(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getagricolaColheitaVisaoGeralMinMaxDiaPromise: getagricolaColheitaVisaoGeralMinMaxDiaPromise(),
            getagricolaColheitaVisaoGeralMinMaxCorteDiaPromise: getagricolaColheitaVisaoGeralMinMaxCorteDiaPromise(),
            getagricolaColheitaPorDiaPromise: getagricolaColheitaPorDiaPromise(),
            getagricolaColheitaPorDiaPorFrentePromise: getagricolaColheitaPorDiaPorFrentePromise(),
            getagricolaColheitaPorSemanaPromise: getagricolaColheitaPorSemanaPromise(),
            getagricolaColheitaPorSemanaPorFrentePromise: getagricolaColheitaPorSemanaPorFrentePromise(),
            getagricolaColheitaPorMesPromise: getagricolaColheitaPorMesPromise(),
            getagricolaColheitaPorMesPorFrentePromise: getagricolaColheitaPorMesPorFrentePromise(),
            getagricolaColheitaPorSafraPromise: getagricolaColheitaPorSafraPromise(),
            getagricolaColheitaPorSafraPorFrentePromise: getagricolaColheitaPorSafraPorFrentePromise(),
            getagricolaColheitaPorDiaPorFrenteEquipamentoPromise: getagricolaColheitaPorDiaPorFrenteEquipamentoPromise(),
            getagricolaColheitaPorSemanaPorFrenteEquipamentoPromise: getagricolaColheitaPorSemanaPorFrenteEquipamentoPromise(),
            getagricolaColheitaPorSemanaPorFrenteEquipamentoCorteDiaPromise: getagricolaColheitaPorSemanaPorFrenteEquipamentoCorteDiaPromise(),
            getagricolaColheitaPorMesPorFrenteEquipamentoPromise: getagricolaColheitaPorMesPorFrenteEquipamentoPromise(),
            getagricolaColheitaPorMesPorFrenteEquipamentoCorteDiaPromise: getagricolaColheitaPorMesPorFrenteEquipamentoCorteDiaPromise(),
            getagricolaColheitaPorSafraPorFrenteEquipamentoPromise: getagricolaColheitaPorSafraPorFrenteEquipamentoPromise(),
            getagricolaColheitaPorSafraPorFrenteEquipamentoCorteDiaPromise: getagricolaColheitaPorSafraPorFrenteEquipamentoCorteDiaPromise()
        };

        return service;


        function getagricolaColheitaVisaoGeralMinMaxDiaPromise(idNegocios) {
            var agricolaColheitaVisaoGeralMinMaxDiaPromise = function (idNegocios) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/VisaoGeralMinMaxDia/' + idNegocios))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaVisaoGeralMinMaxDiaPromise;
        };

        function getagricolaColheitaVisaoGeralMinMaxCorteDiaPromise(idNegocios) {
            var agricolaColheitaVisaoGeralMinMaxCorteDiaPromise = function (idNegocios, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/VisaoGeralMinMaxCorteDia/' + idNegocios + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaVisaoGeralMinMaxCorteDiaPromise;
        };


        function getagricolaColheitaPorDiaPromise(idNegocios, safra, dia) {
            var agricolaColheitaPorDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorDiaPromise;
        };

        function getagricolaColheitaPorDiaPorFrentePromise(idNegocios, safra, dia, frente) {
            var agricolaColheitaPorDiaPorFrentePromise = function (idNegocios, safra, dia, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorDiaPorFrente/' + idNegocios + '/' + safra + '/' + dia + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorDiaPorFrentePromise;
        };

        function getagricolaColheitaPorSemanaPromise(idNegocios, safra, semana) {
            var agricolaColheitaPorSemanaPromise = function (idNegocios, safra, semana) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorSemana/' + idNegocios + '/' + safra + '/' + semana))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorSemanaPromise;
        };

        function getagricolaColheitaPorSemanaPorFrentePromise(idNegocios, safra, semana, frente) {
            var agricolaColheitaPorSemanaPorFrentePromise = function (idNegocios, safra, semana, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorSemanaPorFrente/' + idNegocios + '/' + safra + '/' + semana + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorSemanaPorFrentePromise;
        };

        function getagricolaColheitaPorMesPromise(idNegocios, safra, mes) {
            var agricolaColheitaPorMesPromise = function (idNegocios, safra, mes) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorMes/' + idNegocios + '/' + safra + '/' + mes))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorMesPromise;
        };

        function getagricolaColheitaPorMesPorFrentePromise(idNegocios, safra, mes, frente) {
            var agricolaColheitaPorMesPorFrentePromise = function (idNegocios, safra, mes, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorMesPorFrente/' + idNegocios + '/' + safra + '/' + mes + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorMesPorFrentePromise;
        };

        function getagricolaColheitaPorSafraPromise(idNegocios, safra) {
            var agricolaColheitaPorSafraPromise = function (idNegocios, safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorSafra/' + idNegocios + '/' + safra))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorSafraPromise;
        };

        function getagricolaColheitaPorSafraPorFrentePromise(idNegocios, safra, frente) {
            var agricolaColheitaPorSafraPorFrentePromise = function (idNegocios, safra, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorSafraPorFrente/' + idNegocios + '/' + safra + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorSafraPorFrentePromise;
        };

        function getagricolaColheitaPorDiaPorFrenteEquipamentoPromise(idNegocios, safra, dia, frente) {
            var agricolaColheitaPorDiaPorFrenteEquipamentoPromise = function (idNegocios, safra, dia, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorDiaPorFrenteEquip/' + idNegocios + '/' + safra + '/' + dia + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorDiaPorFrenteEquipamentoPromise;
        };

        function getagricolaColheitaPorSemanaPorFrenteEquipamentoPromise(idNegocios, safra, semana, frente) {
            var agricolaColheitaPorSemanaPorFrenteEquipamentoPromise = function (idNegocios, safra, semana, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorSemanaPorFrenteEquip/' + idNegocios + '/' + safra + '/' + semana + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorSemanaPorFrenteEquipamentoPromise;
        };

        function getagricolaColheitaPorSemanaPorFrenteEquipamentoCorteDiaPromise(idNegocios, safra, semana, frente, dia) {
            var agricolaColheitaPorSemanaPorFrenteEquipamentoCorteDiaPromise = function (idNegocios, safra, semana, frente, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorSemanaPorFrenteEquipCorteDia/' + idNegocios + '/' + safra + '/' + semana + '/' + frente + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorSemanaPorFrenteEquipamentoCorteDiaPromise;
        };

        function getagricolaColheitaPorMesPorFrenteEquipamentoPromise(idNegocios, safra, mes, frente) {
            var agricolaColheitaPorMesPorFrenteEquipamentoPromise = function (idNegocios, safra, mes, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorMesPorFrenteEquip/' + idNegocios + '/' + safra + '/' + mes + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorMesPorFrenteEquipamentoPromise;
        };

        function getagricolaColheitaPorMesPorFrenteEquipamentoCorteDiaPromise(idNegocios, safra, mes, frente, dia) {
            var agricolaColheitaPorMesPorFrenteEquipamentoCorteDiaPromise = function (idNegocios, safra, mes, frente, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorMesPorFrenteEquipCorteDia/' + idNegocios + '/' + safra + '/' + mes + '/' + frente + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorMesPorFrenteEquipamentoCorteDiaPromise;
        };

        function getagricolaColheitaPorSafraPorFrenteEquipamentoPromise(idNegocios, safra, frente) {
            var agricolaColheitaPorSafraPorFrenteEquipamentoPromise = function (idNegocios, safra, frente) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorSafraPorFrenteEquip/' + idNegocios + '/' + safra + '/' + frente))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorSafraPorFrenteEquipamentoPromise;
        };

        function getagricolaColheitaPorSafraPorFrenteEquipamentoCorteDiaPromise(idNegocios, safra, frente, dia) {
            var agricolaColheitaPorSafraPorFrenteEquipamentoCorteDiaPromise = function (idNegocios, safra, frente, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheita/PorSafraPorFrenteEquipCorteDia/' + idNegocios + '/' + safra + '/' + frente + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaPorSafraPorFrenteEquipamentoCorteDiaPromise;
        };

    };
})();