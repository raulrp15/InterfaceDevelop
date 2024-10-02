<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnSaludar = New Button()
        Label1 = New Label()
        txtNombre = New TextBox()
        mError = New Label()
        SuspendLayout()
        ' 
        ' btnSaludar
        ' 
        btnSaludar.Font = New Font("Segoe UI", 15F)
        btnSaludar.Location = New Point(112, 124)
        btnSaludar.Name = "btnSaludar"
        btnSaludar.Size = New Size(136, 43)
        btnSaludar.TabIndex = 0
        btnSaludar.Text = "Saludar"
        btnSaludar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F)
        Label1.Location = New Point(112, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(85, 28)
        Label1.TabIndex = 1
        Label1.Text = "Nombre"
        ' 
        ' txtNombre
        ' 
        txtNombre.Font = New Font("Segoe UI", 15F)
        txtNombre.Location = New Point(203, 73)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(241, 34)
        txtNombre.TabIndex = 2
        ' 
        ' mError
        ' 
        mError.AutoSize = True
        mError.Font = New Font("Segoe UI", 15F)
        mError.ForeColor = Color.Red
        mError.Location = New Point(390, 131)
        mError.Name = "mError"
        mError.Size = New Size(0, 28)
        mError.TabIndex = 3
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(mError)
        Controls.Add(txtNombre)
        Controls.Add(Label1)
        Controls.Add(btnSaludar)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSaludar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents mError As Label

End Class
