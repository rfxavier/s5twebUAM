Namespace S5T

    Partial Public Class Filial
        Private Sub OnBeforeSave()
            If Me.pNome = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[txtnome] Campo nao pode ser nulo")
                Exit Sub
            End If
            If Me.sTipo = 99 Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[cmbTipo] Campo nao pode ser nulo")
                Exit Sub
            End If
           
            'If Me.oCadastro.pPFPJ = "F" Then
            '    Throw New CodeFluent.Runtime.CodeFluentValidationException("[cmbcadastrofilial] Cadastro somente Público tipo júridico")
            '    Exit Sub
            'End If
            'AMANHA VERIFICAR COM RX PORQUE PASSA AQUI MESMO NA EXCLUSÃO
            'If Me.oCadastro Is Nothing Then
            '    Throw New CodeFluent.Runtime.CodeFluentValidationException("INCLUSÃO/ALTERAÇÃO NEGADA - Não informado código do Cadastro")
            'End If


            If Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Created Then
                If S5T.Cadastro.LoadByEntityKey(Me.oCadastropId).oCadastroFilial IsNot Nothing Then
                    Throw New CodeFluent.Runtime.CodeFluentValidationException("INCLUSÃO NEGADA - Código do Cadastro ja indicado para outra Filial")
                End If
                If (S5T.Filial.LoadByEntityKey(Me.pCodigo) Is Nothing) = False Then
                    Throw New CodeFluent.Runtime.CodeFluentValidationException("INCLUSÃO NEGADA - Código da FILIAL ja existente")
                End If
                Dim objFilialMaxCodigo As S5T.Filial = S5T.Filial.LoadMaxCodigo(Me.oEmpresa.pCodigo)
                If objFilialMaxCodigo Is Nothing Then
                    Me.pCodigo = 1
                Else
                    Me.pCodigo = objFilialMaxCodigo.pCodigo + 1
                End If
            End If

            'Me.xDataHoraReg = S5T.AppConfig.LoadDataHoraBD
        End Sub
        Private Sub OnBeforeDelete()
            'If (Me.oTitulos.Count > 0) Then
            '    Throw New CodeFluent.Runtime.CodeFluentValidationException("EXCLUSÃO NEGADA - Títulos vinculado a esta Filial")
            '    Exit Sub
            'End If
            'liberar o cadastro de publico para ser usado em outra filial
            Me.oCadastro = Nothing
            Me.Save()
        End Sub
    End Class
End Namespace
