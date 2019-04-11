Imports System.ComponentModel
Imports EmetraApp2017090
Imports EmetraApp2017090.JhonyLopez.EmetraApp2017090.Model
Public Class RemissionModelView

    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _OrderNumber As Integer
    Private _RemissionDate As Date
    Private _Hour As String
    Private _Place As String

    Private _SanctionType As SanctionType
    Private _ListSanctionType As New List(Of SanctionType)

    Private _AgentNumber As Integer

    Private _Vehicle As Vehicle
    Private _ListVehicle As New List(Of Vehicle)

    Private _Agent As Agent
    Private _ListAgent As New List(Of Agent)

    Private _Model As RemissionModelView
    Private _ListRemission As New List(Of Remission)
    Private _Element As Remission

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnUpdate As Boolean = True
    Private _BtnCancel As Boolean = False

    Private DB As New EmetraApp2017090DataContext
#End Region

#Region "Propiedades"
    Public Property OrderNumber As Integer
        Get
            Return _OrderNumber
        End Get
        Set(value As Integer)
            _OrderNumber = value
            NotificarCambio("OrderNumber")
        End Set
    End Property

    Public Property RemissionDate As Date
        Get
            Return _RemissionDate
        End Get
        Set(value As Date)
            _RemissionDate = value
            NotificarCambio("RemissionDate")
        End Set
    End Property

    Public Property Hour As String
        Get
            Return _Hour
        End Get
        Set(value As String)
            _Hour = value
            NotificarCambio("Hour")
        End Set
    End Property

    Public Property Place As String
        Get
            Return _Place
        End Get
        Set(value As String)
            _Place = value
            NotificarCambio("Place")
        End Set
    End Property

    Public Property SanctionType As SanctionType
        Get
            Return _SanctionType
        End Get
        Set(value As SanctionType)
            _SanctionType = value
            NotificarCambio("SanctionType")
        End Set
    End Property

    Public Property ListSanctionType As List(Of SanctionType)
        Get
            If _ListSanctionType.Count = 0 Then
                _ListSanctionType = (From N In DB.SanctionTypes Select N).ToList
            End If
            Return _ListSanctionType
        End Get
        Set(value As List(Of SanctionType))
            _ListSanctionType = value
            NotificarCambio("ListSanctionType")
        End Set
    End Property

    Public Property AgentNumber As Integer
        Get
            Return _AgentNumber
        End Get
        Set(value As Integer)
            _AgentNumber = value
            NotificarCambio("AgentNumber")
        End Set
    End Property

    Public Property Vehicle As Vehicle
        Get
            Return _Vehicle
        End Get
        Set(value As Vehicle)
            _Vehicle = value
            NotificarCambio("Vehicle")
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

    Public Property Agent As Agent
        Get
            Return _Agent
        End Get
        Set(value As Agent)
            _Agent = value
            NotificarCambio("Agent")
        End Set
    End Property

    Public Property ListAgent As List(Of Agent)
        Get
            If _ListAgent.Count = 0 Then
                _ListAgent = (From N In DB.Agents Select N).ToList
            End If
            Return _ListAgent
        End Get
        Set(value As List(Of Agent))
            _ListAgent = value
            NotificarCambio("ListAgent")
        End Set
    End Property

    Public Property Model As RemissionModelView
        Get
            Return _Model
        End Get
        Set(value As RemissionModelView)
            _Model = value
        End Set
    End Property

    Public Property ListRemission As List(Of Remission)
        Get
            If _ListRemission.Count = 0 Then
                _ListRemission = (From N In DB.Remissions Select N).ToList
            End If
            Return _ListRemission
        End Get
        Set(value As List(Of Remission))
            _ListRemission = value
            NotificarCambio("ListRemission")
        End Set
    End Property

    Public Property Element As Remission
        Get
            Return _Element
        End Get
        Set(value As Remission)
            _Element = value
            NotificarCambio("Element")
            If (value IsNot Nothing) Then
                Me.OrderNumber = _Element.OrderNumber
                Me.RemissionDate = _Element.RemissionDate
                Me.Hour = _Element.Hour
                Me.Place = _Element.Place
                Me.SanctionType = _Element.SanctionType
                Me.AgentNumber = _Element.AgentNumber
                Me.Vehicle = _Element.Vehicle
                Me.Agent = _Element.Agent
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

                Dim registro As New Remission

                registro.OrderNumber = Me.OrderNumber
                registro.RemissionDate = Me.RemissionDate
                registro.Hour = Me.Hour
                registro.Place = Me.Place
                registro.SanctionType = Me.SanctionType
                registro.AgentNumber = Me.AgentNumber
                registro.Vehicle = Me.Vehicle
                registro.Agent = Me.Agent

                Dim queryresult = From NQ In DB.Remissions Where NQ.OrderNumber = Me.OrderNumber Select NQ.OrderNumber
                For Each result In queryresult
                    MsgBox("No se permiten agregar registros duplicados, Por favor corrija el numero de orden: " + Me.OrderNumber, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                Next

                DB.Remissions.Add(registro)
                DB.SaveChanges()
                Quitar()

                ListRemission = (From N In DB.Remissions Select N).ToList
            Catch ex As Exception
                MsgBox("Rellene todos los campos correspondientes", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Danger")
            End Try

        ElseIf parameter.Equals("delete") Then
            Dim respuesta As MsgBoxResult = MsgBoxResult.No
            respuesta = MsgBox("Esta seguro de eliminar el registro", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")

            Try
                If respuesta = MessageBoxResult.Yes Then
                    DB.Remissions.Remove(Me.Element)
                    DB.SaveChanges()
                    ListRemission = (From N In DB.Remissions Select N).ToList
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
                Me.Element.OrderNumber = Me.OrderNumber
                Me.Element.RemissionDate = Me.RemissionDate
                Me.Element.Hour = Me.Hour
                Me.Element.Place = Me.Place
                Me.Element.SanctionType = Me.SanctionType
                Me.Element.AgentNumber = Me.AgentNumber
                Me.Element.Vehicle = Me.Vehicle
                Me.Element.Agent = Me.Agent

                Me.DB.Entry(Me.Element).State = System.Data.Entity.EntityState.Modified
                Me.DB.SaveChanges()
                ListRemission = (From N In DB.Remissions Select N).ToList
            End If
        End If
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
#End Region

#Region "IDataErrorInfo"
    Public ReadOnly Property [Error] As String Implements IDataErrorInfo.Error
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Default Public ReadOnly Property Item(columnName As String) As String Implements IDataErrorInfo.Item
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
        Me.OrderNumber = Nothing
        Me.RemissionDate = Nothing
        Me.Hour = Nothing
        Me.Place = Nothing
        Me.SanctionType = Nothing
        Me.AgentNumber = Nothing
        Me.Vehicle = Nothing
        Me.Agent = Nothing
    End Sub
#End Region
End Class
