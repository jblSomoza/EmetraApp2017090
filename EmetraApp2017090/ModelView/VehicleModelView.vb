Imports System.ComponentModel
Imports EmetraApp2017090
Imports EmetraApp2017090.JhonyLopez.EmetraApp2017090.Model
Public Class VehicleModelView

    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _LicensePlate As String

    Private _Brand As String
    Private _Model1 As Integer
    Private _TypeOfVehicle As String

    Private _Neighbor As Neighbor   'NIT
    Private _ListNeighbor As New List(Of Neighbor)

    Private _Model As VehicleModelView
    Private _ListVehicle As New List(Of Vehicle)
    Private _Element As Vehicle

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnUpdate As Boolean = True
    Private _BtnCancel As Boolean = False
    Private _BtnReturn As MainWindow

    Private DB As New EmetraApp2017090DataContext
#End Region

#Region "Propiedades"
    Public Property LicensePlate As String
        Get
            Return _LicensePlate
        End Get
        Set(value As String)
            _LicensePlate = value
            NotificarCambio("LicensePlate")
        End Set
    End Property

    Public Property Brand As String
        Get
            Return _Brand
        End Get
        Set(value As String)
            _Brand = value
            NotificarCambio("Brand")
        End Set
    End Property

    Public Property Model1 As Integer
        Get
            Return _Model1
        End Get
        Set(value As Integer)
            _Model1 = value
            NotificarCambio("ModelV")
        End Set
    End Property

    Public Property TypeOfVehicle As String
        Get
            Return _TypeOfVehicle
        End Get
        Set(value As String)
            _TypeOfVehicle = value
            NotificarCambio("TypeOfVehicle")
        End Set
    End Property

    Public Property Neighbor As Neighbor
        Get
            Return _Neighbor
        End Get
        Set(value As Neighbor)
            _Neighbor = value
            NotificarCambio("Neighbor")
        End Set
    End Property

    Public Property ListNeighbor As List(Of Neighbor)
        Get
            If _ListNeighbor.Count = 0 Then
                _ListNeighbor = (From N In DB.Neighbors Select N).ToList
            End If
            Return _ListNeighbor
        End Get
        Set(value As List(Of Neighbor))
            _ListNeighbor = value
            NotificarCambio("ListNeighbor")
        End Set
    End Property

    Public Property Model As VehicleModelView
        Get
            Return _Model
        End Get
        Set(value As VehicleModelView)
            _Model = value
        End Set
    End Property

    Public Property ListVehicle As List(Of Vehicle)
        Get
            If _ListVehicle.Count = 0 Then
                _ListVehicle = (From N In DB.Vehicles Select N).ToList
            End If
            Return _ListVehicle
        End Get
        Set(value As List(Of Vehicle))
            _ListVehicle = value
            NotificarCambio("ListVehicle")
        End Set
    End Property

    Public Property Element As Vehicle
        Get
            Return _Element
        End Get
        Set(value As Vehicle)
            _Element = value
            NotificarCambio("Element")

            If (value IsNot Nothing) Then
                Me.LicensePlate = _Element.LicensePlate
                Me.Neighbor = _Element.Neighbor
                Me.Brand = _Element.Brand
                Me.Model1 = _Element.Model1
                Me.TypeOfVehicle = _Element.TypeOfVehicle
            End If
        End Set
    End Property

    Public Property BtnNew As Boolean
        Get
            Return _BtnNew
        End Get
        Set(value As Boolean)
            _BtnNew = value
            NotificarCambio("BtnNew")
        End Set
    End Property

    Public Property BtnSave As Boolean
        Get
            Return _BtnSave
        End Get
        Set(value As Boolean)
            _BtnSave = value
            NotificarCambio("BtnSave")
        End Set
    End Property

    Public Property BtnDelete As Boolean
        Get
            Return _BtnDelete
        End Get
        Set(value As Boolean)
            _BtnDelete = value
            NotificarCambio("BtnDelete")
        End Set
    End Property

    Public Property BtnUpdate As Boolean
        Get
            Return _BtnUpdate
        End Get
        Set(value As Boolean)
            _BtnUpdate = value
            NotificarCambio("BtnUpdate")
        End Set
    End Property

    Public Property BtnCancel As Boolean
        Get
            Return _BtnCancel
        End Get
        Set(value As Boolean)
            _BtnCancel = value
            NotificarCambio("BtnCancel")
        End Set
    End Property
    Public Property BtnReturn As MainWindow
        Get
            Return _BtnReturn
        End Get
        Set(value As MainWindow)
            _BtnReturn = value

        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        Me.Model = Me
    End Sub
#End Region

#Region "INotifyPropertyChaged"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
#End Region

#Region "ICommand"
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        If parameter.Equals("new") Then
            Me.BtnNew = False
            Me.BtnSave = True
            Me.BtnDelete = False
            Me.BtnUpdate = False
            Me.BtnCancel = True
            Quitar()

        ElseIf parameter.Equals("save") Then
            Try
                Me.BtnNew = True
                Me.BtnSave = False
                Me.BtnDelete = True
                Me.BtnUpdate = True
                Me.BtnCancel = False

                Dim registro As New Vehicle
                registro.LicensePlate = Me.LicensePlate
                registro.Neighbor = Me.Neighbor
                registro.Brand = Me.Brand
                registro.Model1 = Me.Model1
                registro.TypeOfVehicle = Me.TypeOfVehicle

                Dim queryresult = From NQ In DB.Vehicles Where NQ.LicensePlate = Me.LicensePlate Select NQ.LicensePlate
                For Each result In queryresult
                    MsgBox("No se permiten agregar registros duplicados, Por favor corrija la licencia: " + Me.LicensePlate, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                Next

                DB.Vehicles.Add(registro)
                DB.SaveChanges()
                Quitar()

                MsgBox("Registro guardado exitosamente", MsgBoxStyle.Information, "Felicidades")

                ListVehicle = (From N In DB.Vehicles Select N).ToList
            Catch ex As Exception
                MsgBox("Rellene todos los campos correspondientes", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Danger")
            End Try

        ElseIf parameter.Equals("delete") Then
            Dim respuesta As MsgBoxResult = MsgBoxResult.No
            respuesta = MsgBox("Esta seguro de eliminar el registro", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")

            Try
                If respuesta = MessageBoxResult.Yes Then
                    DB.Vehicles.Remove(Me.Element)
                    DB.SaveChanges()
                    ListVehicle = (From N In DB.Vehicles Select N).ToList
                    MsgBox("Registro eliminado exitosamente", MsgBoxStyle.Information, "Felicidades")
                End If
            Catch ex As Exception
                MsgBox("Selecccione algun registro para eliminar", MsgBoxStyle.Critical, "Error al eliminar...")
            End Try

        ElseIf parameter.Equals("cancel") Then
            Me.BtnNew = True
            Me.BtnSave = False
            Me.BtnDelete = True
            Me.BtnUpdate = True
            Me.BtnCancel = True
            Quitar()

        ElseIf parameter.Equals("update") Then
            If Me.Element IsNot Nothing Then
                Me.Element.LicensePlate = Me.LicensePlate
                Me.Element.Neighbor = Me.Neighbor
                Me.Element.Brand = Me.Brand
                Me.Element.Model1 = Me.Model1
                Me.Element.TypeOfVehicle = Me.TypeOfVehicle

                MsgBox("Registro actualizado exitosamente", MsgBoxStyle.Information, "Felicidades")

                Me.DB.Entry(Me.Element).State = System.Data.Entity.EntityState.Modified
                Me.DB.SaveChanges()
                ListVehicle = (From N In DB.Vehicles Select N).ToList
            End If
        End If
    End Sub
#End Region

#Region "IDataErrorInfo"
    Default Public ReadOnly Property Item(columnName As String) As String Implements IDataErrorInfo.Item
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property [Error] As String Implements IDataErrorInfo.Error
        Get
            Throw New NotImplementedException()
        End Get
    End Property
#End Region

#Region "NotificarCambio"
    Public Sub NotificarCambio(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
    End Sub
    Public Sub Quitar()
        Me.LicensePlate = Nothing
        Me.Neighbor = Nothing
        Me.Brand = Nothing
        Me.Model1 = Nothing
        Me.TypeOfVehicle = Nothing
    End Sub
#End Region
End Class
