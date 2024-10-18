Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class ChooseReport
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim fsm As New ManageInterface()
        fsm.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fsm As New PurchaseReport()
        fsm.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fsm As New TradeReport()
        fsm.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fsm As New Profit()
        fsm.Show()
        Me.Hide()
    End Sub

    Private Sub ChooseReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("進貨紀錄")
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0

        Button2.BackgroundImage = My.Resources.ResourceManager.GetObject("銷售紀錄")
        Button2.BackColor = Color.Transparent
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderSize = 0

        Button3.BackgroundImage = My.Resources.ResourceManager.GetObject("盈餘")
        Button3.BackColor = Color.Transparent
        Button3.BackgroundImageLayout = ImageLayout.Stretch
        Button3.FlatStyle = FlatStyle.Flat
        Button3.FlatAppearance.BorderSize = 0

        Button6.BackgroundImage = My.Resources.ResourceManager.GetObject("返回")
        Button6.BackColor = Color.Transparent
        Button6.BackgroundImageLayout = ImageLayout.Stretch
        Button6.FlatStyle = FlatStyle.Flat
        Button6.FlatAppearance.BorderSize = 0
    End Sub
End Class