﻿Imports System.Data.OleDb
Public Class SearchStore
    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"
        viewer()

        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("查詢")
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0

        Button2.BackgroundImage = My.Resources.ResourceManager.GetObject("返回")
        Button2.BackColor = Color.Transparent
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderSize = 0

        Button3.BackgroundImage = My.Resources.ResourceManager.GetObject("重整")
        Button3.BackColor = Color.Transparent
        Button3.BackgroundImageLayout = ImageLayout.Stretch
        Button3.FlatStyle = FlatStyle.Flat
        Button3.FlatAppearance.BorderSize = 0
    End Sub
    Private Sub viewer()
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select * from 庫存 ", conn)
        da.Fill(dt)
        DataGridView1.DataSource = dt
        conn.Close()
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(1).Width = 80
        DataGridView1.Columns(2).Width = 80

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim checker As Integer
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from 庫存 where 食材編號 = '" + materialnum.Text + "'or 食材名稱 = '" + materialname.Text + "'"
            cmd.ExecuteNonQuery()
            dt = New DataTable()
            da = New OleDbDataAdapter(cmd)
            da.Fill(dt)
            checker = Convert.ToInt32(dt.Rows.Count.ToString)
            DataGridView1.DataSource = dt
            conn.Close()

            If (checker = 0) Then

            End If
            'viewer()
        Catch ex As Exception
            MessageBox.Show("所需資料請輸入完整")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f5 As New StoreManage()
        f5.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            materialnum.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            materialname.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
        Catch ex As Exception
            MessageBox.Show("請點擊食材編號前方那列")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dt = New DataTable()
        da = New OleDbDataAdapter("select * from 庫存 ", conn)
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub
End Class