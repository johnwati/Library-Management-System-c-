Public Class frmCamera
    Public CamMgr As TouchlessLib.TouchlessMgr
    Dim TempFileNames2 As String

    Private Sub WebcamImage_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Timer1.Enabled = False
            CamMgr.CurrentCamera.Dispose()
            CamMgr.Cameras.Item(cmbCamera.SelectedIndex).Dispose()
            CamMgr.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CamMgr = New TouchlessLib.TouchlessMgr
        TempFileNames2 = ""

        For i As Integer = 0 To CamMgr.Cameras.Count - 1
            cmbCamera.Items.Add(CamMgr.Cameras(i).ToString)
        Next
        If cmbCamera.Items.Count > 0 Then
            cmbCamera.SelectedIndex = 0
            Timer1.Enabled = True
        Else
            MsgBox("There are no Camera ...")
            Me.Close()
        End If

    End Sub



    Private Sub cmbCamera_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCamera.SelectedIndexChanged
        CamMgr.CurrentCamera = CamMgr.Cameras.ElementAt(cmbCamera.SelectedIndex)
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        picFeed.Image = CamMgr.CurrentCamera.GetCurrentImage()
    End Sub

    Private Sub btnCapture_Click(sender As System.Object, e As System.EventArgs) Handles btnCapture.Click
        picPreview.Image = CamMgr.CurrentCamera.GetCurrentImage()
        btnSave.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim sTempFileName As String = System.IO.Path.GetTempFileName()
        TempFileNames2 = sTempFileName
        Dim b As Bitmap = picPreview.Image
        b.Save(sTempFileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        Timer1.Enabled = False
        CamMgr.CurrentCamera.Dispose()
        CamMgr.Cameras.Item(cmbCamera.SelectedIndex).Dispose()
        CamMgr.Dispose()

        Me.Close()
    End Sub


End Class
