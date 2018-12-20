<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="cnEntCanaColheitaSeqMapa.aspx.vb" Inherits="AspNet5t.cnEntCanaColheitaSeqMapa" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
    <script>
        function OnInit(s, e) {
            AdjustSize();
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize();
            });
        }
        function AdjustSize() {
            var height = document.documentElement.clientHeight;
            dv.SetHeight(height-40*1.5);
        }
        function OnSelectedIndexChanged(s) {
            var parameters = dv.GetParameters();
            var parameter1 = parameters.GetParameterByIndex(0);

            dv.BeginUpdateParameters();
            parameter1.SetValue(s.GetSelectedItem().value);
            dv.EndUpdateParameters();
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <div style="position: absolute; margin-bottom: 6px;">
    <div style="float: left; margin-top: 4px;">
        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Sequência de Colheita" Style="font-size: 24px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
        </dx:ASPxLabel>
    </div>
    <div style="float: left; text-align: right; margin-top: 10px; margin-left: 10px; width: 300px;">
        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Selecione uma Frente" ClientVisible="true" ClientInstanceName="lbTonHoraMedia" EncodeHtml="False" Style="font-size: 18px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;" Width="220px">
        </dx:ASPxLabel>
    </div>
    <div style="float: left; text-align: center; margin-left: 10px; width: 200px;">

        <dx:ASPxComboBox ID="cmbFrente" runat="server" Theme="iOS" Width="120px" IncrementalFilteringMode="None">
            <ClientSideEvents SelectedIndexChanged="OnSelectedIndexChanged" />
            <Columns>
                <dx:ListBoxColumn Caption="Código" FieldName="pCodFrente" Name="CodFrente" Visible="False" />
                <dx:ListBoxColumn Caption="Frente" FieldName="pDescFrente" Name="DescFrente" />
            </Columns>
        </dx:ASPxComboBox>
    </div>
    </div>
    <%--    <div class="combofrente">
    </div>--%>
    <div class="clear-float">
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="cbPanel">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" DashboardSource="~/dashXmls/dashCnEntCanaEntradasSequencialColheita.xml" Width="98%" Height="370px" UseDataAccessApi="True" ClientInstanceName="dv" AllowExportDashboard="False">
<%--                    <ExportOptions>
                            <DocumentContentOptions FilterState="None"></DocumentContentOptions>
                        </ExportOptions>--%>
                        <ClientSideEvents Init="OnInit" />
                    </dx:ASPxDashboardViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>
</asp:Content>
