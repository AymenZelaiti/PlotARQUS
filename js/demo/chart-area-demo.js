// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';
// a preciser les noms des fonctions JS respectivement pour chaque diagramme
//************************ AYMEN ZELAITI ************************************
function Gettemperature(stationID) {
    $('#TempChart').replaceWith($('<canvas id="TempChart" width="100%" height="40"> </canvas>'));
    $('#RainChart').replaceWith($('<canvas id="RainChart" width="100%" height="40"> </canvas>'));
    $('#HrChart').replaceWith($('<canvas id="HrChart" width="100%" height="40"> </canvas>'));
    $('#FFChart').replaceWith($('<canvas id="FFChart" width="100%" height="40"> </canvas>'));
    $('#DDChart').replaceWith($('<canvas id="DDChart" width="100%" height="40"> </canvas>'));
    $('#PmerChart').replaceWith($('<canvas id="PmerChart" width="100%" height="40"> </canvas>'));
    $('#DiChart').replaceWith($('<canvas id="DiChart" width="100%" height="40"> </canvas>'));
    $('#RgChart').replaceWith($('<canvas id="RgChart" width="100%" height="40"> </canvas>'));
    var station = stationID;
  
    $.ajax({
        type: "POST",
        url: "Home.aspx/GetChartData",
        data: "{'name': '" + station + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function () {
            alert("Un probleme de chargement est survenu!");
        }
    });
    //To change this for sever DateTime label
    var date = new Date();
    var toDay = date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear()
    var hours = (date.getHours() < 10 ? '0' : '') +
        date.getHours();
    var minutes = (date.getMinutes() < 10 ? '0' : '') +
        date.getMinutes();
    var TimeStamp = toDay + " " + hours + ":" + minutes + "  | Station " + station;
    document.getElementById('updatedAt').innerHTML = TimeStamp;
    document.getElementById('updatedAt1').innerHTML = TimeStamp;
    document.getElementById('updatedAt2').innerHTML = TimeStamp;
    document.getElementById('updatedAt3').innerHTML = TimeStamp;
    document.getElementById('updatedAt4').innerHTML = TimeStamp;
    document.getElementById('updatedAt5').innerHTML = TimeStamp;
    document.getElementById('updatedAt6').innerHTML = TimeStamp;
    document.getElementById('updatedAt7').innerHTML = TimeStamp;
}
function OnSuccess(response) {
    
    var jsondata = JSON.parse(response.d);
    var atemp = jsondata.temperature;
    var alabels = jsondata.time;
    var pluie = jsondata.RR
    var aTd = jsondata.Td;
    var aHR = jsondata.HR;
    var aFF = jsondata.FF;
    var aDD = jsondata.DD;
    var aPmer = jsondata.Pmer;
    var aDi = jsondata.Di;
    var aRg = jsondata.Rg;

    var times = [];
    for (var i = 0; i < alabels.length; i++) {
        times.push(moment(alabels[i], 'DD-MM-YYYY HH:mm:ss'));
    }
    
    var ctx = document.getElementById("TempChart");
    var myLineChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: times,
            datasets: [{
                label: "T air",
                lineTension: 0.3,
                backgroundColor: "rgba(2,117,216,0.2)",
                borderColor: "rgba(2,117,216,1)",
                pointRadius: 1,
                pointBackgroundColor: "rgba(2,117,216,1)",
                pointBorderColor: "rgba(2,117,216,1)",
                pointHoverRadius: 1,
                pointHoverBackgroundColor: "rgba(2,117,216,1)",
                pointHitRadius: 50,
                pointBorderWidth: 0.1,
                data: atemp,
            },
            {
                label: "Td",
                lineTension: 0.3,
                backgroundColor: "rgba(2, 217, 192,0.2)",
                borderColor: "rgba(2, 217, 192, 1)",
                pointRadius: 1,
                pointBackgroundColor: "rgba(2, 217, 192, 1)",
                pointBorderColor: "rgba(2, 217, 192, 1)",
                pointHoverRadius: 1,
                pointHoverBackgroundColor: "rgba(2, 217, 192, 1)",
                pointHitRadius: 50,
                pointBorderWidth: 0.1,
                data: aTd,

            }],
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
                        min: Math.min.apply(this, aTd),
                        max: Math.max.apply(this, atemp),
                        maxTicksLimit: 5
                    },
                    gridLines: {
                        color: "rgba(0, 0, 0, .125)",
                    }
                }],
            },
            legend: {
                display: true
            },
            reponsive : false,
        }
                
    });
    var ctx2 = document.getElementById("RainChart");
    var BarChart = new Chart(ctx2, {
        type: 'bar',
        data: {
            labels: times,
            datasets: [{
                label: "Pluie",
                backgroundColor: "rgba(2,117,216,1)",
                borderColor: "rgba(2,117,216,1)",
                data: pluie,
            }],
        },
        options: {
            scales: {
                xAxes: [{
                    categoryPercentage: 1.0,
                    barPercentage: 1.0,
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
                        maxTicksLimit: 6
                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: Math.max.apply(this, pluie) + 1,
                        maxTicksLimit: 5
                    },
                    gridLines: {
                        display: true
                    }
                }],
            },
            legend: {
                display: false
            }
        }
    });
    //chartHR

    var ctx3 = document.getElementById("HrChart");
    var myLineChart = new Chart(ctx3, {
        type: 'line',
        data: {
            labels: times,
            datasets: [{
                label: "U %",
                lineTension: 0.3,
                backgroundColor: "rgba(2,117,216,0.2)",
                borderColor: "rgba(2,117,216,1)",
                pointRadius: 1,
                pointBackgroundColor: "rgba(2,117,216,1)",
                pointBorderColor: "rgba(2,117,216,1)",
                pointHoverRadius: 1,
                pointHoverBackgroundColor: "rgba(2,117,216,1)",
                pointHitRadius: 50,
                pointBorderWidth: 0.1,
                data: aHR,
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
                        min: 0,
                        max: Math.max.apply(this, aHR),
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
    //chart FF line
    var ctx4 = document.getElementById("FFChart");
    var myLineChart = new Chart(ctx4, {
        type: 'line',
        data: {
            labels: times,
            datasets: [{
                label: "FF m/s",
                lineTension: 0.3,
                backgroundColor: "rgba(2,117,216,0.2)",
                borderColor: "rgba(2,117,216,1)",
                pointRadius: 1,
                pointBackgroundColor: "rgba(2,117,216,1)",
                pointBorderColor: "rgba(2,117,216,1)",
                pointHoverRadius: 1,
                pointHoverBackgroundColor: "rgba(2,117,216,1)",
                pointHitRadius: 50,
                pointBorderWidth: 0.1,
                data: aFF,
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
                        min: 0,
                        max: Math.max.apply(this, aFF),
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
    //DD chart line
    var ctx5 = document.getElementById("DDChart");
    var myLineChart = new Chart(ctx5, {
        type: 'line',
        data: {
            labels: times,
            datasets: [{
                label: "DD",
                lineTension: 0.3,
                backgroundColor: "rgba(2,117,216,0.2)",
                borderColor: "rgba(2,117,216,1)",
                pointRadius: 1,
                pointBackgroundColor: "rgba(2,117,216,1)",
                pointBorderColor: "rgba(2,117,216,1)",
                pointHoverRadius: 1,
                pointHoverBackgroundColor: "rgba(2,117,216,1)",
                pointHitRadius: 50,
                pointBorderWidth: 0.1,
                data: aDD,
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
                        min: 0,
                        max: Math.max.apply(this, aDD),
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
    //Pmer line
    var ctx6 = document.getElementById("PmerChart");
    var myLineChart = new Chart(ctx6, {
        type: 'line',
        data: {
            labels: times,
            datasets: [{
                label: "Pmer Hpa",
                lineTension: 0.3,
                backgroundColor: "rgba(2,117,216,0.2)",
                borderColor: "rgba(2,117,216,1)",
                pointRadius: 1,
                pointBackgroundColor: "rgba(2,117,216,1)",
                pointBorderColor: "rgba(2,117,216,1)",
                pointHoverRadius: 1,
                pointHoverBackgroundColor: "rgba(2,117,216,1)",
                pointHitRadius: 50,
                pointBorderWidth: 0.1,
                data: aPmer,
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
                        min: Math.min.apply(this, aPmer),
                        max: Math.max.apply(this, aPmer),
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
    //Di chart bar
    var ctx7 = document.getElementById("DiChart");
    var BarChart = new Chart(ctx7, {
        type: 'bar',
        data: {
            labels: times,
            datasets: [{
                label: "Dur. Insolation sec/6mn",
                backgroundColor: "rgba(2,117,216,1)",
                borderColor: "rgba(2,117,216,1)",
                data: aDi,
            }],
        },
        options: {
            scales: {
                xAxes: [{
                    categoryPercentage: 1.0,
                    barPercentage: 1.0,
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
                        maxTicksLimit: 6
                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: Math.max.apply(this, aDi),
                        maxTicksLimit: 5
                    },
                    gridLines: {
                        display: true
                    }
                }],
            },
            legend: {
                display: false
            }
        }
    });
    //Rg chart bar
    var ctx8 = document.getElementById("RgChart");
    var BarChart = new Chart(ctx8, {
        type: 'bar',
        data: {
            labels: times,
            datasets: [{
                label: "Ray. Global",
                backgroundColor: "rgba(2,117,216,1)",
                borderColor: "rgba(2,117,216,1)",
                data: aRg,
            }],
        },
        options: {
            scales: {
                xAxes: [{
                    categoryPercentage: 1.0,
                    barPercentage: 1.0,
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
                        maxTicksLimit: 6
                    }
                }],
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: Math.max.apply(this, aRg) + 1,
                        maxTicksLimit: 5
                    },
                    gridLines: {
                        display: true
                    }
                }],
            },
            legend: {
                display: false
            }
        }
    });
}




