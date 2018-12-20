(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiGetService', ['$http', '$q', ApiGetService]);

    function ApiGetService($http, $q) {

        var service = {
            getagricolaColheitaOperVisaoGeralMinMaxDiaPromise: getagricolaColheitaOperVisaoGeralMinMaxDiaPromise(),
            getagricolaColheitaOperPorDiaPromise: getagricolaColheitaOperPorDiaPromise()
        };

        return service;

        function getagricolaColheitaOperVisaoGeralMinMaxDiaPromise(idNegocios) {
            var agricolaColheitaOperVisaoGeralMinMaxDiaPromise = function (idNegocios) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaOper/VisaoGeralMinMaxDia/' + idNegocios))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaOperVisaoGeralMinMaxDiaPromise;
        };

        function getagricolaColheitaOperPorDiaPromise(idNegocios, safra, dia) {
            var agricolaColheitaOperPorDiaPromise = function (idNegocios, safra, dia) {
                var defer = $q.defer();

                $http.get(ResolveUrl('~/api/AgricolaColheitaOper/PorDia/' + idNegocios + '/' + safra + '/' + dia))
                    .success(function (data) {
                        defer.resolve(data);
                    })
                    .error(function (err, status) {
                        defer.reject(err);
                    });

                return defer.promise;
            };

            return agricolaColheitaOperPorDiaPromise;
        };

    };
})();