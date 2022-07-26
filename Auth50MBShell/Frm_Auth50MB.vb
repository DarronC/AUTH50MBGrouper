Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Public Class Frm_Auth50MB

    Dim pro As Process = New Process()
    Dim pro2 As Process = New Process()
    Dim objSHell = CreateObject("Wscript.shell")
    Dim argu As String
    Dim currdir As String
    Private Sub Btn_Grouper_Click(sender As Object, e As EventArgs) Handles Btn_Grouper.Click
        If InStr(txt_writeTo.Text, " ") > 0 Then
            lbl_Warning.Visible = True
            'Exit Sub
        Else
            lbl_Warning.Visible = False
        End If
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
                If System.Environment.OSVersion.Version.Major = 6 And System.Environment.OSVersion.Version.Minor = 2 Then
                    ZipperBat() 'Windows 10
                Else
                    SevenZipperBat() 'Windows 7 - Needs 7zip
                End If
            Catch ex As Exception
                MsgBox("Something went wrong with the Batch File: " & ex.ToString(), vbCritical)
            End Try
            Try
            Catch ex As Exception
                MsgBox("is .NET Core installed on system?")
            End Try
        End If

    End Sub

    Private Sub ZipperBat()
        currdir = My.Computer.FileSystem.CurrentDirectory
        My.Computer.FileSystem.CopyFile(currdir + "\Grouper.ps1", txt_writeTo.Text + "\Grouper.ps1", True)
        argu = txt_writeTo.Text & "\Grouper.ps1"
        Try
            Dim sps1 As String = "C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"
            objSHell.run("powershell.exe -noprofile -executionpolicy Bypass " + sps1 + " '" + argu + "'", 1, True)
            My.Computer.FileSystem.DeleteFile(txt_writeTo.Text + "\Grouper.ps1")
        Catch ex As Exception
            Console.WriteLine("Something went wrong with the Batch File: {0}", ex.ToString())
        End Try
    End Sub
    Private Sub SevenZipperBat()
        Dim psibat As ProcessStartInfo = New ProcessStartInfo(txt_writeTo.Text + "\grouper.bat")
        currdir = My.Computer.FileSystem.CurrentDirectory
        My.Computer.FileSystem.CopyFile(currdir + "\Grouper.bat", txt_writeTo.Text + "\Grouper.bat", True)
        psibat.UseShellExecute = False
        psibat.CreateNoWindow = False
        psibat.WorkingDirectory = txt_writeTo.Text
        psibat.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
        Try
            pro2 = Process.Start(psibat)
            pro2.WaitForExit()
            My.Computer.FileSystem.DeleteFile(txt_writeTo.Text + "\Grouper.bat")
        Catch ex As Exception
            Console.WriteLine("Something went wrong with the Batch File: {0}", ex.ToString())
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        txt_readFrom.Text = FolderBrowserDialog1.SelectedPath

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog2.ShowDialog()
        txt_writeTo.Text = FolderBrowserDialog2.SelectedPath
    End Sub

    Private Sub Frm_Auth50MB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_writeTo.Text = "X:\GroupedAuths"
        'txt_readFrom.Text = "\\KMLFS01\HomeDir$\DCharles\Desktop\TEST CLEAN"

    End Sub
    Private Sub battest()
        Try
            SevenZipperBat()
        Catch ex As Exception
            MsgBox("Something went wrong with the Batch File: " & ex.ToString())
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        battest()
    End Sub
End Class
