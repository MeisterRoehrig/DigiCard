
Imports System.Windows.Forms
Public Class Form1

    Dim rs As ADODB.Recordset
    Dim conn As ADODB.Connection


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.WriteLine("[DigiCard] Form1 Loaded")
        rs = New ADODB.Recordset
        Try
            conn = New ADODB.Connection
            conn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\2024_SATARI_DATA\CODE\DigiCard\Bosch DigiCard\Database.accdb")

            rs.Open("SELECT CardNumber, ProjectName, CardType, ProjectAddressStreet, ProjectAddressNumber, ProjectAddressPLZ, ProjectAddressCity, CardCreated, CardLastModified FROM Card INNER JOIN Project ON Card.ProjectID=Project.ProjectID", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockPessimistic)
            Debug.WriteLine("[DigiCard] Recordset entries found: " & rs.RecordCount)

            Dim data As Object = rs.GetRows() ' Retrieve data into a 2-dimensional array

            Dim dt As New DataTable

            ' Add columns to DataTable based on the recordset's fields
            For i As Integer = 0 To rs.Fields.Count - 1
                dt.Columns.Add(rs.Fields(i).Name)
            Next

            ' Populate DataTable with data from the array
            For j As Integer = 0 To UBound(data, 2)
                Dim row As DataRow = dt.NewRow()
                For i As Integer = 0 To UBound(data, 1)
                    row(i) = data(i, j)
                Next
                dt.Rows.Add(row)
            Next

            ' Bind DataTable to DataGridView
            DataGridView1.DataSource = dt

            rs.Close()
            conn.Close()
        Catch ex As Exception
            Debug.WriteLine("[DigiCard] ADODB.Connection error: " + ex.Message)
        End Try
    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


End Class
