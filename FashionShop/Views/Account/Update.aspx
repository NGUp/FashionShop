<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Cập nhật Tài khoản
</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
    Cập nhật Tài khoản
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/account/account-update.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Selected" ContentPlaceHolderID="SelectedContent" runat="server">3</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/account/account-update.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
    <link rel="import" href="/bower_components/paper-checkbox/paper-checkbox.html">
    <link rel="import" href="/bower_components/core-label/core-label.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <article class="container" ng-controller="UpdateCtrl">
        <div class="update-content">
            <h3><%= ViewData["ID"] %></h3>
            <div class="update-textfield">
                <template is="auto-binding">
                    <paper-input-decorator label="Họ tên" floatingLabel isInvalid="{{!$.txtName.validity.valid}}" error="Họ tên chỉ có thể là ký tự thường, hoa.">
                        <input is="core-input" id="txtName" spellcheck="false" type="text" value="<%= ViewData["Name"] %>" pattern="^[a-zA-Z ]{3,}$">
                    </paper-input-decorator>
                </template>
                <template is="auto-binding">
                    <paper-input-decorator label="Tên đăng nhập" floatingLabel isInvalid="{{!$.txtUsername.validity.valid}}" error="Tên đăng nhập chỉ có thể là ký tự thường, hoa hoặc chữ số. Tối thiểu 4 kí tự.">
                        <input is="core-input" id="txtUsername" spellcheck="false" value="<%= ViewData["Username"] %>" type="text" pattern="^[a-zA-Z0-9]{4,}$">
                    </paper-input-decorator>
                </template>
                <template is="auto-binding">
                    <paper-input-decorator label="Ngày sinh" floatingLabel isInvalid="{{!$.txtBirthday.validity.valid}}" error="Định dạng ngày sinh là dd/MM/yyyy hoặc dd-MM-yyyy.">
                        <input is="core-input" type="text" id="txtBirthday" value="<%= ViewData["Birthday"] %>" pattern="^[a-zA-Z0-9!@#$%^&*?_~]{8,}$">
                    </paper-input-decorator>
                </template>
                <template is="auto-binding">
                    <paper-input-decorator label="Mật khẩu" floatingLabel isInvalid="{{!$.txtPassword.validity.valid}}" error="Mật khẩu không hợp lệ.">
                        <input is="core-input" type="password" id="txtPassword" pattern="^[a-zA-Z0-9!@#$%^&*?_~]{8,}$">
                    </paper-input-decorator>
                </template>
            </div>
            <div class="update-checkbox">
                <core-label center horizontal layout>
                    <div flex>Kích hoạt</div>
                    <paper-checkbox checked="<%= ((int)ViewData["State"] == 1) ? "true" : "false" %>"></paper-checkbox>
                </core-label>
            </div>
            <div class="update-checkbox">
                <core-label center horizontal layout>
                    <div flex>Quản trị viên</div>
                    <paper-checkbox checked="<%= ((int)ViewData["Permission"] == 1) ? "true" : "false" %>"></paper-checkbox>
                </core-label>
            </div>
            <div class="update-buttons">
                <paper-button>Hủy</paper-button>
                <paper-button class="update-accept-button">Đồng ý</paper-button>
            </div>
        </div>
    </article>

</asp:Content>