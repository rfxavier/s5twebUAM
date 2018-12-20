Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Public Class repCnEntCanaEntradasPropriedades

    Private Sub SqlDataSource1_ConfigureDataConnection(sender As Object, e As ConfigureDataConnectionEventArgs) Handles SqlDataSource1.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub
End Class