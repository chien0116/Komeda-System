Imports System.Data.OleDb
Imports System.Runtime.Remoting.Metadata.W3cXsd2001

Public Class SupplierLogin
    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dr As OleDbDataReader
        Dim checker As Integer

        Try
            conn.Open()
            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from 供應商 where 公司名稱 = '" + ComboBox1.Text + "'and 密碼 = '" + TextBox2.Text + "'"
            dr = cmd.ExecuteReader()
            checker = 0

            Do While (dr.Read())
                checker = checker + 1
            Loop

            If (checker = 1) Then
                MessageBox.Show("登錄成功")
                Dim f2 As New SupplierInterface()
                f2.Owner = Me
                f2.supname.Text = ComboBox1.Text
                f2.Show()
                Me.Hide()

            Else
                MessageBox.Show("登錄失敗")
            End If

            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SupplierLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"

        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("登錄")
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim f2 As New StartForm()
        f2.Show()
        Me.Hide()
    End Sub
End Class