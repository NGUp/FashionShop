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

    'use strict';

    angular.module('kids-fashion')

        .controller('DetailsCtrl', ['$scope', '$http', 'Normalization', function (scope, http, normalization) {
            var image = $('#product-id');

            scope.ordered = false,
            scope.canceled = true;

            scope.standardizePrice = normalization.standardizePrice;

            http.get('/category/getall').then(function (data) {
                scope.categories = data.data;
            });

            http.get('/manufacturer/gettopmanufacturers').then(function (data) {
                scope.manufacturers = data.data;
            });

            http.get('/admin/product/relativeproducts/' + $(image).attr('alt')).then(function (data) {
                scope.products = data.data;
            });

            scope.showDetails = function (product) {
                window.location.href = '/index/details/' + product.Id;
            };

            scope.order = function () {
                http.get('/admin/product/orderproduct/' + $(image).attr('alt')).then(function (data) {
                    scope.ordered = data.data;
                });
            };

            scope.search = function () {
                if (scope.keyword === undefined) {
                    return;
                }

                if (scope.keyword === '') {
                    return;
                }

                window.location.href = '/index/search/' + Base64.encode(scope.keyword);
            };

            scope.goCart = function () {
                window.location.href = '/index/cart';
            };
        } ]);
})();