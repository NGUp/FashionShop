<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat=server>
    Giới thiệu
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/index/index-advance.js"></script>
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/index/index-about.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat=server>
    <article>
        <h2>Giới thiệu</h2>
        <div class="content">
            <h3>Thành viên</h3>
            <ul class="list">
                <li>
                    <strong>1265020</strong> - Nguyễn Thành Nhân
                </li>
                <li>
                    <strong>1265094</strong> - Võ Hoài Nam
                </li>
                <li>
                    <strong>1265095</strong> - Nguyễn Thị Thủy Ngân
                </li>
                <li>
                    <strong>1265104</strong> - Huỳnh Chí Phong
                </li>
            </ul>
        </div>
        <div class="content">
            <h3>Công nghệ</h3>
            <ul class="list">
                <li>
                    <a href="http://bower.io/">Bower - Trình quản lý package phía client.</a>
                </li>
                <li>
                    <a href="https://angularjs.org/">Google AngularJS - JavaScript framework, phiên bản 1.3.15.</a>
                </li>
                <li>
                    <a href="http://getbootstrap.com/">Twitter Bootstrap - Front-End framework, phiên bản 3.3.4.</a>
                </li>
                <li>
                    <a href="https://www.polymer-project.org/">Google Polymer - Bộ thư viện hỗ trợ viết Web Components theo thiết kế Material Design, phiên bản 0.5.</a>
                </li>
                <li>
                    Microsoft ASP.NET MVC 2
                </li>
            </ul>
        </div>
        <div class="content">
            <h3>Hỗ trợ khác</h3>
            <ul class="list">
                <li>
                    <a href="http://www.google.com/design/spec/material-design/introduction.html">Thiết kế Material Design.</a>
                </li>
                <li>
                    Web Responsive (đa số các màn hình).
                </li>
                <li>
                    Có gắn Token trong HTTP Request Header mỗi khi lấy dữ liệu JSON từ Server.
                </li>
                <li>
                    Chỉ sử dụng jQuery đủ để có điểm bằng các selector, có thể nói là <strong>không sử dụng jQuery</strong>.
                </li>
            </ul>
        </div>
    </article>
</asp:Content>