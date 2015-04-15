<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Trang chủ - Khu vực quản trị viên
</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
	Trang chủ
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/admin/admin-index.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <div class="index-image">
        <img src="/Content/img/admin/admin-index.png" alt="Management" />
    </div>

</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/admin/admin-index.js"></script>
</asp:Content>