﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace CMSAlertApplication.CRMService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServicesSoap", Namespace="http://tempuri.org/")]
    public partial class Services : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCompanyAlertOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetPartnerAlertOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetEmployeeAlertOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetPartnerFamilyAlertOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetPartnerMiscAlertOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Services() {
            this.Url = global::CMSAlertApplication.Properties.Settings.Default.CMSAlertApplication_CRMService_Services;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event GetCompanyAlertCompletedEventHandler GetCompanyAlertCompleted;
        
        /// <remarks/>
        public event GetPartnerAlertCompletedEventHandler GetPartnerAlertCompleted;
        
        /// <remarks/>
        public event GetEmployeeAlertCompletedEventHandler GetEmployeeAlertCompleted;
        
        /// <remarks/>
        public event GetPartnerFamilyAlertCompletedEventHandler GetPartnerFamilyAlertCompleted;
        
        /// <remarks/>
        public event GetPartnerMiscAlertCompletedEventHandler GetPartnerMiscAlertCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCompanyAlert", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetCompanyAlert(string fromDate, string toDate) {
            object[] results = this.Invoke("GetCompanyAlert", new object[] {
                        fromDate,
                        toDate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetCompanyAlertAsync(string fromDate, string toDate) {
            this.GetCompanyAlertAsync(fromDate, toDate, null);
        }
        
        /// <remarks/>
        public void GetCompanyAlertAsync(string fromDate, string toDate, object userState) {
            if ((this.GetCompanyAlertOperationCompleted == null)) {
                this.GetCompanyAlertOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCompanyAlertOperationCompleted);
            }
            this.InvokeAsync("GetCompanyAlert", new object[] {
                        fromDate,
                        toDate}, this.GetCompanyAlertOperationCompleted, userState);
        }
        
        private void OnGetCompanyAlertOperationCompleted(object arg) {
            if ((this.GetCompanyAlertCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCompanyAlertCompleted(this, new GetCompanyAlertCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPartnerAlert", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetPartnerAlert(string fromDate, string toDate) {
            object[] results = this.Invoke("GetPartnerAlert", new object[] {
                        fromDate,
                        toDate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetPartnerAlertAsync(string fromDate, string toDate) {
            this.GetPartnerAlertAsync(fromDate, toDate, null);
        }
        
        /// <remarks/>
        public void GetPartnerAlertAsync(string fromDate, string toDate, object userState) {
            if ((this.GetPartnerAlertOperationCompleted == null)) {
                this.GetPartnerAlertOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPartnerAlertOperationCompleted);
            }
            this.InvokeAsync("GetPartnerAlert", new object[] {
                        fromDate,
                        toDate}, this.GetPartnerAlertOperationCompleted, userState);
        }
        
        private void OnGetPartnerAlertOperationCompleted(object arg) {
            if ((this.GetPartnerAlertCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPartnerAlertCompleted(this, new GetPartnerAlertCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetEmployeeAlert", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetEmployeeAlert(string fromDate, string toDate) {
            object[] results = this.Invoke("GetEmployeeAlert", new object[] {
                        fromDate,
                        toDate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetEmployeeAlertAsync(string fromDate, string toDate) {
            this.GetEmployeeAlertAsync(fromDate, toDate, null);
        }
        
        /// <remarks/>
        public void GetEmployeeAlertAsync(string fromDate, string toDate, object userState) {
            if ((this.GetEmployeeAlertOperationCompleted == null)) {
                this.GetEmployeeAlertOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetEmployeeAlertOperationCompleted);
            }
            this.InvokeAsync("GetEmployeeAlert", new object[] {
                        fromDate,
                        toDate}, this.GetEmployeeAlertOperationCompleted, userState);
        }
        
        private void OnGetEmployeeAlertOperationCompleted(object arg) {
            if ((this.GetEmployeeAlertCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetEmployeeAlertCompleted(this, new GetEmployeeAlertCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPartnerFamilyAlert", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetPartnerFamilyAlert(string fromDate, string toDate) {
            object[] results = this.Invoke("GetPartnerFamilyAlert", new object[] {
                        fromDate,
                        toDate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetPartnerFamilyAlertAsync(string fromDate, string toDate) {
            this.GetPartnerFamilyAlertAsync(fromDate, toDate, null);
        }
        
        /// <remarks/>
        public void GetPartnerFamilyAlertAsync(string fromDate, string toDate, object userState) {
            if ((this.GetPartnerFamilyAlertOperationCompleted == null)) {
                this.GetPartnerFamilyAlertOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPartnerFamilyAlertOperationCompleted);
            }
            this.InvokeAsync("GetPartnerFamilyAlert", new object[] {
                        fromDate,
                        toDate}, this.GetPartnerFamilyAlertOperationCompleted, userState);
        }
        
        private void OnGetPartnerFamilyAlertOperationCompleted(object arg) {
            if ((this.GetPartnerFamilyAlertCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPartnerFamilyAlertCompleted(this, new GetPartnerFamilyAlertCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPartnerMiscAlert", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetPartnerMiscAlert(string fromDate, string toDate) {
            object[] results = this.Invoke("GetPartnerMiscAlert", new object[] {
                        fromDate,
                        toDate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetPartnerMiscAlertAsync(string fromDate, string toDate) {
            this.GetPartnerMiscAlertAsync(fromDate, toDate, null);
        }
        
        /// <remarks/>
        public void GetPartnerMiscAlertAsync(string fromDate, string toDate, object userState) {
            if ((this.GetPartnerMiscAlertOperationCompleted == null)) {
                this.GetPartnerMiscAlertOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPartnerMiscAlertOperationCompleted);
            }
            this.InvokeAsync("GetPartnerMiscAlert", new object[] {
                        fromDate,
                        toDate}, this.GetPartnerMiscAlertOperationCompleted, userState);
        }
        
        private void OnGetPartnerMiscAlertOperationCompleted(object arg) {
            if ((this.GetPartnerMiscAlertCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPartnerMiscAlertCompleted(this, new GetPartnerMiscAlertCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetCompanyAlertCompletedEventHandler(object sender, GetCompanyAlertCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCompanyAlertCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCompanyAlertCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetPartnerAlertCompletedEventHandler(object sender, GetPartnerAlertCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPartnerAlertCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPartnerAlertCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetEmployeeAlertCompletedEventHandler(object sender, GetEmployeeAlertCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetEmployeeAlertCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetEmployeeAlertCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetPartnerFamilyAlertCompletedEventHandler(object sender, GetPartnerFamilyAlertCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPartnerFamilyAlertCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPartnerFamilyAlertCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void GetPartnerMiscAlertCompletedEventHandler(object sender, GetPartnerMiscAlertCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPartnerMiscAlertCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPartnerMiscAlertCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591