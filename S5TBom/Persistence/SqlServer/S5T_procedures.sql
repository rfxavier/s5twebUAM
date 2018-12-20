/* CodeFluent Generated . TargetVersion:Sql2014. Culture:en-US. UiCulture:en-US. Encoding:utf-8 (http://www.softfluent.com) */
set quoted_identifier OFF
GO
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_1CORTE_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_1CORTE_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_TALHAO_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_1CORTE_TALHAO_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_TALHAO_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_1CORTE_TALHAO_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_DCORTE_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_DCORTE_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_TALHAO_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_DCORTE_TALHAO_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_TALHAO_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_DCORTE_TALHAO_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMPANHAMENTO_PLANTIO_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMPANHAMENTO_PLANTIO_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMPANHAMENTO_PLANTIO_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMPANHAMENTO_PLANTIO_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[appconfig_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[appconfig_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[appconfig_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[appconfig_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastrotipo_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo_Deletecadastroocadastrostipo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastrotipo_Deletecadastroocadastrostipo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastrotipo_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo_Savecadastroocadastrostipo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastrotipo_Savecadastroocadastrostipo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[CERTIFICADO_PATIO_HORA_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CERTIFICADO_PATIO_HORA_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[CERTIFICADO_PATIO_HORA_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CERTIFICADO_PATIO_HORA_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cidade_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cidade_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[empresa_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_Deletecadastrooempresas]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[empresa_Deletecadastrooempresas]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[empresa_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_Savecadastrooempresas]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[empresa_Savecadastrooempresas]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_FRENTESPROP_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_FRENTESPROP_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_FRENTESPROP_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_FRENTESPROP_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_PRINCIPAL_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_PRINCIPAL_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_PRINCIPAL_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_PRINCIPAL_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_AGRUP_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_AGRUP_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_AGRUP_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_AGRUP_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_MP_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_MP_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_MP_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_MP_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_FRENTE_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_FRENTE_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ESCALA_COLAB_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ESCALA_COLAB_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ESCALA_COLAB_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ESCALA_COLAB_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filialconfig_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filialconfig_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filialconfig_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filialconfig_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_TRATOS_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_TRATOS_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_TRATOS_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_TRATOS_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRole_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRole_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRole_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRole_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRoleClaim_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRoleClaim_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRoleClaim_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRoleClaim_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_DeleteIdRoleUsers]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_DeleteIdRoleUsers]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_SaveIdRoleUsers]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_SaveIdRoleUsers]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserClaim_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserClaim_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserClaim_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserClaim_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserLogin_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserLogin_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserLogin_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserLogin_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_EQUIP_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_EQUIP_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INFO_GERAIS_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INFO_GERAIS_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INFO_GERAIS_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INFO_GERAIS_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[loginregistro_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[loginregistro_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[loginregistro_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[loginregistro_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MAPA_PLANCOLHEITA_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MAPA_PLANCOLHEITA_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MAPA_PLANCOLHEITA_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MAPA_PLANCOLHEITA_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menu_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menu_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menu_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menu_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MOAGEM_CANA_HORA_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MOAGEM_CANA_HORA_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MOAGEM_CANA_HORA_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MOAGEM_CANA_HORA_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[pais_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[pais_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[pais_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[pais_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PROPRIEDADES_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PROPRIEDADES_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PROPRIEDADES_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PROPRIEDADES_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_ACUMULADA_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_ACUMULADA_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_ACUMULADA_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_ACUMULADA_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_DIARIA_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_DIARIA_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_DIARIA_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_DIARIA_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_GRID_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_GRID_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_GRID_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_GRID_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_ACUMULADA_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_SAFRA_ACUMULADA_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_ACUMULADA_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_SAFRA_ACUMULADA_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_SAFRA_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_SAFRA_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SAFRA_ANO_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[SAFRA_ANO_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SAFRA_ANO_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[SAFRA_ANO_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SEQUENCIA_COLHEITA_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[SEQUENCIA_COLHEITA_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SEQUENCIA_COLHEITA_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[SEQUENCIA_COLHEITA_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sistema_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema_Deleteempresaosistemas]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sistema_Deleteempresaosistemas]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sistema_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema_Saveempresaosistemas]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sistema_Saveempresaosistemas]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[uf_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[uf_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_DeleteapprelatoriooUsuarios]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_DeleteapprelatoriooUsuarios]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_Deletefilialousuarios]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_Deletefilialousuarios]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_SaveapprelatoriooUsuarios]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_SaveapprelatoriooUsuarios]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_Savefilialousuarios]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_Savefilialousuarios]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[V_DADOS_TALHAO_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[V_DADOS_TALHAO_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[V_DADOS_TALHAO_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[V_DADOS_TALHAO_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[WebSiteMap_Delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[WebSiteMap_Delete]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[WebSiteMap_Save]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[WebSiteMap_Save]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_1CORTE_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_1CORTE_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_1CORTE_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_TALHAO_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_1CORTE_TALHAO_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_TALHAO_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_1CORTE_TALHAO_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_TALHAO_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_1CORTE_TALHAO_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_DCORTE_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_DCORTE_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_DCORTE_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_TALHAO_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_DCORTE_TALHAO_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_TALHAO_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_DCORTE_TALHAO_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_TALHAO_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMP_PROD_DCORTE_TALHAO_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMPANHAMENTO_PLANTIO_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMPANHAMENTO_PLANTIO_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMPANHAMENTO_PLANTIO_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMPANHAMENTO_PLANTIO_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMPANHAMENTO_PLANTIO_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ACOMPANHAMENTO_PLANTIO_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[appconfig_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[appconfig_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[appconfig_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[appconfig_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[appconfig_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[appconfig_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[appconfig_LoadDataBD]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[appconfig_LoadDataBD]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[appconfig_LoadDataHoraBD]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[appconfig_LoadDataHoraBD]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[appconfig_LoadHoraBD]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[appconfig_LoadHoraBD]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_LoadAllView]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_LoadAllView]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_LoadByCategoriaRelatorioView]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_LoadByCategoriaRelatorioView]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_LoadByIdView]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_LoadByIdView]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_LoadBypNomeRelatorio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_LoadBypNomeRelatorio]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_LoadByUsuarioCategoriaRelatorioView]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_LoadByUsuarioCategoriaRelatorioView]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_LoadByUsuarioView]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_LoadByUsuarioView]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_LoadoAppRelatoriosoUsuariosByUsuario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[apprelatorio_LoadoAppRelatoriosoUsuariosByUsuario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadByEmpresaFlgCadastroViewGeralTipo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadByEmpresaFlgCadastroViewGeralTipo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadByEmpresaViewGeral]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadByEmpresaViewGeral]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadByNomeFlgCadastroViewGeral]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadByNomeFlgCadastroViewGeral]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadByNomeViewGeral]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadByNomeViewGeral]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadByoCadastroFilial]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadByoCadastroFilial]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadByoCidade]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadByoCidade]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadByoCidadeAux]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadByoCidadeAux]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadByoUsuario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadByoUsuario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadByParametros]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadByParametros]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadBypCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadBypCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadBypCpfCnpj]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadBypCpfCnpj]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadMaxCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadMaxCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadoCadastrosoCadastrosTipoByCadastroTipo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadoCadastrosoCadastrosTipoByCadastroTipo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_LoadoCadastrosoEmpresasByEmpresa]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastro_LoadoCadastrosoEmpresasByEmpresa]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastrotipo_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastrotipo_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo_LoadAllViewGrid]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastrotipo_LoadAllViewGrid]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo_LoadByFlgCadastro]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastrotipo_LoadByFlgCadastro]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastrotipo_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo_LoadoCadastrosTipooCadastrosByCadastro]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cadastrotipo_LoadoCadastrosTipooCadastrosByCadastro]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[CERTIFICADO_PATIO_HORA_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CERTIFICADO_PATIO_HORA_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[CERTIFICADO_PATIO_HORA_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CERTIFICADO_PATIO_HORA_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[CERTIFICADO_PATIO_HORA_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CERTIFICADO_PATIO_HORA_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cidade_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cidade_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade_LoadAllViewGrid]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cidade_LoadAllViewGrid]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade_LoadByFilterCodigoNome]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cidade_LoadByFilterCodigoNome]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade_LoadByNomeViewGrid]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cidade_LoadByNomeViewGrid]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade_LoadByoUF]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cidade_LoadByoUF]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade_LoadBypCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cidade_LoadBypCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade_LoadMaxCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[cidade_LoadMaxCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[empresa_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[empresa_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_LoadByNome]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[empresa_LoadByNome]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_LoadBypCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[empresa_LoadBypCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_LoadoEmpresasoCadastrosByCadastro]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[empresa_LoadoEmpresasoCadastrosByCadastro]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_LoadoEmpresasoSistemasBySistema]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[empresa_LoadoEmpresasoSistemasBySistema]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_FRENTESPROP_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_FRENTESPROP_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_FRENTESPROP_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_FRENTESPROP_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_FRENTESPROP_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_FRENTESPROP_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_PRINCIPAL_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_PRINCIPAL_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_PRINCIPAL_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_PRINCIPAL_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_PRINCIPAL_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENT_CAMBAL_PRINCIPAL_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_AGRUP_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_AGRUP_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_AGRUP_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_AGRUP_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_AGRUP_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_AGRUP_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_MP_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_MP_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_MP_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_MP_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_MP_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_DET_MP_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_FRENTE_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_FRENTE_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_FRENTE_LoadByDIAFRENTE]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_LoadByDIAFRENTE]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_FRENTE_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_LoadByDIA]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_LoadByDIA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ENTRADA_CANA_HORA_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ESCALA_COLAB_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ESCALA_COLAB_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ESCALA_COLAB_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ESCALA_COLAB_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ESCALA_COLAB_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ESCALA_COLAB_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_LoadByCodEmpresaCodFilial]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_LoadByCodEmpresaCodFilial]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_LoadByCodEmpresaNomeFilial]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_LoadByCodEmpresaNomeFilial]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_LoadByCodFilialLoginUsuario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_LoadByCodFilialLoginUsuario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_LoadByoCadastro]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_LoadByoCadastro]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_LoadByoEmpresa]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_LoadByoEmpresa]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_LoadMaxCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_LoadMaxCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_LoadoFiliaisoUsuariosByUsuario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filial_LoadoFiliaisoUsuariosByUsuario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filialconfig_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filialconfig_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filialconfig_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filialconfig_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filialconfig_LoadByFilial]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filialconfig_LoadByFilial]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filialconfig_LoadByFilialTipoConfig]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filialconfig_LoadByFilialTipoConfig]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filialconfig_LoadByoFilial]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filialconfig_LoadByoFilial]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filialconfig_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filialconfig_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filialconfig_LoadByTipo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[filialconfig_LoadByTipo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_TRATOS_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_TRATOS_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_TRATOS_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_TRATOS_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_TRATOS_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_TRATOS_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRole_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRole_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRole_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRole_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRole_LoadByName]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRole_LoadByName]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRole_LoadRolesUsersByIdUser]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRole_LoadRolesUsersByIdUser]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRoleClaim_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRoleClaim_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRoleClaim_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRoleClaim_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRoleClaim_LoadById]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRoleClaim_LoadById]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRoleClaim_LoadByRole]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdRoleClaim_LoadByRole]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_LoadByEmail]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_LoadByEmail]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_LoadByoUsuario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_LoadByoUsuario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_LoadByUserLoginInfo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_LoadByUserLoginInfo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_LoadByUserName]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_LoadByUserName]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser_LoadUsersRolesByIdRole]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUser_LoadUsersRolesByIdRole]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserClaim_DeleteByClaim]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserClaim_DeleteByClaim]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserClaim_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserClaim_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserClaim_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserClaim_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserClaim_LoadByClaim]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserClaim_LoadByClaim]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserClaim_LoadById]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserClaim_LoadById]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserClaim_LoadByUser]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserClaim_LoadByUser]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserLogin_DeleteByUserLoginInfo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserLogin_DeleteByUserLoginInfo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserLogin_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserLogin_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserLogin_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserLogin_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserLogin_LoadById]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserLogin_LoadById]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserLogin_LoadByUser]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[IdUserLogin_LoadByUser]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_EQUIP_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_EQUIP_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_EQUIP_LoadByFRENTETIPOAUX_DATA_REF]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_LoadByFRENTETIPOAUX_DATA_REF]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_EQUIP_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_LoadByDATA_FECHAMENTO]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_LoadByDATA_FECHAMENTO]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_LoadByDATA_FECHAMENTO_GRUPO]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_LoadByDATA_FECHAMENTO_GRUPO]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_LoadByDATA_FECHAMENTO]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_LoadByDATA_FECHAMENTO]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INFO_GERAIS_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INFO_GERAIS_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INFO_GERAIS_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INFO_GERAIS_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INFO_GERAIS_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[INFO_GERAIS_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[loginregistro_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[loginregistro_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[loginregistro_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[loginregistro_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[loginregistro_LoadByCodUsuario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[loginregistro_LoadByCodUsuario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[loginregistro_LoadByCurrentSession]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[loginregistro_LoadByCurrentSession]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[loginregistro_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[loginregistro_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MAPA_PLANCOLHEITA_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MAPA_PLANCOLHEITA_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MAPA_PLANCOLHEITA_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MAPA_PLANCOLHEITA_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MAPA_PLANCOLHEITA_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MAPA_PLANCOLHEITA_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menu_DeleteBySistema]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menu_DeleteBySistema]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menu_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menu_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menu_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menu_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menu_LoadByoSistema]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menu_LoadByoSistema]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menu_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menu_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menu_LoadBySistemaVw]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menu_LoadBySistemaVw]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menu_LoadBySistemaVwPerm]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menu_LoadBySistemaVwPerm]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_DeleteBySistemaUsuario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_DeleteBySistemaUsuario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_LoadByoSistema]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_LoadByoSistema]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_LoadByoUsuario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_LoadByoUsuario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_LoadBySistemaUsuario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_LoadBySistemaUsuario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_LoadBySistemaUsuarioPerm]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_LoadBySistemaUsuarioPerm]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao_LoadBySistemaUsuarioToolStrip]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[menupermissao_LoadBySistemaUsuarioToolStrip]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MOAGEM_CANA_HORA_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MOAGEM_CANA_HORA_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MOAGEM_CANA_HORA_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MOAGEM_CANA_HORA_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MOAGEM_CANA_HORA_LoadByDIA]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MOAGEM_CANA_HORA_LoadByDIA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MOAGEM_CANA_HORA_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[MOAGEM_CANA_HORA_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[pais_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[pais_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[pais_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[pais_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[pais_LoadAllViewGrid]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[pais_LoadAllViewGrid]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[pais_LoadByDescricaoViewGrid]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[pais_LoadByDescricaoViewGrid]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[pais_LoadBypCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[pais_LoadBypCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[pais_LoadMaxCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[pais_LoadMaxCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PROPRIEDADES_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PROPRIEDADES_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PROPRIEDADES_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PROPRIEDADES_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PROPRIEDADES_LoadByCOD_PROPRIEDADE]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PROPRIEDADES_LoadByCOD_PROPRIEDADE]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PROPRIEDADES_LoadByDSC_PROPRIEDADE]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PROPRIEDADES_LoadByDSC_PROPRIEDADE]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PROPRIEDADES_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PROPRIEDADES_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PROPRIEDADES_LoadBySAFRA]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PROPRIEDADES_LoadBySAFRA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_ACUMULADA_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_ACUMULADA_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_ACUMULADA_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_ACUMULADA_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_ACUMULADA_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_ACUMULADA_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_DIARIA_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_DIARIA_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_DIARIA_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_DIARIA_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_DIARIA_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_DIARIA_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_GRID_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_GRID_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_GRID_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_GRID_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_GRID_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_GRID_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_ACUMULADA_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_SAFRA_ACUMULADA_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_ACUMULADA_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_SAFRA_ACUMULADA_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_ACUMULADA_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_SAFRA_ACUMULADA_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_SAFRA_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_SAFRA_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RES_MENSAL_SAFRA_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SAFRA_ANO_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[SAFRA_ANO_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SAFRA_ANO_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[SAFRA_ANO_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SAFRA_ANO_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[SAFRA_ANO_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SEQUENCIA_COLHEITA_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[SEQUENCIA_COLHEITA_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SEQUENCIA_COLHEITA_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[SEQUENCIA_COLHEITA_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SEQUENCIA_COLHEITA_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[SEQUENCIA_COLHEITA_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sistema_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sistema_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema_LoadByCodSistemaCodEmpresa]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sistema_LoadByCodSistemaCodEmpresa]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema_LoadByNome]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sistema_LoadByNome]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema_LoadBypCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sistema_LoadBypCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema_LoadoSistemasoEmpresasByEmpresa]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sistema_LoadoSistemasoEmpresasByEmpresa]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[uf_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[uf_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf_LoadAllViewGrid]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[uf_LoadAllViewGrid]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf_LoadByDescricaoViewGrid]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[uf_LoadByDescricaoViewGrid]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf_LoadByoPais]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[uf_LoadByoPais]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf_LoadBypCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[uf_LoadBypCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf_LoadBySigla]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[uf_LoadBySigla]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf_LoadMaxCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[uf_LoadMaxCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_LoadByCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_LoadByCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_LoadByLogin]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_LoadByLogin]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_LoadByoCadastro]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_LoadByoCadastro]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_LoadByoIdUser]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_LoadByoIdUser]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_LoadBypLogin]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_LoadBypLogin]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_LoadMaxCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_LoadMaxCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_LoadoUsuariosoAppRelatoriosByAppRelatorio]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_LoadoUsuariosoAppRelatoriosByAppRelatorio]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario_LoadoUsuariosoFiliaisByFilial]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usuario_LoadoUsuariosoFiliaisByFilial]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[V_DADOS_TALHAO_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[V_DADOS_TALHAO_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[V_DADOS_TALHAO_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[V_DADOS_TALHAO_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[V_DADOS_TALHAO_LoadByCOD_PROPRIEDADE]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[V_DADOS_TALHAO_LoadByCOD_PROPRIEDADE]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[V_DADOS_TALHAO_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[V_DADOS_TALHAO_LoadBypId]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[WebSiteMap_Load]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[WebSiteMap_Load]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[WebSiteMap_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[WebSiteMap_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[WebSiteMap_LoadBypId]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[WebSiteMap_LoadBypId]
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_1CORTE_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ACOMP_PROD_1CORTE] FROM [ACOMP_PROD_1CORTE] 
    WHERE ([ACOMP_PROD_1CORTE].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_1CORTE_Save]
(
 @pId [bigint] = NULL,
 @ROWNUM [int] = NULL,
 @PROP_CODIGO [int] = NULL,
 @DS_NOME_PROPRIEDADE [nvarchar] (256) = NULL,
 @NRO_CORTE [int] = NULL,
 @QT_AREA_COLHIDA [float] = NULL,
 @IDADE [int] = NULL,
 @TIPO_PROPRIEDADE [nvarchar] (256) = NULL,
 @QT_TON_ENTREGUE [float] = NULL,
 @RENDIMENTO_PLAN [int] = NULL,
 @RENDIMENTO_REAL [int] = NULL,
 @DESVIO [int] = NULL,
 @PORC_BROCA [float] = NULL,
 @PERDAS [float] = NULL,
 @INCENDIO [nvarchar] (256) = NULL,
 @DATA_INCENDIO [date] = NULL,
 @DT_DESSECACAO [date] = NULL,
 @DT_CALAGEM [date] = NULL,
 @DT_PLANTIO [date] = NULL,
 @TIPO_PLANTIO [nvarchar] (256) = NULL,
 @EMPRESA_PLANTIO [nvarchar] (256) = NULL,
 @STAND [int] = NULL,
 @TIPO_ADUBACAO [nvarchar] (256) = NULL,
 @TRAT_TOLETES [nvarchar] (256) = NULL,
 @DT_HERB_CANA_PLANTA [date] = NULL,
 @SEMANA_ENCERRAMENTO [nvarchar] (256) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ACOMP_PROD_1CORTE] SET
 [ACOMP_PROD_1CORTE].[ROWNUM] = @ROWNUM,
 [ACOMP_PROD_1CORTE].[PROP_CODIGO] = @PROP_CODIGO,
 [ACOMP_PROD_1CORTE].[DS_NOME_PROPRIEDADE] = @DS_NOME_PROPRIEDADE,
 [ACOMP_PROD_1CORTE].[NRO_CORTE] = @NRO_CORTE,
 [ACOMP_PROD_1CORTE].[QT_AREA_COLHIDA] = @QT_AREA_COLHIDA,
 [ACOMP_PROD_1CORTE].[IDADE] = @IDADE,
 [ACOMP_PROD_1CORTE].[TIPO_PROPRIEDADE] = @TIPO_PROPRIEDADE,
 [ACOMP_PROD_1CORTE].[QT_TON_ENTREGUE] = @QT_TON_ENTREGUE,
 [ACOMP_PROD_1CORTE].[RENDIMENTO_PLAN] = @RENDIMENTO_PLAN,
 [ACOMP_PROD_1CORTE].[RENDIMENTO_REAL] = @RENDIMENTO_REAL,
 [ACOMP_PROD_1CORTE].[DESVIO] = @DESVIO,
 [ACOMP_PROD_1CORTE].[PORC_BROCA] = @PORC_BROCA,
 [ACOMP_PROD_1CORTE].[PERDAS] = @PERDAS,
 [ACOMP_PROD_1CORTE].[INCENDIO] = @INCENDIO,
 [ACOMP_PROD_1CORTE].[DATA_INCENDIO] = @DATA_INCENDIO,
 [ACOMP_PROD_1CORTE].[DT_DESSECACAO] = @DT_DESSECACAO,
 [ACOMP_PROD_1CORTE].[DT_CALAGEM] = @DT_CALAGEM,
 [ACOMP_PROD_1CORTE].[DT_PLANTIO] = @DT_PLANTIO,
 [ACOMP_PROD_1CORTE].[TIPO_PLANTIO] = @TIPO_PLANTIO,
 [ACOMP_PROD_1CORTE].[EMPRESA_PLANTIO] = @EMPRESA_PLANTIO,
 [ACOMP_PROD_1CORTE].[STAND] = @STAND,
 [ACOMP_PROD_1CORTE].[TIPO_ADUBACAO] = @TIPO_ADUBACAO,
 [ACOMP_PROD_1CORTE].[TRAT_TOLETES] = @TRAT_TOLETES,
 [ACOMP_PROD_1CORTE].[DT_HERB_CANA_PLANTA] = @DT_HERB_CANA_PLANTA,
 [ACOMP_PROD_1CORTE].[SEMANA_ENCERRAMENTO] = @SEMANA_ENCERRAMENTO,
 [ACOMP_PROD_1CORTE].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ACOMP_PROD_1CORTE].[_trackLastWriteTime] = GETDATE()
    WHERE ([ACOMP_PROD_1CORTE].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ACOMP_PROD_1CORTE] (
        [ACOMP_PROD_1CORTE].[ROWNUM],
        [ACOMP_PROD_1CORTE].[PROP_CODIGO],
        [ACOMP_PROD_1CORTE].[DS_NOME_PROPRIEDADE],
        [ACOMP_PROD_1CORTE].[NRO_CORTE],
        [ACOMP_PROD_1CORTE].[QT_AREA_COLHIDA],
        [ACOMP_PROD_1CORTE].[IDADE],
        [ACOMP_PROD_1CORTE].[TIPO_PROPRIEDADE],
        [ACOMP_PROD_1CORTE].[QT_TON_ENTREGUE],
        [ACOMP_PROD_1CORTE].[RENDIMENTO_PLAN],
        [ACOMP_PROD_1CORTE].[RENDIMENTO_REAL],
        [ACOMP_PROD_1CORTE].[DESVIO],
        [ACOMP_PROD_1CORTE].[PORC_BROCA],
        [ACOMP_PROD_1CORTE].[PERDAS],
        [ACOMP_PROD_1CORTE].[INCENDIO],
        [ACOMP_PROD_1CORTE].[DATA_INCENDIO],
        [ACOMP_PROD_1CORTE].[DT_DESSECACAO],
        [ACOMP_PROD_1CORTE].[DT_CALAGEM],
        [ACOMP_PROD_1CORTE].[DT_PLANTIO],
        [ACOMP_PROD_1CORTE].[TIPO_PLANTIO],
        [ACOMP_PROD_1CORTE].[EMPRESA_PLANTIO],
        [ACOMP_PROD_1CORTE].[STAND],
        [ACOMP_PROD_1CORTE].[TIPO_ADUBACAO],
        [ACOMP_PROD_1CORTE].[TRAT_TOLETES],
        [ACOMP_PROD_1CORTE].[DT_HERB_CANA_PLANTA],
        [ACOMP_PROD_1CORTE].[SEMANA_ENCERRAMENTO],
        [ACOMP_PROD_1CORTE].[_trackCreationUser],
        [ACOMP_PROD_1CORTE].[_trackLastWriteUser])
    VALUES (
        @ROWNUM,
        @PROP_CODIGO,
        @DS_NOME_PROPRIEDADE,
        @NRO_CORTE,
        @QT_AREA_COLHIDA,
        @IDADE,
        @TIPO_PROPRIEDADE,
        @QT_TON_ENTREGUE,
        @RENDIMENTO_PLAN,
        @RENDIMENTO_REAL,
        @DESVIO,
        @PORC_BROCA,
        @PERDAS,
        @INCENDIO,
        @DATA_INCENDIO,
        @DT_DESSECACAO,
        @DT_CALAGEM,
        @DT_PLANTIO,
        @TIPO_PLANTIO,
        @EMPRESA_PLANTIO,
        @STAND,
        @TIPO_ADUBACAO,
        @TRAT_TOLETES,
        @DT_HERB_CANA_PLANTA,
        @SEMANA_ENCERRAMENTO,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ACOMP_PROD_1CORTE] 
        WHERE ([ACOMP_PROD_1CORTE].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_1CORTE_TALHAO_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ACOMP_PROD_1CORTE_TALHAO] FROM [ACOMP_PROD_1CORTE_TALHAO] 
    WHERE ([ACOMP_PROD_1CORTE_TALHAO].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_1CORTE_TALHAO_Save]
(
 @pId [bigint] = NULL,
 @ROWNUM [int] = NULL,
 @PROP_CODIGO [int] = NULL,
 @DS_NOME_PROPRIEDADE [nvarchar] (256) = NULL,
 @TALHAO [int] = NULL,
 @NRO_CORTE [int] = NULL,
 @QT_AREA_COLHIDA [float] = NULL,
 @IDADE [int] = NULL,
 @TIPO_PROPRIEDADE [nvarchar] (256) = NULL,
 @QT_TON_ENTREGUE [float] = NULL,
 @RENDIMENTO_PLAN [int] = NULL,
 @RENDIMENTO_REAL [int] = NULL,
 @DESVIO [int] = NULL,
 @PORC_BROCA [float] = NULL,
 @PERDAS [float] = NULL,
 @INCENDIO [nvarchar] (256) = NULL,
 @DATA_INCENDIO [date] = NULL,
 @DT_DESSECACAO [date] = NULL,
 @DT_CALAGEM [date] = NULL,
 @DT_PLANTIO [date] = NULL,
 @TIPO_PLANTIO [nvarchar] (256) = NULL,
 @EMPRESA_PLANTIO [nvarchar] (256) = NULL,
 @STAND [int] = NULL,
 @TIPO_ADUBACAO [nvarchar] (256) = NULL,
 @TRAT_TOLETES [nvarchar] (256) = NULL,
 @DT_HERB_CANA_PLANTA [date] = NULL,
 @SEMANA_ENCERRAMENTO [nvarchar] (256) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ACOMP_PROD_1CORTE_TALHAO] SET
 [ACOMP_PROD_1CORTE_TALHAO].[ROWNUM] = @ROWNUM,
 [ACOMP_PROD_1CORTE_TALHAO].[PROP_CODIGO] = @PROP_CODIGO,
 [ACOMP_PROD_1CORTE_TALHAO].[DS_NOME_PROPRIEDADE] = @DS_NOME_PROPRIEDADE,
 [ACOMP_PROD_1CORTE_TALHAO].[TALHAO] = @TALHAO,
 [ACOMP_PROD_1CORTE_TALHAO].[NRO_CORTE] = @NRO_CORTE,
 [ACOMP_PROD_1CORTE_TALHAO].[QT_AREA_COLHIDA] = @QT_AREA_COLHIDA,
 [ACOMP_PROD_1CORTE_TALHAO].[IDADE] = @IDADE,
 [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PROPRIEDADE] = @TIPO_PROPRIEDADE,
 [ACOMP_PROD_1CORTE_TALHAO].[QT_TON_ENTREGUE] = @QT_TON_ENTREGUE,
 [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_PLAN] = @RENDIMENTO_PLAN,
 [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_REAL] = @RENDIMENTO_REAL,
 [ACOMP_PROD_1CORTE_TALHAO].[DESVIO] = @DESVIO,
 [ACOMP_PROD_1CORTE_TALHAO].[PORC_BROCA] = @PORC_BROCA,
 [ACOMP_PROD_1CORTE_TALHAO].[PERDAS] = @PERDAS,
 [ACOMP_PROD_1CORTE_TALHAO].[INCENDIO] = @INCENDIO,
 [ACOMP_PROD_1CORTE_TALHAO].[DATA_INCENDIO] = @DATA_INCENDIO,
 [ACOMP_PROD_1CORTE_TALHAO].[DT_DESSECACAO] = @DT_DESSECACAO,
 [ACOMP_PROD_1CORTE_TALHAO].[DT_CALAGEM] = @DT_CALAGEM,
 [ACOMP_PROD_1CORTE_TALHAO].[DT_PLANTIO] = @DT_PLANTIO,
 [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PLANTIO] = @TIPO_PLANTIO,
 [ACOMP_PROD_1CORTE_TALHAO].[EMPRESA_PLANTIO] = @EMPRESA_PLANTIO,
 [ACOMP_PROD_1CORTE_TALHAO].[STAND] = @STAND,
 [ACOMP_PROD_1CORTE_TALHAO].[TIPO_ADUBACAO] = @TIPO_ADUBACAO,
 [ACOMP_PROD_1CORTE_TALHAO].[TRAT_TOLETES] = @TRAT_TOLETES,
 [ACOMP_PROD_1CORTE_TALHAO].[DT_HERB_CANA_PLANTA] = @DT_HERB_CANA_PLANTA,
 [ACOMP_PROD_1CORTE_TALHAO].[SEMANA_ENCERRAMENTO] = @SEMANA_ENCERRAMENTO,
 [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteTime] = GETDATE()
    WHERE ([ACOMP_PROD_1CORTE_TALHAO].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ACOMP_PROD_1CORTE_TALHAO] (
        [ACOMP_PROD_1CORTE_TALHAO].[ROWNUM],
        [ACOMP_PROD_1CORTE_TALHAO].[PROP_CODIGO],
        [ACOMP_PROD_1CORTE_TALHAO].[DS_NOME_PROPRIEDADE],
        [ACOMP_PROD_1CORTE_TALHAO].[TALHAO],
        [ACOMP_PROD_1CORTE_TALHAO].[NRO_CORTE],
        [ACOMP_PROD_1CORTE_TALHAO].[QT_AREA_COLHIDA],
        [ACOMP_PROD_1CORTE_TALHAO].[IDADE],
        [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PROPRIEDADE],
        [ACOMP_PROD_1CORTE_TALHAO].[QT_TON_ENTREGUE],
        [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_PLAN],
        [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_REAL],
        [ACOMP_PROD_1CORTE_TALHAO].[DESVIO],
        [ACOMP_PROD_1CORTE_TALHAO].[PORC_BROCA],
        [ACOMP_PROD_1CORTE_TALHAO].[PERDAS],
        [ACOMP_PROD_1CORTE_TALHAO].[INCENDIO],
        [ACOMP_PROD_1CORTE_TALHAO].[DATA_INCENDIO],
        [ACOMP_PROD_1CORTE_TALHAO].[DT_DESSECACAO],
        [ACOMP_PROD_1CORTE_TALHAO].[DT_CALAGEM],
        [ACOMP_PROD_1CORTE_TALHAO].[DT_PLANTIO],
        [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PLANTIO],
        [ACOMP_PROD_1CORTE_TALHAO].[EMPRESA_PLANTIO],
        [ACOMP_PROD_1CORTE_TALHAO].[STAND],
        [ACOMP_PROD_1CORTE_TALHAO].[TIPO_ADUBACAO],
        [ACOMP_PROD_1CORTE_TALHAO].[TRAT_TOLETES],
        [ACOMP_PROD_1CORTE_TALHAO].[DT_HERB_CANA_PLANTA],
        [ACOMP_PROD_1CORTE_TALHAO].[SEMANA_ENCERRAMENTO],
        [ACOMP_PROD_1CORTE_TALHAO].[_trackCreationUser],
        [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteUser])
    VALUES (
        @ROWNUM,
        @PROP_CODIGO,
        @DS_NOME_PROPRIEDADE,
        @TALHAO,
        @NRO_CORTE,
        @QT_AREA_COLHIDA,
        @IDADE,
        @TIPO_PROPRIEDADE,
        @QT_TON_ENTREGUE,
        @RENDIMENTO_PLAN,
        @RENDIMENTO_REAL,
        @DESVIO,
        @PORC_BROCA,
        @PERDAS,
        @INCENDIO,
        @DATA_INCENDIO,
        @DT_DESSECACAO,
        @DT_CALAGEM,
        @DT_PLANTIO,
        @TIPO_PLANTIO,
        @EMPRESA_PLANTIO,
        @STAND,
        @TIPO_ADUBACAO,
        @TRAT_TOLETES,
        @DT_HERB_CANA_PLANTA,
        @SEMANA_ENCERRAMENTO,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ACOMP_PROD_1CORTE_TALHAO] 
        WHERE ([ACOMP_PROD_1CORTE_TALHAO].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_DCORTE_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ACOMP_PROD_DCORTE] FROM [ACOMP_PROD_DCORTE] 
    WHERE ([ACOMP_PROD_DCORTE].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_DCORTE_Save]
(
 @pId [bigint] = NULL,
 @ROWNUM [int] = NULL,
 @PROP_CODIGO [int] = NULL,
 @DS_NOME_PROPRIEDADE [nvarchar] (256) = NULL,
 @NRO_CORTE [int] = NULL,
 @QT_AREA_COLHIDA [float] = NULL,
 @IDADE [int] = NULL,
 @TIPO_PROPRIEDADE [nvarchar] (256) = NULL,
 @QT_TON_ENTREGUE [float] = NULL,
 @RENDIMENTO_PLAN [int] = NULL,
 @RENDIMENTO_REAL [int] = NULL,
 @DESVIO [int] = NULL,
 @PORC_BROCA [float] = NULL,
 @PERDAS [float] = NULL,
 @DT_COLHEITA_ANTERIOR [date] = NULL,
 @TIPO_ADUBACAO [nvarchar] (256) = NULL,
 @DT_ADUBACAO [date] = NULL,
 @DIF_DIAS_ADUB [int] = NULL,
 @TIPO_HERBICIDA [nvarchar] (256) = NULL,
 @DT_HERBICIDA [date] = NULL,
 @DIF_DIAS_HERB [int] = NULL,
 @INCENDIO [nvarchar] (256) = NULL,
 @DATA_INCENDIO [date] = NULL,
 @FERTIRRIGACAO [nvarchar] (256) = NULL,
 @DT_FERTIRRIGACAO [date] = NULL,
 @SEMANA_ENCERRAMENTO [nvarchar] (256) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ACOMP_PROD_DCORTE] SET
 [ACOMP_PROD_DCORTE].[ROWNUM] = @ROWNUM,
 [ACOMP_PROD_DCORTE].[PROP_CODIGO] = @PROP_CODIGO,
 [ACOMP_PROD_DCORTE].[DS_NOME_PROPRIEDADE] = @DS_NOME_PROPRIEDADE,
 [ACOMP_PROD_DCORTE].[NRO_CORTE] = @NRO_CORTE,
 [ACOMP_PROD_DCORTE].[QT_AREA_COLHIDA] = @QT_AREA_COLHIDA,
 [ACOMP_PROD_DCORTE].[IDADE] = @IDADE,
 [ACOMP_PROD_DCORTE].[TIPO_PROPRIEDADE] = @TIPO_PROPRIEDADE,
 [ACOMP_PROD_DCORTE].[QT_TON_ENTREGUE] = @QT_TON_ENTREGUE,
 [ACOMP_PROD_DCORTE].[RENDIMENTO_PLAN] = @RENDIMENTO_PLAN,
 [ACOMP_PROD_DCORTE].[RENDIMENTO_REAL] = @RENDIMENTO_REAL,
 [ACOMP_PROD_DCORTE].[DESVIO] = @DESVIO,
 [ACOMP_PROD_DCORTE].[PORC_BROCA] = @PORC_BROCA,
 [ACOMP_PROD_DCORTE].[PERDAS] = @PERDAS,
 [ACOMP_PROD_DCORTE].[DT_COLHEITA_ANTERIOR] = @DT_COLHEITA_ANTERIOR,
 [ACOMP_PROD_DCORTE].[TIPO_ADUBACAO] = @TIPO_ADUBACAO,
 [ACOMP_PROD_DCORTE].[DT_ADUBACAO] = @DT_ADUBACAO,
 [ACOMP_PROD_DCORTE].[DIF_DIAS_ADUB] = @DIF_DIAS_ADUB,
 [ACOMP_PROD_DCORTE].[TIPO_HERBICIDA] = @TIPO_HERBICIDA,
 [ACOMP_PROD_DCORTE].[DT_HERBICIDA] = @DT_HERBICIDA,
 [ACOMP_PROD_DCORTE].[DIF_DIAS_HERB] = @DIF_DIAS_HERB,
 [ACOMP_PROD_DCORTE].[INCENDIO] = @INCENDIO,
 [ACOMP_PROD_DCORTE].[DATA_INCENDIO] = @DATA_INCENDIO,
 [ACOMP_PROD_DCORTE].[FERTIRRIGACAO] = @FERTIRRIGACAO,
 [ACOMP_PROD_DCORTE].[DT_FERTIRRIGACAO] = @DT_FERTIRRIGACAO,
 [ACOMP_PROD_DCORTE].[SEMANA_ENCERRAMENTO] = @SEMANA_ENCERRAMENTO,
 [ACOMP_PROD_DCORTE].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ACOMP_PROD_DCORTE].[_trackLastWriteTime] = GETDATE()
    WHERE ([ACOMP_PROD_DCORTE].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ACOMP_PROD_DCORTE] (
        [ACOMP_PROD_DCORTE].[ROWNUM],
        [ACOMP_PROD_DCORTE].[PROP_CODIGO],
        [ACOMP_PROD_DCORTE].[DS_NOME_PROPRIEDADE],
        [ACOMP_PROD_DCORTE].[NRO_CORTE],
        [ACOMP_PROD_DCORTE].[QT_AREA_COLHIDA],
        [ACOMP_PROD_DCORTE].[IDADE],
        [ACOMP_PROD_DCORTE].[TIPO_PROPRIEDADE],
        [ACOMP_PROD_DCORTE].[QT_TON_ENTREGUE],
        [ACOMP_PROD_DCORTE].[RENDIMENTO_PLAN],
        [ACOMP_PROD_DCORTE].[RENDIMENTO_REAL],
        [ACOMP_PROD_DCORTE].[DESVIO],
        [ACOMP_PROD_DCORTE].[PORC_BROCA],
        [ACOMP_PROD_DCORTE].[PERDAS],
        [ACOMP_PROD_DCORTE].[DT_COLHEITA_ANTERIOR],
        [ACOMP_PROD_DCORTE].[TIPO_ADUBACAO],
        [ACOMP_PROD_DCORTE].[DT_ADUBACAO],
        [ACOMP_PROD_DCORTE].[DIF_DIAS_ADUB],
        [ACOMP_PROD_DCORTE].[TIPO_HERBICIDA],
        [ACOMP_PROD_DCORTE].[DT_HERBICIDA],
        [ACOMP_PROD_DCORTE].[DIF_DIAS_HERB],
        [ACOMP_PROD_DCORTE].[INCENDIO],
        [ACOMP_PROD_DCORTE].[DATA_INCENDIO],
        [ACOMP_PROD_DCORTE].[FERTIRRIGACAO],
        [ACOMP_PROD_DCORTE].[DT_FERTIRRIGACAO],
        [ACOMP_PROD_DCORTE].[SEMANA_ENCERRAMENTO],
        [ACOMP_PROD_DCORTE].[_trackCreationUser],
        [ACOMP_PROD_DCORTE].[_trackLastWriteUser])
    VALUES (
        @ROWNUM,
        @PROP_CODIGO,
        @DS_NOME_PROPRIEDADE,
        @NRO_CORTE,
        @QT_AREA_COLHIDA,
        @IDADE,
        @TIPO_PROPRIEDADE,
        @QT_TON_ENTREGUE,
        @RENDIMENTO_PLAN,
        @RENDIMENTO_REAL,
        @DESVIO,
        @PORC_BROCA,
        @PERDAS,
        @DT_COLHEITA_ANTERIOR,
        @TIPO_ADUBACAO,
        @DT_ADUBACAO,
        @DIF_DIAS_ADUB,
        @TIPO_HERBICIDA,
        @DT_HERBICIDA,
        @DIF_DIAS_HERB,
        @INCENDIO,
        @DATA_INCENDIO,
        @FERTIRRIGACAO,
        @DT_FERTIRRIGACAO,
        @SEMANA_ENCERRAMENTO,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ACOMP_PROD_DCORTE] 
        WHERE ([ACOMP_PROD_DCORTE].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_DCORTE_TALHAO_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ACOMP_PROD_DCORTE_TALHAO] FROM [ACOMP_PROD_DCORTE_TALHAO] 
    WHERE ([ACOMP_PROD_DCORTE_TALHAO].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_DCORTE_TALHAO_Save]
(
 @pId [bigint] = NULL,
 @ROWNUM [int] = NULL,
 @PROP_CODIGO [int] = NULL,
 @DS_NOME_PROPRIEDADE [nvarchar] (256) = NULL,
 @TALHAO [int] = NULL,
 @NRO_CORTE [int] = NULL,
 @QT_AREA_COLHIDA [float] = NULL,
 @IDADE [int] = NULL,
 @TIPO_PROPRIEDADE [nvarchar] (256) = NULL,
 @DT_COLHEITA_ATUAL [date] = NULL,
 @QT_TON_ENTREGUE [float] = NULL,
 @RENDIMENTO_PLAN [int] = NULL,
 @RENDIMENTO_REAL [int] = NULL,
 @DESVIO [int] = NULL,
 @PORC_BROCA [float] = NULL,
 @PERDAS [float] = NULL,
 @DT_COLHEITA_ANTERIOR [date] = NULL,
 @TIPO_ADUBACAO [nvarchar] (256) = NULL,
 @DT_ADUBACAO [date] = NULL,
 @DIF_DIAS_ADUB [int] = NULL,
 @TIPO_HERBICIDA [nvarchar] (256) = NULL,
 @DT_HERBICIDA [date] = NULL,
 @DIF_DIAS_HERB [int] = NULL,
 @INCENDIO [nvarchar] (256) = NULL,
 @DATA_INCENDIO [date] = NULL,
 @FERTIRRIGACAO [nvarchar] (256) = NULL,
 @DT_FERTIRRIGACAO [date] = NULL,
 @SEMANA_ENCERRAMENTO [nvarchar] (256) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ACOMP_PROD_DCORTE_TALHAO] SET
 [ACOMP_PROD_DCORTE_TALHAO].[ROWNUM] = @ROWNUM,
 [ACOMP_PROD_DCORTE_TALHAO].[PROP_CODIGO] = @PROP_CODIGO,
 [ACOMP_PROD_DCORTE_TALHAO].[DS_NOME_PROPRIEDADE] = @DS_NOME_PROPRIEDADE,
 [ACOMP_PROD_DCORTE_TALHAO].[TALHAO] = @TALHAO,
 [ACOMP_PROD_DCORTE_TALHAO].[NRO_CORTE] = @NRO_CORTE,
 [ACOMP_PROD_DCORTE_TALHAO].[QT_AREA_COLHIDA] = @QT_AREA_COLHIDA,
 [ACOMP_PROD_DCORTE_TALHAO].[IDADE] = @IDADE,
 [ACOMP_PROD_DCORTE_TALHAO].[TIPO_PROPRIEDADE] = @TIPO_PROPRIEDADE,
 [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ATUAL] = @DT_COLHEITA_ATUAL,
 [ACOMP_PROD_DCORTE_TALHAO].[QT_TON_ENTREGUE] = @QT_TON_ENTREGUE,
 [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_PLAN] = @RENDIMENTO_PLAN,
 [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_REAL] = @RENDIMENTO_REAL,
 [ACOMP_PROD_DCORTE_TALHAO].[DESVIO] = @DESVIO,
 [ACOMP_PROD_DCORTE_TALHAO].[PORC_BROCA] = @PORC_BROCA,
 [ACOMP_PROD_DCORTE_TALHAO].[PERDAS] = @PERDAS,
 [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ANTERIOR] = @DT_COLHEITA_ANTERIOR,
 [ACOMP_PROD_DCORTE_TALHAO].[TIPO_ADUBACAO] = @TIPO_ADUBACAO,
 [ACOMP_PROD_DCORTE_TALHAO].[DT_ADUBACAO] = @DT_ADUBACAO,
 [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_ADUB] = @DIF_DIAS_ADUB,
 [ACOMP_PROD_DCORTE_TALHAO].[TIPO_HERBICIDA] = @TIPO_HERBICIDA,
 [ACOMP_PROD_DCORTE_TALHAO].[DT_HERBICIDA] = @DT_HERBICIDA,
 [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_HERB] = @DIF_DIAS_HERB,
 [ACOMP_PROD_DCORTE_TALHAO].[INCENDIO] = @INCENDIO,
 [ACOMP_PROD_DCORTE_TALHAO].[DATA_INCENDIO] = @DATA_INCENDIO,
 [ACOMP_PROD_DCORTE_TALHAO].[FERTIRRIGACAO] = @FERTIRRIGACAO,
 [ACOMP_PROD_DCORTE_TALHAO].[DT_FERTIRRIGACAO] = @DT_FERTIRRIGACAO,
 [ACOMP_PROD_DCORTE_TALHAO].[SEMANA_ENCERRAMENTO] = @SEMANA_ENCERRAMENTO,
 [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteTime] = GETDATE()
    WHERE ([ACOMP_PROD_DCORTE_TALHAO].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ACOMP_PROD_DCORTE_TALHAO] (
        [ACOMP_PROD_DCORTE_TALHAO].[ROWNUM],
        [ACOMP_PROD_DCORTE_TALHAO].[PROP_CODIGO],
        [ACOMP_PROD_DCORTE_TALHAO].[DS_NOME_PROPRIEDADE],
        [ACOMP_PROD_DCORTE_TALHAO].[TALHAO],
        [ACOMP_PROD_DCORTE_TALHAO].[NRO_CORTE],
        [ACOMP_PROD_DCORTE_TALHAO].[QT_AREA_COLHIDA],
        [ACOMP_PROD_DCORTE_TALHAO].[IDADE],
        [ACOMP_PROD_DCORTE_TALHAO].[TIPO_PROPRIEDADE],
        [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ATUAL],
        [ACOMP_PROD_DCORTE_TALHAO].[QT_TON_ENTREGUE],
        [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_PLAN],
        [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_REAL],
        [ACOMP_PROD_DCORTE_TALHAO].[DESVIO],
        [ACOMP_PROD_DCORTE_TALHAO].[PORC_BROCA],
        [ACOMP_PROD_DCORTE_TALHAO].[PERDAS],
        [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ANTERIOR],
        [ACOMP_PROD_DCORTE_TALHAO].[TIPO_ADUBACAO],
        [ACOMP_PROD_DCORTE_TALHAO].[DT_ADUBACAO],
        [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_ADUB],
        [ACOMP_PROD_DCORTE_TALHAO].[TIPO_HERBICIDA],
        [ACOMP_PROD_DCORTE_TALHAO].[DT_HERBICIDA],
        [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_HERB],
        [ACOMP_PROD_DCORTE_TALHAO].[INCENDIO],
        [ACOMP_PROD_DCORTE_TALHAO].[DATA_INCENDIO],
        [ACOMP_PROD_DCORTE_TALHAO].[FERTIRRIGACAO],
        [ACOMP_PROD_DCORTE_TALHAO].[DT_FERTIRRIGACAO],
        [ACOMP_PROD_DCORTE_TALHAO].[SEMANA_ENCERRAMENTO],
        [ACOMP_PROD_DCORTE_TALHAO].[_trackCreationUser],
        [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteUser])
    VALUES (
        @ROWNUM,
        @PROP_CODIGO,
        @DS_NOME_PROPRIEDADE,
        @TALHAO,
        @NRO_CORTE,
        @QT_AREA_COLHIDA,
        @IDADE,
        @TIPO_PROPRIEDADE,
        @DT_COLHEITA_ATUAL,
        @QT_TON_ENTREGUE,
        @RENDIMENTO_PLAN,
        @RENDIMENTO_REAL,
        @DESVIO,
        @PORC_BROCA,
        @PERDAS,
        @DT_COLHEITA_ANTERIOR,
        @TIPO_ADUBACAO,
        @DT_ADUBACAO,
        @DIF_DIAS_ADUB,
        @TIPO_HERBICIDA,
        @DT_HERBICIDA,
        @DIF_DIAS_HERB,
        @INCENDIO,
        @DATA_INCENDIO,
        @FERTIRRIGACAO,
        @DT_FERTIRRIGACAO,
        @SEMANA_ENCERRAMENTO,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ACOMP_PROD_DCORTE_TALHAO] 
        WHERE ([ACOMP_PROD_DCORTE_TALHAO].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMPANHAMENTO_PLANTIO_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ACOMPANHAMENTO_PLANTIO] FROM [ACOMPANHAMENTO_PLANTIO] 
    WHERE ([ACOMPANHAMENTO_PLANTIO].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMPANHAMENTO_PLANTIO_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @COD_PROPRIEDADE [int] = NULL,
 @SAFRA [int] = NULL,
 @DT_PLANTIO [date] = NULL,
 @AREA_PLANTIO [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ACOMPANHAMENTO_PLANTIO] SET
 [ACOMPANHAMENTO_PLANTIO].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [ACOMPANHAMENTO_PLANTIO].[COD_PROPRIEDADE] = @COD_PROPRIEDADE,
 [ACOMPANHAMENTO_PLANTIO].[SAFRA] = @SAFRA,
 [ACOMPANHAMENTO_PLANTIO].[DT_PLANTIO] = @DT_PLANTIO,
 [ACOMPANHAMENTO_PLANTIO].[AREA_PLANTIO] = @AREA_PLANTIO,
 [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteTime] = GETDATE()
    WHERE ([ACOMPANHAMENTO_PLANTIO].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ACOMPANHAMENTO_PLANTIO] (
        [ACOMPANHAMENTO_PLANTIO].[ID_NEGOCIOS],
        [ACOMPANHAMENTO_PLANTIO].[COD_PROPRIEDADE],
        [ACOMPANHAMENTO_PLANTIO].[SAFRA],
        [ACOMPANHAMENTO_PLANTIO].[DT_PLANTIO],
        [ACOMPANHAMENTO_PLANTIO].[AREA_PLANTIO],
        [ACOMPANHAMENTO_PLANTIO].[_trackCreationUser],
        [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @COD_PROPRIEDADE,
        @SAFRA,
        @DT_PLANTIO,
        @AREA_PLANTIO,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ACOMPANHAMENTO_PLANTIO] 
        WHERE ([ACOMPANHAMENTO_PLANTIO].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[appconfig_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [appconfig] FROM [appconfig] 
    WHERE ([appconfig].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[appconfig_Save]
(
 @pId [bigint] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [appconfig] SET
 [appconfig].[_trackLastWriteUser] = @_trackLastWriteUser,
 [appconfig].[_trackLastWriteTime] = GETDATE()
    WHERE ([appconfig].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [appconfig] (
        [appconfig].[_trackCreationUser],
        [appconfig].[_trackLastWriteUser])
    VALUES (
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [appconfig] 
        WHERE ([appconfig].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [apprelatorio_oUsuarios_usuario_oAppRelatorios] FROM [apprelatorio_oUsuarios_usuario_oAppRelatorios] 
    WHERE ([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [apprelatorio] FROM [apprelatorio] 
    WHERE ([apprelatorio].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_Save]
(
 @pId [bigint] = NULL,
 @pNomeFormArgumento [nvarchar] (256) = NULL,
 @pNomeRelatorio [nvarchar] (20),
 @pNomeRdlc [nvarchar] (256) = NULL,
 @pNomeDataSet [nvarchar] (256) = NULL,
 @sCategoria [int] = NULL,
 @pTituloRelatorio [nvarchar] (256) = NULL,
 @pSequencia [int] = NULL,
 @pCategoriaRelatorio [nvarchar] (256) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [apprelatorio] SET
 [apprelatorio].[pNomeFormArgumento] = @pNomeFormArgumento,
 [apprelatorio].[pNomeRelatorio] = @pNomeRelatorio,
 [apprelatorio].[pNomeRdlc] = @pNomeRdlc,
 [apprelatorio].[pNomeDataSet] = @pNomeDataSet,
 [apprelatorio].[sCategoria] = @sCategoria,
 [apprelatorio].[pTituloRelatorio] = @pTituloRelatorio,
 [apprelatorio].[pSequencia] = @pSequencia,
 [apprelatorio].[pCategoriaRelatorio] = @pCategoriaRelatorio,
 [apprelatorio].[_trackLastWriteUser] = @_trackLastWriteUser,
 [apprelatorio].[_trackLastWriteTime] = GETDATE()
    WHERE ([apprelatorio].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [apprelatorio] (
        [apprelatorio].[pNomeFormArgumento],
        [apprelatorio].[pNomeRelatorio],
        [apprelatorio].[pNomeRdlc],
        [apprelatorio].[pNomeDataSet],
        [apprelatorio].[sCategoria],
        [apprelatorio].[pTituloRelatorio],
        [apprelatorio].[pSequencia],
        [apprelatorio].[pCategoriaRelatorio],
        [apprelatorio].[_trackCreationUser],
        [apprelatorio].[_trackLastWriteUser])
    VALUES (
        @pNomeFormArgumento,
        @pNomeRelatorio,
        @pNomeRdlc,
        @pNomeDataSet,
        @sCategoria,
        @pTituloRelatorio,
        @pSequencia,
        @pCategoriaRelatorio,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [apprelatorio] 
        WHERE ([apprelatorio].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [cadastro_oempresas_empresa_ocadastros] FROM [cadastro_oempresas_empresa_ocadastros] 
    WHERE ([cadastro_oempresas_empresa_ocadastros].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [cadastro_ocadastrostipo_cadastrotipo_ocadastros] FROM [cadastro_ocadastrostipo_cadastrotipo_ocadastros] 
    WHERE ([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [cadastro] FROM [cadastro] 
    WHERE ([cadastro].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_Save]
(
 @pId [bigint] = NULL,
 @pNome [nvarchar] (256) = NULL,
 @pCodigo [int],
 @pPFPJ [nvarchar] (1) = NULL,
 @pEndereco [nvarchar] (256) = NULL,
 @oCidade_pId [bigint] = NULL,
 @pEnderLogradouro [nvarchar] (256) = NULL,
 @pEnderComplemento [nvarchar] (256) = NULL,
 @pEnderBairro [nvarchar] (256) = NULL,
 @pEnderNumero [nvarchar] (256) = NULL,
 @pEnderAuxLogradouro [nvarchar] (256) = NULL,
 @pEnderAuxNumero [nvarchar] (256) = NULL,
 @pEnderAuxBairro [nvarchar] (256) = NULL,
 @pEnderAuxComplemento [nvarchar] (256) = NULL,
 @pEnderecoAux [nvarchar] (256) = NULL,
 @pEmail [nvarchar] (256) = NULL,
 @oCidadeAux_pId [bigint] = NULL,
 @pCpfCnpj [nvarchar] (20) = NULL,
 @pDataNascimento [date] = NULL,
 @pRgIe [nvarchar] (256) = NULL,
 @pNomeFantasia [nvarchar] (256) = NULL,
 @pFlgSexo [nvarchar] (256) = NULL,
 @pDataCadastro [date] = NULL,
 @pDataBaixa [date] = NULL,
 @pTelefone [nvarchar] (256) = NULL,
 @pTelefoneAux [nvarchar] (256) = NULL,
 @pCelular [nvarchar] (256) = NULL,
 @pFax [nvarchar] (256) = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @oUsuario_pId [bigint] = NULL,
 @pCep [nvarchar] (256) = NULL,
 @pCepAux [nvarchar] (256) = NULL,
 @pFlgPreCadastro [nvarchar] (1) = 'N',
 @oCadastroFilial_pId [bigint] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [cadastro] SET
 [cadastro].[pNome] = @pNome,
 [cadastro].[pCodigo] = @pCodigo,
 [cadastro].[pPFPJ] = @pPFPJ,
 [cadastro].[pEndereco] = @pEndereco,
 [cadastro].[oCidade_pId] = @oCidade_pId,
 [cadastro].[pEnderLogradouro] = @pEnderLogradouro,
 [cadastro].[pEnderComplemento] = @pEnderComplemento,
 [cadastro].[pEnderBairro] = @pEnderBairro,
 [cadastro].[pEnderNumero] = @pEnderNumero,
 [cadastro].[pEnderAuxLogradouro] = @pEnderAuxLogradouro,
 [cadastro].[pEnderAuxNumero] = @pEnderAuxNumero,
 [cadastro].[pEnderAuxBairro] = @pEnderAuxBairro,
 [cadastro].[pEnderAuxComplemento] = @pEnderAuxComplemento,
 [cadastro].[pEnderecoAux] = @pEnderecoAux,
 [cadastro].[pEmail] = @pEmail,
 [cadastro].[oCidadeAux_pId] = @oCidadeAux_pId,
 [cadastro].[pCpfCnpj] = @pCpfCnpj,
 [cadastro].[pDataNascimento] = @pDataNascimento,
 [cadastro].[pRgIe] = @pRgIe,
 [cadastro].[pNomeFantasia] = @pNomeFantasia,
 [cadastro].[pFlgSexo] = @pFlgSexo,
 [cadastro].[pDataCadastro] = @pDataCadastro,
 [cadastro].[pDataBaixa] = @pDataBaixa,
 [cadastro].[pTelefone] = @pTelefone,
 [cadastro].[pTelefoneAux] = @pTelefoneAux,
 [cadastro].[pCelular] = @pCelular,
 [cadastro].[pFax] = @pFax,
 [cadastro].[xDataHoraReg] = @xDataHoraReg,
 [cadastro].[xLoginReg] = @xLoginReg,
 [cadastro].[oUsuario_pId] = @oUsuario_pId,
 [cadastro].[pCep] = @pCep,
 [cadastro].[pCepAux] = @pCepAux,
 [cadastro].[pFlgPreCadastro] = @pFlgPreCadastro,
 [cadastro].[oCadastroFilial_pId] = @oCadastroFilial_pId,
 [cadastro].[_trackLastWriteUser] = @_trackLastWriteUser,
 [cadastro].[_trackLastWriteTime] = GETDATE()
    WHERE ([cadastro].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [cadastro] (
        [cadastro].[pNome],
        [cadastro].[pCodigo],
        [cadastro].[pPFPJ],
        [cadastro].[pEndereco],
        [cadastro].[oCidade_pId],
        [cadastro].[pEnderLogradouro],
        [cadastro].[pEnderComplemento],
        [cadastro].[pEnderBairro],
        [cadastro].[pEnderNumero],
        [cadastro].[pEnderAuxLogradouro],
        [cadastro].[pEnderAuxNumero],
        [cadastro].[pEnderAuxBairro],
        [cadastro].[pEnderAuxComplemento],
        [cadastro].[pEnderecoAux],
        [cadastro].[pEmail],
        [cadastro].[oCidadeAux_pId],
        [cadastro].[pCpfCnpj],
        [cadastro].[pDataNascimento],
        [cadastro].[pRgIe],
        [cadastro].[pNomeFantasia],
        [cadastro].[pFlgSexo],
        [cadastro].[pDataCadastro],
        [cadastro].[pDataBaixa],
        [cadastro].[pTelefone],
        [cadastro].[pTelefoneAux],
        [cadastro].[pCelular],
        [cadastro].[pFax],
        [cadastro].[xDataHoraReg],
        [cadastro].[xLoginReg],
        [cadastro].[oUsuario_pId],
        [cadastro].[pCep],
        [cadastro].[pCepAux],
        [cadastro].[pFlgPreCadastro],
        [cadastro].[oCadastroFilial_pId],
        [cadastro].[_trackCreationUser],
        [cadastro].[_trackLastWriteUser])
    VALUES (
        @pNome,
        @pCodigo,
        @pPFPJ,
        @pEndereco,
        @oCidade_pId,
        @pEnderLogradouro,
        @pEnderComplemento,
        @pEnderBairro,
        @pEnderNumero,
        @pEnderAuxLogradouro,
        @pEnderAuxNumero,
        @pEnderAuxBairro,
        @pEnderAuxComplemento,
        @pEnderecoAux,
        @pEmail,
        @oCidadeAux_pId,
        @pCpfCnpj,
        @pDataNascimento,
        @pRgIe,
        @pNomeFantasia,
        @pFlgSexo,
        @pDataCadastro,
        @pDataBaixa,
        @pTelefone,
        @pTelefoneAux,
        @pCelular,
        @pFax,
        @xDataHoraReg,
        @xLoginReg,
        @oUsuario_pId,
        @pCep,
        @pCepAux,
        @pFlgPreCadastro,
        @oCadastroFilial_pId,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [cadastro] 
        WHERE ([cadastro].[pId] = @pId)
END
IF(@oUsuario_pId IS NOT NULL)
BEGIN
    UPDATE [usuario] SET
     [usuario].[oCadastro_pId] = @pId
        WHERE ([usuario].[pId] = @oUsuario_pId)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF(@oCadastroFilial_pId IS NOT NULL)
BEGIN
    UPDATE [filial] SET
     [filial].[oCadastro_pId] = @pId
        WHERE ([filial].[pId] = @oCadastroFilial_pId)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[cadastrotipo_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [cadastro_ocadastrostipo_cadastrotipo_ocadastros] FROM [cadastro_ocadastrostipo_cadastrotipo_ocadastros] 
    WHERE ([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId2] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [cadastrotipo] FROM [cadastrotipo] 
    WHERE ([cadastrotipo].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[cadastrotipo_Deletecadastroocadastrostipo]
(
 @pId [bigint] = NULL,
 @pId2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [cadastro_ocadastrostipo_cadastrotipo_ocadastros] FROM [cadastro_ocadastrostipo_cadastrotipo_ocadastros] 
    WHERE (([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId2] = @pId2) AND ([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId] = @pId))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[cadastrotipo_Save]
(
 @pId [bigint] = NULL,
 @pDescricao [nvarchar] (256) = NULL,
 @pFlgCadastro [nvarchar] (256) = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [cadastrotipo] SET
 [cadastrotipo].[pDescricao] = @pDescricao,
 [cadastrotipo].[pFlgCadastro] = @pFlgCadastro,
 [cadastrotipo].[xDataHoraReg] = @xDataHoraReg,
 [cadastrotipo].[xLoginReg] = @xLoginReg,
 [cadastrotipo].[_trackLastWriteUser] = @_trackLastWriteUser,
 [cadastrotipo].[_trackLastWriteTime] = GETDATE()
    WHERE ([cadastrotipo].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [cadastrotipo] (
        [cadastrotipo].[pDescricao],
        [cadastrotipo].[pFlgCadastro],
        [cadastrotipo].[xDataHoraReg],
        [cadastrotipo].[xLoginReg],
        [cadastrotipo].[_trackCreationUser],
        [cadastrotipo].[_trackLastWriteUser])
    VALUES (
        @pDescricao,
        @pFlgCadastro,
        @xDataHoraReg,
        @xLoginReg,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [cadastrotipo] 
        WHERE ([cadastrotipo].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[cadastrotipo_Savecadastroocadastrostipo]
(
 @pId [bigint],
 @pId2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
SELECT DISTINCT TOP 1 [cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId] 
    FROM [cadastro_ocadastrostipo_cadastrotipo_ocadastros] 
    WHERE (([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId2] = @pId2) AND ([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId] = @pId))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [cadastro_ocadastrostipo_cadastrotipo_ocadastros] (
        [cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId],
        [cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId2])
    VALUES (
        @pId,
        @pId2)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[CERTIFICADO_PATIO_HORA_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [CERTIFICADO_PATIO_HORA] FROM [CERTIFICADO_PATIO_HORA] 
    WHERE ([CERTIFICADO_PATIO_HORA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[CERTIFICADO_PATIO_HORA_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @DIA [date] = NULL,
 @HORA [nvarchar] (256) = NULL,
 @FRENTE [int] = NULL,
 @CERTIFICADOS [int] = NULL,
 @CERT_VAZIO [int] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [CERTIFICADO_PATIO_HORA] SET
 [CERTIFICADO_PATIO_HORA].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [CERTIFICADO_PATIO_HORA].[DIA] = @DIA,
 [CERTIFICADO_PATIO_HORA].[HORA] = @HORA,
 [CERTIFICADO_PATIO_HORA].[FRENTE] = @FRENTE,
 [CERTIFICADO_PATIO_HORA].[CERTIFICADOS] = @CERTIFICADOS,
 [CERTIFICADO_PATIO_HORA].[CERT_VAZIO] = @CERT_VAZIO,
 [CERTIFICADO_PATIO_HORA].[_trackLastWriteUser] = @_trackLastWriteUser,
 [CERTIFICADO_PATIO_HORA].[_trackLastWriteTime] = GETDATE()
    WHERE ([CERTIFICADO_PATIO_HORA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [CERTIFICADO_PATIO_HORA] (
        [CERTIFICADO_PATIO_HORA].[ID_NEGOCIOS],
        [CERTIFICADO_PATIO_HORA].[DIA],
        [CERTIFICADO_PATIO_HORA].[HORA],
        [CERTIFICADO_PATIO_HORA].[FRENTE],
        [CERTIFICADO_PATIO_HORA].[CERTIFICADOS],
        [CERTIFICADO_PATIO_HORA].[CERT_VAZIO],
        [CERTIFICADO_PATIO_HORA].[_trackCreationUser],
        [CERTIFICADO_PATIO_HORA].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @DIA,
        @HORA,
        @FRENTE,
        @CERTIFICADOS,
        @CERT_VAZIO,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [CERTIFICADO_PATIO_HORA] 
        WHERE ([CERTIFICADO_PATIO_HORA].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[cidade_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
UPDATE [cadastro] SET
 [cadastro].[oCidade_pId] = NULL
    WHERE ([cadastro].[oCidade_pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
UPDATE [cadastro] SET
 [cadastro].[oCidadeAux_pId] = NULL
    WHERE ([cadastro].[oCidadeAux_pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
DELETE [cidade] FROM [cidade] 
    WHERE ([cidade].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[cidade_Save]
(
 @pId [bigint] = NULL,
 @pNome [nvarchar] (256) = NULL,
 @pCodigo [int],
 @pCodigoIbge [int] = NULL,
 @oUF_pId [bigint] = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [cidade] SET
 [cidade].[pNome] = @pNome,
 [cidade].[pCodigo] = @pCodigo,
 [cidade].[pCodigoIbge] = @pCodigoIbge,
 [cidade].[oUF_pId] = @oUF_pId,
 [cidade].[xDataHoraReg] = @xDataHoraReg,
 [cidade].[xLoginReg] = @xLoginReg,
 [cidade].[_trackLastWriteUser] = @_trackLastWriteUser,
 [cidade].[_trackLastWriteTime] = GETDATE()
    WHERE ([cidade].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [cidade] (
        [cidade].[pNome],
        [cidade].[pCodigo],
        [cidade].[pCodigoIbge],
        [cidade].[oUF_pId],
        [cidade].[xDataHoraReg],
        [cidade].[xLoginReg],
        [cidade].[_trackCreationUser],
        [cidade].[_trackLastWriteUser])
    VALUES (
        @pNome,
        @pCodigo,
        @pCodigoIbge,
        @oUF_pId,
        @xDataHoraReg,
        @xLoginReg,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [cidade] 
        WHERE ([cidade].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[empresa_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [cadastro_oempresas_empresa_ocadastros] FROM [cadastro_oempresas_empresa_ocadastros] 
    WHERE ([cadastro_oempresas_empresa_ocadastros].[pId2] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [empresa_osistemas_sistema_oempresas] FROM [empresa_osistemas_sistema_oempresas] 
    WHERE ([empresa_osistemas_sistema_oempresas].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
UPDATE [filial] SET
 [filial].[oEmpresa_pId] = NULL
    WHERE ([filial].[oEmpresa_pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
DELETE [empresa] FROM [empresa] 
    WHERE ([empresa].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[empresa_Deletecadastrooempresas]
(
 @pId [bigint] = NULL,
 @pId2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [cadastro_oempresas_empresa_ocadastros] FROM [cadastro_oempresas_empresa_ocadastros] 
    WHERE (([cadastro_oempresas_empresa_ocadastros].[pId2] = @pId2) AND ([cadastro_oempresas_empresa_ocadastros].[pId] = @pId))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[empresa_Save]
(
 @pId [bigint] = NULL,
 @pCodigo [int],
 @pNome [nvarchar] (256) = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @pSimplesNacionalValorAliquotaCreditoICMS [float] = NULL,
 @sSimplesNacionalCategoria [int] = NULL,
 @sCodigoRegimeTributario [int] = NULL,
 @sCodigoRegimeTributarioNormal [int] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [empresa] SET
 [empresa].[pCodigo] = @pCodigo,
 [empresa].[pNome] = @pNome,
 [empresa].[xDataHoraReg] = @xDataHoraReg,
 [empresa].[xLoginReg] = @xLoginReg,
 [empresa].[pSimplesNacionalValorAliquotaCreditoICMS] = @pSimplesNacionalValorAliquotaCreditoICMS,
 [empresa].[sSimplesNacionalCategoria] = @sSimplesNacionalCategoria,
 [empresa].[sCodigoRegimeTributario] = @sCodigoRegimeTributario,
 [empresa].[sCodigoRegimeTributarioNormal] = @sCodigoRegimeTributarioNormal,
 [empresa].[_trackLastWriteUser] = @_trackLastWriteUser,
 [empresa].[_trackLastWriteTime] = GETDATE()
    WHERE ([empresa].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [empresa] (
        [empresa].[pCodigo],
        [empresa].[pNome],
        [empresa].[xDataHoraReg],
        [empresa].[xLoginReg],
        [empresa].[pSimplesNacionalValorAliquotaCreditoICMS],
        [empresa].[sSimplesNacionalCategoria],
        [empresa].[sCodigoRegimeTributario],
        [empresa].[sCodigoRegimeTributarioNormal],
        [empresa].[_trackCreationUser],
        [empresa].[_trackLastWriteUser])
    VALUES (
        @pCodigo,
        @pNome,
        @xDataHoraReg,
        @xLoginReg,
        @pSimplesNacionalValorAliquotaCreditoICMS,
        @sSimplesNacionalCategoria,
        @sCodigoRegimeTributario,
        @sCodigoRegimeTributarioNormal,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [empresa] 
        WHERE ([empresa].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[empresa_Savecadastrooempresas]
(
 @pId [bigint],
 @pId2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
SELECT DISTINCT TOP 1 [cadastro_oempresas_empresa_ocadastros].[pId] 
    FROM [cadastro_oempresas_empresa_ocadastros] 
    WHERE (([cadastro_oempresas_empresa_ocadastros].[pId2] = @pId2) AND ([cadastro_oempresas_empresa_ocadastros].[pId] = @pId))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [cadastro_oempresas_empresa_ocadastros] (
        [cadastro_oempresas_empresa_ocadastros].[pId],
        [cadastro_oempresas_empresa_ocadastros].[pId2])
    VALUES (
        @pId,
        @pId2)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ENT_CAMBAL_CAMINHAOVIAGENS] FROM [ENT_CAMBAL_CAMINHAOVIAGENS] 
    WHERE ([ENT_CAMBAL_CAMINHAOVIAGENS].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_Save]
(
 @pId [bigint] = NULL,
 @ROWNUM [int] = NULL,
 @FRENTE [int] = NULL,
 @COD_PROP [int] = NULL,
 @CAMINHAO [int] = NULL,
 @QTD_VIAGENS [int] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ENT_CAMBAL_CAMINHAOVIAGENS] SET
 [ENT_CAMBAL_CAMINHAOVIAGENS].[ROWNUM] = @ROWNUM,
 [ENT_CAMBAL_CAMINHAOVIAGENS].[FRENTE] = @FRENTE,
 [ENT_CAMBAL_CAMINHAOVIAGENS].[COD_PROP] = @COD_PROP,
 [ENT_CAMBAL_CAMINHAOVIAGENS].[CAMINHAO] = @CAMINHAO,
 [ENT_CAMBAL_CAMINHAOVIAGENS].[QTD_VIAGENS] = @QTD_VIAGENS,
 [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteTime] = GETDATE()
    WHERE ([ENT_CAMBAL_CAMINHAOVIAGENS].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ENT_CAMBAL_CAMINHAOVIAGENS] (
        [ENT_CAMBAL_CAMINHAOVIAGENS].[ROWNUM],
        [ENT_CAMBAL_CAMINHAOVIAGENS].[FRENTE],
        [ENT_CAMBAL_CAMINHAOVIAGENS].[COD_PROP],
        [ENT_CAMBAL_CAMINHAOVIAGENS].[CAMINHAO],
        [ENT_CAMBAL_CAMINHAOVIAGENS].[QTD_VIAGENS],
        [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackCreationUser],
        [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteUser])
    VALUES (
        @ROWNUM,
        @FRENTE,
        @COD_PROP,
        @CAMINHAO,
        @QTD_VIAGENS,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ENT_CAMBAL_CAMINHAOVIAGENS] 
        WHERE ([ENT_CAMBAL_CAMINHAOVIAGENS].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_FRENTESPROP_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ENT_CAMBAL_FRENTESPROP] FROM [ENT_CAMBAL_FRENTESPROP] 
    WHERE ([ENT_CAMBAL_FRENTESPROP].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_FRENTESPROP_Save]
(
 @pId [bigint] = NULL,
 @ROWNUM [int] = NULL,
 @FRENTE [int] = NULL,
 @COD_PROP [int] = NULL,
 @PROPRIEDADE [nvarchar] (256) = NULL,
 @QTD_VIAGENS [int] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ENT_CAMBAL_FRENTESPROP] SET
 [ENT_CAMBAL_FRENTESPROP].[ROWNUM] = @ROWNUM,
 [ENT_CAMBAL_FRENTESPROP].[FRENTE] = @FRENTE,
 [ENT_CAMBAL_FRENTESPROP].[COD_PROP] = @COD_PROP,
 [ENT_CAMBAL_FRENTESPROP].[PROPRIEDADE] = @PROPRIEDADE,
 [ENT_CAMBAL_FRENTESPROP].[QTD_VIAGENS] = @QTD_VIAGENS,
 [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteTime] = GETDATE()
    WHERE ([ENT_CAMBAL_FRENTESPROP].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ENT_CAMBAL_FRENTESPROP] (
        [ENT_CAMBAL_FRENTESPROP].[ROWNUM],
        [ENT_CAMBAL_FRENTESPROP].[FRENTE],
        [ENT_CAMBAL_FRENTESPROP].[COD_PROP],
        [ENT_CAMBAL_FRENTESPROP].[PROPRIEDADE],
        [ENT_CAMBAL_FRENTESPROP].[QTD_VIAGENS],
        [ENT_CAMBAL_FRENTESPROP].[_trackCreationUser],
        [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteUser])
    VALUES (
        @ROWNUM,
        @FRENTE,
        @COD_PROP,
        @PROPRIEDADE,
        @QTD_VIAGENS,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ENT_CAMBAL_FRENTESPROP] 
        WHERE ([ENT_CAMBAL_FRENTESPROP].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_PRINCIPAL_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ENT_CAMBAL_PRINCIPAL] FROM [ENT_CAMBAL_PRINCIPAL] 
    WHERE ([ENT_CAMBAL_PRINCIPAL].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_PRINCIPAL_Save]
(
 @pId [bigint] = NULL,
 @HORA [int] = NULL,
 @F1 [int] = NULL,
 @F2 [int] = NULL,
 @F3 [int] = NULL,
 @F4 [int] = NULL,
 @F5 [int] = NULL,
 @F6 [int] = NULL,
 @F7 [int] = NULL,
 @F8 [int] = NULL,
 @F9 [int] = NULL,
 @F10 [int] = NULL,
 @TOTAL [int] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ENT_CAMBAL_PRINCIPAL] SET
 [ENT_CAMBAL_PRINCIPAL].[HORA] = @HORA,
 [ENT_CAMBAL_PRINCIPAL].[F1] = @F1,
 [ENT_CAMBAL_PRINCIPAL].[F2] = @F2,
 [ENT_CAMBAL_PRINCIPAL].[F3] = @F3,
 [ENT_CAMBAL_PRINCIPAL].[F4] = @F4,
 [ENT_CAMBAL_PRINCIPAL].[F5] = @F5,
 [ENT_CAMBAL_PRINCIPAL].[F6] = @F6,
 [ENT_CAMBAL_PRINCIPAL].[F7] = @F7,
 [ENT_CAMBAL_PRINCIPAL].[F8] = @F8,
 [ENT_CAMBAL_PRINCIPAL].[F9] = @F9,
 [ENT_CAMBAL_PRINCIPAL].[F10] = @F10,
 [ENT_CAMBAL_PRINCIPAL].[TOTAL] = @TOTAL,
 [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteTime] = GETDATE()
    WHERE ([ENT_CAMBAL_PRINCIPAL].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ENT_CAMBAL_PRINCIPAL] (
        [ENT_CAMBAL_PRINCIPAL].[HORA],
        [ENT_CAMBAL_PRINCIPAL].[F1],
        [ENT_CAMBAL_PRINCIPAL].[F2],
        [ENT_CAMBAL_PRINCIPAL].[F3],
        [ENT_CAMBAL_PRINCIPAL].[F4],
        [ENT_CAMBAL_PRINCIPAL].[F5],
        [ENT_CAMBAL_PRINCIPAL].[F6],
        [ENT_CAMBAL_PRINCIPAL].[F7],
        [ENT_CAMBAL_PRINCIPAL].[F8],
        [ENT_CAMBAL_PRINCIPAL].[F9],
        [ENT_CAMBAL_PRINCIPAL].[F10],
        [ENT_CAMBAL_PRINCIPAL].[TOTAL],
        [ENT_CAMBAL_PRINCIPAL].[_trackCreationUser],
        [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteUser])
    VALUES (
        @HORA,
        @F1,
        @F2,
        @F3,
        @F4,
        @F5,
        @F6,
        @F7,
        @F8,
        @F9,
        @F10,
        @TOTAL,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ENT_CAMBAL_PRINCIPAL] 
        WHERE ([ENT_CAMBAL_PRINCIPAL].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_AGRUP_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ENTRADA_CANA_DET_AGRUP] FROM [ENTRADA_CANA_DET_AGRUP] 
    WHERE ([ENTRADA_CANA_DET_AGRUP].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_AGRUP_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @NR_ANO_SAFRA [int] = NULL,
 @NRO_DOCUMENTO [int] = NULL,
 @PROP_CODIGO [int] = NULL,
 @DS_NOME_PROPRIEDADE [nvarchar] (256) = NULL,
 @FRENTE_COLHEITA [nvarchar] (256) = NULL,
 @MUNICIPIO [int] = NULL,
 @DESCMUNI [nvarchar] (256) = NULL,
 @TIPO [int] = NULL,
 @DESCTIPO [nvarchar] (256) = NULL,
 @DT_ENTRADA [date] = NULL,
 @DT_MOAGEM [date] = NULL,
 @AREA_COLHIDA [float] = NULL,
 @QT_TON_ENTREGUE_REAL [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ENTRADA_CANA_DET_AGRUP] SET
 [ENTRADA_CANA_DET_AGRUP].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [ENTRADA_CANA_DET_AGRUP].[NR_ANO_SAFRA] = @NR_ANO_SAFRA,
 [ENTRADA_CANA_DET_AGRUP].[NRO_DOCUMENTO] = @NRO_DOCUMENTO,
 [ENTRADA_CANA_DET_AGRUP].[PROP_CODIGO] = @PROP_CODIGO,
 [ENTRADA_CANA_DET_AGRUP].[DS_NOME_PROPRIEDADE] = @DS_NOME_PROPRIEDADE,
 [ENTRADA_CANA_DET_AGRUP].[FRENTE_COLHEITA] = @FRENTE_COLHEITA,
 [ENTRADA_CANA_DET_AGRUP].[MUNICIPIO] = @MUNICIPIO,
 [ENTRADA_CANA_DET_AGRUP].[DESCMUNI] = @DESCMUNI,
 [ENTRADA_CANA_DET_AGRUP].[TIPO] = @TIPO,
 [ENTRADA_CANA_DET_AGRUP].[DESCTIPO] = @DESCTIPO,
 [ENTRADA_CANA_DET_AGRUP].[DT_ENTRADA] = @DT_ENTRADA,
 [ENTRADA_CANA_DET_AGRUP].[DT_MOAGEM] = @DT_MOAGEM,
 [ENTRADA_CANA_DET_AGRUP].[AREA_COLHIDA] = @AREA_COLHIDA,
 [ENTRADA_CANA_DET_AGRUP].[QT_TON_ENTREGUE_REAL] = @QT_TON_ENTREGUE_REAL,
 [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteTime] = GETDATE()
    WHERE ([ENTRADA_CANA_DET_AGRUP].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ENTRADA_CANA_DET_AGRUP] (
        [ENTRADA_CANA_DET_AGRUP].[ID_NEGOCIOS],
        [ENTRADA_CANA_DET_AGRUP].[NR_ANO_SAFRA],
        [ENTRADA_CANA_DET_AGRUP].[NRO_DOCUMENTO],
        [ENTRADA_CANA_DET_AGRUP].[PROP_CODIGO],
        [ENTRADA_CANA_DET_AGRUP].[DS_NOME_PROPRIEDADE],
        [ENTRADA_CANA_DET_AGRUP].[FRENTE_COLHEITA],
        [ENTRADA_CANA_DET_AGRUP].[MUNICIPIO],
        [ENTRADA_CANA_DET_AGRUP].[DESCMUNI],
        [ENTRADA_CANA_DET_AGRUP].[TIPO],
        [ENTRADA_CANA_DET_AGRUP].[DESCTIPO],
        [ENTRADA_CANA_DET_AGRUP].[DT_ENTRADA],
        [ENTRADA_CANA_DET_AGRUP].[DT_MOAGEM],
        [ENTRADA_CANA_DET_AGRUP].[AREA_COLHIDA],
        [ENTRADA_CANA_DET_AGRUP].[QT_TON_ENTREGUE_REAL],
        [ENTRADA_CANA_DET_AGRUP].[_trackCreationUser],
        [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @NR_ANO_SAFRA,
        @NRO_DOCUMENTO,
        @PROP_CODIGO,
        @DS_NOME_PROPRIEDADE,
        @FRENTE_COLHEITA,
        @MUNICIPIO,
        @DESCMUNI,
        @TIPO,
        @DESCTIPO,
        @DT_ENTRADA,
        @DT_MOAGEM,
        @AREA_COLHIDA,
        @QT_TON_ENTREGUE_REAL,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ENTRADA_CANA_DET_AGRUP] 
        WHERE ([ENTRADA_CANA_DET_AGRUP].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ENTRADA_CANA_DET] FROM [ENTRADA_CANA_DET] 
    WHERE ([ENTRADA_CANA_DET].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_MP_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ENTRADA_CANA_DET_MP] FROM [ENTRADA_CANA_DET_MP] 
    WHERE ([ENTRADA_CANA_DET_MP].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_MP_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @NR_ANO_SAFRA [int] = NULL,
 @PROP_CODIGO [int] = NULL,
 @DS_NOME_PROPRIEDADE [nvarchar] (256) = NULL,
 @FRENTE_COLHEITATOP [nvarchar] (256) = NULL,
 @FRENTE_COLHEITA [nvarchar] (256) = NULL,
 @MUNICIPIO [int] = NULL,
 @DESCMUNI [nvarchar] (256) = NULL,
 @QT_TON_ENTREGUE_REAL [float] = NULL,
 @INICIO [date] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ENTRADA_CANA_DET_MP] SET
 [ENTRADA_CANA_DET_MP].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [ENTRADA_CANA_DET_MP].[NR_ANO_SAFRA] = @NR_ANO_SAFRA,
 [ENTRADA_CANA_DET_MP].[PROP_CODIGO] = @PROP_CODIGO,
 [ENTRADA_CANA_DET_MP].[DS_NOME_PROPRIEDADE] = @DS_NOME_PROPRIEDADE,
 [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITATOP] = @FRENTE_COLHEITATOP,
 [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITA] = @FRENTE_COLHEITA,
 [ENTRADA_CANA_DET_MP].[MUNICIPIO] = @MUNICIPIO,
 [ENTRADA_CANA_DET_MP].[DESCMUNI] = @DESCMUNI,
 [ENTRADA_CANA_DET_MP].[QT_TON_ENTREGUE_REAL] = @QT_TON_ENTREGUE_REAL,
 [ENTRADA_CANA_DET_MP].[INICIO] = @INICIO,
 [ENTRADA_CANA_DET_MP].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ENTRADA_CANA_DET_MP].[_trackLastWriteTime] = GETDATE()
    WHERE ([ENTRADA_CANA_DET_MP].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ENTRADA_CANA_DET_MP] (
        [ENTRADA_CANA_DET_MP].[ID_NEGOCIOS],
        [ENTRADA_CANA_DET_MP].[NR_ANO_SAFRA],
        [ENTRADA_CANA_DET_MP].[PROP_CODIGO],
        [ENTRADA_CANA_DET_MP].[DS_NOME_PROPRIEDADE],
        [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITATOP],
        [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITA],
        [ENTRADA_CANA_DET_MP].[MUNICIPIO],
        [ENTRADA_CANA_DET_MP].[DESCMUNI],
        [ENTRADA_CANA_DET_MP].[QT_TON_ENTREGUE_REAL],
        [ENTRADA_CANA_DET_MP].[INICIO],
        [ENTRADA_CANA_DET_MP].[_trackCreationUser],
        [ENTRADA_CANA_DET_MP].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @NR_ANO_SAFRA,
        @PROP_CODIGO,
        @DS_NOME_PROPRIEDADE,
        @FRENTE_COLHEITATOP,
        @FRENTE_COLHEITA,
        @MUNICIPIO,
        @DESCMUNI,
        @QT_TON_ENTREGUE_REAL,
        @INICIO,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ENTRADA_CANA_DET_MP] 
        WHERE ([ENTRADA_CANA_DET_MP].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @NR_ANO_SAFRA [int] = NULL,
 @NRO_DOCUMENTO [int] = NULL,
 @PROP_CODIGO [int] = NULL,
 @DS_NOME_PROPRIEDADE [nvarchar] (256) = NULL,
 @DSC_VARIEDADE [nvarchar] (256) = NULL,
 @NRO_CORTE [int] = NULL,
 @FRENTE_COLHEITA [nvarchar] (256) = NULL,
 @MUNICIPIO [int] = NULL,
 @DESCMUNI [nvarchar] (256) = NULL,
 @TIPO [int] = NULL,
 @DESCTIPO [nvarchar] (256) = NULL,
 @DT_ENTRADA [date] = NULL,
 @EQUIP_ENTRADA [int] = NULL,
 @REBOQUE [int] = NULL,
 @DT_MOAGEM [date] = NULL,
 @AREA_COLHIDA [float] = NULL,
 @QT_TON_ENTREGUE_PREV [float] = NULL,
 @QT_TON_ENTREGUE_REAL [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ENTRADA_CANA_DET] SET
 [ENTRADA_CANA_DET].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [ENTRADA_CANA_DET].[NR_ANO_SAFRA] = @NR_ANO_SAFRA,
 [ENTRADA_CANA_DET].[NRO_DOCUMENTO] = @NRO_DOCUMENTO,
 [ENTRADA_CANA_DET].[PROP_CODIGO] = @PROP_CODIGO,
 [ENTRADA_CANA_DET].[DS_NOME_PROPRIEDADE] = @DS_NOME_PROPRIEDADE,
 [ENTRADA_CANA_DET].[DSC_VARIEDADE] = @DSC_VARIEDADE,
 [ENTRADA_CANA_DET].[NRO_CORTE] = @NRO_CORTE,
 [ENTRADA_CANA_DET].[FRENTE_COLHEITA] = @FRENTE_COLHEITA,
 [ENTRADA_CANA_DET].[MUNICIPIO] = @MUNICIPIO,
 [ENTRADA_CANA_DET].[DESCMUNI] = @DESCMUNI,
 [ENTRADA_CANA_DET].[TIPO] = @TIPO,
 [ENTRADA_CANA_DET].[DESCTIPO] = @DESCTIPO,
 [ENTRADA_CANA_DET].[DT_ENTRADA] = @DT_ENTRADA,
 [ENTRADA_CANA_DET].[EQUIP_ENTRADA] = @EQUIP_ENTRADA,
 [ENTRADA_CANA_DET].[REBOQUE] = @REBOQUE,
 [ENTRADA_CANA_DET].[DT_MOAGEM] = @DT_MOAGEM,
 [ENTRADA_CANA_DET].[AREA_COLHIDA] = @AREA_COLHIDA,
 [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_PREV] = @QT_TON_ENTREGUE_PREV,
 [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_REAL] = @QT_TON_ENTREGUE_REAL,
 [ENTRADA_CANA_DET].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ENTRADA_CANA_DET].[_trackLastWriteTime] = GETDATE()
    WHERE ([ENTRADA_CANA_DET].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ENTRADA_CANA_DET] (
        [ENTRADA_CANA_DET].[ID_NEGOCIOS],
        [ENTRADA_CANA_DET].[NR_ANO_SAFRA],
        [ENTRADA_CANA_DET].[NRO_DOCUMENTO],
        [ENTRADA_CANA_DET].[PROP_CODIGO],
        [ENTRADA_CANA_DET].[DS_NOME_PROPRIEDADE],
        [ENTRADA_CANA_DET].[DSC_VARIEDADE],
        [ENTRADA_CANA_DET].[NRO_CORTE],
        [ENTRADA_CANA_DET].[FRENTE_COLHEITA],
        [ENTRADA_CANA_DET].[MUNICIPIO],
        [ENTRADA_CANA_DET].[DESCMUNI],
        [ENTRADA_CANA_DET].[TIPO],
        [ENTRADA_CANA_DET].[DESCTIPO],
        [ENTRADA_CANA_DET].[DT_ENTRADA],
        [ENTRADA_CANA_DET].[EQUIP_ENTRADA],
        [ENTRADA_CANA_DET].[REBOQUE],
        [ENTRADA_CANA_DET].[DT_MOAGEM],
        [ENTRADA_CANA_DET].[AREA_COLHIDA],
        [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_PREV],
        [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_REAL],
        [ENTRADA_CANA_DET].[_trackCreationUser],
        [ENTRADA_CANA_DET].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @NR_ANO_SAFRA,
        @NRO_DOCUMENTO,
        @PROP_CODIGO,
        @DS_NOME_PROPRIEDADE,
        @DSC_VARIEDADE,
        @NRO_CORTE,
        @FRENTE_COLHEITA,
        @MUNICIPIO,
        @DESCMUNI,
        @TIPO,
        @DESCTIPO,
        @DT_ENTRADA,
        @EQUIP_ENTRADA,
        @REBOQUE,
        @DT_MOAGEM,
        @AREA_COLHIDA,
        @QT_TON_ENTREGUE_PREV,
        @QT_TON_ENTREGUE_REAL,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ENTRADA_CANA_DET] 
        WHERE ([ENTRADA_CANA_DET].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ENTRADA_CANA_HORA] FROM [ENTRADA_CANA_HORA] 
    WHERE ([ENTRADA_CANA_HORA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ENTRADA_CANA_HORA_FRENTE] FROM [ENTRADA_CANA_HORA_FRENTE] 
    WHERE ([ENTRADA_CANA_HORA_FRENTE].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @DIA [date] = NULL,
 @HORA [nvarchar] (256) = NULL,
 @FRENTE [int] = NULL,
 @TONELADAS [float] = NULL,
 @VIAGEM [int] = NULL,
 @TON_VIAGEM [float] = NULL,
 @METAFRENTE [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ENTRADA_CANA_HORA_FRENTE] SET
 [ENTRADA_CANA_HORA_FRENTE].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [ENTRADA_CANA_HORA_FRENTE].[DIA] = @DIA,
 [ENTRADA_CANA_HORA_FRENTE].[HORA] = @HORA,
 [ENTRADA_CANA_HORA_FRENTE].[FRENTE] = @FRENTE,
 [ENTRADA_CANA_HORA_FRENTE].[TONELADAS] = @TONELADAS,
 [ENTRADA_CANA_HORA_FRENTE].[VIAGEM] = @VIAGEM,
 [ENTRADA_CANA_HORA_FRENTE].[TON_VIAGEM] = @TON_VIAGEM,
 [ENTRADA_CANA_HORA_FRENTE].[METAFRENTE] = @METAFRENTE,
 [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteTime] = GETDATE()
    WHERE ([ENTRADA_CANA_HORA_FRENTE].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ENTRADA_CANA_HORA_FRENTE] (
        [ENTRADA_CANA_HORA_FRENTE].[ID_NEGOCIOS],
        [ENTRADA_CANA_HORA_FRENTE].[DIA],
        [ENTRADA_CANA_HORA_FRENTE].[HORA],
        [ENTRADA_CANA_HORA_FRENTE].[FRENTE],
        [ENTRADA_CANA_HORA_FRENTE].[TONELADAS],
        [ENTRADA_CANA_HORA_FRENTE].[VIAGEM],
        [ENTRADA_CANA_HORA_FRENTE].[TON_VIAGEM],
        [ENTRADA_CANA_HORA_FRENTE].[METAFRENTE],
        [ENTRADA_CANA_HORA_FRENTE].[_trackCreationUser],
        [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @DIA,
        @HORA,
        @FRENTE,
        @TONELADAS,
        @VIAGEM,
        @TON_VIAGEM,
        @METAFRENTE,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ENTRADA_CANA_HORA_FRENTE] 
        WHERE ([ENTRADA_CANA_HORA_FRENTE].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @DIA [date] = NULL,
 @HORA [nvarchar] (256) = NULL,
 @TONELADAS [float] = NULL,
 @VIAGEM [int] = NULL,
 @TON_VIAGEM [float] = NULL,
 @METAFRENTE [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ENTRADA_CANA_HORA] SET
 [ENTRADA_CANA_HORA].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [ENTRADA_CANA_HORA].[DIA] = @DIA,
 [ENTRADA_CANA_HORA].[HORA] = @HORA,
 [ENTRADA_CANA_HORA].[TONELADAS] = @TONELADAS,
 [ENTRADA_CANA_HORA].[VIAGEM] = @VIAGEM,
 [ENTRADA_CANA_HORA].[TON_VIAGEM] = @TON_VIAGEM,
 [ENTRADA_CANA_HORA].[METAFRENTE] = @METAFRENTE,
 [ENTRADA_CANA_HORA].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ENTRADA_CANA_HORA].[_trackLastWriteTime] = GETDATE()
    WHERE ([ENTRADA_CANA_HORA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ENTRADA_CANA_HORA] (
        [ENTRADA_CANA_HORA].[ID_NEGOCIOS],
        [ENTRADA_CANA_HORA].[DIA],
        [ENTRADA_CANA_HORA].[HORA],
        [ENTRADA_CANA_HORA].[TONELADAS],
        [ENTRADA_CANA_HORA].[VIAGEM],
        [ENTRADA_CANA_HORA].[TON_VIAGEM],
        [ENTRADA_CANA_HORA].[METAFRENTE],
        [ENTRADA_CANA_HORA].[_trackCreationUser],
        [ENTRADA_CANA_HORA].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @DIA,
        @HORA,
        @TONELADAS,
        @VIAGEM,
        @TON_VIAGEM,
        @METAFRENTE,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ENTRADA_CANA_HORA] 
        WHERE ([ENTRADA_CANA_HORA].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ESCALA_COLAB_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [ESCALA_COLAB] FROM [ESCALA_COLAB] 
    WHERE ([ESCALA_COLAB].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ESCALA_COLAB_Save]
(
 @pId [bigint] = NULL,
 @ROWNUM [int] = NULL,
 @PROCESSO [nvarchar] (256) = NULL,
 @ESTRUTURA [nvarchar] (256) = NULL,
 @MATRICULA [int] = NULL,
 @NOME [nvarchar] (256) = NULL,
 @TURNO [nvarchar] (256) = NULL,
 @DIA01 [nvarchar] (256) = NULL,
 @DIA02 [nvarchar] (256) = NULL,
 @DIA03 [nvarchar] (256) = NULL,
 @DIA04 [nvarchar] (256) = NULL,
 @DIA05 [nvarchar] (256) = NULL,
 @DIA06 [nvarchar] (256) = NULL,
 @DIA07 [nvarchar] (256) = NULL,
 @DIA08 [nvarchar] (256) = NULL,
 @DIA09 [nvarchar] (256) = NULL,
 @DIA10 [nvarchar] (256) = NULL,
 @DIA11 [nvarchar] (256) = NULL,
 @DIA12 [nvarchar] (256) = NULL,
 @DIA13 [nvarchar] (256) = NULL,
 @DIA14 [nvarchar] (256) = NULL,
 @DIA15 [nvarchar] (256) = NULL,
 @DIA16 [nvarchar] (256) = NULL,
 @DIA17 [nvarchar] (256) = NULL,
 @DIA18 [nvarchar] (256) = NULL,
 @DIA19 [nvarchar] (256) = NULL,
 @DIA20 [nvarchar] (256) = NULL,
 @DIA21 [nvarchar] (256) = NULL,
 @DIA22 [nvarchar] (256) = NULL,
 @DIA23 [nvarchar] (256) = NULL,
 @DIA24 [nvarchar] (256) = NULL,
 @DIA25 [nvarchar] (256) = NULL,
 @DIA26 [nvarchar] (256) = NULL,
 @DIA27 [nvarchar] (256) = NULL,
 @DIA28 [nvarchar] (256) = NULL,
 @DIA29 [nvarchar] (256) = NULL,
 @DIA30 [nvarchar] (256) = NULL,
 @CELULAR [nvarchar] (256) = NULL,
 @ID_NIVEL [int] = NULL,
 @ID_TURMAS [int] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [ESCALA_COLAB] SET
 [ESCALA_COLAB].[ROWNUM] = @ROWNUM,
 [ESCALA_COLAB].[PROCESSO] = @PROCESSO,
 [ESCALA_COLAB].[ESTRUTURA] = @ESTRUTURA,
 [ESCALA_COLAB].[MATRICULA] = @MATRICULA,
 [ESCALA_COLAB].[NOME] = @NOME,
 [ESCALA_COLAB].[TURNO] = @TURNO,
 [ESCALA_COLAB].[DIA01] = @DIA01,
 [ESCALA_COLAB].[DIA02] = @DIA02,
 [ESCALA_COLAB].[DIA03] = @DIA03,
 [ESCALA_COLAB].[DIA04] = @DIA04,
 [ESCALA_COLAB].[DIA05] = @DIA05,
 [ESCALA_COLAB].[DIA06] = @DIA06,
 [ESCALA_COLAB].[DIA07] = @DIA07,
 [ESCALA_COLAB].[DIA08] = @DIA08,
 [ESCALA_COLAB].[DIA09] = @DIA09,
 [ESCALA_COLAB].[DIA10] = @DIA10,
 [ESCALA_COLAB].[DIA11] = @DIA11,
 [ESCALA_COLAB].[DIA12] = @DIA12,
 [ESCALA_COLAB].[DIA13] = @DIA13,
 [ESCALA_COLAB].[DIA14] = @DIA14,
 [ESCALA_COLAB].[DIA15] = @DIA15,
 [ESCALA_COLAB].[DIA16] = @DIA16,
 [ESCALA_COLAB].[DIA17] = @DIA17,
 [ESCALA_COLAB].[DIA18] = @DIA18,
 [ESCALA_COLAB].[DIA19] = @DIA19,
 [ESCALA_COLAB].[DIA20] = @DIA20,
 [ESCALA_COLAB].[DIA21] = @DIA21,
 [ESCALA_COLAB].[DIA22] = @DIA22,
 [ESCALA_COLAB].[DIA23] = @DIA23,
 [ESCALA_COLAB].[DIA24] = @DIA24,
 [ESCALA_COLAB].[DIA25] = @DIA25,
 [ESCALA_COLAB].[DIA26] = @DIA26,
 [ESCALA_COLAB].[DIA27] = @DIA27,
 [ESCALA_COLAB].[DIA28] = @DIA28,
 [ESCALA_COLAB].[DIA29] = @DIA29,
 [ESCALA_COLAB].[DIA30] = @DIA30,
 [ESCALA_COLAB].[CELULAR] = @CELULAR,
 [ESCALA_COLAB].[ID_NIVEL] = @ID_NIVEL,
 [ESCALA_COLAB].[ID_TURMAS] = @ID_TURMAS,
 [ESCALA_COLAB].[_trackLastWriteUser] = @_trackLastWriteUser,
 [ESCALA_COLAB].[_trackLastWriteTime] = GETDATE()
    WHERE ([ESCALA_COLAB].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [ESCALA_COLAB] (
        [ESCALA_COLAB].[ROWNUM],
        [ESCALA_COLAB].[PROCESSO],
        [ESCALA_COLAB].[ESTRUTURA],
        [ESCALA_COLAB].[MATRICULA],
        [ESCALA_COLAB].[NOME],
        [ESCALA_COLAB].[TURNO],
        [ESCALA_COLAB].[DIA01],
        [ESCALA_COLAB].[DIA02],
        [ESCALA_COLAB].[DIA03],
        [ESCALA_COLAB].[DIA04],
        [ESCALA_COLAB].[DIA05],
        [ESCALA_COLAB].[DIA06],
        [ESCALA_COLAB].[DIA07],
        [ESCALA_COLAB].[DIA08],
        [ESCALA_COLAB].[DIA09],
        [ESCALA_COLAB].[DIA10],
        [ESCALA_COLAB].[DIA11],
        [ESCALA_COLAB].[DIA12],
        [ESCALA_COLAB].[DIA13],
        [ESCALA_COLAB].[DIA14],
        [ESCALA_COLAB].[DIA15],
        [ESCALA_COLAB].[DIA16],
        [ESCALA_COLAB].[DIA17],
        [ESCALA_COLAB].[DIA18],
        [ESCALA_COLAB].[DIA19],
        [ESCALA_COLAB].[DIA20],
        [ESCALA_COLAB].[DIA21],
        [ESCALA_COLAB].[DIA22],
        [ESCALA_COLAB].[DIA23],
        [ESCALA_COLAB].[DIA24],
        [ESCALA_COLAB].[DIA25],
        [ESCALA_COLAB].[DIA26],
        [ESCALA_COLAB].[DIA27],
        [ESCALA_COLAB].[DIA28],
        [ESCALA_COLAB].[DIA29],
        [ESCALA_COLAB].[DIA30],
        [ESCALA_COLAB].[CELULAR],
        [ESCALA_COLAB].[ID_NIVEL],
        [ESCALA_COLAB].[ID_TURMAS],
        [ESCALA_COLAB].[_trackCreationUser],
        [ESCALA_COLAB].[_trackLastWriteUser])
    VALUES (
        @ROWNUM,
        @PROCESSO,
        @ESTRUTURA,
        @MATRICULA,
        @NOME,
        @TURNO,
        @DIA01,
        @DIA02,
        @DIA03,
        @DIA04,
        @DIA05,
        @DIA06,
        @DIA07,
        @DIA08,
        @DIA09,
        @DIA10,
        @DIA11,
        @DIA12,
        @DIA13,
        @DIA14,
        @DIA15,
        @DIA16,
        @DIA17,
        @DIA18,
        @DIA19,
        @DIA20,
        @DIA21,
        @DIA22,
        @DIA23,
        @DIA24,
        @DIA25,
        @DIA26,
        @DIA27,
        @DIA28,
        @DIA29,
        @DIA30,
        @CELULAR,
        @ID_NIVEL,
        @ID_TURMAS,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [ESCALA_COLAB] 
        WHERE ([ESCALA_COLAB].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[filial_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [filial_ousuarios_usuario_ofiliais] FROM [filial_ousuarios_usuario_ofiliais] 
    WHERE ([filial_ousuarios_usuario_ofiliais].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
UPDATE [filialconfig] SET
 [filialconfig].[oFilial_pId] = NULL
    WHERE ([filialconfig].[oFilial_pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
DELETE [filial] FROM [filial] 
    WHERE ([filial].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[filial_Save]
(
 @pId [bigint] = NULL,
 @pCodigo [int] = NULL,
 @pNome [nvarchar] (256) = NULL,
 @sTipo [int] = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @oEmpresa_pId [bigint] = NULL,
 @oCadastro_pId [bigint] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [filial] SET
 [filial].[pCodigo] = @pCodigo,
 [filial].[pNome] = @pNome,
 [filial].[sTipo] = @sTipo,
 [filial].[xDataHoraReg] = @xDataHoraReg,
 [filial].[xLoginReg] = @xLoginReg,
 [filial].[oEmpresa_pId] = @oEmpresa_pId,
 [filial].[oCadastro_pId] = @oCadastro_pId,
 [filial].[_trackLastWriteUser] = @_trackLastWriteUser,
 [filial].[_trackLastWriteTime] = GETDATE()
    WHERE ([filial].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [filial] (
        [filial].[pCodigo],
        [filial].[pNome],
        [filial].[sTipo],
        [filial].[xDataHoraReg],
        [filial].[xLoginReg],
        [filial].[oEmpresa_pId],
        [filial].[oCadastro_pId],
        [filial].[_trackCreationUser],
        [filial].[_trackLastWriteUser])
    VALUES (
        @pCodigo,
        @pNome,
        @sTipo,
        @xDataHoraReg,
        @xLoginReg,
        @oEmpresa_pId,
        @oCadastro_pId,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [filial] 
        WHERE ([filial].[pId] = @pId)
END
IF(@oCadastro_pId IS NOT NULL)
BEGIN
    UPDATE [cadastro] SET
     [cadastro].[oCadastroFilial_pId] = @pId
        WHERE ([cadastro].[pId] = @oCadastro_pId)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[filialconfig_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [filialconfig] FROM [filialconfig] 
    WHERE ([filialconfig].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[filialconfig_Save]
(
 @pId [bigint] = NULL,
 @sTipo [int] = NULL,
 @pConteudo [nvarchar] (256) = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @oFilial_pId [bigint] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [filialconfig] SET
 [filialconfig].[sTipo] = @sTipo,
 [filialconfig].[pConteudo] = @pConteudo,
 [filialconfig].[xDataHoraReg] = @xDataHoraReg,
 [filialconfig].[xLoginReg] = @xLoginReg,
 [filialconfig].[oFilial_pId] = @oFilial_pId,
 [filialconfig].[_trackLastWriteUser] = @_trackLastWriteUser,
 [filialconfig].[_trackLastWriteTime] = GETDATE()
    WHERE ([filialconfig].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [filialconfig] (
        [filialconfig].[sTipo],
        [filialconfig].[pConteudo],
        [filialconfig].[xDataHoraReg],
        [filialconfig].[xLoginReg],
        [filialconfig].[oFilial_pId],
        [filialconfig].[_trackCreationUser],
        [filialconfig].[_trackLastWriteUser])
    VALUES (
        @sTipo,
        @pConteudo,
        @xDataHoraReg,
        @xLoginReg,
        @oFilial_pId,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [filialconfig] 
        WHERE ([filialconfig].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [HISTORICO_PROPRIEDADE] FROM [HISTORICO_PROPRIEDADE] 
    WHERE ([HISTORICO_PROPRIEDADE].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @SAFRA [int] = NULL,
 @COD_PROPRIEDADE [int] = NULL,
 @DSC_PROPRIEDADE [nvarchar] (256) = NULL,
 @TALHAO [int] = NULL,
 @RENDIMENTO_PLAN [float] = NULL,
 @CORTE [int] = NULL,
 @AMBIENTE [nvarchar] (256) = NULL,
 @DT_PLANTIO [date] = NULL,
 @DT_COLHEITA_ANT [date] = NULL,
 @DT_COLHEITA_ATU [date] = NULL,
 @AREA_TOTAL [float] = NULL,
 @AREA_LIBERADA [float] = NULL,
 @TONELADA [float] = NULL,
 @RENDIMENTO_REAL [float] = NULL,
 @TCH [float] = NULL,
 @IDADE [float] = NULL,
 @PERC_BROCA [float] = NULL,
 @PERC_PERDA [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [HISTORICO_PROPRIEDADE] SET
 [HISTORICO_PROPRIEDADE].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [HISTORICO_PROPRIEDADE].[SAFRA] = @SAFRA,
 [HISTORICO_PROPRIEDADE].[COD_PROPRIEDADE] = @COD_PROPRIEDADE,
 [HISTORICO_PROPRIEDADE].[DSC_PROPRIEDADE] = @DSC_PROPRIEDADE,
 [HISTORICO_PROPRIEDADE].[TALHAO] = @TALHAO,
 [HISTORICO_PROPRIEDADE].[RENDIMENTO_PLAN] = @RENDIMENTO_PLAN,
 [HISTORICO_PROPRIEDADE].[CORTE] = @CORTE,
 [HISTORICO_PROPRIEDADE].[AMBIENTE] = @AMBIENTE,
 [HISTORICO_PROPRIEDADE].[DT_PLANTIO] = @DT_PLANTIO,
 [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ANT] = @DT_COLHEITA_ANT,
 [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ATU] = @DT_COLHEITA_ATU,
 [HISTORICO_PROPRIEDADE].[AREA_TOTAL] = @AREA_TOTAL,
 [HISTORICO_PROPRIEDADE].[AREA_LIBERADA] = @AREA_LIBERADA,
 [HISTORICO_PROPRIEDADE].[TONELADA] = @TONELADA,
 [HISTORICO_PROPRIEDADE].[RENDIMENTO_REAL] = @RENDIMENTO_REAL,
 [HISTORICO_PROPRIEDADE].[TCH] = @TCH,
 [HISTORICO_PROPRIEDADE].[IDADE] = @IDADE,
 [HISTORICO_PROPRIEDADE].[PERC_BROCA] = @PERC_BROCA,
 [HISTORICO_PROPRIEDADE].[PERC_PERDA] = @PERC_PERDA,
 [HISTORICO_PROPRIEDADE].[_trackLastWriteUser] = @_trackLastWriteUser,
 [HISTORICO_PROPRIEDADE].[_trackLastWriteTime] = GETDATE()
    WHERE ([HISTORICO_PROPRIEDADE].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [HISTORICO_PROPRIEDADE] (
        [HISTORICO_PROPRIEDADE].[ID_NEGOCIOS],
        [HISTORICO_PROPRIEDADE].[SAFRA],
        [HISTORICO_PROPRIEDADE].[COD_PROPRIEDADE],
        [HISTORICO_PROPRIEDADE].[DSC_PROPRIEDADE],
        [HISTORICO_PROPRIEDADE].[TALHAO],
        [HISTORICO_PROPRIEDADE].[RENDIMENTO_PLAN],
        [HISTORICO_PROPRIEDADE].[CORTE],
        [HISTORICO_PROPRIEDADE].[AMBIENTE],
        [HISTORICO_PROPRIEDADE].[DT_PLANTIO],
        [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ANT],
        [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ATU],
        [HISTORICO_PROPRIEDADE].[AREA_TOTAL],
        [HISTORICO_PROPRIEDADE].[AREA_LIBERADA],
        [HISTORICO_PROPRIEDADE].[TONELADA],
        [HISTORICO_PROPRIEDADE].[RENDIMENTO_REAL],
        [HISTORICO_PROPRIEDADE].[TCH],
        [HISTORICO_PROPRIEDADE].[IDADE],
        [HISTORICO_PROPRIEDADE].[PERC_BROCA],
        [HISTORICO_PROPRIEDADE].[PERC_PERDA],
        [HISTORICO_PROPRIEDADE].[_trackCreationUser],
        [HISTORICO_PROPRIEDADE].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @SAFRA,
        @COD_PROPRIEDADE,
        @DSC_PROPRIEDADE,
        @TALHAO,
        @RENDIMENTO_PLAN,
        @CORTE,
        @AMBIENTE,
        @DT_PLANTIO,
        @DT_COLHEITA_ANT,
        @DT_COLHEITA_ATU,
        @AREA_TOTAL,
        @AREA_LIBERADA,
        @TONELADA,
        @RENDIMENTO_REAL,
        @TCH,
        @IDADE,
        @PERC_BROCA,
        @PERC_PERDA,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [HISTORICO_PROPRIEDADE] 
        WHERE ([HISTORICO_PROPRIEDADE].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_TRATOS_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [HISTORICO_PROPRIEDADE_TRATOS] FROM [HISTORICO_PROPRIEDADE_TRATOS] 
    WHERE ([HISTORICO_PROPRIEDADE_TRATOS].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_TRATOS_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @SAFRA [int] = NULL,
 @COD_PROPRIEDADE [int] = NULL,
 @DSC_PROPRIEDADE [nvarchar] (256) = NULL,
 @TALHAO [int] = NULL,
 @CORTE [int] = NULL,
 @AMBIENTE [nvarchar] (256) = NULL,
 @AREA_TALHAO [float] = NULL,
 @AREA_TALHAO_DIS [float] = NULL,
 @AREA_TALHAO_MUDA [float] = NULL,
 @COLHEITA_ANT [date] = NULL,
 @COLHEITA_ATU [date] = NULL,
 @ATIVIDADE [int] = NULL,
 @DSC_ATIVIDADE [nvarchar] (256) = NULL,
 @NRO_RECOM [int] = NULL,
 @DATA_APLICACAO [date] = NULL,
 @AREA_APLICADA [float] = NULL,
 @TOTAL_TALHAO_DISP [int] = NULL,
 @AREA_TOT_TH_DISP [float] = NULL,
 @AREA_TOT_TH_MUDA [float] = NULL,
 @GRUPO_SUBGRUPO_AGR [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [HISTORICO_PROPRIEDADE_TRATOS] SET
 [HISTORICO_PROPRIEDADE_TRATOS].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [HISTORICO_PROPRIEDADE_TRATOS].[SAFRA] = @SAFRA,
 [HISTORICO_PROPRIEDADE_TRATOS].[COD_PROPRIEDADE] = @COD_PROPRIEDADE,
 [HISTORICO_PROPRIEDADE_TRATOS].[DSC_PROPRIEDADE] = @DSC_PROPRIEDADE,
 [HISTORICO_PROPRIEDADE_TRATOS].[TALHAO] = @TALHAO,
 [HISTORICO_PROPRIEDADE_TRATOS].[CORTE] = @CORTE,
 [HISTORICO_PROPRIEDADE_TRATOS].[AMBIENTE] = @AMBIENTE,
 [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO] = @AREA_TALHAO,
 [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_DIS] = @AREA_TALHAO_DIS,
 [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_MUDA] = @AREA_TALHAO_MUDA,
 [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ANT] = @COLHEITA_ANT,
 [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ATU] = @COLHEITA_ATU,
 [HISTORICO_PROPRIEDADE_TRATOS].[ATIVIDADE] = @ATIVIDADE,
 [HISTORICO_PROPRIEDADE_TRATOS].[DSC_ATIVIDADE] = @DSC_ATIVIDADE,
 [HISTORICO_PROPRIEDADE_TRATOS].[NRO_RECOM] = @NRO_RECOM,
 [HISTORICO_PROPRIEDADE_TRATOS].[DATA_APLICACAO] = @DATA_APLICACAO,
 [HISTORICO_PROPRIEDADE_TRATOS].[AREA_APLICADA] = @AREA_APLICADA,
 [HISTORICO_PROPRIEDADE_TRATOS].[TOTAL_TALHAO_DISP] = @TOTAL_TALHAO_DISP,
 [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_DISP] = @AREA_TOT_TH_DISP,
 [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_MUDA] = @AREA_TOT_TH_MUDA,
 [HISTORICO_PROPRIEDADE_TRATOS].[GRUPO_SUBGRUPO_AGR] = @GRUPO_SUBGRUPO_AGR,
 [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteUser] = @_trackLastWriteUser,
 [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteTime] = GETDATE()
    WHERE ([HISTORICO_PROPRIEDADE_TRATOS].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [HISTORICO_PROPRIEDADE_TRATOS] (
        [HISTORICO_PROPRIEDADE_TRATOS].[ID_NEGOCIOS],
        [HISTORICO_PROPRIEDADE_TRATOS].[SAFRA],
        [HISTORICO_PROPRIEDADE_TRATOS].[COD_PROPRIEDADE],
        [HISTORICO_PROPRIEDADE_TRATOS].[DSC_PROPRIEDADE],
        [HISTORICO_PROPRIEDADE_TRATOS].[TALHAO],
        [HISTORICO_PROPRIEDADE_TRATOS].[CORTE],
        [HISTORICO_PROPRIEDADE_TRATOS].[AMBIENTE],
        [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO],
        [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_DIS],
        [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_MUDA],
        [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ANT],
        [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ATU],
        [HISTORICO_PROPRIEDADE_TRATOS].[ATIVIDADE],
        [HISTORICO_PROPRIEDADE_TRATOS].[DSC_ATIVIDADE],
        [HISTORICO_PROPRIEDADE_TRATOS].[NRO_RECOM],
        [HISTORICO_PROPRIEDADE_TRATOS].[DATA_APLICACAO],
        [HISTORICO_PROPRIEDADE_TRATOS].[AREA_APLICADA],
        [HISTORICO_PROPRIEDADE_TRATOS].[TOTAL_TALHAO_DISP],
        [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_DISP],
        [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_MUDA],
        [HISTORICO_PROPRIEDADE_TRATOS].[GRUPO_SUBGRUPO_AGR],
        [HISTORICO_PROPRIEDADE_TRATOS].[_trackCreationUser],
        [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @SAFRA,
        @COD_PROPRIEDADE,
        @DSC_PROPRIEDADE,
        @TALHAO,
        @CORTE,
        @AMBIENTE,
        @AREA_TALHAO,
        @AREA_TALHAO_DIS,
        @AREA_TALHAO_MUDA,
        @COLHEITA_ANT,
        @COLHEITA_ATU,
        @ATIVIDADE,
        @DSC_ATIVIDADE,
        @NRO_RECOM,
        @DATA_APLICACAO,
        @AREA_APLICADA,
        @TOTAL_TALHAO_DISP,
        @AREA_TOT_TH_DISP,
        @AREA_TOT_TH_MUDA,
        @GRUPO_SUBGRUPO_AGR,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [HISTORICO_PROPRIEDADE_TRATOS] 
        WHERE ([HISTORICO_PROPRIEDADE_TRATOS].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdRole_Delete]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [IdRole_Users_IdUser_Roles] FROM [IdRole_Users_IdUser_Roles] 
    WHERE ([IdRole_Users_IdUser_Roles].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [IdRoleClaim] FROM [IdRoleClaim]
    INNER JOIN [IdRole] ON ([IdRoleClaim].[Role_Id] = [IdRole].[Id])
            LEFT OUTER JOIN [IdRoleClaim] [IdRoleClaim$1] ON ([IdRole].[Id] = [IdRoleClaim$1].[Role_Id]) 
    WHERE ([IdRole].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [IdRole] FROM [IdRole] 
    WHERE ([IdRole].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdRole_Save]
(
 @Id [bigint] = NULL,
 @Name [nvarchar] (70),
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [IdRole] SET
 [IdRole].[Name] = @Name,
 [IdRole].[_trackLastWriteUser] = @_trackLastWriteUser,
 [IdRole].[_trackLastWriteTime] = GETDATE()
    WHERE ([IdRole].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [IdRole] (
        [IdRole].[Name],
        [IdRole].[_trackCreationUser],
        [IdRole].[_trackLastWriteUser])
    VALUES (
        @Name,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Id = SCOPE_IDENTITY()  
    SELECT DISTINCT @Id AS 'Id' 
        FROM [IdRole] 
        WHERE ([IdRole].[Id] = @Id)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdRoleClaim_Delete]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [IdRoleClaim] FROM [IdRoleClaim] 
    WHERE ([IdRoleClaim].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdRoleClaim_Save]
(
 @Id [bigint] = NULL,
 @Type [nvarchar] (256),
 @Value [nvarchar] (256) = NULL,
 @ValueType [nvarchar] (256) = NULL,
 @Role_Id [bigint],
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [IdRoleClaim] SET
 [IdRoleClaim].[Type] = @Type,
 [IdRoleClaim].[Value] = @Value,
 [IdRoleClaim].[ValueType] = @ValueType,
 [IdRoleClaim].[Role_Id] = @Role_Id,
 [IdRoleClaim].[_trackLastWriteUser] = @_trackLastWriteUser,
 [IdRoleClaim].[_trackLastWriteTime] = GETDATE()
    WHERE ([IdRoleClaim].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [IdRoleClaim] (
        [IdRoleClaim].[Type],
        [IdRoleClaim].[Value],
        [IdRoleClaim].[ValueType],
        [IdRoleClaim].[Role_Id],
        [IdRoleClaim].[_trackCreationUser],
        [IdRoleClaim].[_trackLastWriteUser])
    VALUES (
        @Type,
        @Value,
        @ValueType,
        @Role_Id,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Id = SCOPE_IDENTITY()  
    SELECT DISTINCT @Id AS 'Id' 
        FROM [IdRoleClaim] 
        WHERE ([IdRoleClaim].[Id] = @Id)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_Delete]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [IdRole_Users_IdUser_Roles] FROM [IdRole_Users_IdUser_Roles] 
    WHERE ([IdRole_Users_IdUser_Roles].[Id2] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [IdUserClaim] FROM [IdUserClaim]
    INNER JOIN [IdUser] ON ([IdUserClaim].[User_Id] = [IdUser].[Id])
            LEFT OUTER JOIN [IdUserClaim] [IdUserClaim$1] ON ([IdUser].[Id] = [IdUserClaim$1].[User_Id]) 
    WHERE ([IdUser].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [IdUserLogin] FROM [IdUserLogin]
    INNER JOIN [IdUser] ON ([IdUserLogin].[User_Id] = [IdUser].[Id]) 
    WHERE ([IdUser].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [IdUser] FROM [IdUser] 
    WHERE ([IdUser].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_DeleteIdRoleUsers]
(
 @Id [bigint] = NULL,
 @Id2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [IdRole_Users_IdUser_Roles] FROM [IdRole_Users_IdUser_Roles] 
    WHERE (([IdRole_Users_IdUser_Roles].[Id2] = @Id2) AND ([IdRole_Users_IdUser_Roles].[Id] = @Id))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_Save]
(
 @Id [bigint] = NULL,
 @UserName [nvarchar] (70),
 @CreationDateUTC [datetime],
 @Email [nvarchar] (70) = NULL,
 @EmailConfirmed [bit],
 @PhoneNumber [nvarchar] (256) = NULL,
 @PhoneNumberConfirmed [bit],
 @Password [nvarchar] (256) = NULL,
 @LastPasswordChangeDate [datetime] = NULL,
 @AccessFailedCount [int],
 @AccessFailedWindowStart [datetime] = NULL,
 @LockoutEnabled [bit],
 @LockoutEndDateUtc [datetime] = NULL,
 @LastProfileUpdateDate [datetime] = NULL,
 @SecurityStamp [nvarchar] (256),
 @TwoFactorEnabled [bit],
 @oUsuario_pId [bigint] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [IdUser] SET
 [IdUser].[UserName] = @UserName,
 [IdUser].[CreationDateUTC] = @CreationDateUTC,
 [IdUser].[Email] = @Email,
 [IdUser].[EmailConfirmed] = @EmailConfirmed,
 [IdUser].[PhoneNumber] = @PhoneNumber,
 [IdUser].[PhoneNumberConfirmed] = @PhoneNumberConfirmed,
 [IdUser].[Password] = @Password,
 [IdUser].[LastPasswordChangeDate] = @LastPasswordChangeDate,
 [IdUser].[AccessFailedCount] = @AccessFailedCount,
 [IdUser].[AccessFailedWindowStart] = @AccessFailedWindowStart,
 [IdUser].[LockoutEnabled] = @LockoutEnabled,
 [IdUser].[LockoutEndDateUtc] = @LockoutEndDateUtc,
 [IdUser].[LastProfileUpdateDate] = @LastProfileUpdateDate,
 [IdUser].[SecurityStamp] = @SecurityStamp,
 [IdUser].[TwoFactorEnabled] = @TwoFactorEnabled,
 [IdUser].[oUsuario_pId] = @oUsuario_pId,
 [IdUser].[_trackLastWriteUser] = @_trackLastWriteUser,
 [IdUser].[_trackLastWriteTime] = GETDATE()
    WHERE ([IdUser].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [IdUser] (
        [IdUser].[UserName],
        [IdUser].[CreationDateUTC],
        [IdUser].[Email],
        [IdUser].[EmailConfirmed],
        [IdUser].[PhoneNumber],
        [IdUser].[PhoneNumberConfirmed],
        [IdUser].[Password],
        [IdUser].[LastPasswordChangeDate],
        [IdUser].[AccessFailedCount],
        [IdUser].[AccessFailedWindowStart],
        [IdUser].[LockoutEnabled],
        [IdUser].[LockoutEndDateUtc],
        [IdUser].[LastProfileUpdateDate],
        [IdUser].[SecurityStamp],
        [IdUser].[TwoFactorEnabled],
        [IdUser].[oUsuario_pId],
        [IdUser].[_trackCreationUser],
        [IdUser].[_trackLastWriteUser])
    VALUES (
        @UserName,
        @CreationDateUTC,
        @Email,
        @EmailConfirmed,
        @PhoneNumber,
        @PhoneNumberConfirmed,
        @Password,
        @LastPasswordChangeDate,
        @AccessFailedCount,
        @AccessFailedWindowStart,
        @LockoutEnabled,
        @LockoutEndDateUtc,
        @LastProfileUpdateDate,
        @SecurityStamp,
        @TwoFactorEnabled,
        @oUsuario_pId,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Id = SCOPE_IDENTITY()  
    SELECT DISTINCT @Id AS 'Id' 
        FROM [IdUser] 
        WHERE ([IdUser].[Id] = @Id)
END
IF(@oUsuario_pId IS NOT NULL)
BEGIN
    UPDATE [usuario] SET
     [usuario].[oIdUser_Id] = @Id
        WHERE ([usuario].[pId] = @oUsuario_pId)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_SaveIdRoleUsers]
(
 @Id [bigint],
 @Id2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
SELECT DISTINCT TOP 1 [IdRole_Users_IdUser_Roles].[Id] 
    FROM [IdRole_Users_IdUser_Roles] 
    WHERE (([IdRole_Users_IdUser_Roles].[Id2] = @Id2) AND ([IdRole_Users_IdUser_Roles].[Id] = @Id))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [IdRole_Users_IdUser_Roles] (
        [IdRole_Users_IdUser_Roles].[Id],
        [IdRole_Users_IdUser_Roles].[Id2])
    VALUES (
        @Id,
        @Id2)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserClaim_Delete]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [IdUserClaim] FROM [IdUserClaim] 
    WHERE ([IdUserClaim].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserClaim_Save]
(
 @Id [bigint] = NULL,
 @Type [nvarchar] (256),
 @Value [nvarchar] (256) = NULL,
 @ValueType [nvarchar] (256) = NULL,
 @Issuer [nvarchar] (256) = NULL,
 @OriginalIssuer [nvarchar] (256) = NULL,
 @User_Id [bigint],
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [IdUserClaim] SET
 [IdUserClaim].[Type] = @Type,
 [IdUserClaim].[Value] = @Value,
 [IdUserClaim].[ValueType] = @ValueType,
 [IdUserClaim].[Issuer] = @Issuer,
 [IdUserClaim].[OriginalIssuer] = @OriginalIssuer,
 [IdUserClaim].[User_Id] = @User_Id,
 [IdUserClaim].[_trackLastWriteUser] = @_trackLastWriteUser,
 [IdUserClaim].[_trackLastWriteTime] = GETDATE()
    WHERE ([IdUserClaim].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [IdUserClaim] (
        [IdUserClaim].[Type],
        [IdUserClaim].[Value],
        [IdUserClaim].[ValueType],
        [IdUserClaim].[Issuer],
        [IdUserClaim].[OriginalIssuer],
        [IdUserClaim].[User_Id],
        [IdUserClaim].[_trackCreationUser],
        [IdUserClaim].[_trackLastWriteUser])
    VALUES (
        @Type,
        @Value,
        @ValueType,
        @Issuer,
        @OriginalIssuer,
        @User_Id,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Id = SCOPE_IDENTITY()  
    SELECT DISTINCT @Id AS 'Id' 
        FROM [IdUserClaim] 
        WHERE ([IdUserClaim].[Id] = @Id)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserLogin_Delete]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [IdUserLogin] FROM [IdUserLogin] 
    WHERE ([IdUserLogin].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserLogin_Save]
(
 @Id [bigint] = NULL,
 @ProviderName [nvarchar] (256),
 @ProviderKey [nvarchar] (256),
 @ProviderDisplayName [nvarchar] (256),
 @User_Id [bigint],
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [IdUserLogin] SET
 [IdUserLogin].[ProviderName] = @ProviderName,
 [IdUserLogin].[ProviderKey] = @ProviderKey,
 [IdUserLogin].[ProviderDisplayName] = @ProviderDisplayName,
 [IdUserLogin].[User_Id] = @User_Id,
 [IdUserLogin].[_trackLastWriteUser] = @_trackLastWriteUser,
 [IdUserLogin].[_trackLastWriteTime] = GETDATE()
    WHERE ([IdUserLogin].[Id] = @Id)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [IdUserLogin] (
        [IdUserLogin].[ProviderName],
        [IdUserLogin].[ProviderKey],
        [IdUserLogin].[ProviderDisplayName],
        [IdUserLogin].[User_Id],
        [IdUserLogin].[_trackCreationUser],
        [IdUserLogin].[_trackLastWriteUser])
    VALUES (
        @ProviderName,
        @ProviderKey,
        @ProviderDisplayName,
        @User_Id,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Id = SCOPE_IDENTITY()  
    SELECT DISTINCT @Id AS 'Id' 
        FROM [IdUserLogin] 
        WHERE ([IdUserLogin].[Id] = @Id)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [INDICADORES_AGRICOLA] FROM [INDICADORES_AGRICOLA] 
    WHERE ([INDICADORES_AGRICOLA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [INDICADORES_AGRICOLA_EQUIP] FROM [INDICADORES_AGRICOLA_EQUIP] 
    WHERE ([INDICADORES_AGRICOLA_EQUIP].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_Save]
(
 @pId [bigint] = NULL,
 @FRENTETIPO [nvarchar] (256) = NULL,
 @FRENTETIPOAUX [nvarchar] (256) = NULL,
 @DS_FRENTE [nvarchar] (256) = NULL,
 @DS_TIPO [nvarchar] (256) = NULL,
 @DS_FRENTETIPO [nvarchar] (256) = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @FRENTE [int] = NULL,
 @DATA_FECHAMENTO [date] = NULL,
 @TIPO [nvarchar] (256) = NULL,
 @GRUPO [nvarchar] (256) = NULL,
 @DSC_EQUIPAMENTO [nvarchar] (256) = NULL,
 @NRO_EQUIPAMENTO [int] = NULL,
 @R_DISP_MECANICA_COLHEDORA [float] = NULL,
 @R_DISP_MECANICA_DEMAIS [float] = NULL,
 @R_DISP_MECANICA [float] = NULL,
 @R_CONSUMO_OLEO_DIESELLTH [float] = NULL,
 @R_CONSUMO_OLEO_DIESELKML [float] = NULL,
 @R_CONSUMO_OLEO_DIESELLTTON [float] = NULL,
 @R_CONSUMO_OLEO_HIDRAULICO [float] = NULL,
 @R_TEMPO_APROVEIT_COLHEDORA [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [INDICADORES_AGRICOLA_EQUIP] SET
 [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPO] = @FRENTETIPO,
 [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPOAUX] = @FRENTETIPOAUX,
 [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTE] = @DS_FRENTE,
 [INDICADORES_AGRICOLA_EQUIP].[DS_TIPO] = @DS_TIPO,
 [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTETIPO] = @DS_FRENTETIPO,
 [INDICADORES_AGRICOLA_EQUIP].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [INDICADORES_AGRICOLA_EQUIP].[FRENTE] = @FRENTE,
 [INDICADORES_AGRICOLA_EQUIP].[DATA_FECHAMENTO] = @DATA_FECHAMENTO,
 [INDICADORES_AGRICOLA_EQUIP].[TIPO] = @TIPO,
 [INDICADORES_AGRICOLA_EQUIP].[GRUPO] = @GRUPO,
 [INDICADORES_AGRICOLA_EQUIP].[DSC_EQUIPAMENTO] = @DSC_EQUIPAMENTO,
 [INDICADORES_AGRICOLA_EQUIP].[NRO_EQUIPAMENTO] = @NRO_EQUIPAMENTO,
 [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_COLHEDORA] = @R_DISP_MECANICA_COLHEDORA,
 [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_DEMAIS] = @R_DISP_MECANICA_DEMAIS,
 [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA] = @R_DISP_MECANICA,
 [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTH] = @R_CONSUMO_OLEO_DIESELLTH,
 [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELKML] = @R_CONSUMO_OLEO_DIESELKML,
 [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTTON] = @R_CONSUMO_OLEO_DIESELLTTON,
 [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_HIDRAULICO] = @R_CONSUMO_OLEO_HIDRAULICO,
 [INDICADORES_AGRICOLA_EQUIP].[R_TEMPO_APROVEIT_COLHEDORA] = @R_TEMPO_APROVEIT_COLHEDORA,
 [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteUser] = @_trackLastWriteUser,
 [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteTime] = GETDATE()
    WHERE ([INDICADORES_AGRICOLA_EQUIP].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [INDICADORES_AGRICOLA_EQUIP] (
        [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPO],
        [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPOAUX],
        [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTE],
        [INDICADORES_AGRICOLA_EQUIP].[DS_TIPO],
        [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTETIPO],
        [INDICADORES_AGRICOLA_EQUIP].[ID_NEGOCIOS],
        [INDICADORES_AGRICOLA_EQUIP].[FRENTE],
        [INDICADORES_AGRICOLA_EQUIP].[DATA_FECHAMENTO],
        [INDICADORES_AGRICOLA_EQUIP].[TIPO],
        [INDICADORES_AGRICOLA_EQUIP].[GRUPO],
        [INDICADORES_AGRICOLA_EQUIP].[DSC_EQUIPAMENTO],
        [INDICADORES_AGRICOLA_EQUIP].[NRO_EQUIPAMENTO],
        [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_COLHEDORA],
        [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_DEMAIS],
        [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA],
        [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTH],
        [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELKML],
        [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTTON],
        [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_HIDRAULICO],
        [INDICADORES_AGRICOLA_EQUIP].[R_TEMPO_APROVEIT_COLHEDORA],
        [INDICADORES_AGRICOLA_EQUIP].[_trackCreationUser],
        [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteUser])
    VALUES (
        @FRENTETIPO,
        @FRENTETIPOAUX,
        @DS_FRENTE,
        @DS_TIPO,
        @DS_FRENTETIPO,
        @ID_NEGOCIOS,
        @FRENTE,
        @DATA_FECHAMENTO,
        @TIPO,
        @GRUPO,
        @DSC_EQUIPAMENTO,
        @NRO_EQUIPAMENTO,
        @R_DISP_MECANICA_COLHEDORA,
        @R_DISP_MECANICA_DEMAIS,
        @R_DISP_MECANICA,
        @R_CONSUMO_OLEO_DIESELLTH,
        @R_CONSUMO_OLEO_DIESELKML,
        @R_CONSUMO_OLEO_DIESELLTTON,
        @R_CONSUMO_OLEO_HIDRAULICO,
        @R_TEMPO_APROVEIT_COLHEDORA,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [INDICADORES_AGRICOLA_EQUIP] 
        WHERE ([INDICADORES_AGRICOLA_EQUIP].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_Save]
(
 @pId [bigint] = NULL,
 @NOTACALC [int] = NULL,
 @FRENTETIPO [nvarchar] (256) = NULL,
 @FRENTETIPOAUX [nvarchar] (256) = NULL,
 @DS_FRENTE [nvarchar] (256) = NULL,
 @DS_TIPO [nvarchar] (256) = NULL,
 @DS_FRENTETIPO [nvarchar] (256) = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @INDICADOR [nvarchar] (256) = NULL,
 @FRENTE [int] = NULL,
 @PLANEJADO [float] = NULL,
 @REALIZADO [float] = NULL,
 @PERC [float] = NULL,
 @NOTA [nvarchar] (256) = NULL,
 @DATA_FECHAMENTO [date] = NULL,
 @UNIDADE_MEDIDA [nvarchar] (256) = NULL,
 @PERC_ABAIXO_META [float] = NULL,
 @PERC_ACIMA_META [float] = NULL,
 @TIPO [nvarchar] (256) = NULL,
 @GRUPO [nvarchar] (256) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [INDICADORES_AGRICOLA] SET
 [INDICADORES_AGRICOLA].[NOTACALC] = @NOTACALC,
 [INDICADORES_AGRICOLA].[FRENTETIPO] = @FRENTETIPO,
 [INDICADORES_AGRICOLA].[FRENTETIPOAUX] = @FRENTETIPOAUX,
 [INDICADORES_AGRICOLA].[DS_FRENTE] = @DS_FRENTE,
 [INDICADORES_AGRICOLA].[DS_TIPO] = @DS_TIPO,
 [INDICADORES_AGRICOLA].[DS_FRENTETIPO] = @DS_FRENTETIPO,
 [INDICADORES_AGRICOLA].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [INDICADORES_AGRICOLA].[INDICADOR] = @INDICADOR,
 [INDICADORES_AGRICOLA].[FRENTE] = @FRENTE,
 [INDICADORES_AGRICOLA].[PLANEJADO] = @PLANEJADO,
 [INDICADORES_AGRICOLA].[REALIZADO] = @REALIZADO,
 [INDICADORES_AGRICOLA].[PERC] = @PERC,
 [INDICADORES_AGRICOLA].[NOTA] = @NOTA,
 [INDICADORES_AGRICOLA].[DATA_FECHAMENTO] = @DATA_FECHAMENTO,
 [INDICADORES_AGRICOLA].[UNIDADE_MEDIDA] = @UNIDADE_MEDIDA,
 [INDICADORES_AGRICOLA].[PERC_ABAIXO_META] = @PERC_ABAIXO_META,
 [INDICADORES_AGRICOLA].[PERC_ACIMA_META] = @PERC_ACIMA_META,
 [INDICADORES_AGRICOLA].[TIPO] = @TIPO,
 [INDICADORES_AGRICOLA].[GRUPO] = @GRUPO,
 [INDICADORES_AGRICOLA].[_trackLastWriteUser] = @_trackLastWriteUser,
 [INDICADORES_AGRICOLA].[_trackLastWriteTime] = GETDATE()
    WHERE ([INDICADORES_AGRICOLA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [INDICADORES_AGRICOLA] (
        [INDICADORES_AGRICOLA].[NOTACALC],
        [INDICADORES_AGRICOLA].[FRENTETIPO],
        [INDICADORES_AGRICOLA].[FRENTETIPOAUX],
        [INDICADORES_AGRICOLA].[DS_FRENTE],
        [INDICADORES_AGRICOLA].[DS_TIPO],
        [INDICADORES_AGRICOLA].[DS_FRENTETIPO],
        [INDICADORES_AGRICOLA].[ID_NEGOCIOS],
        [INDICADORES_AGRICOLA].[INDICADOR],
        [INDICADORES_AGRICOLA].[FRENTE],
        [INDICADORES_AGRICOLA].[PLANEJADO],
        [INDICADORES_AGRICOLA].[REALIZADO],
        [INDICADORES_AGRICOLA].[PERC],
        [INDICADORES_AGRICOLA].[NOTA],
        [INDICADORES_AGRICOLA].[DATA_FECHAMENTO],
        [INDICADORES_AGRICOLA].[UNIDADE_MEDIDA],
        [INDICADORES_AGRICOLA].[PERC_ABAIXO_META],
        [INDICADORES_AGRICOLA].[PERC_ACIMA_META],
        [INDICADORES_AGRICOLA].[TIPO],
        [INDICADORES_AGRICOLA].[GRUPO],
        [INDICADORES_AGRICOLA].[_trackCreationUser],
        [INDICADORES_AGRICOLA].[_trackLastWriteUser])
    VALUES (
        @NOTACALC,
        @FRENTETIPO,
        @FRENTETIPOAUX,
        @DS_FRENTE,
        @DS_TIPO,
        @DS_FRENTETIPO,
        @ID_NEGOCIOS,
        @INDICADOR,
        @FRENTE,
        @PLANEJADO,
        @REALIZADO,
        @PERC,
        @NOTA,
        @DATA_FECHAMENTO,
        @UNIDADE_MEDIDA,
        @PERC_ABAIXO_META,
        @PERC_ACIMA_META,
        @TIPO,
        @GRUPO,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [INDICADORES_AGRICOLA] 
        WHERE ([INDICADORES_AGRICOLA].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [INDICADORES_AGRICOLA_TEMPOAPROV] FROM [INDICADORES_AGRICOLA_TEMPOAPROV] 
    WHERE ([INDICADORES_AGRICOLA_TEMPOAPROV].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_Save]
(
 @pId [bigint] = NULL,
 @DATA_FECHAMENTO [date],
 @PERC_TEMPO_APROV [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [INDICADORES_AGRICOLA_TEMPOAPROV] SET
 [INDICADORES_AGRICOLA_TEMPOAPROV].[DATA_FECHAMENTO] = @DATA_FECHAMENTO,
 [INDICADORES_AGRICOLA_TEMPOAPROV].[PERC_TEMPO_APROV] = @PERC_TEMPO_APROV,
 [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteUser] = @_trackLastWriteUser,
 [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteTime] = GETDATE()
    WHERE ([INDICADORES_AGRICOLA_TEMPOAPROV].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [INDICADORES_AGRICOLA_TEMPOAPROV] (
        [INDICADORES_AGRICOLA_TEMPOAPROV].[DATA_FECHAMENTO],
        [INDICADORES_AGRICOLA_TEMPOAPROV].[PERC_TEMPO_APROV],
        [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackCreationUser],
        [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteUser])
    VALUES (
        @DATA_FECHAMENTO,
        @PERC_TEMPO_APROV,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [INDICADORES_AGRICOLA_TEMPOAPROV] 
        WHERE ([INDICADORES_AGRICOLA_TEMPOAPROV].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[INFO_GERAIS_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [INFO_GERAIS] FROM [INFO_GERAIS] 
    WHERE ([INFO_GERAIS].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[INFO_GERAIS_Save]
(
 @pId [bigint] = NULL,
 @FRENTE [int] = NULL,
 @PROPRIEDADE [int] = NULL,
 @DSC_PROPRIEDADE [nvarchar] (256) = NULL,
 @COLHEDORA [int] = NULL,
 @TONELADA [float] = NULL,
 @QTD_VIAGENS [int] = NULL,
 @MEDIA_VIAGEM [float] = NULL,
 @RAIO_MEDIO [float] = NULL,
 @IMP_MINERAL [float] = NULL,
 @IMP_VEGETAL_PALHA [float] = NULL,
 @IMP_VEGETAL_PONTEIRA [float] = NULL,
 @IMP_MINERAL1 [float] = NULL,
 @IMP_MINERAL2 [float] = NULL,
 @IMP_VEGETAL_PALHA1 [float] = NULL,
 @IMP_VEGETAL_PALHA2 [float] = NULL,
 @IMP_VEGETAL_PONTEIRA1 [float] = NULL,
 @IMP_VEGETAL_PONTEIRA2 [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [INFO_GERAIS] SET
 [INFO_GERAIS].[FRENTE] = @FRENTE,
 [INFO_GERAIS].[PROPRIEDADE] = @PROPRIEDADE,
 [INFO_GERAIS].[DSC_PROPRIEDADE] = @DSC_PROPRIEDADE,
 [INFO_GERAIS].[COLHEDORA] = @COLHEDORA,
 [INFO_GERAIS].[TONELADA] = @TONELADA,
 [INFO_GERAIS].[QTD_VIAGENS] = @QTD_VIAGENS,
 [INFO_GERAIS].[MEDIA_VIAGEM] = @MEDIA_VIAGEM,
 [INFO_GERAIS].[RAIO_MEDIO] = @RAIO_MEDIO,
 [INFO_GERAIS].[IMP_MINERAL] = @IMP_MINERAL,
 [INFO_GERAIS].[IMP_VEGETAL_PALHA] = @IMP_VEGETAL_PALHA,
 [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA] = @IMP_VEGETAL_PONTEIRA,
 [INFO_GERAIS].[IMP_MINERAL1] = @IMP_MINERAL1,
 [INFO_GERAIS].[IMP_MINERAL2] = @IMP_MINERAL2,
 [INFO_GERAIS].[IMP_VEGETAL_PALHA1] = @IMP_VEGETAL_PALHA1,
 [INFO_GERAIS].[IMP_VEGETAL_PALHA2] = @IMP_VEGETAL_PALHA2,
 [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA1] = @IMP_VEGETAL_PONTEIRA1,
 [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA2] = @IMP_VEGETAL_PONTEIRA2,
 [INFO_GERAIS].[_trackLastWriteUser] = @_trackLastWriteUser,
 [INFO_GERAIS].[_trackLastWriteTime] = GETDATE()
    WHERE ([INFO_GERAIS].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [INFO_GERAIS] (
        [INFO_GERAIS].[FRENTE],
        [INFO_GERAIS].[PROPRIEDADE],
        [INFO_GERAIS].[DSC_PROPRIEDADE],
        [INFO_GERAIS].[COLHEDORA],
        [INFO_GERAIS].[TONELADA],
        [INFO_GERAIS].[QTD_VIAGENS],
        [INFO_GERAIS].[MEDIA_VIAGEM],
        [INFO_GERAIS].[RAIO_MEDIO],
        [INFO_GERAIS].[IMP_MINERAL],
        [INFO_GERAIS].[IMP_VEGETAL_PALHA],
        [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA],
        [INFO_GERAIS].[IMP_MINERAL1],
        [INFO_GERAIS].[IMP_MINERAL2],
        [INFO_GERAIS].[IMP_VEGETAL_PALHA1],
        [INFO_GERAIS].[IMP_VEGETAL_PALHA2],
        [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA1],
        [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA2],
        [INFO_GERAIS].[_trackCreationUser],
        [INFO_GERAIS].[_trackLastWriteUser])
    VALUES (
        @FRENTE,
        @PROPRIEDADE,
        @DSC_PROPRIEDADE,
        @COLHEDORA,
        @TONELADA,
        @QTD_VIAGENS,
        @MEDIA_VIAGEM,
        @RAIO_MEDIO,
        @IMP_MINERAL,
        @IMP_VEGETAL_PALHA,
        @IMP_VEGETAL_PONTEIRA,
        @IMP_MINERAL1,
        @IMP_MINERAL2,
        @IMP_VEGETAL_PALHA1,
        @IMP_VEGETAL_PALHA2,
        @IMP_VEGETAL_PONTEIRA1,
        @IMP_VEGETAL_PONTEIRA2,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [INFO_GERAIS] 
        WHERE ([INFO_GERAIS].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[loginregistro_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [loginregistro] FROM [loginregistro] 
    WHERE ([loginregistro].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[loginregistro_Save]
(
 @pId [bigint] = NULL,
 @pDataHora [datetime] = NULL,
 @pSenha [nvarchar] (256) = NULL,
 @pObsLog [nvarchar] (256) = NULL,
 @pCodigoUsuario [int] = NULL,
 @pLoginUsuario [nvarchar] (256) = NULL,
 @pFlgAdminUsuario [nvarchar] (1) = NULL,
 @pCodigoFilial [int] = NULL,
 @pCodigoEmpresa [int] = NULL,
 @pLoginValidado [bit] = NULL,
 @sUsuarioStatus [int] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [loginregistro] SET
 [loginregistro].[pDataHora] = @pDataHora,
 [loginregistro].[pSenha] = @pSenha,
 [loginregistro].[pObsLog] = @pObsLog,
 [loginregistro].[pCodigoUsuario] = @pCodigoUsuario,
 [loginregistro].[pLoginUsuario] = @pLoginUsuario,
 [loginregistro].[pFlgAdminUsuario] = @pFlgAdminUsuario,
 [loginregistro].[pCodigoFilial] = @pCodigoFilial,
 [loginregistro].[pCodigoEmpresa] = @pCodigoEmpresa,
 [loginregistro].[pLoginValidado] = @pLoginValidado,
 [loginregistro].[sUsuarioStatus] = @sUsuarioStatus,
 [loginregistro].[_trackLastWriteUser] = @_trackLastWriteUser,
 [loginregistro].[_trackLastWriteTime] = GETDATE()
    WHERE ([loginregistro].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [loginregistro] (
        [loginregistro].[pDataHora],
        [loginregistro].[pSenha],
        [loginregistro].[pObsLog],
        [loginregistro].[pCodigoUsuario],
        [loginregistro].[pLoginUsuario],
        [loginregistro].[pFlgAdminUsuario],
        [loginregistro].[pCodigoFilial],
        [loginregistro].[pCodigoEmpresa],
        [loginregistro].[pLoginValidado],
        [loginregistro].[sUsuarioStatus],
        [loginregistro].[_trackCreationUser],
        [loginregistro].[_trackLastWriteUser])
    VALUES (
        @pDataHora,
        @pSenha,
        @pObsLog,
        @pCodigoUsuario,
        @pLoginUsuario,
        @pFlgAdminUsuario,
        @pCodigoFilial,
        @pCodigoEmpresa,
        @pLoginValidado,
        @sUsuarioStatus,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [loginregistro] 
        WHERE ([loginregistro].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[MAPA_PLANCOLHEITA_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [MAPA_PLANCOLHEITA] FROM [MAPA_PLANCOLHEITA] 
    WHERE ([MAPA_PLANCOLHEITA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[MAPA_PLANCOLHEITA_Save]
(
 @pId [bigint] = NULL,
 @PROP_CODIGO [int] = NULL,
 @DS_NOME_PROPRIEDADE [nvarchar] (256) = NULL,
 @FRENTE_COLHEITA [int] = NULL,
 @MES [date] = NULL,
 @SEMANA [int] = NULL,
 @MES_SEMANA [nvarchar] (256) = NULL,
 @SEMANA_PERIODO [nvarchar] (256) = NULL,
 @REFORMA_PREV [nvarchar] (256) = NULL,
 @AREA_PREV [float] = NULL,
 @TONELADA_PREV [float] = NULL,
 @AREA_PREV_REFORMA [float] = NULL,
 @TONELADA_PREV_REFORMA [float] = NULL,
 @AREA_PREV_TOTAL [float] = NULL,
 @AREA_PREV_REFORMA_TOTAL [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [MAPA_PLANCOLHEITA] SET
 [MAPA_PLANCOLHEITA].[PROP_CODIGO] = @PROP_CODIGO,
 [MAPA_PLANCOLHEITA].[DS_NOME_PROPRIEDADE] = @DS_NOME_PROPRIEDADE,
 [MAPA_PLANCOLHEITA].[FRENTE_COLHEITA] = @FRENTE_COLHEITA,
 [MAPA_PLANCOLHEITA].[MES] = @MES,
 [MAPA_PLANCOLHEITA].[SEMANA] = @SEMANA,
 [MAPA_PLANCOLHEITA].[MES_SEMANA] = @MES_SEMANA,
 [MAPA_PLANCOLHEITA].[SEMANA_PERIODO] = @SEMANA_PERIODO,
 [MAPA_PLANCOLHEITA].[REFORMA_PREV] = @REFORMA_PREV,
 [MAPA_PLANCOLHEITA].[AREA_PREV] = @AREA_PREV,
 [MAPA_PLANCOLHEITA].[TONELADA_PREV] = @TONELADA_PREV,
 [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA] = @AREA_PREV_REFORMA,
 [MAPA_PLANCOLHEITA].[TONELADA_PREV_REFORMA] = @TONELADA_PREV_REFORMA,
 [MAPA_PLANCOLHEITA].[AREA_PREV_TOTAL] = @AREA_PREV_TOTAL,
 [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA_TOTAL] = @AREA_PREV_REFORMA_TOTAL,
 [MAPA_PLANCOLHEITA].[_trackLastWriteUser] = @_trackLastWriteUser,
 [MAPA_PLANCOLHEITA].[_trackLastWriteTime] = GETDATE()
    WHERE ([MAPA_PLANCOLHEITA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [MAPA_PLANCOLHEITA] (
        [MAPA_PLANCOLHEITA].[PROP_CODIGO],
        [MAPA_PLANCOLHEITA].[DS_NOME_PROPRIEDADE],
        [MAPA_PLANCOLHEITA].[FRENTE_COLHEITA],
        [MAPA_PLANCOLHEITA].[MES],
        [MAPA_PLANCOLHEITA].[SEMANA],
        [MAPA_PLANCOLHEITA].[MES_SEMANA],
        [MAPA_PLANCOLHEITA].[SEMANA_PERIODO],
        [MAPA_PLANCOLHEITA].[REFORMA_PREV],
        [MAPA_PLANCOLHEITA].[AREA_PREV],
        [MAPA_PLANCOLHEITA].[TONELADA_PREV],
        [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA],
        [MAPA_PLANCOLHEITA].[TONELADA_PREV_REFORMA],
        [MAPA_PLANCOLHEITA].[AREA_PREV_TOTAL],
        [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA_TOTAL],
        [MAPA_PLANCOLHEITA].[_trackCreationUser],
        [MAPA_PLANCOLHEITA].[_trackLastWriteUser])
    VALUES (
        @PROP_CODIGO,
        @DS_NOME_PROPRIEDADE,
        @FRENTE_COLHEITA,
        @MES,
        @SEMANA,
        @MES_SEMANA,
        @SEMANA_PERIODO,
        @REFORMA_PREV,
        @AREA_PREV,
        @TONELADA_PREV,
        @AREA_PREV_REFORMA,
        @TONELADA_PREV_REFORMA,
        @AREA_PREV_TOTAL,
        @AREA_PREV_REFORMA_TOTAL,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [MAPA_PLANCOLHEITA] 
        WHERE ([MAPA_PLANCOLHEITA].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[menu_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [menu] FROM [menu] 
    WHERE ([menu].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[menu_Save]
(
 @pId [bigint] = NULL,
 @pDescricao [nvarchar] (256) = NULL,
 @pNomeToolStrip [nvarchar] (256) = NULL,
 @oSistema_pId [bigint] = NULL,
 @pNivelPosicao [int] = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [menu] SET
 [menu].[pDescricao] = @pDescricao,
 [menu].[pNomeToolStrip] = @pNomeToolStrip,
 [menu].[oSistema_pId] = @oSistema_pId,
 [menu].[pNivelPosicao] = @pNivelPosicao,
 [menu].[xDataHoraReg] = @xDataHoraReg,
 [menu].[xLoginReg] = @xLoginReg,
 [menu].[_trackLastWriteUser] = @_trackLastWriteUser,
 [menu].[_trackLastWriteTime] = GETDATE()
    WHERE ([menu].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [menu] (
        [menu].[pDescricao],
        [menu].[pNomeToolStrip],
        [menu].[oSistema_pId],
        [menu].[pNivelPosicao],
        [menu].[xDataHoraReg],
        [menu].[xLoginReg],
        [menu].[_trackCreationUser],
        [menu].[_trackLastWriteUser])
    VALUES (
        @pDescricao,
        @pNomeToolStrip,
        @oSistema_pId,
        @pNivelPosicao,
        @xDataHoraReg,
        @xLoginReg,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [menu] 
        WHERE ([menu].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [menupermissao] FROM [menupermissao] 
    WHERE ([menupermissao].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_Save]
(
 @pId [bigint] = NULL,
 @oUsuario_pId [bigint] = NULL,
 @oSistema_pId [bigint] = NULL,
 @pNomeToolStripPerm [nvarchar] (256),
 @pFlgPermissao [nvarchar] (1) = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [menupermissao] SET
 [menupermissao].[oUsuario_pId] = @oUsuario_pId,
 [menupermissao].[oSistema_pId] = @oSistema_pId,
 [menupermissao].[pNomeToolStripPerm] = @pNomeToolStripPerm,
 [menupermissao].[pFlgPermissao] = @pFlgPermissao,
 [menupermissao].[xDataHoraReg] = @xDataHoraReg,
 [menupermissao].[xLoginReg] = @xLoginReg,
 [menupermissao].[_trackLastWriteUser] = @_trackLastWriteUser,
 [menupermissao].[_trackLastWriteTime] = GETDATE()
    WHERE ([menupermissao].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [menupermissao] (
        [menupermissao].[oUsuario_pId],
        [menupermissao].[oSistema_pId],
        [menupermissao].[pNomeToolStripPerm],
        [menupermissao].[pFlgPermissao],
        [menupermissao].[xDataHoraReg],
        [menupermissao].[xLoginReg],
        [menupermissao].[_trackCreationUser],
        [menupermissao].[_trackLastWriteUser])
    VALUES (
        @oUsuario_pId,
        @oSistema_pId,
        @pNomeToolStripPerm,
        @pFlgPermissao,
        @xDataHoraReg,
        @xLoginReg,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [menupermissao] 
        WHERE ([menupermissao].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[MOAGEM_CANA_HORA_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [MOAGEM_CANA_HORA] FROM [MOAGEM_CANA_HORA] 
    WHERE ([MOAGEM_CANA_HORA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[MOAGEM_CANA_HORA_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @DIA [date] = NULL,
 @HORA [nvarchar] (256) = NULL,
 @VIAGEM [int] = NULL,
 @TONELADAS [float] = NULL,
 @METAFRENTE [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [MOAGEM_CANA_HORA] SET
 [MOAGEM_CANA_HORA].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [MOAGEM_CANA_HORA].[DIA] = @DIA,
 [MOAGEM_CANA_HORA].[HORA] = @HORA,
 [MOAGEM_CANA_HORA].[VIAGEM] = @VIAGEM,
 [MOAGEM_CANA_HORA].[TONELADAS] = @TONELADAS,
 [MOAGEM_CANA_HORA].[METAFRENTE] = @METAFRENTE,
 [MOAGEM_CANA_HORA].[_trackLastWriteUser] = @_trackLastWriteUser,
 [MOAGEM_CANA_HORA].[_trackLastWriteTime] = GETDATE()
    WHERE ([MOAGEM_CANA_HORA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [MOAGEM_CANA_HORA] (
        [MOAGEM_CANA_HORA].[ID_NEGOCIOS],
        [MOAGEM_CANA_HORA].[DIA],
        [MOAGEM_CANA_HORA].[HORA],
        [MOAGEM_CANA_HORA].[VIAGEM],
        [MOAGEM_CANA_HORA].[TONELADAS],
        [MOAGEM_CANA_HORA].[METAFRENTE],
        [MOAGEM_CANA_HORA].[_trackCreationUser],
        [MOAGEM_CANA_HORA].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @DIA,
        @HORA,
        @VIAGEM,
        @TONELADAS,
        @METAFRENTE,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [MOAGEM_CANA_HORA] 
        WHERE ([MOAGEM_CANA_HORA].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[pais_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
UPDATE [uf] SET
 [uf].[oPais_pId] = NULL
    WHERE ([uf].[oPais_pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
DELETE [pais] FROM [pais] 
    WHERE ([pais].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[pais_Save]
(
 @pId [bigint] = NULL,
 @pCodigo [int],
 @pNome [nvarchar] (256) = NULL,
 @pSigla [nvarchar] (3) = NULL,
 @pCodigoIbge [int] = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [pais] SET
 [pais].[pCodigo] = @pCodigo,
 [pais].[pNome] = @pNome,
 [pais].[pSigla] = @pSigla,
 [pais].[pCodigoIbge] = @pCodigoIbge,
 [pais].[xDataHoraReg] = @xDataHoraReg,
 [pais].[xLoginReg] = @xLoginReg,
 [pais].[_trackLastWriteUser] = @_trackLastWriteUser,
 [pais].[_trackLastWriteTime] = GETDATE()
    WHERE ([pais].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [pais] (
        [pais].[pCodigo],
        [pais].[pNome],
        [pais].[pSigla],
        [pais].[pCodigoIbge],
        [pais].[xDataHoraReg],
        [pais].[xLoginReg],
        [pais].[_trackCreationUser],
        [pais].[_trackLastWriteUser])
    VALUES (
        @pCodigo,
        @pNome,
        @pSigla,
        @pCodigoIbge,
        @xDataHoraReg,
        @xLoginReg,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [pais] 
        WHERE ([pais].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[PROPRIEDADES_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [PROPRIEDADES] FROM [PROPRIEDADES] 
    WHERE ([PROPRIEDADES].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[PROPRIEDADES_Save]
(
 @pId [bigint] = NULL,
 @SAFRA [int] = NULL,
 @COD_PROPRIEDADE [int] = NULL,
 @DSC_PROPRIEDADE [nvarchar] (256) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [PROPRIEDADES] SET
 [PROPRIEDADES].[SAFRA] = @SAFRA,
 [PROPRIEDADES].[COD_PROPRIEDADE] = @COD_PROPRIEDADE,
 [PROPRIEDADES].[DSC_PROPRIEDADE] = @DSC_PROPRIEDADE,
 [PROPRIEDADES].[_trackLastWriteUser] = @_trackLastWriteUser,
 [PROPRIEDADES].[_trackLastWriteTime] = GETDATE()
    WHERE ([PROPRIEDADES].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [PROPRIEDADES] (
        [PROPRIEDADES].[SAFRA],
        [PROPRIEDADES].[COD_PROPRIEDADE],
        [PROPRIEDADES].[DSC_PROPRIEDADE],
        [PROPRIEDADES].[_trackCreationUser],
        [PROPRIEDADES].[_trackLastWriteUser])
    VALUES (
        @SAFRA,
        @COD_PROPRIEDADE,
        @DSC_PROPRIEDADE,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [PROPRIEDADES] 
        WHERE ([PROPRIEDADES].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_ACUMULADA_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [RES_MENSAL_ACUMULADA] FROM [RES_MENSAL_ACUMULADA] 
    WHERE ([RES_MENSAL_ACUMULADA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_ACUMULADA_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @NRO_ANO_SAFRA [int] = NULL,
 @MES [nvarchar] (256) = NULL,
 @DIA [date] = NULL,
 @TONELADA_PLAN [float] = NULL,
 @TONELADA_PLAN_AC [float] = NULL,
 @TONELADA_REAL [float] = NULL,
 @TONELADA_REAL_AC [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [RES_MENSAL_ACUMULADA] SET
 [RES_MENSAL_ACUMULADA].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [RES_MENSAL_ACUMULADA].[NRO_ANO_SAFRA] = @NRO_ANO_SAFRA,
 [RES_MENSAL_ACUMULADA].[MES] = @MES,
 [RES_MENSAL_ACUMULADA].[DIA] = @DIA,
 [RES_MENSAL_ACUMULADA].[TONELADA_PLAN] = @TONELADA_PLAN,
 [RES_MENSAL_ACUMULADA].[TONELADA_PLAN_AC] = @TONELADA_PLAN_AC,
 [RES_MENSAL_ACUMULADA].[TONELADA_REAL] = @TONELADA_REAL,
 [RES_MENSAL_ACUMULADA].[TONELADA_REAL_AC] = @TONELADA_REAL_AC,
 [RES_MENSAL_ACUMULADA].[_trackLastWriteUser] = @_trackLastWriteUser,
 [RES_MENSAL_ACUMULADA].[_trackLastWriteTime] = GETDATE()
    WHERE ([RES_MENSAL_ACUMULADA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [RES_MENSAL_ACUMULADA] (
        [RES_MENSAL_ACUMULADA].[ID_NEGOCIOS],
        [RES_MENSAL_ACUMULADA].[NRO_ANO_SAFRA],
        [RES_MENSAL_ACUMULADA].[MES],
        [RES_MENSAL_ACUMULADA].[DIA],
        [RES_MENSAL_ACUMULADA].[TONELADA_PLAN],
        [RES_MENSAL_ACUMULADA].[TONELADA_PLAN_AC],
        [RES_MENSAL_ACUMULADA].[TONELADA_REAL],
        [RES_MENSAL_ACUMULADA].[TONELADA_REAL_AC],
        [RES_MENSAL_ACUMULADA].[_trackCreationUser],
        [RES_MENSAL_ACUMULADA].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @NRO_ANO_SAFRA,
        @MES,
        @DIA,
        @TONELADA_PLAN,
        @TONELADA_PLAN_AC,
        @TONELADA_REAL,
        @TONELADA_REAL_AC,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [RES_MENSAL_ACUMULADA] 
        WHERE ([RES_MENSAL_ACUMULADA].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_DIARIA_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [RES_MENSAL_DIARIA] FROM [RES_MENSAL_DIARIA] 
    WHERE ([RES_MENSAL_DIARIA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_DIARIA_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @NRO_ANO_SAFRA [int] = NULL,
 @MES [nvarchar] (256) = NULL,
 @DIA [date] = NULL,
 @TONELADA_PLAN [float] = NULL,
 @TONELADA_REAL [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [RES_MENSAL_DIARIA] SET
 [RES_MENSAL_DIARIA].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [RES_MENSAL_DIARIA].[NRO_ANO_SAFRA] = @NRO_ANO_SAFRA,
 [RES_MENSAL_DIARIA].[MES] = @MES,
 [RES_MENSAL_DIARIA].[DIA] = @DIA,
 [RES_MENSAL_DIARIA].[TONELADA_PLAN] = @TONELADA_PLAN,
 [RES_MENSAL_DIARIA].[TONELADA_REAL] = @TONELADA_REAL,
 [RES_MENSAL_DIARIA].[_trackLastWriteUser] = @_trackLastWriteUser,
 [RES_MENSAL_DIARIA].[_trackLastWriteTime] = GETDATE()
    WHERE ([RES_MENSAL_DIARIA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [RES_MENSAL_DIARIA] (
        [RES_MENSAL_DIARIA].[ID_NEGOCIOS],
        [RES_MENSAL_DIARIA].[NRO_ANO_SAFRA],
        [RES_MENSAL_DIARIA].[MES],
        [RES_MENSAL_DIARIA].[DIA],
        [RES_MENSAL_DIARIA].[TONELADA_PLAN],
        [RES_MENSAL_DIARIA].[TONELADA_REAL],
        [RES_MENSAL_DIARIA].[_trackCreationUser],
        [RES_MENSAL_DIARIA].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @NRO_ANO_SAFRA,
        @MES,
        @DIA,
        @TONELADA_PLAN,
        @TONELADA_REAL,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [RES_MENSAL_DIARIA] 
        WHERE ([RES_MENSAL_DIARIA].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_GRID_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [RES_MENSAL_GRID] FROM [RES_MENSAL_GRID] 
    WHERE ([RES_MENSAL_GRID].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_GRID_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @NRO_ANO_SAFRA [int] = NULL,
 @MES [nvarchar] (256) = NULL,
 @MES_N [int] = NULL,
 @TIPO [nvarchar] (256) = NULL,
 @TONELADA [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [RES_MENSAL_GRID] SET
 [RES_MENSAL_GRID].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [RES_MENSAL_GRID].[NRO_ANO_SAFRA] = @NRO_ANO_SAFRA,
 [RES_MENSAL_GRID].[MES] = @MES,
 [RES_MENSAL_GRID].[MES_N] = @MES_N,
 [RES_MENSAL_GRID].[TIPO] = @TIPO,
 [RES_MENSAL_GRID].[TONELADA] = @TONELADA,
 [RES_MENSAL_GRID].[_trackLastWriteUser] = @_trackLastWriteUser,
 [RES_MENSAL_GRID].[_trackLastWriteTime] = GETDATE()
    WHERE ([RES_MENSAL_GRID].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [RES_MENSAL_GRID] (
        [RES_MENSAL_GRID].[ID_NEGOCIOS],
        [RES_MENSAL_GRID].[NRO_ANO_SAFRA],
        [RES_MENSAL_GRID].[MES],
        [RES_MENSAL_GRID].[MES_N],
        [RES_MENSAL_GRID].[TIPO],
        [RES_MENSAL_GRID].[TONELADA],
        [RES_MENSAL_GRID].[_trackCreationUser],
        [RES_MENSAL_GRID].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @NRO_ANO_SAFRA,
        @MES,
        @MES_N,
        @TIPO,
        @TONELADA,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [RES_MENSAL_GRID] 
        WHERE ([RES_MENSAL_GRID].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_SAFRA_ACUMULADA_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [RES_MENSAL_SAFRA_ACUMULADA] FROM [RES_MENSAL_SAFRA_ACUMULADA] 
    WHERE ([RES_MENSAL_SAFRA_ACUMULADA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_SAFRA_ACUMULADA_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @NRO_ANO_SAFRA [int] = NULL,
 @MES [nvarchar] (256) = NULL,
 @DIA [date] = NULL,
 @TONELADA_PLAN [float] = NULL,
 @TONELADA_PLAN_AC [float] = NULL,
 @TONELADA_REAL [float] = NULL,
 @TONELADA_REAL_AC [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [RES_MENSAL_SAFRA_ACUMULADA] SET
 [RES_MENSAL_SAFRA_ACUMULADA].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [RES_MENSAL_SAFRA_ACUMULADA].[NRO_ANO_SAFRA] = @NRO_ANO_SAFRA,
 [RES_MENSAL_SAFRA_ACUMULADA].[MES] = @MES,
 [RES_MENSAL_SAFRA_ACUMULADA].[DIA] = @DIA,
 [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN] = @TONELADA_PLAN,
 [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN_AC] = @TONELADA_PLAN_AC,
 [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL] = @TONELADA_REAL,
 [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL_AC] = @TONELADA_REAL_AC,
 [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteUser] = @_trackLastWriteUser,
 [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteTime] = GETDATE()
    WHERE ([RES_MENSAL_SAFRA_ACUMULADA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [RES_MENSAL_SAFRA_ACUMULADA] (
        [RES_MENSAL_SAFRA_ACUMULADA].[ID_NEGOCIOS],
        [RES_MENSAL_SAFRA_ACUMULADA].[NRO_ANO_SAFRA],
        [RES_MENSAL_SAFRA_ACUMULADA].[MES],
        [RES_MENSAL_SAFRA_ACUMULADA].[DIA],
        [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN],
        [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN_AC],
        [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL],
        [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL_AC],
        [RES_MENSAL_SAFRA_ACUMULADA].[_trackCreationUser],
        [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @NRO_ANO_SAFRA,
        @MES,
        @DIA,
        @TONELADA_PLAN,
        @TONELADA_PLAN_AC,
        @TONELADA_REAL,
        @TONELADA_REAL_AC,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [RES_MENSAL_SAFRA_ACUMULADA] 
        WHERE ([RES_MENSAL_SAFRA_ACUMULADA].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_SAFRA_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [RES_MENSAL_SAFRA] FROM [RES_MENSAL_SAFRA] 
    WHERE ([RES_MENSAL_SAFRA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_SAFRA_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @NRO_ANO_SAFRA [int] = NULL,
 @MES [nvarchar] (256) = NULL,
 @DIA [date] = NULL,
 @TONELADA_PLAN [float] = NULL,
 @TONELADA_REAL [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [RES_MENSAL_SAFRA] SET
 [RES_MENSAL_SAFRA].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [RES_MENSAL_SAFRA].[NRO_ANO_SAFRA] = @NRO_ANO_SAFRA,
 [RES_MENSAL_SAFRA].[MES] = @MES,
 [RES_MENSAL_SAFRA].[DIA] = @DIA,
 [RES_MENSAL_SAFRA].[TONELADA_PLAN] = @TONELADA_PLAN,
 [RES_MENSAL_SAFRA].[TONELADA_REAL] = @TONELADA_REAL,
 [RES_MENSAL_SAFRA].[_trackLastWriteUser] = @_trackLastWriteUser,
 [RES_MENSAL_SAFRA].[_trackLastWriteTime] = GETDATE()
    WHERE ([RES_MENSAL_SAFRA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [RES_MENSAL_SAFRA] (
        [RES_MENSAL_SAFRA].[ID_NEGOCIOS],
        [RES_MENSAL_SAFRA].[NRO_ANO_SAFRA],
        [RES_MENSAL_SAFRA].[MES],
        [RES_MENSAL_SAFRA].[DIA],
        [RES_MENSAL_SAFRA].[TONELADA_PLAN],
        [RES_MENSAL_SAFRA].[TONELADA_REAL],
        [RES_MENSAL_SAFRA].[_trackCreationUser],
        [RES_MENSAL_SAFRA].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @NRO_ANO_SAFRA,
        @MES,
        @DIA,
        @TONELADA_PLAN,
        @TONELADA_REAL,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [RES_MENSAL_SAFRA] 
        WHERE ([RES_MENSAL_SAFRA].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[SAFRA_ANO_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [SAFRA_ANO] FROM [SAFRA_ANO] 
    WHERE ([SAFRA_ANO].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[SAFRA_ANO_Save]
(
 @pId [bigint] = NULL,
 @SAFRA [int] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [SAFRA_ANO] SET
 [SAFRA_ANO].[SAFRA] = @SAFRA,
 [SAFRA_ANO].[_trackLastWriteUser] = @_trackLastWriteUser,
 [SAFRA_ANO].[_trackLastWriteTime] = GETDATE()
    WHERE ([SAFRA_ANO].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [SAFRA_ANO] (
        [SAFRA_ANO].[SAFRA],
        [SAFRA_ANO].[_trackCreationUser],
        [SAFRA_ANO].[_trackLastWriteUser])
    VALUES (
        @SAFRA,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [SAFRA_ANO] 
        WHERE ([SAFRA_ANO].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[SEQUENCIA_COLHEITA_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [SEQUENCIA_COLHEITA] FROM [SEQUENCIA_COLHEITA] 
    WHERE ([SEQUENCIA_COLHEITA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[SEQUENCIA_COLHEITA_Save]
(
 @pId [bigint] = NULL,
 @FRENTE_COLHEITA [int] = NULL,
 @PROP_CODIGO [int] = NULL,
 @DS_NOME_PROPRIEDADE [nvarchar] (256) = NULL,
 @COORD_LAT [float] = NULL,
 @COORD_LONG [float] = NULL,
 @ORDEM [int] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [SEQUENCIA_COLHEITA] SET
 [SEQUENCIA_COLHEITA].[FRENTE_COLHEITA] = @FRENTE_COLHEITA,
 [SEQUENCIA_COLHEITA].[PROP_CODIGO] = @PROP_CODIGO,
 [SEQUENCIA_COLHEITA].[DS_NOME_PROPRIEDADE] = @DS_NOME_PROPRIEDADE,
 [SEQUENCIA_COLHEITA].[COORD_LAT] = @COORD_LAT,
 [SEQUENCIA_COLHEITA].[COORD_LONG] = @COORD_LONG,
 [SEQUENCIA_COLHEITA].[ORDEM] = @ORDEM,
 [SEQUENCIA_COLHEITA].[_trackLastWriteUser] = @_trackLastWriteUser,
 [SEQUENCIA_COLHEITA].[_trackLastWriteTime] = GETDATE()
    WHERE ([SEQUENCIA_COLHEITA].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [SEQUENCIA_COLHEITA] (
        [SEQUENCIA_COLHEITA].[FRENTE_COLHEITA],
        [SEQUENCIA_COLHEITA].[PROP_CODIGO],
        [SEQUENCIA_COLHEITA].[DS_NOME_PROPRIEDADE],
        [SEQUENCIA_COLHEITA].[COORD_LAT],
        [SEQUENCIA_COLHEITA].[COORD_LONG],
        [SEQUENCIA_COLHEITA].[ORDEM],
        [SEQUENCIA_COLHEITA].[_trackCreationUser],
        [SEQUENCIA_COLHEITA].[_trackLastWriteUser])
    VALUES (
        @FRENTE_COLHEITA,
        @PROP_CODIGO,
        @DS_NOME_PROPRIEDADE,
        @COORD_LAT,
        @COORD_LONG,
        @ORDEM,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [SEQUENCIA_COLHEITA] 
        WHERE ([SEQUENCIA_COLHEITA].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[sistema_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
UPDATE [menu] SET
 [menu].[oSistema_pId] = NULL
    WHERE ([menu].[oSistema_pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
DELETE [empresa_osistemas_sistema_oempresas] FROM [empresa_osistemas_sistema_oempresas] 
    WHERE ([empresa_osistemas_sistema_oempresas].[pId2] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
UPDATE [menupermissao] SET
 [menupermissao].[oSistema_pId] = NULL
    WHERE ([menupermissao].[oSistema_pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
DELETE [sistema] FROM [sistema] 
    WHERE ([sistema].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[sistema_Deleteempresaosistemas]
(
 @pId [bigint] = NULL,
 @pId2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [empresa_osistemas_sistema_oempresas] FROM [empresa_osistemas_sistema_oempresas] 
    WHERE (([empresa_osistemas_sistema_oempresas].[pId2] = @pId2) AND ([empresa_osistemas_sistema_oempresas].[pId] = @pId))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[sistema_Save]
(
 @pId [bigint] = NULL,
 @pNome [nvarchar] (256) = NULL,
 @pCodigo [int],
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [sistema] SET
 [sistema].[pNome] = @pNome,
 [sistema].[pCodigo] = @pCodigo,
 [sistema].[xDataHoraReg] = @xDataHoraReg,
 [sistema].[xLoginReg] = @xLoginReg,
 [sistema].[_trackLastWriteUser] = @_trackLastWriteUser,
 [sistema].[_trackLastWriteTime] = GETDATE()
    WHERE ([sistema].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [sistema] (
        [sistema].[pNome],
        [sistema].[pCodigo],
        [sistema].[xDataHoraReg],
        [sistema].[xLoginReg],
        [sistema].[_trackCreationUser],
        [sistema].[_trackLastWriteUser])
    VALUES (
        @pNome,
        @pCodigo,
        @xDataHoraReg,
        @xLoginReg,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [sistema] 
        WHERE ([sistema].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[sistema_Saveempresaosistemas]
(
 @pId [bigint],
 @pId2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
SELECT DISTINCT TOP 1 [empresa_osistemas_sistema_oempresas].[pId] 
    FROM [empresa_osistemas_sistema_oempresas] 
    WHERE (([empresa_osistemas_sistema_oempresas].[pId2] = @pId2) AND ([empresa_osistemas_sistema_oempresas].[pId] = @pId))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [empresa_osistemas_sistema_oempresas] (
        [empresa_osistemas_sistema_oempresas].[pId],
        [empresa_osistemas_sistema_oempresas].[pId2])
    VALUES (
        @pId,
        @pId2)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[uf_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
UPDATE [cidade] SET
 [cidade].[oUF_pId] = NULL
    WHERE ([cidade].[oUF_pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
DELETE [uf] FROM [uf] 
    WHERE ([uf].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[uf_Save]
(
 @pId [bigint] = NULL,
 @pCodigo [int],
 @pDescricao [nvarchar] (256) = NULL,
 @pSigla [nvarchar] (2) = NULL,
 @pCodigoIbge [int] = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @oPais_pId [bigint] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [uf] SET
 [uf].[pCodigo] = @pCodigo,
 [uf].[pDescricao] = @pDescricao,
 [uf].[pSigla] = @pSigla,
 [uf].[pCodigoIbge] = @pCodigoIbge,
 [uf].[xDataHoraReg] = @xDataHoraReg,
 [uf].[xLoginReg] = @xLoginReg,
 [uf].[oPais_pId] = @oPais_pId,
 [uf].[_trackLastWriteUser] = @_trackLastWriteUser,
 [uf].[_trackLastWriteTime] = GETDATE()
    WHERE ([uf].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [uf] (
        [uf].[pCodigo],
        [uf].[pDescricao],
        [uf].[pSigla],
        [uf].[pCodigoIbge],
        [uf].[xDataHoraReg],
        [uf].[xLoginReg],
        [uf].[oPais_pId],
        [uf].[_trackCreationUser],
        [uf].[_trackLastWriteUser])
    VALUES (
        @pCodigo,
        @pDescricao,
        @pSigla,
        @pCodigoIbge,
        @xDataHoraReg,
        @xLoginReg,
        @oPais_pId,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [uf] 
        WHERE ([uf].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [filial_ousuarios_usuario_ofiliais] FROM [filial_ousuarios_usuario_ofiliais] 
    WHERE ([filial_ousuarios_usuario_ofiliais].[pId2] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
DELETE [apprelatorio_oUsuarios_usuario_oAppRelatorios] FROM [apprelatorio_oUsuarios_usuario_oAppRelatorios] 
    WHERE ([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId2] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
UPDATE [menupermissao] SET
 [menupermissao].[oUsuario_pId] = NULL
    WHERE ([menupermissao].[oUsuario_pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
DELETE [usuario] FROM [usuario] 
    WHERE ([usuario].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_DeleteapprelatoriooUsuarios]
(
 @pId [bigint] = NULL,
 @pId2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [apprelatorio_oUsuarios_usuario_oAppRelatorios] FROM [apprelatorio_oUsuarios_usuario_oAppRelatorios] 
    WHERE (([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId2] = @pId2) AND ([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId] = @pId))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_Deletefilialousuarios]
(
 @pId [bigint] = NULL,
 @pId2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [filial_ousuarios_usuario_ofiliais] FROM [filial_ousuarios_usuario_ofiliais] 
    WHERE (([filial_ousuarios_usuario_ofiliais].[pId2] = @pId2) AND ([filial_ousuarios_usuario_ofiliais].[pId] = @pId))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_Save]
(
 @pId [bigint] = NULL,
 @pCodigo [int],
 @pLogin [nvarchar] (20),
 @pSenha [nvarchar] (256) = NULL,
 @pFlgAdmin [nvarchar] (1) = NULL,
 @sStatus [int] = NULL,
 @xDataHoraReg [datetime] = NULL,
 @xLoginReg [nvarchar] (30) = NULL,
 @oCadastro_pId [bigint] = NULL,
 @oIdUser_Id [bigint] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [usuario] SET
 [usuario].[pCodigo] = @pCodigo,
 [usuario].[pLogin] = @pLogin,
 [usuario].[pSenha] = @pSenha,
 [usuario].[pFlgAdmin] = @pFlgAdmin,
 [usuario].[sStatus] = @sStatus,
 [usuario].[xDataHoraReg] = @xDataHoraReg,
 [usuario].[xLoginReg] = @xLoginReg,
 [usuario].[oCadastro_pId] = @oCadastro_pId,
 [usuario].[oIdUser_Id] = @oIdUser_Id,
 [usuario].[_trackLastWriteUser] = @_trackLastWriteUser,
 [usuario].[_trackLastWriteTime] = GETDATE()
    WHERE ([usuario].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [usuario] (
        [usuario].[pCodigo],
        [usuario].[pLogin],
        [usuario].[pSenha],
        [usuario].[pFlgAdmin],
        [usuario].[sStatus],
        [usuario].[xDataHoraReg],
        [usuario].[xLoginReg],
        [usuario].[oCadastro_pId],
        [usuario].[oIdUser_Id],
        [usuario].[_trackCreationUser],
        [usuario].[_trackLastWriteUser])
    VALUES (
        @pCodigo,
        @pLogin,
        @pSenha,
        @pFlgAdmin,
        @sStatus,
        @xDataHoraReg,
        @xLoginReg,
        @oCadastro_pId,
        @oIdUser_Id,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [usuario] 
        WHERE ([usuario].[pId] = @pId)
END
IF(@oCadastro_pId IS NOT NULL)
BEGIN
    UPDATE [cadastro] SET
     [cadastro].[oUsuario_pId] = @pId
        WHERE ([cadastro].[pId] = @oCadastro_pId)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF(@oIdUser_Id IS NOT NULL)
BEGIN
    UPDATE [IdUser] SET
     [IdUser].[oUsuario_pId] = @pId
        WHERE ([IdUser].[Id] = @oIdUser_Id)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_SaveapprelatoriooUsuarios]
(
 @pId [bigint],
 @pId2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
SELECT DISTINCT TOP 1 [apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId] 
    FROM [apprelatorio_oUsuarios_usuario_oAppRelatorios] 
    WHERE (([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId2] = @pId2) AND ([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId] = @pId))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [apprelatorio_oUsuarios_usuario_oAppRelatorios] (
        [apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId],
        [apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId2])
    VALUES (
        @pId,
        @pId2)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_Savefilialousuarios]
(
 @pId [bigint],
 @pId2 [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
SELECT DISTINCT TOP 1 [filial_ousuarios_usuario_ofiliais].[pId] 
    FROM [filial_ousuarios_usuario_ofiliais] 
    WHERE (([filial_ousuarios_usuario_ofiliais].[pId2] = @pId2) AND ([filial_ousuarios_usuario_ofiliais].[pId] = @pId))
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [filial_ousuarios_usuario_ofiliais] (
        [filial_ousuarios_usuario_ofiliais].[pId],
        [filial_ousuarios_usuario_ofiliais].[pId2])
    VALUES (
        @pId,
        @pId2)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[V_DADOS_TALHAO_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [V_DADOS_TALHAO] FROM [V_DADOS_TALHAO] 
    WHERE ([V_DADOS_TALHAO].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[V_DADOS_TALHAO_Save]
(
 @pId [bigint] = NULL,
 @ID_NEGOCIOS [int] = NULL,
 @SAFRA [int] = NULL,
 @COD_PROPRIEDADE [int] = NULL,
 @DSC_PROPRIEDADE [nvarchar] (256) = NULL,
 @TALHAO [int] = NULL,
 @CORTE [int] = NULL,
 @AMBIENTE [nvarchar] (256) = NULL,
 @VARIEDADE [nvarchar] (256) = NULL,
 @MATURACAO [nvarchar] (256) = NULL,
 @AREA_TOTAL [float] = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [V_DADOS_TALHAO] SET
 [V_DADOS_TALHAO].[ID_NEGOCIOS] = @ID_NEGOCIOS,
 [V_DADOS_TALHAO].[SAFRA] = @SAFRA,
 [V_DADOS_TALHAO].[COD_PROPRIEDADE] = @COD_PROPRIEDADE,
 [V_DADOS_TALHAO].[DSC_PROPRIEDADE] = @DSC_PROPRIEDADE,
 [V_DADOS_TALHAO].[TALHAO] = @TALHAO,
 [V_DADOS_TALHAO].[CORTE] = @CORTE,
 [V_DADOS_TALHAO].[AMBIENTE] = @AMBIENTE,
 [V_DADOS_TALHAO].[VARIEDADE] = @VARIEDADE,
 [V_DADOS_TALHAO].[MATURACAO] = @MATURACAO,
 [V_DADOS_TALHAO].[AREA_TOTAL] = @AREA_TOTAL,
 [V_DADOS_TALHAO].[_trackLastWriteUser] = @_trackLastWriteUser,
 [V_DADOS_TALHAO].[_trackLastWriteTime] = GETDATE()
    WHERE ([V_DADOS_TALHAO].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [V_DADOS_TALHAO] (
        [V_DADOS_TALHAO].[ID_NEGOCIOS],
        [V_DADOS_TALHAO].[SAFRA],
        [V_DADOS_TALHAO].[COD_PROPRIEDADE],
        [V_DADOS_TALHAO].[DSC_PROPRIEDADE],
        [V_DADOS_TALHAO].[TALHAO],
        [V_DADOS_TALHAO].[CORTE],
        [V_DADOS_TALHAO].[AMBIENTE],
        [V_DADOS_TALHAO].[VARIEDADE],
        [V_DADOS_TALHAO].[MATURACAO],
        [V_DADOS_TALHAO].[AREA_TOTAL],
        [V_DADOS_TALHAO].[_trackCreationUser],
        [V_DADOS_TALHAO].[_trackLastWriteUser])
    VALUES (
        @ID_NEGOCIOS,
        @SAFRA,
        @COD_PROPRIEDADE,
        @DSC_PROPRIEDADE,
        @TALHAO,
        @CORTE,
        @AMBIENTE,
        @VARIEDADE,
        @MATURACAO,
        @AREA_TOTAL,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [V_DADOS_TALHAO] 
        WHERE ([V_DADOS_TALHAO].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[WebSiteMap_Delete]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
DELETE [WebSiteMap] FROM [WebSiteMap] 
    WHERE ([WebSiteMap].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[WebSiteMap_Save]
(
 @pId [bigint] = NULL,
 @pRelPath [nvarchar] (256) = NULL,
 @pNode [nvarchar] (256) = NULL,
 @pDescription [nvarchar] (256) = NULL,
 @_trackLastWriteUser [nvarchar] (64) = NULL
)
AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
IF(@_trackLastWriteUser IS NULL)
BEGIN
    SELECT DISTINCT @_trackLastWriteUser = SYSTEM_USER  
END
UPDATE [WebSiteMap] SET
 [WebSiteMap].[pRelPath] = @pRelPath,
 [WebSiteMap].[pNode] = @pNode,
 [WebSiteMap].[pDescription] = @pDescription,
 [WebSiteMap].[_trackLastWriteUser] = @_trackLastWriteUser,
 [WebSiteMap].[_trackLastWriteTime] = GETDATE()
    WHERE ([WebSiteMap].[pId] = @pId)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
    INSERT INTO [WebSiteMap] (
        [WebSiteMap].[pRelPath],
        [WebSiteMap].[pNode],
        [WebSiteMap].[pDescription],
        [WebSiteMap].[_trackCreationUser],
        [WebSiteMap].[_trackLastWriteUser])
    VALUES (
        @pRelPath,
        @pNode,
        @pDescription,
        @_trackLastWriteUser,
        @_trackLastWriteUser)
    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @pId = SCOPE_IDENTITY()  
    SELECT DISTINCT @pId AS 'pId' 
        FROM [WebSiteMap] 
        WHERE ([WebSiteMap].[pId] = @pId)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_1CORTE_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_1CORTE].[pId], [ACOMP_PROD_1CORTE].[ROWNUM], [ACOMP_PROD_1CORTE].[PROP_CODIGO], [ACOMP_PROD_1CORTE].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_1CORTE].[NRO_CORTE], [ACOMP_PROD_1CORTE].[QT_AREA_COLHIDA], [ACOMP_PROD_1CORTE].[IDADE], [ACOMP_PROD_1CORTE].[TIPO_PROPRIEDADE], [ACOMP_PROD_1CORTE].[QT_TON_ENTREGUE], [ACOMP_PROD_1CORTE].[RENDIMENTO_PLAN], [ACOMP_PROD_1CORTE].[RENDIMENTO_REAL], [ACOMP_PROD_1CORTE].[DESVIO], [ACOMP_PROD_1CORTE].[PORC_BROCA], [ACOMP_PROD_1CORTE].[PERDAS], [ACOMP_PROD_1CORTE].[INCENDIO], [ACOMP_PROD_1CORTE].[DATA_INCENDIO], [ACOMP_PROD_1CORTE].[DT_DESSECACAO], [ACOMP_PROD_1CORTE].[DT_CALAGEM], [ACOMP_PROD_1CORTE].[DT_PLANTIO], [ACOMP_PROD_1CORTE].[TIPO_PLANTIO], [ACOMP_PROD_1CORTE].[EMPRESA_PLANTIO], [ACOMP_PROD_1CORTE].[STAND], [ACOMP_PROD_1CORTE].[TIPO_ADUBACAO], [ACOMP_PROD_1CORTE].[TRAT_TOLETES], [ACOMP_PROD_1CORTE].[DT_HERB_CANA_PLANTA], [ACOMP_PROD_1CORTE].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_1CORTE].[_trackLastWriteTime], [ACOMP_PROD_1CORTE].[_trackCreationTime], [ACOMP_PROD_1CORTE].[_trackLastWriteUser], [ACOMP_PROD_1CORTE].[_trackCreationUser] 
    FROM [ACOMP_PROD_1CORTE] 
    WHERE ([ACOMP_PROD_1CORTE].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_1CORTE_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_1CORTE].[pId], [ACOMP_PROD_1CORTE].[ROWNUM], [ACOMP_PROD_1CORTE].[PROP_CODIGO], [ACOMP_PROD_1CORTE].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_1CORTE].[NRO_CORTE], [ACOMP_PROD_1CORTE].[QT_AREA_COLHIDA], [ACOMP_PROD_1CORTE].[IDADE], [ACOMP_PROD_1CORTE].[TIPO_PROPRIEDADE], [ACOMP_PROD_1CORTE].[QT_TON_ENTREGUE], [ACOMP_PROD_1CORTE].[RENDIMENTO_PLAN], [ACOMP_PROD_1CORTE].[RENDIMENTO_REAL], [ACOMP_PROD_1CORTE].[DESVIO], [ACOMP_PROD_1CORTE].[PORC_BROCA], [ACOMP_PROD_1CORTE].[PERDAS], [ACOMP_PROD_1CORTE].[INCENDIO], [ACOMP_PROD_1CORTE].[DATA_INCENDIO], [ACOMP_PROD_1CORTE].[DT_DESSECACAO], [ACOMP_PROD_1CORTE].[DT_CALAGEM], [ACOMP_PROD_1CORTE].[DT_PLANTIO], [ACOMP_PROD_1CORTE].[TIPO_PLANTIO], [ACOMP_PROD_1CORTE].[EMPRESA_PLANTIO], [ACOMP_PROD_1CORTE].[STAND], [ACOMP_PROD_1CORTE].[TIPO_ADUBACAO], [ACOMP_PROD_1CORTE].[TRAT_TOLETES], [ACOMP_PROD_1CORTE].[DT_HERB_CANA_PLANTA], [ACOMP_PROD_1CORTE].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_1CORTE].[_trackLastWriteTime], [ACOMP_PROD_1CORTE].[_trackCreationTime], [ACOMP_PROD_1CORTE].[_trackLastWriteUser], [ACOMP_PROD_1CORTE].[_trackCreationUser] 
    FROM [ACOMP_PROD_1CORTE] 

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_1CORTE_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_1CORTE].[pId], [ACOMP_PROD_1CORTE].[ROWNUM], [ACOMP_PROD_1CORTE].[PROP_CODIGO], [ACOMP_PROD_1CORTE].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_1CORTE].[NRO_CORTE], [ACOMP_PROD_1CORTE].[QT_AREA_COLHIDA], [ACOMP_PROD_1CORTE].[IDADE], [ACOMP_PROD_1CORTE].[TIPO_PROPRIEDADE], [ACOMP_PROD_1CORTE].[QT_TON_ENTREGUE], [ACOMP_PROD_1CORTE].[RENDIMENTO_PLAN], [ACOMP_PROD_1CORTE].[RENDIMENTO_REAL], [ACOMP_PROD_1CORTE].[DESVIO], [ACOMP_PROD_1CORTE].[PORC_BROCA], [ACOMP_PROD_1CORTE].[PERDAS], [ACOMP_PROD_1CORTE].[INCENDIO], [ACOMP_PROD_1CORTE].[DATA_INCENDIO], [ACOMP_PROD_1CORTE].[DT_DESSECACAO], [ACOMP_PROD_1CORTE].[DT_CALAGEM], [ACOMP_PROD_1CORTE].[DT_PLANTIO], [ACOMP_PROD_1CORTE].[TIPO_PLANTIO], [ACOMP_PROD_1CORTE].[EMPRESA_PLANTIO], [ACOMP_PROD_1CORTE].[STAND], [ACOMP_PROD_1CORTE].[TIPO_ADUBACAO], [ACOMP_PROD_1CORTE].[TRAT_TOLETES], [ACOMP_PROD_1CORTE].[DT_HERB_CANA_PLANTA], [ACOMP_PROD_1CORTE].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_1CORTE].[_trackLastWriteTime], [ACOMP_PROD_1CORTE].[_trackCreationTime], [ACOMP_PROD_1CORTE].[_trackLastWriteUser], [ACOMP_PROD_1CORTE].[_trackCreationUser] 
    FROM [ACOMP_PROD_1CORTE] 
    WHERE ([ACOMP_PROD_1CORTE].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_1CORTE_TALHAO_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_1CORTE_TALHAO].[pId], [ACOMP_PROD_1CORTE_TALHAO].[ROWNUM], [ACOMP_PROD_1CORTE_TALHAO].[PROP_CODIGO], [ACOMP_PROD_1CORTE_TALHAO].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_1CORTE_TALHAO].[TALHAO], [ACOMP_PROD_1CORTE_TALHAO].[NRO_CORTE], [ACOMP_PROD_1CORTE_TALHAO].[QT_AREA_COLHIDA], [ACOMP_PROD_1CORTE_TALHAO].[IDADE], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PROPRIEDADE], [ACOMP_PROD_1CORTE_TALHAO].[QT_TON_ENTREGUE], [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_PLAN], [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_REAL], [ACOMP_PROD_1CORTE_TALHAO].[DESVIO], [ACOMP_PROD_1CORTE_TALHAO].[PORC_BROCA], [ACOMP_PROD_1CORTE_TALHAO].[PERDAS], [ACOMP_PROD_1CORTE_TALHAO].[INCENDIO], [ACOMP_PROD_1CORTE_TALHAO].[DATA_INCENDIO], [ACOMP_PROD_1CORTE_TALHAO].[DT_DESSECACAO], [ACOMP_PROD_1CORTE_TALHAO].[DT_CALAGEM], [ACOMP_PROD_1CORTE_TALHAO].[DT_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[EMPRESA_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[STAND], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_ADUBACAO], [ACOMP_PROD_1CORTE_TALHAO].[TRAT_TOLETES], [ACOMP_PROD_1CORTE_TALHAO].[DT_HERB_CANA_PLANTA], [ACOMP_PROD_1CORTE_TALHAO].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteTime], [ACOMP_PROD_1CORTE_TALHAO].[_trackCreationTime], [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteUser], [ACOMP_PROD_1CORTE_TALHAO].[_trackCreationUser] 
    FROM [ACOMP_PROD_1CORTE_TALHAO] 
    WHERE ([ACOMP_PROD_1CORTE_TALHAO].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_1CORTE_TALHAO_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_1CORTE_TALHAO].[pId], [ACOMP_PROD_1CORTE_TALHAO].[ROWNUM], [ACOMP_PROD_1CORTE_TALHAO].[PROP_CODIGO], [ACOMP_PROD_1CORTE_TALHAO].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_1CORTE_TALHAO].[TALHAO], [ACOMP_PROD_1CORTE_TALHAO].[NRO_CORTE], [ACOMP_PROD_1CORTE_TALHAO].[QT_AREA_COLHIDA], [ACOMP_PROD_1CORTE_TALHAO].[IDADE], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PROPRIEDADE], [ACOMP_PROD_1CORTE_TALHAO].[QT_TON_ENTREGUE], [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_PLAN], [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_REAL], [ACOMP_PROD_1CORTE_TALHAO].[DESVIO], [ACOMP_PROD_1CORTE_TALHAO].[PORC_BROCA], [ACOMP_PROD_1CORTE_TALHAO].[PERDAS], [ACOMP_PROD_1CORTE_TALHAO].[INCENDIO], [ACOMP_PROD_1CORTE_TALHAO].[DATA_INCENDIO], [ACOMP_PROD_1CORTE_TALHAO].[DT_DESSECACAO], [ACOMP_PROD_1CORTE_TALHAO].[DT_CALAGEM], [ACOMP_PROD_1CORTE_TALHAO].[DT_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[EMPRESA_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[STAND], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_ADUBACAO], [ACOMP_PROD_1CORTE_TALHAO].[TRAT_TOLETES], [ACOMP_PROD_1CORTE_TALHAO].[DT_HERB_CANA_PLANTA], [ACOMP_PROD_1CORTE_TALHAO].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteTime], [ACOMP_PROD_1CORTE_TALHAO].[_trackCreationTime], [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteUser], [ACOMP_PROD_1CORTE_TALHAO].[_trackCreationUser] 
    FROM [ACOMP_PROD_1CORTE_TALHAO] 

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_1CORTE_TALHAO_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_1CORTE_TALHAO].[pId], [ACOMP_PROD_1CORTE_TALHAO].[ROWNUM], [ACOMP_PROD_1CORTE_TALHAO].[PROP_CODIGO], [ACOMP_PROD_1CORTE_TALHAO].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_1CORTE_TALHAO].[TALHAO], [ACOMP_PROD_1CORTE_TALHAO].[NRO_CORTE], [ACOMP_PROD_1CORTE_TALHAO].[QT_AREA_COLHIDA], [ACOMP_PROD_1CORTE_TALHAO].[IDADE], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PROPRIEDADE], [ACOMP_PROD_1CORTE_TALHAO].[QT_TON_ENTREGUE], [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_PLAN], [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_REAL], [ACOMP_PROD_1CORTE_TALHAO].[DESVIO], [ACOMP_PROD_1CORTE_TALHAO].[PORC_BROCA], [ACOMP_PROD_1CORTE_TALHAO].[PERDAS], [ACOMP_PROD_1CORTE_TALHAO].[INCENDIO], [ACOMP_PROD_1CORTE_TALHAO].[DATA_INCENDIO], [ACOMP_PROD_1CORTE_TALHAO].[DT_DESSECACAO], [ACOMP_PROD_1CORTE_TALHAO].[DT_CALAGEM], [ACOMP_PROD_1CORTE_TALHAO].[DT_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[EMPRESA_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[STAND], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_ADUBACAO], [ACOMP_PROD_1CORTE_TALHAO].[TRAT_TOLETES], [ACOMP_PROD_1CORTE_TALHAO].[DT_HERB_CANA_PLANTA], [ACOMP_PROD_1CORTE_TALHAO].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteTime], [ACOMP_PROD_1CORTE_TALHAO].[_trackCreationTime], [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteUser], [ACOMP_PROD_1CORTE_TALHAO].[_trackCreationUser] 
    FROM [ACOMP_PROD_1CORTE_TALHAO] 
    WHERE ([ACOMP_PROD_1CORTE_TALHAO].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_DCORTE_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_DCORTE].[pId], [ACOMP_PROD_DCORTE].[ROWNUM], [ACOMP_PROD_DCORTE].[PROP_CODIGO], [ACOMP_PROD_DCORTE].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_DCORTE].[NRO_CORTE], [ACOMP_PROD_DCORTE].[QT_AREA_COLHIDA], [ACOMP_PROD_DCORTE].[IDADE], [ACOMP_PROD_DCORTE].[TIPO_PROPRIEDADE], [ACOMP_PROD_DCORTE].[QT_TON_ENTREGUE], [ACOMP_PROD_DCORTE].[RENDIMENTO_PLAN], [ACOMP_PROD_DCORTE].[RENDIMENTO_REAL], [ACOMP_PROD_DCORTE].[DESVIO], [ACOMP_PROD_DCORTE].[PORC_BROCA], [ACOMP_PROD_DCORTE].[PERDAS], [ACOMP_PROD_DCORTE].[DT_COLHEITA_ANTERIOR], [ACOMP_PROD_DCORTE].[TIPO_ADUBACAO], [ACOMP_PROD_DCORTE].[DT_ADUBACAO], [ACOMP_PROD_DCORTE].[DIF_DIAS_ADUB], [ACOMP_PROD_DCORTE].[TIPO_HERBICIDA], [ACOMP_PROD_DCORTE].[DT_HERBICIDA], [ACOMP_PROD_DCORTE].[DIF_DIAS_HERB], [ACOMP_PROD_DCORTE].[INCENDIO], [ACOMP_PROD_DCORTE].[DATA_INCENDIO], [ACOMP_PROD_DCORTE].[FERTIRRIGACAO], [ACOMP_PROD_DCORTE].[DT_FERTIRRIGACAO], [ACOMP_PROD_DCORTE].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_DCORTE].[_trackLastWriteTime], [ACOMP_PROD_DCORTE].[_trackCreationTime], [ACOMP_PROD_DCORTE].[_trackLastWriteUser], [ACOMP_PROD_DCORTE].[_trackCreationUser] 
    FROM [ACOMP_PROD_DCORTE] 
    WHERE ([ACOMP_PROD_DCORTE].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_DCORTE_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_DCORTE].[pId], [ACOMP_PROD_DCORTE].[ROWNUM], [ACOMP_PROD_DCORTE].[PROP_CODIGO], [ACOMP_PROD_DCORTE].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_DCORTE].[NRO_CORTE], [ACOMP_PROD_DCORTE].[QT_AREA_COLHIDA], [ACOMP_PROD_DCORTE].[IDADE], [ACOMP_PROD_DCORTE].[TIPO_PROPRIEDADE], [ACOMP_PROD_DCORTE].[QT_TON_ENTREGUE], [ACOMP_PROD_DCORTE].[RENDIMENTO_PLAN], [ACOMP_PROD_DCORTE].[RENDIMENTO_REAL], [ACOMP_PROD_DCORTE].[DESVIO], [ACOMP_PROD_DCORTE].[PORC_BROCA], [ACOMP_PROD_DCORTE].[PERDAS], [ACOMP_PROD_DCORTE].[DT_COLHEITA_ANTERIOR], [ACOMP_PROD_DCORTE].[TIPO_ADUBACAO], [ACOMP_PROD_DCORTE].[DT_ADUBACAO], [ACOMP_PROD_DCORTE].[DIF_DIAS_ADUB], [ACOMP_PROD_DCORTE].[TIPO_HERBICIDA], [ACOMP_PROD_DCORTE].[DT_HERBICIDA], [ACOMP_PROD_DCORTE].[DIF_DIAS_HERB], [ACOMP_PROD_DCORTE].[INCENDIO], [ACOMP_PROD_DCORTE].[DATA_INCENDIO], [ACOMP_PROD_DCORTE].[FERTIRRIGACAO], [ACOMP_PROD_DCORTE].[DT_FERTIRRIGACAO], [ACOMP_PROD_DCORTE].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_DCORTE].[_trackLastWriteTime], [ACOMP_PROD_DCORTE].[_trackCreationTime], [ACOMP_PROD_DCORTE].[_trackLastWriteUser], [ACOMP_PROD_DCORTE].[_trackCreationUser] 
    FROM [ACOMP_PROD_DCORTE] 

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_DCORTE_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_DCORTE].[pId], [ACOMP_PROD_DCORTE].[ROWNUM], [ACOMP_PROD_DCORTE].[PROP_CODIGO], [ACOMP_PROD_DCORTE].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_DCORTE].[NRO_CORTE], [ACOMP_PROD_DCORTE].[QT_AREA_COLHIDA], [ACOMP_PROD_DCORTE].[IDADE], [ACOMP_PROD_DCORTE].[TIPO_PROPRIEDADE], [ACOMP_PROD_DCORTE].[QT_TON_ENTREGUE], [ACOMP_PROD_DCORTE].[RENDIMENTO_PLAN], [ACOMP_PROD_DCORTE].[RENDIMENTO_REAL], [ACOMP_PROD_DCORTE].[DESVIO], [ACOMP_PROD_DCORTE].[PORC_BROCA], [ACOMP_PROD_DCORTE].[PERDAS], [ACOMP_PROD_DCORTE].[DT_COLHEITA_ANTERIOR], [ACOMP_PROD_DCORTE].[TIPO_ADUBACAO], [ACOMP_PROD_DCORTE].[DT_ADUBACAO], [ACOMP_PROD_DCORTE].[DIF_DIAS_ADUB], [ACOMP_PROD_DCORTE].[TIPO_HERBICIDA], [ACOMP_PROD_DCORTE].[DT_HERBICIDA], [ACOMP_PROD_DCORTE].[DIF_DIAS_HERB], [ACOMP_PROD_DCORTE].[INCENDIO], [ACOMP_PROD_DCORTE].[DATA_INCENDIO], [ACOMP_PROD_DCORTE].[FERTIRRIGACAO], [ACOMP_PROD_DCORTE].[DT_FERTIRRIGACAO], [ACOMP_PROD_DCORTE].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_DCORTE].[_trackLastWriteTime], [ACOMP_PROD_DCORTE].[_trackCreationTime], [ACOMP_PROD_DCORTE].[_trackLastWriteUser], [ACOMP_PROD_DCORTE].[_trackCreationUser] 
    FROM [ACOMP_PROD_DCORTE] 
    WHERE ([ACOMP_PROD_DCORTE].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_DCORTE_TALHAO_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_DCORTE_TALHAO].[pId], [ACOMP_PROD_DCORTE_TALHAO].[ROWNUM], [ACOMP_PROD_DCORTE_TALHAO].[PROP_CODIGO], [ACOMP_PROD_DCORTE_TALHAO].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_DCORTE_TALHAO].[TALHAO], [ACOMP_PROD_DCORTE_TALHAO].[NRO_CORTE], [ACOMP_PROD_DCORTE_TALHAO].[QT_AREA_COLHIDA], [ACOMP_PROD_DCORTE_TALHAO].[IDADE], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_PROPRIEDADE], [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ATUAL], [ACOMP_PROD_DCORTE_TALHAO].[QT_TON_ENTREGUE], [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_PLAN], [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_REAL], [ACOMP_PROD_DCORTE_TALHAO].[DESVIO], [ACOMP_PROD_DCORTE_TALHAO].[PORC_BROCA], [ACOMP_PROD_DCORTE_TALHAO].[PERDAS], [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ANTERIOR], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_ADUBACAO], [ACOMP_PROD_DCORTE_TALHAO].[DT_ADUBACAO], [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_ADUB], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_HERBICIDA], [ACOMP_PROD_DCORTE_TALHAO].[DT_HERBICIDA], [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_HERB], [ACOMP_PROD_DCORTE_TALHAO].[INCENDIO], [ACOMP_PROD_DCORTE_TALHAO].[DATA_INCENDIO], [ACOMP_PROD_DCORTE_TALHAO].[FERTIRRIGACAO], [ACOMP_PROD_DCORTE_TALHAO].[DT_FERTIRRIGACAO], [ACOMP_PROD_DCORTE_TALHAO].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteTime], [ACOMP_PROD_DCORTE_TALHAO].[_trackCreationTime], [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteUser], [ACOMP_PROD_DCORTE_TALHAO].[_trackCreationUser] 
    FROM [ACOMP_PROD_DCORTE_TALHAO] 
    WHERE ([ACOMP_PROD_DCORTE_TALHAO].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_DCORTE_TALHAO_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_DCORTE_TALHAO].[pId], [ACOMP_PROD_DCORTE_TALHAO].[ROWNUM], [ACOMP_PROD_DCORTE_TALHAO].[PROP_CODIGO], [ACOMP_PROD_DCORTE_TALHAO].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_DCORTE_TALHAO].[TALHAO], [ACOMP_PROD_DCORTE_TALHAO].[NRO_CORTE], [ACOMP_PROD_DCORTE_TALHAO].[QT_AREA_COLHIDA], [ACOMP_PROD_DCORTE_TALHAO].[IDADE], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_PROPRIEDADE], [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ATUAL], [ACOMP_PROD_DCORTE_TALHAO].[QT_TON_ENTREGUE], [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_PLAN], [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_REAL], [ACOMP_PROD_DCORTE_TALHAO].[DESVIO], [ACOMP_PROD_DCORTE_TALHAO].[PORC_BROCA], [ACOMP_PROD_DCORTE_TALHAO].[PERDAS], [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ANTERIOR], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_ADUBACAO], [ACOMP_PROD_DCORTE_TALHAO].[DT_ADUBACAO], [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_ADUB], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_HERBICIDA], [ACOMP_PROD_DCORTE_TALHAO].[DT_HERBICIDA], [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_HERB], [ACOMP_PROD_DCORTE_TALHAO].[INCENDIO], [ACOMP_PROD_DCORTE_TALHAO].[DATA_INCENDIO], [ACOMP_PROD_DCORTE_TALHAO].[FERTIRRIGACAO], [ACOMP_PROD_DCORTE_TALHAO].[DT_FERTIRRIGACAO], [ACOMP_PROD_DCORTE_TALHAO].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteTime], [ACOMP_PROD_DCORTE_TALHAO].[_trackCreationTime], [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteUser], [ACOMP_PROD_DCORTE_TALHAO].[_trackCreationUser] 
    FROM [ACOMP_PROD_DCORTE_TALHAO] 

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMP_PROD_DCORTE_TALHAO_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMP_PROD_DCORTE_TALHAO].[pId], [ACOMP_PROD_DCORTE_TALHAO].[ROWNUM], [ACOMP_PROD_DCORTE_TALHAO].[PROP_CODIGO], [ACOMP_PROD_DCORTE_TALHAO].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_DCORTE_TALHAO].[TALHAO], [ACOMP_PROD_DCORTE_TALHAO].[NRO_CORTE], [ACOMP_PROD_DCORTE_TALHAO].[QT_AREA_COLHIDA], [ACOMP_PROD_DCORTE_TALHAO].[IDADE], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_PROPRIEDADE], [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ATUAL], [ACOMP_PROD_DCORTE_TALHAO].[QT_TON_ENTREGUE], [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_PLAN], [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_REAL], [ACOMP_PROD_DCORTE_TALHAO].[DESVIO], [ACOMP_PROD_DCORTE_TALHAO].[PORC_BROCA], [ACOMP_PROD_DCORTE_TALHAO].[PERDAS], [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ANTERIOR], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_ADUBACAO], [ACOMP_PROD_DCORTE_TALHAO].[DT_ADUBACAO], [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_ADUB], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_HERBICIDA], [ACOMP_PROD_DCORTE_TALHAO].[DT_HERBICIDA], [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_HERB], [ACOMP_PROD_DCORTE_TALHAO].[INCENDIO], [ACOMP_PROD_DCORTE_TALHAO].[DATA_INCENDIO], [ACOMP_PROD_DCORTE_TALHAO].[FERTIRRIGACAO], [ACOMP_PROD_DCORTE_TALHAO].[DT_FERTIRRIGACAO], [ACOMP_PROD_DCORTE_TALHAO].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteTime], [ACOMP_PROD_DCORTE_TALHAO].[_trackCreationTime], [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteUser], [ACOMP_PROD_DCORTE_TALHAO].[_trackCreationUser] 
    FROM [ACOMP_PROD_DCORTE_TALHAO] 
    WHERE ([ACOMP_PROD_DCORTE_TALHAO].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMPANHAMENTO_PLANTIO_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMPANHAMENTO_PLANTIO].[pId], [ACOMPANHAMENTO_PLANTIO].[ID_NEGOCIOS], [ACOMPANHAMENTO_PLANTIO].[COD_PROPRIEDADE], [ACOMPANHAMENTO_PLANTIO].[SAFRA], [ACOMPANHAMENTO_PLANTIO].[DT_PLANTIO], [ACOMPANHAMENTO_PLANTIO].[AREA_PLANTIO], [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteTime], [ACOMPANHAMENTO_PLANTIO].[_trackCreationTime], [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteUser], [ACOMPANHAMENTO_PLANTIO].[_trackCreationUser] 
    FROM [ACOMPANHAMENTO_PLANTIO] 
    WHERE ([ACOMPANHAMENTO_PLANTIO].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMPANHAMENTO_PLANTIO_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMPANHAMENTO_PLANTIO].[pId], [ACOMPANHAMENTO_PLANTIO].[ID_NEGOCIOS], [ACOMPANHAMENTO_PLANTIO].[COD_PROPRIEDADE], [ACOMPANHAMENTO_PLANTIO].[SAFRA], [ACOMPANHAMENTO_PLANTIO].[DT_PLANTIO], [ACOMPANHAMENTO_PLANTIO].[AREA_PLANTIO], [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteTime], [ACOMPANHAMENTO_PLANTIO].[_trackCreationTime], [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteUser], [ACOMPANHAMENTO_PLANTIO].[_trackCreationUser] 
    FROM [ACOMPANHAMENTO_PLANTIO] 

RETURN
GO

CREATE PROCEDURE [dbo].[ACOMPANHAMENTO_PLANTIO_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ACOMPANHAMENTO_PLANTIO].[pId], [ACOMPANHAMENTO_PLANTIO].[ID_NEGOCIOS], [ACOMPANHAMENTO_PLANTIO].[COD_PROPRIEDADE], [ACOMPANHAMENTO_PLANTIO].[SAFRA], [ACOMPANHAMENTO_PLANTIO].[DT_PLANTIO], [ACOMPANHAMENTO_PLANTIO].[AREA_PLANTIO], [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteTime], [ACOMPANHAMENTO_PLANTIO].[_trackCreationTime], [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteUser], [ACOMPANHAMENTO_PLANTIO].[_trackCreationUser] 
    FROM [ACOMPANHAMENTO_PLANTIO] 
    WHERE ([ACOMPANHAMENTO_PLANTIO].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[appconfig_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [appconfig].[pId], [appconfig].[_trackLastWriteTime], [appconfig].[_trackCreationTime], [appconfig].[_trackLastWriteUser], [appconfig].[_trackCreationUser] 
    FROM [appconfig] 
    WHERE ([appconfig].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[appconfig_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [appconfig].[pId], [appconfig].[_trackLastWriteTime], [appconfig].[_trackCreationTime], [appconfig].[_trackLastWriteUser], [appconfig].[_trackCreationUser] 
    FROM [appconfig] 

RETURN
GO

CREATE PROCEDURE [dbo].[appconfig_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [appconfig].[pId], [appconfig].[_trackLastWriteTime], [appconfig].[_trackCreationTime], [appconfig].[_trackLastWriteUser], [appconfig].[_trackCreationUser] 
    FROM [appconfig] 
    WHERE ([appconfig].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[appconfig_LoadDataBD]

AS
SET NOCOUNT ON
SELECT cast(getdate() AS DATE) AS Data
RETURN
GO

CREATE PROCEDURE [dbo].[appconfig_LoadDataHoraBD]

AS
SET NOCOUNT ON
SELECT cast(getdate() AS DATETIME) AS DataHora
RETURN
GO

CREATE PROCEDURE [dbo].[appconfig_LoadHoraBD]

AS
SET NOCOUNT ON
SELECT cast(getdate() AS TIME) AS Hora
RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [apprelatorio].[pId], [apprelatorio].[pNomeFormArgumento], [apprelatorio].[pNomeRelatorio], [apprelatorio].[pNomeRdlc], [apprelatorio].[pNomeDataSet], [apprelatorio].[sCategoria], [apprelatorio].[pTituloRelatorio], [apprelatorio].[pSequencia], [apprelatorio].[pCategoriaRelatorio], [apprelatorio].[_trackLastWriteTime], [apprelatorio].[_trackCreationTime], [apprelatorio].[_trackLastWriteUser], [apprelatorio].[_trackCreationUser] 
    FROM [apprelatorio] 
    WHERE ([apprelatorio].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [apprelatorio].[pId], [apprelatorio].[pNomeFormArgumento], [apprelatorio].[pNomeRelatorio], [apprelatorio].[pNomeRdlc], [apprelatorio].[pNomeDataSet], [apprelatorio].[sCategoria], [apprelatorio].[pTituloRelatorio], [apprelatorio].[pSequencia], [apprelatorio].[pCategoriaRelatorio], [apprelatorio].[_trackLastWriteTime], [apprelatorio].[_trackCreationTime], [apprelatorio].[_trackLastWriteUser], [apprelatorio].[_trackCreationUser] 
    FROM [apprelatorio] 

RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_LoadAllView]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vapprelatorioapprelatorioview].[pId], [vapprelatorioapprelatorioview].[pNomeFormArgumento], [vapprelatorioapprelatorioview].[pNomeRelatorio], [vapprelatorioapprelatorioview].[pNomeRdlc], [vapprelatorioapprelatorioview].[pNomeDataSet], [vapprelatorioapprelatorioview].[sCategoria], [vapprelatorioapprelatorioview].[pTituloRelatorio], [vapprelatorioapprelatorioview].[pSequencia], [vapprelatorioapprelatorioview].[pCategoriaRelatorio], [vapprelatorioapprelatorioview].[_trackCreationTime], [vapprelatorioapprelatorioview].[_trackLastWriteTime], [vapprelatorioapprelatorioview].[_trackCreationUser], [vapprelatorioapprelatorioview].[_trackLastWriteUser] 
    FROM [vapprelatorioapprelatorioview] 
    ORDER BY [vapprelatorioapprelatorioview].[pSequencia] ASC

RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_LoadByCategoriaRelatorioView]
(
 @parCategoriaRelatorio [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vapprelatorioapprelatorioview].[pId], [vapprelatorioapprelatorioview].[pNomeFormArgumento], [vapprelatorioapprelatorioview].[pNomeRelatorio], [vapprelatorioapprelatorioview].[pNomeRdlc], [vapprelatorioapprelatorioview].[pNomeDataSet], [vapprelatorioapprelatorioview].[sCategoria], [vapprelatorioapprelatorioview].[pTituloRelatorio], [vapprelatorioapprelatorioview].[pSequencia], [vapprelatorioapprelatorioview].[pCategoriaRelatorio], [vapprelatorioapprelatorioview].[_trackCreationTime], [vapprelatorioapprelatorioview].[_trackLastWriteTime], [vapprelatorioapprelatorioview].[_trackCreationUser], [vapprelatorioapprelatorioview].[_trackLastWriteUser] 
    FROM [vapprelatorioapprelatorioview] 
    WHERE ([vapprelatorioapprelatorioview].[pCategoriaRelatorio] = @parCategoriaRelatorio)

RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_LoadByIdView]
(
 @parId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vapprelatorioapprelatoriousuarioview].[pId], [vapprelatorioapprelatoriousuarioview].[pNomeFormArgumento], [vapprelatorioapprelatoriousuarioview].[pNomeRelatorio], [vapprelatorioapprelatoriousuarioview].[pNomeRdlc], [vapprelatorioapprelatoriousuarioview].[pNomeDataSet], [vapprelatorioapprelatoriousuarioview].[sCategoria], [vapprelatorioapprelatoriousuarioview].[pTituloRelatorio], [vapprelatorioapprelatoriousuarioview].[pSequencia], [vapprelatorioapprelatoriousuarioview].[pCategoriaRelatorio], [vapprelatorioapprelatoriousuarioview].[pUsuarioLogin], [vapprelatorioapprelatoriousuarioview].[_trackCreationTime], [vapprelatorioapprelatoriousuarioview].[_trackLastWriteTime], [vapprelatorioapprelatoriousuarioview].[_trackCreationUser], [vapprelatorioapprelatoriousuarioview].[_trackLastWriteUser] 
    FROM [vapprelatorioapprelatoriousuarioview] 
    WHERE ([vapprelatorioapprelatoriousuarioview].[pId] = @parId)

RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_LoadBypNomeRelatorio]
(
 @pNomeRelatorio [nvarchar] (256)
)
AS
SET NOCOUNT ON
SELECT DISTINCT [apprelatorio].[pId], [apprelatorio].[pNomeFormArgumento], [apprelatorio].[pNomeRelatorio], [apprelatorio].[pNomeRdlc], [apprelatorio].[pNomeDataSet], [apprelatorio].[sCategoria], [apprelatorio].[pTituloRelatorio], [apprelatorio].[pSequencia], [apprelatorio].[pCategoriaRelatorio], [apprelatorio].[_trackLastWriteTime], [apprelatorio].[_trackCreationTime], [apprelatorio].[_trackLastWriteUser], [apprelatorio].[_trackCreationUser] 
    FROM [apprelatorio] 
    WHERE ([apprelatorio].[pNomeRelatorio] = @pNomeRelatorio)

RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_LoadByUsuarioCategoriaRelatorioView]
(
 @parLogin [nvarchar] (256),
 @parCategoriaRelatorio [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vapprelatorioapprelatoriousuarioview].[pId], [vapprelatorioapprelatoriousuarioview].[pNomeFormArgumento], [vapprelatorioapprelatoriousuarioview].[pNomeRelatorio], [vapprelatorioapprelatoriousuarioview].[pNomeRdlc], [vapprelatorioapprelatoriousuarioview].[pNomeDataSet], [vapprelatorioapprelatoriousuarioview].[sCategoria], [vapprelatorioapprelatoriousuarioview].[pTituloRelatorio], [vapprelatorioapprelatoriousuarioview].[pSequencia], [vapprelatorioapprelatoriousuarioview].[pCategoriaRelatorio], [vapprelatorioapprelatoriousuarioview].[pUsuarioLogin], [vapprelatorioapprelatoriousuarioview].[_trackCreationTime], [vapprelatorioapprelatoriousuarioview].[_trackLastWriteTime], [vapprelatorioapprelatoriousuarioview].[_trackCreationUser], [vapprelatorioapprelatoriousuarioview].[_trackLastWriteUser] 
    FROM [vapprelatorioapprelatoriousuarioview] 
    WHERE (([vapprelatorioapprelatoriousuarioview].[pUsuarioLogin] = @parLogin) AND ([vapprelatorioapprelatoriousuarioview].[pCategoriaRelatorio] = @parCategoriaRelatorio))

RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_LoadByUsuarioView]
(
 @parLogin [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vapprelatorioapprelatoriousuarioview].[pId], [vapprelatorioapprelatoriousuarioview].[pNomeFormArgumento], [vapprelatorioapprelatoriousuarioview].[pNomeRelatorio], [vapprelatorioapprelatoriousuarioview].[pNomeRdlc], [vapprelatorioapprelatoriousuarioview].[pNomeDataSet], [vapprelatorioapprelatoriousuarioview].[sCategoria], [vapprelatorioapprelatoriousuarioview].[pTituloRelatorio], [vapprelatorioapprelatoriousuarioview].[pSequencia], [vapprelatorioapprelatoriousuarioview].[pCategoriaRelatorio], [vapprelatorioapprelatoriousuarioview].[pUsuarioLogin], [vapprelatorioapprelatoriousuarioview].[_trackCreationTime], [vapprelatorioapprelatoriousuarioview].[_trackLastWriteTime], [vapprelatorioapprelatoriousuarioview].[_trackCreationUser], [vapprelatorioapprelatoriousuarioview].[_trackLastWriteUser] 
    FROM [vapprelatorioapprelatoriousuarioview] 
    WHERE ([vapprelatorioapprelatoriousuarioview].[pUsuarioLogin] = @parLogin)

RETURN
GO

CREATE PROCEDURE [dbo].[apprelatorio_LoadoAppRelatoriosoUsuariosByUsuario]
(
 @UsuariopId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [apprelatorio].[pId], [apprelatorio].[pNomeFormArgumento], [apprelatorio].[pNomeRelatorio], [apprelatorio].[pNomeRdlc], [apprelatorio].[pNomeDataSet], [apprelatorio].[sCategoria], [apprelatorio].[pTituloRelatorio], [apprelatorio].[pSequencia], [apprelatorio].[pCategoriaRelatorio], [apprelatorio].[_trackLastWriteTime], [apprelatorio].[_trackCreationTime], [apprelatorio].[_trackLastWriteUser], [apprelatorio].[_trackCreationUser] 
    FROM [apprelatorio]
        LEFT OUTER JOIN [apprelatorio_oUsuarios_usuario_oAppRelatorios] ON ([apprelatorio].[pId] = [apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId])
                LEFT OUTER JOIN [usuario] ON ([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId2] = [usuario].[pId]) 
    WHERE ([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId2] = @UsuariopId)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro] 
    WHERE ([cadastro].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro] 

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadByEmpresaFlgCadastroViewGeralTipo]
(
 @parCodEmpresa [int],
 @parFlgCadastro [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vcadastrocadastroviewgeraltipo].[pId], [vcadastrocadastroviewgeraltipo].[pNome], [vcadastrocadastroviewgeraltipo].[pCodigo], [vcadastrocadastroviewgeraltipo].[pPFPJ], [vcadastrocadastroviewgeraltipo].[pEndereco], [vcadastrocadastroviewgeraltipo].[pEnderLogradouro], [vcadastrocadastroviewgeraltipo].[pEnderComplemento], [vcadastrocadastroviewgeraltipo].[pEnderBairro], [vcadastrocadastroviewgeraltipo].[pEnderNumero], [vcadastrocadastroviewgeraltipo].[pEnderAuxLogradouro], [vcadastrocadastroviewgeraltipo].[pEnderAuxNumero], [vcadastrocadastroviewgeraltipo].[pEnderAuxBairro], [vcadastrocadastroviewgeraltipo].[pEnderAuxComplemento], [vcadastrocadastroviewgeraltipo].[pEnderecoAux], [vcadastrocadastroviewgeraltipo].[pEmail], [vcadastrocadastroviewgeraltipo].[pCpfCnpj], [vcadastrocadastroviewgeraltipo].[pDataNascimento], [vcadastrocadastroviewgeraltipo].[pRgIe], [vcadastrocadastroviewgeraltipo].[pNomeFantasia], [vcadastrocadastroviewgeraltipo].[pFlgSexo], [vcadastrocadastroviewgeraltipo].[pDataCadastro], [vcadastrocadastroviewgeraltipo].[pDataBaixa], [vcadastrocadastroviewgeraltipo].[pTelefone], [vcadastrocadastroviewgeraltipo].[pTelefoneAux], [vcadastrocadastroviewgeraltipo].[pCelular], [vcadastrocadastroviewgeraltipo].[pCodigoCidade], [vcadastrocadastroviewgeraltipo].[pNomeCidade], [vcadastrocadastroviewgeraltipo].[pUFCidade], [vcadastrocadastroviewgeraltipo].[pCodigoCidadeAux], [vcadastrocadastroviewgeraltipo].[pNomeCidadeaux], [vcadastrocadastroviewgeraltipo].[pUFCidadeAux], [vcadastrocadastroviewgeraltipo].[pCodigoEmpresa], [vcadastrocadastroviewgeraltipo].[pNomeEmpresa], [vcadastrocadastroviewgeraltipo].[pCadastroTipoFlgTipo], [vcadastrocadastroviewgeraltipo].[pCadastroTipoDescricao], [vcadastrocadastroviewgeraltipo].[_trackCreationTime], [vcadastrocadastroviewgeraltipo].[_trackLastWriteTime], [vcadastrocadastroviewgeraltipo].[_trackCreationUser], [vcadastrocadastroviewgeraltipo].[_trackLastWriteUser] 
    FROM [vcadastrocadastroviewgeraltipo] 
    WHERE (([vcadastrocadastroviewgeraltipo].[pCodigoEmpresa] = @parCodEmpresa) AND ([vcadastrocadastroviewgeraltipo].[pCadastroTipoFlgTipo] = @parFlgCadastro))

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadByEmpresaViewGeral]
(
 @parCodEmpresa [int],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vcadastrocadastroviewgeral].[pId], [vcadastrocadastroviewgeral].[pNome], [vcadastrocadastroviewgeral].[pCodigo], [vcadastrocadastroviewgeral].[pPFPJ], [vcadastrocadastroviewgeral].[pEndereco], [vcadastrocadastroviewgeral].[pEnderLogradouro], [vcadastrocadastroviewgeral].[pEnderComplemento], [vcadastrocadastroviewgeral].[pEnderBairro], [vcadastrocadastroviewgeral].[pEnderNumero], [vcadastrocadastroviewgeral].[pEnderAuxLogradouro], [vcadastrocadastroviewgeral].[pEnderAuxNumero], [vcadastrocadastroviewgeral].[pEnderAuxBairro], [vcadastrocadastroviewgeral].[pEnderAuxComplemento], [vcadastrocadastroviewgeral].[pEnderecoAux], [vcadastrocadastroviewgeral].[pEmail], [vcadastrocadastroviewgeral].[pCpfCnpj], [vcadastrocadastroviewgeral].[pDataNascimento], [vcadastrocadastroviewgeral].[pRgIe], [vcadastrocadastroviewgeral].[pNomeFantasia], [vcadastrocadastroviewgeral].[pFlgSexo], [vcadastrocadastroviewgeral].[pDataCadastro], [vcadastrocadastroviewgeral].[pDataBaixa], [vcadastrocadastroviewgeral].[pTelefone], [vcadastrocadastroviewgeral].[pTelefoneAux], [vcadastrocadastroviewgeral].[pCelular], [vcadastrocadastroviewgeral].[pCodigoCidade], [vcadastrocadastroviewgeral].[pNomeCidade], [vcadastrocadastroviewgeral].[pUFCidade], [vcadastrocadastroviewgeral].[pCodigoCidadeAux], [vcadastrocadastroviewgeral].[pNomeCidadeaux], [vcadastrocadastroviewgeral].[pUFCidadeAux], [vcadastrocadastroviewgeral].[pCodigoEmpresa], [vcadastrocadastroviewgeral].[pNomeEmpresa], [vcadastrocadastroviewgeral].[_trackCreationTime], [vcadastrocadastroviewgeral].[_trackLastWriteTime], [vcadastrocadastroviewgeral].[_trackCreationUser], [vcadastrocadastroviewgeral].[_trackLastWriteUser] 
    FROM [vcadastrocadastroviewgeral] 
    WHERE ([vcadastrocadastroviewgeral].[pCodigoEmpresa] = @parCodEmpresa)
    ORDER BY [vcadastrocadastroviewgeral].[pNomeFantasia] ASC

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadByNomeFlgCadastroViewGeral]
(
 @parNome [nvarchar] (256),
 @parFlgCadastro [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vcadastrocadastroviewgeraltipo].[pId], [vcadastrocadastroviewgeraltipo].[pNome], [vcadastrocadastroviewgeraltipo].[pCodigo], [vcadastrocadastroviewgeraltipo].[pPFPJ], [vcadastrocadastroviewgeraltipo].[pEndereco], [vcadastrocadastroviewgeraltipo].[pEnderLogradouro], [vcadastrocadastroviewgeraltipo].[pEnderComplemento], [vcadastrocadastroviewgeraltipo].[pEnderBairro], [vcadastrocadastroviewgeraltipo].[pEnderNumero], [vcadastrocadastroviewgeraltipo].[pEnderAuxLogradouro], [vcadastrocadastroviewgeraltipo].[pEnderAuxNumero], [vcadastrocadastroviewgeraltipo].[pEnderAuxBairro], [vcadastrocadastroviewgeraltipo].[pEnderAuxComplemento], [vcadastrocadastroviewgeraltipo].[pEnderecoAux], [vcadastrocadastroviewgeraltipo].[pEmail], [vcadastrocadastroviewgeraltipo].[pCpfCnpj], [vcadastrocadastroviewgeraltipo].[pDataNascimento], [vcadastrocadastroviewgeraltipo].[pRgIe], [vcadastrocadastroviewgeraltipo].[pNomeFantasia], [vcadastrocadastroviewgeraltipo].[pFlgSexo], [vcadastrocadastroviewgeraltipo].[pDataCadastro], [vcadastrocadastroviewgeraltipo].[pDataBaixa], [vcadastrocadastroviewgeraltipo].[pTelefone], [vcadastrocadastroviewgeraltipo].[pTelefoneAux], [vcadastrocadastroviewgeraltipo].[pCelular], [vcadastrocadastroviewgeraltipo].[pCodigoCidade], [vcadastrocadastroviewgeraltipo].[pNomeCidade], [vcadastrocadastroviewgeraltipo].[pUFCidade], [vcadastrocadastroviewgeraltipo].[pCodigoCidadeAux], [vcadastrocadastroviewgeraltipo].[pNomeCidadeaux], [vcadastrocadastroviewgeraltipo].[pUFCidadeAux], [vcadastrocadastroviewgeraltipo].[pCodigoEmpresa], [vcadastrocadastroviewgeraltipo].[pNomeEmpresa], [vcadastrocadastroviewgeraltipo].[pCadastroTipoFlgTipo], [vcadastrocadastroviewgeraltipo].[pCadastroTipoDescricao], [vcadastrocadastroviewgeraltipo].[_trackCreationTime], [vcadastrocadastroviewgeraltipo].[_trackLastWriteTime], [vcadastrocadastroviewgeraltipo].[_trackCreationUser], [vcadastrocadastroviewgeraltipo].[_trackLastWriteUser] 
    FROM [vcadastrocadastroviewgeraltipo] 
    WHERE (([vcadastrocadastroviewgeraltipo].[pNome] LIKE @parNome) AND ([vcadastrocadastroviewgeraltipo].[pCadastroTipoFlgTipo] = @parFlgCadastro))

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadByNomeViewGeral]
(
 @parNome [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vcadastrocadastroviewgeral].[pId], [vcadastrocadastroviewgeral].[pNome], [vcadastrocadastroviewgeral].[pCodigo], [vcadastrocadastroviewgeral].[pPFPJ], [vcadastrocadastroviewgeral].[pEndereco], [vcadastrocadastroviewgeral].[pEnderLogradouro], [vcadastrocadastroviewgeral].[pEnderComplemento], [vcadastrocadastroviewgeral].[pEnderBairro], [vcadastrocadastroviewgeral].[pEnderNumero], [vcadastrocadastroviewgeral].[pEnderAuxLogradouro], [vcadastrocadastroviewgeral].[pEnderAuxNumero], [vcadastrocadastroviewgeral].[pEnderAuxBairro], [vcadastrocadastroviewgeral].[pEnderAuxComplemento], [vcadastrocadastroviewgeral].[pEnderecoAux], [vcadastrocadastroviewgeral].[pEmail], [vcadastrocadastroviewgeral].[pCpfCnpj], [vcadastrocadastroviewgeral].[pDataNascimento], [vcadastrocadastroviewgeral].[pRgIe], [vcadastrocadastroviewgeral].[pNomeFantasia], [vcadastrocadastroviewgeral].[pFlgSexo], [vcadastrocadastroviewgeral].[pDataCadastro], [vcadastrocadastroviewgeral].[pDataBaixa], [vcadastrocadastroviewgeral].[pTelefone], [vcadastrocadastroviewgeral].[pTelefoneAux], [vcadastrocadastroviewgeral].[pCelular], [vcadastrocadastroviewgeral].[pCodigoCidade], [vcadastrocadastroviewgeral].[pNomeCidade], [vcadastrocadastroviewgeral].[pUFCidade], [vcadastrocadastroviewgeral].[pCodigoCidadeAux], [vcadastrocadastroviewgeral].[pNomeCidadeaux], [vcadastrocadastroviewgeral].[pUFCidadeAux], [vcadastrocadastroviewgeral].[pCodigoEmpresa], [vcadastrocadastroviewgeral].[pNomeEmpresa], [vcadastrocadastroviewgeral].[_trackCreationTime], [vcadastrocadastroviewgeral].[_trackLastWriteTime], [vcadastrocadastroviewgeral].[_trackCreationUser], [vcadastrocadastroviewgeral].[_trackLastWriteUser] 
    FROM [vcadastrocadastroviewgeral] 
    WHERE ([vcadastrocadastroviewgeral].[pNome] LIKE @parNome)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadByoCadastroFilial]
(
 @oCadastroFilialpId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro] 
    WHERE ([cadastro].[oCadastroFilial_pId] = @oCadastroFilialpId)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadByoCidade]
(
 @oCidadepId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro] 
    WHERE ([cadastro].[oCidade_pId] = @oCidadepId)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadByoCidadeAux]
(
 @oCidadeAuxpId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro] 
    WHERE ([cadastro].[oCidadeAux_pId] = @oCidadeAuxpId)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadByoUsuario]
(
 @oUsuariopId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro] 
    WHERE ([cadastro].[oUsuario_pId] = @oUsuariopId)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadByParametros]
(
 @parcodigo [int] = NULL,
 @parnome [nvarchar] (256) = NULL,
 @parfj [nvarchar] (256) = NULL,
 @parcpfcnpj [nvarchar] (256) = NULL,
 @parnomecidade [nvarchar] (256) = NULL,
 @parufcidade [nvarchar] (256) = NULL,
 @parflgcadastro [nvarchar] (256) = NULL
)
AS
SET NOCOUNT ON
SET ANSI_WARNINGS OFF

  DECLARE @query NVARCHAR(2000)
  DECLARE @where NVARCHAR(2000)


  SET @query = 'SELECT pId'
  SET @query = @query + ' ,max(pNome) pNome'
  SET @query = @query + ' ,max(pCodigo) pCodigo'
  SET @query = @query + ' ,max(pPFPJ) pPFPJ'
  SET @query = @query + ' ,max(pEndereco) pEndereco'
  SET @query = @query + ' ,max(pEnderLogradouro) pEnderLogradouro'
  SET @query = @query + ' ,max(pEnderComplemento) pEnderComplemento'
  SET @query = @query + ' ,max(pEnderBairro) pEnderBairro'
  SET @query = @query + ' ,max(pEnderNumero) pEnderNumero'
  SET @query = @query + ' ,max(pEnderAuxLogradouro) pEnderAuxLogradouro'
  SET @query = @query + ' ,max(pEnderAuxNumero) pEnderAuxNumero'
  SET @query = @query + ' ,max(pEnderAuxBairro) pEnderAuxBairro'
  SET @query = @query + ' ,max(pEnderAuxComplemento) pEnderAuxComplemento'
  SET @query = @query + ' ,max(pEnderecoAux) pEnderecoAux'
  SET @query = @query + ' ,max(pEmail) pEmail'
  SET @query = @query + ' ,max(pCpfCnpj) pCpfCnpj'
  SET @query = @query + ' ,max(pDataNascimento) pDataNascimento'
  SET @query = @query + ' ,max(pRgIe) pRgIe'
  SET @query = @query + ' ,max(pNomeFantasia) pNomeFantasia'
  SET @query = @query + ' ,max(pFlgSexo) pFlgSexo'
  SET @query = @query + ' ,max(pDataCadastro) pDataCadastro'
  SET @query = @query + ' ,max(pDataBaixa) pDataBaixa'
  SET @query = @query + ' ,max(pTelefone) pTelefone'
  SET @query = @query + ' ,max(pTelefoneAux) pTelefoneAux'
  SET @query = @query + ' ,max(pCelular) pCelular'
  SET @query = @query + ' ,max(pCodigoCidade) pCodigoCidade'
  SET @query = @query + ' ,max(pNomeCidade) pNomeCidade'
  SET @query = @query + ' ,max(pUFCidade) pUFCidade'
  SET @query = @query + ' ,max(pCodigoCidadeAux) pCodigoCidadeAux'
  SET @query = @query + ' ,max(pNomeCidadeaux) pNomeCidadeaux'
  SET @query = @query + ' ,max(pUFCidadeAux) pUFCidadeAux'
  SET @query = @query + ' ,max(pCodigoEmpresa) pCodigoEmpresa'
  SET @query = @query + ' ,max(pNomeEmpresa) pNomeEmpresa'
  SET @query = @query + ' ,reverse(stuff(reverse(max(FlgTipo)), 1, 1, ' + char(39) + char(39) + ')) pCadastroTipoFlgTipo'
  SET @query = @query + ' ,reverse(stuff(reverse(max(Descricao)), 1, 1, ' + char(39) + char(39) + ')) pCadastroTipoDescricao'
  SET @query = @query + ' FROM'
  SET @query = @query + '  vcadastrocadastroviewgeraltipo cadview0'
  SET @query = @query + '  CROSS APPLY ('
  SET @query = @query + ' SELECT cadview1.pCadastroTipoFlgTipo + ' + char(39) + ',' + char(39)
  SET @query = @query + ' FROM'
  SET @query = @query + '  vcadastrocadastroviewgeraltipo cadview1'
  SET @query = @query + ' WHERE'
  SET @query = @query + '  cadview1.pid = cadview0.pid'
  SET @query = @query + ' FOR XML'
  SET @query = @query + '  PATH (' + char(39) + char(39) + ')) a1 (FlgTipo)'
  SET @query = @query + '  CROSS APPLY ('
  SET @query = @query + ' SELECT cadview1.pCadastroTipoDescricao + ' + char(39) + ',' + char(39)
  SET @query = @query + ' FROM'
  SET @query = @query + ' vcadastrocadastroviewgeraltipo cadview1'
  SET @query = @query + ' WHERE'
  SET @query = @query + '  cadview1.pid = cadview0.pid'
  SET @query = @query + ' FOR XML'
  SET @query = @query + '  PATH (' + char(39) + char(39) + ')) a2 (Descricao)'


  SET @where = ' where 0=0';

  IF (@parcodigo <> 0) AND (@parcodigo IS NOT NULL)
    SET @where = concat(@where, concat(' and pCodigo = ', @parcodigo))

  IF (@parnome <> '') AND (@parnome IS NOT NULL)
    SET @where = concat(@where, concat(' and pNome like ', char(39) + @parnome + char(39)))


  IF (@parfj <> '') AND (@parfj IS NOT NULL)
    SET @where = concat(@where, concat(' and pPFPJ = ', char(39) + @parfj + char(39)))

  IF (@parcpfcnpj <> '') AND (@parcpfcnpj IS NOT NULL)
    SET @where = concat(@where, concat(' and pCpfCnpj like ', char(39) + @parcpfcnpj + char(39)))

  IF (@parnomecidade <> '') AND (@parnomecidade IS NOT NULL)
    SET @where = concat(@where, concat(' and pNomeCidade like ', char(39) + @parnomecidade + char(39)))

  IF (@parufcidade <> '') AND (@parufcidade IS NOT NULL)
    SET @where = concat(@where, concat(' and pUfCidade like ', char(39) + @parufcidade + char(39)))

  IF (@parflgcadastro <> '') AND (@parflgcadastro IS NOT NULL)
    SET @where = concat(@where, concat(' and pCadastroTipoFlgTipo like ', char(39) + @parflgcadastro + char(39)))

  SET @query = @query + @where

  SET @query = @query + ' GROUP BY pId'
  EXECUTE (@query)
RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadBypCodigo]
(
 @pCodigo [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro] 
    WHERE ([cadastro].[pCodigo] = @pCodigo)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadBypCpfCnpj]
(
 @parCpfCnpj [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro] 
    WHERE ([cadastro].[pCpfCnpj] = @parCpfCnpj)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadMaxCodigo]

AS
SET NOCOUNT ON
SELECT DISTINCT TOP 1 [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro] 
    ORDER BY [cadastro].[pCodigo] DESC

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadoCadastrosoCadastrosTipoByCadastroTipo]
(
 @CadastroTipopId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro]
        LEFT OUTER JOIN [cadastro_ocadastrostipo_cadastrotipo_ocadastros] ON ([cadastro].[pId] = [cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId])
                LEFT OUTER JOIN [cadastrotipo] ON ([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId2] = [cadastrotipo].[pId]) 
    WHERE ([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId2] = @CadastroTipopId)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastro_LoadoCadastrosoEmpresasByEmpresa]
(
 @EmpresapId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteUser], [cadastro].[_trackCreationUser] 
    FROM [cadastro]
        LEFT OUTER JOIN [cadastro_oempresas_empresa_ocadastros] ON ([cadastro].[pId] = [cadastro_oempresas_empresa_ocadastros].[pId])
                LEFT OUTER JOIN [empresa] ON ([cadastro_oempresas_empresa_ocadastros].[pId2] = [empresa].[pId]) 
    WHERE ([cadastro_oempresas_empresa_ocadastros].[pId2] = @EmpresapId)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastrotipo_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastrotipo].[pId], [cadastrotipo].[pDescricao], [cadastrotipo].[pFlgCadastro], [cadastrotipo].[xDataHoraReg], [cadastrotipo].[xLoginReg], [cadastrotipo].[_trackLastWriteTime], [cadastrotipo].[_trackCreationTime], [cadastrotipo].[_trackLastWriteUser], [cadastrotipo].[_trackCreationUser] 
    FROM [cadastrotipo] 
    WHERE ([cadastrotipo].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastrotipo_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastrotipo].[pId], [cadastrotipo].[pDescricao], [cadastrotipo].[pFlgCadastro], [cadastrotipo].[xDataHoraReg], [cadastrotipo].[xLoginReg], [cadastrotipo].[_trackLastWriteTime], [cadastrotipo].[_trackCreationTime], [cadastrotipo].[_trackLastWriteUser], [cadastrotipo].[_trackCreationUser] 
    FROM [cadastrotipo] 

RETURN
GO

CREATE PROCEDURE [dbo].[cadastrotipo_LoadAllViewGrid]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vcadastrotipocadastrotipoviewgrid].[pId], [vcadastrotipocadastrotipoviewgrid].[pDescricao], [vcadastrotipocadastrotipoviewgrid].[pFlgCadastro], [vcadastrotipocadastrotipoviewgrid].[_trackCreationTime], [vcadastrotipocadastrotipoviewgrid].[_trackLastWriteTime], [vcadastrotipocadastrotipoviewgrid].[_trackCreationUser], [vcadastrotipocadastrotipoviewgrid].[_trackLastWriteUser] 
    FROM [vcadastrotipocadastrotipoviewgrid] 
    ORDER BY [vcadastrotipocadastrotipoviewgrid].[pDescricao] ASC

RETURN
GO

CREATE PROCEDURE [dbo].[cadastrotipo_LoadByFlgCadastro]
(
 @parFlgCadastro [nvarchar] (256)
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastrotipo].[pId], [cadastrotipo].[pDescricao], [cadastrotipo].[pFlgCadastro], [cadastrotipo].[xDataHoraReg], [cadastrotipo].[xLoginReg], [cadastrotipo].[_trackLastWriteTime], [cadastrotipo].[_trackCreationTime], [cadastrotipo].[_trackLastWriteUser], [cadastrotipo].[_trackCreationUser] 
    FROM [cadastrotipo] 
    WHERE ([cadastrotipo].[pFlgCadastro] = @parFlgCadastro)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastrotipo_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastrotipo].[pId], [cadastrotipo].[pDescricao], [cadastrotipo].[pFlgCadastro], [cadastrotipo].[xDataHoraReg], [cadastrotipo].[xLoginReg], [cadastrotipo].[_trackLastWriteTime], [cadastrotipo].[_trackCreationTime], [cadastrotipo].[_trackLastWriteUser], [cadastrotipo].[_trackCreationUser] 
    FROM [cadastrotipo] 
    WHERE ([cadastrotipo].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[cadastrotipo_LoadoCadastrosTipooCadastrosByCadastro]
(
 @CadastropId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cadastrotipo].[pId], [cadastrotipo].[pDescricao], [cadastrotipo].[pFlgCadastro], [cadastrotipo].[xDataHoraReg], [cadastrotipo].[xLoginReg], [cadastrotipo].[_trackLastWriteTime], [cadastrotipo].[_trackCreationTime], [cadastrotipo].[_trackLastWriteUser], [cadastrotipo].[_trackCreationUser] 
    FROM [cadastrotipo]
        LEFT OUTER JOIN [cadastro_ocadastrostipo_cadastrotipo_ocadastros] ON ([cadastrotipo].[pId] = [cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId2])
                LEFT OUTER JOIN [cadastro] ON ([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId] = [cadastro].[pId]) 
    WHERE ([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId] = @CadastropId)

RETURN
GO

CREATE PROCEDURE [dbo].[CERTIFICADO_PATIO_HORA_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [CERTIFICADO_PATIO_HORA].[pId], [CERTIFICADO_PATIO_HORA].[ID_NEGOCIOS], [CERTIFICADO_PATIO_HORA].[DIA], [CERTIFICADO_PATIO_HORA].[HORA], [CERTIFICADO_PATIO_HORA].[FRENTE], [CERTIFICADO_PATIO_HORA].[CERTIFICADOS], [CERTIFICADO_PATIO_HORA].[CERT_VAZIO], [CERTIFICADO_PATIO_HORA].[_trackLastWriteTime], [CERTIFICADO_PATIO_HORA].[_trackCreationTime], [CERTIFICADO_PATIO_HORA].[_trackLastWriteUser], [CERTIFICADO_PATIO_HORA].[_trackCreationUser] 
    FROM [CERTIFICADO_PATIO_HORA] 
    WHERE ([CERTIFICADO_PATIO_HORA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[CERTIFICADO_PATIO_HORA_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [CERTIFICADO_PATIO_HORA].[pId], [CERTIFICADO_PATIO_HORA].[ID_NEGOCIOS], [CERTIFICADO_PATIO_HORA].[DIA], [CERTIFICADO_PATIO_HORA].[HORA], [CERTIFICADO_PATIO_HORA].[FRENTE], [CERTIFICADO_PATIO_HORA].[CERTIFICADOS], [CERTIFICADO_PATIO_HORA].[CERT_VAZIO], [CERTIFICADO_PATIO_HORA].[_trackLastWriteTime], [CERTIFICADO_PATIO_HORA].[_trackCreationTime], [CERTIFICADO_PATIO_HORA].[_trackLastWriteUser], [CERTIFICADO_PATIO_HORA].[_trackCreationUser] 
    FROM [CERTIFICADO_PATIO_HORA] 

RETURN
GO

CREATE PROCEDURE [dbo].[CERTIFICADO_PATIO_HORA_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [CERTIFICADO_PATIO_HORA].[pId], [CERTIFICADO_PATIO_HORA].[ID_NEGOCIOS], [CERTIFICADO_PATIO_HORA].[DIA], [CERTIFICADO_PATIO_HORA].[HORA], [CERTIFICADO_PATIO_HORA].[FRENTE], [CERTIFICADO_PATIO_HORA].[CERTIFICADOS], [CERTIFICADO_PATIO_HORA].[CERT_VAZIO], [CERTIFICADO_PATIO_HORA].[_trackLastWriteTime], [CERTIFICADO_PATIO_HORA].[_trackCreationTime], [CERTIFICADO_PATIO_HORA].[_trackLastWriteUser], [CERTIFICADO_PATIO_HORA].[_trackCreationUser] 
    FROM [CERTIFICADO_PATIO_HORA] 
    WHERE ([CERTIFICADO_PATIO_HORA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[cidade_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cidade].[pId], [cidade].[pNome], [cidade].[pCodigo], [cidade].[pCodigoIbge], [cidade].[oUF_pId], [cidade].[xDataHoraReg], [cidade].[xLoginReg], [cidade].[_trackLastWriteTime], [cidade].[_trackCreationTime], [cidade].[_trackLastWriteUser], [cidade].[_trackCreationUser] 
    FROM [cidade] 
    WHERE ([cidade].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[cidade_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cidade].[pId], [cidade].[pNome], [cidade].[pCodigo], [cidade].[pCodigoIbge], [cidade].[oUF_pId], [cidade].[xDataHoraReg], [cidade].[xLoginReg], [cidade].[_trackLastWriteTime], [cidade].[_trackCreationTime], [cidade].[_trackLastWriteUser], [cidade].[_trackCreationUser] 
    FROM [cidade] 

RETURN
GO

CREATE PROCEDURE [dbo].[cidade_LoadAllViewGrid]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vcidadecidadeviewgrid].[pId], [vcidadecidadeviewgrid].[pNome], [vcidadecidadeviewgrid].[pCodigo], [vcidadecidadeviewgrid].[pCodigoIbge], [vcidadecidadeviewgrid].[UF], [vcidadecidadeviewgrid].[Sigla], [vcidadecidadeviewgrid].[_trackCreationTime], [vcidadecidadeviewgrid].[_trackLastWriteTime], [vcidadecidadeviewgrid].[_trackCreationUser], [vcidadecidadeviewgrid].[_trackLastWriteUser] 
    FROM [vcidadecidadeviewgrid] 
    ORDER BY [vcidadecidadeviewgrid].[pNome] ASC

RETURN
GO

CREATE PROCEDURE [dbo].[cidade_LoadByFilterCodigoNome]
(
 @filter [nvarchar] (256),
 @startIndex [bigint],
 @endIndex [bigint]
)
AS
SET NOCOUNT ON
SELECT st.pId
       , st.pCodigo
       , st.pNome
       , st.pSigla Sigla
	   , right('0000' + ltrim(str(st.pCodigo)), 4) pCodigoStr
  FROM
    (SELECT t.pId
          , t.pCodigo
          , t.pNome
          , uf.pSigla
          , row_number() OVER (ORDER BY t.pNome) AS rn
     FROM
       cidade AS t
       LEFT OUTER JOIN uf
         ON t.oUF_pId = uf.pId
     WHERE
        ((right('0000' + ltrim(str(t.pCodigo)), 4) + ' ' + t.pNome) LIKE @filter)) AS st
  WHERE
    st.rn BETWEEN @startIndex AND @endIndex
RETURN
GO

CREATE PROCEDURE [dbo].[cidade_LoadByNomeViewGrid]
(
 @parNomeCidade [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vcidadecidadeviewgrid].[pId], [vcidadecidadeviewgrid].[pNome], [vcidadecidadeviewgrid].[pCodigo], [vcidadecidadeviewgrid].[pCodigoIbge], [vcidadecidadeviewgrid].[UF], [vcidadecidadeviewgrid].[Sigla], [vcidadecidadeviewgrid].[_trackCreationTime], [vcidadecidadeviewgrid].[_trackLastWriteTime], [vcidadecidadeviewgrid].[_trackCreationUser], [vcidadecidadeviewgrid].[_trackLastWriteUser] 
    FROM [vcidadecidadeviewgrid] 
    WHERE ([vcidadecidadeviewgrid].[pNome] LIKE @parNomeCidade)

RETURN
GO

CREATE PROCEDURE [dbo].[cidade_LoadByoUF]
(
 @oUFpId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cidade].[pId], [cidade].[pNome], [cidade].[pCodigo], [cidade].[pCodigoIbge], [cidade].[oUF_pId], [cidade].[xDataHoraReg], [cidade].[xLoginReg], [cidade].[_trackLastWriteTime], [cidade].[_trackCreationTime], [cidade].[_trackLastWriteUser], [cidade].[_trackCreationUser] 
    FROM [cidade] 
    WHERE ([cidade].[oUF_pId] = @oUFpId)

RETURN
GO

CREATE PROCEDURE [dbo].[cidade_LoadBypCodigo]
(
 @pCodigo [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [cidade].[pId], [cidade].[pNome], [cidade].[pCodigo], [cidade].[pCodigoIbge], [cidade].[oUF_pId], [cidade].[xDataHoraReg], [cidade].[xLoginReg], [cidade].[_trackLastWriteTime], [cidade].[_trackCreationTime], [cidade].[_trackLastWriteUser], [cidade].[_trackCreationUser] 
    FROM [cidade] 
    WHERE ([cidade].[pCodigo] = @pCodigo)

RETURN
GO

CREATE PROCEDURE [dbo].[cidade_LoadMaxCodigo]

AS
SET NOCOUNT ON
SELECT DISTINCT TOP 1 [cidade].[pId], [cidade].[pNome], [cidade].[pCodigo], [cidade].[pCodigoIbge], [cidade].[oUF_pId], [cidade].[xDataHoraReg], [cidade].[xLoginReg], [cidade].[_trackLastWriteTime], [cidade].[_trackCreationTime], [cidade].[_trackLastWriteUser], [cidade].[_trackCreationUser] 
    FROM [cidade] 
    ORDER BY [cidade].[pCodigo] DESC

RETURN
GO

CREATE PROCEDURE [dbo].[empresa_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [empresa].[pId], [empresa].[pCodigo], [empresa].[pNome], [empresa].[xDataHoraReg], [empresa].[xLoginReg], [empresa].[pSimplesNacionalValorAliquotaCreditoICMS], [empresa].[sSimplesNacionalCategoria], [empresa].[sCodigoRegimeTributario], [empresa].[sCodigoRegimeTributarioNormal], [empresa].[_trackLastWriteTime], [empresa].[_trackCreationTime], [empresa].[_trackLastWriteUser], [empresa].[_trackCreationUser] 
    FROM [empresa] 
    WHERE ([empresa].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[empresa_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [empresa].[pId], [empresa].[pCodigo], [empresa].[pNome], [empresa].[xDataHoraReg], [empresa].[xLoginReg], [empresa].[pSimplesNacionalValorAliquotaCreditoICMS], [empresa].[sSimplesNacionalCategoria], [empresa].[sCodigoRegimeTributario], [empresa].[sCodigoRegimeTributarioNormal], [empresa].[_trackLastWriteTime], [empresa].[_trackCreationTime], [empresa].[_trackLastWriteUser], [empresa].[_trackCreationUser] 
    FROM [empresa] 

RETURN
GO

CREATE PROCEDURE [dbo].[empresa_LoadByNome]
(
 @parNome [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [empresa].[pId], [empresa].[pCodigo], [empresa].[pNome], [empresa].[xDataHoraReg], [empresa].[xLoginReg], [empresa].[pSimplesNacionalValorAliquotaCreditoICMS], [empresa].[sSimplesNacionalCategoria], [empresa].[sCodigoRegimeTributario], [empresa].[sCodigoRegimeTributarioNormal], [empresa].[_trackLastWriteTime], [empresa].[_trackCreationTime], [empresa].[_trackLastWriteUser], [empresa].[_trackCreationUser] 
    FROM [empresa] 
    WHERE ([empresa].[pNome] LIKE @parNome)

RETURN
GO

CREATE PROCEDURE [dbo].[empresa_LoadBypCodigo]
(
 @pCodigo [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [empresa].[pId], [empresa].[pCodigo], [empresa].[pNome], [empresa].[xDataHoraReg], [empresa].[xLoginReg], [empresa].[pSimplesNacionalValorAliquotaCreditoICMS], [empresa].[sSimplesNacionalCategoria], [empresa].[sCodigoRegimeTributario], [empresa].[sCodigoRegimeTributarioNormal], [empresa].[_trackLastWriteTime], [empresa].[_trackCreationTime], [empresa].[_trackLastWriteUser], [empresa].[_trackCreationUser] 
    FROM [empresa] 
    WHERE ([empresa].[pCodigo] = @pCodigo)

RETURN
GO

CREATE PROCEDURE [dbo].[empresa_LoadoEmpresasoCadastrosByCadastro]
(
 @CadastropId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [empresa].[pId], [empresa].[pCodigo], [empresa].[pNome], [empresa].[xDataHoraReg], [empresa].[xLoginReg], [empresa].[pSimplesNacionalValorAliquotaCreditoICMS], [empresa].[sSimplesNacionalCategoria], [empresa].[sCodigoRegimeTributario], [empresa].[sCodigoRegimeTributarioNormal], [empresa].[_trackLastWriteTime], [empresa].[_trackCreationTime], [empresa].[_trackLastWriteUser], [empresa].[_trackCreationUser] 
    FROM [empresa]
        LEFT OUTER JOIN [cadastro_oempresas_empresa_ocadastros] ON ([empresa].[pId] = [cadastro_oempresas_empresa_ocadastros].[pId2])
                LEFT OUTER JOIN [cadastro] ON ([cadastro_oempresas_empresa_ocadastros].[pId] = [cadastro].[pId]) 
    WHERE ([cadastro_oempresas_empresa_ocadastros].[pId] = @CadastropId)

RETURN
GO

CREATE PROCEDURE [dbo].[empresa_LoadoEmpresasoSistemasBySistema]
(
 @SistemapId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [empresa].[pId], [empresa].[pCodigo], [empresa].[pNome], [empresa].[xDataHoraReg], [empresa].[xLoginReg], [empresa].[pSimplesNacionalValorAliquotaCreditoICMS], [empresa].[sSimplesNacionalCategoria], [empresa].[sCodigoRegimeTributario], [empresa].[sCodigoRegimeTributarioNormal], [empresa].[_trackLastWriteTime], [empresa].[_trackCreationTime], [empresa].[_trackLastWriteUser], [empresa].[_trackCreationUser] 
    FROM [empresa]
        LEFT OUTER JOIN [empresa_osistemas_sistema_oempresas] ON ([empresa].[pId] = [empresa_osistemas_sistema_oempresas].[pId])
                LEFT OUTER JOIN [sistema] ON ([empresa_osistemas_sistema_oempresas].[pId2] = [sistema].[pId]) 
    WHERE ([empresa_osistemas_sistema_oempresas].[pId2] = @SistemapId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENT_CAMBAL_CAMINHAOVIAGENS].[pId], [ENT_CAMBAL_CAMINHAOVIAGENS].[ROWNUM], [ENT_CAMBAL_CAMINHAOVIAGENS].[FRENTE], [ENT_CAMBAL_CAMINHAOVIAGENS].[COD_PROP], [ENT_CAMBAL_CAMINHAOVIAGENS].[CAMINHAO], [ENT_CAMBAL_CAMINHAOVIAGENS].[QTD_VIAGENS], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteTime], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackCreationTime], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteUser], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackCreationUser] 
    FROM [ENT_CAMBAL_CAMINHAOVIAGENS] 
    WHERE ([ENT_CAMBAL_CAMINHAOVIAGENS].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENT_CAMBAL_CAMINHAOVIAGENS].[pId], [ENT_CAMBAL_CAMINHAOVIAGENS].[ROWNUM], [ENT_CAMBAL_CAMINHAOVIAGENS].[FRENTE], [ENT_CAMBAL_CAMINHAOVIAGENS].[COD_PROP], [ENT_CAMBAL_CAMINHAOVIAGENS].[CAMINHAO], [ENT_CAMBAL_CAMINHAOVIAGENS].[QTD_VIAGENS], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteTime], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackCreationTime], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteUser], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackCreationUser] 
    FROM [ENT_CAMBAL_CAMINHAOVIAGENS] 

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENT_CAMBAL_CAMINHAOVIAGENS].[pId], [ENT_CAMBAL_CAMINHAOVIAGENS].[ROWNUM], [ENT_CAMBAL_CAMINHAOVIAGENS].[FRENTE], [ENT_CAMBAL_CAMINHAOVIAGENS].[COD_PROP], [ENT_CAMBAL_CAMINHAOVIAGENS].[CAMINHAO], [ENT_CAMBAL_CAMINHAOVIAGENS].[QTD_VIAGENS], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteTime], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackCreationTime], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteUser], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackCreationUser] 
    FROM [ENT_CAMBAL_CAMINHAOVIAGENS] 
    WHERE ([ENT_CAMBAL_CAMINHAOVIAGENS].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_FRENTESPROP_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENT_CAMBAL_FRENTESPROP].[pId], [ENT_CAMBAL_FRENTESPROP].[ROWNUM], [ENT_CAMBAL_FRENTESPROP].[FRENTE], [ENT_CAMBAL_FRENTESPROP].[COD_PROP], [ENT_CAMBAL_FRENTESPROP].[PROPRIEDADE], [ENT_CAMBAL_FRENTESPROP].[QTD_VIAGENS], [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteTime], [ENT_CAMBAL_FRENTESPROP].[_trackCreationTime], [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteUser], [ENT_CAMBAL_FRENTESPROP].[_trackCreationUser] 
    FROM [ENT_CAMBAL_FRENTESPROP] 
    WHERE ([ENT_CAMBAL_FRENTESPROP].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_FRENTESPROP_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENT_CAMBAL_FRENTESPROP].[pId], [ENT_CAMBAL_FRENTESPROP].[ROWNUM], [ENT_CAMBAL_FRENTESPROP].[FRENTE], [ENT_CAMBAL_FRENTESPROP].[COD_PROP], [ENT_CAMBAL_FRENTESPROP].[PROPRIEDADE], [ENT_CAMBAL_FRENTESPROP].[QTD_VIAGENS], [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteTime], [ENT_CAMBAL_FRENTESPROP].[_trackCreationTime], [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteUser], [ENT_CAMBAL_FRENTESPROP].[_trackCreationUser] 
    FROM [ENT_CAMBAL_FRENTESPROP] 

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_FRENTESPROP_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENT_CAMBAL_FRENTESPROP].[pId], [ENT_CAMBAL_FRENTESPROP].[ROWNUM], [ENT_CAMBAL_FRENTESPROP].[FRENTE], [ENT_CAMBAL_FRENTESPROP].[COD_PROP], [ENT_CAMBAL_FRENTESPROP].[PROPRIEDADE], [ENT_CAMBAL_FRENTESPROP].[QTD_VIAGENS], [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteTime], [ENT_CAMBAL_FRENTESPROP].[_trackCreationTime], [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteUser], [ENT_CAMBAL_FRENTESPROP].[_trackCreationUser] 
    FROM [ENT_CAMBAL_FRENTESPROP] 
    WHERE ([ENT_CAMBAL_FRENTESPROP].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_PRINCIPAL_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENT_CAMBAL_PRINCIPAL].[pId], [ENT_CAMBAL_PRINCIPAL].[HORA], [ENT_CAMBAL_PRINCIPAL].[F1], [ENT_CAMBAL_PRINCIPAL].[F2], [ENT_CAMBAL_PRINCIPAL].[F3], [ENT_CAMBAL_PRINCIPAL].[F4], [ENT_CAMBAL_PRINCIPAL].[F5], [ENT_CAMBAL_PRINCIPAL].[F6], [ENT_CAMBAL_PRINCIPAL].[F7], [ENT_CAMBAL_PRINCIPAL].[F8], [ENT_CAMBAL_PRINCIPAL].[F9], [ENT_CAMBAL_PRINCIPAL].[F10], [ENT_CAMBAL_PRINCIPAL].[TOTAL], [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteTime], [ENT_CAMBAL_PRINCIPAL].[_trackCreationTime], [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteUser], [ENT_CAMBAL_PRINCIPAL].[_trackCreationUser] 
    FROM [ENT_CAMBAL_PRINCIPAL] 
    WHERE ([ENT_CAMBAL_PRINCIPAL].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_PRINCIPAL_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENT_CAMBAL_PRINCIPAL].[pId], [ENT_CAMBAL_PRINCIPAL].[HORA], [ENT_CAMBAL_PRINCIPAL].[F1], [ENT_CAMBAL_PRINCIPAL].[F2], [ENT_CAMBAL_PRINCIPAL].[F3], [ENT_CAMBAL_PRINCIPAL].[F4], [ENT_CAMBAL_PRINCIPAL].[F5], [ENT_CAMBAL_PRINCIPAL].[F6], [ENT_CAMBAL_PRINCIPAL].[F7], [ENT_CAMBAL_PRINCIPAL].[F8], [ENT_CAMBAL_PRINCIPAL].[F9], [ENT_CAMBAL_PRINCIPAL].[F10], [ENT_CAMBAL_PRINCIPAL].[TOTAL], [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteTime], [ENT_CAMBAL_PRINCIPAL].[_trackCreationTime], [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteUser], [ENT_CAMBAL_PRINCIPAL].[_trackCreationUser] 
    FROM [ENT_CAMBAL_PRINCIPAL] 

RETURN
GO

CREATE PROCEDURE [dbo].[ENT_CAMBAL_PRINCIPAL_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENT_CAMBAL_PRINCIPAL].[pId], [ENT_CAMBAL_PRINCIPAL].[HORA], [ENT_CAMBAL_PRINCIPAL].[F1], [ENT_CAMBAL_PRINCIPAL].[F2], [ENT_CAMBAL_PRINCIPAL].[F3], [ENT_CAMBAL_PRINCIPAL].[F4], [ENT_CAMBAL_PRINCIPAL].[F5], [ENT_CAMBAL_PRINCIPAL].[F6], [ENT_CAMBAL_PRINCIPAL].[F7], [ENT_CAMBAL_PRINCIPAL].[F8], [ENT_CAMBAL_PRINCIPAL].[F9], [ENT_CAMBAL_PRINCIPAL].[F10], [ENT_CAMBAL_PRINCIPAL].[TOTAL], [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteTime], [ENT_CAMBAL_PRINCIPAL].[_trackCreationTime], [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteUser], [ENT_CAMBAL_PRINCIPAL].[_trackCreationUser] 
    FROM [ENT_CAMBAL_PRINCIPAL] 
    WHERE ([ENT_CAMBAL_PRINCIPAL].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_AGRUP_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_DET_AGRUP].[pId], [ENTRADA_CANA_DET_AGRUP].[ID_NEGOCIOS], [ENTRADA_CANA_DET_AGRUP].[NR_ANO_SAFRA], [ENTRADA_CANA_DET_AGRUP].[NRO_DOCUMENTO], [ENTRADA_CANA_DET_AGRUP].[PROP_CODIGO], [ENTRADA_CANA_DET_AGRUP].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET_AGRUP].[FRENTE_COLHEITA], [ENTRADA_CANA_DET_AGRUP].[MUNICIPIO], [ENTRADA_CANA_DET_AGRUP].[DESCMUNI], [ENTRADA_CANA_DET_AGRUP].[TIPO], [ENTRADA_CANA_DET_AGRUP].[DESCTIPO], [ENTRADA_CANA_DET_AGRUP].[DT_ENTRADA], [ENTRADA_CANA_DET_AGRUP].[DT_MOAGEM], [ENTRADA_CANA_DET_AGRUP].[AREA_COLHIDA], [ENTRADA_CANA_DET_AGRUP].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteTime], [ENTRADA_CANA_DET_AGRUP].[_trackCreationTime], [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteUser], [ENTRADA_CANA_DET_AGRUP].[_trackCreationUser] 
    FROM [ENTRADA_CANA_DET_AGRUP] 
    WHERE ([ENTRADA_CANA_DET_AGRUP].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_AGRUP_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_DET_AGRUP].[pId], [ENTRADA_CANA_DET_AGRUP].[ID_NEGOCIOS], [ENTRADA_CANA_DET_AGRUP].[NR_ANO_SAFRA], [ENTRADA_CANA_DET_AGRUP].[NRO_DOCUMENTO], [ENTRADA_CANA_DET_AGRUP].[PROP_CODIGO], [ENTRADA_CANA_DET_AGRUP].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET_AGRUP].[FRENTE_COLHEITA], [ENTRADA_CANA_DET_AGRUP].[MUNICIPIO], [ENTRADA_CANA_DET_AGRUP].[DESCMUNI], [ENTRADA_CANA_DET_AGRUP].[TIPO], [ENTRADA_CANA_DET_AGRUP].[DESCTIPO], [ENTRADA_CANA_DET_AGRUP].[DT_ENTRADA], [ENTRADA_CANA_DET_AGRUP].[DT_MOAGEM], [ENTRADA_CANA_DET_AGRUP].[AREA_COLHIDA], [ENTRADA_CANA_DET_AGRUP].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteTime], [ENTRADA_CANA_DET_AGRUP].[_trackCreationTime], [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteUser], [ENTRADA_CANA_DET_AGRUP].[_trackCreationUser] 
    FROM [ENTRADA_CANA_DET_AGRUP] 

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_AGRUP_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_DET_AGRUP].[pId], [ENTRADA_CANA_DET_AGRUP].[ID_NEGOCIOS], [ENTRADA_CANA_DET_AGRUP].[NR_ANO_SAFRA], [ENTRADA_CANA_DET_AGRUP].[NRO_DOCUMENTO], [ENTRADA_CANA_DET_AGRUP].[PROP_CODIGO], [ENTRADA_CANA_DET_AGRUP].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET_AGRUP].[FRENTE_COLHEITA], [ENTRADA_CANA_DET_AGRUP].[MUNICIPIO], [ENTRADA_CANA_DET_AGRUP].[DESCMUNI], [ENTRADA_CANA_DET_AGRUP].[TIPO], [ENTRADA_CANA_DET_AGRUP].[DESCTIPO], [ENTRADA_CANA_DET_AGRUP].[DT_ENTRADA], [ENTRADA_CANA_DET_AGRUP].[DT_MOAGEM], [ENTRADA_CANA_DET_AGRUP].[AREA_COLHIDA], [ENTRADA_CANA_DET_AGRUP].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteTime], [ENTRADA_CANA_DET_AGRUP].[_trackCreationTime], [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteUser], [ENTRADA_CANA_DET_AGRUP].[_trackCreationUser] 
    FROM [ENTRADA_CANA_DET_AGRUP] 
    WHERE ([ENTRADA_CANA_DET_AGRUP].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_DET].[pId], [ENTRADA_CANA_DET].[ID_NEGOCIOS], [ENTRADA_CANA_DET].[NR_ANO_SAFRA], [ENTRADA_CANA_DET].[NRO_DOCUMENTO], [ENTRADA_CANA_DET].[PROP_CODIGO], [ENTRADA_CANA_DET].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET].[DSC_VARIEDADE], [ENTRADA_CANA_DET].[NRO_CORTE], [ENTRADA_CANA_DET].[FRENTE_COLHEITA], [ENTRADA_CANA_DET].[MUNICIPIO], [ENTRADA_CANA_DET].[DESCMUNI], [ENTRADA_CANA_DET].[TIPO], [ENTRADA_CANA_DET].[DESCTIPO], [ENTRADA_CANA_DET].[DT_ENTRADA], [ENTRADA_CANA_DET].[EQUIP_ENTRADA], [ENTRADA_CANA_DET].[REBOQUE], [ENTRADA_CANA_DET].[DT_MOAGEM], [ENTRADA_CANA_DET].[AREA_COLHIDA], [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_PREV], [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET].[_trackLastWriteTime], [ENTRADA_CANA_DET].[_trackCreationTime], [ENTRADA_CANA_DET].[_trackLastWriteUser], [ENTRADA_CANA_DET].[_trackCreationUser] 
    FROM [ENTRADA_CANA_DET] 
    WHERE ([ENTRADA_CANA_DET].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_DET].[pId], [ENTRADA_CANA_DET].[ID_NEGOCIOS], [ENTRADA_CANA_DET].[NR_ANO_SAFRA], [ENTRADA_CANA_DET].[NRO_DOCUMENTO], [ENTRADA_CANA_DET].[PROP_CODIGO], [ENTRADA_CANA_DET].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET].[DSC_VARIEDADE], [ENTRADA_CANA_DET].[NRO_CORTE], [ENTRADA_CANA_DET].[FRENTE_COLHEITA], [ENTRADA_CANA_DET].[MUNICIPIO], [ENTRADA_CANA_DET].[DESCMUNI], [ENTRADA_CANA_DET].[TIPO], [ENTRADA_CANA_DET].[DESCTIPO], [ENTRADA_CANA_DET].[DT_ENTRADA], [ENTRADA_CANA_DET].[EQUIP_ENTRADA], [ENTRADA_CANA_DET].[REBOQUE], [ENTRADA_CANA_DET].[DT_MOAGEM], [ENTRADA_CANA_DET].[AREA_COLHIDA], [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_PREV], [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET].[_trackLastWriteTime], [ENTRADA_CANA_DET].[_trackCreationTime], [ENTRADA_CANA_DET].[_trackLastWriteUser], [ENTRADA_CANA_DET].[_trackCreationUser] 
    FROM [ENTRADA_CANA_DET] 

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_DET].[pId], [ENTRADA_CANA_DET].[ID_NEGOCIOS], [ENTRADA_CANA_DET].[NR_ANO_SAFRA], [ENTRADA_CANA_DET].[NRO_DOCUMENTO], [ENTRADA_CANA_DET].[PROP_CODIGO], [ENTRADA_CANA_DET].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET].[DSC_VARIEDADE], [ENTRADA_CANA_DET].[NRO_CORTE], [ENTRADA_CANA_DET].[FRENTE_COLHEITA], [ENTRADA_CANA_DET].[MUNICIPIO], [ENTRADA_CANA_DET].[DESCMUNI], [ENTRADA_CANA_DET].[TIPO], [ENTRADA_CANA_DET].[DESCTIPO], [ENTRADA_CANA_DET].[DT_ENTRADA], [ENTRADA_CANA_DET].[EQUIP_ENTRADA], [ENTRADA_CANA_DET].[REBOQUE], [ENTRADA_CANA_DET].[DT_MOAGEM], [ENTRADA_CANA_DET].[AREA_COLHIDA], [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_PREV], [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET].[_trackLastWriteTime], [ENTRADA_CANA_DET].[_trackCreationTime], [ENTRADA_CANA_DET].[_trackLastWriteUser], [ENTRADA_CANA_DET].[_trackCreationUser] 
    FROM [ENTRADA_CANA_DET] 
    WHERE ([ENTRADA_CANA_DET].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_MP_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_DET_MP].[pId], [ENTRADA_CANA_DET_MP].[ID_NEGOCIOS], [ENTRADA_CANA_DET_MP].[NR_ANO_SAFRA], [ENTRADA_CANA_DET_MP].[PROP_CODIGO], [ENTRADA_CANA_DET_MP].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITATOP], [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITA], [ENTRADA_CANA_DET_MP].[MUNICIPIO], [ENTRADA_CANA_DET_MP].[DESCMUNI], [ENTRADA_CANA_DET_MP].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET_MP].[INICIO], [ENTRADA_CANA_DET_MP].[_trackLastWriteTime], [ENTRADA_CANA_DET_MP].[_trackCreationTime], [ENTRADA_CANA_DET_MP].[_trackLastWriteUser], [ENTRADA_CANA_DET_MP].[_trackCreationUser] 
    FROM [ENTRADA_CANA_DET_MP] 
    WHERE ([ENTRADA_CANA_DET_MP].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_MP_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_DET_MP].[pId], [ENTRADA_CANA_DET_MP].[ID_NEGOCIOS], [ENTRADA_CANA_DET_MP].[NR_ANO_SAFRA], [ENTRADA_CANA_DET_MP].[PROP_CODIGO], [ENTRADA_CANA_DET_MP].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITATOP], [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITA], [ENTRADA_CANA_DET_MP].[MUNICIPIO], [ENTRADA_CANA_DET_MP].[DESCMUNI], [ENTRADA_CANA_DET_MP].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET_MP].[INICIO], [ENTRADA_CANA_DET_MP].[_trackLastWriteTime], [ENTRADA_CANA_DET_MP].[_trackCreationTime], [ENTRADA_CANA_DET_MP].[_trackLastWriteUser], [ENTRADA_CANA_DET_MP].[_trackCreationUser] 
    FROM [ENTRADA_CANA_DET_MP] 

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_DET_MP_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_DET_MP].[pId], [ENTRADA_CANA_DET_MP].[ID_NEGOCIOS], [ENTRADA_CANA_DET_MP].[NR_ANO_SAFRA], [ENTRADA_CANA_DET_MP].[PROP_CODIGO], [ENTRADA_CANA_DET_MP].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITATOP], [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITA], [ENTRADA_CANA_DET_MP].[MUNICIPIO], [ENTRADA_CANA_DET_MP].[DESCMUNI], [ENTRADA_CANA_DET_MP].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET_MP].[INICIO], [ENTRADA_CANA_DET_MP].[_trackLastWriteTime], [ENTRADA_CANA_DET_MP].[_trackCreationTime], [ENTRADA_CANA_DET_MP].[_trackLastWriteUser], [ENTRADA_CANA_DET_MP].[_trackCreationUser] 
    FROM [ENTRADA_CANA_DET_MP] 
    WHERE ([ENTRADA_CANA_DET_MP].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_HORA_FRENTE].[pId], [ENTRADA_CANA_HORA_FRENTE].[ID_NEGOCIOS], [ENTRADA_CANA_HORA_FRENTE].[DIA], [ENTRADA_CANA_HORA_FRENTE].[HORA], [ENTRADA_CANA_HORA_FRENTE].[FRENTE], [ENTRADA_CANA_HORA_FRENTE].[TONELADAS], [ENTRADA_CANA_HORA_FRENTE].[VIAGEM], [ENTRADA_CANA_HORA_FRENTE].[TON_VIAGEM], [ENTRADA_CANA_HORA_FRENTE].[METAFRENTE], [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteTime], [ENTRADA_CANA_HORA_FRENTE].[_trackCreationTime], [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteUser], [ENTRADA_CANA_HORA_FRENTE].[_trackCreationUser] 
    FROM [ENTRADA_CANA_HORA_FRENTE] 
    WHERE ([ENTRADA_CANA_HORA_FRENTE].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_HORA_FRENTE].[pId], [ENTRADA_CANA_HORA_FRENTE].[ID_NEGOCIOS], [ENTRADA_CANA_HORA_FRENTE].[DIA], [ENTRADA_CANA_HORA_FRENTE].[HORA], [ENTRADA_CANA_HORA_FRENTE].[FRENTE], [ENTRADA_CANA_HORA_FRENTE].[TONELADAS], [ENTRADA_CANA_HORA_FRENTE].[VIAGEM], [ENTRADA_CANA_HORA_FRENTE].[TON_VIAGEM], [ENTRADA_CANA_HORA_FRENTE].[METAFRENTE], [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteTime], [ENTRADA_CANA_HORA_FRENTE].[_trackCreationTime], [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteUser], [ENTRADA_CANA_HORA_FRENTE].[_trackCreationUser] 
    FROM [ENTRADA_CANA_HORA_FRENTE] 

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_LoadByDIAFRENTE]
(
 @parID_NEGOCIOS [int],
 @parDIA [date],
 @parFRENTE [int],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_HORA_FRENTE].[pId], [ENTRADA_CANA_HORA_FRENTE].[ID_NEGOCIOS], [ENTRADA_CANA_HORA_FRENTE].[DIA], [ENTRADA_CANA_HORA_FRENTE].[HORA], [ENTRADA_CANA_HORA_FRENTE].[FRENTE], [ENTRADA_CANA_HORA_FRENTE].[TONELADAS], [ENTRADA_CANA_HORA_FRENTE].[VIAGEM], [ENTRADA_CANA_HORA_FRENTE].[TON_VIAGEM], [ENTRADA_CANA_HORA_FRENTE].[METAFRENTE], [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteTime], [ENTRADA_CANA_HORA_FRENTE].[_trackCreationTime], [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteUser], [ENTRADA_CANA_HORA_FRENTE].[_trackCreationUser] 
    FROM [ENTRADA_CANA_HORA_FRENTE] 
    WHERE (([ENTRADA_CANA_HORA_FRENTE].[ID_NEGOCIOS] = @parID_NEGOCIOS) AND (([ENTRADA_CANA_HORA_FRENTE].[DIA] = @parDIA) AND ([ENTRADA_CANA_HORA_FRENTE].[FRENTE] = @parFRENTE)))

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_FRENTE_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_HORA_FRENTE].[pId], [ENTRADA_CANA_HORA_FRENTE].[ID_NEGOCIOS], [ENTRADA_CANA_HORA_FRENTE].[DIA], [ENTRADA_CANA_HORA_FRENTE].[HORA], [ENTRADA_CANA_HORA_FRENTE].[FRENTE], [ENTRADA_CANA_HORA_FRENTE].[TONELADAS], [ENTRADA_CANA_HORA_FRENTE].[VIAGEM], [ENTRADA_CANA_HORA_FRENTE].[TON_VIAGEM], [ENTRADA_CANA_HORA_FRENTE].[METAFRENTE], [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteTime], [ENTRADA_CANA_HORA_FRENTE].[_trackCreationTime], [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteUser], [ENTRADA_CANA_HORA_FRENTE].[_trackCreationUser] 
    FROM [ENTRADA_CANA_HORA_FRENTE] 
    WHERE ([ENTRADA_CANA_HORA_FRENTE].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_HORA].[pId], [ENTRADA_CANA_HORA].[ID_NEGOCIOS], [ENTRADA_CANA_HORA].[DIA], [ENTRADA_CANA_HORA].[HORA], [ENTRADA_CANA_HORA].[TONELADAS], [ENTRADA_CANA_HORA].[VIAGEM], [ENTRADA_CANA_HORA].[TON_VIAGEM], [ENTRADA_CANA_HORA].[METAFRENTE], [ENTRADA_CANA_HORA].[_trackLastWriteTime], [ENTRADA_CANA_HORA].[_trackCreationTime], [ENTRADA_CANA_HORA].[_trackLastWriteUser], [ENTRADA_CANA_HORA].[_trackCreationUser] 
    FROM [ENTRADA_CANA_HORA] 
    WHERE ([ENTRADA_CANA_HORA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_HORA].[pId], [ENTRADA_CANA_HORA].[ID_NEGOCIOS], [ENTRADA_CANA_HORA].[DIA], [ENTRADA_CANA_HORA].[HORA], [ENTRADA_CANA_HORA].[TONELADAS], [ENTRADA_CANA_HORA].[VIAGEM], [ENTRADA_CANA_HORA].[TON_VIAGEM], [ENTRADA_CANA_HORA].[METAFRENTE], [ENTRADA_CANA_HORA].[_trackLastWriteTime], [ENTRADA_CANA_HORA].[_trackCreationTime], [ENTRADA_CANA_HORA].[_trackLastWriteUser], [ENTRADA_CANA_HORA].[_trackCreationUser] 
    FROM [ENTRADA_CANA_HORA] 

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_LoadByDIA]
(
 @parID_NEGOCIOS [int],
 @parDIA [date],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_HORA].[pId], [ENTRADA_CANA_HORA].[ID_NEGOCIOS], [ENTRADA_CANA_HORA].[DIA], [ENTRADA_CANA_HORA].[HORA], [ENTRADA_CANA_HORA].[TONELADAS], [ENTRADA_CANA_HORA].[VIAGEM], [ENTRADA_CANA_HORA].[TON_VIAGEM], [ENTRADA_CANA_HORA].[METAFRENTE], [ENTRADA_CANA_HORA].[_trackLastWriteTime], [ENTRADA_CANA_HORA].[_trackCreationTime], [ENTRADA_CANA_HORA].[_trackLastWriteUser], [ENTRADA_CANA_HORA].[_trackCreationUser] 
    FROM [ENTRADA_CANA_HORA] 
    WHERE (([ENTRADA_CANA_HORA].[ID_NEGOCIOS] = @parID_NEGOCIOS) AND ([ENTRADA_CANA_HORA].[DIA] = @parDIA))

RETURN
GO

CREATE PROCEDURE [dbo].[ENTRADA_CANA_HORA_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ENTRADA_CANA_HORA].[pId], [ENTRADA_CANA_HORA].[ID_NEGOCIOS], [ENTRADA_CANA_HORA].[DIA], [ENTRADA_CANA_HORA].[HORA], [ENTRADA_CANA_HORA].[TONELADAS], [ENTRADA_CANA_HORA].[VIAGEM], [ENTRADA_CANA_HORA].[TON_VIAGEM], [ENTRADA_CANA_HORA].[METAFRENTE], [ENTRADA_CANA_HORA].[_trackLastWriteTime], [ENTRADA_CANA_HORA].[_trackCreationTime], [ENTRADA_CANA_HORA].[_trackLastWriteUser], [ENTRADA_CANA_HORA].[_trackCreationUser] 
    FROM [ENTRADA_CANA_HORA] 
    WHERE ([ENTRADA_CANA_HORA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ESCALA_COLAB_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ESCALA_COLAB].[pId], [ESCALA_COLAB].[ROWNUM], [ESCALA_COLAB].[PROCESSO], [ESCALA_COLAB].[ESTRUTURA], [ESCALA_COLAB].[MATRICULA], [ESCALA_COLAB].[NOME], [ESCALA_COLAB].[TURNO], [ESCALA_COLAB].[DIA01], [ESCALA_COLAB].[DIA02], [ESCALA_COLAB].[DIA03], [ESCALA_COLAB].[DIA04], [ESCALA_COLAB].[DIA05], [ESCALA_COLAB].[DIA06], [ESCALA_COLAB].[DIA07], [ESCALA_COLAB].[DIA08], [ESCALA_COLAB].[DIA09], [ESCALA_COLAB].[DIA10], [ESCALA_COLAB].[DIA11], [ESCALA_COLAB].[DIA12], [ESCALA_COLAB].[DIA13], [ESCALA_COLAB].[DIA14], [ESCALA_COLAB].[DIA15], [ESCALA_COLAB].[DIA16], [ESCALA_COLAB].[DIA17], [ESCALA_COLAB].[DIA18], [ESCALA_COLAB].[DIA19], [ESCALA_COLAB].[DIA20], [ESCALA_COLAB].[DIA21], [ESCALA_COLAB].[DIA22], [ESCALA_COLAB].[DIA23], [ESCALA_COLAB].[DIA24], [ESCALA_COLAB].[DIA25], [ESCALA_COLAB].[DIA26], [ESCALA_COLAB].[DIA27], [ESCALA_COLAB].[DIA28], [ESCALA_COLAB].[DIA29], [ESCALA_COLAB].[DIA30], [ESCALA_COLAB].[CELULAR], [ESCALA_COLAB].[ID_NIVEL], [ESCALA_COLAB].[ID_TURMAS], [ESCALA_COLAB].[_trackLastWriteTime], [ESCALA_COLAB].[_trackCreationTime], [ESCALA_COLAB].[_trackLastWriteUser], [ESCALA_COLAB].[_trackCreationUser] 
    FROM [ESCALA_COLAB] 
    WHERE ([ESCALA_COLAB].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[ESCALA_COLAB_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ESCALA_COLAB].[pId], [ESCALA_COLAB].[ROWNUM], [ESCALA_COLAB].[PROCESSO], [ESCALA_COLAB].[ESTRUTURA], [ESCALA_COLAB].[MATRICULA], [ESCALA_COLAB].[NOME], [ESCALA_COLAB].[TURNO], [ESCALA_COLAB].[DIA01], [ESCALA_COLAB].[DIA02], [ESCALA_COLAB].[DIA03], [ESCALA_COLAB].[DIA04], [ESCALA_COLAB].[DIA05], [ESCALA_COLAB].[DIA06], [ESCALA_COLAB].[DIA07], [ESCALA_COLAB].[DIA08], [ESCALA_COLAB].[DIA09], [ESCALA_COLAB].[DIA10], [ESCALA_COLAB].[DIA11], [ESCALA_COLAB].[DIA12], [ESCALA_COLAB].[DIA13], [ESCALA_COLAB].[DIA14], [ESCALA_COLAB].[DIA15], [ESCALA_COLAB].[DIA16], [ESCALA_COLAB].[DIA17], [ESCALA_COLAB].[DIA18], [ESCALA_COLAB].[DIA19], [ESCALA_COLAB].[DIA20], [ESCALA_COLAB].[DIA21], [ESCALA_COLAB].[DIA22], [ESCALA_COLAB].[DIA23], [ESCALA_COLAB].[DIA24], [ESCALA_COLAB].[DIA25], [ESCALA_COLAB].[DIA26], [ESCALA_COLAB].[DIA27], [ESCALA_COLAB].[DIA28], [ESCALA_COLAB].[DIA29], [ESCALA_COLAB].[DIA30], [ESCALA_COLAB].[CELULAR], [ESCALA_COLAB].[ID_NIVEL], [ESCALA_COLAB].[ID_TURMAS], [ESCALA_COLAB].[_trackLastWriteTime], [ESCALA_COLAB].[_trackCreationTime], [ESCALA_COLAB].[_trackLastWriteUser], [ESCALA_COLAB].[_trackCreationUser] 
    FROM [ESCALA_COLAB] 

RETURN
GO

CREATE PROCEDURE [dbo].[ESCALA_COLAB_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [ESCALA_COLAB].[pId], [ESCALA_COLAB].[ROWNUM], [ESCALA_COLAB].[PROCESSO], [ESCALA_COLAB].[ESTRUTURA], [ESCALA_COLAB].[MATRICULA], [ESCALA_COLAB].[NOME], [ESCALA_COLAB].[TURNO], [ESCALA_COLAB].[DIA01], [ESCALA_COLAB].[DIA02], [ESCALA_COLAB].[DIA03], [ESCALA_COLAB].[DIA04], [ESCALA_COLAB].[DIA05], [ESCALA_COLAB].[DIA06], [ESCALA_COLAB].[DIA07], [ESCALA_COLAB].[DIA08], [ESCALA_COLAB].[DIA09], [ESCALA_COLAB].[DIA10], [ESCALA_COLAB].[DIA11], [ESCALA_COLAB].[DIA12], [ESCALA_COLAB].[DIA13], [ESCALA_COLAB].[DIA14], [ESCALA_COLAB].[DIA15], [ESCALA_COLAB].[DIA16], [ESCALA_COLAB].[DIA17], [ESCALA_COLAB].[DIA18], [ESCALA_COLAB].[DIA19], [ESCALA_COLAB].[DIA20], [ESCALA_COLAB].[DIA21], [ESCALA_COLAB].[DIA22], [ESCALA_COLAB].[DIA23], [ESCALA_COLAB].[DIA24], [ESCALA_COLAB].[DIA25], [ESCALA_COLAB].[DIA26], [ESCALA_COLAB].[DIA27], [ESCALA_COLAB].[DIA28], [ESCALA_COLAB].[DIA29], [ESCALA_COLAB].[DIA30], [ESCALA_COLAB].[CELULAR], [ESCALA_COLAB].[ID_NIVEL], [ESCALA_COLAB].[ID_TURMAS], [ESCALA_COLAB].[_trackLastWriteTime], [ESCALA_COLAB].[_trackCreationTime], [ESCALA_COLAB].[_trackLastWriteUser], [ESCALA_COLAB].[_trackCreationUser] 
    FROM [ESCALA_COLAB] 
    WHERE ([ESCALA_COLAB].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[filial_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [filial].[xDataHoraReg], [filial].[xLoginReg], [filial].[oEmpresa_pId], [filial].[oCadastro_pId], [filial].[_trackLastWriteTime], [filial].[_trackCreationTime], [filial].[_trackLastWriteUser], [filial].[_trackCreationUser] 
    FROM [filial] 
    WHERE ([filial].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[filial_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [filial].[xDataHoraReg], [filial].[xLoginReg], [filial].[oEmpresa_pId], [filial].[oCadastro_pId], [filial].[_trackLastWriteTime], [filial].[_trackCreationTime], [filial].[_trackLastWriteUser], [filial].[_trackCreationUser] 
    FROM [filial] 

RETURN
GO

CREATE PROCEDURE [dbo].[filial_LoadByCodEmpresaCodFilial]
(
 @pCodEmpresa [int],
 @pCodFilial [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [filial].[xDataHoraReg], [filial].[xLoginReg], [filial].[oEmpresa_pId], [filial].[oCadastro_pId], [filial].[_trackLastWriteTime], [filial].[_trackCreationTime], [filial].[_trackLastWriteUser], [filial].[_trackCreationUser] 
    FROM [filial]
        LEFT OUTER JOIN [empresa] ON ([filial].[oEmpresa_pId] = [empresa].[pId]) 
    WHERE (([empresa].[pCodigo] = @pCodEmpresa) AND ([filial].[pCodigo] = @pCodFilial))

RETURN
GO

CREATE PROCEDURE [dbo].[filial_LoadByCodEmpresaNomeFilial]
(
 @pCodEmpresa [int],
 @pNomFilial [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [filial].[xDataHoraReg], [filial].[xLoginReg], [filial].[oEmpresa_pId], [filial].[oCadastro_pId], [filial].[_trackLastWriteTime], [filial].[_trackCreationTime], [filial].[_trackLastWriteUser], [filial].[_trackCreationUser] 
    FROM [filial]
        LEFT OUTER JOIN [empresa] ON ([filial].[oEmpresa_pId] = [empresa].[pId]) 
    WHERE (([empresa].[pCodigo] = @pCodEmpresa) AND ([filial].[pNome] LIKE @pNomFilial))

RETURN
GO

CREATE PROCEDURE [dbo].[filial_LoadByCodFilialLoginUsuario]
(
 @parCodFilial [int],
 @parLoginUsuario [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vfilialfilialviewusuarios].[pId], [vfilialfilialviewusuarios].[pCodigo], [vfilialfilialviewusuarios].[pNome], [vfilialfilialviewusuarios].[sTipo], [vfilialfilialviewusuarios].[pEmpresaCodigo], [vfilialfilialviewusuarios].[pEmpresaNome], [vfilialfilialviewusuarios].[pUsuarioLogin], [vfilialfilialviewusuarios].[_trackCreationTime], [vfilialfilialviewusuarios].[_trackLastWriteTime], [vfilialfilialviewusuarios].[_trackCreationUser], [vfilialfilialviewusuarios].[_trackLastWriteUser] 
    FROM [vfilialfilialviewusuarios] 
    WHERE (([vfilialfilialviewusuarios].[pCodigo] = @parCodFilial) AND ([vfilialfilialviewusuarios].[pUsuarioLogin] = @parLoginUsuario))

RETURN
GO

CREATE PROCEDURE [dbo].[filial_LoadByoCadastro]
(
 @oCadastropId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [filial].[xDataHoraReg], [filial].[xLoginReg], [filial].[oEmpresa_pId], [filial].[oCadastro_pId], [filial].[_trackLastWriteTime], [filial].[_trackCreationTime], [filial].[_trackLastWriteUser], [filial].[_trackCreationUser] 
    FROM [filial] 
    WHERE ([filial].[oCadastro_pId] = @oCadastropId)

RETURN
GO

CREATE PROCEDURE [dbo].[filial_LoadByoEmpresa]
(
 @oEmpresapId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [filial].[xDataHoraReg], [filial].[xLoginReg], [filial].[oEmpresa_pId], [filial].[oCadastro_pId], [filial].[_trackLastWriteTime], [filial].[_trackCreationTime], [filial].[_trackLastWriteUser], [filial].[_trackCreationUser] 
    FROM [filial] 
    WHERE ([filial].[oEmpresa_pId] = @oEmpresapId)

RETURN
GO

CREATE PROCEDURE [dbo].[filial_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [filial].[xDataHoraReg], [filial].[xLoginReg], [filial].[oEmpresa_pId], [filial].[oCadastro_pId], [filial].[_trackLastWriteTime], [filial].[_trackCreationTime], [filial].[_trackLastWriteUser], [filial].[_trackCreationUser] 
    FROM [filial] 
    WHERE ([filial].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[filial_LoadMaxCodigo]
(
 @parCodEmpresa [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT TOP 1 [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [filial].[xDataHoraReg], [filial].[xLoginReg], [filial].[oEmpresa_pId], [filial].[oCadastro_pId], [filial].[_trackLastWriteTime], [filial].[_trackCreationTime], [filial].[_trackLastWriteUser], [filial].[_trackCreationUser] 
    FROM [filial]
        LEFT OUTER JOIN [empresa] ON ([filial].[oEmpresa_pId] = [empresa].[pId]) 
    WHERE ([empresa].[pCodigo] = @parCodEmpresa)
    ORDER BY [filial].[pCodigo] DESC

RETURN
GO

CREATE PROCEDURE [dbo].[filial_LoadoFiliaisoUsuariosByUsuario]
(
 @UsuariopId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [filial].[xDataHoraReg], [filial].[xLoginReg], [filial].[oEmpresa_pId], [filial].[oCadastro_pId], [filial].[_trackLastWriteTime], [filial].[_trackCreationTime], [filial].[_trackLastWriteUser], [filial].[_trackCreationUser] 
    FROM [filial]
        LEFT OUTER JOIN [filial_ousuarios_usuario_ofiliais] ON ([filial].[pId] = [filial_ousuarios_usuario_ofiliais].[pId])
                LEFT OUTER JOIN [usuario] ON ([filial_ousuarios_usuario_ofiliais].[pId2] = [usuario].[pId]) 
    WHERE ([filial_ousuarios_usuario_ofiliais].[pId2] = @UsuariopId)

RETURN
GO

CREATE PROCEDURE [dbo].[filialconfig_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filialconfig].[pId], [filialconfig].[sTipo], [filialconfig].[pConteudo], [filialconfig].[xDataHoraReg], [filialconfig].[xLoginReg], [filialconfig].[oFilial_pId], [filialconfig].[_trackLastWriteTime], [filialconfig].[_trackCreationTime], [filialconfig].[_trackLastWriteUser], [filialconfig].[_trackCreationUser] 
    FROM [filialconfig] 
    WHERE ([filialconfig].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[filialconfig_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filialconfig].[pId], [filialconfig].[sTipo], [filialconfig].[pConteudo], [filialconfig].[xDataHoraReg], [filialconfig].[xLoginReg], [filialconfig].[oFilial_pId], [filialconfig].[_trackLastWriteTime], [filialconfig].[_trackCreationTime], [filialconfig].[_trackLastWriteUser], [filialconfig].[_trackCreationUser] 
    FROM [filialconfig] 

RETURN
GO

CREATE PROCEDURE [dbo].[filialconfig_LoadByFilial]
(
 @oFilialpId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filialconfig].[pId], [filialconfig].[sTipo], [filialconfig].[pConteudo], [filialconfig].[xDataHoraReg], [filialconfig].[xLoginReg], [filialconfig].[oFilial_pId], [filialconfig].[_trackLastWriteTime], [filialconfig].[_trackCreationTime], [filialconfig].[_trackLastWriteUser], [filialconfig].[_trackCreationUser] 
    FROM [filialconfig] 
    WHERE ([filialconfig].[oFilial_pId] = @oFilialpId)

RETURN
GO

CREATE PROCEDURE [dbo].[filialconfig_LoadByFilialTipoConfig]
(
 @oFilialpId [bigint],
 @sTipo [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filialconfig].[pId], [filialconfig].[sTipo], [filialconfig].[pConteudo], [filialconfig].[xDataHoraReg], [filialconfig].[xLoginReg], [filialconfig].[oFilial_pId], [filialconfig].[_trackLastWriteTime], [filialconfig].[_trackCreationTime], [filialconfig].[_trackLastWriteUser], [filialconfig].[_trackCreationUser] 
    FROM [filialconfig] 
    WHERE (([filialconfig].[oFilial_pId] = @oFilialpId) AND ([filialconfig].[sTipo] = @sTipo))

RETURN
GO

CREATE PROCEDURE [dbo].[filialconfig_LoadByoFilial]
(
 @oFilialpId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filialconfig].[pId], [filialconfig].[sTipo], [filialconfig].[pConteudo], [filialconfig].[xDataHoraReg], [filialconfig].[xLoginReg], [filialconfig].[oFilial_pId], [filialconfig].[_trackLastWriteTime], [filialconfig].[_trackCreationTime], [filialconfig].[_trackLastWriteUser], [filialconfig].[_trackCreationUser] 
    FROM [filialconfig] 
    WHERE ([filialconfig].[oFilial_pId] = @oFilialpId)

RETURN
GO

CREATE PROCEDURE [dbo].[filialconfig_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filialconfig].[pId], [filialconfig].[sTipo], [filialconfig].[pConteudo], [filialconfig].[xDataHoraReg], [filialconfig].[xLoginReg], [filialconfig].[oFilial_pId], [filialconfig].[_trackLastWriteTime], [filialconfig].[_trackCreationTime], [filialconfig].[_trackLastWriteUser], [filialconfig].[_trackCreationUser] 
    FROM [filialconfig] 
    WHERE ([filialconfig].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[filialconfig_LoadByTipo]
(
 @parTipo [int],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [filialconfig].[pId], [filialconfig].[sTipo], [filialconfig].[pConteudo], [filialconfig].[xDataHoraReg], [filialconfig].[xLoginReg], [filialconfig].[oFilial_pId], [filialconfig].[_trackLastWriteTime], [filialconfig].[_trackCreationTime], [filialconfig].[_trackLastWriteUser], [filialconfig].[_trackCreationUser] 
    FROM [filialconfig] 
    WHERE ([filialconfig].[sTipo] = @parTipo)

RETURN
GO

CREATE PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [HISTORICO_PROPRIEDADE].[pId], [HISTORICO_PROPRIEDADE].[ID_NEGOCIOS], [HISTORICO_PROPRIEDADE].[SAFRA], [HISTORICO_PROPRIEDADE].[COD_PROPRIEDADE], [HISTORICO_PROPRIEDADE].[DSC_PROPRIEDADE], [HISTORICO_PROPRIEDADE].[TALHAO], [HISTORICO_PROPRIEDADE].[RENDIMENTO_PLAN], [HISTORICO_PROPRIEDADE].[CORTE], [HISTORICO_PROPRIEDADE].[AMBIENTE], [HISTORICO_PROPRIEDADE].[DT_PLANTIO], [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ANT], [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ATU], [HISTORICO_PROPRIEDADE].[AREA_TOTAL], [HISTORICO_PROPRIEDADE].[AREA_LIBERADA], [HISTORICO_PROPRIEDADE].[TONELADA], [HISTORICO_PROPRIEDADE].[RENDIMENTO_REAL], [HISTORICO_PROPRIEDADE].[TCH], [HISTORICO_PROPRIEDADE].[IDADE], [HISTORICO_PROPRIEDADE].[PERC_BROCA], [HISTORICO_PROPRIEDADE].[PERC_PERDA], [HISTORICO_PROPRIEDADE].[_trackLastWriteTime], [HISTORICO_PROPRIEDADE].[_trackCreationTime], [HISTORICO_PROPRIEDADE].[_trackLastWriteUser], [HISTORICO_PROPRIEDADE].[_trackCreationUser] 
    FROM [HISTORICO_PROPRIEDADE] 
    WHERE ([HISTORICO_PROPRIEDADE].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [HISTORICO_PROPRIEDADE].[pId], [HISTORICO_PROPRIEDADE].[ID_NEGOCIOS], [HISTORICO_PROPRIEDADE].[SAFRA], [HISTORICO_PROPRIEDADE].[COD_PROPRIEDADE], [HISTORICO_PROPRIEDADE].[DSC_PROPRIEDADE], [HISTORICO_PROPRIEDADE].[TALHAO], [HISTORICO_PROPRIEDADE].[RENDIMENTO_PLAN], [HISTORICO_PROPRIEDADE].[CORTE], [HISTORICO_PROPRIEDADE].[AMBIENTE], [HISTORICO_PROPRIEDADE].[DT_PLANTIO], [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ANT], [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ATU], [HISTORICO_PROPRIEDADE].[AREA_TOTAL], [HISTORICO_PROPRIEDADE].[AREA_LIBERADA], [HISTORICO_PROPRIEDADE].[TONELADA], [HISTORICO_PROPRIEDADE].[RENDIMENTO_REAL], [HISTORICO_PROPRIEDADE].[TCH], [HISTORICO_PROPRIEDADE].[IDADE], [HISTORICO_PROPRIEDADE].[PERC_BROCA], [HISTORICO_PROPRIEDADE].[PERC_PERDA], [HISTORICO_PROPRIEDADE].[_trackLastWriteTime], [HISTORICO_PROPRIEDADE].[_trackCreationTime], [HISTORICO_PROPRIEDADE].[_trackLastWriteUser], [HISTORICO_PROPRIEDADE].[_trackCreationUser] 
    FROM [HISTORICO_PROPRIEDADE] 

RETURN
GO

CREATE PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [HISTORICO_PROPRIEDADE].[pId], [HISTORICO_PROPRIEDADE].[ID_NEGOCIOS], [HISTORICO_PROPRIEDADE].[SAFRA], [HISTORICO_PROPRIEDADE].[COD_PROPRIEDADE], [HISTORICO_PROPRIEDADE].[DSC_PROPRIEDADE], [HISTORICO_PROPRIEDADE].[TALHAO], [HISTORICO_PROPRIEDADE].[RENDIMENTO_PLAN], [HISTORICO_PROPRIEDADE].[CORTE], [HISTORICO_PROPRIEDADE].[AMBIENTE], [HISTORICO_PROPRIEDADE].[DT_PLANTIO], [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ANT], [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ATU], [HISTORICO_PROPRIEDADE].[AREA_TOTAL], [HISTORICO_PROPRIEDADE].[AREA_LIBERADA], [HISTORICO_PROPRIEDADE].[TONELADA], [HISTORICO_PROPRIEDADE].[RENDIMENTO_REAL], [HISTORICO_PROPRIEDADE].[TCH], [HISTORICO_PROPRIEDADE].[IDADE], [HISTORICO_PROPRIEDADE].[PERC_BROCA], [HISTORICO_PROPRIEDADE].[PERC_PERDA], [HISTORICO_PROPRIEDADE].[_trackLastWriteTime], [HISTORICO_PROPRIEDADE].[_trackCreationTime], [HISTORICO_PROPRIEDADE].[_trackLastWriteUser], [HISTORICO_PROPRIEDADE].[_trackCreationUser] 
    FROM [HISTORICO_PROPRIEDADE] 
    WHERE ([HISTORICO_PROPRIEDADE].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_TRATOS_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [HISTORICO_PROPRIEDADE_TRATOS].[pId], [HISTORICO_PROPRIEDADE_TRATOS].[ID_NEGOCIOS], [HISTORICO_PROPRIEDADE_TRATOS].[SAFRA], [HISTORICO_PROPRIEDADE_TRATOS].[COD_PROPRIEDADE], [HISTORICO_PROPRIEDADE_TRATOS].[DSC_PROPRIEDADE], [HISTORICO_PROPRIEDADE_TRATOS].[TALHAO], [HISTORICO_PROPRIEDADE_TRATOS].[CORTE], [HISTORICO_PROPRIEDADE_TRATOS].[AMBIENTE], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_DIS], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_MUDA], [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ANT], [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ATU], [HISTORICO_PROPRIEDADE_TRATOS].[ATIVIDADE], [HISTORICO_PROPRIEDADE_TRATOS].[DSC_ATIVIDADE], [HISTORICO_PROPRIEDADE_TRATOS].[NRO_RECOM], [HISTORICO_PROPRIEDADE_TRATOS].[DATA_APLICACAO], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_APLICADA], [HISTORICO_PROPRIEDADE_TRATOS].[TOTAL_TALHAO_DISP], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_DISP], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_MUDA], [HISTORICO_PROPRIEDADE_TRATOS].[GRUPO_SUBGRUPO_AGR], [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteTime], [HISTORICO_PROPRIEDADE_TRATOS].[_trackCreationTime], [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteUser], [HISTORICO_PROPRIEDADE_TRATOS].[_trackCreationUser] 
    FROM [HISTORICO_PROPRIEDADE_TRATOS] 
    WHERE ([HISTORICO_PROPRIEDADE_TRATOS].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_TRATOS_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [HISTORICO_PROPRIEDADE_TRATOS].[pId], [HISTORICO_PROPRIEDADE_TRATOS].[ID_NEGOCIOS], [HISTORICO_PROPRIEDADE_TRATOS].[SAFRA], [HISTORICO_PROPRIEDADE_TRATOS].[COD_PROPRIEDADE], [HISTORICO_PROPRIEDADE_TRATOS].[DSC_PROPRIEDADE], [HISTORICO_PROPRIEDADE_TRATOS].[TALHAO], [HISTORICO_PROPRIEDADE_TRATOS].[CORTE], [HISTORICO_PROPRIEDADE_TRATOS].[AMBIENTE], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_DIS], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_MUDA], [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ANT], [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ATU], [HISTORICO_PROPRIEDADE_TRATOS].[ATIVIDADE], [HISTORICO_PROPRIEDADE_TRATOS].[DSC_ATIVIDADE], [HISTORICO_PROPRIEDADE_TRATOS].[NRO_RECOM], [HISTORICO_PROPRIEDADE_TRATOS].[DATA_APLICACAO], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_APLICADA], [HISTORICO_PROPRIEDADE_TRATOS].[TOTAL_TALHAO_DISP], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_DISP], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_MUDA], [HISTORICO_PROPRIEDADE_TRATOS].[GRUPO_SUBGRUPO_AGR], [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteTime], [HISTORICO_PROPRIEDADE_TRATOS].[_trackCreationTime], [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteUser], [HISTORICO_PROPRIEDADE_TRATOS].[_trackCreationUser] 
    FROM [HISTORICO_PROPRIEDADE_TRATOS] 

RETURN
GO

CREATE PROCEDURE [dbo].[HISTORICO_PROPRIEDADE_TRATOS_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [HISTORICO_PROPRIEDADE_TRATOS].[pId], [HISTORICO_PROPRIEDADE_TRATOS].[ID_NEGOCIOS], [HISTORICO_PROPRIEDADE_TRATOS].[SAFRA], [HISTORICO_PROPRIEDADE_TRATOS].[COD_PROPRIEDADE], [HISTORICO_PROPRIEDADE_TRATOS].[DSC_PROPRIEDADE], [HISTORICO_PROPRIEDADE_TRATOS].[TALHAO], [HISTORICO_PROPRIEDADE_TRATOS].[CORTE], [HISTORICO_PROPRIEDADE_TRATOS].[AMBIENTE], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_DIS], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_MUDA], [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ANT], [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ATU], [HISTORICO_PROPRIEDADE_TRATOS].[ATIVIDADE], [HISTORICO_PROPRIEDADE_TRATOS].[DSC_ATIVIDADE], [HISTORICO_PROPRIEDADE_TRATOS].[NRO_RECOM], [HISTORICO_PROPRIEDADE_TRATOS].[DATA_APLICACAO], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_APLICADA], [HISTORICO_PROPRIEDADE_TRATOS].[TOTAL_TALHAO_DISP], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_DISP], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_MUDA], [HISTORICO_PROPRIEDADE_TRATOS].[GRUPO_SUBGRUPO_AGR], [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteTime], [HISTORICO_PROPRIEDADE_TRATOS].[_trackCreationTime], [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteUser], [HISTORICO_PROPRIEDADE_TRATOS].[_trackCreationUser] 
    FROM [HISTORICO_PROPRIEDADE_TRATOS] 
    WHERE ([HISTORICO_PROPRIEDADE_TRATOS].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[IdRole_Load]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdRole].[Id], [IdRole].[Name], [IdRole].[_trackLastWriteTime], [IdRole].[_trackCreationTime], [IdRole].[_trackLastWriteUser], [IdRole].[_trackCreationUser] 
    FROM [IdRole] 
    WHERE ([IdRole].[Id] = @Id)

RETURN
GO

CREATE PROCEDURE [dbo].[IdRole_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdRole].[Id], [IdRole].[Name], [IdRole].[_trackLastWriteTime], [IdRole].[_trackCreationTime], [IdRole].[_trackLastWriteUser], [IdRole].[_trackCreationUser] 
    FROM [IdRole] 

RETURN
GO

CREATE PROCEDURE [dbo].[IdRole_LoadByName]
(
 @Name [nvarchar] (256)
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdRole].[Id], [IdRole].[Name], [IdRole].[_trackLastWriteTime], [IdRole].[_trackCreationTime], [IdRole].[_trackLastWriteUser], [IdRole].[_trackCreationUser] 
    FROM [IdRole] 
    WHERE ([IdRole].[Name] = @Name)

RETURN
GO

CREATE PROCEDURE [dbo].[IdRole_LoadRolesUsersByIdUser]
(
 @IdUserId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdRole].[Id], [IdRole].[Name], [IdRole].[_trackLastWriteTime], [IdRole].[_trackCreationTime], [IdRole].[_trackLastWriteUser], [IdRole].[_trackCreationUser] 
    FROM [IdRole]
        LEFT OUTER JOIN [IdRole_Users_IdUser_Roles] ON ([IdRole].[Id] = [IdRole_Users_IdUser_Roles].[Id])
                LEFT OUTER JOIN [IdUser] ON ([IdRole_Users_IdUser_Roles].[Id2] = [IdUser].[Id]) 
    WHERE ([IdRole_Users_IdUser_Roles].[Id2] = @IdUserId)

RETURN
GO

CREATE PROCEDURE [dbo].[IdRoleClaim_Load]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdRoleClaim].[Id], [IdRoleClaim].[Type], [IdRoleClaim].[Value], [IdRoleClaim].[ValueType], [IdRoleClaim].[Role_Id], [IdRoleClaim].[_trackLastWriteTime], [IdRoleClaim].[_trackCreationTime], [IdRoleClaim].[_trackLastWriteUser], [IdRoleClaim].[_trackCreationUser] 
    FROM [IdRoleClaim] 
    WHERE ([IdRoleClaim].[Id] = @Id)

RETURN
GO

CREATE PROCEDURE [dbo].[IdRoleClaim_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdRoleClaim].[Id], [IdRoleClaim].[Type], [IdRoleClaim].[Value], [IdRoleClaim].[ValueType], [IdRoleClaim].[Role_Id], [IdRoleClaim].[_trackLastWriteTime], [IdRoleClaim].[_trackCreationTime], [IdRoleClaim].[_trackLastWriteUser], [IdRoleClaim].[_trackCreationUser] 
    FROM [IdRoleClaim] 

RETURN
GO

CREATE PROCEDURE [dbo].[IdRoleClaim_LoadById]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdRoleClaim].[Id], [IdRoleClaim].[Type], [IdRoleClaim].[Value], [IdRoleClaim].[ValueType], [IdRoleClaim].[Role_Id], [IdRoleClaim].[_trackLastWriteTime], [IdRoleClaim].[_trackCreationTime], [IdRoleClaim].[_trackLastWriteUser], [IdRoleClaim].[_trackCreationUser] 
    FROM [IdRoleClaim] 
    WHERE ([IdRoleClaim].[Id] = @Id)

RETURN
GO

CREATE PROCEDURE [dbo].[IdRoleClaim_LoadByRole]
(
 @RoleId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdRoleClaim].[Id], [IdRoleClaim].[Type], [IdRoleClaim].[Value], [IdRoleClaim].[ValueType], [IdRoleClaim].[Role_Id], [IdRoleClaim].[_trackLastWriteTime], [IdRoleClaim].[_trackCreationTime], [IdRoleClaim].[_trackLastWriteUser], [IdRoleClaim].[_trackCreationUser] 
    FROM [IdRoleClaim] 
    WHERE ([IdRoleClaim].[Role_Id] = @RoleId)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_Load]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUser].[Id], [IdUser].[UserName], [IdUser].[CreationDateUTC], [IdUser].[Email], [IdUser].[EmailConfirmed], [IdUser].[PhoneNumber], [IdUser].[PhoneNumberConfirmed], [IdUser].[Password], [IdUser].[LastPasswordChangeDate], [IdUser].[AccessFailedCount], [IdUser].[AccessFailedWindowStart], [IdUser].[LockoutEnabled], [IdUser].[LockoutEndDateUtc], [IdUser].[LastProfileUpdateDate], [IdUser].[SecurityStamp], [IdUser].[TwoFactorEnabled], [IdUser].[oUsuario_pId], [IdUser].[_trackLastWriteTime], [IdUser].[_trackCreationTime], [IdUser].[_trackLastWriteUser], [IdUser].[_trackCreationUser] 
    FROM [IdUser] 
    WHERE ([IdUser].[Id] = @Id)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUser].[Id], [IdUser].[UserName], [IdUser].[CreationDateUTC], [IdUser].[Email], [IdUser].[EmailConfirmed], [IdUser].[PhoneNumber], [IdUser].[PhoneNumberConfirmed], [IdUser].[Password], [IdUser].[LastPasswordChangeDate], [IdUser].[AccessFailedCount], [IdUser].[AccessFailedWindowStart], [IdUser].[LockoutEnabled], [IdUser].[LockoutEndDateUtc], [IdUser].[LastProfileUpdateDate], [IdUser].[SecurityStamp], [IdUser].[TwoFactorEnabled], [IdUser].[oUsuario_pId], [IdUser].[_trackLastWriteTime], [IdUser].[_trackCreationTime], [IdUser].[_trackLastWriteUser], [IdUser].[_trackCreationUser] 
    FROM [IdUser] 

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_LoadByEmail]
(
 @Email [nvarchar] (256)
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUser].[Id], [IdUser].[UserName], [IdUser].[CreationDateUTC], [IdUser].[Email], [IdUser].[EmailConfirmed], [IdUser].[PhoneNumber], [IdUser].[PhoneNumberConfirmed], [IdUser].[Password], [IdUser].[LastPasswordChangeDate], [IdUser].[AccessFailedCount], [IdUser].[AccessFailedWindowStart], [IdUser].[LockoutEnabled], [IdUser].[LockoutEndDateUtc], [IdUser].[LastProfileUpdateDate], [IdUser].[SecurityStamp], [IdUser].[TwoFactorEnabled], [IdUser].[oUsuario_pId], [IdUser].[_trackLastWriteTime], [IdUser].[_trackCreationTime], [IdUser].[_trackLastWriteUser], [IdUser].[_trackCreationUser] 
    FROM [IdUser] 
    WHERE ([IdUser].[Email] = @Email)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_LoadByoUsuario]
(
 @oUsuariopId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUser].[Id], [IdUser].[UserName], [IdUser].[CreationDateUTC], [IdUser].[Email], [IdUser].[EmailConfirmed], [IdUser].[PhoneNumber], [IdUser].[PhoneNumberConfirmed], [IdUser].[Password], [IdUser].[LastPasswordChangeDate], [IdUser].[AccessFailedCount], [IdUser].[AccessFailedWindowStart], [IdUser].[LockoutEnabled], [IdUser].[LockoutEndDateUtc], [IdUser].[LastProfileUpdateDate], [IdUser].[SecurityStamp], [IdUser].[TwoFactorEnabled], [IdUser].[oUsuario_pId], [IdUser].[_trackLastWriteTime], [IdUser].[_trackCreationTime], [IdUser].[_trackLastWriteUser], [IdUser].[_trackCreationUser] 
    FROM [IdUser] 
    WHERE ([IdUser].[oUsuario_pId] = @oUsuariopId)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_LoadByUserLoginInfo]
(
 @providerKey [nvarchar] (256),
 @providerName [nvarchar] (256)
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUser].[Id], [IdUser].[UserName], [IdUser].[CreationDateUTC], [IdUser].[Email], [IdUser].[EmailConfirmed], [IdUser].[PhoneNumber], [IdUser].[PhoneNumberConfirmed], [IdUser].[Password], [IdUser].[LastPasswordChangeDate], [IdUser].[AccessFailedCount], [IdUser].[AccessFailedWindowStart], [IdUser].[LockoutEnabled], [IdUser].[LockoutEndDateUtc], [IdUser].[LastProfileUpdateDate], [IdUser].[SecurityStamp], [IdUser].[TwoFactorEnabled], [IdUser].[oUsuario_pId], [IdUser].[_trackLastWriteTime], [IdUser].[_trackCreationTime], [IdUser].[_trackLastWriteUser], [IdUser].[_trackCreationUser] 
    FROM [IdUser]
        LEFT OUTER JOIN [IdUserLogin] ON ([IdUser].[Id] = [IdUserLogin].[User_Id]) 
    WHERE (([IdUserLogin].[ProviderKey] = @providerKey) AND ([IdUserLogin].[ProviderName] = @providerName))

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_LoadByUserName]
(
 @UserName [nvarchar] (256)
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUser].[Id], [IdUser].[UserName], [IdUser].[CreationDateUTC], [IdUser].[Email], [IdUser].[EmailConfirmed], [IdUser].[PhoneNumber], [IdUser].[PhoneNumberConfirmed], [IdUser].[Password], [IdUser].[LastPasswordChangeDate], [IdUser].[AccessFailedCount], [IdUser].[AccessFailedWindowStart], [IdUser].[LockoutEnabled], [IdUser].[LockoutEndDateUtc], [IdUser].[LastProfileUpdateDate], [IdUser].[SecurityStamp], [IdUser].[TwoFactorEnabled], [IdUser].[oUsuario_pId], [IdUser].[_trackLastWriteTime], [IdUser].[_trackCreationTime], [IdUser].[_trackLastWriteUser], [IdUser].[_trackCreationUser] 
    FROM [IdUser] 
    WHERE ([IdUser].[UserName] = @UserName)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUser_LoadUsersRolesByIdRole]
(
 @IdRoleId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUser].[Id], [IdUser].[UserName], [IdUser].[CreationDateUTC], [IdUser].[Email], [IdUser].[EmailConfirmed], [IdUser].[PhoneNumber], [IdUser].[PhoneNumberConfirmed], [IdUser].[Password], [IdUser].[LastPasswordChangeDate], [IdUser].[AccessFailedCount], [IdUser].[AccessFailedWindowStart], [IdUser].[LockoutEnabled], [IdUser].[LockoutEndDateUtc], [IdUser].[LastProfileUpdateDate], [IdUser].[SecurityStamp], [IdUser].[TwoFactorEnabled], [IdUser].[oUsuario_pId], [IdUser].[_trackLastWriteTime], [IdUser].[_trackCreationTime], [IdUser].[_trackLastWriteUser], [IdUser].[_trackCreationUser] 
    FROM [IdUser]
        LEFT OUTER JOIN [IdRole_Users_IdUser_Roles] ON ([IdUser].[Id] = [IdRole_Users_IdUser_Roles].[Id2])
                LEFT OUTER JOIN [IdRole] ON ([IdRole_Users_IdUser_Roles].[Id] = [IdRole].[Id]) 
    WHERE ([IdRole_Users_IdUser_Roles].[Id] = @IdRoleId)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserClaim_DeleteByClaim]
(
 @Type [nvarchar] (256),
 @Value [nvarchar] (256)
)
AS
SET NOCOUNT ON
DECLARE @deletedcount int
DELETE [IdUserClaim] FROM [IdUserClaim] 
    WHERE (([IdUserClaim].[Type] = @Type) AND ([IdUserClaim].[Value] = @Value))
SELECT @deletedcount = @@ROWCOUNT

SELECT @deletedcount 
RETURN
GO

CREATE PROCEDURE [dbo].[IdUserClaim_Load]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUserClaim].[Id], [IdUserClaim].[Type], [IdUserClaim].[Value], [IdUserClaim].[ValueType], [IdUserClaim].[Issuer], [IdUserClaim].[OriginalIssuer], [IdUserClaim].[User_Id], [IdUserClaim].[_trackLastWriteTime], [IdUserClaim].[_trackCreationTime], [IdUserClaim].[_trackLastWriteUser], [IdUserClaim].[_trackCreationUser] 
    FROM [IdUserClaim] 
    WHERE ([IdUserClaim].[Id] = @Id)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserClaim_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUserClaim].[Id], [IdUserClaim].[Type], [IdUserClaim].[Value], [IdUserClaim].[ValueType], [IdUserClaim].[Issuer], [IdUserClaim].[OriginalIssuer], [IdUserClaim].[User_Id], [IdUserClaim].[_trackLastWriteTime], [IdUserClaim].[_trackCreationTime], [IdUserClaim].[_trackLastWriteUser], [IdUserClaim].[_trackCreationUser] 
    FROM [IdUserClaim] 

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserClaim_LoadByClaim]
(
 @Type [nvarchar] (256),
 @Value [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUserClaim].[Id], [IdUserClaim].[Type], [IdUserClaim].[Value], [IdUserClaim].[ValueType], [IdUserClaim].[Issuer], [IdUserClaim].[OriginalIssuer], [IdUserClaim].[User_Id], [IdUserClaim].[_trackLastWriteTime], [IdUserClaim].[_trackCreationTime], [IdUserClaim].[_trackLastWriteUser], [IdUserClaim].[_trackCreationUser] 
    FROM [IdUserClaim] 
    WHERE (([IdUserClaim].[Type] = @Type) AND ([IdUserClaim].[Value] = @Value))

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserClaim_LoadById]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUserClaim].[Id], [IdUserClaim].[Type], [IdUserClaim].[Value], [IdUserClaim].[ValueType], [IdUserClaim].[Issuer], [IdUserClaim].[OriginalIssuer], [IdUserClaim].[User_Id], [IdUserClaim].[_trackLastWriteTime], [IdUserClaim].[_trackCreationTime], [IdUserClaim].[_trackLastWriteUser], [IdUserClaim].[_trackCreationUser] 
    FROM [IdUserClaim] 
    WHERE ([IdUserClaim].[Id] = @Id)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserClaim_LoadByUser]
(
 @UserId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUserClaim].[Id], [IdUserClaim].[Type], [IdUserClaim].[Value], [IdUserClaim].[ValueType], [IdUserClaim].[Issuer], [IdUserClaim].[OriginalIssuer], [IdUserClaim].[User_Id], [IdUserClaim].[_trackLastWriteTime], [IdUserClaim].[_trackCreationTime], [IdUserClaim].[_trackLastWriteUser], [IdUserClaim].[_trackCreationUser] 
    FROM [IdUserClaim] 
    WHERE ([IdUserClaim].[User_Id] = @UserId)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserLogin_DeleteByUserLoginInfo]
(
 @UserId [bigint],
 @ProviderKey [nvarchar] (256),
 @ProviderName [nvarchar] (256)
)
AS
SET NOCOUNT ON
DECLARE @deletedcount int
DELETE [IdUserLogin] FROM [IdUserLogin] 
    WHERE (([IdUserLogin].[User_Id] = @UserId) AND (([IdUserLogin].[ProviderKey] = @ProviderKey) AND ([IdUserLogin].[ProviderName] = @ProviderName)))
SELECT @deletedcount = @@ROWCOUNT

SELECT @deletedcount 
RETURN
GO

CREATE PROCEDURE [dbo].[IdUserLogin_Load]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUserLogin].[Id], [IdUserLogin].[ProviderName], [IdUserLogin].[ProviderKey], [IdUserLogin].[ProviderDisplayName], [IdUserLogin].[User_Id], [IdUserLogin].[_trackLastWriteTime], [IdUserLogin].[_trackCreationTime], [IdUserLogin].[_trackLastWriteUser], [IdUserLogin].[_trackCreationUser] 
    FROM [IdUserLogin] 
    WHERE ([IdUserLogin].[Id] = @Id)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserLogin_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUserLogin].[Id], [IdUserLogin].[ProviderName], [IdUserLogin].[ProviderKey], [IdUserLogin].[ProviderDisplayName], [IdUserLogin].[User_Id], [IdUserLogin].[_trackLastWriteTime], [IdUserLogin].[_trackCreationTime], [IdUserLogin].[_trackLastWriteUser], [IdUserLogin].[_trackCreationUser] 
    FROM [IdUserLogin] 

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserLogin_LoadById]
(
 @Id [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUserLogin].[Id], [IdUserLogin].[ProviderName], [IdUserLogin].[ProviderKey], [IdUserLogin].[ProviderDisplayName], [IdUserLogin].[User_Id], [IdUserLogin].[_trackLastWriteTime], [IdUserLogin].[_trackCreationTime], [IdUserLogin].[_trackLastWriteUser], [IdUserLogin].[_trackCreationUser] 
    FROM [IdUserLogin] 
    WHERE ([IdUserLogin].[Id] = @Id)

RETURN
GO

CREATE PROCEDURE [dbo].[IdUserLogin_LoadByUser]
(
 @UserId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [IdUserLogin].[Id], [IdUserLogin].[ProviderName], [IdUserLogin].[ProviderKey], [IdUserLogin].[ProviderDisplayName], [IdUserLogin].[User_Id], [IdUserLogin].[_trackLastWriteTime], [IdUserLogin].[_trackCreationTime], [IdUserLogin].[_trackLastWriteUser], [IdUserLogin].[_trackCreationUser] 
    FROM [IdUserLogin] 
    WHERE ([IdUserLogin].[User_Id] = @UserId)

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA_EQUIP].[pId], [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPO], [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPOAUX], [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTE], [INDICADORES_AGRICOLA_EQUIP].[DS_TIPO], [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTETIPO], [INDICADORES_AGRICOLA_EQUIP].[ID_NEGOCIOS], [INDICADORES_AGRICOLA_EQUIP].[FRENTE], [INDICADORES_AGRICOLA_EQUIP].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA_EQUIP].[TIPO], [INDICADORES_AGRICOLA_EQUIP].[GRUPO], [INDICADORES_AGRICOLA_EQUIP].[DSC_EQUIPAMENTO], [INDICADORES_AGRICOLA_EQUIP].[NRO_EQUIPAMENTO], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_COLHEDORA], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_DEMAIS], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTH], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELKML], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTTON], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_HIDRAULICO], [INDICADORES_AGRICOLA_EQUIP].[R_TEMPO_APROVEIT_COLHEDORA], [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteTime], [INDICADORES_AGRICOLA_EQUIP].[_trackCreationTime], [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteUser], [INDICADORES_AGRICOLA_EQUIP].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA_EQUIP] 
    WHERE ([INDICADORES_AGRICOLA_EQUIP].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA_EQUIP].[pId], [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPO], [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPOAUX], [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTE], [INDICADORES_AGRICOLA_EQUIP].[DS_TIPO], [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTETIPO], [INDICADORES_AGRICOLA_EQUIP].[ID_NEGOCIOS], [INDICADORES_AGRICOLA_EQUIP].[FRENTE], [INDICADORES_AGRICOLA_EQUIP].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA_EQUIP].[TIPO], [INDICADORES_AGRICOLA_EQUIP].[GRUPO], [INDICADORES_AGRICOLA_EQUIP].[DSC_EQUIPAMENTO], [INDICADORES_AGRICOLA_EQUIP].[NRO_EQUIPAMENTO], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_COLHEDORA], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_DEMAIS], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTH], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELKML], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTTON], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_HIDRAULICO], [INDICADORES_AGRICOLA_EQUIP].[R_TEMPO_APROVEIT_COLHEDORA], [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteTime], [INDICADORES_AGRICOLA_EQUIP].[_trackCreationTime], [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteUser], [INDICADORES_AGRICOLA_EQUIP].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA_EQUIP] 

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_LoadByFRENTETIPOAUX_DATA_REF]
(
 @parFRENTETIPOAUX [nvarchar] (256),
 @parDATA_FECHAMENTO [date],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA_EQUIP].[pId], [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPO], [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPOAUX], [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTE], [INDICADORES_AGRICOLA_EQUIP].[DS_TIPO], [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTETIPO], [INDICADORES_AGRICOLA_EQUIP].[ID_NEGOCIOS], [INDICADORES_AGRICOLA_EQUIP].[FRENTE], [INDICADORES_AGRICOLA_EQUIP].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA_EQUIP].[TIPO], [INDICADORES_AGRICOLA_EQUIP].[GRUPO], [INDICADORES_AGRICOLA_EQUIP].[DSC_EQUIPAMENTO], [INDICADORES_AGRICOLA_EQUIP].[NRO_EQUIPAMENTO], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_COLHEDORA], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_DEMAIS], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTH], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELKML], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTTON], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_HIDRAULICO], [INDICADORES_AGRICOLA_EQUIP].[R_TEMPO_APROVEIT_COLHEDORA], [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteTime], [INDICADORES_AGRICOLA_EQUIP].[_trackCreationTime], [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteUser], [INDICADORES_AGRICOLA_EQUIP].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA_EQUIP] 
    WHERE (([INDICADORES_AGRICOLA_EQUIP].[FRENTETIPOAUX] = @parFRENTETIPOAUX) AND ([INDICADORES_AGRICOLA_EQUIP].[DATA_FECHAMENTO] = @parDATA_FECHAMENTO))

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_EQUIP_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA_EQUIP].[pId], [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPO], [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPOAUX], [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTE], [INDICADORES_AGRICOLA_EQUIP].[DS_TIPO], [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTETIPO], [INDICADORES_AGRICOLA_EQUIP].[ID_NEGOCIOS], [INDICADORES_AGRICOLA_EQUIP].[FRENTE], [INDICADORES_AGRICOLA_EQUIP].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA_EQUIP].[TIPO], [INDICADORES_AGRICOLA_EQUIP].[GRUPO], [INDICADORES_AGRICOLA_EQUIP].[DSC_EQUIPAMENTO], [INDICADORES_AGRICOLA_EQUIP].[NRO_EQUIPAMENTO], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_COLHEDORA], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_DEMAIS], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTH], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELKML], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTTON], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_HIDRAULICO], [INDICADORES_AGRICOLA_EQUIP].[R_TEMPO_APROVEIT_COLHEDORA], [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteTime], [INDICADORES_AGRICOLA_EQUIP].[_trackCreationTime], [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteUser], [INDICADORES_AGRICOLA_EQUIP].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA_EQUIP] 
    WHERE ([INDICADORES_AGRICOLA_EQUIP].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA].[pId], [INDICADORES_AGRICOLA].[NOTACALC], [INDICADORES_AGRICOLA].[FRENTETIPO], [INDICADORES_AGRICOLA].[FRENTETIPOAUX], [INDICADORES_AGRICOLA].[DS_FRENTE], [INDICADORES_AGRICOLA].[DS_TIPO], [INDICADORES_AGRICOLA].[DS_FRENTETIPO], [INDICADORES_AGRICOLA].[ID_NEGOCIOS], [INDICADORES_AGRICOLA].[INDICADOR], [INDICADORES_AGRICOLA].[FRENTE], [INDICADORES_AGRICOLA].[PLANEJADO], [INDICADORES_AGRICOLA].[REALIZADO], [INDICADORES_AGRICOLA].[PERC], [INDICADORES_AGRICOLA].[NOTA], [INDICADORES_AGRICOLA].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA].[UNIDADE_MEDIDA], [INDICADORES_AGRICOLA].[PERC_ABAIXO_META], [INDICADORES_AGRICOLA].[PERC_ACIMA_META], [INDICADORES_AGRICOLA].[TIPO], [INDICADORES_AGRICOLA].[GRUPO], [INDICADORES_AGRICOLA].[_trackLastWriteTime], [INDICADORES_AGRICOLA].[_trackCreationTime], [INDICADORES_AGRICOLA].[_trackLastWriteUser], [INDICADORES_AGRICOLA].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA] 
    WHERE ([INDICADORES_AGRICOLA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA].[pId], [INDICADORES_AGRICOLA].[NOTACALC], [INDICADORES_AGRICOLA].[FRENTETIPO], [INDICADORES_AGRICOLA].[FRENTETIPOAUX], [INDICADORES_AGRICOLA].[DS_FRENTE], [INDICADORES_AGRICOLA].[DS_TIPO], [INDICADORES_AGRICOLA].[DS_FRENTETIPO], [INDICADORES_AGRICOLA].[ID_NEGOCIOS], [INDICADORES_AGRICOLA].[INDICADOR], [INDICADORES_AGRICOLA].[FRENTE], [INDICADORES_AGRICOLA].[PLANEJADO], [INDICADORES_AGRICOLA].[REALIZADO], [INDICADORES_AGRICOLA].[PERC], [INDICADORES_AGRICOLA].[NOTA], [INDICADORES_AGRICOLA].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA].[UNIDADE_MEDIDA], [INDICADORES_AGRICOLA].[PERC_ABAIXO_META], [INDICADORES_AGRICOLA].[PERC_ACIMA_META], [INDICADORES_AGRICOLA].[TIPO], [INDICADORES_AGRICOLA].[GRUPO], [INDICADORES_AGRICOLA].[_trackLastWriteTime], [INDICADORES_AGRICOLA].[_trackCreationTime], [INDICADORES_AGRICOLA].[_trackLastWriteUser], [INDICADORES_AGRICOLA].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA] 

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_LoadByDATA_FECHAMENTO]
(
 @parID_NEGOCIOS [int],
 @parDATA_FECHAMENTO [date],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA].[pId], [INDICADORES_AGRICOLA].[NOTACALC], [INDICADORES_AGRICOLA].[FRENTETIPO], [INDICADORES_AGRICOLA].[FRENTETIPOAUX], [INDICADORES_AGRICOLA].[DS_FRENTE], [INDICADORES_AGRICOLA].[DS_TIPO], [INDICADORES_AGRICOLA].[DS_FRENTETIPO], [INDICADORES_AGRICOLA].[ID_NEGOCIOS], [INDICADORES_AGRICOLA].[INDICADOR], [INDICADORES_AGRICOLA].[FRENTE], [INDICADORES_AGRICOLA].[PLANEJADO], [INDICADORES_AGRICOLA].[REALIZADO], [INDICADORES_AGRICOLA].[PERC], [INDICADORES_AGRICOLA].[NOTA], [INDICADORES_AGRICOLA].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA].[UNIDADE_MEDIDA], [INDICADORES_AGRICOLA].[PERC_ABAIXO_META], [INDICADORES_AGRICOLA].[PERC_ACIMA_META], [INDICADORES_AGRICOLA].[TIPO], [INDICADORES_AGRICOLA].[GRUPO], [INDICADORES_AGRICOLA].[_trackLastWriteTime], [INDICADORES_AGRICOLA].[_trackCreationTime], [INDICADORES_AGRICOLA].[_trackLastWriteUser], [INDICADORES_AGRICOLA].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA] 
    WHERE (([INDICADORES_AGRICOLA].[ID_NEGOCIOS] = @parID_NEGOCIOS) AND ([INDICADORES_AGRICOLA].[DATA_FECHAMENTO] = @parDATA_FECHAMENTO))

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_LoadByDATA_FECHAMENTO_GRUPO]
(
 @parID_NEGOCIOS [int],
 @parDATA_FECHAMENTO [date],
 @parGRUPO [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA].[pId], [INDICADORES_AGRICOLA].[NOTACALC], [INDICADORES_AGRICOLA].[FRENTETIPO], [INDICADORES_AGRICOLA].[FRENTETIPOAUX], [INDICADORES_AGRICOLA].[DS_FRENTE], [INDICADORES_AGRICOLA].[DS_TIPO], [INDICADORES_AGRICOLA].[DS_FRENTETIPO], [INDICADORES_AGRICOLA].[ID_NEGOCIOS], [INDICADORES_AGRICOLA].[INDICADOR], [INDICADORES_AGRICOLA].[FRENTE], [INDICADORES_AGRICOLA].[PLANEJADO], [INDICADORES_AGRICOLA].[REALIZADO], [INDICADORES_AGRICOLA].[PERC], [INDICADORES_AGRICOLA].[NOTA], [INDICADORES_AGRICOLA].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA].[UNIDADE_MEDIDA], [INDICADORES_AGRICOLA].[PERC_ABAIXO_META], [INDICADORES_AGRICOLA].[PERC_ACIMA_META], [INDICADORES_AGRICOLA].[TIPO], [INDICADORES_AGRICOLA].[GRUPO], [INDICADORES_AGRICOLA].[_trackLastWriteTime], [INDICADORES_AGRICOLA].[_trackCreationTime], [INDICADORES_AGRICOLA].[_trackLastWriteUser], [INDICADORES_AGRICOLA].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA] 
    WHERE (([INDICADORES_AGRICOLA].[ID_NEGOCIOS] = @parID_NEGOCIOS) AND (([INDICADORES_AGRICOLA].[DATA_FECHAMENTO] = @parDATA_FECHAMENTO) AND ([INDICADORES_AGRICOLA].[GRUPO] = @parGRUPO)))

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA].[pId], [INDICADORES_AGRICOLA].[NOTACALC], [INDICADORES_AGRICOLA].[FRENTETIPO], [INDICADORES_AGRICOLA].[FRENTETIPOAUX], [INDICADORES_AGRICOLA].[DS_FRENTE], [INDICADORES_AGRICOLA].[DS_TIPO], [INDICADORES_AGRICOLA].[DS_FRENTETIPO], [INDICADORES_AGRICOLA].[ID_NEGOCIOS], [INDICADORES_AGRICOLA].[INDICADOR], [INDICADORES_AGRICOLA].[FRENTE], [INDICADORES_AGRICOLA].[PLANEJADO], [INDICADORES_AGRICOLA].[REALIZADO], [INDICADORES_AGRICOLA].[PERC], [INDICADORES_AGRICOLA].[NOTA], [INDICADORES_AGRICOLA].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA].[UNIDADE_MEDIDA], [INDICADORES_AGRICOLA].[PERC_ABAIXO_META], [INDICADORES_AGRICOLA].[PERC_ACIMA_META], [INDICADORES_AGRICOLA].[TIPO], [INDICADORES_AGRICOLA].[GRUPO], [INDICADORES_AGRICOLA].[_trackLastWriteTime], [INDICADORES_AGRICOLA].[_trackCreationTime], [INDICADORES_AGRICOLA].[_trackLastWriteUser], [INDICADORES_AGRICOLA].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA] 
    WHERE ([INDICADORES_AGRICOLA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA_TEMPOAPROV].[pId], [INDICADORES_AGRICOLA_TEMPOAPROV].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA_TEMPOAPROV].[PERC_TEMPO_APROV], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteTime], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackCreationTime], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteUser], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA_TEMPOAPROV] 
    WHERE ([INDICADORES_AGRICOLA_TEMPOAPROV].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA_TEMPOAPROV].[pId], [INDICADORES_AGRICOLA_TEMPOAPROV].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA_TEMPOAPROV].[PERC_TEMPO_APROV], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteTime], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackCreationTime], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteUser], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA_TEMPOAPROV] 

RETURN
GO

CREATE PROCEDURE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV_LoadByDATA_FECHAMENTO]
(
 @DATA_FECHAMENTO [date]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INDICADORES_AGRICOLA_TEMPOAPROV].[pId], [INDICADORES_AGRICOLA_TEMPOAPROV].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA_TEMPOAPROV].[PERC_TEMPO_APROV], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteTime], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackCreationTime], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteUser], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackCreationUser] 
    FROM [INDICADORES_AGRICOLA_TEMPOAPROV] 
    WHERE ([INDICADORES_AGRICOLA_TEMPOAPROV].[DATA_FECHAMENTO] = @DATA_FECHAMENTO)

RETURN
GO

CREATE PROCEDURE [dbo].[INFO_GERAIS_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INFO_GERAIS].[pId], [INFO_GERAIS].[FRENTE], [INFO_GERAIS].[PROPRIEDADE], [INFO_GERAIS].[DSC_PROPRIEDADE], [INFO_GERAIS].[COLHEDORA], [INFO_GERAIS].[TONELADA], [INFO_GERAIS].[QTD_VIAGENS], [INFO_GERAIS].[MEDIA_VIAGEM], [INFO_GERAIS].[RAIO_MEDIO], [INFO_GERAIS].[IMP_MINERAL], [INFO_GERAIS].[IMP_VEGETAL_PALHA], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA], [INFO_GERAIS].[IMP_MINERAL1], [INFO_GERAIS].[IMP_MINERAL2], [INFO_GERAIS].[IMP_VEGETAL_PALHA1], [INFO_GERAIS].[IMP_VEGETAL_PALHA2], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA1], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA2], [INFO_GERAIS].[_trackLastWriteTime], [INFO_GERAIS].[_trackCreationTime], [INFO_GERAIS].[_trackLastWriteUser], [INFO_GERAIS].[_trackCreationUser] 
    FROM [INFO_GERAIS] 
    WHERE ([INFO_GERAIS].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[INFO_GERAIS_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INFO_GERAIS].[pId], [INFO_GERAIS].[FRENTE], [INFO_GERAIS].[PROPRIEDADE], [INFO_GERAIS].[DSC_PROPRIEDADE], [INFO_GERAIS].[COLHEDORA], [INFO_GERAIS].[TONELADA], [INFO_GERAIS].[QTD_VIAGENS], [INFO_GERAIS].[MEDIA_VIAGEM], [INFO_GERAIS].[RAIO_MEDIO], [INFO_GERAIS].[IMP_MINERAL], [INFO_GERAIS].[IMP_VEGETAL_PALHA], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA], [INFO_GERAIS].[IMP_MINERAL1], [INFO_GERAIS].[IMP_MINERAL2], [INFO_GERAIS].[IMP_VEGETAL_PALHA1], [INFO_GERAIS].[IMP_VEGETAL_PALHA2], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA1], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA2], [INFO_GERAIS].[_trackLastWriteTime], [INFO_GERAIS].[_trackCreationTime], [INFO_GERAIS].[_trackLastWriteUser], [INFO_GERAIS].[_trackCreationUser] 
    FROM [INFO_GERAIS] 

RETURN
GO

CREATE PROCEDURE [dbo].[INFO_GERAIS_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [INFO_GERAIS].[pId], [INFO_GERAIS].[FRENTE], [INFO_GERAIS].[PROPRIEDADE], [INFO_GERAIS].[DSC_PROPRIEDADE], [INFO_GERAIS].[COLHEDORA], [INFO_GERAIS].[TONELADA], [INFO_GERAIS].[QTD_VIAGENS], [INFO_GERAIS].[MEDIA_VIAGEM], [INFO_GERAIS].[RAIO_MEDIO], [INFO_GERAIS].[IMP_MINERAL], [INFO_GERAIS].[IMP_VEGETAL_PALHA], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA], [INFO_GERAIS].[IMP_MINERAL1], [INFO_GERAIS].[IMP_MINERAL2], [INFO_GERAIS].[IMP_VEGETAL_PALHA1], [INFO_GERAIS].[IMP_VEGETAL_PALHA2], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA1], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA2], [INFO_GERAIS].[_trackLastWriteTime], [INFO_GERAIS].[_trackCreationTime], [INFO_GERAIS].[_trackLastWriteUser], [INFO_GERAIS].[_trackCreationUser] 
    FROM [INFO_GERAIS] 
    WHERE ([INFO_GERAIS].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[loginregistro_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [loginregistro].[pId], [loginregistro].[pDataHora], [loginregistro].[pSenha], [loginregistro].[pObsLog], [loginregistro].[pCodigoUsuario], [loginregistro].[pLoginUsuario], [loginregistro].[pFlgAdminUsuario], [loginregistro].[pCodigoFilial], [loginregistro].[pCodigoEmpresa], [loginregistro].[pLoginValidado], [loginregistro].[sUsuarioStatus], [loginregistro].[_trackLastWriteTime], [loginregistro].[_trackCreationTime], [loginregistro].[_trackLastWriteUser], [loginregistro].[_trackCreationUser] 
    FROM [loginregistro] 
    WHERE ([loginregistro].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[loginregistro_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [loginregistro].[pId], [loginregistro].[pDataHora], [loginregistro].[pSenha], [loginregistro].[pObsLog], [loginregistro].[pCodigoUsuario], [loginregistro].[pLoginUsuario], [loginregistro].[pFlgAdminUsuario], [loginregistro].[pCodigoFilial], [loginregistro].[pCodigoEmpresa], [loginregistro].[pLoginValidado], [loginregistro].[sUsuarioStatus], [loginregistro].[_trackLastWriteTime], [loginregistro].[_trackCreationTime], [loginregistro].[_trackLastWriteUser], [loginregistro].[_trackCreationUser] 
    FROM [loginregistro] 

RETURN
GO

CREATE PROCEDURE [dbo].[loginregistro_LoadByCodUsuario]
(
 @parCodUsuario [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [loginregistro].[pId], [loginregistro].[pDataHora], [loginregistro].[pSenha], [loginregistro].[pObsLog], [loginregistro].[pCodigoUsuario], [loginregistro].[pLoginUsuario], [loginregistro].[pFlgAdminUsuario], [loginregistro].[pCodigoFilial], [loginregistro].[pCodigoEmpresa], [loginregistro].[pLoginValidado], [loginregistro].[sUsuarioStatus], [loginregistro].[_trackLastWriteTime], [loginregistro].[_trackCreationTime], [loginregistro].[_trackLastWriteUser], [loginregistro].[_trackCreationUser] 
    FROM [loginregistro] 
    WHERE (([loginregistro].[pCodigoUsuario] = @parCodUsuario) AND ([loginregistro].[pLoginValidado] = 1))

RETURN
GO

CREATE PROCEDURE [dbo].[loginregistro_LoadByCurrentSession]
(
 @parDataHora [datetime],
 @parLogin [nvarchar] (256)
)
AS
SET NOCOUNT ON
SELECT DISTINCT [loginregistro].[pId], [loginregistro].[pDataHora], [loginregistro].[pSenha], [loginregistro].[pObsLog], [loginregistro].[pCodigoUsuario], [loginregistro].[pLoginUsuario], [loginregistro].[pFlgAdminUsuario], [loginregistro].[pCodigoFilial], [loginregistro].[pCodigoEmpresa], [loginregistro].[pLoginValidado], [loginregistro].[sUsuarioStatus], [loginregistro].[_trackLastWriteTime], [loginregistro].[_trackCreationTime], [loginregistro].[_trackLastWriteUser], [loginregistro].[_trackCreationUser] 
    FROM [loginregistro] 
    WHERE (([loginregistro].[pDataHora] = @parDataHora) AND (([loginregistro].[pLoginUsuario] = @parLogin) AND ([loginregistro].[pLoginValidado] = 1)))

RETURN
GO

CREATE PROCEDURE [dbo].[loginregistro_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [loginregistro].[pId], [loginregistro].[pDataHora], [loginregistro].[pSenha], [loginregistro].[pObsLog], [loginregistro].[pCodigoUsuario], [loginregistro].[pLoginUsuario], [loginregistro].[pFlgAdminUsuario], [loginregistro].[pCodigoFilial], [loginregistro].[pCodigoEmpresa], [loginregistro].[pLoginValidado], [loginregistro].[sUsuarioStatus], [loginregistro].[_trackLastWriteTime], [loginregistro].[_trackCreationTime], [loginregistro].[_trackLastWriteUser], [loginregistro].[_trackCreationUser] 
    FROM [loginregistro] 
    WHERE ([loginregistro].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[MAPA_PLANCOLHEITA_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [MAPA_PLANCOLHEITA].[pId], [MAPA_PLANCOLHEITA].[PROP_CODIGO], [MAPA_PLANCOLHEITA].[DS_NOME_PROPRIEDADE], [MAPA_PLANCOLHEITA].[FRENTE_COLHEITA], [MAPA_PLANCOLHEITA].[MES], [MAPA_PLANCOLHEITA].[SEMANA], [MAPA_PLANCOLHEITA].[MES_SEMANA], [MAPA_PLANCOLHEITA].[SEMANA_PERIODO], [MAPA_PLANCOLHEITA].[REFORMA_PREV], [MAPA_PLANCOLHEITA].[AREA_PREV], [MAPA_PLANCOLHEITA].[TONELADA_PREV], [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA], [MAPA_PLANCOLHEITA].[TONELADA_PREV_REFORMA], [MAPA_PLANCOLHEITA].[AREA_PREV_TOTAL], [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA_TOTAL], [MAPA_PLANCOLHEITA].[_trackLastWriteTime], [MAPA_PLANCOLHEITA].[_trackCreationTime], [MAPA_PLANCOLHEITA].[_trackLastWriteUser], [MAPA_PLANCOLHEITA].[_trackCreationUser] 
    FROM [MAPA_PLANCOLHEITA] 
    WHERE ([MAPA_PLANCOLHEITA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[MAPA_PLANCOLHEITA_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [MAPA_PLANCOLHEITA].[pId], [MAPA_PLANCOLHEITA].[PROP_CODIGO], [MAPA_PLANCOLHEITA].[DS_NOME_PROPRIEDADE], [MAPA_PLANCOLHEITA].[FRENTE_COLHEITA], [MAPA_PLANCOLHEITA].[MES], [MAPA_PLANCOLHEITA].[SEMANA], [MAPA_PLANCOLHEITA].[MES_SEMANA], [MAPA_PLANCOLHEITA].[SEMANA_PERIODO], [MAPA_PLANCOLHEITA].[REFORMA_PREV], [MAPA_PLANCOLHEITA].[AREA_PREV], [MAPA_PLANCOLHEITA].[TONELADA_PREV], [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA], [MAPA_PLANCOLHEITA].[TONELADA_PREV_REFORMA], [MAPA_PLANCOLHEITA].[AREA_PREV_TOTAL], [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA_TOTAL], [MAPA_PLANCOLHEITA].[_trackLastWriteTime], [MAPA_PLANCOLHEITA].[_trackCreationTime], [MAPA_PLANCOLHEITA].[_trackLastWriteUser], [MAPA_PLANCOLHEITA].[_trackCreationUser] 
    FROM [MAPA_PLANCOLHEITA] 

RETURN
GO

CREATE PROCEDURE [dbo].[MAPA_PLANCOLHEITA_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [MAPA_PLANCOLHEITA].[pId], [MAPA_PLANCOLHEITA].[PROP_CODIGO], [MAPA_PLANCOLHEITA].[DS_NOME_PROPRIEDADE], [MAPA_PLANCOLHEITA].[FRENTE_COLHEITA], [MAPA_PLANCOLHEITA].[MES], [MAPA_PLANCOLHEITA].[SEMANA], [MAPA_PLANCOLHEITA].[MES_SEMANA], [MAPA_PLANCOLHEITA].[SEMANA_PERIODO], [MAPA_PLANCOLHEITA].[REFORMA_PREV], [MAPA_PLANCOLHEITA].[AREA_PREV], [MAPA_PLANCOLHEITA].[TONELADA_PREV], [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA], [MAPA_PLANCOLHEITA].[TONELADA_PREV_REFORMA], [MAPA_PLANCOLHEITA].[AREA_PREV_TOTAL], [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA_TOTAL], [MAPA_PLANCOLHEITA].[_trackLastWriteTime], [MAPA_PLANCOLHEITA].[_trackCreationTime], [MAPA_PLANCOLHEITA].[_trackLastWriteUser], [MAPA_PLANCOLHEITA].[_trackCreationUser] 
    FROM [MAPA_PLANCOLHEITA] 
    WHERE ([MAPA_PLANCOLHEITA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[menu_DeleteBySistema]
(
 @oSistemapId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @deletedcount int
DELETE [menu] FROM [menu] 
    WHERE ([menu].[oSistema_pId] = @oSistemapId)
SELECT @deletedcount = @@ROWCOUNT

SELECT @deletedcount 
RETURN
GO

CREATE PROCEDURE [dbo].[menu_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menu].[pId], [menu].[pDescricao], [menu].[pNomeToolStrip], [menu].[oSistema_pId], [menu].[pNivelPosicao], [menu].[xDataHoraReg], [menu].[xLoginReg], [menu].[_trackLastWriteTime], [menu].[_trackCreationTime], [menu].[_trackLastWriteUser], [menu].[_trackCreationUser] 
    FROM [menu] 
    WHERE ([menu].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[menu_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menu].[pId], [menu].[pDescricao], [menu].[pNomeToolStrip], [menu].[oSistema_pId], [menu].[pNivelPosicao], [menu].[xDataHoraReg], [menu].[xLoginReg], [menu].[_trackLastWriteTime], [menu].[_trackCreationTime], [menu].[_trackLastWriteUser], [menu].[_trackCreationUser] 
    FROM [menu] 

RETURN
GO

CREATE PROCEDURE [dbo].[menu_LoadByoSistema]
(
 @oSistemapId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menu].[pId], [menu].[pDescricao], [menu].[pNomeToolStrip], [menu].[oSistema_pId], [menu].[pNivelPosicao], [menu].[xDataHoraReg], [menu].[xLoginReg], [menu].[_trackLastWriteTime], [menu].[_trackCreationTime], [menu].[_trackLastWriteUser], [menu].[_trackCreationUser] 
    FROM [menu] 
    WHERE ([menu].[oSistema_pId] = @oSistemapId)

RETURN
GO

CREATE PROCEDURE [dbo].[menu_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menu].[pId], [menu].[pDescricao], [menu].[pNomeToolStrip], [menu].[oSistema_pId], [menu].[pNivelPosicao], [menu].[xDataHoraReg], [menu].[xLoginReg], [menu].[_trackLastWriteTime], [menu].[_trackCreationTime], [menu].[_trackLastWriteUser], [menu].[_trackCreationUser] 
    FROM [menu] 
    WHERE ([menu].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[menu_LoadBySistemaVw]
(
 @parCodSistema [int],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vmenumenuvw].[pId], [vmenumenuvw].[pDescricao], [vmenumenuvw].[pNomeToolStrip], [vmenumenuvw].[pNivelPosicao], [vmenumenuvw].[pSistemaCodigo], [vmenumenuvw].[pSistemaNome], [vmenumenuvw].[_trackCreationTime], [vmenumenuvw].[_trackLastWriteTime], [vmenumenuvw].[_trackCreationUser], [vmenumenuvw].[_trackLastWriteUser] 
    FROM [vmenumenuvw] 
    WHERE ([vmenumenuvw].[pSistemaCodigo] = @parCodSistema)

RETURN
GO

CREATE PROCEDURE [dbo].[menu_LoadBySistemaVwPerm]
(
 @parIdUsuario [nvarchar] (256),
 @parIdSistema [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vmenumenuvwperm].[pId], [vmenumenuvwperm].[pNivelPosicao], [vmenumenuvwperm].[pDescricao], [vmenumenuvwperm].[pCodigo], [vmenumenuvwperm].[pNome], [vmenumenuvwperm].[pNomeToolStrip], [vmenumenuvwperm].[pFlgPermissao], [vmenumenuvwperm].[oUsuario_pId], [vmenumenuvwperm].[oSistema_pId] 
    FROM [vmenumenuvwperm] 
    WHERE ((NOT(([vmenumenuvwperm].[oUsuario_pId] IS NOT NULL)) OR ([vmenumenuvwperm].[oUsuario_pId] = @parIdUsuario)) AND (NOT(([vmenumenuvwperm].[oSistema_pId] IS NOT NULL)) OR ([vmenumenuvwperm].[oSistema_pId] = @parIdSistema)))

RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_DeleteBySistemaUsuario]
(
 @oSistemapId [bigint],
 @oUsuariopId [bigint]
)
AS
SET NOCOUNT ON
DECLARE @deletedcount int
DELETE [menupermissao] FROM [menupermissao] 
    WHERE (([menupermissao].[oSistema_pId] = @oSistemapId) AND ([menupermissao].[oUsuario_pId] = @oUsuariopId))
SELECT @deletedcount = @@ROWCOUNT

SELECT @deletedcount 
RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menupermissao].[pId], [menupermissao].[oUsuario_pId], [menupermissao].[oSistema_pId], [menupermissao].[pNomeToolStripPerm], [menupermissao].[pFlgPermissao], [menupermissao].[xDataHoraReg], [menupermissao].[xLoginReg], [menupermissao].[_trackLastWriteTime], [menupermissao].[_trackCreationTime], [menupermissao].[_trackLastWriteUser], [menupermissao].[_trackCreationUser] 
    FROM [menupermissao] 
    WHERE ([menupermissao].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menupermissao].[pId], [menupermissao].[oUsuario_pId], [menupermissao].[oSistema_pId], [menupermissao].[pNomeToolStripPerm], [menupermissao].[pFlgPermissao], [menupermissao].[xDataHoraReg], [menupermissao].[xLoginReg], [menupermissao].[_trackLastWriteTime], [menupermissao].[_trackCreationTime], [menupermissao].[_trackLastWriteUser], [menupermissao].[_trackCreationUser] 
    FROM [menupermissao] 

RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_LoadByoSistema]
(
 @oSistemapId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menupermissao].[pId], [menupermissao].[oUsuario_pId], [menupermissao].[oSistema_pId], [menupermissao].[pNomeToolStripPerm], [menupermissao].[pFlgPermissao], [menupermissao].[xDataHoraReg], [menupermissao].[xLoginReg], [menupermissao].[_trackLastWriteTime], [menupermissao].[_trackCreationTime], [menupermissao].[_trackLastWriteUser], [menupermissao].[_trackCreationUser] 
    FROM [menupermissao] 
    WHERE ([menupermissao].[oSistema_pId] = @oSistemapId)

RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_LoadByoUsuario]
(
 @oUsuariopId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menupermissao].[pId], [menupermissao].[oUsuario_pId], [menupermissao].[oSistema_pId], [menupermissao].[pNomeToolStripPerm], [menupermissao].[pFlgPermissao], [menupermissao].[xDataHoraReg], [menupermissao].[xLoginReg], [menupermissao].[_trackLastWriteTime], [menupermissao].[_trackCreationTime], [menupermissao].[_trackLastWriteUser], [menupermissao].[_trackCreationUser] 
    FROM [menupermissao] 
    WHERE ([menupermissao].[oUsuario_pId] = @oUsuariopId)

RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menupermissao].[pId], [menupermissao].[oUsuario_pId], [menupermissao].[oSistema_pId], [menupermissao].[pNomeToolStripPerm], [menupermissao].[pFlgPermissao], [menupermissao].[xDataHoraReg], [menupermissao].[xLoginReg], [menupermissao].[_trackLastWriteTime], [menupermissao].[_trackCreationTime], [menupermissao].[_trackLastWriteUser], [menupermissao].[_trackCreationUser] 
    FROM [menupermissao] 
    WHERE ([menupermissao].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_LoadBySistemaUsuario]
(
 @oSistemapId [bigint],
 @oUsuariopId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menupermissao].[pId], [menupermissao].[oUsuario_pId], [menupermissao].[oSistema_pId], [menupermissao].[pNomeToolStripPerm], [menupermissao].[pFlgPermissao], [menupermissao].[xDataHoraReg], [menupermissao].[xLoginReg], [menupermissao].[_trackLastWriteTime], [menupermissao].[_trackCreationTime], [menupermissao].[_trackLastWriteUser], [menupermissao].[_trackCreationUser] 
    FROM [menupermissao] 
    WHERE (([menupermissao].[oSistema_pId] = @oSistemapId) AND ([menupermissao].[oUsuario_pId] = @oUsuariopId))

RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_LoadBySistemaUsuarioPerm]
(
 @oSistemapId [bigint],
 @oUsuariopId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menupermissao].[pId], [menupermissao].[oUsuario_pId], [menupermissao].[oSistema_pId], [menupermissao].[pNomeToolStripPerm], [menupermissao].[pFlgPermissao], [menupermissao].[xDataHoraReg], [menupermissao].[xLoginReg], [menupermissao].[_trackLastWriteTime], [menupermissao].[_trackCreationTime], [menupermissao].[_trackLastWriteUser], [menupermissao].[_trackCreationUser] 
    FROM [menupermissao] 
    WHERE (([menupermissao].[oSistema_pId] = @oSistemapId) AND (([menupermissao].[oUsuario_pId] = @oUsuariopId) AND ([menupermissao].[pFlgPermissao] = 'S')))

RETURN
GO

CREATE PROCEDURE [dbo].[menupermissao_LoadBySistemaUsuarioToolStrip]
(
 @oSistemapId [bigint],
 @oUsuariopId [bigint],
 @parNomeToolStripPerm [nvarchar] (256)
)
AS
SET NOCOUNT ON
SELECT DISTINCT [menupermissao].[pId], [menupermissao].[oUsuario_pId], [menupermissao].[oSistema_pId], [menupermissao].[pNomeToolStripPerm], [menupermissao].[pFlgPermissao], [menupermissao].[xDataHoraReg], [menupermissao].[xLoginReg], [menupermissao].[_trackLastWriteTime], [menupermissao].[_trackCreationTime], [menupermissao].[_trackLastWriteUser], [menupermissao].[_trackCreationUser] 
    FROM [menupermissao] 
    WHERE (([menupermissao].[oSistema_pId] = @oSistemapId) AND (([menupermissao].[oUsuario_pId] = @oUsuariopId) AND ([menupermissao].[pNomeToolStripPerm] = @parNomeToolStripPerm)))

RETURN
GO

CREATE PROCEDURE [dbo].[MOAGEM_CANA_HORA_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [MOAGEM_CANA_HORA].[pId], [MOAGEM_CANA_HORA].[ID_NEGOCIOS], [MOAGEM_CANA_HORA].[DIA], [MOAGEM_CANA_HORA].[HORA], [MOAGEM_CANA_HORA].[VIAGEM], [MOAGEM_CANA_HORA].[TONELADAS], [MOAGEM_CANA_HORA].[METAFRENTE], [MOAGEM_CANA_HORA].[_trackLastWriteTime], [MOAGEM_CANA_HORA].[_trackCreationTime], [MOAGEM_CANA_HORA].[_trackLastWriteUser], [MOAGEM_CANA_HORA].[_trackCreationUser] 
    FROM [MOAGEM_CANA_HORA] 
    WHERE ([MOAGEM_CANA_HORA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[MOAGEM_CANA_HORA_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [MOAGEM_CANA_HORA].[pId], [MOAGEM_CANA_HORA].[ID_NEGOCIOS], [MOAGEM_CANA_HORA].[DIA], [MOAGEM_CANA_HORA].[HORA], [MOAGEM_CANA_HORA].[VIAGEM], [MOAGEM_CANA_HORA].[TONELADAS], [MOAGEM_CANA_HORA].[METAFRENTE], [MOAGEM_CANA_HORA].[_trackLastWriteTime], [MOAGEM_CANA_HORA].[_trackCreationTime], [MOAGEM_CANA_HORA].[_trackLastWriteUser], [MOAGEM_CANA_HORA].[_trackCreationUser] 
    FROM [MOAGEM_CANA_HORA] 

RETURN
GO

CREATE PROCEDURE [dbo].[MOAGEM_CANA_HORA_LoadByDIA]
(
 @parID_NEGOCIOS [int],
 @parDIA [date],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [MOAGEM_CANA_HORA].[pId], [MOAGEM_CANA_HORA].[ID_NEGOCIOS], [MOAGEM_CANA_HORA].[DIA], [MOAGEM_CANA_HORA].[HORA], [MOAGEM_CANA_HORA].[VIAGEM], [MOAGEM_CANA_HORA].[TONELADAS], [MOAGEM_CANA_HORA].[METAFRENTE], [MOAGEM_CANA_HORA].[_trackLastWriteTime], [MOAGEM_CANA_HORA].[_trackCreationTime], [MOAGEM_CANA_HORA].[_trackLastWriteUser], [MOAGEM_CANA_HORA].[_trackCreationUser] 
    FROM [MOAGEM_CANA_HORA] 
    WHERE (([MOAGEM_CANA_HORA].[ID_NEGOCIOS] = @parID_NEGOCIOS) AND ([MOAGEM_CANA_HORA].[DIA] = @parDIA))

RETURN
GO

CREATE PROCEDURE [dbo].[MOAGEM_CANA_HORA_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [MOAGEM_CANA_HORA].[pId], [MOAGEM_CANA_HORA].[ID_NEGOCIOS], [MOAGEM_CANA_HORA].[DIA], [MOAGEM_CANA_HORA].[HORA], [MOAGEM_CANA_HORA].[VIAGEM], [MOAGEM_CANA_HORA].[TONELADAS], [MOAGEM_CANA_HORA].[METAFRENTE], [MOAGEM_CANA_HORA].[_trackLastWriteTime], [MOAGEM_CANA_HORA].[_trackCreationTime], [MOAGEM_CANA_HORA].[_trackLastWriteUser], [MOAGEM_CANA_HORA].[_trackCreationUser] 
    FROM [MOAGEM_CANA_HORA] 
    WHERE ([MOAGEM_CANA_HORA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[pais_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [pais].[pId], [pais].[pCodigo], [pais].[pNome], [pais].[pSigla], [pais].[pCodigoIbge], [pais].[xDataHoraReg], [pais].[xLoginReg], [pais].[_trackLastWriteTime], [pais].[_trackCreationTime], [pais].[_trackLastWriteUser], [pais].[_trackCreationUser] 
    FROM [pais] 
    WHERE ([pais].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[pais_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [pais].[pId], [pais].[pCodigo], [pais].[pNome], [pais].[pSigla], [pais].[pCodigoIbge], [pais].[xDataHoraReg], [pais].[xLoginReg], [pais].[_trackLastWriteTime], [pais].[_trackCreationTime], [pais].[_trackLastWriteUser], [pais].[_trackCreationUser] 
    FROM [pais] 

RETURN
GO

CREATE PROCEDURE [dbo].[pais_LoadAllViewGrid]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vpaispaisviewgrid].[pId], [vpaispaisviewgrid].[pCodigo], [vpaispaisviewgrid].[pCodigoIbge], [vpaispaisviewgrid].[pNome], [vpaispaisviewgrid].[_trackCreationTime], [vpaispaisviewgrid].[_trackLastWriteTime], [vpaispaisviewgrid].[_trackCreationUser], [vpaispaisviewgrid].[_trackLastWriteUser] 
    FROM [vpaispaisviewgrid] 
    ORDER BY [vpaispaisviewgrid].[pNome] ASC

RETURN
GO

CREATE PROCEDURE [dbo].[pais_LoadByDescricaoViewGrid]
(
 @parNomePais [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vpaispaisviewgrid].[pId], [vpaispaisviewgrid].[pCodigo], [vpaispaisviewgrid].[pCodigoIbge], [vpaispaisviewgrid].[pNome], [vpaispaisviewgrid].[_trackCreationTime], [vpaispaisviewgrid].[_trackLastWriteTime], [vpaispaisviewgrid].[_trackCreationUser], [vpaispaisviewgrid].[_trackLastWriteUser] 
    FROM [vpaispaisviewgrid] 
    WHERE ([vpaispaisviewgrid].[pNome] LIKE @parNomePais)

RETURN
GO

CREATE PROCEDURE [dbo].[pais_LoadBypCodigo]
(
 @pCodigo [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [pais].[pId], [pais].[pCodigo], [pais].[pNome], [pais].[pSigla], [pais].[pCodigoIbge], [pais].[xDataHoraReg], [pais].[xLoginReg], [pais].[_trackLastWriteTime], [pais].[_trackCreationTime], [pais].[_trackLastWriteUser], [pais].[_trackCreationUser] 
    FROM [pais] 
    WHERE ([pais].[pCodigo] = @pCodigo)

RETURN
GO

CREATE PROCEDURE [dbo].[pais_LoadMaxCodigo]

AS
SET NOCOUNT ON
SELECT DISTINCT TOP 1 [pais].[pId], [pais].[pCodigo], [pais].[pNome], [pais].[pSigla], [pais].[pCodigoIbge], [pais].[xDataHoraReg], [pais].[xLoginReg], [pais].[_trackLastWriteTime], [pais].[_trackCreationTime], [pais].[_trackLastWriteUser], [pais].[_trackCreationUser] 
    FROM [pais] 
    ORDER BY [pais].[pCodigo] DESC

RETURN
GO

CREATE PROCEDURE [dbo].[PROPRIEDADES_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [PROPRIEDADES].[pId], [PROPRIEDADES].[SAFRA], [PROPRIEDADES].[COD_PROPRIEDADE], [PROPRIEDADES].[DSC_PROPRIEDADE], [PROPRIEDADES].[_trackLastWriteTime], [PROPRIEDADES].[_trackCreationTime], [PROPRIEDADES].[_trackLastWriteUser], [PROPRIEDADES].[_trackCreationUser] 
    FROM [PROPRIEDADES] 
    WHERE ([PROPRIEDADES].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[PROPRIEDADES_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [PROPRIEDADES].[pId], [PROPRIEDADES].[SAFRA], [PROPRIEDADES].[COD_PROPRIEDADE], [PROPRIEDADES].[DSC_PROPRIEDADE], [PROPRIEDADES].[_trackLastWriteTime], [PROPRIEDADES].[_trackCreationTime], [PROPRIEDADES].[_trackLastWriteUser], [PROPRIEDADES].[_trackCreationUser] 
    FROM [PROPRIEDADES] 

RETURN
GO

CREATE PROCEDURE [dbo].[PROPRIEDADES_LoadByCOD_PROPRIEDADE]
(
 @parSAFRA [int],
 @parCOD_PROPRIEDADE [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [PROPRIEDADES].[pId], [PROPRIEDADES].[SAFRA], [PROPRIEDADES].[COD_PROPRIEDADE], [PROPRIEDADES].[DSC_PROPRIEDADE], [PROPRIEDADES].[_trackLastWriteTime], [PROPRIEDADES].[_trackCreationTime], [PROPRIEDADES].[_trackLastWriteUser], [PROPRIEDADES].[_trackCreationUser] 
    FROM [PROPRIEDADES] 
    WHERE (([PROPRIEDADES].[SAFRA] = @parSAFRA) AND ([PROPRIEDADES].[COD_PROPRIEDADE] = @parCOD_PROPRIEDADE))

RETURN
GO

CREATE PROCEDURE [dbo].[PROPRIEDADES_LoadByDSC_PROPRIEDADE]
(
 @parSAFRA [int],
 @parDSC_PROPRIEDADE [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [PROPRIEDADES].[pId], [PROPRIEDADES].[SAFRA], [PROPRIEDADES].[COD_PROPRIEDADE], [PROPRIEDADES].[DSC_PROPRIEDADE], [PROPRIEDADES].[_trackLastWriteTime], [PROPRIEDADES].[_trackCreationTime], [PROPRIEDADES].[_trackLastWriteUser], [PROPRIEDADES].[_trackCreationUser] 
    FROM [PROPRIEDADES] 
    WHERE (([PROPRIEDADES].[SAFRA] = @parSAFRA) AND ([PROPRIEDADES].[DSC_PROPRIEDADE] LIKE @parDSC_PROPRIEDADE))

RETURN
GO

CREATE PROCEDURE [dbo].[PROPRIEDADES_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [PROPRIEDADES].[pId], [PROPRIEDADES].[SAFRA], [PROPRIEDADES].[COD_PROPRIEDADE], [PROPRIEDADES].[DSC_PROPRIEDADE], [PROPRIEDADES].[_trackLastWriteTime], [PROPRIEDADES].[_trackCreationTime], [PROPRIEDADES].[_trackLastWriteUser], [PROPRIEDADES].[_trackCreationUser] 
    FROM [PROPRIEDADES] 
    WHERE ([PROPRIEDADES].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[PROPRIEDADES_LoadBySAFRA]
(
 @parSAFRA [int],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [PROPRIEDADES].[pId], [PROPRIEDADES].[SAFRA], [PROPRIEDADES].[COD_PROPRIEDADE], [PROPRIEDADES].[DSC_PROPRIEDADE], [PROPRIEDADES].[_trackLastWriteTime], [PROPRIEDADES].[_trackCreationTime], [PROPRIEDADES].[_trackLastWriteUser], [PROPRIEDADES].[_trackCreationUser] 
    FROM [PROPRIEDADES] 
    WHERE ([PROPRIEDADES].[SAFRA] = @parSAFRA)

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_ACUMULADA_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_ACUMULADA].[pId], [RES_MENSAL_ACUMULADA].[ID_NEGOCIOS], [RES_MENSAL_ACUMULADA].[NRO_ANO_SAFRA], [RES_MENSAL_ACUMULADA].[MES], [RES_MENSAL_ACUMULADA].[DIA], [RES_MENSAL_ACUMULADA].[TONELADA_PLAN], [RES_MENSAL_ACUMULADA].[TONELADA_PLAN_AC], [RES_MENSAL_ACUMULADA].[TONELADA_REAL], [RES_MENSAL_ACUMULADA].[TONELADA_REAL_AC], [RES_MENSAL_ACUMULADA].[_trackLastWriteTime], [RES_MENSAL_ACUMULADA].[_trackCreationTime], [RES_MENSAL_ACUMULADA].[_trackLastWriteUser], [RES_MENSAL_ACUMULADA].[_trackCreationUser] 
    FROM [RES_MENSAL_ACUMULADA] 
    WHERE ([RES_MENSAL_ACUMULADA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_ACUMULADA_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_ACUMULADA].[pId], [RES_MENSAL_ACUMULADA].[ID_NEGOCIOS], [RES_MENSAL_ACUMULADA].[NRO_ANO_SAFRA], [RES_MENSAL_ACUMULADA].[MES], [RES_MENSAL_ACUMULADA].[DIA], [RES_MENSAL_ACUMULADA].[TONELADA_PLAN], [RES_MENSAL_ACUMULADA].[TONELADA_PLAN_AC], [RES_MENSAL_ACUMULADA].[TONELADA_REAL], [RES_MENSAL_ACUMULADA].[TONELADA_REAL_AC], [RES_MENSAL_ACUMULADA].[_trackLastWriteTime], [RES_MENSAL_ACUMULADA].[_trackCreationTime], [RES_MENSAL_ACUMULADA].[_trackLastWriteUser], [RES_MENSAL_ACUMULADA].[_trackCreationUser] 
    FROM [RES_MENSAL_ACUMULADA] 

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_ACUMULADA_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_ACUMULADA].[pId], [RES_MENSAL_ACUMULADA].[ID_NEGOCIOS], [RES_MENSAL_ACUMULADA].[NRO_ANO_SAFRA], [RES_MENSAL_ACUMULADA].[MES], [RES_MENSAL_ACUMULADA].[DIA], [RES_MENSAL_ACUMULADA].[TONELADA_PLAN], [RES_MENSAL_ACUMULADA].[TONELADA_PLAN_AC], [RES_MENSAL_ACUMULADA].[TONELADA_REAL], [RES_MENSAL_ACUMULADA].[TONELADA_REAL_AC], [RES_MENSAL_ACUMULADA].[_trackLastWriteTime], [RES_MENSAL_ACUMULADA].[_trackCreationTime], [RES_MENSAL_ACUMULADA].[_trackLastWriteUser], [RES_MENSAL_ACUMULADA].[_trackCreationUser] 
    FROM [RES_MENSAL_ACUMULADA] 
    WHERE ([RES_MENSAL_ACUMULADA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_DIARIA_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_DIARIA].[pId], [RES_MENSAL_DIARIA].[ID_NEGOCIOS], [RES_MENSAL_DIARIA].[NRO_ANO_SAFRA], [RES_MENSAL_DIARIA].[MES], [RES_MENSAL_DIARIA].[DIA], [RES_MENSAL_DIARIA].[TONELADA_PLAN], [RES_MENSAL_DIARIA].[TONELADA_REAL], [RES_MENSAL_DIARIA].[_trackLastWriteTime], [RES_MENSAL_DIARIA].[_trackCreationTime], [RES_MENSAL_DIARIA].[_trackLastWriteUser], [RES_MENSAL_DIARIA].[_trackCreationUser] 
    FROM [RES_MENSAL_DIARIA] 
    WHERE ([RES_MENSAL_DIARIA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_DIARIA_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_DIARIA].[pId], [RES_MENSAL_DIARIA].[ID_NEGOCIOS], [RES_MENSAL_DIARIA].[NRO_ANO_SAFRA], [RES_MENSAL_DIARIA].[MES], [RES_MENSAL_DIARIA].[DIA], [RES_MENSAL_DIARIA].[TONELADA_PLAN], [RES_MENSAL_DIARIA].[TONELADA_REAL], [RES_MENSAL_DIARIA].[_trackLastWriteTime], [RES_MENSAL_DIARIA].[_trackCreationTime], [RES_MENSAL_DIARIA].[_trackLastWriteUser], [RES_MENSAL_DIARIA].[_trackCreationUser] 
    FROM [RES_MENSAL_DIARIA] 

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_DIARIA_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_DIARIA].[pId], [RES_MENSAL_DIARIA].[ID_NEGOCIOS], [RES_MENSAL_DIARIA].[NRO_ANO_SAFRA], [RES_MENSAL_DIARIA].[MES], [RES_MENSAL_DIARIA].[DIA], [RES_MENSAL_DIARIA].[TONELADA_PLAN], [RES_MENSAL_DIARIA].[TONELADA_REAL], [RES_MENSAL_DIARIA].[_trackLastWriteTime], [RES_MENSAL_DIARIA].[_trackCreationTime], [RES_MENSAL_DIARIA].[_trackLastWriteUser], [RES_MENSAL_DIARIA].[_trackCreationUser] 
    FROM [RES_MENSAL_DIARIA] 
    WHERE ([RES_MENSAL_DIARIA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_GRID_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_GRID].[pId], [RES_MENSAL_GRID].[ID_NEGOCIOS], [RES_MENSAL_GRID].[NRO_ANO_SAFRA], [RES_MENSAL_GRID].[MES], [RES_MENSAL_GRID].[MES_N], [RES_MENSAL_GRID].[TIPO], [RES_MENSAL_GRID].[TONELADA], [RES_MENSAL_GRID].[_trackLastWriteTime], [RES_MENSAL_GRID].[_trackCreationTime], [RES_MENSAL_GRID].[_trackLastWriteUser], [RES_MENSAL_GRID].[_trackCreationUser] 
    FROM [RES_MENSAL_GRID] 
    WHERE ([RES_MENSAL_GRID].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_GRID_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_GRID].[pId], [RES_MENSAL_GRID].[ID_NEGOCIOS], [RES_MENSAL_GRID].[NRO_ANO_SAFRA], [RES_MENSAL_GRID].[MES], [RES_MENSAL_GRID].[MES_N], [RES_MENSAL_GRID].[TIPO], [RES_MENSAL_GRID].[TONELADA], [RES_MENSAL_GRID].[_trackLastWriteTime], [RES_MENSAL_GRID].[_trackCreationTime], [RES_MENSAL_GRID].[_trackLastWriteUser], [RES_MENSAL_GRID].[_trackCreationUser] 
    FROM [RES_MENSAL_GRID] 

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_GRID_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_GRID].[pId], [RES_MENSAL_GRID].[ID_NEGOCIOS], [RES_MENSAL_GRID].[NRO_ANO_SAFRA], [RES_MENSAL_GRID].[MES], [RES_MENSAL_GRID].[MES_N], [RES_MENSAL_GRID].[TIPO], [RES_MENSAL_GRID].[TONELADA], [RES_MENSAL_GRID].[_trackLastWriteTime], [RES_MENSAL_GRID].[_trackCreationTime], [RES_MENSAL_GRID].[_trackLastWriteUser], [RES_MENSAL_GRID].[_trackCreationUser] 
    FROM [RES_MENSAL_GRID] 
    WHERE ([RES_MENSAL_GRID].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_SAFRA_ACUMULADA_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_SAFRA_ACUMULADA].[pId], [RES_MENSAL_SAFRA_ACUMULADA].[ID_NEGOCIOS], [RES_MENSAL_SAFRA_ACUMULADA].[NRO_ANO_SAFRA], [RES_MENSAL_SAFRA_ACUMULADA].[MES], [RES_MENSAL_SAFRA_ACUMULADA].[DIA], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN_AC], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL_AC], [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteTime], [RES_MENSAL_SAFRA_ACUMULADA].[_trackCreationTime], [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteUser], [RES_MENSAL_SAFRA_ACUMULADA].[_trackCreationUser] 
    FROM [RES_MENSAL_SAFRA_ACUMULADA] 
    WHERE ([RES_MENSAL_SAFRA_ACUMULADA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_SAFRA_ACUMULADA_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_SAFRA_ACUMULADA].[pId], [RES_MENSAL_SAFRA_ACUMULADA].[ID_NEGOCIOS], [RES_MENSAL_SAFRA_ACUMULADA].[NRO_ANO_SAFRA], [RES_MENSAL_SAFRA_ACUMULADA].[MES], [RES_MENSAL_SAFRA_ACUMULADA].[DIA], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN_AC], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL_AC], [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteTime], [RES_MENSAL_SAFRA_ACUMULADA].[_trackCreationTime], [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteUser], [RES_MENSAL_SAFRA_ACUMULADA].[_trackCreationUser] 
    FROM [RES_MENSAL_SAFRA_ACUMULADA] 

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_SAFRA_ACUMULADA_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_SAFRA_ACUMULADA].[pId], [RES_MENSAL_SAFRA_ACUMULADA].[ID_NEGOCIOS], [RES_MENSAL_SAFRA_ACUMULADA].[NRO_ANO_SAFRA], [RES_MENSAL_SAFRA_ACUMULADA].[MES], [RES_MENSAL_SAFRA_ACUMULADA].[DIA], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN_AC], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL_AC], [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteTime], [RES_MENSAL_SAFRA_ACUMULADA].[_trackCreationTime], [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteUser], [RES_MENSAL_SAFRA_ACUMULADA].[_trackCreationUser] 
    FROM [RES_MENSAL_SAFRA_ACUMULADA] 
    WHERE ([RES_MENSAL_SAFRA_ACUMULADA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_SAFRA_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_SAFRA].[pId], [RES_MENSAL_SAFRA].[ID_NEGOCIOS], [RES_MENSAL_SAFRA].[NRO_ANO_SAFRA], [RES_MENSAL_SAFRA].[MES], [RES_MENSAL_SAFRA].[DIA], [RES_MENSAL_SAFRA].[TONELADA_PLAN], [RES_MENSAL_SAFRA].[TONELADA_REAL], [RES_MENSAL_SAFRA].[_trackLastWriteTime], [RES_MENSAL_SAFRA].[_trackCreationTime], [RES_MENSAL_SAFRA].[_trackLastWriteUser], [RES_MENSAL_SAFRA].[_trackCreationUser] 
    FROM [RES_MENSAL_SAFRA] 
    WHERE ([RES_MENSAL_SAFRA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_SAFRA_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_SAFRA].[pId], [RES_MENSAL_SAFRA].[ID_NEGOCIOS], [RES_MENSAL_SAFRA].[NRO_ANO_SAFRA], [RES_MENSAL_SAFRA].[MES], [RES_MENSAL_SAFRA].[DIA], [RES_MENSAL_SAFRA].[TONELADA_PLAN], [RES_MENSAL_SAFRA].[TONELADA_REAL], [RES_MENSAL_SAFRA].[_trackLastWriteTime], [RES_MENSAL_SAFRA].[_trackCreationTime], [RES_MENSAL_SAFRA].[_trackLastWriteUser], [RES_MENSAL_SAFRA].[_trackCreationUser] 
    FROM [RES_MENSAL_SAFRA] 

RETURN
GO

CREATE PROCEDURE [dbo].[RES_MENSAL_SAFRA_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [RES_MENSAL_SAFRA].[pId], [RES_MENSAL_SAFRA].[ID_NEGOCIOS], [RES_MENSAL_SAFRA].[NRO_ANO_SAFRA], [RES_MENSAL_SAFRA].[MES], [RES_MENSAL_SAFRA].[DIA], [RES_MENSAL_SAFRA].[TONELADA_PLAN], [RES_MENSAL_SAFRA].[TONELADA_REAL], [RES_MENSAL_SAFRA].[_trackLastWriteTime], [RES_MENSAL_SAFRA].[_trackCreationTime], [RES_MENSAL_SAFRA].[_trackLastWriteUser], [RES_MENSAL_SAFRA].[_trackCreationUser] 
    FROM [RES_MENSAL_SAFRA] 
    WHERE ([RES_MENSAL_SAFRA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[SAFRA_ANO_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [SAFRA_ANO].[pId], [SAFRA_ANO].[SAFRA], [SAFRA_ANO].[_trackLastWriteTime], [SAFRA_ANO].[_trackCreationTime], [SAFRA_ANO].[_trackLastWriteUser], [SAFRA_ANO].[_trackCreationUser] 
    FROM [SAFRA_ANO] 
    WHERE ([SAFRA_ANO].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[SAFRA_ANO_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [SAFRA_ANO].[pId], [SAFRA_ANO].[SAFRA], [SAFRA_ANO].[_trackLastWriteTime], [SAFRA_ANO].[_trackCreationTime], [SAFRA_ANO].[_trackLastWriteUser], [SAFRA_ANO].[_trackCreationUser] 
    FROM [SAFRA_ANO] 

RETURN
GO

CREATE PROCEDURE [dbo].[SAFRA_ANO_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [SAFRA_ANO].[pId], [SAFRA_ANO].[SAFRA], [SAFRA_ANO].[_trackLastWriteTime], [SAFRA_ANO].[_trackCreationTime], [SAFRA_ANO].[_trackLastWriteUser], [SAFRA_ANO].[_trackCreationUser] 
    FROM [SAFRA_ANO] 
    WHERE ([SAFRA_ANO].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[SEQUENCIA_COLHEITA_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [SEQUENCIA_COLHEITA].[pId], [SEQUENCIA_COLHEITA].[FRENTE_COLHEITA], [SEQUENCIA_COLHEITA].[PROP_CODIGO], [SEQUENCIA_COLHEITA].[DS_NOME_PROPRIEDADE], [SEQUENCIA_COLHEITA].[COORD_LAT], [SEQUENCIA_COLHEITA].[COORD_LONG], [SEQUENCIA_COLHEITA].[ORDEM], [SEQUENCIA_COLHEITA].[_trackLastWriteTime], [SEQUENCIA_COLHEITA].[_trackCreationTime], [SEQUENCIA_COLHEITA].[_trackLastWriteUser], [SEQUENCIA_COLHEITA].[_trackCreationUser] 
    FROM [SEQUENCIA_COLHEITA] 
    WHERE ([SEQUENCIA_COLHEITA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[SEQUENCIA_COLHEITA_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [SEQUENCIA_COLHEITA].[pId], [SEQUENCIA_COLHEITA].[FRENTE_COLHEITA], [SEQUENCIA_COLHEITA].[PROP_CODIGO], [SEQUENCIA_COLHEITA].[DS_NOME_PROPRIEDADE], [SEQUENCIA_COLHEITA].[COORD_LAT], [SEQUENCIA_COLHEITA].[COORD_LONG], [SEQUENCIA_COLHEITA].[ORDEM], [SEQUENCIA_COLHEITA].[_trackLastWriteTime], [SEQUENCIA_COLHEITA].[_trackCreationTime], [SEQUENCIA_COLHEITA].[_trackLastWriteUser], [SEQUENCIA_COLHEITA].[_trackCreationUser] 
    FROM [SEQUENCIA_COLHEITA] 

RETURN
GO

CREATE PROCEDURE [dbo].[SEQUENCIA_COLHEITA_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [SEQUENCIA_COLHEITA].[pId], [SEQUENCIA_COLHEITA].[FRENTE_COLHEITA], [SEQUENCIA_COLHEITA].[PROP_CODIGO], [SEQUENCIA_COLHEITA].[DS_NOME_PROPRIEDADE], [SEQUENCIA_COLHEITA].[COORD_LAT], [SEQUENCIA_COLHEITA].[COORD_LONG], [SEQUENCIA_COLHEITA].[ORDEM], [SEQUENCIA_COLHEITA].[_trackLastWriteTime], [SEQUENCIA_COLHEITA].[_trackCreationTime], [SEQUENCIA_COLHEITA].[_trackLastWriteUser], [SEQUENCIA_COLHEITA].[_trackCreationUser] 
    FROM [SEQUENCIA_COLHEITA] 
    WHERE ([SEQUENCIA_COLHEITA].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[sistema_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [sistema].[pId], [sistema].[pNome], [sistema].[pCodigo], [sistema].[xDataHoraReg], [sistema].[xLoginReg], [sistema].[_trackLastWriteTime], [sistema].[_trackCreationTime], [sistema].[_trackLastWriteUser], [sistema].[_trackCreationUser] 
    FROM [sistema] 
    WHERE ([sistema].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[sistema_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [sistema].[pId], [sistema].[pNome], [sistema].[pCodigo], [sistema].[xDataHoraReg], [sistema].[xLoginReg], [sistema].[_trackLastWriteTime], [sistema].[_trackCreationTime], [sistema].[_trackLastWriteUser], [sistema].[_trackCreationUser] 
    FROM [sistema] 

RETURN
GO

CREATE PROCEDURE [dbo].[sistema_LoadByCodSistemaCodEmpresa]
(
 @parCodSistema [int],
 @parCodEmpresa [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [sistema].[pId], [sistema].[pNome], [sistema].[pCodigo], [sistema].[xDataHoraReg], [sistema].[xLoginReg], [sistema].[_trackLastWriteTime], [sistema].[_trackCreationTime], [sistema].[_trackLastWriteUser], [sistema].[_trackCreationUser] 
    FROM [sistema]
        LEFT OUTER JOIN [empresa_osistemas_sistema_oempresas] ON ([sistema].[pId] = [empresa_osistemas_sistema_oempresas].[pId2])
                LEFT OUTER JOIN [empresa] ON ([empresa_osistemas_sistema_oempresas].[pId] = [empresa].[pId]) 
    WHERE (([sistema].[pCodigo] = @parCodSistema) AND ([empresa].[pCodigo] = @parCodEmpresa))

RETURN
GO

CREATE PROCEDURE [dbo].[sistema_LoadByNome]
(
 @parNome [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [sistema].[pId], [sistema].[pNome], [sistema].[pCodigo], [sistema].[xDataHoraReg], [sistema].[xLoginReg], [sistema].[_trackLastWriteTime], [sistema].[_trackCreationTime], [sistema].[_trackLastWriteUser], [sistema].[_trackCreationUser] 
    FROM [sistema] 
    WHERE ([sistema].[pNome] LIKE @parNome)

RETURN
GO

CREATE PROCEDURE [dbo].[sistema_LoadBypCodigo]
(
 @pCodigo [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [sistema].[pId], [sistema].[pNome], [sistema].[pCodigo], [sistema].[xDataHoraReg], [sistema].[xLoginReg], [sistema].[_trackLastWriteTime], [sistema].[_trackCreationTime], [sistema].[_trackLastWriteUser], [sistema].[_trackCreationUser] 
    FROM [sistema] 
    WHERE ([sistema].[pCodigo] = @pCodigo)

RETURN
GO

CREATE PROCEDURE [dbo].[sistema_LoadoSistemasoEmpresasByEmpresa]
(
 @EmpresapId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [sistema].[pId], [sistema].[pNome], [sistema].[pCodigo], [sistema].[xDataHoraReg], [sistema].[xLoginReg], [sistema].[_trackLastWriteTime], [sistema].[_trackCreationTime], [sistema].[_trackLastWriteUser], [sistema].[_trackCreationUser] 
    FROM [sistema]
        LEFT OUTER JOIN [empresa_osistemas_sistema_oempresas] ON ([sistema].[pId] = [empresa_osistemas_sistema_oempresas].[pId2])
                LEFT OUTER JOIN [empresa] ON ([empresa_osistemas_sistema_oempresas].[pId] = [empresa].[pId]) 
    WHERE ([empresa_osistemas_sistema_oempresas].[pId] = @EmpresapId)

RETURN
GO

CREATE PROCEDURE [dbo].[uf_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [uf].[pId], [uf].[pCodigo], [uf].[pDescricao], [uf].[pSigla], [uf].[pCodigoIbge], [uf].[xDataHoraReg], [uf].[xLoginReg], [uf].[oPais_pId], [uf].[_trackLastWriteTime], [uf].[_trackCreationTime], [uf].[_trackLastWriteUser], [uf].[_trackCreationUser] 
    FROM [uf] 
    WHERE ([uf].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[uf_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [uf].[pId], [uf].[pCodigo], [uf].[pDescricao], [uf].[pSigla], [uf].[pCodigoIbge], [uf].[xDataHoraReg], [uf].[xLoginReg], [uf].[oPais_pId], [uf].[_trackLastWriteTime], [uf].[_trackCreationTime], [uf].[_trackLastWriteUser], [uf].[_trackCreationUser] 
    FROM [uf] 

RETURN
GO

CREATE PROCEDURE [dbo].[uf_LoadAllViewGrid]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vufufviewgrid].[pId], [vufufviewgrid].[pCodigo], [vufufviewgrid].[pDescricao], [vufufviewgrid].[pSigla], [vufufviewgrid].[_trackCreationTime], [vufufviewgrid].[_trackLastWriteTime], [vufufviewgrid].[_trackCreationUser], [vufufviewgrid].[_trackLastWriteUser] 
    FROM [vufufviewgrid] 
    ORDER BY [vufufviewgrid].[pDescricao] ASC

RETURN
GO

CREATE PROCEDURE [dbo].[uf_LoadByDescricaoViewGrid]
(
 @parNomeUF [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [vufufviewgrid].[pId], [vufufviewgrid].[pCodigo], [vufufviewgrid].[pDescricao], [vufufviewgrid].[pSigla], [vufufviewgrid].[_trackCreationTime], [vufufviewgrid].[_trackLastWriteTime], [vufufviewgrid].[_trackCreationUser], [vufufviewgrid].[_trackLastWriteUser] 
    FROM [vufufviewgrid] 
    WHERE ([vufufviewgrid].[pDescricao] LIKE @parNomeUF)

RETURN
GO

CREATE PROCEDURE [dbo].[uf_LoadByoPais]
(
 @oPaispId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [uf].[pId], [uf].[pCodigo], [uf].[pDescricao], [uf].[pSigla], [uf].[pCodigoIbge], [uf].[xDataHoraReg], [uf].[xLoginReg], [uf].[oPais_pId], [uf].[_trackLastWriteTime], [uf].[_trackCreationTime], [uf].[_trackLastWriteUser], [uf].[_trackCreationUser] 
    FROM [uf] 
    WHERE ([uf].[oPais_pId] = @oPaispId)

RETURN
GO

CREATE PROCEDURE [dbo].[uf_LoadBypCodigo]
(
 @pCodigo [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [uf].[pId], [uf].[pCodigo], [uf].[pDescricao], [uf].[pSigla], [uf].[pCodigoIbge], [uf].[xDataHoraReg], [uf].[xLoginReg], [uf].[oPais_pId], [uf].[_trackLastWriteTime], [uf].[_trackCreationTime], [uf].[_trackLastWriteUser], [uf].[_trackCreationUser] 
    FROM [uf] 
    WHERE ([uf].[pCodigo] = @pCodigo)

RETURN
GO

CREATE PROCEDURE [dbo].[uf_LoadBySigla]
(
 @parSigla [nvarchar] (256)
)
AS
SET NOCOUNT ON
SELECT DISTINCT [uf].[pId], [uf].[pCodigo], [uf].[pDescricao], [uf].[pSigla], [uf].[pCodigoIbge], [uf].[xDataHoraReg], [uf].[xLoginReg], [uf].[oPais_pId], [uf].[_trackLastWriteTime], [uf].[_trackCreationTime], [uf].[_trackLastWriteUser], [uf].[_trackCreationUser] 
    FROM [uf] 
    WHERE ([uf].[pSigla] = @parSigla)

RETURN
GO

CREATE PROCEDURE [dbo].[uf_LoadMaxCodigo]

AS
SET NOCOUNT ON
SELECT DISTINCT TOP 1 [uf].[pId], [uf].[pCodigo], [uf].[pDescricao], [uf].[pSigla], [uf].[pCodigoIbge], [uf].[xDataHoraReg], [uf].[xLoginReg], [uf].[oPais_pId], [uf].[_trackLastWriteTime], [uf].[_trackCreationTime], [uf].[_trackLastWriteUser], [uf].[_trackCreationUser] 
    FROM [uf] 
    ORDER BY [uf].[pCodigo] DESC

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteUser], [usuario].[_trackCreationUser] 
    FROM [usuario] 
    WHERE ([usuario].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteUser], [usuario].[_trackCreationUser] 
    FROM [usuario] 

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_LoadByCodigo]
(
 @parCodigo [int]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteUser], [usuario].[_trackCreationUser] 
    FROM [usuario] 
    WHERE ([usuario].[pCodigo] = @parCodigo)

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_LoadByLogin]
(
 @parLogin [nvarchar] (256),
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteUser], [usuario].[_trackCreationUser] 
    FROM [usuario] 
    WHERE ([usuario].[pLogin] LIKE @parLogin)

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_LoadByoCadastro]
(
 @oCadastropId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteUser], [usuario].[_trackCreationUser] 
    FROM [usuario] 
    WHERE ([usuario].[oCadastro_pId] = @oCadastropId)

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_LoadByoIdUser]
(
 @oIdUserId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteUser], [usuario].[_trackCreationUser] 
    FROM [usuario] 
    WHERE ([usuario].[oIdUser_Id] = @oIdUserId)

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_LoadBypLogin]
(
 @pLogin [nvarchar] (256)
)
AS
SET NOCOUNT ON
SELECT DISTINCT [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteUser], [usuario].[_trackCreationUser] 
    FROM [usuario] 
    WHERE ([usuario].[pLogin] = @pLogin)

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_LoadMaxCodigo]

AS
SET NOCOUNT ON
SELECT DISTINCT TOP 1 [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteUser], [usuario].[_trackCreationUser] 
    FROM [usuario] 
    ORDER BY [usuario].[pCodigo] DESC

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_LoadoUsuariosoAppRelatoriosByAppRelatorio]
(
 @AppRelatoriopId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteUser], [usuario].[_trackCreationUser] 
    FROM [usuario]
        LEFT OUTER JOIN [apprelatorio_oUsuarios_usuario_oAppRelatorios] ON ([usuario].[pId] = [apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId2])
                LEFT OUTER JOIN [apprelatorio] ON ([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId] = [apprelatorio].[pId]) 
    WHERE ([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId] = @AppRelatoriopId)

RETURN
GO

CREATE PROCEDURE [dbo].[usuario_LoadoUsuariosoFiliaisByFilial]
(
 @FilialpId [bigint],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteUser], [usuario].[_trackCreationUser] 
    FROM [usuario]
        LEFT OUTER JOIN [filial_ousuarios_usuario_ofiliais] ON ([usuario].[pId] = [filial_ousuarios_usuario_ofiliais].[pId2])
                LEFT OUTER JOIN [filial] ON ([filial_ousuarios_usuario_ofiliais].[pId] = [filial].[pId]) 
    WHERE ([filial_ousuarios_usuario_ofiliais].[pId] = @FilialpId)

RETURN
GO

CREATE PROCEDURE [dbo].[V_DADOS_TALHAO_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [V_DADOS_TALHAO].[pId], [V_DADOS_TALHAO].[ID_NEGOCIOS], [V_DADOS_TALHAO].[SAFRA], [V_DADOS_TALHAO].[COD_PROPRIEDADE], [V_DADOS_TALHAO].[DSC_PROPRIEDADE], [V_DADOS_TALHAO].[TALHAO], [V_DADOS_TALHAO].[CORTE], [V_DADOS_TALHAO].[AMBIENTE], [V_DADOS_TALHAO].[VARIEDADE], [V_DADOS_TALHAO].[MATURACAO], [V_DADOS_TALHAO].[AREA_TOTAL], [V_DADOS_TALHAO].[_trackLastWriteTime], [V_DADOS_TALHAO].[_trackCreationTime], [V_DADOS_TALHAO].[_trackLastWriteUser], [V_DADOS_TALHAO].[_trackCreationUser] 
    FROM [V_DADOS_TALHAO] 
    WHERE ([V_DADOS_TALHAO].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[V_DADOS_TALHAO_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [V_DADOS_TALHAO].[pId], [V_DADOS_TALHAO].[ID_NEGOCIOS], [V_DADOS_TALHAO].[SAFRA], [V_DADOS_TALHAO].[COD_PROPRIEDADE], [V_DADOS_TALHAO].[DSC_PROPRIEDADE], [V_DADOS_TALHAO].[TALHAO], [V_DADOS_TALHAO].[CORTE], [V_DADOS_TALHAO].[AMBIENTE], [V_DADOS_TALHAO].[VARIEDADE], [V_DADOS_TALHAO].[MATURACAO], [V_DADOS_TALHAO].[AREA_TOTAL], [V_DADOS_TALHAO].[_trackLastWriteTime], [V_DADOS_TALHAO].[_trackCreationTime], [V_DADOS_TALHAO].[_trackLastWriteUser], [V_DADOS_TALHAO].[_trackCreationUser] 
    FROM [V_DADOS_TALHAO] 

RETURN
GO

CREATE PROCEDURE [dbo].[V_DADOS_TALHAO_LoadByCOD_PROPRIEDADE]
(
 @parSAFRA [int],
 @parCOD_PROPRIEDADE [int],
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [V_DADOS_TALHAO].[pId], [V_DADOS_TALHAO].[ID_NEGOCIOS], [V_DADOS_TALHAO].[SAFRA], [V_DADOS_TALHAO].[COD_PROPRIEDADE], [V_DADOS_TALHAO].[DSC_PROPRIEDADE], [V_DADOS_TALHAO].[TALHAO], [V_DADOS_TALHAO].[CORTE], [V_DADOS_TALHAO].[AMBIENTE], [V_DADOS_TALHAO].[VARIEDADE], [V_DADOS_TALHAO].[MATURACAO], [V_DADOS_TALHAO].[AREA_TOTAL], [V_DADOS_TALHAO].[_trackLastWriteTime], [V_DADOS_TALHAO].[_trackCreationTime], [V_DADOS_TALHAO].[_trackLastWriteUser], [V_DADOS_TALHAO].[_trackCreationUser] 
    FROM [V_DADOS_TALHAO] 
    WHERE (([V_DADOS_TALHAO].[SAFRA] = @parSAFRA) AND ([V_DADOS_TALHAO].[COD_PROPRIEDADE] = @parCOD_PROPRIEDADE))

RETURN
GO

CREATE PROCEDURE [dbo].[V_DADOS_TALHAO_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [V_DADOS_TALHAO].[pId], [V_DADOS_TALHAO].[ID_NEGOCIOS], [V_DADOS_TALHAO].[SAFRA], [V_DADOS_TALHAO].[COD_PROPRIEDADE], [V_DADOS_TALHAO].[DSC_PROPRIEDADE], [V_DADOS_TALHAO].[TALHAO], [V_DADOS_TALHAO].[CORTE], [V_DADOS_TALHAO].[AMBIENTE], [V_DADOS_TALHAO].[VARIEDADE], [V_DADOS_TALHAO].[MATURACAO], [V_DADOS_TALHAO].[AREA_TOTAL], [V_DADOS_TALHAO].[_trackLastWriteTime], [V_DADOS_TALHAO].[_trackCreationTime], [V_DADOS_TALHAO].[_trackLastWriteUser], [V_DADOS_TALHAO].[_trackCreationUser] 
    FROM [V_DADOS_TALHAO] 
    WHERE ([V_DADOS_TALHAO].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[WebSiteMap_Load]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [WebSiteMap].[pId], [WebSiteMap].[pRelPath], [WebSiteMap].[pNode], [WebSiteMap].[pDescription], [WebSiteMap].[_trackLastWriteTime], [WebSiteMap].[_trackCreationTime], [WebSiteMap].[_trackLastWriteUser], [WebSiteMap].[_trackCreationUser] 
    FROM [WebSiteMap] 
    WHERE ([WebSiteMap].[pId] = @pId)

RETURN
GO

CREATE PROCEDURE [dbo].[WebSiteMap_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT DISTINCT [WebSiteMap].[pId], [WebSiteMap].[pRelPath], [WebSiteMap].[pNode], [WebSiteMap].[pDescription], [WebSiteMap].[_trackLastWriteTime], [WebSiteMap].[_trackCreationTime], [WebSiteMap].[_trackLastWriteUser], [WebSiteMap].[_trackCreationUser] 
    FROM [WebSiteMap] 

RETURN
GO

CREATE PROCEDURE [dbo].[WebSiteMap_LoadBypId]
(
 @pId [bigint]
)
AS
SET NOCOUNT ON
SELECT DISTINCT [WebSiteMap].[pId], [WebSiteMap].[pRelPath], [WebSiteMap].[pNode], [WebSiteMap].[pDescription], [WebSiteMap].[_trackLastWriteTime], [WebSiteMap].[_trackCreationTime], [WebSiteMap].[_trackLastWriteUser], [WebSiteMap].[_trackCreationUser] 
    FROM [WebSiteMap] 
    WHERE ([WebSiteMap].[pId] = @pId)

RETURN
GO

