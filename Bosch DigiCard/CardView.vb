Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports System.Globalization
Imports ADODB


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
    Private ClientID As Integer

    Private Sub SetFormIconBasedOnCardType(cardType As String)
        Select Case cardType
            Case "Police"
                Me.Icon = My.Resources.IconPolice
            Case "Fire"
                Me.Icon = My.Resources.IconFire
                ' Add more cases as needed for different card types
            Case Else
                Me.Icon = My.Resources.BoschDigiCard ' A default icon if card type doesn't match
        End Select
    End Sub





    Private Sub LoadCardData(cardID As Integer)
        If cardID <= 0 Then
            Debug.WriteLine("New card being created. No data to load.")
            Return
        End If

        Dim query As String = $"SELECT Card.*, Site.*, Client.ClientID, Client.ClientName, Client.ClientAddressStreet, Client.ClientAddressSupplement, Client.ClientAddressNumber, Client.ClientAddressZIP, Client.ClientAddressCity, Client.ClientAddressCountry " &
                      $"FROM ((Card " &
                      $"INNER JOIN Site ON Card.SiteID = Site.SiteID) " &
                      $"INNER JOIN Client ON Site.ClientID = Client.ClientID) " &
                      $"WHERE Card.CardID = {cardID}"

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
                SetFormIconBasedOnCardType(SafeGetString(rs.Fields("CardType")))
                TextBoxSiteName.Text = SafeGetString(rs.Fields("SiteName"))
                TextBoxSiteAddressStreet.Text = SafeGetString(rs.Fields("SiteAddressStreet"))
                TextBoxSiteAddressAddition.Text = SafeGetString(rs.Fields("SiteAddressAddition"))
                TextBoxSiteAddressNumber.Text = SafeGetString(rs.Fields("SiteAddressNumber"))
                TextBoxSiteAddressPLZ.Text = SafeGetString(rs.Fields("SiteAddressZIP"))
                TextBoxSiteAddressCity.Text = SafeGetString(rs.Fields("SiteAddressCity"))
                TextBoxSiteAddressCountry.Text = SafeGetString(rs.Fields("SiteAddressCountry"))
                TextBoxLat.Text = SafeGetString(rs.Fields("SiteAddressLat"))
                TextBoxLong.Text = SafeGetString(rs.Fields("SiteAddressLong"))
                CheckBoxCardCDM.CheckState = If(SafeGetString(rs.Fields("CardPanic")) = "True", CheckState.Checked, CheckState.Unchecked)
                CheckBoxCardPanic.CheckState = If(SafeGetString(rs.Fields("CardPanic")) = "True", CheckState.Checked, CheckState.Unchecked)
                CheckBoxCardBurglary.CheckState = If(SafeGetString(rs.Fields("CardBurglary")) = "True", CheckState.Checked, CheckState.Unchecked)
                CheckBoxCardTSN.CheckState = If(SafeGetString(rs.Fields("CardTSN")) = "True", CheckState.Checked, CheckState.Unchecked)
                CheckBoxCardBoSiNet.CheckState = If(SafeGetString(rs.Fields("CardBoSiNet")) = "True", CheckState.Checked, CheckState.Unchecked)
                ToolStripStatusLabelCardCreated.Text = "Created: " + SafeGetString(rs.Fields("CardCreated"))
                ToolStripStatusLabelCardLastModified.Text = "Last Modified: " + SafeGetString(rs.Fields("CardLastModified"))
                TextBoxClientName.Text = SafeGetString(rs.Fields("ClientName"))
                TextBoxClientAddressStreet.Text = SafeGetString(rs.Fields("ClientAddressStreet"))
                TextBoxClientAddressSupplement.Text = SafeGetString(rs.Fields("ClientAddressSupplement"))
                TextBoxClientAddressNumber.Text = SafeGetString(rs.Fields("ClientAddressNumber"))
                TextBoxClientAddressZIP.Text = SafeGetString(rs.Fields("ClientAddressZIP"))
                TextBoxClientAddressCity.Text = SafeGetString(rs.Fields("ClientAddressCity"))
                TextBoxClientAddressCountry.Text = SafeGetString(rs.Fields("ClientAddressCountry"))
                ClientID = SafeGetInt(rs.Fields("Site.ClientID"))
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

    Public Function InitializeCard() As Tuple(Of Integer, Integer)
        Dim rsNewCard As New ADODB.Recordset
        Dim cardID As Integer = 0
        Dim clientID As Integer = 0
        Dim currentTime As String = GlobalUtilities.GetFormattedCurrentTime()

        ' Begin transaction
        conn.BeginTrans()

        Try
            ' 1. Insert new Client and retrieve ClientID
            Dim insertClientSql As String = $"INSERT INTO Client (ClientCreated, ClientLastModified) VALUES ('{currentTime}', '{currentTime}')"
            conn.Execute(insertClientSql)

            Dim getClientIDSql As String = "SELECT @@IDENTITY AS NewID"
            rsNewCard.Open(getClientIDSql, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            clientID = CInt(rsNewCard.Fields("NewID").Value)
            rsNewCard.Close()

            ' 2. Insert new Site using the new ClientID and retrieve SiteID
            Dim insertSiteSql As String = $"INSERT INTO Site (ClientID, SiteCreated, SiteLastModified) VALUES ({clientID}, '{currentTime}', '{currentTime}')"
            conn.Execute(insertSiteSql)

            rsNewCard.Open(getClientIDSql, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            Dim siteID As Integer = CInt(rsNewCard.Fields("NewID").Value)
            rsNewCard.Close()

            ' 3. Insert new Card with the new SiteID and retrieve CardID
            Dim insertCardSql As String = $"INSERT INTO Card (SiteID, CardCreated, CardLastModified) VALUES ({siteID}, '{currentTime}', '{currentTime}')"
            conn.Execute(insertCardSql)

            rsNewCard.Open(getClientIDSql, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            cardID = CInt(rsNewCard.Fields("NewID").Value)
            rsNewCard.Close()

            ' Commit transaction
            conn.CommitTrans()

        Catch ex As Exception
            ' Rollback transaction on error
            Debug.WriteLine($"An error occurred while creating a new card: {ex.Message}")
            conn.RollbackTrans()
            ' Log or handle the exception as needed
            Throw
        Finally
            ' Ensure the rsNewCard is closed and cleaned up
            If rsNewCard.State = ADODB.ObjectStateEnum.adStateOpen Then rsNewCard.Close()
            rsNewCard = Nothing
        End Try

        ToolStripStatusLabelCardCreated.Text = "Created: " + currentTime.ToString()
        ToolStripStatusLabelCardLastModified.Text = "Last Modified: " + currentTime.ToString()
        Debug.WriteLine($"New card created with CardID {cardID} and ClientID {clientID}")
        Return New Tuple(Of Integer, Integer)(clientID, cardID)
    End Function

    Private Sub ButtonCardViewApply_Click(sender As Object, e As EventArgs) Handles ButtonCardViewApply.Click
        If cardID <= 0 Then
            ' Initialize form for a new card
            Dim result As Tuple(Of Integer, Integer) = InitializeCard()
            ClientID = result.Item1
            cardID = result.Item2
        End If

        ' Iterate over each contact in CardContacts
        For Each contact In CardContacts
            If contact.PersonID > 0 Then
                ' This is an existing contact, update their details
                Debug.WriteLine($"Updating contact {contact.PersonID}")
                Debug.WriteLine($"Updating contact {GlobalUtilities.GetFormattedCurrentTime()}")
                Dim updatePersonQuery As String = $"UPDATE Person SET " &
                                          $"PersonLastModified = '{GlobalUtilities.GetFormattedCurrentTime()}', " &
                                          $"PersonGender = '{SafeSQL(contact.PersonGender)}', " &
                                          $"PersonFirstname = '{SafeSQL(contact.PersonFirstname)}', " &
                                          $"PersonSurname = '{SafeSQL(contact.PersonSurname)}', " &
                                          $"PersonPhone = '{SafeSQL(contact.PersonPhone)}', " &
                                          $"PersonPhone2 = '{SafeSQL(contact.PersonPhone2)}', " &
                                          $"PersonMail = '{SafeSQL(contact.PersonMail)}' " &
                                          $"WHERE PersonID = {contact.PersonID}"
                conn.Execute(updatePersonQuery)
            Else
                ' This is a new contact, insert them into the Person table
                Debug.WriteLine($"Adding new contact {contact.PersonID}")
                Dim insertPersonQuery As String = $"INSERT INTO Person (PersonCreated, PersonLastModified, PersonGender, PersonFirstname, PersonSurname, PersonPhone, PersonPhone2, PersonMail) " &
                                          $"VALUES ('{GlobalUtilities.GetFormattedCurrentTime()}', '{GlobalUtilities.GetFormattedCurrentTime()}', '{SafeSQL(contact.PersonGender)}', '{SafeSQL(contact.PersonFirstname)}', '{SafeSQL(contact.PersonSurname)}', '{SafeSQL(contact.PersonPhone)}', '{SafeSQL(contact.PersonPhone2)}', '{SafeSQL(contact.PersonMail)}');"
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
                                $"SiteAddressLat = '{SafeSQL(TextBoxLat.Text)}', " &
                                $"SiteAddressLong = '{SafeSQL(TextBoxLong.Text)}', " &
                                $"CardType = '{SafeSQL(ComboBoxCardTyp.SelectedItem)}', " &
                                $"CardCDM = '{SafeSQL(CheckBoxCardCDM.CheckState)}', " &
                                $"CardPanic = '{SafeSQL(If(CheckBoxCardPanic.Checked, 1, 0))}', " &
                                $"CardBurglary = '{SafeSQL(If(CheckBoxCardBurglary.Checked, 1, 0))}', " &
                                $"CardTSN = '{SafeSQL(If(CheckBoxCardTSN.Checked, 1, 0))}', " &
                                $"CardBoSiNet = '{SafeSQL(If(CheckBoxCardBoSiNet.Checked, 1, 0))}' " &
                                $"WHERE CardID = {Me.cardID}"

        Debug.WriteLine(updateQuery)
        Dim clientUpdateQuery As String = $"UPDATE Client SET " &
                              $"ClientName = '{SafeSQL(TextBoxClientName.Text)}', " &
                              $"ClientAddressStreet = '{SafeSQL(TextBoxClientAddressStreet.Text)}', " &
                              $"ClientAddressSupplement = '{SafeSQL(TextBoxClientAddressSupplement.Text)}', " &
                              $"ClientAddressNumber = '{SafeSQL(TextBoxClientAddressNumber.Text)}', " &
                              $"ClientAddressZIP = '{SafeSQL(TextBoxClientAddressZIP.Text)}', " &
                              $"ClientAddressCity = '{SafeSQL(TextBoxClientAddressCity.Text)}', " &
                              $"ClientAddressCountry = '{SafeSQL(TextBoxClientAddressCountry.Text)}', " &
                              $"ClientLastModified = '{GlobalUtilities.GetFormattedCurrentTime()}' " &
                              $"WHERE ClientID = {ClientID}"
        Debug.WriteLine(clientUpdateQuery)

        Try
            ' Execute the update query
            conn.Execute(updateQuery)
            conn.Execute(clientUpdateQuery)
            Debug.WriteLine($"Changes to {cardID} saved successfully")
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Failed to save changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine($"Failed to save changes: {ex.Message}")
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
            .Anchor = AnchorStyles.Left,
            .Margin = New Padding(5)
        }

            ' Configure columns: new for label and buttons, existing adjusted
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' New: Position label
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' New: Move buttons
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' Existing: Label
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60)) ' Existing: TextBox
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' Existing: Label
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60)) ' Existing: TextBox
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' Existing: Label
            contactTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60)) ' Existing: TextBox
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
            Dim moveUpButton As New Button With {.Text = " ↑", .AutoSize = True, .TextAlign = HorizontalAlignment.Center}
            Dim moveDownButton As New Button With {.Text = " ↓", .AutoSize = True}
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
            ' Assuming contact is the current item in your larger For Each contact In CardContacts loop

            ' Gender Label and TextBox
            Dim genderLabel As New Label With {.Text = "Gender:", .AutoSize = True, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleRight}
            Dim genderTextBox As New TextBox With {
                .Text = contact.PersonGender,
                .Dock = DockStyle.Fill,
                .Tag = New With {Key .Contact = contact, Key .PropertyIndex = 0},
                .AutoSize = True,
                .MinimumSize = New Size(20, 0),
                .Anchor = AnchorStyles.Left Or AnchorStyles.Right
            }
            AddHandler genderTextBox.TextChanged, AddressOf UpdateContact
            contactTable.Controls.Add(genderLabel, 2, 0)
            contactTable.Controls.Add(genderTextBox, 3, 0)

            ' First Name Label and TextBox
            Dim firstNameLabel As New Label With {.Text = "First Name:", .AutoSize = True, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleRight}
            Dim firstNameTextBox As New TextBox With {
                .Text = contact.PersonFirstname, .Dock = DockStyle.Fill,
                .Tag = New With {Key .Contact = contact, Key .PropertyIndex = 1},
                .AutoSize = True,
                .MinimumSize = New Size(20, 0),
                .Anchor = AnchorStyles.Left Or AnchorStyles.Right
            }
            AddHandler firstNameTextBox.TextChanged, AddressOf UpdateContact
            contactTable.Controls.Add(firstNameLabel, 4, 0) ' Adjust column index as needed
            contactTable.Controls.Add(firstNameTextBox, 5, 0) ' Adjust column index as needed

            ' Surname Label and TextBox
            Dim surnameLabel As New Label With {.Text = "Surname:", .AutoSize = True, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleRight}
            Dim surnameTextBox As New TextBox With {
                .Text = contact.PersonSurname, .Dock = DockStyle.Fill,
                .Tag = New With {Key .Contact = contact, Key .PropertyIndex = 2},
                .AutoSize = True,
                .MinimumSize = New Size(20, 0),
                .Anchor = AnchorStyles.Left Or AnchorStyles.Right
            }
            AddHandler surnameTextBox.TextChanged, AddressOf UpdateContact
            contactTable.Controls.Add(surnameLabel, 6, 0) ' Adjust column index as needed
            contactTable.Controls.Add(surnameTextBox, 7, 0) ' Adjust column index as needed

            ' Phone 1 Label and TextBox
            Dim phone1Label As New Label With {.Text = "Phone 1:", .AutoSize = True, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleRight}
            Dim phone1TextBox As New TextBox With {
                .Text = contact.PersonPhone, .Dock = DockStyle.Fill,
                .Tag = New With {Key .Contact = contact, Key .PropertyIndex = 3},
                .AutoSize = True,
                .MinimumSize = New Size(20, 0),
                .Anchor = AnchorStyles.Left Or AnchorStyles.Right
            }
            AddHandler phone1TextBox.TextChanged, AddressOf UpdateContact
            contactTable.Controls.Add(phone1Label, 2, 1) ' Adjust column index as needed
            contactTable.Controls.Add(phone1TextBox, 3, 1) ' Adjust column index as needed

            ' Phone 2 Label and TextBox
            Dim phone2Label As New Label With {.Text = "Phone 2:", .AutoSize = True, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleRight}
            Dim phone2TextBox As New TextBox With {
                .Text = contact.PersonPhone2, .Dock = DockStyle.Fill,
                .Tag = New With {Key .Contact = contact, Key .PropertyIndex = 4},
                .AutoSize = True,
                .MinimumSize = New Size(20, 0),
                .Anchor = AnchorStyles.Left Or AnchorStyles.Right
            }
            AddHandler phone2TextBox.TextChanged, AddressOf UpdateContact
            contactTable.Controls.Add(phone2Label, 4, 1) ' Adjust column index and row index as needed
            contactTable.Controls.Add(phone2TextBox, 5, 1) ' Adjust column index and row index as needed

            ' Email Label and TextBox
            Dim emailLabel As New Label With {.Text = "Email:", .AutoSize = True, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleRight}
            Dim emailTextBox As New TextBox With {
                .Text = contact.PersonMail, .Dock = DockStyle.Fill,
                .Tag = New With {Key .Contact = contact, Key .PropertyIndex = 5},
                .AutoSize = True,
                .MinimumSize = New Size(20, 0),
                .Anchor = AnchorStyles.Left Or AnchorStyles.Right
            }
            AddHandler emailTextBox.TextChanged, AddressOf UpdateContact
            contactTable.Controls.Add(emailLabel, 6, 1) ' Adjust column index and row index as needed
            contactTable.Controls.Add(emailTextBox, 7, 1) ' Adjust column index and row index as needed


            ' Delete button
            Dim deleteButton As New Button With {.Text = "Delete", .AutoSize = True}
            AddHandler deleteButton.Click, Sub(sender, e) DeleteContact(contact)
            contactTable.Controls.Add(deleteButton, 8, 0)

            FlowLayoutContact.Controls.Add(contactTable)
            contactIndex += 1
        Next

        FlowLayoutContact.ResumeLayout(True)
    End Sub


    Private Sub UpdateContact(sender As Object, e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        Dim contact As Contact = CType(textBox.Tag, Object).Contact
        Dim propertyIndex As Integer = CType(textBox.Tag, Object).PropertyIndex

        Select Case propertyIndex
            Case 0
                contact.PersonGender = textBox.Text
            Case 1
                contact.PersonFirstname = textBox.Text
            Case 2
                contact.PersonSurname = textBox.Text
            Case 3
                If GlobalUtilities.ValidatePhoneNumber(textBox, ButtonCardViewApply) Then
                    contact.PersonPhone = textBox.Text
                End If
            Case 4
                If GlobalUtilities.ValidatePhoneNumber(textBox, ButtonCardViewApply) Then
                    contact.PersonPhone2 = textBox.Text
                End If
            Case 5
                If GlobalUtilities.ValidateEmail(textBox, ButtonCardViewApply) Then
                    contact.PersonMail = textBox.Text
                End If
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

    Private Sub ButtonCardDelete_Click(sender As Object, e As EventArgs) Handles ButtonCardDelete.Click
        If MessageBox.Show("Are you sure you want to delete this card?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Dim deleteQuery As String = $"DELETE FROM Card WHERE CardID = {cardID}"
            Try
                conn.Execute(deleteQuery)
                Debug.WriteLine($"Card {cardID} deleted successfully")
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                MessageBox.Show($"Failed to delete card: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Debug.WriteLine($"Failed to delete card: {ex.Message}")
            End Try
        End If
    End Sub

    Private Sub TimerSearch_Tick(sender As Object, e As EventArgs) Handles TimerQuickSearch.Tick
        TimerQuickSearch.Stop() ' Stop the timer to prevent multiple executions
        If TextBoxCardNumber.Text IsNot "" Then
            LableCardNumberInfo.Text = CardsDuplicateCheck(TextBoxCardNumber.Text, ComboBoxCardTyp.SelectedItem)
        Else
            LableCardNumberInfo.Text = "⚠ Avoid cards without a number."
        End If
    End Sub

    Private Sub TextBoxCardNumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCardNumber.TextChanged
        TimerQuickSearch.Stop() ' Reset the timer every time the user types
        TimerQuickSearch.Start() ' Restart the timer
        GlobalUtilities.ValidateNumber(DirectCast(sender, TextBox), ButtonCardViewApply)
    End Sub

    Private Sub ComboBoxCardTyp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCardTyp.SelectedIndexChanged
        TimerQuickSearch.Stop() ' Reset the timer every time the user types
        TimerQuickSearch.Start() ' Restart the timer
    End Sub


    Public Function CardsDuplicateCheck(ByVal cardNumber As String, ByVal cardType As String) As String
        Dim cmd As New ADODB.Command
        cardID = If(cardID = Nothing, 0, cardID)
        cardType = If(cardType = Nothing, "", cardType)
        cardNumber = If(cardNumber = Nothing, "", cardNumber)

        With cmd
            .ActiveConnection = conn
            .CommandText = "SELECT * FROM Card WHERE CardNumber = ? AND CardType = ? AND NOT CardID = ?"
            .CommandType = CommandTypeEnum.adCmdText
            .Parameters.Append(.CreateParameter("CardNumber", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 50, cardNumber))
            .Parameters.Append(.CreateParameter("CardType", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 50, cardType))
            .Parameters.Append(.CreateParameter("CardID", DataTypeEnum.adVarChar, ParameterDirectionEnum.adParamInput, 50, cardID))
        End With

        Dim rs As ADODB.Recordset = cmd.Execute()

        If Not rs.EOF Then
            Return $"⚠ Duplicate for {rs.Fields("CardNumber").Value.ToString()} & {rs.Fields("CardType").Value.ToString()} found."
        End If
        Return ""
    End Function


    Private Sub TextBoxSiteAddressPLZ_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSiteAddressPLZ.TextChanged
        GlobalUtilities.ValidateNumber(DirectCast(sender, TextBox), ButtonCardViewApply)
    End Sub

    Private Sub TextBoxClientAddressZIP_TextChanged(sender As Object, e As EventArgs) Handles TextBoxClientAddressZIP.TextChanged
        GlobalUtilities.ValidateNumber(DirectCast(sender, TextBox), ButtonCardViewApply)
    End Sub

    Private Sub TextBoxSiteAddressNumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSiteAddressNumber.TextChanged
        GlobalUtilities.ValidateAddressNumber(DirectCast(sender, TextBox), ButtonCardViewApply)
    End Sub

    Private Sub TextBoxClientAddressNumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxClientAddressNumber.TextChanged
        GlobalUtilities.ValidateAddressNumber(DirectCast(sender, TextBox), ButtonCardViewApply)
    End Sub


    Private Function EnsureDownloadPath() As String
        If String.IsNullOrEmpty(My.Settings.DownloadPath) OrElse Not Directory.Exists(My.Settings.DownloadPath) Then
            Using folderBrowser As New FolderBrowserDialog()
                folderBrowser.Description = "Select a folder to save downloaded files"
                If folderBrowser.ShowDialog() = DialogResult.OK Then
                    My.Settings.DownloadPath = folderBrowser.SelectedPath
                    My.Settings.Save() ' Save the updated path
                    Return My.Settings.DownloadPath
                Else
                    MessageBox.Show("Download path not selected. Operation cancelled.", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return Nothing
                End If
            End Using
        Else
            Return My.Settings.DownloadPath
        End If
    End Function

    Private Function FileToByteArray(filePath As String) As Byte()
        Return IO.File.ReadAllBytes(filePath)
    End Function


    Private Sub UploadFile(columnName As String, fileTypeFilter As String)
        If cardID <= 0 Then
            ' Initialize form for a new card
            Dim result As Tuple(Of Integer, Integer) = InitializeCard()
            ClientID = result.Item1
            cardID = result.Item2
        End If

        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = fileTypeFilter
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = openFileDialog.FileName
                Dim fileBytes As Byte() = FileToByteArray(filePath)
                Dim currentTime As String = GlobalUtilities.GetFormattedCurrentTime()

                ' Attempt to find an existing record for the given CardID
                Dim rsUploadFile As New ADODB.Recordset
                rsUploadFile.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                rsUploadFile.LockType = ADODB.LockTypeEnum.adLockOptimistic
                rsUploadFile.Open($"SELECT * FROM Data WHERE CardID = {Me.cardID}", conn, , , ADODB.CommandTypeEnum.adCmdText)

                If rsUploadFile.EOF Then
                    ' No existing record, so add a new one
                    rsUploadFile.AddNew()
                    rsUploadFile.Fields("CardID").Value = Me.cardID
                    rsUploadFile.Fields("DataCreated").Value = currentTime
                End If

                ' Update the specific OLE Object field and modification date
                rsUploadFile.Fields(columnName).Value = fileBytes
                rsUploadFile.Fields("DataLastModified").Value = currentTime
                rsUploadFile.Update()

                ' Clean up
                If Not rsUploadFile Is Nothing Then
                    If rsUploadFile.State = ADODB.ObjectStateEnum.adStateOpen Then rsUploadFile.Close()
                End If
                rsUploadFile = Nothing

                MessageBox.Show("File uploaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub DownloadFile(columnName As String, fileExtension As String, fileName As String)
        Dim downloadPath As String = EnsureDownloadPath()
        If String.IsNullOrEmpty(downloadPath) Then Return

        Dim rs As New ADODB.Recordset
        Try
            rs.Open($"SELECT {columnName} FROM Data WHERE CardID = {Me.cardID}", conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

            If Not rs.EOF AndAlso Not IsDBNull(rs.Fields(columnName).Value) Then
                Dim fileBytes As Byte() = CType(rs.Fields(columnName).Value, Byte())
                ' Generate a unique filename if the specified one already exists
                Dim tempFilePath As String = Path.Combine(downloadPath, $"{fileName}{fileExtension}")
                Dim counter As Integer = 1
                While File.Exists(tempFilePath)
                    tempFilePath = Path.Combine(downloadPath, $"{fileName} ({counter}){fileExtension}")
                    counter += 1
                End While
                File.WriteAllBytes(tempFilePath, fileBytes)

                ' Optionally, open the folder containing the downloaded file
                If fileExtension = ".pdf" Then
                    Process.Start(tempFilePath)
                Else
                    Process.Start("explorer.exe", $"/select,""{tempFilePath}""")
                End If
            Else
                MessageBox.Show("No file available for the current CardID.", "Download Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            rs.Close()
        End Try
    End Sub

    Private Sub ButtonUploadCardPDF_Click(sender As Object, e As EventArgs) Handles ButtonUploadCardPDF.Click
        UploadFile("DataCardPdf", "PDF Files|*.pdf")
    End Sub

    Private Sub ButtonDownloadCard_Click(sender As Object, e As EventArgs) Handles ButtonDownloadCard.Click
        DownloadFile("DataCardPdf", ".pdf", "DataCard_" + TextBoxCardNumber.Text)
    End Sub

    Private Sub ButtonUploadMapPDF_Click(sender As Object, e As EventArgs) Handles ButtonUploadMapPDF.Click
        UploadFile("DataMapPdf", "PDF Files|*.pdf")
    End Sub

    Private Sub ButtonDownloadMapPDF_Click(sender As Object, e As EventArgs) Handles ButtonDownloadMapPDF.Click
        DownloadFile("DataMapPdf", ".pdf", "DataMap_" + TextBoxCardNumber.Text)
    End Sub

    Private Sub ButtonUploadMapDWG_Click(sender As Object, e As EventArgs) Handles ButtonUploadMapDWG.Click
        UploadFile("DataMapDwg", "DWG Files|*.dwg")
    End Sub

    Private Sub ButtonDownloadMapDWG_Click(sender As Object, e As EventArgs) Handles ButtonDownloadMapDWG.Click
        DownloadFile("DataMapDwg", ".dwg", "DataMap_" + TextBoxCardNumber.Text)
    End Sub

    Private Sub ButtonRequestLatLong_Click(sender As Object, e As EventArgs) Handles ButtonRequestLatLong.Click
        Dim address As String = $"{TextBoxSiteAddressStreet.Text} {TextBoxSiteAddressNumber.Text} {TextBoxSiteAddressAddition.Text}, {TextBoxSiteAddressCity.Text}, {TextBoxSiteAddressPLZ.Text}, {TextBoxSiteAddressCountry.Text}"
        Dim apiKey As String = GetGoogleMapsAPIKey()
        Dim requestUrl As String = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={apiKey}&language=de&region=de"

        Using webClient As New WebClient()
            Try
                Debug.WriteLine($"Requesting geocoding data from: {requestUrl}")
                Debug.WriteLine($"API Key: {apiKey}")
                Debug.WriteLine($"Address: {address}")
                Dim response As String = webClient.DownloadString(requestUrl)
                Dim geoData = JsonConvert.DeserializeObject(Of GeocodeResponse)(response)

                If geoData.status = "OK" AndAlso geoData.results.Count > 0 Then
                    Dim location = geoData.results(0).geometry.location
                    TextBoxLat.Text = location.lat.ToString(CultureInfo.InvariantCulture)
                    TextBoxLong.Text = location.lng.ToString(CultureInfo.InvariantCulture)
                Else
                    MessageBox.Show("Geocoding failed. Please check the address and try again. Make sure that you have a valid Google Geocoding Api key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Define classes to parse the JSON response
    Public Class GeocodeResponse
        Public Property status As String
        Public Property results As List(Of GeocodeResult)
    End Class

    Public Class GeocodeResult
        Public Property geometry As GeocodeGeometry
    End Class

    Public Class GeocodeGeometry
        Public Property location As GeocodeLocation
    End Class

    Public Class GeocodeLocation
        Public Property lat As Double
        Public Property lng As Double
    End Class

    Private Sub TextBoxLat_TextChanged(sender As Object, e As EventArgs) Handles TextBoxLat.TextChanged
        GlobalUtilities.ValidateGeocode(DirectCast(sender, TextBox), ButtonCardViewApply)
    End Sub
    Private Sub TextBoxLong_TextChanged(sender As Object, e As EventArgs) Handles TextBoxLong.TextChanged
        GlobalUtilities.ValidateGeocode(DirectCast(sender, TextBox), ButtonCardViewApply)
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

    Public Function ValidateAddressNumber(textBox As TextBox, applyButton As Button) As Boolean
        Dim pattern As String = "^[a-zA-Z0-9\s\-]*$"
        Dim isValidAddressNumber As Boolean = String.IsNullOrWhiteSpace(textBox.Text) OrElse Regex.IsMatch(textBox.Text, pattern)

        If isValidAddressNumber Then
            textBox.BackColor = Color.White
            applyButton.Enabled = True
            Return True
        End If
        textBox.BackColor = Color.LightCoral
        applyButton.Enabled = False
        Return False
    End Function

    Public Function ValidateGeocode(textBox As TextBox, applyButton As Button) As Boolean
        ' Pattern for matching a geocode: optional minus, digits, optional dot and more digits
        ' This pattern does not strictly validate the range of latitude (-90 to 90) and longitude (-180 to 180)
        Dim pattern As String = "^-?\d+(\.\d+)?$"

        If Not String.IsNullOrWhiteSpace(textBox.Text) AndAlso Regex.IsMatch(textBox.Text, pattern) Then
            textBox.BackColor = Color.White
            applyButton.Enabled = True
            Return True
        Else
            textBox.BackColor = Color.LightCoral
            applyButton.Enabled = False
            Return False
        End If
    End Function

    Public Function ValidateNumber(textBox As TextBox, applyButton As Button)
        Dim isValidNumber As Boolean = String.IsNullOrWhiteSpace(textBox.Text) OrElse IsNumeric(textBox.Text)

        If isValidNumber Then
            textBox.BackColor = Color.White
            applyButton.Enabled = True
            Return True
        End If
        textBox.BackColor = Color.LightCoral
        applyButton.Enabled = False
        Return False
    End Function

    Public Function ValidatePhoneNumber(textBox As TextBox, applyButton As Button)
        Dim pattern As String = "^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$"
        Dim isValidPhoneNumber As Boolean = String.IsNullOrWhiteSpace(textBox.Text) OrElse Regex.IsMatch(textBox.Text, pattern)

        If isValidPhoneNumber Then
            textBox.BackColor = Color.White
            applyButton.Enabled = True
            Return True
        End If
        textBox.BackColor = Color.LightCoral
        applyButton.Enabled = False
        Return False
    End Function

    Public Function ValidateEmail(textBox As TextBox, applyButton As Button)
        Dim pattern As String = "^\S+@\S+\.\S+$"
        If String.IsNullOrWhiteSpace(textBox.Text) OrElse Regex.IsMatch(textBox.Text, pattern) Then
            textBox.BackColor = Color.White
            applyButton.Enabled = True
            Return True
        End If
        textBox.BackColor = Color.LightCoral
        applyButton.Enabled = False
        Return False
    End Function

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
    Public Function GetGoogleMapsAPIKey() As String
        ' Check if the API Key is already set
        If String.IsNullOrEmpty(My.Settings.GoogleMapsAPIKey) Then
            ' If not set, prompt the user to update the API Key
            UpdateGoogleMapsAPIKey(forcePrompt:=True)
        End If

        ' Return the API Key after ensuring it has been set
        Return My.Settings.GoogleMapsAPIKey
    End Function

    Public Sub UpdateGoogleMapsAPIKey(Optional forcePrompt As Boolean = False)
        Dim currentApiKey As String = My.Settings.GoogleMapsAPIKey
        Dim prompt As String = "Please enter the new Google Maps API Key:"
        Dim title As String = "Update API Key"

        ' Only show the current key in the prompt if not forcing the user to re-enter the key
        Dim defaultValue As String = If(forcePrompt, String.Empty, currentApiKey)
        Dim newApiKey As String = InputBox(prompt, title, defaultValue)

        ' Check if the user entered a value or pressed OK with the default value
        If Not String.IsNullOrWhiteSpace(newApiKey) Then
            ' Save the new API key for future use in application settings
            My.Settings.GoogleMapsAPIKey = newApiKey
            My.Settings.Save() ' Save the settings to make the change persistent
        ElseIf forcePrompt AndAlso String.IsNullOrWhiteSpace(currentApiKey) Then
            Debug.WriteLine("API Key is required to use Google Maps features.")
        End If
    End Sub
End Module