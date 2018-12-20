Namespace S5T

    Partial Public Class AppRelatorio

        Private Sub OnBeforeSave()

            If Me.pCategoriaRelatorio = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[TxtCategoriaRelatorio] Campo Categoria Relatório não pode ser nulo")
                Exit Sub
            End If

            If Me.pNomeDataSet = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[TxtDataSet] Campo DataSet não pode ser nulo")
                Exit Sub
            End If

            If Me.pNomeFormArgumento = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[TxtNomeFormArg] Campo Nome Form. Argumento não pode ser nulo")
                Exit Sub
            End If

            If Me.pNomeRdlc = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[TxtNomeRDLC] Campo Nome RDLC não pode ser nulo")
                Exit Sub
            End If

            If Me.pNomeRelatorio = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[TxtNomeRelatorio] Campo Nome Relatório não pode ser nulo")
                Exit Sub
            End If

            If Me.pSequencia = 0 Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[TxtSequencia] Campo Sequência não pode ser nulo")
                Exit Sub
            End If

            If Me.pTituloRelatorio = "" Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[TxtTitulo] Campo Título não pode ser nulo")
                Exit Sub
            End If

            If Me.sCategoria = 0 Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("[cmbCategoria] Combo Categoria não pode ser nulo")
                Exit Sub
            End If

            If Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Created Then
                If (S5T.AppRelatorio.LoadBypNomeRelatorio(Me.pNomeRelatorio) Is Nothing) = False Then
                    Throw New CodeFluent.Runtime.CodeFluentValidationException("[TxtNomeRelatorio]INCLUSÃO NEGADA - Nome Relatório já existe")
                    Exit Sub
                End If


            End If


            Me.pCategoriaRelatorio = Me.pcCategoriaRelatorio
        End Sub
        Private Sub OnGetpcCategoriaRelatorio()
            _pcCategoriaRelatorio = String.Empty

            Select Case Me.sCategoria
                Case AppRelatorioCategoria.Cadastros
                    _pcCategoriaRelatorio = "CADASTROS"
                Case AppRelatorioCategoria.Contabilidade
                    _pcCategoriaRelatorio = "CONTABILIDADE"
                Case AppRelatorioCategoria.Estoque
                    _pcCategoriaRelatorio = "ESTOQUE"
                Case AppRelatorioCategoria.Financeiro
                    _pcCategoriaRelatorio = "FINANCEIRO"
                Case AppRelatorioCategoria.Fiscal
                    _pcCategoriaRelatorio = "FISCAL"
                Case AppRelatorioCategoria.Fechamento_Mensal
                    _pcCategoriaRelatorio = "FECHAMENTO MENSAL"
            End Select
        End Sub
    End Class
End Namespace
