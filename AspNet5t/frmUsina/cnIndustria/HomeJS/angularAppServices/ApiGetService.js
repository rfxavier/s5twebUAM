(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getindustriaHomeVisaoGeralMinMaxDiaPromise: getindustriaHomeVisaoGeralMinMaxDiaPromise(),
            getindustriaHomePorDiaPromise: getindustriaHomePorDiaPromise(),
            getindustriaMoagemVisaoGeralMinMaxDiaPromise: getindustriaMoagemVisaoGeralMinMaxDiaPromise(),
            getindustriaMoagemVisaoGeralCorteDiaPromise: getindustriaMoagemVisaoGeralCorteDiaPromise(),
            getindustriaEnergiaBioVisaoGeralMinMaxDiaPromise: getindustriaEnergiaBioVisaoGeralMinMaxDiaPromise(),
            getindustriaEnergiaBioVisaoGeralCorteDiaPromise: getindustriaEnergiaBioVisaoGeralCorteDiaPromise(),
            getindustriaEnergiaUamVisaoGeralMinMaxDiaPromise: getindustriaEnergiaUamVisaoGeralMinMaxDiaPromise(),
            getindustriaEnergiaUamVisaoGeralCorteDiaPromise: getindustriaEnergiaUamVisaoGeralCorteDiaPromise(),
            getindustriaAcucarVisaoGeralMinMaxDiaPromise: getindustriaAcucarVisaoGeralMinMaxDiaPromise(),
            getindustriaAcucarVisaoGeralCorteDiaPromise: getindustriaAcucarVisaoGeralCorteDiaPromise(),
            getindustriaEtanolVisaoGeralMinMaxDiaPromise: getindustriaEtanolVisaoGeralMinMaxDiaPromise(),
            getindustriaEtanolVisaoGeralCorteDiaPromise: getindustriaEtanolVisaoGeralCorteDiaPromise()
        };

        return service;


        //Home
        function getindustriaHomeVisaoGeralMinMaxDiaPromise(idNegocios) {
            var industriaHomeVisaoGeralMinMaxDiaPromise = function (idNegocios) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaHome/VisaoGeralMinMaxDia/' + idNegocios))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaHomeVisaoGeralMinMaxDiaPromise;
        }

        function getindustriaHomePorDiaPromise(idNegocios, safra, dia) {
            var industriaHomePorDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/IndustriaHome/PorDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return industriaHomePorDiaPromise;
        };


        //Moagem
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

        //Energia Bio
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

        //Energia Uam
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

        //Açúcar
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

        //Etanol
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

    };
})();