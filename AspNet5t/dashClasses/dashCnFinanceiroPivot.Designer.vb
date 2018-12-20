Namespace Win_Dashboards
    Partial Public Class dashCnFinanceiroPivot
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
            Dim DimensionDefinition1 As DevExpress.DashboardCommon.DimensionDefinition = New DevExpress.DashboardCommon.DimensionDefinition("ENTRADA_SAIDA")
            Dim ColorSchemeDimensionKey1 As DevExpress.DashboardCommon.ColorSchemeDimensionKey = New DevExpress.DashboardCommon.ColorSchemeDimensionKey(DimensionDefinition1, "CONTAS A PAGAR")
            Dim ColorSchemeEntry2 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim DimensionDefinition2 As DevExpress.DashboardCommon.DimensionDefinition = New DevExpress.DashboardCommon.DimensionDefinition("ENTRADA_SAIDA")
            Dim ColorSchemeDimensionKey2 As DevExpress.DashboardCommon.ColorSchemeDimensionKey = New DevExpress.DashboardCommon.ColorSchemeDimensionKey(DimensionDefinition2, "CONTAS A RECEBER")
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries2 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Dimension3 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension4 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim CalculatedField1 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim OracleConnectionParameters1 As DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters()
            Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashCnFinanceiroPivot))
            Dim DataConnection1 As DevExpress.DataAccess.DataConnection = New DevExpress.DataAccess.DataConnection()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.chartDashboardItem2 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.pivotDashboardItem1 = New DevExpress.DashboardCommon.PivotDashboardItem()
            Me.dashboardSqlDataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            CType(Me.chartDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pivotDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'chartDashboardItem2
            '
            Dimension1.DataMember = "PAGAMENTO"
            Dimension1.DateTimeFormat.MonthFormat = DevExpress.DashboardCommon.MonthFormat.Abbreviated
            Dimension1.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Dimension1.Name = "Data do Pagamento"
            Dimension1.TopNOptions.Count = 12
            Me.chartDashboardItem2.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension1})
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
            Measure1.DataMember = "CONTAS_A_RECEBER"
            Measure1.Name = "Contas a Receber"
            Measure2.DataMember = "CONTAS_A_PAGAR"
            Measure2.Name = "Contas a Pagar"
            Me.chartDashboardItem2.DataItemRepository.Clear()
            Me.chartDashboardItem2.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.chartDashboardItem2.DataItemRepository.Add(Measure1, "DataItem2")
            Me.chartDashboardItem2.DataItemRepository.Add(Measure2, "DataItem3")
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
            SimpleSeries1.AddDataItem("Value", Measure1)
            SimpleSeries2.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries2.AddDataItem("Value", Measure2)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1, SimpleSeries2})
            Me.chartDashboardItem2.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.chartDashboardItem2.ShowCaption = True
            '
            'pivotDashboardItem1
            '
            Me.pivotDashboardItem1.ComponentName = "pivotDashboardItem1"
            Dimension2.DataMember = "DESCRICAO"
            Measure3.DataMember = "CONTAS_A_RECEBER"
            Measure3.Name = "Valor - Receber"
            Measure4.DataMember = "CONTAS_A_PAGAR"
            Measure4.Name = "Valor - Pagar"
            Dimension3.DataMember = "PAGAMENTO"
            Dimension3.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayMonthYear
            Dimension4.DataMember = "ORIGEM"
            Measure5.DataMember = "Calculated Field 1"
            Measure5.Name = "Valor (Receber - Pagar)"
            Me.pivotDashboardItem1.DataItemRepository.Clear()
            Me.pivotDashboardItem1.DataItemRepository.Add(Dimension2, "DataItem0")
            Me.pivotDashboardItem1.DataItemRepository.Add(Measure3, "DataItem1")
            Me.pivotDashboardItem1.DataItemRepository.Add(Measure4, "DataItem2")
            Me.pivotDashboardItem1.DataItemRepository.Add(Dimension3, "DataItem4")
            Me.pivotDashboardItem1.DataItemRepository.Add(Dimension4, "DataItem3")
            Me.pivotDashboardItem1.DataItemRepository.Add(Measure5, "DataItem5")
            Me.pivotDashboardItem1.DataMember = "FINANCEIRO"
            Me.pivotDashboardItem1.DataSource = Me.dashboardSqlDataSource1
            Me.pivotDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.pivotDashboardItem1.Name = "Pivot"
            Me.pivotDashboardItem1.Rows.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension2, Dimension4, Dimension3})
            Me.pivotDashboardItem1.ShowCaption = True
            Me.pivotDashboardItem1.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure3, Measure4, Measure5})
            '
            'dashboardSqlDataSource1
            '
            CalculatedField1.DataMember = "FINANCEIRO"
            CalculatedField1.DataType = DevExpress.DashboardCommon.CalculatedFieldType.[Decimal]
            CalculatedField1.Expression = "[CONTAS_A_RECEBER] - [CONTAS_A_PAGAR]"
            CalculatedField1.Name = "Calculated Field 1"
            Me.dashboardSqlDataSource1.CalculatedFields.AddRange(New DevExpress.DashboardCommon.CalculatedField() {CalculatedField1})
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
            'dashCnFinanceiroPivot
            '
            DataConnection1.Name = "localhost_base5tConnection"
            DataConnection1.ParametersSerializable = resources.GetString("DataConnection1.ParametersSerializable")
            DataConnection1.ProviderKey = "MySql"
            Me.DataConnections.Add(DataConnection1)
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.dashboardSqlDataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.chartDashboardItem2, Me.pivotDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.pivotDashboardItem1
            DashboardLayoutItem1.Weight = 53.920386007237639R
            DashboardLayoutItem2.DashboardItem = Me.chartDashboardItem2
            DashboardLayoutItem2.Weight = 46.079613992762361R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "Pivot - Financeiro"
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chartDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pivotDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents chartDashboardItem2 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents dashboardSqlDataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents pivotDashboardItem1 As DevExpress.DashboardCommon.PivotDashboardItem

#End Region
    End Class
End Namespace