Imports Oracle.DataAccess.Client
Imports Microsoft.AspNet.Identity

Public Class cnAdmRmEpiPendenteInd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            'Response.AddHeader("Refresh", "40")
            'LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If

        gridGeral.DataSourceID = ""
        gridGeral.DataBind()
    End Sub

    Protected Sub gridGeral_DataBinding(sender As Object, e As EventArgs) Handles gridGeral.DataBinding
        Dim dr As Object = Nothing
        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim oradb As String = AppUtils.dbConnectionString

            Dim conn As OracleConnection = New OracleConnection(oradb)
            conn.Open()
            Dim cmd As OracleCommand = New OracleCommand()
            cmd.Connection = conn
            cmd.CommandText = "SELECT ROWNUM, RM, DATA_RM, MATRICULA, NOME, ID_ESTRUTURA, ESTRUTURA, ITEM, AREA, DIV_DESCRICAO FROM BI4T.V_RM_PENDENTE"
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader() 'As OracleDataReader
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'dr = S5TUam.ACOMP_PROD_DCORTECollection.LoadAll
        End If

        gridGeral.DataSource = dr

    End Sub
End Class