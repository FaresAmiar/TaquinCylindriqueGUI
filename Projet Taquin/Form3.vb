Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles Me.Shown
        ListBox1.Items.Clear()
        For i As Integer = 0 To joueurs.Count - 1
            ListBox1.Items.Add(joueurs(i).getNom & " " & joueurs(i).getMeilleurTps)
        Next

    End Sub
End Class