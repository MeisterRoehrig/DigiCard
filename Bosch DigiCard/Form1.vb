Imports System.Windows.Forms

Public Class Form1

    Dim rs As ADODB.Recordset
    Dim conn As ADODB.Connection


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.WriteLine("[DigiCard] Form1 Loaded")
        ToolStripStatusLable1.Text = "Ready"
        UpdateDatabase()
    End Sub

    Private Sub UpdateDatabase()
        If Not String.IsNullOrEmpty(My.Settings.DatabasePath) Then
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn = New ADODB.Connection
                conn.Open($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={My.Settings.DatabasePath}")
                PerformSearch()
            Catch ex As Exception
                MessageBox.Show($"Failed to open saved database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub TimerSearch_Tick(sender As Object, e As EventArgs) Handles TimerQuickSearch.Tick
        TimerQuickSearch.Stop() ' Stop the timer to prevent multiple executions
        PerformSearch() ' Perform the search operation
    End Sub

    Private Sub TextBoxQuickSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxQuickSearch.TextChanged
        TimerQuickSearch.Stop() ' Reset the timer every time the user types
        TimerQuickSearch.Start() ' Restart the timer
    End Sub

    Private Sub LocateDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocateDatabaseToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Access Database Files (*.accdb)|*.accdb|All files (*.*)|*.*"
        OpenFileDialog1.Title = "Select Database File"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = OpenFileDialog1.FileName
            My.Settings.DatabasePath = selectedFilePath
            My.Settings.Save() ' Save the path to settings
            ' Now you can use selectedFilePath as the path to your database
            UpdateDatabase()
        End If
    End Sub


    Private Sub PerformSearch()
        Try
            Dim searchQuery As String
            ' Check if the search box is empty
            If String.IsNullOrWhiteSpace(TextBoxQuickSearch.Text) Then
                ' Fetch all records since no search term is provided
                searchQuery = "SELECT CardNumber, ProjectName, CardType, ProjectAddressStreet,ProjectAddressSupplement, ProjectAddressNumber, ProjectAddressPLZ, ProjectAddressCity,ProjectAddressCountry, CardCreated, CardLastModified FROM Card INNER JOIN Project ON Card.ProjectID=Project.ProjectID"
            Else
                ' Construct the WHERE clause
                Dim searchTerms As String() = TextBoxQuickSearch.Text.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
                Dim searchColumns As String() = {"CardNumber", "ProjectName", "CardType", "ProjectAddressStreet", "ProjectAddressNumber", "ProjectAddressPLZ", "ProjectAddressCity"}

                Dim whereClause As New System.Text.StringBuilder()

                For Each term As String In searchTerms
                    If whereClause.Length > 0 Then whereClause.Append(If(CheckBoxBroadSearch.Checked, " OR ", " AND "))
                    Dim termCondition As New System.Text.StringBuilder()
                    For Each column As String In searchColumns
                        If termCondition.Length > 0 Then termCondition.Append(" OR ")
                        termCondition.AppendFormat("{0} LIKE '%{1}%'", column, term)
                    Next
                    whereClause.AppendFormat("({0})", termCondition.ToString())
                Next

                searchQuery = $"SELECT CardNumber, ProjectName, CardType, ProjectAddressStreet, ProjectAddressNumber, ProjectAddressPLZ, ProjectAddressCity, CardCreated, CardLastModified FROM Card INNER JOIN Project ON Card.ProjectID=Project.ProjectID WHERE {whereClause}"
            End If

            ' Execute the constructed search query
            If rs Is Nothing Then
                rs = New ADODB.Recordset
            End If
            rs.Open(searchQuery, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockPessimistic)
            Debug.WriteLine("[DigiCard] Recordset entries found: " & rs.RecordCount)

            Dim dt As New DataTable
            If Not rs.EOF Then
                TextBoxQuickSearch.BackColor = SystemColors.Window
                ToolStripStatusLable1.Text = "Search results: " + rs.RecordCount.ToString() + " entries found."

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

                DataGridViewCardsForm1.DataSource = dt
            Else
                TextBoxQuickSearch.BackColor = Color.LightCoral
                ToolStripStatusLable1.Text = "Search results: No entries were found."
            End If

            rs.Close()

        Catch ex As Exception
            Debug.WriteLine("[DigiCard] ADODB.Connection error: " + ex.Message)
            ToolStripStatusLable1.Text = "Error: _" + ex.Message
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CheckBoxBroadSearch_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxBroadSearch.CheckedChanged
        PerformSearch()
    End Sub


    Private Sub DataGridViewCardsForm1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCardsForm1.CellDoubleClick
        ' Make sure the click is not on the header
        If e.RowIndex >= 0 Then
            Dim cardView As New CardView()

            ' Assuming your DataGridView is bound to a DataTable or similar
            ' Retrieve the DataRow bound to the clicked row
            Dim row As DataRow = DirectCast(DataGridViewCardsForm1.Rows(e.RowIndex).DataBoundItem, DataRowView).Row
            cardView.SetData(row)
            cardView.ShowDialog() ' Use ShowDialog for modal, Show for non-modal
        End If
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

End Class
