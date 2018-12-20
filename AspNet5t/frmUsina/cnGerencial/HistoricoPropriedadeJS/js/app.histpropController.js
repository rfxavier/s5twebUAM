/*! 
* Autor: Renato Ferreira Xavier
* Data: fevereiro/2016
* 4T Sistemas Inteligentes Ltda.
*/
(function () {
    "use strict";

    Date.prototype.ddmmyyyy = function () {
        var yyyy = this.getFullYear().toString();
        var mm = (this.getMonth() + 1).toString(); // getMonth() is zero-based
        var dd = this.getDate().toString();
        var hh = this.getHours().toString();
        var mmm = this.getMinutes().toString();
        return (dd[1] ? dd : "0" + dd[0]) + '/' + (mm[1] ? mm : "0" + mm[0]) + '/' + yyyy; // padding
    };

    function GetViewPortArray(longIni, latFin, longFin, latIni, viewPortX, viewPortY) {
        var deltaLong = longFin - longIni;
        var deltaLat = latFin - latIni;

        var centerLong = longIni + deltaLong / 2;
        var centerLat = latIni + deltaLat / 2;

        var ratio = Math.abs(deltaLong) / Math.abs(deltaLat);

        var ratioViewPort = viewPortX / viewPortY;

        if (ratio < ratioViewPort) {
            //muda as longitudes
            var newDeltaLong = Math.abs(deltaLat) * ratioViewPort;

            var newLongIni = centerLong - newDeltaLong / 2;
            var newLongFin = centerLong + newDeltaLong / 2;

            var viewPortArray = [newLongIni, latFin, newLongFin, latIni];
        } else {
            //muda as latitudes
            var newDeltaLat = Math.abs(deltaLong) * ratioViewPort;

            var newLatIni = centerLat - newDeltaLat / 2;
            var newLatFin = centerLat + newDeltaLat / 2;

            var viewPortArray = [longIni, newLatFin, longFin, newLatIni];
        };

        return viewPortArray;
    };

    //#region colorsArray
    //                  blue       orange     green      pink       brown      purple     yellow     red
    var colorsArray = ['#5da5da', '#faa43a', '#60bd68', '#f17cb0', '#b2912f', '#b276b2', '#decf3f', '#f15854'];

    //                          green      yellow     blue       orange     pink       brown      purple     red
    var colorsArrayAmbiente = ['#60bd68', '#decf3f', '#5da5da', '#faa43a', '#f17cb0', '#b2912f', '#b276b2', '#f15854'];

    //                           orange     blue       green      yellow     blue       pink       brown      purple     red
    var colorsArrayMaturacao = ['#faa43a', '#5da5da', '#60bd68', '#decf3f', '#f17cb0', '#b2912f', '#b276b2', '#f15854'];

    //                           purple     brown      orange     green      yellow     blue       pink       red       grn.ylw    lgt.cyan   khaki      drk.cyan   drk.turq   drk.grey   drk.green  drk.blue   drk.red
    var colorsArrayVariedade = ['#b276b2', '#b2912f', '#faa43a', '#60bd68', '#decf3f', '#5da5da', '#f17cb0', '#f15854', '#adff2f', '#e0ffff', '#f0e68c', '#008b8b', '#00ced1', '#2f4f4f', '#006400', '#00008b', '#8b0000',];

    //                       pink       orange     purple     brown      green      red        yellow     blue       
    var colorsArrayCorte = ['#f17cb0', '#faa43a', '#b276b2', '#b2912f', '#60bd68', '#f15854', '#decf3f', '#5da5da'];
    //#endregion colorsArray

    angular.module('app4T')
        .controller("historicoProdutivCtrl", ['$scope', '$document', 'ApiGetService', historicoProdutivCtrl])
    
    function historicoProdutivCtrl($scope, $document, ApiGetService) {
        //#region $scope empty object declarations

        //Safra Atual - primitive type - sem ser o selboxSafraAtual que é object
        $scope.numeroSafraAtual = null;

        //dxSelectBox Safra
        $scope.selboxSafraAtual = null;
        $scope.selboxSafraOptions = {};
        $scope.selboxSafraInstance = null;
        $scope.safrasArray = {};

        //dxLookup Propriedade
        $scope.lookupPropriedadeAtual = null;
        $scope.lookupPropOptions = {};
        $scope.lookupPropInstance = null;
        $scope.propriedadesArray = {};

        //dxVectorMap Mapa Propriedade
        $scope.mapaPropriedadeOptions = {};
        $scope.mapaPropriedadeInstance = null;

        //Dados "parseados" do .SHP e .DBF, que entrarão no layers.data do dxVectorMap
        $scope.mapaPropLayerData = {};

        //Objeto principal da Api gethistoricopropriedadePromise
        $scope.histprodArray = {};

        //Demais objetos filhos atrelados a histprodArray
        $scope.histprodAmbientesArray = {};
        $scope.histprodMaturacoesArray = {};
        $scope.histprodVariedadesArray = {};
        $scope.histprodCortesArray = {};
        $scope.histprodPlantiosArray = {};
        $scope.histprodProducaoTonsHaArray = {};
        $scope.histprodProducaoCanasEntreguesArray = {};
        $scope.histprodProducaoResumoAmbientesArray = {};
        $scope.histprodTratosCulturaisArray = {};
        $scope.histprodNaoConformidadesArray = {};
        $scope.histprodDiagnosticoColheitaArray = {};

        //Datasources de dxSelectBoxes, dxDataGrids e Custom store do dxPivot
        $scope.selboxSafrasDataSource = {};
        $scope.gridAmbientesDataSource = {};
        $scope.gridMaturacoesDataSource = {};
        $scope.gridVariedadesDataSource = {};
        $scope.gridCortesDataSource = {};
        $scope.pivotPlantiosStore = {};
        $scope.gridProducaoTonsHaDataSource = {};
        $scope.gridProducaoCanasEntreguesDataSource = {};
        $scope.gridProducaoResumoAmbientesDataSource = {};
        $scope.gridTratosCulturaisDataSource = {};
        $scope.selboxSubGruposAgricolasDataSource = {};
        $scope.gridNaoConformidadesDataSource = {};
        $scope.gridDiagnosticoColheitaDataSource = {};

        //Configurações de dxDataGrids e dxPivot
        $scope.gridAmbientesOptions = {};
        $scope.gridMaturacoesOptions = {};
        $scope.gridVariedadesOptions = {};
        $scope.gridCortesOptions = {};
        $scope.pivotPlantiosOptions = {};
        $scope.gridProducaoTonsHaOptions = {};
        $scope.gridProducaoCanasEntreguesOptions = {};
        $scope.gridProducaoResumoAmbientesOptions = {};
        $scope.gridTratosCulturaisOptions = {};
        $scope.gridNaoConformidadesOptions = {};

        //Instância de dxDataGrids e dxPivot
        $scope.gridAmbientesInstance = null;
        $scope.gridMaturacoesInstance = null;
        $scope.gridVariedadesInstance = null;
        $scope.gridCortesInstance = null;
        $scope.pivotPlantiosInstance = null;
        $scope.gridProducaoTonsHaInstance = null;
        $scope.gridProducaoCanasEntreguesInstance = null;
        $scope.gridProducaoResumoAmbientesInstance = null;
        $scope.gridTratosCulturaisInstance = null;
        $scope.gridTratosCulturaisTalhoesInstance = null;
        $scope.gridNaoConformidadesInstance = null;

        //Eventos click nos dxDataGrids
        $scope.onGridAmbientesCellClick = {};
        $scope.onGridMaturacoesCellClick = {};
        $scope.onGridVariedadesCellClick = {};
        $scope.onGridCortesCellClick = {};

        //Inicializa dxLookup Propriedades DataSource
        //No then após GetPropriedadesPromise é preenchida com .store().insert
        $scope.lookupPropDataSource = new DevExpress.data.DataSource([]);

        //dxSelectBox filtro subgrupos agrícolas
        $scope.selboxSubGruposAgricolasOptions = {};
        $scope.selboxSubGrupoAgricolaAtual = null;
        $scope.subgruposagricolasArray = {};
        $scope.selboxSubGrupoAgricolaInstance = null;

        //#endregion $scope empty object declarations

        $scope.resetPropriedade = function () {
            $scope.lookupPropriedadeAtual = null;
            $scope.nomePropriedadeAtual = null;
            $scope.nomePropriedadeAtualDisplay = null;

            $scope.selboxSubGrupoAgricolaAtual = 0;
            $scope.gridTratosCulturaisDataSource.filter(null);

            $scope.selboxSubGruposAgricolasDataSource.load();
        };

        function ParseMapaPropriedade(safra, codprop) {
            var codprop4Digitos = ("0000" + codprop).slice(-4);

            //** Fixo safra = 2016, para sempre encontrar mapa
            //DevExpress.viz.vectormaputils.parse(ResolveUrl('~/frmUsina/cnGerencial/mapasProp/' + safra + '/P' + codprop4Digitos + '/P' + codprop4Digitos), { precision: 8 }, function (data) {
            DevExpress.viz.vectormaputils.parse(ResolveUrl('~/frmUsina/cnGerencial/mapasProp/2016' + '/P' + codprop4Digitos + '/P' + codprop4Digitos), { precision: 8 }, function (data) {
                //console.log(data);
                $scope.mapaPropLayerData = data;

                $scope.mapaPropriedadeInstance.option({
                    layers: [{
                        type: 'area',
                        data: $scope.mapaPropLayerData,
                        label: {
                            enabled: true,
                            dataField: 'TALH_CODIG',
                            font: {
                                color: 'black',
                                opacity: 1,
                                weight: 100,
                                size: 10
                            }
                        }
                    }],
                    //bounds: [$scope.mapaPropLayerData.bbox[0], $scope.mapaPropLayerData.bbox[1], $scope.mapaPropLayerData.bbox[2], $scope.mapaPropLayerData.bbox[3]],
                    //bounds: [-47.73450155, -20.48307060, -47.6948768, -20.44910658],
                    bounds: GetViewPortArray($scope.mapaPropLayerData.bbox[0], $scope.mapaPropLayerData.bbox[1], $scope.mapaPropLayerData.bbox[2], $scope.mapaPropLayerData.bbox[3], 280, 240),
                    maxZoomFactor: 6,
                    tooltip: {
                        enabled: true,
                        customizeTooltip: function (arg) {
                            //Ambientes
                            var mapaPropAmbienteTalhoesArray = convertObjAmbientesToArrayTalhoes($scope.gridAmbientesInstance.option('dataSource').items());
                            var mapaPropAmbienteTalhoesDtColheitaArray = convertObjAmbientesToArrayTalhoesDtColheita($scope.gridAmbientesInstance.option('dataSource').items());
                            var mapaPropAmbienteTalhoesReformaArray = convertObjAmbientesToArrayTalhoesReforma($scope.gridAmbientesInstance.option('dataSource').items());
                            var mapaPropAmbienteTalhoesUltCorteMudaArray = convertObjAmbientesToArrayTalhoesUltCorteMuda($scope.gridAmbientesInstance.option('dataSource').items());
                            var mapaPropAmbienteTalhoesNomeArray = convertObjAmbientesToArrayAmbienteTalhoesNomeAmbiente($scope.gridAmbientesInstance.option('dataSource').items());

                            var posAmbiente = $.inArray(arg.attribute('TALH_CODIG'), mapaPropAmbienteTalhoesArray);

                            //Maturações
                            var mapaPropMaturacaoTalhoesArray = convertObjMaturacoesToArrayTalhoes($scope.gridMaturacoesInstance.option('dataSource').items());
                            var mapaPropMaturacaoTalhoesNomeArray = convertObjMaturacoesToArrayMaturacaoTalhoesNomeMaturacao($scope.gridMaturacoesInstance.option('dataSource').items());

                            var posMaturacao = $.inArray(arg.attribute('TALH_CODIG'), mapaPropMaturacaoTalhoesArray);

                            //Variedades
                            var mapaPropVariedadeTalhoesArray = convertObjVariedadesToArrayTalhoes($scope.gridVariedadesInstance.option('dataSource').items());
                            var mapaPropVariedadeTalhoesNomeArray = convertObjVariedadesToArrayVariedadeTalhoesNomeVariedade($scope.gridVariedadesInstance.option('dataSource').items());

                            var posVariedade = $.inArray(arg.attribute('TALH_CODIG'), mapaPropVariedadeTalhoesArray);

                            //Cortes
                            var mapaPropCorteTalhoesArray = convertObjCortesToArrayTalhoes($scope.gridCortesInstance.option('dataSource').items());
                            var mapaPropCorteTalhoesNomeArray = convertObjCortesToArrayCorteTalhoesNomeCorte($scope.gridCortesInstance.option('dataSource').items());

                            var posCorte = $.inArray(arg.attribute('TALH_CODIG'), mapaPropCorteTalhoesArray);

                            var displayAmbiente = mapaPropAmbienteTalhoesNomeArray[posAmbiente] || "Não Informado";
                            var displayMaturacao = mapaPropMaturacaoTalhoesNomeArray[posMaturacao] || "Não Informado";
                            var displayVariedade = mapaPropVariedadeTalhoesNomeArray[posVariedade] || "Não Informado";
                            var displayCorte = mapaPropCorteTalhoesNomeArray[posCorte] || "Não Informado";
                            
                            //Tratamento de tooltip Última Colheita
                            if (mapaPropAmbienteTalhoesDtColheitaArray[posAmbiente]) {
                                var infoDtColheita = mapaPropAmbienteTalhoesDtColheitaArray[posAmbiente];
    
                                var displayDtColheita = new Date(infoDtColheita).ddmmyyyy()

                                if (displayDtColheita == '01/01/1') {
                                    displayDtColheita = 'Não Informado';
                                };
                            } else {
                                var displayDtColheita = "Não Informado";
                            };

                            //Tratamento de tooltip Reforma
                            if (mapaPropAmbienteTalhoesReformaArray[posAmbiente]) {
                                var infoReforma = mapaPropAmbienteTalhoesReformaArray[posAmbiente];
    
                                var displayReforma = infoReforma;
                            } else {
                                var displayReforma = "";
                            };

                            //Tratamento de tooltip Último Corte Muda
                            if (mapaPropAmbienteTalhoesUltCorteMudaArray[posAmbiente]) {
                                var infoUltCorteMuda = mapaPropAmbienteTalhoesUltCorteMudaArray[posAmbiente];
    
                                var displayUltCorteMuda = new Date(infoUltCorteMuda).ddmmyyyy()

                                if (displayUltCorteMuda == '01/01/1') {
                                    displayUltCorteMuda = 'Não Informado';
                                };
                            } else {
                                var displayUltCorteMuda = "Não Informado";
                            };

                            var node = $("<div>")
                                .append("<b>" + arg.attribute("TALH_CODIG") + "</b>")
                                .append("<div>" + 'Ambiente: ' + displayAmbiente + "</div>")
                                .append("<div>" + 'Maturação: ' + displayMaturacao + "</div>")
                                .append("<div>" + 'Variedade: ' + displayVariedade + "</div>")
                                .append("<div>" + 'Corte: ' + displayCorte + "</div>");

                            if (displayDtColheita !== 'Não Informado') {
                                var node = node.append("<div>" + 'Última Colheita: ' + displayDtColheita + "</div>");
                            };

                            if (displayReforma !== '') {
                                var node = node.append("<div>" + 'Reforma: ' + displayReforma + "</div>");
                            };

                            if (displayUltCorteMuda !== 'Não Informado') {
                                var node = node.append("<div>" + 'Último Corte Muda: ' + displayUltCorteMuda + "</div>");
                            };
                            
                            return {
                                html: node.html()
                            };
                        }
                    }
                });
            });

        };

        function GetPropriedadesPromise(safra) {
            //$scope.lookupPropInstance.option({ visible: 'false' });

            var promise = new Promise(function (resolve, reject) {

                ApiGetService
                    .getpropriedadesPromise(safra)
                    .then(function (data) {
                        $scope.propriedadesArray = data;
                        $scope.lookupPropDataSource.store().clear();

                        for (var i = 0; i < data.length; i++) {
                            var propDisp;

                            if (data[i].DT_ENCERRAMENTO == "") {
                                propDisp = ' (' + data[i].DSC_PROPRIEDADE + ')';
                            } else {
                                propDisp = ' (' + data[i].DSC_PROPRIEDADE + ' - ' + data[i].DT_ENCERRAMENTO + ')';
                            };

                            $scope.lookupPropDataSource.store().insert($.extend(data[i], {
                                COD_PROPRIEDADE_PADL: ("0000" + data[i].COD_PROPRIEDADE).slice(-4),
                                DSC_PROPRIEDADE_DISP: propDisp}));
                        };

                        //$scope.lookupPropDataSource.sort({ field: "COD_PROPRIEDADE_PADL", desc: false });
                        $scope.lookupPropDataSource.load();

                        //$scope.lookupPropInstance.option({ visible: 'true' });

                        resolve();
                    });

            });

            return promise;
        };

        function GetHistoricoPropriedadePromise(safra, codprop) {
            ApiGetService
                .gethistoricopropriedadePromise(safra, codprop)
                .then(function (data) {
                    $scope.histprodArray = data;
                    $scope.histprodAmbientesArray = data.oAmbientes;
                    $scope.histprodMaturacoesArray = data.oMaturacoes;
                    $scope.histprodVariedadesArray = data.oVariedades;
                    $scope.histprodCortesArray = data.oCortes;
                    $scope.histprodPlantiosArray = data.oPlantios;
                    $scope.histprodProducaoTonsHaArray = data.oProducaoTonsHa;
                    $scope.histprodProducaoCanasEntreguesArray = data.oProducaoCanasEntregues;
                    $scope.histprodProducaoResumoAmbientesArray = data.oProducaoResumoAmbientes;
                    $scope.histprodTratosCulturaisArray = data.oTratosCulturais;
                    $scope.histprodNaoConformidadesArray = data.oNaoConformidades;
                    $scope.histprodDiagnosticoColheitaArray = data.oDiagnosticoColheita;

                    $scope.gridAmbientesInstance.refresh();
                    $scope.gridMaturacoesInstance.refresh();
                    $scope.gridVariedadesInstance.refresh();
                    $scope.gridCortesInstance.refresh();

                    if ($scope.histprodVariedadesArray.length > 8) {
                        $scope.gridVariedadesInstance.option({ height: 242 });
                    } else {
                        $scope.gridVariedadesInstance.option({ height: undefined });
                    };

                    $scope.pivotPlantiosInstance.getDataSource().reload();

                    //$scope.gridTratosCulturaisTalhoesInstance só dispara o onInitialized ao abrir a aba Tratos Culturais
                    //motivo: gridTratosCulturaisTalhoes está dentro de um dxTemplate
                    //$scope.gridTratosCulturaisInstance.refresh();
                    //$scope.gridTratosCulturaisTalhoesInstance.refresh();
                });
        };

        angular.element(document).ready(function () {
            //ORDEM: 2 - Document Ready Angular

            Globalize.culture("pt-BR");

            ApiGetService
                .getsafrasPromise()
                .then(function (data) {
                    $scope.safrasArray = data;

                    $scope.selboxSafrasDataSource.load();
                    $scope.selboxSafraAtual = { SAFRA: new Date().getFullYear() };
                    //$scope.selboxSafraInstance.option({value: '2016'});

                    //VARIÁVEL $scope.selboxSafraAtual being $watched, dispara GetPropriedadesPromise
                });

            ApiGetService
                .getsubgruposagricolasPromise()
                .then(function (data) {
                    $scope.subgruposagricolasArray = data;
                    $scope.selboxSubGruposAgricolasDataSource.store().clear();

                    $scope.selboxSubGruposAgricolasDataSource.store().insert({ ID_GRUPO: 0, DS_GRUPO: "** TODOS **" })

                    for (var i = 0; i < $scope.subgruposagricolasArray.length; i++) {
                        $scope.selboxSubGruposAgricolasDataSource.store().insert(data[i]);
                    };

                    $scope.selboxSubGruposAgricolasDataSource.load();


                    //$scope.selboxSubGruposAgricolasDataSource.load();
                    //$scope.selboxSubGrupoAgricolaAtual = { SAFRA: new Date().getFullYear() };

                    //?????? VARIÁVEL $scope.selboxSafraAtual being $watched, dispara GetPropriedadesPromise
                });

        });

        //#region $watches $scope.selboxSafraAtual e $scope.lookupPropriedadeAtual
        $scope.$watch('selboxSafraAtual', function () {
            if ($scope.selboxSafraAtual) {
                $scope.lookupPropriedadeAtual = null;
                $scope.nomePropriedadeAtual = null;
                $scope.nomePropriedadeAtualDisplay = null;
                $scope.numeroSafraAtual = $scope.selboxSafraAtual.SAFRA;
                $scope.lookupPropInstance.option({ disabled: true, placeholder: 'Aguarde. Carregando...' });
                GetPropriedadesPromise($scope.selboxSafraAtual.SAFRA)
                    .then(function () {
                        $scope.lookupPropInstance.option({ disabled: false, placeholder: 'Selecione uma propriedade' });
                    });
            };
        });

        $scope.$watch('lookupPropriedadeAtual', function () {
            if ($scope.lookupPropriedadeAtual) {
                var objPropriedade = $scope.propriedadesArray.filter(function (obj) {
                    return obj.COD_PROPRIEDADE == $scope.lookupPropriedadeAtual;
                });

                $scope.nomePropriedadeAtual = objPropriedade && objPropriedade[0].DSC_PROPRIEDADE;
                $scope.nomePropriedadeAtualDisplay = 'Propriedade ' + $scope.lookupPropriedadeAtual + ' - ' + $scope.nomePropriedadeAtual
                ParseMapaPropriedade($scope.selboxSafraAtual.SAFRA, $scope.lookupPropriedadeAtual);
                GetHistoricoPropriedadePromise($scope.selboxSafraAtual.SAFRA, $scope.lookupPropriedadeAtual);
            };
        });

        //$scope.$watch('selboxSubGrupoAgricolaAtual'), function () {
        //    if ($scope.selboxSubGrupoAgricolaAtual) {
        //        $scope.gridTratosCulturaisDataSource.filter(["GRUPO_SUBGRUPO_AGR", "=", $scope.selboxSubGrupoAgricolaAtual]);
        //        //$scope.lookupPropDataSource.sort({ field: "COD_PROPRIEDADE_PADL", desc: false });

        //        $scope.gridTratosCulturaisDataSource.load();
        //    };
        //};
        //#endregion $watches $scope.selboxSafraAtual e $scope.lookupPropriedadeAtual

        //#region selboxSafraDataSource new DevExpress.data.DataSource
        $scope.selboxSafrasDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                deferred.resolve($scope.safrasArray);

                return deferred.promise();
            },
            byKey: function (key) {
                return key;
            }
        });
        //#endregion selboxSafraDataSource new DevExpress.data.DataSource
            
        //#region gridDataSources = new DevExpress.data.DataSource | pivotPlantioCustomStore = new DevExpress.data.CustomStore
        $scope.gridAmbientesDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.histprodAmbientesArray, { totalCount: $scope.histprodAmbientesArray.length });
                else
                    deferred.resolve($scope.histprodAmbientesArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();
                
                deferred.resolve($scope.histprodAmbientesArray.length);

                return deferred.promise();
            }
        });

        $scope.gridMaturacoesDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.histprodMaturacoesArray, { totalCount: $scope.histprodMaturacoesArray.length });
                else
                    deferred.resolve($scope.histprodMaturacoesArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.histprodMaturacoesArray.length);

                return deferred.promise();
            }
        });

        $scope.gridVariedadesDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.histprodVariedadesArray, { totalCount: $scope.histprodVariedadesArray.length });
                else
                    deferred.resolve($scope.histprodVariedadesArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.histprodVariedadesArray.length);

                return deferred.promise();
            }
        });

        $scope.gridCortesDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.histprodCortesArray, { totalCount: $scope.histprodCortesArray.length });
                else
                    deferred.resolve($scope.histprodCortesArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.histprodCortesArray.length);

                return deferred.promise();
            }
        });

        $scope.pivotPlantiosStore = new DevExpress.data.CustomStore({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                deferred.resolve($scope.histprodPlantiosArray);

                return deferred.promise();
            }
        });

        $scope.gridProducaoTonsHaDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.histprodProducaoTonsHaArray, { totalCount: $scope.histprodProducaoTonsHaArray.length });
                else
                    deferred.resolve($scope.histprodProducaoTonsHaArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.histprodProducaoTonsHaArray.length);

                return deferred.promise();
            }
        });

        $scope.gridProducaoCanasEntreguesDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.histprodProducaoCanasEntreguesArray, { totalCount: $scope.histprodProducaoCanasEntreguesArray.length });
                else
                    deferred.resolve($scope.histprodProducaoCanasEntreguesArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.histprodProducaoCanasEntreguesArray.length);

                return deferred.promise();
            }
        });

        $scope.gridProducaoResumoAmbientesDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.histprodProducaoResumoAmbientesArray, { totalCount: $scope.histprodProducaoResumoAmbientesArray.length });
                else
                    deferred.resolve($scope.histprodProducaoResumoAmbientesArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.histprodProducaoResumoAmbientesArray.length);

                return deferred.promise();
            }
        });

        $scope.gridTratosCulturaisDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.filter) {
                    var histprodTratosCulturaisArrayProc = $scope.histprodTratosCulturaisArray.filter(function (element) {
                        return (element.ID_GRUPO == loadOptions.filter[1]);
                    });
                } else {
                    var histprodTratosCulturaisArrayProc = $scope.histprodTratosCulturaisArray;
                };

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve(histprodTratosCulturaisArrayProc, { totalCount: histprodTratosCulturaisArrayProc.length });
                else
                    deferred.resolve(histprodTratosCulturaisArrayProc);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.histprodTratosCulturaisArray.length);

                return deferred.promise();
            }
        });

        $scope.gridNaoConformidadesDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.histprodNaoConformidadesArray, { totalCount: $scope.histprodNaoConformidadesArray.length });
                else
                    deferred.resolve($scope.histprodNaoConformidadesArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.histprodNaoConformidadesArray.length);

                return deferred.promise();
            }
        });

        $scope.gridDiagnosticoColheitaDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.histprodDiagnosticoColheitaArray, { totalCount: $scope.histprodDiagnosticoColheitaArray.length });
                else
                    deferred.resolve($scope.histprodDiagnosticoColheitaArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.histprodDiagnosticoColheitaArray.length);

                return deferred.promise();
            }
        });
        //#endregion gridDataSources = new DevExpress.data.DataSource | pivotPlantioCustomStore = new DevExpress.data.CustomStore

        //#region selboxSubGruposAgricolasDataSource new DevExpress.data.DataSource

        $scope.selboxSubGruposAgricolasDataSource = new DevExpress.data.DataSource([]);

        //$scope.selboxSubGruposAgricolasDataSource = new DevExpress.data.DataSource({
        //    load: function (loadOptions) {
        //        var deferred = $.Deferred();

        //        deferred.resolve($scope.subgruposagricolasArray);

        //        return deferred.promise();
        //    },
        //    byKey: function (key) {
        //        return key;
        //    }
        //});
        //#endregion selboxSafraDataSource new DevExpress.data.DataSource


        //#region LIST SAFRAS Options
        $scope.processSelBoxSafraValueChange = function (e) {
            //console.log(e.value.SAFRA);
        };

        $scope.selboxSafraOptions = {
            dataSource: $scope.selboxSafrasDataSource,
            displayExpr: 'SAFRA',
            bindingOptions: { value: 'selboxSafraAtual' },
            width: '100px',
            noDataText: 'Não há dados',
            placeholder: 'Selecione a safra',
            //onValueChanged: $scope.processSelBoxSafraValueChange,
            onInitialized: function (e) {
                $scope.selboxSafraInstance = e.component;
                e.element.css('font-size', '24px');
            }
        };
        //#endregion LIST SAFRAS Options

        //#region LOOKUP PROPRIEDADES Options
        $scope.currLookupPropDisplayExpr = "DSC_PROPRIEDADE";

        $scope.lookupPropOptions = {
            dataSource: $scope.lookupPropDataSource,
            bindingOptions: { value: 'lookupPropriedadeAtual', itemTemplate: 'currentTemplate' },
            displayExpr: 'COD_PROPRIEDADE_PADL',
            valueExpr: 'COD_PROPRIEDADE',
            width: '420px',
            showDoneButton: true,
            showDataBeforeSearch: false,
            placeholder: 'Aguarde. Carregando...',
            cancelButtonText: 'Cancelar',
            clearButtonText: 'Limpar',
            noDataText: 'Nenhuma propriedade',
            pageLoadingText: 'Aguarde...',
            refreshingText: 'Atualizando...',
            searchPlaceholder: 'Pesquisar',
            nextButtonText: 'Mais',
            //showClearButton: true,
            showPopupTitle: false,
            onInitialized: function (e) {
                $scope.lookupPropInstance = e.component;
                e.element.css('font-size', '24px');
                e.element.css('height', '42px');
            },
            disabled: true
        };
        //#endregion LOOKUP PROPRIEDADES Options

        $scope.currentTemplate = "item";

        //#region SWITCH PESQUISA Options
        $scope.switchPesquisaOptions = {
            onText: 'NOME',
            offText: 'CÓDIGO',
            width: '160px',
            height: '36px',
            onValueChanged: function (e) {
                $scope.currentTemplate = e.value ? "codigo" : "item";
                if (!e.value) {
                    $scope.lookupPropDataSource.sort({ field: "COD_PROPRIEDADE_PADL", desc: false });
                    $scope.lookupPropInstance.option({ displayExpr: 'COD_PROPRIEDADE_PADL', searchMode: 'contains' });
                    $scope.lookupPropDataSource.reload();
                } else {
                    $scope.lookupPropDataSource.sort({ field: "DSC_PROPRIEDADE", desc: false });
                    $scope.lookupPropInstance.option({ displayExpr: 'DSC_PROPRIEDADE', searchMode: 'contains' });
                    $scope.lookupPropDataSource.reload();
                };
            },
            onInitialized: function (e) {
            }

        };
        //#endregion SWITCH PESQUISA Options

        //#region VECTORMAP PROPRIEDADES Options
        //ORDEM: 1 - onInitialized dos $scope....Options
        $scope.mapaPropriedadeOptions = {
            onInitialized: function (e) {
                $scope.mapaPropriedadeInstance = e.component;
            }
        };
        //#endregion VECTORMAP PROPRIEDADES Options

        //#region GRID AMBIENTES CellClick e Options
        //$scope.onGridAmbientesCellClick
        //$scope.gridAmbientesOptions
        $scope.onGridAmbientesCellClick = function (clickedCell) {
            var mapaPropTalhoesArray = convertObjAmbientesToArrayTalhoes($scope.gridAmbientesInstance.option('dataSource').items());
            var mapaPropAmbienteTalhoesArray = convertObjAmbientesToArrayAmbienteTalhoes($scope.gridAmbientesInstance.option('dataSource').items());

            var elements = $scope.mapaPropriedadeInstance.getLayerByIndex(0).getElements();

            for (var i in elements) {
                var pos = $.inArray(elements[i].attribute('TALH_CODIG'), mapaPropTalhoesArray);

                if (pos > -1) {
                    elements[i].applySettings({ color: colorsArrayAmbiente[mapaPropAmbienteTalhoesArray[pos]] });
                } else {
                    elements[i].applySettings({ color: '#d2d2d2' });
                }
            };

            coloreGridLegenda('gridAmbientes');
        };

        $scope.gridAmbientesOptions = {
            dataSource: $scope.gridAmbientesDataSource,
            width: 132,
            columns: [{
                dataField: "AMBIENTE",
                caption: "Ambiente",
                alignment: "center",
                width: 70
            }, {
                dataField: "AREA_TOTAL",
                caption: "Área",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 60
            }
            ],
            onInitialized: function (e) {
                $scope.gridAmbientesInstance = e.component;
            },
            onCellClick: $scope.onGridAmbientesCellClick,
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            },
            noDataText: '',
            wordWrapEnabled: true
        };
        //#endregion GRID AMBIENTES CellClick e Options

        //#region GRID MATURAÇÕES CellClick e Options
        //$scope.onGridMaturacoesCellClick
        //$scope.gridMaturacoesOptions
        $scope.onGridMaturacoesCellClick = function (clickedCell) {
            var mapaPropTalhoesArray = convertObjMaturacoesToArrayTalhoes($scope.gridMaturacoesInstance.option('dataSource').items());
            var mapaPropMaturacaoTalhoesArray = convertObjMaturacoesToArrayMaturacaoTalhoes($scope.gridMaturacoesInstance.option('dataSource').items());

            var elements = $scope.mapaPropriedadeInstance.getLayerByIndex(0).getElements();

            for (var i in elements) {
                var pos = $.inArray(elements[i].attribute('TALH_CODIG'), mapaPropTalhoesArray);

                if (pos > -1) {
                    elements[i].applySettings({ color: colorsArrayMaturacao[mapaPropMaturacaoTalhoesArray[pos]] });
                } else {
                    elements[i].applySettings({ color: '#d2d2d2' });
                }
            };

            coloreGridLegenda('gridMaturacoes');
        };

        $scope.gridMaturacoesOptions = {
            dataSource: $scope.gridMaturacoesDataSource,
            width: 137,
            columns: [{
                dataField: "MATURACAO",
                caption: "Maturação",
                alignment: "center",
                width: 85
            }, {
                dataField: "AREA_TOTAL",
                caption: "Área",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }
            ],
            onInitialized: function (e) {
                $scope.gridMaturacoesInstance = e.component;
            },
            onCellClick: $scope.onGridMaturacoesCellClick,
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            },
            noDataText: '',
            wordWrapEnabled: true
        };
        //#endregion GRID MATURAÇÕES CellClick e Options

        //#region GRID VARIEDADES CellClick e Options
        //$scope.onGridVariedadesCellClick
        //$scope.gridVariedadesOptions
        $scope.onGridVariedadesCellClick = function (clickedCell) {
            var mapaPropTalhoesArray = convertObjVariedadesToArrayTalhoes($scope.gridVariedadesInstance.option('dataSource').items());
            var mapaPropVariedadeTalhoesArray = convertObjVariedadesToArrayVariedadeTalhoes($scope.gridVariedadesInstance.option('dataSource').items());

            var elements = $scope.mapaPropriedadeInstance.getLayerByIndex(0).getElements();

            for (var i in elements) {
                var pos = $.inArray(elements[i].attribute('TALH_CODIG'), mapaPropTalhoesArray);

                if (pos > -1) {
                    elements[i].applySettings({ color: colorsArrayVariedade[mapaPropVariedadeTalhoesArray[pos]] });
                } else {
                    elements[i].applySettings({ color: '#d2d2d2' });
                }
            };

            coloreGridLegenda('gridVariedades');
        };

        $scope.gridVariedadesOptions = {
            dataSource: $scope.gridVariedadesDataSource,
            width: 142,
            columns: [{
                dataField: "VARIEDADE",
                caption: "Variedade",
                alignment: "center",
                width: 80
            }, {
                dataField: "AREA_TOTAL",
                caption: "Área",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 60
            }
            ],
            onInitialized: function (e) {
                $scope.gridVariedadesInstance = e.component;
            },
            onCellClick: $scope.onGridVariedadesCellClick,
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            },
            noDataText: '',
            wordWrapEnabled: true
        };
        //#endregion GRID VARIEDADES CellClick e Options

        //#region GRID CORTES CellClick e Options
        //$scope.onGridCortesCellClick
        //$scope.gridCortesOptions
        $scope.onGridCortesCellClick = function (clickedCell) {
            var mapaPropTalhoesArray = convertObjCortesToArrayTalhoes($scope.gridCortesInstance.option('dataSource').items());
            var mapaPropCorteTalhoesArray = convertObjCortesToArrayCorteTalhoes($scope.gridCortesInstance.option('dataSource').items());

            var elements = $scope.mapaPropriedadeInstance.getLayerByIndex(0).getElements();

            for (var i in elements) {
                var pos = $.inArray(elements[i].attribute('TALH_CODIG'), mapaPropTalhoesArray);

                if (pos > -1) {
                    elements[i].applySettings({ color: colorsArrayCorte[mapaPropCorteTalhoesArray[pos]] });
                } else {
                    elements[i].applySettings({ color: '#d2d2d2' });
                }
            };

            coloreGridLegenda('gridCortes');
        };

        $scope.gridCortesOptions = {
            dataSource: $scope.gridCortesDataSource,
            width: 112,
            columns: [{
                dataField: "CORTE",
                caption: "Corte",
                alignment: "center",
                width: 50
            }, {
                dataField: "AREA_TOTAL",
                caption: "Área",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 60
            }
            ],
            onInitialized: function (e) {
                $scope.gridCortesInstance = e.component;
            },
            onCellClick: $scope.onGridCortesCellClick,
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            },
            noDataText: '',
            wordWrapEnabled: true
        };
        //#endregion GRID CORTES CellClick e Options

        //#region PIVOT PLANTIO Options
        $scope.pivotPlantiosOptions = {
            dataSource: {
                store: $scope.pivotPlantiosStore,
                fields: [{
                    caption: "Safra",
                    width: 80,
                    dataField: "SAFRA",
                    alignment: "right",
                    sortOrder: "asc",
                    area: "column"
                }, {
                    caption: "Hectares",
                    width: 80,
                    dataField: "AREA_PLANTIO",
                    dataType: "number",
                    summaryType: "sum",
                    format: "fixedPoint",
                    precision: 2,
                    isMeasure: "True",
                    customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                    area: "data"
                }]
            },
            fieldChooser: {
                enabled: false
            },
            showColumnGrandTotals: false,
            showBorders: true,
            width: "860px",
            onInitialized: function (e) {
                $scope.pivotPlantiosInstance = e.component;
            },
            onCellPrepared: function (e) {
            },
            texts: {
                grandTotal: 'Hectares',
                noData: 'Não Contém Dados'
            },
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            }
        };
        //#endregion PIVOT PLANTIO Options

        //#region GRID PRODUÇÃO TON/HA
        $scope.gridProducaoTonsHaOptions = {
            dataSource: $scope.gridProducaoTonsHaDataSource,
            width: "855px",
            pager: {
                visible: false
            },
            scrolling: { showScrollbar: 'never' },
            rowAlternationEnabled: true,
            columns: [{
                dataField: "CORTE",
                caption: "Corte",
                alignment: "center",
                width: 120
            }, {
                dataField: "SAFRA_01",
                caption: "SAFRA_01",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_02",
                caption: "SAFRA_02",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_03",
                caption: "SAFRA_03",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_04",
                caption: "SAFRA_04",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_05",
                caption: "SAFRA_05",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_06",
                caption: "SAFRA_06",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_07",
                caption: "SAFRA_07",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }
            ],
            onInitialized: function (e) {
                $scope.gridProducaoTonsHaInstance = e.component;
            },
            onRowPrepared: function (e) {
                if (e.rowType == 'header' || e.cells[0].text == '99') {
                    e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                };
            },
            onCellPrepared: function (e) {
                if (e.rowType == 'header') {
                    if (e.column.caption.substr(0, 5) == 'SAFRA') {
                        e.cellElement.text($scope.numeroSafraAtual - (7 - e.column.caption.substr(6, 2)));
                    };
                };
                if (e.rowType == 'data' && e.columnIndex == 0) {
                    if (e.text == '99') {
                        e.cellElement.text('Média');
                    };
                };
            },
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            noDataText: 'Não há dados',
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            }
        };
        //#endregion GRID PRODUÇÃO TON/HA

        //#region GRID PRODUÇÃO CANAS ENTREGUES
        $scope.gridProducaoCanasEntreguesOptions = {
            dataSource: $scope.gridProducaoCanasEntreguesDataSource,
            width: "855px",
            pager: {
                visible: false
            },
            scrolling: { showScrollbar: 'never' },
            rowAlternationEnabled: true,
            showColumnHeaders: false,
            columns: [{
                caption: "Cana Entregue",
                customizeText: function (cellInfo) { return "Cana Entregue"; },
                alignment: "center",
                width: 120
            }, {
                dataField: "SAFRA_01",
                caption: "SAFRA_01",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_02",
                caption: "SAFRA_02",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_03",
                caption: "SAFRA_03",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_04",
                caption: "SAFRA_04",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_05",
                caption: "SAFRA_05",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_06",
                caption: "SAFRA_06",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }, {
                dataField: "SAFRA_07",
                caption: "SAFRA_07",
                dataType: "number",
                format: "decimal",
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 105
            }
            ],
            onInitialized: function (e) {
                $scope.gridProducaoCanasEntreguesInstance = e.component;
            },
            onRowPrepared: function (info) {
                if (info.rowType == 'data') {
                    info.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                };
            },
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            noDataText: 'Não há dados',
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            }
        };
        //#endregion GRID PRODUÇÃO CANAS ENTREGUES

        //#region GRID PRODUÇÃO RESUMO AMBIENTES
        $scope.gridProducaoResumoAmbientesOptions = {
            dataSource: $scope.gridProducaoResumoAmbientesDataSource,
            //width: "935px",
            pager: {
                visible: false
            },
            selection: {
                mode: "single"
            },
            onSelectionChanged: function (e) {
                //e.component.collapseAll(-1);
                e.component.expandRow(e.currentSelectedRowKeys[0]);
            },
            rowAlternationEnabled: true,
            columns: [{
                dataField: "AMBIENTE",
                caption: "Ambiente",
                alignment: "center",
                width: 90
            }, {
                dataField: "AREA_COLHIDA",
                caption: "Área",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 60
            }, {
                dataField: "DT_PLANTIO",
                caption: "Dt.Plantio",
                width: 120
            }, {
                dataField: "DT_COLHEITA_ANT",
                caption: "Dt. Colheita Ant.",
                width: 120
            }, {
                dataField: "DT_COLHEITA_ATU",
                caption: "Dt. Colheita Atu.",
                width: 120
            }, {
                dataField: "IDADE",
                caption: "Idade",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "PERC_BROCA",
                caption: "%Broca",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 60
            }, {
                dataField: "PERC_PERDA",
                caption: "%Perda",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 60
            }, {
                dataField: "TCH",
                caption: "TCH",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "TON_HA_PLAN",
                caption: "R.Plan",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "TON_HA_REAL",
                caption: "R.Real",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }
            ],
            onInitialized: function (e) {
                $scope.gridProducaoResumoAmbientesInstance = e.component;
            },
            onRowPrepared: function (e) {
                if (e.rowType == 'header') {
                    e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                };
            },
            onCellPrepared: function (e) {
                if (e.rowType == 'data' && (e.columnIndex == 3 || e.columnIndex == 4 || e.columnIndex == 5)) {
                    if (e.text == 'a') {
                        e.cellElement.text('');
                    };
                };
            },
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            noDataText: 'Não há dados',
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            },
            masterDetail: {
                enabled: true,
                template: function (container, detailInfo) {
                    var gridProducaoResumoAmbientesCortesOptions = {
                        dataSource: detailInfo.data.oCortes,
                        width: "825px",
                        paging: {
                            enabled: false
                        },
                        selection: {
                            mode: "single"
                        },
                        scrolling: { showScrollbar: 'never' },
                        onSelectionChanged: function (e) {
                            //e.component.collapseAll(-1);
                            e.component.expandRow(e.currentSelectedRowKeys[0]);
                        },
                        rowAlternationEnabled: true,
                        onRowPrepared: function (e) {
                            if (e.rowType == 'header') {
                                e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                            };
                        },
                        onCellPrepared: function (e) {
                            if (e.rowType == 'data' && (e.columnIndex == 3 || e.columnIndex == 4 || e.columnIndex == 5)) {
                                if (e.text == 'a') {
                                    e.cellElement.text('');
                                };
                            };
                        },
                        columns: [{
                            dataField: "CORTE",
                            caption: "Corte",
                            alignment: "center",
                            width: 60
                        }, {
                            dataField: "AREA_COLHIDA",
                            caption: "Área",
                            dataType: "number",
                            format: "fixedPoint",
                            precision: 1,
                            customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                            width: 60
                        }, {
                            dataField: "DT_PLANTIO",
                            caption: "Dt.Plantio",
                            width: 120
                        }, {
                            dataField: "DT_COLHEITA_ANT",
                            caption: "Dt. Colheita Ant.",
                            width: 120
                        }, {
                            dataField: "DT_COLHEITA_ATU",
                            caption: "Dt. Colheita Atu.",
                            width: 120
                        }, {
                            dataField: "IDADE",
                            caption: "Idade",
                            dataType: "number",
                            format: "fixedPoint",
                            precision: 1,
                            customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                            width: 50
                        }, {
                            dataField: "PERC_BROCA",
                            caption: "%Broca",
                            dataType: "number",
                            format: "fixedPoint",
                            precision: 1,
                            customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                            width: 60
                        }, {
                            dataField: "PERC_PERDA",
                            caption: "%Perda",
                            dataType: "number",
                            format: "fixedPoint",
                            precision: 1,
                            customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                            width: 60
                        }, {
                            dataField: "TCH",
                            caption: "TCH",
                            dataType: "number",
                            format: "fixedPoint",
                            precision: 1,
                            customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                            width: 45
                        }, {
                            dataField: "TON_HA_PLAN",
                            caption: "R.Plan",
                            dataType: "number",
                            format: "fixedPoint",
                            precision: 1,
                            customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                            width: 50
                        }, {
                            dataField: "TON_HA_REAL",
                            caption: "R.Real",
                            dataType: "number",
                            format: "fixedPoint",
                            precision: 1,
                            customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                            width: 50
                        }
                        ],
                        showBorders: true,
                        showRowLines: true,
                        noDataText: 'Não há dados',
                        sorting: { mode: 'none' },
                        masterDetail: {
                            enabled: true,
                            template: function (container, detailInfo) {
                                var gridProducaoResumoAmbientesCortesTalhoesOptions = {
                                    dataSource: detailInfo.data.oTalhoes,
                                    width: "795px",
                                    paging: {
                                        enabled: false
                                    },
                                    scrolling: { showScrollbar: 'never' },
                                    rowAlternationEnabled: true,
                                    onRowPrepared: function (e) {
                                        if (e.rowType == 'header') {
                                            e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                                        };
                                    },
                                    columns: [{
                                        dataField: "TALHAO",
                                        caption: "Talhão",
                                        alignment: "center",
                                        width: 59
                                    }, {
                                        dataField: "AREA_COLHIDA",
                                        caption: "Área",
                                        dataType: "number",
                                        format: "fixedPoint",
                                        precision: 1,
                                        customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                                        width: 60
                                    }, {
                                        dataField: "DT_PLANTIO",
                                        caption: "Dt.Plantio",
                                        width: 120
                                    }, {
                                        dataField: "DT_COLHEITA_ANT",
                                        caption: "Dt. Colheita Ant.",
                                        width: 120
                                    }, {
                                        dataField: "DT_COLHEITA_ATU",
                                        caption: "Dt. Colheita Atu.",
                                        width: 120
                                    }, {
                                        dataField: "IDADE",
                                        caption: "Idade",
                                        dataType: "number",
                                        format: "fixedPoint",
                                        precision: 1,
                                        customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                                        width: 50
                                    }, {
                                        dataField: "PERC_BROCA",
                                        caption: "%Broca",
                                        dataType: "number",
                                        format: "fixedPoint",
                                        precision: 1,
                                        customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                                        width: 60
                                    }, {
                                        dataField: "PERC_PERDA",
                                        caption: "%Perda",
                                        dataType: "number",
                                        format: "fixedPoint",
                                        precision: 1,
                                        customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                                        width: 60
                                    }, {
                                        dataField: "TCH",
                                        caption: "TCH",
                                        dataType: "number",
                                        format: "fixedPoint",
                                        precision: 1,
                                        customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                                        width: 45
                                    }, {
                                        dataField: "TON_HA_PLAN",
                                        caption: "R.Plan",
                                        dataType: "number",
                                        format: "fixedPoint",
                                        precision: 1,
                                        customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                                        width: 50
                                    }, {
                                        dataField: "TON_HA_REAL",
                                        caption: "R.Real",
                                        dataType: "number",
                                        format: "fixedPoint",
                                        precision: 1,
                                        customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                                        width: 50
                                    }
                                    ],
                                    showBorders: true,
                                    showRowLines: true,
                                    noDataText: 'Não há dados',
                                    sorting: { mode: 'none' }
                                };

                                var elementGridProducaoResumoAmbientesCortesTalhoes = $('<div>').dxDataGrid(gridProducaoResumoAmbientesCortesTalhoesOptions)
                                elementGridProducaoResumoAmbientesCortesTalhoes.appendTo(container);
                                //container.closest('td').prev().css('display', 'none');
                                container.css('padding-top', '0px');
                                container.css('padding-bottom', '0px');
                                container.attr('title', ' ');
                            }
                        }
                    };

                    var elementGridProducaoResumoAmbientesCortes = $('<div>').dxDataGrid(gridProducaoResumoAmbientesCortesOptions)
                    elementGridProducaoResumoAmbientesCortes.appendTo(container);
                    //container.closest('td').prev().css('display', 'none');
                    container.css('padding-top', '0px');
                    container.css('padding-bottom', '0px');
                    container.attr('title', ' ');
                }
            }
        };
        //#endregion GRID PRODUÇÃO RESUMO AMBIENTES

        //#region LIST SUBGRUPOS AGRÍCOLAS OPTIONS
        $scope.processSelBoxSubGrupoAgricolaValueChange = function (e) {
            $scope.selboxSubGrupoAgricolaAtual = e.value;
            
            if ($scope.selboxSubGrupoAgricolaAtual) {
                $scope.gridTratosCulturaisDataSource.filter(["ID_GRUPO", $scope.selboxSubGrupoAgricolaAtual]);
            } else {
                $scope.gridTratosCulturaisDataSource.filter(null);
            };

            $scope.gridTratosCulturaisInstance.option({ noDataText: 'Não há Tratos Culturais no Subgrupo ' + e.itemData.DS_GRUPO })
            
            $scope.gridTratosCulturaisDataSource.load();
            $scope.gridTratosCulturaisInstance.refresh();
        };
        
        $scope.selboxSubGruposAgricolasOptions = {
            dataSource: $scope.selboxSubGruposAgricolasDataSource,
            displayExpr: 'DS_GRUPO',
            valueExpr: 'ID_GRUPO',
            bindingOptions: { value: 'selboxSubGrupoAgricolaAtual' },
            width: '220px',
            placeholder: '** TODOS **',
            noDataText: 'Não há dados',
            onValueChanged: $scope.processSelBoxSubGrupoAgricolaValueChange,
            onInitialized: function (e) {
                $scope.selboxSubGrupoAgricolaInstance = e.component;
                $scope.selboxSubGruposAgricolasDataSource.load();
            }
        };
        //#endregion

        //#region GRID TRATOS CULTURAIS Options
        $scope.gridTratosCulturaisOptions = {
            dataSource: $scope.gridTratosCulturaisDataSource,
            //width: "880px",
            pager: {
                visible: false
            },
            selection: {
                mode: "single"
            },
            onSelectionChanged: function (e) {
                e.component.collapseAll(-1);
                e.component.expandRow(e.currentSelectedRowKeys[0]);
            },
            rowAlternationEnabled: true,
            columns: [{
                dataField: "DSC_ATIVIDADE",
                caption: "Tipo",
                alignment: "left",
                width: 280
            }, {
                dataField: "NRO_APLIC_0",
                caption: "0",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "NRO_APLIC_1",
                caption: "1",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "NRO_APLIC_2",
                caption: "2",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "NRO_APLIC_3",
                caption: "3",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "NRO_APLIC_4",
                caption: "4",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "NRO_APLIC_5",
                caption: "5",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "NRO_APLIC_6",
                caption: "6",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "NRO_APLIC_7",
                caption: "7",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "NRO_APLIC_8",
                caption: "8",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "NRO_APLIC_9",
                caption: "9",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }, {
                dataField: "NRO_APLIC_10",
                caption: "10",
                dataType: "number",
                format: "fixedPoint",
                precision: 2,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 50
            }
            ],
            onInitialized: function (e) {
                $scope.gridTratosCulturaisInstance = e.component;
            },
            onRowPrepared: function (e) {
                if (e.rowType == 'header') {
                    e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                };
            },
            showBorders: true,
            showRowLines: true,
            noDataText: 'Não há dados',
            sorting: { mode: 'none' },
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            },
            masterDetail: {
                enabled: true,
                template: function (container, detailInfo) {
                    ApiGetService
                        .gethistoricopropriedadeTratosCulturaisTalhoes($scope.selboxSafraAtual.SAFRA, $scope.lookupPropriedadeAtual, detailInfo.data.ATIVIDADE)
                        .then(function (data) {
                            var histpropTratosCulturaisTalhoesArray = data;

                            var gridTratosCulturaisTalhoesOptions = {
                                dataSource: histpropTratosCulturaisTalhoesArray,
                                width: "850px",
                                paging: {
                                    enabled: false
                                },
                                height: 300,
                                scrolling: {
                                    mode: "virtual"
                                },
                                rowAlternationEnabled: true,
                                columns: [{
                                    dataField: 'TALHAO',
                                    caption: 'Talhão',
                                    alignment: 'left',
                                    width: 199
                                }, {
                                    dataField: 'AREA_TALHAO_DIS',
                                    caption: 'Área',
                                    dataType: "number",
                                    format: "fixedPoint",
                                    precision: 2,
                                    customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_0',
                                    caption: '0',
                                    alignment: 'center',
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_1',
                                    caption: '1',
                                    alignment: 'center',
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_2',
                                    caption: '2',
                                    alignment: 'center',
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_3',
                                    caption: '3',
                                    alignment: 'center',
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_4',
                                    caption: '4',
                                    alignment: 'center',
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_5',
                                    caption: '5',
                                    alignment: 'center',
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_6',
                                    caption: '6',
                                    alignment: 'center',
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_7',
                                    caption: '7',
                                    alignment: 'center',
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_8',
                                    caption: '8',
                                    alignment: 'center',
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_9',
                                    caption: '9',
                                    alignment: 'center',
                                    width: 50
                                }, {
                                    dataField: 'NRO_APLIC_10',
                                    caption: '10',
                                    alignment: 'center',
                                    width: 50
                                }],
                                showBorders: true,
                                showRowLines: true,
                                noDataText: 'Não há dados',
                                sorting: { mode: 'none' },
                                onRowPrepared: function (info) {
                                    if (info.rowType == 'data' && info.data.oDatasAplicacao.length == 0)
                                        info.rowElement.find('.dx-datagrid-group-closed').removeClass("dx-datagrid-group-closed dx-datagrid-expand");
                                },
                                masterDetail: {
                                    enabled: true,
                                    template: function (container, detailInfo) {
                                        var gridTratosCulturaisTalhoesDatasAplicacaoOptions = {
                                            dataSource: detailInfo.data.oDatasAplicacao,
                                            width: "800px",
                                            paging: {
                                                enabled: false
                                            },
                                            wordWrapEnabled: true,
                                            rowAlternationEnabled: true,
                                            columns: [{
                                                dataField: 'DATA_APLICACAO',
                                                caption: 'Data Aplicação',
                                                dataType: "date",
                                                alignment: 'left',
                                                width: 90
                                            }, {
                                                dataField: 'DIAS',
                                                caption: 'Dias',
                                                alignment: 'center',
                                                width: 50
                                            }, {
                                                dataField: 'PRODUTO_DOSAGEM',
                                                caption: 'Produtos Utilizados',
                                                alignment: 'left',
                                                width: 655
                                            }],
                                            showBorders: true,
                                            showRowLines: true,
                                            noDataText: 'Não há dados',
                                            sorting: { mode: 'none' }
                                        };

                                        var elementGridTratosCulturaisDatasAplicacaoTalhoes = $('<div>').addClass("internal-grid").dxDataGrid(gridTratosCulturaisTalhoesDatasAplicacaoOptions)
                                        elementGridTratosCulturaisDatasAplicacaoTalhoes.appendTo(container);
                                        //container.closest('td').prev().css('display', 'none');
                                        container.css('padding-top', '0px');
                                        container.css('padding-bottom', '0px');
                                        container.attr('title', ' ');
                                    }
                                }
                            };

                            var elementGridTratosCulturaisTalhoes = $('<div>').dxDataGrid(gridTratosCulturaisTalhoesOptions)
                            elementGridTratosCulturaisTalhoes.appendTo(container);
                            //container.closest('td').prev().css('display', 'none');
                            container.css('padding-top', '0px');
                            container.css('padding-bottom', '0px');
                            container.attr('title', ' ');
                        });

                }
            }
        };
        //#endregion GRID TRATOS CULTURAIS Options

        //#region GRID NÃO CONFORMIDADES
        $scope.gridNaoConformidadesOptions = {
            dataSource: $scope.gridNaoConformidadesDataSource,
            width: "855px",
            pager: {
                visible: false
            },
            rowAlternationEnabled: true,
            columns: [{
                dataField: "TALHOES_AFETADOS",
                caption: "Talhões Afetados",
                alignment: "left",
                width: 110
            }, {
                dataField: "COD_OCORR",
                caption: "Cód.",
                dataType: "number",
                format: "decimal",
                width: 50
            }, {
                dataField: "DSC_OCORR",
                caption: "Descrição Ocorrência",
                width: 165
            }, {
                dataField: "DT_OCORR",
                caption: "Data",
                dataType: "date",
                width: 80
            }, {
                dataField: "CONSIDERACOES",
                caption: "Considerações"
            }, {
                dataField: "AREA_AFETADA",
                caption: "Área Afetada",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 85
            }, {
                dataField: "AREA_TOTAL",
                caption: "Área Total",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 85
            }
            ],
            onInitialized: function (e) {
                $scope.gridNaoConformidadesInstance = e.component;
            },
            onRowPrepared: function (e) {
                if (e.rowType == 'header' || e.cells[0].text == '99') {
                    e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                };
            },
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            wordWrapEnabled: true,
            noDataText: 'Nenhuma Não Conformidade Registrada',
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            }
        };
        //#endregion GRID NÃO CONFORMIDADES


        //#region GRID DIAGNÓSTICO COLHEITA
        $scope.gridDiagnosticoColheitaOptions = {
            dataSource: $scope.gridDiagnosticoColheitaDataSource,
            width: "855px",
            pager: {
                visible: false
            },
            rowAlternationEnabled: true,
            columns: [{
                dataField: "TALHOES_AFETADOS",
                caption: "Talhões Afetados",
                alignment: "left",
                width: 110
            }, {
                dataField: "AREA_AFETADA",
                caption: "Área Colhida",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 85
            }, {
                dataField: "DT_OCORR",
                caption: "Data",
                dataType: "date",
                width: 80
            }, {
                dataField: "CONSIDERACOES",
                caption: "Considerações"
            }
            ],
            onInitialized: function (e) {
                $scope.gridNaoConformidadesInstance = e.component;
            },
            onRowPrepared: function (e) {
                if (e.rowType == 'header' || e.cells[0].text == '99') {
                    e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                };
            },
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            wordWrapEnabled: true,
            noDataText: 'Nenhum Diagnóstico de Colheita Registrado',
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            }
        };
        //#endregion GRID DIAGNÓSTICO COLHEITA


        //#region TABPANEL Items Array e Options
        $scope.tabPanelItems = [
                {
                    title: "Plantio",
                    template: "tabPlantio",
                    pivotPlantiosOptions: $scope.pivotPlantiosOptions
                },
                {
                    title: "Produção - Ton/ha",
                    template: "tabProducao",
                    numeroSafraAtual: $scope.numeroSafraAtual,
                    gridProducaoTonsHaOptions: $scope.gridProducaoTonsHaOptions,
                    gridProducaoCanasEntreguesOptions: $scope.gridProducaoCanasEntreguesOptions,
                    gridProducaoResumoAmbientesOptions: $scope.gridProducaoResumoAmbientesOptions
                },
                {
                    title: "Tratos Culturais",
                    template: "tabTratosCulturais",
                    gridTratosCulturaisOptions: $scope.gridTratosCulturaisOptions
                },
                {
                    title: "Não Conformidades",
                    template: "tabNaoConformidades",
                    gridNaoConformidadesOptions: $scope.gridNaoConformidadesOptions
                },
                {
                    title: "Diagnóstico Colheita",
                    template: "tabDiagnosticoColheita",
                    gridDiagnosticoColheitaOptions: $scope.gridDiagnosticoColheitaOptions
                }
        ];

        $scope.tabPanelOptions = {
            dataSource: $scope.tabPanelItems,
            titleTemplate: 'title',
            //width: '940px',
            onSelectionChanged: function (e) {
                if (e.component.option('selectedIndex') == 2) {
                    //Selecionada aba de Tratos culturais, força a entrada do dxSelectBox
                    //Por estar dentro de dxTemplate, não passava pelo onInitialized (bug dx?)
                    $("#subgragr").dxSelectBox($scope.selboxSubGruposAgricolasOptions);
                    //$("#subgragr").dxSelectBox.option({ value: '0' });
                    $scope.selboxSubGruposAgricolasDataSource.load();
                    $scope.selboxSubGrupoAgricolaAtual = 0;

                };
            }
        };
        //#endregion TABPANEL Items Array e Options


        //#region Funções HELPER
        function coloreGridLegenda(nomeGrid) {
            //#region Blocos de ifs para limpar cores de grid rows com background #ffffff
            if (nomeGrid !== 'gridAmbientes') {
                $scope.gridAmbientesInstance.option({
                    onRowPrepared: function (info) {
                        if (info.rowType == 'data') {
                            info.rowElement.css('background', '#ffffff');
                        };
                    }
                });
            };

            if (nomeGrid !== 'gridMaturacoes') {
                $scope.gridMaturacoesInstance.option({
                    onRowPrepared: function (info) {
                        if (info.rowType == 'data') {
                            info.rowElement.css('background', '#ffffff');
                        };
                    }
                });
            };

            if (nomeGrid !== 'gridVariedades') {
                $scope.gridVariedadesInstance.option({
                    onRowPrepared: function (info) {
                        if (info.rowType == 'data') {
                            info.rowElement.css('background', '#ffffff');
                        };
                    }
                });
            };

            if (nomeGrid !== 'gridCortes') {
                $scope.gridCortesInstance.option({
                    onRowPrepared: function (info) {
                        if (info.rowType == 'data') {
                            info.rowElement.css('background', '#ffffff');
                        };
                    }
                });
            };
            //#endregion Blocos de ifs para limpar cores de grid rows com background #ffffff

            //#region Blocos de ifs para pintar cores de grid rows com background conforme colorsArrayMaturacao
            if (nomeGrid == 'gridAmbientes') {
                $scope.gridAmbientesInstance.option({
                    onRowPrepared: function (info) {
                        if (info.rowType == 'data') {

                            var arrayAmbientes = convertObjAmbientesToArrayAmbientes($scope.gridAmbientesInstance.option('dataSource').items());

                            var pos = $.inArray(info.data.AMBIENTE, arrayAmbientes);

                            info.rowElement.css('background', colorsArrayAmbiente[pos]);
                        };
                    }
                });
            };

            if (nomeGrid == 'gridMaturacoes') {
                $scope.gridMaturacoesInstance.option({
                    onRowPrepared: function (info) {
                        if (info.rowType == 'data') {

                            var arrayMaturacoes = convertObjMaturacoesToArrayMaturacoes($scope.gridMaturacoesInstance.option('dataSource').items());

                            var pos = $.inArray(info.data.MATURACAO, arrayMaturacoes);

                            info.rowElement.css('background', colorsArrayMaturacao[pos]);
                        };
                    }
                });
            };

            if (nomeGrid == 'gridVariedades') {
                $scope.gridVariedadesInstance.option({
                    onRowPrepared: function (info) {
                        if (info.rowType == 'data') {

                            var arrayVariedades = convertObjVariedadesToArrayVariedades($scope.gridVariedadesInstance.option('dataSource').items());

                            var pos = $.inArray(info.data.VARIEDADE, arrayVariedades);

                            info.rowElement.css('background', colorsArrayVariedade[pos]);
                        };
                    }
                });
            };

            if (nomeGrid == 'gridCortes') {
                $scope.gridCortesInstance.option({
                    onRowPrepared: function (info) {
                        if (info.rowType == 'data') {

                            var arrayCortes = convertObjCortesToArrayCortes($scope.gridCortesInstance.option('dataSource').items());

                            var pos = $.inArray(info.data.CORTE, arrayCortes);

                            info.rowElement.css('background', colorsArrayCorte[pos]);
                        };
                    }
                });
            };
            //#endregion Blocos de ifs para pintar cores de grid rows com background conforme colorsArrayMaturacao

        };

        //#region Funções HELPER Ambientes
        function convertObjAmbientesToArrayTalhoes(objAmbientes) {
            var mapaPropTalhoesArray = [];

            for (var i = 0; i < objAmbientes.length; i++) {
                for (var j = 0; j < objAmbientes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArray.push(objAmbientes[i].oTalhoes[j].NUMERO);
                };
            };

            return mapaPropTalhoesArray;
        };

        function convertObjAmbientesToArrayTalhoesDtColheita(objAmbientes) {
            var mapaPropTalhoesArray = [];

            for (var i = 0; i < objAmbientes.length; i++) {
                for (var j = 0; j < objAmbientes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArray.push(objAmbientes[i].oTalhoes[j].DT_COLHEITA);
                };
            };

            return mapaPropTalhoesArray;
        };

        function convertObjAmbientesToArrayTalhoesReforma(objAmbientes) {
            var mapaPropTalhoesArray = [];

            for (var i = 0; i < objAmbientes.length; i++) {
                for (var j = 0; j < objAmbientes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArray.push(objAmbientes[i].oTalhoes[j].REFORMA);
                };
            };

            return mapaPropTalhoesArray;
        };

        function convertObjAmbientesToArrayTalhoesUltCorteMuda(objAmbientes) {
            var mapaPropTalhoesArray = [];

            for (var i = 0; i < objAmbientes.length; i++) {
                for (var j = 0; j < objAmbientes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArray.push(objAmbientes[i].oTalhoes[j].ULT_CORTE_MUDA);
                };
            };

            return mapaPropTalhoesArray;
        };

        function convertObjAmbientesToArrayAmbienteTalhoes(objAmbientes) {
            var mapaPropTalhoesArraySync = [];

            for (var i = 0; i < objAmbientes.length; i++) {
                for (var j = 0; j < objAmbientes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArraySync.push(i);
                };
            };

            return mapaPropTalhoesArraySync;
        };

        function convertObjAmbientesToArrayAmbienteTalhoesNomeAmbiente(objAmbientes) {
            var mapaPropTalhoesArraySync = [];

            for (var i = 0; i < objAmbientes.length; i++) {
                for (var j = 0; j < objAmbientes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArraySync.push(objAmbientes[i].AMBIENTE);
                };
            };

            return mapaPropTalhoesArraySync;
        };

        function convertObjAmbientesToArrayAmbientes(objAmbientes) {
            var mapaPropAmbientesArray = [];

            for (var i = 0; i < objAmbientes.length; i++) {
                mapaPropAmbientesArray[i] = objAmbientes[i].AMBIENTE;
            };

            return mapaPropAmbientesArray;
        };
        //#endregion Funções HELPER Ambientes

        //#region Funções HELPER Maturações
        function convertObjMaturacoesToArrayTalhoes(objMaturacoes) {
            var mapaPropTalhoesArray = [];

            for (var i = 0; i < objMaturacoes.length; i++) {
                for (var j = 0; j < objMaturacoes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArray.push(objMaturacoes[i].oTalhoes[j].NUMERO);
                };
            };

            return mapaPropTalhoesArray;
        };

        function convertObjMaturacoesToArrayMaturacaoTalhoes(objMaturacoes) {
            var mapaPropTalhoesArraySync = [];

            for (var i = 0; i < objMaturacoes.length; i++) {
                for (var j = 0; j < objMaturacoes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArraySync.push(i);
                };
            };

            return mapaPropTalhoesArraySync;
        };

        function convertObjMaturacoesToArrayMaturacaoTalhoesNomeMaturacao(objMaturacoes) {
            var mapaPropTalhoesArraySync = [];

            for (var i = 0; i < objMaturacoes.length; i++) {
                for (var j = 0; j < objMaturacoes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArraySync.push(objMaturacoes[i].MATURACAO);
                };
            };

            return mapaPropTalhoesArraySync;
        };

        function convertObjMaturacoesToArrayMaturacoes(objMaturacoes) {
            var mapaPropMaturacoesArray = [];

            for (var i = 0; i < objMaturacoes.length; i++) {
                mapaPropMaturacoesArray[i] = objMaturacoes[i].MATURACAO;
            };

            return mapaPropMaturacoesArray;
        };
        //#endregion Funções HELPER Maturações

        //#region Funções HELPER Variedades
        function convertObjVariedadesToArrayTalhoes(objVariedades) {
            var mapaPropTalhoesArray = [];

            for (var i = 0; i < objVariedades.length; i++) {
                for (var j = 0; j < objVariedades[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArray.push(objVariedades[i].oTalhoes[j].NUMERO);
                };
            };

            return mapaPropTalhoesArray;
        };

        function convertObjVariedadesToArrayVariedadeTalhoes(objVariedades) {
            var mapaPropTalhoesArraySync = [];

            for (var i = 0; i < objVariedades.length; i++) {
                for (var j = 0; j < objVariedades[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArraySync.push(i);
                };
            };

            return mapaPropTalhoesArraySync;
        };

        function convertObjVariedadesToArrayVariedadeTalhoesNomeVariedade(objVariedades) {
            var mapaPropTalhoesArraySync = [];

            for (var i = 0; i < objVariedades.length; i++) {
                for (var j = 0; j < objVariedades[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArraySync.push(objVariedades[i].VARIEDADE);
                };
            };

            return mapaPropTalhoesArraySync;
        };

        function convertObjVariedadesToArrayVariedades(objVariedades) {
            var mapaPropVariedadesArray = [];

            for (var i = 0; i < objVariedades.length; i++) {
                mapaPropVariedadesArray[i] = objVariedades[i].VARIEDADE;
            };

            return mapaPropVariedadesArray;
        };
        //#endregion Funções HELPER Variedades

        //#region Funções HELPER Cortes
        function convertObjCortesToArrayTalhoes(objCortes) {
            var mapaPropTalhoesArray = [];

            for (var i = 0; i < objCortes.length; i++) {
                for (var j = 0; j < objCortes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArray.push(objCortes[i].oTalhoes[j].NUMERO);
                };
            };

            return mapaPropTalhoesArray;
        };

        function convertObjCortesToArrayCorteTalhoes(objCortes) {
            var mapaPropTalhoesArraySync = [];

            for (var i = 0; i < objCortes.length; i++) {
                for (var j = 0; j < objCortes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArraySync.push(i);
                };
            };

            return mapaPropTalhoesArraySync;
        };

        function convertObjCortesToArrayCorteTalhoesNomeCorte(objCortes) {
            var mapaPropTalhoesArraySync = [];

            for (var i = 0; i < objCortes.length; i++) {
                for (var j = 0; j < objCortes[i].oTalhoes.length; j++) {
                    mapaPropTalhoesArraySync.push(objCortes[i].CORTE);
                };
            };

            return mapaPropTalhoesArraySync;
        };

        function convertObjCortesToArrayCortes(objCortes) {
            var mapaPropCortesArray = [];

            for (var i = 0; i < objCortes.length; i++) {
                mapaPropCortesArray[i] = objCortes[i].CORTE;
            };

            return mapaPropCortesArray;
        };
        //#endregion Funções HELPER Cortes

        //#endregion Funções HELPER

    };
})();
