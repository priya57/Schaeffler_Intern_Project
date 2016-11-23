Imports System.Data.OleDb.OleDbDataAdapter
Imports System.IO

Public Class Datei_Aktualität

    Sub Aktualität_Dateien()


        Dim Ref_Conn As New OleDbConnection(My.Settings.SQL_Server)
        Ref_Conn.Open()

        Dim Ref_DT As New DataTable
        Dim Ref_cmd As New OleDbCommand("Select * FROM AUTO_TRANSFER", Ref_Conn)

        Dim Ref_DA As New OleDbDataAdapter(Ref_cmd)
        Ref_DA.Fill(Ref_DT)

        Form1.LB_Downloads.Items.Clear()

        For Each zeile In Ref_DT.Rows
            If DateDiff(DateInterval.Hour, File.GetLastWriteTime(zeile("TRA_Win_File")), Now) > zeile("TRA_Zyklus_STD") _
                Then
                Form1.LB_Downloads.Items.Add(zeile("TRA_Trigger").ToString)
            End If
        Next

        Ref_Conn.Close()


    End Sub

    Sub Aktualität_Trigger()
        Dim Ref_Conn As New OleDbConnection(My.Settings.SQL_Server)
        Ref_Conn.Open()

        Dim Ref_DT As New DataTable
        Dim Ref_cmd As New OleDbCommand("Select * FROM AUTO_Trigger", Ref_Conn)

        Dim Ref_DA As New OleDbDataAdapter(Ref_cmd)
        Ref_DA.Fill(Ref_DT)

        Form1.LB_Trigger.Items.Clear()

        For Each zeile In Ref_DT.Rows
            Form1.LB_Trigger.Items.Add(zeile("TRI_Name").ToString)
        Next

        Ref_Conn.Close()


    End Sub

End Class
