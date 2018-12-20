/*! 
* Autor: Renato Ferreira Xavier
* Data: junho/2018
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

    function converteHorasHHMM(horas) {
        var decimalTimeString = horas;
        var n = new Date(0, 0);
        n.setSeconds(+decimalTimeString * 60 * 60);

        return n.toTimeString().slice(0, 5);
    };

    angular.module('app4T')
        .controller("agricolacolheitaOperCtrl", ['$scope', '$document', 'ApiGetService', agricolacolheitaOperCtrl]);

    function agricolacolheitaOperCtrl($scope, $document, ApiGetService) {
        $scope.loadingVisible = true;

        //#region $scope empty object declarations


        function refreshAll() {
            var promise = new Promise(function(resolve, reject) {
                $scope.loadingVisible = true;

                ApiGetService
                    .getagricolaColheitaOperVisaoGeralMinMaxDiaPromise(1)
                    .then(function (data) {
                        $scope.visaoGeralSafra = data.safra;

                        $scope.visaoGeralDiaDate = pureDate(data.maxDia);
                        $scope.visaoGeralDiaMaxDisplay = $scope.visaoGeralDiaDate.ddmmyyyy();

                        $scope.visaoGeralDia = $scope.visaoGeralDiaDate.yyyymmdd();

                        ApiGetService
                            .getagricolaColheitaOperPorDiaPromise(1, $scope.visaoGeralSafra, $scope.visaoGeralDia)
                            .then(function(data) {
                                $scope.infoFrentes = data;
                            });

                        resolve();
                    });
            });

            return promise;
        };


        $scope.autoRefreshButtonType = !window.localStorage.getItem("bi4tAgr03ar") || window.localStorage.getItem("bi4tAgr03ar") == 0 ? 'success' : 'normal';

        angular.element(document).ready(function () {
            //ORDEM: 2 - Document Ready Angular
            Globalize.culture("pt-BR");

            refreshAll().then(function () {
                $scope.loadingVisible = false;

                $scope.$apply();
            });

            $scope.interval = null;

            if (!window.localStorage.getItem("bi4tAgr03ar")) {
                window.localStorage.setItem("bi4tAgr03ar", 0);
                window.localStorage.setItem("bi4tAgr03arsec", 60);
            };

            $scope.autoRefresh = (window.localStorage.getItem("bi4tAgr03ar") == 0);
            $scope.autoRefreshSeconds = window.localStorage.getItem("bi4tAgr03arsec");

            if ($scope.autoRefresh) {
                $scope.interval = setInterval(function() {
                    refreshAll().then(function () {
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

                window.localStorage.setItem("bi4tAgr03ar", $scope.autoRefresh ? 0 : 1);
                window.localStorage.setItem("bi4tAgr03arsec", $scope.autoRefreshSeconds);

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


        $scope.loadOptions = {
            bindingOptions: {
                visible: "loadingVisible"
            },

            showIndicator: true,
            showPane: true,
            shading: true,
            message: "Aguarde..."
        };

        $scope.gaugeEquipColhedoraEquipamentosOnlineDynOptions = function (data) {
            return {
                value: data.colhedoraI48Realizado / 100,
                title: {
                    text: data.colhedoraI48Realizado + "%",
                    font: {
                        size: 14
                    }
                },
                size: { width: 210, height: 150 },
                scale: {
                    startValue: 0,
                    endValue: 1,
                    tickInterval: 0.1,
                    label: {
                        format: 'percent'
                    }
                },
                valueIndicator: {
                    type: "triangleNeedle",
                    color: 'grey'
                },
                rangeContainer: {
                    ranges: [
                        { startValue: 0, endValue: data.colhedoraI48Meta / 100, color: 'red' },
                        { startValue: data.colhedoraI48Meta / 100, endValue: 1, color: 'green' }
                    ],
                    width: 10
                },
                geometry: {
                    startAngle: 180,
                    endAngle: 0
                }
            }
        };

        function caminhaoQuantidadeRanges(meta, max) {
            var gaugeRanges = [];

            if (meta >= 3) {
                gaugeRanges = [
                    { startValue: 0, endValue: meta - 2, color: 'red' },
                    { startValue: meta - 2, endValue: meta - 1, color: 'yellow' },
                    { startValue: meta - 1, endValue: meta + 1, color: 'green' },
                    { startValue: meta + 1, endValue: max, color: 'red' }
                ];
            } else if (meta === 2) {
                gaugeRanges = [
                    { startValue: 0, endValue: meta - 1, color: 'red' },
                    { startValue: meta - 1, endValue: meta + 1, color: 'green' },
                    { startValue: meta + 1, endValue: max, color: 'red' }
                ];
            } else if (meta === 1) {
                gaugeRanges = [
                    { startValue: 0, endValue: meta, color: 'red' },
                    { startValue: meta, endValue: meta + 1, color: 'green' },
                    { startValue: meta + 1, endValue: max, color: 'red' }
                ];
            };

            return gaugeRanges;
        };

        $scope.gaugeEquipCaminhaoQuantidadeDynOptions = function (data) {
            return {
                value: data.caminhaoI36Realizado,
                title: {
                    text: data.caminhaoI36Realizado.toString(),
                    font: {
                        size: 14
                    }
                },
                size: { width: 210, height: 150 },
                scale: {
                    startValue: 0,
                    endValue: 5,
                    tickInterval: 1,
                    label: {
                        format: 'number'
                    }
                },
                valueIndicator: {
                    type: "triangleNeedle",
                    color: 'grey'
                },
                rangeContainer: {
                    ranges: caminhaoQuantidadeRanges(data.caminhaoI36Meta, 15),
                    width: 10
                },
                geometry: {
                    startAngle: 180,
                    endAngle: 0
                }
            }
        };

        $scope.gaugeEquipCaminhaoTempoMedioPermanenciaDynOptions = function (data) {
            return {
                value: data.caminhaoI37Realizado,
                title: {
                    text: converteHorasHHMM(data.caminhaoI37Realizado),
                    font: {
                        size: 14
                    }
                },
                size: { width: 210, height: 150 },
                scale: {
                    startValue: 0,
                    endValue: 2,
                    tickInterval: 0.5,
                    label: {
                        format: { number: '#.#'}
                    }
                },
                valueIndicator: {
                    type: "triangleNeedle",
                    color: 'grey'
                },
                rangeContainer: {
                    ranges: [
                        { startValue: 0, endValue: data.caminhaoI37Meta, color: 'red' },
                        { startValue: data.caminhaoI37Meta, endValue: 24, color: 'green' }
                    ],
                    width: 10
                },
                geometry: {
                    startAngle: 180,
                    endAngle: 0
                }
            }
        };

        $scope.replacePipeWithBr = function (text) {
            var htmlContent = text.split("|").join("<br />");

            return htmlContent;
        };
    };
})();
