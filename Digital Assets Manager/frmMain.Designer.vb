<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblDash = New System.Windows.Forms.Label()
        Me.lblZEC = New System.Windows.Forms.Label()
        Me.lblXMR = New System.Windows.Forms.Label()
        Me.lblETH = New System.Windows.Forms.Label()
        Me.lblPIVX = New System.Windows.Forms.Label()
        Me.lblBTC = New System.Windows.Forms.Label()
        Me.lblLTC = New System.Windows.Forms.Label()
        Me.lblXRP = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAssetsItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDatabaseMaintenance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBackupItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRestoreItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDonateItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAboutItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.AssetsToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.InvestmentToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OFDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FBDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblXLM = New System.Windows.Forms.Label()
        Me.chkAuto = New System.Windows.Forms.CheckBox()
        Me.tmrAuto = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(336, 354)
        Me.btnCalc.Margin = New System.Windows.Forms.Padding(6)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(182, 77)
        Me.btnCalc.TabIndex = 0
        Me.btnCalc.Text = "Calculate"
        Me.btnCalc.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(16, 62)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(816, 108)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDash
        '
        Me.lblDash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDash.Location = New System.Drawing.Point(16, 46)
        Me.lblDash.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDash.Name = "lblDash"
        Me.lblDash.Size = New System.Drawing.Size(256, 25)
        Me.lblDash.TabIndex = 4
        Me.lblDash.Text = "Dash: 0"
        '
        'lblZEC
        '
        Me.lblZEC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZEC.Location = New System.Drawing.Point(16, 77)
        Me.lblZEC.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblZEC.Name = "lblZEC"
        Me.lblZEC.Size = New System.Drawing.Size(256, 25)
        Me.lblZEC.TabIndex = 5
        Me.lblZEC.Text = "Zcash: 0"
        '
        'lblXMR
        '
        Me.lblXMR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXMR.Location = New System.Drawing.Point(288, 46)
        Me.lblXMR.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblXMR.Name = "lblXMR"
        Me.lblXMR.Size = New System.Drawing.Size(272, 25)
        Me.lblXMR.TabIndex = 9
        Me.lblXMR.Text = "Monero: 0"
        '
        'lblETH
        '
        Me.lblETH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblETH.Location = New System.Drawing.Point(16, 108)
        Me.lblETH.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblETH.Name = "lblETH"
        Me.lblETH.Size = New System.Drawing.Size(256, 25)
        Me.lblETH.TabIndex = 8
        Me.lblETH.Text = "Ethereum: 0"
        '
        'lblPIVX
        '
        Me.lblPIVX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPIVX.Location = New System.Drawing.Point(576, 77)
        Me.lblPIVX.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblPIVX.Name = "lblPIVX"
        Me.lblPIVX.Size = New System.Drawing.Size(224, 25)
        Me.lblPIVX.TabIndex = 13
        Me.lblPIVX.Text = "PIVX: 0"
        '
        'lblBTC
        '
        Me.lblBTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBTC.Location = New System.Drawing.Point(288, 77)
        Me.lblBTC.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblBTC.Name = "lblBTC"
        Me.lblBTC.Size = New System.Drawing.Size(272, 25)
        Me.lblBTC.TabIndex = 15
        Me.lblBTC.Text = "Bitcoin: 0"
        '
        'lblLTC
        '
        Me.lblLTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLTC.Location = New System.Drawing.Point(288, 108)
        Me.lblLTC.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblLTC.Name = "lblLTC"
        Me.lblLTC.Size = New System.Drawing.Size(272, 25)
        Me.lblLTC.TabIndex = 19
        Me.lblLTC.Text = "Litecoin: 0"
        '
        'lblXRP
        '
        Me.lblXRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXRP.Location = New System.Drawing.Point(576, 46)
        Me.lblXRP.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblXRP.Name = "lblXRP"
        Me.lblXRP.Size = New System.Drawing.Size(224, 25)
        Me.lblXRP.TabIndex = 17
        Me.lblXRP.Text = "Ripple: 0"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ManageToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(12, 4, 0, 4)
        Me.MenuStrip1.Size = New System.Drawing.Size(850, 44)
        Me.MenuStrip1.TabIndex = 20
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(64, 36)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(151, 38)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ManageToolStripMenuItem
        '
        Me.ManageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAssetsItem, Me.ToolStripSeparator1, Me.mnuDatabaseMaintenance})
        Me.ManageToolStripMenuItem.Name = "ManageToolStripMenuItem"
        Me.ManageToolStripMenuItem.Size = New System.Drawing.Size(114, 36)
        Me.ManageToolStripMenuItem.Text = "Manage"
        '
        'mnuAssetsItem
        '
        Me.mnuAssetsItem.Name = "mnuAssetsItem"
        Me.mnuAssetsItem.Size = New System.Drawing.Size(358, 38)
        Me.mnuAssetsItem.Text = "Assets"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(355, 6)
        '
        'mnuDatabaseMaintenance
        '
        Me.mnuDatabaseMaintenance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBackupItem, Me.mnuRestoreItem})
        Me.mnuDatabaseMaintenance.Name = "mnuDatabaseMaintenance"
        Me.mnuDatabaseMaintenance.Size = New System.Drawing.Size(358, 38)
        Me.mnuDatabaseMaintenance.Text = "Database Maintenance"
        '
        'mnuBackupItem
        '
        Me.mnuBackupItem.Name = "mnuBackupItem"
        Me.mnuBackupItem.Size = New System.Drawing.Size(193, 38)
        Me.mnuBackupItem.Text = "Backup"
        '
        'mnuRestoreItem
        '
        Me.mnuRestoreItem.Name = "mnuRestoreItem"
        Me.mnuRestoreItem.Size = New System.Drawing.Size(193, 38)
        Me.mnuRestoreItem.Text = "Restore"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDonateItem, Me.mnuAboutItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(77, 36)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'mnuDonateItem
        '
        Me.mnuDonateItem.Name = "mnuDonateItem"
        Me.mnuDonateItem.Size = New System.Drawing.Size(294, 38)
        Me.mnuDonateItem.Text = "Donate (PayPal)..."
        '
        'mnuAboutItem
        '
        Me.mnuAboutItem.Name = "mnuAboutItem"
        Me.mnuAboutItem.Size = New System.Drawing.Size(294, 38)
        Me.mnuAboutItem.Text = "About"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssetsToolStripStatusLabel1, Me.InvestmentToolStripStatusLabel4})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 453)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 28, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(850, 41)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 21
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'AssetsToolStripStatusLabel1
        '
        Me.AssetsToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.AssetsToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.AssetsToolStripStatusLabel1.Name = "AssetsToolStripStatusLabel1"
        Me.AssetsToolStripStatusLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        Me.AssetsToolStripStatusLabel1.Size = New System.Drawing.Size(140, 36)
        Me.AssetsToolStripStatusLabel1.Text = "Assets: 0"
        Me.AssetsToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InvestmentToolStripStatusLabel4
        '
        Me.InvestmentToolStripStatusLabel4.AutoSize = False
        Me.InvestmentToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.InvestmentToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.InvestmentToolStripStatusLabel4.Name = "InvestmentToolStripStatusLabel4"
        Me.InvestmentToolStripStatusLabel4.Size = New System.Drawing.Size(680, 36)
        Me.InvestmentToolStripStatusLabel4.Spring = True
        Me.InvestmentToolStripStatusLabel4.Tag = ""
        Me.InvestmentToolStripStatusLabel4.Text = "Investment: € 0"
        Me.InvestmentToolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OFDialog1
        '
        Me.OFDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblXLM)
        Me.GroupBox1.Controls.Add(Me.lblDash)
        Me.GroupBox1.Controls.Add(Me.lblZEC)
        Me.GroupBox1.Controls.Add(Me.lblLTC)
        Me.GroupBox1.Controls.Add(Me.lblETH)
        Me.GroupBox1.Controls.Add(Me.lblXRP)
        Me.GroupBox1.Controls.Add(Me.lblXMR)
        Me.GroupBox1.Controls.Add(Me.lblBTC)
        Me.GroupBox1.Controls.Add(Me.lblPIVX)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 185)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Size = New System.Drawing.Size(816, 154)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Summary"
        '
        'lblXLM
        '
        Me.lblXLM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXLM.Location = New System.Drawing.Point(576, 108)
        Me.lblXLM.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblXLM.Name = "lblXLM"
        Me.lblXLM.Size = New System.Drawing.Size(224, 25)
        Me.lblXLM.TabIndex = 20
        Me.lblXLM.Text = "Lumens: 0"
        '
        'chkAuto
        '
        Me.chkAuto.AutoSize = True
        Me.chkAuto.Location = New System.Drawing.Point(544, 369)
        Me.chkAuto.Margin = New System.Windows.Forms.Padding(6)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(163, 29)
        Me.chkAuto.TabIndex = 23
        Me.chkAuto.Text = "Auto Update"
        Me.chkAuto.UseVisualStyleBackColor = True
        '
        'tmrAuto
        '
        Me.tmrAuto.Interval = 5000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(850, 494)
        Me.Controls.Add(Me.chkAuto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnCalc)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Digital Assets Manager"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCalc As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblDash As Label
    Friend WithEvents lblZEC As Label
    Friend WithEvents lblXMR As Label
    Friend WithEvents lblETH As Label
    Friend WithEvents lblPIVX As Label
    Friend WithEvents lblBTC As Label
    Friend WithEvents lblLTC As Label
    Friend WithEvents lblXRP As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuAssetsItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents AssetsToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents InvestmentToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuDatabaseMaintenance As ToolStripMenuItem
    Friend WithEvents mnuBackupItem As ToolStripMenuItem
    Friend WithEvents mnuRestoreItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuDonateItem As ToolStripMenuItem
    Friend WithEvents mnuAboutItem As ToolStripMenuItem
    Friend WithEvents OFDialog1 As OpenFileDialog
    Friend WithEvents FBDialog1 As FolderBrowserDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblXLM As Label
    Friend WithEvents chkAuto As CheckBox
    Friend WithEvents tmrAuto As Timer
End Class
