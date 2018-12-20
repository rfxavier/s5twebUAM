Imports Microsoft.AspNet.Identity
Imports Oracle.DataAccess.Client

Public Class cnIndDesempResumoGanho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsCallback) And Not (Page.IsPostBack) Or ASPxCbPanel.IsCallback Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

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

                Dim cmdDatasFechamento As New OracleCommand("SELECT TO_CHAR(DATA_FECHAMENTO, 'DD/MM/YYYY') DATA_FECHAMENTO FROM BI4T.v_resumo_ganho_indicadores GROUP BY DATA_FECHAMENTO ORDER BY TO_DATE(DATA_FECHAMENTO) DESC", conn) With {.CommandType = CommandType.Text}

                drDatasFechamento = cmdDatasFechamento.ExecuteReader()
                If drDatasFechamento.HasRows Then
                    Do While drDatasFechamento.Read
                        ASPxComboDataFechamento.Items.Add(drDatasFechamento.Item("DATA_FECHAMENTO"))
                        'DatasFechamento.Add(drDatasFechamento.Item("DATA_FECHAMENTO"))
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

            'GRUPO
            Dim Grupos As New List(Of String)
            ASPxComboGrupo.Items.Clear()

            Dim drGrupos As OracleDataReader = Nothing

            Try
                conn = New OracleConnection(oradb)
                conn.Open()

                Dim cmdGrupos As New OracleCommand("SELECT GRUPO FROM BI4T.v_resumo_ganho_indicadores WHERE DATA_FECHAMENTO = :p0 GROUP BY GRUPO ORDER BY GRUPO", conn) With {.CommandType = CommandType.Text}
                cmdGrupos.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Text

                drGrupos = cmdGrupos.ExecuteReader()
                If drGrupos.HasRows Then
                    ASPxComboGrupo.Items.Add("Todos os Grupos")

                    Do While drGrupos.Read
                        If Not IsDBNull(drGrupos.Item("GRUPO")) Then
                            ASPxComboGrupo.Items.Add(drGrupos.Item("GRUPO"))
                        End If
                        'DatasFechamento.Add(drDatasFechamento.Item("DATA_FECHAMENTO"))
                    Loop

                    drGrupos.Close()
                End If
            Finally
                If (Not (drGrupos) Is Nothing) Then
                    drGrupos.Dispose()
                End If
            End Try

            If Not ASPxCbPanel.IsCallback Then
                ASPxComboGrupo.SelectedIndex = 0
            End If

            'FRENTES
            Try
                conn = New OracleConnection(oradb)
                conn.Open()

                Dim cmd As New OracleCommand("SELECT V.FRENTE FROM BI4T.V_ACESSO_DET V WHERE V.USUARIO = :p0", conn) With {.CommandType = CommandType.Text}

                cmd.Parameters.Add(":p0", OracleDbType.Varchar2).Value = Context.User.Identity.Name.ToUpper

                Dim dr As OracleDataReader = Nothing
                Try
                    dr = cmd.ExecuteReader()
                    If dr.HasRows Then
                        Dim listaFrentes As New List(Of Integer)

                        'USUÁRIO TEM INDICAÇÃO DE FRENTES
                        Do While dr.Read
                            listaFrentes.Add(Convert.ToInt16(dr.Item("FRENTE")))
                        Loop

                        ASPxHiddenField.Set("hfFrentes", String.Join(",", listaFrentes.ToArray))
                    End If
                Finally
                    If (Not (dr) Is Nothing) Then
                        dr.Dispose()
                    End If
                End Try
            Catch ex As Exception

            End Try

            SetaVisibilidadeColunasDataRef(CDate(ASPxComboDataFechamento.Value))

            ASPxGridView1.DataSourceID = ""
            ASPxGridView1.DataBind()
        End If

    End Sub

    Private Sub SetaVisibilidadeColunasDataRef(parDataRef As Date)
        If parDataRef <= New DateTime(2016, 12, 31, 0, 0, 0) Then
            'ESCONDER 4 COLUNAS

            ASPxGridView1.Columns("ENTREGA_DE_CANA").Visible = False
            ASPxGridView1.Columns("PISOTEIO_SOQUEIRA").Visible = False
            ASPxGridView1.Columns("DISPONIBILIDADE_MECANICA").Visible = False
            ASPxGridView1.Columns("MAPA_DE_PARADA").Visible = False

            ASPxGridView1.Columns("DISP_MECANICA_COLHEDORA").Visible = True
            ASPxGridView1.Columns("DISP_MECANICA_DEMAIS").Visible = True

        Else
            ASPxGridView1.Columns("ENTREGA_DE_CANA").Visible = True
            ASPxGridView1.Columns("PISOTEIO_SOQUEIRA").Visible = True
            ASPxGridView1.Columns("DISPONIBILIDADE_MECANICA").Visible = True
            ASPxGridView1.Columns("MAPA_DE_PARADA").Visible = True

            ASPxGridView1.Columns("DISP_MECANICA_COLHEDORA").Visible = False
            ASPxGridView1.Columns("DISP_MECANICA_DEMAIS").Visible = False
        End If

    End Sub

    Private Class S5TIndicadoresAgricola
        Public Property NOTACALC As Integer
        Public Property FRENTETIPO As String
        Public Property FRENTETIPOAUX As String
        Public Property DS_FRENTE As String
        Public Property DS_TIPO As String
        Public Property DS_FRENTETIPO As String
        Public Property ID_NEGOCIOS As Integer
        Public Property INDICADOR As String
        Public Property FRENTE As Integer
        Public Property PLANEJADO As Double
        Public Property REALIZADO As Double
        Public Property PERC As Double
        Public Property NOTA As String
        Public Property DATA_FECHAMENTO As Date
        Public Property UNIDADE_MEDIDA As String
        Public Property PERC_ABAIXO_META As Double
        Public Property PERC_ACIMA_META As Double
        Public Property TIPO As String
        Public Property GRUPO As String

    End Class

    Dim IndicadoresAgricola As New List(Of S5TIndicadoresAgricola)

    Protected Sub ASPxGridView1_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView1.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        Dim cmd As OracleCommand
        Dim cmdIndic As OracleCommand

        conn.Open()

        Dim strFrentesAtuais As String = String.Empty

        If ASPxHiddenField.Contains("hfFrentes") Then
            strFrentesAtuais = ASPxHiddenField("hfFrentes")
        End If

        'If ASPxComboGrupo.SelectedIndex = 0 Then
        'TODOS OS GRUPOS

        'TEM FRENTES INDICADAS
        If strFrentesAtuais <> String.Empty Then
            cmd = New OracleCommand(String.Format("select ID_NEGOCIOS, DATA_FECHAMENTO, ID_PROCESSO, GRUPO, FRENTE, TIPO, DESC_FRENTE_TIPO, PRODUTIVIDADE, IMP_MINERAL IMPUREZA_MINERAL, IMP_VEGETAL IMPUREZA_VEGETAL, PERDAS, CONSUMO_OLEO_DIESEL, CONSUMO_OLEO_DIESEL_COLHEDORA, CONSUMO_OLEO_DIESEL_TRATOR, CONSUMO_OLEO_HIDRAULICO, DISP_MEC_COLHEDORA DISP_MECANICA_COLHEDORA, DISP_MEC_COLHEDORA_SN, DISP_MEC_DEMAIS DISP_MECANICA_DEMAIS, DISP_MEC, TEMPO_AP_COLHEDORA TEMPO_APROVEIT_COLHEDORA, GANHO_BONUS, decode(FRENTE, NULL, TIPO, LPAD(FRENTE, 3, '0')) FRENTETIPO, PREVENTIVA_MECANICA, PREVENTIVA_MANUT_BASICA, TEMPO_ATENDIMENTO, QTD_MAX_HORAS_A_PAGAR, ENTREGA_DE_CANA, PISOTEIO_SOQUEIRA, MAPA_DE_PARADA, DISPONIBILIDADE_MECANICA from BI4T.v_resumo_ganho_indicadores where FRENTE IN ({0}) and DATA_FECHAMENTO = :p0", strFrentesAtuais), conn) With {.CommandType = CommandType.Text}

            cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
        Else
            'TODAS AS FRENTES
            cmd = New OracleCommand("select ID_NEGOCIOS, DATA_FECHAMENTO, ID_PROCESSO, GRUPO, FRENTE, TIPO, DESC_FRENTE_TIPO, PRODUTIVIDADE, IMP_MINERAL IMPUREZA_MINERAL, IMP_VEGETAL IMPUREZA_VEGETAL, PERDAS, CONSUMO_OLEO_DIESEL, CONSUMO_OLEO_DIESEL_COLHEDORA, CONSUMO_OLEO_DIESEL_TRATOR, CONSUMO_OLEO_HIDRAULICO, DISP_MEC_COLHEDORA DISP_MECANICA_COLHEDORA, DISP_MEC_COLHEDORA_SN, DISP_MEC_DEMAIS DISP_MECANICA_DEMAIS, DISP_MEC, TEMPO_AP_COLHEDORA TEMPO_APROVEIT_COLHEDORA, GANHO_BONUS, decode(FRENTE, NULL, TIPO, LPAD(FRENTE, 3, '0')) FRENTETIPO, PREVENTIVA_MECANICA, PREVENTIVA_MANUT_BASICA, TEMPO_ATENDIMENTO, QTD_MAX_HORAS_A_PAGAR, ENTREGA_DE_CANA, PISOTEIO_SOQUEIRA, MAPA_DE_PARADA, DISPONIBILIDADE_MECANICA from BI4T.v_resumo_ganho_indicadores where DATA_FECHAMENTO = :p0", conn) With {.CommandType = CommandType.Text}

            cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
        End If

        Dim dr As OracleDataReader = cmd.ExecuteReader()

        ASPxGridView1.DataSource = dr

        cmdIndic = New OracleCommand("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0), 4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0), 4) REALIZADO, ROUND(NVL(A.PERC, 0), 4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0), 4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0), 4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C, SISAGRI.FRENTE_SERVICO_GRUPO D where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) AND B.ID_NEGOCIOS = D.ID_NEGOCIOS (+) AND B.ID_FRENTE_SERVICO_GRUPO = D.ID_FRENTE_SERVICO_GRUPO (+) and A.DATA_FECHAMENTO = :p0 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by A.frente, A.INDICADOR", conn) With {.CommandType = CommandType.Text}
        cmdIndic.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value

        Dim drIndic As OracleDataReader = cmdIndic.ExecuteReader()


        If drIndic.HasRows Then
            Do While drIndic.Read
                Dim objIndicadoresAgricola = New S5TIndicadoresAgricola

                objIndicadoresAgricola.NOTACALC = AppUtils.Nvl(drIndic.Item("NOTAcalc"), 0)
                objIndicadoresAgricola.FRENTETIPO = AppUtils.Nvl(drIndic.Item("FRENTETIPO"), "")
                objIndicadoresAgricola.FRENTETIPOAUX = AppUtils.Nvl(drIndic.Item("FRENTETIPOAUX"), "")
                objIndicadoresAgricola.DS_FRENTE = AppUtils.Nvl(drIndic.Item("DS_FRENTE"), "")
                objIndicadoresAgricola.DS_TIPO = AppUtils.Nvl(drIndic.Item("DS_TIPO"), "")
                objIndicadoresAgricola.DS_FRENTETIPO = AppUtils.Nvl(drIndic.Item("DS_FRENTETIPO"), "")
                objIndicadoresAgricola.ID_NEGOCIOS = AppUtils.Nvl(drIndic.Item("ID_NEGOCIOS"), 0)
                objIndicadoresAgricola.INDICADOR = AppUtils.Nvl(drIndic.Item("INDICADOR"), "")
                objIndicadoresAgricola.FRENTE = AppUtils.Nvl(drIndic.Item("FRENTE"), 0)
                objIndicadoresAgricola.PLANEJADO = AppUtils.Nvl(drIndic.Item("PLANEJADO"), 0)
                objIndicadoresAgricola.REALIZADO = AppUtils.Nvl(drIndic.Item("REALIZADO"), 0)
                objIndicadoresAgricola.PERC = AppUtils.Nvl(drIndic.Item("PERC"), 0)
                objIndicadoresAgricola.NOTA = AppUtils.Nvl(drIndic.Item("NOTA"), "")
                objIndicadoresAgricola.DATA_FECHAMENTO = AppUtils.Nvl(drIndic.Item("DATA_FECHAMENTO"), Date.MinValue)
                objIndicadoresAgricola.UNIDADE_MEDIDA = AppUtils.Nvl(drIndic.Item("UNIDADE_MEDIDA"), "")
                objIndicadoresAgricola.PERC_ABAIXO_META = AppUtils.Nvl(drIndic.Item("PERC_ABAIXO_META"), 0)
                objIndicadoresAgricola.PERC_ACIMA_META = AppUtils.Nvl(drIndic.Item("PERC_ACIMA_META"), 0)
                objIndicadoresAgricola.TIPO = AppUtils.Nvl(drIndic.Item("TIPO"), "")
                objIndicadoresAgricola.GRUPO = AppUtils.Nvl(drIndic.Item("GRUPO"), "")

                IndicadoresAgricola.Add(objIndicadoresAgricola)
            Loop
        End If



        'For i = 0 To 10
        '    Dim objpropriedade = New S5TLista

        '    objpropriedade.GRUPO = i.ToString

        '    objLista.Add(objpropriedade)
        'Next



    End Sub

    Protected Sub ASPxGridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.Web.ASPxGridViewColumnDataEventArgs) Handles ASPxGridView1.CustomUnboundColumnData
        If e.Column.FieldName = "TIPOcalc" Then
            Select Case e.GetListSourceFieldValue("TIPO")
                Case "CAMINHAO"
                    e.Value = "Caminhão"
                Case "CATRAQUEIRO_PATIO"
                    e.Value = "Catraqueiro Pátio"
                Case "COLETA_PALHA"
                    e.Value = "Coleta Palha"
                Case "COLHEITADEIRA"
                    e.Value = "Colheitadeira"
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
                Case "MOTORISTA_PIPA_FRENTE"
                    e.Value = "Motorista Pipa Frente"
                Case "MOTORISTA_PRANCHA"
                    e.Value = "Motorista Prancha"
                Case "OFICINA_CAMPO_COLHEITA"
                    e.Value = "Oficina Campo Colheita"
                Case "OFICINA_MANUT_AUTOMOTIVA"
                    e.Value = "Oficina Manutenção Automotiva"
                Case "OFICINA_MANUT_BASICA"
                    e.Value = "Oficina Manutenção Básica"
                Case "OPERADOR_MAQUINA_HERB_BARRA"
                    e.Value = "Operador Máquina Herbicida Barra"
                Case "PREPARO_DE_SOLO"
                    e.Value = "Preparo de Solo"
                Case "SERVICOS_GERAIS_ADUBACAO_COBERTURA"
                    e.Value = "Serviços Gerais Adubação Cobertura"
                Case "SERVICOS_GERAIS_AJUDANTE_PIPA_FRENTE"
                    e.Value = "Serviços Gerais Ajudante Pipa Frente"
                Case "SERVICOS_GERAIS_AJUDANTE_PIPA"
                    e.Value = "Serviços Gerais Ajudante Pipa"
                Case "SERVICOS_GERAIS_HERBICIDA_ACEIRO"
                    e.Value = "Serviços Gerais Herbicida Aceiro"
                Case "SERVICOS_GERAIS_HERBICIDA_BARRA"
                    e.Value = "Serviços Gerais Herbicida Barra"
                Case "SUPERVISOR_AGRICOLA"
                    e.Value = "Supervisor Agrícola"
                Case "SUPERVISOR_AGRICOLA_FOLGUISTA"
                    e.Value = "Supervisor Agrícola Folguista"
                Case "TRATOR"
                    e.Value = "Trator"
                Case "TRATORISTA_ADUBACAO_COBERTURA"
                    e.Value = "Tratorista Adubação Cobertura"
                Case "TRATORISTA_HERBICIDA_ACEIRO"
                    e.Value = "Tratorista Herbicida Aceiro"
                Case "TRATORISTA_HERBICIDA_BARRA"
                    e.Value = "Tratorista Herbicida Barra"
                Case "VINHACA_CAMINHAO_MOTORISTA"
                    e.Value = "Vinhaça Caminhão Motorista"
                Case "VINHACA_CAMINHAO_SERVICOS_GERAIS"
                    e.Value = "Vinhaça Caminhão Serviços Gerais"
                Case "VINHACA_CAMINHAO_TRATORISTA"
                    e.Value = "Vinhaça Caminhão Tratorista"
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
                Case "PLANTIO_GRAOS"
                    e.Value = "Plantio Grãos"
                Case "PLANTULAS"
                    e.Value = "Plântulas"
                Case "MOTORISTA_HERBICIDA_BARRA_FRENTE"
                    e.Value = "Motorista Herbicida Barra Frente"
                Case "OFICINA_BORRACHEIRO_VOL"
                    e.Value = "Borracheiro Campo"
                Case "CORTE_SOQUEIRA"
                    e.Value = "Corte Soqueira"
                Case Else
                    e.Value = e.GetListSourceFieldValue("TIPO")
            End Select
        End If


        If e.Column.FieldName = "TOTALcalc" Then
            Dim valTotal As Double = 0

            valTotal += AppUtils.NvlDbNull(e.GetListSourceFieldValue("PRODUTIVIDADE")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("IMPUREZA_MINERAL")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("IMPUREZA_VEGETAL")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("PERDAS")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_COLHEDORA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_TRATOR")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("CONSUMO_OLEO_HIDRAULICO")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("DISP_MECANICA_COLHEDORA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("DISP_MECANICA_DEMAIS")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("TEMPO_APROVEIT_COLHEDORA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("PREVENTIVA_MECANICA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("PREVENTIVA_MANUT_BASICA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("TEMPO_ATENDIMENTO")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("ENTREGA_DE_CANA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("PISOTEIO_SOQUEIRA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("MAPA_DE_PARADA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("DISPONIBILIDADE_MECANICA"))

            e.Value = valTotal
        End If

        If e.Column.FieldName = "QTDPAGARcalc" Then
            Dim valTotal As Double = 0

            valTotal += AppUtils.NvlDbNull(e.GetListSourceFieldValue("PRODUTIVIDADE")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("IMPUREZA_MINERAL")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("IMPUREZA_VEGETAL")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("PERDAS")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_COLHEDORA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_TRATOR")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("CONSUMO_OLEO_HIDRAULICO")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("DISP_MECANICA_COLHEDORA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("DISP_MECANICA_DEMAIS")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("TEMPO_APROVEIT_COLHEDORA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("PREVENTIVA_MECANICA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("PREVENTIVA_MANUT_BASICA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("TEMPO_ATENDIMENTO")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("ENTREGA_DE_CANA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("PISOTEIO_SOQUEIRA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("MAPA_DE_PARADA")) +
                        AppUtils.NvlDbNull(e.GetListSourceFieldValue("DISPONIBILIDADE_MECANICA"))

            Dim qtdPagar As Double = 0
            'ROUND((QTD_MAX_HORAS_A_PAGAR * % Total) / 100,4)

            If IsDBNull(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) Then
                qtdPagar = 0
            Else
                qtdPagar = Math.Round(((Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) * valTotal) / 100) + ((((Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) * valTotal) / 100) * Convert.ToDouble(e.GetListSourceFieldValue("GANHO_BONUS"))) / 100), 2)
            End If

            'qtdPagar = IIf(IsDBNull(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")), 0, Math.Round(((Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) * valTotal) / 100) + ((((Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) * valTotal) / 100) * Convert.ToDouble(e.GetListSourceFieldValue("GANHO_BONUS"))) / 100), 2))

            e.Value = qtdPagar
        End If
    End Sub


    Private Sub ASPxGridView1_HtmlDataCellPrepared(sender As Object, e As DevExpress.Web.ASPxGridViewTableDataCellEventArgs) Handles ASPxGridView1.HtmlDataCellPrepared
        'IndicadoresAgricola

        'Dim o = ASPxGridView1.GetRowValues(e.VisibleIndex, "GRUPO").ToString

        'If e.DataColumn.FieldName = "IMPUREZA_MINERAL" Then
        '    If Not (TypeOf e.CellValue Is System.DBNull) Then
        '        e.Cell.BackColor = Drawing.Color.LightGreen

        '    End If

        '    'If e.CellValue <> "" Then
        '    'End If
        'End If

        If {"PRODUTIVIDADE",
            "IMPUREZA_MINERAL",
            "IMPUREZA_VEGETAL",
            "PERDAS",
            "CONSUMO_OLEO_DIESEL",
            "CONSUMO_OLEO_DIESEL_COLHEDORA",
            "CONSUMO_OLEO_DIESEL_TRATOR",
            "CONSUMO_OLEO_HIDRAULICO",
            "DISP_MECANICA_COLHEDORA",
            "DISP_MECANICA_DEMAIS",
            "TEMPO_APROVEIT_COLHEDORA",
            "PREVENTIVA_MECANICA",
            "PREVENTIVA_MANUT_BASICA",
            "TEMPO_ATENDIMENTO",
            "ENTREGA_DE_CANA",
            "PISOTEIO_SOQUEIRA",
            "MAPA_DE_PARADA",
            "DISPONIBILIDADE_MECANICA"}.Contains(e.DataColumn.FieldName) Then

            If Not (TypeOf e.CellValue Is System.DBNull) Then
                e.Cell.BackColor = GetCorIndicador(ASPxGridView1.GetRowValues(e.VisibleIndex, "GRUPO").ToString,
                                                   ASPxGridView1.GetRowValues(e.VisibleIndex, "FRENTE").ToString,
                                                   ASPxGridView1.GetRowValues(e.VisibleIndex, "TIPO").ToString,
                                                   e.DataColumn.FieldName, IndicadoresAgricola)
            End If

        End If




    End Sub

    Private Function GetCorIndicador(ByVal parGRUPO As String, parFRENTE As String, parTIPO As String, parINDICADOR As String, ByRef parIndicadoresAgricola As List(Of S5TIndicadoresAgricola)) As System.Drawing.Color
        Dim varCor As System.Drawing.Color = Drawing.Color.White

        Dim objIndicadorAgricola As S5TIndicadoresAgricola = Nothing

        If parFRENTE <> "" Then
            'Dim o1 = parIndicadoresAgricola.FindAll(Function(x) x.GRUPO = parGRUPO)
            'Dim o2 = parIndicadoresAgricola.FindAll(Function(x) x.GRUPO = parGRUPO And x.FRENTETIPOAUX = parFRENTE.PadLeft(3, "0"))
            'Dim o3 = parIndicadoresAgricola.FindAll(Function(x) x.GRUPO = parGRUPO And x.FRENTETIPOAUX = parFRENTE.PadLeft(3, "0") And x.INDICADOR = parINDICADOR)

            objIndicadorAgricola = parIndicadoresAgricola.FindAll(Function(x) x.GRUPO = parGRUPO And x.FRENTETIPOAUX = parFRENTE.PadLeft(3, "0") And x.INDICADOR = parINDICADOR).FirstOrDefault
        Else
            'Dim o1 = parIndicadoresAgricola.FindAll(Function(x) x.GRUPO = parGRUPO)
            'Dim o2 = parIndicadoresAgricola.FindAll(Function(x) x.GRUPO = parGRUPO And x.TIPO = parTIPO)
            'Dim o3 = parIndicadoresAgricola.FindAll(Function(x) x.GRUPO = parGRUPO And x.TIPO = parTIPO And x.INDICADOR = parINDICADOR)

            objIndicadorAgricola = parIndicadoresAgricola.FindAll(Function(x) x.GRUPO = parGRUPO And x.TIPO = parTIPO And x.INDICADOR = parINDICADOR).FirstOrDefault
        End If

        If objIndicadorAgricola IsNot Nothing Then
            If objIndicadorAgricola.NOTACALC = "0" Then
                'OTIMO - VERDE
                varCor = System.Drawing.ColorTranslator.FromHtml("#67DD63")
            ElseIf objIndicadorAgricola.NOTACALC = "2" Then
                'BOM - AZUL
                varCor = System.Drawing.ColorTranslator.FromHtml("#699BC1")
            ElseIf objIndicadorAgricola.NOTACALC = "3" Then
                'REGULAR - AMARELO
                varCor = System.Drawing.ColorTranslator.FromHtml("#F5E16B")
            ElseIf objIndicadorAgricola.NOTACALC = "4" Then
                'RUIM - VERMELHO
                varCor = System.Drawing.ColorTranslator.FromHtml("#CE8396")
            End If
        End If

        Return varCor
    End Function


End Class