(function () {

    'user strict';

    angular.module('admin', [])
        .controller('IndexCtrl', ['$scope', '$http', function (scope, http) {
            scope.currentPage = 1;

            http.get('/admin/account/total').then(function (total) {
                scope.totalPages = total.data;

                http.get('/admin/account/get/1').then(function (data) {
                    scope.accounts = data.data;
                });
            });

            scope.isAdmin = function (permission) {
                if (permission === 1) {
                    return true;
                }

                return false;
            };

            scope.isAlive = function (state) {
                if (state === 1) {
                    return true;
                }

                return false;
            };

            scope.updateAccount = function (account) {
                var form = document.createElement('form');
                form.setAttribute('method', 'post');
                form.setAttribute('action', '/admin/account/update');

                var hiddenField = document.createElement('input');
                hiddenField.setAttribute('type', 'hidden');
                hiddenField.setAttribute('name', 'account_ID');
                hiddenField.setAttribute('value', account.ID);
                form.appendChild(hiddenField);

                document.body.appendChild(form);
                form.submit();
            };

            scope.deleteAccount = function (account) {
                console.log('delete');
            };

            scope.next = function () {
                if (scope.currentPage + 1 <= scope.totalPages) {
                    scope.currentPage++;

                    http.get('/admin/account/get/' + scope.currentPage).then(function (data) {
                        scope.accounts = data.data;
                    });
                }
            };

            scope.previous = function () {
                if (scope.currentPage > 1) {
                    scope.currentPage--;

                    http.get('/admin/account/get/' + scope.currentPage).then(function (data) {
                        scope.accounts = data.data;
                    });
                }
            };

            scope.toDate = function (value) {
                var pattern = /Date\(([^)]+)\)/;
                var results = pattern.exec(value);
                var data = new Date(parseFloat(results[1]));

                return data.getDate() + '/' + (data.getMonth() + 1) + '/' + data.getFullYear();
            };

            scope.search = function () {
                var dialog = document.querySelector('paper-dialog');
                dialog.toggle();
            };

        } ]);

})();