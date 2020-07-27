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


            'sql command
            Dim command As New SqlCommand("DELETE telefonDefteri  WHERE telefonDefteriID = = " & Me.Tag, con)

            command.Parameters.Add("@id", SqlDbType.Int).Value = Me.DataGridView1.CurrentRow.Cells("telefonDefteriID").Value

            If ConnectionState.Open Then
                con.Close()
            End If

            'open connection
            con.Open()

            'execute
            command.ExecuteNonQuery()

            'refresh table
            loadData()
            con.Close()

            MessageBox.Show("Kişi silindi")



        Catch ex As Exception
            MsgBox("delete error" & ex.Message)
        End Try


    End Sub


    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
