Imports CodeFluent.Runtime

Namespace S5T
    Partial Public Class LoginRegistro
        Private Sub OnBeforeSave()
            Dim objUsuario = S5T.Usuario.LoadBypLogin(Me.pLoginUsuario.ToUpper.Trim)
            Dim objFilial = S5T.Filial.LoadByCodEmpresaCodFilial(Me.pCodigoEmpresa, Me.pCodigoFilial)

            Me.pLoginValidado = True

            If objUsuario Is Nothing Then
                Me.pObsLog = "Usuário não encontrado"
                Me.pLoginValidado = False
                'Throw New CodeFluentValidationException(Me.pObsLog)
            Else
                Me.pCodigoUsuario = objUsuario.pCodigo
                Me.sUsuarioStatus = objUsuario.sStatus
                Me.pFlgAdminUsuario = objUsuario.pFlgAdmin

                If objUsuario.sStatus = UsuarioStatus.Bloqueado Then
                    Me.pObsLog = "Usuário está inativo"
                    Me.pLoginValidado = False
                    'Throw New CodeFluentValidationException(Me.pObsLog)
                ElseIf objUsuario.pSenha.ToUpper <> Me.pSenha Then
                    Me.pObsLog = "Senha inválida"
                    Me.pLoginValidado = False
                    'Throw New CodeFluentValidationException(Me.pObsLog)
                End If
            End If

            If Me.pLoginValidado = True Then
                If objFilial Is Nothing Then
                    Me.pObsLog = "Filial não encontrada"
                    Me.pLoginValidado = False
                    'Throw New CodeFluent.Runtime.CodeFluentValidationException(Me.pObsLog)
                Else
                    Me.pCodigoFilial = objFilial.pCodigo


                    If S5T.FilialCollection.LoadByCodFilialLoginUsuario(Me.pCodigoFilial, Me.pLoginUsuario).Count = 0 Then
                        Me.pObsLog = "Usuário não tem permissão para essa filial"
                        Me.pLoginValidado = False
                        'Throw New CodeFluent.Runtime.CodeFluentValidationException("Usuário não tem permissão para essa filial")
                    End If
                End If
            End If
        End Sub

        Private Sub OnAfterSave()
            If Me.pLoginValidado = False Then
                Throw New CodeFluentValidationException(Me.pObsLog)
            End If
        End Sub

        'Private Sub OnGetpLoginValidado()
        '    If Me.pCPF = "" Then
        '        _pPFPJ = "J"
        '    ElseIf Me.pCNPJ = "" Then
        '        _pPFPJ = "F"
        '    ElseIf Me.pCPF = "" And Me.pCNPJ = "" Then
        '        _pPFPJ = " "
        '    End If

        'End Sub
    End Class
End Namespace
