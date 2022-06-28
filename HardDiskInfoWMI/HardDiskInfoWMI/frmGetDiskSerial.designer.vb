<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetDiskSerial
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGetDiskSerial))
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.lblDrive = New System.Windows.Forms.Label()
        Me.lblSystemDrive = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBootSerialNumber = New System.Windows.Forms.TextBox()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(1, 3)
        Me.dgvData.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(574, 272)
        Me.dgvData.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(465, 350)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(107, 30)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "ปิดจอ F10"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuery.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuery.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue
        Me.btnQuery.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuery.Location = New System.Drawing.Point(465, 299)
        Me.btnQuery.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(107, 30)
        Me.btnQuery.TabIndex = 1
        Me.btnQuery.Text = "อ่านค่า F8"
        Me.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Serial Number:"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSerialNumber.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtSerialNumber.Location = New System.Drawing.Point(116, 352)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(324, 26)
        Me.txtSerialNumber.TabIndex = 4
        Me.txtSerialNumber.TabStop = False
        '
        'lblDrive
        '
        Me.lblDrive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDrive.AutoSize = True
        Me.lblDrive.ForeColor = System.Drawing.Color.DarkRed
        Me.lblDrive.Location = New System.Drawing.Point(113, 333)
        Me.lblDrive.Name = "lblDrive"
        Me.lblDrive.Size = New System.Drawing.Size(50, 18)
        Me.lblDrive.TabIndex = 6
        Me.lblDrive.Text = "DRIVE"
        '
        'lblSystemDrive
        '
        Me.lblSystemDrive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSystemDrive.AutoSize = True
        Me.lblSystemDrive.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblSystemDrive.ForeColor = System.Drawing.Color.Blue
        Me.lblSystemDrive.Location = New System.Drawing.Point(113, 280)
        Me.lblSystemDrive.Name = "lblSystemDrive"
        Me.lblSystemDrive.Size = New System.Drawing.Size(102, 18)
        Me.lblSystemDrive.TabIndex = 45
        Me.lblSystemDrive.Text = "lblSystemDrive"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 304)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 18)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Boot Disk S/N:"
        '
        'txtBootSerialNumber
        '
        Me.txtBootSerialNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBootSerialNumber.BackColor = System.Drawing.Color.Khaki
        Me.txtBootSerialNumber.Location = New System.Drawing.Point(116, 301)
        Me.txtBootSerialNumber.Name = "txtBootSerialNumber"
        Me.txtBootSerialNumber.Size = New System.Drawing.Size(324, 26)
        Me.txtBootSerialNumber.TabIndex = 3
        Me.txtBootSerialNumber.TabStop = False
        '
        'frmGetDiskSerial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 384)
        Me.Controls.Add(Me.lblSystemDrive)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBootSerialNumber)
        Me.Controls.Add(Me.lblDrive)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.dgvData)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(592, 423)
        Me.Name = "frmGetDiskSerial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Get Disk Serial Number (Physical Drive) - Code By: Thongkorn Tubtimkrob"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblDrive As System.Windows.Forms.Label
    Friend WithEvents lblSystemDrive As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBootSerialNumber As System.Windows.Forms.TextBox

End Class
