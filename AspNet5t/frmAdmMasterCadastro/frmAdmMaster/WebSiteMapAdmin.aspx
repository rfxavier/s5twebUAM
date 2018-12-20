<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="WebSiteMapAdmin.aspx.vb" Inherits="AspNet5t.WebSiteMapAdmin" %>
<%@ Register assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsWebSiteMap" KeyFieldName="pId">
    <Columns>
        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="pId" ReadOnly="True" VisibleIndex="3">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="pRelPath" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="pNode" VisibleIndex="5">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="pDescription" VisibleIndex="6">
        </dx:GridViewDataTextColumn>
    </Columns>
        <SettingsPager PageSize="20">
        </SettingsPager>
</dx:ASPxGridView>
<asp:ObjectDataSource ID="dsWebSiteMap" runat="server" DataObjectTypeName="S5T.WebSiteMap" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAll" TypeName="S5T.WebSiteMapCollection" UpdateMethod="Save"></asp:ObjectDataSource>
</asp:Content>
