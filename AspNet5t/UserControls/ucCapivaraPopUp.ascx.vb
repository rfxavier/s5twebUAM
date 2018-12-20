Imports Oracle.DataAccess.Client
Imports System.IO

Public Class ucCapivaraPopUp
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) And (Not Page.IsCallback) Then
            ASPxDateEdit1.Date = Now 'New DateTime(2014, 10, 5, 10, 0, 0) 'Now
        End If

        ASPxDataView1.DataSourceID = ""
        ASPxDataView2.DataSourceID = ""
        ASPxGridView1.DataSourceID = ""
        ASPxGridView2.DataSourceID = ""

        ASPxDataView1.DataBind()
        ASPxDataView2.DataBind()
        ASPxGridView1.DataBind()
        ASPxGridView2.DataBind()
    End Sub

    Protected Sub ASPxDataView1_DataBinding(sender As Object, e As EventArgs) Handles ASPxDataView1.DataBinding
        If ASPxHiddenField.Contains("COD_PROP") Then
            Dim parCOD_PROP = ParseCODPROP(ASPxHiddenField.Contains("COD_PROP"))

            If parCOD_PROP <> "" Then
                Dim oradb As String = AppUtils.dbConnectionString

                Dim conn As OracleConnection = New OracleConnection(oradb)
                conn.Open()

                Dim cmd1 As New OracleCommand("SELECT ROWNUM, A.* FROM ( SELECT        TRUNC(A.PROP_CODIGO) PROP_CODIGO,        A.DS_NOME_PROPRIEDADE,        TRUNC(A.NRO_CORTE) NRO_CORTE,        ROUND(SUM(A.QT_AREA_COLHIDA), 2) QT_AREA_COLHIDA,        TRUNC(A.IDADE) IDADE,        ROUND(SUM(A.QT_TON_ENTREGUE), 2) QT_TON_ENTREGUE,        ROUND(A.RENDIMENTO_PLAN, 0) RENDIMENTO_PLAN,        ROUND(DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0),                     0,                     0,                     (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA)))) RENDIMENTO_REAL,        MAX(A.DT_DESSECACAO) DT_DESSECACAO,        MAX(A.DT_CALAGEM) DT_CALAGEM,        MAX(A.DT_PLANTIO) DT_PLANTIO,        A.TIPO_PLANTIO,        A.EMPRESA_PLANTIO,        ROUND(AVG(A.STAND)) STAND,        A.TIPO_ADUBACAO,        A.TRAT_TOLETES,        MAX(A.DT_HERB_CANA_PLANTA) DT_HERB_CANA_PLANTA,        A.SEMANA_ENCERRAMENTO   FROM BI4T.V_PRODUTIVIDADE_1CORTE A  WHERE A.PROP_CODIGO = :p0 GROUP BY           A.PROP_CODIGO,           A.DS_NOME_PROPRIEDADE,           A.NRO_CORTE,           A.IDADE,           A.RENDIMENTO_PLAN,           A.TIPO_PLANTIO,           A.EMPRESA_PLANTIO,           A.TIPO_ADUBACAO,           A.TRAT_TOLETES,           A.SEMANA_ENCERRAMENTO ) A", conn) With {.CommandType = CommandType.Text}
                cmd1.Parameters.Add(":p0", OracleDbType.Int32).Value = parCOD_PROP
                Dim dr1 As OracleDataReader = cmd1.ExecuteReader()

                ASPxDataView1.DataSource = dr1

            End If
        End If
    End Sub

    Private Sub ASPxDataView2_DataBinding(sender As Object, e As EventArgs) Handles ASPxDataView2.DataBinding
        If ASPxHiddenField.Contains("COD_PROP") Then
            Dim parCOD_PROP = ParseCODPROP(ASPxHiddenField.Contains("COD_PROP"))

            If parCOD_PROP <> "" Then
                Dim oradb As String = AppUtils.dbConnectionString

                Dim conn As OracleConnection = New OracleConnection(oradb)
                conn.Open()

                Dim cmd2 As New OracleCommand("SELECT ROWNUM, A.*   FROM (SELECT TRUNC(A.PROP_CODIGO) PROP_CODIGO,        A.DS_NOME_PROPRIEDADE,        TRUNC(A.NRO_CORTE) NRO_CORTE,        ROUND(SUM(A.QT_AREA_COLHIDA),2) QT_AREA_COLHIDA,        ROUND(SUM(A.IDADE * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE),2) IDADE,        ROUND(SUM(A.QT_TON_ENTREGUE),2) QT_TON_ENTREGUE,        ROUND(DECODE(NVL(SUM(A.QT_TON_ENTREGUE),0), 0, 0, (SUM(A.RENDIMENTO_PLAN * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE))),0) RENDIMENTO_PLAN,        ROUND(DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA)))) RENDIMENTO_REAL,        ROUND(((DECODE(NVL(SUM(A.QT_AREA_COLHIDA), 0), 0, 0, (SUM(A.QT_TON_ENTREGUE) / SUM(A.QT_AREA_COLHIDA))) /          DECODE(NVL(SUM(A.QT_TON_ENTREGUE),0), 0, 0, (SUM(A.RENDIMENTO_PLAN * A.QT_TON_ENTREGUE) / SUM(A.QT_TON_ENTREGUE)))) -1) * 100) DESVIO,        MIN(A.DT_COLHEITA_ANTERIOR) DT_COLHEITA_ANTERIOR,        A.TIPO_ADUBACAO,        MIN(A.DT_ADUBACAO) DT_ADUBACAO,        TRUNC(MIN(A.DT_ADUBACAO) - MIN(A.DT_COLHEITA_ANTERIOR)) DIF_DIAS_ADUB,        A.TIPO_HERBICIDA,        MIN(A.DT_HERBICIDA) DT_HERBICIDA,        TRUNC(MIN(A.DT_HERBICIDA) - MIN(A.DT_COLHEITA_ANTERIOR)) DIF_DIAS_HERB,        A.FERTIRRIGACAO,        MIN(A.DT_FERTIRRIGACAO) DT_FERTIRRIGACAO,        A.SEMANA_ENCERRAMENTO   FROM BI4T.V_PRODUTIVIDADE_DCORTE A WHERE A.PROP_CODIGO = :p0 GROUP BY A.PROP_CODIGO,           A.DS_NOME_PROPRIEDADE,           A.NRO_CORTE,                             A.TIPO_ADUBACAO,           A.TIPO_HERBICIDA,           A.FERTIRRIGACAO,                    A.SEMANA_ENCERRAMENTO) A", conn) With {.CommandType = CommandType.Text}
                cmd2.Parameters.Add(":p0", OracleDbType.Int32).Value = parCOD_PROP

                Dim dr2 As OracleDataReader = cmd2.ExecuteReader()

                ASPxDataView2.DataSource = dr2
            End If
        End If

    End Sub

    Protected Sub ASPxGridView1_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView1.DataBinding
        If ASPxHiddenField.Contains("COD_PROP") Then
            Dim parCOD_PROP = ParseCODPROP(ASPxHiddenField.Contains("COD_PROP"))

            If parCOD_PROP <> "" Then
                Dim oradb As String = AppUtils.dbConnectionString

                Dim conn As OracleConnection = New OracleConnection(oradb)
                conn.Open()

                Dim cmd3 As New OracleCommand("SELECT ROWNUM, A.*   FROM (SELECT AX.PROPRIEDADE,                AX.DSC_PROPRIEDADE,                AX.CORTE,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-6, AX.TON_HA, 0))) TON_HA_6,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-6, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_6,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-5, AX.TON_HA, 0))) TON_HA_5,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-5, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_5,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-4, AX.TON_HA, 0))) TON_HA_4,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-4, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_4,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-3, AX.TON_HA, 0))) TON_HA_3,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-3, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_3,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-2, AX.TON_HA, 0))) TON_HA_2,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-2, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_2,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-1, AX.TON_HA, 0))) TON_HA_1,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)-1, DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO_1,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)  , AX.TON_HA, 0))) TON_HA,                ROUND(SUM(DECODE(AX.SAFRA, SISAGRI.F_SAFRA_ATUAL(AX.ID_NEGOCIOS_PROP)  , DECODE(NVL(AX.IDADE,0),0,0,((AX.TON_HA / AX.IDADE) * DECODE(AX.CORTE, 1, 15, 12))), 0))) EQUILIBRIO           FROM (SELECT AB.SAFRA,                        AB.ID_NEGOCIOS_PROP,                        AB.PROPRIEDADE,                        AB.DSC_PROPRIEDADE,                        AB.CORTE,                        DECODE(SUM(AB.TON_COLHIDA), 0, 0, (SUM(AB.IDADE * AB.TON_COLHIDA) / SUM(AB.TON_COLHIDA))) IDADE,                        DECODE(NVL(SUM(AB.AREA_COLHIDA),0), 0, 0, (NVL(SUM(AB.TON_COLHIDA),0) / NVL(SUM(AB.AREA_COLHIDA),0))) TON_HA                   FROM (SELECT A.SAFRA,                                A.ID_NEGOCIOS_PROP,                                A.PROPRIEDADE,                                A.DSC_PROPRIEDADE,                                A.CORTE,                                NVL((A.DT_COLH_ATUAL - A.DT_COLH_ANTERIOR) / 30, 0) IDADE,                                NVL(SUM(A.AREA_COLHIDA),0) AREA_COLHIDA,                                NVL(SUM(A.TON_COLHIDA),0) TON_COLHIDA                           FROM (SELECT TALH.TALH_ID,                                        TALH.ID_NEGOCIOS_PROP,                                        TALH.TALH_CODIGO_PROP PROPRIEDADE,                                        PROP.PROP_DESCRICAO DSC_PROPRIEDADE,                                        TALH.TALH_NCORTE CORTE,                                        LIBE.LIBE_TIPO_CORTE TIPOCORTE,                                        CERC.SAFRA,                                        TALH.TALH_DATA_COLHEITA_ANT DT_COLH_ANTERIOR,                                        MIN(TRUNC(CERC.CERC_DATAENTRADAB)) DT_COLH_ATUAL,                                        NVL((LIBE.LIBE_TOTAL), 0) AREA_COLHIDA,                                        NVL(SUM(CERC.CERC_PESOBRUTO - CERC.CERC_TARA), 0) / 1000 TON_COLHIDA                                   FROM SISAGRI.TALHAO           TALH,                                        SISAGRI.TALHAO_LIBERACAO LIBE,                                        SISAGRI.CERTIFICADO_CANA CERC,                                        SISAGRI.PROPRIEDADE_AGRICOLA PROP                                                WHERE TALH.TALH_ID = LIBE.LIBE_ID_TALH                                    AND LIBE.LIBE_ID_TALH = CERC.CERC_ID_TALH                                                AND (LIBE.LIBE_TIPO_CORTE = CERC.CERC_CODIGO_TIPT OR LIBE.LIBE_TIPO_CORTE  IS NULL)                                                  AND TALH.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS                                    AND TALH.TALH_CODIGO_PROP = PROP.PROP_CODIGO                                    AND CERC.CERC_FLAG_ENTRADA IS NULL                                    AND TALH.ID_NEGOCIOS_PROP = 1                                    AND LIBE.LIBE_INDICADOR = '1'                                              AND TALH.TALH_SAFRA BETWEEN (SISAGRI.F_SAFRA_ATUAL(TALH.ID_NEGOCIOS_PROP) - 6) AND SISAGRI.F_SAFRA_ATUAL(TALH.ID_NEGOCIOS_PROP)                                    AND TALH.TALH_CODIGO_PROP = :p0                                  GROUP BY TALH.TALH_ID,                                           TALH.ID_NEGOCIOS_PROP,                                           TALH.TALH_CODIGO_PROP,                                           PROP.PROP_DESCRICAO,                                           TALH.TALH_NCORTE,                                           LIBE.LIBE_TIPO_CORTE,                                           CERC.SAFRA,                                           NVL((LIBE.LIBE_TOTAL), 0),                                           TALH.TALH_DATA_COLHEITA_ANT) A                          GROUP BY A.SAFRA,                                   A.ID_NEGOCIOS_PROP,                                   A.PROPRIEDADE,                                   A.DSC_PROPRIEDADE,                                   A.CORTE,                                   NVL((A.DT_COLH_ATUAL - A.DT_COLH_ANTERIOR) / 30, 0)                                         ) AB                            GROUP BY AB.SAFRA,                           AB.ID_NEGOCIOS_PROP,                           AB.PROPRIEDADE,                           AB.DSC_PROPRIEDADE,                           AB.CORTE                ) AX          GROUP BY AX.PROPRIEDADE,                   AX.DSC_PROPRIEDADE,                   AX.CORTE        ) A", conn) With {.CommandType = CommandType.Text}
                cmd3.Parameters.Add(":p0", OracleDbType.Int32).Value = parCOD_PROP

                Dim dr3 As OracleDataReader = cmd3.ExecuteReader()

                ASPxGridView1.DataSource = dr3

                ASPxGridView1.SettingsText.Title = "Propriedade " & ASPxHiddenField("COD_PROP")
            Else
                ASPxGridView1.SettingsText.Title = ""
            End If
        End If
    End Sub

    Private Sub ASPxGridView2_DataBinding(sender As Object, e As EventArgs) Handles ASPxGridView2.DataBinding
        If ASPxHiddenField.Contains("COD_PROP") Then
            Dim parCOD_PROP = ParseCODPROP(ASPxHiddenField.Contains("COD_PROP"))

            If parCOD_PROP <> "" Then
                Dim oradb As String = AppUtils.dbConnectionString

                Dim conn As OracleConnection = New OracleConnection(oradb)
                conn.Open()

                Dim strcmd4 As String = String.Format("SELECT ROWNUM, BB.* FROM (SELECT AA.DIA, ROUND(SUM(AA.POLPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) POL, ROUND(SUM(AA.FIBRAPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) FIBRA, ROUND(SUM(AA.ARPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) AR, ROUND(SUM(AA.ATRPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) ATR, ROUND(SUM(AA.UMIDADEPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) UMIDADE, ROUND(SUM(AA.PUREZAPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) PUREZA, ROUND(((SUM(AA.POLPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2)) / 0.95) + (SUM(AA.ARPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2)), 2) ART_CALCULADO FROM (SELECT TALH.TALH_CODIGO_PROP PROPRIEDADE, PROP.PROP_DESCRICAO DESCRICAOPROPRIEDADE, TRUNC(CERC.CERC_DATA_REF) DIA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PCC * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) POLPRENSA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_FIBRA * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) FIBRAPRENSA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PUREZA * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) PUREZAPRENSA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_ATR * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) ATRPRENSA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_AR * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) ARPRENSA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_UMIDADE * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) UMIDADEPRENSA, SUM(CERC.CERC_PESOBRUTO - CERC.CERC_TARA) / 1000 CANAENTREGUE1, CASE WHEN ((SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) / 1000) IS NULL) THEN NULL ELSE (SUM(CERC.CERC_PESOBRUTO - CERC.CERC_TARA) / 1000) END CANAENTREGUE2 FROM SISAGRI.CERTIFICADO_CANA CERC, SISAGRI.TALHAO_LIBERACAO LIBE, SISAGRI.TALHAO TALH, SISAGRI.PROPRIEDADE_AGRICOLA PROP WHERE CERC.CERC_ID_TALH = TALH.TALH_ID AND CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH AND (CERC.CERC_CODIGO_TIPT = LIBE.LIBE_TIPO_CORTE OR LIBE.LIBE_TIPO_CORTE IS NULL) AND TALH.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS AND TALH.TALH_CODIGO_PROP = PROP.PROP_CODIGO AND CERC.CERC_FLAG_ENTRADA IS NULL AND CERC.ID_NEGOCIOS = 1 AND CERC.SAFRA >= (SELECT SISAGRI.F_SAFRA_ATUAL(CERC.ID_NEGOCIOS) - 1 FROM DUAL) AND CERC.CERC_DATA_REF <= (SELECT TRUNC(SYSDATE) + 0.99999 FROM DUAL) AND TRUNC(CERC.CERC_DATA_REF) IN ('31/12/2014', '31/12/2015', '{0:dd/MM/yyyy}', '{1:dd/MM/yyyy}') AND PROP.PROP_CODIGO = :p0 GROUP BY TALH.TALH_CODIGO_PROP, PROP.PROP_DESCRICAO, TRUNC(CERC.CERC_DATA_REF)) AA GROUP BY AA.DIA UNION ALL SELECT AA.SAFRA, ROUND(SUM(AA.POLPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) POL, ROUND(SUM(AA.FIBRAPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) FIBRA, ROUND(SUM(AA.ARPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) AR, ROUND(SUM(AA.ATRPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) ATR, ROUND(SUM(AA.UMIDADEPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) UMIDADE, ROUND(SUM(AA.PUREZAPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2), 2) PUREZA, ROUND(((SUM(AA.POLPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2)) / 0.95) + (SUM(AA.ARPRENSA * AA.CANAENTREGUE2) / SUM(AA.CANAENTREGUE2)), 2) ART_CALCULADO FROM (SELECT TALH.TALH_CODIGO_PROP PROPRIEDADE, PROP.PROP_DESCRICAO DESCRICAOPROPRIEDADE, TO_DATE('31/12/' || CERC.SAFRA, 'DD/MM/YYYY') SAFRA, TRUNC(CERC.CERC_DATA_REF) DIA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PCC * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) POLPRENSA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_FIBRA * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) FIBRAPRENSA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PUREZA * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) PUREZAPRENSA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_ATR * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) ATRPRENSA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_AR * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) ARPRENSA, SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_UMIDADE * CERC.CERC_PESO_ANALISADO)) / SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) UMIDADEPRENSA, SUM(CERC.CERC_PESOBRUTO - CERC.CERC_TARA) / 1000 CANAENTREGUE1, CASE WHEN ((SUM(DECODE(CERC.CERC_SACARIMETRO, 0, NULL, NULL, NULL, CERC.CERC_PESO_ANALISADO)) / 1000) IS NULL) THEN NULL ELSE (SUM(CERC.CERC_PESOBRUTO - CERC.CERC_TARA) / 1000) END CANAENTREGUE2 FROM SISAGRI.CERTIFICADO_CANA CERC, SISAGRI.TALHAO_LIBERACAO LIBE, SISAGRI.TALHAO TALH, SISAGRI.PROPRIEDADE_AGRICOLA PROP WHERE CERC.CERC_ID_TALH = TALH.TALH_ID AND CERC.CERC_ID_TALH = LIBE.LIBE_ID_TALH AND (CERC.CERC_CODIGO_TIPT = LIBE.LIBE_TIPO_CORTE OR LIBE.LIBE_TIPO_CORTE IS NULL) AND TALH.ID_NEGOCIOS_PROP = PROP.ID_NEGOCIOS AND TALH.TALH_CODIGO_PROP = PROP.PROP_CODIGO AND CERC.CERC_FLAG_ENTRADA IS NULL AND CERC.ID_NEGOCIOS = 1 AND CERC.SAFRA >= (SELECT SISAGRI.F_SAFRA_ATUAL(CERC.ID_NEGOCIOS) - 1 FROM DUAL) AND CERC.CERC_DATA_REF <= (SELECT TRUNC(SYSDATE) + 0.99999 FROM DUAL) AND ((CERC.CERC_DATA_REF BETWEEN '01/01/2015' AND '{1:dd/MM/yyyy}') OR (CERC.CERC_DATA_REF BETWEEN '01/01/2014' AND '{0:dd/MM/yyyy}')) AND PROP.PROP_CODIGO = :p0 GROUP BY TALH.TALH_CODIGO_PROP, PROP.PROP_DESCRICAO, CERC.SAFRA, TRUNC(CERC.CERC_DATA_REF)) AA GROUP BY AA.SAFRA) BB", New DateTime(ASPxDateEdit1.Date.Year - 1, ASPxDateEdit1.Date.Month, ASPxDateEdit1.Date.Day, 0, 0, 0).ToShortDateString, ASPxDateEdit1.Date.ToShortDateString)
                Dim cmd4 As New OracleCommand(strcmd4, conn) With {.CommandType = CommandType.Text}
                cmd4.Parameters.Add(":p0", OracleDbType.Int32).Value = parCOD_PROP

                Dim dr4 As OracleDataReader = cmd4.ExecuteReader()

                ASPxGridView2.DataSource = dr4

                ASPxGridView2.SettingsText.Title = "Propriedade " & ASPxHiddenField("COD_PROP")
            Else
                ASPxGridView2.SettingsText.Title = ""
            End If
        End If

    End Sub

    Protected Sub ASPxGridView2_CustomColumnSort(sender As Object, e As DevExpress.Web.CustomColumnSortEventArgs) Handles ASPxGridView2.CustomColumnSort
        If e.Column.FieldName = "DIA" Then
            e.Handled = True
            Dim s1 As Date = e.Value1, s2 As Date = e.Value2
            If (s1.Day = 31 And s1.Month = 12) And (s2.Day = 31 And s2.Month = 12) Then
                e.Result = Comparer.Default.Compare(s1, s2)
            ElseIf (s1.Day = 31 And s1.Month = 12) Then
                e.Result = 1
            ElseIf (s2.Day = 31 And s2.Month = 12) Then
                e.Result = -1
            Else
                If s1 > s2 Then
                    e.Result = 1
                ElseIf s1 = s2 Then
                    e.Result = Comparer.Default.Compare(s1, s2)
                ElseIf s1 < s2 Then
                    e.Result = -1
                End If
            End If
        End If
    End Sub

    Protected Sub propriedadePopUp_WindowCallback(source As Object, e As DevExpress.Web.PopupWindowCallbackArgs) Handles propriedadePopUp.WindowCallback
        If ASPxHiddenField.Contains("COD_PROP") Then
            Dim parCOD_PROP = ParseCODPROP(ASPxHiddenField.Contains("COD_PROP"))

            If parCOD_PROP <> "" Then '

                '"C:\Sistemas\AspNet5tUAM\AspNet5t\Content\mapas\" & parCOD_PROP.PadLeft(5, "0") & ".pdf")
                If System.IO.File.Exists(Path.Combine(Server.MapPath("~"), "Content\mapas\" & parCOD_PROP.PadLeft(5, "0") & ".pdf")) Then
                    ASPxHyperLink1.ClientVisible = True
                    ASPxHyperLink1.NavigateUrl = "~/Content/mapas/" & parCOD_PROP.PadLeft(5, "0") & ".pdf?v=" & DateTime.Now.Ticks
                Else
                    ASPxHyperLink1.ClientVisible = False
                    ASPxHyperLink1.NavigateUrl = ""
                End If
            End If
        End If
    End Sub

    Private Function ParseCODPROP(parCOD_PROP As String) As String
        ParseCODPROP = ""

        If ASPxHiddenField.Contains("COD_PROP") Then
            If ASPxHiddenField("COD_PROP").IndexOf(" ( ") > 0 Then

                'EXTRAI CÓDIGO PROPRIEDADE ENTRE PARÊNTESES, NO FORMATO: " ( código ) "
                Dim i As Integer = ASPxHiddenField("COD_PROP").IndexOf(" ( ")

                ParseCODPROP = ASPxHiddenField("COD_PROP").ToString.Substring(i + 2, ASPxHiddenField("COD_PROP").IndexOf(" )") - i - 1).Trim
            End If
        End If
    End Function

    Protected Sub ASPxGridView2_CustomColumnDisplayText(sender As Object, e As DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs) Handles ASPxGridView2.CustomColumnDisplayText
        If e.Column.FieldName <> "DIA" Then Return

        If e.Value.ToString.StartsWith("31/12/") Then
            e.DisplayText = e.Value.ToString.Substring(6, 4)
        End If

    End Sub
End Class