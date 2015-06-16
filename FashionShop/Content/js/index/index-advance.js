/**
* The MIT License (MIT)
*
* Copyright (c) 2015 - 110001NP Development Team
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the 'Software'), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
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

        .controller('AdvanceCtrl', ['$scope', '$http', 'Normalization', function (scope, http, normalization) {

            scope.standardizePrice = normalization.standardizePrice;

            http.get('/category/getall').then(function (data) {
                scope.categories = data.data;
            });

            http.get('/manufacturer/gettopmanufacturers').then(function (data) {
                scope.manufacturers = data.data;
            });

            scope.showDetails = function (product) {
                window.location.href = '/index/details/' + product;
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

            scope.searchAdvance = function () {
                var category = document.getElementById('category'),
                    sex = document.getElementById('sex'),
                    price = document.getElementById('price');

                if (category.selected === null) {
                    category.selected = '';
                }

                if (sex.selected === null) {
                    sex.selected = -1;
                }

                if (price.selected === null) {
                    price.selected = -1;
                }

                if (category.selected === '' && sex.selected === -1 && price.selected === -1) {
                    return;
                }

                console.log(category.selected);
                console.log(sex.selected);
                console.log(price.selected);

                var params = [
                    { 'category': category.selected },
                    { 'price': price.selected },
                    { 'sex': sex.selected }
                ];

                var form = document.createElement('form');
                form.setAttribute('method', 'post');
                form.setAttribute('action', '/index/advancesearch');

                for (var i = 0; i < params.length; i++) {
                    var key = params[i],
                        hiddenField = document.createElement('input');

                    hiddenField.setAttribute('type', 'hidden');
                    hiddenField.setAttribute('name', Object.keys(key));
                    hiddenField.setAttribute('value', key[Object.keys(key)]);

                    form.appendChild(hiddenField);
                }

                document.body.appendChild(form);
                form.submit();
            };
        } ]);
})();