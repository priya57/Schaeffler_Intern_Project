Imports System.Data.OleDb
Imports System.IO


'**************************************************  UPLOADING CSV FILES TO ORACLE DATABSES AND THEN DELETING CSV FILES***********************************
Module Module1

    Public Function csvToDatatable(ByVal filename As String, ByVal separator As String)

        Dim dt As New System.Data.DataTable
        Dim firstLine As Boolean = True
        If IO.File.Exists(filename) Then
            Using sr As New StreamReader(filename)
                dt.Columns.Add("VONDATUM")
                dt.Columns.Add("BISDATUM")
                dt.Columns.Add("AUFTRAG")
                dt.Columns.Add("DISPOEL")
                dt.Columns.Add("MATERIAL")
                dt.Columns.Add("BEZEICHNUNG")
                dt.Columns.Add("VRG")
                dt.Columns.Add("ARBPLATZ")
                dt.Columns.Add("TERMSTART")
                dt.Columns.Add("TERMENDE")
                dt.Columns.Add("VORMENGE")

                While Not sr.EndOfStream
                    Dim data() As String = sr.ReadLine.Split(separator)
                    dt.Rows.Add(data.ToArray)
                End While
            End Using
        End If
        Return dt

    End Function
    Sub Main()

        Dim di As New IO.DirectoryInfo("\\emea.fag.com\schweinfurt\DATA\FP-SWE-PS\Projects\DS_Haerterei\SAP_Transfer\Bedarfe_Haertei\")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        'list the names of all files in the specified directory
        For Each dra In diar1

            Dim path As String = dra.FullName
            Dim finaldt As DataTable = csvToDatatable(path, ";")
            Dim oledbcn As New OleDbConnection(My.Settings.SQL_Server)
            Dim cmd As New OleDbCommand()
            cmd.CommandType = CommandType.Text

            For Each Row As DataRow In finaldt.Rows
                cmd.CommandText = "Insert into SAP_ZPCP12(ID, VONDATUM, BISDATUM, AUFTRAG, DISPOEL,MATERIAL, BEZEICHNUNG, VRG, ARBPLATZ, TERMSTART, TERMENDE, VORMENGE,UPD_DATE)
                               values (SEQ_SAP_ZPCP12.NEXTVAL,?,?,?,?,?,?,?,?,?,?,?,SYSDATE)"
                cmd.Parameters.Add("@VONDATUM", OleDbType.Date).Value = DateTime.ParseExact(Row(0), "dd.MM.yyyy", Nothing)
                cmd.Parameters.Add("@BISDATUM", OleDbType.Date).Value = DateTime.ParseExact(Row(1), "dd.MM.yyyy", Nothing)
                cmd.Parameters.Add("@AUFTRAG", OleDbType.VarChar).Value = Row(2)
                cmd.Parameters.Add("@DISPOEL", OleDbType.VarChar).Value = Row(3)
                cmd.Parameters.Add("@MATERIAL", OleDbType.VarChar).Value = Row(4)
                cmd.Parameters.Add("@BEZEICHNUNG", OleDbType.VarChar).Value = Row(5)
                cmd.Parameters.Add("@VRG", OleDbType.VarChar).Value = Row(6)
                cmd.Parameters.Add("@ARBPLATZ", OleDbType.VarChar).Value = Row(7)
                cmd.Parameters.Add("@TERMSTART", OleDbType.Date).Value = DateTime.ParseExact(Row(8), "dd.MM.yyyy", Nothing)
                cmd.Parameters.Add("@TERMENDE", OleDbType.Date).Value = DateTime.ParseExact(Row(9), "dd.MM.yyyy", Nothing)
                cmd.Parameters.Add("@VORMENGE", OleDbType.VarChar).Value = Row(10)
                cmd.Connection = oledbcn
                oledbcn.Open()
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                oledbcn.Close()
            Next
            System.IO.File.Delete(dra.FullName)
        Next
    End Sub
End Module