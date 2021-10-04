<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PartnerMiscDetails.aspx.cs" Inherits="CMSApplication.PartnerMiscDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .ValidationClass {
            position: absolute;
            float: right;
            color: red;
        }

        .hideDiv {
            display: none;
        }
    </style>
    <div class="container-fluid">
        <div class="row">

            <div class="col-md-12">

                <div id="navCompany" class="tab-pane active">
                    <div class="row align-items-center">
                        <div class="container-fluid">
                            <div class="row justify-content-center">
                                <div class="col-lg-12">
                                    <div class="card">
                                        <div class="card-body">
                                             <div class="">
                                                <div style="float: right">
                                                    <asp:Button CssClass="btn btn-primary" ID="btnBackToDashboard" runat="server" Text="Back To Dashboard"
                                                        OnClick="btnBackToDashboard_Click" />
                                                </div>
                                            </div>
                                            <h2 style="text-align: center; color: #04c;padding-bottom:13px" id="miscPageHeading" runat="server"></h2>
                                            <div class="form-validation">
                                                <div class="form-valide">
                                                    <div class="hideDiv" id="SuccessFailureMessage" runat="server">
                                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                            <span aria-hidden="true">×</span>
                                                        </button>
                                                        <span id="SuccessFailureMessageSpan" runat="server"></span>
                                                    </div>

                                                    <%-- Name --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblMiscName" Text="Name" CssClass="col-form-label"
                                                                AssociatedControlID="txtMiscName" />
                                                            <span class="text-danger">*</span>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <asp:TextBox ID="txtMiscName" runat="server" CssClass="form-control" CausesValidation="true" />
                                                            <asp:RequiredFieldValidator ID="reqMiscName" runat="server" ControlToValidate="txtMiscName" ErrorMessage="*" ForeColor="Red"
                                                                CssClass="ValidationClass" ValidationGroup="Validate" Display="Dynamic" />
                                                        </div>
                                                    </div>   
                                                    
                                                    <%-- ExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblMiscExpiryDate" Text="Misc Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtMiscExpiryDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtMiscExpiryDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- Notes --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblNotes" Text="Notes" CssClass="col-form-label"
                                                                AssociatedControlID="txtMiscNotes"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtMiscNotes" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                                        </div>
                                                    </div>

                                                    <%-- Active --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblMiscActive" Text="Active" CssClass="col-form-label"
                                                                AssociatedControlID="chkMiscActive"></asp:Label>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:CheckBox ID="chkMiscActive" runat="server" Checked="true" />
                                                        </div>
                                                    </div>

                                                    <%-- SAVE Button --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-8 ml-auto">
                                                            <asp:Button CssClass="btn btn-primary" ID="btnMisc" runat="server" Text="Save" OnClick="btnMiscSave_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
