Imports CodeFluent.Runtime

Namespace S5T
    Partial Public Class Usuario
        Private Sub OnBeforeSave()
            If Me.pLogin = "" Then
                Throw New CodeFluentValidationException("[txtLoginUsuario] Campo Login Usuário não pode ser nulo")
            End If

            If Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Created Then
                If (S5T.Usuario.LoadBypLogin(Me.pLogin.ToUpper) Is Nothing) = False Then
                    Throw New CodeFluent.Runtime.CodeFluentValidationException("[txtLoginUsuario] INCLUSÃO NEGADA - Login de Usuário já existente")
                End If
            End If

            Me.pLogin = Me.pLogin.ToUpper

            If Me.pSenha = "" Then
                Throw New CodeFluentValidationException("[txtSenhaUsuario] Campo Senha Usuário não pode ser nulo")
            End If

            If Me.pFlgAdmin <> "S" And Me.pFlgAdmin <> "N" Then
                Throw New CodeFluentValidationException("[CmbFlgAdminUsuario] Campo Usuário administrador inválido")
            End If

            If Me.EntityState = CodeFluentEntityState.Created Then
                If (S5T.Usuario.LoadByoCadastro(Me.oCadastropId) Is Nothing) = False Then
                    Throw New CodeFluentValidationException("INCLUSÃO DE USUÁRIO NEGADA - Código de cadastro já vinculado a um Usuário")
                End If

                Dim objUsuarioMaxCodigo As S5T.Usuario = S5T.Usuario.LoadMaxCodigo
                If objUsuarioMaxCodigo Is Nothing Then
                    Me.pCodigo = 1
                Else
                    Me.pCodigo = objUsuarioMaxCodigo.pCodigo + 1
                End If

                'ADICIONA AO CADASTRO DESTE CLIENTE O TIPO "USU"
                If Me.oCadastro IsNot Nothing Then
                    Me.oCadastro.oCadastrosTipo.Add(S5T.CadastroTipo.LoadByFlgCadastro("USU"))
                    Me.oCadastro.Save()
                End If
            End If

            Me.xDataHoraReg = AppConfig.LoadDataHoraBD
        End Sub

        Private Sub OnBeforeDelete()
            If Me.oMenuPermissoes.Count > 0 Then
                Throw New CodeFluentValidationException("EXCLUSÃO NEGADA - Permissões de menu vinculadas a este Usuário")
            End If

            If Me.oFiliais.Count > 0 Then
                Throw New CodeFluentValidationException("EXCLUSÃO NEGADA - Permissão de filiais vinculadas a este Usuário")
            End If
        End Sub

        Protected Shared Sub DeleteLinkCadastroPartial(ByVal parUsuario As S5T.Usuario)
            If parUsuario IsNot Nothing Then
                If parUsuario.oCadastro IsNot Nothing Then
                    'REMOVE DO CADASTRO DESTE Usuario O TIPO "USU"
                    'DESVINCULA O CADASTRO DESTE Usuario
                    parUsuario.oCadastro.oCadastrosTipo.Remove(S5T.CadastroTipo.LoadByFlgCadastro("USU"))
                    parUsuario.oCadastro.oUsuario = Nothing
                    parUsuario.oCadastro.Save()

                    'DELETA Usuario
                    parUsuario.Delete()
                End If
            End If
        End Sub
    End Class
End Namespace
