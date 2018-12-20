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
        .controller("industriaetanolCtrl", ['$scope', '$document', 'ApiGetService', industriaetanolCtrl]);

    function industriaetanolCtrl($scope, $document, ApiGetService) {
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
                .getindustriaEtanolVisaoGeralMinMaxDiaPromise(1)
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
                            .getindustriaEtanolVisaoGeralCorteDiaPromise(1, $scope.visaoGeralSafra, new Date($scope.visaoGeralDiaDate).yyyymmdd())
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

        var resolveDiaTipoButtonTypes = function () {
            $scope.diaTipoGeralButtonType = $scope.diaTipoGeral ? 'success' : 'normal';
            $scope.diaTipoAButtonType = $scope.diaTipoA ? 'success' : 'normal';
            $scope.diaTipoBButtonType = $scope.diaTipoB ? 'success' : 'normal';
        };

        var resolvetitleChartDia = function () {
            var titleBase = "Produção de Etanol Diária";

            var titleTipoGeral = $scope.diaTipoGeral ? " TOTAL" : "";
            var titleTipoA = $scope.diaTipoA ? " Anidro" : "";
            var titleTipoB = $scope.diaTipoB ? " Hidratado" : "";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.diaValAcumulados ? " - Acumulado" : "";

            var titleTipo = titleBase + titleTipoGeral + titleTipoA + titleTipoB;
            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleTipo + titleVal;

            $scope.titleChartDia = title + " " + $scope.visaoGeralDiaDisplay;
        };


        var dsChartDiaValoresPontuais = function () {
            if ($scope.diaTipoGeral) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrafico }
            if ($scope.diaTipoA) { return $scope.dadosTipoA[0].oGrafico }
            if ($scope.diaTipoB) { return $scope.dadosTipoB[0].oGrafico }
        };

        var dsChartDiaValoresAcumulados = function () {
            if ($scope.diaTipoGeral) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGraficoAcumulado }
            if ($scope.diaTipoA) { return $scope.dadosTipoA[0].oGraficoAcumulado }
            if ($scope.diaTipoB) { return $scope.dadosTipoB[0].oGraficoAcumulado }
        };


        var dsChartDiaTipoGeral = function () {
            if ($scope.diaValPontuais) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrafico }
            if ($scope.diaValAcumulados) { return $scope.dadosTipoAb[0].oGraficoAcumulado }
        };

        var dsChartDiaTipoA = function () {
            if ($scope.diaValPontuais) { return $scope.dadosTipoA[0] && $scope.dadosTipoA[0].oGrafico }
            if ($scope.diaValAcumulados) { return $scope.dadosTipoA[0].oGraficoAcumulado }
        };

        var dsChartDiaTipoB = function () {
            if ($scope.diaValPontuais) { return $scope.dadosTipoB[0] && $scope.dadosTipoB[0].oGrafico }
            if ($scope.diaValAcumulados) { return $scope.dadosTipoB[0].oGraficoAcumulado }
        };


        $scope.$watch('diaValPontuais', function () {
            if ($scope.diaValPontuais) {
                $scope.diaValAcumulados = false;

                resolveDiaValButtonTypes();

                $scope.dsChartDia = dsChartDiaValoresPontuais();
                resolvetitleChartDia();
            };
        });

        $scope.$watch('diaValAcumulados', function () {
            if ($scope.diaValAcumulados) {
                $scope.diaValPontuais = false;

                resolveDiaValButtonTypes();

                $scope.dsChartDia = dsChartDiaValoresAcumulados();
                resolvetitleChartDia();
            };
        });

        $scope.$watch('diaTipoGeral', function () {
            if ($scope.diaTipoGeral) {
                $scope.diaTipoA = false;
                $scope.diaTipoB = false;

                resolveDiaTipoButtonTypes();

                $scope.dsChartDia = dsChartDiaTipoGeral();
                resolvetitleChartDia();

                $scope.dsGridDia = $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrid;
                $scope.mediaHoraAnterior = $scope.dadosTipoAb[0] && parseFloat($scope.dadosTipoAb[0].MediaHoraAnterior).toLocaleString() + " m³";
            };
        });

        $scope.$watch('diaTipoA', function () {
            if ($scope.diaTipoA) {
                $scope.diaTipoGeral = false;
                $scope.diaTipoB = false;

                resolveDiaTipoButtonTypes();

                $scope.dsChartDia = dsChartDiaTipoA();
                resolvetitleChartDia();

                $scope.dsGridDia = $scope.dadosTipoA[0].oGrid;
                $scope.mediaHoraAnterior = $scope.dadosTipoA[0] && parseFloat($scope.dadosTipoA[0].MediaHoraAnterior).toLocaleString() + " m³";
            };
        });

        $scope.$watch('diaTipoB', function () {
            if ($scope.diaTipoB) {
                $scope.diaTipoGeral = false;
                $scope.diaTipoA = false;

                resolveDiaTipoButtonTypes();

                $scope.dsChartDia = dsChartDiaTipoB();
                resolvetitleChartDia();

                $scope.dsGridDia = $scope.dadosTipoB[0].oGrid;
                $scope.mediaHoraAnterior = $scope.dadosTipoB[0] && parseFloat($scope.dadosTipoB[0].MediaHoraAnterior).toLocaleString() + " m³";
            };
        });

        //Dia
        $scope.dsChartDia = {};

        $scope.diaValPontuais = true;
        $scope.diaValAcumulados = false;
        resolveDiaValButtonTypes();

        $scope.diaTipoGeral = true;
        $scope.diaTipoA = false;
        $scope.diaTipoB = false;
        resolveDiaTipoButtonTypes();

        resolvetitleChartDia();

        $scope.dsGridDia = {};
        $scope.dsGridDiaProjecao = {};

        $scope.passoDia = "0";
        $scope.mediaHoraAnterior = "0";
        $scope.estoquePatio = "0";

        //Semana Buttons
        var resolveSemanaValButtonTypes = function () {
            $scope.semanaValPontuaisButtonType = $scope.semanaValPontuais ? 'success' : 'normal';
            $scope.semanaValAcumuladosButtonType = $scope.semanaValAcumulados ? 'success' : 'normal';
        };

        var resolveSemanaTipoButtonTypes = function () {
            $scope.semanaTipoGeralButtonType = $scope.semanaTipoGeral ? 'success' : 'normal';
            $scope.semanaTipoAButtonType = $scope.semanaTipoA ? 'success' : 'normal';
            $scope.semanaTipoBButtonType = $scope.semanaTipoB ? 'success' : 'normal';
        };

        var resolvetitleChartSemana = function () {
            var titleBase = "Produção de Etanol Semanal";

            var titleTipoGeral = $scope.semanaTipoGeral ? " TOTAL" : "";
            var titleTipoA = $scope.semanaTipoA ? " Anidro" : "";
            var titleTipoB = $scope.semanaTipoB ? " Hidratado" : "";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.semanaValAcumulados ? " - Acumulado" : "";

            var titleTipo = titleBase + titleTipoGeral + titleTipoA + titleTipoB;
            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleTipo + titleVal;

            $scope.titleChartSemana = title; // + " " + $scope.visaoGeralSemana;
        };


        var dsChartSemanaValoresPontuais = function () {
            if($scope.semanaTipoGeral) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrafico }
            if ($scope.semanaTipoA) { return $scope.dadosTipoA[0].oGrafico }
            if ($scope.semanaTipoB) { return $scope.dadosTipoB[0].oGrafico }
        };

        var dsChartSemanaValoresAcumulados = function () {
            if ($scope.semanaTipoGeral) {
                return $scope.dadosTipoAb[0].oGraficoAcumulado
            }
            if ($scope.semanaTipoA) {
                return $scope.dadosTipoA[0].oGraficoAcumulado
            }
            if($scope.semanaTipoB) { return $scope.dadosTipoB[0].oGraficoAcumulado }
        };


        var dsChartSemanaTipoGeral = function () {
            if ($scope.semanaValPontuais) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrafico }
            if ($scope.semanaValAcumulados) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGraficoAcumulado }
        };

        var dsChartSemanaTipoA = function () {
            if ($scope.semanaValPontuais) {
                return $scope.dadosTipoA[0].oGrafico
            }
            if ($scope.semanaValAcumulados) {
                return $scope.dadosTipoA[0].oGraficoAcumulado
            }
        };

        var dsChartSemanaTipoB = function () {
            if($scope.semanaValPontuais) { return $scope.dadosTipoB[0].oGrafico }
            if ($scope.semanaValAcumulados) { return $scope.dadosTipoB[0].oGraficoAcumulado
            }
        };


        $scope.$watch('semanaValPontuais', function () {
            if ($scope.semanaValPontuais) {
                $scope.semanaValAcumulados = false;

                resolveSemanaValButtonTypes();

                $scope.dsChartSemana = dsChartSemanaValoresPontuais();
                resolvetitleChartSemana();
            };
        });

        $scope.$watch('semanaValAcumulados', function () {
            if ($scope.semanaValAcumulados) {
                $scope.semanaValPontuais = false;

                resolveSemanaValButtonTypes();

                $scope.dsChartSemana = dsChartSemanaValoresAcumulados();
                resolvetitleChartSemana();
            };
        });

        $scope.$watch('semanaTipoGeral', function () {
            if ($scope.semanaTipoGeral) {
                $scope.semanaTipoA = false;
                $scope.semanaTipoB = false;

                resolveSemanaTipoButtonTypes();

                $scope.dsChartSemana = dsChartSemanaTipoGeral();
                resolvetitleChartSemana();

                $scope.dsGridSemana = $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrid;
                $scope.dsGridSemanaProjecao = $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGridProjecao;
            };
        });

        $scope.$watch('semanaTipoA', function () {
            if ($scope.semanaTipoA) {
                $scope.semanaTipoGeral = false;
                $scope.semanaTipoB = false;

                resolveSemanaTipoButtonTypes();

                $scope.dsChartSemana = dsChartSemanaTipoA();
                resolvetitleChartSemana();

                $scope.dsGridSemana = $scope.dadosTipoA[0].oGrid;
                $scope.dsGridSemanaProjecao = $scope.dadosTipoA[0].oGridProjecao;
            };
        });

        $scope.$watch('semanaTipoB', function () {
            if ($scope.semanaTipoB) {
                $scope.semanaTipoGeral = false;
                $scope.semanaTipoA = false;

                resolveSemanaTipoButtonTypes();

                $scope.dsChartSemana = dsChartSemanaTipoB();
                resolvetitleChartSemana();

                $scope.dsGridSemana = $scope.dadosTipoB[0].oGrid;
                $scope.dsGridSemanaProjecao = $scope.dadosTipoB[0].oGridProjecao;
            };
        });

        //Semana
        $scope.dsChartSemana = {};

        $scope.semanaValPontuais = true;
        $scope.semanaValAcumulados = false;
        resolveSemanaValButtonTypes();

        $scope.semanaTipoGeral = true;
        $scope.semanaTipoA = false;
        $scope.semanaTipoB = false;
        resolveSemanaTipoButtonTypes();

        resolvetitleChartSemana();

        $scope.dsGridSemana = {};
        $scope.dsGridSemanaProjecao = {};


        //Mes Buttons
        var resolveMesValButtonTypes = function () {
            $scope.mesValPontuaisButtonType = $scope.mesValPontuais ? 'success' : 'normal';
            $scope.mesValAcumuladosButtonType = $scope.mesValAcumulados ? 'success' : 'normal';
        };

        var resolveMesTipoButtonTypes = function () {
            $scope.mesTipoGeralButtonType = $scope.mesTipoGeral ? 'success' : 'normal';
            $scope.mesTipoAButtonType = $scope.mesTipoA ? 'success' : 'normal';
            $scope.mesTipoBButtonType = $scope.mesTipoB ? 'success' : 'normal';
        };

        var resolvetitleChartMes = function () {
            var titleBase = "Produção de Etanol Mensal";

            var titleTipoGeral = $scope.mesTipoGeral ? " TOTAL" : "";
            var titleTipoA = $scope.mesTipoA ? " Anidro" : "";
            var titleTipoB = $scope.mesTipoB ? " Hidratado" : "";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.mesValAcumulados ? " - Acumulado" : "";

            var titleTipo = titleBase + titleTipoGeral + titleTipoA + titleTipoB;
            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleTipo + titleVal;

            $scope.titleChartMes = title; // + " " + $scope.visaoGeralMesDisplay;
        };


        var dsChartMesValoresPontuais = function () {
            if ($scope.mesTipoGeral) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrafico }
            if ($scope.mesTipoA) { return $scope.dadosTipoA[0].oGrafico }
            if ($scope.mesTipoB) { return $scope.dadosTipoB[0].oGrafico }
        };

        var dsChartMesValoresAcumulados = function () {
            if ($scope.mesTipoGeral) { return $scope.dadosTipoAb[0].oGraficoAcumulado }
            if ($scope.mesTipoA) { return $scope.dadosTipoA[0].oGraficoAcumulado }
            if ($scope.mesTipoB) { return $scope.dadosTipoB[0].oGraficoAcumulado }
        };


        var dsChartMesTipoGeral = function () {
            if ($scope.mesValPontuais) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrafico }
            if ($scope.mesValAcumulados) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGraficoAcumulado }
        };

        var dsChartMesTipoA = function () {
            if ($scope.mesValPontuais) { return $scope.dadosTipoA[0].oGrafico }
            if ($scope.mesValAcumulados) { return $scope.dadosTipoA[0].oGraficoAcumulado }
        };

        var dsChartMesTipoB = function () {
            if ($scope.mesValPontuais) { return $scope.dadosTipoB[0].oGrafico }
            if ($scope.mesValAcumulados) { return $scope.dadosTipoB[0].oGraficoAcumulado }
        };


        $scope.$watch('mesValPontuais', function () {
            if ($scope.mesValPontuais) {
                $scope.mesValAcumulados = false;

                resolveMesValButtonTypes();

                $scope.dsChartMes = datasourceDadosMes(dsChartMesValoresPontuais());
                resolvetitleChartMes();
            };
        });

        $scope.$watch('mesValAcumulados', function () {
            if ($scope.mesValAcumulados) {
                $scope.mesValPontuais = false;

                resolveMesValButtonTypes();

                $scope.dsChartMes = datasourceDadosMes(dsChartMesValoresAcumulados());
                resolvetitleChartMes();
            };
        });

        $scope.$watch('mesTipoGeral', function () {
            if ($scope.mesTipoGeral) {
                $scope.mesTipoA = false;
                $scope.mesTipoB = false;

                resolveMesTipoButtonTypes();

                $scope.dsChartMes = datasourceDadosMes(dsChartMesTipoGeral());
                resolvetitleChartMes();

                $scope.dsGridMes = $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrid;
            };
        });

        $scope.$watch('mesTipoA', function () {
            if ($scope.mesTipoA) {
                $scope.mesTipoGeral = false;
                $scope.mesTipoB = false;

                resolveMesTipoButtonTypes();

                $scope.dsChartMes = datasourceDadosMes(dsChartMesTipoA());
                resolvetitleChartMes();

                $scope.dsGridMes = $scope.dadosTipoA[0].oGrid;
            };
        });

        $scope.$watch('mesTipoB', function () {
            if ($scope.mesTipoB) {
                $scope.mesTipoGeral = false;
                $scope.mesTipoA = false;

                resolveMesTipoButtonTypes();
                
                $scope.dsChartMes = datasourceDadosMes(dsChartMesTipoB());
                resolvetitleChartMes();

                $scope.dsGridMes = $scope.dadosTipoB[0].oGrid;
            };
        });

        //Mes
        $scope.dsChartMes = {};

        $scope.mesValPontuais = true;
        $scope.mesValAcumulados = false;
        resolveMesValButtonTypes();

        $scope.mesTipoGeral = true;
        $scope.mesTipoA = false;
        $scope.mesTipoB = false;
        resolveMesTipoButtonTypes();

        resolvetitleChartMes();


        //Safra Buttons
        var resolveSafraValButtonTypes = function () {
            $scope.safraValPontuaisButtonType = $scope.safraValPontuais ? 'success' : 'normal';
            $scope.safraValAcumuladosButtonType = $scope.safraValAcumulados ? 'success' : 'normal';
        };

        var resolveSafraTipoButtonTypes = function () {
            $scope.safraTipoGeralButtonType = $scope.safraTipoGeral ? 'success' : 'normal';
            $scope.safraTipoAButtonType = $scope.safraTipoA ? 'success' : 'normal';
            $scope.safraTipoBButtonType = $scope.safraTipoB ? 'success' : 'normal';
        };

        var resolvetitleChartSafra = function () {
            var titleBase = "Produção de Etanol Safra";

            var titleTipoGeral = $scope.safraTipoGeral ? " TOTAL": "";
            var titleTipoA = $scope.safraTipoA ? " Anidro": "";
            var titleTipoB = $scope.safraTipoB ? " Hidratado": "";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.safraValAcumulados ? " - Acumulado": "";

            var titleTipo = titleBase + titleTipoGeral + titleTipoA +titleTipoB;
            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleTipo +titleVal;

            $scope.titleChartSafra = title; // + " " +$scope.visaoGeralSafraDisplay;
        };


        var dsChartSafraValoresPontuais = function () {
            if ($scope.safraTipoGeral) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrafico }
            if ($scope.safraTipoA) { return $scope.dadosTipoA[0].oGrafico }
            if ($scope.safraTipoB) { return $scope.dadosTipoB[0].oGrafico }
        };

        var dsChartSafraValoresAcumulados = function () {
            if ($scope.safraTipoGeral) { return $scope.dadosTipoAb[0].oGraficoAcumulado }
            if ($scope.safraTipoA) { return $scope.dadosTipoA[0].oGraficoAcumulado }
            if ($scope.safraTipoB) { return $scope.dadosTipoB[0].oGraficoAcumulado }
        };


        var dsChartSafraTipoGeral = function () {
            if ($scope.safraValPontuais) { return $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrafico }
            if ($scope.safraValAcumulados) { return $scope.dadosTipoAb[0].oGraficoAcumulado }
        };

        var dsChartSafraTipoA = function () {
            if ($scope.safraValPontuais) { return $scope.dadosTipoA[0].oGrafico }
            if ($scope.safraValAcumulados) { return $scope.dadosTipoA[0].oGraficoAcumulado }
        };

        var dsChartSafraTipoB = function () {
            if ($scope.safraValPontuais) { return $scope.dadosTipoB[0].oGrafico }
            if ($scope.safraValAcumulados) { return $scope.dadosTipoB[0].oGraficoAcumulado }
        };


        $scope.$watch('safraValPontuais', function () {
            if ($scope.safraValPontuais) {
                $scope.safraValAcumulados = false;

                resolveSafraValButtonTypes();

                $scope.dsChartSafra = dsChartSafraValoresPontuais();
                resolvetitleChartSafra();
            };
        });

        $scope.$watch('safraValAcumulados', function () {
            if ($scope.safraValAcumulados) {
                $scope.safraValPontuais = false;

                resolveSafraValButtonTypes();

                $scope.dsChartSafra = dsChartSafraValoresAcumulados();
                resolvetitleChartSafra();
            };
        });

        $scope.$watch('safraTipoGeral', function () {
            if ($scope.safraTipoGeral) {
                $scope.safraTipoA = false;
                $scope.safraTipoB = false;

                resolveSafraTipoButtonTypes();

                $scope.dsChartSafra = dsChartSafraTipoGeral();
                resolvetitleChartSafra();

                $scope.dsGridSafra = $scope.dadosTipoAb[0] && $scope.dadosTipoAb[0].oGrid;
            };
        });

        $scope.$watch('safraTipoA', function () {
            if ($scope.safraTipoA) {
                $scope.safraTipoGeral = false;
                $scope.safraTipoB = false;

                resolveSafraTipoButtonTypes();

                $scope.dsChartSafra = dsChartSafraTipoA();
                resolvetitleChartSafra();

                $scope.dsGridSafra = $scope.dadosTipoA[0].oGrid;
            };
        });

        $scope.$watch('safraTipoB', function () {
            if ($scope.safraTipoB) {
                $scope.safraTipoGeral = false;
                $scope.safraTipoA = false;

                resolveSafraTipoButtonTypes();

                $scope.dsChartSafra = dsChartSafraTipoB();
                resolvetitleChartSafra();

                $scope.dsGridSafra = $scope.dadosTipoB[0].oGrid;
            };
        });

        //Safra
        $scope.dsChartSafra = {};

        $scope.safraValPontuais = true;
        $scope.safraValAcumulados = false;
        resolveSafraValButtonTypes();

        $scope.safraTipoGeral = true;
        $scope.safraTipoA = false;
        $scope.safraTipoB = false;
        resolveSafraTipoButtonTypes();

        resolvetitleChartSafra();


        $scope.dadosTipoAb = {};
        $scope.dadosTipoA = {};
        $scope.dadosTipoB = {};

        $scope.autoRefreshButtonType = !window.localStorage.getItem("bi4tInd05ar") || window.localStorage.getItem("bi4tInd05ar") == 0 ? 'success' : 'normal';

        angular.element(document).ready(function() {
            //ORDEM: 2 - Document Ready Angular

            Globalize.culture("pt-BR");

            $scope.fromHome = Boolean(getUrlParameter('periodo'));
            $scope.filtroPeriodo = getUrlParameter('periodo');

            $scope.homeButtonVisible = $scope.fromHome;

            refreshAll();

            $scope.interval = null;

            if (!window.localStorage.getItem("bi4tInd05ar")) {
                window.localStorage.setItem("bi4tInd05ar", 0);
                window.localStorage.setItem("bi4tInd05arsec", 60);
            };

            $scope.autoRefresh = (window.localStorage.getItem("bi4tInd05ar") == 0);
            $scope.autoRefreshSeconds = window.localStorage.getItem("bi4tInd05arsec");

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

                window.localStorage.setItem("bi4tInd05ar", $scope.autoRefresh ? 0 : 1);
                window.localStorage.setItem("bi4tInd05arsec", $scope.autoRefreshSeconds);

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
                $scope.dsGridDiaProjecao = {};

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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " m³"; }
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

            var columns = columnsBase;

            for (var i = 0; i < dataGrafico.length; i++) {
                columns.push({
                    dataField: "H" + dataGrafico[i].HORA + "_DISP",
                    caption: dataGrafico[i].HORA,
                    dataType: "string",
                    alignment: "center"
                });
            }

            return columns;
        };

        function diaClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaEtanolPorDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia)
                .then(function (data) {

                    for (var i = 0; i < data.length; i++) {
                        for (var j = 0; j < data[i].oGrid.length; j++) {
                            $.extend(data[i].oGrid[j],
                                {
                                    H00_DISP: gridDiaCellDisplay(data[i].oGrid[j].H00, data[i].oGrid[j].Hora),
                                    H01_DISP: gridDiaCellDisplay(data[i].oGrid[j].H01, data[i].oGrid[j].Hora),
                                    H02_DISP: gridDiaCellDisplay(data[i].oGrid[j].H02, data[i].oGrid[j].Hora),
                                    H03_DISP: gridDiaCellDisplay(data[i].oGrid[j].H03, data[i].oGrid[j].Hora),
                                    H04_DISP: gridDiaCellDisplay(data[i].oGrid[j].H04, data[i].oGrid[j].Hora),
                                    H05_DISP: gridDiaCellDisplay(data[i].oGrid[j].H05, data[i].oGrid[j].Hora),
                                    H06_DISP: gridDiaCellDisplay(data[i].oGrid[j].H06, data[i].oGrid[j].Hora),
                                    H07_DISP: gridDiaCellDisplay(data[i].oGrid[j].H07, data[i].oGrid[j].Hora),
                                    H08_DISP: gridDiaCellDisplay(data[i].oGrid[j].H08, data[i].oGrid[j].Hora),
                                    H09_DISP: gridDiaCellDisplay(data[i].oGrid[j].H09, data[i].oGrid[j].Hora),
                                    H10_DISP: gridDiaCellDisplay(data[i].oGrid[j].H10, data[i].oGrid[j].Hora),
                                    H11_DISP: gridDiaCellDisplay(data[i].oGrid[j].H11, data[i].oGrid[j].Hora),
                                    H12_DISP: gridDiaCellDisplay(data[i].oGrid[j].H12, data[i].oGrid[j].Hora),
                                    H13_DISP: gridDiaCellDisplay(data[i].oGrid[j].H13, data[i].oGrid[j].Hora),
                                    H14_DISP: gridDiaCellDisplay(data[i].oGrid[j].H14, data[i].oGrid[j].Hora),
                                    H15_DISP: gridDiaCellDisplay(data[i].oGrid[j].H15, data[i].oGrid[j].Hora),
                                    H16_DISP: gridDiaCellDisplay(data[i].oGrid[j].H16, data[i].oGrid[j].Hora),
                                    H17_DISP: gridDiaCellDisplay(data[i].oGrid[j].H17, data[i].oGrid[j].Hora),
                                    H18_DISP: gridDiaCellDisplay(data[i].oGrid[j].H18, data[i].oGrid[j].Hora),
                                    H19_DISP: gridDiaCellDisplay(data[i].oGrid[j].H19, data[i].oGrid[j].Hora),
                                    H20_DISP: gridDiaCellDisplay(data[i].oGrid[j].H20, data[i].oGrid[j].Hora),
                                    H21_DISP: gridDiaCellDisplay(data[i].oGrid[j].H21, data[i].oGrid[j].Hora),
                                    H22_DISP: gridDiaCellDisplay(data[i].oGrid[j].H22, data[i].oGrid[j].Hora),
                                    H23_DISP: gridDiaCellDisplay(data[i].oGrid[j].H23, data[i].oGrid[j].Hora)
                                });
                        };
                    };


                    $scope.dadosTipoAb = $.grep(data, function (e) { return e.tipo == 'AB'; });
                    $scope.dadosTipoA = $.grep(data, function (e) { return e.tipo == 'A'; });
                    $scope.dadosTipoB = $.grep(data, function (e) { return e.tipo == 'B'; });

                    $scope.dsChartDia = $scope.diaValPontuais ? dsChartDiaValoresPontuais() : dsChartDiaValoresAcumulados();
                    $scope.dsGridDia = $scope.diaTipoGeral ? $scope.dadosTipoAb[0].oGrid : $scope.diaTipoA ? $scope.dadosTipoA[0].oGrid : $scope.dadosTipoB[0].oGrid;

                    $scope.gridDiaColumns = gridDiaColumns($scope.dsChartDia);

                    $scope.mediaHoraAnterior = parseFloat($scope.diaTipoGeral ? $scope.dadosTipoAb[0].MediaHoraAnterior : $scope.diaTipoA ? $scope.dadosTipoA[0].MediaHoraAnterior : $scope.dadosTipoB[0].MediaHoraAnterior).toLocaleString() + " m³";

                    resolvetitleChartDia();

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

        $scope.gridDiaProjecaoOptions = {
            bindingOptions : {
                dataSource: 'dsGridDiaProjecao',
                columns: 'gridDiaProjecaoColumns'
            },
            columnAutoWidth: false,
            showBorders: true,
            showRowLines: true,
            loadPanel: {
                text: "Carregando..."
            },
            noDataText: "Não há dados",
            width: 350,
            onCellPrepared: function (info) {
                if (info.rowType == 'header' || info.columnIndex <= 0) {
                    info.cellElement.css('font-weight', 'bold');
                    info.cellElement.css('color', 'black');
                };

                if (info.rowType == 'data' && info.column.dataField == 'Projecao') {
                    if (info.data.Projecao < info.data.Meta) {
                        info.cellElement.css('background-color', '#FFFF66');
                    }
                };
            },
            onContentReady: function (e) {
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " m³"; }
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

            var columns = columnsBase;

            for (var i = 0; i < dataGrafico.length; i++) {
                columns.push({
                    dataField: "DIA" + (i + 1) + "_DISP",
                    caption: pureDate(dataGrafico[i].DIA).ddmmyyyy(),
                    dataType: "string",
                    alignment: "center"
                });
            }

            return columns;
        };

        function semanaClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaEtanolPorSemanaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralSemana)
                .then(function (data) {

                    for (var i = 0; i < data.length; i++) {
                        for (var j = 0; j < data[i].oGrid.length; j++) {
                            $.extend(data[i].oGrid[j],
                                {
                                    DIA1_DISP: gridSemanaCellDisplay(data[i].oGrid[j].DIA1, data[i].oGrid[j].Hora),
                                    DIA2_DISP: gridSemanaCellDisplay(data[i].oGrid[j].DIA2, data[i].oGrid[j].Hora),
                                    DIA3_DISP: gridSemanaCellDisplay(data[i].oGrid[j].DIA3, data[i].oGrid[j].Hora),
                                    DIA4_DISP: gridSemanaCellDisplay(data[i].oGrid[j].DIA4, data[i].oGrid[j].Hora),
                                    DIA5_DISP: gridSemanaCellDisplay(data[i].oGrid[j].DIA5, data[i].oGrid[j].Hora),
                                    DIA6_DISP: gridSemanaCellDisplay(data[i].oGrid[j].DIA6, data[i].oGrid[j].Hora),
                                    DIA7_DISP: gridSemanaCellDisplay(data[i].oGrid[j].DIA7, data[i].oGrid[j].Hora)
                                });
                        };
                    };

                    $scope.dadosTipoAb = $.grep(data, function (e) { return e.tipo == 'AB'; });
                    $scope.dadosTipoA = $.grep(data, function (e) { return e.tipo == 'A'; });
                    $scope.dadosTipoB = $.grep(data, function (e) { return e.tipo == 'B'; });

                    $scope.dsChartSemana = $scope.semanaValPontuais ? dsChartSemanaValoresPontuais() : dsChartSemanaValoresAcumulados();
                    $scope.dsGridSemana = $scope.semanaTipoGeral ? $scope.dadosTipoAb[0].oGrid : $scope.semanaTipoA ? $scope.dadosTipoA[0].oGrid : $scope.dadosTipoB[0].oGrid;
                    $scope.dsGridSemanaProjecao = $scope.semanaTipoGeral ? $scope.dadosTipoAb[0].oGridProjecao : $scope.semanaTipoA ? $scope.dadosTipoA[0].oGridProjecao : $scope.dadosTipoB[0].oGridProjecao;

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

        $scope.gridSemanaProjecaoOptions = {
            bindingOptions: {
                dataSource: 'dsGridSemanaProjecao'
            },
            columnAutoWidth: false,
            showBorders: true,
            showRowLines: true,
            loadPanel: {
                text: "Carregando..."
            },
            noDataText: "Não há dados",
            width: 350
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " m³"; }
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

            var columns = columnsBase;

            for (var i = 0; i < dataGrafico.length; i++) {
                columns.push({
                    dataField: "SEMANA" + (i + 1) + "_DISP",
                    caption: pureDate(dataGrafico[i].semanaPeriodo.diaInicio).ddmmyyyy() + ' a ' + pureDate(dataGrafico[i].semanaPeriodo.diaFim).ddmmyyyy(),
                    dataType: "string",
                    alignment: "center"
                });
            }

            return columns;
        };

        function mesClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaEtanolPorMesPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralMes)
                .then(function (data) {

                    for (var i = 0; i < data.length; i++) {
                        for (var j = 0; j < data[i].oGrid.length; j++) {
                            $.extend(data[i].oGrid[j],
                                {
                                    SEMANA1_DISP: gridMesCellDisplay(data[i].oGrid[j].SEMANA1, data[i].oGrid[j].Hora),
                                    SEMANA2_DISP: gridMesCellDisplay(data[i].oGrid[j].SEMANA2, data[i].oGrid[j].Hora),
                                    SEMANA3_DISP: gridMesCellDisplay(data[i].oGrid[j].SEMANA3, data[i].oGrid[j].Hora),
                                    SEMANA4_DISP: gridMesCellDisplay(data[i].oGrid[j].SEMANA4, data[i].oGrid[j].Hora),
                                    SEMANA5_DISP: gridMesCellDisplay(data[i].oGrid[j].SEMANA5, data[i].oGrid[j].Hora),
                                    SEMANA6_DISP: gridMesCellDisplay(data[i].oGrid[j].SEMANA6, data[i].oGrid[j].Hora)
                                });
                        };
                    };

                    $scope.dadosTipoAb = $.grep(data, function (e) { return e.tipo == 'AB'; });
                    $scope.dadosTipoA = $.grep(data, function (e) { return e.tipo == 'A'; });
                    $scope.dadosTipoB = $.grep(data, function (e) { return e.tipo == 'B'; });

                    $scope.dsChartMes = $scope.mesValPontuais ? datasourceDadosMes(dsChartMesValoresPontuais()) : datasourceDadosMes(dsChartMesValoresAcumulados());
                    $scope.dsGridMes = $scope.mesTipoGeral ? $scope.dadosTipoAb[0].oGrid : $scope.mesTipoA ? $scope.dadosTipoA[0].oGrid : $scope.dadosTipoB[0].oGrid;

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
                    customizeText: function() { return parseFloat(this.valueText).toLocaleString() + " m³"; }
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

            var columns = columnsBase;

            for (var i = 0; i < dataGrafico.length; i++) {
                columns.push({
                    dataField: "MES" + dataGrafico[i].MES + "_DISP",
                    caption: mesNome(dataGrafico[i].MES),
                    dataType: "string",
                    alignment: "center"
                });
            }

            return columns;
        };


        function safraClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaEtanolPorSafraCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia)
                .then(function (data) {

                    for (var i = 0; i < data.length; i++) {
                        for (var j = 0; j < data[i].oGrid.length; j++) {
                            $.extend(data[i].oGrid[j],
                                {
                                    MES1_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES1, data[i].oGrid[j].Hora),
                                    MES2_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES2, data[i].oGrid[j].Hora),
                                    MES3_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES3, data[i].oGrid[j].Hora),
                                    MES4_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES4, data[i].oGrid[j].Hora),
                                    MES5_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES5, data[i].oGrid[j].Hora),
                                    MES6_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES6, data[i].oGrid[j].Hora),
                                    MES7_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES7, data[i].oGrid[j].Hora),
                                    MES8_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES8, data[i].oGrid[j].Hora),
                                    MES9_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES9, data[i].oGrid[j].Hora),
                                    MES10_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES10, data[i].oGrid[j].Hora),
                                    MES11_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES11, data[i].oGrid[j].Hora),
                                    MES12_DISP: gridSafraCellDisplay(data[i].oGrid[j].MES12, data[i].oGrid[j].Hora)
                                });
                        };
                    };

                    $scope.dadosTipoAb = $.grep(data, function (e) { return e.tipo == 'AB'; });
                    $scope.dadosTipoA = $.grep(data, function (e) { return e.tipo == 'A'; });
                    $scope.dadosTipoB = $.grep(data, function (e) { return e.tipo == 'B'; });

                    $scope.dsChartSafra = $scope.safraValPontuais ? dsChartSafraValoresPontuais() : dsChartSafraValoresAcumulados();
                    $scope.dsGridSafra = $scope.safraTipoGeral ? $scope.dadosTipoAb[0].oGrid : $scope.safraTipoA ? $scope.dadosTipoA[0].oGrid : $scope.dadosTipoB[0].oGrid;

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


        $scope.buttonDiaTipoGeralOptions = {
            text: 'Anidro + Hidratado',
            bindingOptions: {
                type: 'diaTipoGeralButtonType'
            },
            onClick: function () {
                $scope.diaTipoGeral = true;
            }
        };

        $scope.buttonDiaTipoAOptions = {
            text: 'Anidro',
            bindingOptions: {
                type: 'diaTipoAButtonType'
            },
            onClick: function () {
                $scope.diaTipoA = true;

            }
        };

        $scope.buttonDiaTipoBOptions = {
            text: 'Hidratado',
            bindingOptions: {
                type: 'diaTipoBButtonType'
            },
            onClick: function () {
                $scope.diaTipoB = true;

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


        $scope.buttonSemanaTipoGeralOptions = {
            text: 'Anidro + Hidratado',
            bindingOptions: {
                type: 'semanaTipoGeralButtonType'
            },
            onClick: function () {
                $scope.semanaTipoGeral = true;
            }
        };

        $scope.buttonSemanaTipoAOptions = {
            text: 'Anidro',
            bindingOptions: {
                type: 'semanaTipoAButtonType'
            },
            onClick: function () {
                $scope.semanaTipoA = true;
            }
        };

        $scope.buttonSemanaTipoBOptions = {
            text: 'Hidratado',
            bindingOptions: {
                type: 'semanaTipoBButtonType'
            },
            onClick: function () {
                $scope.semanaTipoB = true;
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

        $scope.buttonMesTipoGeralOptions = {
            text: 'Anidro + Hidratado',
            bindingOptions: {
                type: 'mesTipoGeralButtonType'
            },
            onClick: function () {
                $scope.mesTipoGeral = true;
            }
        };

        $scope.buttonMesTipoAOptions = {
            text: 'Anidro',
            bindingOptions: {
                type: 'mesTipoAButtonType'
            },
            onClick: function () {
                $scope.mesTipoA = true;
            }
        };

        $scope.buttonMesTipoBOptions = {
            text: 'Hidratado',
            bindingOptions: {
                type: 'mesTipoBButtonType'
            },
            onClick: function () {
                $scope.mesTipoB = true;

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

        $scope.buttonSafraTipoGeralOptions = {
            text: 'Anidro + Hidratado',
            bindingOptions: {
                type: 'safraTipoGeralButtonType'
            },
            onClick: function () {
                $scope.safraTipoGeral = true;
            }
        };

        $scope.buttonSafraTipoAOptions = {
            text: 'Anidro',
            bindingOptions: {
                type: 'safraTipoAButtonType'
            },
            onClick: function () {
                $scope.safraTipoA = true;
            }
        };

        $scope.buttonSafraTipoBOptions = {
            text: 'Hidratado',
            bindingOptions: {
                type: 'safraTipoBButtonType'
            },
            onClick: function () {
                $scope.safraTipoB = true;
            }
        };
    };
})();