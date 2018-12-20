<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Login.master" CodeBehind="LoginAux.aspx.vb" Inherits="AspNet5t.LoginAux" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<%@ Import Namespace="Microsoft.AspNet.Identity" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderRoot" runat="server">
    <link href="<%= Page.ResolveUrl("~/Content/bootstrap.min.css")%>?v=<%= DateTime.Now.Ticks %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl("~/Content/4t/css/styles4tmain.css")%>?v=<%= DateTime.Now.Ticks %>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl("~/Content/4t/css/loginAux.css")%>?v=<%= DateTime.Now.Ticks %>" rel="stylesheet" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderRoot" runat="server">
     
    <script type="text/javascript">
        window.onload = function () {            
            txtUsuario.Focus();
        }       
    </script>
   <div id="fullscreen_bg" class="fullscreen_bg"/>
    <div class="container-fluid">
        <div class="row" id="toprow4T">
            <div class="col-xs-2">
                <img src="<%= Page.ResolveUrl("~/Content/Images/LogoUAMpequeno.png")%>" />
            </div>
            <div class="col-xs-10 text-right invisivel">
                <dx:ASPxHyperLink runat="server" ID="hlLogo" NavigateUrl="~/Default.aspx" ImageUrl="~/Content/Images/Logo4T.png">
                </dx:ASPxHyperLink>
                <img src="<%= Page.ResolveUrl("~/Content/Images/Logo4TLetters.png")%>" />
            </div>
        </div>
    </div>
    
    <div class="content">
    <div>
        <asp:PlaceHolder runat="server" ID="SuccessMessagePlaceHolder" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>
        <div class="row">
            <h3 class="col-xs-12 text-center texto-autenticacao">AUTENTICAÇÃO</h3>
            <span class="col-xs-12 text-center">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </span>
        </div>
        <dx:ASPxFormLayout ID="LoginFormLayout" runat="server" RequiredMarkDisplayMode="None">
            <Items>
                <dx:LayoutItem>
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox runat="server" NullText="Usuário" Native="true" CssClass="form-control form-control-solid" Width="100%" ClientIDMode="Static" ID="txtUsuario" ClientInstanceName="txtUsuario">
                                <NullTextStyle Font-Italic="True"></NullTextStyle>

                                <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="None" Display="Dynamic" ValidationGroup="login">
                                    <RequiredField IsRequired="True"></RequiredField>
                                </ValidationSettings>
                            </dx:ASPxTextBox>

                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem>
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox runat="server" NullText="Senha" Native="true" CssClass="form-control form-control-solid" Width="100%" ClientIDMode="Static" ID="txtPassword" Password="True">
                                <NullTextStyle Font-Italic="True"></NullTextStyle>

                                <ValidationSettings ErrorDisplayMode="None" Display="Dynamic" ValidationGroup="login">
                                    <RequiredField IsRequired="True"></RequiredField>
                                </ValidationSettings>
                            </dx:ASPxTextBox>

                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>

            <SettingsItems Width="328px" ShowCaption="False" />
            <Styles>
                <LayoutGroup>
                    <Cell>
                        <Paddings PaddingTop="3px" PaddingBottom="3px" />
                    </Cell>
                </LayoutGroup>
            </Styles>
        </dx:ASPxFormLayout>

        <div class="row">
            <div class="col-xs-2"></div>
            <div class="col-xs-4 text-center">
                    <dx:ASPxButton ID="btnLoginNow" runat="server" Text="Login" Native="true" CssClass="btn btn-success btn-4t" OnClick="btnLoginNow_Click" ValidationGroup="login" >
                    </dx:ASPxButton>
            </div>
            <div class="col-xs-4 text-center">
                    <dx:ASPxButton ID="btnCancelLogin" runat="server" Text="Cancelar" Native="true" CssClass="btn btn-default btn-4t" AutoPostBack="false">
                        <ClientSideEvents Click="function(s, e) { window.location = 'Default.aspx'; }" />
                    </dx:ASPxButton>
            </div>
            <div class="col-xs-2"></div>
        </div>
    </div>
</asp:Content>
