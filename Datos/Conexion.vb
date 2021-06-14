Imports System.Data.SqlClient
Public Class Conexion


    'Protected strCn As String = "Server=localhost;Uid=sa;Pwd=sasa;MultipleActiveResultSets=True;Timeout=120
    '                     ;Database=pruebademo;"

    Protected strCn As String = My.Settings.strSql


    Protected Cnn As New SqlConnection()


    Protected Function Conectar()

        Try

            Cnn = New SqlConnection(strCn)
            Cnn.Open()
            Return True

        Catch ex As Exception

            MsgBox(ex.Message)
            Return False

        End Try

    End Function


    Protected Function Cerrar()
        Try

            If Cnn.State = ConnectionState.Open Then
                Cnn.Close()
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try
    End Function
End Class
