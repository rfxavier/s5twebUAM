(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getindustriaEnergiaBioVisaoGeralMinMaxDiaPromise: getindustriaEnergiaBioVisaoGeralMinMaxDiaPromise(),
            getindustriaEnergiaBioVisaoGeralPromise: getindustriaEnergiaBioVisaoGeralPromise(),
            getindustriaEnergiaBioVisaoGeralCorteDiaPromise: getindustriaEnergiaBioVisaoGeralCorteDiaPromise(),
            getindustriaEnergiaBioPorDiaPromise: getindustriaEnergiaBioPorDiaPromise(),
            getindustriaEnergiaBioPorSemanaPromise: getindustriaEnergiaBioPorSemanaPromise(),
            getindustriaEnergiaBioPorMesPromise: getindustriaEnergiaBioPorMesPromise(),
            getindustriaEnergiaBioPorSafraPromise: getindustriaEnergiaBioPorSafraPromise(),
            getindustriaEnergiaBioPorSafraCorteDiaPromise: getindustriaEnergiaBioPorSafraCorteDiaPromise()
        };

        return service;

        function getindustriaEnergiaBioVisaoGeralMinMaxDiaPromise(idNegocios) {
            var industriaEnergiaBioVisaoGeralMinMaxDiaPromise = function (idNegocios) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaBio/VisaoGeralMinMaxDia/' + idNegocios))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaBioVisaoGeralMinMaxDiaPromise;
        };

        function getindustriaEnergiaBioVisaoGeralPromise(idNegocios, safra) {
            var industriaEnergiaBioVisaoGeralPromise = function(idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaBio/VisaoGeral/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaBioVisaoGeralPromise;
        };

        function getindustriaEnergiaBioVisaoGeralCorteDiaPromise(idNegocios, safra, dia) {
            var industriaEnergiaBioVisaoGeralCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaBio/VisaoGeralCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaBioVisaoGeralCorteDiaPromise;
        };

        function getindustriaEnergiaBioPorDiaPromise(idNegocios, safra, dia) {
            var industriaEnergiaBioPorDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaBio/PorDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaBioPorDiaPromise;
        };

        function getindustriaEnergiaBioPorSemanaPromise(idNegocios, safra, semana) {
            var industriaEnergiaBioPorSemanaPromise = function (idNegocios, safra, semana) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaBio/PorSemana/' + idNegocios + '/' + safra + '/' + semana))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaBioPorSemanaPromise;
        };

        function getindustriaEnergiaBioPorMesPromise(idNegocios, safra, mes) {
            var industriaEnergiaBioPorMesPromise = function (idNegocios, safra, mes) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaBio/PorMes/' + idNegocios + '/' + safra + '/' + mes))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaBioPorMesPromise;
        };
        
        function getindustriaEnergiaBioPorSafraPromise(idNegocios, safra) {
            var industriaEnergiaBioPorSafraPromise = function (idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaBio/PorSafra/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaBioPorSafraPromise;
        };

        function getindustriaEnergiaBioPorSafraCorteDiaPromise(idNegocios, safra, dia) {
            var industriaEnergiaBioPorSafraCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaBio/PorSafraCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaBioPorSafraCorteDiaPromise;
        };
        
    };
})();