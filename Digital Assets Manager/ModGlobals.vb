Option Explicit On
Option Infer On

Module ModGlobals

    Public ds As New DataSet
    Public nInvestment As Decimal
    Public nXML_Path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ASC-C\Digital Assets Manager\AssetList.xml"

End Module
