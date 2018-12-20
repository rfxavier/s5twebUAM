<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="LogAdmin.aspx.vb" Inherits="AspNet5t.LogAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
<span>AppDomain.CurrentDomain.FirstChanceException</span>
<asp:Button ID="btnAdd" runat="server" Text="Add Handler" />
<asp:Button ID="btnRemove" runat="server" Text="Remove Handler" />
</asp:Content>
