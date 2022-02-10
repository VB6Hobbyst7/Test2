Module modAlignData

    Public Structure _tagAlignData
        Dim nTotalCnt As Integer
        Dim dX As Double
        Dim dY As Double
    End Structure

    Dim iAlarmTotalCnt As Integer = 0
    Dim _tAlarm() As _tagAlarm

    Dim strFilePath As String = ""

    'ini파일로 Data 읽어드리자.
    Public Function LoadAlarmFile() As Boolean

        '이거 우선? 하드코딩으로 넣어놓자.
        strFilePath = "C:\Chamfering System\Setting\AlarmList\DEFAULT.ini"

        iAlarmTotalCnt = ReadIni("TOTAL_COUNT_INFO", "TOTAL_COUNT", 0, strFilePath)

        '알람List Total Cnt를 넣어준다.
        ReDim _tAlarm(iAlarmTotalCnt)

        For i As Integer = 0 To iAlarmTotalCnt
            _tAlarm(i).strType = ReadIni("ALARM_LIST_INFO_" & i, "TYPE", "PC", strFilePath)
            _tAlarm(i).iAlarmNo = ReadIni("ALARM_LIST_INFO_" & i, "ALARM_NO", 0, strFilePath)
            _tAlarm(i).iAlarmCode = ReadIni("ALARM_LIST_INFO_" & i, "ALARM_CODE", 0, strFilePath)
            _tAlarm(i).strAlarmName = ReadIni("ALARM_LIST_INFO_" & i, "ALARM_NAME", "NONE", strFilePath)
            _tAlarm(i).strAlarmDescript = ReadIni("ALARM_LIST_INFO_" & i, "ALARM_DESCRIPT", "NONE", strFilePath)
            _tAlarm(i).strAlarmType = ReadIni("ALARM_LIST_INFO_" & i, "ALARM_TYPE", "NONE", strFilePath)
        Next

    End Function

    Public Function SaveAlarmFile() As Boolean

        '이거 우선? 하드코딩으로 넣어놓자.
        strFilePath = "C:\Chamfering System\Setting\AlarmList\DEFAULT.ini"

        WriteIni("TOTAL_COUNT_INFO", "TOTAL_COUNT", iAlarmTotalCnt, strFilePath)

        '알람List Total Cnt를 넣어준다.
        ReDim _tAlarm(iAlarmTotalCnt)

        For i As Integer = 0 To iAlarmTotalCnt
            WriteIni("ALARM_LIST_INFO_" & i, "TYPE", _tAlarm(i).strType, strFilePath)
            WriteIni("ALARM_LIST_INFO_" & i, "ALARM_NO", _tAlarm(i).iAlarmNo, strFilePath)
            WriteIni("ALARM_LIST_INFO_" & i, "ALARM_CODE", _tAlarm(i).iAlarmCode, strFilePath)
            WriteIni("ALARM_LIST_INFO_" & i, "ALARM_NAME", _tAlarm(i).strAlarmName, strFilePath)
            WriteIni("ALARM_LIST_INFO_" & i, "ALARM_DESCRIPT", _tAlarm(i).strAlarmDescript, strFilePath)
            WriteIni("ALARM_LIST_INFO_" & i, "ALARM_TYPE", _tAlarm(i).strAlarmType, strFilePath)
        Next

    End Function

    Public Function GetAlarm(ByRef iAlarmCode As Integer, ByRef _Alarm As _tagAlarm) As Boolean

        For i As Integer = 0 To iAlarmTotalCnt

            If iAlarmCode = _tAlarm(i).iAlarmCode Then

                _Alarm = _tAlarm(i)

            End If

        Next

    End Function

End Module
