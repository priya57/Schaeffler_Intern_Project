Imports System.IO
Imports System.Data.OleDb
Imports System.Threading
Imports System.Data

Public Class Trigger


    Sub Trigger_lesen()

        'Lesen der Trigger

        Dim T_DT As New DataTable
        Dim TDef_DT As New DataTable
        Dim TLösch As New List(Of String)

        Dim SQLDB As New OleDbConnection(My.Settings.SQL_Server)

        Try
            SQLDB.Open()

            'Triggerdefinitionen lesen
            Dim TDef_cmd As New OleDbCommand("SELECT * FROM AUTO_Trigger_Definition WHERE AUTO_Trigger_Definition.Win7='ja' Or AUTO_Trigger_Definition.Win7 Is Null", SQLDB)
            Dim TDef_DA As New OleDbDataAdapter(TDef_cmd)
            TDef_DA.Fill(TDef_DT)

        Catch ex As Exception
            Form1.LB_Protokoll.Items.Add("Fehler beim lesen der Trigger")
        End Try

        SQLDB.Close()

        Dim Tri As New Protokoll

        For Each Def As DataRow In TDef_DT.Rows

            Dim relevant As Boolean = True

            Dim Trigger(6) As String

            For idx = 1 To 6
                If Def(idx).ToString() <> "" _
                    Then
                    If Tri.Trigger_vorhanden(Def(idx)) = False _
                        Then
                        relevant = False
                        Exit For
                    Else
                        Dim test As String
                        If Def(idx) Like "HRTest*" Then

                            test = Def(idx)
                        End If
                        Trigger(idx) = Def(idx)
                    End If

                End If

            Next

            'Starten des Triggers
            If relevant = True _
                Then
                Dim Pr As New Process
                Pr.StartInfo.FileName = Def(7)
                Try
                    Pr.Start()
                    Tri.Protokoll("Start", "", Def(7))
                    Form1.LB_Verarbeitung.Text += 1
                Catch ex As Exception
                    Form1.LB_Protokoll.Items.Add("Fehler beim Start des Programms: " & Def(7))
                End Try

                'Vormerken Löschen der Trigger

                For idx = 1 To 6
                    If Trigger(idx) <> "" _
                        Then
                        TLösch.Add(Trigger(idx))
                    End If

                Next

            End If

        Next

        'Löschen der Trigger
        For Each Trig In TLösch
            Tri.Trigger_loeschen(Trig)
            Tri.Protokoll("Lösch", Trig, "")
        Next

    End Sub

End Class
