Imports DevExpress.DataAccess.ConnectionParameters
Imports Microsoft.AspNet.Identity
Imports Oracle.DataAccess.Client

Public Class cnEntCanaColheitaSeqMapa
    Inherits System.Web.UI.Page
    Private Class S5TFrenteColheita
        Private _pCodFrente As Integer
        Public Property pCodFrente() As Integer
            Get
                Return _pCodFrente
            End Get
            Set(ByVal value As Integer)
                _pCodFrente = value
            End Set
        End Property

        Private _pDescFrente As String
        Public Property pDescFrente() As String
            Get
                Return _pDescFrente
            End Get
            Set(ByVal value As String)
                _pDescFrente = value
            End Set
        End Property
    End Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dr As OracleDataReader = Nothing

        If (Not Page.IsCallback) And (Not Page.IsPostBack) Then
            ASPxDashboardViewer1.DashboardId = AppUtils.dashboardEnumToString(dashboardsList.dashCnEntCanaEntradasSequencialColheita)

            LogUserAccess(User.Identity.GetUserName, Me.Page.AppRelativeVirtualPath)

            Dim dsComboFrentes As List(Of S5TFrenteColheita)

            If ConfigurationManager.AppSettings("dashDbType") = "Oracle" Then
                'FAZ TRATAMENTO DE FRENTES DE COLHEITA
                dsComboFrentes = New List(Of S5TFrenteColheita)

                Dim oradbConn As String = AppUtils.dbConnectionString

                Dim oradb As String = String.Format(oradbConn)

                Dim conn As OracleConnection = New OracleConnection(oradb)
                conn.Open()

                Try
                    Dim cmd As New OracleCommand("SELECT V.FRENTE FROM BI4T.V_ACESSO_DET V WHERE V.USUARIO = :p0 and V.FRENTE IS NOT NULL", conn) With {.CommandType = CommandType.Text}

                    cmd.Parameters.Add(":p0", OracleDbType.Varchar2).Value = Context.User.Identity.Name.ToUpper

                    Try
                        dr = cmd.ExecuteReader()
                        If dr.HasRows Then
                            'USUÁRIO TEM INDICAÇÃO DE FRENTES
                            Do While dr.Read
                                Dim objFrenteColheita = New S5TFrenteColheita
                                objFrenteColheita.pCodFrente = Convert.ToInt16(dr.Item("FRENTE"))
                                objFrenteColheita.pDescFrente = "FC" & dr.Item("FRENTE").ToString.Trim.PadLeft(2, "0")
                                dsComboFrentes.Add(objFrenteColheita)
                            Loop

                            dr.Close()
                        Else
                            'USUÁRIO TEM PERMISSÃO PARA TODAS AS FRENTES
                            'Dim objFrenteColheitaTodas = New S5TFrenteColheita
                            'objFrenteColheitaTodas.pCodFrente = 0
                            'objFrenteColheitaTodas.pDescFrente = "(Todas as Frentes)"
                            'dsComboFrentes.Add(objFrenteColheitaTodas)

                            For i = 1 To 10
                                Dim objFrenteColheita = New S5TFrenteColheita
                                objFrenteColheita.pCodFrente = i
                                objFrenteColheita.pDescFrente = "FC" & i.ToString.Trim.PadLeft(2, "0")
                                dsComboFrentes.Add(objFrenteColheita)
                            Next
                        End If
                    Finally
                        If (Not (dr) Is Nothing) Then
                            dr.Dispose()
                        End If
                    End Try
                Catch ex As Exception

                Finally
                    conn.Close()
                End Try
            Else
                dsComboFrentes = New List(Of S5TFrenteColheita)

                For i = 1 To 10
                    Dim objFrenteColheita = New S5TFrenteColheita
                    objFrenteColheita.pCodFrente = i
                    objFrenteColheita.pDescFrente = "FC" & i.ToString.Trim.PadLeft(2, "0")
                    dsComboFrentes.Add(objFrenteColheita)
                Next
            End If

            cmbFrente.DataSource = dsComboFrentes
            cmbFrente.ValueField = "pCodFrente"
            cmbFrente.ValueType = GetType(System.Int32)
            cmbFrente.TextField = "pDescFrente"
            cmbFrente.SelectedIndex = 0
            cmbFrente.DataBind()

        End If

    End Sub

    Private Sub ASPxDashboardViewer1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboardViewer1.ConfigureDataConnection
        e.ConnectionParameters = AppUtils.dashConnectionParameters
    End Sub

    Private Sub ASPxDashboardViewer1_CustomParameters(sender As Object, e As DevExpress.DashboardWeb.CustomParametersWebEventArgs) Handles ASPxDashboardViewer1.CustomParameters
        e.Parameters(0).Value = cmbFrente.Value.ToString
    End Sub

    Private Sub ASPxDashboardViewer1_DashboardLoading(sender As Object, e As DevExpress.DashboardWeb.DashboardLoadingEventArgs) Handles ASPxDashboardViewer1.DashboardLoading
        e.DashboardXml = AppUtils.dashXML(dashboardsList.dashCnEntCanaEntradasSequencialColheita)
    End Sub
End Class