Imports DevExpress.DataAccess.ConnectionParameters
Imports Microsoft.AspNet.Identity
Imports Oracle.DataAccess.Client

Public Class cnEntCanaMobMoagemCanaHora
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) And (Not IsCallback) Then
            ASPxDashboardViewer1.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaMobMoagemCanaHora)
            ASPxDashboardViewer1.DataBind()

            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

            If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                dataReferencia.Date = Now 'New DateTime(2014, 10, 5, 10, 0, 0) 'Now
                ASPxTimer1.Enabled = True
            ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                dataReferencia.Date = New DateTime(2015, 4, 27, 17, 0, 0) 'Now
                ASPxTimer1.Enabled = False
            End If
        End If

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim oradb As String = AppUtils.dbConnectionString

            Dim conn As OracleConnection = New OracleConnection(oradb)
            Dim cmd As OracleCommand
            conn.Open()

            'TRATAMENTO PARA MOSTRAR MÉDIA TON / HORA
            If Now.ToString("yyyyMMddHH") = dataReferencia.Date.ToString("yyyyMMddHH") Then
                'HORA ABERTA
                cmd = New OracleCommand("SELECT ROUND(SUM(MOAGEM_CANA_HORA_TOTAL.TONELADAS) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 2) TON_HORA_MEDIA, ROUND(SUM(MOAGEM_CANA_HORA_TOTAL.VIAGEM) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 1) VIAGEM_MEDIA FROM BI4T.MOAGEM_CANA_HORA MOAGEM_CANA_HORA_TOTAL WHERE TO_CHAR(MOAGEM_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || MOAGEM_CANA_HORA_TOTAL.HORA BETWEEN :parDataHoraIni and :parDataHoraFim and TO_CHAR(MOAGEM_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || SUBSTR(MOAGEM_CANA_HORA_TOTAL.HORA,1,2) <> SUBSTR(:parDataHoraFim,1,10)", conn) With {.CommandType = CommandType.Text}
            Else
                'HORA FECHADA
                cmd = New OracleCommand("SELECT ROUND(SUM(MOAGEM_CANA_HORA_TOTAL.TONELADAS) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 2) TON_HORA_MEDIA, ROUND(SUM(MOAGEM_CANA_HORA_TOTAL.VIAGEM) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 1) VIAGEM_MEDIA FROM BI4T.MOAGEM_CANA_HORA MOAGEM_CANA_HORA_TOTAL WHERE TO_CHAR(MOAGEM_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || MOAGEM_CANA_HORA_TOTAL.HORA BETWEEN :parDataHoraIni and :parDataHoraFim", conn) With {.CommandType = CommandType.Text}
            End If


            cmd.Parameters.Add(":parDataHoraIni", OracleDbType.Varchar2).Value = dataReferencia.Date.AddHours(-12).ToString("yyyyMMddHH:mm")
            cmd.Parameters.Add(":parDataHoraFim", OracleDbType.Varchar2).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm")

            'ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", 0)
            ASPxLabelTonHoraMedia.Text = String.Format("{0:#,#0} Ton/Hora", 0)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()

                If Not IsDBNull(dr.Item("TON_HORA_MEDIA")) Then
                    'ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", Convert.ToDouble(dr.Item("TON_HORA_MEDIA")))
                    ASPxLabelTonHoraMedia.Text = String.Format("{0:#,#0} Ton/Hora", Convert.ToDouble(dr.Item("TON_HORA_MEDIA")))
                    ASPxLabelViagemMedia.Text = String.Format("{0:#,#0.0}", Convert.ToDouble(dr.Item("VIAGEM_MEDIA")))
                End If
            End If

            ASPxImage1.ImageUrl = ""

            cmd2 = New OracleCommand(String.Format("select sum(ton_plan_hora) ton_plan_hora from siscomag.v_meta_colheita where to_date('{0}','DDMMYYYY') between data_inicio_periodo and data_final_periodo", dataReferencia.Date.ToString("ddMMyyyy")), conn) With {.CommandType = CommandType.Text}

            cmd2.Parameters.Add(":parDataHoraFim", OracleDbType.Varchar2).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm")
            dr2 = cmd2.ExecuteReader()
            If dr2.HasRows Then
                dr2.Read()

                If Not IsDBNull(dr2.Item("TON_PLAN_HORA")) And Not IsDBNull(dr.Item("TON_HORA_MEDIA")) Then
                    If Convert.ToDouble(dr.Item("TON_HORA_MEDIA")) >= Convert.ToDouble(dr2.Item("TON_PLAN_HORA")) Then
                        ASPxImage1.ImageUrl = "~/Content/Images/upArrowGreen.jpg"
                    Else
                        ASPxImage1.ImageUrl = "~/Content/Images/dnArrowRed.jpg"

                    End If
                End If
            End If

            'TRATAMENTO PARA MOSTRAR MÉDIA TONELADAS ACUMULADAS / DIA, DESDE AS 00:00
            cmd = New OracleCommand("select SUM(TONELADAS) TON_DIA FROM BI4T.MOAGEM_CANA_HORA MOAGEM_CANA_HORA_DIA WHERE TO_CHAR(MOAGEM_CANA_HORA_DIA.DIA, 'YYYYMMDD') || MOAGEM_CANA_HORA_DIA.HORA BETWEEN :parDataHoraIni and :parDataHoraFim", conn) With {.CommandType = CommandType.Text}

            cmd.Parameters.Add(":parDataHoraIni", OracleDbType.Varchar2).Value = dataReferencia.Date.ToString("yyyyMMdd") & "00:00"
            cmd.Parameters.Add(":parDataHoraFim", OracleDbType.Varchar2).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm")

            'ASPxLabelTonDia.Text = String.Format("Dia: {0:#,#0} Ton", 0)
            ASPxLabelTonDia.Text = String.Format("{0:#,#0} Ton", 0)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()

                If Not IsDBNull(dr.Item("TON_DIA")) Then
                    'ASPxLabelTonDia.Text = String.Format("Dia: {0:#,#0} Ton", Convert.ToDouble(dr.Item("TON_DIA")))
                    ASPxLabelTonDia.Text = String.Format("{0:#,#0} Ton", Convert.ToDouble(dr.Item("TON_DIA")))
                End If
            End If
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", 0)

            Dim CanaHoraDia = S5TUam.MOAGEM_CANA_HORACollection.LoadByDIA(1, dataReferencia.Date)

            If CanaHoraDia.Count > 0 Then
                Dim CanaHoraDia12Horas = CanaHoraDia.ToList.FindAll(Function(x) x.HORA >= String.Format("{0:00}", (dataReferencia.Date.Hour - 12)) & ":00")

                Dim varMediaCana12Horas = CanaHoraDia12Horas.Sum(Function(x) x.TONELADAS) / 12

                ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", varMediaCana12Horas)

                ASPxLabelTonDia.Text = String.Format("{0:#,#0} Ton", CanaHoraDia12Horas.Sum(Function(x) x.TONELADAS))

            End If

            'ASPxImage1.ImageUrl = ""
            ASPxImage1.ImageUrl = "~/Content/Images/upArrowGreen.jpg"
            'ASPxImage1.ImageUrl = "~/Content/Images/dnArrowRed.jpg"
        End If
    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
        'MsgBox(dataReferencia.Date)
    End Sub

    Private Sub ASPxDashboardViewer1_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashboardViewer1.CustomParameters

        e.Parameters(0).Value = dataReferencia.Date.AddHours(-12).ToString("yyyyMMddHH:mm")
        e.Parameters(1).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm") '"2014100613:00"

    End Sub

End Class