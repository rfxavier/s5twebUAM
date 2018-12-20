Namespace Win_Dashboards
    Partial Public Class dashCnOficinaResumoGeralPub
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
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Dimension1 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Gauge1 As DevExpress.DashboardCommon.Gauge = New DevExpress.DashboardCommon.Gauge()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Gauge2 As DevExpress.DashboardCommon.Gauge = New DevExpress.DashboardCommon.Gauge()
            Dim CalculatedField3 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim CalculatedField4 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim OracleConnectionParameters2 As DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters()
            Dim CustomSqlQuery2 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim CalculatedField1 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim CalculatedField2 As DevExpress.DashboardCommon.CalculatedField = New DevExpress.DashboardCommon.CalculatedField()
            Dim OracleConnectionParameters1 As DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters()
            Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashCnOficinaResumoGeralPub))
            Dim DataConnection1 As DevExpress.DataAccess.DataConnection = New DevExpress.DataAccess.DataConnection()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.gaugeDashboardItem2 = New DevExpress.DashboardCommon.GaugeDashboardItem()
            Me.gaugeDashboardItem3 = New DevExpress.DashboardCommon.GaugeDashboardItem()
            Me.dataSource3 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.dataSource2 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            CType(Me.gaugeDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gaugeDashboardItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'gaugeDashboardItem2
            '
            Me.gaugeDashboardItem2.ComponentName = "gaugeDashboardItem2"
            Measure1.DataMember = "DISP"
            Measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure1.NumericFormat.IncludeGroupSeparator = True
            Measure1.NumericFormat.Precision = 0
            Measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure2.DataMember = "DISPmeta"
            Dimension1.DataMember = "CLASSE_MECcalc"
            Me.gaugeDashboardItem2.DataItemRepository.Clear()
            Me.gaugeDashboardItem2.DataItemRepository.Add(Measure1, "DataItem0")
            Me.gaugeDashboardItem2.DataItemRepository.Add(Measure2, "DataItem1")
            Me.gaugeDashboardItem2.DataItemRepository.Add(Dimension1, "DataItem2")
            Me.gaugeDashboardItem2.DataMember = "dsUAMOficinaDispGERAL"
            Me.gaugeDashboardItem2.DataSource = Me.dataSource2
            Gauge1.DeltaOptions.ValueType = DevExpress.DashboardCommon.DeltaValueType.ActualValue
            Gauge1.Maximum = 100.0R
            Gauge1.Minimum = 0.0R
            Gauge1.AddDataItem("ActualValue", Measure1)
            Gauge1.AddDataItem("TargetValue", Measure2)
            Me.gaugeDashboardItem2.Gauges.AddRange(New DevExpress.DashboardCommon.Gauge() {Gauge1})
            Me.gaugeDashboardItem2.InteractivityOptions.IgnoreMasterFilters = True
            Me.gaugeDashboardItem2.Name = "Disponibilidade Total (%)"
            Me.gaugeDashboardItem2.SeriesDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension1})
            Me.gaugeDashboardItem2.ShowCaption = True
            Me.gaugeDashboardItem2.ViewType = DevExpress.DashboardCommon.GaugeViewType.CircularHalf
            '
            'gaugeDashboardItem3
            '
            Me.gaugeDashboardItem3.ComponentName = "gaugeDashboardItem3"
            Me.gaugeDashboardItem3.ContentArrangementMode = DevExpress.DashboardCommon.ContentArrangementMode.FixedColumnCount
            Measure3.DataMember = "DISP"
            Measure3.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure3.NumericFormat.Precision = 0
            Measure3.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure4.DataMember = "DISPmeta"
            Dimension2.DataMember = "CLASSE_MECcalc"
            Measure5.DataMember = "DSC_CLASSE_MECANICA"
            Measure5.SummaryType = DevExpress.DashboardCommon.SummaryType.Max
            Dimension2.SortByMeasure = Measure5
            Me.gaugeDashboardItem3.DataItemRepository.Clear()
            Me.gaugeDashboardItem3.DataItemRepository.Add(Measure3, "DataItem0")
            Me.gaugeDashboardItem3.DataItemRepository.Add(Measure4, "DataItem1")
            Me.gaugeDashboardItem3.DataItemRepository.Add(Dimension2, "DataItem2")
            Me.gaugeDashboardItem3.DataItemRepository.Add(Measure5, "DataItem3")
            Me.gaugeDashboardItem3.DataMember = "dsUAMOficinaDispCM"
            Me.gaugeDashboardItem3.DataSource = Me.dataSource3
            Gauge2.DeltaOptions.ValueType = DevExpress.DashboardCommon.DeltaValueType.ActualValue
            Gauge2.Maximum = 100.0R
            Gauge2.Minimum = 0.0R
            Gauge2.AddDataItem("ActualValue", Measure3)
            Gauge2.AddDataItem("TargetValue", Measure4)
            Me.gaugeDashboardItem3.Gauges.AddRange(New DevExpress.DashboardCommon.Gauge() {Gauge2})
            Me.gaugeDashboardItem3.HiddenMeasures.AddRange(New DevExpress.DashboardCommon.Measure() {Measure5})
            Me.gaugeDashboardItem3.InteractivityOptions.IgnoreMasterFilters = False
            Me.gaugeDashboardItem3.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.gaugeDashboardItem3.IsMasterFilterCrossDataSource = True
            Me.gaugeDashboardItem3.Name = "Disponibilidade por Classe Mecânica (%)"
            Me.gaugeDashboardItem3.SeriesDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension2})
            Me.gaugeDashboardItem3.ShowCaption = True
            Me.gaugeDashboardItem3.ViewType = DevExpress.DashboardCommon.GaugeViewType.CircularHalf
            '
            'dataSource3
            '
            CalculatedField3.DataMember = "dsUAMOficinaDispCM"
            CalculatedField3.DataType = DevExpress.DashboardCommon.CalculatedFieldType.[Decimal]
            CalculatedField3.Expression = "Iif([COD_CLASSE_MECANICA] = 9, 83, 85)"
            CalculatedField3.Name = "DISPmeta"
            CalculatedField4.DataMember = "dsUAMOficinaDispCM"
            CalculatedField4.Expression = "Concat([DSC_CLASSE_MECANICA], ' ( ', ToStr([QTD_MANUT]), ' )')"
            CalculatedField4.Name = "CLASSE_MECcalc"
            Me.dataSource3.CalculatedFields.AddRange(New DevExpress.DashboardCommon.CalculatedField() {CalculatedField3, CalculatedField4})
            Me.dataSource3.ComponentName = "dataSource3"
            Me.dataSource3.ConnectionName = "localhost_Connection"
            OracleConnectionParameters2.ServerName = "localhost"
            Me.dataSource3.ConnectionParameters = OracleConnectionParameters2
            Me.dataSource3.Name = "dsUAMOficinaDispCM"
            CustomSqlQuery2.Name = "dsUAMOficinaDispCM"
            CustomSqlQuery2.Sql = resources.GetString("CustomSqlQuery2.Sql")
            Me.dataSource3.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery2})
            Me.dataSource3.ResultSchemaSerializable = resources.GetString("dataSource3.ResultSchemaSerializable")
            '
            'dataSource2
            '
            CalculatedField1.DataMember = "dsUAMOficinaDispGERAL"
            CalculatedField1.DataType = DevExpress.DashboardCommon.CalculatedFieldType.[Integer]
            CalculatedField1.Expression = "85"
            CalculatedField1.Name = "DISPmeta"
            CalculatedField2.DataMember = "dsUAMOficinaDispGERAL"
            CalculatedField2.Expression = "Concat('Total ', ToStr([QTD_EQUIP]), ' ( ', ToStr([QTD_MANUT]), ' )')"
            CalculatedField2.Name = "CLASSE_MECcalc"
            Me.dataSource2.CalculatedFields.AddRange(New DevExpress.DashboardCommon.CalculatedField() {CalculatedField1, CalculatedField2})
            Me.dataSource2.ComponentName = "dataSource2"
            Me.dataSource2.ConnectionName = "localhost_Connection"
            OracleConnectionParameters1.Password = "manager"
            OracleConnectionParameters1.ServerName = "localhost"
            OracleConnectionParameters1.UserName = "BI4T"
            Me.dataSource2.ConnectionParameters = OracleConnectionParameters1
            Me.dataSource2.Name = "dsUAMOficinaDispGERAL"
            CustomSqlQuery1.Name = "dsUAMOficinaDispGERAL"
            CustomSqlQuery1.Sql = resources.GetString("CustomSqlQuery1.Sql")
            Me.dataSource2.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery1})
            Me.dataSource2.ResultSchemaSerializable = resources.GetString("dataSource2.ResultSchemaSerializable")
            '
            'dashCnOficinaResumoGeralPub
            '
            DataConnection1.Name = "localhost_Connection"
            DataConnection1.ParametersSerializable = resources.GetString("DataConnection1.ParametersSerializable")
            DataConnection1.ProviderKey = "Oracle"
            Me.DataConnections.Add(DataConnection1)
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.dataSource3, Me.dataSource2})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.gaugeDashboardItem2, Me.gaugeDashboardItem3})
            DashboardLayoutItem1.DashboardItem = Me.gaugeDashboardItem2
            DashboardLayoutItem1.Weight = 45.964263709180528R
            DashboardLayoutItem2.DashboardItem = Me.gaugeDashboardItem3
            DashboardLayoutItem2.Weight = 54.035736290819472R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2})
            DashboardLayoutGroup1.DashboardItem = Nothing
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "Resumo da Oficina"
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gaugeDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gaugeDashboardItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents gaugeDashboardItem2 As DevExpress.DashboardCommon.GaugeDashboardItem
        Friend WithEvents dataSource2 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents gaugeDashboardItem3 As DevExpress.DashboardCommon.GaugeDashboardItem
        Friend WithEvents dataSource3 As DevExpress.DashboardCommon.DashboardSqlDataSource

#End Region
    End Class
End Namespace