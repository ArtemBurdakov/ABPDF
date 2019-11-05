Imports System.IO

''' <summary>
''' Предостовляет механизм записи PDF объектов.
''' </summary>
Public Interface IWritable

    ''' <summary>
    ''' Возвращает количество байтов объекта/структуры.
    ''' </summary>
    ReadOnly Property Length() As Integer

    ''' <summary>
    ''' Записывает объект в MemoryStream.
    ''' </summary>
    Sub WriteIn(stream As MemoryStream)

End Interface

