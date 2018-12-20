Public Class CapivaraStandAlone
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            ASPxDateEdit1.Date = Now 'New DateTime(2014, 10, 5, 10, 0, 0) 'Now
        End If

    End Sub

    Protected Sub ASPxGridView2_CustomColumnSort(sender As Object, e As DevExpress.Web.CustomColumnSortEventArgs) Handles ASPxGridView2.CustomColumnSort
        If e.Column.FieldName = "DIA" Then
            e.Handled = True
            Dim s1 As Date = e.Value1, s2 As Date = e.Value2
            If (s1.Day = 31 And s1.Month = 12) And (s2.Day = 31 And s2.Month = 12) Then
                e.Result = Comparer.Default.Compare(s1, s2)
            ElseIf (s1.Day = 31 And s1.Month = 12) Then
                e.Result = 1
            ElseIf (s2.Day = 31 And s2.Month = 12) Then
                e.Result = -1
            Else
                If s1 > s2 Then
                    e.Result = 1
                ElseIf s1 = s2 Then
                    e.Result = Comparer.Default.Compare(s1, s2)
                ElseIf s1 < s2 Then
                    e.Result = -1
                End If
            End If
        End If
    End Sub
End Class