Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class Model1
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Model1")        
    End Sub

    Public Overridable Property Kurse As DbSet(Of Kurse)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Kurse)() _
            .Property(Function(e) e.beschreibung) _
            .IsUnicode(False)
    End Sub
End Class
