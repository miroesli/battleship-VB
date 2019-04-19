Public Class FormPSU
    Dim xlength As Integer = formBS.xlength
    Dim ylength As Integer = formBS.ylength
    'Dim shiplength(formMenu.shiplengthcustom) As Integer
    Public playertilesetup(formBS.xlength, formBS.ylength) As Button
    Dim Counter As Integer = 0
    Dim currentShipLength As Integer
    Public forceclose As Boolean = False
    Public Shiplengthcustomizedorder(formMenu.ShipNumberCustom + 1)
    'Notes:
    'add ship lengths and items depending on the customized thing but by default 2,3,5
    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        formMenu.formpsuopen = True
        For x = 0 To formBS.xlength - 1
            For y = 0 To formBS.ylength - 1
                playertilesetup(x, y) = New Button
                playertilesetup(x, y).Name = x & "," & y
                playertilesetup(x, y).Size = New System.Drawing.Size(formBS.xsize, formBS.ysize)
                playertilesetup(x, y).Location = New System.Drawing.Point(x * formBS.xsize, y * formBS.ysize)
                playertilesetup(x, y).Enabled = True
                playertilesetup(x, y).Tag = 0
                'playertile(x, y).BackColor = Color.Gainsboro
                playertilesetup(x, y).BringToFront()
                AddHandler playertilesetup(x, y).Click, AddressOf playertileset_Click
                AddHandler playertilesetup(x, y).MouseHover, AddressOf playertilemouse_enter
                Me.Controls.Add(playertilesetup(x, y))
            Next
        Next
        Me.Size = New System.Drawing.Size(formBS.xsize * formBS.xlength + 40 + LBbslength.Size.Width, formBS.ysize * formBS.ylength + 34)
        Me.Location = New System.Drawing.Point(25, 25)
        Me.MaximumSize = New Size(formBS.xsize * formBS.xlength + 40 + LBbslength.Size.Width, formBS.ysize * formBS.ylength + 34)
        Me.MinimumSize = New Size(formBS.xsize * formBS.xlength + 40 + LBbslength.Size.Width, formBS.ysize * formBS.ylength + 34)

        GBLength.Location = New System.Drawing.Point(formBS.xsize * formBS.xlength + 10, 12)
        GBRotation.Location = New System.Drawing.Point(formBS.xsize * formBS.xlength + 10, 118)
        BTNForceClose.Location = New System.Drawing.Point(formBS.xsize * formBS.xlength + 10, 190)
        LBLWarning.Location = New System.Drawing.Point(formBS.xsize * formBS.xlength + 10, 216)
        LBLWarning2.Location = New System.Drawing.Point(formBS.xsize * formBS.xlength + 10, 229)
        'playertilesetup(0, 0).Select()
        Addlengths()
        'LBbslength.Items.Add(2)
    End Sub

    Private Sub FormPSU_closed() Handles MyBase.FormClosed
        If Not LBbslength.Items.Count = Nothing And forceclose = False Then
            MsgBox("Please finish placing ships. Restarting...")
            formMenu.restart()
        ElseIf forceclose = True Then
            formBS.Close()
            'formMenu.Show()
        End If
        forceclose = False
        formMenu.formpsuopen = True
    End Sub
    Private Sub Addlengths()
        If formMenu.customchanged = False Then
            LBbslength.Items.Add(2)
            LBbslength.Items.Add(3)
            LBbslength.Items.Add(4)
            LBbslength.Items.Add(5)
            Shiplengthcustomizedorder(1) = 2
            Shiplengthcustomizedorder(2) = 3
            Shiplengthcustomizedorder(3) = 4
            Shiplengthcustomizedorder(4) = 5
        Else
            Dim Random As New Random
            Dim Randomlength = Random.Next(2, formMenu.ShipLengthCustom)
            For x = 0 To formMenu.ShipNumberCustom - 1
                Randomlength = Random.Next(2, formMenu.ShipLengthCustom)
                Shiplengthcustomizedorder(x + 1) = Randomlength
                LBbslength.Items.Add(Randomlength)
            Next
        End If

    End Sub
    Private Sub playertileset_Click(sender As System.Object, e As System.EventArgs)
        Dim position() As String = sender.Name.Split(",")
        Dim xPos As Integer = CInt(position(0))
        Dim yPos As Integer = CInt(position(1))
        'place permanant ship and then remove the count of ships by one and move to next length ship
        If playertilesetup(xPos, yPos).BackColor = Color.Blue Then
            If RBHoriz.Checked = True Then
                formBS.placeShip("setup", currentShipLength, "horizontal", xPos, yPos)
                formBS.playerpartsofshipssunk += currentShipLength
                LBbslength.Items.RemoveAt(0)
            Else
                formBS.placeShip("setup", currentShipLength, "vertical", xPos, yPos)
                formBS.playerpartsofshipssunk += currentShipLength
                LBbslength.Items.RemoveAt(0)
            End If
        End If
    End Sub
    Private Sub playertilemouse_enter(sender As System.Object, e As System.EventArgs)
        Clear()
        Dim position() As String = sender.Name.Split(",")
        Dim xPos As Integer = CInt(position(0))
        Dim yPos As Integer = CInt(position(1))
        'clear everything then place new temporary ship
        'not let it be placed on places where there is a ship already
        'check available first
        If Not LBbslength.Items.Count = Nothing Then
            currentShipLength = LBbslength.Items(0)
            If RBHoriz.Checked = True Then
                'If formBS.checkAvailable("setup", LBbslength.Items.IndexOf(0), "horizontal", xlength, ylength) = True Then
                If formBS.checkAvailable("setup", currentShipLength, "horizontal", xPos, yPos) = True Then
                    formBS.placeShip("setuptemp", currentShipLength, "horizontal", xPos, yPos)
                End If
            Else
                If formBS.checkAvailable("setup", currentShipLength, "vertical", xPos, yPos) = True Then
                    formBS.placeShip("setuptemp", currentShipLength, "vertical", xPos, yPos)
                End If
            End If
        Else
            Me.Close()
            'For x = 0 To xlength - 1
            ' For y = 0 To ylength - 1
            ' formBS.playertile(x, y).BackColor = playertilesetup(x, y).BackColor
            ' 'formBS.
            ' Next
            ' Next
        End If
    End Sub
    Private Sub Clear()
        For x = 0 To xlength - 1
            For y = 0 To ylength - 1
                If formBS.setupShip(x, y) = False Then
                    playertilesetup(x, y).BackColor = SystemColors.Control
                    playertilesetup(x, y).UseVisualStyleBackColor = True
                    playertilesetup(x, y).Tag = 0

                Else
                    'MsgBox(x & "," & y)
                End If
            Next
        Next
    End Sub

    Private Sub BTNRestart_Click(sender As System.Object, e As System.EventArgs)
        formMenu.restart()


    End Sub

    Private Sub BTNForceClose_Click(sender As System.Object, e As System.EventArgs) Handles BTNForceClose.Click
        formMenu.Show()
        formMenu.WindowState = FormWindowState.Normal
        forceclose = True
        Me.Close()
    End Sub
End Class