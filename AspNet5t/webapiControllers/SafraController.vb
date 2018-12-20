Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization

<DataContract>
Public Class S5TSafra
    <DataMember>
    Public Property SAFRA As Integer
End Class

<RoutePrefix("api/Safras")>
Public Class SafraController
    Inherits ApiController

    ' GET api/<controller>
    <HttpGet>
    <Route("")>
    Public Function GetValues() As IHttpActionResult
        Dim Safra = New List(Of S5TSafra)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdSafra As New OracleCommand("SELECT S.SAFR_ANO SAFRA FROM SISAGRI.SAFRA S WHERE S.ID_NEGOCIOS = 1 AND S.SAFR_ANO BETWEEN EXTRACT(YEAR FROM SYSDATE) - 10 AND EXTRACT(YEAR FROM SYSDATE)+1 ORDER BY S.SAFR_ANO DESC", conn) With {.CommandType = CommandType.Text}

            Dim drSafra As OracleDataReader = Nothing
            Try
                drSafra = cmdSafra.ExecuteReader()
                If drSafra.HasRows Then
                    Do While drSafra.Read
                        Dim objSafra = New S5TSafra

                        objSafra.SAFRA = AppUtils.Nvl(drSafra.Item("SAFRA"), 0)
                        Safra.Add(objSafra)
                    Loop

                    drSafra.Close()
                End If
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drSafra) Is Nothing) Then
                    drSafra.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            Dim S5TUamSafra = S5TUam.SAFRA_ANOCollection.LoadAll

            For Each objS5TUamSafra In S5TUamSafra
                Dim objSafra = New S5TSafra

                objSafra.SAFRA = objS5TUamSafra.SAFRA

                Safra.Add(objSafra)
            Next

            ''Safra = S5TUamSafra.Select(Function(x) CriaSafra(x))
        End If


        Return Ok(Safra)
    End Function

    ' GET api/<controller>/5
    <HttpGet>
    <Route("")>
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
