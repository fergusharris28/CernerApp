<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.AppTabs = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SentinelESMButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CerEnvLabel = New System.Windows.Forms.Label()
        Me.CerOlyProfComboBox = New System.Windows.Forms.ComboBox()
        Me.OlyLDAPComboBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FormTb1Label2 = New System.Windows.Forms.Label()
        Me.FormTb1Label3 = New System.Windows.Forms.Label()
        Me.FormTb1Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppTabs.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AppTabs
        '
        Me.AppTabs.Controls.Add(Me.TabPage1)
        Me.AppTabs.Controls.Add(Me.TabPage2)
        Me.AppTabs.Location = New System.Drawing.Point(12, 27)
        Me.AppTabs.Name = "AppTabs"
        Me.AppTabs.SelectedIndex = 0
        Me.AppTabs.Size = New System.Drawing.Size(894, 556)
        Me.AppTabs.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.CerEnvLabel)
        Me.TabPage1.Controls.Add(Me.CerOlyProfComboBox)
        Me.TabPage1.Controls.Add(Me.OlyLDAPComboBox)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.FormTb1Label2)
        Me.TabPage1.Controls.Add(Me.FormTb1Label3)
        Me.TabPage1.Controls.Add(Me.FormTb1Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(886, 530)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Olympus Tools"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.SentinelESMButton)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(372, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(511, 527)
        Me.Panel1.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(3, 101)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SentinelESMButton
        '
        Me.SentinelESMButton.Enabled = False
        Me.SentinelESMButton.Location = New System.Drawing.Point(3, 3)
        Me.SentinelESMButton.Name = "SentinelESMButton"
        Me.SentinelESMButton.Size = New System.Drawing.Size(107, 23)
        Me.SentinelESMButton.TabIndex = 4
        Me.SentinelESMButton.Text = "SentinelESM Agent"
        Me.SentinelESMButton.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CerEnvLabel
        '
        Me.CerEnvLabel.AutoSize = True
        Me.CerEnvLabel.Location = New System.Drawing.Point(118, 58)
        Me.CerEnvLabel.Name = "CerEnvLabel"
        Me.CerEnvLabel.Size = New System.Drawing.Size(89, 13)
        Me.CerEnvLabel.TabIndex = 7
        Me.CerEnvLabel.Text = """Not Connected"""
        '
        'CerOlyProfComboBox
        '
        Me.CerOlyProfComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CerOlyProfComboBox.FormattingEnabled = True
        Me.CerOlyProfComboBox.Location = New System.Drawing.Point(55, 105)
        Me.CerOlyProfComboBox.Name = "CerOlyProfComboBox"
        Me.CerOlyProfComboBox.Size = New System.Drawing.Size(248, 21)
        Me.CerOlyProfComboBox.TabIndex = 6
        '
        'OlyLDAPComboBox
        '
        Me.OlyLDAPComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OlyLDAPComboBox.FormattingEnabled = True
        Me.OlyLDAPComboBox.Location = New System.Drawing.Point(84, 9)
        Me.OlyLDAPComboBox.Name = "OlyLDAPComboBox"
        Me.OlyLDAPComboBox.Size = New System.Drawing.Size(121, 21)
        Me.OlyLDAPComboBox.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 448)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Label4"
        '
        'FormTb1Label2
        '
        Me.FormTb1Label2.AutoSize = True
        Me.FormTb1Label2.Location = New System.Drawing.Point(9, 58)
        Me.FormTb1Label2.Name = "FormTb1Label2"
        Me.FormTb1Label2.Size = New System.Drawing.Size(103, 13)
        Me.FormTb1Label2.TabIndex = 2
        Me.FormTb1Label2.Text = "Cerner Environment:"
        '
        'FormTb1Label3
        '
        Me.FormTb1Label3.AutoSize = True
        Me.FormTb1Label3.Location = New System.Drawing.Point(10, 108)
        Me.FormTb1Label3.Name = "FormTb1Label3"
        Me.FormTb1Label3.Size = New System.Drawing.Size(39, 13)
        Me.FormTb1Label3.TabIndex = 1
        Me.FormTb1Label3.Text = "Profile:"
        '
        'FormTb1Label1
        '
        Me.FormTb1Label1.AutoSize = True
        Me.FormTb1Label1.Location = New System.Drawing.Point(9, 12)
        Me.FormTb1Label1.Name = "FormTb1Label1"
        Me.FormTb1Label1.Size = New System.Drawing.Size(72, 13)
        Me.FormTb1Label1.TabIndex = 0
        Me.FormTb1Label1.Text = "LDAP Server:"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(886, 530)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(918, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadConfigToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LoadConfigToolStripMenuItem
        '
        Me.LoadConfigToolStripMenuItem.Name = "LoadConfigToolStripMenuItem"
        Me.LoadConfigToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.LoadConfigToolStripMenuItem.Text = "Load Config"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 595)
        Me.Controls.Add(Me.AppTabs)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(540, 350)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.AppTabs.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AppTabs As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents FormTb1Label2 As Label
    Friend WithEvents FormTb1Label3 As Label
    Friend WithEvents FormTb1Label1 As Label
    Friend WithEvents SentinelESMButton As Button
    Friend WithEvents CerOlyProfComboBox As ComboBox
    Friend WithEvents OlyLDAPComboBox As ComboBox
    Friend WithEvents CerEnvLabel As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
End Class
