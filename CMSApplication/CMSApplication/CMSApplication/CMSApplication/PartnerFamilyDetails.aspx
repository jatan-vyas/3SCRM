<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PartnerFamilyDetails.aspx.cs" Inherits="CMSApplication.PartnerFamilyDetails" %>
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
                                            <h2 style="text-align: center; color: #04c;padding-bottom:13px" id="partnerFamilyPageHeading" runat="server"></h2>
                                            <div class="form-validation">
                                                <div class="form-valide">
                                                    <div class="hideDiv" id="SuccessFailureMessage" runat="server">
                                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                            <span aria-hidden="true">×</span>
                                                        </button>
                                                        <span id="SuccessFailureMessageSpan" runat="server"></span>
                                                    </div>

                                                    <%-- Partner Family Name --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPartnerFamilyName" Text="Name" CssClass="col-form-label"
                                                                AssociatedControlID="txtPartnerFamilyName" />
                                                            <span class="text-danger">*</span>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <asp:TextBox ID="txtPartnerFamilyName" runat="server" CssClass="form-control" CausesValidation="true" />
                                                            <asp:RequiredFieldValidator ID="reqPartnerFamilyName" runat="server" ControlToValidate="txtPartnerFamilyName" ErrorMessage="*" ForeColor="Red"
                                                                CssClass="ValidationClass" ValidationGroup="Validate" Display="Dynamic" />
                                                        </div>
                                                    </div>                                                   
                                                    
                                                    <%-- Partner Drodown --%>
                                                     <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblSelectPartner" Text="Select Partner" CssClass="col-form-label"
                                                                AssociatedControlID="drpPartnerList" />                                                            
                                                        </div>
                                                        <div class="col-md-6">
                                                            <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" CausesValidation="true" />--%>
                                                            <asp:DropDownList ID="drpPartnerList" runat="server" CssClass="form-control" CausesValidation="true"> </asp:DropDownList>
                                                        </div>
                                                    </div> 

                                                    <%-- Relation--%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPartnerFamilyRelation" Text="Relation" CssClass="col-form-label" CausesValidation="true"
                                                                AssociatedControlID="txtPartnerFamilyRelation"></asp:Label>
                                                            <span class="text-danger">*</span>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPartnerFamilyRelation" runat="server" CssClass="form-control" />                                                            
                                                        </div>
                                                    </div>                                                    

                                                    <%-- PassportExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPartnerFamilyPassportExpDate" Text="Passport Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtPartnerFamilyPassportExpDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPartnerFamilyPassportExpDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- InsuranceExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPartnerFamilyInsuranceExpiryDate" Text="Insurance Expiry Date"
                                                                CssClass="col-form-label" AssociatedControlID="txtPartnerFamilyInsuranceExpiryDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPartnerFamilyInsuranceExpiryDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- VisaExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPartnerFamilyVisaExpiryDate" Text="Visa Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtPartnerFamilyVisaExpiryDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPartnerFamilyVisaExpiryDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- Notes --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblNotes" Text="Notes" CssClass="col-form-label"
                                                                AssociatedControlID="txtParterFamilyNotes"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtParterFamilyNotes" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                                        </div>
                                                    </div>

                                                    <%-- Active --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblPatrtnerActive" Text="Active" CssClass="col-form-label"
                                                                AssociatedControlID="chkPartnerFamilyActive"></asp:Label>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:CheckBox ID="chkPartnerFamilyActive" runat="server" Checked="true" />
                                                        </div>
                                                    </div>

                                                    <%-- SAVE Button --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-8 ml-auto">
                                                            <asp:Button CssClass="btn btn-primary" ID="btnParterSave" runat="server" Text="Save" OnClick="btnPartnerFamilySave_Click" />
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
