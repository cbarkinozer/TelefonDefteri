Public Class Form2
    Dim i As Integer


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'ekle
        Try
            Button2.Visible = False
            Dim insertQuery As String = "INSERT INTO telefonDefteri (ad,soyad,eposta,yas,postaKodu,okulNo) " _
            & " VALUES " & "('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "'," _
            & TextBox4.Text & ",'" & TextBox5.Text & "','" & TextBox6.Text & "')"

            Form1.ExecuteQuery(insertQuery)

            Form1.loadData()

            MessageBox.Show("Kişi eklendi")

            Dim X As Control
            For Each X In Me.Controls
                If TypeOf X Is TextBox Then
                    X.Text = ""
                End If
            Next X
        Catch ex As Exception
            MsgBox("adding error" & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'güncelle
        Try
            Button1.Visible = False
            Form1.displayData()
            i = Form1.DataGridView1.SelectedCells.Item(0).Value
            Dim updateQuery As String = " UPDATE telefonDefteri SET ad ='" + TextBox1.Text + "' ,soyad= '" + TextBox2.Text + "' ,eposta='" + TextBox3.Text +
            "' ,yas='" + TextBox4.Text + "' ,postaKodu='" + TextBox5.Text + "' ,okulNo='" + TextBox6.Text + "'  where telefonDefteriID= " & i & ""

            Form1.ExecuteQuery(updateQuery)

            Form1.loadData()

            MessageBox.Show("Kişiler güncellendi")

            Dim X As Control
            For Each X In Me.Controls
                If TypeOf X Is TextBox Then
                    X.Text = ""
                End If
            Next X


        Catch ex As Exception
            MsgBox("update error" & ex.Message)
        End Try

    End Sub
End Class
