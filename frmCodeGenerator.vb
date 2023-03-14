Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Management.Smo

Friend Class frmCodeGenerator
    Inherits Form
    Private gADType As String
    Private gFieldLength As String
    Private gNullToWhat As String
    Private gPHPNullFunction As String
    Private gPref As String
    Private gSQLType As String
    Private gTableOfTables As String
    Private gType As String
    Private gWhatToNull As String
    Private gAuditNullFunction As String
    Private gAuditNullToWhat As String
    Private vWhatsGoneAlready As Object
    Private gStrictly As String

    Private svr As Server


    Public Function AddElement(ByVal vArray As Object, ByVal vElem As Object) As Object

        Dim vRet As Object

        If IsNothing(vArray) Then
            vRet = New Object() {vElem}
        Else
            vRet = vArray
            ReDim Preserve vRet(UBound(vArray) + 1)
            vRet(UBound(vRet)) = vElem
        End If

        AddElement = vRet

    End Function


    Public Function getDatabaseList(ByRef svr As Microsoft.SqlServer.Management.Smo.Server) As DataTable
        Dim dt As New DataTable
        With dt.Columns
            .Add("DatabaseName")
        End With

        For Each db As Microsoft.SqlServer.Management.Smo.Database In svr.Databases
            Dim dr As DataRow = dt.NewRow
            dr("DatabaseName") = db.Name
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function getTableList(ByRef db As Microsoft.SqlServer.Management.Smo.Database) As DataTable
        Dim dt As New DataTable
        With dt.Columns
            .Add("TableName")
            .Add("Schema")
        End With

        For Each tbl As Microsoft.SqlServer.Management.Smo.Table In db.Tables
            Dim dr As DataRow = dt.NewRow
            dr("TableName") = tbl.Name
            dr("Schema") = tbl.Schema
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Function ReplaceText(ByVal OriginalText As String, ByVal SearchFor As String, ByVal ReplaceWith As String, Optional ByRef ErrInc As Integer = 0) As String

        Dim x As Integer
        Do While InStr(OriginalText, SearchFor) > 0
            x = InStr(OriginalText, SearchFor)
            OriginalText = Microsoft.VisualBasic.Left(OriginalText, x - 1) & ReplaceWith & Microsoft.VisualBasic.Right(OriginalText, Len(OriginalText) - x - (Len(SearchFor) - 1))
            If ErrInc > 0 And IsNumeric(ReplaceWith) Then
                ReplaceWith = CStr(CInt(ReplaceWith) + ErrInc)
            End If
        Loop

        ReplaceText = OriginalText

    End Function


    Public Sub CreateCode(ByVal strScriptName As String, ByVal strOuputDir As String, ByRef strPrefix As String, ByRef strSuffix As String, Optional ByVal blnCollectionIndicator As Boolean = False, Optional ByVal strOutputFileName As String = "")

        Dim lngNum As Integer = 0
        Dim strFileName As String = ""
        Dim strField As String = ""
        Dim strText As String = ""
        Dim f As Integer = 0
        Dim x As Integer = 0
        Dim lngStartHash As Integer = 0
        Dim lngEndHash As Integer = 0
        Dim strToReplace As String = ""
        Dim strToAdd As String = ""
        Dim lngFldCount As Integer = 0
        Dim strSingularName As String = ""
        Dim conn As SqlConnection
        Dim dsSchemaTables As New DataSet
        Dim dsTable As New DataSet
        Dim blnRecognized As Boolean
        Dim lngADLength As Integer = 0
        Dim lngErrNumCnt As Integer = 0
        Dim strTableDef As String = ""
        Dim strToAppend As String = ""
        Dim dblStartPerc As Double = 0
        Dim dblEndPerc As Double = 0
        Dim TableDetail As Object = Nothing
        Dim adapter As New SqlDataAdapter
        Dim blnAudited As Boolean = False
        Dim blnIncludesClientRef As Boolean = False


        conn = New SqlConnection("Data Source=NM-ENVY\SQLEXPRESS;Initial Catalog='" & "Workman" & "';Integrated Security=SSPI;")

        Dim strSQL As String
        strSQL = "select DBTable, EmployeeRefIsPrimaryKey, SingularName, AuditTable, IncludesClientRef from DBTables"
        dsSchemaTables = New DataSet
        adapter.SelectCommand = New SqlCommand(strSQL, conn)
        adapter.Fill(dsSchemaTables, "SchemaTables")

        lngErrNumCnt = 10000

        Dim blnEmployeeRefIsPrimaryKey As Boolean
        Dim dr As DataRow
        For Each dr In dsSchemaTables.Tables(0).Rows

            strTableDef = dr("DBTable").ToString
            strSingularName = dr("SingularName").ToString
            blnEmployeeRefIsPrimaryKey = dr("EmployeeRefIsPrimaryKey")
            blnAudited = dr("AuditTable")
            blnIncludesClientRef = dr("IncludesClientRef")

            Debug.Print(strTableDef)
            strSQL = "SELECT * FROM " & strTableDef & ""
            dsTable = New DataSet
            adapter.SelectCommand = New SqlCommand(strSQL, conn)
            adapter.FillSchema(dsTable, SchemaType.Mapped)

            lngNum = FreeFile()
            strFileName = strScriptName
            FileOpen(lngNum, strFileName, OpenMode.Input)
            strText = ""
            Do While Not EOF(lngNum)
                strText = strText & InputString(lngNum, 1)
            Loop
            FileClose(lngNum)

            lngFldCount = dsTable.Tables(0).Columns.Count
            blnRecognized = False

            For f = 0 To UBound(vWhatsGoneAlready)
                If strTableDef = vWhatsGoneAlready(f)(0) Then
                    strSingularName = vWhatsGoneAlready(f)(1)
                    blnRecognized = True
                    Exit For
                End If
            Next f

            If blnRecognized = False Then

                TableDetail = AddElement(TableDetail, strTableDef)
                TableDetail = AddElement(TableDetail, strSingularName)
                vWhatsGoneAlready = AddElement(vWhatsGoneAlready, TableDetail)
                TableDetail = Nothing
            End If

            strText = ReplaceText(strText, "@SINGULARNAME@", strSingularName)
            strText = ReplaceText(strText, "@RANDOMNUMBER@", CStr(lngErrNumCnt))

            lngErrNumCnt = lngErrNumCnt + 1000

            strText = ReplaceText(strText, "@ERRNUMBER@", CStr(lngErrNumCnt), 10)
            strText = ReplaceText(strText, "@TABLENAME@", strTableDef)
            strText = ReplaceText(strText, "@ID@", dsTable.Tables(0).Columns(0).ColumnName)

            Call SelectTypes(dsTable.Tables(0).Columns(0).DataType.FullName, dsTable.Tables(0).Columns(0).MaxLength)
            lngADLength = dsTable.Tables(0).Columns(0).MaxLength

            strText = ReplaceText(strText, "@IDFIELDTYPE@", gType)
            strText = ReplaceText(strText, "@IDPREF@", gPref)
            strText = ReplaceText(strText, "@adIDFIELDTYPE@", gADType)
            strText = ReplaceText(strText, "@adIDFIELDLENGTH@", gFieldLength)
            strText = ReplaceText(strText, "@IDSQLTYPE@", gSQLType)

            Dim fieldSeparator As String = "$"
            Dim stringIndicator As String = "%"
            Dim auditIndicator As String = "~"
            Dim employeeRefIndicator As String = "#"
            Dim clientRefIndicator As String = "^"

            'all the other fields except the last

            Do While InStr(strText, fieldSeparator) > 0
                strToAppend = ""
                strToAdd = ""
                lngStartHash = InStr(strText, fieldSeparator)
                lngEndHash = InStr(lngStartHash + 1, strText, fieldSeparator)
                strToReplace = Mid(strText, lngStartHash, lngEndHash - lngStartHash + 1)
                x = 0

                dblStartPerc = InStr(strToReplace, stringIndicator)

                For f = 1 To lngFldCount - 2
                    strField = dsTable.Tables(0).Columns(f).ColumnName

                    Call SelectTypes(dsTable.Tables(0).Columns(f).DataType.FullName, dsTable.Tables(0).Columns(f).MaxLength)

                    lngADLength = dsTable.Tables(0).Columns(f).MaxLength()

                    strToAdd = strToReplace

                    strToAdd = ReplaceText(strToAdd, "@FIELD@", strField)
                    strToAdd = ReplaceText(strToAdd, "@FIELDTYPE@", gType)
                    strToAdd = ReplaceText(strToAdd, "@PREF@", gPref)
                    strToAdd = ReplaceText(strToAdd, "@adFIELDTYPE@", gADType)
                    strToAdd = ReplaceText(strToAdd, "@adFIELDLENGTH@", gFieldLength)
                    strToAdd = ReplaceText(strToAdd, "@SQLTYPE@", gSQLType)
                    strToAdd = ReplaceText(strToAdd, "@NULLTOWHAT@", gNullToWhat)
                    strToAdd = ReplaceText(strToAdd, "@WHATTONULL@", gWhatToNull)
                    strToAdd = ReplaceText(strToAdd, "@PHPNULL@", gPHPNullFunction)
                    strToAdd = ReplaceText(strToAdd, "@STRICTLY@", gStrictly)

                    If dblStartPerc > 0 And (dsTable.Tables(0).Columns(f).DataType.ToString <> "System.String") Then
                        'do not add the string
                    Else 'If dsTable.Tables(0).Columns(f).DataType.ToString = "System.String" Then
                        strToAppend = strToAppend & strToAdd
                    End If

                    'delete stuff in between % signs for fields that doesn't relate to string fields
                    Do While InStr(strToAppend, stringIndicator) > 0
                        dblStartPerc = InStr(strToAppend, stringIndicator)
                        dblEndPerc = InStr(CInt(dblStartPerc + 1), strToAppend, stringIndicator)

                        If dblStartPerc > 0 And (dsTable.Tables(0).Columns(f).DataType.ToString <> "System.String") Then
                            'non text field between % signs - lose it
                            strToAppend = Microsoft.VisualBasic.Left(strToAppend, dblStartPerc - 1) & Microsoft.VisualBasic.Right(strToAppend, Len(strToAppend) - dblEndPerc)
                        ElseIf dblStartPerc > 0 Then
                            'text field or not between % signs - do nothing
                            strToAppend = Microsoft.VisualBasic.Left(strToAppend, dblStartPerc - 1) & Mid(strToAppend, dblStartPerc + 1, dblEndPerc - dblStartPerc - 3) & Microsoft.VisualBasic.Right(strToAppend, Len(strToAppend) - dblEndPerc)
                        Else
                            'do nothing
                        End If

                    Loop

                Next f

                'replace the $ signs
                Do While InStr(strToAppend, fieldSeparator) > 0
                    x = InStr(strToAppend, fieldSeparator)
                    strToAppend = Microsoft.VisualBasic.Left(strToAppend, x - 1) & Microsoft.VisualBasic.Right(strToAppend, Len(strToAppend) - x)
                Loop

                'replace the % signs
                Do While InStr(strToAppend, stringIndicator) > 0
                    x = InStr(strToAppend, stringIndicator)
                    strToAppend = Microsoft.VisualBasic.Left(strToAppend, x - 1) & Microsoft.VisualBasic.Right(strToAppend, Len(strToAppend) - x)
                Loop

                strText = Microsoft.VisualBasic.Left(strText, lngStartHash - 1) & strToAppend & Microsoft.VisualBasic.Right(strText, Len(strText) - lngEndHash)

            Loop

            'the last field
            f = lngFldCount - 1
            strField = dsTable.Tables(0).Columns(f).ColumnName
            strText = ReplaceText(strText, "@LASTFIELD@", strField)

            lngADLength = dsTable.Tables(0).Columns(f).MaxLength

            Call SelectTypes(dsTable.Tables(0).Columns(f).DataType.FullName, dsTable.Tables(0).Columns(f).MaxLength)
            strText = ReplaceText(strText, "@LASTFIELDTYPE@", gType)
            strText = ReplaceText(strText, "@LASTPREF@", gPref)
            strText = ReplaceText(strText, "@adLASTFIELDLENGTH@", gFieldLength)
            strText = ReplaceText(strText, "@adLASTFIELDTYPE@", gADType)
            strText = ReplaceText(strText, "@LASTSQLTYPE@", gSQLType)
            strText = ReplaceText(strText, "@LASTNULLTOWHAT@", gNullToWhat)
            strText = ReplaceText(strText, "@LASTWHATTONULL@", gWhatToNull)
            strText = ReplaceText(strText, "@LASTPHPNULL@", gPHPNullFunction)
            strText = ReplaceText(strText, "@AUDITWHATTONULL@", gAuditNullFunction)
            strText = ReplaceText(strText, "@STRICTLY@", gStrictly)

            'delete stuff in between % signs for last fields that doesn't relate to string fields
            Do While InStr(strText, stringIndicator) > 0
                dblStartPerc = InStr(strText, stringIndicator)
                dblEndPerc = InStr(CInt(dblStartPerc + 1), strText, stringIndicator)

                If dblStartPerc > 0 And (dsTable.Tables(0).Columns(f).DataType.ToString <> "System.String") Then
                    'non text field between % signs - lose it
                    strText = Microsoft.VisualBasic.Left(strText, dblStartPerc - 1) & Microsoft.VisualBasic.Right(strText, Len(strText) - dblEndPerc)
                ElseIf dblStartPerc > 0 Then
                    'text field or not between % signs - do nothing
                    strText = Microsoft.VisualBasic.Left(strText, dblStartPerc - 1) & Mid(strText, dblStartPerc + 1, dblEndPerc - dblStartPerc - 3) & Microsoft.VisualBasic.Right(strText, Len(strText) - dblEndPerc)
                Else
                    'do nothing
                End If

            Loop

            'delete stuff between # signs for tables that don't have EmployeeRef in them

            Do While InStr(strText, employeeRefIndicator) > 0
                dblStartPerc = InStr(strText, employeeRefIndicator)
                dblEndPerc = InStr(CInt(dblStartPerc + 1), strText, employeeRefIndicator)

                If blnEmployeeRefIsPrimaryKey Then
                    strText = Microsoft.VisualBasic.Left(strText, dblStartPerc - 1) & Mid(strText, dblStartPerc + 1, dblEndPerc - dblStartPerc - 3) & Microsoft.VisualBasic.Right(strText, Len(strText) - dblEndPerc)
                ElseIf dblStartPerc > 0 Then
                    'non text field between % signs - lose it
                    strText = Microsoft.VisualBasic.Left(strText, dblStartPerc - 1) & Microsoft.VisualBasic.Right(strText, Len(strText) - dblEndPerc)
                Else
                    'do nothing
                End If
            Loop

            'delete stuff between ~ signs for tables that aren't being audited

            Do While InStr(strText, auditIndicator) > 0
                dblStartPerc = InStr(strText, auditIndicator)
                dblEndPerc = InStr(CInt(dblStartPerc + 1), strText, auditIndicator)

                If blnAudited Then
                    strText = Microsoft.VisualBasic.Left(strText, dblStartPerc - 1) & Mid(strText, dblStartPerc + 1, dblEndPerc - dblStartPerc - 3) & Microsoft.VisualBasic.Right(strText, Len(strText) - dblEndPerc)
                ElseIf dblStartPerc > 0 Then
                    'non text field between ~ signs - lose it
                    strText = Microsoft.VisualBasic.Left(strText, dblStartPerc - 1) & Microsoft.VisualBasic.Right(strText, Len(strText) - dblEndPerc)
                Else
                    'do nothing
                End If
            Loop

            'delete stuff between ^ signs for tables without clientref in them

            Do While InStr(strText, clientRefIndicator) > 0
                dblStartPerc = InStr(strText, clientRefIndicator)
                dblEndPerc = InStr(CInt(dblStartPerc + 1), strText, clientRefIndicator)

                If blnIncludesClientRef Then
                    strText = Microsoft.VisualBasic.Left(strText, dblStartPerc - 1) & Mid(strText, dblStartPerc + 1, dblEndPerc - dblStartPerc - 3) & Microsoft.VisualBasic.Right(strText, Len(strText) - dblEndPerc)
                ElseIf dblStartPerc > 0 Then
                    'non text field between ^ signs - lose it
                    strText = Microsoft.VisualBasic.Left(strText, dblStartPerc - 1) & Microsoft.VisualBasic.Right(strText, Len(strText) - dblEndPerc)
                Else
                    'do nothing
                End If
            Loop

            'replace the % signs
            Do While InStr(strText, stringIndicator) > 0
                x = InStr(strText, stringIndicator)
                strText = Microsoft.VisualBasic.Left(strText, x - 1) & Microsoft.VisualBasic.Right(strText, Len(strText) - x)
            Loop

            'output the file to somewhere
            lngNum = FreeFile()
            If blnCollectionIndicator = True And strOutputFileName = "" Then
                strFileName = strOuputDir & strPrefix & strTableDef & "." & strSuffix
                FileOpen(lngNum, strFileName, OpenMode.Output)
            ElseIf strOutputFileName <> "" Then
                strFileName = strOuputDir & strOutputFileName
                FileOpen(lngNum, strFileName, OpenMode.Append)
            Else
                strFileName = strOuputDir & strPrefix & strSingularName & "." & strSuffix
                FileOpen(lngNum, strFileName, OpenMode.Output)
            End If
            PrintLine(lngNum, strText)
            FileClose(lngNum)

            strText = ""

            'dsTable = Nothing
            '            dsSchemaTables.

        Next

        dsSchemaTables = Nothing
        conn = Nothing

        Exit Sub

ErrorHandler:

        If Err.Number = -2147217911 Then
            Resume Next
        Else
            MsgBox(Err.Number & ", " & Err.Description)
        End If
    End Sub


    Private Sub frmCodeGenerator_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.Icon = My.Resources.Generator

        Dim src As Object
        src = My.Application.Info.DirectoryPath & "\"

        On Error Resume Next
        MkDir(src & "cClasses\")
        MkDir(src & "sprocs\")

        txtCOutputLocation.Text = src & "cClasses\"
        txtcClassScript.Text = src & "cClass.txt"
        txtcClassPHPScript.Text = src & "c_Class.php"
        txtSprocs.Text = src & "sprocs.txt"
        txtSprocsLocation.Text = src & "sprocs\"



    End Sub

    Private Sub Generate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Generate.Click


        Cursor = Cursors.WaitCursor

        Dim i As Short
        Dim TableDetail As Object = Nothing

        gTableOfTables = Me.txtTableOfTables.Text

        For i = 0 To 2
            TableDetail = AddElement(TableDetail, CObj("_"))
        Next i

        vWhatsGoneAlready = AddElement(vWhatsGoneAlready, TableDetail)
        TableDetail = Nothing
        Dim myFileName As String
        'get rid of the existing sql files
        myFileName = txtSprocsLocation.Text & "Sprocs.sql"
        On Error Resume Next
        Kill(myFileName)
        On Error GoTo 0


        'CreateCode(txtcClassPHPScript.Text, txtCOutputLocation.Text, "c_", "php")

        CreateCode(txtcClassScript.Text, txtCOutputLocation.Text, "", "vb")

        CreateCode(txtSprocs.Text, txtSprocsLocation.Text, "", "", , "sprocs.sql")

        Cursor = Cursors.Default

    End Sub

    Private Sub SelectTypes(ByVal type As String, ByVal maxlength As Int32)

        Select Case type
            Case "System.String"
                gType = "string"
                gADType = "SqlDbType.VarChar"
                If maxlength > 8000 Then
                    gSQLType = "VarChar(MAX)"
                Else
                    gSQLType = "VarChar(" & maxlength & ")"
                End If
                gNullToWhat = "NullsToEmptyString"
                gWhatToNull = "EmptyStringToNull"
                gAuditNullToWhat = "NullsToEmptyString"
                gAuditNullFunction = "EmptyStringToNull"
                gFieldLength = maxlength
                gPHPNullFunction = "nullsql"
                gStrictly = "CStr"
            Case "System.Date", "System.DateTime"
                gType = "Date"
                gADType = "SqlDbType.DateTime"
                gSQLType = "DateTime"
                gNullToWhat = "NullsToZeroDate"
                gAuditNullToWhat = "NullsToEmptyString"
                gWhatToNull = "ZeroDateToDBNull"
                gAuditNullFunction = "NullsToEmptyString"
                gFieldLength = 8
                gPHPNullFunction = "nullsqldate"
                gStrictly = "CDate"
            Case "System.Bit", "System.Boolean"
                gType = "boolean"
                gADType = "SqlDbType.Bit"
                gSQLType = "bit"
                gNullToWhat = "NullsToZero"
                gAuditNullToWhat = "NullsToZero"
                gWhatToNull = "" 'empty string
                gAuditNullFunction = ""
                gFieldLength = 1
                gPHPNullFunction = "nullsql"
                gStrictly = "CBool"
            Case "System.Double", "System.Decimal"
                gType = "double"
                gADType = "SqlDbType.Float"
                gSQLType = "float"
                gNullToWhat = "NullsToZero"
                gAuditNullToWhat = "NullsToZero"
                gWhatToNull = "ZeroToNull"
                gAuditNullFunction = "ZeroToEmptyString"
                gFieldLength = 10
                gPHPNullFunction = "nullsql"
                gStrictly = "CDbl"
            Case "System.Int32"
                gType = "Long"
                gADType = "SqlDbType.Int"
                gSQLType = "Integer"
                gWhatToNull = "ZeroToNull"
                gAuditNullFunction = "ZeroToNull"
                gNullToWhat = "NullsToZero"
                gAuditNullToWhat = "NullsToZero"
                gFieldLength = 4
                gPHPNullFunction = "nullsql"
                gStrictly = "CLng"
            Case Else
                Stop
        End Select

    End Sub


End Class