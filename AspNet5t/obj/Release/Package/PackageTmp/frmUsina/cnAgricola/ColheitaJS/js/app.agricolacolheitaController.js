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

    function pureDate(dateString) {
        //dateString format: yyyy-MM-ddTHH:MM:SS (2018-04-17T00:00:00)
        var date = dateString;
        date = date.substring(0, 10).split('-');
        return new Date(parseInt(date[0]), parseInt(date[1]) - 1, parseInt(date[2]));
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
        $scope.dsChartImpurezaVegetalPorSemana = {};
        $scope.dsChartImpurezaMineralPorSemana = {};
        $scope.dsChartVelocidadeMediaPorSemana = {};

        $scope.dsChartEntregaCanaPorMes = {};
        $scope.dsChartDensidadeCargaPorMes = {};
        $scope.dsChartImpurezaVegetalPorMes = {};
        $scope.dsChartImpurezaMineralPorMes = {};
        $scope.dsChartVelocidadeMediaPorMes = {};

        $scope.dsChartEntregaCanaPorSafra = {};
        $scope.dsChartDensidadeCargaPorSafra = {};
        $scope.dsChartImpurezaVegetalPorSafra = {};
        $scope.dsChartImpurezaMineralPorSafra = {};
        $scope.dsChartVelocidadeMediaPorSafra = {};

        $scope.equipamentosComDados = false;

        $scope.dsChartEquipColhedoraVelColheita = {};
        $scope.chartEquipColhedoraVelColheitaMedia = 0; //graficoColhedoraI29Media
        $scope.chartEquipColhedoraVelColheitaMediaText = function () { return "Média: " + $scope.chartEquipColhedoraVelColheitaMedia.toLocaleString() }
        $scope.chartEquipColhedoraVelColheitaMeta = 0; //graficoColhedoraI29Meta
        $scope.chartEquipColhedoraVelColheitaMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraVelColheitaMeta.toLocaleString() }
        $scope.chartEquipColhedoraVelColheitaMax = 0;

        $scope.dsChartEquipColhedoraEquipProd = {};
        $scope.chartEquipColhedoraEquipProdMedia = 0; //graficoColhedoraI30Media
        $scope.chartEquipColhedoraEquipProdMediaText = function () { return "Média: " + $scope.chartEquipColhedoraEquipProdMedia.toLocaleString() }
        $scope.chartEquipColhedoraEquipProdMeta = 0; //graficoColhedoraI30Meta
        $scope.chartEquipColhedoraEquipProdMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraEquipProdMeta.toLocaleString() }
        $scope.chartEquipColhedoraEquipProdMax = 0;

        $scope.dsChartEquipColhedoraFaltaTrator = {};
        $scope.chartEquipColhedoraFaltaTratorMedia = 0; //graficoColhedoraI31Media
        $scope.chartEquipColhedoraFaltaTratorMediaText = function () { return "Média: " + $scope.chartEquipColhedoraFaltaTratorMedia.toLocaleString() }
        $scope.chartEquipColhedoraFaltaTratorMeta = 0; //graficoColhedoraI31Meta
        $scope.chartEquipColhedoraFaltaTratorMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraFaltaTratorMeta.toLocaleString() }
        $scope.chartEquipColhedoraFaltaTratorMax = 0;

        $scope.dsChartEquipColhedoraTempoAprov = {};
        $scope.chartEquipColhedoraTempoAprovMedia = 0; //graficoColhedoraI32Media
        $scope.chartEquipColhedoraTempoAprovMediaText = function () { return "Média: " + $scope.chartEquipColhedoraTempoAprovMedia.toLocaleString() }
        $scope.chartEquipColhedoraTempoAprovMeta = 0; //graficoColhedoraI32Meta
        $scope.chartEquipColhedoraTempoAprovMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraTempoAprovMeta.toLocaleString() }
        $scope.chartEquipColhedoraTempoAprovMax = 0;

        $scope.dsChartEquipColhedoraAprovDistancia = {};
        $scope.chartEquipColhedoraAprovDistanciaMedia = 0; //graficoColhedoraI33Media
        $scope.chartEquipColhedoraAprovDistanciaMediaText = function () { return "Média: " + $scope.chartEquipColhedoraAprovDistanciaMedia.toLocaleString() }
        $scope.chartEquipColhedoraAprovDistanciaMeta = 0; //graficoColhedoraI33Meta
        $scope.chartEquipColhedoraAprovDistanciaMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraAprovDistanciaMeta.toLocaleString() }
        $scope.chartEquipColhedoraAprovDistanciaMax = 0;

        $scope.dsChartEquipColhedoraProdutividade = {};
        $scope.chartEquipColhedoraProdutividadeMedia = 0; //graficoColhedoraI49Media
        $scope.chartEquipColhedoraProdutividadeMediaText = function () { return "Média: " + $scope.chartEquipColhedoraProdutividadeMedia.toLocaleString() }
        $scope.chartEquipColhedoraProdutividadeMeta = 0; //graficoColhedoraI49Meta
        $scope.chartEquipColhedoraProdutividadeMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraProdutividadeMeta.toLocaleString() }
        $scope.chartEquipColhedoraProdutividadeMax = 0;

        $scope.dsChartEquipTratorEquipProd = {};
        $scope.chartEquipTratorEquipProdMedia = 0; //graficoTratorI30Media
        $scope.chartEquipTratorEquipProdMediaText = function () { return "Média: " + $scope.chartEquipTratorEquipProdMedia.toLocaleString() }
        $scope.chartEquipTratorEquipProdMeta = 0; //graficoTratorI30Meta
        $scope.chartEquipTratorEquipProdMetaText = function () { return "Meta: " + $scope.chartEquipTratorEquipProdMeta.toLocaleString() }
        $scope.chartEquipTratorEquipProdMax = 0;

        $scope.dsChartEquipTratorFilaCarr = {};
        $scope.chartEquipTratorFilaCarrMedia = 0; //graficoTratorI34Media 
        $scope.chartEquipTratorFilaCarrMediaText = function () { return "Média: " + $scope.chartEquipTratorFilaCarrMedia.toLocaleString() }
        $scope.chartEquipTratorFilaCarrMeta = 0; //graficoTratorI34Meta 
        $scope.chartEquipTratorFilaCarrMetaText = function () { return "Meta: " + $scope.chartEquipTratorFilaCarrMeta.toLocaleString() }
        $scope.chartEquipTratorFilaCarrMax = 0;

        $scope.dsChartEquipTratorFaltaCam = {};
        $scope.chartEquipTratorFaltaCamMedia = 0; //graficoTratorI35Media
        $scope.chartEquipTratorFaltaCamMediaText = function () { return "Média: " + $scope.chartEquipTratorFaltaCamMedia.toLocaleString() }
        $scope.chartEquipTratorFaltaCamMeta = 0; //graficoTratorI35Meta
        $scope.chartEquipTratorFaltaCamMetaText = function () { return "Meta: " + $scope.chartEquipTratorFaltaCamMeta.toLocaleString() }
        $scope.chartEquipTratorFaltaCamMax = 0;

        $scope.seltabFiltroPeriodo = 0;
        $scope.filtroPeriodoDia = function () { return $scope.seltabFiltroPeriodo === 0 };
        $scope.filtroPeriodoSemana = function () { return $scope.seltabFiltroPeriodo === 1 };
        $scope.filtroPeriodoMes = function () { return $scope.seltabFiltroPeriodo === 2 };
        $scope.filtroPeriodoSafra = function () { return $scope.seltabFiltroPeriodo === 3 };

        $scope.filtroFrente = function () {
            return $scope.frenteAtual &&
                $scope.frenteAtual.frenteCodigo !== 0;
        };

        $scope.filtroPeriodoDiaFrente = function () {
            return $scope.seltabFiltroPeriodo === 0 &&
                $scope.frenteAtual &&
                $scope.frenteAtual.frenteCodigo !== 0;
        };

        $scope.filtroPeriodoSemanaFrente = function () {
            return $scope.seltabFiltroPeriodo === 1 &&
                $scope.frenteAtual &&
                $scope.frenteAtual.frenteCodigo !== 0;
        };

        $scope.filtroPeriodoMesFrente = function () {
            return $scope.seltabFiltroPeriodo === 2 &&
                $scope.frenteAtual &&
                $scope.frenteAtual.frenteCodigo !== 0;
        };

        $scope.filtroPeriodoSafraFrente = function () {
            return $scope.seltabFiltroPeriodo === 3 &&
                $scope.frenteAtual &&
                $scope.frenteAtual.frenteCodigo !== 0;
        };

        $scope.seltabFiltroFrentesEntregaCana = -1;
        $scope.seltabFiltroFrentesDensidadeCarga = -1;

        $scope.frenteEntregaCanaAtual = {};
        $scope.frenteDensidadeCargaAtual = {};
        $scope.frenteAtual = {};

        $scope.horaAtual = "";

        $scope.entregaAcumulada = 0;
        $scope.entregaAcumuladaDisplay = "";

        $scope.entregaPlanejadaTotal = 0;
        $scope.entregaPlanejadaTotalDisplay = "";

        $scope.entregaPlanejadaAcumulada = 0;
        $scope.entregaPlanejadaAcumuladaDisplay = "";

        $scope.media = 0;
        $scope.mediaDisplay = "";

        $scope.estoquePatio = 0;
        $scope.estoquePatioDisplay = "";

        $scope.desvio = 0;
        $scope.desvioDisplay = "";

        $scope.densidadeAtual = 0;
        $scope.densidadeAtualDisplay = "";


        $scope.colhedoraFrenteMostrar = false;
        $scope.colhedoraFrenteButtonText = function () { return "COLHEDORA " + $scope.frenteAtual.text };
        $scope.colhedoraFrenteButtonIcon = function () { return $scope.colhedoraFrenteMostrar ? "chevronup" : "chevrondown" };

        $scope.tratorFrenteMostrar = false;
        $scope.tratorFrenteButtonText = function () { return "TRATOR " + $scope.frenteAtual.text };
        $scope.tratorFrenteButtonIcon = function () { return $scope.tratorFrenteMostrar ? "chevronup" : "chevrondown" };

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

        function resolveCharts() {
            //$scope.frenteEntregaCanaAtual = $scope.tabFiltroFrentesEntregaCanaDataSource[$scope.tabFiltroFrentesEntregaCanaDataSource.length - 1];
            //$scope.frenteDensidadeCargaAtual = $scope.tabFiltroFrentesDensidadeCargaDataSource[$scope.tabFiltroFrentesDensidadeCargaDataSource.length - 1];
            //$scope.frenteAtual = $scope.frenteEntregaCanaAtual;

            resolveChartEntregaCana($scope.frenteEntregaCanaAtual, $scope.seltabFiltroPeriodo, true).then(function () {
                $scope.seltabFiltroFrentesEntregaCana = $scope.tabFiltroFrentesEntregaCanaDataSource.length - 1;

                coloreTabsFrentes($("#tabFrEntCana"), $scope.tabFiltroFrentesEntregaCanaDataSource);

                resolveChartDensidadeCarga($scope.frenteDensidadeCargaAtual, $scope.seltabFiltroPeriodo, true).then(function () {
                    $scope.seltabFiltroFrentesDensidadeCarga = $scope.tabFiltroFrentesDensidadeCargaDataSource.length - 1;

                    coloreTabsFrentes($("#tabFrDensCarga"), $scope.tabFiltroFrentesDensidadeCargaDataSource);

                    if ($scope.frenteEntregaCanaAtual.frenteCodigo && $scope.frenteEntregaCanaAtual.frenteCodigo !== 0) refreshEquipamentos($scope.seltabFiltroPeriodo);

                    $scope.loadingVisible = false;
                    $scope.$apply();
                });
            });
        };

        function refreshAll(semLatest) {
            $scope.loadingVisible = true;

            if (!semLatest || !$scope.visaoGeralDiaDate) {
                ApiGetService
                    .getagricolaColheitaVisaoGeralMinMaxDiaPromise(1)
                    .then(function(data) {
                        $scope.visaoGeralSafra = data.safra;
                        $scope.visaoGeralDiaMinDate = pureDate(data.minDia);
                        $scope.visaoGeralDiaMaxDate = pureDate(data.maxDia);

                        $scope.visaoGeralDiaDate = pureDate(data.maxDia);

                        $scope.visaoGeralDiaMaxDisplay = $scope.visaoGeralDiaMaxDate.ddmmyyyy();

                        $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();
                        $scope.visaoGeralDiaDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();
                        //$scope.visaoGeralHora = data.maxHora;

                        $scope.visaoGeralSemana = data.maxSemana;
                        $scope.visaoGeralMes = data.maxMes;

                        resolveCharts();
                    });
            } else {
                ApiGetService
                    .getagricolaColheitaVisaoGeralMinMaxCorteDiaPromise(1, $scope.visaoGeralDiaDate.yyyymmdd())
                    .then(function (data) {
                        //$scope.visaoGeralSafra = data.safra;
                        //$scope.visaoGeralDiaMinDate = pureDate(data.minDia);
                        //$scope.visaoGeralDiaMaxDate = pureDate(data.maxDia);

                        $scope.visaoGeralDiaMaxDisplay = pureDate(data.maxDia).ddmmyyyy();

                        $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();
                        $scope.visaoGeralDiaDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();
                        //$scope.visaoGeralHora = data.maxHora;

                        $scope.visaoGeralSemana = data.maxSemana;
                        $scope.visaoGeralMes = data.maxMes;

                        resolveCharts();
                    });
            }
        };

        function refreshPorDia() {
            if (!$scope.visaoGeralDiaDate) {
                ApiGetService
                    .getagricolaColheitaVisaoGeralMinMaxDiaPromise(1)
                    .then(function (data) {
                        $scope.visaoGeralSafra = data.safra;
                        $scope.visaoGeralDiaMinDate = pureDate(data.minDia);
                        $scope.visaoGeralDiaMaxDate = pureDate(data.maxDia);

                        $scope.visaoGeralDiaDate = pureDate(data.maxDia);

                        $scope.visaoGeralDiaMaxDisplay = $scope.visaoGeralDiaMaxDate.ddmmyyyy();

                        $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();
                        $scope.visaoGeralDiaDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();

                        $scope.visaoGeralSemana = data.maxSemana;
                        $scope.visaoGeralMes = data.maxMes;

                        ApiGetService
                            .getagricolaColheitaPorDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia)
                            .then(function (data) {
                                //Entrega Cana
                                $scope.dsChartEntregaCanaPorDia = data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorDia = "Entrega de Cana";

                                var frentesEntregaCanaArray = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);

                                $scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaArray;
                                $scope.seltabFiltroFrentesEntregaCana = data.oFrentesEntregaCana.length - 1;

                                $scope.frenteEntregaCanaAtual = frentesEntregaCanaArray[data.oFrentesEntregaCana.length - 1];
                                $scope.frenteAtual = frentesEntregaCanaArray[data.oFrentesEntregaCana.length - 1];

                                $scope.horaAtual = data.horaAtual;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                $scope.entregaPlanejadaTotal = data.entregaPlanejadaTotal;
                                $scope.entregaPlanejadaTotalDisplay = data.entregaPlanejadaTotal.toLocaleString();

                                $scope.entregaPlanejadaAcumulada = data.entregaPlanejadaAcumulada;
                                $scope.entregaPlanejadaAcumuladaDisplay = data.entregaPlanejadaAcumulada.toLocaleString();

                                $scope.media = data.media;
                                $scope.mediaDisplay = data.media.toLocaleString();

                                $scope.estoquePatio = data.estoquePatio;
                                $scope.estoquePatioDisplay = data.estoquePatio.toLocaleString();

                                $scope.desvio = data.desvio;
                                $scope.desvioDisplay = data.desvio.toLocaleString();


                                //Densidade Carga
                                $scope.dsChartDensidadeCargaPorDia = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorDia = "Densidade de Carga";

                                $scope.minYChartDensidadeCarga = data.graficoDensidadeCargaYMin;
                                $scope.maxYChartDensidadeCarga = data.graficoDensidadeCargaYMax;
                                $scope.tickYChartDensidadeCarga = data.graficoDensidadeCargaYInc;
                                console.log($scope.maxYChartDensidadeCarga);

                                var frentesDensidadeCargaArray = frentesDensidadeCargaDataSource(data.oFrentesDensidadeCarga);

                                $scope.tabFiltroFrentesDensidadeCargaDataSource = frentesDensidadeCargaArray;
                                $scope.seltabFiltroFrentesDensidadeCarga = data.oFrentesDensidadeCarga.length - 1;

                                $scope.frenteDensidadeCargaAtual = frentesDensidadeCargaArray[data.oFrentesDensidadeCarga.length - 1];
                                $scope.frenteAtual = frentesDensidadeCargaArray[data.oFrentesDensidadeCarga.length - 1];

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();


                                $scope.loadingVisible = false;
                            });
                    });
            } else {
                ApiGetService
                    .getagricolaColheitaVisaoGeralMinMaxCorteDiaPromise(1, $scope.visaoGeralDiaDate.yyyymmdd())
                    .then(function(data) {
                        //$scope.visaoGeralSafra = data.safra;
                        //$scope.visaoGeralDiaMinDate = pureDate(data.minDia);
                        //$scope.visaoGeralDiaMaxDate = pureDate(data.maxDia);

                        $scope.visaoGeralDiaMaxDisplay = pureDate(data.maxDia).ddmmyyyy();

                        $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();
                        $scope.visaoGeralDiaDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();
                        $scope.horaAtual = data.horaAtual;

                        $scope.visaoGeralSemana = data.maxSemana;
                        $scope.visaoGeralMes = data.maxMes;

                        ApiGetService
                            .getagricolaColheitaPorDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia)
                            .then(function (data) {
                                //Entrega Cana
                                $scope.dsChartEntregaCanaPorDia = data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorDia = "Entrega de Cana";

                                var frentesEntregaCanaArray = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);

                                $scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaArray;
                                $scope.seltabFiltroFrentesEntregaCana = data.oFrentesEntregaCana.length - 1;

                                $scope.frenteEntregaCanaAtual = frentesEntregaCanaArray[data.oFrentesEntregaCana.length - 1];
                                $scope.frenteAtual = frentesEntregaCanaArray[data.oFrentesEntregaCana.length - 1];

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                $scope.entregaPlanejadaTotal = data.entregaPlanejadaTotal;
                                $scope.entregaPlanejadaTotalDisplay = data.entregaPlanejadaTotal.toLocaleString();

                                $scope.entregaPlanejadaAcumulada = data.entregaPlanejadaAcumulada;
                                $scope.entregaPlanejadaAcumuladaDisplay = data.entregaPlanejadaAcumulada.toLocaleString();

                                $scope.media = data.media;
                                $scope.mediaDisplay = data.media.toLocaleString();

                                $scope.estoquePatio = data.estoquePatio;
                                $scope.estoquePatioDisplay = data.estoquePatio.toLocaleString();

                                $scope.desvio = data.desvio;
                                $scope.desvioDisplay = data.desvio.toLocaleString();

                                //Densidade Carga
                                $scope.dsChartDensidadeCargaPorDia = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorDia = "Densidade de Carga";

                                $scope.minYChartDensidadeCarga = data.graficoDensidadeCargaYMin;
                                $scope.maxYChartDensidadeCarga = data.graficoDensidadeCargaYMax;
                                $scope.tickYChartDensidadeCarga = data.graficoDensidadeCargaYInc;

                                var frentesDensidadeCargaArray = frentesDensidadeCargaDataSource(data.oFrentesDensidadeCarga);

                                $scope.tabFiltroFrentesDensidadeCargaDataSource = frentesDensidadeCargaArray;
                                $scope.seltabFiltroFrentesDensidadeCarga = data.oFrentesDensidadeCarga.length - 1;

                                $scope.frenteDensidadeCargaAtual = frentesDensidadeCargaArray[data.oFrentesDensidadeCarga.length - 1];
                                $scope.frenteAtual = frentesDensidadeCargaArray[data.oFrentesDensidadeCarga.length - 1];

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();


                                $scope.loadingVisible = false;
                            });
                        
                    });
            };
        };

        $scope.autoRefreshButtonType = !window.localStorage.getItem("bi4tAgr01ar") || window.localStorage.getItem("bi4tAgr01ar") == 0 ? 'success' : 'normal';

        angular.element(document).ready(function () {
            //ORDEM: 2 - Document Ready Angular

            Globalize.culture("pt-BR");

            refreshPorDia();

            $scope.interval = null;

            if (!window.localStorage.getItem("bi4tAgr01ar")) {
                window.localStorage.setItem("bi4tAgr01ar", 0);
                window.localStorage.setItem("bi4tAgr01arsec", 60);
            };

            $scope.autoRefresh = (window.localStorage.getItem("bi4tAgr01ar") == 0);
            $scope.autoRefreshSeconds = window.localStorage.getItem("bi4tAgr01arsec");

            if ($scope.autoRefresh) {
                $scope.interval = setInterval(refreshAll, $scope.autoRefreshSeconds * 1000);
            } else {
                clearInterval($scope.interval);
            };

            $scope.autoRefreshButtonIcon = $scope.autoRefresh ? 'check' : 'remove';
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

                window.localStorage.setItem("bi4tAgr01ar", $scope.autoRefresh ? 0 : 1);
                window.localStorage.setItem("bi4tAgr01arsec", $scope.autoRefreshSeconds);

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

        $scope.dateBoxOptions = {
            type: "date",
            bindingOptions: {
                value: 'visaoGeralDiaDate',
                max: 'visaoGeralDiaMaxDate',
                min: 'visaoGeralDiaMinDate'
            },
            formatString: 'dd/MM/yyyy',
            readOnly: false,
            invalidDateMessage: 'Conteúdo deve ser uma data válida',
            dateOutOfRangeMessage: 'Data está fora do período',
            onValueChanged: function (e) {
                if (e.previousValue !== undefined) {
                    $scope.loadingVisible = true;

                    $scope.seltabFiltroPeriodo = 0;

                    refreshPorDia();
                };
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
                $scope.frenteAtual = $scope.frenteEntregaCanaAtual;

                resolveCharts();

                //resolveChartEntregaCana($scope.frenteEntregaCanaAtual, $scope.seltabFiltroPeriodo, true).then(function() {
                //    $scope.seltabFiltroFrentesEntregaCana = $scope.tabFiltroFrentesEntregaCanaDataSource.length - 1;

                //    coloreTabsFrentes($("#tabFrEntCana"), $scope.tabFiltroFrentesEntregaCanaDataSource);

                //    resolveChartDensidadeCarga($scope.frenteDensidadeCargaAtual, $scope.seltabFiltroPeriodo, true).then(function () {
                //        $scope.seltabFiltroFrentesDensidadeCarga = $scope.tabFiltroFrentesDensidadeCargaDataSource.length - 1;

                //        coloreTabsFrentes($("#tabFrDensCarga"), $scope.tabFiltroFrentesDensidadeCargaDataSource);

                //        $scope.loadingVisible = false;
                //        $scope.$apply();
                //    });
                //});
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

        function datasourceDadosMes(data) {
            var datasourceMes = [];

            for (var i = 0; i < data.length; i++) {
                //console.log(pureDate(data[i].semanaPeriodo.diaInicio).ddmmyyyy());
                datasourceMes.push($.extend(data[i],
                    { semanaPeriodoDisplay: pureDate(data[i].semanaPeriodo.diaInicio).ddmmyyyy() + ' a ' + pureDate(data[i].semanaPeriodo.diaFim).ddmmyyyy() }
                ));                
            }

            return datasourceMes;
        };

        function resolveChartEntregaCana(frenteEntregaCana, filtroPeriodo, refazFrentesDataSource) {
            var promise = new Promise(function (resolve, reject) {
                if (!frenteEntregaCana.frenteCodigo || frenteEntregaCana.frenteCodigo == 0) {
                    //Frentes GERAL
                    if (filtroPeriodo == 0) {
                        //Período Dia
                        ApiGetService
                            .getagricolaColheitaPorDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorDia = data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorDia = "Entrega de Cana";

                                $scope.horaAtual = data.horaAtual;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                $scope.entregaPlanejadaTotal = data.entregaPlanejadaTotal;
                                $scope.entregaPlanejadaTotalDisplay = data.entregaPlanejadaTotal.toLocaleString();

                                $scope.entregaPlanejadaAcumulada = data.entregaPlanejadaAcumulada;
                                $scope.entregaPlanejadaAcumuladaDisplay = data.entregaPlanejadaAcumulada.toLocaleString();

                                $scope.media = data.media;
                                $scope.mediaDisplay = data.media.toLocaleString();

                                $scope.desvio = data.desvio;
                                $scope.desvioDisplay = data.desvio.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesEntregaCana = -1;
                                    $scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);                                    
                                };

                                resolve();
                            });
                    } else if (filtroPeriodo == 1) {
                        //Período Semana
                        ApiGetService
                            .getagricolaColheitaPorSemanaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralSemana)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorSemana = data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorSemana = "Entrega de Cana";

                                $scope.horaAtual = data.horaAtual;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                $scope.entregaPlanejadaTotal = data.entregaPlanejadaTotal;
                                $scope.entregaPlanejadaTotalDisplay = data.entregaPlanejadaTotal.toLocaleString();

                                $scope.entregaPlanejadaAcumulada = data.entregaPlanejadaAcumulada;
                                $scope.entregaPlanejadaAcumuladaDisplay = data.entregaPlanejadaAcumulada.toLocaleString();

                                $scope.media = data.media;
                                $scope.mediaDisplay = data.media.toLocaleString();

                                $scope.desvio = data.desvio;
                                $scope.desvioDisplay = data.desvio.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesEntregaCana = -1;
                                    $scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);
                                };

                                resolve();
                            });
                    } else if (filtroPeriodo == 2) {
                        //Período Mês
                        ApiGetService
                            .getagricolaColheitaPorMesPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralMes)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorMes = datasourceDadosMes(data.oGraficoEntregaCanaAcumulado);
                                console.log($scope.dsChartEntregaCanaPorMes);
                                $scope.titleChartEntregaCanaPorMes = "Entrega de Cana";

                                $scope.horaAtual = data.horaAtual;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                $scope.entregaPlanejadaTotal = data.entregaPlanejadaTotal;
                                $scope.entregaPlanejadaTotalDisplay = data.entregaPlanejadaTotal.toLocaleString();

                                $scope.entregaPlanejadaAcumulada = data.entregaPlanejadaAcumulada;
                                $scope.entregaPlanejadaAcumuladaDisplay = data.entregaPlanejadaAcumulada.toLocaleString();

                                $scope.media = data.media;
                                $scope.mediaDisplay = data.media.toLocaleString();

                                $scope.desvio = data.desvio;
                                $scope.desvioDisplay = data.desvio.toLocaleString();

                                if (refazFrentesDataSource) {
                                    $scope.seltabFiltroFrentesEntregaCana = -1;
                                    $scope.tabFiltroFrentesEntregaCanaDataSource = frentesEntregaCanaDataSource(data.oFrentesEntregaCana);
                                };

                                resolve();
                            });
                    } else if (filtroPeriodo == 3) {
                        //Período Safra
                        ApiGetService
                            .getagricolaColheitaPorSafraPromise(1, $scope.visaoGeralSafra)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorSafra = data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorSafra = "Entrega de Cana";

                                $scope.horaAtual = data.horaAtual;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                $scope.entregaPlanejadaTotal = data.entregaPlanejadaTotal;
                                $scope.entregaPlanejadaTotalDisplay = data.entregaPlanejadaTotal.toLocaleString();

                                $scope.entregaPlanejadaAcumulada = data.entregaPlanejadaAcumulada;
                                $scope.entregaPlanejadaAcumuladaDisplay = data.entregaPlanejadaAcumulada.toLocaleString();

                                $scope.media = data.media;
                                $scope.mediaDisplay = data.media.toLocaleString();

                                $scope.desvio = data.desvio;
                                $scope.desvioDisplay = data.desvio.toLocaleString();

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
                            .getagricolaColheitaPorDiaPorFrentePromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia, frenteEntregaCana.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorDia = data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorDia = "Entrega de Cana " + frenteEntregaCana.text;

                                $scope.horaAtual = data.horaAtual;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                $scope.entregaPlanejadaTotal = data.entregaPlanejadaTotal;
                                $scope.entregaPlanejadaTotalDisplay = data.entregaPlanejadaTotal.toLocaleString();

                                $scope.entregaPlanejadaAcumulada = data.entregaPlanejadaAcumulada;
                                $scope.entregaPlanejadaAcumuladaDisplay = data.entregaPlanejadaAcumulada.toLocaleString();

                                $scope.media = data.media;
                                $scope.mediaDisplay = data.media.toLocaleString();

                                $scope.desvio = data.desvio;
                                $scope.desvioDisplay = data.desvio.toLocaleString();

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
                            .getagricolaColheitaPorSemanaPorFrentePromise(1, $scope.visaoGeralSafra, $scope.visaoGeralSemana, frenteEntregaCana.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorSemana = data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorSemana = "Entrega de Cana " + frenteEntregaCana.text;

                                $scope.horaAtual = data.horaAtual;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                $scope.entregaPlanejadaTotal = data.entregaPlanejadaTotal;
                                $scope.entregaPlanejadaTotalDisplay = data.entregaPlanejadaTotal.toLocaleString();

                                $scope.entregaPlanejadaAcumulada = data.entregaPlanejadaAcumulada;
                                $scope.entregaPlanejadaAcumuladaDisplay = data.entregaPlanejadaAcumulada.toLocaleString();

                                $scope.media = data.media;
                                $scope.mediaDisplay = data.media.toLocaleString();

                                $scope.desvio = data.desvio;
                                $scope.desvioDisplay = data.desvio.toLocaleString();

                                $scope.titleChartImpurezaVegetalPorSemana = "Impureza Vegetal " + frenteEntregaCana.text;
                                $scope.dsChartImpurezaVegetalPorSemana = data.oGraficoImpurezaVegetal;

                                $scope.titleChartImpurezaMineralPorSemana = "Impureza Mineral " + frenteEntregaCana.text;
                                $scope.dsChartImpurezaMineralPorSemana = data.oGraficoImpurezaMineral;

                                $scope.titleChartVelocidadeMediaPorSemana = "Velocidade Média " + frenteEntregaCana.text;
                                $scope.dsChartVelocidadeMediaPorSemana = data.oGraficoVelocidadeMedia;

                                resolve();
                            });
                    } else if (filtroPeriodo == 2) {
                        //Período Mês
                        ApiGetService
                            .getagricolaColheitaPorMesPorFrentePromise(1, $scope.visaoGeralSafra, $scope.visaoGeralMes, frenteEntregaCana.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorMes = datasourceDadosMes(data.oGraficoEntregaCanaAcumulado);
                                $scope.titleChartEntregaCanaPorMes = "Entrega de Cana " + frenteEntregaCana.text;

                                $scope.horaAtual = data.horaAtual;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                $scope.entregaPlanejadaTotal = data.entregaPlanejadaTotal;
                                $scope.entregaPlanejadaTotalDisplay = data.entregaPlanejadaTotal.toLocaleString();

                                $scope.entregaPlanejadaAcumulada = data.entregaPlanejadaAcumulada;
                                $scope.entregaPlanejadaAcumuladaDisplay = data.entregaPlanejadaAcumulada.toLocaleString();

                                $scope.media = data.media;
                                $scope.mediaDisplay = data.media.toLocaleString();

                                $scope.desvio = data.desvio;
                                $scope.desvioDisplay = data.desvio.toLocaleString();

                                $scope.titleChartImpurezaVegetalPorMes = "Impureza Vegetal " + frenteEntregaCana.text;
                                $scope.dsChartImpurezaVegetalPorMes = datasourceDadosMes(data.oGraficoImpurezaVegetal);

                                $scope.titleChartImpurezaMineralPorMes = "Impureza Mineral " + frenteEntregaCana.text;
                                $scope.dsChartImpurezaMineralPorMes = datasourceDadosMes(data.oGraficoImpurezaMineral);

                                $scope.titleChartVelocidadeMediaPorMes = "Velocidade Média " + frenteEntregaCana.text;
                                $scope.dsChartVelocidadeMediaPorMes = datasourceDadosMes(data.oGraficoVelocidadeMedia);

                                resolve();
                            });
                    } else if (filtroPeriodo == 3) {
                        //Período Safra
                        ApiGetService
                            .getagricolaColheitaPorSafraPorFrentePromise(1, $scope.visaoGeralSafra, frenteEntregaCana.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartEntregaCanaPorSafra = data.oGraficoEntregaCanaAcumulado;
                                $scope.titleChartEntregaCanaPorSafra = "Entrega de Cana " + frenteEntregaCana.text;

                                $scope.horaAtual = data.horaAtual;

                                $scope.entregaAcumulada = data.entregaAcumulada;
                                $scope.entregaAcumuladaDisplay = data.entregaAcumulada.toLocaleString();

                                $scope.entregaPlanejadaTotal = data.entregaPlanejadaTotal;
                                $scope.entregaPlanejadaTotalDisplay = data.entregaPlanejadaTotal.toLocaleString();

                                $scope.entregaPlanejadaAcumulada = data.entregaPlanejadaAcumulada;
                                $scope.entregaPlanejadaAcumuladaDisplay = data.entregaPlanejadaAcumulada.toLocaleString();

                                $scope.media = data.media;
                                $scope.mediaDisplay = data.media.toLocaleString();

                                $scope.desvio = data.desvio;
                                $scope.desvioDisplay = data.desvio.toLocaleString();

                                $scope.titleChartImpurezaVegetalPorSafra = "Impureza Vegetal " + frenteEntregaCana.text;
                                $scope.dsChartImpurezaVegetalPorSafra = data.oGraficoImpurezaVegetal;

                                $scope.titleChartImpurezaMineralPorSafra = "Impureza Mineral " + frenteEntregaCana.text;
                                $scope.dsChartImpurezaMineralPorSafra = data.oGraficoImpurezaMineral;

                                $scope.titleChartVelocidadeMediaPorSafra = "Velocidade Média " + frenteEntregaCana.text;
                                $scope.dsChartVelocidadeMediaPorSafra = data.oGraficoVelocidadeMedia;

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
                $scope.frenteAtual = e.itemData;

                resolveChartEntregaCana($scope.frenteAtual, $scope.seltabFiltroPeriodo, false).then(function () {
                    $scope.colhedoraFrenteMostrar = true;
                    $scope.tratorFrenteMostrar = true;

                    refreshEquipamentos($scope.seltabFiltroPeriodo);
                    $scope.equipamentosComDados = true;

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
                if (!frenteDensidadeCarga.frenteCodigo || frenteDensidadeCarga.frenteCodigo == 0) {
                    //Frentes GERAL
                    if (filtroPeriodo == 0) {
                        //Período Dia
                        ApiGetService
                            .getagricolaColheitaPorDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorDia = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorDia = "Densidade de Carga";

                                $scope.minYChartDensidadeCarga = data.graficoDensidadeCargaYMin;
                                $scope.maxYChartDensidadeCarga = data.graficoDensidadeCargaYMax;
                                $scope.tickYChartDensidadeCarga = data.graficoDensidadeCargaYInc;

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
                            .getagricolaColheitaPorSemanaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralSemana)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorSemana = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorSemana = "Densidade de Carga";

                                $scope.minYChartDensidadeCarga = data.graficoDensidadeCargaYMin;
                                $scope.maxYChartDensidadeCarga = data.graficoDensidadeCargaYMax;
                                $scope.tickYChartDensidadeCarga = data.graficoDensidadeCargaYInc;

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
                            .getagricolaColheitaPorMesPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralMes)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorMes = datasourceDadosMes(data.oGraficoDensidadeCarga);
                                $scope.titleChartDensidadeCargaPorMes = "Densidade de Carga";

                                $scope.minYChartDensidadeCarga = data.graficoDensidadeCargaYMin;
                                $scope.maxYChartDensidadeCarga = data.graficoDensidadeCargaYMax;
                                $scope.tickYChartDensidadeCarga = data.graficoDensidadeCargaYInc;

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
                            .getagricolaColheitaPorSafraPromise(1, $scope.visaoGeralSafra)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorSafra = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorSafra = "Densidade de Carga";

                                $scope.minYChartDensidadeCarga = data.graficoDensidadeCargaYMin;
                                $scope.maxYChartDensidadeCarga = data.graficoDensidadeCargaYMax;
                                $scope.tickYChartDensidadeCarga = data.graficoDensidadeCargaYInc;

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
                            .getagricolaColheitaPorDiaPorFrentePromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia, frenteDensidadeCarga.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorDia = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorDia = "Densidade de Carga " + frenteDensidadeCarga.text;

                                $scope.minYChartDensidadeCarga = data.graficoDensidadeCargaYMin;
                                $scope.maxYChartDensidadeCarga = data.graficoDensidadeCargaYMax;
                                $scope.tickYChartDensidadeCarga = data.graficoDensidadeCargaYInc;

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                $scope.titleChartImpurezaVegetalPorDia = "Impureza Vegetal " + frenteDensidadeCarga.text;
                                $scope.dsChartImpurezaVegetalPorDia = data.oGraficoImpurezaVegetal;

                                $scope.titleChartImpurezaMineralPorDia = "Impureza Mineral " + frenteDensidadeCarga.text;
                                $scope.dsChartImpurezaMineralPorDia = data.oGraficoImpurezaMineral;

                                $scope.titleChartVelocidadeMediaPorDia = "Velocidade Média " + frenteDensidadeCarga.text;
                                $scope.dsChartVelocidadeMediaPorDia = data.oGraficoVelocidadeMedia;

                                resolve();
                            });
                    } else if (filtroPeriodo == 1) {
                        //Período Semana
                        ApiGetService
                            .getagricolaColheitaPorSemanaPorFrentePromise(1, $scope.visaoGeralSafra, $scope.visaoGeralSemana, frenteDensidadeCarga.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorSemana = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorSemana = "Densidade de Carga " + frenteDensidadeCarga.text;

                                $scope.minYChartDensidadeCarga = data.graficoDensidadeCargaYMin;
                                $scope.maxYChartDensidadeCarga = data.graficoDensidadeCargaYMax;
                                $scope.tickYChartDensidadeCarga = data.graficoDensidadeCargaYInc;

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                $scope.titleChartImpurezaVegetalPorSemana = "Impureza Vegetal " + frenteDensidadeCarga.text;
                                $scope.dsChartImpurezaVegetalPorSemana = data.oGraficoImpurezaVegetal;

                                $scope.titleChartImpurezaMineralPorSemana = "Impureza Mineral " + frenteDensidadeCarga.text;
                                $scope.dsChartImpurezaMineralPorSemana = data.oGraficoImpurezaMineral;

                                $scope.titleChartVelocidadeMediaPorSemana = "Velocidade Média " + frenteDensidadeCarga.text;
                                $scope.dsChartVelocidadeMediaPorSemana = data.oGraficoVelocidadeMedia;

                                resolve();
                            });
                    } else if (filtroPeriodo == 2) {
                        //Período Mês
                        ApiGetService
                            .getagricolaColheitaPorMesPorFrentePromise(1, $scope.visaoGeralSafra, $scope.visaoGeralMes, frenteDensidadeCarga.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorMes = datasourceDadosMes(data.oGraficoDensidadeCarga);
                                $scope.titleChartDensidadeCargaPorMes = "Densidade de Carga " + frenteDensidadeCarga.text;

                                $scope.minYChartDensidadeCarga = data.graficoDensidadeCargaYMin;
                                $scope.maxYChartDensidadeCarga = data.graficoDensidadeCargaYMax;
                                $scope.tickYChartDensidadeCarga = data.graficoDensidadeCargaYInc;

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                $scope.titleChartImpurezaVegetalPorMes = "Impureza Vegetal " + frenteDensidadeCarga.text;
                                $scope.dsChartImpurezaVegetalPorMes = datasourceDadosMes(data.oGraficoImpurezaVegetal);

                                $scope.titleChartImpurezaMineralPorMes = "Impureza Mineral " + frenteDensidadeCarga.text;
                                $scope.dsChartImpurezaMineralPorMes = datasourceDadosMes(data.oGraficoImpurezaMineral);

                                $scope.titleChartVelocidadeMediaPorMes = "Velocidade Média " + frenteDensidadeCarga.text;
                                $scope.dsChartVelocidadeMediaPorMes = datasourceDadosMes(data.oGraficoVelocidadeMedia);

                                resolve();
                            });
                    } else if (filtroPeriodo == 3) {
                        //Período Safra
                        ApiGetService
                            .getagricolaColheitaPorSafraPorFrentePromise(1, $scope.visaoGeralSafra, frenteDensidadeCarga.frenteCodigo)
                            .then(function (data) {
                                $scope.dsChartDensidadeCargaPorSafra = data.oGraficoDensidadeCarga;
                                $scope.titleChartDensidadeCargaPorSafra = "Densidade de Carga " + frenteDensidadeCarga.text;

                                $scope.minYChartDensidadeCarga = data.graficoDensidadeCargaYMin;
                                $scope.maxYChartDensidadeCarga = data.graficoDensidadeCargaYMax;
                                $scope.tickYChartDensidadeCarga = data.graficoDensidadeCargaYInc;

                                $scope.densidadeAtual = data.densidadeAtual;
                                $scope.densidadeAtualDisplay = data.densidadeAtual.toLocaleString();

                                $scope.titleChartImpurezaVegetalPorSafra = "Impureza Vegetal " + frenteDensidadeCarga.text;
                                $scope.dsChartImpurezaVegetalPorSafra = data.oGraficoImpurezaVegetal;

                                $scope.titleChartImpurezaMineralPorSafra = "Impureza Mineral " + frenteDensidadeCarga.text;
                                $scope.dsChartImpurezaMineralPorSafra = data.oGraficoImpurezaMineral;

                                $scope.titleChartVelocidadeMediaPorSafra = "Velocidade Média " + frenteDensidadeCarga.text;
                                $scope.dsChartVelocidadeMediaPorSafra = data.oGraficoVelocidadeMedia;

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
                $scope.frenteAtual = e.itemData;

                resolveChartDensidadeCarga($scope.frenteAtual, $scope.seltabFiltroPeriodo, false).then(function () {
                    $scope.colhedoraFrenteMostrar = true;
                    $scope.tratorFrenteMostrar = true;

                    refreshEquipamentos($scope.seltabFiltroPeriodo);
                    $scope.equipamentosComDados = true;

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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            valueAxis: [
                {
                    name: "entrega",
                    position: "left",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Toneladas"
                    },
                    label: {
                        customizeText: function () {
                            return this.value.toLocaleString();
                        }                        
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
                title: 'titleChartDensidadeCargaPorDia',
                'valueAxis.min': 'minYChartDensidadeCarga',
                'valueAxis.max': 'maxYChartDensidadeCarga',
                'valueAxis.tickInterval': 'tickYChartDensidadeCarga'
            },
            argumentAxis: {
                argumentType: 'datetime',
                label: {
                    format: 'HH'
                },
                tickInterval: { hours: 1 }
            },
            valueAxis: {
                label: {
                    overlappingBehavior: {
                        mode: 'ignore'
                    },
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                }
            },
            commonSeriesSettings: {
                argumentField: "DIA",
                type: "line",
                point: {
                    size: 6
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            valueAxis: [
                {
                    name: "entrega",
                    position: "left",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Toneladas"
                    },
                    label: {
                        customizeText: function () {
                            return this.value.toLocaleString();
                        }
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
                title: 'titleChartDensidadeCargaPorSemana',
                'valueAxis.min': 'minYChartDensidadeCarga',
                'valueAxis.max': 'maxYChartDensidadeCarga',
                'valueAxis.tickInterval': 'tickYChartDensidadeCarga'
            },
            argumentAxis: {
                argumentType: 'datetime',
                label: {
                    format: 'shortDate'
                },
                tickInterval: { days: 1 }
            },
            valueAxis: {
                label: {
                    overlappingBehavior: {
                        mode: 'ignore'
                    },
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                }
            },
            commonSeriesSettings: {
                argumentField: "DIA",
                type: "line",
                point: {
                    size: 6
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartImpurezaVegetalPorSemanaOptions = {
            bindingOptions: {
                dataSource: 'dsChartImpurezaVegetalPorSemana',
                title: 'titleChartImpurezaVegetalPorSemana'
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartImpurezaMineralPorSemanaOptions = {
            bindingOptions: {
                dataSource: 'dsChartImpurezaMineralPorSemana',
                title: 'titleChartImpurezaMineralPorSemana'
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartVelocidadeMediaPorSemanaOptions = {
            bindingOptions: {
                dataSource: 'dsChartVelocidadeMediaPorSemana',
                title: 'titleChartVelocidadeMediaPorSemana'
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
                    size: 6
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            valueAxis: [
                {
                    name: "entrega",
                    position: "left",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Toneladas"
                    },
                    label: {
                        customizeText: function () {
                            return this.value.toLocaleString();
                        }
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
                title: 'titleChartDensidadeCargaPorMes',
                'valueAxis.min': 'minYChartDensidadeCarga',
                'valueAxis.max': 'maxYChartDensidadeCarga',
                'valueAxis.tickInterval': 'tickYChartDensidadeCarga'
            },
            argumentAxis: {
                argumentType: 'string',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            valueAxis: {
                label: {
                    overlappingBehavior: {
                        mode: 'ignore'
                    },
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                }
            },
            commonSeriesSettings: {
                argumentField: "semanaPeriodoDisplay",
                type: "line",
                point: {
                    size: 6
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartImpurezaVegetalPorMesOptions = {
            bindingOptions: {
                dataSource: 'dsChartImpurezaVegetalPorMes',
                title: 'titleChartImpurezaVegetalPorMes'
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
                    size: 6
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartImpurezaMineralPorMesOptions = {
            bindingOptions: {
                dataSource: 'dsChartImpurezaMineralPorMes',
                title: 'titleChartImpurezaMineralPorMes'
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
                    size: 6
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartVelocidadeMediaPorMesOptions = {
            bindingOptions: {
                dataSource: 'dsChartVelocidadeMediaPorMes',
                title: 'titleChartVelocidadeMediaPorMes'
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
                    size: 6
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            valueAxis: [
                {
                    name: "entrega",
                    position: "left",
                    grid: {
                        visible: true
                    },
                    title: {
                        text: "Toneladas"
                    },
                    label: {
                        customizeText: function () {
                            return this.value.toLocaleString();
                        }
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
                title: 'titleChartDensidadeCargaPorSafra',
                'valueAxis.min': 'minYChartDensidadeCarga',
                'valueAxis.max': 'maxYChartDensidadeCarga',
                'valueAxis.tickInterval': 'tickYChartDensidadeCarga'
            },
            argumentAxis: {
                argumentType: 'datetime',
                label: {
                    format: 'month'
                },
                tickInterval: { months: 1 }
            },
            valueAxis: {
                label: {
                    overlappingBehavior: {
                        mode: 'ignore'
                    },
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                }
            },
            commonSeriesSettings: {
                argumentField: "DIA",
                type: "line",
                point: {
                    size: 6
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartImpurezaVegetalPorSafraOptions = {
            bindingOptions: {
                dataSource: 'dsChartImpurezaVegetalPorSafra',
                title: 'titleChartImpurezaVegetalPorSafra'
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartImpurezaMineralPorSafraOptions = {
            bindingOptions: {
                dataSource: 'dsChartImpurezaMineralPorSafra',
                title: 'titleChartImpurezaMineralPorSafra'
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };

        $scope.chartVelocidadeMediaPorSafraOptions = {
            bindingOptions: {
                dataSource: 'dsChartVelocidadeMediaPorSafra',
                title: 'titleChartVelocidadeMediaPorSafra'
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
                { valueField: "PLANEJADO", name: "Planejado" },
                { valueField: "REALIZADO", name: "Realizado" }
            ],
            legend: {
                verticalAlignment: "bottom",
                horizontalAlignment: "center",
                itemTextPosition: "bottom"
            }
        };


        function maxRealizado(equipamentoArray) {
            var realizadoArray = [];

            for (var i = 0; i < equipamentoArray.length; i++) {
                realizadoArray.push(equipamentoArray[i].REALIZADO);
            }

            return Math.max(...realizadoArray);
        };


        function chartEquipamentosMaisMelhorPointColor(pointValue, chartMeta, chartMedia) {
            var pointColor;

            if (pointValue >= chartMeta) {
                pointColor = 'green'; //'#91d04e';
            } else {
                if (pointValue > chartMedia)
                    pointColor = 'yellow'; //'#ffff66';
                else
                    pointColor = '#d30000';
            };

            return pointColor;
        };

        function chartEquipamentosMenosMelhorSemAmareloPointColor(pointValue, chartMeta) {
            var pointColor;

            if (pointValue >= chartMeta) {
                pointColor = '#d30000'; 
            } else 
                pointColor = 'green';

            return pointColor;
        };



        function refreshEquipamentos(filtroPeriodo) {
            if (filtroPeriodo == 0) {
                //Período Dia
                ApiGetService
                    .getagricolaColheitaPorDiaPorFrenteEquipamentoPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia, $scope.frenteAtual.frenteCodigo)
                    .then(function (data) {
                        $scope.dsChartEquipColhedoraVelColheita = data.oGraficoColhedoraI29;
                        $scope.chartEquipColhedoraVelColheitaMedia = data.graficoColhedoraI29Media;
                        $scope.chartEquipColhedoraVelColheitaMeta = data.graficoColhedoraI29Meta;
                        $scope.chartEquipColhedoraVelColheitaMax = maxRealizado(data.oGraficoColhedoraI29) > $scope.chartEquipColhedoraVelColheitaMeta ? undefined : $scope.chartEquipColhedoraVelColheitaMeta;

                        $scope.dsChartEquipColhedoraEquipProd = data.oGraficoColhedoraI30;
                        $scope.chartEquipColhedoraEquipProdMedia = data.graficoColhedoraI30Media;
                        $scope.chartEquipColhedoraEquipProdMeta = data.graficoColhedoraI30Meta;
                        $scope.chartEquipColhedoraEquipProdMax = maxRealizado(data.oGraficoColhedoraI30) > $scope.chartEquipColhedoraEquipProdMeta ? undefined : $scope.chartEquipColhedoraEquipProdMeta;

                        $scope.dsChartEquipColhedoraFaltaTrator = data.oGraficoColhedoraI31;
                        $scope.chartEquipColhedoraFaltaTratorMedia = data.graficoColhedoraI31Media;
                        $scope.chartEquipColhedoraFaltaTratorMeta = data.graficoColhedoraI31Meta;
                        $scope.chartEquipColhedoraFaltaTratorMax = maxRealizado(data.oGraficoColhedoraI31) > $scope.chartEquipColhedoraFaltaTratorMeta ? undefined : $scope.chartEquipColhedoraFaltaTratorMeta;

                        $scope.dsChartEquipColhedoraTempoAprov = data.oGraficoColhedoraI32;
                        $scope.chartEquipColhedoraTempoAprovMedia = data.graficoColhedoraI32Media;
                        $scope.chartEquipColhedoraTempoAprovMeta = data.graficoColhedoraI32Meta;
                        $scope.chartEquipColhedoraTempoAprovMax = maxRealizado(data.oGraficoColhedoraI32) > $scope.chartEquipColhedoraTempoAprovMeta ? undefined : $scope.chartEquipColhedoraTempoAprovMeta;

                        $scope.dsChartEquipColhedoraAprovDistancia = data.oGraficoColhedoraI33;
                        $scope.chartEquipColhedoraAprovDistanciaMedia = data.graficoColhedoraI33Media;
                        $scope.chartEquipColhedoraAprovDistanciaMeta = data.graficoColhedoraI33Meta;
                        $scope.chartEquipColhedoraAprovDistanciaMax = maxRealizado(data.oGraficoColhedoraI33) > $scope.chartEquipColhedoraAprovDistanciaMeta ? undefined : $scope.chartEquipColhedoraAprovDistanciaMeta;

                        $scope.dsChartEquipColhedoraProdutividade = data.oGraficoColhedoraI49;
                        $scope.chartEquipColhedoraProdutividadeMedia = data.graficoColhedoraI49Media;
                        $scope.chartEquipColhedoraProdutividadeMeta = data.graficoColhedoraI49Meta;
                        $scope.chartEquipColhedoraProdutividadeMax = maxRealizado(data.oGraficoColhedoraI49) > $scope.chartEquipColhedoraProdutividadeMeta ? undefined : $scope.chartEquipColhedoraProdutividadeMeta;

                        $scope.dsChartEquipTratorEquipProd = data.oGraficoTratorI30;
                        $scope.chartEquipTratorEquipProdMedia = data.graficoTratorI30Media;
                        $scope.chartEquipTratorEquipProdMeta = data.graficoTratorI30Meta;
                        $scope.chartEquipTratorEquipProdMax = maxRealizado(data.oGraficoTratorI30) > $scope.chartEquipTratorEquipProdMeta ? undefined : $scope.chartEquipTratorEquipProdMeta;

                        $scope.dsChartEquipTratorFilaCarr = data.oGraficoTratorI34;
                        $scope.chartEquipTratorFilaCarrMedia = data.graficoTratorI34Media;
                        $scope.chartEquipTratorFilaCarrMeta = data.graficoTratorI34Meta;
                        $scope.chartEquipTratorFilaCarrMax = maxRealizado(data.oGraficoTratorI34) > $scope.chartEquipTratorFilaCarrMeta ? undefined : $scope.chartEquipTratorFilaCarrMeta;

                        $scope.dsChartEquipTratorFaltaCam = data.oGraficoTratorI35;
                        $scope.chartEquipTratorFaltaCamMedia = data.graficoTratorI35Media;
                        $scope.chartEquipTratorFaltaCamMeta = data.graficoTratorI35Meta;
                        $scope.chartEquipTratorFaltaCamMax = maxRealizado(data.oGraficoTratorI35) > $scope.chartEquipTratorFaltaCamMeta ? undefined : $scope.chartEquipTratorFaltaCamMeta;

                        $scope.equipamentosComDados = true;

                        $scope.loadingVisible = false;
                    });
            } else if (filtroPeriodo == 1) {
                //Período Semana
                ApiGetService
                    .getagricolaColheitaPorSemanaPorFrenteEquipamentoCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralSemana, $scope.frenteAtual.frenteCodigo, $scope.visaoGeralDia)
                    .then(function (data) {
                        $scope.dsChartEquipColhedoraVelColheita = data.oGraficoColhedoraI29;
                        $scope.chartEquipColhedoraVelColheitaMedia = data.graficoColhedoraI29Media;
                        $scope.chartEquipColhedoraVelColheitaMeta = data.graficoColhedoraI29Meta;
                        $scope.chartEquipColhedoraVelColheitaMax = maxRealizado(data.oGraficoColhedoraI29) > $scope.chartEquipColhedoraVelColheitaMeta ? undefined : $scope.chartEquipColhedoraVelColheitaMeta;

                        $scope.dsChartEquipColhedoraEquipProd = data.oGraficoColhedoraI30;
                        $scope.chartEquipColhedoraEquipProdMedia = data.graficoColhedoraI30Media;
                        $scope.chartEquipColhedoraEquipProdMeta = data.graficoColhedoraI30Meta;
                        $scope.chartEquipColhedoraEquipProdMax = maxRealizado(data.oGraficoColhedoraI30) > $scope.chartEquipColhedoraEquipProdMeta ? undefined : $scope.chartEquipColhedoraEquipProdMeta;

                        $scope.dsChartEquipColhedoraFaltaTrator = data.oGraficoColhedoraI31;
                        $scope.chartEquipColhedoraFaltaTratorMedia = data.graficoColhedoraI31Media;
                        $scope.chartEquipColhedoraFaltaTratorMeta = data.graficoColhedoraI31Meta;
                        $scope.chartEquipColhedoraFaltaTratorMax = maxRealizado(data.oGraficoColhedoraI31) > $scope.chartEquipColhedoraFaltaTratorMeta ? undefined : $scope.chartEquipColhedoraFaltaTratorMeta;

                        $scope.dsChartEquipColhedoraTempoAprov = data.oGraficoColhedoraI32;
                        $scope.chartEquipColhedoraTempoAprovMedia = data.graficoColhedoraI32Media;
                        $scope.chartEquipColhedoraTempoAprovMeta = data.graficoColhedoraI32Meta;
                        $scope.chartEquipColhedoraTempoAprovMax = maxRealizado(data.oGraficoColhedoraI32) > $scope.chartEquipColhedoraTempoAprovMeta ? undefined : $scope.chartEquipColhedoraTempoAprovMeta;

                        $scope.dsChartEquipColhedoraAprovDistancia = data.oGraficoColhedoraI33;
                        $scope.chartEquipColhedoraAprovDistanciaMedia = data.graficoColhedoraI33Media;
                        $scope.chartEquipColhedoraAprovDistanciaMeta = data.graficoColhedoraI33Meta;
                        $scope.chartEquipColhedoraAprovDistanciaMax = maxRealizado(data.oGraficoColhedoraI33) > $scope.chartEquipColhedoraAprovDistanciaMeta ? undefined : $scope.chartEquipColhedoraAprovDistanciaMeta;

                        $scope.dsChartEquipColhedoraProdutividade = data.oGraficoColhedoraI49;
                        $scope.chartEquipColhedoraProdutividadeMedia = data.graficoColhedoraI49Media;
                        $scope.chartEquipColhedoraProdutividadeMeta = data.graficoColhedoraI49Meta;
                        $scope.chartEquipColhedoraProdutividadeMax = maxRealizado(data.oGraficoColhedoraI49) > $scope.chartEquipColhedoraProdutividadeMeta ? undefined : $scope.chartEquipColhedoraProdutividadeMeta;

                        $scope.dsChartEquipTratorEquipProd = data.oGraficoTratorI30;
                        $scope.chartEquipTratorEquipProdMedia = data.graficoTratorI30Media;
                        $scope.chartEquipTratorEquipProdMeta = data.graficoTratorI30Meta;
                        $scope.chartEquipTratorEquipProdMax = maxRealizado(data.oGraficoTratorI30) > $scope.chartEquipTratorEquipProdMeta ? undefined : $scope.chartEquipTratorEquipProdMeta;

                        $scope.dsChartEquipTratorFilaCarr = data.oGraficoTratorI34;
                        $scope.chartEquipTratorFilaCarrMedia = data.graficoTratorI34Media;
                        $scope.chartEquipTratorFilaCarrMeta = data.graficoTratorI34Meta;
                        $scope.chartEquipTratorFilaCarrMax = maxRealizado(data.oGraficoTratorI34) > $scope.chartEquipTratorFilaCarrMeta ? undefined : $scope.chartEquipTratorFilaCarrMeta;

                        $scope.dsChartEquipTratorFaltaCam = data.oGraficoTratorI35;
                        $scope.chartEquipTratorFaltaCamMedia = data.graficoTratorI35Media;
                        $scope.chartEquipTratorFaltaCamMeta = data.graficoTratorI35Meta;
                        $scope.chartEquipTratorFaltaCamMax = maxRealizado(data.oGraficoTratorI35) > $scope.chartEquipTratorFaltaCamMeta ? undefined : $scope.chartEquipTratorFaltaCamMeta;

                        $scope.equipamentosComDados = true;

                        $scope.loadingVisible = false;
                    });
            } else if (filtroPeriodo == 2) {
                //Período Mês
                ApiGetService
                    .getagricolaColheitaPorMesPorFrenteEquipamentoCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralMes, $scope.frenteAtual.frenteCodigo, $scope.visaoGeralDia)
                    .then(function (data) {
                        $scope.dsChartEquipColhedoraVelColheita = data.oGraficoColhedoraI29;
                        $scope.chartEquipColhedoraVelColheitaMedia = data.graficoColhedoraI29Media;
                        $scope.chartEquipColhedoraVelColheitaMeta = data.graficoColhedoraI29Meta;
                        $scope.chartEquipColhedoraVelColheitaMax = maxRealizado(data.oGraficoColhedoraI29) > $scope.chartEquipColhedoraVelColheitaMeta ? undefined : $scope.chartEquipColhedoraVelColheitaMeta;

                        $scope.dsChartEquipColhedoraEquipProd = data.oGraficoColhedoraI30;
                        $scope.chartEquipColhedoraEquipProdMedia = data.graficoColhedoraI30Media;
                        $scope.chartEquipColhedoraEquipProdMeta = data.graficoColhedoraI30Meta;
                        $scope.chartEquipColhedoraEquipProdMax = maxRealizado(data.oGraficoColhedoraI30) > $scope.chartEquipColhedoraEquipProdMeta ? undefined : $scope.chartEquipColhedoraEquipProdMeta;

                        $scope.dsChartEquipColhedoraFaltaTrator = data.oGraficoColhedoraI31;
                        $scope.chartEquipColhedoraFaltaTratorMedia = data.graficoColhedoraI31Media;
                        $scope.chartEquipColhedoraFaltaTratorMeta = data.graficoColhedoraI31Meta;
                        $scope.chartEquipColhedoraFaltaTratorMax = maxRealizado(data.oGraficoColhedoraI31) > $scope.chartEquipColhedoraFaltaTratorMeta ? undefined : $scope.chartEquipColhedoraFaltaTratorMeta;

                        $scope.dsChartEquipColhedoraTempoAprov = data.oGraficoColhedoraI32;
                        $scope.chartEquipColhedoraTempoAprovMedia = data.graficoColhedoraI32Media;
                        $scope.chartEquipColhedoraTempoAprovMeta = data.graficoColhedoraI32Meta;
                        $scope.chartEquipColhedoraTempoAprovMax = maxRealizado(data.oGraficoColhedoraI32) > $scope.chartEquipColhedoraTempoAprovMeta ? undefined : $scope.chartEquipColhedoraTempoAprovMeta;

                        $scope.dsChartEquipColhedoraAprovDistancia = data.oGraficoColhedoraI33;
                        $scope.chartEquipColhedoraAprovDistanciaMedia = data.graficoColhedoraI33Media;
                        $scope.chartEquipColhedoraAprovDistanciaMeta = data.graficoColhedoraI33Meta;
                        $scope.chartEquipColhedoraAprovDistanciaMax = maxRealizado(data.oGraficoColhedoraI33) > $scope.chartEquipColhedoraAprovDistanciaMeta ? undefined : $scope.chartEquipColhedoraAprovDistanciaMeta;

                        $scope.dsChartEquipColhedoraProdutividade = data.oGraficoColhedoraI49;
                        $scope.chartEquipColhedoraProdutividadeMedia = data.graficoColhedoraI49Media;
                        $scope.chartEquipColhedoraProdutividadeMeta = data.graficoColhedoraI49Meta;
                        $scope.chartEquipColhedoraProdutividadeMax = maxRealizado(data.oGraficoColhedoraI49) > $scope.chartEquipColhedoraProdutividadeMeta ? undefined : $scope.chartEquipColhedoraProdutividadeMeta;

                        $scope.dsChartEquipTratorEquipProd = data.oGraficoTratorI30;
                        $scope.chartEquipTratorEquipProdMedia = data.graficoTratorI30Media;
                        $scope.chartEquipTratorEquipProdMeta = data.graficoTratorI30Meta;
                        $scope.chartEquipTratorEquipProdMax = maxRealizado(data.oGraficoTratorI30) > $scope.chartEquipTratorEquipProdMeta ? undefined : $scope.chartEquipTratorEquipProdMeta;

                        $scope.dsChartEquipTratorFilaCarr = data.oGraficoTratorI34;
                        $scope.chartEquipTratorFilaCarrMedia = data.graficoTratorI34Media;
                        $scope.chartEquipTratorFilaCarrMeta = data.graficoTratorI34Meta;
                        $scope.chartEquipTratorFilaCarrMax = maxRealizado(data.oGraficoTratorI34) > $scope.chartEquipTratorFilaCarrMeta ? undefined : $scope.chartEquipTratorFilaCarrMeta;

                        $scope.dsChartEquipTratorFaltaCam = data.oGraficoTratorI35;
                        $scope.chartEquipTratorFaltaCamMedia = data.graficoTratorI35Media;
                        $scope.chartEquipTratorFaltaCamMeta = data.graficoTratorI35Meta;
                        $scope.chartEquipTratorFaltaCamMax = maxRealizado(data.oGraficoTratorI35) > $scope.chartEquipTratorFaltaCamMeta ? undefined : $scope.chartEquipTratorFaltaCamMeta;

                        $scope.equipamentosComDados = true;

                        $scope.loadingVisible = false;
                    });
            } else if (filtroPeriodo == 3) {
                //Período Safra
                ApiGetService
                    .getagricolaColheitaPorSafraPorFrenteEquipamentoCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.frenteAtual.frenteCodigo, $scope.visaoGeralDia)
                    .then(function (data) {
                        $scope.dsChartEquipColhedoraVelColheita = data.oGraficoColhedoraI29;
                        $scope.chartEquipColhedoraVelColheitaMedia = data.graficoColhedoraI29Media;
                        $scope.chartEquipColhedoraVelColheitaMeta = data.graficoColhedoraI29Meta;
                        $scope.chartEquipColhedoraVelColheitaMax = maxRealizado(data.oGraficoColhedoraI29) > $scope.chartEquipColhedoraVelColheitaMeta ? undefined : $scope.chartEquipColhedoraVelColheitaMeta;

                        $scope.dsChartEquipColhedoraEquipProd = data.oGraficoColhedoraI30;
                        $scope.chartEquipColhedoraEquipProdMedia = data.graficoColhedoraI30Media;
                        $scope.chartEquipColhedoraEquipProdMeta = data.graficoColhedoraI30Meta;
                        $scope.chartEquipColhedoraEquipProdMax = maxRealizado(data.oGraficoColhedoraI30) > $scope.chartEquipColhedoraEquipProdMeta ? undefined : $scope.chartEquipColhedoraEquipProdMeta;

                        $scope.dsChartEquipColhedoraFaltaTrator = data.oGraficoColhedoraI31;
                        $scope.chartEquipColhedoraFaltaTratorMedia = data.graficoColhedoraI31Media;
                        $scope.chartEquipColhedoraFaltaTratorMeta = data.graficoColhedoraI31Meta;
                        $scope.chartEquipColhedoraFaltaTratorMax = maxRealizado(data.oGraficoColhedoraI31) > $scope.chartEquipColhedoraFaltaTratorMeta ? undefined : $scope.chartEquipColhedoraFaltaTratorMeta;

                        $scope.dsChartEquipColhedoraTempoAprov = data.oGraficoColhedoraI32;
                        $scope.chartEquipColhedoraTempoAprovMedia = data.graficoColhedoraI32Media;
                        $scope.chartEquipColhedoraTempoAprovMeta = data.graficoColhedoraI32Meta;
                        $scope.chartEquipColhedoraTempoAprovMax = maxRealizado(data.oGraficoColhedoraI32) > $scope.chartEquipColhedoraTempoAprovMeta ? undefined : $scope.chartEquipColhedoraTempoAprovMeta;

                        $scope.dsChartEquipColhedoraAprovDistancia = data.oGraficoColhedoraI33;
                        $scope.chartEquipColhedoraAprovDistanciaMedia = data.graficoColhedoraI33Media;
                        $scope.chartEquipColhedoraAprovDistanciaMeta = data.graficoColhedoraI33Meta;
                        $scope.chartEquipColhedoraAprovDistanciaMax = maxRealizado(data.oGraficoColhedoraI33) > $scope.chartEquipColhedoraAprovDistanciaMeta ? undefined : $scope.chartEquipColhedoraAprovDistanciaMeta;

                        $scope.dsChartEquipColhedoraProdutividade = data.oGraficoColhedoraI49;
                        $scope.chartEquipColhedoraProdutividadeMedia = data.graficoColhedoraI49Media;
                        $scope.chartEquipColhedoraProdutividadeMeta = data.graficoColhedoraI49Meta;
                        $scope.chartEquipColhedoraProdutividadeMax = maxRealizado(data.oGraficoColhedoraI49) > $scope.chartEquipColhedoraProdutividadeMeta ? undefined : $scope.chartEquipColhedoraProdutividadeMeta;

                        $scope.dsChartEquipTratorEquipProd = data.oGraficoTratorI30;
                        $scope.chartEquipTratorEquipProdMedia = data.graficoTratorI30Media;
                        $scope.chartEquipTratorEquipProdMeta = data.graficoTratorI30Meta;
                        $scope.chartEquipTratorEquipProdMax = maxRealizado(data.oGraficoTratorI30) > $scope.chartEquipTratorEquipProdMeta ? undefined : $scope.chartEquipTratorEquipProdMeta;

                        $scope.dsChartEquipTratorFilaCarr = data.oGraficoTratorI34;
                        $scope.chartEquipTratorFilaCarrMedia = data.graficoTratorI34Media;
                        $scope.chartEquipTratorFilaCarrMeta = data.graficoTratorI34Meta;
                        $scope.chartEquipTratorFilaCarrMax = maxRealizado(data.oGraficoTratorI34) > $scope.chartEquipTratorFilaCarrMeta ? undefined : $scope.chartEquipTratorFilaCarrMeta;

                        $scope.dsChartEquipTratorFaltaCam = data.oGraficoTratorI35;
                        $scope.chartEquipTratorFaltaCamMedia = data.graficoTratorI35Media;
                        $scope.chartEquipTratorFaltaCamMeta = data.graficoTratorI35Meta;
                        $scope.chartEquipTratorFaltaCamMax = maxRealizado(data.oGraficoTratorI35) > $scope.chartEquipTratorFaltaCamMeta ? undefined : $scope.chartEquipTratorFaltaCamMeta;

                        $scope.equipamentosComDados = true;

                        $scope.loadingVisible = false;
                    });
            }
        };

        $scope.buttonColhedoraFrenteOptions = {
            bindingOptions: {
                text: 'colhedoraFrenteButtonText()',
                icon: 'colhedoraFrenteButtonIcon()'
            },
            width: 180,
            onClick: function () {
                $scope.colhedoraFrenteMostrar = !$scope.colhedoraFrenteMostrar;

                if ($scope.colhedoraFrenteMostrar && !$scope.equipamentosComDados) refreshEquipamentos($scope.seltabFiltroPeriodo);
            }
        }

        $scope.buttonTratorFrenteOptions = {
            bindingOptions: {
                text: 'tratorFrenteButtonText()',
                icon: 'tratorFrenteButtonIcon()'
            },
            width: 180,
            onClick: function () {
                $scope.tratorFrenteMostrar = !$scope.tratorFrenteMostrar;

                if ($scope.tratorFrenteMostrar && !$scope.equipamentosComDados) refreshEquipamentos($scope.seltabFiltroPeriodo);
            }
            
        };

        $scope.chartEquipColhedoraVelColheitaOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraVelColheita',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraVelColheitaMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraVelColheitaMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraVelColheitaMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraVelColheitaMetaText()',
                'valueAxis.max': 'chartEquipColhedoraVelColheitaMax'
            },
            title: 'Velocidade Colheita - Km/h',
            series: {
                type: 'bar',
                argumentField: 'NRO_EQUIPAMENTO',
                valueField: 'REALIZADO'
            },
            argumentAxis: {
                type: 'discrete',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            valueAxis: {
                label: {
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                },
                constantLines: [{
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'left',
                        font: {
                            color: "#8c8cff"
                        }
                    },
                    width: 2,
                    color: "#8c8cff",
                    dashStyle: "solid"
                }, {
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'right',
                        font: {
                            color: "#ff7c7c"
                        }
                    },
                    width: 2,
                    color: "#ff7c7c",
                    dashStyle: "dash"
                }]
            },
            customizePoint: function (point) {
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipColhedoraVelColheitaMeta, $scope.chartEquipColhedoraVelColheitaMedia) };
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
            legend: {
                visible: false
            }
        };

        $scope.chartEquipColhedoraEquipProdOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraEquipProd',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraEquipProdMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraEquipProdMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraEquipProdMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraEquipProdMetaText()',
                'valueAxis.max': 'chartEquipColhedoraEquipProdMax'
            },
            title: 'Equip.Produtivo - %',
            series: {
                type: 'bar',
                argumentField: 'NRO_EQUIPAMENTO',
                valueField: 'REALIZADO'
            },
            argumentAxis: {
                type: 'discrete',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            valueAxis: {
                label: {
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                },
                constantLines: [{
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'left',
                        font: {
                            color: "#8c8cff"
                        }
                    },
                    width: 2,
                    color: "#8c8cff",
                    dashStyle: "solid"
                }, {
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'right',
                        font: {
                            color: "#ff7c7c"
                        }
                    },
                    width: 2,
                    color: "#ff7c7c",
                    dashStyle: "dash"
                }]
            },
            customizePoint: function (point) {
                return { color: chartEquipamentosMaisMelhorPointColor(point.value, $scope.chartEquipColhedoraEquipProdMeta, $scope.chartEquipColhedoraEquipProdMedia) };
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
            legend: {
                visible: false
            }
        };

        $scope.chartEquipColhedoraFaltaTratorOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraFaltaTrator',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraFaltaTratorMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraFaltaTratorMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraFaltaTratorMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraFaltaTratorMetaText()',
                'valueAxis.max': 'chartEquipColhedoraFaltaTratorMax'
            },
            title: 'Falta Trator - Min/h',
            series: {
                type: 'bar',
                argumentField: 'NRO_EQUIPAMENTO',
                valueField: 'REALIZADO'
            },
            argumentAxis: {
                type: 'discrete',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            valueAxis: {
                label: {
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                },
                constantLines: [{
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'left',
                        font: {
                            color: "#8c8cff"
                        }
                    },
                    width: 2,
                    color: "#8c8cff",
                    dashStyle: "solid"
                }, {
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'right',
                        font: {
                            color: "#ff7c7c"
                        }
                    },
                    width: 2,
                    color: "#ff7c7c",
                    dashStyle: "dash"
                }]
            },
            customizePoint: function (point) {
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipColhedoraFaltaTratorMeta) };
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
            legend: {
                visible: false
            }
        };

        $scope.chartEquipColhedoraTempoAprovOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraTempoAprov',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraTempoAprovMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraTempoAprovMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraTempoAprovMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraTempoAprovMetaText()',
                'valueAxis.max': 'chartEquipColhedoraTempoAprovMax'
            },
            title: 'Tempo Aproveitável - %',
            series: {
                type: 'bar',
                argumentField: 'NRO_EQUIPAMENTO',
                valueField: 'REALIZADO'
            },
            argumentAxis: {
                type: 'discrete',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            valueAxis: {
                label: {
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                },
                constantLines: [{
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'left',
                        font: {
                            color: "#8c8cff"
                        }
                    },
                    width: 2,
                    color: "#8c8cff",
                    dashStyle: "solid"
                }, {
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'right',
                        font: {
                            color: "#ff7c7c"
                        }
                    },
                    width: 2,
                    color: "#ff7c7c",
                    dashStyle: "dash"
                }]
            },
            customizePoint: function (point) {
                return { color: chartEquipamentosMaisMelhorPointColor(point.value, $scope.chartEquipColhedoraTempoAprovMeta, $scope.chartEquipColhedoraTempoAprovMedia) };
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
            legend: {
                visible: false
            }
        };

        $scope.chartEquipColhedoraAprovDistanciaOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraAprovDistancia',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraAprovDistanciaMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraAprovDistanciaMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraAprovDistanciaMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraAprovDistanciaMetaText()',
                'valueAxis.max': 'chartEquipColhedoraAprovDistanciaMax'
            },
            title: 'Aproveit.Distância - %',
            series: {
                type: 'bar',
                argumentField: 'NRO_EQUIPAMENTO',
                valueField: 'REALIZADO'
            },
            argumentAxis: {
                type: 'discrete',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            valueAxis: {
                label: {
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                },
                constantLines: [{
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'left',
                        font: {
                            color: "#8c8cff"
                        }
                    },
                    width: 2,
                    color: "#8c8cff",
                    dashStyle: "solid"
                }, {
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'right',
                        font: {
                            color: "#ff7c7c"
                        }
                    },
                    width: 2,
                    color: "#ff7c7c",
                    dashStyle: "dash"
                }]
            },
            customizePoint: function (point) {
                return { color: chartEquipamentosMaisMelhorPointColor(point.value, $scope.chartEquipColhedoraAprovDistanciaMeta, $scope.chartEquipColhedoraAprovDistanciaMedia) };
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
            legend: {
                visible: false
            }
        };

        $scope.chartEquipColhedoraProdutividadeOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraProdutividade',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraProdutividadeMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraProdutividadeMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraProdutividadeMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraProdutividadeMetaText()',
                'valueAxis.max': 'chartEquipColhedoraProdutividadeMax'
            },
            title: 'Produtividade ton/dia',
            series: {
                type: 'bar',
                argumentField: 'NRO_EQUIPAMENTO',
                valueField: 'REALIZADO'
            },
            argumentAxis: {
                type: 'discrete',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            valueAxis: {
                label: {
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                },
                constantLines: [{
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'left',
                        font: {
                            color: "#8c8cff"
                        }
                    },
                    width: 2,
                    color: "#8c8cff",
                    dashStyle: "solid"
                }, {
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'right',
                        font: {
                            color: "#ff7c7c"
                        }
                    },
                    width: 2,
                    color: "#ff7c7c",
                    dashStyle: "dash"
                }]
            },
            customizePoint: function (point) {
                return { color: chartEquipamentosMaisMelhorPointColor(point.value, $scope.chartEquipColhedoraProdutividadeMeta, $scope.chartEquipColhedoraProdutividadeMedia) };
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
            legend: {
                visible: false
            }
        };


        $scope.chartEquipTratorEquipProdOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipTratorEquipProd',
                'valueAxis.constantLines[0].value': 'chartEquipTratorEquipProdMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipTratorEquipProdMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipTratorEquipProdMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipTratorEquipProdMetaText()',
                'valueAxis.max': 'chartEquipTratorEquipProdMax'
            },
            title: 'Equip.Produtivo - %',
            series: {
                type: 'bar',
                argumentField: 'NRO_EQUIPAMENTO',
                valueField: 'REALIZADO'
            },
            argumentAxis: {
                type: 'discrete',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            valueAxis: {
                label: {
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                },
                constantLines: [{
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'left',
                        font: {
                            color: "#8c8cff"
                        }
                    },
                    width: 2,
                    color: "#8c8cff",
                    dashStyle: "solid"
                }, {
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'right',
                        font: {
                            color: "#ff7c7c"
                        }
                    },
                    width: 2,
                    color: "#ff7c7c",
                    dashStyle: "dash"
                }]
            },
            customizePoint: function (point) {
                return { color: chartEquipamentosMaisMelhorPointColor(point.value, $scope.chartEquipTratorEquipProdMeta, $scope.chartEquipTratorEquipProdMedia ) };
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
            legend: {
                visible: false
            }
        };

        $scope.chartEquipTratorFilaCarrOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipTratorFilaCarr',
                'valueAxis.constantLines[0].value': 'chartEquipTratorFilaCarrMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipTratorFilaCarrMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipTratorFilaCarrMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipTratorFilaCarrMetaText()',
                'valueAxis.max': 'chartEquipTratorFilaCarrMax'
            },
            title: 'Fila Carregamento - Min/h',
            series: {
                type: 'bar',
                argumentField: 'NRO_EQUIPAMENTO',
                valueField: 'REALIZADO'
            },
            argumentAxis: {
                type: 'discrete',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            valueAxis: {
                label: {
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                },
                constantLines: [{
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'left',
                        font: {
                            color: "#8c8cff"
                        }
                    },
                    width: 2,
                    color: "#8c8cff",
                    dashStyle: "solid"
                }, {
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'right',
                        font: {
                            color: "#ff7c7c"
                        }
                    },
                    width: 2,
                    color: "#ff7c7c",
                    dashStyle: "dash"
                }]
            },
            customizePoint: function (point) {
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipTratorFilaCarrMeta) };
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
            legend: {
                visible: false
            }
        };

        $scope.chartEquipTratorFaltaCamOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipTratorFaltaCam',
                'valueAxis.constantLines[0].value': 'chartEquipTratorFaltaCamMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipTratorFaltaCamMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipTratorFaltaCamMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipTratorFaltaCamMetaText()',
                'valueAxis.max': 'chartEquipTratorFaltaCamMax'
            },
            title: 'Falta Caminhão - Min/h',
            series: {
                type: 'bar',
                argumentField: 'NRO_EQUIPAMENTO',
                valueField: 'REALIZADO'
            },
            argumentAxis: {
                type: 'discrete',
                label: {
                    overlappingBehavior: {
                        mode: 'stagger'
                    }
                }
            },
            valueAxis: {
                label: {
                    customizeText: function () {
                        return this.value.toLocaleString();
                    }
                },
                constantLines: [{
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'left',
                        font: {
                            color: "#8c8cff"
                        }
                    },
                    width: 2,
                    color: "#8c8cff",
                    dashStyle: "solid"
                }, {
                    label: {
                        position: 'outside',
                        horizontalAlignment: 'right',
                        font: {
                            color: "#ff7c7c"
                        }
                    },
                    width: 2,
                    color: "#ff7c7c",
                    dashStyle: "dash"
                }]
            },
            customizePoint: function (point) {
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipTratorFaltaCamMeta) };
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
            legend: {
                visible: false
            }
        };
    };
})();
