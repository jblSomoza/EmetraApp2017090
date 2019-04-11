Imports System.ComponentModel
Imports EmetraApp2017090
Public Class MainPrincipalModelView

    Implements INotifyPropertyChanged, ICommand

#Region "Campos"
    Private _Model As MainPrincipalModelView
#End Region

#Region "Propiedades"
    Public Property Model As MainPrincipalModelView
        Get
            Return _Model
        End Get
        Set(value As MainPrincipalModelView)
            _Model = value
            NotificarCambio("Model")
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
        If parameter.Equals("neighbor") Then
            Dim ventanaNeighbor As New NeighborView()
            ventanaNeighbor.ShowDialog()

        ElseIf parameter.Equals("agent") Then
            Dim ventanaAgent As New AgentView()
            ventanaAgent.ShowDialog()

        ElseIf parameter.Equals("remission") Then
            Dim ventanaRemission As New RemissionView()
            ventanaRemission.ShowDialog()

        ElseIf parameter.Equals("sanctiontype") Then
            Dim ventanaSanctionType As New SanctionTypeView()
            ventanaSanctionType.ShowDialog()

        ElseIf parameter.Equals("vehicle") Then
            Dim ventanaVehicle As New VehicleView()
            ventanaVehicle.ShowDialog()
        End If
    End Sub
    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
#End Region

#Region "NotificarCambio"
    Public Sub NotificarCambio(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
    End Sub
#End Region

End Class
