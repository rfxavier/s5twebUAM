Imports Oracle.DataAccess.Client

Public Class WebFormTmpRemunVarMatriz
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsCallback) And Not (Page.IsPostBack) Then
            ASPxPivotGrid1.DataSourceID = ""
            ASPxPivotGrid1.DataBind()
        End If
    End Sub

    Protected Sub ASPxPivotGrid1_DataBinding(sender As Object, e As EventArgs) Handles ASPxPivotGrid1.DataBinding
        Dim oradb As String = AppUtils.dbConnectionString

        Dim conn As OracleConnection = New OracleConnection(oradb)
        Dim cmd As OracleCommand
        conn.Open()

        cmd = New OracleCommand("select t2.id_negocios, t2.indicador, t2.frente, t2.nota_calc, t3.categoria, t3.peso, decode(t2.nota_calc,'RUIM',0,'REGULAR',0.5,'BOM',1,'OTIMO',1,NULL,0) COEF_CALC, t3.peso * decode(t2.nota_calc,'RUIM',0,'REGULAR',0.5,'BOM',1,'OTIMO',1,NULL,0) PESO_CALC from ( select t1.id_negocios, DECODE(t1.INDICADOR, 'CONSUMO_OLEO_DIESEL', 'CONSUMO_OLEO', 'CONSUMO_OLEO_HIDRAULICO','CONSUMO_OLEO', 'DISP_MECANICA_COLHEDORA','DISP_MECANICA', 'DISP_MECANICA_DEMAIS','DISP_MECANICA', t1.INDICADOR) INDICADOR, t1.frente, F_INDICADOR_NOTA(t1.id_negocios, DECODE(t1.INDICADOR, 'CONSUMO_OLEO_DIESEL', 'CONSUMO_OLEO', 'CONSUMO_OLEO_HIDRAULICO','CONSUMO_OLEO', 'DISP_MECANICA_COLHEDORA','DISP_MECANICA', 'DISP_MECANICA_DEMAIS','DISP_MECANICA', t1.INDICADOR),t1.frente) NOTA_CALC from INDICADORES_AGRICOLA t1 where t1.grupo = 'COLHEITA' and t1.frente is not null and t1.frente = 8) t2, indicadores_agricola_pesos t3 where t2.id_negocios = t3.id_negocios and t2.indicador = t3.indicador and t2.frente = 8 group by t2.id_negocios, t2.indicador, t2.frente, t2.nota_calc, t3.categoria,t3.peso order by t2.id_negocios, t2.frente, t2.indicador", conn) With {.CommandType = CommandType.Text}

        'cmd.Parameters.Add(":p0", OracleDbType.Date).Value = ASPxComboDataFechamento.Value

        Dim dr As OracleDataReader = cmd.ExecuteReader()

        ASPxPivotGrid1.DataSource = dr

    End Sub
End Class