Imports DevExpress.DataAccess.ConnectionParameters
Imports Microsoft.AspNet.Identity

Public Class cnOficinaDetalhamentoTriGeralCmFr
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If

        If (Session("OfDetDashboardID") <> Nothing) Then
            If Session("OfDetDashboardID") = 1 Then
                ASPxButton1.Checked = True

                Dim dash As New Win_Dashboards.dashCnOficinaDetalhamentoGeral
                ASPxDashboardViewer1.DashboardSource = dash
                ASPxDashboardViewer1.DataBind()
            ElseIf Session("OfDetDashboardID") = 2 Then
                ASPxButton2.Checked = True

                Dim dash As New Win_Dashboards.dashCnOficinaDetalhamentoPorClasseMec
                ASPxDashboardViewer1.DashboardSource = dash
                ASPxDashboardViewer1.DataBind()
            Else
                ASPxButton3.Checked = True

                Dim dash As New Win_Dashboards.dashCnOficinaDetalhamentoPorFrente
                ASPxDashboardViewer1.DashboardSource = dash
                ASPxDashboardViewer1.DataBind()
            End If
        Else
            ASPxButton1.Checked = True

            'Dim dash As New Win_Dashboards.dashCnOficinaDetalhamentoGeral
            'ASPxDashboardViewer1.DashboardSource = dash
            'ASPxDashboardViewer1.DataBind()
        End If
    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
        If e.Parameter = 1 Then
            Dim dash As New Win_Dashboards.dashCnOficinaDetalhamentoGeral
            ASPxDashboardViewer1.DashboardSource = dash
        ElseIf e.Parameter = 2 Then
            Dim dash As New Win_Dashboards.dashCnOficinaDetalhamentoPorClasseMec
            ASPxDashboardViewer1.DashboardSource = dash
        Else
            Dim dash As New Win_Dashboards.dashCnOficinaDetalhamentoPorFrente
            ASPxDashboardViewer1.DashboardSource = dash
        End If

        Session("OfDetDashboardID") = e.Parameter
    End Sub
End Class