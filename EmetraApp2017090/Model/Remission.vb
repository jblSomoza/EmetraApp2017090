Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Namespace JhonyLopez.EmetraApp2017090.Model
    Public Class Remission
#Region "Campos"
        Private _OrderNumber As Integer
        Private _RemissionDate As Date
        Private _Hour As String
        Private _Place As String
        Private _RemissionID As Integer
        Private _AgentNumber As Integer
        Private _LicensePlate As String
        Private _AgentID As Integer
#End Region

#Region "Llaves"
        Public Overridable Property Vehicle() As Vehicle
        Public Overridable Property Agent() As Agent
        Public Overridable Property SanctionType() As SanctionType
#End Region

#Region "Propiedades"
        <Key>
        Public Property OrderNumber As Integer
            Get
                Return _OrderNumber
            End Get
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property

        Public Property RemissionDate As Date
            Get
                Return _RemissionDate
            End Get
            Set(value As Date)
                _RemissionDate = value
            End Set
        End Property

        Public Property Hour As String
            Get
                Return _Hour
            End Get
            Set(value As String)
                _Hour = value
            End Set
        End Property

        Public Property Place As String
            Get
                Return _Place
            End Get
            Set(value As String)
                _Place = value
            End Set
        End Property
        <ForeignKey("SanctionType")>
        Public Property RemissionID As Integer
            Get
                Return _RemissionID
            End Get
            Set(value As Integer)
                _RemissionID = value
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
        <ForeignKey("Vehicle")>
        Public Property LicensePlate As String
            Get
                Return _LicensePlate
            End Get
            Set(value As String)
                _LicensePlate = value
            End Set
        End Property
        <ForeignKey("Agent")>
        Public Property AgentID As Integer
            Get
                Return _AgentID
            End Get
            Set(value As Integer)
                _AgentID = value
            End Set
        End Property
#End Region
    End Class
End Namespace
