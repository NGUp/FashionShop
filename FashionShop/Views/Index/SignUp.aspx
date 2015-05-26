<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Đăng ký
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/index/index-sign-up.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="https://www.google.com/recaptcha/api.js"></script>
    <script src="/Scripts/sha1.js"></script>
    <script src="/Scripts/md5.js"></script>
    <script src="/Scripts/base64.js"></script>
    <script src="/Content/js/index/index-sign-up.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
    <link rel="import" href="/bower_components/core-menu/core-menu.html">
    <link rel="import" href="/bower_components/paper-dropdown/paper-dropdown.html">
    <link rel="import" href="/bower_components/paper-item/paper-item.html">
    <link rel="import" href="/bower_components/paper-dropdown-menu/paper-dropdown-menu.html">
    <link rel="import" href="/bower_components/paper-dialog/paper-dialog.html">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <article class="content" ng-controller="SignUpCtrl">
        <div>
            <h3>Thông tin cá nhân</h3>
            <template is="auto-binding">
                <paper-input-decorator label="Họ tên" floatingLabel isInvalid="{{!$.txtFullName.validity.valid}}" error="Họ tên không hợp lệ.">
                    <input is="core-input" id="txtFullName" spellcheck="false" type="text" pattern="^([a-zA-Z ]{0,}[^\u0000-\u007F]{0,})+$">
                </paper-input-decorator>
            </template>
            <div style="display: flex;">
                <div class="sign-up-calendar">
                    <h5>Ngày</h5>
                    <paper-dropdown-menu label="Ngày" class="day">
                        <paper-dropdown class="dropdown">
                            <core-menu id="birthday-date" class="menu" valueattr="value" selected="1">
                                <%
                                    for (int day = 1; day < 32; day++)
                                    {
                                       Response.Write("<paper-item value=" + day + ">" + day + "</paper-item>");
                                    }
                                %>
                            </core-menu>
                        </paper-dropdown>
                    </paper-dropdown-menu>
                </div>
                <div class="sign-up-calendar">
                    <h5>Tháng</h5>
                    <paper-dropdown-menu label="Tháng" class="month">
                        <paper-dropdown class="dropdown">
                            <core-menu id="birthday-month" class="menu" valueattr="value" selected="1">
                                <%
                                    for (int month = 1; month < 13; month++)
                                    {
                                       Response.Write("<paper-item value=" + month + ">" + month + "</paper-item>");
                                    }
                                %>
                            </core-menu>
                        </paper-dropdown>
                    </paper-dropdown-menu>
                </div>
                <div class="sign-up-calendar">
                    <h5>Năm</h5>
                    <paper-dropdown-menu label="Năm" class="year">
                        <paper-dropdown class="dropdown">
                            <core-menu id="birthday-year" class="menu" valueattr="value" selected="1994">
                                <%
                                    int maxYear = DateTime.Now.Year + 1;
                                    for (int year = 1930; year < maxYear; year++)
                                    {
                                       Response.Write("<paper-item value=" + year + ">" + year + "</paper-item>");
                                    }
                                %>
                            </core-menu>
                        </paper-dropdown>
                    </paper-dropdown-menu>
                </div>
            </div>
            <paper-dropdown-menu label="Bạn sống tại" class="city">
                <paper-dropdown class="dropdown">
                    <core-menu id="city" class="menu" valueattr="value" selected="TP.HCM">
                        <paper-item value="TP.HCM">TP.HCM</paper-item>
                        <paper-item value="Hà Nội">Hà Nội</paper-item>
                        <paper-item value="Hải Phòng">Hải Phòng</paper-item>
                        <paper-item value="Cần Thơ">Cần Thơ</paper-item>
                        <paper-item value="Đà Nẵng">Đà Nẵng</paper-item>
                    </core-menu>
                </paper-dropdown>
            </paper-dropdown-menu>
        </div>
        <div>
            <h3>Thông tin tài khoản</h3>
            <template is="auto-binding">
                <paper-input-decorator label="Tên đăng nhập" floatingLabel isInvalid="{{!$.txtUsername.validity.valid}}" error="Tên đăng nhập không hợp lệ.">
                    <input is="core-input" id="txtUsername" spellcheck="false" type="text" pattern="^[a-zA-Z0-9]{4,}$">
                </paper-input-decorator>
            </template>
            <template is="auto-binding">
                <paper-input-decorator label="Mật khẩu" floatingLabel isInvalid="{{!$.txtPassword.validity.valid}}" error="Mật khẩu không hợp lệ.">
                    <input is="core-input" type="password" id="txtPassword" pattern="^[a-zA-Z0-9!@#$%^&*?_~]{8,}$">
                </paper-input-decorator>
            </template>
            <template is="auto-binding">
                <paper-input-decorator label="Xác nhận Mật khẩu" floatingLabel isInvalid="{{!$.txtConfirmPassword.validity.valid}}" error="Mật khẩu không hợp lệ.">
                    <input is="core-input" type="password" id="txtConfirmPassword" pattern="^[a-zA-Z0-9!@#$%^&*?_~]{8,}$">
                </paper-input-decorator>
            </template>
        </div>

        <div class="div-captcha">
            <h3>Xác nhận</h3>
            <div class="g-recaptcha" data-sitekey="6LdqAAcTAAAAAHjgN3wATwz_hrV_fmmo_BT8dHCJ"></div>
        </div>
        <paper-button class="right" ng-click="signup()" raised>Đăng ký</paper-button>
        
        <div class="clear"></div>

        <paper-dialog heading="Thông báo" id="paper-dialog" transition="paper-dialog-transition-center">
            <h4 class="error-status">Tên đăng nhập đã tồn tại.</h4>
            <core-icon-button icon="done" affirmative autofocus class="done-button" ng-click="signup()"></core-icon-button>
        </paper-dialog>
    </article>

</asp:Content>