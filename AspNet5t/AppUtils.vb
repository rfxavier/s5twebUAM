Imports System
Imports System.IO
Imports System.Web
Imports Oracle.DataAccess.Client
Imports DevExpress.DataAccess.ConnectionParameters
Module AppUtils
    Public Function parseExMsg(msg As String, Optional ByVal flg As String = "") As String
        Dim retmsg As String = ""
        Dim retmsgAux As String = ""

        If msg.Substring(0, 1) = "[" And msg.IndexOf("]") > 0 Then
            If flg = "name" Then
                retmsg = msg.Substring(1, msg.IndexOf("]") - 1)
            Else
                retmsgAux = msg.Substring(msg.IndexOf("]") + 1)
                If retmsgAux.IndexOf("[") > 0 Then
                    retmsg = retmsgAux.Substring(1, retmsgAux.IndexOf("[") - 1)
                End If

                retmsg = msg.Substring(msg.IndexOf("]") + 1)
            End If
        Else
            retmsg = msg
        End If

        Return retmsg
    End Function
    Public Function exMsgHasTag(msg As String) As Boolean
        Return (msg.Substring(0, 1) = "[" And msg.IndexOf("]") > 0)
    End Function

    Public Function FindControlRecursive(control As Control, id As String) As Control
        If control Is Nothing Then
            Return Nothing
        End If
        'try to find the control at the current level
        Dim ctrl As Control = control.FindControl(id)

        If ctrl Is Nothing Then
            'search the children
            For Each child As Control In control.Controls
                ctrl = FindControlRecursive(child, id)

                If ctrl IsNot Nothing Then
                    Exit For
                End If
            Next
        End If
        Return ctrl
    End Function

    Function HasConnectionToDb() As Boolean
        Dim oradbConnMask As String = String.Empty
        Dim oradb As String = String.Empty

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            If ConfigurationManager.AppSettings("dashDbPointer") = "LocalBI4T" Then
                oradbConnMask = ConfigurationManager.AppSettings("connOracleConnectionMask_LocalBI4T")
                oradb = String.Format(oradbConnMask, ConfigurationManager.AppSettings("dashDbUserName_LocalBI4T"), ConfigurationManager.AppSettings("dashDbPassword_LocalBI4T"))
            ElseIf ConfigurationManager.AppSettings("dashDbPointer") = "DbUAMBI4T" Then
                oradbConnMask = ConfigurationManager.AppSettings("connOracleConnectionMask_DbUAMBI4T")
                oradb = String.Format(oradbConnMask, ConfigurationManager.AppSettings("dashDbUserName_DbUAMBI4T"), ConfigurationManager.AppSettings("dashDbPassword_DbUAMBI4T"))
            End If
        End If

        'TENTA ABRIR CONEXÃO COM O BD 
        Dim conn As OracleConnection = New OracleConnection(oradb)

        Try
            conn.Open()

            HasConnectionToDb = True
        Catch ex As Exception
            HasConnectionToDb = False
        Finally
            conn.Close()
        End Try
    End Function

    Sub LogUserAccess(userName As String, relPath As String)
        Try
            If userName <> "admin@4t.com.br" Then
                Dim objLoginRegistro As New S5T.LoginRegistro

                objLoginRegistro.pLoginUsuario = userName
                objLoginRegistro.pObsLog = relPath
                objLoginRegistro.pDataHora = Now
                objLoginRegistro.Save()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function Nvl(Of T)(ByVal Value As T, ByVal DefaultValue As T) As T
        If Value Is Nothing OrElse IsDBNull(Value) Then
            Return DefaultValue
        Else
            Return Value
        End If
    End Function

    Function dashConnectionParameters() As DevExpress.DataAccess.ConnectionParameters.DataConnectionParametersBase
        dashConnectionParameters = Nothing

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            If ConfigurationManager.AppSettings("dashDbPointerDualInstance") = "LocalBI4T" Then
                Dim oraclepar = New OracleConnectionParameters

                oraclepar.ServerName = ConfigurationManager.AppSettings("dashDbServerName_LocalBI4T")
                oraclepar.UserName = ConfigurationManager.AppSettings("dashDbUserName_LocalBI4T")
                oraclepar.Password = ConfigurationManager.AppSettings("dashDbPassword_LocalBI4T")

                dashConnectionParameters = oraclepar

            ElseIf ConfigurationManager.AppSettings("dashDbPointer") = "DbUAMBI4T" Then

                Dim oraclepar = New OracleConnectionParameters

                oraclepar.ServerName = ConfigurationManager.AppSettings("dashDbServerName_DbUAMBI4T")
                oraclepar.UserName = ConfigurationManager.AppSettings("dashDbUserName_DbUAMBI4T")
                oraclepar.Password = ConfigurationManager.AppSettings("dashDbPassword_DbUAMBI4T")

                dashConnectionParameters = oraclepar
            End If
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            Dim sqlserverpar = New MsSqlConnectionParameters

            If ConfigurationManager.AppSettings("dashDbAuthType_MSSqlServer") = "SqlServer" Then
                sqlserverpar.AuthorizationType = MsSqlAuthorizationType.SqlServer
            ElseIf ConfigurationManager.AppSettings("dashDbAuthType_MSSqlServer") = "Windows" Then
                sqlserverpar.AuthorizationType = MsSqlAuthorizationType.Windows
            End If

            sqlserverpar.ServerName = ConfigurationManager.AppSettings("dashDbServerName_MSSqlServer")
            sqlserverpar.DatabaseName = ConfigurationManager.AppSettings("dashDbDatabaseName_MSSqlServer")
            sqlserverpar.UserName = ConfigurationManager.AppSettings("dashDbUserName_MSSqlServer")
            sqlserverpar.Password = ConfigurationManager.AppSettings("dashDbPassword_MSSqlServer")

            dashConnectionParameters = sqlserverpar
        End If
    End Function

    Function dbConnectionString() As String
        dbConnectionString = String.Empty

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            If ConfigurationManager.AppSettings("dashDbPointer") = "LocalBI4T" Then
                dbConnectionString = ConfigurationManager.AppSettings("connOracleConnection_LocalBI4T")
            ElseIf ConfigurationManager.AppSettings("dashDbPointer") = "DbUAMBI4T" Then
                dbConnectionString = ConfigurationManager.AppSettings("connOracleConnection_DbUAMBI4T")
            End If
        End If
    End Function

    Function GetDashboardInstance(parDash As dashboardsList) As Object
        GetDashboardInstance = Nothing

        Select Case parDash
            Case dashboardsList.dashCnEntCanaEntradasCana
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaEntradasCana
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaEntradasCanaMSSQL
                End If
            Case dashboardsList.dashCnEntCanaEntradasCanaPorTipo
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaEntradasCanaPorTipo
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaEntradasCanaPorTipoMSSQL
                End If
            Case dashboardsList.dashCnEntCanaEntradasCanaTonPorViagemPorFrente
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaEntradasCanaTonPorViagemPorFrente
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaEntradasCanaTonPorViagemPorFrenteMSSQL
                End If
            Case dashboardsList.dashCnEntCanaEntradasCanaTonPorViagemRangeParam
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaEntradasCanaTonPorViagemRangeParam
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaEntradasCanaTonPorViagemRangeParamMSSQL
                End If
            Case dashboardsList.dashCnEntCanaColheitaCertificados
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaColheitaCertificados
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaColheitaCertificadosMSSQL
                End If
            Case dashboardsList.dashCnEntCanaMoagemMensalDiaria
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMoagemMensalDiaria
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMoagemMensalDiariaMSSQL
                End If
            Case dashboardsList.dashCnEntCanaMoagemMensalAcumulada
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMoagemMensalAcumulada
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMoagemMensalAcumuladaMSSQL
                End If
            Case dashboardsList.dashCnEntCanaMoagemMensalSafra
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMoagemMensalSafra
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMoagemMensalSafraMSSQL
                End If
            Case dashboardsList.dashCnEntCanaMoagemMensalSafraAcumulada
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMoagemMensalSafraAcumulada
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMoagemMensalSafraAcumuladaMSSQL
                End If
            Case dashboardsList.dashCnEntCanaMobEntradaCanaHoraGeral
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMobEntradaCanaHoraGeral
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMobEntradaCanaHoraGeralMSSQL
                End If
            Case dashboardsList.dashCnEntCanaMobEntradaCanaHoraPorFrente
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMobEntradaCanaHoraPorFrente
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMobEntradaCanaHoraPorFrenteMSSQL
                End If
            Case dashboardsList.dashCnEntCanaMobMoagemCanaHora
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMobMoagemCanaHora
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMobMoagemCanaHoraMSSQL
                End If
            Case dashboardsList.dashCnEntCanaMobEntradasCertificadoHora
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMobEntradasCertificadoHora
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetDashboardInstance = New Win_Dashboards.dashCnEntCanaMobEntradasCertificadoHoraMSSQL
                End If
        End Select
    End Function

    Function dashXML(parDash As dashboardsList) As String
        dashXML = String.Empty
        Dim definitionPath As String = String.Empty
        Dim dashboardDefinition As String = String.Empty

        Select Case parDash
            Case dashboardsList.dashCnEntCanaEntradasCanaMapa
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    definitionPath = HttpContext.Current.Server.MapPath("~/dashXmls/dashCnEntCanaEntradasCanaMapa.xml")
                    dashboardDefinition = File.ReadAllText(definitionPath)

                    dashXML = dashboardDefinition
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    definitionPath = HttpContext.Current.Server.MapPath("~/dashXmls/dashCnEntCanaEntradasCanaMapaMSSQL.xml")
                    dashboardDefinition = File.ReadAllText(definitionPath)

                    dashXML = dashboardDefinition
                End If
            Case dashboardsList.dashCnEntCanaEntradasCanaMapaPropriedades
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    definitionPath = HttpContext.Current.Server.MapPath("~/dashXmls/dashCnEntCanaEntradasCanaMapaPropriedades.xml")
                    dashboardDefinition = File.ReadAllText(definitionPath)

                    dashXML = dashboardDefinition
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    definitionPath = HttpContext.Current.Server.MapPath("~/dashXmls/dashCnEntCanaEntradasCanaMapaPropriedadesMSSQL.xml")
                    dashboardDefinition = File.ReadAllText(definitionPath)

                    dashXML = dashboardDefinition
                End If
            Case dashboardsList.dashCnEntCanaPlanejamentoColheitaMapa
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    definitionPath = HttpContext.Current.Server.MapPath("~/dashXmls/dashCnEntCanaPlanejamentoColheitaMapa.xml")
                    dashboardDefinition = File.ReadAllText(definitionPath)

                    dashXML = dashboardDefinition
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    definitionPath = HttpContext.Current.Server.MapPath("~/dashXmls/dashCnEntCanaPlanejamentoColheitaMapaMSSQL.xml")
                    dashboardDefinition = File.ReadAllText(definitionPath)

                    dashXML = dashboardDefinition
                End If
            Case dashboardsList.dashCnEntCanaEntradasSequencialColheita
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    definitionPath = HttpContext.Current.Server.MapPath("~/dashXmls/dashCnEntCanaEntradasSequencialColheita.xml")
                    dashboardDefinition = File.ReadAllText(definitionPath)

                    dashXML = dashboardDefinition
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    definitionPath = HttpContext.Current.Server.MapPath("~/dashXmls/dashCnEntCanaEntradasSequencialColheitaMSSQL.xml")
                    dashboardDefinition = File.ReadAllText(definitionPath)

                    dashXML = dashboardDefinition
                End If
        End Select
    End Function

    Function dashboardEnumToString(parDash As dashboardsList) As String
        dashboardEnumToString = [Enum].GetName(GetType(AppUtils.dashboardsList), parDash)
    End Function

    Function GetReportInstance(parReport As reportsList) As Object
        GetReportInstance = Nothing

        Select Case parReport
            Case reportsList.repCnEntCanaEntradasPropriedades
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetReportInstance = New repCnEntCanaEntradasPropriedades
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetReportInstance = New repCnEntCanaEntradasPropriedadesMSSQL
                End If
        End Select
    End Function

    Function GetReportTypeName(parReport As reportsList) As String
        GetReportTypeName = String.Empty

        Select Case parReport
            Case reportsList.repCnEntCanaEntradasPropriedades
                If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                    GetReportTypeName = "AspNet5t.repCnEntCanaEntradasPropriedades"
                ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                    GetReportTypeName = "AspNet5t.repCnEntCanaEntradasPropriedadesMSSQL"
                End If
        End Select
    End Function



    Enum dashboardsList
        dashCnEntCanaEntradasCana
        dashCnEntCanaEntradasCanaPorTipo
        dashCnEntCanaEntradasCanaTonPorViagemPorFrente
        dashCnEntCanaEntradasCanaTonPorViagemRangeParam
        dashCnEntCanaEntradasCanaMapa
        dashCnEntCanaEntradasCanaMapaPropriedades
        dashCnEntCanaColheitaCertificados
        dashCnEntCanaPlanejamentoColheitaMapa
        dashCnEntCanaMoagemMensalDiaria
        dashCnEntCanaMoagemMensalAcumulada
        dashCnEntCanaMoagemMensalSafra
        dashCnEntCanaMoagemMensalSafraAcumulada
        dashCnEntCanaEntradasSequencialColheita
        dashCnEntCanaMobEntradaCanaHoraGeral
        dashCnEntCanaMobEntradaCanaHoraPorFrente
        dashCnEntCanaMobMoagemCanaHora
        dashCnEntCanaMobEntradasCertificadoHora
    End Enum

    Enum reportsList
        repCnEntCanaEntradasPropriedades
    End Enum

    Function NvlDbNull(parListSourceFieldValue As Object) As Double
        Dim valRetorno As Double = 0

        If Not (TypeOf parListSourceFieldValue Is System.DBNull) Then
            valRetorno = Convert.ToDouble(parListSourceFieldValue)
        End If

        Return valRetorno
    End Function

End Module

