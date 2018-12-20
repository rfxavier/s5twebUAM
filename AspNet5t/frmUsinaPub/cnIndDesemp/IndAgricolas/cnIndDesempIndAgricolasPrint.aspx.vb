Imports Oracle.DataAccess.Client
Imports Microsoft.AspNet.Identity
Imports DevExpress.XtraGauges.Core.Drawing
Imports DevExpress.XtraGauges.Core.Base

Public Class cnIndDesempIndAgricolasPrint
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Header.DataBind()
        If Not (Page.IsCallback) And Not (Page.IsPostBack) Or ASPxCbPanel.IsCallback Or ASPxGridView2.IsCallback Then
            'LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = AppUtils.dbConnectionString

            Dim oradb As String = String.Format(oradbConn)

            'DATAS FECHAMENTO
            Dim DatasFechamento As New List(Of String)
            ASPxComboDataFechamento.Items.Clear()

            Dim drDatasFechamento As OracleDataReader = Nothing

            Try
                conn = New OracleConnection(oradb)
                conn.Open()

                'Dim cmdDatasFechamento As New OracleCommand("SELECT TO_CHAR(DATA_FECHAMENTO, 'DD/MM/YYYY') DATA_FECHAMENTO FROM BI4T.INDICADORES_AGRICOLA GROUP BY DATA_FECHAMENTO ORDER BY DATA_FECHAMENTO DESC", conn) With {.CommandType = CommandType.Text}
                Dim cmdDatasFechamento As New OracleCommand("SELECT TO_CHAR(DATA_FECHAMENTO, 'DD/MM/YYYY') DATA_FECHAMENTO FROM BI4T.INDICADORES_AGRICOLA WHERE DATA_FECHAMENTO >= TO_DATE('20/06/2015','DD/MM/YYYY') GROUP BY DATA_FECHAMENTO ORDER BY DATA_FECHAMENTO DESC", conn) With {.CommandType = CommandType.Text}

                drDatasFechamento = cmdDatasFechamento.ExecuteReader()
                If drDatasFechamento.HasRows Then
                    Do While drDatasFechamento.Read
                        ASPxComboDataFechamento.Items.Add(drDatasFechamento.Item("DATA_FECHAMENTO"))
                    Loop

                    drDatasFechamento.Close()
                End If
            Finally
                If (Not (drDatasFechamento) Is Nothing) Then
                    drDatasFechamento.Dispose()
                End If
            End Try

            If Not ASPxCbPanel.IsCallback Then
                ASPxComboDataFechamento.SelectedIndex = 0
            End If
            'ASPxGridView2.DataSourceID = ""
            'ASPxGridView2.DataSource = Nothing

            'GRUPO
            Dim Grupos As New List(Of String)
            ASPxComboGrupo.Items.Clear()

            Dim drGrupos As OracleDataReader = Nothing

            Try
                conn = New OracleConnection(oradb)
                conn.Open()

                Dim cmdGrupos As New OracleCommand("SELECT GRUPO FROM BI4T.INDICADORES_AGRICOLA WHERE DATA_FECHAMENTO = :p0 GROUP BY GRUPO ORDER BY GRUPO", conn) With {.CommandType = CommandType.Text}
                cmdGrupos.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Text

                drGrupos = cmdGrupos.ExecuteReader()
                If drGrupos.HasRows Then
                    ASPxComboGrupo.Items.Add("Todos os Grupos")

                    Do While drGrupos.Read
                        If Not IsDBNull(drGrupos.Item("GRUPO")) Then
                            ASPxComboGrupo.Items.Add(drGrupos.Item("GRUPO"))
                        End If
                    Loop

                    drGrupos.Close()
                End If
            Finally
                If (Not (drGrupos) Is Nothing) Then
                    drGrupos.Dispose()
                End If
            End Try

            If Not ASPxCbPanel.IsCallback Then
                'ESTÁ ENTRANDO PELA PRIMEIRA VEZ NA PÁGINA, NÃO É CALLBACK DO PANEL
                ASPxComboGrupo.SelectedIndex = 0
            Else
                'É CALLBACK DO PANEL, ZERA O hfFrenteTipoAtual PARA TAMBÉM ZERAR O GRID DE DETALHAMENTO POR EQUIPAMENTO ASPxGridView2
                ASPxHiddenField.Set("hfFrenteTipoAtual", "")
            End If


            'TEMPO APROVEITÁVEL
            Dim drTempoAprov As OracleDataReader = Nothing

            Try
                conn = New OracleConnection(oradb)
                conn.Open()

                Dim cmdTempoAprov As New OracleCommand(String.Format("SELECT SISAGRI.F_TEMPO_APROVEITAVEL_IND(1, F_DATA_INI_PERIODO_PRODUTIV(TO_DATE('21/' || TRIM(TO_CHAR(LAST_DAY(ADD_MONTHS('{0}', -1)),'MM/YYYY')),'DD/MM/YYYY')), TO_DATE('{0}', 'DD/MM/YYYY')) TEMPO_APROV FROM DUAL", ASPxComboDataFechamento.Value), conn) With {.CommandType = CommandType.Text}

                drTempoAprov = cmdTempoAprov.ExecuteReader()
                If drTempoAprov.HasRows Then
                    drTempoAprov.Read()

                    ASPxLabelTempoAprov.Text = String.Format(drTempoAprov.Item("TEMPO_APROV"), "{0:#,#0.0}") & " %"

                    drTempoAprov.Close()
                End If

            Finally
                If (Not (drTempoAprov) Is Nothing) Then
                    drTempoAprov.Dispose()
                End If
            End Try


            'FRENTES TIPOS
            Try
                conn = New OracleConnection(oradb)
                conn.Open()

                Dim cmd As New OracleCommand("SELECT V.ID_NEGOCIOS, V.USUARIO, V.FRENTE, V.TIPO, DECODE(NVL(V.FRENTE,0),0,V.TIPO,LPAD(V.FRENTE,3,'0')) FRENTETIPO from V_ACESSO_DET V WHERE V.USUARIO = :p0", conn) With {.CommandType = CommandType.Text}

                cmd.Parameters.Add(":p0", OracleDbType.Varchar2).Value = Context.User.Identity.Name.ToUpper

                Dim dr As OracleDataReader = Nothing
                Try
                    dr = cmd.ExecuteReader()
                    If dr.HasRows Then
                        Dim listaFrentes As New List(Of String)

                        'USUÁRIO TEM INDICAÇÃO DE FRENTES E/OU TIPOS
                        Do While dr.Read
                            listaFrentes.Add("'" & dr.Item("FRENTETIPO").ToString & "'")
                        Loop

                        ASPxHiddenField.Set("hfFrentesTipos", String.Join(",", listaFrentes.ToArray))
                    End If
                Finally
                    If (Not (dr) Is Nothing) Then
                        dr.Dispose()
                    End If
                End Try
            Catch ex As Exception

            End Try

            ASPxGridView1.DataSourceID = ""
            ASPxGridView1.DataBind()

            ASPxGridView2.DataSourceID = ""
            ASPxGridView2.DataSource = Nothing
            ASPxGridView2.DataBind()

            ASPxGridView2.SettingsText.Title = "Indicadores Agrícolas Por Equipamento"

            If ASPxHiddenField.Contains("hfFrenteTipoAtualDs") Then
                If ASPxHiddenField("hfFrenteTipoAtualDs").ToString <> "" Then
                    ASPxGridView2.SettingsText.Title &= " ( " & ASPxHiddenField("hfFrenteTipoAtualDs").ToString & " )"
                End If
            End If
        End If

    End Sub

    Protected Sub ASPxGridView1_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView1.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        Dim cmd As OracleCommand
        conn.Open()

        Dim strFrentesAtuais As String = String.Empty

        If ASPxHiddenField.Contains("hfFrentesTipos") Then
            strFrentesAtuais = ASPxHiddenField("hfFrentesTipos")
        End If

        If ASPxComboGrupo.SelectedIndex = 0 Then
            'TODOS OS GRUPOS

            'TEM FRENTES E/OU TIPOS INDICADOS
            If strFrentesAtuais <> String.Empty Then
                If CDate(ASPxComboDataFechamento.Value) <= New DateTime(2015, 6, 20, 0, 0, 0) Then
                    'QUERY VELHA
                    cmd = New OracleCommand(String.Format("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0),4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0),4) REALIZADO, ROUND(NVL(A.PERC, 0),4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0),4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0),4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) IN ({0}) AND A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and A.DATA_FECHAMENTO = :p0 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by A.frente, A.INDICADOR", strFrentesAtuais), conn) With {.CommandType = CommandType.Text}
                Else
                    'QUERY NOVA
                    cmd = New OracleCommand(String.Format("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0), 4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0), 4) REALIZADO, ROUND(NVL(A.PERC, 0), 4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0), 4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0), 4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C, SISAGRI.FRENTE_SERVICO_GRUPO D where decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) IN ({0}) AND A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) AND B.ID_NEGOCIOS = D.ID_NEGOCIOS (+) AND B.ID_FRENTE_SERVICO_GRUPO = D.ID_FRENTE_SERVICO_GRUPO (+) and A.DATA_FECHAMENTO = :p0 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by A.frente, A.INDICADOR", strFrentesAtuais), conn) With {.CommandType = CommandType.Text}
                End If

                cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
            Else
                'TODAS AS FRENTES E/OU TIPOS
                If CDate(ASPxComboDataFechamento.Value) <= New DateTime(2015, 6, 20, 0, 0, 0) Then
                    'QUERY VELHA
                    cmd = New OracleCommand("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0),4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0),4) REALIZADO, ROUND(NVL(A.PERC, 0),4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0),4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0),4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and A.DATA_FECHAMENTO = :p0 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by A.frente, A.INDICADOR", conn) With {.CommandType = CommandType.Text}
                Else
                    'QUERY NOVA
                    cmd = New OracleCommand("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0), 4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0), 4) REALIZADO, ROUND(NVL(A.PERC, 0), 4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0), 4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0), 4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C, SISAGRI.FRENTE_SERVICO_GRUPO D where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) AND B.ID_NEGOCIOS = D.ID_NEGOCIOS (+) AND B.ID_FRENTE_SERVICO_GRUPO = D.ID_FRENTE_SERVICO_GRUPO (+) and A.DATA_FECHAMENTO = :p0 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by A.frente, A.INDICADOR", conn) With {.CommandType = CommandType.Text}
                End If

                cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
            End If
        Else
            'GRUPO ESPECÍFICO

            'TEM FRENTES E/OU TIPOS INDICADOS
            If strFrentesAtuais <> String.Empty Then
                If CDate(ASPxComboDataFechamento.Value) <= New DateTime(2015, 6, 20, 0, 0, 0) Then
                    'QUERY VELHA
                    cmd = New OracleCommand(String.Format("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0),4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0),4) REALIZADO, ROUND(NVL(A.PERC, 0),4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0),4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0),4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) IN ({0}) AND A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and A.DATA_FECHAMENTO = :p0 and A.GRUPO = :p1 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by A.frente, A.INDICADOR", strFrentesAtuais), conn) With {.CommandType = CommandType.Text}
                Else
                    'QUERY NOVA
                    cmd = New OracleCommand(String.Format("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0), 4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0), 4) REALIZADO, ROUND(NVL(A.PERC, 0), 4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0), 4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0), 4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C, SISAGRI.FRENTE_SERVICO_GRUPO D where decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) IN ({0}) AND A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) AND B.ID_NEGOCIOS = D.ID_NEGOCIOS (+) AND B.ID_FRENTE_SERVICO_GRUPO = D.ID_FRENTE_SERVICO_GRUPO (+) and A.DATA_FECHAMENTO = :p0 and A.GRUPO = :p1 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by A.frente, A.INDICADOR", strFrentesAtuais), conn) With {.CommandType = CommandType.Text}
                End If


                cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
                cmd.Parameters.Add(":p1", OracleDbType.Varchar2).Value = ASPxComboGrupo.Value
            Else
                'TODAS AS FRENTES E/OU TIPOS
                If CDate(ASPxComboDataFechamento.Value) <= New DateTime(2015, 6, 20, 0, 0, 0) Then
                    'QUERY VELHA
                    cmd = New OracleCommand("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0),4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0),4) REALIZADO, ROUND(NVL(A.PERC, 0),4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0),4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0),4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and A.DATA_FECHAMENTO = :p0 and A.GRUPO = :p1 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by A.frente, A.INDICADOR", conn) With {.CommandType = CommandType.Text}
                Else
                    'QUERY NOVA
                    cmd = New OracleCommand("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0), 4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0), 4) REALIZADO, ROUND(NVL(A.PERC, 0), 4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0), 4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0), 4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C, SISAGRI.FRENTE_SERVICO_GRUPO D where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) AND B.ID_NEGOCIOS = D.ID_NEGOCIOS (+) AND B.ID_FRENTE_SERVICO_GRUPO = D.ID_FRENTE_SERVICO_GRUPO (+) and A.DATA_FECHAMENTO = :p0 and A.GRUPO = :p1 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by A.frente, A.INDICADOR", conn) With {.CommandType = CommandType.Text}
                End If

                cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
                cmd.Parameters.Add(":p1", OracleDbType.Varchar2).Value = ASPxComboGrupo.Value
            End If
        End If


        Dim dr As OracleDataReader = cmd.ExecuteReader()

        ASPxGridView1.DataSource = dr
    End Sub

    Private Sub ASPxGridView2_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView2.DataBinding
        'DETALHAMENTO POR EQUIPAMENTO
        Dim strFrentesTipoAtual As String = String.Empty
        Dim dtDataRef As Date = Nothing

        If ASPxHiddenField.Contains("hfFrenteTipoAtual") Then
            If ASPxHiddenField("hfFrenteTipoAtual").ToString <> "" Then

                Dim oradb As String = AppUtils.dbConnectionString

                Dim conn As OracleConnection = New OracleConnection(oradb)
                Dim cmd As OracleCommand
                conn.Open()

                strFrentesTipoAtual = ASPxHiddenField("hfFrenteTipoAtual")
                dtDataRef = CDate(ASPxHiddenField("hfDataRefAtual"))

                cmd = New OracleCommand("select decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.FRENTE, A.DATA_FECHAMENTO, A.TIPO, A.GRUPO, A.DSC_EQUIPAMENTO, A.NRO_EQUIPAMENTO, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'DISP_MECANICA_COLHEDORA'),4) R_DISP_MECANICA_COLHEDORA, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'DISP_MECANICA_DEMAIS'),4) R_DISP_MECANICA_DEMAIS, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR IN ('DISP_MECANICA_COLHEDORA', 'DISP_MECANICA_DEMAIS')),4) R_DISP_MECANICA, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_DIESEL' AND B1.UNIDADE_MEDIDA = 'LT/H'),4) R_CONSUMO_OLEO_DIESELLTH, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_DIESEL' AND B1.UNIDADE_MEDIDA = 'KM/L'),4) R_CONSUMO_OLEO_DIESELKML, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_DIESEL' AND B1.UNIDADE_MEDIDA = 'LT/TON'),4) R_CONSUMO_OLEO_DIESELLTTON, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_HIDRAULICO'),4) R_CONSUMO_OLEO_HIDRAULICO, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'TEMPO_APROVEIT_COLHEDORA'),4) R_TEMPO_APROVEIT_COLHEDORA from BI4T.INDICADORES_AGRICOLA_EQUIP A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) = :p0 and A.DATA_FECHAMENTO = :p1 GROUP BY decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)), B.FRCO_DESCRICAO, C.DSC_REDUZIDA, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO), A.ID_NEGOCIOS, A.FRENTE, A.DATA_FECHAMENTO, A.TIPO, A.GRUPO, A.DSC_EQUIPAMENTO, A.NRO_EQUIPAMENTO", conn) With {.CommandType = CommandType.Text}

                cmd.Parameters.Add(":p0", OracleDbType.Varchar2).Value = strFrentesTipoAtual
                cmd.Parameters.Add(":p1", OracleDbType.Date).Value = dtDataRef

                Dim dr As OracleDataReader = cmd.ExecuteReader()

                ASPxGridView2.DataSource = dr
            End If
        End If
    End Sub


    Protected Sub ASPxGaugeControl1_Init(sender As Object, e As EventArgs)
        Dim gaugeIndicador As DevExpress.Web.ASPxGauges.ASPxGaugeControl = TryCast(sender, DevExpress.Web.ASPxGauges.ASPxGaugeControl)
        Dim container As DevExpress.Web.GridViewDataItemTemplateContainer = DirectCast(gaugeIndicador.NamingContainer, DevExpress.Web.GridViewDataItemTemplateContainer)

        gaugeIndicador.GraphicsProperties.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim strTextFormatLabels = "{0:#,#0}"
        If DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL" Or _
               DataBinder.Eval(container.DataItem, "INDICADOR") = "DISP_MECANICA_COLHEDORA" Or _
               DataBinder.Eval(container.DataItem, "INDICADOR") = "DISP_MECANICA_DEMAIS" Or _
               DataBinder.Eval(container.DataItem, "INDICADOR") = "IMPUREZA_MINERAL" Or _
               DataBinder.Eval(container.DataItem, "INDICADOR") = "IMPUREZA_VEGETAL" Or _
               DataBinder.Eval(container.DataItem, "INDICADOR") = "PERDAS" Or _
               DataBinder.Eval(container.DataItem, "INDICADOR") = "TEMPO_APROVEIT_COLHEDORA" Then
            strTextFormatLabels = "{0:#,#0.00}"
        ElseIf DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_HIDRAULICO" Then
            strTextFormatLabels = "{0:#,#0.0000}"
        ElseIf DataBinder.Eval(container.DataItem, "INDICADOR") = "TEMPO_APROVEIT_COLHEDORA" Then
            strTextFormatLabels = "{0:#,#0}"
        End If

        If DataBinder.Eval(container.DataItem, "INDICADOR") = "DISP_MECANICA_COLHEDORA" Or _
           DataBinder.Eval(container.DataItem, "INDICADOR") = "DISP_MECANICA_DEMAIS" Or _
           DataBinder.Eval(container.DataItem, "INDICADOR") = "TEMPO_APROVEIT_COLHEDORA" Or _
            (CDate(ASPxComboDataFechamento.Value) > New DateTime(2015, 7, 20, 0, 0, 0) And _
             (DataBinder.Eval(container.DataItem, "INDICADOR") = "PREVENTIVA_MANUT_BASICA" Or _
              DataBinder.Eval(container.DataItem, "INDICADOR") = "PREVENTIVA_MECANICA")) Then

            'TIME DO QUANTO MENOR MELHOR - #CE8396 = COR VERMELHA = RUIM 

            Dim scale As DevExpress.Web.ASPxGauges.Gauges.Linear.LinearScaleComponent = DirectCast(gaugeIndicador.Gauges(0), DevExpress.Web.ASPxGauges.Gauges.Linear.LinearGauge).Scales(0)

            scale.Value = Convert.ToDouble(DataBinder.Eval(container.DataItem, "REALIZADO"))

            scale.MinValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 - (Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ABAIXO_META")) + 5) / 100)
            scale.MaxValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 + (Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ACIMA_META")) + 5) / 100)

            scale.MajorTickCount = 0
            scale.MinorTickCount = 0

            scale.MajorTickmark.ShowTick = False
            scale.MinorTickmark.ShowTick = False

            scale.Ranges(0).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#CE8396")) ' #CE8396 = COR VERMELHA = RUIM 
            scale.Ranges(0).StartValue = scale.MinValue
            scale.Ranges(0).EndValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 - Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ABAIXO_META")) / 100)

            scale.Ranges(1).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#F5E16B"))
            scale.Ranges(1).StartValue = scale.Ranges(0).EndValue
            scale.Ranges(1).EndValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO"))

            scale.Ranges(2).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#699BC1"))
            scale.Ranges(2).StartValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO"))
            scale.Ranges(2).EndValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 + Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ACIMA_META")) / 100)

            scale.Ranges(3).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#67DD63"))
            scale.Ranges(3).StartValue = scale.Ranges(2).EndValue
            scale.Ranges(3).EndValue = scale.MaxValue

            'E32-(E32-C32)*((100+(E25-E28)*F26/(E28-C28))/100)

            Dim pos12 = scale.StartPoint.Y - (scale.StartPoint.Y - scale.EndPoint.Y) * ((100 + (scale.Ranges(0).EndValue - scale.MaxValue) * 100 / (scale.MaxValue - scale.MinValue)) / 100)
            Dim pos23 = scale.StartPoint.Y - (scale.StartPoint.Y - scale.EndPoint.Y) * ((100 + (scale.Ranges(1).EndValue - scale.MaxValue) * 100 / (scale.MaxValue - scale.MinValue)) / 100)
            Dim pos34 = scale.StartPoint.Y - (scale.StartPoint.Y - scale.EndPoint.Y) * ((100 + (scale.Ranges(2).EndValue - scale.MaxValue) * 100 / (scale.MaxValue - scale.MinValue)) / 100)

            scale.Labels(0).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(0).Text = String.Format(strTextFormatLabels, scale.Ranges(0).EndValue)
            scale.Labels(0).Position = New PointF2D(46, pos12)
            scale.Labels(3).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(3).Text = "|"
            scale.Labels(3).Position = New PointF2D(59, pos12)

            scale.Labels(1).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(1).Text = String.Format(strTextFormatLabels, scale.Ranges(1).EndValue)
            scale.Labels(1).Position = New PointF2D(46, pos23)
            scale.Labels(4).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(4).Text = "|"
            scale.Labels(4).Position = New PointF2D(59, pos23)

            scale.Labels(2).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(2).Text = String.Format(strTextFormatLabels, scale.Ranges(2).EndValue)
            scale.Labels(2).Position = New PointF2D(46, pos34)
            scale.Labels(5).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(5).Text = "|"
            scale.Labels(5).Position = New PointF2D(59, pos34)

        ElseIf DataBinder.Eval(container.DataItem, "INDICADOR") = "PERDAS" Or _
            DataBinder.Eval(container.DataItem, "INDICADOR") = "IMPUREZA_MINERAL" Or _
            DataBinder.Eval(container.DataItem, "INDICADOR") = "IMPUREZA_VEGETAL" Or _
            ((DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL") And DataBinder.Eval(container.DataItem, "UNIDADE_MEDIDA") <> "KM/L") Or _
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_HIDRAULICO" Or _
            (CDate(ASPxComboDataFechamento.Value) <= New DateTime(2015, 7, 20, 0, 0, 0) And _
             (DataBinder.Eval(container.DataItem, "INDICADOR") = "PREVENTIVA_MANUT_BASICA" Or _
              DataBinder.Eval(container.DataItem, "INDICADOR") = "PREVENTIVA_MECANICA")) Then

            'TIME DO QUANTO MAIOR MELHOR - #67DD63 = COR VERDE = ÓTIMO 


            Dim scale As DevExpress.Web.ASPxGauges.Gauges.Linear.LinearScaleComponent = DirectCast(gaugeIndicador.Gauges(0), DevExpress.Web.ASPxGauges.Gauges.Linear.LinearGauge).Scales(0)

            scale.Value = Convert.ToDouble(DataBinder.Eval(container.DataItem, "REALIZADO"))

            Dim valPlanejado = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO"))

            scale.MinValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 - (Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ACIMA_META")) + 5) / 100)
            scale.MaxValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 + (Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ABAIXO_META")) + 5) / 100)

            scale.MajorTickCount = 0
            scale.MinorTickCount = 0

            scale.MajorTickmark.ShowTick = False
            scale.MinorTickmark.ShowTick = False

            scale.Ranges(0).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#67DD63")) ' #67DD63 = COR VERDE = ÓTIMO 
            scale.Ranges(0).StartValue = scale.MinValue
            scale.Ranges(0).EndValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 - Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ACIMA_META")) / 100)

            scale.Ranges(1).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#699BC1"))
            scale.Ranges(1).StartValue = scale.Ranges(0).EndValue
            scale.Ranges(1).EndValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO"))

            scale.Ranges(2).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#F5E16B"))
            scale.Ranges(2).StartValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO"))
            scale.Ranges(2).EndValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 + Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ABAIXO_META")) / 100)

            scale.Ranges(3).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#CE8396"))
            scale.Ranges(3).StartValue = scale.Ranges(2).EndValue
            scale.Ranges(3).EndValue = scale.MaxValue

            Dim pos12 = scale.StartPoint.Y - (scale.StartPoint.Y - scale.EndPoint.Y) * ((100 + (scale.Ranges(0).EndValue - scale.MaxValue) * 100 / (scale.MaxValue - scale.MinValue)) / 100)
            Dim pos23 = scale.StartPoint.Y - (scale.StartPoint.Y - scale.EndPoint.Y) * ((100 + (scale.Ranges(1).EndValue - scale.MaxValue) * 100 / (scale.MaxValue - scale.MinValue)) / 100)
            Dim pos34 = scale.StartPoint.Y - (scale.StartPoint.Y - scale.EndPoint.Y) * ((100 + (scale.Ranges(2).EndValue - scale.MaxValue) * 100 / (scale.MaxValue - scale.MinValue)) / 100)

            scale.Labels(0).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(0).Text = String.Format(strTextFormatLabels, scale.Ranges(0).EndValue)
            scale.Labels(0).Position = New PointF2D(46, pos12)
            scale.Labels(3).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(3).Text = "|"
            scale.Labels(3).Position = New PointF2D(59, pos12)

            scale.Labels(1).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(1).Text = String.Format(strTextFormatLabels, scale.Ranges(1).EndValue)
            scale.Labels(1).Position = New PointF2D(46, pos23)
            scale.Labels(4).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(4).Text = "|"
            scale.Labels(4).Position = New PointF2D(59, pos23)

            scale.Labels(2).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(2).Text = String.Format(strTextFormatLabels, scale.Ranges(2).EndValue)
            scale.Labels(2).Position = New PointF2D(46, pos34)
            scale.Labels(5).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(5).Text = "|"
            scale.Labels(5).Position = New PointF2D(59, pos34)


        Else
            'TRATAMENTO DE EXCEÇÃO - CASO INDICADOR NÃO PREVISTO NÃO FOR TRATADO NOS 2 IFS ACIMA, CAI AQUI, COM PADRÃO QUANTO MAIOR, MELHOR

            Dim scale As DevExpress.Web.ASPxGauges.Gauges.Linear.LinearScaleComponent = DirectCast(gaugeIndicador.Gauges(0), DevExpress.Web.ASPxGauges.Gauges.Linear.LinearGauge).Scales(0)

            scale.Value = Convert.ToDouble(DataBinder.Eval(container.DataItem, "REALIZADO"))

            Dim valPlanejado = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO"))

            scale.MinValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 - (Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ABAIXO_META")) + 5) / 100)
            scale.MaxValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 + (Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ACIMA_META")) + 5) / 100)

            scale.MajorTickCount = 0
            scale.MinorTickCount = 0

            scale.MajorTickmark.ShowTick = False
            scale.MinorTickmark.ShowTick = False

            scale.Ranges(0).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#CE8396"))  ' #CE8396 = COR VERMELHA = RUIM 
            scale.Ranges(0).StartValue = scale.MinValue
            scale.Ranges(0).EndValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 - Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ABAIXO_META")) / 100)

            scale.Ranges(1).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#F5E16B"))
            scale.Ranges(1).StartValue = scale.Ranges(0).EndValue
            scale.Ranges(1).EndValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO"))

            scale.Ranges(2).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#699BC1"))
            scale.Ranges(2).StartValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO"))
            scale.Ranges(2).EndValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 + Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ACIMA_META")) / 100)

            scale.Ranges(3).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#67DD63"))
            scale.Ranges(3).StartValue = scale.Ranges(2).EndValue
            scale.Ranges(3).EndValue = scale.MaxValue

            Dim pos12 = scale.StartPoint.Y - (scale.StartPoint.Y - scale.EndPoint.Y) * ((100 + (scale.Ranges(0).EndValue - scale.MaxValue) * 100 / (scale.MaxValue - scale.MinValue)) / 100)
            Dim pos23 = scale.StartPoint.Y - (scale.StartPoint.Y - scale.EndPoint.Y) * ((100 + (scale.Ranges(1).EndValue - scale.MaxValue) * 100 / (scale.MaxValue - scale.MinValue)) / 100)
            Dim pos34 = scale.StartPoint.Y - (scale.StartPoint.Y - scale.EndPoint.Y) * ((100 + (scale.Ranges(2).EndValue - scale.MaxValue) * 100 / (scale.MaxValue - scale.MinValue)) / 100)

            scale.Labels(0).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(0).Text = String.Format(strTextFormatLabels, scale.Ranges(0).EndValue)
            scale.Labels(0).Position = New PointF2D(46, pos12)
            scale.Labels(3).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(3).Text = "|"
            scale.Labels(3).Position = New PointF2D(59, pos12)

            scale.Labels(1).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(1).Text = String.Format(strTextFormatLabels, scale.Ranges(1).EndValue)
            scale.Labels(1).Position = New PointF2D(46, pos23)
            scale.Labels(4).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(4).Text = "|"
            scale.Labels(4).Position = New PointF2D(59, pos23)

            scale.Labels(2).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(2).Text = String.Format(strTextFormatLabels, scale.Ranges(2).EndValue)
            scale.Labels(2).Position = New PointF2D(46, pos34)
            scale.Labels(5).TextShape.AppearanceText.Font = New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Bold)
            scale.Labels(5).Text = "|"
            scale.Labels(5).Position = New PointF2D(59, pos34)
        End If
    End Sub

    Protected Sub ASPxGridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.Web.ASPxGridViewColumnDataEventArgs) Handles ASPxGridView1.CustomUnboundColumnData
        If e.Column.FieldName = "METAcalc" Then
            Select Case e.GetListSourceFieldValue("INDICADOR")
                Case "CONSUMO_OLEO_DIESEL"
                    e.Value = "Consumo Óleo Diesel"
                Case "CONSUMO_OLEO_HIDRAULICO"
                    e.Value = "Consumo Óleo Hidráulico"
                Case "DISP_MECANICA_COLHEDORA"
                    e.Value = "Disponibilidade Mecânica Colhedora"
                Case "DISP_MECANICA_DEMAIS"
                    e.Value = "Disponibilidade Mecânica Demais Equipamentos"
                Case "IMPUREZA_MINERAL"
                    e.Value = "Impureza Mineral"
                Case "IMPUREZA_VEGETAL"
                    e.Value = "Impureza Vegetal"
                Case "PERDAS"
                    e.Value = "Perdas"
                Case "PREVENTIVA_MANUT_BASICA"
                    e.Value = "Preventiva Manutenção Básica"
                Case "PREVENTIVA_MECANICA"
                    e.Value = "Preventiva Mecânica"
                Case "PRODUTIVIDADE"
                    e.Value = "Produtividade"
                Case "TEMPO_APROVEIT_COLHEDORA"
                    e.Value = "Tempo Aproveitável Colhedora"
                Case Else
                    e.Value = e.GetListSourceFieldValue("INDICADOR")
            End Select
        End If

        If e.Column.FieldName = "FRENTETIPOcalc" Then
            Select Case e.GetListSourceFieldValue("FRENTETIPO")
                Case "CAMINHAO"
                    e.Value = "Caminhão"
                Case "CATRAQUEIRO_PATIO"
                    e.Value = "Catraqueiro Pátio"
                Case "COLETA_PALHA"
                    e.Value = "Coleta Palha"
                Case "CONSERVACAO_GERAL"
                    e.Value = "Conservação Geral"
                Case "FORMIGA"
                    e.Value = "Formiga"
                Case "FULIGEM_VLC_TORTA_FILTRO"
                    e.Value = "Fuligem Vlc Torta Filtro"
                Case "GENO"
                    e.Value = "Geno"
                Case "HERBICICLO"
                    e.Value = "Herbiciclo"
                Case "MOTORISTA_ADUBACAO"
                    e.Value = "Motorista Adubação"
                Case "MOTORISTA_HERBICIDA_BARRA"
                    e.Value = "Motorista Herbicida Barra"
                Case "MOTORISTA_PATIO"
                    e.Value = "Motorista Pátio"
                Case "MOTORISTA_PIPA"
                    e.Value = "Motorista Pipa"
                Case "MOTORISTA_PRANCHA"
                    e.Value = "Motorista Prancha"
                Case "OFICINA_MANUT_AUTOMOTIVA"
                    e.Value = "Oficina Manutenção Automotiva"
                Case "OFICINA_MANUT_BASICA"
                    e.Value = "Oficina Manutenção Básica"
                Case "PREPARO_DE_SOLO"
                    e.Value = "Preparo de Solo"
                Case "SERVICOS_GERAIS_AJUDANTE_PIPA"
                    e.Value = "Serviços Gerais Ajudante Pipa"
                Case "VINHACA_CAMINHAO_MOTORISTA"
                    e.Value = "Vinhaça Caminhão Motorista"
                Case "VINHACA_CANAL_AGUA_TRATORISTA"
                    e.Value = "Vinhaça Canal Água Tratorista"

                Case "MOTORISTA_COMBOIO"
                    e.Value = "Motorista Comboio"
                Case "OPERADOR_MAQUINA_I"
                    e.Value = "Operador Máquina I"
                Case "SERVICOS_GERAIS_PREPARO_SOLO"
                    e.Value = "Serviços Gerais Preparo Solo"
                Case "TRATORISTA_PREPARO_SOLO"
                    e.Value = "Tratorista Preparo Solo"
                Case Else
                    e.Value = e.GetListSourceFieldValue("FRENTETIPO")
            End Select
        End If
    End Sub

    Protected Sub btnPdfExport_Click(ByVal sender As Object, ByVal e As EventArgs)
        gridExport.WritePdfToResponse()
    End Sub

    Protected Sub ASPxLabel1_Init(sender As Object, e As EventArgs)
        Dim label As DevExpress.Web.ASPxLabel = TryCast(sender, DevExpress.Web.ASPxLabel)
        Dim container As DevExpress.Web.GridViewDataItemTemplateContainer = DirectCast(label.NamingContainer, DevExpress.Web.GridViewDataItemTemplateContainer)

        If DataBinder.Eval(container.DataItem, "INDICADOR") = "PRODUTIVIDADE" Then
            label.Text = String.Format("{0:#,#0}", DataBinder.Eval(container.DataItem, "REALIZADO"))
        ElseIf DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_HIDRAULICO" Then
            label.Text = String.Format("{0:#,#0.0000}", DataBinder.Eval(container.DataItem, "REALIZADO"))
        Else
            label.Text = String.Format("{0:#,#0.00}", DataBinder.Eval(container.DataItem, "REALIZADO"))
        End If


    End Sub

    Protected Sub ASPxGridView1_CustomColumnSort(sender As Object, e As DevExpress.Web.CustomColumnSortEventArgs) Handles ASPxGridView1.CustomColumnSort
        If e.Column.FieldName = "FRENTE" Then
            e.Handled = True
            Dim s1 As Integer = e.Value1, s2 As Integer = e.Value2
            If s1 > s2 Then
                e.Result = 1
            ElseIf s2 > s1 Then
                e.Result = -1
            Else
                e.Result = Comparer.Default.Compare(s1, s2)
            End If
        End If

    End Sub

    Protected Sub ASPxGridView1_CustomColumnDisplayText(sender As Object, e As DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs) Handles ASPxGridView1.CustomColumnDisplayText
        If e.Column.FieldName = "PLANEJADO" Or e.Column.FieldName = "REALIZADO" Then
            If ASPxGridView1.GetRowValues(e.VisibleRowIndex, "INDICADOR") = "CONSUMO_OLEO_HIDRAULICO" Then
                e.DisplayText = String.Format("{0:#,#0.0000}", e.Value)
            End If
        End If

        'If e.Column.FieldName = "METAcalc" Then
        '    If ASPxGridView1.GetRowValues(e.VisibleRowIndex, "DS_FRENTETIPO") = "CAMINHÃO" Then
        '        e.EncodeHtml = False
        '        e.DisplayText = "<p style=""page-break-after:always;""></p>" & e.Value
        '    End If
        'End If
    End Sub
End Class