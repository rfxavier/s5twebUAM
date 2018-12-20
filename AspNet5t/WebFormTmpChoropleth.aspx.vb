Imports DevExpress.DataAccess.ConnectionParameters

Public Class WebFormTmpChoropleth
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            If ConfigurationManager.AppSettings("dashDbPointerDualInstance") = "LocalBI4T" Then
                Dim oraclepar = New OracleConnectionParameters

                oraclepar.ServerName = ConfigurationManager.AppSettings("dashDbServerName_LocalBI4T")
                oraclepar.UserName = ConfigurationManager.AppSettings("dashDbUserName_LocalBI4T")
                oraclepar.Password = ConfigurationManager.AppSettings("dashDbPassword_LocalBI4T")

                e.ConnectionParameters = oraclepar

            ElseIf ConfigurationManager.AppSettings("dashDbPointer") = "DbUAMBI4T" Then

                Dim oraclepar = New OracleConnectionParameters

                oraclepar.ServerName = ConfigurationManager.AppSettings("dashDbServerName_DbUAMBI4T")
                oraclepar.UserName = ConfigurationManager.AppSettings("dashDbUserName_DbUAMBI4T")
                oraclepar.Password = ConfigurationManager.AppSettings("dashDbPassword_DbUAMBI4T")

                e.ConnectionParameters = oraclepar
            End If
        End If
    End Sub

End Class