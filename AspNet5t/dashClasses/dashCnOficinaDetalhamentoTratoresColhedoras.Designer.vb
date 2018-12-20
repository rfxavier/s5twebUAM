Namespace Win_Dashboards
    Partial Public Class dashCnOficinaDetalhamentoTratoresColhedoras
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
            Dim Dimension4 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn4 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim GridMeasureColumn1 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Dimension5 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridDimensionColumn5 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Dimension6 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn6 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Dimension7 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn7 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Dimension8 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn8 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim GridMeasureColumn2 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim CalculatedField1 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashCnOficinaDetalhamentoTratoresColhedoras))
            Dim DataConnection1 As DevExpress.DataAccess.DataConnection = New DevExpress.DataAccess.DataConnection()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.gridDashboardItem1 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.gridDashboardItem2 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.dataSource1 = New DevExpress.DashboardCommon.DataSource()
            Me.dataSource2 = New DevExpress.DashboardCommon.DataSource()
            CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'gridDashboardItem1
            '
            Dimension1.DataMember = "DSC_CLASSE_OPERACIONAL"
            Measure1.DataMember = "HORAS_PARADA"
            Measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure1.NumericFormat.IncludeGroupSeparator = True
            Measure1.NumericFormat.Precision = 0
            Measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Dimension1.SortByMeasure = Measure1
            Dimension1.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn1.Name = "Classe Operacional"
            GridDimensionColumn1.Weight = 96.586501163692787R
            GridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn1.AddDataItem("Dimension", Dimension1)
            Dimension2.DataMember = "NUMERO_EQUIPAMENTO_FROTA"
            Dimension2.SortByMeasure = Measure1
            Dimension2.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn2.Name = "Equip."
            GridDimensionColumn2.Weight = 107.05973622963538R
            GridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn2.AddDataItem("Dimension", Dimension2)
            Dimension3.DataMember = "DSC_EQUIPAMENTO_FROTA"
            Dimension3.SortByMeasure = Measure1
            Dimension3.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn3.Name = "Descrição do Equipamento"
            GridDimensionColumn3.Weight = 94.84096198603568R
            GridDimensionColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn3.AddDataItem("Dimension", Dimension3)
            Dimension4.DataMember = "DATAHORAABERTURA"
            Dimension4.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DateHourMinuteSecond
            Dimension4.Name = "Data OS"
            Dimension4.SortByMeasure = Measure1
            Dimension4.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn4.Name = "Data OS"
            GridDimensionColumn4.Weight = 88.731574864235839R
            GridDimensionColumn4.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn4.AddDataItem("Dimension", Dimension4)
            GridMeasureColumn1.Name = "Horas Parada"
            GridMeasureColumn1.Weight = 56.439100077579518R
            GridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn1.AddDataItem("Measure", Measure1)
            Me.gridDashboardItem1.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn1, GridDimensionColumn2, GridDimensionColumn3, GridDimensionColumn4, GridMeasureColumn1})
            Me.gridDashboardItem1.ComponentName = "gridDashboardItem1"
            Me.gridDashboardItem1.DataItemRepository.Clear()
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension2, "DataItem1")
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension3, "DataItem2")
            Me.gridDashboardItem1.DataItemRepository.Add(Measure1, "DataItem4")
            Me.gridDashboardItem1.DataItemRepository.Add(Dimension4, "DataItem3")
            Me.gridDashboardItem1.DataSource = Me.dataSource1
            Me.gridDashboardItem1.GridOptions.EnableBandedRows = True
            Me.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.gridDashboardItem1.Name = "Tratores e Máquinas Oficina"
            Me.gridDashboardItem1.ShowCaption = True
            '
            'gridDashboardItem2
            '
            Dimension5.DataMember = "DSC_CLASSE_OPERACIONAL"
            Measure2.DataMember = "HORAS_PARADA"
            Measure2.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure2.NumericFormat.IncludeGroupSeparator = True
            Measure2.NumericFormat.Precision = 0
            Measure2.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Dimension5.SortByMeasure = Measure2
            Dimension5.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn5.Name = "Classe Operacional"
            GridDimensionColumn5.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn5.AddDataItem("Dimension", Dimension5)
            Dimension6.DataMember = "NUMERO_EQUIPAMENTO_FROTA"
            Dimension6.SortByMeasure = Measure2
            Dimension6.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn6.Name = "Equip."
            GridDimensionColumn6.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn6.AddDataItem("Dimension", Dimension6)
            Dimension7.DataMember = "DSC_EQUIPAMENTO_FROTA"
            Dimension7.SortByMeasure = Measure2
            Dimension7.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn7.Name = "Descrição"
            GridDimensionColumn7.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn7.AddDataItem("Dimension", Dimension7)
            Dimension8.DataMember = "DATAHORAABERTURA"
            Dimension8.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DateHourMinuteSecond
            Dimension8.SortByMeasure = Measure2
            Dimension8.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            GridDimensionColumn8.Name = "Data OS"
            GridDimensionColumn8.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn8.AddDataItem("Dimension", Dimension8)
            GridMeasureColumn2.Name = "Horas Parada"
            GridMeasureColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn2.AddDataItem("Measure", Measure2)
            Me.gridDashboardItem2.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn5, GridDimensionColumn6, GridDimensionColumn7, GridDimensionColumn8, GridMeasureColumn2})
            Me.gridDashboardItem2.ComponentName = "gridDashboardItem2"
            Me.gridDashboardItem2.DataItemRepository.Clear()
            Me.gridDashboardItem2.DataItemRepository.Add(Dimension5, "DataItem0")
            Me.gridDashboardItem2.DataItemRepository.Add(Dimension6, "DataItem1")
            Me.gridDashboardItem2.DataItemRepository.Add(Dimension7, "DataItem2")
            Me.gridDashboardItem2.DataItemRepository.Add(Dimension8, "DataItem3")
            Me.gridDashboardItem2.DataItemRepository.Add(Measure2, "DataItem4")
            Me.gridDashboardItem2.DataSource = Me.dataSource2
            Me.gridDashboardItem2.GridOptions.EnableBandedRows = True
            Me.gridDashboardItem2.InteractivityOptions.IgnoreMasterFilters = True
            Me.gridDashboardItem2.Name = "Colhedoras Oficina"
            Me.gridDashboardItem2.ShowCaption = True
            '
            'dataSource1
            '
            CalculatedField1.Expression = "Concat([DSC_CLASSE_MECANICA], ' ( ', ToStr([QTD_MANUT]), ' )')"
            CalculatedField1.Name = "CLASSE_MECcalc"
            Me.dataSource1.CalculatedFields.AddRange(New DevExpress.DashboardCommon.CalculatedField() {CalculatedField1})
            Me.dataSource1.ComponentName = "dataSource1"
            Me.dataSource1.DataProviderSerializable = resources.GetString("dataSource1.DataProviderSerializable")
            Me.dataSource1.Name = "dsUAMOficinaCm2TratMaq"
            '
            'dataSource2
            '
            Me.dataSource2.ComponentName = "dataSource2"
            Me.dataSource2.DataProviderSerializable = resources.GetString("dataSource2.DataProviderSerializable")
            Me.dataSource2.Name = "dsUAMOficinaCm9Colh"
            '
            'dashCnOficinaDetalhamentoTratoresColhedoras
            '
            DataConnection1.Name = "localhost_Connection"
            DataConnection1.ParametersSerializable = resources.GetString("DataConnection1.ParametersSerializable")
            DataConnection1.ProviderKey = "Oracle"
            Me.DataConnections.Add(DataConnection1)
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.DataSource() {Me.dataSource1, Me.dataSource2})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.gridDashboardItem1, Me.gridDashboardItem2})
            DashboardLayoutItem1.DashboardItem = Me.gridDashboardItem1
            DashboardLayoutItem1.Weight = 49.901768172888019R
            DashboardLayoutItem2.DashboardItem = Me.gridDashboardItem2
            DashboardLayoutItem2.Weight = 49.901768172888019R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 49.901768172888019R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup2})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.ImageDataSerializable = ""
            Me.Title.Text = "Resumo da Oficina"
            Me.Title.Visible = False
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents gridDashboardItem1 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents dataSource1 As DevExpress.DashboardCommon.DataSource
        Friend WithEvents gridDashboardItem2 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents dataSource2 As DevExpress.DashboardCommon.DataSource

#End Region
    End Class
End Namespace