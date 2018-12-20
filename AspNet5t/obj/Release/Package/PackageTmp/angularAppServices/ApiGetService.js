(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getentcanadetStore: getentcanadetStore(),
            getentcanadetAgrupStore: getentcanadetAgrupStore(),
            getsafrasPromise: getsafrasPromise(),
            getpropriedadesPromise: getpropriedadesPromise(),
            gethistoricopropriedadePromise: gethistoricopropriedadePromise(),
            gethistoricopropriedadeTratosCulturaisTalhoes: gethistoricopropriedadeTratosCulturaisTalhoesPromise(),
            getsubgruposagricolasPromise: getsubgruposagricolasPromise(),
            getentradacanasdetMapaPromise: getentradacanasdetMapaPromise(),
            getcontrolepragaBrocaPromise: getcontrolepragaBrocaPromise(),
            getcontrolepragaCigarrinhaPromise: getcontrolepragaCigarrinhaPromise(),
            getcontrolepragaSphenophorusPromise: getcontrolepragaSphenophorusPromise(),
            getpropriedadepragaBrocaPromise: getpropriedadepragaBrocaPromise(),
            getpropriedadepragaCigarrinhaPromise: getpropriedadepragaCigarrinhaPromise(),
            getpropriedadepragaSphenophorusPromise: getpropriedadepragaSphenophorusPromise(),
            getpropriedadetipoPromise: getpropriedadetipoPromise(),
            getestoqueColheitaFrentePromise: getestoqueColheitaFrentePromise(),
            getestoqueColheitaTempoTimerPromise: getestoqueColheitaTempoTimerPromise(),
            getacessoUsuarioPromise: getacessoUsuarioPromise()
        };

        return service;

        function getentcanadetStore() {
            var entcanadetStore = new DevExpress.data.CustomStore({
                load: function (loadOptions) {

                    var defer = $q.defer();

                    $http.get(ResolveUrl('~/api/EntradaCanaDet'))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                        });

                    return defer.promise;
                }
            });

            return entcanadetStore;
        };

        function getentcanadetAgrupStore() {
            var entcanadetAgrupStore = new DevExpress.data.CustomStore({
                load: function (loadOptions) {

                    var defer = $q.defer();

                    $http.get(ResolveUrl('~/api/EntradaCanaDetAgrup'))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                        });

                    return defer.promise;
                }
            });

            return entcanadetAgrupStore;
        };

        function getsafrasPromise() {
            var safrasPromise = function () {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/Safras'))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return safrasPromise;
        };

        function getpropriedadesPromise(safra) {
            var propriedadesPromise = function (safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/Propriedades/' + safra))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return propriedadesPromise;
        };

        function gethistoricopropriedadePromise(safra, codigoProp) {
            var historicopropriedadePromise = function (safra, codigoProp) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/GerencialHistoricoPropriedade/' + safra + '/' + codigoProp))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return historicopropriedadePromise;
        };

        function gethistoricopropriedadeTratosCulturaisTalhoesPromise(safra, codigoProp, atividade) {
            var historicopropriedadeTratosCulturaisTalhoesPromise = function (safra, codigoProp, atividade) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/GerencialHistoricoPropriedade/' + safra + '/' + codigoProp + '/TratosCulturaisTalhoes/' + atividade))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return historicopropriedadeTratosCulturaisTalhoesPromise;
        };

        function getsubgruposagricolasPromise() {
            var subgruposagricolasPromise = function () {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/SubgrupoAgricola'))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return subgruposagricolasPromise;
        };

        function getentradacanasdetMapaPromise() {
            var entradacanasdetPromise = function () {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/EntradaCanaDetMapa'))
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

        function getcontrolepragaBrocaPromise(safra, codigoProp) {
            var controlepragaBrocaPromise = function (safra, codigoProp) {
                var defer = $q.defer();
                
                $http.get(ResolveUrl('~/api/GerencialControlePraga/' + safra + '/' + codigoProp + '/Broca'))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return controlepragaBrocaPromise;
        };

        function getcontrolepragaCigarrinhaPromise(safra, codigoProp) {
            var controlepragaCigarrinhaPromise = function (safra, codigoProp) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/GerencialControlePraga/' + safra + '/' + codigoProp + '/Cigarrinha'))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return controlepragaCigarrinhaPromise;
        };

        function getcontrolepragaSphenophorusPromise(safra, codigoProp) {
            var controlepragaSphenophorusPromise = function (safra, codigoProp) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/GerencialControlePraga/' + safra + '/' + codigoProp + '/Sphenophorus'))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return controlepragaSphenophorusPromise;
        };

        function getpropriedadepragaBrocaPromise(safra) {
            var propriedadepragaBrocaPromise = function (safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/PropriedadePraga/' + safra + '/Broca'))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return propriedadepragaBrocaPromise;
        };

        function getpropriedadepragaCigarrinhaPromise(safra) {
            var propriedadepragaCigarrinhaPromise = function (safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/PropriedadePraga/' + safra + '/Cigarrinha'))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return propriedadepragaCigarrinhaPromise;
        };

        function getpropriedadepragaSphenophorusPromise(safra) {
            var propriedadepragaSphenophorusPromise = function (safra) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/PropriedadePraga/' + safra + '/Sphenophorus'))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return propriedadepragaSphenophorusPromise;
        };

        function getpropriedadetipoPromise(tipo) {
            var propriedadetipoPromise = function (tipo) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/PropriedadeTipo/' + tipo))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return propriedadetipoPromise;
        };

        function getestoqueColheitaFrentePromise() {
            var estoqueColheitaFrentePromise = function () {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/EstoqueColheitaFrente'))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return estoqueColheitaFrentePromise;
        };

        function getestoqueColheitaTempoTimerPromise() {
            var estoqueColheitaTempoTimerPromise = function () {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/EstoqueColheitaFrente/TempoTimer'))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return estoqueColheitaTempoTimerPromise;
        };

        //' GET api/AcessoUsuario/COD_PROGRAMA/COD_USUARIO/ID_NEGOCIOS/V_CAMPO_AUX
        function getacessoUsuarioPromise(codigoPrograma, codigoUsuario, idNegocios, vCampoAux) {
            var acessoUsuarioPromise = function (codigoPrograma, codigoUsuario, idNegocios, vCampoAux) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AcessoUsuario/' + codigoPrograma + '/' + codigoUsuario + '/' + idNegocios + '/' + vCampoAux))
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err);
                    });

                return defer.promise;
            };

            return acessoUsuarioPromise;

        };
        
    };
})();