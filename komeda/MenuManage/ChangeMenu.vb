Imports System.Data.OleDb

Public Class ChangeMenu
    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)

    Dim cmd_2 As OleDbCommand
    Dim conn_2 As New OleDbConnection
    Dim dt_2 As New DataTable
    Dim da_2 As New OleDbDataAdapter(cmd)
    ' Dim cmd_2 As OleDbCommand
    Private Sub ChangeMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"
        viewer()

        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("修改")
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
        da = New OleDbDataAdapter("select * from 餐點 ", conn)
        da.Fill(dt)
        DataGridView1.DataSource = dt
        conn.Close()
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(1).Width = 80
        DataGridView1.Columns(2).Width = 80
        DataGridView1.Columns(3).Width = 80
        '-----------------------------------
        DataGridView2.DataSource = Nothing
        DataGridView2.Refresh()

        conn.Open()
        cmd_2 = conn.CreateCommand()
        cmd_2.CommandType = CommandType.Text
        da_2 = New OleDbDataAdapter("select 食材編號,食材名稱 from 庫存 ", conn)
        da_2.Fill(dt_2)
        DataGridView2.DataSource = dt_2
        conn.Close()
        DataGridView2.Columns(0).Width = 80
        'DataGridView2.Columns(1).Width = 80
        'DataGridView2.Columns(2).Width = 80

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        If String.IsNullOrWhiteSpace(materialnum.Text) Or String.IsNullOrWhiteSpace(amount.Text) Or String.IsNullOrWhiteSpace(elementName.Text) Then
                MessageBox.Show("請將資料輸入完整")
                Exit Sub
            End If

            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
        cmd.CommandText = "Update 餐點 Set 品名 ='" + materialnum.Text + "',金額 = '" + money.Text + "', 食材編號 = '" + elementName.Text + "',所需食材量='" + amount.Text + "'WHERE '" + elementName.Text + "' IN (SELECT 食材編號 FROM 庫存)And 餐點編號 ='" + foodnum.Text + "' "


        cmd.ExecuteNonQuery()

            dt = New DataTable()
            da = New OleDbDataAdapter("select * from 餐點 ", conn)
            da.Fill(dt)
            DataGridView1.DataSource = dt

            conn.Close()
            MessageBox.Show("已修改餐點")
            'Catch ex As Exception
        ' MessageBox.Show("所需資料請輸入正確且完整")
        'End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fmm As New MenuManage()
        fmm.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            foodnum.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            materialnum.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            money.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
            elementName.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
            amount.Text = DataGridView1.SelectedRows(0).Cells(8).Value.ToString()
        Catch ex As Exception
            MessageBox.Show("請點擊品名前方那列")
        End Try
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Try

            elementName.Text = DataGridView2.SelectedRows(0).Cells(0).Value.ToString()

        Catch ex As Exception
            MessageBox.Show("請點擊食材編號前方那列")
        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class