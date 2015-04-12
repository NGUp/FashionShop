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

    /**
    * A part of the admin module
    *
    */
    angular.module('admin', [])

        /**
        * Security service
        *
        * @return {object} Security service
        */
        .factory('Security', function () {
            return {

                /**
                * Encode password
                *
                * @param  {string} password    The user password
                * @return {string}             The hash
                */
                encode: function (password) {
                    return md5(
                        '922e1cd494659174bd2573' +
                        (new jsSHA('password', 'TEXT')).getHash('SHA-1', 'HEX') +
                        'fa7993697488f5e85f');
                }
            }
        })

        /**
        * Form service
        *
        * @return {object} Form service
        */
        .factory('Form', function () {
            return {

                /**
                * Submit a form
                *
                * @param  {array} params   The array of the parameters
                */
                submit: function (params) {
                    var form = document.createElement('form');
                    form.setAttribute('method', 'post');
                    form.setAttribute('action', '/admin/loginhandler');

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
                }
            }
        })

        /**
        * Login Controller
        *
        * @param  {Object} scope       Angular Object
        * @param  {Object} security    Security service
        * @param  {Object} form        Form service
        */
        .controller('LoginCtrl',
                ['$scope', 'Security', 'Form', function (scope, security, form) {

                    /**
                    * Login to admin page.
                    *
                    */
                    scope.login = function () {
                        var username = document.getElementById('txtUsername'),
                    password = document.getElementById('txtPassword');

                        if (username.validity.valid === true &&
                        password.validity.valid === true &&
                        password.value.length > 7) {
                            form.submit([
                        { 'username': username.value },
                        { 'password': security.encode(password.value) }
                    ]);
                        }
                    };
                } ]);

})();