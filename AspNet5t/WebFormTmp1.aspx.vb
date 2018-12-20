Public Class WebFormTmp1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub ASPxDataView1_DataBound(sender As Object, e As EventArgs) Handles ASPxDataView1.DataBound
        Dim gauge As DevExpress.Web.ASPxGauges.ASPxGaugeControl = CType(ASPxDataView1.FindItemControl("ASPxGaugeControl1", ASPxDataView1.Items(0)), DevExpress.Web.ASPxGauges.ASPxGaugeControl)
        Dim label As Label = CType(ASPxDataView1.FindItemControl("DISPlabel", ASPxDataView1.Items(0)), Label)
        If gauge IsNot Nothing Then MsgBox(gauge.Value)
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click
        Dim gauge As DevExpress.Web.ASPxGauges.ASPxGaugeControl = CType(ASPxDataView1.FindItemControl("ASPxGaugeControl1", ASPxDataView1.Items(0)), DevExpress.Web.ASPxGauges.ASPxGaugeControl)
        Dim label As Label = CType(ASPxDataView1.FindItemControl("DISPlabel", ASPxDataView1.Items(0)), Label)
        If gauge IsNot Nothing Then MsgBox(gauge.Value)

    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
        For Each dataviewItem In ASPxDataView1.Items
            Dim gauge As DevExpress.Web.ASPxGauges.ASPxGaugeControl = CType(ASPxDataView1.FindItemControl("ASPxGaugeControl1", dataviewItem), DevExpress.Web.ASPxGauges.ASPxGaugeControl)
            Dim dispmeta As HiddenField = CType(ASPxDataView1.FindItemControl("DISPmeta", dataviewItem), HiddenField)

            Dim marker As DevExpress.Web.ASPxGauges.Gauges.Circular.ArcScaleMarkerComponent = DirectCast(gauge.Gauges(0), DevExpress.Web.ASPxGauges.Gauges.Circular.CircularGauge).Markers(0)

            marker.Value = dispmeta.Value

            'Dim marker As LinearScaleMarkerComponent = DirectCast(ASPxGaugeControl26.Gauges(0), LinearGauge).Markers(0)
            'marker.Value = CSng(CDbl(RevenuesForecast))
        Next
    End Sub

    Protected Sub ASPxGaugeControl1_DataBinding(sender As Object, e As EventArgs)
        Dim gaugeToGetContainer As DevExpress.Web.ASPxGauges.ASPxGaugeControl = TryCast(sender, DevExpress.Web.ASPxGauges.ASPxGaugeControl)
        Dim container As DevExpress.Web.DataViewItemTemplateContainer = DirectCast(gaugeToGetContainer.NamingContainer, DevExpress.Web.DataViewItemTemplateContainer)

        Dim gauge As DevExpress.Web.ASPxGauges.ASPxGaugeControl = DirectCast(ASPxDataView1.FindItemControl("ASPxGaugeControl1", ASPxDataView1.Items(container.ItemIndex)), DevExpress.Web.ASPxGauges.ASPxGaugeControl)
        Dim dispmeta As HiddenField = CType(ASPxDataView1.FindItemControl("DISPmeta", ASPxDataView1.Items(container.ItemIndex)), HiddenField)

        Dim marker As DevExpress.Web.ASPxGauges.Gauges.Circular.ArcScaleMarkerComponent = DirectCast(gauge.Gauges(0), DevExpress.Web.ASPxGauges.Gauges.Circular.CircularGauge).Markers(0)

        marker.Value = dispmeta.Value

        Dim scale As DevExpress.Web.ASPxGauges.Gauges.Circular.ArcScaleComponent = DirectCast(gauge.Gauges(0), DevExpress.Web.ASPxGauges.Gauges.Circular.CircularGauge).Scales(0)

        scale.Ranges(0).EndValue = dispmeta.Value
        scale.Ranges(1).StartValue = dispmeta.Value

        'LinearScaleComponent scale = ((LinearGauge)ASPxGaugeControl26.Gauges[0]).Scales[0];

        'Dim mylabel1 As Label = TryCast(sender, Label)
        'Dim container As DataViewItemTemplateContainer = DirectCast(mylabel1.NamingContainer, DataViewItemTemplateContainer)
        'Dim mylabel2 As Label = DirectCast(DataView.FindItemControl("CategoryNameLabel", DataView.Items(container.ItemIndex)), Label)
        'mylabel1.Text = String.Format("{1}_{0}", mylabel1.Text, mylabel2.Text)


    End Sub
End Class