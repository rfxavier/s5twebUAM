/* CodeFluent Generated . TargetVersion:Sql2014. Culture:pt-BR. UiCulture:pt-BR. Encoding:utf-8 (http://www.softfluent.com) */
set quoted_identifier OFF
GO
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ACOMP_PROD_1CORTE]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_1CORTE_TALHAO]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ACOMP_PROD_1CORTE_TALHAO]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ACOMP_PROD_DCORTE]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMP_PROD_DCORTE_TALHAO]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ACOMP_PROD_DCORTE_TALHAO]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ACOMPANHAMENTO_PLANTIO]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ACOMPANHAMENTO_PLANTIO]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[appconfig]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[appconfig]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[apprelatorio]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[cadastro]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastrotipo]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[cadastrotipo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[CERTIFICADO_PATIO_HORA]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[CERTIFICADO_PATIO_HORA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cidade]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[cidade]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[empresa]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_CAMINHAOVIAGENS]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_FRENTESPROP]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ENT_CAMBAL_FRENTESPROP]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENT_CAMBAL_PRINCIPAL]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ENT_CAMBAL_PRINCIPAL]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ENTRADA_CANA_DET]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_AGRUP]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ENTRADA_CANA_DET_AGRUP]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_DET_MP]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ENTRADA_CANA_DET_MP]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ENTRADA_CANA_HORA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ENTRADA_CANA_HORA_FRENTE]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ENTRADA_CANA_HORA_FRENTE]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[ESCALA_COLAB]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[ESCALA_COLAB]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[filial]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filialconfig]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[filialconfig]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[HISTORICO_PROPRIEDADE]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_TRATOS]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[HISTORICO_PROPRIEDADE_TRATOS]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRole]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[IdRole]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRoleClaim]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[IdRoleClaim]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUser]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[IdUser]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserClaim]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[IdUserClaim]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdUserLogin]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[IdUserLogin]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[INDICADORES_AGRICOLA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_EQUIP]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[INDICADORES_AGRICOLA_EQUIP]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INDICADORES_AGRICOLA_TEMPOAPROV]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[INFO_GERAIS]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[INFO_GERAIS]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[loginregistro]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[loginregistro]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MAPA_PLANCOLHEITA]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[MAPA_PLANCOLHEITA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menu]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[menu]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[menupermissao]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[menupermissao]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[MOAGEM_CANA_HORA]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[MOAGEM_CANA_HORA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[pais]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[pais]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PROPRIEDADES]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[PROPRIEDADES]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_ACUMULADA]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[RES_MENSAL_ACUMULADA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_DIARIA]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[RES_MENSAL_DIARIA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_GRID]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[RES_MENSAL_GRID]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[RES_MENSAL_SAFRA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[RES_MENSAL_SAFRA_ACUMULADA]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[RES_MENSAL_SAFRA_ACUMULADA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SAFRA_ANO]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[SAFRA_ANO]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[SEQUENCIA_COLHEITA]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[SEQUENCIA_COLHEITA]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[sistema]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[sistema]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[uf]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[uf]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[usuario]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[usuario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[V_DADOS_TALHAO]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[V_DADOS_TALHAO]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[WebSiteMap]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[WebSiteMap]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_oempresas_empresa_ocadastros]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[cadastro_oempresas_empresa_ocadastros]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[empresa_osistemas_sistema_oempresas]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[empresa_osistemas_sistema_oempresas]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[filial_ousuarios_usuario_ofiliais]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[filial_ousuarios_usuario_ofiliais]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[IdRole_Users_IdUser_Roles]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[IdRole_Users_IdUser_Roles]
GO

/* no fk for 'PK_ACO_pId_ACO', tableName='ACOMP_PROD_1CORTE' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ACO_pId_ACO]') AND parent_obj = object_id(N'[dbo].[ACOMP_PROD_1CORTE]'))
 ALTER TABLE [dbo].[ACOMP_PROD_1CORTE] DROP CONSTRAINT [PK_ACO_pId_ACO]
GO
CREATE TABLE [dbo].[ACOMP_PROD_1CORTE] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ROWNUM] [int] NULL,
 [PROP_CODIGO] [int] NULL,
 [DS_NOME_PROPRIEDADE] [nvarchar] (256) NULL,
 [NRO_CORTE] [int] NULL,
 [QT_AREA_COLHIDA] [float] NULL,
 [IDADE] [int] NULL,
 [TIPO_PROPRIEDADE] [nvarchar] (256) NULL,
 [QT_TON_ENTREGUE] [float] NULL,
 [RENDIMENTO_PLAN] [int] NULL,
 [RENDIMENTO_REAL] [int] NULL,
 [DESVIO] [int] NULL,
 [PORC_BROCA] [float] NULL,
 [PERDAS] [float] NULL,
 [INCENDIO] [nvarchar] (256) NULL,
 [DATA_INCENDIO] [date] NULL,
 [DT_DESSECACAO] [date] NULL,
 [DT_CALAGEM] [date] NULL,
 [DT_PLANTIO] [date] NULL,
 [TIPO_PLANTIO] [nvarchar] (256) NULL,
 [EMPRESA_PLANTIO] [nvarchar] (256) NULL,
 [STAND] [int] NULL,
 [TIPO_ADUBACAO] [nvarchar] (256) NULL,
 [TRAT_TOLETES] [nvarchar] (256) NULL,
 [DT_HERB_CANA_PLANTA] [date] NULL,
 [SEMANA_ENCERRAMENTO] [nvarchar] (256) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ACO__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ACO__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ACO_pId_ACO] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ACM_pId_ACM', tableName='ACOMP_PROD_1CORTE_TALHAO' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ACM_pId_ACM]') AND parent_obj = object_id(N'[dbo].[ACOMP_PROD_1CORTE_TALHAO]'))
 ALTER TABLE [dbo].[ACOMP_PROD_1CORTE_TALHAO] DROP CONSTRAINT [PK_ACM_pId_ACM]
GO
CREATE TABLE [dbo].[ACOMP_PROD_1CORTE_TALHAO] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ROWNUM] [int] NULL,
 [PROP_CODIGO] [int] NULL,
 [DS_NOME_PROPRIEDADE] [nvarchar] (256) NULL,
 [TALHAO] [int] NULL,
 [NRO_CORTE] [int] NULL,
 [QT_AREA_COLHIDA] [float] NULL,
 [IDADE] [int] NULL,
 [TIPO_PROPRIEDADE] [nvarchar] (256) NULL,
 [QT_TON_ENTREGUE] [float] NULL,
 [RENDIMENTO_PLAN] [int] NULL,
 [RENDIMENTO_REAL] [int] NULL,
 [DESVIO] [int] NULL,
 [PORC_BROCA] [float] NULL,
 [PERDAS] [float] NULL,
 [INCENDIO] [nvarchar] (256) NULL,
 [DATA_INCENDIO] [date] NULL,
 [DT_DESSECACAO] [date] NULL,
 [DT_CALAGEM] [date] NULL,
 [DT_PLANTIO] [date] NULL,
 [TIPO_PLANTIO] [nvarchar] (256) NULL,
 [EMPRESA_PLANTIO] [nvarchar] (256) NULL,
 [STAND] [int] NULL,
 [TIPO_ADUBACAO] [nvarchar] (256) NULL,
 [TRAT_TOLETES] [nvarchar] (256) NULL,
 [DT_HERB_CANA_PLANTA] [date] NULL,
 [SEMANA_ENCERRAMENTO] [nvarchar] (256) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ACM__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ACM__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ACM_pId_ACM] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ACP_pId_ACP', tableName='ACOMP_PROD_DCORTE' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ACP_pId_ACP]') AND parent_obj = object_id(N'[dbo].[ACOMP_PROD_DCORTE]'))
 ALTER TABLE [dbo].[ACOMP_PROD_DCORTE] DROP CONSTRAINT [PK_ACP_pId_ACP]
GO
CREATE TABLE [dbo].[ACOMP_PROD_DCORTE] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ROWNUM] [int] NULL,
 [PROP_CODIGO] [int] NULL,
 [DS_NOME_PROPRIEDADE] [nvarchar] (256) NULL,
 [NRO_CORTE] [int] NULL,
 [QT_AREA_COLHIDA] [float] NULL,
 [IDADE] [int] NULL,
 [TIPO_PROPRIEDADE] [nvarchar] (256) NULL,
 [QT_TON_ENTREGUE] [float] NULL,
 [RENDIMENTO_PLAN] [int] NULL,
 [RENDIMENTO_REAL] [int] NULL,
 [DESVIO] [int] NULL,
 [PORC_BROCA] [float] NULL,
 [PERDAS] [float] NULL,
 [DT_COLHEITA_ANTERIOR] [date] NULL,
 [TIPO_ADUBACAO] [nvarchar] (256) NULL,
 [DT_ADUBACAO] [date] NULL,
 [DIF_DIAS_ADUB] [int] NULL,
 [TIPO_HERBICIDA] [nvarchar] (256) NULL,
 [DT_HERBICIDA] [date] NULL,
 [DIF_DIAS_HERB] [int] NULL,
 [INCENDIO] [nvarchar] (256) NULL,
 [DATA_INCENDIO] [date] NULL,
 [FERTIRRIGACAO] [nvarchar] (256) NULL,
 [DT_FERTIRRIGACAO] [date] NULL,
 [SEMANA_ENCERRAMENTO] [nvarchar] (256) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ACP__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ACP__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ACP_pId_ACP] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_AC__pId_AC_', tableName='ACOMP_PROD_DCORTE_TALHAO' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_AC__pId_AC_]') AND parent_obj = object_id(N'[dbo].[ACOMP_PROD_DCORTE_TALHAO]'))
 ALTER TABLE [dbo].[ACOMP_PROD_DCORTE_TALHAO] DROP CONSTRAINT [PK_AC__pId_AC_]
GO
CREATE TABLE [dbo].[ACOMP_PROD_DCORTE_TALHAO] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ROWNUM] [int] NULL,
 [PROP_CODIGO] [int] NULL,
 [DS_NOME_PROPRIEDADE] [nvarchar] (256) NULL,
 [TALHAO] [int] NULL,
 [NRO_CORTE] [int] NULL,
 [QT_AREA_COLHIDA] [float] NULL,
 [IDADE] [int] NULL,
 [TIPO_PROPRIEDADE] [nvarchar] (256) NULL,
 [DT_COLHEITA_ATUAL] [date] NULL,
 [QT_TON_ENTREGUE] [float] NULL,
 [RENDIMENTO_PLAN] [int] NULL,
 [RENDIMENTO_REAL] [int] NULL,
 [DESVIO] [int] NULL,
 [PORC_BROCA] [float] NULL,
 [PERDAS] [float] NULL,
 [DT_COLHEITA_ANTERIOR] [date] NULL,
 [TIPO_ADUBACAO] [nvarchar] (256) NULL,
 [DT_ADUBACAO] [date] NULL,
 [DIF_DIAS_ADUB] [int] NULL,
 [TIPO_HERBICIDA] [nvarchar] (256) NULL,
 [DT_HERBICIDA] [date] NULL,
 [DIF_DIAS_HERB] [int] NULL,
 [INCENDIO] [nvarchar] (256) NULL,
 [DATA_INCENDIO] [date] NULL,
 [FERTIRRIGACAO] [nvarchar] (256) NULL,
 [DT_FERTIRRIGACAO] [date] NULL,
 [SEMANA_ENCERRAMENTO] [nvarchar] (256) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_AC___tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_AC___tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_AC__pId_AC_] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ACA_pId_ACA', tableName='ACOMPANHAMENTO_PLANTIO' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ACA_pId_ACA]') AND parent_obj = object_id(N'[dbo].[ACOMPANHAMENTO_PLANTIO]'))
 ALTER TABLE [dbo].[ACOMPANHAMENTO_PLANTIO] DROP CONSTRAINT [PK_ACA_pId_ACA]
GO
CREATE TABLE [dbo].[ACOMPANHAMENTO_PLANTIO] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [COD_PROPRIEDADE] [int] NULL,
 [SAFRA] [int] NULL,
 [DT_PLANTIO] [date] NULL,
 [AREA_PLANTIO] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ACA__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ACA__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ACA_pId_ACA] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_app_pId_app', tableName='appconfig' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_app_pId_app]') AND parent_obj = object_id(N'[dbo].[appconfig]'))
 ALTER TABLE [dbo].[appconfig] DROP CONSTRAINT [PK_app_pId_app]
GO
CREATE TABLE [dbo].[appconfig] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_app__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_app__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_app_pId_app] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_apr_pId_apr', tableName='apprelatorio' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_apr_pId_apr]') AND parent_obj = object_id(N'[dbo].[apprelatorio]'))
 ALTER TABLE [dbo].[apprelatorio] DROP CONSTRAINT [PK_apr_pId_apr]
GO
CREATE TABLE [dbo].[apprelatorio] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pNomeFormArgumento] [nvarchar] (256) NULL,
 [pNomeRelatorio] [nvarchar] (20) NOT NULL,
 [pNomeRdlc] [nvarchar] (256) NULL,
 [pNomeDataSet] [nvarchar] (256) NULL,
 [sCategoria] [int] NULL,
 [pTituloRelatorio] [nvarchar] (256) NULL,
 [pSequencia] [int] NULL,
 [pCategoriaRelatorio] [nvarchar] (256) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_apr__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_apr__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_apr_pId_apr] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY],
 CONSTRAINT [IX_apr_pNm_apr] UNIQUE
 (

  [pNomeRelatorio] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_cad_pId_cad', tableName='cadastro' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_cad_pId_cad]') AND parent_obj = object_id(N'[dbo].[cadastro]'))
 ALTER TABLE [dbo].[cadastro] DROP CONSTRAINT [PK_cad_pId_cad]
GO
CREATE TABLE [dbo].[cadastro] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pNome] [nvarchar] (256) NULL,
 [pCodigo] [int] NOT NULL,
 [pPFPJ] [nvarchar] (1) NULL,
 [pEndereco] [nvarchar] (256) NULL,
 [oCidade_pId] [bigint] NULL,
 [pEnderLogradouro] [nvarchar] (256) NULL,
 [pEnderComplemento] [nvarchar] (256) NULL,
 [pEnderBairro] [nvarchar] (256) NULL,
 [pEnderNumero] [nvarchar] (256) NULL,
 [pEnderAuxLogradouro] [nvarchar] (256) NULL,
 [pEnderAuxNumero] [nvarchar] (256) NULL,
 [pEnderAuxBairro] [nvarchar] (256) NULL,
 [pEnderAuxComplemento] [nvarchar] (256) NULL,
 [pEnderecoAux] [nvarchar] (256) NULL,
 [pEmail] [nvarchar] (256) NULL,
 [oCidadeAux_pId] [bigint] NULL,
 [pCpfCnpj] [nvarchar] (20) NULL,
 [pDataNascimento] [date] NULL,
 [pRgIe] [nvarchar] (256) NULL,
 [pNomeFantasia] [nvarchar] (256) NULL,
 [pFlgSexo] [nvarchar] (256) NULL,
 [pDataCadastro] [date] NULL,
 [pDataBaixa] [date] NULL,
 [pTelefone] [nvarchar] (256) NULL,
 [pTelefoneAux] [nvarchar] (256) NULL,
 [pCelular] [nvarchar] (256) NULL,
 [pFax] [nvarchar] (256) NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [oUsuario_pId] [bigint] NULL,
 [pCep] [nvarchar] (256) NULL,
 [pCepAux] [nvarchar] (256) NULL,
 [pFlgPreCadastro] [nvarchar] (1) NULL,
 [oCadastroFilial_pId] [bigint] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_cad__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_cad__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_cad_pId_cad] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY],
 CONSTRAINT [IX_cad_pCo_cad] UNIQUE
 (

  [pCodigo] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_caa_pId_caa', tableName='cadastrotipo' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_caa_pId_caa]') AND parent_obj = object_id(N'[dbo].[cadastrotipo]'))
 ALTER TABLE [dbo].[cadastrotipo] DROP CONSTRAINT [PK_caa_pId_caa]
GO
CREATE TABLE [dbo].[cadastrotipo] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pDescricao] [nvarchar] (256) NULL,
 [pFlgCadastro] [nvarchar] (256) NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_caa__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_caa__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_caa_pId_caa] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_CER_pId_CER', tableName='CERTIFICADO_PATIO_HORA' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_CER_pId_CER]') AND parent_obj = object_id(N'[dbo].[CERTIFICADO_PATIO_HORA]'))
 ALTER TABLE [dbo].[CERTIFICADO_PATIO_HORA] DROP CONSTRAINT [PK_CER_pId_CER]
GO
CREATE TABLE [dbo].[CERTIFICADO_PATIO_HORA] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [DIA] [date] NULL,
 [HORA] [nvarchar] (256) NULL,
 [FRENTE] [int] NULL,
 [CERTIFICADOS] [int] NULL,
 [CERT_VAZIO] [int] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_CER__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_CER__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_CER_pId_CER] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_cid_pId_cid', tableName='cidade' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_cid_pId_cid]') AND parent_obj = object_id(N'[dbo].[cidade]'))
 ALTER TABLE [dbo].[cidade] DROP CONSTRAINT [PK_cid_pId_cid]
GO
CREATE TABLE [dbo].[cidade] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pNome] [nvarchar] (256) NULL,
 [pCodigo] [int] NOT NULL,
 [pCodigoIbge] [int] NULL,
 [oUF_pId] [bigint] NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_cid__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_cid__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_cid_pId_cid] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY],
 CONSTRAINT [IX_cid_pCo_cid] UNIQUE
 (

  [pCodigo] ) ON [PRIMARY],
 CONSTRAINT [IX_cid_pCd_cid] UNIQUE
 (

  [pCodigoIbge] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_emp_pId_emp', tableName='empresa' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_emp_pId_emp]') AND parent_obj = object_id(N'[dbo].[empresa]'))
 ALTER TABLE [dbo].[empresa] DROP CONSTRAINT [PK_emp_pId_emp]
GO
CREATE TABLE [dbo].[empresa] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pCodigo] [int] NOT NULL,
 [pNome] [nvarchar] (256) NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [pSimplesNacionalValorAliquotaCreditoICMS] [float] NULL,
 [sSimplesNacionalCategoria] [int] NULL,
 [sCodigoRegimeTributario] [int] NULL,
 [sCodigoRegimeTributarioNormal] [int] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_emp__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_emp__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_emp_pId_emp] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY],
 CONSTRAINT [IX_emp_pCo_emp] UNIQUE
 (

  [pCodigo] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ENT_pId_ENT', tableName='ENT_CAMBAL_CAMINHAOVIAGENS' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ENT_pId_ENT]') AND parent_obj = object_id(N'[dbo].[ENT_CAMBAL_CAMINHAOVIAGENS]'))
 ALTER TABLE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS] DROP CONSTRAINT [PK_ENT_pId_ENT]
GO
CREATE TABLE [dbo].[ENT_CAMBAL_CAMINHAOVIAGENS] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ROWNUM] [int] NULL,
 [FRENTE] [int] NULL,
 [COD_PROP] [int] NULL,
 [CAMINHAO] [int] NULL,
 [QTD_VIAGENS] [int] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ENT__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ENT__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ENT_pId_ENT] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_EN__pId_EN_', tableName='ENT_CAMBAL_FRENTESPROP' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_EN__pId_EN_]') AND parent_obj = object_id(N'[dbo].[ENT_CAMBAL_FRENTESPROP]'))
 ALTER TABLE [dbo].[ENT_CAMBAL_FRENTESPROP] DROP CONSTRAINT [PK_EN__pId_EN_]
GO
CREATE TABLE [dbo].[ENT_CAMBAL_FRENTESPROP] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ROWNUM] [int] NULL,
 [FRENTE] [int] NULL,
 [COD_PROP] [int] NULL,
 [PROPRIEDADE] [nvarchar] (256) NULL,
 [QTD_VIAGENS] [int] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_EN___tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_EN___tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_EN__pId_EN_] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ENC_pId_ENC', tableName='ENT_CAMBAL_PRINCIPAL' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ENC_pId_ENC]') AND parent_obj = object_id(N'[dbo].[ENT_CAMBAL_PRINCIPAL]'))
 ALTER TABLE [dbo].[ENT_CAMBAL_PRINCIPAL] DROP CONSTRAINT [PK_ENC_pId_ENC]
GO
CREATE TABLE [dbo].[ENT_CAMBAL_PRINCIPAL] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [HORA] [int] NULL,
 [F1] [int] NULL,
 [F2] [int] NULL,
 [F3] [int] NULL,
 [F4] [int] NULL,
 [F5] [int] NULL,
 [F6] [int] NULL,
 [F7] [int] NULL,
 [F8] [int] NULL,
 [F9] [int] NULL,
 [F10] [int] NULL,
 [TOTAL] [int] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ENC__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ENC__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ENC_pId_ENC] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ENR_pId_ENR', tableName='ENTRADA_CANA_DET' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ENR_pId_ENR]') AND parent_obj = object_id(N'[dbo].[ENTRADA_CANA_DET]'))
 ALTER TABLE [dbo].[ENTRADA_CANA_DET] DROP CONSTRAINT [PK_ENR_pId_ENR]
GO
CREATE TABLE [dbo].[ENTRADA_CANA_DET] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [NR_ANO_SAFRA] [int] NULL,
 [NRO_DOCUMENTO] [int] NULL,
 [PROP_CODIGO] [int] NULL,
 [DS_NOME_PROPRIEDADE] [nvarchar] (256) NULL,
 [DSC_VARIEDADE] [nvarchar] (256) NULL,
 [NRO_CORTE] [int] NULL,
 [FRENTE_COLHEITA] [nvarchar] (256) NULL,
 [MUNICIPIO] [int] NULL,
 [DESCMUNI] [nvarchar] (256) NULL,
 [TIPO] [int] NULL,
 [DESCTIPO] [nvarchar] (256) NULL,
 [DT_ENTRADA] [date] NULL,
 [EQUIP_ENTRADA] [int] NULL,
 [REBOQUE] [int] NULL,
 [DT_MOAGEM] [date] NULL,
 [AREA_COLHIDA] [float] NULL,
 [QT_TON_ENTREGUE_PREV] [float] NULL,
 [QT_TON_ENTREGUE_REAL] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ENR__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ENR__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ENR_pId_ENR] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ENA_pId_ENA', tableName='ENTRADA_CANA_DET_AGRUP' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ENA_pId_ENA]') AND parent_obj = object_id(N'[dbo].[ENTRADA_CANA_DET_AGRUP]'))
 ALTER TABLE [dbo].[ENTRADA_CANA_DET_AGRUP] DROP CONSTRAINT [PK_ENA_pId_ENA]
GO
CREATE TABLE [dbo].[ENTRADA_CANA_DET_AGRUP] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [NR_ANO_SAFRA] [int] NULL,
 [NRO_DOCUMENTO] [int] NULL,
 [PROP_CODIGO] [int] NULL,
 [DS_NOME_PROPRIEDADE] [nvarchar] (256) NULL,
 [FRENTE_COLHEITA] [nvarchar] (256) NULL,
 [MUNICIPIO] [int] NULL,
 [DESCMUNI] [nvarchar] (256) NULL,
 [TIPO] [int] NULL,
 [DESCTIPO] [nvarchar] (256) NULL,
 [DT_ENTRADA] [date] NULL,
 [DT_MOAGEM] [date] NULL,
 [AREA_COLHIDA] [float] NULL,
 [QT_TON_ENTREGUE_REAL] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ENA__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ENA__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ENA_pId_ENA] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_END_pId_END', tableName='ENTRADA_CANA_DET_MP' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_END_pId_END]') AND parent_obj = object_id(N'[dbo].[ENTRADA_CANA_DET_MP]'))
 ALTER TABLE [dbo].[ENTRADA_CANA_DET_MP] DROP CONSTRAINT [PK_END_pId_END]
GO
CREATE TABLE [dbo].[ENTRADA_CANA_DET_MP] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [NR_ANO_SAFRA] [int] NULL,
 [PROP_CODIGO] [int] NULL,
 [DS_NOME_PROPRIEDADE] [nvarchar] (256) NULL,
 [FRENTE_COLHEITATOP] [nvarchar] (256) NULL,
 [FRENTE_COLHEITA] [nvarchar] (256) NULL,
 [MUNICIPIO] [int] NULL,
 [DESCMUNI] [nvarchar] (256) NULL,
 [QT_TON_ENTREGUE_REAL] [float] NULL,
 [INICIO] [date] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_END__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_END__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_END_pId_END] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ENN_pId_ENN', tableName='ENTRADA_CANA_HORA' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ENN_pId_ENN]') AND parent_obj = object_id(N'[dbo].[ENTRADA_CANA_HORA]'))
 ALTER TABLE [dbo].[ENTRADA_CANA_HORA] DROP CONSTRAINT [PK_ENN_pId_ENN]
GO
CREATE TABLE [dbo].[ENTRADA_CANA_HORA] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [DIA] [date] NULL,
 [HORA] [nvarchar] (256) NULL,
 [TONELADAS] [float] NULL,
 [VIAGEM] [int] NULL,
 [TON_VIAGEM] [float] NULL,
 [METAFRENTE] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ENN__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ENN__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ENN_pId_ENN] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ENH_pId_ENH', tableName='ENTRADA_CANA_HORA_FRENTE' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ENH_pId_ENH]') AND parent_obj = object_id(N'[dbo].[ENTRADA_CANA_HORA_FRENTE]'))
 ALTER TABLE [dbo].[ENTRADA_CANA_HORA_FRENTE] DROP CONSTRAINT [PK_ENH_pId_ENH]
GO
CREATE TABLE [dbo].[ENTRADA_CANA_HORA_FRENTE] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [DIA] [date] NULL,
 [HORA] [nvarchar] (256) NULL,
 [FRENTE] [int] NULL,
 [TONELADAS] [float] NULL,
 [VIAGEM] [int] NULL,
 [TON_VIAGEM] [float] NULL,
 [METAFRENTE] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ENH__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ENH__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ENH_pId_ENH] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ESC_pId_ESC', tableName='ESCALA_COLAB' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ESC_pId_ESC]') AND parent_obj = object_id(N'[dbo].[ESCALA_COLAB]'))
 ALTER TABLE [dbo].[ESCALA_COLAB] DROP CONSTRAINT [PK_ESC_pId_ESC]
GO
CREATE TABLE [dbo].[ESCALA_COLAB] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ROWNUM] [int] NULL,
 [PROCESSO] [nvarchar] (256) NULL,
 [ESTRUTURA] [nvarchar] (256) NULL,
 [MATRICULA] [int] NULL,
 [NOME] [nvarchar] (256) NULL,
 [TURNO] [nvarchar] (256) NULL,
 [DIA01] [nvarchar] (256) NULL,
 [DIA02] [nvarchar] (256) NULL,
 [DIA03] [nvarchar] (256) NULL,
 [DIA04] [nvarchar] (256) NULL,
 [DIA05] [nvarchar] (256) NULL,
 [DIA06] [nvarchar] (256) NULL,
 [DIA07] [nvarchar] (256) NULL,
 [DIA08] [nvarchar] (256) NULL,
 [DIA09] [nvarchar] (256) NULL,
 [DIA10] [nvarchar] (256) NULL,
 [DIA11] [nvarchar] (256) NULL,
 [DIA12] [nvarchar] (256) NULL,
 [DIA13] [nvarchar] (256) NULL,
 [DIA14] [nvarchar] (256) NULL,
 [DIA15] [nvarchar] (256) NULL,
 [DIA16] [nvarchar] (256) NULL,
 [DIA17] [nvarchar] (256) NULL,
 [DIA18] [nvarchar] (256) NULL,
 [DIA19] [nvarchar] (256) NULL,
 [DIA20] [nvarchar] (256) NULL,
 [DIA21] [nvarchar] (256) NULL,
 [DIA22] [nvarchar] (256) NULL,
 [DIA23] [nvarchar] (256) NULL,
 [DIA24] [nvarchar] (256) NULL,
 [DIA25] [nvarchar] (256) NULL,
 [DIA26] [nvarchar] (256) NULL,
 [DIA27] [nvarchar] (256) NULL,
 [DIA28] [nvarchar] (256) NULL,
 [DIA29] [nvarchar] (256) NULL,
 [DIA30] [nvarchar] (256) NULL,
 [CELULAR] [nvarchar] (256) NULL,
 [ID_NIVEL] [int] NULL,
 [ID_TURMAS] [int] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_ESC__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_ESC__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_ESC_pId_ESC] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_fil_pId_fil', tableName='filial' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_fil_pId_fil]') AND parent_obj = object_id(N'[dbo].[filial]'))
 ALTER TABLE [dbo].[filial] DROP CONSTRAINT [PK_fil_pId_fil]
GO
CREATE TABLE [dbo].[filial] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pCodigo] [int] NULL,
 [pNome] [nvarchar] (256) NULL,
 [sTipo] [int] NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [oEmpresa_pId] [bigint] NULL,
 [oCadastro_pId] [bigint] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_fil__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_fil__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_fil_pId_fil] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_fii_pId_fii', tableName='filialconfig' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_fii_pId_fii]') AND parent_obj = object_id(N'[dbo].[filialconfig]'))
 ALTER TABLE [dbo].[filialconfig] DROP CONSTRAINT [PK_fii_pId_fii]
GO
CREATE TABLE [dbo].[filialconfig] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [sTipo] [int] NULL,
 [pConteudo] [nvarchar] (256) NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [oFilial_pId] [bigint] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_fii__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_fii__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_fii_pId_fii] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_HIS_pId_HIS', tableName='HISTORICO_PROPRIEDADE' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_HIS_pId_HIS]') AND parent_obj = object_id(N'[dbo].[HISTORICO_PROPRIEDADE]'))
 ALTER TABLE [dbo].[HISTORICO_PROPRIEDADE] DROP CONSTRAINT [PK_HIS_pId_HIS]
GO
CREATE TABLE [dbo].[HISTORICO_PROPRIEDADE] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [SAFRA] [int] NULL,
 [COD_PROPRIEDADE] [int] NULL,
 [DSC_PROPRIEDADE] [nvarchar] (256) NULL,
 [TALHAO] [int] NULL,
 [RENDIMENTO_PLAN] [float] NULL,
 [CORTE] [int] NULL,
 [AMBIENTE] [nvarchar] (256) NULL,
 [DT_PLANTIO] [date] NULL,
 [DT_COLHEITA_ANT] [date] NULL,
 [DT_COLHEITA_ATU] [date] NULL,
 [AREA_TOTAL] [float] NULL,
 [AREA_LIBERADA] [float] NULL,
 [TONELADA] [float] NULL,
 [RENDIMENTO_REAL] [float] NULL,
 [TCH] [float] NULL,
 [IDADE] [float] NULL,
 [PERC_BROCA] [float] NULL,
 [PERC_PERDA] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_HIS__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_HIS__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_HIS_pId_HIS] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_HIT_pId_HIT', tableName='HISTORICO_PROPRIEDADE_TRATOS' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_HIT_pId_HIT]') AND parent_obj = object_id(N'[dbo].[HISTORICO_PROPRIEDADE_TRATOS]'))
 ALTER TABLE [dbo].[HISTORICO_PROPRIEDADE_TRATOS] DROP CONSTRAINT [PK_HIT_pId_HIT]
GO
CREATE TABLE [dbo].[HISTORICO_PROPRIEDADE_TRATOS] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [SAFRA] [int] NULL,
 [COD_PROPRIEDADE] [int] NULL,
 [DSC_PROPRIEDADE] [nvarchar] (256) NULL,
 [TALHAO] [int] NULL,
 [CORTE] [int] NULL,
 [AMBIENTE] [nvarchar] (256) NULL,
 [AREA_TALHAO] [float] NULL,
 [AREA_TALHAO_DIS] [float] NULL,
 [AREA_TALHAO_MUDA] [float] NULL,
 [COLHEITA_ANT] [date] NULL,
 [COLHEITA_ATU] [date] NULL,
 [ATIVIDADE] [int] NULL,
 [DSC_ATIVIDADE] [nvarchar] (256) NULL,
 [NRO_RECOM] [int] NULL,
 [DATA_APLICACAO] [date] NULL,
 [AREA_APLICADA] [float] NULL,
 [TOTAL_TALHAO_DISP] [int] NULL,
 [AREA_TOT_TH_DISP] [float] NULL,
 [AREA_TOT_TH_MUDA] [float] NULL,
 [GRUPO_SUBGRUPO_AGR] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_HIT__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_HIT__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_HIT_pId_HIT] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_IdR_Id_IdR', tableName='IdRole' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_IdR_Id_IdR]') AND parent_obj = object_id(N'[dbo].[IdRole]'))
 ALTER TABLE [dbo].[IdRole] DROP CONSTRAINT [PK_IdR_Id_IdR]
GO
CREATE TABLE [dbo].[IdRole] (
 [Id] [bigint] IDENTITY (1, 1) NOT NULL,
 [Name] [nvarchar] (70) NOT NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_IdR__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_IdR__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_IdR_Id_IdR] PRIMARY KEY CLUSTERED
 (

  [Id]
 ) ON [PRIMARY],
 CONSTRAINT [IX_IdR_Nam_IdR] UNIQUE
 (

  [Name] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_Ido_Id_Ido', tableName='IdRoleClaim' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_Ido_Id_Ido]') AND parent_obj = object_id(N'[dbo].[IdRoleClaim]'))
 ALTER TABLE [dbo].[IdRoleClaim] DROP CONSTRAINT [PK_Ido_Id_Ido]
GO
CREATE TABLE [dbo].[IdRoleClaim] (
 [Id] [bigint] IDENTITY (1, 1) NOT NULL,
 [Type] [nvarchar] (256) NOT NULL,
 [Value] [nvarchar] (256) NULL,
 [ValueType] [nvarchar] (256) NULL,
 [Role_Id] [bigint] NOT NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_Ido__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_Ido__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_Ido_Id_Ido] PRIMARY KEY CLUSTERED
 (

  [Id]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_IdU_Id_IdU', tableName='IdUser' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_IdU_Id_IdU]') AND parent_obj = object_id(N'[dbo].[IdUser]'))
 ALTER TABLE [dbo].[IdUser] DROP CONSTRAINT [PK_IdU_Id_IdU]
GO
CREATE TABLE [dbo].[IdUser] (
 [Id] [bigint] IDENTITY (1, 1) NOT NULL,
 [UserName] [nvarchar] (70) NOT NULL,
 [CreationDateUTC] [datetime] NOT NULL,
 [Email] [nvarchar] (70) NULL,
 [EmailConfirmed] [bit] NOT NULL,
 [PhoneNumber] [nvarchar] (256) NULL,
 [PhoneNumberConfirmed] [bit] NOT NULL,
 [Password] [nvarchar] (256) NULL,
 [LastPasswordChangeDate] [datetime] NULL,
 [AccessFailedCount] [int] NOT NULL,
 [AccessFailedWindowStart] [datetime] NULL,
 [LockoutEnabled] [bit] NOT NULL,
 [LockoutEndDateUtc] [datetime] NULL,
 [LastProfileUpdateDate] [datetime] NULL,
 [SecurityStamp] [nvarchar] (256) NOT NULL,
 [TwoFactorEnabled] [bit] NOT NULL,
 [oUsuario_pId] [bigint] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_IdU__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_IdU__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_IdU_Id_IdU] PRIMARY KEY CLUSTERED
 (

  [Id]
 ) ON [PRIMARY],
 CONSTRAINT [IX_IdU_Use_IdU] UNIQUE
 (

  [UserName] ) ON [PRIMARY],
 CONSTRAINT [IX_IdU_Ema_IdU] UNIQUE
 (

  [Email] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_Ids_Id_Ids', tableName='IdUserClaim' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_Ids_Id_Ids]') AND parent_obj = object_id(N'[dbo].[IdUserClaim]'))
 ALTER TABLE [dbo].[IdUserClaim] DROP CONSTRAINT [PK_Ids_Id_Ids]
GO
CREATE TABLE [dbo].[IdUserClaim] (
 [Id] [bigint] IDENTITY (1, 1) NOT NULL,
 [Type] [nvarchar] (256) NOT NULL,
 [Value] [nvarchar] (256) NULL,
 [ValueType] [nvarchar] (256) NULL,
 [Issuer] [nvarchar] (256) NULL,
 [OriginalIssuer] [nvarchar] (256) NULL,
 [User_Id] [bigint] NOT NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_Ids__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_Ids__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_Ids_Id_Ids] PRIMARY KEY CLUSTERED
 (

  [Id]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_Ide_Id_Ide', tableName='IdUserLogin' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_Ide_Id_Ide]') AND parent_obj = object_id(N'[dbo].[IdUserLogin]'))
 ALTER TABLE [dbo].[IdUserLogin] DROP CONSTRAINT [PK_Ide_Id_Ide]
GO
CREATE TABLE [dbo].[IdUserLogin] (
 [Id] [bigint] IDENTITY (1, 1) NOT NULL,
 [ProviderName] [nvarchar] (256) NOT NULL,
 [ProviderKey] [nvarchar] (256) NOT NULL,
 [ProviderDisplayName] [nvarchar] (256) NOT NULL,
 [User_Id] [bigint] NOT NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_Ide__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_Ide__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_Ide_Id_Ide] PRIMARY KEY CLUSTERED
 (

  [Id]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_IND_pId_IND', tableName='INDICADORES_AGRICOLA' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_IND_pId_IND]') AND parent_obj = object_id(N'[dbo].[INDICADORES_AGRICOLA]'))
 ALTER TABLE [dbo].[INDICADORES_AGRICOLA] DROP CONSTRAINT [PK_IND_pId_IND]
GO
CREATE TABLE [dbo].[INDICADORES_AGRICOLA] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [NOTACALC] [int] NULL,
 [FRENTETIPO] [nvarchar] (256) NULL,
 [FRENTETIPOAUX] [nvarchar] (256) NULL,
 [DS_FRENTE] [nvarchar] (256) NULL,
 [DS_TIPO] [nvarchar] (256) NULL,
 [DS_FRENTETIPO] [nvarchar] (256) NULL,
 [ID_NEGOCIOS] [int] NULL,
 [INDICADOR] [nvarchar] (256) NULL,
 [FRENTE] [int] NULL,
 [PLANEJADO] [float] NULL,
 [REALIZADO] [float] NULL,
 [PERC] [float] NULL,
 [NOTA] [nvarchar] (256) NULL,
 [DATA_FECHAMENTO] [date] NULL,
 [UNIDADE_MEDIDA] [nvarchar] (256) NULL,
 [PERC_ABAIXO_META] [float] NULL,
 [PERC_ACIMA_META] [float] NULL,
 [TIPO] [nvarchar] (256) NULL,
 [GRUPO] [nvarchar] (256) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_IND__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_IND__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_IND_pId_IND] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_INI_pId_INI', tableName='INDICADORES_AGRICOLA_EQUIP' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_INI_pId_INI]') AND parent_obj = object_id(N'[dbo].[INDICADORES_AGRICOLA_EQUIP]'))
 ALTER TABLE [dbo].[INDICADORES_AGRICOLA_EQUIP] DROP CONSTRAINT [PK_INI_pId_INI]
GO
CREATE TABLE [dbo].[INDICADORES_AGRICOLA_EQUIP] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [FRENTETIPO] [nvarchar] (256) NULL,
 [FRENTETIPOAUX] [nvarchar] (256) NULL,
 [DS_FRENTE] [nvarchar] (256) NULL,
 [DS_TIPO] [nvarchar] (256) NULL,
 [DS_FRENTETIPO] [nvarchar] (256) NULL,
 [ID_NEGOCIOS] [int] NULL,
 [FRENTE] [int] NULL,
 [DATA_FECHAMENTO] [date] NULL,
 [TIPO] [nvarchar] (256) NULL,
 [GRUPO] [nvarchar] (256) NULL,
 [DSC_EQUIPAMENTO] [nvarchar] (256) NULL,
 [NRO_EQUIPAMENTO] [int] NULL,
 [R_DISP_MECANICA_COLHEDORA] [float] NULL,
 [R_DISP_MECANICA_DEMAIS] [float] NULL,
 [R_DISP_MECANICA] [float] NULL,
 [R_CONSUMO_OLEO_DIESELLTH] [float] NULL,
 [R_CONSUMO_OLEO_DIESELKML] [float] NULL,
 [R_CONSUMO_OLEO_DIESELLTTON] [float] NULL,
 [R_CONSUMO_OLEO_HIDRAULICO] [float] NULL,
 [R_TEMPO_APROVEIT_COLHEDORA] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_INI__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_INI__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_INI_pId_INI] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_INC_pId_INC', tableName='INDICADORES_AGRICOLA_TEMPOAPROV' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_INC_pId_INC]') AND parent_obj = object_id(N'[dbo].[INDICADORES_AGRICOLA_TEMPOAPROV]'))
 ALTER TABLE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV] DROP CONSTRAINT [PK_INC_pId_INC]
GO
CREATE TABLE [dbo].[INDICADORES_AGRICOLA_TEMPOAPROV] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [DATA_FECHAMENTO] [date] NOT NULL,
 [PERC_TEMPO_APROV] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_INC__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_INC__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_INC_pId_INC] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY],
 CONSTRAINT [IX_INC_DAT_INC] UNIQUE
 (

  [DATA_FECHAMENTO] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_INF_pId_INF', tableName='INFO_GERAIS' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_INF_pId_INF]') AND parent_obj = object_id(N'[dbo].[INFO_GERAIS]'))
 ALTER TABLE [dbo].[INFO_GERAIS] DROP CONSTRAINT [PK_INF_pId_INF]
GO
CREATE TABLE [dbo].[INFO_GERAIS] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [FRENTE] [int] NULL,
 [PROPRIEDADE] [int] NULL,
 [DSC_PROPRIEDADE] [nvarchar] (256) NULL,
 [COLHEDORA] [int] NULL,
 [TONELADA] [float] NULL,
 [QTD_VIAGENS] [int] NULL,
 [MEDIA_VIAGEM] [float] NULL,
 [RAIO_MEDIO] [float] NULL,
 [IMP_MINERAL] [float] NULL,
 [IMP_VEGETAL_PALHA] [float] NULL,
 [IMP_VEGETAL_PONTEIRA] [float] NULL,
 [IMP_MINERAL1] [float] NULL,
 [IMP_MINERAL2] [float] NULL,
 [IMP_VEGETAL_PALHA1] [float] NULL,
 [IMP_VEGETAL_PALHA2] [float] NULL,
 [IMP_VEGETAL_PONTEIRA1] [float] NULL,
 [IMP_VEGETAL_PONTEIRA2] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_INF__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_INF__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_INF_pId_INF] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_log_pId_log', tableName='loginregistro' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_log_pId_log]') AND parent_obj = object_id(N'[dbo].[loginregistro]'))
 ALTER TABLE [dbo].[loginregistro] DROP CONSTRAINT [PK_log_pId_log]
GO
CREATE TABLE [dbo].[loginregistro] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pDataHora] [datetime] NULL,
 [pSenha] [nvarchar] (256) NULL,
 [pObsLog] [nvarchar] (256) NULL,
 [pCodigoUsuario] [int] NULL,
 [pLoginUsuario] [nvarchar] (256) NULL,
 [pFlgAdminUsuario] [nvarchar] (1) NULL,
 [pCodigoFilial] [int] NULL,
 [pCodigoEmpresa] [int] NULL,
 [pLoginValidado] [bit] NULL,
 [sUsuarioStatus] [int] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_log__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_log__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_log_pId_log] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_MAP_pId_MAP', tableName='MAPA_PLANCOLHEITA' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_MAP_pId_MAP]') AND parent_obj = object_id(N'[dbo].[MAPA_PLANCOLHEITA]'))
 ALTER TABLE [dbo].[MAPA_PLANCOLHEITA] DROP CONSTRAINT [PK_MAP_pId_MAP]
GO
CREATE TABLE [dbo].[MAPA_PLANCOLHEITA] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [PROP_CODIGO] [int] NULL,
 [DS_NOME_PROPRIEDADE] [nvarchar] (256) NULL,
 [FRENTE_COLHEITA] [int] NULL,
 [MES] [date] NULL,
 [SEMANA] [int] NULL,
 [MES_SEMANA] [nvarchar] (256) NULL,
 [SEMANA_PERIODO] [nvarchar] (256) NULL,
 [REFORMA_PREV] [nvarchar] (256) NULL,
 [AREA_PREV] [float] NULL,
 [TONELADA_PREV] [float] NULL,
 [AREA_PREV_REFORMA] [float] NULL,
 [TONELADA_PREV_REFORMA] [float] NULL,
 [AREA_PREV_TOTAL] [float] NULL,
 [AREA_PREV_REFORMA_TOTAL] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_MAP__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_MAP__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_MAP_pId_MAP] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_men_pId_men', tableName='menu' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_men_pId_men]') AND parent_obj = object_id(N'[dbo].[menu]'))
 ALTER TABLE [dbo].[menu] DROP CONSTRAINT [PK_men_pId_men]
GO
CREATE TABLE [dbo].[menu] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pDescricao] [nvarchar] (256) NULL,
 [pNomeToolStrip] [nvarchar] (256) NULL,
 [oSistema_pId] [bigint] NULL,
 [pNivelPosicao] [int] NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_men__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_men__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_men_pId_men] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_meu_pId_meu', tableName='menupermissao' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_meu_pId_meu]') AND parent_obj = object_id(N'[dbo].[menupermissao]'))
 ALTER TABLE [dbo].[menupermissao] DROP CONSTRAINT [PK_meu_pId_meu]
GO
CREATE TABLE [dbo].[menupermissao] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [oUsuario_pId] [bigint] NULL,
 [oSistema_pId] [bigint] NULL,
 [pNomeToolStripPerm] [nvarchar] (256) NOT NULL,
 [pFlgPermissao] [nvarchar] (1) NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_meu__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_meu__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_meu_pId_meu] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_MOA_pId_MOA', tableName='MOAGEM_CANA_HORA' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_MOA_pId_MOA]') AND parent_obj = object_id(N'[dbo].[MOAGEM_CANA_HORA]'))
 ALTER TABLE [dbo].[MOAGEM_CANA_HORA] DROP CONSTRAINT [PK_MOA_pId_MOA]
GO
CREATE TABLE [dbo].[MOAGEM_CANA_HORA] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [DIA] [date] NULL,
 [HORA] [nvarchar] (256) NULL,
 [VIAGEM] [int] NULL,
 [TONELADAS] [float] NULL,
 [METAFRENTE] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_MOA__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_MOA__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_MOA_pId_MOA] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_pai_pId_pai', tableName='pais' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_pai_pId_pai]') AND parent_obj = object_id(N'[dbo].[pais]'))
 ALTER TABLE [dbo].[pais] DROP CONSTRAINT [PK_pai_pId_pai]
GO
CREATE TABLE [dbo].[pais] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pCodigo] [int] NOT NULL,
 [pNome] [nvarchar] (256) NULL,
 [pSigla] [nvarchar] (3) NULL,
 [pCodigoIbge] [int] NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_pai__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_pai__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_pai_pId_pai] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY],
 CONSTRAINT [IX_pai_pSi_pai] UNIQUE
 (

  [pSigla] ) ON [PRIMARY],
 CONSTRAINT [IX_pai_pCd_pai] UNIQUE
 (

  [pCodigoIbge] ) ON [PRIMARY],
 CONSTRAINT [IX_pai_pCo_pai] UNIQUE
 (

  [pCodigo] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_PRO_pId_PRO', tableName='PROPRIEDADES' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_PRO_pId_PRO]') AND parent_obj = object_id(N'[dbo].[PROPRIEDADES]'))
 ALTER TABLE [dbo].[PROPRIEDADES] DROP CONSTRAINT [PK_PRO_pId_PRO]
GO
CREATE TABLE [dbo].[PROPRIEDADES] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [SAFRA] [int] NULL,
 [COD_PROPRIEDADE] [int] NULL,
 [DSC_PROPRIEDADE] [nvarchar] (256) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_PRO__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_PRO__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_PRO_pId_PRO] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_RES_pId_RES', tableName='RES_MENSAL_ACUMULADA' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_RES_pId_RES]') AND parent_obj = object_id(N'[dbo].[RES_MENSAL_ACUMULADA]'))
 ALTER TABLE [dbo].[RES_MENSAL_ACUMULADA] DROP CONSTRAINT [PK_RES_pId_RES]
GO
CREATE TABLE [dbo].[RES_MENSAL_ACUMULADA] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [NRO_ANO_SAFRA] [int] NULL,
 [MES] [nvarchar] (256) NULL,
 [DIA] [date] NULL,
 [TONELADA_PLAN] [float] NULL,
 [TONELADA_PLAN_AC] [float] NULL,
 [TONELADA_REAL] [float] NULL,
 [TONELADA_REAL_AC] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_RES__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_RES__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_RES_pId_RES] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_RE__pId_RE_', tableName='RES_MENSAL_DIARIA' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_RE__pId_RE_]') AND parent_obj = object_id(N'[dbo].[RES_MENSAL_DIARIA]'))
 ALTER TABLE [dbo].[RES_MENSAL_DIARIA] DROP CONSTRAINT [PK_RE__pId_RE_]
GO
CREATE TABLE [dbo].[RES_MENSAL_DIARIA] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [NRO_ANO_SAFRA] [int] NULL,
 [MES] [nvarchar] (256) NULL,
 [DIA] [date] NULL,
 [TONELADA_PLAN] [float] NULL,
 [TONELADA_REAL] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_RE___tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_RE___tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_RE__pId_RE_] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_REM_pId_REM', tableName='RES_MENSAL_GRID' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_REM_pId_REM]') AND parent_obj = object_id(N'[dbo].[RES_MENSAL_GRID]'))
 ALTER TABLE [dbo].[RES_MENSAL_GRID] DROP CONSTRAINT [PK_REM_pId_REM]
GO
CREATE TABLE [dbo].[RES_MENSAL_GRID] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [NRO_ANO_SAFRA] [int] NULL,
 [MES] [nvarchar] (256) NULL,
 [MES_N] [int] NULL,
 [TIPO] [nvarchar] (256) NULL,
 [TONELADA] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_REM__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_REM__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_REM_pId_REM] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_REE_pId_REE', tableName='RES_MENSAL_SAFRA' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_REE_pId_REE]') AND parent_obj = object_id(N'[dbo].[RES_MENSAL_SAFRA]'))
 ALTER TABLE [dbo].[RES_MENSAL_SAFRA] DROP CONSTRAINT [PK_REE_pId_REE]
GO
CREATE TABLE [dbo].[RES_MENSAL_SAFRA] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [NRO_ANO_SAFRA] [int] NULL,
 [MES] [nvarchar] (256) NULL,
 [DIA] [date] NULL,
 [TONELADA_PLAN] [float] NULL,
 [TONELADA_REAL] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_REE__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_REE__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_REE_pId_REE] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_REN_pId_REN', tableName='RES_MENSAL_SAFRA_ACUMULADA' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_REN_pId_REN]') AND parent_obj = object_id(N'[dbo].[RES_MENSAL_SAFRA_ACUMULADA]'))
 ALTER TABLE [dbo].[RES_MENSAL_SAFRA_ACUMULADA] DROP CONSTRAINT [PK_REN_pId_REN]
GO
CREATE TABLE [dbo].[RES_MENSAL_SAFRA_ACUMULADA] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [NRO_ANO_SAFRA] [int] NULL,
 [MES] [nvarchar] (256) NULL,
 [DIA] [date] NULL,
 [TONELADA_PLAN] [float] NULL,
 [TONELADA_PLAN_AC] [float] NULL,
 [TONELADA_REAL] [float] NULL,
 [TONELADA_REAL_AC] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_REN__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_REN__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_REN_pId_REN] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_SAF_pId_SAF', tableName='SAFRA_ANO' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_SAF_pId_SAF]') AND parent_obj = object_id(N'[dbo].[SAFRA_ANO]'))
 ALTER TABLE [dbo].[SAFRA_ANO] DROP CONSTRAINT [PK_SAF_pId_SAF]
GO
CREATE TABLE [dbo].[SAFRA_ANO] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [SAFRA] [int] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_SAF__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_SAF__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_SAF_pId_SAF] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_SEQ_pId_SEQ', tableName='SEQUENCIA_COLHEITA' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_SEQ_pId_SEQ]') AND parent_obj = object_id(N'[dbo].[SEQUENCIA_COLHEITA]'))
 ALTER TABLE [dbo].[SEQUENCIA_COLHEITA] DROP CONSTRAINT [PK_SEQ_pId_SEQ]
GO
CREATE TABLE [dbo].[SEQUENCIA_COLHEITA] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [FRENTE_COLHEITA] [int] NULL,
 [PROP_CODIGO] [int] NULL,
 [DS_NOME_PROPRIEDADE] [nvarchar] (256) NULL,
 [COORD_LAT] [float] NULL,
 [COORD_LONG] [float] NULL,
 [ORDEM] [int] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_SEQ__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_SEQ__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_SEQ_pId_SEQ] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_sis_pId_sis', tableName='sistema' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_sis_pId_sis]') AND parent_obj = object_id(N'[dbo].[sistema]'))
 ALTER TABLE [dbo].[sistema] DROP CONSTRAINT [PK_sis_pId_sis]
GO
CREATE TABLE [dbo].[sistema] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pNome] [nvarchar] (256) NULL,
 [pCodigo] [int] NOT NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_sis__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_sis__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_sis_pId_sis] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY],
 CONSTRAINT [IX_sis_pCo_sis] UNIQUE
 (

  [pCodigo] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_uf_pId_uf', tableName='uf' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_uf_pId_uf]') AND parent_obj = object_id(N'[dbo].[uf]'))
 ALTER TABLE [dbo].[uf] DROP CONSTRAINT [PK_uf_pId_uf]
GO
CREATE TABLE [dbo].[uf] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pCodigo] [int] NOT NULL,
 [pDescricao] [nvarchar] (256) NULL,
 [pSigla] [nvarchar] (2) NULL,
 [pCodigoIbge] [int] NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [oPais_pId] [bigint] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_uf__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_uf__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_uf_pId_uf] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY],
 CONSTRAINT [IX_uf_pSi_uf] UNIQUE
 (

  [pSigla] ) ON [PRIMARY],
 CONSTRAINT [IX_uf_pCd_uf] UNIQUE
 (

  [pCodigoIbge] ) ON [PRIMARY],
 CONSTRAINT [IX_uf_pCo_uf] UNIQUE
 (

  [pCodigo] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_usu_pId_usu', tableName='usuario' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_usu_pId_usu]') AND parent_obj = object_id(N'[dbo].[usuario]'))
 ALTER TABLE [dbo].[usuario] DROP CONSTRAINT [PK_usu_pId_usu]
GO
CREATE TABLE [dbo].[usuario] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pCodigo] [int] NOT NULL,
 [pLogin] [nvarchar] (20) NOT NULL,
 [pSenha] [nvarchar] (256) NULL,
 [pFlgAdmin] [nvarchar] (1) NULL,
 [sStatus] [int] NULL,
 [xDataHoraReg] [datetime] NULL,
 [xLoginReg] [nvarchar] (30) NULL,
 [oCadastro_pId] [bigint] NULL,
 [oIdUser_Id] [bigint] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_usu__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_usu__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_usu_pId_usu] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY],
 CONSTRAINT [IX_usu_pLo_usu] UNIQUE
 (

  [pLogin] ) ON [PRIMARY],
 CONSTRAINT [IX_usu_pCo_usu] UNIQUE
 (

  [pCodigo] ) ON [PRIMARY]
)
GO

/* no fk for 'PK_V_D_pId_V_D', tableName='V_DADOS_TALHAO' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_V_D_pId_V_D]') AND parent_obj = object_id(N'[dbo].[V_DADOS_TALHAO]'))
 ALTER TABLE [dbo].[V_DADOS_TALHAO] DROP CONSTRAINT [PK_V_D_pId_V_D]
GO
CREATE TABLE [dbo].[V_DADOS_TALHAO] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [ID_NEGOCIOS] [int] NULL,
 [SAFRA] [int] NULL,
 [COD_PROPRIEDADE] [int] NULL,
 [DSC_PROPRIEDADE] [nvarchar] (256) NULL,
 [TALHAO] [int] NULL,
 [CORTE] [int] NULL,
 [AMBIENTE] [nvarchar] (256) NULL,
 [VARIEDADE] [nvarchar] (256) NULL,
 [MATURACAO] [nvarchar] (256) NULL,
 [AREA_TOTAL] [float] NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_V_D__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_V_D__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_V_D_pId_V_D] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_Web_pId_Web', tableName='WebSiteMap' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_Web_pId_Web]') AND parent_obj = object_id(N'[dbo].[WebSiteMap]'))
 ALTER TABLE [dbo].[WebSiteMap] DROP CONSTRAINT [PK_Web_pId_Web]
GO
CREATE TABLE [dbo].[WebSiteMap] (
 [pId] [bigint] IDENTITY (1, 1) NOT NULL,
 [pRelPath] [nvarchar] (256) NULL,
 [pNode] [nvarchar] (256) NULL,
 [pDescription] [nvarchar] (256) NULL,
 [_trackLastWriteTime] [datetime] NOT NULL CONSTRAINT [DF_Web__tc] DEFAULT (GETDATE()),
 [_trackCreationTime] [datetime] NOT NULL CONSTRAINT [DF_Web__tk] DEFAULT (GETDATE()),
 [_trackLastWriteUser] [nvarchar] (64) NOT NULL,
 [_trackCreationUser] [nvarchar] (64) NOT NULL,
 CONSTRAINT [PK_Web_pId_Web] PRIMARY KEY CLUSTERED
 (

  [pId]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_ape_pId_pI2_ape', tableName='apprelatorio_oUsuarios_usuario_oAppRelatorios' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_ape_pId_pI2_ape]') AND parent_obj = object_id(N'[dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios]'))
 ALTER TABLE [dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios] DROP CONSTRAINT [PK_ape_pId_pI2_ape]
GO
CREATE TABLE [dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios] (
 [pId] [bigint] NOT NULL,
 [pId2] [bigint] NOT NULL,
 CONSTRAINT [PK_ape_pId_pI2_ape] PRIMARY KEY NONCLUSTERED
 (

  [pId],
  [pId2]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_cas_pId_pI2_cas', tableName='cadastro_oempresas_empresa_ocadastros' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_cas_pId_pI2_cas]') AND parent_obj = object_id(N'[dbo].[cadastro_oempresas_empresa_ocadastros]'))
 ALTER TABLE [dbo].[cadastro_oempresas_empresa_ocadastros] DROP CONSTRAINT [PK_cas_pId_pI2_cas]
GO
CREATE TABLE [dbo].[cadastro_oempresas_empresa_ocadastros] (
 [pId] [bigint] NOT NULL,
 [pId2] [bigint] NOT NULL,
 CONSTRAINT [PK_cas_pId_pI2_cas] PRIMARY KEY NONCLUSTERED
 (

  [pId],
  [pId2]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_cat_pId_pI2_cat', tableName='cadastro_ocadastrostipo_cadastrotipo_ocadastros' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_cat_pId_pI2_cat]') AND parent_obj = object_id(N'[dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros]'))
 ALTER TABLE [dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros] DROP CONSTRAINT [PK_cat_pId_pI2_cat]
GO
CREATE TABLE [dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros] (
 [pId] [bigint] NOT NULL,
 [pId2] [bigint] NOT NULL,
 CONSTRAINT [PK_cat_pId_pI2_cat] PRIMARY KEY NONCLUSTERED
 (

  [pId],
  [pId2]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_emr_pId_pI2_emr', tableName='empresa_osistemas_sistema_oempresas' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_emr_pId_pI2_emr]') AND parent_obj = object_id(N'[dbo].[empresa_osistemas_sistema_oempresas]'))
 ALTER TABLE [dbo].[empresa_osistemas_sistema_oempresas] DROP CONSTRAINT [PK_emr_pId_pI2_emr]
GO
CREATE TABLE [dbo].[empresa_osistemas_sistema_oempresas] (
 [pId] [bigint] NOT NULL,
 [pId2] [bigint] NOT NULL,
 CONSTRAINT [PK_emr_pId_pI2_emr] PRIMARY KEY NONCLUSTERED
 (

  [pId],
  [pId2]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_fia_pId_pI2_fia', tableName='filial_ousuarios_usuario_ofiliais' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_fia_pId_pI2_fia]') AND parent_obj = object_id(N'[dbo].[filial_ousuarios_usuario_ofiliais]'))
 ALTER TABLE [dbo].[filial_ousuarios_usuario_ofiliais] DROP CONSTRAINT [PK_fia_pId_pI2_fia]
GO
CREATE TABLE [dbo].[filial_ousuarios_usuario_ofiliais] (
 [pId] [bigint] NOT NULL,
 [pId2] [bigint] NOT NULL,
 CONSTRAINT [PK_fia_pId_pI2_fia] PRIMARY KEY NONCLUSTERED
 (

  [pId],
  [pId2]
 ) ON [PRIMARY]
)
GO

/* no fk for 'PK_Idl_Id_Id2_Idl', tableName='IdRole_Users_IdUser_Roles' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[PK_Idl_Id_Id2_Idl]') AND parent_obj = object_id(N'[dbo].[IdRole_Users_IdUser_Roles]'))
 ALTER TABLE [dbo].[IdRole_Users_IdUser_Roles] DROP CONSTRAINT [PK_Idl_Id_Id2_Idl]
GO
CREATE TABLE [dbo].[IdRole_Users_IdUser_Roles] (
 [Id] [bigint] NOT NULL,
 [Id2] [bigint] NOT NULL,
 CONSTRAINT [PK_Idl_Id_Id2_Idl] PRIMARY KEY NONCLUSTERED
 (

  [Id],
  [Id2]
 ) ON [PRIMARY]
)
GO

