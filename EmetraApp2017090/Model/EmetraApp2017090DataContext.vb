Imports System.Data.Entity
Imports System.Data.SqlClient
Imports System.Data.Entity.ModelConfiguration.Conventions
Namespace JhonyLopez.EmetraApp2017090.Model
    Public Class EmetraApp2017090DataContext
        Inherits DbContext
        Public Property Neighbors() As DbSet(Of Neighbor)
        Public Property Vehicles() As DbSet(Of Vehicle)
        Public Property Agents() As DbSet(Of Agent)
        Public Property Remissions() As DbSet(Of Remission)
        Public Property SanctionTypes() As DbSet(Of SanctionType)
    End Class
End Namespace
