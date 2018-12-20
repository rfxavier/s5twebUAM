Imports CodeFluent.Runtime

Namespace S5T
    Partial Public Class Cadastro
        Private Sub OnBeforeSave()
            If S5T.Usuario.LoadBypLogin(Me.xLoginReg) Is Nothing Then
                Throw New CodeFluentRuntimeException("Usuário xLogin inválido")
            End If

            ' **** início de teste dos campos que não podem ser nulo
            ' **** Me.pPFPJ não precisa testar, é resolvido em código abaixo sobrepondo... ignora o que o usuário informa e sobrepõe...

            If Me.pNome = "" Then
                Throw New CodeFluentValidationException("[TxtNome] Nome do Cadastro não informado")
            End If

            If Me.pCpfCnpj = "" Then
                Throw New CodeFluentValidationException("[TxtCpfCnpj] CPF/CNPJ não informado")
            End If

            Dim cpfcnpj1 As New valida_CNPJ_CPF
            cpfcnpj1.cpf = Me.pCpfCnpj
            cpfcnpj1.cnpj = Me.pCpfCnpj

            If (cpfcnpj1.isCpfValido = False) And (cpfcnpj1.isCnpjValido = False) Then
                Throw New CodeFluentValidationException("[TxtCpfCnpj] CPF/CNPJ inválido")
            End If

            '**** Resolve Me.pPFPJ
            If cpfcnpj1.isCpfValido Then
                Me.pPFPJ = "F"
            ElseIf cpfcnpj1.isCnpjValido Then
                Me.pPFPJ = "J"
            End If

            If Me.EntityState = CodeFluentEntityState.Created Then
                If (S5T.Cadastro.LoadBypCodigo(Me.pCodigo) Is Nothing) = False Then
                    Throw New CodeFluentValidationException("[pCodigo] Já existe Cadastro com código = " & Me.pCodigo)
                End If

                If S5T.CadastroCollection.LoadBypCpfCnpj(Me.pCpfCnpj).Count > 0 Then
                    Throw New CodeFluentValidationException("[TxtCpfCnpj] CPF/CNPJ já cadastrado")
                End If
            End If

            Dim dtDataHoraAtual = AppConfig.LoadDataHoraBD
            Dim dtDataAtual As Date = dtDataHoraAtual.Date

            If Me.pPFPJ = "F" Then
                If Me.pDataNascimento = Nothing Then
                    Throw New CodeFluentValidationException("[MskDtNasc] Data Nascimento não informada")
                End If

                If DateDiff(DateInterval.Year, Me.pDataNascimento, dtDataAtual) > 100 Or Me.pDataNascimento > dtDataAtual Then
                    Throw New CodeFluentValidationException("[MskDtNasc] Data Nascimento inválida")
                End If

                If Me.pFlgSexo = Nothing Then
                    Throw New CodeFluentValidationException("[TxtSexo] Sexo não informado")
                Else
                    Me.pFlgSexo = Me.pFlgSexo.ToUpper
                End If

                If Me.pFlgSexo <> "M" And Me.pFlgSexo <> "F" Then
                    Throw New CodeFluentValidationException("[TxtSexo] Sexo inválido: informar (M) ou (F)")
                End If

                Me.pTelefone = S5T.AppConfig.ValidaTelefone(Me.pTelefone, "TxtFoneFixo1")
                Me.pTelefoneAux = S5T.AppConfig.ValidaTelefone(Me.pTelefoneAux, "TxtFoneCel1")
                Me.pCelular = S5T.AppConfig.ValidaTelefone(Me.pCelular, "TxtFoneAlt1")
                Me.pFax = S5T.AppConfig.ValidaTelefone(Me.pFax, "TxtFoneFax1")
            End If

            'If Me.pPFPJ = "J" Then
            '    Me.pDataNascimento = Nothing
            'End If

            If Me.pEnderLogradouro = "" Then
                Throw New CodeFluentValidationException("[TxtLogradouro] Logradouro não informado")
            End If
            If Me.pEnderNumero = "" Then
                Throw New CodeFluentValidationException("[TxtNumero] Número não informado")
            End If
            If Me.pEnderBairro = "" Then
                Throw New CodeFluentValidationException("[TxtBairro] Bairro não informado")
            End If
            If Me.oCidade Is Nothing Then
                Throw New CodeFluentValidationException("[CmbCidade] Cidade não informada")
            End If
            If Me.pCep = "" Then
                Throw New CodeFluentValidationException("[MskCep] Cep não informado")
            End If

            Me.pEndereco = Me.pEnderLogradouro + ", " + IIf(Me.pEnderNumero = "", "S/N", Me.pEnderNumero) + " " + Me.pEnderComplemento + " " + Me.pEnderBairro

            Me.xDataHoraReg = AppConfig.LoadDataHoraBD

            If Me.EntityState = CodeFluentEntityState.Created Then
                Me.pDataCadastro = dtDataAtual

                Dim objCadastroMaxCodigo As S5T.Cadastro = S5T.Cadastro.LoadMaxCodigo
                If objCadastroMaxCodigo Is Nothing Then
                    Me.pCodigo = 1
                Else
                    Me.pCodigo = objCadastroMaxCodigo.pCodigo + 1
                End If

            End If
        End Sub

        Private Sub OnBeforeDelete()
            'If Me.oTitulos.Count > 0 Then
            '    Throw New CodeFluentValidationException("EXCLUSÃO NEGADA - Existem Títulos vinculados a este Cadastro")
            'End If


            'If Me.oCliente IsNot Nothing Then
            '    'DELETA REGISTRO NA ENTIDADE CLIENTE
            '    Me.oCliente.oCadastro = Nothing
            '    Me.oCliente.Save()
            '    Me.oCliente.Delete()

            '    'REMOVE DO CADASTRO DESTE CLIENTE O TIPO "CLI"
            '    Me.oCadastrosTipo.Remove(S5T.CadastroTipo.LoadByFlgCadastro("CLI"))
            '    Me.Save()
            'End If

            If (Me.oUsuario Is Nothing) = False Then
                'DELETA REGISTRO NA ENTIDADE USUARIO
                Me.oUsuario.oCadastro = Nothing
                Me.oUsuario.Save()
                Me.oUsuario.Delete()

                'REMOVE DO CADASTRO DESTE Usuario O TIPO "USU"
                Me.oCadastrosTipo.Remove(S5T.CadastroTipo.LoadByFlgCadastro("USU"))
                Me.Save()
            End If

        End Sub

    End Class
End Namespace
