Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization

<RoutePrefix("api/EstoqueColheitaFrente")>
Public Class EstoqueColheitaFrenteController
    Inherits ApiController

    <DataContract>
    Private Class S5TEstoqueColheita
        <DataMember>
        Public Property oTotais As List(Of S5TEstoqueColheitaTotal)
        <DataMember>
        Public Property oFrentes As List(Of S5TEstoqueColheitaFrente)
        <DataMember>
        Public Property oFazendasDetalhe As List(Of S5TEstoqueColheitaFazendaDetalhe)
    End Class

    <DataContract>
    Private Class S5TEstoqueColheitaTotal
        Public Property ID_NEGOCIOS As Integer
        Public Property SAFRA As Integer
        <DataMember>
        Public Property DESCRICAO As String
        <DataMember>
        Public Property ESTOQUE_DISP As Double
        Public Property DIAS As Integer
        Public Property HORAS As String
        <DataMember>
        Public Property TEMPO As String
    End Class

    <DataContract>
    Private Class S5TEstoqueColheitaFrente
        Public Property ID_NEGOCIOS As Integer
        Public Property SAFRA As Integer
        Public Property FRENTE_LIB As Integer
        <DataMember>
        Public Property FRENTE_LIB_STR As String
        Public Property CARREGADORAS As String
        <DataMember>
        Public Property ESTOQUE_DISP As Double
        Public Property DIAS As Integer
        Public Property HORAS As String
        <DataMember>
        Public Property TEMPO As String
        Public Property QTD_VIAGENS As Integer
        Public Property MEDIA_VIAGENS As Double
        <DataMember>
        Public Property NR_VIAGEM_REST As Integer
        <DataMember>
        Public Property oFazendas As List(Of S5TEstoqueColheitaFrenteFazenda)
    End Class

    <DataContract>
    Private Class S5TEstoqueColheitaFrenteFazenda
        Implements ICloneable
        Public Property ID_NEGOCIOS As Integer
        Public Property SAFRA As Integer
        Public Property FRENTE_LIB As Integer
        <DataMember>
        Public Property COD_PROP As Integer
        Public Property DSC_PROP As String
        Public Property CARREGADORAS As String
        Public Property CAP_COLH_EFETIVA As Double
        <DataMember>
        Public Property ESTOQUE_DISP As Double
        Public Property TON_COLHIDA As Double
        Public Property DIAS As Integer
        Public Property HORAS As String
        <DataMember>
        Public Property TEMPO As String
        Public Property QTD_VIAGENS As Integer
        Public Property MEDIA_VIAGENS As Double
        <DataMember>
        Public Property NR_VIAGEM_REST As Integer
        Public Property COR_PREENCHIMENTO As Integer
        <DataMember>
        Public Property COORD_LONG As Double
        <DataMember>
        Public Property COORD_LAT As Double
        <DataMember>
        Public Property oTalhoes As List(Of S5TEstoqueColheitaFrenteFazendaTalhao)

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class

    <DataContract>
    Private Class S5TEstoqueColheitaFrenteFazendaTalhao
        Implements ICloneable
        Public Property ID_NEGOCIOS As Integer
        <DataMember>
        Public Property DATA_LIB As Date
        <DataMember>
        Public Property LIBE_TIPO_CORTE As Integer
        <DataMember>
        Public Property LIBE_ID_TALH As Integer
        Public Property SAFRA As Integer
        Public Property FRENTE_LIB As Integer
        <DataMember>
        Public Property TALH_CODIGO_PROP As Integer
        Public Property PROP_DESCRICAO As String
        <DataMember>
        Public Property TALH_CODIGO As Integer
        Public Property TIPO_CORTE As String
        Public Property DIAS_LIB As Integer
        Public Property CAP_COLH_EFETIVA As Double
        Public Property PRODUCAO_PLAN As Double
        Public Property PRODUCAO_REAL As Double
        <DataMember>
        Public Property ESTOQUE_DISP As Double
        Public Property RATEIO_COLHEITABILIDADE As Double
        Public Property CARREGADORA_TALHAO As Integer
        Public Property DIAS As Integer
        Public Property HORAS As String
        <DataMember>
        Public Property TEMPO As String

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class

    <DataContract>
    Private Class S5TEstoqueColheitaFazendaDetalhe
        <DataMember>
        Public Property COD_PROP As Integer
        <DataMember>
        Public Property DSC_PROP As String
        <DataMember>
        Public Property CARREGADORAS As String
        <DataMember>
        Public Property FRENTE_LIB As Integer
        <DataMember>
        Public Property FRENTE_LIB_STR As String
        <DataMember>
        Public Property ESTOQUE_DISP As Double
        <DataMember>
        Public Property TON_COLHIDA As Double
        <DataMember>
        Public Property DIAS As Integer
        Public Property HORAS As String
        <DataMember>
        Public Property TEMPO As String
        <DataMember>
        Public Property MEDIA_VIAGENS As Double
        <DataMember>
        Public Property COR_PREENCHIMENTO As Integer
    End Class

    Private Class S5TEstoqueColheitaFazendaCoordenadas
        Public Property ID_NEGOCIOS As Integer
        Public Property PROP_CODIGO As Integer
        Public Property COORD_LONG As Double
        Public Property COORD_LAT As Double
    End Class

    <DataContract>
    Private Class S5TEstoqueColheitaTimer
        <DataMember>
        Public Property TEMPO_TIMER As Integer
    End Class

    Private Function GetTempo(ByVal parDIAS As Integer, ByVal parHORAS As String) As String
        Dim varTempo As String = String.Empty

        If parHORAS = "" Then parHORAS = "00:00"

        varTempo = String.Format("{0}d {1}h", parDIAS, parHORAS)

        GetTempo = varTempo
    End Function

    ' GET api/EstoqueColheitaFrente
    <HttpGet>
    <Route("")>
    Public Function GetValues() As IHttpActionResult
        Dim EstoqueColheita As S5TEstoqueColheita = Nothing

        Dim EstoqueColheitaTotal = New List(Of S5TEstoqueColheitaTotal)

        Dim EstoqueColheitaFrente = New List(Of S5TEstoqueColheitaFrente)

        Dim EstoqueColheitaFrenteFazendas = New List(Of S5TEstoqueColheitaFrenteFazenda)
        Dim EstoqueColheitaFrenteFazendasClone = New List(Of S5TEstoqueColheitaFrenteFazenda)

        Dim EstoqueColheitaFrenteFazendaTalhoes = New List(Of S5TEstoqueColheitaFrenteFazendaTalhao)
        Dim EstoqueColheitaFrenteFazendaTalhoesClone = New List(Of S5TEstoqueColheitaFrenteFazendaTalhao)


        'TOTAL
        Dim EstoqueColheitaTotalBase = GetTotais()

        'FRENTE
        Dim EstoqueColheitaFrenteBase = GetFrentes().OrderBy(Function(x) x.FRENTE_LIB)
        Dim EstoqueColheitaFrenteFazendasBase = GetFazendas()
        Dim EstoqueColheitaFrenteFazendaTalhoesBase = GetTalhoes()

        'COORDENADAS
        Dim EstoqueColheitaFazendaCoordenadasBase = GetFazendasCoordenadas()


        'NÍVEL 1
        For Each objEstoqueColheitaFrenteBase In EstoqueColheitaFrenteBase
            EstoqueColheitaFrenteFazendas.Clear()
            EstoqueColheitaFrenteFazendas = GetFazendas(objEstoqueColheitaFrenteBase.FRENTE_LIB, EstoqueColheitaFrenteFazendasBase)
            EstoqueColheitaFrenteFazendasClone = EstoqueColheitaFrenteFazendas.Select(Function(x) x.Clone()).Cast(Of S5TEstoqueColheitaFrenteFazenda).ToList

            'NÍVEL 2
            Dim EstoqueColheitaFrenteFazendaTalhoesNew As New List(Of S5TEstoqueColheitaFrenteFazenda)

            For Each objEstoqueColheitaFrenteFazendasClone In EstoqueColheitaFrenteFazendas
                EstoqueColheitaFrenteFazendaTalhoes.Clear()
                EstoqueColheitaFrenteFazendaTalhoes = GetTalhoes(objEstoqueColheitaFrenteFazendasClone.FRENTE_LIB, objEstoqueColheitaFrenteFazendasClone.COD_PROP, EstoqueColheitaFrenteFazendaTalhoesBase)
                EstoqueColheitaFrenteFazendaTalhoesClone = EstoqueColheitaFrenteFazendaTalhoes.Select(Function(x) x.Clone()).Cast(Of S5TEstoqueColheitaFrenteFazendaTalhao).ToList

                Dim varFazendaLong As Double = 0
                Dim varFazendaLat As Double = 0

                Dim objEstoqueColheitaFazendaCoordenada = GetFazendaCoordenada(objEstoqueColheitaFrenteFazendasClone.COD_PROP, EstoqueColheitaFazendaCoordenadasBase)

                If objEstoqueColheitaFazendaCoordenada IsNot Nothing Then
                    varFazendaLong = objEstoqueColheitaFazendaCoordenada.COORD_LONG
                    varFazendaLat = objEstoqueColheitaFazendaCoordenada.COORD_LAT
                End If

                EstoqueColheitaFrenteFazendaTalhoesNew.Add(New S5TEstoqueColheitaFrenteFazenda With {.ID_NEGOCIOS = objEstoqueColheitaFrenteFazendasClone.ID_NEGOCIOS, _
                                                                                                     .SAFRA = objEstoqueColheitaFrenteFazendasClone.SAFRA, _
                                                                                                     .FRENTE_LIB = objEstoqueColheitaFrenteFazendasClone.FRENTE_LIB, _
                                                                                                     .COD_PROP = objEstoqueColheitaFrenteFazendasClone.COD_PROP, _
                                                                                                     .DSC_PROP = objEstoqueColheitaFrenteFazendasClone.DSC_PROP, _
                                                                                                     .CARREGADORAS = objEstoqueColheitaFrenteFazendasClone.CARREGADORAS, _
                                                                                                     .CAP_COLH_EFETIVA = objEstoqueColheitaFrenteFazendasClone.CAP_COLH_EFETIVA, _
                                                                                                     .ESTOQUE_DISP = objEstoqueColheitaFrenteFazendasClone.ESTOQUE_DISP, _
                                                                                                     .DIAS = objEstoqueColheitaFrenteFazendasClone.DIAS, _
                                                                                                     .HORAS = objEstoqueColheitaFrenteFazendasClone.HORAS, _
                                                                                                     .TEMPO = objEstoqueColheitaFrenteFazendasClone.TEMPO, _
                                                                                                     .TON_COLHIDA = objEstoqueColheitaFrenteFazendasClone.TON_COLHIDA, _
                                                                                                     .QTD_VIAGENS = objEstoqueColheitaFrenteFazendasClone.QTD_VIAGENS, _
                                                                                                     .MEDIA_VIAGENS = objEstoqueColheitaFrenteFazendasClone.MEDIA_VIAGENS, _
                                                                                                     .NR_VIAGEM_REST = objEstoqueColheitaFrenteFazendasClone.NR_VIAGEM_REST, _
                                                                                                     .COR_PREENCHIMENTO = objEstoqueColheitaFrenteFazendasClone.COR_PREENCHIMENTO, _
                                                                                                     .COORD_LONG = varFazendaLong,
                                                                                                     .COORD_LAT = varFazendaLat,
                                                                                                     .oTalhoes = EstoqueColheitaFrenteFazendaTalhoesClone})
            Next



            EstoqueColheitaFrente.Add(New S5TEstoqueColheitaFrente With {.ID_NEGOCIOS = objEstoqueColheitaFrenteBase.ID_NEGOCIOS, _
                                                                         .SAFRA = objEstoqueColheitaFrenteBase.SAFRA, _
                                                                         .FRENTE_LIB = objEstoqueColheitaFrenteBase.FRENTE_LIB, _
                                                                         .FRENTE_LIB_STR = objEstoqueColheitaFrenteBase.FRENTE_LIB_STR, _
                                                                         .CARREGADORAS = objEstoqueColheitaFrenteBase.CARREGADORAS, _
                                                                         .ESTOQUE_DISP = objEstoqueColheitaFrenteBase.ESTOQUE_DISP, _
                                                                         .DIAS = objEstoqueColheitaFrenteBase.DIAS, _
                                                                         .HORAS = objEstoqueColheitaFrenteBase.HORAS, _
                                                                         .TEMPO = objEstoqueColheitaFrenteBase.TEMPO, _
                                                                         .QTD_VIAGENS = objEstoqueColheitaFrenteBase.QTD_VIAGENS, _
                                                                         .MEDIA_VIAGENS = objEstoqueColheitaFrenteBase.MEDIA_VIAGENS, _
                                                                         .NR_VIAGEM_REST = objEstoqueColheitaFrenteBase.NR_VIAGEM_REST, _
                                                                         .oFazendas = EstoqueColheitaFrenteFazendaTalhoesNew})
        Next

        'FAZENDA DETALHE
        Dim EstoqueColheitaFazendasDetalheBase = GetFazendasDetalhe(EstoqueColheitaFrente)

        EstoqueColheita = New S5TEstoqueColheita With {.oTotais = EstoqueColheitaTotalBase, _
                                                       .oFrentes = EstoqueColheitaFrente, _
                                                       .oFazendasDetalhe = EstoqueColheitaFazendasDetalheBase}
        Return Ok(EstoqueColheita)
    End Function

    Private Function GetTotais() As List(Of S5TEstoqueColheitaTotal)
        Dim Totais As New List(Of S5TEstoqueColheitaTotal)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosGeral As New OracleCommand("SELECT AA.ID_NEGOCIOS, AA.SAFRA, NVL(SUM(AA.ESTOQUE_DISP),0) ESTOQUE_DISP, TRUNC(CASE WHEN ((NVL(SUM(AA.CARREGADORAS),0) > 0) AND (NVL(SUM(AA.RATEIO_COLHEITABILIDADE),0) > 0)) THEN (((NVL(SUM(AA.ESTOQUE_DISP),0) / NVL(SUM(AA.CARREGADORAS),0)) / (SUM(AA.RATEIO_COLHEITABILIDADE) / SUM(AA.PRODUCAO_PLAN))) / 24) ELSE 0 END) DIAS, F_NTOH_STRING(CASE WHEN ((NVL(SUM(AA.CARREGADORAS),0) > 0) AND (NVL(SUM(AA.RATEIO_COLHEITABILIDADE),0) > 0)) THEN (((((NVL(SUM(AA.ESTOQUE_DISP),0) / NVL(SUM(AA.CARREGADORAS),0)) / (SUM(AA.RATEIO_COLHEITABILIDADE) / SUM(AA.PRODUCAO_PLAN))) / 24) - TRUNC((((NVL(SUM(AA.ESTOQUE_DISP),0) / NVL(SUM(AA.CARREGADORAS),0)) / (SUM(AA.RATEIO_COLHEITABILIDADE) / SUM(AA.PRODUCAO_PLAN))) / 24))) * 24) ELSE 0 END) HORAS FROM (SELECT A1.ID_NEGOCIOS, A1.SAFRA, A1.FRENTE_LIB, NVL(A2.CARREGADORAS,0) CARREGADORAS, NVL(SUM(A1.RATEIO_COLHEITABILIDADE),0) RATEIO_COLHEITABILIDADE, NVL(SUM(A1.ESTOQUE_DISP),0) ESTOQUE_DISP, NVL(SUM(A1.PRODUCAO_PLAN),0) PRODUCAO_PLAN FROM BI4T.V_ESTOQUE_CANA_CAMPO A1, (SELECT TO_NUMBER(Z.REFERENCIA) FRENTE, Y.LOCAL FAZENDA, SUM(Y.CARREGADORAS) CARREGADORAS FROM IFROTA.CNF_TURNOS X, IFROTA.CNF_FRENTES Y, IFROTA.FRENTES Z WHERE X.BASE = Y.BASE AND X.FRENTE = Y.FRENTE AND X.BASE = Z.BASE AND X.FRENTE = Z.CODIGO AND X.TURNO = 1 AND X.FRENTE > 0 AND X.BASE = (SELECT B.CODIGO FROM IFROTA.BASES B WHERE B.ATIVA = 1 AND B.CHAVE_AGR = CAST(1 AS VARCHAR2(5))) GROUP BY TO_NUMBER(Z.REFERENCIA), Y.LOCAL HAVING SUM(Y.CARREGADORAS) <> 0) A2 WHERE A1.FRENTE_LIB = A2.FRENTE (+) AND A1.TALH_CODIGO_PROP = A2.FAZENDA(+) GROUP BY A1.ID_NEGOCIOS, A1.SAFRA, A1.FRENTE_LIB, NVL(A2.CARREGADORAS,0) ) AA GROUP BY AA.ID_NEGOCIOS, AA.SAFRA", conn) With {.CommandType = CommandType.Text}

            Dim drDadosGeral As OracleDataReader = Nothing
            Try
                drDadosGeral = cmdDadosGeral.ExecuteReader()
                If drDadosGeral.HasRows Then
                    Do While drDadosGeral.Read
                        Dim objDadosGeral = New S5TEstoqueColheitaTotal

                        objDadosGeral.ID_NEGOCIOS = AppUtils.Nvl(drDadosGeral.Item("ID_NEGOCIOS"), 0)
                        objDadosGeral.SAFRA = AppUtils.Nvl(drDadosGeral.Item("SAFRA"), 0)
                        objDadosGeral.DESCRICAO = "Total"
                        objDadosGeral.ESTOQUE_DISP = Math.Round(AppUtils.Nvl(drDadosGeral.Item("ESTOQUE_DISP"), 0), 0)
                        objDadosGeral.DIAS = AppUtils.Nvl(drDadosGeral.Item("DIAS"), 0)
                        objDadosGeral.HORAS = AppUtils.Nvl(drDadosGeral.Item("HORAS"), "")
                        objDadosGeral.TEMPO = GetTempo(objDadosGeral.DIAS, objDadosGeral.HORAS)

                        Totais.Add(objDadosGeral)
                    Loop

                    drDadosGeral.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosGeral) Is Nothing) Then
                    drDadosGeral.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED

        End If

        Return Totais
    End Function

    Private Function GetFrentes() As List(Of S5TEstoqueColheitaFrente)
        Dim Frentes As New List(Of S5TEstoqueColheitaFrente)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosFrente As New OracleCommand("SELECT AX.*, ROUND(DECODE(AX.QTD_VIAGENS, 0, 0, (AX.TON_COLHIDA / AX.QTD_VIAGENS)),2) MEDIA_VIAGENS, TRUNC(DECODE(AX.QTD_VIAGENS, 0, 0, (AX.ESTOQUE_DISP / (AX.TON_COLHIDA / AX.QTD_VIAGENS)))) NR_VIAGEM_REST FROM (SELECT AA.ID_NEGOCIOS, AA.SAFRA, AA.FRENTE_LIB, AA.CARREGADORAS, AA.ESTOQUE_DISP, AA.TON_COLHIDA, TRUNC(CASE WHEN ((AA.CARREGADORAS > 0) AND (AA.CAP_COLH_EFETIVA > 0)) THEN (((AA.ESTOQUE_DISP / AA.CARREGADORAS) / AA.CAP_COLH_EFETIVA) / 24) ELSE 0 END) DIAS, F_NTOH_STRING(CASE WHEN ((AA.CARREGADORAS > 0) AND (AA.CAP_COLH_EFETIVA > 0)) THEN (((((AA.ESTOQUE_DISP / AA.CARREGADORAS) / AA.CAP_COLH_EFETIVA) / 24) - TRUNC((((AA.ESTOQUE_DISP / AA.CARREGADORAS) / AA.CAP_COLH_EFETIVA) / 24))) * 24) ELSE 0 END) HORAS, NVL((SELECT COUNT(DISTINCT CERC_CERTIFICADO) FROM CERTIFICADO_CANA CC, TALHAO_LIBERACAO TL WHERE TL.LIBE_ID_TALH = CC.CERC_ID_TALH AND (TL.LIBE_TIPO_CORTE = CC.CERC_CODIGO_TIPT OR TL.LIBE_TIPO_CORTE IS NULL) AND TL.LIBE_INDICADOR = '0' AND CC.ID_NEGOCIOS = AA.ID_NEGOCIOS AND CC.SAFRA = AA.SAFRA AND TO_NUMBER(TRIM(TO_CHAR(F_BUSCA_FRENTE_SERVICO_LIB(TL.ID_NEGOCIOS, TL.LIBE_DATA, TL.LIBE_ID_TALH, TL.LIBE_TIPO_CORTE, CC.CERC_DATAENTRADAB)))) = AA.FRENTE_LIB),0) QTD_VIAGENS FROM (SELECT AB.ID_NEGOCIOS, AB.SAFRA, AB.FRENTE_LIB, SUM(AB.CARREGADORAS) CARREGADORAS, ROUND(DECODE(NVL(SUM(AB.PRODUCAO_PLAN),0),0,0, (NVL(SUM(AB.RATEIO_COLHEITABILIDADE),0) / SUM(AB.PRODUCAO_PLAN))),2) CAP_COLH_EFETIVA, SUM(AB.ESTOQUE_DISP) ESTOQUE_DISP, SUM(AB.TON_COLHIDA) TON_COLHIDA FROM (SELECT A1.ID_NEGOCIOS, A1.SAFRA, A1.FRENTE_LIB, NVL(A2.CARREGADORAS,0) CARREGADORAS, NVL(SUM(A1.RATEIO_COLHEITABILIDADE),0) RATEIO_COLHEITABILIDADE, NVL(SUM(A1.PRODUCAO_PLAN),0) PRODUCAO_PLAN, NVL(SUM(A1.PRODUCAO_REAL),0) TON_COLHIDA, NVL(SUM(A1.ESTOQUE_DISP),0) ESTOQUE_DISP FROM BI4T.V_ESTOQUE_CANA_CAMPO A1, (SELECT TO_NUMBER(Z.REFERENCIA) FRENTE, Y.LOCAL FAZENDA, SUM(Y.CARREGADORAS) CARREGADORAS FROM IFROTA.CNF_TURNOS X, IFROTA.CNF_FRENTES Y, IFROTA.FRENTES Z WHERE X.BASE = Y.BASE AND X.FRENTE = Y.FRENTE AND X.BASE = Z.BASE AND X.FRENTE = Z.CODIGO AND X.TURNO = 1 AND X.FRENTE > 0 AND X.BASE = (SELECT B.CODIGO FROM IFROTA.BASES B WHERE B.ATIVA = 1 AND B.CHAVE_AGR = CAST(1 AS VARCHAR2(5))) GROUP BY TO_NUMBER(Z.REFERENCIA), Y.LOCAL HAVING SUM(Y.CARREGADORAS) <> 0) A2 WHERE A1.FRENTE_LIB = A2.FRENTE (+) AND A1.TALH_CODIGO_PROP = A2.FAZENDA(+) GROUP BY A1.ID_NEGOCIOS, A1.SAFRA, A1.FRENTE_LIB, A2.CARREGADORAS ) AB GROUP BY AB.ID_NEGOCIOS, AB.SAFRA, AB.FRENTE_LIB ) AA ) AX ORDER BY AX.ID_NEGOCIOS, AX.SAFRA, AX.FRENTE_LIB", conn) With {.CommandType = CommandType.Text}

            Dim drDadosFrente As OracleDataReader = Nothing
            Try
                drDadosFrente = cmdDadosFrente.ExecuteReader()
                If drDadosFrente.HasRows Then
                    Do While drDadosFrente.Read
                        Dim objDadosFrente = New S5TEstoqueColheitaFrente

                        objDadosFrente.ID_NEGOCIOS = AppUtils.Nvl(drDadosFrente.Item("ID_NEGOCIOS"), 0)
                        objDadosFrente.SAFRA = AppUtils.Nvl(drDadosFrente.Item("SAFRA"), 0)
                        objDadosFrente.FRENTE_LIB = AppUtils.Nvl(drDadosFrente.Item("FRENTE_LIB"), 0)
                        objDadosFrente.FRENTE_LIB_STR = IIf(objDadosFrente.FRENTE_LIB <> 0, "FC " & objDadosFrente.FRENTE_LIB.ToString.PadLeft(2, "0"), "")
                        objDadosFrente.CARREGADORAS = AppUtils.Nvl(drDadosFrente.Item("CARREGADORAS"), "")
                        objDadosFrente.ESTOQUE_DISP = Math.Round(AppUtils.Nvl(drDadosFrente.Item("ESTOQUE_DISP"), 0), 0)
                        objDadosFrente.DIAS = AppUtils.Nvl(drDadosFrente.Item("DIAS"), 0)
                        objDadosFrente.HORAS = AppUtils.Nvl(drDadosFrente.Item("HORAS"), "")
                        objDadosFrente.TEMPO = GetTempo(objDadosFrente.DIAS, objDadosFrente.HORAS)
                        objDadosFrente.QTD_VIAGENS = AppUtils.Nvl(drDadosFrente.Item("QTD_VIAGENS"), 0)
                        objDadosFrente.MEDIA_VIAGENS = AppUtils.Nvl(drDadosFrente.Item("MEDIA_VIAGENS"), 0)
                        objDadosFrente.NR_VIAGEM_REST = AppUtils.Nvl(drDadosFrente.Item("NR_VIAGEM_REST"), 0)


                        Frentes.Add(objDadosFrente)
                    Loop

                    drDadosFrente.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosFrente) Is Nothing) Then
                    drDadosFrente.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED

        End If

        Return Frentes
    End Function

    Private Function GetFazendas() As List(Of S5TEstoqueColheitaFrenteFazenda)
        Dim Fazendas As New List(Of S5TEstoqueColheitaFrenteFazenda)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosFazenda As New OracleCommand("SELECT AX.*, ROUND(DECODE(AX.QTD_VIAGENS, 0, 0, (AX.TON_COLHIDA / AX.QTD_VIAGENS)), 2) MEDIA_VIAGENS, TRUNC(DECODE(DECODE(AX.QTD_VIAGENS, 0, 0, (AX.TON_COLHIDA / AX.QTD_VIAGENS)), 0, 0, (AX.ESTOQUE_DISP / (AX.TON_COLHIDA / AX.QTD_VIAGENS)))) NR_VIAGEM_REST FROM (SELECT AA.ID_NEGOCIOS, AA.SAFRA, AA.FRENTE_LIB, AA.COD_PROP, AA.DSC_PROP, AA.CARREGADORAS, AA.CAP_COLH_EFETIVA, AA.ESTOQUE_DISP, AA.TON_COLHIDA, AA.DIAS, AA.HORAS, CASE WHEN (NVL(AA.PRODUCAO_REAL, 0) <= 0) THEN 1 WHEN (NVL(AA.PRODUCAO_REAL, 0) > 0) AND (NVL(AA.ESTOQUE_DISP, 0) <> 0) AND ((NVL(AA.DIAS, 0) > 0) OR (NVL(AA.HORAS_DECIMAIS, 0) > TO_NUMBER(F_VALOR_PARAMETRO('P_BI_MAPA_COLHEITA_LIMITE_MAIOR', AA.ID_NEGOCIOS)))) THEN 2 WHEN (NVL(AA.PRODUCAO_REAL, 0) > 0) AND (NVL(AA.ESTOQUE_DISP, 0) <> 0) AND (NVL(AA.DIAS, 0) = 0) AND (NVL(AA.HORAS_DECIMAIS, 0) BETWEEN TO_NUMBER(F_VALOR_PARAMETRO('P_BI_MAPA_COLHEITA_LIMITE_MENOR', AA.ID_NEGOCIOS)) AND TO_NUMBER(F_VALOR_PARAMETRO('P_BI_MAPA_COLHEITA_LIMITE_MAIOR', AA.ID_NEGOCIOS))) THEN 3 WHEN (NVL(AA.PRODUCAO_REAL, 0) > 0) AND (NVL(AA.ESTOQUE_DISP, 0) <> 0) AND (NVL(AA.DIAS, 0) = 0) AND (NVL(AA.HORAS_DECIMAIS, 0) < TO_NUMBER(F_VALOR_PARAMETRO('P_BI_MAPA_COLHEITA_LIMITE_MENOR', AA.ID_NEGOCIOS))) THEN 4 ELSE 0 END AS COR_PREENCHIMENTO, NVL((SELECT COUNT(DISTINCT CERC_CERTIFICADO) FROM CERTIFICADO_CANA CC, TALHAO_LIBERACAO TL WHERE TL.LIBE_ID_TALH = CC.CERC_ID_TALH AND (TL.LIBE_TIPO_CORTE = CC.CERC_CODIGO_TIPT OR TL.LIBE_TIPO_CORTE IS NULL) AND TL.LIBE_INDICADOR = '0' AND CC.ID_NEGOCIOS = AA.ID_NEGOCIOS AND CC.SAFRA = AA.SAFRA AND CC.CERC_CODIGO_PROP = AA.COD_PROP), 0) QTD_VIAGENS FROM (SELECT AB.*, TRUNC(CASE WHEN ((AB.CARREGADORAS > 0) AND (AB.CAP_COLH_EFETIVA > 0)) THEN (((AB.ESTOQUE_DISP / AB.CARREGADORAS) / AB.CAP_COLH_EFETIVA) / 24) ELSE 0 END) DIAS, F_NTOH_STRING(CASE WHEN ((AB.CARREGADORAS > 0) AND (AB.CAP_COLH_EFETIVA > 0)) THEN (((((AB.ESTOQUE_DISP / AB.CARREGADORAS) / AB.CAP_COLH_EFETIVA) / 24) - TRUNC((((AB.ESTOQUE_DISP / AB.CARREGADORAS) / AB.CAP_COLH_EFETIVA) / 24))) * 24) ELSE 0 END) HORAS, CASE WHEN ((AB.CARREGADORAS > 0) AND (AB.CAP_COLH_EFETIVA > 0)) THEN (((((AB.ESTOQUE_DISP / AB.CARREGADORAS) / AB.CAP_COLH_EFETIVA) / 24) - TRUNC((((AB.ESTOQUE_DISP / AB.CARREGADORAS) / AB.CAP_COLH_EFETIVA) / 24))) * 24) ELSE 0 END HORAS_DECIMAIS FROM (SELECT A1.ID_NEGOCIOS, A1.SAFRA, A1.FRENTE_LIB, A1.TALH_CODIGO_PROP COD_PROP, A1.PROP_DESCRICAO DSC_PROP, NVL(A2.CARREGADORAS, 0) CARREGADORAS, NVL(ROUND(SUM(A1.RATEIO_COLHEITABILIDADE) / SUM(A1.PRODUCAO_PLAN), 2), 0) CAP_COLH_EFETIVA, NVL(SUM(A1.PRODUCAO_PLAN), 0) PRODUCAO_PLAN, NVL(SUM(A1.PRODUCAO_REAL), 0) PRODUCAO_REAL, NVL(SUM(A1.ESTOQUE_DISP), 0) ESTOQUE_DISP, NVL(SUM(A1.PRODUCAO_REAL), 0) TON_COLHIDA FROM BI4T.V_ESTOQUE_CANA_CAMPO A1, (SELECT TO_NUMBER(Z.REFERENCIA) FRENTE, Y.LOCAL FAZENDA, SUM(Y.CARREGADORAS) CARREGADORAS FROM IFROTA.CNF_TURNOS X, IFROTA.CNF_FRENTES Y, IFROTA.FRENTES Z WHERE X.BASE = Y.BASE AND X.FRENTE = Y.FRENTE AND X.BASE = Z.BASE AND X.FRENTE = Z.CODIGO AND X.TURNO = 1 AND X.FRENTE > 0 AND X.BASE = (SELECT B.CODIGO FROM IFROTA.BASES B WHERE B.ATIVA = 1 AND B.CHAVE_AGR = CAST(1 AS VARCHAR2(5))) GROUP BY TO_NUMBER(Z.REFERENCIA), Y.LOCAL HAVING SUM(Y.CARREGADORAS) <> 0) A2 WHERE A1.FRENTE_LIB = A2.FRENTE(+) AND A1.TALH_CODIGO_PROP = A2.FAZENDA(+) GROUP BY A1.ID_NEGOCIOS, A1.SAFRA, A1.FRENTE_LIB, A1.TALH_CODIGO_PROP, A1.PROP_DESCRICAO, A2.CARREGADORAS) AB) AA) AX ORDER BY AX.ID_NEGOCIOS, AX.SAFRA, AX.FRENTE_LIB, AX.COD_PROP", conn) With {.CommandType = CommandType.Text}

            Dim drDadosFazenda As OracleDataReader = Nothing
            Try
                drDadosFazenda = cmdDadosFazenda.ExecuteReader()
                If drDadosFazenda.HasRows Then
                    Do While drDadosFazenda.Read
                        Dim objDadosFazenda = New S5TEstoqueColheitaFrenteFazenda

                        objDadosFazenda.ID_NEGOCIOS = AppUtils.Nvl(drDadosFazenda.Item("ID_NEGOCIOS"), 0)
                        objDadosFazenda.SAFRA = AppUtils.Nvl(drDadosFazenda.Item("SAFRA"), 0)
                        objDadosFazenda.FRENTE_LIB = AppUtils.Nvl(drDadosFazenda.Item("FRENTE_LIB"), 0)
                        objDadosFazenda.COD_PROP = AppUtils.Nvl(drDadosFazenda.Item("COD_PROP"), 0)
                        objDadosFazenda.DSC_PROP = AppUtils.Nvl(drDadosFazenda.Item("DSC_PROP"), "")
                        objDadosFazenda.CARREGADORAS = AppUtils.Nvl(drDadosFazenda.Item("CARREGADORAS"), "")
                        objDadosFazenda.CAP_COLH_EFETIVA = Math.Round(AppUtils.Nvl(drDadosFazenda.Item("CAP_COLH_EFETIVA"), 0), 0)
                        objDadosFazenda.ESTOQUE_DISP = Math.Round(AppUtils.Nvl(drDadosFazenda.Item("ESTOQUE_DISP"), 0), 0)
                        objDadosFazenda.TON_COLHIDA = Math.Round(AppUtils.Nvl(drDadosFazenda.Item("TON_COLHIDA"), 0), 0)
                        objDadosFazenda.DIAS = AppUtils.Nvl(drDadosFazenda.Item("DIAS"), 0)
                        objDadosFazenda.HORAS = AppUtils.Nvl(drDadosFazenda.Item("HORAS"), "")
                        objDadosFazenda.TEMPO = GetTempo(objDadosFazenda.DIAS, objDadosFazenda.HORAS)
                        objDadosFazenda.QTD_VIAGENS = AppUtils.Nvl(drDadosFazenda.Item("QTD_VIAGENS"), 0)
                        objDadosFazenda.MEDIA_VIAGENS = AppUtils.Nvl(drDadosFazenda.Item("MEDIA_VIAGENS"), 0)
                        objDadosFazenda.NR_VIAGEM_REST = AppUtils.Nvl(drDadosFazenda.Item("NR_VIAGEM_REST"), 0)
                        objDadosFazenda.COR_PREENCHIMENTO = AppUtils.Nvl(drDadosFazenda.Item("COR_PREENCHIMENTO"), 0)

                        Fazendas.Add(objDadosFazenda)
                    Loop

                    drDadosFazenda.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosFazenda) Is Nothing) Then
                    drDadosFazenda.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED

        End If

        Return Fazendas
    End Function

    Private Function GetFazendas(ByVal parFrente As Integer, ByRef parFazendas As List(Of S5TEstoqueColheitaFrenteFazenda)) As List(Of S5TEstoqueColheitaFrenteFazenda)
        'OVERLOAD
        Return parFazendas.FindAll(Function(x) x.FRENTE_LIB = parFrente)
    End Function

    Private Function GetTalhoes() As List(Of S5TEstoqueColheitaFrenteFazendaTalhao)
        Dim Talhoes As New List(Of S5TEstoqueColheitaFrenteFazendaTalhao)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosTalhao As New OracleCommand("SELECT A3.*, DECODE(A3.CARREGADORA_TALHAO, 0, NULL, TRUNC(((A3.ESTOQUE_DISP / A3.CARREGADORA_TALHAO) / A3.CAP_COLH_EFETIVA) / 24)) DIAS, DECODE(A3.CARREGADORA_TALHAO, 0, NULL, (F_NTOH_STRING((((A3.ESTOQUE_DISP / A3.CARREGADORA_TALHAO) / A3.CAP_COLH_EFETIVA) / 24) - TRUNC(((A3.ESTOQUE_DISP / A3.CARREGADORA_TALHAO) / A3.CAP_COLH_EFETIVA) / 24)))) HORAS FROM (SELECT A1.*, (SELECT COUNT(DISTINCT CERC.CERC_NCARRCOLH) FROM TALHAO TALH, TALHAO_LIBERACAO LIBE, CERTIFICADO_CANA CERC WHERE TALH.TALH_ID = CERC.CERC_ID_TALH AND TALH.TALH_ID = LIBE.LIBE_ID_TALH AND (LIBE.LIBE_TIPO_CORTE = CERC.CERC_CODIGO_TIPT OR LIBE.LIBE_TIPO_CORTE IS NULL) AND CERC.CERC_FLAG_ENTRADA IS NULL AND CERC.ID_NEGOCIOS = A1.ID_NEGOCIOS AND CERC.SAFRA = A1.SAFRA AND CERC.CERC_ID_TALH = A1.LIBE_ID_TALH AND TRIM(TO_CHAR(F_BUSCA_FRENTE_SERVICO_LIB(LIBE.ID_NEGOCIOS,LIBE.LIBE_DATA,LIBE.LIBE_ID_TALH,LIBE.LIBE_TIPO_CORTE,CERC.CERC_DATAENTRADAB))) = 1 AND CERC.CERC_CERTIFICADO = (SELECT MAX(CC.CERC_CERTIFICADO) FROM CERTIFICADO_CANA CC WHERE CC.ID_NEGOCIOS = CERC.ID_NEGOCIOS AND CC.SAFRA = CERC.SAFRA AND CC.CERC_ID_TALH = CERC.CERC_ID_TALH)) CARREGADORA_TALHAO FROM BI4T.V_ESTOQUE_CANA_CAMPO A1, (SELECT TO_NUMBER(Z.REFERENCIA) FRENTE, Y.LOCAL FAZENDA, SUM(Y.CARREGADORAS) CARREGADORAS FROM IFROTA.CNF_TURNOS X, IFROTA.CNF_FRENTES Y, IFROTA.FRENTES Z WHERE X.BASE = Y.BASE AND X.FRENTE = Y.FRENTE AND X.BASE = Z.BASE AND X.FRENTE = Z.CODIGO AND X.TURNO = 1 AND X.FRENTE > 0 AND X.BASE = (SELECT B.CODIGO FROM IFROTA.BASES B WHERE B.ATIVA = 1 AND B.CHAVE_AGR = CAST(1 AS VARCHAR2(5))) GROUP BY TO_NUMBER(Z.REFERENCIA), Y.LOCAL HAVING SUM(Y.CARREGADORAS) <> 0) A2 WHERE A1.FRENTE_LIB = A2.FRENTE (+) AND A1.TALH_CODIGO_PROP = A2.FAZENDA(+)) A3", conn) With {.CommandType = CommandType.Text}

            Dim drDadosTalhao As OracleDataReader = Nothing
            Try
                drDadosTalhao = cmdDadosTalhao.ExecuteReader()
                If drDadosTalhao.HasRows Then
                    Do While drDadosTalhao.Read
                        Dim objDadosTalhao = New S5TEstoqueColheitaFrenteFazendaTalhao

                        objDadosTalhao.ID_NEGOCIOS = AppUtils.Nvl(drDadosTalhao.Item("ID_NEGOCIOS"), 0)
                        objDadosTalhao.DATA_LIB = AppUtils.Nvl(drDadosTalhao.Item("DATA_LIB"), DateTime.MinValue).ToUniversalTime
                        objDadosTalhao.LIBE_TIPO_CORTE = AppUtils.Nvl(drDadosTalhao.Item("LIBE_TIPO_CORTE"), 0)
                        objDadosTalhao.LIBE_ID_TALH = AppUtils.Nvl(drDadosTalhao.Item("LIBE_ID_TALH"), 0)
                        objDadosTalhao.SAFRA = AppUtils.Nvl(drDadosTalhao.Item("SAFRA"), 0)
                        objDadosTalhao.FRENTE_LIB = AppUtils.Nvl(drDadosTalhao.Item("FRENTE_LIB"), 0)
                        objDadosTalhao.TALH_CODIGO_PROP = AppUtils.Nvl(drDadosTalhao.Item("TALH_CODIGO_PROP"), 0)
                        objDadosTalhao.PROP_DESCRICAO = AppUtils.Nvl(drDadosTalhao.Item("PROP_DESCRICAO"), "")
                        objDadosTalhao.TALH_CODIGO = AppUtils.Nvl(drDadosTalhao.Item("TALH_CODIGO"), 0)
                        objDadosTalhao.TIPO_CORTE = AppUtils.Nvl(drDadosTalhao.Item("TIPO_CORTE"), "")
                        objDadosTalhao.DIAS_LIB = AppUtils.Nvl(drDadosTalhao.Item("DIAS_LIB"), 0)
                        objDadosTalhao.CAP_COLH_EFETIVA = Math.Round(AppUtils.Nvl(drDadosTalhao.Item("CAP_COLH_EFETIVA"), 0), 0)
                        objDadosTalhao.PRODUCAO_PLAN = Math.Round(AppUtils.Nvl(drDadosTalhao.Item("PRODUCAO_PLAN"), 0), 0)
                        objDadosTalhao.PRODUCAO_REAL = Math.Round(AppUtils.Nvl(drDadosTalhao.Item("PRODUCAO_REAL"), 0), 0)
                        objDadosTalhao.ESTOQUE_DISP = Math.Round(AppUtils.Nvl(drDadosTalhao.Item("ESTOQUE_DISP"), 0), 0)
                        objDadosTalhao.RATEIO_COLHEITABILIDADE = AppUtils.Nvl(drDadosTalhao.Item("RATEIO_COLHEITABILIDADE"), 0)
                        objDadosTalhao.CARREGADORA_TALHAO = AppUtils.Nvl(drDadosTalhao.Item("CARREGADORA_TALHAO"), 0)
                        objDadosTalhao.DIAS = AppUtils.Nvl(drDadosTalhao.Item("DIAS"), 0)
                        objDadosTalhao.HORAS = AppUtils.Nvl(drDadosTalhao.Item("HORAS"), "")
                        objDadosTalhao.TEMPO = GetTempo(objDadosTalhao.DIAS, objDadosTalhao.HORAS)

                        Talhoes.Add(objDadosTalhao)
                    Loop

                    drDadosTalhao.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosTalhao) Is Nothing) Then
                    drDadosTalhao.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED

        End If

        Return Talhoes
    End Function

    Private Function GetTalhoes(ByVal parFrente As Integer, ByVal parFazenda As Integer, ByRef parTalhoes As List(Of S5TEstoqueColheitaFrenteFazendaTalhao)) As List(Of S5TEstoqueColheitaFrenteFazendaTalhao)
        'OVERLOAD
        Return parTalhoes.FindAll(Function(x) x.FRENTE_LIB = parFrente And x.TALH_CODIGO_PROP = parFazenda).OrderBy(Function(x) x.TALH_CODIGO).ToList
    End Function

    Private Function GetFazendasDetalhe(ByRef parEstoqueColheitaFrente As List(Of S5TEstoqueColheitaFrente)) As List(Of S5TEstoqueColheitaFazendaDetalhe)
        Dim FazendasDetalhe As New List(Of S5TEstoqueColheitaFazendaDetalhe)

        For Each objEstoqueColheitaFrente In parEstoqueColheitaFrente
            For Each objEstoqueColheitaFrenteFazenda In objEstoqueColheitaFrente.oFazendas
                Dim objDadosFazendaDetalhe = New S5TEstoqueColheitaFazendaDetalhe

                objDadosFazendaDetalhe.COD_PROP = objEstoqueColheitaFrenteFazenda.COD_PROP
                objDadosFazendaDetalhe.DSC_PROP = objEstoqueColheitaFrenteFazenda.DSC_PROP
                objDadosFazendaDetalhe.CARREGADORAS = objEstoqueColheitaFrenteFazenda.CARREGADORAS
                objDadosFazendaDetalhe.FRENTE_LIB = objEstoqueColheitaFrente.FRENTE_LIB
                objDadosFazendaDetalhe.FRENTE_LIB_STR = objEstoqueColheitaFrente.FRENTE_LIB_STR
                objDadosFazendaDetalhe.ESTOQUE_DISP = objEstoqueColheitaFrenteFazenda.ESTOQUE_DISP
                objDadosFazendaDetalhe.TON_COLHIDA = objEstoqueColheitaFrenteFazenda.TON_COLHIDA
                objDadosFazendaDetalhe.DIAS = objEstoqueColheitaFrenteFazenda.DIAS
                objDadosFazendaDetalhe.HORAS = objEstoqueColheitaFrenteFazenda.HORAS
                objDadosFazendaDetalhe.TEMPO = GetTempo(objDadosFazendaDetalhe.DIAS, objDadosFazendaDetalhe.HORAS)
                objDadosFazendaDetalhe.MEDIA_VIAGENS = objEstoqueColheitaFrenteFazenda.MEDIA_VIAGENS
                objDadosFazendaDetalhe.COR_PREENCHIMENTO = objEstoqueColheitaFrenteFazenda.COR_PREENCHIMENTO

                FazendasDetalhe.Add(objDadosFazendaDetalhe)
            Next
        Next

        Return FazendasDetalhe
    End Function

    Private Function GetFazendasCoordenadas() As List(Of S5TEstoqueColheitaFazendaCoordenadas)
        Dim FazendaCoordenadas As New List(Of S5TEstoqueColheitaFazendaCoordenadas)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosFazenda As New OracleCommand("SELECT ID_NEGOCIOS, PROP_CODIGO, COORD_LONG, COORD_LAT FROM BI4T.PROPRIEDADES_COORDENADAS", conn) With {.CommandType = CommandType.Text}

            Dim drDadosFazenda As OracleDataReader = Nothing
            Try
                drDadosFazenda = cmdDadosFazenda.ExecuteReader()
                If drDadosFazenda.HasRows Then
                    Do While drDadosFazenda.Read
                        Dim objDadosFazenda = New S5TEstoqueColheitaFazendaCoordenadas

                        objDadosFazenda.ID_NEGOCIOS = AppUtils.Nvl(drDadosFazenda.Item("ID_NEGOCIOS"), 0)
                        objDadosFazenda.PROP_CODIGO = AppUtils.Nvl(drDadosFazenda.Item("PROP_CODIGO"), 0)
                        objDadosFazenda.COORD_LONG = AppUtils.Nvl(drDadosFazenda.Item("COORD_LONG"), 0)
                        objDadosFazenda.COORD_LAT = AppUtils.Nvl(drDadosFazenda.Item("COORD_LAT"), 0)

                        'objDadosFazenda.DT_Fazenda = AppUtils.Nvl(drDadosFazenda.Item("DT_Fazenda"), DateTime.MinValue).ToUniversalTime()

                        FazendaCoordenadas.Add(objDadosFazenda)
                    Loop

                    drDadosFazenda.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosFazenda) Is Nothing) Then
                    drDadosFazenda.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED

        End If

        Return FazendaCoordenadas
    End Function

    Private Function GetFazendaCoordenada(ByVal parFazenda As Integer, ByRef parFazendaCoordenadas As List(Of S5TEstoqueColheitaFazendaCoordenadas)) As S5TEstoqueColheitaFazendaCoordenadas
        'OVERLOAD
        Return parFazendaCoordenadas.FindAll(Function(x) x.PROP_CODIGO = parFazenda).FirstOrDefault
    End Function

    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function


    Public Class S5TEstoqueColheitaTalhoes
        Public Property ID_NEGOCIOS As Integer
        Public Property DATA_LIB As Date
        Public Property LIBE_ID_TALH As Integer
        Public Property LIBE_TIPO_CORTE As Integer
    End Class


    ' POST api/EstoqueColheitaFrente
    <HttpPost>
    <Route("")>
    Public Sub PostValue(<FromBody()> ByVal oTalhoes As List(Of S5TEstoqueColheitaTalhoes))
        'timezone.CurrentTimeZone.ToLocalTime(oTalhoes(0).DATA_LIB)
        For Each objTalhao In oTalhoes
            'UPDATE HERE

            If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                Dim conn As OracleConnection = Nothing
                Dim oradbConn As String = String.Empty

                Dim oradb As String = AppUtils.dbConnectionString

                conn = New OracleConnection(oradb)
                conn.Open()

                Dim cmdUpdateTalhoes As New OracleCommand(String.Format("UPDATE SISAGRI.TALHAO_LIBERACAO TL SET TL.LIBE_INDICADOR = '2' WHERE TL.ID_NEGOCIOS = {0} AND TRUNC(TL.LIBE_DATA) = TO_DATE('{1}','DD/MM/YYYY') AND TL.LIBE_ID_TALH = {2} AND TL.LIBE_TIPO_CORTE = {3} AND TL.LIBE_INDICADOR = '0'", 1, TimeZone.CurrentTimeZone.ToLocalTime(objTalhao.DATA_LIB).ToShortDateString, objTalhao.LIBE_ID_TALH, objTalhao.LIBE_TIPO_CORTE), conn) With {.CommandType = CommandType.Text}

                Try
                    cmdUpdateTalhoes.ExecuteNonQuery()
                Catch ex As Exception
                    'Return InternalServerError(ex)
                Finally
                    conn.Close()
                End Try
            ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                'NOT IMPLEMENTED

            End If


            Console.WriteLine("teste")
        Next
    End Sub


    ' GET api/EstoqueColheitaFrente/TempoTimer
    <HttpGet>
    <Route("TempoTimer")>
    Public Function GetValue() As IHttpActionResult
        Dim varResultado As String = String.Empty

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosResultado As New OracleCommand("SELECT TO_NUMBER(F_VALOR_PARAMETRO('P_BI_MAPA_COLHEITA_TIMER',1)) TEMPO_TIMER FROM DUAL", conn) With {.CommandType = CommandType.Text}

            Dim drDadosResultado As OracleDataReader = Nothing
            Try
                drDadosResultado = cmdDadosResultado.ExecuteReader()
                If drDadosResultado.HasRows Then
                    Do While drDadosResultado.Read
                        varResultado = AppUtils.Nvl(drDadosResultado.Item("TEMPO_TIMER"), 0)
                    Loop

                    drDadosResultado.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosResultado) Is Nothing) Then
                    drDadosResultado.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED

        End If

        Return Ok(varResultado)
    End Function


    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
