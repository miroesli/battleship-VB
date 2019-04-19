<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMenu
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
        Me.BTNMaxNum = New System.Windows.Forms.Button()
        Me.LBLYlength = New System.Windows.Forms.Label()
        Me.LBLXlength = New System.Windows.Forms.Label()
        Me.BTNLePlay = New System.Windows.Forms.Button()
        Me.NUDYLength = New System.Windows.Forms.NumericUpDown()
        Me.NUDXLength = New System.Windows.Forms.NumericUpDown()
        Me.BTNCustomize = New System.Windows.Forms.Button()
        Me.PNLCheat = New System.Windows.Forms.Panel()
        CType(Me.NUDYLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDXLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNMaxNum
        '
        Me.BTNMaxNum.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMaxNum.Location = New System.Drawing.Point(12, 178)
        Me.BTNMaxNum.Name = "BTNMaxNum"
        Me.BTNMaxNum.Size = New System.Drawing.Size(156, 69)
        Me.BTNMaxNum.TabIndex = 16
        Me.BTNMaxNum.Text = "Max it out"
        Me.BTNMaxNum.UseVisualStyleBackColor = True
        '
        'LBLYlength
        '
        Me.LBLYlength.AutoSize = True
        Me.LBLYlength.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLYlength.Location = New System.Drawing.Point(202, 250)
        Me.LBLYlength.Name = "LBLYlength"
        Me.LBLYlength.Size = New System.Drawing.Size(78, 21)
        Me.LBLYlength.TabIndex = 15
        Me.LBLYlength.Text = "Y length"
        '
        'LBLXlength
        '
        Me.LBLXlength.AutoSize = True
        Me.LBLXlength.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLXlength.Location = New System.Drawing.Point(8, 250)
        Me.LBLXlength.Name = "LBLXlength"
        Me.LBLXlength.Size = New System.Drawing.Size(78, 21)
        Me.LBLXlength.TabIndex = 14
        Me.LBLXlength.Text = "X length"
        '
        'BTNLePlay
        '
        Me.BTNLePlay.Font = New System.Drawing.Font("Modern No. 20", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNLePlay.Location = New System.Drawing.Point(12, 12)
        Me.BTNLePlay.Name = "BTNLePlay"
        Me.BTNLePlay.Size = New System.Drawing.Size(268, 160)
        Me.BTNLePlay.TabIndex = 13
        Me.BTNLePlay.Text = "Le Play"
        Me.BTNLePlay.UseVisualStyleBackColor = True
        '
        'NUDYLength
        '
        Me.NUDYLength.Location = New System.Drawing.Point(160, 274)
        Me.NUDYLength.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.NUDYLength.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NUDYLength.Name = "NUDYLength"
        Me.NUDYLength.Size = New System.Drawing.Size(120, 20)
        Me.NUDYLength.TabIndex = 12
        Me.NUDYLength.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NUDXLength
        '
        Me.NUDXLength.Location = New System.Drawing.Point(12, 274)
        Me.NUDXLength.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.NUDXLength.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NUDXLength.Name = "NUDXLength"
        Me.NUDXLength.Size = New System.Drawing.Size(120, 20)
        Me.NUDXLength.TabIndex = 11
        Me.NUDXLength.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'BTNCustomize
        '
        Me.BTNCustomize.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCustomize.Location = New System.Drawing.Point(174, 178)
        Me.BTNCustomize.Name = "BTNCustomize"
        Me.BTNCustomize.Size = New System.Drawing.Size(106, 69)
        Me.BTNCustomize.TabIndex = 17
        Me.BTNCustomize.Text = "Customize"
        Me.BTNCustomize.UseVisualStyleBackColor = True
        '
        'PNLCheat
        '
        Me.PNLCheat.Location = New System.Drawing.Point(138, 272)
        Me.PNLCheat.Name = "PNLCheat"
        Me.PNLCheat.Size = New System.Drawing.Size(16, 22)
        Me.PNLCheat.TabIndex = 18
        '
        'formMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 306)
        Me.Controls.Add(Me.PNLCheat)
        Me.Controls.Add(Me.BTNCustomize)
        Me.Controls.Add(Me.BTNMaxNum)
        Me.Controls.Add(Me.LBLYlength)
        Me.Controls.Add(Me.LBLXlength)
        Me.Controls.Add(Me.BTNLePlay)
        Me.Controls.Add(Me.NUDYLength)
        Me.Controls.Add(Me.NUDXLength)
        Me.MaximumSize = New System.Drawing.Size(300, 340)
        Me.MinimumSize = New System.Drawing.Size(300, 340)
        Me.Name = "formMenu"
        Me.Text = "Battle Ship Menu"
        CType(Me.NUDYLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDXLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNMaxNum As System.Windows.Forms.Button
    Friend WithEvents LBLYlength As System.Windows.Forms.Label
    Friend WithEvents LBLXlength As System.Windows.Forms.Label
    Friend WithEvents BTNLePlay As System.Windows.Forms.Button
    Friend WithEvents NUDYLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUDXLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents BTNCustomize As System.Windows.Forms.Button
    Friend WithEvents PNLCheat As System.Windows.Forms.Panel

End Class
