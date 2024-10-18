Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Order
    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)

    Private bitmap As Bitmap
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"

        Button1.BackgroundImage = My.Resources.ResourceManager.GetObject("新增")
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0

        Button2.BackgroundImage = My.Resources.ResourceManager.GetObject("返回")
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

        Button6.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button6.BackColor = Color.Transparent
        Button6.BackgroundImageLayout = ImageLayout.Stretch
        Button6.FlatStyle = FlatStyle.Flat
        Button6.FlatAppearance.BorderSize = 0

        Button7.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button7.BackColor = Color.Transparent
        Button7.BackgroundImageLayout = ImageLayout.Stretch
        Button7.FlatStyle = FlatStyle.Flat
        Button7.FlatAppearance.BorderSize = 0

        Button8.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button8.BackColor = Color.Transparent
        Button8.BackgroundImageLayout = ImageLayout.Stretch
        Button8.FlatStyle = FlatStyle.Flat
        Button8.FlatAppearance.BorderSize = 0

        Button9.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button9.BackColor = Color.Transparent
        Button9.BackgroundImageLayout = ImageLayout.Stretch
        Button9.FlatStyle = FlatStyle.Flat
        Button9.FlatAppearance.BorderSize = 0

        Button10.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button10.BackColor = Color.Transparent
        Button10.BackgroundImageLayout = ImageLayout.Stretch
        Button10.FlatStyle = FlatStyle.Flat
        Button10.FlatAppearance.BorderSize = 0

        Button11.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button11.BackColor = Color.Transparent
        Button11.BackgroundImageLayout = ImageLayout.Stretch
        Button11.FlatStyle = FlatStyle.Flat
        Button11.FlatAppearance.BorderSize = 0

        Button12.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button12.BackColor = Color.Transparent
        Button12.BackgroundImageLayout = ImageLayout.Stretch
        Button12.FlatStyle = FlatStyle.Flat
        Button12.FlatAppearance.BorderSize = 0

        Button13.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button13.BackColor = Color.Transparent
        Button13.BackgroundImageLayout = ImageLayout.Stretch
        Button13.FlatStyle = FlatStyle.Flat
        Button13.FlatAppearance.BorderSize = 0

        Button14.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button14.BackColor = Color.Transparent
        Button14.BackgroundImageLayout = ImageLayout.Stretch
        Button14.FlatStyle = FlatStyle.Flat
        Button14.FlatAppearance.BorderSize = 0

        Button15.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button15.BackColor = Color.Transparent
        Button15.BackgroundImageLayout = ImageLayout.Stretch
        Button15.FlatStyle = FlatStyle.Flat
        Button15.FlatAppearance.BorderSize = 0

        Button16.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button16.BackColor = Color.Transparent
        Button16.BackgroundImageLayout = ImageLayout.Stretch
        Button16.FlatStyle = FlatStyle.Flat
        Button16.FlatAppearance.BorderSize = 0

        Button17.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button17.BackColor = Color.Transparent
        Button17.BackgroundImageLayout = ImageLayout.Stretch
        Button17.FlatStyle = FlatStyle.Flat
        Button17.FlatAppearance.BorderSize = 0

        Button18.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button18.BackColor = Color.Transparent
        Button18.BackgroundImageLayout = ImageLayout.Stretch
        Button18.FlatStyle = FlatStyle.Flat
        Button18.FlatAppearance.BorderSize = 0

        Button19.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button19.BackColor = Color.Transparent
        Button19.BackgroundImageLayout = ImageLayout.Stretch
        Button19.FlatStyle = FlatStyle.Flat
        Button19.FlatAppearance.BorderSize = 0

        Button20.BackgroundImage = My.Resources.ResourceManager.GetObject("背景2")
        Button20.BackColor = Color.Transparent
        Button20.BackgroundImageLayout = ImageLayout.Stretch
        Button20.FlatStyle = FlatStyle.Flat
        Button20.FlatAppearance.BorderSize = 0
    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(meal.Text) Then
            MsgBox("請選擇餐點")
            Exit Sub
        End If

        If Not String.IsNullOrEmpty(note.Text) Then

            If (Label4.Visible = False And Button15.Visible = False) Then
                Label4.Visible = True
                Label4.Text = note.Text
            ElseIf (Label5.Visible = False And Button16.Visible = False) Then
                Label5.Visible = True
                Label5.Text = note.Text
            ElseIf (Label6.Visible = False And Button17.Visible = False) Then
                Label6.Visible = True
                Label6.Text = note.Text
            ElseIf (Label7.Visible = False And Button18.Visible = False) Then
                Label7.Visible = True
                Label7.Text = note.Text
            ElseIf (Label9.Visible = False And Button19.Visible = False) Then
                Label9.Visible = True
                Label9.Text = note.Text
            ElseIf (Label10.Visible = False And Button20.Visible = False) Then
                Label10.Visible = True
                Label10.Text = note.Text
            End If
        End If

        If (Button15.Visible = False) Then
            Button15.Visible = True
            Button15.Enabled = True
            Button15.Text = meal.Text
            Label11.Text = tablenum.Text
            Label11.Visible = True
        ElseIf (Button16.Visible = False) Then
            Button16.Visible = True
            Button16.Enabled = True
            Button16.Text = meal.Text
            Label12.Text = tablenum.Text
            Label12.Visible = True
        ElseIf (Button17.Visible = False) Then
            Button17.Visible = True
            Button17.Enabled = True
            Button17.Text = meal.Text
            Label13.Text = tablenum.Text
            Label13.Visible = True
        ElseIf (Button18.Visible = False) Then
            Button18.Visible = True
            Button18.Enabled = True
            Button18.Text = meal.Text
            Label14.Text = tablenum.Text
            Label14.Visible = True
        ElseIf (Button19.Visible = False) Then
            Button19.Visible = True
            Button19.Enabled = True
            Button19.Text = meal.Text
            Label15.Text = tablenum.Text
            Label15.Visible = True
        ElseIf (Button20.Visible = False) Then
            Button20.Visible = True
            Button20.Enabled = True
            Button20.Text = meal.Text
            Label16.Text = tablenum.Text
            Label16.Visible = True
        End If

        Dim rand As Integer
        rand = GetRandom(1, 1000)


        conn.Open()
        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        'cmd.CommandText = "insert into 訂單(備註,桌號,品名,價錢)values('" + note.Text +
        '"', '" + tablenum.Text + "','" + meal.Text + "')"
        cmd.CommandText = "INSERT INTO 訂單 (訂單編號,備註, 桌號, 品名, 價錢,日期) " &
                  "SELECT '" & rand & "', '" & note.Text & "', '" & tablenum.Text & "', '" & meal.Text & "', 餐點.金額, ? " &
                  "FROM 餐點 WHERE 餐點.品名 = '" & meal.Text & "'"
        cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value.ToString("yyyy-MM-dd")) '& DateTimePicker1.Value.ToString("yyyy-MM-dd") & "'"
        cmd.ExecuteNonQuery()

        'Using conn
        'cmd.CommandText = "SELECT  MAX (訂單編號) FROM 訂單"
        'ng cmd("SELECT  MAX (訂單編號) FROM 訂單",)
        'Using reader As OleDbDataReader = cmd.ExecuteReader()
        'While reader.Read()
        ' 讀取欄位值
        ' Label17.Text = reader.GetInt32(0)
        ' 在此處理欄位值
        ' End While
        'End Using
        'End Using
        'End Using

        cmd.CommandText = "UPDATE 庫存 SET 存量 = 存量 - '" + TextBox1.Text + "' WHERE 食材編號 IN (SELECT 食材編號 FROM 餐點 WHERE 品名 = '" + meal.Text + "')"
        cmd.ExecuteNonQuery()

        '以下是正規版
        'cmd.CommandText = "UPDATE 庫存 SET 存量 = 存量 - (SELECT 所需食材量 FROM 餐點 WHERE 品名 = '" + meal.Text + "') WHERE 食材編號 IN (SELECT 食材編號 FROM 餐點 WHERE 品名 = ?)"
        'cmd.Parameters.AddWithValue("@mealText", meal.Text)
        'cmd.ExecuteNonQuery()

        conn.Close()
        MessageBox.Show("已增加訂單")
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        meal.Text = Button6.Text
        TextBox1.Text = Button6.Tag
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        meal.Text = Button3.Text
        TextBox1.Text = Button3.Tag
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        meal.Text = Button4.Text
        TextBox1.Text = Button4.Tag
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        meal.Text = Button5.Text
        TextBox1.Text = Button5.Tag
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        meal.Text = Button7.Text
        TextBox1.Text = Button7.Tag
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        meal.Text = Button8.Text
        TextBox1.Text = Button8.Tag
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        meal.Text = Button9.Text
        TextBox1.Text = Button9.Tag
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        meal.Text = Button10.Text
        TextBox1.Text = Button10.Tag
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        meal.Text = Button11.Text
        TextBox1.Text = Button11.Tag
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        meal.Text = Button12.Text
        TextBox1.Text = Button12.Tag
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        meal.Text = Button13.Text
        TextBox1.Text = Button13.Tag
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        meal.Text = Button14.Text
        TextBox1.Text = Button14.Tag
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f2 As New TableChoose()
        f2.Show()
        Me.Hide()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        ' If MessageBox.Show("是否刪除", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        'n.Open()
        ' cmd = conn.CreateCommand()
        '  cmd.CommandType = CommandType.Text
        '  cmd.CommandText = "delete  訂單 where 桌號='" + Label11.Text + "'and 品名='" + Button15.Text + "' "
        'cmd.ExecuteNonQuery()
        '  Else

        '  End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class