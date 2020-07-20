Public Class Form1
    Dim sayi1 As Integer
    Dim sayi2 As Integer
    Dim sayi3 As Integer

    Private Sub Topla_Click(sender As Object, e As EventArgs) Handles Topla.Click
        sayi3 = sayi1 + sayi2
        TextBox3.Text = sayi3
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            sayi1 = CInt(TextBox1.Text)
        Catch tipHata As System.InvalidCastException
            MsgBox("Lütfen tamsayı girin. " & tipHata.Message)
        Catch hata As Exception
            MsgBox("Bilinmeyen hata. " & hata.Message)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Try
            sayi2 = CInt(TextBox2.Text)
        Catch tipHata As System.InvalidCastException
            MsgBox("Lütfen tamsayı girin. " & tipHata.Message)
        Catch hata As Exception
            MsgBox("Bilinmeyen hata. " & hata.Message)
        End Try

    End Sub


End Class
