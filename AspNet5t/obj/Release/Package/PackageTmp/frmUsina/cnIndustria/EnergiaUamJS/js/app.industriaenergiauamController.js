/*! 
* Autor: Renato Ferreira Xavier
* Data: julho/2018
* 4T Sistemas Inteligentes Ltda.
*/
(function() {
    "use strict";

    Date.prototype.ddmmyyyy = function() {
        var yyyy = this.getFullYear().toString();
        var mm = (this.getMonth() + 1).toString(); // getMonth() is zero-based
        var dd = this.getDate().toString();
        var hh = this.getHours().toString();
        var mmm = this.getMinutes().toString();
        return (dd[1] ? dd : "0" + dd[0]) + '/' + (mm[1] ? mm : "0" + mm[0]) + '/' + yyyy; // padding
    };

    Date.prototype.yyyymmdd = function () {
        var yyyy = this.getFullYear().toString();
        var mm = (this.getMonth() + 1).toString(); // getMonth() is zero-based
        var dd = this.getDate().toString();
        var hh = this.getHours().toString();
        var mmm = this.getMinutes().toString();
        return yyyy + (mm[1] ? mm : "0" + mm[0]) + (dd[1] ? dd : "0" + dd[0]); // padding
    };

    function pureDate(dateString) {
        //dateString format: yyyy-MM-ddTHH:MM:SS (2018-04-17T00:00:00)
        var date = dateString;
        date = date.substring(0, 10).split('-');
        return new Date(parseInt(date[0]), parseInt(date[1]) - 1, parseInt(date[2]));
    };

    function getAppPath() {
        var pathArray = location.pathname.split('/');
        var appPath = "/";
        for (var i = 1; i < pathArray.length - 1; i++) {
            appPath += pathArray[i] + "/";
        }

        appPath = appPath.replace(/([^\/]*\/)$/, "");

        return appPath;
    };

    function getUrlParameter(name) {
        name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
        var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
        var results = regex.exec(location.search);
        return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
    };

    angular.module('app4T')
        .controller("industriaenergiauamCtrl", ['$scope', '$document', 'ApiGetService', industriaenergiauamCtrl]);

    function industriaenergiauamCtrl($scope, $document, ApiGetService) {
        //#region $scope empty object declarations
        var chartsVisaoGeralHeight = document.documentElement.clientHeight / 5.3;
        //                     green      yellow     red
        var coresMetaArray = ['#60bd68', '#decf3f', '#f15854'];

        $scope.filtroPeriodo = "";

        $scope.visaoGeral = function() { return $scope.filtroPeriodo === "" };
        $scope.filtroPeriodoDia = function() { return $scope.filtroPeriodo === "dia" };
        $scope.filtroPeriodoSemana = function() { return $scope.filtroPeriodo === "semana" };
        $scope.filtroPeriodoMes = function() { return $scope.filtroPeriodo === "mes" };
        $scope.filtroPeriodoSafra = function() { return $scope.filtroPeriodo === "safra" };

        $scope.visaoGeralButtonVisible = false;
        $scope.homeButtonVisible = false;

        function resolveParamsFromHome() {
            if ($scope.fromHome) {
                console.log('coming from home');

                $scope.visaoGeralSafra = getUrlParameter('safra');
                $scope.visaoGeralDiaDate = pureDate(getUrlParameter('dia'));
                $scope.visaoGeralSemana = getUrlParameter('semana');
                $scope.visaoGeralMes = getUrlParameter('mes');

                $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();
                $scope.visaoGeralDiaDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();

                console.log($scope.visaoGeralSafra);
                console.log($scope.visaoGeralDiaDate);
                console.log($scope.visaoGeralSemana);
                console.log($scope.visaoGeralMes);

            } else {
                console.log('NOT coming from home');
            };
        };

        function refreshAll(semLatest) {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaEnergiaUamVisaoGeralMinMaxDiaPromise(1)
                .then(function (data) {
                    if (!semLatest) {
                        $scope.visaoGeralSafra = data.safra;
                        $scope.visaoGeralDiaMinDate = pureDate(data.MinDia);
                        $scope.visaoGeralDiaMaxDate = pureDate(data.MaxDia);
                        $scope.visaoGeralDiaDate = pureDate(data.MaxDia);

                        $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();
                        $scope.visaoGeralDiaDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();
                        $scope.visaoGeralHora = data.MaxHora;

                        $scope.visaoGeralSemana = data.MaxSemana;

                        $scope.visaoGeralMes = data.MaxMes;

                        //$scope.visaoGeralSafra = data.Safra;
                    };

                    if ($scope.visaoGeral()) {
                        ApiGetService
                            .getindustriaEnergiaUamVisaoGeralCorteDiaPromise(1, $scope.visaoGeralSafra, new Date($scope.visaoGeralDiaDate).yyyymmdd())
                            .then(function(data) {
                                //Dia
                                $scope.chartVisaoGeralDiaDataSource.store().clear();

                                $scope.chartVisaoGeralDiaDataSource.store().insert({
                                    arg: "DIA",
                                    val: data.DiaVal,
                                    meta: data.DiaValMax - data.DiaVal <= 0 ? 0 : data.DiaValMax - data.DiaVal
                                });

                                $scope.chartVisaoGeralDiaDataSource.load();

                                $scope.visaoGeralDiaDate = pureDate(data.Dia);
                                $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();
                                $scope.visaoGeralDiaDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();
                                $scope.visaoGeralHora = data.Hora;

                                $scope.visaoGeralDiaVal = data.DiaVal;
                                $scope.visaoGeralDiaValMax = data.DiaValMax;
                                $scope.visaoGeralDiaIndicadorMeta = data.DiaIndicadorMeta;
                                $scope.visaoGeralDiaIndicadorMetaColor = coresMetaArray[data.DiaIndicadorMeta];

                                //Semana
                                $scope.chartVisaoGeralSemanaDataSource.store().clear();

                                $scope.chartVisaoGeralSemanaDataSource.store().insert({
                                    arg: "SEMANA",
                                    val: data.SemanaVal,
                                    meta: data.SemanaValMax - data.SemanaVal <= 0 ? 0 : data.SemanaValMax - data.SemanaVal
                                });

                                $scope.chartVisaoGeralSemanaDataSource.load();

                                $scope.visaoGeralSemana = data.Semana;
                                $scope.visaoGeralSemanaVal = data.SemanaVal;
                                $scope.visaoGeralSemanaValMax = data.SemanaValMax;
                                $scope.visaoGeralSemanaIndicadorMeta = data.SemanaIndicadorMeta;
                                $scope.visaoGeralSemanaIndicadorMetaColor = coresMetaArray[data.SemanaIndicadorMeta];

                                //Mes
                                $scope.chartVisaoGeralMesDataSource.store().clear();

                                $scope.chartVisaoGeralMesDataSource.store().insert({
                                    arg: "MÊS",
                                    val: data.MesVal,
                                    meta: data.MesValMax - data.MesVal <= 0 ? 0 : data.MesValMax - data.MesVal
                                });

                                $scope.chartVisaoGeralMesDataSource.load();

                                $scope.visaoGeralMes = data.Mes;
                                $scope.visaoGeralMesVal = data.MesVal;
                                $scope.visaoGeralMesValMax = data.MesValMax;
                                $scope.visaoGeralMesIndicadorMeta = data.MesIndicadorMeta;
                                $scope.visaoGeralMesIndicadorMetaColor = coresMetaArray[data.MesIndicadorMeta];

                                //Safra
                                $scope.chartVisaoGeralSafraDataSource.store().clear();

                                $scope.chartVisaoGeralSafraDataSource.store().insert({
                                    arg: "SAFRA",
                                    val: data.SafraVal,
                                    meta: data.SafraValMax - data.SafraVal <= 0 ? 0 : data.SafraValMax - data.SafraVal
                                });

                                $scope.chartVisaoGeralSafraDataSource.load();

                                $scope.visaoGeralSafra = data.Safra;
                                $scope.visaoGeralSafraVal = data.SafraVal;
                                $scope.visaoGeralSafraValMax = data.SafraValMax;
                                $scope.visaoGeralSafraIndicadorMeta = data.SafraIndicadorMeta;
                                $scope.visaoGeralSafraIndicadorMetaColor = coresMetaArray[data.SafraIndicadorMeta];

                                $scope.loadingVisible = false;
                            });
                    } else {
                        resolveParamsFromHome();
                        
                        if ($scope.filtroPeriodoDia()) {
                            diaClick();
                        } else if ($scope.filtroPeriodoSemana()) {
                            semanaClick();
                        } else if ($scope.filtroPeriodoMes()) {
                            mesClick();
                        } else if ($scope.filtroPeriodoSafra()) {
                            safraClick();
                        }
                    }
                });
        };

        $scope.$watch('filtroPeriodo', function() {
            $scope.visaoGeralButtonVisible = !($scope.filtroPeriodo == "") && !$scope.fromHome;
        });

        //Visão Geral
        $scope.chartVisaoGeralDiaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartVisaoGeralSemanaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartVisaoGeralMesDataSource = new DevExpress.data.DataSource([]);
        $scope.chartVisaoGeralSafraDataSource = new DevExpress.data.DataSource([]);

        $scope.visiblePopup = false;

        $scope.visaoGeralDia = "";
        $scope.visaoGeralDiaDisplay = "";
        $scope.visaoGeralHora = "00";
        $scope.visaoGeralHoraAnterior = function () { return ("00" + ($scope.visaoGeralHora - 1)).slice(-2); };

        $scope.visaoGeralDiaVal = 0;
        $scope.visaoGeralDiaValMax = 0;
        $scope.visaoGeralDiaIndicadorMeta = 0;
        $scope.visaoGeralDiaIndicadorMetaColor = "";

        $scope.visaoGeralSemana = 0;
        $scope.visaoGeralSemanaVal = 0;
        $scope.visaoGeralSemanaValMax = 0;
        $scope.visaoGeralSemanaIndicadorMeta = 0;
        $scope.visaoGeralSemanaIndicadorMetaColor = "";

        $scope.visaoGeralMes = 0;
        $scope.visaoGeralMesVal = 0;
        $scope.visaoGeralMesValMax = 0;
        $scope.visaoGeralMesIndicadorMeta = 0;
        $scope.visaoGeralMesIndicadorMetaColor = "";

        $scope.visaoGeralSafra = 0;
        $scope.visaoGeralSafraVal = 0;
        $scope.visaoGeralSafraValMax = 0;
        $scope.visaoGeralSafraIndicadorMeta = 0;
        $scope.visaoGeralSafraIndicadorMetaColor = "";

        //Dia Buttons
        var resolveDiaValButtonTypes = function () {
            $scope.diaValPontuaisButtonType = $scope.diaValPontuais ? 'success' : 'normal';
            $scope.diaValAcumuladosButtonType = $scope.diaValAcumulados ? 'success' : 'normal';
        };

        var resolvetitleChartDia = function () {
            var titleBase = "Controle de Exportação UAM Diário";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.diaValAcumulados ? " - Acumulado" : "";

            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleBase + titleVal;

            $scope.titleChartDia = title + " " + $scope.visaoGeralDiaDisplay;
        };

        $scope.$watch('diaValPontuais', function () {
            if ($scope.diaValPontuais) {
                $scope.diaValAcumulados = false;

                resolveDiaValButtonTypes();

                $scope.dsChartDia = $scope.dadosGeral.oGrafico;
                resolvetitleChartDia();
            };
        });

        $scope.$watch('diaValAcumulados', function () {
            if ($scope.diaValAcumulados) {
                $scope.diaValPontuais = false;

                resolveDiaValButtonTypes();

                $scope.dsChartDia = $scope.dadosGeral.oGraficoAcumulado;
                resolvetitleChartDia();
            };
        });

        //Dia
        $scope.dsChartDia = {};

        $scope.diaValPontuais = true;
        $scope.diaValAcumulados = false;
        resolveDiaValButtonTypes();

        resolvetitleChartDia();

        $scope.dsGridDia = {};

        $scope.mediaHoraAnterior = "0";

        //Semana Buttons
        var resolveSemanaValButtonTypes = function () {
            $scope.semanaValPontuaisButtonType = $scope.semanaValPontuais ? 'success' : 'normal';
            $scope.semanaValAcumuladosButtonType = $scope.semanaValAcumulados ? 'success' : 'normal';
        };

        var resolvetitleChartSemana = function () {
            var titleBase = "Controle de Exportação UAM Semanal";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.semanaValAcumulados ? " - Acumulado" : "";

            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleBase + titleVal;

            $scope.titleChartSemana = title; // + " " + $scope.visaoGeralSemana;
        };

        $scope.$watch('semanaValPontuais', function () {
            if ($scope.semanaValPontuais) {
                $scope.semanaValAcumulados = false;

                resolveSemanaValButtonTypes();

                $scope.dsChartSemana = $scope.dadosGeral.oGrafico;
                resolvetitleChartSemana();
            };
        });

        $scope.$watch('semanaValAcumulados', function () {
            if ($scope.semanaValAcumulados) {
                $scope.semanaValPontuais = false;

                resolveSemanaValButtonTypes();

                $scope.dsChartSemana = $scope.dadosGeral.oGraficoAcumulado;
                resolvetitleChartSemana();
            };
        });

        //Semana
        $scope.dsChartSemana = {};

        $scope.semanaValPontuais = true;
        $scope.semanaValAcumulados = false;
        resolveSemanaValButtonTypes();

        resolvetitleChartSemana();

        $scope.dsGridSemana = {};


        //Mes Buttons
        var resolveMesValButtonTypes = function () {
            $scope.mesValPontuaisButtonType = $scope.mesValPontuais ? 'success' : 'normal';
            $scope.mesValAcumuladosButtonType = $scope.mesValAcumulados ? 'success' : 'normal';
        };

        var resolvetitleChartMes = function () {
            var titleBase = "Controle de Exportação UAM Mensal";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.mesValAcumulados ? " - Acumulado" : "";

            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleBase + titleVal;

            $scope.titleChartMes = title; // + " " + $scope.visaoGeralMesDisplay;
        };

        $scope.$watch('mesValPontuais', function () {
            if ($scope.mesValPontuais) {
                $scope.mesValAcumulados = false;

                resolveMesValButtonTypes();

                $scope.dsChartMes = datasourceDadosMes($scope.dadosGeral.oGrafico);
                resolvetitleChartMes();
            };
        });

        $scope.$watch('mesValAcumulados', function () {
            if ($scope.mesValAcumulados) {
                $scope.mesValPontuais = false;

                resolveMesValButtonTypes();

                $scope.dsChartMes = datasourceDadosMes($scope.dadosGeral.oGraficoAcumulado);
                resolvetitleChartMes();
            };
        });

        //Mes
        $scope.dsChartMes = {};

        $scope.mesValPontuais = true;
        $scope.mesValAcumulados = false;
        resolveMesValButtonTypes();

        resolvetitleChartMes();

        $scope.dsGridMes = {};

        //Safra Buttons
        var resolveSafraValButtonTypes = function () {
            $scope.safraValPontuaisButtonType = $scope.safraValPontuais ? 'success' : 'normal';
            $scope.safraValAcumuladosButtonType = $scope.safraValAcumulados ? 'success' : 'normal';
        };

        var resolvetitleChartSafra = function () {
            var titleBase = "Controle de Exportação UAM Safra";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.safraValAcumulados ? " - Acumulado": "";

            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleBase +titleVal;

            $scope.titleChartSafra = title; // + " " +$scope.visaoGeralSafraDisplay;
        };

        $scope.$watch('safraValPontuais', function () {
            if ($scope.safraValPontuais) {
                $scope.safraValAcumulados = false;

                resolveSafraValButtonTypes();

                $scope.dsChartSafra = $scope.dadosGeral.oGrafico;
                resolvetitleChartSafra();
            };
        });

        $scope.$watch('safraValAcumulados', function () {
            if ($scope.safraValAcumulados) {
                $scope.safraValPontuais = false;

                resolveSafraValButtonTypes();

                $scope.dsChartSafra = $scope.dadosGeral.oGraficoAcumulado;
                resolvetitleChartSafra();
            };
        });

        //Safra
        $scope.dsChartSafra = {};

        $scope.safraValPontuais = true;
        $scope.safraValAcumulados = false;
        resolveSafraValButtonTypes();

        resolvetitleChartSafra();

        $scope.dsGridSafra = {};


        $scope.dadosGeral = {};

        $scope.autoRefreshButtonType = !window.localStorage.getItem("bi4tInd03ar") || window.localStorage.getItem("bi4tInd03ar") == 0 ? 'success' : 'normal';

        angular.element(document).ready(function() {
            //ORDEM: 2 - Document Ready Angular

            Globalize.culture("pt-BR");

            $scope.fromHome = Boolean(getUrlParameter('periodo'));
            $scope.filtroPeriodo = getUrlParameter('periodo');

            $scope.homeButtonVisible = $scope.fromHome;

            refreshAll();

            $scope.interval = null;

            if (!window.localStorage.getItem("bi4tInd03ar")) {
                window.localStorage.setItem("bi4tInd03ar", 0);
                window.localStorage.setItem("bi4tInd03arsec", 60);
            };

            $scope.autoRefresh = (window.localStorage.getItem("bi4tInd03ar") == 0);
            $scope.autoRefreshSeconds = window.localStorage.getItem("bi4tInd03arsec");

            if ($scope.autoRefresh) {
                $scope.interval = setInterval(refreshAll, $scope.autoRefreshSeconds * 1000);
            } else {
                clearInterval($scope.interval);                
            };

            $scope.autoRefreshButtonIcon = $scope.autoRefresh ? 'check' : 'remove';
            //$scope.autoRefreshButtonType = $scope.autoRefresh ? 'success' : 'normal';
        });

        $scope.buttonAutoRefreshOptions = {
            text: "Atualização automática",
            bindingOptions: {
                type: 'autoRefreshButtonType',
                icon: 'autoRefreshButtonIcon'
            },
            onClick: function () {
                $scope.checkBoxAutoRefresh = $scope.autoRefresh;
                $scope.numberBoxAutoRefresh = $scope.autoRefreshSeconds;
                $scope.visiblePopup = true;
                //$("html").css("background-color", "black", "important");
            }
        };

        $scope.popupOptions = {
            width: 300,
            height: 250,
            contentTemplate: "info",
            showCloseButton: false,
            showTitle: true,
            title: "Atualização automática",
            dragEnabled: false,
            closeOnOutsideClick: false,
            bindingOptions: {
                visible: "visiblePopup"
            }
        };

        $scope.checkBoxAutoRefreshOptions = {
            bindingOptions: {
                value: 'checkBoxAutoRefresh'
            }
        };

        $scope.numberBoxAutoRefreshOptions = {
            bindingOptions: {
                value: 'numberBoxAutoRefresh'
            },
            min: 30,
            max: 1800,
            showSpinButtons: true
        };

        $scope.buttonOkAutoRefreshOptions = {
            text: "OK",
            onClick: function () {
                clearInterval($scope.interval);

                $scope.autoRefresh = $scope.checkBoxAutoRefresh;
                $scope.autoRefreshSeconds = $scope.numberBoxAutoRefresh;

                window.localStorage.setItem("bi4tInd03ar", $scope.autoRefresh ? 0 : 1);
                window.localStorage.setItem("bi4tInd03arsec", $scope.autoRefreshSeconds);

                if ($scope.autoRefresh) {
                    $scope.interval = setInterval(refreshAll, $scope.autoRefreshSeconds * 1000);
                } else {
                    clearInterval($scope.interval);
                };

                $scope.autoRefreshButtonIcon = $scope.autoRefresh ? 'check' : 'remove';
                $scope.autoRefreshButtonType = $scope.autoRefresh ? 'success' : 'normal';

                $scope.visiblePopup = false;
            }
        };

        $scope.buttonHomeOptions = {
            text: "Home",
            icon: "home",
            bindingOptions: {
                visible: 'homeButtonVisible'
            },
            onClick: function () {
                window.location.replace(getAppPath() + "HomeJS/cnIndustriaHomeJS");
            }
        };


        $scope.buttonVisaoGeralOptions = {
            text: "Visão Geral",
            icon: "upload",
            bindingOptions: {
                visible: 'visaoGeralButtonVisible'
            },
            onClick: function () {
                $scope.dsChartDia = {};
                $scope.dsGridDia = {};

                $scope.dsChartSemana = {};
                $scope.dsChartMes = {};
                $scope.dsChartSafra = {};

                $scope.filtroPeriodo = "";
            }
        };

        $scope.dateBoxOptions = {
            type: "date",
            bindingOptions: {
                value: 'visaoGeralDiaDate',
                max: 'visaoGeralDiaMaxDate',
                min: 'visaoGeralDiaMinDate',
                visible: '!visaoGeralButtonVisible && !homeButtonVisible'
            },
            formatString: 'dd/MM/yyyy',
            readOnly: false,
            invalidDateMessage: 'Conteúdo deve ser uma data válida',
            dateOutOfRangeMessage: 'Data está fora do período',
            onValueChanged: function (e) {
                if (!$scope.loadingVisible) refreshAll(true);
            }
        };

        $scope.loadOptions = {
            bindingOptions: {
                visible: "loadingVisible"
            },

            showIndicator: true,
            showPane: true,
            shading: true,
            message: "Aguarde..."
        };

        //Visão Geral Dia
        $scope.chartVisaoGeralDiaOptions = {
            dataSource: $scope.chartVisaoGeralDiaDataSource,
            legend: {
                visible: false
            },
            series: [
                {
                    type: "fullStackedBar",
                    valueField: "val"
                }, {
                    type: "fullStackedBar",
                    valueField: "meta",
                    color: "#D3D3D3",
                    label: {
                        visible: false
                    }
                }
            ],
            rotated: true,
            argumentAxis: {
                label: {
                    font: {
                        size: 18
                    },
                    indentFromAxis: 54
                }
            },
            valueAxis: {
                grid: {
                    visible: false
                },
                label: {
                    visible: false
                }
            },
            commonSeriesSettings: {
                label: {
                    visible: true,
                    position: 'inside',
                    backgroundColor: 'transparent',
                    font: {
                        color: 'black',
                        size: 24,
                        weight: 600
                    },
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " MWh"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'visaoGeralDiaValMax',
                'series[0].color': 'visaoGeralDiaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function(e) {
                $scope.filtroPeriodo = "dia";
                refreshAll(true);
            },
            onSeriesClick: function (e) {
                $scope.filtroPeriodo = "dia";
                refreshAll(true);
            }
        };

        function gridDiaColumns(dataGrafico) {
            var columnsBase = [
                {
                    dataField: "Diario",
                    caption: "",
                    alignment: "center"
                }, {
                    dataField: "Hora",
                    caption: "Hora",
                    alignment: "center"
                }];

            var columns = [];

            for (var i = 0; i < dataGrafico.length; i++) {
                columns.push({
                    dataField: "H" + dataGrafico[i].HORA + "_DISP",
                    caption: dataGrafico[i].HORA,
                    dataType: "string",
                    alignment: "center"
                });
            };

            columns.sort(function (a, b) {
                return (a.dataField < b.dataField) ? -1 : (a.dataField > b.dataField) ? 1 : 0;
            });

            for (var j = 0; j < columns.length; j++) {
                columnsBase.push(columns[j]);
            };

            return columnsBase;
        };


        function diaClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaEnergiaUamPorDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia)
                .then(function (data) {

                    for (var i = 0; i < data.oGrid.length; i++) {
                        $.extend(data.oGrid[i],
                            {
                                H00_DISP: gridDiaCellDisplay(data.oGrid[i].H00, data.oGrid[i].Hora),
                                H01_DISP: gridDiaCellDisplay(data.oGrid[i].H01, data.oGrid[i].Hora),
                                H02_DISP: gridDiaCellDisplay(data.oGrid[i].H02, data.oGrid[i].Hora),
                                H03_DISP: gridDiaCellDisplay(data.oGrid[i].H03, data.oGrid[i].Hora),
                                H04_DISP: gridDiaCellDisplay(data.oGrid[i].H04, data.oGrid[i].Hora),
                                H05_DISP: gridDiaCellDisplay(data.oGrid[i].H05, data.oGrid[i].Hora),
                                H06_DISP: gridDiaCellDisplay(data.oGrid[i].H06, data.oGrid[i].Hora),
                                H07_DISP: gridDiaCellDisplay(data.oGrid[i].H07, data.oGrid[i].Hora),
                                H08_DISP: gridDiaCellDisplay(data.oGrid[i].H08, data.oGrid[i].Hora),
                                H09_DISP: gridDiaCellDisplay(data.oGrid[i].H09, data.oGrid[i].Hora),
                                H10_DISP: gridDiaCellDisplay(data.oGrid[i].H10, data.oGrid[i].Hora),
                                H11_DISP: gridDiaCellDisplay(data.oGrid[i].H11, data.oGrid[i].Hora),
                                H12_DISP: gridDiaCellDisplay(data.oGrid[i].H12, data.oGrid[i].Hora),
                                H13_DISP: gridDiaCellDisplay(data.oGrid[i].H13, data.oGrid[i].Hora),
                                H14_DISP: gridDiaCellDisplay(data.oGrid[i].H14, data.oGrid[i].Hora),
                                H15_DISP: gridDiaCellDisplay(data.oGrid[i].H15, data.oGrid[i].Hora),
                                H16_DISP: gridDiaCellDisplay(data.oGrid[i].H16, data.oGrid[i].Hora),
                                H17_DISP: gridDiaCellDisplay(data.oGrid[i].H17, data.oGrid[i].Hora),
                                H18_DISP: gridDiaCellDisplay(data.oGrid[i].H18, data.oGrid[i].Hora),
                                H19_DISP: gridDiaCellDisplay(data.oGrid[i].H19, data.oGrid[i].Hora),
                                H20_DISP: gridDiaCellDisplay(data.oGrid[i].H20, data.oGrid[i].Hora),
                                H21_DISP: gridDiaCellDisplay(data.oGrid[i].H21, data.oGrid[i].Hora),
                                H22_DISP: gridDiaCellDisplay(data.oGrid[i].H22, data.oGrid[i].Hora),
                                H23_DISP: gridDiaCellDisplay(data.oGrid[i].H23, data.oGrid[i].Hora)
                            });
                    };

                    $scope.dadosGeral = data;

                    $scope.dsChartDia = $scope.diaValPontuais ? $scope.dadosGeral.oGrafico : $scope.dadosGeral.oGraficoAcumulado;
                    $scope.dsGridDia = $scope.dadosGeral.oGrid;

                    $scope.gridDiaColumns = gridDiaColumns($scope.dsChartDia);
                    console.log($scope.gridDiaColumns);

                    $scope.mediaHoraAnterior = parseFloat($scope.dadosGeral.MediaHoraAnterior).toLocaleString() + " MWh/h";

                    $scope.loadingVisible = false;
                });
        };

        var gridDiaCellDisplay = function (content, colHora, hora) {
            if (parseInt(hora) > parseInt($scope.visaoGeralHora)) {return ""};

            if (colHora == "%") {
                content = content * 100;
                content = content.toLocaleString() + "%";
                return content;
            } else {
                return content.toLocaleString();
            };
        };

        $scope.gridDiaOptions = {
            bindingOptions: {
                dataSource: 'dsGridDia',
                columns: 'gridDiaColumns'
            },
            columnAutoWidth: true,
            showBorders: true,
            showRowLines: true,
            loadPanel: {
                text: "Carregando..."
            },
            noDataText: "Não há dados",
            onRowPrepared: function (info) {
                if (info.data && info.data.Hora == "Coef.Angular")
                    info.rowElement.css('display', 'none');
            },
            onCellPrepared: function(info) {
                if (info.rowType == 'header' || info.columnIndex <= 1) {
                    info.cellElement.css('font-weight', 'bold');
                    info.cellElement.css('color', 'black');
                }
            },
            onContentReady: function(e) {
                e.element.addClass('bordasgrid');
            }
        };

        //Visão Geral Semana
        $scope.chartVisaoGeralSemanaOptions = {
            dataSource: $scope.chartVisaoGeralSemanaDataSource,
            legend: {
                visible: false
            },
            series: [
                {
                    type: "fullStackedBar",
                    valueField: "val"
                }, {
                    type: "fullStackedBar",
                    valueField: "meta",
                    color: "#D3D3D3",
                    label: {
                        visible: false
                    }
                }
            ],
            rotated: true,
            argumentAxis: {
                label: {
                    font: {
                        size: 18
                    },
                    indentFromAxis: 12
                }
            },
            valueAxis: {
                grid: {
                    visible: false
                },
                label: {
                    visible: false
                }
            },
            commonSeriesSettings: {
                label: {
                    visible: true,
                    position: 'inside',
                    backgroundColor: 'transparent',
                    font: {
                        color: 'black',
                        size: 24,
                        weight: 600
                    },
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " MWh"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'visaoGeralSemanaValMax',
                'series[0].color': 'visaoGeralSemanaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function(e) {
                $scope.filtroPeriodo = "semana";
                refreshAll(true);
            },
            onSeriesClick: function (e) {
                $scope.filtroPeriodo = "semana";
                refreshAll(true);
            }
        };

        function gridSemanaColumns(dataGrafico) {
            var columnsBase = [
                {
                    dataField: "Diario",
                    caption: "",
                    alignment: "center"
                }, {
                    dataField: "Hora",
                    caption: "Dia",
                    alignment: "center"
                }];

            var columns = [];

            for (var i = 0; i < dataGrafico.length; i++) {
                columns.push({
                    dataField: "DIA" + (i + 1) + "_DISP",
                    caption: pureDate(dataGrafico[i].DIA).ddmmyyyy(),
                    dataType: "string",
                    alignment: "center"
                });
            };

            columns.sort(function (a, b) {
                return (a.dataField < b.dataField) ? -1 : (a.dataField > b.dataField) ? 1 : 0;
            });

            for (var j = 0; j < columns.length; j++) {
                columnsBase.push(columns[j]);
            };

            return columnsBase;
        };

        function semanaClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaEnergiaUamPorSemanaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralSemana)
                .then(function (data) {

                    for (var i = 0; i < data.oGrid.length; i++) {
                        $.extend(data.oGrid[i],
                            {
                                DIA1_DISP: gridSemanaCellDisplay(data.oGrid[i].DIA1, data.oGrid[i].Hora),
                                DIA2_DISP: gridSemanaCellDisplay(data.oGrid[i].DIA2, data.oGrid[i].Hora),
                                DIA3_DISP: gridSemanaCellDisplay(data.oGrid[i].DIA3, data.oGrid[i].Hora),
                                DIA4_DISP: gridSemanaCellDisplay(data.oGrid[i].DIA4, data.oGrid[i].Hora),
                                DIA5_DISP: gridSemanaCellDisplay(data.oGrid[i].DIA5, data.oGrid[i].Hora),
                                DIA6_DISP: gridSemanaCellDisplay(data.oGrid[i].DIA6, data.oGrid[i].Hora),
                                DIA7_DISP: gridSemanaCellDisplay(data.oGrid[i].DIA7, data.oGrid[i].Hora)
                            });
                    };

                    $scope.dadosGeral = data;

                    $scope.dsChartSemana = $scope.semanaValPontuais ? $scope.dadosGeral.oGrafico : $scope.dadosGeral.oGraficoAcumulado;
                    $scope.dsGridSemana = $scope.dadosGeral.oGrid;

                    $scope.gridSemanaColumns = gridSemanaColumns($scope.dsChartSemana);

                    $scope.loadingVisible = false;
                });
        };

        var gridSemanaCellDisplay = function (content, colHora) {
            if (colHora == "%") {
                content = content * 100;
                content = content.toLocaleString() + "%";
                return content;
            } else {
                return content.toLocaleString();
            };
        };

        $scope.gridSemanaOptions = {
            bindingOptions: {
                dataSource: 'dsGridSemana',
                columns: 'gridSemanaColumns'
            },
            columnAutoWidth: true,
            showBorders: true,
            showRowLines: true,
            loadPanel: {
                text: "Carregando..."
            },
            noDataText: "Não há dados",
            onCellPrepared: function (info) {
                if (info.rowType == 'header' || info.columnIndex <= 1) {
                    info.cellElement.css('font-weight', 'bold');
                    info.cellElement.css('color', 'black');
                }
            },
            onContentReady: function (e) {
                e.element.addClass('bordasgrid');
            }
        };


        //Visão Geral Mês
        $scope.chartVisaoGeralMesOptions = {
            dataSource: $scope.chartVisaoGeralMesDataSource,
            legend: {
                visible: false
            },
            series: [
                {
                    type: "fullStackedBar",
                    valueField: "val"
                }, {
                    type: "fullStackedBar",
                    valueField: "meta",
                    color: "#D3D3D3",
                    label: {
                        visible: false
                    }
                }
            ],
            rotated: true,
            argumentAxis: {
                label: {
                    font: {
                        size: 18
                    },
                    indentFromAxis: 48
                }
            },
            valueAxis: {
                grid: {
                    visible: false
                },
                label: {
                    visible: false
                }
            },
            commonSeriesSettings: {
                label: {
                    visible: true,
                    position: 'inside',
                    backgroundColor: 'transparent',
                    font: {
                        color: 'black',
                        size: 24,
                        weight: 600
                    },
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " MWh"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'visaoGeralMesValMax',
                'series[0].color': 'visaoGeralMesIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function(e) {
                $scope.filtroPeriodo = "mes";
                refreshAll(true);
            },
            onSeriesClick: function (e) {
                $scope.filtroPeriodo = "mes";
                refreshAll(true);
            }
        };

        function gridMesColumns(dataGrafico) {
            var columnsBase = [
                {
                    dataField: "Diario",
                    caption: "",
                    alignment: "center"
                }, {
                    dataField: "Hora",
                    caption: "Semana",
                    alignment: "center"
                }];

            var columns = [];

            for (var i = 0; i < dataGrafico.length; i++) {
                columns.push({
                    dataField: "SEMANA" + (i + 1) + "_DISP",
                    caption: pureDate(dataGrafico[i].semanaPeriodo.diaInicio).ddmmyyyy() + ' a ' + pureDate(dataGrafico[i].semanaPeriodo.diaFim).ddmmyyyy(),
                    dataType: "string",
                    alignment: "center"
                });
            };

            columns.sort(function (a, b) {
                return (a.dataField < b.dataField) ? -1 : (a.dataField > b.dataField) ? 1 : 0;
            });

            for (var j = 0; j < columns.length; j++) {
                columnsBase.push(columns[j]);
            };

            return columnsBase;
        };

        function mesClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaEnergiaUamPorMesPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralMes)
                .then(function (data) {

                    for (var i = 0; i < data.oGrid.length; i++) {
                        $.extend(data.oGrid[i],
                            {
                                SEMANA1_DISP: gridMesCellDisplay(data.oGrid[i].SEMANA1, data.oGrid[i].Hora),
                                SEMANA2_DISP: gridMesCellDisplay(data.oGrid[i].SEMANA2, data.oGrid[i].Hora),
                                SEMANA3_DISP: gridMesCellDisplay(data.oGrid[i].SEMANA3, data.oGrid[i].Hora),
                                SEMANA4_DISP: gridMesCellDisplay(data.oGrid[i].SEMANA4, data.oGrid[i].Hora),
                                SEMANA5_DISP: gridMesCellDisplay(data.oGrid[i].SEMANA5, data.oGrid[i].Hora),
                                SEMANA6_DISP: gridMesCellDisplay(data.oGrid[i].SEMANA6, data.oGrid[i].Hora)
                            });
                    };

                    $scope.dadosGeral = data;

                    $scope.dsChartMes = $scope.mesValPontuais ? datasourceDadosMes($scope.dadosGeral.oGrafico) : datasourceDadosMes($scope.dadosGeral.oGraficoAcumulado);
                    $scope.dsGridMes = $scope.dadosGeral.oGrid;

                    $scope.gridMesColumns = gridMesColumns($scope.dsChartMes);

                    $scope.loadingVisible = false;
                });
        };

        var gridMesCellDisplay = function (content, colHora) {
            if (colHora == "%") {
                content = content * 100;
                content = content.toLocaleString() + "%";
                return content;
            } else {
                return content.toLocaleString();
            };
        };

        $scope.gridMesOptions = {
            bindingOptions: {
                dataSource: 'dsGridMes',
                columns: 'gridMesColumns'
            },
            columnAutoWidth: true,
            showBorders: true,
            showRowLines: true,
            loadPanel: {
                text: "Carregando..."
            },
            noDataText: "Não há dados",
            onCellPrepared: function (info) {
                if (info.rowType == 'header' || info.columnIndex <= 1) {
                    info.cellElement.css('font-weight', 'bold');
                    info.cellElement.css('color', 'black');
                }
            },
            onContentReady: function (e) {
                e.element.addClass('bordasgrid');
            }
        };


        //Visão Geral Safra
        $scope.chartVisaoGeralSafraOptions = {
            dataSource: $scope.chartVisaoGeralSafraDataSource,
            legend: {
                visible: false
            },
            series: [
                {
                    type: "fullStackedBar",
                    valueField: "val"
                }, {
                    type: "fullStackedBar",
                    valueField: "meta",
                    color: "#D3D3D3",
                    label: {
                        visible: false
                    }
                }
            ],
            rotated: true,
            argumentAxis: {
                label: {
                    font: {
                        size: 18
                    },
                    indentFromAxis: 31
                }
            },
            valueAxis: {
                grid: {
                    visible: false
                },
                label: {
                    visible: false
                }
            },
            commonSeriesSettings: {
                label: {
                    visible: true,
                    position: 'inside',
                    backgroundColor: 'transparent',
                    font: {
                        color: 'black',
                        size: 24,
                        weight: 600
                    },
                    customizeText: function() { return parseFloat(this.valueText).toLocaleString() + " MWh"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'visaoGeralSafraValMax',
                'series[0].color': 'visaoGeralSafraIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function(e) {
                $scope.filtroPeriodo = "safra";
                refreshAll(true);
            },
            onSeriesClick: function (e) {
                $scope.filtroPeriodo = "safra";
                refreshAll(true);
            }
        };

        function mesNome(mesNumero) {
            var mesesArray = ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'];

            return mesesArray[mesNumero - 1];
        };

        function gridSafraColumns(dataGrafico) {
            var columnsBase = [
                {
                    dataField: "Diario",
                    caption: "",
                    alignment: "center"
                }, {
                    dataField: "Hora",
                    caption: "Mês",
                    alignment: "center"
                }];

            var columns = [];

            for (var i = 0; i < dataGrafico.length; i++) {
                columns.push({
                    dataField: "MES" + dataGrafico[i].MES + "_DISP",
                    caption: mesNome(dataGrafico[i].MES),
                    dataType: "string",
                    alignment: "center"
                });
            };

            columns.sort(function (a, b) {
                return (a.dataField < b.dataField) ? -1 : (a.dataField > b.dataField) ? 1 : 0;
            });

            for (var j = 0; j < columns.length; j++) {
                columnsBase.push(columns[j]);
            };

            return columnsBase;
        };

        function safraClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaEnergiaUamPorSafraCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia)
                .then(function (data) {
                    for (var i = 0; i < data.oGrid.length; i++) {
                        $.extend(data.oGrid[i],
                            {
                                MES1_DISP: gridSafraCellDisplay(data.oGrid[i].MES1, data.oGrid[i].Hora),
                                MES2_DISP: gridSafraCellDisplay(data.oGrid[i].MES2, data.oGrid[i].Hora),
                                MES3_DISP: gridSafraCellDisplay(data.oGrid[i].MES3, data.oGrid[i].Hora),
                                MES4_DISP: gridSafraCellDisplay(data.oGrid[i].MES4, data.oGrid[i].Hora),
                                MES5_DISP: gridSafraCellDisplay(data.oGrid[i].MES5, data.oGrid[i].Hora),
                                MES6_DISP: gridSafraCellDisplay(data.oGrid[i].MES6, data.oGrid[i].Hora),
                                MES7_DISP: gridSafraCellDisplay(data.oGrid[i].MES7, data.oGrid[i].Hora),
                                MES8_DISP: gridSafraCellDisplay(data.oGrid[i].MES8, data.oGrid[i].Hora),
                                MES9_DISP: gridSafraCellDisplay(data.oGrid[i].MES9, data.oGrid[i].Hora),
                                MES10_DISP: gridSafraCellDisplay(data.oGrid[i].MES10, data.oGrid[i].Hora),
                                MES11_DISP: gridSafraCellDisplay(data.oGrid[i].MES11, data.oGrid[i].Hora),
                                MES12_DISP: gridSafraCellDisplay(data.oGrid[i].MES12, data.oGrid[i].Hora)
                            });
                    };

                    $scope.dadosGeral = data;

                    $scope.dsChartSafra = $scope.safraValPontuais ? $scope.dadosGeral.oGrafico : $scope.dadosGeral.oGraficoAcumulado;
                    $scope.dsGridSafra = $scope.dadosGeral.oGrid;

                    $scope.gridSafraColumns = gridSafraColumns($scope.dsChartSafra);

                    $scope.loadingVisible = false;
                });
        };

        var gridSafraCellDisplay = function (content, colHora) {
            if (colHora == "%") {
                content = content * 100;
                content = content.toLocaleString() + "%";
                return content;
            } else {
                return content.toLocaleString();
            };
        };

        $scope.gridSafraOptions = {
            bindingOptions: {
                dataSource: 'dsGridSafra',
                columns: 'gridSafraColumns'
            },
            columnAutoWidth: true,
            showBorders: true,
            showRowLines: true,
            loadPanel: {
                text: "Carregando..."
            },
            noDataText: "Não há dados",
            onCellPrepared: function (info) {
                if (info.rowType == 'header' || info.columnIndex <= 1) {
                    info.cellElement.css('font-weight', 'bold');
                    info.cellElement.css('color', 'black');
                }
            },
            onContentReady: function (e) {
                e.element.addClass('bordasgrid');
            }
        };


        //Chart Dia
        $scope.chartDiaOptions = {
            bindingOptions: {
                dataSource: 'dsChartDia',
                title: 'titleChartDia'
            },
            argumentAxis: {
                argumentType: 'datetime',
                label: {
                    format: 'HH'
                },
                tickInterval: { hours: 1 }
            },
            commonSeriesSettings: {
                argumentField: "DIA",
                type: "line",
                point: {
                    size: 8
                }
            },
            tooltip: {
                enabled: true,
                customizeTooltip: function (arg) {
                    var node = $("<div>")
                        .append("<h5>" + arg.value.toLocaleString() + "</h5>");

                    return {
                        html: node.html()
                    };
                }
            },
            series: [
                { valueField: "VALOR_PLAN", name: "Planejado" },
                { valueField: "VALOR_REAL", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.buttonDiaValoresPontuaisOptions = {
            text: 'Valores Pontuais',
            bindingOptions: {
                type: 'diaValPontuaisButtonType'
            },
            onClick: function () {
                $scope.diaValPontuais = true;
            }
        };

        $scope.buttonDiaValoresAcumuladosOptions = {
            text: 'Valores Acumulados',
            bindingOptions: {
                type: 'diaValAcumuladosButtonType'
            },
            onClick: function () {
                $scope.diaValAcumulados = true;
            }
        };


        //Chart Semana
        $scope.chartSemanaOptions = {
            bindingOptions: {
                dataSource: 'dsChartSemana',
                title: 'titleChartSemana'
            },
            argumentAxis: {
                argumentType: 'datetime',
                label: {
                    format: 'shortDate'
                },
                tickInterval: { days: 1 }
            },
            commonSeriesSettings: {
                argumentField: "DIA",
                type: "line",
                point: {
                    size: 8
                }
            },
            tooltip: {
                enabled: true,
                customizeTooltip: function (arg) {
                    var node = $("<div>")
                        .append("<h5>" + arg.value.toLocaleString() + "</h5>");

                    return {
                        html: node.html()
                    };
                }
            },
            series: [
                { valueField: "VALOR_PLAN", name: "Planejado" },
                { valueField: "VALOR_REAL", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.buttonSemanaValoresPontuaisOptions = {
            text: 'Valores Pontuais',
            bindingOptions: {
                type: 'semanaValPontuaisButtonType'
            },
            onClick: function () {
                $scope.semanaValPontuais = true;
            }
        };

        $scope.buttonSemanaValoresAcumuladosOptions = {
            text: 'Valores Acumulados',
            bindingOptions: {
                type: 'semanaValAcumuladosButtonType'
            },
            onClick: function () {
                $scope.semanaValAcumulados = true;
            }
        };


        //Chart Mes
        function datasourceDadosMes(data) {
            if (!data) return [];

            var datasourceMes = [];

            for (var i = 0; i < data.length; i++) {
                datasourceMes.push($.extend(data[i],
                    { semanaPeriodoDisplay: pureDate(data[i].semanaPeriodo.diaInicio).ddmmyyyy() + ' a ' + pureDate(data[i].semanaPeriodo.diaFim).ddmmyyyy() }
                ));
            }

            return datasourceMes;
        };

        $scope.chartMesOptions = {
            bindingOptions: {
                dataSource: 'dsChartMes',
                title: 'titleChartMes'
            },
            argumentAxis: {
                argumentType: 'string',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            commonSeriesSettings: {
                argumentField: "semanaPeriodoDisplay",
                type: "line",
                point: {
                    size: 8
                }
            },
            tooltip: {
                enabled: true,
                customizeTooltip: function (arg) {
                    var node = $("<div>")
                        .append("<h5>" + arg.value.toLocaleString() + "</h5>");

                    return {
                        html: node.html()
                    };
                }
            },
            series: [
                { valueField: "VALOR_PLAN", name: "Planejado" },
                { valueField: "VALOR_REAL", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.buttonMesValoresPontuaisOptions = {
            text: 'Valores Pontuais',
            bindingOptions: {
                type: 'mesValPontuaisButtonType'
            },
            onClick: function () {
                $scope.mesValPontuais = true;
            }
        };

        $scope.buttonMesValoresAcumuladosOptions = {
            text: 'Valores Acumulados',
            bindingOptions: {
                type: 'mesValAcumuladosButtonType'
            },
            onClick: function () {
                $scope.mesValAcumulados = true;
            }
        };


        //Chart Safra
        $scope.chartSafraOptions = {
            bindingOptions: {
                dataSource: 'dsChartSafra',
                title: 'titleChartSafra'
            },
            argumentAxis: {
                argumentType: 'datetime',
                label: {
                    format: 'month'
                },
                tickInterval: { months: 1 }
            },
            commonSeriesSettings: {
                argumentField: "DIA",
                type: "line",
                point: {
                    size: 4
                }
            },
            tooltip: {
                enabled: true,
                customizeTooltip: function (arg) {
                    var node = $("<div>")
                        .append("<h5>" + arg.value.toLocaleString() + "</h5>");

                    return {
                        html: node.html()
                    };
                }
            },
            series: [
                { valueField: "VALOR_PLAN", name: "Planejado" },
                { valueField: "VALOR_REAL", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.buttonSafraValoresPontuaisOptions = {
            text: 'Valores Pontuais',
            bindingOptions: {
                type: 'safraValPontuaisButtonType'
            },
            onClick: function () {
                $scope.safraValPontuais = true;
            }
        };

        $scope.buttonSafraValoresAcumuladosOptions = {
            text: 'Valores Acumulados',
            bindingOptions: {
                type: 'safraValAcumuladosButtonType'
            },
            onClick: function () {
                $scope.safraValAcumulados = true;
            }
        };
    };
})();