<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html ng-app="admin">
    <head>
        <meta charset="UTF-8" />
        <title>Đăng nhập</title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link href="/Content/icon/favicon.png" rel="shortcut icon">
        <link href="/Content/css/admin/admin-login.css" rel="stylesheet" type="text/css" />
        <%--<link href="https://fonts.googleapis.com/css?family=RobotoDraft:400,500,700,400italic" rel="stylesheet" type="text/css">--%>
    </head>
    <body>
        <div class="wrap-content" ng-controller="LoginCtrl">
            <section>
                <article>
                    <h1>
                        <img src="/Content/icon/logo.png" alt="Kids Fashion" />
                    </h1>
                    <div>
                        <core-field>
                            <input placeholder="Tên đăng nhập" id="txtUsername" autocomplete="off" spellcheck="false" name="username" flex>
                        </core-field>
                        <core-field>
                            <input placeholder="Mật khẩu" id="txtPassword" autocomplete="off" spellcheck="false" type="password" name="password" flex>
                        </core-field>
                    </div>
                    <div class="div-button">
                        <paper-button raised ng-click="login()">Đăng nhập</paper-button>
                    </div>
                </article>
            </section>
        </div>

        <script src="/Scripts/platform.js"></script>
        <script src="/bower_components/angular/angular.min.js"></script>
        <script src="/Scripts/sha1.js"></script>
        <script src="/Scripts/md5.js"></script>
        <script src="/Content/js/admin/admin-login.js"></script>

        <link rel="import" href="/bower_components/core-field/core-field.html">
        <link rel="import" href="/bower_components/paper-button/paper-button.html">
    </body>
</html>
