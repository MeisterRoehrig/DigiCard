Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports System.Globalization

Public Class Form1

    Private conn As ADODB.Connection = Nothing
    Private rs As ADODB.Recordset = Nothing

    'Sicherstellen das beim Starten keine DB Connections mit gleichem Namen existieren
    Private Sub WipeDatabaseConnection()
        If conn IsNot Nothing Then
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn = Nothing
        End If

        If rs IsNot Nothing Then
            If rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                rs.Close()
            End If
            rs = Nothing
        End If
    End Sub

    'Speichern des Pfads zur Datenbank
    Private Sub LocateDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocateDatabaseToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Access Database Files (*.accdb)|*.accdb|All files (*.*)|*.*"
        OpenFileDialog1.Title = "Select Database File"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = OpenFileDialog1.FileName

            Dim tempConn As New ADODB.Connection
            Try
                tempConn.Open($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={selectedFilePath}") ' 
                tempConn.Close()
                My.Settings.DatabasePath = selectedFilePath
                My.Settings.Save()
                Debug.WriteLine($"[DigiCard] Database location updated successfully to: {selectedFilePath}")
                UpdateDatabase()
            Catch ex As Exception
                Debug.WriteLine($"[DigiCard] Failed to open selected database: {ex.Message}")
                MessageBox.Show($"Failed to open selected database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    'Start der Dantenbank verbindnung bei Form Load etc.
    Private Sub UpdateDatabase()
        If Not String.IsNullOrEmpty(My.Settings.DatabasePath) Then
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn = New ADODB.Connection
                conn.Open($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={My.Settings.DatabasePath}")
                Debug.WriteLine($"[DigiCard] Database loaded from saved file path: {My.Settings.DatabasePath}")
                PerformSearch(isRefresh:=True)
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

        ' Landen der vorheriegen eingaben aus den Settings 
        CheckBoxHideFire.Checked = My.Settings.HideFire
        CheckBoxHidePolice.Checked = My.Settings.HidePolice
        CheckBoxBroadSearch.Checked = My.Settings.BroadSearch
        CheckBoxFuzzySearch.Checked = My.Settings.FuzzySearch
        UpdateDatabase()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        WipeDatabaseConnection()
    End Sub

    'Timer um zu verhindern das sofort nach jeder eingabe ein querry durchgefürt werde
    Private Sub TimerSearch_Tick(sender As Object, e As EventArgs) Handles TimerQuickSearch.Tick
        TimerQuickSearch.Stop()
        PerformSearch(isQuickSearch:=True)
    End Sub

    Private Sub TextBoxQuickSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxQuickSearch.TextChanged
        TimerQuickSearch.Stop()
        TimerQuickSearch.Start()
    End Sub

    'Vorbereiten der Select Querry mit dem Filtern
    Private Function PrepareSearch() As DataTable
        Dim baseQuery As String = "SELECT CardID, CardNumber, SiteName, CardPropertyDescription, SiteAddressStreet, SiteAddressAddition, SiteAddressNumber, SiteAddressZIP, SiteAddressCity, SiteAddressCountry, CardType, SiteAddressLat, SiteAddressLong, CardCreated, CardLastModified FROM Card INNER JOIN Site ON Card.SiteID=Site.SiteID"
        Dim filterClauses As New List(Of String)

        If CheckBoxHideFire.Checked Then
            filterClauses.Add("CardType <> 'Fire'")
        End If
        If CheckBoxHidePolice.Checked Then
            filterClauses.Add("CardType <> 'Police'")
        End If

        If filterClauses.Any() Then
            baseQuery &= " WHERE " & String.Join(" AND ", filterClauses)
        End If

        Return ExecuteQuery(baseQuery)
    End Function

    'Laden der Daten aus der Datenbank
    Private Function ExecuteQuery(query As String) As DataTable
        Dim dataTable As New DataTable()
        Try
            If rs Is Nothing Then
                rs = New ADODB.Recordset
            End If
            rs.Open(query, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If Not rs.EOF Then
                For Each field As ADODB.Field In rs.Fields
                    dataTable.Columns.Add(field.Name, GetType(String))
                Next

                While Not rs.EOF
                    Dim row As DataRow = dataTable.NewRow()
                    For i As Integer = 0 To rs.Fields.Count - 1
                        row(i) = rs.Fields(i).Value.ToString()
                    Next
                    dataTable.Rows.Add(row)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
        Catch ex As Exception
            Debug.WriteLine("Error executing query: " & ex.Message)
        End Try
        Return dataTable
    End Function

    Private Function PerformDataSearch(data As DataTable, isQuickSearch As Boolean) As DataTable
        ' Welche Columns sollen durchsucht werden
        Dim quickSearchColumns As String() = {"CardNumber", "SiteName", "CardPropertyDescription", "SiteAddressStreet", "SiteAddressAddition", "SiteAddressNumber", "SiteAddressZIP", "SiteAddressCity", "SiteAddressCountry", "CardType"}

        ' Bei advanced search mapping zwischen Columns des rs und den Text Boxen
        Dim advancedSearchCriteria As New Dictionary(Of String, TextBox)
        If Not isQuickSearch Then
            advancedSearchCriteria.Add("SiteAddressStreet", TextBoxSiteAddressStreet)
            advancedSearchCriteria.Add("SiteAddressNumber", TextBoxSiteAddressNumber)
            advancedSearchCriteria.Add("SiteAddressAddition", TextBoxSiteAddressAddition)
            advancedSearchCriteria.Add("SiteAddressCity", TextBoxSiteAddressCity)
            advancedSearchCriteria.Add("SiteAddressZIP", TextBoxSiteAddressPLZ)
            advancedSearchCriteria.Add("SiteAddressCountry", TextBoxSiteAddressCountry)
            advancedSearchCriteria.Add("CardNumber", TextBoxCardNumber)
            advancedSearchCriteria.Add("SiteName", TextBoxSiteName)
        End If

        'Wenn keine eingabe erfolgt ist gesamte daten ohne suche ausgeben
        If TextBoxQuickSearch.Text Is Nothing AndAlso isQuickSearch Then
            Return data
        End If

        Dim searchTerms As String() = If(isQuickSearch, TextBoxQuickSearch.Text.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries), Array.Empty(Of String)())
        Dim filteredData As DataTable = data.Clone()

        For Each row As DataRow In data.Rows
            Dim termMatches As New List(Of Boolean)()

            If isQuickSearch Then
                For Each term As String In searchTerms
                    'Durchführen einer Quick search
                    PerformSearchLogic(term, quickSearchColumns, row, termMatches)
                Next
            Else
                'Durchfüren einer Advanced Search
                For Each kvp As KeyValuePair(Of String, TextBox) In advancedSearchCriteria
                    If Not String.IsNullOrWhiteSpace(kvp.Value.Text) Then
                        PerformSearchLogic(kvp.Value.Text, New String() {kvp.Key}, row, termMatches)
                    End If
                Next
            End If

            'Bei oder suche reicht es wenn suche einem Column matched 
            Dim isRowMatch As Boolean = If(CheckBoxBroadSearch.Checked, termMatches.Any(Function(x) x), termMatches.All(Function(x) x))

            If isRowMatch Then
                filteredData.ImportRow(row)
            End If
        Next
        Return filteredData
    End Function

    'Durchsuchen der Vorbereiteten datensatzes mit Fuzzy search oder match search
    Private Sub PerformSearchLogic(term As String, columns As String(), row As DataRow, ByRef termMatches As List(Of Boolean))
        Dim termMatchFound As Boolean = False

        For Each column As String In columns
            Dim cellText As String = If(row(column) IsNot Nothing, row(column).ToString().ToLower(), "")

            If CheckBoxFuzzySearch.Checked Then
                Dim matchScore As Double = Simil.Simil(cellText, term.ToLower())
                If matchScore >= 0.7 Then
                    termMatchFound = True
                    Exit For
                End If
            Else
                ' Use basic matching logic for exact searches
                If String.Equals(cellText, term, StringComparison.OrdinalIgnoreCase) Then
                    termMatchFound = True
                    Exit For
                End If
            End If
        Next

        termMatches.Add(termMatchFound)
    End Sub

    Private Sub PopulateDataGridView(filteredData As DataTable)
        Try
            If filteredData IsNot Nothing AndAlso filteredData.Rows.Count > 0 Then
                ToolStripStatusLabel1.Text = $"Search results: {filteredData.Rows.Count} entries found."

                'verstecken von unnützen Columns
                With DataGridViewCardsForm1
                    .DataSource = filteredData

                    If .Columns("CardID") IsNot Nothing Then
                        .Columns("CardID").Visible = False
                    End If
                    If .Columns("SiteAddressLat") IsNot Nothing Then
                        .Columns("SiteAddressLat").Visible = False
                    End If
                    If .Columns("SiteAddressLong") IsNot Nothing Then
                        .Columns("SiteAddressLong").Visible = False
                    End If
                End With
            Else
                ToolStripStatusLabel1.Text = "Search results: No entries were found."
                DataGridViewCardsForm1.DataSource = Nothing
            End If
        Catch ex As Exception
            Debug.WriteLine("[DigiCard] Error populating DataGridView: " + ex.Message)
            ToolStripStatusLabel1.Text = "Error: " + ex.Message
        End Try
    End Sub


    Private Sub PerformSearch(Optional isQuickSearch As Boolean = True, Optional isRefresh As Boolean = False)
        If isRefresh Then
            If TextBoxQuickSearch.Text Is "" Then
                Debug.WriteLine("Performing Refresh False")
                Dim dt As DataTable = PrepareSearch()
                dt = PerformDataSearch(dt, False)
                PopulateDataGridView(dt)
                DisplayMarkersFromDataGridView()
            Else
                Dim dt As DataTable = PrepareSearch()
                Debug.WriteLine("Performing Refresh True")

                dt = PerformDataSearch(dt, True)
                PopulateDataGridView(dt)
                DisplayMarkersFromDataGridView()
            End If
        Else
            Dim dt As DataTable = PrepareSearch()
            dt = PerformDataSearch(dt, isQuickSearch)
            PopulateDataGridView(dt)
            DisplayMarkersFromDataGridView()
        End If
    End Sub

    Private Sub ButtonAdvancedSearch_Click(sender As Object, e As EventArgs) Handles ButtonAdvancedSearch.Click
        GlobalUtilities.ClearTextBoxWithoutTextChange(TextBoxQuickSearch, AddressOf TextBoxQuickSearch_TextChanged)
        PerformSearch(isQuickSearch:=False)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        My.Settings.BroadSearch = CheckBoxBroadSearch.Checked
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub CheckBoxBroadSearch_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxBroadSearch.CheckedChanged
        If TextBoxQuickSearch.Text IsNot "" Then
            PerformSearch()
        End If
    End Sub

    Private Sub CheckBoxHideFire_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxHideFire.CheckedChanged
        My.Settings.HideFire = CheckBoxHideFire.Checked
        My.Settings.Save()
        If TextBoxQuickSearch.Text IsNot "" Then
            PerformSearch()
        End If
    End Sub

    Private Sub CheckBoxHidePolice_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxHidePolice.CheckedChanged
        My.Settings.HidePolice = CheckBoxHidePolice.Checked
        My.Settings.Save()
        If TextBoxQuickSearch.Text IsNot "" Then
            PerformSearch()
        End If
    End Sub

    Private Sub CheckBoxFuzzySearch_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFuzzySearch.CheckedChanged
        My.Settings.FuzzySearch = CheckBoxFuzzySearch.Checked
        My.Settings.Save()
        If TextBoxQuickSearch.Text IsNot "" Then
            PerformSearch()
        End If
    End Sub

    'Starte Card Form beim Click
    Private Sub DataGridViewCardsForm1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCardsForm1.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim cardID As Integer = Convert.ToInt32(DataGridViewCardsForm1.Rows(e.RowIndex).Cells("CardID").Value)
            Dim cardView As New CardView(cardID, conn)
            If cardView.ShowDialog() = DialogResult.OK Then
                PerformSearch(isRefresh:=True)
                SelectRowByCardID(cardID)
            End If
        End If
    End Sub

    'Wählt Row aus nachdem Card View geschlossen wurde
    Private Sub SelectRowByCardID(cardID As Integer)
        If DataGridViewCardsForm1.Rows.Count > 0 Then
            Dim rowIndex As Integer = -1
            For Each row As DataGridViewRow In DataGridViewCardsForm1.Rows
                If row.Cells("CardID").Value IsNot Nothing AndAlso row.Cells("CardID").Value.ToString() = cardID.ToString() Then
                    rowIndex = row.Index
                    Exit For
                End If
            Next

            If rowIndex <> -1 Then
                DataGridViewCardsForm1.ClearSelection()
                DataGridViewCardsForm1.Rows(rowIndex).Selected = True
                DataGridViewCardsForm1.CurrentCell = DataGridViewCardsForm1.Rows(rowIndex).Cells(1) ' Or another cell index if preferred
            End If
        End If
    End Sub

    'Updaten des Download paths
    Private Sub SetDonwloadPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetDonwloadPathToolStripMenuItem.Click
        Using folderBrowser As New FolderBrowserDialog()
            folderBrowser.Description = "Select a folder to save downloaded Files."
            If Not String.IsNullOrEmpty(My.Settings.DownloadPath) Then
                folderBrowser.SelectedPath = My.Settings.DownloadPath
            End If

            If folderBrowser.ShowDialog() = DialogResult.OK Then
                My.Settings.DownloadPath = folderBrowser.SelectedPath
                My.Settings.Save()
                PerformSearch(isRefresh:=True)
                Debug.WriteLine($"Download path set to: {My.Settings.DownloadPath}", "Download Path Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    'Starten eines CardViews mit für neue Karte
    Private Sub NewEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewEntryToolStripMenuItem.Click
        Dim cardView As New CardView(0, conn)
        If cardView.ShowDialog() = DialogResult.OK Then
            PerformSearch(isRefresh:=True)
        End If
    End Sub

    Private Sub SetGeocodingAPIKeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetGeocodingAPIKeyToolStripMenuItem.Click
        GlobalUtilities.UpdateGoogleMapsAPIKey(True)
    End Sub

    'Lade Map View 
    Private Sub GMapControl_Load(sender As Object, e As EventArgs) Handles GMapControl.Load
        GMap.NET.MapProviders.GoogleMapProvider.UserAgent = "DigiCard"
        GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly
        GMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance

        GMapControl.Position = New GMap.NET.PointLatLng(52.520008, 13.404954) ' Example: Latitude and Longitude of Paris, France
        GMapControl.MinZoom = 5
        GMapControl.MaxZoom = 20
        GMapControl.Zoom = 10
        GMapControl.DragButton = MouseButtons.Left
        GMapControl.ShowCenter = False
        GMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter
        AddHandler GMapControl.OnMarkerClick, AddressOf MarkerClick
    End Sub

    'Wird bei click eines Markers aufgerufen und startet den Card view
    Private Sub MarkerClick(item As GMap.NET.WindowsForms.GMapMarker, e As MouseEventArgs)
        Debug.WriteLine("Marker clicked: " & item.Position.ToString())
        If item.Tag IsNot Nothing Then
            Dim cardID As Integer = Convert.ToInt32(item.Tag)

            Dim cardView As New CardView(cardID, conn)
            If cardView.ShowDialog() = DialogResult.OK Then
                PerformSearch(isRefresh:=True)
            End If
        End If
    End Sub

    'Lädt marker in der Karte auf basis des Data Grid Views
    Private Sub DisplayMarkersFromDataGridView()
        Dim markersOverlay As GMap.NET.WindowsForms.GMapOverlay
        Dim overlayExists As Boolean = False

        For Each overlay As GMap.NET.WindowsForms.GMapOverlay In GMapControl.Overlays
            If overlay.Id = "markers" Then
                markersOverlay = overlay
                overlayExists = True
                markersOverlay.Markers.Clear()
                Exit For
            End If
        Next

        If Not overlayExists Then
            markersOverlay = New GMap.NET.WindowsForms.GMapOverlay("markers")
            GMapControl.Overlays.Add(markersOverlay)
            Debug.WriteLine("Overlay count: " & GMapControl.Overlays.Count)
        End If

        For Each row As DataGridViewRow In DataGridViewCardsForm1.Rows
            If Not row.IsNewRow AndAlso Not IsDBNull(row.Cells("SiteAddressLat").Value) AndAlso Not IsDBNull(row.Cells("SiteAddressLong").Value) Then
                Dim lat As Double = 0
                Dim lng As Double = 0
                Dim latString As String = row.Cells("SiteAddressLat").Value.ToString()
                Dim lngString As String = row.Cells("SiteAddressLong").Value.ToString()

                If Double.TryParse(latString, NumberStyles.Any, CultureInfo.InvariantCulture, lat) AndAlso Double.TryParse(lngString, NumberStyles.Any, CultureInfo.InvariantCulture, lng) Then
                    Dim marker As GMarkerGoogleWithLabel
                    If row.Cells("CardType").Value.ToString() = "Fire" Then
                        marker = New GMarkerGoogleWithLabel(New GMap.NET.PointLatLng(lat, lng), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot)
                        marker.Tag = Convert.ToInt32(row.Cells("CardID").Value)
                        marker.LabelColor = Color.IndianRed
                    ElseIf row.Cells("CardType").Value.ToString() = "Police" Then
                        marker = New GMarkerGoogleWithLabel(New GMap.NET.PointLatLng(lat, lng), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_dot)
                        marker.Tag = Convert.ToInt32(row.Cells("CardID").Value)
                        marker.LabelColor = Color.Blue
                    Else
                        marker = New GMarkerGoogleWithLabel(New GMap.NET.PointLatLng(lat, lng), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.black_small)
                        marker.Tag = Convert.ToInt32(row.Cells("CardID").Value)
                        marker.LabelColor = Color.Black
                    End If
                    If Not IsDBNull(row.Cells("SiteName").Value) Then
                        marker.LabelText = row.Cells("SiteName").Value.ToString()
                    End If
                    markersOverlay.Markers.Add(marker)
                End If
            End If
        Next

        GMapControl.Refresh()
    End Sub

End Class

'Erweiterung der GMarker Classe mit zusätzlichem Lable
Public Class GMarkerGoogleWithLabel
    Inherits GMarkerGoogle

    Public Property LabelText As String
    Public Property LabelFont As Font = New Font("Arial", 8)

    Private _labelBrush As Brush = New SolidBrush(Color.Black)
    Public Property LabelBrush As Brush
        Get
            Return _labelBrush
        End Get
        Set(value As Brush)
            _labelBrush = value
        End Set
    End Property

    Private _labelColor As Color = Color.Black
    Public Property LabelColor As Color
        Get
            Return _labelColor
        End Get
        Set(value As Color)
            _labelColor = value
            _labelBrush = New SolidBrush(value)
        End Set
    End Property

    Public Property LabelOffset As Point = New Point(20, 20)

    Public Sub New(p As PointLatLng, type As GMarkerGoogleType)
        MyBase.New(p, type)
    End Sub

    Public Sub New(p As PointLatLng, bitmap As Bitmap)
        MyBase.New(p, bitmap)
    End Sub

    Public Overrides Sub OnRender(g As Graphics)
        MyBase.OnRender(g)

        If Not String.IsNullOrWhiteSpace(LabelText) Then
            Dim labelPosition As New PointF(LocalPosition.X + LabelOffset.X, LocalPosition.Y + LabelOffset.Y)

            Dim borderBrush As Brush = New SolidBrush(Color.White)

            Dim borderThickness As Integer = 0.7

            For x As Integer = -borderThickness To borderThickness
                For y As Integer = -borderThickness To borderThickness
                    If x <> 0 OrElse y <> 0 Then
                        g.DrawString(LabelText, LabelFont, borderBrush, New PointF(labelPosition.X + x, labelPosition.Y + y))
                    End If
                Next
            Next

            g.DrawString(LabelText, LabelFont, LabelBrush, labelPosition)
        End If
    End Sub
End Class
