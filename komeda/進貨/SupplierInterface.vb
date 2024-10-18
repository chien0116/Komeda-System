Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class SupplierInterface
    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)
    Private Sub SupplierInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'supname.Text = SupplierLogin.ComboBox1.Text
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"
        'MsgBox(supname.Text)
        viewer()

        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("確定")
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0

        Button6.BackgroundImage = My.Resources.ResourceManager.GetObject("返回")
        Button6.BackColor = Color.Transparent
        Button6.BackgroundImageLayout = ImageLayout.Stretch
        Button6.FlatStyle = FlatStyle.Flat
        Button6.FlatAppearance.BorderSize = 0
    End Sub
    Private Sub viewer()
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select 食材名稱,進貨量,進貨編號,送達狀態 from 進貨  where 公司名稱 ='" + supname.Text + "' ", conn)
        da.Fill(dt)
        DataGridView1.DataSource = dt
        conn.Close()
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(1).Width = 80
        DataGridView1.Columns(2).Width = 80
        DataGridView1.Columns(2).Width = 80

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If String.IsNullOrWhiteSpace(ordernum.Text) Or String.IsNullOrWhiteSpace(money.Text) Then
                MessageBox.Show("請將資料輸入完整")
                Exit Sub
            End If
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            dt = New DataTable()
            da = New OleDbDataAdapter("select 食材名稱,進貨量,進貨編號,送達狀態 from 進貨 where 公司名稱 ='" + supname.Text + "' ", conn)
            da.Fill(dt)
            DataGridView1.DataSource = dt

            da.SelectCommand.Parameters.AddWithValue("@startDate", DateTimePicker1.Value.ToString("yyyy-MM-dd"))

            cmd.CommandText = "update 進貨 set 進貨日期 = '" + DateTimePicker1.Value.ToString("yyyy-MM-dd") + "',成本 ='" + money.Text + "',送達狀態 = '已送達' where 進貨編號 = '" + ordernum.Text + "'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "update 庫存 set 存量 = 存量+ '" + orderamount.Text + "' where 食材名稱 = '" + orderthing.Text + "'"
            cmd.ExecuteNonQuery()

            dt = New DataTable()
            da = New OleDbDataAdapter("select 食材名稱,進貨量,進貨編號,送達狀態 from 進貨 where 公司名稱 ='" + supname.Text + "' ", conn)
            da.Fill(dt)
            DataGridView1.DataSource = dt

            conn.Close()
            MessageBox.Show("已確認供貨")
        Catch ex As Exception
            MessageBox.Show("餐點編號不可重複 且 食材編號不可填寫不存在的")

        End Try
        ordernum.Text = ""
        money.Text = ""


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim f2 As New SupplierLogin()
        f2.Owner = Me
        f2.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            ordernum.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
            orderthing.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            orderamount.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
        Catch ex As Exception
            MessageBox.Show("請點擊食材編號前方那列")
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class