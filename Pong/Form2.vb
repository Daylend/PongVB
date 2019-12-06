Public Class Pong
    Dim hSpeed As Integer = 5
    Dim vSpeed As Integer = 5
    Dim bounces As Integer = 0
    Dim bounceLimit As Integer = 10
    Dim countdown As Integer = 3
    Dim sensitivity As Integer = 7
    Dim difficulty As Integer = 0
    Dim paused As Boolean = False
    Dim p1ScoreVal As Integer = 0
    Dim p2ScoreVal As Integer = 0
    Dim rand As New Random()

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles gameTimer.Tick
        'Move it
        box.Left += hSpeed
        box.Top += vSpeed


        'Wall collisions
        'Horizontal
        If box.Left <= 0 Or getRight(box) >= Me.ClientSize.Width Then

            'Increment scores
            If box.Left <= 0 Then
                p1ScoreVal += 1
            Else
                p2ScoreVal += 1
            End If

            'Reset EVERYTHING... except scores.
            'If you change the locations of the bumpers you'll have to change this
            lBumper.Location = New Point(25, 180)
            rBumper.Location = New Point(900, 180)
            box.Location = New Point(460, 239)
            gameTimer.Enabled = False
            cdwnTimer.Enabled = True
            p1Score.Text = p1ScoreVal
            p2Score.Text = p2ScoreVal
            resetSpeed()
            difficulty = 0
            sensitivity = 7
            Me.Text = "Pong     Difficulty: " & difficulty
            bounceLimit = 10
        End If

            'Vertical
            If box.Top <= 0 Or getBottom(box) >= Me.ClientSize.Height Then
                vSpeed = (vSpeed * -1)
                bounces += 1
            End If

            'Checking for collisions w/ paddles, check subroutine.
            checkCollision(lBumper)
            checkCollision(rBumper)

            'Difficulty progression
            If bounces >= bounceLimit Then
                If Math.Abs(hSpeed) < 19 Then
                incSpeed(hSpeed, 1)
                incSpeed(vSpeed, 1)
                sensitivity += 1
                difficulty += 1
                Me.Text = "Pong     Difficulty: " & difficulty
                '40% increase in bounce limit, fixes exponential speed increase
                bounceLimit = bounceLimit * 1.4

                'Fun stuff
                Select Case difficulty
                    Case 5
                        box.BackColor = Color.GreenYellow
                    Case 8
                        box.BackColor = Color.Yellow
                    Case 10
                        box.BackColor = Color.Firebrick
                    Case 12
                        box.BackColor = Color.Red
                    Case 13
                        box.Size = New Size(15, 15)
                        Me.Text = "Pong     Difficulty: FINAL"
                        bounceLimit = 666
                    Case 14
                        'Code me
                        Me.Text = "PONG HELL."
                End Select
            End If
        End If

        'Player controls (left)
        If GetAsyncKeyState(Keys.W) Then
            If lBumper.Top >= 0 Then
                lBumper.Top -= sensitivity
            End If
        ElseIf GetAsyncKeyState(Keys.S) Then
            If getBottom(lBumper) <= Me.ClientSize.Height Then
                lBumper.Top += sensitivity
            End If
        End If

        'Player controls (right)
        If GetAsyncKeyState(Keys.Up) Then
            If rBumper.Top >= 0 Then
                rBumper.Top -= sensitivity
            End If
        ElseIf GetAsyncKeyState(Keys.Down) Then
            If getBottom(rBumper) <= Me.ClientSize.Height Then
                rBumper.Top += sensitivity
            End If
        End If

    End Sub

    '3...2...1...
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles cdwnTimer.Tick
        If countdown <= 0 Then
            gameTimer.Enabled = True
            cdwnTimer.Enabled = False
            p1Score.Visible = True
            p2Score.Visible = True
            countdown = 3
            lblCountdown.Text = ""
            paused = False

            'Pauses after countdown if not in focus
            If Not Me.Focused Then
                pauseGame()
            End If
        Else
            paused = True
            lblCountdown.Location = New Point(456, 43)
            lblCountdown.Text = countdown
            countdown -= 1
        End If
    End Sub

    Private Sub Pong_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'Could write a switch for this but not that important atm
        If e.KeyValue = Keys.Q Or e.KeyValue = Keys.P Then
            pauseGame()
        End If

        'Back to menu
        If e.KeyValue = Keys.Escape Then
            If paused = False Then
                pauseGame()
            End If

            Me.Hide()
            Form1.Show()
        End If
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

    'Not sure if I'll need these but just in case.
    Function getX(ByVal picbox As PictureBox) As Integer
        Dim x As Integer = picbox.Left + (picbox.Width / 2)

        Return x
    End Function

    Function getY(ByVal picbox As PictureBox) As Integer
        Dim y As Integer = picbox.Top - (picbox.Height / 2)

        Return y
    End Function

    'Checks for negative values
    Sub incSpeed(ByRef speed As Integer, ByVal inc As Integer)
        If speed >= 0 Then
            speed += inc
        ElseIf speed < 0 Then
            speed -= inc
        End If
    End Sub

    'Reset h and vSpeed at random. Starting to bug me that hspeed and vspeed aren't a part of the box class
    Sub resetSpeed()
        Dim speedH As Boolean = rand.Next(0, 2)
        Dim speedV As Boolean = rand.Next(0, 2)

        If speedH Then
            hSpeed = 5
        Else
            hSpeed = -5
        End If

        If speedV Then
            vSpeed = 5
        Else
            vSpeed = -5
        End If

    End Sub

    'Checks both sides to make this subroutine work for both/all paddles
    Sub checkCollision(ByVal bumper As PictureBox)
        'If the left side of the box is past the left side of the bumper (->) and the left side of the box is left or on the right side of the bumper
        If box.Left >= bumper.Left And box.Left <= getRight(bumper) Then
            'If the top of the box is higher than or equal to the bottom of the bumper and the bottom of the box is lower than or equal to the top of the bumper
            If box.Top <= getBottom(bumper) And getBottom(box) >= bumper.Top Then
                box.Left = bumper.Left + bumper.Width + 1
                hSpeed = (hSpeed * -1)
                bounces += 1
            End If
        ElseIf getRight(box) >= bumper.Left And getRight(box) <= getRight(bumper) Then
            If box.Top <= getBottom(bumper) And getBottom(box) >= bumper.Top Then
                box.Left = bumper.Left - bumper.Width - 1
                hSpeed = (hSpeed * -1)
                bounces += 1
            End If
        End If
    End Sub

    Sub pauseGame()
        If paused Then
            cdwnTimer.Enabled = True
        ElseIf cdwnTimer.Enabled = False Then
            gameTimer.Enabled = False
            lblCountdown.Location = New Point(400, 43)
            lblCountdown.Text = "PAUSED"
            paused = True
        End If
    End Sub

    'Exclusive function for getting key state
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer

    Private Sub Pong_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Close()
    End Sub

    Private Sub Pong_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If paused = False Then
            pauseGame()
        ElseIf cdwnTimer.Enabled = True Then
            cdwnTimer.Enabled = False
            pauseGame()
        End If
    End Sub

    Private Sub Pong_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        resetSpeed()
    End Sub
End Class
