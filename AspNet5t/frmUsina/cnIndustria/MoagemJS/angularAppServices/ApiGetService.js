(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getindustriaMoagemVisaoGeralMinMaxDiaPromise: getindustriaMoagemVisaoGeralMinMaxDiaPromise(),
            getindustriaMoagemVisaoGeralPromise: getindustriaMoagemVisaoGeralPromise(),
            getindustriaMoagemVisaoGeralCorteDiaPromise: getindustriaMoagemVisaoGeralCorteDiaPromise(),
            getindustriaMoagemPorDiaPromise: getindustriaMoagemPorDiaPromise(),
            getindustriaMoagemPorSemanaPromise: getindustriaMoagemPorSemanaPromise(),
            getindustriaMoagemPorMesPromise: getindustriaMoagemPorMesPromise(),
            getindustriaMoagemPorSafraPromise: getindustriaMoagemPorSafraPromise(),
            getindustriaMoagemPorSafraCorteDiaPromise: getindustriaMoagemPorSafraCorteDiaPromise()
        };

        return service;

        function getindustriaMoagemVisaoGeralMinMaxDiaPromise(idNegocios) {
            var industriaMoagemVisaoGeralMinMaxDiaPromise = function (idNegocios) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaMoagem/VisaoGeralMinMaxDia/' + idNegocios))
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

        function getindustriaMoagemVisaoGeralPromise(idNegocios, safra) {
            var industriaMoagemVisaoGeralPromise = function(idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaMoagem/VisaoGeral/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaMoagemVisaoGeralPromise;
        };

        function getindustriaMoagemVisaoGeralCorteDiaPromise(idNegocios, safra, dia) {
            var industriaMoagemVisaoGeralCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaMoagem/VisaoGeralCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

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

        function getindustriaMoagemPorSafraCorteDiaPromise(idNegocios, safra, dia) {
            var industriaMoagemPorSafraCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaMoagem/PorSafraCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaMoagemPorSafraCorteDiaPromise;
        };
        
    };
})();