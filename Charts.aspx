<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Charts.aspx.cs" Inherits="PlotArqus.Charts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Arqus 2.0 - Dashboard</title>
    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />

    <!-- Page level plugin CSS-->
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet" />
</head>
<body id="page-top">
    <form id="form3" runat="server">

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
                    <button runat="server" id="btndashbord2" class="nav-link" title="Charts" onserverclick="btndashbord2_ServerClick" style="background-color: black; border: none">
                        <i class="fas fa-fw fa-tachometer-alt"></i>
                        <span>Dashboard</span>
                    </button>
                </li>
                <li class="nav-item active">
                    <button runat="server" id="btnCharts2" class="nav-link" title="Charts" onserverclick="btnCharts2_ServerClick" style="background-color: black; border: none">
                        <i class="fas fa-fw fa-chart-area"></i><span>Charts</span>
                    </button>
                </li>

                <li class="nav-item">
                    <button runat="server" id="btnTables2" class="nav-link" title="Tables" onserverclick="btnTables2_ServerClick" style="background-color: black; border: none">
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
                        <li class="breadcrumb-item active">Charts</li>
                    </ol>
                    <br />
                    <h3>Données graphiques par station</h3>

                    <div class="container mt-2 mb-2">
                        <div class="row">
                            <div class="col-sm-2">
                                <fieldset class="form-group">
                                    <legend class="control-label">Station</legend>
                                    <select id="ddlstation" class="form-control">
                                        <option value="60714">Bizerte</option>
                                        <option value="60715">Tunis-Carthage</option>
                                        <option value="60710">Tabarka</option>
                                        <option value="60720">Kelibia</option>
                                        <option value="60729">Zaghouane</option>
                                        <option value="60723">Beja</option>
                                        <option value="60725">Jendouba</option>
                                        <option value="60732">El-Kef</option>
                                        <option value="60734">Siliana</option>
                                        <option value="60735">Kairouan</option>
                                        <option value="60731">Enfidha</option>
                                        <option value="60740">Monastir</option>
                                        <option value="60742">Mahdia</option>
                                        <option value="60748">Sidi-Bouzid</option>
                                        <option value="60750">Sfax</option>
                                        <option value="60765">Gabes</option>
                                        <option value="60767">Matmata</option>
                                        <option value="60770">Mednine</option>
                                        <option value="60772">Tataouine</option>
                                        <option value="60775">Remada</option>
                                        <option value="60780">El-Borma</option>
                                        <option value="60745">Gafsa</option>
                                        <option value="60769">Kassrine</option>
                                        <option value="60717">Borj-El-Amri</option>
                                        <option value="60738">Thala</option>
                                        <option value="60760">Tozeur</option>
                                        <option value="60764">Kebili</option>

                                    </select>
                                </fieldset>
                            </div>
                            <div class="col-sm-2">
                                <fieldset class="form-group">
                                    <legend class="control-label">Paramètre</legend>
                                    <select id="ddlparam" class="form-control">
                                        <option value="Tair">Température</option>
                                        <option value="Td">point de rosée</option>
                                        <option value="HR">Humidité</option>
                                        <option value="FF">FF Vent</option>
                                        <option value="DD">DD Vent</option>
                                        <option value="Pmer">Pression Mer</option>
                                        <option value="RR">Pluie</option>
                                        <option value="Di">Insolation</option>
                                        <option value="Rg">Ray. Global</option>

                                    </select>
                                </fieldset>
                            </div>

                            <div class="col-sm-3">
                                <fieldset class="form-group">
                                    <legend class="control-label">Date et Heure début</legend>
                                    <div class="input-group date" id="datetimepicker3" data-target-input="nearest">
                                        <input id="txtstartdate" type="text" class="form-control datetimepicker-input" data-target="#datetimepicker3" />
                                        <div class="input-group-append" data-target="#datetimepicker3" data-toggle="datetimepicker">
                                            <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>

                            <div class="col-sm-3">
                                <fieldset class="form-group">
                                    <legend class="control-label">Date et Heure fin</legend>
                                    <div class="input-group date" id="datetimepicker4" data-target-input="nearest">
                                        <input id="txtenddate" type="text" class="form-control datetimepicker-input" data-target="#datetimepicker4" />
                                        <div class="input-group-append" data-target="#datetimepicker4" data-toggle="datetimepicker">
                                            <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="col-sm-2">
                                <fieldset class="form-group">
                                    <legend class="control-label">Résolution</legend>
                                    <div class="form-check">
                                        <input class="form-check-input" type="radio" name="gridRadios" id="rdb6min" value="0" checked="checked" />
                                        <label class="form-check-label" for="gridRadios1">
                                            6 minutes
                                        </label>
                                    </div>
                                    <div class="form-check">
                                        <input class="form-check-input" type="radio" name="gridRadios" id="rdbhourly" value="1" />
                                        <label class="form-check-label" for="gridRadios1">
                                            Horaire
                                        </label>
                                    </div>
                                </fieldset>
                                <br />
                                <button id="btnBindChart" type="button" class="btn btn-primary btn-lg btn-block">Valider</button>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="container-fluid mt-1 mb-2">
                            <canvas id="MyChart" width="900" height="400"></canvas>

                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <label id="lblupdated"> </label>
                    </div>
                    <br />
                    <!-- Sticky Footer -->
                    <div class="row">

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
            <!-- /.content-wrapper -->

        </div>
        <!-- /#wrapper -->

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
                        <asp:Button ID="btnLogout" Text="Logout" Onclick="btnLogout_Click" runat="server" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>

        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- Core plugin JavaScript-->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
        <!-- Custom scripts for all pages-->
        <script src="js/sb-admin.min.js"></script>
        <!-- Demo scripts for this page-->
        <script src="Scripts/moment.js"></script>
        <script src="Scripts/tempusdominus-bootstrap-4.min.js"></script>
        <script src="vendor/chart.js/Chart.min.js"></script>
        <!-- Demo scripts for this page-->
        <script type="text/javascript">
            $(function () {
                $('#datetimepicker3').datetimepicker({
                    format: 'DD/MM/YYYY HH:mm',
                });
            });
        </script>
        <script type="text/javascript">
            $(function () {
                $('#datetimepicker4').datetimepicker({
                    format: 'DD/MM/YYYY HH:mm',
                });
            });
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#btnBindChart").on('click', function () {
                    //ajax
                    $('#MyChart').replaceWith($('<canvas id="MyChart" width="100%" height="40"></canvas>'));
                    var station = $("#ddlstation").val();
                    var start = $("#txtstartdate").val();
                    var stop = $("#txtenddate").val();
                    var param = $("#ddlparam").val();
                    var resolution;
                    var chart_type;
                    var xoptions;
                    if (document.getElementById('rdb6min').checked) {
                        resolution = document.getElementById('rdb6min').value;
                    }
                    else if (document.getElementById('rdbhourly').checked) {
                        resolution = document.getElementById('rdbhourly').value;
                    }
                    if (param === 'RR' || param === 'Rg' || param === 'Di') {
                        chart_type = 'bar'                      
                    } else { chart_type = 'line'}                     
                   
                    var jsonData = JSON.stringify({
                        name: station,
                        aParam: param,
                        aStart: start,
                        aStop: stop,
                        aresolution: resolution,
                    });
                    
                    $.ajax({
                        type: "POST",
                        url: "Charts.aspx/BindChart",
                        data: jsonData,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: OnSuccess,
                        failure: function () {
                            alert("Un erreur est survenus, essayez ulterieurement !");
                        }
                    });
                    function OnSuccess(response) {
                        var jsondata = JSON.parse(response.d);
                        var aData = jsondata.parameter;
                        var alabels = jsondata.time;
                        var times = [];
                        for (var i = 0; i < alabels.length; i++) {
                            times.push(moment(alabels[i], 'DD-MM-YYYY HH:mm:ss'));
                        }
                        var ctx = document.getElementById("MyChart");
                        var myLineChart = new Chart(ctx, {
                            type: chart_type,
                            data: {
                                labels: times,
                                datasets: [{
                                    label: param,
                                    lineTension: 0,
                                    backgroundColor: "rgba(2,117,216,0.2)",
                                    borderColor: "rgba(2,117,216,1)",
                                    pointRadius: 1,
                                    pointBackgroundColor: "rgba(2,117,216,1)",
                                    pointBorderColor: "rgba(2,117,216,1)",
                                    pointHoverRadius: 1,
                                    pointHoverBackgroundColor: "rgba(2,117,216,1)",
                                    pointHitRadius: 50,
                                    pointBorderWidth: 0.1,
                                    data: aData,
                                }, ],
                            },
                            options: {
                                scales: {
                                    xAxes: [{
                                        type: 'time',
                                        time: {
                                            tooltipFormat: 'YYYY/MM/DD HH:mm',
                                            displayFormats: {
                                                'millisecond': 'HH:mm',
                                                'second': 'HH:mm',
                                                'minute': 'HH:mm',
                                                'hour': 'HH:mm',
                                                'day': 'HH:mm',
                                                'week': 'HH:mm',
                                                'month': 'HH:mm',
                                                'quarter': 'HH:mm',
                                                'year': 'HH:mm',
                                            }
                                        },
                                        gridLines: {
                                            display: false
                                        },
                                        ticks: {
                                            display: true,
                                        }
                                    }],
                                    yAxes: [{
                                        ticks: {
                                            min: Math.min.apply(this, aData),
                                            max: Math.max.apply(this, aData),
                                            maxTicksLimit: 5
                                        },
                                        gridLines: {
                                            color: "rgba(0, 0, 0, .125)",
                                        }
                                    }],
                                },
                                legend: {
                                    display: true
                                }
                            }
                        });
                                                
                    }
                    //***
                    var legend = '  Station: ' + station + ' | Paramètre: ' + param + ' | du: ' + start + ' au ' + stop + '.';
                    document.getElementById('lblupdated').innerHTML = legend;
                    

                })
                
            })

        </script>


    </form>
</body>
</html>
