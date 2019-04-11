Imports System.ComponentModel
Imports EmetraApp2017090
Imports EmetraApp2017090.JhonyLopez.EmetraApp2017090.Model
Public Class AgentModelView

    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _AgentID As Integer
    Private _AgentNumber As Integer
    Private _AgentName As String
    Private _AgentLastName As String
    Private _Charge As String
    Private _Salary As Decimal
    Private _Commission As Decimal

    Private _Model As AgentModelView
    Private _ListAgent As New List(Of Agent)
    Private _Element As Agent

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnUpdate As Boolean = True
    Private _BtnCancel As Boolean = False

    Private DB As New EmetraApp2017090DataContext
#End Region

#Region "Propiedades"
    Public Property AgentID As Integer
        Get
            Return _AgentID
        End Get
        Set(value As Integer)
            _AgentID = value
            NotificarCambio("AgentID")
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

    Public Property AgentName As String
        Get
            Return _AgentName
        End Get
        Set(value As String)
            _AgentName = value
            NotificarCambio("AgentName")
        End Set
    End Property

    Public Property AgentLastName As String
        Get
            Return _AgentLastName
        End Get
        Set(value As String)
            _AgentLastName = value
            NotificarCambio("AgentLastName")
        End Set
    End Property

    Public Property Charge As String
        Get
            Return _Charge
        End Get
        Set(value As String)
            _Charge = value
            NotificarCambio("Charge")
        End Set
    End Property

    Public Property Salary As Decimal
        Get
            Return _Salary
        End Get
        Set(value As Decimal)
            _Salary = value
            NotificarCambio("Salary")
        End Set
    End Property

    Public Property Commission As Decimal
        Get
            Return _Commission
        End Get
        Set(value As Decimal)
            _Commission = value
            NotificarCambio("Commission")
        End Set
    End Property

    Public Property Model As AgentModelView
        Get
            Return _Model
        End Get
        Set(value As AgentModelView)
            _Model = value
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

    Public Property Element As Agent
        Get
            Return _Element
        End Get
        Set(value As Agent)
            _Element = value
            NotificarCambio("Element")

            If (value IsNot Nothing) Then
                Me.AgentID = _Element.AgentID
                Me.AgentNumber = _Element.AgentNumber
                Me.AgentName = _Element.AgentName
                Me.AgentLastName = _Element.AgentLastName
                Me.Charge = _Element.Charge
                Me.Salary = _Element.Salary
                Me.Commission = _Element.Commission
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

                Dim registro As New Agent
                registro.AgentID = Me.AgentID
                registro.AgentNumber = Me.AgentNumber
                registro.AgentName = Me.AgentName
                registro.AgentLastName = Me.AgentLastName
                registro.Charge = Me.Charge
                registro.Salary = Me.Salary
                registro.Commission = Me.Commission

                DB.Agents.Add(registro)
                DB.SaveChanges()
                Quitar()

                ListAgent = (From N In DB.Agents Select N).ToList
            Catch ex As Exception
                MsgBox("Rellene todos los campos correspondientes", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Danger")
            End Try

        ElseIf parameter.Equals("delete") Then
            Dim respuesta As MsgBoxResult = MsgBoxResult.No
            respuesta = MsgBox("Esta seguro de eliminar el registro", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")

            Try
                If respuesta = MessageBoxResult.Yes Then
                    DB.Agents.Remove(Me.Element)
                    DB.SaveChanges()
                    ListAgent = (From N In DB.Agents Select N).ToList
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
                Me.Element.AgentID = Me.AgentID
                Me.Element.AgentNumber = Me.AgentNumber
                Me.Element.AgentName = Me.AgentName
                Me.Element.AgentLastName = Me.AgentLastName
                Me.Element.Charge = Me.Charge
                Me.Element.Salary = Me.Salary
                Me.Element.Commission = Me.Commission

                Me.DB.Entry(Me.Element).State = System.Data.Entity.EntityState.Modified
                Me.DB.SaveChanges()
                ListAgent = (From N In DB.Agents Select N).ToList
            End If
        End If
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
#End Region

#Region "IDataErroInfo"
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
        Me.AgentID = Nothing
        Me.AgentNumber = Nothing
        Me.AgentName = Nothing
        Me.AgentLastName = Nothing
        Me.Charge = Nothing
        Me.Salary = Nothing
        Me.Commission = Nothing
    End Sub
#End Region
End Class
