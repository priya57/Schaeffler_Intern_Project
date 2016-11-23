
Imports System.IO
Imports System.Data.SqlClient

Public Class Kopiervorgang

    Structure Dat_Verz
        Dim SAP_Dateiname As String
        Dim Win_Dateiname As String
        Dim TRG_Dateiname As String
        Dim Bezeichnung As String
    End Structure

    Structure Dat_Referenz
        Dim Referenz1 As String
        Dim Referenz2 As String
        Dim Referenz3 As String
        Dim Win_Dateiname As String
        Dim TRG_Dateiname As String
        Dim Bezeichnung As String
    End Structure

    Friend VZ_Dateien As New List(Of Dat_Verz)
    Friend VZ_Referenzen As New List(Of Dat_Referenz)
    Friend Anz_Dateien_kopiert As Integer = 0
    Friend Prot As New Protokoll

    Sub Kopieren()
        Call Referenzen_lesen()
        Call Verzeichnis_lesen()
        Call Dateien_kopieren()

    End Sub



    Sub Verzeichnis_lesen()

        'Lesen des zu überwachende SAP_Verzeichnis

        'Damit die Dateien auch nicht während des Schreibens verschoben werden ist eine Verweilzeit von 2 Minauten nach dem Kreieren 
        'eingeplant
        Dim DIR As New DirectoryInfo(My.Settings.SAP_Queue)

        VZ_Dateien.Clear()

        Try
            For Each FI As FileInfo In DIR.GetFiles
                'If Path.GetExtension(FI.FullName.ToUpper) = ".m00" _
                'Then
                If DateDiff(DateInterval.Minute, FI.CreationTime, Now()) > 1 _
                Then
                    Dim Datei_Info As Dat_Verz
                    Datei_Info.SAP_Dateiname = ""
                    Datei_Info.Win_Dateiname = ""
                    Datei_Info.TRG_Dateiname = ""
                    Datei_Info.Bezeichnung = ""

                    Datei_Info.SAP_Dateiname = FI.FullName
                    Call Datei_lesen(Datei_Info.SAP_Dateiname, Datei_Info.Win_Dateiname, Datei_Info.TRG_Dateiname, Datei_Info.Bezeichnung)
                    VZ_Dateien.Add(Datei_Info)
                    'End If
                End If
            Next
        Catch ex As Exception
        End Try

        My.Application.DoEvents()
    End Sub

    Sub Datei_lesen(ByVal Dateiname As String, ByRef Win_Dateiname As String, ByRef TRG_Dateiname As String, ByRef Bezeichung As String)

        Dim Zeile As String = "~~"
        Dim Anz_Zeilen As Int16 = 0

        'Lesen der ersten 100 Zeilen

        Using SR As New StreamReader(Dateiname)

            Do Until SR.EndOfStream Or Anz_Zeilen > 100
                Anz_Zeilen += 1
                Zeile &= SR.ReadLine
            Loop

        End Using

        'Prüfen der ersten 20 Zeilen

        For Each Re In VZ_Referenzen

            If Zeile.IndexOf(Re.Referenz1) > 1 And Zeile.IndexOf(Re.Referenz2) > 1 And Zeile.IndexOf(Re.Referenz3) > 1 _
            Then
                Win_Dateiname = Re.Win_Dateiname
                TRG_Dateiname = Re.TRG_Dateiname
                Bezeichung = Re.Bezeichnung
                Exit For
            End If
        Next

        If Win_Dateiname = "" _
        Then
            Dim Dateiname_extrakt() = Dateiname.Split("\")
            Win_Dateiname = My.Settings.Fileserver & "\" & Dateiname_extrakt(Dateiname_extrakt.Length - 1)
            Bezeichung = "unbekannt"
        End If

    End Sub


    Sub Referenzen_lesen()

        Dim Ref_Conn As New OleDbConnection(My.Settings.SQL_Server)
        Ref_Conn.Open()

        Dim Ref_DT As New DataTable
        Dim Ref_cmd As New OleDbCommand("Select * FROM AUTO_TRANSFER", Ref_Conn)

        Dim Ref_DA As New OleDbDataAdapter(Ref_cmd)
        Ref_DA.Fill(Ref_DT)

        For Each zeile In Ref_DT.Rows
            Dim RE As New Dat_Referenz
            RE.Referenz1 = zeile("TRA_Referenz1").ToString
            RE.Referenz2 = zeile("TRA_Referenz2").ToString
            RE.Referenz3 = zeile("TRA_Referenz3").ToString
            RE.Bezeichnung = zeile("TRA_Bezeichnung").ToString
            RE.Win_Dateiname = zeile("TRA_Win_File").ToString
            RE.TRG_Dateiname = zeile("TRA_Trigger").ToString
            VZ_Referenzen.Add(RE)
        Next

        Ref_Conn.Close()

    End Sub

    Sub Dateien_kopieren()

        For Each Dat In VZ_Dateien

            'Alte Datei lösen - wenn sie vorhanden ist

            Try
                System.IO.File.Delete(Dat.Win_Dateiname)
            Catch ex As Exception
            End Try

            ' Verschieben der Datei
            ' Ist das Verzeichnis nicht vorhanden wird das Standardverzeichnis genommen

            Try
                System.IO.File.Move(Dat.SAP_Dateiname, Dat.Win_Dateiname)
            Catch ex As Exception

                Dim Dateiname_extrakt() = Dat.SAP_Dateiname.Split("\")
                Dat.Win_Dateiname = My.Settings.Nicht_interpretierbar & "\" & Dateiname_extrakt(Dateiname_extrakt.Length - 1)
                Try
                    System.IO.File.Move(Dat.SAP_Dateiname, Dat.Win_Dateiname)
                Catch xx As Exception
                End Try
            End Try


            Prot.Trigger_schreiben(Dat.TRG_Dateiname)
            Prot.Protokoll("Kop", Dat.TRG_Dateiname, Dat.Win_Dateiname)

        Next


    End Sub

End Class
