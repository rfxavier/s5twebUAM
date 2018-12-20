Imports Oracle.DataAccess.Client
Imports Microsoft.AspNet.Identity

Public Class cnEntCanaAcompProdutividade1Corte
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
            cmd.CommandText = "SELECT ROWNUM, A.* FROM (SELECT TRUNC(A.PROP_CODIGO) PROP_CODIGO, A.DS_NOME_PROPRIEDADE, TRUNC(A.NRO_CORTE) NRO_CORTE, ROUND(SUM(A.QT_AREA_COLHIDA), 2) QT_AREA_COLHIDA, TRUNC(A.IDADE) IDADE, A.TIPO_PROPRIEDADE, ROUND(SUM(A.QT_TON_ENTREGUE), 3) QT_TON_ENTREGUE, ROUND(A.RENDIMENTO_PLAN, 0) RENDIMENTO_PLAN, ROUND(DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA)))) RENDIMENTO_REAL, ROUND(((DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA))) / DECODE(NVL(SUM(A.QT_TON_ENTREGUE), 0), 0, 0, (SUM(A.RENDIMENTO_PLAN * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE)))) - 1) * 100) DESVIO, ROUND(DECODE(SUM(A.QT_TON_ENTREGUE_BROCA), 0, 0, (SUM(A.PORC_BROCA * A.QT_TON_ENTREGUE_BROCA) / SUM(A.QT_TON_ENTREGUE_BROCA))), 2) PORC_BROCA, ROUND(DECODE(SUM(A.PERDA_AREA), 0, 0, (SUM(PERDA_TOTAL) / SUM(A.PERDA_AREA))), 3) PERDAS, A.INCENDIO, MAX(A.DATA_INCENDIO) DATA_INCENDIO, MAX(A.DT_DESSECACAO) DT_DESSECACAO, MAX(A.DT_CALAGEM) DT_CALAGEM, MAX(A.DT_PLANTIO) DT_PLANTIO, A.TIPO_PLANTIO, A.EMPRESA_PLANTIO, ROUND(AVG(A.STAND)) STAND, A.TIPO_ADUBACAO, A.TRAT_TOLETES, MAX(A.DT_HERB_CANA_PLANTA) DT_HERB_CANA_PLANTA, A.SEMANA_ENCERRAMENTO FROM BI4T.V_PRODUTIVIDADE_1CORTE A GROUP BY A.PROP_CODIGO, A.DS_NOME_PROPRIEDADE, A.NRO_CORTE, A.IDADE, A.TIPO_PROPRIEDADE, A.RENDIMENTO_PLAN, A.INCENDIO, A.TIPO_PLANTIO, A.EMPRESA_PLANTIO, A.TIPO_ADUBACAO, A.TRAT_TOLETES, A.SEMANA_ENCERRAMENTO) A"
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader() 'As OracleDataReader
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            dr = S5TUam.ACOMP_PROD_1CORTECollection.LoadAll
        End If

        ASPxGridView1.DataSource = dr
    End Sub

    Protected Sub ASPxGridView1_AutoFilterCellEditorInitialize(sender As Object, e As DevExpress.Web.ASPxGridViewEditorEventArgs) Handles ASPxGridView1.AutoFilterCellEditorInitialize
        If TypeOf e.Editor Is DevExpress.Web.ASPxTextBox Then
            TryCast(e.Editor, DevExpress.Web.ASPxTextBox).DisplayFormatString = "#0"
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
            cmd.CommandText = "SELECT ROWNUM, TRUNC(A.PROP_CODIGO) PROP_CODIGO, A.DS_NOME_PROPRIEDADE, TRUNC(A.TALHAO) TALHAO, TRUNC(A.NRO_CORTE) NRO_CORTE, ROUND(A.QT_AREA_COLHIDA, 2) QT_AREA_COLHIDA, TRUNC(A.IDADE) IDADE, A.TIPO_PROPRIEDADE, ROUND(A.QT_TON_ENTREGUE, 2) QT_TON_ENTREGUE, ROUND(A.RENDIMENTO_PLAN, 0) RENDIMENTO_PLAN, ROUND(A.RENDIMENTO_REAL, 0) RENDIMENTO_REAL, ROUND(A.DESVIO, 0) DESVIO, ROUND(A.PORC_BROCA, 2) PORC_BROCA, ROUND(A.PERDA, 2) PERDAS, A.INCENDIO, A.DATA_INCENDIO, A.DT_DESSECACAO, A.DT_CALAGEM, A.DT_PLANTIO, A.TIPO_PLANTIO, A.EMPRESA_PLANTIO, ROUND(A.STAND, 0) STAND, A.TIPO_ADUBACAO, A.TRAT_TOLETES, A.DT_HERB_CANA_PLANTA, A.SEMANA_ENCERRAMENTO FROM BI4T.V_PRODUTIVIDADE_1CORTE A"
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader() 'As OracleDataReader 
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            dr = S5TUam.ACOMP_PROD_1CORTE_TALHAOCollection.LoadAll
        End If

        ASPxGridView2.DataSource = dr

    End Sub
End Class