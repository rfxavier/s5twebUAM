Namespace Win_Dashboards
    Partial Public Class dashCnEntCanaPalhaPorDia
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
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ColorSchemeEntry1 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry2 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries2 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim SimpleSeries3 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries4 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashCnEntCanaPalhaPorDia))
            Dim ColorSchemeEntry3 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry4 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim DataConnection1 As DevExpress.DataAccess.DataConnection = New DevExpress.DataAccess.DataConnection()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardParameter1 As DevExpress.DashboardCommon.DashboardParameter = New DevExpress.DashboardCommon.DashboardParameter()
            Dim DashboardParameter2 As DevExpress.DashboardCommon.DashboardParameter = New DevExpress.DashboardCommon.DashboardParameter()
            Me.chartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.rangeFilterDashboardItem1 = New DevExpress.DashboardCommon.RangeFilterDashboardItem()
            Me.dataSource1 = New DevExpress.DashboardCommon.DataSource()
            CType(Me.chartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.rangeFilterDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'chartDashboardItem1
            '
            Dimension1.DataMember = "DATA_ENTRADA"
            Dimension1.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayMonthYear
            Dimension1.Name = "Data Entrada"
            Measure1.DataMember = "DATA_ENTRADA_DATE"
            Measure1.SummaryType = DevExpress.DashboardCommon.SummaryType.Min
            Dimension1.SortByMeasure = Measure1
            Me.chartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension1})
            Me.chartDashboardItem1.AxisX.TitleVisible = False
            ColorSchemeEntry1.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(System.Drawing.Color.FromArgb(-3685058))
            ColorSchemeEntry1.DataSource = Me.dataSource1
            ColorSchemeEntry1.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("REALIZADO")})
            ColorSchemeEntry2.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(1)
            ColorSchemeEntry2.DataSource = Me.dataSource1
            ColorSchemeEntry2.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("PLANEJADO", DevExpress.DashboardCommon.SummaryType.Average)})
            Me.chartDashboardItem1.ColorScheme.AddRange(New DevExpress.DashboardCommon.ColorSchemeEntry() {ColorSchemeEntry1, ColorSchemeEntry2})
            Me.chartDashboardItem1.ComponentName = "chartDashboardItem1"
            Measure2.DataMember = "REALIZADO"
            Measure2.Name = "Realizado"
            Measure2.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure2.NumericFormat.IncludeGroupSeparator = True
            Measure2.NumericFormat.Precision = 0
            Measure2.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure3.DataMember = "PLANEJADO"
            Measure3.Name = "Planejado"
            Measure3.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure3.NumericFormat.IncludeGroupSeparator = True
            Measure3.NumericFormat.Precision = 0
            Measure3.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure3.SummaryType = DevExpress.DashboardCommon.SummaryType.Average
            Me.chartDashboardItem1.DataItemRepository.Clear()
            Me.chartDashboardItem1.DataItemRepository.Add(Measure2, "DataItem1")
            Me.chartDashboardItem1.DataItemRepository.Add(Measure3, "DataItem4")
            Me.chartDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem6")
            Me.chartDashboardItem1.DataItemRepository.Add(Measure1, "DataItem2")
            Me.chartDashboardItem1.DataSource = Me.dataSource1
            Me.chartDashboardItem1.HiddenMeasures.AddRange(New DevExpress.DashboardCommon.Measure() {Measure1})
            Me.chartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.chartDashboardItem1.Legend.Visible = False
            Me.chartDashboardItem1.Name = "Entradas de Cana por Hora"
            ChartPane1.Name = "Pane 1"
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.TitleVisible = True
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            SimpleSeries1.PointLabelOptions.OverlappingMode = DevExpress.DashboardCommon.PointLabelOverlappingMode.Reposition
            SimpleSeries1.PointLabelOptions.ShowPointLabels = True
            SimpleSeries1.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Area
            SimpleSeries1.ShowPointMarkers = True
            SimpleSeries1.AddDataItem("Value", Measure2)
            SimpleSeries2.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries2.AddDataItem("Value", Measure3)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1, SimpleSeries2})
            Me.chartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.chartDashboardItem1.ShowCaption = False
            '
            'rangeFilterDashboardItem1
            '
            Dimension2.DataMember = "DATA_ENTRADA_DATE"
            Dimension2.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayMonthYear
            Me.rangeFilterDashboardItem1.Argument = Dimension2
            Me.rangeFilterDashboardItem1.ComponentName = "rangeFilterDashboardItem1"
            Measure4.DataMember = "PLANEJADO"
            Measure4.SummaryType = DevExpress.DashboardCommon.SummaryType.Average
            Measure5.DataMember = "REALIZADO"
            Me.rangeFilterDashboardItem1.DataItemRepository.Clear()
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Measure4, "DataItem2")
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Dimension2, "DataItem0")
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Measure5, "DataItem1")
            Me.rangeFilterDashboardItem1.DataSource = Me.dataSource1
            Me.rangeFilterDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.rangeFilterDashboardItem1.Name = "Range Filter 1"
            SimpleSeries3.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries3.AddDataItem("Value", Measure5)
            SimpleSeries4.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries4.AddDataItem("Value", Measure4)
            Me.rangeFilterDashboardItem1.Series.AddRange(New DevExpress.DashboardCommon.SimpleSeries() {SimpleSeries3, SimpleSeries4})
            Me.rangeFilterDashboardItem1.ShowCaption = False
            '
            'dataSource1
            '
            Me.dataSource1.ComponentName = "dataSource1"
            Me.dataSource1.DataProviderSerializable = resources.GetString("dataSource1.DataProviderSerializable")
            Me.dataSource1.Name = "dsUAMColetaPalhaDia"
            '
            'dashCnEntCanaPalhaPorDia
            '
            ColorSchemeEntry3.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(System.Drawing.Color.FromArgb(-6066913))
            ColorSchemeEntry3.DataSource = Me.dataSource1
            ColorSchemeEntry3.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("REALIZADO")})
            ColorSchemeEntry4.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(1)
            ColorSchemeEntry4.DataSource = Me.dataSource1
            ColorSchemeEntry4.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("PLANEJADO", DevExpress.DashboardCommon.SummaryType.Average)})
            Me.ColorScheme.AddRange(New DevExpress.DashboardCommon.ColorSchemeEntry() {ColorSchemeEntry3, ColorSchemeEntry4})
            DataConnection1.Name = "localhost_Connection"
            DataConnection1.ParametersSerializable = resources.GetString("DataConnection1.ParametersSerializable")
            DataConnection1.ProviderKey = "Oracle"
            Me.DataConnections.Add(DataConnection1)
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.DataSource() {Me.dataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.chartDashboardItem1, Me.rangeFilterDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.chartDashboardItem1
            DashboardLayoutItem1.Weight = 84.981684981684978R
            DashboardLayoutItem2.DashboardItem = Me.rangeFilterDashboardItem1
            DashboardLayoutItem2.Weight = 15.018315018315018R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            Me.LayoutRoot = DashboardLayoutGroup1
            DashboardParameter1.Name = "parDataIni"
            DashboardParameter1.Type = GetType(String)
            DashboardParameter1.Value = "20150521"
            DashboardParameter2.Name = "parDataFim"
            DashboardParameter2.Type = GetType(String)
            DashboardParameter2.Value = "20150620"
            Me.Parameters.AddRange(New DevExpress.DashboardCommon.DashboardParameter() {DashboardParameter1, DashboardParameter2})
            Me.Title.ImageDataSerializable = ""
            Me.Title.Text = "Dashboard"
            Me.Title.Visible = False
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.rangeFilterDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents chartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents dataSource1 As DevExpress.DashboardCommon.DataSource
        Friend WithEvents rangeFilterDashboardItem1 As DevExpress.DashboardCommon.RangeFilterDashboardItem

#End Region
    End Class
End Namespace