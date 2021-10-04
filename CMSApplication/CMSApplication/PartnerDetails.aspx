<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PartnerDetails.aspx.cs" Inherits="CMSApplication.PartnerDetails" %>

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
                                            <h2 style="text-align: center; color: #04c;padding-bottom:13px" id="partnerpageHeading" runat="server"></h2>
                                            <div class="form-validation">
                                                <div class="form-valide">
                                                    <div class="hideDiv" id="SuccessFailureMessage" runat="server">
                                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                            <span aria-hidden="true">×</span>
                                                        </button>
                                                        <span id="SuccessFailureMessageSpan" runat="server"></span>
                                                    </div>
                                                    <%-- Partner Name --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPartnerName" Text="Partner Name" CssClass="col-form-label"
                                                                AssociatedControlID="txtPartnerName" />
                                                            <span class="text-danger">*</span>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <asp:TextBox ID="txtPartnerName" runat="server" CssClass="form-control" CausesValidation="true" />
                                                            <asp:RequiredFieldValidator ID="reqPartnerName" runat="server" ControlToValidate="txtPartnerName" ErrorMessage="*" ForeColor="Red"
                                                                CssClass="ValidationClass" ValidationGroup="Validate" Display="Dynamic" />
                                                        </div>
                                                    </div>


                                                    <%-- Phone--%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPartnerPhone" Text="Phone" CssClass="col-form-label" CausesValidation="true"
                                                                AssociatedControlID="txtPartnerPhone"></asp:Label>
                                                            <span class="text-danger">*</span>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPartnerPhone" runat="server" CssClass="form-control" />
                                                            <%-- RequiredFieldValidator --%>
                                                            <asp:RequiredFieldValidator ID="reqPartnerPhone" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtPartnerPhone" ValidationGroup="Validate" CssClass="ValidationClass" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>

                                                            <%-- Regular Expression Validator --%>
                                                            <asp:RegularExpressionValidator ID="regPartnerPhone" runat="server" ErrorMessage="Invalid Mobile Number."
                                                                ValidationExpression="^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$" ControlToValidate="txtPartnerPhone"
                                                                ValidationGroup="Validate" CssClass="ValidationClass" Display="Dynamic">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>

                                                    <%-- PassportExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPartnerPassportExpDate" Text="Passport Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtPartnerPassportExpDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPartnerPassportExpDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- InsuranceExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPartnerInsuranceExpiryDate" Text="Insurance Expiry Date"
                                                                CssClass="col-form-label" AssociatedControlID="txtPartnerInsuranceExpiryDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPartnerInsuranceExpiryDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- VisaExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPartnerVisaExpiryDate" Text="Visa Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtPartnerVisaExpiryDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPartnerVisaExpiryDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- Notes --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblNotes" Text="Notes" CssClass="col-form-label"
                                                                AssociatedControlID="txtParterNotes"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtParterNotes" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                                        </div>
                                                    </div>

                                                    <%-- Active --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPatrtnerActive" Text="Active" CssClass="col-form-label"
                                                                AssociatedControlID="chkPartnerActive"></asp:Label>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:CheckBox ID="chkPartnerActive" runat="server" Checked="true" />
                                                        </div>
                                                    </div>

                                                    <%-- SAVE Button --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-8 ml-auto">
                                                            <asp:Button CssClass="btn btn-primary" ID="btnParterSave" runat="server" Text="Save" OnClick="btnPartnerSave_Click" />
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
