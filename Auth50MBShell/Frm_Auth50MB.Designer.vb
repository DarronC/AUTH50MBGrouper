﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Auth50MB
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txt_readFrom = New System.Windows.Forms.TextBox()
        Me.txt_writeTo = New System.Windows.Forms.TextBox()
        Me.Btn_Grouper = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.txt_year = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_StartNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_NameSche = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lbl_Warning = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(390, 53)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Browse..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(390, 124)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Browse..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txt_readFrom
        '
        Me.txt_readFrom.Location = New System.Drawing.Point(78, 53)
        Me.txt_readFrom.Name = "txt_readFrom"
        Me.txt_readFrom.Size = New System.Drawing.Size(283, 20)
        Me.txt_readFrom.TabIndex = 0
        '
        'txt_writeTo
        '
        Me.txt_writeTo.Location = New System.Drawing.Point(78, 127)
        Me.txt_writeTo.Name = "txt_writeTo"
        Me.txt_writeTo.Size = New System.Drawing.Size(283, 20)
        Me.txt_writeTo.TabIndex = 2
        '
        'Btn_Grouper
        '
        Me.Btn_Grouper.Location = New System.Drawing.Point(177, 241)
        Me.Btn_Grouper.Name = "Btn_Grouper"
        Me.Btn_Grouper.Size = New System.Drawing.Size(158, 40)
        Me.Btn_Grouper.TabIndex = 7
        Me.Btn_Grouper.Text = "Run Authorization Grouper"
        Me.Btn_Grouper.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(75, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(286, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select the folder containing the ungrouped Authorizations..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(43, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(318, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Select the folder to place the grouped and zipped Authorizations..."
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.SelectedPath = "X:"
        '
        'FolderBrowserDialog2
        '
        Me.FolderBrowserDialog2.SelectedPath = "X:"
        '
        'txt_year
        '
        Me.txt_year.Location = New System.Drawing.Point(165, 184)
        Me.txt_year.Name = "txt_year"
        Me.txt_year.Size = New System.Drawing.Size(68, 20)
        Me.txt_year.TabIndex = 5
        Me.txt_year.Text = "2024"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(153, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Select Year For File Naming"
        '
        'Txt_StartNo
        '
        Me.Txt_StartNo.Location = New System.Drawing.Point(401, 184)
        Me.Txt_StartNo.Name = "Txt_StartNo"
        Me.Txt_StartNo.Size = New System.Drawing.Size(46, 20)
        Me.Txt_StartNo.TabIndex = 6
        Me.Txt_StartNo.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(387, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Starting Number"
        '
        'txt_NameSche
        '
        Me.txt_NameSche.Location = New System.Drawing.Point(22, 184)
        Me.txt_NameSche.Name = "txt_NameSche"
        Me.txt_NameSche.Size = New System.Drawing.Size(115, 20)
        Me.txt_NameSche.TabIndex = 4
        Me.txt_NameSche.Text = "20AT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Naming Scheme"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(357, 241)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 34)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "battest"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'lbl_Warning
        '
        Me.lbl_Warning.AutoSize = True
        Me.lbl_Warning.ForeColor = System.Drawing.Color.Red
        Me.lbl_Warning.Location = New System.Drawing.Point(298, 154)
        Me.lbl_Warning.Name = "lbl_Warning"
        Me.lbl_Warning.Size = New System.Drawing.Size(159, 13)
        Me.lbl_Warning.TabIndex = 14
        Me.lbl_Warning.Text = "Spaces Not Allowed In File Path"
        Me.lbl_Warning.Visible = False
        '
        'Frm_Auth50MB
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(521, 302)
        Me.Controls.Add(Me.lbl_Warning)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_NameSche)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_StartNo)
        Me.Controls.Add(Me.txt_year)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Grouper)
        Me.Controls.Add(Me.txt_writeTo)
        Me.Controls.Add(Me.txt_readFrom)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Frm_Auth50MB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Authorization Grouper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents txt_readFrom As TextBox
    Friend WithEvents txt_writeTo As TextBox
    Friend WithEvents Btn_Grouper As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
    Friend WithEvents txt_year As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_StartNo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_NameSche As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents lbl_Warning As Label
End Class
