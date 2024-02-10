
Imports System.Windows.Forms
Public Class Form1

    Dim rs As ADODB.Recordset
    Dim conn As ADODB.Connection

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.WriteLine("App Start")
        rs = New ADODB.Recordset
        Try
            conn = New ADODB.Connection
            conn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\2024_SATARI_DATA\CODE\DigiCard\Bosch DigiCard\Database.accdb")
            rs.Open("SELECT * FROM Client", conn,
            ADODB.CursorTypeEnum.adOpenStatic,
            ADODB.LockTypeEnum.adLockPessimistic)
            Debug.WriteLine("Datensätze gefunden: " & rs.RecordCount)

            If rs.RecordCount > 0 Then
                rs.MoveFirst()
                Do While Not rs.EOF
                    Debug.WriteLine(CStr(rs.Fields("ClientName").Value))
                    rs.MoveNext()
                Loop
            Else
                Debug.WriteLine("Keine Daten gefunden!")
            End If
            rs.Close()
            conn.Close()
        Catch ex As Exception
            Debug.WriteLine("Form1_Load Error: " + ex.Message)
        End Try
    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
