Imports System.Globalization
Imports System.Reflection
Imports System.Runtime.Serialization
Imports System.Web.Http
Imports Oracle.DataAccess.Client

<RoutePrefix("api/IndustriaEnergiaBio")>
Public Class IndustriaEnergiaBioController
    Inherits ApiController

    Private Property QueryIndustriaEnergiaBio As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, HORA, ID_CA_INDICADOR, DS_CA_INDICADOR, MOENDA, VALOR_PLAN, VALOR_PLAN_NEFETIVA, VALOR_REAL FROM BI4T.INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR IN (56)"
    Private Property QueryIndustriaEnergiaBioPlanejado As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, HORA, ID_CA_INDICADOR, DS_CA_INDICADOR, MOENDA, VALOR_PLAN, VALOR_PLAN_EFETIVA VALOR_PLAN_NEFETIVA, VALOR_REAL FROM BI4T.V_PLAN_INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR = 56"

    <DataContract>
    Public Class S5TIndustriaEnergiaBioSemanaDiaInicioFim
        <DataMember>
        Public Property diaInicio As Date
        <DataMember>
        Public Property diaFim As Date
    End Class

    <DataContract>
    Public Class S5TIndustriaEnergiaBio
        Public Property ID_NEGOCIOS as Integer
        Public Property SAFRA As Integer
        <DataMember>
        Public Property MES As Integer
        <DataMember>
        Public Property SEMANA As Integer
        <DataMember>
        Public Property semanaPeriodo As S5TIndustriaEnergiaBioSemanaDiaInicioFim
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
    Public Class S5TIndustriaEnergiaBioPorHora
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
    Public Class S5TIndustriaEnergiaBioPorDia
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
    Public Class S5TIndustriaEnergiaBioPorSemana
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
    Public Class S5TIndustriaEnergiaBioPorMes
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
    Public Class S5TIndustriaEnergiaBioAgrupadoPorDia
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaEnergiaBio)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaEnergiaBio)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaEnergiaBioPorHora)
        <DataMember>
        Public Property HoraAtual As String
        <DataMember>
        Public Property MediaHoraAnterior As Double
    End Class

    <DataContract>
    Public Class S5TIndustriaEnergiaBioAgrupadoPorSemana
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaEnergiaBio)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaEnergiaBio)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaEnergiaBioPorDia)
        <DataMember>
        Public Property DiaAtual As Date
    End Class

    <DataContract>
    Public Class S5TIndustriaEnergiaBioAgrupadoPorMes
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaEnergiaBio)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaEnergiaBio)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaEnergiaBioPorSemana)
        <DataMember>
        Public Property SemanaAtual As Integer
    End Class

    <DataContract>
    Public Class S5TIndustriaEnergiaBioAgrupadoPorSafra
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaEnergiaBio)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaEnergiaBio)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaEnergiaBioPorMes)
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

    ' GET api/IndustriaEnergiaBio/VisaoGeralMinMaxDia/1
    <HttpGet>
    <Route("VisaoGeralMinMaxDia/{parIdNegocios}")>
    Public Function GetValuesMaxDia(parIdNegocios As Integer) As IHttpActionResult
        Return Ok(GetIndustriaEnergiaBioPorSafraMinMaxDia(parIdNegocios))
    End Function


    ' GET api/IndustriaEnergiaBio/VisaoGeral/1/2017
    <HttpGet>
    <Route("VisaoGeral/{parIdNegocios}/{parSafra}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer) As IHttpActionResult
        Dim dados = GetIndustriaEnergiaBioPorSafraPlain(parIdNegocios, parSafra)
        Dim dadosPlanejado = GetIndustriaEnergiaBioPlanejadoPorSafraPlain(parIdNegocios, parSafra)

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

    ' GET api/IndustriaEnergiaBio/VisaoGeralCorteDia/1/2017/20171110
    <HttpGet>
    <Route("VisaoGeralCorteDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValuesCorteDia(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim dados = GetIndustriaEnergiaBioPorSafraCorteDiaPlain(parIdNegocios, parSafra, parDia)
        Dim dadosPlanejado = GetIndustriaEnergiaBioPlanejadoPorSafraPlain(parIdNegocios, parSafra)

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


    ' GET api/IndustriaEnergiaBio/PorDia/1/2017/20171117
    <HttpGet>
    <Route("PorDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim dados = GetIndustriaEnergiaBioPorDiaPlain(parIdNegocios, parSafra, varDia)

        Dim dadosAgrupados = GetIndustriaEnergiaBioAgrupadoPorDiaHora(dados)

        Return Ok(dadosAgrupados)
    End Function

    ' GET api/IndustriaEnergiaBio/PorSemana/1/2017/46
    <HttpGet>
    <Route("PorSemana/{parIdNegocios}/{parSafra}/{parSemana}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As IHttpActionResult
        Dim dados = GetIndustriaEnergiaBioPorSemanaPlain(parIdNegocios, parSafra, parSemana)

        Dim dadosAgrupados = GetIndustriaEnergiaBioAgrupadoPorSemana(dados)

        Return Ok(dadosAgrupados)
    End Function

    ' GET api/IndustriaEnergiaBio/PorMes/1/2017/11
    <HttpGet>
    <Route("PorMes/{parIdNegocios}/{parSafra}/{parMes}")>
    Public Function GetValuesMes(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As IHttpActionResult
        Dim dados = GetIndustriaEnergiaBioPorMesPlain(parIdNegocios, parSafra, parMes)

        Dim dadosAgrupados = GetIndustriaEnergiaBioAgrupadoPorMes(dados)

        Return Ok(dadosAgrupados)
    End Function

    ' GET api/IndustriaEnergiaBio/PorSafra/1/2017
    <HttpGet>
    <Route("PorSafra/{parIdNegocios}/{parSafra}")>
    Public Function GetValuesSafra(parIdNegocios As Integer, parSafra As Integer) As IHttpActionResult
        Dim dados = GetIndustriaEnergiaBioPorSafraPlain(parIdNegocios, parSafra)

        Dim dadosAgrupados = GetIndustriaEnergiaBioAgrupadoPorSafra(dados)

        Return Ok(dadosAgrupados)
    End Function

    ' GET api/IndustriaEnergiaBio/PorSafraCorteDia/1/2017/20171110
    <HttpGet>
    <Route("PorSafraCorteDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValuesSafraCorteDia(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim dados = GetIndustriaEnergiaBioPorSafraCorteDiaPlain(parIdNegocios, parSafra, parDia)

        Dim dadosAgrupados = GetIndustriaEnergiaBioAgrupadoPorSafra(dados)

        Return Ok(dadosAgrupados)
    End Function

    
    Public Function GetIndustriaEnergiaBioPorSafraMinMaxDia(parIdNegocios As Integer) As Object
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            "SELECT MAX(SAFRA) SAFRA, MIN(DIA) MINDIA, MAX(DIA) MAXDIA, MAX(to_char(DIA + cast('0 '||HORA||':00:00' as interval day to second), 'YYYYMMDDHH24MI')) MAXDIAHORA, MIN(SEMANA) MINSEMANA, MAX(SEMANA) MAXSEMANA, MIN(MES) MINMES, MAX(MES) MAXMES FROM BI4T.INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR = 56 AND ID_NEGOCIOS = :p0",
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

        GetIndustriaEnergiaBioPorSafraMinMaxDia = New With {
            Key .safra = varSafra,
            Key .MinDia = varMinDia, 
            Key .MaxDia = varMaxDia, 
            Key .MaxHora = varMaxHora, 
            Key .MinSemana = varMinSemana, 
            Key .MaxSemana = varMaxSemana, 
            Key .MinMes = varMinMes, 
            Key .MaxMes = varMaxMes}
    End Function


    Public Function GetIndustriaEnergiaBioPorSafraPlain(parIdNegocios As Integer, parSafra As Integer) As List(Of S5TIndustriaEnergiaBio)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEnergiaBio & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra

        Return GetDados(conn, cmdDados)
    End Function

    Public Function GetIndustriaEnergiaBioPlanejadoPorSafraPlain(parIdNegocios As Integer, parSafra As Integer) As List(Of S5TIndustriaEnergiaBio)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEnergiaBioPlanejado & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra

        Return GetDados(conn, cmdDados)
    End Function


    Public Function GetIndustriaEnergiaBioPorSafraCorteDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As String) As List(Of S5TIndustriaEnergiaBio)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEnergiaBio & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA <= :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Date).Value = varDia

        Return GetDados(conn, cmdDados)
    End Function
    
    Public Function GetIndustriaEnergiaBioPorDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As DateTime) As List(Of S5TIndustriaEnergiaBio)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEnergiaBio & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Date).Value = parDia

        Return GetDados(conn, cmdDados)
    End Function

    Public Function GetIndustriaEnergiaBioPorSemanaPlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As List(Of S5TIndustriaEnergiaBio)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEnergiaBio & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana

        Return GetDados(conn, cmdDados)
    End Function

    Public Function GetIndustriaEnergiaBioPorMesPlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As List(Of S5TIndustriaEnergiaBio)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEnergiaBio & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Int16).Value = parMes

        Return GetDados(conn, cmdDados)
    End Function


    Private Function GetDados(parConnection As OracleConnection, parCommand As OracleCommand) As List(Of S5TIndustriaEnergiaBio)
        Dim dados As New List(Of S5TIndustriaEnergiaBio)

        parConnection.Open()

        Dim drDados As OracleDataReader = Nothing
        Try
            drDados = parCommand.ExecuteReader()
            If drDados.HasRows Then
                Do While drDados.Read
                    Dim objDados = New S5TIndustriaEnergiaBio

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

    Private Function GetValoresVisaoGeral(parDados As List(Of S5TIndustriaEnergiaBio), parDadosPlanejado As List(Of S5TIndustriaEnergiaBio), parPeriodo As Periodo) As S5TVisaoGeralAux
        Dim val = Math.Round(parDados.Sum(Function(x) x.VALOR_REAL), 0)

        Dim parDadosParaMeta As List(Of S5TIndustriaEnergiaBio)

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

    Private Function GetIndustriaEnergiaBioAgrupadoPorDiaHora(parDados As List(Of S5TIndustriaEnergiaBio)) As S5TIndustriaEnergiaBioAgrupadoPorDia
        Dim varDadosGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 56).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                    Key .HORA = x.HORA, _
                                                                                                                                    Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                                                                    Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaEnergiaBio With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                                                .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                                                                .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList
                                                                                                                                                                    
        Dim varDadosGeralAcumulado = GetIndustriaEnergiaBioAcumulado(varDadosGeral)

        Dim varDadosGeralPorHora = GetIndustriaEnergiaBioPorHora(varDadosGeral)

        Dim varHoraAtual = parDados.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().HORA
        Dim varHoraAnterior = varHoraAtual

        If varDadosGeral.Count > 1 Then
            varHoraAnterior = varDadosGeral.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA)(1).HORA
        End If

        GetIndustriaEnergiaBioAgrupadoPorDiaHora = New S5TIndustriaEnergiaBioAgrupadoPorDia With {
                                                                                                           .oGrafico = varDadosGeral, 
                                                                                                           .oGraficoAcumulado = varDadosGeralAcumulado, 
                                                                                                           .oGrid = varDadosGeralPorHora,
                                                                                                           .HoraAtual = varHoraAtual,
                                                                                                           .MediaHoraAnterior = GetMediaHoraAnterior(varDadosGeralPorHora, varHoraAtual)}
    End Function

    Private Function GetIndustriaEnergiaBioAgrupadoPorSemana(parDados As List(Of S5TIndustriaEnergiaBio)) As S5TIndustriaEnergiaBioAgrupadoPorSemana
        Dim varDadosGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 56).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date, _
                                                                                                                                    Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                                                                    Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaEnergiaBio With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                                                                .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosGeralAcumulado = GetIndustriaEnergiaBioAcumulado(varDadosGeral.OrderBy(Function(x) x.DIA.Date).ToList)

        Dim varDadosGeralPorDia = GetIndustriaEnergiaBioPorDia(varDadosGeral)

        Dim varDiaAtual = parDados.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().DIA.Date

        GetIndustriaEnergiaBioAgrupadoPorSemana = New S5TIndustriaEnergiaBioAgrupadoPorSemana With {
                                                                                                            .oGrafico = varDadosGeral.OrderBy(Function(x) x.DIA.Date).ToList, 
                                                                                                            .oGraficoAcumulado = varDadosGeralAcumulado, 
                                                                                                            .oGrid = varDadosGeralPorDia,
                                                                                                            .DiaAtual = varDiaAtual}
    End Function

    Private Function GetIndustriaEnergiaBioAgrupadoPorMes(parDados As List(Of S5TIndustriaEnergiaBio)) As S5TIndustriaEnergiaBioAgrupadoPorMes
        Dim varDadosGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 56).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaEnergiaBio With {
                                                                                                                                                                                                                  .SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                  .semanaPeriodo = New S5TIndustriaEnergiaBioSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                  .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                  .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosGeralAcumulado = GetIndustriaEnergiaBioAcumulado(varDadosGeral.OrderBy(Function(x) x.SEMANA).ToList)

        Dim varDadosGeralPorSemana = GetIndustriaEnergiaBioPorSemana(varDadosGeral)

        Dim varSemanaAtual = parDados.OrderByDescending(Function(x) x.SEMANA).FirstOrDefault().SEMANA

        GetIndustriaEnergiaBioAgrupadoPorMes = New S5TIndustriaEnergiaBioAgrupadoPorMes With {
                                                                                                        .oGrafico = varDadosGeral.OrderBy(Function(x) x.SEMANA).ToList, 
                                                                                                        .oGraficoAcumulado = varDadosGeralAcumulado, 
                                                                                                        .oGrid = varDadosGeralPorSemana,
                                                                                                        .SemanaAtual = varSemanaAtual}
    End Function

    Private Function GetIndustriaEnergiaBioAgrupadoPorSafra(parDados As List(Of S5TIndustriaEnergiaBio)) As S5TIndustriaEnergiaBioAgrupadoPorSafra
        Dim varDadosGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 56).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaEnergiaBio With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                            .DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                            .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                            .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosGeralAcumulado = GetIndustriaEnergiaBioAcumulado(varDadosGeral.OrderBy(Function(x) x.MES).ToList)

        Dim varDadosGeralPorMes = GetIndustriaEnergiaBioPorMes(varDadosGeral)

        Dim varMesAtual = parDados.OrderByDescending(Function(x) x.MES).FirstOrDefault().MES

        GetIndustriaEnergiaBioAgrupadoPorSafra = New S5TIndustriaEnergiaBioAgrupadoPorSafra With {
                                                                                                           .oGrafico = varDadosGeral.OrderBy(Function(x) x.MES).ToList, 
                                                                                                           .oGraficoAcumulado = varDadosGeralAcumulado, 
                                                                                                           .oGrid = varDadosGeralPorMes,
                                                                                                           .MesAtual = varMesAtual}
    End Function


    Private Function GetIndustriaEnergiaBioAcumulado(parIndustriaEnergiaBio As List(Of S5TIndustriaEnergiaBio)) As List(Of S5TIndustriaEnergiaBio)
        Dim parIndustriaEnergiaBioOrdenado = parIndustriaEnergiaBio.OrderBy(Function(x) x.DIA).OrderBy(Function(x) x.HORA)

        Dim varIndustriaEnergiaBioAcumulado = New List(Of S5TIndustriaEnergiaBio)

        Dim varPlanejadoAcumulado As Double = 0
        Dim varRealizadoAcumulado As Double = 0

        For Each objIndustriaEnergiaBio In parIndustriaEnergiaBioOrdenado
            varPlanejadoAcumulado += Math.Round(objIndustriaEnergiaBio.VALOR_PLAN,0)
            varRealizadoAcumulado += Math.Round(objIndustriaEnergiaBio.VALOR_REAL,0)

            varIndustriaEnergiaBioAcumulado.Add(New S5TIndustriaEnergiaBio() With {
                                                .ID_NEGOCIOS = objIndustriaEnergiaBio.ID_NEGOCIOS,
                                                .SAFRA = objIndustriaEnergiaBio.SAFRA,
                                                .MES = objIndustriaEnergiaBio.MES,
                                                .SEMANA = objIndustriaEnergiaBio.SEMANA,
                                                .semanaPeriodo = objIndustriaEnergiaBio.semanaPeriodo,
                                                .DIA = objIndustriaEnergiaBio.DIA,
                                                .HORA = objIndustriaEnergiaBio.HORA,
                                                .ID_CA_INDICADOR = objIndustriaEnergiaBio.ID_CA_INDICADOR,
                                                .DS_CA_INDICADOR = objIndustriaEnergiaBio.DS_CA_INDICADOR,
                                                .MOENDA = objIndustriaEnergiaBio.MOENDA,
                                                .VALOR_PLAN = varPlanejadoAcumulado,
                                                .VALOR_REAL = varRealizadoAcumulado
                                            })
        Next

        GetIndustriaEnergiaBioAcumulado = varIndustriaEnergiaBioAcumulado
    End Function

    Private Function GetIndustriaEnergiaBioPorHora(parDadosPorDia As List(Of S5TIndustriaEnergiaBio)) As List(Of S5TIndustriaEnergiaBioPorHora)
        Dim varIndustriaEnergiaBioPorHora = New List(Of S5TIndustriaEnergiaBioPorHora)

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

        Dim obj01PlanejadoPorHora = New S5TIndustriaEnergiaBioPorHora With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Horário (MWh)",
                                                                        .H00 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH00),
                                                                        .H01 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH01),
                                                                        .H02 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH02),
                                                                        .H03 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH03),
                                                                        .H04 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH04),
                                                                        .H05 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH05),
                                                                        .H06 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH06),
                                                                        .H07 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH07),
                                                                        .H08 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH08),
                                                                        .H09 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH09),
                                                                        .H10 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH10),
                                                                        .H11 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH11),
                                                                        .H12 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH12),
                                                                        .H13 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH13),
                                                                        .H14 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH14),
                                                                        .H15 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH15),
                                                                        .H16 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH16),
                                                                        .H17 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH17),
                                                                        .H18 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH18),
                                                                        .H19 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH19),
                                                                        .H20 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH20),
                                                                        .H21 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH21),
                                                                        .H22 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH22),
                                                                        .H23 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH23)
                                                                        }

        Dim obj02PlanejadoAcumuladoPorHora = New S5TIndustriaEnergiaBioPorHora With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (MWh)",
                                                                        .H00 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 0),
                                                                        .H01 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 1),
                                                                        .H02 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 2),
                                                                        .H03 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 3),
                                                                        .H04 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 4),
                                                                        .H05 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 5),
                                                                        .H06 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 6),
                                                                        .H07 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 7),
                                                                        .H08 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 8),
                                                                        .H09 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 9),
                                                                        .H10 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 10),
                                                                        .H11 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 11),
                                                                        .H12 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 12),
                                                                        .H13 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 13),
                                                                        .H14 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 14),
                                                                        .H15 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 15),
                                                                        .H16 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 16),
                                                                        .H17 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 17),
                                                                        .H18 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 18),
                                                                        .H19 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 19),
                                                                        .H20 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 20),
                                                                        .H21 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 21),
                                                                        .H22 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 22),
                                                                        .H23 = GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 23)
                                                                        }


        Dim obj03RealizadoPorHora = New S5TIndustriaEnergiaBioPorHora With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Diário (MWh)",
                                                                        .H00 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH00),
                                                                        .H01 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH01),
                                                                        .H02 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH02),
                                                                        .H03 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH03),
                                                                        .H04 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH04),
                                                                        .H05 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH05),
                                                                        .H06 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH06),
                                                                        .H07 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH07),
                                                                        .H08 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH08),
                                                                        .H09 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH09),
                                                                        .H10 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH10),
                                                                        .H11 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH11),
                                                                        .H12 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH12),
                                                                        .H13 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH13),
                                                                        .H14 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH14),
                                                                        .H15 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH15),
                                                                        .H16 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH16),
                                                                        .H17 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH17),
                                                                        .H18 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH18),
                                                                        .H19 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH19),
                                                                        .H20 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH20),
                                                                        .H21 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH21),
                                                                        .H22 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH22),
                                                                        .H23 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH23)
                                                                        }

        Dim obj04RealizadoAcumuladoPorHora = New S5TIndustriaEnergiaBioPorHora With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (MWh)",
                                                                        .H00 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 0),
                                                                        .H01 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 1),
                                                                        .H02 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 2),
                                                                        .H03 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 3),
                                                                        .H04 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 4),
                                                                        .H05 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 5),
                                                                        .H06 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 6),
                                                                        .H07 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 7),
                                                                        .H08 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 8),
                                                                        .H09 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 9),
                                                                        .H10 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 10),
                                                                        .H11 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 11),
                                                                        .H12 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 12),
                                                                        .H13 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 13),
                                                                        .H14 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 14),
                                                                        .H15 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 15),
                                                                        .H16 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 16),
                                                                        .H17 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 17),
                                                                        .H18 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 18),
                                                                        .H19 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 19),
                                                                        .H20 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 20),
                                                                        .H21 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 21),
                                                                        .H22 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 22),
                                                                        .H23 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 23)
                                                                        }

        Dim obj05RealizadoMenosPlanejadoPorHora = New S5TIndustriaEnergiaBioPorHora With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Diário (MWh)",
                                                                                        .H00 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH00) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH00),
                                                                                        .H01 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH01) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH01),
                                                                                        .H02 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH02) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH02),
                                                                                        .H03 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH03) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH03),
                                                                                        .H04 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH04) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH04),
                                                                                        .H05 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH05) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH05),
                                                                                        .H06 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH06) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH06),
                                                                                        .H07 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH07) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH07),
                                                                                        .H08 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH08) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH08),
                                                                                        .H09 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH09) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH09),
                                                                                        .H10 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH10) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH10),
                                                                                        .H11 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH11) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH11),
                                                                                        .H12 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH12) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH12),
                                                                                        .H13 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH13) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH13),
                                                                                        .H14 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH14) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH14),
                                                                                        .H15 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH15) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH15),
                                                                                        .H16 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH16) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH16),
                                                                                        .H17 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH17) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH17),
                                                                                        .H18 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH18) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH18),
                                                                                        .H19 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH19) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH19),
                                                                                        .H20 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH20) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH20),
                                                                                        .H21 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH21) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH21),
                                                                                        .H22 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH22) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH22),
                                                                                        .H23 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjH23) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjH23)
            }

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorHora = New S5TIndustriaEnergiaBioPorHora With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (MWh)",
                                                                                .H00 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 0) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 0),
                                                                                .H01 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 1) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 1),
                                                                                .H02 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 2) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 2),
                                                                                .H03 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 3) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 3),
                                                                                .H04 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 4) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 4),
                                                                                .H05 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 5) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 5),
                                                                                .H06 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 6) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 6),
                                                                                .H07 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 7) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 7),
                                                                                .H08 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 8) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 8),
                                                                                .H09 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 9) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 9),
                                                                                .H10 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 10) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 10),
                                                                                .H11 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 11) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 11),
                                                                                .H12 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 12) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 12),
                                                                                .H13 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 13) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 13),
                                                                                .H14 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 14) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 14),
                                                                                .H15 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 15) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 15),
                                                                                .H16 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 16) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 16),
                                                                                .H17 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 17) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 17),
                                                                                .H18 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 18) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 18),
                                                                                .H19 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 19) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 19),
                                                                                .H20 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 20) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 20),
                                                                                .H21 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 21) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 21),
                                                                                .H22 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 22) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 22),
                                                                                .H23 = GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 23) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 23)
        }

        Dim obj07DesvioPercentual = New S5TIndustriaEnergiaBioPorHora With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .H00 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 0) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 0) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 0)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 0), 4)),
                                                        .H01 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 1) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 1) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 1)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 1), 4)),
                                                        .H02 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 2) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 2) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 2)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 2), 4)),
                                                        .H03 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 3) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 3) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 3)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 3), 4)),
                                                        .H04 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 4) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 4) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 4)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 4), 4)),
                                                        .H05 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 5) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 5) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 5)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 5), 4)),
                                                        .H06 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 6) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 6) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 6)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 6), 4)),
                                                        .H07 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 7) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 7) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 7)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 7), 4)),
                                                        .H08 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 8) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 8) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 8)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 8), 4)),
                                                        .H09 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 9) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 9) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 9)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 9), 4)),
                                                        .H10 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 10) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 10) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 10)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 10), 4)),
                                                        .H11 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 11) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 11) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 11)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 11), 4)),
                                                        .H12 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 12) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 12) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 12)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 12), 4)),
                                                        .H13 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 13) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 13) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 13)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 13), 4)),
                                                        .H14 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 14) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 14) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 14)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 14), 4)),
                                                        .H15 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 15) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 15) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 15)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 15), 4)),
                                                        .H16 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 16) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 16) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 16)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 16), 4)),
                                                        .H17 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 17) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 17) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 17)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 17), 4)),
                                                        .H18 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 18) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 18) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 18)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 18), 4)),
                                                        .H19 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 19) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 19) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 19)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 19), 4)),
                                                        .H20 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 20) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 20) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 20)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 20), 4)),
                                                        .H21 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 21) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 21) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 21)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 21), 4)),
                                                        .H22 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 22) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 22) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 22)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 22), 4)),
                                                        .H23 = IIf(GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 23) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorHoraAcumulado(obj03RealizadoPorHora, 23) - GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 23)) / GetIndustriaEnergiaBioPorHoraAcumulado(obj01PlanejadoPorHora, 23), 4))
            }

        Dim objCoeficienteAngular = New S5TIndustriaEnergiaBioPorHora With {
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

        varIndustriaEnergiaBioPorHora.Add(obj01PlanejadoPorHora)
        varIndustriaEnergiaBioPorHora.Add(obj02PlanejadoAcumuladoPorHora)

        varIndustriaEnergiaBioPorHora.Add(obj03RealizadoPorHora)
        varIndustriaEnergiaBioPorHora.Add(obj04RealizadoAcumuladoPorHora)

        varIndustriaEnergiaBioPorHora.Add(obj05RealizadoMenosPlanejadoPorHora)
        varIndustriaEnergiaBioPorHora.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorHora)
        varIndustriaEnergiaBioPorHora.Add(obj07DesvioPercentual)
        varIndustriaEnergiaBioPorHora.Add(objCoeficienteAngular)

        GetIndustriaEnergiaBioPorHora = varIndustriaEnergiaBioPorHora
    End Function

    Private Function GetIndustriaEnergiaBioPorDia(parDadosPorDia As List(Of S5TIndustriaEnergiaBio)) As List(Of S5TIndustriaEnergiaBioPorDia)
        Dim varIndustriaEnergiaBioPorDia = New List(Of S5TIndustriaEnergiaBioPorDia)

        Dim dadosPorDia = parDadosPorDia.OrderBy(Function(x) x.DIA.Date)

        Dim varObjDia01 = Iif(dadosPorDia.Count() > 0, dadosPorDia(0), Nothing)
        Dim varObjDia02 = Iif(dadosPorDia.Count() > 1, dadosPorDia(1), Nothing)
        Dim varObjDia03 = Iif(dadosPorDia.Count() > 2, dadosPorDia(2), Nothing)
        Dim varObjDia04 = Iif(dadosPorDia.Count() > 3, dadosPorDia(3), Nothing)
        Dim varObjDia05 = Iif(dadosPorDia.Count() > 4, dadosPorDia(4), Nothing)
        Dim varObjDia06 = Iif(dadosPorDia.Count() > 5, dadosPorDia(5), Nothing)
        Dim varObjDia07 = Iif(dadosPorDia.Count() > 6, dadosPorDia(6), Nothing)

        Dim obj01PlanejadoPorDia = New S5TIndustriaEnergiaBioPorDia With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Diário (MWh)",
                                                                        .DIA1 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia01),
                                                                        .DIA2 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia02),
                                                                        .DIA3 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia03),
                                                                        .DIA4 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia04),
                                                                        .DIA5 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia05),
                                                                        .DIA6 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia06),
                                                                        .DIA7 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia07)}

        Dim obj02PlanejadoAcumuladoPorDia = New S5TIndustriaEnergiaBioPorDia With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (MWh)",
                                                                        .DIA1 = GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 1),
                                                                        .DIA2 = GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 2),
                                                                        .DIA3 = GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 3),
                                                                        .DIA4 = GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 4),
                                                                        .DIA5 = GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 5),
                                                                        .DIA6 = GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 6),
                                                                        .DIA7 = GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 7)}

        Dim obj03RealizadoPorDia = New S5TIndustriaEnergiaBioPorDia With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Diário (MWh)",
                                                                        .DIA1 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia01),
                                                                        .DIA2 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia02),
                                                                        .DIA3 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia03),
                                                                        .DIA4 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia04),
                                                                        .DIA5 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia05),
                                                                        .DIA6 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia06),
                                                                        .DIA7 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia07)}

        Dim obj04RealizadoAcumuladoPorDia = New S5TIndustriaEnergiaBioPorDia With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (MWh)",
                                                                        .DIA1 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 1),
                                                                        .DIA2 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 2),
                                                                        .DIA3 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 3),
                                                                        .DIA4 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 4),
                                                                        .DIA5 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 5),
                                                                        .DIA6 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 6),
                                                                        .DIA7 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 7)}

        Dim obj05RealizadoMenosPlanejadoPorDia = New S5TIndustriaEnergiaBioPorDia With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Diário (MWh)",
                                                                                        .DIA1 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia01) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia01),
                                                                                        .DIA2 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia02) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia02),
                                                                                        .DIA3 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia03) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia03),
                                                                                        .DIA4 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia04) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia04),
                                                                                        .DIA5 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia05) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia05),
                                                                                        .DIA6 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia06) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia06),
                                                                                        .DIA7 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjDia07) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjDia07)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorDia = New S5TIndustriaEnergiaBioPorDia With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (MWh)",
                                                                                .DIA1 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 1) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 1),
                                                                                .DIA2 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 2) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 2),
                                                                                .DIA3 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 3) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 3),
                                                                                .DIA4 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 4) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 4),
                                                                                .DIA5 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 5) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 5),
                                                                                .DIA6 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 6) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 6),
                                                                                .DIA7 = GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 7) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 7)}

        Dim obj07DesvioPercentual = New S5TIndustriaEnergiaBioPorDia With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .DIA1 = IIf(GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 1) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 1) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 1)) / GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 1), 4)),
                                                        .DIA2 = IIf(GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 2) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 2) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 2)) / GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 2), 4)),
                                                        .DIA3 = IIf(GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 3) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 3) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 3)) / GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 3), 4)),
                                                        .DIA4 = IIf(GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 4) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 4) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 4)) / GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 4), 4)),
                                                        .DIA5 = IIf(GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 5) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 5) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 5)) / GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 5), 4)),
                                                        .DIA6 = IIf(GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 6) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 6) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 6)) / GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 6), 4)),
                                                        .DIA7 = IIf(GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 7) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorDiaAcumulado(obj03RealizadoPorDia, 7) - GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 7)) / GetIndustriaEnergiaBioPorDiaAcumulado(obj01PlanejadoPorDia, 7), 4))}

        varIndustriaEnergiaBioPorDia.Add(obj01PlanejadoPorDia)
        varIndustriaEnergiaBioPorDia.Add(obj02PlanejadoAcumuladoPorDia)

        varIndustriaEnergiaBioPorDia.Add(obj03RealizadoPorDia)
        varIndustriaEnergiaBioPorDia.Add(obj04RealizadoAcumuladoPorDia)

        varIndustriaEnergiaBioPorDia.Add(obj05RealizadoMenosPlanejadoPorDia)
        varIndustriaEnergiaBioPorDia.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorDia)
        varIndustriaEnergiaBioPorDia.Add(obj07DesvioPercentual)

        GetIndustriaEnergiaBioPorDia = varIndustriaEnergiaBioPorDia
    End Function

    Private Function GetIndustriaEnergiaBioPorSemana(parDados As List(Of S5TIndustriaEnergiaBio)) As List(Of S5TIndustriaEnergiaBioPorSemana)
        Dim varIndustriaEnergiaBioPorSemana = New List(Of S5TIndustriaEnergiaBioPorSemana)

        Dim dadosPorSemana = parDados.GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaEnergiaBio With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                          .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                          .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).OrderBy(Function(x) x.SEMANA).ToList()


        Dim varObjSemana1 As S5TIndustriaEnergiaBio = Nothing
        Dim varObjSemana2 As S5TIndustriaEnergiaBio = Nothing
        Dim varObjSemana3 As S5TIndustriaEnergiaBio = Nothing
        Dim varObjSemana4 As S5TIndustriaEnergiaBio = Nothing
        Dim varObjSemana5 As S5TIndustriaEnergiaBio = Nothing
        Dim varObjSemana6 As S5TIndustriaEnergiaBio = Nothing

        If dadosPorSemana.Count() > 0 Then varObjSemana1 = dadosPorSemana(0)
        If dadosPorSemana.Count() > 1 Then varObjSemana2 = dadosPorSemana(1)
        If dadosPorSemana.Count() > 2 Then varObjSemana3 = dadosPorSemana(2)
        If dadosPorSemana.Count() > 3 Then varObjSemana4 = dadosPorSemana(3)
        If dadosPorSemana.Count() > 4 Then varObjSemana5 = dadosPorSemana(4)
        If dadosPorSemana.Count() > 5 Then varObjSemana6 = dadosPorSemana(5)

        Dim obj01PlanejadoPorSemana = New S5TIndustriaEnergiaBioPorSemana With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Semanal (MWh)",
                                                                        .SEMANA1 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana1),
                                                                        .SEMANA2 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana2),
                                                                        .SEMANA3 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana3),
                                                                        .SEMANA4 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana4),
                                                                        .SEMANA5 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana5),
                                                                        .SEMANA6 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana6)}

        Dim obj02PlanejadoAcumuladoPorSemana = New S5TIndustriaEnergiaBioPorSemana With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (MWh)",
                                                                        .SEMANA1 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 1),
                                                                        .SEMANA2 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 2),
                                                                        .SEMANA3 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 3),
                                                                        .SEMANA4 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 4),
                                                                        .SEMANA5 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 5),
                                                                        .SEMANA6 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 6)}

        Dim obj03RealizadoPorSemana = New S5TIndustriaEnergiaBioPorSemana With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Semanal (MWh)",
                                                                        .SEMANA1 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana1),
                                                                        .SEMANA2 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana2),
                                                                        .SEMANA3 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana3),
                                                                        .SEMANA4 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana4),
                                                                        .SEMANA5 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana5),
                                                                        .SEMANA6 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana6)}

        Dim obj04RealizadoAcumuladoPorSemana = New S5TIndustriaEnergiaBioPorSemana With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (MWh)",
                                                                        .SEMANA1 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 1),
                                                                        .SEMANA2 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 2),
                                                                        .SEMANA3 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 3),
                                                                        .SEMANA4 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 4),
                                                                        .SEMANA5 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 5),
                                                                        .SEMANA6 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 6)}

        Dim obj05RealizadoMenosPlanejadoPorSemana = New S5TIndustriaEnergiaBioPorSemana With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Semanal (MWh)",
                                                                                        .SEMANA1 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana1) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana1),
                                                                                        .SEMANA2 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana2) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana2),
                                                                                        .SEMANA3 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana3) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana3),
                                                                                        .SEMANA4 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana4) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana4),
                                                                                        .SEMANA5 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana5) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana5),
                                                                                        .SEMANA6 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjSemana6) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjSemana6)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorSemana = New S5TIndustriaEnergiaBioPorSemana With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (MWh)",
                                                                                .SEMANA1 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 1) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 1),
                                                                                .SEMANA2 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 2) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 2),
                                                                                .SEMANA3 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 3) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 3),
                                                                                .SEMANA4 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 4) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 4),
                                                                                .SEMANA5 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 5) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 5),
                                                                                .SEMANA6 = GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 6) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 6)}

        Dim obj07DesvioPercentual = New S5TIndustriaEnergiaBioPorSemana With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .SEMANA1 = IIf(GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 1) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 1) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 1)) / GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 1), 4)),
                                                        .SEMANA2 = IIf(GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 2) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 2) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 2)) / GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 2), 4)),
                                                        .SEMANA3 = IIf(GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 3) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 3) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 3)) / GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 3), 4)),
                                                        .SEMANA4 = IIf(GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 4) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 4) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 4)) / GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 4), 4)),
                                                        .SEMANA5 = IIf(GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 5) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 5) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 5)) / GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 5), 4)),
                                                        .SEMANA6 = IIf(GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 6) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorSemanaAcumulado(obj03RealizadoPorSemana, 6) - GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 6)) / GetIndustriaEnergiaBioPorSemanaAcumulado(obj01PlanejadoPorSemana, 6), 4))}

        varIndustriaEnergiaBioPorSemana.Add(obj01PlanejadoPorSemana)
        varIndustriaEnergiaBioPorSemana.Add(obj02PlanejadoAcumuladoPorSemana)

        varIndustriaEnergiaBioPorSemana.Add(obj03RealizadoPorSemana)
        varIndustriaEnergiaBioPorSemana.Add(obj04RealizadoAcumuladoPorSemana)

        varIndustriaEnergiaBioPorSemana.Add(obj05RealizadoMenosPlanejadoPorSemana)
        varIndustriaEnergiaBioPorSemana.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorSemana)
        varIndustriaEnergiaBioPorSemana.Add(obj07DesvioPercentual)

        GetIndustriaEnergiaBioPorSemana = varIndustriaEnergiaBioPorSemana
    End Function

    Private Function GetIndustriaEnergiaBioPorMes(parDados As List(Of S5TIndustriaEnergiaBio)) As List(Of S5TIndustriaEnergiaBioPorMes)
        Dim varIndustriaEnergiaBioPorMes = New List(Of S5TIndustriaEnergiaBioPorMes)

        Dim dadosPorMes = parDados.GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaEnergiaBio With {.MES = y.Min(Function(group) group.MES), _
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

        Dim obj01PlanejadoPorMes = New S5TIndustriaEnergiaBioPorMes With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Mensal (MWh)",
                                                                        .MES1 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes01),
                                                                        .MES2 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes02),
                                                                        .MES3 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes03),
                                                                        .MES4 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes04),
                                                                        .MES5 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes05),
                                                                        .MES6 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes06),
                                                                        .MES7 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes07),
                                                                        .MES8 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes08),
                                                                        .MES9 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes09),
                                                                        .MES10 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes10),
                                                                        .MES11 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes11),
                                                                        .MES12 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes12)}

        Dim obj02PlanejadoAcumuladoPorMes = New S5TIndustriaEnergiaBioPorMes With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (MWh)",
                                                                        .MES1 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 1),
                                                                        .MES2 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 2),
                                                                        .MES3 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 3),
                                                                        .MES4 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 4),
                                                                        .MES5 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 5),
                                                                        .MES6 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 6),
                                                                        .MES7 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 7),
                                                                        .MES8 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 8),
                                                                        .MES9 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 9),
                                                                        .MES10 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 10),
                                                                        .MES11 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 11),
                                                                        .MES12 = GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 12)}

        Dim obj03RealizadoPorMes = New S5TIndustriaEnergiaBioPorMes With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Mensal (MWh)",
                                                                        .MES1 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes01),
                                                                        .MES2 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes02),
                                                                        .MES3 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes03),
                                                                        .MES4 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes04),
                                                                        .MES5 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes05),
                                                                        .MES6 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes06),
                                                                        .MES7 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes07),
                                                                        .MES8 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes08),
                                                                        .MES9 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes09),
                                                                        .MES10 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes10),
                                                                        .MES11 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes11),
                                                                        .MES12 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes12)}

        Dim obj04RealizadoAcumuladoPorMes = New S5TIndustriaEnergiaBioPorMes With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (MWh)",
                                                                        .MES1 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 1),
                                                                        .MES2 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 2),
                                                                        .MES3 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 3),
                                                                        .MES4 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 4),
                                                                        .MES5 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 5),
                                                                        .MES6 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 6),
                                                                        .MES7 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 7),
                                                                        .MES8 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 8),
                                                                        .MES9 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 9),
                                                                        .MES10 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 10),
                                                                        .MES11 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 11),
                                                                        .MES12 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 12)}

        Dim obj05RealizadoMenosPlanejadoPorMes = New S5TIndustriaEnergiaBioPorMes With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Mensal (MWh)",
                                                                                        .MES1 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes01) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes01),
                                                                                        .MES2 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes02) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes02),
                                                                                        .MES3 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes03) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes03),
                                                                                        .MES4 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes04) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes04),
                                                                                        .MES5 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes05) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes05),
                                                                                        .MES6 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes06) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes06),
                                                                                        .MES7 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes07) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes07),
                                                                                        .MES8 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes08) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes08),
                                                                                        .MES9 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes09) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes09),
                                                                                        .MES10 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes10) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes10),
                                                                                        .MES11 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes11) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes11),
                                                                                        .MES12 = GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorRealizado, varObjMes12) - GetInfoObjIndustriaEnergiaBio(TipoCampo.ValorPlanejado, varObjMes12)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorMes = New S5TIndustriaEnergiaBioPorMes With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (MWh)",
                                                                                .MES1 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 1) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 1),
                                                                                .MES2 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 2) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 2),
                                                                                .MES3 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 3) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 3),
                                                                                .MES4 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 4) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 4),
                                                                                .MES5 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 5) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 5),
                                                                                .MES6 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 6) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 6),
                                                                                .MES7 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 7) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 7),
                                                                                .MES8 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 8) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 8),
                                                                                .MES9 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 9) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 9),
                                                                                .MES10 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 10) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 10),
                                                                                .MES11 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 11) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 11),
                                                                                .MES12 = GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 12) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 12)}

        Dim obj07DesvioPercentual = New S5TIndustriaEnergiaBioPorMes With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .MES1 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 1) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 1) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 1)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 1), 4)),
                                                        .MES2 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 2) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 2) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 2)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 2), 4)),
                                                        .MES3 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 3) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 3) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 3)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 3), 4)),
                                                        .MES4 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 4) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 4) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 4)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 4), 4)),
                                                        .MES5 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 5) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 5) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 5)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 5), 4)),
                                                        .MES6 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 6) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 6) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 6)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 6), 4)),
                                                        .MES7 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 7) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 7) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 7)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 7), 4)),
                                                        .MES8 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 8) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 8) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 8)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 8), 4)),
                                                        .MES9 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 9) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 9) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 9)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 9), 4)),
                                                        .MES10 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 10) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 10) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 10)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 10), 4)),
                                                        .MES11 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 11) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 11) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 11)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 11), 4)),
                                                        .MES12 = IIf(GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 12) = 0, 0, Math.Round((GetIndustriaEnergiaBioPorMesAcumulado(obj03RealizadoPorMes, 12) - GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 12)) / GetIndustriaEnergiaBioPorMesAcumulado(obj01PlanejadoPorMes, 12), 4))}

        varIndustriaEnergiaBioPorMes.Add(obj01PlanejadoPorMes)
        varIndustriaEnergiaBioPorMes.Add(obj02PlanejadoAcumuladoPorMes)

        varIndustriaEnergiaBioPorMes.Add(obj03RealizadoPorMes)
        varIndustriaEnergiaBioPorMes.Add(obj04RealizadoAcumuladoPorMes)

        varIndustriaEnergiaBioPorMes.Add(obj05RealizadoMenosPlanejadoPorMes)
        varIndustriaEnergiaBioPorMes.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorMes)
        varIndustriaEnergiaBioPorMes.Add(obj07DesvioPercentual)

        GetIndustriaEnergiaBioPorMes = varIndustriaEnergiaBioPorMes
    End Function


    Private Function GetIndustriaEnergiaBioPorHoraAcumulado(parIndustriaEnergiaBioPorHora As S5TIndustriaEnergiaBioPorHora, parHora As Integer) As Double
        Dim varValor = 0

        Select Case parHora
            Case 0
                varValor = parIndustriaEnergiaBioPorHora.H00
            Case 1
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01
            Case 2
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02
            Case 3
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03
            Case 4
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04
            Case 5
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05
            Case 6
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06
            Case 7
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07
            Case 8
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08
            Case 9
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09
            Case 10
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10
            Case 11
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11
            Case 12
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12
            Case 13
                varValor = parIndustriaEnergiaBioPorHora.H00 + 
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13
            Case 14
                varValor = parIndustriaEnergiaBioPorHora.H00 +
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13 +
                           parIndustriaEnergiaBioPorHora.H14
            Case 15
                varValor = parIndustriaEnergiaBioPorHora.H00 +
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13 +
                           parIndustriaEnergiaBioPorHora.H14 +
                           parIndustriaEnergiaBioPorHora.H15
            Case 16
                varValor = parIndustriaEnergiaBioPorHora.H00 +
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13 +
                           parIndustriaEnergiaBioPorHora.H14 +
                           parIndustriaEnergiaBioPorHora.H15 +
                           parIndustriaEnergiaBioPorHora.H16
            Case 17
                varValor = parIndustriaEnergiaBioPorHora.H00 +
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13 +
                           parIndustriaEnergiaBioPorHora.H14 +
                           parIndustriaEnergiaBioPorHora.H15 +
                           parIndustriaEnergiaBioPorHora.H16 +
                           parIndustriaEnergiaBioPorHora.H17
            Case 18
                varValor = parIndustriaEnergiaBioPorHora.H00 +
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13 +
                           parIndustriaEnergiaBioPorHora.H14 +
                           parIndustriaEnergiaBioPorHora.H15 +
                           parIndustriaEnergiaBioPorHora.H16 +
                           parIndustriaEnergiaBioPorHora.H17 +
                           parIndustriaEnergiaBioPorHora.H18
            Case 19
                varValor = parIndustriaEnergiaBioPorHora.H00 +
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13 +
                           parIndustriaEnergiaBioPorHora.H14 +
                           parIndustriaEnergiaBioPorHora.H15 +
                           parIndustriaEnergiaBioPorHora.H16 +
                           parIndustriaEnergiaBioPorHora.H17 +
                           parIndustriaEnergiaBioPorHora.H18 +
                           parIndustriaEnergiaBioPorHora.H19
            Case 20
                varValor = parIndustriaEnergiaBioPorHora.H00 +
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13 +
                           parIndustriaEnergiaBioPorHora.H14 +
                           parIndustriaEnergiaBioPorHora.H15 +
                           parIndustriaEnergiaBioPorHora.H16 +
                           parIndustriaEnergiaBioPorHora.H17 +
                           parIndustriaEnergiaBioPorHora.H18 +
                           parIndustriaEnergiaBioPorHora.H19 +
                           parIndustriaEnergiaBioPorHora.H20
            Case 21
                varValor = parIndustriaEnergiaBioPorHora.H00 +
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13 +
                           parIndustriaEnergiaBioPorHora.H14 +
                           parIndustriaEnergiaBioPorHora.H15 +
                           parIndustriaEnergiaBioPorHora.H16 +
                           parIndustriaEnergiaBioPorHora.H17 +
                           parIndustriaEnergiaBioPorHora.H18 +
                           parIndustriaEnergiaBioPorHora.H19 +
                           parIndustriaEnergiaBioPorHora.H20 +
                           parIndustriaEnergiaBioPorHora.H21
            Case 22
                varValor = parIndustriaEnergiaBioPorHora.H00 +
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13 +
                           parIndustriaEnergiaBioPorHora.H14 +
                           parIndustriaEnergiaBioPorHora.H15 +
                           parIndustriaEnergiaBioPorHora.H16 +
                           parIndustriaEnergiaBioPorHora.H17 +
                           parIndustriaEnergiaBioPorHora.H18 +
                           parIndustriaEnergiaBioPorHora.H19 +
                           parIndustriaEnergiaBioPorHora.H20 +
                           parIndustriaEnergiaBioPorHora.H21 +
                           parIndustriaEnergiaBioPorHora.H22
            Case 23
                varValor = parIndustriaEnergiaBioPorHora.H00 +
                           parIndustriaEnergiaBioPorHora.H01 +
                           parIndustriaEnergiaBioPorHora.H02 +
                           parIndustriaEnergiaBioPorHora.H03 +
                           parIndustriaEnergiaBioPorHora.H04 +
                           parIndustriaEnergiaBioPorHora.H05 +
                           parIndustriaEnergiaBioPorHora.H06 +
                           parIndustriaEnergiaBioPorHora.H07 +
                           parIndustriaEnergiaBioPorHora.H08 +
                           parIndustriaEnergiaBioPorHora.H09 +
                           parIndustriaEnergiaBioPorHora.H10 +
                           parIndustriaEnergiaBioPorHora.H11 +
                           parIndustriaEnergiaBioPorHora.H12 +
                           parIndustriaEnergiaBioPorHora.H13 +
                           parIndustriaEnergiaBioPorHora.H14 +
                           parIndustriaEnergiaBioPorHora.H15 +
                           parIndustriaEnergiaBioPorHora.H16 +
                           parIndustriaEnergiaBioPorHora.H17 +
                           parIndustriaEnergiaBioPorHora.H18 +
                           parIndustriaEnergiaBioPorHora.H19 +
                           parIndustriaEnergiaBioPorHora.H20 +
                           parIndustriaEnergiaBioPorHora.H21 +
                           parIndustriaEnergiaBioPorHora.H22 +
                           parIndustriaEnergiaBioPorHora.H23
        End Select

        GetIndustriaEnergiaBioPorHoraAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustraPorHoraCoeficienteAngular(parIndustriaEnergiaBioPorHora As S5TIndustriaEnergiaBioPorHora, parHora As Integer) As Double
        GetIndustraPorHoraCoeficienteAngular = 0

        Dim t as Type = parIndustriaEnergiaBioPorHora.GetType()

        If parHora >= 1 Then
            Dim varNomePropriedadeHoraAtual = "H" & (parHora.ToString).PadLeft(2,"0")
            Dim varHoraAtualMenos1 = "H" & ((parHora - 1).ToString).PadLeft(2,"0")
            Dim fieldHoraAtual As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtual)
            Dim fieldHoraMenos1 As PropertyInfo = t.GetProperty(varHoraAtualMenos1)

            If fieldHoraAtual IsNot Nothing And fieldHoraMenos1 IsNot Nothing Then
                Dim varValorHoraAtual = fieldHoraAtual.GetValue(parIndustriaEnergiaBioPorHora, Nothing)
                Dim varValorHoraAtualMenos1 = fieldHoraMenos1.GetValue(parIndustriaEnergiaBioPorHora, Nothing)


                If varValorHoraAtual - varValorHoraAtualMenos1 <> 0 Then
                    GetIndustraPorHoraCoeficienteAngular = 1 / (varValorHoraAtual - varValorHoraAtualMenos1)
                End If
            End If
        End If
    End Function

    Private Function GetIndustriaEnergiaBioPorDiaAcumulado(parIndustriaEnergiaBioPorDia As S5TIndustriaEnergiaBioPorDia, parDia As Integer) As Double
        Dim varValor = 0

        Select Case parDia
            Case 1
                varValor = parIndustriaEnergiaBioPorDia.DIA1
            Case 2
                varValor = parIndustriaEnergiaBioPorDia.DIA1 + 
                           parIndustriaEnergiaBioPorDia.DIA2
            Case 3
                varValor = parIndustriaEnergiaBioPorDia.DIA1 + 
                           parIndustriaEnergiaBioPorDia.DIA2 +
                           parIndustriaEnergiaBioPorDia.DIA3
            Case 4
                varValor = parIndustriaEnergiaBioPorDia.DIA1 + 
                           parIndustriaEnergiaBioPorDia.DIA2 +
                           parIndustriaEnergiaBioPorDia.DIA3 +
                           parIndustriaEnergiaBioPorDia.DIA4
            Case 5
                varValor = parIndustriaEnergiaBioPorDia.DIA1 + 
                           parIndustriaEnergiaBioPorDia.DIA2 +
                           parIndustriaEnergiaBioPorDia.DIA3 +
                           parIndustriaEnergiaBioPorDia.DIA4 +
                           parIndustriaEnergiaBioPorDia.DIA5
            Case 6
                varValor = parIndustriaEnergiaBioPorDia.DIA1 + 
                           parIndustriaEnergiaBioPorDia.DIA2 +
                           parIndustriaEnergiaBioPorDia.DIA3 +
                           parIndustriaEnergiaBioPorDia.DIA4 +
                           parIndustriaEnergiaBioPorDia.DIA5 +
                           parIndustriaEnergiaBioPorDia.DIA6
            Case 7
                varValor = parIndustriaEnergiaBioPorDia.DIA1 + 
                           parIndustriaEnergiaBioPorDia.DIA2 +
                           parIndustriaEnergiaBioPorDia.DIA3 +
                           parIndustriaEnergiaBioPorDia.DIA4 +
                           parIndustriaEnergiaBioPorDia.DIA5 +
                           parIndustriaEnergiaBioPorDia.DIA6 +
                           parIndustriaEnergiaBioPorDia.DIA7
        End Select

        GetIndustriaEnergiaBioPorDiaAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustriaEnergiaBioPorSemanaAcumulado(parIndustriaEnergiaBioPorSemana As S5TIndustriaEnergiaBioPorSemana, parSemana As Integer) As Double
        Dim varValor = 0

        Select Case parSemana
            Case 1
                varValor = parIndustriaEnergiaBioPorSemana.SEMANA1
            Case 2
                varValor = parIndustriaEnergiaBioPorSemana.SEMANA1 +
                           parIndustriaEnergiaBioPorSemana.SEMANA2
            Case 3
                varValor = parIndustriaEnergiaBioPorSemana.SEMANA1 + 
                           parIndustriaEnergiaBioPorSemana.SEMANA2 +
                           parIndustriaEnergiaBioPorSemana.SEMANA3
            Case 4
                varValor = parIndustriaEnergiaBioPorSemana.SEMANA1 + 
                           parIndustriaEnergiaBioPorSemana.SEMANA2 +
                           parIndustriaEnergiaBioPorSemana.SEMANA3 +
                           parIndustriaEnergiaBioPorSemana.SEMANA4
            Case 5
                varValor = parIndustriaEnergiaBioPorSemana.SEMANA1 + 
                           parIndustriaEnergiaBioPorSemana.SEMANA2 +
                           parIndustriaEnergiaBioPorSemana.SEMANA3 +
                           parIndustriaEnergiaBioPorSemana.SEMANA4 +
                           parIndustriaEnergiaBioPorSemana.SEMANA5
            Case 6
                varValor = parIndustriaEnergiaBioPorSemana.SEMANA1 + 
                           parIndustriaEnergiaBioPorSemana.SEMANA2 +
                           parIndustriaEnergiaBioPorSemana.SEMANA3 +
                           parIndustriaEnergiaBioPorSemana.SEMANA4 +
                           parIndustriaEnergiaBioPorSemana.SEMANA5 +
                           parIndustriaEnergiaBioPorSemana.SEMANA6
        End Select

        GetIndustriaEnergiaBioPorSemanaAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustriaEnergiaBioPorMesAcumulado(parIndustriaEnergiaBioPorMes As S5TIndustriaEnergiaBioPorMes, parMes As Integer) As Double
        Dim varValor = 0

        Select Case parMes
            Case 1
                varValor = parIndustriaEnergiaBioPorMes.MES1
            Case 2
                varValor = parIndustriaEnergiaBioPorMes.MES1 +
                           parIndustriaEnergiaBioPorMes.MES2
            Case 3
                varValor = parIndustriaEnergiaBioPorMes.MES1 + 
                           parIndustriaEnergiaBioPorMes.MES2 +
                           parIndustriaEnergiaBioPorMes.MES3
            Case 4
                varValor = parIndustriaEnergiaBioPorMes.MES1 + 
                           parIndustriaEnergiaBioPorMes.MES2 +
                           parIndustriaEnergiaBioPorMes.MES3 +
                           parIndustriaEnergiaBioPorMes.MES4
            Case 5
                varValor = parIndustriaEnergiaBioPorMes.MES1 + 
                           parIndustriaEnergiaBioPorMes.MES2 +
                           parIndustriaEnergiaBioPorMes.MES3 +
                           parIndustriaEnergiaBioPorMes.MES4 +
                           parIndustriaEnergiaBioPorMes.MES5
            Case 6
                varValor = parIndustriaEnergiaBioPorMes.MES1 + 
                           parIndustriaEnergiaBioPorMes.MES2 +
                           parIndustriaEnergiaBioPorMes.MES3 +
                           parIndustriaEnergiaBioPorMes.MES4 +
                           parIndustriaEnergiaBioPorMes.MES5 +
                           parIndustriaEnergiaBioPorMes.MES6
            Case 7
                varValor = parIndustriaEnergiaBioPorMes.MES1 + 
                           parIndustriaEnergiaBioPorMes.MES2 +
                           parIndustriaEnergiaBioPorMes.MES3 +
                           parIndustriaEnergiaBioPorMes.MES4 +
                           parIndustriaEnergiaBioPorMes.MES5 +
                           parIndustriaEnergiaBioPorMes.MES6 +
                           parIndustriaEnergiaBioPorMes.MES7
            Case 8
                varValor = parIndustriaEnergiaBioPorMes.MES1 + 
                           parIndustriaEnergiaBioPorMes.MES2 +
                           parIndustriaEnergiaBioPorMes.MES3 +
                           parIndustriaEnergiaBioPorMes.MES4 +
                           parIndustriaEnergiaBioPorMes.MES5 +
                           parIndustriaEnergiaBioPorMes.MES6 +
                           parIndustriaEnergiaBioPorMes.MES7 +
                           parIndustriaEnergiaBioPorMes.MES8
            Case 9
                varValor = parIndustriaEnergiaBioPorMes.MES1 + 
                           parIndustriaEnergiaBioPorMes.MES2 +
                           parIndustriaEnergiaBioPorMes.MES3 +
                           parIndustriaEnergiaBioPorMes.MES4 +
                           parIndustriaEnergiaBioPorMes.MES5 +
                           parIndustriaEnergiaBioPorMes.MES6 +
                           parIndustriaEnergiaBioPorMes.MES7 +
                           parIndustriaEnergiaBioPorMes.MES8 +
                           parIndustriaEnergiaBioPorMes.MES9
            Case 10
                varValor = parIndustriaEnergiaBioPorMes.MES1 + 
                           parIndustriaEnergiaBioPorMes.MES2 +
                           parIndustriaEnergiaBioPorMes.MES3 +
                           parIndustriaEnergiaBioPorMes.MES4 +
                           parIndustriaEnergiaBioPorMes.MES5 +
                           parIndustriaEnergiaBioPorMes.MES6 +
                           parIndustriaEnergiaBioPorMes.MES7 +
                           parIndustriaEnergiaBioPorMes.MES8 +
                           parIndustriaEnergiaBioPorMes.MES9 +
                           parIndustriaEnergiaBioPorMes.MES10
            Case 11
                varValor = parIndustriaEnergiaBioPorMes.MES1 + 
                           parIndustriaEnergiaBioPorMes.MES2 +
                           parIndustriaEnergiaBioPorMes.MES3 +
                           parIndustriaEnergiaBioPorMes.MES4 +
                           parIndustriaEnergiaBioPorMes.MES5 +
                           parIndustriaEnergiaBioPorMes.MES6 +
                           parIndustriaEnergiaBioPorMes.MES7 +
                           parIndustriaEnergiaBioPorMes.MES8 +
                           parIndustriaEnergiaBioPorMes.MES9 +
                           parIndustriaEnergiaBioPorMes.MES10 +
                           parIndustriaEnergiaBioPorMes.MES11
            Case 12
                varValor = parIndustriaEnergiaBioPorMes.MES1 + 
                           parIndustriaEnergiaBioPorMes.MES2 +
                           parIndustriaEnergiaBioPorMes.MES3 +
                           parIndustriaEnergiaBioPorMes.MES4 +
                           parIndustriaEnergiaBioPorMes.MES5 +
                           parIndustriaEnergiaBioPorMes.MES6 +
                           parIndustriaEnergiaBioPorMes.MES7 +
                           parIndustriaEnergiaBioPorMes.MES8 +
                           parIndustriaEnergiaBioPorMes.MES9 +
                           parIndustriaEnergiaBioPorMes.MES10 +
                           parIndustriaEnergiaBioPorMes.MES11 +
                           parIndustriaEnergiaBioPorMes.MES12
        End Select

        GetIndustriaEnergiaBioPorMesAcumulado = Math.Round(varValor,0)
    End Function

    Enum TipoCampo
        ValorPlanejado
        ValorRealizado
    End Enum

    Private Function GetInfoObjIndustriaEnergiaBio(parTipoCampo As TipoCampo, parObjIndustriaEnergiaBio As S5TIndustriaEnergiaBio) As Double
        GetInfoObjIndustriaEnergiaBio = 0

        If parObjIndustriaEnergiaBio IsNot Nothing Then
            If parTipoCampo = TipoCampo.ValorPlanejado Then
                GetInfoObjIndustriaEnergiaBio = Math.Round(parObjIndustriaEnergiaBio.VALOR_PLAN,0)
            ElseIf parTipoCampo = TipoCampo.ValorRealizado Then
                GetInfoObjIndustriaEnergiaBio = Math.Round(parObjIndustriaEnergiaBio.VALOR_REAL,0)
            End If
        End If
    End Function

    Private Function GetIndustriaEnergiaBioAcumuladoPorDiaAjustadoMetas(parIndustriaEnergiaBioPorHora As S5TIndustriaEnergiaBioPorHora, parHoraAtual As String) As S5TIndustriaEnergiaBioPorHora
        GetIndustriaEnergiaBioAcumuladoPorDiaAjustadoMetas = parIndustriaEnergiaBioPorHora

        Dim varHoraAtual = Convert.ToInt16(parHoraAtual)

        Dim t as Type = parIndustriaEnergiaBioPorHora.GetType()

        For i As Integer = varHoraAtual To 22
            Dim varValorMetaHoraMenos1 As Double = 0
            If i > 0 Then
                Dim varNomePropriedadeHoraMenos1 = "H" & (i-1).ToString.PadLeft(2, "0")
                Dim fieldHoraMenos1 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraMenos1)
                varValorMetaHoraMenos1 = fieldHoraMenos1.GetValue(parIndustriaEnergiaBioPorHora, Nothing)
            End If

            Dim varNomePropriedadeHoraAtual = "H" & i.ToString.PadLeft(2, "0")
            Dim fieldHoraAtual As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtual)
            Dim varValorMetaHoraAtual As Double = fieldHoraAtual.GetValue(parIndustriaEnergiaBioPorHora, Nothing)

            Dim varNomePropriedadeHoraMais1 = "H" & (i+1).ToString.PadLeft(2, "0")
            Dim fieldHoraMais1 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraMais1)
            Dim varValorMetaHoraMais1 As Double = fieldHoraMais1.GetValue(parIndustriaEnergiaBioPorHora, Nothing)

            If varValorMetaHoraMais1 <= varValorMetaHoraAtual Then
                fieldHoraMais1.SetValue(parIndustriaEnergiaBioPorHora, Math.Round(varValorMetaHoraAtual + (varValorMetaHoraAtual - varValorMetaHoraMenos1),0))
            End If            
        Next

        GetIndustriaEnergiaBioAcumuladoPorDiaAjustadoMetas = parIndustriaEnergiaBioPorHora
    End Function

    Private Function GetMediaHoraAnterior(parDadosGeralPorHora As List(Of S5TIndustriaEnergiaBioPorHora), parHoraAtual As String) As Double
        GetMediaHoraAnterior = 0

        Dim objRealizadoAcumulado = parDadosGeralPorHora.FirstOrDefault(Function(x) x.Diario = "Realizado" And x.Hora = "Acumulado (MWh)")

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
