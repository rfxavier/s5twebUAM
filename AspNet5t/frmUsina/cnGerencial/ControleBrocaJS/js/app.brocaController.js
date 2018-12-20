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

    angular.module('app4T')
        .controller("controleBrocasCtrl", ['$scope', '$document', 'ApiGetService', controleBrocasCtrl])
    
    function controleBrocasCtrl($scope, $document, ApiGetService) {
        //#region $scope empty object declarations

        //Nome da propriedade (código da propriedade), para mostrar em botão disparador do PopOver
        $scope.nomePropriedadeDisplay = null;
        $scope.codigoPropriedade = 0;

        //dxVectorMap Mapa Propriedade
        $scope.mapaPropriedadeOptions = {};
        $scope.mapaPropriedadeInstance = null;

        //Dados "parseados" do .SHP e .DBF, que entrarão no layers.data do dxVectorMap
        $scope.mapaPropriedadesLayerData = {};
        $scope.mapaMunicipiosLayerData = {};

        $scope.propriedadepragaArray = {};
        $scope.propriedadetipoArray = {};

        //Botão com nome e código da propriedade
        $scope.botaoPropriedadePopOverOptions = {};

        //
        $scope.loadingVisible = false;

        //PopOver
        $scope.popOverOptions = {};
        $scope.popOverVisible = false;
        $scope.togglePopover = {};

        //Grid principal - relacionados
        $scope.controleBrocasArray = {};
        $scope.gridBrocasDataSource = {};
        $scope.gridBrocasOptions = {};
        $scope.gridBrocasInstance = null;

        //Sub classe relacionada para drill down com Safra + Propriedade + Tipo principais
        $scope.controleBrocasPorTalhaoArray = {};
        $scope.gridBrocaPorTalhoesDataSource = {};
        $scope.gridBrocaPorTalhoesOptions = {};
        $scope.gridBrocaPorTalhoesInstance = null;

        $scope.percInfestacaoSafraAnterior = 0;
        $scope.percInfestacaoSafraAnteriorTextoDisplay = null;

        $scope.gridBrocasExpCount = 0;

        //#endregion $scope empty object declarations

        var symbolArray = ['Ã£', 'Ã´', 'Ã¢','Ã§','Ã©','Ãº','Ãª','Ã³','Ã¡','Ã'];
        var charArray = ['ã','ô','â','ç','é','ú','ê','ó','á','í'];

        var coresFrentesArray = ['#ffc0cb', '#ffa500', '#800080', '#00ff00', '#00ffff', '#4169e1', '#ff00ff', '#ff0000', '#00c000', '#ffff00']

        function TrocaSymbolsPorAcento(nome) {
            var nomeResultante = nome;
            
            for (var i = 0; i < symbolArray.length; i++) {
                if (nomeResultante.indexOf(symbolArray[i]) !== -1) {
                    var regex = new RegExp(symbolArray[i], 'g');
                    nomeResultante = nomeResultante.replace(regex, charArray[i]);
                };
            };
           
            return nomeResultante;
        };


        function ParseDataVectorMapUtilsNomeMunicipioAcentos(parseData) {
            for (var i = 0; i < parseData.features.length; i++) {
                parseData.features[i].properties.NOME = 'Município de ' + TrocaSymbolsPorAcento(parseData.features[i].properties.NOME);
            };

        };


        function ParseDataVectorMapUtilsPropDescrAcentos(parseData) {
            for (var i = 0; i < parseData.features.length; i++) {
                parseData.features[i].properties.PROP_DESCR = TrocaSymbolsPorAcento(parseData.features[i].properties.PROP_DESCR);
            };

        };

        var parseMapaPropriedade = function () {
            var promise = new Promise(function (resolve, reject) {
                DevExpress.viz.vectormaputils.parse(ResolveUrl('~/mapaShapes/Propriedades/Propriedades'), { precision: 8 }, function (data) {
                    //console.log(data);
                    ParseDataVectorMapUtilsPropDescrAcentos(data);

                    $scope.mapaPropriedadesLayerData = data;

                    DevExpress.viz.vectormaputils.parse(ResolveUrl('~/mapaShapes/Municipios/Municipios'), { precision: 8 }, function (data) {
                        //console.log(data);
                        ParseDataVectorMapUtilsNomeMunicipioAcentos(data);

                        $scope.mapaMunicipiosLayerData = data;

                        $scope.mapaPropriedadeInstance.option({
                            layers: [{
                                type: 'area',
                                data: $scope.mapaMunicipiosLayerData,
                                label: {
                                    enabled: true,
                                    dataField: 'NOME',
                                    font: {
                                        color: 'black',
                                        opacity: 1,
                                        weight: 80,
                                        size: 8
                                    }
                                },
                                opacity: 0.2,
                                borderColor: 'indianred',
                                borderWidth: 2,
                                selectionMode: 'none'
                            }, {
                                type: 'area',
                                data: $scope.mapaPropriedadesLayerData,
                                label: {
                                    enabled: true,
                                    dataField: 'PROP_DESCR',
                                    font: {
                                        color: 'black',
                                        opacity: 1,
                                        weight: 100,
                                        size: 15
                                    }
                                },
                                selectedColor: 'seagreen',
                                selectionMode: 'single'
                            }],
                            onClick: function (e) {
                                var clickedArea = e.target;
                                if (clickedArea != undefined && clickedArea.layer.type == 'area') {
                                    if (clickedArea.attribute('PROP_CODIG') !== undefined) {
                                        clickedArea.selected(!clickedArea.selected());
                                        if ($scope.popOverVisible) {
                                            $scope.popOverVisible = false;
                                            $scope.gridBrocasExpCount = 0;
                                        };
                                        if (clickedArea.selected()) {
                                            $scope.nomePropriedadeDisplay = clickedArea.attribute('PROP_DESCR') + ' (' + clickedArea.attribute('PROP_CODIG') + ')';
                                            $scope.codigoPropriedade = clickedArea.attribute('PROP_CODIG');
                                        } else {
                                            $scope.nomePropriedadeDisplay = null;
                                            $scope.codigoPropriedade = 0;
                                        };
                                    };
                                }
                            },
                            tooltip: {
                                enabled: true,
                                customizeTooltip: function (arg) {
                                    if (arg.layer.index == 1) {
                                        if ($scope.propriedadepragaArray.length !== undefined) {
                                            var objPropriedade = $scope.propriedadepragaArray.filter(function (obj) {
                                                return obj.COD_PROPRIEDADE == arg.attribute("PROP_CODIG");
                                            });
                                        } else {
                                            var objPropriedade = [];
                                        };

                                        if (objPropriedade.length == 0) {
                                            var node = $("<div>")
                                                .append("<h5>" + arg.attribute("PROP_CODIG") + "</h5>")
                                                .append("<h5>" + arg.attribute("PROP_DESCR") + "</h5>");
                                        } else {
                                            //var percInfestacaoSafraAnterior = objPropriedade[0].PERC_INFEST_SF_ANT;
                                            //var percInfestacaoSafraAnteriorDisplay = percInfestacaoSafraAnterior.toString().replace(/\,/g, '').replace('.', ',')
                                            var node = $("<div>")
                                                .append("<h5>" + arg.attribute("PROP_CODIG") + "</h5>")
                                                .append("<h5>" + arg.attribute("PROP_DESCR") + "</h5>")
                                                .append("<div>" +$scope.percInfestacaoSafraAnteriorTextoDisplay + objPropriedade[0].PERC_INFEST_SF_ANT + "</div>")
                                        };
                                        return {
                                            html: node.html()
                                        };
                                    };
                                }
                            },
                            size: {
                                height: document.documentElement.clientHeight - 154
                            },
                            bounds: [$scope.mapaPropriedadesLayerData.bbox[0], $scope.mapaPropriedadesLayerData.bbox[1], $scope.mapaPropriedadesLayerData.bbox[2], $scope.mapaPropriedadesLayerData.bbox[3]],
                            maxZoomFactor: 48,
                            zoomFactor: 4
                        });

                        resolve();
                    });
                });

            });

            return promise;
        };

        $scope.tipoPragaDisplay = function () {
            var pragaDisplay = '';

            if (tipoPraga == 'broca') {
                pragaDisplay = 'Brocas';
            } else if (tipoPraga == 'cigarrinha') {
                pragaDisplay = 'Cigarrinha';
            } else if (tipoPraga == 'sphenophorus') {
                pragaDisplay = 'Sphenophorus';
            };

            return pragaDisplay;
        }();

        $scope.percInfestacaoSafraAnteriorTextoDisplay = function () {
            var infestacaoDisplay = '';

            if (tipoPraga == 'broca') {
                infestacaoDisplay = '% Infestação Sf. Anterior: ';
            } else if (tipoPraga == 'cigarrinha') {
                infestacaoDisplay = 'Média Individuos/ha Sf. Anterior: ';
            } else if (tipoPraga == 'sphenophorus') {
                infestacaoDisplay = '% Infestação Sf. Anterior: ';
            };

            return infestacaoDisplay;
        }();

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


        $scope.selboxSafraOptions = {
            dataSource: $scope.selboxSafrasDataSource,
            displayExpr: 'SAFRA',
            bindingOptions: { value: 'selboxSafraAtual' },
            width: '70px',
            noDataText: 'Não há dados',
            placeholder: 'Selecione a safra',
            onInitialized: function (e) {
                $scope.selboxSafraInstance = e.component;
            }
        };

        function PercInfestacaoSafraAnterior(codigoProp) {
            var objPropriedade = $scope.propriedadepragaArray.filter(function (obj) {
                return obj.COD_PROPRIEDADE == codigoProp;
            });

            if (objPropriedade.length) {
                var percInfestacao = objPropriedade[0].PERC_INFEST_SF_ANT;
            } else {
                var percInfestacao = 0;
            };

            return percInfestacao.toString().replace(/\,/g, '').replace('.', ',');
        };

        function PercInfestacaoSafraAnteriorString(codigoProp) {
            var objPropriedade = $scope.propriedadepragaArray.filter(function (obj) {
                return obj.COD_PROPRIEDADE == codigoProp;
            });

            if (objPropriedade.length) {
                var percInfestacao = objPropriedade[0].PERC_INFEST_SF_ANT;
            } else {
                var percInfestacao = '0';
            };

            return percInfestacao.toString();
        };

        function ColoreMapaElementos() {
            if (!$scope.mapaPropriedadeInstance.getLayers().length) { return };

            var elements = $scope.mapaPropriedadeInstance.getLayerByIndex(1).getElements();

            for (var i in elements) {
                var objPropriedade = $scope.propriedadepragaArray.filter(function (obj) {
                    return obj.COD_PROPRIEDADE == elements[i].attribute('PROP_CODIG');
                });

                var objPropriedadeTipo = $scope.propriedadetipoArray.filter(function (obj) {
                    return obj.PROP_CODIGO == elements[i].attribute('PROP_CODIG');
                });

                if (objPropriedade.length) {
                    elements[i].applySettings({ color: '#00c000' });
                } else {
                    elements[i].applySettings({ color: '#d2d2d2' });
                };

                if (objPropriedade.length && objPropriedadeTipo.length) {
                    elements[i].applySettings({ color: 'purple' });
                } else if (objPropriedadeTipo.length) {
                    elements[i].applySettings({ color: 'rgba(252, 255, 0, 0.4)' });
                };


            };

        };

        function ColoreMapaPropriedades(safraAnterior, safra) {
            if (tipoPraga == 'broca') {
                //#region ApiGetService Broca
                //PARA PINTAR O MAPA E DAR INFORMAÇÕES NA TOOLTIP

                if (safraAnterior !== safra) {
                    ApiGetService
                        .getpropriedadepragaBrocaPromise(safra)
                        .then(function (data) {
                            $scope.propriedadepragaArray = data;

                            ColoreMapaElementos();
                        });
                };


                //#endregion ApiGetService Broca
            } else if (tipoPraga == 'cigarrinha') {
                //#region ApiGetService Cigarrinha
                //PEGA INFORMAÇÕES COLHEITA
                //PARA PINTAR O MAPA E DAR INFORMAÇÕES NA TOOLTIP
                if (safraAnterior !== safra) {
                    ApiGetService
                        .getpropriedadepragaCigarrinhaPromise(safra)
                        .then(function (data) {
                            $scope.propriedadepragaArray = data;

                            ColoreMapaElementos();
                        });
                };
                //#endregion ApiGetService Cigarrinha
            } else if (tipoPraga == 'sphenophorus') {
                //#region ApiGetService Sphenophorus
                //PEGA INFORMAÇÕES COLHEITA
                //PARA PINTAR O MAPA E DAR INFORMAÇÕES NA TOOLTIP
                if (safraAnterior !== safra) {
                    ApiGetService
                        .getpropriedadepragaSphenophorusPromise(safra)
                        .then(function (data) {
                            $scope.propriedadepragaArray = data;

                            ColoreMapaElementos();
                        });
                };
                //#endregion ApiGetService Sphenophorus
            };

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

                    ApiGetService
                    .getpropriedadetipoPromise('F')
                    .then(function (data) {
                        $scope.propriedadetipoArray = data;

                        parseMapaPropriedade().then(function () {
                            ColoreMapaElementos();
                        });
                    });
                });
        });

        //#region $watch $scope.selboxSafraAtual
        $scope.$watch('selboxSafraAtual', function () {
            if ($scope.selboxSafraAtual) {
                var numeroSafraAnterior = $scope.numeroSafraAtual;

                $scope.numeroSafraAtual = $scope.selboxSafraAtual.SAFRA;

                ColoreMapaPropriedades(numeroSafraAnterior, $scope.numeroSafraAtual);
            };
        });
        //#endregion $watch $scope.selboxSafraAtual 


        //#region gridDataSources = new DevExpress.data.DataSource
        $scope.gridBrocasDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.controleBrocasArray, { totalCount: $scope.controleBrocasArray.length });
                else
                    deferred.resolve($scope.controleBrocasArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.controleBrocasArray.length);

                return deferred.promise();
            }
        });
        //#endregion gridDataSources = new DevExpress.data.DataSource

        //#region VECTORMAP PROPRIEDADES Options
        //ORDEM: 1 - onInitialized dos $scope....Options
        $scope.mapaPropriedadeOptions = {
            controlBar: {
                enabled: false
            },
            //zoomFactor: 4,
            //maxZoomFactor: 48,
            onInitialized: function (e) {
                $scope.mapaPropriedadeInstance = e.component;
            }
        };
        //#endregion VECTORMAP PROPRIEDADES Options

        //#region BUTTON SELECIONE PROPRIEDADE Options
        $scope.selecionePropriedadeOptions = {
            onInitialized: function (e) {
                e.element.css('background', 'rgba(252, 255, 0, 0.17)');
            },
            text: 'Selecione uma propriedade no mapa'
        };
        //#endregion BUTTON SELECIONE PROPRIEDADE Options



        //#region BUTTON PROPRIEDADES POPOVER Options
        $scope.propriedadePopOverOptions = {
            onInitialized: function (e) {
                e.element.css('background', 'rgba(169, 208, 142, 0.47)');
            },
            onClick: function () {
                $scope.popOverVisible = !$scope.popOverVisible;
                if ($scope.popOverVisible) {
                    $scope.loadingVisible = true;
                    $scope.percInfestacaoSafraAnterior = PercInfestacaoSafraAnteriorString($scope.codigoPropriedade);

                    $scope.gridBrocasInstance && $scope.gridBrocasInstance.collapseAll(-1);
                    $scope.gridBrocasExpCount = 0;

                    if (tipoPraga == 'broca') {
                        ApiGetService
                             .getcontrolepragaBrocaPromise($scope.numeroSafraAtual, $scope.codigoPropriedade)
                             .then(function (data) {
                                 $scope.controleBrocasArray = data;

                                 $scope.gridBrocasInstance.refresh();
                                 $scope.loadingVisible = false;
                             });

                    } else if (tipoPraga == 'cigarrinha') {
                        ApiGetService
                             .getcontrolepragaCigarrinhaPromise($scope.numeroSafraAtual, $scope.codigoPropriedade)
                             .then(function (data) {
                                 $scope.controleBrocasArray = data;

                                 $scope.gridBrocasInstance.refresh();
                                 $scope.loadingVisible = false;
                             });
                    } else if (tipoPraga == 'sphenophorus') {
                        ApiGetService
                             .getcontrolepragaSphenophorusPromise($scope.numeroSafraAtual, $scope.codigoPropriedade)
                             .then(function (data) {
                                 $scope.controleBrocasArray = data;

                                 $scope.gridBrocasInstance.refresh();
                                 $scope.loadingVisible = false;
                             });
                    };

                };
            },
            bindingOptions: { text: 'nomePropriedadeDisplay' }
        }
        //#endregion BUTTON PROPRIEDADES POPOVER Options

        //#region LOADPANEL Options
        $scope.loadOptions = {
            shadingColor: "rgba(0,0,0,0.4)",
            position: { of: "#gridBrocasContainer" },
            bindingOptions: {
                visible: "loadingVisible"
            },
            message: "Aguarde..."
        };
        //#endregion LOADPANEL Options

        //#region POPOVER Options
        $scope.popOverOptions = {
            target: '#popoverButton',
            contentTemplate: 'popoverContent',
            showTitle: true,
            //title: 'Acompanhamento de Infestação de Brocas',
            width: '770px',
            position: { my: 'left', at: 'right', offset: '5 64' },
            closeOnOutsideClick: false,
            bindingOptions: {
                visible: 'popOverVisible'
            }
        };
        //#endregion POPOVER Options

        //#region GRID BROCAS
        $scope.gridBrocasOptions = {
            dataSource: $scope.gridBrocasDataSource,
            pager: {
                visible: false
            },
            columns: [{
                dataField: "TIPO",
                caption: "Tipo",
                alignment: "left",
                width: 195
            }, {
                dataField: "NRO_APLIC_0",
                caption: "0",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "NRO_APLIC_1",
                caption: "1",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "NRO_APLIC_2",
                caption: "2",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "NRO_APLIC_3",
                caption: "3",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "NRO_APLIC_4",
                caption: "4",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "NRO_APLIC_5",
                caption: "5",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "NRO_APLIC_6",
                caption: "6",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "NRO_APLIC_7",
                caption: "7",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "NRO_APLIC_8",
                caption: "8",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "NRO_APLIC_9",
                caption: "9",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }, {
                dataField: "NRO_APLIC_10",
                caption: "10",
                dataType: "number",
                format: "fixedPoint",
                precision: 1,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 45
            }
            ],
            onInitialized: function (e) {
                $scope.gridBrocasInstance = e.component;
            },
            onRowPrepared: function (e) {
                if (e.rowType == 'header') {
                    e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                };
            },
            onRowExpanded: function () {
                $scope.gridBrocasExpCount++;
            },
            onRowCollapsed: function () {
                $scope.gridBrocasExpCount--;
            },
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            },
            noDataText: 'Não há dados',
            //onRowPrepared: function (info) {
            //    info.rowElement.find('.dx-datagrid-group-closed').removeClass("dx-datagrid-group-closed dx-datagrid-expand");
            //},
            masterDetail: {
                enabled: true,
                template: function (container, detailInfo) {
                    var gridBrocaPorTalhoesOptions = {
                        dataSource: detailInfo.data.oTalhoes,
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
                            width: 54
                        }, {
                            dataField: 'REFORMA',
                            caption: 'Reforma',
                            alignment: 'center',
                            width: 60
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
                            width: 45
                        }, {
                            dataField: 'NRO_APLIC_1',
                            caption: '1',
                            alignment: 'center',
                            width: 45
                        }, {
                            dataField: 'NRO_APLIC_2',
                            caption: '2',
                            alignment: 'center',
                            width: 45
                        }, {
                            dataField: 'NRO_APLIC_3',
                            caption: '3',
                            alignment: 'center',
                            width: 45
                        }, {
                            dataField: 'NRO_APLIC_4',
                            caption: '4',
                            alignment: 'center',
                            width: 45
                        }, {
                            dataField: 'NRO_APLIC_5',
                            caption: '5',
                            alignment: 'center',
                            width: 45
                        }, {
                            dataField: 'NRO_APLIC_6',
                            caption: '6',
                            alignment: 'center',
                            width: 45
                        }, {
                            dataField: 'NRO_APLIC_7',
                            caption: '7',
                            alignment: 'center',
                            width: 45
                        }, {
                            dataField: 'NRO_APLIC_8',
                            caption: '8',
                            alignment: 'center',
                            width: 45
                        }, {
                            dataField: 'NRO_APLIC_9',
                            caption: '9',
                            alignment: 'center',
                            width: 45
                        }, {
                            dataField: 'NRO_APLIC_10',
                            caption: '10',
                            alignment: 'center',
                            width: 45
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
                                var gridBrocaPorTalhoesDatasAplicacaoOptions = {
                                    dataSource: detailInfo.data.oDatasAplicacao,
                                    width: "850px",
                                    paging: {
                                        enabled: false
                                    },
                                    wordWrapEnabled: true,
                                    rowAlternationEnabled: true,
                                    columns: [{
                                        dataField: 'DATA_LEVANTAMENTO',
                                        caption: 'Data Levantamento',
                                        dataType: "date",
                                        alignment: 'left',
                                        width: 90
                                    }, {
                                        dataField: 'PERIODO_RECOM',
                                        caption: 'Período Recom.',
                                        alignment: 'center',
                                        width: 90
                                    }, {
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
                                        width: 475
                                    }],
                                    onCellPrepared: function (e) {
                                        if (e.rowType == 'data' && (e.columnIndex == 0 || e.columnIndex == 2)) {
                                            if (e.text == '01/01/0001') {
                                                e.cellElement.text('');
                                            };
                                        };
                                        if (e.rowType == 'data' && e.columnIndex == 3) {
                                            if (e.text == '0') {
                                                e.cellElement.text('');
                                            };
                                        };
                                    },
                                    showBorders: true,
                                    showRowLines: true,
                                    noDataText: 'Não há dados',
                                    sorting: { mode: 'none' }
                                };

                                var elementGridBrocaPorTalhoesDatasAplicacao = $('<div>').addClass("internal-grid").dxDataGrid(gridBrocaPorTalhoesDatasAplicacaoOptions)
                                elementGridBrocaPorTalhoesDatasAplicacao.appendTo(container);
                                //container.closest('td').prev().css('display', 'none');
                                container.css('padding-top', '0px');
                                container.css('padding-bottom', '0px');
                                container.attr('title', ' ');
                            }
                        }
                    };

                    var elementGridBrocaPorTalhoes = $('<div>').dxDataGrid(gridBrocaPorTalhoesOptions)
                    elementGridBrocaPorTalhoes.appendTo(container);
                    //container.closest('td').prev().css('display', 'none');
                    container.css('padding-top', '0px');
                    container.css('padding-bottom', '0px');
                    container.attr('title', ' ');
                }
            }
        };
        //#endregion GRID BROCAS

        //#region Funções HELPER

        //#endregion Funções HELPER

    };
})();
