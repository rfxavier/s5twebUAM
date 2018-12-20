Imports DevExpress.DataAccess.ConnectionParameters
Imports Oracle.DataAccess.Client
Imports Microsoft.AspNet.Identity
Public Class cnEnRenovColetaPalha
    Inherits System.Web.UI.Page

    Dim dtPeriodoIni As Date
    Dim dtPeriodoFim As Date
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dashCanaCanaPalhaPorDia As New Win_Dashboards.dashCnEntCanaPalhaPorDia

        Dim dr As OracleDataReader = Nothing

        If (Not IsPostBack) And (Not IsCallback) Then

            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
            dataReferencia.Date = Now
        End If

        ASPxDashboardViewer1.DashboardSource = dashCanaCanaPalhaPorDia
        ASPxDashboardViewer1.DataBind()

        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        conn.Open()

        Dim cmdPeriodo As New OracleCommand(String.Format("select INICIO_PERIODO, FINAL_PERIODO from SISAGRI.V_ENTRADA_PALHA_DIA WHERE TO_DATE('{0}','DD/MM/YYYY') BETWEEN INICIO_PERIODO AND FINAL_PERIODO group by INICIO_PERIODO, FINAL_PERIODO", dataReferencia.Date.ToString("dd/MM/yyyy")), conn) With {.CommandType = CommandType.Text}

        dr = cmdPeriodo.ExecuteReader()
        If dr.HasRows Then
            dr.Read()

            dtPeriodoIni = CDate(dr.Item("INICIO_PERIODO").ToString)
            dtPeriodoFim = CDate(dr.Item("FINAL_PERIODO").ToString)
        Else
            dtPeriodoIni = dataReferencia.Date.AddDays(-30)
            dtPeriodoFim = dataReferencia.Date
        End If


        'Dim cmd As New OracleCommand("select ID_NEGOCIOS,to_char(DATA_ENTRADA,'DD/MM') AS DATA_ENTRADA,DATA_ENTRADA AS DATA_ENTRADA_DATE,PLANEJADO,REALIZADO from SISAGRI.V_ENTRADA_PALHA_DIA where DATA_ENTRADA BETWEEN :p0 and :p1", conn) With {.CommandType = CommandType.Text}

        'cmd.Parameters.Add(":p0", OracleDbType.Date).Value = dtPeriodoIni
        'cmd.Parameters.Add(":p1", OracleDbType.Date).Value = dtPeriodoFim

        'dr = cmd.ExecuteReader()
        'If dr.HasRows Then
        '    dr.Read()
        'End If

        'PREENCHE LABEL TOTAL PERÍODO + INDICADOR VISUAL
        TotalPalhaPeriodo = New OracleCommand("select sum(REALIZADO) TOTAL_REALIZADO_PERIODO, sum(PLANEJADO) TOTAL_PLANEJADO_PERIODO from SISAGRI.V_ENTRADA_PALHA_DIA where DATA_ENTRADA BETWEEN :parDataIni and :parDataFim", conn) With {.CommandType = CommandType.Text}

        TotalPalhaPeriodo.Parameters.Add(":parDataIni", OracleDbType.Date).Value = dtPeriodoIni
        TotalPalhaPeriodo.Parameters.Add(":parDataFim", OracleDbType.Date).Value = dtPeriodoFim

        ASPxImagePeriodo.ImageUrl = ""

        drTotalPalhaPeriodo = TotalPalhaPeriodo.ExecuteReader()
        If drTotalPalhaPeriodo.HasRows Then
            drTotalPalhaPeriodo.Read()
            If Not IsDBNull(drTotalPalhaPeriodo.Item("TOTAL_REALIZADO_PERIODO")) Then
                ASPxLabelPalhaMes.Text = String.Format("{0:#,#0}", Convert.ToDouble(drTotalPalhaPeriodo.Item("TOTAL_REALIZADO_PERIODO"))) & " Ton"
            Else
                ASPxLabelPalhaMes.Text = "0,00" & " Ton"
            End If

            If Not IsDBNull(drTotalPalhaPeriodo.Item("TOTAL_REALIZADO_PERIODO")) And Not IsDBNull(drTotalPalhaPeriodo.Item("TOTAL_PLANEJADO_PERIODO")) Then
                If Convert.ToDouble(drTotalPalhaPeriodo.Item("TOTAL_REALIZADO_PERIODO")) >= Convert.ToDouble(drTotalPalhaPeriodo.Item("TOTAL_PLANEJADO_PERIODO")) Then
                    ASPxImagePeriodo.ImageUrl = "~/Content/Images/upArrowGreen.jpg"
                Else
                    ASPxImagePeriodo.ImageUrl = "~/Content/Images/dnArrowRed.jpg"

                End If
            End If
        End If

        'PREENCHE LABEL TOTAL SAFRA
        cmdTotalPalhaSafra = New OracleCommand("select sum(REALIZADO) TOTAL_REALIZADO_SAFRA, sum(PLANEJADO) TOTAL_PLANEJADO_SAFRA from SISAGRI.V_ENTRADA_PALHA_DIA where DATA_ENTRADA BETWEEN :parDataIni and :parDataFim", conn) With {.CommandType = CommandType.Text}

        cmdTotalPalhaSafra.Parameters.Add(":parDataIni", OracleDbType.Date).Value = CDate(dataReferencia.Date.ToString("01/01/yyyy"))
        cmdTotalPalhaSafra.Parameters.Add(":parDataFim", OracleDbType.Date).Value = CDate(dataReferencia.Date.ToString("31/12/yyyy"))

        drTotalPalhaSafra = cmdTotalPalhaSafra.ExecuteReader()
        If drTotalPalhaSafra.HasRows Then
            drTotalPalhaSafra.Read()
            If Not IsDBNull(drTotalPalhaSafra.Item("TOTAL_REALIZADO_SAFRA")) Then
                ASPxLabelPalhaSafra.Text = String.Format("{0:#,#0}", Convert.ToDouble(drTotalPalhaSafra.Item("TOTAL_REALIZADO_SAFRA"))) & " Ton"
            Else
                ASPxLabelPalhaSafra.Text = "0,00" & " Ton"
            End If
        End If


    End Sub

    Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
        'MsgBox(dataReferencia.Date)
    End Sub

    Private Sub ASPxDashboardViewer1_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashboardViewer1.CustomParameters
        e.Parameters(0).Value = dtPeriodoIni.ToString("yyyyMMdd")
        e.Parameters(1).Value = dtPeriodoFim.ToString("yyyyMMdd")
    End Sub
End Class