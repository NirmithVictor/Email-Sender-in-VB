Imports System.Net.Mail

Public Class Form1
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Dispose()
    End Sub

    Private Sub lnkAttachment_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAttachment.LinkClicked
        With OpenFileDialog1
            .FileName = ""
            .Multiselect = False
        End With
        If OpenFileDialog1.ShowDialog = 1 Then
            lblAttachment.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Dim accountFrom As String = "youremail@gmail.com"
    Dim message As New MailMessage
    Dim smtp As New SmtpClient
    Dim instance As IDisposable
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Try
            Dim Mail As New MailMessage
            Mail.To.Add(txtto.Text)
            Mail.Subject = txtsubject.Text
            Mail.From = New MailAddress(accountFrom)
            Mail.Body = txtmessage.Text
            Dim attach As New Attachment(OpenFileDialog1.FileName)
            Mail.Attachments.Add(attach)
            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.Port = 587
            SMTP.Credentials = New System.Net.NetworkCredential(accountFrom, "yourpasscode")
            SMTP.EnableSsl = True
            SMTP.Send(Mail)
            MsgBox("Sent Successfully")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtfrom.Text = accountFrom
        txtfrom.Enabled = False

    End Sub
End Class
