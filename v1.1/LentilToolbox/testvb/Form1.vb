Imports INFITF

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next
        Dim CATIA As Application
        CATIA = GetObject(, "CATIA.Application")
        If Err.Number <> 0 Then
            CATIA = CreateObject("CATIA.Application")
            CATIA.Visible = True
        End If
    End Sub
End Class
