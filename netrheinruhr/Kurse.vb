Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Kurse")>
Partial Public Class Kurse
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property Id As Integer

    <StringLength(50)>
    Public Property beschreibung As String

    <Column(TypeName:="date")>
    Public Property datum As Date?
End Class
