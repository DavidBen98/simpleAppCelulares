Public Class Form1
    Dim cant As Integer
    Structure persona
        Public DNI As String
        Public Nombre As String
        Public Marca As String
        Public criterio As String
    End Structure

    Dim datos(100) As persona

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Or (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            MsgBox("DNI vacio")
            TextBox1.Focus()
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsLetter(e.KeyChar) Or (Asc(e.KeyChar) = 32) Or (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If TextBox2.Text = "" Then
            MsgBox("Nombre vacio")
            TextBox2.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim indice, indice2 As Integer

        cant += 1
        If Not RadioButton1.Checked And Not RadioButton2.Checked And Not RadioButton3.Checked And Not RadioButton4.Checked Then
            MsgBox("criterio vacio")
        End If

        datos(cant).DNI = TextBox1.Text
        datos(cant).Nombre = TextBox2.Text
        datos(cant).Marca = ComboBox1.Text

        If RadioButton1.Checked Then
            datos(cant).criterio = RadioButton1.Text          ' origen nacional
        End If
        If RadioButton2.Checked Then
            datos(cant).criterio = RadioButton2.Text          ' origen extranjero
        End If
        If RadioButton3.Checked Then
            datos(cant).criterio = RadioButton3.Text          ' genero accion
        End If
        If RadioButton4.Checked Then
            datos(cant).criterio = RadioButton4.Text          ' genero comedia
        End If

        indice = ComboBox2.Items.IndexOf(TextBox1.Text)
        If (indice = -1) Then
            ComboBox2.Items.Add(TextBox1.Text)
        End If

        indice2 = ComboBox1.Items.IndexOf(datos(cant).Marca)
        If datos(cant).DNI = datos(cant - 1).DNI Then
            indice2 = -1
        End If
        If indice2 = -1 Then
            MsgBox("Marca vacia")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim agregado As Integer
        For i = 1 To cant
            agregado = Listbox3.items.IndexOf(datos(i).DNI)

            If ComboBox2.SelectedItem = datos(i).DNI And agregado = -1 Then
                listBox3.items.add(datos(i).DNI)
                ListBox1.Items.Add(datos(i).Marca & " - " & datos(i).criterio)
            End If
        Next
    End Sub

    Private Sub ListBox1_Click(sender As Object, e As EventArgs) Handles ListBox1.Click
        If ListBox1.SelectedItems.Count > 0 Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox2.Items.Add(ListBox1.SelectedItem)
        ListBox1.Items.Remove(ListBox1.SelectedItem)

        If ListBox2.Items.Count > 0 Then
            Button4.Enabled = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        For i = 1 To ListBox2.Items.Count - 1
            RichTextBox1.AppendText(ListBox2.Items(i) & vbNewLine)
        Next

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            RichTextBox1.SaveFile(SaveFileDialog1.FileName)
        End If
    End Sub
End Class
