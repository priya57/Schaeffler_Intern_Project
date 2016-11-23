Imports System.IO
Imports System.Data.OleDb


Public Class Pruefung

    ReadOnly Property Queue As Boolean
        Get
            Dim DIR As New DirectoryInfo(My.Settings.SAP_Queue)

            Try
                For Each FI As FileInfo In DIR.GetFiles
                Next
            Catch ex As Exception
                Return False
            End Try
            Return True

        End Get
    End Property

    ReadOnly Property Fileserver As Boolean
        Get
            Dim DIR As New DirectoryInfo(My.Settings.Fileserver)

            Try
                For Each FI As FileInfo In DIR.GetFiles
                Next
            Catch ex As Exception
                Return False
            End Try
            Return True

        End Get
    End Property


    ReadOnly Property SQLserver As Boolean
        Get
            Dim SQLDB As New OleDbConnection(My.Settings.SQL_Server)

            Try
                Dim T_DT As New DataTable
                SQLDB.Open()
                Dim T_cmd As New OleDbCommand("SELECT * FROM AUTO_Trigger", SQLDB)
                Dim T_DA As New OleDbDataAdapter(T_cmd)
                T_DA.Fill(T_DT)

            Catch ex As Exception
                Return False
            End Try
            SQLDB.Dispose()
            Return True

        End Get
    End Property



End Class
