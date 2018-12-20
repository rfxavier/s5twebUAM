Public Class WebFormTmpCanaMoagemMensal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ASPxPivotGrid1_CustomFieldSort(sender As Object, e As DevExpress.Web.ASPxPivotGrid.PivotGridCustomFieldSortEventArgs) Handles ASPxPivotGrid1.CustomFieldSort
        If e.Field.FieldName <> "MES" Then Return
        e.Handled = True

        Dim mes1 As Integer = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "MES_N")
        Dim mes2 As Integer = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "MES_N")

        If mes1 > mes2 Then
            e.Result = 1
        ElseIf mes1 = mes2 Then
            e.Result = 0
        ElseIf mes1 < mes2 Then
            e.Result = -1
        End If
    End Sub
End Class