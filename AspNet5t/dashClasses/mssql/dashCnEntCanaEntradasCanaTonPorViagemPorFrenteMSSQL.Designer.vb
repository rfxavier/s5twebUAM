Namespace Win_Dashboards
    Partial Public Class dashCnEntCanaEntradasCanaTonPorViagemPorFrenteMSSQL
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
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn2 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Dimension3 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn3 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim GridMeasureColumn1 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn2 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn3 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Gauge1 As DevExpress.DashboardCommon.Gauge = New DevExpress.DashboardCommon.Gauge()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Card1 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim Measure6 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Card2 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim Dimension4 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn4 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Measure7 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn4 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Measure8 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn5 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Measure9 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn6 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim CalculatedField1 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim CalculatedField2 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim MsSqlConnectionParameters1 As DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters()
            Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim QueryParameter1 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
            Dim QueryParameter2 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashCnEntCanaEntradasCanaTonPorViagemPorFrenteMSSQL))
            Dim CalculatedField3 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim MsSqlConnectionParameters2 As DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters()
            Dim CustomSqlQuery2 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim QueryParameter3 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
            Dim QueryParameter4 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
            Dim CalculatedField4 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim CalculatedField5 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim MsSqlConnectionParameters3 As DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters()
            Dim CustomSqlQuery3 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim QueryParameter5 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
            Dim QueryParameter6 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
            Dim DataConnection1 As DevExpress.DataAccess.DataConnection = New DevExpress.DataAccess.DataConnection()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup3 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup4 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem4 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem5 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardParameter1 As DevExpress.DashboardCommon.DashboardParameter = New DevExpress.DashboardCommon.DashboardParameter()
            Dim DashboardParameter2 As DevExpress.DashboardCommon.DashboardParameter = New DevExpress.DashboardCommon.DashboardParameter()
            Me.gridDashboardItem1 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.gaugeDashboardItem1 = New DevExpress.DashboardCommon.GaugeDashboardItem()
            Me.cardDashboardItem1 = New DevExpress.DashboardCommon.CardDashboardItem()
            Me.cardDashboardItem2 = New DevExpress.DashboardCommon.CardDashboardItem()
            Me.gridDashboardItem2 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.dataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.dataSource2 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.dataSource3 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gaugeDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cardDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cardDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'gridDashboardItem1
            '
            Dimension1.DataMember = "PROP_CODIGO"
            Dimension1.Name = "Código"
            Dimension1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Dimension1.NumericFormat.Precision = 0
            Dimension1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure1.DataMember = "QT_TON_ENTREGUE_REAL"
            Measure1.Name = "Toneladas"
            Measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure1.NumericFormat.IncludeGroupSeparator = True
            Measure1.NumericFormat.Precision = 0
            Measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Dimension1.SortByMeasure = Measure1
            Dimension1.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn1.Name = "Código"
            GridDimensionColumn1.Weight = 57.32393248937457R
            GridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn1.AddDataItem("Dimension", Dimension1)
            Dimension2.DataMember = "DS_NOME_PROPRIEDADE"
            Dimension2.Name = "Propriedade"
            Dimension2.SortByMeasure = Measure1
            Dimension2.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn2.Name = "Propriedade"
            GridDimensionColumn2.Weight = 121.17843956614624R
            GridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn2.AddDataItem("Dimension", Dimension2)
            Dimension3.DataMember = "DESCMUNI"
            Dimension3.Name = "Município"
            Dimension3.SortByMeasure = Measure1
            Dimension3.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn3.Name = "Município"
            GridDimensionColumn3.Weight = 66.0313652725707R
            GridDimensionColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn3.AddDataItem("Dimension", Dimension3)
            GridMeasureColumn1.Name = "Toneladas"
            GridMeasureColumn1.Weight = 87.79994723056106R
            GridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn1.AddDataItem("Measure", Measure1)
            Measure2.DataMember = "VIAGENS"
            Measure2.Name = "Viagens"
            Measure2.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure2.NumericFormat.IncludeGroupSeparator = True
            Measure2.NumericFormat.Precision = 0
            Measure2.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            GridMeasureColumn2.Name = "Viagens"
            GridMeasureColumn2.Weight = 86.3487084333617R
            GridMeasureColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn2.AddDataItem("Measure", Measure2)
            Measure3.DataMember = "TON_POR_VIAGEM"
            Measure3.Name = "Ton/Viagem"
            Measure3.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure3.NumericFormat.IncludeGroupSeparator = True
            Measure3.NumericFormat.Precision = 1
            Measure3.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure3.SummaryType = DevExpress.DashboardCommon.SummaryType.Average
            GridMeasureColumn3.Name = "Ton/Viagem"
            GridMeasureColumn3.Weight = 87.79994723056106R
            GridMeasureColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn3.AddDataItem("Measure", Measure3)
            Me.gridDashboardItem1.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn1, GridDimensionColumn2, GridDimensionColumn3, GridMeasureColumn1, GridMeasureColumn2, GridMeasureColumn3})
            Me.gridDashboardItem1.ComponentName = "gridDashboardItem1"
            Me.gridDashboardItem1.DataItemRepository.Clear()
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension2, "DataItem0")
            Me.gridDashboardItem1.DataItemRepository.Add(Measure1, "DataItem3")
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension3, "DataItem2")
            Me.gridDashboardItem1.DataItemRepository.Add(Measure3, "DataItem4")
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem5")
            Me.gridDashboardItem1.DataItemRepository.Add(Measure2, "DataItem1")
            Me.gridDashboardItem1.DataMember = "dsCnEntCanaEntPorProp"
            Me.gridDashboardItem1.DataSource = Me.dataSource1
            Me.gridDashboardItem1.GridOptions.ColumnWidthMode = DevExpress.DashboardCommon.GridColumnWidthMode.Manual
            Me.gridDashboardItem1.GridOptions.EnableBandedRows = True
            Me.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.gridDashboardItem1.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.gridDashboardItem1.Name = "Entradas de Cana por Propriedade"
            Me.gridDashboardItem1.ShowCaption = True
            '
            'gaugeDashboardItem1
            '
            Me.gaugeDashboardItem1.ComponentName = "gaugeDashboardItem1"
            Me.gaugeDashboardItem1.ContentArrangementMode = DevExpress.DashboardCommon.ContentArrangementMode.FixedRowCount
            Me.gaugeDashboardItem1.ContentLineCount = 2
            Measure4.DataMember = "QT_TON_ENTREGUE_REAL"
            Measure4.Name = "Toneladas"
            Measure4.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure4.NumericFormat.IncludeGroupSeparator = True
            Me.gaugeDashboardItem1.DataItemRepository.Clear()
            Me.gaugeDashboardItem1.DataItemRepository.Add(Measure4, "DataItem0")
            Me.gaugeDashboardItem1.DataMember = "dsCnEntCanaEntPorProp"
            Me.gaugeDashboardItem1.DataSource = Me.dataSource1
            Gauge1.Name = "Total Toneladas"
            Gauge1.AddDataItem("ActualValue", Measure4)
            Me.gaugeDashboardItem1.Gauges.AddRange(New DevExpress.DashboardCommon.Gauge() {Gauge1})
            Me.gaugeDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.gaugeDashboardItem1.Name = "Gauges 1"
            Me.gaugeDashboardItem1.ShowCaption = False
            Me.gaugeDashboardItem1.ViewType = DevExpress.DashboardCommon.GaugeViewType.CircularHalf
            '
            'cardDashboardItem1
            '
            Measure5.DataMember = "VIAGENS"
            Measure5.Name = "Viagens Geral"
            Measure5.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure5.NumericFormat.IncludeGroupSeparator = True
            Measure5.NumericFormat.Precision = 0
            Measure5.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Card1.AddDataItem("ActualValue", Measure5)
            Me.cardDashboardItem1.Cards.AddRange(New DevExpress.DashboardCommon.Card() {Card1})
            Me.cardDashboardItem1.ComponentName = "cardDashboardItem1"
            Me.cardDashboardItem1.DataItemRepository.Clear()
            Me.cardDashboardItem1.DataItemRepository.Add(Measure5, "DataItem0")
            Me.cardDashboardItem1.DataMember = "dsCnEntCanaEntGeral"
            Me.cardDashboardItem1.DataSource = Me.dataSource2
            Me.cardDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.cardDashboardItem1.Name = "Cards 1"
            Me.cardDashboardItem1.ShowCaption = False
            '
            'cardDashboardItem2
            '
            Measure6.DataMember = "TON_POR_VIAGEM"
            Measure6.Name = "Ton / Viagem Geral"
            Measure6.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure6.NumericFormat.IncludeGroupSeparator = True
            Measure6.NumericFormat.Precision = 1
            Measure6.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Card2.AddDataItem("ActualValue", Measure6)
            Me.cardDashboardItem2.Cards.AddRange(New DevExpress.DashboardCommon.Card() {Card2})
            Me.cardDashboardItem2.ComponentName = "cardDashboardItem2"
            Me.cardDashboardItem2.DataItemRepository.Clear()
            Me.cardDashboardItem2.DataItemRepository.Add(Measure6, "DataItem0")
            Me.cardDashboardItem2.DataMember = "dsCnEntCanaEntGeral"
            Me.cardDashboardItem2.DataSource = Me.dataSource2
            Me.cardDashboardItem2.InteractivityOptions.IgnoreMasterFilters = False
            Me.cardDashboardItem2.Name = "Cards 2"
            Me.cardDashboardItem2.ShowCaption = False
            '
            'gridDashboardItem2
            '
            Dimension4.DataMember = "FC_INTcalc"
            Dimension4.Name = "Frente"
            Dimension4.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Dimension4.NumericFormat.IncludeGroupSeparator = True
            Dimension4.NumericFormat.Precision = 0
            Dimension4.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            GridDimensionColumn4.Name = "Frente"
            GridDimensionColumn4.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn4.AddDataItem("Dimension", Dimension4)
            Measure7.DataMember = "QT_TON_ENTREGUE_REAL"
            Measure7.Name = "Toneladas"
            Measure7.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure7.NumericFormat.IncludeGroupSeparator = True
            Measure7.NumericFormat.Precision = 0
            GridMeasureColumn4.Name = "Toneladas"
            GridMeasureColumn4.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn4.AddDataItem("Measure", Measure7)
            Measure8.DataMember = "VIAGENS"
            Measure8.Name = "Viagens"
            Measure8.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure8.NumericFormat.IncludeGroupSeparator = True
            Measure8.NumericFormat.Precision = 0
            Measure8.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            GridMeasureColumn5.Name = "Viagens"
            GridMeasureColumn5.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn5.AddDataItem("Measure", Measure8)
            Measure9.DataMember = "TON_POR_VIAGEM"
            Measure9.Name = "Ton / Viagem"
            Measure9.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure9.NumericFormat.IncludeGroupSeparator = True
            Measure9.NumericFormat.Precision = 1
            Measure9.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure9.SummaryType = DevExpress.DashboardCommon.SummaryType.Average
            GridMeasureColumn6.Name = "Ton / Viagem"
            GridMeasureColumn6.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn6.AddDataItem("Measure", Measure9)
            Me.gridDashboardItem2.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn4, GridMeasureColumn4, GridMeasureColumn5, GridMeasureColumn6})
            Me.gridDashboardItem2.ComponentName = "gridDashboardItem2"
            Me.gridDashboardItem2.DataItemRepository.Clear()
            Me.gridDashboardItem2.DataItemRepository.Add(Measure9, "DataItem0")
            Me.gridDashboardItem2.DataItemRepository.Add(Measure7, "DataItem2")
            Me.gridDashboardItem2.DataItemRepository.Add(Dimension4, "DataItem1")
            Me.gridDashboardItem2.DataItemRepository.Add(Measure8, "DataItem4")
            Me.gridDashboardItem2.DataMember = "dsCnEntCanaEntPorPropPorFrente"
            Me.gridDashboardItem2.DataSource = Me.dataSource3
            Me.gridDashboardItem2.InteractivityOptions.IgnoreMasterFilters = False
            Me.gridDashboardItem2.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.[Single]
            Me.gridDashboardItem2.IsMasterFilterCrossDataSource = True
            Me.gridDashboardItem2.Name = "Entradas de Cana por Frente"
            Me.gridDashboardItem2.ShowCaption = True
            '
            'dataSource1
            '
            CalculatedField1.DataMember = "dsCnEntCanaEntPorProp"
            CalculatedField1.DataType = DevExpress.DashboardCommon.CalculatedFieldType.[Decimal]
            CalculatedField1.Expression = "[QT_TON_ENTREGUE_REAL] / [VIAGENS]"
            CalculatedField1.Name = "QT_TON_PORVIAGEMcalc"
            CalculatedField2.DataMember = "dsCnEntCanaEntPorProp"
            CalculatedField2.DataType = DevExpress.DashboardCommon.CalculatedFieldType.[Decimal]
            CalculatedField2.Expression = "ToInt([FRENTE_COLHEITA])"
            CalculatedField2.Name = "FC_INTcalc"
            Me.dataSource1.CalculatedFields.AddRange(New DevExpress.DashboardCommon.CalculatedField() {CalculatedField1, CalculatedField2})
            Me.dataSource1.ComponentName = "dataSource1"
            Me.dataSource1.ConnectionName = "GIOVANA-LAPTOP\SQLEXPRESS_s5tuam_Connection"
            MsSqlConnectionParameters1.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.SqlServer
            MsSqlConnectionParameters1.DatabaseName = "s5tuam"
            MsSqlConnectionParameters1.ServerName = "GIOVANA-LAPTOP\SQLEXPRESS"
            Me.dataSource1.ConnectionParameters = MsSqlConnectionParameters1
            Me.dataSource1.Name = "dsCnEntCanaEntPorProp"
            CustomSqlQuery1.Name = "dsCnEntCanaEntPorProp"
            QueryParameter1.Name = "parDataIni"
            QueryParameter1.Type = GetType(DevExpress.DataAccess.Expression)
            QueryParameter1.Value = New DevExpress.DataAccess.Expression("[Parameters.parDataIni]", GetType(Date))
            QueryParameter2.Name = "parDataFim"
            QueryParameter2.Type = GetType(DevExpress.DataAccess.Expression)
            QueryParameter2.Value = New DevExpress.DataAccess.Expression("[Parameters.parDataFim]", GetType(Date))
            CustomSqlQuery1.Parameters.Add(QueryParameter1)
            CustomSqlQuery1.Parameters.Add(QueryParameter2)
            CustomSqlQuery1.Sql = resources.GetString("CustomSqlQuery1.Sql")
            Me.dataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery1})
            Me.dataSource1.ResultSchemaSerializable = resources.GetString("dataSource1.ResultSchemaSerializable")
            '
            'dataSource2
            '
            CalculatedField3.DataMember = "dsCnEntCanaEntGeral"
            CalculatedField3.DataType = DevExpress.DashboardCommon.CalculatedFieldType.[Decimal]
            CalculatedField3.Expression = "[QT_TON_ENTREGUE_REAL] / [VIAGENS]"
            CalculatedField3.Name = "QT_TON_PORVIAGEMcalc"
            Me.dataSource2.CalculatedFields.AddRange(New DevExpress.DashboardCommon.CalculatedField() {CalculatedField3})
            Me.dataSource2.ComponentName = "dataSource2"
            Me.dataSource2.ConnectionName = "GIOVANA-LAPTOP\SQLEXPRESS_s5tuam_Connection"
            MsSqlConnectionParameters2.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.SqlServer
            MsSqlConnectionParameters2.DatabaseName = "s5tuam"
            MsSqlConnectionParameters2.ServerName = "GIOVANA-LAPTOP\SQLEXPRESS"
            Me.dataSource2.ConnectionParameters = MsSqlConnectionParameters2
            Me.dataSource2.Name = "dsCnEntCanaEntGeral"
            CustomSqlQuery2.Name = "dsCnEntCanaEntGeral"
            QueryParameter3.Name = "parDataIni"
            QueryParameter3.Type = GetType(DevExpress.DataAccess.Expression)
            QueryParameter3.Value = New DevExpress.DataAccess.Expression("[Parameters.parDataIni]", GetType(Date))
            QueryParameter4.Name = "parDataFim"
            QueryParameter4.Type = GetType(DevExpress.DataAccess.Expression)
            QueryParameter4.Value = New DevExpress.DataAccess.Expression("[Parameters.parDataFim]", GetType(Date))
            CustomSqlQuery2.Parameters.Add(QueryParameter3)
            CustomSqlQuery2.Parameters.Add(QueryParameter4)
            CustomSqlQuery2.Sql = resources.GetString("CustomSqlQuery2.Sql")
            Me.dataSource2.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery2})
            Me.dataSource2.ResultSchemaSerializable = resources.GetString("dataSource2.ResultSchemaSerializable")
            '
            'dataSource3
            '
            CalculatedField4.DataMember = "dsCnEntCanaEntPorPropPorFrente"
            CalculatedField4.DataType = DevExpress.DashboardCommon.CalculatedFieldType.[Decimal]
            CalculatedField4.Expression = "[QT_TON_ENTREGUE_REAL] / [VIAGENS]"
            CalculatedField4.Name = "QT_TON_PORVIAGEMcalc"
            CalculatedField5.DataMember = "dsCnEntCanaEntPorPropPorFrente"
            CalculatedField5.DataType = DevExpress.DashboardCommon.CalculatedFieldType.[Decimal]
            CalculatedField5.Expression = "ToInt([FRENTE_COLHEITA])"
            CalculatedField5.Name = "FC_INTcalc"
            Me.dataSource3.CalculatedFields.AddRange(New DevExpress.DashboardCommon.CalculatedField() {CalculatedField4, CalculatedField5})
            Me.dataSource3.ComponentName = "dataSource3"
            Me.dataSource3.ConnectionName = "GIOVANA-LAPTOP\SQLEXPRESS_s5tuam_Connection"
            MsSqlConnectionParameters3.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.SqlServer
            MsSqlConnectionParameters3.DatabaseName = "s5tuam"
            MsSqlConnectionParameters3.ServerName = "GIOVANA-LAPTOP\SQLEXPRESS"
            Me.dataSource3.ConnectionParameters = MsSqlConnectionParameters3
            Me.dataSource3.Name = "dsCnEntCanaEntPorPropPorFrente"
            CustomSqlQuery3.Name = "dsCnEntCanaEntPorPropPorFrente"
            QueryParameter5.Name = "parDataIni"
            QueryParameter5.Type = GetType(DevExpress.DataAccess.Expression)
            QueryParameter5.Value = New DevExpress.DataAccess.Expression("[Parameters.parDataIni]", GetType(Date))
            QueryParameter6.Name = "parDataFim"
            QueryParameter6.Type = GetType(DevExpress.DataAccess.Expression)
            QueryParameter6.Value = New DevExpress.DataAccess.Expression("[Parameters.parDataFim]", GetType(Date))
            CustomSqlQuery3.Parameters.Add(QueryParameter5)
            CustomSqlQuery3.Parameters.Add(QueryParameter6)
            CustomSqlQuery3.Sql = resources.GetString("CustomSqlQuery3.Sql")
            Me.dataSource3.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery3})
            Me.dataSource3.ResultSchemaSerializable = resources.GetString("dataSource3.ResultSchemaSerializable")
            '
            'dashCnEntCanaEntradasCanaTonPorViagemPorFrenteMSSQL
            '
            DataConnection1.Name = "localhost_Connection"
            DataConnection1.ParametersSerializable = resources.GetString("DataConnection1.ParametersSerializable")
            DataConnection1.ProviderKey = "Oracle"
            Me.DataConnections.Add(DataConnection1)
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.dataSource1, Me.dataSource2, Me.dataSource3})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.gridDashboardItem1, Me.gaugeDashboardItem1, Me.cardDashboardItem1, Me.cardDashboardItem2, Me.gridDashboardItem2})
            DashboardLayoutItem1.DashboardItem = Me.gridDashboardItem2
            DashboardLayoutItem1.Weight = 32.4468085106383R
            DashboardLayoutItem2.DashboardItem = Me.gridDashboardItem1
            DashboardLayoutItem2.Weight = 67.553191489361708R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 50.687622789783887R
            DashboardLayoutItem3.DashboardItem = Me.cardDashboardItem1
            DashboardLayoutItem3.Weight = 50.199203187250994R
            DashboardLayoutItem4.DashboardItem = Me.cardDashboardItem2
            DashboardLayoutItem4.Weight = 49.800796812749006R
            DashboardLayoutGroup4.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem3, DashboardLayoutItem4})
            DashboardLayoutGroup4.DashboardItem = Nothing
            DashboardLayoutGroup4.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup4.Weight = 25.319148936170212R
            DashboardLayoutItem5.DashboardItem = Me.gaugeDashboardItem1
            DashboardLayoutItem5.Weight = 74.680851063829792R
            DashboardLayoutGroup3.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup4, DashboardLayoutItem5})
            DashboardLayoutGroup3.DashboardItem = Nothing
            DashboardLayoutGroup3.Weight = 49.312377210216113R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup2, DashboardLayoutGroup3})
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
            Me.Title.Text = "Entradas por Propriedade"
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gaugeDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cardDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cardDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents gridDashboardItem1 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents dataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents gaugeDashboardItem1 As DevExpress.DashboardCommon.GaugeDashboardItem
        Friend WithEvents cardDashboardItem1 As DevExpress.DashboardCommon.CardDashboardItem
        Friend WithEvents dataSource2 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents cardDashboardItem2 As DevExpress.DashboardCommon.CardDashboardItem
        Friend WithEvents gridDashboardItem2 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents dataSource3 As DevExpress.DashboardCommon.DashboardSqlDataSource

#End Region
    End Class
End Namespace