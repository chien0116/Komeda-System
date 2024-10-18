Public Class MenuManage
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim fmi As New ManageInterface()
        fmi.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim famc As New AddMenuClass()
        famc.Show()
        Me.Hide()
    End Sub

    Private Sub MenuManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("新餐品項")
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0

        Button2.BackgroundImage = My.Resources.ResourceManager.GetObject("修改餐點")
        Button2.BackColor = Color.Transparent
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderSize = 0

        Button3.BackgroundImage = My.Resources.ResourceManager.GetObject("刪除餐點")
        Button3.BackColor = Color.Transparent
        Button3.BackgroundImageLayout = ImageLayout.Stretch
        Button3.FlatStyle = FlatStyle.Flat
        Button3.FlatAppearance.BorderSize = 0

        Button4.BackgroundImage = My.Resources.ResourceManager.GetObject("查詢餐點")
        Button4.BackColor = Color.Transparent
        Button4.BackgroundImageLayout = ImageLayout.Stretch
        Button4.FlatStyle = FlatStyle.Flat
        Button4.FlatAppearance.BorderSize = 0

        Button6.BackgroundImage = My.Resources.ResourceManager.GetObject("返回")
        Button6.BackColor = Color.Transparent
        Button6.BackgroundImageLayout = ImageLayout.Stretch
        Button6.FlatStyle = FlatStyle.Flat
        Button6.FlatAppearance.BorderSize = 0
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fdf As New DelFood()
        fdf.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fcm As New ChangeMenu()
        fcm.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim fsf As New Searchfood()
        fsf.Show()
        Me.Hide()
    End Sub
End Class