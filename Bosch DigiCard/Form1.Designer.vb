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
        Me.TableLayoutPanelObject = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBoxQuickSearch = New System.Windows.Forms.TextBox()
        Me.LabelQuickSearch = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanelLetLong = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckBoxHidePolice = New System.Windows.Forms.CheckBox()
        Me.CheckBoxHideFire = New System.Windows.Forms.CheckBox()
        Me.CheckBoxBroadSearch = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFuzzySearch = New System.Windows.Forms.CheckBox()
        Me.LabelSiteAddressStreet = New System.Windows.Forms.Label()
        Me.LabelSiteAddressNumber = New System.Windows.Forms.Label()
        Me.LabelSiteAddressAddition = New System.Windows.Forms.Label()
        Me.TextBoxSiteAddressStreet = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressNumber = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressAddition = New System.Windows.Forms.TextBox()
        Me.LabelSiteAddressZIP = New System.Windows.Forms.Label()
        Me.LabelSiteAddressCity = New System.Windows.Forms.Label()
        Me.LabelSiteAddressCountry = New System.Windows.Forms.Label()
        Me.TextBoxSiteAddressCity = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressPLZ = New System.Windows.Forms.TextBox()
        Me.LabelCardNumber = New System.Windows.Forms.Label()
        Me.LabelSiteName = New System.Windows.Forms.Label()
        Me.TextBoxCardNumber = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteName = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressCountry = New System.Windows.Forms.TextBox()
        Me.ButtonAdvancedSearch = New System.Windows.Forms.Button()
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
        Me.TableLayoutPanelObject.SuspendLayout()
        Me.FlowLayoutPanelLetLong.SuspendLayout()
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
        Me.DataGridViewCardsForm1.Size = New System.Drawing.Size(999, 401)
        Me.DataGridViewCardsForm1.TabIndex = 4
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanelObject)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControlCardTable)
        Me.SplitContainer1.Size = New System.Drawing.Size(1013, 576)
        Me.SplitContainer1.SplitterDistance = 139
        Me.SplitContainer1.TabIndex = 5
        '
        'TableLayoutPanelObject
        '
        Me.TableLayoutPanelObject.AutoSize = True
        Me.TableLayoutPanelObject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanelObject.ColumnCount = 8
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxQuickSearch, 1, 0)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelQuickSearch, 0, 0)
        Me.TableLayoutPanelObject.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanelObject.Controls.Add(Me.FlowLayoutPanelLetLong, 1, 1)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressStreet, 0, 2)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressNumber, 0, 3)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressAddition, 0, 4)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressStreet, 1, 2)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressNumber, 1, 3)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressAddition, 1, 4)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressZIP, 2, 2)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressCity, 2, 3)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressCountry, 2, 4)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressCity, 3, 3)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressPLZ, 3, 2)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelCardNumber, 4, 2)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteName, 4, 3)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxCardNumber, 5, 2)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteName, 5, 3)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressCountry, 3, 4)
        Me.TableLayoutPanelObject.Controls.Add(Me.ButtonAdvancedSearch, 5, 4)
        Me.TableLayoutPanelObject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelObject.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelObject.Name = "TableLayoutPanelObject"
        Me.TableLayoutPanelObject.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.TableLayoutPanelObject.RowCount = 7
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelObject.Size = New System.Drawing.Size(1013, 139)
        Me.TableLayoutPanelObject.TabIndex = 5
        '
        'TextBoxQuickSearch
        '
        Me.TextBoxQuickSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanelObject.SetColumnSpan(Me.TextBoxQuickSearch, 3)
        Me.TextBoxQuickSearch.Location = New System.Drawing.Point(85, 6)
        Me.TextBoxQuickSearch.Margin = New System.Windows.Forms.Padding(3, 6, 3, 10)
        Me.TextBoxQuickSearch.Name = "TextBoxQuickSearch"
        Me.TextBoxQuickSearch.Size = New System.Drawing.Size(350, 20)
        Me.TextBoxQuickSearch.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.TextBoxQuickSearch, "Enter keywords to search for specific cards. Use space to separate multiple terms" &
        ".")
        '
        'LabelQuickSearch
        '
        Me.LabelQuickSearch.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelQuickSearch.AutoSize = True
        Me.LabelQuickSearch.Location = New System.Drawing.Point(7, 8)
        Me.LabelQuickSearch.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.LabelQuickSearch.Name = "LabelQuickSearch"
        Me.LabelQuickSearch.Size = New System.Drawing.Size(72, 13)
        Me.LabelQuickSearch.TabIndex = 2
        Me.LabelQuickSearch.Text = "Quick Search"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Filter"
        '
        'FlowLayoutPanelLetLong
        '
        Me.FlowLayoutPanelLetLong.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FlowLayoutPanelLetLong.AutoSize = True
        Me.TableLayoutPanelObject.SetColumnSpan(Me.FlowLayoutPanelLetLong, 3)
        Me.FlowLayoutPanelLetLong.Controls.Add(Me.CheckBoxHidePolice)
        Me.FlowLayoutPanelLetLong.Controls.Add(Me.CheckBoxHideFire)
        Me.FlowLayoutPanelLetLong.Controls.Add(Me.CheckBoxBroadSearch)
        Me.FlowLayoutPanelLetLong.Controls.Add(Me.CheckBoxFuzzySearch)
        Me.FlowLayoutPanelLetLong.Location = New System.Drawing.Point(82, 36)
        Me.FlowLayoutPanelLetLong.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanelLetLong.Name = "FlowLayoutPanelLetLong"
        Me.FlowLayoutPanelLetLong.Size = New System.Drawing.Size(341, 23)
        Me.FlowLayoutPanelLetLong.TabIndex = 3
        '
        'CheckBoxHidePolice
        '
        Me.CheckBoxHidePolice.AutoSize = True
        Me.CheckBoxHidePolice.Location = New System.Drawing.Point(3, 3)
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
        Me.CheckBoxHideFire.Location = New System.Drawing.Point(89, 3)
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
        Me.CheckBoxBroadSearch.Location = New System.Drawing.Point(163, 3)
        Me.CheckBoxBroadSearch.Name = "CheckBoxBroadSearch"
        Me.CheckBoxBroadSearch.Size = New System.Drawing.Size(79, 17)
        Me.CheckBoxBroadSearch.TabIndex = 3
        Me.CheckBoxBroadSearch.Tag = ""
        Me.CheckBoxBroadSearch.Text = "OR Search"
        Me.ToolTip.SetToolTip(Me.CheckBoxBroadSearch, "If unchecked, items must match all search terms.")
        Me.CheckBoxBroadSearch.UseVisualStyleBackColor = True
        '
        'CheckBoxFuzzySearch
        '
        Me.CheckBoxFuzzySearch.AutoSize = True
        Me.CheckBoxFuzzySearch.Location = New System.Drawing.Point(248, 3)
        Me.CheckBoxFuzzySearch.Name = "CheckBoxFuzzySearch"
        Me.CheckBoxFuzzySearch.Size = New System.Drawing.Size(90, 17)
        Me.CheckBoxFuzzySearch.TabIndex = 5
        Me.CheckBoxFuzzySearch.Tag = ""
        Me.CheckBoxFuzzySearch.Text = "Fuzzy Search"
        Me.ToolTip.SetToolTip(Me.CheckBoxFuzzySearch, "Check this box to allow for approximate matches to your search terms.")
        Me.CheckBoxFuzzySearch.UseVisualStyleBackColor = True
        '
        'LabelSiteAddressStreet
        '
        Me.LabelSiteAddressStreet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressStreet.AutoSize = True
        Me.LabelSiteAddressStreet.Location = New System.Drawing.Point(7, 65)
        Me.LabelSiteAddressStreet.Name = "LabelSiteAddressStreet"
        Me.LabelSiteAddressStreet.Size = New System.Drawing.Size(35, 13)
        Me.LabelSiteAddressStreet.TabIndex = 1
        Me.LabelSiteAddressStreet.Text = "Street"
        '
        'LabelSiteAddressNumber
        '
        Me.LabelSiteAddressNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressNumber.AutoSize = True
        Me.LabelSiteAddressNumber.Location = New System.Drawing.Point(7, 91)
        Me.LabelSiteAddressNumber.Name = "LabelSiteAddressNumber"
        Me.LabelSiteAddressNumber.Size = New System.Drawing.Size(44, 13)
        Me.LabelSiteAddressNumber.TabIndex = 1
        Me.LabelSiteAddressNumber.Text = "Number"
        '
        'LabelSiteAddressAddition
        '
        Me.LabelSiteAddressAddition.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressAddition.AutoSize = True
        Me.LabelSiteAddressAddition.Location = New System.Drawing.Point(7, 118)
        Me.LabelSiteAddressAddition.Name = "LabelSiteAddressAddition"
        Me.LabelSiteAddressAddition.Size = New System.Drawing.Size(45, 13)
        Me.LabelSiteAddressAddition.TabIndex = 1
        Me.LabelSiteAddressAddition.Text = "Addition"
        '
        'TextBoxSiteAddressStreet
        '
        Me.TextBoxSiteAddressStreet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressStreet.Location = New System.Drawing.Point(85, 62)
        Me.TextBoxSiteAddressStreet.Name = "TextBoxSiteAddressStreet"
        Me.TextBoxSiteAddressStreet.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressStreet.TabIndex = 2
        '
        'TextBoxSiteAddressNumber
        '
        Me.TextBoxSiteAddressNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressNumber.Location = New System.Drawing.Point(85, 88)
        Me.TextBoxSiteAddressNumber.Name = "TextBoxSiteAddressNumber"
        Me.TextBoxSiteAddressNumber.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressNumber.TabIndex = 2
        '
        'TextBoxSiteAddressAddition
        '
        Me.TextBoxSiteAddressAddition.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressAddition.Location = New System.Drawing.Point(85, 115)
        Me.TextBoxSiteAddressAddition.Name = "TextBoxSiteAddressAddition"
        Me.TextBoxSiteAddressAddition.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressAddition.TabIndex = 2
        '
        'LabelSiteAddressZIP
        '
        Me.LabelSiteAddressZIP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressZIP.AutoSize = True
        Me.LabelSiteAddressZIP.Location = New System.Drawing.Point(254, 65)
        Me.LabelSiteAddressZIP.Name = "LabelSiteAddressZIP"
        Me.LabelSiteAddressZIP.Size = New System.Drawing.Size(24, 13)
        Me.LabelSiteAddressZIP.TabIndex = 1
        Me.LabelSiteAddressZIP.Text = "ZIP"
        '
        'LabelSiteAddressCity
        '
        Me.LabelSiteAddressCity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressCity.AutoSize = True
        Me.LabelSiteAddressCity.Location = New System.Drawing.Point(254, 91)
        Me.LabelSiteAddressCity.Name = "LabelSiteAddressCity"
        Me.LabelSiteAddressCity.Size = New System.Drawing.Size(24, 13)
        Me.LabelSiteAddressCity.TabIndex = 1
        Me.LabelSiteAddressCity.Text = "City"
        '
        'LabelSiteAddressCountry
        '
        Me.LabelSiteAddressCountry.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressCountry.AutoSize = True
        Me.LabelSiteAddressCountry.Location = New System.Drawing.Point(254, 118)
        Me.LabelSiteAddressCountry.Name = "LabelSiteAddressCountry"
        Me.LabelSiteAddressCountry.Size = New System.Drawing.Size(43, 13)
        Me.LabelSiteAddressCountry.TabIndex = 1
        Me.LabelSiteAddressCountry.Text = "Country"
        '
        'TextBoxSiteAddressCity
        '
        Me.TextBoxSiteAddressCity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressCity.Location = New System.Drawing.Point(303, 88)
        Me.TextBoxSiteAddressCity.Name = "TextBoxSiteAddressCity"
        Me.TextBoxSiteAddressCity.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressCity.TabIndex = 2
        '
        'TextBoxSiteAddressPLZ
        '
        Me.TextBoxSiteAddressPLZ.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressPLZ.Location = New System.Drawing.Point(303, 62)
        Me.TextBoxSiteAddressPLZ.Name = "TextBoxSiteAddressPLZ"
        Me.TextBoxSiteAddressPLZ.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressPLZ.TabIndex = 2
        '
        'LabelCardNumber
        '
        Me.LabelCardNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelCardNumber.AutoSize = True
        Me.LabelCardNumber.Location = New System.Drawing.Point(472, 65)
        Me.LabelCardNumber.Name = "LabelCardNumber"
        Me.LabelCardNumber.Size = New System.Drawing.Size(69, 13)
        Me.LabelCardNumber.TabIndex = 7
        Me.LabelCardNumber.Text = "Card Number"
        '
        'LabelSiteName
        '
        Me.LabelSiteName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteName.AutoSize = True
        Me.LabelSiteName.Location = New System.Drawing.Point(472, 91)
        Me.LabelSiteName.Name = "LabelSiteName"
        Me.LabelSiteName.Size = New System.Drawing.Size(56, 13)
        Me.LabelSiteName.TabIndex = 8
        Me.LabelSiteName.Text = "Site Name"
        '
        'TextBoxCardNumber
        '
        Me.TextBoxCardNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxCardNumber.Location = New System.Drawing.Point(547, 62)
        Me.TextBoxCardNumber.Name = "TextBoxCardNumber"
        Me.TextBoxCardNumber.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxCardNumber.TabIndex = 5
        '
        'TextBoxSiteName
        '
        Me.TextBoxSiteName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteName.Location = New System.Drawing.Point(547, 88)
        Me.TextBoxSiteName.Name = "TextBoxSiteName"
        Me.TextBoxSiteName.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteName.TabIndex = 6
        '
        'TextBoxSiteAddressCountry
        '
        Me.TextBoxSiteAddressCountry.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressCountry.Location = New System.Drawing.Point(303, 115)
        Me.TextBoxSiteAddressCountry.Name = "TextBoxSiteAddressCountry"
        Me.TextBoxSiteAddressCountry.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressCountry.TabIndex = 2
        '
        'ButtonAdvancedSearch
        '
        Me.ButtonAdvancedSearch.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.TableLayoutPanelObject.SetColumnSpan(Me.ButtonAdvancedSearch, 2)
        Me.ButtonAdvancedSearch.Location = New System.Drawing.Point(596, 114)
        Me.ButtonAdvancedSearch.Name = "ButtonAdvancedSearch"
        Me.ButtonAdvancedSearch.Size = New System.Drawing.Size(114, 22)
        Me.ButtonAdvancedSearch.TabIndex = 4
        Me.ButtonAdvancedSearch.Text = "Advanced Search"
        Me.ButtonAdvancedSearch.UseVisualStyleBackColor = True
        '
        'TabControlCardTable
        '
        Me.TabControlCardTable.Controls.Add(Me.TableView)
        Me.TabControlCardTable.Controls.Add(Me.TabPage2)
        Me.TabControlCardTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlCardTable.Location = New System.Drawing.Point(0, 0)
        Me.TabControlCardTable.Name = "TabControlCardTable"
        Me.TabControlCardTable.SelectedIndex = 0
        Me.TabControlCardTable.Size = New System.Drawing.Size(1013, 433)
        Me.TabControlCardTable.TabIndex = 5
        '
        'TableView
        '
        Me.TableView.Controls.Add(Me.DataGridViewCardsForm1)
        Me.TableView.Location = New System.Drawing.Point(4, 22)
        Me.TableView.Name = "TableView"
        Me.TableView.Padding = New System.Windows.Forms.Padding(3)
        Me.TableView.Size = New System.Drawing.Size(1005, 407)
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
        Me.TabPage2.Size = New System.Drawing.Size(1005, 407)
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
        Me.GMapControl.Size = New System.Drawing.Size(999, 401)
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
        Me.MinimumSize = New System.Drawing.Size(734, 661)
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
        Me.TableLayoutPanelObject.ResumeLayout(False)
        Me.TableLayoutPanelObject.PerformLayout()
        Me.FlowLayoutPanelLetLong.ResumeLayout(False)
        Me.FlowLayoutPanelLetLong.PerformLayout()
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
    Friend WithEvents TableLayoutPanelObject As TableLayoutPanel
    Friend WithEvents LabelSiteAddressZIP As Label
    Friend WithEvents FlowLayoutPanelLetLong As FlowLayoutPanel
    Friend WithEvents TextBoxSiteAddressPLZ As TextBox
    Friend WithEvents TextBoxSiteAddressCity As TextBox
    Friend WithEvents LabelSiteAddressCountry As Label
    Friend WithEvents LabelSiteAddressCity As Label
    Friend WithEvents LabelSiteAddressNumber As Label
    Friend WithEvents TextBoxSiteAddressNumber As TextBox
    Friend WithEvents TextBoxSiteAddressAddition As TextBox
    Friend WithEvents LabelSiteAddressAddition As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonAdvancedSearch As Button
    Friend WithEvents TextBoxSiteAddressStreet As TextBox
    Friend WithEvents TextBoxSiteAddressCountry As TextBox
    Friend WithEvents CheckBoxFuzzySearch As CheckBox
    Friend WithEvents TextBoxCardNumber As TextBox
    Friend WithEvents TextBoxSiteName As TextBox
    Friend WithEvents LabelSiteAddressStreet As Label
    Friend WithEvents LabelCardNumber As Label
    Friend WithEvents LabelSiteName As Label
End Class
