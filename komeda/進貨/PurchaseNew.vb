Imports System.Data.OleDb
Imports System.Runtime.Remoting.Metadata.W3cXsd2001

Public Class PurchaseNew
    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)
    'Dim a As String = "0"
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"
        viewer()

        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("確定")
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0

        Button2.BackgroundImage = My.Resources.ResourceManager.GetObject("返回")
        Button2.BackColor = Color.Transparent
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderSize = 0
    End Sub
    Private Sub viewer()
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select 食材名稱,存量 from 庫存 ", conn)
        da.Fill(dt)
        DataGridView1.DataSource = dt
        conn.Close()
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(1).Width = 80



    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim rand As Integer
            rand = GetRandom(1, 1000)
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "insert into 進貨(公司名稱,食材名稱,進貨量,進貨編號)values('" + ComboBox1.Text +
        "', '" + TextBox1.Text + "','" + TextBox2.Text + "','" & rand & "')"
            'a = a + 1
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("新增進貨成功,請等待供應商回應")
        Catch ex As Exception
            MessageBox.Show("所需資料請輸入完整")
        End Try
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f5 As New ManageInterface()
        f5.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()

        Catch ex As Exception
            MessageBox.Show("請點擊品名前方那列")
        End Try
    End Sub
End Class