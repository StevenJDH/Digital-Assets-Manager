Option Explicit On
Option Infer On

Imports Newtonsoft.Json.Linq

Public Class frmMain
    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        Try
            btnCalc.Enabled = False

            Dim jsonData As String = New System.Net.WebClient().DownloadString("https://api.kraken.com/0/public/Ticker?pair=DASHEUR,ZECEUR,ETHEUR,XMREUR,XBTEUR,LTCEUR,XRPXBT")
            Dim jsonKraken As JObject = JObject.Parse(jsonData)
            jsonData = New System.Net.WebClient().DownloadString("https://bittrex.com/api/v1.1/public/getticker?market=btc-pivx")
            Dim jsonBittrex As JObject = JObject.Parse(jsonData)

            Dim jsonKrakenErrorCheck As Array = jsonKraken.SelectToken("error").ToArray
            If jsonKrakenErrorCheck.Length > 0 Then
                MsgBox("[Kraken API] " & jsonKrakenErrorCheck(0), vbCritical, Me.Text)
                btnCalc.Enabled = True
                Exit Sub
            End If
            Dim jsonBittrexErrorCheck As Boolean = jsonBittrex.SelectToken("success")
            If jsonBittrexErrorCheck = False Then
                MsgBox("[Bittrex API] Error: " & jsonBittrex.SelectToken("message").ToString, vbCritical, Me.Text)
                btnCalc.Enabled = True
                Exit Sub
            End If

            If ds.Tables.Count > 0 Then
                Dim nTotal As Decimal = 0
                Dim jsonValue As String
                Dim nBTC As Decimal = 0 'Used for PIVX > EUR conversion
                For i As Integer = 0 To ds.Tables("MyAssets").Rows.Count - 1
                    Select Case ds.Tables("MyAssets").Rows(i).Item("Digital Asset")
                        Case "Bitcoin"
                            jsonValue = jsonKraken.SelectToken("result").SelectToken("XXBTZEUR").SelectToken("c")(0)
                            nTotal += jsonValue * ds.Tables("MyAssets").Rows(i).Item("Quantity")
                            nBTC = jsonValue
                            lblBTC.Text = "Bitcoin: " & Math.Round(Convert.ToDecimal(jsonValue), 2)
                        Case "Dash"
                            jsonValue = jsonKraken.SelectToken("result").SelectToken("DASHEUR").SelectToken("c")(0)
                            nTotal += jsonValue * ds.Tables("MyAssets").Rows(i).Item("Quantity")
                            lblDash.Text = "DASH: " & Math.Round(Convert.ToDecimal(jsonValue), 2)
                        Case "Fiat (Euro)"
                            nTotal += ds.Tables("MyAssets").Rows(i).Item("Investment") 'Adds Euro assets from exchange.
                        Case "Ethereum"
                            jsonValue = jsonKraken.SelectToken("result").SelectToken("XETHZEUR").SelectToken("c")(0)
                            nTotal += jsonValue * ds.Tables("MyAssets").Rows(i).Item("Quantity")
                            lblETH.Text = "Ethereum: " & Math.Round(Convert.ToDecimal(jsonValue), 2)
                        Case "Litecoin"
                            jsonValue = jsonKraken.SelectToken("result").SelectToken("XLTCZEUR").SelectToken("c")(0)
                            nTotal += jsonValue * ds.Tables("MyAssets").Rows(i).Item("Quantity")
                            lblLTC.Text = "Litecoin: " & Math.Round(Convert.ToDecimal(jsonValue), 2)
                        Case "Monero"
                            jsonValue = jsonKraken.SelectToken("result").SelectToken("XXMRZEUR").SelectToken("c")(0)
                            nTotal += jsonValue * ds.Tables("MyAssets").Rows(i).Item("Quantity")
                            lblXMR.Text = "Monero: " & Math.Round(Convert.ToDecimal(jsonValue), 2)
                        Case "PIVX"
                            jsonValue = jsonBittrex.SelectToken("result").SelectToken("Last").ToString
                            nTotal += (jsonValue * nBTC) * ds.Tables("MyAssets").Rows(i).Item("Quantity") 'Converts PIVX > EUR and adds to total.
                            lblPIVX.Text = "PIVX: " & Math.Round(Convert.ToDecimal(jsonValue * nBTC), 2)
                        Case "Ripple"
                            jsonValue = jsonKraken.SelectToken("result").SelectToken("XXRPXXBT").SelectToken("c")(0)
                            nTotal += (jsonValue * nBTC) * ds.Tables("MyAssets").Rows(i).Item("Quantity")
                            lblXRP.Text = "Ripple: " & Math.Round(Convert.ToDecimal(jsonValue * nBTC), 2)
                        Case "Zcash"
                            jsonValue = jsonKraken.SelectToken("result").SelectToken("XZECZEUR").SelectToken("c")(0)
                            nTotal += jsonValue * ds.Tables("MyAssets").Rows(i).Item("Quantity")
                            lblZEC.Text = "ZCash: " & Math.Round(Convert.ToDecimal(jsonValue), 2)
                    End Select
                Next i
                lblTotal.Text = "€ " & Math.Round(nTotal - nInvestment, 2)
            End If
        Catch err As Exception
            MsgBox("Error: " & err.Message, vbCritical, Me.Text)
        Finally
            btnCalc.Enabled = True
        End Try
    End Sub

    Private Sub mnuAssetsItem_Click(sender As Object, e As EventArgs) Handles mnuAssetsItem.Click
        Dim frm As New FrmAssets
        frm.ShowDialog()
        frm.Dispose()
        frm = Nothing
        AssetsToolStripStatusLabel1.Text = String.Format("Assets: {0}", ds.Tables("MyAssets").Rows.Count)
        If ds.Tables.Count > 0 Then
            Dim i As Integer
            Dim nTotal As Decimal = 0
            For i = 0 To ds.Tables("MyAssets").Rows.Count - 1
                nTotal += ds.Tables("MyAssets").Rows(i).Item("Investment")
            Next i
            nInvestment = Math.Round(nTotal, 2)
            InvestmentToolStripStatusLabel4.Text = String.Format("Investment: € {0}", nInvestment)
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            MsgBox("You can only run one instance of the program at a time.", MsgBoxStyle.Information, Me.Text)
            Me.Close()
        End If

        If System.IO.File.Exists(nXML_Path) = True Then
            ds.ReadXml(nXML_Path)
        End If

        If ds.Tables.Count < 1 Or ds.Tables("MyAssets").Rows.Count < 1 Then
            MsgBox("You have not entered any digital assets into your database yet.", MsgBoxStyle.Information, Me.Text)
            ds.Clear()
        Else
            AssetsToolStripStatusLabel1.Text = String.Format("Assets: {0}", ds.Tables("MyAssets").Rows.Count)
            If ds.Tables.Count > 0 Then
                Dim i As Integer
                Dim nTotal As Decimal = 0
                For i = 0 To ds.Tables("MyAssets").Rows.Count - 1
                    nTotal += ds.Tables("MyAssets").Rows(i).Item("Investment")
                Next i
                nInvestment = Math.Round(nTotal, 2)
                InvestmentToolStripStatusLabel4.Text = String.Format("Investment: € {0}", nInvestment)
            End If
        End If
    End Sub

    Private Sub mnuRestoreItem_Click(sender As Object, e As EventArgs) Handles mnuRestoreItem.Click
        Dim nResults As DialogResult
        Try
            If System.IO.File.Exists(nXML_Path) = True Then
                If MsgBox("This will replace your existing asset database. Are you sure you want to continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text) = DialogResult.No Then
                    Exit Sub
                End If
            End If
            OFDialog1.FileName = ""
            OFDialog1.Filter = "Digital Assets List (*.xml)|*.xml"
            nResults = OFDialog1.ShowDialog()
            If nResults = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            My.Computer.FileSystem.CopyFile(OFDialog1.FileName, nXML_Path, True)
            MsgBox("Your asset database has been restored successfully.", MsgBoxStyle.Information, Me.Text)
        Catch
            MsgBox("Error: " & Err.Description, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub mnuBackupItem_Click(sender As Object, e As EventArgs) Handles mnuBackupItem.Click
        Dim nResults As DialogResult
        Try
            If System.IO.File.Exists(nXML_Path) = False Then
                MsgBox("Nothing to backup yet until you add your first asset.", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            FBDialog1.Description = vbNewLine & "Select a folder to backup your asset database to:"
            nResults = FBDialog1.ShowDialog()
            If nResults = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            My.Computer.FileSystem.CopyFile(nXML_Path, FBDialog1.SelectedPath & "\AssetList_" & Format(Today.Date, "yyyy-MM-dd") & ".xml", FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
            MsgBox("Your asset database has been backed up successfully.", MsgBoxStyle.Information, Me.Text)
        Catch
            MsgBox("Error: " & Err.Description, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub mnuAboutItem_Click(sender As Object, e As EventArgs) Handles mnuAboutItem.Click
        MsgBox("Digital Assets Manager 1.0 (30/5/2017)" & vbNewLine & vbNewLine & "Author: Steven Jenkins De Haro" &
        vbNewLine & "A Steve Creation/Convergence" & vbNewLine & vbNewLine &
        "Microsoft .NET Framework 4.0", MsgBoxStyle.OkOnly, Me.Text)
    End Sub

    Private Sub mnuDonateItem_Click(sender As Object, e As EventArgs) Handles mnuDonateItem.Click
        On Error Resume Next
        Process.Start("https://www.paypal.me/ascc")
    End Sub

End Class
