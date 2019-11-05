Imports System.IO

Namespace FileStructures

    ''' <summary>
    ''' Представляет структуру PDF (заголовок, тело, ссылочная таблица, трейлер).
    ''' </summary>
    Public MustInherit Class FileStructure
        Implements IWritable

        Private _pdf As PDF

        ''' <summary>
        ''' Документ с которым связана структура.
        ''' </summary>
        Public Property PDF As PDF
            Get
                Return _pdf
            End Get
            Friend Set(value As PDF)
                _pdf = value
            End Set
        End Property

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend MustOverride ReadOnly Property Length() As Integer Implements IWritable.Length

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend MustOverride Sub WriteIn(stream As MemoryStream) Implements IWritable.WriteIn

    End Class

End Namespace

