Public Class Tank

    Public Position As Point
    Public angle As Single

    Const Multiplyer As Integer = 5

    Public Bindings As Keybinds

    Public BulletList As New List(Of Bullet)

    Public HitBox As Rectangle

    Declare Auto Function GetAsyncKeyState Lib "User32" Alias "GetAsyncKeyState" (ByVal vKey As Keys) As Short

    Sub New(PlayerBinds As Keybinds)
        Bindings = PlayerBinds
    End Sub
    Public Sub Update()
        Moves()
        'set hitbox
        Bullets()
    End Sub
    Sub Moves()

        If GetAsyncKeyState(Bindings.Forward) <> 0 Then
            Position.X += (Math.Sin(angle) * Multiplyer)
            Position.Y += (Math.Cos(angle) * Multiplyer)
        End If

        If GetAsyncKeyState(Bindings.Right) <> 0 Then
            angle -= 0.1
        End If

        If GetAsyncKeyState(Bindings.Backward) <> 0 Then
            Position.X -= (Math.Sin(angle) * Multiplyer)
            Position.Y -= (Math.Cos(angle) * Multiplyer)
        End If

        If GetAsyncKeyState(Bindings.Left) <> 0 Then
            angle += 0.1
        End If

        If GetAsyncKeyState(Bindings.Shoot) <> 0 Then
            Shoot()
        End If

    End Sub

    Sub Bullets()
        If BulletList.Count <> 0 Then
            For i = BulletList.Count - 1 To 0
                BulletList(i).Update()
                If BulletList(i).TimeAlive > 2000 Then
                    BulletList(i).RemoveFromForm()
                    BulletList.RemoveAt(i)
                End If
            Next
        End If
    End Sub

    Sub Shoot()
        BulletList.Add(New Bullet(Position, New Vector(Math.Sin(angle) * Multiplyer, Math.Cos(angle) * Multiplyer)))
    End Sub

End Class
