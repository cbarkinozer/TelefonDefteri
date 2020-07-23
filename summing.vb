Public Class Form1
    Dim sayi1 As Integer
    Dim sayi2 As Integer
    Dim sayi3 As Integer

    Private Sub Topla_Click(sender As Object, e As EventArgs) Handles Topla.Click
        sayi3 = sayi1 + sayi2
        TextBox3.Text = sayi3
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text.Contains(",") Then
            Try

                sayi1 = CSng(TextBox1.Text)


            Catch sinirHata As IndexOutOfRangeException

                sayi1 = CDbl(TextBox1.Text)
            End Try
            GoTo son
        End If



        Try
            sayi1 = CInt(TextBox1.Text)
        Catch tipHata As System.InvalidCastException
            MsgBox("Lütfen tamsayı girin. " & tipHata.Message)
        Catch hata As Exception
            MsgBox("Bilinmeyen hata. " & hata.Message)
        End Try
son:
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        If TextBox1.Text.Contains(",") Then
            Try

                sayi1 = CSng(TextBox1.Text)


            Catch sinirHata As IndexOutOfRangeException

                sayi1 = CDbl(TextBox1.Text)
            End Try
            GoTo son
        End If




        Try
            sayi2 = CInt(TextBox2.Text)
        Catch tipHata As System.InvalidCastException
            MsgBox("Lütfen tamsayı girin. " & tipHata.Message)
        Catch hata As Exception
            MsgBox("Bilinmeyen hata. " & hata.Message)
        End Try
son:
    End Sub


End Class
