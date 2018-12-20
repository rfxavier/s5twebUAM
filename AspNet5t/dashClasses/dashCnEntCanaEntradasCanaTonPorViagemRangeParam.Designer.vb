Namespace Win_Dashboards
    Partial Public Class dashCnEntCanaEntradasCanaTonPorViagemRangeParam
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
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim OracleConnectionParameters1 As DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters = New DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters()
            Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashCnEntCanaEntradasCanaTonPorViagemRangeParam))
            Dim DataConnection1 As DevExpress.DataAccess.DataConnection = New DevExpress.DataAccess.DataConnection()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.rangeFilterDashboardItem1 = New DevExpress.DashboardCommon.RangeFilterDashboardItem()
            Me.dataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            CType(Me.rangeFilterDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'rangeFilterDashboardItem1
            '
            Dimension1.DataMember = "DT_MOAGEM"
            Dimension1.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayMonthYear
            Me.rangeFilterDashboardItem1.Argument = Dimension1
            Me.rangeFilterDashboardItem1.ComponentName = "rangeFilterDashboardItem1"
            Measure1.DataMember = "QT_TON_ENTREGUE_REAL"
            Me.rangeFilterDashboardItem1.DataItemRepository.Clear()
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.rangeFilterDashboardItem1.DataItemRepository.Add(Measure1, "DataItem1")
            Me.rangeFilterDashboardItem1.DataMember = "dsBI4T"
            Me.rangeFilterDashboardItem1.DataSource = Me.dataSource1
            Me.rangeFilterDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.rangeFilterDashboardItem1.Name = "Range Filter 1"
            SimpleSeries1.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Area
            SimpleSeries1.AddDataItem("Value", Measure1)
            Me.rangeFilterDashboardItem1.Series.AddRange(New DevExpress.DashboardCommon.SimpleSeries() {SimpleSeries1})
            Me.rangeFilterDashboardItem1.ShowCaption = False
            '
            'dataSource1
            '
            Me.dataSource1.ComponentName = "dataSource1"
            Me.dataSource1.ConnectionName = "localhost_Connection"
            OracleConnectionParameters1.ServerName = "localhost"
            Me.dataSource1.ConnectionParameters = OracleConnectionParameters1
            Me.dataSource1.Name = "dsBI4T"
            CustomSqlQuery1.Name = "dsBI4T"
            CustomSqlQuery1.Sql = resources.GetString("CustomSqlQuery1.Sql")
            Me.dataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery1})
            Me.dataSource1.ResultSchemaSerializable = resources.GetString("dataSource1.ResultSchemaSerializable")
            '
            'dashCnEntCanaEntradasCanaTonPorViagemRangeParam
            '
            DataConnection1.Name = "localhost_Connection"
            DataConnection1.ParametersSerializable = resources.GetString("DataConnection1.ParametersSerializable")
            DataConnection1.ProviderKey = "Oracle"
            Me.DataConnections.Add(DataConnection1)
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.dataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.rangeFilterDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.rangeFilterDashboardItem1
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1})
            DashboardLayoutGroup1.DashboardItem = Nothing
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.ShowMasterFilterState = False
            Me.Title.Text = "Dashboard"
            Me.Title.Visible = False
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.rangeFilterDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents rangeFilterDashboardItem1 As DevExpress.DashboardCommon.RangeFilterDashboardItem
        Friend WithEvents dataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource

#End Region
    End Class
End Namespace