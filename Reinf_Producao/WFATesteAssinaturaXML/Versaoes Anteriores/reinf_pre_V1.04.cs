﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------
namespace reinfPreWSDL_V1_04
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;

    // 
    // This source code was auto-generated by wsdl, Version=4.6.1055.0.
    // 


    /// <remarks/>
    // CODEGEN: O elemento de extensão WSDL opcional 'PolicyReference' do espaço para nome 'http://schemas.xmlsoap.org/ws/2004/09/policy' não foi tratado.
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "BasicHttpBinding_RecepcaoLoteReinf", Namespace = "http://sped.fazenda.gov.br/")]
    public partial class RecepcaoLoteReinf : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback ReceberLoteEventosOperationCompleted;

        /// <remarks/>
        public RecepcaoLoteReinf()
        {
            this.Url = "https://reinf.receita.fazenda.gov.br/WsREINF/RecepcaoLoteReinf.svc";
            
            //"https://preprodefdreinf.receita.fazenda.gov.br/WsREINF/RecepcaoLoteReinf.svc";                        
        }

        /// <remarks/>
        public event ReceberLoteEventosCompletedEventHandler ReceberLoteEventosCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sped.fazenda.gov.br/RecepcaoLoteReinf/ReceberLoteEventos", RequestNamespace = "http://sped.fazenda.gov.br/", ResponseNamespace = "http://sped.fazenda.gov.br/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode ReceberLoteEventos(System.Xml.XmlNode loteEventos)
        {
            object[] results = this.Invoke("ReceberLoteEventos", new object[] {
                    loteEventos});
            return ((System.Xml.XmlNode)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginReceberLoteEventos(System.Xml.XmlNode loteEventos, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("ReceberLoteEventos", new object[] {
                    loteEventos}, callback, asyncState);
        }

        /// <remarks/>
        public System.Xml.XmlNode EndReceberLoteEventos(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }

        /// <remarks/>
        public void ReceberLoteEventosAsync(System.Xml.XmlNode loteEventos)
        {
            this.ReceberLoteEventosAsync(loteEventos, null);
        }

        /// <remarks/>
        public void ReceberLoteEventosAsync(System.Xml.XmlNode loteEventos, object userState)
        {
            if ((this.ReceberLoteEventosOperationCompleted == null))
            {
                this.ReceberLoteEventosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReceberLoteEventosOperationCompleted);
            }
            this.InvokeAsync("ReceberLoteEventos", new object[] {
                    loteEventos}, this.ReceberLoteEventosOperationCompleted, userState);
        }

        private void OnReceberLoteEventosOperationCompleted(object arg)
        {
            if ((this.ReceberLoteEventosCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReceberLoteEventosCompleted(this, new ReceberLoteEventosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    public delegate void ReceberLoteEventosCompletedEventHandler(object sender, ReceberLoteEventosCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReceberLoteEventosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal ReceberLoteEventosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public System.Xml.XmlNode Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }

}