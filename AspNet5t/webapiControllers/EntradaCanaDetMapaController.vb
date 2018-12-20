Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization


<RoutePrefix("api/EntradaCanaDetMapa")>
Public Class EntradaCanaDetMapaController
    Inherits ApiController

    <DataContract>
    Private Class S5TEntradaCanaDetMapa
        Public Property ID_NEGOCIOS As Integer
        Public Property NR_ANO_SAFRA As Integer
        <DataMember>
        Public Property PROP_CODIGO As Integer
        <DataMember>
        Public Property DS_NOME_PROPRIEDADE As String
        <DataMember>
        Public Property FRENTE_COLHEITATOP As String
        Public Property FRENTE_COLHEITA As String
        Public Property MUNICIPIO As Integer
        <DataMember>
        Public Property DESCMUNI As String
        <DataMember>
        Public Property QT_TON_ENTREGUE_REAL As Double
        <DataMember>
        Public Property INICIO As Date
    End Class


    ' GET api/EntradaCanaDetMapa
    <HttpGet>
    <Route("")>
    Public Function GetValues() As IHttpActionResult
        Dim EntradaCanaDets = GetEntradaCanaDetsMapa(New Date(2015, 1, 1), New Date(2015, 12, 31))

        Dim EntradaCanaDetsAgrupFrenteTop = GetEntradaCanaDetsMapaAgrupFrenteTop(EntradaCanaDets)

        Return Ok(EntradaCanaDetsAgrupFrenteTop)
    End Function

    Private Function GetEntradaCanaDetsMapa(ByVal parDataIni As Date, ByVal parDataFim As Date) As List(Of S5TEntradaCanaDetMapa)
        Dim EntradaCanaDetsMapa = New List(Of S5TEntradaCanaDetMapa)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdEntradaCanaDetMapa As New OracleCommand("select E4.ID_NEGOCIOS, E4.NR_ANO_SAFRA, E4.PROP_CODIGO, E4.DS_NOME_PROPRIEDADE, (SELECT E3.FRENTE_COLHEITA FRENTE_COLHEITA FROM BI4T.ENTRADA_CANA_DET E3 where E3.ID_NEGOCIOS = E4.ID_NEGOCIOS AND E3.NR_ANO_SAFRA = E4.NR_ANO_SAFRA AND E3.PROP_CODIGO = E4.PROP_CODIGO AND E3.DT_MOAGEM BETWEEN :parDataIni AND :parDataFim HAVING SUM(E3.QT_TON_ENTREGUE_REAL) = (SELECT MAX(QT_TON_ENTREGUE_REAL) FROM (SELECT E1.ID_NEGOCIOS, E1.NR_ANO_SAFRA, E1.PROP_CODIGO, E1.FRENTE_COLHEITA FRENTE_COLHEITA, SUM(E1.QT_TON_ENTREGUE_REAL) QT_TON_ENTREGUE_REAL FROM BI4T.ENTRADA_CANA_DET E1 WHERE E1.DT_MOAGEM BETWEEN :parDataIni AND :parDataFim GROUP BY E1.ID_NEGOCIOS, E1.NR_ANO_SAFRA, E1.PROP_CODIGO, E1.FRENTE_COLHEITA) E2 WHERE E2.ID_NEGOCIOS = E3.ID_NEGOCIOS AND E2.NR_ANO_SAFRA = E3.NR_ANO_SAFRA AND E2.PROP_CODIGO = E3.PROP_CODIGO GROUP BY E2.ID_NEGOCIOS, E2.NR_ANO_SAFRA, E2.PROP_CODIGO) GROUP BY E3.ID_NEGOCIOS, E3.NR_ANO_SAFRA, E3.PROP_CODIGO, E3.DS_NOME_PROPRIEDADE, E3.MUNICIPIO, E3.DESCMUNI, E3.FRENTE_COLHEITA ) FRENTE_COLHEITATOP, E4.FRENTE_COLHEITA, E4.MUNICIPIO, E4.DESCMUNI, SUM(E4.QT_TON_ENTREGUE_REAL) QT_TON_ENTREGUE_REAL, NVL((SELECT MIN(B.DT_ENTRADA) INICIO FROM BI4T.ENTRADA_CANA_DET B WHERE B.ID_NEGOCIOS = E4.ID_NEGOCIOS AND B.NR_ANO_SAFRA = E4.NR_ANO_SAFRA AND B.PROP_CODIGO = E4.PROP_CODIGO AND B.DT_ENTRADA >= E4.DT_ENTRADA - 40),TO_DATE('31122015','DDMMYYYY')) INICIO from BI4T.ENTRADA_CANA_DET E4 WHERE E4.DT_MOAGEM BETWEEN :parDataIni AND :parDataFim GROUP BY E4.ID_NEGOCIOS, E4.NR_ANO_SAFRA, E4.PROP_CODIGO, E4.DT_ENTRADA, E4.DS_NOME_PROPRIEDADE, E4.FRENTE_COLHEITA, E4.MUNICIPIO, E4.DESCMUNI", conn) With {.CommandType = CommandType.Text}
            cmdEntradaCanaDetMapa.Parameters.Add(":p0", OracleDbType.Date).Value = parDataIni
            cmdEntradaCanaDetMapa.Parameters.Add(":p1", OracleDbType.Date).Value = parDataFim

            Dim drEntradaCanaDetMapa As OracleDataReader = Nothing
            Try
                drEntradaCanaDetMapa = cmdEntradaCanaDetMapa.ExecuteReader()
                If drEntradaCanaDetMapa.HasRows Then
                    Do While drEntradaCanaDetMapa.Read
                        Dim objEntradaCanaDetMapa = New S5TEntradaCanaDetMapa

                        objEntradaCanaDetMapa.ID_NEGOCIOS = AppUtils.Nvl(drEntradaCanaDetMapa.Item("ID_NEGOCIOS"), 0)
                        objEntradaCanaDetMapa.NR_ANO_SAFRA = AppUtils.Nvl(drEntradaCanaDetMapa.Item("NR_ANO_SAFRA"), 0)
                        objEntradaCanaDetMapa.PROP_CODIGO = AppUtils.Nvl(drEntradaCanaDetMapa.Item("PROP_CODIGO"), 0)
                        objEntradaCanaDetMapa.DS_NOME_PROPRIEDADE = AppUtils.Nvl(drEntradaCanaDetMapa.Item("DS_NOME_PROPRIEDADE"), "")
                        objEntradaCanaDetMapa.FRENTE_COLHEITATOP = AppUtils.Nvl(drEntradaCanaDetMapa.Item("FRENTE_COLHEITATOP"), "")
                        objEntradaCanaDetMapa.FRENTE_COLHEITA = AppUtils.Nvl(drEntradaCanaDetMapa.Item("FRENTE_COLHEITA"), "")
                        objEntradaCanaDetMapa.MUNICIPIO = AppUtils.Nvl(drEntradaCanaDetMapa.Item("MUNICIPIO"), 0)
                        objEntradaCanaDetMapa.DESCMUNI = AppUtils.Nvl(drEntradaCanaDetMapa.Item("DESCMUNI"), "")
                        objEntradaCanaDetMapa.QT_TON_ENTREGUE_REAL = AppUtils.Nvl(drEntradaCanaDetMapa.Item("QT_TON_ENTREGUE_REAL"), "")
                        objEntradaCanaDetMapa.INICIO = AppUtils.Nvl(drEntradaCanaDetMapa.Item("INICIO"), DateTime.MinValue).ToUniversalTime()

                        EntradaCanaDetsMapa.Add(objEntradaCanaDetMapa)
                    Loop

                    drEntradaCanaDetMapa.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drEntradaCanaDetMapa) Is Nothing) Then
                    drEntradaCanaDetMapa.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then

        End If

        Return EntradaCanaDetsMapa
    End Function

    'Dim VDadosTalhoesAgrupadoPropriedade = parVDadosTalhoes.GroupBy(Function(x) x.COD_PROPRIEDADE).Select(Function(y) New S5TPropriedade With {.ID_NEGOCIOS = y.Min(Function(group) group.ID_NEGOCIOS), _
    '                                                                                                                                       .SAFRA = y.Min(Function(group) group.SAFRA), _
    '                                                                                                                                       .COD_PROPRIEDADE = y.Min(Function(group) group.COD_PROPRIEDADE), _
    '                                                                                                                                       .DSC_PROPRIEDADE = y.Min(Function(group) group.DSC_PROPRIEDADE)}).ToList

    Private Function GetEntradaCanaDetsMapaAgrupFrenteTop(ByRef parEntradaCanaDets As List(Of S5TEntradaCanaDetMapa)) As List(Of S5TEntradaCanaDetMapa)
        Dim EntradaCanaDetsMapaAgrupFrenteTop = parEntradaCanaDets.GroupBy(Function(x) New With {Key .ID_NEGOCIOS = x.ID_NEGOCIOS, _
                                                                                                 Key .NR_ANO_SAFRA = x.NR_ANO_SAFRA, _
                                                                                                 Key .PROP_CODIGO = x.PROP_CODIGO, _
                                                                                                 Key .DS_NOME_PROPRIEDADE = x.DS_NOME_PROPRIEDADE, _
                                                                                                 Key .FRENTE_COLHEITATOP = x.FRENTE_COLHEITATOP, _
                                                                                                 Key .MUNICIPIO = x.MUNICIPIO, _
                                                                                                 Key .DESCMUNI = x.DESCMUNI}).Select(Function(y) New S5TEntradaCanaDetMapa With {.ID_NEGOCIOS = y.Min(Function(group) group.ID_NEGOCIOS), _
                                                                                                                                                                             .NR_ANO_SAFRA = y.Min(Function(group) group.NR_ANO_SAFRA), _
                                                                                                                                                                             .PROP_CODIGO = y.Min(Function(group) group.PROP_CODIGO), _
                                                                                                                                                                             .DS_NOME_PROPRIEDADE = y.Min(Function(group) group.DS_NOME_PROPRIEDADE), _
                                                                                                                                                                             .FRENTE_COLHEITATOP = y.Min(Function(group) group.FRENTE_COLHEITATOP), _
                                                                                                                                                                             .MUNICIPIO = y.Min(Function(group) group.MUNICIPIO), _
                                                                                                                                                                             .DESCMUNI = y.Min(Function(group) group.DESCMUNI), _
                                                                                                                                                                             .INICIO = y.Min(Function(group) group.INICIO), _
                                                                                                                                                                             .QT_TON_ENTREGUE_REAL = Math.Round(y.Sum(Function(group) group.QT_TON_ENTREGUE_REAL), 2)}).ToList

        Return EntradaCanaDetsMapaAgrupFrenteTop
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
