Imports DevExpress.Web.ASPxPivotGrid
Imports DevExpress.XtraCharts
Imports DevExpress.Utils
Imports Oracle.DataAccess.Client
Imports Microsoft.AspNet.Identity

Public Class pivotEntradaCana
    Inherits System.Web.UI.Page

    Private Sub SetChartType(ByVal text As String)
        WebChartControl1.SeriesTemplate.ChangeView(CType(System.Enum.Parse(GetType(ViewType), text), ViewType))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If

        ASPxPivotGrid1.DataBind()

        If (Not IsPostBack) Then
            Dim restrictedTypes() As ViewType = {ViewType.PolarArea, ViewType.PolarLine, ViewType.SideBySideGantt, ViewType.SideBySideRangeBar, ViewType.RangeBar, ViewType.Gantt, ViewType.PolarPoint, ViewType.Stock, ViewType.CandleStick, ViewType.Bubble}
            Dim allowedTypes() As ViewType = {ViewType.Line, ViewType.Area, ViewType.Bar, ViewType.Line, ViewType.Pie, ViewType.Point}
            For Each type As ViewType In System.Enum.GetValues(GetType(ViewType))
                If Array.IndexOf(Of ViewType)(allowedTypes, type) >= 0 Then
                    'Continue For
                    comboChartType.Items.Add(type.ToString())
                End If
            Next type
            comboChartType.SelectedItem = comboChartType.Items.FindByText(ViewType.Line.ToString())
            SetChartType(comboChartType.SelectedItem.Text)
        End If
    End Sub

    Protected Sub ASPxPivotGrid1_DataBinding(sender As Object, e As EventArgs) Handles ASPxPivotGrid1.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = New OracleConnection(oradb)
            conn.Open()
            Dim cmd As OracleCommand = New OracleCommand()
            cmd.Connection = conn
            cmd.CommandText = "select TRUNC(ID_NEGOCIOS) ID_NEGOCIOS, TRUNC(NR_ANO_SAFRA) NR_ANO_SAFRA, TRUNC(NRO_DOCUMENTO) NRO_DOCUMENTO, TRUNC(PROP_CODIGO) PROP_CODIGO, DS_NOME_PROPRIEDADE, DSC_VARIEDADE, TRUNC(NRO_CORTE) NRO_CORTE, FRENTE_COLHEITA, TRUNC(MUNICIPIO) MUNICIPIO, DESCMUNI, TRUNC(TIPO) TIPO, DESCTIPO, DT_ENTRADA, TRUNC(EQUIP_ENTRADA) EQUIP_ENTRADA, TRUNC(REBOQUE) REBOQUE, DT_MOAGEM, ROUND(AREA_COLHIDA,2) AREA_COLHIDA, ROUND(QT_TON_ENTREGUE_REAL,4) QT_TON_ENTREGUE_REAL from BI4T.ENTRADA_CANA_DET"
            cmd.CommandType = CommandType.Text
            Dim dr As OracleDataReader = cmd.ExecuteReader()

            ASPxPivotGrid1.DataSource = dr
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            ASPxPivotGrid1.DataSource = S5TUam.ENTRADA_CANA_DETCollection.LoadAll

        End If

    End Sub

    Protected Sub comboChartType_ValueChanged(sender As Object, e As EventArgs) Handles comboChartType.ValueChanged
        SetChartType(comboChartType.SelectedItem.Text)
    End Sub

    Protected Sub buttonSaveAs_Click(sender As Object, e As EventArgs) Handles buttonSaveAs.Click
        Export(True)
    End Sub

    Private Sub Export(ByVal saveAs As Boolean)
        For Each field As PivotGridField In ASPxPivotGrid1.Fields
            If field.ValueFormat IsNot Nothing AndAlso (Not String.IsNullOrEmpty(field.ValueFormat.FormatString)) Then
                field.UseNativeFormat = DefaultBoolean.True
            End If
        Next field
        ASPxPivotGridExporter1.OptionsPrint.PrintHeadersOnEveryPage = DefaultBoolean.False
        ASPxPivotGridExporter1.OptionsPrint.MergeColumnFieldValues = DefaultBoolean.True
        ASPxPivotGridExporter1.OptionsPrint.MergeRowFieldValues = DefaultBoolean.True

        ASPxPivotGridExporter1.OptionsPrint.PrintFilterHeaders = DefaultBoolean.False

        ASPxPivotGridExporter1.OptionsPrint.PrintColumnHeaders = DefaultBoolean.False

        ASPxPivotGridExporter1.OptionsPrint.PrintRowHeaders = DefaultBoolean.True

        ASPxPivotGridExporter1.OptionsPrint.PrintDataHeaders = DefaultBoolean.False

        Dim fileName As String = "PivotUsina" & DateTime.Now.ToShortDateString & DateTime.Now.ToShortTimeString

        ASPxPivotGridExporter1.ExportXlsToResponse(fileName, saveAs)
    End Sub
End Class