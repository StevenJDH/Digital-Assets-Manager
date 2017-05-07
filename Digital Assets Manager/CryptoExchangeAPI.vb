Imports Newtonsoft.Json.Linq

Public Class CryptoExchangeAPI
    Public MustInherit Class CryptoExhanges
        Sub New()
            UpdateRates() 'Ensures rates are updated for initial use.
        End Sub

        Public MustOverride Sub UpdateRates()

        Protected MustOverride Function GetRate(asset As String) As Decimal
    End Class

    Public Class KrakenExchange : Inherits CryptoExhanges
        Dim jsonKraken As JObject

        Public Overrides Sub UpdateRates()
            Dim jsonData As String = New System.Net.WebClient().DownloadString("https://api.kraken.com/0/public/Ticker?pair=DASHEUR,ZECEUR,ETHEUR,XMREUR,XBTEUR,LTCEUR,XRPXBT,XLMEUR")
            jsonKraken = JObject.Parse(jsonData)

            Dim jsonErrorCheck As Array = jsonKraken.SelectToken("error").ToArray
            If jsonErrorCheck.Length > 0 Then
                Throw (New APIException("[Kraken API] " & jsonErrorCheck(0)))
            End If
        End Sub

        Protected Overrides Function GetRate(assetName As String) As Decimal
            Select Case assetName
                Case "Bitcoin"
                    Return jsonKraken.SelectToken("result").SelectToken("XXBTZEUR").SelectToken("c")(0)
                Case "Dash"
                    Return jsonKraken.SelectToken("result").SelectToken("DASHEUR").SelectToken("c")(0)
                Case "Ethereum"
                    Return jsonKraken.SelectToken("result").SelectToken("XETHZEUR").SelectToken("c")(0)
                Case "Litecoin"
                    Return jsonKraken.SelectToken("result").SelectToken("XLTCZEUR").SelectToken("c")(0)
                Case "Lumens"
                    Return jsonKraken.SelectToken("result").SelectToken("XXLMZEUR").SelectToken("c")(0)
                Case "Monero"
                    Return jsonKraken.SelectToken("result").SelectToken("XXMRZEUR").SelectToken("c")(0)
                Case "Ripple"
                    Return jsonKraken.SelectToken("result").SelectToken("XXRPXXBT").SelectToken("c")(0)
                Case "Zcash"
                    Return jsonKraken.SelectToken("result").SelectToken("XZECZEUR").SelectToken("c")(0)
                Case Else
                    Return 0
            End Select
        End Function

        Public Function Bitcoin() As Decimal
            Return GetRate("Bitcoin")
        End Function

        Public Function Dash() As Decimal
            Return GetRate("Dash")
        End Function
        Public Function Ethereum() As Decimal
            Return GetRate("Ethereum")
        End Function
        Public Function Litecoin() As Decimal
            Return GetRate("Litecoin")
        End Function
        Public Function Lumens() As Decimal
            Return GetRate("Lumens")
        End Function
        Public Function Monero() As Decimal
            Return GetRate("Monero")
        End Function
        Public Function Ripple() As Decimal
            Return GetRate("Ripple") * Bitcoin() 'Converts RippleBTC > EUR
        End Function
        Public Function Zcash() As Decimal
            Return GetRate("Zcash")
        End Function
    End Class

    Public Class BittrexExchange : Inherits CryptoExhanges
        Dim jsonBittrex As JObject

        Public Overrides Sub UpdateRates()
            Dim jsonData = New System.Net.WebClient().DownloadString("https://bittrex.com/api/v1.1/public/getticker?market=btc-pivx")
            jsonBittrex = JObject.Parse(jsonData)

            Dim jsonErrorCheck As Boolean = jsonBittrex.SelectToken("success")
            If jsonErrorCheck = False Then
                Throw (New APIException("[Bittrex API] Error: " & jsonBittrex.SelectToken("message").ToString))
            End If
        End Sub

        Protected Overrides Function GetRate(assetName As String) As Decimal
            Select Case assetName
                Case "PIVX"
                    Return jsonBittrex.SelectToken("result").SelectToken("Last").ToString
                Case Else
                    Return 0
            End Select
        End Function

        ''' <summary>
        ''' Provides the value of PIVX in Bitcoin because Bittrex doesn't have fiat conversion in API.
        ''' This will need to use the Kraken Bitcoin method to multiply against to get fiat value.
        ''' </summary>
        ''' <returns>Amount in BTC</returns>
        Public Function PIVX() As Decimal
            Return GetRate("PIVX")
        End Function
    End Class

    Public Class APIException : Inherits ApplicationException
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
    End Class

End Class
