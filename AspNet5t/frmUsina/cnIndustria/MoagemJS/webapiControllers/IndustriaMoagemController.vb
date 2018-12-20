Imports System.Globalization
Imports System.Reflection
Imports System.Runtime.Serialization
Imports System.Web.Http
Imports Oracle.DataAccess.Client

<RoutePrefix("api/IndustriaMoagem")>
Public Class IndustriaMoagemController
    Inherits ApiController

    Private Property QueryIndustriaMoagem As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, HORA, ID_CA_INDICADOR, DS_CA_INDICADOR, MOENDA, VALOR_PLAN, VALOR_PLAN_NEFETIVA, VALOR_REAL FROM BI4T.INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR IN (46, 25)"
    Private Property QueryIndustriaMoagemPlanejado As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, HORA, ID_CA_INDICADOR, DS_CA_INDICADOR, MOENDA, VALOR_PLAN, VALOR_PLAN_EFETIVA VALOR_PLAN_NEFETIVA, VALOR_REAL FROM BI4T.V_PLAN_INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR = 46"

    <DataContract>
    Public Class S5TIndustriaMoagemSemanaDiaInicioFim
        <DataMember>
        Public Property diaInicio As Date
        <DataMember>
        Public Property diaFim As Date
    End Class

    <DataContract>
    Public Class S5TIndustriaMoagem
        Public Property ID_NEGOCIOS as Integer
        Public Property SAFRA As Integer
        <DataMember>
        Public Property MES As Integer
        <DataMember>
        Public Property SEMANA As Integer
        <DataMember>
        Public Property semanaPeriodo As S5TIndustriaMoagemSemanaDiaInicioFim
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
    Public Class S5TIndustriaMoagemPorHora
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
    Public Class S5TIndustriaMoagemPorDia
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
    Public Class S5TIndustriaMoagemPorSemana
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
    Public Class S5TIndustriaMoagemPorMes
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
    Public Class S5TIndustriaMoagemPorMoendaPorDia
        <DataMember>
        Public Property moenda As String
        <DataMember>
        Public Property oGraficoMoagem As List(Of S5TIndustriaMoagem)
        <DataMember>
        Public Property oGraficoMoagemAcumulado As List(Of S5TIndustriaMoagem)
        <DataMember>
        Public Property oGridMoagem As List(Of S5TIndustriaMoagemPorHora)
        <DataMember>
        Public Property oGridMoagemProjecao As List(Of S5TIndustriaMoagemProjecao)
        <DataMember>
        Public Property HoraAtual As String
        <DataMember>
        Public Property Passo As Double
        <DataMember>
        Public Property MediaMoagemHoraAnterior As Double
        <DataMember>
        Public Property EstoquePatio As Double
    End Class

    <DataContract>
    Public Class S5TIndustriaMoagemPorMoendaPorSemana
        <DataMember>
        Public Property moenda As String
        <DataMember>
        Public Property oGraficoMoagem As List(Of S5TIndustriaMoagem)
        <DataMember>
        Public Property oGraficoMoagemAcumulado As List(Of S5TIndustriaMoagem)
        <DataMember>
        Public Property oGridMoagem As List(Of S5TIndustriaMoagemPorDia)
        <DataMember>
        Public Property oGridMoagemProjecao As List(Of S5TIndustriaMoagemProjecao)
        <DataMember>
        Public Property DiaAtual As Date
    End Class

    <DataContract>
    Public Class S5TIndustriaMoagemPorMoendaPorMes
        <DataMember>
        Public Property moenda As String
        <DataMember>
        Public Property oGraficoMoagem As List(Of S5TIndustriaMoagem)
        <DataMember>
        Public Property oGraficoMoagemAcumulado As List(Of S5TIndustriaMoagem)
        <DataMember>
        Public Property oGridMoagem As List(Of S5TIndustriaMoagemPorSemana)
        <DataMember>
        Public Property oGridMoagemProjecao As List(Of S5TIndustriaMoagemProjecao)
        <DataMember>
        Public Property SemanaAtual As Integer
    End Class

    <DataContract>
    Public Class S5TIndustriaMoagemPorMoendaPorSafra
        <DataMember>
        Public Property moenda As String
        <DataMember>
        Public Property oGraficoMoagem As List(Of S5TIndustriaMoagem)
        <DataMember>
        Public Property oGraficoMoagemAcumulado As List(Of S5TIndustriaMoagem)
        <DataMember>
        Public Property oGridMoagem As List(Of S5TIndustriaMoagemPorMes)
        <DataMember>
        Public Property oGridMoagemProjecao As List(Of S5TIndustriaMoagemProjecao)
        <DataMember>
        Public Property MesAtual As Integer
    End Class


    <DataContract>
    Public Class S5TIndustriaMoagemProjecao
        <DataMember>
        Public Property ProjecaoHora As String
        <DataMember>
        Public Property Projecao As Double
        <DataMember>
        Public Property Meta As Double
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
        Property DiaValMoagem As Double

        <DataMember>
        Property DiaValMoagemMax As Double

        <DataMember>
        Property DiaIndicadorMeta As Integer

        <DataMember>
        Property Semana As Integer
        <DataMember>
        Property SemanaValMoagem As Double

        <DataMember>
        Property SemanaValMoagemMax As Double

        <DataMember>
        Property SemanaIndicadorMeta As Integer

        <DataMember>
        Property Mes As Integer
        <DataMember>
        Property MesValMoagem As Double

        <DataMember>
        Property MesValMoagemMax As Double

        <DataMember>
        Property MesIndicadorMeta As Integer

        <DataMember>
        Property Safra As Integer
        <DataMember>
        Property SafraValMoagem As Double

        <DataMember>
        Property SafraValMoagemMax As Double

        <DataMember>
        Property SafraIndicadorMeta As Integer
    End Class

    ' GET api/IndustriaMoagem/VisaoGeralMinMaxDia/1
    <HttpGet>
    <Route("VisaoGeralMinMaxDia/{parIdNegocios}")>
    Public Function GetValuesMaxDia(parIdNegocios As Integer) As IHttpActionResult
        Return Ok(GetIndustriaMoagemPorSafraMinMaxDia(parIdNegocios))
    End Function


    ' GET api/IndustriaMoagem/VisaoGeral/1/2017
    <HttpGet>
    <Route("VisaoGeral/{parIdNegocios}/{parSafra}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer) As IHttpActionResult
        Dim dadosMoagem = GetIndustriaMoagemPorSafraPlain(parIdNegocios, parSafra)
        Dim dadosMoagemPlanejado = GetIndustriaMoagemPlanejadoPorSafraPlain(parIdNegocios, parSafra)

        Dim ultimoDia = dadosMoagem.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Date

        Dim ultimaHora = dadosMoagem.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Hour

        Dim ultimaSemana = dadosMoagem.OrderByDescending(Function(x) x.SEMANA).FirstOrDefault().SEMANA

        Dim ultimoMes = dadosMoagem.OrderByDescending(Function(x) x.MES).FirstOrDefault().MES


        Dim dadosMoagemDia = dadosMoagem.FindAll(Function (x) x.ID_CA_INDICADOR = 46 And x.DIA.Date = ultimoDia)

        Dim dadosMoagemSemana = dadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 46 And x.SEMANA = ultimaSemana)

        Dim dadosMoagemMes = dadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 46 And x.MES = ultimoMes)

        Dim dadosMoagemSafra = dadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 46)


        Dim dadosMoagemPlanejadoDia = dadosMoagemPlanejado.FindAll(Function (x) x.DIA.Date = ultimoDia)

        Dim dadosMoagemPlanejadoSemana = dadosMoagemPlanejado.FindAll(Function(x) x.SEMANA = ultimaSemana)

        Dim dadosMoagemPlanejadoMes = dadosMoagemPlanejado.FindAll(Function(x) x.MES = ultimoMes)

        Dim dadosMoagemPlanejadoSafra = dadosMoagemPlanejado


        Dim varVisaoGeralDia = GetValoresVisaoGeral(dadosMoagemDia, dadosMoagemPlanejadoDia, MoagemPeriodo.Dia)
        Dim varVisaoGeralSemana = GetValoresVisaoGeral(dadosMoagemSemana, dadosMoagemPlanejadoSemana, MoagemPeriodo.Semana)
        Dim varVisaoGeralMes = GetValoresVisaoGeral(dadosMoagemMes, dadosMoagemPlanejadoMes,  MoagemPeriodo.Mes)
        Dim varVisaoGeralSafra = GetValoresVisaoGeral(dadosMoagemSafra, dadosMoagemPlanejadoSafra, MoagemPeriodo.Safra)

        'Metas determinadas
        'varVisaoGeralDia.ValMax = 40000
        'varVisaoGeralSemana.ValMax = 280000
        'varVisaoGeralMes.ValMax = 1000000
        'varVisaoGeralSafra.ValMax = 6000000

        'Alertar insuficiência de meta no dia?
        Dim varDadosMoagemPorMoendaGeral = dadosMoagemDia.GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                        Key .HORA = x.HORA, _
                                                                                        Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                        Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                   .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                   .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                   .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                   .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                                                   .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosMoagemPorMoendaGeralPorHora = GetIndustriaMoagemPorMoendaPorHora(varDadosMoagemPorMoendaGeral)

        'Apura a projeção do dia
        Dim varIndustriaMoagemProjecaoPorDia = GetIndustriaMoagemProjecaoPorDia(varDadosMoagemPorMoendaGeralPorHora, ultimaHora.ToString().PadLeft(2,"0"))

        If varVisaoGeralDia.IndicadorMeta = 0 And GetProjecaoDiaAlertarInsuficiencia(varIndustriaMoagemProjecaoPorDia) Then
            varVisaoGeralDia.IndicadorMeta = 1
        End If

        Dim varVisaoGeral = New S5TVisaoGeral With {
                .Dia = ultimoDia,
                .Hora = ultimaHora,
                .DiaValMoagem = varVisaoGeralDia.Val,
                .DiaValMoagemMax = varVisaoGeralDia.ValMax,
                .DiaIndicadorMeta = varVisaoGeralDia.IndicadorMeta,
                .Semana = ultimaSemana,
                .SemanaValMoagem = varVisaoGeralSemana.Val,
                .SemanaValMoagemMax = varVisaoGeralSemana.ValMax,
                .SemanaIndicadorMeta = varVisaoGeralSemana.IndicadorMeta,
                .Mes = ultimoMes,
                .MesValMoagem = varVisaoGeralMes.Val,
                .MesValMoagemMax = varVisaoGeralMes.ValMax,
                .MesIndicadorMeta = varVisaoGeralMes.IndicadorMeta,
                .Safra = parSafra,
                .SafraValMoagem = varVisaoGeralSafra.Val,
                .SafraValMoagemMax = varVisaoGeralSafra.ValMax,
                .SafraIndicadorMeta = varVisaoGeralSafra.IndicadorMeta
                }

        Return Ok(varVisaoGeral)
    End Function

    ' GET api/IndustriaMoagem/VisaoGeralCorteDia/1/2017/20171110
    <HttpGet>
    <Route("VisaoGeralCorteDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValuesCorteDia(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim dadosMoagem = GetIndustriaMoagemPorSafraCorteDiaPlain(parIdNegocios, parSafra, parDia)
        Dim dadosMoagemPlanejado = GetIndustriaMoagemPlanejadoPorSafraPlain(parIdNegocios, parSafra)

        Dim ultimoDia = dadosMoagem.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Date

        Dim ultimaHora = dadosMoagem.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Hour

        Dim ultimaSemana = dadosMoagem.OrderByDescending(Function(x) x.SEMANA).FirstOrDefault().SEMANA

        Dim ultimoMes = dadosMoagem.OrderByDescending(Function(x) x.MES).FirstOrDefault().MES


        Dim dadosMoagemDia = dadosMoagem.FindAll(Function (x) x.ID_CA_INDICADOR = 46 And x.DIA.Date = ultimoDia)

        Dim dadosMoagemSemana = dadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 46 And x.SEMANA = ultimaSemana)

        Dim dadosMoagemMes = dadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 46 And x.MES = ultimoMes)

        Dim dadosMoagemSafra = dadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 46)


        Dim dadosMoagemPlanejadoDia = dadosMoagemPlanejado.FindAll(Function (x) x.DIA.Date = ultimoDia)

        Dim dadosMoagemPlanejadoSemana = dadosMoagemPlanejado.FindAll(Function(x) x.SEMANA = ultimaSemana)

        Dim dadosMoagemPlanejadoMes = dadosMoagemPlanejado.FindAll(Function(x) x.MES = ultimoMes)

        Dim dadosMoagemPlanejadoSafra = dadosMoagemPlanejado


        Dim varVisaoGeralDia = GetValoresVisaoGeral(dadosMoagemDia, dadosMoagemPlanejadoDia, MoagemPeriodo.Dia)
        Dim varVisaoGeralSemana = GetValoresVisaoGeral(dadosMoagemSemana,dadosMoagemPlanejadoSemana, MoagemPeriodo.Semana)
        Dim varVisaoGeralMes = GetValoresVisaoGeral(dadosMoagemMes, dadosMoagemPlanejadoMes, MoagemPeriodo.Mes)
        Dim varVisaoGeralSafra = GetValoresVisaoGeral(dadosMoagemSafra, dadosMoagemPlanejadoSafra, MoagemPeriodo.Safra)

        'Metas determinadas
        'varVisaoGeralDia.ValMax = 40000
        'varVisaoGeralSemana.ValMax = 280000
        'varVisaoGeralMes.ValMax = 1000000
        'varVisaoGeralSafra.ValMax = 6000000

        'Alertar insuficiência de meta no dia?
        Dim varDadosMoagemPorMoendaGeral = dadosMoagemDia.GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                        Key .HORA = x.HORA, _
                                                                                        Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                        Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                   .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                   .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                   .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                   .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                                                   .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosMoagemPorMoendaGeralPorHora = GetIndustriaMoagemPorMoendaPorHora(varDadosMoagemPorMoendaGeral)

        'Apura a projeção do dia
        Dim varIndustriaMoagemProjecaoPorDia = GetIndustriaMoagemProjecaoPorDia(varDadosMoagemPorMoendaGeralPorHora, ultimaHora.ToString().PadLeft(2,"0"))

        If varVisaoGeralDia.IndicadorMeta = 0 And GetProjecaoDiaAlertarInsuficiencia(varIndustriaMoagemProjecaoPorDia) Then
            varVisaoGeralDia.IndicadorMeta = 1
        End If

        Dim varVisaoGeral = New S5TVisaoGeral With {
                .Dia = ultimoDia,
                .Hora = ultimaHora,
                .DiaValMoagem = varVisaoGeralDia.Val,
                .DiaValMoagemMax = varVisaoGeralDia.ValMax,
                .DiaIndicadorMeta = varVisaoGeralDia.IndicadorMeta,
                .Semana = ultimaSemana,
                .SemanaValMoagem = varVisaoGeralSemana.Val,
                .SemanaValMoagemMax = varVisaoGeralSemana.ValMax,
                .SemanaIndicadorMeta = varVisaoGeralSemana.IndicadorMeta,
                .Mes = ultimoMes,
                .MesValMoagem = varVisaoGeralMes.Val,
                .MesValMoagemMax = varVisaoGeralMes.ValMax,
                .MesIndicadorMeta = varVisaoGeralMes.IndicadorMeta,
                .Safra = parSafra,
                .SafraValMoagem = varVisaoGeralSafra.Val,
                .SafraValMoagemMax = varVisaoGeralSafra.ValMax,
                .SafraIndicadorMeta = varVisaoGeralSafra.IndicadorMeta
                }

        Return Ok(varVisaoGeral)
    End Function


    ' GET api/IndustriaMoagem/PorDia/1/2017/20171117
    <HttpGet>
    <Route("PorDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim dadosMoagem = GetIndustriaMoagemPorDiaPlain(parIdNegocios, parSafra, varDia)

        Dim dadosMoagemPorMoenda = GetIndustriaMoagemPorMoendaAgrupadoPorDiaHora(dadosMoagem)

        Return Ok(dadosMoagemPorMoenda)
    End Function

    ' GET api/IndustriaMoagem/PorSemana/1/2017/46
    <HttpGet>
    <Route("PorSemana/{parIdNegocios}/{parSafra}/{parSemana}")>
    Public Function GetValues(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As IHttpActionResult
        Dim dadosMoagem = GetIndustriaMoagemPorSemanaPlain(parIdNegocios, parSafra, parSemana)

        Dim dadosMoagemPorMoenda = GetIndustriaMoagemPorMoendaAgrupadoPorSemana(dadosMoagem)

        Return Ok(dadosMoagemPorMoenda)
    End Function

    ' GET api/IndustriaMoagem/PorMes/1/2017/11
    <HttpGet>
    <Route("PorMes/{parIdNegocios}/{parSafra}/{parMes}")>
    Public Function GetValuesMes(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As IHttpActionResult
        Dim dadosMoagem = GetIndustriaMoagemPorMesPlain(parIdNegocios, parSafra, parMes)

        Dim dadosMoagemPorMoenda = GetIndustriaMoagemPorMoendaAgrupadoPorMes(dadosMoagem)

        Return Ok(dadosMoagemPorMoenda)
    End Function

    ' GET api/IndustriaMoagem/PorSafra/1/2017
    <HttpGet>
    <Route("PorSafra/{parIdNegocios}/{parSafra}")>
    Public Function GetValuesSafra(parIdNegocios As Integer, parSafra As Integer) As IHttpActionResult
        Dim dadosMoagem = GetIndustriaMoagemPorSafraPlain(parIdNegocios, parSafra)

        Dim dadosMoagemPorMoenda = GetIndustriaMoagemPorMoendaAgrupadoPorSafra(dadosMoagem)

        Return Ok(dadosMoagemPorMoenda)
    End Function

    ' GET api/IndustriaMoagem/PorSafraCorteDia/1/2017/20171110
    <HttpGet>
    <Route("PorSafraCorteDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValuesSafraCorteDia(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim dadosMoagem = GetIndustriaMoagemPorSafraCorteDiaPlain(parIdNegocios, parSafra, parDia)

        Dim dadosMoagemPorMoenda = GetIndustriaMoagemPorMoendaAgrupadoPorSafra(dadosMoagem)

        Return Ok(dadosMoagemPorMoenda)
    End Function

    
    Public Function GetIndustriaMoagemPorSafraMinMaxDia(parIdNegocios As Integer) As Object
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosMoagem As New OracleCommand(
            "SELECT MAX(SAFRA) SAFRA, MIN(DIA) MINDIA, MAX(DIA) MAXDIA, MAX(to_char(DIA + cast('0 '||HORA||':00:00' as interval day to second), 'YYYYMMDDHH24MI')) MAXDIAHORA, MIN(SEMANA) MINSEMANA, MAX(SEMANA) MAXSEMANA, MIN(MES) MINMES, MAX(MES) MAXMES FROM BI4T.INDICADORES_INDUSTRIA WHERE ID_CA_INDICADOR = 46 AND ID_NEGOCIOS = :p0",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosMoagem.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios

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

        Dim drDadosMoagem As OracleDataReader = Nothing
        Try
            drDadosMoagem = cmdDadosMoagem.ExecuteReader()
            If drDadosMoagem.HasRows Then
                Do While drDadosMoagem.Read
                    varSafra = Nvl(drDadosMoagem.Item("SAFRA"), 0)

                    varMinDia = Nvl(drDadosMoagem.Item("MINDIA"), DateTime.MinValue)
                    varMaxDia = Nvl(drDadosMoagem.Item("MAXDIA"), DateTime.MinValue)
                    varMaxDiaHora = Nvl(drDadosMoagem.Item("MAXDIAHORA"), "")
                    varMaxHora = varMaxDiaHora.Substring(8,2)

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

        GetIndustriaMoagemPorSafraMinMaxDia = New With {
            Key .safra = varSafra,
            Key .MinDia = varMinDia, 
            Key .MaxDia = varMaxDia, 
            Key .MaxHora = varMaxHora, 
            Key .MinSemana = varMinSemana, 
            Key .MaxSemana = varMaxSemana, 
            Key .MinMes = varMinMes, 
            Key .MaxMes = varMaxMes}
    End Function


    Public Function GetIndustriaMoagemPorSafraPlain(parIdNegocios As Integer, parSafra As Integer) As List(Of S5TIndustriaMoagem)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosMoagem As New OracleCommand(
            QueryIndustriaMoagem & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosMoagem.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosMoagem.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra

        Return GetDadosMoagem(conn, cmdDadosMoagem)
    End Function

    Public Function GetIndustriaMoagemPlanejadoPorSafraPlain(parIdNegocios As Integer, parSafra As Integer) As List(Of S5TIndustriaMoagem)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosMoagem As New OracleCommand(
            QueryIndustriaMoagemPlanejado & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosMoagem.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosMoagem.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra

        Return GetDadosMoagem(conn, cmdDadosMoagem)
    End Function


    Public Function GetIndustriaMoagemPorSafraCorteDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As String) As List(Of S5TIndustriaMoagem)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim cmdDadosMoagem As New OracleCommand(
            QueryIndustriaMoagem & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA <= :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosMoagem.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosMoagem.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosMoagem.Parameters.Add(":p2", OracleDbType.Date).Value = varDia

        Return GetDadosMoagem(conn, cmdDadosMoagem)
    End Function
    
    Public Function GetIndustriaMoagemPorDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As DateTime) As List(Of S5TIndustriaMoagem)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosMoagem As New OracleCommand(
            QueryIndustriaMoagem & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosMoagem.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosMoagem.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosMoagem.Parameters.Add(":p2", OracleDbType.Date).Value = parDia

        Return GetDadosMoagem(conn, cmdDadosMoagem)
    End Function

    Public Function GetIndustriaMoagemPorSemanaPlain(parIdNegocios As Integer, parSafra As Integer, parSemana As Integer) As List(Of S5TIndustriaMoagem)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosMoagem As New OracleCommand(
            QueryIndustriaMoagem & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND SEMANA = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosMoagem.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosMoagem.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosMoagem.Parameters.Add(":p2", OracleDbType.Int16).Value = parSemana

        Return GetDadosMoagem(conn, cmdDadosMoagem)
    End Function

    Public Function GetIndustriaMoagemPorMesPlain(parIdNegocios As Integer, parSafra As Integer, parMes As Integer) As List(Of S5TIndustriaMoagem)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosMoagem As New OracleCommand(
            QueryIndustriaMoagem & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND MES = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosMoagem.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosMoagem.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosMoagem.Parameters.Add(":p2", OracleDbType.Int16).Value = parMes

        Return GetDadosMoagem(conn, cmdDadosMoagem)
    End Function


    Private Function GetDadosMoagem(parConnection As OracleConnection, parCommand As OracleCommand) As List(Of S5TIndustriaMoagem)
        Dim dadosMoagem As New List(Of S5TIndustriaMoagem)

        parConnection.Open()

        Dim drDadosMoagem As OracleDataReader = Nothing
        Try
            drDadosMoagem = parCommand.ExecuteReader()
            If drDadosMoagem.HasRows Then
                Do While drDadosMoagem.Read
                    Dim objDadosMoagem = New S5TIndustriaMoagem

                    objDadosMoagem.ID_NEGOCIOS = AppUtils.Nvl(drDadosMoagem.Item("ID_NEGOCIOS"), 0)
                    objDadosMoagem.SAFRA = AppUtils.Nvl(drDadosMoagem.Item("SAFRA"), 0)
                    objDadosMoagem.MES = AppUtils.Nvl(drDadosMoagem.Item("MES"), 0)
                    objDadosMoagem.SEMANA = AppUtils.Nvl(drDadosMoagem.Item("SEMANA"), 0)
                    objDadosMoagem.DIA = Nvl(drDadosMoagem.Item("DIA"), DateTime.MinValue)
                    objDadosMoagem.DIA = objDadosMoagem.DIA.AddHours(Convert.ToInt16(AppUtils.Nvl(drDadosMoagem.Item("HORA").ToString().Substring(0, 2), "")))
                    objDadosMoagem.HORA = AppUtils.Nvl(drDadosMoagem.Item("HORA"), "")
                    objDadosMoagem.ID_CA_INDICADOR = AppUtils.Nvl(drDadosMoagem.Item("ID_CA_INDICADOR"), 0)
                    objDadosMoagem.DS_CA_INDICADOR = AppUtils.Nvl(drDadosMoagem.Item("DS_CA_INDICADOR"), "")
                    objDadosMoagem.MOENDA = AppUtils.Nvl(drDadosMoagem.Item("MOENDA"), "")
                    objDadosMoagem.VALOR_PLAN = AppUtils.Nvl(drDadosMoagem.Item("VALOR_PLAN"), 0)
                    objDadosMoagem.VALOR_PLAN_NEFETIVA = AppUtils.Nvl(drDadosMoagem.Item("VALOR_PLAN_NEFETIVA"), 0)
                    objDadosMoagem.VALOR_REAL = AppUtils.Nvl(drDadosMoagem.Item("VALOR_REAL"), 0)

                    dadosMoagem.Add(objDadosMoagem)
                Loop

                drDadosMoagem.Close()
            End If
        Catch ex As Exception
            'Return InternalServerError(ex)
        Finally
            parConnection.Close()
            If (Not (drDadosMoagem) Is Nothing) Then
                drDadosMoagem.Dispose()
            End If
        End Try

        GetDadosMoagem = dadosMoagem
    End Function

    Private Enum MoagemPeriodo
        Dia
        Semana
        Mes
        Safra
    End Enum

    Private Function GetValoresVisaoGeral(parDadosMoagem As List(Of S5TIndustriaMoagem), parDadosMoagemPlanejado As List(Of S5TIndustriaMoagem), parPeriodo As MoagemPeriodo) As S5TVisaoGeralAux
        Dim valMoagem = Math.Round(parDadosMoagem.Sum(Function(x) x.VALOR_REAL), 0)

        Dim parDadosMoagemParaMeta As List(Of S5TIndustriaMoagem)

        If parPeriodo = MoagemPeriodo.Dia Then
            Dim varHoraAnterior = parDadosMoagem.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Hour -1

            parDadosMoagemParaMeta = parDadosMoagem.FindAll(Function(x) x.HORA <= varHoraAnterior)
        Else
            Dim varDiaAnterior = parDadosMoagem.OrderByDescending(Function(x) x.DIA).FirstOrDefault().DIA.Date.AddDays(-1)

            parDadosMoagemParaMeta = parDadosMoagem.FindAll(Function(x) x.DIA <= varDiaAnterior)
        End If

        'PARA NÃO FALHAR COM DIA NA PRIMEIRA HORA DO DIA, COM SEMANA NO PRIMEIRO DIA DA SEMANA
        If parDadosMoagemParaMeta.Count = 0 Then
            parDadosMoagemParaMeta = parDadosMoagem
        End If

        Dim valMeta As Double = 0
        Dim valMoagemMax As Double = 0

        If parPeriodo = MoagemPeriodo.Dia Then
            valMeta = Math.Round(parDadosMoagemParaMeta.Sum(Function(x) x.VALOR_PLAN), 0)
            'valMoagemMax = Math.Round(parDadosMoagemPlanejado.Sum(Function(x) x.VALOR_PLAN), 0)
        Else
            valMeta = Math.Round(parDadosMoagemParaMeta.Sum(Function(x) x.VALOR_PLAN_NEFETIVA), 0)
            'valMoagemMax = Math.Round(parDadosMoagemPlanejado.Sum(Function(x) x.VALOR_PLAN_NEFETIVA), 0)
        End If

        valMoagemMax = Math.Round(parDadosMoagemPlanejado.Sum(Function(x) x.VALOR_PLAN_NEFETIVA), 0)

        Dim indicadorMeta = 0

        If valMoagem >= valMeta Then
            'IGUAL OU ACIMA DA META
            indicadorMeta = 0
        ElseIf valMoagem < valMeta Then
            'ABAIXO DA META
            indicadorMeta = 2
        End If

        Return New S5TVisaoGeralAux With {
            .Val = valMoagem,
            .ValMax = valMoagemMax,
            .IndicadorMeta = indicadorMeta
            }
    End Function

    Private Function GetIndustriaMoagemPorMoendaAgrupadoPorDiaHora(parDadosMoagem As List(Of S5TIndustriaMoagem)) As List(Of S5TIndustriaMoagemPorMoendaPorDia)
        Dim varMoendas = New List(Of S5TIndustriaMoagemPorMoendaPorDia) 

        Dim varDadosMoagemPorMoendaGeral = parDadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                    Key .HORA = x.HORA, _
                                                                                                                                    Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                                                                    Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                                                .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                                                                .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosMoagemPorMoendaA = parDadosMoagem.FindAll(Function(x) x.MOENDA = "A").FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                    Key .HORA = x.HORA, _
                                                                                                                                                                    Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                                                                                                    Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                                                                                .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                                                                                                .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosMoagemPorMoendaB = parDadosMoagem.FindAll(Function(x) x.MOENDA = "B").FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .DIA = x.DIA, _
                                                                                                                                                                    Key .HORA = x.HORA, _
                                                                                                                                                                    Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                                                                                                    Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA), _
                                                                                                                                                                                                                                                                .HORA = y.Min(Function(group) group.HORA), _
                                                                                                                                                                                                                                                                .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                                                                                                .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList
                                                                                                                                                                    

        Dim varDadosMoagemPorMoendaGeralAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaGeral)
        Dim varDadosMoagemPorMoendaAAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaA)
        Dim varDadosMoagemPorMoendaBAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaB)

        Dim varDadosMoagemPorMoendaGeralPorHora = GetIndustriaMoagemPorMoendaPorHora(varDadosMoagemPorMoendaGeral)
        Dim varDadosMoagemPorMoendaAPorHora = GetIndustriaMoagemPorMoendaPorHora(varDadosMoagemPorMoendaA)
        Dim varDadosMoagemPorMoendaBPorHora = GetIndustriaMoagemPorMoendaPorHora(varDadosMoagemPorMoendaB)

        Dim varHoraAtual = parDadosMoagem.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().HORA
        Dim varHoraAnterior = varHoraAtual

        If varDadosMoagemPorMoendaGeral.Count > 1 Then
            varHoraAnterior = varDadosMoagemPorMoendaGeral.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA)(1).HORA
        End If

        Dim varEstoquePatio As Double = 0
        Dim objEstoquePatio = parDadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 25 And x.HORA = varHoraAtual).FirstOrDefault()
        If objEstoquePatio IsNot Nothing Then varEstoquePatio = objEstoquePatio.VALOR_REAL

        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorDia With {.moenda = "AB", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaGeral, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaGeralAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaGeralPorHora,
                                                             .oGridMoagemProjecao = GetIndustriaMoagemProjecaoPorDia(varDadosMoagemPorMoendaGeralPorHora, varHoraAtual),
                                                             .HoraAtual = varHoraAtual,
                                                             .Passo = GetPassoPorDia(varDadosMoagemPorMoendaGeralPorHora, varHoraAnterior),
                                                             .MediaMoagemHoraAnterior = GetMediaMoagemHoraAnterior(varDadosMoagemPorMoendaGeralPorHora, varHoraAtual),
                                                             .EstoquePatio = varEstoquePatio})

        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorDia With {.moenda = "A", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaA, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaAAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaAPorHora,
                                                             .oGridMoagemProjecao = GetIndustriaMoagemProjecaoPorDia(varDadosMoagemPorMoendaAPorHora, varHoraAtual),
                                                             .HoraAtual = varHoraAtual,
                                                             .Passo = GetPassoPorDia(varDadosMoagemPorMoendaAPorHora, varHoraAnterior),
                                                             .MediaMoagemHoraAnterior = GetMediaMoagemHoraAnterior(varDadosMoagemPorMoendaAPorHora, varHoraAtual),
                                                             .EstoquePatio = varEstoquePatio})

        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorDia With {.moenda = "B", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaB, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaBAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaBPorHora,
                                                             .oGridMoagemProjecao = GetIndustriaMoagemProjecaoPorDia(varDadosMoagemPorMoendaBPorHora, varHoraAtual),
                                                             .HoraAtual = varHoraAtual,
                                                             .Passo = GetPassoPorDia(varDadosMoagemPorMoendaBPorHora, varHoraAnterior),
                                                             .MediaMoagemHoraAnterior = GetMediaMoagemHoraAnterior(varDadosMoagemPorMoendaBPorHora, varHoraAtual),
                                                             .EstoquePatio = varEstoquePatio})

        GetIndustriaMoagemPorMoendaAgrupadoPorDiaHora = varMoendas
    End Function

    Private Function GetIndustriaMoagemPorMoendaAgrupadoPorSemana(parDadosMoagem As List(Of S5TIndustriaMoagem)) As List(Of S5TIndustriaMoagemPorMoendaPorSemana)
        Dim varMoendas = New List(Of S5TIndustriaMoagemPorMoendaPorSemana) 

        Dim varDadosMoagemPorMoendaGeral = parDadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date, _
                                                                                                                                    Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                                                                    Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                                                                .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosMoagemPorMoendaA = parDadosMoagem.FindAll(Function(x) x.MOENDA = "A").FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date, _
                                                                                                                                                                    Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                                                                                                    Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                                                .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                                                                                                .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosMoagemPorMoendaB = parDadosMoagem.FindAll(Function(x) x.MOENDA = "B").FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .DIA = x.DIA.Date, _
                                                                                                                                                                    Key .ID_CA_INDICADOR = x.ID_CA_INDICADOR, _
                                                                                                                                                                    Key .DS_CA_INDICADOR = x.DS_CA_INDICADOR}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                                                .ID_CA_INDICADOR = y.Min(Function(group) group.ID_CA_INDICADOR), _
                                                                                                                                                                                                                                                                .DS_CA_INDICADOR = y.Min(Function(group) group.DS_CA_INDICADOR), _
                                                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList




        Dim varDadosMoagemPorMoendaGeralAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaGeral.OrderBy(Function(x) x.DIA.Date).ToList)
        Dim varDadosMoagemPorMoendaAAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaA.OrderBy(Function(x) x.DIA.Date).ToList)
        Dim varDadosMoagemPorMoendaBAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaB.OrderBy(Function(x) x.DIA.Date).ToList)

        Dim varDadosMoagemPorMoendaGeralPorDia = GetIndustriaMoagemPorMoendaPorDia(varDadosMoagemPorMoendaGeral)
        Dim varDadosMoagemPorMoendaAPorDia = GetIndustriaMoagemPorMoendaPorDia(varDadosMoagemPorMoendaA)
        Dim varDadosMoagemPorMoendaBPorDia = GetIndustriaMoagemPorMoendaPorDia(varDadosMoagemPorMoendaB)

        Dim varDiaAtual = parDadosMoagem.OrderByDescending(Function(x) x.DIA).ThenByDescending(Function(x) x.HORA).FirstOrDefault().DIA.Date

        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorSemana With {.moenda = "AB", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaGeral.OrderBy(Function(x) x.DIA.Date).ToList, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaGeralAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaGeralPorDia,
                                                             .oGridMoagemProjecao = Nothing, 'GetIndustriaMoagemProjecao(),
                                                             .DiaAtual = varDiaAtual})
        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorSemana With {.moenda = "A", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaA.OrderBy(Function(x) x.DIA.Date).ToList, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaAAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaAPorDia,
                                                             .oGridMoagemProjecao = Nothing, 'GetIndustriaMoagemProjecao(),
                                                             .DiaAtual = varDiaAtual})
        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorSemana With {.moenda = "B", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaB.OrderBy(Function(x) x.DIA.Date).ToList, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaBAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaBPorDia,
                                                             .oGridMoagemProjecao = Nothing, 'GetIndustriaMoagemProjecao(),
                                                             .DiaAtual = varDiaAtual})

        GetIndustriaMoagemPorMoendaAgrupadoPorSemana = varMoendas
    End Function

    Private Function GetIndustriaMoagemPorMoendaAgrupadoPorMes(parDadosMoagem As List(Of S5TIndustriaMoagem)) As List(Of S5TIndustriaMoagemPorMoendaPorMes)
        Dim varMoendas = New List(Of S5TIndustriaMoagemPorMoendaPorMes) 

        Dim varDadosMoagemPorMoendaGeral = parDadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                .SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                                .semanaPeriodo = New S5TIndustriaMoagemSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosMoagemPorMoendaA = parDadosMoagem.FindAll(Function(x) x.MOENDA = "A").FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                                                .SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                                                                .semanaPeriodo = New S5TIndustriaMoagemSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosMoagemPorMoendaB = parDadosMoagem.FindAll(Function(x) x.MOENDA = "B").FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaMoagem With {.DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                                                .SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                                                                                                                                .semanaPeriodo = New S5TIndustriaMoagemSemanaDiaInicioFim With {.diaInicio = y.Min(Function(semanaGroup) semanaGroup.DIA.Date), .diaFim = y.Max(Function(semanaGroup) semanaGroup.DIA.Date)}, _
                                                                                                                                                                                                                                                                .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                                                .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList




        Dim varDadosMoagemPorMoendaGeralAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaGeral.OrderBy(Function(x) x.SEMANA).ToList)
        Dim varDadosMoagemPorMoendaAAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaA.OrderBy(Function(x) x.SEMANA).ToList)
        Dim varDadosMoagemPorMoendaBAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaB.OrderBy(Function(x) x.SEMANA).ToList)

        Dim varDadosMoagemPorMoendaGeralPorSemana = GetIndustriaMoagemPorMoendaPorSemana(varDadosMoagemPorMoendaGeral)
        Dim varDadosMoagemPorMoendaAPorSemana = GetIndustriaMoagemPorMoendaPorSemana(varDadosMoagemPorMoendaA)
        Dim varDadosMoagemPorMoendaBPorSemana = GetIndustriaMoagemPorMoendaPorSemana(varDadosMoagemPorMoendaB)

        Dim varSemanaAtual = parDadosMoagem.OrderByDescending(Function(x) x.SEMANA).FirstOrDefault().SEMANA

        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorMes With {.moenda = "AB", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaGeral.OrderBy(Function(x) x.SEMANA).ToList, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaGeralAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaGeralPorSemana,
                                                             .oGridMoagemProjecao = Nothing, 'GetIndustriaMoagemProjecao(),
                                                             .SemanaAtual = varSemanaAtual})
        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorMes With {.moenda = "A", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaA.OrderBy(Function(x) x.SEMANA).ToList, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaAAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaAPorSemana,
                                                             .oGridMoagemProjecao = Nothing, 'GetIndustriaMoagemProjecao(),
                                                             .SemanaAtual = varSemanaAtual})
        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorMes With {.moenda = "B", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaB.OrderBy(Function(x) x.SEMANA).ToList, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaBAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaBPorSemana,
                                                             .oGridMoagemProjecao = Nothing, 'GetIndustriaMoagemProjecao(),
                                                             .SemanaAtual = varSemanaAtual})

        GetIndustriaMoagemPorMoendaAgrupadoPorMes = varMoendas
    End Function

    Private Function GetIndustriaMoagemPorMoendaAgrupadoPorSafra(parDadosMoagem As List(Of S5TIndustriaMoagem)) As List(Of S5TIndustriaMoagemPorMoendaPorSafra)
        Dim varMoendas = New List(Of S5TIndustriaMoagemPorMoendaPorSafra) 

        Dim varDadosMoagemPorMoendaGeral = parDadosMoagem.FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaMoagem With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                        .DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                        .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                        .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosMoagemPorMoendaA = parDadosMoagem.FindAll(Function(x) x.MOENDA = "A").FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaMoagem With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                                                        .DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                        .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                        .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varDadosMoagemPorMoendaB = parDadosMoagem.FindAll(Function(x) x.MOENDA = "B").FindAll(Function(x) x.ID_CA_INDICADOR = 46).GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaMoagem With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                                                                                                        .DIA = y.Min(Function(group) group.DIA.Date), _
                                                                                                                                                                                                                                        .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN_NEFETIVA), 2), _
                                                                                                                                                                                                                                        .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList




        Dim varDadosMoagemPorMoendaGeralAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaGeral.OrderBy(Function(x) x.MES).ToList)
        Dim varDadosMoagemPorMoendaAAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaA.OrderBy(Function(x) x.MES).ToList)
        Dim varDadosMoagemPorMoendaBAcumulado = GetIndustriaMoagemAcumulado(varDadosMoagemPorMoendaB.OrderBy(Function(x) x.MES).ToList)

        Dim varDadosMoagemPorMoendaGeralPorMes = GetIndustriaMoagemPorMoendaPorMes(varDadosMoagemPorMoendaGeral)
        Dim varDadosMoagemPorMoendaAPorMes = GetIndustriaMoagemPorMoendaPorMes(varDadosMoagemPorMoendaA)
        Dim varDadosMoagemPorMoendaBPorMes = GetIndustriaMoagemPorMoendaPorMes(varDadosMoagemPorMoendaB)

        Dim varMesAtual = parDadosMoagem.OrderByDescending(Function(x) x.MES).FirstOrDefault().MES

        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorSafra With {.moenda = "AB", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaGeral.OrderBy(Function(x) x.MES).ToList, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaGeralAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaGeralPorMes,
                                                             .oGridMoagemProjecao = Nothing, 'GetIndustriaMoagemProjecao(),
                                                             .MesAtual = varMesAtual})
        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorSafra With {.moenda = "A", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaA.OrderBy(Function(x) x.MES).ToList, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaAAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaAPorMes,
                                                             .oGridMoagemProjecao = Nothing, 'GetIndustriaMoagemProjecao(),
                                                             .MesAtual = varMesAtual})
        varMoendas.Add(New S5TIndustriaMoagemPorMoendaPorSafra With {.moenda = "B", 
                                                             .oGraficoMoagem = varDadosMoagemPorMoendaB.OrderBy(Function(x) x.MES).ToList, 
                                                             .oGraficoMoagemAcumulado = varDadosMoagemPorMoendaBAcumulado, 
                                                             .oGridMoagem = varDadosMoagemPorMoendaBPorMes,
                                                             .oGridMoagemProjecao = Nothing, 'GetIndustriaMoagemProjecao(),
                                                             .MesAtual = varMesAtual})

        GetIndustriaMoagemPorMoendaAgrupadoPorSafra = varMoendas
    End Function


    Private Function GetIndustriaMoagemAcumulado(parIndustriaMoagem As List(Of S5TIndustriaMoagem)) As List(Of S5TIndustriaMoagem)
        Dim parIndustriaMoagemOrdenado = parIndustriaMoagem.OrderBy(Function(x) x.DIA).OrderBy(Function(x) x.HORA)

        Dim varIndustriaMoagemAcumulado = New List(Of S5TIndustriaMoagem)

        Dim varPlanejadoAcumulado As Double = 0
        Dim varRealizadoAcumulado As Double = 0

        For Each objIndustriaMoagem In parIndustriaMoagemOrdenado
            varPlanejadoAcumulado += objIndustriaMoagem.VALOR_PLAN
            varRealizadoAcumulado += objIndustriaMoagem.VALOR_REAL

            varIndustriaMoagemAcumulado.Add(New S5TIndustriaMoagem() With {
                                                .ID_NEGOCIOS = objIndustriaMoagem.ID_NEGOCIOS,
                                                .SAFRA = objIndustriaMoagem.SAFRA,
                                                .MES = objIndustriaMoagem.MES,
                                                .SEMANA = objIndustriaMoagem.SEMANA,
                                                .semanaPeriodo = objIndustriaMoagem.semanaPeriodo,
                                                .DIA = objIndustriaMoagem.DIA,
                                                .HORA = objIndustriaMoagem.HORA,
                                                .ID_CA_INDICADOR = objIndustriaMoagem.ID_CA_INDICADOR,
                                                .DS_CA_INDICADOR = objIndustriaMoagem.DS_CA_INDICADOR,
                                                .MOENDA = objIndustriaMoagem.MOENDA,
                                                .VALOR_PLAN = Math.Round(varPlanejadoAcumulado,0),
                                                .VALOR_REAL = Math.Round(varRealizadoAcumulado,0)
                                            })
        Next

        GetIndustriaMoagemAcumulado = varIndustriaMoagemAcumulado
    End Function

    Private Function GetIndustriaMoagemPorMoendaPorHora(parDadosMoagemPorDia As List(Of S5TIndustriaMoagem)) As List(Of S5TIndustriaMoagemPorHora)
        Dim varIndustriaMoagemPorHora = New List(Of S5TIndustriaMoagemPorHora)

        Dim varObjH00 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "00")
        Dim varObjH01 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "01")
        Dim varObjH02 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "02")
        Dim varObjH03 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "03")
        Dim varObjH04 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "04")
        Dim varObjH05 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "05")
        Dim varObjH06 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "06")
        Dim varObjH07 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "07")
        Dim varObjH08 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "08")
        Dim varObjH09 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "09")
        Dim varObjH10 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "10")
        Dim varObjH11 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "11")
        Dim varObjH12 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "12")
        Dim varObjH13 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "13")
        Dim varObjH14 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "14")
        Dim varObjH15 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "15")
        Dim varObjH16 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "16")
        Dim varObjH17 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "17")
        Dim varObjH18 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "18")
        Dim varObjH19 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "19")
        Dim varObjH20 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "20")
        Dim varObjH21 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "21")
        Dim varObjH22 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "22")
        Dim varObjH23 = parDadosMoagemPorDia.FirstOrDefault(Function(x) x.HORA = "23")

        Dim obj01PlanejadoMoagemPorHora = New S5TIndustriaMoagemPorHora With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Horário (ton/h)",
                                                                        .H00 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH00),
                                                                        .H01 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH01),
                                                                        .H02 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH02),
                                                                        .H03 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH03),
                                                                        .H04 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH04),
                                                                        .H05 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH05),
                                                                        .H06 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH06),
                                                                        .H07 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH07),
                                                                        .H08 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH08),
                                                                        .H09 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH09),
                                                                        .H10 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH10),
                                                                        .H11 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH11),
                                                                        .H12 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH12),
                                                                        .H13 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH13),
                                                                        .H14 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH14),
                                                                        .H15 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH15),
                                                                        .H16 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH16),
                                                                        .H17 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH17),
                                                                        .H18 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH18),
                                                                        .H19 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH19),
                                                                        .H20 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH20),
                                                                        .H21 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH21),
                                                                        .H22 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH22),
                                                                        .H23 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH23)
                                                                        }

        Dim obj02PlanejadoAcumuladoMoagemPorHora = New S5TIndustriaMoagemPorHora With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (ton/dia)",
                                                                        .H00 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 0),
                                                                        .H01 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 1),
                                                                        .H02 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 2),
                                                                        .H03 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 3),
                                                                        .H04 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 4),
                                                                        .H05 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 5),
                                                                        .H06 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 6),
                                                                        .H07 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 7),
                                                                        .H08 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 8),
                                                                        .H09 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 9),
                                                                        .H10 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 10),
                                                                        .H11 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 11),
                                                                        .H12 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 12),
                                                                        .H13 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 13),
                                                                        .H14 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 14),
                                                                        .H15 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 15),
                                                                        .H16 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 16),
                                                                        .H17 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 17),
                                                                        .H18 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 18),
                                                                        .H19 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 19),
                                                                        .H20 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 20),
                                                                        .H21 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 21),
                                                                        .H22 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 22),
                                                                        .H23 = GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 23)
                                                                        }


        Dim obj03RealizadoMoagemPorHora = New S5TIndustriaMoagemPorHora With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Diário (ton/h)",
                                                                        .H00 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH00),
                                                                        .H01 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH01),
                                                                        .H02 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH02),
                                                                        .H03 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH03),
                                                                        .H04 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH04),
                                                                        .H05 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH05),
                                                                        .H06 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH06),
                                                                        .H07 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH07),
                                                                        .H08 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH08),
                                                                        .H09 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH09),
                                                                        .H10 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH10),
                                                                        .H11 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH11),
                                                                        .H12 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH12),
                                                                        .H13 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH13),
                                                                        .H14 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH14),
                                                                        .H15 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH15),
                                                                        .H16 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH16),
                                                                        .H17 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH17),
                                                                        .H18 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH18),
                                                                        .H19 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH19),
                                                                        .H20 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH20),
                                                                        .H21 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH21),
                                                                        .H22 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH22),
                                                                        .H23 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH23)
                                                                        }

        Dim obj04RealizadoAcumuladoMoagemPorHora = New S5TIndustriaMoagemPorHora With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (ton/dia)",
                                                                        .H00 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 0),
                                                                        .H01 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 1),
                                                                        .H02 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 2),
                                                                        .H03 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 3),
                                                                        .H04 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 4),
                                                                        .H05 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 5),
                                                                        .H06 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 6),
                                                                        .H07 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 7),
                                                                        .H08 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 8),
                                                                        .H09 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 9),
                                                                        .H10 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 10),
                                                                        .H11 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 11),
                                                                        .H12 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 12),
                                                                        .H13 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 13),
                                                                        .H14 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 14),
                                                                        .H15 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 15),
                                                                        .H16 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 16),
                                                                        .H17 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 17),
                                                                        .H18 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 18),
                                                                        .H19 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 19),
                                                                        .H20 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 20),
                                                                        .H21 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 21),
                                                                        .H22 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 22),
                                                                        .H23 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 23)
                                                                        }

        Dim obj05RealizadoMenosPlanejadoMoagemPorHora = New S5TIndustriaMoagemPorHora With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Diário (ton)",
                                                                                        .H00 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH00) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH00),
                                                                                        .H01 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH01) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH01),
                                                                                        .H02 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH02) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH02),
                                                                                        .H03 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH03) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH03),
                                                                                        .H04 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH04) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH04),
                                                                                        .H05 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH05) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH05),
                                                                                        .H06 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH06) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH06),
                                                                                        .H07 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH07) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH07),
                                                                                        .H08 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH08) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH08),
                                                                                        .H09 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH09) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH09),
                                                                                        .H10 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH10) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH10),
                                                                                        .H11 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH11) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH11),
                                                                                        .H12 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH12) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH12),
                                                                                        .H13 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH13) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH13),
                                                                                        .H14 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH14) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH14),
                                                                                        .H15 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH15) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH15),
                                                                                        .H16 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH16) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH16),
                                                                                        .H17 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH17) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH17),
                                                                                        .H18 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH18) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH18),
                                                                                        .H19 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH19) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH19),
                                                                                        .H20 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH20) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH20),
                                                                                        .H21 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH21) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH21),
                                                                                        .H22 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH22) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH22),
                                                                                        .H23 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjH23) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjH23)
            }

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoMoagemPorHora = New S5TIndustriaMoagemPorHora With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (ton)",
                                                                                .H00 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 0) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 0),
                                                                                .H01 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 1) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 1),
                                                                                .H02 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 2) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 2),
                                                                                .H03 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 3) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 3),
                                                                                .H04 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 4) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 4),
                                                                                .H05 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 5) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 5),
                                                                                .H06 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 6) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 6),
                                                                                .H07 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 7) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 7),
                                                                                .H08 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 8) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 8),
                                                                                .H09 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 9) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 9),
                                                                                .H10 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 10) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 10),
                                                                                .H11 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 11) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 11),
                                                                                .H12 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 12) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 12),
                                                                                .H13 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 13) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 13),
                                                                                .H14 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 14) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 14),
                                                                                .H15 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 15) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 15),
                                                                                .H16 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 16) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 16),
                                                                                .H17 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 17) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 17),
                                                                                .H18 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 18) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 18),
                                                                                .H19 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 19) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 19),
                                                                                .H20 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 20) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 20),
                                                                                .H21 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 21) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 21),
                                                                                .H22 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 22) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 22),
                                                                                .H23 = GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 23) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 23)
        }

        Dim obj07DesvioPercentual = New S5TIndustriaMoagemPorHora With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .H00 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 0) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 0) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 0)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 0), 4)),
                                                        .H01 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 1) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 1) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 1)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 1), 4)),
                                                        .H02 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 2) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 2) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 2)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 2), 4)),
                                                        .H03 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 3) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 3) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 3)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 3), 4)),
                                                        .H04 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 4) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 4) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 4)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 4), 4)),
                                                        .H05 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 5) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 5) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 5)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 5), 4)),
                                                        .H06 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 6) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 6) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 6)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 6), 4)),
                                                        .H07 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 7) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 7) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 7)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 7), 4)),
                                                        .H08 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 8) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 8) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 8)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 8), 4)),
                                                        .H09 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 9) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 9) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 9)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 9), 4)),
                                                        .H10 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 10) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 10) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 10)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 10), 4)),
                                                        .H11 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 11) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 11) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 11)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 11), 4)),
                                                        .H12 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 12) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 12) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 12)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 12), 4)),
                                                        .H13 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 13) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 13) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 13)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 13), 4)),
                                                        .H14 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 14) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 14) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 14)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 14), 4)),
                                                        .H15 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 15) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 15) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 15)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 15), 4)),
                                                        .H16 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 16) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 16) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 16)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 16), 4)),
                                                        .H17 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 17) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 17) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 17)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 17), 4)),
                                                        .H18 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 18) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 18) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 18)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 18), 4)),
                                                        .H19 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 19) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 19) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 19)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 19), 4)),
                                                        .H20 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 20) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 20) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 20)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 20), 4)),
                                                        .H21 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 21) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 21) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 21)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 21), 4)),
                                                        .H22 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 22) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 22) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 22)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 22), 4)),
                                                        .H23 = IIf(GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 23) = 0, 0, Math.Round((GetIndustriaMoagemPorHoraAcumulado(obj03RealizadoMoagemPorHora, 23) - GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 23)) / GetIndustriaMoagemPorHoraAcumulado(obj01PlanejadoMoagemPorHora, 23), 4))
            }

        Dim objCoeficienteAngular = New S5TIndustriaMoagemPorHora With {
                                                       .Diario = "Desvio",
                                                       .Hora = "Coef.Angular",
                                                       .H00 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 0),
                                                       .H01 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 1),
                                                       .H02 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 2),
                                                       .H03 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 3),
                                                       .H04 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 4),
                                                       .H05 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 5),
                                                       .H06 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 6),
                                                       .H07 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 7),
                                                       .H08 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 8),
                                                       .H09 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 9),
                                                       .H10 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 10),
                                                       .H11 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 11),
                                                       .H12 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 12),
                                                       .H13 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 13),
                                                       .H14 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 14),
                                                       .H15 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 15),
                                                       .H16 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 16),
                                                       .H17 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 17),
                                                       .H18 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 18),
                                                       .H19 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 19),
                                                       .H20 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 20),
                                                       .H21 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 21),
                                                       .H22 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 22),
                                                       .H23 = GetIndustraMoagemPorHoraCoeficienteAngular(obj04RealizadoAcumuladoMoagemPorHora, 23)
        }

        varIndustriaMoagemPorHora.Add(obj01PlanejadoMoagemPorHora)
        varIndustriaMoagemPorHora.Add(obj02PlanejadoAcumuladoMoagemPorHora)

        varIndustriaMoagemPorHora.Add(obj03RealizadoMoagemPorHora)
        varIndustriaMoagemPorHora.Add(obj04RealizadoAcumuladoMoagemPorHora)

        varIndustriaMoagemPorHora.Add(obj05RealizadoMenosPlanejadoMoagemPorHora)
        varIndustriaMoagemPorHora.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoMoagemPorHora)
        varIndustriaMoagemPorHora.Add(obj07DesvioPercentual)
        varIndustriaMoagemPorHora.Add(objCoeficienteAngular)

        GetIndustriaMoagemPorMoendaPorHora = varIndustriaMoagemPorHora
    End Function

    Private Function GetIndustriaMoagemPorMoendaPorDia(parDadosMoagemPorDia As List(Of S5TIndustriaMoagem)) As List(Of S5TIndustriaMoagemPorDia)
        Dim varIndustriaMoagemPorDia = New List(Of S5TIndustriaMoagemPorDia)

        Dim dadosMoagemPorDia = parDadosMoagemPorDia.OrderBy(Function(x) x.DIA.Date)

        Dim varObjDia01 = Iif(dadosMoagemPorDia.Count() > 0, dadosMoagemPorDia(0), Nothing)
        Dim varObjDia02 = Iif(dadosMoagemPorDia.Count() > 1, dadosMoagemPorDia(1), Nothing)
        Dim varObjDia03 = Iif(dadosMoagemPorDia.Count() > 2, dadosMoagemPorDia(2), Nothing)
        Dim varObjDia04 = Iif(dadosMoagemPorDia.Count() > 3, dadosMoagemPorDia(3), Nothing)
        Dim varObjDia05 = Iif(dadosMoagemPorDia.Count() > 4, dadosMoagemPorDia(4), Nothing)
        Dim varObjDia06 = Iif(dadosMoagemPorDia.Count() > 5, dadosMoagemPorDia(5), Nothing)
        Dim varObjDia07 = Iif(dadosMoagemPorDia.Count() > 6, dadosMoagemPorDia(6), Nothing)

        Dim obj01PlanejadoMoagemPorDia = New S5TIndustriaMoagemPorDia With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Diário (ton/dia)",
                                                                        .DIA1 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia01),
                                                                        .DIA2 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia02),
                                                                        .DIA3 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia03),
                                                                        .DIA4 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia04),
                                                                        .DIA5 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia05),
                                                                        .DIA6 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia06),
                                                                        .DIA7 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia07)}

        Dim obj02PlanejadoAcumuladoMoagemPorDia = New S5TIndustriaMoagemPorDia With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (ton/semana)",
                                                                        .DIA1 = GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 1),
                                                                        .DIA2 = GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 2),
                                                                        .DIA3 = GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 3),
                                                                        .DIA4 = GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 4),
                                                                        .DIA5 = GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 5),
                                                                        .DIA6 = GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 6),
                                                                        .DIA7 = GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 7)}

        Dim obj03RealizadoMoagemPorDia = New S5TIndustriaMoagemPorDia With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Diário (ton/dia)",
                                                                        .DIA1 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia01),
                                                                        .DIA2 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia02),
                                                                        .DIA3 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia03),
                                                                        .DIA4 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia04),
                                                                        .DIA5 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia05),
                                                                        .DIA6 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia06),
                                                                        .DIA7 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia07)}

        Dim obj04RealizadoAcumuladoMoagemPorDia = New S5TIndustriaMoagemPorDia With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (ton/semana)",
                                                                        .DIA1 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 1),
                                                                        .DIA2 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 2),
                                                                        .DIA3 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 3),
                                                                        .DIA4 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 4),
                                                                        .DIA5 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 5),
                                                                        .DIA6 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 6),
                                                                        .DIA7 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 7)}

        Dim obj05RealizadoMenosPlanejadoMoagemPorDia = New S5TIndustriaMoagemPorDia With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Diário (ton)",
                                                                                        .DIA1 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia01) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia01),
                                                                                        .DIA2 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia02) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia02),
                                                                                        .DIA3 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia03) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia03),
                                                                                        .DIA4 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia04) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia04),
                                                                                        .DIA5 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia05) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia05),
                                                                                        .DIA6 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia06) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia06),
                                                                                        .DIA7 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjDia07) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjDia07)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoMoagemPorDia = New S5TIndustriaMoagemPorDia With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (ton)",
                                                                                .DIA1 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 1) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 1),
                                                                                .DIA2 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 2) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 2),
                                                                                .DIA3 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 3) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 3),
                                                                                .DIA4 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 4) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 4),
                                                                                .DIA5 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 5) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 5),
                                                                                .DIA6 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 6) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 6),
                                                                                .DIA7 = GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 7) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 7)}

        Dim obj07DesvioPercentual = New S5TIndustriaMoagemPorDia With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .DIA1 = IIf(GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 1) = 0, 0, Math.Round((GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 1) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 1)) / GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 1), 4)),
                                                        .DIA2 = IIf(GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 2) = 0, 0, Math.Round((GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 2) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 2)) / GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 2), 4)),
                                                        .DIA3 = IIf(GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 3) = 0, 0, Math.Round((GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 3) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 3)) / GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 3), 4)),
                                                        .DIA4 = IIf(GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 4) = 0, 0, Math.Round((GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 4) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 4)) / GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 4), 4)),
                                                        .DIA5 = IIf(GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 5) = 0, 0, Math.Round((GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 5) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 5)) / GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 5), 4)),
                                                        .DIA6 = IIf(GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 6) = 0, 0, Math.Round((GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 6) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 6)) / GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 6), 4)),
                                                        .DIA7 = IIf(GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 7) = 0, 0, Math.Round((GetIndustriaMoagemPorDiaAcumulado(obj03RealizadoMoagemPorDia, 7) - GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 7)) / GetIndustriaMoagemPorDiaAcumulado(obj01PlanejadoMoagemPorDia, 7), 4))}

        varIndustriaMoagemPorDia.Add(obj01PlanejadoMoagemPorDia)
        varIndustriaMoagemPorDia.Add(obj02PlanejadoAcumuladoMoagemPorDia)

        varIndustriaMoagemPorDia.Add(obj03RealizadoMoagemPorDia)
        varIndustriaMoagemPorDia.Add(obj04RealizadoAcumuladoMoagemPorDia)

        varIndustriaMoagemPorDia.Add(obj05RealizadoMenosPlanejadoMoagemPorDia)
        varIndustriaMoagemPorDia.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoMoagemPorDia)
        varIndustriaMoagemPorDia.Add(obj07DesvioPercentual)

        GetIndustriaMoagemPorMoendaPorDia = varIndustriaMoagemPorDia
    End Function

    Private Function GetIndustriaMoagemPorMoendaPorSemana(parDadosMoagem As List(Of S5TIndustriaMoagem)) As List(Of S5TIndustriaMoagemPorSemana)
        Dim varIndustriaMoagemPorSemana = New List(Of S5TIndustriaMoagemPorSemana)

        Dim dadosMoagemPorSemana = parDadosMoagem.GroupBy(Function(x) New With {Key .SEMANA = x.SEMANA}).Select(Function (y) New S5TIndustriaMoagem With {.SEMANA = y.Min(Function(group) group.SEMANA), _
                                                                                                                                                          .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                          .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).OrderBy(Function(x) x.SEMANA).ToList()


        Dim varObjSemana1 As S5TIndustriaMoagem = Nothing
        Dim varObjSemana2 As S5TIndustriaMoagem = Nothing
        Dim varObjSemana3 As S5TIndustriaMoagem = Nothing
        Dim varObjSemana4 As S5TIndustriaMoagem = Nothing
        Dim varObjSemana5 As S5TIndustriaMoagem = Nothing
        Dim varObjSemana6 As S5TIndustriaMoagem = Nothing

        If dadosMoagemPorSemana.Count() > 0 Then varObjSemana1 = dadosMoagemPorSemana(0)
        If dadosMoagemPorSemana.Count() > 1 Then varObjSemana2 = dadosMoagemPorSemana(1)
        If dadosMoagemPorSemana.Count() > 2 Then varObjSemana3 = dadosMoagemPorSemana(2)
        If dadosMoagemPorSemana.Count() > 3 Then varObjSemana4 = dadosMoagemPorSemana(3)
        If dadosMoagemPorSemana.Count() > 4 Then varObjSemana5 = dadosMoagemPorSemana(4)
        If dadosMoagemPorSemana.Count() > 5 Then varObjSemana6 = dadosMoagemPorSemana(5)

        Dim obj01PlanejadoMoagemPorSemana = New S5TIndustriaMoagemPorSemana With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Semanal (ton/semana)",
                                                                        .SEMANA1 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana1),
                                                                        .SEMANA2 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana2),
                                                                        .SEMANA3 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana3),
                                                                        .SEMANA4 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana4),
                                                                        .SEMANA5 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana5),
                                                                        .SEMANA6 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana6)}

        Dim obj02PlanejadoAcumuladoMoagemPorSemana = New S5TIndustriaMoagemPorSemana With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (ton/mês)",
                                                                        .SEMANA1 = GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 1),
                                                                        .SEMANA2 = GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 2),
                                                                        .SEMANA3 = GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 3),
                                                                        .SEMANA4 = GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 4),
                                                                        .SEMANA5 = GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 5),
                                                                        .SEMANA6 = GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 6)}

        Dim obj03RealizadoMoagemPorSemana = New S5TIndustriaMoagemPorSemana With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Semanal (ton/semana)",
                                                                        .SEMANA1 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana1),
                                                                        .SEMANA2 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana2),
                                                                        .SEMANA3 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana3),
                                                                        .SEMANA4 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana4),
                                                                        .SEMANA5 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana5),
                                                                        .SEMANA6 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana6)}

        Dim obj04RealizadoAcumuladoMoagemPorSemana = New S5TIndustriaMoagemPorSemana With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (ton/mês)",
                                                                        .SEMANA1 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 1),
                                                                        .SEMANA2 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 2),
                                                                        .SEMANA3 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 3),
                                                                        .SEMANA4 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 4),
                                                                        .SEMANA5 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 5),
                                                                        .SEMANA6 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 6)}

        Dim obj05RealizadoMenosPlanejadoMoagemPorSemana = New S5TIndustriaMoagemPorSemana With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Semanal (ton)",
                                                                                        .SEMANA1 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana1) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana1),
                                                                                        .SEMANA2 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana2) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana2),
                                                                                        .SEMANA3 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana3) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana3),
                                                                                        .SEMANA4 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana4) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana4),
                                                                                        .SEMANA5 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana5) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana5),
                                                                                        .SEMANA6 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjSemana6) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjSemana6)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoMoagemPorSemana = New S5TIndustriaMoagemPorSemana With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (ton)",
                                                                                .SEMANA1 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 1) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 1),
                                                                                .SEMANA2 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 2) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 2),
                                                                                .SEMANA3 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 3) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 3),
                                                                                .SEMANA4 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 4) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 4),
                                                                                .SEMANA5 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 5) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 5),
                                                                                .SEMANA6 = GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 6) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 6)}

        Dim obj07DesvioPercentual = New S5TIndustriaMoagemPorSemana With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .SEMANA1 = IIf(GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 1) = 0, 0, Math.Round((GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 1) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 1)) / GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 1), 4)),
                                                        .SEMANA2 = IIf(GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 2) = 0, 0, Math.Round((GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 2) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 2)) / GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 2), 4)),
                                                        .SEMANA3 = IIf(GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 3) = 0, 0, Math.Round((GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 3) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 3)) / GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 3), 4)),
                                                        .SEMANA4 = IIf(GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 4) = 0, 0, Math.Round((GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 4) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 4)) / GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 4), 4)),
                                                        .SEMANA5 = IIf(GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 5) = 0, 0, Math.Round((GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 5) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 5)) / GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 5), 4)),
                                                        .SEMANA6 = IIf(GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 6) = 0, 0, Math.Round((GetIndustriaMoagemPorSemanaAcumulado(obj03RealizadoMoagemPorSemana, 6) - GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 6)) / GetIndustriaMoagemPorSemanaAcumulado(obj01PlanejadoMoagemPorSemana, 6), 4))}

        varIndustriaMoagemPorSemana.Add(obj01PlanejadoMoagemPorSemana)
        varIndustriaMoagemPorSemana.Add(obj02PlanejadoAcumuladoMoagemPorSemana)

        varIndustriaMoagemPorSemana.Add(obj03RealizadoMoagemPorSemana)
        varIndustriaMoagemPorSemana.Add(obj04RealizadoAcumuladoMoagemPorSemana)

        varIndustriaMoagemPorSemana.Add(obj05RealizadoMenosPlanejadoMoagemPorSemana)
        varIndustriaMoagemPorSemana.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoMoagemPorSemana)
        varIndustriaMoagemPorSemana.Add(obj07DesvioPercentual)

        GetIndustriaMoagemPorMoendaPorSemana = varIndustriaMoagemPorSemana
    End Function

    Private Function GetIndustriaMoagemPorMoendaPorMes(parDadosMoagem As List(Of S5TIndustriaMoagem)) As List(Of S5TIndustriaMoagemPorMes)
        Dim varIndustriaMoagemPorMes = New List(Of S5TIndustriaMoagemPorMes)

        Dim dadosMoagemPorMes = parDadosMoagem.GroupBy(Function(x) New With {Key .MES = x.MES}).Select(Function (y) New S5TIndustriaMoagem With {.MES = y.Min(Function(group) group.MES), _
                                                                                                                                                 .VALOR_PLAN = Math.Round(y.Sum(Function(group) group.VALOR_PLAN), 2), _
                                                                                                                                                 .VALOR_REAL = Math.Round(y.Sum(Function(group) group.VALOR_REAL), 2)}).ToList

        Dim varObjMes01 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 1)
        Dim varObjMes02 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 2)
        Dim varObjMes03 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 3)
        Dim varObjMes04 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 4)
        Dim varObjMes05 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 5)
        Dim varObjMes06 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 6)
        Dim varObjMes07 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 7)
        Dim varObjMes08 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 8)
        Dim varObjMes09 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 9)
        Dim varObjMes10 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 10)
        Dim varObjMes11 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 11)
        Dim varObjMes12 = dadosMoagemPorMes.FirstOrDefault(Function(x) x.MES = 12)

        Dim obj01PlanejadoMoagemPorMes = New S5TIndustriaMoagemPorMes With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Mensal (ton/mês)",
                                                                        .MES1 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes01),
                                                                        .MES2 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes02),
                                                                        .MES3 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes03),
                                                                        .MES4 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes04),
                                                                        .MES5 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes05),
                                                                        .MES6 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes06),
                                                                        .MES7 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes07),
                                                                        .MES8 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes08),
                                                                        .MES9 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes09),
                                                                        .MES10 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes10),
                                                                        .MES11 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes11),
                                                                        .MES12 = GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes12)}

        Dim obj02PlanejadoAcumuladoMoagemPorMes = New S5TIndustriaMoagemPorMes With {
                                                                        .Diario = "Planejado",
                                                                        .Hora = "Acumulado (ton/safra)",
                                                                        .MES1 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 1),
                                                                        .MES2 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 2),
                                                                        .MES3 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 3),
                                                                        .MES4 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 4),
                                                                        .MES5 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 5),
                                                                        .MES6 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 6),
                                                                        .MES7 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 7),
                                                                        .MES8 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 8),
                                                                        .MES9 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 9),
                                                                        .MES10 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 10),
                                                                        .MES11 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 11),
                                                                        .MES12 = GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 12)}

        Dim obj03RealizadoMoagemPorMes = New S5TIndustriaMoagemPorMes With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Mensal (ton/mês)",
                                                                        .MES1 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes01),
                                                                        .MES2 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes02),
                                                                        .MES3 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes03),
                                                                        .MES4 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes04),
                                                                        .MES5 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes05),
                                                                        .MES6 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes06),
                                                                        .MES7 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes07),
                                                                        .MES8 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes08),
                                                                        .MES9 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes09),
                                                                        .MES10 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes10),
                                                                        .MES11 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes11),
                                                                        .MES12 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes12)}

        Dim obj04RealizadoAcumuladoMoagemPorMes = New S5TIndustriaMoagemPorMes With {
                                                                        .Diario = "Realizado",
                                                                        .Hora = "Acumulado (ton/safra)",
                                                                        .MES1 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 1),
                                                                        .MES2 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 2),
                                                                        .MES3 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 3),
                                                                        .MES4 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 4),
                                                                        .MES5 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 5),
                                                                        .MES6 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 6),
                                                                        .MES7 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 7),
                                                                        .MES8 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 8),
                                                                        .MES9 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 9),
                                                                        .MES10 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 10),
                                                                        .MES11 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 11),
                                                                        .MES12 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 12)}

        Dim obj05RealizadoMenosPlanejadoMoagemPorMes = New S5TIndustriaMoagemPorMes With {
                                                                                        .Diario = "Desvio",
                                                                                        .Hora = "Mensal (ton)",
                                                                                        .MES1 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes01) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes01),
                                                                                        .MES2 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes02) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes02),
                                                                                        .MES3 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes03) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes03),
                                                                                        .MES4 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes04) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes04),
                                                                                        .MES5 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes05) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes05),
                                                                                        .MES6 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes06) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes06),
                                                                                        .MES7 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes07) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes07),
                                                                                        .MES8 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes08) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes08),
                                                                                        .MES9 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes09) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes09),
                                                                                        .MES10 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes10) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes10),
                                                                                        .MES11 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes11) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes11),
                                                                                        .MES12 = GetInfoObjIndustriaMoagem(TipoCampo.ValorRealizado, varObjMes12) - GetInfoObjIndustriaMoagem(TipoCampo.ValorPlanejado, varObjMes12)}

        Dim obj06RealizadoAcumuladoMenosPlanejadoAcumuladoMoagemPorMes = New S5TIndustriaMoagemPorMes With {
                                                                                .Diario = "Desvio",
                                                                                .Hora = "Acumulado (ton)",
                                                                                .MES1 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 1) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 1),
                                                                                .MES2 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 2) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 2),
                                                                                .MES3 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 3) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 3),
                                                                                .MES4 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 4) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 4),
                                                                                .MES5 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 5) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 5),
                                                                                .MES6 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 6) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 6),
                                                                                .MES7 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 7) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 7),
                                                                                .MES8 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 8) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 8),
                                                                                .MES9 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 9) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 9),
                                                                                .MES10 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 10) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 10),
                                                                                .MES11 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 11) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 11),
                                                                                .MES12 = GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 12) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 12)}

        Dim obj07DesvioPercentual = New S5TIndustriaMoagemPorMes With {
                                                        .Diario = "Desvio",
                                                        .Hora = "%",
                                                        .MES1 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 1) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 1) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 1)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 1), 4)),
                                                        .MES2 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 2) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 2) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 2)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 2), 4)),
                                                        .MES3 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 3) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 3) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 3)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 3), 4)),
                                                        .MES4 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 4) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 4) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 4)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 4), 4)),
                                                        .MES5 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 5) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 5) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 5)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 5), 4)),
                                                        .MES6 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 6) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 6) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 6)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 6), 4)),
                                                        .MES7 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 7) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 7) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 7)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 7), 4)),
                                                        .MES8 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 8) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 8) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 8)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 8), 4)),
                                                        .MES9 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 9) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 9) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 9)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 9), 4)),
                                                        .MES10 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 10) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 10) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 10)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 10), 4)),
                                                        .MES11 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 11) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 11) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 11)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 11), 4)),
                                                        .MES12 = IIf(GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 12) = 0, 0, Math.Round((GetIndustriaMoagemPorMesAcumulado(obj03RealizadoMoagemPorMes, 12) - GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 12)) / GetIndustriaMoagemPorMesAcumulado(obj01PlanejadoMoagemPorMes, 12), 4))}

        varIndustriaMoagemPorMes.Add(obj01PlanejadoMoagemPorMes)
        varIndustriaMoagemPorMes.Add(obj02PlanejadoAcumuladoMoagemPorMes)

        varIndustriaMoagemPorMes.Add(obj03RealizadoMoagemPorMes)
        varIndustriaMoagemPorMes.Add(obj04RealizadoAcumuladoMoagemPorMes)

        varIndustriaMoagemPorMes.Add(obj05RealizadoMenosPlanejadoMoagemPorMes)
        varIndustriaMoagemPorMes.Add(obj06RealizadoAcumuladoMenosPlanejadoAcumuladoMoagemPorMes)
        varIndustriaMoagemPorMes.Add(obj07DesvioPercentual)

        GetIndustriaMoagemPorMoendaPorMes = varIndustriaMoagemPorMes
    End Function


    Private Function GetIndustriaMoagemPorHoraAcumulado(parIndustriaMoagemPorHora As S5TIndustriaMoagemPorHora, parHora As Integer) As Double
        Dim varValor = 0

        Select Case parHora
            Case 0
                varValor = parIndustriaMoagemPorHora.H00
            Case 1
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01
            Case 2
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02
            Case 3
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03
            Case 4
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04
            Case 5
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05
            Case 6
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06
            Case 7
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07
            Case 8
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08
            Case 9
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09
            Case 10
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10
            Case 11
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11
            Case 12
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12
            Case 13
                varValor = parIndustriaMoagemPorHora.H00 + 
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13
            Case 14
                varValor = parIndustriaMoagemPorHora.H00 +
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13 +
                           parIndustriaMoagemPorHora.H14
            Case 15
                varValor = parIndustriaMoagemPorHora.H00 +
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13 +
                           parIndustriaMoagemPorHora.H14 +
                           parIndustriaMoagemPorHora.H15
            Case 16
                varValor = parIndustriaMoagemPorHora.H00 +
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13 +
                           parIndustriaMoagemPorHora.H14 +
                           parIndustriaMoagemPorHora.H15 +
                           parIndustriaMoagemPorHora.H16
            Case 17
                varValor = parIndustriaMoagemPorHora.H00 +
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13 +
                           parIndustriaMoagemPorHora.H14 +
                           parIndustriaMoagemPorHora.H15 +
                           parIndustriaMoagemPorHora.H16 +
                           parIndustriaMoagemPorHora.H17
            Case 18
                varValor = parIndustriaMoagemPorHora.H00 +
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13 +
                           parIndustriaMoagemPorHora.H14 +
                           parIndustriaMoagemPorHora.H15 +
                           parIndustriaMoagemPorHora.H16 +
                           parIndustriaMoagemPorHora.H17 +
                           parIndustriaMoagemPorHora.H18
            Case 19
                varValor = parIndustriaMoagemPorHora.H00 +
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13 +
                           parIndustriaMoagemPorHora.H14 +
                           parIndustriaMoagemPorHora.H15 +
                           parIndustriaMoagemPorHora.H16 +
                           parIndustriaMoagemPorHora.H17 +
                           parIndustriaMoagemPorHora.H18 +
                           parIndustriaMoagemPorHora.H19
            Case 20
                varValor = parIndustriaMoagemPorHora.H00 +
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13 +
                           parIndustriaMoagemPorHora.H14 +
                           parIndustriaMoagemPorHora.H15 +
                           parIndustriaMoagemPorHora.H16 +
                           parIndustriaMoagemPorHora.H17 +
                           parIndustriaMoagemPorHora.H18 +
                           parIndustriaMoagemPorHora.H19 +
                           parIndustriaMoagemPorHora.H20
            Case 21
                varValor = parIndustriaMoagemPorHora.H00 +
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13 +
                           parIndustriaMoagemPorHora.H14 +
                           parIndustriaMoagemPorHora.H15 +
                           parIndustriaMoagemPorHora.H16 +
                           parIndustriaMoagemPorHora.H17 +
                           parIndustriaMoagemPorHora.H18 +
                           parIndustriaMoagemPorHora.H19 +
                           parIndustriaMoagemPorHora.H20 +
                           parIndustriaMoagemPorHora.H21
            Case 22
                varValor = parIndustriaMoagemPorHora.H00 +
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13 +
                           parIndustriaMoagemPorHora.H14 +
                           parIndustriaMoagemPorHora.H15 +
                           parIndustriaMoagemPorHora.H16 +
                           parIndustriaMoagemPorHora.H17 +
                           parIndustriaMoagemPorHora.H18 +
                           parIndustriaMoagemPorHora.H19 +
                           parIndustriaMoagemPorHora.H20 +
                           parIndustriaMoagemPorHora.H21 +
                           parIndustriaMoagemPorHora.H22
            Case 23
                varValor = parIndustriaMoagemPorHora.H00 +
                           parIndustriaMoagemPorHora.H01 +
                           parIndustriaMoagemPorHora.H02 +
                           parIndustriaMoagemPorHora.H03 +
                           parIndustriaMoagemPorHora.H04 +
                           parIndustriaMoagemPorHora.H05 +
                           parIndustriaMoagemPorHora.H06 +
                           parIndustriaMoagemPorHora.H07 +
                           parIndustriaMoagemPorHora.H08 +
                           parIndustriaMoagemPorHora.H09 +
                           parIndustriaMoagemPorHora.H10 +
                           parIndustriaMoagemPorHora.H11 +
                           parIndustriaMoagemPorHora.H12 +
                           parIndustriaMoagemPorHora.H13 +
                           parIndustriaMoagemPorHora.H14 +
                           parIndustriaMoagemPorHora.H15 +
                           parIndustriaMoagemPorHora.H16 +
                           parIndustriaMoagemPorHora.H17 +
                           parIndustriaMoagemPorHora.H18 +
                           parIndustriaMoagemPorHora.H19 +
                           parIndustriaMoagemPorHora.H20 +
                           parIndustriaMoagemPorHora.H21 +
                           parIndustriaMoagemPorHora.H22 +
                           parIndustriaMoagemPorHora.H23
        End Select

        GetIndustriaMoagemPorHoraAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustraMoagemPorHoraCoeficienteAngular(parIndustriaMoagemPorHora As S5TIndustriaMoagemPorHora, parHora As Integer) As Double
        GetIndustraMoagemPorHoraCoeficienteAngular = 0

        Dim t as Type = parIndustriaMoagemPorHora.GetType()

        If parHora >= 1 Then
            Dim varNomePropriedadeHoraAtual = "H" & (parHora.ToString).PadLeft(2,"0")
            Dim varHoraAtualMenos1 = "H" & ((parHora - 1).ToString).PadLeft(2,"0")
            Dim fieldHoraAtual As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtual)
            Dim fieldHoraMenos1 As PropertyInfo = t.GetProperty(varHoraAtualMenos1)

            If fieldHoraAtual IsNot Nothing And fieldHoraMenos1 IsNot Nothing Then
                Dim varValorHoraAtual = fieldHoraAtual.GetValue(parIndustriaMoagemPorHora, Nothing)
                Dim varValorHoraAtualMenos1 = fieldHoraMenos1.GetValue(parIndustriaMoagemPorHora, Nothing)


                If varValorHoraAtual - varValorHoraAtualMenos1 <> 0 Then
                    GetIndustraMoagemPorHoraCoeficienteAngular = 1 / (varValorHoraAtual - varValorHoraAtualMenos1)
                End If
            End If
        End If
    End Function

    Private Function GetIndustriaMoagemPorDiaAcumulado(parIndustriaMoagemPorDia As S5TIndustriaMoagemPorDia, parDia As Integer) As Double
        Dim varValor = 0

        Select Case parDia
            Case 1
                varValor = parIndustriaMoagemPorDia.DIA1
            Case 2
                varValor = parIndustriaMoagemPorDia.DIA1 + 
                           parIndustriaMoagemPorDia.DIA2
            Case 3
                varValor = parIndustriaMoagemPorDia.DIA1 + 
                           parIndustriaMoagemPorDia.DIA2 +
                           parIndustriaMoagemPorDia.DIA3
            Case 4
                varValor = parIndustriaMoagemPorDia.DIA1 + 
                           parIndustriaMoagemPorDia.DIA2 +
                           parIndustriaMoagemPorDia.DIA3 +
                           parIndustriaMoagemPorDia.DIA4
            Case 5
                varValor = parIndustriaMoagemPorDia.DIA1 + 
                           parIndustriaMoagemPorDia.DIA2 +
                           parIndustriaMoagemPorDia.DIA3 +
                           parIndustriaMoagemPorDia.DIA4 +
                           parIndustriaMoagemPorDia.DIA5
            Case 6
                varValor = parIndustriaMoagemPorDia.DIA1 + 
                           parIndustriaMoagemPorDia.DIA2 +
                           parIndustriaMoagemPorDia.DIA3 +
                           parIndustriaMoagemPorDia.DIA4 +
                           parIndustriaMoagemPorDia.DIA5 +
                           parIndustriaMoagemPorDia.DIA6
            Case 7
                varValor = parIndustriaMoagemPorDia.DIA1 + 
                           parIndustriaMoagemPorDia.DIA2 +
                           parIndustriaMoagemPorDia.DIA3 +
                           parIndustriaMoagemPorDia.DIA4 +
                           parIndustriaMoagemPorDia.DIA5 +
                           parIndustriaMoagemPorDia.DIA6 +
                           parIndustriaMoagemPorDia.DIA7
        End Select

        GetIndustriaMoagemPorDiaAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustriaMoagemPorSemanaAcumulado(parIndustriaMoagemPorSemana As S5TIndustriaMoagemPorSemana, parSemana As Integer) As Double
        Dim varValor = 0

        Select Case parSemana
            Case 1
                varValor = parIndustriaMoagemPorSemana.SEMANA1
            Case 2
                varValor = parIndustriaMoagemPorSemana.SEMANA1 +
                           parIndustriaMoagemPorSemana.SEMANA2
            Case 3
                varValor = parIndustriaMoagemPorSemana.SEMANA1 + 
                           parIndustriaMoagemPorSemana.SEMANA2 +
                           parIndustriaMoagemPorSemana.SEMANA3
            Case 4
                varValor = parIndustriaMoagemPorSemana.SEMANA1 + 
                           parIndustriaMoagemPorSemana.SEMANA2 +
                           parIndustriaMoagemPorSemana.SEMANA3 +
                           parIndustriaMoagemPorSemana.SEMANA4
            Case 5
                varValor = parIndustriaMoagemPorSemana.SEMANA1 + 
                           parIndustriaMoagemPorSemana.SEMANA2 +
                           parIndustriaMoagemPorSemana.SEMANA3 +
                           parIndustriaMoagemPorSemana.SEMANA4 +
                           parIndustriaMoagemPorSemana.SEMANA5
            Case 6
                varValor = parIndustriaMoagemPorSemana.SEMANA1 + 
                           parIndustriaMoagemPorSemana.SEMANA2 +
                           parIndustriaMoagemPorSemana.SEMANA3 +
                           parIndustriaMoagemPorSemana.SEMANA4 +
                           parIndustriaMoagemPorSemana.SEMANA5 +
                           parIndustriaMoagemPorSemana.SEMANA6
        End Select

        GetIndustriaMoagemPorSemanaAcumulado = Math.Round(varValor,0)
    End Function

    Private Function GetIndustriaMoagemPorMesAcumulado(parIndustriaMoagemPorMes As S5TIndustriaMoagemPorMes, parMes As Integer) As Double
        Dim varValor = 0

        Select Case parMes
            Case 1
                varValor = parIndustriaMoagemPorMes.MES1
            Case 2
                varValor = parIndustriaMoagemPorMes.MES1 +
                           parIndustriaMoagemPorMes.MES2
            Case 3
                varValor = parIndustriaMoagemPorMes.MES1 + 
                           parIndustriaMoagemPorMes.MES2 +
                           parIndustriaMoagemPorMes.MES3
            Case 4
                varValor = parIndustriaMoagemPorMes.MES1 + 
                           parIndustriaMoagemPorMes.MES2 +
                           parIndustriaMoagemPorMes.MES3 +
                           parIndustriaMoagemPorMes.MES4
            Case 5
                varValor = parIndustriaMoagemPorMes.MES1 + 
                           parIndustriaMoagemPorMes.MES2 +
                           parIndustriaMoagemPorMes.MES3 +
                           parIndustriaMoagemPorMes.MES4 +
                           parIndustriaMoagemPorMes.MES5
            Case 6
                varValor = parIndustriaMoagemPorMes.MES1 + 
                           parIndustriaMoagemPorMes.MES2 +
                           parIndustriaMoagemPorMes.MES3 +
                           parIndustriaMoagemPorMes.MES4 +
                           parIndustriaMoagemPorMes.MES5 +
                           parIndustriaMoagemPorMes.MES6
            Case 7
                varValor = parIndustriaMoagemPorMes.MES1 + 
                           parIndustriaMoagemPorMes.MES2 +
                           parIndustriaMoagemPorMes.MES3 +
                           parIndustriaMoagemPorMes.MES4 +
                           parIndustriaMoagemPorMes.MES5 +
                           parIndustriaMoagemPorMes.MES6 +
                           parIndustriaMoagemPorMes.MES7
            Case 8
                varValor = parIndustriaMoagemPorMes.MES1 + 
                           parIndustriaMoagemPorMes.MES2 +
                           parIndustriaMoagemPorMes.MES3 +
                           parIndustriaMoagemPorMes.MES4 +
                           parIndustriaMoagemPorMes.MES5 +
                           parIndustriaMoagemPorMes.MES6 +
                           parIndustriaMoagemPorMes.MES7 +
                           parIndustriaMoagemPorMes.MES8
            Case 9
                varValor = parIndustriaMoagemPorMes.MES1 + 
                           parIndustriaMoagemPorMes.MES2 +
                           parIndustriaMoagemPorMes.MES3 +
                           parIndustriaMoagemPorMes.MES4 +
                           parIndustriaMoagemPorMes.MES5 +
                           parIndustriaMoagemPorMes.MES6 +
                           parIndustriaMoagemPorMes.MES7 +
                           parIndustriaMoagemPorMes.MES8 +
                           parIndustriaMoagemPorMes.MES9
            Case 10
                varValor = parIndustriaMoagemPorMes.MES1 + 
                           parIndustriaMoagemPorMes.MES2 +
                           parIndustriaMoagemPorMes.MES3 +
                           parIndustriaMoagemPorMes.MES4 +
                           parIndustriaMoagemPorMes.MES5 +
                           parIndustriaMoagemPorMes.MES6 +
                           parIndustriaMoagemPorMes.MES7 +
                           parIndustriaMoagemPorMes.MES8 +
                           parIndustriaMoagemPorMes.MES9 +
                           parIndustriaMoagemPorMes.MES10
            Case 11
                varValor = parIndustriaMoagemPorMes.MES1 + 
                           parIndustriaMoagemPorMes.MES2 +
                           parIndustriaMoagemPorMes.MES3 +
                           parIndustriaMoagemPorMes.MES4 +
                           parIndustriaMoagemPorMes.MES5 +
                           parIndustriaMoagemPorMes.MES6 +
                           parIndustriaMoagemPorMes.MES7 +
                           parIndustriaMoagemPorMes.MES8 +
                           parIndustriaMoagemPorMes.MES9 +
                           parIndustriaMoagemPorMes.MES10 +
                           parIndustriaMoagemPorMes.MES11
            Case 12
                varValor = parIndustriaMoagemPorMes.MES1 + 
                           parIndustriaMoagemPorMes.MES2 +
                           parIndustriaMoagemPorMes.MES3 +
                           parIndustriaMoagemPorMes.MES4 +
                           parIndustriaMoagemPorMes.MES5 +
                           parIndustriaMoagemPorMes.MES6 +
                           parIndustriaMoagemPorMes.MES7 +
                           parIndustriaMoagemPorMes.MES8 +
                           parIndustriaMoagemPorMes.MES9 +
                           parIndustriaMoagemPorMes.MES10 +
                           parIndustriaMoagemPorMes.MES11 +
                           parIndustriaMoagemPorMes.MES12
        End Select

        GetIndustriaMoagemPorMesAcumulado = Math.Round(varValor,0)
    End Function

    Enum TipoCampo
        ValorPlanejado
        ValorRealizado
    End Enum

    Private Function GetInfoObjIndustriaMoagem(parTipoCampo As TipoCampo, parObjIndustriaMoagem As S5TIndustriaMoagem) As Double
        GetInfoObjIndustriaMoagem = 0

        If parObjIndustriaMoagem IsNot Nothing Then
            If parTipoCampo = TipoCampo.ValorPlanejado Then
                GetInfoObjIndustriaMoagem = Math.Round(parObjIndustriaMoagem.VALOR_PLAN,0)
            ElseIf parTipoCampo = TipoCampo.ValorRealizado Then
                GetInfoObjIndustriaMoagem = Math.Round(parObjIndustriaMoagem.VALOR_REAL,0)
            End If
        End If
    End Function

    Private Function GetIndustriaMoagemProjecaoPorDia(parDadosMoagemPorMoendaGeralPorHora As List(Of S5TIndustriaMoagemPorHora), parHoraAtual As String) As List(Of S5TIndustriaMoagemProjecao)
        Dim varIndustriaMoagemProjecao = New List(Of S5TIndustriaMoagemProjecao)

        Dim objCoeficientesAngulares = parDadosMoagemPorMoendaGeralPorHora.FirstOrDefault(Function(x) x.Hora = "Coef.Angular")
        Dim objRealizadoAcumulado = parDadosMoagemPorMoendaGeralPorHora.FirstOrDefault(Function(x) x.Diario = "Realizado" And x.Hora = "Acumulado (ton/dia)")
        Dim objPlanejadoAcumulado = parDadosMoagemPorMoendaGeralPorHora.FirstOrDefault(Function(x) x.Diario = "Planejado" And x.Hora = "Acumulado (ton/dia)")

        objPlanejadoAcumulado = GetIndustriaMoagemAcumuladoPorDiaAjustadoMetas(objPlanejadoAcumulado, parHoraAtual)

        Dim t as Type = objCoeficientesAngulares.GetType()


        Dim varValorRealizadoAcumuladoHoraAtualMenos2 = 0

        If objRealizadoAcumulado IsNot Nothing And Convert.ToInt16(parHoraAtual) >= 2 Then
            Dim varNomePropriedadeHoraAtualMenos2 = "H" & (Convert.ToInt16(parHoraAtual) - 2).ToString.PadLeft(2,"0")
            Dim fieldHoraAtualMenos2 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtualMenos2)

            varValorRealizadoAcumuladoHoraAtualMenos2 = fieldHoraAtualMenos2.GetValue(objRealizadoAcumulado, Nothing)
        End If


        If objCoeficientesAngulares IsNot Nothing Then
            'Valores Projeção
            Dim varValorHoraAtualMenos1 As Double = 0
            If Convert.ToInt16(parHoraAtual) > 0 Then
                Dim varNomePropriedadeHoraAtualMenos1 = "H" & (Convert.ToInt16(parHoraAtual) - 1).ToString.PadLeft(2,"0")
                Dim fieldHoraAtualMenos1 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtualMenos1)
                varValorHoraAtualMenos1 = fieldHoraAtualMenos1.GetValue(objCoeficientesAngulares, Nothing)
            End If

            Dim varProjecaoHoraMais1 As Double = 0
            Dim varProjecaoHoraMais2 As Double = 0
            Dim varProjecaoHoraMais3 As Double = 0
            Dim varProjecaoHoraMais4 As Double = 0

            If varValorHoraAtualMenos1 <> 0 Then
                varProjecaoHoraMais1 = 2 / varValorHoraAtualMenos1 + varValorRealizadoAcumuladoHoraAtualMenos2
                varProjecaoHoraMais2 = 3 / varValorHoraAtualMenos1 + varValorRealizadoAcumuladoHoraAtualMenos2
                varProjecaoHoraMais3 = 4 / varValorHoraAtualMenos1 + varValorRealizadoAcumuladoHoraAtualMenos2
                varProjecaoHoraMais4 = 5 / varValorHoraAtualMenos1 + varValorRealizadoAcumuladoHoraAtualMenos2
            End If

            'Valores Meta
            Dim varNomePropriedadeHoraAtual = "H" & Convert.ToInt16(parHoraAtual).ToString.PadLeft(2, "0")
            Dim fieldHoraAtual As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtual)
            Dim varValorMetaHoraAtual As Double = fieldHoraAtual.GetValue(objPlanejadoAcumulado, Nothing)

            Dim varValorMetaHoraAtualMais1 As Double = 0
            If Convert.ToInt16(parHoraAtual) <= 22 Then
                Dim varNomePropriedadeHoraAtualMais1 = "H" & (Convert.ToInt16(parHoraAtual) + 1).ToString.PadLeft(2, "0")
                Dim fieldHoraAtualMais1 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtualMais1)
                varValorMetaHoraAtualMais1 = fieldHoraAtualMais1.GetValue(objPlanejadoAcumulado, Nothing)
            End If

            Dim varValorMetaHoraAtualMais2 As Double = 0
            If Convert.ToInt16(parHoraAtual) <= 21 Then
                Dim varNomePropriedadeHoraAtualMais2 = "H" & (Convert.ToInt16(parHoraAtual) + 2).ToString.PadLeft(2, "0")
                Dim fieldHoraAtualMais2 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtualMais2)
                varValorMetaHoraAtualMais2 = fieldHoraAtualMais2.GetValue(objPlanejadoAcumulado, Nothing)
            End If


            Dim varValorMetaHoraAtualMais3 As Double = 0
            If Convert.ToInt16(parHoraAtual) <= 20 Then
                Dim varNomePropriedadeHoraAtualMais3 = "H" & (Convert.ToInt16(parHoraAtual) + 3).ToString.PadLeft(2, "0")
                Dim fieldHoraAtualMais3 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtualMais3)
                varValorMetaHoraAtualMais3 = fieldHoraAtualMais3.GetValue(objPlanejadoAcumulado, Nothing)
            End If

            varIndustriaMoagemProjecao.Add(New S5TIndustriaMoagemProjecao() With {
                                              .ProjecaoHora = "+1",
                                              .Projecao = varProjecaoHoraMais1,
                                              .Meta = varValorMetaHoraAtual
                                              })

            varIndustriaMoagemProjecao.Add(New S5TIndustriaMoagemProjecao() With {
                                              .ProjecaoHora = "+2",
                                              .Projecao = varProjecaoHoraMais2,
                                              .Meta = varValorMetaHoraAtualMais1
                                              })

            varIndustriaMoagemProjecao.Add(New S5TIndustriaMoagemProjecao() With {
                                              .ProjecaoHora = "+3",
                                              .Projecao = varProjecaoHoraMais3,
                                              .Meta = varValorMetaHoraAtualMais2
                                              })

            varIndustriaMoagemProjecao.Add(New S5TIndustriaMoagemProjecao() With {
                                              .ProjecaoHora = "+4",
                                              .Projecao = varProjecaoHoraMais4,
                                              .Meta = varValorMetaHoraAtualMais3
                                              })
        End If

        GetIndustriaMoagemProjecaoPorDia = varIndustriaMoagemProjecao
    End Function

    Private Function GetIndustriaMoagemAcumuladoPorDiaAjustadoMetas(parIndustriaMoagemPorHora As S5TIndustriaMoagemPorHora, parHoraAtual As String) As S5TIndustriaMoagemPorHora
        GetIndustriaMoagemAcumuladoPorDiaAjustadoMetas = parIndustriaMoagemPorHora

        Dim varHoraAtual = Convert.ToInt16(parHoraAtual)

        Dim t as Type = parIndustriaMoagemPorHora.GetType()

        For i As Integer = varHoraAtual To 22
            Dim varValorMetaHoraMenos1 As Double = 0
            If i > 0 Then
                Dim varNomePropriedadeHoraMenos1 = "H" & (i-1).ToString.PadLeft(2, "0")
                Dim fieldHoraMenos1 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraMenos1)
                varValorMetaHoraMenos1 = fieldHoraMenos1.GetValue(parIndustriaMoagemPorHora, Nothing)
            End If

            Dim varNomePropriedadeHoraAtual = "H" & i.ToString.PadLeft(2, "0")
            Dim fieldHoraAtual As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtual)
            Dim varValorMetaHoraAtual As Double = fieldHoraAtual.GetValue(parIndustriaMoagemPorHora, Nothing)

            Dim varNomePropriedadeHoraMais1 = "H" & (i+1).ToString.PadLeft(2, "0")
            Dim fieldHoraMais1 As PropertyInfo = t.GetProperty(varNomePropriedadeHoraMais1)
            Dim varValorMetaHoraMais1 As Double = fieldHoraMais1.GetValue(parIndustriaMoagemPorHora, Nothing)

            If varValorMetaHoraMais1 <= varValorMetaHoraAtual Then
                fieldHoraMais1.SetValue(parIndustriaMoagemPorHora, Math.Round(varValorMetaHoraAtual + (varValorMetaHoraAtual - varValorMetaHoraMenos1),0))
            End If            
        Next

        GetIndustriaMoagemAcumuladoPorDiaAjustadoMetas = parIndustriaMoagemPorHora
    End Function

    Private Function GetPassoPorDia(parDadosMoagemPorMoendaGeralPorHora As List(Of S5TIndustriaMoagemPorHora), parHoraAtual As String) As Double
        GetPassoPorDia = 0

        Dim objDesvioAcumulado = parDadosMoagemPorMoendaGeralPorHora.FirstOrDefault(Function(x) x.Diario = "Desvio" And x.Hora = "Acumulado (ton)")
        Dim objPlanejado = parDadosMoagemPorMoendaGeralPorHora.FirstOrDefault(Function(x) x.Diario = "Planejado" And x.Hora = "Horário (ton/h)")

        Dim varHoraAtual = Convert.ToInt16(parHoraAtual)

        Dim t as Type = objDesvioAcumulado.GetType()

        Dim varNomePropriedadeHoraAtual = "H" & varHoraAtual.ToString.PadLeft(2, "0")
        Dim fieldHoraAtual As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAtual)

        Dim varDesvioAcumuladoHoraAtual As Double = fieldHoraAtual.GetValue(objDesvioAcumulado, Nothing)
        Dim varPlanejadoHoraAtual As Double = fieldHoraAtual.GetValue(objPlanejado, Nothing)

        Dim varPasso As Double = 0

        If varHoraAtual - 23 <> 0 Then
            varPasso = ((varDesvioAcumuladoHoraAtual / (varHoraAtual - 23))) + varPlanejadoHoraAtual
        End If

        GetPassoPorDia = Math.Round(varPasso,0)
    End Function

    Private Function GetProjecaoDiaAlertarInsuficiencia(parIndustriaMoagemProjecao As List(Of S5TIndustriaMoagemProjecao)) As Boolean
        Dim varIndustriaMoagemProjecao = parIndustriaMoagemProjecao.OrderBy(Function(x) x.ProjecaoHora)

        Dim varMetaSeraAlcancada = True

        For Each objIndustriaMoagemProjecao As S5TIndustriaMoagemProjecao In varIndustriaMoagemProjecao
            varMetaSeraAlcancada = varMetaSeraAlcancada And objIndustriaMoagemProjecao.Projecao >= objIndustriaMoagemProjecao.Meta
        Next

        GetProjecaoDiaAlertarInsuficiencia = Not varMetaSeraAlcancada
    End Function

    Private Function GetMediaMoagemHoraAnterior(parDadosMoagemPorMoendaGeralPorHora As List(Of S5TIndustriaMoagemPorHora), parHoraAtual As String) As Double
        GetMediaMoagemHoraAnterior = 0

        Dim objRealizadoAcumulado = parDadosMoagemPorMoendaGeralPorHora.FirstOrDefault(Function(x) x.Diario = "Realizado" And x.Hora = "Acumulado (ton/dia)")

        Dim varHoraAtual = Convert.ToInt16(parHoraAtual)

        If varHoraAtual > 0 Then
            Dim t as Type = objRealizadoAcumulado.GetType()

            Dim varNomePropriedadeHoraAnterior = "H" & (varHoraAtual - 1).ToString.PadLeft(2, "0")
            Dim fieldHoraAnterior As PropertyInfo = t.GetProperty(varNomePropriedadeHoraAnterior)

            Dim varRealizadoAcumuladoHoraAnterior As Double = fieldHoraAnterior.GetValue(objRealizadoAcumulado, Nothing)

            Dim varMediaMoagemHoraAnterior As Double = varRealizadoAcumuladoHoraAnterior / varHoraAtual


            GetMediaMoagemHoraAnterior = Math.Round(varMediaMoagemHoraAnterior,0)
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
