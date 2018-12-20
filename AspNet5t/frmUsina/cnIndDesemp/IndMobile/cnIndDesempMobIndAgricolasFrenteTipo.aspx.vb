Imports Oracle.DataAccess.Client
Imports Microsoft.AspNet.Identity
Imports DevExpress.XtraGauges.Core.Drawing
Imports DevExpress.Web
Imports DevExpress.XtraGauges.Core.Base

Public Class cnIndDesempMobIndAgricolasFrenteTipo
    Inherits System.Web.UI.Page

    Private Class S5TFrenteColheita
        Private _pCodFrente As Integer
        Public Property pCodFrente() As Integer
            Get
                Return _pCodFrente
            End Get
            Set(ByVal value As Integer)
                _pCodFrente = value
            End Set
        End Property

        Private _pDescFrente As String
        Public Property pDescFrente() As String
            Get
                Return _pDescFrente
            End Get
            Set(ByVal value As String)
                _pDescFrente = value
            End Set
        End Property
    End Class

    Private Class S5TBoletimProd
        Private _pIndicador As String
        Public Property pIndicador() As String
            Get
                Return _pIndicador
            End Get
            Set(ByVal value As String)
                _pIndicador = value
            End Set
        End Property

        Private _pFrente As Integer
        Public Property pFrente() As Integer
            Get
                Return _pFrente
            End Get
            Set(ByVal value As Integer)
                _pFrente = value
            End Set
        End Property

        Private _pTipo As String
        Public Property pTipo() As String
            Get
                Return _pTipo
            End Get
            Set(ByVal value As String)
                _pTipo = value
            End Set
        End Property

        Private _pFrenteTipo As String
        Public Property pFrenteTipo() As String
            Get
                Return _pFrenteTipo
            End Get
            Set(ByVal value As String)
                _pFrenteTipo = value
            End Set
        End Property

        Private _pFrenteTipoTitulo As String
        Public Property pFrenteTipoTitulo() As String
            Get
                Return _pFrenteTipoTitulo
            End Get
            Set(ByVal value As String)
                _pFrenteTipoTitulo = value
            End Set
        End Property

        Private _pDsFrente As String
        Public Property pDsFrente() As String
            Get
                Return _pDsFrente
            End Get
            Set(ByVal value As String)
                _pDsFrente = value
            End Set
        End Property

        Private _pDsTipo As String
        Public Property pDsTipo() As String
            Get
                Return _pDsTipo
            End Get
            Set(ByVal value As String)
                _pDsTipo = value
            End Set
        End Property

        Private _pDsFrenteTipo As String
        Public Property pDsFrenteTipo() As String
            Get
                Return _pDsFrenteTipo
            End Get
            Set(ByVal value As String)
                _pDsFrenteTipo = value
            End Set
        End Property


        Private _pUnidadeMedida As String
        Public Property pUnidadeMedida() As String
            Get
                Return _pUnidadeMedida
            End Get
            Set(ByVal value As String)
                _pUnidadeMedida = value
            End Set
        End Property


        Private _pFrenteTipoFlg As String
        Public Property pFrenteTipoFlg() As String
            Get
                Return _pFrenteTipoFlg
            End Get
            Set(ByVal value As String)
                _pFrenteTipoFlg = value
            End Set
        End Property


        Private _pPlanejado As Double
        Public Property pPlanejado() As Double
            Get
                Return _pPlanejado
            End Get
            Set(ByVal value As Double)
                _pPlanejado = value
            End Set
        End Property

        Private _pRealizado As Double
        Public Property pRealizado() As Double
            Get
                Return _pRealizado
            End Get
            Set(ByVal value As Double)
                _pRealizado = value
            End Set
        End Property

        Private _pPerc As Double
        Public Property pPerc() As Double
            Get
                Return _pPerc
            End Get
            Set(ByVal value As Double)
                _pPerc = value
            End Set
        End Property

        Private _pNota As String
        Public Property pNota() As String
            Get
                Return _pNota
            End Get
            Set(ByVal value As String)
                _pNota = value
            End Set
        End Property

        Private _pNotaCalc As Integer
        Public Property pNotaCalc() As Integer
            Get
                Return _pNotaCalc
            End Get
            Set(ByVal value As Integer)
                _pNotaCalc = value
            End Set
        End Property

        Private _pPaginaNumero As Integer
        Public Property pPaginaNumero() As Integer
            Get
                Return _pPaginaNumero
            End Get
            Set(ByVal value As Integer)
                _pPaginaNumero = value
            End Set
        End Property

        Private _pGrupo As String
        Public Property pGrupo() As String
            Get
                Return _pGrupo
            End Get
            Set(ByVal value As String)
                _pGrupo = value
            End Set
        End Property


    End Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ((Not IsPostBack) And (Not IsCallback)) Or ASPxCbPanel.IsCallback Then
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

                'Dim cmdDatasFechamento As New OracleCommand("SELECT TO_CHAR(DATA_FECHAMENTO, 'DD/MM/YYYY') DATA_FECHAMENTO FROM BI4T.INDICADORES_AGRICOLA GROUP BY DATA_FECHAMENTO ORDER BY DATA_FECHAMENTO DESC", conn) With {.CommandType = CommandType.Text}
                Dim cmdDatasFechamento As New OracleCommand("SELECT TO_CHAR(DATA_FECHAMENTO, 'DD/MM/YYYY') DATA_FECHAMENTO FROM BI4T.INDICADORES_AGRICOLA WHERE DATA_FECHAMENTO >= TO_DATE('20/06/2015', 'DD/MM/YYYY') GROUP BY DATA_FECHAMENTO ORDER BY TO_DATE(DATA_FECHAMENTO) DESC", conn) With {.CommandType = CommandType.Text}

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
            Catch

            Finally
                If (Not (drTempoAprov) Is Nothing) Then
                    drTempoAprov.Dispose()
                End If
            End Try

            'MONTAGEM DO NAVBAR
            Dim BoletimProd = New List(Of S5TBoletimProd)
            Dim cmdBoletimProdFrente As OracleCommand

            Try
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

                        If CDate(ASPxComboDataFechamento.Value) <= New DateTime(2015, 6, 20, 0, 0, 0) Then
                            'QUERY VELHA
                            cmdBoletimProdFrente = New OracleCommand(String.Format("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0),4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0),4) REALIZADO, ROUND(NVL(A.PERC, 0),4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0),4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0),4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) IN ({0}) AND A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and A.DATA_FECHAMENTO = :p0 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO), A.INDICADOR, A.UNIDADE_MEDIDA", String.Join(",", listaFrentes.ToArray)), conn) With {.CommandType = CommandType.Text}
                        Else
                            'QUERY NOVA
                            cmdBoletimProdFrente = New OracleCommand(String.Format("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0), 4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0), 4) REALIZADO, ROUND(NVL(A.PERC, 0), 4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0), 4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0), 4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C, SISAGRI.FRENTE_SERVICO_GRUPO D where decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) IN ({0}) AND A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) AND B.ID_NEGOCIOS = D.ID_NEGOCIOS (+) AND B.ID_FRENTE_SERVICO_GRUPO = D.ID_FRENTE_SERVICO_GRUPO (+) and A.DATA_FECHAMENTO = :p0 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)), A.INDICADOR, A.UNIDADE_MEDIDA", String.Join(",", listaFrentes.ToArray)), conn) With {.CommandType = CommandType.Text}
                        End If

                        cmdBoletimProdFrente.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value

                        Dim drBoletimProdFrente As OracleDataReader = Nothing
                        Try
                            drBoletimProdFrente = cmdBoletimProdFrente.ExecuteReader()
                            If drBoletimProdFrente.HasRows Then
                                Do While drBoletimProdFrente.Read
                                    Dim objBoletimProd = New S5TBoletimProd

                                    objBoletimProd.pIndicador = drBoletimProdFrente.Item("INDICADOR")
                                    If IsDBNull(drBoletimProdFrente.Item("FRENTE")) Then
                                        objBoletimProd.pGrupo = drBoletimProdFrente.Item("GRUPO")
                                        objBoletimProd.pFrente = 0
                                        objBoletimProd.pTipo = drBoletimProdFrente.Item("TIPO")
                                        objBoletimProd.pFrenteTipo = objBoletimProd.pTipo
                                        objBoletimProd.pFrenteTipoTitulo = FrenteTipoTitulo(objBoletimProd.pFrenteTipo)
                                        objBoletimProd.pFrenteTipoFlg = "T"
                                    Else
                                        objBoletimProd.pGrupo = drBoletimProdFrente.Item("GRUPO")
                                        objBoletimProd.pFrente = drBoletimProdFrente.Item("FRENTE")
                                        objBoletimProd.pTipo = ""
                                        objBoletimProd.pFrenteTipo = objBoletimProd.pFrente.ToString.PadLeft(3, "0")
                                        objBoletimProd.pFrenteTipoTitulo = objBoletimProd.pFrenteTipo & " " & objBoletimProd.pGrupo.PadRight(10, " ").Substring(0, 10).Trim
                                        objBoletimProd.pFrenteTipoFlg = "F"
                                    End If
                                    objBoletimProd.pUnidadeMedida = drBoletimProdFrente.Item("UNIDADE_MEDIDA")
                                    objBoletimProd.pDsFrente = drBoletimProdFrente.Item("DS_FRENTE").ToString
                                    objBoletimProd.pDsTipo = drBoletimProdFrente.Item("DS_TIPO").ToString
                                    objBoletimProd.pDsFrenteTipo = drBoletimProdFrente.Item("DS_FRENTETIPO").ToString
                                    objBoletimProd.pPlanejado = drBoletimProdFrente.Item("PLANEJADO")
                                    objBoletimProd.pRealizado = drBoletimProdFrente.Item("REALIZADO")
                                    objBoletimProd.pPerc = drBoletimProdFrente.Item("PERC")
                                    objBoletimProd.pNota = drBoletimProdFrente.Item("NOTA")
                                    objBoletimProd.pNotaCalc = drBoletimProdFrente.Item("NOTAcalc")

                                    BoletimProd.Add(objBoletimProd)
                                Loop

                                drBoletimProdFrente.Close()
                            End If
                        Finally
                            If (Not (drBoletimProdFrente) Is Nothing) Then
                                drBoletimProdFrente.Dispose()
                            End If
                        End Try

                        Dim BoletimProdOrd = BoletimProd.OrderBy(Function(x) x.pDsFrenteTipo).ThenBy(Function(x) x.pIndicador).ThenBy(Function(x) x.pUnidadeMedida)

                        If BoletimProdOrd.FirstOrDefault.pFrenteTipoFlg = "F" Then
                            ASPxHiddenField.Set("hfFrenteAtual", BoletimProdOrd.FirstOrDefault.pFrente)
                            ASPxButtonResultadoFrente.Text = "Resultados % " & BoletimProdOrd.FirstOrDefault.pDsFrenteTipo.ToString
                            ASPxButtonEquip.Text = "Equipamento " & BoletimProdOrd.FirstOrDefault.pDsFrenteTipo.ToString
                            ASPxHiddenField.Set("hfTipoAtual", "")
                        Else
                            ASPxHiddenField.Set("hfFrenteAtual", "")
                            ASPxButtonResultadoFrente.Text = "Resultados % " & BoletimProdOrd.FirstOrDefault.pDsFrenteTipo.ToString
                            ASPxButtonEquip.Text = "Equipamento " & BoletimProdOrd.FirstOrDefault.pDsFrenteTipo.ToString
                            ASPxHiddenField.Set("hfTipoAtual", BoletimProdOrd.FirstOrDefault.pTipo)
                        End If
                        ASPxHiddenField.Set("hfFrenteTipoAtual", BoletimProdOrd.FirstOrDefault.pFrenteTipo)
                        ASPxHiddenField.Set("hfFrenteTipoAtualDs", BoletimProdOrd.FirstOrDefault.pDsFrenteTipo)

                        dr.Close()
                    Else
                        'USUÁRIO TEM PERMISSÃO PARA TODAS AS FRENTES
                        If CDate(ASPxComboDataFechamento.Value) <= New DateTime(2015, 6, 20, 0, 0, 0) Then
                            'QUERY VELHA
                            cmdBoletimProdFrente = New OracleCommand("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0),4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0),4) REALIZADO, ROUND(NVL(A.PERC, 0),4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0),4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0),4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and A.DATA_FECHAMENTO = :p0 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO), A.INDICADOR, A.UNIDADE_MEDIDA", conn) With {.CommandType = CommandType.Text}
                        Else
                            'QUERY NOVA
                            cmdBoletimProdFrente = New OracleCommand("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0), 4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0), 4) REALIZADO, ROUND(NVL(A.PERC, 0), 4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0), 4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0), 4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C, SISAGRI.FRENTE_SERVICO_GRUPO D where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) AND B.ID_NEGOCIOS = D.ID_NEGOCIOS (+) AND B.ID_FRENTE_SERVICO_GRUPO = D.ID_FRENTE_SERVICO_GRUPO (+) and A.DATA_FECHAMENTO = :p0 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)), A.INDICADOR, A.UNIDADE_MEDIDA", conn) With {.CommandType = CommandType.Text}
                        End If

                        cmdBoletimProdFrente.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value

                        Dim drBoletimProdFrente As OracleDataReader = Nothing
                        Try
                            drBoletimProdFrente = cmdBoletimProdFrente.ExecuteReader()
                            If drBoletimProdFrente.HasRows Then
                                Do While drBoletimProdFrente.Read
                                    Dim objBoletimProd = New S5TBoletimProd

                                    objBoletimProd.pIndicador = drBoletimProdFrente.Item("INDICADOR")
                                    If IsDBNull(drBoletimProdFrente.Item("FRENTE")) Then
                                        objBoletimProd.pGrupo = AppUtils.Nvl(drBoletimProdFrente.Item("GRUPO"), "")
                                        objBoletimProd.pFrente = 0
                                        objBoletimProd.pTipo = drBoletimProdFrente.Item("TIPO")
                                        objBoletimProd.pFrenteTipo = objBoletimProd.pTipo
                                        objBoletimProd.pFrenteTipoTitulo = FrenteTipoTitulo(objBoletimProd.pFrenteTipo)
                                        objBoletimProd.pFrenteTipoFlg = "T"
                                    Else
                                        objBoletimProd.pGrupo = drBoletimProdFrente.Item("GRUPO")
                                        objBoletimProd.pFrente = drBoletimProdFrente.Item("FRENTE")
                                        objBoletimProd.pTipo = ""
                                        objBoletimProd.pFrenteTipo = objBoletimProd.pFrente.ToString.PadLeft(3, "0")
                                        objBoletimProd.pFrenteTipoTitulo = objBoletimProd.pFrenteTipo & " " & objBoletimProd.pGrupo.PadRight(10, " ").Substring(0, 10).Trim
                                        objBoletimProd.pFrenteTipoFlg = "F"
                                    End If
                                    objBoletimProd.pUnidadeMedida = drBoletimProdFrente.Item("UNIDADE_MEDIDA")
                                    objBoletimProd.pDsFrente = drBoletimProdFrente.Item("DS_FRENTE").ToString
                                    objBoletimProd.pDsTipo = drBoletimProdFrente.Item("DS_TIPO").ToString
                                    objBoletimProd.pDsFrenteTipo = drBoletimProdFrente.Item("DS_FRENTETIPO").ToString
                                    objBoletimProd.pPlanejado = drBoletimProdFrente.Item("PLANEJADO")
                                    objBoletimProd.pRealizado = drBoletimProdFrente.Item("REALIZADO")
                                    objBoletimProd.pPerc = drBoletimProdFrente.Item("PERC")
                                    objBoletimProd.pNota = drBoletimProdFrente.Item("NOTA")
                                    objBoletimProd.pNotaCalc = drBoletimProdFrente.Item("NOTAcalc")

                                    BoletimProd.Add(objBoletimProd)
                                Loop

                                drBoletimProdFrente.Close()
                            End If
                            'Catch ex As Exception
                            '    MsgBox(ex.Message)
                        Finally
                            If (Not (drBoletimProdFrente) Is Nothing) Then
                                drBoletimProdFrente.Dispose()
                            End If
                        End Try

                        Dim BoletimProdOrd = BoletimProd.OrderBy(Function(x) x.pDsFrenteTipo).ThenBy(Function(x) x.pIndicador).ThenBy(Function(x) x.pUnidadeMedida)

                        If BoletimProdOrd.FirstOrDefault.pFrenteTipoFlg = "F" Then
                            ASPxHiddenField.Set("hfFrenteAtual", BoletimProdOrd.FirstOrDefault.pFrente)
                            ASPxButtonResultadoFrente.Text = "Resultados % " & BoletimProdOrd.FirstOrDefault.pDsFrenteTipo.ToString
                            ASPxButtonEquip.Text = "Equipamento " & BoletimProdOrd.FirstOrDefault.pDsFrenteTipo.ToString
                            ASPxHiddenField.Set("hfTipoAtual", "")
                        Else
                            ASPxHiddenField.Set("hfFrenteAtual", "")
                            ASPxButtonResultadoFrente.Text = "Resultados % " & BoletimProdOrd.FirstOrDefault.pDsFrenteTipo.ToString
                            ASPxButtonEquip.Text = "Equipamento " & BoletimProdOrd.FirstOrDefault.pDsFrenteTipo.ToString
                            ASPxHiddenField.Set("hfTipoAtual", BoletimProdOrd.FirstOrDefault.pTipo)
                        End If
                        ASPxHiddenField.Set("hfFrenteTipoAtual", BoletimProdOrd.FirstOrDefault.pFrenteTipo)
                        ASPxHiddenField.Set("hfFrenteTipoAtualDs", BoletimProdOrd.FirstOrDefault.pDsFrenteTipo)

                        'ASPxHiddenField.Set("hfFrenteAtual", 1)
                        'ASPxButtonResultadoFrente.Text = "Resultados % COLHEITA F-01"

                    End If
                Finally
                    If (Not (dr) Is Nothing) Then
                        dr.Dispose()
                    End If
                End Try
            Catch ex As Exception

            End Try

            Dim pFrenteAux As String = String.Empty
            Dim group As DevExpress.Web.NavBarGroup = Nothing

            Dim numPagina As Integer = 0

            FrentesNavBar.Groups.Clear()

            For Each objBoletimProd In BoletimProd.OrderBy(Function(x) x.pDsFrenteTipo).ThenBy(Function(x) x.pIndicador).ThenBy(Function(x) x.pUnidadeMedida)
                If objBoletimProd.pFrenteTipo <> pFrenteAux Then
                    numPagina = 1
                    If objBoletimProd.pFrenteTipoFlg = "T" Then
                        group = New NavBarGroup(objBoletimProd.pDsTipo, objBoletimProd.pDsFrenteTipo)
                    Else
                        'group = New NavBarGroup(objBoletimProd.pFrente & " " & objBoletimProd.pGrupo.PadRight(10, " ").Substring(0, 10).Trim, objBoletimProd.pFrenteTipo)
                        group = New NavBarGroup(objBoletimProd.pDsFrente, objBoletimProd.pDsFrenteTipo)
                    End If
                    group.Expanded = False
                    group.DataItem = objBoletimProd
                    FrentesNavBar.Groups.Add(group)
                Else
                    numPagina += 1
                End If

                objBoletimProd.pPaginaNumero = numPagina

                Dim item = New NavBarItem(objBoletimProd.pIndicador, objBoletimProd.pIndicador & objBoletimProd.pFrenteTipo)
                item.Text = objBoletimProd.pIndicador
                item.DataItem = objBoletimProd
                group.Items.Add(item)

                pFrenteAux = objBoletimProd.pFrenteTipo
            Next

            'BOTAO DO RESULTADO DO GANHO EM PERCENTUAL, QUEM TEM PERMISSAO <> N VAI APARECER
            Dim drPermissaoResultado As OracleDataReader = Nothing

            Try
                conn = New OracleConnection(oradb)
                conn.Open()

                Dim cmdPermissaoResultado As New OracleCommand(String.Format("SELECT NVL(F_VERIFICA_ACESSO_CAMPOS_AUX(3873, '{0}', 1, 'AUX_01'), 'S') AS RESULTADO FROM DUAL", User.Identity.GetUserName.ToUpper), conn) With {.CommandType = CommandType.Text}

                drPermissaoResultado = cmdPermissaoResultado.ExecuteReader()
                If drPermissaoResultado.HasRows Then
                    drPermissaoResultado.Read()
                    If drPermissaoResultado.Item("RESULTADO").ToString.ToUpper <> "N" Then
                        ASPxButtonResultadoFrente.ClientVisible = True
                        ASPxButtonEquip.ClientVisible = True
                    Else
                        ASPxButtonResultadoFrente.ClientVisible = False
                        ASPxButtonEquip.ClientVisible = False
                    End If
                    drPermissaoResultado.Close()
                End If
            Catch

            Finally
                If (Not (drPermissaoResultado) Is Nothing) Then
                    drPermissaoResultado.Dispose()
                End If
            End Try


        End If

        ASPxDataView1.DataSourceID = ""
        ASPxDataView1.DataBind()

        SetaVisibilidadeColunasGridResumoGanhoDataRef(CDate(ASPxComboDataFechamento.Value))

        gridResumoGanho.DataSourceID = ""
        gridResumoGanho.DataBind()

        ASPxGridView2.DataSourceID = ""
        ASPxGridView2.DataBind()

        ASPxGridView2.SettingsText.Title = "Indicadores Agrícolas Por Equipamento"

        If ASPxHiddenField.Contains("hfFrenteTipoAtualDs") Then
            If ASPxHiddenField("hfFrenteTipoAtualDs").ToString <> "" Then
                ASPxGridView2.SettingsText.Title &= " ( " & ASPxHiddenField("hfFrenteTipoAtualDs").ToString & " )"
            End If
        End If
    End Sub

    Private Sub SetaVisibilidadeColunasGridResumoGanhoDataRef(parDataRef As Date)
        If parDataRef <= New DateTime(2016, 12, 31, 0, 0, 0) Then
            'ESCONDER 4 COLUNAS

            gridResumoGanho.Columns("ENTREGA_DE_CANA").Visible = False
            gridResumoGanho.Columns("PISOTEIO_SOQUEIRA").Visible = False
            gridResumoGanho.Columns("DISPONIBILIDADE_MECANICA").Visible = False
            gridResumoGanho.Columns("MAPA_DE_PARADA").Visible = False

            gridResumoGanho.Columns("DISP_MECANICA_COLHEDORA").Visible = True
            gridResumoGanho.Columns("DISP_MECANICA_DEMAIS").Visible = True

        Else
            gridResumoGanho.Columns("ENTREGA_DE_CANA").Visible = True
            gridResumoGanho.Columns("PISOTEIO_SOQUEIRA").Visible = True
            gridResumoGanho.Columns("DISPONIBILIDADE_MECANICA").Visible = True
            gridResumoGanho.Columns("MAPA_DE_PARADA").Visible = True

            gridResumoGanho.Columns("DISP_MECANICA_COLHEDORA").Visible = False
            gridResumoGanho.Columns("DISP_MECANICA_DEMAIS").Visible = False
        End If

    End Sub

    Private Function FrenteTipoTitulo(ByVal parFrenteTipo As String) As String
        Select Case parFrenteTipo
            Case "CAMINHAO"
                FrenteTipoTitulo = "Caminhão"
            Case "COLETA_PALHA"
                FrenteTipoTitulo = "Coleta Palha"
            Case "CONSERVACAO_GERAL"
                FrenteTipoTitulo = "Conservação Geral"
            Case "FORMIGA"
                FrenteTipoTitulo = "Formiga"
            Case "FULIGEM_VLC_TORTA_FILTRO"
                FrenteTipoTitulo = "Fuligem Vlc Torta Filtro"
            Case "GENO"
                FrenteTipoTitulo = "Geno"
            Case "HERBICICLO"
                FrenteTipoTitulo = "Herbiciclo"
            Case "MOTORISTA_ADUBACAO"
                FrenteTipoTitulo = "Motorista Adubação"
            Case "MOTORISTA_HERBICIDA_BARRA"
                FrenteTipoTitulo = "Motorista Herbicida Barra"
            Case "MOTORISTA_PATIO"
                FrenteTipoTitulo = "Motorista Pátio"
            Case "MOTORISTA_PIPA"
                FrenteTipoTitulo = "Motorista Pipa"
            Case "MOTORISTA_PRANCHA"
                FrenteTipoTitulo = "Motorista Prancha"
            Case "OFICINA_MANUT_AUTOMOTIVA"
                FrenteTipoTitulo = "Oficina Manutenção Automotiva"
            Case "OFICINA_MANUT_BASICA"
                FrenteTipoTitulo = "Oficina Manutenção Básica"
            Case "PREPARO_DE_SOLO"
                FrenteTipoTitulo = "Preparo de Solo"
            Case "VINHACA_CAMINHAO_MOTORISTA"
                FrenteTipoTitulo = "Vinhaça Caminhão Motorista"
            Case "VINHACA_CANAL_AGUA_TRATORISTA"
                FrenteTipoTitulo = "Vinhaça Canal Água Trat."

            Case Else
                FrenteTipoTitulo = parFrenteTipo
        End Select
    End Function

    Function FrenteTipoTituloDataView(ByVal parFrenteTipo As String, ByVal parGrupo As String) As String
        Dim i As Integer
        If Integer.TryParse(parFrenteTipo, i) Then
            FrenteTipoTituloDataView = parFrenteTipo & " " & parGrupo.PadRight(10, " ").Substring(0, 10).Trim
        Else
            FrenteTipoTituloDataView = FrenteTipoTitulo(parFrenteTipo)
        End If
    End Function

    Protected Sub ASPxGaugeControl1_Init(sender As Object, e As EventArgs)
        Dim gaugeIndicador As DevExpress.Web.ASPxGauges.ASPxGaugeControl = TryCast(sender, DevExpress.Web.ASPxGauges.ASPxGaugeControl)

        Dim containerFormLayout As DevExpress.Web.ASPxFormLayout = DirectCast(gaugeIndicador.NamingContainer, DevExpress.Web.ASPxFormLayout)
        Dim container As DevExpress.Web.DataViewItemTemplateContainer = DirectCast(containerFormLayout.NamingContainer, DevExpress.Web.DataViewItemTemplateContainer)

        gaugeIndicador.GraphicsProperties.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim strTextFormatLabels = "{0:#,#0}"
        If DataBinder.Eval(container.DataItem, "INDICADOR") = "DISP_MECANICA_COLHEDORA" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "DISP_MECANICA_DEMAIS" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "IMPUREZA_MINERAL" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "IMPUREZA_VEGETAL" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "PERDAS" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "TEMPO_APROVEIT_COLHEDORA" Then
            strTextFormatLabels = "{0:#,#0.00}"
        ElseIf DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_HIDRAULICO" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL_COLHEDORA" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL_TRATOR" Then
            strTextFormatLabels = "{0:#,#0.0000}"
        ElseIf DataBinder.Eval(container.DataItem, "INDICADOR") = "TEMPO_ATENDIMENTO" Then
            strTextFormatLabels = "{0:#,#0.0}"
        End If

        If DataBinder.Eval(container.DataItem, "INDICADOR") = "DISP_MECANICA_COLHEDORA" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "DISP_MECANICA_DEMAIS" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "TEMPO_APROVEIT_COLHEDORA" Or
            (CDate(ASPxComboDataFechamento.Value) > New DateTime(2015, 7, 20, 0, 0, 0) And
             (DataBinder.Eval(container.DataItem, "INDICADOR") = "PREVENTIVA_MANUT_BASICA" Or
              DataBinder.Eval(container.DataItem, "INDICADOR") = "PREVENTIVA_MECANICA")) Then

            'TIME DO QUANTO MENOR MELHOR - #CE8396 = COR VERMELHA = RUIM 

            Dim scale As DevExpress.Web.ASPxGauges.Gauges.Linear.LinearScaleComponent = DirectCast(gaugeIndicador.Gauges(0), DevExpress.Web.ASPxGauges.Gauges.Linear.LinearGauge).Scales(0)

            scale.Value = Convert.ToDouble(DataBinder.Eval(container.DataItem, "REALIZADO"))

            'scale.MinValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) - 10
            'scale.MaxValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) + 10

            scale.MinValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 - (Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ABAIXO_META")) + 5) / 100)
            scale.MaxValue = Convert.ToDouble(DataBinder.Eval(container.DataItem, "PLANEJADO")) * (1 + (Convert.ToDouble(DataBinder.Eval(container.DataItem, "PERC_ACIMA_META")) + 5) / 100)

            scale.MajorTickCount = 0
            scale.MinorTickCount = 0

            scale.MajorTickmark.ShowTick = False
            scale.MinorTickmark.ShowTick = False

            scale.Ranges(0).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#CE8396"))   ' #CE8396 = COR VERMELHA = RUIM
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

        ElseIf DataBinder.Eval(container.DataItem, "INDICADOR") = "PERDAS" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "IMPUREZA_MINERAL" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "IMPUREZA_VEGETAL" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "TEMPO_ATENDIMENTO" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "PISOTEIO_SOQUEIRA" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL_COLHEDORA" Or
           DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL_TRATOR" Or
            ((DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL") And DataBinder.Eval(container.DataItem, "UNIDADE_MEDIDA") <> "KM/L") Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_HIDRAULICO" Or
            (CDate(ASPxComboDataFechamento.Value) <= New DateTime(2015, 7, 20, 0, 0, 0) And
             (DataBinder.Eval(container.DataItem, "INDICADOR") = "PREVENTIVA_MANUT_BASICA" Or
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

            scale.Ranges(0).AppearanceRange.ContentBrush = New SolidBrushObject(System.Drawing.ColorTranslator.FromHtml("#67DD63"))  ' #67DD63 = COR VERDE = ÓTIMO 
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

        'If DataBinder.Eval(container.DataItem, "INDICADOR") = "PRODUTIVIDADE" Or _
        '   DataBinder.Eval(container.DataItem, "INDICADOR") = "DISP_MECANICA_COLHEDORA" Or _
        '   DataBinder.Eval(container.DataItem, "INDICADOR") = "DISP_MECANICA_DEMAIS" Or _
        '   DataBinder.Eval(container.DataItem, "INDICADOR") = "TEMPO_APROVEIT_COLHEDORA" Then
        '    Dim scale As DevExpress.Web.ASPxGauges.Gauges.Linear.LinearScaleComponent = DirectCast(gaugeIndicador.Gauges(0), DevExpress.Web.ASPxGauges.Gauges.Linear.LinearGauge).Scales(0)

        '    scale.MajorTickmark.FormatString = "{0:#,#0}"
        'ElseIf DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_HIDRAULICO" Then
        '    Dim scale As DevExpress.Web.ASPxGauges.Gauges.Linear.LinearScaleComponent = DirectCast(gaugeIndicador.Gauges(0), DevExpress.Web.ASPxGauges.Gauges.Linear.LinearGauge).Scales(0)

        '    scale.MajorTickmark.FormatString = "{0:#,#0.000}"
        'End If
    End Sub

    Function IndicadoresINDICADORCalc(parINDICADOR As String) As String
        IndicadoresINDICADORCalc = ""

        Select Case parINDICADOR
            Case "CONSUMO_OLEO_DIESEL"
                IndicadoresINDICADORCalc = "Consumo Óleo Diesel"
            Case "CONSUMO_OLEO_HIDRAULICO"
                IndicadoresINDICADORCalc = "Consumo Óleo Hidráulico"
            Case "DISP_MECANICA_COLHEDORA"
                IndicadoresINDICADORCalc = "Disponibilidade Mecânica Colhedora"
            Case "DISP_MECANICA_DEMAIS"
                IndicadoresINDICADORCalc = "Disponibilidade Mecânica Demais Equipamentos"
            Case "IMPUREZA_MINERAL"
                IndicadoresINDICADORCalc = "Impureza Mineral"
            Case "IMPUREZA_VEGETAL"
                IndicadoresINDICADORCalc = "Impureza Vegetal"
            Case "PERDAS"
                IndicadoresINDICADORCalc = "Perdas"
            Case "PREVENTIVA_MANUT_BASICA"
                IndicadoresINDICADORCalc = "Preventiva Manutenção Básica"
            Case "PREVENTIVA_MECANICA"
                IndicadoresINDICADORCalc = "Preventiva Mecânica"
            Case "PRODUTIVIDADE"
                IndicadoresINDICADORCalc = "Produtividade"
            Case "TEMPO_APROVEIT_COLHEDORA"
                IndicadoresINDICADORCalc = "Tempo Aproveitável Colhedora"
            Case "TEMPO_ATENDIMENTO"
                IndicadoresINDICADORCalc = "Tempo Atendimento"
            Case "CONSUMO_OLEO_DIESEL_COLHEDORA"
                IndicadoresINDICADORCalc = "Consumo Oleo Diesel - Colh."
            Case "CONSUMO_OLEO_DIESEL_TRATOR"
                IndicadoresINDICADORCalc = "Consumo Oleo Diesel - Trator"
            Case "DISPONIBILIDADE_MECANICA"
                IndicadoresINDICADORCalc = "Disponibilidade Técnica"
            Case "ENTREGA_DE_CANA"
                IndicadoresINDICADORCalc = "Entrega de Cana"
            Case "PISOTEIO_SOQUEIRA"
                IndicadoresINDICADORCalc = "Pisoteio Soqueira"
            Case "MAPA_DE_PARADA"
                IndicadoresINDICADORCalc = "Mapa de Parada"
            Case "TON_HA_PROPRIA"
                IndicadoresINDICADORCalc = "TON/HA - Própria"
            Case "TON_HA_FORNECEDOR"
                IndicadoresINDICADORCalc = "TON/HA - Fornecedor"
            Case "TON_HA_TOTAL"
                IndicadoresINDICADORCalc = "TON/HA - Total"
        End Select
    End Function
    Function IndicadoresINDICADORCalcAbrev(parINDICADOR As String) As String
        Select Case parINDICADOR
            Case "CONSUMO_OLEO_DIESEL"
                IndicadoresINDICADORCalcAbrev = "Consumo Óleo Diesel"
            Case "CONSUMO_OLEO_HIDRAULICO"
                IndicadoresINDICADORCalcAbrev = "Consumo Óleo Hidráulico"
            Case "DISP_MECANICA_COLHEDORA"
                IndicadoresINDICADORCalcAbrev = "Disp. Mecânica Colhedora"
            Case "DISP_MECANICA_DEMAIS"
                IndicadoresINDICADORCalcAbrev = "Disp. Mecânica D. Equip."
            Case "IMPUREZA_MINERAL"
                IndicadoresINDICADORCalcAbrev = "Impureza Mineral"
            Case "IMPUREZA_VEGETAL"
                IndicadoresINDICADORCalcAbrev = "Impureza Vegetal"
            Case "PERDAS"
                IndicadoresINDICADORCalcAbrev = "Perdas"
            Case "PREVENTIVA_MANUT_BASICA"
                IndicadoresINDICADORCalcAbrev = "Preventiva Manut.Básica"
            Case "PREVENTIVA_MECANICA"
                IndicadoresINDICADORCalcAbrev = "Preventiva Mecânica"
            Case "PRODUTIVIDADE"
                IndicadoresINDICADORCalcAbrev = "Produtividade"
            Case "TEMPO_APROVEIT_COLHEDORA"
                IndicadoresINDICADORCalcAbrev = "Tempo Aprov. Colhedora"
            Case "TEMPO_ATENDIMENTO"
                IndicadoresINDICADORCalcAbrev = "Tempo Atendimento"
            Case "CONSUMO_OLEO_DIESEL_COLHEDORA"
                IndicadoresINDICADORCalcAbrev = "Consumo Oleo Diesel - Colh."
            Case "CONSUMO_OLEO_DIESEL_TRATOR"
                IndicadoresINDICADORCalcAbrev = "Consumo Oleo Diesel - Trator"
            Case "DISPONIBILIDADE_MECANICA"
                IndicadoresINDICADORCalcAbrev = "Disp. Técnica"
            Case "ENTREGA_DE_CANA"
                IndicadoresINDICADORCalcAbrev = "Entrega Cana"
            Case "PISOTEIO_SOQUEIRA"
                IndicadoresINDICADORCalcAbrev = "Pisoteio Soqueira"
            Case "MAPA_DE_PARADA"
                IndicadoresINDICADORCalcAbrev = "Mapa de Parada"
            Case "TON_HA_PROPRIA"
                IndicadoresINDICADORCalcAbrev = "TON/HA Própria"
            Case "TON_HA_FORNECEDOR"
                IndicadoresINDICADORCalcAbrev = "TON/HA Fornecedor"
            Case "TON_HA_TOTAL"
                IndicadoresINDICADORCalcAbrev = "TON/HA Total"
            Case Else
                IndicadoresINDICADORCalcAbrev = parINDICADOR
        End Select
    End Function

    Protected Sub ASPxHyperLink1_Load(sender As Object, e As EventArgs)
        Dim hl As ASPxHyperLink = TryCast(sender, ASPxHyperLink)
        Dim container As DevExpress.Web.NavBarItemTemplateContainer = DirectCast(hl.NamingContainer, DevExpress.Web.NavBarItemTemplateContainer)

        hl.ClientSideEvents.Click = String.Format("function(s, e) {{ OnClick(s, e, '{0}', '{1}', '{2}', '{3}') }}", DataBinder.Eval(container.Item.DataItem, "pFrenteTipoFlg"), DataBinder.Eval(container.Item.DataItem, "pFrenteTipo"), DataBinder.Eval(container.Item.DataItem, "pDsFrenteTipo"), DataBinder.Eval(container.Item.DataItem, "pPaginaNumero"))
    End Sub


    Private Sub ASPxDataView1_CustomCallback(sender As Object, e As CallbackEventArgsBase) Handles ASPxDataView1.CustomCallback
        If ASPxHiddenField.Contains("hfPaginaAtual") Then
            ASPxDataView1.PageIndex = Convert.ToInt16(ASPxHiddenField("hfPaginaAtual") - 1)
        End If
    End Sub

    Protected Sub ASPxDataView1_DataBinding(sender As Object, e As EventArgs) Handles ASPxDataView1.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        Dim codFrenteAtual As Integer = 0
        Dim dscTipoAtual As String = String.Empty

        If ASPxHiddenField.Contains("hfFrenteAtual") Then
            If ASPxHiddenField("hfFrenteAtual").ToString <> "" Then
                codFrenteAtual = Convert.ToInt16(ASPxHiddenField("hfFrenteAtual"))
            End If
        End If

        If ASPxHiddenField.Contains("hfTipoAtual") Then
            If ASPxHiddenField("hfTipoAtual") <> "" Then
                dscTipoAtual = ASPxHiddenField("hfTipoAtual")
            End If
        End If

        Dim conn As OracleConnection = New OracleConnection(oradb)
        conn.Open()

        Dim cmd As OracleCommand

        If codFrenteAtual <> 0 Then
            cmd = New OracleCommand("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0), 4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0), 4) REALIZADO, ROUND(NVL(A.PERC, 0), 4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0), 4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0), 4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C, SISAGRI.FRENTE_SERVICO_GRUPO D where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) AND B.ID_NEGOCIOS = D.ID_NEGOCIOS(+) AND B.ID_FRENTE_SERVICO_GRUPO = D.ID_FRENTE_SERVICO_GRUPO(+) AND A.FRENTE = :p0 and A.DATA_FECHAMENTO = :p1 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)), A.INDICADOR, A.UNIDADE_MEDIDA", conn) With {.CommandType = CommandType.Text}

            cmd.Parameters.Add(":p0", OracleDbType.Int16).Value = codFrenteAtual
            cmd.Parameters.Add(":p1", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
        Else
            cmd = New OracleCommand("select DECODE(A.NOTA, 'RUIM', 4, 'REGULAR', 3, 'BOM', 2, 'OTIMO', 0) NOTAcalc, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)) DS_FRENTETIPO, A.ID_NEGOCIOS, A.INDICADOR, A.FRENTE, ROUND(NVL(A.PLANEJADO, 0), 4) PLANEJADO, ROUND(NVL(A.REALIZADO, 0), 4) REALIZADO, ROUND(NVL(A.PERC, 0), 4) PERC, A.NOTA, A.DATA_FECHAMENTO, A.UNIDADE_MEDIDA, ROUND(NVL(A.PERC_ABAIXO_META, 0), 4) PERC_ABAIXO_META, ROUND(NVL(A.PERC_ACIMA_META, 0), 4) PERC_ACIMA_META, A.TIPO, A.GRUPO from BI4T.INDICADORES_AGRICOLA A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C, SISAGRI.FRENTE_SERVICO_GRUPO D where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) AND B.ID_NEGOCIOS = D.ID_NEGOCIOS(+) AND B.ID_FRENTE_SERVICO_GRUPO = D.ID_FRENTE_SERVICO_GRUPO(+) AND A.TIPO = :p0 and A.DATA_FECHAMENTO = :p1 and A.NOTA IS NOT NULL and A.PLANEJADO > 0 order by decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, DECODE(D.SN_AGRUPAR, 'S', D.DS_FRENTE_SERVICO_GRUPO, B.FRCO_DESCRICAO)), A.INDICADOR, A.UNIDADE_MEDIDA", conn) With {.CommandType = CommandType.Text}

            cmd.Parameters.Add(":p0", OracleDbType.Varchar2).Value = dscTipoAtual
            cmd.Parameters.Add(":p1", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
        End If

        Dim dr As OracleDataReader = cmd.ExecuteReader()

        ASPxDataView1.DataSource = dr

    End Sub
    Private Sub ASPxGridView2_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView2.DataBinding
        If ASPxHiddenField.Contains("hfFrenteTipoAtual") Then
            If ASPxHiddenField("hfFrenteTipoAtual").ToString <> "" Then


                Dim codFrenteAtual As Integer = 0
                Dim dscTipoAtual As String = String.Empty

                If ASPxHiddenField.Contains("hfFrenteAtual") Then
                    If ASPxHiddenField("hfFrenteAtual").ToString <> "" Then
                        codFrenteAtual = Convert.ToInt16(ASPxHiddenField("hfFrenteAtual"))
                    End If
                End If

                If ASPxHiddenField.Contains("hfTipoAtual") Then
                    If ASPxHiddenField("hfTipoAtual") <> "" Then
                        dscTipoAtual = ASPxHiddenField("hfTipoAtual")
                    End If
                End If


                Dim oradb As String = AppUtils.dbConnectionString

                Dim conn As OracleConnection = New OracleConnection(oradb)
                Dim cmd As OracleCommand
                conn.Open()


                strFrentesTipoAtual = ASPxHiddenField("hfFrenteTipoAtual")

                cmd = New OracleCommand("select decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)) FRENTETIPO, decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) FRENTETIPOAUX, B.FRCO_DESCRICAO DS_FRENTE, C.DSC_REDUZIDA DS_TIPO, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO) DS_FRENTETIPO, A.ID_NEGOCIOS, A.FRENTE, A.DATA_FECHAMENTO, A.TIPO, A.GRUPO, A.DSC_EQUIPAMENTO, A.NRO_EQUIPAMENTO, A.DSC_ULTIMA_OPERACAO, A.CONSUMO_PADRAO_OPER, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'DISP_MECANICA_COLHEDORA'), 4) R_DISP_MECANICA_COLHEDORA, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'DISP_MECANICA_DEMAIS'), 4) R_DISP_MECANICA_DEMAIS, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR IN ('DISP_MECANICA_COLHEDORA', 'DISP_MECANICA_DEMAIS','DISPONIBILIDADE_MECANICA')), 4) R_DISP_MECANICA, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR IN ('CONSUMO_OLEO_DIESEL', 'CONSUMO_OLEO_DIESEL_COLHEDORA', 'CONSUMO_OLEO_DIESEL_TRATOR') AND B1.UNIDADE_MEDIDA = 'LT/H'), 4) R_CONSUMO_OLEO_DIESELLTH, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR IN ('CONSUMO_OLEO_DIESEL', 'CONSUMO_OLEO_DIESEL_COLHEDORA', 'CONSUMO_OLEO_DIESEL_TRATOR') AND B1.UNIDADE_MEDIDA = 'KM/L'), 4) R_CONSUMO_OLEO_DIESELKML, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR IN ('CONSUMO_OLEO_DIESEL', 'CONSUMO_OLEO_DIESEL_COLHEDORA', 'CONSUMO_OLEO_DIESEL_TRATOR') AND B1.UNIDADE_MEDIDA = 'LT/TON'), 4) R_CONSUMO_OLEO_DIESELLTTON, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'CONSUMO_OLEO_HIDRAULICO'), 4) R_CONSUMO_OLEO_HIDRAULICO, ROUND((SELECT MAX(NVL(B1.REALIZADO, 0)) FROM BI4T.INDICADORES_AGRICOLA_EQUIP B1 WHERE B1.ID_NEGOCIOS = A.ID_NEGOCIOS AND NVL(B1.FRENTE, 0) = NVL(A.FRENTE, 0) AND B1.DATA_FECHAMENTO = A.DATA_FECHAMENTO AND NVL(B1.TIPO, 'XXX') = NVL(A.TIPO, 'XXX') AND B1.GRUPO = A.GRUPO AND B1.NRO_EQUIPAMENTO = A.NRO_EQUIPAMENTO AND B1.INDICADOR = 'TEMPO_APROVEIT_COLHEDORA'), 4) R_TEMPO_APROVEIT_COLHEDORA from BI4T.INDICADORES_AGRICOLA_EQUIP A, SISAGRI.FRENTE_SERVICO B, SISCOMAG.CA_TIPO_COMISSAO C where A.ID_NEGOCIOS = B.ID_NEGOCIOS(+) AND A.FRENTE = B.ID_FRENTE_SERVICO(+) AND A.TIPO = C.ID_TIPO(+) and decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0')) = :p0 and A.DATA_FECHAMENTO = :p1 GROUP BY decode(A.FRENTE, NULL, A.TIPO, LPAD(A.FRENTE, 3, '0') || ' ' || SUBSTR(A.GRUPO, 1, 10)), B.FRCO_DESCRICAO, C.DSC_REDUZIDA, decode(B.FRCO_DESCRICAO, NULL, C.DSC_REDUZIDA, B.FRCO_DESCRICAO), A.ID_NEGOCIOS, A.FRENTE, A.DATA_FECHAMENTO, A.TIPO, A.GRUPO, A.DSC_EQUIPAMENTO, A.NRO_EQUIPAMENTO, A.DSC_ULTIMA_OPERACAO, A.CONSUMO_PADRAO_OPER", conn) With {.CommandType = CommandType.Text}

                cmd.Parameters.Add(":p0", OracleDbType.Varchar2).Value = strFrentesTipoAtual
                cmd.Parameters.Add(":p1", OracleDbType.Date).Value = ASPxComboDataFechamento.Value

                Dim dr As OracleDataReader = cmd.ExecuteReader()

                ASPxGridView2.DataSource = dr

            End If
        End If
    End Sub

    Protected Sub ASPxLabel1_Init(sender As Object, e As EventArgs)
        Dim label As DevExpress.Web.ASPxLabel = TryCast(sender, DevExpress.Web.ASPxLabel)

        Dim containerFormLayout As DevExpress.Web.ASPxFormLayout = DirectCast(label.NamingContainer, DevExpress.Web.ASPxFormLayout)
        Dim container As DevExpress.Web.DataViewItemTemplateContainer = DirectCast(containerFormLayout.NamingContainer, DevExpress.Web.DataViewItemTemplateContainer)

        If DataBinder.Eval(container.DataItem, "INDICADOR") = "PRODUTIVIDADE" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "ENTREGA_DE_CANA" Then
            label.Text = String.Format("{0:#,#0}", DataBinder.Eval(container.DataItem, "REALIZADO"))
        ElseIf DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_HIDRAULICO" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL_COLHEDORA" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL_TRATOR" Then
            label.Text = String.Format("{0:#,#0.0000}", DataBinder.Eval(container.DataItem, "REALIZADO"))
        Else
            label.Text = String.Format("{0:#,#0.00}", DataBinder.Eval(container.DataItem, "REALIZADO"))
        End If
    End Sub

    Protected Sub ASPxLabelPlanejado_Init(sender As Object, e As EventArgs)
        Dim label As DevExpress.Web.ASPxLabel = TryCast(sender, DevExpress.Web.ASPxLabel)

        Dim containerFormLayout As DevExpress.Web.ASPxFormLayout = DirectCast(label.NamingContainer, DevExpress.Web.ASPxFormLayout)
        Dim container As DevExpress.Web.DataViewItemTemplateContainer = DirectCast(containerFormLayout.NamingContainer, DevExpress.Web.DataViewItemTemplateContainer)

        If DataBinder.Eval(container.DataItem, "INDICADOR") = "PRODUTIVIDADE" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "ENTREGA_DE_CANA" Then
            label.Text = String.Format("{0:#,#0}", DataBinder.Eval(container.DataItem, "PLANEJADO"))
        ElseIf DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_HIDRAULICO" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL_COLHEDORA" Or
            DataBinder.Eval(container.DataItem, "INDICADOR") = "CONSUMO_OLEO_DIESEL_TRATOR" Then
            label.Text = String.Format("{0:#,#0.0000}", DataBinder.Eval(container.DataItem, "PLANEJADO"))
        Else
            label.Text = String.Format("{0:#,#0.00}", DataBinder.Eval(container.DataItem, "PLANEJADO"))
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

    Protected Sub gridResumoGanho_DataBinding(sender As Object, e As EventArgs) Handles gridResumoGanho.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        Dim cmd As OracleCommand
        Dim cmdIndic As OracleCommand

        conn.Open()


        Dim codFrenteAtual As Integer = 0
        Dim dscTipoAtual As String = String.Empty

        If ASPxHiddenField.Contains("hfFrenteAtual") Then
            If ASPxHiddenField("hfFrenteAtual").ToString <> "" Then
                codFrenteAtual = Convert.ToInt16(ASPxHiddenField("hfFrenteAtual"))
            End If
        End If

        If ASPxHiddenField.Contains("hfTipoAtual") Then
            If ASPxHiddenField("hfTipoAtual") <> "" Then
                dscTipoAtual = ASPxHiddenField("hfTipoAtual")
            End If
        End If

        If codFrenteAtual <> 0 Then
            'TODAS AS FRENTES
            cmd = New OracleCommand("select ID_NEGOCIOS, DATA_FECHAMENTO, ID_PROCESSO, GRUPO, FRENTE, NVL(FRENTE,0) FRENTE_AUX, TIPO, DESC_FRENTE_TIPO, PRODUTIVIDADE, IMP_MINERAL IMPUREZA_MINERAL, IMP_VEGETAL IMPUREZA_VEGETAL, PERDAS, CONSUMO_OLEO_DIESEL, CONSUMO_OLEO_DIESEL_COLHEDORA, CONSUMO_OLEO_DIESEL_TRATOR, CONSUMO_OLEO_HIDRAULICO, DISP_MEC_COLHEDORA DISP_MECANICA_COLHEDORA, DISP_MEC_COLHEDORA_SN, DISP_MEC_DEMAIS DISP_MECANICA_DEMAIS, DISP_MEC, TEMPO_AP_COLHEDORA TEMPO_APROVEIT_COLHEDORA, GANHO_BONUS, decode(FRENTE, NULL, TIPO, LPAD(FRENTE, 3, '0')) FRENTETIPO, PREVENTIVA_MECANICA, PREVENTIVA_MANUT_BASICA, TEMPO_ATENDIMENTO, QTD_MAX_HORAS_A_PAGAR, ENTREGA_DE_CANA, PISOTEIO_SOQUEIRA, MAPA_DE_PARADA, DISPONIBILIDADE_MECANICA from v_resumo_ganho_indicadores where DATA_FECHAMENTO = :p0 and FRENTE = :p1", conn) With {.CommandType = CommandType.Text}

            cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
            cmd.Parameters.Add(":p1", OracleDbType.Int16).Value = codFrenteAtual
        Else
            'TODAS AS FRENTES
            cmd = New OracleCommand("select ID_NEGOCIOS, DATA_FECHAMENTO, ID_PROCESSO, GRUPO, FRENTE, NVL(FRENTE,0) FRENTE_AUX, TIPO, DESC_FRENTE_TIPO, PRODUTIVIDADE, IMP_MINERAL IMPUREZA_MINERAL, IMP_VEGETAL IMPUREZA_VEGETAL, PERDAS, CONSUMO_OLEO_DIESEL, CONSUMO_OLEO_DIESEL_COLHEDORA, CONSUMO_OLEO_DIESEL_TRATOR, CONSUMO_OLEO_HIDRAULICO, DISP_MEC_COLHEDORA DISP_MECANICA_COLHEDORA, DISP_MEC_COLHEDORA_SN, DISP_MEC_DEMAIS DISP_MECANICA_DEMAIS, DISP_MEC, TEMPO_AP_COLHEDORA TEMPO_APROVEIT_COLHEDORA, GANHO_BONUS, decode(FRENTE, NULL, TIPO, LPAD(FRENTE, 3, '0')) FRENTETIPO, PREVENTIVA_MECANICA, PREVENTIVA_MANUT_BASICA, TEMPO_ATENDIMENTO, QTD_MAX_HORAS_A_PAGAR, ENTREGA_DE_CANA, PISOTEIO_SOQUEIRA, MAPA_DE_PARADA, DISPONIBILIDADE_MECANICA from v_resumo_ganho_indicadores where DATA_FECHAMENTO = :p0 and TIPO = :p1", conn) With {.CommandType = CommandType.Text}

            cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
            cmd.Parameters.Add(":p1", OracleDbType.Varchar2).Value = dscTipoAtual
        End If

        Dim dr As OracleDataReader = cmd.ExecuteReader()

        gridResumoGanho.DataSource = dr


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

    End Sub

    Protected Sub gridResumoGanhoColab_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = CType(sender, ASPxGridView)

        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        conn.Open()
        Dim cmd As OracleCommand
        If (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue().ToString.Split("|")(1) = "0" Then
            'NÃO TEM FRENTE
            cmd = New OracleCommand("select ROWNUM, ID_NEGOCIOS, DATA_HORA, ID_TIPO, FRENTE_SRV, MATRICULA, NOME, CARGO_NA_DATA, DS_CARGO, DIAS_PERIODO, DIAS_TRAB_PERIODO, VLR_HORA_COLAB, QTD_TOTAL_TIPO, QTD_TOTAL_COLAB, VLR_TOTAL_TIPO, VLR_TOTAL_COLAB from BI4T.V_RESUMO_GANHO_COLABORADORES WHERE DATA_HORA = :p0 AND ID_TIPO = :p1", conn) With {.CommandType = CommandType.Text}
            cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
            cmd.Parameters.Add(":p1", OracleDbType.Varchar2).Value = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue().ToString.Split("|")(0)
        Else
            'POSSUI FRENTE DEFINIDA
            cmd = New OracleCommand("select ROWNUM, ID_NEGOCIOS, DATA_HORA, ID_TIPO, FRENTE_SRV, MATRICULA, NOME, CARGO_NA_DATA, DS_CARGO, DIAS_PERIODO, DIAS_TRAB_PERIODO, VLR_HORA_COLAB, QTD_TOTAL_TIPO, QTD_TOTAL_COLAB, VLR_TOTAL_TIPO, VLR_TOTAL_COLAB from BI4T.V_RESUMO_GANHO_COLABORADORES WHERE DATA_HORA = :p0 AND ID_TIPO = :p1 AND FRENTE_SRV = :p2", conn) With {.CommandType = CommandType.Text}
            cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value
            cmd.Parameters.Add(":p1", OracleDbType.Varchar2).Value = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue().ToString.Split("|")(0)
            cmd.Parameters.Add(":p2", OracleDbType.Int16).Value = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue().ToString.Split("|")(1)
        End If


        Dim dr As OracleDataReader = cmd.ExecuteReader()

        detailGridView.DataSourceID = ""
        detailGridView.DataSource = dr

    End Sub


    Protected Sub gridResumoGanho_CustomUnboundColumnData(sender As Object, e As DevExpress.Web.ASPxGridViewColumnDataEventArgs) Handles gridResumoGanho.CustomUnboundColumnData
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

            'valTotal += IIf(IsDBNull(e.GetListSourceFieldValue("PRODUTIVIDADE")), 0, Convert.ToDouble(e.GetListSourceFieldValue("PRODUTIVIDADE"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("IMP_MINERAL")), 0, Convert.ToDouble(e.GetListSourceFieldValue("IMP_MINERAL"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("IMP_VEGETAL")), 0, Convert.ToDouble(e.GetListSourceFieldValue("IMP_VEGETAL"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("PERDAS")), 0, Convert.ToDouble(e.GetListSourceFieldValue("PERDAS"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL")), 0, Convert.ToDouble(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_COLHEDORA")), 0, Convert.ToDouble(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_COLHEDORA"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_TRATOR")), 0, Convert.ToDouble(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_TRATOR"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("CONSUMO_OLEO_HIDRAULICO")), 0, Convert.ToDouble(e.GetListSourceFieldValue("CONSUMO_OLEO_HIDRAULICO"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("DISP_MEC")), 0, Convert.ToDouble(e.GetListSourceFieldValue("DISP_MEC"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("TEMPO_AP_COLHEDORA")), 0, Convert.ToDouble(e.GetListSourceFieldValue("TEMPO_AP_COLHEDORA"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("PREVENTIVA_MECANICA")), 0, Convert.ToDouble(e.GetListSourceFieldValue("PREVENTIVA_MECANICA"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("PREVENTIVA_MANUT_BASICA")), 0, Convert.ToDouble(e.GetListSourceFieldValue("PREVENTIVA_MANUT_BASICA"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("TEMPO_ATENDIMENTO")), 0, Convert.ToDouble(e.GetListSourceFieldValue("TEMPO_ATENDIMENTO")))

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

            'valTotal += IIf(IsDBNull(e.GetListSourceFieldValue("PRODUTIVIDADE")), 0, Convert.ToDouble(e.GetListSourceFieldValue("PRODUTIVIDADE"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("IMP_MINERAL")), 0, Convert.ToDouble(e.GetListSourceFieldValue("IMP_MINERAL"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("IMP_VEGETAL")), 0, Convert.ToDouble(e.GetListSourceFieldValue("IMP_VEGETAL"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("PERDAS")), 0, Convert.ToDouble(e.GetListSourceFieldValue("PERDAS"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL")), 0, Convert.ToDouble(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_COLHEDORA")), 0, Convert.ToDouble(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_COLHEDORA"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_TRATOR")), 0, Convert.ToDouble(e.GetListSourceFieldValue("CONSUMO_OLEO_DIESEL_TRATOR"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("CONSUMO_OLEO_HIDRAULICO")), 0, Convert.ToDouble(e.GetListSourceFieldValue("CONSUMO_OLEO_HIDRAULICO"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("DISP_MEC")), 0, Convert.ToDouble(e.GetListSourceFieldValue("DISP_MEC"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("TEMPO_AP_COLHEDORA")), 0, Convert.ToDouble(e.GetListSourceFieldValue("TEMPO_AP_COLHEDORA"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("PREVENTIVA_MECANICA")), 0, Convert.ToDouble(e.GetListSourceFieldValue("PREVENTIVA_MECANICA"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("PREVENTIVA_MANUT_BASICA")), 0, Convert.ToDouble(e.GetListSourceFieldValue("PREVENTIVA_MANUT_BASICA"))) + _
            '            IIf(IsDBNull(e.GetListSourceFieldValue("TEMPO_ATENDIMENTO")), 0, Convert.ToDouble(e.GetListSourceFieldValue("TEMPO_ATENDIMENTO")))

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
            'ROUND((Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) * valTotal / 100) / 100,4)
            'Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR"))
            'qtdPagar = IIf(IsDBNull(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")), 0, Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")))
            'qtdPagar = IIf(IsDBNull(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")), 0, Math.Round(((Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) * valTotal) / 100) * Convert.ToDouble(e.GetListSourceFieldValue("GANHO_BONUS")) / 100, 2))

            If IsDBNull(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) Then
                qtdPagar = 0
            Else
                qtdPagar = Math.Round(((Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) * valTotal) / 100) + ((((Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) * valTotal) / 100) * Convert.ToDouble(e.GetListSourceFieldValue("GANHO_BONUS"))) / 100), 2)
            End If

            'qtdPagar = IIf(IsDBNull(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")), 0, Math.Round(((Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) * valTotal) / 100) + ((((Convert.ToDouble(e.GetListSourceFieldValue("QTD_MAX_HORAS_A_PAGAR")) * valTotal) / 100) * Convert.ToDouble(e.GetListSourceFieldValue("GANHO_BONUS"))) / 100), 2))

            e.Value = qtdPagar
        End If


    End Sub

    Private Sub gridResumoGanho_HtmlDataCellPrepared(sender As Object, e As ASPxGridViewTableDataCellEventArgs) Handles gridResumoGanho.HtmlDataCellPrepared
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
                e.Cell.BackColor = GetCorIndicador(gridResumoGanho.GetRowValues(e.VisibleIndex, "GRUPO").ToString,
                                                   gridResumoGanho.GetRowValues(e.VisibleIndex, "FRENTE").ToString,
                                                   gridResumoGanho.GetRowValues(e.VisibleIndex, "TIPO").ToString,
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