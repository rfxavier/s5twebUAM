Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Web.Http
Imports Oracle.DataAccess.Client

<RoutePrefix("api/AgricolaColheita")>
    Public Class AgricolaColheitaController
        Inherits ApiController

    Private Property QueryAgricolaColheita As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, HORA, FRENTE, DESC_FRENTE, ID_CA_INDICADOR, DS_CA_INDICADOR, PLANEJADO, REALIZADO, CN_ENT_INDICADOR, TIPO_PLANEJAMENTO FROM BI4T.INDICADORES_COLHEITA WHERE 0=0" ' AND DIA <= TO_DATE('07/05/2018','DD/MM/YYYY') AND HORA <= '00'"
    Private Property QueryAgricolaColheitaEquipamento As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, FRENTE, DESC_FRENTE, CLASSE_EQUIP, NRO_EQUIPAMENTO, ID_INDICADOR, DSC_INDICADOR, META, REALIZADO, TIPO_PLANEJAMENTO FROM BI4T.INDICADORES_COLHEITA_EQUIP WHERE TIPO_INDICADOR = 'O'"

    <DataContract>
    Public Class S5TAgricolaColheitaSemanaDiaInicioFim
        <DataMember>
        Public Property diaInicio As Date
        <DataMember>
        Public Property diaFim As Date
    End Class

    Public Class S5TAgricolaColheitaGraficoDensidadeCargaEscalaEixoY
        Public Property Min as Integer
        Public Property Max as Integer
        Public Property Inc as Integer
    End Class

    <DataContract>
    Public Class S5TAgricolaColheita
        Public Property ID_NEGOCIOS as Integer
        Public Property SAFRA As Integer
        <DataMember>
        Public Property MES As Integer
        <DataMember>
        Public Property SEMANA As Integer
        <DataMember>
        Public Property semanaPeriodo As S5TAgricolaColheitaSemanaDiaInicioFim
        <DataMember>
        Public Property DIA As DateTime
        <DataMember>
        Public Property HORA As String
        Public Property FRENTE As Integer
        Public Property DESC_FRENTE As String
        Public Property ID_CA_INDICADOR As Integer
        Public Property DS_CA_INDICADOR As String
        <DataMember>
        Public Property PLANEJADO As Double
        <DataMember>
        Public Property REALIZADO As Double
        Public Property CN_ENT_INDICADOR As Double
        Public Property TIPO_PLANEJAMENTO As String

    End Class

    <DataContract>
    Public Class S5TAgricolaColheitaFrentes
        <DataMember>
        Public Property frenteCodigo As Integer
        <DataMember>
        Public Property frenteDescricao As String
        <DataMember>
        Public Property indicadorMeta As Integer
    End Class

    <DataContract>
    Public Class S5TAgricolaColheitaAgrupadoPorDia
        <DataMember>
        Public Property oGraficoEntregaCanaAcumulado As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoDensidadeCarga As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property graficoDensidadeCargaYMin As Integer
        <DataMember>
        Public Property graficoDensidadeCargaYMax As Integer
        <DataMember>
        Public Property graficoDensidadeCargaYInc As Integer
        <DataMember>
        Public Property oGraficoImpurezaVegetal As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoImpurezaMineral As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoVelocidadeMedia As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property horaAtual As String
        <DataMember>
        Public Property entregaAcumulada As Double
        <DataMember>
        Public Property entregaPlanejadaAcumulada As Double
        <DataMember>
        Public Property entregaPlanejadaTotal As Double
        <DataMember>
        Public Property media As Double
        <DataMember>
        Public Property estoquePatio As Double
        <DataMember>
        Public Property desvio As Double
        <DataMember>
        Public Property densidadeAtual As Double
        <DataMember>
        Public Property oFrentesEntregaCana As List(Of S5TAgricolaColheitaFrentes)
        <DataMember>
        Public Property oFrentesDensidadeCarga As List(Of S5TAgricolaColheitaFrentes)
    End Class

    <DataContract>
    Public Class S5TAgricolaColheitaAgrupadoPorSemana
        <DataMember>
        Public Property oGraficoEntregaCanaAcumulado As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoDensidadeCarga As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property graficoDensidadeCargaYMin As Integer
        <DataMember>
        Public Property graficoDensidadeCargaYMax As Integer
        <DataMember>
        Public Property graficoDensidadeCargaYInc As Integer
        <DataMember>
        Public Property oGraficoImpurezaVegetal As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoImpurezaMineral As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoVelocidadeMedia As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property diaAtual As Date
        <DataMember>
        Public Property entregaAcumulada As Double
        <DataMember>
        Public Property entregaPlanejadaAcumulada As Double
        <DataMember>
        Public Property entregaPlanejadaTotal As Double
        <DataMember>
        Public Property media As Double
        <DataMember>
        Public Property desvio As Double
        <DataMember>
        Public Property densidadeAtual As Double
        <DataMember>
        Public Property oFrentesEntregaCana As List(Of S5TAgricolaColheitaFrentes)
        <DataMember>
        Public Property oFrentesDensidadeCarga As List(Of S5TAgricolaColheitaFrentes)
    End Class

    <DataContract>
    Public Class S5TAgricolaColheitaAgrupadoPorMes
        <DataMember>
        Public Property oGraficoEntregaCanaAcumulado As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoDensidadeCarga As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property graficoDensidadeCargaYMin As Integer
        <DataMember>
        Public Property graficoDensidadeCargaYMax As Integer
        <DataMember>
        Public Property graficoDensidadeCargaYInc As Integer
        <DataMember>
        Public Property oGraficoImpurezaVegetal As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoImpurezaMineral As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoVelocidadeMedia As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property semanaAtual As Integer
        <DataMember>
        Public Property entregaAcumulada As Double
        <DataMember>
        Public Property entregaPlanejadaAcumulada As Double
        <DataMember>
        Public Property entregaPlanejadaTotal As Double
        <DataMember>
        Public Property media As Double
        <DataMember>
        Public Property desvio As Double
        <DataMember>
        Public Property densidadeAtual As Double
        <DataMember>
        Public Property oFrentesEntregaCana As List(Of S5TAgricolaColheitaFrentes)
        <DataMember>
        Public Property oFrentesDensidadeCarga As List(Of S5TAgricolaColheitaFrentes)
    End Class

    <DataContract>
    Public Class S5TAgricolaColheitaAgrupadoPorSafra
        <DataMember>
        Public Property oGraficoEntregaCanaAcumulado As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoDensidadeCarga As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property graficoDensidadeCargaYMin As Integer
        <DataMember>
        Public Property graficoDensidadeCargaYMax As Integer
        <DataMember>
        Public Property graficoDensidadeCargaYInc As Integer
        <DataMember>
        Public Property oGraficoImpurezaVegetal As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoImpurezaMineral As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property oGraficoVelocidadeMedia As List(Of S5TAgricolaColheita)
        <DataMember>
        Public Property mesAtual As Integer
        <DataMember>
        Public Property entregaAcumulada As Double
        <DataMember>
        Public Property entregaPlanejadaAcumulada As Double
        <DataMember>
        Public Property entregaPlanejadaTotal As Double
        <DataMember>
        Public Property media As Double
        <DataMember>
        Public Property desvio As Double
        <DataMember>
        Public Property densidadeAtual As Double
        <DataMember>
        Public Property oFrentesEntregaCana As List(Of S5TAgricolaColheitaFrentes)
        <DataMember>
        Public Property oFrentesDensidadeCarga As List(Of S5TAgricolaColheitaFrentes)
    End Class
    
    <DataContract>
    Public Class S5TAgricolaColheitaEquipamento
        Public Property ID_NEGOCIOS As Integer
        Public Property SAFRA As Integer
        Public Property MES As Integer
        Public Property SEMANA As Integer
        Public Property DIA As DateTime
        Public Property FRENTE As Integer
        Public Property DESC_FRENTE As String
        Public Property CLASSE_EQUIP As String
        <DataMember>
        Public Property NRO_EQUIPAMENTO As Integer
        Public Property ID_INDICADOR As Integer
        Public Property DSC_INDICADOR As String
        <DataMember>
        Public Property META As Double
        <DataMember>
        Public Property REALIZADO As Double
        Public Property TIPO_PLANEJAMENTO As String

    End Class

    <DataContract>
    Public Class S5TAgricolaColheitaEquipamentoAgrupado
        <DataMember>
        Public Property oGraficoColhedoraI29 As List(Of S5TAgricolaColheitaEquipamento) 'VELOCIDADE DE COLHEITA
        <DataMember>
        Public Property graficoColhedoraI29Media As Double
        <DataMember>
        Public Property graficoColhedoraI29Meta As Double


        <DataMember>
        Public Property oGraficoColhedoraI30 As List(Of S5TAgricolaColheitaEquipamento) 'EQUIP.PRODUTIVO
        <DataMember>
        Public Property graficoColhedoraI30Media As Double
        <DataMember>
        Public Property graficoColhedoraI30Meta As Double


        <DataMember>
        Public Property oGraficoColhedoraI31 As List(Of S5TAgricolaColheitaEquipamento) 'FALTA TRATOR
        <DataMember>
        Public Property graficoColhedoraI31Media As Double
        <DataMember>
        Public Property graficoColhedoraI31Meta As Double


        <DataMember>
        Public Property oGraficoColhedoraI32 As List(Of S5TAgricolaColheitaEquipamento) 'TEMPO APROVEITÁVEL
        <DataMember>
        Public Property graficoColhedoraI32Media As Double
        <DataMember>
        Public Property graficoColhedoraI32Meta As Double


        <DataMember>
        Public Property oGraficoColhedoraI33 As List(Of S5TAgricolaColheitaEquipamento) 'APROVEIT.DISTÂNCIA
        <DataMember>
        Public Property graficoColhedoraI33Media As Double
        <DataMember>
        Public Property graficoColhedoraI33Meta As Double


        <DataMember>
        Public Property oGraficoColhedoraI49 As List(Of S5TAgricolaColheitaEquipamento) 'PRODUTIVIDADE EQUIP/TON/DIA
        <DataMember>
        Public Property graficoColhedoraI49Media As Double
        <DataMember>
        Public Property graficoColhedoraI49Meta As Double


        <DataMember>
        Public Property oGraficoTratorI30 As List(Of S5TAgricolaColheitaEquipamento) 'EQUIP.PRODUTIVO
        <DataMember>
        Public Property graficoTratorI30Media As Double
        <DataMember>
        Public Property graficoTratorI30Meta As Double

        <DataMember>
        Public Property oGraficoTratorI34 As List(Of S5TAgricolaColheitaEquipamento) 'FILA CARREGAMENTO
        <DataMember>
        Public Property graficoTratorI34Media As Double
        <DataMember>
        Public Property graficoTratorI34Meta As Double

        <DataMember>
        Public Property oGraficoTratorI35 As List(Of S5TAgricolaColheitaEquipamento) 'FALTA CAMINHÃO
        <DataMember>
        Public Property graficoTratorI35Media As Double
        <DataMember>
        Public Property graficoTratorI35Meta As Double
    End Class


    ' GET api/AgricolaColheita/VisaoGeralMinMaxDia/1
    <HttpGet>
    <Route("VisaoGeralMinMaxDia/{parIdNegocios}")>
    Public Function GetValuesMaxDia(parIdNegocios As Integer) As IHttpActionResult
        Return Ok(GetAgricolaColheitaPorSafraMinMaxDia(parIdNegocios))
    End Function

    Public Function GetAgricolaColheitaPorSafraMinMaxDia(parIdNegocios As Integer) As Object
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosMoagem As New OracleCommand(
            "SELECT MAX(SAFRA) SAFRA, MIN(DIA) MINDIA, MAX(DIA) MAXDIA, MIN(SEMANA) MINSEMANA, MAX(SEMANA) MAXSEMANA, MIN(MES) MINMES, MAX(MES) MAXMES FROM BI4T.INDICADORES_COLHEITA WHERE ID_NEGOCIOS = :p0",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosMoagem.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios

        Dim varSafra As Integer

        Dim varMinDia As Date
        Dim varMaxDia As Date

        Dim varMinSemana As Integer
        Dim varMaxSemana As Integer

        Dim varMinMes As Integer
        Dim varMaxMes As Integer

        conn.Open()

        Dim drDadosMoagem As OracleDataReader = Nothing
        Try
            drDadosMoagem = cmdDadosMoagem.ExecuteReader()
            If drDadosMoagem.HasRows Then
                Do While drDadosMoagem.Read
                    varSafra = Nvl(drDadosMoagem.Item("SAFRA"), 0)

                    varMinDia = Nvl(drDadosMoagem.Item("MINDIA"), DateTime.MinValue)
                    varMaxDia = Nvl(drDadosMoagem.Item("MAXDIA"), DateTime.MinValue)

                    varMinSemana = Nvl(drDadosMoagem.Item("MINSEMANA"), 0)
                    varMaxSemana = Nvl(drDadosMoagem.Item("MAXSEMANA"), 0)

                    varMinMes = Nvl(drDadosMoagem.Item("MINMES"), 0)
                    varMaxMes = Nvl(drDadosMoagem.Item("MAXMES"), 0)
                Loop

                drDadosMoagem.Close()
            End If
        Catch ex As Exception
            'Return InternalServerError(ex)
        Finally
            conn.Close()
            If (Not (drDadosMoagem) Is Nothing) Then
                drDadosMoagem.Dispose()
            End If
        End Try

        GetAgricolaColheitaPorSafraMinMaxDia = New With {Key .safra = varSafra, 
                                                         Key .minDia = varMinDia, 
                                                         Key .maxDia = varMaxDia, 
                                                         Key .minSemana = varMinSemana, 
                                                         Key .maxSemana = varMaxSemana, 
                                                         Key .minMes = varMinMes, 
                                                         Key .maxMes = varMaxMes}
    End Function


    ' GET api/AgricolaColheita/VisaoGeralMinMaxCorteDia/1/20180510
    <HttpGet>
    <Route("VisaoGeralMinMaxCorteDia/{parIdNegocios}/{parDia}")>
    Public Function GetValuesMaxCorteDia(parIdNegocios As Integer, parDia As String) As IHttpActionResult
        Return Ok(GetAgricolaColheitaPorSafraMinMaxCorteDia(parIdNegocios, parDia))
    End Function

    Public Function GetAgricolaColheitaPorSafraMinMaxCorteDia(parIdNegocios As Integer, parDia As String) As Object
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDadosMoagem As New OracleCommand(
            "SELECT MAX(SAFRA) SAFRA, MIN(DIA) MINDIA, MAX(DIA) MAXDIA, MIN(SEMANA) MINSEMANA, MAX(SEMANA) MAXSEMANA, MIN(MES) MINMES, MAX(MES) MAXMES FROM BI4T.INDICADORES_COLHEITA WHERE ID_NEGOCIOS = :p0 AND DIA <= :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosMoagem.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosMoagem.Parameters.Add(":p1", OracleDbType.Date).Value = varDia

        Dim varSafra As Integer

        Dim varMinDia As Date
        Dim varMaxDia As Date

        Dim varMinSemana As Integer
        Dim varMaxSemana As Integer

        Dim varMinMes As Integer
        Dim varMaxMes As Integer

        conn.Open()

        Dim drDadosMoagem As OracleDataReader = Nothing
        Try
            drDadosMoagem = cmdDadosMoagem.ExecuteReader()
            If drDadosMoagem.HasRows Then
                Do While drDadosMoagem.Read
                    varSafra = Nvl(drDadosMoagem.Item("SAFRA"), 0)

                    varMinDia = Nvl(drDadosMoagem.Item("MINDIA"), DateTime.MinValue)
                    varMaxDia = Nvl(drDadosMoagem.Item("MAXDIA"), DateTime.MinValue)

                    varMinSemana = Nvl(drDadosMoagem.Item("MINSEMANA"), 0)
                    varMaxSemana = Nvl(drDadosMoagem.Item("MAXSEMANA"), 0)

                    varMinMes = Nvl(drDadosMoagem.Item("MINMES"), 0)
                    varMaxMes = Nvl(drDadosMoagem.Item("MAXMES"), 0)
                Loop

                drDadosMoagem.Close()
            End If
        Catch ex As Exception
            'Return InternalServerError(ex)
        Finally
            conn.Close()
            If (Not (drDadosMoagem) Is Nothing) Then
                drDadosMoagem.Dispose()
            End If
        End Try

        GetAgricolaColheitaPorSafraMinMaxCorteDia = New With {Key .safra = varSafra, 
                                                              Key .minDia = varMinDia, 
                                                              Key .maxDia = varMaxDia, 
                                                              Key .minSemana = varMinSemana, 
                                                              Key .maxSemana = varMaxSemana, 
                                                              Key .minMes = varMinMes, 
                                                              Key .maxMes = varMaxMes}
    End Function



    ' *** POR DIA
    ' GET api/AgricolaColheita/PorDia/1/2017/20171117
    <HttpGet>
    <Route("PorDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim dadosColheita = GetAgricolaColheitaPorDiaPlain(parIdNegocios, parSafra, varDia)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAgrupadoPorDia(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheita/PorDiaPorFrente/1/2017/20171117/1
    <HttpGet>
    <Route("PorDiaPorFrente/{parIdNegocios}/{parSafra}/{parDia}/{parFrente}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parDia As String, parFrente As Integer) As IHttpActionResult
        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim dadosColheita = GetAgricolaColheitaPorDiaPorFrentePlain(parIdNegocios, parSafra, varDia, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAgrupadoPorDia(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function


    Public Function GetAgricolaColheitaPorDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As DateTime) As List(Of S5TAgricolaColheita)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheita & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA = :p2 AND ID_CA_INDICADOR IN (24, 25, 26)",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Date).Value = parDia

        Return GetDadosColheita(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaPorDiaPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parDia As DateTime, parFrente As Integer) As List(Of S5TAgricolaColheita)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheita & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA = :p2 AND ID_CA_INDICADOR IN (24, 26, 27, 28, 29) AND FRENTE = :p3",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Date).Value = parDia
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente

        Return GetDadosColheita(conn, cmdDadosColheita)
    End Function

    Private Function GetAgricolaColheitaGraficoDensidadeCargaEixoY(parDadosColheita As List(Of S5TAgricolaColheita)) As S5TAgricolaColheitaGraficoDensidadeCargaEscalaEixoY
        Dim varMin As Integer = 0
        Dim varMax As Integer = 100
        Dim varInc As Integer = 10

        Dim varMenorValorRealizado = 0
        Dim varMaiorValorRealizado = 0

        Dim varMenorValorPlanejado = 0
        Dim varMaiorValorPlanejado = 0

        Dim varDadosColheitaEfetivos = parDadosColheita.FindAll(Function(x) x.PLANEJADO > 0).FindAll(Function(x) x.REALIZADO > 0)

        If varDadosColheitaEfetivos.Count > 0 Then
            varMenorValorRealizado = varDadosColheitaEfetivos.Min(Function(x) x.REALIZADO)
            varMaiorValorRealizado = varDadosColheitaEfetivos.Max(Function(x) x.REALIZADO)

            varMenorValorPlanejado = varDadosColheitaEfetivos.Min(Function(x) x.PLANEJADO)
            varMaiorValorPlanejado = varDadosColheitaEfetivos.Max(Function(x) x.PLANEJADO)

            varInc = 2
        End If

        Dim varDadosColheitaRealizadoZerado = parDadosColheita.FindAll(Function(x) x.REALIZADO <= 0)

        If varDadosColheitaRealizadoZerado.Count > 0 Then
            varMenorValorRealizado = 0

            varInc = 5
        End If

        Dim valores = New List(Of Double) From { varMenorValorRealizado, varMaiorValorRealizado, varMenorValorPlanejado, varMaiorValorPlanejado}

        Dim varMenorValor = valores.Min
        Dim varMaiorValor = valores.Max

        GetAgricolaColheitaGraficoDensidadeCargaEixoY = New S5TAgricolaColheitaGraficoDensidadeCargaEscalaEixoY With {.Min = IIf(varMenorValor <= 5, 0, Math.Round(varMenorValor - 5,0)), .Max = Math.Round(varMaiorValor + 5,0), .Inc = varInc}
    End Function

    Private Function GetAgricolaColheitaAgrupadoPorDia(parDadosColheita As List(Of S5TAgricolaColheita)) As S5TAgricolaColheitaAgrupadoPorDia
        Dim varDadosEntregaCanaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                      Key .HORA = x.HORA}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                             .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                                             .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                             .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)


        Dim varDadosDensidadeCargaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                        Key .HORA = x.HORA}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                               .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                               .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                               .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2)) }).ToList

        Dim varDadosDensidadeCargaAgrupadoGeral = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .ID_NEGOCIOS = x.ID_NEGOCIOS}).Select(Function (y) New S5TAgricolaColheita With {.ID_NEGOCIOS = y.Min(Function(group) group.ID_NEGOCIOS), _
                                                                                                                                                                                                                                  .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                                  .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2)) }).ToList

        Dim varDadosImpurezaMineralAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 27).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                         Key .HORA = x.HORA}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                        .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                        .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                        .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosImpurezaVegetalAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 28).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                         Key .HORA = x.HORA}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                        .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                        .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                        .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosVelocidadeMediaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 29).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                         Key .HORA = x.HORA}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                        .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                        .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                        .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varHoraAtual = parDadosColheita.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().HORA

        Dim varMediaPorHora As Double = Math.Round(varDadosEntregaCanaAgrupado.Average(Function(x) x.REALIZADO),0)
        Dim varEstoquePatio As Double = 0
        Dim objEstoquePatio = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 25 And x.HORA = varHoraAtual).FirstOrDefault()
        If objEstoquePatio IsNot Nothing Then varEstoquePatio = objEstoquePatio.REALIZADO

        Dim varEntregaAcumuladaAtual = varDadosEntregaCanaAcumulado.LastOrDefault().REALIZADO
        Dim varDensidadeAtual = varDadosDensidadeCargaAgrupadoGeral.LastOrDefault().REALIZADO

        Dim varEntregaPlanejadaAcumuladaAtual = varDadosEntregaCanaAcumulado.LastOrDefault().PLANEJADO

        Dim varDesvioPercentual = If(varEntregaPlanejadaAcumuladaAtual = 0, 0, Math.Round(Math.Round(varEntregaAcumuladaAtual / varEntregaPlanejadaAcumuladaAtual * 100, 1) - 100, 1))

        Dim varEntregaCanaPlanejadoTotal As Double = 0
        Dim objEntregaCanaAgrupadoPlanejadoTotal = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA = "").GroupBy(Function(x) New With {Key .ID_NEGOCIOS = x.ID_NEGOCIOS}).Select(Function (y) New S5TAgricolaColheita With {
                                                                                                                                                                                                           .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                           .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList.FirstOrDefault()

        If objEntregaCanaAgrupadoPlanejadoTotal IsNot Nothing Then varEntregaCanaPlanejadoTotal = Math.Round(objEntregaCanaAgrupadoPlanejadoTotal.PLANEJADO, 0)

        Dim varFrentesEntregaCanaAgrupadas = GetAgricolaColheitaFrentes(parDadosColheita, TipoAgrupamento.Dia, FrentesIndicador.EntregaCana)

        Dim varFrentesDensidadeCargaAgrupadas = GetAgricolaColheitaFrentes(parDadosColheita, TipoAgrupamento.Dia, FrentesIndicador.DensidadeCarga)

        Dim objGraficoDensidadeCargaEscalaEixoY = GetAgricolaColheitaGraficoDensidadeCargaEixoY(varDadosDensidadeCargaAgrupado)

        GetAgricolaColheitaAgrupadoPorDia = New S5TAgricolaColheitaAgrupadoPorDia With {
                                                                                        .oGraficoEntregaCanaAcumulado = varDadosEntregaCanaAcumulado,
                                                                                        .oGraficoDensidadeCarga = varDadosDensidadeCargaAgrupado,
                                                                                        .graficoDensidadeCargaYMin = objGraficoDensidadeCargaEscalaEixoY.Min,
                                                                                        .graficoDensidadeCargaYMax = objGraficoDensidadeCargaEscalaEixoY.Max,
                                                                                        .graficoDensidadeCargaYInc = objGraficoDensidadeCargaEscalaEixoY.Inc,
                                                                                        .oGraficoImpurezaMineral = varDadosImpurezaMineralAgrupado,
                                                                                        .oGraficoImpurezaVegetal = varDadosImpurezaVegetalAgrupado,
                                                                                        .oGraficoVelocidadeMedia = varDadosVelocidadeMediaAgrupado,
                                                                                        .horaAtual = varHoraAtual, 
                                                                                        .entregaAcumulada = varEntregaAcumuladaAtual,
                                                                                        .entregaPlanejadaAcumulada = varEntregaPlanejadaAcumuladaAtual,
                                                                                        .entregaPlanejadaTotal = varEntregaCanaPlanejadoTotal,
                                                                                        .media = varMediaPorHora,
                                                                                        .estoquePatio = varEstoquePatio,
                                                                                        .desvio = varDesvioPercentual,
                                                                                        .densidadeAtual = varDensidadeAtual,
                                                                                        .oFrentesEntregaCana = varFrentesEntregaCanaAgrupadas,
                                                                                        .oFrentesDensidadeCarga = varFrentesDensidadeCargaAgrupadas}
    End Function

    Public Function GetAgricolaColheitaEquipamentoPorDiaPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parDia As DateTime, parFrente As Integer) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA = :p2 AND FRENTE = :p3",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Date).Value = parDia
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function

    Private Function GetAgricolaColheitaEquipamentoAgrupadoPorDia(parDadosColheita As List(Of S5TAgricolaColheitaEquipamento)) As S5TAgricolaColheitaEquipamentoAgrupado
        Dim varDadosColhedoraI29VelocidadeColheitaAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 29).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                                      Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                              .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                              .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                              .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI30EquipProdutivoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 30 And x.TIPO_PLANEJAMENTO = "D").GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                          .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI31FaltaTratorAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 31).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                               Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                       .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                       .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                       .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI32TempoAprovAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 32 And x.TIPO_PLANEJAMENTO = "D").GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                              Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                      .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                      .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                      .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI33AprovDistanciaAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 33 And x.TIPO_PLANEJAMENTO = "D").GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                          .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI49ProdutividadeAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 49).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                                 Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                         .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                         .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                         .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI30EquipProdutivoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 30 And x.TIPO_PLANEJAMENTO = "D").GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                            Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                    .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                    .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                    .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI34FilaCarregamentoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 34).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                              Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                      .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                      .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                      .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI35FaltaCaminhaoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 35).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                           Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                   .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                   .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                   .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList



        GetAgricolaColheitaEquipamentoAgrupadoPorDia = New S5TAgricolaColheitaEquipamentoAgrupado With {
                                                                                            .oGraficoColhedoraI29 = varDadosColhedoraI29VelocidadeColheitaAgrupado,
                                                                                            .graficoColhedoraI29Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI29VelocidadeColheitaAgrupado),
                                                                                            .graficoColhedoraI29Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI29VelocidadeColheitaAgrupado),
                                                                                            .oGraficoColhedoraI30 = varDadosColhedoraI30EquipProdutivoAgrupado,
                                                                                            .graficoColhedoraI30Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI30EquipProdutivoAgrupado),
                                                                                            .graficoColhedoraI30Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI30EquipProdutivoAgrupado),
                                                                                            .oGraficoColhedoraI31 = varDadosColhedoraI31FaltaTratorAgrupado,
                                                                                            .graficoColhedoraI31Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI31FaltaTratorAgrupado),
                                                                                            .graficoColhedoraI31Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI31FaltaTratorAgrupado),
                                                                                            .oGraficoColhedoraI32 = varDadosColhedoraI32TempoAprovAgrupado,
                                                                                            .graficoColhedoraI32Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI32TempoAprovAgrupado),
                                                                                            .graficoColhedoraI32Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI32TempoAprovAgrupado),
                                                                                            .oGraficoColhedoraI33 = varDadosColhedoraI33AprovDistanciaAgrupado,
                                                                                            .graficoColhedoraI33Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI33AprovDistanciaAgrupado),
                                                                                            .graficoColhedoraI33Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI33AprovDistanciaAgrupado),
                                                                                            .oGraficoColhedoraI49 = varDadosColhedoraI49ProdutividadeAgrupado,
                                                                                            .graficoColhedoraI49Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI49ProdutividadeAgrupado),
                                                                                            .graficoColhedoraI49Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI49ProdutividadeAgrupado),
                                                                                            .oGraficoTratorI30 = varDadosTratorI30EquipProdutivoAgrupado,
                                                                                            .graficoTratorI30Media = GetEquipamentoIndicadorMedia(varDadosTratorI30EquipProdutivoAgrupado),
                                                                                            .graficoTratorI30Meta = GetEquipamentoIndicadorMeta(varDadosTratorI30EquipProdutivoAgrupado),
                                                                                            .oGraficoTratorI34 = varDadosTratorI34FilaCarregamentoAgrupado,
                                                                                            .graficoTratorI34Media = GetEquipamentoIndicadorMedia(varDadosTratorI34FilaCarregamentoAgrupado),
                                                                                            .graficoTratorI34Meta = GetEquipamentoIndicadorMeta(varDadosTratorI34FilaCarregamentoAgrupado),
                                                                                            .oGraficoTratorI35 = varDadosTratorI35FaltaCaminhaoAgrupado,
                                                                                            .graficoTratorI35Media = GetEquipamentoIndicadorMedia(varDadosTratorI35FaltaCaminhaoAgrupado),
                                                                                            .graficoTratorI35Meta = GetEquipamentoIndicadorMeta(varDadosTratorI35FaltaCaminhaoAgrupado)
                                                                                            }
    End Function

    ' *** POR SEMANA
    ' GET api/AgricolaColheita/PorSemana/1/2017/46
    <HttpGet>
    <Route("PorSemana/{parIdNegocios}/{parSafra}/{parSemana}")>
    Public Function GetValuesPorSemana(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorSemanaPlain(parIdNegocios, parSafra, parSemana)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAgrupadoPorSemana(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheita/PorSemanaPorFrente/1/2017/46/1
    <HttpGet>
    <Route("PorSemanaPorFrente/{parIdNegocios}/{parSafra}/{parSemana}/{parFrente}")>
    Public Function GetValuesPorSemanaPorFrente(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parFrente As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorSemanaPorFrentePlain(parIdNegocios, parSafra, parSemana, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAgrupadoPorSemana(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function


    Public Function GetAgricolaColheitaPorSemanaPlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As List(Of S5TAgricolaColheita)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheita & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2 AND ID_CA_INDICADOR IN (24, 25, 26)",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana

        Return GetDadosColheita(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaPorSemanaPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parFrente As Integer) As List(Of S5TAgricolaColheita)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheita & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2 AND ID_CA_INDICADOR IN (24, 26, 27, 28, 29) AND FRENTE = :p3",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente

        Return GetDadosColheita(conn, cmdDadosColheita)
    End Function

    Private Function GetAgricolaColheitaAgrupadoPorSemana(parDadosColheita As List(Of S5TAgricolaColheita)) As S5TAgricolaColheitaAgrupadoPorSemana
        Dim varDadosEntregaCanaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                               .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                               .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

        Dim varDadosDensidadeCargaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                  .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                  .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

        Dim varDadosDensidadeCargaAgrupadoGeral = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .ID_NEGOCIOS = x.ID_NEGOCIOS}).Select(Function (y) New S5TAgricolaColheita With {.ID_NEGOCIOS = y.Min(Function(group) group.ID_NEGOCIOS), _
                                                                                                                                                                                                                                  .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                                  .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2)) }).ToList

        Dim varDadosImpurezaMineralAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 27).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                   .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                   .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

        Dim varDadosImpurezaVegetalAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 28).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                   .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                   .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

        Dim varDadosVelocidadeMediaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 29).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                   .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                   .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList


        Dim varDiaAtual = parDadosColheita.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().DIA.Date

        Dim varMediaPorDia As Double = Math.Round(varDadosEntregaCanaAgrupado.Average(Function(x) x.REALIZADO),0)

        Dim varEntregaAcumuladaAtual = varDadosEntregaCanaAcumulado.LastOrDefault().REALIZADO
        Dim varDensidadeAtual = varDadosDensidadeCargaAgrupadoGeral.LastOrDefault().REALIZADO

        Dim varEntregaPlanejadaAcumuladaAtual = varDadosEntregaCanaAcumulado.LastOrDefault().PLANEJADO

        Dim varDesvioPercentual = If(varEntregaPlanejadaAcumuladaAtual = 0, 0, Math.Round(Math.Round(varEntregaAcumuladaAtual / varEntregaPlanejadaAcumuladaAtual * 100, 1) - 100, 1))

        Dim varEntregaCanaPlanejadoTotal As Double = 0
        Dim objEntregaCanaAgrupadoPlanejadoTotal = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA = "").GroupBy(Function(x) New With {Key .ID_NEGOCIOS = x.ID_NEGOCIOS}).Select(Function (y) New S5TAgricolaColheita With {
                                                                                                                                                                                                           .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                           .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList.FirstOrDefault()

        If objEntregaCanaAgrupadoPlanejadoTotal IsNot Nothing Then varEntregaCanaPlanejadoTotal = Math.Round(objEntregaCanaAgrupadoPlanejadoTotal.PLANEJADO, 0)

        Dim varFrentesEntregaCanaAgrupadas = GetAgricolaColheitaFrentes(parDadosColheita, TipoAgrupamento.Semana, FrentesIndicador.EntregaCana)

        Dim varFrentesDensidadeCargaAgrupadas = GetAgricolaColheitaFrentes(parDadosColheita, TipoAgrupamento.Semana, FrentesIndicador.DensidadeCarga)

        Dim objGraficoDensidadeCargaEscalaEixoY = GetAgricolaColheitaGraficoDensidadeCargaEixoY(varDadosDensidadeCargaAgrupado)

        GetAgricolaColheitaAgrupadoPorSemana = New S5TAgricolaColheitaAgrupadoPorSemana With {
                                                                                            .oGraficoEntregaCanaAcumulado = varDadosEntregaCanaAcumulado,
                                                                                            .oGraficoDensidadeCarga = varDadosDensidadeCargaAgrupado,
                                                                                            .graficoDensidadeCargaYMin = objGraficoDensidadeCargaEscalaEixoY.Min,
                                                                                            .graficoDensidadeCargaYMax = objGraficoDensidadeCargaEscalaEixoY.Max,
                                                                                            .graficoDensidadeCargaYInc = objGraficoDensidadeCargaEscalaEixoY.Inc,
                                                                                            .oGraficoImpurezaMineral = varDadosImpurezaMineralAgrupado,
                                                                                            .oGraficoImpurezaVegetal = varDadosImpurezaVegetalAgrupado,
                                                                                            .oGraficoVelocidadeMedia = varDadosVelocidadeMediaAgrupado,
                                                                                            .diaAtual = varDiaAtual, 
                                                                                            .entregaAcumulada = varEntregaAcumuladaAtual,
                                                                                            .entregaPlanejadaAcumulada = varEntregaPlanejadaAcumuladaAtual,
                                                                                            .entregaPlanejadaTotal = varEntregaCanaPlanejadoTotal,
                                                                                            .media = varMediaPorDia,
                                                                                            .desvio = varDesvioPercentual,
                                                                                            .densidadeAtual = varDensidadeAtual,
                                                                                            .oFrentesEntregaCana = varFrentesEntregaCanaAgrupadas,
                                                                                            .oFrentesDensidadeCarga = varFrentesDensidadeCargaAgrupadas}
    End Function

    Public Function GetAgricolaColheitaEquipamentoPorSemanaPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parFrente As Integer) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2 AND FRENTE = :p3",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaEquipamentoPorSemanaPorFrenteCorteDiaPlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parFrente As Integer, parDia As String) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2 AND FRENTE = :p3 AND ID_INDICADOR NOT IN (30,32,33) UNION ALL " & 
            QueryAgricolaColheitaEquipamento & " AND ID_NEGOCIOS = :p4 AND SAFRA = :p5 AND SEMANA = :p6 AND FRENTE = :p7 AND DIA = :p8 AND ID_INDICADOR IN (30,32,33)",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente

        cmdDadosColheita.Parameters.Add(":p4", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p5", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p6", OracleDbType.Int16).Value = parSemana
        cmdDadosColheita.Parameters.Add(":p7", OracleDbType.Int16).Value = parFrente
        cmdDadosColheita.Parameters.Add(":p8", OracleDbType.Date).Value = varDia

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function


    Private Function GetAgricolaColheitaEquipamentoAgrupadoPorSemana(parDadosColheita As List(Of S5TAgricolaColheitaEquipamento)) As S5TAgricolaColheitaEquipamentoAgrupado
        Dim varDadosColhedoraI29VelocidadeColheitaAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 29).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                      Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                              .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                              .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                              .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI30EquipProdutivoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 30 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                          .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI31FaltaTratorAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 31).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                               Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                       .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                       .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                       .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI32TempoAprovAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 32 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                              Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                      .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                      .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                      .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI33AprovDistanciaAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 33 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                          .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI49ProdutividadeAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 49).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                 Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                         .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                         .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                         .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI30EquipProdutivoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 30 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                            Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                    .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                    .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                    .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI34FilaCarregamentoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 34).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                              Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                      .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                      .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                      .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI35FaltaCaminhaoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 35).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                           Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                   .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                   .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                   .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList



        GetAgricolaColheitaEquipamentoAgrupadoPorSemana = New S5TAgricolaColheitaEquipamentoAgrupado With {
                                                                                            .oGraficoColhedoraI29 = varDadosColhedoraI29VelocidadeColheitaAgrupado,
                                                                                            .graficoColhedoraI29Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI29VelocidadeColheitaAgrupado),
                                                                                            .graficoColhedoraI29Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI29VelocidadeColheitaAgrupado),
                                                                                            .oGraficoColhedoraI30 = varDadosColhedoraI30EquipProdutivoAgrupado,
                                                                                            .graficoColhedoraI30Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI30EquipProdutivoAgrupado),
                                                                                            .graficoColhedoraI30Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI30EquipProdutivoAgrupado),
                                                                                            .oGraficoColhedoraI31 = varDadosColhedoraI31FaltaTratorAgrupado,
                                                                                            .graficoColhedoraI31Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI31FaltaTratorAgrupado),
                                                                                            .graficoColhedoraI31Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI31FaltaTratorAgrupado),
                                                                                            .oGraficoColhedoraI32 = varDadosColhedoraI32TempoAprovAgrupado,
                                                                                            .graficoColhedoraI32Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI32TempoAprovAgrupado),
                                                                                            .graficoColhedoraI32Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI32TempoAprovAgrupado),
                                                                                            .oGraficoColhedoraI33 = varDadosColhedoraI33AprovDistanciaAgrupado,
                                                                                            .graficoColhedoraI33Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI33AprovDistanciaAgrupado),
                                                                                            .graficoColhedoraI33Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI33AprovDistanciaAgrupado),
                                                                                            .oGraficoColhedoraI49 = varDadosColhedoraI49ProdutividadeAgrupado,
                                                                                            .graficoColhedoraI49Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI49ProdutividadeAgrupado),
                                                                                            .graficoColhedoraI49Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI49ProdutividadeAgrupado),
                                                                                            .oGraficoTratorI30 = varDadosTratorI30EquipProdutivoAgrupado,
                                                                                            .graficoTratorI30Media = GetEquipamentoIndicadorMedia(varDadosTratorI30EquipProdutivoAgrupado),
                                                                                            .graficoTratorI30Meta = GetEquipamentoIndicadorMeta(varDadosTratorI30EquipProdutivoAgrupado),
                                                                                            .oGraficoTratorI34 = varDadosTratorI34FilaCarregamentoAgrupado,
                                                                                            .graficoTratorI34Media = GetEquipamentoIndicadorMedia(varDadosTratorI34FilaCarregamentoAgrupado),
                                                                                            .graficoTratorI34Meta = GetEquipamentoIndicadorMeta(varDadosTratorI34FilaCarregamentoAgrupado),
                                                                                            .oGraficoTratorI35 = varDadosTratorI35FaltaCaminhaoAgrupado,
                                                                                            .graficoTratorI35Media = GetEquipamentoIndicadorMedia(varDadosTratorI35FaltaCaminhaoAgrupado),
                                                                                            .graficoTratorI35Meta = GetEquipamentoIndicadorMeta(varDadosTratorI35FaltaCaminhaoAgrupado)
                                                                                            }
    End Function


    ' *** POR MÊS
    ' GET api/AgricolaColheita/PorMes/1/2017/11
    <HttpGet>
    <Route("PorMes/{parIdNegocios}/{parSafra}/{parMes}")>
    Public Function GetValuesPorMes(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorMesPlain(parIdNegocios, parSafra, parMes)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAgrupadoPorMes(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheita/PorMesPorFrente/1/2017/11/1
    <HttpGet>
    <Route("PorMesPorFrente/{parIdNegocios}/{parSafra}/{parMes}/{parFrente}")>
    Public Function GetValuesPorMesPorFrente(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parFrente As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorMesPorFrentePlain(parIdNegocios, parSafra, parMes, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAgrupadoPorMes(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    Public Function GetAgricolaColheitaPorMesPlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As List(Of S5TAgricolaColheita)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(QueryAgricolaColheita & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2 AND ID_CA_INDICADOR IN (24, 25, 26)", conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parMes


        'Dim cmdDadosColheita As New OracleCommand(QueryAgricolaColheita & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA BETWEEN (SELECT MIN(SEMANA) FROM BI4T.INDICADORES_COLHEITA WHERE ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2 AND ID_CA_INDICADOR IN (24, 25, 26)) AND (SELECT MAX(SEMANA) FROM BI4T.INDICADORES_COLHEITA WHERE ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2 AND ID_CA_INDICADOR IN (24, 25, 26)) AND ID_CA_INDICADOR IN (24, 25, 26)", conn) With {.CommandType = CommandType.Text}

        'cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parIdNegocios
        'cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parSafra
        'cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parIdNegocios
        'cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parSafra
        'cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parMes
        'cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parIdNegocios
        'cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parSafra
        'cmdDadosColheita.Parameters.Add("", OracleDbType.Int16).Value = parMes

        Return GetDadosColheita(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaPorMesPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parFrente As Integer) As List(Of S5TAgricolaColheita)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheita & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2 AND ID_CA_INDICADOR IN (24, 26, 27, 28, 29) AND FRENTE = :p3",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parMes
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente

        Return GetDadosColheita(conn, cmdDadosColheita)
    End Function

    Private Function GetAgricolaColheitaAgrupadoPorMes(parDadosColheita As List(Of S5TAgricolaColheita)) As S5TAgricolaColheitaAgrupadoPorMes
        Dim varDadosEntregaCanaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TAgricolaColheita With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                .semanaPeriodo = New S5TAgricolaColheitaSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

        Dim varDadosDensidadeCargaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TAgricolaColheita With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                   .semanaPeriodo = New S5TAgricolaColheitaSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                   .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                   .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

        Dim varDadosDensidadeCargaAgrupadoGeral = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .ID_NEGOCIOS = x.ID_NEGOCIOS}).Select(Function (y) New S5TAgricolaColheita With {.ID_NEGOCIOS = y.Min(Function(group) group.ID_NEGOCIOS), _
                                                                                                                                                                                                                                  .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                                  .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2)) }).ToList

        Dim varDadosImpurezaMineralAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 27).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TAgricolaColheita With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                    .semanaPeriodo = New S5TAgricolaColheitaSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                    .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                    .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

        Dim varDadosImpurezaVegetalAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 28).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TAgricolaColheita With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                    .semanaPeriodo = New S5TAgricolaColheitaSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                    .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                    .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

        Dim varDadosVelocidadeMediaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 29).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TAgricolaColheita With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                    .semanaPeriodo = New S5TAgricolaColheitaSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                    .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                    .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList


        Dim varSemanaAtual = parDadosColheita.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().SEMANA

        Dim varMediaPorSemana As Double = Math.Round(varDadosEntregaCanaAgrupado.Average(Function(x) x.REALIZADO),0)
        Dim varEntregaAcumuladaAtual = varDadosEntregaCanaAcumulado.LastOrDefault().REALIZADO
        Dim varDensidadeAtual = varDadosDensidadeCargaAgrupadoGeral.LastOrDefault().REALIZADO

        Dim varEntregaPlanejadaAcumuladaAtual = varDadosEntregaCanaAcumulado.LastOrDefault().PLANEJADO

        Dim varDesvioPercentual = If(varEntregaPlanejadaAcumuladaAtual = 0, 0, Math.Round(Math.Round(varEntregaAcumuladaAtual / varEntregaPlanejadaAcumuladaAtual * 100, 1) - 100, 1))

        Dim varEntregaCanaPlanejadoTotal As Double = 0
        Dim objEntregaCanaAgrupadoPlanejadoTotal = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA = "").GroupBy(Function(x) New With {Key .ID_NEGOCIOS = x.ID_NEGOCIOS}).Select(Function (y) New S5TAgricolaColheita With {
                                                                                                                                                                                                           .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                           .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList.FirstOrDefault()

        If objEntregaCanaAgrupadoPlanejadoTotal IsNot Nothing Then varEntregaCanaPlanejadoTotal = Math.Round(objEntregaCanaAgrupadoPlanejadoTotal.PLANEJADO, 0)

        Dim varFrentesEntregaCanaAgrupadas = GetAgricolaColheitaFrentes(parDadosColheita, TipoAgrupamento.Mes, FrentesIndicador.EntregaCana)

        Dim varFrentesDensidadeCargaAgrupadas = GetAgricolaColheitaFrentes(parDadosColheita, TipoAgrupamento.Mes, FrentesIndicador.DensidadeCarga)

        Dim objGraficoDensidadeCargaEscalaEixoY = GetAgricolaColheitaGraficoDensidadeCargaEixoY(varDadosDensidadeCargaAgrupado)

        GetAgricolaColheitaAgrupadoPorMes = New S5TAgricolaColheitaAgrupadoPorMes With {
                                                                                        .oGraficoEntregaCanaAcumulado = varDadosEntregaCanaAcumulado,
                                                                                        .oGraficoDensidadeCarga = varDadosDensidadeCargaAgrupado,
                                                                                        .graficoDensidadeCargaYMin = objGraficoDensidadeCargaEscalaEixoY.Min,
                                                                                        .graficoDensidadeCargaYMax = objGraficoDensidadeCargaEscalaEixoY.Max,
                                                                                        .graficoDensidadeCargaYInc = objGraficoDensidadeCargaEscalaEixoY.Inc,
                                                                                        .oGraficoImpurezaMineral = varDadosImpurezaMineralAgrupado,
                                                                                        .oGraficoImpurezaVegetal = varDadosImpurezaVegetalAgrupado,
                                                                                        .oGraficoVelocidadeMedia = varDadosVelocidadeMediaAgrupado,
                                                                                        .semanaAtual = varSemanaAtual, 
                                                                                        .entregaAcumulada = varEntregaAcumuladaAtual,
                                                                                        .entregaPlanejadaAcumulada = varEntregaPlanejadaAcumuladaAtual,
                                                                                        .entregaPlanejadaTotal = varEntregaCanaPlanejadoTotal,
                                                                                        .media = varMediaPorSemana,
                                                                                        .desvio = varDesvioPercentual,
                                                                                        .densidadeAtual = varDensidadeAtual,
                                                                                        .oFrentesEntregaCana = varFrentesEntregaCanaAgrupadas,
                                                                                        .oFrentesDensidadeCarga = varFrentesDensidadeCargaAgrupadas}
    End Function

    Public Function GetAgricolaColheitaEquipamentoPorMesPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parFrente As Integer) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2 AND FRENTE = :p3",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parMes
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaEquipamentoPorMesPorFrenteCorteDiaPlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parFrente As Integer, parDia As String) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2 AND FRENTE = :p3 AND ID_INDICADOR NOT IN (30,32,33) UNION ALL " & 
            QueryAgricolaColheitaEquipamento & " AND ID_NEGOCIOS = :p4 AND SAFRA = :p5 AND MES = :p6 AND FRENTE = :p7 AND DIA = :p8 AND ID_INDICADOR IN (30,32,33)",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parMes
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente

        cmdDadosColheita.Parameters.Add(":p4", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p5", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p6", OracleDbType.Int16).Value = parMes
        cmdDadosColheita.Parameters.Add(":p7", OracleDbType.Int16).Value = parFrente
        cmdDadosColheita.Parameters.Add(":p8", OracleDbType.Date).Value = varDia

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function


    Private Function GetAgricolaColheitaEquipamentoAgrupadoPorMes(parDadosColheita As List(Of S5TAgricolaColheitaEquipamento)) As S5TAgricolaColheitaEquipamentoAgrupado
        Dim varDadosColhedoraI29VelocidadeColheitaAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 29).GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                      Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                              .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                              .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                              .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI30EquipProdutivoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 30 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                          .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI31FaltaTratorAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 31).GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                               Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                       .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                       .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                       .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI32TempoAprovAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 32 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                              Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                      .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                      .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                      .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI33AprovDistanciaAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 33 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                          .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI49ProdutividadeAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 49).GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                 Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                         .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                         .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                         .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI30EquipProdutivoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 30 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                            Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                    .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                    .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                    .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI34FilaCarregamentoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 34).GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                              Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                      .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                      .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                      .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI35FaltaCaminhaoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 35).GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                           Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                   .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                   .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                   .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList



        GetAgricolaColheitaEquipamentoAgrupadoPorMes = New S5TAgricolaColheitaEquipamentoAgrupado With {
                                                                                            .oGraficoColhedoraI29 = varDadosColhedoraI29VelocidadeColheitaAgrupado,
                                                                                            .graficoColhedoraI29Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI29VelocidadeColheitaAgrupado),
                                                                                            .graficoColhedoraI29Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI29VelocidadeColheitaAgrupado),
                                                                                            .oGraficoColhedoraI30 = varDadosColhedoraI30EquipProdutivoAgrupado,
                                                                                            .graficoColhedoraI30Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI30EquipProdutivoAgrupado),
                                                                                            .graficoColhedoraI30Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI30EquipProdutivoAgrupado),
                                                                                            .oGraficoColhedoraI31 = varDadosColhedoraI31FaltaTratorAgrupado,
                                                                                            .graficoColhedoraI31Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI31FaltaTratorAgrupado),
                                                                                            .graficoColhedoraI31Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI31FaltaTratorAgrupado),
                                                                                            .oGraficoColhedoraI32 = varDadosColhedoraI32TempoAprovAgrupado,
                                                                                            .graficoColhedoraI32Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI32TempoAprovAgrupado),
                                                                                            .graficoColhedoraI32Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI32TempoAprovAgrupado),
                                                                                            .oGraficoColhedoraI33 = varDadosColhedoraI33AprovDistanciaAgrupado,
                                                                                            .graficoColhedoraI33Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI33AprovDistanciaAgrupado),
                                                                                            .graficoColhedoraI33Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI33AprovDistanciaAgrupado),
                                                                                            .oGraficoColhedoraI49 = varDadosColhedoraI49ProdutividadeAgrupado,
                                                                                            .graficoColhedoraI49Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI49ProdutividadeAgrupado),
                                                                                            .graficoColhedoraI49Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI49ProdutividadeAgrupado),
                                                                                            .oGraficoTratorI30 = varDadosTratorI30EquipProdutivoAgrupado,
                                                                                            .graficoTratorI30Media = GetEquipamentoIndicadorMedia(varDadosTratorI30EquipProdutivoAgrupado),
                                                                                            .graficoTratorI30Meta = GetEquipamentoIndicadorMeta(varDadosTratorI30EquipProdutivoAgrupado),
                                                                                            .oGraficoTratorI34 = varDadosTratorI34FilaCarregamentoAgrupado,
                                                                                            .graficoTratorI34Media = GetEquipamentoIndicadorMedia(varDadosTratorI34FilaCarregamentoAgrupado),
                                                                                            .graficoTratorI34Meta = GetEquipamentoIndicadorMeta(varDadosTratorI34FilaCarregamentoAgrupado),
                                                                                            .oGraficoTratorI35 = varDadosTratorI35FaltaCaminhaoAgrupado,
                                                                                            .graficoTratorI35Media = GetEquipamentoIndicadorMedia(varDadosTratorI35FaltaCaminhaoAgrupado),
                                                                                            .graficoTratorI35Meta = GetEquipamentoIndicadorMeta(varDadosTratorI35FaltaCaminhaoAgrupado)
                                                                                            }
    End Function


    ' *** POR SAFRA
    ' GET api/AgricolaColheita/PorSafra/1/2017
    <HttpGet>
    <Route("PorSafra/{parIdNegocios}/{parSafra}")>
    Public Function GetValuesPorSafra(parIdNegocios As Integer, parSafra As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorSafraPlain(parIdNegocios, parSafra)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAgrupadoPorSafra(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheita/PorSafraPorFrente/1/2017/1
    <HttpGet>
    <Route("PorSafraPorFrente/{parIdNegocios}/{parSafra}/{parFrente}")>
    Public Function GetValuesPorSafraPorFrente(parIdNegocios As Integer, parSafra As Integer, parFrente As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorSafraPorFrentePlain(parIdNegocios, parSafra, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAgrupadoPorSafra(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    Public Function GetAgricolaColheitaPorSafraPlain(parIdNegocios As Integer, parSafra As Integer) As List(Of S5TAgricolaColheita)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheita & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND ID_CA_INDICADOR IN (24, 25, 26)",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra

        Return GetDadosColheita(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaPorSafraPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parFrente As Integer) As List(Of S5TAgricolaColheita)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheita & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND ID_CA_INDICADOR IN (24, 26, 27, 28, 29) AND FRENTE = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parFrente

        Return GetDadosColheita(conn, cmdDadosColheita)
    End Function

    Private Function GetAgricolaColheitaAgrupadoPorSafra(parDadosColheita As List(Of S5TAgricolaColheita)) As S5TAgricolaColheitaAgrupadoPorSafra
        Dim varDadosEntregaCanaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TAgricolaColheita With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                          .DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                          .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

        Dim varDadosDensidadeCargaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TAgricolaColheita With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                             .DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                             .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                             .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

        Dim varDadosDensidadeCargaAgrupadoGeral = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .ID_NEGOCIOS = x.ID_NEGOCIOS}).Select(Function (y) New S5TAgricolaColheita With {.ID_NEGOCIOS = y.Min(Function(group) group.ID_NEGOCIOS), _
                                                                                                                                                                                                                                  .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                                  .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2)) }).ToList

        Dim varDadosImpurezaMineralAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 27).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TAgricolaColheita With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                              .DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                              .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                              .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

        Dim varDadosImpurezaVegetalAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 28).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TAgricolaColheita With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                              .DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                              .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                              .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

        Dim varDadosVelocidadeMediaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 29).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TAgricolaColheita With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                              .DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                              .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                              .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList


        Dim varMesAtual = parDadosColheita.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().MES

        Dim varMediaPorMes As Double = Math.Round(varDadosEntregaCanaAgrupado.Average(Function(x) x.REALIZADO),0)

        Dim varEntregaAcumuladaAtual = varDadosEntregaCanaAcumulado.LastOrDefault().REALIZADO
        Dim varDensidadeAtual = varDadosDensidadeCargaAgrupadoGeral.LastOrDefault().REALIZADO

        Dim varEntregaPlanejadaAcumuladaAtual = varDadosEntregaCanaAcumulado.LastOrDefault().PLANEJADO

        Dim varDesvioPercentual = If(varEntregaPlanejadaAcumuladaAtual = 0, 0, Math.Round(Math.Round(varEntregaAcumuladaAtual / varEntregaPlanejadaAcumuladaAtual * 100, 1) - 100, 1))

        Dim varEntregaCanaPlanejadoTotal As Double = 0
        Dim objEntregaCanaAgrupadoPlanejadoTotal = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA = "").GroupBy(Function(x) New With {Key .ID_NEGOCIOS = x.ID_NEGOCIOS}).Select(Function (y) New S5TAgricolaColheita With {
                                                                                                                                                                                                           .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                           .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList.FirstOrDefault()

        If objEntregaCanaAgrupadoPlanejadoTotal IsNot Nothing Then varEntregaCanaPlanejadoTotal = Math.Round(objEntregaCanaAgrupadoPlanejadoTotal.PLANEJADO, 0)

        Dim varFrentesEntregaCanaAgrupadas = GetAgricolaColheitaFrentes(parDadosColheita, TipoAgrupamento.Safra, FrentesIndicador.EntregaCana)

        Dim varFrentesDensidadeCargaAgrupadas = GetAgricolaColheitaFrentes(parDadosColheita, TipoAgrupamento.Safra, FrentesIndicador.DensidadeCarga)

        Dim objGraficoDensidadeCargaEscalaEixoY = GetAgricolaColheitaGraficoDensidadeCargaEixoY(varDadosDensidadeCargaAgrupado)

        GetAgricolaColheitaAgrupadoPorSafra = New S5TAgricolaColheitaAgrupadoPorSafra With {
                                                                                            .oGraficoEntregaCanaAcumulado = varDadosEntregaCanaAcumulado,
                                                                                            .oGraficoDensidadeCarga = varDadosDensidadeCargaAgrupado,
                                                                                            .graficoDensidadeCargaYMin = objGraficoDensidadeCargaEscalaEixoY.Min,
                                                                                            .graficoDensidadeCargaYMax = objGraficoDensidadeCargaEscalaEixoY.Max,
                                                                                            .graficoDensidadeCargaYInc = objGraficoDensidadeCargaEscalaEixoY.Inc,
                                                                                            .oGraficoImpurezaMineral = varDadosImpurezaMineralAgrupado,
                                                                                            .oGraficoImpurezaVegetal = varDadosImpurezaVegetalAgrupado,
                                                                                            .oGraficoVelocidadeMedia = varDadosVelocidadeMediaAgrupado,
                                                                                            .mesAtual = varMesAtual, 
                                                                                            .entregaAcumulada = varEntregaAcumuladaAtual,
                                                                                            .entregaPlanejadaAcumulada = varEntregaPlanejadaAcumuladaAtual,
                                                                                            .entregaPlanejadaTotal = varEntregaCanaPlanejadoTotal,
                                                                                            .media = varMediaPorMes,
                                                                                            .desvio = varDesvioPercentual,
                                                                                            .densidadeAtual = varDensidadeAtual,
                                                                                            .oFrentesEntregaCana = varFrentesEntregaCanaAgrupadas,
                                                                                            .oFrentesDensidadeCarga = varFrentesDensidadeCargaAgrupadas}
    End Function

    Public Function GetAgricolaColheitaEquipamentoPorSafraPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parFrente As Integer) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND FRENTE = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parFrente

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaEquipamentoPorSafraPorFrenteCorteDiaPlain(parIdNegocios As Integer, parSafra As Integer, parFrente As Integer, parDia As String) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND FRENTE = :p2 AND ID_INDICADOR NOT IN (30,32,33) UNION ALL " & 
            QueryAgricolaColheitaEquipamento & " AND ID_NEGOCIOS = :p3 AND SAFRA = :p4 AND FRENTE = :p5 AND DIA = :p6 AND ID_INDICADOR IN (30,32,33)",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parFrente

        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p4", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p5", OracleDbType.Int16).Value = parFrente
        cmdDadosColheita.Parameters.Add(":p6", OracleDbType.Date).Value = varDia

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function

    Private Function GetAgricolaColheitaEquipamentoAgrupadoPorSafra(parDadosColheita As List(Of S5TAgricolaColheitaEquipamento)) As S5TAgricolaColheitaEquipamentoAgrupado
        Dim varDadosColhedoraI29VelocidadeColheitaAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 29).GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                      Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                              .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                              .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                              .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI30EquipProdutivoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 30 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                          .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI31FaltaTratorAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 31).GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                               Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                       .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                       .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                       .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI32TempoAprovAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 32 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                              Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                      .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                      .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                      .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI33AprovDistanciaAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 33 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                          .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI49ProdutividadeAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 49).GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                 Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                         .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                         .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                         .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI30EquipProdutivoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 30 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                            Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                    .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                    .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                    .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI34FilaCarregamentoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 34).GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                              Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                      .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                      .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                      .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI35FaltaCaminhaoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 35).GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                           Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                                   .NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                   .META = Math.Round(y.Average(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                   .REALIZADO = Math.Round(y.Average(Function(group) group.REALIZADO), 2)}).ToList



        GetAgricolaColheitaEquipamentoAgrupadoPorSafra = New S5TAgricolaColheitaEquipamentoAgrupado With {
                                                                                            .oGraficoColhedoraI29 = varDadosColhedoraI29VelocidadeColheitaAgrupado,
                                                                                            .graficoColhedoraI29Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI29VelocidadeColheitaAgrupado),
                                                                                            .graficoColhedoraI29Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI29VelocidadeColheitaAgrupado),
                                                                                            .oGraficoColhedoraI30 = varDadosColhedoraI30EquipProdutivoAgrupado,
                                                                                            .graficoColhedoraI30Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI30EquipProdutivoAgrupado),
                                                                                            .graficoColhedoraI30Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI30EquipProdutivoAgrupado),
                                                                                            .oGraficoColhedoraI31 = varDadosColhedoraI31FaltaTratorAgrupado,
                                                                                            .graficoColhedoraI31Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI31FaltaTratorAgrupado),
                                                                                            .graficoColhedoraI31Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI31FaltaTratorAgrupado),
                                                                                            .oGraficoColhedoraI32 = varDadosColhedoraI32TempoAprovAgrupado,
                                                                                            .graficoColhedoraI32Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI32TempoAprovAgrupado),
                                                                                            .graficoColhedoraI32Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI32TempoAprovAgrupado),
                                                                                            .oGraficoColhedoraI33 = varDadosColhedoraI33AprovDistanciaAgrupado,
                                                                                            .graficoColhedoraI33Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI33AprovDistanciaAgrupado),
                                                                                            .graficoColhedoraI33Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI33AprovDistanciaAgrupado),
                                                                                            .oGraficoColhedoraI49 = varDadosColhedoraI49ProdutividadeAgrupado,
                                                                                            .graficoColhedoraI49Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI49ProdutividadeAgrupado),
                                                                                            .graficoColhedoraI49Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI49ProdutividadeAgrupado),
                                                                                            .oGraficoTratorI30 = varDadosTratorI30EquipProdutivoAgrupado,
                                                                                            .graficoTratorI30Media = GetEquipamentoIndicadorMedia(varDadosTratorI30EquipProdutivoAgrupado),
                                                                                            .graficoTratorI30Meta = GetEquipamentoIndicadorMeta(varDadosTratorI30EquipProdutivoAgrupado),
                                                                                            .oGraficoTratorI34 = varDadosTratorI34FilaCarregamentoAgrupado,
                                                                                            .graficoTratorI34Media = GetEquipamentoIndicadorMedia(varDadosTratorI34FilaCarregamentoAgrupado),
                                                                                            .graficoTratorI34Meta = GetEquipamentoIndicadorMeta(varDadosTratorI34FilaCarregamentoAgrupado),
                                                                                            .oGraficoTratorI35 = varDadosTratorI35FaltaCaminhaoAgrupado,
                                                                                            .graficoTratorI35Media = GetEquipamentoIndicadorMedia(varDadosTratorI35FaltaCaminhaoAgrupado),
                                                                                            .graficoTratorI35Meta = GetEquipamentoIndicadorMeta(varDadosTratorI35FaltaCaminhaoAgrupado)
                                                                                            }
    End Function


    Private Function GetEquipamentoIndicadorMeta(parDadosEquipamento As List(Of S5TAgricolaColheitaEquipamento)) As Double
        Dim varMeta As Double = 0

        If parDadosEquipamento.Count > 0 
            varMeta = Math.Round(parDadosEquipamento.Average(Function(x) x.META), 2)
        End If

        GetEquipamentoIndicadorMeta = varMeta
    End Function

    Private Function GetEquipamentoIndicadorMedia(parDadosEquipamento As List(Of S5TAgricolaColheitaEquipamento)) As Double
        Dim varMedia As Double = 0

        If parDadosEquipamento.Count > 0 Then
            varMedia = Math.Round(parDadosEquipamento.Average(Function(x) x.REALIZADO), 2)
        End If

        GetEquipamentoIndicadorMedia = varMedia
    End Function


    ' *** EQUIPAMENTO - NÍVEL 3
    ' *** POR DIA
    ' GET api/AgricolaColheita/PorDiaPorFrenteEquip/1/2017/20171017/2
    <HttpGet>
    <Route("PorDiaPorFrenteEquip/{parIdNegocios}/{parSafra}/{parDia}/{parFrente}")>
    Public Function GetValuesEquipPorDiaPorFrente(parIdNegocios As Integer, parSafra As Integer, parDia As String, parFrente As Integer) As IHttpActionResult
        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorDiaPorFrentePlain(parIdNegocios, parSafra, varDia, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaEquipamentoAgrupadoPorDia(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' *** POR SEMANA
    ' GET api/AgricolaColheita/PorSemanaPorFrenteEquip/1/2018/17/2
    <HttpGet>
    <Route("PorSemanaPorFrenteEquip/{parIdNegocios}/{parSafra}/{parSemana}/{parFrente}")>
    Public Function GetValuesEquipPorSemanaPorFrente(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parFrente As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorSemanaPorFrentePlain(parIdNegocios, parSafra, parSemana, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaEquipamentoAgrupadoPorSemana(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheita/PorSemanaPorFrenteEquipCorteDia/1/2018/23/1/20180607
    <HttpGet>
    <Route("PorSemanaPorFrenteEquipCorteDia/{parIdNegocios}/{parSafra}/{parSemana}/{parFrente}/{parDia}")>
    Public Function GetValuesEquipPorSemanaPorFrenteCorteDia(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parFrente As Integer, parDia As String) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorSemanaPorFrenteCorteDiaPlain(parIdNegocios, parSafra, parSemana, parFrente, parDia)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaEquipamentoAgrupadoPorSemana(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function


    ' *** POR MÊS
    ' GET api/AgricolaColheita/PorMesPorFrenteEquip/1/2018/4/2
    <HttpGet>
    <Route("PorMesPorFrenteEquip/{parIdNegocios}/{parSafra}/{parMes}/{parFrente}")>
    Public Function GetValuesEquipPorMesPorFrente(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parFrente As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorMesPorFrentePlain(parIdNegocios, parSafra, parMes, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaEquipamentoAgrupadoPorMes(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheita/PorMesPorFrenteEquipCorteDia/1/2018/6/1/20180607
    <HttpGet>
    <Route("PorMesPorFrenteEquipCorteDia/{parIdNegocios}/{parSafra}/{parMes}/{parFrente}/{parDia}")>
    Public Function GetValuesEquipPorMesPorFrenteCorteDia(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parFrente As Integer, parDia As String) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorMesPorFrenteCorteDiaPlain(parIdNegocios, parSafra, parMes, parFrente, parDia)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaEquipamentoAgrupadoPorMes(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function


    ' *** POR SAFRA
    ' GET api/AgricolaColheita/PorSafraPorFrenteEquip/1/2018/2
    <HttpGet>
    <Route("PorSafraPorFrenteEquip/{parIdNegocios}/{parSafra}/{parFrente}")>
    Public Function GetValuesEquipPorSafraPorFrente(parIdNegocios As Integer, parSafra As Integer, parFrente As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorSafraPorFrentePlain(parIdNegocios, parSafra, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaEquipamentoAgrupadoPorSafra(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheita/PorSafraPorFrenteEquipCorteDia/1/2018/1/20180607
    <HttpGet>
    <Route("PorSafraPorFrenteEquipCorteDia/{parIdNegocios}/{parSafra}/{parFrente}/{parDia}")>
    Public Function GetValuesEquipPorSafraPorFrenteCorteDia(parIdNegocios As Integer, parSafra As Integer, parFrente As Integer, parDia As String) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorSafraPorFrenteCorteDiaPlain(parIdNegocios, parSafra, parFrente, parDia)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaEquipamentoAgrupadoPorSafra(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function


    Private Enum TipoAgrupamento
        Dia
        Semana
        Mes
        Safra
    End Enum

    Private Enum FrentesIndicador
        EntregaCana
        DensidadeCarga
    End Enum

    Private Function GetObjAgricolaColheitaEntregaCanaFrentesMaisRecente(parDadosEntregaCana As List(Of S5TAgricolaColheita), parDadosEntregaCanaAcumulado As List(Of S5TAgricolaColheita)) As S5TAgricolaColheita
        Dim varUltimoIndice As Integer = 0

        For i = 0 To parDadosEntregaCana.Count - 1
            If parDadosEntregaCana(i).REALIZADO > 0 Then
                varUltimoIndice = i
            End If
        Next

        GetObjAgricolaColheitaEntregaCanaFrentesMaisRecente = parDadosEntregaCanaAcumulado(varUltimoIndice)
    End Function

    Private Function GetObjAgricolaColheitaDensidadeCargaFrentesMaisRecente(parDadosDensidadeCarga As List(Of S5TAgricolaColheita)) As S5TAgricolaColheita
        Dim varUltimoIndice As Integer = 0

        For i = 0 To parDadosDensidadeCarga.Count - 1
            If parDadosDensidadeCarga(i).REALIZADO > 0 Then
                varUltimoIndice = i
            End If
        Next

        GetObjAgricolaColheitaDensidadeCargaFrentesMaisRecente = parDadosDensidadeCarga(varUltimoIndice)
    End Function


    Private Function GetAgricolaColheitaFrentes(parDadosColheita As List(Of S5TAgricolaColheita), parTipoAgrupamento As TipoAgrupamento, parIndicador As FrentesIndicador) As List(Of S5TAgricolaColheitaFrentes)
        Dim varAgrupamentos = New List(Of S5TAgricolaColheitaFrentes)

        Dim varDadosColheita As List(Of S5TAgricolaColheita)

        If parIndicador = FrentesIndicador.EntregaCana Then
            varDadosColheita = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "")
        ElseIf parIndicador = FrentesIndicador.DensidadeCarga Then
            varDadosColheita = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26)
        End If

        Dim varDadosColheitaAgrupadoPorFrente = varDadosColheita.GroupBy(Function(x) New With {Key .FRENTE = x.FRENTE, _
                                                                                               Key .DESC_FRENTE = x.DESC_FRENTE}).Select(Function (y) New S5TAgricolaColheita With {.FRENTE = y.Min(Function(group) group.FRENTE), _
                                                                                                                                                                                .DESC_FRENTE = y.Min(Function(group) group.DESC_FRENTE)}).ToList

        Dim varDadosEntregaCanaAgrupado As List(Of S5TAgricolaColheita)
        Dim varDadosEntregaCanaAcumulado As List(Of S5TAgricolaColheita)
        Dim varDadosDensidadeCargaAgrupado As List(Of S5TAgricolaColheita)
        

        'Geral
        If parTipoAgrupamento = TipoAgrupamento.Dia Then
            varDadosEntregaCanaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                     Key .HORA = x.HORA}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                            .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                            .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                            .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

            varDadosEntregaCanaAgrupado = varDadosEntregaCanaAgrupado.OrderBy(Function(x) x.DIA).ThenBy(Function(x) x.HORA).ToList

            varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

            varDadosDensidadeCargaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                        Key .HORA = x.HORA}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                   .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                                   .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                   .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2)) }).ToList

            varDadosDensidadeCargaAgrupado = varDadosDensidadeCargaAgrupado.OrderBy(Function(x) x.DIA).ThenBy(Function(x) x.HORA).ToList
        ElseIf parTipoAgrupamento = TipoAgrupamento.Semana Then
            varDadosEntregaCanaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                               .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                               .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

            varDadosEntregaCanaAgrupado = varDadosEntregaCanaAgrupado.OrderBy(Function(x) x.DIA.Date).ToList

            varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

            varDadosDensidadeCargaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                  .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                  .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

            varDadosDensidadeCargaAgrupado = varDadosDensidadeCargaAgrupado.OrderBy(Function(x) x.DIA.Date).ToList
        ElseIf parTipoAgrupamento = TipoAgrupamento.Mes Then
            varDadosEntregaCanaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TAgricolaColheita With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

            varDadosEntregaCanaAgrupado = varDadosEntregaCanaAgrupado.OrderBy(Function(x) x.SEMANA).ToList

            varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

            varDadosDensidadeCargaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TAgricolaColheita With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                   .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                   .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList
            varDadosDensidadeCargaAgrupado = varDadosDensidadeCargaAgrupado.OrderBy(Function(x) x.SEMANA).ToList
        ElseIf parTipoAgrupamento = TipoAgrupamento.Safra
            varDadosEntregaCanaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TAgricolaColheita With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                          .DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                          .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

            varDadosEntregaCanaAgrupado = varDadosEntregaCanaAgrupado.OrderBy(Function(x) x.MES).ToList

            varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

            varDadosDensidadeCargaAgrupado = parDadosColheita.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TAgricolaColheita With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                                 .DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                 .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                 .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList
            varDadosDensidadeCargaAgrupado = varDadosDensidadeCargaAgrupado.OrderBy(Function(x) x.MES).ToList
        End If

        Dim varIndicadorMetaGeral As Integer

        If parIndicador = FrentesIndicador.EntregaCana 
            'varIndicadorMetaGeral = IIf(varDadosEntregaCanaAcumulado.LastOrDefault.REALIZADO >= varDadosEntregaCanaAcumulado.LastOrDefault.PLANEJADO, 0, 1)
            Dim objAgricolaColheitaEntregaCanaFrentesMaisRecente = GetObjAgricolaColheitaEntregaCanaFrentesMaisRecente(varDadosEntregaCanaAgrupado, varDadosEntregaCanaAcumulado)
            If objAgricolaColheitaEntregaCanaFrentesMaisRecente IsNot Nothing Then varIndicadorMetaGeral = IIf(objAgricolaColheitaEntregaCanaFrentesMaisRecente.REALIZADO >= objAgricolaColheitaEntregaCanaFrentesMaisRecente.PLANEJADO, 0, 1)
        ElseIf parIndicador = FrentesIndicador.DensidadeCarga Then
            'varIndicadorMetaGeral = IIf(varDadosDensidadeCargaAgrupado.LastOrDefault.REALIZADO >= varDadosDensidadeCargaAgrupado.LastOrDefault.PLANEJADO, 0, 1)
            Dim objAgricolaColheitaDensidadeCargaFrentesMaisRecente = GetObjAgricolaColheitaDensidadeCargaFrentesMaisRecente(varDadosDensidadeCargaAgrupado)
            If objAgricolaColheitaDensidadeCargaFrentesMaisRecente IsNot Nothing Then varIndicadorMetaGeral = IIf(objAgricolaColheitaDensidadeCargaFrentesMaisRecente.REALIZADO >= objAgricolaColheitaDensidadeCargaFrentesMaisRecente.PLANEJADO, 0, 1)
        End If

        varAgrupamentos.Add(New S5TAgricolaColheitaFrentes With {.frenteCodigo = 0,
                                                                 .frenteDescricao = "GERAL", 
                                                                 .indicadorMeta = varIndicadorMetaGeral})


        'Por Frentes
        Dim varDadosColheitaPorFrente As List(Of S5TAgricolaColheita)

        For Each objDadosColheitaAgrupadoPorFrente In varDadosColheitaAgrupadoPorFrente
            varDadosColheitaPorFrente = varDadosColheita.FindAll(Function(x) x.FRENTE = objDadosColheitaAgrupadoPorFrente.FRENTE)

            If parTipoAgrupamento = TipoAgrupamento.Dia 
                varDadosEntregaCanaAgrupado = varDadosColheitaPorFrente.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                  Key .HORA = x.HORA}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                         .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                                         .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                         .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

                varDadosEntregaCanaAgrupado = varDadosEntregaCanaAgrupado.OrderBy(Function(x) x.DIA).ThenBy(Function(x) x.HORA).ToList

                varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

                varDadosDensidadeCargaAgrupado = varDadosColheitaPorFrente.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                     Key .HORA = x.HORA}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                            .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                                            .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                            .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2)) }).ToList

                varDadosDensidadeCargaAgrupado = varDadosDensidadeCargaAgrupado.OrderBy(Function(x) x.DIA).ThenBy(Function(x) x.HORA).ToList
            ElseIf parTipoAgrupamento = TipoAgrupamento.Semana Then
                varDadosEntregaCanaAgrupado = varDadosColheitaPorFrente.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                           .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                           .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList


                varDadosEntregaCanaAgrupado = varDadosEntregaCanaAgrupado.OrderBy(Function(x) x.DIA.Date).ToList

                varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

                varDadosDensidadeCargaAgrupado = varDadosColheitaPorFrente.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TAgricolaColheita With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                              .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                              .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

                varDadosDensidadeCargaAgrupado = varDadosDensidadeCargaAgrupado.OrderBy(Function(x) x.DIA.Date).ToList
            ElseIf parTipoAgrupamento = TipoAgrupamento.Mes Then
                varDadosEntregaCanaAgrupado = varDadosColheitaPorFrente.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TAgricolaColheita With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                    .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                    .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

                varDadosEntregaCanaAgrupado = varDadosEntregaCanaAgrupado.OrderBy(Function(x) x.SEMANA).ToList

                varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

                varDadosDensidadeCargaAgrupado = varDadosColheitaPorFrente.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TAgricolaColheita With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                       .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                       .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList

                varDadosDensidadeCargaAgrupado = varDadosDensidadeCargaAgrupado.OrderBy(Function(x) x.SEMANA).ToList
            ElseIf parTipoAgrupamento = TipoAgrupamento.Safra
                varDadosEntregaCanaAgrupado = varDadosColheitaPorFrente.FindAll(Function(x) x.ID_CA_INDICADOR = 24 And x.HORA <> "").GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TAgricolaColheita With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                              .DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                              .PLANEJADO = Math.Round(y.Sum(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                              .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

                varDadosEntregaCanaAgrupado = varDadosEntregaCanaAgrupado.OrderBy(Function(x) x.MES).ToList

                varDadosEntregaCanaAcumulado = GetAgricolaColheitaAcumulado(varDadosEntregaCanaAgrupado)

                varDadosDensidadeCargaAgrupado = varDadosColheitaPorFrente.FindAll(Function(x) x.ID_CA_INDICADOR = 26).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TAgricolaColheita With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                                     .DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                     .PLANEJADO = Math.Round(y.Average(Function(group) group.PLANEJADO), 2), _
                                                                                                                                                                                                                     .REALIZADO = IIf(Math.Round(y.Sum(Function(group) group.CN_ENT_INDICADOR),0) = 0, 0, Math.Round(y.Sum(Function(group) group.REALIZADO * group.CN_ENT_INDICADOR) / y.Sum(Function(group) group.CN_ENT_INDICADOR) , 2))}).ToList
                varDadosDensidadeCargaAgrupado = varDadosDensidadeCargaAgrupado.OrderBy(Function(x) x.MES).ToList
            End If

            Dim varIndicadorMeta As Integer

            If parIndicador = FrentesIndicador.EntregaCana 
                Dim objAgricolaColheitaEntregaCanaFrentesMaisRecente = GetObjAgricolaColheitaEntregaCanaFrentesMaisRecente(varDadosEntregaCanaAgrupado, varDadosEntregaCanaAcumulado)
                If objAgricolaColheitaEntregaCanaFrentesMaisRecente IsNot Nothing Then varIndicadorMeta = IIf(objAgricolaColheitaEntregaCanaFrentesMaisRecente.REALIZADO >= objAgricolaColheitaEntregaCanaFrentesMaisRecente.PLANEJADO, 0, 1)
            ElseIf parIndicador = FrentesIndicador.DensidadeCarga Then
                Dim objAgricolaColheitaDensidadeCargaFrentesMaisRecente = GetObjAgricolaColheitaDensidadeCargaFrentesMaisRecente(varDadosDensidadeCargaAgrupado)
                If objAgricolaColheitaDensidadeCargaFrentesMaisRecente IsNot Nothing Then varIndicadorMeta = IIf(objAgricolaColheitaDensidadeCargaFrentesMaisRecente.REALIZADO >= objAgricolaColheitaDensidadeCargaFrentesMaisRecente.PLANEJADO, 0, 1)
            End If

            varAgrupamentos.Add(New S5TAgricolaColheitaFrentes With {.frenteCodigo = objDadosColheitaAgrupadoPorFrente.FRENTE,
                                                                     .frenteDescricao = GetDescricaoAbreviadaFrente(objDadosColheitaAgrupadoPorFrente.DESC_FRENTE), 
                                                                     .indicadorMeta = varIndicadorMeta})
        Next

        GetAgricolaColheitaFrentes = varAgrupamentos.OrderBy(Function(x) x.FrenteDescricao).ToList
    End Function

    Private Function GetDescricaoAbreviadaFrente(parFrenteDescricao As String) As String
       varFrenteDescricao = parFrenteDescricao.Replace("-","")

        GetDescricaoAbreviadaFrente = varFrenteDescricao
    End Function

    Private Function GetDadosColheita(parConnection As OracleConnection, parCommand As OracleCommand) As List(Of S5TAgricolaColheita)
        Dim dadosColheita As New List(Of S5TAgricolaColheita)

        parConnection.Open()

        Dim drDadosColheita As OracleDataReader = Nothing
        Try
            drDadosColheita = parCommand.ExecuteReader()
            If drDadosColheita.HasRows Then
                Do While drDadosColheita.Read
                    Dim objDadosColheita = New S5TAgricolaColheita

                    objDadosColheita.ID_NEGOCIOS = AppUtils.Nvl(drDadosColheita.Item("ID_NEGOCIOS"), 0)
                    objDadosColheita.SAFRA = AppUtils.Nvl(drDadosColheita.Item("SAFRA"), 0)
                    objDadosColheita.MES = AppUtils.Nvl(drDadosColheita.Item("MES"), 0)
                    objDadosColheita.SEMANA = AppUtils.Nvl(drDadosColheita.Item("SEMANA"), 0)
                    objDadosColheita.DIA = Nvl(drDadosColheita.Item("DIA"), DateTime.MinValue)
                    If AppUtils.Nvl(drDadosColheita.Item("HORA"), "") <> "" Then
                        objDadosColheita.DIA = objDadosColheita.DIA.AddHours(Convert.ToInt16(AppUtils.Nvl(drDadosColheita.Item("HORA").ToString().Substring(0, 2), "")))
                    End If
                    objDadosColheita.HORA = AppUtils.Nvl(drDadosColheita.Item("HORA"), "")
                    objDadosColheita.FRENTE = AppUtils.Nvl(drDadosColheita.Item("FRENTE"), 0)
                    objDadosColheita.DESC_FRENTE = AppUtils.Nvl(drDadosColheita.Item("DESC_FRENTE"), "")
                    objDadosColheita.ID_CA_INDICADOR = AppUtils.Nvl(drDadosColheita.Item("ID_CA_INDICADOR"), 0)
                    objDadosColheita.DS_CA_INDICADOR = AppUtils.Nvl(drDadosColheita.Item("DS_CA_INDICADOR"), "")
                    objDadosColheita.PLANEJADO = AppUtils.Nvl(drDadosColheita.Item("PLANEJADO"), 0)
                    objDadosColheita.REALIZADO = AppUtils.Nvl(drDadosColheita.Item("REALIZADO"), 0)
                    objDadosColheita.CN_ENT_INDICADOR = AppUtils.Nvl(drDadosColheita.Item("CN_ENT_INDICADOR"), 0)
                    objDadosColheita.TIPO_PLANEJAMENTO = AppUtils.Nvl(drDadosColheita.Item("TIPO_PLANEJAMENTO"), "")

                    dadosColheita.Add(objDadosColheita)
                Loop

                drDadosColheita.Close()
            End If
        Catch ex As Exception
            Return Nothing 'InternalServerError(ex)
        Finally
            parConnection.Close()
            If (Not (drDadosColheita) Is Nothing) Then
                drDadosColheita.Dispose()
            End If
        End Try

        GetDadosColheita = dadosColheita
    End Function

    Private Function GetAgricolaColheitaAcumulado(parAgricolaColheita As List(Of S5TAgricolaColheita)) As List(Of S5TAgricolaColheita)
        Dim parAgricolaColheitaOrdenado = parAgricolaColheita.OrderBy(Function(x) x.MES).ThenBy(Function(x) x.SEMANA).ThenBy(Function(x) x.DIA).ThenBy(Function(x) x.HORA)

        Dim varAgricolaColheitaAcumulado = New List(Of S5TAgricolaColheita)

        Dim varPlanejadoAcumulado As Double = 0
        Dim varRealizadoAcumulado As Double = 0

        For Each objAgricolaColheita In parAgricolaColheitaOrdenado
            varPlanejadoAcumulado += Math.Round(objAgricolaColheita.PLANEJADO,0)
            varRealizadoAcumulado += Math.Round(objAgricolaColheita.REALIZADO,0)

            varAgricolaColheitaAcumulado.Add(New S5TAgricolaColheita With {
                                                .ID_NEGOCIOS = objAgricolaColheita.ID_NEGOCIOS,
                                                .SAFRA = objAgricolaColheita.SAFRA,
                                                .MES = objAgricolaColheita.MES,
                                                .SEMANA = objAgricolaColheita.SEMANA,
                                                .semanaPeriodo = objAgricolaColheita.semanaPeriodo,
                                                .DIA = objAgricolaColheita.DIA,
                                                .HORA = objAgricolaColheita.HORA,
                                                .ID_CA_INDICADOR = objAgricolaColheita.ID_CA_INDICADOR,
                                                .DS_CA_INDICADOR = objAgricolaColheita.DS_CA_INDICADOR,
                                                .FRENTE = objAgricolaColheita.FRENTE,
                                                .DESC_FRENTE = objAgricolaColheita.DESC_FRENTE,
                                                .PLANEJADO = varPlanejadoAcumulado,
                                                .REALIZADO = varRealizadoAcumulado
                                            })
        Next

        GetAgricolaColheitaAcumulado = varAgricolaColheitaAcumulado
    End Function


    Private Function GetDadosColheitaEquipamento(parConnection As OracleConnection, parCommand As OracleCommand) As List(Of S5TAgricolaColheitaEquipamento)
        Dim dadosColheita As New List(Of S5TAgricolaColheitaEquipamento)

        parConnection.Open()

        Dim drDadosColheita As OracleDataReader = Nothing
        Try
            drDadosColheita = parCommand.ExecuteReader()
            If drDadosColheita.HasRows Then
                Do While drDadosColheita.Read
                    Dim objDadosColheita = New S5TAgricolaColheitaEquipamento

                    objDadosColheita.ID_NEGOCIOS = AppUtils.Nvl(drDadosColheita.Item("ID_NEGOCIOS"), 0)
                    objDadosColheita.SAFRA = AppUtils.Nvl(drDadosColheita.Item("SAFRA"), 0)
                    objDadosColheita.MES = AppUtils.Nvl(drDadosColheita.Item("MES"), 0)
                    objDadosColheita.SEMANA = AppUtils.Nvl(drDadosColheita.Item("SEMANA"), 0)
                    objDadosColheita.DIA = Nvl(drDadosColheita.Item("DIA"), DateTime.MinValue)
                    objDadosColheita.FRENTE = AppUtils.Nvl(drDadosColheita.Item("FRENTE"), 0)
                    objDadosColheita.DESC_FRENTE = AppUtils.Nvl(drDadosColheita.Item("DESC_FRENTE"), "")
                    objDadosColheita.CLASSE_EQUIP = AppUtils.Nvl(drDadosColheita.Item("CLASSE_EQUIP"), "")
                    objDadosColheita.NRO_EQUIPAMENTO = AppUtils.Nvl(drDadosColheita.Item("NRO_EQUIPAMENTO"), 0)
                    objDadosColheita.ID_INDICADOR = AppUtils.Nvl(drDadosColheita.Item("ID_INDICADOR"), 0)
                    objDadosColheita.DSC_INDICADOR = AppUtils.Nvl(drDadosColheita.Item("DSC_INDICADOR"), "")
                    objDadosColheita.META = AppUtils.Nvl(drDadosColheita.Item("META"), 0)
                    objDadosColheita.REALIZADO = AppUtils.Nvl(drDadosColheita.Item("REALIZADO"), 0)
                    objDadosColheita.TIPO_PLANEJAMENTO = AppUtils.Nvl(drDadosColheita.Item("TIPO_PLANEJAMENTO"), "")

                    dadosColheita.Add(objDadosColheita)
                Loop

                drDadosColheita.Close()
            End If
        Catch ex As Exception
            'Return InternalServerError(ex)
        Finally
            parConnection.Close()
            If (Not (drDadosColheita) Is Nothing) Then
                drDadosColheita.Dispose()
            End If
        End Try

        GetDadosColheitaEquipamento = dadosColheita
    End Function


        ' GET: api/AgricolaColheita
        Public Function GetValues() As IEnumerable(Of String)
            Return New String() {"value1", "value2"}
        End Function

        ' GET: api/AgricolaColheita/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/AgricolaColheita
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/AgricolaColheita/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/AgricolaColheita/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
