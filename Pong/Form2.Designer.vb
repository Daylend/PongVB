<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pong
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.box = New System.Windows.Forms.PictureBox()
        Me.gameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.cdwnTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblCountdown = New System.Windows.Forms.Label()
        Me.lBumper = New System.Windows.Forms.PictureBox()
        Me.rBumper = New System.Windows.Forms.PictureBox()
        Me.p1Score = New System.Windows.Forms.Label()
        Me.p2Score = New System.Windows.Forms.Label()
        CType(Me.box, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lBumper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rBumper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'box
        '
        Me.box.BackColor = System.Drawing.Color.Lime
        Me.box.Location = New System.Drawing.Point(460, 239)
        Me.box.Name = "box"
        Me.box.Size = New System.Drawing.Size(25, 25)
        Me.box.TabIndex = 0
        Me.box.TabStop = False
        '
        'gameTimer
        '
        Me.gameTimer.Interval = 10
        '
        'cdwnTimer
        '
        Me.cdwnTimer.Enabled = True
        Me.cdwnTimer.Interval = 1000
        '
        'lblCountdown
        '
        Me.lblCountdown.AutoSize = True
        Me.lblCountdown.BackColor = System.Drawing.Color.Transparent
        Me.lblCountdown.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountdown.ForeColor = System.Drawing.Color.Lime
        Me.lblCountdown.Location = New System.Drawing.Point(456, 43)
        Me.lblCountdown.Name = "lblCountdown"
        Me.lblCountdown.Size = New System.Drawing.Size(33, 36)
        Me.lblCountdown.TabIndex = 1
        Me.lblCountdown.Text = "3"
        Me.lblCountdown.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lBumper
        '
        Me.lBumper.BackColor = System.Drawing.Color.Lime
        Me.lBumper.Location = New System.Drawing.Point(25, 180)
        Me.lBumper.Name = "lBumper"
        Me.lBumper.Size = New System.Drawing.Size(20, 143)
        Me.lBumper.TabIndex = 2
        Me.lBumper.TabStop = False
        '
        'rBumper
        '
        Me.rBumper.BackColor = System.Drawing.Color.Lime
        Me.rBumper.Location = New System.Drawing.Point(900, 180)
        Me.rBumper.Name = "rBumper"
        Me.rBumper.Size = New System.Drawing.Size(20, 143)
        Me.rBumper.TabIndex = 3
        Me.rBumper.TabStop = False
        '
        'p1Score
        '
        Me.p1Score.AutoSize = True
        Me.p1Score.BackColor = System.Drawing.Color.Transparent
        Me.p1Score.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.p1Score.ForeColor = System.Drawing.Color.Green
        Me.p1Score.Location = New System.Drawing.Point(427, 22)
        Me.p1Score.Name = "p1Score"
        Me.p1Score.Size = New System.Drawing.Size(23, 25)
        Me.p1Score.TabIndex = 4
        Me.p1Score.Text = "0"
        Me.p1Score.Visible = False
        '
        'p2Score
        '
        Me.p2Score.AutoSize = True
        Me.p2Score.BackColor = System.Drawing.Color.Transparent
        Me.p2Score.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.p2Score.ForeColor = System.Drawing.Color.Green
        Me.p2Score.Location = New System.Drawing.Point(495, 22)
        Me.p2Score.Name = "p2Score"
        Me.p2Score.Size = New System.Drawing.Size(23, 25)
        Me.p2Score.TabIndex = 5
        Me.p2Score.Text = "0"
        Me.p2Score.Visible = False
        '
        'Pong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(944, 502)
        Me.Controls.Add(Me.rBumper)
        Me.Controls.Add(Me.lBumper)
        Me.Controls.Add(Me.lblCountdown)
        Me.Controls.Add(Me.box)
        Me.Controls.Add(Me.p1Score)
        Me.Controls.Add(Me.p2Score)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(960, 540)
        Me.Name = "Pong"
        Me.Text = "Pong     Difficulty: 0"
        CType(Me.box, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lBumper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rBumper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents box As System.Windows.Forms.PictureBox
    Friend WithEvents gameTimer As System.Windows.Forms.Timer
    Friend WithEvents cdwnTimer As System.Windows.Forms.Timer
    Friend WithEvents lblCountdown As System.Windows.Forms.Label
    Friend WithEvents lBumper As System.Windows.Forms.PictureBox
    Friend WithEvents rBumper As System.Windows.Forms.PictureBox
    Friend WithEvents p1Score As System.Windows.Forms.Label
    Friend WithEvents p2Score As System.Windows.Forms.Label

End Class
