Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Namespace UPDOWN_TOOL

    Public Class Form1
        Inherits Form

        ' ==== Colors ====
        Private ReadOnly ColorUp As Color = Color.FromArgb(39, 174, 96)
        Private ReadOnly ColorDown As Color = Color.FromArgb(192, 57, 43)
        Private ReadOnly ColorNext As Color = Color.FromArgb(41, 128, 185)
        Private ReadOnly ColorClear As Color = Color.FromArgb(230, 126, 34)
        Private ReadOnly ColorClose As Color = Color.FromArgb(52, 58, 64)
        Private ReadOnly ColorSelected As Color = Color.FromArgb(173, 216, 230)
        Private ReadOnly ColorWhite As Color = Color.White

        ' ==== Controls ====
        Private btnUp As Button
        Private btnDown As Button
        Private btnNext As Button
        Private btnClear As Button
        Private btnClose As Button

        Private centerFlow As FlowLayoutPanel

        ' ==== State ====
        Private ReadOnly items As New List(Of Panel)()
        Private selectedIndex As Integer = -1

        Public Sub New()
            InitializeUI()
        End Sub

        Private Sub InitializeUI()
            ' ---- Form ----
            Me.Text = "UP DOWN OPTION TOOL"
            Me.WindowState = FormWindowState.Maximized
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.BackColor = ColorWhite
            Me.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            Me.MinimumSize = New Size(900, 600)

            ' ---- Main 3 column layout: 15% / 70% / 15% ----
            Dim mainLayout As New TableLayoutPanel()
            mainLayout.Dock = DockStyle.Fill
            mainLayout.BackColor = ColorWhite
            mainLayout.ColumnCount = 3
            mainLayout.RowCount = 1
            mainLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 15.0F))
            mainLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70.0F))
            mainLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 15.0F))
            mainLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))

            ' ---- LEFT SECTION ----
            Dim leftPanel As New Panel()
            leftPanel.Dock = DockStyle.Fill
            leftPanel.BackColor = ColorWhite
            leftPanel.Padding = New Padding(10)

            Dim leftButtonsPanel As New FlowLayoutPanel()
            leftButtonsPanel.Dock = DockStyle.Bottom
            leftButtonsPanel.FlowDirection = FlowDirection.TopDown
            leftButtonsPanel.WrapContents = False
            leftButtonsPanel.AutoSize = True
            leftButtonsPanel.BackColor = ColorWhite
            leftButtonsPanel.Padding = New Padding(5)

            btnUp = New Button()
            btnUp.Text = "↑" & Environment.NewLine & "UP"
            btnUp.Size = New Size(160, 130)
            btnUp.Margin = New Padding(5, 5, 5, 10)
            btnUp.BackColor = ColorUp
            btnUp.ForeColor = ColorWhite
            btnUp.FlatStyle = FlatStyle.Flat
            btnUp.FlatAppearance.BorderSize = 0
            btnUp.Font = New Font("Segoe UI", 22, FontStyle.Bold)
            btnUp.Cursor = Cursors.Hand

            btnDown = New Button()
            btnDown.Text = "↓" & Environment.NewLine & "DOWN"
            btnDown.Size = New Size(160, 130)
            btnDown.Margin = New Padding(5, 5, 5, 5)
            btnDown.BackColor = ColorDown
            btnDown.ForeColor = ColorWhite
            btnDown.FlatStyle = FlatStyle.Flat
            btnDown.FlatAppearance.BorderSize = 0
            btnDown.Font = New Font("Segoe UI", 22, FontStyle.Bold)
            btnDown.Cursor = Cursors.Hand

            leftButtonsPanel.Controls.Add(btnUp)
            leftButtonsPanel.Controls.Add(btnDown)
            leftPanel.Controls.Add(leftButtonsPanel)

            ' ---- CENTER SECTION ----
            Dim centerContainer As New Panel()
            centerContainer.Dock = DockStyle.Fill
            centerContainer.BackColor = ColorWhite
            centerContainer.Padding = New Padding(10)
            centerContainer.BorderStyle = BorderStyle.FixedSingle

            centerFlow = New FlowLayoutPanel()
            centerFlow.Dock = DockStyle.Fill
            centerFlow.FlowDirection = FlowDirection.LeftToRight
            centerFlow.WrapContents = False
            centerFlow.AutoScroll = True
            centerFlow.BackColor = ColorWhite
            centerFlow.Padding = New Padding(10)

            centerContainer.Controls.Add(centerFlow)

            ' ---- RIGHT SECTION ----
            Dim rightPanel As New Panel()
            rightPanel.Dock = DockStyle.Fill
            rightPanel.BackColor = ColorWhite
            rightPanel.Padding = New Padding(10)

            Dim rightButtonsPanel As New FlowLayoutPanel()
            rightButtonsPanel.Dock = DockStyle.Top
            rightButtonsPanel.FlowDirection = FlowDirection.TopDown
            rightButtonsPanel.WrapContents = False
            rightButtonsPanel.AutoSize = True
            rightButtonsPanel.BackColor = ColorWhite
            rightButtonsPanel.Padding = New Padding(5)

            btnNext = New Button()
            btnNext.Text = "NEXT OPTION"
            btnNext.Size = New Size(160, 90)
            btnNext.Margin = New Padding(5, 5, 5, 15)
            btnNext.BackColor = ColorNext
            btnNext.ForeColor = ColorWhite
            btnNext.FlatStyle = FlatStyle.Flat
            btnNext.FlatAppearance.BorderSize = 0
            btnNext.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            btnNext.Cursor = Cursors.Hand

            btnClear = New Button()
            btnClear.Text = "CLEAR"
            btnClear.Size = New Size(160, 70)
            btnClear.Margin = New Padding(5, 5, 5, 15)
            btnClear.BackColor = ColorClear
            btnClear.ForeColor = ColorWhite
            btnClear.FlatStyle = FlatStyle.Flat
            btnClear.FlatAppearance.BorderSize = 0
            btnClear.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            btnClear.Cursor = Cursors.Hand

            btnClose = New Button()
            btnClose.Text = "CLOSE"
            btnClose.Size = New Size(160, 70)
            btnClose.Margin = New Padding(5, 5, 5, 5)
            btnClose.BackColor = ColorClose
            btnClose.ForeColor = ColorWhite
            btnClose.FlatStyle = FlatStyle.Flat
            btnClose.FlatAppearance.BorderSize = 0
            btnClose.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            btnClose.Cursor = Cursors.Hand

            rightButtonsPanel.Controls.Add(btnNext)
            rightButtonsPanel.Controls.Add(btnClear)
            rightButtonsPanel.Controls.Add(btnClose)
            rightPanel.Controls.Add(rightButtonsPanel)

            ' ---- Assemble main layout ----
            mainLayout.Controls.Add(leftPanel, 0, 0)
            mainLayout.Controls.Add(centerContainer, 1, 0)
            mainLayout.Controls.Add(rightPanel, 2, 0)

            Me.Controls.Add(mainLayout)

            ' ---- Wire up events explicitly (no Handles clauses) ----
            AddHandler btnUp.Click, AddressOf BtnUp_Click
            AddHandler btnDown.Click, AddressOf BtnDown_Click
            AddHandler btnNext.Click, AddressOf BtnNext_Click
            AddHandler btnClear.Click, AddressOf BtnClear_Click
            AddHandler btnClose.Click, AddressOf BtnClose_Click
        End Sub

        ' ================== EVENT HANDLERS ==================

        Private Sub BtnUp_Click(sender As Object, e As EventArgs)
            AddItem("UP")
        End Sub

        Private Sub BtnDown_Click(sender As Object, e As EventArgs)
            AddItem("DOWN")
        End Sub

        Private Sub BtnNext_Click(sender As Object, e As EventArgs)
            If items.Count = 0 Then Return

            Dim nextIndex As Integer = selectedIndex + 1
            If nextIndex >= items.Count Then
                nextIndex = 0
            End If

            SelectItem(nextIndex)
            centerFlow.ScrollControlIntoView(items(nextIndex))
        End Sub

        Private Sub BtnClear_Click(sender As Object, e As EventArgs)
            centerFlow.Controls.Clear()
            items.Clear()
            selectedIndex = -1
        End Sub

        Private Sub BtnClose_Click(sender As Object, e As EventArgs)
            Me.Close()
        End Sub

        ' ================== ITEM MANAGEMENT ==================

        Private Sub AddItem(kind As String)
            Dim itemPanel As New Panel()
            itemPanel.Size = New Size(150, 100)
            itemPanel.Margin = New Padding(8)
            itemPanel.BackColor = ColorWhite
            itemPanel.BorderStyle = BorderStyle.FixedSingle
            itemPanel.Tag = kind
            itemPanel.Cursor = Cursors.Hand

            Dim lbl As New Label()
            lbl.Dock = DockStyle.Fill
            lbl.TextAlign = ContentAlignment.MiddleCenter
            lbl.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            lbl.BackColor = Color.Transparent
            lbl.Tag = kind
            lbl.Cursor = Cursors.Hand

            If kind = "UP" Then
                lbl.Text = "↑ UP"
                lbl.ForeColor = ColorUp
            Else
                lbl.Text = "↓ DOWN"
                lbl.ForeColor = ColorDown
            End If

            itemPanel.Controls.Add(lbl)

            AddHandler itemPanel.Click, AddressOf Item_Click
            AddHandler lbl.Click, AddressOf Item_Click

            centerFlow.Controls.Add(itemPanel)
            items.Add(itemPanel)

            SelectItem(items.Count - 1)
            centerFlow.ScrollControlIntoView(itemPanel)
        End Sub

        Private Sub Item_Click(sender As Object, e As EventArgs)
            Dim clicked As Control = TryCast(sender, Control)
            If clicked Is Nothing Then Return

            Dim targetPanel As Panel = TryCast(clicked, Panel)
            If targetPanel Is Nothing Then
                targetPanel = TryCast(clicked.Parent, Panel)
            End If
            If targetPanel Is Nothing Then Return

            Dim idx As Integer = items.IndexOf(targetPanel)
            If idx >= 0 Then
                SelectItem(idx)
            End If
        End Sub

        Private Sub SelectItem(index As Integer)
            If index < 0 OrElse index >= items.Count Then Return

            For i As Integer = 0 To items.Count - 1
                Dim p As Panel = items(i)
                If i = index Then
                    p.BackColor = ColorSelected
                    p.BorderStyle = BorderStyle.Fixed3D
                Else
                    p.BackColor = ColorWhite
                    p.BorderStyle = BorderStyle.FixedSingle
                End If
            Next

            selectedIndex = index
        End Sub

    End Class

End Namespace
