Imports System.Threading
Imports System.Runtime.InteropServices

Public Class clsRTC6

#Region "RTC6 Function"
    Const TableSize As Integer = 1024
    Const SampleArraySize As Integer = 1024 * 1024
    Const SignalSize As Integer = 4
    Const TransformSize As Integer = 132130
    Const SignalSize2 As Integer = 8

    Declare Function init_rtc6_dll Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Sub free_rtc6_dll Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_rtc4_mode Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_rtc5_mode Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_rtc6_mode Lib "RTC6DLLx64.DLL" ()
    Declare Function get_rtc_mode Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function n_get_error Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function n_get_last_error Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Sub n_reset_error Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Code As UInteger)
    Declare Function n_set_verify Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Verify As UInteger) As UInteger
    Declare Function get_error Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function get_last_error Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Sub reset_error Lib "RTC6DLLx64.DLL" (ByVal Code As UInteger)
    Declare Function set_verify Lib "RTC6DLLx64.DLL" (ByVal Verify As UInteger) As UInteger
    Declare Function verify_checksum Lib "RTC6DLLx64.DLL" (ByVal Name As String) As UInteger
    Declare Function RTC6_count_cards Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function acquire_rtc Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function release_rtc Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function select_rtc Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function get_dll_version Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function n_get_serial_number Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function n_get_hex_version Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function n_get_rtc_version Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function get_serial_number Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function get_hex_version Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function get_rtc_version Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function n_load_program_file Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Path As String) As UInteger
    Declare Sub n_sync_slaves Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Function n_get_sync_status Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function n_load_correction_file Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Name As String, ByVal No As UInteger, ByVal [Dim] As UInteger) As UInteger
    Declare Function n_load_z_table Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal A As Double, ByVal B As Double, ByVal C As Double) As UInteger
    Declare Sub n_select_cor_table Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadA As UInteger, ByVal HeadB As UInteger)
    Declare Function n_set_dsp_mode Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger) As UInteger
    Declare Function n_get_head_para Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal ParaNo As UInteger) As Double
    Declare Function n_get_table_para Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal TableNo As UInteger, ByVal ParaNo As UInteger) As Double
    Declare Function load_program_file Lib "RTC6DLLx64.DLL" (ByVal Path As String) As UInteger
    Declare Sub sync_slaves Lib "RTC6DLLx64.DLL" ()
    Declare Function get_sync_status Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function load_correction_file Lib "RTC6DLLx64.DLL" (ByVal Name As String, ByVal No As UInteger, ByVal [Dim] As UInteger) As UInteger
    Declare Function load_z_table Lib "RTC6DLLx64.DLL" (ByVal A As Double, ByVal B As Double, ByVal C As Double) As UInteger
    Declare Sub select_cor_table Lib "RTC6DLLx64.DLL" (ByVal HeadA As UInteger, ByVal HeadB As UInteger)
    Declare Function set_dsp_mode Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger) As UInteger
    Declare Function get_head_para Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal ParaNo As UInteger) As Double
    Declare Function get_table_para Lib "RTC6DLLx64.DLL" (ByVal TableNo As UInteger, ByVal ParaNo As UInteger) As Double
    Declare Sub n_config_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mem1 As UInteger, ByVal Mem2 As UInteger)
    Declare Sub n_get_config_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Function n_save_disk Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Name As String, ByVal Mode As UInteger) As UInteger
    Declare Function n_load_disk Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Name As String, ByVal Mode As UInteger) As UInteger
    Declare Function n_get_list_space Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Sub config_list Lib "RTC6DLLx64.DLL" (ByVal Mem1 As UInteger, ByVal Mem2 As UInteger)
    Declare Sub get_config_list Lib "RTC6DLLx64.DLL" ()
    Declare Function save_disk Lib "RTC6DLLx64.DLL" (ByVal Name As String, ByVal Mode As UInteger) As UInteger
    Declare Function load_disk Lib "RTC6DLLx64.DLL" (ByVal Name As String, ByVal Mode As UInteger) As UInteger
    Declare Function get_list_space Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Sub n_set_start_list_pos Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ListNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_set_start_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ListNo As UInteger)
    Declare Sub n_set_start_list_1 Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_set_start_list_2 Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_set_input_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Function n_load_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ListNo As UInteger, ByVal Pos As UInteger) As UInteger
    Declare Sub n_load_sub Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger)
    Declare Sub n_load_char Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal [Char] As UInteger)
    Declare Sub n_load_text_table Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger)
    Declare Sub n_get_list_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByRef ListNo As UInteger, ByRef Pos As UInteger)
    Declare Function n_get_input_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Sub set_start_list_pos Lib "RTC6DLLx64.DLL" (ByVal ListNo As UInteger, ByVal Pos As UInteger)
    Declare Sub set_start_list Lib "RTC6DLLx64.DLL" (ByVal ListNo As UInteger)
    Declare Sub set_start_list_1 Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_start_list_2 Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_input_pointer Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Function load_list Lib "RTC6DLLx64.DLL" (ByVal ListNo As UInteger, ByVal Pos As UInteger) As UInteger
    Declare Sub load_sub Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger)
    Declare Sub load_char Lib "RTC6DLLx64.DLL" (ByVal [Char] As UInteger)
    Declare Sub load_text_table Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger)
    Declare Sub get_list_pointer Lib "RTC6DLLx64.DLL" (ByRef ListNo As UInteger, ByRef Pos As UInteger)
    Declare Function get_input_pointer Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Sub n_execute_list_pos Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ListNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_execute_at_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_execute_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ListNo As UInteger)
    Declare Sub n_execute_list_1 Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_execute_list_2 Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_get_out_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByRef ListNo As UInteger, ByRef Pos As UInteger)
    Declare Sub execute_list_pos Lib "RTC6DLLx64.DLL" (ByVal ListNo As UInteger, ByVal Pos As UInteger)
    Declare Sub execute_at_pointer Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Sub execute_list Lib "RTC6DLLx64.DLL" (ByVal ListNo As UInteger)
    Declare Sub execute_list_1 Lib "RTC6DLLx64.DLL" ()
    Declare Sub execute_list_2 Lib "RTC6DLLx64.DLL" ()
    Declare Sub get_out_pointer Lib "RTC6DLLx64.DLL" (ByRef ListNo As UInteger, ByRef Pos As UInteger)
    Declare Sub n_auto_change_pos Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_start_loop Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_quit_loop Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_pause_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_restart_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_release_wait Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_stop_execution Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_auto_change Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_stop_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Function n_get_wait_status Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function n_read_status Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Sub n_get_status Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByRef Status As UInteger, ByRef Pos As UInteger)
    Declare Sub auto_change_pos Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Sub start_loop Lib "RTC6DLLx64.DLL" ()
    Declare Sub quit_loop Lib "RTC6DLLx64.DLL" ()
    Declare Sub pause_list Lib "RTC6DLLx64.DLL" ()
    Declare Sub restart_list Lib "RTC6DLLx64.DLL" ()
    Declare Sub release_wait Lib "RTC6DLLx64.DLL" ()
    Declare Sub stop_execution Lib "RTC6DLLx64.DLL" ()
    Declare Sub auto_change Lib "RTC6DLLx64.DLL" ()
    Declare Sub stop_list Lib "RTC6DLLx64.DLL" ()
    Declare Function get_wait_status Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function read_status Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Sub get_status Lib "RTC6DLLx64.DLL" (ByRef Status As UInteger, ByRef Pos As UInteger)
    Declare Sub n_set_extstartpos Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_set_max_counts Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Counts As UInteger)
    Declare Sub n_set_control_mode Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger)
    Declare Sub n_simulate_ext_stop Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_simulate_ext_start_ctrl Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Function n_get_counts Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function n_get_startstop_info Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Sub set_extstartpos Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Sub set_max_counts Lib "RTC6DLLx64.DLL" (ByVal Counts As UInteger)
    Declare Sub set_control_mode Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger)
    Declare Sub simulate_ext_stop Lib "RTC6DLLx64.DLL" ()
    Declare Sub simulate_ext_start_ctrl Lib "RTC6DLLx64.DLL" ()
    Declare Function get_counts Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function get_startstop_info Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Sub n_copy_dst_src Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Dst As UInteger, ByVal Src As UInteger, ByVal Mode As UInteger)
    Declare Sub n_set_char_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal [Char] As UInteger, ByVal Pos As UInteger)
    Declare Sub n_set_sub_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger, ByVal Pos As UInteger)
    Declare Sub n_set_text_table_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger, ByVal Pos As UInteger)
    Declare Sub n_set_char_table Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger, ByVal Pos As UInteger)
    Declare Function n_get_char_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal [Char] As UInteger) As UInteger
    Declare Function n_get_sub_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger) As UInteger
    Declare Function n_get_text_table_pointer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger) As UInteger
    Declare Sub copy_dst_src Lib "RTC6DLLx64.DLL" (ByVal Dst As UInteger, ByVal Src As UInteger, ByVal Mode As UInteger)
    Declare Sub set_char_pointer Lib "RTC6DLLx64.DLL" (ByVal [Char] As UInteger, ByVal Pos As UInteger)
    Declare Sub set_sub_pointer Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger, ByVal Pos As UInteger)
    Declare Sub set_text_table_pointer Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger, ByVal Pos As UInteger)
    Declare Sub set_char_table Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger, ByVal Pos As UInteger)
    Declare Function get_char_pointer Lib "RTC6DLLx64.DLL" (ByVal [Char] As UInteger) As UInteger
    Declare Function get_sub_pointer Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger) As UInteger
    Declare Function get_text_table_pointer Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger) As UInteger
    Declare Sub n_time_update Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_set_serial_step Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger, ByVal [Step] As UInteger)
    Declare Sub n_set_serial Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger)
    Declare Function n_get_serial Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As Double
    Declare Sub time_update Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_serial_step Lib "RTC6DLLx64.DLL" (ByVal No As UInteger, ByVal [Step] As UInteger)
    Declare Sub set_serial Lib "RTC6DLLx64.DLL" (ByVal No As UInteger)
    Declare Function get_serial Lib "RTC6DLLx64.DLL" () As Double
    Declare Sub n_write_io_port_mask Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As UInteger, ByVal Mask As UInteger)
    Declare Sub n_write_8bit_port Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As UInteger)
    Declare Function n_read_io_port Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function n_read_io_port_buffer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger, ByRef Value As UInteger, ByRef XPos As Integer, ByRef YPos As Integer, ByRef Time As UInteger) As UInteger
    Declare Function n_get_io_status Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function n_read_analog_in Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Sub n_write_da_x Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal x As UInteger, ByVal Value As UInteger)
    Declare Sub n_set_laser_off_default Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal AnalogOut1 As UInteger, ByVal AnalogOut2 As UInteger, ByVal DigitalOut As UInteger)
    Declare Sub n_set_port_default Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Port As UInteger, ByVal Value As UInteger)
    Declare Sub n_write_io_port Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As UInteger)
    Declare Sub n_write_da_1 Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As UInteger)
    Declare Sub n_write_da_2 Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As UInteger)
    Declare Sub write_io_port_mask Lib "RTC6DLLx64.DLL" (ByVal Value As UInteger, ByVal Mask As UInteger)
    Declare Sub write_8bit_port Lib "RTC6DLLx64.DLL" (ByVal Value As UInteger)
    Declare Function read_io_port Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function read_io_port_buffer Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger, ByRef Value As UInteger, ByRef XPos As Integer, ByRef YPos As Integer, ByRef Time As UInteger) As UInteger
    Declare Function get_io_status Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function read_analog_in Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Sub write_da_x Lib "RTC6DLLx64.DLL" (ByVal x As UInteger, ByVal Value As UInteger)
    Declare Sub set_laser_off_default Lib "RTC6DLLx64.DLL" (ByVal AnalogOut1 As UInteger, ByVal AnalogOut2 As UInteger, ByVal DigitalOut As UInteger)
    Declare Sub set_port_default Lib "RTC6DLLx64.DLL" (ByVal Port As UInteger, ByVal Value As UInteger)
    Declare Sub write_io_port Lib "RTC6DLLx64.DLL" (ByVal Value As UInteger)
    Declare Sub write_da_1 Lib "RTC6DLLx64.DLL" (ByVal Value As UInteger)
    Declare Sub write_da_2 Lib "RTC6DLLx64.DLL" (ByVal Value As UInteger)
    Declare Sub n_disable_laser Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_enable_laser Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_laser_signal_on Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_laser_signal_off Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_set_standby Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HalfPeriod As UInteger, ByVal PulseLength As UInteger)
    Declare Sub n_set_laser_pulses_ctrl Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HalfPeriod As UInteger, ByVal PulseLength As UInteger)
    Declare Sub n_set_firstpulse_killer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Length As UInteger)
    Declare Sub n_set_qswitch_delay Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Delay As UInteger)
    Declare Sub n_set_laser_mode Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger)
    Declare Sub n_set_laser_control Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Ctrl As UInteger)
    Declare Sub n_set_laser_pin_out Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pins As UInteger)
    Declare Function n_get_laser_pin_in Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Sub n_set_softstart_level Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger, ByVal Level As UInteger)
    Declare Sub n_set_softstart_mode Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger, ByVal Number As UInteger, ByVal Delay As UInteger)
    Declare Function n_set_auto_laser_control Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Ctrl As UInteger, ByVal Value As UInteger, ByVal Mode As UInteger, ByVal MinValue As UInteger, ByVal MaxValue As UInteger) As UInteger
    Declare Function n_set_auto_laser_params Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Ctrl As UInteger, ByVal Value As UInteger, ByVal MinValue As UInteger, ByVal MaxValue As UInteger) As UInteger
    Declare Function n_load_auto_laser_control Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Name As String, ByVal No As UInteger) As Integer
    Declare Function n_load_position_control Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Name As String, ByVal No As UInteger) As Integer
    Declare Sub n_set_default_pixel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal PulseLength As UInteger)
    Declare Sub n_get_standby Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByRef HalfPeriod As UInteger, ByRef PulseLength As UInteger)
    Declare Sub n_set_pulse_picking Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger)
    Declare Sub n_set_pulse_picking_length Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Length As UInteger)
    Declare Sub n_config_laser_signals Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Config As UInteger)
    Declare Sub disable_laser Lib "RTC6DLLx64.DLL" ()
    Declare Sub enable_laser Lib "RTC6DLLx64.DLL" ()
    Declare Sub laser_signal_on Lib "RTC6DLLx64.DLL" ()
    Declare Sub laser_signal_off Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_standby Lib "RTC6DLLx64.DLL" (ByVal HalfPeriod As UInteger, ByVal PulseLength As UInteger)
    Declare Sub set_laser_pulses_ctrl Lib "RTC6DLLx64.DLL" (ByVal HalfPeriod As UInteger, ByVal PulseLength As UInteger)
    Declare Sub set_firstpulse_killer Lib "RTC6DLLx64.DLL" (ByVal Length As UInteger)
    Declare Sub set_qswitch_delay Lib "RTC6DLLx64.DLL" (ByVal Delay As UInteger)
    Declare Sub set_laser_mode Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger)
    Declare Sub set_laser_control Lib "RTC6DLLx64.DLL" (ByVal Ctrl As UInteger)
    Declare Sub set_laser_pin_out Lib "RTC6DLLx64.DLL" (ByVal Pins As UInteger)
    Declare Function get_laser_pin_in Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Sub set_softstart_level Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger, ByVal Level As UInteger)
    Declare Sub set_softstart_mode Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger, ByVal Number As UInteger, ByVal Delay As UInteger)
    Declare Function set_auto_laser_control Lib "RTC6DLLx64.DLL" (ByVal Ctrl As UInteger, ByVal Value As UInteger, ByVal Mode As UInteger, ByVal MinValue As UInteger, ByVal MaxValue As UInteger) As UInteger
    Declare Function set_auto_laser_params Lib "RTC6DLLx64.DLL" (ByVal Ctrl As UInteger, ByVal Value As UInteger, ByVal MinValue As UInteger, ByVal MaxValue As UInteger) As UInteger
    Declare Function load_auto_laser_control Lib "RTC6DLLx64.DLL" (ByVal Name As String, ByVal No As UInteger) As Integer
    Declare Function load_position_control Lib "RTC6DLLx64.DLL" (ByVal Name As String, ByVal No As UInteger) As Integer
    Declare Sub set_default_pixel Lib "RTC6DLLx64.DLL" (ByVal PulseLength As UInteger)
    Declare Sub get_standby Lib "RTC6DLLx64.DLL" (ByRef HalfPeriod As UInteger, ByRef PulseLength As UInteger)
    Declare Sub set_pulse_picking Lib "RTC6DLLx64.DLL" (ByVal No As UInteger)
    Declare Sub set_pulse_picking_length Lib "RTC6DLLx64.DLL" (ByVal Length As UInteger)
    Declare Sub config_laser_signals Lib "RTC6DLLx64.DLL" (ByVal Config As UInteger)
    Declare Sub n_set_ext_start_delay Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Delay As Integer, ByVal EncoderNo As UInteger)
    Declare Sub n_set_rot_center Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer)
    Declare Sub n_simulate_encoder Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal EncoderNo As UInteger)
    Declare Function n_get_marking_info Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Sub n_set_encoder_speed_ctrl Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal EncoderNo As UInteger, ByVal Speed As Double, ByVal Smooth As Double)
    Declare Sub n_set_mcbsp_x Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ScaleX As Double)
    Declare Sub n_set_mcbsp_y Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ScaleY As Double)
    Declare Sub n_set_mcbsp_rot Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Resolution As Double)
    Declare Sub n_set_mcbsp_matrix Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_set_mcbsp_in Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger, ByVal Scale As Double)
    Declare Sub n_set_fly_tracking_error Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal TrackingErrorX As UInteger, ByVal TrackingErrorY As UInteger)
    Declare Sub n_get_encoder Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByRef Encoder0 As Integer, ByRef Encoder1 As Integer)
    Declare Sub n_read_encoder Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByRef Encoder0_1 As Integer, ByRef Encoder1_1 As Integer, ByRef Encoder0_2 As Integer, ByRef Encoder1_2 As Integer)
    Declare Function n_get_mcbsp Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As Integer
    Declare Function n_read_mcbsp Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger) As Integer
    Declare Sub set_ext_start_delay Lib "RTC6DLLx64.DLL" (ByVal Delay As Integer, ByVal EncoderNo As UInteger)
    Declare Sub set_rot_center Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer)
    Declare Sub simulate_encoder Lib "RTC6DLLx64.DLL" (ByVal EncoderNo As UInteger)
    Declare Function get_marking_info Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Sub set_encoder_speed_ctrl Lib "RTC6DLLx64.DLL" (ByVal EncoderNo As UInteger, ByVal Speed As Double, ByVal Smooth As Double)
    Declare Sub set_mcbsp_x Lib "RTC6DLLx64.DLL" (ByVal ScaleX As Double)
    Declare Sub set_mcbsp_y Lib "RTC6DLLx64.DLL" (ByVal ScaleY As Double)
    Declare Sub set_mcbsp_rot Lib "RTC6DLLx64.DLL" (ByVal Resolution As Double)
    Declare Sub set_mcbsp_matrix Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_mcbsp_in Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger, ByVal Scale As Double)
    Declare Sub set_fly_tracking_error Lib "RTC6DLLx64.DLL" (ByVal TrackingErrorX As UInteger, ByVal TrackingErrorY As UInteger)
    Declare Sub get_encoder Lib "RTC6DLLx64.DLL" (ByRef Encoder0 As Integer, ByRef Encoder1 As Integer)
    Declare Sub read_encoder Lib "RTC6DLLx64.DLL" (ByRef Encoder0_1 As Integer, ByRef Encoder1_1 As Integer, ByRef Encoder0_2 As Integer, ByRef Encoder1_2 As Integer)
    Declare Function get_mcbsp Lib "RTC6DLLx64.DLL" () As Integer
    Declare Function read_mcbsp Lib "RTC6DLLx64.DLL" (ByVal No As UInteger) As Integer
    Declare Function n_get_time Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As Double
    Declare Sub n_measurement_status Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByRef Busy As UInteger, ByRef Pos As UInteger)
    Declare Sub n_get_waveform Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Channel As UInteger, ByVal Number As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=SampleArraySize)> ByVal Ptr As Integer())
    Declare Sub n_bounce_supp Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Length As UInteger)
    Declare Sub n_home_position_xyz Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal XHome As Integer, ByVal YHome As Integer, ByVal ZHome As Integer)
    Declare Sub n_home_position Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal XHome As Integer, ByVal YHome As Integer)
    Declare Sub n_rs232_config Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal BaudRate As UInteger)
    Declare Sub n_rs232_write_data Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Data As UInteger)
    Declare Sub n_rs232_write_text Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal pData As String)
    Declare Function n_rs232_read_data Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function n_set_mcbsp_freq Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Freq As UInteger) As UInteger
    Declare Sub n_mcbsp_init Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal XDelay As UInteger, ByVal RDelay As UInteger)
    Declare Function n_get_overrun Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Function n_get_master_slave Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger) As UInteger
    Declare Sub n_get_transform Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Number As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=SampleArraySize)> ByVal Ptr1 As Integer(), <MarshalAs(UnmanagedType.LPArray, SizeConst:=SampleArraySize)> ByVal Ptr2 As Integer(), <MarshalAs(UnmanagedType.LPArray, SizeConst:=TransformSize)> ByVal Ptr As UInteger(), ByVal Code As UInteger)
    Declare Sub n_stop_trigger Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_move_to Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_set_enduring_wobbel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal CenterX As UInteger, ByVal CenterY As UInteger, ByVal CenterZ As UInteger, ByVal LimitHi As UInteger, ByVal LimitLo As UInteger, _
         ByVal ScaleX As Double, ByVal ScaleY As Double, ByVal ScaleZ As Double)
    Declare Sub n_set_free_variable Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal VarNo As UInteger, ByVal Value As UInteger)
    Declare Function n_get_free_variable Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal VarNo As UInteger) As UInteger
    Declare Sub n_set_mcbsp_out_ptr Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Number As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=SignalSize2)> ByVal SignalPtr As Integer())
    Declare Function get_time Lib "RTC6DLLx64.DLL" () As Double
    Declare Sub measurement_status Lib "RTC6DLLx64.DLL" (ByRef Busy As UInteger, ByRef Pos As UInteger)
    Declare Sub get_waveform Lib "RTC6DLLx64.DLL" (ByVal Channel As UInteger, ByVal Number As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=SampleArraySize)> ByVal Ptr As Integer())
    Declare Sub bounce_supp Lib "RTC6DLLx64.DLL" (ByVal Length As UInteger)
    Declare Sub home_position_xyz Lib "RTC6DLLx64.DLL" (ByVal XHome As Integer, ByVal YHome As Integer, ByVal ZHome As Integer)
    Declare Sub home_position Lib "RTC6DLLx64.DLL" (ByVal XHome As Integer, ByVal YHome As Integer)
    Declare Sub rs232_config Lib "RTC6DLLx64.DLL" (ByVal BaudRate As UInteger)
    Declare Sub rs232_write_data Lib "RTC6DLLx64.DLL" (ByVal Data As UInteger)
    Declare Sub rs232_write_text Lib "RTC6DLLx64.DLL" (ByVal pData As String)
    Declare Function rs232_read_data Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function set_mcbsp_freq Lib "RTC6DLLx64.DLL" (ByVal Freq As UInteger) As UInteger
    Declare Sub mcbsp_init Lib "RTC6DLLx64.DLL" (ByVal XDelay As UInteger, ByVal RDelay As UInteger)
    Declare Function get_overrun Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Function get_master_slave Lib "RTC6DLLx64.DLL" () As UInteger
    Declare Sub get_transform Lib "RTC6DLLx64.DLL" (ByVal Number As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=SampleArraySize)> ByVal Ptr1 As Integer(), <MarshalAs(UnmanagedType.LPArray, SizeConst:=SampleArraySize)> ByVal Ptr2 As Integer(), <MarshalAs(UnmanagedType.LPArray, SizeConst:=TransformSize)> ByVal Ptr As UInteger(), ByVal Code As UInteger)
    Declare Sub stop_trigger Lib "RTC6DLLx64.DLL" ()
    Declare Sub move_to Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Sub set_enduring_wobbel Lib "RTC6DLLx64.DLL" (ByVal CenterX As UInteger, ByVal CenterY As UInteger, ByVal CenterZ As UInteger, ByVal LimitHi As UInteger, ByVal LimitLo As UInteger, ByVal ScaleX As Double, _
         ByVal ScaleY As Double, ByVal ScaleZ As Double)
    Declare Sub set_free_variable Lib "RTC6DLLx64.DLL" (ByVal VarNo As UInteger, ByVal Value As UInteger)
    Declare Function get_free_variable Lib "RTC6DLLx64.DLL" (ByVal VarNo As UInteger) As UInteger
    Declare Sub set_mcbsp_out_ptr Lib "RTC6DLLx64.DLL" (ByVal Number As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=SignalSize2)> ByVal SignalPtr As Integer())
    Declare Sub n_set_defocus Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Shift As Integer)
    Declare Sub n_goto_xyz Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer)
    Declare Sub n_goto_xy Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer)
    Declare Function n_get_z_distance Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer) As Integer
    Declare Sub set_defocus Lib "RTC6DLLx64.DLL" (ByVal Shift As Integer)
    Declare Sub goto_xyz Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer)
    Declare Sub goto_xy Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer)
    Declare Function get_z_distance Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer) As Integer
    Declare Sub n_set_offset_xyz Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal XOffset As Integer, ByVal YOffset As Integer, ByVal ZOffset As Integer, ByVal at_once As UInteger)
    Declare Sub n_set_offset Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal XOffset As Integer, ByVal YOffset As Integer, ByVal at_once As UInteger)
    Declare Sub n_set_matrix Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal M11 As Double, ByVal M12 As Double, ByVal M21 As Double, ByVal M22 As Double, _
         ByVal at_once As UInteger)
    Declare Sub n_set_angle Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal Angle As Double, ByVal at_once As UInteger)
    Declare Sub n_set_scale Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal Scale As Double, ByVal at_once As UInteger)
    Declare Sub n_apply_mcbsp Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal at_once As UInteger)
    Declare Function n_upload_transform Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=TransformSize)> ByVal Ptr As UInteger()) As UInteger
    Declare Sub set_offset_xyz Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal XOffset As Integer, ByVal YOffset As Integer, ByVal ZOffset As Integer, ByVal at_once As UInteger)
    Declare Sub set_offset Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal XOffset As Integer, ByVal YOffset As Integer, ByVal at_once As UInteger)
    Declare Sub set_matrix Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal M11 As Double, ByVal M12 As Double, ByVal M21 As Double, ByVal M22 As Double, ByVal at_once As UInteger)
    Declare Sub set_angle Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal Angle As Double, ByVal at_once As UInteger)
    Declare Sub set_scale Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal Scale As Double, ByVal at_once As UInteger)
    Declare Sub apply_mcbsp Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal at_once As UInteger)
    Declare Function upload_transform Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=TransformSize)> ByVal Ptr As UInteger()) As UInteger
    Declare Function transform Lib "RTC6DLLx64.DLL" (ByRef Sig1 As Integer, ByRef Sig2 As Integer, <MarshalAs(UnmanagedType.LPArray, SizeConst:=TransformSize)> ByVal Ptr As UInteger(), ByVal Code As UInteger) As UInteger
    Declare Sub n_set_delay_mode Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal VarPoly As UInteger, ByVal DirectMove3D As UInteger, ByVal EdgeLevel As UInteger, ByVal MinJumpDelay As UInteger, ByVal JumpLengthLimit As UInteger)
    Declare Sub n_set_jump_speed_ctrl Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Speed As Double)
    Declare Sub n_set_mark_speed_ctrl Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Speed As Double)
    Declare Sub n_set_sky_writing_para Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Timelag As Double, ByVal LaserOnShift As Integer, ByVal Nprev As UInteger, ByVal Npost As UInteger)
    Declare Sub n_set_sky_writing_limit Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal CosAngle As Double)
    Declare Sub n_set_sky_writing_mode Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger)
    Declare Function n_load_varpolydelay Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Name As String, ByVal No As UInteger) As Integer
    Declare Sub n_set_hi Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal GalvoGainX As Double, ByVal GalvoGainY As Double, ByVal GalvoOffsetX As Integer, ByVal GalvoOffsetY As Integer)
    Declare Sub n_get_hi_pos Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByRef X1 As Integer, ByRef X2 As Integer, ByRef Y1 As Integer, ByRef Y2 As Integer)
    Declare Function n_auto_cal Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal Command As UInteger) As UInteger
    Declare Function n_get_auto_cal Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger) As UInteger
    Declare Sub n_set_sky_writing Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Timelag As Double, ByVal LaserOnShift As Integer)
    Declare Sub n_get_hi_data Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByRef X1 As Integer, ByRef X2 As Integer, ByRef Y1 As Integer, ByRef Y2 As Integer)
    Declare Sub set_delay_mode Lib "RTC6DLLx64.DLL" (ByVal VarPoly As UInteger, ByVal DirectMove3D As UInteger, ByVal EdgeLevel As UInteger, ByVal MinJumpDelay As UInteger, ByVal JumpLengthLimit As UInteger)
    Declare Sub set_jump_speed_ctrl Lib "RTC6DLLx64.DLL" (ByVal Speed As Double)
    Declare Sub set_mark_speed_ctrl Lib "RTC6DLLx64.DLL" (ByVal Speed As Double)
    Declare Sub set_sky_writing_para Lib "RTC6DLLx64.DLL" (ByVal Timelag As Double, ByVal LaserOnShift As Integer, ByVal Nprev As UInteger, ByVal Npost As UInteger)
    Declare Sub set_sky_writing_limit Lib "RTC6DLLx64.DLL" (ByVal CosAngle As Double)
    Declare Sub set_sky_writing_mode Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger)
    Declare Function load_varpolydelay Lib "RTC6DLLx64.DLL" (ByVal Name As String, ByVal No As UInteger) As Integer
    Declare Sub set_hi Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal GalvoGainX As Double, ByVal GalvoGainY As Double, ByVal GalvoOffsetX As Integer, ByVal GalvoOffsetY As Integer)
    Declare Sub get_hi_pos Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByRef X1 As Integer, ByRef X2 As Integer, ByRef Y1 As Integer, ByRef Y2 As Integer)
    Declare Function auto_cal Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal Command As UInteger) As UInteger
    Declare Function get_auto_cal Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger) As UInteger
    Declare Sub set_sky_writing Lib "RTC6DLLx64.DLL" (ByVal Timelag As Double, ByVal LaserOnShift As Integer)
    Declare Sub get_hi_data Lib "RTC6DLLx64.DLL" (ByRef X1 As Integer, ByRef X2 As Integer, ByRef Y1 As Integer, ByRef Y2 As Integer)
    Declare Sub n_send_user_data Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Head As UInteger, ByVal Axis As UInteger, ByVal Data0 As Integer, ByVal Data1 As Integer, ByVal Data2 As Integer, _
         ByVal Data3 As Integer, ByVal Data4 As Integer)
    Declare Function n_read_user_data Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Head As UInteger, ByVal Axis As UInteger, ByRef Data0 As Integer, ByRef Data1 As Integer, ByRef Data2 As Integer, _
         ByRef Data3 As Integer, ByRef Data4 As Integer) As Integer
    Declare Sub n_control_command Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Head As UInteger, ByVal Axis As UInteger, ByVal Data As UInteger)
    Declare Function n_get_value Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Signal As UInteger) As Integer
    Declare Sub n_get_values Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=SignalSize)> ByVal SignalPtr As UInteger(), <MarshalAs(UnmanagedType.LPArray, SizeConst:=SignalSize)> ByVal ResultPtr As Integer())
    Declare Function n_get_head_status Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Head As UInteger) As UInteger
    Declare Function n_set_jump_mode Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Flag As Integer, ByVal Length As UInteger, ByVal VA1 As Integer, ByVal VA2 As Integer, ByVal VB1 As Integer, _
         ByVal VB2 As Integer, ByVal JA1 As Integer, ByVal JA2 As Integer, ByVal JB1 As Integer, ByVal JB2 As Integer) As Integer
    Declare Function n_load_jump_table_offset Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Name As String, ByVal No As UInteger, ByVal PosAck As UInteger, ByVal Offset As Integer, ByVal MinDelay As UInteger, _
         ByVal MaxDelay As UInteger, ByVal ListPos As UInteger) As Integer
    Declare Function n_get_jump_table Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=TableSize)> ByVal Ptr As UShort()) As UInteger
    Declare Function n_set_jump_table Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, <MarshalAs(UnmanagedType.LPArray, SizeConst:=TableSize)> ByVal Ptr As UShort()) As UInteger
    Declare Function n_load_jump_table Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Name As String, ByVal No As UInteger, ByVal PosAck As UInteger, ByVal MinDelay As UInteger, ByVal MaxDelay As UInteger, _
         ByVal ListPos As UInteger) As Integer
    Declare Sub send_user_data Lib "RTC6DLLx64.DLL" (ByVal Head As UInteger, ByVal Axis As UInteger, ByVal Data0 As Integer, ByVal Data1 As Integer, ByVal Data2 As Integer, ByVal Data3 As Integer, _
         ByVal Data4 As Integer)
    Declare Function read_user_data Lib "RTC6DLLx64.DLL" (ByVal Head As UInteger, ByVal Axis As UInteger, ByRef Data0 As Integer, ByRef Data1 As Integer, ByRef Data2 As Integer, ByRef Data3 As Integer, _
         ByRef Data4 As Integer) As Integer
    Declare Sub control_command Lib "RTC6DLLx64.DLL" (ByVal Head As UInteger, ByVal Axis As UInteger, ByVal Data As UInteger)
    Declare Function get_value Lib "RTC6DLLx64.DLL" (ByVal Signal As UInteger) As Integer
    Declare Sub get_values Lib "RTC6DLLx64.DLL" (<MarshalAs(UnmanagedType.LPArray, SizeConst:=SignalSize)> ByVal SignalPtr As UInteger(), <MarshalAs(UnmanagedType.LPArray, SizeConst:=SignalSize)> ByVal ResultPtr As Integer())
    Declare Function get_head_status Lib "RTC6DLLx64.DLL" (ByVal Head As UInteger) As UInteger
    Declare Function set_jump_mode Lib "RTC6DLLx64.DLL" (ByVal Flag As Integer, ByVal Length As UInteger, ByVal VA1 As Integer, ByVal VA2 As Integer, ByVal VB1 As Integer, ByVal VB2 As Integer, _
         ByVal JA1 As Integer, ByVal JA2 As Integer, ByVal JB1 As Integer, ByVal JB2 As Integer) As Integer
    Declare Function load_jump_table_offset Lib "RTC6DLLx64.DLL" (ByVal Name As String, ByVal No As UInteger, ByVal PosAck As UInteger, ByVal Offset As Integer, ByVal MinDelay As UInteger, ByVal MaxDelay As UInteger, _
         ByVal ListPos As UInteger) As Integer
    Declare Function get_jump_table Lib "RTC6DLLx64.DLL" (<MarshalAs(UnmanagedType.LPArray, SizeConst:=TableSize)> ByVal Ptr As UShort()) As UInteger
    Declare Function set_jump_table Lib "RTC6DLLx64.DLL" (<MarshalAs(UnmanagedType.LPArray, SizeConst:=TableSize)> ByVal Ptr As UShort()) As UInteger
    Declare Function load_jump_table Lib "RTC6DLLx64.DLL" (ByVal Name As String, ByVal No As UInteger, ByVal PosAck As UInteger, ByVal MinDelay As UInteger, ByVal MaxDelay As UInteger, ByVal ListPos As UInteger) As Integer
    Declare Sub n_stepper_init Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger, ByVal Period As UInteger, ByVal Dir As Integer, ByVal Pos As Integer, ByVal Tol As UInteger, _
         ByVal Enable As UInteger, ByVal WaitTime As UInteger)
    Declare Sub n_stepper_enable Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Enable1 As Integer, ByVal Enable2 As Integer)
    Declare Sub n_stepper_control Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Period1 As Integer, ByVal Period2 As Integer)
    Declare Sub n_stepper_abs_no Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger, ByVal Pos As Integer, ByVal WaitTime As UInteger)
    Declare Sub n_stepper_rel_no Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger, ByVal dPos As Integer, ByVal WaitTime As UInteger)
    Declare Sub n_stepper_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos1 As Integer, ByVal Pos2 As Integer, ByVal WaitTime As UInteger)
    Declare Sub n_stepper_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dPos1 As Integer, ByVal dPos2 As Integer, ByVal WaitTime As UInteger)
    Declare Sub n_get_stepper_status Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByRef Status1 As UInteger, ByRef Pos1 As Integer, ByRef Status2 As UInteger, ByRef Pos2 As Integer)
    Declare Sub stepper_init Lib "RTC6DLLx64.DLL" (ByVal No As UInteger, ByVal Period As UInteger, ByVal Dir As Integer, ByVal Pos As Integer, ByVal Tol As UInteger, ByVal Enable As UInteger, _
         ByVal WaitTime As UInteger)
    Declare Sub stepper_enable Lib "RTC6DLLx64.DLL" (ByVal Enable1 As Integer, ByVal Enable2 As Integer)
    Declare Sub stepper_control Lib "RTC6DLLx64.DLL" (ByVal Period1 As Integer, ByVal Period2 As Integer)
    Declare Sub stepper_abs_no Lib "RTC6DLLx64.DLL" (ByVal No As UInteger, ByVal Pos As Integer, ByVal WaitTime As UInteger)
    Declare Sub stepper_rel_no Lib "RTC6DLLx64.DLL" (ByVal No As UInteger, ByVal dPos As Integer, ByVal WaitTime As UInteger)
    Declare Sub stepper_abs Lib "RTC6DLLx64.DLL" (ByVal Pos1 As Integer, ByVal Pos2 As Integer, ByVal WaitTime As UInteger)
    Declare Sub stepper_rel Lib "RTC6DLLx64.DLL" (ByVal dPos1 As Integer, ByVal dPos2 As Integer, ByVal WaitTime As UInteger)
    Declare Sub get_stepper_status Lib "RTC6DLLx64.DLL" (ByRef Status1 As UInteger, ByRef Pos1 As Integer, ByRef Status2 As UInteger, ByRef Pos2 As Integer)
    Declare Sub n_select_cor_table_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadA As UInteger, ByVal HeadB As UInteger)
    Declare Sub select_cor_table_list Lib "RTC6DLLx64.DLL" (ByVal HeadA As UInteger, ByVal HeadB As UInteger)
    Declare Sub n_list_nop Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_list_continue Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_long_delay Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Delay As UInteger)
    Declare Sub n_set_end_of_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_set_wait Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal WaitWord As UInteger)
    Declare Sub n_list_jump_pos Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_list_jump_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As Integer)
    Declare Sub n_set_list_jump Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Sub list_nop Lib "RTC6DLLx64.DLL" ()
    Declare Sub list_continue Lib "RTC6DLLx64.DLL" ()
    Declare Sub long_delay Lib "RTC6DLLx64.DLL" (ByVal Delay As UInteger)
    Declare Sub set_end_of_list Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_wait Lib "RTC6DLLx64.DLL" (ByVal WaitWord As UInteger)
    Declare Sub list_jump_pos Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Sub list_jump_rel Lib "RTC6DLLx64.DLL" (ByVal Pos As Integer)
    Declare Sub set_list_jump Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Sub n_set_extstartpos_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_set_control_mode_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger)
    Declare Sub n_simulate_ext_start Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Delay As Integer, ByVal EncoderNo As UInteger)
    Declare Sub set_extstartpos_list Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Sub set_control_mode_list Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger)
    Declare Sub simulate_ext_start Lib "RTC6DLLx64.DLL" (ByVal Delay As Integer, ByVal EncoderNo As UInteger)
    Declare Sub n_list_return Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_list_call Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_list_call_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_sub_call Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger)
    Declare Sub n_sub_call_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Index As UInteger)
    Declare Sub list_return Lib "RTC6DLLx64.DLL" ()
    Declare Sub list_call Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Sub list_call_abs Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Sub sub_call Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger)
    Declare Sub sub_call_abs Lib "RTC6DLLx64.DLL" (ByVal Index As UInteger)
    Declare Sub n_list_call_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Pos As UInteger)
    Declare Sub n_list_call_abs_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Pos As UInteger)
    Declare Sub n_sub_call_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Pos As UInteger)
    Declare Sub n_sub_call_abs_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Pos As UInteger)
    Declare Sub n_list_jump_pos_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Index As UInteger)
    Declare Sub n_list_jump_rel_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Index As Integer)
    Declare Sub n_if_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger)
    Declare Sub n_if_not_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger)
    Declare Sub n_if_pin_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger)
    Declare Sub n_if_not_pin_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger)
    Declare Sub n_switch_ioport Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal MaskBits As UInteger, ByVal ShiftBits As UInteger)
    Declare Sub n_list_jump_cond Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Pos As UInteger)
    Declare Sub list_call_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Pos As UInteger)
    Declare Sub list_call_abs_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Pos As UInteger)
    Declare Sub sub_call_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Index As UInteger)
    Declare Sub sub_call_abs_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Index As UInteger)
    Declare Sub list_jump_pos_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Pos As UInteger)
    Declare Sub list_jump_rel_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Pos As Integer)
    Declare Sub if_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger)
    Declare Sub if_not_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger)
    Declare Sub if_pin_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger)
    Declare Sub if_not_pin_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger)
    Declare Sub switch_ioport Lib "RTC6DLLx64.DLL" (ByVal MaskBits As UInteger, ByVal ShiftBits As UInteger)
    Declare Sub list_jump_cond Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Pos As UInteger)
    Declare Sub n_select_char_set Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger)
    Declare Sub n_mark_text Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Text As String)
    Declare Sub n_mark_text_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Text As String)
    Declare Sub n_mark_char Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal [Char] As UInteger)
    Declare Sub n_mark_char_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal [Char] As UInteger)
    Declare Sub select_char_set Lib "RTC6DLLx64.DLL" (ByVal No As UInteger)
    Declare Sub mark_text Lib "RTC6DLLx64.DLL" (ByVal Text As String)
    Declare Sub mark_text_abs Lib "RTC6DLLx64.DLL" (ByVal Text As String)
    Declare Sub mark_char Lib "RTC6DLLx64.DLL" (ByVal [Char] As UInteger)
    Declare Sub mark_char_abs Lib "RTC6DLLx64.DLL" (ByVal [Char] As UInteger)
    Declare Sub n_mark_serial Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger, ByVal Digits As UInteger)
    Declare Sub n_mark_serial_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger, ByVal Digits As UInteger)
    Declare Sub n_mark_date Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Part As UInteger, ByVal Mode As UInteger)
    Declare Sub n_mark_date_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Part As UInteger, ByVal Mode As UInteger)
    Declare Sub n_mark_time Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Part As UInteger, ByVal Mode As UInteger)
    Declare Sub n_mark_time_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Part As UInteger, ByVal Mode As UInteger)
    Declare Sub n_time_fix_f_off Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal FirstDay As UInteger, ByVal Offset As UInteger)
    Declare Sub n_time_fix_f Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal FirstDay As UInteger)
    Declare Sub n_time_fix Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub mark_serial Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger, ByVal Digits As UInteger)
    Declare Sub mark_serial_abs Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger, ByVal Digits As UInteger)
    Declare Sub mark_date Lib "RTC6DLLx64.DLL" (ByVal Part As UInteger, ByVal Mode As UInteger)
    Declare Sub mark_date_abs Lib "RTC6DLLx64.DLL" (ByVal Part As UInteger, ByVal Mode As UInteger)
    Declare Sub mark_time Lib "RTC6DLLx64.DLL" (ByVal Part As UInteger, ByVal Mode As UInteger)
    Declare Sub mark_time_abs Lib "RTC6DLLx64.DLL" (ByVal Part As UInteger, ByVal Mode As UInteger)
    Declare Sub time_fix_f_off Lib "RTC6DLLx64.DLL" (ByVal FirstDay As UInteger, ByVal Offset As UInteger)
    Declare Sub time_fix_f Lib "RTC6DLLx64.DLL" (ByVal FirstDay As UInteger)
    Declare Sub time_fix Lib "RTC6DLLx64.DLL" ()
    Declare Sub n_clear_io_cond_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Mask As UInteger)
    Declare Sub n_set_io_cond_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal Mask As UInteger)
    Declare Sub n_write_io_port_mask_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As UInteger, ByVal Mask As UInteger)
    Declare Sub n_write_8bit_port_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As UInteger)
    Declare Sub n_read_io_port_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_write_da_x_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal x As UInteger, ByVal Value As UInteger)
    Declare Sub n_write_io_port_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As UInteger)
    Declare Sub n_write_da_1_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As UInteger)
    Declare Sub n_write_da_2_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As UInteger)
    Declare Sub clear_io_cond_list Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal MaskClear As UInteger)
    Declare Sub set_io_cond_list Lib "RTC6DLLx64.DLL" (ByVal Mask1 As UInteger, ByVal Mask0 As UInteger, ByVal MaskSet As UInteger)
    Declare Sub write_io_port_mask_list Lib "RTC6DLLx64.DLL" (ByVal Value As UInteger, ByVal Mask As UInteger)
    Declare Sub write_8bit_port_list Lib "RTC6DLLx64.DLL" (ByVal Value As UInteger)
    Declare Sub read_io_port_list Lib "RTC6DLLx64.DLL" ()
    Declare Sub write_da_x_list Lib "RTC6DLLx64.DLL" (ByVal x As UInteger, ByVal Value As UInteger)
    Declare Sub write_io_port_list Lib "RTC6DLLx64.DLL" (ByVal Value As UInteger)
    Declare Sub write_da_1_list Lib "RTC6DLLx64.DLL" (ByVal Value As UInteger)
    Declare Sub write_da_2_list Lib "RTC6DLLx64.DLL" (ByVal Value As UInteger)
    Declare Sub n_laser_signal_on_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_laser_signal_off_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_para_laser_on_pulses_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Period As UInteger, ByVal Pulses As UInteger, ByVal P As UInteger)
    Declare Sub n_laser_on_pulses_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Period As UInteger, ByVal Pulses As UInteger)
    Declare Sub n_laser_on_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Period As UInteger)
    Declare Sub n_set_laser_delays Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal LaserOnDelay As Integer, ByVal LaserOffDelay As UInteger)
    Declare Sub n_set_standby_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HalfPeriod As UInteger, ByVal PulseLength As UInteger)
    Declare Sub n_set_laser_pulses Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HalfPeriod As UInteger, ByVal PulseLength As UInteger)
    Declare Sub n_set_firstpulse_killer_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Length As UInteger)
    Declare Sub n_set_qswitch_delay_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Delay As UInteger)
    Declare Sub n_set_laser_pin_out_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pins As UInteger)
    Declare Sub n_set_vector_control Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Ctrl As UInteger, ByVal Value As UInteger)
    Declare Sub n_set_default_pixel_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal PulseLength As UInteger)
    Declare Sub n_set_auto_laser_params_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Ctrl As UInteger, ByVal Value As UInteger, ByVal MinValue As UInteger, ByVal MaxValue As UInteger)
    Declare Sub n_set_pulse_picking_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger)
    Declare Sub n_set_laser_timing Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HalfPeriod As UInteger, ByVal PulseLength1 As UInteger, ByVal PulseLength2 As UInteger, ByVal TimeBase As UInteger)
    Declare Sub laser_signal_on_list Lib "RTC6DLLx64.DLL" ()
    Declare Sub laser_signal_off_list Lib "RTC6DLLx64.DLL" ()
    Declare Sub para_laser_on_pulses_list Lib "RTC6DLLx64.DLL" (ByVal Period As UInteger, ByVal Pulses As UInteger, ByVal P As UInteger)
    Declare Sub laser_on_pulses_list Lib "RTC6DLLx64.DLL" (ByVal Period As UInteger, ByVal Pulses As UInteger)
    Declare Sub laser_on_list Lib "RTC6DLLx64.DLL" (ByVal Period As UInteger)
    Declare Sub set_laser_delays Lib "RTC6DLLx64.DLL" (ByVal LaserOnDelay As Integer, ByVal LaserOffDelay As UInteger)
    Declare Sub set_standby_list Lib "RTC6DLLx64.DLL" (ByVal HalfPeriod As UInteger, ByVal PulseLength As UInteger)
    Declare Sub set_laser_pulses Lib "RTC6DLLx64.DLL" (ByVal HalfPeriod As UInteger, ByVal PulseLength As UInteger)
    Declare Sub set_firstpulse_killer_list Lib "RTC6DLLx64.DLL" (ByVal Length As UInteger)
    Declare Sub set_qswitch_delay_list Lib "RTC6DLLx64.DLL" (ByVal Delay As UInteger)
    Declare Sub set_laser_pin_out_list Lib "RTC6DLLx64.DLL" (ByVal Pins As UInteger)
    Declare Sub set_vector_control Lib "RTC6DLLx64.DLL" (ByVal Ctrl As UInteger, ByVal Value As UInteger)
    Declare Sub set_default_pixel_list Lib "RTC6DLLx64.DLL" (ByVal PulseLength As UInteger)
    Declare Sub set_auto_laser_params_list Lib "RTC6DLLx64.DLL" (ByVal Ctrl As UInteger, ByVal Value As UInteger, ByVal MinValue As UInteger, ByVal MaxValue As UInteger)
    Declare Sub set_pulse_picking_list Lib "RTC6DLLx64.DLL" (ByVal No As UInteger)
    Declare Sub set_laser_timing Lib "RTC6DLLx64.DLL" (ByVal HalfPeriod As UInteger, ByVal PulseLength1 As UInteger, ByVal PulseLength2 As UInteger, ByVal TimeBase As UInteger)
    Declare Sub n_fly_return_z Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer)
    Declare Sub n_fly_return Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer)
    Declare Sub n_set_rot_center_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer)
    Declare Sub n_set_ext_start_delay_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Delay As Integer, ByVal EncoderNo As UInteger)
    Declare Sub n_set_fly_x Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ScaleX As Double)
    Declare Sub n_set_fly_y Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ScaleY As Double)
    Declare Sub n_set_fly_z Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ScaleZ As Double, ByVal EndoderNo As UInteger)
    Declare Sub n_set_fly_rot Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Resolution As Double)
    Declare Sub n_set_fly_x_pos Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ScaleX As Double)
    Declare Sub n_set_fly_y_pos Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ScaleY As Double)
    Declare Sub n_set_fly_rot_pos Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Resolution As Double)
    Declare Sub n_set_fly_limits Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Xmin As Integer, ByVal Xmax As Integer, ByVal Ymin As Integer, ByVal Ymax As Integer)
    Declare Sub n_set_fly_limits_z Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Zmin As Integer, ByVal Zmax As Integer)
    Declare Sub n_if_fly_x_overflow Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As Integer)
    Declare Sub n_if_fly_y_overflow Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As Integer)
    Declare Sub n_if_fly_z_overflow Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As Integer)
    Declare Sub n_if_not_fly_x_overflow Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As Integer)
    Declare Sub n_if_not_fly_y_overflow Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As Integer)
    Declare Sub n_if_not_fly_z_overflow Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As Integer)
    Declare Sub n_clear_fly_overflow Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger)
    Declare Sub n_set_mcbsp_x_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ScaleX As Double)
    Declare Sub n_set_mcbsp_y_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal ScaleY As Double)
    Declare Sub n_set_mcbsp_rot_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Resolution As Double)
    Declare Sub n_set_mcbsp_matrix_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_set_mcbsp_in_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger, ByVal Scale As Double)
    Declare Sub n_wait_for_encoder_mode Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As Integer, ByVal EncoderNo As UInteger, ByVal Mode As Integer)
    Declare Sub n_wait_for_mcbsp Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Axis As UInteger, ByVal Value As Integer, ByVal Mode As Integer)
    Declare Sub n_set_encoder_speed Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal EncoderNo As UInteger, ByVal Speed As Double, ByVal Smooth As Double)
    Declare Sub n_get_mcbsp_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_store_encoder Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos As UInteger)
    Declare Sub n_wait_for_encoder Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Value As Integer, ByVal EncoderNo As UInteger)
    Declare Sub fly_return_z Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer)
    Declare Sub fly_return Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer)
    Declare Sub set_rot_center_list Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer)
    Declare Sub set_ext_start_delay_list Lib "RTC6DLLx64.DLL" (ByVal Delay As Integer, ByVal EncoderNo As UInteger)
    Declare Sub set_fly_x Lib "RTC6DLLx64.DLL" (ByVal ScaleX As Double)
    Declare Sub set_fly_y Lib "RTC6DLLx64.DLL" (ByVal ScaleY As Double)
    Declare Sub set_fly_z Lib "RTC6DLLx64.DLL" (ByVal ScaleZ As Double, ByVal EncoderNo As UInteger)
    Declare Sub set_fly_rot Lib "RTC6DLLx64.DLL" (ByVal Resolution As Double)
    Declare Sub set_fly_x_pos Lib "RTC6DLLx64.DLL" (ByVal ScaleX As Double)
    Declare Sub set_fly_y_pos Lib "RTC6DLLx64.DLL" (ByVal ScaleY As Double)
    Declare Sub set_fly_rot_pos Lib "RTC6DLLx64.DLL" (ByVal Resolution As Double)
    Declare Sub set_fly_limits Lib "RTC6DLLx64.DLL" (ByVal Xmin As Integer, ByVal Xmax As Integer, ByVal Ymin As Integer, ByVal Ymax As Integer)
    Declare Sub set_fly_limits_z Lib "RTC6DLLx64.DLL" (ByVal Zmin As Integer, ByVal Zmax As Integer)
    Declare Sub if_fly_x_overflow Lib "RTC6DLLx64.DLL" (ByVal Mode As Integer)
    Declare Sub if_fly_y_overflow Lib "RTC6DLLx64.DLL" (ByVal Mode As Integer)
    Declare Sub if_fly_z_overflow Lib "RTC6DLLx64.DLL" (ByVal Mode As Integer)
    Declare Sub if_not_fly_x_overflow Lib "RTC6DLLx64.DLL" (ByVal Mode As Integer)
    Declare Sub if_not_fly_y_overflow Lib "RTC6DLLx64.DLL" (ByVal Mode As Integer)
    Declare Sub if_not_fly_z_overflow Lib "RTC6DLLx64.DLL" (ByVal Mode As Integer)
    Declare Sub clear_fly_overflow Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger)
    Declare Sub set_mcbsp_x_list Lib "RTC6DLLx64.DLL" (ByVal ScaleX As Double)
    Declare Sub set_mcbsp_y_list Lib "RTC6DLLx64.DLL" (ByVal ScaleY As Double)
    Declare Sub set_mcbsp_rot_list Lib "RTC6DLLx64.DLL" (ByVal Resolution As Double)
    Declare Sub set_mcbsp_matrix_list Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_mcbsp_in_list Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger, ByVal Scale As Double)
    Declare Sub wait_for_encoder_mode Lib "RTC6DLLx64.DLL" (ByVal Value As Integer, ByVal EncoderNo As UInteger, ByVal Mode As Integer)
    Declare Sub wait_for_mcbsp Lib "RTC6DLLx64.DLL" (ByVal Axis As UInteger, ByVal Value As Integer, ByVal Mode As Integer)
    Declare Sub set_encoder_speed Lib "RTC6DLLx64.DLL" (ByVal EncoderNo As UInteger, ByVal Speed As Double, ByVal Smooth As Double)
    Declare Sub get_mcbsp_list Lib "RTC6DLLx64.DLL" ()
    Declare Sub store_encoder Lib "RTC6DLLx64.DLL" (ByVal Pos As UInteger)
    Declare Sub wait_for_encoder Lib "RTC6DLLx64.DLL" (ByVal Value As Integer, ByVal EncoderNo As UInteger)
    Declare Sub n_save_and_restart_timer Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub n_set_wobbel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Transversal As UInteger, ByVal Longitudinal As UInteger, ByVal Freq As Double)
    Declare Sub n_set_wobbel_mode Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Transversal As UInteger, ByVal Longitudinal As UInteger, ByVal Freq As Double, ByVal Mode As Integer)
    Declare Sub n_set_trigger Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Period As UInteger, ByVal Signal1 As UInteger, ByVal Signal2 As UInteger)
    Declare Sub n_set_pixel_line Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Channel As UInteger, ByVal HalfPeriod As UInteger, ByVal dX As Double, ByVal dY As Double)
    Declare Sub n_set_n_pixel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal PulseLength As UInteger, ByVal AnalogOut As UInteger, ByVal Number As UInteger)
    Declare Sub n_set_pixel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal PulseLength As UInteger, ByVal AnalogOut As UInteger)
    Declare Sub n_rs232_write_text_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal pData As String)
    Declare Sub n_set_mcbsp_out Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Signal1 As UInteger, ByVal Signal2 As UInteger)
    Declare Sub n_camming Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal FirstPos As UInteger, ByVal NPos As UInteger, ByVal No As UInteger, ByVal Ctrl As UInteger, ByVal Scale As Double, _
         ByVal Code As UInteger)
    Declare Sub n_micro_vector_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal LasOn As Integer, ByVal LasOf As Integer)
    Declare Sub n_micro_vector_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal LasOn As Integer, ByVal LasOf As Integer)
    Declare Sub n_set_free_variable_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal VarNo As UInteger, ByVal Value As UInteger)
    Declare Sub save_and_restart_timer Lib "RTC6DLLx64.DLL" ()
    Declare Sub set_wobbel Lib "RTC6DLLx64.DLL" (ByVal Transversal As UInteger, ByVal Longitudinal As UInteger, ByVal Freq As Double)
    Declare Sub set_wobbel_mode Lib "RTC6DLLx64.DLL" (ByVal Transversal As UInteger, ByVal Longitudinal As UInteger, ByVal Freq As Double, ByVal Mode As Integer)
    Declare Sub set_trigger Lib "RTC6DLLx64.DLL" (ByVal Period As UInteger, ByVal Signal1 As UInteger, ByVal Signal2 As UInteger)
    Declare Sub set_pixel_line Lib "RTC6DLLx64.DLL" (ByVal Channel As UInteger, ByVal HalfPeriod As UInteger, ByVal dX As Double, ByVal dY As Double)
    Declare Sub set_n_pixel Lib "RTC6DLLx64.DLL" (ByVal PulseLength As UInteger, ByVal AnalogOut As UInteger, ByVal Number As UInteger)
    Declare Sub set_pixel Lib "RTC6DLLx64.DLL" (ByVal PulseLength As UInteger, ByVal AnalogOut As UInteger)
    Declare Sub rs232_write_text_list Lib "RTC6DLLx64.DLL" (ByVal pData As String)
    Declare Sub set_mcbsp_out Lib "RTC6DLLx64.DLL" (ByVal Signal1 As UInteger, ByVal Signal2 As UInteger)
    Declare Sub camming Lib "RTC6DLLx64.DLL" (ByVal FirstPos As UInteger, ByVal NPos As UInteger, ByVal No As UInteger, ByVal Ctrl As UInteger, ByVal Scale As Double, ByVal Code As UInteger)
    Declare Sub micro_vector_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal LasOn As Integer, ByVal LasOf As Integer)
    Declare Sub micro_vector_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal LasOn As Integer, ByVal LasOf As Integer)
    Declare Sub set_free_variable_list Lib "RTC6DLLx64.DLL" (ByVal VarNo As UInteger, ByVal Value As UInteger)
    Declare Sub n_timed_mark_abs_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal T As Double)
    Declare Sub n_timed_mark_rel_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal T As Double)
    Declare Sub n_timed_mark_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal T As Double)
    Declare Sub n_timed_mark_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal T As Double)
    Declare Sub timed_mark_abs_3d Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal T As Double)
    Declare Sub timed_mark_rel_3d Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal T As Double)
    Declare Sub timed_mark_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal T As Double)
    Declare Sub timed_mark_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal T As Double)
    Declare Sub n_mark_abs_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer)
    Declare Sub n_mark_rel_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer)
    Declare Sub n_mark_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer)
    Declare Sub n_mark_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer)
    Declare Sub mark_abs_3d Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer)
    Declare Sub mark_rel_3d Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer)
    Declare Sub mark_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer)
    Declare Sub mark_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer)
    Declare Sub n_timed_jump_abs_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal T As Double)
    Declare Sub n_timed_jump_rel_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal T As Double)
    Declare Sub n_timed_jump_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal T As Double)
    Declare Sub n_timed_jump_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal T As Double)
    Declare Sub timed_jump_abs_3d Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal T As Double)
    Declare Sub timed_jump_rel_3d Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal T As Double)
    Declare Sub timed_jump_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal T As Double)
    Declare Sub timed_jump_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal T As Double)
    Declare Sub n_jump_abs_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer)
    Declare Sub n_jump_rel_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer)
    Declare Sub n_jump_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer)
    Declare Sub n_jump_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer)
    Declare Sub jump_abs_3d Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer)
    Declare Sub jump_rel_3d Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer)
    Declare Sub jump_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer)
    Declare Sub jump_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer)
    Declare Sub n_para_mark_abs_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal P As UInteger)
    Declare Sub n_para_mark_rel_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal P As UInteger)
    Declare Sub n_para_mark_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal P As UInteger)
    Declare Sub n_para_mark_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal P As UInteger)
    Declare Sub para_mark_abs_3d Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal P As UInteger)
    Declare Sub para_mark_rel_3d Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal P As UInteger)
    Declare Sub para_mark_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal P As UInteger)
    Declare Sub para_mark_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal P As UInteger)
    Declare Sub n_para_jump_abs_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal P As UInteger)
    Declare Sub n_para_jump_rel_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal P As UInteger)
    Declare Sub n_para_jump_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal P As UInteger)
    Declare Sub n_para_jump_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal P As UInteger)
    Declare Sub para_jump_abs_3d Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal P As UInteger)
    Declare Sub para_jump_rel_3d Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal P As UInteger)
    Declare Sub para_jump_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal P As UInteger)
    Declare Sub para_jump_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal P As UInteger)
    Declare Sub n_timed_para_mark_abs_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub n_timed_para_mark_rel_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub n_timed_para_jump_abs_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub n_timed_para_jump_rel_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub n_timed_para_mark_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub n_timed_para_mark_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub n_timed_para_jump_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub n_timed_para_jump_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub timed_para_mark_abs_3d Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub timed_para_mark_rel_3d Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub timed_para_jump_abs_3d Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub timed_para_jump_rel_3d Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub timed_para_mark_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub timed_para_mark_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub timed_para_jump_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub timed_para_jump_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal P As UInteger, ByVal T As Double)
    Declare Sub n_set_defocus_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Shift As Integer)
    Declare Sub set_defocus_list Lib "RTC6DLLx64.DLL" (ByVal Shift As Integer)
    Declare Sub n_timed_arc_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Angle As Double, ByVal T As Double)
    Declare Sub n_timed_arc_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal Angle As Double, ByVal T As Double)
    Declare Sub timed_arc_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Angle As Double, ByVal T As Double)
    Declare Sub timed_arc_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal Angle As Double, ByVal T As Double)
    Declare Sub n_arc_abs_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal Angle As Double)
    Declare Sub n_arc_rel_3d Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal Angle As Double)
    Declare Sub n_arc_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Angle As Double)
    Declare Sub n_arc_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal Angle As Double)
    Declare Sub n_set_ellipse Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal A As UInteger, ByVal B As UInteger, ByVal Phi0 As Double, ByVal Phi As Double)
    Declare Sub n_mark_ellipse_abs Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal X As Integer, ByVal Y As Integer, ByVal Alpha As Double)
    Declare Sub n_mark_ellipse_rel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dX As Integer, ByVal dY As Integer, ByVal Alpha As Double)
    Declare Sub arc_abs_3d Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer, ByVal Angle As Double)
    Declare Sub arc_rel_3d Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal dZ As Integer, ByVal Angle As Double)
    Declare Sub arc_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Angle As Double)
    Declare Sub arc_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal Angle As Double)
    Declare Sub set_ellipse Lib "RTC6DLLx64.DLL" (ByVal A As UInteger, ByVal B As UInteger, ByVal Phi0 As Double, ByVal Phi As Double)
    Declare Sub mark_ellipse_abs Lib "RTC6DLLx64.DLL" (ByVal X As Integer, ByVal Y As Integer, ByVal Alpha As Double)
    Declare Sub mark_ellipse_rel Lib "RTC6DLLx64.DLL" (ByVal dX As Integer, ByVal dY As Integer, ByVal Alpha As Double)
    Declare Sub n_set_offset_xyz_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal XOffset As Integer, ByVal YOffset As Integer, ByVal ZOffset As Integer, ByVal at_once As UInteger)
    Declare Sub n_set_offset_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal XOffset As Integer, ByVal YOffset As Integer, ByVal at_once As UInteger)
    Declare Sub n_set_matrix_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal Ind1 As UInteger, ByVal Ind2 As UInteger, ByVal Mij As Double, ByVal at_once As UInteger)
    Declare Sub n_set_angle_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal Angle As Double, ByVal at_once As UInteger)
    Declare Sub n_set_scale_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal Scale As Double, ByVal at_once As UInteger)
    Declare Sub n_apply_mcbsp_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal HeadNo As UInteger, ByVal at_once As UInteger)
    Declare Sub set_offset_xyz_list Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal XOffset As Integer, ByVal YOffset As Integer, ByVal ZOffset As Integer, ByVal at_once As UInteger)
    Declare Sub set_offset_list Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal XOffset As Integer, ByVal YOffset As Integer, ByVal at_once As UInteger)
    Declare Sub set_matrix_list Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal Ind1 As UInteger, ByVal Ind2 As UInteger, ByVal Mij As Double, ByVal at_once As UInteger)
    Declare Sub set_angle_list Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal Angle As Double, ByVal at_once As UInteger)
    Declare Sub set_scale_list Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal Scale As Double, ByVal at_once As UInteger)
    Declare Sub apply_mcbsp_list Lib "RTC6DLLx64.DLL" (ByVal HeadNo As UInteger, ByVal at_once As UInteger)
    Declare Sub n_set_mark_speed Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Speed As Double)
    Declare Sub n_set_jump_speed Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Speed As Double)
    Declare Sub n_set_sky_writing_para_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Timelag As Double, ByVal LaserOnShift As Integer, ByVal Nprev As UInteger, ByVal Npost As UInteger)
    Declare Sub n_set_sky_writing_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Timelag As Double, ByVal LaserOnShift As Integer)
    Declare Sub n_set_sky_writing_limit_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal CosAngle As Double)
    Declare Sub n_set_sky_writing_mode_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Mode As UInteger)
    Declare Sub n_set_scanner_delays Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Jump As UInteger, ByVal Mark As UInteger, ByVal Polygon As UInteger)
    Declare Sub n_set_jump_mode_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Flag As Integer)
    Declare Sub n_enduring_wobbel Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger)
    Declare Sub set_mark_speed Lib "RTC6DLLx64.DLL" (ByVal Speed As Double)
    Declare Sub set_jump_speed Lib "RTC6DLLx64.DLL" (ByVal Speed As Double)
    Declare Sub set_sky_writing_para_list Lib "RTC6DLLx64.DLL" (ByVal Timelag As Double, ByVal LaserOnShift As Integer, ByVal Nprev As UInteger, ByVal Npost As UInteger)
    Declare Sub set_sky_writing_list Lib "RTC6DLLx64.DLL" (ByVal Timelag As Double, ByVal LaserOnShift As Integer)
    Declare Sub set_sky_writing_limit_list Lib "RTC6DLLx64.DLL" (ByVal CosAngle As Double)
    Declare Sub set_sky_writing_mode_list Lib "RTC6DLLx64.DLL" (ByVal Mode As UInteger)
    Declare Sub set_scanner_delays Lib "RTC6DLLx64.DLL" (ByVal Jump As UInteger, ByVal Mark As UInteger, ByVal Polygon As UInteger)
    Declare Sub set_jump_mode_list Lib "RTC6DLLx64.DLL" (ByVal Flag As Integer)
    Declare Sub enduring_wobbel Lib "RTC6DLLx64.DLL" ()
    Declare Sub n_stepper_enable_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Enable1 As Integer, ByVal Enable2 As Integer)
    Declare Sub n_stepper_control_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Period1 As Integer, ByVal Period2 As Integer)
    Declare Sub n_stepper_abs_no_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger, ByVal Pos As Integer)
    Declare Sub n_stepper_rel_no_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger, ByVal dPos As Integer)
    Declare Sub n_stepper_abs_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal Pos1 As Integer, ByVal Pos2 As Integer)
    Declare Sub n_stepper_rel_list Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal dPos1 As Integer, ByVal dPos2 As Integer)
    Declare Sub n_stepper_wait Lib "RTC6DLLx64.DLL" (ByVal CardNo As UInteger, ByVal No As UInteger)
    Declare Sub stepper_enable_list Lib "RTC6DLLx64.DLL" (ByVal Enable1 As Integer, ByVal Enable2 As Integer)
    Declare Sub stepper_control_list Lib "RTC6DLLx64.DLL" (ByVal Period1 As Integer, ByVal Period2 As Integer)
    Declare Sub stepper_abs_no_list Lib "RTC6DLLx64.DLL" (ByVal No As UInteger, ByVal Pos As Integer)
    Declare Sub stepper_rel_no_list Lib "RTC6DLLx64.DLL" (ByVal No As UInteger, ByVal dPos As Integer)
    Declare Sub stepper_abs_list Lib "RTC6DLLx64.DLL" (ByVal Pos1 As Integer, ByVal Pos2 As Integer)
    Declare Sub stepper_rel_list Lib "RTC6DLLx64.DLL" (ByVal dPos1 As Integer, ByVal dPos2 As Integer)
    Declare Sub stepper_wait Lib "RTC6DLLx64.DLL" (ByVal No As UInteger)
#End Region

    Public ErrorMsg As String = ""

#Region "Parameter Set"
    Private m_iRTC6Num As Integer = 0 '설명: 스캐너 넘버 
    Private m_iTimeBase As Integer = 1 '설명 : TimeBase = 0 ( 1bit = 1 us [1Mhz]), TimeBase = 1 ( 1bit = 1/8 us [8Mhz])
    Private m_iLaserMod As Integer '설명 : CO2 Mode = 0, YAG Mode 1 = 1, YAG Mode 2 = 2, YAG Mode 3 = 3, Laser Mode = 4 
    Private m_iFirstPulseKill As Integer '설명 : 1bit = 1/8us
    Private m_iHalfPulsePeriod As Integer '설명 : 1bit = 1us or 1/8us
    Private m_iPulseWidth1 As Integer '설명 : 1bit = 1us or 1/8us
    Private m_iPulseWidth2 As Integer '설명 : 1bit = 1us or 1/8us
    Private m_dScanScale As Double = 1 '설명 : bit 당 이동거리 단위(um)
    Private m_dRtnScanScale As Double = 1 '설명 : bit 당 이동거리 단위(um)
    Private m_dJumpSpeed As Double '설명 : 단위 mm/s 범위 2 ~ 50000bit
    Private m_dMarkSpeed As Double '설명 : 단위 mm/s 범위 2 ~ 50000bit
    Private m_iLaserOnDelay As Integer  '설명 : 단위 1us , 범위 -8000us ~ 8000us
    Private m_iLaserOffDelay As Integer '설명 : 단위 1us , 범위 2us ~ 8000us
    Private m_iJumpDelay As Integer '설명 : bit 당 10us , 범위 0us ~ 32767bit
    Private m_iMarkDelay As Integer '설명 : bit 당 10us , 범위 0us ~ 32767bit
    Private m_iPolygonDelay As Integer '설명 : bit 당 10us , 범위 0us ~ 32767bit
    Private m_strCorrectionFilePath As String ' 
    Private m_strProgramFilePath As String

    Structure ScannerStatus
        Dim bInit As Boolean
        Dim bAbleWork As Boolean
        Dim bShot As Boolean
        Dim dPosX As Double
        Dim dPosY As Double
    End Structure

    Public pStatus As ScannerStatus
    Public m_iIndex As Integer = 0
    Private ThreadScanner As Thread
    Private bThreadRunningScanner As Boolean
    Private nKillThreadScanner As Integer
    Private nThreadIndex As Integer = 1

    Enum CalMatrix
        Five = 0
        Seven
        Nine
        Eleven
        Thirteen
        Fifteen
        SevenTeen
        NineTeen
    End Enum

#End Region

#Region "Thread"

    ReadOnly Property ThreadRunningLaser() As Boolean
        Get
            Return bThreadRunningScanner
        End Get
    End Property

    Function StartScanner() As Boolean
        On Error GoTo SysErr

        'ThreadScanner = New Thread(AddressOf ScannerStatusThreadSub)
        'nKillThreadScanner = 0
        'ThreadScanner.SetApartmentState(ApartmentState.MTA)
        'ThreadScanner.Priority = ThreadPriority.Highest 'ThreadPriority.Normal
        'ThreadScanner.Start()

        StartScanner = True
        Exit Function
SysErr:
        pStatus.bInit = False
        StartScanner = False
        ErrorMsg = ErrorMsg & "Start Laser Status Thread Error" & ","
    End Function

    Function EndScanner() As Boolean
        On Error GoTo SysErr
        'Interlocked.Exchange(nKillThreadScanner, 1)

        'If bThreadRunningScanner = True Then
        'ThreadScanner.Join(1000)   'ThreadScanner.Join(5000)
        'End If

        If Not (ThreadScanner Is Nothing) Then
            ThreadScanner.Join(10000)
        End If

        free_rtc6_dll()
        ThreadScanner = Nothing
        pStatus.bInit = False

        bThreadRunningScanner = False

        Return True
        Exit Function
SysErr:
        EndScanner = False
        ErrorMsg = ErrorMsg & "End Laser Status Thread Error" & ","
    End Function



    Sub ScannerStatusThreadSub()
        On Error GoTo SysErr
        Dim strCmd As String

        'While nKillThreadScanner = 0
        bThreadRunningScanner = True
        pStatus.bAbleWork = RTC6Status(pStatus.dPosX, pStatus.dPosY)
        'Thread.Sleep(300)
        '  RTC6_GetPosXY(pStatus.dPosX, pStatus.dPosY)
        'For i = 0 To 300
        '    Thread.Sleep(1)
        'Next
        'End While

        'bThreadRunningScanner = False
        Exit Sub
SysErr:
        bThreadRunningScanner = False
        'ErrorMsg = ErrorMsg & "Laser Status Thread Error" & ","
    End Sub


    Sub Close()

        If Not (ThreadScanner Is Nothing) Then
            ThreadScanner.Join(10000)
        End If

        Call Finalize()

    End Sub

#End Region


    Sub SetRTC6Num(ByVal iNum As Integer)
        On Error GoTo SysErr
        m_iRTC6Num = iNum
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "RTC6Num Set Error" & ","
    End Sub

    Function GetRTC6Num() As Integer
        On Error GoTo SysErr
        Return m_iRTC6Num
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "RTC6Num Get Error" & ","
    End Function

    Sub SetTimeBase(ByVal TimeBase As Integer)
        On Error GoTo SysErr
        m_iTimeBase = TimeBase
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Time Base Set Error" & ","
    End Sub

    Function GetTimeBase() As Integer
        On Error GoTo SysErr
        Return m_iTimeBase
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Time Base Get Error" & ","
    End Function

    Sub SetLaserMod(ByVal LaserMod As Integer)
        On Error GoTo SysErr
        m_iLaserMod = LaserMod
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Laser Mode Set Error" & ","
    End Sub

    Function GetLaserMod() As Integer
        On Error GoTo SysErr
        Return m_iLaserMod
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Laser Mode Get Error" & ","
    End Function

    Sub SetFirstPulseKill(ByVal FirstPulseKill As Integer)
        On Error GoTo SysErr
        m_iFirstPulseKill = FirstPulseKill
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Laser Mode Set Error" & ","
    End Sub

    Function GetFirstPulseKill() As Integer
        On Error GoTo SysErr
        Return m_iFirstPulseKill
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Laser Mode Get Error" & ","
    End Function

    ''''''''''''''''[단위 : us]''''''''''''''''
    Sub SetPulsePeriod(ByVal Frequency As Integer)
        On Error GoTo SysErr
        'm_iHalfPulsePeriod = ConvertFrequencyToHalfPulsePeriod(Frequency)
        m_iHalfPulsePeriod = Frequency
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Half Pulse Period Set Error" & ","
    End Sub

    Function GetPulsePeriod() As Integer
        On Error GoTo SysErr
        Dim TmpPeriod As Integer
        TmpPeriod = ConvertFrequencyToHalfPulsePeriod(m_iHalfPulsePeriod)
        Return TmpPeriod
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Half Pulse Period Get Error" & ","
    End Function

    Sub SetPulseWidth1(ByVal PulseWidth As Integer)
        On Error GoTo SysErr
        m_iPulseWidth1 = PulseWidth
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Pulse Width1 Set Error" & ","
    End Sub

    Function GetPulseWidth1()
        On Error GoTo SysErr
        Return m_iPulseWidth1
SysErr:
        ErrorMsg = ErrorMsg & "Pulse Width1 Get Error" & ","
    End Function

    Sub SetPulseWidth2(ByVal PulseWidth As Integer)
        On Error GoTo SysErr
        m_iPulseWidth2 = PulseWidth
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Pulse Width2 Set Error" & ","
    End Sub

    Function GetPulseWidth2()
        On Error GoTo SysErr
        Return m_iPulseWidth2
SysErr:
        ErrorMsg = ErrorMsg & "Pulse Width2 Get Error" & ","
    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''

    ''''''''''''''''[단위 : bit/mm]''''''''''''''''
    Sub SetScanScale(ByVal ScanScale As Double)
        On Error GoTo SysErr
        m_dRtnScanScale = 1000 / ScanScale
        m_dScanScale = ScanScale
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Scanner Scale set Error" & ","
    End Sub

    Function GetScanScale() As Double
        On Error GoTo SysErr
        Return m_dRtnScanScale
SysErr:
        ErrorMsg = ErrorMsg & "Scanner Scale Get Error" & ","
    End Function
    '''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''[단위 : mm/s]''''''''''''''''
    Sub SetJumpSpeed(ByVal JumpSpeed As Double)
        On Error GoTo SysErr
        m_dJumpSpeed = JumpSpeed / m_dScanScale
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Jump Speed Set Error" & ","
    End Sub

    Function GetJumpSpeed() As Double
        On Error GoTo SysErr
        Return m_dJumpSpeed * m_dScanScale
SysErr:
        ErrorMsg = ErrorMsg & "Jump Speed Get Error" & ","
    End Function

    Sub SetMarkSpeed(ByVal MarkSpeed As Double)
        On Error GoTo SysErr
        m_dMarkSpeed = MarkSpeed / m_dScanScale
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Mark Speed Set Error" & ","
    End Sub

    Function GetMarkSpeed() As Double
        On Error GoTo SysErr
        Return m_dMarkSpeed * m_dScanScale
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Mark Speed Get Error" & ","
    End Function
    '''''''''''''''''''''''''''''''''''''''''''''

    ''''''''''''''''[단위 : us]''''''''''''''''
    Sub SetJumpDelay(ByVal JumpDelay As Integer)
        On Error GoTo SysErr
        m_iJumpDelay = JumpDelay / 10
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Jump Delay Set Error" & ","
    End Sub

    Function GetJumpDelay() As Integer
        On Error GoTo SysErr
        Return m_iJumpDelay * 10
SysErr:
        ErrorMsg = ErrorMsg & "Jump Delay Get Error" & ","
    End Function

    Sub SetMarkDelay(ByVal MarkDelay As Integer)
        On Error GoTo SysErr
        m_iMarkDelay = MarkDelay / 10
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Mark Delay Set Error" & ","
    End Sub

    Function GetMarkDelay() As Integer
        On Error GoTo SysErr
        Return m_iMarkDelay * 10
SysErr:
        ErrorMsg = ErrorMsg & "Mark Delay Get Error" & ","
    End Function

    Sub SetPolygonDelay(ByVal PolygonDelay As Integer)
        On Error GoTo SysErr
        m_iPolygonDelay = PolygonDelay / 10
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Polygon Delay Set Error" & ","
    End Sub

    Function GetPolygonDelay() As Integer
        On Error GoTo SysErr
        Return m_iPolygonDelay * 10
SysErr:
        ErrorMsg = ErrorMsg & "Polygon Delay Get Error" & ","
    End Function

    Sub SetLaserOnDelay(ByVal LaserOnDelay As Integer)
        On Error GoTo SysErr
        'm_iLaserOnDelay = LaserOnDelay / 10
        m_iLaserOnDelay = LaserOnDelay * 10
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Polygon Delay Set Error" & ","
    End Sub

    Function GetLaserOnDelay() As Integer
        On Error GoTo SysErr
        'Return m_iLaserOnDelay * 10
        Return m_iLaserOnDelay / 10
SysErr:
        ErrorMsg = ErrorMsg & "Polygon Delay Get Error" & ","
    End Function

    Sub SetLaserOffDelay(ByVal LaserOffDelay As Integer)
        On Error GoTo SysErr
        'm_iLaserOffDelay = LaserOffDelay / 10
        m_iLaserOffDelay = LaserOffDelay * 10
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Polygon Delay Set Error" & ","
    End Sub

    Function GetLaserOffDelay() As Integer
        On Error GoTo SysErr
        'Return m_iLaserOffDelay * 10
        Return m_iLaserOffDelay / 10
SysErr:
        ErrorMsg = ErrorMsg & "Polygon Delay Get Error" & ","
    End Function

    '''''''''''''''''''''''''''''''''''''''''''''

    Sub SetCorrectionFilePath(ByVal CorFilePath As String)
        On Error GoTo SysErr
        m_strCorrectionFilePath = CorFilePath
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Correction File Path Set Error" & ","
    End Sub

    Function GetCorrectionFilePath() As String
        On Error GoTo SysErr
        Return m_strCorrectionFilePath
SysErr:
        ErrorMsg = ErrorMsg & "Correction File Path Get Error" & ","
    End Function

    Sub SetProgramFilePath(ByVal HexFilePath As String)
        On Error GoTo SysErr
        m_strProgramFilePath = HexFilePath
        Exit Sub
SysErr:
        ErrorMsg = ErrorMsg & "Program File Path Set Error" & ","
    End Sub

    Function GetProgramFilePath() As String
        On Error GoTo SysErr
        Return m_strProgramFilePath
SysErr:
        ErrorMsg = ErrorMsg & "Program File Path Get Error" & ","
    End Function

#Region "Function"
    Function RTC6load_correction(ByVal ipRTCNo As Integer, ByVal ipPath As String) As Boolean
        On Error GoTo SysErr

        Dim ErrorCorCode As Short

        ErrorCorCode = n_load_correction_file(ipRTCNo, ipPath, 1, 2)

        If (ErrorCorCode) Then
            ErrorMsg = ErrorCorCode
            Return False
            Exit Function
        End If

        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "InitRTC6 Error" & ","
        Return False
    End Function
    Function RTC6load_program(ByVal ipRTCNo As Integer, ByVal ipPath As String) As Boolean
        On Error GoTo SysErr

        Dim ErrorHexCode As Short

        ErrorHexCode = n_load_program_file(ipRTCNo, ipPath)

        If (ErrorHexCode) Then
            ErrorMsg = ErrorHexCode
            Return False
            Exit Function
        End If
        pStatus.bInit = True
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "InitRTC6 Error" & ","
        Return False
    End Function

    Function RTC6Init() As Boolean
        On Error GoTo SysErr

        Dim ErrorSelCode As Integer
        Dim ErrorCode As Integer
        Dim ErrorCorCode As Short
        Dim ErrorHexCode As Short
        Dim nSerial As Integer = 0

        EndScanner()

        ErrorCode = init_rtc6_dll()

        If (ErrorCode) Then

            ErrorMsg = ErrorMsg & "Init Error : " & ","
            free_rtc6_dll()
            Return False
            Exit Function

        End If

        nSerial = n_get_serial_number(m_iRTC6Num)

        'set_rtc4_mode()

        ErrorCorCode = n_load_correction_file(m_iRTC6Num, m_strCorrectionFilePath, 1, 2)
        ErrorHexCode = n_load_program_file(m_iRTC6Num, m_strProgramFilePath)

        If (ErrorCorCode) Then
            ErrorMsg = ErrorMsg & "Correction file loading error: " & ","
            free_rtc6_dll()
            Return False
            Exit Function
        End If

        If (ErrorHexCode) Then
            ErrorMsg = ErrorMsg & "Program file loading error: " & ","
            free_rtc6_dll()
            Return False
            Exit Function
        End If

        n_select_cor_table(m_iRTC6Num, 1, 0)

        m_iTimeBase = 1

        If bThreadRunningScanner = False Then
            'StartScanner()
            pStatus.bInit = True
            n_stop_execution(m_iRTC6Num)    'GYN add
            Return True
        End If

        Exit Function
SysErr:
        free_rtc6_dll()
        ErrorMsg = ErrorMsg & "InitRTC6 Error" & "," & Err.Description
        Return False
    End Function

    Function RTC6ParamApply() As Boolean
        On Error GoTo SysErr

        n_set_laser_mode(m_iRTC6Num, m_iLaserMod)
        n_set_laser_control(m_iRTC6Num, 0)
        n_set_standby(m_iRTC6Num, m_iHalfPulsePeriod, 8)
        n_set_start_list(m_iRTC6Num, 1)
        n_set_firstpulse_killer(m_iRTC6Num, m_iFirstPulseKill)
        n_set_laser_delays(m_iRTC6Num, m_iLaserOnDelay, m_iLaserOffDelay)
        n_set_scanner_delays(m_iRTC6Num, m_iJumpDelay, m_iMarkDelay, m_iPolygonDelay)
        ' n_set_laser_pulses(m_iRTC6Num, m_iHalfPulsePeriod, m_iPulseWidth1)
        n_set_laser_timing(m_iRTC6Num, m_iHalfPulsePeriod, m_iPulseWidth1, m_iPulseWidth2, m_iTimeBase)

        n_set_mark_speed(m_iRTC6Num, m_dMarkSpeed)
        n_set_jump_speed(m_iRTC6Num, m_dJumpSpeed)
        n_set_end_of_list(m_iRTC6Num)
        n_execute_list(m_iRTC6Num, 1)

        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "RTC6ParamApply Error" & ","
        Return False
    End Function

    'GYN - List Reset TEST
    Function RTC6ResetList() As Boolean
        On Error GoTo SysErr


        RTC6ParamApply()

        'n_set_start_list(m_iRTC6Num, 1)
        'n_set_end_of_list(m_iRTC6Num)
        'n_execute_list(m_iRTC6Num, 1)

SysErr:
        ErrorMsg = ErrorMsg & "RTC6ResetList Error" & ","
        Return False
    End Function

    Function RTC6LaserShotOnTime(ByVal LaserShotTime As Integer) As Boolean  ' LaserShotTime =< 655000 us
        On Error GoTo SysErr
        n_set_start_list(m_iRTC6Num, 1)
        n_laser_on_list(m_iRTC6Num, LaserShotTime / 10)
        n_set_end_of_list(1)
        n_execute_list(m_iRTC6Num, 1)

        Return True
        Exit Function
SysErr:
        Return False
        ErrorMsg = ErrorMsg & "RTC6 Laser Shot On Time Error" & ","
    End Function

    Function RTC6LaserShotOn() As Boolean
        On Error GoTo SysErr
        pStatus.bShot = True
        n_laser_signal_on(m_iRTC6Num)
        Return True
SysErr:
        n_laser_signal_off(m_iRTC6Num)
        pStatus.bShot = False
        Return False
        ErrorMsg = ErrorMsg & "RTC6 Laser Shot On Error" & ","
    End Function

    Function RTC6LaserShotOff() As Boolean
        On Error GoTo SysErr
        pStatus.bShot = False
        n_laser_signal_off(m_iRTC6Num)
        Return True
SysErr:
        n_laser_signal_off(m_iRTC6Num)
        Return False
        ErrorMsg = ErrorMsg & "RTC6 Laser Shot Off Error" & ","
    End Function

    Function RTC6_GetPosXY(ByRef PosX As Double, ByRef PosY As Double) As Boolean
        On Error GoTo SysErr

        '        'GYN - 수정 완료.
        '        'GYN - 주철민 대리 확인 할것. 메모리 이상 현상 발생.
        '        Dim tmpPosX As Long
        '        Dim tmpPosY As Long

        '        'control_command(m_iRTC6Num, 1, CUInt("&H" & "0501"))
        '        n_control_command(m_iRTC6Num, 1, 1, &H501)   'CUInt("&H" & "0501"))
        '        tmpPosX = n_get_value(m_iRTC6Num, &H1)

        '        'control_command(m_iRTC6Num, 2, CUInt("&H" & "0501"))
        '        n_control_command(m_iRTC6Num, 1, 2, &H501)   'CUInt("&H" & "0501"))
        '        tmpPosY = n_get_value(m_iRTC6Num, &H2)

        '        If tmpPosX > 32767 Then
        '            tmpPosX = tmpPosX - 65536
        '        End If

        '        If tmpPosY > 32767 Then
        '            tmpPosY = tmpPosY - 65536
        '        End If

        '        PosX = tmpPosX * m_dScanScale
        '        PosY = tmpPosY * m_dScanScale

        '        Return True
        '        Exit Function
SysErr:
        '        Return False
        '        ErrorMsg = ErrorMsg & "RTC6 Get Position XY Error" & ","
    End Function

    Function RTC6Status(ByRef PosX As Double, ByRef PosY As Double) As Boolean
        On Error GoTo SysErr

        'GYN - TEST
        Dim iStatus As UInteger = 9999
        Dim iListPos As UInteger = m_iRTC6Num



        n_get_status(m_iRTC6Num, iStatus, iListPos)

        n_control_command(m_iRTC6Num, 1, 1, &H501)
        tmpPosX = n_get_value(m_iRTC6Num, &H1)

        'iStatus = 501
        'n_control_command(m_iRTC6Num, 1, 1, iStatus)
        'iStatus = 1
        'tmpPosX = n_get_value(m_iRTC6Num, iStatus)

        For i As Integer = 0 To 30
            Thread.Sleep(1)
        Next

        n_control_command(m_iRTC6Num, 1, 2, &H501)
        tmpPosY = n_get_value(m_iRTC6Num, &H2)

        'iStatus = 501
        'n_control_command(m_iRTC6Num, 1, 2, iStatus)
        'iStatus = 2
        'tmpPosY = n_get_value(m_iRTC6Num, iStatus)

        PosX = tmpPosX * m_dScanScale
        PosY = tmpPosY * m_dScanScale

        If iStatus = 0 Then
            ' pStatus.bShot = False
            Return True
        Else
            '  pStatus.bShot = True
            Return False
        End If

        Return True
        'Catch ex As Exception
        '    ErrorMsg = ErrorMsg & "RTC6 Status Get Error" & ","
        'End Try


        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "RTC6 Status Get Error" & ","
    End Function

    Function RTC6RelMove(ByVal RelValueX As Integer, ByVal RelValueY As Integer) As Boolean
        On Error GoTo SysErr
        n_set_start_list(m_iRTC6Num, 1)
        n_jump_rel(m_iRTC6Num, RelValueX / m_dScanScale, RelValueY / m_dScanScale)
        n_set_end_of_list(m_iRTC6Num)
        n_execute_list(m_iRTC6Num, 1)
        Return True
        Exit Function
SysErr:
        Return False
        ErrorMsg = ErrorMsg & "RTC6 Rel Move Error" & ","
    End Function

    Function RTC6ABSMove(ByVal ABSValueX As Integer, ByVal ABSValueY As Integer) As Boolean
        On Error GoTo SysErr

        If pScanner(m_iRTC6Num - 1).pStatus.bInit = False Then
            Return False
        End If

        n_set_start_list(m_iRTC6Num, 1)
        n_jump_abs(m_iRTC6Num, ABSValueX / m_dScanScale, ABSValueY / m_dScanScale)
        n_set_end_of_list(m_iRTC6Num)
        n_execute_list(m_iRTC6Num, 1)
        Return True
        Exit Function
SysErr:
        Return False
        ErrorMsg = ErrorMsg & "RTC6 ABS Move Error" & ","
    End Function

    '    Function RTC6SetWobbel(ByVal ipWobbelSize As Double, ByVal ipFrequency As Double) As Boolean
    '        On Error GoTo SysErr
    '        Dim nAmplitude As Integer = ipWobbelSize / m_dScanScale

    '        n_set_start_list(m_iRTC6Num, 1)
    '        n_set_wobbel(m_iRTC6Num, nAmplitude, ipFrequency)
    '        n_set_end_of_list(m_iRTC6Num)
    '        n_execute_list(m_iRTC6Num, 1)

    '        Return True
    'SysErr:
    '        Return False
    '    End Function

    Function RTC6MarkLine(ByVal ipSize As Integer, ByVal ABS_CenterPosX As Integer, ByVal ABS_CenterPosY As Integer, ByVal Repeat As Integer, ByVal bDirXY As Boolean) As Boolean
        On Error GoTo SysErr
        n_set_start_list(m_iRTC6Num, 1)
        For i As Integer = 1 To Repeat
            If bDirXY = True Then ' bDirXY = True X축, False Y축
                n_jump_abs(m_iRTC6Num, (ABS_CenterPosX - ipSize) / (2 * m_dScanScale), 0)
                n_mark_abs(m_iRTC6Num, (ABS_CenterPosX + ipSize) / (2 * m_dScanScale), 0)
            Else
                n_jump_abs(m_iRTC6Num, 0, (ABS_CenterPosY - ipSize) / (2 * m_dScanScale))
                n_mark_abs(m_iRTC6Num, 0, (ABS_CenterPosY + ipSize) / (2 * m_dScanScale))
            End If
        Next
        n_jump_abs(m_iRTC6Num, 0, 0)
        n_set_end_of_list(m_iRTC6Num)
        n_execute_list(m_iRTC6Num, 1)
        Return True
        Exit Function
SysErr:
        Return False
        ErrorMsg = ErrorMsg & "RTC6 Mark Line Error" & ","
    End Function

    Function RTC6MarkCircle(ByVal ipSize As Integer, ByVal ABS_CenterPosX As Integer, ByVal ABS_CenterPosY As Integer, ByVal Repeat As Integer) As Boolean
        On Error GoTo SysErr
        Dim dHalfCircleSize As Double = ipSize / 2
        n_set_start_list(m_iRTC6Num, 1)
        For i As Integer = 1 To Repeat
            n_jump_abs(m_iRTC6Num, ABS_CenterPosX / m_dScanScale, ABS_CenterPosY / m_dScanScale)
            n_jump_rel(m_iRTC6Num, -dHalfCircleSize / m_dScanScale, 0)
            n_arc_rel(m_iRTC6Num, dHalfCircleSize / m_dScanScale, 0, 360)
        Next
        n_jump_abs(m_iRTC6Num, 0, 0)
        n_set_end_of_list(m_iRTC6Num)
        n_execute_list(m_iRTC6Num, 1)
        Return True
        Exit Function
SysErr:
        Return False
        ErrorMsg = ErrorMsg & "RTC6 Mark Circle Error" & ","
    End Function

    Function RTC6MarkRect(ByVal ipSizeX As Integer, ByVal ipSizeY As Integer, ByVal ABS_CenterPosX As Integer, ByVal ABS_CenterPosY As Integer, ByVal Repeat As Integer) As Boolean
        On Error GoTo SysErr
        Dim nTmpPosX As Integer = ipSizeX / 2
        Dim nTmpPosY As Integer = ipSizeY / 2

        Dim nTmpSizeX As Integer = ipSizeX / 2
        Dim nTmpSizeY As Integer = ipSizeY / 2

        n_set_start_list(m_iRTC6Num, 1)
        n_jump_abs(m_iRTC6Num, ABS_CenterPosX / m_dScanScale, ABS_CenterPosY / m_dScanScale)
        For i As Integer = 1 To Repeat
            n_jump_abs(m_iRTC6Num, (ABS_CenterPosX - nTmpSizeX) / m_dScanScale, (ABS_CenterPosY - nTmpSizeY) / m_dScanScale)
            n_mark_abs(m_iRTC6Num, (ABS_CenterPosX - nTmpSizeX) / m_dScanScale, (ABS_CenterPosY + nTmpSizeY) / m_dScanScale)
            n_mark_abs(m_iRTC6Num, (ABS_CenterPosX + nTmpSizeX) / m_dScanScale, (ABS_CenterPosY + nTmpSizeY) / m_dScanScale)
            n_mark_abs(m_iRTC6Num, (ABS_CenterPosX + nTmpSizeX) / m_dScanScale, (ABS_CenterPosY - nTmpSizeY) / m_dScanScale)
            '  n_mark_abs(m_iRTC6Num, (ABS_CenterPosX - nTmpSizeX) / m_dScanScale, (ABS_CenterPosY + nTmpSizeY) / m_dScanScale)
        Next
        n_jump_abs(m_iRTC6Num, 0, 0)
        n_set_end_of_list(m_iRTC6Num)
        n_execute_list(m_iRTC6Num, 1)

        Return True
        Exit Function
SysErr:
        Return False
        ErrorMsg = ErrorMsg & "RTC6 Mark Rect Error" & ","
    End Function

    Function RTC6MarkCross(ByVal ipSize As Integer, ByVal ABS_CenterPosX As Integer, ByVal ABS_CenterPosY As Integer, ByVal Repeat As Integer) As Boolean
        On Error GoTo SysErr
        Dim nHalfTmpSize As Integer = ipSize / 2
        n_set_start_list(m_iRTC6Num, 1)
        n_jump_abs(m_iRTC6Num, ABS_CenterPosX / m_dScanScale, ABS_CenterPosY / m_dScanScale)
        For i As Integer = 1 To Repeat
            n_jump_abs(m_iRTC6Num, (ABS_CenterPosX - nHalfTmpSize) / m_dScanScale, ABS_CenterPosY / m_dScanScale)
            n_mark_abs(m_iRTC6Num, (ABS_CenterPosX + nHalfTmpSize) / m_dScanScale, ABS_CenterPosY / m_dScanScale)
            n_jump_abs(m_iRTC6Num, ABS_CenterPosX / m_dScanScale, (ABS_CenterPosY - nHalfTmpSize) / m_dScanScale)
            n_mark_abs(m_iRTC6Num, ABS_CenterPosX / m_dScanScale, (ABS_CenterPosY + nHalfTmpSize) / m_dScanScale)
        Next
        n_jump_abs(m_iRTC6Num, 0, 0)
        n_set_end_of_list(m_iRTC6Num)
        n_execute_list(m_iRTC6Num, 1)
        Return True
        Exit Function
SysErr:
        Return False
        ErrorMsg = ErrorMsg & "RTC6 Mark Cross Error" & ","
    End Function

    Function RTC6_CrossShot(ByVal nSize As Double) As Boolean  ' LaserShotTime =< 655000 us
        On Error GoTo SysErr
        Dim tmpSize As Integer = nSize

        n_set_start_list(m_iRTC6Num, 1)
        n_jump_abs(m_iRTC6Num, -tmpSize / m_dScanScale, 0)
        n_mark_abs(m_iRTC6Num, tmpSize / m_dScanScale, 0)
        n_jump_abs(m_iRTC6Num, 0, -tmpSize / m_dScanScale)
        n_mark_abs(m_iRTC6Num, 0, tmpSize / m_dScanScale)
        n_set_end_of_list(1)
        n_execute_list(m_iRTC6Num, 1)
        Return True
        Exit Function
SysErr:
        Return False
        ErrorMsg = ErrorMsg & "RTC6 Laser Shot On Time Error" & ","
    End Function

    Function RTC6_CrossShot_Seq(ByVal ipPosX As Integer, ByVal ipPosY As Integer, ByVal OffsetX As Double, ByVal OffsetY As Double, ByVal ipAngle As Double, ByVal nSize As Double) As Boolean  ' LaserShotTime =< 655000 us
        On Error GoTo SysErr
        Dim tmpSize As Integer = 0

        tmpSize = nSize / m_dScanScale

        tmpPosX = ipPosX / m_dScanScale
        tmpPosY = ipPosY / m_dScanScale
        tmpOffsetX = OffsetX / m_dScanScale
        tmpOffsetY = OffsetY / m_dScanScale

        AdjustAngle(tmpPosX, tmpPosY, ipAngle)

        n_jump_abs(m_iRTC6Num, (tmpPosX + tmpOffsetX) - tmpSize, tmpPosY + tmpOffsetY)
        n_mark_abs(m_iRTC6Num, (tmpPosX + tmpOffsetX) + tmpSize, tmpPosY + tmpOffsetY)
        n_jump_abs(m_iRTC6Num, (tmpPosX + tmpOffsetX), (tmpPosY + tmpOffsetY) - tmpSize)
        n_mark_abs(m_iRTC6Num, (tmpPosX + tmpOffsetX), (tmpPosY + tmpOffsetY) + tmpSize)

        Return True
        Exit Function
SysErr:
        Return False
        ErrorMsg = ErrorMsg & "RTC6 Laser Shot On Time Error" & ","
    End Function

    '20140226 추가

    Dim tmpPosX As Double = 0
    Dim tmpPosY As Double = 0

    Dim tmpOffsetX As Double = 0
    Dim tmpOffsetY As Double = 0


    Function RTC6MarkListStart() As Boolean
        On Error GoTo SysErr
        n_set_start_list(m_iRTC6Num, 1)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6MarkLineAdd(ByVal ipStartPosX As Integer, ByVal ipStartPosY As Integer, ByVal ipEndPosX As Integer, ByVal ipEndPosY As Integer) As Boolean
        On Error GoTo SysErr
        n_jump_abs(m_iRTC6Num, ipStartPosX / m_dScanScale, ipStartPosY / m_dScanScale)
        n_mark_abs(m_iRTC6Num, ipEndPosX / m_dScanScale, ipEndPosY / m_dScanScale)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6MarkRectAdd(ByVal ipStartPosX As Integer, ByVal ipStartPosY As Integer, ByVal ipEndPosX As Integer, ByVal ipEndPosY As Integer) As Boolean
        On Error GoTo SysErr

        n_jump_abs(m_iRTC6Num, ipStartPosX / m_dScanScale, ipStartPosY / m_dScanScale)
        n_mark_abs(m_iRTC6Num, ipEndPosX / m_dScanScale, ipStartPosY / m_dScanScale)
        n_mark_abs(m_iRTC6Num, ipEndPosX / m_dScanScale, ipEndPosY / m_dScanScale)
        n_mark_abs(m_iRTC6Num, ipStartPosX / m_dScanScale, ipEndPosY / m_dScanScale)
        n_mark_abs(m_iRTC6Num, ipStartPosX / m_dScanScale, ipStartPosY / m_dScanScale)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6MarkCircleAdd(ByVal ipStartPosX As Integer, ByVal ipStartPosY As Integer, ByVal ipEndPosX As Integer, ByVal ipEndPosY As Integer) As Boolean
        On Error GoTo SysErr
        Dim dHalfCircleSize As Double = Math.Sqrt((ipStartPosX - ipEndPosX) ^ 2 + (ipStartPosY - ipEndPosY) ^ 2) / 2
        n_jump_abs(m_iRTC6Num, (ipStartPosX + ipEndPosX) / (2 * m_dScanScale), (ipStartPosY + ipEndPosY) / (2 * m_dScanScale))
        n_jump_rel(m_iRTC6Num, -dHalfCircleSize / m_dScanScale, 0)
        n_arc_rel(m_iRTC6Num, dHalfCircleSize / m_dScanScale, 0, 360)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6MarkABSAdd(ByVal ipPosX As Integer, ByVal ipPosY As Integer, ByVal OffsetX As Double, ByVal OffsetY As Double, ByVal ipAngle As Double) As Boolean
        On Error GoTo SysErr
        tmpPosX = ipPosX / m_dScanScale
        tmpPosY = ipPosY / m_dScanScale
        tmpOffsetX = OffsetX / m_dScanScale
        tmpOffsetY = OffsetY / m_dScanScale

        AdjustAngle(tmpPosX, tmpPosY, ipAngle)
        n_mark_abs(m_iRTC6Num, tmpPosX + tmpOffsetX, tmpPosY + tmpOffsetY)

        'modPub.TestLog("MA- X:" & (tmpPosX + tmpOffsetX).ToString & ",Y:" & (tmpPosY + tmpOffsetY).ToString)
        'modPub.TestLog("MA- X:" & (ipPosX / 1000).ToString & ",Y:" & (ipPosY / 1000).ToString)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6MarkRELAdd(ByVal ipPosX As Double, ByVal ipPosY As Double, ByVal OffsetX As Double, ByVal OffsetY As Double, ByVal ipAngle As Double) As Boolean
        On Error GoTo SysErr
        tmpPosX = ipPosX / m_dScanScale
        tmpPosY = ipPosY / m_dScanScale

        tmpOffsetX = OffsetX / m_dScanScale
        tmpOffsetY = OffsetY / m_dScanScale

        AdjustAngle(tmpPosX, tmpPosY, ipAngle)
        n_mark_rel(m_iRTC6Num, tmpPosX + tmpOffsetX, tmpPosY + tmpOffsetY)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6JumpABSAdd(ByVal ipPosX As Double, ByVal ipPosY As Double, ByVal OffsetX As Double, ByVal OffsetY As Double, ByVal ipAngle As Double) As Boolean
        On Error GoTo SysErr
        tmpPosX = ipPosX / m_dScanScale
        tmpPosY = ipPosY / m_dScanScale
        tmpOffsetX = OffsetX / m_dScanScale
        tmpOffsetY = OffsetY / m_dScanScale

        AdjustAngle(tmpPosX, tmpPosY, ipAngle)

        n_jump_abs(m_iRTC6Num, tmpPosX + tmpOffsetX, tmpPosY + tmpOffsetY)

        'modPub.TestLog("JA : X(" & (tmpPosX + tmpOffsetX).ToString & ") Y(" & (tmpPosY + tmpOffsetY).ToString & ")")
        'modPub.TestLog("JA : X(" & (ipPosX / 1000).ToString & ") Y(" & (ipPosY / 1000).ToString & ")")
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6JumpRELAdd(ByVal ipPosX As Double, ByVal ipPosY As Double, ByVal OffsetX As Double, ByVal OffsetY As Double, ByVal ipAngle As Double) As Boolean
        On Error GoTo SysErr
        tmpPosX = ipPosX / m_dScanScale
        tmpPosY = ipPosY / m_dScanScale
        tmpOffsetX = OffsetX / m_dScanScale
        tmpOffsetY = OffsetY / m_dScanScale

        AdjustAngle(tmpPosX, tmpPosY, ipAngle)
        n_jump_rel(m_iRTC6Num, tmpPosX + tmpOffsetX, tmpPosY + tmpOffsetY)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6ArcABSAdd(ByVal ipPosX As Double, ByVal ipPosY As Double, ByVal Angle As Double, ByVal OffsetX As Double, ByVal OffsetY As Double, ByVal ipAngle As Double) As Boolean
        On Error GoTo SysErr
        tmpPosX = ipPosX / m_dScanScale
        tmpPosY = ipPosY / m_dScanScale
        tmpOffsetX = OffsetX / m_dScanScale
        tmpOffsetY = OffsetY / m_dScanScale

        AdjustAngle(tmpPosX, tmpPosY, ipAngle)

        n_arc_abs(m_iRTC6Num, tmpPosX + tmpOffsetX, tmpPosY + tmpOffsetY, Angle)

        'modPub.TestLog("AA : X(" & (tmpPosX + tmpOffsetX).ToString & ") Y(" & (tmpPosY + tmpOffsetY).ToString & ") T(" & Angle.ToString & ")")

        Return True
        Exit Function
SysErr:
    End Function

    Function RTC6ArcRelAdd(ByVal ipPosX As Double, ByVal ipPosY As Double, ByVal Angle As Double, ByVal OffsetX As Double, ByVal OffsetY As Double, ByVal ipAngle As Double) As Boolean
        On Error GoTo SysErr
        tmpPosX = ipPosX / m_dScanScale
        tmpPosY = ipPosY / m_dScanScale
        tmpOffsetX = OffsetX / m_dScanScale
        tmpOffsetY = OffsetY / m_dScanScale

        AdjustAngle(tmpPosX, tmpPosY, ipAngle)

        n_arc_rel(m_iRTC6Num, tmpPosX + tmpOffsetX, tmpPosY + tmpOffsetY, Angle)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6MarkSpeedSet(ByVal ipSpeed As Double) As Boolean
        On Error GoTo SysErr
        m_dMarkSpeed = ipSpeed / m_dScanScale
        n_set_mark_speed(m_iRTC6Num, m_dMarkSpeed)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6JumpSpeedSet(ByVal ipSpeed As Double) As Boolean
        On Error GoTo SysErr
        m_dJumpSpeed = ipSpeed / m_dScanScale
        n_set_jump_speed(m_iRTC6Num, m_dJumpSpeed)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6MarkListEnd() As Boolean
        On Error GoTo SysErr
        n_set_end_of_list(m_iRTC6Num)
        n_execute_list(m_iRTC6Num, 1)
        Return True
        Exit Function
SysErr:

    End Function

    '    Function RTC6MarkListExecute() As Boolean
    '        On Error GoTo SysErr
    '        n_execute_list(m_iRTC6Num, 1)
    '        Return True
    '        Exit Function
    'SysErr:

    '    End Function

    Function RTC6StopAll() As Boolean
        On Error GoTo SysErr
        n_stop_execution(m_iRTC6Num)
        Return True
        Exit Function
SysErr:

    End Function

    Function RTC6SetMatrix(ByVal ipAngle As Double) As Boolean

        On Error GoTo SysErr
        Dim tmpSinData As Double = 0
        Dim tmpCosData As Double = 0

        tmpSinData = Math.Sin(ipAngle * Math.PI / 180)
        tmpCosData = Math.Cos(ipAngle * Math.PI / 180)

        n_set_matrix(m_iRTC6Num, 1, tmpCosData, -tmpSinData, tmpSinData, tmpCosData, 0)

        Return True

        Exit Function
SysErr:

    End Function


    Function RTC6_CAL(ByVal BitSize As Integer, ByVal Gab As Integer, ByVal numMatrix As Integer, ByVal Repeat As Integer) As Boolean
        On Error GoTo SysErr
        Dim Interval As Integer = 0
        Dim tmpInterval As Integer = 0
        Dim HalfSize As Integer = BitSize / 2
        Dim nTemp As Integer = numMatrix - 1
        Dim nDir As Integer = 1

        Interval = BitSize / nTemp
        n_set_start_list(m_iRTC6Num, 1)

        For i As Integer = 1 To Repeat
            n_jump_abs(m_iRTC6Num, -(HalfSize + Gab), HalfSize)
            n_mark_abs(m_iRTC6Num, (HalfSize + Gab), HalfSize)

            For l As Integer = 1 To nTemp
                tmpInterval = tmpInterval + Interval
                nDir = nDir * -1
                n_jump_rel(m_iRTC6Num, 0, -Interval)
                n_mark_abs(m_iRTC6Num, (HalfSize + Gab) * nDir, HalfSize - tmpInterval)
            Next

            tmpInterval = 0
            nDir = -1
            n_jump_abs(m_iRTC6Num, -HalfSize, (HalfSize + Gab))
            n_mark_abs(m_iRTC6Num, -HalfSize, -(HalfSize + Gab))

            For m As Integer = 1 To nTemp
                tmpInterval = tmpInterval + Interval
                nDir = nDir * -1
                n_jump_rel(m_iRTC6Num, Interval, 0)
                n_mark_abs(m_iRTC6Num, -HalfSize + tmpInterval, (HalfSize + Gab) * nDir)
            Next
        Next
        n_jump_abs(m_iRTC6Num, 0, 0)
        n_set_end_of_list(m_iRTC6Num)
        n_execute_list(m_iRTC6Num, 1)
        Return True
        Exit Function
SysErr:
        Dim strErr As String = Err.Description
        Return False
    End Function

    Function ConvertFrequencyToHalfPulsePeriod(ByVal Frequency As Integer) As Integer
        On Error GoTo SysErr
        Dim nHalfPulsePeriod As Integer

        If m_iTimeBase = 0 Then
            nHalfPulsePeriod = 1000 / Frequency / 2
        ElseIf m_iTimeBase = 1 Then
            nHalfPulsePeriod = 8000 / Frequency / 2
        End If

        Return nHalfPulsePeriod
        Exit Function
SysErr:
        Return 0
        ErrorMsg = ErrorMsg & "RTC6 Convert Period to Frequency Error" & ","
    End Function

    Function ConvertDutyToPulseWitdh(ByVal Duty As Integer, ByVal Frequency As Integer) As Integer
        Dim nPulseWidth As Double
        If Duty > 100 Then
            Duty = 99
        End If

        If m_iTimeBase = 0 Then
            nPulseWidth = (1000 / Frequency / 2) * Duty / 100
        ElseIf m_iTimeBase = 1 Then
            nPulseWidth = (8000 / Frequency / 2) * Duty / 100
        End If

        Return nPulseWidth
        Exit Function
SysErr:
        Return 0
        ErrorMsg = ErrorMsg & "RTC6 Convert Period to Frequency Error" & ","
    End Function

    'GYN - 2017.04.04 RTC6를 이용한 Laser Power 조절
    'Trumf Laser일 경우 사용.
    Function RTC6_LaserPowerTRUMF(ByVal nCardNo, ByVal nPower) As Boolean
        On Error GoTo SysErr

        'x <1 또는 x> 2 인 경우 명령이 무시됩니다 (get_last_error 리턴 코드 RTC6_PARAM_ERROR).
        Dim iError As Integer = 0
        Dim dPower As Double = 0.0
        Dim nTempPower As Integer = 0
        Dim strPower As String = ""
        Dim Temp As Object

        dPower = nPower * 102.3 '* 409.5
        '0~10V -> 0~30W로 변경
        strPower = dPower.ToString

        nTempPower = CInt(strPower)

        Temp = nTempPower   'Hex(nTempPower)

        n_write_da_x(m_iRTC6Num, 1, Temp)
        'n_write_da_x(m_iRTC6Num, 1, Hex(nTempPower))
        'n_write_da_x(m_iRTC6Num, 1, &HFF)  '&HFF:2.5V (255), &HFFF:10V (4095)
        'n_write_da_x(m_iRTC6Num, 1, 0)

        iError = get_last_error()

        'n_write_da_x_list(nCardNo, 1, nPower)

        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Laser Power Set Error" & ","

    End Function

#End Region

    Enum MarkInfo
        JUMP_REL = 0
        JUMP_ABS
        MARK_REL
        MARK_ABS
        ARC_REL
        ARC_ABS
    End Enum

    Structure MarkingData
        Dim PosX() As Integer
        Dim PosY() As Integer
        Dim MarkingInfo() As MarkInfo

    End Structure

#Region "Chamfering"
    Function GetMarkingInformation(ByVal strData As String) As Boolean
        On Error GoTo SysErr


        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "RTC6 Get Marking Information Error" & ","
        Return False
    End Function

    Function AdjustAngle(ByRef PosX As Double, ByRef PosY As Double, ByVal ipAngle As Double) As Boolean
        On Error GoTo SysErr
        Dim tmpAngle As Double = ipAngle
        Dim tmpPosX As Double = PosX
        Dim tmpPosY As Double = PosY

        tmpAngle = ipAngle * Math.PI / 180

        PosX = CDbl(tmpPosX * Math.Cos(tmpAngle) - tmpPosY * Math.Sin(tmpAngle))
        PosY = CDbl(tmpPosY * Math.Cos(tmpAngle) + tmpPosX * Math.Sin(tmpAngle))

        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "RTC6 Adjust Angle Error" & ","
        Return False
    End Function
#End Region

End Class
