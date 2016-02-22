Imports Cyl_gear

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, TextBox5.TextChanged, TextBox3.TextChanged, TextBox2.TextChanged, TextBox4.TextChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label5.Visible = False
        TextBox5.Visible = False
        GroupBox1.Visible = False
        Me.Height = 134
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label5.Visible = True
        TextBox5.Visible = True
        GroupBox1.Visible = True
        Me.Height = 184
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim gear1 As New CylGear, a As Integer
        Me.Enabled = False

        If RadioButton3.Checked = True Then
            a = 1
        Else
            a = 2

        End If
        If RadioButton1.Checked = True Then
            Me.Enabled = gear1.GearModel(Val(TextBox1.Text), Val(TextBox2.Text), Val(TextBox3.Text), Val(TextBox4.Text), 0, 0)
        ElseIf RadioButton2.Checked = True Then
            Me.Enabled = gear1.GearModel(Val(TextBox1.Text), Val(TextBox2.Text), Val(TextBox3.Text), Val(TextBox4.Text), Val(TextBox5.Text), a)
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
