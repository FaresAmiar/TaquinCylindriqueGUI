Imports System.IO
Public Class Form1

    Dim damier() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"}
    Dim nombre() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"}
    Dim triche As Boolean = False
    Dim bouton As Button = Nothing
    Dim temps As Double = 0
    Dim nomJoueur As String
    Dim coupAJouer(120) As String
    Dim etatFinal = 0
    Dim etatsDuTaquin(499, 15)


    Private Sub Button_Click(sender As Object, e As EventArgs) _
        Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click

        If Timer1.Enabled = False Then
            Timer1.Interval = 100
            Timer1.Enabled = True
        End If

        If triche Then
            If bouton Is Nothing Then
                bouton = sender
            Else
                Dim tmp As String = bouton.Text
                bouton.Text = sender.text
                sender.text = tmp

                bouton = Nothing
                Button17.PerformClick()
            End If


            Exit Sub
        End If
        If peutBouger(sender) Then
            Dim bouton_ref As Integer

            For i As Integer = 0 To Panel1.Controls.Count - 1

                If Panel1.Controls(i).Text = "0" Then
                    bouton_ref = i
                End If

            Next i

            Panel1.Controls(bouton_ref).Text = sender.Text
            Panel1.Controls(bouton_ref).Visible = True
            sender.Text = "0"
            sender.Visible = False
            Panel1.Controls(bouton_ref).Focus()


        End If

        For i As Integer = 0 To Panel1.Controls.Count - 1
            damier(i) = Panel1.Controls(i).Text
        Next i

        If checkTaquin() Then
            Timer1.Enabled = False
            'If Joueur.joueurs(nomJoueur).getMeilleurTps() = 0 Or Joueur.joueurs(nomJoueur).getMeilleurTps() > temps Then
            '    Joueur.joueurs(nomJoueur).setMeilleurTps(temps)
            'End If
            'Joueur.joueurs(nomJoueur).incTpsJoue(temps)
            MsgBox("Bravo")
            Me.Close()
            Form2.Show()
        End If

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown



        nomJoueur = Form2.ComboBox1.Text
        triche = False
        bouton = Nothing
        temps = 0
        Label2.Text = temps

        For i As Integer = 0 To Panel1.Controls.Count - 1
            Panel1.Controls(i).Text = damier(i)
        Next

        For i As Integer = 0 To 5 'difficulte
            For Each b As Button In Panel1.Controls
                If peutBouger(b) Then
                    Button_Click(b, e)
                End If
            Next
        Next


        For i As Integer = 0 To Panel1.Controls.Count - 1

            If Panel1.Controls(i).Text = "0" Then
                Panel1.Controls(i).Visible = False
            End If

        Next

    End Sub

    Private Function peutBouger(bouton As Button) As Boolean

        For i As Integer = 0 To Panel1.Controls.Count - 1
            If Panel1.Controls(i).Text = bouton.Text Then

                If i Mod 4 = 0 Then

                    If i < 4 Then
                        If Panel1.Controls(i + 3).Text = "0" Or Panel1.Controls(i + 1).Text = "0" Or Panel1.Controls(i + 4).Text = "0" Then
                            Return True
                        End If
                    ElseIf i > 11 Then
                        If Panel1.Controls(i + 3).Text = "0" Or Panel1.Controls(i + 1).Text = "0" Or Panel1.Controls(i - 4).Text = "0" Then
                            Return True
                        End If
                    Else
                        If Panel1.Controls(i + 3).Text = "0" Or Panel1.Controls(i + 1).Text = "0" Or Panel1.Controls(i + 4).Text = "0" Or Panel1.Controls(i - 4).Text = "0" Then
                            Return True
                        End If
                    End If

                ElseIf i Mod 4 = 3 Then

                    If i < 4 Then
                        If Panel1.Controls(i - 3).Text = "0" Or Panel1.Controls(i - 1).Text = "0" Or Panel1.Controls(i + 4).Text = "0" Then
                            Return True
                        End If
                    ElseIf i > 11 Then
                        If Panel1.Controls(i - 3).Text = "0" Or Panel1.Controls(i - 1).Text = "0" Or Panel1.Controls(i - 4).Text = "0" Then
                            Return True
                        End If
                    Else
                        If Panel1.Controls(i - 3).Text = "0" Or Panel1.Controls(i - 1).Text = "0" Or Panel1.Controls(i + 4).Text = "0" Or Panel1.Controls(i - 4).Text = "0" Then
                            Return True
                        End If
                    End If

                ElseIf i < 4 Then
                    If Panel1.Controls(i - 1).Text = "0" Or Panel1.Controls(i + 1).Text = "0" Or Panel1.Controls(i + 4).Text = "0" Then
                        Return True
                    End If

                ElseIf i > 11 Then
                    If Panel1.Controls(i - 1).Text = "0" Or Panel1.Controls(i + 1).Text = "0" Or Panel1.Controls(i - 4).Text = "0" Then
                        Return True
                    End If

                Else

                    If Panel1.Controls(i - 1).Text = "0" Or Panel1.Controls(i + 1).Text = "0" Or Panel1.Controls(i - 4).Text = "0" Or Panel1.Controls(i + 4).Text = "0" Then
                        Return True
                    End If

                End If
            End If

        Next i
        Return False

    End Function

    Private Function checkTaquin() As Boolean
        Dim test As Boolean = True

        For i As Integer = 1 To damier.Length - 2
            If Not (damier(i - 1) + 1 = damier(i) Or damier(i + 1) - 1 = damier(i)) Then
                test = False
            End If
        Next i

        Return test

    End Function

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If triche Then
            triche = False
            Label1.Text = ""
            bouton = Nothing
        Else
            triche = True
            Label1.Text = "triche"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If temps > 1500000000 Then
            Timer1.Enabled = False
            MsgBox("PERDU GROS NUL")
            'Joueur.joueurs(nomJoueur).incTpsJoue(60)
            Me.Close()
            Form2.Show()
        End If

        temps = temps + 0.1
        Label2.Text = Strings.RSet(temps, 4)

    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim colonne_droite() As String = {"0", "0", "0", "0"}
        Dim compteur As Integer = 0
        Dim i As Integer = Panel1.Controls.Count - 1

        While i >= 0
            If i Mod 4 <> 0 Then
                If i Mod 4 = 3 Then
                    colonne_droite(compteur) = Panel1.Controls(i).Text
                    compteur = compteur + 1
                    Panel1.Controls(i).Text = Panel1.Controls(i - 1).Text
                Else
                    Panel1.Controls(i).Text = Panel1.Controls(i - 1).Text
                End If
            End If
            i = i - 1
        End While

        compteur = compteur - 1

        For j As Integer = 0 To Panel1.Controls.Count - 1
            If j Mod 4 = 0 Then
                Panel1.Controls(j).Text = colonne_droite(compteur)
                compteur = compteur - 1
            End If
            If Panel1.Controls(j).Text <> "0" Then
                Panel1.Controls(j).Visible = True
            Else
                Panel1.Controls(j).Visible = False
            End If
        Next j

        For j As Integer = 0 To Panel1.Controls.Count - 1
            damier(j) = Panel1.Controls(j).Text
        Next j

        If checkTaquin() Then
            Timer1.Enabled = False
            MsgBox("Bravo")
            Me.Close()
            Form2.Show()
        End If

    End Sub


    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim colonne_gauche() As String = {"0", "0", "0", "0"}
        Dim compteur As Integer = 0
        Dim j As Integer = Panel1.Controls.Count - 1

        For i As Integer = 0 To Panel1.Controls.Count - 1
            If i Mod 4 <> 3 Then
                If i Mod 4 = 0 Then
                    colonne_gauche(compteur) = Panel1.Controls(i).Text
                    compteur = compteur + 1
                    Panel1.Controls(i).Text = Panel1.Controls(i + 1).Text
                Else
                    Panel1.Controls(i).Text = Panel1.Controls(i + 1).Text
                End If
            End If
        Next i

        compteur = compteur - 1

        While j >= 0
            If j Mod 4 = 3 Then
                Panel1.Controls(j).Text = colonne_gauche(compteur)
                compteur = compteur - 1
            End If
            If Panel1.Controls(j).Text <> "0" Then
                Panel1.Controls(j).Visible = True
            Else
                Panel1.Controls(j).Visible = False
            End If
            j = j - 1
        End While

        For i As Integer = 0 To Panel1.Controls.Count - 1
            damier(i) = Panel1.Controls(i).Text
        Next i

        If checkTaquin() Then
            Timer1.Enabled = False
            MsgBox("Bravo")
            Me.Close()
            Form2.Show()
        End If

    End Sub

    'La fonction a besoin du nom du fichier avec les infos du taq
    'elle retourne le chemin du fichier avec la solution
    Public Sub TaquinSoluce()
        Dim commande = "scriptTaquin.bat"
        Dim taquinTranscrit = transcrireTaquin(damier)
        ecrireTaquinTranscrit(taquinTranscrit)
        'Shell(commande)

        Dim p_Taquin As New Process()
        Dim pInfo As New ProcessStartInfo(commande)
        pInfo.WindowStyle = ProcessWindowStyle.Hidden
        p_Taquin.StartInfo = pInfo
        p_Taquin.Start()
        p_Taquin.WaitForExit()

        retranscrireTaquin()
    End Sub

    'Ecrit le taquin transcrit dans un fichier
    Private Sub ecrireTaquinTranscrit(ByRef tab())
        'Remplacer le fichier existant avec de nouvelles valeurs
        Dim fw As New FileStream("fichierDuTaquinEnCours.txt", FileMode.Create)
        fw.Close()
        'Creation d'un stream pour ecrire dans le fichier
        Dim sw As New StreamWriter("fichierDuTaquinEnCours.txt")
        sw.WriteLine("4 4")
        For i As Integer = 0 To tab.Count - 1
            sw.WriteLine(tab(i))
        Next
        sw.Close()
    End Sub

    'Transcrit le taquin pour le resolveur
    Private Function transcrireTaquin(ByRef tab() As String)
        Dim taquinTranscrit(3) As String
        'Variable pour garder le parcours du tableau et rassembler les 4 valeurs sur une meme ligne
        Dim k = 0
        Dim PremierL1 = 0, PremierL2 = 4, PremierL3 = 8, PremierL4 = 12, DernierL1 = 3, DernierL2 = 7, DernierL3 = 11, DernierL4 = 15
        For i As Integer = 0 To taquinTranscrit.Count - 1

            'Indice pour mettre les indices cote a cote
            For i_temp As Integer = k To tab.Count - 1
                If tab(i_temp) = "0" Then
                    If i_temp = PremierL1 OrElse i_temp = PremierL2 OrElse i_temp = PremierL3 OrElse i_temp = PremierL4 Then
                        taquinTranscrit(i) += "  #"
                    ElseIf i_temp = DernierL1 OrElse i_temp = DernierL2 OrElse i_temp = DernierL3 OrElse i_temp = DernierL4 Then
                        taquinTranscrit(i) += "  #  "

                    Else
                        taquinTranscrit(i) += "  #"
                    End If



                Else
                    If i_temp = PremierL1 OrElse i_temp = PremierL2 OrElse i_temp = PremierL3 OrElse i_temp = PremierL4 Then
                        If tab(i_temp).Count = 2 Then
                            taquinTranscrit(i) += "  " & tab(i_temp)
                        Else
                            taquinTranscrit(i) += "  " & tab(i_temp)
                        End If

                    ElseIf i_temp = DernierL1 OrElse i_temp = DernierL2 OrElse i_temp = DernierL3 OrElse i_temp = DernierL4 Then
                        If tab(i_temp).Count = 1 Then
                            taquinTranscrit(i) += "  " & tab(i_temp) + "  "
                        Else
                            taquinTranscrit(i) += " " & tab(i_temp) + "  "
                        End If
                    Else
                        If tab(i_temp).Count = 1 Then
                            taquinTranscrit(i) += "  " & tab(i_temp)
                        Else
                            taquinTranscrit(i) += "  " & tab(i_temp)
                        End If

                    End If

                End If

                k = i_temp
                If i_temp = DernierL1 OrElse i_temp = DernierL2 OrElse i_temp = DernierL3 OrElse i_temp = DernierL4 Then
                    k += 1
                    Exit For
                End If
            Next
        Next
        Return taquinTranscrit
    End Function

    'transcrire le taquin vb en taquin txt pour c++
    Sub retranscrireTaquin()


        Dim sr As New StreamReader("fichierDuTaquinResolu.txt")
        Dim buffer As String = ""

        Dim i As Integer = 0
        Dim j As Integer = 0
        For k = 0 To 6
            sr.ReadLine()
        Next
        While sr.EndOfStream = False



            'Flush du buffer pour continuer le parcours
            buffer = ""

            'Etat suivant

            'Iterations de transcription pour un etat
            While (buffer.Contains("SUD") = False AndAlso buffer.Contains("OUEST") = False AndAlso buffer.Contains("NORD") = False AndAlso buffer.Contains("EST") = False) _
                AndAlso sr.EndOfStream = False
                'Premiere ligne
                buffer = sr.ReadLine()
                For j = 0 To 3
                    If j = 3 Then
                        If buffer.Length = 4 Then
                            etatsDuTaquin(i, j) = buffer.Substring(2, 2)
                        Else
                            If buffer(2) = "#" Then
                                etatsDuTaquin(i, j) = "0"
                            Else
                                etatsDuTaquin(i, j) = buffer(2)
                            End If
                        End If
                        Exit For
                    End If
                    If (buffer(3) = " ") Then
                        If buffer(2) = "#" Then
                            etatsDuTaquin(i, j) = "0"
                        Else
                            etatsDuTaquin(i, j) = buffer(2)
                        End If
                        buffer = buffer.Substring(3)
                    Else
                        etatsDuTaquin(i, j) = buffer.Substring(2, 2)
                        buffer = buffer.Substring(4)
                    End If
                Next

                '2e ligne
                buffer = sr.ReadLine
                For j = 4 To 7
                    If j = 7 Then
                        If buffer.Length = 4 Then
                            etatsDuTaquin(i, j) = buffer.Substring(2, 2)
                        Else
                            If buffer(2) = "#" Then
                                etatsDuTaquin(i, j) = "0"
                            Else
                                etatsDuTaquin(i, j) = buffer(2)
                            End If
                        End If
                        Exit For
                    End If
                    If (buffer(3) = " ") Then
                        If buffer(2) = "#" Then
                            etatsDuTaquin(i, j) = "0"
                        Else
                            etatsDuTaquin(i, j) = buffer(2)
                        End If
                        buffer = buffer.Substring(3)
                    Else
                        etatsDuTaquin(i, j) = buffer.Substring(2, 2)
                        buffer = buffer.Substring(4)
                    End If
                Next

                '3e ligne
                buffer = sr.ReadLine
                For j = 8 To 11
                    If j = 11 Then
                        If buffer.Length = 4 Then
                            etatsDuTaquin(i, j) = buffer.Substring(2, 2)
                        Else
                            If buffer(2) = "#" Then
                                etatsDuTaquin(i, j) = "0"
                            Else
                                etatsDuTaquin(i, j) = buffer(2)
                            End If
                        End If
                        Exit For
                    End If
                    If (buffer(3) = " ") Then
                        If buffer(2) = "#" Then
                            etatsDuTaquin(i, j) = "0"
                        Else
                            etatsDuTaquin(i, j) = buffer(2)
                        End If
                        buffer = buffer.Substring(3)
                    Else
                        etatsDuTaquin(i, j) = buffer.Substring(2, 2)
                        buffer = buffer.Substring(4)
                    End If
                Next

                '4e ligne
                buffer = sr.ReadLine
                For j = 12 To 15
                    If j = 15 Then
                        If buffer.Length = 4 Then
                            etatsDuTaquin(i, j) = buffer.Substring(2, 2)
                        Else
                            If buffer(2) = "#" Then
                                etatsDuTaquin(i, j) = "0"
                            Else
                                etatsDuTaquin(i, j) = buffer(2)
                            End If
                        End If
                        Exit For
                    End If
                    If (buffer(3) = " ") Then
                        If buffer(2) = "#" Then
                            etatsDuTaquin(i, j) = "0"
                        Else
                            etatsDuTaquin(i, j) = buffer(2)
                        End If
                        buffer = buffer.Substring(3)
                    Else
                        etatsDuTaquin(i, j) = buffer.Substring(2, 2)
                        buffer = buffer.Substring(4)
                    End If
                Next

                'Fin de l'etat, on s'attend a tomber sur une position (NORD, SUD,...) apres ou la fin du fichier
                buffer = sr.ReadLine()
                If buffer Is Nothing Then
                    buffer = ""
                    Exit While
                End If
            End While

            If sr.EndOfStream = True Then
                Exit While
            End If
            i += 1
        End While
        etatFinal = i
        sr.Close()
    End Sub

    Private Sub btnResolution_Click(sender As Object, e As EventArgs) Handles btnResolution.Click
        'Etats recuperés du taquin
        TaquinSoluce()

        Dim etatfinal() = recupererEtat(Me.etatFinal)
        resoudreTaquin(etatfinal)
        actualiserAffichage()

    End Sub

    Private Sub btnCoupSuivant_Click(sender As Object, e As EventArgs) Handles btnCoupSuivant.Click
        TaquinSuiv()
        CoupSuivant()
        algoCoupSuivant()
        supprimerFichier()
    End Sub

    Public Sub TaquinSuiv()
        Dim commande = "scriptTaquin.bat"
        Dim taquinTranscrit = transcrireTaquin(damier)
        ecrireTaquinTranscrit(taquinTranscrit)
        'Shell(commande)

        Dim p_Taquin As New Process()
        Dim pInfo As New ProcessStartInfo(commande)
        pInfo.WindowStyle = ProcessWindowStyle.Hidden
        p_Taquin.StartInfo = pInfo
        p_Taquin.Start()
        p_Taquin.WaitForExit()


    End Sub
    Private Sub supprimerFichier()
        Shell("supp.bat")
    End Sub

    'Lit les mouvements
    Public Sub CoupSuivant()

        Dim sr As New StreamReader("fichierDuTaquinResolu.txt")

        For j As Integer = 0 To coupAJouer.Count - 1
            coupAJouer(j) = ""
        Next

        Dim buffer
        Dim i As Integer
        For k = 0 To 5
            sr.ReadLine()
        Next

        While sr.EndOfStream = False
            buffer = sr.ReadLine
            coupAJouer(i) = buffer
            For l As Integer = 0 To 3
                sr.ReadLine()
            Next
            i += 1
        End While
    End Sub

    Public Sub algoCoupSuivant()
        Dim e As New EventArgs()
        Dim j As Integer
        For i As Integer = 0 To Panel1.Controls.Count - 1
            If Panel1.Controls(i).Text = "0" Then
                j = i
            End If
        Next

        Select Case coupAJouer(0)
            Case "SUD"
                Button_Click(Panel1.Controls(j + 4), e)
            Case "NORD"
                Button_Click(Panel1.Controls(j - 4), e)
            Case "OUEST"
                Button_Click(Panel1.Controls(j - 1), e)
            Case "EST"
                Button_Click(Panel1.Controls(j + 1), e)
        End Select

    End Sub

    'Remplace le damier du taquin par la solution du taquin
    Private Sub resoudreTaquin(tab() As String)
        For i = 0 To damier.Count - 1
            damier(i) = tab(i)
        Next
    End Sub


    'Fonction qui recupere le tableau un etat donné
    Public Function recupererEtat(i As Integer) As String()
        Dim tabtemp(15) As String
        For j As Integer = 0 To 15
            tabtemp(j) = etatsDuTaquin(i, j)
        Next
        Return tabtemp
    End Function

    'Procedure qui actualise l'affichage du taquin
    Public Sub actualiserAffichage()
        For i As Integer = 0 To Panel1.Controls.Count - 1
            Panel1.Controls(i).Text = damier(i)
            If damier(i) = "0" Then
                Panel1.Controls(i).Visible = False
            End If
        Next
    End Sub



End Class
