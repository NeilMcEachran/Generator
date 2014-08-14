<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCodeGenerator
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents txtUserID As System.Windows.Forms.TextBox
	Public WithEvents txtPassword As System.Windows.Forms.TextBox
	Public WithEvents txtSprocsLocation As System.Windows.Forms.TextBox
	Public WithEvents txtSprocs As System.Windows.Forms.TextBox
	Public WithEvents txtcClassScript As System.Windows.Forms.TextBox
	Public WithEvents Generate As System.Windows.Forms.Button
	Public WithEvents txtCOutputLocation As System.Windows.Forms.TextBox
	Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtSprocsLocation = New System.Windows.Forms.TextBox()
        Me.txtSprocs = New System.Windows.Forms.TextBox()
        Me.txtcClassScript = New System.Windows.Forms.TextBox()
        Me.Generate = New System.Windows.Forms.Button()
        Me.txtCOutputLocation = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTableOfTables = New System.Windows.Forms.TextBox()
        Me.txtcClassPHPScript = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DatabaseNames = New System.Windows.Forms.ComboBox()
        Me.TableNames = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtUserID
        '
        Me.txtUserID.AcceptsReturn = True
        Me.txtUserID.BackColor = System.Drawing.SystemColors.Window
        Me.txtUserID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUserID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUserID.Location = New System.Drawing.Point(184, 93)
        Me.txtUserID.MaxLength = 0
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUserID.Size = New System.Drawing.Size(354, 20)
        Me.txtUserID.TabIndex = 2
        Me.txtUserID.Text = "WorkmanUser"
        '
        'txtPassword
        '
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassword.Location = New System.Drawing.Point(184, 119)
        Me.txtPassword.MaxLength = 0
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPassword.Size = New System.Drawing.Size(354, 20)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Text = "WorkmanUser1"
        '
        'txtSprocsLocation
        '
        Me.txtSprocsLocation.AcceptsReturn = True
        Me.txtSprocsLocation.BackColor = System.Drawing.SystemColors.Window
        Me.txtSprocsLocation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSprocsLocation.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSprocsLocation.Location = New System.Drawing.Point(184, 315)
        Me.txtSprocsLocation.MaxLength = 0
        Me.txtSprocsLocation.Name = "txtSprocsLocation"
        Me.txtSprocsLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSprocsLocation.Size = New System.Drawing.Size(354, 20)
        Me.txtSprocsLocation.TabIndex = 9
        '
        'txtSprocs
        '
        Me.txtSprocs.AcceptsReturn = True
        Me.txtSprocs.BackColor = System.Drawing.SystemColors.Window
        Me.txtSprocs.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSprocs.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSprocs.Location = New System.Drawing.Point(184, 289)
        Me.txtSprocs.MaxLength = 0
        Me.txtSprocs.Name = "txtSprocs"
        Me.txtSprocs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSprocs.Size = New System.Drawing.Size(354, 20)
        Me.txtSprocs.TabIndex = 8
        '
        'txtcClassScript
        '
        Me.txtcClassScript.AcceptsReturn = True
        Me.txtcClassScript.BackColor = System.Drawing.SystemColors.Window
        Me.txtcClassScript.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcClassScript.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtcClassScript.Location = New System.Drawing.Point(184, 237)
        Me.txtcClassScript.MaxLength = 0
        Me.txtcClassScript.Name = "txtcClassScript"
        Me.txtcClassScript.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtcClassScript.Size = New System.Drawing.Size(354, 20)
        Me.txtcClassScript.TabIndex = 6
        '
        'Generate
        '
        Me.Generate.BackColor = System.Drawing.SystemColors.Control
        Me.Generate.Cursor = System.Windows.Forms.Cursors.Default
        Me.Generate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Generate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Generate.Location = New System.Drawing.Point(222, 398)
        Me.Generate.Name = "Generate"
        Me.Generate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Generate.Size = New System.Drawing.Size(81, 31)
        Me.Generate.TabIndex = 10
        Me.Generate.Text = "Generate"
        Me.Generate.UseVisualStyleBackColor = False
        '
        'txtCOutputLocation
        '
        Me.txtCOutputLocation.AcceptsReturn = True
        Me.txtCOutputLocation.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOutputLocation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCOutputLocation.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCOutputLocation.Location = New System.Drawing.Point(184, 211)
        Me.txtCOutputLocation.MaxLength = 0
        Me.txtCOutputLocation.Name = "txtCOutputLocation"
        Me.txtCOutputLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCOutputLocation.Size = New System.Drawing.Size(354, 20)
        Me.txtCOutputLocation.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(32, 191)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(385, 17)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "NB These directories should exist before running the code generation routine."
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(32, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(149, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Database Name:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(32, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(142, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "User ID"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(149, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(32, 315)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(149, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Stored Proc output Location:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(32, 289)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(142, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Stored Procedures"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(32, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(149, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "cClass Script"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(32, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(149, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "cClass Output Location"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(32, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(149, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Table of Tables:"
        '
        'txtTableOfTables
        '
        Me.txtTableOfTables.AcceptsReturn = True
        Me.txtTableOfTables.BackColor = System.Drawing.SystemColors.Window
        Me.txtTableOfTables.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTableOfTables.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTableOfTables.Location = New System.Drawing.Point(184, 145)
        Me.txtTableOfTables.MaxLength = 0
        Me.txtTableOfTables.Name = "txtTableOfTables"
        Me.txtTableOfTables.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTableOfTables.Size = New System.Drawing.Size(354, 20)
        Me.txtTableOfTables.TabIndex = 4
        Me.txtTableOfTables.Text = "DBTables"
        '
        'txtcClassPHPScript
        '
        Me.txtcClassPHPScript.AcceptsReturn = True
        Me.txtcClassPHPScript.BackColor = System.Drawing.SystemColors.Window
        Me.txtcClassPHPScript.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcClassPHPScript.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtcClassPHPScript.Location = New System.Drawing.Point(184, 263)
        Me.txtcClassPHPScript.MaxLength = 0
        Me.txtcClassPHPScript.Name = "txtcClassPHPScript"
        Me.txtcClassPHPScript.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtcClassPHPScript.Size = New System.Drawing.Size(354, 20)
        Me.txtcClassPHPScript.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(32, 263)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(149, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "cClass PHP Script"
        '
        'DatabaseNames
        '
        Me.DatabaseNames.FormattingEnabled = True
        Me.DatabaseNames.Location = New System.Drawing.Point(184, 39)
        Me.DatabaseNames.Name = "DatabaseNames"
        Me.DatabaseNames.Size = New System.Drawing.Size(233, 21)
        Me.DatabaseNames.TabIndex = 23
        '
        'TableNames
        '
        Me.TableNames.FormattingEnabled = True
        Me.TableNames.Location = New System.Drawing.Point(184, 66)
        Me.TableNames.Name = "TableNames"
        Me.TableNames.Size = New System.Drawing.Size(233, 21)
        Me.TableNames.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(32, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(149, 16)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Table Name:"
        '
        'frmCodeGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(557, 441)
        Me.Controls.Add(Me.TableNames)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DatabaseNames)
        Me.Controls.Add(Me.txtcClassPHPScript)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTableOfTables)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtSprocsLocation)
        Me.Controls.Add(Me.txtSprocs)
        Me.Controls.Add(Me.txtcClassScript)
        Me.Controls.Add(Me.Generate)
        Me.Controls.Add(Me.txtCOutputLocation)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmCodeGenerator"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Waterfield Consulting - Code Generator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents txtTableOfTables As System.Windows.Forms.TextBox
    Public WithEvents txtcClassPHPScript As System.Windows.Forms.TextBox
    Public WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DatabaseNames As System.Windows.Forms.ComboBox
    Friend WithEvents TableNames As System.Windows.Forms.ComboBox
    Public WithEvents Label12 As System.Windows.Forms.Label
#End Region
End Class