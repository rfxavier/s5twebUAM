(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getagricolaColheitaAdmVisaoGeralMinMaxDiaPromise: getagricolaColheitaAdmVisaoGeralMinMaxDiaPromise(),
            getagricolaColheitaAdmVisaoGeralMinMaxCorteDiaPromise: getagricolaColheitaAdmVisaoGeralMinMaxCorteDiaPromise(),

            getagricolaColheitaAdmPorDiaPorFrenteEquipamentoPromise: getagricolaColheitaAdmPorDiaPorFrenteEquipamentoPromise(),

            getagricolaColheitaAdmPorSemanaPromise: getagricolaColheitaAdmPorSemanaPromise(),
            getagricolaColheitaAdmPorSemanaPorFrenteEquipamentoPromise: getagricolaColheitaAdmPorSemanaPorFrenteEquipamentoPromise(),

            getagricolaColheitaAdmPorSemanaCorteDiaPromise: getagricolaColheitaAdmPorSemanaCorteDiaPromise(),
            getagricolaColheitaAdmPorSemanaPorFrenteEquipamentoCorteDiaPromise: getagricolaColheitaAdmPorSemanaPorFrenteEquipamentoCorteDiaPromise(),

            getagricolaColheitaAdmPorMesPromise: getagricolaColheitaAdmPorMesPromise(),
            getagricolaColheitaAdmPorMesPorFrenteEquipamentoPromise: getagricolaColheitaAdmPorMesPorFrenteEquipamentoPromise(),

            getagricolaColheitaAdmPorMesCorteDiaPromise: getagricolaColheitaAdmPorMesCorteDiaPromise(),
            getagricolaColheitaAdmPorMesPorFrenteEquipamentoCorteDiaPromise: getagricolaColheitaAdmPorMesPorFrenteEquipamentoCorteDiaPromise(),

            getagricolaColheitaAdmPorSafraPromise: getagricolaColheitaAdmPorSafraPromise(),
            getagricolaColheitaAdmPorSafraPorFrenteEquipamentoPromise: getagricolaColheitaAdmPorSafraPorFrenteEquipamentoPromise(),

            getagricolaColheitaAdmPorSafraCorteDiaPromise: getagricolaColheitaAdmPorSafraCorteDiaPromise(),
            getagricolaColheitaAdmPorSafraPorFrenteEquipamentoCorteDiaPromise: getagricolaColheitaAdmPorSafraPorFrenteEquipamentoCorteDiaPromise()
        };

        return service;


        function getagricolaColheitaAdmVisaoGeralMinMaxDiaPromise(idNegocios) {
            var agricolaColheitaAdmVisaoGeralMinMaxDiaPromise = function (idNegocios) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/VisaoGeralMinMaxDia/' + idNegocios))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmVisaoGeralMinMaxDiaPromise;
        };

        function getagricolaColheitaAdmVisaoGeralMinMaxCorteDiaPromise(idNegocios) {
            var agricolaColheitaAdmVisaoGeralMinMaxCorteDiaPromise = function (idNegocios, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/VisaoGeralMinMaxCorteDia/' + idNegocios + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmVisaoGeralMinMaxCorteDiaPromise;
        };


        function getagricolaColheitaAdmPorDiaPorFrenteEquipamentoPromise(idNegocios, safra, dia, frente) {
            var agricolaColheitaAdmPorDiaPorFrenteEquipamentoPromise = function (idNegocios, safra, dia, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorDiaPorFrenteEquip/' + idNegocios + '/' + safra + '/' + dia + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorDiaPorFrenteEquipamentoPromise;
        };


        function getagricolaColheitaAdmPorSemanaPromise(idNegocios, safra, semana) {
            var agricolaColheitaAdmPorSemanaPromise = function (idNegocios, safra, semana) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorSemana/' + idNegocios + '/' + safra + '/' + semana))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorSemanaPromise;
        };

        function getagricolaColheitaAdmPorSemanaPorFrenteEquipamentoPromise(idNegocios, safra, semana, frente) {
            var agricolaColheitaAdmPorSemanaPorFrenteEquipamentoPromise = function (idNegocios, safra, semana, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorSemanaPorFrenteEquip/' + idNegocios + '/' + safra + '/' + semana + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorSemanaPorFrenteEquipamentoPromise;
        };


        function getagricolaColheitaAdmPorSemanaCorteDiaPromise(idNegocios, safra, semana, dia) {
            var agricolaColheitaAdmPorSemanaCorteDiaPromise = function (idNegocios, safra, semana, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorSemanaCorteDia/' + idNegocios + '/' + safra + '/' + semana + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorSemanaCorteDiaPromise;
        };

        function getagricolaColheitaAdmPorSemanaPorFrenteEquipamentoCorteDiaPromise(idNegocios, safra, semana, frente, dia) {
            var agricolaColheitaAdmPorSemanaPorFrenteEquipamentoCorteDiaPromise = function (idNegocios, safra, semana, frente, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorSemanaPorFrenteEquipCorteDia/' + idNegocios + '/' + safra + '/' + semana + '/' + frente + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorSemanaPorFrenteEquipamentoCorteDiaPromise;
        };


        function getagricolaColheitaAdmPorMesPromise(idNegocios, safra, mes) {
            var agricolaColheitaAdmPorMesPromise = function (idNegocios, safra, mes) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorMes/' + idNegocios + '/' + safra + '/' + mes))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorMesPromise;
        };

        function getagricolaColheitaAdmPorMesPorFrenteEquipamentoPromise(idNegocios, safra, mes, frente) {
            var agricolaColheitaAdmPorMesPorFrenteEquipamentoPromise = function (idNegocios, safra, mes, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorMesPorFrenteEquip/' + idNegocios + '/' + safra + '/' + mes + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorMesPorFrenteEquipamentoPromise;
        };


        function getagricolaColheitaAdmPorMesCorteDiaPromise(idNegocios, safra, mes, dia) {
            var agricolaColheitaAdmPorMesCorteDiaPromise = function (idNegocios, safra, mes, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorMesCorteDia/' + idNegocios + '/' + safra + '/' + mes + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorMesCorteDiaPromise;
        };

        function getagricolaColheitaAdmPorMesPorFrenteEquipamentoCorteDiaPromise(idNegocios, safra, mes, frente, dia) {
            var agricolaColheitaAdmPorMesPorFrenteEquipamentoCorteDiaPromise = function (idNegocios, safra, mes, frente, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorMesPorFrenteEquipCorteDia/' + idNegocios + '/' + safra + '/' + mes + '/' + frente + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorMesPorFrenteEquipamentoCorteDiaPromise;
        };


        function getagricolaColheitaAdmPorSafraPromise(idNegocios, safra) {
            var agricolaColheitaAdmPorSafraPromise = function (idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorSafra/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorSafraPromise;
        };

        function getagricolaColheitaAdmPorSafraPorFrenteEquipamentoPromise(idNegocios, safra, frente) {
            var agricolaColheitaAdmPorSafraPorFrenteEquipamentoPromise = function (idNegocios, safra, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorSafraPorFrenteEquip/' + idNegocios + '/' + safra + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorSafraPorFrenteEquipamentoPromise;
        };


        function getagricolaColheitaAdmPorSafraCorteDiaPromise(idNegocios, safra, dia) {
            var agricolaColheitaAdmPorSafraCorteDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorSafraCorteDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorSafraCorteDiaPromise;
        };

        function getagricolaColheitaAdmPorSafraPorFrenteEquipamentoCorteDiaPromise(idNegocios, safra, frente, dia) {
            var agricolaColheitaAdmPorSafraPorFrenteEquipamentoCorteDiaPromise = function (idNegocios, safra, frente, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaAdm/PorSafraPorFrenteEquipCorteDia/' + idNegocios + '/' + safra + '/' + frente + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaAdmPorSafraPorFrenteEquipamentoCorteDiaPromise;
        };
    };
})();