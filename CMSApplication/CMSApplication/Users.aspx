<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="CMSApplication.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: "POST",
                url: "Users.aspx/GetUserDetails",
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
            $("[id*=gvUserDetails]").DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[10, 15, -1], [10, 15, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    data: response.d,
                    columns: [
                        { 'data': 'Name' },                    
                        { 'data': 'Username' },
                        { 'data': 'Mobile_No' },
                        {
                            'data': 'Is_active',
                            'render': function (data, type, row) {
                                return (data == true) ? '<span><img src="https://cdn1.iconfinder.com/data/icons/e-commerce-flat/512/Correct-128.png" height="20px" weidth="20px" </span> '
                                    : ' <img src="https://cdn3.iconfinder.com/data/icons/flat-actions-icons-9/792/Close_Icon-128.png" height="20px" width=20px">';
                            }
                        },
                        {
                            "mRender": function (data, type, row) {
                                return '<a href=UserDetails.aspx?op=edit&userid=' + row.Pk_userid + '><i class="fa fa-edit"></i></a>';
                            }
                        }
                    ]
                });
        };
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

        .UserDetailstable {
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
                                    <div class=""><h3 style="color: #04c;">Users</h3></div>
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
                                        <asp:Button ID="btnAddUser" runat="server" Text="Add User" CssClass="btn btn-primary"
                                            OnClick="btnAddUser_Click" /></div>
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="gvUserDetails" runat="server" CssClass="table table-striped table-bordered zero-configuration
                                UserDetailstable" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name" />                                    
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                    <asp:BoundField DataField="Mobile_No" HeaderText="Mobile_No" />                                    
                                    <asp:BoundField DataField="Is_active" HeaderText="Active" />                                    
                                    <asp:BoundField />                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- #/ container -->

</asp:Content>
