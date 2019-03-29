Public Class Lamina
    Private _numero As String
    Private _AH As Double
    Private _BG As Double
    Private _C As Double
    Private _D As Double
    Private _E As Double
    Private _F As Double
    Private _gramos As Integer

    Public Property numero() As String
        Get
            Return _numero
        End Get
        Set(value As String)
            _numero = value
        End Set
    End Property
    Public Property AH() As Double
        Get
            Return _AH
        End Get
        Set(value As Double)
            _AH = value
        End Set
    End Property
    Public Property BG() As Double
        Get
            Return _BG
        End Get
        Set(value As Double)
            _BG = value
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
    Public Property E() As Double
        Get
            Return _E
        End Get
        Set(value As Double)
            _E = value
        End Set
    End Property
    Public Property F() As Double
        Get
            Return _F
        End Get
        Set(value As Double)
            _F = value
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
    Public Sub New()
        Me.numero = ""
        Me.AH = 0
        Me.BG = 0
        Me.C = 0
        Me.D = 0
        Me.E = 0
        Me.F = 0
        Me.gramos = 0
    End Sub
    Public Sub reset()
        Me.numero = ""
        Me.AH = 0
        Me.BG = 0
        Me.C = 0
        Me.D = 0
        Me.E = 0
        Me.F = 0
        Me.gramos = 0
    End Sub
End Class
