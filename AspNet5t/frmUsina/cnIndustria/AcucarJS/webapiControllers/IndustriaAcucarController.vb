Imports System.Globalization
Imports System.Reflection
Imports System.Runtime.Serialization
Imports System.Web.Http
Imports Oracle.DataAccess.Client

<RoutePrefix("api/IndustriaAcucar")>
Public Class IndustriaAcucarController
    Inherits ApiController

    Private Property QueryIndustriaAcucar As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, HORA, ID_CA_INDICADOR, DS_CA_INDICADOR, MOENDA, VALOR_PLAN, VALOR_PLAN_NEFETIVA, VALOR_REAL FROM BI4T.INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR IN (50)"
    Private Property QueryIndustriaAcucarPlanejado As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, HORA, ID_CA_INDICADOR, DS_CA_INDICADOR, MOENDA, VALOR_PLAN, VALOR_PLAN_EFETIVA VALOR_PLAN_NEFETIVA, VALOR_REAL FROM BI4T.V_PLAN_INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR = 50"

    <DataContract>
    Public Class S5TIndustriaAcucarSemanaDiaInicioFim
        <DataMember>
        Public Property diaInicio As Date
        <DataMember>
        Public Property diaFim As Date
    End Class

    <DataContract>
    Public Class S5TIndustriaAcucar
        Public Property ID_NEGOCIOS as Integer
        Public Property SAFRA As Integer
        <DataMember>
        Public Property MES As Integer
        <DataMember>
        Public Property SEMANA As Integer
        <DataMember>
        Public Property semanaPeriodo As S5TIndustriaAcucarSemanaDiaInicioFim
        <DataMember>
        Public Property DIA As DateTime
        <DataMember>
        Public Property HORA As String
        Public Property ID_CA_INDICADOR as Integer
        Public Property DS_CA_INDICADOR as String
        Public Property MOENDA As String
        <DataMember>
        Public Property VALOR_PLAN As Double
        Public Property VALOR_PLAN_NEFETIVA As Double
        <DataMember>
        Public Property VALOR_REAL As Double

    End Class


    <DataContract>
    Public Class S5TIndustriaAcucarPorHora
        Public Property DIA As DateTime
        <DataMember>
        Public Property Diario As String
        <DataMember>
        Public Property Hora As String
        <DataMember>
        Public Property H00 As Double
        <DataMember>
        Public Property H01 As Double
        <DataMember>
        Public Property H02 As Double
        <DataMember>
        Public Property H03 As Double
        <DataMember>
        Public Property H04 As Double
        <DataMember>
        Public Property H05 As Double
        <DataMember>
        Public Property H06 As Double
        <DataMember>
        Public Property H07 As Double
        <DataMember>
        Public Property H08 As Double
        <DataMember>
        Public Property H09 As Double
        <DataMember>
        Public Property H10 As Double
        <DataMember>
        Public Property H11 As Double
        <DataMember>
        Public Property H12 As Double
        <DataMember>
        Public Property H13 As Double
        <DataMember>
        Public Property H14 As Double
        <DataMember>
        Public Property H15 As Double
        <DataMember>
        Public Property H16 As Double
        <DataMember>
        Public Property H17 As Double
        <DataMember>
        Public Property H18 As Double
        <DataMember>
        Public Property H19 As Double
        <DataMember>
        Public Property H20 As Double
        <DataMember>
        Public Property H21 As Double
        <DataMember>
        Public Property H22 As Double
        <DataMember>
        Public Property H23 As Double
    End Class

    <DataContract>
    Public Class S5TIndustriaAcucarPorDia
        Public Property SEMANA As Integer
        <DataMember>
        Public Property Diario As String
        <DataMember>
        Public Property Hora As String
        <DataMember>
        Public Property DIA1 As Double
        <DataMember>
        Public Property DIA2 As Double
        <DataMember>
        Public Property DIA3 As Double
        <DataMember>
        Public Property DIA4 As Double
        <DataMember>
        Public Property DIA5 As Double
        <DataMember>
        Public Property DIA6 As Double
        <DataMember>
        Public Property DIA7 As Double
    End Class

    <DataContract>
    Public Class S5TIndustriaAcucarPorSemana
        Public Property MES As Integer
        <DataMember>
        Public Property Diario As String
        <DataMember>
        Public Property Hora As String
        <DataMember>
        Public Property SEMANA1 As Double
        <DataMember>
        Public Property SEMANA2 As Double
        <DataMember>
        Public Property SEMANA3 As Double
        <DataMember>
        Public Property SEMANA4 As Double
        <DataMember>
        Public Property SEMANA5 As Double
        <DataMember>
        Public Property SEMANA6 As Double
    End Class

    <DataContract>
    Public Class S5TIndustriaAcucarPorMes
        Public Property SAFRA As Integer
        <DataMember>
        Public Property Diario As String
        <DataMember>
        Public Property Hora As String
        <DataMember>
        Public Property MES1 As Double
        <DataMember>
        Public Property MES2 As Double
        <DataMember>
        Public Property MES3 As Double
        <DataMember>
        Public Property MES4 As Double
        <DataMember>
        Public Property MES5 As Double
        <DataMember>
        Public Property MES6 As Double
        <DataMember>
        Public Property MES7 As Double
        <DataMember>
        Public Property MES8 As Double
        <DataMember>
        Public Property MES9 As Double
        <DataMember>
        Public Property MES10 As Double
        <DataMember>
        Public Property MES11 As Double
        <DataMember>
        Public Property MES12 As Double
    End Class


    <DataContract>
    Public Class S5TIndustriaAcucarAgrupadoPorDia
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaAcucar)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaAcucar)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaAcucarPorHora)
        <DataMember>
        Public Property HoraAtual As String
        <DataMember>
        Public Property MediaHoraAnterior As Double
    End Class

    <DataContract>
    Public Class S5TIndustriaAcucarAgrupadoPorSemana
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaAcucar)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaAcucar)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaAcucarPorDia)
        <DataMember>
        Public Property DiaAtual As Date
    End Class

    <DataContract>
    Public Class S5TIndustriaAcucarAgrupadoPorMes
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaAcucar)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaAcucar)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaAcucarPorSemana)
        <DataMember>
        Public Property SemanaAtual As Integer
    End Class

    <DataContract>
    Public Class S5TIndustriaAcucarAgrupadoPorSafra
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaAcucar)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaAcucar)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaAcucarPorMes)
        <DataMember>
        Public Property MesAtual As Integer
    End Class

    Private Class S5TVisaoGeralAux
        Property Val As Double
        Property ValMax As Double
        Property IndicadorMeta As Integer
    End Class

    <DataContract>
    Private Class S5TVisaoGeral
        <DataMember>
        Property Dia As DateTime
        <DataMember>
        Property Hora As String
        <DataMember>
        Property DiaVal As Double

        <DataMember>
        Property DiaValMax As Double

        <DataMember>
        Property DiaIndicadorMeta As Integer

        <DataMember>
        Property Semana As Integer
        <DataMember>
        Property SemanaVal As Double

        <DataMember>
        Property SemanaValMax As Double

        <DataMember>
        Property SemanaIndicadorMeta As Integer

        <DataMember>
        Property Mes As Integer
        <DataMember>
        Property MesVal As Double

        <DataMember>
        Property MesValMax As Double

        <DataMember>
        Property MesIndicadorMeta As Integer

        <DataMember>
        Property Safra As Integer
        <DataMember>
        Property SafraVal As Double

        <DataMember>
        Property SafraValMax As Double

        <DataMember>
        Property SafraIndicadorMeta As Integer
    End Class

    ' GET api/IndustriaAcucar/VisaoGeralMinMaxDia/1
    <HttpGet>
    <Route("VisaoGeralMinMaxDia/{parIdNegocios}")>
    Public Function GetValuesMaxDia(parIdNegocios As Integer) As IHttpActionResult
        Return Ok(GetIndustriaAcucarPorSafraMinMaxDia(parIdNegocios))
    End Function


    ' GET api/IndustriaAcucar/VisaoGeral/1/2017
    <HttpGet>
    <Route("VisaoGeral/{parIdNegocios}/{parSafra}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer) As IHttpActionResult
        Dim dados = GetIndustriaAcucarPorSafraPlain(parIdNegocios, parSafra)
        Dim dadosPlanejado = GetIndustriaAcucarPlanejadoPorSafraPlain(parIdNegocios, parSafra)

        Dim ultimoDia = dados.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Date

        Dim ultimaHora = dados.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Hour

        Dim ultimaSemana = dados.OrderByDescending(Function(x) x.SEMANA).FirstOrDefault().SEMANA

        Dim ultimoMes = dados.OrderByDescending(Function(x) x.MES).FirstOrDefault().MES


        Dim dadosDia = dados.FindAll(Function (x) x.DIA.Date = ultimoDia)

        Dim dadosSemana = dados.FindAll(Function(x) x.SEMANA = ultimaSemana)

        Dim dadosMes = dados.FindAll(Function(x) x.MES = ultimoMes)

        Dim dadosSafra = dados


        Dim dadosPlanejadoDia = dadosPlanejado.FindAll(Function (x) x.DIA.Date = ultimoDia)

        Dim dadosPlanejadoSemana = dadosPlanejado.FindAll(Function(x) x.SEMANA = ultimaSemana)

        Dim dadosPlanejadoMes = dadosPlanejado.FindAll(Function(x) x.MES = ultimoMes)

        Dim dadosPlanejadoSafra = dadosPlanejado


        Dim varVisaoGeralDia = GetValoresVisaoGeral(dadosDia, dadosPlanejadoDia, Periodo.Dia)
        Dim varVisaoGeralSemana = GetValoresVisaoGeral(dadosSemana, dadosPlanejadoSemana, Periodo.Semana)
        Dim varVisaoGeralMes = GetValoresVisaoGeral(dadosMes, dadosPlanejadoMes,  Periodo.Mes)
        Dim varVisaoGeralSafra = GetValoresVisaoGeral(dadosSafra, dadosPlanejadoSafra, Periodo.Safra)

        'Metas determinadas
        'varVisaoGeralDia.ValMax = 40000
        'varVisaoGeralSemana.ValMax = 280000
        'varVisaoGeralMes.ValMax = 1000000
        'varVisaoGeralSafra.ValMax = 6000000

        Dim varVisaoGeral = New S5TVisaoGeral With {
                .Dia = ultimoDia,
                .Hora = ultimaHora,
                .DiaVal = varVisaoGeralDia.Val,
                .DiaValMax = varVisaoGeralDia.ValMax,
                .DiaIndicadorMeta = varVisaoGeralDia.IndicadorMeta,
                .Semana = ultimaSemana,
                .SemanaVal = varVisaoGeralSemana.Val,
                .SemanaValMax = varVisaoGeralSemana.ValMax,
                .SemanaIndicadorMeta = varVisaoGeralSemana.IndicadorMeta,
                .Mes = ultimoMes,
                .MesVal = varVisaoGeralMes.Val,
                .MesValMax = varVisaoGeralMes.ValMax,
                .MesIndicadorMeta = varVisaoGeralMes.IndicadorMeta,
                .Safra = parSafra,
                .SafraVal = varVisaoGeralSafra.Val,
                .SafraValMax = varVisaoGeralSafra.ValMax,
                .SafraIndicadorMeta = varVisaoGeralSafra.IndicadorMeta
                }

        Return Ok(varVisaoGeral)
    End Function

    ' GET api/IndustriaAcucar/VisaoGeralCorteDia/1/2017/20171110
    <HttpGet>
    <Route("VisaoGeralCorteDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValuesCorteDia(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim dados = GetIndustriaAcucarPorSafraCorteDiaPlain(parIdNegocios, parSafra, parDia)
        Dim dadosPlanejado = GetIndustriaAcucarPlanejadoPorSafraPlain(parIdNegocios, parSafra)

        Dim ultimoDia = dados.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Date

        Dim ultimaHora = dados.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Hour

        Dim ultimaSemana = dados.OrderByDescending(Function(x) x.SEMANA).FirstOrDefault().SEMANA

        Dim ultimoMes = dados.OrderByDescending(Function(x) x.MES).FirstOrDefault().MES


        Dim dadosDia = dados.FindAll(Function (x) x.DIA.Date = ultimoDia)

        Dim dadosSemana = dados.FindAll(Function(x) x.SEMANA = ultimaSemana)

        Dim dadosMes = dados.FindAll(Function(x) x.MES = ultimoMes)

        Dim dadosSafra = dados


        Dim dadosPlanejadoDia = dadosPlanejado.FindAll(Function (x) x.DIA.Date = ultimoDia)

        Dim dadosPlanejadoSemana = dadosPlanejado.FindAll(Function(x) x.SEMANA = ultimaSemana)

        Dim dadosPlanejadoMes = dadosPlanejado.FindAll(Function(x) x.MES = ultimoMes)

        Dim dadosPlanejadoSafra = dadosPlanejado


        Dim varVisaoGeralDia = GetValoresVisaoGeral(dadosDia, dadosPlanejadoDia, Periodo.Dia)
        Dim varVisaoGeralSemana = GetValoresVisaoGeral(dadosSemana,dadosPlanejadoSemana, Periodo.Semana)
        Dim varVisaoGeralMes = GetValoresVisaoGeral(dadosMes, dadosPlanejadoMes, Periodo.Mes)
        Dim varVisaoGeralSafra = GetValoresVisaoGeral(dadosSafra, dadosPlanejadoSafra, Periodo.Safra)

        'Metas determinadas
        'varVisaoGeralDia.ValMax = 40000
        'varVisaoGeralSemana.ValMax = 280000
        'varVisaoGeralMes.ValMax = 1000000
        'varVisaoGeralSafra.ValMax = 6000000

        Dim varVisaoGeral = New S5TVisaoGeral With {
                .Dia = ultimoDia,
                .Hora = ultimaHora,
                .DiaVal = varVisaoGeralDia.Val,
                .DiaValMax = varVisaoGeralDia.ValMax,
                .DiaIndicadorMeta = varVisaoGeralDia.IndicadorMeta,
                .Semana = ultimaSemana,
                .SemanaVal = varVisaoGeralSemana.Val,
                .SemanaValMax = varVisaoGeralSemana.ValMax,
                .SemanaIndicadorMeta = varVisaoGeralSemana.IndicadorMeta,
                .Mes = ultimoMes,
                .MesVal = varVisaoGeralMes.Val,
                .MesValMax = varVisaoGeralMes.ValMax,
                .MesIndicadorMeta = varVisaoGeralMes.IndicadorMeta,
                .Safra = parSafra,
                .SafraVal = varVisaoGeralSafra.Val,
                .SafraValMax = varVisaoGeralSafra.ValMax,
                .SafraIndicadorMeta = varVisaoGeralSafra.IndicadorMeta
                }

        Return Ok(varVisaoGeral)
    End Function


    ' GET api/IndustriaAcucar/PorDia/1/2017/20171117
    <HttpGet>
    <Route("PorDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim dados = GetIndustriaAcucarPorDiaPlain(parIdNegocios, parSafra, varDia)

        Dim dadosAgrupados = GetIndustriaAcucarAgrupadoPorDiaHora(dados)

        Return Ok(dadosAgrupados)
    End Function

    ' GET api/IndustriaAcucar/PorSemana/1/2017/46
    <HttpGet>
    <Route("PorSemana/{parIdNegocios}/{parSafra}/{parSemana}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As IHttpActionResult
        Dim dados = GetIndustriaAcucarPorSemanaPlain(parIdNegocios, parSafra, parSemana)

        Dim dadosAgrupados = GetIndustriaAcucarAgrupadoPorSemana(dados)

        Return Ok(dadosAgrupados)
    End Function

    ' GET api/IndustriaAcucar/PorMes/1/2017/11
    <HttpGet>
    <Route("PorMes/{parIdNegocios}/{parSafra}/{parMes}")>
    Public Function GetValuesMes(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As IHttpActionResult
        Dim dados = GetIndustriaAcucarPorMesPlain(parIdNegocios, parSafra, parMes)

        Dim dadosAgrupados = GetIndustriaAcucarAgrupadoPorMes(dados)

        Return Ok(dadosAgrupados)
    End Function

    ' GET api/IndustriaAcucar/PorSafra/1/2017
    <HttpGet>
    <Route("PorSafra/{parIdNegocios}/{parSafra}")>
    Public Function GetValuesSafra(parIdNegocios As Integer, parSafra As Integer) As IHttpActionResult
        Dim dados = GetIndustriaAcucarPorSafraPlain(parIdNegocios, parSafra)

        Dim dadosAgrupados = GetIndustriaAcucarAgrupadoPorSafra(dados)

        Return Ok(dadosAgrupados)
    End Function

    ' GET api/IndustriaAcucar/PorSafraCorteDia/1/2017/20171110
    <HttpGet>
    <Route("PorSafraCorteDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValuesSafraCorteDia(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim dados = GetIndustriaAcucarPorSafraCorteDiaPlain(parIdNegocios, parSafra, parDia)

        Dim dadosAgrupados = GetIndustriaAcucarAgrupadoPorSafra(dados)

        Return Ok(dadosAgrupados)
    End Function

    
    Public Function GetIndustriaAcucarPorSafraMinMaxDia(parIdNegocios As Integer) As Object
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            "SELECT MAX(SAFRA) SAFRA, MIN(DIA) MINDIA, MAX(DIA) MAXDIA, MAX(to_char(DIA + cast('0 '||HORA||':00:00' as interval day to second), 'YYYYMMDDHH24MI')) MAXDIAHORA, MIN(SEMANA) MINSEMANA, MAX(SEMANA) MAXSEMANA, MIN(MES) MINMES, MAX(MES) MAXMES FROM BI4T.INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR = 50 AND ID_NEGOCIOS = :p0",
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
                    varMaxHora = varMaxDiaHora.Substring(8,2)

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

        GetIndustriaAcucarPorSafraMinMaxDia = New With {
            Key .safra = varSafra,
            Key .MinDia = varMinDia, 
            Key .MaxDia = varMaxDia, 
            Key .MaxHora = varMaxHora, 
            Key .MinSemana = varMinSemana, 
            Key .MaxSemana = varMaxSemana, 
            Key .MinMes = varMinMes, 
            Key .MaxMes = varMaxMes}
    End Function


    Public Function GetIndustriaAcucarPorSafraPlain(parIdNegocios As Integer, parSafra As Integer) As List(Of S5TIndustriaAcucar)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaAcucar & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra

        Return GetDados(conn, cmdDados)
    End Function

    Public Function GetIndustriaAcucarPlanejadoPorSafraPlain(parIdNegocios As Integer, parSafra As Integer) As List(Of S5TIndustriaAcucar)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaAcucarPlanejado & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra

        Return GetDados(conn, cmdDados)
    End Function


    Public Function GetIndustriaAcucarPorSafraCorteDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As String) As List(Of S5TIndustriaAcucar)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaAcucar & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA <= :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Date).Value = varDia

        Return GetDados(conn, cmdDados)
    End Function
    
    Public Function GetIndustriaAcucarPorDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As DateTime) As List(Of S5TIndustriaAcucar)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaAcucar & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Date).Value = parDia

        Return GetDados(conn, cmdDados)
    End Function

    Public Function GetIndustriaAcucarPorSemanaPlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As List(Of S5TIndustriaAcucar)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaAcucar & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana

        Return GetDados(conn, cmdDados)
    End Function

    Public Function GetIndustriaAcucarPorMesPlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As List(Of S5TIndustriaAcucar)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaAcucar & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Int16).Value = parMes

        Return GetDados(conn, cmdDados)
    End Function


    Private Function GetDados(parConnection As OracleConnection, parCommand As OracleCommand) As List(Of S5TIndustriaAcucar)
        Dim dados As New List(Of S5TIndustriaAcucar)

        parConnection.Open()

        Dim drDados As OracleDataReader = Nothing
        Try
            drDados = parCommand.ExecuteReader()
            If drDados.HasRows Then
                Do While drDados.Read
                    Dim objDados = New S5TIndustriaAcucar

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

    Private Enum Periodo
        Dia
        Semana
        Mes
        Safra
    End Enum

    Private Function GetValoresVisaoGeral(parDados As List(Of S5TIndustriaAcucar), parDadosPlanejado As List(Of S5TIndustriaAcucar), parPeriodo As Periodo) As S5TVisaoGeralAux
        Dim val = Math.Round(parDados.Sum(Function(x) x.VALOR_REAL), 0)

        Dim parDadosParaMeta As List(Of S5TIndustriaAcucar)

        If parPeriodo = Periodo.Dia Then
            Dim varHoraAnterior = parDados.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Hour -1

            parDadosParaMeta = parDados.FindAll(Function(x) x.HORA <= varHoraAnterior)
        Else
            Dim varDiaAnterior = parDados.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Date.AddDays(-1)

            parDadosParaMeta = parDados.FindAll(Function(x) x.DIA <= varDiaAnterior)
        End If

        'PARA NÃO FALHAR COM DIA NA PRIMEIRA HORA DO DIA, COM SEMANA NO PRIMEIRO DIA DA SEMANA
        If parDadosParaMeta.Count = 0 Then
            parDadosParaMeta = parDados
        End If

        Dim valMeta As Double = 0
        Dim valMax As Double = 0

        If parPeriodo = Periodo.Dia Then
            valMeta = Math.Round(parDadosParaMeta.Sum(Function(x) x.VALOR_PLAN), 0)
            'valMax = Math.Round(parDadosPlanejado.Sum(Function(x) x.VALOR_PLAN), 0)
        Else
            valMeta = Math.Round(parDadosParaMeta.Sum(Function(x) x.VALOR_PLAN_NEFETIVA), 0)
            'valMax = Math.Round(parDadosPlanejado.Sum(Function(x) x.VALOR_PLAN_NEFETIVA), 0)
        End If

        valMax = Math.Round(parDadosPlanejado.Sum(Function(x) x.VALOR_PLAN_NEFETIVA), 0)

        Dim indicadorMeta = 0

        If val >= valMeta Then
            'IGUAL OU ACIMA DA META
            indicadorMeta = 0
        ElseIf val < valMeta Then
            'ABAIXO DA META
            indicadorMeta = 2
        End If

        Return New S5TVisaoGeralAux With {
            .Val = val,
            .ValMax = valMax,
            .IndicadorMeta = indicadorMeta
            }
    End Function

    Private Function GetIndustriaAcucarAgrupadoPorDiaHora(parDados As List(Of S5TIndustriaAcucar)) As S5TIndustriaAcucarAgrupadoPorDia
        Dim varDadosGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 50).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                    Key .HORA = x.HORA, _
                                                                                                                                    Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                                                                    Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaAcucar With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                                                .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                                                                .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList
                                                                                                                                                                    
        Dim varDadosGeralAcumulado = GetIndustriaAcucarAcumulado(varDadosGeral)

        Dim varDadosGeralPorHora = GetIndustriaAcucarPorHora(varDadosGeral)

        Dim varHoraAtual = parDados.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().HORA
        Dim varHoraAnterior = varHoraAtual

        If varDadosGeral.Count > 1 Then
            varHoraAnterior = varDadosGeral.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA)(1).HORA
        End If

        GetIndustriaAcucarAgrupadoPorDiaHora = New S5TIndustriaAcucarAgrupadoPorDia With {
                                                                                                           .oGrafico = varDadosGeral, 
                                                                                                           .oGraficoAcumulado = varDadosGeralAcumulado, 
                                                                                                           .oGrid = varDadosGeralPorHora,
                                                                                                           .HoraAtual = varHoraAtual,
                                                                                                           .MediaHoraAnterior = GetMediaHoraAnterior(varDadosGeralPorHora, varHoraAtual)}
    End Function

    Private Function GetIndustriaAcucarAgrupadoPorSemana(parDados As List(Of S5TIndustriaAcucar)) As S5TIndustriaAcucarAgrupadoPorSemana
        Dim varDadosGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 50).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date, _
                                                                                                                                    Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                                                                    Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaAcucar With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                                                                .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosGeralAcumulado = GetIndustriaAcucarAcumulado(varDadosGeral.OrderBy(Function(x) x.DIA.Date).ToList)

        Dim varDadosGeralPorDia = GetIndustriaAcucarPorDia(varDadosGeral)

        Dim varDiaAtual = parDados.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().DIA.Date

        GetIndustriaAcucarAgrupadoPorSemana = New S5TIndustriaAcucarAgrupadoPorSemana With {
                                                                                                            .oGrafico = varDadosGeral.OrderBy(Function(x) x.DIA.Date).ToList, 
                                                                                                            .oGraficoAcumulado = varDadosGeralAcumulado, 
                                                                                                            .oGrid = varDadosGeralPorDia,
                                                                                                            .DiaAtual = varDiaAtual}
    End Function

    Private Function GetIndustriaAcucarAgrupadoPorMes(parDados As List(Of S5TIndustriaAcucar)) As S5TIndustriaAcucarAgrupadoPorMes
        Dim varDadosGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 50).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaAcucar With {
                                                                                                                                                                                                                  .SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                  .semanaPeriodo = New S5TIndustriaAcucarSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                  .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                  .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosGeralAcumulado = GetIndustriaAcucarAcumulado(varDadosGeral.OrderBy(Function(x) x.SEMANA).ToList)

        Dim varDadosGeralPorSemana = GetIndustriaAcucarPorSemana(varDadosGeral)

        Dim varSemanaAtual = parDados.OrderByDescending(Function(x) x.SEMANA).FirstOrDefault().SEMANA

        GetIndustriaAcucarAgrupadoPorMes = New S5TIndustriaAcucarAgrupadoPorMes With {
                                                                                                        .oGrafico = varDadosGeral.OrderBy(Function(x) x.SEMANA).ToList, 
                                                                                                        .oGraficoAcumulado = varDadosGeralAcumulado, 
                                                                                                        .oGrid = varDadosGeralPorSemana,
                                                                                                        .SemanaAtual = varSemanaAtual}
    End Function

    Private Function GetIndustriaAcucarAgrupadoPorSafra(parDados As List(Of S5TIndustriaAcucar)) As S5TIndustriaAcucarAgrupadoPorSafra
        Dim varDadosGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 50).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaAcucar With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                            .DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                            .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                            .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosGeralAcumulado = GetIndustriaAcucarAcumulado(varDadosGeral.OrderBy(Function(x) x.MES).ToList)

        Dim varDadosGeralPorMes = GetIndustriaAcucarPorMes(varDadosGeral)

        Dim varMesAtual = parDados.OrderByDescending(Function(x) x.MES).FirstOrDefault().MES

        GetIndustriaAcucarAgrupadoPorSafra = New S5TIndustriaAcucarAgrupadoPorSafra With {
                                                                                                           .oGrafico = varDadosGeral.OrderBy(Function(x) x.MES).ToList, 
                                                                                                           .oGraficoAcumulado = varDadosGeralAcumulado, 
                                                                                                           .oGrid = varDadosGeralPorMes,
                                                                                                           .MesAtual = varMesAtual}
    End Function


    Private Function GetIndustriaAcucarAcumulado(parIndustriaAcucar As List(Of S5TIndustriaAcucar)) As List(Of S5TIndustriaAcucar)
        Dim parIndustriaAcucarOrdenado = parIndustriaAcucar.OrderBy(Function(x) x.DIA).OrderBy(Function(x) x.HORA)

        Dim varIndustriaAcucarAcumulado = New List(Of S5TIndustriaAcucar)

        Dim varPlanejadoAcumulado As Double = 0
        Dim varRealizadoAcumulado As Double = 0

        For Each objIndustriaAcucar In parIndustriaAcucarOrdenado
            varPlanejadoAcumulado += Math.Round(objIndustriaAcucar.VALOR_PLAN,0)
            varRealizadoAcumulado += Math.Round(objIndustriaAcucar.VALOR_REAL,0)

            varIndustriaAcucarAcumulado.Add(New S5TIndustriaAcucar() With {
                                                .ID_NEGOCIOS = objIndustriaAcucar.ID_NEGOCIOS,
                                                .SAFRA = objIndustriaAcucar.SAFRA,
                                                .MES = objIndustriaAcucar.MES,
                                                .SEMANA = objIndustriaAcucar.SEMANA,
                                                .semanaPeriodo = objIndustriaAcucar.semanaPeriodo,
                                                .DIA = objIndustriaAcucar.DIA,
                                                .HORA = objIndustriaAcucar.HORA,
                                                .ID_CA_INDICADOR = objIndustriaAcucar.ID_CA_INDICADOR,
                                                .DS_CA_INDICADOR = objIndustriaAcucar.DS_CA_INDICADOR,
                                                .MOENDA = objIndustriaAcucar.MOENDA,
                                                .VALOR_PLAN = varPlanejadoAcumulado,
                                                .VALOR_REAL = varRealizadoAcumulado
                                            })
        Next

        GetIndustriaAcucarAcumulado = varIndustriaAcucarAcumulado
    End Function

    Private Function GetIndustriaAcucarPorHora(parDadosPorDia As List(Of S5TIndustriaAcucar)) As List(Of S5TIndustriaAcucarPorHora)
        Dim varIndustriaAcucarPorHora = New List(Of S5TIndustriaAcucarPorHora)

        Dim varObjH00 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "00")
        Dim varObjH01 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "01")
        Dim varObjH02 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "02")
        Dim varObjH03 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "03")
        Dim varObjH04 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "04")
        Dim varObjH05 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "05")
        Dim varObjH06 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "06")
        Dim varObjH07 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "07")
        Dim varObjH08 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "08")
        Dim varObjH09 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "09")
        Dim varObjH10 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "10")
        Dim varObjH11 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "11")
        Dim varObjH12 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "12")
        Dim varObjH13 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "13")
        Dim varObjH14 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "14")
        Dim varObjH15 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "15")
        Dim varObjH16 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "16")
        Dim varObjH17 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "17")
        Dim varObjH18 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "18")
        Dim varObjH19 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "19")
        Dim varObjH20 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "20")
        Dim varObjH21 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "21")
        Dim varObjH22 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "22")
        Dim varObjH23 = parDadosPorDia.FirstOrDefault(Function(x) x.HORA = "23")

        Dim obj01PlanejadoPorHora = New S5TIndustriaAcucarPorHora With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Horário (scs)",
                                                                        .H00 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH00),
                                                                        .H01 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH01),
                                                                        .H02 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH02),
                                                                        .H03 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH03),
                                                                        .H04 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH04),
                                                                        .H05 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH05),
                                                                        .H06 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH06),
                                                                        .H07 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH07),
                                                                        .H08 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH08),
                                                                        .H09 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH09),
                                                                        .H10 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH10),
                                                                        .H11 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH11),
                                                                        .H12 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH12),
                                                                        .H13 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH13),
                                                                        .H14 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH14),
                                                                        .H15 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH15),
                                                                        .H16 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH16),
                                                                        .H17 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH17),
                                                                        .H18 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH18),
                                                                        .H19 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH19),
                                                                        .H20 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH20),
                                                                        .H21 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH21),
                                                                        .H22 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH22),
                                                                        .H23 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH23)
                                                                        }

        Dim obj02PlanejadoAcumuladoPorHora = New S5TIndustriaAcucarPorHora With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (scs)",
                                                                        .H00 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 0),
                                                                        .H01 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 1),
                                                                        .H02 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 2),
                                                                        .H03 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 3),
                                                                        .H04 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 4),
                                                                        .H05 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 5),
                                                                        .H06 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 6),
                                                                        .H07 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 7),
                                                                        .H08 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 8),
                                                                        .H09 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 9),
                                                                        .H10 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 10),
                                                                        .H11 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 11),
                                                                        .H12 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 12),
                                                                        .H13 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 13),
                                                                        .H14 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 14),
                                                                        .H15 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 15),
                                                                        .H16 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 16),
                                                                        .H17 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 17),
                                                                        .H18 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 18),
                                                                        .H19 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 19),
                                                                        .H20 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 20),
                                                                        .H21 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 21),
                                                                        .H22 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 22),
                                                                        .H23 = GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 23)
                                                                        }


        Dim obj03RealizadoPorHora = New S5TIndustriaAcucarPorHora With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Diário (scs)",
                                                                        .H00 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH00),
                                                                        .H01 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH01),
                                                                        .H02 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH02),
                                                                        .H03 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH03),
                                                                        .H04 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH04),
                                                                        .H05 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH05),
                                                                        .H06 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH06),
                                                                        .H07 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH07),
                                                                        .H08 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH08),
                                                                        .H09 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH09),
                                                                        .H10 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH10),
                                                                        .H11 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH11),
                                                                        .H12 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH12),
                                                                        .H13 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH13),
                                                                        .H14 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH14),
                                                                        .H15 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH15),
                                                                        .H16 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH16),
                                                                        .H17 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH17),
                                                                        .H18 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH18),
                                                                        .H19 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH19),
                                                                        .H20 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH20),
                                                                        .H21 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH21),
                                                                        .H22 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH22),
                                                                        .H23 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH23)
                                                                        }

        Dim obj04RealizadoAcumuladoPorHora = New S5TIndustriaAcucarPorHora With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (scs)",
                                                                        .H00 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 0),
                                                                        .H01 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 1),
                                                                        .H02 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 2),
                                                                        .H03 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 3),
                                                                        .H04 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 4),
                                                                        .H05 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 5),
                                                                        .H06 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 6),
                                                                        .H07 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 7),
                                                                        .H08 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 8),
                                                                        .H09 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 9),
                                                                        .H10 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 10),
                                                                        .H11 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 11),
                                                                        .H12 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 12),
                                                                        .H13 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 13),
                                                                        .H14 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 14),
                                                                        .H15 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 15),
                                                                        .H16 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 16),
                                                                        .H17 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 17),
                                                                        .H18 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 18),
                                                                        .H19 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 19),
                                                                        .H20 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 20),
                                                                        .H21 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 21),
                                                                        .H22 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 22),
                                                                        .H23 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 23)
                                                                        }

        Dim obj05RealizadoMenosPlanejadoPorHora = New S5TIndustriaAcucarPorHora With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Diário (scs)",
                                                                                        .H00 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH00) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH00),
                                                                                        .H01 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH01) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH01),
                                                                                        .H02 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH02) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH02),
                                                                                        .H03 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH03) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH03),
                                                                                        .H04 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH04) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH04),
                                                                                        .H05 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH05) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH05),
                                                                                        .H06 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH06) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH06),
                                                                                        .H07 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH07) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH07),
                                                                                        .H08 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH08) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH08),
                                                                                        .H09 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH09) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH09),
                                                                                        .H10 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH10) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH10),
                                                                                        .H11 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH11) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH11),
                                                                                        .H12 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH12) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH12),
                                                                                        .H13 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH13) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH13),
                                                                                        .H14 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH14) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH14),
                                                                                        .H15 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH15) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH15),
                                                                                        .H16 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH16) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH16),
                                                                                        .H17 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH17) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH17),
                                                                                        .H18 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH18) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH18),
                                                                                        .H19 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH19) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH19),
                                                                                        .H20 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH20) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH20),
                                                                                        .H21 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH21) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH21),
                                                                                        .H22 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH22) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH22),
                                                                                        .H23 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjH23) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjH23)
            }

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorHora = New S5TIndustriaAcucarPorHora With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (scs)",
                                                                                .H00 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 0) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 0),
                                                                                .H01 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 1) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 1),
                                                                                .H02 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 2) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 2),
                                                                                .H03 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 3) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 3),
                                                                                .H04 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 4) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 4),
                                                                                .H05 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 5) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 5),
                                                                                .H06 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 6) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 6),
                                                                                .H07 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 7) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 7),
                                                                                .H08 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 8) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 8),
                                                                                .H09 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 9) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 9),
                                                                                .H10 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 10) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 10),
                                                                                .H11 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 11) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 11),
                                                                                .H12 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 12) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 12),
                                                                                .H13 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 13) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 13),
                                                                                .H14 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 14) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 14),
                                                                                .H15 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 15) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 15),
                                                                                .H16 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 16) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 16),
                                                                                .H17 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 17) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 17),
                                                                                .H18 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 18) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 18),
                                                                                .H19 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 19) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 19),
                                                                                .H20 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 20) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 20),
                                                                                .H21 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 21) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 21),
                                                                                .H22 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 22) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 22),
                                                                                .H23 = GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 23) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 23)
        }

        Dim obj07DesvioPercentual = New S5TIndustriaAcucarPorHora With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .H00 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 0) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 0) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 0)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 0), 4)),
                                                        .H01 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 1) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 1) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 1)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 1), 4)),
                                                        .H02 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 2) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 2) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 2)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 2), 4)),
                                                        .H03 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 3) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 3) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 3)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 3), 4)),
                                                        .H04 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 4) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 4) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 4)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 4), 4)),
                                                        .H05 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 5) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 5) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 5)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 5), 4)),
                                                        .H06 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 6) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 6) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 6)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 6), 4)),
                                                        .H07 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 7) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 7) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 7)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 7), 4)),
                                                        .H08 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 8) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 8) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 8)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 8), 4)),
                                                        .H09 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 9) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 9) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 9)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 9), 4)),
                                                        .H10 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 10) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 10) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 10)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 10), 4)),
                                                        .H11 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 11) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 11) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 11)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 11), 4)),
                                                        .H12 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 12) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 12) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 12)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 12), 4)),
                                                        .H13 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 13) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 13) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 13)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 13), 4)),
                                                        .H14 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 14) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 14) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 14)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 14), 4)),
                                                        .H15 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 15) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 15) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 15)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 15), 4)),
                                                        .H16 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 16) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 16) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 16)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 16), 4)),
                                                        .H17 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 17) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 17) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 17)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 17), 4)),
                                                        .H18 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 18) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 18) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 18)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 18), 4)),
                                                        .H19 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 19) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 19) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 19)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 19), 4)),
                                                        .H20 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 20) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 20) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 20)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 20), 4)),
                                                        .H21 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 21) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 21) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 21)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 21), 4)),
                                                        .H22 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 22) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 22) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 22)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 22), 4)),
                                                        .H23 = IIf(GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 23) = 0, 0, Math.Round((GetIndustriaAcucarPorHoraAcumulado(obj03RealizadoPorHora, 23) - GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 23)) / GetIndustriaAcucarPorHoraAcumulado(obj01PlanejadoPorHora, 23), 4))
            }

        Dim objCoeficienteAngular = New S5TIndustriaAcucarPorHora With {
                                                       .Diario = "Desvio",
                                                       .Hora = "Coef.Angular",
                                                       .H00 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 0),
                                                       .H01 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 1),
                                                       .H02 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 2),
                                                       .H03 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 3),
                                                       .H04 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 4),
                                                       .H05 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 5),
                                                       .H06 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 6),
                                                       .H07 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 7),
                                                       .H08 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 8),
                                                       .H09 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 9),
                                                       .H10 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 10),
                                                       .H11 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 11),
                                                       .H12 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 12),
                                                       .H13 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 13),
                                                       .H14 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 14),
                                                       .H15 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 15),
                                                       .H16 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 16),
                                                       .H17 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 17),
                                                       .H18 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 18),
                                                       .H19 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 19),
                                                       .H20 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 20),
                                                       .H21 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 21),
                                                       .H22 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 22),
                                                       .H23 = GetIndustraPorHoraCoeficienteAngular(obj04RealizadoAcumuladoPorHora, 23)
        }

        varIndustriaAcucarPorHora.Add(obj01PlanejadoPorHora)
        varIndustriaAcucarPorHora.Add(obj02PlanejadoAcumuladoPorHora)

        varIndustriaAcucarPorHora.Add(obj03RealizadoPorHora)
        varIndustriaAcucarPorHora.Add(obj04RealizadoAcumuladoPorHora)

        varIndustriaAcucarPorHora.Add(obj05RealizadoMenosPlanejadoPorHora)
        varIndustriaAcucarPorHora.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorHora)
        varIndustriaAcucarPorHora.Add(obj07DesvioPercentual)
        varIndustriaAcucarPorHora.Add(objCoeficienteAngular)

        GetIndustriaAcucarPorHora = varIndustriaAcucarPorHora
    End Function

    Private Function GetIndustriaAcucarPorDia(parDadosPorDia As List(Of S5TIndustriaAcucar)) As List(Of S5TIndustriaAcucarPorDia)
        Dim varIndustriaAcucarPorDia = New List(Of S5TIndustriaAcucarPorDia)

        Dim dadosPorDia = parDadosPorDia.OrderBy(Function(x) x.DIA.Date)

        Dim varObjDia01 = Iif(dadosPorDia.Count() > 0, dadosPorDia(0), Nothing)
        Dim varObjDia02 = Iif(dadosPorDia.Count() > 1, dadosPorDia(1), Nothing)
        Dim varObjDia03 = Iif(dadosPorDia.Count() > 2, dadosPorDia(2), Nothing)
        Dim varObjDia04 = Iif(dadosPorDia.Count() > 3, dadosPorDia(3), Nothing)
        Dim varObjDia05 = Iif(dadosPorDia.Count() > 4, dadosPorDia(4), Nothing)
        Dim varObjDia06 = Iif(dadosPorDia.Count() > 5, dadosPorDia(5), Nothing)
        Dim varObjDia07 = Iif(dadosPorDia.Count() > 6, dadosPorDia(6), Nothing)

        Dim obj01PlanejadoPorDia = New S5TIndustriaAcucarPorDia With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Diário (scs)",
                                                                        .DIA1 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia01),
                                                                        .DIA2 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia02),
                                                                        .DIA3 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia03),
                                                                        .DIA4 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia04),
                                                                        .DIA5 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia05),
                                                                        .DIA6 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia06),
                                                                        .DIA7 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia07)}

        Dim obj02PlanejadoAcumuladoPorDia = New S5TIndustriaAcucarPorDia With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (scs)",
                                                                        .DIA1 = GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 1),
                                                                        .DIA2 = GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 2),
                                                                        .DIA3 = GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 3),
                                                                        .DIA4 = GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 4),
                                                                        .DIA5 = GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 5),
                                                                        .DIA6 = GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 6),
                                                                        .DIA7 = GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 7)}

        Dim obj03RealizadoPorDia = New S5TIndustriaAcucarPorDia With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Diário (scs)",
                                                                        .DIA1 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia01),
                                                                        .DIA2 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia02),
                                                                        .DIA3 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia03),
                                                                        .DIA4 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia04),
                                                                        .DIA5 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia05),
                                                                        .DIA6 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia06),
                                                                        .DIA7 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia07)}

        Dim obj04RealizadoAcumuladoPorDia = New S5TIndustriaAcucarPorDia With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (scs)",
                                                                        .DIA1 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 1),
                                                                        .DIA2 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 2),
                                                                        .DIA3 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 3),
                                                                        .DIA4 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 4),
                                                                        .DIA5 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 5),
                                                                        .DIA6 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 6),
                                                                        .DIA7 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 7)}

        Dim obj05RealizadoMenosPlanejadoPorDia = New S5TIndustriaAcucarPorDia With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Diário (scs)",
                                                                                        .DIA1 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia01) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia01),
                                                                                        .DIA2 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia02) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia02),
                                                                                        .DIA3 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia03) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia03),
                                                                                        .DIA4 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia04) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia04),
                                                                                        .DIA5 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia05) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia05),
                                                                                        .DIA6 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia06) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia06),
                                                                                        .DIA7 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjDia07) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjDia07)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorDia = New S5TIndustriaAcucarPorDia With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (scs)",
                                                                                .DIA1 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 1) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 1),
                                                                                .DIA2 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 2) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 2),
                                                                                .DIA3 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 3) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 3),
                                                                                .DIA4 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 4) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 4),
                                                                                .DIA5 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 5) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 5),
                                                                                .DIA6 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 6) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 6),
                                                                                .DIA7 = GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 7) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 7)}

        Dim obj07DesvioPercentual = New S5TIndustriaAcucarPorDia With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .DIA1 = IIf(GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 1) = 0, 0, Math.Round((GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 1) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 1)) / GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 1), 4)),
                                                        .DIA2 = IIf(GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 2) = 0, 0, Math.Round((GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 2) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 2)) / GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 2), 4)),
                                                        .DIA3 = IIf(GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 3) = 0, 0, Math.Round((GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 3) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 3)) / GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 3), 4)),
                                                        .DIA4 = IIf(GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 4) = 0, 0, Math.Round((GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 4) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 4)) / GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 4), 4)),
                                                        .DIA5 = IIf(GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 5) = 0, 0, Math.Round((GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 5) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 5)) / GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 5), 4)),
                                                        .DIA6 = IIf(GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 6) = 0, 0, Math.Round((GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 6) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 6)) / GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 6), 4)),
                                                        .DIA7 = IIf(GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 7) = 0, 0, Math.Round((GetIndustriaAcucarPorDiaAcumulado(obj03RealizadoPorDia, 7) - GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 7)) / GetIndustriaAcucarPorDiaAcumulado(obj01PlanejadoPorDia, 7), 4))}

        varIndustriaAcucarPorDia.Add(obj01PlanejadoPorDia)
        varIndustriaAcucarPorDia.Add(obj02PlanejadoAcumuladoPorDia)

        varIndustriaAcucarPorDia.Add(obj03RealizadoPorDia)
        varIndustriaAcucarPorDia.Add(obj04RealizadoAcumuladoPorDia)

        varIndustriaAcucarPorDia.Add(obj05RealizadoMenosPlanejadoPorDia)
        varIndustriaAcucarPorDia.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorDia)
        varIndustriaAcucarPorDia.Add(obj07DesvioPercentual)

        GetIndustriaAcucarPorDia = varIndustriaAcucarPorDia
    End Function

    Private Function GetIndustriaAcucarPorSemana(parDados As List(Of S5TIndustriaAcucar)) As List(Of S5TIndustriaAcucarPorSemana)
        Dim varIndustriaAcucarPorSemana = New List(Of S5TIndustriaAcucarPorSemana)

        Dim dadosPorSemana = parDados.GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaAcucar With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                          .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                          .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).OrderBy(Function(x) x.SEMANA).ToList()


        Dim varObjSemana1 As S5TIndustriaAcucar = Nothing
        Dim varObjSemana2 As S5TIndustriaAcucar = Nothing
        Dim varObjSemana3 As S5TIndustriaAcucar = Nothing
        Dim varObjSemana4 As S5TIndustriaAcucar = Nothing
        Dim varObjSemana5 As S5TIndustriaAcucar = Nothing
        Dim varObjSemana6 As S5TIndustriaAcucar = Nothing

        If dadosPorSemana.Count() > 0 Then varObjSemana1 = dadosPorSemana(0)
        If dadosPorSemana.Count() > 1 Then varObjSemana2 = dadosPorSemana(1)
        If dadosPorSemana.Count() > 2 Then varObjSemana3 = dadosPorSemana(2)
        If dadosPorSemana.Count() > 3 Then varObjSemana4 = dadosPorSemana(3)
        If dadosPorSemana.Count() > 4 Then varObjSemana5 = dadosPorSemana(4)
        If dadosPorSemana.Count() > 5 Then varObjSemana6 = dadosPorSemana(5)

        Dim obj01PlanejadoPorSemana = New S5TIndustriaAcucarPorSemana With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Semanal (scs)",
                                                                        .SEMANA1 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana1),
                                                                        .SEMANA2 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana2),
                                                                        .SEMANA3 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana3),
                                                                        .SEMANA4 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana4),
                                                                        .SEMANA5 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana5),
                                                                        .SEMANA6 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana6)}

        Dim obj02PlanejadoAcumuladoPorSemana = New S5TIndustriaAcucarPorSemana With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (scs)",
                                                                        .SEMANA1 = GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 1),
                                                                        .SEMANA2 = GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 2),
                                                                        .SEMANA3 = GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 3),
                                                                        .SEMANA4 = GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 4),
                                                                        .SEMANA5 = GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 5),
                                                                        .SEMANA6 = GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 6)}

        Dim obj03RealizadoPorSemana = New S5TIndustriaAcucarPorSemana With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Semanal (scs)",
                                                                        .SEMANA1 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana1),
                                                                        .SEMANA2 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana2),
                                                                        .SEMANA3 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana3),
                                                                        .SEMANA4 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana4),
                                                                        .SEMANA5 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana5),
                                                                        .SEMANA6 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana6)}

        Dim obj04RealizadoAcumuladoPorSemana = New S5TIndustriaAcucarPorSemana With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (scs)",
                                                                        .SEMANA1 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 1),
                                                                        .SEMANA2 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 2),
                                                                        .SEMANA3 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 3),
                                                                        .SEMANA4 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 4),
                                                                        .SEMANA5 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 5),
                                                                        .SEMANA6 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 6)}

        Dim obj05RealizadoMenosPlanejadoPorSemana = New S5TIndustriaAcucarPorSemana With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Semanal (scs)",
                                                                                        .SEMANA1 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana1) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana1),
                                                                                        .SEMANA2 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana2) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana2),
                                                                                        .SEMANA3 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana3) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana3),
                                                                                        .SEMANA4 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana4) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana4),
                                                                                        .SEMANA5 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana5) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana5),
                                                                                        .SEMANA6 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjSemana6) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjSemana6)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorSemana = New S5TIndustriaAcucarPorSemana With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (scs)",
                                                                                .SEMANA1 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 1) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 1),
                                                                                .SEMANA2 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 2) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 2),
                                                                                .SEMANA3 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 3) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 3),
                                                                                .SEMANA4 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 4) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 4),
                                                                                .SEMANA5 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 5) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 5),
                                                                                .SEMANA6 = GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 6) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 6)}

        Dim obj07DesvioPercentual = New S5TIndustriaAcucarPorSemana With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .SEMANA1 = IIf(GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 1) = 0, 0, Math.Round((GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 1) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 1)) / GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 1), 4)),
                                                        .SEMANA2 = IIf(GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 2) = 0, 0, Math.Round((GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 2) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 2)) / GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 2), 4)),
                                                        .SEMANA3 = IIf(GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 3) = 0, 0, Math.Round((GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 3) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 3)) / GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 3), 4)),
                                                        .SEMANA4 = IIf(GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 4) = 0, 0, Math.Round((GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 4) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 4)) / GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 4), 4)),
                                                        .SEMANA5 = IIf(GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 5) = 0, 0, Math.Round((GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 5) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 5)) / GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 5), 4)),
                                                        .SEMANA6 = IIf(GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 6) = 0, 0, Math.Round((GetIndustriaAcucarPorSemanaAcumulado(obj03RealizadoPorSemana, 6) - GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 6)) / GetIndustriaAcucarPorSemanaAcumulado(obj01PlanejadoPorSemana, 6), 4))}

        varIndustriaAcucarPorSemana.Add(obj01PlanejadoPorSemana)
        varIndustriaAcucarPorSemana.Add(obj02PlanejadoAcumuladoPorSemana)

        varIndustriaAcucarPorSemana.Add(obj03RealizadoPorSemana)
        varIndustriaAcucarPorSemana.Add(obj04RealizadoAcumuladoPorSemana)

        varIndustriaAcucarPorSemana.Add(obj05RealizadoMenosPlanejadoPorSemana)
        varIndustriaAcucarPorSemana.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorSemana)
        varIndustriaAcucarPorSemana.Add(obj07DesvioPercentual)

        GetIndustriaAcucarPorSemana = varIndustriaAcucarPorSemana
    End Function

    Private Function GetIndustriaAcucarPorMes(parDados As List(Of S5TIndustriaAcucar)) As List(Of S5TIndustriaAcucarPorMes)
        Dim varIndustriaAcucarPorMes = New List(Of S5TIndustriaAcucarPorMes)

        Dim dadosPorMes = parDados.GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaAcucar With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                 .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                 .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varObjMes01 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 1)
        Dim varObjMes02 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 2)
        Dim varObjMes03 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 3)
        Dim varObjMes04 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 4)
        Dim varObjMes05 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 5)
        Dim varObjMes06 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 6)
        Dim varObjMes07 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 7)
        Dim varObjMes08 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 8)
        Dim varObjMes09 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 9)
        Dim varObjMes10 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 10)
        Dim varObjMes11 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 11)
        Dim varObjMes12 = dadosPorMes.FirstOrDefault(Function(x) x.MES = 12)

        Dim obj01PlanejadoPorMes = New S5TIndustriaAcucarPorMes With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Mensal (scs)",
                                                                        .MES1 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes01),
                                                                        .MES2 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes02),
                                                                        .MES3 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes03),
                                                                        .MES4 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes04),
                                                                        .MES5 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes05),
                                                                        .MES6 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes06),
                                                                        .MES7 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes07),
                                                                        .MES8 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes08),
                                                                        .MES9 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes09),
                                                                        .MES10 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes10),
                                                                        .MES11 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes11),
                                                                        .MES12 = GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes12)}

        Dim obj02PlanejadoAcumuladoPorMes = New S5TIndustriaAcucarPorMes With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (scs)",
                                                                        .MES1 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 1),
                                                                        .MES2 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 2),
                                                                        .MES3 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 3),
                                                                        .MES4 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 4),
                                                                        .MES5 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 5),
                                                                        .MES6 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 6),
                                                                        .MES7 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 7),
                                                                        .MES8 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 8),
                                                                        .MES9 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 9),
                                                                        .MES10 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 10),
                                                                        .MES11 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 11),
                                                                        .MES12 = GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 12)}

        Dim obj03RealizadoPorMes = New S5TIndustriaAcucarPorMes With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Mensal (scs)",
                                                                        .MES1 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes01),
                                                                        .MES2 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes02),
                                                                        .MES3 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes03),
                                                                        .MES4 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes04),
                                                                        .MES5 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes05),
                                                                        .MES6 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes06),
                                                                        .MES7 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes07),
                                                                        .MES8 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes08),
                                                                        .MES9 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes09),
                                                                        .MES10 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes10),
                                                                        .MES11 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes11),
                                                                        .MES12 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes12)}

        Dim obj04RealizadoAcumuladoPorMes = New S5TIndustriaAcucarPorMes With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (scs)",
                                                                        .MES1 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 1),
                                                                        .MES2 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 2),
                                                                        .MES3 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 3),
                                                                        .MES4 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 4),
                                                                        .MES5 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 5),
                                                                        .MES6 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 6),
                                                                        .MES7 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 7),
                                                                        .MES8 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 8),
                                                                        .MES9 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 9),
                                                                        .MES10 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 10),
                                                                        .MES11 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 11),
                                                                        .MES12 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 12)}

        Dim obj05RealizadoMenosPlanejadoPorMes = New S5TIndustriaAcucarPorMes With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Mensal (scs)",
                                                                                        .MES1 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes01) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes01),
                                                                                        .MES2 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes02) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes02),
                                                                                        .MES3 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes03) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes03),
                                                                                        .MES4 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes04) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes04),
                                                                                        .MES5 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes05) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes05),
                                                                                        .MES6 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes06) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes06),
                                                                                        .MES7 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes07) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes07),
                                                                                        .MES8 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes08) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes08),
                                                                                        .MES9 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes09) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes09),
                                                                                        .MES10 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes10) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes10),
                                                                                        .MES11 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes11) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes11),
                                                                                        .MES12 = GetInfoObjIndustriaAcucar(TipoCampo.ValorRealizado, varObjMes12) - GetInfoObjIndustriaAcucar(TipoCampo.ValorPlanejado, varObjMes12)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorMes = New S5TIndustriaAcucarPorMes With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (scs)",
                                                                                .MES1 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 1) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 1),
                                                                                .MES2 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 2) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 2),
                                                                                .MES3 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 3) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 3),
                                                                                .MES4 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 4) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 4),
                                                                                .MES5 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 5) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 5),
                                                                                .MES6 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 6) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 6),
                                                                                .MES7 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 7) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 7),
                                                                                .MES8 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 8) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 8),
                                                                                .MES9 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 9) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 9),
                                                                                .MES10 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 10) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 10),
                                                                                .MES11 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 11) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 11),
                                                                                .MES12 = GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 12) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 12)}

        Dim obj07DesvioPercentual = New S5TIndustriaAcucarPorMes With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .MES1 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 1) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 1) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 1)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 1), 4)),
                                                        .MES2 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 2) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 2) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 2)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 2), 4)),
                                                        .MES3 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 3) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 3) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 3)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 3), 4)),
                                                        .MES4 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 4) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 4) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 4)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 4), 4)),
                                                        .MES5 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 5) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 5) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 5)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 5), 4)),
                                                        .MES6 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 6) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 6) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 6)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 6), 4)),
                                                        .MES7 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 7) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 7) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 7)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 7), 4)),
                                                        .MES8 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 8) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 8) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 8)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 8), 4)),
                                                        .MES9 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 9) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 9) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 9)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 9), 4)),
                                                        .MES10 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 10) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 10) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 10)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 10), 4)),
                                                        .MES11 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 11) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 11) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 11)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 11), 4)),
                                                        .MES12 = IIf(GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 12) = 0, 0, Math.Round((GetIndustriaAcucarPorMesAcumulado(obj03RealizadoPorMes, 12) - GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 12)) / GetIndustriaAcucarPorMesAcumulado(obj01PlanejadoPorMes, 12), 4))}

        varIndustriaAcucarPorMes.Add(obj01PlanejadoPorMes)
        varIndustriaAcucarPorMes.Add(obj02PlanejadoAcumuladoPorMes)

        varIndustriaAcucarPorMes.Add(obj03RealizadoPorMes)
        varIndustriaAcucarPorMes.Add(obj04RealizadoAcumuladoPorMes)

        varIndustriaAcucarPorMes.Add(obj05RealizadoMenosPlanejadoPorMes)
        varIndustriaAcucarPorMes.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorMes)
        varIndustriaAcucarPorMes.Add(obj07DesvioPercentual)

        GetIndustriaAcucarPorMes = varIndustriaAcucarPorMes
    End Function


    Private Function GetIndustriaAcucarPorHoraAcumulado(parIndustriaAcucarPorHora As S5TIndustriaAcucarPorHora, parHora As Integer) As Double
        Dim varValor = 0

        Select Case parHora
            Case 0
                varValor = parIndustriaAcucarPorHora.H00
            Case 1
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01
            Case 2
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02
            Case 3
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03
            Case 4
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04
            Case 5
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05
            Case 6
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06
            Case 7
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07
            Case 8
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08
            Case 9
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09
            Case 10
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10
            Case 11
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11
            Case 12
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12
            Case 13
                varValor = parIndustriaAcucarPorHora.H00 + 
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13
            Case 14
                varValor = parIndustriaAcucarPorHora.H00 +
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13 +
                           parIndustriaAcucarPorHora.H14
            Case 15
                varValor = parIndustriaAcucarPorHora.H00 +
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13 +
                           parIndustriaAcucarPorHora.H14 +
                           parIndustriaAcucarPorHora.H15
            Case 16
                varValor = parIndustriaAcucarPorHora.H00 +
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13 +
                           parIndustriaAcucarPorHora.H14 +
                           parIndustriaAcucarPorHora.H15 +
                           parIndustriaAcucarPorHora.H16
            Case 17
                varValor = parIndustriaAcucarPorHora.H00 +
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13 +
                           parIndustriaAcucarPorHora.H14 +
                           parIndustriaAcucarPorHora.H15 +
                           parIndustriaAcucarPorHora.H16 +
                           parIndustriaAcucarPorHora.H17
            Case 18
                varValor = parIndustriaAcucarPorHora.H00 +
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13 +
                           parIndustriaAcucarPorHora.H14 +
                           parIndustriaAcucarPorHora.H15 +
                           parIndustriaAcucarPorHora.H16 +
                           parIndustriaAcucarPorHora.H17 +
                           parIndustriaAcucarPorHora.H18
            Case 19
                varValor = parIndustriaAcucarPorHora.H00 +
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13 +
                           parIndustriaAcucarPorHora.H14 +
                           parIndustriaAcucarPorHora.H15 +
                           parIndustriaAcucarPorHora.H16 +
                           parIndustriaAcucarPorHora.H17 +
                           parIndustriaAcucarPorHora.H18 +
                           parIndustriaAcucarPorHora.H19
            Case 20
                varValor = parIndustriaAcucarPorHora.H00 +
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13 +
                           parIndustriaAcucarPorHora.H14 +
                           parIndustriaAcucarPorHora.H15 +
                           parIndustriaAcucarPorHora.H16 +
                           parIndustriaAcucarPorHora.H17 +
                           parIndustriaAcucarPorHora.H18 +
                           parIndustriaAcucarPorHora.H19 +
                           parIndustriaAcucarPorHora.H20
            Case 21
                varValor = parIndustriaAcucarPorHora.H00 +
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13 +
                           parIndustriaAcucarPorHora.H14 +
                           parIndustriaAcucarPorHora.H15 +
                           parIndustriaAcucarPorHora.H16 +
                           parIndustriaAcucarPorHora.H17 +
                           parIndustriaAcucarPorHora.H18 +
                           parIndustriaAcucarPorHora.H19 +
                           parIndustriaAcucarPorHora.H20 +
                           parIndustriaAcucarPorHora.H21
            Case 22
                varValor = parIndustriaAcucarPorHora.H00 +
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13 +
                           parIndustriaAcucarPorHora.H14 +
                           parIndustriaAcucarPorHora.H15 +
                           parIndustriaAcucarPorHora.H16 +
                           parIndustriaAcucarPorHora.H17 +
                           parIndustriaAcucarPorHora.H18 +
                           parIndustriaAcucarPorHora.H19 +
                           parIndustriaAcucarPorHora.H20 +
                           parIndustriaAcucarPorHora.H21 +
                           parIndustriaAcucarPorHora.H22
            Case 23
                varValor = parIndustriaAcucarPorHora.H00 +
                           parIndustriaAcucarPorHora.H01 +
                           parIndustriaAcucarPorHora.H02 +
                           parIndustriaAcucarPorHora.H03 +
                           parIndustriaAcucarPorHora.H04 +
                           parIndustriaAcucarPorHora.H05 +
                           parIndustriaAcucarPorHora.H06 +
                           parIndustriaAcucarPorHora.H07 +
                           parIndustriaAcucarPorHora.H08 +
                           parIndustriaAcucarPorHora.H09 +
                           parIndustriaAcucarPorHora.H10 +
                           parIndustriaAcucarPorHora.H11 +
                           parIndustriaAcucarPorHora.H12 +
                           parIndustriaAcucarPorHora.H13 +
                           parIndustriaAcucarPorHora.H14 +
                           parIndustriaAcucarPorHora.H15 +
                           parIndustriaAcucarPorHora.H16 +
                           parIndustriaAcucarPorHora.H17 +
                           parIndustriaAcucarPorHora.H18 +
                           parIndustriaAcucarPorHora.H19 +
                           parIndustriaAcucarPorHora.H20 +
                           parIndustriaAcucarPorHora.H21 +
                           parIndustriaAcucarPorHora.H22 +
                           parIndustriaAcucarPorHora.H23
        End Select

        GetIndustriaAcucarPorHoraAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustraPorHoraCoeficienteAngular(parIndustriaAcucarPorHora As S5TIndustriaAcucarPorHora, parHora As Integer) As Double
        GetIndustraPorHoraCoeficienteAngular = 0

        Dim t as Type = parIndustriaAcucarPorHora.GetType()

        If parHora >= 1 Then
            Dim varNomePropriedadeHoraAtual = "H" & (parHora.ToString).PadLeft(2,"0")
            Dim varHoraAtualMenos1 = "H" & ((parHora - 1).ToString).PadLeft(2,"0")
            Dim fieldHoraAtual As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtual)
            Dim fieldHoraMenos1 As PropertyInfo = t.GetProperty(varHoraAtualMenos1)

            If fieldHoraAtual IsNot Nothing And fieldHoraMenos1 IsNot Nothing Then
                Dim varValorHoraAtual = fieldHoraAtual.GetValue(parIndustriaAcucarPorHora, Nothing)
                Dim varValorHoraAtualMenos1 = fieldHoraMenos1.GetValue(parIndustriaAcucarPorHora, Nothing)


                If varValorHoraAtual - varValorHoraAtualMenos1 <> 0 Then
                    GetIndustraPorHoraCoeficienteAngular = 1 / (varValorHoraAtual - varValorHoraAtualMenos1)
                End If
            End If
        End If
    End Function

    Private Function GetIndustriaAcucarPorDiaAcumulado(parIndustriaAcucarPorDia As S5TIndustriaAcucarPorDia, parDia As Integer) As Double
        Dim varValor = 0

        Select Case parDia
            Case 1
                varValor = parIndustriaAcucarPorDia.DIA1
            Case 2
                varValor = parIndustriaAcucarPorDia.DIA1 + 
                           parIndustriaAcucarPorDia.DIA2
            Case 3
                varValor = parIndustriaAcucarPorDia.DIA1 + 
                           parIndustriaAcucarPorDia.DIA2 +
                           parIndustriaAcucarPorDia.DIA3
            Case 4
                varValor = parIndustriaAcucarPorDia.DIA1 + 
                           parIndustriaAcucarPorDia.DIA2 +
                           parIndustriaAcucarPorDia.DIA3 +
                           parIndustriaAcucarPorDia.DIA4
            Case 5
                varValor = parIndustriaAcucarPorDia.DIA1 + 
                           parIndustriaAcucarPorDia.DIA2 +
                           parIndustriaAcucarPorDia.DIA3 +
                           parIndustriaAcucarPorDia.DIA4 +
                           parIndustriaAcucarPorDia.DIA5
            Case 6
                varValor = parIndustriaAcucarPorDia.DIA1 + 
                           parIndustriaAcucarPorDia.DIA2 +
                           parIndustriaAcucarPorDia.DIA3 +
                           parIndustriaAcucarPorDia.DIA4 +
                           parIndustriaAcucarPorDia.DIA5 +
                           parIndustriaAcucarPorDia.DIA6
            Case 7
                varValor = parIndustriaAcucarPorDia.DIA1 + 
                           parIndustriaAcucarPorDia.DIA2 +
                           parIndustriaAcucarPorDia.DIA3 +
                           parIndustriaAcucarPorDia.DIA4 +
                           parIndustriaAcucarPorDia.DIA5 +
                           parIndustriaAcucarPorDia.DIA6 +
                           parIndustriaAcucarPorDia.DIA7
        End Select

        GetIndustriaAcucarPorDiaAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustriaAcucarPorSemanaAcumulado(parIndustriaAcucarPorSemana As S5TIndustriaAcucarPorSemana, parSemana As Integer) As Double
        Dim varValor = 0

        Select Case parSemana
            Case 1
                varValor = parIndustriaAcucarPorSemana.SEMANA1
            Case 2
                varValor = parIndustriaAcucarPorSemana.SEMANA1 +
                           parIndustriaAcucarPorSemana.SEMANA2
            Case 3
                varValor = parIndustriaAcucarPorSemana.SEMANA1 + 
                           parIndustriaAcucarPorSemana.SEMANA2 +
                           parIndustriaAcucarPorSemana.SEMANA3
            Case 4
                varValor = parIndustriaAcucarPorSemana.SEMANA1 + 
                           parIndustriaAcucarPorSemana.SEMANA2 +
                           parIndustriaAcucarPorSemana.SEMANA3 +
                           parIndustriaAcucarPorSemana.SEMANA4
            Case 5
                varValor = parIndustriaAcucarPorSemana.SEMANA1 + 
                           parIndustriaAcucarPorSemana.SEMANA2 +
                           parIndustriaAcucarPorSemana.SEMANA3 +
                           parIndustriaAcucarPorSemana.SEMANA4 +
                           parIndustriaAcucarPorSemana.SEMANA5
            Case 6
                varValor = parIndustriaAcucarPorSemana.SEMANA1 + 
                           parIndustriaAcucarPorSemana.SEMANA2 +
                           parIndustriaAcucarPorSemana.SEMANA3 +
                           parIndustriaAcucarPorSemana.SEMANA4 +
                           parIndustriaAcucarPorSemana.SEMANA5 +
                           parIndustriaAcucarPorSemana.SEMANA6
        End Select

        GetIndustriaAcucarPorSemanaAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustriaAcucarPorMesAcumulado(parIndustriaAcucarPorMes As S5TIndustriaAcucarPorMes, parMes As Integer) As Double
        Dim varValor = 0

        Select Case parMes
            Case 1
                varValor = parIndustriaAcucarPorMes.MES1
            Case 2
                varValor = parIndustriaAcucarPorMes.MES1 +
                           parIndustriaAcucarPorMes.MES2
            Case 3
                varValor = parIndustriaAcucarPorMes.MES1 + 
                           parIndustriaAcucarPorMes.MES2 +
                           parIndustriaAcucarPorMes.MES3
            Case 4
                varValor = parIndustriaAcucarPorMes.MES1 + 
                           parIndustriaAcucarPorMes.MES2 +
                           parIndustriaAcucarPorMes.MES3 +
                           parIndustriaAcucarPorMes.MES4
            Case 5
                varValor = parIndustriaAcucarPorMes.MES1 + 
                           parIndustriaAcucarPorMes.MES2 +
                           parIndustriaAcucarPorMes.MES3 +
                           parIndustriaAcucarPorMes.MES4 +
                           parIndustriaAcucarPorMes.MES5
            Case 6
                varValor = parIndustriaAcucarPorMes.MES1 + 
                           parIndustriaAcucarPorMes.MES2 +
                           parIndustriaAcucarPorMes.MES3 +
                           parIndustriaAcucarPorMes.MES4 +
                           parIndustriaAcucarPorMes.MES5 +
                           parIndustriaAcucarPorMes.MES6
            Case 7
                varValor = parIndustriaAcucarPorMes.MES1 + 
                           parIndustriaAcucarPorMes.MES2 +
                           parIndustriaAcucarPorMes.MES3 +
                           parIndustriaAcucarPorMes.MES4 +
                           parIndustriaAcucarPorMes.MES5 +
                           parIndustriaAcucarPorMes.MES6 +
                           parIndustriaAcucarPorMes.MES7
            Case 8
                varValor = parIndustriaAcucarPorMes.MES1 + 
                           parIndustriaAcucarPorMes.MES2 +
                           parIndustriaAcucarPorMes.MES3 +
                           parIndustriaAcucarPorMes.MES4 +
                           parIndustriaAcucarPorMes.MES5 +
                           parIndustriaAcucarPorMes.MES6 +
                           parIndustriaAcucarPorMes.MES7 +
                           parIndustriaAcucarPorMes.MES8
            Case 9
                varValor = parIndustriaAcucarPorMes.MES1 + 
                           parIndustriaAcucarPorMes.MES2 +
                           parIndustriaAcucarPorMes.MES3 +
                           parIndustriaAcucarPorMes.MES4 +
                           parIndustriaAcucarPorMes.MES5 +
                           parIndustriaAcucarPorMes.MES6 +
                           parIndustriaAcucarPorMes.MES7 +
                           parIndustriaAcucarPorMes.MES8 +
                           parIndustriaAcucarPorMes.MES9
            Case 10
                varValor = parIndustriaAcucarPorMes.MES1 + 
                           parIndustriaAcucarPorMes.MES2 +
                           parIndustriaAcucarPorMes.MES3 +
                           parIndustriaAcucarPorMes.MES4 +
                           parIndustriaAcucarPorMes.MES5 +
                           parIndustriaAcucarPorMes.MES6 +
                           parIndustriaAcucarPorMes.MES7 +
                           parIndustriaAcucarPorMes.MES8 +
                           parIndustriaAcucarPorMes.MES9 +
                           parIndustriaAcucarPorMes.MES10
            Case 11
                varValor = parIndustriaAcucarPorMes.MES1 + 
                           parIndustriaAcucarPorMes.MES2 +
                           parIndustriaAcucarPorMes.MES3 +
                           parIndustriaAcucarPorMes.MES4 +
                           parIndustriaAcucarPorMes.MES5 +
                           parIndustriaAcucarPorMes.MES6 +
                           parIndustriaAcucarPorMes.MES7 +
                           parIndustriaAcucarPorMes.MES8 +
                           parIndustriaAcucarPorMes.MES9 +
                           parIndustriaAcucarPorMes.MES10 +
                           parIndustriaAcucarPorMes.MES11
            Case 12
                varValor = parIndustriaAcucarPorMes.MES1 + 
                           parIndustriaAcucarPorMes.MES2 +
                           parIndustriaAcucarPorMes.MES3 +
                           parIndustriaAcucarPorMes.MES4 +
                           parIndustriaAcucarPorMes.MES5 +
                           parIndustriaAcucarPorMes.MES6 +
                           parIndustriaAcucarPorMes.MES7 +
                           parIndustriaAcucarPorMes.MES8 +
                           parIndustriaAcucarPorMes.MES9 +
                           parIndustriaAcucarPorMes.MES10 +
                           parIndustriaAcucarPorMes.MES11 +
                           parIndustriaAcucarPorMes.MES12
        End Select

        GetIndustriaAcucarPorMesAcumulado = Math.Round(varValor,0)
    End Function

    Enum TipoCampo
        ValorPlanejado
        ValorRealizado
    End Enum

    Private Function GetInfoObjIndustriaAcucar(parTipoCampo As TipoCampo, parObjIndustriaAcucar As S5TIndustriaAcucar) As Double
        GetInfoObjIndustriaAcucar = 0

        If parObjIndustriaAcucar IsNot Nothing Then
            If parTipoCampo = TipoCampo.ValorPlanejado Then
                GetInfoObjIndustriaAcucar = Math.Round(parObjIndustriaAcucar.VALOR_PLAN,0)
            ElseIf parTipoCampo = TipoCampo.ValorRealizado Then
                GetInfoObjIndustriaAcucar = Math.Round(parObjIndustriaAcucar.VALOR_REAL,0)
            End If
        End If
    End Function

    Private Function GetIndustriaAcucarAcumuladoPorDiaAjustadoMetas(parIndustriaAcucarPorHora As S5TIndustriaAcucarPorHora, parHoraAtual As String) As S5TIndustriaAcucarPorHora
        GetIndustriaAcucarAcumuladoPorDiaAjustadoMetas = parIndustriaAcucarPorHora

        Dim varHoraAtual = Convert.ToInt16(parHoraAtual)

        Dim t as Type = parIndustriaAcucarPorHora.GetType()

        For i As Integer = varHoraAtual To 22
            Dim varValorMetaHoraMenos1 As Double = 0
            If i > 0 Then
                Dim varNomePropriedadeHoraMenos1 = "H" & (i-1).ToString.PadLeft(2, "0")
                Dim fieldHoraMenos1 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraMenos1)
                varValorMetaHoraMenos1 = fieldHoraMenos1.GetValue(parIndustriaAcucarPorHora, Nothing)
            End If

            Dim varNomePropriedadeHoraAtual = "H" & i.ToString.PadLeft(2, "0")
            Dim fieldHoraAtual As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtual)
            Dim varValorMetaHoraAtual As Double = fieldHoraAtual.GetValue(parIndustriaAcucarPorHora, Nothing)

            Dim varNomePropriedadeHoraMais1 = "H" & (i+1).ToString.PadLeft(2, "0")
            Dim fieldHoraMais1 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraMais1)
            Dim varValorMetaHoraMais1 As Double = fieldHoraMais1.GetValue(parIndustriaAcucarPorHora, Nothing)

            If varValorMetaHoraMais1 <= varValorMetaHoraAtual Then
                fieldHoraMais1.SetValue(parIndustriaAcucarPorHora, Math.Round(varValorMetaHoraAtual + (varValorMetaHoraAtual - varValorMetaHoraMenos1),0))
            End If            
        Next

        GetIndustriaAcucarAcumuladoPorDiaAjustadoMetas = parIndustriaAcucarPorHora
    End Function

    Private Function GetMediaHoraAnterior(parDadosGeralPorHora As List(Of S5TIndustriaAcucarPorHora), parHoraAtual As String) As Double
        GetMediaHoraAnterior = 0

        Dim objRealizadoAcumulado = parDadosGeralPorHora.FirstOrDefault(Function(x) x.Diario = "Realizado" And x.Hora = "Acumulado (scs)")

        Dim varHoraAtual = Convert.ToInt16(parHoraAtual)

        If varHoraAtual > 0 Then
            Dim t as Type = objRealizadoAcumulado.GetType()

            Dim varNomePropriedadeHoraAnterior = "H" & (varHoraAtual - 1).ToString.PadLeft(2, "0")
            Dim fieldHoraAnterior As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAnterior)

            Dim varRealizadoAcumuladoHoraAnterior As Double = fieldHoraAnterior.GetValue(objRealizadoAcumulado, Nothing)

            Dim varMediaHoraAnterior As Double = varRealizadoAcumuladoHoraAnterior / varHoraAtual


            GetMediaHoraAnterior = Math.Round(varMediaHoraAnterior,0)
        End If
    End Function


    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)
    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)
    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)
    End Sub
End Class
