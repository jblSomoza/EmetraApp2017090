Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Namespace JhonyLopez.EmetraApp2017090.Model
    Public Class Vehicle
#Region "Campos"
        Private _LicensePlate As String
        Private _NIT As String
        Private _Brand As String
        Private _Model1 As String    'Revisar
        Private _TypeOfVehicle As String
#End Region

#Region "Llaves"
        Public Overridable Property Neighbor() As Neighbor
        Public Overridable Property Remissions() As ICollection(Of Remission)
#End Region

#Region "Propiedades"
        <Key>
        Public Property LicensePlate As String
            Get
                Return _LicensePlate
            End Get
            Set(value As String)
                _LicensePlate = value
            End Set
        End Property
        <ForeignKey("Neighbor")>
        Public Property NIT As String
            Get
                Return _NIT
            End Get
            Set(value As String)
                _NIT = value
            End Set
        End Property

        Public Property Brand As String
            Get
                Return _Brand
            End Get
            Set(value As String)
                _Brand = value
            End Set
        End Property

        Public Property Model1 As String
            Get
                Return _Model1
            End Get
            Set(value As String)
                _Model1 = value
            End Set
        End Property

        Public Property TypeOfVehicle As String
            Get
                Return _TypeOfVehicle
            End Get
            Set(value As String)
                _TypeOfVehicle = value
            End Set
        End Property
#End Region
    End Class
End Namespace

