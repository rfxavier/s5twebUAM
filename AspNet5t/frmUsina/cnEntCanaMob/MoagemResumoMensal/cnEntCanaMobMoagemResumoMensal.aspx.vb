Imports DevExpress.DataAccess.ConnectionParameters
Imports Microsoft.AspNet.Identity
Imports Oracle.DataAccess.Client
Imports System.Globalization

Public Class cnEntCanaMobMoagemResumoMensal
    Inherits System.Web.UI.Page
    Dim dtPeriodoIni As String
    Dim dtPeriodoFim As String
    Dim intSafra As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then

            ASPxDashMoagemMensalDiaria.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaMoagemMensalDiaria)
            ASPxDashMoagemMensalDiaria.DataBind()

            ASPxDashMoagemMensalAcumulada.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaMoagemMensalAcumulada)
            ASPxDashMoagemMensalAcumulada.DataBind()

            ASPxDashMoagemMensalSafra.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaMoagemMensalSafra)
            ASPxDashMoagemMensalSafra.DataBind()

            ASPxDashMoagemMensalSafraAcumulada.DashboardSource = AppUtils.GetDashboardInstance(dashboardsList.dashCnEntCanaMoagemMensalSafraAcumulada)
            ASPxDashMoagemMensalSafraAcumulada.DataBind()

            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
            dataReferencia.Date = Now

        End If

        ASPxPivotGrid1.DataSourceID = ""
        ASPxPivotGrid1.DataBind()

        dtPeriodoIni = dataReferencia.Date.ToString("yyyyMM01")
        dtPeriodoFim = New Date(dataReferencia.Date.Year, dataReferencia.Date.Month, Date.DaysInMonth(dataReferencia.Date.Year, dataReferencia.Date.Month)).ToString("yyyyMMdd")

        intSafra = dataReferencia.Date.Year

        ASPxLabelSafraMes.Text = String.Format("Safra {0} - ", Today.Year) & CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dataReferencia.Date.Month).ToUpper
    End Sub
    
    Private Sub ASPxDashMoagemMensalDiaria_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashMoagemMensalDiaria.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub
    Private Sub ASPxDashMoagemMensalDiaria_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashMoagemMensalDiaria.CustomParameters
        e.Parameters(0).Value = dtPeriodoIni
        e.Parameters(1).Value = dtPeriodoFim
    End Sub

    Private Sub ASPxDashMoagemMensalAcumulada_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashMoagemMensalAcumulada.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub
    Private Sub ASPxDashMoagemMensalAcumulada_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashMoagemMensalAcumulada.CustomParameters
        e.Parameters(0).Value = dtPeriodoIni
        e.Parameters(1).Value = dtPeriodoFim
    End Sub

    Private Sub ASPxDashMoagemMensalSafra_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashMoagemMensalSafra.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub

    Private Sub ASPxDashMoagemMensalSafra_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashMoagemMensalSafra.CustomParameters
        e.Parameters(0).Value = intSafra
    End Sub


    Private Sub ASPxDashMoagemMensalSafraAcumulada_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashMoagemMensalSafraAcumulada.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub

    Private Sub ASPxDashMoagemMensalSafraAcumulada_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashMoagemMensalSafraAcumulada.CustomParameters
        e.Parameters(0).Value = intSafra
    End Sub


    Private Sub ASPxPivotGrid1_DataBinding(sender As Object, e As EventArgs) Handles ASPxPivotGrid1.DataBinding
        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim oradb As String = AppUtils.dbConnectionString

            Dim conn As OracleConnection = New OracleConnection(oradb)
            conn.Open()
            Dim cmd As OracleCommand = New OracleCommand()
            cmd.Connection = conn
            cmd.CommandText = "SELECT XY.ID_NEGOCIOS, XY.NRO_ANO_SAFRA, XY.MES, XY.MES_N, 'REAL' TIPO, SUM(XY.TONELADA_REAL) TONELADA FROM (SELECT X.ID_NEGOCIOS, X.NRO_ANO_SAFRA, TO_CHAR(X.DIA, 'MONTH', 'NLS_DATE_LANGUAGE=PORTUGUESE') MES, TO_NUMBER(TO_CHAR(X.DIA, 'MM')) MES_N, X.DIA, X.TON_PLAN_DIA TONELADA_PLAN, SUM(A.TONELADAS) TONELADA_REAL FROM MOAGEM_CANA_HORA A, (SELECT C.ID_NEGOCIOS, C.NRO_ANO_SAFRA, C.DIA, D.TON_PLAN_DIA FROM (SELECT B.ID_NEGOCIOS, B.SAFR_ANO NRO_ANO_SAFRA, B.SAFR_INICIO + ROWNUM - 1 DIA FROM DUAL, (SELECT * FROM SISAGRI.SAFRA B WHERE B.SAFR_SAFRA_ATUAL = '*') B CONNECT BY LEVEL <= B.SAFR_FIM - B.SAFR_INICIO + 1) C, (SELECT A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO, ROUND(SUM(TON_PLAN_HORA * 24)) TON_PLAN_DIA FROM SISCOMAG.V_META_COLHEITA A GROUP BY A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO) D WHERE C.DIA BETWEEN D.DATA_INICIO_PERIODO AND D.DATA_FINAL_PERIODO) X WHERE A.ID_NEGOCIOS(+) = X.ID_NEGOCIOS AND A.NRO_ANO_SAFRA(+) = X.NRO_ANO_SAFRA AND A.DIA(+) = X.DIA GROUP BY X.ID_NEGOCIOS, X.NRO_ANO_SAFRA, TO_CHAR(X.DIA, 'MONTH', 'NLS_DATE_LANGUAGE=PORTUGUESE'), TO_NUMBER(TO_CHAR(X.DIA, 'MM')), X.DIA, X.TON_PLAN_DIA ORDER BY A.DIA) XY GROUP BY XY.ID_NEGOCIOS, XY.NRO_ANO_SAFRA, XY.MES, XY.MES_N UNION ALL SELECT XY.ID_NEGOCIOS, XY.NRO_ANO_SAFRA, XY.MES, XY.MES_N, 'PLANEJADA' TIPO, SUM(CASE WHEN(XY.MES_N < TO_NUMBER(TO_CHAR(TRUNC(SYSDATE),'MM'))) THEN XY.TONELADA_REAL ELSE XY.TONELADA_PLAN END) TONELADA FROM (SELECT X.ID_NEGOCIOS, X.NRO_ANO_SAFRA, TO_CHAR(X.DIA, 'MONTH', 'NLS_DATE_LANGUAGE=PORTUGUESE') MES, TO_NUMBER(TO_CHAR(X.DIA, 'MM')) MES_N, X.DIA, X.TON_PLAN_DIA TONELADA_PLAN, SUM(A.TONELADAS) TONELADA_REAL FROM MOAGEM_CANA_HORA A, (SELECT C.ID_NEGOCIOS, C.NRO_ANO_SAFRA, C.DIA, D.TON_PLAN_DIA FROM (SELECT B.ID_NEGOCIOS, B.SAFR_ANO NRO_ANO_SAFRA, B.SAFR_INICIO + ROWNUM - 1 DIA FROM DUAL, (SELECT * FROM SISAGRI.SAFRA B WHERE B.SAFR_SAFRA_ATUAL = '*') B CONNECT BY LEVEL <= B.SAFR_FIM - B.SAFR_INICIO + 1) C, (SELECT A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO, ROUND(SUM(TON_PLAN_HORA * 24)) TON_PLAN_DIA FROM SISCOMAG.V_META_COLHEITA A GROUP BY A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO) D WHERE C.DIA BETWEEN D.DATA_INICIO_PERIODO AND D.DATA_FINAL_PERIODO) X WHERE A.ID_NEGOCIOS(+) = X.ID_NEGOCIOS AND A.NRO_ANO_SAFRA(+) = X.NRO_ANO_SAFRA AND A.DIA(+) = X.DIA GROUP BY X.ID_NEGOCIOS, X.NRO_ANO_SAFRA, TO_CHAR(X.DIA, 'MONTH', 'NLS_DATE_LANGUAGE=PORTUGUESE'), TO_NUMBER(TO_CHAR(X.DIA, 'MM')), X.DIA, X.TON_PLAN_DIA ORDER BY A.DIA) XY GROUP BY XY.ID_NEGOCIOS, XY.NRO_ANO_SAFRA, XY.MES, XY.MES_N"

            cmd.CommandType = CommandType.Text

            Dim dr As OracleDataReader = cmd.ExecuteReader()

            ASPxPivotGrid1.DataSource = dr
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            ASPxPivotGrid1.DataSource = S5TUam.RES_MENSAL_GRIDCollection.LoadAll
        End If
    End Sub

    Private Sub ASPxPivotGrid1_CustomFieldSort(sender As Object, e As DevExpress.Web.ASPxPivotGrid.PivotGridCustomFieldSortEventArgs) Handles ASPxPivotGrid1.CustomFieldSort
        If e.Field.FieldName <> "MES" Then Return
        e.Handled = True

        Dim mes1 As Integer = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "MES_N")
        Dim mes2 As Integer = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "MES_N")

        If mes1 > mes2 Then
            e.Result = 1
        ElseIf mes1 = mes2 Then
            e.Result = 0
        ElseIf mes1 < mes2 Then
            e.Result = -1
        End If
    End Sub
End Class