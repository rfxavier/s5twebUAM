<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="AspNet5t.Login1" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<%@ Import Namespace="Microsoft.AspNet.Identity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="loginNoPopup">
        <div class="title">
            AUTENTICAÇÃO
            <p>
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
        </div>
        <div class="formLayout">
            <dx:ASPxFormLayout ID="LoginFormLayout" runat="server" RequiredMarkDisplayMode="None">
                <Items>
                    <dx:LayoutItem>
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox runat="server" NullText="Usuário" Width="100%" Height="30px" CssClass="editor" ID="txtUsuario">
                                    <ClientSideEvents Init="function(s, e) { s.Focus(); }" />
                                    <NullTextStyle Font-Italic="True"></NullTextStyle>

                                    <ValidationSettings ErrorDisplayMode="None" Display="Dynamic" ValidationGroup="login">
                                        <RequiredField IsRequired="True"></RequiredField>
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem>
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox runat="server" NullText="Senha" Width="100%" Height="30px" CssClass="editor" ID="txtPassword" Password="True">
                                    <NullTextStyle Font-Italic="True"></NullTextStyle>

                                    <ValidationSettings ErrorDisplayMode="None" Display="Dynamic" ValidationGroup="login">
                                        <RequiredField IsRequired="True"></RequiredField>
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem>
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxCheckBox runat="server" CheckState="Unchecked" ID="chkLembrar" Text="Lembrar senha"></dx:ASPxCheckBox>
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
        </div>
        <div class="buttons">
            <div class="buttonsContainer">
                <dx:ASPxButton ID="btnLoginNow" runat="server" Text="Login" Width="110px" Height="40px" BackColor="#f7f7f7"
                    OnClick="btnLoginNow_Click" ValidationGroup="login" Font-Size="14px">
                    <%--<HoverStyle BackColor="#f88e1d"></HoverStyle>--%>
                </dx:ASPxButton>
                <dx:ASPxButton ID="btnCancelLogin" runat="server" Text="Cancelar" AutoPostBack="false" Width="110px" Height="40px" BackColor="#f7f7f7" Font-Size="14px">
                    <%--<HoverStyle BackColor="#f88e1d"></HoverStyle>--%>
                </dx:ASPxButton>
            </div>
        </div>
    </div>
</asp:Content>
