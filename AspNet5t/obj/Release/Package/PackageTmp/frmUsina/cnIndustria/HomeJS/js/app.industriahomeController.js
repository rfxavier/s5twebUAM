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

    function pureDateString(date) {
        var yyyy = date.getFullYear().toString();
        var mm = (date.getMonth() + 1).toString(); // getMonth() is zero-based
        var dd = date.getDate().toString();
        var hh = date.getHours().toString();
        var mmm = date.getMinutes().toString();
        return yyyy + '-' + (mm[1] ? mm : "0" + mm[0]) + '-' + (dd[1] ? dd : "0" + dd[0]); // padding
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

    angular.module('app4T')
        .controller("industriahomeCtrl", ['$scope', '$document', 'ApiGetService', industriahomeCtrl]);

    function industriahomeCtrl($scope, $document, ApiGetService) {
        //#region $scope empty object declarations
        var chartsVisaoGeralHeight = document.documentElement.clientHeight / 11;
        //                     green      yellow     red
        var coresMetaArray = ['#60bd68', '#decf3f', '#f15854'];

        $scope.loadingHomeTerminado = false;
        $scope.loadingMoagemTerminado = false;
        $scope.loadingEnergiaBioTerminado = false;
        $scope.loadingEnergiaUamTerminado = false;
        $scope.loadingAcucarTerminado = false;
        $scope.loadingEtanolTerminado = false;

        function resolveDesligaLoadingVisible() {
            if ($scope.loadingHomeTerminado &&
                $scope.loadingMoagemTerminado &&
                $scope.loadingEnergiaBioTerminado &&
                $scope.loadingEnergiaUamTerminado &&
                $scope.loadingAcucarTerminado &&
                $scope.loadingEtanolTerminado) $scope.loadingVisible = false;            
        };

        $scope.$watch('loadingHomeTerminado', function () {
            resolveDesligaLoadingVisible();
        });

        $scope.$watch('loadingMoagemTerminado', function () {
            resolveDesligaLoadingVisible();
        });

        $scope.$watch('loadingEnergiaBioTerminado', function () {
            resolveDesligaLoadingVisible();
        });

        $scope.$watch('loadingEnergiaUamTerminado', function () {
            resolveDesligaLoadingVisible();
        });

        $scope.$watch('loadingAcucarTerminado', function () {
            resolveDesligaLoadingVisible();
        });

        $scope.$watch('loadingEtanolTerminado', function () {
            resolveDesligaLoadingVisible();
        });

        function refreshAll(semLatest) {
            $scope.loadingHomeTerminado = false;
            $scope.loadingMoagemTerminado = false;
            $scope.loadingEnergiaBioTerminado = false;
            $scope.loadingEnergiaUamTerminado = false;
            $scope.loadingAcucarTerminado = false;
            $scope.loadingEtanolTerminado = false;

            $scope.loadingVisible = true;

            ApiGetService
                .getindustriaHomeVisaoGeralMinMaxDiaPromise(1)
                .then(function (data) {
                    if (!semLatest) {
                        $scope.homeVisaoGeralSafra = data.safra;
                        $scope.homeVisaoGeralDiaMinDate = pureDate(data.MinDia);
                        $scope.homeVisaoGeralDiaMaxDate = pureDate(data.MaxDia);
                        $scope.homeVisaoGeralDiaDate = pureDate(data.MaxDia);

                        $scope.homeVisaoGeralDia = $scope.homeVisaoGeralDiaDate.yyyymmdd();
                        $scope.homeVisaoGeralDiaDisplay = $scope.homeVisaoGeralDiaDate.ddmmyyyy();
                        $scope.homeVisaoGeralHora = data.MaxHora;

                        $scope.homeVisaoGeralSemana = data.MaxSemana;

                        $scope.homeVisaoGeralMes = data.MaxMes;

                        //$scope.homeVisaoGeralSafra = data.Safra;
                    };

                    ApiGetService
                        .getindustriaHomePorDiaPromise(1, $scope.homeVisaoGeralSafra, new Date($scope.homeVisaoGeralDiaDate).yyyymmdd())
                        .then(function (data) {
                            $scope.homeEficienciaArtValue = data.EficienciaIndustrialArt / 100;
                            $scope.homeEficienciaArtValueDisplay = parseFloat(data.EficienciaIndustrialArt).toLocaleString() + "%";

                            $scope.homeEficienciaRtcValue = data.EficienciaIndustrialRtc / 100;
                            $scope.homeEficienciaRtcValueDisplay = parseFloat(data.EficienciaIndustrialRtc).toLocaleString() + "%";

                            $scope.homeEficienciaCiValue = data.ConsumoInternoPorTonCana;
                            $scope.homeEficienciaCiValueDisplay = parseFloat(data.ConsumoInternoPorTonCana).toLocaleString();

                            $scope.loadingHomeTerminado = true;
                        });
                });


            ApiGetService
                .getindustriaMoagemVisaoGeralMinMaxDiaPromise(1)
                .then(function (data) {
                    if (!semLatest) {
                        $scope.moagemVisaoGeralSafra = data.safra;
                        $scope.moagemVisaoGeralDiaMinDate = pureDate(data.MinDia);
                        $scope.moagemVisaoGeralDiaMaxDate = pureDate(data.MaxDia);
                        $scope.moagemVisaoGeralDiaDate = pureDate(data.MaxDia);

                        $scope.moagemVisaoGeralDia = $scope.moagemVisaoGeralDiaDate.yyyymmdd();
                        $scope.moagemVisaoGeralDiaDisplay = $scope.moagemVisaoGeralDiaDate.ddmmyyyy();
                        $scope.moagemVisaoGeralHora = data.MaxHora;

                        $scope.moagemVisaoGeralSemana = data.MaxSemana;

                        $scope.moagemVisaoGeralMes = data.MaxMes;

                        //$scope.moagemVisaoGeralSafra = data.Safra;
                    };

                    ApiGetService
                        .getindustriaMoagemVisaoGeralCorteDiaPromise(1, $scope.moagemVisaoGeralSafra, new Date($scope.moagemVisaoGeralDiaDate).yyyymmdd())
                        .then(function (data) {
                            //Dia
                            $scope.chartMoagemVisaoGeralDiaDataSource.store().clear();

                            $scope.chartMoagemVisaoGeralDiaDataSource.store().insert({
                                arg: "DIA",
                                val: data.DiaValMoagem,
                                meta: data.DiaValMoagemMax - data.DiaValMoagem <= 0 ? 0 : data.DiaValMoagemMax - data.DiaValMoagem
                            });

                            $scope.chartMoagemVisaoGeralDiaDataSource.load();

                            $scope.moagemVisaoGeralDiaDate = pureDate(data.Dia);
                            $scope.moagemVisaoGeralDia = $scope.moagemVisaoGeralDiaDate.yyyymmdd();
                            $scope.moagemVisaoGeralDiaDisplay = $scope.moagemVisaoGeralDiaDate.ddmmyyyy();
                            $scope.moagemVisaoGeralHora = data.Hora;

                            $scope.moagemVisaoGeralDiaValMoagem = data.DiaValMoagem;
                            $scope.moagemVisaoGeralDiaValMoagemMax = data.DiaValMoagemMax;
                            $scope.moagemVisaoGeralDiaIndicadorMeta = data.DiaIndicadorMeta;
                            $scope.moagemVisaoGeralDiaIndicadorMetaColor = coresMetaArray[data.DiaIndicadorMeta];

                            //Semana
                            $scope.chartMoagemVisaoGeralSemanaDataSource.store().clear();

                            $scope.chartMoagemVisaoGeralSemanaDataSource.store().insert({
                                arg: "SEMANA",
                                val: data.SemanaValMoagem,
                                meta: data.SemanaValMoagemMax - data.SemanaValMoagem <= 0 ? 0 : data.SemanaValMoagemMax - data.SemanaValMoagem
                            });

                            $scope.chartMoagemVisaoGeralSemanaDataSource.load();

                            $scope.moagemVisaoGeralSemana = data.Semana;
                            $scope.moagemVisaoGeralSemanaValMoagem = data.SemanaValMoagem;
                            $scope.moagemVisaoGeralSemanaValMoagemMax = data.SemanaValMoagemMax;
                            $scope.moagemVisaoGeralSemanaIndicadorMeta = data.SemanaIndicadorMeta;
                            $scope.moagemVisaoGeralSemanaIndicadorMetaColor = coresMetaArray[data.SemanaIndicadorMeta];

                            //Mes
                            $scope.chartMoagemVisaoGeralMesDataSource.store().clear();

                            $scope.chartMoagemVisaoGeralMesDataSource.store().insert({
                                arg: "MÊS",
                                val: data.MesValMoagem,
                                meta: data.MesValMoagemMax - data.MesValMoagem <= 0 ? 0 : data.MesValMoagemMax - data.MesValMoagem
                            });

                            $scope.chartMoagemVisaoGeralMesDataSource.load();

                            $scope.moagemVisaoGeralMes = data.Mes;
                            $scope.moagemVisaoGeralMesValMoagem = data.MesValMoagem;
                            $scope.moagemVisaoGeralMesValMoagemMax = data.MesValMoagemMax;
                            $scope.moagemVisaoGeralMesIndicadorMeta = data.MesIndicadorMeta;
                            $scope.moagemVisaoGeralMesIndicadorMetaColor = coresMetaArray[data.MesIndicadorMeta];

                            //Safra
                            $scope.chartMoagemVisaoGeralSafraDataSource.store().clear();

                            $scope.chartMoagemVisaoGeralSafraDataSource.store().insert({
                                arg: "SAFRA",
                                val: data.SafraValMoagem,
                                meta: data.SafraValMoagemMax - data.SafraValMoagem <= 0 ? 0 : data.SafraValMoagemMax - data.SafraValMoagem
                            });

                            $scope.chartMoagemVisaoGeralSafraDataSource.load();

                            $scope.moagemVisaoGeralSafra = data.Safra;
                            $scope.moagemVisaoGeralSafraValMoagem = data.SafraValMoagem;
                            $scope.moagemVisaoGeralSafraValMoagemMax = data.SafraValMoagemMax;
                            $scope.moagemVisaoGeralSafraIndicadorMeta = data.SafraIndicadorMeta;
                            $scope.moagemVisaoGeralSafraIndicadorMetaColor = coresMetaArray[data.SafraIndicadorMeta];

                            $scope.loadingMoagemTerminado = true;
                        });
                });

            ApiGetService
                .getindustriaEnergiaBioVisaoGeralMinMaxDiaPromise(1)
                .then(function (data) {
                    if (!semLatest) {
                        $scope.energiabioVisaoGeralSafra = data.safra;
                        $scope.energiabioVisaoGeralDiaMinDate = pureDate(data.MinDia);
                        $scope.energiabioVisaoGeralDiaMaxDate = pureDate(data.MaxDia);
                        $scope.energiabioVisaoGeralDiaDate = pureDate(data.MaxDia);

                        $scope.energiabioVisaoGeralDia = $scope.energiabioVisaoGeralDiaDate.yyyymmdd();
                        $scope.energiabioVisaoGeralDiaDisplay = $scope.energiabioVisaoGeralDiaDate.ddmmyyyy();
                        $scope.energiabioVisaoGeralHora = data.MaxHora;

                        $scope.energiabioVisaoGeralSemana = data.MaxSemana;

                        $scope.energiabioVisaoGeralMes = data.MaxMes;

                        //$scope.energiabioVisaoGeralSafra = data.Safra;
                    };

                    ApiGetService
                        .getindustriaEnergiaBioVisaoGeralCorteDiaPromise(1, $scope.energiabioVisaoGeralSafra, new Date($scope.energiabioVisaoGeralDiaDate).yyyymmdd())
                        .then(function (data) {
                            //Dia
                            $scope.chartEnergiaBioVisaoGeralDiaDataSource.store().clear();

                            $scope.chartEnergiaBioVisaoGeralDiaDataSource.store().insert({
                                arg: "DIA",
                                val: data.DiaVal,
                                meta: data.DiaValMax - data.DiaVal <= 0 ? 0 : data.DiaValMax - data.DiaVal
                            });

                            $scope.chartEnergiaBioVisaoGeralDiaDataSource.load();

                            $scope.energiabioVisaoGeralDiaDate = pureDate(data.Dia);
                            $scope.energiabioVisaoGeralDia = $scope.energiabioVisaoGeralDiaDate.yyyymmdd();
                            $scope.energiabioVisaoGeralDiaDisplay = $scope.energiabioVisaoGeralDiaDate.ddmmyyyy();
                            $scope.energiabioVisaoGeralHora = data.Hora;

                            $scope.energiabioVisaoGeralDiaVal = data.DiaVal;
                            $scope.energiabioVisaoGeralDiaValMax = data.DiaValMax;
                            $scope.energiabioVisaoGeralDiaIndicadorMeta = data.DiaIndicadorMeta;
                            $scope.energiabioVisaoGeralDiaIndicadorMetaColor = coresMetaArray[data.DiaIndicadorMeta];

                            //Semana
                            $scope.chartEnergiaBioVisaoGeralSemanaDataSource.store().clear();

                            $scope.chartEnergiaBioVisaoGeralSemanaDataSource.store().insert({
                                arg: "SEMANA",
                                val: data.SemanaVal,
                                meta: data.SemanaValMax - data.SemanaVal <= 0 ? 0 : data.SemanaValMax - data.SemanaVal
                            });

                            $scope.chartEnergiaBioVisaoGeralSemanaDataSource.load();

                            $scope.energiabioVisaoGeralSemana = data.Semana;
                            $scope.energiabioVisaoGeralSemanaVal = data.SemanaVal;
                            $scope.energiabioVisaoGeralSemanaValMax = data.SemanaValMax;
                            $scope.energiabioVisaoGeralSemanaIndicadorMeta = data.SemanaIndicadorMeta;
                            $scope.energiabioVisaoGeralSemanaIndicadorMetaColor = coresMetaArray[data.SemanaIndicadorMeta];

                            //Mes
                            $scope.chartEnergiaBioVisaoGeralMesDataSource.store().clear();

                            $scope.chartEnergiaBioVisaoGeralMesDataSource.store().insert({
                                arg: "MÊS",
                                val: data.MesVal,
                                meta: data.MesValMax - data.MesVal <= 0 ? 0 : data.MesValMax - data.MesVal
                            });

                            $scope.chartEnergiaBioVisaoGeralMesDataSource.load();

                            $scope.energiabioVisaoGeralMes = data.Mes;
                            $scope.energiabioVisaoGeralMesVal = data.MesVal;
                            $scope.energiabioVisaoGeralMesValMax = data.MesValMax;
                            $scope.energiabioVisaoGeralMesIndicadorMeta = data.MesIndicadorMeta;
                            $scope.energiabioVisaoGeralMesIndicadorMetaColor = coresMetaArray[data.MesIndicadorMeta];

                            //Safra
                            $scope.chartEnergiaBioVisaoGeralSafraDataSource.store().clear();

                            $scope.chartEnergiaBioVisaoGeralSafraDataSource.store().insert({
                                arg: "SAFRA",
                                val: data.SafraVal,
                                meta: data.SafraValMax - data.SafraVal <= 0 ? 0 : data.SafraValMax - data.SafraVal
                            });

                            $scope.chartEnergiaBioVisaoGeralSafraDataSource.load();

                            $scope.energiabioVisaoGeralSafra = data.Safra;
                            $scope.energiabioVisaoGeralSafraVal = data.SafraVal;
                            $scope.energiabioVisaoGeralSafraValMax = data.SafraValMax;
                            $scope.energiabioVisaoGeralSafraIndicadorMeta = data.SafraIndicadorMeta;
                            $scope.energiabioVisaoGeralSafraIndicadorMetaColor = coresMetaArray[data.SafraIndicadorMeta];

                            $scope.loadingEnergiaBioTerminado = true;
                        });
                });

            ApiGetService
                .getindustriaEnergiaUamVisaoGeralMinMaxDiaPromise(1)
                .then(function (data) {
                    if (!semLatest) {
                        $scope.energiauamVisaoGeralSafra = data.safra;
                        $scope.energiauamVisaoGeralDiaMinDate = pureDate(data.MinDia);
                        $scope.energiauamVisaoGeralDiaMaxDate = pureDate(data.MaxDia);
                        $scope.energiauamVisaoGeralDiaDate = pureDate(data.MaxDia);

                        $scope.energiauamVisaoGeralDia = $scope.energiauamVisaoGeralDiaDate.yyyymmdd();
                        $scope.energiauamVisaoGeralDiaDisplay = $scope.energiauamVisaoGeralDiaDate.ddmmyyyy();
                        $scope.energiauamVisaoGeralHora = data.MaxHora;

                        $scope.energiauamVisaoGeralSemana = data.MaxSemana;

                        $scope.energiauamVisaoGeralMes = data.MaxMes;

                        //$scope.energiauamVisaoGeralSafra = data.Safra;
                    };

                    ApiGetService
                        .getindustriaEnergiaUamVisaoGeralCorteDiaPromise(1, $scope.energiauamVisaoGeralSafra, new Date($scope.energiauamVisaoGeralDiaDate).yyyymmdd())
                        .then(function (data) {
                            //Dia
                            $scope.chartEnergiaUamVisaoGeralDiaDataSource.store().clear();

                            $scope.chartEnergiaUamVisaoGeralDiaDataSource.store().insert({
                                arg: "DIA",
                                val: data.DiaVal,
                                meta: data.DiaValMax - data.DiaVal <= 0 ? 0 : data.DiaValMax - data.DiaVal
                            });

                            $scope.chartEnergiaUamVisaoGeralDiaDataSource.load();

                            $scope.energiauamVisaoGeralDiaDate = pureDate(data.Dia);
                            $scope.energiauamVisaoGeralDia = $scope.energiauamVisaoGeralDiaDate.yyyymmdd();
                            $scope.energiauamVisaoGeralDiaDisplay = $scope.energiauamVisaoGeralDiaDate.ddmmyyyy();
                            $scope.energiauamVisaoGeralHora = data.Hora;

                            $scope.energiauamVisaoGeralDiaVal = data.DiaVal;
                            $scope.energiauamVisaoGeralDiaValMax = data.DiaValMax;
                            $scope.energiauamVisaoGeralDiaIndicadorMeta = data.DiaIndicadorMeta;
                            $scope.energiauamVisaoGeralDiaIndicadorMetaColor = coresMetaArray[data.DiaIndicadorMeta];

                            //Semana
                            $scope.chartEnergiaUamVisaoGeralSemanaDataSource.store().clear();

                            $scope.chartEnergiaUamVisaoGeralSemanaDataSource.store().insert({
                                arg: "SEMANA",
                                val: data.SemanaVal,
                                meta: data.SemanaValMax - data.SemanaVal <= 0 ? 0 : data.SemanaValMax - data.SemanaVal
                            });

                            $scope.chartEnergiaUamVisaoGeralSemanaDataSource.load();

                            $scope.energiauamVisaoGeralSemana = data.Semana;
                            $scope.energiauamVisaoGeralSemanaVal = data.SemanaVal;
                            $scope.energiauamVisaoGeralSemanaValMax = data.SemanaValMax;
                            $scope.energiauamVisaoGeralSemanaIndicadorMeta = data.SemanaIndicadorMeta;
                            $scope.energiauamVisaoGeralSemanaIndicadorMetaColor = coresMetaArray[data.SemanaIndicadorMeta];

                            //Mes
                            $scope.chartEnergiaUamVisaoGeralMesDataSource.store().clear();

                            $scope.chartEnergiaUamVisaoGeralMesDataSource.store().insert({
                                arg: "MÊS",
                                val: data.MesVal,
                                meta: data.MesValMax - data.MesVal <= 0 ? 0 : data.MesValMax - data.MesVal
                            });

                            $scope.chartEnergiaUamVisaoGeralMesDataSource.load();

                            $scope.energiauamVisaoGeralMes = data.Mes;
                            $scope.energiauamVisaoGeralMesVal = data.MesVal;
                            $scope.energiauamVisaoGeralMesValMax = data.MesValMax;
                            $scope.energiauamVisaoGeralMesIndicadorMeta = data.MesIndicadorMeta;
                            $scope.energiauamVisaoGeralMesIndicadorMetaColor = coresMetaArray[data.MesIndicadorMeta];

                            //Safra
                            $scope.chartEnergiaUamVisaoGeralSafraDataSource.store().clear();

                            $scope.chartEnergiaUamVisaoGeralSafraDataSource.store().insert({
                                arg: "SAFRA",
                                val: data.SafraVal,
                                meta: data.SafraValMax - data.SafraVal <= 0 ? 0 : data.SafraValMax - data.SafraVal
                            });

                            $scope.chartEnergiaUamVisaoGeralSafraDataSource.load();

                            $scope.energiauamVisaoGeralSafra = data.Safra;
                            $scope.energiauamVisaoGeralSafraVal = data.SafraVal;
                            $scope.energiauamVisaoGeralSafraValMax = data.SafraValMax;
                            $scope.energiauamVisaoGeralSafraIndicadorMeta = data.SafraIndicadorMeta;
                            $scope.energiauamVisaoGeralSafraIndicadorMetaColor = coresMetaArray[data.SafraIndicadorMeta];

                            $scope.loadingEnergiaUamTerminado = true;
                        });
                });

            ApiGetService
                .getindustriaAcucarVisaoGeralMinMaxDiaPromise(1)
                .then(function (data) {
                    if (!semLatest) {
                        $scope.acucarVisaoGeralSafra = data.safra;
                        $scope.acucarVisaoGeralDiaMinDate = pureDate(data.MinDia);
                        $scope.acucarVisaoGeralDiaMaxDate = pureDate(data.MaxDia);
                        $scope.acucarVisaoGeralDiaDate = pureDate(data.MaxDia);

                        $scope.acucarVisaoGeralDia = $scope.acucarVisaoGeralDiaDate.yyyymmdd();
                        $scope.acucarVisaoGeralDiaDisplay = $scope.acucarVisaoGeralDiaDate.ddmmyyyy();
                        $scope.acucarVisaoGeralHora = data.MaxHora;

                        $scope.acucarVisaoGeralSemana = data.MaxSemana;

                        $scope.acucarVisaoGeralMes = data.MaxMes;

                        //$scope.acucarVisaoGeralSafra = data.Safra;
                    };

                    ApiGetService
                        .getindustriaAcucarVisaoGeralCorteDiaPromise(1, $scope.acucarVisaoGeralSafra, new Date($scope.acucarVisaoGeralDiaDate).yyyymmdd())
                        .then(function (data) {
                            //Dia
                            $scope.chartAcucarVisaoGeralDiaDataSource.store().clear();

                            $scope.chartAcucarVisaoGeralDiaDataSource.store().insert({
                                arg: "DIA",
                                val: data.DiaVal,
                                meta: data.DiaValMax - data.DiaVal <= 0 ? 0 : data.DiaValMax - data.DiaVal
                            });

                            $scope.chartAcucarVisaoGeralDiaDataSource.load();

                            $scope.acucarVisaoGeralDiaDate = pureDate(data.Dia);
                            $scope.acucarVisaoGeralDia = $scope.acucarVisaoGeralDiaDate.yyyymmdd();
                            $scope.acucarVisaoGeralDiaDisplay = $scope.acucarVisaoGeralDiaDate.ddmmyyyy();
                            $scope.acucarVisaoGeralHora = data.Hora;

                            $scope.acucarVisaoGeralDiaVal = data.DiaVal;
                            $scope.acucarVisaoGeralDiaValMax = data.DiaValMax;
                            $scope.acucarVisaoGeralDiaIndicadorMeta = data.DiaIndicadorMeta;
                            $scope.acucarVisaoGeralDiaIndicadorMetaColor = coresMetaArray[data.DiaIndicadorMeta];

                            //Semana
                            $scope.chartAcucarVisaoGeralSemanaDataSource.store().clear();

                            $scope.chartAcucarVisaoGeralSemanaDataSource.store().insert({
                                arg: "SEMANA",
                                val: data.SemanaVal,
                                meta: data.SemanaValMax - data.SemanaVal <= 0 ? 0 : data.SemanaValMax - data.SemanaVal
                            });

                            $scope.chartAcucarVisaoGeralSemanaDataSource.load();

                            $scope.acucarVisaoGeralSemana = data.Semana;
                            $scope.acucarVisaoGeralSemanaVal = data.SemanaVal;
                            $scope.acucarVisaoGeralSemanaValMax = data.SemanaValMax;
                            $scope.acucarVisaoGeralSemanaIndicadorMeta = data.SemanaIndicadorMeta;
                            $scope.acucarVisaoGeralSemanaIndicadorMetaColor = coresMetaArray[data.SemanaIndicadorMeta];

                            //Mes
                            $scope.chartAcucarVisaoGeralMesDataSource.store().clear();

                            $scope.chartAcucarVisaoGeralMesDataSource.store().insert({
                                arg: "MÊS",
                                val: data.MesVal,
                                meta: data.MesValMax - data.MesVal <= 0 ? 0 : data.MesValMax - data.MesVal
                            });

                            $scope.chartAcucarVisaoGeralMesDataSource.load();

                            $scope.acucarVisaoGeralMes = data.Mes;
                            $scope.acucarVisaoGeralMesVal = data.MesVal;
                            $scope.acucarVisaoGeralMesValMax = data.MesValMax;
                            $scope.acucarVisaoGeralMesIndicadorMeta = data.MesIndicadorMeta;
                            $scope.acucarVisaoGeralMesIndicadorMetaColor = coresMetaArray[data.MesIndicadorMeta];

                            //Safra
                            $scope.chartAcucarVisaoGeralSafraDataSource.store().clear();

                            $scope.chartAcucarVisaoGeralSafraDataSource.store().insert({
                                arg: "SAFRA",
                                val: data.SafraVal,
                                meta: data.SafraValMax - data.SafraVal <= 0 ? 0 : data.SafraValMax - data.SafraVal
                            });

                            $scope.chartAcucarVisaoGeralSafraDataSource.load();

                            $scope.acucarVisaoGeralSafra = data.Safra;
                            $scope.acucarVisaoGeralSafraVal = data.SafraVal;
                            $scope.acucarVisaoGeralSafraValMax = data.SafraValMax;
                            $scope.acucarVisaoGeralSafraIndicadorMeta = data.SafraIndicadorMeta;
                            $scope.acucarVisaoGeralSafraIndicadorMetaColor = coresMetaArray[data.SafraIndicadorMeta];

                            $scope.loadingAcucarTerminado = true;
                        });
                });

            ApiGetService
                .getindustriaEtanolVisaoGeralMinMaxDiaPromise(1)
                .then(function (data) {
                    if (!semLatest) {
                        $scope.etanolVisaoGeralSafra = data.safra;
                        $scope.etanolVisaoGeralDiaMinDate = pureDate(data.MinDia);
                        $scope.etanolVisaoGeralDiaMaxDate = pureDate(data.MaxDia);
                        $scope.etanolVisaoGeralDiaDate = pureDate(data.MaxDia);

                        $scope.etanolVisaoGeralDia = $scope.etanolVisaoGeralDiaDate.yyyymmdd();
                        $scope.etanolVisaoGeralDiaDisplay = $scope.etanolVisaoGeralDiaDate.ddmmyyyy();
                        $scope.etanolVisaoGeralHora = data.MaxHora;

                        $scope.etanolVisaoGeralSemana = data.MaxSemana;

                        $scope.etanolVisaoGeralMes = data.MaxMes;

                        //$scope.etanolVisaoGeralSafra = data.Safra;
                    };

                    ApiGetService
                        .getindustriaEtanolVisaoGeralCorteDiaPromise(1, $scope.etanolVisaoGeralSafra, new Date($scope.etanolVisaoGeralDiaDate).yyyymmdd())
                        .then(function (data) {
                            //Dia
                            $scope.chartEtanolVisaoGeralDiaDataSource.store().clear();

                            $scope.chartEtanolVisaoGeralDiaDataSource.store().insert({
                                arg: "DIA",
                                val: data.DiaVal,
                                meta: data.DiaValMax - data.DiaVal <= 0 ? 0 : data.DiaValMax - data.DiaVal
                            });

                            $scope.chartEtanolVisaoGeralDiaDataSource.load();

                            $scope.etanolVisaoGeralDiaDate = pureDate(data.Dia);
                            $scope.etanolVisaoGeralDia = $scope.etanolVisaoGeralDiaDate.yyyymmdd();
                            $scope.etanolVisaoGeralDiaDisplay = $scope.etanolVisaoGeralDiaDate.ddmmyyyy();
                            $scope.etanolVisaoGeralHora = data.Hora;

                            $scope.etanolVisaoGeralDiaVal = data.DiaVal;
                            $scope.etanolVisaoGeralDiaValMax = data.DiaValMax;
                            $scope.etanolVisaoGeralDiaIndicadorMeta = data.DiaIndicadorMeta;
                            $scope.etanolVisaoGeralDiaIndicadorMetaColor = coresMetaArray[data.DiaIndicadorMeta];

                            //Semana
                            $scope.chartEtanolVisaoGeralSemanaDataSource.store().clear();

                            $scope.chartEtanolVisaoGeralSemanaDataSource.store().insert({
                                arg: "SEMANA",
                                val: data.SemanaVal,
                                meta: data.SemanaValMax - data.SemanaVal <= 0 ? 0 : data.SemanaValMax - data.SemanaVal
                            });

                            $scope.chartEtanolVisaoGeralSemanaDataSource.load();

                            $scope.etanolVisaoGeralSemana = data.Semana;
                            $scope.etanolVisaoGeralSemanaVal = data.SemanaVal;
                            $scope.etanolVisaoGeralSemanaValMax = data.SemanaValMax;
                            $scope.etanolVisaoGeralSemanaIndicadorMeta = data.SemanaIndicadorMeta;
                            $scope.etanolVisaoGeralSemanaIndicadorMetaColor = coresMetaArray[data.SemanaIndicadorMeta];

                            //Mes
                            $scope.chartEtanolVisaoGeralMesDataSource.store().clear();

                            $scope.chartEtanolVisaoGeralMesDataSource.store().insert({
                                arg: "MÊS",
                                val: data.MesVal,
                                meta: data.MesValMax - data.MesVal <= 0 ? 0 : data.MesValMax - data.MesVal
                            });

                            $scope.chartEtanolVisaoGeralMesDataSource.load();

                            $scope.etanolVisaoGeralMes = data.Mes;
                            $scope.etanolVisaoGeralMesVal = data.MesVal;
                            $scope.etanolVisaoGeralMesValMax = data.MesValMax;
                            $scope.etanolVisaoGeralMesIndicadorMeta = data.MesIndicadorMeta;
                            $scope.etanolVisaoGeralMesIndicadorMetaColor = coresMetaArray[data.MesIndicadorMeta];

                            //Safra
                            $scope.chartEtanolVisaoGeralSafraDataSource.store().clear();

                            $scope.chartEtanolVisaoGeralSafraDataSource.store().insert({
                                arg: "SAFRA",
                                val: data.SafraVal,
                                meta: data.SafraValMax - data.SafraVal <= 0 ? 0 : data.SafraValMax - data.SafraVal
                            });

                            $scope.chartEtanolVisaoGeralSafraDataSource.load();

                            $scope.etanolVisaoGeralSafra = data.Safra;
                            $scope.etanolVisaoGeralSafraVal = data.SafraVal;
                            $scope.etanolVisaoGeralSafraValMax = data.SafraValMax;
                            $scope.etanolVisaoGeralSafraIndicadorMeta = data.SafraIndicadorMeta;
                            $scope.etanolVisaoGeralSafraIndicadorMetaColor = coresMetaArray[data.SafraIndicadorMeta];

                            $scope.loadingEtanolTerminado = true;
                        });
                });

        };

        $scope.visiblePopup = false;

        //Home
        $scope.homeVisaoGeralSafra = 0;

        $scope.homeVisaoGeralDia = "";
        $scope.homeVisaoGeralDiaDisplay = "";
        $scope.homeVisaoGeralHora = "00";

        $scope.homeVisaoGeralSemana = 0;

        $scope.homeVisaoGeralMes = 0;

        $scope.homeEficienciaArtValue = 0;
        $scope.homeEficienciaArtValueDisplay = "";
        $scope.homeEficienciaRtcValue = 0;
        $scope.homeEficienciaRtcValueDisplay = "";
        $scope.homeEficienciaCiValue = 0;
        $scope.homeEficienciaCiValueDisplay = "";

        //Moagem Visão Geral
        $scope.chartMoagemVisaoGeralDiaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartMoagemVisaoGeralSemanaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartMoagemVisaoGeralMesDataSource = new DevExpress.data.DataSource([]);
        $scope.chartMoagemVisaoGeralSafraDataSource = new DevExpress.data.DataSource([]);

        $scope.moagemVisaoGeralDia = "";
        $scope.moagemVisaoGeralDiaDisplay = "";
        $scope.moagemVisaoGeralHora = "00";
        $scope.moagemVisaoGeralHoraAnterior = function () { return ("00" + ($scope.moagemVisaoGeralHora - 1)).slice(-2); };

        $scope.moagemVisaoGeralDiaValMoagem = 0;
        $scope.moagemVisaoGeralDiaValMoagemMax = 0;
        $scope.moagemVisaoGeralDiaIndicadorMeta = 0;
        $scope.moagemVisaoGeralDiaIndicadorMetaColor = "";

        $scope.moagemVisaoGeralSemana = 0;
        $scope.moagemVisaoGeralSemanaValMoagem = 0;
        $scope.moagemVisaoGeralSemanaValMoagemMax = 0;
        $scope.moagemVisaoGeralSemanaIndicadorMeta = 0;
        $scope.moagemVisaoGeralSemanaIndicadorMetaColor = "";

        $scope.moagemVisaoGeralMes = 0;
        $scope.moagemVisaoGeralMesValMoagem = 0;
        $scope.moagemVisaoGeralMesValMoagemMax = 0;
        $scope.moagemVisaoGeralMesIndicadorMeta = 0;
        $scope.moagemVisaoGeralMesIndicadorMetaColor = "";

        $scope.moagemVisaoGeralSafra = 0;
        $scope.moagemVisaoGeralSafraValMoagem = 0;
        $scope.moagemVisaoGeralSafraValMoagemMax = 0;
        $scope.moagemVisaoGeralSafraIndicadorMeta = 0;
        $scope.moagemVisaoGeralSafraIndicadorMetaColor = "";

        //Energia Bio Visão Geral
        $scope.chartEnergiaBioVisaoGeralDiaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartEnergiaBioVisaoGeralSemanaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartEnergiaBioVisaoGeralMesDataSource = new DevExpress.data.DataSource([]);
        $scope.chartEnergiaBioVisaoGeralSafraDataSource = new DevExpress.data.DataSource([]);

        $scope.energiabioVisaoGeralDia = "";
        $scope.energiabioVisaoGeralDiaDisplay = "";
        $scope.energiabioVisaoGeralHora = "00";
        $scope.energiabioVisaoGeralHoraAnterior = function () { return ("00" + ($scope.energiabioVisaoGeralHora - 1)).slice(-2); };

        $scope.energiabioVisaoGeralDiaValMoagem = 0;
        $scope.energiabioVisaoGeralDiaValMoagemMax = 0;
        $scope.energiabioVisaoGeralDiaIndicadorMeta = 0;
        $scope.energiabioVisaoGeralDiaIndicadorMetaColor = "";

        $scope.energiabioVisaoGeralSemana = 0;
        $scope.energiabioVisaoGeralSemanaValMoagem = 0;
        $scope.energiabioVisaoGeralSemanaValMoagemMax = 0;
        $scope.energiabioVisaoGeralSemanaIndicadorMeta = 0;
        $scope.energiabioVisaoGeralSemanaIndicadorMetaColor = "";

        $scope.energiabioVisaoGeralMes = 0;
        $scope.energiabioVisaoGeralMesValMoagem = 0;
        $scope.energiabioVisaoGeralMesValMoagemMax = 0;
        $scope.energiabioVisaoGeralMesIndicadorMeta = 0;
        $scope.energiabioVisaoGeralMesIndicadorMetaColor = "";

        $scope.energiabioVisaoGeralSafra = 0;
        $scope.energiabioVisaoGeralSafraValMoagem = 0;
        $scope.energiabioVisaoGeralSafraValMoagemMax = 0;
        $scope.energiabioVisaoGeralSafraIndicadorMeta = 0;
        $scope.energiabioVisaoGeralSafraIndicadorMetaColor = "";

        //Energia Uam Visão Geral
        $scope.chartEnergiaUamVisaoGeralDiaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartEnergiaUamVisaoGeralSemanaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartEnergiaUamVisaoGeralMesDataSource = new DevExpress.data.DataSource([]);
        $scope.chartEnergiaUamVisaoGeralSafraDataSource = new DevExpress.data.DataSource([]);

        $scope.energiauamVisaoGeralDia = "";
        $scope.energiauamVisaoGeralDiaDisplay = "";
        $scope.energiauamVisaoGeralHora = "00";
        $scope.energiauamVisaoGeralHoraAnterior = function () { return ("00" + ($scope.energiauamVisaoGeralHora - 1)).slice(-2); };

        $scope.energiauamVisaoGeralDiaValMoagem = 0;
        $scope.energiauamVisaoGeralDiaValMoagemMax = 0;
        $scope.energiauamVisaoGeralDiaIndicadorMeta = 0;
        $scope.energiauamVisaoGeralDiaIndicadorMetaColor = "";

        $scope.energiauamVisaoGeralSemana = 0;
        $scope.energiauamVisaoGeralSemanaValMoagem = 0;
        $scope.energiauamVisaoGeralSemanaValMoagemMax = 0;
        $scope.energiauamVisaoGeralSemanaIndicadorMeta = 0;
        $scope.energiauamVisaoGeralSemanaIndicadorMetaColor = "";

        $scope.energiauamVisaoGeralMes = 0;
        $scope.energiauamVisaoGeralMesValMoagem = 0;
        $scope.energiauamVisaoGeralMesValMoagemMax = 0;
        $scope.energiauamVisaoGeralMesIndicadorMeta = 0;
        $scope.energiauamVisaoGeralMesIndicadorMetaColor = "";

        $scope.energiauamVisaoGeralSafra = 0;
        $scope.energiauamVisaoGeralSafraValMoagem = 0;
        $scope.energiauamVisaoGeralSafraValMoagemMax = 0;
        $scope.energiauamVisaoGeralSafraIndicadorMeta = 0;
        $scope.energiauamVisaoGeralSafraIndicadorMetaColor = "";


        //Açúcar Visão Geral
        $scope.chartAcucarVisaoGeralDiaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartAcucarVisaoGeralSemanaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartAcucarVisaoGeralMesDataSource = new DevExpress.data.DataSource([]);
        $scope.chartAcucarVisaoGeralSafraDataSource = new DevExpress.data.DataSource([]);

        $scope.acucarVisaoGeralDia = "";
        $scope.acucarVisaoGeralDiaDisplay = "";
        $scope.acucarVisaoGeralHora = "00";
        $scope.acucarVisaoGeralHoraAnterior = function () { return ("00" + ($scope.acucarVisaoGeralHora - 1)).slice(-2); };

        $scope.acucarVisaoGeralDiaValMoagem = 0;
        $scope.acucarVisaoGeralDiaValMoagemMax = 0;
        $scope.acucarVisaoGeralDiaIndicadorMeta = 0;
        $scope.acucarVisaoGeralDiaIndicadorMetaColor = "";

        $scope.acucarVisaoGeralSemana = 0;
        $scope.acucarVisaoGeralSemanaValMoagem = 0;
        $scope.acucarVisaoGeralSemanaValMoagemMax = 0;
        $scope.acucarVisaoGeralSemanaIndicadorMeta = 0;
        $scope.acucarVisaoGeralSemanaIndicadorMetaColor = "";

        $scope.acucarVisaoGeralMes = 0;
        $scope.acucarVisaoGeralMesValMoagem = 0;
        $scope.acucarVisaoGeralMesValMoagemMax = 0;
        $scope.acucarVisaoGeralMesIndicadorMeta = 0;
        $scope.acucarVisaoGeralMesIndicadorMetaColor = "";

        $scope.acucarVisaoGeralSafra = 0;
        $scope.acucarVisaoGeralSafraValMoagem = 0;
        $scope.acucarVisaoGeralSafraValMoagemMax = 0;
        $scope.acucarVisaoGeralSafraIndicadorMeta = 0;
        $scope.acucarVisaoGeralSafraIndicadorMetaColor = "";



        //Etanol Visão Geral
        $scope.chartEtanolVisaoGeralDiaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartEtanolVisaoGeralSemanaDataSource = new DevExpress.data.DataSource([]);
        $scope.chartEtanolVisaoGeralMesDataSource = new DevExpress.data.DataSource([]);
        $scope.chartEtanolVisaoGeralSafraDataSource = new DevExpress.data.DataSource([]);

        $scope.etanolVisaoGeralDia = "";
        $scope.etanolVisaoGeralDiaDisplay = "";
        $scope.etanolVisaoGeralHora = "00";
        $scope.etanolVisaoGeralHoraAnterior = function () { return ("00" + ($scope.etanolVisaoGeralHora - 1)).slice(-2); };

        $scope.etanolVisaoGeralDiaValMoagem = 0;
        $scope.etanolVisaoGeralDiaValMoagemMax = 0;
        $scope.etanolVisaoGeralDiaIndicadorMeta = 0;
        $scope.etanolVisaoGeralDiaIndicadorMetaColor = "";

        $scope.etanolVisaoGeralSemana = 0;
        $scope.etanolVisaoGeralSemanaValMoagem = 0;
        $scope.etanolVisaoGeralSemanaValMoagemMax = 0;
        $scope.etanolVisaoGeralSemanaIndicadorMeta = 0;
        $scope.etanolVisaoGeralSemanaIndicadorMetaColor = "";

        $scope.etanolVisaoGeralMes = 0;
        $scope.etanolVisaoGeralMesValMoagem = 0;
        $scope.etanolVisaoGeralMesValMoagemMax = 0;
        $scope.etanolVisaoGeralMesIndicadorMeta = 0;
        $scope.etanolVisaoGeralMesIndicadorMetaColor = "";

        $scope.etanolVisaoGeralSafra = 0;
        $scope.etanolVisaoGeralSafraValMoagem = 0;
        $scope.etanolVisaoGeralSafraValMoagemMax = 0;
        $scope.etanolVisaoGeralSafraIndicadorMeta = 0;
        $scope.etanolVisaoGeralSafraIndicadorMetaColor = "";



        $scope.autoRefreshButtonType = !window.localStorage.getItem("bi4tInd00ar") || window.localStorage.getItem("bi4tInd00ar") == 0 ? 'success' : 'normal';

        angular.element(document).ready(function() {
            //ORDEM: 2 - Document Ready Angular

            Globalize.culture("pt-BR");

            refreshAll();

            $scope.interval = null;

            if (!window.localStorage.getItem("bi4tInd00ar")) {
                window.localStorage.setItem("bi4tInd00ar", 0);
                window.localStorage.setItem("bi4tInd00arsec", 60);
            };

            $scope.autoRefresh = (window.localStorage.getItem("bi4tInd00ar") == 0);
            $scope.autoRefreshSeconds = window.localStorage.getItem("bi4tInd00arsec");

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
            min: 60,
            max: 1800,
            showSpinButtons: true
        };

        $scope.buttonOkAutoRefreshOptions = {
            text: "OK",
            onClick: function () {
                clearInterval($scope.interval);

                $scope.autoRefresh = $scope.checkBoxAutoRefresh;
                $scope.autoRefreshSeconds = $scope.numberBoxAutoRefresh;

                window.localStorage.setItem("bi4tInd00ar", $scope.autoRefresh ? 0 : 1);
                window.localStorage.setItem("bi4tInd00arsec", $scope.autoRefreshSeconds);

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
                value: 'moagemVisaoGeralDiaDate',
                max: 'moagemVisaoGeralDiaMaxDate',
                min: 'moagemVisaoGeralDiaMinDate'
            },
            formatString: 'dd/MM/yyyy',
            readOnly: false,
            invalidDateMessage: 'Conteúdo deve ser uma data válida',
            dateOutOfRangeMessage: 'Data está fora do período',
            onValueChanged: function (e) {
                if (!$scope.loadingVisible) {
                    $scope.homeVisaoGeralDiaDate = $scope.moagemVisaoGeralDiaDate > $scope.homeVisaoGeralDiaMaxDate ? $scope.homeVisaoGeralDiaDate : $scope.moagemVisaoGeralDiaDate;
                    $scope.acucarVisaoGeralDiaDate = $scope.moagemVisaoGeralDiaDate;
                    $scope.etanolVisaoGeralDiaDate = $scope.moagemVisaoGeralDiaDate;
                    $scope.energiabioVisaoGeralDiaDate = $scope.moagemVisaoGeralDiaDate;
                    $scope.energiauamVisaoGeralDiaDate = $scope.moagemVisaoGeralDiaDate;

                    refreshAll(true);
                }
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

        //Home Indicadores
        $scope.gaugeEficienciaArtOptions = {
            bindingOptions: {
                value: 'homeEficienciaArtValue',
                'title.subtitle.text':'homeEficienciaArtValueDisplay'
            },
            title: {
                text: 'ART',
                font: {
                    size: 16,
                    weight: 900
                },
                subtitle: {
                    font: {
                        size: 16
                    }
                }
            },
            size: { height: 180 },
            scale: {
                startValue: 0,
                endValue: 1,
                tickInterval: 0.2,
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
                    { startValue: 0, endValue: 0.5, color: 'red' },
                    { startValue: 0.5, endValue: 1, color: 'green' }
                ],
                width: 10
            },
            geometry: {
                startAngle: 180,
                endAngle: 0
            }
        };

        $scope.gaugeEficienciaRtcOptions = {
            bindingOptions: {
                value: 'homeEficienciaRtcValue',
                'title.subtitle.text': 'homeEficienciaRtcValueDisplay'
            },
            title: {
                text: 'RTC',
                font: {
                    size: 16,
                    weight: 900
                },
                subtitle: {
                    font: {
                        size: 16
                    }
                }
            },
            size: { height: 180 },
            scale: {
                startValue: 0,
                endValue: 1,
                tickInterval: 0.2,
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
                    { startValue: 0, endValue: 0.5, color: 'red' },
                    { startValue: 0.5, endValue: 1, color: 'green' }
                ],
                width: 10
            },
            geometry: {
                startAngle: 180,
                endAngle: 0
            }
        };

        $scope.gaugeEficienciaCIOptions = {
            bindingOptions: {
                value: 'homeEficienciaCiValue',
                'title.subtitle.text': 'homeEficienciaCiValueDisplay'
            },
            title: {
                text: 'Consumo Interno Por Ton de Cana Moída',
                font: {
                    size: 16,
                    weight: 900
                },
                subtitle: {
                    font: {
                        size: 14
                    }
                }
            },
            size: { height: 180 },
            scale: {
                startValue: 0,
                endValue: 4,
                tickInterval: 0.5,
                label: {
                    format: { number: '#.####' }
                }
            },
            valueIndicator: {
                type: "triangleNeedle",
                color: 'grey'
            },
            rangeContainer: {
                ranges: [
                    { startValue: 0, endValue: 2, color: 'red' },
                    { startValue: 2, endValue: 4, color: 'green' }
                ],
                width: 10
            },
            geometry: {
                startAngle: 180,
                endAngle: 0
            }
        };

        //Moagem Visão Geral Dia
        $scope.chartMoagemVisaoGeralDiaOptions = {
            dataSource: $scope.chartMoagemVisaoGeralDiaDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " ton"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'moagemVisaoGeralDiaValMoagemMax',
                'series[0].color': 'moagemVisaoGeralDiaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "MoagemJS/cnIndustriaMoagemJS?periodo=dia&safra=" + $scope.moagemVisaoGeralSafra + "&dia=" + pureDateString($scope.moagemVisaoGeralDiaDate));
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "MoagemJS/cnIndustriaMoagemJS?periodo=dia&safra=" + $scope.moagemVisaoGeralSafra + "&dia=" + pureDateString($scope.moagemVisaoGeralDiaDate));
            }
        };

        //Moagem Visão Geral Semana
        $scope.chartMoagemVisaoGeralSemanaOptions = {
            dataSource: $scope.chartMoagemVisaoGeralSemanaDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " ton"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'moagemVisaoGeralSemanaValMoagemMax',
                'series[0].color': 'moagemVisaoGeralSemanaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "MoagemJS/cnIndustriaMoagemJS?periodo=semana&safra=" + $scope.moagemVisaoGeralSafra + "&dia=" + pureDateString($scope.moagemVisaoGeralDiaDate) + "&semana=" + $scope.moagemVisaoGeralSemana);
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "MoagemJS/cnIndustriaMoagemJS?periodo=semana&safra=" + $scope.moagemVisaoGeralSafra + "&dia=" + pureDateString($scope.moagemVisaoGeralDiaDate) + "&semana=" + $scope.moagemVisaoGeralSemana);
            }
        };

        //Moagem Visão Geral Mês
        $scope.chartMoagemVisaoGeralMesOptions = {
            dataSource: $scope.chartMoagemVisaoGeralMesDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " ton"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'moagemVisaoGeralMesValMoagemMax',
                'series[0].color': 'moagemVisaoGeralMesIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "MoagemJS/cnIndustriaMoagemJS?periodo=mes&safra=" + $scope.moagemVisaoGeralSafra + "&dia=" + pureDateString($scope.moagemVisaoGeralDiaDate) + "&mes=" + $scope.moagemVisaoGeralMes);
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "MoagemJS/cnIndustriaMoagemJS?periodo=mes&safra=" + $scope.moagemVisaoGeralSafra + "&dia=" + pureDateString($scope.moagemVisaoGeralDiaDate) + "&mes=" + $scope.moagemVisaoGeralMes);
            }
        };

        //Moagem Visão Geral Safra
        $scope.chartMoagemVisaoGeralSafraOptions = {
            dataSource: $scope.chartMoagemVisaoGeralSafraDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " ton"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'moagemVisaoGeralSafraValMoagemMax',
                'series[0].color': 'moagemVisaoGeralSafraIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "MoagemJS/cnIndustriaMoagemJS?periodo=safra&safra=" + $scope.moagemVisaoGeralSafra + "&dia=" + pureDateString($scope.moagemVisaoGeralDiaDate));
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "MoagemJS/cnIndustriaMoagemJS?periodo=safra&safra=" + $scope.moagemVisaoGeralSafra + "&dia=" + pureDateString($scope.moagemVisaoGeralDiaDate));
            }
        };



        //Energia Bio Visão Geral Dia
        $scope.chartEnergiaBioVisaoGeralDiaOptions = {
            dataSource: $scope.chartEnergiaBioVisaoGeralDiaDataSource,
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
                //'valueAxis.max': 'energiabioVisaoGeralDiaValMax',
                'series[0].color': 'energiabioVisaoGeralDiaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaBioJS/cnIndustriaEnergiaBioJS?periodo=dia&safra=" + $scope.energiabioVisaoGeralSafra + "&dia=" + pureDateString($scope.energiabioVisaoGeralDiaDate));
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaBioJS/cnIndustriaEnergiaBioJS?periodo=dia&safra=" + $scope.energiabioVisaoGeralSafra + "&dia=" + pureDateString($scope.energiabioVisaoGeralDiaDate));
            }
        };

        //Energia Bio Visão Geral Semana
        $scope.chartEnergiaBioVisaoGeralSemanaOptions = {
            dataSource: $scope.chartEnergiaBioVisaoGeralSemanaDataSource,
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
                //'valueAxis.max': 'energiabioVisaoGeralSemanaValMax',
                'series[0].color': 'energiabioVisaoGeralSemanaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaBioJS/cnIndustriaEnergiaBioJS?periodo=semana&safra=" + $scope.energiabioVisaoGeralSafra + "&dia=" + pureDateString($scope.energiabioVisaoGeralDiaDate) + "&semana=" + $scope.energiabioVisaoGeralSemana);
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaBioJS/cnIndustriaEnergiaBioJS?periodo=semana&safra=" + $scope.energiabioVisaoGeralSafra + "&dia=" + pureDateString($scope.energiabioVisaoGeralDiaDate) + "&semana=" + $scope.energiabioVisaoGeralSemana);
            }
        };

        //Energia Bio Visão Geral Mês
        $scope.chartEnergiaBioVisaoGeralMesOptions = {
            dataSource: $scope.chartEnergiaBioVisaoGeralMesDataSource,
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
                //'valueAxis.max': 'energiabioVisaoGeralMesValMax',
                'series[0].color': 'energiabioVisaoGeralMesIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaBioJS/cnIndustriaEnergiaBioJS?periodo=mes&safra=" + $scope.energiabioVisaoGeralSafra + "&dia=" + pureDateString($scope.energiabioVisaoGeralDiaDate) + "&mes=" + $scope.energiabioVisaoGeralMes);
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaBioJS/cnIndustriaEnergiaBioJS?periodo=mes&safra=" + $scope.energiabioVisaoGeralSafra + "&dia=" + pureDateString($scope.energiabioVisaoGeralDiaDate) + "&mes=" + $scope.energiabioVisaoGeralMes);
            }
        };

        //Energia Bio Visão Geral Safra
        $scope.chartEnergiaBioVisaoGeralSafraOptions = {
            dataSource: $scope.chartEnergiaBioVisaoGeralSafraDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " MWh"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'energiabioVisaoGeralSafraValMax',
                'series[0].color': 'energiabioVisaoGeralSafraIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaBioJS/cnIndustriaEnergiaBioJS?periodo=safra&safra=" + $scope.energiabioVisaoGeralSafra + "&dia=" + pureDateString($scope.energiabioVisaoGeralDiaDate));
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaBioJS/cnIndustriaEnergiaBioJS?periodo=safra&safra=" + $scope.energiabioVisaoGeralSafra + "&dia=" + pureDateString($scope.energiabioVisaoGeralDiaDate));
            }
        };



        //Energia Uam Visão Geral Dia
        $scope.chartEnergiaUamVisaoGeralDiaOptions = {
            dataSource: $scope.chartEnergiaUamVisaoGeralDiaDataSource,
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
                //'valueAxis.max': 'energiauamVisaoGeralDiaValMax',
                'series[0].color': 'energiauamVisaoGeralDiaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaUamJS/cnIndustriaEnergiaUamJS?periodo=dia&safra=" + $scope.energiauamVisaoGeralSafra + "&dia=" + pureDateString($scope.energiauamVisaoGeralDiaDate));
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaUamJS/cnIndustriaEnergiaUamJS?periodo=dia&safra=" + $scope.energiauamVisaoGeralSafra + "&dia=" + pureDateString($scope.energiauamVisaoGeralDiaDate));
            }
        };

        //Energia Uam Visão Geral Semana
        $scope.chartEnergiaUamVisaoGeralSemanaOptions = {
            dataSource: $scope.chartEnergiaUamVisaoGeralSemanaDataSource,
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
                //'valueAxis.max': 'energiauamVisaoGeralSemanaValMax',
                'series[0].color': 'energiauamVisaoGeralSemanaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaUamJS/cnIndustriaEnergiaUamJS?periodo=semana&safra=" + $scope.energiauamVisaoGeralSafra + "&dia=" + pureDateString($scope.energiauamVisaoGeralDiaDate) + "&semana=" + $scope.energiauamVisaoGeralSemana);
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaUamJS/cnIndustriaEnergiaUamJS?periodo=semana&safra=" + $scope.energiauamVisaoGeralSafra + "&dia=" + pureDateString($scope.energiauamVisaoGeralDiaDate) + "&semana=" + $scope.energiauamVisaoGeralSemana);
            }
        };

        //Energia Uam Visão Geral Mês
        $scope.chartEnergiaUamVisaoGeralMesOptions = {
            dataSource: $scope.chartEnergiaUamVisaoGeralMesDataSource,
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
                //'valueAxis.max': 'energiauamVisaoGeralMesValMax',
                'series[0].color': 'energiauamVisaoGeralMesIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaUamJS/cnIndustriaEnergiaUamJS?periodo=mes&safra=" + $scope.energiauamVisaoGeralSafra + "&dia=" + pureDateString($scope.energiauamVisaoGeralDiaDate) + "&mes=" + $scope.energiauamVisaoGeralMes);
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaUamJS/cnIndustriaEnergiaUamJS?periodo=mes&safra=" + $scope.energiauamVisaoGeralSafra + "&dia=" + pureDateString($scope.energiauamVisaoGeralDiaDate) + "&mes=" + $scope.energiauamVisaoGeralMes);
            }
        };

        //Energia Uam Visão Geral Safra
        $scope.chartEnergiaUamVisaoGeralSafraOptions = {
            dataSource: $scope.chartEnergiaUamVisaoGeralSafraDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " MWh"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'energiauamVisaoGeralSafraValMax',
                'series[0].color': 'energiauamVisaoGeralSafraIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaUamJS/cnIndustriaEnergiaUamJS?periodo=safra&safra=" + $scope.energiauamVisaoGeralSafra + "&dia=" + pureDateString($scope.energiauamVisaoGeralDiaDate));
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EnergiaUamJS/cnIndustriaEnergiaUamJS?periodo=safra&safra=" + $scope.energiauamVisaoGeralSafra + "&dia=" + pureDateString($scope.energiauamVisaoGeralDiaDate));
            }
        };



        //Açúcar Visão Geral Dia
        $scope.chartAcucarVisaoGeralDiaOptions = {
            dataSource: $scope.chartAcucarVisaoGeralDiaDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " scs"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'acucarVisaoGeralDiaValMax',
                'series[0].color': 'acucarVisaoGeralDiaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "AcucarJS/cnIndustriaAcucarJS?periodo=dia&safra=" + $scope.acucarVisaoGeralSafra + "&dia=" + pureDateString($scope.acucarVisaoGeralDiaDate));
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "AcucarJS/cnIndustriaAcucarJS?periodo=dia&safra=" + $scope.acucarVisaoGeralSafra + "&dia=" + pureDateString($scope.acucarVisaoGeralDiaDate));
            }
        };

        //Açúcar Visão Geral Semana
        $scope.chartAcucarVisaoGeralSemanaOptions = {
            dataSource: $scope.chartAcucarVisaoGeralSemanaDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " scs"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'acucarVisaoGeralSemanaValMax',
                'series[0].color': 'acucarVisaoGeralSemanaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "AcucarJS/cnIndustriaAcucarJS?periodo=semana&safra=" + $scope.acucarVisaoGeralSafra + "&dia=" + pureDateString($scope.acucarVisaoGeralDiaDate) + "&semana=" + $scope.acucarVisaoGeralSemana);
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "AcucarJS/cnIndustriaAcucarJS?periodo=semana&safra=" + $scope.acucarVisaoGeralSafra + "&dia=" + pureDateString($scope.acucarVisaoGeralDiaDate) + "&semana=" + $scope.acucarVisaoGeralSemana);
            }
        };

        //Açúcar Visão Geral Mês
        $scope.chartAcucarVisaoGeralMesOptions = {
            dataSource: $scope.chartAcucarVisaoGeralMesDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " scs"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'acucarVisaoGeralMesValMax',
                'series[0].color': 'acucarVisaoGeralMesIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "AcucarJS/cnIndustriaAcucarJS?periodo=mes&safra=" + $scope.acucarVisaoGeralSafra + "&dia=" + pureDateString($scope.acucarVisaoGeralDiaDate) + "&mes=" + $scope.acucarVisaoGeralMes);
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "AcucarJS/cnIndustriaAcucarJS?periodo=mes&safra=" + $scope.acucarVisaoGeralSafra + "&dia=" + pureDateString($scope.acucarVisaoGeralDiaDate) + "&mes=" + $scope.acucarVisaoGeralMes);
            }
        };

        //Açúcar Visão Geral Safra
        $scope.chartAcucarVisaoGeralSafraOptions = {
            dataSource: $scope.chartAcucarVisaoGeralSafraDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " scs"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'acucarVisaoGeralSafraValMax',
                'series[0].color': 'acucarVisaoGeralSafraIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "AcucarJS/cnIndustriaAcucarJS?periodo=safra&safra=" + $scope.acucarVisaoGeralSafra + "&dia=" + pureDateString($scope.acucarVisaoGeralDiaDate));
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "AcucarJS/cnIndustriaAcucarJS?periodo=safra&safra=" + $scope.acucarVisaoGeralSafra + "&dia=" + pureDateString($scope.acucarVisaoGeralDiaDate));
            }
        };




        //Etanol Visão Geral Dia
        $scope.chartEtanolVisaoGeralDiaOptions = {
            dataSource: $scope.chartEtanolVisaoGeralDiaDataSource,
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
                //'valueAxis.max': 'etanolVisaoGeralDiaValMax',
                'series[0].color': 'etanolVisaoGeralDiaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EtanolJS/cnIndustriaEtanolJS?periodo=dia&safra=" + $scope.etanolVisaoGeralSafra + "&dia=" + pureDateString($scope.etanolVisaoGeralDiaDate));
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EtanolJS/cnIndustriaEtanolJS?periodo=dia&safra=" + $scope.etanolVisaoGeralSafra + "&dia=" + pureDateString($scope.etanolVisaoGeralDiaDate));
            }
        };

        //Etanol Visão Geral Semana
        $scope.chartEtanolVisaoGeralSemanaOptions = {
            dataSource: $scope.chartEtanolVisaoGeralSemanaDataSource,
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
                //'valueAxis.max': 'etanolVisaoGeralSemanaValMax',
                'series[0].color': 'etanolVisaoGeralSemanaIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EtanolJS/cnIndustriaEtanolJS?periodo=semana&safra=" + $scope.etanolVisaoGeralSafra + "&dia=" + pureDateString($scope.etanolVisaoGeralDiaDate) + "&semana=" + $scope.etanolVisaoGeralSemana);
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EtanolJS/cnIndustriaEtanolJS?periodo=semana&safra=" + $scope.etanolVisaoGeralSafra + "&dia=" + pureDateString($scope.etanolVisaoGeralDiaDate) + "&semana=" + $scope.etanolVisaoGeralSemana);
            }
        };

        //Etanol Visão Geral Mês
        $scope.chartEtanolVisaoGeralMesOptions = {
            dataSource: $scope.chartEtanolVisaoGeralMesDataSource,
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
                //'valueAxis.max': 'etanolVisaoGeralMesValMax',
                'series[0].color': 'etanolVisaoGeralMesIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EtanolJS/cnIndustriaEtanolJS?periodo=mes&safra=" + $scope.etanolVisaoGeralSafra + "&dia=" + pureDateString($scope.etanolVisaoGeralDiaDate) + "&mes=" + $scope.etanolVisaoGeralMes);
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EtanolJS/cnIndustriaEtanolJS?periodo=mes&safra=" + $scope.etanolVisaoGeralSafra + "&dia=" + pureDateString($scope.etanolVisaoGeralDiaDate) + "&mes=" + $scope.etanolVisaoGeralMes);
            }
        };

        //Etanol Visão Geral Safra
        $scope.chartEtanolVisaoGeralSafraOptions = {
            dataSource: $scope.chartEtanolVisaoGeralSafraDataSource,
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
                    customizeText: function () { return parseFloat(this.valueText).toLocaleString() + " m³"; }
                }
            },
            bindingOptions: {
                //'valueAxis.max': 'etanolVisaoGeralSafraValMax',
                'series[0].color': 'etanolVisaoGeralSafraIndicadorMetaColor'
            },
            size: {
                height: chartsVisaoGeralHeight
            },
            onArgumentAxisClick: function (e) {
                window.location.replace(getAppPath() + "EtanolJS/cnIndustriaEtanolJS?periodo=safra&safra=" + $scope.etanolVisaoGeralSafra + "&dia=" + pureDateString($scope.etanolVisaoGeralDiaDate));
            },
            onSeriesClick: function (e) {
                window.location.replace(getAppPath() + "EtanolJS/cnIndustriaEtanolJS?periodo=safra&safra=" + $scope.etanolVisaoGeralSafra + "&dia=" + pureDateString($scope.etanolVisaoGeralDiaDate));
            }
        };


    };
})();