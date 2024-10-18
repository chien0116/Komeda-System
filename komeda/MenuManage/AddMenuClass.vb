Imports System.Data.OleDb
Imports System.Diagnostics.Eventing.Reader
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class AddMenuClass

    Dim conn As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable
    Dim da As New OleDbDataAdapter(cmd)

    Dim cmd_2 As OleDbCommand
    Dim conn_2 As New OleDbConnection
    Dim dt_2 As New DataTable
    Dim da_2 As New OleDbDataAdapter(cmd_2)
    ' Dim cmd_2 As OleDbCommand
    Private bitmap As Bitmap
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
        '----------------------------------------------------------------
        DataGridView2.DataSource = Nothing
        DataGridView2.Refresh()

        conn_2.Open()
        cmd_2 = conn_2.CreateCommand()
        cmd_2.CommandType = CommandType.Text
        da_2 = New OleDbDataAdapter("select * from 餐點 ", conn_2)
        da_2.Fill(dt_2)
        DataGridView2.DataSource = dt_2
        conn_2.Close()
        DataGridView2.Columns(0).Width = 80
        DataGridView2.Columns(1).Width = 80
        DataGridView2.Columns(2).Width = 80
        DataGridView2.Columns(3).Width = 80
        DataGridView2.Columns(4).Width = 80
        DataGridView2.Columns(5).Width = 80
        DataGridView2.Columns(6).Width = 80
        DataGridView2.Columns(7).Width = 80
        DataGridView2.Columns(8).Width = 80

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fmm As New MenuManage()
        fmm.Show()
        Me.Hide()
    End Sub

    Private Sub AddMenuClass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"
        conn_2.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; data source =D:\komeda_data.mdb"
        viewer()

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
    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rand As Integer
        rand = GetRandom(1, 1000)
        Try
            If String.IsNullOrWhiteSpace(foodname.Text) Or String.IsNullOrWhiteSpace(money.Text) Or String.IsNullOrWhiteSpace(MaterialAmount.Text) Or String.IsNullOrWhiteSpace(ElementNum1.Text) Then
                MessageBox.Show("請將資料輸入完整")
                Exit Sub
            End If
            Dim dr As OleDbDataReader
            Button1.Tag = 0
            'Try
            conn.Open()
            conn_2.Open()
            cmd_2 = conn.CreateCommand()
            cmd_2.CommandType = CommandType.Text
            cmd_2.CommandText = "insert into 餐點(餐點編號,品名,金額,食材編號,食材2編號,食材3編號,食材4編號,食材5編號,所需食材量)
        select'" & rand & "','" + foodname.Text + "','" + money.Text + "','" + ElementNum1.Text + "','" + ElementNum2.Text + "','" + ElementNum3.Text +
                "','" + ElementNum4.Text + "','" + ElementNum5.Text + "','" + MaterialAmount.Text + "'
       from 庫存
        where 食材編號='" + ElementNum1.Text + "'"
            cmd_2.ExecuteNonQuery()
            '請注意此處有_2的才是上面的餐點DataGridView2才是上面的

            dt_2 = New DataTable()
            da_2 = New OleDbDataAdapter("select * from 餐點 ", conn_2)
            da_2.Fill(dt_2)
            DataGridView2.DataSource = dt_2

            dt = New DataTable()
            da = New OleDbDataAdapter("select * from 庫存 ", conn)
            da.Fill(dt)
            DataGridView1.DataSource = dt


            MessageBox.Show("新增存貨類別成功")
            ' Else
            conn.Close()
            conn_2.Close()
        Catch ex As Exception
            MessageBox.Show("餐點編號不可重複 且 食材編號不可填寫不存在的")

        End Try
        foodname.Text = ""
        money.Text = ""
        ElementNum1.Text = ""
        ElementNum2.Text = ""
        ElementNum3.Text = ""
        ElementNum4.Text = ""
        ElementNum5.Text = ""
        MaterialAmount.Text = ""
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If String.IsNullOrWhiteSpace(ElementNum1.Text) Then
                ElementNum1.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()

            ElseIf String.IsNullOrWhiteSpace(ElementNum2.Text) Then
                ElementNum2.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            ElseIf String.IsNullOrWhiteSpace(ElementNum3.Text) Then
                ElementNum3.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            ElseIf String.IsNullOrWhiteSpace(ElementNum4.Text) Then
                ElementNum4.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            ElseIf String.IsNullOrWhiteSpace(ElementNum5.Text) Then
                ElementNum5.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("請點擊食材編號前方那列")
        End Try
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Try
            foodname.Text = DataGridView2.SelectedRows(0).Cells(1).Value.ToString()
            money.Text = DataGridView2.SelectedRows(0).Cells(2).Value.ToString()
            ElementNum1.Text = DataGridView2.SelectedRows(0).Cells(3).Value.ToString()
            ElementNum2.Text = DataGridView2.SelectedRows(0).Cells(4).Value.ToString()
            ElementNum3.Text = DataGridView2.SelectedRows(0).Cells(5).Value.ToString()
            ElementNum4.Text = DataGridView2.SelectedRows(0).Cells(6).Value.ToString()
            ElementNum5.Text = DataGridView2.SelectedRows(0).Cells(7).Value.ToString()
            MaterialAmount.Text = DataGridView2.SelectedRows(0).Cells(8).Value.ToString()
        Catch ex As Exception
            MessageBox.Show("請點擊品名前方那列")
        End Try
    End Sub
End Class