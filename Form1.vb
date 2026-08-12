Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1

    Private flowPanel As FlowLayoutPanel

    Private btnUp As Button
    Private btnDown As Button
    Private btnNext As Button
    Private btnClear As Button
    Private btnClose As Button

    Private items As New List(Of Label)
    Private currentIndex As Integer = -1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "UP DOWN Option Tool"

        Me.WindowState = FormWindowState.Maximized
        Me.MinimumSize = New Size(900, 600)

        Me.BackColor = Color.White

        CreateUI()

    End Sub


    '========================================================
    ' CREATE UI
    '========================================================

    Private Sub CreateUI()

        '----------------------------------------------------
        ' MAIN LAYOUT
        '----------------------------------------------------

        Dim mainLayout As New TableLayoutPanel()

        mainLayout.Dock = DockStyle.Fill

        mainLayout.ColumnCount = 3
        mainLayout.RowCount = 1

        ' Left = 15%
        ' Center = 70%
        ' Right = 15%

        mainLayout.ColumnStyles.Add(
            New ColumnStyle(SizeType.Percent, 15))

        mainLayout.ColumnStyles.Add(
            New ColumnStyle(SizeType.Percent, 70))

        mainLayout.ColumnStyles.Add(
            New ColumnStyle(SizeType.Percent, 15))


        Me.Controls.Add(mainLayout)


        '====================================================
        ' LEFT PANEL
        '====================================================

        Dim leftPanel As New Panel()

        leftPanel.Dock = DockStyle.Fill
        leftPanel.BackColor = Color.FromArgb(245, 245, 245)

        mainLayout.Controls.Add(leftPanel, 0, 0)


        '----------------------------------------------------
        ' UP BUTTON
        '----------------------------------------------------

        btnUp = New Button()

        btnUp.Text = "↑" & Environment.NewLine & "UP"

        btnUp.Font = New Font(
            "Segoe UI",
            18,
            FontStyle.Bold)

        btnUp.ForeColor = Color.White
        btnUp.BackColor = Color.FromArgb(40, 180, 80)

        btnUp.FlatStyle = FlatStyle.Flat
        btnUp.FlatAppearance.BorderSize = 0

        btnUp.Dock = DockStyle.Bottom

        btnUp.Height = 100

        AddHandler btnUp.Click,
            AddressOf Up_Click

        leftPanel.Controls.Add(btnUp)


        '----------------------------------------------------
        ' DOWN BUTTON
        '----------------------------------------------------

        btnDown = New Button()

        btnDown.Text = "↓" & Environment.NewLine & "DOWN"

        btnDown.Font = New Font(
            "Segoe UI",
            18,
            FontStyle.Bold)

        btnDown.ForeColor = Color.White
        btnDown.BackColor = Color.FromArgb(220, 60, 60)

        btnDown.FlatStyle = FlatStyle.Flat
        btnDown.FlatAppearance.BorderSize = 0

        btnDown.Dock = DockStyle.Bottom

        btnDown.Height = 100

        AddHandler btnDown.Click,
            AddressOf Down_Click

        leftPanel.Controls.Add(btnDown)


        '====================================================
        ' CENTER EMPTY AREA
        '====================================================

        flowPanel = New FlowLayoutPanel()

        flowPanel.Dock = DockStyle.Fill

        flowPanel.BackColor = Color.White

        ' IMPORTANT:
        ' Items will go LEFT -> RIGHT

        flowPanel.FlowDirection =
            FlowDirection.LeftToRight

        ' Do not move to next line

        flowPanel.WrapContents = False

        ' Horizontal scrolling

        flowPanel.AutoScroll = True

        flowPanel.Padding =
            New Padding(30)

        mainLayout.Controls.Add(
            flowPanel,
            1,
            0)


        '====================================================
        ' RIGHT PANEL
        '====================================================

        Dim rightPanel As New Panel()

        rightPanel.Dock = DockStyle.Fill

        rightPanel.BackColor =
            Color.FromArgb(245, 245, 245)

        mainLayout.Controls.Add(
            rightPanel,
            2,
            0)


        '====================================================
        ' NEXT OPTION
        '====================================================

        btnNext = New Button()

        btnNext.Text =
            "NEXT" & Environment.NewLine &
            "OPTION"

        btnNext.Font =
            New Font(
                "Segoe UI",
                14,
                FontStyle.Bold)

        btnNext.ForeColor = Color.White

        btnNext.BackColor =
            Color.FromArgb(50, 120, 220)

        btnNext.FlatStyle =
            FlatStyle.Flat

        btnNext.FlatAppearance.BorderSize = 0

        btnNext.Dock = DockStyle.Top

        btnNext.Height = 90

        AddHandler btnNext.Click,
            AddressOf Next_Click

        rightPanel.Controls.Add(btnNext)


        '====================================================
        ' CLEAR
        '====================================================

        btnClear = New Button()

        btnClear.Text = "CLEAR"

        btnClear.Font =
            New Font(
                "Segoe UI",
                14,
                FontStyle.Bold)

        btnClear.ForeColor = Color.White

        btnClear.BackColor =
            Color.FromArgb(240, 170, 40)

        btnClear.FlatStyle =
            FlatStyle.Flat

        btnClear.FlatAppearance.BorderSize = 0

        btnClear.Dock = DockStyle.Top

        btnClear.Height = 70

        AddHandler btnClear.Click,
            AddressOf Clear_Click

        rightPanel.Controls.Add(btnClear)


        '====================================================
        ' CLOSE
        '====================================================

        btnClose = New Button()

        btnClose.Text = "CLOSE"

        btnClose.Font =
            New Font(
                "Segoe UI",
                14,
                FontStyle.Bold)

        btnClose.ForeColor = Color.White

        btnClose.BackColor =
            Color.FromArgb(80, 80, 80)

        btnClose.FlatStyle =
            FlatStyle.Flat

        btnClose.FlatAppearance.BorderSize = 0

        btnClose.Dock = DockStyle.Bottom

        btnClose.Height = 70

        AddHandler btnClose.Click,
            AddressOf Close_Click

        rightPanel.Controls.Add(btnClose)

    End Sub


    '========================================================
    ' UP CLICK
    '========================================================

    Private Sub Up_Click(
        sender As Object,
        e As EventArgs)

        AddOption(
            "↑ UP",
            Color.FromArgb(40, 180, 80))

    End Sub


    '========================================================
    ' DOWN CLICK
    '========================================================

    Private Sub Down_Click(
        sender As Object,
        e As EventArgs)

        AddOption(
            "↓ DOWN",
            Color.FromArgb(220, 60, 60))

    End Sub


    '========================================================
    ' ADD OPTION
    '========================================================

    Private Sub AddOption(
        text As String,
        textColor As Color)

        ' Remove previous selection

        ClearSelection()


        ' Create label

        Dim lbl As New Label()


        lbl.Text = text


        lbl.Font =
            New Font(
                "Segoe UI",
                26,
                FontStyle.Bold)


        lbl.ForeColor = textColor

        lbl.BackColor = Color.White


        lbl.TextAlign =
            ContentAlignment.MiddleCenter


        ' Width of each item

        lbl.Width = 150

        lbl.Height = 90


        lbl.Margin =
            New Padding(10)


        lbl.BorderStyle =
            BorderStyle.FixedSingle


        ' Click the item to select it

        AddHandler lbl.Click,
            Sub()

                SelectItem(lbl)

            End Sub


        ' Add to list

        items.Add(lbl)


        ' Add to UI

        flowPanel.Controls.Add(lbl)


        ' New item becomes selected

        currentIndex =
            items.Count - 1


        SelectItem(lbl)


        ' Scroll to new item

        flowPanel.ScrollControlIntoView(lbl)

    End Sub


    '========================================================
    ' SELECT ITEM
    '========================================================

    Private Sub SelectItem(
        lbl As Label)

        ' Remove all previous selection

        ClearSelection()


        ' Highlight selected item

        lbl.BackColor =
            Color.FromArgb(
                220,
                235,
                255)


        lbl.BorderStyle =
            BorderStyle.Fixed3D


        ' Update index

        currentIndex =
            items.IndexOf(lbl)

    End Sub


    '========================================================
    ' CLEAR SELECTION
    '========================================================

    Private Sub ClearSelection()

        For Each lbl As Label In items

            lbl.BackColor =
                Color.White

            lbl.BorderStyle =
                BorderStyle.FixedSingle

        Next

    End Sub


    '========================================================
    ' NEXT OPTION
    '========================================================

    Private Sub Next_Click(
        sender As Object,
        e As EventArgs)

        ' Nothing to select

        If items.Count = 0 Then
            Return
        End If


        ' Move to next item

        If currentIndex <
           items.Count - 1 Then

            currentIndex += 1

        Else

            ' Already at last item

            Return

        End If


        ' Select next item

        SelectItem(
            items(currentIndex))


        ' Automatically scroll

        flowPanel.ScrollControlIntoView(
            items(currentIndex))

    End Sub


    '========================================================
    ' CLEAR ALL
    '========================================================

    Private Sub Clear_Click(
        sender As Object,
        e As EventArgs)

        ' Remove all controls

        flowPanel.Controls.Clear()


        ' Clear list

        items.Clear()


        ' Reset selection

        currentIndex = -1

    End Sub


    '========================================================
    ' CLOSE
    '========================================================

    Private Sub Close_Click(
        sender As Object,
        e As EventArgs)

        Me.Close()

    End Sub

End Class
