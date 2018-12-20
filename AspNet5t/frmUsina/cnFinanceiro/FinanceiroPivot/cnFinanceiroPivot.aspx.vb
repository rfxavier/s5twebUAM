Imports DevExpress.DataAccess.ConnectionParameters
Imports Microsoft.AspNet.Identity
Imports Oracle.DataAccess.Client

Public Class cnFinanceiroPivot
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) And (Not IsCallback) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If

        Dim oradb As String = AppUtils.dbConnectionString

    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            If ConfigurationManager.AppSettings("dashDbPointer") = "LocalBI4T" Then
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

    Protected Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
        'MsgBox(dataReferencia.Date)
    End Sub

    'Private Sub ASPxDashboardViewer1_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashboardViewer1.CustomParameters

    '    e.Parameters(0).Value = dataReferencia.Date.AddHours(-12).ToString("yyyyMMddHH:mm")
    '    e.Parameters(1).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm") '"2014100613:00"

    'End Sub

End Class