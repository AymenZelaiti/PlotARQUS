<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PlotArqus.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>ARQUS - Login</title>
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="css/sb-admin.css" rel="stylesheet" />
</head>
<body class="bg-dark">
    <form id="formLogin" runat="server">
        <div class="container">
            <div class="card card-login mx-auto mt-5">
                <div class="card-header">Login</div>
                <div class="card-body">

                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="txtuser" CssClass="form-control" placeholder="User Name" runat="server"></asp:TextBox>
                            <label for="txtuser">User Name</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="txtpassword" CssClass="form-control" palceholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                            <label for="txtpassword">Password</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" value="remember-me" />
                                Remember Password
             
                            </label>
                        </div>
                    </div>
                    <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-block" Text="Login" runat="server" OnClick="btnLogin_Click" />

                    <div class="text-center">
                        <asp:HyperLink ID="HyperLink_Register" runat="server" NavigateUrl="~/Register.aspx" CssClass="d-block small mt-3">Register an Account</asp:HyperLink>
                        <a class="d-block small" href="forgot-password.html">Forgot Password?</a>
                    </div>
                </div>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:userconnectionstring %>" SelectCommand="SELECT * FROM [UserLog]"></asp:SqlDataSource>
        </div>
        <!-- Bootstrap core JavaScript-->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Core plugin JavaScript-->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    </form>
</body>
</html>
