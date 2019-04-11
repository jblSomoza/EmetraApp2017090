Public Class MainPrincipalView
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = New MainPrincipalModelView
    End Sub
End Class
