<%@ Page Title="Company" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyDetails.aspx.cs" Inherits="CMSApplication.CompanyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .label_header {
            color: #324cdd;
            margin-left: 20px;
            font-size: 16px !important;
        }

        /* Android 2.3 :checked fix #7571f9*/
        @keyframes fake {
            from {
                opacity: 1;
            }

            to {
                opacity: 1;
            }
        }

        body {
            animation: fake 1s infinite;
        }

        .worko-tabs {
            margin: 20px;
            width: 95%;
        }

            .worko-tabs .state {
                position: absolute;
                left: -10000px;
            }

            .worko-tabs .flex-tabs {
                display: flex;
                justify-content: space-between;
                flex-wrap: wrap;
                /*border: 1px solid #7571f9;*/
                /*border-top: none;*/
            }

                .worko-tabs .flex-tabs .tab {
                    flex-grow: 1;
                    max-height: 40px;
                    border-bottom: 1px solid #7571f9;
                    /*border-left:none;*/
                    border-right: none;
                }

                .worko-tabs .flex-tabs .panel {
                    background-color: #fff;
                    padding: 20px;
                    height: auto;
                    display: none;
                    width: 100%;
                    flex-basis: auto;
                    border: 1px solid #7571f9;
                    border-top: none;
                }

            .worko-tabs .tab {
                display: inline-block;
                padding: 10px;
                vertical-align: top;
                background-color: #eee;
                cursor: default;
                cursor: pointer;
                border-left: 10px solid #ccc;
            }

                .worko-tabs .tab:hover {
                    background-color: #fff;
                }

            .worko-tabs label {
                margin-bottom: 0rem;
            }

        #tab-one:checked ~ .tabs #tab-one-label,
        #tab-two:checked ~ .tabs #tab-two-label,
        #tab-three:checked ~ .tabs #tab-three-label,
        #tab-four:checked ~ .tabs #tab-four-label,
        #tab-five:checked ~ .tabs #tab-five-label,
        #tab-six:checked ~ .tabs #tab-six-label {
            background-color: #fff;
            cursor: default;
            border-left-color: #7571f9;
            border-bottom: none;
            border-top: 1px solid #7571f9;
            border-right: 1px solid #7571f9;
        }

        #tab-one:checked ~ .tabs #tab-one-panel,
        #tab-two:checked ~ .tabs #tab-two-panel,
        #tab-three:checked ~ .tabs #tab-three-panel,
        #tab-four:checked ~ .tabs #tab-four-panel,
        #tab-five:checked ~ .tabs #tab-five-panel,
        #tab-six:checked ~ .tabs #tab-six-panel {
            display: block;
        }

        @media (max-width: 600px) {
            .flex-tabs {
                flex-direction: column;
            }

                .flex-tabs .tab {
                    background: #fff;
                    border-bottom: 1px solid #ccc;
                }

                    .flex-tabs .tab:last-of-type {
                        border-bottom: none;
                    }

                .flex-tabs #tab-one-label {
                    order: 1;
                }

                .flex-tabs #tab-two-label {
                    order: 3;
                }

                .flex-tabs #tab-three-label {
                    order: 5;
                }

                .flex-tabs #tab-four-label {
                    order: 7;
                }

                .flex-tabs #tab-five-label {
                    order: 9;
                }

                .flex-tabs #tab-six-label {
                    order: 11;
                }

                .flex-tabs #tab-one-panel {
                    order: 2;
                }

                .flex-tabs #tab-two-panel {
                    order: 4;
                }

                .flex-tabs #tab-three-panel {
                    order: 6;
                }

                .flex-tabs #tab-four-panel {
                    order: 8;
                }

                .flex-tabs #tab-five-panel {
                    order: 10;
                }

                .flex-tabs #tab-six-panel {
                    order: 12;
                }

            #tab-one:checked ~ .tabs #tab-one-label,
            #tab-two:checked ~ .tabs #tab-two-label,
            #tab-three:checked ~ .tabs #tab-three-label,
            #tab-four:checked ~ .tabs #tab-four-label,
            #tab-five:checked ~ .tabs #tab-five-label,
            #tab-six:checked ~ .tabs #tab-six-label {
                border-bottom: none;
            }

            #tab-one:checked ~ .tabs #tab-one-panel,
            #tab-two:checked ~ .tabs #tab-two-panel,
            #tab-three:checked ~ .tabs #tab-three-panel,
            #tab-four:checked ~ .tabs #tab-four-panel,
            #tab-five:checked ~ .tabs #tab-five-panel,
            #tab-six:checked ~ .tabs #tab-six-panel {
                border-bottom: 1px solid #ccc;
            }
        }

        .ValidationClass {
            position: absolute;
            float: right;
            color: red;
        }

        .hideDiv {
            display: none;
        }

        .content-body .container-fluid {
            padding: 0px !important;
        }

        div.dataTables_wrapper div.dataTables_filter input {
            box-shadow: none;
            height: 45px;
            display: block;
            width: 100%;
            height: calc(2.0625rem + 2px);
            padding: 0.375rem 0.75rem;
            font-size: 0.875rem;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
        }

        div.dataTables_wrapper div.dataTables_filter label {
            padding-bottom: 10px;
        }
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="">
                                    <div class="">
                                        <asp:Label runat="server" ID="lblCompName" Text="Company" CssClass="col-form-label label_header" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="worko-tabs">

                            <input class="state" type="radio" title="tab-one" name="tabs-state" id="tab-one" checked  />
                            <input class="state" type="radio" title="tab-two" name="tabs-state" id="tab-two" />
                            <input class="state" type="radio" title="tab-three" name="tabs-state" id="tab-three" />
                            <input class="state" type="radio" title="tab-four" name="tabs-state" id="tab-four" />
                            <input class="state" type="radio" title="tab-five" name="tabs-state" id="tab-five" />

                            <div class="tabs flex-tabs">
                                <label for="tab-one" id="tab-one-label" class="tab">General</label>
                                <label for="tab-two" id="tab-two-label" class="tab" onclick="PartnerTab()">Partner</label>
                                <label for="tab-three" id="tab-three-label" class="tab" onclick="EmployeeTab()">Employee</label>
                                <label for="tab-four" id="tab-four-label" class="tab" onclick="PartnerFamilyTab()">Partner Family</label>
                                <label for="tab-five" id="tab-five-label" class="tab" onclick="MiscTab()">Misc.</label>

                                <%-- Company Tab --%>
                                <div id="tab-one-panel" class="panel ">
                                    <div class="form-validation">
                                        <div class="form-valide">
                                            <%-- <div class="">
                                                <div style="float: right">
                                                    <asp:Button CssClass="btn btn-primary" ID="btnBackToDashboard" runat="server" Text="Back To Dashboard"
                                                        OnClick="btnBackToDashboard_Click" />
                                                </div>
                                            </div>--%>
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
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" />
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
                                                    <asp:Label runat="server" ID="lblCompanyPhone" Text="Phone" CssClass="col-form-label"
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
                                                    <%--<span class="text-danger">*</span>--%>
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
                                                    <%--<span class="text-danger">*</span>--%>
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
                                                    <%--<span class="text-danger">*</span>--%>
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
                                                    <%--<span class="text-danger">*</span>--%>
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
                                                    <%--<span class="text-danger">*</span>--%>
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

                                <%-- Partner Tab --%>
                                <div id="tab-two-panel" class="panel active">
                                    <div class="container-fluid">
                                        <div class="row justify-content-center">
                                            <div class="col-lg-12">
                                                <div class="row">
                                                    <div class="col">
                                                        <div class="">
                                                            <div class="">
                                                                <h3 style="color: #04c;">Partner</h3>
                                                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="">
                                                            <div class="">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="">
                                                            <div style="float: right">
                                                                <asp:Button ID="btnAddPartner" runat="server" Text="Add Partner" CssClass="btn btn-primary"
                                                                    OnClick="btnAddPartner_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvPartnerDetails" runat="server" CssClass="table table-striped table-bordered zero-configuration PartnerDetailstable" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="Par_name" HeaderText="Name" />
                                                            <asp:BoundField DataField="Par_mobile" HeaderText="Phone" />
                                                            <asp:BoundField DataField="Par_passport_exp" HeaderText="Passport Expiry" />
                                                            <asp:BoundField DataField="Par_insurance_exp" HeaderText="Insurance Expiry" />
                                                            <asp:BoundField DataField="Par_visa_exp" HeaderText="Visa Expiry" />
                                                            <asp:BoundField DataField="Is_active" HeaderText="Active" />
                                                            <asp:BoundField />
                                                            <asp:BoundField />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div class="row">
                                                    <!--Delete Partner modal-->
                                                    <div class="modal fade" id="deletePartnerModal" tabindex="-1" aria-hidden="true">
                                                        <div class="modal-dialog modal-dialog-centered mw-650px">
                                                            <div class="modal-content rounded">
                                                                <div class="modal-body scroll-y px-10 px-lg-15 pt-0 pb-15">
                                                                    <asp:HiddenField ID="hdnPartnerID" runat="server" />
                                                                    <div class="mb-13 text-center">
                                                                        <h1 class="mb-3" id="deletePartnerHeaderName"></h1>
                                                                        <div class="text-muted fw-bold fs-5" id="deletePartnerDescriptionName">
                                                                            Are you sure you want to delete this record?
                                                                        </div>
                                                                    </div>
                                                                    <div>&nbsp;</div>
                                                                    <div class="text-center">
                                                                        <asp:Button ID="btnPartnerDelete" runat="server" CssClass="btn btn-light me-3" data-dismiss="modal" Text="Cancel" />
                                                                        <asp:Button ID="btnPartnerCancel" runat="server" CssClass="btn btn-primary" Text="Yes" OnClick="btnDeletePartner_Click" />
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

                                <%-- Employee Tab --%>
                                <div id="tab-three-panel" class="panel">
                                    <div class="container-fluid">
                                        <div class="row justify-content-center">
                                            <div class="col-lg-12">
                                                <div class="row">
                                                    <div class="col">
                                                        <div class="">
                                                            <div class="">
                                                                <h3 style="color: #04c;">Employee</h3>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="">
                                                            <div class="">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="">
                                                            <div style="float: right">
                                                                <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" CssClass="btn btn-primary"
                                                                    OnClick="btnAddEmployee_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvEmployeeDetails" runat="server" CssClass="table table-striped table-bordered zero-configuration EmployeeDetailstable"
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="Emp_name" HeaderText="Name" />
                                                            <asp:BoundField DataField="Emp_mobile" HeaderText="Phone" />
                                                            <asp:BoundField DataField="Emp_passport_exp" HeaderText="Passport Expiry" />
                                                            <asp:BoundField DataField="Emp_insurance_exp" HeaderText="Insurance Expiry" />
                                                            <asp:BoundField DataField="Emp_visa_exp" HeaderText="Visa Expiry" />
                                                            <asp:BoundField DataField="Emp_labor_card_exp" HeaderText="Labor Card Expiry" />
                                                            <asp:BoundField DataField="Is_active" HeaderText="Active" />
                                                            <asp:BoundField />
                                                            <asp:BoundField />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div class="row">
                                                    <!--Delete Employee modal-->
                                                    <div class="modal fade" id="deleteEmployeeModal" tabindex="-1" aria-hidden="true">
                                                        <div class="modal-dialog modal-dialog-centered mw-650px">
                                                            <div class="modal-content rounded">
                                                                <div class="modal-body scroll-y px-10 px-lg-15 pt-0 pb-15">
                                                                    <asp:HiddenField ID="hdnEmployeeID" runat="server" />
                                                                    <div class="mb-13 text-center">
                                                                        <h1 class="mb-3" id="deleteHeaderName"></h1>
                                                                        <div class="text-muted fw-bold fs-5" id="deleteDescriptionName">
                                                                            Are you sure you want to delete this record?
                                                                        </div>
                                                                    </div>
                                                                    <div>&nbsp;</div>
                                                                    <div class="text-center">
                                                                        <asp:Button ID="btnEmployeeCancel" runat="server" CssClass="btn btn-light me-3" data-dismiss="modal" Text="Cancel" />
                                                                        <asp:Button ID="btnEmployeeDelete" runat="server" CssClass="btn btn-primary" Text="Yes" OnClick="btnDeleteEmployee_Click" />
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

                                <%-- Partner Family --%>
                                <div id="tab-four-panel" class="panel">
                                    <div class="container-fluid">
                                        <div class="row justify-content-center">
                                            <div class="col-lg-12">

                                                <div class="row">
                                                    <div class="col">
                                                        <div class="">
                                                            <div class="">
                                                                <h3 style="color: #04c;">Partner Family</h3>
                                                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="">
                                                            <div class="">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="">
                                                            <div style="float: right">
                                                                <asp:Button ID="btnAddPartnerFamily" runat="server" Text="Add Partner Family" CssClass="btn btn-primary"
                                                                    OnClick="btnAddPartnerFamily_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvPartnerFamilyDetails" runat="server" CssClass="table table-striped table-bordered zero-configuration PartnerFamilyDetailstable" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="Fml_name" HeaderText="Name" />
                                                            <asp:BoundField DataField="Par_name" HeaderText="Partner Name" />
                                                            <asp:BoundField DataField="Par_mobile" HeaderText="Partner Phone" />
                                                            <asp:BoundField DataField="Fml_relation" HeaderText="Relation" />
                                                            <asp:BoundField DataField="Fml_passport_exp" HeaderText="Passport Expiry" />
                                                            <asp:BoundField DataField="Fml_insurance_exp" HeaderText="Insurance Expiry" />
                                                            <asp:BoundField DataField="Fml_visa_exp" HeaderText="Visa Expiry" />
                                                            <asp:BoundField DataField="Is_active" HeaderText="Active" />
                                                            <asp:BoundField />
                                                            <asp:BoundField />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div class="row">
                                                    <!--Delete Partner Family modal-->
                                                    <div class="modal fade" id="deleteFamilyModal" tabindex="-1" aria-hidden="true">
                                                        <div class="modal-dialog modal-dialog-centered mw-650px">
                                                            <div class="modal-content rounded">
                                                                <div class="modal-body scroll-y px-10 px-lg-15 pt-0 pb-15">
                                                                    <asp:HiddenField ID="hdnPartnerFamilyID" runat="server" />
                                                                    <div class="mb-13 text-center">
                                                                        <h1 class="mb-3" id="deleteFamilyHeaderName"></h1>
                                                                        <div class="text-muted fw-bold fs-5" id="deleteFamilyDescriptionName">
                                                                            Are you sure you want to delete this record?
                                                                        </div>
                                                                    </div>
                                                                    <div>&nbsp;</div>
                                                                    <div class="text-center">
                                                                        <asp:Button ID="btnPartnerFamilyCancel" runat="server" CssClass="btn btn-light me-3" data-dismiss="modal" Text="Cancel" />
                                                                        <asp:Button ID="btnPartnerFamilyDelete" runat="server" CssClass="btn btn-primary" Text="Yes" OnClick="btnDeleteFamily_Click" />
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

                                <%-- Misc --%>
                                <div id="tab-five-panel" class="panel">
                                    <div class="container-fluid">
                                        <div class="row justify-content-center">
                                            <div class="col-lg-12">
                                                <div class="row">
                                                    <div class="col">
                                                        <div class="">
                                                            <div class="">
                                                                <h3 style="color: #04c;">Misc</h3>
                                                                <asp:HiddenField ID="hdnMiscID" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="">
                                                            <div class="">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="">
                                                            <div style="float: right">
                                                                <asp:Button ID="btnAddMisc" runat="server" Text="Add Misc" CssClass="btn btn-primary"
                                                                    OnClick="btnAddPartnerMisc_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvMiscDetails" runat="server" CssClass="table table-striped table-bordered zero-configuration MiscDetailstable" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="Misc_name" HeaderText="Name" />
                                                            <asp:BoundField DataField="Misc_exp_date" HeaderText="Expiry" />
                                                            <asp:BoundField DataField="Is_active" HeaderText="Active" />
                                                            <asp:BoundField />
                                                            <asp:BoundField />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div class="row">
                                                    <!--Delete Misc modal-->
                                                    <div class="modal fade" id="deleteMiscModal" tabindex="-1" aria-hidden="true">
                                                        <div class="modal-dialog modal-dialog-centered mw-650px">
                                                            <div class="modal-content rounded">
                                                                <div class="modal-body scroll-y px-10 px-lg-15 pt-0 pb-15">
                                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                    <div class="mb-13 text-center">
                                                                        <h1 class="mb-3" id="deleteMiscHeaderName"></h1>
                                                                        <div class="text-muted fw-bold fs-5" id="deleteFamilyMiscName">
                                                                            Are you sure you want to delete this record?
                                                                        </div>
                                                                    </div>
                                                                    <div>&nbsp;</div>
                                                                    <div class="text-center">
                                                                        <asp:Button ID="btnDeleteMiscCancel" runat="server" CssClass="btn btn-light me-3" data-dismiss="modal" Text="Cancel" />
                                                                        <asp:Button ID="btnDeleteMiscDelete" runat="server" CssClass="btn btn-primary" Text="Yes" OnClick="btnDeleteMisc_Click" />
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
            </div>
        </div>
    </div>

</asp:Content>
