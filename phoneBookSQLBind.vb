Imports System.Data.SqlClient
Public Class Form1
    Dim connection As New SqlConnection("Server=DESKTOP-E5T285L;Database= telefonRehberi;Integrated Security =true")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Public Sub ExecuteQuery(query As String)
        Dim command As New SqlCommand(query, connection)

        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'ekle butonu
        Dim insertQuery As String = "INSERT INTO phoneBook(ad,soyad,e-posta,yas,postaKodu,okulNo) VALUES(' & TextBox1.Text',' &TextBox2.Text','&TextBox3.Text','&TextBox4.Text','&TextBox5.Text','&TextBox6')"
        ExecuteQuery(insertQuery)
        MessageBox.Show("Kişi eklendi")
        Dim X As Control
        For Each X In Me.Controls
            If TypeOf X Is TextBox Then
                X.Text = ""
            End If
        Next X
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'update butonu
        Dim updateQuery As String = "Update phoneBook Set ad= ' & TextBox1.Text', soyad= '&TextBox2.Text',e-posta= ' & TextBox3.Text',yas= '& TextBox4.Text',postaKodu='& TextBox5.Text',okulNo= '& TextBox6.Text'"
        ExecuteQuery(updateQuery)
        MessageBox.Show("Kişiler güncellendi")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'delete butonu
        'Dim deleteQuery As String = " "
        ' ExecuteQuery(deleteQuery)
        'MessageBox.Show("Kişi silindi")
    End Sub
End Class