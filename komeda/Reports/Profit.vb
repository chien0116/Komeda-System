Imports System.Data.OleDb
Public Class Profit
    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)
    Dim dt2 As New DataTable
    Dim da2 As New OleDbDataAdapter(cmd)
    Private Sub Profit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"
        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        da = New OleDbDataAdapter("select 食材名稱,成本,進貨日期 from 進貨 where 送達狀態 = '已送達' ", conn)
        da.Fill(dt)
        DataGridView1.DataSource = dt

        da2 = New OleDbDataAdapter("select 品名,價錢,日期 from 訂單 where 付款狀態 ='1' ", conn)
        da2.Fill(dt2)
        DataGridView2.DataSource = dt2

        Dim totalAmount As Decimal = 0
        Dim query As String = "SELECT SUM(價錢) FROM 訂單 where 付款狀態 = '1'"
        Using cmd As New OleDbCommand(query, conn)
            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot DBNull.Value Then
                totalAmount = Convert.ToDecimal(result)
            End If
        End Using
        Label4.Text = totalAmount.ToString


        Dim totalAmount2 As Decimal = 0
        Dim query2 As String = "SELECT SUM(成本) FROM 進貨 where 送達狀態 = '已送達'"
        Using cmd2 As New OleDbCommand(query2, conn)
            Dim result2 As Object = cmd2.ExecuteScalar()
            If result2 IsNot DBNull.Value Then
                totalAmount2 = Convert.ToDecimal(result2)
            End If
        End Using
        Label5.Text = totalAmount2.ToString

        Label6.Text = Label4.Text - Label5.Text
        conn.Close()
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(1).Width = 80
        DataGridView1.Columns(2).Width = 80
        DataGridView2.Columns(0).Width = 80
        DataGridView2.Columns(1).Width = 80
        DataGridView2.Columns(2).Width = 80

        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("刷新")
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

        dt = New DataTable()
        da = New OleDbDataAdapter("select 食材名稱,成本,進貨日期 from 進貨 where 進貨日期 between ? AND ? AND 送達狀態 = '已送達'", conn)
        da.SelectCommand.Parameters.AddWithValue("@startDate", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
        da.SelectCommand.Parameters.AddWithValue("@endDate", DateTimePicker2.Value.ToString("yyyy-MM-dd"))
        da.Fill(dt)
        DataGridView1.DataSource = dt

        dt2 = New DataTable()
        da2 = New OleDbDataAdapter("select 品名,價錢,日期 from 訂單 where 日期 between ? AND ? and 付款狀態 ='1'", conn)
        da2.SelectCommand.Parameters.AddWithValue("@startDate", DateTimePicker1.Value.ToString("yyyy-MM-dd")) '?意思是插入值在這兩行
        da2.SelectCommand.Parameters.AddWithValue("@endDate", DateTimePicker2.Value.ToString("yyyy-MM-dd"))
        da2.Fill(dt2)
        DataGridView2.DataSource = dt2

        conn.Open()
        Dim totalAmount As Decimal = 0
        Dim query As String = "SELECT SUM(價錢) FROM 訂單 where 日期 between '" + DateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + DateTimePicker2.Value.ToString("yyyy-MM-dd") + "' AND 付款狀態='1'"
        Using cmd As New OleDbCommand(query, conn)
            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot DBNull.Value Then
                totalAmount = Convert.ToDecimal(result)
            End If
        End Using
        Label4.Text = totalAmount.ToString

        Dim totalAmount2 As Decimal = 0
        Dim query2 As String = "SELECT SUM(成本) FROM 進貨 where 送達狀態 = '已送達' AND 進貨日期 between '" + DateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + DateTimePicker2.Value.ToString("yyyy-MM-dd") + "'"
        Using cmd2 As New OleDbCommand(query2, conn)
            Dim result2 As Object = cmd2.ExecuteScalar()
            If result2 IsNot DBNull.Value Then
                totalAmount2 = Convert.ToDecimal(result2)
            End If
        End Using
        conn.Close()
        Label5.Text = totalAmount2.ToString

        Label6.Text = Label4.Text - Label5.Text

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fsm As New ChooseReport()
        fsm.Show()
        Me.Hide()
    End Sub
End Class