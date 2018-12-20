<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="relEntradasPropriedades.aspx.vb" Inherits="AspNet5t.relEntradasPropriedades" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div>
        <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" ReportTypeName="AspNet5t.repCnEntCanaEntradasPropriedades" ToolbarMode="Ribbon">
            <SettingsReportViewer EnableReportMargins="True" />
            <StylesReportViewer>
                <Paddings Padding="10px"></Paddings>
            </StylesReportViewer>
        </dx:ASPxDocumentViewer>
    </div>
</asp:Content>
