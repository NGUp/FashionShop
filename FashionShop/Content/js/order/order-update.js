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
            var purchaseID = document.getElementById('purchase-id').value;

            http.get('/admin/order/getcartbypurchaseorder/' + purchaseID).then(function (data) {
                scope.cart = data.data;
            });

            scope.total = function () {
                var total = 0;
                angular.forEach(scope.cart, function (item) {
                    total += (item.Quantity * item.Product.Price);
                });

                return total;
            };

            scope.remove = function (index) {
                scope.cart.splice(index, 1);
            };

            scope.cancel = function () {
                window.location.href = '/admin/order';
            };

            scope.update = function () {
                var id = document.getElementById('purchase-id');

                var params = [
                    { 'id': id.value },
                    { 'cart': JSON.stringify(scope.cart) }
                ];

                var form = document.createElement('form');
                form.setAttribute('method', 'post');
                form.setAttribute('action', '/admin/order/updatehandler');

                for (var i = 0; i < params.length; i++) {
                    var key = params[i],
                        hiddenField = document.createElement("input");

                    hiddenField.setAttribute("type", "hidden");
                    hiddenField.setAttribute("name", Object.keys(key));
                    hiddenField.setAttribute("value", key[Object.keys(key)]);

                    form.appendChild(hiddenField);
                }

                document.body.appendChild(form);
                form.submit();
            };
        } ]);
})();