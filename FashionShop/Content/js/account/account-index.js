/**
* The MIT License (MIT)
*
* Copyright (c) 2015 - 110001NP Development Team
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE
*/

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
                var form = document.createElement('form');
                form.setAttribute('method', 'post');
                form.setAttribute('action', '/admin/account/delete');

                var hiddenField = document.createElement('input');
                hiddenField.setAttribute('type', 'hidden');
                hiddenField.setAttribute('name', 'account_ID');
                hiddenField.setAttribute('value', account.ID);
                form.appendChild(hiddenField);

                document.body.appendChild(form);
                form.submit();
            };

            scope.next = function () {
                if (scope.currentPage + 1 <= scope.totalPages) {
                    scope.currentPage++;

                    if (scope.isSearching === true) {
                        // TODO
                    }

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

            scope.refresh = function () {
                http.get('/admin/account/total').then(function (total) {
                    scope.totalPages = total.data;

                    http.get('/admin/account/get/1').then(function (data) {
                        scope.accounts = data.data;
                        scope.isSearching = false;
                    });
                });
            };

            scope.searchAccounts = function () {
                var id = document.getElementById('txtID'),
                    username = document.getElementById('txtUsername');

                if (id.validity.valid === false) {
                    id.focus();
                    return;
                }

                if (username.validity.valid === false) {
                    username.focus();
                    return;
                }

                if (id.value.length === 0 && username.value.length === 0) {
                    return;
                }

                var token = 'id=' + id.value + '&username=' + username.value;
                token = Base64.encode(token);

                http.get('/admin/account/searchresults/' + token).then(function (total) {
                    scope.totalPages = total.data;

                    http.get('/admin/account/search/1/' + token).then(function (data) {
                        scope.accounts = data.data;

                        var dialog = document.getElementById('paper-dialog');
                        dialog.close();
                        scope.isSearching = true;
                        scope.currentPage = 1;
                    });
                });
            };

            scope.toDate = function (value) {
                var pattern = /Date\(([^)]+)\)/;
                var results = pattern.exec(value);
                var data = new Date(parseFloat(results[1]));

                return data.getDate() + '/' + (data.getMonth() + 1) + '/' + data.getFullYear();
            };

            scope.search = function () {
                var id = document.getElementById('txtID'),
                    username = document.getElementById('txtUsername'),
                    dialog = document.querySelector('paper-dialog');

                id.value = '';
                username.value = '';
                dialog.toggle();
            };

        } ]);

})();