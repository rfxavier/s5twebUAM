/* CodeFluent Generated . TargetVersion:Sql2014. Culture:pt-BR. UiCulture:pt-BR. Encoding:utf-8 (http://www.softfluent.com) */
set quoted_identifier OFF
GO
ALTER TABLE [dbo].[cadastro] WITH NOCHECK ADD CONSTRAINT [FK_cad_oCi_pId_cid] FOREIGN KEY (
 [oCidade_pId]
) REFERENCES [dbo].[cidade](

 [pId]
)
ALTER TABLE [dbo].[cadastro] NOCHECK CONSTRAINT [FK_cad_oCi_pId_cid]
ALTER TABLE [dbo].[cadastro] WITH NOCHECK ADD CONSTRAINT [FK_cad_oCd_pId_cid] FOREIGN KEY (
 [oCidadeAux_pId]
) REFERENCES [dbo].[cidade](

 [pId]
)
ALTER TABLE [dbo].[cadastro] NOCHECK CONSTRAINT [FK_cad_oCd_pId_cid]
ALTER TABLE [dbo].[cadastro] WITH NOCHECK ADD CONSTRAINT [FK_cad_oUs_pId_usu] FOREIGN KEY (
 [oUsuario_pId]
) REFERENCES [dbo].[usuario](

 [pId]
)
ALTER TABLE [dbo].[cadastro] NOCHECK CONSTRAINT [FK_cad_oUs_pId_usu]
ALTER TABLE [dbo].[cadastro] WITH NOCHECK ADD CONSTRAINT [FK_cad_oCa_pId_fil] FOREIGN KEY (
 [oCadastroFilial_pId]
) REFERENCES [dbo].[filial](

 [pId]
)
ALTER TABLE [dbo].[cadastro] NOCHECK CONSTRAINT [FK_cad_oCa_pId_fil]
ALTER TABLE [dbo].[cidade] WITH NOCHECK ADD CONSTRAINT [FK_cid_oUF_pId_uf] FOREIGN KEY (
 [oUF_pId]
) REFERENCES [dbo].[uf](

 [pId]
)
ALTER TABLE [dbo].[cidade] NOCHECK CONSTRAINT [FK_cid_oUF_pId_uf]
ALTER TABLE [dbo].[filial] WITH NOCHECK ADD CONSTRAINT [FK_fil_oEm_pId_emp] FOREIGN KEY (
 [oEmpresa_pId]
) REFERENCES [dbo].[empresa](

 [pId]
)
ALTER TABLE [dbo].[filial] NOCHECK CONSTRAINT [FK_fil_oEm_pId_emp]
ALTER TABLE [dbo].[filial] WITH NOCHECK ADD CONSTRAINT [FK_fil_oCa_pId_cad] FOREIGN KEY (
 [oCadastro_pId]
) REFERENCES [dbo].[cadastro](

 [pId]
)
ALTER TABLE [dbo].[filial] NOCHECK CONSTRAINT [FK_fil_oCa_pId_cad]
ALTER TABLE [dbo].[filialconfig] WITH NOCHECK ADD CONSTRAINT [FK_fii_oFi_pId_fil] FOREIGN KEY (
 [oFilial_pId]
) REFERENCES [dbo].[filial](

 [pId]
)
ALTER TABLE [dbo].[filialconfig] NOCHECK CONSTRAINT [FK_fii_oFi_pId_fil]
ALTER TABLE [dbo].[IdRoleClaim] WITH NOCHECK ADD CONSTRAINT [FK_Ido_Rol_Id_IdR] FOREIGN KEY (
 [Role_Id]
) REFERENCES [dbo].[IdRole](

 [Id]
)
ALTER TABLE [dbo].[IdRoleClaim] NOCHECK CONSTRAINT [FK_Ido_Rol_Id_IdR]
ALTER TABLE [dbo].[IdUser] WITH NOCHECK ADD CONSTRAINT [FK_IdU_oUs_pId_usu] FOREIGN KEY (
 [oUsuario_pId]
) REFERENCES [dbo].[usuario](

 [pId]
)
ALTER TABLE [dbo].[IdUser] NOCHECK CONSTRAINT [FK_IdU_oUs_pId_usu]
ALTER TABLE [dbo].[IdUserClaim] WITH NOCHECK ADD CONSTRAINT [FK_Ids_Use_Id_IdU] FOREIGN KEY (
 [User_Id]
) REFERENCES [dbo].[IdUser](

 [Id]
)
ALTER TABLE [dbo].[IdUserClaim] NOCHECK CONSTRAINT [FK_Ids_Use_Id_IdU]
ALTER TABLE [dbo].[IdUserLogin] WITH NOCHECK ADD CONSTRAINT [FK_Ide_Use_Id_IdU] FOREIGN KEY (
 [User_Id]
) REFERENCES [dbo].[IdUser](

 [Id]
)
ALTER TABLE [dbo].[IdUserLogin] NOCHECK CONSTRAINT [FK_Ide_Use_Id_IdU]
ALTER TABLE [dbo].[menu] WITH NOCHECK ADD CONSTRAINT [FK_men_oSi_pId_sis] FOREIGN KEY (
 [oSistema_pId]
) REFERENCES [dbo].[sistema](

 [pId]
)
ALTER TABLE [dbo].[menu] NOCHECK CONSTRAINT [FK_men_oSi_pId_sis]
ALTER TABLE [dbo].[menupermissao] WITH NOCHECK ADD CONSTRAINT [FK_meu_oUs_pId_usu] FOREIGN KEY (
 [oUsuario_pId]
) REFERENCES [dbo].[usuario](

 [pId]
)
ALTER TABLE [dbo].[menupermissao] NOCHECK CONSTRAINT [FK_meu_oUs_pId_usu]
ALTER TABLE [dbo].[menupermissao] WITH NOCHECK ADD CONSTRAINT [FK_meu_oSi_pId_sis] FOREIGN KEY (
 [oSistema_pId]
) REFERENCES [dbo].[sistema](

 [pId]
)
ALTER TABLE [dbo].[menupermissao] NOCHECK CONSTRAINT [FK_meu_oSi_pId_sis]
ALTER TABLE [dbo].[uf] WITH NOCHECK ADD CONSTRAINT [FK_uf_oPa_pId_pai] FOREIGN KEY (
 [oPais_pId]
) REFERENCES [dbo].[pais](

 [pId]
)
ALTER TABLE [dbo].[uf] NOCHECK CONSTRAINT [FK_uf_oPa_pId_pai]
ALTER TABLE [dbo].[usuario] WITH NOCHECK ADD CONSTRAINT [FK_usu_oCa_pId_cad] FOREIGN KEY (
 [oCadastro_pId]
) REFERENCES [dbo].[cadastro](

 [pId]
)
ALTER TABLE [dbo].[usuario] NOCHECK CONSTRAINT [FK_usu_oCa_pId_cad]
ALTER TABLE [dbo].[usuario] WITH NOCHECK ADD CONSTRAINT [FK_usu_oId_Id_IdU] FOREIGN KEY (
 [oIdUser_Id]
) REFERENCES [dbo].[IdUser](

 [Id]
)
ALTER TABLE [dbo].[usuario] NOCHECK CONSTRAINT [FK_usu_oId_Id_IdU]
ALTER TABLE [dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios] WITH NOCHECK ADD CONSTRAINT [FK_ape_pId_pId_apr] FOREIGN KEY (
 [pId]
) REFERENCES [dbo].[apprelatorio](

 [pId]
)
ALTER TABLE [dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios] NOCHECK CONSTRAINT [FK_ape_pId_pId_apr]
ALTER TABLE [dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios] WITH NOCHECK ADD CONSTRAINT [FK_ape_pI2_pId_usu] FOREIGN KEY (
 [pId2]
) REFERENCES [dbo].[usuario](

 [pId]
)
ALTER TABLE [dbo].[apprelatorio_oUsuarios_usuario_oAppRelatorios] NOCHECK CONSTRAINT [FK_ape_pI2_pId_usu]
ALTER TABLE [dbo].[cadastro_oempresas_empresa_ocadastros] WITH NOCHECK ADD CONSTRAINT [FK_cas_pId_pId_cad] FOREIGN KEY (
 [pId]
) REFERENCES [dbo].[cadastro](

 [pId]
)
ALTER TABLE [dbo].[cadastro_oempresas_empresa_ocadastros] NOCHECK CONSTRAINT [FK_cas_pId_pId_cad]
ALTER TABLE [dbo].[cadastro_oempresas_empresa_ocadastros] WITH NOCHECK ADD CONSTRAINT [FK_cas_pI2_pId_emp] FOREIGN KEY (
 [pId2]
) REFERENCES [dbo].[empresa](

 [pId]
)
ALTER TABLE [dbo].[cadastro_oempresas_empresa_ocadastros] NOCHECK CONSTRAINT [FK_cas_pI2_pId_emp]
ALTER TABLE [dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros] WITH NOCHECK ADD CONSTRAINT [FK_cat_pId_pId_cad] FOREIGN KEY (
 [pId]
) REFERENCES [dbo].[cadastro](

 [pId]
)
ALTER TABLE [dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros] NOCHECK CONSTRAINT [FK_cat_pId_pId_cad]
ALTER TABLE [dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros] WITH NOCHECK ADD CONSTRAINT [FK_cat_pI2_pId_caa] FOREIGN KEY (
 [pId2]
) REFERENCES [dbo].[cadastrotipo](

 [pId]
)
ALTER TABLE [dbo].[cadastro_ocadastrostipo_cadastrotipo_ocadastros] NOCHECK CONSTRAINT [FK_cat_pI2_pId_caa]
ALTER TABLE [dbo].[empresa_osistemas_sistema_oempresas] WITH NOCHECK ADD CONSTRAINT [FK_emr_pId_pId_emp] FOREIGN KEY (
 [pId]
) REFERENCES [dbo].[empresa](

 [pId]
)
ALTER TABLE [dbo].[empresa_osistemas_sistema_oempresas] NOCHECK CONSTRAINT [FK_emr_pId_pId_emp]
ALTER TABLE [dbo].[empresa_osistemas_sistema_oempresas] WITH NOCHECK ADD CONSTRAINT [FK_emr_pI2_pId_sis] FOREIGN KEY (
 [pId2]
) REFERENCES [dbo].[sistema](

 [pId]
)
ALTER TABLE [dbo].[empresa_osistemas_sistema_oempresas] NOCHECK CONSTRAINT [FK_emr_pI2_pId_sis]
ALTER TABLE [dbo].[filial_ousuarios_usuario_ofiliais] WITH NOCHECK ADD CONSTRAINT [FK_fia_pId_pId_fil] FOREIGN KEY (
 [pId]
) REFERENCES [dbo].[filial](

 [pId]
)
ALTER TABLE [dbo].[filial_ousuarios_usuario_ofiliais] NOCHECK CONSTRAINT [FK_fia_pId_pId_fil]
ALTER TABLE [dbo].[filial_ousuarios_usuario_ofiliais] WITH NOCHECK ADD CONSTRAINT [FK_fia_pI2_pId_usu] FOREIGN KEY (
 [pId2]
) REFERENCES [dbo].[usuario](

 [pId]
)
ALTER TABLE [dbo].[filial_ousuarios_usuario_ofiliais] NOCHECK CONSTRAINT [FK_fia_pI2_pId_usu]
ALTER TABLE [dbo].[IdRole_Users_IdUser_Roles] WITH NOCHECK ADD CONSTRAINT [FK_Idl_Id_Id_IdR] FOREIGN KEY (
 [Id]
) REFERENCES [dbo].[IdRole](

 [Id]
)
ALTER TABLE [dbo].[IdRole_Users_IdUser_Roles] NOCHECK CONSTRAINT [FK_Idl_Id_Id_IdR]
ALTER TABLE [dbo].[IdRole_Users_IdUser_Roles] WITH NOCHECK ADD CONSTRAINT [FK_Idl_Id2_Id_IdU] FOREIGN KEY (
 [Id2]
) REFERENCES [dbo].[IdUser](

 [Id]
)
ALTER TABLE [dbo].[IdRole_Users_IdUser_Roles] NOCHECK CONSTRAINT [FK_Idl_Id2_Id_IdU]
