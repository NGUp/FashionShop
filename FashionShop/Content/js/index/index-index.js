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

    angular.module('kids-fashion', [])
        .directive('ngEnter', function () {
            return function (scope, element, attrs) {
                element.bind("keydown keypress", function (event) {
                    if (event.which === 13) {
                        scope.$apply(function () {
                            scope.$eval(attrs.ngEnter);
                        });

                        event.preventDefault();
                    }
                });
            };
        })

        .controller('IndexCtrl', ['$scope', '$http', function (scope, http) {

            scope.removeProgressBar = function () {
                var progressBar = document.getElementsByTagName('paper-progress');

                for (var index = progressBar.length - 1; index >= 0; index--) {
                    progressBar[index].parentNode.removeChild(progressBar[index]);
                }
            };

            http.get('/category/getall').then(function (data) {
                scope.categories = data.data;
            });

            http.get('/manufacturer/gettopmanufacturers').then(function (data) {
                scope.manufacturers = data.data;
            });

            http.get('/product/getnews').then(function (data) {
                scope.removeProgressBar();
                scope.productsNew = data.data;
            });

            http.get('/product/getsales').then(function (data) {
                scope.removeProgressBar();
                scope.productsSale = data.data;
            });

            scope.showDetails = function (product) {
                window.location.href = '/index/details/' + product.Id;
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
        } ]);
})();