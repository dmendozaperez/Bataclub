﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bata.Ws_BataClub {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://bata.ecommerce.pe/", ConfigurationName="Ws_BataClub.BataEcommerceSoap")]
    public interface BataEcommerceSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el mensaje ws_registrar_ClienteRequest tiene encabezados.
        [System.ServiceModel.OperationContractAttribute(Action="http://bata.ecommerce.pe/ws_registrar_Cliente", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Bata.Ws_BataClub.ws_registrar_ClienteResponse ws_registrar_Cliente(Bata.Ws_BataClub.ws_registrar_ClienteRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el mensaje ws_consultar_ClienteRequest tiene encabezados.
        [System.ServiceModel.OperationContractAttribute(Action="http://bata.ecommerce.pe/ws_consultar_Cliente", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Bata.Ws_BataClub.ws_consultar_ClienteResponse ws_consultar_Cliente(Bata.Ws_BataClub.ws_consultar_ClienteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bata.ecommerce.pe/ws_genera_barra", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Bata.Ws_BataClub.Ent_MsgTransacBarra ws_genera_barra(string user, string password, string barra);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bata.ecommerce.pe/")]
    public partial class ValidateAcceso : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string usernameField;
        
        private string passwordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("Username");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
                this.RaisePropertyChanged("AnyAttr");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bata.ecommerce.pe/")]
    public partial class Ent_MsgTransacBarra : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string estadoField;
        
        private string descripcionField;
        
        private string uriField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
                this.RaisePropertyChanged("estado");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("descripcion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string uri {
            get {
                return this.uriField;
            }
            set {
                this.uriField = value;
                this.RaisePropertyChanged("uri");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bata.ecommerce.pe/")]
    public partial class Cliente_Parameter_Bataclub : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string dniField;
        
        private string dni_barraField;
        
        private string envia_correoField;
        
        private string correo_updateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string dni {
            get {
                return this.dniField;
            }
            set {
                this.dniField = value;
                this.RaisePropertyChanged("dni");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string dni_barra {
            get {
                return this.dni_barraField;
            }
            set {
                this.dni_barraField = value;
                this.RaisePropertyChanged("dni_barra");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string envia_correo {
            get {
                return this.envia_correoField;
            }
            set {
                this.envia_correoField = value;
                this.RaisePropertyChanged("envia_correo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string correo_update {
            get {
                return this.correo_updateField;
            }
            set {
                this.correo_updateField = value;
                this.RaisePropertyChanged("correo_update");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bata.ecommerce.pe/")]
    public partial class Ent_MsgTransac : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string codigoField;
        
        private string descripcionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string codigo {
            get {
                return this.codigoField;
            }
            set {
                this.codigoField = value;
                this.RaisePropertyChanged("codigo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("descripcion");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bata.ecommerce.pe/")]
    public partial class Ent_Cliente_BataClub : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string canalField;
        
        private string dniField;
        
        private string primerNombreField;
        
        private string segundoNombreField;
        
        private string apellidoPaterField;
        
        private string apellidoMaterField;
        
        private string generoField;
        
        private string correoField;
        
        private string fecNacField;
        
        private string telefonoField;
        
        private string ubigeoField;
        
        private string ubigeo_distritoField;
        
        private string tiendaField;
        
        private bool registradoField;
        
        private bool miembro_bataclubField;
        
        private bool existe_clienteField;
        
        private string descripcion_errorField;
        
        private string barra_clienteField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string canal {
            get {
                return this.canalField;
            }
            set {
                this.canalField = value;
                this.RaisePropertyChanged("canal");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string dni {
            get {
                return this.dniField;
            }
            set {
                this.dniField = value;
                this.RaisePropertyChanged("dni");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string primerNombre {
            get {
                return this.primerNombreField;
            }
            set {
                this.primerNombreField = value;
                this.RaisePropertyChanged("primerNombre");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string segundoNombre {
            get {
                return this.segundoNombreField;
            }
            set {
                this.segundoNombreField = value;
                this.RaisePropertyChanged("segundoNombre");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string apellidoPater {
            get {
                return this.apellidoPaterField;
            }
            set {
                this.apellidoPaterField = value;
                this.RaisePropertyChanged("apellidoPater");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string apellidoMater {
            get {
                return this.apellidoMaterField;
            }
            set {
                this.apellidoMaterField = value;
                this.RaisePropertyChanged("apellidoMater");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string genero {
            get {
                return this.generoField;
            }
            set {
                this.generoField = value;
                this.RaisePropertyChanged("genero");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string correo {
            get {
                return this.correoField;
            }
            set {
                this.correoField = value;
                this.RaisePropertyChanged("correo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string fecNac {
            get {
                return this.fecNacField;
            }
            set {
                this.fecNacField = value;
                this.RaisePropertyChanged("fecNac");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string telefono {
            get {
                return this.telefonoField;
            }
            set {
                this.telefonoField = value;
                this.RaisePropertyChanged("telefono");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string ubigeo {
            get {
                return this.ubigeoField;
            }
            set {
                this.ubigeoField = value;
                this.RaisePropertyChanged("ubigeo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string ubigeo_distrito {
            get {
                return this.ubigeo_distritoField;
            }
            set {
                this.ubigeo_distritoField = value;
                this.RaisePropertyChanged("ubigeo_distrito");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string tienda {
            get {
                return this.tiendaField;
            }
            set {
                this.tiendaField = value;
                this.RaisePropertyChanged("tienda");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public bool registrado {
            get {
                return this.registradoField;
            }
            set {
                this.registradoField = value;
                this.RaisePropertyChanged("registrado");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public bool miembro_bataclub {
            get {
                return this.miembro_bataclubField;
            }
            set {
                this.miembro_bataclubField = value;
                this.RaisePropertyChanged("miembro_bataclub");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public bool existe_cliente {
            get {
                return this.existe_clienteField;
            }
            set {
                this.existe_clienteField = value;
                this.RaisePropertyChanged("existe_cliente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string descripcion_error {
            get {
                return this.descripcion_errorField;
            }
            set {
                this.descripcion_errorField = value;
                this.RaisePropertyChanged("descripcion_error");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string barra_cliente {
            get {
                return this.barra_clienteField;
            }
            set {
                this.barra_clienteField = value;
                this.RaisePropertyChanged("barra_cliente");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ws_registrar_Cliente", WrapperNamespace="http://bata.ecommerce.pe/", IsWrapped=true)]
    public partial class ws_registrar_ClienteRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://bata.ecommerce.pe/")]
        public Bata.Ws_BataClub.ValidateAcceso ValidateAcceso;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bata.ecommerce.pe/", Order=0)]
        public Bata.Ws_BataClub.Ent_Cliente_BataClub Cliente;
        
        public ws_registrar_ClienteRequest() {
        }
        
        public ws_registrar_ClienteRequest(Bata.Ws_BataClub.ValidateAcceso ValidateAcceso, Bata.Ws_BataClub.Ent_Cliente_BataClub Cliente) {
            this.ValidateAcceso = ValidateAcceso;
            this.Cliente = Cliente;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ws_registrar_ClienteResponse", WrapperNamespace="http://bata.ecommerce.pe/", IsWrapped=true)]
    public partial class ws_registrar_ClienteResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bata.ecommerce.pe/", Order=0)]
        public Bata.Ws_BataClub.Ent_MsgTransac ws_registrar_ClienteResult;
        
        public ws_registrar_ClienteResponse() {
        }
        
        public ws_registrar_ClienteResponse(Bata.Ws_BataClub.Ent_MsgTransac ws_registrar_ClienteResult) {
            this.ws_registrar_ClienteResult = ws_registrar_ClienteResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ws_consultar_Cliente", WrapperNamespace="http://bata.ecommerce.pe/", IsWrapped=true)]
    public partial class ws_consultar_ClienteRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://bata.ecommerce.pe/")]
        public Bata.Ws_BataClub.ValidateAcceso ValidateAcceso;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bata.ecommerce.pe/", Order=0)]
        public Bata.Ws_BataClub.Cliente_Parameter_Bataclub dni;
        
        public ws_consultar_ClienteRequest() {
        }
        
        public ws_consultar_ClienteRequest(Bata.Ws_BataClub.ValidateAcceso ValidateAcceso, Bata.Ws_BataClub.Cliente_Parameter_Bataclub dni) {
            this.ValidateAcceso = ValidateAcceso;
            this.dni = dni;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ws_consultar_ClienteResponse", WrapperNamespace="http://bata.ecommerce.pe/", IsWrapped=true)]
    public partial class ws_consultar_ClienteResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bata.ecommerce.pe/", Order=0)]
        public Bata.Ws_BataClub.Ent_Cliente_BataClub ws_consultar_ClienteResult;
        
        public ws_consultar_ClienteResponse() {
        }
        
        public ws_consultar_ClienteResponse(Bata.Ws_BataClub.Ent_Cliente_BataClub ws_consultar_ClienteResult) {
            this.ws_consultar_ClienteResult = ws_consultar_ClienteResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BataEcommerceSoapChannel : Bata.Ws_BataClub.BataEcommerceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BataEcommerceSoapClient : System.ServiceModel.ClientBase<Bata.Ws_BataClub.BataEcommerceSoap>, Bata.Ws_BataClub.BataEcommerceSoap {
        
        public BataEcommerceSoapClient() {
        }
        
        public BataEcommerceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BataEcommerceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BataEcommerceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BataEcommerceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Bata.Ws_BataClub.ws_registrar_ClienteResponse Bata.Ws_BataClub.BataEcommerceSoap.ws_registrar_Cliente(Bata.Ws_BataClub.ws_registrar_ClienteRequest request) {
            return base.Channel.ws_registrar_Cliente(request);
        }
        
        public Bata.Ws_BataClub.Ent_MsgTransac ws_registrar_Cliente(Bata.Ws_BataClub.ValidateAcceso ValidateAcceso, Bata.Ws_BataClub.Ent_Cliente_BataClub Cliente) {
            Bata.Ws_BataClub.ws_registrar_ClienteRequest inValue = new Bata.Ws_BataClub.ws_registrar_ClienteRequest();
            inValue.ValidateAcceso = ValidateAcceso;
            inValue.Cliente = Cliente;
            Bata.Ws_BataClub.ws_registrar_ClienteResponse retVal = ((Bata.Ws_BataClub.BataEcommerceSoap)(this)).ws_registrar_Cliente(inValue);
            return retVal.ws_registrar_ClienteResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Bata.Ws_BataClub.ws_consultar_ClienteResponse Bata.Ws_BataClub.BataEcommerceSoap.ws_consultar_Cliente(Bata.Ws_BataClub.ws_consultar_ClienteRequest request) {
            return base.Channel.ws_consultar_Cliente(request);
        }
        
        public Bata.Ws_BataClub.Ent_Cliente_BataClub ws_consultar_Cliente(Bata.Ws_BataClub.ValidateAcceso ValidateAcceso, Bata.Ws_BataClub.Cliente_Parameter_Bataclub dni) {
            Bata.Ws_BataClub.ws_consultar_ClienteRequest inValue = new Bata.Ws_BataClub.ws_consultar_ClienteRequest();
            inValue.ValidateAcceso = ValidateAcceso;
            inValue.dni = dni;
            Bata.Ws_BataClub.ws_consultar_ClienteResponse retVal = ((Bata.Ws_BataClub.BataEcommerceSoap)(this)).ws_consultar_Cliente(inValue);
            return retVal.ws_consultar_ClienteResult;
        }
        
        public Bata.Ws_BataClub.Ent_MsgTransacBarra ws_genera_barra(string user, string password, string barra) {
            return base.Channel.ws_genera_barra(user, password, barra);
        }
    }
}
