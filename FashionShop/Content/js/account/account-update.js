(function () {

    'use strict';

    angular.module('admin', [])
        .factory('Form', function () {
            return {
                submit: function (params) {
                    var form = document.createElement('form');
                    form.setAttribute('method', 'post');
                    form.setAttribute('action', '/admin/account/updatehandler');

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
            };
        })

        .controller('UpdateCtrl', ['$scope', 'Form', function (scope, form) {
            scope.cancel = function () {
                window.location.href = '/admin/account';
            };

            scope.update = function () {
                var id = document.getElementById('txtID'),
                    username = document.getElementById('txtUsername'),
                    name = document.getElementById('txtName'),
                    birthday = document.getElementById('txtBirthday'),
                    password = document.getElementById('txtPassword'),
                    city = document.getElementById('txtCity'),
                    state = document.getElementById('chkboxState'),
                    isAdmin = document.getElementById('chkboxAdmin');

                if (name.validity.valid === false ||
                        name.value.length === 0) {
                    name.focus();
                    return;
                }

                if (birthday.validity.valid === false ||
                        birthday.value.length === 0) {
                    birthday.focus();
                    return;
                }

                if (password.validity.valid === false ||
                        password.value.length === 0) {
                    password.focus();
                    return;
                }

                if (city.validity.valid === false) {
                    city.focus();
                    return;
                }

                form.submit([
                    { 'id': id.innerHTML },
                    { 'username': username.innerHTML },
                    { 'name': name.value },
                    { 'birthday': birthday.value },
                    { 'password': password.value },
                    { 'city': city.value },
                    { 'state': state.checked ? 1 : 0 },
                    { 'isAdmin': isAdmin.checked ? 1 : 0 }
                ]);
            };
        } ]);

})();