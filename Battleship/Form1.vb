Public Class formMenu

    'ADVANCED
    'Change player colors
    'Get two players
    'Make it so cpu htis less abundant areas when all ships are sunk

    'REMAINING THINGS To FIX
    'not opening menu when force closed etc
    'didnt open form when on max it out after setup mode
    'make it possible to select placed ship?
    'change y/n selection to another form with two buttons?
    'make it so that menu appears on force close

    'reseting for second game on the setup mode
    'not choosing right tile for computer
    'intructions?
    'when 9 boats with length 3 for max the cpu couldnt find last spot when 2 length 2 ships were side by side
    'checkforsunkenship not fully proper with radius that can hit other boats with tag/length that is the same (change tags so that it counts amount of ships of same length 1,2 2,2 3,2 4,2 etc)
    'tell player when he sunk ship and what length (FIXED BUIT NOT WORKING, USE BREAKPOINT)
    'not picking right bs hti when in a row. keeps going all around
    'customize both 8 and 8 and it crashed

    'fix cpu choosing
    'fix little things like telling player when sunk
    'shipnum not being created in place ship for player so when it checks the if sunked ship it adds even if its other ship.

    '--------------------
    'checks on x spots
    'ybeing other ship
    '0being my ship

    'xx
    'yyyy
    '000
    'xx
    '--------------------

    'tags messsing up things in the form manual make

    'cheat mode didnt work after clicking max it out

    'make it more smarter by clicing abundance

    'CHECK FOR EXCEEDING 50 TRIES OF RANDOM PLACE IN BOTH BOTS AND PLAYER ISAND IF IT DOES THEN RESTART ALL OF RANDOM PLACE




    'place where smallest ship left can fit
    '(use checkavailable but add another varaiable required witch states whether one or the other)
    'random place crash on inifinite loop make it so there is a check if infinite loop coutner then if it reaches 50 in randomplaceship() then tell user that it is restarting due to not being able to fit all ships correctly or just restart it by makingit reset board and click play again 

    Public ylength As Integer
    Public xlength As Integer
    Public WillRandom As String
    Public ShipNumberCustom As String
    Public ShipLengthCustom As String
    Public customchanged As Boolean = False
    Public Cheatmode As Boolean = False
    Public formbsopen As Boolean = False
    Public formpsuopen As Boolean = False

    Private Sub btlShp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MsgBox("Hello, Welcome to battleship! There is a cheat mode just soz you know. Find it if you can.")
        BTNLePlay.Select()
        'amount of boxes (2 dimensional size)
        xlength = NUDXLength.Value
        ylength = NUDYLength.Value
    End Sub

    Private Sub BTNLePlay_Click(sender As System.Object, e As System.EventArgs) Handles BTNLePlay.Click
        If formbsopen = True Then
            formBS.Close()
        End If
        If formpsuopen = True Then
            FormPSU.Close()
        End If

        'WillRandom = LCase(InputBox("Welcome to Battleship!" & vbNewLine & "You will be starting with 3 ships. One with length 2, length 3, length 4, and the last with length 5 (Unless customized otherwise). Would you like us to randomly place them? (yes/no)/(y/n)" & vbNewLine & vbNewLine & "Note: If you select No, you will be placing them yourself."))
        'While Not WillRandom = "y" And Not WillRandom = "n" And Not WillRandom = "yes" And Not WillRandom = "no" And Not WillRandom = ""
        ' 'you can shorten to just say please input y/n in input box
        ' MsgBox("Please input y/n")
        ' WillRandom = LCase(InputBox("Welcome to Battleship!" & vbNewLine & "You will be starting with 4 ships. One with length 2, length 3, length 4, and the last with length 5 (Unless customized otherwise). Would you like us to randomly place them? (yes/no)/(y/n)" & vbNewLine & vbNewLine & "Note: If you select No, you will be placing them yourself."))
        ' End While
        ' If WillRandom = "" Then
        ' Me.WindowState = FormWindowState.Normal
        ' Else
        ' formBS.Show()
        ' Me.WindowState = FormWindowState.Minimized
        ' End If'
        If customchanged = False Then
            ShipNumberCustom = 4
        End If
        SelectSetup.Show()
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub BTNMaxNum_Click(sender As System.Object, e As System.EventArgs) Handles BTNMaxNum.Click
        NUDXLength.Value = 15
        NUDYLength.Value = 15
    End Sub

    Public Sub reloadform() 'israndom As Boolean)
        formBS.Close()
        formBS.Show()
    End Sub

    Private Sub BTNCustomize_Click(sender As System.Object, e As System.EventArgs) Handles BTNCustomize.Click
        customchanged = True
        'MsgBox("Customize will only work if you set up the ship yourself. (If you load in random mode these customizations will be irrelevant.)")
        ShipNumberCustom = InputBox("How many ships would you like to have? (1 minimum, 10 maximum) Note: This will be the random range.", "", "null")
        While True
            If IsNumeric(ShipNumberCustom) Then
                If ShipNumberCustom >= 1 And ShipNumberCustom <= 10 Then
                    Exit While
                Else
                    MsgBox("Please make sure you entered a number within the bounds indicated.")
                    ShipNumberCustom = InputBox("How many ships would you like to have? (1 minimum, 10 maximum) Note: This will be the random range.", "", "null")
                End If
            Else
                If ShipNumberCustom = "" Then
                    customchanged = False
                    Exit Sub
                End If
                ' Me.WindowState = FormWindowState.Normal
                'End If
                MsgBox("Please input real number.")
                ShipNumberCustom = InputBox("How many ships would you like to have? (1 minimum, 10 maximum) Note: This will be the random range.", "", "null") 'make it click button instead?
            End If
        End While
        ShipLengthCustom = InputBox("What maximum length would you like to have? (2 minimum, 8 maximum) Note: This will be the random range.", " ", "null")
        While True
            If IsNumeric(ShipLengthCustom) Then
                If ShipLengthCustom >= 3 And ShipLengthCustom <= 8 Then
                    Exit While
                Else
                    MsgBox("Please make sure you entered a number within the bounds indicated.")
                    ShipLengthCustom = InputBox("What maximum length would you like to have? (3 minimum, 8 maximum) Note: This will be the random range.", " ", "null")
                End If
            Else
                If ShipLengthCustom = "" Then
                    customchanged = False
                    Exit Sub
                End If
                ' Me.WindowState = FormWindowState.Normal
                'End If
                MsgBox("Please input real number.")
                ShipNumberCustom = InputBox("What maximum length would you like to have? (3 minimum, 8 maximum) Note: This will be the random range.", " ", "null")
            End If
        End While
        MsgBox("Finished customizations.")
    End Sub

    Public Sub restart()
        Me.Show()
        formBS.Close()
        FormPSU.Close()
        BTNLePlay.PerformClick()
    End Sub

    Private Sub PNLCheat_Click(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PNLCheat.Click
        MsgBox("Cheat mode activated.")
        If Cheatmode = False Then
            Cheatmode = True
        Else
            Cheatmode = False
        End If
    End Sub
    Public Sub problemtell()
        MsgBox("A problem occured when randomly placing ships. Consider changing your customizations or try again.")
    End Sub
End Class
