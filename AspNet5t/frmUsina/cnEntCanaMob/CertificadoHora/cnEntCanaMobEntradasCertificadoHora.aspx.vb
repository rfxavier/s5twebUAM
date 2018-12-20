Imports DevExpress.DataAccess.ConnectionParameters
Imports Microsoft.AspNet.Identity
Imports Oracle.DataAccess.Client

Public Class cnEntCanaMobEntradasCertificadoHora
    Inherits System.Web.UI.Page

    Private Sub AtualizaPainelTop
                Dim oradb As String = AppUtils.dbConnectionString

                Dim conn As OracleConnection = New OracleConnection(oradb)
                Dim cmd As OracleCommand
                Dim cmd2 As OracleCommand
                conn.Open()

                If Now.ToString("yyyyMMddHH") = dataReferencia.Date.ToString("yyyyMMddHH") Then
                    'HORA ABERTA
                    cmd = New OracleCommand("SELECT ROUND(SUM(ENTRADA_CANA_HORA_TOTAL.TONELADAS) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 2) TON_HORA_MEDIA FROM BI4T.ENTRADA_CANA_HORA ENTRADA_CANA_HORA_TOTAL WHERE TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || ENTRADA_CANA_HORA_TOTAL.HORA BETWEEN :parDataHoraIni and :parDataHoraFim and TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || SUBSTR(ENTRADA_CANA_HORA_TOTAL.HORA,1,2) <> SUBSTR(:parDataHoraFim,1,10)", conn) With {.CommandType = CommandType.Text}
                    cmd2 = New OracleCommand("SELECT ROUND(SUM(ENTRADA_CANA_HORA_TOTAL.CERTIFICADOS) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 2) CERTIFICADOS_HORA_MEDIA FROM BI4T.CERTIFICADO_PATIO_HORA ENTRADA_CANA_HORA_TOTAL WHERE TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || ENTRADA_CANA_HORA_TOTAL.HORA BETWEEN :parDataHoraIni and :parDataHoraFim and TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || SUBSTR(ENTRADA_CANA_HORA_TOTAL.HORA,1,2) <> SUBSTR(:parDataHoraFim,1,10)", conn) With {.CommandType = CommandType.Text}
                Else
                    'HORA FECHADA
                    cmd = New OracleCommand("SELECT ROUND(SUM(ENTRADA_CANA_HORA_TOTAL.TONELADAS) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 2) TON_HORA_MEDIA FROM BI4T.ENTRADA_CANA_HORA ENTRADA_CANA_HORA_TOTAL WHERE TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || ENTRADA_CANA_HORA_TOTAL.HORA BETWEEN :parDataHoraIni and :parDataHoraFim", conn) With {.CommandType = CommandType.Text}
                    cmd2 = New OracleCommand("SELECT ROUND(SUM(ENTRADA_CANA_HORA_TOTAL.CERTIFICADOS) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 2) CERTIFICADOS_HORA_MEDIA FROM BI4T.CERTIFICADO_PATIO_HORA ENTRADA_CANA_HORA_TOTAL WHERE TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || ENTRADA_CANA_HORA_TOTAL.HORA BETWEEN :parDataHoraIni and :parDataHoraFim", conn) With {.CommandType = CommandType.Text}
                End If


                cmd.Parameters.Add(":parDataHoraIni", OracleDbType.Varchar2).Value = dataReferencia.Date.AddHours(-12).ToString("yyyyMMddHH:mm")
                cmd.Parameters.Add(":parDataHoraFim", OracleDbType.Varchar2).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm")

                cmd2.Parameters.Add(":parDataHoraIni", OracleDbType.Varchar2).Value = dataReferencia.Date.AddHours(-12).ToString("yyyyMMddHH:mm")
                cmd2.Parameters.Add(":parDataHoraFim", OracleDbType.Varchar2).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm")

                ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", 0)
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    If Not IsDBNull(dr.Item("TON_HORA_MEDIA")) Then
                        ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", Convert.ToDouble(dr.Item("TON_HORA_MEDIA")))
                    End If
                End If

                dr = cmd2.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    If Not IsDBNull(dr.Item("CERTIFICADOS_HORA_MEDIA")) Then
                        ASPxLabelCertificadosHoraMedia.Text = String.Format("Média Certificados: {0:#,#0.0}", Convert.ToDouble(dr.Item("CERTIFICADOS_HORA_MEDIA")))
                    End If
                End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) And (Not IsCallback) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

            If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                dataReferencia.Date = Now
                ASPxTimer1.Enabled = True

                ASPxDashboardViewer1.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaMobEntradasCertificadoHora)
                ASPxDashboardViewer1.DataBind()

                AtualizaPainelTop

            ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                dataReferencia.Date = New DateTime(2015, 4, 27, 17, 0, 0) 'Now
                ASPxTimer1.Enabled = False
            End If
        End If
    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub

    Protected Sub ASPxCallbackPanel2_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles ASPxCallbackPanel2.Callback
        AtualizaPainelTop
        'MsgBox(dataReferencia.Date)
    End Sub

    Private Sub ASPxDashboardViewer1_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashboardViewer1.CustomParameters

        e.Parameters(0).Value = dataReferencia.Date.AddHours(-12).ToString("yyyyMMddHH:mm")
        e.Parameters(1).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm") '"2014100613:00"

    End Sub

End Class