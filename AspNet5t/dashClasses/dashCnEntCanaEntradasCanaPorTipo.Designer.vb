Namespace Win_Dashboards
    Partial Public Class dashCnEntCanaEntradasCanaPorTipo
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
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridDimensionColumn1 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Dimension3 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn2 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim GridMeasureColumn1 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Dimension4 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Dimension5 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Card1 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim Dimension6 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension7 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Dimension8 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim SimpleSeries2 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim CalculatedField1 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim OracleConnectionParameters1 As DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters()
            Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashCnEntCanaEntradasCanaPorTipo))
            Dim ColorSchemeEntry1 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim DimensionDefinition1 As DevExpress.DashboardCommon.DimensionDefinition = New DevExpress.DashboardCommon.DimensionDefinition("DESCTIPO")
            Dim ColorSchemeDimensionKey1 As DevExpress.DashboardCommon.ColorSchemeDimensionKey = New DevExpress.DashboardCommon.ColorSchemeDimensionKey(DimensionDefinition1, "PROPRIA")
            Dim ColorSchemeEntry2 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim DimensionDefinition2 As DevExpress.DashboardCommon.DimensionDefinition = New DevExpress.DashboardCommon.DimensionDefinition("DESCTIPO")
            Dim ColorSchemeDimensionKey2 As DevExpress.DashboardCommon.ColorSchemeDimensionKey = New DevExpress.DashboardCommon.ColorSchemeDimensionKey(DimensionDefinition2, "FORNECEDORES")
            Dim DataConnection1 As DevExpress.DataAccess.DataConnection = New DevExpress.DataAccess.DataConnection()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup3 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem4 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem5 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.pieDashboardItem1 = New DevExpress.DashboardCommon.PieDashboardItem()
            Me.gridDashboardItem1 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.chartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.cardDashboardItem1 = New DevExpress.DashboardCommon.CardDashboardItem()
            Me.rangeFilterDashboardItem1 = New DevExpress.DashboardCommon.RangeFilterDashboardItem()
            Me.dataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            CType(Me.pieDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cardDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.rangeFilterDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'pieDashboardItem1
            '
            Dimension1.DataMember = "DESCTIPO"
            Dimension1.Name = "Tipo"
            Me.pieDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension1})
            Me.pieDashboardItem1.ComponentName = "pieDashboardItem1"
            Measure1.DataMember = "QT_TON_ENTREGUE_REAL"
            Measure1.Name = "Toneladas"
            Measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure1.NumericFormat.IncludeGroupSeparator = True
            Measure1.NumericFormat.Precision = 0
            Measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Me.pieDashboardItem1.DataItemRepository.Clear()
            Me.pieDashboardItem1.DataItemRepository.Add(Measure1, "DataItem2")
            Me.pieDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem1")
            Me.pieDashboardItem1.DataMember = "dsUAMOraXE"
            Me.pieDashboardItem1.DataSource = Me.dataSource1
            Me.pieDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.pieDashboardItem1.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.pieDashboardItem1.Name = "Entradas Por Origem"
            Me.pieDashboardItem1.PieType = DevExpress.DashboardCommon.PieType.Donut
            Me.pieDashboardItem1.ShowCaption = True
            Me.pieDashboardItem1.ShowPieCaptions = False
            Me.pieDashboardItem1.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure1})
            '
            'gridDashboardItem1
            '
            Dimension2.DataMember = "DESCMUNI"
            Dimension2.Name = "Município"
            Measure2.DataMember = "QT_TON_ENTREGUE_REAL"
            Measure2.Name = "Toneladas"
            Measure2.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Dimension2.SortByMeasure = Measure2
            Dimension2.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn1.AddDataItem("Dimension", Dimension2)
            Dimension3.DataMember = "propDESCCODcalc"
            Dimension3.Name = "Propriedade"
            Dimension3.SortByMeasure = Measure2
            Dimension3.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn2.AddDataItem("Dimension", Dimension3)
            GridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn1.AddDataItem("Measure", Measure2)
            Me.gridDashboardItem1.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn1, GridDimensionColumn2, GridMeasureColumn1})
            Me.gridDashboardItem1.ComponentName = "gridDashboardItem1"
            Me.gridDashboardItem1.DataItemRepository.Clear()
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension2, "DataItem0")
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension3, "DataItem2")
            Me.gridDashboardItem1.DataItemRepository.Add(Measure2, "DataItem3")
            Me.gridDashboardItem1.DataMember = "dsUAMOraXE"
            Me.gridDashboardItem1.DataSource = Me.dataSource1
            Me.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.gridDashboardItem1.InteractivityOptions.IsDrillDownEnabled = True
            Me.gridDashboardItem1.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.gridDashboardItem1.Name = "Municípios e Propriedades"
            Me.gridDashboardItem1.ShowCaption = True
            '
            'chartDashboardItem1
            '
            Dimension4.DataMember = "DT_MOAGEM"
            Dimension4.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.Month
            Dimension4.Name = "Mês / Ano"
            Me.chartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension4})
            Me.chartDashboardItem1.AxisX.TitleVisible = False
            Me.chartDashboardItem1.ComponentName = "chartDashboardItem1"
            Measure3.DataMember = "QT_TON_ENTREGUE_REAL"
            Measure3.Name = "Toneladas"
            Measure3.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure3.NumericFormat.IncludeGroupSeparator = True
            Measure3.NumericFormat.Precision = 0
            Measure3.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Dimension5.DataMember = "DESCTIPO"
            Dimension5.Name = "Tipo"
            Me.chartDashboardItem1.DataItemRepository.Clear()
            Me.chartDashboardItem1.DataItemRepository.Add(Measure3, "DataItem3")
            Me.chartDashboardItem1.DataItemRepository.Add(Dimension4, "DataItem1")
            Me.chartDashboardItem1.DataItemRepository.Add(Dimension5, "DataItem2")
            Me.chartDashboardItem1.DataMember = "dsUAMOraXE"
            Me.chartDashboardItem1.DataSource = Me.dataSource1
            Me.chartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.chartDashboardItem1.Name = "Entradas Mensais Por Origem"
            ChartPane1.Name = "Pane 1"
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.TitleVisible = True
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            SimpleSeries1.AddDataItem("Value", Measure3)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1})
            Me.chartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.chartDashboardItem1.SeriesDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension5})
            Me.chartDashboardItem1.ShowCaption = True
            '
            'cardDashboardItem1
            '
            Measure4.DataMember = "QT_TON_ENTREGUE_REAL"
            Measure4.Name = "Total Toneladas"
            Measure4.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Card1.AddDataItem("ActualValue", Measure4)
            Me.cardDashboardItem1.Cards.AddRange(New DevExpress.DashboardCommon.Card() {Card1})
            Me.cardDashboardItem1.ComponentName = "cardDashboardItem1"
            Dimension6.DataMember = "DT_MOAGEM"
            Dimension6.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Me.cardDashboardItem1.DataItemRepository.Clear()
            Me.cardDashboardItem1.DataItemRepository.Add(Dimension6, "DataItem1")
            Me.cardDashboardItem1.DataItemRepository.Add(Measure4, "DataItem0")
            Me.cardDashboardItem1.DataMember = "dsUAMOraXE"
            Me.cardDashboardItem1.DataSource = Me.dataSource1
            Me.cardDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.cardDashboardItem1.Name = "Total Entradas"
            Me.cardDashboardItem1.ShowCaption = False
            Me.cardDashboardItem1.SparklineArgument = Dimension6
            '
            'rangeFilterDashboardItem1
            '
            Dimension7.DataMember = "DT_MOAGEM"
            Dimension7.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayMonthYear
            Dimension7.Name = "Dia / Mês / Ano"
            Me.rangeFilterDashboardItem1.Argument = Dimension7
            Me.rangeFilterDashboardItem1.ComponentName = "rangeFilterDashboardItem1"
            Measure5.DataMember = "QT_TON_ENTREGUE_REAL"
            Measure5.Name = "Toneladas"
            Dimension8.DataMember = "DESCTIPO"
            Dimension8.Name = "Tipo"
            Me.rangeFilterDashboardItem1.DataItemRepository.Clear()
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Dimension7, "DataItem0")
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Measure5, "DataItem1")
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Dimension8, "DataItem2")
            Me.rangeFilterDashboardItem1.DataMember = "dsUAMOraXE"
            Me.rangeFilterDashboardItem1.DataSource = Me.dataSource1
            Me.rangeFilterDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.rangeFilterDashboardItem1.Name = "Range Filter 1"
            SimpleSeries2.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Area
            SimpleSeries2.AddDataItem("Value", Measure5)
            Me.rangeFilterDashboardItem1.Series.AddRange(New DevExpress.DashboardCommon.SimpleSeries() {SimpleSeries2})
            Me.rangeFilterDashboardItem1.SeriesDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension8})
            Me.rangeFilterDashboardItem1.ShowCaption = False
            '
            'dataSource1
            '
            CalculatedField1.DataMember = "dsUAMOraXE"
            CalculatedField1.Expression = "Concat([DS_NOME_PROPRIEDADE], ' ( ', ToStr([PROP_CODIGO]), ' )')"
            CalculatedField1.Name = "propDESCCODcalc"
            Me.dataSource1.CalculatedFields.AddRange(New DevExpress.DashboardCommon.CalculatedField() {CalculatedField1})
            Me.dataSource1.ComponentName = "dataSource1"
            Me.dataSource1.ConnectionName = "localhost_Connection"
            OracleConnectionParameters1.ServerName = "localhost"
            Me.dataSource1.ConnectionParameters = OracleConnectionParameters1
            Me.dataSource1.Name = "dsUAMOraXE"
            CustomSqlQuery1.Name = "dsUAMOraXE"
            CustomSqlQuery1.Sql = resources.GetString("CustomSqlQuery1.Sql")
            Me.dataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery1})
            Me.dataSource1.ResultSchemaSerializable = resources.GetString("dataSource1.ResultSchemaSerializable")
            '
            'dashCnEntCanaEntradasCanaPorTipo
            '
            ColorSchemeEntry1.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(10)
            ColorSchemeEntry1.DataMember = "dsUAMOraXE"
            ColorSchemeEntry1.DataSource = Me.dataSource1
            ColorSchemeEntry1.DimensionKeys.AddRange(New DevExpress.DashboardCommon.ColorSchemeDimensionKey() {ColorSchemeDimensionKey1})
            ColorSchemeEntry2.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(19)
            ColorSchemeEntry2.DataMember = "dsUAMOraXE"
            ColorSchemeEntry2.DataSource = Me.dataSource1
            ColorSchemeEntry2.DimensionKeys.AddRange(New DevExpress.DashboardCommon.ColorSchemeDimensionKey() {ColorSchemeDimensionKey2})
            Me.ColorScheme.AddRange(New DevExpress.DashboardCommon.ColorSchemeEntry() {ColorSchemeEntry1, ColorSchemeEntry2})
            DataConnection1.Name = "localhost_Connection"
            DataConnection1.ParametersSerializable = resources.GetString("DataConnection1.ParametersSerializable")
            DataConnection1.ProviderKey = "Oracle"
            Me.DataConnections.Add(DataConnection1)
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.dataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.pieDashboardItem1, Me.gridDashboardItem1, Me.chartDashboardItem1, Me.cardDashboardItem1, Me.rangeFilterDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.gridDashboardItem1
            DashboardLayoutItem1.Weight = 29.62566844919786R
            DashboardLayoutItem2.DashboardItem = Me.pieDashboardItem1
            DashboardLayoutItem2.Weight = 46.63101604278075R
            DashboardLayoutItem3.DashboardItem = Me.cardDashboardItem1
            DashboardLayoutItem3.Weight = 23.743315508021389R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2, DashboardLayoutItem3})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 41.453831041257367R
            DashboardLayoutItem4.DashboardItem = Me.chartDashboardItem1
            DashboardLayoutItem4.Weight = 71.812080536912745R
            DashboardLayoutItem5.DashboardItem = Me.rangeFilterDashboardItem1
            DashboardLayoutItem5.Weight = 28.187919463087248R
            DashboardLayoutGroup3.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem4, DashboardLayoutItem5})
            DashboardLayoutGroup3.DashboardItem = Nothing
            DashboardLayoutGroup3.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup3.Weight = 58.546168958742633R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup2, DashboardLayoutGroup3})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "Entradas Cana"
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pieDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cardDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.rangeFilterDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents pieDashboardItem1 As DevExpress.DashboardCommon.PieDashboardItem
        Friend WithEvents dataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents gridDashboardItem1 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents chartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents cardDashboardItem1 As DevExpress.DashboardCommon.CardDashboardItem
        Friend WithEvents rangeFilterDashboardItem1 As DevExpress.DashboardCommon.RangeFilterDashboardItem

#End Region
    End Class
End Namespace