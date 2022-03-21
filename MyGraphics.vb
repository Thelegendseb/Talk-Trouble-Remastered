Public Class MyGraphics

    Public Canvas As Bitmap
    Public Size As Size

    Public Sub New(S As Size)
        Size = S
        Canvas = New Bitmap(Size.Width, Size.Height)
    End Sub

    Public Function Render(Tanks() As Tank) As Bitmap
        'break down
        Using g As Graphics = Graphics.FromImage(Canvas)
            g.DrawImage(TankRender(Tanks), New Point(0, 0))

            'rest
        End Using

        Dim Copy As Bitmap = Canvas.Clone
        Canvas = New Bitmap(Size.Width, Size.Height)
        Return Copy
    End Function

    Public Function TankRender(Tanks() As Tank) As Bitmap

        Dim TankMap As New Bitmap(Size.Width, Size.Height)

        Using g As Graphics = Graphics.FromImage(TankMap)

            'draw tank = 
            For Each T In Tanks
                g.DrawEllipse(Pens.Black, T.Position.X, T.Position.Y, 20, 20)
            Next
        End Using

        Return TankMap
    End Function

End Class
