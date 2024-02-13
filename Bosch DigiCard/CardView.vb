Imports System.Windows.Forms

Public Class CardView
    Public Sub SetData(ByVal row As DataRow)
        Me.Text = SafeGetString(row.Item("CardNumber")) + " - " + SafeGetString(row.Item("ProjectName"))
        TextBoxCardNumber.Text = SafeGetString(row.Item("CardNumber"))
        ComboBoxCardTyp.SelectedItem = SafeGetString(row.Item("CardType"))
        TextBoxProjectName.Text = SafeGetString(row.Item("ProjectName"))
        TextBoxProjectAddressStreet.Text = SafeGetString(row.Item("ProjectAddressStreet"))
        TextBoxProjectAddressSupplement.Text = SafeGetString(row.Item("ProjectAddressSupplement"))
        TextBoxProjectAddressNumber.Text = SafeGetString(row.Item("ProjectAddressNumber"))
        TextBoxProjectAddressPLZ.Text = SafeGetString(row.Item("ProjectAddressPLZ"))
        TextBoxProjectAddressCity.Text = SafeGetString(row.Item("ProjectAddressCity"))
        TextBoxProjectAddressCountry.Text = SafeGetString(row.Item("ProjectAddressCountry"))
    End Sub

    Public Function SafeGetString(ByVal obj As Object) As String
        If obj Is Nothing OrElse IsDBNull(obj) Then
            Return String.Empty
        Else
            Return obj.ToString()
        End If
    End Function

    Private Sub ButtonCardViewCancel_Click(sender As Object, e As EventArgs) Handles ButtonCardViewCancel.Click
        Me.Close()
    End Sub
End Class


