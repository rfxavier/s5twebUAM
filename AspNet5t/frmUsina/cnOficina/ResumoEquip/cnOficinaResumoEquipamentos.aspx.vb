Imports DevExpress.Web
Imports Oracle.DataAccess.Client
Imports DevExpress.Data
Imports DevExpress.Data.Filtering
Imports Microsoft.AspNet.Identity
Imports System
Imports System.IO

Public Class cnOficinaResumoEquipamentos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsCallback) And Not (Page.IsPostBack) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

            gridCm.DataSourceID = ""
            gridCm.DataBind()
            'gridCm.DetailRows.ExpandAllRows()

            gridDetalhe.DataSourceID = ""
            gridDetalhe.DataBind()
        End If
    End Sub

    Protected Sub gridCm_DataBinding(sender As Object, e As EventArgs) Handles gridCm.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        conn.Open()
        Dim cmd As OracleCommand = New OracleCommand()
        cmd.Connection = conn
        cmd.CommandText = "SELECT ROWNUM, A.* FROM (SELECT R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'BASICA') BASICA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'RAPIDA') RAPIDA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'OFICINA') OFICINA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'VOLANTE') VOLANTE, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'EXTERNA' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.LOCAL IN ('OFICINA'))) EXTERNA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND LOCAL = 'EXTERNA/UAM' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.LOCAL IN ('OFICINA','EXTERNA'))) EXTERNA_UAM, COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA) TOTAL, ROUND((((SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA) - COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA)) * 100) / (SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA), 1) DISP FROM BI4T.V_RESUMO_OFICINA R GROUP BY R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA) A"
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()

        gridCm.DataSource = dr
    End Sub


    Protected Sub gridCmCo_BeforePerformDataSelect(sender As Object, e As EventArgs)
        'Session("gridCOD_CLASSE_MECANICA") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim detailGridView As ASPxGridView = CType(sender, ASPxGridView)

        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        conn.Open()

        Dim cmd As New OracleCommand("SELECT ROWNUM, A.* FROM (SELECT R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'BASICA') BASICA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'RAPIDA') RAPIDA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'OFICINA') OFICINA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'VOLANTE') VOLANTE, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'EXTERNA' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.COD_CLASSE_OPERACIONAL = RB.COD_CLASSE_OPERACIONAL AND RB2.LOCAL IN ('OFICINA'))) EXTERNA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND LOCAL = 'EXTERNA/UAM' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.COD_CLASSE_OPERACIONAL = RB.COD_CLASSE_OPERACIONAL AND RB2.LOCAL IN ('OFICINA','EXTERNA'))) EXTERNA_UAM, COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA) TOTAL, ROUND((((SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND X.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL) - COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA)) * 100) / (SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND X.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL), 1) DISP FROM BI4T.V_RESUMO_OFICINA R WHERE R.COD_CLASSE_MECANICA = :p0 GROUP BY R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL ORDER BY R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL) A", conn) With {.CommandType = CommandType.Text}
        cmd.Parameters.Add(":p0", OracleDbType.Int32).Value = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

        Dim dr As OracleDataReader = cmd.ExecuteReader()

        detailGridView.DataSourceID = ""
        detailGridView.DataSource = dr

    End Sub

    Protected Sub gridCmCoSe_BeforePerformDataSelect(sender As Object, e As EventArgs)
        'Session("gridCOD_CLASSE_MECANICA") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim detailGridView As ASPxGridView = CType(sender, ASPxGridView)

        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        conn.Open()

        Dim cmd As New OracleCommand("SELECT ROWNUM, A.* FROM (SELECT R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL, R.COD_SETOR, R.DSC_SETOR, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'BASICA') BASICA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'RAPIDA') RAPIDA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'OFICINA') OFICINA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'VOLANTE') VOLANTE, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'EXTERNA' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.LOCAL IN ('OFICINA'))) EXTERNA, (SELECT COUNT(DISTINCT RB.NUMERO_EQUIPAMENTO_FROTA) FROM BI4T.V_RESUMO_OFICINA RB WHERE RB.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND RB.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND RB.COD_SETOR = R.COD_SETOR AND LOCAL = 'EXTERNA/UAM' AND RB.NUMERO_EQUIPAMENTO_FROTA NOT IN (SELECT RB2.NUMERO_EQUIPAMENTO_FROTA FROM BI4T.V_RESUMO_OFICINA RB2 WHERE RB2.COD_CLASSE_MECANICA = RB.COD_CLASSE_MECANICA AND RB2.LOCAL IN ('OFICINA', 'EXTERNA'))) EXTERNA_UAM, COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA) TOTAL, ROUND((((SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND X.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND X.COD_SETOR = R.COD_SETOR) - COUNT(DISTINCT R.NUMERO_EQUIPAMENTO_FROTA)) * 100) / (SELECT SUM(X.QTDE_EQUIP) FROM BI4T.V_RESUMO_OFICINA_DISP X WHERE X.COD_CLASSE_MECANICA = R.COD_CLASSE_MECANICA AND X.COD_CLASSE_OPERACIONAL = R.COD_CLASSE_OPERACIONAL AND X.COD_SETOR = R.COD_SETOR), 1) DISP FROM BI4T.V_RESUMO_OFICINA R WHERE R.COD_CLASSE_MECANICA = :p0 AND R.COD_CLASSE_OPERACIONAL = :p1 GROUP BY R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL, R.COD_SETOR, R.DSC_SETOR ORDER BY R.COD_CLASSE_MECANICA, R.DSC_CLASSE_MECANICA, R.COD_CLASSE_OPERACIONAL, R.DSC_CLASSE_OPERACIONAL, R.COD_SETOR, R.DSC_SETOR) A", conn) With {.CommandType = CommandType.Text}
        cmd.Parameters.Add(":p0", OracleDbType.Int32).Value = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue().ToString.Split("|")(0)
        cmd.Parameters.Add(":p1", OracleDbType.Int32).Value = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue().ToString.Split("|")(1)

        Dim dr As OracleDataReader = cmd.ExecuteReader()

        detailGridView.DataSourceID = ""
        detailGridView.DataSource = dr
    End Sub

    Dim totalEQUIP As Double = 0
    Dim totalEQUIPMANUT As Double = 0
    Protected Sub gridCm_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles gridCm.CustomSummaryCalculate
        Dim item As ASPxSummaryItem = TryCast(e.Item, ASPxSummaryItem)
        'If item.FieldName = "DISP" Then
        '    If e.SummaryProcess = CustomSummaryProcess.Start Then


        '        If ASPxGridView1.VisibleRowCount > 4 Then
        '            e.TotalValue = Convert.ToInt32(TryCast(ASPxGridView1.GetRow(3), DataRowView)("UnitPrice"))
        '            e.TotalValueReady = True
        '        End If
        '    End If
        'End If

        Dim currRow As Integer = e.RowHandle

        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            totalEQUIPMANUT += Convert.ToInt32(gridCm.GetRowValues(currRow, "TOTAL"))
        End If

        If item.FieldName = "DISP" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                totalEQUIP = 0
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                totalEQUIP += (Convert.ToInt32(gridCm.GetRowValues(currRow, "TOTAL")) * 100) / (100 - Convert.ToDouble(gridCm.GetRowValues(currRow, "DISP")))
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                e.TotalValue = 100 - (totalEQUIPMANUT * 100 / totalEQUIP)
            End If
        End If

    End Sub

    'Protected Sub DetailGridCmCo_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Page.IsCallback = False Then
    '        Dim detailGrid As DevExpress.Web.ASPxGridView = TryCast(sender, DevExpress.Web.ASPxGridView)
    '        Dim container As GridViewDetailRowTemplateContainer = detailGrid.NamingContainer
    '        detailGrid.ClientInstanceName = "detail_" + container.VisibleIndex.ToString()
    '    End If
    'End Sub

    Protected Sub gridDetalhe_DataBinding(sender As Object, e As EventArgs) Handles gridDetalhe.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        conn.Open()
        Dim cmd As OracleCommand = New OracleCommand()
        cmd.Connection = conn
        cmd.CommandText = "SELECT ROWNUM, A.* FROM BI4T.V_RESUMO_OFICINA A"
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()

        gridDetalhe.DataSource = dr


    End Sub

    Protected Sub gridDetalhe_AutoFilterCellEditorCreate(sender As Object, e As ASPxGridViewEditorCreateEventArgs) Handles gridDetalhe.AutoFilterCellEditorCreate
        If e.Column.FieldName = "DATAHORAPREVISTA" Then
            Dim combo As New ComboBoxProperties()
            e.EditorProperties = combo
        End If
    End Sub

    Protected Sub gridDetalhe_AutoFilterCellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs) Handles gridDetalhe.AutoFilterCellEditorInitialize
        If e.Column.FieldName = "DATAHORAPREVISTA" Then
            Dim combo As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            combo.ValueType = GetType(String)

            combo.Items.Add("Em atraso")
            combo.Items.Add("Em atraso > 2 dias")
            combo.Items.Add("Em atraso > 7 dias")
        End If
    End Sub

    Protected Sub gridDetalhe_ProcessColumnAutoFilter(sender As Object, e As ASPxGridViewAutoFilterEventArgs) Handles gridDetalhe.ProcessColumnAutoFilter
        If e.Column.FieldName <> "DATAHORAPREVISTA" Then
            Return
        End If
        If e.Kind = GridViewAutoFilterEventKind.ExtractDisplayText Then
            e.Value = Session("value").ToString()
            Return
        Else
            Dim start As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), [end] As DateTime = start
            Dim value As String = e.Value

            If value = "Em atraso" Then
                'start = start.Subtract(New TimeSpan(365, 0, 0, 0))
                [end] = [end].Subtract(New TimeSpan(1, 0, 0, 0))
            ElseIf value = "Em atraso > 2 dias" Then
                'start = start.Subtract(New TimeSpan(365, 0, 0, 0))
                [end] = [end].Subtract(New TimeSpan(3, 0, 0, 0))
            ElseIf value = "Em atraso > 7 dias" Then
                'start = start.Subtract(New TimeSpan(365, 0, 0, 0))
                [end] = [end].Subtract(New TimeSpan(8, 0, 0, 0))
            End If
            Session("value") = value

            e.Criteria = New GroupOperator(New BinaryOperator(e.Column.FieldName, [end], BinaryOperatorType.LessOrEqual))
            'e.Criteria = New GroupOperator(GroupOperatorType.[And], New BinaryOperator(e.Column.FieldName, start, BinaryOperatorType.GreaterOrEqual), New BinaryOperator(e.Column.FieldName, [end], BinaryOperatorType.Less))
        End If

    End Sub

    Private count As Int32 = 0
    Private list As List(Of String) = New List(Of String)()

    Protected Sub gridDetalhe_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles gridDetalhe.CustomSummaryCalculate
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            count = 0
        ElseIf e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            If Not list.Contains(e.FieldValue.ToString) Then
                count += 1
                list.Add(e.FieldValue.ToString)
            End If
        ElseIf e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            e.TotalValue = count
            list.Clear()
        End If
    End Sub
End Class