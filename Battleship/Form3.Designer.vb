<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPSU
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
        Me.RBHoriz = New System.Windows.Forms.RadioButton()
        Me.RBVert = New System.Windows.Forms.RadioButton()
        Me.GBRotation = New System.Windows.Forms.GroupBox()
        Me.GBLength = New System.Windows.Forms.GroupBox()
        Me.LBbslength = New System.Windows.Forms.ListBox()
        Me.BTNForceClose = New System.Windows.Forms.Button()
        Me.LBLWarning = New System.Windows.Forms.Label()
        Me.LBLWarning2 = New System.Windows.Forms.Label()
        Me.GBRotation.SuspendLayout()
        Me.GBLength.SuspendLayout()
        Me.SuspendLayout()
        '
        'RBHoriz
        '
        Me.RBHoriz.AutoSize = True
        Me.RBHoriz.Location = New System.Drawing.Point(6, 19)
        Me.RBHoriz.Name = "RBHoriz"
        Me.RBHoriz.Size = New System.Drawing.Size(72, 17)
        Me.RBHoriz.TabIndex = 0
        Me.RBHoriz.TabStop = True
        Me.RBHoriz.Text = "Horizontal"
        Me.RBHoriz.UseVisualStyleBackColor = True
        '
        'RBVert
        '
        Me.RBVert.AutoSize = True
        Me.RBVert.Location = New System.Drawing.Point(6, 42)
        Me.RBVert.Name = "RBVert"
        Me.RBVert.Size = New System.Drawing.Size(60, 17)
        Me.RBVert.TabIndex = 1
        Me.RBVert.TabStop = True
        Me.RBVert.Text = "Vertical"
        Me.RBVert.UseVisualStyleBackColor = True
        '
        'GBRotation
        '
        Me.GBRotation.Controls.Add(Me.RBHoriz)
        Me.GBRotation.Controls.Add(Me.RBVert)
        Me.GBRotation.Location = New System.Drawing.Point(293, 118)
        Me.GBRotation.Name = "GBRotation"
        Me.GBRotation.Size = New System.Drawing.Size(110, 65)
        Me.GBRotation.TabIndex = 2
        Me.GBRotation.TabStop = False
        Me.GBRotation.Text = "Rotation"
        '
        'GBLength
        '
        Me.GBLength.Controls.Add(Me.LBbslength)
        Me.GBLength.Location = New System.Drawing.Point(293, 12)
        Me.GBLength.Name = "GBLength"
        Me.GBLength.Size = New System.Drawing.Size(200, 100)
        Me.GBLength.TabIndex = 3
        Me.GBLength.TabStop = False
        Me.GBLength.Text = "Battleshiplength"
        '
        'LBbslength
        '
        Me.LBbslength.FormattingEnabled = True
        Me.LBbslength.Location = New System.Drawing.Point(6, 19)
        Me.LBbslength.Name = "LBbslength"
        Me.LBbslength.Size = New System.Drawing.Size(188, 69)
        Me.LBbslength.TabIndex = 0
        '
        'BTNForceClose
        '
        Me.BTNForceClose.Location = New System.Drawing.Point(293, 190)
        Me.BTNForceClose.Name = "BTNForceClose"
        Me.BTNForceClose.Size = New System.Drawing.Size(75, 23)
        Me.BTNForceClose.TabIndex = 4
        Me.BTNForceClose.Text = "Force Close"
        Me.BTNForceClose.UseVisualStyleBackColor = True
        '
        'LBLWarning
        '
        Me.LBLWarning.AutoSize = True
        Me.LBLWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLWarning.Location = New System.Drawing.Point(290, 216)
        Me.LBLWarning.Name = "LBLWarning"
        Me.LBLWarning.Size = New System.Drawing.Size(105, 13)
        Me.LBLWarning.TabIndex = 5
        Me.LBLWarning.Text = "Hover over a button!"
        '
        'LBLWarning2
        '
        Me.LBLWarning2.AutoSize = True
        Me.LBLWarning2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLWarning2.Location = New System.Drawing.Point(290, 229)
        Me.LBLWarning2.Name = "LBLWarning2"
        Me.LBLWarning2.Size = New System.Drawing.Size(74, 13)
        Me.LBLWarning2.TabIndex = 6
        Me.LBLWarning2.Text = "Click to place."
        '
        'FormPSU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 266)
        Me.Controls.Add(Me.LBLWarning2)
        Me.Controls.Add(Me.LBLWarning)
        Me.Controls.Add(Me.BTNForceClose)
        Me.Controls.Add(Me.GBLength)
        Me.Controls.Add(Me.GBRotation)
        Me.Name = "FormPSU"
        Me.Text = "Battleship Setup"
        Me.GBRotation.ResumeLayout(False)
        Me.GBRotation.PerformLayout()
        Me.GBLength.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RBHoriz As System.Windows.Forms.RadioButton
    Friend WithEvents RBVert As System.Windows.Forms.RadioButton
    Friend WithEvents GBRotation As System.Windows.Forms.GroupBox
    Friend WithEvents GBLength As System.Windows.Forms.GroupBox
    Friend WithEvents LBbslength As System.Windows.Forms.ListBox
    Friend WithEvents BTNForceClose As System.Windows.Forms.Button
    Friend WithEvents LBLWarning As System.Windows.Forms.Label
    Friend WithEvents LBLWarning2 As System.Windows.Forms.Label
End Class
