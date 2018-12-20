Namespace S5T
    Partial Public Class MenuPermissao
        Protected Shared Sub InserePermissoesPartial(ByVal oSistema As S5T.Sistema, ByVal oUsuario As S5T.Usuario, ByVal arrToolStrips As System.Array)
            S5T.MenuPermissaoCollection.DeleteBySistemaUsuario(oSistema, oUsuario)

            Dim flgPermissao As String = "N"

            For Each ObjMenu In S5T.MenuCollection.LoadByoSistema(oSistema)
                If Array.IndexOf(arrToolStrips, ObjMenu.pNomeToolStrip) >= 0 Then
                    flgPermissao = "S"
                Else
                    flgPermissao = "N"
                End If

                Dim objPerm As New S5T.MenuPermissao

                objPerm.oSistema = oSistema
                objPerm.oUsuario = oUsuario
                objPerm.pNomeToolStripPerm = ObjMenu.pNomeToolStrip
                objPerm.pFlgPermissao = flgPermissao
                objPerm.Save()
            Next

            'For Each strToolStrip In arrToolStrips
            '    Dim objPerm As New S5T.MenuPermissao

            '    objPerm.oSistema = oSistema
            '    objPerm.oUsuario = oUsuario
            '    objPerm.pNomeToolStripPerm = strToolStrip
            '    objPerm.Save()
            'Next

        End Sub

        Protected Shared Function PesquisaPermissoesPartial(ByVal parCodSistema As Integer, ByVal parCodUsuario As Integer) As System.Collections.Generic.List(Of S5T.MenuVwPerm)
            If parCodSistema = 0 Or parCodUsuario = 0 Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException("Campos não preenchidos")
                Return Nothing
            Else
                Dim objMenuCollection As List(Of S5T.MenuVwPerm) = S5T.MenuCollection.LoadBySistemaVwPerm(S5T.Usuario.LoadByCodigo(parCodUsuario).pId, S5T.Sistema.LoadBypCodigo(parCodSistema).pId)

                If objMenuCollection.Count = 0 Then
                    Throw New CodeFluent.Runtime.CodeFluentValidationException("Itens de menu não encontrados")
                    Return Nothing
                Else
                    Return objMenuCollection
                End If
            End If
        End Function
    End Class
End Namespace
