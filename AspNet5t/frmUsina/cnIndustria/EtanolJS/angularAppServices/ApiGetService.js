(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getindustriaEtanolVisaoGeralMinMaxDiaPromise: getindustriaEtanolVisaoGeralMinMaxDiaPromise(),
            getindustriaEtanolVisaoGeralPromise: getindustriaEtanolVisaoGeralPromise(),
            getindustriaEtanolVisaoGeralCorteDiaPromise: getindustriaEtanolVisaoGeralCorteDiaPromise(),
            getindustriaEtanolPorDiaPromise: getindustriaEtanolPorDiaPromise(),
            getindustriaEtanolPorSemanaPromise: getindustriaEtanolPorSemanaPromise(),
            getindustriaEtanolPorMesPromise: getindustriaEtanolPorMesPromise(),
            getindustriaEtanolPorSafraPromise: getindustriaEtanolPorSafraPromise(),
            getindustriaEtanolPorSafraCorteDiaPromise: getindustriaEtanolPorSafraCorteDiaPromise()
        };

        return service;

        function getindustriaEtanolVisaoGeralMinMaxDiaPromise(idNegocios) {
            var industriaEtanolVisaoGeralMinMaxDiaPromise = function (idNegocios) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEtanol/VisaoGeralMinMaxDia/' + idNegocios))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEtanolVisaoGeralMinMaxDiaPromise;
        };

        function getindustriaEtanolVisaoGeralPromise(idNegocios, safra) {
            var industriaEtanolVisaoGeralPromise = function(idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEtanol/VisaoGeral/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEtanolVisaoGeralPromise;
        };

        function getindustriaEtanolVisaoGeralCorteDiaPromise(idNegocios, safra, dia) {
            var industriaEtanolVisaoGeralCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEtanol/VisaoGeralCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEtanolVisaoGeralCorteDiaPromise;
        };

        function getindustriaEtanolPorDiaPromise(idNegocios, safra, dia) {
            var industriaEtanolPorDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEtanol/PorDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEtanolPorDiaPromise;
        };

        function getindustriaEtanolPorSemanaPromise(idNegocios, safra, semana) {
            var industriaEtanolPorSemanaPromise = function (idNegocios, safra, semana) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEtanol/PorSemana/' + idNegocios + '/' + safra + '/' + semana))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEtanolPorSemanaPromise;
        };

        function getindustriaEtanolPorMesPromise(idNegocios, safra, mes) {
            var industriaEtanolPorMesPromise = function (idNegocios, safra, mes) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEtanol/PorMes/' + idNegocios + '/' + safra + '/' + mes))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEtanolPorMesPromise;
        };
        
        function getindustriaEtanolPorSafraPromise(idNegocios, safra) {
            var industriaEtanolPorSafraPromise = function (idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEtanol/PorSafra/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEtanolPorSafraPromise;
        };

        function getindustriaEtanolPorSafraCorteDiaPromise(idNegocios, safra, dia) {
            var industriaEtanolPorSafraCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEtanol/PorSafraCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEtanolPorSafraCorteDiaPromise;
        };
        
    };
})();