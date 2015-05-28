Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports netrheinruhr

Namespace Controllers
    Public Class KurseController
        Inherits System.Web.Http.ApiController

        Private db As New Model1

        ' GET: api/Kurse
        Function GetKurse() As IQueryable(Of Kurse)
            Return db.Kurse
        End Function

        ' GET: api/Kurse/5
        <ResponseType(GetType(Kurse))>
        Function GetKurse(ByVal id As Integer) As IHttpActionResult
            Dim kurse As Kurse = db.Kurse.Find(id)
            If IsNothing(kurse) Then
                Return NotFound()
            End If

            Return Ok(kurse)
        End Function

        ' PUT: api/Kurse/5
        <ResponseType(GetType(Void))>
        Function PutKurse(ByVal id As Integer, ByVal kurse As Kurse) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = kurse.Id Then
                Return BadRequest()
            End If

            db.Entry(kurse).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (KurseExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Kurse
        <ResponseType(GetType(Kurse))>
        Function PostKurse(ByVal kurse As Kurse) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If
            Dim id = db.Kurse.Max(Function(x) x.Id) + 1
            kurse.Id = id
            db.Kurse.Add(kurse)
            MyHub1.updateClients(kurse) 'ein kurs

            Try
                db.SaveChanges()
            Catch ex As DbUpdateException
                If (KurseExists(kurse.Id)) Then
                    Return Conflict()
                Else
                    Throw
                End If
            End Try

            Return CreatedAtRoute("DefaultApi", New With {.id = kurse.Id}, kurse)
        End Function

        ' DELETE: api/Kurse/5
        <ResponseType(GetType(Kurse))>
        Function DeleteKurse(ByVal id As Integer) As IHttpActionResult
            Dim kurse As Kurse = db.Kurse.Find(id)
            If IsNothing(kurse) Then
                Return NotFound()
            End If

            db.Kurse.Remove(kurse)
            db.SaveChanges()

            Return Ok(kurse)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function KurseExists(ByVal id As Integer) As Boolean
            Return db.Kurse.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace