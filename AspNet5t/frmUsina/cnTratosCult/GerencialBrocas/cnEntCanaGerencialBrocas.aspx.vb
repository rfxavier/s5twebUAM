Imports DevExpress.Web
Imports DevExpress.Data.Filtering
Imports Microsoft.AspNet.Identity
Imports Oracle.DataAccess.Client

Public Class cnEntCanaGerencialBrocas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
            ASPxChkSemControle.Checked = True
        End If

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = AppUtils.dbConnectionString

            Dim oradb As String = String.Format(oradbConn)

            If Not Page.IsPostBack Then
                'SAFRAS
                Dim Safras As New List(Of String)
                ASPxComboSafra.Items.Clear()

                Dim drSafras As OracleDataReader = Nothing

                Try
                    conn = New OracleConnection(oradb)
                    conn.Open()

                    Dim cmdSafras As New OracleCommand("select distinct talh_safra FROM BI4T.GERENCIAL_BROCA order by talh_safra DESC", conn) With {.CommandType = CommandType.Text}

                    drSafras = cmdSafras.ExecuteReader()
                    If drSafras.HasRows Then
                        Do While drSafras.Read
                            ASPxComboSafra.Items.Add(drSafras.Item("talh_safra"))
                        Loop

                        drSafras.Close()
                    End If
                Finally
                    If (Not (drSafras) Is Nothing) Then
                        drSafras.Dispose()
                    End If
                End Try
            End If
        End If


        ASPxGridView1.DataSourceID = ""
        ASPxGridView1.DataBind()

        ASPxGridView2.DataSourceID = ""
        ASPxGridView2.DataBind()

        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            ASPxGridView1.ExpandAll()
        End If
    End Sub

    Private Sub ASPxGridView1_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView1.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        conn.Open()
        Dim cmd As OracleCommand = New OracleCommand()
        cmd.Connection = conn

        If ASPxChkSemControle.Checked Then
            cmd.CommandText = String.Format("SELECT ROWNUM, ID_NEGOCIOS, TALH_SAFRA, TALH_CODIGO_PROP, PROP_DESCRICAO, TALH_CODIGO, TALH_ID, TALH_NCORTE, TALH_CODIGO_VARI, VARI_DESCRICAO, INDICE_SF_ANT, CANA_ENT_SF_ANT, AREA_LEVANT_1, DATA_LEVANT_1, DATA_BIOLOGICO_1, DATA_QUIMICO_1, DATA_BIOLOGICO_1_AUX, DATA_QUIMICO_1_AUX, IND_MENOR1CM_HA_1, IND_GDE_MEDIA_HA_1, NRO_INDIV_HA_1, DECODE(SITUACAO_1, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT1, SITUACAO_1, DIAS_1, AREA_LEVANT_2, DATA_LEVANT_2, DATA_BIOLOGICO_2, DATA_QUIMICO_2, DATA_BIOLOGICO_2_AUX, DATA_QUIMICO_2_AUX, IND_MENOR1CM_HA_2, IND_GDE_MEDIA_HA_2, NRO_INDIV_HA_2, DECODE(SITUACAO_2, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT2, SITUACAO_2, DIAS_2, AREA_LEVANT_3, DATA_LEVANT_3, DATA_BIOLOGICO_3, DATA_QUIMICO_3, DATA_BIOLOGICO_3_AUX, DATA_QUIMICO_3_AUX, IND_MENOR1CM_HA_3, IND_GDE_MEDIA_HA_3, NRO_INDIV_HA_3, DECODE(SITUACAO_3, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT3, SITUACAO_3, DIAS_3, AREA_LEVANT_4, DATA_LEVANT_4, DATA_BIOLOGICO_4, DATA_QUIMICO_4, DATA_BIOLOGICO_4_AUX, DATA_QUIMICO_4_AUX, IND_MENOR1CM_HA_4, IND_GDE_MEDIA_HA_4, NRO_INDIV_HA_4, DECODE(SITUACAO_4, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT4, SITUACAO_4, DIAS_4, DATA_REFERENCIA, SITUACAO_REFERENCIA, DECODE(SITUACAO_REFERENCIA, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SITREF FROM BI4T.GERENCIAL_BROCA WHERE TALH_SAFRA = {0} AND SITUACAO_REFERENCIA <> 'IC'", ASPxComboSafra.SelectedValue)
        Else
            cmd.CommandText = String.Format("SELECT ROWNUM, ID_NEGOCIOS, TALH_SAFRA, TALH_CODIGO_PROP, PROP_DESCRICAO, TALH_CODIGO, TALH_ID, TALH_NCORTE, TALH_CODIGO_VARI, VARI_DESCRICAO, INDICE_SF_ANT, CANA_ENT_SF_ANT, AREA_LEVANT_1, DATA_LEVANT_1, DATA_BIOLOGICO_1, DATA_QUIMICO_1, DATA_BIOLOGICO_1_AUX, DATA_QUIMICO_1_AUX, IND_MENOR1CM_HA_1, IND_GDE_MEDIA_HA_1, NRO_INDIV_HA_1, DECODE(SITUACAO_1, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT1, SITUACAO_1, DIAS_1, AREA_LEVANT_2, DATA_LEVANT_2, DATA_BIOLOGICO_2, DATA_QUIMICO_2, DATA_BIOLOGICO_2_AUX, DATA_QUIMICO_2_AUX, IND_MENOR1CM_HA_2, IND_GDE_MEDIA_HA_2, NRO_INDIV_HA_2, DECODE(SITUACAO_2, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT2, SITUACAO_2, DIAS_2, AREA_LEVANT_3, DATA_LEVANT_3, DATA_BIOLOGICO_3, DATA_QUIMICO_3, DATA_BIOLOGICO_3_AUX, DATA_QUIMICO_3_AUX, IND_MENOR1CM_HA_3, IND_GDE_MEDIA_HA_3, NRO_INDIV_HA_3, DECODE(SITUACAO_3, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT3, SITUACAO_3, DIAS_3, AREA_LEVANT_4, DATA_LEVANT_4, DATA_BIOLOGICO_4, DATA_QUIMICO_4, DATA_BIOLOGICO_4_AUX, DATA_QUIMICO_4_AUX, IND_MENOR1CM_HA_4, IND_GDE_MEDIA_HA_4, NRO_INDIV_HA_4, DECODE(SITUACAO_4, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SIT4, SITUACAO_4, DIAS_4, DATA_REFERENCIA, SITUACAO_REFERENCIA, DECODE(SITUACAO_REFERENCIA, NULL, '0', 'IC', '1', 'CQP', '2', 'CQA', '3', 'CBP', '4', 'CBA', '5', '0') SITREF FROM BI4T.GERENCIAL_BROCA WHERE TALH_SAFRA = {0}", ASPxComboSafra.SelectedValue)
        End If

        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()

        ASPxGridView1.DataSource = dr
    End Sub

    Private Sub ASPxGridView2_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView2.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        conn.Open()
        Dim cmd As OracleCommand = New OracleCommand()
        cmd.Connection = conn
        cmd.CommandText = String.Format("SELECT 1 ROWPK, NVL(SUM(AA.AREA_LEVANT_1), 0) TOTAL_LEVANT, NVL(SUM(CASE WHEN (AA.DATA_LEVANT_1 IS NULL) THEN NULL ELSE AA.AREA_LEVANT_1 END), 0) AS TOTAL_LEVANT_1, NVL(SUM(CASE WHEN (AA.NRO_INDIV_HA_1 < 1500) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS SITUACAO_IC_1, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_1 IS NULL) AND (AA.DATA_BIOLOGICO_1 IS NOT NULL) AND (AA.DATA_BIOLOGICO_1 <= (AA.DATA_LEVANT_1 + 5))) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS SITUACAO_CBP_1, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_1 IS NULL) AND (AA.DATA_BIOLOGICO_1 IS NOT NULL) AND (AA.DATA_BIOLOGICO_1 > (AA.DATA_LEVANT_1 + 5))) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS SITUACAO_CBA_1, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_1 IS NULL) AND (AA.DATA_QUIMICO_1 IS NOT NULL) AND (AA.DATA_QUIMICO_1 <= (AA.DATA_LEVANT_1 + 3))) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS SITUACAO_CQP_1, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_1 IS NULL) AND (AA.DATA_QUIMICO_1 IS NOT NULL) AND (AA.DATA_QUIMICO_1 > (AA.DATA_LEVANT_1 + 3))) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS SITUACAO_CQA_1, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_1 IS NOT NULL) AND (AA.DATA_QUIMICO_1 IS NOT NULL)) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS CTRL_QUIM_BIO_1, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_1 IS NOT NULL) AND (AA.NRO_INDIV_HA_1 < 1500) AND (AA.DATA_QUIMICO_1 IS NULL) AND (AA.DATA_BIOLOGICO_1 IS NULL)) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MENOR_1, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_1 IS NOT NULL) AND (AA.NRO_INDIV_HA_1 >= 1500) AND (AA.DATA_QUIMICO_1 IS NULL) AND (AA.DATA_BIOLOGICO_1 IS NULL)) THEN AA.AREA_LEVANT_1 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MAIOR_1, NVL(SUM(CASE WHEN (AA.DATA_LEVANT_2 IS NULL) THEN NULL ELSE AA.AREA_LEVANT_2 END), 0) AS TOTAL_LEVANT_2, NVL(SUM(CASE WHEN (AA.NRO_INDIV_HA_2 < 1500) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_IC_2, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_2 IS NULL) AND (AA.DATA_BIOLOGICO_2 IS NOT NULL) AND (AA.DATA_BIOLOGICO_2 <= (AA.DATA_LEVANT_2 + 5))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CBP_2, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_2 IS NULL) AND (AA.DATA_BIOLOGICO_2 IS NOT NULL) AND (AA.DATA_BIOLOGICO_2 > (AA.DATA_LEVANT_2 + 5))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CBA_2, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_2 IS NULL) AND (AA.DATA_QUIMICO_2 IS NOT NULL) AND (AA.DATA_QUIMICO_2 <= (AA.DATA_LEVANT_2 + 3))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CQP_2, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_2 IS NULL) AND (AA.DATA_QUIMICO_2 IS NOT NULL) AND (AA.DATA_QUIMICO_2 > (AA.DATA_LEVANT_2 + 3))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CQA_2, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_2 IS NOT NULL) AND (AA.DATA_QUIMICO_2 IS NOT NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS CTRL_QUIM_BIO_2, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_2 IS NOT NULL) AND (AA.NRO_INDIV_HA_2 < 1500) AND (AA.DATA_QUIMICO_2 IS NULL) AND (AA.DATA_BIOLOGICO_2 IS NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MENOR_2, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_2 IS NOT NULL) AND (AA.NRO_INDIV_HA_2 >= 1500) AND (AA.DATA_QUIMICO_2 IS NULL) AND (AA.DATA_BIOLOGICO_2 IS NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MAIOR_2, NVL(SUM(CASE WHEN (AA.DATA_LEVANT_3 IS NULL) THEN NULL ELSE AA.AREA_LEVANT_2 END), 0) AS TOTAL_LEVANT_3, NVL(SUM(CASE WHEN (AA.NRO_INDIV_HA_3 < 1500) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_IC_3, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_3 IS NULL) AND (AA.DATA_BIOLOGICO_3 IS NOT NULL) AND (AA.DATA_BIOLOGICO_3 <= (AA.DATA_LEVANT_3 + 5))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CBP_3, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_3 IS NULL) AND (AA.DATA_BIOLOGICO_3 IS NOT NULL) AND (AA.DATA_BIOLOGICO_3 > (AA.DATA_LEVANT_3 + 5))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CBA_3, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_3 IS NULL) AND (AA.DATA_QUIMICO_3 IS NOT NULL) AND (AA.DATA_QUIMICO_3 <= (AA.DATA_LEVANT_3 + 3))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CQP_3, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_3 IS NULL) AND (AA.DATA_QUIMICO_3 IS NOT NULL) AND (AA.DATA_QUIMICO_3 > (AA.DATA_LEVANT_3 + 3))) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS SITUACAO_CQA_3, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_3 IS NOT NULL) AND (AA.DATA_QUIMICO_3 IS NOT NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS CTRL_QUIM_BIO_3, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_3 IS NOT NULL) AND (AA.NRO_INDIV_HA_3 < 1500) AND (AA.DATA_QUIMICO_3 IS NULL) AND (AA.DATA_BIOLOGICO_3 IS NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MENOR_3, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_3 IS NOT NULL) AND (AA.NRO_INDIV_HA_3 >= 1500) AND (AA.DATA_QUIMICO_3 IS NULL) AND (AA.DATA_BIOLOGICO_3 IS NULL)) THEN AA.AREA_LEVANT_2 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MAIOR_3, NVL(SUM(CASE WHEN (AA.DATA_LEVANT_4 IS NULL) THEN NULL ELSE AA.AREA_LEVANT_4 END), 0) AS TOTAL_LEVANT_4, NVL(SUM(CASE WHEN (AA.NRO_INDIV_HA_4 < 1500) THEN AA.AREA_LEVANT_4 ELSE NULL END), 0) AS SITUACAO_IC_4, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_4 IS NULL) AND (AA.DATA_BIOLOGICO_4 IS NOT NULL) AND (AA.DATA_BIOLOGICO_4 <= (AA.DATA_LEVANT_4 + 5))) THEN AA.AREA_LEVANT_4 ELSE NULL END), 0) AS SITUACAO_CBP_4, NVL(SUM(CASE WHEN ((AA.DATA_QUIMICO_4 IS NULL) AND (AA.DATA_BIOLOGICO_4 IS NOT NULL) AND (AA.DATA_BIOLOGICO_4 > (AA.DATA_LEVANT_4 + 5))) THEN AA.AREA_LEVANT_4 ELSE NULL END), 0) AS SITUACAO_CBA_4, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_4 IS NULL) AND (AA.DATA_QUIMICO_4 IS NOT NULL) AND (AA.DATA_QUIMICO_4 <= (AA.DATA_LEVANT_4 + 3))) THEN AA.AREA_LEVANT_4 ELSE NULL END), 0) AS SITUACAO_CQP_4, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_4 IS NULL) AND (AA.DATA_QUIMICO_4 IS NOT NULL) AND (AA.DATA_QUIMICO_4 > (AA.DATA_LEVANT_4 + 3))) THEN AA.AREA_LEVANT_4 ELSE NULL END), 0) AS SITUACAO_CQA_4, NVL(SUM(CASE WHEN ((AA.DATA_BIOLOGICO_4 IS NOT NULL) AND (AA.DATA_QUIMICO_4 IS NOT NULL)) THEN AA.AREA_LEVANT_4 ELSE NULL END), 0) AS CTRL_QUIM_BIO_4, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_4 IS NOT NULL) AND (AA.NRO_INDIV_HA_4 < 1500) AND (AA.DATA_QUIMICO_4 IS NULL) AND (AA.DATA_BIOLOGICO_4 IS NULL)) THEN AA.AREA_LEVANT_4 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MENOR_4, NVL(SUM(CASE WHEN ((AA.DATA_LEVANT_4 IS NOT NULL) AND (AA.NRO_INDIV_HA_4 >= 1500) AND (AA.DATA_QUIMICO_4 IS NULL) AND (AA.DATA_BIOLOGICO_4 IS NULL)) THEN AA.AREA_LEVANT_4 ELSE NULL END), 0) AS NAO_FEZ_INTERV_MAIOR_4, (SELECT SUM(NVL(AB.AREA_CTRL_QUIMICO, 0)) FROM BI4T.GERENCIAL_BROCA_SEM_LEVANT AB WHERE AB.ID_NEGOCIOS = AA.ID_NEGOCIOS AND AB.DT_ATUALIZACAO = AA.DT_ATUALIZACAO) AREA_CTRL_Q_SEM_LEVANT, (SELECT SUM(NVL(AB.AREA_CTRL_BIOLOGICO, 0)) FROM BI4T.GERENCIAL_BROCA_SEM_LEVANT AB WHERE AB.ID_NEGOCIOS = AA.ID_NEGOCIOS AND AB.DT_ATUALIZACAO = AA.DT_ATUALIZACAO) AREA_CTRL_B_SEM_LEVANT FROM BI4T.GERENCIAL_BROCA AA WHERE AA.TALH_SAFRA = {0} GROUP BY AA.ID_NEGOCIOS, AA.DT_ATUALIZACAO", ASPxComboSafra.SelectedValue)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()

        'If dr.HasRows Then
        '    Do While dr.Read
        '        MsgBox(dr.Item("AREA_CTRL_B_SEM_LEVANT"))
        '    Loop

        '    dr.Close()
        'End If


        ASPxGridView2.DataSource = dr
    End Sub

    Private Sub ASPxGridView1_AutoFilterCellEditorCreate(sender As Object, e As DevExpress.Web.ASPxGridViewEditorCreateEventArgs) Handles ASPxGridView1.AutoFilterCellEditorCreate
        If e.Column.FieldName = "SITUACAO_REFERENCIA" Or _
            e.Column.FieldName = "SITUACAO_1" Or _
            e.Column.FieldName = "SITUACAO_2" Or _
            e.Column.FieldName = "SITUACAO_3" Or _
            e.Column.FieldName = "SITUACAO_4" Then
            Dim combo As New ComboBoxProperties()
            'combo.RenderIFrameForPopupElements = DevExpress.Utils.DefaultBoolean.True
            e.EditorProperties = combo
        End If
    End Sub

    Private Sub ASPxGridView1_AutoFilterCellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs) Handles ASPxGridView1.AutoFilterCellEditorInitialize
        If e.Column.FieldName = "SITUACAO_REFERENCIA" Or _
            e.Column.FieldName = "SITUACAO_1" Or _
            e.Column.FieldName = "SITUACAO_2" Or _
            e.Column.FieldName = "SITUACAO_3" Or _
            e.Column.FieldName = "SITUACAO_4" Then
            Dim combo As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            combo.ValueType = GetType(String)

            combo.Items.Add("Infestação Controlada")
            combo.Items.Add("Ctrl. Químico Prazo")
            combo.Items.Add("Ctrl. Químico Atraso")
            combo.Items.Add("Ctrl. Biológico Prazo")
            combo.Items.Add("Ctrl. Biológico Atraso")
        End If

    End Sub

    Private Sub ASPxGridView1_ProcessColumnAutoFilter(sender As Object, e As ASPxGridViewAutoFilterEventArgs) Handles ASPxGridView1.ProcessColumnAutoFilter
        If e.Column.FieldName <> "SITUACAO_REFERENCIA" And _
            e.Column.FieldName <> "SITUACAO_1" And _
            e.Column.FieldName <> "SITUACAO_2" And _
            e.Column.FieldName <> "SITUACAO_3" And _
            e.Column.FieldName <> "SITUACAO_4" Then
            Return
        End If
        If e.Kind = GridViewAutoFilterEventKind.ExtractDisplayText Then
            e.Value = Session("valuecb").ToString()
            Return
        Else
            Dim strSITUACAO As String = String.Empty
            Dim value As String = e.Value

            If value = "Infestação Controlada" Then
                strSITUACAO = "IC"
            ElseIf value = "Ctrl. Químico Prazo" Then
                strSITUACAO = "CQP"
            ElseIf value = "Ctrl. Químico Atraso" Then
                strSITUACAO = "CQA"
            ElseIf value = "Ctrl. Biológico Prazo" Then
                strSITUACAO = "CBP"
            ElseIf value = "Ctrl. Biológico Atraso" Then
                strSITUACAO = "CBA"
            End If
            Session("valuecb") = value

            e.Criteria = New GroupOperator(New BinaryOperator(e.Column.FieldName, strSITUACAO, BinaryOperatorType.Equal))
        End If
    End Sub

    Protected Function GetTotalSummaryValue(summary As String) As Object
        Dim summaryItem As ASPxSummaryItem = ASPxGridView2.TotalSummary.First(Function(i) i.Tag = summary)
        Return ASPxGridView2.GetTotalSummaryValue(summaryItem)
    End Function

End Class