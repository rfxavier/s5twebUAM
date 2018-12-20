<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="RoleAdmin.aspx.vb" Inherits="AspNet5t.RoleAdmin" %>
<%@ Register assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsRoles" KeyFieldName="Id">
    <Columns>
        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="3">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
    </Columns>
</dx:ASPxGridView>
<asp:ObjectDataSource ID="dsRoles" runat="server" DataObjectTypeName="S5T.IdRole" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAll" TypeName="S5T.IdRoleCollection" UpdateMethod="Save"></asp:ObjectDataSource>
</asp:Content>
