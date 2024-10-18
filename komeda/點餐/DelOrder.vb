Imports System.Data.OleDb

Public Class DelOrder

    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)

    Private bitmap As Bitmap
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f2 As New TableChoose()
        f2.Show()
        Me.Hide()
    End Sub
    Private Sub viewer()
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select * from 訂單 ", conn)
        da.Fill(dt)
        DataGridView1.DataSource = dt
        conn.Close()
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(1).Width = 80
        DataGridView1.Columns(2).Width = 80
        DataGridView1.Columns(3).Width = 80
        DataGridView1.Columns(4).Width = 80
        DataGridView1.Columns(5).Width = 80

    End Sub
    Private Sub DelOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"
        viewer()

        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("刪除")
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                MessageBox.Show("請輸入編號")
                Exit Sub
            End If
            conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text

        'Dim reader As OleDbDataReader = cmd.ExecuteReader()
        cmd.CommandText = "DELETE * FROM 訂單 WHERE 訂單編號 = '" + TextBox1.Text + "'"
        cmd.ExecuteNonQuery()
        'cmd.CommandText = "UPDATE 庫存 set存量+  WHERE 食材名稱 IN (SELECT 品名 FROM 餐點  WHERE 餐點品名=(SELECT 訂單品名 FROM 訂單 WHERE 訂單編號 = '" + TextBox1.Text + "')) "
        'cmd.ExecuteNonQuery()
        dt = New DataTable()
            da = New OleDbDataAdapter("select * from 訂單 ", conn)
            da.Fill(dt)
            DataGridView1.DataSource = dt

            conn.Close()
            MessageBox.Show("刪除訂單成功")

            'Catch ex As Exception
        '   MessageBox.Show("所需資料請輸入完整")
        ' End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        Catch ex As Exception
            MessageBox.Show("請點擊訂單編號前方那列")
        End Try
    End Sub
End Class