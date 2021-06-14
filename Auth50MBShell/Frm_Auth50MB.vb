Imports System.IO
Imports System.Text.RegularExpressions
Public Class Frm_Auth50MB
    Dim pro As Process = New Process()
    Dim pro2 As Process = New Process()
    Dim argu As String
    Dim currdir As String
    Private Sub Btn_Grouper_Click(sender As Object, e As EventArgs) Handles Btn_Grouper.Click
        Try
            Integer.Parse(Txt_StartNo.Text)
        Catch ex As Exception
            MsgBox("Enter a number", MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
        If Regex.IsMatch(txt_NameSche.Text, pattern:="[*?:<>|/\\]") Then
            MsgBox("Invalid Character", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txt_readFrom.Text) Or String.IsNullOrEmpty(txt_writeTo.Text) Then
            MsgBox("Select Folders To Launch Application.")
        Else
            argu = String.Format("dotnet Auth50MB-Csharp.dll '{1}' '{2}' '{3}' '{4}' '{5}'", ControlChars.Quote, txt_readFrom.Text, txt_writeTo.Text, txt_year.Text, txt_NameSche.Text, Txt_StartNo.Text)
            Dim psi As ProcessStartInfo = New ProcessStartInfo("powershell.exe", "-WindowStyle Normal -command " + argu)
            pro = Process.Start(psi)
            pro.WaitForExit()
            pro.Close()
            Try
                currdir = My.Computer.FileSystem.CurrentDirectory
                My.Computer.FileSystem.CopyFile(currdir + "\Grouper.ps1", txt_writeTo.Text + "\Grouper.ps1", True)
                argu = String.Format(".\Grouper")
                Dim psibat As ProcessStartInfo = New ProcessStartInfo("powershell.exe", "-command " + argu)
                psibat.UseShellExecute = False
                psibat.CreateNoWindow = False
                psibat.WorkingDirectory = txt_writeTo.Text
                pro2 = Process.Start(psibat)
                pro2.WaitForExit()
            Catch ex As Exception
                Console.WriteLine("Something went wrong with the Batch File: {0}", ex.ToString())
            End Try
            Try
                My.Computer.FileSystem.DeleteFile(txt_writeTo.Text + "\Grouper.ps1")
            Catch ex As Exception
                Console.WriteLine("is .NET Core installed on system?")
            End Try
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
