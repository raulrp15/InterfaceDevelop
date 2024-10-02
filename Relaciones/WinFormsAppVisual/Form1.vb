Imports BibliotecaDeClases

Public Class Form1
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles btnSaludar.Click
        Dim persona As New ClsPersona()


        If Not (txtNombre.Text.Equals("")) Then
            persona.Nombre = txtNombre.Text
            MessageBox.Show(
                "Hola, " + persona.Nombre,
                "Saludar",
                MessageBoxButtons.OK
            )
        Else
            mError.Text = "No puede estar vacio"
        End If

    End Sub

End Class
