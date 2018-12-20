Imports System.Web.Optimization

Public Class BundleConfig
    ' For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/WebFormsJs").Include(
                        "~/Scripts/WebForms/WebForms.js",
                        "~/Scripts/WebForms/WebUIValidation.js",
                        "~/Scripts/WebForms/MenuStandards.js",
                        "~/Scripts/WebForms/Focus.js",
                        "~/Scripts/WebForms/GridView.js",
                        "~/Scripts/WebForms/DetailsView.js",
                        "~/Scripts/WebForms/TreeView.js",
                        "~/Scripts/WebForms/WebParts.js"))

        ' Order is very important for these files to work, they have explicit dependencies
        bundles.Add(New ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"))

        ' Use the Development version of Modernizr to develop with and learn from. Then, when you’re
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"))

        'CENÁRIO GERENCIAL Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcengerencial").Include(
                        "~/Content/dx.common.css",
                        "~/Content/dx.light.compact.css"))

        bundles.Add(New StyleBundle("~/Content/csspagehistprop").Include(
                        "~/frmUsina/cnGerencial/HistoricoPropriedadeJS/css/pagehistprop.css"))

        bundles.Add(New StyleBundle("~/Content/csspagectrlbroca").Include(
                        "~/frmUsina/cnGerencial/ControleBrocaJS/css/pagectrlbroca.css"))

        'CENÁRIO GERENCIAL Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcengerencial").Include(
                        "~/Scripts/dx.webappjs.js",
                        "~/Scripts/dx.chartjs.js",
                        "~/Scripts/devextreme-nonNuget/js/vectormap-utils/dx.vectormaputils.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Thistprop").Include(
                        "~/frmUsina/cnGerencial/HistoricoPropriedadeJS/js/app.module.js",
                        "~/angularAppServices/ApiGetService.js",
                        "~/frmUsina/cnGerencial/HistoricoPropriedadeJS/js/app.histpropController.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tctrlpragas").Include(
                        "~/frmUsina/cnGerencial/ControleBrocaJS/js/app.module.js",
                        "~/angularAppServices/ApiGetService.js",
                        "~/frmUsina/cnGerencial/ControleBrocaJS/js/app.brocaController.js"))

        'CENÁRIO COLHEITA DE CANA Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcencolheitacana").Include(
                        "~/Content/dx.common.css",
                        "~/Content/dx.light.css"))

        bundles.Add(New StyleBundle("~/Content/csspagectrlestfrente").Include(
                        "~/frmUsina/cnEntCana/ControleEstoqueFrenteJS/css/pagectrlestfrente.css"))

        'CENÁRIO COLHEITA DE CANA Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcencolheitacana").Include(
                        "~/Scripts/dx.webappjs.js",
                        "~/Scripts/dx.chartjs.js",
                        "~/Scripts/devextreme-nonNuget/js/vectormap-utils/dx.vectormaputils.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tctrlestcolheita").Include(
                        "~/frmUsina/cnEntCana/ControleEstoqueFrenteJS/js/app.module.js",
                        "~/angularAppServices/ApiGetService.js",
                        "~/angularAppServices/ApiPostService.js",
                        "~/frmUsina/cnEntCana/ControleEstoqueFrenteJS/js/app.ctrlestController.js"))

        'CENÁRIO AGRÍCOLA COLHEITA Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcenagricolacolheita").Include(
            "~/Content/dx.common.css",
            "~/Content/dx.light.css"))

        bundles.Add(New StyleBundle("~/Content/csspageagricolacolheita").Include(
            "~/frmUsina/cnAgricola/ColheitaJS/css/pageagricolacolheita.css"))

        'CENÁRIO AGRÍCOLA COLHEITA Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcenagricolacolheita").Include(
            "~/Scripts/dx.webappjs.js",
            "~/Scripts/dx.chartjs.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tagricolacolheita").Include(
            "~/frmUsina/cnAgricola/ColheitaJS/js/app.module.js",
            "~/frmUsina/cnAgricola/ColheitaJS/angularAppServices/ApiGetService.js",
            "~/frmUsina/cnAgricola/ColheitaJS/js/app.agricolacolheitaController.js"))


        'CENÁRIO AGRÍCOLA COLHEITA ADM Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcenagricolacolheitaadm").Include(
            "~/Content/dx.common.css",
            "~/Content/dx.light.css"))

        bundles.Add(New StyleBundle("~/Content/csspageagricolacolheitaadm").Include(
            "~/frmUsina/cnAgricola/ColheitaAdmJS/css/pageagricolacolheita.css"))

        'CENÁRIO AGRÍCOLA COLHEITA ADM Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcenagricolacolheitaadm").Include(
            "~/Scripts/dx.webappjs.js",
            "~/Scripts/dx.chartjs.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tagricolacolheitaadm").Include(
            "~/frmUsina/cnAgricola/ColheitaAdmJS/js/app.module.js",
            "~/frmUsina/cnAgricola/ColheitaAdmJS/angularAppServices/ApiGetService.js",
            "~/frmUsina/cnAgricola/ColheitaAdmJS/js/app.agricolacolheitaAdmController.js"))


        'CENÁRIO AGRÍCOLA COLHEITA OPERACIONAL Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcenagricolacolheitaoper").Include(
            "~/Content/dx.common.css",
            "~/Content/dx.light.css"))

        bundles.Add(New StyleBundle("~/Content/csspageagricolacolheitaoper").Include(
            "~/frmUsina/cnAgricola/ColheitaOperJS/css/pageagricolacolheita.css"))

        'CENÁRIO AGRÍCOLA COLHEITA OPERACIONAL Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcenagricolacolheitaoper").Include(
            "~/Scripts/dx.webappjs.js",
            "~/Scripts/dx.chartjs.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tagricolacolheitaoper").Include(
            "~/frmUsina/cnAgricola/ColheitaOperJS/js/app.module.js",
            "~/frmUsina/cnAgricola/ColheitaOperJS/angularAppServices/ApiGetService.js",
            "~/frmUsina/cnAgricola/ColheitaOperJS/js/app.agricolacolheitaOperController.js"))


        'CENÁRIO INDÚSTRIA HOME Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcenindustriahome").Include(
            "~/Content/dx.common.css",
            "~/Content/dx.light.css"))

        bundles.Add(New StyleBundle("~/Content/csspageindustriahome").Include(
            "~/frmUsina/cnIndustria/HomeJS/css/pageindustriahome.css"))

        'CENÁRIO INDÚSTRIA HOME Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcenindustriahome").Include(
            "~/Scripts/dx.webappjs.js",
            "~/Scripts/dx.chartjs.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tindustriahome").Include(
            "~/frmUsina/cnIndustria/HomeJS/js/app.module.js",
            "~/frmUsina/cnIndustria/HomeJS/angularAppServices/ApiGetService.js",
            "~/frmUsina/cnIndustria/HomeJS/js/app.industriahomeController.js"))


        'CENÁRIO INDÚSTRIA MOAGEM Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcenindustriamoagem").Include(
            "~/Content/dx.common.css",
            "~/Content/dx.light.css"))

        bundles.Add(New StyleBundle("~/Content/csspageindustriamoagem").Include(
            "~/frmUsina/cnIndustria/MoagemJS/css/pageindustriamoagem.css"))

        'CENÁRIO INDÚSTRIA MOAGEM Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcenindustriamoagem").Include(
            "~/Scripts/dx.webappjs.js",
            "~/Scripts/dx.chartjs.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tindustriamoagem").Include(
            "~/frmUsina/cnIndustria/MoagemJS/js/app.module.js",
            "~/frmUsina/cnIndustria/MoagemJS/angularAppServices/ApiGetService.js",
            "~/frmUsina/cnIndustria/MoagemJS/js/app.industriamoagemController.js"))

        'CENÁRIO INDÚSTRIA ENERGIA BIO Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcenindustriaenergiabio").Include(
            "~/Content/dx.common.css",
            "~/Content/dx.light.css"))

        bundles.Add(New StyleBundle("~/Content/csspageindustriaenergiabio").Include(
            "~/frmUsina/cnIndustria/EnergiaBioJS/css/pageindustriaenergiabio.css"))

        'CENÁRIO INDÚSTRIA ENERGIA BIO Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcenindustriaenergiabio").Include(
            "~/Scripts/dx.webappjs.js",
            "~/Scripts/dx.chartjs.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tindustriaenergiabio").Include(
            "~/frmUsina/cnIndustria/EnergiaBioJS/js/app.module.js",
            "~/frmUsina/cnIndustria/EnergiaBioJS/angularAppServices/ApiGetService.js",
            "~/frmUsina/cnIndustria/EnergiaBioJS/js/app.industriaenergiabioController.js"))

        'CENÁRIO INDÚSTRIA ENERGIA UAM Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcenindustriaenergiauam").Include(
            "~/Content/dx.common.css",
            "~/Content/dx.light.css"))

        bundles.Add(New StyleBundle("~/Content/csspageindustriaenergiauam").Include(
            "~/frmUsina/cnIndustria/EnergiaUamJS/css/pageindustriaenergiauam.css"))

        'CENÁRIO INDÚSTRIA ENERGIA UAM Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcenindustriaenergiauam").Include(
            "~/Scripts/dx.webappjs.js",
            "~/Scripts/dx.chartjs.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tindustriaenergiauam").Include(
            "~/frmUsina/cnIndustria/EnergiaUamJS/js/app.module.js",
            "~/frmUsina/cnIndustria/EnergiaUamJS/angularAppServices/ApiGetService.js",
            "~/frmUsina/cnIndustria/EnergiaUamJS/js/app.industriaenergiauamController.js"))


        'CENÁRIO INDÚSTRIA PRODUÇÃO AÇÚCAR Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcenindustriaacucar").Include(
            "~/Content/dx.common.css",
            "~/Content/dx.light.css"))

        bundles.Add(New StyleBundle("~/Content/csspageindustriaacucar").Include(
            "~/frmUsina/cnIndustria/AcucarJS/css/pageindustriaacucar.css"))

        'CENÁRIO INDÚSTRIA PRODUÇÃO AÇÚCAR Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcenindustriaacucar").Include(
            "~/Scripts/dx.webappjs.js",
            "~/Scripts/dx.chartjs.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tindustriaacucar").Include(
            "~/frmUsina/cnIndustria/AcucarJS/js/app.module.js",
            "~/frmUsina/cnIndustria/AcucarJS/angularAppServices/ApiGetService.js",
            "~/frmUsina/cnIndustria/AcucarJS/js/app.industriaacucarController.js"))


        'CENÁRIO INDÚSTRIA PRODUÇÃO ETANOL Css
        bundles.Add(New StyleBundle("~/Content/dxcss4Tcenindustriaetanol").Include(
            "~/Content/dx.common.css",
            "~/Content/dx.light.css"))

        bundles.Add(New StyleBundle("~/Content/csspageindustriaetanol").Include(
            "~/frmUsina/cnIndustria/EtanolJS/css/pageindustriaetanol.css"))

        'CENÁRIO INDÚSTRIA PRODUÇÃO ETANOL Javascript
        bundles.Add(New ScriptBundle("~/bundles/dx4Tcenindustriaetanol").Include(
            "~/Scripts/dx.webappjs.js",
            "~/Scripts/dx.chartjs.js"))

        bundles.Add(New ScriptBundle("~/bundles/app4Tindustriaetanol").Include(
            "~/frmUsina/cnIndustria/EtanolJS/js/app.module.js",
            "~/frmUsina/cnIndustria/EtanolJS/angularAppServices/ApiGetService.js",
            "~/frmUsina/cnIndustria/EtanolJS/js/app.industriaetanolController.js"))


        ScriptManager.ScriptResourceMapping.AddDefinition("respond", New ScriptResourceDefinition() With {
                .Path = "~/Scripts/respond.min.js",
                .DebugPath = "~/Scripts/respond.js"})

    End Sub
End Class
