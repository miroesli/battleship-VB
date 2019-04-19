<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formBS
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
        Me.LBLTurn = New System.Windows.Forms.Label()
        Me.BTNgotomenu = New System.Windows.Forms.Button()
        Me.BTNRestart = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LBLTurn
        '
        Me.LBLTurn.AutoSize = True
        Me.LBLTurn.Location = New System.Drawing.Point(174, 17)
        Me.LBLTurn.Name = "LBLTurn"
        Me.LBLTurn.Size = New System.Drawing.Size(48, 13)
        Me.LBLTurn.TabIndex = 0
        Me.LBLTurn.Text = "LBLTurn"
        Me.LBLTurn.Visible = False
        '
        'BTNgotomenu
        '
        Me.BTNgotomenu.Location = New System.Drawing.Point(12, 12)
        Me.BTNgotomenu.Name = "BTNgotomenu"
        Me.BTNgotomenu.Size = New System.Drawing.Size(75, 23)
        Me.BTNgotomenu.TabIndex = 1
        Me.BTNgotomenu.Text = "Go to Menu"
        Me.BTNgotomenu.UseVisualStyleBackColor = True
        '
        'BTNRestart
        '
        Me.BTNRestart.Location = New System.Drawing.Point(93, 12)
        Me.BTNRestart.Name = "BTNRestart"
        Me.BTNRestart.Size = New System.Drawing.Size(75, 23)
        Me.BTNRestart.TabIndex = 2
        Me.BTNRestart.Text = "Restart"
        Me.BTNRestart.UseVisualStyleBackColor = True
        '
        'formBS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 264)
        Me.Controls.Add(Me.BTNRestart)
        Me.Controls.Add(Me.BTNgotomenu)
        Me.Controls.Add(Me.LBLTurn)
        Me.Name = "formBS"
        Me.Text = "Battle Ship"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBLTurn As System.Windows.Forms.Label
    Friend WithEvents BTNgotomenu As System.Windows.Forms.Button
    Friend WithEvents BTNRestart As System.Windows.Forms.Button
End Class
