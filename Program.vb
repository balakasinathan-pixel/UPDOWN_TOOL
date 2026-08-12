Imports System
Imports System.Windows.Forms

Namespace UPDOWN_TOOL

    Public Module Program

        <STAThread>
        Sub Main()
            Application.SetHighDpiMode(HighDpiMode.SystemAware)
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New Form1())
        End Sub

    End Module

End Namespace
