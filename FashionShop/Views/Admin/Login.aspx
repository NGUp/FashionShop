<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainAdmin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Đăng nhập
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/admin-login.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    
    <article class="login-form">
        <div>
            <paper-input label="Tên đăng nhập" floatingLabel></paper-input>
        </div>
        <div>
            <paper-input-decorator label="Mật khẩu" floatingLabel>
                <input is="core-input" type="password">
            </paper-input-decorator>
        </div>
        <div>
            <paper-button raised class="login-button">Đăng nhập</paper-button>
        </div>
    </article>

</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
</asp:Content>