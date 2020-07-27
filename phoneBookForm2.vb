Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class Form2
    Dim con As New SqlConnection("Server=DESKTOP-E5T285L;Database= telefonRehberi;Integrated Security =true")
    Dim cmd As New SqlCommand
    Dim i As Integer

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Me.Tag <> "" Then

            'veri çekilip gösterilecek
            displayData()

        End If

    End Sub
    Public Sub displayData()
        'show selected rows on input boxes
        Try
            'check connection
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Open()

            Dim command As New SqlCommand("SELECT ad,soyad,eposta,yas,postaKodu,okulNo FROM telefonDefteri WHERE telefonDefteriID = '" Me.Tag"' ", con)
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = Me.Tag

            Dim conn As SqlConnection = New SqlConnection()
            Dim constr As String = "Data Source=Localhost;Initial Catalog=telefonRehberi;Persist Security Info=true;" _
            & "user ID=sa;Password= ***;"
            conn.ConnectionString = constr
            Dim cmd As SqlCommand = New SqlCommand()
            conn.Open()

            cmd.CommandText = ""

            conn.Close()

            TextBoxIsim.Text = "SELECT ad FROM telefonDefteri WHERE telefonDefteriID =Me.Tag"
            TextBoxSoyisim.Text = "SELECT soyad FROM telefonDefteri WHERE telefonDefteriID =Me.Tag"
            TextBoxEposta.Text = "SELECT eposta FROM telefonDefteri WHERE telefonDefteriID =Me.Tag"
            TextBoxYas.Text = "SELECT yas FROM telefonDefteri WHERE telefonDefteriID =Me.Tag"
            TextBoxPostaKodu.Text = "SELECT postaKodu FROM telefonDefteri WHERE telefonDefteriID =Me.Tag"
            TextBoxOkulNumarasi.Text = "SELECT okulNo FROM telefonDefteri WHERE telefonDefteriID =Me.Tag"

            command.ExecuteNonQuery()

            con.Close()
        Catch ex As Exception
            MsgBox("Display data error" & ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonKaydet.Click
        'kaydet butonu

        'differentiate update and add
        If (Me.Tag <> "") Then

            'güncelle
            Try



                'sql command
                Dim command As New SqlCommand("UPDATE TelefonDefteri SET ad = @name ,soyad = @surname ,eposta = @email,
                    yas=@age,postaKodu=@postCode,okulNo=@stdNo WHERE telefonDefteriID = @id ", con)

                'sql injection security parameters



                command.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBoxIsim.Text
                command.Parameters.Add("@surname", SqlDbType.VarChar).Value = TextBoxSoyisim.Text
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBoxEposta.Text
                command.Parameters.Add("@age", SqlDbType.Int).Value = TextBoxYas.Text
                command.Parameters.Add("@postCode", SqlDbType.VarChar).Value = TextBoxPostaKodu.Text
                command.Parameters.Add("@stdNo", SqlDbType.VarChar).Value = TextBoxOkulNumarasi.Text


                'check connection state
                If ConnectionState.Open Then
                    con.Close()
                End If
                'open connection
                con.Open()
                'execute command
                command.ExecuteNonQuery()

                MessageBox.Show("Kayıt güncellendi")
                Form1.loadData()


                ' close connection
                con.Close()


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
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBoxIsim.Text
                command.Parameters.Add("@surname", SqlDbType.VarChar).Value = TextBoxSoyisim.Text
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBoxEposta.Text
                command.Parameters.Add("@age", SqlDbType.Int).Value = TextBoxYas.Text
                command.Parameters.Add("@pcode", SqlDbType.VarChar).Value = TextBoxPostaKodu.Text
                command.Parameters.Add("@sno", SqlDbType.VarChar).Value = TextBoxOkulNumarasi.Text

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
