Public Class Form1

    Public Window As PictureBox

    Dim WithEvents T As New Timer

    Dim g As MyGraphics

    Dim TankArr(1) As Tank


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        g = New MyGraphics(Me.ClientSize)
        TankArr(0) = New Tank(New Keybinds(Keys.W, Keys.S, Keys.A, Keys.D, Keys.Space))
        TankArr(1) = New Tank(New Keybinds(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.RControlKey))
        T.Interval = 30
        T.Start()
    End Sub

    Private Sub T_Tick(sender As System.Object, e As System.EventArgs) Handles T.Tick
        For Each Tt In TankArr
            Tt.Update()
        Next

        Me.BackgroundImage = g.Render(TankArr)
    End Sub


End Class
