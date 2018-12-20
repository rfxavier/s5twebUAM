Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization

<RoutePrefix("api/PropriedadePraga")>
Public Class PropriedadePragaController
    Inherits ApiController

    <DataContract>
    Private Class S5TPropriedadePraga
        <DataMember>
        Public Property COD_PROPRIEDADE As Integer
        Public Property STATUS As String
        <DataMember>
        Public Property PERC_INFEST_SF_ANT As String
    End Class


    'GET api/PropriedadePraga/2015/Broca
    <HttpGet>
    <Route("{SAFRA}/Broca")>
    Public Function GetValuesBroca(ByVal SAFRA As Integer) As IHttpActionResult

        Dim ControlePraga As New List(Of S5TPropriedadePraga)

        'CONTROLE DE PRAGAS
        Dim ControlePragasBase = GetPropriedadePragas(SAFRA, tipoPraga.Brocas).FindAll(Function(x) x.STATUS = "S")

        Return Ok(ControlePragasBase)

    End Function

    'GET api/PropriedadePraga/2015/Cigarrinha
    <HttpGet>
    <Route("{SAFRA}/Cigarrinha")>
    Public Function GetValuesCigarrinha(ByVal SAFRA As Integer) As IHttpActionResult

        Dim ControlePraga As New List(Of S5TPropriedadePraga)

        'CONTROLE DE PRAGAS
        Dim ControlePragasBase = GetPropriedadePragas(SAFRA, tipoPraga.Cigarrinha).FindAll(Function(x) x.STATUS = "S")

        Return Ok(ControlePragasBase)

    End Function

    'GET api/PropriedadePraga/2015/Sphenophorus
    <HttpGet>
    <Route("{SAFRA}/Sphenophorus")>
    Public Function GetValuesSphenophorus(ByVal SAFRA As Integer) As IHttpActionResult

        Dim ControlePraga As New List(Of S5TPropriedadePraga)

        'CONTROLE DE PRAGAS
        Dim ControlePragasBase = GetPropriedadePragas(SAFRA, tipoPraga.Sphenophorus).FindAll(Function(x) x.STATUS = "S")

        Return Ok(ControlePragasBase)

    End Function

    Private Function GetPropriedadePragas(ByVal parSafra As Integer, ByVal parTipoPraga As tipoPraga) As List(Of S5TPropriedadePraga)
        Dim ControlePraga As New List(Of S5TPropriedadePraga)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdDadosControlePraga As OracleCommand = Nothing

            If parTipoPraga = tipoPraga.Brocas Then
                cmdDadosControlePraga = New OracleCommand(String.Format("SELECT AA.COD_PROPRIEDADE, CASE WHEN (SUM(AA.QTDE_RECOM) > 0) THEN 'S' ELSE 'N' END AS STATUS, (SELECT ROUND(DECODE(NVL(SUM(HP.TONELADA_BROCA),0), 0, NULL, (NVL(SUM(HP.PERC_BROCA * HP.TONELADA_BROCA),0) / SUM(HP.TONELADA_BROCA))),2) PERC_BROCA FROM BI4T.HISTORICO_PROPRIEDADE HP WHERE HP.ID_NEGOCIOS = AA.ID_NEGOCIOS AND HP.SAFRA = AA.SAFRA - 1 AND HP.COD_PROPRIEDADE = AA.COD_PROPRIEDADE) PERC_INFEST_SF_ANT FROM (SELECT TH.ID_NEGOCIOS_PROP ID_NEGOCIOS, TH.TALH_SAFRA SAFRA, TH.TALH_CODIGO_PROP COD_PROPRIEDADE, 0 QTDE_RECOM FROM TALHAO TH WHERE TH.ID_NEGOCIOS_PROP = 1 AND TH.TALH_SAFRA = {0} UNION ALL SELECT A.ID_NEGOCIOS, A.SAFRA, A.COD_PROPRIEDADE, COUNT(DISTINCT A.NRO_RECOM) QTDE_RECOM FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A WHERE A.ID_NEGOCIOS = 1 AND A.SAFRA = {0} AND A.ATIVIDADE IN ({1}) GROUP BY A.ID_NEGOCIOS, A.SAFRA, A.COD_PROPRIEDADE) AA GROUP BY AA.ID_NEGOCIOS, AA.SAFRA, AA.COD_PROPRIEDADE", parSafra, AtividadeListaCodigos(parTipoPraga)), conn) With {.CommandType = CommandType.Text}
            ElseIf parTipoPraga = tipoPraga.Cigarrinha Then
                cmdDadosControlePraga = New OracleCommand(String.Format("SELECT AA.COD_PROPRIEDADE, CASE WHEN (SUM(AA.QTDE_RECOM) > 0) THEN 'S' ELSE 'N' END AS STATUS, MAX(AA.MEDIA_IND_HA) PERC_INFEST_SF_ANT FROM (SELECT TH.ID_NEGOCIOS_PROP ID_NEGOCIOS, TH.TALH_SAFRA SAFRA, TH.TALH_CODIGO_PROP COD_PROPRIEDADE, NULL MEDIA_IND_HA, 0 QTDE_RECOM FROM TALHAO TH WHERE TH.ID_NEGOCIOS_PROP = 1 AND TH.TALH_SAFRA = {0} UNION ALL SELECT BB.ID_NEGOCIOS, BB.SAFRA, BB.COD_PROPRIEDADE, (SELECT BI4T.F_INDICE_INFEST_CIGARRINHA(BB.ID_NEGOCIOS, BB.SAFRA, BB.COD_PROPRIEDADE, BB.COLHEITA_ANT, BB.COLHEITA_ATU) FROM DUAL) MEDIA_IND_HA, BB.QTDE_RECOM FROM (SELECT A.ID_NEGOCIOS, A.SAFRA, A.COD_PROPRIEDADE, MIN(A.COLHEITA_ANT) COLHEITA_ANT, MAX(A.COLHEITA_ATU) COLHEITA_ATU, COUNT(DISTINCT A.NRO_RECOM) QTDE_RECOM FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A WHERE A.ID_NEGOCIOS = 1 AND A.SAFRA = {0} AND A.ATIVIDADE IN ({1}) GROUP BY A.ID_NEGOCIOS, A.SAFRA, A.COD_PROPRIEDADE) BB ) AA GROUP BY AA.COD_PROPRIEDADE", parSafra, AtividadeListaCodigos(parTipoPraga)), conn) With {.CommandType = CommandType.Text}
            ElseIf parTipoPraga = tipoPraga.Sphenophorus Then
                cmdDadosControlePraga = New OracleCommand(String.Format("SELECT AA.COD_PROPRIEDADE, CASE WHEN (SUM(AA.QTDE_RECOM) > 0) THEN 'S' ELSE 'N' END AS STATUS, (SELECT ROUND(AVG(XX.PERC_SPHENOPHORUS),2) PERC_SPHENOPHORUS FROM (SELECT DISTINCT B.TALH_CODIGO_PROP COD_PROPRIEDADE, A.TALH_ID, A.DATA_LEVANTAMENTO, ROUND(A.AREA_LEVANTAMENTO,2) AREA_LEVANTAMENTO, DECODE(A.TIPO_AMOSTRAGEM, 'L', ROUND((A.QTDE_TOCO_ATACADO / A.QTDE_TOCO_TOTAL) * 100, 2), 0) PERC_SPHENOPHORUS FROM SISAGRI.INFESTACAO_SPHENOPHORUS A, SISAGRI.TALHAO B WHERE A.TALH_ID = B.TALH_ID AND B.ID_NEGOCIOS_PROP = 1 AND B.TALH_SAFRA = {0} - 1) XX WHERE XX.COD_PROPRIEDADE = AA.COD_PROPRIEDADE) PERC_INFEST_SF_ANT FROM (SELECT TH.ID_NEGOCIOS_PROP ID_NEGOCIOS, TH.TALH_SAFRA SAFRA, TH.TALH_CODIGO_PROP COD_PROPRIEDADE, 0 QTDE_RECOM FROM TALHAO TH WHERE TH.ID_NEGOCIOS_PROP = 1 AND TH.TALH_SAFRA = {0} UNION ALL SELECT A.ID_NEGOCIOS, A.SAFRA, A.COD_PROPRIEDADE, COUNT(DISTINCT A.NRO_RECOM) QTDE_RECOM FROM BI4T.HISTORICO_PROPRIEDADE_TRATOS A WHERE A.ID_NEGOCIOS = 1 AND A.SAFRA = {0} AND A.ATIVIDADE IN ({1}) GROUP BY A.ID_NEGOCIOS, A.SAFRA, A.COD_PROPRIEDADE) AA GROUP BY AA.ID_NEGOCIOS, AA.SAFRA, AA.COD_PROPRIEDADE", parSafra, AtividadeListaCodigos(parTipoPraga)), conn) With {.CommandType = CommandType.Text}
            End If
            'cmdDadosControlePraga.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra

            Dim drDadosControlePraga As OracleDataReader = Nothing
            Try
                drDadosControlePraga = cmdDadosControlePraga.ExecuteReader()
                If drDadosControlePraga.HasRows Then
                    Do While drDadosControlePraga.Read
                        Dim objDadosControlePraga = New S5TPropriedadePraga

                        objDadosControlePraga.COD_PROPRIEDADE = AppUtils.Nvl(drDadosControlePraga.Item("COD_PROPRIEDADE"), 0)
                        objDadosControlePraga.STATUS = AppUtils.Nvl(drDadosControlePraga.Item("STATUS"), "")

                        'If parTipoPraga = tipoPraga.Cigarrinha Then
                        '    objDadosControlePraga.PERC_INFEST_SF_ANT = AppUtils.Nvl(drDadosControlePraga.Item("PERC_INFEST_SF_ANT"), "Não Disponível")
                        'Else
                        '    objDadosControlePraga.PERC_INFEST_SF_ANT = AppUtils.Nvl(drDadosControlePraga.Item("PERC_INFEST_SF_ANT"), "")
                        'End If

                        If parTipoPraga = tipoPraga.Brocas Then
                            objDadosControlePraga.PERC_INFEST_SF_ANT = AppUtils.Nvl(drDadosControlePraga.Item("PERC_INFEST_SF_ANT"), "S/ Levant.")
                        Else
                            objDadosControlePraga.PERC_INFEST_SF_ANT = AppUtils.Nvl(drDadosControlePraga.Item("PERC_INFEST_SF_ANT"), "")
                        End If




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


    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

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
