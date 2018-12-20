Imports Oracle.DataAccess.Client

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ASPxGridView1.DataSourceID = ""
        ASPxGridView1.DataBind()

    End Sub

    Private Sub ASPxGridView1_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView1.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        conn.Open()
        Dim cmd As OracleCommand = New OracleCommand()
        cmd.Connection = conn
        cmd.CommandText = "SELECT A.ID_NEGOCIOS, A.NRO_ANO_SAFRA, TO_CHAR(A.DIA, 'MONTH','NLS_DATE_LANGUAGE=PORTUGUESE') MES, A.DIA, X.TON_PLAN_DIA TONELADA_PLAN, SUM(A.TONELADAS) TONELADA_REAL FROM MOAGEM_CANA_HORA A, (SELECT C.DIA, D.TON_PLAN_DIA FROM (SELECT B.SAFR_INICIO + ROWNUM - 1 DIA FROM DUAL, (SELECT * FROM SISAGRI.SAFRA B WHERE B.SAFR_SAFRA_ATUAL = '*') B CONNECT BY LEVEL <= B.SAFR_FIM - B.SAFR_INICIO + 1) C, (SELECT A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO, ROUND(SUM(TON_PLAN_HORA * 24)) TON_PLAN_DIA FROM SISCOMAG.V_META_COLHEITA A GROUP BY A.DATA_INICIO_PERIODO, A.DATA_FINAL_PERIODO) D WHERE C.DIA BETWEEN D.DATA_INICIO_PERIODO AND D.DATA_FINAL_PERIODO) X WHERE A.DIA = X.DIA GROUP BY A.ID_NEGOCIOS, A.NRO_ANO_SAFRA, TO_CHAR(A.DIA, 'MONTH','NLS_DATE_LANGUAGE=PORTUGUESE'), A.DIA, X.TON_PLAN_DIA ORDER BY A.DIA"
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader()

        ASPxGridView1.DataSource = dr

    End Sub
End Class