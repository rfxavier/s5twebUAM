(function () {
    "use strict";
    angular.module('app4T')
        .controller("pivotCtrl", ['$scope', '$document', 'ApiGetService', pivotCtrl])
    
    function pivotCtrl($scope, $document, ApiGetService) {

            // being verbose, what do I have in my $scope, as empty object declarations
            $scope.entcanadetStore = {};
            $scope.pivotGridDataSourceConfig = {};
            $scope.pivotGridDataSource = {};

            $scope.pivotgridSettings = {};
            $scope.pivotgridfieldchooserSettings = {};

            $document.ready(function () {
                Globalize.culture("pt-BR");
            });

            $scope.entcanadetStore = ApiGetService.getentcanadetAgrupStore;

            $scope.pivotGridDataSourceConfig = {
                store: $scope.entcanadetStore,
                fields: [{
                    caption: "Município",
                    width: 120,
                    dataField: "DESCMUNI",
                    area: "row"
                }, {
                    caption: "Frente",
                    dataField: "FRENTE_COLHEITA",
                    customizeText: function (cellInfo) {
                        return "FC " + ("00" + cellInfo.value).slice(-2);
                    },
                    sortOrder: "asc",
                    dataType: "number",
                    area: "column"
                }, {
                    caption: "Toneladas",
                    dataField: "QT_TON_ENTREGUE_REAL",
                    dataType: "number",
                    summaryType: "sum",
                    format: "decimal",
                    isMeasure: "True",
                    customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); },
                    area: "data"
                }, {
                    dataField: "QT_TON_ENTREGUE_REAL",
                    summaryDisplayMode: "percentOfColumnGrandTotal",
                    caption: "% Linha",
                    visible: true
                }, {
                    dataField: "QT_TON_ENTREGUE_REAL",
                    summaryDisplayMode: "percentOfRowGrandTotal",
                    caption: "% Coluna",
                    visible: true
                }, {
                    caption: "Prop.Cód.",
                    dataField: "PROP_CODIGO",
                    format: ""
                }, {
                    caption: "Mês",
                    dataField: "DT_MOAGEM",
                    dataType: "date",
                    groupInterval: "month"
                }, {
                    caption: "Propriedade",
                    dataField: "DS_NOME_PROPRIEDADE",
                    format: ""
                }, {
                    caption: "Origem",
                    dataField: "DESCTIPO",
                    format: ""
                }, {
                    dataField: "DT_MOAGEM",
                    visible: false
                }, {
                    dataField: "QT_TON_ENTREGUE_REAL",
                    visible: false
                }]
            };

            $scope.pivotGridDataSource = new DevExpress.data.PivotGridDataSource($scope.pivotGridDataSourceConfig);

            $scope.drillDownDataSource = {};
            $scope.entcanaPopupVisible = false;
            $scope.entcanaPopupTitle = "";

            $scope.pivotgridSettings = {
                allowSortingBySummary: true,
                allowSorting: true,
                allowFiltering: true,
                allowExpandAll: true,
                height: 540,
                texts: {
                    grandTotal: 'Total Geral',
                    collapseAll: 'Recolher Tudo',
                    expandAll: 'Expandir Tudo',
                    noData: 'Não Contém Dados',
                    removeAllSorting: 'Remover Ordenação',
                    showFieldChooser: 'Mostrar Lista de Campos',
                    sortColumnBySummary: 'Ordenar {0} por esta coluna',
                    sortRowBySummary: 'Ordenar {0} por esta linha',
                    total: '{0} Subtotal'
                },
                loadPanel: {
                    text: 'Carregando'
                },
                "export": {
                    enabled: true,
                    fileName: "EntradaCana"
                },
                scrolling: {
                    mode: "virtual"
                },
                fieldChooser: {
                    enabled: false,
                    layout: 1,
                    height: 500,
                    title: 'Selecionar Campos',
                    texts: {
                        allFields: 'Lista de Campos',
                        columnFields: 'Colunas',
                        dataFields: 'Valores',
                        filterFields: 'Filtros',
                        rowFields: 'Linhas'
                    }
                },
                onCellClick: function (e) {
                    if (e.area == "data") {
                        var pivotGridDataSource = e.component.getDataSource(),
                            rowPathLength = e.cell.rowPath.length,
                            rowPathName = e.cell.rowPath[rowPathLength - 1],
                            popupTitle = "Detalhamento " + (rowPathName ? rowPathName : "Total");

                        $scope.drillDownDataSource = pivotGridDataSource.createDrillDownDataSource(e.cell);
                        $scope.entcanaPopupTitle = popupTitle;
                        $scope.entcanaPopupVisible = true;
                    }
                },
                dataSource: $scope.pivotGridDataSource
            };

            $scope.pivotgridfieldchooserSettings = {
                dataSource: $scope.pivotGridDataSource,
                width: 400,
                height: 600,
                layout: 2,
                title: 'Selecionar Campos',
                texts: {
                    allFields: 'Lista de Campos',
                    columnFields: 'Colunas',
                    dataFields: 'Valores',
                    filterFields: 'Filtros',
                    rowFields: 'Linhas'
                }
            };

            $scope.popupOptions = {
                width: 600,
                height: 400,
                closeOnOutsideClick: true,
                bindingOptions: {
                    title: "entcanaPopupTitle",
                    visible: "entcanaPopupVisible"
                }
            };

            $scope.datagridSettings = {
                bindingOptions: {
                    dataSource: {
                        dataPath: 'drillDownDataSource',
                        deep: false
                    }
                },
                scrolling: {
                    mode: "virtual"
                },
                width: 560,
                height: 300,
                rowAlternationEnabled: true,
                columns: [{
                    caption: "Data",
                    width: 90,
                    dataField: "DT_MOAGEM",
                    sortOrder: "asc",
                    dataType: "date"
                }, {
                    caption: "Frente",
                    width: 60,
                    dataField: "FRENTE_COLHEITA",
                    dataType: "number",
                    customizeText: function (cellInfo) {
                        return "FC " + ("00" + cellInfo.value).slice(-2);
                        },
                }, {
                    caption: "Propriedade",
                    width: 260,
                    dataField: "DS_NOME_PROPRIEDADE",
                }, {
                    caption: "Doc.",
                    width: 70,
                    dataField: "NRO_DOCUMENTO",
                    dataType: "number",
                }, {
                    caption: "Toneladas",
                    width: 80,
                    dataField: "QT_TON_ENTREGUE_REAL",
                    dataType: "number",
                    format: "decimal",
                    customizeText: function (cellInfo) { return cellInfo.valueText.replace(/\B(?=(?:\d{3})+(?!\d))/g, "."); }
                }]
            };

            $scope.pivotGridDataSource.dispose();
    };
})();
