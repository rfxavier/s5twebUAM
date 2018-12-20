Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization

<RoutePrefix("api/GerencialControlePraga")>
Public Class GerencialControlePragaController
    Inherits ApiController

    <DataContract>
    Private Class S5TControlePraga
        <DataMember>
        Public Property TIPO As String
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
        <DataMember>
        Public Property oTalhoes As List(Of S5TControlePragaAplicacaoTalhao)
    End Class

    <DataContract>
    Private Class S5TControlePragaTalhao
        Implements ICloneable
        Public Property TIPO As String
        <DataMember>
        Public Property TALHAO As Integer
        <DataMember>
        Public Property AREA_APLICADA As Double
        <DataMember>
        Public Property DATA_APLICACAO As Date
        <DataMember>
        Public Property DIAS As Integer
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class



    <DataContract>
    Private Class S5TControlePragaAplicacaoTalhao
        Implements ICloneable
        Public Property TIPO As String
        <DataMember>
        Public Property TALHAO As Integer
        <DataMember>
        Public Property REFORMA As String
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
        Public Property oDatasAplicacao As List(Of S5TControlePragaAplicacaoData)
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class

    <DataContract>
    Private Class S5TControlePragaAplicacaoData
        Implements ICloneable
        Public Property TIPO As String
        Public Property TALHAO As Integer
        <DataMember>
        Public Property AREA_APLICADA As Double
        <DataMember>
        Public Property DATA_LEVANTAMENTO As Date
        <DataMember>
        Public Property PERIODO_RECOM As String
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




    ' GET api/GerencialControlePraga
    Public Function GetValues() As IHttpActionResult

        Return NotFound()

    End Function
    ' GET api/GerencialControlePraga/2015
    Public Function GetValues(ByVal SAFRA As Integer) As IHttpActionResult

        Return NotFound()
    End Function
    ' GET api/GerencialControlePraga/2015/22
    <HttpGet>
    <Route("{SAFRA}/{COD_PROPRIEDADE}")>
    Public Function GetValue(ByVal SAFRA As Integer, ByVal COD_PROPRIEDADE As Integer) As IHttpActionResult
        Return NotFound()
    End Function

    ' GET api/GerencialControlePraga/2016/22/Broca
    <HttpGet>
    <Route("{SAFRA}/{COD_PROPRIEDADE}/Broca")>
    Public Function GetValueBroca(ByVal SAFRA As Integer, ByVal COD_PROPRIEDADE As Integer) As IHttpActionResult
        Dim ControlePraga As New List(Of S5TControlePraga)

        Dim ControlePragaTalhoes As New List(Of S5TControlePragaAplicacaoTalhao)

        Dim ControlePragaTalhaoDatas As New List(Of S5TControlePragaAplicacaoData)

        'CONTROLE DE PRAGAS
        Dim ControlePragasBase = GetControlePragas(SAFRA, COD_PROPRIEDADE, tipoPraga.Brocas)
        Dim ControlePragaAplicacaoTalhoesBase = GetControlePragaAplicacaoTalhoes(SAFRA, COD_PROPRIEDADE, tipoPraga.Brocas)
        Dim ControlePragaAplicacaoTalhaoDatasBase = GetControlePragaAplicacaoDatas(SAFRA, COD_PROPRIEDADE, tipoPraga.Brocas)

        PreencheControlePragaTalhoes(ControlePraga, ControlePragaTalhoes, ControlePragaTalhaoDatas, ControlePragasBase, ControlePragaAplicacaoTalhoesBase, ControlePragaAplicacaoTalhaoDatasBase)

        Return Ok(ControlePraga)
    End Function


    ' GET api/GerencialControlePraga/2016/22/Cigarrinha
    <HttpGet>
    <Route("{SAFRA}/{COD_PROPRIEDADE}/Cigarrinha")>
    Public Function GetValueCigarrinha(ByVal SAFRA As Integer, ByVal COD_PROPRIEDADE As Integer) As IHttpActionResult
        Dim ControlePraga As New List(Of S5TControlePraga)

        Dim ControlePragaTalhoes As New List(Of S5TControlePragaAplicacaoTalhao)

        Dim ControlePragaTalhaoDatas As New List(Of S5TControlePragaAplicacaoData)

        'CONTROLE DE PRAGAS
        Dim ControlePragasBase = GetControlePragas(SAFRA, COD_PROPRIEDADE, tipoPraga.Cigarrinha)
        Dim ControlePragaAplicacaoTalhoesBase = GetControlePragaAplicacaoTalhoes(SAFRA, COD_PROPRIEDADE, tipoPraga.Cigarrinha)
        Dim ControlePragaAplicacaoTalhaoDatasBase = GetControlePragaAplicacaoDatas(SAFRA, COD_PROPRIEDADE, tipoPraga.Cigarrinha)

        PreencheControlePragaTalhoes(ControlePraga, ControlePragaTalhoes, ControlePragaTalhaoDatas, ControlePragasBase, ControlePragaAplicacaoTalhoesBase, ControlePragaAplicacaoTalhaoDatasBase)

        Return Ok(ControlePraga)
    End Function


    ' GET api/GerencialControlePraga/2016/22/Sphenophorus
    <HttpGet>
    <Route("{SAFRA}/{COD_PROPRIEDADE}/Sphenophorus")>
    Public Function GetValueSphenophorus(ByVal SAFRA As Integer, ByVal COD_PROPRIEDADE As Integer) As IHttpActionResult
        Dim ControlePraga As New List(Of S5TControlePraga)

        Dim ControlePragaTalhoes As New List(Of S5TControlePragaAplicacaoTalhao)

        Dim ControlePragaTalhaoDatas As New List(Of S5TControlePragaAplicacaoData)

        'CONTROLE DE PRAGAS
        Dim ControlePragasBase = GetControlePragas(SAFRA, COD_PROPRIEDADE, tipoPraga.Sphenophorus)
        Dim ControlePragaAplicacaoTalhoesBase = GetControlePragaAplicacaoTalhoes(SAFRA, COD_PROPRIEDADE, tipoPraga.Sphenophorus)
        Dim ControlePragaAplicacaoTalhaoDatasBase = GetControlePragaAplicacaoDatas(SAFRA, COD_PROPRIEDADE, tipoPraga.Sphenophorus)

        PreencheControlePragaTalhoes(ControlePraga, ControlePragaTalhoes, ControlePragaTalhaoDatas, ControlePragasBase, ControlePragaAplicacaoTalhoesBase, ControlePragaAplicacaoTalhaoDatasBase)

        Return Ok(ControlePraga)
    End Function

    Private Sub PreencheControlePragaTalhoes(ByRef parControlePraga As List(Of S5TControlePraga), _
                                              ByRef parControlePragaAplicacaoTalhoes As List(Of S5TControlePragaAplicacaoTalhao), _
                                              ByRef parControlePragaAplicacaoDatas As List(Of S5TControlePragaAplicacaoData), _
                                              ByRef parControlePragasBase As List(Of S5TControlePraga), _
                                              ByRef parControlePragaAplicacaoTalhoesBase As List(Of S5TControlePragaAplicacaoTalhao), _
                                              ByRef parControlePragaAplicacaoDatasBase As List(Of S5TControlePragaAplicacaoData))

        Dim ControlePragaAplicacaoTalhoesClone As New List(Of S5TControlePragaAplicacaoTalhao)

        Dim ControlePragaAplicacaoTalhaoData As New List(Of S5TControlePragaAplicacaoData)
        Dim ControlePragaAplicacaoTalhaoDataClone As New List(Of S5TControlePragaAplicacaoData)

        'NÍVEL 1
        For Each objControlePragasBase In parControlePragasBase
            parControlePragaAplicacaoTalhoes.Clear()
            parControlePragaAplicacaoTalhoes = GetControlePragaAplicacaoTalhoes(objControlePragasBase.TIPO, parControlePragaAplicacaoTalhoesBase)
            ControlePragaAplicacaoTalhoesClone = parControlePragaAplicacaoTalhoes.Select(Function(x) x.Clone()).Cast(Of S5TControlePragaAplicacaoTalhao).ToList


            'NÍVEL 2
            Dim ControlePragaTalhoesDatasAplicacoes As New List(Of S5TControlePragaAplicacaoTalhao)

            For Each objControlePragaAplicacaoTalhoesClone In ControlePragaAplicacaoTalhoesClone
                ControlePragaAplicacaoTalhaoData.Clear()
                ControlePragaAplicacaoTalhaoData = GetControlePragaAplicacaoDatas(objControlePragaAplicacaoTalhoesClone.TIPO, objControlePragaAplicacaoTalhoesClone.TALHAO, parControlePragaAplicacaoDatasBase)
                ControlePragaAplicacaoTalhaoDataClone = ControlePragaAplicacaoTalhaoData.Select(Function(x) x.Clone()).Cast(Of S5TControlePragaAplicacaoData).ToList

                ControlePragaTalhoesDatasAplicacoes.Add(New S5TControlePragaAplicacaoTalhao With {.TIPO = objControlePragaAplicacaoTalhoesClone.TIPO, _
                                                                                                  .TALHAO = objControlePragaAplicacaoTalhoesClone.TALHAO, _
                                                                                                  .REFORMA = objControlePragaAplicacaoTalhoesClone.REFORMA, _
                                                                                                  .AREA_TALHAO_DIS = objControlePragaAplicacaoTalhoesClone.AREA_TALHAO_DIS, _
                                                                                                  .NRO_APLIC_0 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_0, _
                                                                                                  .NRO_APLIC_1 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_1, _
                                                                                                  .NRO_APLIC_2 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_2, _
                                                                                                  .NRO_APLIC_3 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_3, _
                                                                                                  .NRO_APLIC_4 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_4, _
                                                                                                  .NRO_APLIC_5 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_5, _
                                                                                                  .NRO_APLIC_6 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_6, _
                                                                                                  .NRO_APLIC_7 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_7, _
                                                                                                  .NRO_APLIC_8 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_8, _
                                                                                                  .NRO_APLIC_9 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_9, _
                                                                                                  .NRO_APLIC_10 = objControlePragaAplicacaoTalhoesClone.NRO_APLIC_10, _
                                                                                                  .oDatasAplicacao = ControlePragaAplicacaoTalhaoDataClone})
            Next

            parControlePraga.Add(New S5TControlePraga With {.TIPO = objControlePragasBase.TIPO, _
                                                         .NRO_APLIC_0 = objControlePragasBase.NRO_APLIC_0, _
                                                         .NRO_APLIC_1 = objControlePragasBase.NRO_APLIC_1, _
                                                         .NRO_APLIC_2 = objControlePragasBase.NRO_APLIC_2, _
                                                         .NRO_APLIC_3 = objControlePragasBase.NRO_APLIC_3, _
                                                         .NRO_APLIC_4 = objControlePragasBase.NRO_APLIC_4, _
                                                         .NRO_APLIC_5 = objControlePragasBase.NRO_APLIC_5, _
                                                         .NRO_APLIC_6 = objControlePragasBase.NRO_APLIC_6, _
                                                         .NRO_APLIC_7 = objControlePragasBase.NRO_APLIC_7, _
                                                         .NRO_APLIC_8 = objControlePragasBase.NRO_APLIC_8, _
                                                         .NRO_APLIC_9 = objControlePragasBase.NRO_APLIC_9, _
                                                         .NRO_APLIC_10 = objControlePragasBase.NRO_APLIC_10, _
                                                         .oTalhoes = ControlePragaTalhoesDatasAplicacoes})
        Next
    End Sub


    Private Enum tipoPraga
        Brocas
        Cigarrinha
        Sphenophorus
    End Enum

    Private Function AtividadeListaCodigos(ByVal parTipoPraga As tipoPraga) As String
        Dim strAtividadeListaCodigos As String = String.Empty

        If parTipoPraga = tipoPraga.Brocas Then
            strAtividadeListaCodigos = "20, 26"
        ElseIf parTipoPraga = tipoPraga.Cigarrinha Then
            strAtividadeListaCodigos = "51, 55"
        ElseIf parTipoPraga = tipoPraga.Sphenophorus Then
            strAtividadeListaCodigos = "25"
        End If

        Return strAtividadeListaCodigos
    End Function


    Private Function GetControlePragas(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer, ByVal parTipoPraga As tipoPraga) As List(Of S5TControlePraga)
        Dim ControlePraga As New List(Of S5TControlePraga)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosControlePraga As New OracleCommand(String.Format("SELECT YY.TIPO, CASE WHEN (YY.NRO_APLIC_0 > 100) THEN 100 ELSE YY.NRO_APLIC_0 END AS NRO_APLIC_0, CASE WHEN (YY.NRO_APLIC_1 > 100) THEN 100 ELSE YY.NRO_APLIC_1 END AS NRO_APLIC_1, CASE WHEN (YY.NRO_APLIC_2 > 100) THEN 100 ELSE YY.NRO_APLIC_2 END AS NRO_APLIC_2, CASE WHEN (YY.NRO_APLIC_3 > 100) THEN 100 ELSE YY.NRO_APLIC_3 END AS NRO_APLIC_3, CASE WHEN (YY.NRO_APLIC_4 > 100) THEN 100 ELSE YY.NRO_APLIC_4 END AS NRO_APLIC_4, CASE WHEN (YY.NRO_APLIC_5 > 100) THEN 100 ELSE YY.NRO_APLIC_5 END AS NRO_APLIC_5, CASE WHEN (YY.NRO_APLIC_6 > 100) THEN 100 ELSE YY.NRO_APLIC_6 END AS NRO_APLIC_6, CASE WHEN (YY.NRO_APLIC_7 > 100) THEN 100 ELSE YY.NRO_APLIC_7 END AS NRO_APLIC_7, CASE WHEN (YY.NRO_APLIC_8 > 100) THEN 100 ELSE YY.NRO_APLIC_8 END AS NRO_APLIC_8, CASE WHEN (YY.NRO_APLIC_9 > 100) THEN 100 ELSE YY.NRO_APLIC_9 END AS NRO_APLIC_9, CASE WHEN (YY.NRO_APLIC_10 > 100) THEN 100 ELSE YY.NRO_APLIC_10 END AS NRO_APLIC_10 FROM (SELECT CASE WHEN (AA.ATIVIDADE = 26) THEN 'Broca Química' WHEN (AA.ATIVIDADE = 20) THEN 'Broca Biológica' WHEN (AA.ATIVIDADE = 27) THEN 'Broca Química - Mudas' WHEN (AA.ATIVIDADE = 38) THEN 'Broca Biológica - Mudas' WHEN (AA.ATIVIDADE = 55) THEN 'Cigarr. Química' WHEN (AA.ATIVIDADE = 56) THEN 'Cigarr. Química - Mudas' WHEN (AA.ATIVIDADE = 51) THEN 'Cigarr. Biológica' WHEN (AA.ATIVIDADE = 57) THEN 'Cigarr. Biológica - Mudas' WHEN (AA.ATIVIDADE = 25) THEN 'Sphenophorus' WHEN (AA.ATIVIDADE = 938) THEN 'Sphenophorus - Mudas' ELSE 'Outros' END TIPO, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 0) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_0, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 1) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_1, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 2) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_2, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 3) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_3, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 4) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_4, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 5) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_5, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 6) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_6, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 7) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_7, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 8) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_8, ROUND(SUM(CASE WHEN (AA.NRO_APLIC = 9) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_9, ROUND(SUM(CASE WHEN (AA.NRO_APLIC =10) THEN (DECODE(NVL(AA.AREA_TOTAL_DISP, 0), 0, 0, (AA.AREA_TOTAL_APLIC / AA.AREA_TOTAL_DISP)) * 100) ELSE 0 END), 2) AS NRO_APLIC_10 FROM (SELECT XX.ATIVIDADE, XX.DSC_ATIVIDADE, XX.NRO_APLIC, XX.AREA_TOTAL_DISP, SUM(XX.AREA_TOTAL_APLIC) AREA_TOTAL_APLIC FROM (SELECT DISTINCT A.TALHAO, A.ATIVIDADE, A.DSC_ATIVIDADE, MAX(NVL(A.NRO_APLICACAO, 0)) NRO_APLIC, MAX(DECODE(B.ATIN_MUDA, 'S', A.AREA_TOTAL_MUDA, A.AREA_TOTAL_DISP)) AREA_TOTAL_DISP, MAX(CASE WHEN ((NVL(A.NRO_APLICACAO, 0) = 0) AND (NVL(B.ATIN_MUDA, 'N') = 'S')) THEN A.AREA_TALHAO_MUDA WHEN ((NVL(A.NRO_APLICACAO, 0) = 0) AND (NVL(B.ATIN_MUDA, 'N') = 'N')) THEN A.AREA_TALHAO_DIS WHEN ((NVL(A.NRO_APLICACAO, 0) > 0)) THEN A.AREA_TALHAO_APLIC ELSE 0 END) AS AREA_TOTAL_APLIC FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A, SISAGRI.ATIVIDADE_INSUMO B WHERE A.ATIVIDADE = B.ATIN_CODIGO AND A.ATIVIDADE IN ({0}) AND A.ID_NEGOCIOS = 1 AND A.SAFRA = :p0 AND A.COD_PROPRIEDADE = :p1 GROUP BY A.TALHAO, A.ATIVIDADE, A.DSC_ATIVIDADE) XX WHERE 1 = 1 GROUP BY XX.ATIVIDADE, XX.DSC_ATIVIDADE, XX.NRO_APLIC, XX.AREA_TOTAL_DISP) AA WHERE 1 = 1 GROUP BY CASE WHEN (AA.ATIVIDADE = 26) THEN 'Broca Química' WHEN (AA.ATIVIDADE = 20) THEN 'Broca Biológica' WHEN (AA.ATIVIDADE = 27) THEN 'Broca Química - Mudas' WHEN (AA.ATIVIDADE = 38) THEN 'Broca Biológica - Mudas' WHEN (AA.ATIVIDADE = 55) THEN 'Cigarr. Química' WHEN (AA.ATIVIDADE = 56) THEN 'Cigarr. Química - Mudas' WHEN (AA.ATIVIDADE = 51) THEN 'Cigarr. Biológica' WHEN (AA.ATIVIDADE = 57) THEN 'Cigarr. Biológica - Mudas' WHEN (AA.ATIVIDADE = 25) THEN 'Sphenophorus' WHEN (AA.ATIVIDADE = 938) THEN 'Sphenophorus - Mudas' ELSE 'Outros' END) YY ORDER BY 1 ", AtividadeListaCodigos(parTipoPraga)), conn) With {.CommandType = CommandType.Text}
            cmdDadosControlePraga.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosControlePraga.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosControlePraga As OracleDataReader = Nothing
            Try
                drDadosControlePraga = cmdDadosControlePraga.ExecuteReader()
                If drDadosControlePraga.HasRows Then
                    Do While drDadosControlePraga.Read
                        Dim objDadosControlePraga = New S5TControlePraga

                        objDadosControlePraga.TIPO = AppUtils.Nvl(drDadosControlePraga.Item("TIPO"), "")
                        objDadosControlePraga.NRO_APLIC_0 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_0"), 0)
                        objDadosControlePraga.NRO_APLIC_1 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_1"), 0)
                        objDadosControlePraga.NRO_APLIC_2 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_2"), 0)
                        objDadosControlePraga.NRO_APLIC_3 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_3"), 0)
                        objDadosControlePraga.NRO_APLIC_4 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_4"), 0)
                        objDadosControlePraga.NRO_APLIC_5 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_5"), 0)
                        objDadosControlePraga.NRO_APLIC_6 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_6"), 0)
                        objDadosControlePraga.NRO_APLIC_7 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_7"), 0)
                        objDadosControlePraga.NRO_APLIC_8 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_8"), 0)
                        objDadosControlePraga.NRO_APLIC_9 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_9"), 0)
                        objDadosControlePraga.NRO_APLIC_10 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_10"), 0)

                        ControlePraga.Add(objDadosControlePraga)
                    Loop

                    drDadosControlePraga.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosControlePraga) Is Nothing) Then
                    drDadosControlePraga.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
        End If

        Return ControlePraga
    End Function

    Private Function GetControlePragaAplicacaoTalhoes(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer, ByVal parTipoPraga As tipoPraga) As List(Of S5TControlePragaAplicacaoTalhao)
        Dim ControlePraga As New List(Of S5TControlePragaAplicacaoTalhao)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosControlePraga As New OracleCommand(String.Format("SELECT AA.TIPO, AA.TALHAO, AA.REFORMA, AA.AREA_TALHAO_DIS, CASE WHEN (AA.NRO_APLIC = 0) THEN 'X' ELSE NULL END AS NRO_APLIC_0, CASE WHEN (AA.NRO_APLIC = 1) THEN 'X' ELSE NULL END AS NRO_APLIC_1, CASE WHEN (AA.NRO_APLIC = 2) THEN 'X' ELSE NULL END AS NRO_APLIC_2, CASE WHEN (AA.NRO_APLIC = 3) THEN 'X' ELSE NULL END AS NRO_APLIC_3, CASE WHEN (AA.NRO_APLIC = 4) THEN 'X' ELSE NULL END AS NRO_APLIC_4, CASE WHEN (AA.NRO_APLIC = 5) THEN 'X' ELSE NULL END AS NRO_APLIC_5, CASE WHEN (AA.NRO_APLIC = 6) THEN 'X' ELSE NULL END AS NRO_APLIC_6, CASE WHEN (AA.NRO_APLIC = 7) THEN 'X' ELSE NULL END AS NRO_APLIC_7, CASE WHEN (AA.NRO_APLIC = 8) THEN 'X' ELSE NULL END AS NRO_APLIC_8, CASE WHEN (AA.NRO_APLIC = 9) THEN 'X' ELSE NULL END AS NRO_APLIC_9, CASE WHEN (AA.NRO_APLIC = 10) THEN 'X' ELSE NULL END AS NRO_APLIC_10 FROM (SELECT DISTINCT A.TALHAO, MAX(A.AREA_TALHAO_DIS) AREA_TALHAO_DIS, A.REFORMA, CASE WHEN (A.ATIVIDADE IN (26, 27)) THEN 'Broca Química' WHEN (A.ATIVIDADE IN (20, 38)) THEN 'Broca Biológica' WHEN (A.ATIVIDADE IN (55, 56)) THEN 'Cigarr. Química' WHEN (A.ATIVIDADE IN (51, 57)) THEN 'Cigarr. Biológica' WHEN (A.ATIVIDADE IN (25, 938)) THEN 'Sphenophorus' ELSE 'Outros' END AS TIPO, MAX(NVL(A.NRO_APLICACAO, 0)) NRO_APLIC, MAX(DECODE(B.ATIN_MUDA, 'S', A.AREA_TOTAL_MUDA, A.AREA_TOTAL_DISP)) AREA_TOTAL_DISP, MAX(DECODE(B.ATIN_MUDA, 'S', A.AREA_TALHAO_MUDA, A.AREA_TALHAO_DIS)) AREA_TOTAL_APLIC FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A, SISAGRI.ATIVIDADE_INSUMO B WHERE A.ATIVIDADE = B.ATIN_CODIGO AND A.ID_NEGOCIOS = 1 AND A.SAFRA = :p0 AND A.COD_PROPRIEDADE = :p1 AND A.ATIVIDADE IN ({0}) GROUP BY A.TALHAO, A.REFORMA, CASE WHEN (A.ATIVIDADE IN (26, 27)) THEN 'Broca Química' WHEN (A.ATIVIDADE IN (20, 38)) THEN 'Broca Biológica' WHEN (A.ATIVIDADE IN (55, 56)) THEN 'Cigarr. Química' WHEN (A.ATIVIDADE IN (51, 57)) THEN 'Cigarr. Biológica' WHEN (A.ATIVIDADE IN (25, 938)) THEN 'Sphenophorus' ELSE 'Outros' END) AA ORDER BY AA.TALHAO", AtividadeListaCodigos(parTipoPraga)), conn) With {.CommandType = CommandType.Text}
            cmdDadosControlePraga.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdDadosControlePraga.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosControlePraga As OracleDataReader = Nothing
            Try
                drDadosControlePraga = cmdDadosControlePraga.ExecuteReader()
                If drDadosControlePraga.HasRows Then
                    Do While drDadosControlePraga.Read
                        Dim objDadosControlePraga = New S5TControlePragaAplicacaoTalhao

                        objDadosControlePraga.TIPO = AppUtils.Nvl(drDadosControlePraga.Item("TIPO"), "")
                        objDadosControlePraga.TALHAO = AppUtils.Nvl(drDadosControlePraga.Item("TALHAO"), 0)
                        objDadosControlePraga.REFORMA = AppUtils.Nvl(drDadosControlePraga.Item("REFORMA"), "")
                        objDadosControlePraga.AREA_TALHAO_DIS = AppUtils.Nvl(drDadosControlePraga.Item("AREA_TALHAO_DIS"), 0)
                        objDadosControlePraga.NRO_APLIC_0 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_0"), "")
                        objDadosControlePraga.NRO_APLIC_1 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_1"), "")
                        objDadosControlePraga.NRO_APLIC_2 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_2"), "")
                        objDadosControlePraga.NRO_APLIC_3 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_3"), "")
                        objDadosControlePraga.NRO_APLIC_4 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_4"), "")
                        objDadosControlePraga.NRO_APLIC_5 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_5"), "")
                        objDadosControlePraga.NRO_APLIC_6 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_6"), "")
                        objDadosControlePraga.NRO_APLIC_7 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_7"), "")
                        objDadosControlePraga.NRO_APLIC_8 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_8"), "")
                        objDadosControlePraga.NRO_APLIC_9 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_9"), "")
                        objDadosControlePraga.NRO_APLIC_10 = AppUtils.Nvl(drDadosControlePraga.Item("NRO_APLIC_10"), "")

                        ControlePraga.Add(objDadosControlePraga)
                    Loop

                    drDadosControlePraga.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosControlePraga) Is Nothing) Then
                    drDadosControlePraga.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
        End If

        Return ControlePraga

    End Function

    Private Function GetControlePragaAplicacaoDatas(ByVal parSafra As Integer, ByVal parCodigoPropriedade As Integer, ByVal parTipoPraga As tipoPraga) As List(Of S5TControlePragaAplicacaoData)
        Dim ControlePragaTalhoes As New List(Of S5TControlePragaAplicacaoData)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosControlePragaTalhao As New OracleCommand(String.Format("SELECT AA.* FROM (SELECT CASE WHEN (XX.ATIVIDADE IN (26, 27)) THEN 'Broca Química' WHEN (XX.ATIVIDADE IN (20, 38)) THEN 'Broca Biológica' WHEN (XX.ATIVIDADE IN (55, 56)) THEN 'Cigarr. Química' WHEN (XX.ATIVIDADE IN (51, 57)) THEN 'Cigarr. Biológica' WHEN (XX.ATIVIDADE IN (25, 938)) THEN 'Sphenophorus' ELSE 'Outros' END TIPO, XX.TALHAO, XX.AREA_APLICADA, XX.DATA_LEVANTAMENTO, XX.PERIODO_RECOM, XX.DATA_APLICACAO, TRUNC(XX.DATA_APLICACAO - NVL(XX.PROX_APLICACAO, XX.COLHEITA_ANT)) DIAS, XX.PRODUTO_DOSAGEM FROM (SELECT DISTINCT A.TALHAO, A.ATIVIDADE, DECODE(NVL(B.ATIN_MUDA, 'N'), 'S', A.AREA_TALHAO_MUDA, A.AREA_TALHAO_DIS) AREA_APLICADA, A.DATA_LEVANTAMENTO, A.PERIODO_RECOM, A.DATA_APLICACAO, A.COLHEITA_ANT, LAG(A.DATA_APLICACAO, 1) OVER(PARTITION BY A.TALHAO, A.ATIVIDADE ORDER BY A.TALHAO, A.ATIVIDADE, A.DATA_APLICACAO) PROX_APLICACAO, A.PRODUTO_DOSAGEM FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A, SISAGRI.ATIVIDADE_INSUMO B WHERE A.ATIVIDADE = B.ATIN_CODIGO AND A.ATIVIDADE IN ({0}) AND A.ID_NEGOCIOS = 1 AND A.SAFRA = {1} AND A.COD_PROPRIEDADE = {2} ORDER BY A.TALHAO, A.ATIVIDADE, NVL(A.DATA_LEVANTAMENTO,A.DATA_APLICACAO)) XX) AA", AtividadeListaCodigos(parTipoPraga), parSafra, parCodigoPropriedade), conn) With {.CommandType = CommandType.Text}
            'cmdDadosControlePragaTalhao.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            'cmdDadosControlePragaTalhao.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodigoPropriedade

            Dim drDadosControlePragaTalhao As OracleDataReader = Nothing
            Try
                drDadosControlePragaTalhao = cmdDadosControlePragaTalhao.ExecuteReader()
                If drDadosControlePragaTalhao.HasRows Then
                    Do While drDadosControlePragaTalhao.Read
                        Dim objDadosControlePragaTalhao = New S5TControlePragaAplicacaoData

                        objDadosControlePragaTalhao.TIPO = AppUtils.Nvl(drDadosControlePragaTalhao.Item("TIPO"), "")
                        objDadosControlePragaTalhao.TALHAO = AppUtils.Nvl(drDadosControlePragaTalhao.Item("TALHAO"), 0)
                        objDadosControlePragaTalhao.AREA_APLICADA = Math.Round(AppUtils.Nvl(drDadosControlePragaTalhao.Item("AREA_APLICADA"), 0), 2)
                        objDadosControlePragaTalhao.DATA_LEVANTAMENTO = AppUtils.Nvl(drDadosControlePragaTalhao.Item("DATA_LEVANTAMENTO"), DateTime.MinValue).ToUniversalTime()
                        objDadosControlePragaTalhao.PERIODO_RECOM = AppUtils.Nvl(drDadosControlePragaTalhao.Item("PERIODO_RECOM"), "")
                        objDadosControlePragaTalhao.DATA_APLICACAO = AppUtils.Nvl(drDadosControlePragaTalhao.Item("DATA_APLICACAO"), DateTime.MinValue).ToUniversalTime()
                        objDadosControlePragaTalhao.DIAS = AppUtils.Nvl(drDadosControlePragaTalhao.Item("DIAS"), 0)
                        objDadosControlePragaTalhao.PRODUTO_DOSAGEM = AppUtils.Nvl(drDadosControlePragaTalhao.Item("PRODUTO_DOSAGEM"), "")

                        ControlePragaTalhoes.Add(objDadosControlePragaTalhao)
                    Loop

                    drDadosControlePragaTalhao.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drDadosControlePragaTalhao) Is Nothing) Then
                    drDadosControlePragaTalhao.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'NOT IMPLEMENTED
        End If

        Return ControlePragaTalhoes


    End Function


    Private Function GetControlePragaAplicacaoTalhoes(ByVal parTIPO As String, ByRef parControlePragaAplicacaoTalhoes As List(Of S5TControlePragaAplicacaoTalhao))
        'OVERLOAD
        Return parControlePragaAplicacaoTalhoes.FindAll(Function(x) x.TIPO = parTIPO)
    End Function

    Private Function GetControlePragaAplicacaoDatas(ByVal parTIPO As String, ByVal parTALHAO As Integer, ByRef parControlePragaAplicacaoDatas As List(Of S5TControlePragaAplicacaoData))
        'OVERLOAD
        Return parControlePragaAplicacaoDatas.FindAll(Function(x) x.TIPO = parTIPO And x.TALHAO = parTALHAO)
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
