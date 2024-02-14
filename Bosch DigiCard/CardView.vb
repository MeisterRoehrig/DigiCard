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

    Private Sub CardView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCardData(Me.cardID)
    End Sub
    Private Sub CardView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If rs IsNot Nothing AndAlso rs.State = ADODB.ObjectStateEnum.adStateOpen Then
            rs.Close()
        End If
    End Sub

    Private Sub LoadCardData(cardID As Integer)
        ' Assuming you have a method to get a database connection
        Dim query As String = $"SELECT CardID, CardNumber, SiteName, CardPropertyDescription, SiteAddressStreet,SiteAddressAddition, SiteAddressNumber, SiteAddressZIP, SiteAddressCity,SiteAddressCountry, CardType, CardCreated, CardLastModified FROM Card INNER JOIN Site ON Card.SiteID=Site.SiteID WHERE CardID = {cardID}"

        Try
            If rs Is Nothing Then
                rs = New ADODB.Recordset
            End If
            rs.Open(query, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)

            If Not rs.EOF Then
                ' Populate your form controls here based on the recordset's fields
                Me.Text = SafeGetString(rs.Fields("CardNumber")) + " - " + SafeGetString(rs.Fields("SiteName"))
                TextBoxCardNumber.Text = SafeGetString(rs.Fields("CardNumber"))
                ComboBoxCardTyp.SelectedItem = SafeGetString(rs.Fields("CardType"))
                TextBoxSiteName.Text = SafeGetString(rs.Fields("SiteName"))
                TextBoxSiteAddressStreet.Text = SafeGetString(rs.Fields("SiteAddressStreet"))
                TextBoxSiteAddressAddition.Text = SafeGetString(rs.Fields("SiteAddressAddition"))
                TextBoxSiteAddressNumber.Text = SafeGetString(rs.Fields("SiteAddressNumber"))
                TextBoxSiteAddressPLZ.Text = SafeGetString(rs.Fields("SiteAddressZIP"))
                TextBoxSiteAddressCity.Text = SafeGetString(rs.Fields("SiteAddressCity"))
                TextBoxSiteAddressCountry.Text = SafeGetString(rs.Fields("SiteAddressCountry"))
            Else
                Debug.WriteLine("No data found for the specified card.")
            End If
        Catch ex As Exception
            Debug.WriteLine($"An error occurred while fetching card data: {ex.Message}")
            MessageBox.Show($"An error occurred while fetching card data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonCardViewApply_Click(sender As Object, e As EventArgs) Handles ButtonCardViewApply.Click
        ' Construct the UPDATE SQL statement
        Dim updateQuery As String = $"UPDATE Card INNER JOIN Site ON Card.SiteID = Site.SiteID SET " &
                                $"CardNumber = '{SafeSQL(TextBoxCardNumber.Text)}', " &
                                $"SiteName = '{SafeSQL(TextBoxSiteName.Text)}', " &
                                $"SiteAddressStreet = '{SafeSQL(TextBoxSiteAddressStreet.Text)}', " &
                                $"SiteAddressAddition = '{SafeSQL(TextBoxSiteAddressAddition.Text)}', " &
                                $"SiteAddressNumber = '{SafeSQL(TextBoxSiteAddressNumber.Text)}', " &
                                $"SiteAddressZIP = '{SafeSQL(TextBoxSiteAddressPLZ.Text)}', " &
                                $"SiteAddressCity = '{SafeSQL(TextBoxSiteAddressCity.Text)}', " &
                                $"SiteAddressCountry = '{SafeSQL(TextBoxSiteAddressCountry.Text)}', " &
                                $"CardType = '{SafeSQL(ComboBoxCardTyp.SelectedItem)}' " &
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

    ' Helper function to prevent SQL injection
    Private Function SafeSQL(ByVal value As String) As String
        Return value.Replace("'", "''")
    End Function


    Private Sub ButtonCardViewCancel_Click(sender As Object, e As EventArgs) Handles ButtonCardViewCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class