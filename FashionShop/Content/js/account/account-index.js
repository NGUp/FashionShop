(function () {

    'user strict';

    angular.module('admin', [])
        .controller('IndexCtrl', ['$scope', '$http', function (scope, http) {
            http.get('/admin/account/get/1').then(function (data) {
                console.log(data);
            });

            scope.updateAccount = function () {
            }

            scope.deleteAccount = function () {
                console.log('delete');
            }

        } ]);

})();