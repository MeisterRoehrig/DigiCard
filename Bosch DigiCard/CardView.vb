Imports System.Windows.Forms

Public Class CardView
    Private cardID As Integer
    Private conn As ADODB.Connection
    Private rs As ADODB.Recordset

    Public Sub New(_cardID As Integer, _conn As ADODB.Connection)
        ' This call is required by the designer.
        InitializeComponent()
        cardID = _cardID
        conn = _conn
    End Sub

    Public Function SafeGetString(ByVal field As ADODB.Field) As String
        If field.Value Is Nothing OrElse IsDBNull(field.Value) Then
            Return String.Empty
        Else
            Return field.Value.ToString()
        End If
    End Function

    Private Sub CardView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If rs IsNot Nothing AndAlso rs.State = ADODB.ObjectStateEnum.adStateOpen Then
            rs.Close()
        End If
    End Sub

    Private CardContactsWindowOpenState As New List(Of Integer)


    Private Sub LoadCardData(cardID As Integer)
        ' Assuming you have a method to get a database connection
        Dim query As String = $"SELECT * FROM Card INNER JOIN Site ON Card.SiteID=Site.SiteID WHERE CardID = {cardID}"

        Try
            If rs Is Nothing Then
                rs = New ADODB.Recordset
            End If
            rs.Open(query, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

            If Not rs.EOF Then
                ' Populate your form controls here based on the recordset's fields
                Me.Text = SafeGetString(rs.Fields("CardNumber")) + " - " + SafeGetString(rs.Fields("SiteName"))
                RichTextBoxCardComment.Text = SafeGetString(rs.Fields("CardComment"))
                TextBoxCardNumber.Text = SafeGetString(rs.Fields("CardNumber"))
                ComboBoxCardTyp.SelectedItem = SafeGetString(rs.Fields("CardType"))
                TextBoxSiteName.Text = SafeGetString(rs.Fields("SiteName"))
                TextBoxSiteAddressStreet.Text = SafeGetString(rs.Fields("SiteAddressStreet"))
                TextBoxSiteAddressAddition.Text = SafeGetString(rs.Fields("SiteAddressAddition"))
                TextBoxSiteAddressNumber.Text = SafeGetString(rs.Fields("SiteAddressNumber"))
                TextBoxSiteAddressPLZ.Text = SafeGetString(rs.Fields("SiteAddressZIP"))
                TextBoxSiteAddressCity.Text = SafeGetString(rs.Fields("SiteAddressCity"))
                TextBoxSiteAddressCountry.Text = SafeGetString(rs.Fields("SiteAddressCountry"))
                CheckBoxCardCDM.CheckState = If(SafeGetString(rs.Fields("CardPanic")) = "True", CheckState.Checked, CheckState.Unchecked)
                CheckBoxCardPanic.CheckState = If(SafeGetString(rs.Fields("CardPanic")) = "True", CheckState.Checked, CheckState.Unchecked)
                CheckBoxCardBurglary.CheckState = If(SafeGetString(rs.Fields("CardBurglary")) = "True", CheckState.Checked, CheckState.Unchecked)
                CheckBoxCardTSN.CheckState = If(SafeGetString(rs.Fields("CardTSN")) = "True", CheckState.Checked, CheckState.Unchecked)
                CheckBoxCardBoSiNet.CheckState = If(SafeGetString(rs.Fields("CardBoSiNet")) = "True", CheckState.Checked, CheckState.Unchecked)

            Else
                Debug.WriteLine("No data found for the specified card.")
            End If
        Catch ex As Exception
            Debug.WriteLine($"An error occurred while fetching card data: {ex.Message}")
            MessageBox.Show($"An error occurred while fetching card data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' New code to load contacts:
        Dim contactQuery As String = $"SELECT Person.* FROM CardContactMapping INNER JOIN Person ON CardContactMapping.PersonID = Person.PersonID WHERE CardContactMapping.CardID = {cardID} ORDER BY CardContactMapping.CardContactMappingIndex ASC"

        Try
            Dim contactRs As New ADODB.Recordset
            contactRs.Open(contactQuery, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

            CardContacts.Clear()
            CardContactsWindowOpenState.Clear()

            While Not contactRs.EOF
                CardContacts.Add(New Contact(SafeGetInt(contactRs.Fields("PersonID")),
                                             GlobalUtilities.SafeGetDate(contactRs.Fields("PersonCreated")),
                                             GlobalUtilities.SafeGetDate(contactRs.Fields("PersonLastModified")),
                                             SafeGetString(contactRs.Fields("PersonGender")),
                                             SafeGetString(contactRs.Fields("PersonFirstname")),
                                             SafeGetString(contactRs.Fields("PersonSurname")),
                                              SafeGetString(contactRs.Fields("PersonPhone")),
                                              SafeGetString(contactRs.Fields("PersonPhone2")),
                                              SafeGetString(contactRs.Fields("PersonMail"))))

                CardContactsWindowOpenState.Add(SafeGetInt(contactRs.Fields("PersonID")))

                contactRs.MoveNext()
            End While

            'Write alle elements of the list to the debug console
            For Each contact In CardContacts
                Debug.WriteLine($"Contact: {contact.PersonID} {contact.PersonFirstname} {contact.PersonSurname} {contact.PersonPhone} {contact.PersonMail}")
            Next

            contactRs.Close()
        Catch ex As Exception
            Debug.WriteLine($"An error occurred while fetching contact data: {ex.Message}")
            MessageBox.Show($"An error occurred while fetching contact data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Sub ButtonCardViewApply_Click(sender As Object, e As EventArgs) Handles ButtonCardViewApply.Click
        ' Iterate over each contact in CardContacts
        For Each contact In CardContacts
            If contact.PersonID > 0 Then
                ' This is an existing contact, update their details
                Debug.WriteLine($"Updating contact {contact.PersonID}")
                Debug.WriteLine($"Updating contact {GlobalUtilities.GetFormattedCurrentTime()}")
                Dim updatePersonQuery As String = $"UPDATE Person SET " &
                                          $"PersonLastModified = '{GlobalUtilities.GetFormattedCurrentTime()}', " &
                                          $"PersonFirstname = '{SafeSQL(contact.PersonFirstname)}', " &
                                          $"PersonSurname = '{SafeSQL(contact.PersonSurname)}', " &
                                          $"PersonPhone = '{SafeSQL(contact.PersonPhone)}', " &
                                          $"PersonMail = '{SafeSQL(contact.PersonMail)}' " &
                                          $"WHERE PersonID = {contact.PersonID}"
                conn.Execute(updatePersonQuery)
            Else
                ' This is a new contact, insert them into the Person table
                Debug.WriteLine($"Adding new contact {contact.PersonID}")
                Dim insertPersonQuery As String = $"INSERT INTO Person (PersonCreated, PersonLastModified, PersonFirstname, PersonSurname, PersonPhone, PersonMail) " &
                                          $"VALUES ('{GlobalUtilities.GetFormattedCurrentTime()}', '{GlobalUtilities.GetFormattedCurrentTime()}', '{SafeSQL(contact.PersonFirstname)}', '{SafeSQL(contact.PersonSurname)}', '{SafeSQL(contact.PersonPhone)}', '{SafeSQL(contact.PersonMail)}');"
                conn.Execute(insertPersonQuery)

                ' Retrieve the new PersonID using @@IDENTITY
                ' It's important to immediately retrieve @@IDENTITY in the same session to avoid issues with concurrent inserts
                Dim rsNewPerson As ADODB.Recordset = conn.Execute("SELECT @@IDENTITY AS NewID;")
                If Not rsNewPerson.EOF Then
                    contact.PersonID = CInt(rsNewPerson.Fields("NewID").Value)
                    Debug.WriteLine($"New contact added with PersonID {contact.PersonID}")
                End If
            End If
        Next

        ' First, handle new and existing contacts
        Dim currentIndex As Integer = 0
        For Each contact In CardContacts
            ' Update the CardContactMappingIndex for all contacts
            If contact.PersonID > 0 Then
                ' Check if mapping exists and update or insert accordingly
                Dim checkMappingQuery As String = $"SELECT COUNT(*) AS MappingCount FROM CardContactMapping WHERE CardID = {Me.cardID} AND PersonID = {contact.PersonID}"
                Dim rsCheck As ADODB.Recordset = conn.Execute(checkMappingQuery)
                If CInt(rsCheck.Fields("MappingCount").Value) = 0 Then
                    ' Insert new mapping
                    Dim insertMappingQuery As String = $"INSERT INTO CardContactMapping (CardContactMappingCreated, CardContactMappingLastModified, CardID, PersonID, CardContactMappingIndex) VALUES ('{GlobalUtilities.GetFormattedCurrentTime()}', '{GlobalUtilities.GetFormattedCurrentTime()}', {Me.cardID}, {contact.PersonID}, {currentIndex})"
                    Debug.WriteLine(insertMappingQuery)
                    conn.Execute(insertMappingQuery)
                Else
                    ' Update existing mapping index

                    Dim updateMappingQuery As String = $"UPDATE CardContactMapping SET CardContactMappingLastModified = '{GlobalUtilities.GetFormattedCurrentTime()}', CardContactMappingIndex = {currentIndex} WHERE CardID = {Me.cardID} AND PersonID = {contact.PersonID}"
                    Debug.WriteLine(updateMappingQuery)
                    conn.Execute(updateMappingQuery)

                End If
            End If
            currentIndex += 1
        Next

        ' Assume CardContacts is a list of Contact objects and you have a way to get their PersonID
        Dim currentContactIDs As List(Of Integer) = CardContacts.Select(Function(c) c.PersonID).ToList()

        ' Find PersonIDs to remove: those in CardContactsWindowOpenState but not in currentContactIDs
        Dim personIDsToRemove As List(Of Integer) = CardContactsWindowOpenState.Except(currentContactIDs).ToList()

        ' Remove mappings for these PersonIDs
        For Each personID In personIDsToRemove
            Debug.WriteLine($"Removing mapping for PersonID {personID}...")
            Dim deleteMappingQuery As String = $"DELETE FROM CardContactMapping WHERE CardID = {Me.cardID} AND PersonID = {personID}"
            conn.Execute(deleteMappingQuery)
        Next

        ' Construct the UPDATE SQL statement
        Dim updateQuery As String = $"UPDATE Card INNER JOIN Site ON Card.SiteID = Site.SiteID SET " &
                                $"CardNumber = '{SafeSQL(TextBoxCardNumber.Text)}', " &
                                $"CardComment = '{SafeSQL(RichTextBoxCardComment.Text)}', " &
                                $"CardLastModified = '{GlobalUtilities.GetFormattedCurrentTime()}', " &
                                $"SiteName = '{SafeSQL(TextBoxSiteName.Text)}', " &
                                $"SiteAddressStreet = '{SafeSQL(TextBoxSiteAddressStreet.Text)}', " &
                                $"SiteAddressAddition = '{SafeSQL(TextBoxSiteAddressAddition.Text)}', " &
                                $"SiteAddressNumber = '{SafeSQL(TextBoxSiteAddressNumber.Text)}', " &
                                $"SiteAddressZIP = '{SafeSQL(TextBoxSiteAddressPLZ.Text)}', " &
                                $"SiteAddressCity = '{SafeSQL(TextBoxSiteAddressCity.Text)}', " &
                                $"SiteAddressCountry = '{SafeSQL(TextBoxSiteAddressCountry.Text)}', " &
                                $"CardType = '{SafeSQL(ComboBoxCardTyp.SelectedItem)}', " &
                                $"CardCDM = '{SafeSQL(CheckBoxCardCDM.CheckState)}', " &
                                $"CardPanic = '{SafeSQL(If(CheckBoxCardPanic.Checked, 1, 0))}', " &
                                $"CardBurglary = '{SafeSQL(If(CheckBoxCardBurglary.Checked, 1, 0))}', " &
                                $"CardTSN = '{SafeSQL(If(CheckBoxCardTSN.Checked, 1, 0))}', " &
                                $"CardBoSiNet = '{SafeSQL(If(CheckBoxCardBoSiNet.Checked, 1, 0))}' " &
                                $"WHERE CardID = {Me.cardID}"
        Try
            ' Execute the update query
            conn.Execute(updateQuery)
            Debug.WriteLine($"Changes to {cardID} saved successfully")
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Failed to save changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function SafeSQL(ByVal value As String) As String
        If value Is Nothing Then
            Return ""
        Else
            Return value.Replace("'", "''")
        End If
    End Function

    Private Function SafeGetString(ByVal field As Object) As String
        If IsDBNull(field) Then Return String.Empty
        Return TryCast(field, String) ' This will return Nothing if the cast fails, which would be the case if field is not a string
    End Function

    Private Function SafeGetInt(ByVal field As ADODB.Field) As Integer
        If field IsNot Nothing AndAlso Not IsDBNull(field.Value) Then
            Return Convert.ToInt32(field.Value)
        Else
            Return 0
        End If
    End Function





    Private CardContacts As New List(Of Contact)

    Private Sub ContactLayoutUpdate()
        FlowLayoutContact.SuspendLayout()
        FlowLayoutContact.Controls.Clear()

        Dim contactIndex As Integer = 1
        For Each contact In CardContacts
            Dim contactTable As New BorderedTableLayoutPanel With {
            .ColumnCount = 9, ' Adjusting for specified controls
            .RowCount = 2,
            .AutoSize = True,
            .AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink,
            .Padding = New Padding(5),
            .Dock = DockStyle.Top,
            .Anchor = AnchorStyles.Left Or AnchorStyles.Right,
            .Margin = New Padding(5)
        }

            ' Configure columns: new for label and buttons, existing adjusted
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' New: Position label
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' New: Move buttons
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 11.0F)) ' Existing: Label
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22.0F)) ' Existing: TextBox
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 11.0F)) ' Existing: Label
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22.0F)) ' Existing: TextBox
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 11.0F)) ' Existing: Label
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22.0F)) ' Existing: TextBox
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' Existing: Delete Button

            ' Index label spanning two rows
            Dim positionLabel As New Label With {
            .Text = contactIndex.ToString(),
            .AutoSize = True,
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleCenter
        }
            contactTable.Controls.Add(positionLabel, 0, 0)
            contactTable.SetRowSpan(positionLabel, 2)


            ' Up and Down Buttons
            Dim moveUpButton As New Button With {.Text = "↑", .AutoSize = True}
            Dim moveDownButton As New Button With {.Text = "↓", .AutoSize = True}
            AddHandler moveUpButton.Click, Sub(sender, e) MoveContactUp(contact)
            AddHandler moveDownButton.Click, Sub(sender, e) MoveContactDown(contact)
            contactTable.Controls.Add(moveUpButton, 1, 0)
            contactTable.Controls.Add(moveDownButton, 1, 1)
            moveUpButton.Width = contactTable.GetColumnWidths(1) ' Assuming column 1 is for buttons
            moveDownButton.Width = moveUpButton.Width

            ' Adding labels and textboxes for contact details as specified
            Dim labelsAndControls As (String, String)() = {
            ("Gender", contact.PersonGender),
            ("First Name", contact.PersonFirstname),
            ("Surname", contact.PersonSurname),
            ("Phone 1", contact.PersonPhone),
            ("Phone 2", contact.PersonPhone2),
            ("Email", contact.PersonMail)
        }

            Dim column As Integer = 2 ' Starting column for the first label-textbox pair
            For Each item In labelsAndControls
                Dim label As New Label With {.Text = $"{item.Item1}:", .AutoSize = True, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleRight}
                Dim textBox As New TextBox With {.Text = item.Item2, .Dock = DockStyle.Fill}
                ' Determine which row based on the type of data
                Dim row As Integer = If(item.Item1 = "Gender" OrElse item.Item1.StartsWith("First") OrElse item.Item1.StartsWith("Surname"), 0, 1)

                ' Add label and textbox to the table
                contactTable.Controls.Add(label, column, row)
                contactTable.Controls.Add(textBox, column + 1, row)
                column += 2 ' Increment column for the next label-textbox pair, skipping one for the textbox

                ' Reset column index after surname for the first line
                If item.Item1.StartsWith("Surname") Then column = 2
            Next

            ' Delete button spanning two rows
            Dim deleteButton As New Button With {.Text = "Delete", .AutoSize = True}
            AddHandler deleteButton.Click, Sub(sender, e) DeleteContact(contact)
            contactTable.Controls.Add(deleteButton, 8, 0)

            FlowLayoutContact.Controls.Add(contactTable)
            contactIndex += 1
        Next

        FlowLayoutContact.ResumeLayout(True)
    End Sub


    'Private Sub ContactLayoutUpdate()
    '    FlowLayoutContact.SuspendLayout() ' Suspend layout logic
    '    FlowLayoutContact.Controls.Clear() ' Clear existing controls

    '    Dim contactIndex As Integer = 1 ' Initialize contact index for displaying position
    '    For Each contact In CardContacts
    '        Dim contactTable As New BorderedTableLayoutPanel With {
    '        .ColumnCount = 7, ' Adjusted for position label and move buttons
    '        .RowCount = 2,
    '        .AutoSize = True,
    '        .AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink,
    '        .Padding = New Padding(5),
    '        .Dock = DockStyle.Top,
    '        .Anchor = AnchorStyles.Left Or AnchorStyles.Right,
    '        .Margin = New Padding(5)
    '        }

    '        ' Configure columns: new for label and buttons, existing adjusted
    '        contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' New: Position label
    '        contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' New: Move buttons
    '        contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 10.0F)) ' Existing: Label
    '        contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F)) ' Existing: TextBox
    '        contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 10.0F)) ' Existing: Label
    '        contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F)) ' Existing: TextBox
    '        contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' Existing: Delete Button

    '        ' Position label
    '        Dim positionLabel As New Label With {
    '        .Text = contactIndex.ToString(),
    '        .AutoSize = True,
    '        .Anchor = AnchorStyles.Left
    '    }
    '        contactTable.Controls.Add(positionLabel, 0, 0)
    '        contactTable.SetRowSpan(positionLabel, 2) ' Span two rows

    '        ' Move up and down buttons
    '        Dim moveUpButton As New Button With {.Text = "↑", .AutoSize = True}
    '        Dim moveDownButton As New Button With {.Text = "↓", .AutoSize = True}
    '        AddHandler moveUpButton.Click, Sub(sender, e) MoveContactUp(contact)
    '        AddHandler moveDownButton.Click, Sub(sender, e) MoveContactDown(contact)
    '        contactTable.Controls.Add(moveUpButton, 1, 0)
    '        contactTable.Controls.Add(moveDownButton, 1, 1)
    '        moveUpButton.Width = contactTable.GetColumnWidths(1) ' Assuming column 1 is for buttons
    '        moveDownButton.Width = moveUpButton.Width

    '        ' Add labels and textboxes for contact details, adjusting column indices
    '        Dim labels As String() = {"First Name", "Surname", "Phone", "Email"}
    '        Dim values As String() = {contact.PersonFirstname, contact.PersonSurname, contact.PersonPhone, contact.PersonMail}
    '        For i As Integer = 0 To labels.Length - 1
    '            Dim label As New Label With {.Text = labels(i), .Anchor = AnchorStyles.Right, .AutoSize = True}
    '            Dim textBox As New TextBox With {.Text = values(i), .Anchor = AnchorStyles.Left Or AnchorStyles.Right, .AutoSize = True}
    '            textBox.Tag = New With {Key .Contact = contact, Key .PropertyIndex = i}
    '            AddHandler textBox.TextChanged, AddressOf UpdateContact
    '            Dim row As Integer = i \ 2 ' Determine row based on index
    '            Dim col As Integer = (i Mod 2) * 2 + 2 ' Adjust column index to account for new columns
    '            contactTable.Controls.Add(label, col, row)
    '            contactTable.Controls.Add(textBox, col + 1, row)
    '        Next

    '        ' Delete button, adjusting column index
    '        Dim deleteButton As New Button With {.Text = "Delete", .AutoSize = True}
    '        AddHandler deleteButton.Click, Sub(sender, e) DeleteContact(contact)
    '        contactTable.Controls.Add(deleteButton, 6, 0)
    '        contactTable.SetRowSpan(deleteButton, 2) ' Span two rows

    '        FlowLayoutContact.Controls.Add(contactTable)
    '        contactIndex += 1 ' Increment for the next contact's position label
    '    Next

    '    FlowLayoutContact.ResumeLayout(True) ' Resume layout logic and optionally perform layout
    'End Sub

    'Private Sub UpdateContact(sender As Object, e As EventArgs)
    '    Dim textBox As TextBox = CType(sender, TextBox)
    '    Dim contactInfo = CType(textBox.Tag, Object) ' Assuming you used an anonymous type; adjust if using a Tuple or custom class
    '    Dim contact As Contact = contactInfo.Contact
    '    Dim propertyIndex As Integer = contactInfo.PropertyIndex

    '    Select Case propertyIndex
    '        Case 0
    '            contact.PersonFirstname = textBox.Text
    '        Case 1
    '            contact.PersonSurname = textBox.Text
    '        Case 2
    '            contact.PersonPhone = textBox.Text
    '        Case 3
    '            contact.PersonMail = textBox.Text
    '    End Select
    'End Sub

    Private Sub UpdateContact(sender As Object, e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        Dim contactInfo = CType(textBox.Tag, Object) ' Adjusted for direct use of the anonymous type
        Dim contact As Contact = contactInfo.Contact
        Dim propertyIndex As Integer = contactInfo.PropertyIndex

        ' Updated to match the new properties in the labels array
        Select Case propertyIndex
            Case 0
                contact.PersonGender = textBox.Text
            Case 1
                contact.PersonFirstname = textBox.Text
            Case 2
                contact.PersonSurname = textBox.Text
            Case 3
                contact.PersonPhone = textBox.Text
            Case 4
                contact.PersonPhone2 = textBox.Text
            Case 5
                contact.PersonMail = textBox.Text
        End Select
    End Sub

    Private Sub MoveContactUp(contact As Contact)
        Dim index As Integer = CardContacts.IndexOf(contact)
        If index > 0 Then
            CardContacts.RemoveAt(index)
            CardContacts.Insert(index - 1, contact)
            ContactLayoutUpdate()
        End If
    End Sub

    Private Sub MoveContactDown(contact As Contact)
        Dim index As Integer = CardContacts.IndexOf(contact)
        If index < CardContacts.Count - 1 Then
            CardContacts.RemoveAt(index)
            CardContacts.Insert(index + 1, contact)
            ContactLayoutUpdate()
        End If
    End Sub

    Private Sub DeleteContact(contact As Contact)
        CardContacts.Remove(contact)
        ContactLayoutUpdate()
    End Sub

    Private Sub ButtonAddContact_Click(sender As Object, e As EventArgs) Handles ButtonContactAdd.Click
        CardContacts.Add(New Contact(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
        ContactLayoutUpdate()
    End Sub

    Private Sub CardView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCardData(cardID)
        ContactLayoutUpdate()
    End Sub

    Private Sub ButtonCardViewCancel_Click(sender As Object, e As EventArgs) Handles ButtonCardViewCancel.Click
        If rs IsNot Nothing AndAlso rs.State = ADODB.ObjectStateEnum.adStateOpen Then
            rs.Close()
        End If
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class

Public Class Contact
    Public Property PersonID As Integer
    Public Property PersonCreated As DateTime
    Public Property PersonLastModified As DateTime
    Public Property PersonGender As String
    Public Property PersonSurname As String
    Public Property PersonFirstname As String
    Public Property PersonPhone As String
    Public Property PersonPhone2 As String
    Public Property PersonMail As String

    Public Sub New(personID As Integer, created As DateTime, lastModified As DateTime, gender As String, firstName As String, surname As String, phone As String, phone2 As String, mail As String)
        Me.PersonID = personID
        Me.PersonCreated = created
        Me.PersonLastModified = lastModified
        Me.PersonGender = gender
        Me.PersonFirstname = firstName
        Me.PersonSurname = surname
        Me.PersonPhone = phone
        Me.PersonPhone2 = phone2
        Me.PersonMail = mail
    End Sub
End Class

Public Class BorderedTableLayoutPanel
    Inherits TableLayoutPanel

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Draw a border around the table
        Dim pen As New Pen(Color.LightGray, 1) ' Customize color and thickness
        e.Graphics.DrawRectangle(pen, 0, 0, Me.Width - 1, Me.Height - 1)
    End Sub
End Class

Module GlobalUtilities

    ' Retrieves a DateTime object from a database field, safely handling DBNull values.
    ' Returns a default value if the date is not initialized or is DBNull.
    Public Function SafeGetDate(ByVal field As Object) As DateTime
        If IsDBNull(field) Then Return New DateTime(1900, 1, 1) ' Returning a default, non-minimum date

        Dim dateValue As DateTime
        If DateTime.TryParse(Convert.ToString(field), dateValue) Then
            Return dateValue
        Else
            Return New DateTime(1900, 1, 1) ' Return a default date
        End If
    End Function

    ' Formats a DateTime object into a string suitable for SQL queries.
    ' Adjust the format string as needed based on your database and locale requirements.
    Public Function FormatDateForSql(ByVal dateTime As DateTime) As String
        ' Format date as dd/MM/yyyy HH:mm:ss for compatibility with your database
        Return dateTime.ToString("dd/MM/yyyy HH:mm:ss")
    End Function

    ' Attempts to create a DateTime object from a string, based on an expected format.
    Public Function CreateDateFromString(ByVal dateString As String) As DateTime
        Dim result As DateTime
        ' Try parsing the date string using the expected format.
        If DateTime.TryParseExact(dateString, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, result) Then
            Return result
        Else
            ' Return a default date if parsing fails.
            Return New DateTime(1900, 1, 1)
        End If
    End Function

    ' Returns the current time, standardized across the application.
    ' This method centralizes the decision of using local time vs. UTC.
    Public Function GetCurrentTime() As DateTime
        ' Example: Returning UTC time. Adjust as necessary for your application.
        Return DateTime.UtcNow
    End Function

    ' Returns a formatted string of the current time, using the application's standard date and time format.
    Public Function GetFormattedCurrentTime() As String
        ' Utilizes FormatDateForSql to ensure consistent formatting.
        Return FormatDateForSql(DateTime.UtcNow)
    End Function

End Module