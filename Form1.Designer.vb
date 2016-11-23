<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LB_in_Arbeit = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.P_App = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.P_Fileserver = New System.Windows.Forms.Panel()
        Me.P_SQL_Server = New System.Windows.Forms.Panel()
        Me.P_SAP_Queue = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.DateTimePickerWartung = New System.Windows.Forms.DateTimePicker()
        Me.LB_Steuerung = New System.Windows.Forms.Label()
        Me.LabeWartungDauer = New System.Windows.Forms.Label()
        Me.LabelWartung = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BTN_Stop = New System.Windows.Forms.Button()
        Me.BTN_Start = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LB_Protokoll = New System.Windows.Forms.ListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LB_Verarbeitung = New System.Windows.Forms.Label()
        Me.Anz_Downloads = New System.Windows.Forms.Label()
        Me.LB_Startdatum = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.LB_Trigger = New System.Windows.Forms.ListBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LB_Downloads = New System.Windows.Forms.ListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.LB_in_Arbeit)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.P_App)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.P_Fileserver)
        Me.Panel1.Controls.Add(Me.P_SQL_Server)
        Me.Panel1.Controls.Add(Me.P_SAP_Queue)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(23, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(420, 211)
        Me.Panel1.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(21, 133)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(56, 13)
        Me.ProgressBar1.TabIndex = 11
        '
        'LB_in_Arbeit
        '
        Me.LB_in_Arbeit.AutoSize = True
        Me.LB_in_Arbeit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_in_Arbeit.ForeColor = System.Drawing.Color.Navy
        Me.LB_in_Arbeit.Location = New System.Drawing.Point(241, 133)
        Me.LB_in_Arbeit.Name = "LB_in_Arbeit"
        Me.LB_in_Arbeit.Size = New System.Drawing.Size(54, 13)
        Me.LB_in_Arbeit.TabIndex = 10
        Me.LB_in_Arbeit.Text = "in Arbeit"
        Me.LB_in_Arbeit.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(97, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Wartezeit bis zur n. Prüfung"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(97, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Transfer und Trigger Anwendung"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(97, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(195, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fileserver \DS_Haerterei\SAP_Transfer"
        '
        'P_App
        '
        Me.P_App.BackColor = System.Drawing.Color.Red
        Me.P_App.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_App.Location = New System.Drawing.Point(21, 56)
        Me.P_App.Name = "P_App"
        Me.P_App.Size = New System.Drawing.Size(56, 13)
        Me.P_App.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(97, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Oracle PLS-Server (wba_kom)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(97, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "SAP-PrinterQueue W1279"
        '
        'P_Fileserver
        '
        Me.P_Fileserver.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.P_Fileserver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_Fileserver.Location = New System.Drawing.Point(21, 95)
        Me.P_Fileserver.Name = "P_Fileserver"
        Me.P_Fileserver.Size = New System.Drawing.Size(56, 13)
        Me.P_Fileserver.TabIndex = 4
        '
        'P_SQL_Server
        '
        Me.P_SQL_Server.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.P_SQL_Server.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_SQL_Server.Location = New System.Drawing.Point(21, 114)
        Me.P_SQL_Server.Name = "P_SQL_Server"
        Me.P_SQL_Server.Size = New System.Drawing.Size(56, 13)
        Me.P_SQL_Server.TabIndex = 6
        '
        'P_SAP_Queue
        '
        Me.P_SAP_Queue.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.P_SAP_Queue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_SAP_Queue.Location = New System.Drawing.Point(21, 75)
        Me.P_SAP_Queue.Name = "P_SAP_Queue"
        Me.P_SAP_Queue.Size = New System.Drawing.Size(56, 13)
        Me.P_SAP_Queue.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(18, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Statusinformationen"
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.NumericUpDown1)
        Me.Panel6.Controls.Add(Me.DateTimePickerWartung)
        Me.Panel6.Controls.Add(Me.LB_Steuerung)
        Me.Panel6.Controls.Add(Me.LabeWartungDauer)
        Me.Panel6.Controls.Add(Me.LabelWartung)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Controls.Add(Me.BTN_Stop)
        Me.Panel6.Controls.Add(Me.BTN_Start)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Location = New System.Drawing.Point(748, 33)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(237, 210)
        Me.Panel6.TabIndex = 1
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(17, 147)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(62, 20)
        Me.NumericUpDown1.TabIndex = 15
        Me.NumericUpDown1.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'DateTimePickerWartung
        '
        Me.DateTimePickerWartung.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerWartung.Location = New System.Drawing.Point(17, 108)
        Me.DateTimePickerWartung.Name = "DateTimePickerWartung"
        Me.DateTimePickerWartung.ShowCheckBox = True
        Me.DateTimePickerWartung.Size = New System.Drawing.Size(147, 20)
        Me.DateTimePickerWartung.TabIndex = 12
        '
        'LB_Steuerung
        '
        Me.LB_Steuerung.AutoSize = True
        Me.LB_Steuerung.ForeColor = System.Drawing.Color.Black
        Me.LB_Steuerung.Location = New System.Drawing.Point(16, 187)
        Me.LB_Steuerung.Name = "LB_Steuerung"
        Me.LB_Steuerung.Size = New System.Drawing.Size(74, 13)
        Me.LB_Steuerung.TabIndex = 13
        Me.LB_Steuerung.Text = "nicht gestartet"
        '
        'LabeWartungDauer
        '
        Me.LabeWartungDauer.AutoSize = True
        Me.LabeWartungDauer.ForeColor = System.Drawing.Color.Black
        Me.LabeWartungDauer.Location = New System.Drawing.Point(16, 131)
        Me.LabeWartungDauer.Name = "LabeWartungDauer"
        Me.LabeWartungDauer.Size = New System.Drawing.Size(67, 13)
        Me.LabeWartungDauer.TabIndex = 12
        Me.LabeWartungDauer.Text = "Dauer in Min"
        '
        'LabelWartung
        '
        Me.LabelWartung.AutoSize = True
        Me.LabelWartung.ForeColor = System.Drawing.Color.Black
        Me.LabelWartung.Location = New System.Drawing.Point(16, 89)
        Me.LabelWartung.Name = "LabelWartung"
        Me.LabelWartung.Size = New System.Drawing.Size(65, 13)
        Me.LabelWartung.TabIndex = 12
        Me.LabelWartung.Text = "Wartung am"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(16, 170)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Status"
        '
        'BTN_Stop
        '
        Me.BTN_Stop.BackColor = System.Drawing.Color.Red
        Me.BTN_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Stop.Location = New System.Drawing.Point(124, 44)
        Me.BTN_Stop.Name = "BTN_Stop"
        Me.BTN_Stop.Size = New System.Drawing.Size(90, 37)
        Me.BTN_Stop.TabIndex = 14
        Me.BTN_Stop.Text = "Stopp"
        Me.BTN_Stop.UseVisualStyleBackColor = False
        '
        'BTN_Start
        '
        Me.BTN_Start.BackColor = System.Drawing.Color.Chartreuse
        Me.BTN_Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Start.Location = New System.Drawing.Point(19, 44)
        Me.BTN_Start.Name = "BTN_Start"
        Me.BTN_Start.Size = New System.Drawing.Size(90, 37)
        Me.BTN_Start.TabIndex = 13
        Me.BTN_Start.Text = "Start"
        Me.BTN_Start.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(16, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Steuerung"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.LB_Protokoll)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Location = New System.Drawing.Point(23, 250)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(707, 470)
        Me.Panel3.TabIndex = 3
        '
        'LB_Protokoll
        '
        Me.LB_Protokoll.BackColor = System.Drawing.SystemColors.Control
        Me.LB_Protokoll.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LB_Protokoll.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Protokoll.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LB_Protokoll.FormattingEnabled = True
        Me.LB_Protokoll.HorizontalScrollbar = True
        Me.LB_Protokoll.ItemHeight = 14
        Me.LB_Protokoll.Location = New System.Drawing.Point(22, 41)
        Me.LB_Protokoll.Name = "LB_Protokoll"
        Me.LB_Protokoll.Size = New System.Drawing.Size(663, 406)
        Me.LB_Protokoll.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(19, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Protokoll"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.LB_Verarbeitung)
        Me.Panel4.Controls.Add(Me.Anz_Downloads)
        Me.Panel4.Controls.Add(Me.LB_Startdatum)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Location = New System.Drawing.Point(454, 34)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(275, 209)
        Me.Panel4.TabIndex = 4
        '
        'LB_Verarbeitung
        '
        Me.LB_Verarbeitung.AutoSize = True
        Me.LB_Verarbeitung.Location = New System.Drawing.Point(118, 74)
        Me.LB_Verarbeitung.Name = "LB_Verarbeitung"
        Me.LB_Verarbeitung.Size = New System.Drawing.Size(13, 13)
        Me.LB_Verarbeitung.TabIndex = 22
        Me.LB_Verarbeitung.Text = "0"
        '
        'Anz_Downloads
        '
        Me.Anz_Downloads.AutoSize = True
        Me.Anz_Downloads.Location = New System.Drawing.Point(118, 55)
        Me.Anz_Downloads.Name = "Anz_Downloads"
        Me.Anz_Downloads.Size = New System.Drawing.Size(13, 13)
        Me.Anz_Downloads.TabIndex = 21
        Me.Anz_Downloads.Text = "0"
        '
        'LB_Startdatum
        '
        Me.LB_Startdatum.AutoSize = True
        Me.LB_Startdatum.Location = New System.Drawing.Point(118, 94)
        Me.LB_Startdatum.Name = "LB_Startdatum"
        Me.LB_Startdatum.Size = New System.Drawing.Size(74, 13)
        Me.LB_Startdatum.TabIndex = 18
        Me.LB_Startdatum.Text = "nicht gestartet"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(16, 94)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "läuft seit"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(16, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Verarbeitungen"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(16, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Downloads"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Navy
        Me.Label12.Location = New System.Drawing.Point(16, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Statistik"
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.LB_Trigger)
        Me.Panel7.Controls.Add(Me.Label17)
        Me.Panel7.Location = New System.Drawing.Point(748, 493)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(237, 226)
        Me.Panel7.TabIndex = 18
        '
        'LB_Trigger
        '
        Me.LB_Trigger.BackColor = System.Drawing.SystemColors.Control
        Me.LB_Trigger.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LB_Trigger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LB_Trigger.FormattingEnabled = True
        Me.LB_Trigger.Location = New System.Drawing.Point(16, 42)
        Me.LB_Trigger.Name = "LB_Trigger"
        Me.LB_Trigger.Size = New System.Drawing.Size(198, 169)
        Me.LB_Trigger.TabIndex = 16
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(14, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "offene Trigger"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(14, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "überfällige Downloads"
        '
        'LB_Downloads
        '
        Me.LB_Downloads.BackColor = System.Drawing.SystemColors.Control
        Me.LB_Downloads.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LB_Downloads.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LB_Downloads.FormattingEnabled = True
        Me.LB_Downloads.Location = New System.Drawing.Point(16, 42)
        Me.LB_Downloads.Name = "LB_Downloads"
        Me.LB_Downloads.Size = New System.Drawing.Size(197, 156)
        Me.LB_Downloads.TabIndex = 16
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LB_Downloads)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(748, 249)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(237, 223)
        Me.Panel2.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 708)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "SAP - Masterplanung Automation"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents P_SQL_Server As System.Windows.Forms.Panel
    Friend WithEvents P_SAP_Queue As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents P_Fileserver As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents P_App As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents LB_Steuerung As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BTN_Stop As System.Windows.Forms.Button
    Friend WithEvents BTN_Start As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LB_in_Arbeit As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LB_Protokoll As System.Windows.Forms.ListBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LB_Startdatum As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Anz_Downloads As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents LB_Trigger As System.Windows.Forms.ListBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LB_Downloads As System.Windows.Forms.ListBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LB_Verarbeitung As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerWartung As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelWartung As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabeWartungDauer As System.Windows.Forms.Label

End Class
