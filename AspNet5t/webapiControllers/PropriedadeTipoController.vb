Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization

<RoutePrefix("api/PropriedadeTipo")>
Public Class PropriedadeTipoController
    Inherits ApiController

    <DataContract>
    Private Class S5TPropriedadeTipo
        <DataMember>
        Public Property PROP_CODIGO As Integer
        Public Property TIPO_PROP As String

    End Class

    ' GET api/PropriedadeTipo
    <HttpGet>
    <Route("{TIPO}")>
    Public Function GetValues(ByVal TIPO As String) As IHttpActionResult

        Return Ok(GetListPropriedadeTipo(TIPO))
    End Function

    Private Function GetListPropriedadeTipo(ByVal parTIPO) As List(Of S5TPropriedadeTipo)
        Dim PropriedadeTipos = New List(Of S5TPropriedadeTipo)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdPropriedade As New OracleCommand("SELECT A.PROP_CODIGO, DECODE(A.PROP_CODIGO_TIPP, 4, 'F', 'P') TIPO_PROP FROM PROPRIEDADE_AGRICOLA A WHERE DECODE(A.PROP_CODIGO_TIPP, 4, 'F', 'P') = :p0 ORDER BY A.PROP_CODIGO", conn) With {.CommandType = CommandType.Text}
            cmdPropriedade.Parameters.Add(":p0", OracleDbType.Varchar2).Value = parTIPO

            Dim drPropriedade As OracleDataReader = Nothing
            Try
                drPropriedade = cmdPropriedade.ExecuteReader()
                If drPropriedade.HasRows Then
                    Do While drPropriedade.Read
                        Dim objPropriedadeTipo = New S5TPropriedadeTipo

                        objPropriedadeTipo.PROP_CODIGO = AppUtils.Nvl(drPropriedade.Item("PROP_CODIGO"), 0)
                        objPropriedadeTipo.TIPO_PROP = AppUtils.Nvl(drPropriedade.Item("TIPO_PROP"), "")

                        PropriedadeTipos.Add(objPropriedadeTipo)
                    Loop

                    drPropriedade.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drPropriedade) Is Nothing) Then
                    drPropriedade.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then

        End If

        Return PropriedadeTipos
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
