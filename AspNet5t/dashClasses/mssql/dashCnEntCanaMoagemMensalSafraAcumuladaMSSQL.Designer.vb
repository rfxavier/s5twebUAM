Namespace Win_Dashboards
    Partial Public Class dashCnEntCanaMoagemMensalSafraAcumuladaMSSQL
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim Dimension1 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim ColorSchemeEntry1 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry2 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry3 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries2 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim CalculatedField1 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim MsSqlConnectionParameters1 As DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters()
            Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim QueryParameter1 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashCnEntCanaMoagemMensalSafraAcumuladaMSSQL))
            Dim DataConnection1 As DevExpress.DataAccess.DataConnection = New DevExpress.DataAccess.DataConnection()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardParameter1 As DevExpress.DashboardCommon.DashboardParameter = New DevExpress.DashboardCommon.DashboardParameter()
            Me.chartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.dataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            CType(Me.chartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'chartDashboardItem1
            '
            Dimension1.DataMember = "DIA"
            Dimension1.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.Month
            Dimension1.Name = "Meses"
            Me.chartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension1})
            Me.chartDashboardItem1.AxisX.TitleVisible = True
            Me.chartDashboardItem1.ColoringOptions.UseGlobalColors = False
            ColorSchemeEntry1.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(10)
            ColorSchemeEntry1.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("TONELADA_REAL_AC")})
            ColorSchemeEntry2.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(1)
            ColorSchemeEntry2.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("TONELADA_PLAN_AC")})
            ColorSchemeEntry3.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(10)
            ColorSchemeEntry3.DataMember = "dsBI4T"
            ColorSchemeEntry3.DataSource = Me.dataSource1
            ColorSchemeEntry3.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("TONELADA_REAL_ACcalc")})
            Me.chartDashboardItem1.ColorScheme.AddRange(New DevExpress.DashboardCommon.ColorSchemeEntry() {ColorSchemeEntry1, ColorSchemeEntry2, ColorSchemeEntry3})
            Me.chartDashboardItem1.ComponentName = "chartDashboardItem1"
            Measure1.DataMember = "TONELADA_PLAN_AC"
            Measure1.Name = "Planejado"
            Measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure1.NumericFormat.IncludeGroupSeparator = True
            Measure1.NumericFormat.Precision = 0
            Measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure2.DataMember = "TONELADA_REAL_ACcalc"
            Measure2.Name = "Realizado"
            Measure2.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure2.NumericFormat.IncludeGroupSeparator = True
            Measure2.NumericFormat.Precision = 0
            Measure2.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Me.chartDashboardItem1.DataItemRepository.Clear()
            Me.chartDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem1")
            Me.chartDashboardItem1.DataItemRepository.Add(Measure1, "DataItem2")
            Me.chartDashboardItem1.DataItemRepository.Add(Measure2, "DataItem0")
            Me.chartDashboardItem1.DataMember = "dsBI4T"
            Me.chartDashboardItem1.DataSource = Me.dataSource1
            Me.chartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.chartDashboardItem1.Legend.InsidePosition = DevExpress.DashboardCommon.ChartLegendInsidePosition.TopLeftHorizontal
            Me.chartDashboardItem1.Legend.IsInsideDiagram = True
            Me.chartDashboardItem1.Legend.OutsidePosition = DevExpress.DashboardCommon.ChartLegendOutsidePosition.BottomLeftHorizontal
            Me.chartDashboardItem1.Name = "Mensal Acumulativo"
            ChartPane1.Name = "Pane 1"
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.Title = "Toneladas"
            ChartPane1.PrimaryAxisY.TitleVisible = True
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            SimpleSeries1.PointLabelOptions.ShowPointLabels = True
            SimpleSeries1.AddDataItem("Value", Measure2)
            SimpleSeries2.Name = "Planejado"
            SimpleSeries2.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries2.ShowPointMarkers = True
            SimpleSeries2.AddDataItem("Value", Measure1)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1, SimpleSeries2})
            Me.chartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.chartDashboardItem1.ShowCaption = True
            '
            'dataSource1
            '
            CalculatedField1.DataMember = "dsBI4T"
            CalculatedField1.DataType = DevExpress.DashboardCommon.CalculatedFieldType.[Decimal]
            CalculatedField1.Expression = "Iif(GetMonth([DIA]) > GetMonth(Today()), 0, [TONELADA_REAL_AC])"
            CalculatedField1.Name = "TONELADA_REAL_ACcalc"
            Me.dataSource1.CalculatedFields.AddRange(New DevExpress.DashboardCommon.CalculatedField() {CalculatedField1})
            Me.dataSource1.ComponentName = "dataSource1"
            Me.dataSource1.ConnectionName = "GIOVANA-LAPTOP\SQLEXPRESS_s5tuam_Connection"
            MsSqlConnectionParameters1.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.SqlServer
            MsSqlConnectionParameters1.DatabaseName = "s5tuam"
            MsSqlConnectionParameters1.ServerName = "GIOVANA-LAPTOP\SQLEXPRESS"
            Me.dataSource1.ConnectionParameters = MsSqlConnectionParameters1
            Me.dataSource1.Name = "dsBI4T"
            CustomSqlQuery1.Name = "dsBI4T"
            QueryParameter1.Name = "parSafra"
            QueryParameter1.Type = GetType(DevExpress.DataAccess.Expression)
            QueryParameter1.Value = New DevExpress.DataAccess.Expression("[Parameters.parSafra]", GetType(Short))
            CustomSqlQuery1.Parameters.Add(QueryParameter1)
            CustomSqlQuery1.Sql = "SELECT ID_NEGOCIOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     , NRO_ANO_SAFRA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     , MES" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     , DIA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     , TONELADA" & _
        "_PLAN" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     , TONELADA_PLAN_AC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     , TONELADA_REAL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     , TONELADA_REAL_AC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "F" & _
        "ROM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  dbo.RES_MENSAL_SAFRA_ACUMULADA"
            Me.dataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery1})
            Me.dataSource1.ResultSchemaSerializable = resources.GetString("dataSource1.ResultSchemaSerializable")
            '
            'dashCnEntCanaMoagemMensalSafraAcumuladaMSSQL
            '
            DataConnection1.Name = "localhost_Connection"
            DataConnection1.ParametersSerializable = resources.GetString("DataConnection1.ParametersSerializable")
            DataConnection1.ProviderKey = "Oracle"
            Me.DataConnections.Add(DataConnection1)
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.dataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.chartDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.chartDashboardItem1
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1})
            DashboardLayoutGroup1.DashboardItem = Nothing
            Me.LayoutRoot = DashboardLayoutGroup1
            DashboardParameter1.Name = "parSafra"
            DashboardParameter1.Type = GetType(Short)
            DashboardParameter1.Value = CType(2015, Short)
            Me.Parameters.AddRange(New DevExpress.DashboardCommon.DashboardParameter() {DashboardParameter1})
            Me.Title.Text = "Dashboard"
            Me.Title.Visible = False
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents chartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents dataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource

#End Region
    End Class
End Namespace