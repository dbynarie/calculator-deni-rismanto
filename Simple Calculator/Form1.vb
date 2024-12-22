Public Class Form1
    Dim nilaiPertama As Integer = 0
    Dim operatorMatematika As String = ""
    Dim operasiDilakukan As Boolean = False

    ' Ketika tombol angka ditekan
    Private Sub btnAngka_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim tombol As Button = CType(sender, Button)

        '       If txtDisplay.Text = "0" Or operasiDilakukan Then
        '      txtDisplay.Text = ""
        '     operasiDilakukan = False
        '    End If

        If operasiDilakukan Then
            txtDisplay.Text &= tombol.Text
        Else
            If txtDisplay.Text = "0" Then
                txtDisplay.Text = tombol.Text
            Else
                txtDisplay.Text &= tombol.Text
            End If
        End If
    End Sub

    ' Ketika tombol operasi ditekan
    Private Sub btnOperator_Click(sender As Object, e As EventArgs) Handles btnPlus.Click, btnMinus.Click, btnMultiply.Click, btnDivide.Click
        Dim tombol As Button = CType(sender, Button)

        nilaiPertama = Integer.Parse(txtDisplay.Text)
        operatorMatematika = tombol.Text
        operasiDilakukan = True


        ' Tampilkan operator di txtDisplay
        txtDisplay.Text &= " " & operatorMatematika & " "
    End Sub

    ' Ketika tombol hasil (=) ditekan
    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        ' Pisahkan teks berdasarkan spasi
        Dim ekspresi As String() = txtDisplay.Text.Split(" "c)

        ' Validasi bahwa teks memiliki format [angka pertama] [operator] [angka kedua]
        If ekspresi.Length <> 3 Then
            MessageBox.Show("Input tidak valid! Pastikan Kamu memasukkan angka Pertama, operator, dan angka kedua.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim nilaiKedua As Integer
        Try
            ' Parsing nilai kedua dari teks
            nilaiKedua = Integer.Parse(ekspresi(2))
        Catch ex As Exception
            MessageBox.Show("Angka kedua tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim hasil As Integer

        ' Operasikan berdasarkan operator
        Select Case ekspresi(1)
            Case "+"
                hasil = nilaiPertama + nilaiKedua
            Case "-"
                hasil = nilaiPertama - nilaiKedua
            Case "*"
                hasil = nilaiPertama * nilaiKedua
            Case "/"
                If nilaiKedua = 0 Then
                    MessageBox.Show("Tidak bisa membagi dengan nol!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                hasil = nilaiPertama \ nilaiKedua ' Pembagian integer
            Case Else
                MessageBox.Show("Operator tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        ' Tampilkan hasil
        txtDisplay.Text = hasil.ToString()
        operatorMatematika = ""
        operasiDilakukan = False
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Reset semua variabel dan teks tampilan
        txtDisplay.Text = "0"
        nilaiPertama = 0
        operatorMatematika = ""
        operasiDilakukan = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

