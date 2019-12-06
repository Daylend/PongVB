Public Class Form1
    '418, 151 441, 183 433, 218
    Dim buttonPosition As Integer = 0
    Dim easter As Boolean = False
    Dim hSpeed As Integer = 5
    Dim vSpeed As Integer = -5

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If easter = True Then
            easter = False
            buttonPosition = 0
            Timer1.Enabled = False
            Timer2.Enabled = True
        End If


        Select Case e.KeyData
            Case Keys.Up
                If buttonPosition > 0 Then
                    buttonPosition -= 1
                End If
            Case Keys.Down
                If buttonPosition < 2 Then
                    buttonPosition += 1
                End If
            Case Keys.Enter
                Select Case buttonPosition
                    Case 0
                        Pong.Show()
                        Me.Hide()
                    Case 1
                        'Help
                    Case 2
                        'Options
                End Select
        End Select

        Select Case buttonPosition
            Case 0
                PictureBox1.Location = New Point(418, 151)
            Case 1
                PictureBox1.Location = New Point(441, 183)
            Case 2
                PictureBox1.Location = New Point(430, 214)
        End Select

        Timer2.Enabled = False
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        easter = True
        Timer1.Enabled = True
        Timer2.Enabled = False

    End Sub

    'EASTER EGG CODE --------------------------------------------------------------------------------------------
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Move it
        PictureBox1.Left += hSpeed
        PictureBox1.Top += vSpeed

        'Wall collision
        If PictureBox1.Left <= 0 Or getRight(PictureBox1) >= Me.ClientSize.Width Then
            hSpeed = (hSpeed * -1)
        End If

        If PictureBox1.Top <= 0 Or getBottom(PictureBox1) >= Me.ClientSize.Height Then
            vSpeed = (vSpeed * -1)
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        easter = True
        Timer1.Enabled = True
        Timer2.Enabled = False
    End Sub

    'Get right side of object (x)
    Function getRight(ByVal picBox As PictureBox) As Integer
        Dim x As Integer = picBox.Left + picBox.Width

        Return x

    End Function

    'Get bottom of object (y)
    Function getBottom(ByVal picBox As PictureBox) As Integer
        Dim y As Integer = picBox.Top + picBox.Height

        Return y
    End Function
End Class