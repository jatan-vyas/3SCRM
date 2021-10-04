<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="CMSApplication.CompanyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: "POST",
                url: "Company.aspx/GetCompanyDetails",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        });
        function OnSuccess(response) {
            $("[id*=gvCompanyDetails]").DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[10, 15, -1], [10, 15, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    data: response.d,
                    columns: [
                        { 'data': 'Comp_name' },
                        { 'data': 'Comp_phone' },
                        { 'data': 'Comp_trade_license_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                        { 'data': 'Comp_immigration_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                        { 'data': 'Comp_import_code_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                        { 'data': 'Comp_insurance_exp', render: function (d) { if (d) { return moment(d).format("DD-MMM-YYYY"); } else { return '' } } },
                        {
                            'data': 'Is_active',
                            'render': function (data, type, row) {
                                return (data == true) ? '<span><img src="https://cdn1.iconfinder.com/data/icons/e-commerce-flat/512/Correct-128.png" height="20px" weidth="20px" </span> '
                                    : ' <img src="https://cdn3.iconfinder.com/data/icons/flat-actions-icons-9/792/Close_Icon-128.png" height="20px" width=20px">';
                            }
                        },
                        {
                            "mRender": function (data, type, row) {
                                return '<a href=CompanyDetails.aspx?op=edit&id=' + row.Pk_companyid + '><i class="fa fa-edit"></i></a>';
                            }
                        },
                        {
                            "mRender": function (data, type, row) {
                                return '<a href="#" onclick="deleteCompany(this)" id=' + row.Pk_companyid + '><i class="fa fa-trash"></i></a>';
                            }
                        }
                    ]
                });
        };

        function deleteCompany(companyID) {            
            $('#deleteModal').modal('show');
            $("#MainContent_hdnCompanyID").val(companyID.attributes['id'].value)
        }
    </script>
    <style>
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

        .current {
            border: 1px solid blue !important;
        }

        .CompanyDetailstable {
            width: 100% !important
        }
    </style>
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="">
                                    <div class="">
                                        <h3 style="color: #04c;">Company</h3>
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
                                        <asp:Button ID="btnAddCompany" runat="server" Text="Add Company" CssClass="btn btn-primary" OnClick="btnAddCompany_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="gvCompanyDetails" runat="server" CssClass="table table-striped table-bordered zero-configuration CompanyDetailstable" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Comp_name" HeaderText="Name" />
                                    <asp:BoundField DataField="Comp_phone" HeaderText="Phone" />
                                    <asp:BoundField DataField="Comp_trade_license_exp" HeaderText="Trade Licence Exp Date" />
                                    <asp:BoundField DataField="Comp_immigration_exp" HeaderText="Immigration Exp Date" />
                                    <asp:BoundField DataField="Comp_import_code_exp" HeaderText="Import Code Exp Date" />
                                    <asp:BoundField DataField="Comp_insurance_exp" HeaderText="Insurance Exp Date" />
                                    <asp:BoundField DataField="Is_active" HeaderText="Active" />
                                    <asp:BoundField />
                                    <asp:BoundField />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="row">
                            <!--Delete modal-->
                            <div class="modal fade" id="deleteModal" tabindex="-1" aria-hidden="true">
                                <div class="modal-dialog modal-dialog-centered mw-650px">
                                    <div class="modal-content rounded">
                                        <div class="modal-body scroll-y px-10 px-lg-15 pt-0 pb-15">                                            
                                                <asp:HiddenField ID="hdnCompanyID" runat="server" />
                                                <div class="mb-13 text-center">
                                                    <h1 class="mb-3" id="deleteHeaderName"></h1>
                                                    <div class="text-muted fw-bold fs-5" id="deleteDescriptionName">
                                                        Are you sure you want to delete this record?
                                                    </div>
                                                </div>
                                            <div> &nbsp;</div>
                                                <div class="text-center">
                                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-light me-3" data-dismiss="modal" Text="Cancel" />
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text="Yes" OnClick="btnDeleteCompany_Click"/>

                                                    <%--<button type="button" data-dismiss="modal" class="btn btn-light me-3">Cancel</button>
                                                    <button type="button" id="deleteRecord" class="btn btn-primary">Yes</button>--%>
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
    <!-- #/ container -->

</asp:Content>
