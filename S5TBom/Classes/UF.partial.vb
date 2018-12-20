Namespace S5T

    Partial Public Class UF
        Private Sub OnBeforeSave()
 
            If Me.pDescricao = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[txtdescricao] Campo nao pode ser nulo")
                Exit Sub
            End If
            If Me.pSigla = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[txtsigla] Campo nao pode ser nulo")
                Exit Sub
            End If
         
            If Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Created Then
                If (S5T.UF.LoadBypCodigo(Me.pCodigo) Is Nothing) = False Then
                    Throw New CodeFluent.Runtime.CodeFluentValidationException("INCLUSÃO NEGADA - Código da UF ja existente")
                End If

                Dim objUFMaxCodigo As S5T.UF = S5T.UF.LoadMaxCodigo
                If objUFMaxCodigo Is Nothing Then
                    Me.pCodigo = 1
                Else
                    Me.pCodigo = objUFMaxCodigo.pCodigo + 1
                End If
           
            End If
            Me.xDataHoraReg = S5T.AppConfig.LoadDataHoraBD

        End Sub
        Private Sub OnBeforeDelete()
            If (Me.oCidades.Count > 0) Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("EXCLUSÃO NEGADA - Cidades vinculadas a esta UF")
                Exit Sub
            End If
        End Sub

    End Class
End Namespace
