Imports Microsoft.AspNet.SignalR

Public Class MyHub1
    Inherits Hub

  
    Public Shared Sub updateClients(kurs)
        Dim ctx = GlobalHost.ConnectionManager.GetHubContext(Of MyHub1)()
        ctx.Clients.All.freshme(kurs)
    End Sub

End Class
