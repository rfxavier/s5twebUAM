Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization

<RoutePrefix("api/SubGrupoAgricola")>
Public Class SubGrupoAgricolaController
    Inherits ApiController

    <DataContract>
    Private Class S5TSubGrupoAgricola
        <DataMember>
        Public Property ID_GRUPO As Integer
        <DataMember>
        Public Property DS_GRUPO As String
    End Class

    ' GET api/SubGrupoAgricola
    <HttpGet>
    <Route("")>
    Public Function GetValues() As IHttpActionResult
        Return Ok(GetSubGruposAgricolas)
    End Function

    ' GET api/SubGrupoAgricola/5
    Public Function GetValue(ByVal id As Integer) As IHttpActionResult
        Return NotFound()
    End Function

    Private Function GetSubGruposAgricolas() As List(Of S5TSubGrupoAgricola)
        Dim SubGruposAgricolas = New List(Of S5TSubGrupoAgricola)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdSubGrupoAgricola As New OracleCommand("SELECT DISTINCT A1.ID_GRUPO_ATIN ID_GRUPO, B1.DS_GRUPO_ATIN DS_GRUPO FROM SISAGRI.ATIVIDADE_INSUMO_GRUPO_DET A1, SISAGRI.ATIVIDADE_INSUMO_GRUPO B1 WHERE A1.ID_GRUPO_ATIN = B1.ID_GRUPO_ATIN AND A1.ID_NEGOCIOS = 1 AND A1.ID_PROCESSO = 5 ORDER BY 1", conn) With {.CommandType = CommandType.Text}

            Dim drSubGrupoAgricola As OracleDataReader = Nothing
            Try
                drSubGrupoAgricola = cmdSubGrupoAgricola.ExecuteReader()
                If drSubGrupoAgricola.HasRows Then
                    Do While drSubGrupoAgricola.Read
                        Dim objSubGrupoAgricola = New S5TSubGrupoAgricola

                        objSubGrupoAgricola.ID_GRUPO = AppUtils.Nvl(drSubGrupoAgricola.Item("ID_GRUPO"), 0)
                        objSubGrupoAgricola.DS_GRUPO = AppUtils.Nvl(drSubGrupoAgricola.Item("DS_GRUPO"), "")

                        SubGruposAgricolas.Add(objSubGrupoAgricola)
                    Loop

                    drSubGrupoAgricola.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drSubGrupoAgricola) Is Nothing) Then
                    drSubGrupoAgricola.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then

        End If

        Return SubGruposAgricolas
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
