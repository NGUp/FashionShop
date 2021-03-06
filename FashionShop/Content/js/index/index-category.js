﻿/**
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

        .controller('CategoryCtrl', ['$scope', '$http', 'Normalization', function (scope, http, normalization) {

            var params = window.location.href.split('/');

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

            scope.previous = function () {
                var page = $('#page').text();

                if (page > 1) {
                    window.location.href = '/index/category/' + params[5] + '/' + (parseInt(page) - 1);
                }
            };

            scope.next = function () {
                var page = $('#page').text(),
                    maxPage = $('#page-total').text();

                if (page < maxPage) {
                    window.location.href = '/index/category/' + params[5] + '/' + (parseInt(page) + 1);
                }
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