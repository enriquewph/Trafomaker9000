Public Class Trafo
    Private _frecuencia As Integer
    Private _densidadDeCorriente As Double
    Private _rendimiento As Double
    Private _cosenoFi As Double
    Private _constanteBobinado As Double
    Private _induccionBmax As Double
    Private _potenciaSecundarioTotal As Integer
    Private _Sn As Double
    Private _factorDeApilado As Double
    Private _perdida As Double
    Private _rendimientoReal As Double
    Private _constanteCalculoSn As Double
    Private _perdidaWKg As Double

    Public Property frecuencia() As Integer
        Get
            Return _frecuencia
        End Get
        Set(value As Integer)
            _frecuencia = value
        End Set
    End Property
    Public Property densidadDeCorriente() As Double
        Get
            Return _densidadDeCorriente
        End Get
        Set(value As Double)
            _densidadDeCorriente = value
        End Set
    End Property
    Public Property rendimiento() As Double
        Get
            Return _rendimiento
        End Get
        Set(value As Double)
            _rendimiento = value
        End Set
    End Property
    Public Property cosenoFi() As Double
        Get
            Return _cosenoFi
        End Get
        Set(value As Double)
            _cosenoFi = value
        End Set
    End Property
    Public Property constanteBobinado As Double
        Get
            Return _constanteBobinado
        End Get
        Set(value As Double)
            _constanteBobinado = value
        End Set
    End Property
    Public Property induccionBmax() As Double
        Get
            Return _induccionBmax
        End Get
        Set(value As Double)
            _induccionBmax = value
        End Set
    End Property
    Public Property potenciaSecundarioTotal() As Integer
        Get
            Return _potenciaSecundarioTotal
        End Get
        Set(value As Integer)
            _potenciaSecundarioTotal = value
        End Set
    End Property
    Public Property Sn() As Double
        Get
            Return _Sn
        End Get
        Set(value As Double)
            _Sn = value
        End Set
    End Property
    Public Property factorDeApilado() As Double
        Get
            Return _factorDeApilado
        End Get
        Set(value As Double)
            _factorDeApilado = value
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
    Public Property rendimientoReal() As Double
        Get
            Return _rendimientoReal
        End Get
        Set(value As Double)
            _rendimientoReal = value
        End Set
    End Property
    Public Property constanteCalculoSn() As Double
        Get
            Return _constanteCalculoSn
        End Get
        Set(value As Double)
            _constanteCalculoSn = value
        End Set
    End Property
    Public Property perdidaWKg() As Double
        Get
            Return _perdidaWKg
        End Get
        Set(value As Double)
            _perdidaWKg = value
        End Set
    End Property

    Public Sub New()
        Me.frecuencia = 0
        Me.densidadDeCorriente = 0
        Me.rendimiento = 0
        Me.cosenoFi = 0
        Me.constanteBobinado = 0
        Me.induccionBmax = 0
        Me.potenciaSecundarioTotal = 0
        Me.Sn = 0
        Me.factorDeApilado = 0
        Me.perdida = 0
        Me.rendimientoReal = 0
        Me.constanteCalculoSn = 0
        Me.perdidaWKg = 0
    End Sub
    Public Sub reset()
        Me.frecuencia = 0
        Me.densidadDeCorriente = 0
        Me.rendimiento = 0
        Me.cosenoFi = 0
        Me.constanteBobinado = 0
        Me.induccionBmax = 0
        Me.potenciaSecundarioTotal = 0
        Me.Sn = 0
        Me.factorDeApilado = 0
        Me.perdida = 0
        Me.rendimientoReal = 0
        Me.constanteCalculoSn = 0
        Me.perdidaWKg = 0
    End Sub
End Class
