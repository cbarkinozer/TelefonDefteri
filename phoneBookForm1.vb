Imports System.Data.SqlClient
Public Class Form1
    Dim con As New SqlConnection("Server=DESKTOP-E5T285L;Database= telefonRehberi;Integrated Security =true")
    Dim cmd As New SqlCommand
    Dim i As Integer
    Dim newForm2 As New Form2


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TelefonRehberiDataSet.telefonDefteri' table. You can move, or remove it, as needed.
        Me.TelefonDefteriTableAdapter.Fill(Me.TelefonRehberiDataSet.telefonDefteri)


    End Sub
    Public Sub loadData()
        'refresh the gridview
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
        'show selected rows on input boxes
        Try

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            DataGridView1.DataSource = dt
            con.Close()
        Catch ex As Exception
            MsgBox("Display data error" & ex.Message)
        End Try

    End Sub
    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'add button

        newForm2.Tag = DataGridView1.SelectedRows.Item(1).ToString()
        newForm2.ShowDialog()


    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'update button

        newForm2.Tag = DataGridView1.SelectedRows.Item(0).ToString()
        newForm2.ShowDialog()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        'delete button

        Try
            If DataGridView1.SelectedRows.Count > 0 Then

                Dim deleteQuery As String = "DELETE FROM telefonDefteri WHERE telefonDefteriID= " & i & ""
                ExecuteQuery(deleteQuery)

            Else
                MessageBox.Show("No rows to select")
            End If

            MessageBox.Show("Kişi silindi")

            loadData()
        Catch ex As Exception
            MsgBox("delete error" & ex.Message)
        End Try


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'choose row to show in input boxes
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
            Dim dr As SqlClient.SqlDataReader

            da.Fill(dt)

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While dr.Read
                Form2.TextBox1.Text = dr.GetString(1).ToString()
                Form2.TextBox2.Text = dr.GetString(2).ToString()
                Form2.TextBox3.Text = dr.GetString(3).ToString()
                Form2.TextBox4.Text = dr.GetString(4).ToString()
                Form2.TextBox5.Text = dr.GetString(5).ToString()
                Form2.TextBox6.Text = dr.GetString(6).ToString()
            End While


        Catch hata As Exception
            MsgBox("DataGridView_Click error. " & hata.Message)
        End Try

    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub
End Class
