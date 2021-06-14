<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tables.aspx.cs" Inherits="PlotArqus.Tables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Arqus 2.0 - Dashboard</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>

    <!-- Page level plugin CSS-->
    <link href="css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet"/>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet"/>
</head>
<body id="page-top">
    <form id="form2" runat="server">
        <nav class="navbar navbar-expand navbar-dark bg-dark static-top">

            <asp:HyperLink ID="dashbord" NavigateUrl="~/Home.aspx" Text="Arqus-Dashbord" CssClass="navbar-brand mr-1" runat="server"></asp:HyperLink>
            <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle">
                <i class="fas fa-bars"></i>
            </button>

            <!-- Navbar Search -->
            <div class="d-none d-md-inline-block form-inline ml-auto mr-0 mr-md-3 my-2 my-md-0">
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2" />
                    <div class="input-group-append">
                        <button class="btn btn-primary" type="button">
                            <i class="fas fa-search"></i>
                        </button>
                    </div>
                </div>
            </div>

            <!-- Navbar -->
            <ul class="navbar-nav ml-auto ml-md-0">
                <li class="nav-item dropdown no-arrow mx-1">
                    <a class="nav-link dropdown-toggle" href="#" id="alertsDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fas fa-bell fa-fw"></i>
                        <span class="badge badge-danger">9+</span>
                    </a>
                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="alertsDropdown">
                        <a class="dropdown-item" href="#">Action</a>
                        <a class="dropdown-item" href="#">Another action</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#">Something else here</a>
                    </div>
                </li>
                <li class="nav-item dropdown no-arrow mx-1">
                    <a class="nav-link dropdown-toggle" href="#" id="messagesDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fas fa-envelope fa-fw"></i>
                        <span class="badge badge-danger">7</span>
                    </a>
                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="messagesDropdown">
                        <a class="dropdown-item" href="#">Action</a>
                        <a class="dropdown-item" href="#">Another action</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#">Something else here</a>
                    </div>
                </li>
                <li class="nav-item dropdown no-arrow">
                    <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="fas fa-user-circle fa-fw"></i>
                    </a>
                    <div class="dropdown-menu dropdown-menu-right" aria-labelledby="userDropdown">
                        <a class="dropdown-item" href="#">Settings</a>
                        <a class="dropdown-item" href="#">Activity Log</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#" data-toggle="modal" data-target="#logoutModal">Logout</a>
                    </div>
                </li>
            </ul>

        </nav>

        <div id="wrapper">

            <!-- Sidebar -->
            <ul class="sidebar navbar-nav">
                <li class="nav-item">
                    <button runat="server" id="btndshbord1" class="nav-link" title="Charts" onserverclick="btndshbord1_ServerClick" style="background-color: black; border: none">
                        <i class="fas fa-fw fa-tachometer-alt"></i>
                        <span>Dashboard</span>
                    </button>
                </li>
                <li class="nav-item">
                    <button runat="server" id="btnCharts1" class="nav-link" title="Charts" onserverclick="btnCharts1_ServerClick" style="background-color: black; border: none">
                        <i class="fas fa-fw fa-chart-area"></i><span>Charts</span>
                    </button>
                </li>

                <li class="nav-item active">
                    <button runat="server" id="btnTables1" class="nav-link" title="Tables" onserverclick="btnTables1_ServerClick" style="background-color: black; border: none">
                        <i class="fas fa-fw fa-table"></i><span>Tables</span>
                    </button>
                </li>
                <li class="nav-item">
                    <button runat="server" id="btnCalcul" class="nav-link" title="Tables" onserverclick="btnCalcul_ServerClick" style="background-color: black; border: none">
                        <i class="fas fa-fw fa-calculator"></i><span>Calculs</span>
                    </button>
                </li>

            </ul>

            <div id="content-wrapper">
                <div class="container-fluid">

                    <!-- Breadcrumbs-->
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="#">Dashboard</a>
                        </li>
                        <li class="breadcrumb-item active">Tables</li>
                    </ol>
                    <br />
                    <h3>Données alphanumériques par station</h3>
                    <div class="container mt-2 mb-2">
                        <div class="row">
                            <div class="col-sm-2">
                                <fieldset class="form-group">
                                    <legend class="control-label">Station</legend>
                                    <div class="input-group mb-3">
                                        <asp:DropDownList ID="ddlStation" runat="server" CssClass="form-control" TabIndex="1">
                                            <asp:ListItem Value="60714">Bizerte</asp:ListItem>
                                            <asp:ListItem Value="60715">Tunis-Carthage</asp:ListItem>
                                            <asp:ListItem Value="60710">Tabarka</asp:ListItem>
                                            <asp:ListItem Value="60720">Kelibia</asp:ListItem>
                                            <asp:ListItem Value="60729">Zaghouane</asp:ListItem>
                                            <asp:ListItem Value="60723">Beja</asp:ListItem>
                                            <asp:ListItem Value="60725">Jendouba</asp:ListItem>
                                            <asp:ListItem Value="60732">El-Kef</asp:ListItem>
                                            <asp:ListItem Value="60734">Siliana</asp:ListItem>
                                            <asp:ListItem Value="60735">Kairouan</asp:ListItem>
                                            <asp:ListItem Value="60731">Enfidha</asp:ListItem>
                                            <asp:ListItem Value="60740">Monastir</asp:ListItem>
                                            <asp:ListItem Value="60742">Mahdia</asp:ListItem>
                                            <asp:ListItem Value="60748">Sidi-Bouzid</asp:ListItem>
                                            <asp:ListItem Value="60750">Sfax</asp:ListItem>
                                            <asp:ListItem Value="60765">Gabes</asp:ListItem>
                                            <asp:ListItem Value="60767">Matmata</asp:ListItem>
                                            <asp:ListItem Value="60770">Mednine</asp:ListItem>
                                            <asp:ListItem Value="60772">Tataouine</asp:ListItem>
                                            <asp:ListItem Value="60775">Remada</asp:ListItem>
                                            <asp:ListItem Value="60780">El-Borma</asp:ListItem>
                                            <asp:ListItem Value="60745">Gafsa</asp:ListItem>
                                            <asp:ListItem Value="60769">Kassrine</asp:ListItem>
                                            <asp:ListItem Value="60717">Borj-El-Amri</asp:ListItem>
                                            <asp:ListItem Value="60738">Thala</asp:ListItem>
                                            <asp:ListItem Value="60760">Tozeur</asp:ListItem>
                                            <asp:ListItem Value="60764">Kebili</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="col-sm-3">
                                <fieldset class="form-group">
                                    <legend class="control-label">Date et Heure début</legend>
                                    <div class="input-group date" id="datetimepicker1" data-target-input="nearest">
                                        <asp:TextBox ID="txtdate1" runat="server" CssClass="form-control datetimepicker-input" data-target="#datetimepicker1"></asp:TextBox>
                                        <div class="input-group-append" data-target="#datetimepicker1" data-toggle="datetimepicker">
                                            <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="col-sm-3">
                                <fieldset class="form-group">
                                    <legend class="control-label">Date et Heure fin</legend>
                                    <div class="input-group date" id="datetimepicker2" data-target-input="nearest">
                                        <asp:TextBox ID="txtdate2" runat="server" CssClass="form-control datetimepicker-input" data-target="#datetimepicker2"></asp:TextBox>
                                        <div class="input-group-append" data-target="#datetimepicker2" data-toggle="datetimepicker">
                                            <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="col-sm-3">
                                <fieldset class="form-group">
                                    <legend class="control-label">Résolution</legend>
                                    <div class="radio radiobuttonlist">
                                        <asp:RadioButtonList ID="rdbResolution" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow" CausesValidation="True">
                                            <asp:ListItem Text="6 minutes" Selected="True" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Horaire" Selected="False" Value="0"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:Button ID="btnBindTable" runat="server" Text="Valider la Requette" OnClick="btnBindTable_Click" CssClass="btn btn-primary btn-block" />
                                </fieldset>

                            </div>
                        </div>
                    </div>
                    <!-- DataTables Example -->
                    <div class="container mt-5 mb-5">
                        <asp:Repeater ID="DataTblRptr" runat="server">
                            <HeaderTemplate>
                                <div class="table-responsive">
                                    <table class="table table-bordered table-hover" id="dataTable" width="100%" cellspacing="0">
                                        <thead class="thead-dark">
                                            <tr>
                                                <th scope="col">Date/Heure</th>
                                                <th scope="col">DD</th>
                                                <th scope="col">FF</th>
                                                <th scope="col">Tair</th>
                                                <th scope="col">HR</th>
                                                <th scope="col">Td</th>
                                                <th scope="col">Pmer</th>
                                                <th scope="col">RR</th>
                                                <th scope="col">Di</th>
                                                <th scope="col">Rg</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"><%# Eval("oDate") %></th>
                                    <td><%# Eval("DD") %></td>
                                    <td><%# Eval("FF") %></td>
                                    <td><%# Eval("Tair") %></td>
                                    <td><%# Eval("HR") %></td>
                                    <td><%# Eval("Td") %></td>
                                    <td><%# Eval("Pmer") %></td>
                                    <td><%# Eval("RR") %></td>
                                    <td><%# Eval("Di") %></td>
                                    <td><%# Eval("Rg") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                </table>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="Ltrexption" runat="server"></asp:Literal>
                    </div>
                    <!-- Sticky Footer -->
                    <footer class="sticky-footer">
                        <div class="container my-auto">
                            <div class="copyright text-center my-auto">
                                <p>Copyright &copy; Aymen Zelaiti 2019-<%: DateTime.Now.Year %></p>
                            </div>
                        </div>
                    </footer>
                </div>

            </div>
        </div>
        
        <!-- Scroll to Top Button-->
        <a class="scroll-to-top rounded" href="#page-top">
            <i class="fas fa-angle-up"></i>
        </a>

        <!-- Logout Modal-->
        <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
                        <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
                    <div class="modal-footer">
                        <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                        <asp:Button ID="btnLogout" Text="Logout" OnClick="btnLogout_Click" runat="server" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Bootstrap core JavaScript-->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- Core plugin JavaScript-->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <!-- Page level plugin JavaScript-->
        <script src="vendor/datatables/jquery.dataTables.js"></script>
        <script src="vendor/datatables/dataTables.bootstrap4.js"></script>
        <script src="Scripts/jquery.dataTables.min.js"></script>
        <!-- Custom scripts for all pages-->
        <script src="js/sb-admin.min.js"></script>

        <!-- Demo scripts for this page-->
        <script src="Scripts/moment.js"></script>
        <script src="js/demo/datatables-demo.js"></script>
        <script src="Scripts/tempusdominus-bootstrap-4.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#dataTable').DataTable();
            });
        </script>
        <script type="text/javascript">
            $(function () {
                $('#datetimepicker1').datetimepicker({
                    format: 'DD/MM/YYYY HH:mm',
                });
            });
        </script>
        <script type="text/javascript">
            $(function () {
                $('#datetimepicker2').datetimepicker({
                    format: 'DD/MM/YYYY HH:mm',
                });
            });
        </script>
    </form>
</body>
</html>
