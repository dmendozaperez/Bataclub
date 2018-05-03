using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Basico_Metricard;
namespace Service_Envio_Metri
{
    public partial class EnvioMetri : ServiceBase
    {
        Timer tmservicio = null;
        private Int32 _valida_service = 0;

        /*variable para el envio de venta*/
        Timer tmservicio_venta = null;
        private Int32 _valida_service_venta = 0;

        public EnvioMetri()
        {
            InitializeComponent();
            tmservicio = new Timer(30000);
            tmservicio.Elapsed += new ElapsedEventHandler(tmpServicio_Elapsed);

            /*Envio de ventas*/

            tmservicio_venta = new Timer(30000);
            tmservicio_venta.Elapsed += new ElapsedEventHandler(tmservicio_venta_Elapsed);

        }
        void tmservicio_venta_Elapsed(object sender, ElapsedEventArgs e)
        {
            string _error_tarea = "";
            Int32 _valor = 0;
            try
            {
                //verificarsi es el servicio se esta ejeutando

                if (_valida_service_venta == 0)
                {
                    _valor = 1;
                    _valida_service_venta = 1;
                    //activar servicio                                     
                    //string _error = "";
                    //ejecutar la importacion de data
                    BasicoMetri._ejecuta_proceso_enviaVenta_metricard(ref _error_tarea);
                    //********************
                    //si es que hay un error entonces grabamos el error en tabla del sql
                    if (_error_tarea.Trim().Length > 0)
                    {
                        BasicoMetri.insertar_error_service_metricard(_error_tarea);
                    }

                    //una vez se haya realizado las importaciones
                    //setear la tabla en cero
                    _valida_service_venta = 0;
                }
                //****************************************************************************

            }
            catch (Exception ex)
            {
                _valida_service_venta = 0;
                _error_tarea += "===>>" + ex.Message;
                if (_error_tarea.Trim().Length > 0)
                {
                    BasicoMetri.insertar_error_service_metricard(_error_tarea);
                }

                if (_valor == 1)
                {
                    _valida_service_venta = 0;
                }
            }
        }
        void tmpServicio_Elapsed(object sender, ElapsedEventArgs e)
        {
            string _error_tarea = "";
            Int32 _valor = 0;
            try
            {
                //verificarsi es el servicio se esta ejeutando
               
                if (_valida_service == 0)
                {
                    _valor = 1;
                    _valida_service = 1;
                    //activar servicio                                     
                    //string _error = "";
                    //ejecutar la importacion de data
                    BasicoMetri._ejecuta_proceso_envia_metricard(ref _error_tarea);
                    //********************
                    //si es que hay un error entonces grabamos el error en tabla del sql
                    if (_error_tarea.Trim().Length > 0)
                    {
                        BasicoMetri.insertar_error_service_metricard(_error_tarea);
                    }

                    //una vez se haya realizado las importaciones
                    //setear la tabla en cero
                    _valida_service = 0;                                  
                }
                //****************************************************************************

            }
            catch (Exception ex)
            {
                _valida_service = 0;
                _error_tarea += "===>>" + ex.Message;
                if (_error_tarea.Trim().Length > 0)
                {
                    BasicoMetri.insertar_error_service_metricard(_error_tarea);
                }

                if (_valor == 1)
                {                    
                    _valida_service = 0;                 
                }                
            }
        }
        protected override void OnStart(string[] args)
        {
            tmservicio.Start();
            tmservicio_venta.Start();
        }

        protected override void OnStop()
        {
            tmservicio.Stop();
            tmservicio_venta.Stop();
        }
    }
}
