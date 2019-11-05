Imports ABPDF.PDFObjects
Imports ABPDF.Drawing

''' <summary>
''' Фабрика для создания шрифтов.
''' </summary>
Public Class Fonts

    Public Shared Function TimesNewRoman() As Font
        Dim font = New Font()
        font.Subtype = Names.Type0
        font.BaseFont = Names.TimesNewRoman
        font.Encoding = Names.Identity_H
        font.ToUnicode = CreateCMap_TimesNewRoman()
        font.SetDescendantFont(CreateCID_TimesNewRoman(font, AddressOf CreateFontDescriptor_TimesNewRoman))
        Return font
    End Function

    Public Shared Function TimesNewRoman_Bold() As Font
        Dim font = New Font()
        font.Subtype = Names.Type0
        font.BaseFont = Names.TimesNewRoman_Bold
        font.Encoding = Names.Identity_H
        font.ToUnicode = CreateCMap_TimesNewRoman_Bold()
        font.SetDescendantFont(CreateCID_TimesNewRoman(font, AddressOf CreateFontDescriptor_TimesNewRoman_Bold))
        Return font
    End Function

    Private Shared Function CreateCMap_TimesNewRoman() As CMap
        Dim cMap = New CMap()
        cMap.BFChars = {
                New GlyfChar With {.CodeChar = &H0003, .Unicode = &H0020, .Width = 250},
                New GlyfChar With {.CodeChar = &H0004, .Unicode = &H0021, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H0005, .Unicode = &H0022, .Width = 408.203125},
                New GlyfChar With {.CodeChar = &H0006, .Unicode = &H0023, .Width = 500},
                New GlyfChar With {.CodeChar = &H0007, .Unicode = &H0024, .Width = 500},
                New GlyfChar With {.CodeChar = &H0008, .Unicode = &H0025, .Width = 833.0078125},
                New GlyfChar With {.CodeChar = &H0009, .Unicode = &H0026, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H000A, .Unicode = &H0027, .Width = 180.17578125},
                New GlyfChar With {.CodeChar = &H000B, .Unicode = &H0028, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H000C, .Unicode = &H0029, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H000D, .Unicode = &H002A, .Width = 500},
                New GlyfChar With {.CodeChar = &H000E, .Unicode = &H002B, .Width = 563.96484375},
                New GlyfChar With {.CodeChar = &H000F, .Unicode = &H002C, .Width = 250},
                New GlyfChar With {.CodeChar = &H0010, .Unicode = &H002D, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H0011, .Unicode = &H002E, .Width = 250},
                New GlyfChar With {.CodeChar = &H0012, .Unicode = &H002F, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H0013, .Unicode = &H0030, .Width = 500},
                New GlyfChar With {.CodeChar = &H0014, .Unicode = &H0031, .Width = 500},
                New GlyfChar With {.CodeChar = &H0015, .Unicode = &H0032, .Width = 500},
                New GlyfChar With {.CodeChar = &H0016, .Unicode = &H0033, .Width = 500},
                New GlyfChar With {.CodeChar = &H0017, .Unicode = &H0034, .Width = 500},
                New GlyfChar With {.CodeChar = &H0018, .Unicode = &H0035, .Width = 500},
                New GlyfChar With {.CodeChar = &H0019, .Unicode = &H0036, .Width = 500},
                New GlyfChar With {.CodeChar = &H001A, .Unicode = &H0037, .Width = 500},
                New GlyfChar With {.CodeChar = &H001B, .Unicode = &H0038, .Width = 500},
                New GlyfChar With {.CodeChar = &H001C, .Unicode = &H0039, .Width = 500},
                New GlyfChar With {.CodeChar = &H001D, .Unicode = &H003A, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H001E, .Unicode = &H003B, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H001F, .Unicode = &H003C, .Width = 563.96484375},
                New GlyfChar With {.CodeChar = &H0020, .Unicode = &H003D, .Width = 563.96484375},
                New GlyfChar With {.CodeChar = &H0021, .Unicode = &H003E, .Width = 563.96484375},
                New GlyfChar With {.CodeChar = &H0022, .Unicode = &H003F, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H0023, .Unicode = &H0040, .Width = 920.8984375},
                New GlyfChar With {.CodeChar = &H0024, .Unicode = &H0041, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0025, .Unicode = &H0042, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H0026, .Unicode = &H0043, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H0027, .Unicode = &H0044, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0028, .Unicode = &H0045, .Width = 610.83984375},
                New GlyfChar With {.CodeChar = &H0029, .Unicode = &H0046, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H002A, .Unicode = &H0047, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H002B, .Unicode = &H0048, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H002C, .Unicode = &H0049, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H002D, .Unicode = &H004A, .Width = 389.16015625},
                New GlyfChar With {.CodeChar = &H002E, .Unicode = &H004B, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H002F, .Unicode = &H004C, .Width = 610.83984375},
                New GlyfChar With {.CodeChar = &H0030, .Unicode = &H004D, .Width = 889.16015625},
                New GlyfChar With {.CodeChar = &H0031, .Unicode = &H004E, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0032, .Unicode = &H004F, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0033, .Unicode = &H0050, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H0034, .Unicode = &H0051, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0035, .Unicode = &H0052, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H0036, .Unicode = &H0053, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H0037, .Unicode = &H0054, .Width = 610.83984375},
                New GlyfChar With {.CodeChar = &H0038, .Unicode = &H0055, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0039, .Unicode = &H0056, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H003A, .Unicode = &H0057, .Width = 943.84765625},
                New GlyfChar With {.CodeChar = &H003B, .Unicode = &H0058, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H003C, .Unicode = &H0059, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H003D, .Unicode = &H005A, .Width = 610.83984375},
                New GlyfChar With {.CodeChar = &H003E, .Unicode = &H005B, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H003F, .Unicode = &H005C, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H0040, .Unicode = &H005D, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H0041, .Unicode = &H005E, .Width = 469.23828125},
                New GlyfChar With {.CodeChar = &H0042, .Unicode = &H005F, .Width = 500},
                New GlyfChar With {.CodeChar = &H0043, .Unicode = &H0060, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H0044, .Unicode = &H0061, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H0045, .Unicode = &H0062, .Width = 500},
                New GlyfChar With {.CodeChar = &H0046, .Unicode = &H0063, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H0047, .Unicode = &H0064, .Width = 500},
                New GlyfChar With {.CodeChar = &H0048, .Unicode = &H0065, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H0049, .Unicode = &H0066, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H004A, .Unicode = &H0067, .Width = 500},
                New GlyfChar With {.CodeChar = &H004B, .Unicode = &H0068, .Width = 500},
                New GlyfChar With {.CodeChar = &H004C, .Unicode = &H0069, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H004D, .Unicode = &H006A, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H004E, .Unicode = &H006B, .Width = 500},
                New GlyfChar With {.CodeChar = &H004F, .Unicode = &H006C, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H0050, .Unicode = &H006D, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H0051, .Unicode = &H006E, .Width = 500},
                New GlyfChar With {.CodeChar = &H0052, .Unicode = &H006F, .Width = 500},
                New GlyfChar With {.CodeChar = &H0053, .Unicode = &H0070, .Width = 500},
                New GlyfChar With {.CodeChar = &H0054, .Unicode = &H0071, .Width = 500},
                New GlyfChar With {.CodeChar = &H0055, .Unicode = &H0072, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H0056, .Unicode = &H0073, .Width = 389.16015625},
                New GlyfChar With {.CodeChar = &H0057, .Unicode = &H0074, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H0058, .Unicode = &H0075, .Width = 500},
                New GlyfChar With {.CodeChar = &H0059, .Unicode = &H0076, .Width = 500},
                New GlyfChar With {.CodeChar = &H005A, .Unicode = &H0077, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H005B, .Unicode = &H0078, .Width = 500},
                New GlyfChar With {.CodeChar = &H005C, .Unicode = &H0079, .Width = 500},
                New GlyfChar With {.CodeChar = &H005D, .Unicode = &H007A, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H005E, .Unicode = &H007B, .Width = 479.98046875},
                New GlyfChar With {.CodeChar = &H005F, .Unicode = &H007C, .Width = 200.1953125},
                New GlyfChar With {.CodeChar = &H0060, .Unicode = &H007D, .Width = 479.98046875},
                New GlyfChar With {.CodeChar = &H0061, .Unicode = &H007E, .Width = 541.015625},
                New GlyfChar With {.CodeChar = &H023A, .Unicode = &H0410, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H023B, .Unicode = &H0411, .Width = 574.21875},
                New GlyfChar With {.CodeChar = &H023C, .Unicode = &H0412, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H023D, .Unicode = &H0413, .Width = 578.125},
                New GlyfChar With {.CodeChar = &H023E, .Unicode = &H0414, .Width = 682.12890625},
                New GlyfChar With {.CodeChar = &H023F, .Unicode = &H0415, .Width = 610.83984375},
                New GlyfChar With {.CodeChar = &H0240, .Unicode = &H0416, .Width = 895.99609375},
                New GlyfChar With {.CodeChar = &H0241, .Unicode = &H0417, .Width = 500.9765625},
                New GlyfChar With {.CodeChar = &H0242, .Unicode = &H0418, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0243, .Unicode = &H0419, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0244, .Unicode = &H041A, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H0245, .Unicode = &H041B, .Width = 678.22265625},
                New GlyfChar With {.CodeChar = &H0246, .Unicode = &H041C, .Width = 889.16015625},
                New GlyfChar With {.CodeChar = &H0247, .Unicode = &H041D, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0248, .Unicode = &H041E, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0249, .Unicode = &H041F, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H024A, .Unicode = &H0420, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H024B, .Unicode = &H0421, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H024C, .Unicode = &H0422, .Width = 610.83984375},
                New GlyfChar With {.CodeChar = &H024D, .Unicode = &H0423, .Width = 708.0078125},
                New GlyfChar With {.CodeChar = &H024E, .Unicode = &H0424, .Width = 790.0390625},
                New GlyfChar With {.CodeChar = &H024F, .Unicode = &H0425, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0250, .Unicode = &H0426, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0251, .Unicode = &H0427, .Width = 649.90234375},
                New GlyfChar With {.CodeChar = &H0252, .Unicode = &H0428, .Width = 1008.7890625},
                New GlyfChar With {.CodeChar = &H0253, .Unicode = &H0429, .Width = 1008.7890625},
                New GlyfChar With {.CodeChar = &H0254, .Unicode = &H042A, .Width = 706.0546875},
                New GlyfChar With {.CodeChar = &H0255, .Unicode = &H042B, .Width = 872.0703125},
                New GlyfChar With {.CodeChar = &H0256, .Unicode = &H042C, .Width = 574.21875},
                New GlyfChar With {.CodeChar = &H0257, .Unicode = &H042D, .Width = 660.15625},
                New GlyfChar With {.CodeChar = &H0258, .Unicode = &H042E, .Width = 1027.83203125},
                New GlyfChar With {.CodeChar = &H0259, .Unicode = &H042F, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H025A, .Unicode = &H0430, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H025B, .Unicode = &H0431, .Width = 508.7890625},
                New GlyfChar With {.CodeChar = &H025C, .Unicode = &H0432, .Width = 472.16796875},
                New GlyfChar With {.CodeChar = &H025D, .Unicode = &H0433, .Width = 410.15625},
                New GlyfChar With {.CodeChar = &H025E, .Unicode = &H0434, .Width = 508.7890625},
                New GlyfChar With {.CodeChar = &H025F, .Unicode = &H0435, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H0260, .Unicode = &H0436, .Width = 690.91796875},
                New GlyfChar With {.CodeChar = &H0261, .Unicode = &H0437, .Width = 395.01953125},
                New GlyfChar With {.CodeChar = &H0262, .Unicode = &H0438, .Width = 535.15625},
                New GlyfChar With {.CodeChar = &H0263, .Unicode = &H0439, .Width = 535.15625},
                New GlyfChar With {.CodeChar = &H0264, .Unicode = &H043A, .Width = 485.83984375},
                New GlyfChar With {.CodeChar = &H0265, .Unicode = &H043B, .Width = 499.0234375},
                New GlyfChar With {.CodeChar = &H0266, .Unicode = &H043C, .Width = 632.8125},
                New GlyfChar With {.CodeChar = &H0267, .Unicode = &H043D, .Width = 535.15625},
                New GlyfChar With {.CodeChar = &H0268, .Unicode = &H043E, .Width = 500},
                New GlyfChar With {.CodeChar = &H0269, .Unicode = &H043F, .Width = 535.15625},
                New GlyfChar With {.CodeChar = &H026A, .Unicode = &H0440, .Width = 500},
                New GlyfChar With {.CodeChar = &H026B, .Unicode = &H0441, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H026C, .Unicode = &H0442, .Width = 437.01171875},
                New GlyfChar With {.CodeChar = &H026D, .Unicode = &H0443, .Width = 500},
                New GlyfChar With {.CodeChar = &H026E, .Unicode = &H0444, .Width = 647.94921875},
                New GlyfChar With {.CodeChar = &H026F, .Unicode = &H0445, .Width = 500},
                New GlyfChar With {.CodeChar = &H0270, .Unicode = &H0446, .Width = 535.15625},
                New GlyfChar With {.CodeChar = &H0271, .Unicode = &H0447, .Width = 502.9296875},
                New GlyfChar With {.CodeChar = &H0272, .Unicode = &H0448, .Width = 770.01953125},
                New GlyfChar With {.CodeChar = &H0273, .Unicode = &H0449, .Width = 770.01953125},
                New GlyfChar With {.CodeChar = &H0274, .Unicode = &H044A, .Width = 517.08984375},
                New GlyfChar With {.CodeChar = &H0275, .Unicode = &H044B, .Width = 671.875},
                New GlyfChar With {.CodeChar = &H0276, .Unicode = &H044C, .Width = 456.0546875},
                New GlyfChar With {.CodeChar = &H0277, .Unicode = &H044D, .Width = 429.19921875},
                New GlyfChar With {.CodeChar = &H0278, .Unicode = &H044E, .Width = 747.0703125},
                New GlyfChar With {.CodeChar = &H0279, .Unicode = &H044F, .Width = 459.9609375},
                New GlyfChar With {.CodeChar = &H027A, .Unicode = &H0451, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H022C, .Unicode = &H0401, .Width = 610.83984375},
                New GlyfChar With {.CodeChar = &H028B, .Unicode = &H2116, .Width = 954}
            }
        cMap.Flush()
        Return cMap
    End Function

    Private Shared Function CreateCMap_TimesNewRoman_Bold() As CMap
        Dim cMap = New CMap()
        cMap.BFChars = {
                New GlyfChar With {.CodeChar = &H0003, .Unicode = &H0020, .Width = 250},
                New GlyfChar With {.CodeChar = &H0004, .Unicode = &H0021, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H0005, .Unicode = &H0022, .Width = 555.17578125},
                New GlyfChar With {.CodeChar = &H0006, .Unicode = &H0023, .Width = 500},
                New GlyfChar With {.CodeChar = &H0007, .Unicode = &H0024, .Width = 500},
                New GlyfChar With {.CodeChar = &H0008, .Unicode = &H0025, .Width = 1000},
                New GlyfChar With {.CodeChar = &H0009, .Unicode = &H0026, .Width = 833.0078125},
                New GlyfChar With {.CodeChar = &H000A, .Unicode = &H0027, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H000B, .Unicode = &H0028, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H000C, .Unicode = &H0029, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H000D, .Unicode = &H002A, .Width = 500},
                New GlyfChar With {.CodeChar = &H000E, .Unicode = &H002B, .Width = 569.82421875},
                New GlyfChar With {.CodeChar = &H000F, .Unicode = &H002C, .Width = 250},
                New GlyfChar With {.CodeChar = &H0010, .Unicode = &H002D, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H0011, .Unicode = &H002E, .Width = 250},
                New GlyfChar With {.CodeChar = &H0012, .Unicode = &H002F, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H0013, .Unicode = &H0030, .Width = 500},
                New GlyfChar With {.CodeChar = &H0014, .Unicode = &H0031, .Width = 500},
                New GlyfChar With {.CodeChar = &H0015, .Unicode = &H0032, .Width = 500},
                New GlyfChar With {.CodeChar = &H0016, .Unicode = &H0033, .Width = 500},
                New GlyfChar With {.CodeChar = &H0017, .Unicode = &H0034, .Width = 500},
                New GlyfChar With {.CodeChar = &H0018, .Unicode = &H0035, .Width = 500},
                New GlyfChar With {.CodeChar = &H0019, .Unicode = &H0036, .Width = 500},
                New GlyfChar With {.CodeChar = &H001A, .Unicode = &H0037, .Width = 500},
                New GlyfChar With {.CodeChar = &H001B, .Unicode = &H0038, .Width = 500},
                New GlyfChar With {.CodeChar = &H001C, .Unicode = &H0039, .Width = 500},
                New GlyfChar With {.CodeChar = &H001D, .Unicode = &H003A, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H001E, .Unicode = &H003B, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H001F, .Unicode = &H003C, .Width = 569.82421875},
                New GlyfChar With {.CodeChar = &H0020, .Unicode = &H003D, .Width = 569.82421875},
                New GlyfChar With {.CodeChar = &H0021, .Unicode = &H003E, .Width = 569.82421875},
                New GlyfChar With {.CodeChar = &H0022, .Unicode = &H003F, .Width = 500},
                New GlyfChar With {.CodeChar = &H0023, .Unicode = &H0040, .Width = 930.17578125},
                New GlyfChar With {.CodeChar = &H0024, .Unicode = &H0041, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0025, .Unicode = &H0042, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H0026, .Unicode = &H0043, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0027, .Unicode = &H0044, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0028, .Unicode = &H0045, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H0029, .Unicode = &H0046, .Width = 610.83984375},
                New GlyfChar With {.CodeChar = &H002A, .Unicode = &H0047, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H002B, .Unicode = &H0048, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H002C, .Unicode = &H0049, .Width = 389.16015625},
                New GlyfChar With {.CodeChar = &H002D, .Unicode = &H004A, .Width = 500},
                New GlyfChar With {.CodeChar = &H002E, .Unicode = &H004B, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H002F, .Unicode = &H004C, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H0030, .Unicode = &H004D, .Width = 943.84765625},
                New GlyfChar With {.CodeChar = &H0031, .Unicode = &H004E, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0032, .Unicode = &H004F, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H0033, .Unicode = &H0050, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H0034, .Unicode = &H0051, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H0035, .Unicode = &H0052, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0036, .Unicode = &H0053, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H0037, .Unicode = &H0054, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H0038, .Unicode = &H0055, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0039, .Unicode = &H0056, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H003A, .Unicode = &H0057, .Width = 1000},
                New GlyfChar With {.CodeChar = &H003B, .Unicode = &H0058, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H003C, .Unicode = &H0059, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H003D, .Unicode = &H005A, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H003E, .Unicode = &H005B, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H003F, .Unicode = &H005C, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H0040, .Unicode = &H005D, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H0041, .Unicode = &H005E, .Width = 581.0546875},
                New GlyfChar With {.CodeChar = &H0042, .Unicode = &H005F, .Width = 500},
                New GlyfChar With {.CodeChar = &H0043, .Unicode = &H0060, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H0044, .Unicode = &H0061, .Width = 500},
                New GlyfChar With {.CodeChar = &H0045, .Unicode = &H0062, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H0046, .Unicode = &H0063, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H0047, .Unicode = &H0064, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H0048, .Unicode = &H0065, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H0049, .Unicode = &H0066, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H004A, .Unicode = &H0067, .Width = 500},
                New GlyfChar With {.CodeChar = &H004B, .Unicode = &H0068, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H004C, .Unicode = &H0069, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H004D, .Unicode = &H006A, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H004E, .Unicode = &H006B, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H004F, .Unicode = &H006C, .Width = 277.83203125},
                New GlyfChar With {.CodeChar = &H0050, .Unicode = &H006D, .Width = 833.0078125},
                New GlyfChar With {.CodeChar = &H0051, .Unicode = &H006E, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H0052, .Unicode = &H006F, .Width = 500},
                New GlyfChar With {.CodeChar = &H0053, .Unicode = &H0070, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H0054, .Unicode = &H0071, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H0055, .Unicode = &H0072, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H0056, .Unicode = &H0073, .Width = 389.16015625},
                New GlyfChar With {.CodeChar = &H0057, .Unicode = &H0074, .Width = 333.0078125},
                New GlyfChar With {.CodeChar = &H0058, .Unicode = &H0075, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H0059, .Unicode = &H0076, .Width = 500},
                New GlyfChar With {.CodeChar = &H005A, .Unicode = &H0077, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H005B, .Unicode = &H0078, .Width = 500},
                New GlyfChar With {.CodeChar = &H005C, .Unicode = &H0079, .Width = 500},
                New GlyfChar With {.CodeChar = &H005D, .Unicode = &H007A, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H005E, .Unicode = &H007B, .Width = 394.04296875},
                New GlyfChar With {.CodeChar = &H005F, .Unicode = &H007C, .Width = 220.21484375},
                New GlyfChar With {.CodeChar = &H0060, .Unicode = &H007D, .Width = 394.04296875},
                New GlyfChar With {.CodeChar = &H0061, .Unicode = &H007E, .Width = 520.01953125},
                New GlyfChar With {.CodeChar = &H023A, .Unicode = &H0410, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H023B, .Unicode = &H0411, .Width = 661.1328125},
                New GlyfChar With {.CodeChar = &H023C, .Unicode = &H0412, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H023D, .Unicode = &H0413, .Width = 636.23046875},
                New GlyfChar With {.CodeChar = &H023E, .Unicode = &H0414, .Width = 687.98828125},
                New GlyfChar With {.CodeChar = &H023F, .Unicode = &H0415, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H0240, .Unicode = &H0416, .Width = 988.76953125},
                New GlyfChar With {.CodeChar = &H0241, .Unicode = &H0417, .Width = 527.83203125},
                New GlyfChar With {.CodeChar = &H0242, .Unicode = &H0418, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H0243, .Unicode = &H0419, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H0244, .Unicode = &H041A, .Width = 725.09765625},
                New GlyfChar With {.CodeChar = &H0245, .Unicode = &H041B, .Width = 745.1171875},
                New GlyfChar With {.CodeChar = &H0246, .Unicode = &H041C, .Width = 943.84765625},
                New GlyfChar With {.CodeChar = &H0247, .Unicode = &H041D, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H0248, .Unicode = &H041E, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H0249, .Unicode = &H041F, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H024A, .Unicode = &H0420, .Width = 610.83984375},
                New GlyfChar With {.CodeChar = &H024B, .Unicode = &H0421, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H024C, .Unicode = &H0422, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H024D, .Unicode = &H0423, .Width = 733.88671875},
                New GlyfChar With {.CodeChar = &H024E, .Unicode = &H0424, .Width = 858.88671875},
                New GlyfChar With {.CodeChar = &H024F, .Unicode = &H0425, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H0250, .Unicode = &H0426, .Width = 777.83203125},
                New GlyfChar With {.CodeChar = &H0251, .Unicode = &H0427, .Width = 733.88671875},
                New GlyfChar With {.CodeChar = &H0252, .Unicode = &H0428, .Width = 1098.14453125},
                New GlyfChar With {.CodeChar = &H0253, .Unicode = &H0429, .Width = 1098.14453125},
                New GlyfChar With {.CodeChar = &H0254, .Unicode = &H042A, .Width = 765.13671875},
                New GlyfChar With {.CodeChar = &H0255, .Unicode = &H042B, .Width = 981.93359375},
                New GlyfChar With {.CodeChar = &H0256, .Unicode = &H042C, .Width = 661.1328125},
                New GlyfChar With {.CodeChar = &H0257, .Unicode = &H042D, .Width = 678.22265625},
                New GlyfChar With {.CodeChar = &H0258, .Unicode = &H042E, .Width = 1125.9765625},
                New GlyfChar With {.CodeChar = &H0259, .Unicode = &H042F, .Width = 722.16796875},
                New GlyfChar With {.CodeChar = &H025A, .Unicode = &H0430, .Width = 500},
                New GlyfChar With {.CodeChar = &H025B, .Unicode = &H0431, .Width = 500},
                New GlyfChar With {.CodeChar = &H025C, .Unicode = &H0432, .Width = 540.0390625},
                New GlyfChar With {.CodeChar = &H025D, .Unicode = &H0433, .Width = 454.1015625},
                New GlyfChar With {.CodeChar = &H025E, .Unicode = &H0434, .Width = 505.859375},
                New GlyfChar With {.CodeChar = &H025F, .Unicode = &H0435, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H0260, .Unicode = &H0436, .Width = 725.09765625},
                New GlyfChar With {.CodeChar = &H0261, .Unicode = &H0437, .Width = 401.85546875},
                New GlyfChar With {.CodeChar = &H0262, .Unicode = &H0438, .Width = 576.171875},
                New GlyfChar With {.CodeChar = &H0263, .Unicode = &H0439, .Width = 576.171875},
                New GlyfChar With {.CodeChar = &H0264, .Unicode = &H043A, .Width = 576.171875},
                New GlyfChar With {.CodeChar = &H0265, .Unicode = &H043B, .Width = 561.03515625},
                New GlyfChar With {.CodeChar = &H0266, .Unicode = &H043C, .Width = 681.15234375},
                New GlyfChar With {.CodeChar = &H0267, .Unicode = &H043D, .Width = 576.171875},
                New GlyfChar With {.CodeChar = &H0268, .Unicode = &H043E, .Width = 500},
                New GlyfChar With {.CodeChar = &H0269, .Unicode = &H043F, .Width = 576.171875},
                New GlyfChar With {.CodeChar = &H026A, .Unicode = &H0440, .Width = 556.15234375},
                New GlyfChar With {.CodeChar = &H026B, .Unicode = &H0441, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H026C, .Unicode = &H0442, .Width = 491.2109375},
                New GlyfChar With {.CodeChar = &H026D, .Unicode = &H0443, .Width = 500},
                New GlyfChar With {.CodeChar = &H026E, .Unicode = &H0444, .Width = 691.89453125},
                New GlyfChar With {.CodeChar = &H026F, .Unicode = &H0445, .Width = 500},
                New GlyfChar With {.CodeChar = &H0270, .Unicode = &H0446, .Width = 576.171875},
                New GlyfChar With {.CodeChar = &H0271, .Unicode = &H0447, .Width = 563.96484375},
                New GlyfChar With {.CodeChar = &H0272, .Unicode = &H0448, .Width = 844.23828125},
                New GlyfChar With {.CodeChar = &H0273, .Unicode = &H0449, .Width = 844.23828125},
                New GlyfChar With {.CodeChar = &H0274, .Unicode = &H044A, .Width = 583.0078125},
                New GlyfChar With {.CodeChar = &H0275, .Unicode = &H044B, .Width = 780.76171875},
                New GlyfChar With {.CodeChar = &H0276, .Unicode = &H044C, .Width = 528.80859375},
                New GlyfChar With {.CodeChar = &H0277, .Unicode = &H044D, .Width = 432.12890625},
                New GlyfChar With {.CodeChar = &H0278, .Unicode = &H044E, .Width = 764.16015625},
                New GlyfChar With {.CodeChar = &H0279, .Unicode = &H044F, .Width = 541.015625},
                New GlyfChar With {.CodeChar = &H027A, .Unicode = &H0451, .Width = 443.84765625},
                New GlyfChar With {.CodeChar = &H022C, .Unicode = &H0401, .Width = 666.9921875},
                New GlyfChar With {.CodeChar = &H028B, .Unicode = &H2116, .Width = 1004.8828125}
            }
        cMap.Flush()
        Return cMap
    End Function

    Private Shared Function CreateCID_TimesNewRoman(font As Font, funcDescriptor As Func(Of FontDescriptor)) As CIDFont
        Dim cidFont = New CIDFont()
        cidFont.Subtype = Names.CIDFontType2
        cidFont.CIDToGIDMap = Names.Identity
        cidFont.DefaultWidth = 1000
        cidFont.WidthGlyfs = New ArrayInderect() With {.ContentObject = font.ToUnicode.CreateGlifWidths()}
        cidFont.CIDSystemInfo = CreateCIDSystemInfo_AdobeIdentity()
        cidFont.FontDescriptor = funcDescriptor()
        Return cidFont
    End Function

    Private Shared Function CreateCIDSystemInfo_AdobeIdentity() As CIDSystemInfo
        Return New CIDSystemInfo() With {
            .Ordering = New StringObject("Identity"),
            .Registry = New StringObject("Adobe"),
            .Supplement = New NumericObject(0)
        }
    End Function

    Private Shared Function CreateFontDescriptor_TimesNewRoman() As FontDescriptor
        Dim fontDescriptor = New FontDescriptor()
        fontDescriptor.FontName = New NameObject("TimesNewRoman")
        fontDescriptor.Flags = New NumericObject(32)
        fontDescriptor.ItalicAngle = New NumericObject(0)
        fontDescriptor.Ascent = New NumericObject(891)
        fontDescriptor.Descent = New NumericObject(-216)
        fontDescriptor.CapHeight = 723
        fontDescriptor.AvgWidth = New NumericObject(401)
        fontDescriptor.MaxWidth = New NumericObject(2568)
        fontDescriptor.FontWeight = New NumericObject(400)
        fontDescriptor.XHeight = New NumericObject(250)
        fontDescriptor.Leading = New NumericObject(42)
        fontDescriptor.StemV = New NumericObject(40)
        fontDescriptor.FontBBox = New RectanglesObject() With {.LowLeftX = -568, .LowLeftY = -216, .UpRightX = 2000, .UpRightY = 723}
        fontDescriptor.FontFile2 = New FontStream("_Fonts/TimesNewRoman.ttf")
        Return fontDescriptor
    End Function

    Private Shared Function CreateFontDescriptor_TimesNewRoman_Bold() As FontDescriptor
        Dim fontDescriptor = New FontDescriptor()
        fontDescriptor.FontName = New NameObject("TimesNewRoman,Bold")
        fontDescriptor.Flags = New NumericObject(32)
        fontDescriptor.ItalicAngle = New NumericObject(0)
        fontDescriptor.Ascent = New NumericObject(891)
        fontDescriptor.Descent = New NumericObject(-216)
        fontDescriptor.CapHeight = 723
        fontDescriptor.AvgWidth = New NumericObject(401)
        fontDescriptor.MaxWidth = New NumericObject(2568)
        fontDescriptor.FontWeight = New NumericObject(700)
        fontDescriptor.XHeight = New NumericObject(250)
        fontDescriptor.Leading = New NumericObject(42)
        fontDescriptor.StemV = New NumericObject(40)
        fontDescriptor.FontBBox = New RectanglesObject() With {.LowLeftX = -568, .LowLeftY = -216, .UpRightX = 2000, .UpRightY = 723}
        fontDescriptor.FontFile2 = New FontStream("_Fonts/TimesNewRoman-Bold.ttf")
        Return fontDescriptor
    End Function

End Class

