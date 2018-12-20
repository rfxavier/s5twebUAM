<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="pivotEntradaCanaAgrupApp.aspx.vb" Inherits="AspNet5t.pivotEntradaCanaAgrupApp" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <script type="text/javascript">
        var baseUrl = "<%= ResolveUrl("~/") %>";
    </script>

    <link href="<%= Page.ResolveUrl("~/Content/dx.common.css")%>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl("~/Content/dx.light.css")%>" rel="stylesheet" />

    <script src="<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/bootstrap.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/angular-sanitize.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/globalize.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jquery.globalize/cultures/globalize.culture.pt-BR.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/jszip.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Scripts/dx.webappjs.js")%>"></script>

    <script src="<%= Page.ResolveUrl("~/frmUsina/cnEntCana/PivotEntradaCanaAgrupJS/js/app.module.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/frmUsina/cnEntCana/PivotEntradaCanaAgrupJS/js/pivotEntradaCanaAppController.js")%>?v=<%= DateTime.Now.Ticks %>"></script>
    <script src="<%= Page.ResolveUrl("~/angularAppServices/ApiGetService.js")%>"></script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div ng-app="app4T" ng-controller="pivotCtrl as pivot">

        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Pivot Entrada de Cana</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div dx-pivot-grid="pivotgridSettings"></div>
                </div>
                <div class="row">
                    <div dx-pivot-grid-field-chooser="pivotgridfieldchooserSettings"></div>
                </div>

                <div dx-popup="popupOptions">
	                <div data-options="dxTemplate: { name: 'content' }">
		                <div dx-data-grid="datagridSettings"></div>
	                </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
