Imports Excel = Microsoft.Office.Interop.Excel
Public Class TrafoMaker9000
#Region "Variables"
    Public APP As New Excel.Application
    Public workbook As Excel.Workbook
    Public worksheet As Excel.Worksheet
    Public myTrafo As New Trafo
    Public myLamina As New Lamina
    Public myCarrete As New Carrete
    Public myPrimario As New Bobinado
    Public mySecundario1 As New Bobinado
    Public mySecundario2 As New Bobinado
    Public mySecundario3 As New Bobinado

    Public excelAbierto As Boolean = False
    Public errorentrada As Boolean
    Public secundario2Habilitado As Boolean = False
    Public secundario3Habilitado As Boolean = False
    Public filaConductor As Integer = 0
    Public ab1, ab2, ab3, ab4 As Double
    Public entra As Boolean = True
    Public perdidaCobre As Double = 0
    Public perdidaHierro As Double = 0
    Public perdidaAdicional As Double = 0
    Public pesoDelNucleo As Double = 0
    Public perdidaDelNucleo As Double = 0
    Public seRecalcula As Boolean = False
    Public recalcularOffset As Integer = 0
#End Region
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxPrincipal.DropDownStyle = ComboBoxStyle.DropDownList 'No editable
        ComboBoxPrincipal.SelectedIndex = 2 'Seleccionar por defecto 220v50hz
        ComboBoxBobinado.DropDownStyle = ComboBoxStyle.DropDownList 'No editable
        ComboBoxBobinado.SelectedIndex = 0 'Seleccionar por defecto bobinado a maquina
        ComboBoxNucleos.DropDownStyle = ComboBoxStyle.DropDownList 'No editable
        ComboBoxSecundarios.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxSecundarios.SelectedIndex = 0
        RadioButtonCorriente.Checked = True

        excelAbierto = True

        Dim path As String = My.Application.Info.DirectoryPath 'Obtener ruta del .exe
        Dim archivotablas As String = IO.Path.Combine(path, "Tablas.xlsx") 'Combinar ruta del .exe con el archivo de las tablas.

        If My.Computer.FileSystem.FileExists(archivotablas) Then
            workbook = APP.Workbooks.Open(archivotablas) 'Abrir archivo de excel
            worksheet = workbook.Worksheets("Laminas") 'Abrir hoja "Laminas"
        Else
            MsgBox("No se encontro el archivo Tablas.xlsx dentro del directorio del ejecutable. Cierre el programa e intente nuevamente.")
            workbook.Close() 'Cerrar la hoja de excel
            APP.Quit() 'Terminar el servicio de excel
            excelAbierto = False
        End If

        cargarNucleos()
    End Sub
    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If excelAbierto Then
            workbook.Close() 'Cerrar la hoja de excel
            APP.Quit() 'Terminar el servicio de excel
            excelAbierto = False
        End If
    End Sub
    Private Sub ButtonCalcular_Click(sender As Object, e As EventArgs) Handles ButtonCalcular.Click
        'agregar mensaje de error cuando se introduzca 0 en alguno de los campos en uso.
        myPrimario.reset()
        mySecundario1.reset()
        mySecundario2.reset()
        mySecundario3.reset()
        myCarrete.reset()
        myTrafo.reset()
        myLamina.reset()

        entra = True
        perdidaCobre = 0
        perdidaHierro = 0
        perdidaAdicional = 0
        pesoDelNucleo = 0
        perdidaDelNucleo = 0
        seRecalcula = False
        recalcularOffset = 0

        actualizarInterfaz()
        Dim continuar As Boolean = False
        If checkearEntradas() Then 'Entradas correctas
            cargarValores()
            CalcularPaso1()
            CalcularPaso2()
            CalcularPaso3()
            CalcularPaso4()
            CalcularPaso5()
            If Not entra And CheckBoxNucleos.Checked Then
                Dim diferencia As Double = (ab1 + ab2 + ab3 + ab4) * myTrafo.constanteBobinado - myLamina.E
                Dim msgRslt As MsgBoxResult = MsgBox("El bobinado no va a entrar con el carrete seleccionado. Diferencia de: " & rd(diferencia) & "mm. ¿Desea Continuar?", MsgBoxStyle.YesNo)
                If msgRslt = MsgBoxResult.Yes Then
                    continuar = True
                Else
                    continuar = False
                End If
            Else
                While Not entra
                    seRecalcula = True
                    recalcularOffset = recalcularOffset + 1
                    CalcularPaso1()
                    CalcularPaso2()
                    CalcularPaso3()
                    CalcularPaso4()
                    CalcularPaso5()
                End While

                continuar = True
            End If

            If continuar Then
                CalcularPaso6()
                CalcularPaso7()
                CalcularPaso8()
                postCalculo()
                actualizarSalida()
            End If
        Else
            'Codigo cuando se detecto algun error en la entrada
            MsgBox("Hay un dato de entrada invalido.")
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.DefaultExt = "*.txt"
        SaveFileDialog1.Filter = "Archivo de texto|*.txt"
        SaveFileDialog1.CreatePrompt = True
        If SaveFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Using outputFile As New System.IO.StreamWriter(SaveFileDialog1.FileName)
                For Each item As Object In ListBox1.Items
                    outputFile.WriteLine(item.ToString)
                Next
            End Using
        End If
    End Sub
    Sub cargarValores()
        If ComboBoxPrincipal.SelectedIndex = 0 Then
            myPrimario.voltaje = 380
            myTrafo.frecuencia = 50
        ElseIf ComboBoxPrincipal.SelectedIndex = 1 Then
            myPrimario.voltaje = 240
            myTrafo.frecuencia = 50
        ElseIf ComboBoxPrincipal.SelectedIndex = 2 Then
            myPrimario.voltaje = 220
            myTrafo.frecuencia = 50
        ElseIf ComboBoxPrincipal.SelectedIndex = 3 Then
            myPrimario.voltaje = 127
            myTrafo.frecuencia = 50
        ElseIf ComboBoxPrincipal.SelectedIndex = 4 Then
            myPrimario.voltaje = 190
            myTrafo.frecuencia = 60
        ElseIf ComboBoxPrincipal.SelectedIndex = 5 Then
            myPrimario.voltaje = 120
            myTrafo.frecuencia = 60
        ElseIf ComboBoxPrincipal.SelectedIndex = 6 Then
            myPrimario.voltaje = 110
            myTrafo.frecuencia = 60
        ElseIf ComboBoxPrincipal.SelectedIndex = 7 Then
            myPrimario.voltaje = 63
            myTrafo.frecuencia = 60
        End If

        mySecundario1.voltaje = CDbl(Val(TextBoxVoltajeSecundario1.Text))
        mySecundario1.corriente = CDbl(Val(TextBoxCorrienteSecundario1.Text))
        mySecundario1.potencia = CDbl(Val(TextBoxPotenciaSecundario1.Text))

        If secundario2Habilitado Then
            mySecundario2.voltaje = CDbl(Val(TextBoxVoltajeSecundario2.Text))
            mySecundario2.corriente = CDbl(Val(TextBoxCorrienteSecundario2.Text))
            mySecundario2.potencia = CDbl(Val(TextBoxPotenciaSecundario2.Text))
        End If

        If secundario3Habilitado Then
            mySecundario3.voltaje = CDbl(Val(TextBoxVoltajeSecundario3.Text))
            mySecundario3.corriente = CDbl(Val(TextBoxCorrienteSecundario3.Text))
            mySecundario3.potencia = CDbl(Val(TextBoxPotenciaSecundario3.Text))
        End If

        myTrafo.densidadDeCorriente = CDbl(Val(TextBoxDensidad.Text))

        If CheckBoxPotencia.Checked Then
            myTrafo.potenciaSecundarioTotal = CDbl(Val(TextBoxPotenciaTotal.Text))
        Else
            myTrafo.potenciaSecundarioTotal = mySecundario1.potencia + mySecundario2.potencia + mySecundario3.potencia 'Se establece la potencia total de las salidas del transformador
        End If

        If CheckBoxCosenoRendimiento.Checked Then
            myTrafo.rendimiento = CDbl(Val(TextBoxRendimiento.Text))
            myTrafo.cosenoFi = CDbl(Val(TextBoxCosenoFi.Text))
        Else
            myTrafo.rendimiento = 0.9
            myTrafo.cosenoFi = 0.8
        End If

        If ComboBoxBobinado.SelectedIndex = 0 Then ' a maquina
            myTrafo.constanteBobinado = 2
        Else
            myTrafo.constanteBobinado = 3.33
        End If

        myTrafo.induccionBmax = CDbl(Val(TextBoxInduccion.Text))
        myTrafo.constanteCalculoSn = CDbl(Val(TextBoxSn.Text))
        myTrafo.perdidaWKg = CDbl(Val(TextBoxPerdidaWKg.Text))

        myTrafo.factorDeApilado = 0.95

    End Sub
    Function aproximarATabla(valor As Double, columna As Integer, filaDesde As Integer, solocuadrado As Boolean)
        Dim diferencia As Double = 0
        Dim diferenciaUltimo As Double = 8192
        Dim filaResultado As Integer = 0
        Dim ultimaFila As Integer = obtenerUltimaFila()

        If solocuadrado Then
            For c As Integer = filaDesde To ultimaFila Step 1
                Dim valorReal As Double = worksheet.Cells(c, columna).value
                If worksheet.Cells(c, 8).value = 1 Then
                    If valorReal = valor Then
                        filaResultado = c
                        Exit For
                    ElseIf valorReal < valor Then
                        diferencia = valor - valorReal
                        If diferencia < diferenciaUltimo Then
                            diferenciaUltimo = diferencia
                            filaResultado = c
                        End If
                    ElseIf valorReal > valor Then
                        diferencia = valorReal - valor
                        If diferencia < diferenciaUltimo Then
                            diferenciaUltimo = diferencia
                            filaResultado = c
                        End If
                    End If
                End If
            Next
        Else
            For c As Integer = filaDesde To ultimaFila Step 1
                Dim valorReal As Double = worksheet.Cells(c, columna).value
                If valorReal = valor Then
                    filaResultado = c
                    Exit For
                ElseIf valorReal < valor Then
                    diferencia = valor - valorReal
                    If diferencia < diferenciaUltimo Then
                        diferenciaUltimo = diferencia
                        filaResultado = c
                    End If
                ElseIf valorReal > valor Then
                    diferencia = valorReal - valor
                    If diferencia < diferenciaUltimo Then
                        diferenciaUltimo = diferencia
                        filaResultado = c
                    End If
                End If
            Next
        End If

        Return filaResultado
    End Function
    Function obtenerUltimaFila()
        Dim finDeLaTabla As Boolean = False
        Dim ultimaFila As Integer = 1
        While Not finDeLaTabla
            ultimaFila = ultimaFila + 1
            If worksheet.Cells(ultimaFila, 1).value = worksheet.Cells(7000, 7000).value Then
                finDeLaTabla = True
                ultimaFila = ultimaFila - 1
            End If
        End While

        If ultimaFila = 0 Then 'Checkeo rapido por si la funcion de arriba tiro algun valor incorrecto
            ultimaFila = 20
        End If

        Return ultimaFila
    End Function
    Sub checkEntrada(TextBox As Object, mayoramaxerror As Boolean, valMax As Double)
        Dim value As Double
        If Double.TryParse(TextBox.text, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, value) Then

            If value <= 0 Then
                errorentrada = True
                TextBox.foreColor = Color.Red
            ElseIf mayoramaxerror And value > valMax Then
                errorentrada = True
                TextBox.foreColor = Color.Red
            Else
                TextBox.foreColor = Color.Black
            End If
        Else
            errorentrada = True
            TextBox.foreColor = Color.Red
        End If
    End Sub
    Function checkearEntradas() 'Retorna verdadero cuando no hay ningun error.
        errorentrada = False 'INAMOVIBLE

        checkEntrada(TextBoxVoltajeSecundario1, False, 1)
        checkEntrada(TextBoxCorrienteSecundario1, False, 1)
        checkEntrada(TextBoxPotenciaSecundario1, False, 1)
        If secundario2Habilitado Then
            checkEntrada(TextBoxVoltajeSecundario2, False, 1)
            checkEntrada(TextBoxCorrienteSecundario2, False, 1)
            checkEntrada(TextBoxPotenciaSecundario2, False, 1)
        End If

        If secundario3Habilitado Then
            checkEntrada(TextBoxVoltajeSecundario3, False, 1)
            checkEntrada(TextBoxPotenciaSecundario3, False, 1)
            checkEntrada(TextBoxCorrienteSecundario3, False, 1)
        End If

        checkEntrada(TextBoxDensidad, False, 1)

        If CheckBoxCosenoRendimiento.Checked Then
            checkEntrada(TextBoxRendimiento, True, 1)
            checkEntrada(TextBoxCosenoFi, True, 1)
        End If

        If CheckBoxPotencia.Checked Then
            checkEntrada(TextBoxPotenciaTotal, False, 1)
        End If

        checkEntrada(TextBoxInduccion, False, 1)
        checkEntrada(TextBoxSn, False, 1)
        checkEntrada(TextBoxPerdidaWKg, False, 1)

        Return Not errorentrada
    End Function
    Function rd(valor As Double)
        If Not valor = 0 Then
            Return Decimal.Round(valor, 2, MidpointRounding.AwayFromZero).ToString
        Else
            Return "0"
        End If
    End Function

#Region "Actualizar Interfaz"
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSecundarios.SelectedIndexChanged
        actualizarInterfaz()
    End Sub
    Private Sub ComboBoxPrincipal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPrincipal.SelectedIndexChanged
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxVoltajeSecundario1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxVoltajeSecundario1.TextChanged
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxPotenciaSecundario1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPotenciaSecundario1.TextChanged
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxVoltajeSecundario2_TextChanged(sender As Object, e As EventArgs)
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxPotenciaSecundario2_TextChanged(sender As Object, e As EventArgs)
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxVoltajeSecundario3_TextChanged(sender As Object, e As EventArgs)
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxPotenciaSecundario3_TextChanged(sender As Object, e As EventArgs)
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxDensidad_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDensidad.TextChanged
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxRendimiento_TextChanged(sender As Object, e As EventArgs) Handles TextBoxRendimiento.TextChanged
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxCosenoFi_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCosenoFi.TextChanged
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxPotenciaTotal_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPotenciaTotal.TextChanged
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxSn_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSn.TextChanged
        actualizarInterfaz()
    End Sub
    Private Sub ComboBoxBobinado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBobinado.SelectedIndexChanged
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxInduccion_TextChanged(sender As Object, e As EventArgs) Handles TextBoxInduccion.TextChanged
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxPerdidaWKg_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPerdidaWKg.TextChanged
        actualizarInterfaz()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSoloNucleosCuadrados.CheckedChanged
        actualizarInterfaz()
    End Sub
    Private Sub ComboBoxNucleos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxNucleos.SelectedIndexChanged
        actualizarInterfaz()
    End Sub
    Private Sub CheckBoxNucleos_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxNucleos.CheckedChanged
        actualizarInterfaz()
    End Sub
    Private Sub CheckBoxCosenoRendimiento_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCosenoRendimiento.CheckedChanged
        actualizarInterfaz()
    End Sub
    Private Sub CheckBoxHabilitadoSecundario2_CheckedChanged(sender As Object, e As EventArgs)
        actualizarInterfaz()
    End Sub
    Private Sub CheckBoxHabilitadoSecundario3_CheckedChanged(sender As Object, e As EventArgs)
        actualizarInterfaz()
    End Sub
    Private Sub CheckBoxConstantes_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxPotencia.CheckedChanged
        actualizarInterfaz()
    End Sub
    Private Sub RadioButtonPotencia_CheckedChanged(sender As Object, e As EventArgs)
        actualizarInterfaz()
    End Sub
    Private Sub RadioButtonCorriente_CheckedChanged(sender As Object, e As EventArgs)
        actualizarInterfaz()
    End Sub
    Private Sub TextBoxCorrienteSecundario1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCorrienteSecundario1.TextChanged
        actualizarInterfaz()
    End Sub

    Private Sub TextBoxCorrienteSecundario2_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCorrienteSecundario2.TextChanged
        actualizarInterfaz()
    End Sub

    Private Sub TextBoxCorrienteSecundario3_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCorrienteSecundario3.TextChanged
        actualizarInterfaz()
    End Sub
#End Region
#Region "Funciones y Subrutinas de Calculo"

    Sub CalcularPaso1() '1) Calculo de la seccion del nucleo
        myTrafo.Sn = myTrafo.constanteCalculoSn * Math.Sqrt(myTrafo.potenciaSecundarioTotal) 'Valor en Cm2
        'Seleccionar Carrete:
        worksheet = workbook.Worksheets("Carretes") 'Abrimos la hoja carretes

        Dim filaCarrete As Integer = 0

        If Not CheckBoxNucleos.Checked Then 'No se sobreescribe el nucleo, calcular normalmente
            filaCarrete = aproximarATabla(myTrafo.Sn, 7, 2, CheckBoxSoloNucleosCuadrados.Checked)

            If seRecalcula Then
                filaCarrete = filaCarrete + recalcularOffset
            End If
        Else    'Calcular en base al nucleo especificado
            filaCarrete = ComboBoxNucleos.SelectedIndex + 2
        End If

        myCarrete.numero = worksheet.Cells(filaCarrete, 1).value
        myCarrete.A = worksheet.Cells(filaCarrete, 2).value
        myCarrete.B = worksheet.Cells(filaCarrete, 3).value
        myCarrete.C = worksheet.Cells(filaCarrete, 4).value
        myCarrete.D = worksheet.Cells(filaCarrete, 5).value
        myCarrete.H = worksheet.Cells(filaCarrete, 6).value
        myTrafo.Sn = worksheet.Cells(filaCarrete, 7).value * myTrafo.factorDeApilado
        myCarrete.Cuadrado = worksheet.Cells(filaCarrete, 8).value

        'Seleccionar Lamina
        worksheet = workbook.Worksheets("Laminas") 'Abrir hoja "Laminas"
        Dim filaLamina As Integer = aproximarATabla(myCarrete.A, 7, 2, False)

        myLamina.numero = worksheet.Cells(filaLamina, 1).value
        myLamina.AH = worksheet.Cells(filaLamina, 2).value
        myLamina.BG = worksheet.Cells(filaLamina, 3).value
        myLamina.C = worksheet.Cells(filaLamina, 4).value
        myLamina.D = worksheet.Cells(filaLamina, 5).value
        myLamina.E = worksheet.Cells(filaLamina, 6).value
        myLamina.F = worksheet.Cells(filaLamina, 7).value


        'Ya tenemos el numero de lamina que vamos a usar y su fila dentro de la tabla
        'Ya tenemos el carrete que vamos a usar (Siempre seccion cuadrada) y su fila dentro de la tabla
    End Sub
    Sub CalcularPaso2() '2) Calculo de I1
        myPrimario.corriente = myTrafo.potenciaSecundarioTotal / (myPrimario.voltaje * myTrafo.rendimiento * myTrafo.cosenoFi)
    End Sub
    Sub CalcularPaso3() '3) Calculo de las secciones de los conductores
        worksheet = workbook.Worksheets("Conductores") 'Abrir hoja "Conductores"

        'Calculos para el conductor del bobinado primario
        myPrimario.seccion = myPrimario.corriente / myTrafo.densidadDeCorriente
        filaConductor = aproximarATabla(myPrimario.seccion, 3, 2, False)
        myPrimario.calibre = worksheet.Cells(filaConductor, 1).value.ToString
        myPrimario.diametro = worksheet.Cells(filaConductor, 2).value
        myPrimario.seccion = worksheet.Cells(filaConductor, 3).value
        myPrimario.gramosMetro = worksheet.Cells(filaConductor, 4).value
        myPrimario.ohmMetro = worksheet.Cells(filaConductor, 5).value

        'Calculos para el conductor del bobinado secundario 1
        mySecundario1.seccion = mySecundario1.corriente / myTrafo.densidadDeCorriente
        filaConductor = aproximarATabla(mySecundario1.seccion, 3, 2, False)

        mySecundario1.calibre = worksheet.Cells(filaConductor, 1).value.ToString
        mySecundario1.diametro = worksheet.Cells(filaConductor, 2).value
        mySecundario1.seccion = worksheet.Cells(filaConductor, 3).value
        mySecundario1.gramosMetro = worksheet.Cells(filaConductor, 4).value
        mySecundario1.ohmMetro = worksheet.Cells(filaConductor, 5).value


        'no calcular para los secundarios que no se usan:
        If secundario2Habilitado Then
            'Calculos para el conductor del bobinado secundario 1
            mySecundario2.seccion = mySecundario2.corriente / myTrafo.densidadDeCorriente
            filaConductor = aproximarATabla(mySecundario2.seccion, 3, 2, False)

            mySecundario2.calibre = worksheet.Cells(filaConductor, 1).value.ToString
            mySecundario2.diametro = worksheet.Cells(filaConductor, 2).value
            mySecundario2.seccion = worksheet.Cells(filaConductor, 3).value
            mySecundario2.gramosMetro = worksheet.Cells(filaConductor, 4).value
            mySecundario2.ohmMetro = worksheet.Cells(filaConductor, 5).value
        End If

        If secundario3Habilitado Then
            'Calculos para el conductor del bobinado secundario 1
            mySecundario3.seccion = mySecundario3.corriente / myTrafo.densidadDeCorriente
            filaConductor = aproximarATabla(mySecundario3.seccion, 3, 2, False)

            mySecundario3.calibre = worksheet.Cells(filaConductor, 1).value.ToString
            mySecundario3.diametro = worksheet.Cells(filaConductor, 2).value
            mySecundario3.seccion = worksheet.Cells(filaConductor, 3).value
            mySecundario3.gramosMetro = worksheet.Cells(filaConductor, 4).value
            mySecundario3.ohmMetro = worksheet.Cells(filaConductor, 5).value
        End If

    End Sub
    Sub CalcularPaso4() '4) Calculo del numero de espiras de los bobinados

        Dim divisor As Double = myTrafo.frecuencia * myTrafo.Sn * myTrafo.induccionBmax * 0.000000444 / 10
        myPrimario.vueltas = Math.Ceiling(myPrimario.voltaje / divisor)
        mySecundario1.vueltas = Math.Ceiling(mySecundario1.voltaje / divisor)

        'no calcular para los secundarios que no se usan:
        If secundario2Habilitado Then
            mySecundario2.vueltas = Math.Ceiling(mySecundario2.voltaje / divisor)
        Else
            mySecundario2.vueltas = 0
        End If

        If secundario3Habilitado Then
            mySecundario3.vueltas = Math.Ceiling(mySecundario3.voltaje / divisor)
        Else
            mySecundario3.vueltas = 0
        End If
    End Sub
    Sub CalcularPaso5() '5) Calculo del ancho de los bobinados

        myPrimario.alambresPorCapa = Math.Floor(myLamina.C / myPrimario.diametro)
        myPrimario.capas = Math.Ceiling(myPrimario.vueltas / myPrimario.alambresPorCapa)
        ab1 = myPrimario.diametro * myPrimario.capas

        mySecundario1.alambresPorCapa = Math.Floor(myLamina.C / mySecundario1.diametro)
        mySecundario1.capas = Math.Ceiling(mySecundario1.vueltas / mySecundario1.alambresPorCapa)
        ab2 = mySecundario1.diametro * mySecundario1.capas

        If secundario2Habilitado Then
            mySecundario2.alambresPorCapa = Math.Floor(myLamina.C / mySecundario2.diametro)
            mySecundario2.capas = Math.Ceiling(mySecundario2.vueltas / mySecundario2.alambresPorCapa)
            ab3 = mySecundario2.diametro * mySecundario2.capas
        Else
            ab3 = 0
        End If
        If secundario3Habilitado Then
            mySecundario3.alambresPorCapa = Math.Floor(myLamina.C / mySecundario3.diametro)
            mySecundario3.capas = Math.Ceiling(mySecundario3.vueltas / mySecundario3.alambresPorCapa)
            ab4 = mySecundario3.diametro * mySecundario3.capas
        Else
            ab4 = 0
        End If

        If (ab1 + ab2 + ab3 + ab4) * myTrafo.constanteBobinado < myLamina.E Then
            ' Entra
            entra = True
        Else
            ' No entra
            entra = False
        End If
    End Sub
    Sub CalcularPaso6() '6) Calculo del largo y la resistencia de los Bobinados

        myPrimario.largoMedio = 2 * (myCarrete.A + ab1) + 2 * (myCarrete.B + ab1)
        mySecundario1.largoMedio = 2 * (myCarrete.A + ab2 + 2 * ab1) + 2 * (myCarrete.B + ab2 + 2 * ab1)
        If secundario2Habilitado Then
            mySecundario2.largoMedio = 2 * (myCarrete.A + ab3 + 2 * ab2 + 2 * ab1) + 2 * (myCarrete.B + ab3 + 2 * ab2 + 2 * ab1)
        Else
            mySecundario2.largoMedio = 0
        End If
        If secundario3Habilitado Then
            mySecundario3.largoMedio = 2 * (myCarrete.A + ab4 + 2 * ab3 + 2 * ab2 + 2 * ab1) + 2 * (myCarrete.B + ab4 + 2 * ab3 + 2 * ab2 + 2 * ab1)
        Else
            mySecundario3.largoMedio = 0
        End If
        myPrimario.longitud = myPrimario.vueltas * myPrimario.largoMedio / 1000 '/1000 para pasar a metros
        mySecundario1.longitud = mySecundario1.vueltas * mySecundario1.largoMedio / 1000 '/1000 para pasar a metros
        If secundario2Habilitado Then
            mySecundario2.longitud = mySecundario2.vueltas * mySecundario2.largoMedio / 1000 '/1000 para pasar a metros
        Else
            mySecundario2.longitud = 0
        End If
        If secundario3Habilitado Then
            mySecundario3.longitud = mySecundario3.vueltas * mySecundario3.largoMedio / 1000 '/1000 para pasar a metros
        Else
            mySecundario3.longitud = 0
        End If

        myPrimario.resistencia = myPrimario.longitud * myPrimario.ohmMetro / 1000 ' /1000 para la conversion de ohm/km a ohm/m
        mySecundario1.resistencia = mySecundario1.longitud * mySecundario1.ohmMetro / 1000 ' /1000 para la conversion de ohm/km a ohm/m
        If secundario2Habilitado Then
            mySecundario2.resistencia = mySecundario2.longitud * mySecundario2.ohmMetro / 1000 ' /1000 para la conversion de ohm/km a ohm/m
        Else
            mySecundario2.resistencia = 0
        End If
        If secundario3Habilitado Then
            mySecundario3.resistencia = mySecundario3.longitud * mySecundario3.ohmMetro / 1000 ' /1000 para la conversion de ohm/km a ohm/m
        Else
            mySecundario3.resistencia = 0
        End If
    End Sub
    Sub CalcularPaso7() '7) Calculo de la caida de tension y correcion del numero de espiras
        myPrimario.vueltas = ((myPrimario.voltaje - myPrimario.corriente * myPrimario.resistencia) * myPrimario.vueltas) / myPrimario.voltaje
        mySecundario1.vueltas = ((mySecundario1.voltaje + mySecundario1.corriente * mySecundario1.resistencia) * mySecundario1.vueltas) / mySecundario1.voltaje
        If secundario2Habilitado Then
            mySecundario2.vueltas = ((mySecundario2.voltaje + mySecundario2.corriente * mySecundario2.resistencia) * mySecundario2.vueltas) / mySecundario2.voltaje
        Else
            mySecundario2.vueltas = 0
        End If
        If secundario3Habilitado Then
            mySecundario3.vueltas = ((mySecundario3.voltaje + mySecundario3.corriente * mySecundario3.resistencia) * mySecundario3.vueltas) / mySecundario3.voltaje
        Else
            mySecundario3.vueltas = 0
        End If
    End Sub
    Sub CalcularPaso8() '8) Calculo del rendimiento real del transformador
        perdidaAdicional = myTrafo.potenciaSecundarioTotal / 100 '1% de P2
        myPrimario.perdida = myPrimario.resistencia * myPrimario.corriente * myPrimario.corriente
        mySecundario1.perdida = mySecundario1.resistencia * mySecundario1.corriente * mySecundario1.corriente
        If secundario2Habilitado Then
            mySecundario2.perdida = mySecundario2.resistencia * mySecundario2.corriente * mySecundario2.corriente
        Else
            mySecundario2.perdida = 0
        End If
        If secundario3Habilitado Then
            mySecundario3.perdida = mySecundario3.resistencia * mySecundario3.corriente * mySecundario3.corriente
        Else
            mySecundario3.perdida = 0
        End If

        perdidaCobre = myPrimario.perdida + mySecundario1.perdida + mySecundario2.perdida + mySecundario3.perdida

        Dim volumenNucleo As Double = (myTrafo.Sn / 1000) * 6 * (myLamina.F / 100)
        pesoDelNucleo = 7.8 * volumenNucleo '7.8kg/dm3

        myLamina.gramos = (pesoDelNucleo + pesoDelNucleo / 100) * 10000 'peso del nucleo + 1%

        perdidaDelNucleo = myTrafo.perdidaWKg * myLamina.gramos / 1000

        myTrafo.perdida = perdidaCobre + perdidaDelNucleo + perdidaAdicional
        myTrafo.rendimientoReal = myTrafo.potenciaSecundarioTotal / (myTrafo.potenciaSecundarioTotal + myTrafo.perdida)
    End Sub
    Sub postCalculo()
        myPrimario.gramos = myPrimario.gramosMetro * myPrimario.longitud
        mySecundario1.gramos = mySecundario1.gramosMetro * mySecundario1.longitud
        mySecundario2.gramos = mySecundario2.gramosMetro * mySecundario2.longitud
        mySecundario3.gramos = mySecundario3.gramosMetro * mySecundario3.longitud
        myPrimario.potencia = myPrimario.voltaje * myPrimario.corriente
    End Sub



#End Region

#Region "Subrutinas de entrada/salida e interfaz"
    Sub actualizarSalida()
        ListBox1.Items.Clear()
        Dim linea(15) As String
        Dim lineaPrimario(16) As String
        Dim lineaSecundario1(16) As String
        Dim lineaSecundario2(16) As String
        Dim lineaSecundario3(16) As String

        linea(0) = "Numero de lamina: " & My.Forms.TrafoMaker9000.myLamina.numero
        linea(1) = "Gramos de lamina a comprar: " & rd(My.Forms.TrafoMaker9000.myLamina.gramos).ToString
        linea(2) = "Numero de carrete: " & My.Forms.TrafoMaker9000.myCarrete.numero
        linea(3) = "Frecuencia (Hz): " & My.Forms.TrafoMaker9000.myTrafo.frecuencia.ToString
        linea(4) = "Densidad de corriente (A/mm2): " & My.Forms.TrafoMaker9000.myTrafo.densidadDeCorriente.ToString
        linea(5) = "Rendimiento: " & My.Forms.TrafoMaker9000.myTrafo.rendimiento.ToString
        linea(6) = "Rendimiento Real: " & rd(My.Forms.TrafoMaker9000.myTrafo.rendimientoReal)
        linea(7) = "Coseno Fi: " & My.Forms.TrafoMaker9000.myTrafo.cosenoFi.ToString
        linea(8) = "Constante Bobinado (Mano/Maquina): " & My.Forms.TrafoMaker9000.myTrafo.constanteBobinado.ToString
        linea(9) = "Induccion Bmax (Gauss): " & My.Forms.TrafoMaker9000.myTrafo.induccionBmax.ToString
        linea(10) = "Potencia Secundario Total (W): " & My.Forms.TrafoMaker9000.myTrafo.potenciaSecundarioTotal.ToString
        linea(11) = "Seccion del nucleo (cm2): " & rd(My.Forms.TrafoMaker9000.myTrafo.Sn)
        linea(12) = "Factor de Apilado: " & My.Forms.TrafoMaker9000.myTrafo.factorDeApilado.ToString
        linea(13) = "Perdida (W): " & rd(My.Forms.TrafoMaker9000.myTrafo.perdida)
        linea(14) = "Perdida de la chapa (W/Kg): " & My.Forms.TrafoMaker9000.myTrafo.perdidaWKg.ToString
        linea(15) = "Constante Calculo Sn (k'): " & My.Forms.TrafoMaker9000.myTrafo.constanteCalculoSn.ToString

        lineaPrimario(0) = ""
        lineaPrimario(1) = ""
        lineaPrimario(2) = "Caracteristicas del bobinado primario:"
        lineaPrimario(3) = "Voltaje (V): " & rd(My.Forms.TrafoMaker9000.myPrimario.voltaje)
        lineaPrimario(4) = "Corriente (A): " & rd(My.Forms.TrafoMaker9000.myPrimario.corriente)
        lineaPrimario(5) = "Potencia (W): " & rd(My.Forms.TrafoMaker9000.myPrimario.potencia)
        lineaPrimario(6) = "Calibre (AWG): " & My.Forms.TrafoMaker9000.myPrimario.calibre
        lineaPrimario(7) = "Diametro (mm): " & rd(My.Forms.TrafoMaker9000.myPrimario.diametro)
        lineaPrimario(8) = "Seccion (mm2): " & rd(My.Forms.TrafoMaker9000.myPrimario.seccion)
        lineaPrimario(9) = "Vueltas: " & My.Forms.TrafoMaker9000.myPrimario.vueltas.ToString
        lineaPrimario(10) = "Espiras por Capa: " & My.Forms.TrafoMaker9000.myPrimario.alambresPorCapa.ToString
        lineaPrimario(11) = "Capas: " & My.Forms.TrafoMaker9000.myPrimario.capas.ToString
        lineaPrimario(12) = "Longitud (m): " & rd(My.Forms.TrafoMaker9000.myPrimario.longitud)
        lineaPrimario(13) = "Largo Medio por Vuelta (mm): " & rd(My.Forms.TrafoMaker9000.myPrimario.largoMedio)
        lineaPrimario(14) = "Resistencia (ohm): " & rd(My.Forms.TrafoMaker9000.myPrimario.resistencia)
        lineaPrimario(15) = "Perdida (W): " & rd(My.Forms.TrafoMaker9000.myPrimario.perdida)
        lineaPrimario(16) = "Gramos a comprar: " & My.Forms.TrafoMaker9000.myPrimario.gramos.ToString

        lineaSecundario1(0) = ""
        lineaSecundario1(1) = ""
        lineaSecundario1(2) = "Caracteristicas del bobinado secundario 1:"
        lineaSecundario1(3) = "Voltaje (V): " & rd(My.Forms.TrafoMaker9000.mySecundario1.voltaje)
        lineaSecundario1(4) = "Corriente (A): " & rd(My.Forms.TrafoMaker9000.mySecundario1.corriente)
        lineaSecundario1(5) = "Potencia (W): " & rd(My.Forms.TrafoMaker9000.mySecundario1.potencia)
        lineaSecundario1(6) = "Calibre (AWG): " & My.Forms.TrafoMaker9000.mySecundario1.calibre
        lineaSecundario1(7) = "Diametro (mm): " & rd(My.Forms.TrafoMaker9000.mySecundario1.diametro)
        lineaSecundario1(8) = "Seccion (mm2): " & rd(My.Forms.TrafoMaker9000.mySecundario1.seccion)
        lineaSecundario1(9) = "Vueltas: " & My.Forms.TrafoMaker9000.mySecundario1.vueltas.ToString
        lineaSecundario1(10) = "Espiras por Capa: " & My.Forms.TrafoMaker9000.mySecundario1.alambresPorCapa.ToString
        lineaSecundario1(11) = "Capas: " & My.Forms.TrafoMaker9000.mySecundario1.capas.ToString
        lineaSecundario1(12) = "Longitud (m): " & rd(My.Forms.TrafoMaker9000.mySecundario1.longitud)
        lineaSecundario1(13) = "Largo Medio por Vuelta (mm): " & rd(My.Forms.TrafoMaker9000.mySecundario1.largoMedio).ToString
        lineaSecundario1(14) = "Resistencia (ohm): " & rd(My.Forms.TrafoMaker9000.mySecundario1.resistencia)
        lineaSecundario1(15) = "Perdida (W): " & rd(My.Forms.TrafoMaker9000.mySecundario1.perdida)
        lineaSecundario1(16) = "Gramos a comprar: " & My.Forms.TrafoMaker9000.mySecundario1.gramos.ToString

        lineaSecundario2(0) = ""
        lineaSecundario2(1) = ""
        lineaSecundario2(2) = "Caracteristicas del bobinado secundario 2:"
        lineaSecundario2(3) = "Voltaje (V): " & rd(My.Forms.TrafoMaker9000.mySecundario2.voltaje)
        lineaSecundario2(4) = "Corriente (A): " & rd(My.Forms.TrafoMaker9000.mySecundario2.corriente)
        lineaSecundario2(5) = "Potencia (W): " & rd(My.Forms.TrafoMaker9000.mySecundario2.potencia)
        lineaSecundario2(6) = "Calibre (AWG): " & My.Forms.TrafoMaker9000.mySecundario2.calibre
        lineaSecundario2(7) = "Diametro (mm): " & rd(My.Forms.TrafoMaker9000.mySecundario2.diametro)
        lineaSecundario2(8) = "Seccion (mm2): " & rd(My.Forms.TrafoMaker9000.mySecundario2.seccion)
        lineaSecundario2(9) = "Vueltas: " & My.Forms.TrafoMaker9000.mySecundario2.vueltas.ToString
        lineaSecundario2(10) = "Espiras por Capa: " & My.Forms.TrafoMaker9000.mySecundario2.alambresPorCapa.ToString
        lineaSecundario2(11) = "Capas: " & My.Forms.TrafoMaker9000.mySecundario2.capas.ToString
        lineaSecundario2(12) = "Longitud (m): " & rd(My.Forms.TrafoMaker9000.mySecundario2.longitud)
        lineaSecundario2(13) = "Largo Medio por Vuelta (mm): " & rd(My.Forms.TrafoMaker9000.mySecundario2.largoMedio).ToString
        lineaSecundario2(14) = "Resistencia (ohm): " & rd(My.Forms.TrafoMaker9000.mySecundario2.resistencia)
        lineaSecundario2(15) = "Perdida (W): " & rd(My.Forms.TrafoMaker9000.mySecundario2.perdida)
        lineaSecundario2(16) = "Gramos a comprar: " & My.Forms.TrafoMaker9000.mySecundario2.gramos.ToString

        lineaSecundario3(0) = ""
        lineaSecundario3(1) = ""
        lineaSecundario3(2) = "Caracteristicas del bobinado secundario 3:"
        lineaSecundario3(3) = "Voltaje (V): " & rd(My.Forms.TrafoMaker9000.mySecundario3.voltaje)
        lineaSecundario3(4) = "Corriente (A): " & rd(My.Forms.TrafoMaker9000.mySecundario3.corriente)
        lineaSecundario3(5) = "Potencia (W): " & rd(My.Forms.TrafoMaker9000.mySecundario3.potencia)
        lineaSecundario3(6) = "Calibre (AWG): " & My.Forms.TrafoMaker9000.mySecundario3.calibre
        lineaSecundario3(7) = "Diametro (mm): " & rd(My.Forms.TrafoMaker9000.mySecundario3.diametro)
        lineaSecundario3(8) = "Seccion (mm2): " & rd(My.Forms.TrafoMaker9000.mySecundario3.seccion)
        lineaSecundario3(9) = "Vueltas: " & My.Forms.TrafoMaker9000.mySecundario3.vueltas.ToString
        lineaSecundario3(10) = "Espiras por Capa: " & My.Forms.TrafoMaker9000.mySecundario3.alambresPorCapa.ToString
        lineaSecundario3(11) = "Capas: " & My.Forms.TrafoMaker9000.mySecundario3.capas.ToString
        lineaSecundario3(12) = "Longitud (m): " & rd(My.Forms.TrafoMaker9000.mySecundario3.longitud)
        lineaSecundario3(13) = "Largo Medio por Vuelta (mm): " & rd(My.Forms.TrafoMaker9000.mySecundario3.largoMedio).ToString
        lineaSecundario3(14) = "Resistencia (ohm): " & rd(My.Forms.TrafoMaker9000.mySecundario3.resistencia)
        lineaSecundario3(15) = "Perdida (W): " & rd(My.Forms.TrafoMaker9000.mySecundario3.perdida)
        lineaSecundario3(16) = "Gramos a comprar: " & My.Forms.TrafoMaker9000.mySecundario3.gramos.ToString

        For Each line As String In linea
            ListBox1.Items.Add(line)
        Next
        For Each line As String In lineaPrimario
            ListBox1.Items.Add(line)
        Next
        For Each line As String In lineaSecundario1
            ListBox1.Items.Add(line)
        Next
        If My.Forms.TrafoMaker9000.secundario2Habilitado Then
            For Each line As String In lineaSecundario2
                ListBox1.Items.Add(line)
            Next
        End If
        If My.Forms.TrafoMaker9000.secundario3Habilitado Then
            For Each line As String In lineaSecundario3
                ListBox1.Items.Add(line)
            Next
        End If
    End Sub
    Sub actualizarInterfaz()

        Select Case ComboBoxSecundarios.SelectedIndex
            Case 0
                secundario2Habilitado = False
                secundario3Habilitado = False
            Case 1
                secundario2Habilitado = True
                secundario3Habilitado = False
            Case 2
                secundario2Habilitado = True
                secundario3Habilitado = True
        End Select

        TextBoxPotenciaSecundario1.Enabled = RadioButtonPotencia.Checked
        TextBoxCorrienteSecundario1.Enabled = RadioButtonCorriente.Checked

        If secundario2Habilitado Then
            TextBoxVoltajeSecundario2.Enabled = True
            TextBoxCorrienteSecundario2.Enabled = RadioButtonCorriente.Checked
            TextBoxPotenciaSecundario2.Enabled = RadioButtonPotencia.Checked
        Else
            TextBoxVoltajeSecundario2.Enabled = False
            TextBoxCorrienteSecundario2.Enabled = False
            TextBoxPotenciaSecundario2.Enabled = False
        End If

        If secundario3Habilitado Then
            TextBoxVoltajeSecundario3.Enabled = True
            TextBoxCorrienteSecundario3.Enabled = RadioButtonCorriente.Checked
            TextBoxPotenciaSecundario3.Enabled = RadioButtonPotencia.Checked
        Else
            TextBoxVoltajeSecundario3.Enabled = False
            TextBoxCorrienteSecundario3.Enabled = False
            TextBoxPotenciaSecundario3.Enabled = False
        End If

        If RadioButtonPotencia.Checked Then
            Dim corrientes1 As Double = CDbl(Val(TextBoxPotenciaSecundario1.Text)) / CDbl(Val(TextBoxVoltajeSecundario1.Text))
            TextBoxCorrienteSecundario1.Text = corrientes1.ToString
            If secundario2Habilitado Then
                Dim corrientes2 As Double = CDbl(Val(TextBoxPotenciaSecundario2.Text)) / CDbl(Val(TextBoxVoltajeSecundario2.Text))
                TextBoxCorrienteSecundario2.Text = corrientes2.ToString
            End If
            If secundario3Habilitado Then
                Dim corrientes3 As Double = CDbl(Val(TextBoxPotenciaSecundario3.Text)) / CDbl(Val(TextBoxVoltajeSecundario3.Text))
                TextBoxCorrienteSecundario3.Text = corrientes3.ToString
            End If
        ElseIf RadioButtonCorriente.Checked Then
            Dim potencias1 As Double = CDbl(Val(TextBoxCorrienteSecundario1.Text)) * CDbl(Val(TextBoxVoltajeSecundario1.Text))
            TextBoxPotenciaSecundario1.Text = potencias1.ToString
            If secundario2Habilitado Then
                Dim potencias2 As Double = CDbl(Val(TextBoxCorrienteSecundario2.Text)) * CDbl(Val(TextBoxVoltajeSecundario2.Text))
                TextBoxPotenciaSecundario2.Text = potencias2.ToString
            End If
            If secundario3Habilitado Then
                Dim potencias3 As Double = CDbl(Val(TextBoxCorrienteSecundario3.Text)) * CDbl(Val(TextBoxVoltajeSecundario3.Text))
                TextBoxPotenciaSecundario3.Text = potencias3.ToString
            End If
        End If

        ComboBoxNucleos.Enabled = CheckBoxNucleos.Checked
        TextBoxRendimiento.Enabled = CheckBoxCosenoRendimiento.Checked
        TextBoxCosenoFi.Enabled = CheckBoxCosenoRendimiento.Checked
        TextBoxPotenciaTotal.Enabled = CheckBoxPotencia.Checked

        If checkearEntradas() Then
            mySecundario1.potencia = CDbl(Val(TextBoxPotenciaSecundario1.Text))

            If secundario2Habilitado Then
                mySecundario2.potencia = CDbl(Val(TextBoxPotenciaSecundario2.Text))
            Else
                mySecundario2.potencia = 0
            End If
            If secundario3Habilitado Then
                mySecundario3.potencia = CDbl(Val(TextBoxPotenciaSecundario3.Text))
            Else
                mySecundario3.potencia = 0
            End If

            If CheckBoxPotencia.Checked Then
                myTrafo.potenciaSecundarioTotal = CDbl(Val(TextBoxPotenciaTotal.Text))
            Else
                myTrafo.potenciaSecundarioTotal = mySecundario1.potencia + mySecundario2.potencia + mySecundario3.potencia 'Se establece la potencia total de las salidas del transformador
            End If

            myTrafo.constanteCalculoSn = CDbl(Val(TextBoxSn.Text))

            TextBoxPotenciaTotal.Text = rd(myTrafo.potenciaSecundarioTotal).ToString

            myTrafo.Sn = myTrafo.constanteCalculoSn * Math.Sqrt(myTrafo.potenciaSecundarioTotal) 'Valor en Cm2

            LabelSnRecomendada.Text = "Sn recomendada [cm2]: " & rd(myTrafo.Sn)
            End If

    End Sub
    Sub cargarNucleos()
        worksheet = workbook.Worksheets("Carretes") 'Abrir hoja "Carretes"
        Dim ultimaFila As Integer = obtenerUltimaFila()

        For i As Integer = 2 To ultimaFila

            Dim carrete As String = worksheet.Cells(i, 1).value.ToString
            Dim seccion As Double = worksheet.Cells(i, 7).value

            Dim linea As String = "Sn[cm2]: " & rd(seccion) & "  Carrete Nº: " & carrete

            ComboBoxNucleos.Items.Add(linea)
        Next
        ComboBoxNucleos.SelectedIndex = 1
    End Sub
#End Region

End Class