Imports BibliotecaDeClases

Public Class Form1
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles btnSaludar.Click
        Dim persona As New ClsPersona(txtNombre.Text)

        MessageBox.Show(
        "Hola, " + persona.getNombre(),
        "Saludar",
        MessageBoxButtons.OK
        )
    End Sub

End Class
