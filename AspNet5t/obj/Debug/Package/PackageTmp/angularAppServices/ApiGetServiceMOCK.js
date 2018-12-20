(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getentradacanasdetMapaPromise: getentradacanasdetMapaPromise(),
            getindustriaMoagemVisaoGeralMinMaxDiaPromise: getindustriaMoagemVisaoGeralMinMaxDiaPromise(),
            getindustriaMoagemVisaoGeralPromise: getindustriaMoagemVisaoGeralPromise(),
            getindustriaMoagemVisaoGeralCorteDiaPromise: getindustriaMoagemVisaoGeralCorteDiaPromise(),
            getindustriaMoagemPorDiaPromise: getindustriaMoagemPorDiaPromise(),
            getindustriaMoagemPorSemanaPromise: getindustriaMoagemPorSemanaPromise(),
            getindustriaMoagemPorMesPromise: getindustriaMoagemPorMesPromise(),
            getindustriaMoagemPorSafraPromise: getindustriaMoagemPorSafraPromise()
        };

        return service;

        function getentradacanasdetMapaPromise() {
            var entradacanasdetPromise = function () {
                var defer = $q.defer();

                $http.get('EntradaCanaDetMapa.json')
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return entradacanasdetPromise;

        };

        function getindustriaMoagemVisaoGeralMinMaxDiaPromise(idNegocios, safra) {
            var industriaMoagemVisaoGeralMinMaxDiaPromise = function (idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaMoagem/VisaoGeralMinMaxDia/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaMoagemVisaoGeralMinMaxDiaPromise;
        };


        function getindustriaMoagemVisaoGeralPromise(idNegocios, safra, dia) {
            var industriaMoagemVisaoGeralPromise = function (idNegocios, safra) {
                var defer = $q.defer();

                var data = {
                    "Dia": "2017-11-17T00:00:00",
                    "Hora": "23",
                    "DiaValMoagem": 12000,
                    "DiaValMoagemMax": 24000,
                    "DiaIndicadorMeta": 1,
                    "Semana": 46,
                    "SemanaValMoagem": 125606,
                    "SemanaValMoagemMax": 200000,
                    "SemanaIndicadorMeta": 0,
                    "Mes": 11,
                    "MesValMoagem": 171682,
                    "MesValMoagemMax": 400000,
                    "MesIndicadorMeta": 2,
                    "Safra": 2017,
                    "SafraValMoagem": 3500000,
                    "SafraValMoagemMax": 6800000,
                    "SafraIndicadorMeta": 0
                };

                defer.resolve(data);

                return defer.promise;
            };

            return industriaMoagemVisaoGeralPromise;
        };

        function getindustriaMoagemVisaoGeralCorteDiaPromise(idNegocios, safra, dia) {
            var industriaMoagemVisaoGeralCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                var data = {
                    "Dia": "2017-11-10T00:00:00",
                    "Hora": "23",
                    "DiaValMoagem": 24559,
                    "DiaValMoagemMax": 40000,
                    "DiaIndicadorMeta": 2,
                    "Semana": 45,
                    "SemanaValMoagem": 95800,
                    "SemanaValMoagemMax": 280000,
                    "SemanaIndicadorMeta": 2,
                    "Mes": 11,
                    "MesValMoagem": 157510,
                    "MesValMoagemMax": 1000000,
                    "MesIndicadorMeta": 2,
                    "Safra": 2017,
                    "SafraValMoagem": 5571917,
                    "SafraValMoagemMax": 6000000,
                    "SafraIndicadorMeta": 2
                };

                defer.resolve(data);

                return defer.promise;
            };

            return industriaMoagemVisaoGeralCorteDiaPromise;
        };

        function getindustriaMoagemPorDiaPromise(idNegocios, safra, dia) {
            var industriaMoagemPorDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaMoagem/PorDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaMoagemPorDiaPromise;
        };

        function getindustriaMoagemPorSemanaPromise(idNegocios, safra, semana) {
            var industriaMoagemPorSemanaPromise = function (idNegocios, safra, semana) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaMoagem/PorSemana/' + idNegocios + '/' + safra + '/' + semana))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaMoagemPorSemanaPromise;
        };

        function getindustriaMoagemPorMesPromise(idNegocios, safra, mes) {
            var industriaMoagemPorMesPromise = function (idNegocios, safra, mes) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaMoagem/PorMes/' + idNegocios + '/' + safra + '/' + mes))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaMoagemPorMesPromise;
        };

        function getindustriaMoagemPorSafraPromise(idNegocios, safra) {
            var industriaMoagemPorSafraPromise = function (idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaMoagem/PorSafra/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaMoagemPorSafraPromise;
        };

    };
})();