Imports System.IO
Public Class Frm_Auth50MB
    Dim psi As ProcessStartInfo = New ProcessStartInfo("cmd.exe")

    Dim pro As Process = New Process()
    Dim pro2 As Process = New Process()
    Dim argu As String
    Private Sub Btn_Grouper_Click(sender As Object, e As EventArgs) Handles Btn_Grouper.Click
        Dim psibat As ProcessStartInfo = New ProcessStartInfo(txt_writeTo.Text + "\Grouper.bat")
        If String.IsNullOrEmpty(txt_readFrom.Text) Or String.IsNullOrEmpty(txt_writeTo.Text) Then
            MsgBox("Select Folders To Launch Application.")
        Else
            argu = String.Format("/c dotnet Auth50MB-Csharp.dll {0}{1}{0} {0}{2}{0}", ControlChars.Quote, txt_readFrom.Text, txt_writeTo.Text)
            psi.Arguments = argu
            pro = Process.Start(psi)
            pro.WaitForExit()
            psibat.UseShellExecute = False
            psibat.CreateNoWindow = False
            psibat.WorkingDirectory = txt_writeTo.Text
            psibat.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
            Try
                pro2 = Process.Start(psibat)
                pro2.WaitForExit()
            Catch ex As Exception
                Console.WriteLine("Something went wrong with the Batch File: {0}", ex.ToString())
            End Try
            My.Computer.FileSystem.DeleteFile(txt_writeTo.Text + "\Grouper.bat")
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        txt_readFrom.Text = FolderBrowserDialog1.SelectedPath

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog2.ShowDialog()
        txt_writeTo.Text = FolderBrowserDialog2.SelectedPath
    End Sub
End Class
