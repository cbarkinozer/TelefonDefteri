Imports System.Data.SqlClient
Public Class Form1
    Dim con As New SqlConnection("Server=DESKTOP-E5T285L;Database= telefonRehberi;Integrated Security =true")
    Dim cmd As New SqlCommand
    Dim i As Integer 'holds selected id
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

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonEkle.Click
        'add button

        newForm2.ShowDialog()


    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonGuncelle.Click
        'update button

        newForm2.Tag = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        newForm2.ShowDialog()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ButtonSil.Click

        'delete button

        Try

            If MessageBox.Show("Do you really want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                MsgBox("Operation cancelled")
                Exit Sub
            End If


            ' sql command
            Dim command As New SqlCommand("DELETE FROM TelefonDefteri WHERE telefonDefteriID = " & Me.Tag, con)


            'check the connection state
            If ConnectionState.Open Then
                con.Close()
            End If

            'open connection
            con.Open()

            'execute
            command.ExecuteNonQuery()

            MessageBox.Show("Kayıt silindi")

            'refresh
            loadData()


            'close connection
            con.Close()



        Catch ex As Exception
            MsgBox("Delete error " & ex.Message)
        End Try


    End Sub


    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBoxAra_TextChanged(sender As Object, e As EventArgs) Handles TextBoxAra.TextChanged
        filterData("")
    End Sub
    Public Sub filterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * FROM telefonDefteri WHERE CONCAT(ad,soyad,eposta,yas,postaKodu,okulNo) like '%" & valueToSearch & "%'"
        Dim command As New SqlCommand(searchQuery, con)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub

    Private Sub ButtonAra_Click(sender As Object, e As EventArgs) Handles ButtonAra.Click
        filterData(TextBoxAra.Text)
    End Sub
End Class
