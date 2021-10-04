<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CMSApplication.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="icon" type="image/png" sizes="16x16" href="images/favicon.png">
    <!-- Custom Stylesheet -->
    <link href="./quixlab/plugins/bootstrap-material-datetimepicker/css/bootstrap-material-datetimepicker.css" rel="stylesheet">
    <!-- Page plugins css -->
    <link href="./quixlab/plugins/clockpicker/dist/jquery-clockpicker.min.css" rel="stylesheet">
    <!-- Color picker plugins css -->
    <link href="./quixlab/plugins/jquery-asColorPicker-master/css/asColorPicker.css" rel="stylesheet">
    <!-- Date picker plugins css -->
    <link href="./quixlab/plugins/bootstrap-datepicker/bootstrap-datepicker.min.css" rel="stylesheet">
    <!-- Daterange picker plugins css -->
    <link href="./quixlab/plugins/timepicker/bootstrap-timepicker.min.css" rel="stylesheet">
    <link href="./quixlab/plugins/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">
    <div class="container-fluid mt-3">
        <div class="card">
            <div class="card-body">
                <%--<h4 class="card-title">Select From Date & To Date to see the alerts </h4>--%>
                <div class="row">
                    <div class="col-md-3">
                        <div class="example">
                            <h5 class="box-title m-t-30">From Date</h5>
                            <div class="input-group">
                                <asp:TextBox TextMode="Date" class="form-control" runat="server" ID="txtFromDate" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="example">
                            <h5 class="box-title m-t-30">To Date</h5>
                            <div class="input-group">
                                <asp:TextBox TextMode="Date" class="form-control" runat="server" ID="txtToDate" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <div class="example">
                            <h5>&nbsp;</h5>
                            <div class="input-group">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn mb-1 btn-primary" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                    <%--<div class="col-md-5">
                        <div class="example">
                            <h5>&nbsp;</h5>
                            <div class="input-group">
                                <asp:FileUpload ID="ExcelFileUpload" runat="server" CssClass="btn mb-1 btn-primary" AllowMultiple="true" />
                                <div style="text-align: right">
                                    <asp:Button ID="btnFileSave" runat="server" Text="Import" CssClass="btn mb-1 btn-primary" OnClick="btnImport_Click" />
                                </div>

                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 col-sm-12">
                <div class="card gradient-0">
                    <div class="card-body" style="height: 400px; overflow: auto">
                        <div style="width: 100%; height: 50px; padding: 12px;" class="gradient-1">
                            <h3 style="color: white;">Company Alert
                                <div class="badge gradient-2 badge-pill gradient-2" style="float: right">
                                    <asp:Label ID="lblCompanyAlertCount" runat="server"></asp:Label>
                                </div>
                            </h3>
                        </div>
                        <asp:Repeater ID="companyAlertRepeater" runat="server">
                            <ItemTemplate>
                                <div class="table-responsive">
                                    <table class="table table-bordered">
                                        <thead>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th class="text-center text-black">
                                                    <a style="color: #7571f9;" href='AddCompanyOperations.aspx?op=edit&id=<%# Eval("PK_COMPANYID") %>' class="">
                                                        <%# Eval("COMP_NAME")%> </a>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="table innerTable">
                                                        <tr>
                                                            <td style="width: 30%">Trade Licence Expiry : </td>
                                                            <td style="width: 20%"><b style="color: #000"><%# Eval("COMP_TRADE_LICENSE_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                            <td style="width: 30%">Immigration Expiry : </td>
                                                            <td style="width: 30%"><b style="color: #000"><%# Eval("COMP_IMMIGRATION_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 30%">Import Code Expiry : </td>
                                                            <td style="width: 20%"><b style="color: #000"><%# Eval("COMP_IMPORT_CODE_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                            <td style="width: 30%">Insurance Expiry : </td>
                                                            <td style="width: 30%"><b style="color: #000"><%# Eval("COMP_INSURANCE_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>

                                <%--<div class="card">
                                    <div class="card-body">
                                        <div class="row align-items-top">
                                            <div class="col-md-4 col-lg-3">
                                                <div class="nav flex-column nav-pills">
                                                    <a href='AddCompanyOperations.aspx?op=edit&id=<%# Eval("PK_COMPANYID") %>' data-toggle="pill" class="nav-link active show"><%# Eval("COMP_NAME")%></a>
                                                </div>
                                            </div>
                                            <div class="col-md-8 col-lg-9">
                                                <div class="tab-content">
                                                    <div id='<%# Eval("PK_COMPANYID") %>' class="tab-pane fade active show">
                                                        <table class="table innerTable">
                                                            <tr>
                                                                <td>Trade Licence Expiry : </td>
                                                                <td><%# Eval("COMP_TRADE_LICENSE_EXP")%></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Immigration Expiry : </td>
                                                                <td><%# Eval("COMP_IMMIGRATION_EXP")%></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Import Code Expiry : </td>
                                                                <td><%# Eval("COMP_IMPORT_CODE_EXP")%></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Insurance Expiry : </td>
                                                                <td><%# Eval("COMP_INSURANCE_EXP")%></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-sm-12">
                <div class="card gradient-0">
                    <div class="card-body" style="height: 400px; overflow: auto">
                        <div style="width: 100%; height: 50px; padding: 12px;" class="gradient-2">
                            <h3 style="color: white;">Employee Alert
                                <div class="badge gradient-1 badge-pill gradient-1" style="float: right">
                                    <asp:Label ID="lblEmployeeAlertCount" runat="server"></asp:Label>
                                </div>
                            </h3>
                        </div>
                        <asp:Repeater ID="employeeAlertRepeater" runat="server">
                            <ItemTemplate>
                                <div class="table-responsive">
                                    <table class="table table-bordered">
                                        <thead>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th class="text-center text-black">
                                                    <a style="color: #7571f9;" href='#' class="">
                                                        <%# Eval("EMP_NAME")%> </a>(<%# Eval("COMP_NAME")%>
                                                )
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="table innerTable">
                                                        <tr>
                                                            <td style="width: 30%">Passport Expiry : </td>
                                                            <td style="width: 20%"><b style="color: #000"><%# Eval("EMP_PASSPORT_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                            <td style="width: 30%">Insurance Expiry : </td>
                                                            <td style="width: 30%"><b style="color: #000"><%# Eval("EMP_INSURANCE_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 30%">Visa Expiry : </td>
                                                            <td style="width: 20%"><b style="color: #000"><%# Eval("EMP_VISA_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                            <td style="width: 30%">labour Card Expiry : </td>
                                                            <td style="width: 30%"><b style="color: #000"><%# Eval("EMP_LABOR_CARD_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-sm-12">
                <div class="card gradient-0">
                    <div class="card-body" style="height: 400px; overflow: auto">
                        <div style="width: 100%; height: 50px; padding: 12px;" class="gradient-3">
                            <h3 style="color: white;">Partner Alert
                                <div class="badge gradient-8 badge-pill gradient-8" style="float: right">
                                    <asp:Label ID="lblPartnerAlertCount" runat="server"></asp:Label>
                                </div>
                            </h3>
                        </div>
                        <asp:Repeater ID="partnerAlertRepeater" runat="server">
                            <ItemTemplate>
                                <div class="table-responsive">
                                    <table class="table table-bordered">
                                        <thead>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th class="text-center text-black">
                                                    <a style="color: #7571f9;" href='#' class=""><%# Eval("PAR_NAME")%> </a>(<%# Eval("COMP_NAME")%>
                                                )
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="table innerTable">
                                                        <tr>
                                                            <td style="width: 30%">Passport Expiry : </td>
                                                            <td style="width: 20%"><b style="color: #000"><%# Eval("PAR_PASSPORT_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%">Insurance Expiry : </td>
                                                            <td style="width: 30%"><b style="color: #000"><%# Eval("PAR_INSURANCE_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 30%">Visa Expiry : </td>
                                                            <td style="width: 20%"><b style="color: #000"><%# Eval("PAR_VISA_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-sm-12">
                <div class="card gradient-0">
                    <div class="card-body" style="height: 400px; overflow: auto">
                        <div style="width: 100%; height: 50px; padding: 12px;" class="gradient-4">
                            <h3 style="color: white;">Partner's Family Alert
                                <div class="badge gradient-5 badge-pill gradient-5" style="float: right">
                                    <asp:Label ID="lblPartnerFamilyAlertCount" runat="server"></asp:Label>
                                </div>
                            </h3>
                        </div>
                        <asp:Repeater ID="partnerFamilyAlertRepeater" runat="server">
                            <ItemTemplate>
                                <div class="table-responsive">
                                    <table class="table table-bordered">
                                        <thead>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th class="text-center text-black">
                                                    <a style="color: #7571f9;" href='#' class=""><%# Eval("FML_NAME")%> </a>(<%# Eval("COMP_NAME")%>
                                                )
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="table innerTable">
                                                        <tr>
                                                            <td style="width: 30%">Passport Expiry : </td>
                                                            <td style="width: 20%"><b style="color: #000"><%# Eval("FML_PASSPORT_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%">Insurance Expiry : </td>
                                                            <td style="width: 30%"><b style="color: #000"><%# Eval("FML_INSURANCE_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 30%">Visa Expiry : </td>
                                                            <td style="width: 20%"><b style="color: #000"><%# Eval("FML_VISA_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-sm-12">
                <div class="card gradient-0">
                    <div class="card-body" style="height: 400px; overflow: auto">
                        <div style="width: 100%; height: 50px; padding: 12px;" class="gradient-8">
                            <h3 style="color: white;">Misc Alert
                                <div class="badge gradient-3 badge-pill gradient-3" style="float: right">
                                    <asp:Label ID="lblMiscAlertCount" runat="server"></asp:Label>
                                </div>
                            </h3>
                        </div>
                        <asp:Repeater ID="miscAlertRepeater" runat="server">
                            <ItemTemplate>
                                <div class="table-responsive">
                                    <table class="table table-bordered">
                                        <thead>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th class="text-center text-black">
                                                    <a style="color: #7571f9;" href='#' class=""><%# Eval("FML_NAME")%> </a>(<%# Eval("COMP_NAME")%>
                                                )
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="table innerTable">
                                                        <tr>
                                                            <td style="width: 30%">Passport Expiry : </td>
                                                            <td style="width: 20%"><b style="color: #000"><%# Eval("FML_PASSPORT_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30%">Insurance Expiry : </td>
                                                            <td style="width: 30%"><b style="color: #000"><%# Eval("FML_INSURANCE_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 30%">Visa Expiry : </td>
                                                            <td style="width: 20%"><b style="color: #000"><%# Eval("FML_VISA_EXP","{0: dd-MMM-yyyy}")%></b></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
