Imports System.Data.SqlClient
Public Class Form1
    Dim con As New SqlConnection("Server=DESKTOP-E5T285L;Database= telefonRehberi;Integrated Security =true")
    Dim cmd As New SqlCommand
    Dim i As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TelefonRehberiDataSet.telefonDefteri' table. You can move, or remove it, as needed.
        Me.TelefonDefteriTableAdapter.Fill(Me.TelefonRehberiDataSet.telefonDefteri)


    End Sub
    Private Sub loadData()
        Try
            Dim Str As String = "SELECT * FROM telefonDefteri"
            con.Open()
            Dim Search As New SqlDataAdapter(Str, con)
            Dim ds As DataSet = New DataSet
            Search.Fill(ds, "telefonDefteri")
            DataGridView1.DataSource = ds.Tables("telefonDefteri")
            con.Close()
        Catch ex As Exception
            MsgBox("loading data error" & ex.Message)
            con.Close()
        End Try
    End Sub
    Public Sub ExecuteQuery(query As String)
        Dim command As New SqlCommand(query, con)

        con.Open()
        command.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub displayData()
        Try
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            DataGridView1.DataSource = dt

        Catch ex As Exception
            MsgBox("ldisplay data error" & ex.Message)
        End Try

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'ekle butonu
        Try
            Dim insertQuery As String = "INSERT INTO telefonDefteri (ad,soyad,eposta,yas,postaKodu,okulNo) " _
            & " VALUES " & "('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "'," _
            & TextBox4.Text & ",'" & TextBox5.Text & "','" & TextBox6.Text & "')"

            ExecuteQuery(insertQuery)



            loadData()


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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'güncelle butonu
        Try
            Dim updateQuery As String = " UPDATE telefonDefteri SET ad ='" + TextBox1.Text + "' ,soyad= '" + TextBox2.Text + "' ,eposta='" + TextBox3.Text +
            "' ,yas='" + TextBox4.Text + "' ,postaKodu='" + TextBox5.Text + "' ,okulNo='" + TextBox6.Text + "'  where telefonDefteriID= " & i & ""
            ExecuteQuery(updateQuery)
            displayData()
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'sil butonu
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                Dim deleteQuery As String = "DELETE FROM telefonDefteri WHERE telefonDefteriID= " & i & ""
                ExecuteQuery(deleteQuery)
            Else
                MessageBox.Show("No rows to select")
            End If
            MessageBox.Show("Kişi silindi")

        Catch ex As Exception
            MsgBox("delete error" & ex.Message)
        End Try


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()

            i = DataGridView1.SelectedCells.Item(0).Value
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read
                TextBox1.Text = dr.GetString(1).ToString()
                TextBox2.Text = dr.GetString(2).ToString()
                TextBox3.Text = dr.GetString(3).ToString()
                TextBox4.Text = dr.GetString(4).ToString()
                TextBox5.Text = dr.GetString(5).ToString()
                TextBox6.Text = dr.GetString(6).ToString()
            End While
        Catch hata As Exception
            MsgBox("DataGridView_Click error. " & hata.Message)
        End Try

    End Sub

End Class
