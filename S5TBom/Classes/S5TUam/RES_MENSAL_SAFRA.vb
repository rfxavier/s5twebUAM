﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:
'
'     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
'     o código for gerado novamente.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports CodeFluent.Runtime
Imports CodeFluent.Runtime.Utilities

Namespace S5TUam
    
    'CodeFluent Entities generated (http://www.softfluent.com). Date: .
    <System.CodeDom.Compiler.GeneratedCodeAttribute("CodeFluent Entities", "1.0.01234.05678"),  _
     System.SerializableAttribute(),  _
     System.ComponentModel.DataObjectAttribute(),  _
     System.Diagnostics.DebuggerDisplayAttribute("EK={EntityKey}, MES={MES}, pId={pId}"),  _
     System.ComponentModel.TypeConverterAttribute(GetType(CodeFluent.Runtime.Design.NameTypeConverter))>  _
    Partial Public Class RES_MENSAL_SAFRA
        Implements System.ICloneable, System.IComparable, System.IComparable(Of S5TUam.RES_MENSAL_SAFRA), CodeFluent.Runtime.ICodeFluentCollectionEntity(Of Long), System.ComponentModel.IDataErrorInfo, CodeFluent.Runtime.ICodeFluentMemberValidator, CodeFluent.Runtime.ICodeFluentSummaryValidator, System.IEquatable(Of S5TUam.RES_MENSAL_SAFRA)
        
        Private _raisePropertyChangedEvents As Boolean = true
        
        Private _entityState As CodeFluent.Runtime.CodeFluentEntityState
        
        Private _pId As Long = -1
        
        Private _iD_NEGOCIOS As Integer = CodeFluentPersistence.DefaultInt32Value
        
        Private _nRO_ANO_SAFRA As Integer = CodeFluentPersistence.DefaultInt32Value
        
        Private _mES As String = CType(Nothing, String)
        
        Private _dIA As Date = CodeFluentPersistence.DefaultDateTimeValue
        
        Private _tONELADA_PLAN As Double = CodeFluentPersistence.DefaultDoubleValue
        
        Private _tONELADA_REAL As Double = CodeFluentPersistence.DefaultDoubleValue
        
        Public Sub New()
            MyBase.New
            Me._entityState = CodeFluent.Runtime.CodeFluentEntityState.Created
        End Sub
        
        <System.ComponentModel.BrowsableAttribute(false),  _
         System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Overridable Property RaisePropertyChangedEvents() As Boolean
            Get
                Return Me._raisePropertyChangedEvents
            End Get
            Set
                Me._raisePropertyChangedEvents = value
            End Set
        End Property
        
        Public Overridable Property EntityKey() As String Implements CodeFluent.Runtime.ICodeFluentEntity.EntityKey
            Get
                Return Me.pId.ToString
            End Get
            Set
                Me.pId = CType(ConvertUtilities.ChangeType(value, GetType(Long), -1),Long)
            End Set
        End Property
        
        Public Overridable ReadOnly Property EntityDisplayName() As String Implements CodeFluent.Runtime.ICodeFluentEntity.EntityDisplayName
            Get
                Return Me.MES
            End Get
        End Property
        
        <System.ComponentModel.DefaultValueAttribute(CType(-1,Long)),  _
         System.Xml.Serialization.XmlElementAttribute(IsNullable:=false, Type:=GetType(Long)),  _
         System.ComponentModel.DataObjectFieldAttribute(true)>  _
        Public Property pId() As Long
            Get
                Return Me._pId
            End Get
            Set
                If (System.Collections.Generic.EqualityComparer(Of Long).Default.Equals(value, Me._pId) = true) Then
                    Return
                End If
                Dim oldKey As Long = Me._pId
                Me._pId = value
                Try 
                    Me.OnCollectionKeyChanged(oldKey)
                Catch __exception As System.ArgumentException
                    Me._pId = oldKey
                    Return
                End Try
                Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified
                Me.OnPropertyChanged(New System.ComponentModel.PropertyChangedEventArgs("pId"))
            End Set
        End Property
        
        <System.ComponentModel.DefaultValueAttribute(CodeFluentPersistence.DefaultInt32Value),  _
         System.Xml.Serialization.XmlElementAttribute(IsNullable:=false, Type:=GetType(Integer))>  _
        Public Property ID_NEGOCIOS() As Integer
            Get
                Return Me._iD_NEGOCIOS
            End Get
            Set
                Me._iD_NEGOCIOS = value
                Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified
                Me.OnPropertyChanged(New System.ComponentModel.PropertyChangedEventArgs("ID_NEGOCIOS"))
            End Set
        End Property
        
        <System.ComponentModel.DefaultValueAttribute(CodeFluentPersistence.DefaultInt32Value),  _
         System.Xml.Serialization.XmlElementAttribute(IsNullable:=false, Type:=GetType(Integer))>  _
        Public Property NRO_ANO_SAFRA() As Integer
            Get
                Return Me._nRO_ANO_SAFRA
            End Get
            Set
                Me._nRO_ANO_SAFRA = value
                Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified
                Me.OnPropertyChanged(New System.ComponentModel.PropertyChangedEventArgs("NRO_ANO_SAFRA"))
            End Set
        End Property
        
        <System.ComponentModel.DefaultValueAttribute(CType(Nothing, String)),  _
         System.Xml.Serialization.XmlElementAttribute(IsNullable:=true, Type:=GetType(String))>  _
        Public Property MES() As String
            Get
                Return Me._mES
            End Get
            Set
                Me._mES = value
                Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified
                Me.OnPropertyChanged(New System.ComponentModel.PropertyChangedEventArgs("MES"))
            End Set
        End Property
        
        <System.Xml.Serialization.XmlElementAttribute(IsNullable:=false, Type:=GetType(Date))>  _
        Public Property DIA() As Date
            Get
                Return Me._dIA
            End Get
            Set
                Me._dIA = value
                Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified
                Me.OnPropertyChanged(New System.ComponentModel.PropertyChangedEventArgs("DIA"))
            End Set
        End Property
        
        <System.ComponentModel.DefaultValueAttribute(CodeFluentPersistence.DefaultDoubleValue),  _
         System.Xml.Serialization.XmlElementAttribute(IsNullable:=false, Type:=GetType(Double))>  _
        Public Property TONELADA_PLAN() As Double
            Get
                Return Me._tONELADA_PLAN
            End Get
            Set
                Me._tONELADA_PLAN = value
                Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified
                Me.OnPropertyChanged(New System.ComponentModel.PropertyChangedEventArgs("TONELADA_PLAN"))
            End Set
        End Property
        
        <System.ComponentModel.DefaultValueAttribute(CodeFluentPersistence.DefaultDoubleValue),  _
         System.Xml.Serialization.XmlElementAttribute(IsNullable:=false, Type:=GetType(Double))>  _
        Public Property TONELADA_REAL() As Double
            Get
                Return Me._tONELADA_REAL
            End Get
            Set
                Me._tONELADA_REAL = value
                Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Modified
                Me.OnPropertyChanged(New System.ComponentModel.PropertyChangedEventArgs("TONELADA_REAL"))
            End Set
        End Property
        
        ReadOnly Property System_ComponentModel_IDataErrorInfo_Error() As String Implements System.ComponentModel.IDataErrorInfo.[Error]
            Get
                Return Me.Validate(System.Globalization.CultureInfo.CurrentCulture)
            End Get
        End Property
        
        ReadOnly Property System_ComponentModel_IDataErrorInfo_Item(ByVal columnName As String) As String Implements System.ComponentModel.IDataErrorInfo.Item
            Get
                Return CodeFluentPersistence.ValidateMember(System.Globalization.CultureInfo.CurrentCulture, Me, columnName, Nothing)
            End Get
        End Property
        
        ReadOnly Property CodeFluent_Runtime_Utilities_IKeyable_System_Int64__Key() As Long Implements CodeFluent.Runtime.Utilities.IKeyable(Of Long).Key
            Get
                Return Me.pId
            End Get
        End Property
        
        Public Overridable Property EntityState() As CodeFluent.Runtime.CodeFluentEntityState Implements CodeFluent.Runtime.ICodeFluentEntity.EntityState
            Get
                Return Me._entityState
            End Get
            Set
                If (System.Collections.Generic.EqualityComparer(Of CodeFluent.Runtime.CodeFluentEntityState).Default.Equals(value, Me.EntityState) = true) Then
                    Return
                End If
                If ((Me._entityState = CodeFluent.Runtime.CodeFluentEntityState.ToBeDeleted)  _
                            AndAlso (value = CodeFluent.Runtime.CodeFluentEntityState.Modified)) Then
                    Return
                End If
                If ((Me._entityState = CodeFluent.Runtime.CodeFluentEntityState.Created)  _
                            AndAlso (value = CodeFluent.Runtime.CodeFluentEntityState.Modified)) Then
                    Return
                End If
                Me._entityState = value
                Me.OnPropertyChanged(New System.ComponentModel.PropertyChangedEventArgs("EntityState"))
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Public Event EntityAction As CodeFluent.Runtime.CodeFluentEntityActionEventHandler Implements CodeFluent.Runtime.ICodeFluentEntity.EntityAction
        
        Public Event KeyChanged As System.EventHandler(Of CodeFluent.Runtime.Utilities.KeyChangedEventArgs(Of Long)) Implements CodeFluent.Runtime.Utilities.IKeyable(Of Long).KeyChanged
        
        Protected Overridable Sub OnPropertyChanged(ByVal e As System.ComponentModel.PropertyChangedEventArgs)
            If (Me.RaisePropertyChangedEvents = false) Then
                Return
            End If
            If (Not (Me.PropertyChangedEvent) Is Nothing) Then
                RaiseEvent PropertyChanged(Me, e)
            End If
        End Sub
        
        Protected Overridable Sub OnEntityAction(ByVal e As CodeFluent.Runtime.CodeFluentEntityActionEventArgs)
            If (Not (Me.EntityActionEvent) Is Nothing) Then
                RaiseEvent EntityAction(Me, e)
            End If
        End Sub
        
        Public Overloads Overridable Function Equals(ByVal rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA) As Boolean Implements System.IEquatable(Of S5TUam.RES_MENSAL_SAFRA).Equals
            If (rES_MENSAL_SAFRA Is Nothing) Then
                Return false
            End If
            If (Me.pId = -1) Then
                Return MyBase.Equals(rES_MENSAL_SAFRA)
            End If
            Return (Me.pId.Equals(rES_MENSAL_SAFRA.pId) = true)
        End Function
        
        Public Overloads Overrides Function GetHashCode() As Integer
            Return Me.pId.GetHashCode
        End Function
        
        Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
            Dim rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA = Nothing
            Try 
                rES_MENSAL_SAFRA = CType(obj,S5TUam.RES_MENSAL_SAFRA)
            Catch icex As System.InvalidCastException
                rES_MENSAL_SAFRA = Nothing
            End Try
            Return Me.Equals(rES_MENSAL_SAFRA)
        End Function
        
        Overridable Function System_IComparable_CompareTo(ByVal value As Object) As Integer Implements System.IComparable.CompareTo
            Dim rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA = Nothing
            Try 
                rES_MENSAL_SAFRA = CType(value,S5TUam.RES_MENSAL_SAFRA)
            Catch icex As System.InvalidCastException
                rES_MENSAL_SAFRA = Nothing
            End Try
            If (rES_MENSAL_SAFRA Is Nothing) Then
                Throw New System.ArgumentException("value")
            End If
            Dim localCompareTo As Integer = Me.CompareTo(rES_MENSAL_SAFRA)
            Return localCompareTo
        End Function
        
        Public Overridable Function CompareTo(ByVal rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA) As Integer Implements System.IComparable(Of S5TUam.RES_MENSAL_SAFRA).CompareTo
            If (rES_MENSAL_SAFRA Is Nothing) Then
                Throw New System.ArgumentNullException("rES_MENSAL_SAFRA")
            End If
            Dim localCompareTo As Integer = Me.pId.CompareTo(rES_MENSAL_SAFRA.pId)
            Return localCompareTo
        End Function
        
        Public Overloads Overridable Function Validate(ByVal culture As System.Globalization.CultureInfo) As String
            Return CodeFluentPersistence.Validate(culture, Me, Nothing)
        End Function
        
        Public Overloads Overridable Sub Validate(ByVal culture As System.Globalization.CultureInfo, ByVal results As System.Collections.Generic.IList(Of CodeFluent.Runtime.CodeFluentValidationException)) Implements CodeFluent.Runtime.ICodeFluentSummaryValidator.Validate
            Dim evt As CodeFluent.Runtime.CodeFluentEntityActionEventArgs = New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.Validating, true, results)
            evt.Culture = culture
            Me.OnEntityAction(evt)
            If (evt.Cancel = true) Then
                Dim externalValidate As String
                If (Not (evt.Argument) Is Nothing) Then
                    externalValidate = evt.Argument.ToString
                Else
                    externalValidate = S5T.Resources.Manager.GetStringWithDefault(culture, "S5TUam.RES_MENSAL_SAFRA.ExternalValidate", "Type 'S5TUam.RES_MENSAL_SAFRA' cannot be validated.", Nothing)
                End If
                CodeFluentPersistence.AddValidationError(results, externalValidate)
            End If
            CodeFluentPersistence.ValidateMember(culture, results, Me, Nothing)
            Me.OnEntityAction(New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.Validated, false, results))
        End Sub
        
        Public Overloads Sub Validate()
            Dim var As String = Me.Validate(System.Globalization.CultureInfo.CurrentCulture)
            If (Not (var) Is Nothing) Then
                Throw New CodeFluent.Runtime.CodeFluentValidationException(var)
            End If
        End Sub
        
        Function CodeFluent_Runtime_ICodeFluentValidator_Validate(ByVal culture As System.Globalization.CultureInfo) As String Implements CodeFluent.Runtime.ICodeFluentValidator.Validate
            Dim localValidate As String = Me.Validate(culture)
            Return localValidate
        End Function
        
        Sub CodeFluent_Runtime_ICodeFluentMemberValidator_Validate(ByVal culture As System.Globalization.CultureInfo, ByVal memberName As String, ByVal results As System.Collections.Generic.IList(Of CodeFluent.Runtime.CodeFluentValidationException)) Implements CodeFluent.Runtime.ICodeFluentMemberValidator.Validate
            Me.ValidateMember(culture, memberName, results)
        End Sub
        
        Public Overloads Overridable Function Delete() As Boolean Implements CodeFluent.Runtime.ICodeFluentEntity.Delete
            Dim ret As Boolean = false
            Dim evt As CodeFluent.Runtime.CodeFluentEntityActionEventArgs = New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.Deleting, true)
            Me.OnEntityAction(evt)
            If (evt.Cancel = true) Then
                Return ret
            End If
            If (Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Deleted) Then
                Return ret
            End If
            Dim persistence As CodeFluent.Runtime.CodeFluentPersistence = CodeFluentContext.Get(S5T.Constants.S5TStoreName).Persistence
            persistence.CreateStoredProcedureCommand(Nothing, "RES_MENSAL_SAFRA", "Delete")
            persistence.AddParameter("@pId", Me.pId, CType(-1,Long))
            persistence.ExecuteNonQuery
            Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Deleted
            Me.OnEntityAction(New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.Deleted, false, false))
            ret = true
            Return ret
        End Function
        
        Protected Overridable Sub ReadRecord(ByVal reader As System.Data.IDataReader, ByVal options As CodeFluent.Runtime.CodeFluentReloadOptions)
            If (reader Is Nothing) Then
                Throw New System.ArgumentNullException("reader")
            End If
            If (((options And CodeFluent.Runtime.CodeFluentReloadOptions.Properties)  _
                        = 0)  _
                        = false) Then
                Me._pId = CodeFluentPersistence.GetReaderValue(reader, "pId", CType(-1,Long))
                Me._iD_NEGOCIOS = CodeFluentPersistence.GetReaderValue(reader, "ID_NEGOCIOS", CType(CodeFluentPersistence.DefaultInt32Value,Integer))
                Me._nRO_ANO_SAFRA = CodeFluentPersistence.GetReaderValue(reader, "NRO_ANO_SAFRA", CType(CodeFluentPersistence.DefaultInt32Value,Integer))
                Me._mES = CodeFluentPersistence.GetReaderValue(reader, "MES", CType(CType(Nothing, String),String))
                Me._dIA = CodeFluentPersistence.GetReaderValue(reader, "DIA", CType(CodeFluentPersistence.DefaultDateTimeValue,Date))
                Me._tONELADA_PLAN = CodeFluentPersistence.GetReaderValue(reader, "TONELADA_PLAN", CType(CodeFluentPersistence.DefaultDoubleValue,Double))
                Me._tONELADA_REAL = CodeFluentPersistence.GetReaderValue(reader, "TONELADA_REAL", CType(CodeFluentPersistence.DefaultDoubleValue,Double))
            End If
            Me.OnEntityAction(New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.ReadRecord, false, false))
        End Sub
        
        Sub CodeFluent_Runtime_ICodeFluentEntity_ReadRecord(ByVal reader As System.Data.IDataReader) Implements CodeFluent.Runtime.ICodeFluentEntity.ReadRecord
            Me.ReadRecord(reader, CodeFluent.Runtime.CodeFluentReloadOptions.[Default])
        End Sub
        
        Protected Overridable Sub ReadRecordOnSave(ByVal reader As System.Data.IDataReader)
            If (reader Is Nothing) Then
                Throw New System.ArgumentNullException("reader")
            End If
            Me._pId = CodeFluentPersistence.GetReaderValue(reader, "pId", CType(-1,Long))
            Me.OnEntityAction(New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.ReadRecordOnSave, false, false))
        End Sub
        
        Sub CodeFluent_Runtime_ICodeFluentEntity_ReadRecordOnSave(ByVal reader As System.Data.IDataReader) Implements CodeFluent.Runtime.ICodeFluentEntity.ReadRecordOnSave
            Me.ReadRecordOnSave(reader)
        End Sub
        
        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.[Select], true)>  _
        Public Shared Function Load(ByVal pId As Long) As S5TUam.RES_MENSAL_SAFRA
            If (pId = -1) Then
                Return Nothing
            End If
            Dim rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA = New S5TUam.RES_MENSAL_SAFRA()
            Dim persistence As CodeFluent.Runtime.CodeFluentPersistence = CodeFluentContext.Get(S5T.Constants.S5TStoreName).Persistence
            persistence.CreateStoredProcedureCommand(Nothing, "RES_MENSAL_SAFRA", "Load")
            persistence.AddParameter("@pId", pId, CType(-1,Long))
            Dim reader As System.Data.IDataReader = Nothing
            Try 
                reader = persistence.ExecuteReader
                If (reader.Read = true) Then
                    rES_MENSAL_SAFRA.ReadRecord(reader, CodeFluent.Runtime.CodeFluentReloadOptions.[Default])
                    rES_MENSAL_SAFRA.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Unchanged
                    Return rES_MENSAL_SAFRA
                End If
            Finally
                If (Not (reader) Is Nothing) Then
                    reader.Dispose
                End If
                persistence.CompleteCommand
            End Try
            Return Nothing
        End Function
        
        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.[Select], false)>  _
        Public Shared Function LoadBypId(ByVal pId As Long) As S5TUam.RES_MENSAL_SAFRA
            If (pId = -1) Then
                Return Nothing
            End If
            Dim rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA = New S5TUam.RES_MENSAL_SAFRA()
            Dim persistence As CodeFluent.Runtime.CodeFluentPersistence = CodeFluentContext.Get(S5T.Constants.S5TStoreName).Persistence
            persistence.CreateStoredProcedureCommand(Nothing, "RES_MENSAL_SAFRA", "LoadBypId")
            persistence.AddParameter("@pId", pId, CType(-1,Long))
            Dim reader As System.Data.IDataReader = Nothing
            Try 
                reader = persistence.ExecuteReader
                If (reader.Read = true) Then
                    rES_MENSAL_SAFRA.ReadRecord(reader, CodeFluent.Runtime.CodeFluentReloadOptions.[Default])
                    rES_MENSAL_SAFRA.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Unchanged
                    Return rES_MENSAL_SAFRA
                End If
            Finally
                If (Not (reader) Is Nothing) Then
                    reader.Dispose
                End If
                persistence.CompleteCommand
            End Try
            Return Nothing
        End Function
        
        Public Overridable Function Reload(ByVal options As CodeFluent.Runtime.CodeFluentReloadOptions) As Boolean
            Dim ret As Boolean = false
            If (Me.pId = -1) Then
                Return ret
            End If
            Dim persistence As CodeFluent.Runtime.CodeFluentPersistence = CodeFluentContext.Get(S5T.Constants.S5TStoreName).Persistence
            persistence.CreateStoredProcedureCommand(Nothing, "RES_MENSAL_SAFRA", "Load")
            persistence.AddParameter("@pId", Me.pId, CType(-1,Long))
            Dim reader As System.Data.IDataReader = Nothing
            Try 
                reader = persistence.ExecuteReader
                If (reader.Read = true) Then
                    Me.ReadRecord(reader, options)
                    Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Unchanged
                    ret = true
                Else
                    Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Deleted
                End If
            Finally
                If (Not (reader) Is Nothing) Then
                    reader.Dispose
                End If
                persistence.CompleteCommand
            End Try
            Return ret
        End Function
        
        Protected Overridable Function BaseSave(ByVal force As Boolean) As Boolean
            If (Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.ToBeDeleted) Then
                S5TUam.RES_MENSAL_SAFRA.Delete(Me)
                Return false
            End If
            Dim evt As CodeFluent.Runtime.CodeFluentEntityActionEventArgs = New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.Saving, true)
            Me.OnEntityAction(evt)
            If (evt.Cancel = true) Then
                Return false
            End If
            CodeFluentPersistence.ThrowIfDeleted(Me)
            Me.Validate
            If ((force = false)  _
                        AndAlso (Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Unchanged)) Then
                Return false
            End If
            Dim persistence As CodeFluent.Runtime.CodeFluentPersistence = CodeFluentContext.Get(S5T.Constants.S5TStoreName).Persistence
            persistence.CreateStoredProcedureCommand(Nothing, "RES_MENSAL_SAFRA", "Save")
            persistence.AddParameter("@pId", Me.pId, CType(-1,Long))
            persistence.AddParameter("@ID_NEGOCIOS", Me.ID_NEGOCIOS, CodeFluentPersistence.DefaultInt32Value)
            persistence.AddParameter("@NRO_ANO_SAFRA", Me.NRO_ANO_SAFRA, CodeFluentPersistence.DefaultInt32Value)
            persistence.AddParameter("@MES", Me.MES, CType(Nothing, String))
            persistence.AddParameter("@DIA", Me.DIA, CodeFluentPersistence.DefaultDateTimeValue)
            persistence.AddParameter("@TONELADA_PLAN", Me.TONELADA_PLAN, CodeFluentPersistence.DefaultDoubleValue)
            persistence.AddParameter("@TONELADA_REAL", Me.TONELADA_REAL, CodeFluentPersistence.DefaultDoubleValue)
            persistence.AddParameter("@_trackLastWriteUser", persistence.Context.User.Name)
            Dim reader As System.Data.IDataReader = Nothing
            Try 
                reader = persistence.ExecuteReader
                If (reader.Read = true) Then
                    Me.ReadRecordOnSave(reader)
                End If
                CodeFluentPersistence.NextResults(reader)
            Finally
                If (Not (reader) Is Nothing) Then
                    reader.Dispose
                End If
                persistence.CompleteCommand
            End Try
            Me.OnEntityAction(New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.Saved, false, false))
            Me.EntityState = CodeFluent.Runtime.CodeFluentEntityState.Unchanged
            Return true
        End Function
        
        Public Overloads Overridable Function Save() As Boolean Implements CodeFluent.Runtime.ICodeFluentEntity.Save
            Dim localSave As Boolean = Me.BaseSave(false)
            Return localSave
        End Function
        
        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)>  _
        Public Overloads Shared Function Save(ByVal rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA) As Boolean
            If (rES_MENSAL_SAFRA Is Nothing) Then
                Return false
            End If
            Dim ret As Boolean = rES_MENSAL_SAFRA.Save
            Return ret
        End Function
        
        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)>  _
        Public Shared Function Insert(ByVal rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA) As Boolean
            Dim ret As Boolean = S5TUam.RES_MENSAL_SAFRA.Save(rES_MENSAL_SAFRA)
            Return ret
        End Function
        
        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)>  _
        Public Overloads Shared Function Delete(ByVal rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA) As Boolean
            If (rES_MENSAL_SAFRA Is Nothing) Then
                Return false
            End If
            Dim ret As Boolean = rES_MENSAL_SAFRA.Delete
            Return ret
        End Function
        
        Public Function Trace() As String
            Dim stringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter(stringBuilder, System.Globalization.CultureInfo.CurrentCulture)
            Dim writer As System.CodeDom.Compiler.IndentedTextWriter = New System.CodeDom.Compiler.IndentedTextWriter(stringWriter)
            Me.BaseTrace(writer)
            writer.Flush
            CType(writer,System.IDisposable).Dispose
            CType(stringWriter,System.IDisposable).Dispose
            Dim sr As String = stringBuilder.ToString
            Return sr
        End Function
        
        <System.ComponentModel.BrowsableAttribute(false),  _
         System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)>  _
        Sub CodeFluent_Runtime_ICodeFluentObject_Trace(ByVal writer As System.CodeDom.Compiler.IndentedTextWriter) Implements CodeFluent.Runtime.ICodeFluentObject.Trace
            Me.BaseTrace(writer)
        End Sub
        
        Protected Overridable Sub BaseTrace(ByVal writer As System.CodeDom.Compiler.IndentedTextWriter)
            writer.Write("[")
            writer.Write("pId=")
            writer.Write(Me.pId)
            writer.Write(",")
            writer.Write("ID_NEGOCIOS=")
            writer.Write(Me.ID_NEGOCIOS)
            writer.Write(",")
            writer.Write("NRO_ANO_SAFRA=")
            writer.Write(Me.NRO_ANO_SAFRA)
            writer.Write(",")
            writer.Write("MES=")
            writer.Write(Me.MES)
            writer.Write(",")
            writer.Write("DIA=")
            writer.Write(Me.DIA)
            writer.Write(",")
            writer.Write("TONELADA_PLAN=")
            writer.Write(Me.TONELADA_PLAN)
            writer.Write(",")
            writer.Write("TONELADA_REAL=")
            writer.Write(Me.TONELADA_REAL)
            writer.Write(", EntityState=")
            writer.Write(Me.EntityState)
            writer.Write("]")
        End Sub
        
        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.[Select], true)>  _
        Public Shared Function LoadByEntityKey(ByVal key As String) As S5TUam.RES_MENSAL_SAFRA
            If (key Is String.Empty) Then
                Return Nothing
            End If
            Dim rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA
            Dim var As Long = CType(ConvertUtilities.ChangeType(key, GetType(Long), -1),Long)
            rES_MENSAL_SAFRA = S5TUam.RES_MENSAL_SAFRA.Load(var)
            Return rES_MENSAL_SAFRA
        End Function
        
        Protected Overridable Sub ValidateMember(ByVal culture As System.Globalization.CultureInfo, ByVal memberName As String, ByVal results As System.Collections.Generic.IList(Of CodeFluent.Runtime.CodeFluentValidationException))
        End Sub
        
        Public Overloads Function Clone(ByVal deep As Boolean) As S5TUam.RES_MENSAL_SAFRA
            Dim rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA = New S5TUam.RES_MENSAL_SAFRA()
            Me.CopyTo(rES_MENSAL_SAFRA, deep)
            Return rES_MENSAL_SAFRA
        End Function
        
        Public Overloads Function Clone() As S5TUam.RES_MENSAL_SAFRA
            Dim localClone As S5TUam.RES_MENSAL_SAFRA = Me.Clone(true)
            Return localClone
        End Function
        
        Function System_ICloneable_Clone() As Object Implements System.ICloneable.Clone
            Dim localClone As Object = Me.Clone
            Return localClone
        End Function
        
        Public Overridable Sub CopyFrom(ByVal dict As System.Collections.IDictionary, ByVal deep As Boolean)
            If (dict Is Nothing) Then
                Throw New System.ArgumentNullException("dict")
            End If
            If (dict.Contains("pId") = true) Then
                Me.pId = CType(ConvertUtilities.ChangeType(dict("pId"), GetType(Long), -1),Long)
            End If
            If (dict.Contains("DIA") = true) Then
                Me.DIA = CType(ConvertUtilities.ChangeType(dict("DIA"), GetType(Date), CodeFluentPersistence.DefaultDateTimeValue),Date)
            End If
            If (dict.Contains("TONELADA_PLAN") = true) Then
                Me.TONELADA_PLAN = CType(ConvertUtilities.ChangeType(dict("TONELADA_PLAN"), GetType(Double), CodeFluentPersistence.DefaultDoubleValue),Double)
            End If
            If (dict.Contains("TONELADA_REAL") = true) Then
                Me.TONELADA_REAL = CType(ConvertUtilities.ChangeType(dict("TONELADA_REAL"), GetType(Double), CodeFluentPersistence.DefaultDoubleValue),Double)
            End If
            If (dict.Contains("ID_NEGOCIOS") = true) Then
                Me.ID_NEGOCIOS = CType(ConvertUtilities.ChangeType(dict("ID_NEGOCIOS"), GetType(Integer), CodeFluentPersistence.DefaultInt32Value),Integer)
            End If
            If (dict.Contains("NRO_ANO_SAFRA") = true) Then
                Me.NRO_ANO_SAFRA = CType(ConvertUtilities.ChangeType(dict("NRO_ANO_SAFRA"), GetType(Integer), CodeFluentPersistence.DefaultInt32Value),Integer)
            End If
            If (dict.Contains("MES") = true) Then
                Me.MES = CType(ConvertUtilities.ChangeType(dict("MES"), GetType(String), CType(Nothing, String)),String)
            End If
            Me.OnEntityAction(New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.CopyFrom, false, dict))
        End Sub
        
        Public Overloads Overridable Sub CopyTo(ByVal rES_MENSAL_SAFRA As S5TUam.RES_MENSAL_SAFRA, ByVal deep As Boolean)
            If (rES_MENSAL_SAFRA Is Nothing) Then
                Throw New System.ArgumentNullException("rES_MENSAL_SAFRA")
            End If
            rES_MENSAL_SAFRA.pId = Me.pId
            rES_MENSAL_SAFRA.DIA = Me.DIA
            rES_MENSAL_SAFRA.TONELADA_PLAN = Me.TONELADA_PLAN
            rES_MENSAL_SAFRA.TONELADA_REAL = Me.TONELADA_REAL
            rES_MENSAL_SAFRA.ID_NEGOCIOS = Me.ID_NEGOCIOS
            rES_MENSAL_SAFRA.NRO_ANO_SAFRA = Me.NRO_ANO_SAFRA
            rES_MENSAL_SAFRA.MES = Me.MES
            Me.OnEntityAction(New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.CopyTo, false, rES_MENSAL_SAFRA))
        End Sub
        
        Public Overloads Overridable Sub CopyTo(ByVal dict As System.Collections.IDictionary, ByVal deep As Boolean)
            If (dict Is Nothing) Then
                Throw New System.ArgumentNullException("dict")
            End If
            dict("pId") = Me.pId
            dict("DIA") = Me.DIA
            dict("TONELADA_PLAN") = Me.TONELADA_PLAN
            dict("TONELADA_REAL") = Me.TONELADA_REAL
            dict("ID_NEGOCIOS") = Me.ID_NEGOCIOS
            dict("NRO_ANO_SAFRA") = Me.NRO_ANO_SAFRA
            dict("MES") = Me.MES
            Me.OnEntityAction(New CodeFluent.Runtime.CodeFluentEntityActionEventArgs(Me, CodeFluent.Runtime.CodeFluentEntityAction.CopyTo, false, dict))
        End Sub
        
        Protected Sub OnCollectionKeyChanged(ByVal key As Long)
            If (Not (Me.KeyChangedEvent) Is Nothing) Then
                RaiseEvent KeyChanged(Me, New CodeFluent.Runtime.Utilities.KeyChangedEventArgs(Of Long)(key))
            End If
        End Sub
    End Class
End Namespace
