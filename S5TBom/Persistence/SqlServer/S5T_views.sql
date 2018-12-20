/* CodeFluent Generated . TargetVersion:Sql2014. Culture:pt-BR. UiCulture:pt-BR. Encoding:utf-8 (http://www.softfluent.com) */
set quoted_identifier OFF
GO
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vACOMP_PROD_1CORTE' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vACOMP_PROD_1CORTE]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vACOMP_PROD_1CORTE_TALHAO' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vACOMP_PROD_1CORTE_TALHAO]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vACOMP_PROD_DCORTE' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vACOMP_PROD_DCORTE]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vACOMP_PROD_DCORTE_TALHAO' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vACOMP_PROD_DCORTE_TALHAO]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vACOMPANHAMENTO_PLANTIO' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vACOMPANHAMENTO_PLANTIO]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vappconfig' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vappconfig]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vapprelatorio' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vapprelatorio]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vapprelatorioapprelatoriousuarioview' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vapprelatorioapprelatoriousuarioview]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vapprelatorioapprelatorioview' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vapprelatorioapprelatorioview]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vcadastro' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vcadastro]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vcadastrocadastroviewgeral' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vcadastrocadastroviewgeral]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vcadastrocadastroviewgeraltipo' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vcadastrocadastroviewgeraltipo]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vcadastrotipo' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vcadastrotipo]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vcadastrotipocadastrotipoviewgrid' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vcadastrotipocadastrotipoviewgrid]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vCERTIFICADO_PATIO_HORA' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vCERTIFICADO_PATIO_HORA]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vcidade' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vcidade]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vcidadecidadeviewgrid' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vcidadecidadeviewgrid]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vempresa' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vempresa]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vENT_CAMBAL_CAMINHAOVIAGENS' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vENT_CAMBAL_CAMINHAOVIAGENS]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vENT_CAMBAL_FRENTESPROP' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vENT_CAMBAL_FRENTESPROP]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vENT_CAMBAL_PRINCIPAL' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vENT_CAMBAL_PRINCIPAL]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vENTRADA_CANA_DET' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vENTRADA_CANA_DET]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vENTRADA_CANA_DET_AGRUP' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vENTRADA_CANA_DET_AGRUP]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vENTRADA_CANA_DET_MP' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vENTRADA_CANA_DET_MP]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vENTRADA_CANA_HORA' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vENTRADA_CANA_HORA]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vENTRADA_CANA_HORA_FRENTE' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vENTRADA_CANA_HORA_FRENTE]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vESCALA_COLAB' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vESCALA_COLAB]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vfilial' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vfilial]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vfilialconfig' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vfilialconfig]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vfilialfilialviewgrid' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vfilialfilialviewgrid]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vfilialfilialviewusuarios' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vfilialfilialviewusuarios]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vHISTORICO_PROPRIEDADE' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vHISTORICO_PROPRIEDADE]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vHISTORICO_PROPRIEDADE_TRATOS' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vHISTORICO_PROPRIEDADE_TRATOS]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vIdRole' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vIdRole]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vIdRoleClaim' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vIdRoleClaim]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vIdUser' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vIdUser]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vIdUserClaim' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vIdUserClaim]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vIdUserLogin' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vIdUserLogin]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vINDICADORES_AGRICOLA' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vINDICADORES_AGRICOLA]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vINDICADORES_AGRICOLA_EQUIP' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vINDICADORES_AGRICOLA_EQUIP]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vINDICADORES_AGRICOLA_TEMPOAPROV' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vINDICADORES_AGRICOLA_TEMPOAPROV]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vINFO_GERAIS' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vINFO_GERAIS]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vloginregistro' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vloginregistro]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vMAPA_PLANCOLHEITA' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vMAPA_PLANCOLHEITA]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vmenu' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vmenu]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vmenumenuvw' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vmenumenuvw]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vmenumenuvwperm' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vmenumenuvwperm]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vmenupermissao' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vmenupermissao]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vMOAGEM_CANA_HORA' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vMOAGEM_CANA_HORA]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vpais' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vpais]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vpaispaisviewgrid' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vpaispaisviewgrid]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vPROPRIEDADES' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vPROPRIEDADES]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vRES_MENSAL_ACUMULADA' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vRES_MENSAL_ACUMULADA]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vRES_MENSAL_DIARIA' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vRES_MENSAL_DIARIA]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vRES_MENSAL_GRID' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vRES_MENSAL_GRID]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vRES_MENSAL_SAFRA' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vRES_MENSAL_SAFRA]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vRES_MENSAL_SAFRA_ACUMULADA' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vRES_MENSAL_SAFRA_ACUMULADA]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vSAFRA_ANO' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vSAFRA_ANO]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vSEQUENCIA_COLHEITA' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vSEQUENCIA_COLHEITA]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vsistema' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vsistema]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vuf' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vuf]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vufufviewgrid' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vufufviewgrid]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vusuario' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vusuario]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vV_DADOS_TALHAO' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vV_DADOS_TALHAO]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vWebSiteMap' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vWebSiteMap]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'vwebsitemaplogacessousuariosviewraw' AND TABLE_SCHEMA = 'dbo')
DROP VIEW [dbo].[vwebsitemaplogacessousuariosviewraw]
GO

CREATE VIEW [dbo].[vACOMP_PROD_1CORTE]
AS
SELECT [ACOMP_PROD_1CORTE].[pId], [ACOMP_PROD_1CORTE].[ROWNUM], [ACOMP_PROD_1CORTE].[PROP_CODIGO], [ACOMP_PROD_1CORTE].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_1CORTE].[NRO_CORTE], [ACOMP_PROD_1CORTE].[QT_AREA_COLHIDA], [ACOMP_PROD_1CORTE].[IDADE], [ACOMP_PROD_1CORTE].[TIPO_PROPRIEDADE], [ACOMP_PROD_1CORTE].[QT_TON_ENTREGUE], [ACOMP_PROD_1CORTE].[RENDIMENTO_PLAN], [ACOMP_PROD_1CORTE].[RENDIMENTO_REAL], [ACOMP_PROD_1CORTE].[DESVIO], [ACOMP_PROD_1CORTE].[PORC_BROCA], [ACOMP_PROD_1CORTE].[PERDAS], [ACOMP_PROD_1CORTE].[INCENDIO], [ACOMP_PROD_1CORTE].[DATA_INCENDIO], [ACOMP_PROD_1CORTE].[DT_DESSECACAO], [ACOMP_PROD_1CORTE].[DT_CALAGEM], [ACOMP_PROD_1CORTE].[DT_PLANTIO], [ACOMP_PROD_1CORTE].[TIPO_PLANTIO], [ACOMP_PROD_1CORTE].[EMPRESA_PLANTIO], [ACOMP_PROD_1CORTE].[STAND], [ACOMP_PROD_1CORTE].[TIPO_ADUBACAO], [ACOMP_PROD_1CORTE].[TRAT_TOLETES], [ACOMP_PROD_1CORTE].[DT_HERB_CANA_PLANTA], [ACOMP_PROD_1CORTE].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_1CORTE].[_trackCreationTime], [ACOMP_PROD_1CORTE].[_trackLastWriteTime], [ACOMP_PROD_1CORTE].[_trackCreationUser], [ACOMP_PROD_1CORTE].[_trackLastWriteUser] 
    FROM [ACOMP_PROD_1CORTE]
GO

CREATE VIEW [dbo].[vACOMP_PROD_1CORTE_TALHAO]
AS
SELECT [ACOMP_PROD_1CORTE_TALHAO].[pId], [ACOMP_PROD_1CORTE_TALHAO].[ROWNUM], [ACOMP_PROD_1CORTE_TALHAO].[PROP_CODIGO], [ACOMP_PROD_1CORTE_TALHAO].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_1CORTE_TALHAO].[TALHAO], [ACOMP_PROD_1CORTE_TALHAO].[NRO_CORTE], [ACOMP_PROD_1CORTE_TALHAO].[QT_AREA_COLHIDA], [ACOMP_PROD_1CORTE_TALHAO].[IDADE], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PROPRIEDADE], [ACOMP_PROD_1CORTE_TALHAO].[QT_TON_ENTREGUE], [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_PLAN], [ACOMP_PROD_1CORTE_TALHAO].[RENDIMENTO_REAL], [ACOMP_PROD_1CORTE_TALHAO].[DESVIO], [ACOMP_PROD_1CORTE_TALHAO].[PORC_BROCA], [ACOMP_PROD_1CORTE_TALHAO].[PERDAS], [ACOMP_PROD_1CORTE_TALHAO].[INCENDIO], [ACOMP_PROD_1CORTE_TALHAO].[DATA_INCENDIO], [ACOMP_PROD_1CORTE_TALHAO].[DT_DESSECACAO], [ACOMP_PROD_1CORTE_TALHAO].[DT_CALAGEM], [ACOMP_PROD_1CORTE_TALHAO].[DT_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[EMPRESA_PLANTIO], [ACOMP_PROD_1CORTE_TALHAO].[STAND], [ACOMP_PROD_1CORTE_TALHAO].[TIPO_ADUBACAO], [ACOMP_PROD_1CORTE_TALHAO].[TRAT_TOLETES], [ACOMP_PROD_1CORTE_TALHAO].[DT_HERB_CANA_PLANTA], [ACOMP_PROD_1CORTE_TALHAO].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_1CORTE_TALHAO].[_trackCreationTime], [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteTime], [ACOMP_PROD_1CORTE_TALHAO].[_trackCreationUser], [ACOMP_PROD_1CORTE_TALHAO].[_trackLastWriteUser] 
    FROM [ACOMP_PROD_1CORTE_TALHAO]
GO

CREATE VIEW [dbo].[vACOMP_PROD_DCORTE]
AS
SELECT [ACOMP_PROD_DCORTE].[pId], [ACOMP_PROD_DCORTE].[ROWNUM], [ACOMP_PROD_DCORTE].[PROP_CODIGO], [ACOMP_PROD_DCORTE].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_DCORTE].[NRO_CORTE], [ACOMP_PROD_DCORTE].[QT_AREA_COLHIDA], [ACOMP_PROD_DCORTE].[IDADE], [ACOMP_PROD_DCORTE].[TIPO_PROPRIEDADE], [ACOMP_PROD_DCORTE].[QT_TON_ENTREGUE], [ACOMP_PROD_DCORTE].[RENDIMENTO_PLAN], [ACOMP_PROD_DCORTE].[RENDIMENTO_REAL], [ACOMP_PROD_DCORTE].[DESVIO], [ACOMP_PROD_DCORTE].[PORC_BROCA], [ACOMP_PROD_DCORTE].[PERDAS], [ACOMP_PROD_DCORTE].[DT_COLHEITA_ANTERIOR], [ACOMP_PROD_DCORTE].[TIPO_ADUBACAO], [ACOMP_PROD_DCORTE].[DT_ADUBACAO], [ACOMP_PROD_DCORTE].[DIF_DIAS_ADUB], [ACOMP_PROD_DCORTE].[TIPO_HERBICIDA], [ACOMP_PROD_DCORTE].[DT_HERBICIDA], [ACOMP_PROD_DCORTE].[DIF_DIAS_HERB], [ACOMP_PROD_DCORTE].[INCENDIO], [ACOMP_PROD_DCORTE].[DATA_INCENDIO], [ACOMP_PROD_DCORTE].[FERTIRRIGACAO], [ACOMP_PROD_DCORTE].[DT_FERTIRRIGACAO], [ACOMP_PROD_DCORTE].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_DCORTE].[_trackCreationTime], [ACOMP_PROD_DCORTE].[_trackLastWriteTime], [ACOMP_PROD_DCORTE].[_trackCreationUser], [ACOMP_PROD_DCORTE].[_trackLastWriteUser] 
    FROM [ACOMP_PROD_DCORTE]
GO

CREATE VIEW [dbo].[vACOMP_PROD_DCORTE_TALHAO]
AS
SELECT [ACOMP_PROD_DCORTE_TALHAO].[pId], [ACOMP_PROD_DCORTE_TALHAO].[ROWNUM], [ACOMP_PROD_DCORTE_TALHAO].[PROP_CODIGO], [ACOMP_PROD_DCORTE_TALHAO].[DS_NOME_PROPRIEDADE], [ACOMP_PROD_DCORTE_TALHAO].[TALHAO], [ACOMP_PROD_DCORTE_TALHAO].[NRO_CORTE], [ACOMP_PROD_DCORTE_TALHAO].[QT_AREA_COLHIDA], [ACOMP_PROD_DCORTE_TALHAO].[IDADE], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_PROPRIEDADE], [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ATUAL], [ACOMP_PROD_DCORTE_TALHAO].[QT_TON_ENTREGUE], [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_PLAN], [ACOMP_PROD_DCORTE_TALHAO].[RENDIMENTO_REAL], [ACOMP_PROD_DCORTE_TALHAO].[DESVIO], [ACOMP_PROD_DCORTE_TALHAO].[PORC_BROCA], [ACOMP_PROD_DCORTE_TALHAO].[PERDAS], [ACOMP_PROD_DCORTE_TALHAO].[DT_COLHEITA_ANTERIOR], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_ADUBACAO], [ACOMP_PROD_DCORTE_TALHAO].[DT_ADUBACAO], [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_ADUB], [ACOMP_PROD_DCORTE_TALHAO].[TIPO_HERBICIDA], [ACOMP_PROD_DCORTE_TALHAO].[DT_HERBICIDA], [ACOMP_PROD_DCORTE_TALHAO].[DIF_DIAS_HERB], [ACOMP_PROD_DCORTE_TALHAO].[INCENDIO], [ACOMP_PROD_DCORTE_TALHAO].[DATA_INCENDIO], [ACOMP_PROD_DCORTE_TALHAO].[FERTIRRIGACAO], [ACOMP_PROD_DCORTE_TALHAO].[DT_FERTIRRIGACAO], [ACOMP_PROD_DCORTE_TALHAO].[SEMANA_ENCERRAMENTO], [ACOMP_PROD_DCORTE_TALHAO].[_trackCreationTime], [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteTime], [ACOMP_PROD_DCORTE_TALHAO].[_trackCreationUser], [ACOMP_PROD_DCORTE_TALHAO].[_trackLastWriteUser] 
    FROM [ACOMP_PROD_DCORTE_TALHAO]
GO

CREATE VIEW [dbo].[vACOMPANHAMENTO_PLANTIO]
AS
SELECT [ACOMPANHAMENTO_PLANTIO].[pId], [ACOMPANHAMENTO_PLANTIO].[ID_NEGOCIOS], [ACOMPANHAMENTO_PLANTIO].[COD_PROPRIEDADE], [ACOMPANHAMENTO_PLANTIO].[SAFRA], [ACOMPANHAMENTO_PLANTIO].[DT_PLANTIO], [ACOMPANHAMENTO_PLANTIO].[AREA_PLANTIO], [ACOMPANHAMENTO_PLANTIO].[_trackCreationTime], [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteTime], [ACOMPANHAMENTO_PLANTIO].[_trackCreationUser], [ACOMPANHAMENTO_PLANTIO].[_trackLastWriteUser] 
    FROM [ACOMPANHAMENTO_PLANTIO]
GO

CREATE VIEW [dbo].[vappconfig]
AS
SELECT [appconfig].[pId], [appconfig].[_trackCreationTime], [appconfig].[_trackLastWriteTime], [appconfig].[_trackCreationUser], [appconfig].[_trackLastWriteUser] 
    FROM [appconfig]
GO

CREATE VIEW [dbo].[vapprelatorio]
AS
SELECT [apprelatorio].[pId], [apprelatorio].[pNomeFormArgumento], [apprelatorio].[pNomeRelatorio], [apprelatorio].[pNomeRdlc], [apprelatorio].[pNomeDataSet], [apprelatorio].[sCategoria], [apprelatorio].[pTituloRelatorio], [apprelatorio].[pSequencia], [apprelatorio].[pCategoriaRelatorio], [apprelatorio].[_trackCreationTime], [apprelatorio].[_trackLastWriteTime], [apprelatorio].[_trackCreationUser], [apprelatorio].[_trackLastWriteUser] 
    FROM [apprelatorio]
GO

CREATE VIEW [dbo].[vapprelatorioapprelatoriousuarioview]
AS
SELECT [apprelatorio].[pId], [apprelatorio].[pNomeFormArgumento], [apprelatorio].[pNomeRelatorio], [apprelatorio].[pNomeRdlc], [apprelatorio].[pNomeDataSet], [apprelatorio].[sCategoria], [apprelatorio].[pTituloRelatorio], [apprelatorio].[pSequencia], [apprelatorio].[pCategoriaRelatorio], [usuario].[pLogin] AS 'pUsuarioLogin', [apprelatorio].[_trackCreationTime], [apprelatorio].[_trackLastWriteTime], [apprelatorio].[_trackCreationUser], [apprelatorio].[_trackLastWriteUser] 
    FROM [apprelatorio]
        LEFT OUTER JOIN [apprelatorio_oUsuarios_usuario_oAppRelatorios] ON ([apprelatorio].[pId] = [apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId])
                LEFT OUTER JOIN [usuario] ON ([apprelatorio_oUsuarios_usuario_oAppRelatorios].[pId2] = [usuario].[pId])
GO

CREATE VIEW [dbo].[vapprelatorioapprelatorioview]
AS
SELECT [apprelatorio].[pId], [apprelatorio].[pNomeFormArgumento], [apprelatorio].[pNomeRelatorio], [apprelatorio].[pNomeRdlc], [apprelatorio].[pNomeDataSet], [apprelatorio].[sCategoria], [apprelatorio].[pTituloRelatorio], [apprelatorio].[pSequencia], [apprelatorio].[pCategoriaRelatorio], [apprelatorio].[_trackCreationTime], [apprelatorio].[_trackLastWriteTime], [apprelatorio].[_trackCreationUser], [apprelatorio].[_trackLastWriteUser] 
    FROM [apprelatorio]
GO

CREATE VIEW [dbo].[vcadastro]
AS
SELECT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[oCidade_pId], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[oCidadeAux_pId], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cadastro].[pFax], [cadastro].[xDataHoraReg], [cadastro].[xLoginReg], [cadastro].[oUsuario_pId], [cadastro].[pCep], [cadastro].[pCepAux], [cadastro].[pFlgPreCadastro], [cadastro].[oCadastroFilial_pId], [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationUser], [cadastro].[_trackLastWriteUser] 
    FROM [cadastro]
GO

CREATE VIEW [dbo].[vcadastrocadastroviewgeral]
AS
SELECT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cidade].[pCodigo] AS 'pCodigoCidade', [cidade].[pNome] AS 'pNomeCidade', [uf].[pSigla] AS 'pUFCidade', [cidade$1].[pCodigo] AS 'pCodigoCidadeAux', [cidade$1].[pNome] AS 'pNomeCidadeaux', [uf$1].[pSigla] AS 'pUFCidadeAux', [empresa].[pCodigo] AS 'pCodigoEmpresa', [empresa].[pNome] AS 'pNomeEmpresa', [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationUser], [cadastro].[_trackLastWriteUser] 
    FROM [cadastro]
        LEFT OUTER JOIN [cidade] ON ([cadastro].[oCidade_pId] = [cidade].[pId])
                LEFT OUTER JOIN [uf] ON ([cidade].[oUF_pId] = [uf].[pId])
                LEFT OUTER JOIN [cidade] [cidade$1] ON ([cadastro].[oCidadeAux_pId] = [cidade$1].[pId])
                LEFT OUTER JOIN [cidade] [cidade$2] ON ([cadastro].[oCidadeAux_pId] = [cidade$2].[pId])
                        LEFT OUTER JOIN [uf] [uf$1] ON ([cidade$2].[oUF_pId] = [uf$1].[pId])
        LEFT OUTER JOIN [cadastro_oempresas_empresa_ocadastros] ON ([cadastro].[pId] = [cadastro_oempresas_empresa_ocadastros].[pId])
                LEFT OUTER JOIN [empresa] ON ([cadastro_oempresas_empresa_ocadastros].[pId2] = [empresa].[pId])
GO

CREATE VIEW [dbo].[vcadastrocadastroviewgeraltipo]
AS
SELECT [cadastro].[pId], [cadastro].[pNome], [cadastro].[pCodigo], [cadastro].[pPFPJ], [cadastro].[pEndereco], [cadastro].[pEnderLogradouro], [cadastro].[pEnderComplemento], [cadastro].[pEnderBairro], [cadastro].[pEnderNumero], [cadastro].[pEnderAuxLogradouro], [cadastro].[pEnderAuxNumero], [cadastro].[pEnderAuxBairro], [cadastro].[pEnderAuxComplemento], [cadastro].[pEnderecoAux], [cadastro].[pEmail], [cadastro].[pCpfCnpj], [cadastro].[pDataNascimento], [cadastro].[pRgIe], [cadastro].[pNomeFantasia], [cadastro].[pFlgSexo], [cadastro].[pDataCadastro], [cadastro].[pDataBaixa], [cadastro].[pTelefone], [cadastro].[pTelefoneAux], [cadastro].[pCelular], [cidade].[pCodigo] AS 'pCodigoCidade', [cidade].[pNome] AS 'pNomeCidade', [uf].[pSigla] AS 'pUFCidade', [cidade$1].[pCodigo] AS 'pCodigoCidadeAux', [cidade$1].[pNome] AS 'pNomeCidadeaux', [uf$1].[pSigla] AS 'pUFCidadeAux', [empresa].[pCodigo] AS 'pCodigoEmpresa', [empresa].[pNome] AS 'pNomeEmpresa', [cadastrotipo].[pFlgCadastro] AS 'pCadastroTipoFlgTipo', [cadastrotipo].[pDescricao] AS 'pCadastroTipoDescricao', [cadastro].[_trackCreationTime], [cadastro].[_trackLastWriteTime], [cadastro].[_trackCreationUser], [cadastro].[_trackLastWriteUser] 
    FROM [cadastro]
        LEFT OUTER JOIN [cidade] ON ([cadastro].[oCidade_pId] = [cidade].[pId])
                LEFT OUTER JOIN [uf] ON ([cidade].[oUF_pId] = [uf].[pId])
                LEFT OUTER JOIN [cidade] [cidade$1] ON ([cadastro].[oCidadeAux_pId] = [cidade$1].[pId])
                LEFT OUTER JOIN [cidade] [cidade$2] ON ([cadastro].[oCidadeAux_pId] = [cidade$2].[pId])
                        LEFT OUTER JOIN [uf] [uf$1] ON ([cidade$2].[oUF_pId] = [uf$1].[pId])
        LEFT OUTER JOIN [cadastro_oempresas_empresa_ocadastros] ON ([cadastro].[pId] = [cadastro_oempresas_empresa_ocadastros].[pId])
                LEFT OUTER JOIN [empresa] ON ([cadastro_oempresas_empresa_ocadastros].[pId2] = [empresa].[pId])
        LEFT OUTER JOIN [cadastro_ocadastrostipo_cadastrotipo_ocadastros] ON ([cadastro].[pId] = [cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId])
                LEFT OUTER JOIN [cadastrotipo] ON ([cadastro_ocadastrostipo_cadastrotipo_ocadastros].[pId2] = [cadastrotipo].[pId])
GO

CREATE VIEW [dbo].[vcadastrotipo]
AS
SELECT [cadastrotipo].[pId], [cadastrotipo].[pDescricao], [cadastrotipo].[pFlgCadastro], [cadastrotipo].[xDataHoraReg], [cadastrotipo].[xLoginReg], [cadastrotipo].[_trackCreationTime], [cadastrotipo].[_trackLastWriteTime], [cadastrotipo].[_trackCreationUser], [cadastrotipo].[_trackLastWriteUser] 
    FROM [cadastrotipo]
GO

CREATE VIEW [dbo].[vcadastrotipocadastrotipoviewgrid]
AS
SELECT [cadastrotipo].[pId], [cadastrotipo].[pDescricao], [cadastrotipo].[pFlgCadastro], [cadastrotipo].[_trackCreationTime], [cadastrotipo].[_trackLastWriteTime], [cadastrotipo].[_trackCreationUser], [cadastrotipo].[_trackLastWriteUser] 
    FROM [cadastrotipo]
GO

CREATE VIEW [dbo].[vCERTIFICADO_PATIO_HORA]
AS
SELECT [CERTIFICADO_PATIO_HORA].[pId], [CERTIFICADO_PATIO_HORA].[ID_NEGOCIOS], [CERTIFICADO_PATIO_HORA].[DIA], [CERTIFICADO_PATIO_HORA].[HORA], [CERTIFICADO_PATIO_HORA].[FRENTE], [CERTIFICADO_PATIO_HORA].[CERTIFICADOS], [CERTIFICADO_PATIO_HORA].[CERT_VAZIO], [CERTIFICADO_PATIO_HORA].[_trackCreationTime], [CERTIFICADO_PATIO_HORA].[_trackLastWriteTime], [CERTIFICADO_PATIO_HORA].[_trackCreationUser], [CERTIFICADO_PATIO_HORA].[_trackLastWriteUser] 
    FROM [CERTIFICADO_PATIO_HORA]
GO

CREATE VIEW [dbo].[vcidade]
AS
SELECT [cidade].[pId], [cidade].[pNome], [cidade].[pCodigo], [cidade].[pCodigoIbge], [cidade].[oUF_pId], [cidade].[xDataHoraReg], [cidade].[xLoginReg], [cidade].[_trackCreationTime], [cidade].[_trackLastWriteTime], [cidade].[_trackCreationUser], [cidade].[_trackLastWriteUser] 
    FROM [cidade]
GO

CREATE VIEW [dbo].[vcidadecidadeviewgrid]
AS
SELECT [cidade].[pId], [cidade].[pNome], [cidade].[pCodigo], [cidade].[pCodigoIbge], [uf].[pDescricao] AS 'UF', [uf].[pSigla] AS 'Sigla', [cidade].[_trackCreationTime], [cidade].[_trackLastWriteTime], [cidade].[_trackCreationUser], [cidade].[_trackLastWriteUser] 
    FROM [cidade]
        LEFT OUTER JOIN [uf] ON ([cidade].[oUF_pId] = [uf].[pId])
GO

CREATE VIEW [dbo].[vempresa]
AS
SELECT [empresa].[pId], [empresa].[pCodigo], [empresa].[pNome], [empresa].[xDataHoraReg], [empresa].[xLoginReg], [empresa].[pSimplesNacionalValorAliquotaCreditoICMS], [empresa].[sSimplesNacionalCategoria], [empresa].[sCodigoRegimeTributario], [empresa].[sCodigoRegimeTributarioNormal], [empresa].[_trackCreationTime], [empresa].[_trackLastWriteTime], [empresa].[_trackCreationUser], [empresa].[_trackLastWriteUser] 
    FROM [empresa]
GO

CREATE VIEW [dbo].[vENT_CAMBAL_CAMINHAOVIAGENS]
AS
SELECT [ENT_CAMBAL_CAMINHAOVIAGENS].[pId], [ENT_CAMBAL_CAMINHAOVIAGENS].[ROWNUM], [ENT_CAMBAL_CAMINHAOVIAGENS].[FRENTE], [ENT_CAMBAL_CAMINHAOVIAGENS].[COD_PROP], [ENT_CAMBAL_CAMINHAOVIAGENS].[CAMINHAO], [ENT_CAMBAL_CAMINHAOVIAGENS].[QTD_VIAGENS], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackCreationTime], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteTime], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackCreationUser], [ENT_CAMBAL_CAMINHAOVIAGENS].[_trackLastWriteUser] 
    FROM [ENT_CAMBAL_CAMINHAOVIAGENS]
GO

CREATE VIEW [dbo].[vENT_CAMBAL_FRENTESPROP]
AS
SELECT [ENT_CAMBAL_FRENTESPROP].[pId], [ENT_CAMBAL_FRENTESPROP].[ROWNUM], [ENT_CAMBAL_FRENTESPROP].[FRENTE], [ENT_CAMBAL_FRENTESPROP].[COD_PROP], [ENT_CAMBAL_FRENTESPROP].[PROPRIEDADE], [ENT_CAMBAL_FRENTESPROP].[QTD_VIAGENS], [ENT_CAMBAL_FRENTESPROP].[_trackCreationTime], [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteTime], [ENT_CAMBAL_FRENTESPROP].[_trackCreationUser], [ENT_CAMBAL_FRENTESPROP].[_trackLastWriteUser] 
    FROM [ENT_CAMBAL_FRENTESPROP]
GO

CREATE VIEW [dbo].[vENT_CAMBAL_PRINCIPAL]
AS
SELECT [ENT_CAMBAL_PRINCIPAL].[pId], [ENT_CAMBAL_PRINCIPAL].[HORA], [ENT_CAMBAL_PRINCIPAL].[F1], [ENT_CAMBAL_PRINCIPAL].[F2], [ENT_CAMBAL_PRINCIPAL].[F3], [ENT_CAMBAL_PRINCIPAL].[F4], [ENT_CAMBAL_PRINCIPAL].[F5], [ENT_CAMBAL_PRINCIPAL].[F6], [ENT_CAMBAL_PRINCIPAL].[F7], [ENT_CAMBAL_PRINCIPAL].[F8], [ENT_CAMBAL_PRINCIPAL].[F9], [ENT_CAMBAL_PRINCIPAL].[F10], [ENT_CAMBAL_PRINCIPAL].[TOTAL], [ENT_CAMBAL_PRINCIPAL].[_trackCreationTime], [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteTime], [ENT_CAMBAL_PRINCIPAL].[_trackCreationUser], [ENT_CAMBAL_PRINCIPAL].[_trackLastWriteUser] 
    FROM [ENT_CAMBAL_PRINCIPAL]
GO

CREATE VIEW [dbo].[vENTRADA_CANA_DET]
AS
SELECT [ENTRADA_CANA_DET].[pId], [ENTRADA_CANA_DET].[ID_NEGOCIOS], [ENTRADA_CANA_DET].[NR_ANO_SAFRA], [ENTRADA_CANA_DET].[NRO_DOCUMENTO], [ENTRADA_CANA_DET].[PROP_CODIGO], [ENTRADA_CANA_DET].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET].[DSC_VARIEDADE], [ENTRADA_CANA_DET].[NRO_CORTE], [ENTRADA_CANA_DET].[FRENTE_COLHEITA], [ENTRADA_CANA_DET].[MUNICIPIO], [ENTRADA_CANA_DET].[DESCMUNI], [ENTRADA_CANA_DET].[TIPO], [ENTRADA_CANA_DET].[DESCTIPO], [ENTRADA_CANA_DET].[DT_ENTRADA], [ENTRADA_CANA_DET].[EQUIP_ENTRADA], [ENTRADA_CANA_DET].[REBOQUE], [ENTRADA_CANA_DET].[DT_MOAGEM], [ENTRADA_CANA_DET].[AREA_COLHIDA], [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_PREV], [ENTRADA_CANA_DET].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET].[_trackCreationTime], [ENTRADA_CANA_DET].[_trackLastWriteTime], [ENTRADA_CANA_DET].[_trackCreationUser], [ENTRADA_CANA_DET].[_trackLastWriteUser] 
    FROM [ENTRADA_CANA_DET]
GO

CREATE VIEW [dbo].[vENTRADA_CANA_DET_AGRUP]
AS
SELECT [ENTRADA_CANA_DET_AGRUP].[pId], [ENTRADA_CANA_DET_AGRUP].[ID_NEGOCIOS], [ENTRADA_CANA_DET_AGRUP].[NR_ANO_SAFRA], [ENTRADA_CANA_DET_AGRUP].[NRO_DOCUMENTO], [ENTRADA_CANA_DET_AGRUP].[PROP_CODIGO], [ENTRADA_CANA_DET_AGRUP].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET_AGRUP].[FRENTE_COLHEITA], [ENTRADA_CANA_DET_AGRUP].[MUNICIPIO], [ENTRADA_CANA_DET_AGRUP].[DESCMUNI], [ENTRADA_CANA_DET_AGRUP].[TIPO], [ENTRADA_CANA_DET_AGRUP].[DESCTIPO], [ENTRADA_CANA_DET_AGRUP].[DT_ENTRADA], [ENTRADA_CANA_DET_AGRUP].[DT_MOAGEM], [ENTRADA_CANA_DET_AGRUP].[AREA_COLHIDA], [ENTRADA_CANA_DET_AGRUP].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET_AGRUP].[_trackCreationTime], [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteTime], [ENTRADA_CANA_DET_AGRUP].[_trackCreationUser], [ENTRADA_CANA_DET_AGRUP].[_trackLastWriteUser] 
    FROM [ENTRADA_CANA_DET_AGRUP]
GO

CREATE VIEW [dbo].[vENTRADA_CANA_DET_MP]
AS
SELECT [ENTRADA_CANA_DET_MP].[pId], [ENTRADA_CANA_DET_MP].[ID_NEGOCIOS], [ENTRADA_CANA_DET_MP].[NR_ANO_SAFRA], [ENTRADA_CANA_DET_MP].[PROP_CODIGO], [ENTRADA_CANA_DET_MP].[DS_NOME_PROPRIEDADE], [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITATOP], [ENTRADA_CANA_DET_MP].[FRENTE_COLHEITA], [ENTRADA_CANA_DET_MP].[MUNICIPIO], [ENTRADA_CANA_DET_MP].[DESCMUNI], [ENTRADA_CANA_DET_MP].[QT_TON_ENTREGUE_REAL], [ENTRADA_CANA_DET_MP].[INICIO], [ENTRADA_CANA_DET_MP].[_trackCreationTime], [ENTRADA_CANA_DET_MP].[_trackLastWriteTime], [ENTRADA_CANA_DET_MP].[_trackCreationUser], [ENTRADA_CANA_DET_MP].[_trackLastWriteUser] 
    FROM [ENTRADA_CANA_DET_MP]
GO

CREATE VIEW [dbo].[vENTRADA_CANA_HORA]
AS
SELECT [ENTRADA_CANA_HORA].[pId], [ENTRADA_CANA_HORA].[ID_NEGOCIOS], [ENTRADA_CANA_HORA].[DIA], [ENTRADA_CANA_HORA].[HORA], [ENTRADA_CANA_HORA].[TONELADAS], [ENTRADA_CANA_HORA].[VIAGEM], [ENTRADA_CANA_HORA].[TON_VIAGEM], [ENTRADA_CANA_HORA].[METAFRENTE], [ENTRADA_CANA_HORA].[_trackCreationTime], [ENTRADA_CANA_HORA].[_trackLastWriteTime], [ENTRADA_CANA_HORA].[_trackCreationUser], [ENTRADA_CANA_HORA].[_trackLastWriteUser] 
    FROM [ENTRADA_CANA_HORA]
GO

CREATE VIEW [dbo].[vENTRADA_CANA_HORA_FRENTE]
AS
SELECT [ENTRADA_CANA_HORA_FRENTE].[pId], [ENTRADA_CANA_HORA_FRENTE].[ID_NEGOCIOS], [ENTRADA_CANA_HORA_FRENTE].[DIA], [ENTRADA_CANA_HORA_FRENTE].[HORA], [ENTRADA_CANA_HORA_FRENTE].[FRENTE], [ENTRADA_CANA_HORA_FRENTE].[TONELADAS], [ENTRADA_CANA_HORA_FRENTE].[VIAGEM], [ENTRADA_CANA_HORA_FRENTE].[TON_VIAGEM], [ENTRADA_CANA_HORA_FRENTE].[METAFRENTE], [ENTRADA_CANA_HORA_FRENTE].[_trackCreationTime], [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteTime], [ENTRADA_CANA_HORA_FRENTE].[_trackCreationUser], [ENTRADA_CANA_HORA_FRENTE].[_trackLastWriteUser] 
    FROM [ENTRADA_CANA_HORA_FRENTE]
GO

CREATE VIEW [dbo].[vESCALA_COLAB]
AS
SELECT [ESCALA_COLAB].[pId], [ESCALA_COLAB].[ROWNUM], [ESCALA_COLAB].[PROCESSO], [ESCALA_COLAB].[ESTRUTURA], [ESCALA_COLAB].[MATRICULA], [ESCALA_COLAB].[NOME], [ESCALA_COLAB].[TURNO], [ESCALA_COLAB].[DIA01], [ESCALA_COLAB].[DIA02], [ESCALA_COLAB].[DIA03], [ESCALA_COLAB].[DIA04], [ESCALA_COLAB].[DIA05], [ESCALA_COLAB].[DIA06], [ESCALA_COLAB].[DIA07], [ESCALA_COLAB].[DIA08], [ESCALA_COLAB].[DIA09], [ESCALA_COLAB].[DIA10], [ESCALA_COLAB].[DIA11], [ESCALA_COLAB].[DIA12], [ESCALA_COLAB].[DIA13], [ESCALA_COLAB].[DIA14], [ESCALA_COLAB].[DIA15], [ESCALA_COLAB].[DIA16], [ESCALA_COLAB].[DIA17], [ESCALA_COLAB].[DIA18], [ESCALA_COLAB].[DIA19], [ESCALA_COLAB].[DIA20], [ESCALA_COLAB].[DIA21], [ESCALA_COLAB].[DIA22], [ESCALA_COLAB].[DIA23], [ESCALA_COLAB].[DIA24], [ESCALA_COLAB].[DIA25], [ESCALA_COLAB].[DIA26], [ESCALA_COLAB].[DIA27], [ESCALA_COLAB].[DIA28], [ESCALA_COLAB].[DIA29], [ESCALA_COLAB].[DIA30], [ESCALA_COLAB].[CELULAR], [ESCALA_COLAB].[ID_NIVEL], [ESCALA_COLAB].[ID_TURMAS], [ESCALA_COLAB].[_trackCreationTime], [ESCALA_COLAB].[_trackLastWriteTime], [ESCALA_COLAB].[_trackCreationUser], [ESCALA_COLAB].[_trackLastWriteUser] 
    FROM [ESCALA_COLAB]
GO

CREATE VIEW [dbo].[vfilial]
AS
SELECT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [filial].[xDataHoraReg], [filial].[xLoginReg], [filial].[oEmpresa_pId], [filial].[oCadastro_pId], [filial].[_trackCreationTime], [filial].[_trackLastWriteTime], [filial].[_trackCreationUser], [filial].[_trackLastWriteUser] 
    FROM [filial]
GO

CREATE VIEW [dbo].[vfilialconfig]
AS
SELECT [filialconfig].[pId], [filialconfig].[sTipo], [filialconfig].[pConteudo], [filialconfig].[xDataHoraReg], [filialconfig].[xLoginReg], [filialconfig].[oFilial_pId], [filialconfig].[_trackCreationTime], [filialconfig].[_trackLastWriteTime], [filialconfig].[_trackCreationUser], [filialconfig].[_trackLastWriteUser] 
    FROM [filialconfig]
GO

CREATE VIEW [dbo].[vfilialfilialviewgrid]
AS
SELECT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [empresa].[pCodigo] AS 'pCodEmpresa', [empresa].[pNome] AS 'pNomEmpresa', [cadastro].[pCpfCnpj] AS 'pCNPJ', [filial].[_trackCreationTime], [filial].[_trackLastWriteTime], [filial].[_trackCreationUser], [filial].[_trackLastWriteUser] 
    FROM [filial]
        LEFT OUTER JOIN [empresa] ON ([filial].[oEmpresa_pId] = [empresa].[pId])
                LEFT OUTER JOIN [cadastro] ON ([filial].[pId] = [cadastro].[oCadastroFilial_pId])
GO

CREATE VIEW [dbo].[vfilialfilialviewusuarios]
AS
SELECT [filial].[pId], [filial].[pCodigo], [filial].[pNome], [filial].[sTipo], [empresa].[pCodigo] AS 'pEmpresaCodigo', [empresa].[pNome] AS 'pEmpresaNome', [usuario].[pLogin] AS 'pUsuarioLogin', [filial].[_trackCreationTime], [filial].[_trackLastWriteTime], [filial].[_trackCreationUser], [filial].[_trackLastWriteUser] 
    FROM [filial]
        LEFT OUTER JOIN [empresa] ON ([filial].[oEmpresa_pId] = [empresa].[pId])
        LEFT OUTER JOIN [filial_ousuarios_usuario_ofiliais] ON ([filial].[pId] = [filial_ousuarios_usuario_ofiliais].[pId])
                LEFT OUTER JOIN [usuario] ON ([filial_ousuarios_usuario_ofiliais].[pId2] = [usuario].[pId])
GO

CREATE VIEW [dbo].[vHISTORICO_PROPRIEDADE]
AS
SELECT [HISTORICO_PROPRIEDADE].[pId], [HISTORICO_PROPRIEDADE].[ID_NEGOCIOS], [HISTORICO_PROPRIEDADE].[SAFRA], [HISTORICO_PROPRIEDADE].[COD_PROPRIEDADE], [HISTORICO_PROPRIEDADE].[DSC_PROPRIEDADE], [HISTORICO_PROPRIEDADE].[TALHAO], [HISTORICO_PROPRIEDADE].[RENDIMENTO_PLAN], [HISTORICO_PROPRIEDADE].[CORTE], [HISTORICO_PROPRIEDADE].[AMBIENTE], [HISTORICO_PROPRIEDADE].[DT_PLANTIO], [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ANT], [HISTORICO_PROPRIEDADE].[DT_COLHEITA_ATU], [HISTORICO_PROPRIEDADE].[AREA_TOTAL], [HISTORICO_PROPRIEDADE].[AREA_LIBERADA], [HISTORICO_PROPRIEDADE].[TONELADA], [HISTORICO_PROPRIEDADE].[RENDIMENTO_REAL], [HISTORICO_PROPRIEDADE].[TCH], [HISTORICO_PROPRIEDADE].[IDADE], [HISTORICO_PROPRIEDADE].[PERC_BROCA], [HISTORICO_PROPRIEDADE].[PERC_PERDA], [HISTORICO_PROPRIEDADE].[_trackCreationTime], [HISTORICO_PROPRIEDADE].[_trackLastWriteTime], [HISTORICO_PROPRIEDADE].[_trackCreationUser], [HISTORICO_PROPRIEDADE].[_trackLastWriteUser] 
    FROM [HISTORICO_PROPRIEDADE]
GO

CREATE VIEW [dbo].[vHISTORICO_PROPRIEDADE_TRATOS]
AS
SELECT [HISTORICO_PROPRIEDADE_TRATOS].[pId], [HISTORICO_PROPRIEDADE_TRATOS].[ID_NEGOCIOS], [HISTORICO_PROPRIEDADE_TRATOS].[SAFRA], [HISTORICO_PROPRIEDADE_TRATOS].[COD_PROPRIEDADE], [HISTORICO_PROPRIEDADE_TRATOS].[DSC_PROPRIEDADE], [HISTORICO_PROPRIEDADE_TRATOS].[TALHAO], [HISTORICO_PROPRIEDADE_TRATOS].[CORTE], [HISTORICO_PROPRIEDADE_TRATOS].[AMBIENTE], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_DIS], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TALHAO_MUDA], [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ANT], [HISTORICO_PROPRIEDADE_TRATOS].[COLHEITA_ATU], [HISTORICO_PROPRIEDADE_TRATOS].[ATIVIDADE], [HISTORICO_PROPRIEDADE_TRATOS].[DSC_ATIVIDADE], [HISTORICO_PROPRIEDADE_TRATOS].[NRO_RECOM], [HISTORICO_PROPRIEDADE_TRATOS].[DATA_APLICACAO], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_APLICADA], [HISTORICO_PROPRIEDADE_TRATOS].[TOTAL_TALHAO_DISP], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_DISP], [HISTORICO_PROPRIEDADE_TRATOS].[AREA_TOT_TH_MUDA], [HISTORICO_PROPRIEDADE_TRATOS].[GRUPO_SUBGRUPO_AGR], [HISTORICO_PROPRIEDADE_TRATOS].[_trackCreationTime], [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteTime], [HISTORICO_PROPRIEDADE_TRATOS].[_trackCreationUser], [HISTORICO_PROPRIEDADE_TRATOS].[_trackLastWriteUser] 
    FROM [HISTORICO_PROPRIEDADE_TRATOS]
GO

CREATE VIEW [dbo].[vIdRole]
AS
SELECT [IdRole].[Id], [IdRole].[Name], [IdRole].[_trackCreationTime], [IdRole].[_trackLastWriteTime], [IdRole].[_trackCreationUser], [IdRole].[_trackLastWriteUser] 
    FROM [IdRole]
GO

CREATE VIEW [dbo].[vIdRoleClaim]
AS
SELECT [IdRoleClaim].[Id], [IdRoleClaim].[Type], [IdRoleClaim].[Value], [IdRoleClaim].[ValueType], [IdRoleClaim].[Role_Id], [IdRoleClaim].[_trackCreationTime], [IdRoleClaim].[_trackLastWriteTime], [IdRoleClaim].[_trackCreationUser], [IdRoleClaim].[_trackLastWriteUser] 
    FROM [IdRoleClaim]
GO

CREATE VIEW [dbo].[vIdUser]
AS
SELECT [IdUser].[Id], [IdUser].[UserName], [IdUser].[CreationDateUTC], [IdUser].[Email], [IdUser].[EmailConfirmed], [IdUser].[PhoneNumber], [IdUser].[PhoneNumberConfirmed], [IdUser].[Password], [IdUser].[LastPasswordChangeDate], [IdUser].[AccessFailedCount], [IdUser].[AccessFailedWindowStart], [IdUser].[LockoutEnabled], [IdUser].[LockoutEndDateUtc], [IdUser].[LastProfileUpdateDate], [IdUser].[SecurityStamp], [IdUser].[TwoFactorEnabled], [IdUser].[oUsuario_pId], [IdUser].[_trackCreationTime], [IdUser].[_trackLastWriteTime], [IdUser].[_trackCreationUser], [IdUser].[_trackLastWriteUser] 
    FROM [IdUser]
GO

CREATE VIEW [dbo].[vIdUserClaim]
AS
SELECT [IdUserClaim].[Id], [IdUserClaim].[Type], [IdUserClaim].[Value], [IdUserClaim].[ValueType], [IdUserClaim].[Issuer], [IdUserClaim].[OriginalIssuer], [IdUserClaim].[User_Id], [IdUserClaim].[_trackCreationTime], [IdUserClaim].[_trackLastWriteTime], [IdUserClaim].[_trackCreationUser], [IdUserClaim].[_trackLastWriteUser] 
    FROM [IdUserClaim]
GO

CREATE VIEW [dbo].[vIdUserLogin]
AS
SELECT [IdUserLogin].[Id], [IdUserLogin].[ProviderName], [IdUserLogin].[ProviderKey], [IdUserLogin].[ProviderDisplayName], [IdUserLogin].[User_Id], [IdUserLogin].[_trackCreationTime], [IdUserLogin].[_trackLastWriteTime], [IdUserLogin].[_trackCreationUser], [IdUserLogin].[_trackLastWriteUser] 
    FROM [IdUserLogin]
GO

CREATE VIEW [dbo].[vINDICADORES_AGRICOLA]
AS
SELECT [INDICADORES_AGRICOLA].[pId], [INDICADORES_AGRICOLA].[NOTACALC], [INDICADORES_AGRICOLA].[FRENTETIPO], [INDICADORES_AGRICOLA].[FRENTETIPOAUX], [INDICADORES_AGRICOLA].[DS_FRENTE], [INDICADORES_AGRICOLA].[DS_TIPO], [INDICADORES_AGRICOLA].[DS_FRENTETIPO], [INDICADORES_AGRICOLA].[ID_NEGOCIOS], [INDICADORES_AGRICOLA].[INDICADOR], [INDICADORES_AGRICOLA].[FRENTE], [INDICADORES_AGRICOLA].[PLANEJADO], [INDICADORES_AGRICOLA].[REALIZADO], [INDICADORES_AGRICOLA].[PERC], [INDICADORES_AGRICOLA].[NOTA], [INDICADORES_AGRICOLA].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA].[UNIDADE_MEDIDA], [INDICADORES_AGRICOLA].[PERC_ABAIXO_META], [INDICADORES_AGRICOLA].[PERC_ACIMA_META], [INDICADORES_AGRICOLA].[TIPO], [INDICADORES_AGRICOLA].[GRUPO], [INDICADORES_AGRICOLA].[_trackCreationTime], [INDICADORES_AGRICOLA].[_trackLastWriteTime], [INDICADORES_AGRICOLA].[_trackCreationUser], [INDICADORES_AGRICOLA].[_trackLastWriteUser] 
    FROM [INDICADORES_AGRICOLA]
GO

CREATE VIEW [dbo].[vINDICADORES_AGRICOLA_EQUIP]
AS
SELECT [INDICADORES_AGRICOLA_EQUIP].[pId], [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPO], [INDICADORES_AGRICOLA_EQUIP].[FRENTETIPOAUX], [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTE], [INDICADORES_AGRICOLA_EQUIP].[DS_TIPO], [INDICADORES_AGRICOLA_EQUIP].[DS_FRENTETIPO], [INDICADORES_AGRICOLA_EQUIP].[ID_NEGOCIOS], [INDICADORES_AGRICOLA_EQUIP].[FRENTE], [INDICADORES_AGRICOLA_EQUIP].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA_EQUIP].[TIPO], [INDICADORES_AGRICOLA_EQUIP].[GRUPO], [INDICADORES_AGRICOLA_EQUIP].[DSC_EQUIPAMENTO], [INDICADORES_AGRICOLA_EQUIP].[NRO_EQUIPAMENTO], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_COLHEDORA], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA_DEMAIS], [INDICADORES_AGRICOLA_EQUIP].[R_DISP_MECANICA], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTH], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELKML], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_DIESELLTTON], [INDICADORES_AGRICOLA_EQUIP].[R_CONSUMO_OLEO_HIDRAULICO], [INDICADORES_AGRICOLA_EQUIP].[R_TEMPO_APROVEIT_COLHEDORA], [INDICADORES_AGRICOLA_EQUIP].[_trackCreationTime], [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteTime], [INDICADORES_AGRICOLA_EQUIP].[_trackCreationUser], [INDICADORES_AGRICOLA_EQUIP].[_trackLastWriteUser] 
    FROM [INDICADORES_AGRICOLA_EQUIP]
GO

CREATE VIEW [dbo].[vINDICADORES_AGRICOLA_TEMPOAPROV]
AS
SELECT [INDICADORES_AGRICOLA_TEMPOAPROV].[pId], [INDICADORES_AGRICOLA_TEMPOAPROV].[DATA_FECHAMENTO], [INDICADORES_AGRICOLA_TEMPOAPROV].[PERC_TEMPO_APROV], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackCreationTime], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteTime], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackCreationUser], [INDICADORES_AGRICOLA_TEMPOAPROV].[_trackLastWriteUser] 
    FROM [INDICADORES_AGRICOLA_TEMPOAPROV]
GO

CREATE VIEW [dbo].[vINFO_GERAIS]
AS
SELECT [INFO_GERAIS].[pId], [INFO_GERAIS].[FRENTE], [INFO_GERAIS].[PROPRIEDADE], [INFO_GERAIS].[DSC_PROPRIEDADE], [INFO_GERAIS].[COLHEDORA], [INFO_GERAIS].[TONELADA], [INFO_GERAIS].[QTD_VIAGENS], [INFO_GERAIS].[MEDIA_VIAGEM], [INFO_GERAIS].[RAIO_MEDIO], [INFO_GERAIS].[IMP_MINERAL], [INFO_GERAIS].[IMP_VEGETAL_PALHA], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA], [INFO_GERAIS].[IMP_MINERAL1], [INFO_GERAIS].[IMP_MINERAL2], [INFO_GERAIS].[IMP_VEGETAL_PALHA1], [INFO_GERAIS].[IMP_VEGETAL_PALHA2], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA1], [INFO_GERAIS].[IMP_VEGETAL_PONTEIRA2], [INFO_GERAIS].[_trackCreationTime], [INFO_GERAIS].[_trackLastWriteTime], [INFO_GERAIS].[_trackCreationUser], [INFO_GERAIS].[_trackLastWriteUser] 
    FROM [INFO_GERAIS]
GO

CREATE VIEW [dbo].[vloginregistro]
AS
SELECT [loginregistro].[pId], [loginregistro].[pDataHora], [loginregistro].[pSenha], [loginregistro].[pObsLog], [loginregistro].[pCodigoUsuario], [loginregistro].[pLoginUsuario], [loginregistro].[pFlgAdminUsuario], [loginregistro].[pCodigoFilial], [loginregistro].[pCodigoEmpresa], [loginregistro].[pLoginValidado], [loginregistro].[sUsuarioStatus], [loginregistro].[_trackCreationTime], [loginregistro].[_trackLastWriteTime], [loginregistro].[_trackCreationUser], [loginregistro].[_trackLastWriteUser] 
    FROM [loginregistro]
GO

CREATE VIEW [dbo].[vMAPA_PLANCOLHEITA]
AS
SELECT [MAPA_PLANCOLHEITA].[pId], [MAPA_PLANCOLHEITA].[PROP_CODIGO], [MAPA_PLANCOLHEITA].[DS_NOME_PROPRIEDADE], [MAPA_PLANCOLHEITA].[FRENTE_COLHEITA], [MAPA_PLANCOLHEITA].[MES], [MAPA_PLANCOLHEITA].[SEMANA], [MAPA_PLANCOLHEITA].[MES_SEMANA], [MAPA_PLANCOLHEITA].[SEMANA_PERIODO], [MAPA_PLANCOLHEITA].[REFORMA_PREV], [MAPA_PLANCOLHEITA].[AREA_PREV], [MAPA_PLANCOLHEITA].[TONELADA_PREV], [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA], [MAPA_PLANCOLHEITA].[TONELADA_PREV_REFORMA], [MAPA_PLANCOLHEITA].[AREA_PREV_TOTAL], [MAPA_PLANCOLHEITA].[AREA_PREV_REFORMA_TOTAL], [MAPA_PLANCOLHEITA].[_trackCreationTime], [MAPA_PLANCOLHEITA].[_trackLastWriteTime], [MAPA_PLANCOLHEITA].[_trackCreationUser], [MAPA_PLANCOLHEITA].[_trackLastWriteUser] 
    FROM [MAPA_PLANCOLHEITA]
GO

CREATE VIEW [dbo].[vmenu]
AS
SELECT [menu].[pId], [menu].[pDescricao], [menu].[pNomeToolStrip], [menu].[oSistema_pId], [menu].[pNivelPosicao], [menu].[xDataHoraReg], [menu].[xLoginReg], [menu].[_trackCreationTime], [menu].[_trackLastWriteTime], [menu].[_trackCreationUser], [menu].[_trackLastWriteUser] 
    FROM [menu]
GO

CREATE VIEW [dbo].[vmenumenuvw]
AS
SELECT [menu].[pId], [menu].[pDescricao], [menu].[pNomeToolStrip], [menu].[pNivelPosicao], [sistema].[pCodigo] AS 'pSistemaCodigo', [sistema].[pNome] AS 'pSistemaNome', [menu].[_trackCreationTime], [menu].[_trackLastWriteTime], [menu].[_trackCreationUser], [menu].[_trackLastWriteUser] 
    FROM [menu]
        LEFT OUTER JOIN [sistema] ON ([menu].[oSistema_pId] = [sistema].[pId])
GO

CREATE VIEW [dbo].[vmenupermissao]
AS
SELECT [menupermissao].[pId], [menupermissao].[oUsuario_pId], [menupermissao].[oSistema_pId], [menupermissao].[pNomeToolStripPerm], [menupermissao].[pFlgPermissao], [menupermissao].[xDataHoraReg], [menupermissao].[xLoginReg], [menupermissao].[_trackCreationTime], [menupermissao].[_trackLastWriteTime], [menupermissao].[_trackCreationUser], [menupermissao].[_trackLastWriteUser] 
    FROM [menupermissao]
GO

CREATE VIEW [dbo].[vMOAGEM_CANA_HORA]
AS
SELECT [MOAGEM_CANA_HORA].[pId], [MOAGEM_CANA_HORA].[ID_NEGOCIOS], [MOAGEM_CANA_HORA].[DIA], [MOAGEM_CANA_HORA].[HORA], [MOAGEM_CANA_HORA].[VIAGEM], [MOAGEM_CANA_HORA].[TONELADAS], [MOAGEM_CANA_HORA].[METAFRENTE], [MOAGEM_CANA_HORA].[_trackCreationTime], [MOAGEM_CANA_HORA].[_trackLastWriteTime], [MOAGEM_CANA_HORA].[_trackCreationUser], [MOAGEM_CANA_HORA].[_trackLastWriteUser] 
    FROM [MOAGEM_CANA_HORA]
GO

CREATE VIEW [dbo].[vpais]
AS
SELECT [pais].[pId], [pais].[pCodigo], [pais].[pNome], [pais].[pSigla], [pais].[pCodigoIbge], [pais].[xDataHoraReg], [pais].[xLoginReg], [pais].[_trackCreationTime], [pais].[_trackLastWriteTime], [pais].[_trackCreationUser], [pais].[_trackLastWriteUser] 
    FROM [pais]
GO

CREATE VIEW [dbo].[vpaispaisviewgrid]
AS
SELECT [pais].[pId], [pais].[pCodigo], [pais].[pCodigoIbge], [pais].[pNome], [pais].[_trackCreationTime], [pais].[_trackLastWriteTime], [pais].[_trackCreationUser], [pais].[_trackLastWriteUser] 
    FROM [pais]
GO

CREATE VIEW [dbo].[vPROPRIEDADES]
AS
SELECT [PROPRIEDADES].[pId], [PROPRIEDADES].[SAFRA], [PROPRIEDADES].[COD_PROPRIEDADE], [PROPRIEDADES].[DSC_PROPRIEDADE], [PROPRIEDADES].[_trackCreationTime], [PROPRIEDADES].[_trackLastWriteTime], [PROPRIEDADES].[_trackCreationUser], [PROPRIEDADES].[_trackLastWriteUser] 
    FROM [PROPRIEDADES]
GO

CREATE VIEW [dbo].[vRES_MENSAL_ACUMULADA]
AS
SELECT [RES_MENSAL_ACUMULADA].[pId], [RES_MENSAL_ACUMULADA].[ID_NEGOCIOS], [RES_MENSAL_ACUMULADA].[NRO_ANO_SAFRA], [RES_MENSAL_ACUMULADA].[MES], [RES_MENSAL_ACUMULADA].[DIA], [RES_MENSAL_ACUMULADA].[TONELADA_PLAN], [RES_MENSAL_ACUMULADA].[TONELADA_PLAN_AC], [RES_MENSAL_ACUMULADA].[TONELADA_REAL], [RES_MENSAL_ACUMULADA].[TONELADA_REAL_AC], [RES_MENSAL_ACUMULADA].[_trackCreationTime], [RES_MENSAL_ACUMULADA].[_trackLastWriteTime], [RES_MENSAL_ACUMULADA].[_trackCreationUser], [RES_MENSAL_ACUMULADA].[_trackLastWriteUser] 
    FROM [RES_MENSAL_ACUMULADA]
GO

CREATE VIEW [dbo].[vRES_MENSAL_DIARIA]
AS
SELECT [RES_MENSAL_DIARIA].[pId], [RES_MENSAL_DIARIA].[ID_NEGOCIOS], [RES_MENSAL_DIARIA].[NRO_ANO_SAFRA], [RES_MENSAL_DIARIA].[MES], [RES_MENSAL_DIARIA].[DIA], [RES_MENSAL_DIARIA].[TONELADA_PLAN], [RES_MENSAL_DIARIA].[TONELADA_REAL], [RES_MENSAL_DIARIA].[_trackCreationTime], [RES_MENSAL_DIARIA].[_trackLastWriteTime], [RES_MENSAL_DIARIA].[_trackCreationUser], [RES_MENSAL_DIARIA].[_trackLastWriteUser] 
    FROM [RES_MENSAL_DIARIA]
GO

CREATE VIEW [dbo].[vRES_MENSAL_GRID]
AS
SELECT [RES_MENSAL_GRID].[pId], [RES_MENSAL_GRID].[ID_NEGOCIOS], [RES_MENSAL_GRID].[NRO_ANO_SAFRA], [RES_MENSAL_GRID].[MES], [RES_MENSAL_GRID].[MES_N], [RES_MENSAL_GRID].[TIPO], [RES_MENSAL_GRID].[TONELADA], [RES_MENSAL_GRID].[_trackCreationTime], [RES_MENSAL_GRID].[_trackLastWriteTime], [RES_MENSAL_GRID].[_trackCreationUser], [RES_MENSAL_GRID].[_trackLastWriteUser] 
    FROM [RES_MENSAL_GRID]
GO

CREATE VIEW [dbo].[vRES_MENSAL_SAFRA]
AS
SELECT [RES_MENSAL_SAFRA].[pId], [RES_MENSAL_SAFRA].[ID_NEGOCIOS], [RES_MENSAL_SAFRA].[NRO_ANO_SAFRA], [RES_MENSAL_SAFRA].[MES], [RES_MENSAL_SAFRA].[DIA], [RES_MENSAL_SAFRA].[TONELADA_PLAN], [RES_MENSAL_SAFRA].[TONELADA_REAL], [RES_MENSAL_SAFRA].[_trackCreationTime], [RES_MENSAL_SAFRA].[_trackLastWriteTime], [RES_MENSAL_SAFRA].[_trackCreationUser], [RES_MENSAL_SAFRA].[_trackLastWriteUser] 
    FROM [RES_MENSAL_SAFRA]
GO

CREATE VIEW [dbo].[vRES_MENSAL_SAFRA_ACUMULADA]
AS
SELECT [RES_MENSAL_SAFRA_ACUMULADA].[pId], [RES_MENSAL_SAFRA_ACUMULADA].[ID_NEGOCIOS], [RES_MENSAL_SAFRA_ACUMULADA].[NRO_ANO_SAFRA], [RES_MENSAL_SAFRA_ACUMULADA].[MES], [RES_MENSAL_SAFRA_ACUMULADA].[DIA], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_PLAN_AC], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL], [RES_MENSAL_SAFRA_ACUMULADA].[TONELADA_REAL_AC], [RES_MENSAL_SAFRA_ACUMULADA].[_trackCreationTime], [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteTime], [RES_MENSAL_SAFRA_ACUMULADA].[_trackCreationUser], [RES_MENSAL_SAFRA_ACUMULADA].[_trackLastWriteUser] 
    FROM [RES_MENSAL_SAFRA_ACUMULADA]
GO

CREATE VIEW [dbo].[vSAFRA_ANO]
AS
SELECT [SAFRA_ANO].[pId], [SAFRA_ANO].[SAFRA], [SAFRA_ANO].[_trackCreationTime], [SAFRA_ANO].[_trackLastWriteTime], [SAFRA_ANO].[_trackCreationUser], [SAFRA_ANO].[_trackLastWriteUser] 
    FROM [SAFRA_ANO]
GO

CREATE VIEW [dbo].[vSEQUENCIA_COLHEITA]
AS
SELECT [SEQUENCIA_COLHEITA].[pId], [SEQUENCIA_COLHEITA].[FRENTE_COLHEITA], [SEQUENCIA_COLHEITA].[PROP_CODIGO], [SEQUENCIA_COLHEITA].[DS_NOME_PROPRIEDADE], [SEQUENCIA_COLHEITA].[COORD_LAT], [SEQUENCIA_COLHEITA].[COORD_LONG], [SEQUENCIA_COLHEITA].[ORDEM], [SEQUENCIA_COLHEITA].[_trackCreationTime], [SEQUENCIA_COLHEITA].[_trackLastWriteTime], [SEQUENCIA_COLHEITA].[_trackCreationUser], [SEQUENCIA_COLHEITA].[_trackLastWriteUser] 
    FROM [SEQUENCIA_COLHEITA]
GO

CREATE VIEW [dbo].[vsistema]
AS
SELECT [sistema].[pId], [sistema].[pNome], [sistema].[pCodigo], [sistema].[xDataHoraReg], [sistema].[xLoginReg], [sistema].[_trackCreationTime], [sistema].[_trackLastWriteTime], [sistema].[_trackCreationUser], [sistema].[_trackLastWriteUser] 
    FROM [sistema]
GO

CREATE VIEW [dbo].[vuf]
AS
SELECT [uf].[pId], [uf].[pCodigo], [uf].[pDescricao], [uf].[pSigla], [uf].[pCodigoIbge], [uf].[xDataHoraReg], [uf].[xLoginReg], [uf].[oPais_pId], [uf].[_trackCreationTime], [uf].[_trackLastWriteTime], [uf].[_trackCreationUser], [uf].[_trackLastWriteUser] 
    FROM [uf]
GO

CREATE VIEW [dbo].[vufufviewgrid]
AS
SELECT [uf].[pId], [uf].[pCodigo], [uf].[pDescricao], [uf].[pSigla], [uf].[_trackCreationTime], [uf].[_trackLastWriteTime], [uf].[_trackCreationUser], [uf].[_trackLastWriteUser] 
    FROM [uf]
GO

CREATE VIEW [dbo].[vusuario]
AS
SELECT [usuario].[pId], [usuario].[pCodigo], [usuario].[pLogin], [usuario].[pSenha], [usuario].[pFlgAdmin], [usuario].[sStatus], [usuario].[xDataHoraReg], [usuario].[xLoginReg], [usuario].[oCadastro_pId], [usuario].[oIdUser_Id], [usuario].[_trackCreationTime], [usuario].[_trackLastWriteTime], [usuario].[_trackCreationUser], [usuario].[_trackLastWriteUser] 
    FROM [usuario]
GO

CREATE VIEW [dbo].[vV_DADOS_TALHAO]
AS
SELECT [V_DADOS_TALHAO].[pId], [V_DADOS_TALHAO].[ID_NEGOCIOS], [V_DADOS_TALHAO].[SAFRA], [V_DADOS_TALHAO].[COD_PROPRIEDADE], [V_DADOS_TALHAO].[DSC_PROPRIEDADE], [V_DADOS_TALHAO].[TALHAO], [V_DADOS_TALHAO].[CORTE], [V_DADOS_TALHAO].[AMBIENTE], [V_DADOS_TALHAO].[VARIEDADE], [V_DADOS_TALHAO].[MATURACAO], [V_DADOS_TALHAO].[AREA_TOTAL], [V_DADOS_TALHAO].[_trackCreationTime], [V_DADOS_TALHAO].[_trackLastWriteTime], [V_DADOS_TALHAO].[_trackCreationUser], [V_DADOS_TALHAO].[_trackLastWriteUser] 
    FROM [V_DADOS_TALHAO]
GO

CREATE VIEW [dbo].[vWebSiteMap]
AS
SELECT [WebSiteMap].[pId], [WebSiteMap].[pRelPath], [WebSiteMap].[pNode], [WebSiteMap].[pDescription], [WebSiteMap].[_trackCreationTime], [WebSiteMap].[_trackLastWriteTime], [WebSiteMap].[_trackCreationUser], [WebSiteMap].[_trackLastWriteUser] 
    FROM [WebSiteMap]
GO

