Imports Oracle.DataAccess.Client
Imports Microsoft.AspNet.Identity
Imports DevExpress.Web
Imports DevExpress.Data.Filtering

Public Class cnAdmRmEpiPendenteIndMenu
    Inherits System.Web.UI.Page

    Private _areaRef As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            'Response.AddHeader("Refresh", "40")

            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

        End If

        _areaRef = Request.QueryString("area")

        gridGeral.DataSourceID = ""
        gridGeral.DataBind()
    End Sub

    Private Sub gridGeral_AutoFilterCellEditorCreate(sender As Object, e As DevExpress.Web.ASPxGridViewEditorCreateEventArgs) Handles gridGeral.AutoFilterCellEditorCreate
        If e.Column.FieldName = "DATA_RM" Then
            Dim combo As New ComboBoxProperties()
            e.EditorProperties = combo
        End If

    End Sub

    Private Sub gridGeral_AutoFilterCellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs) Handles gridGeral.AutoFilterCellEditorInitialize
        If e.Column.FieldName = "DATA_RM" Then
            Dim combo As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            combo.ValueType = GetType(String)

            combo.Items.Add("Em atraso")
        End If

    End Sub
    Private Sub gridGeral_ProcessColumnAutoFilter(sender As Object, e As ASPxGridViewAutoFilterEventArgs) Handles gridGeral.ProcessColumnAutoFilter
        If e.Column.FieldName <> "DATA_RM" Then
            Return
        End If
        If e.Kind = GridViewAutoFilterEventKind.ExtractDisplayText Then
            e.Value = Session("value").ToString()
            Return
        Else
            Dim start As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), [end] As DateTime = start
            Dim value As String = e.Value

            Dim dtLastSaturday As Date = Now.AddDays(-(Now.DayOfWeek + 1))
            Dim dLastSaturday As Date = New Date(dtLastSaturday.Year, dtLastSaturday.Month, dtLastSaturday.Day)

            If value = "Em atraso" Then
                'start = start.Subtract(New TimeSpan(365, 0, 0, 0))
                [end] = [end].Subtract(New TimeSpan(1, 0, 0, 0))

                e.Criteria = New GroupOperator(New BinaryOperator(e.Column.FieldName, dLastSaturday, BinaryOperatorType.LessOrEqual))
            End If
            Session("value") = value

        End If

    End Sub

    Protected Sub gridGeral_DataBinding(sender As Object, e As EventArgs) Handles gridGeral.DataBinding
        Dim dr As Object = Nothing
        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim oradb As String = AppUtils.dbConnectionString

            Dim conn As OracleConnection = New OracleConnection(oradb)
            conn.Open()
            Dim cmd As OracleCommand = New OracleCommand()
            cmd.Connection = conn
            If _areaRef = "IND" Then
                'ÁREA INDÚSTRIA
                gridGeral.SettingsText.Title = "RM EPI Pendente - Indústria"
                cmd.CommandText = "SELECT ROWNUM, RM, DATA_RM, MATRICULA, NOME, ID_ESTRUTURA, ESTRUTURA, ITEM, AREA, DIV_DESCRICAO FROM BI4T.V_RM_PENDENTE WHERE DIV_DESCRICAO = 'Industrial'"
            ElseIf _areaRef = "AGR" Then
                'ÁREA AGRÍCOLA
                gridGeral.SettingsText.Title = "RM EPI Pendente - Agrícola"
                cmd.CommandText = "SELECT ROWNUM, RM, DATA_RM, MATRICULA, NOME, ID_ESTRUTURA, ESTRUTURA, ITEM, AREA, DIV_DESCRICAO FROM BI4T.V_RM_PENDENTE WHERE DIV_DESCRICAO = 'Agrícola'"
            ElseIf _areaRef = "ADM" Then
                'ÁREA ADMINISTRAÇÃO
                gridGeral.SettingsText.Title = "RM EPI Pendente - Administração"
                cmd.CommandText = "SELECT ROWNUM, RM, DATA_RM, MATRICULA, NOME, ID_ESTRUTURA, ESTRUTURA, ITEM, AREA, DIV_DESCRICAO FROM BI4T.V_RM_PENDENTE WHERE DIV_DESCRICAO = 'Administração Geral'"
            End If
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader() 'As OracleDataReader
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            'dr = S5TUam.ACOMP_PROD_DCORTECollection.LoadAll
        End If

        gridGeral.DataSource = dr

    End Sub

End Class