<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardView
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.GroupBoxSystemsType = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckBoxCardCDM = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCardPanic = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCardBurglary = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCardTSN = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCardBoSiNet = New System.Windows.Forms.CheckBox()
        Me.GroupBoxCard = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.RichTextBoxCardComment = New System.Windows.Forms.RichTextBox()
        Me.LabelCardNumber = New System.Windows.Forms.Label()
        Me.TextBoxCardNumber = New System.Windows.Forms.TextBox()
        Me.ComboBoxCardTyp = New System.Windows.Forms.ComboBox()
        Me.LabelCardType = New System.Windows.Forms.Label()
        Me.GroupBoxObject = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanelObject = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelSiteAddressZIP = New System.Windows.Forms.Label()
        Me.TextBoxSiteAddressPLZ = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressCountry = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteName = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressCity = New System.Windows.Forms.TextBox()
        Me.LabelSiteAddressCountry = New System.Windows.Forms.Label()
        Me.LabelSiteName = New System.Windows.Forms.Label()
        Me.LabelSiteAddressCity = New System.Windows.Forms.Label()
        Me.LabelSiteAddressNumber = New System.Windows.Forms.Label()
        Me.TextBoxSiteAddressNumber = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressStreet = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressAddition = New System.Windows.Forms.TextBox()
        Me.LabelSiteAddressStreet = New System.Windows.Forms.Label()
        Me.LabelSiteAddressAddition = New System.Windows.Forms.Label()
        Me.ButtonCardViewCancel = New System.Windows.Forms.Button()
        Me.ButtonCardViewApply = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBoxContactList = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutContact = New System.Windows.Forms.FlowLayoutPanel()
        Me.ButtonContactAdd = New System.Windows.Forms.Button()
        Me.GroupBoxSystemsType.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBoxCard.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBoxObject.SuspendLayout()
        Me.TableLayoutPanelObject.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBoxContactList.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 608)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(938, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'GroupBoxSystemsType
        '
        Me.GroupBoxSystemsType.AutoSize = True
        Me.GroupBoxSystemsType.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBoxSystemsType.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxSystemsType.Location = New System.Drawing.Point(0, 74)
        Me.GroupBoxSystemsType.Name = "GroupBoxSystemsType"
        Me.GroupBoxSystemsType.Size = New System.Drawing.Size(938, 42)
        Me.GroupBoxSystemsType.TabIndex = 5
        Me.GroupBoxSystemsType.TabStop = False
        Me.GroupBoxSystemsType.Text = "Systems Type"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBoxCardCDM)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBoxCardPanic)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBoxCardBurglary)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBoxCardTSN)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBoxCardBoSiNet)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(932, 23)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'CheckBoxCardCDM
        '
        Me.CheckBoxCardCDM.AutoSize = True
        Me.CheckBoxCardCDM.Location = New System.Drawing.Point(3, 3)
        Me.CheckBoxCardCDM.Name = "CheckBoxCardCDM"
        Me.CheckBoxCardCDM.Size = New System.Drawing.Size(50, 17)
        Me.CheckBoxCardCDM.TabIndex = 0
        Me.CheckBoxCardCDM.Text = "CDM"
        Me.CheckBoxCardCDM.UseVisualStyleBackColor = True
        '
        'CheckBoxCardPanic
        '
        Me.CheckBoxCardPanic.AutoSize = True
        Me.CheckBoxCardPanic.Location = New System.Drawing.Point(59, 3)
        Me.CheckBoxCardPanic.Name = "CheckBoxCardPanic"
        Me.CheckBoxCardPanic.Size = New System.Drawing.Size(53, 17)
        Me.CheckBoxCardPanic.TabIndex = 0
        Me.CheckBoxCardPanic.Text = "Panic"
        Me.CheckBoxCardPanic.UseVisualStyleBackColor = True
        '
        'CheckBoxCardBurglary
        '
        Me.CheckBoxCardBurglary.AutoSize = True
        Me.CheckBoxCardBurglary.Location = New System.Drawing.Point(118, 3)
        Me.CheckBoxCardBurglary.Name = "CheckBoxCardBurglary"
        Me.CheckBoxCardBurglary.Size = New System.Drawing.Size(64, 17)
        Me.CheckBoxCardBurglary.TabIndex = 0
        Me.CheckBoxCardBurglary.Text = "Burglary"
        Me.CheckBoxCardBurglary.UseVisualStyleBackColor = True
        '
        'CheckBoxCardTSN
        '
        Me.CheckBoxCardTSN.AutoSize = True
        Me.CheckBoxCardTSN.Location = New System.Drawing.Point(188, 3)
        Me.CheckBoxCardTSN.Name = "CheckBoxCardTSN"
        Me.CheckBoxCardTSN.Size = New System.Drawing.Size(48, 17)
        Me.CheckBoxCardTSN.TabIndex = 0
        Me.CheckBoxCardTSN.Text = "TSN"
        Me.CheckBoxCardTSN.UseVisualStyleBackColor = True
        '
        'CheckBoxCardBoSiNet
        '
        Me.CheckBoxCardBoSiNet.AutoSize = True
        Me.CheckBoxCardBoSiNet.Location = New System.Drawing.Point(242, 3)
        Me.CheckBoxCardBoSiNet.Name = "CheckBoxCardBoSiNet"
        Me.CheckBoxCardBoSiNet.Size = New System.Drawing.Size(65, 17)
        Me.CheckBoxCardBoSiNet.TabIndex = 0
        Me.CheckBoxCardBoSiNet.Text = "BoSiNet"
        Me.CheckBoxCardBoSiNet.UseVisualStyleBackColor = True
        '
        'GroupBoxCard
        '
        Me.GroupBoxCard.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBoxCard.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxCard.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxCard.Name = "GroupBoxCard"
        Me.GroupBoxCard.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBoxCard.Size = New System.Drawing.Size(938, 74)
        Me.GroupBoxCard.TabIndex = 2
        Me.GroupBoxCard.TabStop = False
        Me.GroupBoxCard.Text = "Card"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.RichTextBoxCardComment, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelCardNumber, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxCardNumber, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBoxCardTyp, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LabelCardType, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(932, 55)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'RichTextBoxCardComment
        '
        Me.RichTextBoxCardComment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxCardComment.Location = New System.Drawing.Point(468, 3)
        Me.RichTextBoxCardComment.Name = "RichTextBoxCardComment"
        Me.TableLayoutPanel2.SetRowSpan(Me.RichTextBoxCardComment, 2)
        Me.RichTextBoxCardComment.Size = New System.Drawing.Size(461, 49)
        Me.RichTextBoxCardComment.TabIndex = 4
        Me.RichTextBoxCardComment.Text = ""
        '
        'LabelCardNumber
        '
        Me.LabelCardNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelCardNumber.AutoSize = True
        Me.LabelCardNumber.Location = New System.Drawing.Point(3, 7)
        Me.LabelCardNumber.Name = "LabelCardNumber"
        Me.LabelCardNumber.Size = New System.Drawing.Size(44, 13)
        Me.LabelCardNumber.TabIndex = 1
        Me.LabelCardNumber.Text = "Number"
        '
        'TextBoxCardNumber
        '
        Me.TextBoxCardNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxCardNumber.Location = New System.Drawing.Point(96, 3)
        Me.TextBoxCardNumber.Name = "TextBoxCardNumber"
        Me.TextBoxCardNumber.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxCardNumber.TabIndex = 2
        '
        'ComboBoxCardTyp
        '
        Me.ComboBoxCardTyp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ComboBoxCardTyp.FormattingEnabled = True
        Me.ComboBoxCardTyp.Items.AddRange(New Object() {"Police", "Fire"})
        Me.ComboBoxCardTyp.Location = New System.Drawing.Point(96, 30)
        Me.ComboBoxCardTyp.Name = "ComboBoxCardTyp"
        Me.ComboBoxCardTyp.Size = New System.Drawing.Size(163, 21)
        Me.ComboBoxCardTyp.TabIndex = 3
        '
        'LabelCardType
        '
        Me.LabelCardType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelCardType.AutoSize = True
        Me.LabelCardType.Location = New System.Drawing.Point(3, 34)
        Me.LabelCardType.Name = "LabelCardType"
        Me.LabelCardType.Size = New System.Drawing.Size(31, 13)
        Me.LabelCardType.TabIndex = 1
        Me.LabelCardType.Text = "Type"
        '
        'GroupBoxObject
        '
        Me.GroupBoxObject.Controls.Add(Me.TableLayoutPanelObject)
        Me.GroupBoxObject.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxObject.Location = New System.Drawing.Point(0, 210)
        Me.GroupBoxObject.Name = "GroupBoxObject"
        Me.GroupBoxObject.Size = New System.Drawing.Size(938, 224)
        Me.GroupBoxObject.TabIndex = 3
        Me.GroupBoxObject.TabStop = False
        Me.GroupBoxObject.Text = "Object"
        '
        'TableLayoutPanelObject
        '
        Me.TableLayoutPanelObject.ColumnCount = 4
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanelObject.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressZIP, 0, 3)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressPLZ, 1, 3)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressCountry, 3, 3)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteName, 1, 0)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressCity, 3, 2)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressCountry, 2, 3)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteName, 0, 0)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressCity, 2, 2)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressNumber, 2, 1)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressNumber, 3, 1)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressStreet, 1, 1)
        Me.TableLayoutPanelObject.Controls.Add(Me.TextBoxSiteAddressAddition, 1, 2)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressStreet, 0, 1)
        Me.TableLayoutPanelObject.Controls.Add(Me.LabelSiteAddressAddition, 0, 2)
        Me.TableLayoutPanelObject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelObject.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanelObject.Name = "TableLayoutPanelObject"
        Me.TableLayoutPanelObject.RowCount = 4
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanelObject.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelObject.Size = New System.Drawing.Size(932, 205)
        Me.TableLayoutPanelObject.TabIndex = 3
        '
        'LabelSiteAddressZIP
        '
        Me.LabelSiteAddressZIP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressZIP.AutoSize = True
        Me.LabelSiteAddressZIP.Location = New System.Drawing.Point(3, 172)
        Me.LabelSiteAddressZIP.Name = "LabelSiteAddressZIP"
        Me.LabelSiteAddressZIP.Size = New System.Drawing.Size(24, 13)
        Me.LabelSiteAddressZIP.TabIndex = 1
        Me.LabelSiteAddressZIP.Text = "ZIP"
        '
        'TextBoxSiteAddressPLZ
        '
        Me.TextBoxSiteAddressPLZ.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressPLZ.Location = New System.Drawing.Point(96, 169)
        Me.TextBoxSiteAddressPLZ.Name = "TextBoxSiteAddressPLZ"
        Me.TextBoxSiteAddressPLZ.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressPLZ.TabIndex = 2
        '
        'TextBoxSiteAddressCountry
        '
        Me.TextBoxSiteAddressCountry.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressCountry.Location = New System.Drawing.Point(561, 169)
        Me.TextBoxSiteAddressCountry.Name = "TextBoxSiteAddressCountry"
        Me.TextBoxSiteAddressCountry.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressCountry.TabIndex = 2
        '
        'TextBoxSiteName
        '
        Me.TextBoxSiteName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteName.Location = New System.Drawing.Point(96, 15)
        Me.TextBoxSiteName.Name = "TextBoxSiteName"
        Me.TextBoxSiteName.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteName.TabIndex = 2
        '
        'TextBoxSiteAddressCity
        '
        Me.TextBoxSiteAddressCity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressCity.Location = New System.Drawing.Point(561, 117)
        Me.TextBoxSiteAddressCity.Name = "TextBoxSiteAddressCity"
        Me.TextBoxSiteAddressCity.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressCity.TabIndex = 2
        '
        'LabelSiteAddressCountry
        '
        Me.LabelSiteAddressCountry.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressCountry.AutoSize = True
        Me.LabelSiteAddressCountry.Location = New System.Drawing.Point(468, 172)
        Me.LabelSiteAddressCountry.Name = "LabelSiteAddressCountry"
        Me.LabelSiteAddressCountry.Size = New System.Drawing.Size(43, 13)
        Me.LabelSiteAddressCountry.TabIndex = 1
        Me.LabelSiteAddressCountry.Text = "Country"
        '
        'LabelSiteName
        '
        Me.LabelSiteName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteName.AutoSize = True
        Me.LabelSiteName.Location = New System.Drawing.Point(3, 19)
        Me.LabelSiteName.Name = "LabelSiteName"
        Me.LabelSiteName.Size = New System.Drawing.Size(35, 13)
        Me.LabelSiteName.TabIndex = 1
        Me.LabelSiteName.Text = "Name"
        '
        'LabelSiteAddressCity
        '
        Me.LabelSiteAddressCity.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressCity.AutoSize = True
        Me.LabelSiteAddressCity.Location = New System.Drawing.Point(468, 121)
        Me.LabelSiteAddressCity.Name = "LabelSiteAddressCity"
        Me.LabelSiteAddressCity.Size = New System.Drawing.Size(24, 13)
        Me.LabelSiteAddressCity.TabIndex = 1
        Me.LabelSiteAddressCity.Text = "City"
        '
        'LabelSiteAddressNumber
        '
        Me.LabelSiteAddressNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressNumber.AutoSize = True
        Me.LabelSiteAddressNumber.Location = New System.Drawing.Point(468, 70)
        Me.LabelSiteAddressNumber.Name = "LabelSiteAddressNumber"
        Me.LabelSiteAddressNumber.Size = New System.Drawing.Size(44, 13)
        Me.LabelSiteAddressNumber.TabIndex = 1
        Me.LabelSiteAddressNumber.Text = "Number"
        '
        'TextBoxSiteAddressNumber
        '
        Me.TextBoxSiteAddressNumber.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressNumber.Location = New System.Drawing.Point(561, 66)
        Me.TextBoxSiteAddressNumber.Name = "TextBoxSiteAddressNumber"
        Me.TextBoxSiteAddressNumber.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressNumber.TabIndex = 2
        '
        'TextBoxSiteAddressStreet
        '
        Me.TextBoxSiteAddressStreet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressStreet.Location = New System.Drawing.Point(96, 66)
        Me.TextBoxSiteAddressStreet.Name = "TextBoxSiteAddressStreet"
        Me.TextBoxSiteAddressStreet.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressStreet.TabIndex = 2
        '
        'TextBoxSiteAddressAddition
        '
        Me.TextBoxSiteAddressAddition.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TextBoxSiteAddressAddition.Location = New System.Drawing.Point(96, 117)
        Me.TextBoxSiteAddressAddition.Name = "TextBoxSiteAddressAddition"
        Me.TextBoxSiteAddressAddition.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressAddition.TabIndex = 2
        '
        'LabelSiteAddressStreet
        '
        Me.LabelSiteAddressStreet.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressStreet.AutoSize = True
        Me.LabelSiteAddressStreet.Location = New System.Drawing.Point(3, 70)
        Me.LabelSiteAddressStreet.Name = "LabelSiteAddressStreet"
        Me.LabelSiteAddressStreet.Size = New System.Drawing.Size(35, 13)
        Me.LabelSiteAddressStreet.TabIndex = 1
        Me.LabelSiteAddressStreet.Text = "Street"
        '
        'LabelSiteAddressAddition
        '
        Me.LabelSiteAddressAddition.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LabelSiteAddressAddition.AutoSize = True
        Me.LabelSiteAddressAddition.Location = New System.Drawing.Point(3, 121)
        Me.LabelSiteAddressAddition.Name = "LabelSiteAddressAddition"
        Me.LabelSiteAddressAddition.Size = New System.Drawing.Size(45, 13)
        Me.LabelSiteAddressAddition.TabIndex = 1
        Me.LabelSiteAddressAddition.Text = "Addition"
        '
        'ButtonCardViewCancel
        '
        Me.ButtonCardViewCancel.Location = New System.Drawing.Point(860, 3)
        Me.ButtonCardViewCancel.Name = "ButtonCardViewCancel"
        Me.ButtonCardViewCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCardViewCancel.TabIndex = 0
        Me.ButtonCardViewCancel.Text = "Cancel"
        Me.ButtonCardViewCancel.UseVisualStyleBackColor = True
        '
        'ButtonCardViewApply
        '
        Me.ButtonCardViewApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCardViewApply.Location = New System.Drawing.Point(779, 3)
        Me.ButtonCardViewApply.Name = "ButtonCardViewApply"
        Me.ButtonCardViewApply.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCardViewApply.TabIndex = 0
        Me.ButtonCardViewApply.Text = "Apply"
        Me.ButtonCardViewApply.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.AutoSize = True
        Me.FlowLayoutPanel3.Controls.Add(Me.ButtonCardViewCancel)
        Me.FlowLayoutPanel3.Controls.Add(Me.ButtonCardViewApply)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(0, 579)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(938, 29)
        Me.FlowLayoutPanel3.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.GroupBoxObject)
        Me.Panel2.Controls.Add(Me.GroupBoxContactList)
        Me.Panel2.Controls.Add(Me.GroupBoxSystemsType)
        Me.Panel2.Controls.Add(Me.GroupBoxCard)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(938, 579)
        Me.Panel2.TabIndex = 9
        '
        'GroupBoxContactList
        '
        Me.GroupBoxContactList.AutoSize = True
        Me.GroupBoxContactList.Controls.Add(Me.FlowLayoutContact)
        Me.GroupBoxContactList.Controls.Add(Me.ButtonContactAdd)
        Me.GroupBoxContactList.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxContactList.Location = New System.Drawing.Point(0, 116)
        Me.GroupBoxContactList.Name = "GroupBoxContactList"
        Me.GroupBoxContactList.Size = New System.Drawing.Size(938, 94)
        Me.GroupBoxContactList.TabIndex = 5
        Me.GroupBoxContactList.TabStop = False
        Me.GroupBoxContactList.Text = "Contact List"
        '
        'FlowLayoutContact
        '
        Me.FlowLayoutContact.AutoSize = True
        Me.FlowLayoutContact.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutContact.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutContact.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutContact.Location = New System.Drawing.Point(3, 16)
        Me.FlowLayoutContact.MinimumSize = New System.Drawing.Size(0, 50)
        Me.FlowLayoutContact.Name = "FlowLayoutContact"
        Me.FlowLayoutContact.Size = New System.Drawing.Size(932, 50)
        Me.FlowLayoutContact.TabIndex = 4
        Me.FlowLayoutContact.WrapContents = False
        '
        'ButtonContactAdd
        '
        Me.ButtonContactAdd.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonContactAdd.Location = New System.Drawing.Point(3, 66)
        Me.ButtonContactAdd.MaximumSize = New System.Drawing.Size(120, 0)
        Me.ButtonContactAdd.MinimumSize = New System.Drawing.Size(0, 25)
        Me.ButtonContactAdd.Name = "ButtonContactAdd"
        Me.ButtonContactAdd.Size = New System.Drawing.Size(120, 25)
        Me.ButtonContactAdd.TabIndex = 6
        Me.ButtonContactAdd.Text = "Add"
        Me.ButtonContactAdd.UseVisualStyleBackColor = True
        '
        'CardView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 630)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.FlowLayoutPanel3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Name = "CardView"
        Me.Text = "va"
        Me.GroupBoxSystemsType.ResumeLayout(False)
        Me.GroupBoxSystemsType.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.GroupBoxCard.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBoxObject.ResumeLayout(False)
        Me.TableLayoutPanelObject.ResumeLayout(False)
        Me.TableLayoutPanelObject.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBoxContactList.ResumeLayout(False)
        Me.GroupBoxContactList.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents GroupBoxSystemsType As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents CheckBoxCardCDM As CheckBox
    Friend WithEvents CheckBoxCardPanic As CheckBox
    Friend WithEvents CheckBoxCardBurglary As CheckBox
    Friend WithEvents CheckBoxCardTSN As CheckBox
    Friend WithEvents CheckBoxCardBoSiNet As CheckBox
    Friend WithEvents ButtonCardViewApply As Button
    Friend WithEvents ButtonCardViewCancel As Button
    Friend WithEvents GroupBoxCard As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents RichTextBoxCardComment As RichTextBox
    Friend WithEvents LabelCardNumber As Label
    Friend WithEvents TextBoxCardNumber As TextBox
    Friend WithEvents ComboBoxCardTyp As ComboBox
    Friend WithEvents LabelCardType As Label
    Friend WithEvents GroupBoxObject As GroupBox
    Friend WithEvents TableLayoutPanelObject As TableLayoutPanel
    Friend WithEvents LabelSiteAddressZIP As Label
    Friend WithEvents TextBoxSiteAddressPLZ As TextBox
    Friend WithEvents TextBoxSiteAddressCountry As TextBox
    Friend WithEvents TextBoxSiteName As TextBox
    Friend WithEvents TextBoxSiteAddressCity As TextBox
    Friend WithEvents LabelSiteAddressCountry As Label
    Friend WithEvents LabelSiteName As Label
    Friend WithEvents LabelSiteAddressCity As Label
    Friend WithEvents LabelSiteAddressNumber As Label
    Friend WithEvents TextBoxSiteAddressNumber As TextBox
    Friend WithEvents TextBoxSiteAddressStreet As TextBox
    Friend WithEvents TextBoxSiteAddressAddition As TextBox
    Friend WithEvents LabelSiteAddressStreet As Label
    Friend WithEvents LabelSiteAddressAddition As Label
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Private WithEvents GroupBoxContactList As GroupBox
    Friend WithEvents ButtonContactAdd As Button
    Friend WithEvents FlowLayoutContact As FlowLayoutPanel
End Class
