﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bata.ws_clientedniruc {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.consultabata.com/", ConfigurationName="ws_clientedniruc.Cons_ClienteSoap")]
    public interface Cons_ClienteSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_validatdabgwb", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool ws_validatdabgwb(string _cod_tda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_update_cliente", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_update_cliente(string _ruc, string _nombres, string _apepat, string _apemat, string _telefono, string _email, string _tda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_update_venta_empl", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_update_venta_empl(string _Tip_Id_Ven, string _Nro_Dni_Ven, string _Cod_Tda_Ven, string _Nro_Doc_Ven, string _Tip_Doc_Ven, string _Ser_Doc_Ven, string _Num_Doc_Ven, string _Fec_Doc_Ven, string _Est_Doc_Ven, string _Fc_Nin_Ven);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_update_vales", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_update_vales(string _serie, string _correlativo, string _cod_tda_venta, string _dni_venta, string _nombres_venta, string _fecha_doc, string _tipo_doc, string _serie_doc, string _numero_doc, string _estado_doc, string _fc_nint, string _email_venta, string _telefono_venta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_buscar_vales", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ws_buscar_vales(string _correlativo, string _code, string _tda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_buscar_desxdni", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ws_buscar_desxdni(string _dni, string _codtda, string _tip_des);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_conscliente", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable ws_conscliente(string _dniruc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_persona_reniec", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable ws_persona_reniec(string _dni);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_info_sunat", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Bata.ws_clientedniruc.Data_Sunat ws_info_sunat(string _ruc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_persona_sunat", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable ws_persona_sunat(string _ruc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_verifica_version_apltda", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool ws_verifica_version_apltda(string _cod_tda, string _nom_apl, string _ver_apl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.consultabata.com/ws_update_apltda", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ws_update_apltda(string _cod_tda, string _nom_apl, string _ver_apl);
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.consultabata.com/")]
    public partial class Data_Sunat : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string errorField;
        
        private string direccionField;
        
        private string nombresField;
        
        private string rucField;
        
        private string telefonoField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string error {
            get {
                return this.errorField;
            }
            set {
                this.errorField = value;
                this.RaisePropertyChanged("error");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string direccion {
            get {
                return this.direccionField;
            }
            set {
                this.direccionField = value;
                this.RaisePropertyChanged("direccion");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string nombres {
            get {
                return this.nombresField;
            }
            set {
                this.nombresField = value;
                this.RaisePropertyChanged("nombres");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ruc {
            get {
                return this.rucField;
            }
            set {
                this.rucField = value;
                this.RaisePropertyChanged("ruc");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string telefono {
            get {
                return this.telefonoField;
            }
            set {
                this.telefonoField = value;
                this.RaisePropertyChanged("telefono");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Cons_ClienteSoapChannel : Bata.ws_clientedniruc.Cons_ClienteSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Cons_ClienteSoapClient : System.ServiceModel.ClientBase<Bata.ws_clientedniruc.Cons_ClienteSoap>, Bata.ws_clientedniruc.Cons_ClienteSoap {
        
        public Cons_ClienteSoapClient() {
        }
        
        public Cons_ClienteSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Cons_ClienteSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Cons_ClienteSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Cons_ClienteSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ws_validatdabgwb(string _cod_tda) {
            return base.Channel.ws_validatdabgwb(_cod_tda);
        }
        
        public string ws_update_cliente(string _ruc, string _nombres, string _apepat, string _apemat, string _telefono, string _email, string _tda) {
            return base.Channel.ws_update_cliente(_ruc, _nombres, _apepat, _apemat, _telefono, _email, _tda);
        }
        
        public string ws_update_venta_empl(string _Tip_Id_Ven, string _Nro_Dni_Ven, string _Cod_Tda_Ven, string _Nro_Doc_Ven, string _Tip_Doc_Ven, string _Ser_Doc_Ven, string _Num_Doc_Ven, string _Fec_Doc_Ven, string _Est_Doc_Ven, string _Fc_Nin_Ven) {
            return base.Channel.ws_update_venta_empl(_Tip_Id_Ven, _Nro_Dni_Ven, _Cod_Tda_Ven, _Nro_Doc_Ven, _Tip_Doc_Ven, _Ser_Doc_Ven, _Num_Doc_Ven, _Fec_Doc_Ven, _Est_Doc_Ven, _Fc_Nin_Ven);
        }
        
        public string ws_update_vales(string _serie, string _correlativo, string _cod_tda_venta, string _dni_venta, string _nombres_venta, string _fecha_doc, string _tipo_doc, string _serie_doc, string _numero_doc, string _estado_doc, string _fc_nint, string _email_venta, string _telefono_venta) {
            return base.Channel.ws_update_vales(_serie, _correlativo, _cod_tda_venta, _dni_venta, _nombres_venta, _fecha_doc, _tipo_doc, _serie_doc, _numero_doc, _estado_doc, _fc_nint, _email_venta, _telefono_venta);
        }
        
        public System.Data.DataSet ws_buscar_vales(string _correlativo, string _code, string _tda) {
            return base.Channel.ws_buscar_vales(_correlativo, _code, _tda);
        }
        
        public System.Data.DataSet ws_buscar_desxdni(string _dni, string _codtda, string _tip_des) {
            return base.Channel.ws_buscar_desxdni(_dni, _codtda, _tip_des);
        }
        
        public System.Data.DataTable ws_conscliente(string _dniruc) {
            return base.Channel.ws_conscliente(_dniruc);
        }
        
        public System.Data.DataTable ws_persona_reniec(string _dni) {
            return base.Channel.ws_persona_reniec(_dni);
        }
        
        public Bata.ws_clientedniruc.Data_Sunat ws_info_sunat(string _ruc) {
            return base.Channel.ws_info_sunat(_ruc);
        }
        
        public System.Data.DataTable ws_persona_sunat(string _ruc) {
            return base.Channel.ws_persona_sunat(_ruc);
        }
        
        public bool ws_verifica_version_apltda(string _cod_tda, string _nom_apl, string _ver_apl) {
            return base.Channel.ws_verifica_version_apltda(_cod_tda, _nom_apl, _ver_apl);
        }
        
        public string ws_update_apltda(string _cod_tda, string _nom_apl, string _ver_apl) {
            return base.Channel.ws_update_apltda(_cod_tda, _nom_apl, _ver_apl);
        }
    }
}
