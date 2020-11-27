Imports Projet_Taquin.Joueur
Public Class Form2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Not ComboBox1.Text = "" Then

            ComboBox1.Text = StrConv(ComboBox1.Text, VbStrConv.ProperCase)

            Me.Hide()
            Form1.Show()

            ComboBox1.Items.Add(ComboBox1.Text)
            Dim j As Joueur.joueur = New Joueur.joueur(ComboBox1.Text)
            Joueur.ajouterJoueur(j)
            j.incNbPartiesJouees()
            Form1.lblNom.Text = j.getNom

        End If


    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        If Not (e.KeyChar >= "0" AndAlso e.KeyChar >= "9") Then
            e.Handled = True
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        ComboBox1.Sorted = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form3.Show()
    End Sub
End Class