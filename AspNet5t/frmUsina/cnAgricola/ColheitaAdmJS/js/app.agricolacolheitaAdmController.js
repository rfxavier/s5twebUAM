/*! 
* Autor: Renato Ferreira Xavier
* Data: maio/2018
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
        .controller("agricolacolheitaAdmCtrl", ['$scope', '$document', 'ApiGetService', agricolacolheitaAdmCtrl]);

    function agricolacolheitaAdmCtrl($scope, $document, ApiGetService) {
        $scope.loadingVisible = true;

        //#region $scope empty object declarations

        $scope.dsChartEquipColhedoraMotorOcioso = {};
        $scope.chartEquipColhedoraMotorOciosoMedia = 0; //graficoColhedoraI38Media
        $scope.chartEquipColhedoraMotorOciosoMediaText = function () { return "Média: " + $scope.chartEquipColhedoraMotorOciosoMedia.toLocaleString() }
        $scope.chartEquipColhedoraMotorOciosoMeta = 0; //graficoColhedoraI38Meta
        $scope.chartEquipColhedoraMotorOciosoMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraMotorOciosoMeta.toLocaleString() }
        $scope.chartEquipColhedoraMotorOciosoMax = 0;

        $scope.dsChartEquipColhedoraPilotoAutomatico = {};
        $scope.chartEquipColhedoraPilotoAutomaticoMedia = 0; //graficoColhedoraI39Media
        $scope.chartEquipColhedoraPilotoAutomaticoMediaText = function () { return "Média: " + $scope.chartEquipColhedoraPilotoAutomaticoMedia.toLocaleString() }
        $scope.chartEquipColhedoraPilotoAutomaticoMeta = 0; //graficoColhedoraI39Meta
        $scope.chartEquipColhedoraPilotoAutomaticoMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraPilotoAutomaticoMeta.toLocaleString() }
        $scope.chartEquipColhedoraPilotoAutomaticoMax = 0;

        $scope.dsChartEquipColhedoraConsumoOleoHidraulico = {};
        $scope.chartEquipColhedoraConsumoOleoHidraulicoMedia = 0; //graficoColhedoraI40Media
        $scope.chartEquipColhedoraConsumoOleoHidraulicoMediaText = function () { return "Média: " + $scope.chartEquipColhedoraConsumoOleoHidraulicoMedia.toLocaleString() }
        $scope.chartEquipColhedoraConsumoOleoHidraulicoMeta = 0; //graficoColhedoraI40Meta
        $scope.chartEquipColhedoraConsumoOleoHidraulicoMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraConsumoOleoHidraulicoMeta.toLocaleString() }
        $scope.chartEquipColhedoraConsumoOleoHidraulicoMax = 0;

        $scope.dsChartEquipColhedoraConsumoOleoDiesel = {};
        $scope.chartEquipColhedoraConsumoOleoDieselMedia = 0; //graficoColhedoraI41Media
        $scope.chartEquipColhedoraConsumoOleoDieselMediaText = function () { return "Média: " + $scope.chartEquipColhedoraConsumoOleoDieselMedia.toLocaleString() }
        $scope.chartEquipColhedoraConsumoOleoDieselMeta = 0; //graficoColhedoraI41Meta
        $scope.chartEquipColhedoraConsumoOleoDieselMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraConsumoOleoDieselMeta.toLocaleString() }
        $scope.chartEquipColhedoraConsumoOleoDieselMax = 0;

        $scope.dsChartEquipColhedoraColheitabilidade = {};
        $scope.chartEquipColhedoraColheitabilidadeMedia = 0; //graficoColhedoraI42Media
        $scope.chartEquipColhedoraColheitabilidadeMediaText = function () { return "Média: " + $scope.chartEquipColhedoraColheitabilidadeMedia.toLocaleString() }
        $scope.chartEquipColhedoraColheitabilidadeMeta = 0; //graficoColhedoraI42Meta
        $scope.chartEquipColhedoraColheitabilidadeMetaText = function () { return "Meta: " + $scope.chartEquipColhedoraColheitabilidadeMeta.toLocaleString() }
        $scope.chartEquipColhedoraColheitabilidadeMax = 0;

        $scope.gaugeEquipColhedoraEquipamentosOnlineValue = 0;
        $scope.gaugeEquipColhedoraEquipamentosOnlineValueDisplay = "0%";
        $scope.gaugeEquipColhedoraEquipamentosOnlineMeta = 0;

        $scope.dsChartEquipTratorMotorOcioso = {};
        $scope.chartEquipTratorMotorOciosoMedia = 0; //graficoTratorI38Media
        $scope.chartEquipTratorMotorOciosoMediaText = function () { return "Média: " + $scope.chartEquipTratorMotorOciosoMedia.toLocaleString() }
        $scope.chartEquipTratorMotorOciosoMeta = 0; //graficoTratorI38Meta
        $scope.chartEquipTratorMotorOciosoMetaText = function () { return "Meta: " + $scope.chartEquipTratorMotorOciosoMeta.toLocaleString() }
        $scope.chartEquipTratorMotorOciosoMax = 0;

        $scope.dsChartEquipTratorConsumoOleoDiesel = {};
        $scope.chartEquipTratorConsumoOleoDieselMedia = 0; //graficoTratorI41Media
        $scope.chartEquipTratorConsumoOleoDieselMediaText = function () { return "Média: " + $scope.chartEquipTratorConsumoOleoDieselMedia.toLocaleString() }
        $scope.chartEquipTratorConsumoOleoDieselMeta = 0; //graficoTratorI41Meta
        $scope.chartEquipTratorConsumoOleoDieselMetaText = function () { return "Meta: " + $scope.chartEquipTratorConsumoOleoDieselMeta.toLocaleString() }
        $scope.chartEquipTratorConsumoOleoDieselMax = 0;

        $scope.gaugeEquipCaminhaoQuantidadeValue = 0;
        $scope.gaugeEquipCaminhaoQuantidadeValueDisplay = "0";
        $scope.gaugeEquipCaminhaoQuantidadeMeta = 0;

        $scope.gaugeEquipCaminhaoTempoMedioPermanenciaValue = 0;
        $scope.gaugeEquipCaminhaoTempoMedioPermanenciaValueDisplay = "00:00";
        $scope.gaugeEquipCaminhaoTempoMedioPermanenciaMeta = 0;

        $scope.textoColhedoraI43 = "";
        $scope.textoColhedoraI44 = "";
        $scope.textoColhedoraI45 = "";

        $scope.dsChartEquipCaminhaoTempoMedioPermanencia = {};
        $scope.chartEquipCaminhaoTempoMedioPermanenciaMedia = 0; //graficoCaminhaoI37Media
        $scope.chartEquipCaminhaoTempoMedioPermanenciaMediaText = function () { return "Média: " + $scope.chartEquipCaminhaoTempoMedioPermanenciaMedia.toLocaleString() }
        $scope.chartEquipCaminhaoTempoMedioPermanenciaMeta = 0; //graficoCaminhaoI37Meta
        $scope.chartEquipCaminhaoTempoMedioPermanenciaMetaText = function () { return "Meta: " + $scope.chartEquipCaminhaoTempoMedioPermanenciaMeta.toLocaleString() }
        $scope.chartEquipCaminhaoTempoMedioPermanenciaMax = 0;

        $scope.dsChartEquipCanavieiroConsumoOleoDiesel = {};
        $scope.chartEquipCanavieiroConsumoOleoDieselMedia = 0; //graficoCanavieiroI41Media
        $scope.chartEquipCanavieiroConsumoOleoDieselMediaText = function () { return "Média: " + $scope.chartEquipCanavieiroConsumoOleoDieselMedia.toLocaleString() }
        $scope.chartEquipCanavieiroConsumoOleoDieselMeta = 0; //graficoCanavieiroI41Meta
        $scope.chartEquipCanavieiroConsumoOleoDieselMetaText = function () { return "Meta: " + $scope.chartEquipCanavieiroConsumoOleoDieselMeta.toLocaleString() }
        $scope.chartEquipCanavieiroConsumoOleoDieselMax = 0;

        $scope.dsChartEquipEscravoConsumoOleoDiesel = {};
        $scope.chartEquipEscravoConsumoOleoDieselMedia = 0; //graficoEscravoI41Media
        $scope.chartEquipEscravoConsumoOleoDieselMediaText = function () { return "Média: " + $scope.chartEquipEscravoConsumoOleoDieselMedia.toLocaleString() }
        $scope.chartEquipEscravoConsumoOleoDieselMeta = 0; //graficoEscravoI41Meta
        $scope.chartEquipEscravoConsumoOleoDieselMetaText = function () { return "Meta: " + $scope.chartEquipEscravoConsumoOleoDieselMeta.toLocaleString() }
        $scope.chartEquipEscravoConsumoOleoDieselMax = 0;



        $scope.seltabFiltroPeriodo = 0;

        $scope.frenteAtual = {};

        $scope.frentesColheita = true;

        $scope.colhedoraFrenteMostrar = true;
        $scope.colhedoraFrenteButtonText = function () { return "COLHEDORA " + $scope.frenteAtual.text };
        $scope.colhedoraFrenteButtonIcon = function () { return $scope.colhedoraFrenteMostrar ? "chevronup" : "chevrondown" };

        $scope.tratorFrenteMostrar = true;
        $scope.tratorFrenteButtonText = function () { return "TRATOR " + $scope.frenteAtual.text };
        $scope.tratorFrenteButtonIcon = function () { return $scope.tratorFrenteMostrar ? "chevronup" : "chevrondown" };

        $scope.caminhaoFrenteMostrar = true;
        $scope.caminhaoFrenteButtonText = function () { return "CAMINHÃO " + $scope.frenteAtual.text };
        $scope.caminhaoFrenteButtonIcon = function () { return $scope.caminhaoFrenteMostrar ? "chevronup" : "chevrondown" };

        $scope.canavieiroFrenteMostrar = true;
        $scope.canavieiroFrenteButtonText = function () { return "CANAVIEIRO " + $scope.frenteAtual.text };
        $scope.canavieiroFrenteButtonIcon = function () { return $scope.canavieiroFrenteMostrar ? "chevronup" : "chevrondown" };

        $scope.escravoFrenteMostrar = false;
        $scope.escravoFrenteButtonText = function () { return "ESCRAVO " + $scope.frenteAtual.text };
        $scope.escravoFrenteButtonIcon = function () { return $scope.escravoFrenteMostrar ? "chevronup" : "chevrondown" };

        $scope.infoFrenteMostrar = false;
        $scope.infoFrenteButtonText = function () { return "INFORMAÇÕES " + $scope.frenteAtual.text };
        $scope.infoFrenteButtonIcon = function () { return $scope.infoFrenteMostrar ? "chevronup" : "chevrondown" };


        function frentesDataSource(frentes) {
            var frentesArray = [];

            for (var i = 0; i < frentes.length; i++) {
                frentesArray.push({
                    text: frentes[i].frenteDescricao,
                    frenteCodigo: frentes[i].frenteCodigo,
                    indicadorMeta: frentes[i].indicadorMeta
                });
            };

            return frentesArray;
        };

        function refreshAll(refazFrentesDataSource) {
            var promise = new Promise(function(resolve, reject) {
                $scope.loadingVisible = true;

                if ($scope.seltabFiltroPeriodo == 0) {
                    console.log($scope.visaoGeralDia);

                    //Período Semana
                    ApiGetService
                        .getagricolaColheitaAdmPorSemanaCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralSemana, $scope.visaoGeralDia)
                        .then(function (data) {
                            if (refazFrentesDataSource) {
                                var frentesArray = frentesDataSource(data.oFrentes);

                                $scope.tabFiltroFrentesDataSource = frentesArray;

                                $scope.frenteAtual = frentesArray[0];
                            };

                            refreshEquipamentos().then(function () {
                                resolve();
                            });
                        });
                } else if ($scope.seltabFiltroPeriodo == 1) {
                    //Período Mês
                    ApiGetService
                        .getagricolaColheitaAdmPorMesCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralMes, $scope.visaoGeralDia)
                        .then(function (data) {
                            if (refazFrentesDataSource) {
                                var frentesArray = frentesDataSource(data.oFrentes);

                                $scope.tabFiltroFrentesDataSource = frentesArray;

                                $scope.frenteAtual = frentesArray[0];
                            };

                            refreshEquipamentos().then(function () {
                                resolve();
                            });
                        });
                } else if ($scope.seltabFiltroPeriodo == 2) {
                    //Período Safra
                    ApiGetService
                        .getagricolaColheitaAdmPorSafraCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia)
                        .then(function (data) {
                            if (refazFrentesDataSource) {
                                var frentesArray = frentesDataSource(data.oFrentes);

                                $scope.tabFiltroFrentesDataSource = frentesArray;

                                $scope.frenteAtual = frentesArray[0];
                            };

                            refreshEquipamentos().then(function () {
                                resolve();
                            });
                        });
                };
            });

            return promise;
        };

        function refreshPorDia() {
            if (!$scope.visaoGeralDiaDate) {
                ApiGetService
                    .getagricolaColheitaAdmVisaoGeralMinMaxDiaPromise(1)
                    .then(function (data) {
                        $scope.visaoGeralSafra = data.safra;
                        $scope.visaoGeralDiaMinDate = pureDate(data.minDia);
                        $scope.visaoGeralDiaMaxDate = pureDate(data.maxDia);
                        $scope.visaoGeralDiaDate = pureDate(data.maxDia);

                        $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();
                        $scope.visaoGeralDiaMaxDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();

                        $scope.visaoGeralSemana = data.maxSemana;
                        $scope.visaoGeralMes = data.maxMes;
                        console.log($scope.visaoGeralDia);

                        refreshAll(true).then(function () {
                            $scope.seltabFiltroFrentes = 0;

                            $scope.loadingVisible = false;

                            $scope.$apply();
                        });
                    });
            } else {
                ApiGetService
                    .getagricolaColheitaAdmVisaoGeralMinMaxCorteDiaPromise(1, $scope.visaoGeralDiaDate.yyyymmdd())
                    .then(function (data) {
                        console.log(data);

                        //$scope.visaoGeralSafra = data.safra;
                        //$scope.visaoGeralDiaMinDate = pureDate(data.minDia);
                        //$scope.visaoGeralDiaMaxDate = pureDate(data.maxDia);
                        //$scope.visaoGeralDiaDate = pureDate(data.maxDia);
                        $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();

                        $scope.visaoGeralDiaMaxDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();

                        $scope.visaoGeralSemana = data.maxSemana;
                        $scope.visaoGeralMes = data.maxMes;

                        refreshAll(true).then(function () {
                            $scope.seltabFiltroFrentes = 0;

                            $scope.loadingVisible = false;

                            $scope.$apply();
                        });
                    });
                
            };
        };

        $scope.autoRefreshButtonType = !window.localStorage.getItem("bi4tAgr02ar") || window.localStorage.getItem("bi4tAgr02ar") == 0 ? 'success' : 'normal';

        angular.element(document).ready(function () {
            //ORDEM: 2 - Document Ready Angular
            Globalize.culture("pt-BR");

            refreshPorDia();

            $scope.interval = null;

            if (!window.localStorage.getItem("bi4tAgr02ar")) {
                window.localStorage.setItem("bi4tAgr02ar", 0);
                window.localStorage.setItem("bi4tAgr02arsec", 60);
            };

            $scope.autoRefresh = (window.localStorage.getItem("bi4tAgr02ar") == 0);
            $scope.autoRefreshSeconds = window.localStorage.getItem("bi4tAgr02arsec");

            if ($scope.autoRefresh) {
                $scope.interval = setInterval(function() {
                    refreshAll(false).then(function () {
                        $scope.loadingVisible = false;

                        $scope.$apply();
                    });
                }, $scope.autoRefreshSeconds * 1000);
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

                window.localStorage.setItem("bi4tAgr02ar", $scope.autoRefresh ? 0 : 1);
                window.localStorage.setItem("bi4tAgr02arsec", $scope.autoRefreshSeconds);

                if ($scope.autoRefresh) {
                    $scope.interval = setInterval(function() {
                        refreshAll(true).then(function () {
                            $scope.loadingVisible = false;

                            $scope.$apply();
                        });
                    }, $scope.autoRefreshSeconds * 1000);
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

                    $scope.seltabFiltroFrentes = -1;
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
                { text: "Semana" },
                { text: "Mês" },
                { text: "Safra" }
            ],
            bindingOptions: {
                selectedIndex: 'seltabFiltroPeriodo'
            },
            onItemClick: function(e) {
                $scope.loadingVisible = true;

                $scope.seltabFiltroFrentes = -1;

                refreshAll(true).then(function () {
                    $scope.seltabFiltroFrentes = 0;

                    $scope.frentesColheita = !($scope.frenteAtual.frenteCodigo == 33);

                    $scope.colhedoraFrenteMostrar = $scope.frentesColheita;
                    $scope.tratorFrenteMostrar = true;
                    $scope.caminhaoFrenteMostrar = true;

                    $scope.canavieiroFrenteMostrar = !$scope.frentesColheita;
                    $scope.escravoFrenteMostrar = true;

                    $scope.infoFrenteMostrar = false;

                    $scope.loadingVisible = false;

                    $scope.$apply();
                });
            }
        };

        $scope.tabFiltroFrentesOptions = {
            bindingOptions: {
                dataSource: 'tabFiltroFrentesDataSource',
                selectedIndex: 'seltabFiltroFrentes'
            },
            noDataText: "",
            onItemClick: function (e) {
                $scope.loadingVisible = true;

                $scope.frenteAtual = e.itemData;

                $scope.frentesColheita = !($scope.frenteAtual.frenteCodigo == 33);

                $scope.colhedoraFrenteMostrar = $scope.frentesColheita;
                $scope.tratorFrenteMostrar = true;
                $scope.caminhaoFrenteMostrar = true;

                $scope.canavieiroFrenteMostrar = !$scope.frentesColheita;
                $scope.escravoFrenteMostrar = true;

                $scope.infoFrenteMostrar = false;

                refreshEquipamentos().then(function () {
                    $scope.loadingVisible = false;

                    $scope.$apply();
                });
            },
            onContentReady: function (e) {
                
            }
        };


        function maxRealizado(equipamentoArray) {
            var realizadoArray = [];

            for (var i = 0; i < equipamentoArray.length; i++) {
                realizadoArray.push(equipamentoArray[i].REALIZADO);
            }

            return Math.max(...realizadoArray);
        };

        function converteHorasHHMM(horas) {
            var decimalTimeString = horas;
            var n = new Date(0, 0);
            n.setSeconds(+decimalTimeString * 60 * 60);

            return n.toTimeString().slice(0, 5);
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

        function resolveChartsEquipamentos(data) {
            $scope.dsChartEquipColhedoraMotorOcioso = data.oGraficoColhedoraI38;
            $scope.chartEquipColhedoraMotorOciosoMedia = data.graficoColhedoraI38Media;
            $scope.chartEquipColhedoraMotorOciosoMeta = data.graficoColhedoraI38Meta;
            $scope.chartEquipColhedoraMotorOciosoMax = maxRealizado(data.oGraficoColhedoraI38) > $scope.chartEquipColhedoraMotorOciosoMeta ? undefined : $scope.chartEquipColhedoraMotorOciosoMeta;

            $scope.dsChartEquipColhedoraPilotoAutomatico = data.oGraficoColhedoraI39;
            $scope.chartEquipColhedoraPilotoAutomaticoMedia = data.graficoColhedoraI39Media;
            $scope.chartEquipColhedoraPilotoAutomaticoMeta = data.graficoColhedoraI39Meta;
            $scope.chartEquipColhedoraPilotoAutomaticoMax = maxRealizado(data.oGraficoColhedoraI39) > $scope.chartEquipColhedoraPilotoAutomaticoMeta ? undefined : $scope.chartEquipColhedoraPilotoAutomaticoMeta;

            $scope.dsChartEquipColhedoraConsumoOleoHidraulico = data.oGraficoColhedoraI40;
            $scope.chartEquipColhedoraConsumoOleoHidraulicoMedia = data.graficoColhedoraI40Media;
            $scope.chartEquipColhedoraConsumoOleoHidraulicoMeta = data.graficoColhedoraI40Meta;
            $scope.chartEquipColhedoraConsumoOleoHidraulicoMax = maxRealizado(data.oGraficoColhedoraI40) > $scope.chartEquipColhedoraConsumoOleoHidraulicoMeta ? undefined : $scope.chartEquipColhedoraConsumoOleoHidraulicoMeta;

            $scope.dsChartEquipColhedoraConsumoOleoDiesel = data.oGraficoColhedoraI41;
            $scope.chartEquipColhedoraConsumoOleoDieselMedia = data.graficoColhedoraI41Media;
            $scope.chartEquipColhedoraConsumoOleoDieselMeta = data.graficoColhedoraI41Meta;
            $scope.chartEquipColhedoraConsumoOleoDieselMax = maxRealizado(data.oGraficoColhedoraI41) > $scope.chartEquipColhedoraConsumoOleoDieselMeta ? undefined : $scope.chartEquipColhedoraConsumoOleoDieselMeta;

            $scope.dsChartEquipColhedoraColheitabilidade = data.oGraficoColhedoraI42;
            $scope.chartEquipColhedoraColheitabilidadeMedia = data.graficoColhedoraI42Media;
            $scope.chartEquipColhedoraColheitabilidadeMeta = data.graficoColhedoraI42Meta;
            $scope.chartEquipColhedoraColheitabilidadeMax = maxRealizado(data.oGraficoColhedoraI42) > $scope.chartEquipColhedoraColheitabilidadeMeta ? undefined : $scope.chartEquipColhedoraColheitabilidadeMeta;

            $scope.dsChartEquipTratorMotorOcioso = data.oGraficoTratorI38;
            $scope.chartEquipTratorMotorOciosoMedia = data.graficoTratorI38Media;
            $scope.chartEquipTratorMotorOciosoMeta = data.graficoTratorI38Meta;
            $scope.chartEquipTratorMotorOciosoMax = maxRealizado(data.oGraficoTratorI38) > $scope.chartEquipTratorMotorOciosoMeta ? undefined : $scope.chartEquipTratorMotorOciosoMeta;

            $scope.dsChartEquipTratorConsumoOleoDiesel = data.oGraficoTratorI41;
            $scope.chartEquipTratorConsumoOleoDieselMedia = data.graficoTratorI41Media;
            $scope.chartEquipTratorConsumoOleoDieselMeta = data.graficoTratorI41Meta;
            $scope.chartEquipTratorConsumoOleoDieselMax = maxRealizado(data.oGraficoTratorI41) > $scope.chartEquipTratorConsumoOleoDieselMeta ? undefined : $scope.chartEquipTratorConsumoOleoDieselMeta;

            $scope.dsChartEquipCanavieiroConsumoOleoDiesel = data.oGraficoCanavieiroI41;
            $scope.chartEquipCanavieiroConsumoOleoDieselMedia = data.graficoCanavieiroI41Media;
            $scope.chartEquipCanavieiroConsumoOleoDieselMeta = data.graficoCanavieiroI41Meta;
            $scope.chartEquipCanavieiroConsumoOleoDieselMax = maxRealizado(data.oGraficoCanavieiroI41) > $scope.chartEquipCanavieiroConsumoOleoDieselMeta ? undefined : $scope.chartEquipCanavieiroConsumoOleoDieselMeta;

            $scope.dsChartEquipEscravoConsumoOleoDiesel = data.oGraficoEscravoI41;
            $scope.chartEquipEscravoConsumoOleoDieselMedia = data.graficoEscravoI41Media;
            $scope.chartEquipEscravoConsumoOleoDieselMeta = data.graficoEscravoI41Meta;
            $scope.chartEquipEscravoConsumoOleoDieselMax = maxRealizado(data.oGraficoEscravoI41) > $scope.chartEquipEscravoConsumoOleoDieselMeta ? undefined : $scope.chartEquipEscravoConsumoOleoDieselMeta;
        };

        function refreshEquipamentos() {
            var promise = new Promise(function (resolve, reject) {
                ApiGetService
                    .getagricolaColheitaAdmPorDiaPorFrenteEquipamentoPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia, $scope.frenteAtual.frenteCodigo)
                    .then(function (data) {
                        $scope.gaugeEquipColhedoraEquipamentosOnlineValue = data.oGraficoColhedoraI48 && data.oGraficoColhedoraI48[0] ? data.oGraficoColhedoraI48[0].REALIZADO / 100 : 0;
                        $scope.gaugeEquipColhedoraEquipamentosOnlineValueDisplay = $scope.gaugeEquipColhedoraEquipamentosOnlineValue * 100 + "%";
                        $scope.gaugeEquipColhedoraEquipamentosOnlineMeta = data.oGraficoColhedoraI48 && data.oGraficoColhedoraI48[0] ? data.oGraficoColhedoraI48[0].META / 100 : 0;

                        $scope.gaugeEquipCaminhaoQuantidadeValue = data.oGraficoCaminhaoI36 && data.oGraficoCaminhaoI36[0] ? data.oGraficoCaminhaoI36[0].REALIZADO : 0;
                        $scope.gaugeEquipCaminhaoQuantidadeValueDisplay = $scope.gaugeEquipCaminhaoQuantidadeValue + "";
                        $scope.gaugeEquipCaminhaoQuantidadeMeta = data.oGraficoCaminhaoI36 && data.oGraficoCaminhaoI36[0] ? data.oGraficoCaminhaoI36[0].META : 0;

                        $scope.gaugeEquipCaminhaoTempoMedioPermanenciaValue = data.oGraficoCaminhaoI37 && data.oGraficoCaminhaoI37[0] ? data.oGraficoCaminhaoI37[0].REALIZADO : 0;
                        $scope.gaugeEquipCaminhaoTempoMedioPermanenciaValueDisplay = converteHorasHHMM($scope.gaugeEquipCaminhaoTempoMedioPermanenciaValue);
                        $scope.gaugeEquipCaminhaoTempoMedioPermanenciaMeta = data.oGraficoCaminhaoI37 && data.oGraficoCaminhaoI37[0] ? data.oGraficoCaminhaoI37[0].META : 0;

                        $scope.textoColhedoraI43 = data.textoColhedoraI43;
                        $scope.textoColhedoraI44 = data.textoColhedoraI44;
                        $scope.textoColhedoraI45 = data.textoColhedoraI45;

                        if ($scope.seltabFiltroPeriodo == 0) {
                            //Período Semana
                            ApiGetService
                                .getagricolaColheitaAdmPorSemanaPorFrenteEquipamentoCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralSemana, $scope.frenteAtual.frenteCodigo, $scope.visaoGeralDia)
                                //.getagricolaColheitaAdmPorSemanaPorFrenteEquipamentoPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralSemana, $scope.frenteAtual.frenteCodigo)
                                .then(function (data) {
                                    resolveChartsEquipamentos(data);

                                    $scope.equipamentosComDados = true;

                                    resolve();
                                });
                        } else if ($scope.seltabFiltroPeriodo == 1) {
                            //Período Mês
                            ApiGetService
                                .getagricolaColheitaAdmPorMesPorFrenteEquipamentoCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralMes, $scope.frenteAtual.frenteCodigo, $scope.visaoGeralDia)
                                //.getagricolaColheitaAdmPorMesPorFrenteEquipamentoPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralMes, $scope.frenteAtual.frenteCodigo)
                                .then(function (data) {
                                    resolveChartsEquipamentos(data);

                                    $scope.equipamentosComDados = true;

                                    resolve();
                                });
                        } else if ($scope.seltabFiltroPeriodo == 2) {
                            //Período Safra
                            ApiGetService
                                .getagricolaColheitaAdmPorSafraPorFrenteEquipamentoCorteDiaPromise(1, $scope.visaoGeralSafra, $scope.frenteAtual.frenteCodigo, $scope.visaoGeralDia)
                                //.getagricolaColheitaAdmPorSafraPorFrenteEquipamentoPromise(1, $scope.visaoGeralSafra, $scope.frenteAtual.frenteCodigo)
                                .then(function (data) {
                                    resolveChartsEquipamentos(data);

                                    $scope.equipamentosComDados = true;

                                    resolve();
                                });
                        }
                    });
            });

            return promise;
        };

        $scope.buttonColhedoraFrenteOptions = {
            bindingOptions: {
                text: 'colhedoraFrenteButtonText()',
                icon: 'colhedoraFrenteButtonIcon()'
            },
            width: 220,
            onClick: function () {
                $scope.colhedoraFrenteMostrar = !$scope.colhedoraFrenteMostrar;
            }
        }

        $scope.buttonTratorFrenteOptions = {
            bindingOptions: {
                text: 'tratorFrenteButtonText()',
                icon: 'tratorFrenteButtonIcon()'
            },
            width: 220,
            onClick: function () {
                $scope.tratorFrenteMostrar = !$scope.tratorFrenteMostrar;
            }
            
        };

        $scope.buttonCaminhaoFrenteOptions = {
            bindingOptions: {
                text: 'caminhaoFrenteButtonText()',
                icon: 'caminhaoFrenteButtonIcon()'
            },
            width: 220,
            onClick: function () {
                $scope.caminhaoFrenteMostrar = !$scope.caminhaoFrenteMostrar;
            }

        };

        $scope.buttonCanavieiroFrenteOptions = {
            bindingOptions: {
                text: 'canavieiroFrenteButtonText()',
                icon: 'canavieiroFrenteButtonIcon()'
            },
            width: 220,
            onClick: function () {
                $scope.canavieiroFrenteMostrar = !$scope.canavieiroFrenteMostrar;
            }

        };

        $scope.buttonEscravoFrenteOptions = {
            bindingOptions: {
                text: 'escravoFrenteButtonText()',
                icon: 'escravoFrenteButtonIcon()'
            },
            width: 220,
            onClick: function () {
                $scope.escravoFrenteMostrar = !$scope.escravoFrenteMostrar;
            }

        };

        $scope.buttonInfoFrenteOptions = {
            bindingOptions: {
                text: 'infoFrenteButtonText()',
                icon: 'infoFrenteButtonIcon()'
            },
            width: 220,
            onClick: function () {
                $scope.infoFrenteMostrar = !$scope.infoFrenteMostrar;
            }

        };




        $scope.chartEquipColhedoraMotorOciosoOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraMotorOcioso',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraMotorOciosoMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraMotorOciosoMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraMotorOciosoMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraMotorOciosoMetaText()',
                'valueAxis.max': 'chartEquipColhedoraMotorOciosoMax'
            },
            title: 'Motor Ocioso (%)',
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
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipColhedoraMotorOciosoMeta, $scope.chartEquipColhedoraMotorOciosoMedia) };
            },
            tooltip: {
                enabled: true
            },
            legend: {
                visible: false
            }
        };

        $scope.chartEquipColhedoraPilotoAutomaticoOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraPilotoAutomatico',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraPilotoAutomaticoMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraPilotoAutomaticoMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraPilotoAutomaticoMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraPilotoAutomaticoMetaText()',
                'valueAxis.max': 'chartEquipColhedoraPilotoAutomaticoMax'
            },
            title: 'Piloto Automático (%)',
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
                return { color: chartEquipamentosMaisMelhorPointColor(point.value, $scope.chartEquipColhedoraPilotoAutomaticoMeta, $scope.chartEquipColhedoraPilotoAutomaticoMedia) };
            },
            tooltip: {
                enabled: true
            },
            legend: {
                visible: false
            }
        };

        $scope.chartEquipColhedoraConsumoOleoHidraulicoOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraConsumoOleoHidraulico',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraConsumoOleoHidraulicoMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraConsumoOleoHidraulicoMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraConsumoOleoHidraulicoMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraConsumoOleoHidraulicoMetaText()',
                'valueAxis.max': 'chartEquipColhedoraConsumoOleoHidraulicoMax'
            },
            title: 'Consumo Hidráulico (l/ton)',
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
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipColhedoraConsumoOleoHidraulicoMeta, $scope.chartEquipColhedoraConsumoOleoHidraulicoMedia) };
            },
            tooltip: {
                enabled: true
            },
            legend: {
                visible: false
            }
        };

        $scope.chartEquipColhedoraConsumoOleoDieselOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraConsumoOleoDiesel',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraConsumoOleoDieselMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraConsumoOleoDieselMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraConsumoOleoDieselMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraConsumoOleoDieselMetaText()',
                'valueAxis.max': 'chartEquipColhedoraConsumoOleoDieselMax'
            },
            title: 'Consumo Diesel (l/ton)',
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
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipColhedoraConsumoOleoDieselMeta, $scope.chartEquipColhedoraConsumoOleoDieselMedia) };
            },
            tooltip: {
                enabled: true
            },
            legend: {
                visible: false
            }
        };

        $scope.chartEquipColhedoraColheitabilidadeOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipColhedoraColheitabilidade',
                'valueAxis.constantLines[0].value': 'chartEquipColhedoraColheitabilidadeMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipColhedoraColheitabilidadeMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipColhedoraColheitabilidadeMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipColhedoraColheitabilidadeMetaText()',
                'valueAxis.max': 'chartEquipColhedoraColheitabilidadeMax'
            },
            title: 'Colheitabilidade (ton/h)',
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
                return { color: chartEquipamentosMaisMelhorPointColor(point.value, $scope.chartEquipColhedoraColheitabilidadeMeta, $scope.chartEquipColhedoraColheitabilidadeMedia) };
            },
            tooltip: {
                enabled: true
            },
            legend: {
                visible: false
            }
        };

        $scope.gaugeEquipColhedoraEquipamentosOnlineOptions = {
            bindingOptions: {
                value: 'gaugeEquipColhedoraEquipamentosOnlineValue',
                'title.subtitle.text': 'gaugeEquipColhedoraEquipamentosOnlineValueDisplay',
                'rangeContainer.ranges[0].endValue': 'gaugeEquipColhedoraEquipamentosOnlineMeta',
                'rangeContainer.ranges[1].startValue': 'gaugeEquipColhedoraEquipamentosOnlineMeta'
            },
            title: {
                text: 'Equipamentos Online',
                subtitle: {
                    font: {
                        size: 20
                    }
                }
            },
            scale: {
                startValue: 0,
                endValue: 1,
                tickInterval: 0.1,
                label: {
                    format: 'percent'
                }
            },
            valueIndicator: {
                type: "triangleNeedle"
            },
            rangeContainer: {
                ranges: [
                    { startValue: 0, color: 'red' },
                    { endValue: 1, color: 'green' }
                ],
                width: 10
            },
            geometry: {
                startAngle: 180,
                endAngle: 0
            }
        };


        $scope.chartEquipTratorMotorOciosoOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipTratorMotorOcioso',
                'valueAxis.constantLines[0].value': 'chartEquipTratorMotorOciosoMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipTratorMotorOciosoMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipTratorMotorOciosoMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipTratorMotorOciosoMetaText()',
                'valueAxis.max': 'chartEquipTratorMotorOciosoMax'
            },
            title: 'Motor Ocioso (%)',
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
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipTratorMotorOciosoMeta, $scope.chartEquipTratorMotorOciosoMedia) };
            },
            tooltip: {
                enabled: true
            },
            legend: {
                visible: false
            }
        };

        $scope.chartEquipTratorConsumoOleoDieselOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipTratorConsumoOleoDiesel',
                'valueAxis.constantLines[0].value': 'chartEquipTratorConsumoOleoDieselMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipTratorConsumoOleoDieselMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipTratorConsumoOleoDieselMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipTratorConsumoOleoDieselMetaText()',
                'valueAxis.max': 'chartEquipTratorConsumoOleoDieselMax'
            },
            title: 'Consumo Diesel (l/ton)',
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
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipTratorConsumoOleoDieselMeta, $scope.chartEquipTratorConsumoOleoDieselMedia) };
            },
            tooltip: {
                enabled: true
            },
            legend: {
                visible: false
            }
        };

        $scope.gaugeEquipCaminhaoQuantidadeOptions = {
            bindingOptions: {
                value: 'gaugeEquipCaminhaoQuantidadeValue',
                'title.subtitle.text': 'gaugeEquipCaminhaoQuantidadeValueDisplay',
                'rangeContainer.ranges[0].endValue': 'gaugeEquipCaminhaoQuantidadeMeta',
                'rangeContainer.ranges[1].startValue': 'gaugeEquipCaminhaoQuantidadeMeta'
            },
            title: {
                text: 'Quantidade',
                subtitle: {
                    font: {
                        size: 20
                    }
                }
            },
            scale: {
                startValue: 0,
                endValue: 15,
                tickInterval: 5,
                label: {
                    format: 'number'
                }
            },
            valueIndicator: {
                type: "triangleNeedle"
            },
            rangeContainer: {
                ranges: [
                    { startValue: 0, color: 'red' },
                    { endValue: 30, color: 'green' }
                ],
                width: 10
            },
            geometry: {
                startAngle: 180,
                endAngle: 0
            }
        };


        $scope.gaugeEquipCaminhaoTempoMedioPermanenciaOptions = {
            bindingOptions: {
                value: 'gaugeEquipCaminhaoTempoMedioPermanenciaValue',
                'title.subtitle.text': 'gaugeEquipCaminhaoTempoMedioPermanenciaValueDisplay',
                'rangeContainer.ranges[0].endValue': 'gaugeEquipCaminhaoTempoMedioPermanenciaMeta',
                'rangeContainer.ranges[1].startValue': 'gaugeEquipCaminhaoTempoMedioPermanenciaMeta'
            },
            title: {
                text: 'Tempo Permanência',
                subtitle: {
                    font: {
                        size: 20
                    }
                }
            },
            scale: {
                startValue: 0,
                endValue: 24,
                tickInterval: 1,
                label: {
                    format: 'number'
                }
            },
            valueIndicator: {
                type: "triangleNeedle"
            },
            rangeContainer: {
                ranges: [
                    { startValue: 0, color: 'red' },
                    { endValue: 24, color: 'green' }
                ],
                width: 10
            },
            geometry: {
                startAngle: 180,
                endAngle: 0
            }            
        };

        $scope.chartEquipCaminhaoTempoMedioPermanenciaOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipCaminhaoTempoMedioPermanencia',
                'valueAxis.constantLines[0].value': 'chartEquipCaminhaoTempoMedioPermanenciaMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipCaminhaoTempoMedioPermanenciaMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipCaminhaoTempoMedioPermanenciaMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipCaminhaoTempoMedioPermanenciaMetaText()',
                'valueAxis.max': 'chartEquipCaminhaoTempoMedioPermanenciaMax'
            },
            title: 'Tempo Permanência',
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
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipCaminhaoTempoMedioPermanenciaMeta, $scope.chartEquipCaminhaoTempoMedioPermanenciaMedia) };
            },
            tooltip: {
                enabled: true
            },
            legend: {
                visible: false
            }
        };

        $scope.chartEquipCanavieiroConsumoOleoDieselOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipCanavieiroConsumoOleoDiesel',
                'valueAxis.constantLines[0].value': 'chartEquipCanavieiroConsumoOleoDieselMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipCanavieiroConsumoOleoDieselMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipCanavieiroConsumoOleoDieselMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipCanavieiroConsumoOleoDieselMetaText()',
                'valueAxis.max': 'chartEquipCanavieiroConsumoOleoDieselMax'
            },
            title: 'Consumo Óleo Diesel (l/ton)',
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
                    },
                    font: { size: 12 }
                }
            },
            valueAxis: {
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
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipCanavieiroConsumoOleoDieselMeta, $scope.chartEquipCanavieiroConsumoOleoDieselMedia) };
            },
            tooltip: {
                enabled: true,
                customizeTooltip: function(arg) {
                    var node = $("<div>")
                        .append("<h5>" + arg.argumentText + "</h5>")
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

        $scope.chartEquipEscravoConsumoOleoDieselOptions = {
            bindingOptions: {
                dataSource: 'dsChartEquipEscravoConsumoOleoDiesel',
                'valueAxis.constantLines[0].value': 'chartEquipEscravoConsumoOleoDieselMedia',
                'valueAxis.constantLines[0].label.text': 'chartEquipEscravoConsumoOleoDieselMediaText()',
                'valueAxis.constantLines[1].value': 'chartEquipEscravoConsumoOleoDieselMeta',
                'valueAxis.constantLines[1].label.text': 'chartEquipEscravoConsumoOleoDieselMetaText()',
                'valueAxis.max': 'chartEquipEscravoConsumoOleoDieselMax'
            },
            title: 'Consumo Óleo Diesel (l/ton)',
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
                    },
                    font: { size: 12 }
                }
            },
            valueAxis: {
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
                return { color: chartEquipamentosMenosMelhorSemAmareloPointColor(point.value, $scope.chartEquipEscravoConsumoOleoDieselMeta, $scope.chartEquipEscravoConsumoOleoDieselMedia) };
            },
            tooltip: {
                enabled: true,
                customizeTooltip: function(arg) {
                    var node = $("<div>")
                        .append("<h5>" + arg.argumentText + "</h5>")
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
