/*! 
* Autor: Renato Ferreira Xavier
* Data: março/2018
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

    angular.module('app4T')
        .controller("industriamoagemCtrl", ['$scope', '$document', 'ApiGetService', industriamoagemCtrl]);

    function industriamoagemCtrl($scope, $document, ApiGetService) {
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

        function refreshAll(semLatest) {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaMoagemVisaoGeralMinMaxDiaPromise(1, 2018)
                .then(function (data) {
                    if (!semLatest) {
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
                            .getindustriaMoagemVisaoGeralCorteDiaPromise(1, 2018, new Date($scope.visaoGeralDiaDate).yyyymmdd())
                            .then(function (data) {
                                //Dia
                                $scope.chartVisaoGeralDiaDataSource.store().clear();

                                $scope.chartVisaoGeralDiaDataSource.store().insert({
                                    arg: "DIA",
                                    val: data.DiaValMoagem
                                });

                                $scope.chartVisaoGeralDiaDataSource.load();

                                $scope.visaoGeralDiaDate = pureDate(data.Dia);
                                $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();
                                $scope.visaoGeralDiaDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();
                                $scope.visaoGeralHora = data.Hora;

                                $scope.visaoGeralDiaValMoagem = data.DiaValMoagem;
                                $scope.visaoGeralDiaValMoagemMax = data.DiaValMoagemMax;
                                $scope.visaoGeralDiaIndicadorMeta = data.DiaIndicadorMeta;
                                $scope.visaoGeralDiaIndicadorMetaColor = coresMetaArray[data.DiaIndicadorMeta];

                                //Semana
                                $scope.chartVisaoGeralSemanaDataSource.store().clear();

                                $scope.chartVisaoGeralSemanaDataSource.store().insert({
                                    arg: "SEMANA",
                                    val: data.SemanaValMoagem
                                });

                                $scope.chartVisaoGeralSemanaDataSource.load();

                                $scope.visaoGeralSemana = data.Semana;
                                $scope.visaoGeralSemanaValMoagem = data.SemanaValMoagem;
                                $scope.visaoGeralSemanaValMoagemMax = data.SemanaValMoagemMax;
                                $scope.visaoGeralSemanaIndicadorMeta = data.SemanaIndicadorMeta;
                                $scope.visaoGeralSemanaIndicadorMetaColor = coresMetaArray[data.SemanaIndicadorMeta];

                                //Mes
                                $scope.chartVisaoGeralMesDataSource.store().clear();

                                $scope.chartVisaoGeralMesDataSource.store().insert({
                                    arg: "MÊS",
                                    val: data.MesValMoagem
                                });

                                $scope.chartVisaoGeralMesDataSource.load();

                                $scope.visaoGeralMes = data.Mes;
                                $scope.visaoGeralMesValMoagem = data.MesValMoagem;
                                $scope.visaoGeralMesValMoagemMax = data.MesValMoagemMax;
                                $scope.visaoGeralMesIndicadorMeta = data.MesIndicadorMeta;
                                $scope.visaoGeralMesIndicadorMetaColor = coresMetaArray[data.MesIndicadorMeta];

                                //Safra
                                $scope.chartVisaoGeralSafraDataSource.store().clear();

                                $scope.chartVisaoGeralSafraDataSource.store().insert({
                                    arg: "SAFRA",
                                    val: data.SafraValMoagem
                                });

                                $scope.chartVisaoGeralSafraDataSource.load();

                                $scope.visaoGeralSafra = data.Safra;
                                $scope.visaoGeralSafraValMoagem = data.SafraValMoagem;
                                $scope.visaoGeralSafraValMoagemMax = data.SafraValMoagemMax;
                                $scope.visaoGeralSafraIndicadorMeta = data.SafraIndicadorMeta;
                                $scope.visaoGeralSafraIndicadorMetaColor = coresMetaArray[data.SafraIndicadorMeta];

                                $scope.loadingVisible = false;
                            });
                    } else if ($scope.filtroPeriodoDia()) {
                        diaClick();
                    } else if ($scope.filtroPeriodoSemana()) {
                        semanaClick();
                    } else if ($scope.filtroPeriodoMes()) {
                        mesClick();
                    } else if ($scope.filtroPeriodoSafra()) {
                        safraClick();
                    }
                });
        };

        $scope.$watch('filtroPeriodo', function() {
            $scope.visaoGeralButtonVisible = !($scope.filtroPeriodo == "");
        });

        //Visão Geral
        $scope.chartVisaoGeralDiaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartVisaoGeralSemanaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartVisaoGeralMesDataSource = new DevExpress.data.DataSource([]);
        $scope.chartVisaoGeralSafraDataSource = new DevExpress.data.DataSource([]);

        //$scope.visaoGeralDiaMinDate = new Date(2018, 1, 1);
        //$scope.visaoGeralDiaMaxDate = new Date();
        //$scope.visaoGeralDiaDate = new Date();
        $scope.visiblePopup = false;

        $scope.visaoGeralDia = "";
        $scope.visaoGeralDiaDisplay = "";
        $scope.visaoGeralHora = "00";
        $scope.visaoGeralHoraAnterior = function () { return ("00" + ($scope.visaoGeralHora - 1)).slice(-2); };

        $scope.visaoGeralDiaValMoagem = 0;
        $scope.visaoGeralDiaValMoagemMax = 0;
        $scope.visaoGeralDiaIndicadorMeta = 0;
        $scope.visaoGeralDiaIndicadorMetaColor = "";

        $scope.visaoGeralSemana = 0;
        $scope.visaoGeralSemanaValMoagem = 0;
        $scope.visaoGeralSemanaValMoagemMax = 0;
        $scope.visaoGeralSemanaIndicadorMeta = 0;
        $scope.visaoGeralSemanaIndicadorMetaColor = "";

        $scope.visaoGeralMes = 0;
        $scope.visaoGeralMesValMoagem = 0;
        $scope.visaoGeralMesValMoagemMax = 0;
        $scope.visaoGeralMesIndicadorMeta = 0;
        $scope.visaoGeralMesIndicadorMetaColor = "";

        $scope.visaoGeralSafra = 0;
        $scope.visaoGeralSafraValMoagem = 0;
        $scope.visaoGeralSafraValMoagemMax = 0;
        $scope.visaoGeralSafraIndicadorMeta = 0;
        $scope.visaoGeralSafraIndicadorMetaColor = "";

        //Dia Buttons
        var resolveDiaValButtonTypes = function () {
            $scope.diaValPontuaisButtonType = $scope.diaValPontuais ? 'success' : 'normal';
            $scope.diaValAcumuladosButtonType = $scope.diaValAcumulados ? 'success' : 'normal';
        };

        var resolveDiaMoendaButtonTypes = function () {
            $scope.diaMoendaGeralButtonType = $scope.diaMoendaGeral ? 'success' : 'normal';
            $scope.diaMoendaAButtonType = $scope.diaMoendaA ? 'success' : 'normal';
            $scope.diaMoendaBButtonType = $scope.diaMoendaB ? 'success' : 'normal';
        };

        var resolvetitleChartDia = function () {
            var titleBase = "Plano de Moagem Diário";

            var titleMoendaGeral = $scope.diaMoendaGeral ? " TOTAL" : "";
            var titleMoendaA = $scope.diaMoendaA ? " Moenda A" : "";
            var titleMoendaB = $scope.diaMoendaB ? " Moenda B" : "";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.diaValAcumulados ? " - Acumulado" : "";

            var titleMoenda = titleBase + titleMoendaGeral + titleMoendaA + titleMoendaB;
            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleMoenda + titleVal;

            $scope.titleChartDia = title + " " + $scope.visaoGeralDiaDisplay;
        };


        var dsChartDiaValoresPontuais = function () {
            if ($scope.diaMoendaGeral) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagem }
            if ($scope.diaMoendaA) { return $scope.dadosMoendaA[0].oGraficoMoagem }
            if ($scope.diaMoendaB) { return $scope.dadosMoendaB[0].oGraficoMoagem }
        };

        var dsChartDiaValoresAcumulados = function () {
            if ($scope.diaMoendaGeral) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagemAcumulado }
            if ($scope.diaMoendaA) { return $scope.dadosMoendaA[0].oGraficoMoagemAcumulado }
            if ($scope.diaMoendaB) { return $scope.dadosMoendaB[0].oGraficoMoagemAcumulado }
        };


        var dsChartDiaMoendaGeral = function () {
            if ($scope.diaValPontuais) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagem }
            if ($scope.diaValAcumulados) { return $scope.dadosMoendaAb[0].oGraficoMoagemAcumulado }
        };

        var dsChartDiaMoendaA = function () {
            if ($scope.diaValPontuais) { return $scope.dadosMoendaA[0] && $scope.dadosMoendaA[0].oGraficoMoagem }
            if ($scope.diaValAcumulados) { return $scope.dadosMoendaA[0].oGraficoMoagemAcumulado }
        };

        var dsChartDiaMoendaB = function () {
            if ($scope.diaValPontuais) { return $scope.dadosMoendaB[0] && $scope.dadosMoendaB[0].oGraficoMoagem }
            if ($scope.diaValAcumulados) { return $scope.dadosMoendaB[0].oGraficoMoagemAcumulado }
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

        $scope.$watch('diaMoendaGeral', function () {
            if ($scope.diaMoendaGeral) {
                $scope.diaMoendaA = false;
                $scope.diaMoendaB = false;

                resolveDiaMoendaButtonTypes();

                $scope.dsChartDia = dsChartDiaMoendaGeral();
                resolvetitleChartDia();

                $scope.dsGridDia = $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGridMoagem;
                $scope.dsGridDiaProjecao = $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGridMoagemProjecao;
                $scope.passoDia = $scope.dadosMoendaAb[0] && parseFloat($scope.dadosMoendaAb[0].Passo).toLocaleString() + " ton/h";
                $scope.mediaMoagemHoraAnterior = $scope.dadosMoendaAb[0] && parseFloat($scope.dadosMoendaAb[0].MediaMoagemHoraAnterior).toLocaleString() + " ton/h";
            };
        });

        $scope.$watch('diaMoendaA', function () {
            if ($scope.diaMoendaA) {
                $scope.diaMoendaGeral = false;
                $scope.diaMoendaB = false;

                resolveDiaMoendaButtonTypes();

                $scope.dsChartDia = dsChartDiaMoendaA();
                resolvetitleChartDia();

                $scope.dsGridDia = $scope.dadosMoendaA[0].oGridMoagem;
                $scope.dsGridDiaProjecao = $scope.dadosMoendaA[0].oGridMoagemProjecao;
                $scope.passoDia = parseFloat($scope.dadosMoendaA[0].Passo).toLocaleString() + " ton/h";
                $scope.mediaMoagemHoraAnterior = $scope.dadosMoendaA[0] && parseFloat($scope.dadosMoendaA[0].MediaMoagemHoraAnterior).toLocaleString() + " ton/h";
            };
        });

        $scope.$watch('diaMoendaB', function () {
            if ($scope.diaMoendaB) {
                $scope.diaMoendaGeral = false;
                $scope.diaMoendaA = false;

                resolveDiaMoendaButtonTypes();

                $scope.dsChartDia = dsChartDiaMoendaB();
                resolvetitleChartDia();

                $scope.dsGridDia = $scope.dadosMoendaB[0].oGridMoagem;
                $scope.dsGridDiaProjecao = $scope.dadosMoendaB[0].oGridMoagemProjecao;
                $scope.passoDia = parseFloat($scope.dadosMoendaB[0].Passo).toLocaleString() + " ton/h";
                $scope.mediaMoagemHoraAnterior = $scope.dadosMoendaB[0] && parseFloat($scope.dadosMoendaB[0].MediaMoagemHoraAnterior).toLocaleString() + " ton/h";
            };
        });

        //Dia
        $scope.dsChartDia = {};

        $scope.diaValPontuais = true;
        $scope.diaValAcumulados = false;
        resolveDiaValButtonTypes();

        $scope.diaMoendaGeral = true;
        $scope.diaMoendaA = false;
        $scope.diaMoendaB = false;
        resolveDiaMoendaButtonTypes();

        resolvetitleChartDia();

        $scope.dsGridDia = {};
        $scope.dsGridDiaProjecao = {};

        $scope.passoDia = "0";
        $scope.mediaMoagemHoraAnterior = "0";

        //Semana Buttons
        var resolveSemanaValButtonTypes = function () {
            $scope.semanaValPontuaisButtonType = $scope.semanaValPontuais ? 'success' : 'normal';
            $scope.semanaValAcumuladosButtonType = $scope.semanaValAcumulados ? 'success' : 'normal';
        };

        var resolveSemanaMoendaButtonTypes = function () {
            $scope.semanaMoendaGeralButtonType = $scope.semanaMoendaGeral ? 'success' : 'normal';
            $scope.semanaMoendaAButtonType = $scope.semanaMoendaA ? 'success' : 'normal';
            $scope.semanaMoendaBButtonType = $scope.semanaMoendaB ? 'success' : 'normal';
        };

        var resolvetitleChartSemana = function () {
            var titleBase = "Plano de Moagem Semanal";

            var titleMoendaGeral = $scope.semanaMoendaGeral ? " TOTAL" : "";
            var titleMoendaA = $scope.semanaMoendaA ? " Moenda A" : "";
            var titleMoendaB = $scope.semanaMoendaB ? " Moenda B" : "";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.semanaValAcumulados ? " - Acumulado" : "";

            var titleMoenda = titleBase + titleMoendaGeral + titleMoendaA + titleMoendaB;
            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleMoenda + titleVal;

            $scope.titleChartSemana = title; // + " " + $scope.visaoGeralSemana;
        };


        var dsChartSemanaValoresPontuais = function () {
            if($scope.semanaMoendaGeral) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagem }
            if ($scope.semanaMoendaA) { return $scope.dadosMoendaA[0].oGraficoMoagem }
            if ($scope.semanaMoendaB) { return $scope.dadosMoendaB[0].oGraficoMoagem }
        };

        var dsChartSemanaValoresAcumulados = function () {
            if ($scope.semanaMoendaGeral) {
                return $scope.dadosMoendaAb[0].oGraficoMoagemAcumulado
            }
            if ($scope.semanaMoendaA) {
                return $scope.dadosMoendaA[0].oGraficoMoagemAcumulado
            }
            if($scope.semanaMoendaB) { return $scope.dadosMoendaB[0].oGraficoMoagemAcumulado }
        };


        var dsChartSemanaMoendaGeral = function () {
            if ($scope.semanaValPontuais) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagem }
            if ($scope.semanaValAcumulados) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagemAcumulado }
        };

        var dsChartSemanaMoendaA = function () {
            if ($scope.semanaValPontuais) {
                return $scope.dadosMoendaA[0].oGraficoMoagem
            }
            if ($scope.semanaValAcumulados) {
                return $scope.dadosMoendaA[0].oGraficoMoagemAcumulado
            }
        };

        var dsChartSemanaMoendaB = function () {
            if($scope.semanaValPontuais) { return $scope.dadosMoendaB[0].oGraficoMoagem }
            if ($scope.semanaValAcumulados) { return $scope.dadosMoendaB[0].oGraficoMoagemAcumulado
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

        $scope.$watch('semanaMoendaGeral', function () {
            if ($scope.semanaMoendaGeral) {
                $scope.semanaMoendaA = false;
                $scope.semanaMoendaB = false;

                resolveSemanaMoendaButtonTypes();

                $scope.dsChartSemana = dsChartSemanaMoendaGeral();
                resolvetitleChartSemana();

                $scope.dsGridSemana = $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGridMoagem;
                $scope.dsGridSemanaProjecao = $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGridMoagemProjecao;
            };
        });

        $scope.$watch('semanaMoendaA', function () {
            if ($scope.semanaMoendaA) {
                $scope.semanaMoendaGeral = false;
                $scope.semanaMoendaB = false;

                resolveSemanaMoendaButtonTypes();

                $scope.dsChartSemana = dsChartSemanaMoendaA();
                resolvetitleChartSemana();

                $scope.dsGridSemana = $scope.dadosMoendaA[0].oGridMoagem;
                $scope.dsGridSemanaProjecao = $scope.dadosMoendaA[0].oGridMoagemProjecao;
            };
        });

        $scope.$watch('semanaMoendaB', function () {
            if ($scope.semanaMoendaB) {
                $scope.semanaMoendaGeral = false;
                $scope.semanaMoendaA = false;

                resolveSemanaMoendaButtonTypes();

                $scope.dsChartSemana = dsChartSemanaMoendaB();
                resolvetitleChartSemana();

                $scope.dsGridSemana = $scope.dadosMoendaB[0].oGridMoagem;
                $scope.dsGridSemanaProjecao = $scope.dadosMoendaB[0].oGridMoagemProjecao;
            };
        });

        //Semana
        $scope.dsChartSemana = {};

        $scope.semanaValPontuais = true;
        $scope.semanaValAcumulados = false;
        resolveSemanaValButtonTypes();

        $scope.semanaMoendaGeral = true;
        $scope.semanaMoendaA = false;
        $scope.semanaMoendaB = false;
        resolveSemanaMoendaButtonTypes();

        resolvetitleChartSemana();

        $scope.dsGridSemana = {};
        $scope.dsGridSemanaProjecao = {};


        //Mes Buttons
        var resolveMesValButtonTypes = function () {
            $scope.mesValPontuaisButtonType = $scope.mesValPontuais ? 'success' : 'normal';
            $scope.mesValAcumuladosButtonType = $scope.mesValAcumulados ? 'success' : 'normal';
        };

        var resolveMesMoendaButtonTypes = function () {
            $scope.mesMoendaGeralButtonType = $scope.mesMoendaGeral ? 'success' : 'normal';
            $scope.mesMoendaAButtonType = $scope.mesMoendaA ? 'success' : 'normal';
            $scope.mesMoendaBButtonType = $scope.mesMoendaB ? 'success' : 'normal';
        };

        var resolvetitleChartMes = function () {
            var titleBase = "Plano de Moagem Mensal";

            var titleMoendaGeral = $scope.mesMoendaGeral ? " TOTAL" : "";
            var titleMoendaA = $scope.mesMoendaA ? " Moenda A" : "";
            var titleMoendaB = $scope.mesMoendaB ? " Moenda B" : "";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.mesValAcumulados ? " - Acumulado" : "";

            var titleMoenda = titleBase + titleMoendaGeral + titleMoendaA + titleMoendaB;
            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleMoenda + titleVal;

            $scope.titleChartMes = title; // + " " + $scope.visaoGeralMesDisplay;
        };


        var dsChartMesValoresPontuais = function () {
            if ($scope.mesMoendaGeral) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagem }
            if ($scope.mesMoendaA) { return $scope.dadosMoendaA[0].oGraficoMoagem }
            if ($scope.mesMoendaB) { return $scope.dadosMoendaB[0].oGraficoMoagem }
        };

        var dsChartMesValoresAcumulados = function () {
            if ($scope.mesMoendaGeral) { return $scope.dadosMoendaAb[0].oGraficoMoagemAcumulado }
            if ($scope.mesMoendaA) { return $scope.dadosMoendaA[0].oGraficoMoagemAcumulado }
            if ($scope.mesMoendaB) { return $scope.dadosMoendaB[0].oGraficoMoagemAcumulado }
        };


        var dsChartMesMoendaGeral = function () {
            if ($scope.mesValPontuais) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagem }
            if ($scope.mesValAcumulados) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagemAcumulado }
        };

        var dsChartMesMoendaA = function () {
            if ($scope.mesValPontuais) { return $scope.dadosMoendaA[0].oGraficoMoagem }
            if ($scope.mesValAcumulados) { return $scope.dadosMoendaA[0].oGraficoMoagemAcumulado }
        };

        var dsChartMesMoendaB = function () {
            if ($scope.mesValPontuais) { return $scope.dadosMoendaB[0].oGraficoMoagem }
            if ($scope.mesValAcumulados) { return $scope.dadosMoendaB[0].oGraficoMoagemAcumulado }
        };


        $scope.$watch('mesValPontuais', function () {
            if ($scope.mesValPontuais) {
                $scope.mesValAcumulados = false;

                resolveMesValButtonTypes();

                $scope.dsChartMes = dsChartMesValoresPontuais();
                resolvetitleChartMes();
            };
        });

        $scope.$watch('mesValAcumulados', function () {
            if ($scope.mesValAcumulados) {
                $scope.mesValPontuais = false;

                resolveMesValButtonTypes();

                $scope.dsChartMes = dsChartMesValoresAcumulados();
                resolvetitleChartMes();
            };
        });

        $scope.$watch('mesMoendaGeral', function () {
            if ($scope.mesMoendaGeral) {
                $scope.mesMoendaA = false;
                $scope.mesMoendaB = false;

                resolveMesMoendaButtonTypes();

                $scope.dsChartMes = dsChartMesMoendaGeral();
                resolvetitleChartMes();

                $scope.dsGridMes = $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGridMoagem;
            };
        });

        $scope.$watch('mesMoendaA', function () {
            if ($scope.mesMoendaA) {
                $scope.mesMoendaGeral = false;
                $scope.mesMoendaB = false;

                resolveMesMoendaButtonTypes();

                $scope.dsChartMes = dsChartMesMoendaA();
                resolvetitleChartMes();

                $scope.dsGridMes = $scope.dadosMoendaA[0].oGridMoagem;
            };
        });

        $scope.$watch('mesMoendaB', function () {
            if ($scope.mesMoendaB) {
                $scope.mesMoendaGeral = false;
                $scope.mesMoendaA = false;

                resolveMesMoendaButtonTypes();
                
                $scope.dsChartMes = dsChartMesMoendaB();
                resolvetitleChartMes();

                $scope.dsGridMes = $scope.dadosMoendaB[0].oGridMoagem;
            };
        });

        //Mes
        $scope.dsChartMes = {};

        $scope.mesValPontuais = true;
        $scope.mesValAcumulados = false;
        resolveMesValButtonTypes();

        $scope.mesMoendaGeral = true;
        $scope.mesMoendaA = false;
        $scope.mesMoendaB = false;
        resolveMesMoendaButtonTypes();

        resolvetitleChartMes();


        //Safra Buttons
        var resolveSafraValButtonTypes = function () {
            $scope.safraValPontuaisButtonType = $scope.safraValPontuais ? 'success' : 'normal';
            $scope.safraValAcumuladosButtonType = $scope.safraValAcumulados ? 'success' : 'normal';
        };

        var resolveSafraMoendaButtonTypes = function () {
            $scope.safraMoendaGeralButtonType = $scope.safraMoendaGeral ? 'success' : 'normal';
            $scope.safraMoendaAButtonType = $scope.safraMoendaA ? 'success' : 'normal';
            $scope.safraMoendaBButtonType = $scope.safraMoendaB ? 'success' : 'normal';
        };

        var resolvetitleChartSafra = function () {
            var titleBase = "Plano de Moagem Safra";

            var titleMoendaGeral = $scope.safraMoendaGeral ? " TOTAL": "";
            var titleMoendaA = $scope.safraMoendaA ? " Moenda A": "";
            var titleMoendaB = $scope.safraMoendaB ? " Moenda B": "";

            var titleValPontuais = "";
            var titleValAcumulados = $scope.safraValAcumulados ? " - Acumulado": "";

            var titleMoenda = titleBase + titleMoendaGeral + titleMoendaA +titleMoendaB;
            var titleVal = titleValPontuais + titleValAcumulados;

            var title = titleMoenda +titleVal;

            $scope.titleChartSafra = title; // + " " +$scope.visaoGeralSafraDisplay;
        };


        var dsChartSafraValoresPontuais = function () {
            if ($scope.safraMoendaGeral) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagem }
            if ($scope.safraMoendaA) { return $scope.dadosMoendaA[0].oGraficoMoagem }
            if ($scope.safraMoendaB) { return $scope.dadosMoendaB[0].oGraficoMoagem }
        };

        var dsChartSafraValoresAcumulados = function () {
            if ($scope.safraMoendaGeral) { return $scope.dadosMoendaAb[0].oGraficoMoagemAcumulado }
            if ($scope.safraMoendaA) { return $scope.dadosMoendaA[0].oGraficoMoagemAcumulado }
            if ($scope.safraMoendaB) { return $scope.dadosMoendaB[0].oGraficoMoagemAcumulado }
        };


        var dsChartSafraMoendaGeral = function () {
            if ($scope.safraValPontuais) { return $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGraficoMoagem }
            if ($scope.safraValAcumulados) { return $scope.dadosMoendaAb[0].oGraficoMoagemAcumulado }
        };

        var dsChartSafraMoendaA = function () {
            if ($scope.safraValPontuais) { return $scope.dadosMoendaA[0].oGraficoMoagem }
            if ($scope.safraValAcumulados) { return $scope.dadosMoendaA[0].oGraficoMoagemAcumulado }
        };

        var dsChartSafraMoendaB = function () {
            if ($scope.safraValPontuais) { return $scope.dadosMoendaB[0].oGraficoMoagem }
            if ($scope.safraValAcumulados) { return $scope.dadosMoendaB[0].oGraficoMoagemAcumulado }
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

        $scope.$watch('safraMoendaGeral', function () {
            if ($scope.safraMoendaGeral) {
                $scope.safraMoendaA = false;
                $scope.safraMoendaB = false;

                resolveSafraMoendaButtonTypes();

                $scope.dsChartSafra = dsChartSafraMoendaGeral();
                resolvetitleChartSafra();

                $scope.dsGridSafra = $scope.dadosMoendaAb[0] && $scope.dadosMoendaAb[0].oGridMoagem;
            };
        });

        $scope.$watch('safraMoendaA', function () {
            if ($scope.safraMoendaA) {
                $scope.safraMoendaGeral = false;
                $scope.safraMoendaB = false;

                resolveSafraMoendaButtonTypes();

                $scope.dsChartSafra = dsChartSafraMoendaA();
                resolvetitleChartSafra();

                $scope.dsGridSafra = $scope.dadosMoendaA[0].oGridMoagem;
            };
        });

        $scope.$watch('safraMoendaB', function () {
            if ($scope.safraMoendaB) {
                $scope.safraMoendaGeral = false;
                $scope.safraMoendaA = false;

                resolveSafraMoendaButtonTypes();

                $scope.dsChartSafra = dsChartSafraMoendaB();
                resolvetitleChartSafra();

                $scope.dsGridSafra = $scope.dadosMoendaB[0].oGridMoagem;
            };
        });

        //Safra
        $scope.dsChartSafra = {};

        $scope.safraValPontuais = true;
        $scope.safraValAcumulados = false;
        resolveSafraValButtonTypes();

        $scope.safraMoendaGeral = true;
        $scope.safraMoendaA = false;
        $scope.safraMoendaB = false;
        resolveSafraMoendaButtonTypes();

        resolvetitleChartSafra();


        $scope.dadosMoendaAb = {};
        $scope.dadosMoendaA = {};
        $scope.dadosMoendaB = {};

        //$scope.autoRefresh = true;
        //$scope.autoRefreshSeconds = 10;
        //$scope.autoRefreshInterval = function () { return $scope.autoRefreshSeconds * 1000 }();

        //$scope.autoRefreshButtonIcon = function() { return $scope.autoRefresh ? 'check' : 'remove' }();
        //$scope.autoRefreshButtonType = function () { return $scope.autoRefresh ? 'success' : 'normal' }();
        $scope.autoRefreshButtonType = !window.localStorage.getItem("bi4tInd01ar") || window.localStorage.getItem("bi4tInd01ar") == 0 ? 'success' : 'normal';

        angular.element(document).ready(function() {
            //ORDEM: 2 - Document Ready Angular

            Globalize.culture("pt-BR");

            console.log(document.documentElement.clientHeight);
            console.log($scope.visaoGeral());

            refreshAll();

            $scope.interval = null;

            if (!window.localStorage.getItem("bi4tInd01ar")) {
                window.localStorage.setItem("bi4tInd01ar", 0);
                window.localStorage.setItem("bi4tInd01arsec", 60);
            };

            $scope.autoRefresh = (window.localStorage.getItem("bi4tInd01ar") == 0);
            $scope.autoRefreshSeconds = window.localStorage.getItem("bi4tInd01arsec");

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

                window.localStorage.setItem("bi4tInd01ar", $scope.autoRefresh ? 0 : 1);
                window.localStorage.setItem("bi4tInd01arsec", $scope.autoRefreshSeconds);

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
                visible: '!visaoGeralButtonVisible'
            },
            formatString: 'dd/MM/yyyy',
            readOnly: false,
            invalidDateMessage: 'Conteúdo deve ser uma data válida',
            dateOutOfRangeMessage: 'Data está fora do período',
            onValueChanged: function (e) {
                refreshAll(true);
                //$scope.loadingVisible = true;

                //ApiGetService
                //    .getindustriaMoagemVisaoGeralCorteDiaPromise(1, 2018, new Date(e.value).yyyymmdd())
                //    .then(function (data) {
                //        //Dia
                //        $scope.chartVisaoGeralDiaDataSource.store().clear();

                //        $scope.chartVisaoGeralDiaDataSource.store().insert({
                //            arg: "DIA",
                //            val: data.DiaValMoagem
                //        });

                //        $scope.chartVisaoGeralDiaDataSource.load();

                //        $scope.visaoGeralDiaDate = new Date(data.Dia);
                //        $scope.visaoGeralDia = new Date(data.Dia).yyyymmdd();
                //        $scope.visaoGeralDiaDisplay = new Date(data.Dia).ddmmyyyy();
                //        $scope.visaoGeralHora = data.Hora;
                //        $scope.titleChartDia = "Plano de Moagem Diário TOTAL " + $scope.visaoGeralDiaDisplay;

                //        $scope.visaoGeralDiaValMoagem = data.DiaValMoagem;
                //        $scope.visaoGeralDiaValMoagemMax = data.DiaValMoagemMax;
                //        $scope.visaoGeralDiaIndicadorMeta = data.DiaIndicadorMeta;
                //        $scope.visaoGeralDiaIndicadorMetaColor = coresMetaArray[data.DiaIndicadorMeta];


                //        //Semana
                //        $scope.chartVisaoGeralSemanaDataSource.store().clear();

                //        $scope.chartVisaoGeralSemanaDataSource.store().insert({
                //            arg: "SEMANA",
                //            val: data.SemanaValMoagem
                //        });

                //        $scope.chartVisaoGeralSemanaDataSource.load();

                //        $scope.visaoGeralSemana = data.Semana;
                //        $scope.visaoGeralSemanaValMoagem = data.SemanaValMoagem;
                //        $scope.visaoGeralSemanaValMoagemMax = data.SemanaValMoagemMax;
                //        $scope.visaoGeralSemanaIndicadorMeta = data.SemanaIndicadorMeta;
                //        $scope.visaoGeralSemanaIndicadorMetaColor = coresMetaArray[data.SemanaIndicadorMeta];

                //        //Mes
                //        $scope.chartVisaoGeralMesDataSource.store().clear();

                //        $scope.chartVisaoGeralMesDataSource.store().insert({
                //            arg: "MÊS",
                //            val: data.MesValMoagem
                //        });

                //        $scope.chartVisaoGeralMesDataSource.load();

                //        $scope.visaoGeralMes = data.Mes;
                //        $scope.visaoGeralMesValMoagem = data.MesValMoagem;
                //        $scope.visaoGeralMesValMoagemMax = data.MesValMoagemMax;
                //        $scope.visaoGeralMesIndicadorMeta = data.MesIndicadorMeta;
                //        $scope.visaoGeralMesIndicadorMetaColor = coresMetaArray[data.MesIndicadorMeta];

                //        //Safra
                //        $scope.chartVisaoGeralSafraDataSource.store().clear();

                //        $scope.chartVisaoGeralSafraDataSource.store().insert({
                //            arg: "SAFRA",
                //            val: data.SafraValMoagem
                //        });

                //        $scope.chartVisaoGeralSafraDataSource.load();

                //        $scope.visaoGeralSafra = data.Safra;
                //        $scope.visaoGeralSafraValMoagem = data.SafraValMoagem;
                //        $scope.visaoGeralSafraValMoagemMax = data.SafraValMoagemMax;
                //        $scope.visaoGeralSafraIndicadorMeta = data.SafraIndicadorMeta;
                //        $scope.visaoGeralSafraIndicadorMetaColor = coresMetaArray[data.SafraIndicadorMeta];

                //        $scope.loadingVisible = false;
                //    });
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
            series: {
                type: "bar"
            },
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " ton"; }
                }
            },
            bindingOptions: {
                'valueAxis.max': 'visaoGeralDiaValMoagemMax',
                'commonSeriesSettings.color': 'visaoGeralDiaIndicadorMetaColor'
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

        function diaClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaMoagemPorDiaPromise(1, 2018, $scope.visaoGeralDia)
                .then(function (data) {
                    $scope.dadosMoendaAb = $.grep(data, function (e) { return e.moenda == 'AB'; });
                    $scope.dadosMoendaA = $.grep(data, function (e) { return e.moenda == 'A'; });
                    $scope.dadosMoendaB = $.grep(data, function (e) { return e.moenda == 'B'; });

                    $scope.dsChartDia = $scope.diaValPontuais ? dsChartDiaValoresPontuais() : dsChartDiaValoresAcumulados();
                    $scope.dsGridDia = $scope.diaMoendaGeral ? $scope.dadosMoendaAb[0].oGridMoagem : $scope.diaMoendaA ? $scope.dadosMoendaA[0].oGridMoagem : $scope.dadosMoendaB[0].oGridMoagem;
                    $scope.dsGridDiaProjecao = $scope.diaMoendaGeral ? $scope.dadosMoendaAb[0].oGridMoagemProjecao : $scope.diaMoendaA ? $scope.dadosMoendaA[0].oGridMoagemProjecao : $scope.dadosMoendaB[0].oGridMoagemProjecao;

                    $scope.gridDiaProjecaoColumns = [
                        {
                            dataField: "ProjecaoHora",
                            caption: "Projeção Hora",
                            alignment: "center",
                            width: 188
                        }, {
                            dataField: "Projecao",
                            caption: "Projeção",
                            alignment: "right",
                            calculateCellValue: function (data) { return parseFloat(data.Projecao).toLocaleString() }
                        }, {
                            dataField: "Meta",
                            caption: "Meta",
                            dataType: "string",
                            alignment: "right",
                            calculateCellValue: function (data) { return parseFloat(data.Meta).toLocaleString() }
                        }
                    ];

                    $scope.passoDia = parseFloat($scope.diaMoendaGeral ? $scope.dadosMoendaAb[0].Passo : $scope.diaMoendaA ? $scope.dadosMoendaA[0].Passo : $scope.dadosMoendaB[0].Passo).toLocaleString() + " ton/h";
                    $scope.mediaMoagemHoraAnterior = parseFloat($scope.diaMoendaGeral ? $scope.dadosMoendaAb[0].MediaMoagemHoraAnterior : $scope.diaMoendaA ? $scope.dadosMoendaA[0].MediaMoagemHoraAnterior : $scope.dadosMoendaB[0].MediaMoagemHoraAnterior).toLocaleString() + " ton/h";

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
                dataSource: 'dsGridDia'
            },
            columns: [
                {
                    dataField: "Diario",
                    caption: "Diário",
                    alignment: "center",
                    width: 65
                }, {
                    dataField: "Hora",
                    caption: "Hora",
                    alignment: "center",
                    width: 123
                }, {
                    dataField: "H00",
                    caption: "00",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H00, data.Hora, 0); }
                }, {
                    dataField: "H01",
                    caption: "01",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H01, data.Hora, 1); }
                }, {
                    dataField: "H02",
                    caption: "02",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H02, data.Hora, 2); }
                }, {
                    dataField: "H03",
                    caption: "03",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H03, data.Hora, 3); }
                }, {
                    dataField: "H04",
                    caption: "04",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H04, data.Hora, 4); }
                }, {
                    dataField: "H05",
                    caption: "05",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H05, data.Hora, 5); }
                }, {
                    dataField: "H06",
                    caption: "06",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H06, data.Hora, 6); }
                }, {
                    dataField: "H07",
                    caption: "07",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H07, data.Hora, 7); }
                }, {
                    dataField: "H08",
                    caption: "08",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H08, data.Hora, 8); }
                }, {
                    dataField: "H09",
                    caption: "09",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H09, data.Hora, 9); }
                }, {
                    dataField: "H10",
                    caption: "10",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H10, data.Hora, 10); }
                }, {
                    dataField: "H11",
                    caption: "11",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H11, data.Hora, 11); }
                }, {
                    dataField: "H12",
                    caption: "12",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H12, data.Hora, 12); }
                }, {
                    dataField: "H13",
                    caption: "13",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H13, data.Hora, 13); }
                }, {
                    dataField: "H14",
                    caption: "14",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H14, data.Hora, 14); }
                }, {
                    dataField: "H15",
                    caption: "15",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H15, data.Hora, 15); }
                }, {
                    dataField: "H16",
                    caption: "16",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H16, data.Hora, 16); }
                }, {
                    dataField: "H17",
                    caption: "17",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H17, data.Hora, 17); }
                }, {
                    dataField: "H18",
                    caption: "18",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H18, data.Hora, 18); }
                }, {
                    dataField: "H19",
                    caption: "19",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H19, data.Hora, 19); }
                }, {
                    dataField: "H20",
                    caption: "20",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H20, data.Hora, 20); }
                }, {
                    dataField: "H21",
                    caption: "21",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H21, data.Hora, 21); }
                }, {
                    dataField: "H22",
                    caption: "22",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H22, data.Hora, 22); }
                }, {
                    dataField: "H23",
                    caption: "23",
                    dataType: "string",
                    alignment: "center",
                    calculateCellValue: function (data) { return gridDiaCellDisplay(data.H23, data.Hora, 23); }
                }
            ],
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
            series: {
                type: "bar"
            },
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " ton"; }
                }
            },
            bindingOptions: {
                'valueAxis.max': 'visaoGeralSemanaValMoagemMax',
                'commonSeriesSettings.color': 'visaoGeralSemanaIndicadorMetaColor'
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

        function semanaClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaMoagemPorSemanaPromise(1, 2018, $scope.visaoGeralSemana)
                .then(function (data) {
                    $scope.dadosMoendaAb = $.grep(data, function (e) { return e.moenda == 'AB'; });
                    $scope.dadosMoendaA = $.grep(data, function (e) { return e.moenda == 'A'; });
                    $scope.dadosMoendaB = $.grep(data, function (e) { return e.moenda == 'B'; });

                    $scope.dsChartSemana = $scope.semanaValPontuais ? dsChartSemanaValoresPontuais() : dsChartSemanaValoresAcumulados();
                    $scope.dsGridSemana = $scope.semanaMoendaGeral ? $scope.dadosMoendaAb[0].oGridMoagem : $scope.semanaMoendaA ? $scope.dadosMoendaA[0].oGridMoagem : $scope.dadosMoendaB[0].oGridMoagem;
                    $scope.dsGridSemanaProjecao = $scope.semanaMoendaGeral ? $scope.dadosMoendaAb[0].oGridMoagemProjecao : $scope.semanaMoendaA ? $scope.dadosMoendaA[0].oGridMoagemProjecao : $scope.dadosMoendaB[0].oGridMoagemProjecao;

                    //var semanaDiaReferencia = new Date($scope.dadosMoendaAb[0].DiaAtual);
                    var semanaDiaReferencia = new Date(2018, 4, 22);

                    var semanaDiaAtual = semanaDiaReferencia.ddmmyyyy();

                    semanaDiaReferencia.setDate(semanaDiaReferencia.getDate() - 1);
                    var semanaDiaAtualMenos1 = semanaDiaReferencia.ddmmyyyy();

                    semanaDiaReferencia.setDate(semanaDiaReferencia.getDate() - 1);
                    var semanaDiaAtualMenos2 = semanaDiaReferencia.ddmmyyyy();

                    semanaDiaReferencia.setDate(semanaDiaReferencia.getDate() - 1);
                    var semanaDiaAtualMenos3 = semanaDiaReferencia.ddmmyyyy();

                    semanaDiaReferencia.setDate(semanaDiaReferencia.getDate() - 1);
                    var semanaDiaAtualMenos4 = semanaDiaReferencia.ddmmyyyy();

                    semanaDiaReferencia.setDate(semanaDiaReferencia.getDate() - 1);
                    var semanaDiaAtualMenos5 = semanaDiaReferencia.ddmmyyyy();

                    semanaDiaReferencia.setDate(semanaDiaReferencia.getDate() - 1);
                    var semanaDiaAtualMenos6 = semanaDiaReferencia.ddmmyyyy();

                    $scope.gridSemanaColumns = [
                        {
                            dataField: "Diario",
                            caption: "Diário",
                            alignment: "center"
                        }, {
                            dataField: "Hora",
                            caption: "Hora",
                            alignment: "center"
                        }, {
                            dataField: "DIA1",
                            caption: semanaDiaAtualMenos6,
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSemanaCellDisplay(data.DIA1, data.Hora); }
                        }, {
                            dataField: "DIA2",
                            caption: semanaDiaAtualMenos5,
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSemanaCellDisplay(data.DIA2, data.Hora); }
                        }, {
                            dataField: "DIA3",
                            caption: semanaDiaAtualMenos4,
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSemanaCellDisplay(data.DIA3, data.Hora); }
                        }, {
                            dataField: "DIA4",
                            caption: semanaDiaAtualMenos3,
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSemanaCellDisplay(data.DIA4, data.Hora); }
                        }, {
                            dataField: "DIA5",
                            caption: semanaDiaAtualMenos2,
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSemanaCellDisplay(data.DIA5, data.Hora); }
                        }, {
                            dataField: "DIA6",
                            caption: semanaDiaAtualMenos1,
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSemanaCellDisplay(data.DIA6, data.Hora); }
                        }, {
                            dataField: "DIA7",
                            caption: semanaDiaAtual,
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSemanaCellDisplay(data.DIA7, data.Hora); }
                        }
                    ];

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
            series: {
                type: "bar"
            },
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " ton"; }
                }
            },
            bindingOptions: {
                'valueAxis.max': 'visaoGeralMesValMoagemMax',
                'commonSeriesSettings.color': 'visaoGeralMesIndicadorMetaColor'
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

        function mesClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaMoagemPorMesPromise(1, 2018, $scope.visaoGeralMes)
                .then(function (data) {
                    $scope.dadosMoendaAb = $.grep(data, function (e) { return e.moenda == 'AB'; });
                    $scope.dadosMoendaA = $.grep(data, function (e) { return e.moenda == 'A'; });
                    $scope.dadosMoendaB = $.grep(data, function (e) { return e.moenda == 'B'; });

                    $scope.dsChartMes = $scope.mesValPontuais ? dsChartMesValoresPontuais() : dsChartMesValoresAcumulados();
                    $scope.dsGridMes = $scope.mesMoendaGeral ? $scope.dadosMoendaAb[0].oGridMoagem : $scope.mesMoendaA ? $scope.dadosMoendaA[0].oGridMoagem : $scope.dadosMoendaB[0].oGridMoagem;

                    $scope.gridMesColumns = [
                        {
                            dataField: "Diario",
                            caption: "Diário",
                            alignment: "center"
                        }, {
                            dataField: "Hora",
                            caption: "Hora",
                            alignment: "center"
                        }, {
                            dataField: "SEMANA1",
                            caption: "Semana 1",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridMesCellDisplay(data.SEMANA1, data.Hora); }
                        }, {
                            dataField: "SEMANA2",
                            caption: "Semana 2",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridMesCellDisplay(data.SEMANA2, data.Hora); }
                        }, {
                            dataField: "SEMANA3",
                            caption: "Semana 3",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridMesCellDisplay(data.SEMANA3, data.Hora); }
                        }, {
                            dataField: "SEMANA4",
                            caption: "Semana 4",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridMesCellDisplay(data.SEMANA4, data.Hora); }
                        }, {
                            dataField: "SEMANA5",
                            caption: "Semana 5",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridMesCellDisplay(data.SEMANA5, data.Hora); }
                        }, {
                            dataField: "SEMANA6",
                            caption: "Semana 6",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridMesCellDisplay(data.SEMANA6, data.Hora); }
                        }
                    ];

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
            series: {
                type: "bar"
            },
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
                    customizeText: function() { return parseFloat(this.valueText).toLocaleString() + " ton"; }
                }
            },
            bindingOptions: {
                'valueAxis.max': 'visaoGeralSafraValMoagemMax',
                'commonSeriesSettings.color': 'visaoGeralSafraIndicadorMetaColor'
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


        function safraClick() {
            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaMoagemPorSafraCorteDiaPromise(1, 2018, $scope.visaoGeralDia)
                .then(function (data) {
                    $scope.dadosMoendaAb = $.grep(data, function (e) { return e.moenda == 'AB'; });
                    $scope.dadosMoendaA = $.grep(data, function (e) { return e.moenda == 'A'; });
                    $scope.dadosMoendaB = $.grep(data, function (e) { return e.moenda == 'B'; });

                    $scope.dsChartSafra = $scope.safraValPontuais ? dsChartSafraValoresPontuais() : dsChartSafraValoresAcumulados();
                    $scope.dsGridSafra = $scope.safraMoendaGeral ? $scope.dadosMoendaAb[0].oGridMoagem : $scope.safraMoendaA ? $scope.dadosMoendaA[0].oGridMoagem : $scope.dadosMoendaB[0].oGridMoagem;

                    $scope.gridSafraColumns = [
                        {
                            dataField: "Diario",
                            caption: "Diário",
                            alignment: "center"
                        }, {
                            dataField: "Hora",
                            caption: "Hora",
                            alignment: "center"
                        }, {
                            dataField: "MES4",
                            caption: "Abril",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSafraCellDisplay(data.MES4, data.Hora); }
                        }, {
                            dataField: "MES5",
                            caption: "Maio",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSafraCellDisplay(data.MES5, data.Hora); }
                        }, {
                            dataField: "MES6",
                            caption: "Junho",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSafraCellDisplay(data.MES6, data.Hora); }
                        }, {
                            dataField: "MES7",
                            caption: "Julho",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSafraCellDisplay(data.MES7, data.Hora); }
                        }, {
                            dataField: "MES8",
                            caption: "Agosto",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSafraCellDisplay(data.MES8, data.Hora); }
                        }, {
                            dataField: "MES9",
                            caption: "Setembro",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSafraCellDisplay(data.MES9, data.Hora); }
                        }, {
                            dataField: "MES10",
                            caption: "Outubro",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSafraCellDisplay(data.MES10, data.Hora); }
                        }, {
                            dataField: "MES11",
                            caption: "Novembro",
                            dataType: "string",
                            alignment: "center",
                            calculateCellValue: function (data) { return gridSafraCellDisplay(data.MES11, data.Hora); }
                        }
                    ];

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


        $scope.buttonDiaMoendaGeralOptions = {
            text: 'Moendas A+B',
            bindingOptions: {
                type: 'diaMoendaGeralButtonType'
            },
            onClick: function () {
                $scope.diaMoendaGeral = true;
            }
        };

        $scope.buttonDiaMoendaAOptions = {
            text: 'Moenda A',
            bindingOptions: {
                type: 'diaMoendaAButtonType'
            },
            onClick: function () {
                $scope.diaMoendaA = true;

            }
        };

        $scope.buttonDiaMoendaBOptions = {
            text: 'Moenda B',
            bindingOptions: {
                type: 'diaMoendaBButtonType'
            },
            onClick: function () {
                $scope.diaMoendaB = true;

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


        $scope.buttonSemanaMoendaGeralOptions = {
            text: 'Moendas A+B',
            bindingOptions: {
                type: 'semanaMoendaGeralButtonType'
            },
            onClick: function () {
                $scope.semanaMoendaGeral = true;
            }
        };

        $scope.buttonSemanaMoendaAOptions = {
            text: 'Moenda A',
            bindingOptions: {
                type: 'semanaMoendaAButtonType'
            },
            onClick: function () {
                $scope.semanaMoendaA = true;
            }
        };

        $scope.buttonSemanaMoendaBOptions = {
            text: 'Moenda B',
            bindingOptions: {
                type: 'semanaMoendaBButtonType'
            },
            onClick: function () {
                $scope.semanaMoendaB = true;
            }
        };


        //Chart Mes
        $scope.chartMesOptions = {
            bindingOptions: {
                dataSource: 'dsChartMes',
                title: 'titleChartMes'
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

        $scope.buttonMesMoendaGeralOptions = {
            text: 'Moendas A+B',
            bindingOptions: {
                type: 'mesMoendaGeralButtonType'
            },
            onClick: function () {
                $scope.mesMoendaGeral = true;
            }
        };

        $scope.buttonMesMoendaAOptions = {
            text: 'Moenda A',
            bindingOptions: {
                type: 'mesMoendaAButtonType'
            },
            onClick: function () {
                $scope.mesMoendaA = true;
            }
        };

        $scope.buttonMesMoendaBOptions = {
            text: 'Moenda B',
            bindingOptions: {
                type: 'mesMoendaBButtonType'
            },
            onClick: function () {
                $scope.mesMoendaB = true;

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
                    format: 'shortDate'
                },
                tickInterval: { days: 1 }
            },
            commonSeriesSettings: {
                argumentField: "DIA",
                type: "line",
                point: {
                    size: 4
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

        $scope.buttonSafraMoendaGeralOptions = {
            text: 'Moendas A+B',
            bindingOptions: {
                type: 'safraMoendaGeralButtonType'
            },
            onClick: function () {
                $scope.safraMoendaGeral = true;
            }
        };

        $scope.buttonSafraMoendaAOptions = {
            text: 'Moenda A',
            bindingOptions: {
                type: 'safraMoendaAButtonType'
            },
            onClick: function () {
                $scope.safraMoendaA = true;
            }
        };

        $scope.buttonSafraMoendaBOptions = {
            text: 'Moenda B',
            bindingOptions: {
                type: 'safraMoendaBButtonType'
            },
            onClick: function () {
                $scope.safraMoendaB = true;
            }
        };
    };
})();