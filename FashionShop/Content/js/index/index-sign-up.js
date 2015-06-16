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
                        (new jsSHA(password, 'TEXT')).getHash('SHA-1', 'HEX') +
                        'fa7993697488f5e85f');
                }
            }
        })

        .controller('SignUpCtrl', ['$scope', '$http', 'Security', function (scope, http, security) {
            var isValidTime = function (day, month, year) {
                if (day < 1 || day > 31) {
                    return false;
                }

                if (month === 1 || month === 3 || month === 5 || month === 7 || month === 8 || month === 10 || month === 12) {
                    if (day < 32) {
                        return true;
                    }
                } else if (month === 4 || month === 6 || month === 9 || month === 11) {
                    if (day < 32) {
                        return true;
                    }
                } else {
                    if ((year % 400 === 0) || (year % 4 == 0 && year % 100 !== 0)) {
                        if (day < 30) {
                            return true;
                        }
                    } else {
                        if (day < 29) {
                            return true;
                        }
                    }
                }

                return false;
            }

            http.get('/Content/data/provinces.json').then(function (data) {
                scope.provinces = data.data;
            });

            scope.signup = function () {
                var fullname = document.getElementById('txtFullName'),
                    day = document.getElementById('birthday-date'),
                    month = document.getElementById('birthday-month'),
                    year = document.getElementById('birthday-year'),
                    city = document.getElementById('city'),
                    username = document.getElementById('txtUsername'),
                    password = document.getElementById('txtPassword'),
                    confirm = document.getElementById('txtConfirmPassword'),
                    captcha = document.getElementById('g-recaptcha-response');

                if (fullname.value.length === 0 &&
                    fullname.validity.valid === false) {
                    return;
                }

                if (username.value.length === 0 &&
                    username.validity.valid === false) {
                    return;
                }

                if (day.selected.length === 0) {
                    return;
                }

                if (month.selected.length === 0) {
                    return;
                }

                if (year.selected.length === 0) {
                    return;
                }

                if (city.selected.length === 0) {
                    return;
                }

                if (password.value.length === 0 &&
                    password.validity.valid === false) {
                    return;
                }

                if (confirm.value.length === 0 &&
                    confirm.value !== password.value &&
                    confirm.validity.valid === false) {
                    return;
                }

                if (captcha.value.length === 0) {
                    return;
                }

                if (isValidTime(day.selected, month.selected, year.selected) === false) {
                    return;
                }

                var keyword = 'user=' + username.value;
                keyword = Base64.encode(keyword);

                http.get('/index/isexisted/' + keyword).then(function (result) {
                    if (result.data === false) {
                        scope.isnAvailable = false;

                        var params = [
                            { 'fullname': fullname.value },
                            { 'username': username.value },
                            { 'day': day.selected },
                            { 'month': month.selected },
                            { 'year': year.selected },
                            { 'city': city.selected },
                            { 'password': security.encode(password.value) },
                            { 'captcha': captcha.value }
                        ];

                        var form = document.createElement('form');
                        form.setAttribute('method', 'post');
                        form.setAttribute('action', '/index/signuphandler');

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
                    } else {
                        scope.isnAvailable = true;
                    }
                });
            };
        } ]);
})();