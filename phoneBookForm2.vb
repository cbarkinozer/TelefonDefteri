Imports System.Data.SqlClient
Public Class Form2
    Dim con As New SqlConnection("Server=DESKTOP-E5T285L;Database= telefonRehberi;Integrated Security =true")
    Dim cmd As New SqlCommand
    Dim i As Integer


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'kaydet


        If (Tag = 0) Then
            'güncelle
            Try
                Form1.displayData() 'show selected row
                i = Form1.DataGridView1.SelectedRows.Item(0).ToString 'get selected row

                If i = "" Then ' be sure its not empty
                    MessageBox.Show("Empty Id")

                Else
                    'sql command
                    Dim command As New SqlCommand("UPDATE Users SET ad = @name ,soyad = @surname ,eposta = @email, _
                    yas=@age,postaKodu=@pcode,okulNo=@sno WHERE telefonDefteriID = @id", con)

                    'sql injection security parameters
                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text
                    command.Parameters.Add("@surname", SqlDbType.VarChar).Value = TextBox2.Text
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBox3.Text
                    command.Parameters.Add("@age", SqlDbType.Int).Value = TextBox4.Text
                    command.Parameters.Add("@pcode", SqlDbType.VarChar).Value = TextBox5.Text
                    command.Parameters.Add("@sno", SqlDbType.VarChar).Value = TextBox6.Text

                    con.Open()

                    If command.ExecuteNonQuery() = 1 Then
                        MessageBox.Show("Data Updated")

                    Else
                        MessageBox.Show("Data Not Updated")
                    End If

                    con.Close()

                End If



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



        ElseIf (Tag = 1) Then
            'ekle
            Try

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

        End If

    End Sub
End Class
