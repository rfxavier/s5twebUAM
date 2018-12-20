Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Web.Http
Imports Oracle.DataAccess.Client

<RoutePrefix("api/AgricolaColheitaOper")>
    Public Class AgricolaColheitaOperController
        Inherits ApiController
    Private Property QueryAgricolaColheitaAdmEquipamento As String = "SELECT ID_NEGOCIOS, SAFRA, MES, SEMANA, DIA, FRENTE, DESC_FRENTE, CLASSE_EQUIP, NRO_EQUIPAMENTO, ID_INDICADOR, DSC_INDICADOR, META, REALIZADO, TIPO_PLANEJAMENTO, DS_OBS FROM BI4T.INDICADORES_COLHEITA_EQUIP WHERE TIPO_INDICADOR = 'A' AND ID_INDICADOR IN (36,37,48,43,44,45)"

    <DataContract>
    Public Class S5TAgricolaColheitaEquipamento
        Public Property ID_NEGOCIOS As Integer
        Public Property SAFRA As Integer
        Public Property MES As Integer
        Public Property SEMANA As Integer
        Public Property DIA As DateTime
        Public Property FRENTE As Integer
        Public Property DESC_FRENTE As String
        Public Property CLASSE_EQUIP As String
        Public Property NRO_EQUIPAMENTO As Integer
        Public Property ID_INDICADOR As Integer
        Public Property DSC_INDICADOR As String
        Public Property META As Double
        Public Property REALIZADO As Double
        Public Property TIPO_PLANEJAMENTO As String
        Public Property DS_OBS As String
    End Class


    <DataContract>
    Public Class S5TAgricolaOperacional
        <DataMember>
        Public Property frenteCodigo As Integer
        <DataMember>
        Public Property frenteDescricao As String
        <DataMember>
        Public Property caminhaoI36Realizado As Double
        <DataMember>
        Public Property caminhaoI36Meta As Double
        <DataMember>
        Public Property caminhaoI37Realizado As Double
        <DataMember>
        Public Property caminhaoI37Meta As Double
        <DataMember>
        Public Property colhedoraI48Realizado As Double
        <DataMember>
        Public Property colhedoraI48Meta As Double
        <DataMember>
        Public Property textoColhedoraI43 As String
        <DataMember>
        Public Property textoColhedoraI44 As String
        <DataMember>
        Public Property textoColhedoraI45 As String
    End Class

    ' GET api/AgricolaColheitaOper/VisaoGeralMinMaxDia/1
    <HttpGet>
    <Route("VisaoGeralMinMaxDia/{parIdNegocios}")>
    Public Function GetValuesMaxDia(parIdNegocios As Integer) As IHttpActionResult
        Return Ok(GetAgricolaColheitaOperPorSafraMinMaxDia(parIdNegocios))
    End Function

    Public Function GetAgricolaColheitaOperPorSafraMinMaxDia(parIdNegocios As Integer) As Object
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosMoagem As New OracleCommand(
            "SELECT MAX(SAFRA) SAFRA, MIN(DIA) MINDIA, MAX(DIA) MAXDIA FROM BI4T.INDICADORES_COLHEITA_EQUIP WHERE TIPO_INDICADOR = 'A' AND ID_NEGOCIOS = :p0 AND ID_INDICADOR IN (36,37,48,43,44,45)",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosMoagem.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios

        Dim varSafra As Integer

        Dim varMinDia As Date
        Dim varMaxDia As Date

        conn.Open()

        Dim drDadosMoagem As OracleDataReader = Nothing
        Try
            drDadosMoagem = cmdDadosMoagem.ExecuteReader()
            If drDadosMoagem.HasRows Then
                Do While drDadosMoagem.Read
                    varSafra = Nvl(drDadosMoagem.Item("SAFRA"), 0)

                    varMinDia = Nvl(drDadosMoagem.Item("MINDIA"), DateTime.MinValue)
                    varMaxDia = Nvl(drDadosMoagem.Item("MAXDIA"), DateTime.MinValue)
                Loop

                drDadosMoagem.Close()
            End If
        Catch ex As Exception
            'Return InternalServerError(ex)
        Finally
            conn.Close()
            If (Not (drDadosMoagem) Is Nothing) Then
                drDadosMoagem.Dispose()
            End If
        End Try

        GetAgricolaColheitaOperPorSafraMinMaxDia = New With {Key .safra = varSafra,
                                                             Key .minDia = varMinDia, 
                                                             Key .maxDia = varMaxDia}
    End Function

    ' *** POR DIA
    ' GET api/AgricolaColheitaOper/PorDia/1/2018/20180606
    <HttpGet>
    <Route("PorDia/{parIdNegocios}/{parSafra}/{parDia}")>
    Public Function GetValuesEquipPorDia(parIdNegocios As Integer, parSafra As Integer, parDia As String) As IHttpActionResult
        Dim varDia = DateTime.ParseExact(parDia, "yyyyMMdd", CultureInfo.InvariantCulture)

        Dim dadosColheita = GetAgricolaColheitaEquipamentoPorDiaPlain(parIdNegocios, parSafra, varDia)

        Dim dadosColheitaAgrupado = GetAgricolaColheitaEquipamentoAgrupadoPorDia(dadosColheita)

        Return Ok(dadosColheitaAgrupado)
    End Function

    Private Function GetAgricolaColheitaEquipamentoAgrupadoPorDia(parDadosColheita As List(Of S5TAgricolaColheitaEquipamento)) As List(Of S5TAgricolaOperacional)
        Dim agricolaOperacional = New List(Of S5TAgricolaOperacional)

        Dim varCaminhaoI36 = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "CAMINHAO" And x.ID_INDICADOR = 36)
        Dim varCaminhaoI37 = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "CAMINHAO" And x.ID_INDICADOR = 37)
        Dim varColhedoraI48 = parDadosColheita.FindAll(Function(x) x.CLASSE_EQUIP = "COLHEDORA" And x.ID_INDICADOR = 48)
        Dim varColhedoraI43 = parDadosColheita.FindAll(Function(x) x.ID_INDICADOR = 43)
        Dim varColhedoraI44 = parDadosColheita.FindAll(Function(x) x.ID_INDICADOR = 44)
        Dim varColhedoraI45 = parDadosColheita.FindAll(Function(x) x.ID_INDICADOR = 45)

        Dim varDadosColheitaAgrupadoPorFrente = parDadosColheita.GroupBy(Function(x) New With {Key .FRENTE = x.FRENTE, _
                                                                                               Key .DESC_FRENTE = x.DESC_FRENTE}).Select(Function (y) New S5TAgricolaOperacional With {.frenteCodigo = y.Min(Function(group) group.FRENTE), _
                                                                                                                                                                                       .frenteDescricao = y.Min(Function(group) GetDescricaoAbreviadaFrente(group.DESC_FRENTE))}).ToList

        For Each objAgricolaOperacional In varDadosColheitaAgrupadoPorFrente
            Dim varValorCaminhaoI36Realizado As Double = 0
            Dim varValorCaminhaoI36Meta As Double = 0
            Dim varValorCaminhaoI37Realizado  As Double = 0
            Dim varValorCaminhaoI37Meta  As Double = 0
            Dim varValorColhedoraI48Realizado As Double = 0
            Dim varValorColhedoraI48Meta As Double = 0
            Dim varTextoColhedoraI43 As String = ""
            Dim varTextoColhedoraI44 As String = ""
            Dim varTextoColhedoraI45 As String = ""

            If varCaminhaoI36.Count > 0 Then
                Dim varCaminhaoI36FrenteAtual = varCaminhaoI36.FindAll(Function(x) x.FRENTE = objAgricolaOperacional.frenteCodigo)

                If varCaminhaoI36FrenteAtual.Count > 0 Then
                    varValorCaminhaoI36Realizado = Math.Round(varCaminhaoI36FrenteAtual.FirstOrDefault.REALIZADO, 2)
                    varValorCaminhaoI36Meta = Math.Round(varCaminhaoI36FrenteAtual.FirstOrDefault.META, 2)
                End If
            End If

            If varCaminhaoI37.Count > 0 Then
                Dim varCaminhaoI37FrenteAtual = varCaminhaoI37.FindAll(Function(x) x.FRENTE = objAgricolaOperacional.frenteCodigo)

                If varCaminhaoI37FrenteAtual.Count > 0 Then
                    varValorCaminhaoI37Realizado = Math.Round(varCaminhaoI37FrenteAtual.FirstOrDefault.REALIZADO, 2)
                    varValorCaminhaoI37Meta = Math.Round(varCaminhaoI37FrenteAtual.FirstOrDefault.META, 2)
                End If
            End If

            If varColhedoraI48.Count > 0 Then
                Dim varColhedoraI48FrenteAtual = varColhedoraI48.FindAll(Function(x) x.FRENTE = objAgricolaOperacional.frenteCodigo)

                If varColhedoraI48FrenteAtual.Count > 0 Then
                    varValorColhedoraI48Realizado = Math.Round(varColhedoraI48FrenteAtual.FirstOrDefault.REALIZADO, 2)
                    varValorColhedoraI48Meta = Math.Round(varColhedoraI48FrenteAtual.FirstOrDefault.META, 2)
                End If
            End If

            If varColhedoraI43.Count > 0 Then
                Dim varColhedoraI43FrenteAtual = varColhedoraI43.FindAll(Function(x) x.FRENTE = objAgricolaOperacional.frenteCodigo)

                If varColhedoraI43FrenteAtual.Count > 0 Then
                    varTextoColhedoraI43 = varColhedoraI43FrenteAtual.FirstOrDefault.DS_OBS
                End If
            End If

            If varColhedoraI44.Count > 0 Then
                Dim varColhedoraI44FrenteAtual = varColhedoraI44.FindAll(Function(x) x.FRENTE = objAgricolaOperacional.frenteCodigo)

                If varColhedoraI44FrenteAtual.Count > 0 Then
                    varTextoColhedoraI44 = varColhedoraI44FrenteAtual.FirstOrDefault.DS_OBS
                End If
            End If

            If varColhedoraI45.Count > 0 Then
                Dim varColhedoraI45FrenteAtual = varColhedoraI45.FindAll(Function(x) x.FRENTE = objAgricolaOperacional.frenteCodigo)

                If varColhedoraI45FrenteAtual.Count > 0 Then
                    varTextoColhedoraI45 = varColhedoraI45FrenteAtual.FirstOrDefault.DS_OBS
                End If
            End If

            agricolaOperacional.Add(New S5TAgricolaOperacional With {.frenteCodigo = objAgricolaOperacional.frenteCodigo,
                                                                     .frenteDescricao = objAgricolaOperacional.frenteDescricao,
                                                                     .caminhaoI36Realizado = varValorCaminhaoI36Realizado,
                                                                     .caminhaoI36Meta = varValorCaminhaoI36Meta,
                                                                     .caminhaoI37Realizado = varValorCaminhaoI37Realizado,
                                                                     .caminhaoI37Meta = varValorCaminhaoI37Meta,
                                                                     .colhedoraI48Realizado = varValorColhedoraI48Realizado,
                                                                     .colhedoraI48Meta = varValorColhedoraI48Meta,
                                                                     .textoColhedoraI43 = varTextoColhedoraI43,
                                                                     .textoColhedoraI44 = varTextoColhedoraI44,
                                                                     .textoColhedoraI45 = varTextoColhedoraI45 })
        Next

        Return agricolaOperacional
    End Function


    Public Function GetAgricolaColheitaEquipamentoPorDiaPlain(parIdNegocios As Integer, parSafra As Integer, parDia As DateTime) As List(Of S5TAgricolaColheitaEquipamento)
        Dim conn = New OracleConnection(AppUtils.dbConnectionString)

        Dim cmdDadosColheita As New OracleCommand(
            QueryAgricolaColheitaAdmEquipamento & " AND ID_NEGOCIOS = :p0 AND SAFRA = :p1 AND DIA = :p2",
            conn) With {.CommandType = CommandType.Text}

        cmdDadosColheita.Parameters.Add(":p0", OracleDbType.Int16).Value = parIdNegocios
        cmdDadosColheita.Parameters.Add(":p1", OracleDbType.Int16).Value = parSafra
        cmdDadosColheita.Parameters.Add(":p2", OracleDbType.Date).Value = parDia

        Return GetDadosColheitaEquipamento(conn, cmdDadosColheita)
    End Function

    Private Function GetDadosColheitaEquipamento(parConnection As OracleConnection, parCommand As OracleCommand) As List(Of S5TAgricolaColheitaEquipamento)
        Dim dadosColheita As New List(Of S5TAgricolaColheitaEquipamento)

        parConnection.Open()

        Dim drDadosColheita As OracleDataReader = Nothing
        Try
            drDadosColheita = parCommand.ExecuteReader()
            If drDadosColheita.HasRows Then
                Do While drDadosColheita.Read
                    Dim objDadosColheita = New S5TAgricolaColheitaEquipamento

                    objDadosColheita.ID_NEGOCIOS = AppUtils.Nvl(drDadosColheita.Item("ID_NEGOCIOS"), 0)
                    objDadosColheita.SAFRA = AppUtils.Nvl(drDadosColheita.Item("SAFRA"), 0)
                    objDadosColheita.MES = AppUtils.Nvl(drDadosColheita.Item("MES"), 0)
                    objDadosColheita.SEMANA = AppUtils.Nvl(drDadosColheita.Item("SEMANA"), 0)
                    objDadosColheita.DIA = Nvl(drDadosColheita.Item("DIA"), DateTime.MinValue)
                    objDadosColheita.FRENTE = AppUtils.Nvl(drDadosColheita.Item("FRENTE"), 0)
                    objDadosColheita.DESC_FRENTE = AppUtils.Nvl(drDadosColheita.Item("DESC_FRENTE"), "")
                    objDadosColheita.CLASSE_EQUIP = AppUtils.Nvl(drDadosColheita.Item("CLASSE_EQUIP"), "")
                    objDadosColheita.NRO_EQUIPAMENTO = AppUtils.Nvl(drDadosColheita.Item("NRO_EQUIPAMENTO"), 0)
                    objDadosColheita.ID_INDICADOR = AppUtils.Nvl(drDadosColheita.Item("ID_INDICADOR"), 0)
                    objDadosColheita.DSC_INDICADOR = AppUtils.Nvl(drDadosColheita.Item("DSC_INDICADOR"), "")
                    objDadosColheita.META = AppUtils.Nvl(drDadosColheita.Item("META"), 0)
                    objDadosColheita.REALIZADO = AppUtils.Nvl(drDadosColheita.Item("REALIZADO"), 0)
                    objDadosColheita.TIPO_PLANEJAMENTO = AppUtils.Nvl(drDadosColheita.Item("TIPO_PLANEJAMENTO"), "")
                    objDadosColheita.DS_OBS = AppUtils.Nvl(drDadosColheita.Item("DS_OBS"), "")

                    dadosColheita.Add(objDadosColheita)
                Loop

                drDadosColheita.Close()
            End If
        Catch ex As Exception
            'Return InternalServerError(ex)
        Finally
            parConnection.Close()
            If (Not (drDadosColheita) Is Nothing) Then
                drDadosColheita.Dispose()
            End If
        End Try

        GetDadosColheitaEquipamento = dadosColheita
    End Function

    Private Function GetDescricaoAbreviadaFrente(parFrenteDescricao As String) As String
        Dim varFrenteDescricao = parFrenteDescricao

        varFrenteDescricao = varFrenteDescricao.Replace("-","").Replace(" ","")

        GetDescricaoAbreviadaFrente = varFrenteDescricao
    End Function

End Class
