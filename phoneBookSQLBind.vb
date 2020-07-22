Imports System.Data.SqlClient
Public Class Form1
    Dim connection As New SqlConnection("Server=DESKTOP-E5T285L;Database= telefonRehberi;Integrated Security =true")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TelefonRehberiDataSet.telefonDefteri' table. You can move, or remove it, as needed.
        Me.TelefonDefteriTableAdapter.Fill(Me.TelefonRehberiDataSet.telefonDefteri)


    End Sub
    Public Sub ExecuteQuery(query As String)
        Dim command As New SqlCommand(query, connection)

        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'ekle butonu
        Dim insertQuery As String = "INSERT INTO telefonDefteri (ad,soyad,eposta,yas,postaKodu,okulNo) " _
        & " VALUES " _
        & "('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "'," _
        & TextBox4.Text & ",'" & TextBox5.Text & "','" & TextBox6.Text & "')"
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
        'güncelle butonu
        Dim updateQuery As String = "Update telefonDefteri Set ad= '" & TextBox1.Text & "', soyad= '" & TextBox2.Text & "',e-posta= '" _
        & TextBox3.Text & "', yas='" & TextBox4.Text & "',postaKodu='" & TextBox5.Text & "',okulNo= '" & TextBox6.Text & "' "
        ExecuteQuery(updateQuery)
        MessageBox.Show("Kişiler güncellendi")
        Dim X As Control
        For Each X In Me.Controls
            If TypeOf X Is TextBox Then
                X.Text = ""
            End If
        Next X
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'sil butonu
        'Dim deleteQuery As String = " "
        ' ExecuteQuery(deleteQuery)
        'MessageBox.Show("Kişi silindi")
    End Sub
End Class
