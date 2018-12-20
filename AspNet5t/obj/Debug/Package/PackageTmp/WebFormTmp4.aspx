<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="WebFormTmp4.aspx.vb" Inherits="AspNet5t.WebFormTmp4" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Linear" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Circular" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.State" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGauges.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGauges.Gauges.Digital" tagprefix="dx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceHolderMain" runat="server">
    <%--<iframe src="Content/mapas/00338.pdf"></iframe>--%>
    <a href="Content/mapas/00338.pdf?x=s" target="_blank">View PDF</a>

    <dx:ASPxGaugeControl ID="ASPxGaugeControl2" runat="server" Height="260px" Width="260px" BackColor="White" LayoutInterval="6" Value="20"></dx:ASPxGaugeControl>
                                                    <dx:ASPxGaugeControl runat="server" Value="1" AutoLayout="False" Width="500px" Height="80px" BackColor="White" ID="ASPxGaugeControl1" OnInit="ASPxGaugeControl1_Init">
                                                        <Gauges>
                                                            <dx:LinearGauge Orientation="Horizontal" Name="linearGauge11" Bounds="-20, 0, 520, 80">
                                                                <scales>
                                                                    <dx:LinearScaleComponent AppearanceScale-Brush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" AppearanceScale-Width="4" AppearanceTickmarkText-Font="Tahoma, 6pt" AppearanceTickmarkText-TextBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" CustomLogarithmicBase="2" Appearance-Brush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#4D4D4D&quot;/&gt;" Appearance-Width="4" StartPoint="62.5, 230" EndPoint="62.5, 20" Value="1" MaxValue="140" MinorTickmark-ShowTick="True" MinorTickmark-ShapeOffset="-5" MinorTickmark-ShapeType="Circular_Style28_1" MinorTickCount="9" MajorTickmark-TextOffset="-18" MajorTickmark-TextOrientation="BottomToTop" MajorTickmark-FormatString="{0:#,#0.00}" MajorTickmark-ShowFirst="False" MajorTickmark-ShowLast="False" MajorTickmark-ShapeOffset="-8" MajorTickmark-ShapeType="Circular_Style28_1" MajorTickCount="8" AcceptOrder="0" Name="scale2">
                                                                        <Ranges>
                                                                            <dx:LinearScaleRangeWeb Name="Range0" AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#CE8396&quot;/&gt;" EndValue="90" StartThickness="7" EndThickness="7" ShapeOffset="1">
                                                                            </dx:LinearScaleRangeWeb>
                                                                            <dx:LinearScaleRangeWeb Name="Range1" AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#699BC1&quot;/&gt;" StartValue="90" EndValue="100" StartThickness="7" EndThickness="7" ShapeOffset="1">
                                                                            </dx:LinearScaleRangeWeb>
                                                                            <dx:LinearScaleRangeWeb Name="Range2" AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#F5E16B&quot;/&gt;" StartValue="100" EndValue="105" StartThickness="7" EndThickness="7" ShapeOffset="1">
                                                                            </dx:LinearScaleRangeWeb>
                                                                            <dx:LinearScaleRangeWeb Name="Range3" AppearanceRange-ContentBrush="&lt;BrushObject Type=&quot;Solid&quot; Data=&quot;Color:#67DD63&quot;/&gt;" StartValue="105" EndValue="140" StartThickness="7" EndThickness="7" ShapeOffset="1">
                                                                            </dx:LinearScaleRangeWeb>
                                                                        </Ranges>
                                                                    </dx:LinearScaleComponent>
                                                                </scales>
                                                                <markers>
                                                                    <dx:LinearScaleMarkerComponent ScaleID="scale2" LinearScale="" ZOrder="-150" AcceptOrder="150" Name="linearGauge11_Marker1">
                                                                    </dx:LinearScaleMarkerComponent>
                                                                </markers>
                                                            </dx:LinearGauge>
                                                        </Gauges>
                                                        <LayoutPadding All="0" Left="0" Top="0" Right="0" Bottom="0"></LayoutPadding>
                                                    </dx:ASPxGaugeControl>

    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="ASPxButton"></dx:ASPxButton>
    <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="ASPxHyperLink" NavigateUrl="~/Content/mapas/00338.pdf" Target="_blank" Theme="Office2003Silver">
    </dx:ASPxHyperLink>
</asp:Content>
<%--<a href="Content/mapas/00338.pdf">Content/mapas/00338.pdf</a>--%>