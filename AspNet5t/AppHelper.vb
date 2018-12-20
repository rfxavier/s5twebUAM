Imports System.Runtime.ExceptionServices

Module AppHelper
    Public Sub HandleFirstTimeExceptions(ByVal varObject As Object, ByVal varException As FirstChanceExceptionEventArgs)
        Dim sSource As String
        Dim sLog As String
        Dim sEvent As String

        sSource = "ASP.NET BI4T"
        sLog = "Application"
        sEvent = "Dashboard ConfigureDataConnection: " & varException.Exception.Message

        'If Not EventLog.SourceExists(sSource) Then
        '    EventLog.CreateEventSource(sSource, sLog)
        'End If

        'If Me.Page.AppRelativeVirtualPath = "~/frmUsina/cnEntCanaMob/CertificadoHora/cnEntCanaMobEntradasCertificadoHora.aspx" Then
        EventLog.WriteEntry("ASP.NET 4.0.30319.0", sEvent, EventLogEntryType.Error)
        'End If

    End Sub

End Module
