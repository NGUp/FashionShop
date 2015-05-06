<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Quản lý Sản phẩm
</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
	Quản lý Sản phẩm
</asp:Content>

<asp:Content ID="Selected" ContentPlaceHolderID="SelectedContent" runat="server">0</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/product/product-index.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <article class="container">
        <ul class="list-products">
            <li>
                <div class="product-details">
                    <h4 class="product-manufacturer">Old Navy</h4>
                    <img src="/Content/img/products/131210.8.3.jpg" alt="131210.8.3" />
                    <div>
                        <h4>131210.8.3</h4>
                        <h4 class="product-name">Áo dạ kẻ-MT Đỏ tím</h4>
                        <h4>217.000 VND</h4>
                    </div>
                </div>
            </li>
        </ul>
    </article>

</asp:Content>


