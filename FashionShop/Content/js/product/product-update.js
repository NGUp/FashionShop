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

    angular.module('admin')

        .controller('UpdateCtrl', ['$scope', '$http', function (scope, http) {
            scope.cancel = function () {
                window.location.href = '/admin/product';
            };

            http.get('/manufacturer/getall').then(function (data) {
                scope.manufacturers = data.data;
            });

            scope.remove = function () {
                var form = document.createElement('form');
                form.setAttribute('method', 'post');
                form.setAttribute('action', '/admin/product/deletehandler');

                var id = document.querySelector('.product-id'),
                    hiddenField = document.createElement("input");

                hiddenField.setAttribute("type", "hidden");
                hiddenField.setAttribute("name", "id");
                hiddenField.setAttribute("value", id.innerHTML);

                form.appendChild(hiddenField);
                document.body.appendChild(form);
                form.submit();
            }

            scope.accept = function () {
                var id = document.querySelector('.product-id'),
                    image = document.getElementById('md-upload-button'),
                    name = document.getElementById('product-name'),
                    price = document.getElementById('product-price'),
                    origin = document.getElementById('product-origin'),
                    manufacturer = document.getElementById('product-manufacturer'),
                    sex = document.getElementById('product-sex');

                if (name.value.length === 0) {
                    return;
                }

                if (manufacturer.selected.length === 0) {
                    return;
                }

                if (price.value.length === 0) {
                    return;
                }

                if (origin.value.length === 0) {
                    return;
                }

                if (sex.selected.length === 0) {
                    return;
                }

                var params = [
                    { 'id': id.innerHTML },
                    { 'name': name.value },
                    { 'manufacturer': manufacturer.selected },
                    { 'price': price.value },
                    { 'origin': origin.value },
                    { 'sex': sex.selected }
                ];

                var form = document.createElement('form');
                form.setAttribute('method', 'post');
                form.setAttribute('action', '/admin/product/updatehandler');
                form.setAttribute('enctype', 'multipart/form-data');

                for (var i = 0; i < params.length; i++) {
                    var key = params[i],
                        hiddenField = document.createElement("input");

                    hiddenField.setAttribute("type", "hidden");
                    hiddenField.setAttribute("name", Object.keys(key));
                    hiddenField.setAttribute("value", key[Object.keys(key)]);

                    form.appendChild(hiddenField);
                }

                form.appendChild(image);
                document.body.appendChild(form);
                form.submit();
            };
        } ]);
})();