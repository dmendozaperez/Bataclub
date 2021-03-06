﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.IO;
using System.Web;
using Tesseract;
using AForge.Imaging.Filters;
using AForge;
using System.Data;
using System.Text.RegularExpressions;
//using HtmlAgilityPack;
using System.Text;

namespace ConsultReniec
{
    public class PersonaReniec
    {
        public enum Resul
        {
            /// <summary>
            /// Se encontro la persona
            /// </summary>
            Ok = 0,
            /// <summary>
            /// No se encontro la persona
            /// </summary>
            NoResul = 1,
            /// <summary>
            /// la imagen capcha no es valida
            /// </summary>
            ErrorCapcha = 2,
            /// <summary>
            /// Error no especificado
            /// </summary>
            Error = 3,
        }

        private Resul state;
        private string _Nombres;
        private string _ApePaterno;
        private string _ApeMaterno;
        private CookieContainer myCookie;

       


        IntRange red = new IntRange(0, 255);
        IntRange green = new IntRange(0, 255);
        IntRange blue = new IntRange(0, 255);

        TesseractEngine engine;
        #region Propiedades

        /// <summary>
        /// Devuelve la imagen para el reto capcha
        /// </summary>
        public Image GetCapcha { get { return ReadCapcha(); } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve los nombres 
        /// de la persona caso contrario devuelve ""
        /// </summary>
        public string Nombres { get { return _Nombres; } }

        public  Int32 estado_reniec { set; get; }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve el Apellido Paterno
        /// de la persona caso contrario devuelve ""
        public string ApePaterno { get { return _ApePaterno; } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve el Apellido Materno
        /// de la persona caso contrario devuelve ""
        public string ApeMaterno { get { return _ApeMaterno; } }

        /// <summary>
        /// Devuelve el resultado de la busqueda de DNI
        /// </summary>
        public Resul GetResul { get { return state; } }


        private Bitmap bmp1;
        private Bitmap bmp2;
        #endregion

        #region Constructor

        public PersonaReniec(Boolean win_cli=false)
        {
            try
            {
                myCookie = null;
                myCookie = new CookieContainer();
                if (win_cli) return;
               

                //Permitir SSL
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                ReadCapcha();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Carga la imagen Capcha
        /// </summary>
        /// 
        public string UseTesseract(string _ruta = "")
        {

            string text = String.Empty;
            try
            {
                //Recordemos que el metodo ( si ya obviaré las tildes ) ... 
                // el metodo ReadCapcha devuelve la imagen ya procesada ...
                using (Bitmap bm = new Bitmap(ReadCapcha()))
                {

                    this.bmp1= bm;

                    //transformar imagen para leer codigo captcha
                    AplicacionFiltros();
                    AplicacionFiltros();
                    //FiltroInvertir(ref bmp);
                    //ColorFiltros(ref bmp);

                    //FiltroInvertir(ref bmp);


                    //Instanciamos el TesseractEngine declarado arriba !
                    //engine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);   

                    using (var engine = new TesseractEngine(@_ruta, "eng", EngineMode.Default))
                    {
                        using (var image = new System.Drawing.Bitmap(this.bmp2))
                        {
                            using (var pix = PixConverter.ToPix(image))
                            {
                                using (var page = engine.Process(pix))
                                {
                                    var Porcentaje = String.Format("{0:P}", page.GetMeanConfidence());
                                    string CaptchaTexto = page.GetText();
                                    char[] eliminarChars = { '\n', ' ' };
                                    CaptchaTexto = CaptchaTexto.TrimEnd(eliminarChars);
                                    CaptchaTexto = CaptchaTexto.Replace(" ", string.Empty);
                                    CaptchaTexto = Regex.Replace(CaptchaTexto, "[^a-zA-Z0-9]+", string.Empty);
                                    if (CaptchaTexto != string.Empty & CaptchaTexto.Length == 4)
                                        text = CaptchaTexto.ToUpper();
                                    //else
                                    //    CargarImagenReniec();
                                }
                            }
                        }

                    }


                    //engine = new TesseractEngine(@_ruta, "eng", EngineMode.Default);


                    //engine.DefaultPageSegMode = PageSegMode.SingleBlock;
                    //Tesseract.Page p = engine.Process(bmp2);
                    //text = p.GetText().Trim().ToUpper().Replace(" ", "");



                    //  Console.WriteLine("Text recognized: " + text);
                }
            }
            catch(Exception exc)
            {

            }
            //Retornamos luego del trabajo del OCR el texto obtenido 
            return text;
        }
       
        private void AplicacionFiltros()
        {
            Bitmap bmp = this.bmp1;
            FiltroInvertir(bmp);
            ColorFiltros();
            Bitmap bmp1 = this.bmp2;
            FiltroInvertir(bmp1);
            Bitmap bmp2 = this.bmp2;
            FiltroSharpen(bmp2);
        }
        private void FiltroSharpen(Bitmap bmp)
        {
            IFilter Filtro = new Sharpen();
            Bitmap XImage = Filtro.Apply(bmp);
            this.bmp2 = XImage;
        }
        private void FiltroInvertir(Bitmap bmp)
        {
            IFilter Filtro = new Invert();
            Bitmap XImage = Filtro.Apply(bmp);
            this.bmp2 = XImage;
        }
        private void ColorFiltros()
        {
            //Red Min - MAX
            red.Min = Math.Min(red.Max, byte.Parse("229"));
            red.Max = Math.Max(red.Min, byte.Parse("255"));
            //Verde Min - MAX
            green.Min = Math.Min(green.Max, byte.Parse("0"));
            green.Max = Math.Max(green.Min, byte.Parse("255"));
            //Azul Min - MAX
            blue.Min = Math.Min(blue.Max, byte.Parse("0"));
            blue.Max = Math.Max(blue.Min, byte.Parse("130"));
            ActualizarFiltro();
        }
        private void ActualizarFiltro()
        {
            ColorFiltering FiltroColor = new ColorFiltering();
            FiltroColor.Red = red;
            FiltroColor.Green = green;
            FiltroColor.Blue = blue;
            IFilter Filtro = FiltroColor;
            Bitmap bmp = this.bmp2;
            Bitmap XImage = Filtro.Apply(bmp);
            this.bmp2 = XImage;
        }
        private Image ReadCapcha()
        {
            try
            {
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("https://cel.reniec.gob.pe/valreg/codigo.do");

                myWebRequest.CookieContainer = myCookie;

                myWebRequest.Proxy = null;

                myWebRequest.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream myImgStream = myWebResponse.GetResponseStream();

                //myWebResponse.Close();

                return Image.FromStream(myImgStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inicia la carga de los datos de la persona 
        /// </summary>
        /// <param name="numDni"></param>
        /// <param name="ImgCapcha"></param>
        /// 
        public void GetInfo(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    _Nombres = dt.Rows[0]["nombres"].ToString();
                    _ApePaterno = dt.Rows[0]["apepat"].ToString();
                    _ApeMaterno= dt.Rows[0]["apemat"].ToString();
                    estado_reniec=Convert.ToInt32(dt.Rows[0]["estado"].ToString());
                }
            }
            catch
            {

            }
        }
        private readonly CookieContainer a = new CookieContainer();
        public string getRawResponseAsync(string url, params object[] parameters)
        {
            string str = Convert.ToString(parameters[0]);
            string s = "hTipo=2&hDni=" + str + "&hApPat=&hApMat=&hNombre=";
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            httpWebRequest.Referer = "http://clientes.reniec.gob.pe/padronElectoral2012/padronPEMDistrito.htm";
            httpWebRequest.CookieContainer = this.a;
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            using (Stream j = httpWebRequest.GetRequestStream())
                j.Write(bytes, 0, bytes.Length);
            string endAsync = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();

            return endAsync;
        }
        private string[] splitString(string _textString, char _character)
        {
            string[] split = null;
            if (!string.IsNullOrEmpty(_textString))
            {
                split = _textString.Split(new Char[] { _character });
            }
            return split;
        }
        public void GetInfo(string numDni, string ImgCapcha)
        {
            try
            {
                //#region<NUEVA CONSULTA DNI>
                //string str = this.getRawResponseAsync("http://clientes.reniec.gob.pe/padronElectoral2012/consulta.htm", (object)numDni);
                //string html = str;
                //str = (string)null;
                //HtmlDocument htmlDocument = new HtmlDocument();
                //htmlDocument.LoadHtml(html);
                //HtmlNodeCollection htmlNodeCollection1 = htmlDocument.DocumentNode.SelectNodes("//table");
                //if (htmlNodeCollection1.Count != 7)
                //    throw new InvalidOperationException("No se pudo conectar con el servidor RENIEC.");
                ////Persona persona = new Persona()
                ////{
                ////    Dni = dni.Trim()
                ////};
                //HtmlNodeCollection htmlNodeCollection2 = htmlNodeCollection1[4].SelectNodes("tr/td");
                //string[] strArray = htmlNodeCollection2[1].InnerHtml.Split(',');
                //this._Nombres = strArray[1].TrimEnd();
                //this._ApeMaterno = strArray[0].TrimEnd();
                //string[] apellidos = splitString(this._ApeMaterno, ' ');

                //this._ApePaterno = apellidos[0].ToString();
                //this._ApeMaterno = apellidos[1].ToString();

                //estado_reniec = 231;
                //state = Resul.Ok;
                ////this._Nombres = nombres_onp[2].ToString().Trim();
                ////this._ApePaterno = nombres_onp[0].ToString().Trim();
                ////this._ApeMaterno = nombres_onp[1].ToString().Trim();
                //return;


                //#endregion

                #region<CONSULTA DE DATA ONPE POR DNI>
                String myurl_onpe = string.Format("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI={0}", numDni);
                HttpWebRequest myWebRequest_onpe = (HttpWebRequest)WebRequest.Create(myurl_onpe);
                myWebRequest_onpe.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";//esto creo que lo puse por gusto :/
                myWebRequest_onpe.CookieContainer = myCookie;
                myWebRequest_onpe.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest_onpe.Proxy = null;

                HttpWebResponse myHttpWebResponse_onpe = (HttpWebResponse)myWebRequest_onpe.GetResponse();

                Stream myStream_onpe = myHttpWebResponse_onpe.GetResponseStream();

                StreamReader myStreamReader_onpe = new StreamReader(myStream_onpe);

                string _WebSource_onpe = HttpUtility.HtmlDecode(myStreamReader_onpe.ReadToEnd());


                if (_WebSource_onpe.Length>0)
                {
                    string[] nombres_onp = _WebSource_onpe.Split('|');

                    if (nombres_onp.Length>0)
                    {
                        estado_reniec = 231;
                        state = Resul.Ok;
                        this._Nombres = nombres_onp[2].ToString().Trim() ;
                        this._ApePaterno = nombres_onp[0].ToString().Trim(); 
                        this._ApeMaterno = nombres_onp[1].ToString().Trim(); 
                        return;
                    }

                }


                #endregion

                string myUrl = String.Format("https://cel.reniec.gob.pe/valreg/valreg.do?accion=buscar&nuDni={0}&imagen={1}",
                                        numDni, ImgCapcha);

                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
                myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";//esto creo que lo puse por gusto :/
                myWebRequest.CookieContainer = myCookie;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;

                //myWebRequest.ContentType = "text/html;charset=ISO-8859-1";
                //myWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream myStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(myStream);

                string _WebSource = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

                string[] _split = _WebSource.Split(new char[] { '<', '>', '\n', '\r' });

                List<string> _resul = new List<string>();

                //quitamos todos los caracteres nulos
                for (int i = 0; i < _split.Length; i++)
                {
                    if (!string.IsNullOrEmpty(_split[i].Trim()))
                        _resul.Add(_split[i].Trim());
                }



                // Anlizando la el arreglo "_resul" llegamos a la siguiente conclusion
                // 
                // _resul.Count == 217 cuando nos equivocamos en el captcha
                // _resul.Count == 232 cuando todo salio ok
                // _resul.Count == 222 cuando no existe el DNI
                //

                switch (_resul.Count)
                {
                    case 217:
                        estado_reniec = 217;
                        state = Resul.ErrorCapcha;
                        break;
                    case 231:
                        estado_reniec = 231;
                        state = Resul.Ok;
                        break;
                    case 232:
                        estado_reniec = 231;
                        state = Resul.Ok;
                        break;
                    case 222:
                        estado_reniec = 222;
                        state = Resul.NoResul;
                        break;
                    default:
                        estado_reniec = 0;
                        state = Resul.Error;
                        break;
                }

                if (state == Resul.Ok)
                {
                    this._Nombres = _resul[185];
                    this._ApePaterno = _resul[186];
                    this._ApeMaterno = _resul[187];
                    //this._Nombres = this._Nombres.Replace("�", "Ñ");
                    //this._ApePaterno = this._ApePaterno.Replace("�", "Ñ");
                    //this._ApeMaterno = this._ApeMaterno.Replace("�", "Ñ");

                    if (this._ApeMaterno == "br") this._ApeMaterno = "";
                }
                if (state == Resul.ErrorCapcha && _resul[185].ToString() == "Cancelado por fallecimiento.")
                {
                    this._Nombres = _resul[185];
                }

                myHttpWebResponse.Close();
            }
            catch (Exception ex)
            {
                estado_reniec = 0;
                state = Resul.Error;
                //throw ex;
            }
        }
    }
}
