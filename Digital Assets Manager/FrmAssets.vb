Public Class FrmAssets

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'As you make changes to records in a dataset by updating, inserting, and deleting 
        'records, the dataset maintains original and current versions of the records. In 
        'addition, each row's RowState property keeps track of whether the records are in 
        'their original state or have been updated, inserted, or deleted.
        If System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ASC-C") = False Then
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ASC-C")
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ASC-C\Digital Assets Manager")
        ElseIf System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ASC-C\Digital Assets Manager") = False Then
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ASC-C\Digital Assets Manager")
        End If
        ds.AcceptChanges()
        ds.WriteXml(nXML_Path)
        btnSave.Enabled = False
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbAssets.SelectedIndex < 0 Then
                MsgBox("Please select an asset from the dropdown list.", MsgBoxStyle.Exclamation, frmMain.Text)
                Exit Sub
            ElseIf AssetSearch(cmbAssets.SelectedItem, "Digital Asset") = True Then
                MsgBox("The asset already exists in the database.", MsgBoxStyle.Exclamation, frmMain.Text)
                Exit Sub
            End If

            Dim n As Integer = DataGridView1.Rows.Add
            DataGridView1.Rows.Item(n).Cells(0).Value = cmbAssets.SelectedItem
            If cmbAssets.SelectedItem.ToString.Contains("Fiat (") = True Then
                DataGridView1.Rows.Item(n).Cells(1).Value = "1.00000000" 'Add a 1 for Fiat currency so it is not multiplied.
            Else
                'The following {0:Nx} flags forces the counter to save all the decimal places.
                DataGridView1.Rows.Item(n).Cells(1).Value = String.Format("{0:N8}", numQuantity.Value)
            End If
            DataGridView1.Rows.Item(n).Cells(2).Value = String.Format("{0:N5}", numInvestment.Value)

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables("MyAssets").NewRow()
            dsNewRow.Item("Digital Asset") = DataGridView1.Rows.Item(n).Cells(0).Value
            dsNewRow.Item("Quantity") = DataGridView1.Rows.Item(n).Cells(1).Value
            dsNewRow.Item("Investment") = DataGridView1.Rows.Item(n).Cells(2).Value
            ds.Tables("MyAssets").Rows.Add(dsNewRow)

            Me.Text = String.Format("Asset Manager - {0} Asset(s)", ds.Tables("MyAssets").Rows.Count)
            btnSave.Enabled = True
            numQuantity.Value = "0.00000001"
            numInvestment.Value = "0.00001"
            cmbAssets.SelectedIndex = -1
            cmbAssets.Focus()
            MsgBox("The new asset has been added to the database.", MsgBoxStyle.Information, frmMain.Text)
        Catch
            MsgBox(Err.Description & " Asset Manager will now close.", MsgBoxStyle.Critical, frmMain.Text)
            Me.Close()
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If btnSave.Enabled = True AndAlso (MsgBox("Save changes before closing?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, frmMain.Text)) = DialogResult.Yes Then
            btnSave_Click(Me, EventArgs.Empty)
        Else
            'This reloads the ds so that the count is correctly displayed on the status strip of the main screen.
            'Also, it ensures that no unsaved entries are still in the ds.
            ds.Clear()
            ds.ReadXml(nXML_Path)
        End If
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                If MsgBox("Are you sure you want to delete this asset?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, frmMain.Text) = DialogResult.No Then
                    Exit Sub
                End If
                ds.Tables("MyAssets").Rows(DataGridView1.CurrentCellAddress.Y).Delete()
                DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
                Me.Text = String.Format("Asset Manager - {0} Asset(s)", ds.Tables("MyAssets").Rows.Count)
                btnSave.Enabled = True
            End If
        Catch
            MsgBox(Err.Description & " Asset Manager will now close.", MsgBoxStyle.Critical, frmMain.Text)
            Me.Close()
        End Try
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            If btnSave.Enabled = True Then
                If (MsgBox("Save changes before refreshing?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, frmMain.Text)) = DialogResult.Yes Then
                    btnSave_Click(Me, EventArgs.Empty)
                End If
            End If
            DataGridView1.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnDeleteAll.Text = "Delete All"
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnUpdate.Enabled = False
            cmbAssets.SelectedIndex = -1
            numQuantity.Value = "0.00000001"
            numInvestment.Value = "0.00001"
            DataGridView1.Rows.Clear()
            ds.Clear()
            If System.IO.File.Exists(nXML_Path) = True Then
                ds.ReadXml(nXML_Path)
            End If
            If ds.Tables.Count < 1 Then
                ds.Tables.Add("MyAssets")
                ds.Tables("MyAssets").Columns.Add("Digital Asset")
                ds.Tables("MyAssets").Columns.Add("Quantity")
                ds.Tables("MyAssets").Columns.Add("Investment")
                Me.Text = "Asset Manager - 0 Asset(s)"
            Else
                Me.Text = String.Format("Asset Manager - {0} Asset(s)", ds.Tables("MyAssets").Rows.Count)
                'DataGridView1.DataSource = ds.Tables("MyAssets")
                Dim i As Integer
                For i = 0 To ds.Tables("MyAssets").Rows.Count - 1
                    Dim n As Integer = DataGridView1.Rows.Add
                    DataGridView1.Rows.Item(n).Cells(0).Value = ds.Tables("MyAssets").Rows(n).Item("Digital Asset")
                    DataGridView1.Rows.Item(n).Cells(1).Value = ds.Tables("MyAssets").Rows(n).Item("Quantity")
                    DataGridView1.Rows.Item(n).Cells(2).Value = ds.Tables("MyAssets").Rows(n).Item("Investment")
                Next i
            End If
        Catch
            MsgBox(Err.Description & " Asset Manager will now close.", MsgBoxStyle.Critical, frmMain.Text)
            Me.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If cmbAssets.SelectedIndex < 0 Then
                MsgBox("Please select an asset from the dropdown list.", MsgBoxStyle.Exclamation, frmMain.Text)
                Exit Sub
            End If
            If Not cmbAssets.SelectedItem = DataGridView1.Rows.Item(DataGridView1.CurrentCellAddress.Y).Cells(0).Value Then
                If AssetSearch(cmbAssets.SelectedItem, "Digital Asset") = True Then
                    MsgBox("The asset already exists in the database.", MsgBoxStyle.Exclamation, frmMain.Text)
                    Exit Sub
                End If
            End If

            'The following {0:Nx} flags forces the counter to save all the decimal places.
            DataGridView1.Rows.Item(DataGridView1.CurrentCellAddress.Y).Cells(0).Value = cmbAssets.SelectedItem
            DataGridView1.Rows.Item(DataGridView1.CurrentCellAddress.Y).Cells(1).Value = String.Format("{0:N8}", numQuantity.Value)
            DataGridView1.Rows.Item(DataGridView1.CurrentCellAddress.Y).Cells(2).Value = String.Format("{0:N5}", numInvestment.Value)

            ds.Tables("MyAssets").Rows(DataGridView1.CurrentCellAddress.Y).Item("Digital Asset") = DataGridView1.Rows.Item(DataGridView1.CurrentCellAddress.Y).Cells(0).Value
            ds.Tables("MyAssets").Rows(DataGridView1.CurrentCellAddress.Y).Item("Quantity") = DataGridView1.Rows.Item(DataGridView1.CurrentCellAddress.Y).Cells(1).Value
            ds.Tables("MyAssets").Rows(DataGridView1.CurrentCellAddress.Y).Item("Investment") = DataGridView1.Rows.Item(DataGridView1.CurrentCellAddress.Y).Cells(2).Value

            numQuantity.Value = "0.00000001"
            numInvestment.Value = "0.00001"
            cmbAssets.SelectedIndex = -1
            cmbAssets.Focus()
            DataGridView1.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnDeleteAll.Text = "Delete All"
            btnAdd.Enabled = True
            btnUpdate.Enabled = False
            btnSave.Enabled = True
        Catch
            MsgBox(Err.Description & " Asset Manager will now close.", MsgBoxStyle.Critical, frmMain.Text)
            Me.Close()
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If DataGridView1.Rows.Count > 0 Then
            cmbAssets.SelectedItem = DataGridView1.Rows.Item(DataGridView1.CurrentCellAddress.Y).Cells(0).Value
            numQuantity.Value = DataGridView1.Rows.Item(DataGridView1.CurrentCellAddress.Y).Cells(1).Value
            numInvestment.Value = DataGridView1.Rows.Item(DataGridView1.CurrentCellAddress.Y).Cells(2).Value
            btnDeleteAll.Text = "Cancel"
            DataGridView1.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnAdd.Enabled = False
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Function AssetSearch(ByVal nAsset As String, ByVal nSection As String) As Boolean
        Dim i As Integer
        For i = 0 To ds.Tables("MyAssets").Rows.Count - 1
            If nAsset.Trim.ToUpper = ds.Tables("MyAssets").Rows(i).Item(nSection).ToString.ToUpper Then
                Return True
            End If
        Next i
        Return False
    End Function

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Select Case btnDeleteAll.Text
            Case "Delete All"
                If MsgBox("Are you sure you want to delete all assets?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, frmMain.Text) = DialogResult.No Then
                    Exit Sub
                End If
                DataGridView1.Rows.Clear()
                ds.Clear()
                Me.Text = "Asset Manager - 0 Asset(s)"
                btnSave.Enabled = True
            Case "Cancel" 'This is for when edit is activated
                btnDeleteAll.Text = "Delete All"
                cmbAssets.SelectedIndex = -1
                numQuantity.Value = "0.00000001"
                numInvestment.Value = "0.00001"
                DataGridView1.Enabled = True
                btnEdit.Enabled = True
                btnDelete.Enabled = True
                btnAdd.Enabled = True
                btnUpdate.Enabled = False
        End Select
    End Sub

    Private Sub cmbAssets_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbAssets.KeyDown
        If e.KeyCode = Keys.Enter And btnAdd.Enabled = True Then
            btnAdd_Click(Me, EventArgs.Empty)
        ElseIf e.KeyCode = Keys.Enter And btnUpdate.Enabled = True Then
            btnUpdate_Click(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub numQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles numQuantity.KeyDown
        If e.KeyCode = Keys.Enter And btnAdd.Enabled = True Then
            btnAdd_Click(Me, EventArgs.Empty)
        ElseIf e.KeyCode = Keys.Enter And btnUpdate.Enabled = True Then
            btnUpdate_Click(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub numInvestment_KeyDown(sender As Object, e As KeyEventArgs) Handles numInvestment.KeyDown
        If e.KeyCode = Keys.Enter And btnAdd.Enabled = True Then
            btnAdd_Click(Me, EventArgs.Empty)
        ElseIf e.KeyCode = Keys.Enter And btnUpdate.Enabled = True Then
            btnUpdate_Click(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub FrmAssets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Do not sort the data grid view because the dataset won't sort and will be out of sync.
        Try
            btnRefresh_Click(Me, EventArgs.Empty)
        Catch
            MsgBox(Err.Description & " Asset Manager will now close.", MsgBoxStyle.Critical, frmMain.Text)
            Me.Close()
        End Try
    End Sub

    Private Sub cmbAssets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAssets.SelectedIndexChanged
        'Check index first and if it is null, then the text is not checked or it will throw a null exception.
        If cmbAssets.SelectedIndex > -1 AndAlso cmbAssets.SelectedItem.ToString.Contains("Fiat (") = True Then
            lblQuantity.Visible = False
            numQuantity.Visible = False
        Else
            lblQuantity.Visible = True
            numQuantity.Visible = True
        End If
    End Sub

End Class

