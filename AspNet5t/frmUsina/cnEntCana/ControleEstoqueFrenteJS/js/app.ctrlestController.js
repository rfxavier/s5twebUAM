/*! 
* Autor: Renato Ferreira Xavier
* Data: abril/2016
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
        .controller("controleEstColheitaCtrl", ['$scope', '$document', 'ApiGetService', 'ApiPostService', controleEstColheitaCtrl])
    
    function controleEstColheitaCtrl($scope, $document, ApiGetService, ApiPostService) {
        //#region $scope empty object declarations

        //Timer tempo
        $scope.tempoTimer = 0;

        //dxVectorMap Mapa Propriedade
        $scope.mapaPropriedadeOptions = {};
        $scope.mapaPropriedadeInstance = null;

        //Dados "parseados" do .SHP e .DBF, que entrarão no layers.data do dxVectorMap
        $scope.mapaPropriedadesLayerData = {};
        $scope.mapaMunicipiosLayerData = {};

        $scope.numeroSafraAtual = new Date().getFullYear();

        //Array Principal
        $scope.estoqueColheitaFrenteArray = {};

        //Grid Totais
        $scope.totaisArray = {};
        $scope.gridTotaisDataSource = {};
        $scope.gridTotaisOptions = {};
        $scope.gridTotaisInstance = null;

        //Grid Frentes
        $scope.frentesArray = {};
        $scope.gridFrentesDataSource = {};
        $scope.gridFrentesOptions = {};
        $scope.gridFrentesInstance = null;

        //Array talhões selecionados
        $scope.talhoesSelecionadosArray = [];

        //Botão Encerrar
        $scope.botaoEncerrarInstance = null;
        $scope.botaoEncerrarTexto = 'Encerrar';
        $scope.botaoEncerrarDisabled = true;

        //Grids Detalhe: Fazenda Talhões - Instances de cada um
        $scope.gridsFrenteFazendaTalhoesInstances = {};

        //Permissão de usuário para update
        $scope.usuarioPermissaoUpdate = false;

        //Array para aplicar aos elementos de mapa (painting e tooltip)
        $scope.fazendasdetArray = {};

        //
        $scope.loadingVisible = false;

        //
        $scope.showDiv = false;

        //
        $scope.msgShowDiv = 'Esconder Resumo';

        //#endregion $scope empty object declarations

        $('#updateNow').click(function () {
            clearInterval(timeinterval);
            $scope.loadingVisible = true;


            AtualizaGridsRecoloreMapa()
                .then(function () {

                    var timeInMinutes = $scope.tempoTimer;
                    var currentTime = Date.parse(new Date());
                    var deadline = new Date(currentTime + timeInMinutes * 60 * 1000);

                    initializeClock('clockdiv', deadline);
                    $scope.loadingVisible = false;

                });

            return false;
        });

        //$('#toggleGrid').click(function () {
        //    $scope.showDiv = !$scope.showDiv;
        //    return false;
        //});

        $scope.toggleGrid = function () {
            $scope.showDiv = $scope.showDiv === false ? true : false;

            if ($scope.showDiv) {
                //hidden
                $scope.msgShowDiv = 'Mostrar Resumo';

                $scope.mapaPropriedadeInstance.option({
                    size: {
                        width: document.documentElement.clientWidth - 60
                    }
                });
            } else {
                //shown
                $scope.msgShowDiv = 'Esconder Resumo';

                $scope.mapaPropriedadeInstance.option({
                    size: {
                        width: document.documentElement.clientWidth - 520
                    }
                });
            };

        };

        var timeinterval;

        function getTimeRemaining(endtime) {
            var t = Date.parse(endtime) - Date.parse(new Date());
            var seconds = Math.floor((t / 1000) % 60);
            var minutes = Math.floor((t / 1000 / 60) % 60);
            var hours = Math.floor((t / (1000 * 60 * 60)) % 24);
            var days = Math.floor(t / (1000 * 60 * 60 * 24));
            return {
                'total': t,
                'days': days,
                'hours': hours,
                'minutes': minutes,
                'seconds': seconds
            };
        };

        function initializeClock(id, endtime) {
            var clock = document.getElementById(id);
            var hoursSpan = clock.querySelector('.hours');
            var minutesSpan = clock.querySelector('.minutes');
            var secondsSpan = clock.querySelector('.seconds');

            function updateClock() {
                var t = getTimeRemaining(endtime);

                hoursSpan.innerHTML = ('0' + t.hours).slice(-2);
                minutesSpan.innerHTML = ('0' + t.minutes).slice(-2);
                secondsSpan.innerHTML = ('0' + t.seconds).slice(-2);

                if (t.total <= 0) {
                    clearInterval(timeinterval);
                    $scope.loadingVisible = true;


                    AtualizaGridsRecoloreMapa()
                        .then(function () {

                            var timeInMinutes = $scope.tempoTimer;
                            var currentTime = Date.parse(new Date());
                            var deadline = new Date(currentTime + timeInMinutes * 60 * 1000);

                            initializeClock('clockdiv', deadline);
                            $scope.loadingVisible = false;

                        });
                }
            }

            updateClock();
            timeinterval = setInterval(updateClock, 1000);
        };

        function AtualizaGridsRecoloreMapa() {
            var promise = new Promise(function (resolve, reject) {
                ApiGetService
                     .getestoqueColheitaFrentePromise()
                     .then(function (data) {
                         $scope.estoqueColheitaFrenteArray = data;

                         $scope.totaisArray = data.oTotais;
                         $scope.frentesArray = data.oFrentes;
                         $scope.fazendasdetArray = data.oFazendasDetalhe;

                         $scope.gridTotaisInstance.refresh();
                         $scope.gridFrentesInstance.refresh();

                         $scope.botaoEncerrarDisabled = true;
                         $scope.botaoEncerrarTexto = 'Encerrar';

                         ColoreMapaElementos();

                         resolve();
                     });
            });

            return promise;
        };

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
                $.extend(parseData.features[i].properties, { PROP_CODIGDESC: parseData.features[i].properties.PROP_CODIG + '-' + parseData.features[i].properties.PROP_DESCR});
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
                                    dataField: 'PROP_CODIGDESC',
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
                            tooltip: {
                                enabled: true,
                                customizeTooltip: function (arg) {
                                    if (arg.layer.index == 1) {
                                        if ($scope.fazendasdetArray.length !== undefined) {
                                            var objPropriedade = $scope.fazendasdetArray.filter(function (obj) {
                                                return obj.COD_PROP == arg.attribute("PROP_CODIG");
                                            });
                                        } else {
                                            var objPropriedade = [];
                                        };

                                        if (objPropriedade.length == 0) {
                                            var node = $("<div>")
                                                .append("<h5 class='centerBlock'>" + arg.attribute("PROP_CODIG") + "</h5>")
                                                .append("<h5 class='centerBlock'>" + arg.attribute("PROP_DESCR") + "</h5>");
                                        } else {
                                            var node = $("<div>")
                                                .append("<h5 class='centerBlock'>" + objPropriedade[0].FRENTE_LIB_STR + "</h5>")
                                                .append("<h5 class='centerBlock'>" + arg.attribute("PROP_CODIG") + "</h5>")
                                                .append("<h5 class='centerBlock'>" + arg.attribute("PROP_DESCR") + "</h5>")
                                                .append("<br/>")
                                                .append("<div><table class='tg'><tbody><tr><td class='tg-lqy6'>Carregadoras:</td><td class='tg-lqy6'>" + objPropriedade[0].CARREGADORAS + "</td></tr><tr><td class='tg-lqy6'>Média Viagens:</td><td class='tg-lqy6'>" + objPropriedade[0].MEDIA_VIAGENS.toString().replace('.', ',').replace(/\B(?=(?:\d{3})+(?!\d))/g, ".") + "</td></tr><tr><td class='tg-lqy6'>Cana Colhida:</td><td class='tg-lqy6'>&nbsp;&nbsp;&nbsp;" + objPropriedade[0].TON_COLHIDA.toString().replace('.', ',').replace(/\B(?=(?:\d{3})+(?!\d))/g, ".") + " ton</td></tr><tr><td class='tg-lqy6'>Cana a Colher:</td><td class='tg-lqy6'>&nbsp;&nbsp;&nbsp;" + objPropriedade[0].ESTOQUE_DISP.toString().replace('.', ',').replace(/\B(?=(?:\d{3})+(?!\d))/g, ".") + " ton</td></tr><tr><td class='tg-lqy6'>Tempo Restante:</td><td class='tg-lqy6'>&nbsp;&nbsp;&nbsp;" + objPropriedade[0].TEMPO + "</td></tr></tbody></table></div>")

                                                //.append("<div>" + 'Ton. Colhida: ' + objPropriedade[0].TON_COLHIDA.toString().replace('.', ',').replace(/\B(?=(?:\d{3})+(?!\d))/g, ".") + "</div>")
                                                //.append("<div>" + 'Ton. a Colher: ' + objPropriedade[0].ESTOQUE_DISP.toString().replace('.', ',').replace(/\B(?=(?:\d{3})+(?!\d))/g, ".") + "</div>")
                                                //.append("<div>" + 'Tempo restante: ' + objPropriedade[0].HORAS + ' horas' + "</div>")
                                        };
                                        return {
                                            html: node.html()
                                        };
                                    };
                                }
                            },
                            size: {
                                height: document.documentElement.clientHeight - 194,
                                width: document.documentElement.clientWidth - 520
                            },
                            bounds: [$scope.mapaPropriedadesLayerData.bbox[0], $scope.mapaPropriedadesLayerData.bbox[1], $scope.mapaPropriedadesLayerData.bbox[2], $scope.mapaPropriedadesLayerData.bbox[3]],
                            maxZoomFactor: 48,
                            zoomFactor: 2
                        });
                        //console.log(document.documentElement.clientWidth);
                        resolve();
                    });
                });

            });

            return promise;
        };

        function AdicionaArrayTalhoesEmSelecionados(codigoProp, objArrayTalhoes) {
            for (var i = $scope.talhoesSelecionadosArray.length - 1; i >= 0; i--) {
                if ($scope.talhoesSelecionadosArray[i].TALH_CODIGO_PROP === codigoProp) {
                    $scope.talhoesSelecionadosArray.splice(i, 1);
                }
            };

            $scope.talhoesSelecionadosArray = $scope.talhoesSelecionadosArray.concat(objArrayTalhoes);


            //for (var i = 0; i < objArrayTalhoes.length; i++) {
            //    var achouObjTalhao = false;

            //    for (var j = 0; j < $scope.talhoesSelecionadosArray.length; j++) {
            //        if ($scope.talhoesSelecionadosArray[j].DATA_LIB == objArrayTalhoes[i].DATA_LIB && $scope.talhoesSelecionadosArray[j].LIBE_ID_TALH == objArrayTalhoes[i].LIBE_ID_TALH && $scope.talhoesSelecionadosArray[j].LIBE_TIPO_CORTE == objArrayTalhoes[i].LIBE_TIPO_CORTE) {
            //            achouObjTalhao = true;
            //            break;
            //        }
            //    }

            //    if (!achouObjTalhao) {
            //        $scope.talhoesSelecionadosArray.push(objArrayTalhoes[i]);
            //    };
            //};
        };

        function GetCorPadraoFrente(objPropriedade) {
            var codfrente2Digitos = ("00" + objPropriedade.FRENTE_LIB).slice(-2);
            var corElemento;

            if (objPropriedade.COR_PREENCHIMENTO == 1) {
                corElemento = coresFrentesArray[objPropriedade.FRENTE_LIB - 1];
            } else {
                corElemento = 'url(#fc' + codfrente2Digitos + 'p' + objPropriedade.COR_PREENCHIMENTO + ')';
            };
            
            return corElemento;
        };

        function ColoreMapaElementos() {
            if (!$scope.mapaPropriedadeInstance.getLayers().length) { return };

            var elements = $scope.mapaPropriedadeInstance.getLayerByIndex(1).getElements();

            for (var i in elements) {
                var objPropriedade = $scope.fazendasdetArray.filter(function (obj) {
                    return obj.COD_PROP == elements[i].attribute('PROP_CODIG');
                });

                if (objPropriedade.length) {
                    //elements[i].applySettings({ color: GetCorPadraoFrente(objPropriedade[0]), borderColor: coresFrentesArray[objPropriedade[0].FRENTE_LIB - 1] });
                    elements[i].applySettings({ color: GetCorPadraoFrente(objPropriedade[0]) });

                    //if (objPropriedade[0].COR_PREENCHIMENTO == 2) {
                    //    elements[i].applySettings({ color: 'url(#fc01p4)' });
                    //} else {
                    //    elements[i].applySettings({ color: 'url(#fc01p3)' });
                    //};
                } else {
                    elements[i].applySettings({ color: '#d2d2d2', opacity: 0.4 });
                };
            };

        };


        angular.element(document).ready(function () {
            //ORDEM: 2 - Document Ready Angular

            Globalize.culture("pt-BR");

            ApiGetService
                 .getestoqueColheitaTempoTimerPromise()
                 .then(function (dataTimer) {
                     $scope.tempoTimer = dataTimer;

                     var timeInMinutes = $scope.tempoTimer;
                     var currentTime = Date.parse(new Date());
                     var deadline = new Date(currentTime + timeInMinutes * 60 * 1000);
                     //var deadline = new Date(currentTime + 22 * 1000);

                     initializeClock('clockdiv', deadline);
                 });

            ApiGetService
                 .getestoqueColheitaFrentePromise()
                 .then(function (data) {
                     $scope.estoqueColheitaFrenteArray = data;

                     $scope.totaisArray = data.oTotais;
                     $scope.frentesArray = data.oFrentes;
                     $scope.fazendasdetArray = data.oFazendasDetalhe;

                     ApiGetService
                        .getacessoUsuarioPromise(3966, usuarioAtual, 1, 'AUX_01')
                        .then(function (dataUsuario) {
                            if (dataUsuario !== "E") {
                                $scope.usuarioPermissaoUpdate = false;
                            } else {
                                $scope.usuarioPermissaoUpdate = true;
                            };

                            $scope.gridTotaisInstance.refresh();
                            $scope.gridFrentesInstance.refresh();

                        });

                     parseMapaPropriedade().then(function () {
                         ColoreMapaElementos();
                     });
                 });
        });

        //#region gridDataSources = new DevExpress.data.DataSource
        $scope.gridTotaisDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.totaisArray, { totalCount: $scope.totaisArray.length });
                else
                    deferred.resolve($scope.totaisArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.totaisArray.length);

                return deferred.promise();
            }
        });

        $scope.gridFrentesDataSource = new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var deferred = $.Deferred();

                if (loadOptions.requireTotalCount === true)
                    deferred.resolve($scope.frentesArray, { totalCount: $scope.frentesArray.length });
                else
                    deferred.resolve($scope.frentesArray);
                return deferred.promise();
            },
            totalCount: function (options) {
                var deferred = $.Deferred();

                deferred.resolve($scope.frentesArray.length);

                return deferred.promise();
            }
        });
        //#endregion gridDataSources = new DevExpress.data.DataSource

        //#region GRID TOTAIS Options
        //$scope.gridTotaisOptions
        $scope.gridTotaisOptions = {
            dataSource: $scope.gridTotaisDataSource,
            width: "376px",
            onRowPrepared: function (e) {
                if (e.rowType == 'header') {
                    e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                };
            },
            onRowClick: function (e) {
                //$scope.mapaPropriedadeInstance.zoomFactor(1);
                $scope.mapaPropriedadeInstance.option({
                    bounds: [$scope.mapaPropriedadesLayerData.bbox[0], $scope.mapaPropriedadesLayerData.bbox[1], $scope.mapaPropriedadesLayerData.bbox[2], $scope.mapaPropriedadesLayerData.bbox[3]]
                });
            },
            columns: [{
                dataField: "DESCRICAO",
                caption: "",
                alignment: "left",
                width: 137
            }, {
                dataField: "ESTOQUE_DISP",
                caption: "Estoque",
                dataType: "number",
                format: "fixedPoint",
                precision: 0,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 75
            },
            {
                dataField: "TEMPO",
                caption: "Tempo",
                alignment: "center",
                width: 90
            }, {
                width: 70
            }],
            onInitialized: function (e) {
                $scope.gridTotaisInstance = e.component;
            },
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
        //#endregion GRID TOTAIS Options

        //#region GRID FRENTES Options
        //$scope.gridFrentesOptions
        $scope.gridFrentesOptions = {
            dataSource: $scope.gridFrentesDataSource,
            width: "376px",
            onRowPrepared: function (e) {
                if (e.rowType == 'header') {
                    e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                };
            },

            columns: [{
                dataField: "FRENTE_LIB_STR",
                caption: "Frente",
                alignment: "left",
                width: 107
            }, {
                dataField: "ESTOQUE_DISP",
                caption: "Estoque",
                dataType: "number",
                format: "fixedPoint",
                precision: 0,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 75
            },
            {
                dataField: "TEMPO",
                caption: "Tempo",
                alignment: "center",
                width: 90
            }, {
                dataField: "NR_VIAGEM_REST",
                caption: "V. Rest.",
                dataType: "number",
                format: "fixedPoint",
                precision: 0,
                customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                width: 70
            }],
            onInitialized: function (e) {
                $scope.gridFrentesInstance = e.component;
            },
            showBorders: true,
            showRowLines: true,
            sorting: { mode: 'none' },
            loadPanel: {
                enabled: false,
                text: 'Carregando...'
            },
            wordWrapEnabled: true,
            noDataText: '',
            //onRowPrepared: function (info) {
            //    info.rowElement.find('.dx-datagrid-group-closed').removeClass("dx-datagrid-group-closed dx-datagrid-expand");
            //},
            masterDetail: {
                enabled: true,
                template: function (container, detailInfo) {
                    var gridFrenteFazendasOptions = {
                        dataSource: detailInfo.data.oFazendas,
                        width: "344px",
                        paging: {
                            enabled: false
                        },
                        rowAlternationEnabled: true,
                        onRowPrepared: function (e) {
                            if (e.rowType == 'header') {
                                e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                            };
                        },
                        onRowClick: function (e) {
                            //console.log(e.data);
                            if (e.data.COORD_LONG !== 0 && e.data.COORD_LAT !== 0) {
                                $scope.mapaPropriedadeInstance.center([e.data.COORD_LONG, e.data.COORD_LAT]).zoomFactor(12)
                            };
                            //if (e.data.COD_PROP == 100) {
                            //    $scope.mapaPropriedadeInstance.center([-47.85552, -20.36143]).zoomFactor(12)
                            //} else if (e.data.COD_PROP == 185) {
                            //    $scope.mapaPropriedadeInstance.center([-47.64172, -20.51426]).zoomFactor(12)
                            //};
                        },
                        columns: [{
                            dataField: "COD_PROP",
                            caption: "Cód.Prop.",
                            alignment: "left",
                            width: 76
                        }, {
                            dataField: "ESTOQUE_DISP",
                            caption: "Estoque",
                            dataType: "number",
                            format: "fixedPoint",
                            precision: 0,
                            customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                            width: 75
                        },
                        {
                            dataField: "TEMPO",
                            caption: "Tempo",
                            alignment: "center",
                            width: 90
                        }, {
                            dataField: "NR_VIAGEM_REST",
                            caption: "V. Rest.",
                            dataType: "number",
                            format: "fixedPoint",
                            precision: 0,
                            customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                            width: 70
                        }],
                        showBorders: true,
                        showRowLines: true,
                        noDataText: '',
                        sorting: { mode: 'none' },
                        //onRowPrepared: function (info) {
                        //    if (info.rowType == 'data' && info.data.oDatasAplicacao.length == 0)
                        //        info.rowElement.find('.dx-datagrid-group-closed').removeClass("dx-datagrid-group-closed dx-datagrid-expand");
                        //},
                        masterDetail: {
                            enabled: true,
                            template: function (container, detailInfo) {
                                var selectionMode;
                                //if aqui para determinar se vai ter selection mode conforme o usuário
                                if ($scope.usuarioPermissaoUpdate) {
                                    selectionMode = "multiple";
                                } else {
                                    selectionMode = "none";
                                };


                                var gridFrenteFazendaTalhoesOptions = {
                                    dataSource: detailInfo.data.oTalhoes,
                                    width: "312px",
                                    paging: {
                                        enabled: false
                                    },
                                    selection: {
                                        mode: selectionMode,
                                        showCheckBoxesMode: "always"
                                    },
                                    onSelectionChanged: function (selectedItems) {
                                        AdicionaArrayTalhoesEmSelecionados(detailInfo.data.oTalhoes[0].TALH_CODIGO_PROP, selectedItems.selectedRowsData);

                                        if ($scope.talhoesSelecionadosArray.length > 0) {
                                            clearInterval(timeinterval);
                                            $scope.botaoEncerrarDisabled = false;
                                            if ($scope.talhoesSelecionadosArray.length == 1) {
                                                $scope.botaoEncerrarTexto = 'Encerrar 1 talhão';
                                            } else {
                                                $scope.botaoEncerrarTexto = 'Encerrar ' + $scope.talhoesSelecionadosArray.length + ' talhões';
                                            };
                                        } else {
                                            $scope.botaoEncerrarDisabled = true;
                                            $scope.botaoEncerrarTexto = 'Encerrar';

                                            var timeInMinutes = $scope.tempoTimer;
                                            var currentTime = Date.parse(new Date());
                                            var deadline = new Date(currentTime + timeInMinutes * 60 * 1000);

                                            initializeClock('clockdiv', deadline);
                                        };

                                        $scope.botaoEncerrarInstance.repaint();
                                    },
                                    onContentReady: function (e) {
                                        e.component.columnOption("command:select", "visibleIndex", 8);
                                        e.component.columnOption("command:select", "width", 70);
                                    },
                                    wordWrapEnabled: true,
                                    rowAlternationEnabled: true,
                                    onRowPrepared: function (e) {
                                        if (e.rowType == 'header') {
                                            e.rowElement.css('background', 'rgba(0, 38, 255, 0.17)');
                                        };
                                    },
                                    columns: [{
                                        width: 0
                                    }, {
                                        dataField: "TALH_CODIGO",
                                        caption: "Talhão",
                                        alignment: "left",
                                        width: 75
                                    }, {
                                        dataField: "ESTOQUE_DISP",
                                        caption: "Estoque",
                                        dataType: "number",
                                        format: "fixedPoint",
                                        precision: 0,
                                        customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                                        width: 75
                                    },
                                    {
                                        dataField: "TEMPO",
                                        caption: "Tempo",
                                        alignment: "center",
                                        width: 90
                                    }],
                                    showBorders: true,
                                    showRowLines: true,
                                    noDataText: '',
                                    sorting: { mode: 'none' }
                                };

                                if (!$scope.usuarioPermissaoUpdate) {
                                    gridFrenteFazendaTalhoesOptions.columns[4] = { width: 70 };
                                };

                                container.addClass("internal-grid-container");
                                var elementGridFrenteFazendaTalhoes = $('<div>').addClass("internal-grid").dxDataGrid(gridFrenteFazendaTalhoesOptions)


                                elementGridFrenteFazendaTalhoes.appendTo(container);

                                $scope.gridsFrenteFazendaTalhoesInstances["master" + detailInfo.key.COD_PROP] = elementGridFrenteFazendaTalhoes;

                                //container.closest('td').prev().css('display', 'none');
                                container.css('padding-top', '0px');
                                container.css('padding-bottom', '0px');
                                container.attr('title', ' ');
                            }
                        }
                    };

                    var elementGridFrenteFazendas = $('<div>').dxDataGrid(gridFrenteFazendasOptions)
                    elementGridFrenteFazendas.appendTo(container);
                    //container.closest('td').prev().css('display', 'none');
                    container.css('padding-top', '0px');
                    container.css('padding-bottom', '0px');
                    container.attr('title', ' ');
                }
            }

        };
        //#endregion GRID Frentes Options

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

        //#region BUTTON ENCERRAR Options
        $scope.botaoEncerrarOptions = {
            bindingOptions: {
                text: 'botaoEncerrarTexto',
                disabled: 'botaoEncerrarDisabled',
                visible: 'usuarioPermissaoUpdate'
            },
            type: 'success',
            onInitialized: function (e) {
                $scope.botaoEncerrarInstance = e.component;
            },
            onClick: function () {
                clearInterval(timeinterval);
                $scope.loadingVisible = true;

                ApiPostService
                     .postestoqueColheitaFrentePromise($scope.talhoesSelecionadosArray)
                     .then(function (data) {
                         //limpa seleção de todos os grids
                         for (var prop in $scope.gridsFrenteFazendaTalhoesInstances) {
                             var grid = $scope.gridsFrenteFazendaTalhoesInstances[prop];
                             var dataGrid = grid.dxDataGrid('instance');
                             dataGrid.clearSelection();
                         };

                         AtualizaGridsRecoloreMapa()
                            .then(function () {

                                var timeInMinutes = $scope.tempoTimer;
                                var currentTime = Date.parse(new Date());
                                var deadline = new Date(currentTime + timeInMinutes * 60 * 1000);

                                initializeClock('clockdiv', deadline);
                                $scope.loadingVisible = false;

                            });

                         //ApiGetService
                         //     .getestoqueColheitaFrentePromise()
                         //     .then(function (data) {
                         //         $scope.estoqueColheitaFrenteArray = data;

                         //         $scope.totaisArray = data.oTotais;
                         //         $scope.frentesArray = data.oFrentes;
                         //         $scope.fazendasdetArray = data.oFazendasDetalhe;

                         //         $scope.gridTotaisInstance.refresh();
                         //         $scope.gridFrentesInstance.refresh();

                         //         $scope.botaoEncerrarDisabled = true;
                         //         $scope.botaoEncerrarTexto = 'Encerrar';

                         //         ColoreMapaElementos();
                         //     });

                     });
            }
        };
        //#endregion BUTTON ENCERRAR Options

        //#region LOADPANEL Options
        $scope.loadOptions = {
            shadingColor: "rgba(0,0,0,0.4)",
            position: { of: "#panelPrincipal" },
            bindingOptions: {
                visible: "loadingVisible"
            },
            message: "Aguarde..."
        };
        //#endregion LOADPANEL Options


        //#region Funções HELPER

        //#endregion Funções HELPER

    };
})();
