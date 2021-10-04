<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CMSApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <title>3S Business Service CRM</title>
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="../../assets/images/favicon.png" />
    <!-- <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous"> -->
    <link href="quixlab/css/style.css" rel="stylesheet" />
</head>
<body>

    <!--*******************
        Preloader start
    ********************-->
    <div id="preloader">
        <div class="loader">
            <svg class="circular" viewBox="25 25 50 50">
                <circle class="path" cx="50" cy="50" r="20" fill="none" stroke-width="3" stroke-miterlimit="10" />
            </svg>
        </div>
    </div>
    <!--*******************
        Preloader end
    ********************-->


    <div class="login-form-bg h-100">
        <div class="container h-100">
            <div class="row justify-content-center h-100">
                <div class="col-xl-6">
                    <div class="form-input-content">
                        <div class="card login-form mb-0">
                            <div class="card-body pt-5">
                                <div class="text-center">
                                    <div class="brand-logo" style="background: #fff;">
                                        <a href="#">
                                            <b class="logo-abbr">
                                                <img src="quixlab/images/3sLogo.png" alt="" />
                                            </b>                                            
                                        </a>
                                    </div>
                                </div>

                                <form class="mt-5 mb-5 login-input" id="form1" runat="server">
                                    <div class="form-group">                                                                        
                                        <asp:TextBox ID="txtUserName" CssClass="form-control input-default" placeholder="UserName" runat="server" style="padding-left:5px"/>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorUserName" ControlToValidate="txtUserName" ErrorMessage="*" Style="color: red" />
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:TextBox runat="server" ID="txtPassword" class="form-control input-default" placeholder="Password" TextMode="Password" style="padding-left:5px"/>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorPassword" ControlToValidate="txtPassword" ErrorMessage="*" />

                                    </div>                                    
                                    <asp:Button ID="btnSingIn" runat="server" class="btn login-form__btn submit w-100" Text="Sign In" OnClick="btnSingIn_Click" />
                                </form>
                                <%--<p class="mt-5 login-form__footer">Dont have account? <a href="page-register.html" class="text-primary">Sign Up</a> now</p>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




    <!--**********************************
        Scripts
    ***********************************-->
    <script src="quixlab/plugins/common/common.min.js"></script>
    <script src="quixlab/js/custom.min.js"></script>
    <script src="quixlab/js/settings.js"></script>
    <script src="quixlab/js/gleek.js"></script>
    <script src="quixlab/js/styleSwitcher.js"></script>

</body>
</html>
