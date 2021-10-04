<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCompanyOperations.aspx.cs" Inherits="CMSApplication.WebForm2" %>

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
                                            <h2 style="text-align: center; color: #04c">Add Company </h2>
                                            <div class="form-validation">
                                                <div class="form-valide">
                                                    <div class="hideDiv" id="SuccessFailureMessage" runat="server">
                                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                            <span aria-hidden="true">×</span>
                                                        </button>
                                                        <span id="SuccessFailureMessageSpan" runat="server"></span>
                                                    </div>
                                                    <%-- Company Name --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblCompanyName" Text="Company Name" CssClass="col-form-label"
                                                                AssociatedControlID="txtCompanyName" />
                                                            <span class="text-danger">*</span>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" CausesValidation="true" />
                                                            <asp:RequiredFieldValidator ID="reqCompanyName" runat="server" ControlToValidate="txtCompanyName" ErrorMessage="*" ForeColor="Red"
                                                                CssClass="ValidationClass" ValidationGroup="Validate" Display="Dynamic" />
                                                        </div>
                                                    </div>

                                                    <%-- Address--%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblCompanyAddress" Text="Address" CssClass="col-form-label"
                                                                AssociatedControlID="txtCompanyAddress"></asp:Label>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                                        </div>
                                                    </div>

                                                    <%-- Phone--%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblCompanyPhone" Text="Phone" CssClass="col-form-label" CausesValidation="true"
                                                                AssociatedControlID="txtCompanyPhone"></asp:Label>
                                                            <span class="text-danger">*</span>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCompanyPhone" runat="server" CssClass="form-control" />
                                                            <%-- RequiredFieldValidator --%>
                                                            <asp:RequiredFieldValidator ID="reqCompanyPhone" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtCompanyPhone" ValidationGroup="Validate" CssClass="ValidationClass" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>

                                                            <%-- Regular Expression Validator --%>
                                                            <asp:RegularExpressionValidator ID="regCompanyPhone" runat="server" ErrorMessage="Invalid Mobile Number."
                                                                ValidationExpression="^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$" ControlToValidate="txtCompanyPhone"
                                                                ValidationGroup="Validate" CssClass="ValidationClass" Display="Dynamic">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <%-- Email --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblEmail" Text="Email" CssClass="col-form-label" CausesValidation="true"
                                                                AssociatedControlID="txtCompanyEmail"></asp:Label>
                                                            <span class="text-danger">*</span>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCompanyEmail" runat="server" CssClass="form-control" />
                                                            <%-- RequiredFieldValidator --%>
                                                            <asp:RequiredFieldValidator ID="reqCompanyEmail" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtCompanyEmail" ValidationGroup="Validate" CssClass="ValidationClass" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>

                                                            <%-- Regular Expression Validator --%>
                                                            <asp:RegularExpressionValidator ID="regCompanyEmail" runat="server" ErrorMessage="Invalid Email"
                                                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtCompanyEmail"
                                                                ValidationGroup="Validate" CssClass="ValidationClass" Display="Dynamic">
                                                            </asp:RegularExpressionValidator>

                                                        </div>
                                                    </div>

                                                    <%-- TradeLicenceExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblCompanyTradeLicenceExp" Text="Trade Licence Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtCompanyTradeLicenceExpDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCompanyTradeLicenceExpDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- ImmigraitonExpirtyDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblCompanyImmigraitonExpDate" Text="Company Immigration Expiry Date"
                                                                CssClass="col-form-label" AssociatedControlID="txtCompanyImmigraitonExpDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCompanyImmigraitonExpDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- ImportCodeExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblCompanyImportCodeExpDate" Text="Company Import Code Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtCompanyImportCodeExpDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCompanyImportCodeExpDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- InsuranceExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblCompanyInsuranceExpDate" Text="Company Insurance Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtCompanyInsuranceExpDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCompanyInsuranceExpDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- Contact Person --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblContactPerson" Text="Contact Person" CssClass="col-form-label"
                                                                AssociatedControlID="txtCompanyContactPerson"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCompanyContactPerson" runat="server" CssClass="form-control" />
                                                        </div>
                                                    </div>

                                                    <%-- Contact Person's Phone --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblContactPersonPhone" Text="Contact Person Phone" CssClass="col-form-label"
                                                                AssociatedControlID="txtContactPersonPhone"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtContactPersonPhone" runat="server" CssClass="form-control" />
                                                        </div>
                                                    </div>

                                                    <%-- Notes --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblNotes" Text="Notes" CssClass="col-form-label"
                                                                AssociatedControlID="txtCompanyNotes"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCompanyNotes" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                                        </div>
                                                    </div>

                                                    <%-- Active --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblCompanyActive" Text="Active" CssClass="col-form-label"
                                                                AssociatedControlID="chkCompanyActive"></asp:Label>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:CheckBox ID="chkCompanyActive" runat="server" Checked="true" />
                                                        </div>
                                                    </div>

                                                    <%-- SAVE Button --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-8 ml-auto">
                                                            <asp:Button CssClass="btn btn-primary" ID="btnCompanySave" runat="server" Text="Save" OnClick="btnCompanySave_Click" />
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
