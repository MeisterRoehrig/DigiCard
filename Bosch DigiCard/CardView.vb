Imports System.Windows.Forms

Public Class CardView
    Public Sub SetData(ByVal row As DataRow)
        Me.Text = SafeGetString(row.Item("CardNumber")) + " - " + SafeGetString(row.Item("SiteName"))
        TextBoxCardNumber.Text = SafeGetString(row.Item("CardNumber"))
        ComboBoxCardTyp.SelectedItem = SafeGetString(row.Item("CardType"))
        TextBoxSiteName.Text = SafeGetString(row.Item("SiteName"))
        TextBoxSiteAddressStreet.Text = SafeGetString(row.Item("SiteAddressStreet"))
        TextBoxSiteAddressAddition.Text = SafeGetString(row.Item("SiteAddressAddition"))
        TextBoxSiteAddressNumber.Text = SafeGetString(row.Item("SiteAddressNumber"))
        TextBoxSiteAddressPLZ.Text = SafeGetString(row.Item("SiteAddressZIP"))
        TextBoxSiteAddressCity.Text = SafeGetString(row.Item("SiteAddressCity"))
        TextBoxSiteAddressCountry.Text = SafeGetString(row.Item("SiteAddressCountry"))
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


