Module Joueur

    Public joueurs As List(Of joueur) = New List(Of joueur)
    Public meilleurTps As List(Of joueur) = New List(Of joueur)
    Public j_sauv As List(Of joueur) = New List(Of joueur)
    Public Class joueur
        Private nom As String
        Private meilleurTemps As Double
        Private nbPartiesJouees As Integer
        Private tpsJoue As Double

        Public Sub New(nom As String)
            Me.nom = nom
        End Sub


        Public Function getNom() As String
            Return nom
        End Function
        Public Function getMeilleurTps() As Double
            Return meilleurTemps
        End Function
        Public Function getNbPartiesJouees() As Integer
            Return nbPartiesJouees
        End Function
        Public Function getTpsJoue() As Double
            Return tpsJoue
        End Function
        Public Sub setMeilleurTps(tps As Double)
            meilleurTemps = tps
        End Sub
        Public Sub incTpsJoue(tps As Double)
            tpsJoue += tps
        End Sub

        Public Sub incNbPartiesJouees()
            nbPartiesJouees += 1
        End Sub

    End Class

    Public Sub ajouterJoueur(j As joueur)
        joueurs.Add(j)
    End Sub

    Public Sub trierJoueur()
        'meilleurTps.Clear()
        'Dim k As joueur
        'j_sauv.Clear()
        'For i As Integer = 0 To joueurs.Count - 1
        '    j_sauv.Add(joueurs(i))
        'Next

        'For i As Integer = 0 To joueurs.Count - 1
        '    k = joueurs.ElementAt(i)
        '    For j As Integer = 1 To joueurs.Count - 1
        '        If k.getMeilleurTps() < joueurs.ElementAt(j).getMeilleurTps() Then

        '            k = joueurs.ElementAt(j)
        '        End If
        '    Next
        '    joueurs.Remove(k)
        '    If meilleurTps.Count() <= 5 Then
        '        meilleurTps.Add(k)
        '    End If
        'Next

        'For i As Integer = 0 To j_sauv.Count - 1
        '    joueurs.Add(j_sauv(i))
        'Next

        Dim meilleurTempsCompare = New meilleurTempsCompare

        For i As Integer = 0 To joueurs.Count - 1
            joueurs.Sort(i, i + 1, meilleurTempsCompare)
        Next


    End Sub
    Public Class meilleurTempsCompare
        Implements IComparer

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Dim j1 As joueur = CType(x, joueur)
            Dim j2 As joueur = CType(y, joueur)
            Return j1.getMeilleurTps() > j2.getMeilleurTps()
        End Function

    End Class



End Module
