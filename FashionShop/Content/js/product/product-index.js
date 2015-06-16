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

    angular.module('admin')

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

        .controller('IndexCtrl', ['$scope', '$http', '$location', 'Form', function (scope, http, location, form) {
            scope.currentPage = 1;
            scope.keyword = '';
            var currentKeyword = '';

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
                        http.get('/admin/product/search/' + scope.currentPage + '/' + Base64.encode(scope.keyword)).then(function (data) {
                            scope.products = data.data;
                        });
                    } else {
                        http.get('/admin/product/get/' + scope.currentPage).then(function (data) {
                            scope.products = data.data;
                        });
                    }
                }
            };

            scope.previous = function () {
                if (scope.currentPage > 1) {
                    scope.currentPage--;

                    if (scope.isSearching === true) {
                        http.get('/admin/product/search/' + scope.currentPage + '/' + Base64.encode(scope.keyword)).then(function (data) {
                            scope.products = data.data;
                        });
                    } else {
                        http.get('/admin/product/get/' + scope.currentPage).then(function (data) {
                            scope.products = data.data;
                        });
                    }
                }
            };

            scope.refresh = function () {
                http.get('/admin/product/total').then(function (total) {
                    scope.totalPages = total.data;
                    scope.isSearching = false;
                    scope.keyword = '';

                    if (scope.totalPages === 0) {
                        scope.currentPage = 0;
                        scope.products = null;
                    } else {
                        http.get('/admin/product/get/1').then(function (data) {
                            scope.products = data.data;
                            scope.currentPage = 1;
                        });
                    }
                });
            };

            scope.search = function () {
                if (scope.keyword === '') {
                    return;
                }

                var keyword = Base64.encode(scope.keyword);

                http.get('/admin/product/searchresults/' + keyword).then(function (total) {
                    scope.totalPages = total.data;
                    scope.isSearching = true;

                    if (scope.totalPages === 0) {
                        scope.currentPage = 0;
                        scope.products = null;
                    } else {
                        http.get('/admin/product/search/1/' + keyword).then(function (data) {
                            scope.products = data.data;
                            scope.currentPage = 1;
                        });
                    }
                });
            };

            scope.add = function () {
                window.location.href = '/admin/product/add';
            };

        } ]);

})();