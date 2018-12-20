/*! 
* Autor: Renato Ferreira Xavier
* Data: março/2018
* 4T Sistemas Inteligentes Ltda.
*/
(function () {
    "use strict";

    Date.prototype.ddmmyyyy = function () {
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

    angular.module('app4T')
        .controller("agricolacolheitaCtrl", ['$scope', '$document', 'ApiGetService', agricolacolheitaCtrl]);

    function agricolacolheitaCtrl($scope, $document, ApiGetService) {
        $scope.loadingVisible = true;

        //#region $scope empty object declarations
        $scope.dsChartEntregaCanaPorDia = {};
        $scope.dsChartDensidadeCargaPorDia = {};
        $scope.dsChartImpurezaVegetalPorDia = {};
        $scope.dsChartImpurezaMineralPorDia = {};
        $scope.dsChartVelocidadeMediaPorDia = {};

        $scope.dsChartEntregaCanaPorSemana = {};
        $scope.dsChartDensidadeCargaPorSemana = {};

        $scope.dsChartEntregaCanaPorMes = {};
        $scope.dsChartDensidadeCargaPorMes = {};

        $scope.dsChartEntregaCanaPorSafra = {};
        $scope.dsChartDensidadeCargaPorSafra = {};

        $scope.seltabFiltroPeriodo = 0;
        $scope.filtroPeriodoDia = function () { return $scope.seltabFiltroPeriodo === 0 };
        $scope.filtroPeriodoSemana = function () { return $scope.seltabFiltroPeriodo === 1 };
        $scope.filtroPeriodoMes = function () { return $scope.seltabFiltroPeriodo === 2 };
        $scope.filtroPeriodoSafra = function () { return $scope.seltabFiltroPeriodo === 3 };

        $scope.filtroPeriodoDiaFrente = function () {
            return $scope.seltabFiltroPeriodo === 0 &&
                $scope.frenteEntregaCanaAtual &&
                $scope.frenteEntregaCanaAtual.frenteCodigo !== 0;
        };

        $scope.seltabFiltroFrentesEntregaCana = -1;
        $scope.seltabFiltroFrentesDensidadeCarga = -1;

        $scope.frenteEntregaCanaAtual = {};
        $scope.frenteDensidadeCargaAtual = {};

        $scope.entregaAcumulada = 0;
        $scope.entregaAcumuladaDisplay = "";

        $scope.densidadeAtual = 0;
        $scope.densidadeAtualDisplay = "";

        function frentesEntregaCanaDataSource(frentesEntregaCana) {
            var frentesEntregaCanaArray = [];

            for (var i = 0; i < frentesEntregaCana.length; i++) {
                frentesEntregaCanaArray.push({
                    text: frentesEntregaCana[i].frenteDescricao,
                    frenteCodigo: frentesEntregaCana[i].frenteCodigo,
                    indicadorMeta: frentesEntregaCana[i].indicadorMeta
                });
            };

            return frentesEntregaCanaArray;
        };

        function frentesDensidadeCargaDataSource(frentesDensidadeCarga) {
            var frentesDensidadeCargaArray = [];

            for (var i = 0; i < frentesDensidadeCarga.length; i++) {
                frentesDensidadeCargaArray.push({
                    text: frentesDensidadeCarga[i].frenteDescricao,
                    frenteCodigo: frentesDensidadeCarga[i].frenteCodigo,
                    indicadorMeta: frentesDensidadeCarga[i].indicadorMeta
                });
            };

            return frentesDensidadeCargaArray;
        };

        function dataEntregaCanaMergeEstoque(data) {
            if (!data.oGraficoEntregaCanaAcumulado) return [];

            var entregaCanaMergeEstoqueArray = [];

            for (var i = 0; i < data.oGraficoEntregaCanaAcumulado.length; i++) {
                var estoque = data.oGraficoEstoqueCanaPatio && data.oGraficoEstoqueCanaPatio[i] ? data.oGraficoEstoqueCanaPatio[i].REALIZADO : 0;

                entregaCanaMergeEstoqueArray.push($.extend(data.oGraficoEntregaCanaAcumulado[i], { ESTOQUE: estoque}));
            }

            return entregaCanaMergeEstoqueArray;
        };

        angular.element(document).ready(function () {
            //ORDEM: 2 - Document Ready Angular

            Globalize.culture("pt-BR");

            ApiGetService
                .getagricolaColheitaVisaoGeralMinMaxDiaPromise(1, 2017)
                .then(function (data) {
                    //$scope.visaoGeralDia = new Date(data.maxDia).yyyymmdd();
                    $scope.visaoGeralDia = new Date(2017, 10, 17).yyyymmdd();
                    $scope.visaoGeralDiaDate = new Date(data.maxDia);
                    $scope.visaoGeralSemana = data.maxSemana;
                    $scope.visaoGeralMes = data.maxMes;

                    ApiGetService
                        .getagricolaColheitaPorDiaPromise(1, 2017, $scope.visaoGeralDia)
                        .then(function (data) {
                            //Entrega Cana
                            $scope.dsChartEntregaCanaPorDia = dataEntregaCanaMergeEstoque(data); //data.oGraficoEntregaCanaAcumulado;
                            $scope.titleChartEntregaCanaPorDia = "Entrega de Cana";

                            var frentesEntregaCanaArray = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);

                            $scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaArray;
                            $scope.seltabFiltroFrentesEntregaCana = data.oFrentesEntregaCana.length - 1;

                            $scope.frenteEntregaCanaAtual = frentesEntregaCanaArray[data.oFrentesEntregaCana.length - 1];

                            $scope.entregaAcumulada = data.entregaAcumulada;
                            $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                            //Densidade Carga
                            $scope.dsChartDensidadeCargaPorDia = data.oGraficoDensidadeCarga;
                            $scope.titleChartDensidadeCargaPorDia = "Densidade de Carga";

                            var frentesDensidadeCargaArray = frentesDensidadeCargaDataSource(data.oFrentesDensidadeCarga);

                            $scope.tabFiltroFrentesDensidadeCargaDataSource = frentesDensidadeCargaArray;
                            $scope.seltabFiltroFrentesDensidadeCarga = data.oFrentesDensidadeCarga.length -1;

                            $scope.frenteDensidadeCargaAtual = frentesDensidadeCargaArray[data.oFrentesDensidadeCarga.length - 1];

                            $scope.densidadeAtual = data.densidadeAtual;
                            $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();


                            $scope.loadingVisible = false;
                        });
                });
        });

        $scope.loadOptions = {
            bindingOptions: {
                visible: "loadingVisible"
            },

            showIndicator: true,
            showPane: true,
            shading: true,
            message: "Aguarde..."
        };

        $scope.tabFiltroPeriodoOptions = {
            dataSource: [
                { text: "Dia" },
                { text: "Semana" },
                { text: "Mês" },
                { text: "Safra" }
            ],
            bindingOptions: {
                selectedIndex: 'seltabFiltroPeriodo'
            },
            onItemClick: function(e) {
                $scope.loadingVisible = true;

                $scope.frenteEntregaCanaAtual = $scope.tabFiltroFrentesEntregaCanaDataSource[$scope.tabFiltroFrentesEntregaCanaDataSource.length - 1];
                $scope.frenteDensidadeCargaAtual = $scope.tabFiltroFrentesDensidadeCargaDataSource[$scope.tabFiltroFrentesDensidadeCargaDataSource.length - 1];

                resolveChartEntregaCana($scope.frenteEntregaCanaAtual, $scope.seltabFiltroPeriodo, true).then(function() {
                    $scope.seltabFiltroFrentesEntregaCana = $scope.tabFiltroFrentesEntregaCanaDataSource.length - 1;

                    coloreTabsFrentes($("#tabFrEntCana"), $scope.tabFiltroFrentesEntregaCanaDataSource);

                    resolveChartDensidadeCarga($scope.frenteDensidadeCargaAtual, $scope.seltabFiltroPeriodo, true).then(function () {
                        $scope.seltabFiltroFrentesDensidadeCarga = $scope.tabFiltroFrentesDensidadeCargaDataSource.length - 1;

                        coloreTabsFrentes($("#tabFrDensCarga"), $scope.tabFiltroFrentesDensidadeCargaDataSource);

                        $scope.loadingVisible = false;
                        $scope.$apply();
                    });
                });
            }
        };

        function coloreTabsFrentes(element, frentesDataSource) {
            if (!element || !frentesDataSource) return;

            var tabs = element.find(".dx-tab");

            for (var i = 0; i < frentesDataSource.length; i++) {
                var backgroundColor = frentesDataSource[i].indicadorMeta == 0 ? '#91d04e' : '#d30000';

                $(tabs[i]).css('background', backgroundColor);
            }            
        };

        $scope.$watch("seltabFiltroPeriodo", function (newValue) {
            console.log(newValue);

        });

        $scope.$watch("seltabFiltroFrentesEntregaCana", function (newValue) {
            console.log(newValue);
        });


        function resolveChartEntregaCana(frenteEntregaCana, filtroPeriodo, refazFrentesDataSource) {
            var promise = new Promise(function(resolve, reject) {
                    if (frenteEntregaCana.frenteCodigo == 0) {
                    //Frentes GERAL
                    if (filtroPeriodo == 0) {
                        //Período Dia
                        ApiGetService
                            .getagricolaColheitaPorDiaPromise(1, 2017, $scope.visaoGeralDia)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorDia = dataEntregaCanaMergeEstoque(data); //data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorDia = "Entrega de Cana";

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesEntregaCana = -1;
                                    $scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);                                    
                                };

                                resolve();
                            });
                    } else if (filtroPeriodo == 1) {
                        //Período Semana
                        ApiGetService
                            .getagricolaColheitaPorSemanaPromise(1, 2017, $scope.visaoGeralSemana)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorSemana = dataEntregaCanaMergeEstoque(data); //data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorSemana = "Entrega de Cana";

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesEntregaCana = -1;
                                    $scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);
                                };

                                resolve();
                            });
                    } else if (filtroPeriodo == 2) {
                        //Período Mês
                        ApiGetService
                            .getagricolaColheitaPorMesPromise(1, 2017, $scope.visaoGeralMes)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorMes = dataEntregaCanaMergeEstoque(data); //data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorMes = "Entrega de Cana";

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesEntregaCana = -1;
                                    $scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);
                                };

                                resolve();
                            });
                    } else if (filtroPeriodo == 3) {
                        //Período Safra
                        ApiGetService
                            .getagricolaColheitaPorSafraPromise(1, 2017)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorSafra = dataEntregaCanaMergeEstoque(data); //data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorSafra = "Entrega de Cana";

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesEntregaCana = -1;
                                    $scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);
                                };

                                resolve();
                            });
                    };
                } else {
                    //Frentes específicas
                    if (filtroPeriodo == 0) {
                        //Período Dia
                        ApiGetService
                            .getagricolaColheitaPorDiaPorFrentePromise(1, 2017, $scope.visaoGeralDia, frenteEntregaCana.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorDia = dataEntregaCanaMergeEstoque(data); //data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorDia = "Entrega de Cana " + frenteEntregaCana.text;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                //$scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);

                                $scope.titleChartImpurezaVegetalPorDia = "Impureza Vegetal " + frenteEntregaCana.text;
                                $scope.dsChartImpurezaVegetalPorDia = data.oGraficoImpurezaVegetal;

                                $scope.titleChartImpurezaMineralPorDia = "Impureza Mineral " + frenteEntregaCana.text;
                                $scope.dsChartImpurezaMineralPorDia = data.oGraficoImpurezaMineral;

                                $scope.titleChartVelocidadeMediaPorDia = "Velocidade Média " + frenteEntregaCana.text;
                                $scope.dsChartVelocidadeMediaPorDia = data.oGraficoVelocidadeMedia;

                                resolve();
                            });
                    } else if (filtroPeriodo == 1) {
                        //Período Semana
                        ApiGetService
                            .getagricolaColheitaPorSemanaPorFrentePromise(1, 2017, $scope.visaoGeralSemana, frenteEntregaCana.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorSemana = dataEntregaCanaMergeEstoque(data); //data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorSemana = "Entrega de Cana " + frenteEntregaCana.text;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                //$scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);

                                resolve();
                            });
                    } else if (filtroPeriodo == 2) {
                        //Período Mês
                        ApiGetService
                            .getagricolaColheitaPorMesPorFrentePromise(1, 2017, $scope.visaoGeralMes, frenteEntregaCana.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorMes = dataEntregaCanaMergeEstoque(data); //data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorMes = "Entrega de Cana " + frenteEntregaCana.text;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                //$scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);

                                resolve();
                            });
                    } else if (filtroPeriodo == 3) {
                        //Período Safra
                        ApiGetService
                            .getagricolaColheitaPorSafraPorFrentePromise(1, 2017, frenteEntregaCana.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorSafra = dataEntregaCanaMergeEstoque(data); //data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorSafra = "Entrega de Cana " + frenteEntregaCana.text;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                //$scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);

                                resolve();
                            });
                    };
                };
            });

            return promise;
        };

        $scope.tabFiltroFrentesEntregaCanaOptions = {
            bindingOptions: {
                dataSource: 'tabFiltroFrentesEntregaCanaDataSource',
                selectedIndex: 'seltabFiltroFrentesEntregaCana'
            },
            noDataText: "",
            onItemClick: function (e) {
                $scope.loadingVisible = true;

                $scope.frenteEntregaCanaAtual = e.itemData;

                console.log($scope.frenteEntregaCanaAtual);

                resolveChartEntregaCana($scope.frenteEntregaCanaAtual, $scope.seltabFiltroPeriodo, false).then(function () {
                    $scope.loadingVisible = false;
                    $scope.$apply();
                });
            },
            onContentReady: function (e) {
                coloreTabsFrentes(e.element, $scope.tabFiltroFrentesEntregaCanaDataSource);
            }
        };


        function resolveChartDensidadeCarga(frenteDensidadeCarga, filtroPeriodo, refazFrentesDataSource) {
            var promise = new Promise(function(resolve, reject) {
                    if (frenteDensidadeCarga.frenteCodigo == 0) {
                    //Frentes GERAL
                    if (filtroPeriodo == 0) {
                        //Período Dia
                        ApiGetService
                            .getagricolaColheitaPorDiaPromise(1, 2017, $scope.visaoGeralDia)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorDia = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorDia = "Densidade de Carga";

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesDensidadeCarga = -1;
                                    $scope.tabFiltroFrentesDensidadeCargaDataSource = frentesDensidadeCargaDataSource(data.oFrentesDensidadeCarga);
                                };

                                resolve();
                            });
                    } else if (filtroPeriodo == 1) {
                        //Período Semana
                        ApiGetService
                            .getagricolaColheitaPorSemanaPromise(1, 2017, $scope.visaoGeralSemana)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorSemana = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorSemana = "Densidade de Carga";

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesDensidadeCarga = -1;
                                    $scope.tabFiltroFrentesDensidadeCargaDataSource = frentesDensidadeCargaDataSource(data.oFrentesDensidadeCarga);
                                };
                                
                                resolve();
                            });
                    } else if (filtroPeriodo == 2) {
                        //Período Mês
                        ApiGetService
                            .getagricolaColheitaPorMesPromise(1, 2017, $scope.visaoGeralMes)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorMes = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorMes = "Densidade de Carga";

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesDensidadeCarga = -1;
                                    $scope.tabFiltroFrentesDensidadeCargaDataSource = frentesDensidadeCargaDataSource(data.oFrentesDensidadeCarga);
                                };

                                resolve();
                            });
                    } else if (filtroPeriodo == 3) {
                        //Período Safra
                        ApiGetService
                            .getagricolaColheitaPorSafraPromise(1, 2017)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorSafra = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorSafra = "Densidade de Carga";

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesDensidadeCarga = -1;
                                    $scope.tabFiltroFrentesDensidadeCargaDataSource = frentesDensidadeCargaDataSource(data.oFrentesDensidadeCarga);
                                };

                                resolve();
                            });
                    };
                } else {
                    //Frentes específicas
                    if (filtroPeriodo == 0) {
                        //Período Dia
                        ApiGetService
                            .getagricolaColheitaPorDiaPorFrentePromise(1, 2017, $scope.visaoGeralDia, frenteDensidadeCarga.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorDia = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorDia = "Densidade de Carga " + frenteDensidadeCarga.text;

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                resolve();
                            });
                    } else if (filtroPeriodo == 1) {
                        //Período Semana
                        ApiGetService
                            .getagricolaColheitaPorSemanaPorFrentePromise(1, 2017, $scope.visaoGeralSemana, frenteDensidadeCarga.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorSemana = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorSemana = "Densidade de Carga " + frenteDensidadeCarga.text;

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                resolve();
                            });
                    } else if (filtroPeriodo == 2) {
                        //Período Mês
                        ApiGetService
                            .getagricolaColheitaPorMesPorFrentePromise(1, 2017, $scope.visaoGeralMes, frenteDensidadeCarga.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorMes = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorMes = "Densidade de Carga " + frenteDensidadeCarga.text;

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                resolve();
                            });
                    } else if (filtroPeriodo == 3) {
                        //Período Safra
                        ApiGetService
                            .getagricolaColheitaPorSafraPorFrentePromise(1, 2017, frenteDensidadeCarga.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorSafra = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorSafra = "Densidade de Carga " + frenteDensidadeCarga.text;

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                resolve();
                            });
                    };
                };
            });

            return promise;
        };

        $scope.tabFiltroFrentesDensidadeCargaOptions = {
            bindingOptions: {
                dataSource: 'tabFiltroFrentesDensidadeCargaDataSource',
                selectedIndex: 'seltabFiltroFrentesDensidadeCarga'
            },
            noDataText: "",
            onItemClick: function(e) {
                $scope.loadingVisible = true;

                $scope.frenteDensidadeCargaAtual = e.itemData;

                resolveChartDensidadeCarga($scope.frenteDensidadeCargaAtual, $scope.seltabFiltroPeriodo, false).then(function () {
                    $scope.loadingVisible = false;
                    $scope.$apply();
                });
            },
            onContentReady: function(e) {
                coloreTabsFrentes(e.element, $scope.tabFiltroFrentesDensidadeCargaDataSource);
            }
        };



        $scope.chartEntregaCanaPorDiaOptions = {
            bindingOptions: {
                dataSource: 'dsChartEntregaCanaPorDia',
                title: 'titleChartEntregaCanaPorDia'
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
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" },
                { valueField: "ESTOQUE", name: "Estoque Cana", axis: "estoque"}
            ],
            valueAxis: [
                {
                    name: "entrega",
                    position: "left",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Entrega Diária"
                    }
                },
                {
                    name: "estoque",
                    position: "right",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Estoque"
                    }
                }],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartDensidadeCargaPorDiaOptions = {
            bindingOptions: {
                dataSource: 'dsChartDensidadeCargaPorDia',
                title: 'titleChartDensidadeCargaPorDia'
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
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartImpurezaVegetalPorDiaOptions = {
            bindingOptions: {
                dataSource: 'dsChartImpurezaVegetalPorDia',
                title: 'titleChartImpurezaVegetalPorDia'
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
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartImpurezaMineralPorDiaOptions = {
            bindingOptions: {
                dataSource: 'dsChartImpurezaMineralPorDia',
                title: 'titleChartImpurezaMineralPorDia'
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
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartVelocidadeMediaPorDiaOptions = {
            bindingOptions: {
                dataSource: 'dsChartVelocidadeMediaPorDia',
                title: 'titleChartVelocidadeMediaPorDia'
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
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };





        $scope.chartEntregaCanaPorSemanaOptions = {
            bindingOptions: {
                dataSource: 'dsChartEntregaCanaPorSemana',
                title: 'titleChartEntregaCanaPorSemana'
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
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" },
                { valueField: "ESTOQUE", name: "Estoque Cana", axis: "estoque" }
            ],
            valueAxis: [
                {
                    name: "entrega",
                    position: "left",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Entrega Diária"
                    }
                },
                {
                    name: "estoque",
                    position: "right",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Estoque"
                    }
                }],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartDensidadeCargaPorSemanaOptions = {
            bindingOptions: {
                dataSource: 'dsChartDensidadeCargaPorSemana',
                title: 'titleChartDensidadeCargaPorSemana'
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
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };


        $scope.chartEntregaCanaPorMesOptions = {
            bindingOptions: {
                dataSource: 'dsChartEntregaCanaPorMes',
                title: 'titleChartEntregaCanaPorMes'
            },
            argumentAxis: {
                argumentType: 'numeric',
                label: {
                    format: 'decimal'
                }
            },
            commonSeriesSettings: {
                argumentField: "SEMANA",
                type: "line",
                point: {
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" },
                { valueField: "ESTOQUE", name: "Estoque Cana", axis: "estoque" }
            ],
            valueAxis: [
                {
                    name: "entrega",
                    position: "left",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Entrega Diária"
                    }
                },
                {
                    name: "estoque",
                    position: "right",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Estoque"
                    }
                }],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartDensidadeCargaPorMesOptions = {
            bindingOptions: {
                dataSource: 'dsChartDensidadeCargaPorMes',
                title: 'titleChartDensidadeCargaPorMes'
            },
            argumentAxis: {
                argumentType: 'numeric',
                label: {
                    format: 'decimal'
                }
            },
            commonSeriesSettings: {
                argumentField: "SEMANA",
                type: "line",
                point: {
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };


        $scope.chartEntregaCanaPorSafraOptions = {
            bindingOptions: {
                dataSource: 'dsChartEntregaCanaPorSafra',
                title: 'titleChartEntregaCanaPorSafra'
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
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" },
                { valueField: "ESTOQUE", name: "Estoque Cana", axis: "estoque" }
            ],
            valueAxis: [
                {
                    name: "entrega",
                    position: "left",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Entrega Diária"
                    }
                },
                {
                    name: "estoque",
                    position: "right",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Estoque"
                    }
                }],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartDensidadeCargaPorSafraOptions = {
            bindingOptions: {
                dataSource: 'dsChartDensidadeCargaPorSafra',
                title: 'titleChartDensidadeCargaPorSafra'
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
                    size: 6
                }
            },
            tooltip: {
                enabled: true
            },
            series: [
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

    };
})();
