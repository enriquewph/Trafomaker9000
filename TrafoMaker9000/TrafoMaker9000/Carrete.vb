Public Class Carrete
    Private _numero As String
    Private _A As Double
    Private _B As Double
    Private _C As Double
    Private _D As Double
    Private _H As Double
    Private _Cuadrado As Boolean
    Private _precio As Double

    Public Property numero() As String
        Get
            Return _numero
        End Get
        Set(value As String)
            _numero = value
        End Set
    End Property
    Public Property A() As Double
        Get
            Return _A
        End Get
        Set(value As Double)
            _A = value
        End Set
    End Property
    Public Property B() As Double
        Get
            Return _B
        End Get
        Set(value As Double)
            _B = value
        End Set
    End Property
    Public Property C() As Double
        Get
            Return _C
        End Get
        Set(value As Double)
            _C = value
        End Set
    End Property
    Public Property D() As Double
        Get
            Return _D
        End Get
        Set(value As Double)
            _D = value
        End Set
    End Property
    Public Property H() As Double
        Get
            Return _H
        End Get
        Set(value As Double)
            _H = value
        End Set
    End Property
    Public Property Cuadrado() As Boolean
        Get
            Return _Cuadrado
        End Get
        Set(value As Boolean)
            _Cuadrado = value
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
        Me.numero = ""
        Me.A = 0
        Me.B = 0
        Me.C = 0
        Me.D = 0
        Me.H = 0
        Me.Cuadrado = False
        Me.Precio = 0
    End Sub
    Public Sub reset()
        Me.numero = ""
        Me.A = 0
        Me.B = 0
        Me.C = 0
        Me.D = 0
        Me.H = 0
        Me.Cuadrado = False
        Me.Precio = 0
    End Sub
End Class
