<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectSetup
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
        Me.BTNYes = New System.Windows.Forms.Button()
        Me.BTNNo = New System.Windows.Forms.Button()
        Me.LBLDedicatedto = New System.Windows.Forms.Label()
        Me.LBLWelcome = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BTNYes
        '
        Me.BTNYes.Location = New System.Drawing.Point(12, 95)
        Me.BTNYes.Name = "BTNYes"
        Me.BTNYes.Size = New System.Drawing.Size(152, 72)
        Me.BTNYes.TabIndex = 0
        Me.BTNYes.Text = "Yes, do randomize"
        Me.BTNYes.UseVisualStyleBackColor = True
        '
        'BTNNo
        '
        Me.BTNNo.Location = New System.Drawing.Point(170, 95)
        Me.BTNNo.Name = "BTNNo"
        Me.BTNNo.Size = New System.Drawing.Size(152, 72)
        Me.BTNNo.TabIndex = 1
        Me.BTNNo.Text = "No, Do not randomize"
        Me.BTNNo.UseVisualStyleBackColor = True
        '
        'LBLDedicatedto
        '
        Me.LBLDedicatedto.AutoSize = True
        Me.LBLDedicatedto.Location = New System.Drawing.Point(12, 170)
        Me.LBLDedicatedto.Name = "LBLDedicatedto"
        Me.LBLDedicatedto.Size = New System.Drawing.Size(310, 13)
        Me.LBLDedicatedto.TabIndex = 2
        Me.LBLDedicatedto.Text = "This Form is dedicated to a special teacher called Mr.McDonald."
        '
        'LBLWelcome
        '
        Me.LBLWelcome.AutoSize = True
        Me.LBLWelcome.Location = New System.Drawing.Point(12, 9)
        Me.LBLWelcome.Name = "LBLWelcome"
        Me.LBLWelcome.Size = New System.Drawing.Size(116, 13)
        Me.LBLWelcome.TabIndex = 3
        Me.LBLWelcome.Text = "Welcome to Battleship!"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 25)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(307, 64)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "You will be starting with 3 ships. One with length 2, length 3, length 4, and the" & _
    " last with length 5 (Unless customized otherwise). Would you like us to randomly" & _
    " place them?"
        '
        'SelectSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 192)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LBLWelcome)
        Me.Controls.Add(Me.LBLDedicatedto)
        Me.Controls.Add(Me.BTNNo)
        Me.Controls.Add(Me.BTNYes)
        Me.Name = "SelectSetup"
        Me.Text = "SelectSetup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNYes As System.Windows.Forms.Button
    Friend WithEvents BTNNo As System.Windows.Forms.Button
    Friend WithEvents LBLDedicatedto As System.Windows.Forms.Label
    Friend WithEvents LBLWelcome As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
