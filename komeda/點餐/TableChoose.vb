Imports System.Data.OleDb
Public Class TableChoose
    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"

        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0

        Button2.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button2.BackColor = Color.Transparent
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderSize = 0

        Button3.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button3.BackColor = Color.Transparent
        Button3.BackgroundImageLayout = ImageLayout.Stretch
        Button3.FlatStyle = FlatStyle.Flat
        Button3.FlatAppearance.BorderSize = 0

        Button4.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button4.BackColor = Color.Transparent
        Button4.BackgroundImageLayout = ImageLayout.Stretch
        Button4.FlatStyle = FlatStyle.Flat
        Button4.FlatAppearance.BorderSize = 0

        Button5.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button5.BackColor = Color.Transparent
        Button5.BackgroundImageLayout = ImageLayout.Stretch
        Button5.FlatStyle = FlatStyle.Flat
        Button5.FlatAppearance.BorderSize = 0

        Button11.BackgroundImage = My.Resources.ResourceManager.GetObject("返回")
        Button11.BackColor = Color.Transparent
        Button11.BackgroundImageLayout = ImageLayout.Stretch
        Button11.FlatStyle = FlatStyle.Flat
        Button11.FlatAppearance.BorderSize = 0

        Button12.BackgroundImage = My.Resources.ResourceManager.GetObject("刪除訂單")
        Button12.BackColor = Color.Transparent
        Button12.BackgroundImageLayout = ImageLayout.Stretch
        Button12.FlatStyle = FlatStyle.Flat
        Button12.FlatAppearance.BorderSize = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f2 As New Order()
        f2.Owner = Me
        f2.tablenum.Text = Button1.Text
        f2.Show()
        Me.Hide()
        Button6.Visible = True
        Button6.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f2 As New Order()
        f2.Owner = Me
        f2.tablenum.Text = Button2.Text
        f2.Show()
        Me.Hide()
        Button7.Visible = True
        Button7.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f2 As New Order()
        f2.Owner = Me
        f2.tablenum.Text = Button3.Text
        f2.Show()
        Me.Hide()
        Button8.Visible = True
        Button8.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim f2 As New Order()
        f2.Owner = Me
        f2.tablenum.Text = Button4.Text
        f2.Show()
        Me.Hide()
        Button9.Visible = True
        Button9.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f2 As New Order()
        f2.Owner = Me
        f2.tablenum.Text = Button5.Text
        f2.Show()
        Me.Hide()
        Button10.Visible = True
        Button10.Enabled = True
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim f2 As New StartForm()
        f2.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim f2 As New Pay()
        f2.Label2.Text = Button2.Text
        f2.Show()
        Me.Hide()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim f2 As New DelOrder()
        f2.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim f2 As New Pay()
        f2.Label2.Text = Button1.Text
        f2.Show()
        Me.Hide()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim f2 As New Pay()
        f2.Label2.Text = Button3.Text
        f2.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim f2 As New Pay()
        f2.Label2.Text = Button4.Text
        f2.Show()
        Me.Hide()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim f2 As New Pay()
        f2.Label2.Text = Button5.Text
        f2.Show()
        Me.Hide()
    End Sub
End Class
