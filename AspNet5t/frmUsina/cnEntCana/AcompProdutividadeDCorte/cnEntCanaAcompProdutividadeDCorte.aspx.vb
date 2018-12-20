Imports Oracle.DataAccess.Client
Imports Microsoft.AspNet.Identity

Public Class cnEntCanaAcompProdutividadeDCorte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)
        End If

        ASPxGridView1.DataSourceID = ""
        ASPxGridView2.DataSourceID = ""

        ASPxGridView1.DataBind()
        ASPxGridView2.DataBind()
    End Sub

    Protected Sub ASPxGridView1_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView1.DataBinding
        Dim dr As Object = Nothing
        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim oradb As String = AppUtils.dbConnectionString

            Dim conn As OracleConnection = New OracleConnection(oradb)
            conn.Open()
            Dim cmd As OracleCommand = New OracleCommand()
            cmd.Connection = conn
            cmd.CommandText = "SELECT ROWNUM, A.* FROM (SELECT TRUNC(A.PROP_CODIGO) PROP_CODIGO, A.DS_NOME_PROPRIEDADE, TRUNC(A.NRO_CORTE) NRO_CORTE, ROUND(SUM(A.QT_AREA_COLHIDA), 2) QT_AREA_COLHIDA, ROUND(SUM(A.IDADE * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE), 2) IDADE, A.TIPO_PROPRIEDADE, ROUND(SUM(A.QT_TON_ENTREGUE), 2) QT_TON_ENTREGUE, ROUND(DECODE(NVL(SUM(A.QT_TON_ENTREGUE), 0), 0, 0, (SUM(A.RENDIMENTO_PLAN * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE))), 0) RENDIMENTO_PLAN, ROUND(DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA)))) RENDIMENTO_REAL, ROUND(((DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA))) / DECODE(NVL(SUM(A.QT_TON_ENTREGUE), 0), 0, 0, (SUM(A.RENDIMENTO_PLAN * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE)))) - 1) * 100) DESVIO, ROUND(DECODE(SUM(A.QT_TON_ENTREGUE_BROCA), 0, 0, (SUM(A.PORC_BROCA * A.QT_TON_ENTREGUE_BROCA) / SUM(A.QT_TON_ENTREGUE_BROCA))), 2) PORC_BROCA, ROUND(DECODE(SUM(A.PERDA_AREA), 0, 0, (SUM(PERDA_TOTAL) / SUM(A.PERDA_AREA))), 3) PERDAS, MIN(A.DT_COLHEITA_ANTERIOR) DT_COLHEITA_ANTERIOR, A.TIPO_ADUBACAO, MIN(A.DT_ADUBACAO) DT_ADUBACAO, TRUNC(MIN(A.DT_ADUBACAO) - MIN(A.DT_COLHEITA_ANTERIOR)) DIF_DIAS_ADUB, A.TIPO_HERBICIDA, MIN(A.DT_HERBICIDA) DT_HERBICIDA, TRUNC(MIN(A.DT_HERBICIDA) - MIN(A.DT_COLHEITA_ANTERIOR)) DIF_DIAS_HERB, A.INCENDIO, MIN(A.DATA_INCENDIO) DATA_INCENDIO, A.FERTIRRIGACAO, MIN(A.DT_FERTIRRIGACAO) DT_FERTIRRIGACAO, A.SEMANA_ENCERRAMENTO FROM BI4T.V_PRODUTIVIDADE_DCORTE A GROUP BY A.PROP_CODIGO, A.DS_NOME_PROPRIEDADE, A.NRO_CORTE, A.TIPO_PROPRIEDADE, A.TIPO_ADUBACAO, A.TIPO_HERBICIDA, A.INCENDIO, A.FERTIRRIGACAO, A.SEMANA_ENCERRAMENTO) A"
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader() 'As OracleDataReader
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            dr = S5TUam.ACOMP_PROD_DCORTECollection.LoadAll
        End If

        ASPxGridView1.DataSource = dr

    End Sub

    Protected Sub ASPxGridView1_AutoFilterCellEditorInitialize(sender As Object, e As DevExpress.Web.ASPxGridViewEditorEventArgs) Handles ASPxGridView1.AutoFilterCellEditorInitialize
        If TypeOf e.Editor Is DevExpress.Web.ASPxTextEdit Then
            TryCast(e.Editor, DevExpress.Web.ASPxTextEdit).DisplayFormatString = "#0"
        End If
    End Sub

    Protected Sub ASPxGridView2_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView2.DataBinding
        Dim dr As Object = Nothing
        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim oradb As String = AppUtils.dbConnectionString

            Dim conn As OracleConnection = New OracleConnection(oradb)
            conn.Open()
            Dim cmd As OracleCommand = New OracleCommand()
            cmd.Connection = conn
            cmd.CommandText = "SELECT ROWNUM, TRUNC(PROP_CODIGO) PROP_CODIGO, DS_NOME_PROPRIEDADE, TRUNC(TALHAO) TALHAO, TRUNC(NRO_CORTE) NRO_CORTE, ROUND(QT_AREA_COLHIDA, 2) QT_AREA_COLHIDA, TRUNC(IDADE) IDADE, TIPO_PROPRIEDADE, DT_COLHEITA_ATUAL, ROUND(QT_TON_ENTREGUE, 2) QT_TON_ENTREGUE, ROUND(RENDIMENTO_PLAN, 0) RENDIMENTO_PLAN, ROUND(RENDIMENTO_REAL, 0) RENDIMENTO_REAL, ROUND(DESVIO, 0) DESVIO, ROUND(PORC_BROCA, 2) PORC_BROCA, ROUND(PERDA, 2) PERDAS, DT_COLHEITA_ANTERIOR, TIPO_ADUBACAO, DT_ADUBACAO, TRUNC(DIF_DIAS_ADUB) DIF_DIAS_ADUB, TIPO_HERBICIDA, DT_HERBICIDA, TRUNC(DIF_DIAS_HERB) DIF_DIAS_HERB, INCENDIO, DATA_INCENDIO, FERTIRRIGACAO, DT_FERTIRRIGACAO, SEMANA_ENCERRAMENTO FROM BI4T.V_PRODUTIVIDADE_DCORTE"
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader() 'As OracleDataReader 
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            dr = S5TUam.ACOMP_PROD_DCORTE_TALHAOCollection.LoadAll
        End If

        ASPxGridView2.DataSource = dr
    End Sub
End Class