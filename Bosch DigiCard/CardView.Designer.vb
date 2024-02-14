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
        Me.ButtonCardViewApply = New System.Windows.Forms.Button()
        Me.LabelCardNumber = New System.Windows.Forms.Label()
        Me.GroupBoxCard = New System.Windows.Forms.GroupBox()
        Me.ComboBoxCardTyp = New System.Windows.Forms.ComboBox()
        Me.LabelCardType = New System.Windows.Forms.Label()
        Me.TextBoxCardNumber = New System.Windows.Forms.TextBox()
        Me.ButtonCardViewCancel = New System.Windows.Forms.Button()
        Me.GroupBoxObject = New System.Windows.Forms.GroupBox()
        Me.TextBoxSiteAddressCountry = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressCity = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressPLZ = New System.Windows.Forms.TextBox()
        Me.TextBoxSiteAddressNumber = New System.Windows.Forms.TextBox()
        Me.LabelSiteAddressCountry = New System.Windows.Forms.Label()
        Me.TextBoxSiteAddressStreet = New System.Windows.Forms.TextBox()
        Me.LabelSiteAddressCity = New System.Windows.Forms.Label()
        Me.TextBoxSiteAddressAddition = New System.Windows.Forms.TextBox()
        Me.LabelSiteAddressZIP = New System.Windows.Forms.Label()
        Me.LabelSiteAddressNumber = New System.Windows.Forms.Label()
        Me.LabelSiteAddressStreet = New System.Windows.Forms.Label()
        Me.LabelSiteAddressAddition = New System.Windows.Forms.Label()
        Me.LabelSiteName = New System.Windows.Forms.Label()
        Me.TextBoxSiteName = New System.Windows.Forms.TextBox()
        Me.GroupBoxCard.SuspendLayout()
        Me.GroupBoxObject.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonCardViewApply
        '
        Me.ButtonCardViewApply.Location = New System.Drawing.Point(700, 415)
        Me.ButtonCardViewApply.Name = "ButtonCardViewApply"
        Me.ButtonCardViewApply.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCardViewApply.TabIndex = 0
        Me.ButtonCardViewApply.Text = "Apply"
        Me.ButtonCardViewApply.UseVisualStyleBackColor = True
        '
        'LabelCardNumber
        '
        Me.LabelCardNumber.AutoSize = True
        Me.LabelCardNumber.Location = New System.Drawing.Point(18, 35)
        Me.LabelCardNumber.Name = "LabelCardNumber"
        Me.LabelCardNumber.Size = New System.Drawing.Size(44, 13)
        Me.LabelCardNumber.TabIndex = 1
        Me.LabelCardNumber.Text = "Number"
        '
        'GroupBoxCard
        '
        Me.GroupBoxCard.Controls.Add(Me.ComboBoxCardTyp)
        Me.GroupBoxCard.Controls.Add(Me.LabelCardType)
        Me.GroupBoxCard.Controls.Add(Me.TextBoxCardNumber)
        Me.GroupBoxCard.Controls.Add(Me.LabelCardNumber)
        Me.GroupBoxCard.Location = New System.Drawing.Point(32, 34)
        Me.GroupBoxCard.Name = "GroupBoxCard"
        Me.GroupBoxCard.Size = New System.Drawing.Size(283, 130)
        Me.GroupBoxCard.TabIndex = 2
        Me.GroupBoxCard.TabStop = False
        Me.GroupBoxCard.Text = "Card"
        '
        'ComboBoxCardTyp
        '
        Me.ComboBoxCardTyp.FormattingEnabled = True
        Me.ComboBoxCardTyp.Items.AddRange(New Object() {"Police", "Fire"})
        Me.ComboBoxCardTyp.Location = New System.Drawing.Point(93, 64)
        Me.ComboBoxCardTyp.Name = "ComboBoxCardTyp"
        Me.ComboBoxCardTyp.Size = New System.Drawing.Size(163, 21)
        Me.ComboBoxCardTyp.TabIndex = 3
        '
        'LabelCardType
        '
        Me.LabelCardType.AutoSize = True
        Me.LabelCardType.Location = New System.Drawing.Point(18, 67)
        Me.LabelCardType.Name = "LabelCardType"
        Me.LabelCardType.Size = New System.Drawing.Size(31, 13)
        Me.LabelCardType.TabIndex = 1
        Me.LabelCardType.Text = "Type"
        '
        'TextBoxCardNumber
        '
        Me.TextBoxCardNumber.Location = New System.Drawing.Point(93, 32)
        Me.TextBoxCardNumber.Name = "TextBoxCardNumber"
        Me.TextBoxCardNumber.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxCardNumber.TabIndex = 2
        '
        'ButtonCardViewCancel
        '
        Me.ButtonCardViewCancel.Location = New System.Drawing.Point(598, 415)
        Me.ButtonCardViewCancel.Name = "ButtonCardViewCancel"
        Me.ButtonCardViewCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCardViewCancel.TabIndex = 0
        Me.ButtonCardViewCancel.Text = "Cancel"
        Me.ButtonCardViewCancel.UseVisualStyleBackColor = True
        '
        'GroupBoxObject
        '
        Me.GroupBoxObject.Controls.Add(Me.TextBoxSiteAddressCountry)
        Me.GroupBoxObject.Controls.Add(Me.TextBoxSiteAddressCity)
        Me.GroupBoxObject.Controls.Add(Me.TextBoxSiteAddressPLZ)
        Me.GroupBoxObject.Controls.Add(Me.TextBoxSiteAddressNumber)
        Me.GroupBoxObject.Controls.Add(Me.LabelSiteAddressCountry)
        Me.GroupBoxObject.Controls.Add(Me.TextBoxSiteAddressStreet)
        Me.GroupBoxObject.Controls.Add(Me.LabelSiteAddressCity)
        Me.GroupBoxObject.Controls.Add(Me.TextBoxSiteAddressAddition)
        Me.GroupBoxObject.Controls.Add(Me.LabelSiteAddressZIP)
        Me.GroupBoxObject.Controls.Add(Me.LabelSiteAddressNumber)
        Me.GroupBoxObject.Controls.Add(Me.LabelSiteAddressStreet)
        Me.GroupBoxObject.Controls.Add(Me.LabelSiteAddressAddition)
        Me.GroupBoxObject.Controls.Add(Me.LabelSiteName)
        Me.GroupBoxObject.Controls.Add(Me.TextBoxSiteName)
        Me.GroupBoxObject.Location = New System.Drawing.Point(32, 196)
        Me.GroupBoxObject.Name = "GroupBoxObject"
        Me.GroupBoxObject.Size = New System.Drawing.Size(556, 185)
        Me.GroupBoxObject.TabIndex = 3
        Me.GroupBoxObject.TabStop = False
        Me.GroupBoxObject.Text = "Object"
        '
        'TextBoxSiteAddressCountry
        '
        Me.TextBoxSiteAddressCountry.Location = New System.Drawing.Point(338, 140)
        Me.TextBoxSiteAddressCountry.Name = "TextBoxSiteAddressCountry"
        Me.TextBoxSiteAddressCountry.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressCountry.TabIndex = 2
        '
        'TextBoxSiteAddressCity
        '
        Me.TextBoxSiteAddressCity.Location = New System.Drawing.Point(338, 103)
        Me.TextBoxSiteAddressCity.Name = "TextBoxSiteAddressCity"
        Me.TextBoxSiteAddressCity.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressCity.TabIndex = 2
        '
        'TextBoxSiteAddressPLZ
        '
        Me.TextBoxSiteAddressPLZ.Location = New System.Drawing.Point(93, 140)
        Me.TextBoxSiteAddressPLZ.Name = "TextBoxSiteAddressPLZ"
        Me.TextBoxSiteAddressPLZ.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressPLZ.TabIndex = 2
        '
        'TextBoxSiteAddressNumber
        '
        Me.TextBoxSiteAddressNumber.Location = New System.Drawing.Point(338, 68)
        Me.TextBoxSiteAddressNumber.Name = "TextBoxSiteAddressNumber"
        Me.TextBoxSiteAddressNumber.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressNumber.TabIndex = 2
        '
        'LabelSiteAddressCountry
        '
        Me.LabelSiteAddressCountry.AutoSize = True
        Me.LabelSiteAddressCountry.Location = New System.Drawing.Point(279, 143)
        Me.LabelSiteAddressCountry.Name = "LabelSiteAddressCountry"
        Me.LabelSiteAddressCountry.Size = New System.Drawing.Size(43, 13)
        Me.LabelSiteAddressCountry.TabIndex = 1
        Me.LabelSiteAddressCountry.Text = "Country"
        '
        'TextBoxSiteAddressStreet
        '
        Me.TextBoxSiteAddressStreet.Location = New System.Drawing.Point(93, 68)
        Me.TextBoxSiteAddressStreet.Name = "TextBoxSiteAddressStreet"
        Me.TextBoxSiteAddressStreet.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressStreet.TabIndex = 2
        '
        'LabelSiteAddressCity
        '
        Me.LabelSiteAddressCity.AutoSize = True
        Me.LabelSiteAddressCity.Location = New System.Drawing.Point(279, 106)
        Me.LabelSiteAddressCity.Name = "LabelSiteAddressCity"
        Me.LabelSiteAddressCity.Size = New System.Drawing.Size(24, 13)
        Me.LabelSiteAddressCity.TabIndex = 1
        Me.LabelSiteAddressCity.Text = "City"
        '
        'TextBoxSiteAddressAddition
        '
        Me.TextBoxSiteAddressAddition.Location = New System.Drawing.Point(93, 103)
        Me.TextBoxSiteAddressAddition.Name = "TextBoxSiteAddressAddition"
        Me.TextBoxSiteAddressAddition.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteAddressAddition.TabIndex = 2
        '
        'LabelSiteAddressZIP
        '
        Me.LabelSiteAddressZIP.AutoSize = True
        Me.LabelSiteAddressZIP.Location = New System.Drawing.Point(18, 143)
        Me.LabelSiteAddressZIP.Name = "LabelSiteAddressZIP"
        Me.LabelSiteAddressZIP.Size = New System.Drawing.Size(24, 13)
        Me.LabelSiteAddressZIP.TabIndex = 1
        Me.LabelSiteAddressZIP.Text = "ZIP"
        '
        'LabelSiteAddressNumber
        '
        Me.LabelSiteAddressNumber.AutoSize = True
        Me.LabelSiteAddressNumber.Location = New System.Drawing.Point(279, 71)
        Me.LabelSiteAddressNumber.Name = "LabelSiteAddressNumber"
        Me.LabelSiteAddressNumber.Size = New System.Drawing.Size(44, 13)
        Me.LabelSiteAddressNumber.TabIndex = 1
        Me.LabelSiteAddressNumber.Text = "Number"
        '
        'LabelSiteAddressStreet
        '
        Me.LabelSiteAddressStreet.AutoSize = True
        Me.LabelSiteAddressStreet.Location = New System.Drawing.Point(18, 71)
        Me.LabelSiteAddressStreet.Name = "LabelSiteAddressStreet"
        Me.LabelSiteAddressStreet.Size = New System.Drawing.Size(35, 13)
        Me.LabelSiteAddressStreet.TabIndex = 1
        Me.LabelSiteAddressStreet.Text = "Street"
        '
        'LabelSiteAddressAddition
        '
        Me.LabelSiteAddressAddition.AutoSize = True
        Me.LabelSiteAddressAddition.Location = New System.Drawing.Point(18, 106)
        Me.LabelSiteAddressAddition.Name = "LabelSiteAddressAddition"
        Me.LabelSiteAddressAddition.Size = New System.Drawing.Size(45, 13)
        Me.LabelSiteAddressAddition.TabIndex = 1
        Me.LabelSiteAddressAddition.Text = "Addition"
        '
        'LabelSiteName
        '
        Me.LabelSiteName.AutoSize = True
        Me.LabelSiteName.Location = New System.Drawing.Point(18, 36)
        Me.LabelSiteName.Name = "LabelSiteName"
        Me.LabelSiteName.Size = New System.Drawing.Size(35, 13)
        Me.LabelSiteName.TabIndex = 1
        Me.LabelSiteName.Text = "Name"
        '
        'TextBoxSiteName
        '
        Me.TextBoxSiteName.Location = New System.Drawing.Point(93, 33)
        Me.TextBoxSiteName.Name = "TextBoxSiteName"
        Me.TextBoxSiteName.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxSiteName.TabIndex = 2
        '
        'CardView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 455)
        Me.Controls.Add(Me.GroupBoxObject)
        Me.Controls.Add(Me.GroupBoxCard)
        Me.Controls.Add(Me.ButtonCardViewCancel)
        Me.Controls.Add(Me.ButtonCardViewApply)
        Me.Name = "CardView"
        Me.Text = "CardView"
        Me.GroupBoxCard.ResumeLayout(False)
        Me.GroupBoxCard.PerformLayout()
        Me.GroupBoxObject.ResumeLayout(False)
        Me.GroupBoxObject.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonCardViewApply As Button
    Friend WithEvents LabelCardNumber As Label
    Friend WithEvents GroupBoxCard As GroupBox
    Friend WithEvents TextBoxCardNumber As TextBox
    Friend WithEvents LabelCardType As Label
    Friend WithEvents ComboBoxCardTyp As ComboBox
    Friend WithEvents ButtonCardViewCancel As Button
    Friend WithEvents GroupBoxObject As GroupBox
    Friend WithEvents LabelSiteName As Label
    Friend WithEvents TextBoxSiteName As TextBox
    Friend WithEvents TextBoxSiteAddressAddition As TextBox
    Friend WithEvents LabelSiteAddressAddition As Label
    Friend WithEvents TextBoxSiteAddressCountry As TextBox
    Friend WithEvents TextBoxSiteAddressCity As TextBox
    Friend WithEvents TextBoxSiteAddressPLZ As TextBox
    Friend WithEvents TextBoxSiteAddressNumber As TextBox
    Friend WithEvents LabelSiteAddressCountry As Label
    Friend WithEvents TextBoxSiteAddressStreet As TextBox
    Friend WithEvents LabelSiteAddressCity As Label
    Friend WithEvents LabelSiteAddressZIP As Label
    Friend WithEvents LabelSiteAddressNumber As Label
    Friend WithEvents LabelSiteAddressStreet As Label
End Class
