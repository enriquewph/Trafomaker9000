<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TrafoMaker9000
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TrafoMaker9000))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxPrincipal = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxPotenciaSecundario1 = New System.Windows.Forms.TextBox()
        Me.TextBoxVoltajeSecundario1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonCorriente = New System.Windows.Forms.RadioButton()
        Me.RadioButtonPotencia = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBoxPotenciaSecundario3 = New System.Windows.Forms.TextBox()
        Me.TextBoxVoltajeSecundario3 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxPotenciaSecundario2 = New System.Windows.Forms.TextBox()
        Me.TextBoxVoltajeSecundario2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ComboBoxSecundarios = New System.Windows.Forms.ComboBox()
        Me.TextBoxDensidad = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBoxBobinado = New System.Windows.Forms.ComboBox()
        Me.TextBoxInduccion = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxCosenoRendimiento = New System.Windows.Forms.CheckBox()
        Me.TextBoxPotenciaTotal = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBoxSn = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CheckBoxPotencia = New System.Windows.Forms.CheckBox()
        Me.TextBoxCosenoFi = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxRendimiento = New System.Windows.Forms.TextBox()
        Me.TextBoxPerdidaWKg = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CheckBoxSoloNucleosCuadrados = New System.Windows.Forms.CheckBox()
        Me.ComboBoxNucleos = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LabelSnRecomendada = New System.Windows.Forms.Label()
        Me.CheckBoxNucleos = New System.Windows.Forms.CheckBox()
        Me.ButtonCalcular = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonOpciones = New System.Windows.Forms.Button()
        Me.ButtonInformacion = New System.Windows.Forms.Button()
        Me.ContextMenuV1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PuntoMedio1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuV2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PuntoMedio2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuV3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PuntoMedio3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.ContextMenuV1.SuspendLayout()
        Me.ContextMenuV2.SuspendLayout()
        Me.ContextMenuV3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Principal:"
        Me.ToolTip1.SetToolTip(Me.Label1, "Seleccionar Voltaje y Frecuencia del bobinado primario.")
        '
        'ComboBoxPrincipal
        '
        Me.ComboBoxPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPrincipal.FormattingEnabled = True
        Me.ComboBoxPrincipal.Items.AddRange(New Object() {"380V 50Hz", "240V 50Hz", "220V 50Hz", "127V 50Hz", "190V 60Hz", "120V 60Hz", "110V 60Hz", "63.5V 60Hz"})
        Me.ComboBoxPrincipal.Location = New System.Drawing.Point(62, 13)
        Me.ComboBoxPrincipal.Name = "ComboBoxPrincipal"
        Me.ComboBoxPrincipal.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxPrincipal.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.ComboBoxPrincipal, "Seleccionar Voltaje y Frecuencia del bobinado primario.")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxPotenciaSecundario1)
        Me.GroupBox1.Controls.Add(Me.TextBoxVoltajeSecundario1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(177, 73)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Secundario 1:"
        '
        'TextBoxPotenciaSecundario1
        '
        Me.TextBoxPotenciaSecundario1.Location = New System.Drawing.Point(86, 45)
        Me.TextBoxPotenciaSecundario1.Name = "TextBoxPotenciaSecundario1"
        Me.TextBoxPotenciaSecundario1.Size = New System.Drawing.Size(85, 20)
        Me.TextBoxPotenciaSecundario1.TabIndex = 3
        Me.TextBoxPotenciaSecundario1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxPotenciaSecundario1, "Potencia del bobinado")
        '
        'TextBoxVoltajeSecundario1
        '
        Me.TextBoxVoltajeSecundario1.ContextMenuStrip = Me.ContextMenuV1
        Me.TextBoxVoltajeSecundario1.Location = New System.Drawing.Point(86, 19)
        Me.TextBoxVoltajeSecundario1.Name = "TextBoxVoltajeSecundario1"
        Me.TextBoxVoltajeSecundario1.Size = New System.Drawing.Size(85, 20)
        Me.TextBoxVoltajeSecundario1.TabIndex = 2
        Me.TextBoxVoltajeSecundario1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxVoltajeSecundario1, "Voltaje eficaz del bobinado.")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Potencia[W]:"
        Me.ToolTip1.SetToolTip(Me.Label3, "Potencia/corriente del bobinado")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Voltaje[V]:"
        Me.ToolTip1.SetToolTip(Me.Label2, "Voltaje eficaz del bobinado.")
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RadioButtonCorriente)
        Me.GroupBox4.Controls.Add(Me.RadioButtonPotencia)
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.ComboBoxSecundarios)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.ComboBoxPrincipal)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(190, 334)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Bobinados"
        '
        'RadioButtonCorriente
        '
        Me.RadioButtonCorriente.AutoSize = True
        Me.RadioButtonCorriente.Location = New System.Drawing.Point(10, 304)
        Me.RadioButtonCorriente.Name = "RadioButtonCorriente"
        Me.RadioButtonCorriente.Size = New System.Drawing.Size(67, 17)
        Me.RadioButtonCorriente.TabIndex = 12
        Me.RadioButtonCorriente.TabStop = True
        Me.RadioButtonCorriente.Text = "Corriente"
        Me.RadioButtonCorriente.UseVisualStyleBackColor = True
        '
        'RadioButtonPotencia
        '
        Me.RadioButtonPotencia.AutoSize = True
        Me.RadioButtonPotencia.Location = New System.Drawing.Point(111, 304)
        Me.RadioButtonPotencia.Name = "RadioButtonPotencia"
        Me.RadioButtonPotencia.Size = New System.Drawing.Size(67, 17)
        Me.RadioButtonPotencia.TabIndex = 11
        Me.RadioButtonPotencia.TabStop = True
        Me.RadioButtonPotencia.Text = "Potencia"
        Me.RadioButtonPotencia.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBoxPotenciaSecundario3)
        Me.GroupBox3.Controls.Add(Me.TextBoxVoltajeSecundario3)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 225)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(177, 73)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Secundario 3:"
        '
        'TextBoxPotenciaSecundario3
        '
        Me.TextBoxPotenciaSecundario3.Location = New System.Drawing.Point(86, 45)
        Me.TextBoxPotenciaSecundario3.Name = "TextBoxPotenciaSecundario3"
        Me.TextBoxPotenciaSecundario3.Size = New System.Drawing.Size(85, 20)
        Me.TextBoxPotenciaSecundario3.TabIndex = 3
        Me.TextBoxPotenciaSecundario3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxPotenciaSecundario3, "Potencia del bobinado")
        '
        'TextBoxVoltajeSecundario3
        '
        Me.TextBoxVoltajeSecundario3.ContextMenuStrip = Me.ContextMenuV3
        Me.TextBoxVoltajeSecundario3.Location = New System.Drawing.Point(86, 19)
        Me.TextBoxVoltajeSecundario3.Name = "TextBoxVoltajeSecundario3"
        Me.TextBoxVoltajeSecundario3.Size = New System.Drawing.Size(85, 20)
        Me.TextBoxVoltajeSecundario3.TabIndex = 2
        Me.TextBoxVoltajeSecundario3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxVoltajeSecundario3, "Voltaje eficaz del bobinado.")
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 48)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Potencia[W]:"
        Me.ToolTip1.SetToolTip(Me.Label20, "Potencia/corriente del bobinado")
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(24, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Voltaje[V]:"
        Me.ToolTip1.SetToolTip(Me.Label21, "Voltaje eficaz del bobinado.")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxPotenciaSecundario2)
        Me.GroupBox2.Controls.Add(Me.TextBoxVoltajeSecundario2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 146)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(177, 73)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Secundario 2:"
        '
        'TextBoxPotenciaSecundario2
        '
        Me.TextBoxPotenciaSecundario2.Location = New System.Drawing.Point(86, 45)
        Me.TextBoxPotenciaSecundario2.Name = "TextBoxPotenciaSecundario2"
        Me.TextBoxPotenciaSecundario2.Size = New System.Drawing.Size(85, 20)
        Me.TextBoxPotenciaSecundario2.TabIndex = 3
        Me.TextBoxPotenciaSecundario2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxPotenciaSecundario2, "Potencia del bobinado")
        '
        'TextBoxVoltajeSecundario2
        '
        Me.TextBoxVoltajeSecundario2.ContextMenuStrip = Me.ContextMenuV2
        Me.TextBoxVoltajeSecundario2.Location = New System.Drawing.Point(86, 19)
        Me.TextBoxVoltajeSecundario2.Name = "TextBoxVoltajeSecundario2"
        Me.TextBoxVoltajeSecundario2.Size = New System.Drawing.Size(85, 20)
        Me.TextBoxVoltajeSecundario2.TabIndex = 2
        Me.TextBoxVoltajeSecundario2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxVoltajeSecundario2, "Voltaje eficaz del bobinado.")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Potencia[W]:"
        Me.ToolTip1.SetToolTip(Me.Label5, "Potencia/corriente del bobinado")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Voltaje[V]:"
        Me.ToolTip1.SetToolTip(Me.Label6, "Voltaje eficaz del bobinado.")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 43)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Nº Secundarios:"
        '
        'ComboBoxSecundarios
        '
        Me.ComboBoxSecundarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSecundarios.FormattingEnabled = True
        Me.ComboBoxSecundarios.Items.AddRange(New Object() {"1", "2", "3"})
        Me.ComboBoxSecundarios.Location = New System.Drawing.Point(96, 40)
        Me.ComboBoxSecundarios.Name = "ComboBoxSecundarios"
        Me.ComboBoxSecundarios.Size = New System.Drawing.Size(87, 21)
        Me.ComboBoxSecundarios.TabIndex = 8
        '
        'TextBoxDensidad
        '
        Me.TextBoxDensidad.Location = New System.Drawing.Point(167, 13)
        Me.TextBoxDensidad.Name = "TextBoxDensidad"
        Me.TextBoxDensidad.Size = New System.Drawing.Size(58, 20)
        Me.TextBoxDensidad.TabIndex = 7
        Me.TextBoxDensidad.Text = "3"
        Me.TextBoxDensidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxDensidad, "Densidad de corriente en A/mm2.")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Densidad de corriente[A/mm2]:"
        Me.ToolTip1.SetToolTip(Me.Label8, "Densidad de corriente en A/mm2." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ver tabla.")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 78)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Segun Refrigeración:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2-4 A/mm2: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4-6 A/mm2: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6-8 A/mm2: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7-9 A/mm2: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9-10A/m" &
    "m2: "
        '
        'ComboBoxBobinado
        '
        Me.ComboBoxBobinado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBobinado.FormattingEnabled = True
        Me.ComboBoxBobinado.Items.AddRange(New Object() {"Bobinado a máquina", "Bobinado a mano"})
        Me.ComboBoxBobinado.Location = New System.Drawing.Point(7, 147)
        Me.ComboBoxBobinado.Name = "ComboBoxBobinado"
        Me.ComboBoxBobinado.Size = New System.Drawing.Size(219, 21)
        Me.ComboBoxBobinado.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.ComboBoxBobinado, "Tipo de bobinado.")
        '
        'TextBoxInduccion
        '
        Me.TextBoxInduccion.Location = New System.Drawing.Point(107, 19)
        Me.TextBoxInduccion.Name = "TextBoxInduccion"
        Me.TextBoxInduccion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBoxInduccion.Size = New System.Drawing.Size(77, 20)
        Me.TextBoxInduccion.TabIndex = 13
        Me.TextBoxInduccion.Text = "11000"
        Me.ToolTip1.SetToolTip(Me.TextBoxInduccion, "Para el Fe-Si:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8000 Gauss (malo)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9000 Gauss (regular)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "10000 Gauss (bueno)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "110" &
        "00 Gauss (excelente)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Para Fe-Si de grano orientado:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "16000 Gauss" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "17000 Gauss" &
        "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "18000 Gauss")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Induccion[Gauss]:"
        Me.ToolTip1.SetToolTip(Me.Label13, resources.GetString("Label13.ToolTip"))
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Rendimiento:"
        Me.ToolTip1.SetToolTip(Me.Label10, "Rendimiento asumido para calcular el transformador." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No es el rendimiento real qu" &
        "e tendra el transformador." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Valor recomendado: 0.9.")
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.TextBoxDensidad)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Location = New System.Drawing.Point(211, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(232, 122)
        Me.GroupBox6.TabIndex = 14
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Densidad de corriente"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(83, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(142, 65)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Natural " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Forzada" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Aceite Natural" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Aceite Forzado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Aceite Forzado/Aire Forzado"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckBoxCosenoRendimiento)
        Me.GroupBox7.Controls.Add(Me.TextBoxPotenciaTotal)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.TextBoxSn)
        Me.GroupBox7.Controls.Add(Me.ComboBoxBobinado)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Controls.Add(Me.CheckBoxPotencia)
        Me.GroupBox7.Controls.Add(Me.TextBoxCosenoFi)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.TextBoxRendimiento)
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Location = New System.Drawing.Point(211, 140)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(232, 180)
        Me.GroupBox7.TabIndex = 15
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Constantes para el cálculo"
        '
        'CheckBoxCosenoRendimiento
        '
        Me.CheckBoxCosenoRendimiento.AutoSize = True
        Me.CheckBoxCosenoRendimiento.Location = New System.Drawing.Point(139, 49)
        Me.CheckBoxCosenoRendimiento.Name = "CheckBoxCosenoRendimiento"
        Me.CheckBoxCosenoRendimiento.Size = New System.Drawing.Size(87, 17)
        Me.CheckBoxCosenoRendimiento.TabIndex = 24
        Me.CheckBoxCosenoRendimiento.Text = "Sobreescribir"
        Me.ToolTip1.SetToolTip(Me.CheckBoxCosenoRendimiento, "Se editaran los valores de las constantes para el cálculo.")
        Me.CheckBoxCosenoRendimiento.UseVisualStyleBackColor = True
        '
        'TextBoxPotenciaTotal
        '
        Me.TextBoxPotenciaTotal.Enabled = False
        Me.TextBoxPotenciaTotal.Location = New System.Drawing.Point(143, 72)
        Me.TextBoxPotenciaTotal.Name = "TextBoxPotenciaTotal"
        Me.TextBoxPotenciaTotal.Size = New System.Drawing.Size(82, 20)
        Me.TextBoxPotenciaTotal.TabIndex = 23
        Me.TextBoxPotenciaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxPotenciaTotal, "Ingrese un valor aqui si desea utilizar otra potencia" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "secundaria total para los " &
        "calculos del transformador.")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 75)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(129, 13)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Potencia Secundario [W]:"
        Me.ToolTip1.SetToolTip(Me.Label16, "Ingrese un valor aqui si desea utilizar otra potencia" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "secundaria total para los " &
        "calculos del transformador.")
        '
        'TextBoxSn
        '
        Me.TextBoxSn.Location = New System.Drawing.Point(149, 121)
        Me.TextBoxSn.Name = "TextBoxSn"
        Me.TextBoxSn.Size = New System.Drawing.Size(76, 20)
        Me.TextBoxSn.TabIndex = 19
        Me.TextBoxSn.Text = "1.35"
        Me.TextBoxSn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxSn, "k' para el calculo de seecion del nucleo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Varia entre 1.25 a 1.5.")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 124)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Constante para Calculo Sn:"
        Me.ToolTip1.SetToolTip(Me.Label14, "k' para el calculo de seecion del nucleo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Varia entre 1.25 a 1.5.")
        '
        'CheckBoxPotencia
        '
        Me.CheckBoxPotencia.AutoSize = True
        Me.CheckBoxPotencia.Location = New System.Drawing.Point(139, 98)
        Me.CheckBoxPotencia.Name = "CheckBoxPotencia"
        Me.CheckBoxPotencia.Size = New System.Drawing.Size(87, 17)
        Me.CheckBoxPotencia.TabIndex = 17
        Me.CheckBoxPotencia.Text = "Sobreescribir"
        Me.ToolTip1.SetToolTip(Me.CheckBoxPotencia, "Se editaran los valores de las constantes para el cálculo.")
        Me.CheckBoxPotencia.UseVisualStyleBackColor = True
        '
        'TextBoxCosenoFi
        '
        Me.TextBoxCosenoFi.Enabled = False
        Me.TextBoxCosenoFi.Location = New System.Drawing.Point(193, 23)
        Me.TextBoxCosenoFi.Name = "TextBoxCosenoFi"
        Me.TextBoxCosenoFi.Size = New System.Drawing.Size(33, 20)
        Me.TextBoxCosenoFi.TabIndex = 16
        Me.TextBoxCosenoFi.Text = "0.8"
        Me.TextBoxCosenoFi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxCosenoFi, "Coseno de Fi asumido para calcular el transformador.")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(119, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Coseno de Fi:"
        Me.ToolTip1.SetToolTip(Me.Label11, "Coseno de Fi asumido para calcular el transformador." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No es el Coseno de Fi real " &
        "que tendra el transformador." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Valor recomendado: 0.8.")
        '
        'TextBoxRendimiento
        '
        Me.TextBoxRendimiento.Enabled = False
        Me.TextBoxRendimiento.Location = New System.Drawing.Point(80, 23)
        Me.TextBoxRendimiento.Name = "TextBoxRendimiento"
        Me.TextBoxRendimiento.Size = New System.Drawing.Size(33, 20)
        Me.TextBoxRendimiento.TabIndex = 14
        Me.TextBoxRendimiento.Text = "0.9"
        Me.TextBoxRendimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxRendimiento, "Rendimiento asumido para calcular el transformador.")
        '
        'TextBoxPerdidaWKg
        '
        Me.TextBoxPerdidaWKg.Location = New System.Drawing.Point(135, 45)
        Me.TextBoxPerdidaWKg.Name = "TextBoxPerdidaWKg"
        Me.TextBoxPerdidaWKg.Size = New System.Drawing.Size(49, 20)
        Me.TextBoxPerdidaWKg.TabIndex = 21
        Me.TextBoxPerdidaWKg.Text = "1.8"
        Me.TextBoxPerdidaWKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.TextBoxPerdidaWKg, "Constante que varia segun la calidad de la chapa." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Varia entre 2 a 5.")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Perdida Nucleo [W/Kg]:"
        Me.ToolTip1.SetToolTip(Me.Label15, "Constante que varia segun la calidad de la chapa." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Varia entre 2 a 5.")
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Informacion"
        '
        'CheckBoxSoloNucleosCuadrados
        '
        Me.CheckBoxSoloNucleosCuadrados.AutoSize = True
        Me.CheckBoxSoloNucleosCuadrados.Location = New System.Drawing.Point(85, 19)
        Me.CheckBoxSoloNucleosCuadrados.Name = "CheckBoxSoloNucleosCuadrados"
        Me.CheckBoxSoloNucleosCuadrados.Size = New System.Drawing.Size(140, 17)
        Me.CheckBoxSoloNucleosCuadrados.TabIndex = 20
        Me.CheckBoxSoloNucleosCuadrados.Text = "Solo nucleos cuadrados"
        Me.ToolTip1.SetToolTip(Me.CheckBoxSoloNucleosCuadrados, "Marcar esta opcion si desea" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "que el programa solamente" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "elija nucleos de sección " &
        "cuadrada.")
        Me.CheckBoxSoloNucleosCuadrados.UseVisualStyleBackColor = True
        '
        'ComboBoxNucleos
        '
        Me.ComboBoxNucleos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxNucleos.Enabled = False
        Me.ComboBoxNucleos.FormattingEnabled = True
        Me.ComboBoxNucleos.Location = New System.Drawing.Point(6, 57)
        Me.ComboBoxNucleos.Name = "ComboBoxNucleos"
        Me.ComboBoxNucleos.Size = New System.Drawing.Size(219, 21)
        Me.ComboBoxNucleos.TabIndex = 21
        Me.ToolTip1.SetToolTip(Me.ComboBoxNucleos, resources.GetString("ComboBoxNucleos.ToolTip"))
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(190, 13)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Utilizar el siguiente nucleo[Por carrete]:"
        Me.ToolTip1.SetToolTip(Me.Label17, resources.GetString("Label17.ToolTip"))
        '
        'LabelSnRecomendada
        '
        Me.LabelSnRecomendada.AutoSize = True
        Me.LabelSnRecomendada.Location = New System.Drawing.Point(6, 83)
        Me.LabelSnRecomendada.Name = "LabelSnRecomendada"
        Me.LabelSnRecomendada.Size = New System.Drawing.Size(123, 13)
        Me.LabelSnRecomendada.TabIndex = 23
        Me.LabelSnRecomendada.Text = "Sn recomendada [cm2]: "
        Me.ToolTip1.SetToolTip(Me.LabelSnRecomendada, resources.GetString("LabelSnRecomendada.ToolTip"))
        '
        'CheckBoxNucleos
        '
        Me.CheckBoxNucleos.AutoSize = True
        Me.CheckBoxNucleos.Location = New System.Drawing.Point(138, 105)
        Me.CheckBoxNucleos.Name = "CheckBoxNucleos"
        Me.CheckBoxNucleos.Size = New System.Drawing.Size(87, 17)
        Me.CheckBoxNucleos.TabIndex = 24
        Me.CheckBoxNucleos.Text = "Sobreescribir"
        Me.ToolTip1.SetToolTip(Me.CheckBoxNucleos, "Se sobreescribira el nucleo.")
        Me.CheckBoxNucleos.UseVisualStyleBackColor = True
        '
        'ButtonCalcular
        '
        Me.ButtonCalcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCalcular.Location = New System.Drawing.Point(449, 409)
        Me.ButtonCalcular.Name = "ButtonCalcular"
        Me.ButtonCalcular.Size = New System.Drawing.Size(175, 50)
        Me.ButtonCalcular.TabIndex = 16
        Me.ButtonCalcular.Text = "Calcular"
        Me.ButtonCalcular.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(449, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.ListBox1.Size = New System.Drawing.Size(356, 394)
        Me.ListBox1.TabIndex = 18
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(630, 409)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(175, 50)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Guardar en archivo de Texto"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.CreatePrompt = True
        Me.SaveFileDialog1.FileName = "Datos trafo"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TextBoxInduccion)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.TextBoxPerdidaWKg)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 352)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(190, 73)
        Me.GroupBox5.TabIndex = 19
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Caracteristicas de las laminas"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.CheckBoxSoloNucleosCuadrados)
        Me.GroupBox8.Controls.Add(Me.CheckBoxNucleos)
        Me.GroupBox8.Controls.Add(Me.Label17)
        Me.GroupBox8.Controls.Add(Me.LabelSnRecomendada)
        Me.GroupBox8.Controls.Add(Me.ComboBoxNucleos)
        Me.GroupBox8.Location = New System.Drawing.Point(211, 326)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(232, 134)
        Me.GroupBox8.TabIndex = 25
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Otras opciones:"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'ButtonOpciones
        '
        Me.ButtonOpciones.Location = New System.Drawing.Point(15, 431)
        Me.ButtonOpciones.Name = "ButtonOpciones"
        Me.ButtonOpciones.Size = New System.Drawing.Size(105, 29)
        Me.ButtonOpciones.TabIndex = 26
        Me.ButtonOpciones.Text = "Opciones Extra"
        Me.ButtonOpciones.UseVisualStyleBackColor = True
        '
        'ButtonInformacion
        '
        Me.ButtonInformacion.Location = New System.Drawing.Point(126, 431)
        Me.ButtonInformacion.Name = "ButtonInformacion"
        Me.ButtonInformacion.Size = New System.Drawing.Size(79, 29)
        Me.ButtonInformacion.TabIndex = 27
        Me.ButtonInformacion.Text = "Informacion"
        Me.ButtonInformacion.UseVisualStyleBackColor = True
        '
        'ContextMenuV1
        '
        Me.ContextMenuV1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PuntoMedio1})
        Me.ContextMenuV1.Name = "ContextMenuV1"
        Me.ContextMenuV1.ShowCheckMargin = True
        Me.ContextMenuV1.ShowImageMargin = False
        Me.ContextMenuV1.Size = New System.Drawing.Size(153, 48)
        '
        'PuntoMedio1
        '
        Me.PuntoMedio1.CheckOnClick = True
        Me.PuntoMedio1.Name = "PuntoMedio1"
        Me.PuntoMedio1.Size = New System.Drawing.Size(152, 22)
        Me.PuntoMedio1.Text = "Punto Medio"
        '
        'ContextMenuV2
        '
        Me.ContextMenuV2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PuntoMedio2})
        Me.ContextMenuV2.Name = "ContextMenuV1"
        Me.ContextMenuV2.ShowCheckMargin = True
        Me.ContextMenuV2.ShowImageMargin = False
        Me.ContextMenuV2.Size = New System.Drawing.Size(144, 26)
        '
        'PuntoMedio2
        '
        Me.PuntoMedio2.CheckOnClick = True
        Me.PuntoMedio2.Name = "PuntoMedio2"
        Me.PuntoMedio2.Size = New System.Drawing.Size(143, 22)
        Me.PuntoMedio2.Text = "Punto Medio"
        '
        'ContextMenuV3
        '
        Me.ContextMenuV3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PuntoMedio3})
        Me.ContextMenuV3.Name = "ContextMenuV1"
        Me.ContextMenuV3.ShowCheckMargin = True
        Me.ContextMenuV3.ShowImageMargin = False
        Me.ContextMenuV3.Size = New System.Drawing.Size(144, 26)
        '
        'PuntoMedio3
        '
        Me.PuntoMedio3.CheckOnClick = True
        Me.PuntoMedio3.Name = "PuntoMedio3"
        Me.PuntoMedio3.Size = New System.Drawing.Size(143, 22)
        Me.PuntoMedio3.Text = "Punto Medio"
        '
        'TrafoMaker9000
        '
        Me.AcceptButton = Me.ButtonCalcular
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 468)
        Me.Controls.Add(Me.ButtonInformacion)
        Me.Controls.Add(Me.ButtonOpciones)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ButtonCalcular)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(830, 507)
        Me.MinimumSize = New System.Drawing.Size(830, 507)
        Me.Name = "TrafoMaker9000"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TrafoMaker9000"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ContextMenuV1.ResumeLayout(False)
        Me.ContextMenuV2.ResumeLayout(False)
        Me.ContextMenuV3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxPrincipal As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextBoxDensidad As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBoxBobinado As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents TextBoxRendimiento As TextBox
    Friend WithEvents TextBoxCosenoFi As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents CheckBoxPotencia As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ButtonCalcular As Button
    Friend WithEvents TextBoxInduccion As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBoxSn As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TextBoxPerdidaWKg As TextBox
    Friend WithEvents TextBoxPotenciaTotal As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button2 As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents CheckBoxCosenoRendimiento As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents CheckBoxSoloNucleosCuadrados As CheckBox
    Friend WithEvents ComboBoxNucleos As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents LabelSnRecomendada As Label
    Friend WithEvents CheckBoxNucleos As CheckBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextBoxPotenciaSecundario3 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ComboBoxSecundarios As ComboBox
    Friend WithEvents RadioButtonCorriente As RadioButton
    Friend WithEvents RadioButtonPotencia As RadioButton
    Friend WithEvents TextBoxPotenciaSecundario1 As TextBox
    Friend WithEvents TextBoxVoltajeSecundario1 As TextBox
    Friend WithEvents TextBoxVoltajeSecundario3 As TextBox
    Friend WithEvents TextBoxPotenciaSecundario2 As TextBox
    Friend WithEvents TextBoxVoltajeSecundario2 As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ButtonOpciones As Button
    Friend WithEvents ButtonInformacion As Button
    Friend WithEvents ContextMenuV1 As ContextMenuStrip
    Friend WithEvents PuntoMedio1 As ToolStripMenuItem
    Friend WithEvents ContextMenuV2 As ContextMenuStrip
    Friend WithEvents PuntoMedio2 As ToolStripMenuItem
    Friend WithEvents ContextMenuV3 As ContextMenuStrip
    Friend WithEvents PuntoMedio3 As ToolStripMenuItem
End Class
