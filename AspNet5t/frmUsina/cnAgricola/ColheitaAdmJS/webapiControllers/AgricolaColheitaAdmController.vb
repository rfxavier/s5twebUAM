Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Web.Http
Imports Oracle.DataAccess.Client

<RoutePrefix("api/AgricolaColheitaAdm")>
    Public Class AgricolaColheitaAdmController
        Inherits ApiController
    Private Property QueryAgricolaColheitaAdm As String = "SELECT FRENTE, DESC_FRENTE FROM BI4T.INDICADORES_COLHEITA_EQUIP WHERE TIPO_INDICADOR = 'A' {0} GROUP BY FRENTE, DESC_FRENTE ORDER BY DESC_FRENTE"
    Private Property QueryAgricolaColheitaAdmEquipamento As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, FRENTE, DESC_FRENTE, CLASSE_EQUIP, NRO_EQUIPAMENTO, ID_INDICADOR, DSC_INDICADOR, META, REALIZADO, TIPO_PLANEJAMENTO, DS_OBS FROM BI4T.INDICADORES_COLHEITA_EQUIP WHERE TIPO_INDICADOR = 'A'"


    <DataContract>
    Public Class S5TAgricolaColheitaAdmFrentes
        <DataMember>
        Public Property frenteCodigo As Integer
        <DataMember>
        Public Property frenteDescricao As String
        <DataMember>
        Public Property indicadorMeta As Integer
    End Class

    <DataContract>
    Public Class S5TAgricolaColheitaAgrupadoPorSemana
        <DataMember>
        Public Property diaAtual As Date
        <DataMember>
        Public Property oFrentes As List(Of S5TAgricolaColheitaAdmFrentes)
    End Class

    <DataContract>
    Public Class S5TAgricolaColheitaAgrupadoPorMes
        <DataMember>
        Public Property semanaAtual As Integer
        <DataMember>
        Public Property oFrentes As List(Of S5TAgricolaColheitaAdmFrentes)
    End Class

    <DataContract>
    Public Class S5TAgricolaColheitaAgrupadoPorSafra
        <DataMember>
        Public Property mesAtual As Integer
        <DataMember>
        Public Property oFrentes As List(Of S5TAgricolaColheitaAdmFrentes)
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
        <DataMember>
        Public Property DS_OBS As String
    End Class

    <DataContract>
    Public Class S5TAgricolaColheitaAdmEquipamentoAgrupado
        <DataMember>
        Public Property oGraficoColhedoraI38 As List(Of S5TAgricolaColheitaEquipamento) 'MOTOR OCIOSO
        <DataMember>
        Public Property graficoColhedoraI38Media As Double
        <DataMember>
        Public Property graficoColhedoraI38Meta As Double


        <DataMember>
        Public Property oGraficoColhedoraI39 As List(Of S5TAgricolaColheitaEquipamento) 'PILOTO AUTOMÁTICO COLHEDORAS
        <DataMember>
        Public Property graficoColhedoraI39Media As Double
        <DataMember>
        Public Property graficoColhedoraI39Meta As Double


        <DataMember>
        Public Property oGraficoColhedoraI40 As List(Of S5TAgricolaColheitaEquipamento) 'CONSUMO ÓLEO HIDRÁULICO
        <DataMember>
        Public Property graficoColhedoraI40Media As Double
        <DataMember>
        Public Property graficoColhedoraI40Meta As Double


        <DataMember>
        Public Property oGraficoColhedoraI41 As List(Of S5TAgricolaColheitaEquipamento) 'CONSUMO ÓLEO DIESEL
        <DataMember>
        Public Property graficoColhedoraI41Media As Double
        <DataMember>
        Public Property graficoColhedoraI41Meta As Double


        <DataMember>
        Public Property oGraficoColhedoraI42 As List(Of S5TAgricolaColheitaEquipamento) 'COLHEITABILIDADE
        <DataMember>
        Public Property graficoColhedoraI42Media As Double
        <DataMember>
        Public Property graficoColhedoraI42Meta As Double


        <DataMember>
        Public Property oGraficoTratorI38 As List(Of S5TAgricolaColheitaEquipamento) 'MOTOR OCIOSO
        <DataMember>
        Public Property graficoTratorI38Media As Double
        <DataMember>
        Public Property graficoTratorI38Meta As Double


        <DataMember>
        Public Property oGraficoTratorI41 As List(Of S5TAgricolaColheitaEquipamento) 'CONSUMO ÓLEO DIESEL
        <DataMember>
        Public Property graficoTratorI41Media As Double
        <DataMember>
        Public Property graficoTratorI41Meta As Double


        <DataMember>
        Public Property oGraficoCanavieiroI41 As List(Of S5TAgricolaColheitaEquipamento) 'CONSUMO ÓLEO DIESEL
        <DataMember>
        Public Property graficoCanavieiroI41Media As Double
        <DataMember>
        Public Property graficoCanavieiroI41Meta As Double


        <DataMember>
        Public Property oGraficoEscravoI41 As List(Of S5TAgricolaColheitaEquipamento) 'CONSUMO ÓLEO DIESEL
        <DataMember>
        Public Property graficoEscravoI41Media As Double
        <DataMember>
        Public Property graficoEscravoI41Meta As Double


        <DataMember>
        Public Property oGraficoCaminhaoI36 As List(Of S5TAgricolaColheitaEquipamento) 'QUANTIDADE CAMINHÕES FRENTE
        <DataMember>
        Public Property graficoCaminhaoI36Media As Double
        <DataMember>
        Public Property graficoCaminhaoI36Meta As Double


        <DataMember>
        Public Property oGraficoCaminhaoI37 As List(Of S5TAgricolaColheitaEquipamento) 'TEMPO MÉDIO PERMANÊNCIA FRENTE
        <DataMember>
        Public Property graficoCaminhaoI37Media As Double
        <DataMember>
        Public Property graficoCaminhaoI37Meta As Double


        <DataMember>
        Public Property oGraficoColhedoraI48 As List(Of S5TAgricolaColheitaEquipamento) 'EQUIPAMENTOS ONLINE
        <DataMember>
        Public Property graficoColhedoraI48Media As Double
        <DataMember>
        Public Property graficoColhedoraI48Meta As Double


        <DataMember>
        Public Property textoColhedoraI43 As String 'COLHEDORAS COM APONT.PRODUTIVO EM TALHÕES NÃO LIB.
        <DataMember>
        Public Property textoColhedoraI44 As String 'PROPRIEDADE COM PROJETO SEM ATIVIAÇÃO ES
        <DataMember>
        Public Property textoColhedoraI45 As String 'EQUIPAMENTO SEM IMPLEMENTO
    End Class


    ' GET api/AgricolaColheitaAdm/VisaoGeralMinMaxDia/1
    <HttpGet>
    <Route("VisaoGeralMinMaxDia/{parIdNegocios}")>
    Public Function GetValuesMaxDia(parIdNegocios As Integer) As IHttpActionResult
        Return Ok(GetAgricolaColheitaAdmPorSafraMinMaxDia(parIdNegocios))
    End Function

    Public Function GetAgricolaColheitaAdmPorSafraMinMaxDia(parIdNegocios As Integer) As Object
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosMoagem As New OracleCommand(
            "SELECT MAX(SAFRA) SAFRA, MIN(DIA) MINDIA, MAX(DIA) MAXDIA, MIN(SEMANA) MINSEMANA, MAX(SEMANA) MAXSEMANA, MIN(MES) MINMES, MAX(MES) MAXMES FROM BI4T.INDICADORES_COLHEITA_EQUIP WHERE TIPO_INDICADOR = 'A' AND ID_NEGOCIOS = :p0",
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

        GetAgricolaColheitaAdmPorSafraMinMaxDia = New With {Key .safra = varSafra, 
                                                         Key .minDia = varMinDia, 
                                                         Key .maxDia = varMaxDia, 
                                                         Key .minSemana = varMinSemana, 
                                                         Key .maxSemana = varMaxSemana, 
                                                         Key .minMes = varMinMes, 
                                                         Key .maxMes = varMaxMes}
    End Function


    ' GET api/AgricolaColheitaAdm/VisaoGeralMinMaxCorteDia/1/20180510
    <HttpGet>
    <Route("VisaoGeralMinMaxCorteDia/{parIdNegocios}/{parDia}")>
    Public Function GetValuesMaxCorteDia(parIdNegocios As Integer, parDia As String) As IHttpActionResult
        Return Ok(GetAgricolaColheitaPorSafraMinMaxCorteDia(parIdNegocios, parDia))
    End Function

    Public Function GetAgricolaColheitaPorSafraMinMaxCorteDia(parIdNegocios As Integer, parDia As String) As Object
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDadosMoagem As New OracleCommand(
            "SELECT MAX(SAFRA) SAFRA, MIN(DIA) MINDIA, MAX(DIA) MAXDIA, MIN(SEMANA) MINSEMANA, MAX(SEMANA) MAXSEMANA, MIN(MES) MINMES, MAX(MES) MAXMES FROM BI4T.INDICADORES_COLHEITA_EQUIP WHERE TIPO_INDICADOR = 'A' AND ID_NEGOCIOS = :p0 AND DIA <= :p2",
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
    Public Function GetAgricolaColheitaEquipamentoPorDiaPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parDia As DateTime, parFrente As Integer) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaAdmEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA = :p2 AND FRENTE = :p3",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Date).Value = parDia
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function

    Private Function GetAgricolaColheitaAdmEquipamentoAgrupadoPorDia(parDadosColheita As List(Of S5TAgricolaColheitaEquipamento)) As S5TAgricolaColheitaAdmEquipamentoAgrupado
        Dim varDadosCaminhaoI36QuantidadeFrenteAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "CAMINHAO" And x.ID_INDICADOR = 36 And x.TIPO_PLANEJAMENTO = "D").GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                                                                Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                        .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                        .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosCaminhaoI37TempoMedioPermFrenteAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "CAMINHAO" And x.ID_INDICADOR = 37 And x.TIPO_PLANEJAMENTO = "D").GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                                                                    Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                            .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                            .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI48EquipamentosOnlineAgrupado = parDadosColheita.FindAll(Function(x) x.ID_INDICADOR = 48 And x.TIPO_PLANEJAMENTO = "D").GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                                   Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                           .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                           .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI43ColhedorasSemTalhaoLib = parDadosColheita.FirstOrDefault(Function(x) x.ID_INDICADOR = 43 And x.TIPO_PLANEJAMENTO = "D")
        Dim varDadosColhedoraI44PropriedadeSemAtivacaoES = parDadosColheita.FirstOrDefault(Function(x) x.ID_INDICADOR = 44 And x.TIPO_PLANEJAMENTO = "D")
        Dim varDadosColhedoraI45EquipSemImplemento = parDadosColheita.FirstOrDefault(Function(x) x.ID_INDICADOR = 45 And x.TIPO_PLANEJAMENTO = "D")

        Dim varTextoI43ColhedorasSemTalhaoLib = If(varDadosColhedoraI43ColhedorasSemTalhaoLib IsNot Nothing, varDadosColhedoraI43ColhedorasSemTalhaoLib.DS_OBS, "")
        Dim varTextoI44PropriedadeSemAtivacaoES = If(varDadosColhedoraI44PropriedadeSemAtivacaoES IsNot Nothing, varDadosColhedoraI44PropriedadeSemAtivacaoES.DS_OBS, "")
        Dim varTextoI45EquipSemImplemento = If(varDadosColhedoraI45EquipSemImplemento IsNot Nothing, varDadosColhedoraI45EquipSemImplemento.DS_OBS, "")

        GetAgricolaColheitaAdmEquipamentoAgrupadoPorDia = New S5TAgricolaColheitaAdmEquipamentoAgrupado With {
                                                                                            .oGraficoCaminhaoI36 = varDadosCaminhaoI36QuantidadeFrenteAgrupado,
                                                                                            .graficoCaminhaoI36Media = GetEquipamentoIndicadorMedia(varDadosCaminhaoI36QuantidadeFrenteAgrupado),
                                                                                            .graficoCaminhaoI36Meta = GetEquipamentoIndicadorMeta(varDadosCaminhaoI36QuantidadeFrenteAgrupado),
                                                                                            .oGraficoCaminhaoI37 = varDadosCaminhaoI37TempoMedioPermFrenteAgrupado,
                                                                                            .graficoCaminhaoI37Media = GetEquipamentoIndicadorMedia(varDadosCaminhaoI37TempoMedioPermFrenteAgrupado),
                                                                                            .graficoCaminhaoI37Meta = GetEquipamentoIndicadorMeta(varDadosCaminhaoI37TempoMedioPermFrenteAgrupado),
                                                                                            .oGraficoColhedoraI48 = varDadosColhedoraI48EquipamentosOnlineAgrupado,
                                                                                            .graficoColhedoraI48Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI48EquipamentosOnlineAgrupado),
                                                                                            .graficoColhedoraI48Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI48EquipamentosOnlineAgrupado),
                                                                                            .textoColhedoraI43 = varTextoI43ColhedorasSemTalhaoLib,
                                                                                            .textoColhedoraI44 = varTextoI44PropriedadeSemAtivacaoES,
                                                                                            .textoColhedoraI45 = varTextoI45EquipSemImplemento
                                                                                            }
    End Function


    ' *** POR SEMANA
    ' GET api/AgricolaColheitaAdm/PorSemana/1/2018/15
    <HttpGet>
    <Route("PorSemana/{parIdNegocios}/{parSafra}/{parSemana}")>
    Public Function GetValuesPorSemana(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorSemanaPlain(parIdNegocios, parSafra, parSemana)

        Dim dadosColheitaAgrupado = New S5TAgricolaColheitaAgrupadoPorSemana With {.oFrentes = dadosColheita}

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheitaAdm/PorSemanaCorteDia/1/2018/15/20180505
    <HttpGet>
    <Route("PorSemanaCorteDia/{parIdNegocios}/{parSafra}/{parSemana}/{parDia}")>
    Public Function GetValuesPorSemanaCorteDia(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parDia As String) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorSemanaCorteDiaPlain(parIdNegocios, parSafra, parSemana, parDia)

        Dim dadosColheitaAgrupado = New S5TAgricolaColheitaAgrupadoPorSemana With {.oFrentes = dadosColheita}

        Return Ok(dadosColheitaAgrupado)
    End Function


    Public Function GetAgricolaColheitaPorSemanaPlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As List(Of S5TAgricolaColheitaAdmFrentes)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            String.Format(QueryAgricolaColheitaAdm, "AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2"),
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana

        Return GetDadosColheitaFrentes(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaPorSemanaCorteDiaPlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parDia As String) As List(Of S5TAgricolaColheitaAdmFrentes)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDadosColheita As New OracleCommand(
            String.Format(QueryAgricolaColheitaAdm, "AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2 AND DIA <= :p3"),
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Date).Value = varDia

        Return GetDadosColheitaFrentes(conn, cmdDadosColheita)
    End Function


    Public Function GetAgricolaColheitaEquipamentoPorSemanaPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parFrente As Integer) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaAdmEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2 AND FRENTE = :p3",
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
            QueryAgricolaColheitaAdmEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2 AND FRENTE = :p3 AND DIA = :p4",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente
        cmdDadosColheita.Parameters.Add(":p4", OracleDbType.Date).Value = varDia

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function


    Private Function GetAgricolaColheitaAdmEquipamentoAgrupadoPorSemana(parDadosColheita As List(Of S5TAgricolaColheitaEquipamento)) As S5TAgricolaColheitaAdmEquipamentoAgrupado
        Dim varDadosColhedoraI38MotorOciosoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 38 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                                             Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                     .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                     .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI39PilotoAutomaticoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 39 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 40 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                                                       Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                               .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                               .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                                                   Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                           .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                           .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI42ColheitabilidadeAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 42 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI38MotorOciosoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 38 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                                       Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                               .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                               .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                                             Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                     .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                     .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosCanavieiroI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "CANAVIEIRO" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                                                 Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                         .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                         .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosEscravoI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "ESCRAVO" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "S").GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA, _
                                                                                                                                                                                                              Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                      .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                      .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        GetAgricolaColheitaAdmEquipamentoAgrupadoPorSemana = New S5TAgricolaColheitaAdmEquipamentoAgrupado With {
                                                                                            .oGraficoColhedoraI38 = varDadosColhedoraI38MotorOciosoAgrupado,
                                                                                            .graficoColhedoraI38Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI38MotorOciosoAgrupado),
                                                                                            .graficoColhedoraI38Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI38MotorOciosoAgrupado),
                                                                                            .oGraficoColhedoraI39 = varDadosColhedoraI39PilotoAutomaticoAgrupado,
                                                                                            .graficoColhedoraI39Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI39PilotoAutomaticoAgrupado),
                                                                                            .graficoColhedoraI39Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI39PilotoAutomaticoAgrupado),
                                                                                            .oGraficoColhedoraI40 = varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado,
                                                                                            .graficoColhedoraI40Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado),
                                                                                            .graficoColhedoraI40Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado),
                                                                                            .oGraficoColhedoraI41 = varDadosColhedoraI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoColhedoraI41Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoColhedoraI41Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI41ConsumoOleoDieselAgrupado),
                                                                                            .oGraficoColhedoraI42 = varDadosColhedoraI42ColheitabilidadeAgrupado,
                                                                                            .graficoColhedoraI42Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI42ColheitabilidadeAgrupado),
                                                                                            .graficoColhedoraI42Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI42ColheitabilidadeAgrupado),
                                                                                            .oGraficoTratorI38 = varDadosTratorI38MotorOciosoAgrupado,
                                                                                            .graficoTratorI38Media = GetEquipamentoIndicadorMedia(varDadosTratorI38MotorOciosoAgrupado),
                                                                                            .graficoTratorI38Meta = GetEquipamentoIndicadorMeta(varDadosTratorI38MotorOciosoAgrupado),
                                                                                            .oGraficoTratorI41 = varDadosTratorI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoTratorI41Media = GetEquipamentoIndicadorMedia(varDadosTratorI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoTratorI41Meta = GetEquipamentoIndicadorMeta(varDadosTratorI41ConsumoOleoDieselAgrupado),
                                                                                            .oGraficoCanavieiroI41 = varDadosCanavieiroI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoCanavieiroI41Media = GetEquipamentoIndicadorMedia(varDadosCanavieiroI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoCanavieiroI41Meta = GetEquipamentoIndicadorMeta(varDadosCanavieiroI41ConsumoOleoDieselAgrupado),
                                                                                            .oGraficoEscravoI41 = varDadosEscravoI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoEscravoI41Media = GetEquipamentoIndicadorMedia(varDadosEscravoI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoEscravoI41Meta = GetEquipamentoIndicadorMeta(varDadosEscravoI41ConsumoOleoDieselAgrupado)
                                                                                            }
    End Function


    ' *** POR MÊS
    ' GET api/AgricolaColheitaAdm/PorMes/1/2018/5
    <HttpGet>
    <Route("PorMes/{parIdNegocios}/{parSafra}/{parMes}")>
    Public Function GetValuesPorMes(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorMesPlain(parIdNegocios, parSafra, parMes)

        Dim dadosColheitaAgrupado = New S5TAgricolaColheitaAgrupadoPorMes With {.oFrentes = dadosColheita}

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheitaAdm/PorMesCorteDia/1/2018/5/20180505
    <HttpGet>
    <Route("PorMesCorteDia/{parIdNegocios}/{parSafra}/{parMes}/{parDia}")>
    Public Function GetValuesPorMesCorteDia(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parDia As String) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorMesCorteDiaPlain(parIdNegocios, parSafra, parMes, parDia)

        Dim dadosColheitaAgrupado = New S5TAgricolaColheitaAgrupadoPorMes With {.oFrentes = dadosColheita}

        Return Ok(dadosColheitaAgrupado)
    End Function


    Public Function GetAgricolaColheitaPorMesPlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As List(Of S5TAgricolaColheitaAdmFrentes)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            String.Format(QueryAgricolaColheitaAdm, "AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2"),
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parMes

        Return GetDadosColheitaFrentes(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaPorMesCorteDiaPlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parDia As String) As List(Of S5TAgricolaColheitaAdmFrentes)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDadosColheita As New OracleCommand(
            String.Format(QueryAgricolaColheitaAdm, "AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2 AND DIA <= :p3"),
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parMes
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Date).Value = varDia

        Return GetDadosColheitaFrentes(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaEquipamentoPorMesPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parFrente As Integer) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaAdmEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2 AND FRENTE = :p3",
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
            QueryAgricolaColheitaAdmEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2 AND FRENTE = :p3 AND DIA = :p4",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parMes
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Int16).Value = parFrente
        cmdDadosColheita.Parameters.Add(":p4", OracleDbType.Date).Value = varDia

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function


    Private Function GetAgricolaColheitaAdmEquipamentoAgrupadoPorMes(parDadosColheita As List(Of S5TAgricolaColheitaEquipamento)) As S5TAgricolaColheitaAdmEquipamentoAgrupado
        Dim varDadosColhedoraI38MotorOciosoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 38 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                                             Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                     .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                     .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI39PilotoAutomaticoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 39 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 40 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                                                       Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                               .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                               .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                                                   Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                           .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                           .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI42ColheitabilidadeAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 42 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI38MotorOciosoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 38 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                                       Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                               .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                               .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                                             Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                     .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                     .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosCanavieiroI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "CANAVIEIRO" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                                                     Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                             .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                             .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosEscravoI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "ESCRAVO" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "M").GroupBy(Function(x) New With {Key .MES = x.MES, _
                                                                                                                                                                                                               Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                       .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                       .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        GetAgricolaColheitaAdmEquipamentoAgrupadoPorMes = New S5TAgricolaColheitaAdmEquipamentoAgrupado With {
                                                                                            .oGraficoColhedoraI38 = varDadosColhedoraI38MotorOciosoAgrupado,
                                                                                            .graficoColhedoraI38Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI38MotorOciosoAgrupado),
                                                                                            .graficoColhedoraI38Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI38MotorOciosoAgrupado),
                                                                                            .oGraficoColhedoraI39 = varDadosColhedoraI39PilotoAutomaticoAgrupado,
                                                                                            .graficoColhedoraI39Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI39PilotoAutomaticoAgrupado),
                                                                                            .graficoColhedoraI39Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI39PilotoAutomaticoAgrupado),
                                                                                            .oGraficoColhedoraI40 = varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado,
                                                                                            .graficoColhedoraI40Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado),
                                                                                            .graficoColhedoraI40Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado),
                                                                                            .oGraficoColhedoraI41 = varDadosColhedoraI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoColhedoraI41Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoColhedoraI41Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI41ConsumoOleoDieselAgrupado),
                                                                                            .oGraficoColhedoraI42 = varDadosColhedoraI42ColheitabilidadeAgrupado,
                                                                                            .graficoColhedoraI42Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI42ColheitabilidadeAgrupado),
                                                                                            .graficoColhedoraI42Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI42ColheitabilidadeAgrupado),
                                                                                            .oGraficoTratorI38 = varDadosTratorI38MotorOciosoAgrupado,
                                                                                            .graficoTratorI38Media = GetEquipamentoIndicadorMedia(varDadosTratorI38MotorOciosoAgrupado),
                                                                                            .graficoTratorI38Meta = GetEquipamentoIndicadorMeta(varDadosTratorI38MotorOciosoAgrupado),
                                                                                            .oGraficoTratorI41 = varDadosTratorI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoTratorI41Media = GetEquipamentoIndicadorMedia(varDadosTratorI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoTratorI41Meta = GetEquipamentoIndicadorMeta(varDadosTratorI41ConsumoOleoDieselAgrupado),
                                                                                            .oGraficoCanavieiroI41 = varDadosCanavieiroI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoCanavieiroI41Media = GetEquipamentoIndicadorMedia(varDadosCanavieiroI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoCanavieiroI41Meta = GetEquipamentoIndicadorMeta(varDadosCanavieiroI41ConsumoOleoDieselAgrupado),
                                                                                            .oGraficoEscravoI41 = varDadosEscravoI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoEscravoI41Media = GetEquipamentoIndicadorMedia(varDadosEscravoI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoEscravoI41Meta = GetEquipamentoIndicadorMeta(varDadosEscravoI41ConsumoOleoDieselAgrupado)
                                                                                            }
    End Function


    ' *** POR SAFRA
    ' GET api/AgricolaColheitaAdm/PorSafra/1/2018
    <HttpGet>
    <Route("PorSafra/{parIdNegocios}/{parSafra}")>
    Public Function GetValuesPorSafra(parIdNegocios As Integer, parSafra As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorSafraPlain(parIdNegocios, parSafra)

        Dim dadosColheitaAgrupado = New S5TAgricolaColheitaAgrupadoPorSafra With {.oFrentes = dadosColheita}

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheitaAdm/PorSafraCorteDia/1/2018/20180505
    <HttpGet>
    <Route("PorSafraCorteDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValuesPorSafraCorteDia(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaPorSafraCorteDiaPlain(parIdNegocios, parSafra, parDia)

        Dim dadosColheitaAgrupado = New S5TAgricolaColheitaAgrupadoPorSafra With {.oFrentes = dadosColheita}

        Return Ok(dadosColheitaAgrupado)
    End Function


    Public Function GetAgricolaColheitaPorSafraPlain(parIdNegocios As Integer, parSafra As Integer) As List(Of S5TAgricolaColheitaAdmFrentes)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            String.Format(QueryAgricolaColheitaAdm, "AND ID_NEGOCIOS = :p0 AND SAFRA = :p1"),
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra

        Return GetDadosColheitaFrentes(conn, cmdDadosColheita)
    End Function

    Public Function GetAgricolaColheitaPorSafraCorteDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As String) As List(Of S5TAgricolaColheitaAdmFrentes)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDadosColheita As New OracleCommand(
            String.Format(QueryAgricolaColheitaAdm, "AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA <= :p2"),
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Date).Value = varDia

        Return GetDadosColheitaFrentes(conn, cmdDadosColheita)
    End Function


    Public Function GetAgricolaColheitaEquipamentoPorSafraPorFrentePlain(parIdNegocios As Integer, parSafra As Integer, parFrente As Integer) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaAdmEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND FRENTE = :p2",
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
            QueryAgricolaColheitaAdmEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND FRENTE = :p2 AND DIA = :p3",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Int16).Value = parFrente
        cmdDadosColheita.Parameters.Add(":p3", OracleDbType.Date).Value = varDia

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function

    Private Function GetAgricolaColheitaAdmEquipamentoAgrupadoPorSafra(parDadosColheita As List(Of S5TAgricolaColheitaEquipamento)) As S5TAgricolaColheitaAdmEquipamentoAgrupado
        Dim varDadosColhedoraI38MotorOciosoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 38 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                                             Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                     .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                     .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI39PilotoAutomaticoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 39 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList


        Dim varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 40 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                                                       Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                               .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                               .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosColhedoraI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                                                   Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                           .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                           .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList
        Dim varDadosColhedoraI42ColheitabilidadeAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 42 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                                                  Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                          .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                          .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI38MotorOciosoAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 38 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                                       Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                               .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                               .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosTratorI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "TRATOR" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                                             Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                     .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                     .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosCanavieiroI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "CANAVIEIRO" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                                                     Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                             .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                             .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        Dim varDadosEscravoI41ConsumoOleoDieselAgrupado = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "ESCRAVO" And x.ID_INDICADOR = 41 And x.TIPO_PLANEJAMENTO = "G").GroupBy(Function(x) New With {Key .SAFRA = x.SAFRA, _
                                                                                                                                                                                                               Key .NRO_EQUIPAMENTO = x.NRO_EQUIPAMENTO}).Select(Function (y) New S5TAgricolaColheitaEquipamento With {.NRO_EQUIPAMENTO = y.Min(Function(group) group.NRO_EQUIPAMENTO), _
                                                                                                                                                                                                                                                                                                                       .META = Math.Round(y.Sum(Function(group) group.META), 2), _
                                                                                                                                                                                                                                                                                                                       .REALIZADO = Math.Round(y.Sum(Function(group) group.REALIZADO), 2)}).ToList

        GetAgricolaColheitaAdmEquipamentoAgrupadoPorSafra = New S5TAgricolaColheitaAdmEquipamentoAgrupado With {
                                                                                            .oGraficoColhedoraI38 = varDadosColhedoraI38MotorOciosoAgrupado,
                                                                                            .graficoColhedoraI38Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI38MotorOciosoAgrupado),
                                                                                            .graficoColhedoraI38Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI38MotorOciosoAgrupado),
                                                                                            .oGraficoColhedoraI39 = varDadosColhedoraI39PilotoAutomaticoAgrupado,
                                                                                            .graficoColhedoraI39Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI39PilotoAutomaticoAgrupado),
                                                                                            .graficoColhedoraI39Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI39PilotoAutomaticoAgrupado),
                                                                                            .oGraficoColhedoraI40 = varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado,
                                                                                            .graficoColhedoraI40Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado),
                                                                                            .graficoColhedoraI40Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI40ConsumoOleoHidraulicoAgrupado),
                                                                                            .oGraficoColhedoraI41 = varDadosColhedoraI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoColhedoraI41Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoColhedoraI41Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI41ConsumoOleoDieselAgrupado),
                                                                                            .oGraficoColhedoraI42 = varDadosColhedoraI42ColheitabilidadeAgrupado,
                                                                                            .graficoColhedoraI42Media = GetEquipamentoIndicadorMedia(varDadosColhedoraI42ColheitabilidadeAgrupado),
                                                                                            .graficoColhedoraI42Meta = GetEquipamentoIndicadorMeta(varDadosColhedoraI42ColheitabilidadeAgrupado),
                                                                                            .oGraficoTratorI38 = varDadosTratorI38MotorOciosoAgrupado,
                                                                                            .graficoTratorI38Media = GetEquipamentoIndicadorMedia(varDadosTratorI38MotorOciosoAgrupado),
                                                                                            .graficoTratorI38Meta = GetEquipamentoIndicadorMeta(varDadosTratorI38MotorOciosoAgrupado),
                                                                                            .oGraficoTratorI41 = varDadosTratorI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoTratorI41Media = GetEquipamentoIndicadorMedia(varDadosTratorI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoTratorI41Meta = GetEquipamentoIndicadorMeta(varDadosTratorI41ConsumoOleoDieselAgrupado),
                                                                                            .oGraficoCanavieiroI41 = varDadosCanavieiroI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoCanavieiroI41Media = GetEquipamentoIndicadorMedia(varDadosCanavieiroI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoCanavieiroI41Meta = GetEquipamentoIndicadorMeta(varDadosCanavieiroI41ConsumoOleoDieselAgrupado),
                                                                                            .oGraficoEscravoI41 = varDadosEscravoI41ConsumoOleoDieselAgrupado,
                                                                                            .graficoEscravoI41Media = GetEquipamentoIndicadorMedia(varDadosEscravoI41ConsumoOleoDieselAgrupado),
                                                                                            .graficoEscravoI41Meta = GetEquipamentoIndicadorMeta(varDadosEscravoI41ConsumoOleoDieselAgrupado)
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


    ' *** EQUIPAMENTO
    ' *** POR DIA (PONTUAIS)
    ' GET api/AgricolaColheitaAdm/PorDiaPorFrenteEquip/1/2018/20180511/1
    <HttpGet>
    <Route("PorDiaPorFrenteEquip/{parIdNegocios}/{parSafra}/{parDia}/{parFrente}")>
    Public Function GetValuesEquipPorDiaPorFrente(parIdNegocios As Integer, parSafra As Integer, parDia As String, parFrente As Integer) As IHttpActionResult
        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorDiaPorFrentePlain(parIdNegocios, parSafra, varDia, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAdmEquipamentoAgrupadoPorDia(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    
    ' *** POR SEMANA
    ' GET api/AgricolaColheitaAdm/PorSemanaPorFrenteEquip/1/2018/15/2
    <HttpGet>
    <Route("PorSemanaPorFrenteEquip/{parIdNegocios}/{parSafra}/{parSemana}/{parFrente}")>
    Public Function GetValuesEquipPorSemanaPorFrente(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parFrente As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorSemanaPorFrentePlain(parIdNegocios, parSafra, parSemana, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAdmEquipamentoAgrupadoPorSemana(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheitaAdm/PorSemanaPorFrenteEquipCorteDia/1/2018/15/2/20180505
    <HttpGet>
    <Route("PorSemanaPorFrenteEquipCorteDia/{parIdNegocios}/{parSafra}/{parSemana}/{parFrente}/{parDia}")>
    Public Function GetValuesEquipPorSemanaPorFrenteCorteDia(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer, parFrente As Integer, parDia As String) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorSemanaPorFrenteCorteDiaPlain(parIdNegocios, parSafra, parSemana, parFrente, parDia)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAdmEquipamentoAgrupadoPorSemana(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function


    ' *** POR MÊS
    ' GET api/AgricolaColheitaAdm/PorMesPorFrenteEquip/1/2018/4/2
    <HttpGet>
    <Route("PorMesPorFrenteEquip/{parIdNegocios}/{parSafra}/{parMes}/{parFrente}")>
    Public Function GetValuesEquipPorMesPorFrente(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parFrente As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorMesPorFrentePlain(parIdNegocios, parSafra, parMes, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAdmEquipamentoAgrupadoPorMes(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheitaAdm/PorMesPorFrenteEquipCorteDia/1/2018/4/2/20180505
    <HttpGet>
    <Route("PorMesPorFrenteEquipCorteDia/{parIdNegocios}/{parSafra}/{parMes}/{parFrente}/{parDia}")>
    Public Function GetValuesEquipPorMesPorFrenteCorteDia(parIdNegocios As Integer, parSafra As Integer, parMes As Integer, parFrente As Integer, parDia As String) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorMesPorFrenteCorteDiaPlain(parIdNegocios, parSafra, parMes, parFrente, parDia)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAdmEquipamentoAgrupadoPorMes(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function


    ' *** POR SAFRA
    ' GET api/AgricolaColheitaAdm/PorSafraPorFrenteEquip/1/2018/2
    <HttpGet>
    <Route("PorSafraPorFrenteEquip/{parIdNegocios}/{parSafra}/{parFrente}")>
    Public Function GetValuesEquipPorSafraPorFrente(parIdNegocios As Integer, parSafra As Integer, parFrente As Integer) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorSafraPorFrentePlain(parIdNegocios, parSafra, parFrente)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAdmEquipamentoAgrupadoPorSafra(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    ' GET api/AgricolaColheitaAdm/PorSafraPorFrenteEquipCorteDia/1/2018/2/20180505
    <HttpGet>
    <Route("PorSafraPorFrenteEquipCorteDia/{parIdNegocios}/{parSafra}/{parFrente}/{parDia}")>
    Public Function GetValuesEquipPorSafraPorFrenteCorteDia(parIdNegocios As Integer, parSafra As Integer, parFrente As Integer, parDia As String) As IHttpActionResult
        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorSafraPorFrenteCorteDiaPlain(parIdNegocios, parSafra, parFrente, parDia)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaAdmEquipamentoAgrupadoPorSafra(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function


    Private Function GetDescricaoAbreviadaFrente(parFrenteDescricao As String) As String
        Dim varFrenteDescricao = parFrenteDescricao

        varFrenteDescricao = varFrenteDescricao.Replace("-","").Replace(" ","")

        GetDescricaoAbreviadaFrente = varFrenteDescricao
    End Function

    Private Function GetDadosColheitaFrentes(parConnection As OracleConnection, parCommand As OracleCommand) As List(Of S5TAgricolaColheitaAdmFrentes)
        Dim dadosColheita As New List(Of S5TAgricolaColheitaAdmFrentes)

        parConnection.Open()

        Dim drDadosColheita As OracleDataReader = Nothing
        Try
            drDadosColheita = parCommand.ExecuteReader()
            If drDadosColheita.HasRows Then
                Do While drDadosColheita.Read
                    Dim objDadosColheita = New S5TAgricolaColheitaAdmFrentes

                    objDadosColheita.frenteCodigo = AppUtils.Nvl(drDadosColheita.Item("FRENTE"), 0)
                    objDadosColheita.frenteDescricao = GetDescricaoAbreviadaFrente(AppUtils.Nvl(drDadosColheita.Item("DESC_FRENTE"), ""))
                    objDadosColheita.indicadorMeta = 0

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

        GetDadosColheitaFrentes = dadosColheita
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
                    objDadosColheita.DS_OBS = AppUtils.Nvl(drDadosColheita.Item("DS_OBS"), "")

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
