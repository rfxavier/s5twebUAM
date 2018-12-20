Imports Microsoft.AspNet.Identity
Imports Oracle.DataAccess.Client
Imports DevExpress.Web

Public Class cnEntCanaMobCaminhoesBalHora
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

            If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                Dim oradb As String = AppUtils.dbConnectionString

                Dim conn As OracleConnection = New OracleConnection(oradb)
                conn.Open()

                cmd = New OracleCommand("select NVL(MIN(to_date(CERC.CERC_DATAENTRADAB,'DD/MM/YYYY')), TO_DATE('01/01/' || TO_CHAR(SYSDATE,'YYYY'),'DD/MM/YYYY')) CERC_DATAENTRADAB from SISAGRI.CERTIFICADO_CANA CERC where CERC.SAFRA = " & Now.Year.ToString, conn) With {.CommandType = CommandType.Text}

                Dim dr As OracleDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()

                    ASPxDataRef.MinDate = CDate(dr.Item("CERC_DATAENTRADAB"))
                End If

                conn.Close()

                ASPxDataRef.MaxDate = New Date(Now.Year, Now.Month, Now.Day)
                ASPxDataRef.Date = Now 'New Date(2014, 10, 4) 'Now
            End If

        End If

        'If ASPxCbPanel.IsCallback Then
        '    'É CALLBACK DO PANEL, ZERA O hfFrenteAtual E hfCodPropAtual PARA TAMBÉM ZERAR O GRID DE CAMINHOES E VIAGENS ASPxGridViewCaminhaoViagens
        '    ASPxHiddenField.Set("hfFrenteAtual", "")
        '    ASPxHiddenField.Set("hfCodPropAtual", "")

        '    ASPxGridViewFrentesProp.Selection.UnselectAll()
        'End If


        ASPxGridViewHorasFrentePrincipal.DataSourceID = ""
        ASPxGridViewHorasFrentePrincipal.DataSource = Nothing
        ASPxGridViewHorasFrentePrincipal.DataBind()

        ASPxGridViewFrentesProp.DataSourceID = ""
        ASPxGridViewFrentesProp.DataSource = Nothing
        ASPxGridViewFrentesProp.DataBind()

        If ASPxGridViewFrentesProp.VisibleRowCount > 0 Then
            ASPxGridViewFrentesProp.Selection.SelectRow(0)

            If ((Not ASPxHiddenField.Contains("hfFrenteAtual")) And (Not ASPxHiddenField.Contains("hfCodPropAtual"))) Or ASPxCbPanel.IsCallback Then
                ASPxHiddenField.Set("hfFrenteAtual", ASPxGridViewFrentesProp.GetRowValues(0, "FRENTE"))
                ASPxHiddenField.Set("hfCodPropAtual", ASPxGridViewFrentesProp.GetRowValues(0, "COD_PROP"))
            End If
        End If

        ASPxGridViewCaminhaoViagens.DataSourceID = ""
        ASPxGridViewCaminhaoViagens.DataSource = Nothing
        ASPxGridViewCaminhaoViagens.DataBind()

    End Sub

    Private intContagemHorasComViagem As Integer
    Private dblTotalViagens As Double
    Private boolUltimaHoraTemZeroViagens As Boolean
    Private Sub ASPxGridViewHorasFrentePrincipal_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles ASPxGridViewHorasFrentePrincipal.CustomSummaryCalculate
        Dim item As ASPxSummaryItem = TryCast(e.Item, ASPxSummaryItem)

        'Dim currRow As Integer = e.RowHandle

        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
        '    If ASPxGridViewHorasFrentePrincipal.GetRowValues(currRow, "F1") > 0 Then
        '        intContagemHorasComViagem += 1
        '    End If
        'End If

        'If item.FieldName = "F1" Then
        '    If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
        '        dblTotalViagens = 0
        '    End If
        '    If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
        '        dblTotalViagens += Convert.ToInt32(ASPxGridViewHorasFrentePrincipal.GetRowValues(currRow, "F1"))
        '    End If
        '    If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
        '        If intContagemHorasComViagem > 0 Then
        '            e.TotalValue = dblTotalViagens / intContagemHorasComViagem
        '        Else
        '            e.TotalValue = 0
        '        End If
        '    End If
        'End If


        '******************
        'If item.FieldName <> "F1" Then
        '    Return
        'End If

        'If e.IsTotalSummary Then
        '    Dim totalValue As Integer = 0
        '    For i = 0 To ASPxGridViewHorasFrentePrincipal.VisibleRowCount
        '        totalValue += Convert.ToInt32(ASPxGridViewHorasFrentePrincipal.GetRowValues(i, "F1"))
        '    Next
        '    e.TotalValue = totalValue
        '    e.TotalValueReady = True
        'End If


        Dim currRow As Integer = e.RowHandle

        If item.FieldName = "F1" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("F1"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("F1")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If

        If item.FieldName = "F2" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("F2"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("F2")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If

        If item.FieldName = "F3" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("F3"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("F3")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If

        If item.FieldName = "F4" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("F4"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("F4")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If

        If item.FieldName = "F5" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("F5"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("F5")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If

        If item.FieldName = "F6" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("F6"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("F6")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If

        If item.FieldName = "F7" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("F7"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("F7")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If

        If item.FieldName = "F8" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("F8"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("F8")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If

        If item.FieldName = "F9" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("F9"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("F9")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If


        If item.FieldName = "F10" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("F10"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("F10")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If

        If item.FieldName = "TOTALcalc" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                intContagemHorasComViagem = 0
                dblTotalViagens = 0
                boolUltimaHoraTemZeroViagens = False
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                dblTotalViagens += Convert.ToInt16(e.GetValue("TOTALcalc"))
                intContagemHorasComViagem += 1
                If Convert.ToInt16(e.GetValue("TOTALcalc")) > 0 Then
                    boolUltimaHoraTemZeroViagens = False
                Else
                    boolUltimaHoraTemZeroViagens = True
                End If
            End If
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If boolUltimaHoraTemZeroViagens Then
                    intContagemHorasComViagem -= 1
                End If

                If intContagemHorasComViagem > 0 Then
                    e.TotalValue = dblTotalViagens / intContagemHorasComViagem
                Else
                    e.TotalValue = 0
                End If
            End If
        End If
    End Sub

    Private Sub ASPxGridViewHorasFrentePrincipal_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridViewHorasFrentePrincipal.DataBinding
        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim oradb As String = AppUtils.dbConnectionString

            Dim conn As OracleConnection = New OracleConnection(oradb)
            conn.Open()

            'cmd = New OracleCommand("SELECT AB.HORA, SUM(CASE WHEN (FRENTE = 1) THEN QTD_VIAGENS ELSE 0 END) AS F1, SUM(CASE WHEN (FRENTE = 2) THEN QTD_VIAGENS ELSE 0 END) AS F2, SUM(CASE WHEN (FRENTE = 3) THEN QTD_VIAGENS ELSE 0 END) AS F3, SUM(CASE WHEN (FRENTE = 4) THEN QTD_VIAGENS ELSE 0 END) AS F4, SUM(CASE WHEN (FRENTE = 5) THEN QTD_VIAGENS ELSE 0 END) AS F5, SUM(CASE WHEN (FRENTE = 6) THEN QTD_VIAGENS ELSE 0 END) AS F6, SUM(CASE WHEN (FRENTE = 7) THEN QTD_VIAGENS ELSE 0 END) AS F7, SUM(CASE WHEN (FRENTE = 8) THEN QTD_VIAGENS ELSE 0 END) AS F8, SUM(CASE WHEN (FRENTE = 9) THEN QTD_VIAGENS ELSE 0 END) AS F9, SUM(CASE WHEN (FRENTE = 10) THEN QTD_VIAGENS ELSE 0 END) AS F10, SUM(CASE WHEN (FRENTE BETWEEN 1 AND 10) THEN QTD_VIAGENS ELSE 0 END) AS TOTAL FROM (SELECT CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER) FRENTE, TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))) HORA, CERC.CERC_CODIGO_PROP COD_PROP, CERC.CERC_CODIGO_PROP || ' - ' || UPPER(PROP.PROP_DESCRICAO) PROPRIEDADE, CERC.CERC_NEQUIPAMENTO CAMINHAO, COUNT(DISTINCT CERC.CERC_CERTIFICADO) QTD_VIAGENS FROM SISAGRI.CERTIFICADO_CANA CERC, SISAGRI.TALHAO_LIBERACAO LIBE, SISAGRI.PROPRIEDADE_AGRICOLA PROP WHERE CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH AND (LIBE.LIBE_TIPO_CORTE = CERC.CERC_CODIGO_TIPT OR LIBE.LIBE_TIPO_CORTE IS NULL) AND CERC.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS AND CERC.CERC_CODIGO_PROP = PROP.PROP_CODIGO AND CERC.ID_NEGOCIOS = :p0 AND CERC.SAFRA = :p1 AND TRUNC(CERC.CERC_DATAENTRADAB) = TO_DATE(:p2, 'YYYYMMDD') GROUP BY CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER), TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))), CERC.CERC_CODIGO_PROP, CERC.CERC_CODIGO_PROP || ' - ' || UPPER(PROP.PROP_DESCRICAO), CERC.CERC_NEQUIPAMENTO) AB GROUP BY AB.HORA", conn) With {.CommandType = CommandType.Text}
            cmd = New OracleCommand("SELECT AB.HORA, SUM(CASE WHEN (FRENTE = 1) THEN QTD_VIAGENS ELSE 0 END) AS F1, SUM(CASE WHEN (FRENTE = 2) THEN QTD_VIAGENS ELSE 0 END) AS F2, SUM(CASE WHEN (FRENTE = 3) THEN QTD_VIAGENS ELSE 0 END) AS F3, SUM(CASE WHEN (FRENTE = 4) THEN QTD_VIAGENS ELSE 0 END) AS F4, SUM(CASE WHEN (FRENTE = 5) THEN QTD_VIAGENS ELSE 0 END) AS F5, SUM(CASE WHEN (FRENTE = 6) THEN QTD_VIAGENS ELSE 0 END) AS F6, SUM(CASE WHEN (FRENTE = 7) THEN QTD_VIAGENS ELSE 0 END) AS F7, SUM(CASE WHEN (FRENTE = 8) THEN QTD_VIAGENS ELSE 0 END) AS F8, SUM(CASE WHEN (FRENTE = 9) THEN QTD_VIAGENS ELSE 0 END) AS F9, SUM(CASE WHEN (FRENTE = 10) THEN QTD_VIAGENS ELSE 0 END) AS F10, SUM(CASE WHEN (FRENTE BETWEEN 1 AND 10) THEN QTD_VIAGENS ELSE 0 END) AS TOTAL FROM (SELECT CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER) FRENTE, TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))) HORA, COUNT(DISTINCT CERC.CERC_CERTIFICADO) QTD_VIAGENS FROM SISAGRI.CERTIFICADO_CANA CERC, SISAGRI.TALHAO_LIBERACAO LIBE, SISAGRI.PROPRIEDADE_AGRICOLA PROP WHERE CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH AND (LIBE.LIBE_TIPO_CORTE = CERC.CERC_CODIGO_TIPT OR LIBE.LIBE_TIPO_CORTE IS NULL) AND CERC.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS AND CERC.CERC_CODIGO_PROP = PROP.PROP_CODIGO AND CERC.ID_NEGOCIOS = :p0 AND CERC.SAFRA = :p1 AND TRUNC(CERC.CERC_DATAENTRADAB) = TO_DATE(:p2, 'YYYYMMDD') GROUP BY CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER), TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))) ) AB GROUP BY AB.HORA", conn) With {.CommandType = CommandType.Text}

            cmd.Parameters.Add(":p0", OracleDbType.Int16).Value = 1
            cmd.Parameters.Add(":p1", OracleDbType.Int16).Value = Convert.ToInt16(ASPxDataRef.Date.Year.ToString("0000"))
            cmd.parameters.add(":p2", OracleDbType.Varchar2).value = ASPxDataRef.Date.ToString("yyyyMMdd")

            Dim dr As OracleDataReader = cmd.ExecuteReader()

            ASPxGridViewHorasFrentePrincipal.DataSource = dr
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            ASPxGridViewHorasFrentePrincipal.DataSource = S5TUam.ENT_CAMBAL_PRINCIPALCollection.LoadAll
        End If

    End Sub

    Private Sub ASPxGridViewFrentesProp_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridViewFrentesProp.DataBinding
        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim oradb As String = AppUtils.dbConnectionString

            Dim conn As OracleConnection = New OracleConnection(oradb)
            conn.Open()

            cmd = New OracleCommand("SELECT ROWNUM, AX.* FROM ( SELECT AB.FRENTE, AB.COD_PROP, AB.PROPRIEDADE, SUM(QTD_VIAGENS) QTD_VIAGENS FROM (SELECT CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER) FRENTE, TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))) HORA, CERC.CERC_CODIGO_PROP COD_PROP, CERC.CERC_CODIGO_PROP ||' - '|| UPPER(PROP.PROP_DESCRICAO) PROPRIEDADE, CERC.CERC_NEQUIPAMENTO CAMINHAO, COUNT(DISTINCT CERC.CERC_CERTIFICADO) QTD_VIAGENS FROM SISAGRI.CERTIFICADO_CANA CERC, SISAGRI.TALHAO_LIBERACAO LIBE, SISAGRI.PROPRIEDADE_AGRICOLA PROP WHERE CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH AND (LIBE.LIBE_TIPO_CORTE = CERC.CERC_CODIGO_TIPT OR LIBE.LIBE_TIPO_CORTE IS NULL) AND CERC.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS AND CERC.CERC_CODIGO_PROP = PROP.PROP_CODIGO AND CERC.ID_NEGOCIOS = :p0 AND CERC.SAFRA = :p1 AND TRUNC(CERC.CERC_DATAENTRADAB) = TO_DATE(:p2, 'YYYYMMDD') GROUP BY CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER), TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))), CERC.CERC_CODIGO_PROP, CERC.CERC_CODIGO_PROP ||' - '|| UPPER(PROP.PROP_DESCRICAO), CERC.CERC_NEQUIPAMENTO) AB GROUP BY AB.FRENTE, AB.COD_PROP, AB.PROPRIEDADE ORDER BY AB.FRENTE, AB.COD_PROP) AX ORDER BY AX.FRENTE, AX.PROPRIEDADE", conn) With {.CommandType = CommandType.Text}

            cmd.Parameters.Add(":p0", OracleDbType.Int16).Value = 1
            cmd.Parameters.Add(":p1", OracleDbType.Int16).Value = Convert.ToInt16(ASPxDataRef.Date.Year.ToString("0000"))
            cmd.parameters.add(":p2", OracleDbType.Varchar2).value = ASPxDataRef.Date.ToString("yyyyMMdd")

            Dim dr As OracleDataReader = cmd.ExecuteReader()

            ASPxGridViewFrentesProp.DataSource = dr
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            ASPxGridViewFrentesProp.DataSource = S5TUam.ENT_CAMBAL_FRENTESPROPCollection.LoadAll
        End If
    End Sub

    Private Sub ASPxGridViewCaminhaoViagens_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridViewCaminhaoViagens.DataBinding
        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            'hf.Set("hfFrenteAtual", data[0]);
            '             hf.Set("hfCodPropAtual", data[1]);
            '             hf.Set("hfDataRefAtual", cbDataRef.GetValue());

            Dim strFrenteAtual As String = String.Empty
            Dim strCodigoPropAtual As String = String.Empty
            Dim dtDataRef As Date = Nothing

            If ASPxHiddenField.Contains("hfFrenteAtual") And ASPxHiddenField.Contains("hfCodPropAtual") Then
                If ASPxHiddenField("hfFrenteAtual").ToString <> "" And ASPxHiddenField("hfCodPropAtual").ToString <> "" Then
                    Dim oradb As String = AppUtils.dbConnectionString

                    Dim conn As OracleConnection = New OracleConnection(oradb)
                    conn.Open()

                    strFrenteAtual = ASPxHiddenField("hfFrenteAtual")
                    strCodigoPropAtual = ASPxHiddenField("hfCodPropAtual")

                    If ASPxHiddenField.Contains("hfDataRefAtual") Then
                        dtDataRef = CDate(ASPxHiddenField("hfDataRefAtual"))
                    Else
                        dtDataRef = ASPxDataRef.Date
                    End If

                    cmd = New OracleCommand("SELECT ROWNUM, AX.* FROM ( SELECT AB.FRENTE, AB.COD_PROP, AB.CAMINHAO, SUM(QTD_VIAGENS) QTD_VIAGENS FROM (SELECT CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER) FRENTE, TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))) HORA, CERC.CERC_CODIGO_PROP COD_PROP, CERC.CERC_CODIGO_PROP ||' - '|| UPPER(PROP.PROP_DESCRICAO) PROPRIEDADE, CERC.CERC_NEQUIPAMENTO CAMINHAO, COUNT(DISTINCT CERC.CERC_CERTIFICADO) QTD_VIAGENS FROM SISAGRI.CERTIFICADO_CANA CERC, SISAGRI.TALHAO_LIBERACAO LIBE, SISAGRI.PROPRIEDADE_AGRICOLA PROP WHERE CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH AND (LIBE.LIBE_TIPO_CORTE = CERC.CERC_CODIGO_TIPT OR LIBE.LIBE_TIPO_CORTE IS NULL) AND CERC.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS AND CERC.CERC_CODIGO_PROP = PROP.PROP_CODIGO AND CERC.ID_NEGOCIOS = :parIdNegocios AND CERC.SAFRA = :parSafra AND TRUNC(CERC.CERC_DATAENTRADAB) = TO_DATE(:parDataRef, 'YYYYMMDD') AND CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER) = :parFrente AND CERC.CERC_CODIGO_PROP = :parCodigoProp GROUP BY CAST(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS, LIBE.LIBE_DATA, LIBE.LIBE_ID_TALH, LIBE.LIBE_TIPO_CORTE, CERC.CERC_DATAENTRADAB) AS INTEGER), TO_NUMBER(TRIM(TO_CHAR(CERC.CERC_DATAENTRADAB, 'HH24'))), CERC.CERC_CODIGO_PROP, CERC.CERC_CODIGO_PROP ||' - '|| UPPER(PROP.PROP_DESCRICAO), CERC.CERC_NEQUIPAMENTO) AB GROUP BY AB.FRENTE, AB.COD_PROP, AB.CAMINHAO ORDER BY AB.FRENTE, AB.COD_PROP, AB.CAMINHAO) AX", conn) With {.CommandType = CommandType.Text}

                    cmd.Parameters.Add(":parIdNegocios", OracleDbType.Int16).Value = 1
                    cmd.Parameters.Add(":parSafra", OracleDbType.Int16).Value = Convert.ToInt16(ASPxDataRef.Date.Year.ToString("0000"))
                    cmd.parameters.add(":parDataRef", OracleDbType.Varchar2).value = dtDataRef.ToString("yyyyMMdd")
                    cmd.parameters.add(":parFrente", OracleDbType.Int16).value = Convert.ToInt16(strFrenteAtual)
                    cmd.parameters.add(":parCodigoProp", OracleDbType.Int16).value = Convert.ToInt16(strCodigoPropAtual)

                    Dim dr As OracleDataReader = cmd.ExecuteReader()

                    ASPxGridViewCaminhaoViagens.DataSource = dr
                End If
            End If
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            ASPxGridViewCaminhaoViagens.DataSource = S5TUam.ENT_CAMBAL_CAMINHAOVIAGENSCollection.LoadAll
        End If
    End Sub

    Private Sub ASPxGridViewHorasFrentePrincipal_CustomUnboundColumnData(sender As Object, e As DevExpress.Web.ASPxGridViewColumnDataEventArgs) Handles ASPxGridViewHorasFrentePrincipal.CustomUnboundColumnData
        If e.Column.FieldName = "HORAFAIXAcalc" Then
            If e.GetListSourceFieldValue("HORA").ToString = 23 Then
                e.Value = "23-00"
            Else
                e.Value = e.GetListSourceFieldValue("HORA").ToString.PadLeft(2, "0") & "-" & Convert.ToString(Convert.ToInt16(e.GetListSourceFieldValue("HORA")) + 1).PadLeft(2, "0")
            End If
        ElseIf e.Column.FieldName = "SUBGRUPOcalc" Then
            If Convert.ToInt16(e.GetListSourceFieldValue("HORA")) >= 0 And Convert.ToInt16(e.GetListSourceFieldValue("HORA")) <= 7 Then
                e.Value = "01"
            ElseIf Convert.ToInt16(e.GetListSourceFieldValue("HORA")) >= 8 And Convert.ToInt16(e.GetListSourceFieldValue("HORA")) <= 15 Then
                e.Value = "02"
            ElseIf Convert.ToInt16(e.GetListSourceFieldValue("HORA")) >= 16 And Convert.ToInt16(e.GetListSourceFieldValue("HORA")) <= 23 Then
                e.Value = "03"
            End If
        ElseIf e.Column.FieldName = "TOTALcalc" Then
            e.Value = Convert.ToInt16(e.GetListSourceFieldValue("F1")) + _
                      Convert.ToInt16(e.GetListSourceFieldValue("F2")) + _
                      Convert.ToInt16(e.GetListSourceFieldValue("F3")) + _
                      Convert.ToInt16(e.GetListSourceFieldValue("F4")) + _
                      Convert.ToInt16(e.GetListSourceFieldValue("F5")) + _
                      Convert.ToInt16(e.GetListSourceFieldValue("F6")) + _
                      Convert.ToInt16(e.GetListSourceFieldValue("F7")) + _
                      Convert.ToInt16(e.GetListSourceFieldValue("F8")) + _
                      Convert.ToInt16(e.GetListSourceFieldValue("F9")) + _
                      Convert.ToInt16(e.GetListSourceFieldValue("F10"))
        End If
    End Sub

    Private Sub ASPxGridViewHorasFrentePrincipal_HtmlRowPrepared(sender As Object, e As DevExpress.Web.ASPxGridViewTableRowEventArgs) Handles ASPxGridViewHorasFrentePrincipal.HtmlRowPrepared
        Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
        If grid.GroupCount = 0 Then
            Return
        End If
        If e.Row.Cells.Count > 1 Then
            e.Row.Cells(grid.GroupCount - 1).Visible = False
            e.Row.Cells(grid.GroupCount).ColumnSpan = 2
        End If

    End Sub

    Private Sub ASPxGridViewHorasFrentePrincipal_HtmlRowCreated(sender As Object, e As ASPxGridViewTableRowEventArgs) Handles ASPxGridViewHorasFrentePrincipal.HtmlRowCreated
        If e.RowType = GridViewRowType.Group Then
            e.Row.Visible = False
        End If
    End Sub
End Class