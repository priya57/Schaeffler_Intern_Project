Imports System.Threading
Imports System.Collections.ObjectModel
Imports System.Management.Automation
Imports System.Management.Automation.Runspaces
Imports System.Text
Imports System.IO

Public Class Form1

    Public Steuerungsflag As Boolean
    Public Prot As New Protokoll

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LB_Startdatum.Text = Now
        DateTimePickerWartung.CustomFormat = "dd'.'MM'.'yyyy' 'HH:mm"
        DateTimePickerWartung.Checked = False

    End Sub

    Private Sub BTN_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Start.Click


        BTN_Start.Visible = False

        Steuerungsflag = True
        Bearbeitung_Start()
        Me.LB_Steuerung.Text = "gestartet um " & Now

        Dim COP As New Kopiervorgang
        Dim AKT As New Datei_Aktualität
        Dim TR As New Trigger

        'Endlosschleife 


        While Steuerungsflag
            If Wartungsmodus() Then
                Me.BackColor = Color.Orange
                schlafen()
            Else
                Me.BackColor = Control.DefaultBackColor
                If Prüfung_Resourcen() = True _
                Then

                    'Alle Ressourcen stehen zur Verfügung
                    Me.P_App.BackColor = Color.Chartreuse

                    'Kopieren von FTP-Server nach Fileserver
                    COP.Kopieren()

                    'Lesen der überfälligen Downloads
                    AKT.Aktualität_Dateien()
                    AKT.Aktualität_Trigger()

                    'Trigger bearbeiten
                    TR.Trigger_lesen()

                Else
                    Me.P_App.BackColor = Color.Red
                End If

                Bearbeitung_Ende()
                Me.Refresh()
                '***********************************************IMPORTANT CALLLING POWERSHELL SCRIPT AND ORACLE DATABASE CONVERSION FUNCTION**************************
                RunScript(POWVB("win*")).ToString()
                Call Main()

                'schlafen legen für eine Minute
                schlafen()
            End If
        End While

    End Sub

    Function Prüfung_Resourcen() As Boolean

        Dim Re As New Pruefung
        Dim Prüf As Boolean = True

        If Re.Queue = True _
            Then
            Me.P_SAP_Queue.BackColor = Color.Chartreuse
        Else
            Me.P_SAP_Queue.BackColor = Color.Red

            Prot.Protokoll("Res", "", "SAP_Queue steht nicht zur Verfügung")
            Prüf = False
        End If

        If Re.Fileserver = True _
        Then
            Me.P_Fileserver.BackColor = Color.Chartreuse
        Else
            Me.P_Fileserver.BackColor = Color.Red
            Prot.Protokoll("Res", "", "Fileserver steht nicht zur Verfügung")
            Prüf = False
        End If

        If Re.SQLserver = True _
        Then
            Me.P_SQL_Server.BackColor = Color.Chartreuse
        Else
            Me.P_SQL_Server.BackColor = Color.Red
            Prot.Protokoll("Res", "", "SQL_Server steht nicht zur Verfügung")
            Prüf = False
        End If

        Me.Refresh()
        Return Prüf

    End Function

    Sub schlafen()

        ProgressBar1.Maximum = 60
        ProgressBar1.Value = 60
        ProgressBar1.ForeColor = Color.Red


        For Sek_Wart = 0 To 30
            ProgressBar1.Value = 60 - Sek_Wart * 2
            Me.Refresh()
            Application.DoEvents()
            Thread.Sleep(2000)
            My.Application.DoEvents()

            If Steuerungsflag = False _
                Then
                Exit For
            End If
        Next

        ProgressBar1.Value = 0

    End Sub

    Function Wartungsmodus() As Boolean

        If DateTimePickerWartung.Checked Then

            Dim _wartungBis = DateTimePickerWartung.Value.AddMinutes(NumericUpDown1.Value)
            Dim _wartungVon = DateTimePickerWartung.Value


            If _wartungVon <= Now And Now <= _wartungBis Then
                'Wartungsmodus aktiv

                Return True
            Else
                Return False
            End If

        Else
            'Wartungsmodus nicht aktiv
            Return False

        End If
    End Function


    Private Sub BTN_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Stop.Click

        BTN_Start.Visible = True

        Steuerungsflag = False
        Me.LB_Steuerung.Text = "gestoppt um " & Now
        Prot.Protokoll("Stop", "", "Automat wurde gestoppt")
        Me.Refresh()
        Me.P_App.BackColor = Color.Red
        Me.P_Fileserver.BackColor = Color.DarkGray
        Me.P_SAP_Queue.BackColor = Color.DarkGray
        Me.P_SQL_Server.BackColor = Color.DarkGray
        Me.LB_in_Arbeit.Visible = False

    End Sub

    Sub Bearbeitung_Start()
        Me.LB_in_Arbeit.Visible = True
        Prot.Protokoll("Start", "", "Automat wurde gestartet")
        Me.Refresh()
    End Sub

    Sub Bearbeitung_Ende()
        Me.LB_in_Arbeit.Visible = False
        Me.Refresh()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case MsgBox("Wollen Sie das Programm wirklich beenden?", vbQuestion Or vbYesNo Or vbDefaultButton2, "beenden ?")
            Case vbYes
                If BTN_Start.Visible = True Then
                    Me.Dispose()
                End If
                If BTN_Start.Visible = False Then
                    MsgBox("Bitte drücken sie erst den Stop Button")
                    e.Cancel = True
                    Exit Sub
                End If

                End
            Case vbNo
                e.Cancel = True
        End Select
    End Sub
    Private Function RunScript(ByVal scriptText As String) As Object
        Dim MyRunSpace As Runspace = RunspaceFactory.CreateRunspace()
        MyRunSpace.Open()
        Dim MyPipeline As Pipeline = MyRunSpace.CreatePipeline()
        MyPipeline.Commands.AddScript(scriptText)
        Dim results As Collection(Of PSObject) = MyPipeline.Invoke()
        MyRunSpace.Close()
        Dim MyStringBuilder As New StringBuilder()
        For Each obj As PSObject In results
            MyStringBuilder.AppendLine(obj.ToString())
        Next
        Return MyStringBuilder
    End Function

    'CONVERTING POWERSHELL SCRIPT TO VB FORMAT USING POWERSHELL TO VB.EXE FILE IN FOLDER 
    '\\\emea.fag.com\schweinfurt\DATA\FP-SWE-PS\Projects\DS_Haerterei\SAP_VS\SAP_Automat\PowerShell to VB.NET Code\PowerShell to VB.NET Code\bin\Debug
    'RUN THE EXE FILE PASTE THE POWERSHELL SCRIPT AND PRESS COVERT BUTTON AND THEN COPY THE CONVERTED VB SCRIPT BELOW

    Private Function POWVB(ByVal filter As String)
        Dim Script As New StringBuilder()
        Script.Append("$dir = " + Chr(34) + "\\emea.fag.com\schweinfurt\DATA\FP-SWE-PS\Projects\DS_Haerterei\SAP_Transfer\Bedarfe_Haertei\" + Chr(34) + "" + vbCrLf)
        Script.Append("$latest = Get-ChildItem -Path $dir | Sort-Object Date -Descending " + vbCrLf)
        Script.Append("$k=$latest.count" + vbCrLf)
        Script.Append("for($i=0;$i -lt $k;$i++){" + vbCrLf)
        Script.Append("$datei = $latest[$i].name.Split('.\')[-2] " + vbCrLf)
        Script.Append("$datei" + vbCrLf)
        Script.Append("$end = " + Chr(34) + ".TXT" + Chr(34) + "" + vbCrLf)
        Script.Append("$csv = " + Chr(34) + ".csv" + Chr(34) + "" + vbCrLf)
        Script.Append("$file =  $dir + $datei  + $end " + vbCrLf)
        Script.Append("$file2 = $dir + $datei + " + Chr(34) + "Proc2" + Chr(34) + " + $end" + vbCrLf)
        Script.Append("$file3 = $dir + $datei + " + Chr(34) + "Proc3" + Chr(34) + " + $end" + vbCrLf)
        Script.Append("$file4 = $dir + $datei + " + Chr(34) + "Proc4" + Chr(34) + " + $end" + vbCrLf)
        Script.Append("$file5 = $dir + $datei + " + Chr(34) + "Proc5" + Chr(34) + " + $end" + vbCrLf)
        Script.Append("$file6 = $dir + $datei + " + Chr(34) + "Proc6" + Chr(34) + " + $end" + vbCrLf)
        Script.Append("$file7 = $dir + $datei + " + Chr(34) + "Proc7" + Chr(34) + " + $end  " + vbCrLf)
        Script.Append("$file8 = $dir + $datei + " + Chr(34) + "ready8" + Chr(34) + " + $end" + vbCrLf)
        Script.Append("$filecsv = $dir + $datei + " + Chr(34) + "ready" + Chr(34) + " + $csv" + vbCrLf)
        Script.Append("$filecsv1 = $dir + $datei + " + Chr(34) + "ready1" + Chr(34) + " + $csv" + vbCrLf)
        Script.Append("$filecsv2 = $dir + $datei + " + Chr(34) + "ready2" + Chr(34) + " + $csv" + vbCrLf)
        Script.Append("$final = $dir + $datei + " + Chr(34) + "final" + Chr(34) + " + $csv" + vbCrLf)
        Script.Append("$final1 = $dir + $datei + " + Chr(34) + "final1" + Chr(34) + " + $csv" + vbCrLf)
        Script.Append("" + vbCrLf)
        Script.Append("$str | out-file $file2     # Inhalt der Datei löschen " + vbCrLf)
        Script.Append("foreach ($str in gc $file)" + vbCrLf)
        Script.Append("{                                                                                 " + vbCrLf)
        Script.Append("       if ($str -like '*+-*' -or $str -like '*Ressource*'-or $str -like '*Zeitraum*' -or $str -like '*Granularit*'-or $str -like '*von Datum*')" + vbCrLf)
        Script.Append("        { " + vbCrLf)
        Script.Append("        } else { " + vbCrLf)
        Script.Append("                 $str | out-file $file2 -append   # SubString ist enthalten -> Zeile wird an die Datei angehängt " + vbCrLf)
        Script.Append("               }      " + vbCrLf)
        Script.Append("}" + vbCrLf)
        Script.Append("gc $file2 | foreach-object {$_.TrimStart('|')| Out-File $file3 -append}" + vbCrLf)
        Script.Append("gc $file3 | foreach-object {$_.TrimEnd('|')| Out-File $file4 -append}" + vbCrLf)
        Script.Append("gc $file4 | where {$_ -ne " + Chr(34) + "" + Chr(34) + "}  > $file5" + vbCrLf)
        Script.Append("$Path= $file5" + vbCrLf)
        Script.Append("$OriginalString=    " + Chr(34) + "|" + Chr(34) + "" + vbCrLf)
        Script.Append("$ReplaceString=" + Chr(34) + ";" + Chr(34) + "" + vbCrLf)
        Script.Append("$AllText = [IO.File]::ReadAllText($Path)" + vbCrLf)
        Script.Append("$AllTextNew=$AllText.Replace($OriginalString,$ReplaceString)" + vbCrLf)
        Script.Append("" + vbCrLf)
        Script.Append("#$AllTextNew | Out-File -FilePath $Path #Ausgangsdatei ersetzen" + vbCrLf)
        Script.Append("$AllTextNew | Out-File -FilePath $file6" + vbCrLf)
        Script.Append("gc $file6 | select -Skip 1 | set-content $file7" + vbCrLf)
        Script.Append("" + vbCrLf)
        Script.Append("#gc $file7 | Measure-Object -Line" + vbCrLf)
        Script.Append("$a = (gc $file7 | Measure-Object -Line)" + vbCrLf)
        Script.Append("(gc $file7) | ? {($a.count-2)-notcontains $_.ReadCount} | Set-Content $filecsv" + vbCrLf)
        Script.Append("Remove-Item $dir*Proc*" + vbCrLf)
        Script.Append("" + vbCrLf)
        Script.Append("$l =  $filecsv" + vbCrLf)
        Script.Append("$new = $filecsv1" + vbCrLf)
        Script.Append("" + vbCrLf)
        Script.Append("Get-Content $l | ForEach-Object{" + vbCrLf)
        Script.Append("    If($_ -match " + Chr(34) + ";" + Chr(34) + "){" + vbCrLf)
        Script.Append("" + vbCrLf)
        Script.Append("      $_.Split(" + Chr(34) + ";" + Chr(34) + ")[0..10] -join(" + Chr(34) + ";" + Chr(34) + ") # " + vbCrLf)
        Script.Append("    " + vbCrLf)
        Script.Append("    } Else {" + vbCrLf)
        Script.Append("        $_ " + vbCrLf)
        Script.Append("    }" + vbCrLf)
        Script.Append("} | Set-Content $new |Format-Table" + vbCrLf)
        Script.Append("" + vbCrLf)
        Script.Append("(gc $new) -notmatch '(^[\s;-]*$)|(rows\s*affected)' | set-content $final" + vbCrLf)
        Script.Append("" + vbCrLf)
        Script.Append("Remove-Item $dir*read*" + vbCrLf)
        Script.Append("Remove-Item  $file" + vbCrLf)
        Script.Append("}" + vbCrLf)
        Return Script.ToString()
    End Function

End Class
