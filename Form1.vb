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


    '========================================================
    ' FORM CONSTRUCTOR
    '========================================================

    Public Sub New()

        InitializeComponent()

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

        '====================================================
        ' MAIN LAYOUT
        '====================================================

        Dim mainLayout As New TableLayoutPanel()

        mainLayout.Dock = DockStyle.Fill

        mainLayout.ColumnCount = 3
        mainLayout.RowCount = 1

        ' LEFT = 15%
        ' CENTER = 70%
        ' RIGHT = 15%

        mainLayout.ColumnStyles.Add(
            New ColumnStyle(
                SizeType.Percent,
                15))

        mainLayout.ColumnStyles.Add(
            New ColumnStyle(
                SizeType.Percent,
                70))

        mainLayout.ColumnStyles.Add(
            New ColumnStyle(
                SizeType.Percent,
                15))


        Me.Controls.Add(mainLayout)


        '====================================================
        ' LEFT PANEL
        '====================================================

        Dim leftPanel As New Panel()

        leftPanel.Dock = DockStyle.Fill

        leftPanel.BackColor =
            Color.FromArgb(245, 245, 245)

        mainLayout.Controls.Add(
            leftPanel,
            0,
            0)


        '====================================================
        ' UP BUTTON
        '====================================================

        btnUp = New Button()

        btnUp.Text =
            "↑" &
            Environment.NewLine &
            "UP"

        btnUp.Font =
            New Font(
                "Segoe UI",
                18,
                FontStyle.Bold)

        btnUp.ForeColor = Color.White

        btnUp.BackColor =
            Color.FromArgb(40, 180, 80)

        btnUp.FlatStyle =
            FlatStyle.Flat

        btnUp.FlatAppearance.BorderSize = 0

        btnUp.Dock =
            DockStyle.Bottom

        btnUp.Height = 110

        btnUp.Cursor =
            Cursors.Hand

        AddHandler btnUp.Click,
            AddressOf Up_Click

        leftPanel.Controls.Add(btnUp)


        '====================================================
        ' DOWN BUTTON
        '====================================================

        btnDown = New Button()

        btnDown.Text =
            "↓" &
            Environment.NewLine &
            "DOWN"

        btnDown.Font =
            New Font(
                "Segoe UI",
                18,
                FontStyle.Bold)

        btnDown.ForeColor = Color.White

        btnDown.BackColor =
            Color.FromArgb(220, 60, 60)

        btnDown.FlatStyle =
            FlatStyle.Flat

        btnDown.FlatAppearance.BorderSize = 0

        btnDown.Dock =
            DockStyle.Bottom

        btnDown.Height = 110

        btnDown.Cursor =
            Cursors.Hand

        AddHandler btnDown.Click,
            AddressOf Down_Click

        leftPanel.Controls.Add(btnDown)


        '====================================================
        ' CENTER EMPTY AREA
        '====================================================

        flowPanel =
            New FlowLayoutPanel()

        flowPanel.Dock =
            DockStyle.Fill

        flowPanel.BackColor =
            Color.White

        ' IMPORTANT:
        ' Items go LEFT -> RIGHT

        flowPanel.FlowDirection =
            FlowDirection.LeftToRight

        ' Do NOT move items to next line

        flowPanel.WrapContents = False

        ' Enable scrolling

        flowPanel.AutoScroll = True

        flowPanel.Padding =
            New Padding(30)

        flowPanel.Margin =
            New Padding(0)

        mainLayout.Controls.Add(
            flowPanel,
            1,
            0)


        '====================================================
        ' RIGHT PANEL
        '====================================================

        Dim rightPanel As New Panel()

        rightPanel.Dock =
            DockStyle.Fill

        rightPanel.BackColor =
            Color.FromArgb(245, 245, 245)

        mainLayout.Controls.Add(
            rightPanel,
            2,
            0)


        '====================================================
        ' NEXT OPTION BUTTON
        '====================================================

        btnNext = New Button()

        btnNext.Text =
            "NEXT" &
            Environment.NewLine &
            "OPTION"

        btnNext.Font =
            New Font(
                "Segoe UI",
                14,
                FontStyle.Bold)

        btnNext.ForeColor =
            Color.White

        btnNext.BackColor =
            Color.FromArgb(50, 120, 220)

        btnNext.FlatStyle =
            FlatStyle.Flat

        btnNext.FlatAppearance.BorderSize = 0

        btnNext.Dock =
            DockStyle.Top

        btnNext.Height = 90

        btnNext.Cursor =
            Cursors.Hand

        AddHandler btnNext.Click,
            AddressOf Next_Click

        rightPanel.Controls.Add(btnNext)


        '====================================================
        ' CLEAR BUTTON
        '====================================================

        btnClear = New Button()

        btnClear.Text = "CLEAR"

        btnClear.Font =
            New Font(
                "Segoe UI",
                14,
                FontStyle.Bold)

        btnClear.ForeColor =
            Color.White

        btnClear.BackColor =
            Color.FromArgb(240, 170, 40)

        btnClear.FlatStyle =
            FlatStyle.Flat

        btnClear.FlatAppearance.BorderSize = 0

        btnClear.Dock =
            DockStyle.Top

        btnClear.Height = 70

        btnClear.Cursor =
            Cursors.Hand

        AddHandler btnClear.Click,
            AddressOf Clear_Click

        rightPanel.Controls.Add(btnClear)


        '====================================================
        ' CLOSE BUTTON
        '====================================================

        btnClose = New Button()

        btnClose.Text = "CLOSE"

        btnClose.Font =
            New Font(
                "Segoe UI",
                14,
                FontStyle.Bold)

        btnClose.ForeColor =
            Color.White

        btnClose.BackColor =
            Color.FromArgb(80, 80, 80)

        btnClose.FlatStyle =
            FlatStyle.Flat

        btnClose.FlatAppearance.BorderSize = 0

        btnClose.Dock =
            DockStyle.Bottom

        btnClose.Height = 70

        btnClose.Cursor =
            Cursors.Hand

        AddHandler btnClose.Click,
            AddressOf Close_Click

        rightPanel.Controls.Add(btnClose)

    End Sub


    '========================================================
    ' UP BUTTON CLICK
    '========================================================

    Private Sub Up_Click(
        sender As Object,
        e As EventArgs)

        AddOption(
            "↑ UP",
            Color.FromArgb(40, 180, 80))

    End Sub


    '========================================================
    ' DOWN BUTTON CLICK
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


        '====================================================
        ' CREATE NEW LABEL
        '====================================================

        Dim lbl As New Label()

        lbl.Text = text

        lbl.Font =
            New Font(
                "Segoe UI",
                26,
                FontStyle.Bold)

        lbl.ForeColor =
            textColor

        lbl.BackColor =
            Color.White

        lbl.TextAlign =
            ContentAlignment.MiddleCenter

        ' Each item size

        lbl.Width = 150

        lbl.Height = 90

        lbl.Margin =
            New Padding(10)

        lbl.BorderStyle =
            BorderStyle.FixedSingle

        lbl.Cursor =
            Cursors.Hand


        '====================================================
        ' CLICK ITEM TO SELECT
        '====================================================

        AddHandler lbl.Click,
            Sub()

                SelectItem(lbl)

            End Sub


        '====================================================
        ' ADD TO LIST
        '====================================================

        items.Add(lbl)


        '====================================================
        ' ADD TO CENTER AREA
        '====================================================

        flowPanel.Controls.Add(lbl)


        '====================================================
        ' NEW ITEM = SELECTED
        '====================================================

        currentIndex =
            items.Count - 1

        SelectItem(lbl)


        '====================================================
        ' SCROLL TO NEW ITEM
        '====================================================

        flowPanel.ScrollControlIntoView(lbl)

    End Sub


    '========================================================
    ' SELECT ITEM
    '========================================================

    Private Sub SelectItem(
        lbl As Label)

        ' Remove old selection

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

        ' No items

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


        ' Scroll to selected item

        flowPanel.ScrollControlIntoView(
            items(currentIndex))

    End Sub


    '========================================================
    ' CLEAR ALL
    '========================================================

    Private Sub Clear_Click(
        sender As Object,
        e As EventArgs)

        ' Remove controls

        flowPanel.Controls.Clear()


        ' Clear item list

        items.Clear()


        ' Reset selected index

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
