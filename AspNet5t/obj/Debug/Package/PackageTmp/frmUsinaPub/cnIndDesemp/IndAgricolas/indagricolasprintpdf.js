﻿$(function () {
    Date.prototype.ddmmyyyy = function () {
        var yyyy = this.getFullYear().toString();
        var mm = (this.getMonth() + 1).toString(); // getMonth() is zero-based
        var dd = this.getDate().toString();
        var hh = this.getHours().toString();
        var mmm = this.getMinutes().toString();
        return (dd[1] ? dd : "0" + dd[0]) + '/' + (mm[1] ? mm : "0" + mm[0]) + '/' + yyyy; // padding
    };


    var openTrTdColspan8 = '<tr class="dxgvDataRow_Office2010Silver"><td colspan=8 class="dxgv" style="padding-top:0px;padding-bottom:0px;padding-left:0px;padding-right:0px;">';
    var closeTrTdColspan8 = '</td></tr>';

    var imgLogoSource = ResolveUrl('~/Content/Images/LogoUAMpequeno.png');

    var txtGrupo = hf.Get("hfGrupo");
    var txtDataFechamento = new Date(hf.Get("hfDataFechamento")).ddmmyyyy();
    var txtTempoAprov = hf.Get("hfTempoAprov");

    var trHeader = '<table class="dxflGroup dxflGroupSys dxflAGSys" cellspacing="0" cellpadding="0" style="border-collapse:collapse;border-collapse:separate;">  			<tbody>  				  <tr>  				<td id="ASPxCbPanel_ASPxFormLayout1_0" class="dxflHALSys dxflGroupCell"><div class="dxflCLTSys dxflItemSys dxflTextItemSys dxflItem" style="width:100px;">  					                                              <img src="' + imgLogoSource + '">                                            				</div></td><td id="ASPxCbPanel_ASPxFormLayout1_1" class="dxflHALSys dxflGroupCell"><table class="dxflCLTSys dxflItemSys dxflCustomItemSys dxflItem" cellspacing="0" cellpadding="0" style="width:500px;border-collapse:collapse;border-collapse:separate;">  					<tbody><tr>  						<td class="dxflHALSys dxflVATSys dxflCaptionCell dxflCaptionCellSys" style="width:1px;"><span class="dxflCaption">Grupo:</span></td>  					</tr><tr>  						<td class="dxflNestedControlCell">                                              <span id="ASPxCbPanel_ASPxFormLayout1_txtGrupo" class="parametros" style="display:inline-block;width:200px;">' + txtGrupo + '</span>                                          </td>  					</tr>  				</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_2" class="dxflGroupCell"><table class="dxflCLTSys dxflItemSys dxflCustomItemSys dxflItem" cellspacing="0" cellpadding="0" style="width:100px;border-collapse:collapse;border-collapse:separate;">  					<tbody><tr>  						<td class="dxflHACSys dxflVATSys dxflCaptionCell dxflCaptionCellSys"><span class="dxflCaption">Data Fechamento:</span></td>  					</tr><tr>  						<td class="dxflNestedControlCell">                                              <span id="ASPxCbPanel_ASPxFormLayout1_txtDataFechamento" class="parametros" style="display:inline-block;width:100px;">' + txtDataFechamento + '</span>                                          </td>  					</tr>  				</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_3" class="dxflHACSys dxflGroupCell"><table class="dxflCLTSys dxflItemSys dxflCustomItemSys dxflItem" cellspacing="0" cellpadding="0" style="width:100px;border-collapse:collapse;border-collapse:separate;">  					<tbody><tr>  						<td class="dxflHACSys dxflVATSys dxflCaptionCell dxflCaptionCellSys" style="width:1px;"><span class="dxflCaption">Tempo Aproveit. Industrial:</span></td>  					</tr><tr>  						<td class="dxflNestedControlCell">                                              <div style="width: 100px; text-align: center;">                                                  <span id="ASPxCbPanel_ASPxFormLayout1_txtTempoAprov" class="parametros">' + txtTempoAprov + '</span>                                              </div>                                          </td>  					</tr>  				</tbody></table></td>  			</tr>  			  </tbody>  </table>';
    var tableTituloIndicadores = '<table id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_DXTitle" cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  								<tbody><tr>  									<td class="dxgvTitlePanel_Office2010Silver" style="font-size:Medium;">Indicadores Agrícolas</td>  								</tr>  							</tbody></table>';
    var tableHeaderColumns = '<table id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_DXMainTable" class="dxgvTable_Office2010Silver" cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;empty-cells:show;">  <tbody>  <tr id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_DXHeadersRow0">  									<td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col2" class="dxgvHeader_Office2010Silver dx-wrap" style="width:120px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Indicador</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span><img class="dxGridView_gvHeaderSortUp_Office2010Silver dx-vam" src="/DXR.axd?r=1_37-yqIbc" alt="(Crescente)" style="margin-left:5px;"></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col3" class="dxgvHeader_Office2010Silver dx-wrap" style="width:115px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Frente / Tipo</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span><img class="dxGridView_gvHeaderSortUp_Office2010Silver dx-vam" src="/DXR.axd?r=1_37-yqIbc" alt="(Crescente)" style="margin-left:5px;"></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col7" class="dxgvHeader_Office2010Silver dx-wrap" style="width:80px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Planejado</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col8" class="dxgvHeader_Office2010Silver dx-wrap" style="width:80px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Realizado</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col9" class="dxgvHeader_Office2010Silver dx-wrap" style="width:85px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Unidade Medida</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col14" class="dxgvHeader_Office2010Silver dx-wrap" style="width:70px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap"> </td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col10" class="dxgvHeader_Office2010Silver dx-wrap" style="width:65px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Status</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col11" class="dxgvHeader_Office2010Silver dx-wrap" style="width:285px;border-top-width:0px;border-left-width:0px;cursor:default;border-right-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap"> </td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td>  								</tr>  </tbody>  </table>';
    var tableHeaderColumnsAjust = '<table id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_DXMainTable" class="dxgvTable_Office2010Silver" cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;empty-cells:show;">  <tbody>  <tr id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_DXHeadersRow0">  									<td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col2" class="dxgvHeader_Office2010Silver dx-wrap" style="width:115px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Indicador</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span><img class="dxGridView_gvHeaderSortUp_Office2010Silver dx-vam" src="/DXR.axd?r=1_37-yqIbc" alt="(Crescente)" style="margin-left:5px;"></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col3" class="dxgvHeader_Office2010Silver dx-wrap" style="width:111px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Frente / Tipo</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span><img class="dxGridView_gvHeaderSortUp_Office2010Silver dx-vam" src="/DXR.axd?r=1_37-yqIbc" alt="(Crescente)" style="margin-left:5px;"></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col7" class="dxgvHeader_Office2010Silver dx-wrap" style="width:74px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Planejado</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col8" class="dxgvHeader_Office2010Silver dx-wrap" style="width:74px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Realizado</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col9" class="dxgvHeader_Office2010Silver dx-wrap" style="width:79px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Unidade Medida</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col14" class="dxgvHeader_Office2010Silver dx-wrap" style="width:69px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap"> </td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col10" class="dxgvHeader_Office2010Silver dx-wrap" style="width:60px;border-top-width:0px;border-left-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap">Status</td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td><td id="ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_col11" class="dxgvHeader_Office2010Silver dx-wrap" style="width:285px;border-top-width:0px;border-left-width:0px;cursor:default;border-right-width:0px;cursor:default;"><table cellspacing="0" cellpadding="0" style="width:100%;border-collapse:collapse;">  										<tbody><tr>  											<td class="dx-wrap"> </td><td style="width:1px;text-align:right;"><span class="dx-vam">&nbsp;</span></td>  										</tr>  									</tbody></table></td>  								</tr>  </tbody>  </table>';

    var pageRows = 16;
    var dataRowSelectorPrefix = '#ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_DXDataRow';

    //$('#ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_DXDataRow10').after(closeCurrentTr + openTrHeader + reopenCurrentTr).after('<div class="page-break">&nbsp;</div>');
    //$('#ASPxCbPanel_ASPxFormLayout1_ASPxGridView1_DXDataRow16').after(openTrTdColspan8 + trHeader + tableTituloIndicadores + tableHeaderColumnsAjust + closeTrTdColspan8).after('<div class="page-break">&nbsp;</div>');

    while ($(dataRowSelectorPrefix + pageRows).length) {
        //console.log($(dataRowSelectorPrefix + pageRows).length);
        $(dataRowSelectorPrefix + pageRows).after(openTrTdColspan8 + trHeader + tableTituloIndicadores + tableHeaderColumnsAjust + closeTrTdColspan8).after('<div class="page-break">&nbsp;</div>');
        pageRows += 16;
    };
});
