Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock

Public Class Form1

    Private conn As ADODB.Connection = Nothing
    Private rs As ADODB.Recordset = Nothing

    Private Sub WipeDatabaseConnection()
        ' Close and clean up the connection
        If conn IsNot Nothing Then
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn = Nothing
        End If

        ' Close and clean up the recordset
        If rs IsNot Nothing Then
            If rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                rs.Close()
            End If
            rs = Nothing
        End If
    End Sub

    Private Sub LocateDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocateDatabaseToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Access Database Files (*.accdb)|*.accdb|All files (*.*)|*.*"
        OpenFileDialog1.Title = "Select Database File"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = OpenFileDialog1.FileName

            ' Optionally, check if the selected database can be opened before saving the path
            Dim tempConn As New ADODB.Connection
            Try
                tempConn.Open($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={selectedFilePath}") ' 
                tempConn.Close() ' Close immediately after verifying it can be opened
                My.Settings.DatabasePath = selectedFilePath
                My.Settings.Save() ' Save the path to settings
                Debug.WriteLine($"[DigiCard] Database location updated successfully to: {selectedFilePath}")
                UpdateDatabase() ' Refresh the connection with the new database path
            Catch ex As Exception
                Debug.WriteLine($"[DigiCard] Failed to open selected database: {ex.Message}")
                MessageBox.Show($"Failed to open selected database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub UpdateDatabase()
        If Not String.IsNullOrEmpty(My.Settings.DatabasePath) Then
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn = New ADODB.Connection
                conn.Open($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={My.Settings.DatabasePath}")
                Debug.WriteLine($"[DigiCard] Database loaded from saved file path: {My.Settings.DatabasePath}")
                PerformSearch()
            Catch ex As Exception
                Debug.WriteLine($"[DigiCard] Failed to open saved database: {ex.Message}")
                MessageBox.Show($"Failed to open saved database: {ex.Message}. Try Changing the Database location.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.WriteLine("[DigiCard] Form1 Loaded")
        WipeDatabaseConnection()
        ToolStripStatusLabel1.Text = "Ready"

        ' Restore the checkbox states from saved settings
        CheckBoxHideFire.Checked = My.Settings.HideFire
        CheckBoxHidePolice.Checked = My.Settings.HidePolice
        CheckBoxBroadSearch.Checked = My.Settings.BroadSearch

        UpdateDatabase()

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        WipeDatabaseConnection()
    End Sub

    Private Sub TimerSearch_Tick(sender As Object, e As EventArgs) Handles TimerQuickSearch.Tick
        TimerQuickSearch.Stop() ' Stop the timer to prevent multiple executions
        PerformSearch() ' Perform the search operation
    End Sub

    Private Sub TextBoxQuickSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxQuickSearch.TextChanged
        TimerQuickSearch.Stop() ' Reset the timer every time the user types
        TimerQuickSearch.Start() ' Restart the timer
    End Sub

    Private Function BuildSearchQuery() As String
        Dim whereClause As New System.Text.StringBuilder()
        Dim filterClause As New System.Text.StringBuilder() ' Renamed from exclusionClause

        ' Handle exclusions explicitly with filterClause
        If CheckBoxHideFire.Checked Then
            AppendCondition(filterClause, "CardType <> 'Fire'", alwaysUseAnd:=True)
        End If
        If CheckBoxHidePolice.Checked Then
            AppendCondition(filterClause, "CardType <> 'Police'", alwaysUseAnd:=True)
        End If

        ' Handle search box input
        If Not String.IsNullOrWhiteSpace(TextBoxQuickSearch.Text) Then
            Dim searchTerms As String() = TextBoxQuickSearch.Text.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
            Dim searchColumns As String() = {"CardNumber", "SiteName", "CardPropertyDescription", "SiteAddressStreet", "SiteAddressAddition", "SiteAddressNumber", "SiteAddressZIP", "SiteAddressCity", "SiteAddressCountry", "CardType"}

            For Each term As String In searchTerms
                Dim termCondition As New System.Text.StringBuilder()
                For Each column As String In searchColumns
                    If termCondition.Length > 0 Then termCondition.Append(" OR ")
                    termCondition.AppendFormat("{0} LIKE '%{1}%'", column, term)
                Next
                AppendCondition(whereClause, $"({termCondition})", CheckBoxBroadSearch.Checked)
            Next
        End If

        ' Combine filterClause and whereClause
        If filterClause.Length > 0 Then
            If whereClause.Length > 0 Then
                whereClause.Insert(0, filterClause.ToString() & " AND (") ' Prepend filterClause and open parenthesis for remaining conditions
                whereClause.Append(")") ' Close parenthesis for remaining conditions
            Else
                whereClause.Append(filterClause.ToString()) ' Just use filterClause if no other conditions
            End If
        End If

        ' Construct the final search query
        Dim searchQuery As String = "SELECT CardID, CardNumber, SiteName, CardPropertyDescription, SiteAddressStreet,SiteAddressAddition, SiteAddressNumber, SiteAddressZIP, SiteAddressCity,SiteAddressCountry, CardType, CardCreated, CardLastModified FROM Card INNER JOIN Site ON Card.SiteID=Site.SiteID"
        If whereClause.Length > 0 Then
            searchQuery &= " WHERE " & whereClause.ToString()
        End If

        Return searchQuery
    End Function

    Private Sub AppendCondition(ByRef clause As StringBuilder, condition As String, Optional useOr As Boolean = False, Optional alwaysUseAnd As Boolean = False)
        If clause.Length > 0 Then clause.Append(If(alwaysUseAnd, " AND ", If(useOr, " OR ", " AND ")))
        clause.Append(condition)
    End Sub


    Private Sub PopulateDataGridView(searchQuery As String)
        Try
            If rs Is Nothing Then
                rs = New ADODB.Recordset
            End If
            rs.Open(searchQuery, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            Dim dt As New DataTable
            If Not rs.EOF Then
                TextBoxQuickSearch.BackColor = SystemColors.Window
                ToolStripStatusLabel1.Text = $"Search results: {rs.RecordCount} entries found."

                Dim data As Object = rs.GetRows()
                For i As Integer = 0 To rs.Fields.Count - 1
                    dt.Columns.Add(rs.Fields(i).Name)
                Next

                For j As Integer = 0 To UBound(data, 2)
                    Dim row As DataRow = dt.NewRow()
                    For i As Integer = 0 To UBound(data, 1)
                        row(i) = data(i, j)
                    Next
                    dt.Rows.Add(row)
                Next

                'Hide CardID Column
                DataGridViewCardsForm1.DataSource = dt

                With DataGridViewCardsForm1
                    If .Columns("CardID") IsNot Nothing Then
                        .Columns("CardID").Visible = False
                    End If
                End With
            Else
                TextBoxQuickSearch.BackColor = Color.LightCoral
                ToolStripStatusLabel1.Text = "Search results: No entries were found."
                DataGridViewCardsForm1.DataSource = Nothing
                DataGridViewCardsForm1.DataSource = New DataTable() ' Clears the DataGridView
            End If

            rs.Close()
        Catch ex As Exception
            Debug.WriteLine("[DigiCard] Error populating DataGridView: " + ex.Message)
            ToolStripStatusLabel1.Text = "Error: " + ex.Message
        End Try
    End Sub

    Private Sub PerformSearch()
        Dim searchQuery As String = BuildSearchQuery()
        PopulateDataGridView(searchQuery)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        My.Settings.BroadSearch = CheckBoxBroadSearch.Checked
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub CheckBoxBroadSearch_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxBroadSearch.CheckedChanged
        PerformSearch()
    End Sub

    Private Sub CheckBoxHideFire_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxHideFire.CheckedChanged
        My.Settings.HideFire = CheckBoxHideFire.Checked
        My.Settings.Save()
        PerformSearch()
    End Sub

    Private Sub CheckBoxHidePolice_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxHidePolice.CheckedChanged
        My.Settings.HidePolice = CheckBoxHidePolice.Checked
        My.Settings.Save()
        PerformSearch()
    End Sub

    Private Sub DataGridViewCardsForm1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCardsForm1.CellDoubleClick
        ' Make sure the click is not on the header
        If e.RowIndex >= 0 Then
            Dim cardID As Integer = Convert.ToInt32(DataGridViewCardsForm1.Rows(e.RowIndex).Cells("CardID").Value)
            Dim cardView As New CardView(cardID, conn)
            If cardView.ShowDialog() = DialogResult.OK Then
                ' Refresh DataGridView here
                PerformSearch()
                SelectRowByCardID(cardID)
            End If
        End If
    End Sub

    Private Sub SelectRowByCardID(cardID As Integer)
        ' Ensure the DataGridView has been populated and has rows
        If DataGridViewCardsForm1.Rows.Count > 0 Then
            Dim rowIndex As Integer = -1
            ' Search for the row index with the matching CardID
            For Each row As DataGridViewRow In DataGridViewCardsForm1.Rows
                If row.Cells("CardID").Value IsNot Nothing AndAlso row.Cells("CardID").Value.ToString() = cardID.ToString() Then
                    rowIndex = row.Index
                    Exit For
                End If
            Next

            ' If a matching row is found, select it
            If rowIndex <> -1 Then
                DataGridViewCardsForm1.ClearSelection()
                DataGridViewCardsForm1.Rows(rowIndex).Selected = True
                DataGridViewCardsForm1.CurrentCell = DataGridViewCardsForm1.Rows(rowIndex).Cells(1) ' Or another cell index if preferred
            End If
        End If
    End Sub

    Private Sub SetDonwloadPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetDonwloadPathToolStripMenuItem.Click
        Using folderBrowser As New FolderBrowserDialog()
            folderBrowser.Description = "Select a folder to save downloaded PDFs"
            ' Set the initial directory to the current download path if one exists
            If Not String.IsNullOrEmpty(My.Settings.DownloadPath) Then
                folderBrowser.SelectedPath = My.Settings.DownloadPath
            End If

            ' Show the dialog and check if the user clicked OK
            If folderBrowser.ShowDialog() = DialogResult.OK Then
                ' Update the download path in the settings
                My.Settings.DownloadPath = folderBrowser.SelectedPath
                My.Settings.Save() ' Save the settings

                Debug.WriteLine($"Download path set to: {My.Settings.DownloadPath}", "Download Path Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Optionally handle the case where the user cancels the dialog
                MessageBox.Show("Download path update cancelled.", "Update Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub NewEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewEntryToolStripMenuItem.Click
        Dim cardView As New CardView(0, conn)
        If cardView.ShowDialog() = DialogResult.OK Then
            ' Refresh DataGridView here
            PerformSearch()
            'SelectRowByCardID(cardID)
        End If
    End Sub

    Private Sub SetGeocodingAPIKeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetGeocodingAPIKeyToolStripMenuItem.Click
        GlobalUtilities.UpdateGoogleMapsAPIKey(True)
    End Sub
End Class
