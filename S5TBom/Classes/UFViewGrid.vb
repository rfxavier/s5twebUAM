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

Namespace S5T
    
    'CodeFluent Entities generated (http://www.softfluent.com). Date: .
    <System.CodeDom.Compiler.GeneratedCodeAttribute("CodeFluent Entities", "1.0.01234.05678"),  _
     System.SerializableAttribute(),  _
     System.ComponentModel.DataObjectAttribute()>  _
    Partial Public Class UFViewGrid
        Implements CodeFluent.Runtime.ICodeFluentLightEntity
        
        Private _pId As Long = -1
        
        Private _pCodigo As Integer = CodeFluentPersistence.DefaultInt32Value
        
        Private _pDescricao As String = CType(Nothing, String)
        
        Private _pSigla As String = CType(Nothing, String)
        
        Public Sub New()
            MyBase.New
        End Sub
        
        <System.ComponentModel.DefaultValueAttribute(CType(-1,Long)),  _
         System.Xml.Serialization.XmlElementAttribute(IsNullable:=false, Type:=GetType(Long)),  _
         System.ComponentModel.DataObjectFieldAttribute(true)>  _
        Public Property pId() As Long
            Get
                Return Me._pId
            End Get
            Set
                Me._pId = value
            End Set
        End Property
        
        <System.ComponentModel.DefaultValueAttribute(CodeFluentPersistence.DefaultInt32Value),  _
         System.Xml.Serialization.XmlElementAttribute(IsNullable:=false, Type:=GetType(Integer))>  _
        Public Property pCodigo() As Integer
            Get
                Return Me._pCodigo
            End Get
            Set
                If (System.Collections.Generic.EqualityComparer(Of Integer).Default.Equals(value, Me._pCodigo) = true) Then
                    Return
                End If
                Me._pCodigo = value
            End Set
        End Property
        
        <System.ComponentModel.DefaultValueAttribute(CType(Nothing, String)),  _
         System.Xml.Serialization.XmlElementAttribute(IsNullable:=true, Type:=GetType(String))>  _
        Public Property pDescricao() As String
            Get
                Return Me._pDescricao
            End Get
            Set
                Me._pDescricao = value
            End Set
        End Property
        
        <System.ComponentModel.DefaultValueAttribute(CType(Nothing, String)),  _
         System.Xml.Serialization.XmlElementAttribute(IsNullable:=true, Type:=GetType(String))>  _
        Public Property pSigla() As String
            Get
                Return Me._pSigla
            End Get
            Set
                Me._pSigla = value
            End Set
        End Property
        
        Protected Overridable Sub ReadRecord(ByVal reader As System.Data.IDataReader, ByVal options As CodeFluent.Runtime.CodeFluentReloadOptions)
            If (reader Is Nothing) Then
                Throw New System.ArgumentNullException("reader")
            End If
            If (((options And CodeFluent.Runtime.CodeFluentReloadOptions.Properties)  _
                        = 0)  _
                        = false) Then
                Me._pId = CodeFluentPersistence.GetReaderValue(reader, "pId", CType(-1,Long))
                Me._pCodigo = CodeFluentPersistence.GetReaderValue(reader, "pCodigo", CType(CodeFluentPersistence.DefaultInt32Value,Integer))
                Me._pDescricao = CodeFluentPersistence.GetReaderValue(reader, "pDescricao", CType(CType(Nothing, String),String))
                Me._pSigla = CodeFluentPersistence.GetReaderValue(reader, "pSigla", CType(CType(Nothing, String),String))
            End If
        End Sub
        
        Sub CodeFluent_Runtime_ICodeFluentLightEntity_ReadRecord(ByVal reader As System.Data.IDataReader) Implements CodeFluent.Runtime.ICodeFluentLightEntity.ReadRecord
            Me.ReadRecord(reader, CodeFluent.Runtime.CodeFluentReloadOptions.[Default])
        End Sub
    End Class
End Namespace
