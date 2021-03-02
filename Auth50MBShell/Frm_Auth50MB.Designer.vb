<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(390, 53)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Browse..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(390, 124)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Browse..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txt_readFrom
        '
        Me.txt_readFrom.Enabled = False
        Me.txt_readFrom.Location = New System.Drawing.Point(78, 53)
        Me.txt_readFrom.Name = "txt_readFrom"
        Me.txt_readFrom.Size = New System.Drawing.Size(283, 20)
        Me.txt_readFrom.TabIndex = 2
        '
        'txt_writeTo
        '
        Me.txt_writeTo.Enabled = False
        Me.txt_writeTo.Location = New System.Drawing.Point(78, 127)
        Me.txt_writeTo.Name = "txt_writeTo"
        Me.txt_writeTo.Size = New System.Drawing.Size(283, 20)
        Me.txt_writeTo.TabIndex = 3
        '
        'Btn_Grouper
        '
        Me.Btn_Grouper.Location = New System.Drawing.Point(180, 176)
        Me.Btn_Grouper.Name = "Btn_Grouper"
        Me.Btn_Grouper.Size = New System.Drawing.Size(158, 40)
        Me.Btn_Grouper.TabIndex = 4
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
        'Frm_Auth50MB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(512, 243)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Grouper)
        Me.Controls.Add(Me.txt_writeTo)
        Me.Controls.Add(Me.txt_readFrom)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Frm_Auth50MB"
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
End Class
