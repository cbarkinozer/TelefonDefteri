Imports System.Data.SqlClient
Public Class Form2
    Dim con As New SqlConnection("Server=DESKTOP-E5T285L;Database= telefonRehberi;Integrated Security =true")
    Dim cmd As New SqlCommand
    Dim i As Integer

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Me.Tag <> "" Then

            'veri çekilip gösterilecek...

            Form1.displayData() 'show selected row
            i = Form1.DataGridView1.SelectedRows.Item(0).ToString 'get selected row

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'kaydet butonu

        'differentiate update and add
        If (Me.Tag <> "") Then
            'güncelle
            Try


                If i = "" Then ' be sure its not empty
                    MessageBox.Show("Güncellenecek kayıt yok")

                Else
                    'sql command
                    Dim command As New SqlCommand("UPDATE TelefonDefteri SET ad = @name ,soyad = @surname ,eposta = @email,
                    yas=@age,postaKodu=@postCode,okulNo=@stdNo WHERE telefonDefteriID = @id ", con)

                    'sql injection security parameters

                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text
                    command.Parameters.Add("@surname", SqlDbType.VarChar).Value = TextBox2.Text
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBox3.Text
                    command.Parameters.Add("@age", SqlDbType.Int).Value = TextBox4.Text
                    command.Parameters.Add("@postCode", SqlDbType.VarChar).Value = TextBox5.Text
                    command.Parameters.Add("@stdNo", SqlDbType.VarChar).Value = TextBox6.Text
                    command.Parameters.Add("@id", SqlDbType.Int).Value = i


                    'check connection state
                    If ConnectionState.Open Then
                        con.Close()
                    End If
                    'open connection
                    con.Open()
                    'execute command
                    command.ExecuteNonQuery()

                    'check execution success
                    If command.ExecuteNonQuery() = 1 Then
                        MessageBox.Show("Kayıt güncellendi")
                        Form1.loadData()

                    Else
                        MessageBox.Show("Kayıt Güncellenemedi")
                    End If
                    ' close connection
                    con.Close()

                End If
                ' clear textboxes
                Dim X As Control
                For Each X In Me.Controls
                    If TypeOf X Is TextBox Then
                        X.Text = ""
                    End If
                Next X

            Catch ex As Exception
                MsgBox("update error " & ex.Message)
            End Try



        Else

            'ekle
            Try
                ' sql command
                Dim command As New SqlCommand("INSERT INTO TelefonDefteri(ad,soyad,eposta,yas,postaKodu,okulNo)
                Values(@name,@surname,@email,@age,@pcode,@sno) ", con)

                'sql injection security parameters
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text
                command.Parameters.Add("@surname", SqlDbType.VarChar).Value = TextBox2.Text
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBox3.Text
                command.Parameters.Add("@age", SqlDbType.Int).Value = TextBox4.Text
                command.Parameters.Add("@pcode", SqlDbType.VarChar).Value = TextBox5.Text
                command.Parameters.Add("@sno", SqlDbType.VarChar).Value = TextBox6.Text

                'check the connection state
                If ConnectionState.Open Then
                    con.Close()
                End If
                'open connection
                con.Open()
                'execute
                command.ExecuteNonQuery()

                MessageBox.Show("Kayıt eklendi")

                'refresh
                Form1.loadData()


                'close connection
                con.Close()

                'clear textboxes
                Dim X As Control
                For Each X In Me.Controls
                    If TypeOf X Is TextBox Then
                        X.Text = ""
                    End If
                Next X

            Catch ex As Exception
                MsgBox("adding error " & ex.Message)
            End Try

        End If

    End Sub
End Class
