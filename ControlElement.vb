Public Class ControlElement

    Inherits PictureBox


    Sub Create(x As Integer, y As Integer, wid As Integer, hei As Integer)
        Me.Left = x
        Me.Top = y
        Me.Width = wid
        Me.Height = hei
    End Sub

    Sub AddToForm()
        Form1.Controls.Add(Me)
    End Sub
    Sub RemoveFromForm()
        Form1.Controls.Remove(Me)
    End Sub

End Class
