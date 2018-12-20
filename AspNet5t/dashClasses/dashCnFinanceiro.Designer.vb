Namespace Win_Dashboards
    Partial Public Class dashCnFinanceiro
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
            Dim OracleConnectionParameters1 As DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters()
            Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashCnFinanceiro))
            Dim Dimension1 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn1 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn1 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn2 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn2 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Dimension3 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn3 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn3 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn4 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Dimension4 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim ColorSchemeEntry1 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim DimensionDefinition1 As DevExpress.DashboardCommon.DimensionDefinition = New DevExpress.DashboardCommon.DimensionDefinition("ENTRADA_SAIDA")
            Dim ColorSchemeDimensionKey1 As DevExpress.DashboardCommon.ColorSchemeDimensionKey = New DevExpress.DashboardCommon.ColorSchemeDimensionKey(DimensionDefinition1, "CONTAS A PAGAR")
            Dim ColorSchemeEntry2 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim DimensionDefinition2 As DevExpress.DashboardCommon.DimensionDefinition = New DevExpress.DashboardCommon.DimensionDefinition("ENTRADA_SAIDA")
            Dim ColorSchemeDimensionKey2 As DevExpress.DashboardCommon.ColorSchemeDimensionKey = New DevExpress.DashboardCommon.ColorSchemeDimensionKey(DimensionDefinition2, "CONTAS A RECEBER")
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure6 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries2 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension5 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure7 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure8 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim SimpleSeries3 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries4 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim DataConnection1 As DevExpress.DataAccess.DataConnection = New DevExpress.DataAccess.DataConnection()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup3 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem4 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.dashboardSqlDataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.gridDashboardItem1 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.gridDashboardItem2 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.chartDashboardItem2 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.rangeFilterDashboardItem1 = New DevExpress.DashboardCommon.RangeFilterDashboardItem()
            CType(Me.dashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chartDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.rangeFilterDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'dashboardSqlDataSource1
            '
            Me.dashboardSqlDataSource1.ComponentName = "dashboardSqlDataSource1"
            Me.dashboardSqlDataSource1.ConnectionName = "localhost_BI4T_Connection"
            OracleConnectionParameters1.ServerName = "localhost"
            Me.dashboardSqlDataSource1.ConnectionParameters = OracleConnectionParameters1
            Me.dashboardSqlDataSource1.Name = "SQL Data Source 1"
            CustomSqlQuery1.Name = "FINANCEIRO"
            CustomSqlQuery1.Sql = resources.GetString("CustomSqlQuery1.Sql")
            Me.dashboardSqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery1})
            Me.dashboardSqlDataSource1.ResultSchemaSerializable = resources.GetString("dashboardSqlDataSource1.ResultSchemaSerializable")
            '
            'gridDashboardItem1
            '
            Dimension1.DataMember = "ORIGEM"
            Dimension1.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn1.Name = " "
            GridDimensionColumn1.Weight = 107.25R
            GridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn1.AddDataItem("Dimension", Dimension1)
            Measure1.DataMember = "CONTAS_A_RECEBER"
            GridMeasureColumn1.Name = "Valor Contas a Receber"
            GridMeasureColumn1.Weight = 57.375R
            GridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn1.AddDataItem("Measure", Measure1)
            Measure2.DataMember = "CONTAS_A_PAGAR"
            GridMeasureColumn2.Name = "Valor Contas a Pagar"
            GridMeasureColumn2.Weight = 60.375R
            GridMeasureColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn2.AddDataItem("Measure", Measure2)
            Me.gridDashboardItem1.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn1, GridMeasureColumn1, GridMeasureColumn2})
            Me.gridDashboardItem1.ComponentName = "gridDashboardItem1"
            Me.gridDashboardItem1.DataItemRepository.Clear()
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.gridDashboardItem1.DataItemRepository.Add(Measure1, "DataItem2")
            Me.gridDashboardItem1.DataItemRepository.Add(Measure2, "DataItem3")
            Me.gridDashboardItem1.DataMember = "FINANCEIRO"
            Me.gridDashboardItem1.DataSource = Me.dashboardSqlDataSource1
            Me.gridDashboardItem1.GridOptions.ColumnWidthMode = DevExpress.DashboardCommon.GridColumnWidthMode.Manual
            Me.gridDashboardItem1.GridOptions.EnableBandedRows = True
            Me.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.gridDashboardItem1.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.gridDashboardItem1.Name = "Origem"
            Me.gridDashboardItem1.ShowCaption = True
            '
            'gridDashboardItem2
            '
            Dimension2.DataMember = "DESCRICAO"
            Dimension2.Name = "Descrição"
            GridDimensionColumn2.Name = "Descrição Favorecido"
            GridDimensionColumn2.Weight = 140.23969019074698R
            GridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn2.AddDataItem("Dimension", Dimension2)
            Dimension3.DataMember = "PAGAMENTO"
            Dimension3.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayMonthYear
            Dimension3.Name = "Data do Pagamento"
            GridDimensionColumn3.Name = "Data do Pagamento"
            GridDimensionColumn3.Weight = 99.944382647386R
            GridDimensionColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn3.AddDataItem("Dimension", Dimension3)
            Measure3.DataMember = "CONTAS_A_RECEBER"
            GridMeasureColumn3.Name = "Valor Contas a Receber"
            GridMeasureColumn3.Weight = 43.751658221068695R
            GridMeasureColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn3.AddDataItem("Measure", Measure3)
            Measure4.DataMember = "CONTAS_A_PAGAR"
            GridMeasureColumn4.Name = "Valor Contas a Pagar"
            GridMeasureColumn4.Weight = 50.392534915338054R
            GridMeasureColumn4.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn4.AddDataItem("Measure", Measure4)
            Me.gridDashboardItem2.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn2, GridDimensionColumn3, GridMeasureColumn3, GridMeasureColumn4})
            Me.gridDashboardItem2.ComponentName = "gridDashboardItem2"
            Me.gridDashboardItem2.DataItemRepository.Clear()
            Me.gridDashboardItem2.DataItemRepository.Add(Dimension3, "DataItem4")
            Me.gridDashboardItem2.DataItemRepository.Add(Dimension2, "DataItem1")
            Me.gridDashboardItem2.DataItemRepository.Add(Measure3, "DataItem3")
            Me.gridDashboardItem2.DataItemRepository.Add(Measure4, "DataItem5")
            Me.gridDashboardItem2.DataMember = "FINANCEIRO"
            Me.gridDashboardItem2.DataSource = Me.dashboardSqlDataSource1
            Me.gridDashboardItem2.GridOptions.ColumnWidthMode = DevExpress.DashboardCommon.GridColumnWidthMode.Manual
            Me.gridDashboardItem2.InteractivityOptions.IgnoreMasterFilters = False
            Me.gridDashboardItem2.InteractivityOptions.IsDrillDownEnabled = True
            Me.gridDashboardItem2.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.gridDashboardItem2.Name = "Sumário/Detalhamento"
            Me.gridDashboardItem2.ShowCaption = True
            '
            'chartDashboardItem2
            '
            Dimension4.DataMember = "PAGAMENTO"
            Dimension4.DateTimeFormat.MonthFormat = DevExpress.DashboardCommon.MonthFormat.Abbreviated
            Dimension4.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Dimension4.Name = "Data do Pagamento"
            Dimension4.TopNOptions.Count = 12
            Me.chartDashboardItem2.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension4})
            Me.chartDashboardItem2.AxisX.TitleVisible = False
            Me.chartDashboardItem2.ColoringOptions.UseGlobalColors = False
            ColorSchemeEntry1.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(System.Drawing.Color.FromArgb(-10515563))
            ColorSchemeEntry1.DataMember = "FINANCEIRO"
            ColorSchemeEntry1.DataSource = Me.dashboardSqlDataSource1
            ColorSchemeEntry1.DimensionKeys.AddRange(New DevExpress.DashboardCommon.ColorSchemeDimensionKey() {ColorSchemeDimensionKey1})
            ColorSchemeEntry2.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(System.Drawing.Color.FromArgb(-4567727))
            ColorSchemeEntry2.DataMember = "FINANCEIRO"
            ColorSchemeEntry2.DataSource = Me.dashboardSqlDataSource1
            ColorSchemeEntry2.DimensionKeys.AddRange(New DevExpress.DashboardCommon.ColorSchemeDimensionKey() {ColorSchemeDimensionKey2})
            Me.chartDashboardItem2.ColorScheme.AddRange(New DevExpress.DashboardCommon.ColorSchemeEntry() {ColorSchemeEntry1, ColorSchemeEntry2})
            Me.chartDashboardItem2.ComponentName = "chartDashboardItem2"
            Measure5.DataMember = "CONTAS_A_RECEBER"
            Measure5.Name = "Contas a Receber"
            Measure6.DataMember = "CONTAS_A_PAGAR"
            Measure6.Name = "Contas a Pagar"
            Me.chartDashboardItem2.DataItemRepository.Clear()
            Me.chartDashboardItem2.DataItemRepository.Add(Dimension4, "DataItem0")
            Me.chartDashboardItem2.DataItemRepository.Add(Measure5, "DataItem2")
            Me.chartDashboardItem2.DataItemRepository.Add(Measure6, "DataItem3")
            Me.chartDashboardItem2.DataMember = "FINANCEIRO"
            Me.chartDashboardItem2.DataSource = Me.dashboardSqlDataSource1
            Me.chartDashboardItem2.InteractivityOptions.IgnoreMasterFilters = False
            Me.chartDashboardItem2.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.chartDashboardItem2.Name = "Total Valor"
            ChartPane1.Name = "Pane 1"
            ChartPane1.PrimaryAxisY.AlwaysShowZeroLevel = False
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.TitleVisible = False
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            SimpleSeries1.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries1.AddDataItem("Value", Measure5)
            SimpleSeries2.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries2.AddDataItem("Value", Measure6)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1, SimpleSeries2})
            Me.chartDashboardItem2.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.chartDashboardItem2.ShowCaption = True
            '
            'rangeFilterDashboardItem1
            '
            Dimension5.DataMember = "PAGAMENTO"
            Dimension5.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayMonthYear
            Me.rangeFilterDashboardItem1.Argument = Dimension5
            Me.rangeFilterDashboardItem1.ComponentName = "rangeFilterDashboardItem1"
            Measure7.DataMember = "CONTAS_A_RECEBER"
            Measure8.DataMember = "CONTAS_A_PAGAR"
            Me.rangeFilterDashboardItem1.DataItemRepository.Clear()
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Dimension5, "DataItem0")
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Measure7, "DataItem1")
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Measure8, "DataItem4")
            Me.rangeFilterDashboardItem1.DataMember = "FINANCEIRO"
            Me.rangeFilterDashboardItem1.DataSource = Me.dashboardSqlDataSource1
            Me.rangeFilterDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.rangeFilterDashboardItem1.Name = "Período por data de pagamento"
            SimpleSeries3.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Area
            SimpleSeries3.AddDataItem("Value", Measure7)
            SimpleSeries4.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Area
            SimpleSeries4.AddDataItem("Value", Measure8)
            Me.rangeFilterDashboardItem1.Series.AddRange(New DevExpress.DashboardCommon.SimpleSeries() {SimpleSeries3, SimpleSeries4})
            Me.rangeFilterDashboardItem1.ShowCaption = True
            '
            'dashCnFinanceiro
            '
            DataConnection1.Name = "localhost_base5tConnection"
            DataConnection1.ParametersSerializable = resources.GetString("DataConnection1.ParametersSerializable")
            DataConnection1.ProviderKey = "MySql"
            Me.DataConnections.Add(DataConnection1)
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.dashboardSqlDataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.gridDashboardItem1, Me.gridDashboardItem2, Me.chartDashboardItem2, Me.rangeFilterDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.gridDashboardItem1
            DashboardLayoutItem1.Weight = 45.648854961832058R
            DashboardLayoutItem2.DashboardItem = Me.gridDashboardItem2
            DashboardLayoutItem2.Weight = 54.351145038167942R
            DashboardLayoutGroup3.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2})
            DashboardLayoutGroup3.DashboardItem = Nothing
            DashboardLayoutGroup3.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup3.Weight = 41.974479516454R
            DashboardLayoutItem3.DashboardItem = Me.chartDashboardItem2
            DashboardLayoutItem3.Weight = 58.025520483546R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup3, DashboardLayoutItem3})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 79.0108564535585R
            DashboardLayoutItem4.DashboardItem = Me.rangeFilterDashboardItem1
            DashboardLayoutItem4.Weight = 20.989143546441497R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup2, DashboardLayoutItem4})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "Dashboard Financeiro"
            CType(Me.dashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chartDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.rangeFilterDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents gridDashboardItem1 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents dashboardSqlDataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents gridDashboardItem2 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents chartDashboardItem2 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents rangeFilterDashboardItem1 As DevExpress.DashboardCommon.RangeFilterDashboardItem

#End Region
    End Class
End Namespace