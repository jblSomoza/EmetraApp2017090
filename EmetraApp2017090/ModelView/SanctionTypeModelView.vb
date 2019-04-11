Imports System.ComponentModel
Imports EmetraApp2017090
Imports EmetraApp2017090.JhonyLopez.EmetraApp2017090.Model
Public Class SanctionTypeModelView

    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _RemissionID As Integer
    Private _Description As String
    Private _Import As Decimal
    Private _Recurrent As String

    Private _Model As SanctionTypeModelView
    Private _ListSanctionType As New List(Of SanctionType)
    Private _Element As SanctionType

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnUpdate As Boolean = True
    Private _BtnCancel As Boolean = False

    Private DB As New EmetraApp2017090DataContext
#End Region

#Region "Propiedades"
    Public Property RemissionID As Integer
        Get
            Return _RemissionID
        End Get
        Set(value As Integer)
            _RemissionID = value
            NotificarCambio("RemissionID")
        End Set
    End Property

    Public Property Description As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
            NotificarCambio("Description")
        End Set
    End Property

    Public Property Import As Decimal
        Get
            Return _Import
        End Get
        Set(value As Decimal)
            _Import = value
            NotificarCambio("Import")
        End Set
    End Property

    Public Property Recurrent As String
        Get
            Return _Recurrent
        End Get
        Set(value As String)
            _Recurrent = value
            NotificarCambio("Recurrent")
        End Set
    End Property

    Public Property Model As SanctionTypeModelView
        Get
            Return _Model
        End Get
        Set(value As SanctionTypeModelView)
            _Model = value
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

    Public Property Element As SanctionType
        Get
            Return _Element
        End Get
        Set(value As SanctionType)
            _Element = value
            NotificarCambio("Element")

            If (value IsNot Nothing) Then
                Me.RemissionID = _Element.RemissionID
                Me.Description = _Element.Description
                Me.Import = _Element.Import
                Me.Recurrent = _Element.Recurrent
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

                Dim registro As New SanctionType

                registro.RemissionID = Me.RemissionID
                registro.Description = Me.Description
                registro.Import = Me.Import
                registro.Recurrent = Me.Recurrent

                DB.SanctionTypes.Add(registro)
                DB.SaveChanges()
                Quitar()

                ListSanctionType = (From N In DB.SanctionTypes Select N).ToList
            Catch ex As Exception
                MsgBox("Rellene todos los campos correspondientes", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Danger")
            End Try

        ElseIf parameter.Equals("delete") Then
            Dim respuesta As MsgBoxResult = MsgBoxResult.No
            respuesta = MsgBox("Esta seguro de eliminar el registro", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")

            Try
                If respuesta = MessageBoxResult.Yes Then
                    DB.SanctionTypes.Remove(Me.Element)
                    DB.SaveChanges()
                    ListSanctionType = (From N In DB.SanctionTypes Select N).ToList
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
                Me.Element.RemissionID = Me.RemissionID
                Me.Element.Description = Me.Description
                Me.Element.Import = Me.Import
                Me.Element.Recurrent = Me.Recurrent

                Me.DB.Entry(Me.Element).State = System.Data.Entity.EntityState.Modified
                Me.DB.SaveChanges()
                ListSanctionType = (From N In DB.SanctionTypes Select N).ToList
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

#Region "NotificarCambios"
    Public Sub NotificarCambio(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
    End Sub
    Public Sub Quitar()
        Me.RemissionID = Nothing
        Me.Description = Nothing
        Me.Import = Nothing
        Me.Recurrent = Nothing
    End Sub
#End Region

End Class
