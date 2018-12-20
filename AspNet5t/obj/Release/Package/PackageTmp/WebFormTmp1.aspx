<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="WebFormTmp1.aspx.vb" Inherits="AspNet5t.WebFormTmp1" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Linear" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Circular" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.State" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Digital" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="ASPxButton1"></dx:ASPxButton>
    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="ASPxButton2" AutoPostBack="False">
        <ClientSideEvents Click="function(s, e) { cbPanel.PerformCallback(); }"></ClientSideEvents>
    </dx:ASPxButton>

    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="cbPanel">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxDataView ID="ASPxDataView1" runat="server" DataSourceID="SqlDataSource1" Height="100%" ItemSpacing="0px" PagerPanelSpacing="0px" ClientInstanceName="dv">
                    <PagerSettings ShowNumericButtons="False">
                    </PagerSettings>
                    <ItemTemplate>
                        <asp:hiddenfield ID="DISPmeta" runat="server" Value='<%# Eval("DISPmeta") %>'></asp:hiddenfield>
                        &nbsp;<asp:Label ID="DSC_CLASSE_MECANICALabel" runat="server" Text='<%# String.Concat(Eval("DSC_CLASSE_MECANICA"), " ( ", Eval("QTD_MANUT"), " )") %>' BackColor="White" Font-Bold="True" ForeColor="Black" />   <%--#D0FFD0--%>
                        <br />
                        <dx:ASPxGaugeControl ID="ASPxGaugeControl1" runat="server" BackColor="White" Height="120px" LayoutInterval="3" Value='<%# Eval("DISP") %>' Width="180px" OnDataBinding="ASPxGaugeControl1_DataBinding">
                            <Gauges>
                                <dx:CircularGauge Bounds="1, 1, 178, 119" Name="cGauge1">
                                    <scales>
                            <dx:ArcScaleComponent AcceptOrder="0" AppearanceTickmarkText-Font="Tahoma, 12pt" AppearanceTickmarkText-TextBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:Black&quot;/&gt;" Center="125, 165" EndAngle="0" MajorTickmark-FormatString="{0:F0}" MajorTickmark-ShapeOffset="-5" MajorTickmark-ShapeScale="0.6, 0.8" MajorTickmark-ShapeType="Circular_Style11_4" MajorTickmark-TextOffset="-17" MajorTickmark-TextOrientation="LeftToRight" MaxValue="100" MinorTickmark-ShapeOffset="-2.5" MinorTickmark-ShapeScale="0.6, 1" MinorTickmark-ShapeType="Circular_Style11_3" MinorTickmark-ShowFirst="False" MinorTickmark-ShowLast="False" Name="scale1" RadiusX="107" RadiusY="107" StartAngle="-180" Value="20">
                                <ranges>
                                    <dx:ArcScaleRangeWeb AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#EF8C75&quot;/&gt;" EndThickness="14" EndValue="85" Name="Range0" ShapeOffset="0" StartThickness="14" />
                                    <dx:ArcScaleRangeWeb AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#9EC968&quot;/&gt;" EndThickness="14" EndValue="100" Name="Range2" ShapeOffset="0" StartThickness="14" StartValue="85" />
                                </ranges>
                            </dx:ArcScaleComponent>
                        </scales>
                                    <backgroundlayers>
                            <dx:ArcScaleBackgroundLayerComponent AcceptOrder="-1000" ArcScale="" Name="bg1" ScaleCenterPos="0.5, 0.815" ScaleID="scale1" ShapeType="CircularHalf_Style11" Size="250, 154" ZOrder="1000" />
                        </backgroundlayers>
                                    <needles>
                            <dx:ArcScaleNeedleComponent AcceptOrder="50" ArcScale="" EndOffset="5" Name="needle1" ScaleID="scale1" ShapeType="CircularFull_Style11" StartOffset="-9.5" ZOrder="-50" />
                        </needles>
                                    <markers>
                            <dx:ArcScaleMarkerComponent AcceptOrder="100" ArcScale="" Name="cGauge1_Marker1" ScaleID="scale1" Shader="&lt;ShaderObject Type=&quot;Style&quot; Data=&quot;Colors[Style1:#9EC968;Style2:DarkGreen]&quot;/&gt;" ShapeType="WedgeLeft" Value="85" ZOrder="-100" />
                        </markers>
                                    <indicators>
                            <dx:ArcScaleStateIndicatorComponent AcceptOrder="100" Center="243, 165" IndicatorScale="" Name="cGauge1_Indicator1" ScaleID="scale1" Size="25, 25" StateIndex="0" ZOrder="-100">
                                <states>
                                    <dx:ScaleIndicatorStateWeb IntervalLength="85" Name="Default" ShapeType="ElectricLight2" />
                                    <dx:ScaleIndicatorStateWeb IntervalLength="100" Name="State1" ShapeType="ElectricLight4" StartValue="85" />
                                </states>
                            </dx:ArcScaleStateIndicatorComponent>
                        </indicators>
                                </dx:CircularGauge>
                            </Gauges>
                            <LayoutPadding All="-1" Bottom="0" Left="1" Right="1" Top="1" />
                        </dx:ASPxGaugeControl>
                        <br />
                        <asp:Label ID="DISPlabel" runat="server" Text='<%# String.Concat(Eval("DISP", "{0:0}"), "%")%>' Font-Bold="True" ForeColor='<%# Iif(Eval("DISP") >= Eval("DISPmeta"), System.Drawing.Color.Green, System.Drawing.Color.Red) %>' Font-Size="large"  />
                    </ItemTemplate>
                    <ItemStyle BackColor="White" Height="130px" HorizontalAlign="Center" Width="180px">
                        <Border BorderStyle="None" />
                    </ItemStyle>
                </dx:ASPxDataView>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1Corte %>" ProviderName="<%$ ConnectionStrings:ConnectionString1Corte.ProviderName %>" SelectCommand="select COD_CLASSE_MECANICA, DSC_CLASSE_MECANICA, QTD_MANUT, QTDE_EQUIP, DISP, DECODE(COD_CLASSE_MECANICA,9,53,85) DISPmeta FROM V_RESUMO_OFICINA_DISP"></asp:SqlDataSource>
</asp:Content>
