Namespace Win_Dashboards
    Partial Public Class dashLogUsuarios
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
            Dim GridDimensionColumn1 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim GridMeasureColumn1 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridDimensionColumn2 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim GridMeasureColumn2 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Dimension3 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension4 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridDimensionColumn3 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim GridMeasureColumn3 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Dimension5 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries2 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension6 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure6 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane2 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries3 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim MySqlConnectionParameters1 As DevExpress.DataAccess.ConnectionParameters.MySqlConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.MySqlConnectionParameters()
            Dim TableQuery1 As DevExpress.DataAccess.Sql.TableQuery = New DevExpress.DataAccess.Sql.TableQuery()
            Dim QueryParameter1 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
            Dim QueryParameter2 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
            Dim TableInfo1 As DevExpress.DataAccess.Sql.TableInfo = New DevExpress.DataAccess.Sql.TableInfo()
            Dim ColumnInfo1 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
            Dim ColumnInfo2 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
            Dim ColumnInfo3 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
            Dim ColumnInfo4 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
            Dim ColumnInfo5 As DevExpress.DataAccess.Sql.ColumnInfo = New DevExpress.DataAccess.Sql.ColumnInfo()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashLogUsuarios))
            Dim DataConnection1 As DevExpress.DataAccess.DataConnection = New DevExpress.DataAccess.DataConnection()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup3 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem4 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup4 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem5 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem6 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardParameter1 As DevExpress.DashboardCommon.DashboardParameter = New DevExpress.DashboardCommon.DashboardParameter()
            Dim DashboardParameter2 As DevExpress.DashboardCommon.DashboardParameter = New DevExpress.DashboardCommon.DashboardParameter()
            Me.gridDashboardItem1 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.gridDashboardItem2 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.rangeFilterDashboardItem1 = New DevExpress.DashboardCommon.RangeFilterDashboardItem()
            Me.gridDashboardItem3 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.chartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.chartDashboardItem2 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.dataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.rangeFilterDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridDashboardItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chartDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'gridDashboardItem1
            '
            Dimension1.DataMember = "pLoginUsuario"
            Dimension1.Name = "Usuário"
            Measure1.DataMember = "pDescription"
            Measure1.Name = "Acessos"
            Measure1.SummaryType = DevExpress.DashboardCommon.SummaryType.Count
            Dimension1.SortByMeasure = Measure1
            Dimension1.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn1.Name = "Usuário"
            GridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn1.AddDataItem("Dimension", Dimension1)
            GridMeasureColumn1.Name = "Nº Acessos"
            GridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn1.AddDataItem("Measure", Measure1)
            Me.gridDashboardItem1.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn1, GridMeasureColumn1})
            Me.gridDashboardItem1.ComponentName = "gridDashboardItem1"
            Me.gridDashboardItem1.DataItemRepository.Clear()
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.gridDashboardItem1.DataItemRepository.Add(Measure1, "DataItem1")
            Me.gridDashboardItem1.DataMember = "dsLog"
            Me.gridDashboardItem1.DataSource = Me.dataSource1
            Me.gridDashboardItem1.GridOptions.EnableBandedRows = True
            Me.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.gridDashboardItem1.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.gridDashboardItem1.Name = "Por Usuário"
            Me.gridDashboardItem1.ShowCaption = True
            '
            'gridDashboardItem2
            '
            Dimension2.DataMember = "pNode"
            Dimension2.Name = "Cenário"
            Measure2.DataMember = "pDescription"
            Measure2.Name = "Acessos"
            Measure2.SummaryType = DevExpress.DashboardCommon.SummaryType.Count
            Dimension2.SortByMeasure = Measure2
            Dimension2.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn2.Name = "Cenário"
            GridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn2.AddDataItem("Dimension", Dimension2)
            GridMeasureColumn2.Name = "Nº Acessos"
            GridMeasureColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn2.AddDataItem("Measure", Measure2)
            Me.gridDashboardItem2.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn2, GridMeasureColumn2})
            Me.gridDashboardItem2.ComponentName = "gridDashboardItem2"
            Me.gridDashboardItem2.DataItemRepository.Clear()
            Me.gridDashboardItem2.DataItemRepository.Add(Measure2, "DataItem1")
            Me.gridDashboardItem2.DataItemRepository.Add(Dimension2, "DataItem2")
            Me.gridDashboardItem2.DataMember = "dsLog"
            Me.gridDashboardItem2.DataSource = Me.dataSource1
            Me.gridDashboardItem2.GridOptions.EnableBandedRows = True
            Me.gridDashboardItem2.InteractivityOptions.IgnoreMasterFilters = False
            Me.gridDashboardItem2.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.gridDashboardItem2.Name = "Por Cenário"
            Me.gridDashboardItem2.ShowCaption = True
            '
            'rangeFilterDashboardItem1
            '
            Dimension3.DataMember = "pDataHora"
            Dimension3.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayMonthYear
            Me.rangeFilterDashboardItem1.Argument = Dimension3
            Me.rangeFilterDashboardItem1.ComponentName = "rangeFilterDashboardItem1"
            Measure3.DataMember = "pDescription"
            Measure3.SummaryType = DevExpress.DashboardCommon.SummaryType.Count
            Me.rangeFilterDashboardItem1.DataItemRepository.Clear()
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Measure3, "DataItem0")
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Dimension3, "DataItem1")
            Me.rangeFilterDashboardItem1.DataMember = "dsLog"
            Me.rangeFilterDashboardItem1.DataSource = Me.dataSource1
            Me.rangeFilterDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.rangeFilterDashboardItem1.Name = "Range Filter 1"
            SimpleSeries1.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries1.AddDataItem("Value", Measure3)
            Me.rangeFilterDashboardItem1.Series.AddRange(New DevExpress.DashboardCommon.SimpleSeries() {SimpleSeries1})
            Me.rangeFilterDashboardItem1.ShowCaption = False
            '
            'gridDashboardItem3
            '
            Dimension4.DataMember = "pDescription"
            Dimension4.Name = "Aplicação"
            Measure4.DataMember = "pDescription"
            Measure4.Name = "Acessos"
            Measure4.SummaryType = DevExpress.DashboardCommon.SummaryType.Count
            Dimension4.SortByMeasure = Measure4
            Dimension4.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn3.Name = "Aplicação"
            GridDimensionColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn3.AddDataItem("Dimension", Dimension4)
            GridMeasureColumn3.Name = "Nº Acessos"
            GridMeasureColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn3.AddDataItem("Measure", Measure4)
            Me.gridDashboardItem3.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn3, GridMeasureColumn3})
            Me.gridDashboardItem3.ComponentName = "gridDashboardItem3"
            Me.gridDashboardItem3.DataItemRepository.Clear()
            Me.gridDashboardItem3.DataItemRepository.Add(Dimension4, "DataItem0")
            Me.gridDashboardItem3.DataItemRepository.Add(Measure4, "DataItem1")
            Me.gridDashboardItem3.DataMember = "dsLog"
            Me.gridDashboardItem3.DataSource = Me.dataSource1
            Me.gridDashboardItem3.GridOptions.EnableBandedRows = True
            Me.gridDashboardItem3.InteractivityOptions.IgnoreMasterFilters = False
            Me.gridDashboardItem3.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.gridDashboardItem3.Name = "Por Aplicação"
            Me.gridDashboardItem3.ShowCaption = True
            '
            'chartDashboardItem1
            '
            Dimension5.DataMember = "pDataHora"
            Dimension5.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.Hour
            Dimension5.Name = "Hora"
            Me.chartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension5})
            Me.chartDashboardItem1.AxisX.TitleVisible = False
            Me.chartDashboardItem1.ComponentName = "chartDashboardItem1"
            Measure5.DataMember = "pDescription"
            Measure5.SummaryType = DevExpress.DashboardCommon.SummaryType.Count
            Me.chartDashboardItem1.DataItemRepository.Clear()
            Me.chartDashboardItem1.DataItemRepository.Add(Dimension5, "DataItem0")
            Me.chartDashboardItem1.DataItemRepository.Add(Measure5, "DataItem2")
            Me.chartDashboardItem1.DataMember = "dsLog"
            Me.chartDashboardItem1.DataSource = Me.dataSource1
            Me.chartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.chartDashboardItem1.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.chartDashboardItem1.Legend.Visible = False
            Me.chartDashboardItem1.Name = "Por Hora"
            ChartPane1.Name = "Pane 1"
            ChartPane1.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.TitleVisible = True
            ChartPane1.PrimaryAxisY.Visible = False
            ChartPane1.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            SimpleSeries2.Name = "Nº Acessos"
            SimpleSeries2.AddDataItem("Value", Measure5)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries2})
            Me.chartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.chartDashboardItem1.Rotated = True
            Me.chartDashboardItem1.ShowCaption = True
            '
            'chartDashboardItem2
            '
            Dimension6.DataMember = "pDataHora"
            Dimension6.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayMonthYear
            Dimension6.Name = "Dia"
            Me.chartDashboardItem2.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension6})
            Me.chartDashboardItem2.AxisX.TitleVisible = False
            Me.chartDashboardItem2.ComponentName = "chartDashboardItem2"
            Measure6.DataMember = "pDescription"
            Measure6.Name = "Nº Acessos"
            Measure6.SummaryType = DevExpress.DashboardCommon.SummaryType.Count
            Me.chartDashboardItem2.DataItemRepository.Clear()
            Me.chartDashboardItem2.DataItemRepository.Add(Measure6, "DataItem0")
            Me.chartDashboardItem2.DataItemRepository.Add(Dimension6, "DataItem2")
            Me.chartDashboardItem2.DataMember = "dsLog"
            Me.chartDashboardItem2.DataSource = Me.dataSource1
            Me.chartDashboardItem2.InteractivityOptions.IgnoreMasterFilters = False
            Me.chartDashboardItem2.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.chartDashboardItem2.Legend.Visible = False
            Me.chartDashboardItem2.Name = "Por Dia"
            ChartPane2.Name = "Pane 1"
            ChartPane2.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane2.PrimaryAxisY.ShowGridLines = True
            ChartPane2.PrimaryAxisY.TitleVisible = True
            ChartPane2.PrimaryAxisY.Visible = False
            ChartPane2.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane2.SecondaryAxisY.ShowGridLines = False
            ChartPane2.SecondaryAxisY.TitleVisible = True
            SimpleSeries3.Name = "Nº Acessos"
            SimpleSeries3.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries3.AddDataItem("Value", Measure6)
            ChartPane2.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries3})
            Me.chartDashboardItem2.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane2})
            Me.chartDashboardItem2.ShowCaption = True
            '
            'dataSource1
            '
            Me.dataSource1.ComponentName = "dataSource1"
            Me.dataSource1.ConnectionName = "localhost_s5tuamConnection"
            MySqlConnectionParameters1.DatabaseName = "s5tuam"
            MySqlConnectionParameters1.ServerName = "localhost"
            Me.dataSource1.ConnectionParameters = MySqlConnectionParameters1
            Me.dataSource1.Name = "dsLog"
            TableQuery1.FilterString = "[vwebsitemaplogacessousuariosviewraw.pDataHora] Between(?parDataIni, ?parDataFim)" & _
        ""
            TableQuery1.Name = "dsLog"
            QueryParameter1.Name = "parDataIni"
            QueryParameter1.Type = GetType(DevExpress.DataAccess.Expression)
            QueryParameter1.Value = New DevExpress.DataAccess.Expression("[Parameters.parDataIni]", GetType(Date))
            QueryParameter2.Name = "parDataFim"
            QueryParameter2.Type = GetType(DevExpress.DataAccess.Expression)
            QueryParameter2.Value = New DevExpress.DataAccess.Expression("[Parameters.parDataFim]", GetType(Date))
            TableQuery1.Parameters.Add(QueryParameter1)
            TableQuery1.Parameters.Add(QueryParameter2)
            TableInfo1.Name = "vwebsitemaplogacessousuariosviewraw"
            ColumnInfo1.Name = "pDataHora"
            ColumnInfo2.Name = "pLoginUsuario"
            ColumnInfo3.Name = "pObsLog"
            ColumnInfo4.Name = "pNode"
            ColumnInfo5.Name = "pDescription"
            TableInfo1.SelectedColumns.AddRange(New DevExpress.DataAccess.Sql.ColumnInfo() {ColumnInfo1, ColumnInfo2, ColumnInfo3, ColumnInfo4, ColumnInfo5})
            TableQuery1.Tables.AddRange(New DevExpress.DataAccess.Sql.TableInfo() {TableInfo1})
            Me.dataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {TableQuery1})
            Me.dataSource1.ResultSchemaSerializable = resources.GetString("dataSource1.ResultSchemaSerializable")
            '
            'dashLogUsuarios
            '
            DataConnection1.Name = "localhost_s5tuamConnection"
            DataConnection1.ParametersSerializable = resources.GetString("DataConnection1.ParametersSerializable")
            DataConnection1.ProviderKey = "MySql"
            Me.DataConnections.Add(DataConnection1)
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.dataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.gridDashboardItem1, Me.gridDashboardItem2, Me.rangeFilterDashboardItem1, Me.gridDashboardItem3, Me.chartDashboardItem1, Me.chartDashboardItem2})
            DashboardLayoutItem1.DashboardItem = Me.gridDashboardItem1
            DashboardLayoutItem1.Weight = 26.4733395696913R
            DashboardLayoutItem2.DashboardItem = Me.gridDashboardItem2
            DashboardLayoutItem2.Weight = 27.167630057803468R
            DashboardLayoutItem3.DashboardItem = Me.chartDashboardItem1
            DashboardLayoutItem3.Weight = 72.832369942196536R
            DashboardLayoutGroup3.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem2, DashboardLayoutItem3})
            DashboardLayoutGroup3.DashboardItem = Nothing
            DashboardLayoutGroup3.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup3.Weight = 32.647333956969128R
            DashboardLayoutItem4.DashboardItem = Me.gridDashboardItem3
            DashboardLayoutItem4.Weight = 40.879326473339567R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutGroup3, DashboardLayoutItem4})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 67.578125R
            DashboardLayoutItem5.DashboardItem = Me.chartDashboardItem2
            DashboardLayoutItem5.Weight = 75.903614457831324R
            DashboardLayoutItem6.DashboardItem = Me.rangeFilterDashboardItem1
            DashboardLayoutItem6.Weight = 24.096385542168676R
            DashboardLayoutGroup4.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem5, DashboardLayoutItem6})
            DashboardLayoutGroup4.DashboardItem = Nothing
            DashboardLayoutGroup4.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup4.Weight = 32.421875R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup2, DashboardLayoutGroup4})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            Me.LayoutRoot = DashboardLayoutGroup1
            DashboardParameter1.Description = "Data Inicial"
            DashboardParameter1.Name = "parDataIni"
            DashboardParameter1.Type = GetType(Date)
            DashboardParameter1.Value = New Date(2015, 1, 1, 0, 0, 0, 0)
            DashboardParameter2.Description = "Data Final"
            DashboardParameter2.Name = "parDataFim"
            DashboardParameter2.Type = GetType(Date)
            DashboardParameter2.Value = New Date(2015, 12, 31, 0, 0, 0, 0)
            Me.Parameters.AddRange(New DevExpress.DashboardCommon.DashboardParameter() {DashboardParameter1, DashboardParameter2})
            Me.Title.Text = "Log Acesso Usuários BI UAM"
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.rangeFilterDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridDashboardItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chartDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents gridDashboardItem1 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents dataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents gridDashboardItem2 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents rangeFilterDashboardItem1 As DevExpress.DashboardCommon.RangeFilterDashboardItem
        Friend WithEvents gridDashboardItem3 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents chartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents chartDashboardItem2 As DevExpress.DashboardCommon.ChartDashboardItem

#End Region
    End Class
End Namespace