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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocateDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutBoschDigiCardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.StatusStripForm1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLable1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DataGridViewCardsForm1 = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CheckBoxBroadSearch = New System.Windows.Forms.CheckBox()
        Me.LabelQuickSearch = New System.Windows.Forms.Label()
        Me.TextBoxQuickSearch = New System.Windows.Forms.TextBox()
        Me.TimerQuickSearch = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStripForm1.SuspendLayout()
        CType(Me.DataGridViewCardsForm1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Location = New System.Drawing.Point(909, 38)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSearch.TabIndex = 0
        Me.ButtonSearch.Text = "Search"
        Me.ButtonSearch.UseVisualStyleBackColor = True
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewEntryToolStripMenuItem, Me.LocateDatabaseToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LocateDatabaseToolStripMenuItem
        '
        Me.LocateDatabaseToolStripMenuItem.Name = "LocateDatabaseToolStripMenuItem"
        Me.LocateDatabaseToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LocateDatabaseToolStripMenuItem.Text = "Locate Database"
        '
        'NewEntryToolStripMenuItem
        '
        Me.NewEntryToolStripMenuItem.Name = "NewEntryToolStripMenuItem"
        Me.NewEntryToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.NewEntryToolStripMenuItem.Text = "New Entry"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutBoschDigiCardToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.EditToolStripMenuItem.Text = "Help"
        '
        'AboutBoschDigiCardToolStripMenuItem
        '
        Me.AboutBoschDigiCardToolStripMenuItem.Name = "AboutBoschDigiCardToolStripMenuItem"
        Me.AboutBoschDigiCardToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.AboutBoschDigiCardToolStripMenuItem.Text = "About Bosch DigiCard"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1013, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'StatusStripForm1
        '
        Me.StatusStripForm1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLable1})
        Me.StatusStripForm1.Location = New System.Drawing.Point(0, 600)
        Me.StatusStripForm1.Name = "StatusStripForm1"
        Me.StatusStripForm1.Size = New System.Drawing.Size(1013, 22)
        Me.StatusStripForm1.SizingGrip = False
        Me.StatusStripForm1.TabIndex = 3
        Me.StatusStripForm1.Text = "StatusStrip1"
        '
        'ToolStripStatusLable1
        '
        Me.ToolStripStatusLable1.Name = "ToolStripStatusLable1"
        Me.ToolStripStatusLable1.Size = New System.Drawing.Size(36, 17)
        Me.ToolStripStatusLable1.Text = "None"
        '
        'DataGridViewCardsForm1
        '
        Me.DataGridViewCardsForm1.AllowUserToAddRows = False
        Me.DataGridViewCardsForm1.AllowUserToDeleteRows = False
        Me.DataGridViewCardsForm1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridViewCardsForm1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewCardsForm1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewCardsForm1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCardsForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewCardsForm1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewCardsForm1.Name = "DataGridViewCardsForm1"
        Me.DataGridViewCardsForm1.ReadOnly = True
        Me.DataGridViewCardsForm1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewCardsForm1.Size = New System.Drawing.Size(1013, 449)
        Me.DataGridViewCardsForm1.TabIndex = 4
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxBroadSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelQuickSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxQuickSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonSearch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridViewCardsForm1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1013, 576)
        Me.SplitContainer1.SplitterDistance = 123
        Me.SplitContainer1.TabIndex = 5
        '
        'CheckBoxBroadSearch
        '
        Me.CheckBoxBroadSearch.AutoSize = True
        Me.CheckBoxBroadSearch.Location = New System.Drawing.Point(812, 42)
        Me.CheckBoxBroadSearch.Name = "CheckBoxBroadSearch"
        Me.CheckBoxBroadSearch.Size = New System.Drawing.Size(91, 17)
        Me.CheckBoxBroadSearch.TabIndex = 3
        Me.CheckBoxBroadSearch.Tag = ""
        Me.CheckBoxBroadSearch.Text = "Broad Search"
        Me.ToolTip.SetToolTip(Me.CheckBoxBroadSearch, "Broadens search to include any matching terms. Uncheck for precise results.")
        Me.CheckBoxBroadSearch.UseVisualStyleBackColor = True
        '
        'LabelQuickSearch
        '
        Me.LabelQuickSearch.AutoSize = True
        Me.LabelQuickSearch.Location = New System.Drawing.Point(19, 25)
        Me.LabelQuickSearch.Name = "LabelQuickSearch"
        Me.LabelQuickSearch.Size = New System.Drawing.Size(72, 13)
        Me.LabelQuickSearch.TabIndex = 2
        Me.LabelQuickSearch.Text = "Quick Search"
        '
        'TextBoxQuickSearch
        '
        Me.TextBoxQuickSearch.Location = New System.Drawing.Point(97, 22)
        Me.TextBoxQuickSearch.Name = "TextBoxQuickSearch"
        Me.TextBoxQuickSearch.Size = New System.Drawing.Size(256, 20)
        Me.TextBoxQuickSearch.TabIndex = 1
        '
        'TimerQuickSearch
        '
        '
        'ToolTip
        '
        Me.ToolTip.AutoPopDelay = 10000
        Me.ToolTip.InitialDelay = 500
        Me.ToolTip.ReshowDelay = 100
        Me.ToolTip.Tag = ""
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 622)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStripForm1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "DigiCard"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStripForm1.ResumeLayout(False)
        Me.StatusStripForm1.PerformLayout()
        CType(Me.DataGridViewCardsForm1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonSearch As Button
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewEntryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutBoschDigiCardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents StatusStripForm1 As StatusStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents DataGridViewCardsForm1 As DataGridView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TextBoxQuickSearch As TextBox
    Friend WithEvents TimerQuickSearch As Timer
    Friend WithEvents ToolStripStatusLable1 As ToolStripStatusLabel
    Friend WithEvents LabelQuickSearch As Label
    Friend WithEvents CheckBoxBroadSearch As CheckBox
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents LocateDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
