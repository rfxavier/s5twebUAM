(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getindustriaEnergiaUamVisaoGeralMinMaxDiaPromise: getindustriaEnergiaUamVisaoGeralMinMaxDiaPromise(),
            getindustriaEnergiaUamVisaoGeralPromise: getindustriaEnergiaUamVisaoGeralPromise(),
            getindustriaEnergiaUamVisaoGeralCorteDiaPromise: getindustriaEnergiaUamVisaoGeralCorteDiaPromise(),
            getindustriaEnergiaUamPorDiaPromise: getindustriaEnergiaUamPorDiaPromise(),
            getindustriaEnergiaUamPorSemanaPromise: getindustriaEnergiaUamPorSemanaPromise(),
            getindustriaEnergiaUamPorMesPromise: getindustriaEnergiaUamPorMesPromise(),
            getindustriaEnergiaUamPorSafraPromise: getindustriaEnergiaUamPorSafraPromise(),
            getindustriaEnergiaUamPorSafraCorteDiaPromise: getindustriaEnergiaUamPorSafraCorteDiaPromise()
        };

        return service;

        function getindustriaEnergiaUamVisaoGeralMinMaxDiaPromise(idNegocios) {
            var industriaEnergiaUamVisaoGeralMinMaxDiaPromise = function (idNegocios) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaUam/VisaoGeralMinMaxDia/' + idNegocios))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaUamVisaoGeralMinMaxDiaPromise;
        };

        function getindustriaEnergiaUamVisaoGeralPromise(idNegocios, safra) {
            var industriaEnergiaUamVisaoGeralPromise = function(idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaUam/VisaoGeral/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaUamVisaoGeralPromise;
        };

        function getindustriaEnergiaUamVisaoGeralCorteDiaPromise(idNegocios, safra, dia) {
            var industriaEnergiaUamVisaoGeralCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaUam/VisaoGeralCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaUamVisaoGeralCorteDiaPromise;
        };

        function getindustriaEnergiaUamPorDiaPromise(idNegocios, safra, dia) {
            var industriaEnergiaUamPorDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaUam/PorDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaUamPorDiaPromise;
        };

        function getindustriaEnergiaUamPorSemanaPromise(idNegocios, safra, semana) {
            var industriaEnergiaUamPorSemanaPromise = function (idNegocios, safra, semana) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaUam/PorSemana/' + idNegocios + '/' + safra + '/' + semana))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaUamPorSemanaPromise;
        };

        function getindustriaEnergiaUamPorMesPromise(idNegocios, safra, mes) {
            var industriaEnergiaUamPorMesPromise = function (idNegocios, safra, mes) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaUam/PorMes/' + idNegocios + '/' + safra + '/' + mes))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaUamPorMesPromise;
        };
        
        function getindustriaEnergiaUamPorSafraPromise(idNegocios, safra) {
            var industriaEnergiaUamPorSafraPromise = function (idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaUam/PorSafra/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaUamPorSafraPromise;
        };

        function getindustriaEnergiaUamPorSafraCorteDiaPromise(idNegocios, safra, dia) {
            var industriaEnergiaUamPorSafraCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaEnergiaUam/PorSafraCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaEnergiaUamPorSafraCorteDiaPromise;
        };
        
    };
})();