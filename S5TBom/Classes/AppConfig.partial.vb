Imports CodeFluent.Runtime
Imports System.Text.RegularExpressions

Namespace S5T
    Partial Public Class AppConfig
        Protected Shared Function ValidaTelefonePartial(ByVal parTelefone As String, ByVal parNomeControle As String) As String
            If parTelefone IsNot Nothing Then

                If parTelefone.Length > 0 Then
                    Dim txtTelefone As String = String.Empty
                    txtTelefone = Regex.Replace(parTelefone, "[^0-9]", "")

                    Dim strTagNomeControle As String = String.Empty
                    If parNomeControle.Trim <> "" Then
                        strTagNomeControle = "[" & parNomeControle.Trim & "] "
                    Else
                        strTagNomeControle = ""
                    End If

                    If txtTelefone.Length < 10 Then
                        Throw New CodeFluentValidationException(strTagNomeControle & "Telefone inválido. Quantidade de números MENOR que permitido. DDD-prefixo-número")
                    ElseIf txtTelefone.Length > 11 Then
                        Throw New CodeFluentValidationException(strTagNomeControle & "Telefone inválido. Quantidade de números MAIOR que permitido. DDD-prefixo-número")
                    End If

                    If txtTelefone.Length = 10 Then
                        txtTelefone = "(" + txtTelefone.Substring(0, 2) + ") " + txtTelefone.Substring(2, 4) + "-" + txtTelefone.Substring(6, 4)
                    Else
                        txtTelefone = "(" + txtTelefone.Substring(0, 2) + ") " + txtTelefone.Substring(2, 5) + "-" + txtTelefone.Substring(7, 4)
                    End If

                    Return txtTelefone
                Else
                    Return ""
                End If
            Else
                Return ""
            End If



        End Function


    End Class
End Namespace
