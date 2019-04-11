Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Namespace JhonyLopez.EmetraApp2017090.Model
    Public Class Agent
#Region "Campos"
        Private _AgentID As Integer
        Private _AgentNumber As Integer
        Private _AgentName As String
        Private _AgentLastName As String
        Private _Charge As String
        Private _Salary As Decimal
        Private _Commission As Decimal
#End Region

#Region "Llaves"
        Public Overridable Property Remissions() As ICollection(Of Remission)
#End Region

#Region "Propiedades"
        <Key>
        Public Property AgentID As Integer
            Get
                Return _AgentID
            End Get
            Set(value As Integer)
                _AgentID = value
            End Set
        End Property

        Public Property AgentNumber As Integer
            Get
                Return _AgentNumber
            End Get
            Set(value As Integer)
                _AgentNumber = value
            End Set
        End Property

        Public Property AgentName As String
            Get
                Return _AgentName
            End Get
            Set(value As String)
                _AgentName = value
            End Set
        End Property

        Public Property AgentLastName As String
            Get
                Return _AgentLastName
            End Get
            Set(value As String)
                _AgentLastName = value
            End Set
        End Property

        Public Property Charge As String
            Get
                Return _Charge
            End Get
            Set(value As String)
                _Charge = value
            End Set
        End Property

        Public Property Salary As Decimal
            Get
                Return _Salary
            End Get
            Set(value As Decimal)
                _Salary = value
            End Set
        End Property

        Public Property Commission As Decimal
            Get
                Return _Commission
            End Get
            Set(value As Decimal)
                _Commission = value
            End Set
        End Property
#End Region
    End Class
End Namespace
