﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :4.0.30319.269
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization

Namespace ServiceSecurite
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute(Name:="CompositeType", [Namespace]:="http://schemas.datacontract.org/2004/07/HC_service_web"),  _
     System.SerializableAttribute()>  _
    Partial Public Class CompositeType
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
        
        <System.NonSerializedAttribute()>  _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private BoolValueField As Boolean
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private StringValueField As String
        
        <Global.System.ComponentModel.BrowsableAttribute(false)>  _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set
                Me.extensionDataField = value
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property BoolValue() As Boolean
            Get
                Return Me.BoolValueField
            End Get
            Set
                If (Me.BoolValueField.Equals(value) <> true) Then
                    Me.BoolValueField = value
                    Me.RaisePropertyChanged("BoolValue")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property StringValue() As String
            Get
                Return Me.StringValueField
            End Get
            Set
                If (Object.ReferenceEquals(Me.StringValueField, value) <> true) Then
                    Me.StringValueField = value
                    Me.RaisePropertyChanged("StringValue")
                End If
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ServiceSecurite.ISecurite_hc")>  _
    Public Interface ISecurite_hc
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ISecurite_hc/GetData", ReplyAction:="http://tempuri.org/ISecurite_hc/GetDataResponse")>  _
        Function GetData(ByVal value As Integer) As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ISecurite_hc/GetDataUsingDataContract", ReplyAction:="http://tempuri.org/ISecurite_hc/GetDataUsingDataContractResponse")>  _
        Function GetDataUsingDataContract(ByVal composite As ServiceSecurite.CompositeType) As ServiceSecurite.CompositeType
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ISecurite_hc/HashPass", ReplyAction:="http://tempuri.org/ISecurite_hc/HashPassResponse")>  _
        Function HashPass(ByVal motPass As String, ByVal salt As String) As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ISecurite_hc/ComparerMotPasses", ReplyAction:="http://tempuri.org/ISecurite_hc/ComparerMotPassesResponse")>  _
        Function ComparerMotPasses(ByVal motPass1 As String, ByVal motPass2 As String) As Boolean
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface ISecurite_hcChannel
        Inherits ServiceSecurite.ISecurite_hc, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class Securite_hcClient
        Inherits System.ServiceModel.ClientBase(Of ServiceSecurite.ISecurite_hc)
        Implements ServiceSecurite.ISecurite_hc
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function GetData(ByVal value As Integer) As String Implements ServiceSecurite.ISecurite_hc.GetData
            Return MyBase.Channel.GetData(value)
        End Function
        
        Public Function GetDataUsingDataContract(ByVal composite As ServiceSecurite.CompositeType) As ServiceSecurite.CompositeType Implements ServiceSecurite.ISecurite_hc.GetDataUsingDataContract
            Return MyBase.Channel.GetDataUsingDataContract(composite)
        End Function
        
        Public Function HashPass(ByVal motPass As String, ByVal salt As String) As String Implements ServiceSecurite.ISecurite_hc.HashPass
            Return MyBase.Channel.HashPass(motPass, salt)
        End Function
        
        Public Function ComparerMotPasses(ByVal motPass1 As String, ByVal motPass2 As String) As Boolean Implements ServiceSecurite.ISecurite_hc.ComparerMotPasses
            Return MyBase.Channel.ComparerMotPasses(motPass1, motPass2)
        End Function
    End Class
End Namespace
