Imports System.Net
Imports System.Web.Http
Imports Oracle.DataAccess.Client
Imports System.Runtime.Serialization

'ID_NEGOCIOS               NUMBER(4)    
'NR_ANO_SAFRA              NUMBER       
'NRO_DOCUMENTO             NUMBER       
'PROP_CODIGO               NUMBER       
'DS_NOME_PROPRIEDADE       VARCHAR2(31) 
'DSC_VARIEDADE             VARCHAR2(30) 
'NRO_CORTE                 NUMBER       
'FRENTE_COLHEITA           VARCHAR2(5)  
'MUNICIPIO                 NUMBER(7)    
'DESCMUNI                  VARCHAR2(50) 
'TIPO                      NUMBER       
'DESCTIPO                  VARCHAR2(30) 
'DT_ENTRADA                DATE         
'EQUIP_ENTRADA             NUMBER       
'REBOQUE                   NUMBER       
'DT_MOAGEM                 DATE         
'QT_TON_ENTREGUE_REAL      NUMBER(14,2) 
'AREA_COLHIDA              NUMBER     


'** REFERENCIAR System.Runtime.Serialization COM ADD REFERENCES
'** Catch ex As Exception - TRATAR, COMO RETORNAR RESTFULLY, O ERRO?

<DataContract>
Public Class S5TEntradaCanaDet
    Public Property ID_NEGOCIOS As Integer
    Public Property NR_ANO_SAFRA As Integer
    <DataMember>
    Public Property NRO_DOCUMENTO As Integer
    <DataMember>
    Public Property PROP_CODIGO As Integer
    <DataMember>
    Public Property DS_NOME_PROPRIEDADE As String
    <DataMember>
    Public Property DSC_VARIEDADE As String
    <DataMember>
    Public Property NRO_CORTE As Integer
    <DataMember>
    Public Property FRENTE_COLHEITA As String
    Public Property MUNICIPIO As Integer
    <DataMember>
    Public Property DESCMUNI As String
    Public Property TIPO As Integer
    <DataMember>
    Public Property DESCTIPO As String
    Public Property DT_ENTRADA As Date
    <DataMember>
    Public Property EQUIP_ENTRADA As Integer
    <DataMember>
    Public Property REBOQUE As Integer
    <DataMember>
    Public Property DT_MOAGEM As Date
    <DataMember>
    Public Property QT_TON_ENTREGUE_REAL As Double
    Public Property AREA_COLHIDA As Double
End Class

<RoutePrefix("api/EntradaCanaDet")>
Public Class EntradaCanaDetController
    Inherits ApiController

    ' GET api/<controller>
    <HttpGet>
    <Route("")>
    Public Function GetValues() As IHttpActionResult
        Dim EntradaCanaDet = New List(Of S5TEntradaCanaDet)

        If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
            Dim conn As OracleConnection = Nothing
            Dim oradbConn As String = String.Empty

            Dim oradb As String = AppUtils.dbConnectionString

            conn = New OracleConnection(oradb)
            conn.Open()

            Dim cmdEntradaCanaDet As New OracleCommand("select TRUNC(ID_NEGOCIOS) ID_NEGOCIOS, TRUNC(NR_ANO_SAFRA) NR_ANO_SAFRA, TRUNC(NRO_DOCUMENTO) NRO_DOCUMENTO, TRUNC(PROP_CODIGO) PROP_CODIGO, DS_NOME_PROPRIEDADE, DSC_VARIEDADE, TRUNC(NRO_CORTE) NRO_CORTE, FRENTE_COLHEITA, TRUNC(MUNICIPIO) MUNICIPIO, DESCMUNI, TRUNC(TIPO) TIPO, DESCTIPO, DT_ENTRADA, TRUNC(EQUIP_ENTRADA) EQUIP_ENTRADA, TRUNC(REBOQUE) REBOQUE, DT_MOAGEM, ROUND(AREA_COLHIDA,2) AREA_COLHIDA, ROUND(QT_TON_ENTREGUE_REAL,4) QT_TON_ENTREGUE_REAL from BI4T.ENTRADA_CANA_DET", conn) With {.CommandType = CommandType.Text}

            Dim drEntradaCanaDet As OracleDataReader = Nothing
            Try
                drEntradaCanaDet = cmdEntradaCanaDet.ExecuteReader()
                If drEntradaCanaDet.HasRows Then
                    Do While drEntradaCanaDet.Read
                        Dim objEntradaCanaDet = New S5TEntradaCanaDet

                        objEntradaCanaDet.ID_NEGOCIOS = AppUtils.Nvl(drEntradaCanaDet.Item("ID_NEGOCIOS"), 0)
                        objEntradaCanaDet.NR_ANO_SAFRA = AppUtils.Nvl(drEntradaCanaDet.Item("NR_ANO_SAFRA"), 0)
                        objEntradaCanaDet.NRO_DOCUMENTO = AppUtils.Nvl(drEntradaCanaDet.Item("NRO_DOCUMENTO"), 0)
                        objEntradaCanaDet.PROP_CODIGO = AppUtils.Nvl(drEntradaCanaDet.Item("PROP_CODIGO"), 0)
                        objEntradaCanaDet.DS_NOME_PROPRIEDADE = AppUtils.Nvl(drEntradaCanaDet.Item("DS_NOME_PROPRIEDADE"), "")
                        objEntradaCanaDet.DSC_VARIEDADE = AppUtils.Nvl(drEntradaCanaDet.Item("DSC_VARIEDADE"), "")
                        objEntradaCanaDet.NRO_CORTE = AppUtils.Nvl(drEntradaCanaDet.Item("NRO_CORTE"), 0)
                        objEntradaCanaDet.FRENTE_COLHEITA = AppUtils.Nvl(drEntradaCanaDet.Item("FRENTE_COLHEITA"), "")
                        objEntradaCanaDet.MUNICIPIO = AppUtils.Nvl(drEntradaCanaDet.Item("MUNICIPIO"), 0)
                        objEntradaCanaDet.DESCMUNI = AppUtils.Nvl(drEntradaCanaDet.Item("DESCMUNI"), "")
                        objEntradaCanaDet.TIPO = AppUtils.Nvl(drEntradaCanaDet.Item("TIPO"), "")
                        objEntradaCanaDet.DESCTIPO = AppUtils.Nvl(drEntradaCanaDet.Item("DESCTIPO"), "")
                        objEntradaCanaDet.DT_ENTRADA = AppUtils.Nvl(drEntradaCanaDet.Item("DT_ENTRADA"), DateTime.MinValue)
                        objEntradaCanaDet.EQUIP_ENTRADA = AppUtils.Nvl(drEntradaCanaDet.Item("EQUIP_ENTRADA"), 0)
                        objEntradaCanaDet.REBOQUE = AppUtils.Nvl(drEntradaCanaDet.Item("REBOQUE"), 0)
                        objEntradaCanaDet.DT_MOAGEM = AppUtils.Nvl(drEntradaCanaDet.Item("DT_MOAGEM"), DateTime.MinValue)
                        objEntradaCanaDet.QT_TON_ENTREGUE_REAL = AppUtils.Nvl(drEntradaCanaDet.Item("QT_TON_ENTREGUE_REAL"), 0)
                        objEntradaCanaDet.AREA_COLHIDA = AppUtils.Nvl(drEntradaCanaDet.Item("AREA_COLHIDA"), 0)

                        EntradaCanaDet.Add(objEntradaCanaDet)
                    Loop

                    drEntradaCanaDet.Close()
                End If
            Catch ex As Exception
                Return InternalServerError(ex)
            Finally
                conn.Close()
                If (Not (drEntradaCanaDet) Is Nothing) Then
                    drEntradaCanaDet.Dispose()
                End If
            End Try
        ElseIf ConfigurationManager.AppSettings("dashDbType") = "MSSqlServer" Then
            Dim S5TUamEntradaCanaDet = S5TUam.ENTRADA_CANA_DETCollection.LoadAll

            For Each objS5TUamEntradaCanaDet In S5TUamEntradaCanaDet
                Dim objEntradaCanaDet = New S5TEntradaCanaDet

                objEntradaCanaDet.ID_NEGOCIOS = objS5TUamEntradaCanaDet.ID_NEGOCIOS
                objEntradaCanaDet.NR_ANO_SAFRA = objS5TUamEntradaCanaDet.NR_ANO_SAFRA
                objEntradaCanaDet.NRO_DOCUMENTO = objS5TUamEntradaCanaDet.NRO_DOCUMENTO
                objEntradaCanaDet.PROP_CODIGO = objS5TUamEntradaCanaDet.PROP_CODIGO
                objEntradaCanaDet.DS_NOME_PROPRIEDADE = objS5TUamEntradaCanaDet.DS_NOME_PROPRIEDADE
                objEntradaCanaDet.DSC_VARIEDADE = objS5TUamEntradaCanaDet.DSC_VARIEDADE
                objEntradaCanaDet.NRO_CORTE = objS5TUamEntradaCanaDet.NRO_CORTE
                objEntradaCanaDet.FRENTE_COLHEITA = objS5TUamEntradaCanaDet.FRENTE_COLHEITA
                objEntradaCanaDet.MUNICIPIO = objS5TUamEntradaCanaDet.MUNICIPIO
                objEntradaCanaDet.DESCMUNI = objS5TUamEntradaCanaDet.DESCMUNI
                objEntradaCanaDet.TIPO = objS5TUamEntradaCanaDet.TIPO
                objEntradaCanaDet.DESCTIPO = objS5TUamEntradaCanaDet.DESCTIPO
                objEntradaCanaDet.DT_ENTRADA = objS5TUamEntradaCanaDet.DT_ENTRADA
                objEntradaCanaDet.EQUIP_ENTRADA = objS5TUamEntradaCanaDet.EQUIP_ENTRADA
                objEntradaCanaDet.REBOQUE = objS5TUamEntradaCanaDet.REBOQUE
                objEntradaCanaDet.DT_MOAGEM = objS5TUamEntradaCanaDet.DT_MOAGEM
                objEntradaCanaDet.QT_TON_ENTREGUE_REAL = objS5TUamEntradaCanaDet.QT_TON_ENTREGUE_REAL
                objEntradaCanaDet.AREA_COLHIDA = objS5TUamEntradaCanaDet.AREA_COLHIDA

                EntradaCanaDet.Add(objEntradaCanaDet)
            Next

            'EntradaCanaDet = S5TUamEntradaCanaDet.Select(Function(x) CriaEntradaCanaDet(x))
        End If

        Return Ok(EntradaCanaDet)
    End Function

    Function CriaEntradaCanaDet(parS5TUamEntradaCanaDet As S5TUam.ENTRADA_CANA_DET) As S5TEntradaCanaDet
        Return New S5TEntradaCanaDet With {.ID_NEGOCIOS = parS5TUamEntradaCanaDet.ID_NEGOCIOS, _
                                            .NR_ANO_SAFRA = parS5TUamEntradaCanaDet.NR_ANO_SAFRA, _
                                            .NRO_DOCUMENTO = parS5TUamEntradaCanaDet.NRO_DOCUMENTO, _
                                            .PROP_CODIGO = parS5TUamEntradaCanaDet.PROP_CODIGO, _
                                            .DS_NOME_PROPRIEDADE = parS5TUamEntradaCanaDet.DS_NOME_PROPRIEDADE, _
                                            .DSC_VARIEDADE = parS5TUamEntradaCanaDet.DSC_VARIEDADE, _
                                            .NRO_CORTE = parS5TUamEntradaCanaDet.NRO_CORTE, _
                                            .FRENTE_COLHEITA = parS5TUamEntradaCanaDet.FRENTE_COLHEITA, _
                                            .MUNICIPIO = parS5TUamEntradaCanaDet.MUNICIPIO, _
                                            .DESCMUNI = parS5TUamEntradaCanaDet.DESCMUNI, _
                                            .TIPO = parS5TUamEntradaCanaDet.TIPO, _
                                            .DESCTIPO = parS5TUamEntradaCanaDet.DESCTIPO, _
                                            .DT_ENTRADA = parS5TUamEntradaCanaDet.DT_ENTRADA, _
                                            .EQUIP_ENTRADA = parS5TUamEntradaCanaDet.EQUIP_ENTRADA, _
                                            .REBOQUE = parS5TUamEntradaCanaDet.REBOQUE, _
                                            .DT_MOAGEM = parS5TUamEntradaCanaDet.DT_MOAGEM, _
                                            .QT_TON_ENTREGUE_REAL = parS5TUamEntradaCanaDet.QT_TON_ENTREGUE_REAL, _
                                            .AREA_COLHIDA = parS5TUamEntradaCanaDet.AREA_COLHIDA}
    End Function

    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
