Public Class SelectSetup
    Dim forceclose As Boolean = True
    Private Sub BTNYes_Click(sender As System.Object, e As System.EventArgs) Handles BTNYes.Click
        formMenu.WillRandom = "yes"
        formBS.Show()
        forceclose = False
        Me.Close()
    End Sub

    Private Sub BTNNo_Click(sender As System.Object, e As System.EventArgs) Handles BTNNo.Click
        formMenu.WillRandom = "no"
        formBS.Show()
        forceclose = False
        Me.Close()
    End Sub

    'Private Sub SelectSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    'LBLQuestion.Text = "You will be starting with 3 ships. One with length 2, length 3, length 4, and the last with length 5 (Unless customized otherwise). Would you like us to randomly place them?"
    ' End Sub

    Private Sub LBLQuestion_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub form_closed(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        If forceclose = True Then
            formMenu.WindowState = FormWindowState.Normal
        End If
    End Sub
End Class