<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="Default.aspx.vb" Inherits="AspNet5t.DefaultMain" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div>
        <asp:PlaceHolder runat="server" ID="SuccessMessagePlaceHolder" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

</asp:Content>
