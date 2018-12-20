Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization

<RoutePrefix("api/AcessoUsuario")>
Public Class AcessoUsuarioController
    Inherits ApiController

    Private Class S5TAcessoUsuarioResultado
        Public Property RESULTADO As String
    End Class


    ' GET api/<controller>
    Public Function GetValues() As IEnumerable(Of String)
        Return New String() {"value1", "value2"}
    End Function


    ' GET api/AcessoUsuario/COD_PROGRAMA/COD_USUARIO/ID_NEGOCIOS/V_CAMPO_AUX
    <HttpGet>
    <Route("{parCOD_PROGRAMA}/{parCOD_USUARIO}/{parID_NEGOCIOS}/{parV_CAMPO_AUX}")>
    Public Function GetValue(ByVal parCOD_PROGRAMA As Integer, ByVal parCOD_USUARIO As String, ByVal parID_NEGOCIOS As Integer, parV_CAMPO_AUX As String) As IHttpActionResult
        Dim varResultado As String = String.Empty

        If parCOD_USUARIO = "admin@4t.com.br" Then
            varResultado = "E"
        Else
            If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                Dim conn As OracleConnection = Nothing
                Dim oradbConn As String = String.Empty

                Dim oradb As String = AppUtils.dbConnectionString

                conn = New OracleConnection(oradb)
                conn.Open()

                Dim cmdDadosResultado As New OracleCommand(String.Format("SELECT APOIO.F_VERIFICA_ACESSO_CAMPOS_AUX({0},'{1}',{2},'{3}') AS RESULTADO FROM DUAL", parCOD_PROGRAMA, parCOD_USUARIO.ToUpper, parID_NEGOCIOS, parV_CAMPO_AUX), conn) With {.CommandType = CommandType.Text}

                Dim drDadosResultado As OracleDataReader = Nothing
                Try
                    drDadosResultado = cmdDadosResultado.ExecuteReader()
                    If drDadosResultado.HasRows Then
                        Do While drDadosResultado.Read
                            varResultado = AppUtils.Nvl(drDadosResultado.Item("RESULTADO"), "")
                        Loop

                        drDadosResultado.Close()
                    End If
                Catch ex As Exception
                    'Return InternalServerError(ex)
                Finally
                    conn.Close()
                    If (Not (drDadosResultado) Is Nothing) Then
                        drDadosResultado.Dispose()
                    End If
                End Try
            ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                'NOT IMPLEMENTED

            End If
        End If

        Return Ok(varResultado)
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
