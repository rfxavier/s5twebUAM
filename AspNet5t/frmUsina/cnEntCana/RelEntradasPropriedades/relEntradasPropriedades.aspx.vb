Imports Microsoft.AspNet.Identity

Public Class relEntradasPropriedades
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            ASPxDocumentViewer1.ReportTypeName = AppUtils.GetReportTypeName(reportsList.repCnEntCanaEntradasPropriedades)
            ASPxDocumentViewer1.Report = AppUtils.GetReportInstance(reportsList.repCnEntCanaEntradasPropriedades)

            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If

    End Sub

End Class