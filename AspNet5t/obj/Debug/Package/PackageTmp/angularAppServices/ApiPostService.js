(function () {
    "use strict";
    angular.module('app4T')
        .factory('ApiPostService', ['$http', '$q', ApiPostService])

    function ApiPostService($http, $q) {

        var service = {
            postestoqueColheitaFrentePromise: postestoqueColheitaFrentePromise()
        };

        return service;

        function postestoqueColheitaFrentePromise(safra) {
            var estoqueColheitaFrentePromise = function (obj) {
                var defer = $q.defer();

                $http.post(ResolveUrl('~/api/EstoqueColheitaFrente'), obj)
                .success(function (data) {
                    defer.resolve(data);
                })
                .error(function (err, status) {
                    defer.reject(err)
                });

                return defer.promise;
            };

            return estoqueColheitaFrentePromise;
        };
    };
})();