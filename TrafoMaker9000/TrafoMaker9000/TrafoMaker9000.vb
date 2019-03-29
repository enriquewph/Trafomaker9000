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
    Public entra As Boolean = True
    Public seRecalcula As Boolean = False
    Public recalcularOffset As Integer = 0
    Public modopotencia As Boolean = True

    Public ab1, ab2, ab3, ab4 As Double
    Public perdidaCobre As Double = 0
    Public perdidaAdicional As Double = 0
    Public perdidaDelNucleo As Double = 0
    Public precioLaminas As Double = 0
    Public precioTotalEstimado As Double = 0
    Public puntoMedio1habilitado As Boolean = False
    Public puntoMedio1Vueltas As Integer = 0
    Public puntoMedio2habilitado As Boolean = False
    Public puntoMedio2Vueltas As Integer = 0
    Public puntoMedio3habilitado As Boolean = False
    Public puntoMedio3Vueltas As Integer = 0

#End Region
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxPrincipal.SelectedIndex = 2 'Seleccionar por defecto 220v50hz
        ComboBoxBobinado.SelectedIndex = 0 'Seleccionar por defecto bobinado a maquina
        ComboBoxSecundarios.SelectedIndex = 0
        RadioButtonCorriente.Checked = False
        RadioButtonPotencia.Checked = True

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
        perdidaAdicional = 0
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
    Private Sub ButtonOpciones_Click(sender As Object, e As EventArgs) Handles ButtonOpciones.Click
        My.Forms.Opciones.Show()
    End Sub
    Private Sub ButtonInformacion_Click(sender As Object, e As EventArgs) Handles ButtonInformacion.Click
        MsgBox("Autor: Enrique Walter Philippeaux" & vbNewLine & "Email: quique18c@gmail.com" & vbNewLine & "Version: " & ProductVersion, MsgBoxStyle.Information)
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
                If mayoramaxerror And value > valMax Then
                    errorentrada = True
                    TextBox.foreColor = Color.Red
                End If
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
        checkEntrada(TextBoxPotenciaSecundario1, False, 1)

        If secundario2Habilitado Then
            checkEntrada(TextBoxVoltajeSecundario2, False, 1)
            checkEntrada(TextBoxPotenciaSecundario2, False, 1)
        End If
        If secundario3Habilitado Then
            checkEntrada(TextBoxVoltajeSecundario3, False, 1)
            checkEntrada(TextBoxPotenciaSecundario3, False, 1)
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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
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
        myCarrete.Precio = worksheet.Cells(filaCarrete, 9).value

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
        Dim pesoDelNucleo As Double = 7.8 * volumenNucleo '7.8kg/dm3

        myLamina.gramos = (pesoDelNucleo + pesoDelNucleo / 100) * 10000 'peso del nucleo + 1%

        perdidaDelNucleo = myTrafo.perdidaWKg * myLamina.gramos / 1000

        myTrafo.perdida = perdidaCobre + perdidaDelNucleo + perdidaAdicional
        myTrafo.rendimientoReal = myTrafo.potenciaSecundarioTotal / (myTrafo.potenciaSecundarioTotal + myTrafo.perdida)
    End Sub
    Sub postCalculo()

        puntoMedio1habilitado = PuntoMedio1.Checked
        puntoMedio2habilitado = PuntoMedio2.Checked And secundario2Habilitado
        puntoMedio3habilitado = PuntoMedio3.Checked And secundario3Habilitado

        If puntoMedio1habilitado Then
            puntoMedio1Vueltas = mySecundario1.vueltas / 2
            mySecundario1.longitud = mySecundario1.longitud + 0.05
        End If

        If puntoMedio2habilitado Then
            puntoMedio2Vueltas = mySecundario2.vueltas / 2
            mySecundario2.longitud = mySecundario2.longitud + 0.05
        End If

        If puntoMedio3habilitado Then
            puntoMedio3Vueltas = mySecundario3.vueltas / 2
            mySecundario3.longitud = mySecundario3.longitud + 0.05
        End If

        myPrimario.gramos = myPrimario.gramosMetro * myPrimario.longitud
        mySecundario1.gramos = mySecundario1.gramosMetro * mySecundario1.longitud
        mySecundario2.gramos = mySecundario2.gramosMetro * mySecundario2.longitud
        mySecundario3.gramos = mySecundario3.gramosMetro * mySecundario3.longitud

        precioLaminas = (myLamina.gramos / 1000) * My.Settings.PesosKgLaminas

        myPrimario.Precio = (myPrimario.gramos / 1000) * My.Settings.PesosKgAlambre
        mySecundario1.Precio = (mySecundario1.gramos / 1000) * My.Settings.PesosKgAlambre
        mySecundario2.Precio = (mySecundario2.gramos / 1000) * My.Settings.PesosKgAlambre
        mySecundario3.Precio = (mySecundario3.gramos / 1000) * My.Settings.PesosKgAlambre

        myPrimario.potencia = myPrimario.voltaje * myPrimario.corriente

        precioTotalEstimado = precioLaminas + myCarrete.Precio + myPrimario.Precio + mySecundario1.Precio + mySecundario2.Precio + mySecundario3.Precio
    End Sub
#End Region

#Region "Subrutinas de entrada/salida e interfaz"
    Sub actualizarSalida()
        ListBox1.Items.Clear()
        Dim linea(22) As String

        linea(0) = "Numero de lamina: " & myLamina.numero
        linea(1) = "Gramos de lamina a comprar: " & rd(myLamina.gramos).ToString & " g"
        linea(2) = "Numero de carrete: " & myCarrete.numero
        linea(3) = "Frecuencia de trabajo: " & myTrafo.frecuencia.ToString & " Hz"
        linea(4) = "Densidad de corriente: " & myTrafo.densidadDeCorriente.ToString & " A/mm2"
        linea(5) = "Rendimiento: " & myTrafo.rendimiento.ToString
        linea(6) = "Rendimiento Real: " & rd(myTrafo.rendimientoReal).ToString
        linea(7) = "Coseno Fi: " & myTrafo.cosenoFi.ToString
        linea(8) = "Constante Bobinado (Mano/Maquina): " & myTrafo.constanteBobinado.ToString
        linea(9) = "Induccion Bmax: " & myTrafo.induccionBmax.ToString & " Gauss"
        linea(10) = "Potencia Secundario Total: " & myTrafo.potenciaSecundarioTotal.ToString & " W"
        linea(11) = "Seccion del nucleo: " & rd(myTrafo.Sn).ToString & " cm2"
        linea(12) = "Factor de Apilado: " & myTrafo.factorDeApilado.ToString
        linea(13) = "Perdida en conductores: " & rd(perdidaCobre).ToString & " W"
        linea(14) = "Perdida en el nucleo: " & rd(perdidaDelNucleo).ToString & " W"
        linea(15) = "Perdida adicional: " & rd(perdidaAdicional).ToString & " W"
        linea(16) = "Perdida: " & rd(myTrafo.perdida).ToString & " W"
        linea(17) = "Coeficiente Perdida de la chapa: " & myTrafo.perdidaWKg.ToString & " W/Kg"
        linea(18) = "Constante Calculo Sn (k'): " & myTrafo.constanteCalculoSn.ToString
        linea(19) = "Precio del carrete: " & rd(myCarrete.Precio).ToString & "$"
        linea(20) = "Precio de las laminas: " & rd(precioLaminas).ToString & "$"
        linea(21) = "Precio del cobre: " & rd(myPrimario.Precio + mySecundario1.Precio + mySecundario2.Precio + mySecundario3.Precio).ToString & "$"
        linea(22) = "Precio total estimado: " & rd(precioTotalEstimado).ToString & "$"

        Dim lineaPrimario(18) As String
        lineaPrimario(0) = ""
        lineaPrimario(1) = ""
        lineaPrimario(2) = "Caracteristicas del bobinado primario:"
        lineaPrimario(3) = "Voltaje: " & rd(myPrimario.voltaje) & " V"
        lineaPrimario(4) = "Corriente: " & rd(myPrimario.corriente) & " A"
        lineaPrimario(5) = "Potencia: " & rd(myPrimario.potencia) & " W"
        lineaPrimario(6) = "Calibre (AWG): " & myPrimario.calibre
        lineaPrimario(7) = "Diametro: " & rd(myPrimario.diametro) & " mm"
        lineaPrimario(8) = "Seccion: " & rd(myPrimario.seccion) & " mm2"
        lineaPrimario(9) = "Vueltas: " & myPrimario.vueltas.ToString
        lineaPrimario(10) = "Espiras por Capa: " & myPrimario.alambresPorCapa.ToString
        lineaPrimario(11) = "Capas: " & myPrimario.capas.ToString
        lineaPrimario(12) = "Longitud: " & rd(myPrimario.longitud) & " m"
        lineaPrimario(13) = "Largo Medio por Vuelta: " & rd(myPrimario.largoMedio) & " mm"
        lineaPrimario(14) = "Ancho del bobinado estimado: " & rd(ab1) & " mm"
        lineaPrimario(15) = "Resistencia: " & rd(myPrimario.resistencia) & " ohm"
        lineaPrimario(16) = "Perdida: " & rd(myPrimario.perdida) & " W"
        lineaPrimario(17) = "Gramos a comprar: " & myPrimario.gramos.ToString & " g"
        lineaPrimario(18) = "Precio estimado: " & myPrimario.Precio.ToString & "$"

        Dim lineaSecundario1(19) As String
        lineaSecundario1(0) = ""
        lineaSecundario1(1) = ""
        lineaSecundario1(2) = "Caracteristicas del bobinado secundario 1:"
        If puntoMedio1habilitado Then
            lineaSecundario1(3) = "Voltaje: " & rd(mySecundario1.voltaje) / 2 & "+" & rd(mySecundario1.voltaje) / 2 & " V"
        Else
            lineaSecundario1(3) = "Voltaje: " & rd(mySecundario1.voltaje) & " V"
        End If
        lineaSecundario1(4) = "Corriente: " & rd(mySecundario1.corriente) & " A"
        lineaSecundario1(5) = "Potencia: " & rd(mySecundario1.potencia) & " W"
        lineaSecundario1(6) = "Calibre (AWG): " & mySecundario1.calibre
        lineaSecundario1(7) = "Diametro: " & rd(mySecundario1.diametro) & " mm"
        lineaSecundario1(8) = "Seccion: " & rd(mySecundario1.seccion) & " mm2"
        lineaSecundario1(9) = "Vueltas: " & mySecundario1.vueltas.ToString
        If puntoMedio1habilitado Then
            lineaSecundario1(10) = "Vueltas al punto medio: " & puntoMedio1Vueltas
        Else
            lineaSecundario1(10) = "Bobinado sin punto medio."
        End If
        lineaSecundario1(11) = "Espiras por Capa: " & mySecundario1.alambresPorCapa.ToString
        lineaSecundario1(12) = "Capas: " & mySecundario1.capas.ToString
        lineaSecundario1(13) = "Longitud: " & rd(mySecundario1.longitud) & " m"
        lineaSecundario1(14) = "Largo Medio por Vuelta: " & rd(mySecundario1.largoMedio) & " mm"
        lineaSecundario1(15) = "Ancho del bobinado estimado: " & rd(ab2) & " mm"
        lineaSecundario1(16) = "Resistencia: " & rd(mySecundario1.resistencia) & " ohm"
        lineaSecundario1(17) = "Perdida: " & rd(mySecundario1.perdida) & " W"
        lineaSecundario1(18) = "Gramos a comprar: " & mySecundario1.gramos.ToString & " g"
        lineaSecundario1(19) = "Precio estimado: " & mySecundario1.Precio.ToString & "$"

        Dim lineaSecundario2(19) As String
        lineaSecundario2(0) = ""
        lineaSecundario2(1) = ""
        lineaSecundario2(2) = "Caracteristicas del bobinado secundario 2:"
        If puntoMedio2habilitado Then
            lineaSecundario2(3) = "Voltaje: " & rd(mySecundario2.voltaje) / 2 & "+" & rd(mySecundario2.voltaje) / 2 & " V"
        Else
            lineaSecundario2(3) = "Voltaje: " & rd(mySecundario2.voltaje) & " V"
        End If
        lineaSecundario2(4) = "Corriente: " & rd(mySecundario2.corriente) & " A"
        lineaSecundario2(5) = "Potencia: " & rd(mySecundario2.potencia) & " W"
        lineaSecundario2(6) = "Calibre (AWG): " & mySecundario2.calibre
        lineaSecundario2(7) = "Diametro: " & rd(mySecundario2.diametro) & " mm"
        lineaSecundario2(8) = "Seccion: " & rd(mySecundario2.seccion) & " mm2"
        lineaSecundario2(9) = "Vueltas: " & mySecundario2.vueltas.ToString
        If puntoMedio2habilitado Then
            lineaSecundario2(10) = "Vueltas al punto medio: " & puntoMedio2Vueltas
        Else
            lineaSecundario2(10) = "Bobinado sin punto medio."
        End If
        lineaSecundario2(11) = "Espiras por Capa: " & mySecundario2.alambresPorCapa.ToString
        lineaSecundario2(12) = "Capas: " & mySecundario2.capas.ToString
        lineaSecundario2(13) = "Longitud: " & rd(mySecundario2.longitud) & " m"
        lineaSecundario2(14) = "Largo Medio por Vuelta: " & rd(mySecundario2.largoMedio) & " mm"
        lineaSecundario2(15) = "Ancho del bobinado estimado: " & rd(ab2) & " mm"
        lineaSecundario2(16) = "Resistencia: " & rd(mySecundario2.resistencia) & " ohm"
        lineaSecundario2(17) = "Perdida: " & rd(mySecundario2.perdida) & " W"
        lineaSecundario2(18) = "Gramos a comprar: " & mySecundario2.gramos.ToString & " g"
        lineaSecundario2(19) = "Precio estimado: " & mySecundario2.Precio.ToString & "$"

        Dim lineaSecundario3(19) As String
        lineaSecundario3(0) = ""
        lineaSecundario3(1) = ""
        lineaSecundario3(2) = "Caracteristicas del bobinado secundario 3:"
        If puntoMedio3habilitado Then
            lineaSecundario3(3) = "Voltaje: " & rd(mySecundario3.voltaje) / 2 & "+" & rd(mySecundario3.voltaje) / 2 & " V"
        Else
            lineaSecundario3(3) = "Voltaje: " & rd(mySecundario3.voltaje) & " V"
        End If
        lineaSecundario3(4) = "Corriente: " & rd(mySecundario3.corriente) & " A"
        lineaSecundario3(5) = "Potencia: " & rd(mySecundario3.potencia) & " W"
        lineaSecundario3(6) = "Calibre (AWG): " & mySecundario3.calibre
        lineaSecundario3(7) = "Diametro: " & rd(mySecundario3.diametro) & " mm"
        lineaSecundario3(8) = "Seccion: " & rd(mySecundario3.seccion) & " mm2"
        lineaSecundario3(9) = "Vueltas: " & mySecundario3.vueltas.ToString
        If puntoMedio3habilitado Then
            lineaSecundario3(10) = "Vueltas al punto medio: " & puntoMedio3Vueltas
        Else
            lineaSecundario3(10) = "Bobinado sin punto medio."
        End If
        lineaSecundario3(11) = "Espiras por Capa: " & mySecundario3.alambresPorCapa.ToString
        lineaSecundario3(12) = "Capas: " & mySecundario3.capas.ToString
        lineaSecundario3(13) = "Longitud: " & rd(mySecundario3.longitud) & " m"
        lineaSecundario3(14) = "Largo Medio por Vuelta: " & rd(mySecundario3.largoMedio) & " mm"
        lineaSecundario3(15) = "Ancho del bobinado estimado: " & rd(ab2) & " mm"
        lineaSecundario3(16) = "Resistencia: " & rd(mySecundario3.resistencia) & " ohm"
        lineaSecundario3(17) = "Perdida: " & rd(mySecundario3.perdida) & " W"
        lineaSecundario3(18) = "Gramos a comprar: " & mySecundario3.gramos.ToString & " g"
        lineaSecundario3(19) = "Precio estimado: " & mySecundario3.Precio.ToString & "$"

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
        If RadioButtonPotencia.Checked = True And RadioButtonCorriente.Checked = False Then
            modopotencia = True
            Label3.Text = "Potencia[W]:"
            Label5.Text = "Potencia[W]:"
            Label20.Text = "Potencia[W]:"
        Else
            modopotencia = False
            Label3.Text = "Corriente[A]:"
            Label5.Text = "Corriente[A]:"
            Label20.Text = "Corriente[A]:"
        End If

        Select Case ComboBoxSecundarios.SelectedIndex
            Case 0
                secundario2Habilitado = False
                secundario3Habilitado = False
                TextBoxVoltajeSecundario2.Enabled = False
                TextBoxPotenciaSecundario2.Enabled = False
                TextBoxVoltajeSecundario3.Enabled = False
                TextBoxPotenciaSecundario3.Enabled = False
                TextBoxVoltajeSecundario2.Text = ""
                TextBoxPotenciaSecundario2.Text = ""
                TextBoxVoltajeSecundario3.Text = ""
                TextBoxPotenciaSecundario3.Text = ""

            Case 1
                secundario2Habilitado = True
                secundario3Habilitado = False
                TextBoxVoltajeSecundario2.Enabled = True
                TextBoxPotenciaSecundario2.Enabled = True
                TextBoxVoltajeSecundario3.Enabled = False
                TextBoxPotenciaSecundario3.Enabled = False
                TextBoxVoltajeSecundario3.Text = ""
                TextBoxPotenciaSecundario3.Text = ""
            Case 2
                secundario2Habilitado = True
                secundario3Habilitado = True
                TextBoxVoltajeSecundario2.Enabled = True
                TextBoxPotenciaSecundario2.Enabled = True
                TextBoxVoltajeSecundario3.Enabled = True
                TextBoxPotenciaSecundario3.Enabled = True
        End Select

        ComboBoxNucleos.Enabled = CheckBoxNucleos.Checked
        TextBoxRendimiento.Enabled = CheckBoxCosenoRendimiento.Checked
        TextBoxCosenoFi.Enabled = CheckBoxCosenoRendimiento.Checked
        TextBoxPotenciaTotal.Enabled = CheckBoxPotencia.Checked

        If checkearEntradas() Then

            mySecundario1.voltaje = CDbl(Val(TextBoxVoltajeSecundario1.Text))
            If modopotencia Then
                mySecundario1.potencia = CDbl(Val(TextBoxPotenciaSecundario1.Text))
                mySecundario1.corriente = mySecundario1.potencia / mySecundario1.voltaje
            Else
                mySecundario1.corriente = CDbl(Val(TextBoxPotenciaSecundario1.Text))
                mySecundario1.potencia = mySecundario1.corriente * mySecundario1.voltaje
            End If

            If secundario2Habilitado Then
                mySecundario2.voltaje = CDbl(Val(TextBoxVoltajeSecundario2.Text))
                If modopotencia Then
                    mySecundario2.potencia = CDbl(Val(TextBoxPotenciaSecundario2.Text))
                    mySecundario2.corriente = mySecundario2.potencia / mySecundario2.voltaje
                Else
                    mySecundario2.corriente = CDbl(Val(TextBoxPotenciaSecundario2.Text))
                    mySecundario2.potencia = mySecundario2.corriente * mySecundario2.voltaje
                End If
            Else
                mySecundario2.voltaje = 0
                mySecundario2.corriente = 0
                mySecundario2.potencia = 0
            End If

            If secundario3Habilitado Then
                mySecundario3.voltaje = CDbl(Val(TextBoxVoltajeSecundario3.Text))
                If modopotencia Then
                    mySecundario3.potencia = CDbl(Val(TextBoxPotenciaSecundario3.Text))
                    mySecundario3.corriente = mySecundario3.potencia / mySecundario3.voltaje
                Else
                    mySecundario3.corriente = CDbl(Val(TextBoxPotenciaSecundario3.Text))
                    mySecundario3.potencia = mySecundario3.corriente * mySecundario3.voltaje
                End If
            Else
                mySecundario3.voltaje = 0
                mySecundario3.corriente = 0
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