Public Class Opciones
    Private Sub Opciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = My.Settings.PesosKgAlambre.ToString
        TextBox1.Text = My.Settings.PesosKgLaminas.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Forms.TrafoMaker9000.errorentrada = False
        My.Forms.TrafoMaker9000.checkEntrada(TextBox2, False, 1)
        My.Forms.TrafoMaker9000.checkEntrada(TextBox1, False, 1)

        If Not My.Forms.TrafoMaker9000.errorentrada Then
            My.Settings.PesosKgAlambre = CDbl(Val(TextBox2.Text))
            My.Settings.PesosKgLaminas = CDbl(Val(TextBox1.Text))
            Me.Close()
        Else
            MsgBox("Solo utilizar numeros y punto como separador decimal.")
        End If
    End Sub
End Class