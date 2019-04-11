Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Namespace JhonyLopez.EmetraApp2017090.Model
    Public Class Neighbor
#Region "Campos"
        Private _NIT As String
        Private _DPI As Integer
        Private _FirstName As String
        Private _LastName As String
        Private _Adress As String
        Private _Municipality As String
        Private _PostalCode As Integer
        Private _Telephone As Integer
#End Region

#Region "Llaves"
        Public Overridable Property Vehicles() As ICollection(Of Vehicle)
#End Region

#Region "Propiedades"
        <Key>
        Public Property NIT As String
            Get
                Return _NIT
            End Get
            Set(value As String)
                _NIT = value
            End Set
        End Property

        Public Property DPI As Integer
            Get
                Return _DPI
            End Get
            Set(value As Integer)
                _DPI = value
            End Set
        End Property

        Public Property FirstName As String
            Get
                Return _FirstName
            End Get
            Set(value As String)
                _FirstName = value
            End Set
        End Property

        Public Property LastName As String
            Get
                Return _LastName
            End Get
            Set(value As String)
                _LastName = value
            End Set
        End Property

        Public Property Adress As String
            Get
                Return _Adress
            End Get
            Set(value As String)
                _Adress = value
            End Set
        End Property

        Public Property Municipality As String
            Get
                Return _Municipality
            End Get
            Set(value As String)
                _Municipality = value
            End Set
        End Property

        Public Property PostalCode As Integer
            Get
                Return _PostalCode
            End Get
            Set(value As Integer)
                _PostalCode = value
            End Set
        End Property

        Public Property Telephone As Integer
            Get
                Return _Telephone
            End Get
            Set(value As Integer)
                _Telephone = value
            End Set
        End Property
#End Region
    End Class
End Namespace
