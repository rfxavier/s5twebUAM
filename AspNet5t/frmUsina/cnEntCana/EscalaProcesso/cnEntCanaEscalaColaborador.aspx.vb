Imports Microsoft.AspNet.Identity
Imports Oracle.DataAccess.Client
Imports System.Globalization

Public Class cnEntCanaEscalaColaborador
    Inherits System.Web.UI.Page

    Dim oradbConn As String = AppUtils.dbConnectionString
    Dim connOraDb As OracleConnection = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

            ASPxDataRef.MinDate = New Date(Now.Year, Now.Month, Now.Day)
            ASPxDataRef.MaxDate = Now.AddDays(29)
            ASPxDataRef.Date = New Date(Now.Year, Now.Month, Now.Day) 'New Date(2014, 10, 4) 'Now

            If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                Dim oradb As String = AppUtils.dbConnectionString

                'PROCESSO
                Dim Grupos As New List(Of String)
                ASPxComboProcesso.Items.Clear()

                Dim drProcessos As OracleDataReader = Nothing

                Dim conn As OracleConnection = New OracleConnection(oradb)
                conn.Open()

                Try
                    Dim cmdGrupos As New OracleCommand("select PROCESSO FROM BI4T.V_ESCALA_COLAB WHERE ID_NIVEL IN (6,7) GROUP BY PROCESSO ORDER BY PROCESSO", conn) With {.CommandType = CommandType.Text}

                    drProcessos = cmdGrupos.ExecuteReader()
                    If drProcessos.HasRows Then
                        ASPxComboProcesso.Items.Add("Todos os Processos")

                        Do While drProcessos.Read
                            If Not IsDBNull(drProcessos.Item("PROCESSO")) Then
                                ASPxComboProcesso.Items.Add(drProcessos.Item("PROCESSO"))
                            End If
                        Loop

                        drProcessos.Close()
                    End If
                Finally
                    conn.Close()
                    If (Not (drProcessos) Is Nothing) Then
                        drProcessos.Dispose()
                    End If
                End Try
            Else
                ASPxComboProcesso.Items.Add("Todos os Processos")
            End If

            If Not ASPxCbPanel.IsCallback Then
                'ESTÁ ENTRANDO PELA PRIMEIRA VEZ NA PÁGINA, NÃO É CALLBACK DO PANEL
                ASPxComboProcesso.SelectedIndex = 0
            Else
                'É CALLBACK DO PANEL, ZERA O hfFrenteTipoAtual PARA TAMBÉM ZERAR O GRID DE DETALHAMENTO POR EQUIPAMENTO ASPxGridView2
                ASPxHiddenField.Set("hfProcessoAtual", "")
            End If
        End If

        ASPxGridView1.Columns("DIA01").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(0).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(0).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(0).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA02").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(1).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(1).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(1).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA03").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(2).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(2).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(2).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA04").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(3).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(3).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(3).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA05").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(4).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(4).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(4).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA06").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(5).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(5).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(5).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA07").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(6).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(6).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(6).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA08").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(7).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(7).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(7).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA09").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(8).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(8).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(8).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA10").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(9).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(9).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(9).DayOfWeek).Replace("-", " ")

        ASPxGridView1.Columns("DIA11").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(10).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(10).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(10).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA12").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(11).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(11).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(11).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA13").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(12).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(12).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(12).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA14").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(13).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(13).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(13).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA15").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(14).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(14).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(14).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA16").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(15).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(15).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(15).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA17").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(16).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(16).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(16).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA18").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(17).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(17).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(17).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA19").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(18).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(18).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(18).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA20").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(19).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(19).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(19).DayOfWeek).Replace("-", " ")

        ASPxGridView1.Columns("DIA21").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(20).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(20).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(20).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA22").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(21).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(21).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(21).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA23").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(22).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(22).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(22).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA24").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(23).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(23).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(23).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA25").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(24).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(24).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(24).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA26").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(25).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(25).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(25).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA27").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(26).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(26).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(26).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA28").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(27).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(27).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(27).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA29").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(28).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(28).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(28).DayOfWeek).Replace("-", " ")
        ASPxGridView1.Columns("DIA30").Caption = New Date(Now.Year, Now.Month, Now.Day).AddDays(29).Day & "/" & New Date(Now.Year, Now.Month, Now.Day).AddDays(29).Month & " " & CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(New Date(Now.Year, Now.Month, Now.Day).AddDays(29).DayOfWeek).Replace("-", " ")

        Dim i As Integer = 0

        For i = 1 To 30
            ASPxGridView1.Columns("DIA" & i.ToString.PadLeft(2, "0")).Visible = False
        Next

        'For i = (ASPxDataRef.Date - New Date(Now.Year, Now.Month, Now.Day)).Days + 8 To 30
        For i = (ASPxDataRef.Date - New Date(Now.Year, Now.Month, Now.Day)).Days + 1 To IIf((ASPxDataRef.Date - New Date(Now.Year, Now.Month, Now.Day)).Days + 7 > 30, 30, (ASPxDataRef.Date - New Date(Now.Year, Now.Month, Now.Day)).Days + 7)
            ASPxGridView1.Columns("DIA" & i.ToString.PadLeft(2, "0")).Visible = True
        Next

        ASPxGridView1.DataSourceID = ""
        ASPxGridView1.DataSource = Nothing

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            connOraDb = New OracleConnection(oradbConn)
            connOraDb.Open()

            ASPxGridView1.DataBind()

            connOraDb.Close()
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            ASPxGridView1.DataBind()
        End If
    End Sub

    Private Sub ASPxGridView1_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView1.DataBinding
        Dim dr As Object = Nothing

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim cmd As OracleCommand

            If ASPxComboProcesso.SelectedIndex = 0 Then
                'TODOS OS PROCESSOS
                cmd = New OracleCommand("SELECT ROWNUM,PROCESSO,ESTRUTURA,MATRICULA,NOME,TURNO,DIA01,DIA02,DIA03,DIA04,DIA05,DIA06,DIA07,DIA08,DIA09,DIA10,DIA11,DIA12,DIA13,DIA14,DIA15,DIA16,DIA17,DIA18,DIA19,DIA20,DIA21,DIA22,DIA23,DIA24,DIA25,DIA26,DIA27,DIA28,DIA29,DIA30,CELULAR,ID_NIVEL,ID_TURMAS FROM BI4T.V_ESCALA_COLAB WHERE ID_NIVEL IN (6,7)", connOraDb) With {.CommandType = CommandType.Text}

                'cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxDataRef.Date
            Else
                'TEM PROCESSO ESPECÍFICO

                cmd = New OracleCommand(String.Format("SELECT ROWNUM,PROCESSO,ESTRUTURA,MATRICULA,NOME,TURNO,DIA01,DIA02,DIA03,DIA04,DIA05,DIA06,DIA07,DIA08,DIA09,DIA10,DIA11,DIA12,DIA13,DIA14,DIA15,DIA16,DIA17,DIA18,DIA19,DIA20,DIA21,DIA22,DIA23,DIA24,DIA25,DIA26,DIA27,DIA28,DIA29,DIA30,CELULAR,ID_NIVEL,ID_TURMAS FROM BI4T.V_ESCALA_COLAB WHERE ID_NIVEL IN (6,7) AND PROCESSO = '{0}'", ASPxComboProcesso.Value), connOraDb) With {.CommandType = CommandType.Text}

                'cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxDataRef.Date
                'cmd.Parameters.Add(":p1", OracleDbType.Varchar2).Value = ASPxComboProcesso.Value
            End If

            dr = cmd.ExecuteReader() 'As OracleDataReader 
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            dr = S5TUam.ESCALA_COLABCollection.LoadAll

        End If

        ASPxGridView1.DataSource = dr
    End Sub
End Class