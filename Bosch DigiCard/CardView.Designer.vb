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
        Me.GroupBoxProject = New System.Windows.Forms.GroupBox()
        Me.TextBoxProjectAddressCountry = New System.Windows.Forms.TextBox()
        Me.TextBoxProjectAddressCity = New System.Windows.Forms.TextBox()
        Me.TextBoxProjectAddressPLZ = New System.Windows.Forms.TextBox()
        Me.TextBoxProjectAddressNumber = New System.Windows.Forms.TextBox()
        Me.LabelProjectAddressCountry = New System.Windows.Forms.Label()
        Me.TextBoxProjectAddressStreet = New System.Windows.Forms.TextBox()
        Me.LabelProjectAddressCity = New System.Windows.Forms.Label()
        Me.TextBoxProjectAddressSupplement = New System.Windows.Forms.TextBox()
        Me.LabelProjectAddressPLZ = New System.Windows.Forms.Label()
        Me.LabelProjectAddressNumber = New System.Windows.Forms.Label()
        Me.LabelProjectAddressStreet = New System.Windows.Forms.Label()
        Me.LabelProjectAddressSupplement = New System.Windows.Forms.Label()
        Me.LabelProjectName = New System.Windows.Forms.Label()
        Me.TextBoxProjectName = New System.Windows.Forms.TextBox()
        Me.GroupBoxCard.SuspendLayout()
        Me.GroupBoxProject.SuspendLayout()
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
        'GroupBoxProject
        '
        Me.GroupBoxProject.Controls.Add(Me.TextBoxProjectAddressCountry)
        Me.GroupBoxProject.Controls.Add(Me.TextBoxProjectAddressCity)
        Me.GroupBoxProject.Controls.Add(Me.TextBoxProjectAddressPLZ)
        Me.GroupBoxProject.Controls.Add(Me.TextBoxProjectAddressNumber)
        Me.GroupBoxProject.Controls.Add(Me.LabelProjectAddressCountry)
        Me.GroupBoxProject.Controls.Add(Me.TextBoxProjectAddressStreet)
        Me.GroupBoxProject.Controls.Add(Me.LabelProjectAddressCity)
        Me.GroupBoxProject.Controls.Add(Me.TextBoxProjectAddressSupplement)
        Me.GroupBoxProject.Controls.Add(Me.LabelProjectAddressPLZ)
        Me.GroupBoxProject.Controls.Add(Me.LabelProjectAddressNumber)
        Me.GroupBoxProject.Controls.Add(Me.LabelProjectAddressStreet)
        Me.GroupBoxProject.Controls.Add(Me.LabelProjectAddressSupplement)
        Me.GroupBoxProject.Controls.Add(Me.LabelProjectName)
        Me.GroupBoxProject.Controls.Add(Me.TextBoxProjectName)
        Me.GroupBoxProject.Location = New System.Drawing.Point(32, 196)
        Me.GroupBoxProject.Name = "GroupBoxProject"
        Me.GroupBoxProject.Size = New System.Drawing.Size(556, 185)
        Me.GroupBoxProject.TabIndex = 3
        Me.GroupBoxProject.TabStop = False
        Me.GroupBoxProject.Text = "Project"
        '
        'TextBoxProjectAddressCountry
        '
        Me.TextBoxProjectAddressCountry.Location = New System.Drawing.Point(338, 140)
        Me.TextBoxProjectAddressCountry.Name = "TextBoxProjectAddressCountry"
        Me.TextBoxProjectAddressCountry.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxProjectAddressCountry.TabIndex = 2
        '
        'TextBoxProjectAddressCity
        '
        Me.TextBoxProjectAddressCity.Location = New System.Drawing.Point(338, 103)
        Me.TextBoxProjectAddressCity.Name = "TextBoxProjectAddressCity"
        Me.TextBoxProjectAddressCity.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxProjectAddressCity.TabIndex = 2
        '
        'TextBoxProjectAddressPLZ
        '
        Me.TextBoxProjectAddressPLZ.Location = New System.Drawing.Point(93, 140)
        Me.TextBoxProjectAddressPLZ.Name = "TextBoxProjectAddressPLZ"
        Me.TextBoxProjectAddressPLZ.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxProjectAddressPLZ.TabIndex = 2
        '
        'TextBoxProjectAddressNumber
        '
        Me.TextBoxProjectAddressNumber.Location = New System.Drawing.Point(338, 68)
        Me.TextBoxProjectAddressNumber.Name = "TextBoxProjectAddressNumber"
        Me.TextBoxProjectAddressNumber.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxProjectAddressNumber.TabIndex = 2
        '
        'LabelProjectAddressCountry
        '
        Me.LabelProjectAddressCountry.AutoSize = True
        Me.LabelProjectAddressCountry.Location = New System.Drawing.Point(279, 143)
        Me.LabelProjectAddressCountry.Name = "LabelProjectAddressCountry"
        Me.LabelProjectAddressCountry.Size = New System.Drawing.Size(43, 13)
        Me.LabelProjectAddressCountry.TabIndex = 1
        Me.LabelProjectAddressCountry.Text = "Country"
        '
        'TextBoxProjectAddressStreet
        '
        Me.TextBoxProjectAddressStreet.Location = New System.Drawing.Point(93, 68)
        Me.TextBoxProjectAddressStreet.Name = "TextBoxProjectAddressStreet"
        Me.TextBoxProjectAddressStreet.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxProjectAddressStreet.TabIndex = 2
        '
        'LabelProjectAddressCity
        '
        Me.LabelProjectAddressCity.AutoSize = True
        Me.LabelProjectAddressCity.Location = New System.Drawing.Point(279, 106)
        Me.LabelProjectAddressCity.Name = "LabelProjectAddressCity"
        Me.LabelProjectAddressCity.Size = New System.Drawing.Size(24, 13)
        Me.LabelProjectAddressCity.TabIndex = 1
        Me.LabelProjectAddressCity.Text = "City"
        '
        'TextBoxProjectAddressSupplement
        '
        Me.TextBoxProjectAddressSupplement.Location = New System.Drawing.Point(93, 103)
        Me.TextBoxProjectAddressSupplement.Name = "TextBoxProjectAddressSupplement"
        Me.TextBoxProjectAddressSupplement.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxProjectAddressSupplement.TabIndex = 2
        '
        'LabelProjectAddressPLZ
        '
        Me.LabelProjectAddressPLZ.AutoSize = True
        Me.LabelProjectAddressPLZ.Location = New System.Drawing.Point(18, 143)
        Me.LabelProjectAddressPLZ.Name = "LabelProjectAddressPLZ"
        Me.LabelProjectAddressPLZ.Size = New System.Drawing.Size(27, 13)
        Me.LabelProjectAddressPLZ.TabIndex = 1
        Me.LabelProjectAddressPLZ.Text = "PLZ"
        '
        'LabelProjectAddressNumber
        '
        Me.LabelProjectAddressNumber.AutoSize = True
        Me.LabelProjectAddressNumber.Location = New System.Drawing.Point(279, 71)
        Me.LabelProjectAddressNumber.Name = "LabelProjectAddressNumber"
        Me.LabelProjectAddressNumber.Size = New System.Drawing.Size(44, 13)
        Me.LabelProjectAddressNumber.TabIndex = 1
        Me.LabelProjectAddressNumber.Text = "Number"
        '
        'LabelProjectAddressStreet
        '
        Me.LabelProjectAddressStreet.AutoSize = True
        Me.LabelProjectAddressStreet.Location = New System.Drawing.Point(18, 71)
        Me.LabelProjectAddressStreet.Name = "LabelProjectAddressStreet"
        Me.LabelProjectAddressStreet.Size = New System.Drawing.Size(35, 13)
        Me.LabelProjectAddressStreet.TabIndex = 1
        Me.LabelProjectAddressStreet.Text = "Street"
        '
        'LabelProjectAddressSupplement
        '
        Me.LabelProjectAddressSupplement.AutoSize = True
        Me.LabelProjectAddressSupplement.Location = New System.Drawing.Point(18, 106)
        Me.LabelProjectAddressSupplement.Name = "LabelProjectAddressSupplement"
        Me.LabelProjectAddressSupplement.Size = New System.Drawing.Size(45, 13)
        Me.LabelProjectAddressSupplement.TabIndex = 1
        Me.LabelProjectAddressSupplement.Text = "Addition"
        '
        'LabelProjectName
        '
        Me.LabelProjectName.AutoSize = True
        Me.LabelProjectName.Location = New System.Drawing.Point(18, 36)
        Me.LabelProjectName.Name = "LabelProjectName"
        Me.LabelProjectName.Size = New System.Drawing.Size(35, 13)
        Me.LabelProjectName.TabIndex = 1
        Me.LabelProjectName.Text = "Name"
        '
        'TextBoxProjectName
        '
        Me.TextBoxProjectName.Location = New System.Drawing.Point(93, 33)
        Me.TextBoxProjectName.Name = "TextBoxProjectName"
        Me.TextBoxProjectName.Size = New System.Drawing.Size(163, 20)
        Me.TextBoxProjectName.TabIndex = 2
        '
        'CardView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 455)
        Me.Controls.Add(Me.GroupBoxProject)
        Me.Controls.Add(Me.GroupBoxCard)
        Me.Controls.Add(Me.ButtonCardViewCancel)
        Me.Controls.Add(Me.ButtonCardViewApply)
        Me.Name = "CardView"
        Me.Text = "CardView"
        Me.GroupBoxCard.ResumeLayout(False)
        Me.GroupBoxCard.PerformLayout()
        Me.GroupBoxProject.ResumeLayout(False)
        Me.GroupBoxProject.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonCardViewApply As Button
    Friend WithEvents LabelCardNumber As Label
    Friend WithEvents GroupBoxCard As GroupBox
    Friend WithEvents TextBoxCardNumber As TextBox
    Friend WithEvents LabelCardType As Label
    Friend WithEvents ComboBoxCardTyp As ComboBox

    Private Sub CardView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Friend WithEvents ButtonCardViewCancel As Button
    Friend WithEvents GroupBoxProject As GroupBox
    Friend WithEvents LabelProjectName As Label
    Friend WithEvents TextBoxProjectName As TextBox
    Friend WithEvents TextBoxProjectAddressSupplement As TextBox
    Friend WithEvents LabelProjectAddressSupplement As Label
    Friend WithEvents TextBoxProjectAddressCountry As TextBox
    Friend WithEvents TextBoxProjectAddressCity As TextBox
    Friend WithEvents TextBoxProjectAddressPLZ As TextBox
    Friend WithEvents TextBoxProjectAddressNumber As TextBox
    Friend WithEvents LabelProjectAddressCountry As Label
    Friend WithEvents TextBoxProjectAddressStreet As TextBox
    Friend WithEvents LabelProjectAddressCity As Label
    Friend WithEvents LabelProjectAddressPLZ As Label
    Friend WithEvents LabelProjectAddressNumber As Label
    Friend WithEvents LabelProjectAddressStreet As Label
End Class
