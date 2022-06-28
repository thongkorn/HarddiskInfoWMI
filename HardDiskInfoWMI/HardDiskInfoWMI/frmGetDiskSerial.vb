#Region "ABOUT"
' / --------------------------------------------------------------------
' / Developer : Mr.Surapon Yodsanga (Thongkorn Tubtimkrob)
' / eMail : thongkorn@hotmail.com
' / URL: http://www.g2gnet.com (Khon Kaen - Thailand)
' / Facebook: https://www.facebook.com/g2gnet (For Thailand)
' / Facebook: https://www.facebook.com/commonindy (Worldwide)
' / More Info: http://www.g2gsoft.com/
' /
' / Purpose: Read the physical hard disk serial number with WMI (Windows Management Instrumental).
' / Microsoft Visual Basic .NET (2010)
' /
' / This is open source code under @Copyleft by Thongkorn Tubtimkrob.
' / You can modify and/or distribute without to inform the developer.
' / --------------------------------------------------------------------
#End Region

'// IMPORTANT ... อย่าลืม Add References --> System.Management เพื่อใช้งาน
'// Windows Management Instrumentation (WMI)
Imports System.Management
Imports System.Globalization

Public Class frmGetDiskSerial

    '/ START HERE
    Private Sub frmGetDiskSerial_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call InitializeGrid(dgvData)
        lblDrive.Text = String.Empty
        lblSystemDrive.Text = String.Empty
        txtSerialNumber.Text = String.Empty
        txtBootSerialNumber.Text = String.Empty
    End Sub

    ' / --------------------------------------------------------------------------------
    '// Default settings for Grids @Run Time
    Private Sub InitializeGrid(ByRef dgv As DataGridView)
        With dgv
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .Font = New Font("Tahoma", 10)
            .RowHeadersVisible = True
            .RowTemplate.MinimumHeight = 29
            .RowTemplate.Height = 29
            .AlternatingRowsDefaultCellStyle.BackColor = Color.SkyBlue
            .DefaultCellStyle.SelectionBackColor = Color.Green
            '/ Auto size column width of each main by sorting the field.
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            '/ Adjust Header Styles
            With .ColumnHeadersDefaultCellStyle
                .BackColor = Color.Orange
                .ForeColor = Color.White
                .Font = New Font("Tahoma", 10, FontStyle.Bold)
            End With
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 36
            '// กำหนดให้ EnableHeadersVisualStyles = False เพื่อให้ยอมรับการเปลี่ยนแปลงสีพื้นหลังของ Header
            .EnableHeadersVisualStyles = False
        End With
    End Sub

    Private Sub btnQuery_Click(sender As System.Object, e As System.EventArgs) Handles btnQuery.Click
        txtSerialNumber.Text = String.Empty
        '/ ค้นหาฮาร์ดดิสต์ทั้งหมดในเครื่อง และหาค่า Serial Number ของ Physical Drive.
        Call PhysicalMediaWMI()
        '/ หาดิสต์ลูกที่บู๊ตระบบปฏิบัติการ Windows และหาค่า Serial Number ของ Physical Drive.
        Call GetBootDiskSerialNumber()
    End Sub

    ' / --------------------------------------------------------------------------------
    ' / Read the serial number (Physical Drive) of all hard drives on the computer.
    Private Sub PhysicalMediaWMI()
        Dim DT As New DataTable()
        Dim WmiClass As String = "Win32_PhysicalMedia "
        Dim Searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM " & WmiClass)
        '/ Add Column
        For Each QueryObj As ManagementObject In Searcher.Get()
            For Each item As PropertyData In QueryObj.Properties()
                Try
                    Select Case item.Name
                        Case "Tag", "SerialNumber"
                            DT.Columns.Add(item.Name)
                    End Select
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                End Try
            Next
            Exit For
        Next
        '/ Add Row
        For Each QueryObj As ManagementObject In Searcher.Get()
            Dim DR As DataRow = DT.NewRow
            For Each item As PropertyData In QueryObj.Properties()
                Try
                    Select Case item.Name
                        Case "Tag"
                            DR(item.Name) = Trim(item.Value).Replace("\", "").Replace(".", "")
                            DT.Rows.Add(DR)
                        Case "SerialNumber"
                            DR(item.Name) = Trim(item.Value)
                            DT.Rows.Add(DR)
                    End Select
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                End Try
            Next
        Next
        dgvData.DataSource = DT
    End Sub

    ' / --------------------------------------------------------------------------------
    ' / Check the hard drive at system boot system and get serial number (Physical Drive).
    ' / สรุปวิธีคิด (สั้นๆ) ... มันจะมีการเรียกใช้งานอยู่หลาย Class
    ' / เริ่มจากการหาดิสต์ลูกที่บู๊ตระบบปฏิบัติการ Windows ก่อน (Win32_OperatingSystem)
    ' / จะได้ System Drive ออกมา ซึ่งปกติก็คือไดรฟ์ C นั่นเอง
    ' / หาว่าไดรฟ์ C มันมี Logical Disk Drive หมายเลขอะไร (DeviceID)
    ' / นำค่า DeviceID ไปเปรียบเทียบกับ Class Win32_DiskDrive ว่ามันอยู่ที่ฮาร์ดดิสต์ลูกไหน
    ' / เมื่อเจอแล้วก็อ่านค่า Serial Number แบบ Physical Disk Drive ออกมา ... จบ
    ' / --------------------------------------------------------------------------------
    Sub GetBootDiskSerialNumber()
        '/ Read boot system drive before.
        Dim SysOS As ManagementObject = New ManagementObject("Win32_OperatingSystem=@")
        '/ System Drive is C:
        Dim SystemDrive As String = SysOS("SystemDrive")
        lblSystemDrive.Text = "System Drive is " & SystemDrive
        '/ Get the LogicalDiskToPartition.
        Dim strQuery As String = "ASSOCIATORS OF {Win32_LogicalDisk.DeviceID="""
        strQuery = strQuery + SystemDrive + """} WHERE AssocClass = Win32_LogicalDiskToPartition"
        '/ strQuery = ASSOCIATORS OF {Win32_LogicalDisk.DeviceID="C:"} WHERE AssocClass = Win32_LogicalDiskToPartition

        Dim Relquery As New RelatedObjectQuery(strQuery)
        Dim Search As New ManagementObjectSearcher(Relquery)
        Dim idx As UInt32 = 0
        Dim DeviceID As String = String.Empty
        '/ Find DeviceID from DiskPartition and return value is DiskIndex.
        '/ DiskPartition = \\THONGKORN-PC\root\cimv2:Win32_DiskPartition.DeviceID = "Disk #3, Partition #2"
        For Each DiskPartition In Search.Get()
            '/ DiskPartition (Index) = 3 or PHYSICALDRIVE3
            idx = DiskPartition("DiskIndex")
            DeviceID = DiskPartition("DeviceID").ToString
        Next
        '/ Read Serial Number (Physical Drive) from Disk Index = 3. (PHYSICALDRIVE3)
        Dim SerialQuery As SelectQuery = New SelectQuery(String.Format("SELECT * FROM Win32_DiskDrive WHERE Index={0}", idx))
        Dim SerialSearch As ManagementObjectSearcher = New ManagementObjectSearcher(SerialQuery)
        For Each sn In SerialSearch.Get()
            txtBootSerialNumber.Text = sn("SerialNumber").ToString.Trim
        Next
        lblSystemDrive.Text = lblSystemDrive.Text & " [Device ID : " & DeviceID & "]"
    End Sub

    Private Sub frmGetDiskSerial_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F8
                '/ Add Row
                Call btnQuery_Click(sender, e)
            Case Keys.F10
                '/ Remove Row
                Call btnClose_Click(sender, e)
        End Select
    End Sub

    ' / --------------------------------------------------------------------------------
    ' / แสดงผล Serial Number ในแถวที่เลือกจากตารางกริด
    Private Sub dgvData_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellClick
        txtSerialNumber.Text = dgvData.Rows(e.RowIndex).Cells(0).Value.ToString
        lblDrive.Text = Mid(dgvData.Rows(e.RowIndex).Cells(1).Value.ToString, 9, Len(dgvData.Rows(e.RowIndex).Cells(1).Value.ToString) - 8)
    End Sub

    ' / --------------------------------------------------------------------------------
    ' / Display line numbers in the DataGridView.
    Private Sub dgvData_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvData.RowPostPaint
        Using b As SolidBrush = New SolidBrush(dgvData.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub txtSerialNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerialNumber.KeyPress
        '// Lock Key Press.
        e.Handled = True
    End Sub

    Private Sub txtBootSerialNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        '// Lock Key Press.
        e.Handled = True
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmGetDiskSerial_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        GC.SuppressFinalize(Me)
        Application.Exit()
    End Sub

End Class
