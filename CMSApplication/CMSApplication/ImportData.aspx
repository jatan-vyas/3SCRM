<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportData.aspx.cs" Inherits="CMSApplication.ImportData" %>

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
                                            <h2 style="text-align: center; color: #04c; padding-bottom: 13px" id="employeePageHeading" runat="server"></h2>
                                            <div class="form-validation">
                                                <div class="form-valide">
                                                    <div class="hideDiv" id="SuccessFailureMessage" runat="server">
                                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                            <span aria-hidden="true">×</span>
                                                        </button>
                                                        <span id="SuccessFailureMessageSpan" runat="server"></span>
                                                    </div>
                                                </div>                                                
                                                <div class="form-group row">
                                                    <div class="col-lg-3">
                                                        <asp:Label runat="server" ID="lblSelectFile" Text="Select files to Import" CssClass="col-form-label" />
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:FileUpload ID="ExcelFileUpload" runat="server" CssClass="btn mb-1 btn-primary" AllowMultiple="true" />
                                                        <div style="float: right">
                                                            <asp:Button ID="btnFileSave" runat="server" Text="Import" CssClass="btn mb-1 btn-primary" OnClick="btnImport_Click" />
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
