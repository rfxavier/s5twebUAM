Imports System.Web.Http
Imports System.Net.Http.Formatting
Imports Newtonsoft.Json.Serialization

Public Class WebApiConfig
    Public Shared Sub Register(config As HttpConfiguration)
        'DEFAULTS TO JSON
        GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear()

        'Web API routes
        config.MapHttpAttributeRoutes()

        'Convention-based routing.
        'config.Routes.MapHttpRoute(name:="DefaultApi", _
        '                           routeTemplate:="api/{controller}/{id}", _
        '                           defaults:=New With {Key .id = RouteParameter.Optional})

        'IN CASE JSON PAYLOAD IS CAMELCASED, UNCOMMENT BELOW
        'Dim jsonFormatter = config.Formatters.OfType(Of JsonMediaTypeFormatter)().First()
        'jsonFormatter.SerializerSettings.ContractResolver = New CamelCasePropertyNamesContractResolver()
    End Sub

End Class
