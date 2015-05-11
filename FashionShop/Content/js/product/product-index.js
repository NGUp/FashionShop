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
        .factory('Form', function () {
            return {
                submitForm: function (product, url) {
                    var form = document.createElement('form');
                    form.setAttribute('method', 'post');
                    form.setAttribute('action', url);

                    var hiddenField = document.createElement('input');
                    hiddenField.setAttribute('type', 'hidden');
                    hiddenField.setAttribute('name', 'product_ID');
                    hiddenField.setAttribute('value', product.Id);
                    form.appendChild(hiddenField);

                    document.body.appendChild(form);
                    form.submit();
                }
            }
        })

        .controller('IndexCtrl', ['$scope', '$http', 'Form', function (scope, http, form) {
            scope.currentPage = 1;
            scope.keyword = '';

            http.get('/admin/product/total').then(function (total) {
                scope.totalPages = total.data;

                http.get('/admin/product/get/1').then(function (data) {
                    scope.products = data.data;
                });
            });

            scope.showDetails = function (product) {
                form.submitForm(product, '/admin/product/update');
            }

            scope.isAvailable = function (product) {
                return (product.State === 1) ? true : false;
            }

            scope.next = function () {
                if (scope.currentPage + 1 <= scope.totalPages) {
                    scope.currentPage++;

                    if (scope.isSearching === true) {
                        http.get('/admin/account/search/' + scope.currentPage + '/' + keyword).then(function (data) {
                            scope.accounts = data.data;
                        });
                    } else {
                        http.get('/admin/account/get/' + scope.currentPage).then(function (data) {
                            scope.accounts = data.data;
                        });
                    }
                }
            };

            scope.previous = function () {
                if (scope.currentPage > 1) {
                    scope.currentPage--;

                    if (scope.isSearching === true) {
                        http.get('/admin/account/search/' + scope.currentPage + '/' + keyword).then(function (data) {
                            scope.accounts = data.data;
                        });
                    } else {
                        http.get('/admin/account/get/' + scope.currentPage).then(function (data) {
                            scope.accounts = data.data;
                        });
                    }
                }
            };

            scope.refresh = function () {
                http.get('/admin/product/total').then(function (total) {
                    scope.totalPages = total.data;

                    http.get('/admin/product/get/1').then(function (data) {
                        scope.products = data.data;
                    });
                });
            };

            scope.searchProducts = function () {
                var id = document.getElementById('txtProductID'),
                    name = document.getElementById('txtProductName');

                if (id.value.length === 0 && name.value.length === 0) {
                    return;
                }

                keyword = 'id=' + id.value + '&name=' + name.value;
                keyword = Base64.encode(keyword);

                console.log(keyword);

                http.get('/admin/product/searchresults/' + keyword).then(function (total) {
                    scope.totalPages = total.data;

                    http.get('/admin/product/search/1/' + keyword).then(function (data) {
                        console.log(data);
                        scope.products = data.data;

                        var dialog = document.getElementById('paper-dialog');
                        dialog.close();
                        scope.isSearching = true;
                        scope.currentPage = 1;
                    });
                });
            };

            scope.search = function () {
                var id = document.getElementById('txtProductID'),
                    username = document.getElementById('txtProductName'),
                    dialog = document.querySelector('paper-dialog');

                id.value = '';
                username.value = '';
                dialog.toggle();
            };

        } ]);

})();