<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="CMSApplication.EmployeeDetails" %>
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
                                            <h2 style="text-align: center; color: #04c;padding-bottom:13px" id="employeePageHeading" runat="server"></h2>
                                            <div class="form-validation">
                                                <div class="form-valide">
                                                    <div class="hideDiv" id="SuccessFailureMessage" runat="server">
                                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                            <span aria-hidden="true">×</span>
                                                        </button>
                                                        <span id="SuccessFailureMessageSpan" runat="server"></span>                                                        
                                                    </div>
                                                    <%-- Employee Name --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblEmployeeName" Text="Employee Name" CssClass="col-form-label"
                                                                AssociatedControlID="txtEmployeeName" />
                                                            <span class="text-danger">*</span>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" CausesValidation="true" />
                                                            <asp:RequiredFieldValidator ID="reqEmployeeName" runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="*" ForeColor="Red"
                                                                CssClass="ValidationClass" ValidationGroup="Validate" Display="Dynamic" />
                                                        </div>
                                                    </div>                                                   
                                                    

                                                    <%-- Phone--%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblEmployeePhone" Text="Phone" CssClass="col-form-label" CausesValidation="true"
                                                                AssociatedControlID="txtEmployeePhone"></asp:Label>
                                                            <span class="text-danger">*</span>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtEmployeePhone" runat="server" CssClass="form-control" />
                                                            <%-- RequiredFieldValidator --%>
                                                            <asp:RequiredFieldValidator ID="reqEmployeePhone" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtEmployeePhone" ValidationGroup="Validate" CssClass="ValidationClass" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>

                                                            <%-- Regular Expression Validator --%>
                                                            <asp:RegularExpressionValidator ID="regEmployeePhone" runat="server" ErrorMessage="Invalid Mobile Number."
                                                                ValidationExpression="^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$" ControlToValidate="txtEmployeePhone"
                                                                ValidationGroup="Validate" CssClass="ValidationClass" Display="Dynamic">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>                                                    

                                                    <%-- PassportExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblEmployeePassportExpDate" Text="Passport Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtEmployeePassportExpDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtEmployeePassportExpDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- InsuranceExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblEmployeeInsuranceExpiryDate" Text="Insurance Expiry Date"
                                                                CssClass="col-form-label" AssociatedControlID="txtEmployeeInsuranceExpiryDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtEmployeeInsuranceExpiryDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- VisaExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblEmployeeVisaExpiryDate" Text="Visa Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtEmployeeVisaExpiryDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtEmployeeVisaExpiryDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>

                                                    <%-- LaborCardExpiryDate --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblEmployeeLaborCardExpDate" Text="Labor Card Expiry Date" CssClass="col-form-label"
                                                                AssociatedControlID="txtEmployeeLaborCardExpDate"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtEmployeeLaborCardExpDate" runat="server" CssClass="form-control" TextMode="Date" />
                                                        </div>
                                                    </div>                                                   

                                                    <%-- Notes --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblNotes" Text="Notes" CssClass="col-form-label"
                                                                AssociatedControlID="txtEmployeeNotes"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtEmployeeNotes" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                                        </div>
                                                    </div>

                                                    <%-- Active --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-3">
                                                            <asp:Label runat="server" ID="lblEmployeeActive" Text="Active" CssClass="col-form-label"
                                                                AssociatedControlID="chkEmployeeActive"></asp:Label>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <asp:CheckBox ID="chkemployeeActive" runat="server" Checked="true" />
                                                        </div>
                                                    </div>

                                                    <%-- SAVE Button --%>
                                                    <div class="form-group row">
                                                        <div class="col-lg-8 ml-auto">
                                                            <asp:Button CssClass="btn btn-primary" ID="btnEmployeeSave" runat="server" Text="Save" OnClick="btnEmployeeSave_Click" />
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
