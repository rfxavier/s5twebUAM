Imports DevExpress.DataAccess.ConnectionParameters
Imports Oracle.DataAccess.Client
Imports Microsoft.AspNet.Identity

Public Class cnEntCanaMobEntradasCanaHoraDualGeralFrente
    Inherits System.Web.UI.Page

    Private Class S5TFrenteColheita
        Private _pCodFrente As Integer
        Public Property pCodFrente() As Integer
            Get
                Return _pCodFrente
            End Get
            Set(ByVal value As Integer)
                _pCodFrente = value
            End Set
        End Property

        Private _pDescFrente As String
        Public Property pDescFrente() As String
            Get
                Return _pDescFrente
            End Get
            Set(ByVal value As String)
                _pDescFrente = value
            End Set
        End Property
    End Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dr As OracleDataReader = Nothing


        If (Not IsPostBack) And (Not IsCallback) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

            If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                dataReferencia.Date = Now 'New DateTime(2014, 10, 5, 10, 0, 0) 'Now
                ASPxTimer1.Enabled = True

                'FAZ TRATAMENTO DE FRENTES DE COLHEITA
                Dim dsComboFrentes = New List(Of S5TFrenteColheita)

                Dim oradbConn As String = AppUtils.dbConnectionString

                Dim oradb As String = String.Format(oradbConn)

                Try
                    Dim conn As OracleConnection = New OracleConnection(oradb)
                    conn.Open()

                    Dim cmd As New OracleCommand("SELECT V.FRENTE FROM BI4T.V_ACESSO_DET V WHERE V.USUARIO = :p0 and V.FRENTE IS NOT NULL", conn) With {.CommandType = CommandType.Text}

                    cmd.Parameters.Add(":p0", OracleDbType.Varchar2).Value = Context.User.Identity.Name.ToUpper

                    Try
                        dr = cmd.ExecuteReader()
                        If dr.HasRows Then
                            'USUÁRIO TEM INDICAÇÃO DE FRENTES
                            Do While dr.Read
                                Dim objFrenteColheita = New S5TFrenteColheita
                                objFrenteColheita.pCodFrente = Convert.ToInt16(dr.Item("FRENTE"))
                                objFrenteColheita.pDescFrente = "FC" & dr.Item("FRENTE").ToString.Trim.PadLeft(2, "0")
                                dsComboFrentes.Add(objFrenteColheita)
                            Loop

                            dr.Close()
                        Else
                            'USUÁRIO TEM PERMISSÃO PARA TODAS AS FRENTES
                            Dim objFrenteColheitaTodas = New S5TFrenteColheita
                            objFrenteColheitaTodas.pCodFrente = 0
                            objFrenteColheitaTodas.pDescFrente = "(Todas as Frentes)"
                            dsComboFrentes.Add(objFrenteColheitaTodas)

                            For i = 1 To 9
                                Dim objFrenteColheita = New S5TFrenteColheita
                                objFrenteColheita.pCodFrente = i
                                objFrenteColheita.pDescFrente = "FC" & i.ToString.Trim.PadLeft(2, "0")
                                dsComboFrentes.Add(objFrenteColheita)
                            Next
                        End If
                    Finally
                        If (Not (dr) Is Nothing) Then
                            dr.Dispose()
                        End If
                    End Try
                Catch ex As Exception

                End Try

                cmbFrente.DataSource = dsComboFrentes
                cmbFrente.ValueField = "pCodFrente"
                cmbFrente.ValueType = GetType(System.Int32)
                cmbFrente.TextField = "pDescFrente"
                cmbFrente.SelectedIndex = 0
                cmbFrente.DataBind()
            ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
                dataReferencia.Date = New DateTime(2015, 4, 27, 17, 0, 0) 'Now
                ASPxTimer1.Enabled = False

                Dim dsComboFrentes = New List(Of S5TFrenteColheita)

                'USUÁRIO TEM PERMISSÃO PARA TODAS AS FRENTES
                Dim objFrenteColheitaTodas = New S5TFrenteColheita
                objFrenteColheitaTodas.pCodFrente = 0
                objFrenteColheitaTodas.pDescFrente = "(Todas as Frentes)"
                dsComboFrentes.Add(objFrenteColheitaTodas)

                For i = 1 To 9
                    Dim objFrenteColheita = New S5TFrenteColheita
                    objFrenteColheita.pCodFrente = i
                    objFrenteColheita.pDescFrente = "FC" & i.ToString.Trim.PadLeft(2, "0")
                    dsComboFrentes.Add(objFrenteColheita)
                Next

                cmbFrente.DataSource = dsComboFrentes
                cmbFrente.ValueField = "pCodFrente"
                cmbFrente.ValueType = GetType(System.Int32)
                cmbFrente.TextField = "pDescFrente"
                cmbFrente.SelectedIndex = 0
                cmbFrente.DataBind()
            End If
        End If

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            If cmbFrente.Value = 0 Then
                'TODAS AS FRENTES
                ASPxDashboardViewer1.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaMobEntradaCanaHoraGeral)
                ASPxDashboardViewer1.DataBind()

                Dim oradb As String = AppUtils.dbConnectionString

                Dim conn As OracleConnection = New OracleConnection(oradb)
                Dim cmd As OracleCommand
                conn.Open()

                If Now.ToString("yyyyMMddHH") = dataReferencia.Date.ToString("yyyyMMddHH") Then
                    'HORA ABERTA
                    cmd = New OracleCommand("SELECT ROUND(SUM(ENTRADA_CANA_HORA_TOTAL.TONELADAS) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 2) TON_HORA_MEDIA, ROUND(SUM(ENTRADA_CANA_HORA_TOTAL.VIAGEM) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 1) VIAGEM_MEDIA FROM BI4T.ENTRADA_CANA_HORA ENTRADA_CANA_HORA_TOTAL WHERE TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || ENTRADA_CANA_HORA_TOTAL.HORA BETWEEN :parDataHoraIni and :parDataHoraFim and TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || SUBSTR(ENTRADA_CANA_HORA_TOTAL.HORA,1,2) <> SUBSTR(:parDataHoraFim,1,10)", conn) With {.CommandType = CommandType.Text}
                Else
                    'HORA FECHADA
                    cmd = New OracleCommand("SELECT ROUND(SUM(ENTRADA_CANA_HORA_TOTAL.TONELADAS) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 2) TON_HORA_MEDIA, ROUND(SUM(ENTRADA_CANA_HORA_TOTAL.VIAGEM) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 1) VIAGEM_MEDIA FROM BI4T.ENTRADA_CANA_HORA ENTRADA_CANA_HORA_TOTAL WHERE TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || ENTRADA_CANA_HORA_TOTAL.HORA BETWEEN :parDataHoraIni and :parDataHoraFim", conn) With {.CommandType = CommandType.Text}
                End If


                cmd.Parameters.Add(":parDataHoraIni", OracleDbType.Varchar2).Value = dataReferencia.Date.AddHours(-12).ToString("yyyyMMddHH:mm")
                cmd.Parameters.Add(":parDataHoraFim", OracleDbType.Varchar2).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm")

                ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", 0)
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    'ASPxLabelTonHoraMedia.Text = String.Format(0, "Média: {0:#,#0.00} Ton/Hora")
                    If Not IsDBNull(dr.Item("TON_HORA_MEDIA")) Then
                        ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", Convert.ToDouble(dr.Item("TON_HORA_MEDIA")))
                        ASPxLabelViagemMedia.Text = String.Format("{0:#,#0.0}", Convert.ToDouble(dr.Item("VIAGEM_MEDIA")))
                    End If
                End If

                ASPxImage1.ImageUrl = ""

                cmd2 = New OracleCommand(String.Format("select sum(ton_plan_hora) ton_plan_hora from siscomag.v_meta_colheita where to_date('{0}','DDMMYYYY') between data_inicio_periodo and data_final_periodo", dataReferencia.Date.ToString("ddMMyyyy")), conn) With {.CommandType = CommandType.Text}

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
            Else
                'FRENTE ESPECÍFICA
                ASPxDashboardViewer1.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaMobEntradaCanaHoraPorFrente)
                ASPxDashboardViewer1.DataBind()

                Dim oradb As String = AppUtils.dbConnectionString

                Dim conn As OracleConnection = New OracleConnection(oradb)
                Dim cmd As OracleCommand
                conn.Open()

                If Now.ToString("yyyyMMddHH") = dataReferencia.Date.ToString("yyyyMMddHH") Then
                    'HORA ABERTA
                    cmd = New OracleCommand("SELECT ROUND(SUM(ENTRADA_CANA_HORA_TOTAL.TONELADAS) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 2) TON_HORA_MEDIA FROM BI4T.ENTRADA_CANA_HORA ENTRADA_CANA_HORA_TOTAL WHERE ENTRADA_CANA_HORA_TOTAL.FRENTE = :p0 and TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || ENTRADA_CANA_HORA_TOTAL.HORA BETWEEN :parDataHoraIni and :parDataHoraFim and TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || SUBSTR(ENTRADA_CANA_HORA_TOTAL.HORA,1,2) <> SUBSTR(:parDataHoraFim,1,10)", conn) With {.CommandType = CommandType.Text}
                Else
                    'HORA FECHADA
                    cmd = New OracleCommand("SELECT ROUND(SUM(ENTRADA_CANA_HORA_TOTAL.TONELADAS) / (((max(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI')) - min(to_date(to_char(dia, 'DDMMYYYY') || HORA, 'DDMMYYYYHH24:MI'))) * 1440) / 60 + 1), 2) TON_HORA_MEDIA FROM BI4T.ENTRADA_CANA_HORA ENTRADA_CANA_HORA_TOTAL WHERE ENTRADA_CANA_HORA_TOTAL.FRENTE = :p0 and TO_CHAR(ENTRADA_CANA_HORA_TOTAL.DIA, 'YYYYMMDD') || ENTRADA_CANA_HORA_TOTAL.HORA BETWEEN :parDataHoraIni and :parDataHoraFim", conn) With {.CommandType = CommandType.Text}
                End If


                cmd.Parameters.Add(":p0", OracleDbType.Int16).Value = cmbFrente.Value
                cmd.Parameters.Add(":parDataHoraIni", OracleDbType.Varchar2).Value = dataReferencia.Date.AddHours(-12).ToString("yyyyMMddHH:mm")
                cmd.Parameters.Add(":parDataHoraFim", OracleDbType.Varchar2).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm")

                ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", 0)
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    'ASPxLabelTonHoraMedia.Text = String.Format(0, "Média: {0:#,#0.00} Ton/Hora")
                    If Not IsDBNull(dr.Item("TON_HORA_MEDIA")) Then
                        ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", Convert.ToDouble(dr.Item("TON_HORA_MEDIA")))
                    End If
                End If

                ASPxImage1.ImageUrl = ""

                cmd2 = New OracleCommand(String.Format("select sum(ton_plan_hora) ton_plan_hora from siscomag.v_meta_colheita where frente = :p0 and to_date('{0}','DDMMYYYY') between data_inicio_periodo and data_final_periodo", dataReferencia.Date.ToString("ddMMyyyy")), conn) With {.CommandType = CommandType.Text}

                cmd2.Parameters.Add(":p0", OracleDbType.Int16).Value = cmbFrente.Value
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
            End If
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            If cmbFrente.Value = 0 Then
                'TODAS AS FRENTES
                ASPxDashboardViewer1.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaMobEntradaCanaHoraGeral)
                ASPxDashboardViewer1.DataBind()

                ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", 0)

                Dim CanaHoraDia = S5TUam.ENTRADA_CANA_HORACollection.LoadByDIA(1, dataReferencia.Date)

                If CanaHoraDia.Count > 0 Then
                    Dim CanaHoraDia12Horas = CanaHoraDia.ToList.FindAll(Function(x) x.HORA >= String.Format("{0:00}", (dataReferencia.Date.Hour - 12)) & ":00")

                    Dim varMediaCana12Horas = CanaHoraDia12Horas.Sum(Function(x) x.TONELADAS) / 12

                    ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", varMediaCana12Horas)
                End If

                'ASPxImage1.ImageUrl = ""
                ASPxImage1.ImageUrl = "~/Content/Images/upArrowGreen.jpg"
                'ASPxImage1.ImageUrl = "~/Content/Images/dnArrowRed.jpg"
            Else
                'FRENTE ESPECÍFICA 
                ASPxDashboardViewer1.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaMobEntradaCanaHoraPorFrente)
                ASPxDashboardViewer1.DataBind()

                ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", 0)

                Dim CanaHoraDia = S5TUam.ENTRADA_CANA_HORA_FRENTECollection.LoadByDIAFRENTE(1, dataReferencia.Date, cmbFrente.Value)

                If CanaHoraDia.Count > 0 Then
                    Dim CanaHoraDia12Horas = CanaHoraDia.ToList.FindAll(Function(x) x.HORA >= String.Format("{0:00}", (dataReferencia.Date.Hour - 12)) & ":00")

                    Dim varMediaCana12Horas = CanaHoraDia12Horas.Sum(Function(x) x.TONELADAS) / 12

                    ASPxLabelTonHoraMedia.Text = String.Format("Média: {0:#,#0} Ton/Hora", varMediaCana12Horas)
                End If

                'ASPxImage1.ImageUrl = ""
                ASPxImage1.ImageUrl = "~/Content/Images/upArrowGreen.jpg"
                'ASPxImage1.ImageUrl = "~/Content/Images/dnArrowRed.jpg"

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
        'Obj.GetType() Is GetType(System.Web.UI.WebControls.DropDownList)
        If ASPxDashboardViewer1.DashboardSource Is GetType(Win_Dashboards.dashCnEntCanaMobEntradaCanaHoraGeral) Then
            'If TypeOf ASPxDashboardViewer1.DashboardSource Is Win_Dashboards.dashCnEntCanaMovMoagemCanaHoraGeral Then
            e.Parameters(0).Value = dataReferencia.Date.AddHours(-12).ToString("yyyyMMddHH:mm")
            e.Parameters(1).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm") '"2014100613:00"
        ElseIf ASPxDashboardViewer1.DashboardSource Is GetType(Win_Dashboards.dashCnEntCanaMobEntradaCanaHoraPorFrente) Then
            e.Parameters(0).Value = dataReferencia.Date.AddHours(-12).ToString("yyyyMMddHH:mm")
            e.Parameters(1).Value = dataReferencia.Date.ToString("yyyyMMddHH:mm") '"2014100613:00"
            e.Parameters(2).Value = cmbFrente.Value
        End If
    End Sub
End Class