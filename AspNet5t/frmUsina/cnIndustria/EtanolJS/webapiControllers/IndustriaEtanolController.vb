Imports System.Globalization
Imports System.Reflection
Imports System.Runtime.Serialization
Imports System.Web.Http
Imports Oracle.DataAccess.Client

<RoutePrefix("api/IndustriaEtanol")>
Public Class IndustriaEtanolController
    Inherits ApiController

    Private Property QueryIndustriaEtanol As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, HORA, ID_CA_INDICADOR, DS_CA_INDICADOR, MOENDA, VALOR_PLAN, VALOR_PLAN_NEFETIVA, VALOR_REAL FROM BI4T.INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR IN (51,52)"
    Private Property QueryIndustriaEtanolPlanejado As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, HORA, ID_CA_INDICADOR, DS_CA_INDICADOR, MOENDA, VALOR_PLAN, VALOR_PLAN_EFETIVA VALOR_PLAN_NEFETIVA, VALOR_REAL FROM BI4T.V_PLAN_INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR IN (51,52)"

    <DataContract>
    Public Class S5TIndustriaEtanolSemanaDiaInicioFim
        <DataMember>
        Public Property diaInicio As Date
        <DataMember>
        Public Property diaFim As Date
    End Class

    <DataContract>
    Public Class S5TIndustriaEtanol
        Public Property ID_NEGOCIOS as Integer
        Public Property SAFRA As Integer
        <DataMember>
        Public Property MES As Integer
        <DataMember>
        Public Property SEMANA As Integer
        <DataMember>
        Public Property semanaPeriodo As S5TIndustriaEtanolSemanaDiaInicioFim
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
    Public Class S5TIndustriaEtanolPorHora
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
    Public Class S5TIndustriaEtanolPorDia
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
    Public Class S5TIndustriaEtanolPorSemana
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
    Public Class S5TIndustriaEtanolPorMes
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
    Public Class S5TIndustriaEtanolPorTipoPorDia
        <DataMember>
        Public Property tipo As String
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaEtanol)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaEtanol)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaEtanolPorHora)
        <DataMember>
        Public Property HoraAtual As String
        <DataMember>
        Public Property MediaHoraAnterior As Double
    End Class

    <DataContract>
    Public Class S5TIndustriaEtanolPorTipoPorSemana
        <DataMember>
        Public Property tipo As String
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaEtanol)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaEtanol)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaEtanolPorDia)
        <DataMember>
        Public Property DiaAtual As Date
    End Class

    <DataContract>
    Public Class S5TIndustriaEtanolPorTipoPorMes
        <DataMember>
        Public Property tipo As String
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaEtanol)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaEtanol)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaEtanolPorSemana)
        <DataMember>
        Public Property SemanaAtual As Integer
    End Class

    <DataContract>
    Public Class S5TIndustriaEtanolPorTipoPorSafra
        <DataMember>
        Public Property tipo As String
        <DataMember>
        Public Property oGrafico As List(Of S5TIndustriaEtanol)
        <DataMember>
        Public Property oGraficoAcumulado As List(Of S5TIndustriaEtanol)
        <DataMember>
        Public Property oGrid As List(Of S5TIndustriaEtanolPorMes)
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

    ' GET api/IndustriaEtanol/VisaoGeralMinMaxDia/1
    <HttpGet>
    <Route("VisaoGeralMinMaxDia/{parIdNegocios}")>
    Public Function GetValuesMaxDia(parIdNegocios As Integer) As IHttpActionResult
        Return Ok(GetIndustriaEtanolPorSafraMinMaxDia(parIdNegocios))
    End Function


    ' GET api/IndustriaEtanol/VisaoGeral/1/2017
    <HttpGet>
    <Route("VisaoGeral/{parIdNegocios}/{parSafra}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer) As IHttpActionResult
        Dim dados = GetIndustriaEtanolPorSafraPlain(parIdNegocios, parSafra)
        Dim dadosPlanejado = GetIndustriaEtanolPlanejadoPorSafraPlain(parIdNegocios, parSafra)

        Dim ultimoDia = dados.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Date

        Dim ultimaHora = dados.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Hour

        Dim ultimaSemana = dados.OrderByDescending(Function(x) x.SEMANA).FirstOrDefault().SEMANA

        Dim ultimoMes = dados.OrderByDescending(Function(x) x.MES).FirstOrDefault().MES


        Dim dadosDia = dados.FindAll(Function (x) (x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52) And x.DIA.Date = ultimoDia)

        Dim dadosSemana = dados.FindAll(Function(x) (x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52) And x.SEMANA = ultimaSemana)

        Dim dadosMes = dados.FindAll(Function(x) (x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52) And x.MES = ultimoMes)

        Dim dadosSafra = dados.FindAll(Function(x) (x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52))


        Dim dadosPlanejadoDia = dadosPlanejado.FindAll(Function (x) x.DIA.Date = ultimoDia)

        Dim dadosPlanejadoSemana = dadosPlanejado.FindAll(Function(x) x.SEMANA = ultimaSemana)

        Dim dadosPlanejadoMes = dadosPlanejado.FindAll(Function(x) x.MES = ultimoMes)

        Dim dadosPlanejadoSafra = dadosPlanejado


        Dim varVisaoGeralDia = GetValoresVisaoGeral(dadosDia, dadosPlanejadoDia, Periodo.Dia)
        Dim varVisaoGeralSemana = GetValoresVisaoGeral(dadosSemana, dadosPlanejadoSemana, Periodo.Semana)
        Dim varVisaoGeralMes = GetValoresVisaoGeral(dadosMes, dadosPlanejadoMes,  Periodo.Mes)
        Dim varVisaoGeralSafra = GetValoresVisaoGeral(dadosSafra, dadosPlanejadoSafra, Periodo.Safra)

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

    ' GET api/IndustriaEtanol/VisaoGeralCorteDia/1/2017/20171110
    <HttpGet>
    <Route("VisaoGeralCorteDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValuesCorteDia(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim dados = GetIndustriaEtanolPorSafraCorteDiaPlain(parIdNegocios, parSafra, parDia)
        Dim dadosPlanejado = GetIndustriaEtanolPlanejadoPorSafraPlain(parIdNegocios, parSafra)

        Dim ultimoDia = dados.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Date

        Dim ultimaHora = dados.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Hour

        Dim ultimaSemana = dados.OrderByDescending(Function(x) x.SEMANA).FirstOrDefault().SEMANA

        Dim ultimoMes = dados.OrderByDescending(Function(x) x.MES).FirstOrDefault().MES


        Dim dadosDia = dados.FindAll(Function (x) (x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52) And x.DIA.Date = ultimoDia)

        Dim dadosSemana = dados.FindAll(Function(x) (x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52) And x.SEMANA = ultimaSemana)

        Dim dadosMes = dados.FindAll(Function(x) (x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52) And x.MES = ultimoMes)

        Dim dadosSafra = dados.FindAll(Function(x) (x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52))


        Dim dadosPlanejadoDia = dadosPlanejado.FindAll(Function (x) x.DIA.Date = ultimoDia)

        Dim dadosPlanejadoSemana = dadosPlanejado.FindAll(Function(x) x.SEMANA = ultimaSemana)

        Dim dadosPlanejadoMes = dadosPlanejado.FindAll(Function(x) x.MES = ultimoMes)

        Dim dadosPlanejadoSafra = dadosPlanejado


        Dim varVisaoGeralDia = GetValoresVisaoGeral(dadosDia, dadosPlanejadoDia, Periodo.Dia)
        Dim varVisaoGeralSemana = GetValoresVisaoGeral(dadosSemana,dadosPlanejadoSemana, Periodo.Semana)
        Dim varVisaoGeralMes = GetValoresVisaoGeral(dadosMes, dadosPlanejadoMes, Periodo.Mes)
        Dim varVisaoGeralSafra = GetValoresVisaoGeral(dadosSafra, dadosPlanejadoSafra, Periodo.Safra)

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


    ' GET api/IndustriaEtanol/PorDia/1/2017/20171117
    <HttpGet>
    <Route("PorDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim dados = GetIndustriaEtanolPorDiaPlain(parIdNegocios, parSafra, varDia)

        Dim dadosPorTipo = GetIndustriaEtanolPorTipoAgrupadoPorDiaHora(dados)

        Return Ok(dadosPorTipo)
    End Function

    ' GET api/IndustriaEtanol/PorSemana/1/2017/46
    <HttpGet>
    <Route("PorSemana/{parIdNegocios}/{parSafra}/{parSemana}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As IHttpActionResult
        Dim dados = GetIndustriaEtanolPorSemanaPlain(parIdNegocios, parSafra, parSemana)

        Dim dadosPorTipo = GetIndustriaEtanolPorTipoAgrupadoPorSemana(dados)

        Return Ok(dadosPorTipo)
    End Function

    ' GET api/IndustriaEtanol/PorMes/1/2017/11
    <HttpGet>
    <Route("PorMes/{parIdNegocios}/{parSafra}/{parMes}")>
    Public Function GetValuesMes(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As IHttpActionResult
        Dim dados = GetIndustriaEtanolPorMesPlain(parIdNegocios, parSafra, parMes)

        Dim dadosPorTipo = GetIndustriaEtanolPorTipoAgrupadoPorMes(dados)

        Return Ok(dadosPorTipo)
    End Function

    ' GET api/IndustriaEtanol/PorSafra/1/2017
    <HttpGet>
    <Route("PorSafra/{parIdNegocios}/{parSafra}")>
    Public Function GetValuesSafra(parIdNegocios As Integer, parSafra As Integer) As IHttpActionResult
        Dim dados = GetIndustriaEtanolPorSafraPlain(parIdNegocios, parSafra)

        Dim dadosPorTipo = GetIndustriaEtanolPorTipoAgrupadoPorSafra(dados)

        Return Ok(dadosPorTipo)
    End Function

    ' GET api/IndustriaEtanol/PorSafraCorteDia/1/2017/20171110
    <HttpGet>
    <Route("PorSafraCorteDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValuesSafraCorteDia(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim dados = GetIndustriaEtanolPorSafraCorteDiaPlain(parIdNegocios, parSafra, parDia)

        Dim dadosPorTipo = GetIndustriaEtanolPorTipoAgrupadoPorSafra(dados)

        Return Ok(dadosPorTipo)
    End Function

    
    Public Function GetIndustriaEtanolPorSafraMinMaxDia(parIdNegocios As Integer) As Object
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            "SELECT MAX(SAFRA) SAFRA, MIN(DIA) MINDIA, MAX(DIA) MAXDIA, MAX(to_char(DIA + cast('0 '||HORA||':00:00' as interval day to second), 'YYYYMMDDHH24MI')) MAXDIAHORA, MIN(SEMANA) MINSEMANA, MAX(SEMANA) MAXSEMANA, MIN(MES) MINMES, MAX(MES) MAXMES FROM BI4T.INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR = 46 AND ID_NEGOCIOS = :p0",
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

        GetIndustriaEtanolPorSafraMinMaxDia = New With {
            Key .safra = varSafra,
            Key .MinDia = varMinDia, 
            Key .MaxDia = varMaxDia, 
            Key .MaxHora = varMaxHora, 
            Key .MinSemana = varMinSemana, 
            Key .MaxSemana = varMaxSemana, 
            Key .MinMes = varMinMes, 
            Key .MaxMes = varMaxMes}
    End Function


    Public Function GetIndustriaEtanolPorSafraPlain(parIdNegocios As Integer, parSafra As Integer) As List(Of S5TIndustriaEtanol)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEtanol & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra

        Return GetDados(conn, cmdDados)
    End Function

    Public Function GetIndustriaEtanolPlanejadoPorSafraPlain(parIdNegocios As Integer, parSafra As Integer) As List(Of S5TIndustriaEtanol)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEtanolPlanejado & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra

        Return GetDados(conn, cmdDados)
    End Function


    Public Function GetIndustriaEtanolPorSafraCorteDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As String) As List(Of S5TIndustriaEtanol)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEtanol & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA <= :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Date).Value = varDia

        Return GetDados(conn, cmdDados)
    End Function
    
    Public Function GetIndustriaEtanolPorDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As DateTime) As List(Of S5TIndustriaEtanol)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEtanol & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Date).Value = parDia

        Return GetDados(conn, cmdDados)
    End Function

    Public Function GetIndustriaEtanolPorSemanaPlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As List(Of S5TIndustriaEtanol)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEtanol & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana

        Return GetDados(conn, cmdDados)
    End Function

    Public Function GetIndustriaEtanolPorMesPlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As List(Of S5TIndustriaEtanol)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDados As New OracleCommand(
            QueryIndustriaEtanol & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDados.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDados.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDados.Parameters.Add(":p2", OracleDbType.Int16).Value = parMes

        Return GetDados(conn, cmdDados)
    End Function


    Private Function GetDados(parConnection As OracleConnection, parCommand As OracleCommand) As List(Of S5TIndustriaEtanol)
        Dim dados As New List(Of S5TIndustriaEtanol)

        parConnection.Open()

        Dim drDados As OracleDataReader = Nothing
        Try
            drDados = parCommand.ExecuteReader()
            If drDados.HasRows Then
                Do While drDados.Read
                    Dim objDados = New S5TIndustriaEtanol

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

    Private Function GetValoresVisaoGeral(parDados As List(Of S5TIndustriaEtanol), parDadosPlanejado As List(Of S5TIndustriaEtanol), parPeriodo As Periodo) As S5TVisaoGeralAux
        Dim val = Math.Round(parDados.Sum(Function(x) x.VALOR_REAL), 0)

        Dim parDadosParaMeta As List(Of S5TIndustriaEtanol)

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

    Private Function GetIndustriaEtanolPorTipoAgrupadoPorDiaHora(parDados As List(Of S5TIndustriaEtanol)) As List(Of S5TIndustriaEtanolPorTipoPorDia)
        Dim varTipos = New List(Of S5TIndustriaEtanolPorTipoPorDia)

        Dim varDadosPorTipoGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                            Key .HORA = x.HORA}).Select(Function (y) New S5TIndustriaEtanol With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                  .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                                                  .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                                                                                                  .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoA = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 51).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                              Key .HORA = x.HORA}).Select(Function (y) New S5TIndustriaEtanol With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                    .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                    .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                                                                    .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoB = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 52).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                              Key .HORA = x.HORA}).Select(Function (y) New S5TIndustriaEtanol With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                    .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                    .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                                                                    .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoGeralAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoGeral)
        Dim varDadosPorTipoAAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoA)
        Dim varDadosPorTipoBAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoB)

        Dim varDadosPorTipoGeralPorHora = GetIndustriaEtanolPorTipoPorHora(varDadosPorTipoGeral)
        Dim varDadosPorTipoAPorHora = GetIndustriaEtanolPorTipoPorHora(varDadosPorTipoA)
        Dim varDadosPorTipoBPorHora = GetIndustriaEtanolPorTipoPorHora(varDadosPorTipoB)

        Dim varHoraAtual = parDados.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().HORA
        Dim varHoraAnterior = varHoraAtual

        If varDadosPorTipoGeral.Count > 1 Then
            varHoraAnterior = varDadosPorTipoGeral.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA)(1).HORA
        End If

        varTipos.Add(New S5TIndustriaEtanolPorTipoPorDia With {.tipo = "AB", 
                                                               .oGrafico = varDadosPorTipoGeral.OrderBy(Function(x) x.DIA.Date).ThenBy(Function(x) x.HORA).ToList, 
                                                               .oGraficoAcumulado = varDadosPorTipoGeralAcumulado, 
                                                               .oGrid = varDadosPorTipoGeralPorHora,
                                                               .HoraAtual = varHoraAtual,
                                                               .MediaHoraAnterior = GetMediaHoraAnterior(varDadosPorTipoGeralPorHora, varHoraAtual)})

        varTipos.Add(New S5TIndustriaEtanolPorTipoPorDia With {.tipo = "A", 
                                                               .oGrafico = varDadosPorTipoA.OrderBy(Function(x) x.DIA.Date).ThenBy(Function(x) x.HORA).ToList, 
                                                               .oGraficoAcumulado = varDadosPorTipoAAcumulado, 
                                                               .oGrid = varDadosPorTipoAPorHora,
                                                               .HoraAtual = varHoraAtual,
                                                               .MediaHoraAnterior = GetMediaHoraAnterior(varDadosPorTipoAPorHora, varHoraAtual)})

        varTipos.Add(New S5TIndustriaEtanolPorTipoPorDia With {.tipo = "B", 
                                                               .oGrafico = varDadosPorTipoB.OrderBy(Function(x) x.DIA.Date).ThenBy(Function(x) x.HORA).ToList, 
                                                               .oGraficoAcumulado = varDadosPorTipoBAcumulado, 
                                                               .oGrid = varDadosPorTipoBPorHora,
                                                               .HoraAtual = varHoraAtual,
                                                               .MediaHoraAnterior = GetMediaHoraAnterior(varDadosPorTipoBPorHora, varHoraAtual)})

        GetIndustriaEtanolPorTipoAgrupadoPorDiaHora = varTipos
    End Function

    Private Function GetIndustriaEtanolPorTipoAgrupadoPorSemana(parDados As List(Of S5TIndustriaEtanol)) As List(Of S5TIndustriaEtanolPorTipoPorSemana)
        Dim varTipos = New List(Of S5TIndustriaEtanolPorTipoPorSemana) 

        Dim varDadosPorTipoGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TIndustriaEtanol With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                     .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                     .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoA = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 51).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TIndustriaEtanol With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                       .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                       .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoB = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 52).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date}).Select(Function (y) New S5TIndustriaEtanol With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                       .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                       .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoGeralAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoGeral.OrderBy(Function(x) x.DIA.Date).ToList)
        Dim varDadosPorTipoAAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoA.OrderBy(Function(x) x.DIA.Date).ToList)
        Dim varDadosPorTipoBAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoB.OrderBy(Function(x) x.DIA.Date).ToList)

        Dim varDadosPorTipoGeralPorDia = GetIndustriaEtanolPorTipoPorDia(varDadosPorTipoGeral)
        Dim varDadosPorTipoAPorDia = GetIndustriaEtanolPorTipoPorDia(varDadosPorTipoA)
        Dim varDadosPorTipoBPorDia = GetIndustriaEtanolPorTipoPorDia(varDadosPorTipoB)

        Dim varDiaAtual = parDados.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().DIA.Date

        varTipos.Add(New S5TIndustriaEtanolPorTipoPorSemana With {.tipo = "AB", 
                                                                  .oGrafico = varDadosPorTipoGeral.OrderBy(Function(x) x.DIA.Date).ToList, 
                                                                  .oGraficoAcumulado = varDadosPorTipoGeralAcumulado, 
                                                                  .oGrid = varDadosPorTipoGeralPorDia,
                                                                  .DiaAtual = varDiaAtual})
        varTipos.Add(New S5TIndustriaEtanolPorTipoPorSemana With {.tipo = "A", 
                                                                  .oGrafico = varDadosPorTipoA.OrderBy(Function(x) x.DIA.Date).ToList, 
                                                                  .oGraficoAcumulado = varDadosPorTipoAAcumulado, 
                                                                  .oGrid = varDadosPorTipoAPorDia,
                                                                  .DiaAtual = varDiaAtual})
        varTipos.Add(New S5TIndustriaEtanolPorTipoPorSemana With {.tipo = "B", 
                                                                  .oGrafico = varDadosPorTipoB.OrderBy(Function(x) x.DIA.Date).ToList, 
                                                                  .oGraficoAcumulado = varDadosPorTipoBAcumulado, 
                                                                  .oGrid = varDadosPorTipoBPorDia,
                                                                  .DiaAtual = varDiaAtual})

        GetIndustriaEtanolPorTipoAgrupadoPorSemana = varTipos
    End Function

    Private Function GetIndustriaEtanolPorTipoAgrupadoPorMes(parDados As List(Of S5TIndustriaEtanol)) As List(Of S5TIndustriaEtanolPorTipoPorMes)
        Dim varTipos = New List(Of S5TIndustriaEtanolPorTipoPorMes) 

        Dim varDadosPorTipoGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaEtanol With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                      .SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                                      .semanaPeriodo = New S5TIndustriaEtanolSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                                      .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                      .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoA = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 51).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaEtanol With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                        .SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                        .semanaPeriodo = New S5TIndustriaEtanolSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                        .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                        .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoB = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 52).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaEtanol With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                        .SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                        .semanaPeriodo = New S5TIndustriaEtanolSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                        .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                        .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoGeralAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoGeral.OrderBy(Function(x) x.SEMANA).ToList)
        Dim varDadosPorTipoAAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoA.OrderBy(Function(x) x.SEMANA).ToList)
        Dim varDadosPorTipoBAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoB.OrderBy(Function(x) x.SEMANA).ToList)

        Dim varDadosPorTipoGeralPorSemana = GetIndustriaEtanolPorTipoPorSemana(varDadosPorTipoGeral)
        Dim varDadosPorTipoAPorSemana = GetIndustriaEtanolPorTipoPorSemana(varDadosPorTipoA)
        Dim varDadosPorTipoBPorSemana = GetIndustriaEtanolPorTipoPorSemana(varDadosPorTipoB)

        Dim varSemanaAtual = parDados.OrderByDescending(Function(x) x.SEMANA).FirstOrDefault().SEMANA

        varTipos.Add(New S5TIndustriaEtanolPorTipoPorMes With {.tipo = "AB", 
                                                             .oGrafico = varDadosPorTipoGeral.OrderBy(Function(x) x.SEMANA).ToList, 
                                                             .oGraficoAcumulado = varDadosPorTipoGeralAcumulado, 
                                                             .oGrid = varDadosPorTipoGeralPorSemana,
                                                             .SemanaAtual = varSemanaAtual})
        varTipos.Add(New S5TIndustriaEtanolPorTipoPorMes With {.tipo = "A", 
                                                             .oGrafico = varDadosPorTipoA.OrderBy(Function(x) x.SEMANA).ToList, 
                                                             .oGraficoAcumulado = varDadosPorTipoAAcumulado, 
                                                             .oGrid = varDadosPorTipoAPorSemana,
                                                             .SemanaAtual = varSemanaAtual})
        varTipos.Add(New S5TIndustriaEtanolPorTipoPorMes With {.tipo = "B", 
                                                             .oGrafico = varDadosPorTipoB.OrderBy(Function(x) x.SEMANA).ToList, 
                                                             .oGraficoAcumulado = varDadosPorTipoBAcumulado, 
                                                             .oGrid = varDadosPorTipoBPorSemana,
                                                             .SemanaAtual = varSemanaAtual})

        GetIndustriaEtanolPorTipoAgrupadoPorMes = varTipos
    End Function

    Private Function GetIndustriaEtanolPorTipoAgrupadoPorSafra(parDados As List(Of S5TIndustriaEtanol)) As List(Of S5TIndustriaEtanolPorTipoPorSafra)
        Dim varTipos = New List(Of S5TIndustriaEtanolPorTipoPorSafra) 

        Dim varDadosPorTipoGeral = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 51 Or x.ID_CA_INDICADOR = 52).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaEtanol With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                                                .DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoA = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 51).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaEtanol With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                  .DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                  .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                  .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoB = parDados.FindAll(Function(x) x.ID_CA_INDICADOR = 52).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaEtanol With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                  .DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                  .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                  .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosPorTipoGeralAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoGeral.OrderBy(Function(x) x.MES).ToList)
        Dim varDadosPorTipoAAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoA.OrderBy(Function(x) x.MES).ToList)
        Dim varDadosPorTipoBAcumulado = GetIndustriaEtanolAcumulado(varDadosPorTipoB.OrderBy(Function(x) x.MES).ToList)

        Dim varDadosPorTipoGeralPorMes = GetIndustriaEtanolPorTipoPorMes(varDadosPorTipoGeral)
        Dim varDadosPorTipoAPorMes = GetIndustriaEtanolPorTipoPorMes(varDadosPorTipoA)
        Dim varDadosPorTipoBPorMes = GetIndustriaEtanolPorTipoPorMes(varDadosPorTipoB)

        Dim varMesAtual = parDados.OrderByDescending(Function(x) x.MES).FirstOrDefault().MES

        varTipos.Add(New S5TIndustriaEtanolPorTipoPorSafra With {.tipo = "AB", 
                                                             .oGrafico = varDadosPorTipoGeral.OrderBy(Function(x) x.MES).ToList, 
                                                             .oGraficoAcumulado = varDadosPorTipoGeralAcumulado, 
                                                             .oGrid = varDadosPorTipoGeralPorMes,
                                                             .MesAtual = varMesAtual})
        varTipos.Add(New S5TIndustriaEtanolPorTipoPorSafra With {.tipo = "A", 
                                                             .oGrafico = varDadosPorTipoA.OrderBy(Function(x) x.MES).ToList, 
                                                             .oGraficoAcumulado = varDadosPorTipoAAcumulado, 
                                                             .oGrid = varDadosPorTipoAPorMes,
                                                             .MesAtual = varMesAtual})
        varTipos.Add(New S5TIndustriaEtanolPorTipoPorSafra With {.tipo = "B", 
                                                             .oGrafico = varDadosPorTipoB.OrderBy(Function(x) x.MES).ToList, 
                                                             .oGraficoAcumulado = varDadosPorTipoBAcumulado, 
                                                             .oGrid = varDadosPorTipoBPorMes,
                                                             .MesAtual = varMesAtual})

        GetIndustriaEtanolPorTipoAgrupadoPorSafra = varTipos
    End Function

    Private Function GetIndustriaEtanolAcumulado(parIndustriaEtanol As List(Of S5TIndustriaEtanol)) As List(Of S5TIndustriaEtanol)
        Dim parIndustriaEtanolOrdenado = parIndustriaEtanol.OrderBy(Function(x) x.DIA).OrderBy(Function(x) x.HORA)

        Dim varIndustriaEtanolAcumulado = New List(Of S5TIndustriaEtanol)

        Dim varPlanejadoAcumulado As Double = 0
        Dim varRealizadoAcumulado As Double = 0

        For Each objIndustriaEtanol In parIndustriaEtanolOrdenado
            varPlanejadoAcumulado += objIndustriaEtanol.VALOR_PLAN
            varRealizadoAcumulado += objIndustriaEtanol.VALOR_REAL

            varIndustriaEtanolAcumulado.Add(New S5TIndustriaEtanol() With {
                                                .ID_NEGOCIOS = objIndustriaEtanol.ID_NEGOCIOS,
                                                .SAFRA = objIndustriaEtanol.SAFRA,
                                                .MES = objIndustriaEtanol.MES,
                                                .SEMANA = objIndustriaEtanol.SEMANA,
                                                .semanaPeriodo = objIndustriaEtanol.semanaPeriodo,
                                                .DIA = objIndustriaEtanol.DIA,
                                                .HORA = objIndustriaEtanol.HORA,
                                                .ID_CA_INDICADOR = objIndustriaEtanol.ID_CA_INDICADOR,
                                                .DS_CA_INDICADOR = objIndustriaEtanol.DS_CA_INDICADOR,
                                                .MOENDA = objIndustriaEtanol.MOENDA,
                                                .VALOR_PLAN = Math.Round(varPlanejadoAcumulado,0),
                                                .VALOR_REAL = Math.Round(varRealizadoAcumulado,0)
                                            })
        Next

        GetIndustriaEtanolAcumulado = varIndustriaEtanolAcumulado
    End Function

    Private Function GetIndustriaEtanolPorTipoPorHora(parDadosPorDia As List(Of S5TIndustriaEtanol)) As List(Of S5TIndustriaEtanolPorHora)
        Dim varIndustriaEtanolPorHora = New List(Of S5TIndustriaEtanolPorHora)

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

        Dim obj01PlanejadoPorHora = New S5TIndustriaEtanolPorHora With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Horário (m³)",
                                                                        .H00 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH00),
                                                                        .H01 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH01),
                                                                        .H02 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH02),
                                                                        .H03 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH03),
                                                                        .H04 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH04),
                                                                        .H05 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH05),
                                                                        .H06 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH06),
                                                                        .H07 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH07),
                                                                        .H08 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH08),
                                                                        .H09 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH09),
                                                                        .H10 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH10),
                                                                        .H11 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH11),
                                                                        .H12 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH12),
                                                                        .H13 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH13),
                                                                        .H14 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH14),
                                                                        .H15 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH15),
                                                                        .H16 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH16),
                                                                        .H17 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH17),
                                                                        .H18 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH18),
                                                                        .H19 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH19),
                                                                        .H20 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH20),
                                                                        .H21 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH21),
                                                                        .H22 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH22),
                                                                        .H23 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH23)
                                                                        }

        Dim obj02PlanejadoAcumuladoPorHora = New S5TIndustriaEtanolPorHora With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (m³/dia)",
                                                                        .H00 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 0),
                                                                        .H01 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 1),
                                                                        .H02 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 2),
                                                                        .H03 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 3),
                                                                        .H04 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 4),
                                                                        .H05 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 5),
                                                                        .H06 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 6),
                                                                        .H07 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 7),
                                                                        .H08 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 8),
                                                                        .H09 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 9),
                                                                        .H10 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 10),
                                                                        .H11 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 11),
                                                                        .H12 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 12),
                                                                        .H13 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 13),
                                                                        .H14 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 14),
                                                                        .H15 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 15),
                                                                        .H16 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 16),
                                                                        .H17 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 17),
                                                                        .H18 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 18),
                                                                        .H19 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 19),
                                                                        .H20 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 20),
                                                                        .H21 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 21),
                                                                        .H22 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 22),
                                                                        .H23 = GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 23)
                                                                        }


        Dim obj03RealizadoPorHora = New S5TIndustriaEtanolPorHora With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Diário (m³)",
                                                                        .H00 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH00),
                                                                        .H01 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH01),
                                                                        .H02 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH02),
                                                                        .H03 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH03),
                                                                        .H04 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH04),
                                                                        .H05 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH05),
                                                                        .H06 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH06),
                                                                        .H07 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH07),
                                                                        .H08 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH08),
                                                                        .H09 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH09),
                                                                        .H10 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH10),
                                                                        .H11 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH11),
                                                                        .H12 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH12),
                                                                        .H13 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH13),
                                                                        .H14 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH14),
                                                                        .H15 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH15),
                                                                        .H16 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH16),
                                                                        .H17 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH17),
                                                                        .H18 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH18),
                                                                        .H19 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH19),
                                                                        .H20 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH20),
                                                                        .H21 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH21),
                                                                        .H22 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH22),
                                                                        .H23 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH23)
                                                                        }

        Dim obj04RealizadoAcumuladoPorHora = New S5TIndustriaEtanolPorHora With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (m³/dia)",
                                                                        .H00 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 0),
                                                                        .H01 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 1),
                                                                        .H02 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 2),
                                                                        .H03 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 3),
                                                                        .H04 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 4),
                                                                        .H05 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 5),
                                                                        .H06 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 6),
                                                                        .H07 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 7),
                                                                        .H08 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 8),
                                                                        .H09 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 9),
                                                                        .H10 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 10),
                                                                        .H11 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 11),
                                                                        .H12 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 12),
                                                                        .H13 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 13),
                                                                        .H14 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 14),
                                                                        .H15 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 15),
                                                                        .H16 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 16),
                                                                        .H17 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 17),
                                                                        .H18 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 18),
                                                                        .H19 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 19),
                                                                        .H20 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 20),
                                                                        .H21 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 21),
                                                                        .H22 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 22),
                                                                        .H23 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 23)
                                                                        }

        Dim obj05RealizadoMenosPlanejadoPorHora = New S5TIndustriaEtanolPorHora With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Diário (m³)",
                                                                                        .H00 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH00) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH00),
                                                                                        .H01 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH01) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH01),
                                                                                        .H02 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH02) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH02),
                                                                                        .H03 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH03) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH03),
                                                                                        .H04 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH04) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH04),
                                                                                        .H05 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH05) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH05),
                                                                                        .H06 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH06) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH06),
                                                                                        .H07 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH07) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH07),
                                                                                        .H08 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH08) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH08),
                                                                                        .H09 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH09) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH09),
                                                                                        .H10 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH10) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH10),
                                                                                        .H11 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH11) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH11),
                                                                                        .H12 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH12) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH12),
                                                                                        .H13 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH13) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH13),
                                                                                        .H14 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH14) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH14),
                                                                                        .H15 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH15) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH15),
                                                                                        .H16 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH16) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH16),
                                                                                        .H17 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH17) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH17),
                                                                                        .H18 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH18) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH18),
                                                                                        .H19 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH19) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH19),
                                                                                        .H20 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH20) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH20),
                                                                                        .H21 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH21) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH21),
                                                                                        .H22 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH22) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH22),
                                                                                        .H23 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjH23) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjH23)
            }

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorHora = New S5TIndustriaEtanolPorHora With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (m³)",
                                                                                .H00 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 0) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 0),
                                                                                .H01 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 1) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 1),
                                                                                .H02 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 2) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 2),
                                                                                .H03 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 3) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 3),
                                                                                .H04 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 4) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 4),
                                                                                .H05 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 5) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 5),
                                                                                .H06 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 6) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 6),
                                                                                .H07 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 7) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 7),
                                                                                .H08 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 8) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 8),
                                                                                .H09 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 9) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 9),
                                                                                .H10 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 10) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 10),
                                                                                .H11 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 11) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 11),
                                                                                .H12 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 12) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 12),
                                                                                .H13 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 13) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 13),
                                                                                .H14 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 14) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 14),
                                                                                .H15 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 15) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 15),
                                                                                .H16 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 16) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 16),
                                                                                .H17 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 17) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 17),
                                                                                .H18 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 18) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 18),
                                                                                .H19 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 19) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 19),
                                                                                .H20 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 20) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 20),
                                                                                .H21 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 21) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 21),
                                                                                .H22 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 22) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 22),
                                                                                .H23 = GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 23) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 23)
        }

        Dim obj07DesvioPercentual = New S5TIndustriaEtanolPorHora With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .H00 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 0) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 0) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 0)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 0), 4)),
                                                        .H01 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 1) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 1) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 1)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 1), 4)),
                                                        .H02 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 2) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 2) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 2)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 2), 4)),
                                                        .H03 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 3) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 3) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 3)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 3), 4)),
                                                        .H04 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 4) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 4) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 4)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 4), 4)),
                                                        .H05 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 5) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 5) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 5)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 5), 4)),
                                                        .H06 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 6) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 6) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 6)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 6), 4)),
                                                        .H07 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 7) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 7) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 7)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 7), 4)),
                                                        .H08 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 8) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 8) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 8)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 8), 4)),
                                                        .H09 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 9) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 9) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 9)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 9), 4)),
                                                        .H10 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 10) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 10) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 10)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 10), 4)),
                                                        .H11 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 11) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 11) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 11)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 11), 4)),
                                                        .H12 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 12) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 12) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 12)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 12), 4)),
                                                        .H13 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 13) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 13) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 13)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 13), 4)),
                                                        .H14 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 14) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 14) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 14)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 14), 4)),
                                                        .H15 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 15) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 15) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 15)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 15), 4)),
                                                        .H16 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 16) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 16) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 16)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 16), 4)),
                                                        .H17 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 17) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 17) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 17)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 17), 4)),
                                                        .H18 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 18) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 18) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 18)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 18), 4)),
                                                        .H19 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 19) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 19) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 19)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 19), 4)),
                                                        .H20 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 20) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 20) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 20)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 20), 4)),
                                                        .H21 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 21) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 21) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 21)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 21), 4)),
                                                        .H22 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 22) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 22) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 22)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 22), 4)),
                                                        .H23 = IIf(GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 23) = 0, 0, Math.Round((GetIndustriaEtanolPorHoraAcumulado(obj03RealizadoPorHora, 23) - GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 23)) / GetIndustriaEtanolPorHoraAcumulado(obj01PlanejadoPorHora, 23), 4))
            }

        varIndustriaEtanolPorHora.Add(obj01PlanejadoPorHora)
        varIndustriaEtanolPorHora.Add(obj02PlanejadoAcumuladoPorHora)

        varIndustriaEtanolPorHora.Add(obj03RealizadoPorHora)
        varIndustriaEtanolPorHora.Add(obj04RealizadoAcumuladoPorHora)

        varIndustriaEtanolPorHora.Add(obj05RealizadoMenosPlanejadoPorHora)
        varIndustriaEtanolPorHora.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorHora)
        varIndustriaEtanolPorHora.Add(obj07DesvioPercentual)

        GetIndustriaEtanolPorTipoPorHora = varIndustriaEtanolPorHora
    End Function

    Private Function GetIndustriaEtanolPorTipoPorDia(parDadosPorDia As List(Of S5TIndustriaEtanol)) As List(Of S5TIndustriaEtanolPorDia)
        Dim varIndustriaEtanolPorDia = New List(Of S5TIndustriaEtanolPorDia)

        Dim dadosPorDia = parDadosPorDia.OrderBy(Function(x) x.DIA.Date)

        Dim varObjDia01 = Iif(dadosPorDia.Count() > 0, dadosPorDia(0), Nothing)
        Dim varObjDia02 = Iif(dadosPorDia.Count() > 1, dadosPorDia(1), Nothing)
        Dim varObjDia03 = Iif(dadosPorDia.Count() > 2, dadosPorDia(2), Nothing)
        Dim varObjDia04 = Iif(dadosPorDia.Count() > 3, dadosPorDia(3), Nothing)
        Dim varObjDia05 = Iif(dadosPorDia.Count() > 4, dadosPorDia(4), Nothing)
        Dim varObjDia06 = Iif(dadosPorDia.Count() > 5, dadosPorDia(5), Nothing)
        Dim varObjDia07 = Iif(dadosPorDia.Count() > 6, dadosPorDia(6), Nothing)

        Dim obj01PlanejadoPorDia = New S5TIndustriaEtanolPorDia With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Diário (m³/dia)",
                                                                        .DIA1 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia01),
                                                                        .DIA2 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia02),
                                                                        .DIA3 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia03),
                                                                        .DIA4 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia04),
                                                                        .DIA5 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia05),
                                                                        .DIA6 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia06),
                                                                        .DIA7 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia07)}

        Dim obj02PlanejadoAcumuladoPorDia = New S5TIndustriaEtanolPorDia With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (m³/semana)",
                                                                        .DIA1 = GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 1),
                                                                        .DIA2 = GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 2),
                                                                        .DIA3 = GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 3),
                                                                        .DIA4 = GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 4),
                                                                        .DIA5 = GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 5),
                                                                        .DIA6 = GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 6),
                                                                        .DIA7 = GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 7)}

        Dim obj03RealizadoPorDia = New S5TIndustriaEtanolPorDia With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Diário (m³/dia)",
                                                                        .DIA1 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia01),
                                                                        .DIA2 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia02),
                                                                        .DIA3 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia03),
                                                                        .DIA4 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia04),
                                                                        .DIA5 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia05),
                                                                        .DIA6 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia06),
                                                                        .DIA7 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia07)}

        Dim obj04RealizadoAcumuladoPorDia = New S5TIndustriaEtanolPorDia With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (m³/semana)",
                                                                        .DIA1 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 1),
                                                                        .DIA2 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 2),
                                                                        .DIA3 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 3),
                                                                        .DIA4 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 4),
                                                                        .DIA5 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 5),
                                                                        .DIA6 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 6),
                                                                        .DIA7 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 7)}

        Dim obj05RealizadoMenosPlanejadoPorDia = New S5TIndustriaEtanolPorDia With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Diário (m³)",
                                                                                        .DIA1 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia01) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia01),
                                                                                        .DIA2 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia02) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia02),
                                                                                        .DIA3 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia03) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia03),
                                                                                        .DIA4 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia04) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia04),
                                                                                        .DIA5 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia05) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia05),
                                                                                        .DIA6 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia06) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia06),
                                                                                        .DIA7 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjDia07) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjDia07)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorDia = New S5TIndustriaEtanolPorDia With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (m³)",
                                                                                .DIA1 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 1) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 1),
                                                                                .DIA2 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 2) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 2),
                                                                                .DIA3 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 3) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 3),
                                                                                .DIA4 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 4) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 4),
                                                                                .DIA5 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 5) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 5),
                                                                                .DIA6 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 6) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 6),
                                                                                .DIA7 = GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 7) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 7)}

        Dim obj07DesvioPercentual = New S5TIndustriaEtanolPorDia With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .DIA1 = IIf(GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 1) = 0, 0, Math.Round((GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 1) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 1)) / GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 1), 4)),
                                                        .DIA2 = IIf(GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 2) = 0, 0, Math.Round((GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 2) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 2)) / GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 2), 4)),
                                                        .DIA3 = IIf(GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 3) = 0, 0, Math.Round((GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 3) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 3)) / GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 3), 4)),
                                                        .DIA4 = IIf(GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 4) = 0, 0, Math.Round((GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 4) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 4)) / GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 4), 4)),
                                                        .DIA5 = IIf(GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 5) = 0, 0, Math.Round((GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 5) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 5)) / GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 5), 4)),
                                                        .DIA6 = IIf(GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 6) = 0, 0, Math.Round((GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 6) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 6)) / GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 6), 4)),
                                                        .DIA7 = IIf(GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 7) = 0, 0, Math.Round((GetIndustriaEtanolPorDiaAcumulado(obj03RealizadoPorDia, 7) - GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 7)) / GetIndustriaEtanolPorDiaAcumulado(obj01PlanejadoPorDia, 7), 4))}

        varIndustriaEtanolPorDia.Add(obj01PlanejadoPorDia)
        varIndustriaEtanolPorDia.Add(obj02PlanejadoAcumuladoPorDia)

        varIndustriaEtanolPorDia.Add(obj03RealizadoPorDia)
        varIndustriaEtanolPorDia.Add(obj04RealizadoAcumuladoPorDia)

        varIndustriaEtanolPorDia.Add(obj05RealizadoMenosPlanejadoPorDia)
        varIndustriaEtanolPorDia.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorDia)
        varIndustriaEtanolPorDia.Add(obj07DesvioPercentual)

        GetIndustriaEtanolPorTipoPorDia = varIndustriaEtanolPorDia
    End Function

    Private Function GetIndustriaEtanolPorTipoPorSemana(parDados As List(Of S5TIndustriaEtanol)) As List(Of S5TIndustriaEtanolPorSemana)
        Dim varIndustriaEtanolPorSemana = New List(Of S5TIndustriaEtanolPorSemana)

        Dim dadosPorSemana = parDados.GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaEtanol With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                          .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                          .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).OrderBy(Function(x) x.SEMANA).ToList()


        Dim varObjSemana1 As S5TIndustriaEtanol = Nothing
        Dim varObjSemana2 As S5TIndustriaEtanol = Nothing
        Dim varObjSemana3 As S5TIndustriaEtanol = Nothing
        Dim varObjSemana4 As S5TIndustriaEtanol = Nothing
        Dim varObjSemana5 As S5TIndustriaEtanol = Nothing
        Dim varObjSemana6 As S5TIndustriaEtanol = Nothing

        If dadosPorSemana.Count() > 0 Then varObjSemana1 = dadosPorSemana(0)
        If dadosPorSemana.Count() > 1 Then varObjSemana2 = dadosPorSemana(1)
        If dadosPorSemana.Count() > 2 Then varObjSemana3 = dadosPorSemana(2)
        If dadosPorSemana.Count() > 3 Then varObjSemana4 = dadosPorSemana(3)
        If dadosPorSemana.Count() > 4 Then varObjSemana5 = dadosPorSemana(4)
        If dadosPorSemana.Count() > 5 Then varObjSemana6 = dadosPorSemana(5)

        Dim obj01PlanejadoPorSemana = New S5TIndustriaEtanolPorSemana With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Semanal (m³/semana)",
                                                                        .SEMANA1 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana1),
                                                                        .SEMANA2 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana2),
                                                                        .SEMANA3 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana3),
                                                                        .SEMANA4 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana4),
                                                                        .SEMANA5 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana5),
                                                                        .SEMANA6 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana6)}

        Dim obj02PlanejadoAcumuladoPorSemana = New S5TIndustriaEtanolPorSemana With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (m³/mês)",
                                                                        .SEMANA1 = GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 1),
                                                                        .SEMANA2 = GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 2),
                                                                        .SEMANA3 = GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 3),
                                                                        .SEMANA4 = GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 4),
                                                                        .SEMANA5 = GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 5),
                                                                        .SEMANA6 = GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 6)}

        Dim obj03RealizadoPorSemana = New S5TIndustriaEtanolPorSemana With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Semanal (m³/semana)",
                                                                        .SEMANA1 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana1),
                                                                        .SEMANA2 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana2),
                                                                        .SEMANA3 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana3),
                                                                        .SEMANA4 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana4),
                                                                        .SEMANA5 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana5),
                                                                        .SEMANA6 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana6)}

        Dim obj04RealizadoAcumuladoPorSemana = New S5TIndustriaEtanolPorSemana With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (m³/mês)",
                                                                        .SEMANA1 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 1),
                                                                        .SEMANA2 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 2),
                                                                        .SEMANA3 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 3),
                                                                        .SEMANA4 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 4),
                                                                        .SEMANA5 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 5),
                                                                        .SEMANA6 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 6)}

        Dim obj05RealizadoMenosPlanejadoPorSemana = New S5TIndustriaEtanolPorSemana With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Semanal (m³)",
                                                                                        .SEMANA1 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana1) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana1),
                                                                                        .SEMANA2 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana2) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana2),
                                                                                        .SEMANA3 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana3) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana3),
                                                                                        .SEMANA4 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana4) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana4),
                                                                                        .SEMANA5 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana5) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana5),
                                                                                        .SEMANA6 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjSemana6) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjSemana6)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorSemana = New S5TIndustriaEtanolPorSemana With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (m³)",
                                                                                .SEMANA1 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 1) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 1),
                                                                                .SEMANA2 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 2) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 2),
                                                                                .SEMANA3 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 3) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 3),
                                                                                .SEMANA4 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 4) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 4),
                                                                                .SEMANA5 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 5) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 5),
                                                                                .SEMANA6 = GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 6) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 6)}

        Dim obj07DesvioPercentual = New S5TIndustriaEtanolPorSemana With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .SEMANA1 = IIf(GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 1) = 0, 0, Math.Round((GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 1) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 1)) / GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 1), 4)),
                                                        .SEMANA2 = IIf(GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 2) = 0, 0, Math.Round((GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 2) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 2)) / GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 2), 4)),
                                                        .SEMANA3 = IIf(GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 3) = 0, 0, Math.Round((GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 3) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 3)) / GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 3), 4)),
                                                        .SEMANA4 = IIf(GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 4) = 0, 0, Math.Round((GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 4) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 4)) / GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 4), 4)),
                                                        .SEMANA5 = IIf(GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 5) = 0, 0, Math.Round((GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 5) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 5)) / GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 5), 4)),
                                                        .SEMANA6 = IIf(GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 6) = 0, 0, Math.Round((GetIndustriaEtanolPorSemanaAcumulado(obj03RealizadoPorSemana, 6) - GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 6)) / GetIndustriaEtanolPorSemanaAcumulado(obj01PlanejadoPorSemana, 6), 4))}

        varIndustriaEtanolPorSemana.Add(obj01PlanejadoPorSemana)
        varIndustriaEtanolPorSemana.Add(obj02PlanejadoAcumuladoPorSemana)

        varIndustriaEtanolPorSemana.Add(obj03RealizadoPorSemana)
        varIndustriaEtanolPorSemana.Add(obj04RealizadoAcumuladoPorSemana)

        varIndustriaEtanolPorSemana.Add(obj05RealizadoMenosPlanejadoPorSemana)
        varIndustriaEtanolPorSemana.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorSemana)
        varIndustriaEtanolPorSemana.Add(obj07DesvioPercentual)

        GetIndustriaEtanolPorTipoPorSemana = varIndustriaEtanolPorSemana
    End Function

    Private Function GetIndustriaEtanolPorTipoPorMes(parDados As List(Of S5TIndustriaEtanol)) As List(Of S5TIndustriaEtanolPorMes)
        Dim varIndustriaEtanolPorMes = New List(Of S5TIndustriaEtanolPorMes)

        Dim dadosPorMes = parDados.GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaEtanol With {.MES = y.Min(Function(group) group.MES), _
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

        Dim obj01PlanejadoPorMes = New S5TIndustriaEtanolPorMes With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Mensal (m³/mês)",
                                                                        .MES1 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes01),
                                                                        .MES2 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes02),
                                                                        .MES3 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes03),
                                                                        .MES4 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes04),
                                                                        .MES5 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes05),
                                                                        .MES6 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes06),
                                                                        .MES7 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes07),
                                                                        .MES8 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes08),
                                                                        .MES9 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes09),
                                                                        .MES10 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes10),
                                                                        .MES11 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes11),
                                                                        .MES12 = GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes12)}

        Dim obj02PlanejadoAcumuladoPorMes = New S5TIndustriaEtanolPorMes With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (m³/safra)",
                                                                        .MES1 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 1),
                                                                        .MES2 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 2),
                                                                        .MES3 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 3),
                                                                        .MES4 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 4),
                                                                        .MES5 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 5),
                                                                        .MES6 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 6),
                                                                        .MES7 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 7),
                                                                        .MES8 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 8),
                                                                        .MES9 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 9),
                                                                        .MES10 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 10),
                                                                        .MES11 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 11),
                                                                        .MES12 = GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 12)}

        Dim obj03RealizadoPorMes = New S5TIndustriaEtanolPorMes With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Mensal (m³/mês)",
                                                                        .MES1 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes01),
                                                                        .MES2 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes02),
                                                                        .MES3 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes03),
                                                                        .MES4 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes04),
                                                                        .MES5 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes05),
                                                                        .MES6 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes06),
                                                                        .MES7 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes07),
                                                                        .MES8 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes08),
                                                                        .MES9 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes09),
                                                                        .MES10 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes10),
                                                                        .MES11 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes11),
                                                                        .MES12 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes12)}

        Dim obj04RealizadoAcumuladoPorMes = New S5TIndustriaEtanolPorMes With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (m³/safra)",
                                                                        .MES1 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 1),
                                                                        .MES2 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 2),
                                                                        .MES3 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 3),
                                                                        .MES4 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 4),
                                                                        .MES5 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 5),
                                                                        .MES6 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 6),
                                                                        .MES7 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 7),
                                                                        .MES8 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 8),
                                                                        .MES9 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 9),
                                                                        .MES10 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 10),
                                                                        .MES11 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 11),
                                                                        .MES12 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 12)}

        Dim obj05RealizadoMenosPlanejadoPorMes = New S5TIndustriaEtanolPorMes With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Mensal (m³)",
                                                                                        .MES1 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes01) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes01),
                                                                                        .MES2 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes02) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes02),
                                                                                        .MES3 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes03) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes03),
                                                                                        .MES4 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes04) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes04),
                                                                                        .MES5 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes05) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes05),
                                                                                        .MES6 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes06) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes06),
                                                                                        .MES7 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes07) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes07),
                                                                                        .MES8 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes08) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes08),
                                                                                        .MES9 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes09) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes09),
                                                                                        .MES10 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes10) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes10),
                                                                                        .MES11 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes11) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes11),
                                                                                        .MES12 = GetInfoObjIndustriaEtanol(TipoCampo.ValorRealizado, varObjMes12) - GetInfoObjIndustriaEtanol(TipoCampo.ValorPlanejado, varObjMes12)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorMes = New S5TIndustriaEtanolPorMes With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (m³)",
                                                                                .MES1 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 1) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 1),
                                                                                .MES2 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 2) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 2),
                                                                                .MES3 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 3) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 3),
                                                                                .MES4 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 4) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 4),
                                                                                .MES5 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 5) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 5),
                                                                                .MES6 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 6) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 6),
                                                                                .MES7 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 7) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 7),
                                                                                .MES8 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 8) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 8),
                                                                                .MES9 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 9) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 9),
                                                                                .MES10 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 10) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 10),
                                                                                .MES11 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 11) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 11),
                                                                                .MES12 = GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 12) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 12)}

        Dim obj07DesvioPercentual = New S5TIndustriaEtanolPorMes With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .MES1 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 1) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 1) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 1)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 1), 4)),
                                                        .MES2 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 2) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 2) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 2)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 2), 4)),
                                                        .MES3 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 3) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 3) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 3)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 3), 4)),
                                                        .MES4 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 4) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 4) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 4)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 4), 4)),
                                                        .MES5 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 5) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 5) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 5)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 5), 4)),
                                                        .MES6 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 6) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 6) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 6)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 6), 4)),
                                                        .MES7 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 7) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 7) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 7)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 7), 4)),
                                                        .MES8 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 8) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 8) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 8)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 8), 4)),
                                                        .MES9 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 9) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 9) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 9)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 9), 4)),
                                                        .MES10 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 10) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 10) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 10)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 10), 4)),
                                                        .MES11 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 11) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 11) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 11)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 11), 4)),
                                                        .MES12 = IIf(GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 12) = 0, 0, Math.Round((GetIndustriaEtanolPorMesAcumulado(obj03RealizadoPorMes, 12) - GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 12)) / GetIndustriaEtanolPorMesAcumulado(obj01PlanejadoPorMes, 12), 4))}

        varIndustriaEtanolPorMes.Add(obj01PlanejadoPorMes)
        varIndustriaEtanolPorMes.Add(obj02PlanejadoAcumuladoPorMes)

        varIndustriaEtanolPorMes.Add(obj03RealizadoPorMes)
        varIndustriaEtanolPorMes.Add(obj04RealizadoAcumuladoPorMes)

        varIndustriaEtanolPorMes.Add(obj05RealizadoMenosPlanejadoPorMes)
        varIndustriaEtanolPorMes.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoPorMes)
        varIndustriaEtanolPorMes.Add(obj07DesvioPercentual)

        GetIndustriaEtanolPorTipoPorMes = varIndustriaEtanolPorMes
    End Function


    Private Function GetIndustriaEtanolPorHoraAcumulado(parIndustriaEtanolPorHora As S5TIndustriaEtanolPorHora, parHora As Integer) As Double
        Dim varValor = 0

        Select Case parHora
            Case 0
                varValor = parIndustriaEtanolPorHora.H00
            Case 1
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01
            Case 2
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02
            Case 3
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03
            Case 4
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04
            Case 5
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05
            Case 6
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06
            Case 7
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07
            Case 8
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08
            Case 9
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09
            Case 10
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10
            Case 11
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11
            Case 12
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12
            Case 13
                varValor = parIndustriaEtanolPorHora.H00 + 
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13
            Case 14
                varValor = parIndustriaEtanolPorHora.H00 +
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13 +
                           parIndustriaEtanolPorHora.H14
            Case 15
                varValor = parIndustriaEtanolPorHora.H00 +
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13 +
                           parIndustriaEtanolPorHora.H14 +
                           parIndustriaEtanolPorHora.H15
            Case 16
                varValor = parIndustriaEtanolPorHora.H00 +
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13 +
                           parIndustriaEtanolPorHora.H14 +
                           parIndustriaEtanolPorHora.H15 +
                           parIndustriaEtanolPorHora.H16
            Case 17
                varValor = parIndustriaEtanolPorHora.H00 +
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13 +
                           parIndustriaEtanolPorHora.H14 +
                           parIndustriaEtanolPorHora.H15 +
                           parIndustriaEtanolPorHora.H16 +
                           parIndustriaEtanolPorHora.H17
            Case 18
                varValor = parIndustriaEtanolPorHora.H00 +
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13 +
                           parIndustriaEtanolPorHora.H14 +
                           parIndustriaEtanolPorHora.H15 +
                           parIndustriaEtanolPorHora.H16 +
                           parIndustriaEtanolPorHora.H17 +
                           parIndustriaEtanolPorHora.H18
            Case 19
                varValor = parIndustriaEtanolPorHora.H00 +
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13 +
                           parIndustriaEtanolPorHora.H14 +
                           parIndustriaEtanolPorHora.H15 +
                           parIndustriaEtanolPorHora.H16 +
                           parIndustriaEtanolPorHora.H17 +
                           parIndustriaEtanolPorHora.H18 +
                           parIndustriaEtanolPorHora.H19
            Case 20
                varValor = parIndustriaEtanolPorHora.H00 +
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13 +
                           parIndustriaEtanolPorHora.H14 +
                           parIndustriaEtanolPorHora.H15 +
                           parIndustriaEtanolPorHora.H16 +
                           parIndustriaEtanolPorHora.H17 +
                           parIndustriaEtanolPorHora.H18 +
                           parIndustriaEtanolPorHora.H19 +
                           parIndustriaEtanolPorHora.H20
            Case 21
                varValor = parIndustriaEtanolPorHora.H00 +
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13 +
                           parIndustriaEtanolPorHora.H14 +
                           parIndustriaEtanolPorHora.H15 +
                           parIndustriaEtanolPorHora.H16 +
                           parIndustriaEtanolPorHora.H17 +
                           parIndustriaEtanolPorHora.H18 +
                           parIndustriaEtanolPorHora.H19 +
                           parIndustriaEtanolPorHora.H20 +
                           parIndustriaEtanolPorHora.H21
            Case 22
                varValor = parIndustriaEtanolPorHora.H00 +
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13 +
                           parIndustriaEtanolPorHora.H14 +
                           parIndustriaEtanolPorHora.H15 +
                           parIndustriaEtanolPorHora.H16 +
                           parIndustriaEtanolPorHora.H17 +
                           parIndustriaEtanolPorHora.H18 +
                           parIndustriaEtanolPorHora.H19 +
                           parIndustriaEtanolPorHora.H20 +
                           parIndustriaEtanolPorHora.H21 +
                           parIndustriaEtanolPorHora.H22
            Case 23
                varValor = parIndustriaEtanolPorHora.H00 +
                           parIndustriaEtanolPorHora.H01 +
                           parIndustriaEtanolPorHora.H02 +
                           parIndustriaEtanolPorHora.H03 +
                           parIndustriaEtanolPorHora.H04 +
                           parIndustriaEtanolPorHora.H05 +
                           parIndustriaEtanolPorHora.H06 +
                           parIndustriaEtanolPorHora.H07 +
                           parIndustriaEtanolPorHora.H08 +
                           parIndustriaEtanolPorHora.H09 +
                           parIndustriaEtanolPorHora.H10 +
                           parIndustriaEtanolPorHora.H11 +
                           parIndustriaEtanolPorHora.H12 +
                           parIndustriaEtanolPorHora.H13 +
                           parIndustriaEtanolPorHora.H14 +
                           parIndustriaEtanolPorHora.H15 +
                           parIndustriaEtanolPorHora.H16 +
                           parIndustriaEtanolPorHora.H17 +
                           parIndustriaEtanolPorHora.H18 +
                           parIndustriaEtanolPorHora.H19 +
                           parIndustriaEtanolPorHora.H20 +
                           parIndustriaEtanolPorHora.H21 +
                           parIndustriaEtanolPorHora.H22 +
                           parIndustriaEtanolPorHora.H23
        End Select

        GetIndustriaEtanolPorHoraAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustriaEtanolPorDiaAcumulado(parIndustriaEtanolPorDia As S5TIndustriaEtanolPorDia, parDia As Integer) As Double
        Dim varValor = 0

        Select Case parDia
            Case 1
                varValor = parIndustriaEtanolPorDia.DIA1
            Case 2
                varValor = parIndustriaEtanolPorDia.DIA1 + 
                           parIndustriaEtanolPorDia.DIA2
            Case 3
                varValor = parIndustriaEtanolPorDia.DIA1 + 
                           parIndustriaEtanolPorDia.DIA2 +
                           parIndustriaEtanolPorDia.DIA3
            Case 4
                varValor = parIndustriaEtanolPorDia.DIA1 + 
                           parIndustriaEtanolPorDia.DIA2 +
                           parIndustriaEtanolPorDia.DIA3 +
                           parIndustriaEtanolPorDia.DIA4
            Case 5
                varValor = parIndustriaEtanolPorDia.DIA1 + 
                           parIndustriaEtanolPorDia.DIA2 +
                           parIndustriaEtanolPorDia.DIA3 +
                           parIndustriaEtanolPorDia.DIA4 +
                           parIndustriaEtanolPorDia.DIA5
            Case 6
                varValor = parIndustriaEtanolPorDia.DIA1 + 
                           parIndustriaEtanolPorDia.DIA2 +
                           parIndustriaEtanolPorDia.DIA3 +
                           parIndustriaEtanolPorDia.DIA4 +
                           parIndustriaEtanolPorDia.DIA5 +
                           parIndustriaEtanolPorDia.DIA6
            Case 7
                varValor = parIndustriaEtanolPorDia.DIA1 + 
                           parIndustriaEtanolPorDia.DIA2 +
                           parIndustriaEtanolPorDia.DIA3 +
                           parIndustriaEtanolPorDia.DIA4 +
                           parIndustriaEtanolPorDia.DIA5 +
                           parIndustriaEtanolPorDia.DIA6 +
                           parIndustriaEtanolPorDia.DIA7
        End Select

        GetIndustriaEtanolPorDiaAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustriaEtanolPorSemanaAcumulado(parIndustriaEtanolPorSemana As S5TIndustriaEtanolPorSemana, parSemana As Integer) As Double
        Dim varValor = 0

        Select Case parSemana
            Case 1
                varValor = parIndustriaEtanolPorSemana.SEMANA1
            Case 2
                varValor = parIndustriaEtanolPorSemana.SEMANA1 +
                           parIndustriaEtanolPorSemana.SEMANA2
            Case 3
                varValor = parIndustriaEtanolPorSemana.SEMANA1 + 
                           parIndustriaEtanolPorSemana.SEMANA2 +
                           parIndustriaEtanolPorSemana.SEMANA3
            Case 4
                varValor = parIndustriaEtanolPorSemana.SEMANA1 + 
                           parIndustriaEtanolPorSemana.SEMANA2 +
                           parIndustriaEtanolPorSemana.SEMANA3 +
                           parIndustriaEtanolPorSemana.SEMANA4
            Case 5
                varValor = parIndustriaEtanolPorSemana.SEMANA1 + 
                           parIndustriaEtanolPorSemana.SEMANA2 +
                           parIndustriaEtanolPorSemana.SEMANA3 +
                           parIndustriaEtanolPorSemana.SEMANA4 +
                           parIndustriaEtanolPorSemana.SEMANA5
            Case 6
                varValor = parIndustriaEtanolPorSemana.SEMANA1 + 
                           parIndustriaEtanolPorSemana.SEMANA2 +
                           parIndustriaEtanolPorSemana.SEMANA3 +
                           parIndustriaEtanolPorSemana.SEMANA4 +
                           parIndustriaEtanolPorSemana.SEMANA5 +
                           parIndustriaEtanolPorSemana.SEMANA6
        End Select

        GetIndustriaEtanolPorSemanaAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustriaEtanolPorMesAcumulado(parIndustriaEtanolPorMes As S5TIndustriaEtanolPorMes, parMes As Integer) As Double
        Dim varValor = 0

        Select Case parMes
            Case 1
                varValor = parIndustriaEtanolPorMes.MES1
            Case 2
                varValor = parIndustriaEtanolPorMes.MES1 +
                           parIndustriaEtanolPorMes.MES2
            Case 3
                varValor = parIndustriaEtanolPorMes.MES1 + 
                           parIndustriaEtanolPorMes.MES2 +
                           parIndustriaEtanolPorMes.MES3
            Case 4
                varValor = parIndustriaEtanolPorMes.MES1 + 
                           parIndustriaEtanolPorMes.MES2 +
                           parIndustriaEtanolPorMes.MES3 +
                           parIndustriaEtanolPorMes.MES4
            Case 5
                varValor = parIndustriaEtanolPorMes.MES1 + 
                           parIndustriaEtanolPorMes.MES2 +
                           parIndustriaEtanolPorMes.MES3 +
                           parIndustriaEtanolPorMes.MES4 +
                           parIndustriaEtanolPorMes.MES5
            Case 6
                varValor = parIndustriaEtanolPorMes.MES1 + 
                           parIndustriaEtanolPorMes.MES2 +
                           parIndustriaEtanolPorMes.MES3 +
                           parIndustriaEtanolPorMes.MES4 +
                           parIndustriaEtanolPorMes.MES5 +
                           parIndustriaEtanolPorMes.MES6
            Case 7
                varValor = parIndustriaEtanolPorMes.MES1 + 
                           parIndustriaEtanolPorMes.MES2 +
                           parIndustriaEtanolPorMes.MES3 +
                           parIndustriaEtanolPorMes.MES4 +
                           parIndustriaEtanolPorMes.MES5 +
                           parIndustriaEtanolPorMes.MES6 +
                           parIndustriaEtanolPorMes.MES7
            Case 8
                varValor = parIndustriaEtanolPorMes.MES1 + 
                           parIndustriaEtanolPorMes.MES2 +
                           parIndustriaEtanolPorMes.MES3 +
                           parIndustriaEtanolPorMes.MES4 +
                           parIndustriaEtanolPorMes.MES5 +
                           parIndustriaEtanolPorMes.MES6 +
                           parIndustriaEtanolPorMes.MES7 +
                           parIndustriaEtanolPorMes.MES8
            Case 9
                varValor = parIndustriaEtanolPorMes.MES1 + 
                           parIndustriaEtanolPorMes.MES2 +
                           parIndustriaEtanolPorMes.MES3 +
                           parIndustriaEtanolPorMes.MES4 +
                           parIndustriaEtanolPorMes.MES5 +
                           parIndustriaEtanolPorMes.MES6 +
                           parIndustriaEtanolPorMes.MES7 +
                           parIndustriaEtanolPorMes.MES8 +
                           parIndustriaEtanolPorMes.MES9
            Case 10
                varValor = parIndustriaEtanolPorMes.MES1 + 
                           parIndustriaEtanolPorMes.MES2 +
                           parIndustriaEtanolPorMes.MES3 +
                           parIndustriaEtanolPorMes.MES4 +
                           parIndustriaEtanolPorMes.MES5 +
                           parIndustriaEtanolPorMes.MES6 +
                           parIndustriaEtanolPorMes.MES7 +
                           parIndustriaEtanolPorMes.MES8 +
                           parIndustriaEtanolPorMes.MES9 +
                           parIndustriaEtanolPorMes.MES10
            Case 11
                varValor = parIndustriaEtanolPorMes.MES1 + 
                           parIndustriaEtanolPorMes.MES2 +
                           parIndustriaEtanolPorMes.MES3 +
                           parIndustriaEtanolPorMes.MES4 +
                           parIndustriaEtanolPorMes.MES5 +
                           parIndustriaEtanolPorMes.MES6 +
                           parIndustriaEtanolPorMes.MES7 +
                           parIndustriaEtanolPorMes.MES8 +
                           parIndustriaEtanolPorMes.MES9 +
                           parIndustriaEtanolPorMes.MES10 +
                           parIndustriaEtanolPorMes.MES11
            Case 12
                varValor = parIndustriaEtanolPorMes.MES1 + 
                           parIndustriaEtanolPorMes.MES2 +
                           parIndustriaEtanolPorMes.MES3 +
                           parIndustriaEtanolPorMes.MES4 +
                           parIndustriaEtanolPorMes.MES5 +
                           parIndustriaEtanolPorMes.MES6 +
                           parIndustriaEtanolPorMes.MES7 +
                           parIndustriaEtanolPorMes.MES8 +
                           parIndustriaEtanolPorMes.MES9 +
                           parIndustriaEtanolPorMes.MES10 +
                           parIndustriaEtanolPorMes.MES11 +
                           parIndustriaEtanolPorMes.MES12
        End Select

        GetIndustriaEtanolPorMesAcumulado = Math.Round(varValor,0)
    End Function

    Enum TipoCampo
        ValorPlanejado
        ValorRealizado
    End Enum

    Private Function GetInfoObjIndustriaEtanol(parTipoCampo As TipoCampo, parObjIndustriaEtanol As S5TIndustriaEtanol) As Double
        GetInfoObjIndustriaEtanol = 0

        If parObjIndustriaEtanol IsNot Nothing Then
            If parTipoCampo = TipoCampo.ValorPlanejado Then
                GetInfoObjIndustriaEtanol = Math.Round(parObjIndustriaEtanol.VALOR_PLAN,0)
            ElseIf parTipoCampo = TipoCampo.ValorRealizado Then
                GetInfoObjIndustriaEtanol = Math.Round(parObjIndustriaEtanol.VALOR_REAL,0)
            End If
        End If
    End Function

    Private Function GetMediaHoraAnterior(parDadosPorTipoGeralPorHora As List(Of S5TIndustriaEtanolPorHora), parHoraAtual As String) As Double
        GetMediaHoraAnterior = 0

        Dim objRealizadoAcumulado = parDadosPorTipoGeralPorHora.FirstOrDefault(Function(x) x.Diario = "Realizado" And x.Hora = "Acumulado (m³/dia)")

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
End Class
