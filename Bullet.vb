Public Class Bullet

    Inherits ControlElement

    Public Trajectory As Vector
    Public Origin As Point
    Public Position As Point

    Public TimeAlive As Integer = 0

    Public S As New Size(10, 10)

    Sub New(StartPoint As Point, Traj As Vector)
        Origin = StartPoint
        Trajectory = Traj
        Position = Origin
        Me.Size = S


        Me.Create(Position.X, Position.Y, S.Width, S.Height)
        DrawOnto()
        AddToForm()
    End Sub

    Shadows Sub Update() 'WallArr() As Wall)
        TimeAlive += 1
        MoveXY()
        ' Bounce(WallArr)
        Map()

    End Sub

    Sub Bounce(WallArr() As Wall)
        For Each W In WallArr
            If Me.Bounds.IntersectsWith(W.Bounds) Then
                If W.Horizontal = True Then
                    Trajectory.y = -(Trajectory.y)
                Else
                    Trajectory.x = -(Trajectory.x)
                End If
            End If
        Next
    End Sub

    Sub MoveXY()
        Position.X += Trajectory.x
        Position.Y += Trajectory.y
    End Sub

    Sub Map()
        Me.Left = Position.X
        Me.Top = Position.Y
    End Sub

    Sub DrawOnto()
        Me.BackColor = Color.Black
        'Using g As Graphics = Me.CreateGraphics
        '    g.FillEllipse(Brushes.Black, Me.Bounds)
        'End Using
    End Sub

End Class
