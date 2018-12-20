(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getindustriaAcucarVisaoGeralMinMaxDiaPromise: getindustriaAcucarVisaoGeralMinMaxDiaPromise(),
            getindustriaAcucarVisaoGeralPromise: getindustriaAcucarVisaoGeralPromise(),
            getindustriaAcucarVisaoGeralCorteDiaPromise: getindustriaAcucarVisaoGeralCorteDiaPromise(),
            getindustriaAcucarPorDiaPromise: getindustriaAcucarPorDiaPromise(),
            getindustriaAcucarPorSemanaPromise: getindustriaAcucarPorSemanaPromise(),
            getindustriaAcucarPorMesPromise: getindustriaAcucarPorMesPromise(),
            getindustriaAcucarPorSafraPromise: getindustriaAcucarPorSafraPromise(),
            getindustriaAcucarPorSafraCorteDiaPromise: getindustriaAcucarPorSafraCorteDiaPromise()
        };

        return service;

        function getindustriaAcucarVisaoGeralMinMaxDiaPromise(idNegocios) {
            var industriaAcucarVisaoGeralMinMaxDiaPromise = function (idNegocios) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaAcucar/VisaoGeralMinMaxDia/' + idNegocios))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaAcucarVisaoGeralMinMaxDiaPromise;
        };

        function getindustriaAcucarVisaoGeralPromise(idNegocios, safra) {
            var industriaAcucarVisaoGeralPromise = function(idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaAcucar/VisaoGeral/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaAcucarVisaoGeralPromise;
        };

        function getindustriaAcucarVisaoGeralCorteDiaPromise(idNegocios, safra, dia) {
            var industriaAcucarVisaoGeralCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaAcucar/VisaoGeralCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaAcucarVisaoGeralCorteDiaPromise;
        };

        function getindustriaAcucarPorDiaPromise(idNegocios, safra, dia) {
            var industriaAcucarPorDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaAcucar/PorDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaAcucarPorDiaPromise;
        };

        function getindustriaAcucarPorSemanaPromise(idNegocios, safra, semana) {
            var industriaAcucarPorSemanaPromise = function (idNegocios, safra, semana) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaAcucar/PorSemana/' + idNegocios + '/' + safra + '/' + semana))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaAcucarPorSemanaPromise;
        };

        function getindustriaAcucarPorMesPromise(idNegocios, safra, mes) {
            var industriaAcucarPorMesPromise = function (idNegocios, safra, mes) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaAcucar/PorMes/' + idNegocios + '/' + safra + '/' + mes))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaAcucarPorMesPromise;
        };
        
        function getindustriaAcucarPorSafraPromise(idNegocios, safra) {
            var industriaAcucarPorSafraPromise = function (idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaAcucar/PorSafra/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaAcucarPorSafraPromise;
        };

        function getindustriaAcucarPorSafraCorteDiaPromise(idNegocios, safra, dia) {
            var industriaAcucarPorSafraCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaAcucar/PorSafraCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaAcucarPorSafraCorteDiaPromise;
        };
        
    };
})();