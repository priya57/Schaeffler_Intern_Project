Imports System.Data
Imports System.Data.OleDb

Public Class Protokoll
    Public LB As ListBox

    Sub Trigger_schreiben(ByVal Name)

        Try
            Dim MP_Conn As New OleDbConnection(My.Settings.SQL_Server)
            MP_Conn.Open()

            Dim TRI_cmd As New OleDbCommand("Insert INTO AUTO_Trigger (TRI_Name, TRI_Datum) VALUES( ?, ?)", MP_Conn)
            TRI_cmd.Parameters.AddWithValue("@Name", Name)
            TRI_cmd.Parameters.AddWithValue("@Datum", Now())
            TRI_cmd.ExecuteNonQuery()
            MP_Conn.Close()
        Catch ex As Exception

        End Try

    End Sub

    Function Trigger_vorhanden(ByVal Name) As Boolean

        Try
            Dim MP_Conn As New OleDbConnection(My.Settings.SQL_Server)
            MP_Conn.Open()

            Dim TRI_cmd As New OleDbCommand("Select * FROM AUTO_Trigger where TRI_Name = ?", MP_Conn)
            TRI_cmd.Parameters.AddWithValue("@Name", Name)

            Dim Trigger_reader As OleDbDataReader = TRI_cmd.ExecuteReader

            If Trigger_reader.HasRows _
                Then
                MP_Conn.Close()
                Return True
            Else
                MP_Conn.Close()
                Return False
            End If

        Catch ex As Exception

        End Try

        Return False

    End Function

    Sub Trigger_loeschen(ByVal Name)

        Try
            Dim MP_Conn As New OleDbConnection(My.Settings.SQL_Server)
            MP_Conn.Open()

            Dim TRI_cmd As New OleDbCommand("DELETE FROM AUTO_Trigger where TRI_Name = ?", MP_Conn)
            TRI_cmd.Parameters.AddWithValue("@Name", Name)
            TRI_cmd.ExecuteNonQuery()
            MP_Conn.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub Protokoll(ByVal Vorgang As String, ByVal Trigger As String, ByVal Bemerkungen As String)


        Dim LB As ListBox = Form1.LB_Protokoll
        Try
            Dim MP_Conn As New OleDbConnection(My.Settings.SQL_Server)
            MP_Conn.Open()

            Dim Pro_cmd As New OleDbCommand("Insert INTO AUTO_Protokoll (Pro_Datum,Pro_Vorgang,Pro_Trigger,Pro_Bemerkungen) VALUES( ?, ?, ?, ?)", MP_Conn)
            Pro_cmd.Parameters.AddWithValue("@Datum", Now())
            Pro_cmd.Parameters.AddWithValue("@Vorgang", Vorgang)
            Pro_cmd.Parameters.AddWithValue("@Trigger", Trigger)
            Pro_cmd.Parameters.AddWithValue("@Bemerkungen", Bemerkungen)
            Pro_cmd.ExecuteNonQuery()
            MP_Conn.Close()

            If Vorgang = "Kop" Then Form1.Anz_Downloads.Text = CInt(Form1.Anz_Downloads.Text) + 1

        Catch ex As Exception

        End Try


        LB.Items.Add(Now.ToString.PadRight(20) & Vorgang.PadRight(12) & Trigger.PadRight(23) & Bemerkungen)

    End Sub


End Class
