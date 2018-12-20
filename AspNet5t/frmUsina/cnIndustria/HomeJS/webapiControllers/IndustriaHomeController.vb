Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Web.Http
Imports Oracle.DataAccess.Client

<RoutePrefix("api/IndustriaHome")>
Public Class IndustriaHomeController
    Inherits ApiController

    Private Property QueryIndustriaHome As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, HORA, ID_CA_INDICADOR, DS_CA_INDICADOR, MOENDA, VALOR_PLAN, VALOR_PLAN_NEFETIVA, VALOR_REAL FROM BI4T.INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR IN (53,54,57)"


    <DataContract>
    Public Class S5TIndustriaHome
        Public Property ID_NEGOCIOS As Integer
        Public Property SAFRA As Integer
        <DataMember>
        Public Property MES As Integer
        <DataMember>
        Public Property SEMANA As Integer
        <DataMember>
        Public Property DIA As DateTime
        <DataMember>
        Public Property HORA As String
        Public Property ID_CA_INDICADOR As Integer
        Public Property DS_CA_INDICADOR As String
        Public Property MOENDA As String
        <DataMember>
        Public Property VALOR_PLAN As Double
        Public Property VALOR_PLAN_NEFETIVA As Double
        <DataMember>
        Public Property VALOR_REAL As Double

    End Class

    <DataContract>
    Public Class S5TIndustriaHomeAgrupadoPorDia
        <DataMember>
        Public Property HoraAtual As String
        <DataMember>
        Public Property EficienciaIndustrialArt As Double
        <DataMember>
        Public Property EficienciaIndustrialRtc As Double
        <DataMember>
        Public Property ConsumoInternoPorTonCana As Double
    End Class

    ' GET api/IndustriaHome/VisaoGeralMinMaxDia/1
    <HttpGet>
    <Route("VisaoGeralMinMaxDia/{parIdNegocios}")>
    Public Function GetValuesMaxDia(parIdNegocios As Integer) As IHttpActionResult
        Return Ok(GetIndustriaHomePorSafraMinMaxDia(parIdNegocios))
    End Function


    ' GET api/IndustriaHome/PorDia/1/2017/20171117
    <HttpGet>
    <Route("PorDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim dados = GetIndustriaHomePorDiaPlain(parIdNegocios, parSafra, varDia)

        Dim dadosAgrupados = GetIndustriaHomeAgrupadoPorDiaHora(dados)

        Return Ok(dadosAgrupados)
    End Function

    Public Function GetIndustriaHomePorSafraMinMaxDia(parIdNegocios As Integer) As Object
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            "SELECT MAX(SAFRA) SAFRA, MIN(DIA) MINDIA, MAX(DIA) MAXDIA, MAX(to_char(DIA + cast('0 '||HORA||':00:00' as interval day to second), 'YYYYMMDDHH24MI')) MAXDIAHORA, MIN(SEMANA) MINSEMANA, MAX(SEMANA) MAXSEMANA, MIN(MES) MINMES, MAX(MES) MAXMES FROM BI4T.INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR IN (53,54,57) AND ID_NEGOCIOS = :p0",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios

        Dim varSafra As Integer

        Dim varMinDia As Date
        Dim varMaxDia As Date
        Dim varMaxDiaHora As String
        Dim varMaxHora As String

        Dim varMinSemana As Integer
        Dim varMaxSemana As Integer

        Dim varMinMes As Integer
        Dim varMaxMes As Integer

        conn.Open()

        Dim drDados As OracleDataReader = Nothing
        Try
            drDados = cmdDados.ExecuteReader()
            If drDados.HasRows Then
                Do While drDados.Read
                    varSafra = Nvl(drDados.Item("SAFRA"), 0)

                    varMinDia = Nvl(drDados.Item("MINDIA"), DateTime.MinValue)
                    varMaxDia = Nvl(drDados.Item("MAXDIA"), DateTime.MinValue)
                    varMaxDiaHora = Nvl(drDados.Item("MAXDIAHORA"), "")
                    varMaxHora = varMaxDiaHora.Substring(8, 2)

                    varMinSemana = Nvl(drDados.Item("MINSEMANA"), 0)
                    varMaxSemana = Nvl(drDados.Item("MAXSEMANA"), 0)

                    varMinMes = Nvl(drDados.Item("MINMES"), 0)
                    varMaxMes = Nvl(drDados.Item("MAXMES"), 0)
                Loop

                drDados.Close()
            End If
        Catch ex As Exception
            'Return InternalServerError(ex)
        Finally
            conn.Close()
            If (Not (drDados) Is Nothing) Then
                drDados.Dispose()
            End If
        End Try

        GetIndustriaHomePorSafraMinMaxDia = New With {
            Key .safra = varSafra,
            Key .MinDia = varMinDia,
            Key .MaxDia = varMaxDia,
            Key .MaxHora = varMaxHora,
            Key .MinSemana = varMinSemana,
            Key .MaxSemana = varMaxSemana,
            Key .MinMes = varMinMes,
            Key .MaxMes = varMaxMes}
    End Function

    Public Function GetIndustriaHomePorDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As DateTime) As List(Of S5TIndustriaHome)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaHome & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Date).Value = parDia

        Return GetDados(conn, cmdDados)
    End Function


    Private Function GetIndustriaHomeAgrupadoPorDiaHora(parDados As List(Of S5TIndustriaHome)) As S5TIndustriaHomeAgrupadoPorDia
        Dim varHoraAtual = parDados.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().HORA

        Dim varEficienciaIndustrialArt As Double = 0
        Dim objEficienciaIndustrialArt = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 53 And x.HORA = varHoraAtual).FirstOrDefault()
        If objEficienciaIndustrialArt IsNot Nothing Then varEficienciaIndustrialArt = objEficienciaIndustrialArt.VALOR_REAL

        Dim varEficienciaIndustrialRtc As Double = 0
        Dim objEficienciaIndustrialRtc = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 54 And x.HORA = varHoraAtual).FirstOrDefault()
        If objEficienciaIndustrialRtc IsNot Nothing Then varEficienciaIndustrialRtc = objEficienciaIndustrialRtc.VALOR_REAL

        Dim varConsumoInternoPorTonCana As Double = 0
        Dim objConsumoInternoPorTonCana = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 57 And x.HORA = varHoraAtual).FirstOrDefault()
        If objConsumoInternoPorTonCana IsNot Nothing Then varConsumoInternoPorTonCana = objConsumoInternoPorTonCana.VALOR_REAL

        GetIndustriaHomeAgrupadoPorDiaHora = New S5TIndustriaHomeAgrupadoPorDia With {
                                                                                      .HoraAtual = varHoraAtual,
                                                                                      .EficienciaIndustrialArt = varEficienciaIndustrialArt,
                                                                                      .EficienciaIndustrialRtc = varEficienciaIndustrialRtc,
                                                                                      .ConsumoInternoPorTonCana = varConsumoInternoPorTonCana
                                                                                      }
    End Function



    Private Function GetDados(parConnection As OracleConnection, parCommand As OracleCommand) As List(Of S5TIndustriaHome)
        Dim dados As New List(Of S5TIndustriaHome)

        parConnection.Open()

        Dim drDados As OracleDataReader = Nothing
        Try
            drDados = parCommand.ExecuteReader()
            If drDados.HasRows Then
                Do While drDados.Read
                    Dim objDados = New S5TIndustriaHome

                    objDados.ID_NEGOCIOS = AppUtils.Nvl(drDados.Item("ID_NEGOCIOS"), 0)
                    objDados.SAFRA = AppUtils.Nvl(drDados.Item("SAFRA"), 0)
                    objDados.MES = AppUtils.Nvl(drDados.Item("MES"), 0)
                    objDados.SEMANA = AppUtils.Nvl(drDados.Item("SEMANA"), 0)
                    objDados.DIA = Nvl(drDados.Item("DIA"), DateTime.MinValue)
                    objDados.DIA = objDados.DIA.AddHours(Convert.ToInt16(AppUtils.Nvl(drDados.Item("HORA").ToString().Substring(0, 2), "")))
                    objDados.HORA = AppUtils.Nvl(drDados.Item("HORA"), "")
                    objDados.ID_CA_INDICADOR = AppUtils.Nvl(drDados.Item("ID_CA_INDICADOR"), 0)
                    objDados.DS_CA_INDICADOR = AppUtils.Nvl(drDados.Item("DS_CA_INDICADOR"), "")
                    objDados.MOENDA = AppUtils.Nvl(drDados.Item("MOENDA"), "")
                    objDados.VALOR_PLAN = AppUtils.Nvl(drDados.Item("VALOR_PLAN"), 0)
                    objDados.VALOR_PLAN_NEFETIVA = AppUtils.Nvl(drDados.Item("VALOR_PLAN_NEFETIVA"), 0)
                    objDados.VALOR_REAL = AppUtils.Nvl(drDados.Item("VALOR_REAL"), 0)

                    dados.Add(objDados)
                Loop

                drDados.Close()
            End If
        Catch ex As Exception
            'Return InternalServerError(ex)
        Finally
            parConnection.Close()
            If (Not (drDados) Is Nothing) Then
                drDados.Dispose()
            End If
        End Try

        GetDados = dados
    End Function

End Class
