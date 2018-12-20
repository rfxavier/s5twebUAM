Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization

<RoutePrefix("api/GerencialHistoricoPropriedade")>
Public Class GerencialHistoricoPropriedadeController
    Inherits ApiController

    <DataContract>
    Private Class S5TPropriedade
        Public Property ID_NEGOCIOS As Integer
        Public Property SAFRA As Integer
        <DataMember>
        Public Property COD_PROPRIEDADE As Integer
        <DataMember>
        Public Property DSC_PROPRIEDADE As String
        <DataMember>
        Public Property oAmbientes As List(Of S5TPropriedadeAmbiente)
        <DataMember>
        Public Property oMaturacoes As List(Of S5TPropriedadeMaturacao)
        <DataMember>
        Public Property oVariedades As List(Of S5TPropriedadeVariedade)
        <DataMember>
        Public Property oCortes As List(Of S5TPropriedadeCorte)
        <DataMember>
        Public Property oPlantios As List(Of S5TPlantio)
        <DataMember>
        Public Property oProducaoTonsHa As List(Of S5TProducaoTonHa)
        <DataMember>
        Public Property oProducaoCanasEntregues As List(Of S5TProducaoCanaEntregue)
        <DataMember>
        Public Property oProducaoResumoAmbientes As List(Of S5TProducaoResumoAmbiente)
        <DataMember>
        Public Property oTratosCulturais As List(Of S5TTratosCulturais)
        <DataMember>
        Public Property oNaoConformidades As List(Of S5TNaoConformidade)
        <DataMember>
        Public Property oDiagnosticoColheita As List(Of S5TNaoConformidade)
    End Class

    <DataContract>
    Private Class S5TPropriedadeTalhao
        Implements ICloneable
        <DataMember>
        Public Property NUMERO As Integer
        <DataMember>
        Public Property DT_COLHEITA As Date
        <DataMember>
        Public Property REFORMA As String
        <DataMember>
        Public Property ULT_CORTE_MUDA As Date

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class

    <DataContract>
    Private Class S5TPropriedadeAmbiente
        <DataMember>
        Public Property AMBIENTE As String
        <DataMember>
        Public Property AREA_TOTAL As Double
        <DataMember>
        Public Property oTalhoes As List(Of S5TPropriedadeTalhao)
    End Class

    <DataContract>
    Private Class S5TPropriedadeMaturacao
        <DataMember>
        Public Property MATURACAO As String
        <DataMember>
        Public Property AREA_TOTAL As Double
        <DataMember>
        Public Property oTalhoes As List(Of S5TPropriedadeTalhao)
    End Class

    <DataContract>
    Private Class S5TPropriedadeVariedade
        <DataMember>
        Public Property VARIEDADE As String
        <DataMember>
        Public Property AREA_TOTAL As Double
        <DataMember>
        Public Property oTalhoes As List(Of S5TPropriedadeTalhao)
    End Class

    <DataContract>
    Private Class S5TPropriedadeCorte
        <DataMember>
        Public Property CORTE As String
        <DataMember>
        Public Property AREA_TOTAL As Double
        <DataMember>
        Public Property oTalhoes As List(Of S5TPropriedadeTalhao)
    End Class

    Private Class S5TVDadosTalhao
        Public Property ID_NEGOCIOS As Integer
        Public Property SAFRA As Integer
        Public Property COD_PROPRIEDADE As Integer
        Public Property DSC_PROPRIEDADE As String
        Public Property TALHAO As Integer
        Public Property CORTE As Integer
        Public Property AMBIENTE As String
        Public Property VARIEDADE As String
        Public Property MATURACAO As String
        Public Property DT_COLHEITA As Date
        Public Property REFORMA As String
        Public Property ULT_CORTE_MUDA As Date
        Public Property AREA_TOTAL As Double

    End Class

    Private Class S5TAmbiente
        Public Property AMBIENTE As String
        Public Property AREA_TOTAL As Double

    End Class

    Private Class S5TMaturacao
        Public Property MATURACAO As String
        Public Property AREA_TOTAL As Double

    End Class

    Private Class S5TVariedade
        Public Property VARIEDADE As String
        Public Property AREA_TOTAL As Double

    End Class

    Private Class S5TCorte
        Public Property CORTE As Integer
        Public Property AREA_TOTAL As Double

    End Class


    <DataContract>
    Private Class S5TPlantio
        <DataMember>
        Public Property SAFRA As Integer
        <DataMember>
        Public Property DT_PLANTIO As Date
        <DataMember>
        Public Property AREA_PLANTIO As Double
    End Class

    <DataContract>
    Private Class S5TProducaoTonHa
        <DataMember>
        Public Property CORTE As Integer
        <DataMember>
        Public Property SAFRA_01 As Double
        <DataMember>
        Public Property SAFRA_02 As Double
        <DataMember>
        Public Property SAFRA_03 As Double
        <DataMember>
        Public Property SAFRA_04 As Double
        <DataMember>
        Public Property SAFRA_05 As Double
        <DataMember>
        Public Property SAFRA_06 As Double
        <DataMember>
        Public Property SAFRA_07 As Double
    End Class

    <DataContract>
    Private Class S5TProducaoCanaEntregue
        <DataMember>
        Public Property SAFRA_01 As Double
        <DataMember>
        Public Property SAFRA_02 As Double
        <DataMember>
        Public Property SAFRA_03 As Double
        <DataMember>
        Public Property SAFRA_04 As Double
        <DataMember>
        Public Property SAFRA_05 As Double
        <DataMember>
        Public Property SAFRA_06 As Double
        <DataMember>
        Public Property SAFRA_07 As Double
    End Class

    <DataContract>
    Private Class S5TProducaoResumoAmbiente
        <DataMember>
        Public Property AMBIENTE As String
        <DataMember>
        Public Property AREA_COLHIDA As Double
        <DataMember>
        Public Property DT_PLANTIO As String
        <DataMember>
        Public Property DT_COLHEITA_ANT As String
        <DataMember>
        Public Property DT_COLHEITA_ATU As String
        <DataMember>
        Public Property IDADE As Double
        <DataMember>
        Public Property PERC_BROCA As Double
        <DataMember>
        Public Property PERC_PERDA As Double
        <DataMember>
        Public Property TCH As Double
        <DataMember>
        Public Property TON_HA_PLAN As Double
        <DataMember>
        Public Property TON_HA_REAL As Double
        <DataMember>
        Public Property oCortes As List(Of S5TProducaoResumoAmbienteCorte)
    End Class

    <DataContract>
    Private Class S5TProducaoResumoAmbienteCorte
        Implements ICloneable
        Public Property AMBIENTE As String
        <DataMember>
        Public Property CORTE As Integer
        <DataMember>
        Public Property AREA_COLHIDA As Double
        <DataMember>
        Public Property DT_PLANTIO As String
        <DataMember>
        Public Property DT_COLHEITA_ANT As String
        <DataMember>
        Public Property DT_COLHEITA_ATU As String
        <DataMember>
        Public Property IDADE As Double
        <DataMember>
        Public Property PERC_BROCA As Double
        <DataMember>
        Public Property PERC_PERDA As Double
        <DataMember>
        Public Property TCH As Double
        <DataMember>
        Public Property TON_HA_PLAN As Double
        <DataMember>
        Public Property TON_HA_REAL As Double
        <DataMember>
        Public Property oTalhoes As List(Of S5TProducaoResumoAmbienteCorteTalhao)

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class

    <DataContract>
    Private Class S5TProducaoResumoAmbienteCorteTalhao
        Implements ICloneable
        Public Property AMBIENTE As String
        Public Property CORTE As Integer
        <DataMember>
        Public Property TALHAO As Integer
        <DataMember>
        Public Property AREA_COLHIDA As Double
        <DataMember>
        Public Property DT_PLANTIO As String
        <DataMember>
        Public Property DT_COLHEITA_ANT As String
        <DataMember>
        Public Property DT_COLHEITA_ATU As String
        <DataMember>
        Public Property IDADE As Double
        <DataMember>
        Public Property PERC_BROCA As Double
        <DataMember>
        Public Property PERC_PERDA As Double
        <DataMember>
        Public Property TCH As Double
        <DataMember>
        Public Property TON_HA_PLAN As Double
        <DataMember>
        Public Property TON_HA_REAL As Double

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class

    <DataContract>
    Private Class S5TTratosCulturais
        <DataMember>
        Public Property ID_GRUPO As Integer
        Public Property DS_GRUPO As String
        <DataMember>
        Public Property ATIVIDADE As Integer
        <DataMember>
        Public Property DSC_ATIVIDADE As String
        <DataMember>
        Public Property NRO_APLIC_0 As Double
        <DataMember>
        Public Property NRO_APLIC_1 As Double
        <DataMember>
        Public Property NRO_APLIC_2 As Double
        <DataMember>
        Public Property NRO_APLIC_3 As Double
        <DataMember>
        Public Property NRO_APLIC_4 As Double
        <DataMember>
        Public Property NRO_APLIC_5 As Double
        <DataMember>
        Public Property NRO_APLIC_6 As Double
        <DataMember>
        Public Property NRO_APLIC_7 As Double
        <DataMember>
        Public Property NRO_APLIC_8 As Double
        <DataMember>
        Public Property NRO_APLIC_9 As Double
        <DataMember>
        Public Property NRO_APLIC_10 As Double
        Public Property oTalhoes As List(Of S5TTratosCulturaisTalhao)
    End Class

    <DataContract>
    Private Class S5TTratosCulturaisTalhao
        Implements ICloneable
        Public Property ATIVIDADE As Integer
        <DataMember>
        Public Property TALHAO As Integer
        <DataMember>
        Public Property AREA_TALHAO_DIS As Double
        <DataMember>
        Public Property NRO_APLIC_0 As String
        <DataMember>
        Public Property NRO_APLIC_1 As String
        <DataMember>
        Public Property NRO_APLIC_2 As String
        <DataMember>
        Public Property NRO_APLIC_3 As String
        <DataMember>
        Public Property NRO_APLIC_4 As String
        <DataMember>
        Public Property NRO_APLIC_5 As String
        <DataMember>
        Public Property NRO_APLIC_6 As String
        <DataMember>
        Public Property NRO_APLIC_7 As String
        <DataMember>
        Public Property NRO_APLIC_8 As String
        <DataMember>
        Public Property NRO_APLIC_9 As String
        <DataMember>
        Public Property NRO_APLIC_10 As String
        <DataMember>
        Public Property oDatasAplicacao As List(Of S5TTratosCulturaisDataAplicacao)
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class

    <DataContract>
    Private Class S5TTratosCulturaisDataAplicacao
        Implements ICloneable
        Public Property ATIVIDADE As Integer
        Public Property TALHAO As Integer
        <DataMember>
        Public Property AREA_APLICADA As Double
        <DataMember>
        Public Property DATA_APLICACAO As Date
        <DataMember>
        Public Property DIAS As Integer
        <DataMember>
        Public Property PRODUTO_DOSAGEM As String
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function

    End Class

    <DataContract>
    Private Class S5TNaoConformidade
        <DataMember>
        Public Property TALHOES_AFETADOS As String
        <DataMember>
        Public Property COD_OCORR As Integer
        <DataMember>
        Public Property DSC_OCORR As String
        <DataMember>
        Public Property DT_OCORR As Date
        <DataMember>
        Public Property CONSIDERACOES As String
        <DataMember>
        Public Property AREA_AFETADA As Double
        <DataMember>
        Public Property AREA_TOTAL As Double
    End Class

    'GET api/GerencialHistoricoPropriedade
    <HttpGet>
    <Route("")>
    Public Function GetValues() As IHttpActionResult

        Return NotFound()
    End Function

    'GET api/GerencialHistoricoPropriedade/2016
    <HttpGet>
    <Route("{SAFRA}")>
    Public Function GetValues(ByVal SAFRA As Integer) As IHttpActionResult

        Return NotFound()
    End Function

    'GET api/GerencialHistoricoPropriedade/2016/124
    <HttpGet>
    <Route("{SAFRA}/{COD_PROPRIEDADE}")>
    Public Function GetValues(ByVal SAFRA As Integer, ByVal COD_PROPRIEDADE As Integer) As IHttpActionResult
        Dim HistProp As S5TPropriedade = Nothing

        Dim HistPropAmbientes As New List(Of S5TPropriedadeAmbiente)
        Dim HistPropMaturacoes As New List(Of S5TPropriedadeMaturacao)
        Dim HistPropVariedades As New List(Of S5TPropriedadeVariedade)
        Dim HistPropCortes As New List(Of S5TPropriedadeCorte)

        Dim HistPropTalhoes As New List(Of S5TPropriedadeTalhao)
        Dim HistPropTalhoesClone As List(Of S5TPropriedadeTalhao)


        Dim HistPropPlantios As New List(Of S5TPlantio)


        Dim HistPropProducaoTonsHa As New List(Of S5TProducaoTonHa)


        Dim HistPropProducaoCanasEntregues As New List(Of S5TProducaoCanaEntregue)


        Dim HistPropProducaoResumoAmbiente As New List(Of S5TProducaoResumoAmbiente)

        Dim HistPropProducaoResumoAmbienteCortes As New List(Of S5TProducaoResumoAmbienteCorte)
        Dim HistPropProducaoResumoAmbienteCortesClone As New List(Of S5TProducaoResumoAmbienteCorte)

        Dim HistPropProducaoResumoAmbienteCorteTalhoes As New List(Of S5TProducaoResumoAmbienteCorteTalhao)
        Dim HistPropProducaoResumoAmbienteCorteTalhoesClone As New List(Of S5TProducaoResumoAmbienteCorteTalhao)


        Dim HistPropTratosCulturais As New List(Of S5TTratosCulturais)

        Dim HistPropTratosCulturaisTalhoes As New List(Of S5TTratosCulturaisTalhao)
        Dim HistPropTratosCulturaisTalhoesClone As New List(Of S5TTratosCulturaisTalhao)

        Dim HistPropTratosCulturaisTalhoesDatasAplicacao As New List(Of S5TTratosCulturaisDataAplicacao)
        Dim HistPropTratosCulturaisTalhoesDatasAplicacaoClone As New List(Of S5TTratosCulturaisDataAplicacao)

        Dim HistPropNaoConformidadesBase As New List(Of S5TNaoConformidade)

        Dim HistPropNaoConformidades As New List(Of S5TNaoConformidade)

        Dim HistPropDiagnosticoColheita As New List(Of S5TNaoConformidade)

        Dim VDadosTalhoes As New List(Of S5TVDadosTalhao)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosTalhao As New OracleCommand("SELECT 1 ID_NEGOCIOS, SAFRA, COD_PROPRIEDADE, DSC_PROPRIEDADE, TALHAO, CORTE, AMBIENTE, VARIEDADE, MATURACAO, DT_COLHEITA, REFORMA, CASE WHEN (ULT_CORTE_MUDA < ADD_MONTHS(TO_DATE('01/01/' || SAFRA), -24)) THEN NULL ELSE ULT_CORTE_MUDA END AS ULT_CORTE_MUDA, AREA_TOTAL FROM BI4T.V_DADOS_TALHAO WHERE SAFRA = :p0 AND COD_PROPRIEDADE = :p1", conn) With {.CommandType = CommandType.Text}
            cmdDadosTalhao.Parameters.Add(":p0", OracleDbType.Int16).Value = SAFRA
            cmdDadosTalhao.Parameters.Add(":p1", OracleDbType.Int16).Value = COD_PROPRIEDADE

            Dim drDadosTalhao As OracleDataReader = Nothing
            Try
                drDadosTalhao = cmdDadosTalhao.ExecuteReader()
                If drDadosTalhao.HasRows Then
                    Do While drDadosTalhao.Read
                        Dim objDadosTalhao = New S5TVDadosTalhao

                        objDadosTalhao.ID_NEGOCIOS = AppUtils.Nvl(drDadosTalhao.Item("ID_NEGOCIOS"), 0)
                        objDadosTalhao.SAFRA = AppUtils.Nvl(drDadosTalhao.Item("SAFRA"), 0)
                        objDadosTalhao.COD_PROPRIEDADE = AppUtils.Nvl(drDadosTalhao.Item("COD_PROPRIEDADE"), 0)
                        objDadosTalhao.DSC_PROPRIEDADE = AppUtils.Nvl(drDadosTalhao.Item("DSC_PROPRIEDADE"), "")
                        objDadosTalhao.TALHAO = AppUtils.Nvl(drDadosTalhao.Item("TALHAO"), 0)
                        objDadosTalhao.CORTE = AppUtils.Nvl(drDadosTalhao.Item("CORTE"), 0)
                        objDadosTalhao.AMBIENTE = AppUtils.Nvl(drDadosTalhao.Item("AMBIENTE"), "")
                        objDadosTalhao.VARIEDADE = AppUtils.Nvl(drDadosTalhao.Item("VARIEDADE"), "")
                        objDadosTalhao.MATURACAO = AppUtils.Nvl(drDadosTalhao.Item("MATURACAO"), "")
                        objDadosTalhao.DT_COLHEITA = AppUtils.Nvl(drDadosTalhao.Item("DT_COLHEITA"), DateTime.MinValue).ToUniversalTime()
                        objDadosTalhao.REFORMA = AppUtils.Nvl(drDadosTalhao.Item("REFORMA"), "")
                        objDadosTalhao.ULT_CORTE_MUDA = AppUtils.Nvl(drDadosTalhao.Item("ULT_CORTE_MUDA"), DateTime.MinValue).ToUniversalTime()
                        objDadosTalhao.AREA_TOTAL = AppUtils.Nvl(drDadosTalhao.Item("AREA_TOTAL"), 0)

                        VDadosTalhoes.Add(objDadosTalhao)
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
            Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
                                                                                             .SAFRA = x.SAFRA, _
                                                                                             .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
                                                                                             .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
                                                                                             .TALHAO = x.TALHAO, _
                                                                                             .CORTE = x.CORTE, _
                                                                                             .AMBIENTE = x.AMBIENTE, _
                                                                                             .VARIEDADE = x.VARIEDADE, _
                                                                                             .MATURACAO = x.MATURACAO, _
                                                                                             .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        'AQUI TENHO COLLECTION VDadosTalhoes PREENCHIDA
        Dim objPropriedade = GetPropriedade(VDadosTalhoes)

        For Each objAmbiente In GetAmbientes(VDadosTalhoes)
            HistPropTalhoes.Clear()
            HistPropTalhoes = VDadosTalhoes.FindAll(Function(x) x.AMBIENTE = objAmbiente.AMBIENTE).Select(Function(y) New S5TPropriedadeTalhao With {.NUMERO = y.TALHAO, .DT_COLHEITA = y.DT_COLHEITA, .REFORMA = y.REFORMA, .ULT_CORTE_MUDA = y.ULT_CORTE_MUDA}).ToList
            HistPropTalhoesClone = HistPropTalhoes.Select(Function(x) x.Clone()).Cast(Of S5TPropriedadeTalhao).ToList

            HistPropAmbientes.Add(New S5TPropriedadeAmbiente With {.AMBIENTE = objAmbiente.AMBIENTE, .AREA_TOTAL = objAmbiente.AREA_TOTAL, .oTalhoes = HistPropTalhoesClone})
        Next

        For Each objMaturacao In GetMaturacoes(VDadosTalhoes)
            HistPropTalhoes.Clear()
            HistPropTalhoes = VDadosTalhoes.FindAll(Function(x) x.MATURACAO = objMaturacao.MATURACAO).Select(Function(y) New S5TPropriedadeTalhao With {.NUMERO = y.TALHAO, .DT_COLHEITA = y.DT_COLHEITA, .REFORMA = y.REFORMA, .ULT_CORTE_MUDA = y.ULT_CORTE_MUDA}).ToList
            HistPropTalhoesClone = HistPropTalhoes.Select(Function(x) x.Clone()).Cast(Of S5TPropriedadeTalhao).ToList

            HistPropMaturacoes.Add(New S5TPropriedadeMaturacao With {.MATURACAO = objMaturacao.MATURACAO, .AREA_TOTAL = objMaturacao.AREA_TOTAL, .oTalhoes = HistPropTalhoesClone})
        Next

        For Each objVariedade In GetVariedades(VDadosTalhoes)
            HistPropTalhoes.Clear()
            HistPropTalhoes = VDadosTalhoes.FindAll(Function(x) x.VARIEDADE = objVariedade.VARIEDADE).Select(Function(y) New S5TPropriedadeTalhao With {.NUMERO = y.TALHAO, .DT_COLHEITA = y.DT_COLHEITA, .REFORMA = y.REFORMA, .ULT_CORTE_MUDA = y.ULT_CORTE_MUDA}).ToList
            HistPropTalhoesClone = HistPropTalhoes.Select(Function(x) x.Clone()).Cast(Of S5TPropriedadeTalhao).ToList

            HistPropVariedades.Add(New S5TPropriedadeVariedade With {.VARIEDADE = objVariedade.VARIEDADE, .AREA_TOTAL = objVariedade.AREA_TOTAL, .oTalhoes = HistPropTalhoesClone})
        Next

        For Each objCorte In GetCortes(VDadosTalhoes)
            HistPropTalhoes.Clear()
            HistPropTalhoes = VDadosTalhoes.FindAll(Function(x) x.CORTE = objCorte.CORTE).Select(Function(y) New S5TPropriedadeTalhao With {.NUMERO = y.TALHAO, .DT_COLHEITA = y.DT_COLHEITA, .REFORMA = y.REFORMA, .ULT_CORTE_MUDA = y.ULT_CORTE_MUDA}).ToList
            HistPropTalhoesClone = HistPropTalhoes.Select(Function(x) x.Clone()).Cast(Of S5TPropriedadeTalhao).ToList

            HistPropCortes.Add(New S5TPropriedadeCorte With {.CORTE = objCorte.CORTE, .AREA_TOTAL = objCorte.AREA_TOTAL, .oTalhoes = HistPropTalhoesClone})
        Next

        'PLANTIOS
        HistPropPlantios = GetPlantios(SAFRA, COD_PROPRIEDADE)

        'PRODUÇÃO TON / HA
        HistPropProducaoTonsHa = GetProducaoTonHa(SAFRA, COD_PROPRIEDADE).OrderBy(Function(x) x.CORTE).ToList

        'PRODUÇÃO CANA ENTREGUE
        HistPropProducaoCanasEntregues = GetProducaoCanaEntregue(SAFRA, COD_PROPRIEDADE)

        'PRODUÇÃO RESUMO AMBIENTE
        Dim HistPropProducaoResumoAmbientesBase = GetProducaoResumoAmbiente(SAFRA, COD_PROPRIEDADE)
        Dim HistPropProducaoResumoAmbienteCortesBase = GetProducaoResumoAmbienteCorte(SAFRA, COD_PROPRIEDADE)
        Dim HistPropProducaoResumoAmbienteCorteTalhoesBase = GetProducaoResumoAmbienteCorteTalhao(SAFRA, COD_PROPRIEDADE)

        'NÍVEL 1
        For Each objHistPropProducaoResumoAmbientesBase In HistPropProducaoResumoAmbientesBase
            HistPropProducaoResumoAmbienteCortes.Clear()
            HistPropProducaoResumoAmbienteCortes = GetProducaoResumoAmbienteCorte(objHistPropProducaoResumoAmbientesBase.AMBIENTE, HistPropProducaoResumoAmbienteCortesBase)
            HistPropProducaoResumoAmbienteCortesClone = HistPropProducaoResumoAmbienteCortes.Select(Function(x) x.Clone()).Cast(Of S5TProducaoResumoAmbienteCorte).ToList

            'NÍVEL 2
            Dim HistPropProducaoResumoAmbienteCortesTalhoesNew As New List(Of S5TProducaoResumoAmbienteCorte)

            For Each objHistPropProducaoResumoAmbientesCortesClone In HistPropProducaoResumoAmbienteCortesClone
                HistPropProducaoResumoAmbienteCorteTalhoes.Clear()
                HistPropProducaoResumoAmbienteCorteTalhoes = GetProducaoResumoAmbienteCorteTalhao(objHistPropProducaoResumoAmbientesCortesClone.AMBIENTE, objHistPropProducaoResumoAmbientesCortesClone.CORTE, HistPropProducaoResumoAmbienteCorteTalhoesBase)
                HistPropProducaoResumoAmbienteCorteTalhoesClone = HistPropProducaoResumoAmbienteCorteTalhoes.Select(Function(x) x.Clone()).Cast(Of S5TProducaoResumoAmbienteCorteTalhao).ToList

                HistPropProducaoResumoAmbienteCortesTalhoesNew.Add(New S5TProducaoResumoAmbienteCorte With {.AMBIENTE = objHistPropProducaoResumoAmbientesCortesClone.AMBIENTE, _
                                                                                                        .CORTE = objHistPropProducaoResumoAmbientesCortesClone.CORTE, _
                                                                                                        .AREA_COLHIDA = objHistPropProducaoResumoAmbientesCortesClone.AREA_COLHIDA, _
                                                                                                        .DT_PLANTIO = objHistPropProducaoResumoAmbientesCortesClone.DT_PLANTIO, _
                                                                                                        .DT_COLHEITA_ANT = objHistPropProducaoResumoAmbientesCortesClone.DT_COLHEITA_ANT, _
                                                                                                        .DT_COLHEITA_ATU = objHistPropProducaoResumoAmbientesCortesClone.DT_COLHEITA_ATU, _
                                                                                                        .IDADE = objHistPropProducaoResumoAmbientesCortesClone.IDADE, _
                                                                                                        .PERC_BROCA = objHistPropProducaoResumoAmbientesCortesClone.PERC_BROCA, _
                                                                                                        .PERC_PERDA = objHistPropProducaoResumoAmbientesCortesClone.PERC_PERDA, _
                                                                                                        .TCH = objHistPropProducaoResumoAmbientesCortesClone.TCH, _
                                                                                                        .TON_HA_PLAN = objHistPropProducaoResumoAmbientesCortesClone.TON_HA_PLAN, _
                                                                                                        .TON_HA_REAL = objHistPropProducaoResumoAmbientesCortesClone.TON_HA_REAL, _
                                                                                                        .oTalhoes = HistPropProducaoResumoAmbienteCorteTalhoesClone})
            Next

            HistPropProducaoResumoAmbiente.Add(New S5TProducaoResumoAmbiente With {.AMBIENTE = objHistPropProducaoResumoAmbientesBase.AMBIENTE, _
                                                                                    .AREA_COLHIDA = objHistPropProducaoResumoAmbientesBase.AREA_COLHIDA, _
                                                                                    .DT_PLANTIO = objHistPropProducaoResumoAmbientesBase.DT_PLANTIO, _
                                                                                    .DT_COLHEITA_ANT = objHistPropProducaoResumoAmbientesBase.DT_COLHEITA_ANT, _
                                                                                    .DT_COLHEITA_ATU = objHistPropProducaoResumoAmbientesBase.DT_COLHEITA_ATU, _
                                                                                    .IDADE = objHistPropProducaoResumoAmbientesBase.IDADE, _
                                                                                    .PERC_BROCA = objHistPropProducaoResumoAmbientesBase.PERC_BROCA, _
                                                                                    .PERC_PERDA = objHistPropProducaoResumoAmbientesBase.PERC_PERDA, _
                                                                                    .TCH = objHistPropProducaoResumoAmbientesBase.TCH, _
                                                                                    .TON_HA_PLAN = objHistPropProducaoResumoAmbientesBase.TON_HA_PLAN, _
                                                                                    .TON_HA_REAL = objHistPropProducaoResumoAmbientesBase.TON_HA_REAL, _
                                                                                    .oCortes = HistPropProducaoResumoAmbienteCortesTalhoesNew})
        Next


        'TRATOS CULTURAIS
        Dim HistPropTratosCulturaisBase = GetTratosCulturais(SAFRA, COD_PROPRIEDADE).OrderBy(Function(x) x.DSC_ATIVIDADE).ToList
        Dim HistPropTratosCulturaisTalhoesBase = GetTratosCulturaisTalhoes(SAFRA, COD_PROPRIEDADE)
        'NÍVEL 2 COMENTADO
        'Dim HistPropTratosCulturaisTalhoesDatasAplicacaoBase = GetTratosCulturaisTalhoesDatasAplicacao(SAFRA, COD_PROPRIEDADE)

        'NÍVEL 1
        For Each objHistPropTratosCulturaisBase In HistPropTratosCulturaisBase
            HistPropTratosCulturaisTalhoes.Clear()
            HistPropTratosCulturaisTalhoes = GetTratosCulturaisTalhoes(objHistPropTratosCulturaisBase.ATIVIDADE, HistPropTratosCulturaisTalhoesBase)
            HistPropTratosCulturaisTalhoesClone = HistPropTratosCulturaisTalhoes.Select(Function(x) x.Clone()).Cast(Of S5TTratosCulturaisTalhao).ToList

            'NÍVEL 2 COMENTADO
            'Dim HistPropTratosCulturaisTalhoesDatasAplicacoes As New List(Of S5TTratosCulturaisTalhao)

            'For Each objHistPropTratosCulturaisTalhoesClone In HistPropTratosCulturaisTalhoesClone
            '    HistPropTratosCulturaisTalhoesDatasAplicacao.Clear()
            '    HistPropTratosCulturaisTalhoesDatasAplicacao = GetTratosCulturaisTalhoesDatasAplicacao(objHistPropTratosCulturaisTalhoesClone.ATIVIDADE, objHistPropTratosCulturaisTalhoesClone.TALHAO, HistPropTratosCulturaisTalhoesDatasAplicacaoBase)
            '    HistPropTratosCulturaisTalhoesDatasAplicacaoClone = HistPropTratosCulturaisTalhoesDatasAplicacao.Select(Function(x) x.Clone()).Cast(Of S5TTratosCulturaisDataAplicacao).ToList

            '    HistPropTratosCulturaisTalhoesDatasAplicacoes.Add(New S5TTratosCulturaisTalhao With {.ATIVIDADE = objHistPropTratosCulturaisTalhoesClone.ATIVIDADE, _
            '                                                                                                     .TALHAO = objHistPropTratosCulturaisTalhoesClone.TALHAO, _
            '                                                                                                     .NRO_APLIC_0 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_0, _
            '                                                                                                     .NRO_APLIC_1 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_1, _
            '                                                                                                     .NRO_APLIC_2 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_2, _
            '                                                                                                     .NRO_APLIC_3 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_3, _
            '                                                                                                     .NRO_APLIC_4 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_4, _
            '                                                                                                     .NRO_APLIC_5 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_5, _
            '                                                                                                     .NRO_APLIC_6 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_6, _
            '                                                                                                     .NRO_APLIC_7 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_7, _
            '                                                                                                     .NRO_APLIC_8 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_8, _
            '                                                                                                     .NRO_APLIC_9 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_9, _
            '                                                                                                     .NRO_APLIC_10 = objHistPropTratosCulturaisTalhoesClone.NRO_APLIC_10, _
            '                                                                                                     .oDatasAplicacao = HistPropTratosCulturaisTalhoesDatasAplicacaoClone})
            'Next

            HistPropTratosCulturais.Add(New S5TTratosCulturais With {.ID_GRUPO = objHistPropTratosCulturaisBase.ID_GRUPO, _
                                                                     .DS_GRUPO = objHistPropTratosCulturaisBase.DS_GRUPO, _
                                                                     .ATIVIDADE = objHistPropTratosCulturaisBase.ATIVIDADE, _
                                                                     .DSC_ATIVIDADE = objHistPropTratosCulturaisBase.DSC_ATIVIDADE, _
                                                                     .NRO_APLIC_0 = objHistPropTratosCulturaisBase.NRO_APLIC_0, _
                                                                     .NRO_APLIC_1 = objHistPropTratosCulturaisBase.NRO_APLIC_1, _
                                                                     .NRO_APLIC_2 = objHistPropTratosCulturaisBase.NRO_APLIC_2, _
                                                                     .NRO_APLIC_3 = objHistPropTratosCulturaisBase.NRO_APLIC_3, _
                                                                     .NRO_APLIC_4 = objHistPropTratosCulturaisBase.NRO_APLIC_4, _
                                                                     .NRO_APLIC_5 = objHistPropTratosCulturaisBase.NRO_APLIC_5, _
                                                                     .NRO_APLIC_6 = objHistPropTratosCulturaisBase.NRO_APLIC_6, _
                                                                     .NRO_APLIC_7 = objHistPropTratosCulturaisBase.NRO_APLIC_7, _
                                                                     .NRO_APLIC_8 = objHistPropTratosCulturaisBase.NRO_APLIC_8, _
                                                                     .NRO_APLIC_9 = objHistPropTratosCulturaisBase.NRO_APLIC_9, _
                                                                     .NRO_APLIC_10 = objHistPropTratosCulturaisBase.NRO_APLIC_10, _
                                                                     .oTalhoes = Nothing})
            'NÍVEL 2 COMENTADO
            '                                                                    .oTalhoes = HistPropTratosCulturaisTalhoesDatasAplicacoes})
        Next

        'NÃO CONFORMIDADES - BASE
        HistPropNaoConformidadesBase = GetNaoConformidades(SAFRA, COD_PROPRIEDADE)

        'NÃO CONFORMIDADES
        HistPropNaoConformidades = GetNaoConformidades(HistPropNaoConformidadesBase, tipoNaoConformidade.naoConformidade)

        'DIAGNÓSTICO COLHEITA
        HistPropDiagnosticoColheita = GetNaoConformidades(HistPropNaoConformidadesBase, tipoNaoConformidade.diagnosticoColheita)

        HistProp = New S5TPropriedade With {.ID_NEGOCIOS = objPropriedade.ID_NEGOCIOS, _
                                                        .SAFRA = objPropriedade.SAFRA, _
                                                        .COD_PROPRIEDADE = objPropriedade.COD_PROPRIEDADE, _
                                                        .DSC_PROPRIEDADE = objPropriedade.DSC_PROPRIEDADE, _
                                                        .oAmbientes = HistPropAmbientes.OrderBy(Function(x) x.AMBIENTE).ToList, _
                                                        .oMaturacoes = HistPropMaturacoes.OrderBy(Function(x) x.MATURACAO).ToList, _
                                                        .oVariedades = HistPropVariedades.OrderBy(Function(x) x.VARIEDADE).ToList, _
                                                        .oCortes = HistPropCortes.OrderBy(Function(x) x.CORTE).ToList, _
                                                        .oPlantios = HistPropPlantios, _
                                                        .oProducaoTonsHa = HistPropProducaoTonsHa, _
                                                        .oProducaoCanasEntregues = HistPropProducaoCanasEntregues, _
                                                        .oProducaoResumoAmbientes = HistPropProducaoResumoAmbiente, _
                                                        .oTratosCulturais = HistPropTratosCulturais, _
                                                        .oNaoConformidades = HistPropNaoConformidades, _
                                                        .oDiagnosticoColheita = HistPropDiagnosticoColheita}

        Return Ok(HistProp)
    End Function

    'GET api/GerencialHistoricoPropriedade/2016/124/TratosCulturaisTalhoes/49
    <HttpGet>
    <Route("{SAFRA}/{COD_PROPRIEDADE}/TratosCulturaisTalhoes/{ATIVIDADE}")>
    Public Function GetValues(ByVal SAFRA As Integer, ByVal COD_PROPRIEDADE As Integer, ByVal ATIVIDADE As Integer) As IHttpActionResult
        Dim HistProp As S5TPropriedade = Nothing

        Dim HistPropTratosCulturaisTalhoes As New List(Of S5TTratosCulturaisTalhao)
        Dim HistPropTratosCulturaisTalhoesClone As New List(Of S5TTratosCulturaisTalhao)

        Dim HistPropTratosCulturaisTalhoesDatasAplicacao As New List(Of S5TTratosCulturaisDataAplicacao)
        Dim HistPropTratosCulturaisTalhoesDatasAplicacaoClone As New List(Of S5TTratosCulturaisDataAplicacao)

        'TRATOS CULTURAIS
        Dim HistPropTratosCulturaisTalhoesBase = GetTratosCulturaisTalhoes(SAFRA, COD_PROPRIEDADE, ATIVIDADE)
        Dim HistPropTratosCulturaisTalhoesDatasAplicacaoBase = GetTratosCulturaisTalhoesDatasAplicacao(SAFRA, COD_PROPRIEDADE, ATIVIDADE)


        'NÍVEL 2
        For Each objHistPropTratosCulturaisTalhoesBase In HistPropTratosCulturaisTalhoesBase
            HistPropTratosCulturaisTalhoesDatasAplicacao.Clear()
            HistPropTratosCulturaisTalhoesDatasAplicacao = GetTratosCulturaisTalhoesDatasAplicacao(objHistPropTratosCulturaisTalhoesBase.ATIVIDADE, objHistPropTratosCulturaisTalhoesBase.TALHAO, HistPropTratosCulturaisTalhoesDatasAplicacaoBase)
            HistPropTratosCulturaisTalhoesDatasAplicacaoClone = HistPropTratosCulturaisTalhoesDatasAplicacao.Select(Function(x) x.Clone()).Cast(Of S5TTratosCulturaisDataAplicacao).ToList

            HistPropTratosCulturaisTalhoes.Add(New S5TTratosCulturaisTalhao With {.ATIVIDADE = objHistPropTratosCulturaisTalhoesBase.ATIVIDADE, _
                                                                                    .TALHAO = objHistPropTratosCulturaisTalhoesBase.TALHAO, _
                                                                                    .AREA_TALHAO_DIS = objHistPropTratosCulturaisTalhoesBase.AREA_TALHAO_DIS, _
                                                                                    .NRO_APLIC_0 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_0, _
                                                                                    .NRO_APLIC_1 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_1, _
                                                                                    .NRO_APLIC_2 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_2, _
                                                                                    .NRO_APLIC_3 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_3, _
                                                                                    .NRO_APLIC_4 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_4, _
                                                                                    .NRO_APLIC_5 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_5, _
                                                                                    .NRO_APLIC_6 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_6, _
                                                                                    .NRO_APLIC_7 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_7, _
                                                                                    .NRO_APLIC_8 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_8, _
                                                                                    .NRO_APLIC_9 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_9, _
                                                                                    .NRO_APLIC_10 = objHistPropTratosCulturaisTalhoesBase.NRO_APLIC_10, _
                                                                                    .oDatasAplicacao = HistPropTratosCulturaisTalhoesDatasAplicacaoClone})
        Next

        Return Ok(HistPropTratosCulturaisTalhoes)
    End Function


    Private Function GetPropriedade(parVDadosTalhoes As List(Of S5TVDadosTalhao)) As S5TPropriedade
        Dim VDadosTalhoesAgrupadoPropriedade = parVDadosTalhoes.GroupBy(Function(x) x.COD_PROPRIEDADE).Select(Function(y) New S5TPropriedade With {.ID_NEGOCIOS = y.Min(Function(group) group.ID_NEGOCIOS), _
                                                                                                                                                   .SAFRA = y.Min(Function(group) group.SAFRA), _
                                                                                                                                                   .COD_PROPRIEDADE = y.Min(Function(group) group.COD_PROPRIEDADE), _
                                                                                                                                                   .DSC_PROPRIEDADE = y.Min(Function(group) group.DSC_PROPRIEDADE)}).ToList

        Return VDadosTalhoesAgrupadoPropriedade(0)
    End Function

    Private Function GetAmbientes(parVDadosTalhoes As List(Of S5TVDadosTalhao)) As List(Of S5TAmbiente)

        Dim VDadosTalhoesAgrupadoAmbiente = parVDadosTalhoes.GroupBy(Function(x) x.AMBIENTE).Select(Function(y) New S5TAmbiente With {.AMBIENTE = y.Key, .AREA_TOTAL = Math.Round(y.Sum(Function(group) group.AREA_TOTAL), 2)}).ToList

        Return VDadosTalhoesAgrupadoAmbiente
    End Function

    Private Function GetMaturacoes(parVDadosTalhoes As List(Of S5TVDadosTalhao)) As List(Of S5TMaturacao)

        Dim VDadosTalhoesAgrupadoMaturacao = parVDadosTalhoes.GroupBy(Function(x) x.MATURACAO).Select(Function(y) New S5TMaturacao With {.MATURACAO = y.Key, .AREA_TOTAL = Math.Round(y.Sum(Function(group) group.AREA_TOTAL), 2)}).ToList

        Return VDadosTalhoesAgrupadoMaturacao
    End Function

    Private Function GetVariedades(parVDadosTalhoes As List(Of S5TVDadosTalhao)) As List(Of S5TVariedade)

        Dim VDadosTalhoesAgrupadoVariedade = parVDadosTalhoes.GroupBy(Function(x) x.VARIEDADE).Select(Function(y) New S5TVariedade With {.VARIEDADE = y.Key, .AREA_TOTAL = Math.Round(y.Sum(Function(group) group.AREA_TOTAL), 2)}).ToList

        Return VDadosTalhoesAgrupadoVariedade
    End Function

    Private Function GetCortes(parVDadosTalhoes As List(Of S5TVDadosTalhao)) As List(Of S5TCorte)

        Dim VDadosTalhoesAgrupadoCorte = parVDadosTalhoes.GroupBy(Function(x) x.CORTE).Select(Function(y) New S5TCorte With {.CORTE = y.Key, .AREA_TOTAL = Math.Round(y.Sum(Function(group) group.AREA_TOTAL), 2)}).ToList

        Return VDadosTalhoesAgrupadoCorte
    End Function


    Private Function GetPlantios(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer) As List(Of S5TPlantio)
        Dim Plantios As New List(Of S5TPlantio)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosPlantio As New OracleCommand("SELECT AP.ACOM_SAFRA SAFRA, MAX(AP.ACOM_DATA) DT_PLANTIO, SUM(AP.ACOM_AREA_SULCACAO) AREA_PLANTIO FROM SISAGRI.ACOMPANHAMENTO_PLANTIO AP WHERE AP.ID_NEGOCIOS = 1 AND AP.ACOM_SAFRA >= :p0 - 6 AND AP.ACOM_CODIGO_PROP = :p1 GROUP BY AP.ACOM_SAFRA, AP.ACOM_SAFRA ORDER BY AP.ACOM_SAFRA", conn) With {.CommandType = CommandType.Text}
            cmdDadosPlantio.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosPlantio.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosPlantio As OracleDataReader = Nothing
            Try
                drDadosPlantio = cmdDadosPlantio.ExecuteReader()
                If drDadosPlantio.HasRows Then
                    Do While drDadosPlantio.Read
                        Dim objDadosPlantio = New S5TPlantio

                        objDadosPlantio.SAFRA = AppUtils.Nvl(drDadosPlantio.Item("SAFRA"), 0)
                        objDadosPlantio.DT_PLANTIO = AppUtils.Nvl(drDadosPlantio.Item("DT_PLANTIO"), DateTime.MinValue).ToUniversalTime()
                        objDadosPlantio.AREA_PLANTIO = AppUtils.Nvl(drDadosPlantio.Item("AREA_PLANTIO"), 0)

                        Plantios.Add(objDadosPlantio)
                    Loop

                    drDadosPlantio.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosPlantio) Is Nothing) Then
                    drDadosPlantio.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return Plantios
    End Function


    Private Function GetProducaoTonHa(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer) As List(Of S5TProducaoTonHa)
        Dim ProducaoTonsHa As New List(Of S5TProducaoTonHa)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosProducaoTonHa As New OracleCommand(String.Format("SELECT XX.CORTE, ROUND(SUM(CASE WHEN (XX.Safra = {0} - 6) THEN XX.Ton_Ha ELSE 0 END), 0) AS Safra_01, ROUND(SUM(CASE WHEN (XX.Safra = {0} - 5) THEN XX.Ton_Ha ELSE 0 END), 0) AS Safra_02, ROUND(SUM(CASE WHEN (XX.Safra = {0} - 4) THEN XX.Ton_Ha ELSE 0 END), 0) AS Safra_03, ROUND(SUM(CASE WHEN (XX.Safra = {0} - 3) THEN XX.Ton_Ha ELSE 0 END), 0) AS Safra_04, ROUND(SUM(CASE WHEN (XX.Safra = {0} - 2) THEN XX.Ton_Ha ELSE 0 END), 0) AS Safra_05, ROUND(SUM(CASE WHEN (XX.Safra = {0} - 1) THEN XX.Ton_Ha ELSE 0 END), 0) AS Safra_06, ROUND(SUM(CASE WHEN (XX.Safra = {0} - 0) THEN XX.Ton_Ha ELSE 0 END), 0) AS Safra_07 FROM (SELECT P.SAFRA, P.CORTE, DECODE(NVL(SUM(P.AREA_TOTAL), 0), 0, 0, (SUM(P.TONELADA) / SUM(P.AREA_TOTAL))) TON_HA FROM BI4T.HISTORICO_PROPRIEDADE P WHERE P.ID_NEGOCIOS = 1 AND P.SAFRA BETWEEN {0} - 6 AND {0} AND P.COD_PROPRIEDADE = :p0 GROUP BY P.SAFRA, P.CORTE) XX GROUP BY XX.CORTE UNION ALL SELECT 99 CORTE, ROUND(SUM(CASE WHEN (XX.Safra = {0}-6) THEN XX.Ton_Ha ELSE 0 END),0) AS Safra_01, ROUND(SUM(CASE WHEN (XX.Safra = {0}-5) THEN XX.Ton_Ha ELSE 0 END),0) AS Safra_02, ROUND(SUM(CASE WHEN (XX.Safra = {0}-4) THEN XX.Ton_Ha ELSE 0 END),0) AS Safra_03, ROUND(SUM(CASE WHEN (XX.Safra = {0}-3) THEN XX.Ton_Ha ELSE 0 END),0) AS Safra_04, ROUND(SUM(CASE WHEN (XX.Safra = {0}-2) THEN XX.Ton_Ha ELSE 0 END),0) AS Safra_05, ROUND(SUM(CASE WHEN (XX.Safra = {0}-1) THEN XX.Ton_Ha ELSE 0 END),0) AS Safra_06, ROUND(SUM(CASE WHEN (XX.Safra = {0}-0) THEN XX.Ton_Ha ELSE 0 END),0) AS Safra_07 FROM (SELECT P.SAFRA, DECODE(NVL(SUM(P.AREA_TOTAL),0), 0, 0, (SUM(P.TONELADA) / SUM(P.AREA_TOTAL))) TON_HA FROM BI4T.HISTORICO_PROPRIEDADE P WHERE P.ID_NEGOCIOS = 1 AND P.SAFRA BETWEEN {0} - 6 AND 2016 AND P.COD_PROPRIEDADE = :p0 GROUP BY P.SAFRA) XX", parSafra), conn) With {.CommandType = CommandType.Text}
            cmdDadosProducaoTonHa.Parameters.Add(":p0", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosProducaoTonHa As OracleDataReader = Nothing
            Try
                drDadosProducaoTonHa = cmdDadosProducaoTonHa.ExecuteReader()
                If drDadosProducaoTonHa.HasRows Then
                    Do While drDadosProducaoTonHa.Read
                        Dim objDadosProducaoTonHa = New S5TProducaoTonHa

                        objDadosProducaoTonHa.CORTE = AppUtils.Nvl(drDadosProducaoTonHa.Item("CORTE"), 0)
                        objDadosProducaoTonHa.SAFRA_01 = AppUtils.Nvl(drDadosProducaoTonHa.Item("SAFRA_01"), 0)
                        objDadosProducaoTonHa.SAFRA_02 = AppUtils.Nvl(drDadosProducaoTonHa.Item("SAFRA_02"), 0)
                        objDadosProducaoTonHa.SAFRA_03 = AppUtils.Nvl(drDadosProducaoTonHa.Item("SAFRA_03"), 0)
                        objDadosProducaoTonHa.SAFRA_04 = AppUtils.Nvl(drDadosProducaoTonHa.Item("SAFRA_04"), 0)
                        objDadosProducaoTonHa.SAFRA_05 = AppUtils.Nvl(drDadosProducaoTonHa.Item("SAFRA_05"), 0)
                        objDadosProducaoTonHa.SAFRA_06 = AppUtils.Nvl(drDadosProducaoTonHa.Item("SAFRA_06"), 0)
                        objDadosProducaoTonHa.SAFRA_07 = AppUtils.Nvl(drDadosProducaoTonHa.Item("SAFRA_07"), 0)

                        ProducaoTonsHa.Add(objDadosProducaoTonHa)
                    Loop

                    drDadosProducaoTonHa.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosProducaoTonHa) Is Nothing) Then
                    drDadosProducaoTonHa.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return ProducaoTonsHa

    End Function

    Private Function GetProducaoCanaEntregue(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer) As List(Of S5TProducaoCanaEntregue)
        Dim ProducaoCanaEntregue As New List(Of S5TProducaoCanaEntregue)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosProducaoCanaEntregue As New OracleCommand(String.Format("SELECT ROUND(SUM(CASE WHEN (XX.Safra = {0}-6) THEN XX.TONELADA ELSE 0 END),0) AS Safra_01, ROUND(SUM(CASE WHEN (XX.Safra = {0}-5) THEN XX.TONELADA ELSE 0 END),0) AS Safra_02, ROUND(SUM(CASE WHEN (XX.Safra = {0}-4) THEN XX.TONELADA ELSE 0 END),0) AS Safra_03, ROUND(SUM(CASE WHEN (XX.Safra = {0}-3) THEN XX.TONELADA ELSE 0 END),0) AS Safra_04, ROUND(SUM(CASE WHEN (XX.Safra = {0}-2) THEN XX.TONELADA ELSE 0 END),0) AS Safra_05, ROUND(SUM(CASE WHEN (XX.Safra = {0}-1) THEN XX.TONELADA ELSE 0 END),0) AS Safra_06, ROUND(SUM(CASE WHEN (XX.Safra = {0}-0) THEN XX.TONELADA ELSE 0 END),0) AS Safra_07 FROM (SELECT P.SAFRA, P.CORTE, NVL(SUM(P.TONELADA),0) TONELADA FROM BI4T.HISTORICO_PROPRIEDADE P WHERE P.ID_NEGOCIOS = 1 AND P.SAFRA BETWEEN {0} - 6 AND {0} AND P.COD_PROPRIEDADE = {1} GROUP BY P.SAFRA, P.CORTE) XX", parSafra, parCodigoPropriedade), conn) With {.CommandType = CommandType.Text}
            cmdDadosProducaoCanaEntregue.Parameters.Add(":p0", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosProducaoCanaEntregue As OracleDataReader = Nothing
            Try
                drDadosProducaoCanaEntregue = cmdDadosProducaoCanaEntregue.ExecuteReader()
                If drDadosProducaoCanaEntregue.HasRows Then
                    Do While drDadosProducaoCanaEntregue.Read
                        Dim objDadosProducaoCanaEntregue = New S5TProducaoCanaEntregue

                        objDadosProducaoCanaEntregue.SAFRA_01 = AppUtils.Nvl(drDadosProducaoCanaEntregue.Item("SAFRA_01"), 0)
                        objDadosProducaoCanaEntregue.SAFRA_02 = AppUtils.Nvl(drDadosProducaoCanaEntregue.Item("SAFRA_02"), 0)
                        objDadosProducaoCanaEntregue.SAFRA_03 = AppUtils.Nvl(drDadosProducaoCanaEntregue.Item("SAFRA_03"), 0)
                        objDadosProducaoCanaEntregue.SAFRA_04 = AppUtils.Nvl(drDadosProducaoCanaEntregue.Item("SAFRA_04"), 0)
                        objDadosProducaoCanaEntregue.SAFRA_05 = AppUtils.Nvl(drDadosProducaoCanaEntregue.Item("SAFRA_05"), 0)
                        objDadosProducaoCanaEntregue.SAFRA_06 = AppUtils.Nvl(drDadosProducaoCanaEntregue.Item("SAFRA_06"), 0)
                        objDadosProducaoCanaEntregue.SAFRA_07 = AppUtils.Nvl(drDadosProducaoCanaEntregue.Item("SAFRA_07"), 0)

                        ProducaoCanaEntregue.Add(objDadosProducaoCanaEntregue)
                    Loop

                    drDadosProducaoCanaEntregue.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosProducaoCanaEntregue) Is Nothing) Then
                    drDadosProducaoCanaEntregue.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return ProducaoCanaEntregue

    End Function


    Private Function GetProducaoResumoAmbiente(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer) As List(Of S5TProducaoResumoAmbiente)
        Dim ProducaoResumoAmbiente As New List(Of S5TProducaoResumoAmbiente)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosProducaoResumoAmbiente As New OracleCommand("SELECT HP.AMBIENTE, NVL(SUM(HP.AREA_LIBERADA),0) AREA_COLHIDA, TRIM(TO_CHAR(MIN(HP.DT_PLANTIO),'DD/MM') ||' a '|| TO_CHAR(MAX(HP.DT_PLANTIO),'DD/MM/YYYY')) DT_PLANTIO, TRIM(TO_CHAR(MIN(HP.DT_COLHEITA_ANT),'DD/MM') ||' a '|| TO_CHAR(MAX(HP.DT_COLHEITA_ANT),'DD/MM/YYYY')) DT_COLHEITA_ANT, TRIM(TO_CHAR(MIN(HP.DT_COLHEITA_ATU),'DD/MM') ||' a '|| TO_CHAR(MAX(HP.DT_COLHEITA_ATU),'DD/MM/YYYY')) DT_COLHEITA_ATU, ROUND(DECODE(NVL(SUM(HP.TONELADA),0), 0, 0, (NVL(SUM(HP.IDADE * HP.AREA_LIBERADA),0) / SUM(HP.AREA_LIBERADA))),2) IDADE, ROUND(DECODE(NVL(SUM(HP.TONELADA_BROCA),0), 0, NULL, (NVL(SUM(HP.PERC_BROCA * HP.TONELADA_BROCA),0) / SUM(HP.TONELADA_BROCA))),3) PERC_BROCA, ROUND(DECODE(NVL(SUM(HP.AREA_PERDA),0), 0, NULL, (NVL(SUM(HP.PERC_PERDA),0) / SUM(HP.AREA_PERDA))),3) PERC_PERDA, ROUND(DECODE(NVL(SUM(HP.TONELADA),0), 0, 0, (NVL(SUM(HP.TCH * HP.TONELADA),0) / SUM(HP.TONELADA))),3) TCH, ROUND(DECODE(NVL(SUM(HP.AREA_TOTAL),0), 0, 0, (NVL(SUM(HP.RENDIMENTO_PLAN * HP.AREA_TOTAL),0) / SUM(HP.AREA_TOTAL))),3) TON_HA_PLAN, ROUND(DECODE(NVL(SUM(HP.AREA_LIBERADA),0), 0, 0, NVL(SUM(HP.TONELADA),0) / SUM(HP.AREA_LIBERADA)),3) TON_HA_REAL FROM BI4T.HISTORICO_PROPRIEDADE HP WHERE HP.ID_NEGOCIOS = 1 AND HP.SAFRA = :p0 AND HP.COD_PROPRIEDADE = :p1 GROUP BY HP.AMBIENTE ORDER BY HP.AMBIENTE", conn) With {.CommandType = CommandType.Text}
            cmdDadosProducaoResumoAmbiente.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosProducaoResumoAmbiente.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosProducaoResumoAmbiente As OracleDataReader = Nothing
            Try
                drDadosProducaoResumoAmbiente = cmdDadosProducaoResumoAmbiente.ExecuteReader()
                If drDadosProducaoResumoAmbiente.HasRows Then
                    Do While drDadosProducaoResumoAmbiente.Read
                        Dim objDadosProducaoResumoAmbiente = New S5TProducaoResumoAmbiente

                        objDadosProducaoResumoAmbiente.AMBIENTE = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("AMBIENTE"), "")
                        objDadosProducaoResumoAmbiente.AREA_COLHIDA = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("AREA_COLHIDA"), 0)
                        objDadosProducaoResumoAmbiente.DT_PLANTIO = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("DT_PLANTIO"), "")
                        objDadosProducaoResumoAmbiente.DT_COLHEITA_ANT = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("DT_COLHEITA_ANT"), "")
                        objDadosProducaoResumoAmbiente.DT_COLHEITA_ATU = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("DT_COLHEITA_ATU"), "")
                        objDadosProducaoResumoAmbiente.IDADE = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("IDADE"), 0)
                        objDadosProducaoResumoAmbiente.PERC_BROCA = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("PERC_BROCA"), 0)
                        objDadosProducaoResumoAmbiente.PERC_PERDA = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("PERC_PERDA"), 0)
                        objDadosProducaoResumoAmbiente.TCH = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("TCH"), 0)
                        objDadosProducaoResumoAmbiente.TON_HA_PLAN = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("TON_HA_PLAN"), 0)
                        objDadosProducaoResumoAmbiente.TON_HA_REAL = AppUtils.Nvl(drDadosProducaoResumoAmbiente.Item("TON_HA_REAL"), 0)

                        ProducaoResumoAmbiente.Add(objDadosProducaoResumoAmbiente)
                    Loop

                    drDadosProducaoResumoAmbiente.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosProducaoResumoAmbiente) Is Nothing) Then
                    drDadosProducaoResumoAmbiente.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return ProducaoResumoAmbiente
    End Function

    Private Function GetProducaoResumoAmbienteCorte(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer) As List(Of S5TProducaoResumoAmbienteCorte)
        Dim ProducaoResumoAmbienteCorte As New List(Of S5TProducaoResumoAmbienteCorte)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosProducaoResumoAmbienteCorte As New OracleCommand("SELECT HP.AMBIENTE, HP.CORTE, NVL(SUM(HP.AREA_LIBERADA),0) AREA_COLHIDA, TRIM(TO_CHAR(MIN(HP.DT_PLANTIO),'DD/MM') ||' a '|| TO_CHAR(MAX(HP.DT_PLANTIO),'DD/MM/YYYY')) DT_PLANTIO, TRIM(TO_CHAR(MIN(HP.DT_COLHEITA_ANT),'DD/MM') ||' a '|| TO_CHAR(MAX(HP.DT_COLHEITA_ANT),'DD/MM/YYYY')) DT_COLHEITA_ANT, TRIM(TO_CHAR(MIN(HP.DT_COLHEITA_ATU),'DD/MM') ||' a '|| TO_CHAR(MAX(HP.DT_COLHEITA_ATU),'DD/MM/YYYY')) DT_COLHEITA_ATU, ROUND(DECODE(NVL(SUM(HP.TONELADA),0), 0, 0, (NVL(SUM(HP.IDADE * HP.AREA_LIBERADA),0) / SUM(HP.AREA_LIBERADA))),2) IDADE, ROUND(DECODE(NVL(SUM(HP.TONELADA_BROCA),0), 0, NULL, (NVL(SUM(HP.PERC_BROCA * HP.TONELADA_BROCA),0) / SUM(HP.TONELADA_BROCA))),3) PERC_BROCA, ROUND(DECODE(NVL(SUM(HP.AREA_PERDA),0), 0, NULL, (NVL(SUM(HP.PERC_PERDA),0) / SUM(HP.AREA_PERDA))),3) PERC_PERDA, ROUND(DECODE(NVL(SUM(HP.TONELADA),0), 0, 0, (NVL(SUM(HP.TCH * HP.TONELADA),0) / SUM(HP.TONELADA))),3) TCH, ROUND(DECODE(NVL(SUM(HP.AREA_TOTAL),0), 0, 0, (NVL(SUM(HP.RENDIMENTO_PLAN * HP.AREA_TOTAL),0) / SUM(HP.AREA_TOTAL))),3) TON_HA_PLAN, ROUND(DECODE(NVL(SUM(HP.AREA_LIBERADA),0), 0, 0, NVL(SUM(HP.TONELADA),0) / SUM(HP.AREA_LIBERADA)),3) TON_HA_REAL FROM BI4T.HISTORICO_PROPRIEDADE HP WHERE HP.ID_NEGOCIOS = 1 AND HP.SAFRA = :p0 AND HP.COD_PROPRIEDADE = :p1 GROUP BY HP.AMBIENTE, HP.CORTE ORDER BY HP.AMBIENTE, HP.CORTE", conn) With {.CommandType = CommandType.Text}
            cmdDadosProducaoResumoAmbienteCorte.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosProducaoResumoAmbienteCorte.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosProducaoResumoAmbienteCorte As OracleDataReader = Nothing
            Try
                drDadosProducaoResumoAmbienteCorte = cmdDadosProducaoResumoAmbienteCorte.ExecuteReader()
                If drDadosProducaoResumoAmbienteCorte.HasRows Then
                    Do While drDadosProducaoResumoAmbienteCorte.Read
                        Dim objDadosProducaoResumoAmbienteCorte = New S5TProducaoResumoAmbienteCorte

                        objDadosProducaoResumoAmbienteCorte.AMBIENTE = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("AMBIENTE"), "")
                        objDadosProducaoResumoAmbienteCorte.CORTE = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("CORTE"), 0)
                        objDadosProducaoResumoAmbienteCorte.AREA_COLHIDA = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("AREA_COLHIDA"), 0)
                        objDadosProducaoResumoAmbienteCorte.DT_PLANTIO = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("DT_PLANTIO"), "")
                        objDadosProducaoResumoAmbienteCorte.DT_COLHEITA_ANT = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("DT_COLHEITA_ANT"), "")
                        objDadosProducaoResumoAmbienteCorte.DT_COLHEITA_ATU = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("DT_COLHEITA_ATU"), "")
                        objDadosProducaoResumoAmbienteCorte.IDADE = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("IDADE"), 0)
                        objDadosProducaoResumoAmbienteCorte.PERC_BROCA = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("PERC_BROCA"), 0)
                        objDadosProducaoResumoAmbienteCorte.PERC_PERDA = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("PERC_PERDA"), 0)
                        objDadosProducaoResumoAmbienteCorte.TCH = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("TCH"), 0)
                        objDadosProducaoResumoAmbienteCorte.TON_HA_PLAN = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("TON_HA_PLAN"), 0)
                        objDadosProducaoResumoAmbienteCorte.TON_HA_REAL = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorte.Item("TON_HA_REAL"), 0)

                        ProducaoResumoAmbienteCorte.Add(objDadosProducaoResumoAmbienteCorte)
                    Loop

                    drDadosProducaoResumoAmbienteCorte.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosProducaoResumoAmbienteCorte) Is Nothing) Then
                    drDadosProducaoResumoAmbienteCorte.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return ProducaoResumoAmbienteCorte

    End Function

    Private Function GetProducaoResumoAmbienteCorte(ByVal parAmbiente As String, ByRef parResumoAmbienteCorte As List(Of S5TProducaoResumoAmbienteCorte)) As List(Of S5TProducaoResumoAmbienteCorte)
        'OVERLOAD
        Return parResumoAmbienteCorte.FindAll(Function(x) x.AMBIENTE = parAmbiente)
    End Function

    Private Function GetProducaoResumoAmbienteCorteTalhao(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer) As List(Of S5TProducaoResumoAmbienteCorteTalhao)
        Dim ProducaoResumoAmbienteCorteTalhao As New List(Of S5TProducaoResumoAmbienteCorteTalhao)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosProducaoResumoAmbienteCorteTalhao As New OracleCommand("SELECT HP.AMBIENTE, HP.CORTE, HP.TALHAO, NVL(SUM(HP.AREA_LIBERADA), 0) AREA_COLHIDA, MAX(HP.DT_PLANTIO) DT_PLANTIO, MAX(HP.DT_COLHEITA_ANT) DT_COLHEITA_ANT, MAX(HP.DT_COLHEITA_ATU) DT_COLHEITA_ATU, ROUND(DECODE(NVL(SUM(HP.TONELADA), 0), 0, 0, (NVL(SUM(HP.IDADE * HP.AREA_LIBERADA), 0) / SUM(HP.AREA_LIBERADA))), 2) IDADE, ROUND(DECODE(NVL(SUM(HP.TONELADA_BROCA), 0), 0, NULL, (NVL(SUM(HP.PERC_BROCA * HP.TONELADA_BROCA), 0) / SUM(HP.TONELADA_BROCA))), 3) PERC_BROCA, ROUND(DECODE(NVL(SUM(HP.AREA_PERDA), 0), 0, NULL, (NVL(SUM(HP.PERC_PERDA), 0) / SUM(HP.AREA_PERDA))), 3) PERC_PERDA, ROUND(DECODE(NVL(SUM(HP.TONELADA), 0), 0, 0, (NVL(SUM(HP.TCH * HP.TONELADA), 0) / SUM(HP.TONELADA))), 3) TCH, ROUND(DECODE(NVL(SUM(HP.AREA_TOTAL), 0), 0, 0, (NVL(SUM(HP.RENDIMENTO_PLAN * HP.AREA_TOTAL), 0) / SUM(HP.AREA_TOTAL))), 3) TON_HA_PLAN, ROUND(DECODE(NVL(SUM(HP.AREA_LIBERADA), 0), 0, 0, NVL(SUM(HP.TONELADA), 0) / SUM(HP.AREA_LIBERADA)), 3) TON_HA_REAL FROM BI4T.HISTORICO_PROPRIEDADE HP WHERE HP.ID_NEGOCIOS = 1 AND HP.SAFRA = :p0 AND HP.COD_PROPRIEDADE = :p1 GROUP BY HP.AMBIENTE, HP.CORTE, HP.TALHAO ORDER BY HP.AMBIENTE, HP.CORTE, HP.TALHAO", conn) With {.CommandType = CommandType.Text}
            cmdDadosProducaoResumoAmbienteCorteTalhao.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosProducaoResumoAmbienteCorteTalhao.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosProducaoResumoAmbienteCorteTalhao As OracleDataReader = Nothing
            Try
                drDadosProducaoResumoAmbienteCorteTalhao = cmdDadosProducaoResumoAmbienteCorteTalhao.ExecuteReader()
                If drDadosProducaoResumoAmbienteCorteTalhao.HasRows Then
                    Do While drDadosProducaoResumoAmbienteCorteTalhao.Read
                        Dim objDadosProducaoResumoAmbienteCorteTalhao = New S5TProducaoResumoAmbienteCorteTalhao

                        objDadosProducaoResumoAmbienteCorteTalhao.AMBIENTE = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("AMBIENTE"), "")
                        objDadosProducaoResumoAmbienteCorteTalhao.CORTE = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("CORTE"), 0)
                        objDadosProducaoResumoAmbienteCorteTalhao.TALHAO = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("TALHAO"), 0)
                        objDadosProducaoResumoAmbienteCorteTalhao.AREA_COLHIDA = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("AREA_COLHIDA"), 0)
                        objDadosProducaoResumoAmbienteCorteTalhao.DT_PLANTIO = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("DT_PLANTIO"), "")
                        objDadosProducaoResumoAmbienteCorteTalhao.DT_COLHEITA_ANT = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("DT_COLHEITA_ANT"), "")
                        objDadosProducaoResumoAmbienteCorteTalhao.DT_COLHEITA_ATU = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("DT_COLHEITA_ATU"), "")
                        objDadosProducaoResumoAmbienteCorteTalhao.IDADE = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("IDADE"), 0)
                        objDadosProducaoResumoAmbienteCorteTalhao.PERC_BROCA = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("PERC_BROCA"), 0)
                        objDadosProducaoResumoAmbienteCorteTalhao.PERC_PERDA = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("PERC_PERDA"), 0)
                        objDadosProducaoResumoAmbienteCorteTalhao.TCH = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("TCH"), 0)
                        objDadosProducaoResumoAmbienteCorteTalhao.TON_HA_PLAN = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("TON_HA_PLAN"), 0)
                        objDadosProducaoResumoAmbienteCorteTalhao.TON_HA_REAL = AppUtils.Nvl(drDadosProducaoResumoAmbienteCorteTalhao.Item("TON_HA_REAL"), 0)

                        ProducaoResumoAmbienteCorteTalhao.Add(objDadosProducaoResumoAmbienteCorteTalhao)
                    Loop

                    drDadosProducaoResumoAmbienteCorteTalhao.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosProducaoResumoAmbienteCorteTalhao) Is Nothing) Then
                    drDadosProducaoResumoAmbienteCorteTalhao.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return ProducaoResumoAmbienteCorteTalhao

    End Function

    Private Function GetProducaoResumoAmbienteCorteTalhao(ByVal parAmbiente As String, ByVal parCorte As Integer, ByRef parResumoAmbienteCorteTalhao As List(Of S5TProducaoResumoAmbienteCorteTalhao)) As List(Of S5TProducaoResumoAmbienteCorteTalhao)
        'OVERLOAD
        Return parResumoAmbienteCorteTalhao.FindAll(Function(x) x.AMBIENTE = parAmbiente And x.CORTE = parCorte)
    End Function


    Private Function GetTratosCulturais(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer) As List(Of S5TTratosCulturais)
        Dim TratosCulturais As New List(Of S5TTratosCulturais)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosTratosCulturais As New OracleCommand("SELECT YY.COD_GRUPO ID_GRUPO, YY.DSC_GRUPO DS_GRUPO, YY.ATIVIDADE, YY.DSC_ATIVIDADE, YY.GRUPO_SUBGRUPO_AGR, CASE WHEN (YY.NRO_APLIC_0 > 100) THEN 100 ELSE YY.NRO_APLIC_0 END AS NRO_APLIC_0, CASE WHEN (YY.NRO_APLIC_1 > 100) THEN 100 ELSE YY.NRO_APLIC_1 END AS NRO_APLIC_1, CASE WHEN (YY.NRO_APLIC_2 > 100) THEN 100 ELSE YY.NRO_APLIC_2 END AS NRO_APLIC_2, CASE WHEN (YY.NRO_APLIC_3 > 100) THEN 100 ELSE YY.NRO_APLIC_3 END AS NRO_APLIC_3, CASE WHEN (YY.NRO_APLIC_4 > 100) THEN 100 ELSE YY.NRO_APLIC_4 END AS NRO_APLIC_4, CASE WHEN (YY.NRO_APLIC_5 > 100) THEN 100 ELSE YY.NRO_APLIC_5 END AS NRO_APLIC_5, CASE WHEN (YY.NRO_APLIC_6 > 100) THEN 100 ELSE YY.NRO_APLIC_6 END AS NRO_APLIC_6, CASE WHEN (YY.NRO_APLIC_7 > 100) THEN 100 ELSE YY.NRO_APLIC_7 END AS NRO_APLIC_7, CASE WHEN (YY.NRO_APLIC_8 > 100) THEN 100 ELSE YY.NRO_APLIC_8 END AS NRO_APLIC_8, CASE WHEN (YY.NRO_APLIC_9 > 100) THEN 100 ELSE YY.NRO_APLIC_9 END AS NRO_APLIC_9, CASE WHEN (YY.NRO_APLIC_10 > 100) THEN 100 ELSE YY.NRO_APLIC_10 END AS NRO_APLIC_10 FROM (SELECT AA.COD_GRUPO, AA.DSC_GRUPO, AA.ATIVIDADE, AA.DSC_ATIVIDADE, MAX(AA.GRUPO_SUBGRUPO_AGR) GRUPO_SUBGRUPO_AGR, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 0) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_0, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 1) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_1, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 2) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_2, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 3) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_3, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 4) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_4, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 5) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_5, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 6) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_6, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 7) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_7, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 8) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_8, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 9) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_9, ROUND(SUM(CASE WHEN (AA.NRO_APLIC =10) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_10 FROM (SELECT XX.COD_GRUPO, XX.DSC_GRUPO, XX.ATIVIDADE, XX.DSC_ATIVIDADE, XX.GRUPO_SUBGRUPO_AGR, XX.NRO_APLIC, XX.AREA_TOTAL_DISP, SUM(XX.AREA_TOTAL_APLIC) AREA_TOTAL_APLIC FROM (SELECT DISTINCT A.TALHAO, C.ID_GRUPO_ATIN COD_GRUPO, D.DS_GRUPO_ATIN DSC_GRUPO, A.ATIVIDADE, A.DSC_ATIVIDADE, MAX(NVL(A.NRO_APLICACAO, 0)) NRO_APLIC, A.GRUPO_SUBGRUPO_AGR, MAX(DECODE(B.ATIN_MUDA, 'S', A.AREA_TOTAL_MUDA, A.AREA_TOTAL_DISP)) AREA_TOTAL_DISP, MAX(DECODE(B.ATIN_MUDA, 'S', A.AREA_TALHAO_MUDA, A.AREA_TALHAO_DIS)) AREA_TOTAL_APLIC FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A, SISAGRI.ATIVIDADE_INSUMO B, SISAGRI.ATIVIDADE_INSUMO_GRUPO_DET C, SISAGRI.ATIVIDADE_INSUMO_GRUPO D WHERE A.ATIVIDADE = B.ATIN_CODIGO AND A.ID_NEGOCIOS = C.ID_NEGOCIOS AND A.ATIVIDADE = C.ATIN_CODIGO AND C.ID_GRUPO_ATIN = D.ID_GRUPO_ATIN AND C.ID_PROCESSO = 5 AND A.ID_NEGOCIOS = 1 AND A.SAFRA = :p0 AND A.COD_PROPRIEDADE = :p1 GROUP BY A.TALHAO, C.ID_GRUPO_ATIN, D.DS_GRUPO_ATIN, A.ATIVIDADE, A.DSC_ATIVIDADE, A.GRUPO_SUBGRUPO_AGR) XX WHERE 1 = 1 GROUP BY XX.COD_GRUPO, XX.DSC_GRUPO, XX.ATIVIDADE, XX.DSC_ATIVIDADE, XX.GRUPO_SUBGRUPO_AGR, XX.NRO_APLIC, XX.AREA_TOTAL_DISP) AA WHERE 1 = 1 GROUP BY AA.COD_GRUPO, AA.DSC_GRUPO, AA.ATIVIDADE, AA.DSC_ATIVIDADE) YY ORDER BY YY.ATIVIDADE", conn) With {.CommandType = CommandType.Text}
            cmdDadosTratosCulturais.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosTratosCulturais.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosTratosCulturais As OracleDataReader = Nothing
            Try
                drDadosTratosCulturais = cmdDadosTratosCulturais.ExecuteReader()
                If drDadosTratosCulturais.HasRows Then
                    Do While drDadosTratosCulturais.Read
                        Dim objDadosTratosCulturais = New S5TTratosCulturais

                        objDadosTratosCulturais.ID_GRUPO = AppUtils.Nvl(drDadosTratosCulturais.Item("ID_GRUPO"), 0)
                        objDadosTratosCulturais.DS_GRUPO = AppUtils.Nvl(drDadosTratosCulturais.Item("DS_GRUPO"), "")
                        objDadosTratosCulturais.ATIVIDADE = AppUtils.Nvl(drDadosTratosCulturais.Item("ATIVIDADE"), 0)
                        objDadosTratosCulturais.DSC_ATIVIDADE = AppUtils.Nvl(drDadosTratosCulturais.Item("DSC_ATIVIDADE"), "")
                        objDadosTratosCulturais.NRO_APLIC_0 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_0"), 0)
                        objDadosTratosCulturais.NRO_APLIC_1 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_1"), 0)
                        objDadosTratosCulturais.NRO_APLIC_2 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_2"), 0)
                        objDadosTratosCulturais.NRO_APLIC_3 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_3"), 0)
                        objDadosTratosCulturais.NRO_APLIC_4 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_4"), 0)
                        objDadosTratosCulturais.NRO_APLIC_5 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_5"), 0)
                        objDadosTratosCulturais.NRO_APLIC_6 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_6"), 0)
                        objDadosTratosCulturais.NRO_APLIC_7 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_7"), 0)
                        objDadosTratosCulturais.NRO_APLIC_8 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_8"), 0)
                        objDadosTratosCulturais.NRO_APLIC_9 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_9"), 0)
                        objDadosTratosCulturais.NRO_APLIC_10 = AppUtils.Nvl(drDadosTratosCulturais.Item("NRO_APLIC_10"), 0)

                        TratosCulturais.Add(objDadosTratosCulturais)
                    Loop

                    drDadosTratosCulturais.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosTratosCulturais) Is Nothing) Then
                    drDadosTratosCulturais.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return TratosCulturais
    End Function

    Private Function GetTratosCulturaisTalhoes(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer) As List(Of S5TTratosCulturaisTalhao)
        Dim TratosCulturaisTalhao As New List(Of S5TTratosCulturaisTalhao)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosTratosCulturaisTalhao As New OracleCommand("SELECT AA.TALHAO, AA.AREA_TALHAO_DIS, AA.ATIVIDADE, CASE WHEN (AA.NRO_APLIC = 0) THEN 'X' ELSE NULL END AS NRO_APLIC_0, CASE WHEN (AA.NRO_APLIC = 1) THEN 'X' ELSE NULL END AS NRO_APLIC_1, CASE WHEN (AA.NRO_APLIC = 2) THEN 'X' ELSE NULL END AS NRO_APLIC_2, CASE WHEN (AA.NRO_APLIC = 3) THEN 'X' ELSE NULL END AS NRO_APLIC_3, CASE WHEN (AA.NRO_APLIC = 4) THEN 'X' ELSE NULL END AS NRO_APLIC_4, CASE WHEN (AA.NRO_APLIC = 5) THEN 'X' ELSE NULL END AS NRO_APLIC_5, CASE WHEN (AA.NRO_APLIC = 6) THEN 'X' ELSE NULL END AS NRO_APLIC_6, CASE WHEN (AA.NRO_APLIC = 7) THEN 'X' ELSE NULL END AS NRO_APLIC_7, CASE WHEN (AA.NRO_APLIC = 8) THEN 'X' ELSE NULL END AS NRO_APLIC_8, CASE WHEN (AA.NRO_APLIC = 9) THEN 'X' ELSE NULL END AS NRO_APLIC_9, CASE WHEN (AA.NRO_APLIC = 10) THEN 'X' ELSE NULL END AS NRO_APLIC_10 FROM (SELECT DISTINCT A.TALHAO, MAX(A.AREA_TALHAO_DIS) AREA_TALHAO_DIS, A.ATIVIDADE, A.DSC_ATIVIDADE, MAX(NVL(A.NRO_APLICACAO, 0)) NRO_APLIC, MAX(DECODE(B.ATIN_MUDA, 'S', A.AREA_TOTAL_MUDA, A.AREA_TOTAL_DISP)) AREA_TOTAL_DISP, MAX(DECODE(B.ATIN_MUDA, 'S', A.AREA_TALHAO_MUDA, A.AREA_TALHAO_DIS)) AREA_TOTAL_APLIC FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A, SISAGRI.ATIVIDADE_INSUMO B WHERE A.ATIVIDADE = B.ATIN_CODIGO AND A.ID_NEGOCIOS = 1 AND A.SAFRA = :p0 AND A.COD_PROPRIEDADE = :p1 GROUP BY A.TALHAO, A.ATIVIDADE, A.DSC_ATIVIDADE) AA ORDER BY AA.TALHAO", conn) With {.CommandType = CommandType.Text}
            cmdDadosTratosCulturaisTalhao.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosTratosCulturaisTalhao.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosTratosCulturaisTalhao As OracleDataReader = Nothing
            Try
                drDadosTratosCulturaisTalhao = cmdDadosTratosCulturaisTalhao.ExecuteReader()
                If drDadosTratosCulturaisTalhao.HasRows Then
                    Do While drDadosTratosCulturaisTalhao.Read
                        Dim objDadosTratosCulturaisTalhao = New S5TTratosCulturaisTalhao

                        objDadosTratosCulturaisTalhao.TALHAO = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("TALHAO"), 0)
                        objDadosTratosCulturaisTalhao.AREA_TALHAO_DIS = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("AREA_TALHAO_DIS"), 0)
                        objDadosTratosCulturaisTalhao.ATIVIDADE = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("ATIVIDADE"), 0)
                        objDadosTratosCulturaisTalhao.NRO_APLIC_0 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_0"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_1 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_1"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_2 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_2"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_3 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_3"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_4 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_4"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_5 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_5"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_6 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_6"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_7 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_7"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_8 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_8"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_9 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_9"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_10 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_10"), "")

                        TratosCulturaisTalhao.Add(objDadosTratosCulturaisTalhao)
                    Loop

                    drDadosTratosCulturaisTalhao.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosTratosCulturaisTalhao) Is Nothing) Then
                    drDadosTratosCulturaisTalhao.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return TratosCulturaisTalhao
    End Function

    Private Function GetTratosCulturaisTalhoes(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer, ByVal parAtividade As Integer) As List(Of S5TTratosCulturaisTalhao)
        Dim TratosCulturaisTalhao As New List(Of S5TTratosCulturaisTalhao)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosTratosCulturaisTalhao As New OracleCommand("SELECT AA.TALHAO, AA.AREA_TALHAO_DIS, AA.ATIVIDADE, CASE WHEN (AA.NRO_APLIC = 0) THEN 'X' ELSE NULL END AS NRO_APLIC_0, CASE WHEN (AA.NRO_APLIC = 1) THEN 'X' ELSE NULL END AS NRO_APLIC_1, CASE WHEN (AA.NRO_APLIC = 2) THEN 'X' ELSE NULL END AS NRO_APLIC_2, CASE WHEN (AA.NRO_APLIC = 3) THEN 'X' ELSE NULL END AS NRO_APLIC_3, CASE WHEN (AA.NRO_APLIC = 4) THEN 'X' ELSE NULL END AS NRO_APLIC_4, CASE WHEN (AA.NRO_APLIC = 5) THEN 'X' ELSE NULL END AS NRO_APLIC_5, CASE WHEN (AA.NRO_APLIC = 6) THEN 'X' ELSE NULL END AS NRO_APLIC_6, CASE WHEN (AA.NRO_APLIC = 7) THEN 'X' ELSE NULL END AS NRO_APLIC_7, CASE WHEN (AA.NRO_APLIC = 8) THEN 'X' ELSE NULL END AS NRO_APLIC_8, CASE WHEN (AA.NRO_APLIC = 9) THEN 'X' ELSE NULL END AS NRO_APLIC_9, CASE WHEN (AA.NRO_APLIC = 10) THEN 'X' ELSE NULL END AS NRO_APLIC_10 FROM (SELECT DISTINCT A.TALHAO, MAX(A.AREA_TALHAO_DIS) AREA_TALHAO_DIS, A.ATIVIDADE, A.DSC_ATIVIDADE, MAX(NVL(A.NRO_APLICACAO, 0)) NRO_APLIC, MAX(DECODE(B.ATIN_MUDA, 'S', A.AREA_TOTAL_MUDA, A.AREA_TOTAL_DISP)) AREA_TOTAL_DISP, MAX(DECODE(B.ATIN_MUDA, 'S', A.AREA_TALHAO_MUDA, A.AREA_TALHAO_DIS)) AREA_TOTAL_APLIC FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A, SISAGRI.ATIVIDADE_INSUMO B WHERE A.ATIVIDADE = B.ATIN_CODIGO AND A.ID_NEGOCIOS = 1 AND A.SAFRA = :p0 AND A.COD_PROPRIEDADE = :p1 AND A.ATIVIDADE = :p2 GROUP BY A.TALHAO, A.ATIVIDADE, A.DSC_ATIVIDADE) AA ORDER BY AA.TALHAO ", conn) With {.CommandType = CommandType.Text}
            cmdDadosTratosCulturaisTalhao.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosTratosCulturaisTalhao.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade
            cmdDadosTratosCulturaisTalhao.Parameters.Add(":p2", OracleDbType.Int16).Value = parAtividade

            Dim drDadosTratosCulturaisTalhao As OracleDataReader = Nothing
            Try
                drDadosTratosCulturaisTalhao = cmdDadosTratosCulturaisTalhao.ExecuteReader()
                If drDadosTratosCulturaisTalhao.HasRows Then
                    Do While drDadosTratosCulturaisTalhao.Read
                        Dim objDadosTratosCulturaisTalhao = New S5TTratosCulturaisTalhao

                        objDadosTratosCulturaisTalhao.TALHAO = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("TALHAO"), 0)
                        objDadosTratosCulturaisTalhao.AREA_TALHAO_DIS = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("AREA_TALHAO_DIS"), 0)
                        objDadosTratosCulturaisTalhao.ATIVIDADE = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("ATIVIDADE"), 0)
                        objDadosTratosCulturaisTalhao.NRO_APLIC_0 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_0"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_1 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_1"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_2 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_2"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_3 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_3"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_4 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_4"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_5 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_5"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_6 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_6"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_7 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_7"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_8 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_8"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_9 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_9"), "")
                        objDadosTratosCulturaisTalhao.NRO_APLIC_10 = AppUtils.Nvl(drDadosTratosCulturaisTalhao.Item("NRO_APLIC_10"), "")

                        TratosCulturaisTalhao.Add(objDadosTratosCulturaisTalhao)
                    Loop

                    drDadosTratosCulturaisTalhao.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosTratosCulturaisTalhao) Is Nothing) Then
                    drDadosTratosCulturaisTalhao.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return TratosCulturaisTalhao
    End Function

    Private Function GetTratosCulturaisTalhoesDatasAplicacao(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer) As List(Of S5TTratosCulturaisDataAplicacao)
        Dim TratosCulturaisTalhaoDataAplicacao As New List(Of S5TTratosCulturaisDataAplicacao)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosTratosCulturaisTalhaoDataAplicacao As New OracleCommand("SELECT XX.ATIVIDADE, XX.TALHAO, XX.AREA_APLICADA, XX.DATA_APLICACAO, TRUNC(XX.DATA_APLICACAO - NVL(XX.PROX_APLICACAO, XX.COLHEITA_ANT)) DIAS, XX.PRODUTO_DOSAGEM FROM (SELECT DISTINCT A.ATIVIDADE, A.TALHAO, A.AREA_TALHAO_DIS AREA_APLICADA, A.DATA_APLICACAO, A.COLHEITA_ANT, LAG(A.DATA_APLICACAO, 1) OVER(PARTITION BY A.TALHAO, A.ATIVIDADE ORDER BY A.TALHAO, A.ATIVIDADE, A.DATA_APLICACAO) PROX_APLICACAO, A.PRODUTO_DOSAGEM FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A, SISAGRI.ATIVIDADE_INSUMO B WHERE A.ATIVIDADE = B.ATIN_CODIGO AND A.ID_NEGOCIOS = 1 AND A.SAFRA = :p0 AND A.COD_PROPRIEDADE = :p1 AND A.DATA_APLICACAO IS NOT NULL ORDER BY A.TALHAO, A.ATIVIDADE, A.DATA_APLICACAO) XX", conn) With {.CommandType = CommandType.Text}
            cmdDadosTratosCulturaisTalhaoDataAplicacao.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosTratosCulturaisTalhaoDataAplicacao.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosTratosCulturaisTalhaoDataAplicacao As OracleDataReader = Nothing
            Try
                drDadosTratosCulturaisTalhaoDataAplicacao = cmdDadosTratosCulturaisTalhaoDataAplicacao.ExecuteReader()
                If drDadosTratosCulturaisTalhaoDataAplicacao.HasRows Then
                    Do While drDadosTratosCulturaisTalhaoDataAplicacao.Read
                        Dim objDadosTratosCulturaisTalhaoDataAplicacao = New S5TTratosCulturaisDataAplicacao

                        objDadosTratosCulturaisTalhaoDataAplicacao.ATIVIDADE = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("ATIVIDADE"), 0)
                        objDadosTratosCulturaisTalhaoDataAplicacao.TALHAO = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("TALHAO"), 0)
                        objDadosTratosCulturaisTalhaoDataAplicacao.AREA_APLICADA = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("AREA_APLICADA"), 0)
                        objDadosTratosCulturaisTalhaoDataAplicacao.DATA_APLICACAO = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("DATA_APLICACAO"), DateTime.MinValue).ToUniversalTime()
                        objDadosTratosCulturaisTalhaoDataAplicacao.DIAS = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("DIAS"), 0)
                        objDadosTratosCulturaisTalhaoDataAplicacao.PRODUTO_DOSAGEM = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("PRODUTO_DOSAGEM"), "")

                        TratosCulturaisTalhaoDataAplicacao.Add(objDadosTratosCulturaisTalhaoDataAplicacao)
                    Loop

                    drDadosTratosCulturaisTalhaoDataAplicacao.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosTratosCulturaisTalhaoDataAplicacao) Is Nothing) Then
                    drDadosTratosCulturaisTalhaoDataAplicacao.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return TratosCulturaisTalhaoDataAplicacao
    End Function

    Private Function GetTratosCulturaisTalhoesDatasAplicacao(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer, ByVal parAtividade As Integer) As List(Of S5TTratosCulturaisDataAplicacao)
        Dim TratosCulturaisTalhaoDataAplicacao As New List(Of S5TTratosCulturaisDataAplicacao)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosTratosCulturaisTalhaoDataAplicacao As New OracleCommand("SELECT XX.ATIVIDADE, XX.TALHAO, XX.AREA_APLICADA, XX.DATA_APLICACAO, TRUNC(XX.DATA_APLICACAO - NVL(XX.PROX_APLICACAO, XX.COLHEITA_ANT)) DIAS, XX.PRODUTO_DOSAGEM FROM (SELECT DISTINCT A.ATIVIDADE, A.TALHAO, A.AREA_TALHAO_DIS AREA_APLICADA, A.DATA_APLICACAO, A.COLHEITA_ANT, LAG(A.DATA_APLICACAO, 1) OVER(PARTITION BY A.TALHAO, A.ATIVIDADE ORDER BY A.TALHAO, A.ATIVIDADE, A.DATA_APLICACAO) PROX_APLICACAO, A.PRODUTO_DOSAGEM FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A, SISAGRI.ATIVIDADE_INSUMO B WHERE A.ATIVIDADE = B.ATIN_CODIGO AND A.ID_NEGOCIOS = 1 AND A.SAFRA = :p0 AND A.COD_PROPRIEDADE = :p1 AND A.ATIVIDADE = :p2 AND A.DATA_APLICACAO IS NOT NULL ORDER BY A.TALHAO, A.ATIVIDADE, A.DATA_APLICACAO) XX", conn) With {.CommandType = CommandType.Text}
            cmdDadosTratosCulturaisTalhaoDataAplicacao.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosTratosCulturaisTalhaoDataAplicacao.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade
            cmdDadosTratosCulturaisTalhaoDataAplicacao.Parameters.Add(":p2", OracleDbType.Int16).Value = parAtividade

            Dim drDadosTratosCulturaisTalhaoDataAplicacao As OracleDataReader = Nothing
            Try
                drDadosTratosCulturaisTalhaoDataAplicacao = cmdDadosTratosCulturaisTalhaoDataAplicacao.ExecuteReader()
                If drDadosTratosCulturaisTalhaoDataAplicacao.HasRows Then
                    Do While drDadosTratosCulturaisTalhaoDataAplicacao.Read
                        Dim objDadosTratosCulturaisTalhaoDataAplicacao = New S5TTratosCulturaisDataAplicacao

                        objDadosTratosCulturaisTalhaoDataAplicacao.ATIVIDADE = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("ATIVIDADE"), 0)
                        objDadosTratosCulturaisTalhaoDataAplicacao.TALHAO = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("TALHAO"), 0)
                        objDadosTratosCulturaisTalhaoDataAplicacao.AREA_APLICADA = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("AREA_APLICADA"), 0)
                        objDadosTratosCulturaisTalhaoDataAplicacao.DATA_APLICACAO = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("DATA_APLICACAO"), DateTime.MinValue).ToUniversalTime()
                        objDadosTratosCulturaisTalhaoDataAplicacao.DIAS = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("DIAS"), 0)
                        objDadosTratosCulturaisTalhaoDataAplicacao.PRODUTO_DOSAGEM = AppUtils.Nvl(drDadosTratosCulturaisTalhaoDataAplicacao.Item("PRODUTO_DOSAGEM"), "")

                        TratosCulturaisTalhaoDataAplicacao.Add(objDadosTratosCulturaisTalhaoDataAplicacao)
                    Loop

                    drDadosTratosCulturaisTalhaoDataAplicacao.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosTratosCulturaisTalhaoDataAplicacao) Is Nothing) Then
                    drDadosTratosCulturaisTalhaoDataAplicacao.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
            'Dim S5TUamVDadosTalhoes = S5TUam.V_DADOS_TALHAOCollection.LoadByCOD_PROPRIEDADE(SAFRA, COD_PROPRIEDADE)

            'VDadosTalhoes = S5TUamVDadosTalhoes.Select(Function(x) New S5TVDadosTalhao With {.ID_NEGOCIOS = x.ID_NEGOCIOS, _
            '                                                                                 .SAFRA = x.SAFRA, _
            '                                                                                 .COD_PROPRIEDADE = x.COD_PROPRIEDADE, _
            '                                                                                 .DSC_PROPRIEDADE = x.DSC_PROPRIEDADE, _
            '                                                                                 .TALHAO = x.TALHAO, _
            '                                                                                 .CORTE = x.CORTE, _
            '                                                                                 .AMBIENTE = x.AMBIENTE, _
            '                                                                                 .VARIEDADE = x.VARIEDADE, _
            '                                                                                 .MATURACAO = x.MATURACAO, _
            '                                                                                 .AREA_TOTAL = Math.Round(x.AREA_TOTAL, 2)}).ToList
        End If

        Return TratosCulturaisTalhaoDataAplicacao
    End Function

    Private Function GetTratosCulturaisTalhoes(ByVal parAtividade As Integer, ByRef parTratosCulturaisTalhoes As List(Of S5TTratosCulturaisTalhao))
        'OVERLOAD
        Return parTratosCulturaisTalhoes.FindAll(Function(x) x.ATIVIDADE = parAtividade)
    End Function

    Private Function GetTratosCulturaisTalhoesDatasAplicacao(ByVal parAtividade As Integer, ByVal parTalhao As Integer, ByRef parTratosCulturaisTalhoesDatasAplicacao As List(Of S5TTratosCulturaisDataAplicacao))
        'OVERLOAD
        Return parTratosCulturaisTalhoesDatasAplicacao.FindAll(Function(x) x.ATIVIDADE = parAtividade And x.TALHAO = parTalhao)
    End Function

    Private Function GetNaoConformidades(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer) As List(Of S5TNaoConformidade)
        Dim NaoConformidades As New List(Of S5TNaoConformidade)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosNaoConformidade As New OracleCommand("SELECT A.SAFRA, A.COD_PROP, A.DSC_PROP, A.TALHOES_AFETADOS, A.COD_OCORR, A.DSC_OCORR, A.DT_OCORR, A.CONSIDERACOES, A.AREA_AFETADA, A.AREA_TOTAL FROM BI4T.V_BI_NAO_CONFORMIDADE_AGR A WHERE A.ID_NEGOCIOS = 1 AND A.SAFRA = :p0 AND A.COD_PROP = :p1", conn) With {.CommandType = CommandType.Text}
            cmdDadosNaoConformidade.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosNaoConformidade.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosNaoConformidade As OracleDataReader = Nothing
            Try
                drDadosNaoConformidade = cmdDadosNaoConformidade.ExecuteReader()
                If drDadosNaoConformidade.HasRows Then
                    Do While drDadosNaoConformidade.Read
                        Dim objDadosNaoConformidade = New S5TNaoConformidade

                        objDadosNaoConformidade.TALHOES_AFETADOS = AppUtils.Nvl(drDadosNaoConformidade.Item("TALHOES_AFETADOS"), "")
                        objDadosNaoConformidade.COD_OCORR = AppUtils.Nvl(drDadosNaoConformidade.Item("COD_OCORR"), 0)
                        objDadosNaoConformidade.DSC_OCORR = AppUtils.Nvl(drDadosNaoConformidade.Item("DSC_OCORR"), "")
                        objDadosNaoConformidade.DT_OCORR = AppUtils.Nvl(drDadosNaoConformidade.Item("DT_OCORR"), DateTime.MinValue).ToUniversalTime()
                        objDadosNaoConformidade.CONSIDERACOES = AppUtils.Nvl(drDadosNaoConformidade.Item("CONSIDERACOES"), "")
                        objDadosNaoConformidade.AREA_AFETADA = AppUtils.Nvl(drDadosNaoConformidade.Item("AREA_AFETADA"), 0)
                        objDadosNaoConformidade.AREA_TOTAL = AppUtils.Nvl(drDadosNaoConformidade.Item("AREA_TOTAL"), 0)

                        NaoConformidades.Add(objDadosNaoConformidade)
                    Loop

                    drDadosNaoConformidade.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosNaoConformidade) Is Nothing) Then
                    drDadosNaoConformidade.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
        End If

        Return NaoConformidades
    End Function

    Private Enum tipoNaoConformidade
        naoConformidade
        diagnosticoColheita
    End Enum

    Private Function GetNaoConformidades(parNaoConformidades As List(Of S5TNaoConformidade), parTipo As tipoNaoConformidade) As List(Of S5TNaoConformidade)
        'OVERLOAD
        Dim NaoConformidades As New List(Of S5TNaoConformidade)

        If parTipo = tipoNaoConformidade.naoConformidade Then
            NaoConformidades = parNaoConformidades.FindAll(Function(x) x.COD_OCORR <> 782)
        ElseIf parTipo = tipoNaoConformidade.diagnosticoColheita Then
            NaoConformidades = parNaoConformidades.FindAll(Function(x) x.COD_OCORR = 782)
        End If

        Return NaoConformidades
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
