Namespace S5T

    Partial Public Class Cidade
        Private Sub OnBeforeSave()
            If Me.pNome = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[txtnome] Campo nao pode ser nulo")
            End If
            If Me.pCodigoIbge = 0 Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[txtcodigoibge] Campo nao pode ser nulo")
            End If
            If Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Created Then
                If (S5T.Cidade.LoadBypCodigo(Me.pCodigo) Is Nothing) = False Then
                    Throw New CodeFluent.Runtime.CodeFluentValidationException("INCLUSÃO NEGADA - Código do Banco ja existente")
                End If

                Dim objCidadeMaxCodigo As S5T.Cidade = S5T.Cidade.LoadMaxCodigo
                If objCidadeMaxCodigo Is Nothing Then
                    Me.pCodigo = 1
                Else
                    Me.pCodigo = objCidadeMaxCodigo.pCodigo + 1
                End If
            End If

            Me.xDataHoraReg = S5T.AppConfig.LoadDataHoraBD
        End Sub
        Private Sub OnBeforeDelete()
            If (Me.oCadastros.Count > 0) Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("EXCLUSÃO NEGADA - Cadastro vinculado a esta cidade")
                Exit Sub
            End If
           
        End Sub

    End Class
End Namespace
