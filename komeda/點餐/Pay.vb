Imports System.Data.OleDb
Public Class Pay
    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)
    Private Sub Pay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"

        conn.Open()
        cmd = New OleDbCommand("SELECT SUM(價錢) FROM 訂單 WHERE 桌號 =  '" + Label2.Text + "'  AND 付款狀態 = '0' ", conn)
        Dim result As Object = cmd.ExecuteScalar()
        If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
            Dim totalAmount As Integer = Convert.ToInt32(result)
            Label4.Text = totalAmount
        Else
            Label4.Text = "不用付錢"
        End If
        'Dim totalAmount As Integer
        'totalAmount = Convert.ToInt32(cmd.ExecuteScalar())

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = New OleDbCommand("UPDATE 訂單 SET 付款狀態 = '1' WHERE 桌號 = '" + Label2.Text + "' AND 付款狀態 = '0'", conn)
        cmd.ExecuteNonQuery()
        conn.Close()
        Dim moneyback As Integer = TextBox1.Text - Label4.Text
        MessageBox.Show("找零: " & moneyback)
        Dim f2 As New StartForm()
        f2.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f2 As New TableChoose()
        f2.Show()
        Me.Hide()
    End Sub
End Class