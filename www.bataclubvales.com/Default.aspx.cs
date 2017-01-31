using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;
namespace www.bataclubvales.com
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod()]
        public static List<Imagenes> Galeria()
        {
            List<Imagenes> listImagenes = new List<Imagenes>();
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "ImagesUp");
            FileInfo[] fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

            var fileQuery = from file in fileList
                            where file.Extension == ".jpg"
                            orderby file.Name
                            select file;

            foreach (var file in fileQuery)
            {
                listImagenes.Add(new Imagenes("ImagesUp/" + file.Name));
            }
            return listImagenes;
        }

        public class Imagenes
        {
            public string imagen { get; set; }
            public Imagenes(string sImagen)
            {
                imagen = sImagen;
            }
        }
    } 

}