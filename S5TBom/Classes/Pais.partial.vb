Namespace S5T

    Partial Public Class Pais
        Private Sub OnBeforeSave()
            If Me.pNome = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[txtnome] Campo nao pode ser nulo")
                Exit Sub
            End If
            If Me.pCodigoIbge = 0 Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[txtcodigoibge] Campo nao pode ser nulo")
                Exit Sub
            End If
            If Me.pSigla = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[txtsigla] Campo nao pode ser nulo")
                Exit Sub
            End If
            If Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Created Then
                Dim objPaisMaxCodigo As S5T.Pais = S5T.Pais.LoadMaxCodigo
                If objPaisMaxCodigo Is Nothing Then
                    Me.pCodigo = 1
                Else
                    Me.pCodigo = objPaisMaxCodigo.pCodigo + 1
                End If
            End If
        End Sub

        Private Sub OnBeforeDelete()

        End Sub
    End Class
End Namespace
