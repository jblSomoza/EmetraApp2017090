Imports System.ComponentModel
Imports EmetraApp2017090
Imports EmetraApp2017090.JhonyLopez.EmetraApp2017090.Model
Public Class NeighborModelView

    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _NIT As String
    Private _DPI As Integer
    Private _FirstName As String
    Private _LastName As String
    Private _Adress As String
    Private _Municipality As String
    Private _PostalCode As Integer
    Private _Telephone As Integer

    Private _Model As NeighborModelView
    Private _ListNeighbor As New List(Of Neighbor)
    Private _Element As Neighbor

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnCancel As Boolean = False
    Private _BtnUpdate As Boolean = True

    Private DB As New EmetraApp2017090DataContext
#End Region

#Region "Propiedades"
    Public Property NIT As String
        Get
            Return _NIT
        End Get
        Set(value As String)
            _NIT = value
            NotificarCambio("NIT")
        End Set
    End Property

    Public Property DPI As Integer
        Get
            Return _DPI
        End Get
        Set(value As Integer)
            _DPI = value
            NotificarCambio("DPI")
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _FirstName
        End Get
        Set(value As String)
            _FirstName = value
            NotificarCambio("FirstName")
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _LastName
        End Get
        Set(value As String)
            _LastName = value
            NotificarCambio("LastName")
        End Set
    End Property

    Public Property Adress As String
        Get
            Return _Adress
        End Get
        Set(value As String)
            _Adress = value
            NotificarCambio("Adress")
        End Set
    End Property

    Public Property Municipality As String
        Get
            Return _Municipality
        End Get
        Set(value As String)
            _Municipality = value
            NotificarCambio("Municipality")
        End Set
    End Property

    Public Property PostalCode As Integer
        Get
            Return _PostalCode
        End Get
        Set(value As Integer)
            _PostalCode = value
            NotificarCambio("PostalCode")
        End Set
    End Property

    Public Property Telephone As Integer
        Get
            Return _Telephone
        End Get
        Set(value As Integer)
            _Telephone = value
            NotificarCambio("Telephone")
        End Set
    End Property

    Public Property Model As NeighborModelView
        Get
            Return _Model
        End Get
        Set(value As NeighborModelView)
            _Model = value
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

    Public Property Element As Neighbor
        Get
            Return _Element
        End Get
        Set(value As Neighbor)
            _Element = value
            NotificarCambio("Element")

            If (value IsNot Nothing) Then
                Me.NIT = _Element.NIT
                Me.DPI = _Element.DPI
                Me.FirstName = _Element.FirstName
                Me.LastName = _Element.LastName
                Me.Adress = _Element.Adress
                Me.Municipality = _Element.Municipality
                Me.PostalCode = _Element.PostalCode
                Me.Telephone = _Element.Telephone
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

    Public Property BtnCancel As Boolean
        Get
            Return _BtnCancel
        End Get
        Set(value As Boolean)
            _BtnCancel = value
            NotificarCambio("BtnCancel")
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
#End Region

#Region "Constructor"
    Public Sub New()
        Me.Model = Me
    End Sub
#End Region

#Region "INotifyPropertyChanged"
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
            Me.BtnCancel = True
            Me.BtnUpdate = False
            Quitar()

        ElseIf parameter.Equals("save") Then
            Try
                Me.BtnNew = True
                Me.BtnSave = False
                Me.BtnDelete = True
                Me.BtnCancel = False
                Me.BtnUpdate = True

                Dim registro As New Neighbor

                registro.NIT = Me.NIT
                registro.DPI = Me.DPI
                registro.FirstName = Me.FirstName
                registro.LastName = Me.LastName
                registro.Adress = Me.Adress
                registro.Municipality = Me.Municipality
                registro.PostalCode = Me.PostalCode
                registro.Telephone = Me.Telephone

                Dim queryresult = From NQ In DB.Neighbors Where NQ.NIT = Me.NIT Select NQ.NIT
                For Each result In queryresult
                    MsgBox("No se permiten agregar registros duplicados, Por favor corrija el NIT: " + Me.NIT, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                Next

                DB.Neighbors.Add(registro)
                DB.SaveChanges()
                Quitar()

                ListNeighbor = (From N In DB.Neighbors Select N).ToList
            Catch ex As Exception
                MsgBox("Rellene todos los campos correspondientes", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Danger")
            End Try

        ElseIf parameter.Equals("delete") Then
            Dim respuesta As MsgBoxResult = MsgBoxResult.No

            respuesta = MsgBox("¿Esta seguro de eliminar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")

            Try
                If respuesta = MessageBoxResult.Yes Then
                    DB.Neighbors.Remove(Me.Element)
                    DB.SaveChanges()
                    ListNeighbor = (From N In DB.Neighbors Select N).ToList
                End If
            Catch ex As Exception
                MsgBox("Selecccione algun registro para eliminar", MsgBoxStyle.Critical, "Error al eliminar...")
            End Try

        ElseIf parameter.Equals("cancel") Then
            Me.BtnNew = True
            Me.BtnSave = False
            Me.BtnDelete = True
            Me.BtnCancel = False
            Me.BtnUpdate = True
            Quitar()

        ElseIf parameter.Equals("update") Then
            If Me.Element IsNot Nothing Then
                Me.Element.NIT = Me.NIT
                Me.Element.DPI = Me.DPI
                Me.Element.FirstName = Me.FirstName
                Me.Element.LastName = Me.LastName
                Me.Element.Adress = Me.Adress
                Me.Element.Municipality = Me.Municipality
                Me.Element.PostalCode = Me.PostalCode
                Me.Element.Telephone = Me.Telephone

                Me.DB.Entry(Me.Element).State = System.Data.Entity.EntityState.Modified
                Me.DB.SaveChanges()
                ListNeighbor = (From N In DB.Neighbors Select N).ToList
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
        Me.NIT = Nothing
        Me.DPI = Nothing
        Me.FirstName = Nothing
        Me.LastName = Nothing
        Me.Adress = Nothing
        Me.Municipality = Nothing
        Me.PostalCode = Nothing
        Me.Telephone = Nothing
    End Sub
#End Region
End Class
