/* CodeFluent Generated . TargetVersion:Sql2014. Culture:pt-BR. UiCulture:pt-BR. Encoding:utf-8 (http://www.softfluent.com) */
set quoted_identifier OFF
GO
/* no fk for 'FK_cad_oCi_pId_cid', tableName='cadastro' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_cad_oCi_pId_cid]') AND parent_obj = object_id(N'[dbo].[cadastro]'))
 ALTER TABLE [dbo].[cadastro] DROP CONSTRAINT [FK_cad_oCi_pId_cid]
GO
/* no fk for 'FK_cad_oCd_pId_cid', tableName='cadastro' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_cad_oCd_pId_cid]') AND parent_obj = object_id(N'[dbo].[cadastro]'))
 ALTER TABLE [dbo].[cadastro] DROP CONSTRAINT [FK_cad_oCd_pId_cid]
GO
/* no fk for 'FK_cad_oUs_pId_usu', tableName='cadastro' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_cad_oUs_pId_usu]') AND parent_obj = object_id(N'[dbo].[cadastro]'))
 ALTER TABLE [dbo].[cadastro] DROP CONSTRAINT [FK_cad_oUs_pId_usu]
GO
/* no fk for 'FK_cad_oCa_pId_fil', tableName='cadastro' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_cad_oCa_pId_fil]') AND parent_obj = object_id(N'[dbo].[cadastro]'))
 ALTER TABLE [dbo].[cadastro] DROP CONSTRAINT [FK_cad_oCa_pId_fil]
GO
/* no fk for 'FK_cid_oUF_pId_uf', tableName='cidade' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_cid_oUF_pId_uf]') AND parent_obj = object_id(N'[dbo].[cidade]'))
 ALTER TABLE [dbo].[cidade] DROP CONSTRAINT [FK_cid_oUF_pId_uf]
GO
/* no fk for 'FK_fil_oEm_pId_emp', tableName='filial' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_fil_oEm_pId_emp]') AND parent_obj = object_id(N'[dbo].[filial]'))
 ALTER TABLE [dbo].[filial] DROP CONSTRAINT [FK_fil_oEm_pId_emp]
GO
/* no fk for 'FK_fil_oCa_pId_cad', tableName='filial' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_fil_oCa_pId_cad]') AND parent_obj = object_id(N'[dbo].[filial]'))
 ALTER TABLE [dbo].[filial] DROP CONSTRAINT [FK_fil_oCa_pId_cad]
GO
/* no fk for 'FK_fii_oFi_pId_fil', tableName='filialconfig' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_fii_oFi_pId_fil]') AND parent_obj = object_id(N'[dbo].[filialconfig]'))
 ALTER TABLE [dbo].[filialconfig] DROP CONSTRAINT [FK_fii_oFi_pId_fil]
GO
/* no fk for 'FK_Ido_Rol_Id_IdR', tableName='IdRoleClaim' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_Ido_Rol_Id_IdR]') AND parent_obj = object_id(N'[dbo].[IdRoleClaim]'))
 ALTER TABLE [dbo].[IdRoleClaim] DROP CONSTRAINT [FK_Ido_Rol_Id_IdR]
GO
/* no fk for 'FK_IdU_oUs_pId_usu', tableName='IdUser' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_IdU_oUs_pId_usu]') AND parent_obj = object_id(N'[dbo].[IdUser]'))
 ALTER TABLE [dbo].[IdUser] DROP CONSTRAINT [FK_IdU_oUs_pId_usu]
GO
/* no fk for 'FK_Ids_Use_Id_IdU', tableName='IdUserClaim' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_Ids_Use_Id_IdU]') AND parent_obj = object_id(N'[dbo].[IdUserClaim]'))
 ALTER TABLE [dbo].[IdUserClaim] DROP CONSTRAINT [FK_Ids_Use_Id_IdU]
GO
/* no fk for 'FK_Ide_Use_Id_IdU', tableName='IdUserLogin' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_Ide_Use_Id_IdU]') AND parent_obj = object_id(N'[dbo].[IdUserLogin]'))
 ALTER TABLE [dbo].[IdUserLogin] DROP CONSTRAINT [FK_Ide_Use_Id_IdU]
GO
/* no fk for 'FK_men_oSi_pId_sis', tableName='menu' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_men_oSi_pId_sis]') AND parent_obj = object_id(N'[dbo].[menu]'))
 ALTER TABLE [dbo].[menu] DROP CONSTRAINT [FK_men_oSi_pId_sis]
GO
/* no fk for 'FK_meu_oUs_pId_usu', tableName='menupermissao' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_meu_oUs_pId_usu]') AND parent_obj = object_id(N'[dbo].[menupermissao]'))
 ALTER TABLE [dbo].[menupermissao] DROP CONSTRAINT [FK_meu_oUs_pId_usu]
GO
/* no fk for 'FK_meu_oSi_pId_sis', tableName='menupermissao' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_meu_oSi_pId_sis]') AND parent_obj = object_id(N'[dbo].[menupermissao]'))
 ALTER TABLE [dbo].[menupermissao] DROP CONSTRAINT [FK_meu_oSi_pId_sis]
GO
/* no fk for 'FK_uf_oPa_pId_pai', tableName='uf' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_uf_oPa_pId_pai]') AND parent_obj = object_id(N'[dbo].[uf]'))
 ALTER TABLE [dbo].[uf] DROP CONSTRAINT [FK_uf_oPa_pId_pai]
GO
/* no fk for 'FK_usu_oCa_pId_cad', tableName='usuario' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_usu_oCa_pId_cad]') AND parent_obj = object_id(N'[dbo].[usuario]'))
 ALTER TABLE [dbo].[usuario] DROP CONSTRAINT [FK_usu_oCa_pId_cad]
GO
/* no fk for 'FK_usu_oId_Id_IdU', tableName='usuario' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_usu_oId_Id_IdU]') AND parent_obj = object_id(N'[dbo].[usuario]'))
 ALTER TABLE [dbo].[usuario] DROP CONSTRAINT [FK_usu_oId_Id_IdU]
GO
/* no fk for 'FK_ape_pId_pId_apr', tableName='apprelatorio_oUsuarios_usuario_oAppRelatorios' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_ape_pId_pId_apr]') AND parent_obj = object_id(N'[dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios]'))
 ALTER TABLE [dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios] DROP CONSTRAINT [FK_ape_pId_pId_apr]
GO
/* no fk for 'FK_ape_pI2_pId_usu', tableName='apprelatorio_oUsuarios_usuario_oAppRelatorios' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_ape_pI2_pId_usu]') AND parent_obj = object_id(N'[dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios]'))
 ALTER TABLE [dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios] DROP CONSTRAINT [FK_ape_pI2_pId_usu]
GO
/* no fk for 'FK_cas_pId_pId_cad', tableName='cadastro_oempresas_empresa_ocadastros' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_cas_pId_pId_cad]') AND parent_obj = object_id(N'[dbo].[cadastro_oempresas_empresa_ocadastros]'))
 ALTER TABLE [dbo].[cadastro_oempresas_empresa_ocadastros] DROP CONSTRAINT [FK_cas_pId_pId_cad]
GO
/* no fk for 'FK_cas_pI2_pId_emp', tableName='cadastro_oempresas_empresa_ocadastros' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_cas_pI2_pId_emp]') AND parent_obj = object_id(N'[dbo].[cadastro_oempresas_empresa_ocadastros]'))
 ALTER TABLE [dbo].[cadastro_oempresas_empresa_ocadastros] DROP CONSTRAINT [FK_cas_pI2_pId_emp]
GO
/* no fk for 'FK_cat_pId_pId_cad', tableName='cadastro_ocadastrostipo_cadastrotipo_ocadastros' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_cat_pId_pId_cad]') AND parent_obj = object_id(N'[dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros]'))
 ALTER TABLE [dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros] DROP CONSTRAINT [FK_cat_pId_pId_cad]
GO
/* no fk for 'FK_cat_pI2_pId_caa', tableName='cadastro_ocadastrostipo_cadastrotipo_ocadastros' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_cat_pI2_pId_caa]') AND parent_obj = object_id(N'[dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros]'))
 ALTER TABLE [dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros] DROP CONSTRAINT [FK_cat_pI2_pId_caa]
GO
/* no fk for 'FK_emr_pId_pId_emp', tableName='empresa_osistemas_sistema_oempresas' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_emr_pId_pId_emp]') AND parent_obj = object_id(N'[dbo].[empresa_osistemas_sistema_oempresas]'))
 ALTER TABLE [dbo].[empresa_osistemas_sistema_oempresas] DROP CONSTRAINT [FK_emr_pId_pId_emp]
GO
/* no fk for 'FK_emr_pI2_pId_sis', tableName='empresa_osistemas_sistema_oempresas' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_emr_pI2_pId_sis]') AND parent_obj = object_id(N'[dbo].[empresa_osistemas_sistema_oempresas]'))
 ALTER TABLE [dbo].[empresa_osistemas_sistema_oempresas] DROP CONSTRAINT [FK_emr_pI2_pId_sis]
GO
/* no fk for 'FK_fia_pId_pId_fil', tableName='filial_ousuarios_usuario_ofiliais' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_fia_pId_pId_fil]') AND parent_obj = object_id(N'[dbo].[filial_ousuarios_usuario_ofiliais]'))
 ALTER TABLE [dbo].[filial_ousuarios_usuario_ofiliais] DROP CONSTRAINT [FK_fia_pId_pId_fil]
GO
/* no fk for 'FK_fia_pI2_pId_usu', tableName='filial_ousuarios_usuario_ofiliais' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_fia_pI2_pId_usu]') AND parent_obj = object_id(N'[dbo].[filial_ousuarios_usuario_ofiliais]'))
 ALTER TABLE [dbo].[filial_ousuarios_usuario_ofiliais] DROP CONSTRAINT [FK_fia_pI2_pId_usu]
GO
/* no fk for 'FK_Idl_Id_Id_IdR', tableName='IdRole_Users_IdUser_Roles' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_Idl_Id_Id_IdR]') AND parent_obj = object_id(N'[dbo].[IdRole_Users_IdUser_Roles]'))
 ALTER TABLE [dbo].[IdRole_Users_IdUser_Roles] DROP CONSTRAINT [FK_Idl_Id_Id_IdR]
GO
/* no fk for 'FK_Idl_Id2_Id_IdU', tableName='IdRole_Users_IdUser_Roles' table='null' */
IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[FK_Idl_Id2_Id_IdU]') AND parent_obj = object_id(N'[dbo].[IdRole_Users_IdUser_Roles]'))
 ALTER TABLE [dbo].[IdRole_Users_IdUser_Roles] DROP CONSTRAINT [FK_Idl_Id2_Id_IdU]
GO
