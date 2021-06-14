<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PlotArqus.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>ARQUS | Registration</title>
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="css/sb-admin.css" rel="stylesheet" />
</head>
<body class="bg-dark">
    <form id="formRestration" runat="server">
       <div class="container">
    <div class="card card-register mx-auto mt-5">
      <div class="card-header">Créer un compte</div>
      <div class="card-body">
        
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                  <div class="form-label-group">
                      <asp:TextBox ID="txtfirstName" runat="server" class="form-control" placeholder="First name" required="required" autofocus="autofocus" MaxLength="30"></asp:TextBox>
                      <label for="txtfirstName">First name</label>
                  </div>
              </div>
              <div class="col-md-6">
                  <div class="form-label-group">
                      <asp:TextBox ID="txtlastName" runat="server" class="form-control" placeholder="Last name" required="required" MaxLength="30"></asp:TextBox>
                      <label for="txtlastName">Last name</label>
                  </div>
              </div>
            </div>
          </div>
          <div class="form-group mt-2 mb-2">
              <div class="form-row">
                  <div class="col-md-6">
                      <div class="form-label-group">
                          <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="User Name" required="required" autofocus="autofocus" MaxLength="30"></asp:TextBox>
                          <label for="txtUserName">User Name</label>
                      </div>
                  </div>
              </div>
          </div>
          
          <div class="form-group">
              <div class="form-row">
                  <div class="col-md-6">
                      <div class="form-label-group">
                          <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" MaxLength="20"></asp:TextBox>
                          <label for="txtPassword">Password</label>
                      </div>
                  </div>
                  <div class="col-md-6">
                      <div class="form-label-group">
                          <asp:TextBox ID="txtConfirmPssWrd" runat="server" CssClass="form-control" placeholder="Confirm password" TextMode="Password" MaxLength="20"></asp:TextBox>
                          <label for="txtConfirmPssWrd">Confirm password</label>
                      </div>
                      
                  </div>
              </div>
          </div>
          
          <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary btn-block" OnClick="btnRegister_Click" />
          <div class="text-center">
              <asp:HyperLink ID="HyperLink_loginPage" NavigateUrl="~/Login.aspx" runat="server" CssClass="d-block small mt-3">Login Page</asp:HyperLink>
              <a class="d-block small" href="forgot-password.html">Forgot Password?</a>
          </div>
      </div>
    </div>
  </div>

  <!-- Bootstrap core JavaScript-->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    </form>
</body>
</html>
