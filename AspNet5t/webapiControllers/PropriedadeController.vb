Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization

<DataContract>
Public Class S5TPropriedadeSafra
    <DataMember>
    Public Property SAFRA As Integer
    <DataMember>
    Public Property oPropriedades As List(Of S5TPropriedadeDescricao)
End Class

<DataContract>
Public Class S5TPropriedadeDescricao
    <DataMember>
    Public Property COD_PROPRIEDADE As Integer
    <DataMember>
    Public Property DSC_PROPRIEDADE As String
    Public Property DT_ENCERRAMENTO_DATE As Date
    <DataMember>
    Public Property DT_ENCERRAMENTO As String
End Class

<RoutePrefix("api/Propriedades")>
Public Class PropriedadeController
    Inherits ApiController

    ' GET api/Propriedades
    <HttpGet>
    <Route("")>
    Public Function GetValues() As IHttpActionResult
        Return Ok(GetListPropriedadeSafra)
    End Function


    ' GET api/Propriedades/2016
    <HttpGet>
    <Route("{safra}")>
    Public Function GetValues(ByVal safra As Integer) As IHttpActionResult
        Return Ok(GetListPropriedadeDescricao(safra))
    End Function

    ' GET api/Propriedades/2016?comecacom_descricao=SITIO
    <HttpGet>
    <Route("{safra}")>
    Public Function GetValuesComecaCom(ByVal safra As Integer, ByVal comecacom_descricao As String) As IHttpActionResult
        Return Ok(GetListPropriedadeDescricao(safra, comecacom_descricao))
    End Function

    ' GET api/Propriedades/2016/22
    <HttpGet>
    <Route("{safra}/{codigo}")>
    Public Function GetValue(ByVal safra As Integer, ByVal codigo As Integer) As IHttpActionResult
        Return Ok(GetPropriedadeDescricao(safra, codigo))
    End Function


    Private Function GetListPropriedadeSafra() As List(Of S5TPropriedadeSafra)
        Dim Safras = New List(Of S5TPropriedadeSafra)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdPropriedade As New OracleCommand("SELECT DISTINCT V.SAFRA FROM BI4T.V_DADOS_TALHAO V ORDER BY V.SAFRA DESC", conn) With {.CommandType = CommandType.Text}

            Dim drPropriedade As OracleDataReader = Nothing
            Try
                drPropriedade = cmdPropriedade.ExecuteReader()
                If drPropriedade.HasRows Then
                    Do While drPropriedade.Read
                        Dim objSafra = New S5TPropriedadeSafra

                        objSafra.SAFRA = AppUtils.Nvl(drPropriedade.Item("SAFRA"), 0)
                        objSafra.oPropriedades = GetListPropriedadeDescricao(objSafra.SAFRA)

                        Safras.Add(objSafra)
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

        Return Safras
    End Function

    Private Function GetListPropriedadeDescricao(parSafra) As List(Of S5TPropriedadeDescricao)
        Dim Propriedades = New List(Of S5TPropriedadeDescricao)
        Dim Propriedades2 = New List(Of S5TPropriedadeDescricao)
        Dim PropriedadesComDataEncerramento = New List(Of S5TPropriedadeDescricao)
        Dim PropriedadesNaoEncerradas = New List(Of S5TPropriedadeDescricao)
        Dim PropriedadesUnion = New List(Of S5TPropriedadeDescricao)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdPropriedade As New OracleCommand("SELECT V.COD_PROPRIEDADE, V.DSC_PROPRIEDADE, MAX(DT_ENCERRAMENTO) DT_ENCERRAMENTO_DATE, TO_CHAR(MAX(V.DT_ENCERRAMENTO),'DD/MM/YYYY') DT_ENCERRAMENTO FROM BI4T.V_DADOS_TALHAO V WHERE V.SAFRA = :p0 AND NVL(V.LIB_COLHEITA,0) = '1' GROUP BY V.COD_PROPRIEDADE, V.DSC_PROPRIEDADE ", conn) With {.CommandType = CommandType.Text}
            cmdPropriedade.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra

            Dim cmdPropriedade2 As New OracleCommand("SELECT DISTINCT V.COD_PROPRIEDADE, V.DSC_PROPRIEDADE FROM BI4T.V_DADOS_TALHAO V WHERE V.SAFRA = :p0 AND NVL(V.LIB_COLHEITA,0) <> '1'", conn) With {.CommandType = CommandType.Text}
            cmdPropriedade2.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra

            Dim drPropriedade As OracleDataReader = Nothing

            Dim drPropriedade2 As OracleDataReader = Nothing

            Try
                drPropriedade = cmdPropriedade.ExecuteReader()
                If drPropriedade.HasRows Then
                    Do While drPropriedade.Read
                        Dim objPropriedade = New S5TPropriedadeDescricao

                        objPropriedade.COD_PROPRIEDADE = AppUtils.Nvl(drPropriedade.Item("COD_PROPRIEDADE"), 0)
                        objPropriedade.DSC_PROPRIEDADE = AppUtils.Nvl(drPropriedade.Item("DSC_PROPRIEDADE"), "")
                        objPropriedade.DT_ENCERRAMENTO_DATE = AppUtils.Nvl(drPropriedade.Item("DT_ENCERRAMENTO_DATE"), DateTime.MinValue).ToUniversalTime
                        objPropriedade.DT_ENCERRAMENTO = AppUtils.Nvl(drPropriedade.Item("DT_ENCERRAMENTO"), "")
                        Propriedades.Add(objPropriedade)
                    Loop
                End If

                drPropriedade2 = cmdPropriedade2.ExecuteReader()
                If drPropriedade2.HasRows Then
                    Do While drPropriedade2.Read
                        Dim objPropriedade2 = New S5TPropriedadeDescricao

                        objPropriedade2.COD_PROPRIEDADE = AppUtils.Nvl(drPropriedade2.Item("COD_PROPRIEDADE"), 0)
                        objPropriedade2.DSC_PROPRIEDADE = AppUtils.Nvl(drPropriedade2.Item("DSC_PROPRIEDADE"), "")
                        objPropriedade2.DT_ENCERRAMENTO_DATE = DateTime.MinValue.ToUniversalTime
                        objPropriedade2.DT_ENCERRAMENTO = ""
                        Propriedades2.Add(objPropriedade2)
                    Loop
                End If

                drPropriedade.Close()
                drPropriedade2.Close()
            Catch ex As Exception
                'Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drPropriedade) Is Nothing) Then
                    drPropriedade.Dispose()
                End If

                If (Not (drPropriedade2) Is Nothing) Then
                    drPropriedade2.Dispose()
                End If
            End Try

            PropriedadesComDataEncerramento = Propriedades.OrderByDescending(Function(x) x.DT_ENCERRAMENTO_DATE).ThenBy(Function(x) x.COD_PROPRIEDADE).ToList
            PropriedadesNaoEncerradas = Propriedades2.OrderBy(Function(x) x.COD_PROPRIEDADE).ToList

        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            Dim S5TUamPropriedade = S5TUam.PROPRIEDADESCollection.LoadBySAFRA(parSafra)

            For Each objS5TUamPropriedade In S5TUamPropriedade
                Dim objPropriedade = New S5TPropriedadeDescricao

                objPropriedade.COD_PROPRIEDADE = objS5TUamPropriedade.COD_PROPRIEDADE
                objPropriedade.DSC_PROPRIEDADE = objS5TUamPropriedade.DSC_PROPRIEDADE

                Propriedades.Add(objPropriedade)
            Next
        End If

        PropriedadesUnion.AddRange(PropriedadesComDataEncerramento)
        PropriedadesUnion.AddRange(PropriedadesNaoEncerradas)

        Return PropriedadesUnion
    End Function

    Private Function GetListPropriedadeDescricao(parSafra, parComecaComDescricao) As List(Of S5TPropriedadeDescricao)
        Dim Propriedades = New List(Of S5TPropriedadeDescricao)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdPropriedade As New OracleCommand("SELECT DISTINCT V.COD_PROPRIEDADE, V.DSC_PROPRIEDADE FROM BI4T.V_DADOS_TALHAO V WHERE V.SAFRA = :p0 AND V.DSC_PROPRIEDADE LIKE :p1 ORDER BY V.DSC_PROPRIEDADE", conn) With {.CommandType = CommandType.Text}
            cmdPropriedade.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdPropriedade.Parameters.Add(":p1", OracleDbType.Varchar2).Value = parComecaComDescricao & "%"

            Dim drPropriedade As OracleDataReader = Nothing
            Try
                drPropriedade = cmdPropriedade.ExecuteReader()
                If drPropriedade.HasRows Then
                    Do While drPropriedade.Read
                        Dim objPropriedade = New S5TPropriedadeDescricao

                        objPropriedade.COD_PROPRIEDADE = AppUtils.Nvl(drPropriedade.Item("COD_PROPRIEDADE"), 0)
                        objPropriedade.DSC_PROPRIEDADE = AppUtils.Nvl(drPropriedade.Item("DSC_PROPRIEDADE"), "")
                        Propriedades.Add(objPropriedade)
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
            Dim S5TUamPropriedade = S5TUam.PROPRIEDADESCollection.LoadByDSC_PROPRIEDADE(parSafra, parComecaComDescricao)

            For Each objS5TUamPropriedade In S5TUamPropriedade
                Dim objPropriedade = New S5TPropriedadeDescricao

                objPropriedade.COD_PROPRIEDADE = objS5TUamPropriedade.COD_PROPRIEDADE
                objPropriedade.DSC_PROPRIEDADE = objS5TUamPropriedade.DSC_PROPRIEDADE

                Propriedades.Add(objPropriedade)
            Next
        End If

        Return Propriedades
    End Function

    Private Function GetPropriedadeDescricao(parSafra As Integer, parCodPropriedade As Integer) As S5TPropriedadeDescricao
        Dim objPropriedade = New S5TPropriedadeDescricao

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdPropriedade As New OracleCommand("SELECT DISTINCT V.COD_PROPRIEDADE, V.DSC_PROPRIEDADE FROM BI4T.V_DADOS_TALHAO V WHERE V.SAFRA = :p0 AND V.COD_PROPRIEDADE = :p1", conn) With {.CommandType = CommandType.Text}
            cmdPropriedade.Parameters.Add(":p0", OracleDbType.Int16).Value = parSafra
            cmdPropriedade.Parameters.Add(":p1", OracleDbType.Int16).Value = parCodPropriedade

            Dim drPropriedade As OracleDataReader = Nothing
            Try
                drPropriedade = cmdPropriedade.ExecuteReader()
                If drPropriedade.HasRows Then
                    drPropriedade.Read()

                    objPropriedade.COD_PROPRIEDADE = AppUtils.Nvl(drPropriedade.Item("COD_PROPRIEDADE"), 0)
                    objPropriedade.DSC_PROPRIEDADE = AppUtils.Nvl(drPropriedade.Item("DSC_PROPRIEDADE"), "")

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
            Dim objS5TUamPropriedade = S5TUam.PROPRIEDADES.LoadByCOD_PROPRIEDADE(parSafra, parCodPropriedade)

            objPropriedade.COD_PROPRIEDADE = objS5TUamPropriedade.COD_PROPRIEDADE
            objPropriedade.DSC_PROPRIEDADE = objS5TUamPropriedade.DSC_PROPRIEDADE
        End If

        Return objPropriedade

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
