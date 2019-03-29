Public Class Bobinado
    Private _voltaje As Integer
    Private _corriente As Double
    Private _potencia As Double
    Private _calibre As String
    Private _diametro As Double
    Private _seccion As Double
    Private _gramosMetro As Double
    Private _ohmMetro As Double
    Private _vueltas As Integer
    Private _alambresPorCapa As Integer
    Private _capas As Integer
    Private _longitud As Double
    Private _largoMedio As Double
    Private _resistencia As Double
    Private _perdida As Double
    Private _gramos As Integer
    Private _precio As Double

    Public Property voltaje() As Integer
        Get
            Return _voltaje
        End Get
        Set(value As Integer)
            _voltaje = value
        End Set
    End Property
    Public Property corriente() As Double
        Get
            Return _corriente
        End Get
        Set(value As Double)
            _corriente = value
        End Set
    End Property
    Public Property potencia() As Double
        Get
            Return _potencia
        End Get
        Set(value As Double)
            _potencia = value
        End Set
    End Property
    Public Property calibre() As String
        Get
            Return _calibre
        End Get
        Set(value As String)
            _calibre = value
        End Set
    End Property
    Public Property diametro() As Double
        Get
            Return _diametro
        End Get
        Set(value As Double)
            _diametro = value
        End Set
    End Property
    Public Property seccion() As Double
        Get
            Return _seccion
        End Get
        Set(value As Double)
            _seccion = value
        End Set
    End Property
    Public Property gramosMetro() As Double
        Get
            Return _gramosMetro
        End Get
        Set(value As Double)
            _gramosMetro = value
        End Set
    End Property
    Public Property ohmMetro() As Double
        Get
            Return _ohmMetro
        End Get
        Set(value As Double)
            _ohmMetro = value
        End Set
    End Property
    Public Property vueltas() As Integer
        Get
            Return _vueltas
        End Get
        Set(value As Integer)
            _vueltas = value
        End Set
    End Property
    Public Property alambresPorCapa() As Integer
        Get
            Return _alambresPorCapa
        End Get
        Set(value As Integer)
            _alambresPorCapa = value
        End Set
    End Property
    Public Property capas() As Integer
        Get
            Return _capas
        End Get
        Set(value As Integer)
            _capas = value
        End Set
    End Property
    Public Property longitud() As Double
        Get
            Return _longitud
        End Get
        Set(value As Double)
            _longitud = value
        End Set
    End Property
    Public Property largoMedio() As Double
        Get
            Return _largoMedio
        End Get
        Set(value As Double)
            _largoMedio = value
        End Set
    End Property
    Public Property resistencia() As Double
        Get
            Return _resistencia
        End Get
        Set(value As Double)
            _resistencia = value
        End Set
    End Property
    Public Property perdida() As Double
        Get
            Return _perdida
        End Get
        Set(value As Double)
            _perdida = value
        End Set
    End Property
    Public Property gramos() As Integer
        Get
            Return _gramos
        End Get
        Set(value As Integer)
            _gramos = value
        End Set
    End Property
    Public Property Precio() As Double
        Get
            Return _precio
        End Get
        Set(value As Double)
            _precio = value
        End Set
    End Property
    Public Sub New()
        Me.voltaje = 0
        Me.corriente = 0
        Me.potencia = 0
        Me.calibre = ""
        Me.diametro = 0
        Me.seccion = 0
        Me.gramosMetro = 0
        Me.ohmMetro = 0
        Me.vueltas = 0
        Me.alambresPorCapa = 0
        Me.capas = 0
        Me.longitud = 0
        Me.largoMedio = 0
        Me.resistencia = 0
        Me.perdida = 0
        Me.gramos = 0
        Me.Precio = 0
    End Sub
    Public Sub reset()
        Me.voltaje = 0
        Me.corriente = 0
        Me.potencia = 0
        Me.calibre = ""
        Me.diametro = 0
        Me.seccion = 0
        Me.gramosMetro = 0
        Me.ohmMetro = 0
        Me.vueltas = 0
        Me.alambresPorCapa = 0
        Me.capas = 0
        Me.longitud = 0
        Me.largoMedio = 0
        Me.resistencia = 0
        Me.perdida = 0
        Me.gramos = 0
        Me.Precio = 0
    End Sub
End Class
