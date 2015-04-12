<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainAdmin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Đăng nhập
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/admin-login.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <article class="login-form" ng-controller="LoginCtrl">
        <div>
            <template is="auto-binding">
                <paper-input-decorator label="Tên đăng nhập" floatingLabel isInvalid="{{!$.txtUsername.validity.valid}}" error="Tên đăng nhập chỉ có thể là ký tự thường, hoa hoặc chữ số.">
                    <input is="core-input" id="txtUsername" spellcheck="false" type="text" pattern="^[a-zA-Z0-9]{4,}$">
                </paper-input-decorator>
            </template>
        </div>
        <div>
            <template is="auto-binding">
                <paper-input-decorator label="Mật khẩu" floatingLabel isInvalid="{{!$.txtPassword.validity.valid}}" error="Mật khẩu không hợp lệ.">
                    <input is="core-input" type="password" id="txtPassword" pattern="^[a-zA-Z0-9!@#$%^&*?_~]{8,}$">
                </paper-input-decorator>
            </template>
        </div>
        <div>
            <paper-button raised ng-click="login()">Đăng nhập</paper-button>
        </div>
    </article>

</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Scripts/sha1.js"></script>
    <script src="/Scripts/md5.js"></script>
    <script src="/Content/js/admin/admin-login.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
</asp:Content>