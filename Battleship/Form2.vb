Public Class formBS
    Public xlength As Integer = formMenu.NUDXLength.Value
    Public ylength As Integer = formMenu.NUDYLength.Value
    Public playertile(xlength, ylength) As Button
    Public cputile(xlength, ylength) As Button
    Public playerShip(xlength, ylength) As Boolean
    Public setupShip(xlength, ylength) As Boolean
    Public cpuShip(xlength, ylength) As Boolean
    Public shipXpos(0) As Integer
    Public shipYpos(0) As Integer
    Public xsize = 30
    Public ysize = 30
    Dim ShipRotation As String = "horizontal"
    Dim Rand As New Random
    Dim numofships As Integer = 0
    Dim selectedplayercolor As Color = Color.Blue
    Dim selectedcpucolor As Color = Color.Orange
    Dim PlayerTurn As Boolean = True
    Public playerpartsofshipssunk As Integer = 0
    Dim cpupartsofshipssunk As Integer = 0
    Dim Done As Boolean = False
    Dim shipnum As Integer = 1
    Dim playershipnumber(xlength, ylength) As Integer
    Dim cpushipnumber(xlength, ylength) As Integer
    Dim Shiplengthrandomedorder(formMenu.ShipNumberCustom + 1) As Integer
    Dim timesplaced As Integer = 0
    Dim toldplayer As Boolean = False
    Dim counter As Integer = 1
    'Dim mode As String

    'NOTES:
    'cpu should understand if horizontal or vertical 2
    'first click botoom, then top then left or right since we know that its horizontal by then for sure
    'if computer wins make it win b4 i pick my last spot

    'cpu should know when 2 in a row and continue hitting on that line
    'start player setup menu (manual setting ships)
    'later change to real ships with pictures?
    Private Sub formBS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        formMenu.formbsopen = True
        'place something for number of cpu ships if n selected
        If formMenu.ShipNumberCustom = Nothing Then 'fix this
            formMenu.ShipNumberCustom = 4
        End If
        'cpu physical board
        For x = 0 To xlength - 1
            For y = 0 To ylength - 1
                cputile(x, y) = New Button
                cputile(x, y).Name = x & "," & y
                cputile(x, y).Size = New System.Drawing.Size(xsize, ysize)
                cputile(x, y).Location = New System.Drawing.Point(x * xsize + (xlength * xsize + 20), y * ysize + 50)
                cputile(x, y).Tag = 0
                'playertile(x, y).BackColor = Color.Gainsboro
                cputile(x, y).BringToFront()
                AddHandler cputile(x, y).Click, AddressOf cputile_click
                Me.Controls.Add(cputile(x, y))
            Next
        Next
        If formMenu.WillRandom = "n" Or formMenu.WillRandom = "no" Then
            'MsgBox("Player Set up mode is still in progress... ")
            'mode = "manual"
            runPlayerSetupMode()

            For x = 0 To xlength - 1
                For y = 0 To ylength - 1
                    playertile(x, y) = New Button
                    playertile(x, y).Name = x & "," & y
                    playertile(x, y).Size = New System.Drawing.Size(xsize, ysize)
                    playertile(x, y).Location = New System.Drawing.Point(x * xsize, y * ysize + 50)
                    playertile(x, y).Enabled = False
                    playertile(x, y).Tag = FormPSU.playertilesetup(x, y).Tag
                    playertile(x, y).BackColor = FormPSU.playertilesetup(x, y).BackColor
                    playertile(x, y).BringToFront()
                    AddHandler playertile(x, y).Click, AddressOf playertile_Click
                    Me.Controls.Add(playertile(x, y))
                Next
            Next
            For x = 0 To formMenu.ShipNumberCustom - 1
                randomplaceShip("cpu", FormPSU.Shiplengthcustomizedorder(x + 1))
            Next
        Else
            Randomize()
            For x = 0 To xlength - 1
                For y = 0 To ylength - 1
                    playertile(x, y) = New Button
                    playertile(x, y).Name = x & "," & y
                    playertile(x, y).Size = New System.Drawing.Size(xsize, ysize)
                    playertile(x, y).Location = New System.Drawing.Point(x * xsize, y * ysize + 50)
                    playertile(x, y).Enabled = False
                    playertile(x, y).Tag = 0
                    'playertile(x, y).BackColor = Color.Gainsboro
                    playertile(x, y).BringToFront()
                    AddHandler playertile(x, y).Click, AddressOf playertile_Click
                    Me.Controls.Add(playertile(x, y))
                Next
            Next
            If formMenu.WillRandom = "y" Or formMenu.WillRandom = "yes" Then
                'mode = "random"
                'PlaceRandom()
            End If
            If formMenu.customchanged = False Then
                randomplaceShip("cpu", 2)
                randomplaceShip("cpu", 3)
                randomplaceShip("cpu", 4)
                randomplaceShip("cpu", 5)
                PlaceRandom()
            Else
                Dim Random As New Random
                Dim Randomlength = Random.Next(2, formMenu.ShipLengthCustom)
                For x = 0 To formMenu.ShipNumberCustom - 1
                    Randomlength = Random.Next(2, formMenu.ShipLengthCustom)
                    Shiplengthrandomedorder(x + 1) = Randomlength
                    randomplaceShip("cpu", Randomlength)
                    randomplaceShip("player", Randomlength)
                Next
            End If
        End If


        'FormSize
        Me.Size = New System.Drawing.Size(xsize * xlength + 8 + (xlength * xsize) + 20, ysize * ylength + 84)
        Me.Location = New System.Drawing.Point(25, 25)
        Me.MaximumSize = New Size(xsize * xlength + 8 + (xlength * xsize) + 20, ysize * ylength + 84)
        Me.MinimumSize = New Size(xsize * xlength + 8 + (xlength * xsize) + 20, ysize * ylength + 84)

        If formMenu.Cheatmode = True Then
            For x = 0 To xlength - 1
                For y = 0 To ylength - 1
                    If cpuShip(x, y) = True Then
                        cputile(x, y).BackColor = Color.Purple
                    End If
                Next
            Next
        End If

        cputile(0, 0).Select()
        'MsgBox("Done")
    End Sub
    Private Sub formBS_close(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        'formMenu.Close()
        formMenu.formbsopen = False
        formMenu.BringToFront()
        formMenu.WindowState = FormWindowState.Normal
    End Sub
    Private Sub PlaceRandom()
        randomplaceShip("player", 2)
        randomplaceShip("player", 3)
        randomplaceShip("player", 4)
        randomplaceShip("player", 5)
    End Sub
    Private Sub randomplaceShip(board As String, shiplength As Integer)
        If timesplaced >= 15 Then
            FormPSU.Close()
            If toldplayer = False Then
                formMenu.problemtell()
                toldplayer = True
            End If
            'toldplayer = False
            Me.Close()
        End If
        If board = "player" Then
            If Rand.Next(1, 3) = 1 Then
                ShipRotation = "horizontal"
            Else
                ShipRotation = "vertical"
            End If
            ReDim shipXpos(numofships + 1)
            ReDim shipYpos(numofships + 1)
            shipXpos(shipXpos.Length - 1) = Rand.Next(0, xlength - (shiplength - 1))
            shipYpos(shipYpos.Length - 1) = Rand.Next(0, ylength - (shiplength - 1))
            If checkAvailable("player", shiplength, ShipRotation, shipXpos(shipXpos.Length - 1), shipYpos(shipYpos.Length - 1)) = False Then
                randomplaceShip("player", shiplength)
                timesplaced += 1
            Else
                placeShip("player", shiplength, ShipRotation, shipXpos(shipXpos.Length - 1), shipYpos(shipYpos.Length - 1))
                playerpartsofshipssunk += shiplength
            End If
        Else
            If Rand.Next(1, 3) = 1 Then
                ShipRotation = "horizontal"
            Else
                ShipRotation = "vertical"
            End If
            ReDim shipXpos(numofships + 1)
            ReDim shipYpos(numofships + 1)
            shipXpos(shipXpos.Length - 1) = Rand.Next(0, xlength - (shiplength - 1))
            shipYpos(shipYpos.Length - 1) = Rand.Next(0, ylength - (shiplength - 1))
            If checkAvailable("cpu", shiplength, ShipRotation, shipXpos(shipXpos.Length - 1), shipYpos(shipYpos.Length - 1)) = False Then
                randomplaceShip("cpu", shiplength)
                timesplaced += 1
            Else
                placeShip("cpu", shiplength, ShipRotation, shipXpos(shipXpos.Length - 1), shipYpos(shipYpos.Length - 1))
                cpupartsofshipssunk += shiplength
            End If
        End If
        'MsgBox(cpupartsofshipssunk & " " & playerpartsofshipssunk)
    End Sub
    Public Function checkAvailable(board As String, shiplength As Integer, rotation As String, x As Integer, y As Integer)
        Dim canplaceship As Integer = 0
        If board = "player" Then
            If rotation = "horizontal" Then
                'horizontal check
                If x + (shiplength - 1) >= 0 And x + (shiplength - 1) <= xlength - 1 Then
                    For z = 0 To shiplength - 1
                        If playerShip(x + z, y) = False Then
                            canplaceship += 1
                            If canplaceship = shiplength Then
                                canplaceship = 0
                                Return True
                            End If
                        Else
                            canplaceship = 0
                            Return False
                        End If
                    Next

                Else
                    Return False
                End If
            Else
                'vertical check
                If y + (shiplength - 1) >= 0 And y + (shiplength - 1) <= ylength - 1 Then
                    For z = 0 To shiplength - 1
                        If playerShip(x, y + z) = False Then
                            canplaceship += 1
                            If canplaceship = shiplength Then
                                canplaceship = 0
                                Return True
                            End If
                        Else
                            canplaceship = 0
                            Return False
                        End If
                    Next
                Else
                    canplaceship = 0
                    Return False
                End If
            End If
        ElseIf board = "cpu" Then
            'check CPU board
            If rotation = "horizontal" Then
                'horizontal check
                If x + (shiplength - 1) >= 0 And x + (shiplength - 1) <= xlength - 1 Then
                    For z = 0 To shiplength - 1
                        If cpuShip(x + z, y) = False Then
                            canplaceship += 1
                            If canplaceship = shiplength Then
                                canplaceship = 0
                                Return True
                            End If
                        Else
                            canplaceship = 0
                            Return False
                        End If
                    Next

                Else
                    Return False
                End If
            Else
                'vertical check
                If y + (shiplength - 1) >= 0 And y + (shiplength - 1) <= ylength - 1 Then
                    For z = 0 To shiplength - 1
                        If cpuShip(x, y + z) = False Then
                            canplaceship += 1
                            If canplaceship = shiplength Then
                                canplaceship = 0
                                Return True
                            End If
                        Else
                            canplaceship = 0
                            Return False
                        End If
                    Next
                Else
                    canplaceship = 0
                    Return False
                End If
            End If
        ElseIf board = "setup" Then
            'check setup board
            If rotation = "horizontal" Then
                'horizontal check
                If x + (shiplength - 1) >= 0 And x + (shiplength - 1) <= xlength - 1 Then
                    For z = 0 To shiplength - 1
                        If setupShip(x + z, y) = False Then
                            canplaceship += 1
                            If canplaceship = shiplength Then
                                canplaceship = 0
                                Return True
                            End If
                        Else
                            canplaceship = 0
                            Return False
                        End If
                    Next

                Else
                    Return False
                End If
            Else
                'vertical check
                If y + (shiplength - 1) >= 0 And y + (shiplength - 1) <= ylength - 1 Then
                    For z = 0 To shiplength - 1
                        If setupShip(x, y + z) = False Then
                            canplaceship += 1
                            If canplaceship = shiplength Then
                                canplaceship = 0
                                Return True
                            End If
                        Else
                            canplaceship = 0
                            Return False
                        End If
                    Next
                Else
                    canplaceship = 0
                    Return False
                End If
            End If
        ElseIf board = "playerselect" Then
            'check setup board
            If rotation = "horizontal" Then
                'horizontal check
                If x + (shiplength - 1) >= 0 And x + (shiplength - 1) <= xlength - 1 Then
                    For z = 0 To shiplength - 1
                        If playertile(x + z, y).Enabled = True Then
                            canplaceship += 1
                            If canplaceship = shiplength Then
                                canplaceship = 0
                                Return True
                            End If
                        Else
                            canplaceship = 0
                            Return False
                        End If
                    Next

                Else
                    Return False
                End If
            Else
                'vertical check
                If y + (shiplength - 1) >= 0 And y + (shiplength - 1) <= ylength - 1 Then
                    For z = 0 To shiplength - 1
                        If playertile(x, y + z).Enabled = True Then
                            canplaceship += 1
                            If canplaceship = shiplength Then
                                canplaceship = 0
                                Return True
                            End If
                        Else
                            canplaceship = 0
                            Return False
                        End If
                    Next
                Else
                    canplaceship = 0
                    Return False
                End If
            End If
        ElseIf board = "playerselect2" Then
            If Not playertile(x + 1, y).Enabled = Nothing Then
                If playertile(x + 1, y).Enabled = True Then
                    canplaceship += 1
                End If
            End If
            If Not playertile(x - 1, y).Enabled = Nothing Then
                If playertile(x - 1, y).Enabled = True Then
                    canplaceship += 1
                End If
            End If
            If Not playertile(x, y + 1).Enabled = Nothing Then
                If playertile(x, y + 1).Enabled = True Then
                    canplaceship += 1
                End If
            End If
            If Not playertile(x, y - 1).Enabled = Nothing Then
                If playertile(x, y - 1).Enabled = True Then
                    canplaceship += 1
                End If
            End If
            If canplaceship >= 1 Then
                canplaceship = 0
                Return True
            End If
        End If
    End Function
    Public Sub placeShip(board As String, shiplength As Integer, rotation As String, x As Integer, y As Integer)
        'tags: 
        '0 = no boat
        '1 = has part of boat

        'MsgBox(counter)
        'counter += 1
        If board = "player" Then
            If rotation = "horizontal" Then
                'horizontal check
                For z = 0 To shiplength - 1
                    playerShip(x + z, y) = True
                    playertile(x + z, y).Enabled = False
                    playertile(x + z, y).BackColor = selectedplayercolor
                    playertile(x + z, y).Tag = shiplength
                    playershipnumber(x + z, y) = shipnum
                Next
                shipnum += 1
            Else
                For z = 0 To shiplength - 1
                    playerShip(x, y + z) = True
                    playertile(x, y + z).Enabled = False
                    playertile(x, y + z).BackColor = selectedplayercolor
                    playertile(x, y + z).Tag = shiplength
                    playershipnumber(x, y + z) = shipnum
                Next
                shipnum += 1
            End If
        ElseIf board = "cpu" Then
            'cpu place
            If rotation = "horizontal" Then
                'horizontal check
                For z = 0 To shiplength - 1
                    cpuShip(x + z, y) = True
                    'cputile(x + z, y).Enabled = False
                    'cputile(x + z, y).BackColor = selectedcpucolor
                    cputile(x + z, y).Tag = shiplength
                    cpushipnumber(x + z, y) = shipnum
                Next
                shipnum += 1
            Else
                For z = 0 To shiplength - 1
                    cpuShip(x, y + z) = True
                    'cputile(x, y + z).Enabled = False
                    'cputile(x, y + z).BackColor = selectedcpucolor
                    cputile(x, y + z).Tag = shiplength
                    cpushipnumber(x, y + z) = shipnum
                Next
                shipnum += 1
            End If
        ElseIf board = "setup" Then
            'setup place
            If rotation = "horizontal" Then
                'horizontal check
                For z = 0 To shiplength - 1
                    setupShip(x + z, y) = True
                    FormPSU.playertilesetup(x + z, y).Enabled = False
                    FormPSU.playertilesetup(x + z, y).BackColor = selectedplayercolor
                    FormPSU.playertilesetup(x + z, y).Tag = shiplength
                    playershipnumber(x + z, y) = shipnum
                Next
                shipnum += 1
            Else
                For z = 0 To shiplength - 1
                    setupShip(x, y + z) = True
                    FormPSU.playertilesetup(x, y + z).Enabled = False
                    FormPSU.playertilesetup(x, y + z).BackColor = selectedplayercolor
                    FormPSU.playertilesetup(x, y + z).Tag = shiplength
                    playershipnumber(x, y + z) = shipnum
                Next
                shipnum += 1
            End If
        ElseIf board = "setuptemp" Then
            'setup place
            If rotation = "horizontal" Then
                'horizontal check
                For z = 0 To shiplength - 1
                    setupShip(x + z, y) = False
                    'FormPSU.playertilesetup(x + z, y).Enabled = False
                    FormPSU.playertilesetup(x + z, y).BackColor = selectedplayercolor
                    'FormPSU.playertilesetup(x + z, y).Tag = shiplength
                Next
            Else
                For z = 0 To shiplength - 1
                    setupShip(x, y + z) = False
                    'FormPSU.playertilesetup(x, y + z).Enabled = False
                    FormPSU.playertilesetup(x, y + z).BackColor = selectedplayercolor
                    'FormPSU.playertilesetup(x, y + z).Tag = shiplength
                Next
            End If
        End If
    End Sub
    Private Sub runPlayerSetupMode()
        'no mode set up yet
        'PlaceRandom()
        FormPSU.ShowDialog()
        'FormPSU.Show()
    End Sub
    Private Sub Disableall()
        For x = 0 To xlength - 1
            For y = 0 To ylength - 1
                If Not cputile(x, y).BackColor = selectedcpucolor And cputile(x, y).Enabled = True Then
                    cputile(x, y).BackColor = Color.Gray
                End If
                cputile(x, y).Enabled = False
            Next
        Next
    End Sub
    Private Sub showinvisible()
        For x = 0 To xlength - 1
            For y = 0 To ylength - 1
                If Not cputile(x, y).Tag = 0 And cputile(x, y).BackColor = Color.Gray Then
                    cputile(x, y).BackColor = Color.Purple
                End If
            Next
        Next
    End Sub
    Private Sub playertile_Click(sender As System.Object, e As System.EventArgs)
        Dim position() As String = sender.Name.Split(",")
        Dim xPos As Integer = CInt(position(0))
        Dim yPos As Integer = CInt(position(1))
        'MsgBox("playertile:" & xPos & "," & yPos)
        playertile(xPos, yPos).Enabled = False
        If Not playertile(xPos, yPos).Tag = 0 Then
            playertile(xPos, yPos).BackColor = Color.Black
        Else
            playertile(xPos, yPos).BackColor = Color.White
        End If
        PlayerTurn = True
        'If CheckWin() = "cw" Then
        ' MsgBox("You lost. D:")
        ' Disableall()
        ' showinvisible()
        ' End If
    End Sub
    Private Sub cputile_click(sender As System.Object, e As System.EventArgs)
        Dim position() As String = sender.Name.Split(",")
        Dim xPos As Integer = CInt(position(0))
        Dim yPos As Integer = CInt(position(1))
        'MsgBox("cputile:" & xPos & "," & yPos)
            PlayerTurn = False

            cputile(xPos, yPos).Enabled = False
            If Not cputile(xPos, yPos).Tag = 0 Then
            cputile(xPos, yPos).BackColor = selectedcpucolor
            If checkifsunkenship(cpushipnumber(xPos, yPos), xPos, yPos, "cpu") = True Then
                MsgBox("You sunk a ship!")
            End If
            Else
                cputile(xPos, yPos).BackColor = Color.White
            End If
            cpuSelect()
    End Sub
    Private Sub winnercheck()
        'place this at start of cpu turn?
        If CheckWin() = "cw" Then
            MsgBox("You lost. D:")
            Disableall()
            showinvisible()
            Exit Sub
        ElseIf CheckWin() = "pw" Then
            MsgBox("You win!")
            Disableall()
            showinvisible()
            Exit Sub
        End If
    End Sub
    Private Sub cpuSelect()
        winnercheck()

        changePlayerEnables()
        Dim selectedside = Rand.Next(1, 5)
        'check for red tile which doesnt have complete sunken ship
        For x = 0 To xlength - 1
            For y = 0 To ylength - 1
                If PlayerTurn = False Then
                    If playertile(x, y).BackColor = Color.Black Then
                        If playershipnumber(x, y) = 0 Then
                            MsgBox("This should not be happening!")
                        End If
                        If checkifsunkenship(playershipnumber(x, y), x, y, "player") = False Then
                            'check if its an entire ship sunken
                            'check if there is two in a row or more then place it on the side
                            'smart place
                            If y + 1 >= 0 And y + 1 <= ylength - 1 And PlayerTurn = False Then
                                If playertile(x, y + 1).BackColor = Color.Black And playershipnumber(x, y + 1) = playershipnumber(x, y) Then
                                    If y - 1 >= 0 And y - 1 <= ylength - 1 Then
                                        If Not playertile(x, y - 1).BackColor = Color.Black And Not playertile(x, y - 1).BackColor = Color.White Then
                                            playertile(x, y - 1).PerformClick()
                                        ElseIf playertile(x, y - 1).BackColor = Color.White Then
                                            Selectnext(x, y + 1, "down") 'the side selectnext right?
                                        End If
                                    End If
                                End If
                            End If
                            If x + 1 >= 0 And x + 1 <= xlength - 1 And PlayerTurn = False Then
                                If playertile(x + 1, y).BackColor = Color.Black And playershipnumber(x + 1, y) = playershipnumber(x, y) Then
                                    If x - 1 >= 0 And x - 1 <= xlength - 1 Then
                                        If Not playertile(x - 1, y).BackColor = Color.Black And Not playertile(x - 1, y).BackColor = Color.White Then
                                            playertile(x - 1, y).PerformClick()
                                        ElseIf playertile(x - 1, y).BackColor = Color.White Then
                                            Selectnext(x + 1, y, "right")
                                        End If
                                    End If
                                End If
                            End If
                            If y - 1 >= 0 And y - 1 <= ylength - 1 And PlayerTurn = False Then
                                If playertile(x, y - 1).BackColor = Color.Black And playershipnumber(x, y - 1) = playershipnumber(x, y) Then
                                    If y + 1 >= 0 And y + 1 <= ylength - 1 Then
                                        If Not playertile(x, y + 1).BackColor = Color.Black And Not playertile(x, y + 1).BackColor = Color.White Then
                                            playertile(x, y + 1).PerformClick()
                                        ElseIf playertile(x, y + 1).BackColor = Color.White Then
                                            Selectnext(x, y - 1, "up")
                                        End If
                                    End If
                                End If
                            End If
                            If x - 1 >= 0 And x - 1 <= xlength - 1 And PlayerTurn = False Then
                                If playertile(x - 1, y).BackColor = Color.Black And playershipnumber(x - 1, y) = playershipnumber(x, y) Then
                                    If x + 1 >= 0 And x + 1 <= xlength - 1 Then
                                        If Not playertile(x + 1, y).BackColor = Color.Black And Not playertile(x + 1, y).BackColor = Color.White Then
                                            playertile(x + 1, y).PerformClick()
                                        ElseIf playertile(x + 1, y).BackColor = Color.White Then
                                            Selectnext(x - 1, y, "left")
                                        End If
                                    End If
                                End If
                            End If
                            'side picker
                            If y + 1 >= 0 And PlayerTurn = False And y + 1 <= ylength - 1 Then
                                If Not playertile(x, y + 1).BackColor = Color.Black And Not playertile(x, y + 1).BackColor = Color.White Then
                                    playertile(x, y + 1).PerformClick()
                                End If
                            End If
                            If x + 1 >= 0 And PlayerTurn = False And x + 1 <= xlength - 1 Then
                                If Not playertile(x + 1, y).BackColor = Color.Black And Not playertile(x + 1, y).BackColor = Color.White Then
                                    playertile(x + 1, y).PerformClick()
                                End If
                            End If
                            If y - 1 >= 0 And PlayerTurn = False And y - 1 <= ylength - 1 Then
                                If Not playertile(x, y - 1).BackColor = Color.Black And Not playertile(x, y - 1).BackColor = Color.White Then
                                    playertile(x, y - 1).PerformClick()
                                End If
                            End If
                            If x - 1 >= 0 And PlayerTurn = False And x - 1 <= xlength - 1 Then
                                If Not playertile(x - 1, y).BackColor = Color.Black And Not playertile(x - 1, y).BackColor = Color.White Then
                                    playertile(x - 1, y).PerformClick()
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        Next
        'First check what the smallest ship left is then click only in places where that ship is possible

        'placce in the most abundant place of nnon selected tiles by dividing the board into sections and randoomly place in that section that is most abundant with tiles
        'when dividing the board into multiple sections, check if the board has and even or uneven width. if even, check if dividable by 4 if mod leaves you with more than 0 then you check for dividable by 2.
        'if odd then:

        'randomly place where it isnt already selected ONLY IF THE THING B$ DIDNT WORK/ all ships that are seen are done

        'checksmallestship()
        Dim whilecounter As Integer = 0
        Dim xpos As Integer = Rand.Next(0, xlength)
        Dim ypos As Integer = Rand.Next(0, ylength)
        While PlayerTurn = False
            If playertile(xpos, ypos).Enabled = True Then
                While Not checkAvailable("playerselect", 2, "vertical", xpos, ypos) = True Or Not checkAvailable("playerselect", 2, "horizontal", xpos, ypos) = True
                    xpos = Rand.Next(0, xlength)
                    ypos = Rand.Next(0, ylength)
                    whilecounter += 1
                    'If whilecounter >= 18 Then
                    ' checkwhereavailable()
                    ' Exit While
                    'End If
                End While
                playertile(xpos, ypos).PerformClick()
            Else
                xpos = Rand.Next(0, xlength)
                ypos = Rand.Next(0, ylength)
            End If
        End While
        PlayerTurn = True
        'playertile(xpos, ypos).PerformClick()

        winnercheck()
        changePlayerEnables()

    End Sub
    Private Sub checkwhereavailable()
        For x = 0 To xlength - 1
            For y = 0 To ylength - 1
                If checkAvailable("playerselect", 2, "vertical", x, y) = True Then
                    playertile(x, y).PerformClick()
                End If
            Next
        Next
    End Sub
    Private Function checksmallestship()
        'For x = 0 to 
        ' Return 2
    End Function
    Private Sub Selectnext(xpos As Integer, ypos As Integer, direction As String)
        If direction = "down" Then
            For z = 1 To ylength - 1
                If ypos + z >= 0 And ypos + z <= ylength - 1 Then
                    If Not playertile(xpos, ypos + z).BackColor = Color.White And Not playertile(xpos, ypos + z).BackColor = Color.Black And PlayerTurn = False Then
                        playertile(xpos, ypos + z).PerformClick()
                        Exit For
                    ElseIf playertile(xpos, ypos + z).BackColor = Color.White Then
                        Exit Sub
                    End If
                End If
            Next
        ElseIf direction = "right" Then
            For z = 1 To xlength - 1
                If xpos + z >= 0 And xpos + z <= xlength - 1 Then
                    If Not playertile(xpos + z, ypos).BackColor = Color.White And Not playertile(xpos + z, ypos).BackColor = Color.Black And PlayerTurn = False Then
                        playertile(xpos + z, ypos).PerformClick()
                        Exit For
                    ElseIf playertile(xpos + z, ypos).BackColor = Color.White Then
                        Exit Sub
                    End If
                End If
            Next
        ElseIf direction = "up" Then
            For z = 1 To ylength - 1
                If ypos - z >= 0 And ypos - z <= ylength - 1 Then
                    If Not playertile(xpos, ypos - z).BackColor = Color.White And Not playertile(xpos, ypos - z).BackColor = Color.Black And PlayerTurn = False Then
                        playertile(xpos, ypos - z).PerformClick()
                        Exit For
                    ElseIf playertile(xpos, ypos - z).BackColor = Color.White Then
                        Exit Sub
                    End If
                End If
            Next
        ElseIf direction = "left" Then
            For z = 1 To xlength - 1
                If xpos - z >= 0 And xpos - z <= xlength - 1 Then
                    If Not playertile(xpos - z, ypos).BackColor = Color.White And Not playertile(xpos - z, ypos).BackColor = Color.Black And PlayerTurn = False Then
                        playertile(xpos - z, ypos).PerformClick()
                        Exit For
                    ElseIf playertile(xpos - z, ypos).BackColor = Color.White Then
                        Exit Sub
                    End If
                End If
            Next
        End If
    End Sub
    Private Function checkifsunkenship(sn As Integer, xpos As Integer, ypos As Integer, board As String)
        Dim currentshiplength As Integer = 0
        'horizontal check with start on same point
        If board = "player" Then
            For z = -CInt(playertile(xpos, ypos).Tag) To CInt(playertile(xpos, ypos).Tag)
                If xpos + z >= 0 And xpos + z < xlength Then
                    If playershipnumber(xpos + z, ypos) = sn And playertile(xpos + z, ypos).BackColor = Color.Black Then
                        currentshiplength += 1
                    End If
                    If currentshiplength = playertile(xpos, ypos).Tag Then
                        Return True
                    End If
                End If
            Next
            currentshiplength = 0
            'vertical check with start on same point
            For z = -CInt(playertile(xpos, ypos).Tag) To CInt(playertile(xpos, ypos).Tag)
                If ypos + z >= 0 And ypos + z < ylength Then
                    If playershipnumber(xpos, ypos + z) = sn And playertile(xpos, ypos + z).BackColor = Color.Black Then
                        currentshiplength += 1
                    End If
                    If currentshiplength = playertile(xpos, ypos).Tag Then
                        Return True
                    End If
                End If
            Next
            Return False
        ElseIf board = "cpu" Then
            For z = -CInt(cputile(xpos, ypos).Tag) To CInt(cputile(xpos, ypos).Tag)
                If xpos + z >= 0 And xpos + z < xlength Then
                    If cpushipnumber(xpos + z, ypos) = sn And cputile(xpos + z, ypos).BackColor = selectedcpucolor Then
                        currentshiplength += 1
                    End If
                    If currentshiplength = cputile(xpos, ypos).Tag Then
                        Return True
                    End If
                End If
            Next
            currentshiplength = 0
            'vertical check with start on same point
            For z = -CInt(cputile(xpos, ypos).Tag) To CInt(cputile(xpos, ypos).Tag)
                If ypos + z >= 0 And ypos + z < ylength Then
                    If cpushipnumber(xpos, ypos + z) = sn And cputile(xpos, ypos + z).BackColor = selectedcpucolor Then
                        currentshiplength += 1
                    End If
                    If currentshiplength = cputile(xpos, ypos).Tag Then
                        Return True
                    End If
                End If
            Next
            Return False
        End If
        'return true or false
    End Function
    Private Function CheckWin()
        Dim playerpartssunk As Integer = 0
        Dim cpupartssunk As Integer = 0
        For x = 0 To xlength - 1
            For y = 0 To ylength - 1
                If playertile(x, y).BackColor = Color.Black Then
                    playerpartssunk += 1
                End If
                If cputile(x, y).BackColor = selectedcpucolor Then
                    cpupartssunk += 1
                End If
            Next
        Next
        If playerpartssunk = playerpartsofshipssunk Then
            Return "cw"
        End If
        If cpupartssunk = cpupartsofshipssunk Then
            Return "pw"
        End If
    End Function
    Private Sub changePlayerEnables()
        For x = 0 To xlength - 1
            For y = 0 To ylength - 1
                If Not playertile(x, y).BackColor = selectedcpucolor And Not playertile(x, y).BackColor = Color.White And Not playertile(x, y).BackColor = Color.Black Then
                    If playertile(x, y).Enabled = False Then
                        playertile(x, y).Enabled = True
                    Else
                        playertile(x, y).Enabled = False
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub BTNgotomenu_Click(sender As System.Object, e As System.EventArgs) Handles BTNgotomenu.Click
        'NOT WORKING
        resetAll()
        formMenu.WindowState = FormWindowState.Normal
        formMenu.Show()
        Me.Close()

    End Sub
    Private Sub Restart_Click_1(sender As System.Object, e As System.EventArgs) Handles BTNRestart.Click
        'formBS_Load(sender, e) '<==WHAT DOES THIS DO?

        'For x = 0 To xlength - 1
        ' For y = 0 To ylength - 1
        ' setupShip(x, y) = False
        ' FormPSU.playertilesetup(x, y).BackColor = SystemColors.Control
        ' FormPSU.playertilesetup(x, y).UseVisualStyleBackColor = True
        ' Next
        ' Next
        ' formMenu.reloadform() 'True)
        resetAll()
        formMenu.restart()
    End Sub
    Private Sub resetAll()
        For x = 0 To xlength - 1
            For y = 0 To ylength - 1
                playerShip(x, y) = False
                cpuShip(x, y) = False
                playertile(x, y).BackColor = SystemColors.Control
                playertile(x, y).UseVisualStyleBackColor = True
                playertile(x, y).Tag = 0
                playertile(x, y).Enabled = True
                cputile(x, y).BackColor = SystemColors.Control
                cputile(x, y).UseVisualStyleBackColor = True
                cputile(x, y).Tag = 0
                playertile(x, y).Enabled = True
                'FormPSU.playertilesetup(x, y).BackColor = SystemColors.Control
                'FormPSU.playertilesetup(x, y).UseVisualStyleBackColor = True
                'FormPSU.playertilesetup(x, y).Tag = 0
                'FormPSU.playertilesetup(x, y).Enabled = True
            Next
        Next
    End Sub
End Class