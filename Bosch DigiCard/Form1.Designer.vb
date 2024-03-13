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
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LocateDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetDonwloadPathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetGeocodingAPIKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutBoschDigiCardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.StatusStripForm1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DataGridViewCardsForm1 = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CheckBoxHidePolice = New System.Windows.Forms.CheckBox()
        Me.CheckBoxHideFire = New System.Windows.Forms.CheckBox()
        Me.CheckBoxBroadSearch = New System.Windows.Forms.CheckBox()
        Me.LabelQuickSearch = New System.Windows.Forms.Label()
        Me.TextBoxQuickSearch = New System.Windows.Forms.TextBox()
        Me.TabControlCardTable = New System.Windows.Forms.TabControl()
        Me.TableView = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GMapControl = New GMap.NET.WindowsForms.GMapControl()
        Me.TimerQuickSearch = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStripForm1.SuspendLayout()
        CType(Me.DataGridViewCardsForm1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControlCardTable.SuspendLayout()
        Me.TableView.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewEntryToolStripMenuItem, Me.ToolStripSeparator1, Me.LocateDatabaseToolStripMenuItem, Me.SetDonwloadPathToolStripMenuItem, Me.SetGeocodingAPIKeyToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewEntryToolStripMenuItem
        '
        Me.NewEntryToolStripMenuItem.Image = Global.Bosch_DigiCard.My.Resources.Resources.icons8_seite_einfügen_96
        Me.NewEntryToolStripMenuItem.Name = "NewEntryToolStripMenuItem"
        Me.NewEntryToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.NewEntryToolStripMenuItem.Text = "New Entry"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(191, 6)
        '
        'LocateDatabaseToolStripMenuItem
        '
        Me.LocateDatabaseToolStripMenuItem.Image = Global.Bosch_DigiCard.My.Resources.Resources.icons8_mappe_96
        Me.LocateDatabaseToolStripMenuItem.Name = "LocateDatabaseToolStripMenuItem"
        Me.LocateDatabaseToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.LocateDatabaseToolStripMenuItem.Text = "Locate Database"
        '
        'SetDonwloadPathToolStripMenuItem
        '
        Me.SetDonwloadPathToolStripMenuItem.Image = Global.Bosch_DigiCard.My.Resources.Resources.icons8_updates_herunterladen_96
        Me.SetDonwloadPathToolStripMenuItem.Name = "SetDonwloadPathToolStripMenuItem"
        Me.SetDonwloadPathToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.SetDonwloadPathToolStripMenuItem.Text = "Set Download Path"
        '
        'SetGeocodingAPIKeyToolStripMenuItem
        '
        Me.SetGeocodingAPIKeyToolStripMenuItem.Name = "SetGeocodingAPIKeyToolStripMenuItem"
        Me.SetGeocodingAPIKeyToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.SetGeocodingAPIKeyToolStripMenuItem.Text = "Set Geocoding API Key"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(191, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
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
        Me.StatusStripForm1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStripForm1.Location = New System.Drawing.Point(0, 600)
        Me.StatusStripForm1.Name = "StatusStripForm1"
        Me.StatusStripForm1.Size = New System.Drawing.Size(1013, 22)
        Me.StatusStripForm1.SizingGrip = False
        Me.StatusStripForm1.TabIndex = 3
        Me.StatusStripForm1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(36, 17)
        Me.ToolStripStatusLabel1.Text = "None"
        '
        'DataGridViewCardsForm1
        '
        Me.DataGridViewCardsForm1.AllowUserToAddRows = False
        Me.DataGridViewCardsForm1.AllowUserToDeleteRows = False
        Me.DataGridViewCardsForm1.AllowUserToOrderColumns = True
        Me.DataGridViewCardsForm1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridViewCardsForm1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewCardsForm1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewCardsForm1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCardsForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewCardsForm1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewCardsForm1.MultiSelect = False
        Me.DataGridViewCardsForm1.Name = "DataGridViewCardsForm1"
        Me.DataGridViewCardsForm1.ReadOnly = True
        Me.DataGridViewCardsForm1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridViewCardsForm1.RowHeadersVisible = False
        Me.DataGridViewCardsForm1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewCardsForm1.Size = New System.Drawing.Size(999, 417)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxHidePolice)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxHideFire)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxBroadSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelQuickSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxQuickSearch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControlCardTable)
        Me.SplitContainer1.Size = New System.Drawing.Size(1013, 576)
        Me.SplitContainer1.SplitterDistance = 123
        Me.SplitContainer1.TabIndex = 5
        '
        'CheckBoxHidePolice
        '
        Me.CheckBoxHidePolice.AutoSize = True
        Me.CheckBoxHidePolice.Location = New System.Drawing.Point(22, 72)
        Me.CheckBoxHidePolice.Name = "CheckBoxHidePolice"
        Me.CheckBoxHidePolice.Size = New System.Drawing.Size(80, 17)
        Me.CheckBoxHidePolice.TabIndex = 4
        Me.CheckBoxHidePolice.Text = "Hide Police"
        Me.ToolTip.SetToolTip(Me.CheckBoxHidePolice, "Check this box to exclude all police-related cards from your search results.")
        Me.CheckBoxHidePolice.UseVisualStyleBackColor = True
        '
        'CheckBoxHideFire
        '
        Me.CheckBoxHideFire.AutoSize = True
        Me.CheckBoxHideFire.Location = New System.Drawing.Point(118, 72)
        Me.CheckBoxHideFire.Name = "CheckBoxHideFire"
        Me.CheckBoxHideFire.Size = New System.Drawing.Size(68, 17)
        Me.CheckBoxHideFire.TabIndex = 4
        Me.CheckBoxHideFire.Text = "Hide Fire"
        Me.ToolTip.SetToolTip(Me.CheckBoxHideFire, "Check this box to exclude all fire-related cards from your search results.")
        Me.CheckBoxHideFire.UseVisualStyleBackColor = True
        '
        'CheckBoxBroadSearch
        '
        Me.CheckBoxBroadSearch.AutoSize = True
        Me.CheckBoxBroadSearch.Location = New System.Drawing.Point(203, 72)
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
        Me.ToolTip.SetToolTip(Me.TextBoxQuickSearch, "Enter keywords to search for specific cards. Use space to separate multiple terms" &
        ".")
        '
        'TabControlCardTable
        '
        Me.TabControlCardTable.Controls.Add(Me.TableView)
        Me.TabControlCardTable.Controls.Add(Me.TabPage2)
        Me.TabControlCardTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlCardTable.Location = New System.Drawing.Point(0, 0)
        Me.TabControlCardTable.Name = "TabControlCardTable"
        Me.TabControlCardTable.SelectedIndex = 0
        Me.TabControlCardTable.Size = New System.Drawing.Size(1013, 449)
        Me.TabControlCardTable.TabIndex = 5
        '
        'TableView
        '
        Me.TableView.Controls.Add(Me.DataGridViewCardsForm1)
        Me.TableView.Location = New System.Drawing.Point(4, 22)
        Me.TableView.Name = "TableView"
        Me.TableView.Padding = New System.Windows.Forms.Padding(3)
        Me.TableView.Size = New System.Drawing.Size(1005, 423)
        Me.TableView.TabIndex = 0
        Me.TableView.Text = "Table View"
        Me.TableView.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GMapControl)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1005, 423)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Map View"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GMapControl
        '
        Me.GMapControl.Bearing = 0!
        Me.GMapControl.CanDragMap = True
        Me.GMapControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GMapControl.EmptyTileColor = System.Drawing.Color.Navy
        Me.GMapControl.GrayScaleMode = False
        Me.GMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.GMapControl.LevelsKeepInMemory = 5
        Me.GMapControl.Location = New System.Drawing.Point(3, 3)
        Me.GMapControl.MarkersEnabled = True
        Me.GMapControl.MaxZoom = 2
        Me.GMapControl.MinZoom = 2
        Me.GMapControl.MouseWheelZoomEnabled = True
        Me.GMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.GMapControl.Name = "GMapControl"
        Me.GMapControl.NegativeMode = False
        Me.GMapControl.PolygonsEnabled = True
        Me.GMapControl.RetryLoadTile = 0
        Me.GMapControl.RoutesEnabled = True
        Me.GMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.GMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GMapControl.ShowTileGridLines = False
        Me.GMapControl.Size = New System.Drawing.Size(999, 417)
        Me.GMapControl.TabIndex = 0
        Me.GMapControl.Zoom = 0R
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
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 622)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStripForm1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
        Me.TabControlCardTable.ResumeLayout(False)
        Me.TableView.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents LabelQuickSearch As Label
    Friend WithEvents CheckBoxBroadSearch As CheckBox
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents LocateDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CheckBoxHidePolice As CheckBox
    Friend WithEvents CheckBoxHideFire As CheckBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents SetDonwloadPathToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetGeocodingAPIKeyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControlCardTable As TabControl
    Friend WithEvents TableView As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GMapControl As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
