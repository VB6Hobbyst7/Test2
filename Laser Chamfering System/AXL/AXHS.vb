Option Strict Off
Option Explicit On
Module AXHS
    '****************************************************************************
    '*****************************************************************************
    '**
    '** File Name
    '** ----------
    '**
    '** AXHS.BAS
    '**
    '** COPYRIGHT (c) AJINEXTEK Co., LTD
    '**
    '*****************************************************************************
    '*****************************************************************************
    '**
    '** Description
    '** -----------
    '** Resource Define Header File
    '** 
    '**
    '*****************************************************************************
    '*****************************************************************************
    '**
    '** Source Change Indices
    '** ---------------------
    '** 
    '** (None)
    '**
    '**
    '*****************************************************************************
    '*****************************************************************************
    '**
    '** Website
    '** ---------------------
    '**
    '** http://www.ajinextek.com
    '**
    '*****************************************************************************
    '*****************************************************************************
    '*

    ' 베이스보드 정의
    Public Const AXT_UNKNOWN As Short = &H0S                                ' Unknown Baseboard
    Public Const AXT_BIHR As Short = &H1S                                   ' ISA bus, Half size
    Public Const AXT_BIFR As Short = &H2S                                   ' ISA bus, Full size
    Public Const AXT_BPHR As Short = &H3S                                   ' PCI bus, Half size
    Public Const AXT_BPFR As Short = &H4S                                   ' PCI bus, Full size
    Public Const AXT_BV3R As Short = &H5S                                   ' VME bus, 3U size
    Public Const AXT_BV6R As Short = &H6S                                   ' VME bus, 6U size
    Public Const AXT_BC3R As Short = &H7S                                   ' cPCI bus, 3U size
    Public Const AXT_BC6R As Short = &H8S                                   ' cPCI bus, 6U size
    Public Const AXT_BEHR As Short = &H9S                                   ' PCIe bus, Half size
    Public Const AXT_BEFR As Short = &HAS                                   ' PCIe bus, Full size
    Public Const AXT_BEHD As Short = &HBS                                   ' PCIe bus, Half size, DB-32T
    Public Const AXT_FMNSH4D As Short = &H52S                               ' ISA bus, Full size, DB-32T, SIO-2V03 * 2
    Public Const AXT_PCI_DI64R As Short = &H43S                             ' PCI bus, Digital IN 64점
    Public Const AXT_PCIE_DI64R As Short = &H44S                            ' PCIe bus, Digital IN 64점
    Public Const AXT_PCI_DO64R As Short = &H53S                             ' PCI bus, Digital OUT 64점
    Public Const AXT_PCIE_DO64R As Short = &H54S                            ' PCIe bus, Digital OUT 64점
    Public Const AXT_PCI_DB64R As Short = &H63S                             ' PCI bus, Digital IN 32점, OUT 32점
    Public Const AXT_PCIE_DB64R As Short = &H64S                            ' PCIe bus, Digital IN 32점, OUT 32점
    Public Const AXT_PCIN204 As Short = &H82S                               ' PCI bus, Half size On-Board 2 Axis controller.
    Public Const AXT_BPHD As Short = &H83S                                  ' PCI bus, Half size, DB-32T
    Public Const AXT_PCIN404 As Short = &H84S                               ' PCI bus, Half size On-Board 4 Axis controller.
    Public Const AXT_PCIN804 As Short = &H85S                               ' PCI bus, Half size On-Board 8 Axis controller.
    Public Const AXT_PCIEN804 As Short = &H86S                              ' PCIe bus, Half size On-Board 8 Axis controller.
    Public Const AXT_PCIEN404 As Short = &H87S                              ' PCIe bus, Half size On-Board 4 Axis controller.
    Public Const AXT_PCI_AIO1602HR As Short = &H93S                         ' PCI bus, Half size, AI-16ch, AO-2ch AI16HR
    Public Const AXT_PCI_R1604 As Short = &HC1S                             ' PCI bus[PCI9030], Half size, RTEX based 16 axis controller
    Public Const AXT_PCI_R3204 As Short = &HC2S                             ' PCI bus[PCI9030], Half size, RTEX based 32 axis controller
    Public Const AXT_PCI_R32IO As Short = &HC3S                             ' PCI bus[PCI9030], Half size, RTEX based IO only.
    Public Const AXT_PCI_REV2 As Short = &HC4S                              ' Reserved.
    Public Const AXT_PCI_R1604MLII As Short = &HC5S                         ' PCI bus[PCI9030], Half size, Mechatrolink-II 16/32 axis controller.
    Public Const AXT_PCI_R0804MLII As Short = &HC6S                         ' PCI bus[PCI9030], Half size, Mechatrolink-II 08 axis controller.
    Public Const AXT_PCI_Rxx00MLIII As Short = &HC7S                        ' Master PCI Board, Mechatrolink III AXT, PCI Bus[PCI9030], Half size, Max.32 Slave module support
    Public Const AXT_PCIE_Rxx00MLIII As Short = &HC8S                       ' Master PCI Express Board, Mechatrolink III AXT, PCI Bus[], Half size, Max.32 Slave module support
    Public Const AXT_PCP2_Rxx00MLIII As Short = &HC9S                       ' Master PCI/104-Plus Board, Mechatrolink III AXT, PCI Bus[], Half size, Max.32 Slave module support
    Public Const AXT_PCI_R1604SIIIH As Short = &HCAS                        ' PCI bus[PCI9030], Half size, SSCNET III / H 16/32 axis controller.
    Public Const AXT_PCI_R32IOEV As Short = &HCBS                           ' PCI bus[PCI9030], Half size, RTEX based IO only. Economic version.
    Public Const AXT_PCIE_R0804RTEX As Short = &HCCS                        ' PCIe bus, Half size, Half size, RTEX based 08 axis controller.
    Public Const AXT_PCIE_R1604RTEX As Short = &HCDS                        ' PCIe bus, Half size, Half size, RTEX based 16 axis controller.
    Public Const AXT_PCIE_R2404RTEX As Short = &HCES                        ' PCIe bus, Half size, Half size, RTEX based 24 axis controller.
    Public Const AXT_PCIE_R3204RTEX As Short = &HCFS                        ' PCIe bus, Half size, Half size, RTEX based 32 axis controller.
    Public Const AXT_PCIE_Rxx04SIIIH As Short = &HD0S                       ' PCIe bus, Half size, SSCNET III / H 16(or 32)-axis(CAMC-QI based) controller.
    Public Const AXT_PCIE_Rxx00SIIIH As Short = &HD1S                       ' PCIe bus, Half size, SSCNET III / H Max. 32-axis(DSP Based) controller.
    
    ' 모듈 정의
    Public Const AXT_SMC_2V01 As Short = &H1S                               ' CAMC-5M, 2 Axis
    Public Const AXT_SMC_2V02 As Short = &H2S                               ' CAMC-FS, 2 Axis
    Public Const AXT_SMC_1V01 As Short = &H3S                               ' CAMC-5M, 1 Axis
    Public Const AXT_SMC_1V02 As Short = &H4S                               ' CAMC-FS, 1 Axis
    Public Const AXT_SMC_2V03 As Short = &H5S                               ' CAMC-IP, 2 Axis
    Public Const AXT_SMC_4V04 As Short = &H6S                               ' CAMC-QI, 4 Axis
    Public Const AXT_SMC_R1V04A4 As Short = &H7S                            ' CAMC-QI, 1 Axis, For RTEX A4 slave only
    Public Const AXT_SMC_1V03 As Short = &H8S                               ' CAMC-IP, 1 Axis
    Public Const AXT_SMC_R1V04 As Short = &H9S                              ' CAMC-QI, 1 Axis, For RTEX SLAVE only
    Public Const AXT_SMC_R1V04MLIISV As Short = &HAS                        ' CAMC-QI, 1 Axis, For Sigma-X series.
    Public Const AXT_SMC_R1V04MLIICL As Short = &HES                        ' CAMC-QI, 1 Axis, For Convex Linear Servo Drive
    Public Const AXT_SMC_R1V04MLIICR As Short = &HFS                        ' CAMC-QI, 1 Axis, For Convex Rotary Servo Drive
    Public Const AXT_SMC_R1V04MLIIPM As Short = &HBS                        ' 2 Axis, For Pulse output series(JEPMC-PL2910).
    Public Const AXT_SMC_2V04 As Short = &HCS                               ' CAMC-QI, 2 Axis
    Public Const AXT_SMC_R1V04A5 As Short = &HDS                            ' CAMC-QI, 1 Axis, For RTEX A5N slave only
    Public Const AXT_SMC_R1V04PM2Q As Short = &H10S                         ' CAMC-QI, 2 Axis, For RTEX SLAVE only(Pulse Output Module)
    Public Const AXT_SMC_R1V04PM2QE As Short = &H11S                        ' CAMC-QI, 4 Axis, For RTEX SLAVE only(Pulse Output Module)
    Public Const AXT_SMC_R1V04MLIIORI As Short = &H12S                      ' CAMC-QI, 1 Axis, For MLII Oriental Step Driver only
    Public Const AXT_SMC_R1V04SIIIHMIV As Short = &H14S                     ' CAMC-QI, 1 Axis, For SSCNETIII/H MRJ4
    Public Const AXT_SMC_R1V04SIIIHMIV_R As Short = &H15S                   ' CAMC-QI, 1 Axis, For SSCNETIII/H MRJ4
    Public Const AXT_SMC_R1V04MLIIISV As Short = &H20S                      ' DSP, 1 Axis, For ML-3 SigmaV/YASKAWA only 
    Public Const AXT_SMC_R1V04MLIIIPM As Short = &H21S                      ' DSP, 1 Axis, For ML-3 SLAVE/AJINEXTEK only(Pulse Output Module)
    Public Const AXT_SMC_R1V04MLIIISV_MD As Short = &H22S                   ' DSP, 1 Axis, For ML-3 SigmaV-MD/YASKAWA only (Multi-Axis Control amp)
    Public Const AXT_SMC_R1V04MLIIIS7S As Short = &H23S                     ' DSP, 1 Axis, For ML-3 Sigma7S/YASKAWA only
    Public Const AXT_SMC_R1V04MLIIIS7W As Short = &H24S                     ' DSP, 2 Axis, For ML-3 Sigma7W/YASKAWA only(Dual-Axis control amp)
    Public Const AXT_SIO_RDI32MLIII As Short = &H70S                        ' DI slave module, MechatroLink III AXT, IN 32-Channel NPN
    Public Const AXT_SIO_RDO32MLIII As Short = &H71S                        ' DO slave module, MechatroLink III AXT, OUT 32-Channel  NPN
    Public Const AXT_SIO_RDB32MLIII As Short = &H72S                        ' DB slave module, MechatroLink III AXT, IN 16-Channel, OUT 16-Channel  NPN
    Public Const AXT_SIO_RDI32MSMLIII As Short = &H73S                      ' DI slave module, MechatroLink III M-SYSTEM, IN 32-Channel
    Public Const AXT_SIO_RDO32AMSMLIII As Short = &H74S                     ' DO slave module, MechatroLink III M-SYSTEM, OUT 32-Channel
    Public Const AXT_SIO_RDI32PMLIII As Short = &H75S                       ' DI slave module, MechatroLink III AXT, IN 32-Channel PNP
    Public Const AXT_SIO_RDO32PMLIII As Short = &H76S                       ' DO slave module, MechatroLink III AXT, OUT 32-Channel  PNP
    Public Const AXT_SIO_RDB32PMLIII As Short = &H77S                       ' DB slave module, MechatroLink III AXT, IN 16-Channel, OUT 16-Channel  PNP
    Public Const AXT_SIO_UNDEFINEMLIII = &H79S                              ' IO slave module, MechatroLink III Any, Max. IN 480-Channel, Max. OUT 480-Channel
    Public Const AXT_SIO_RDB128MLIIIAI = &H7DS                              ' Intelligent I/O (Product by IAI), For MLII only
    Public Const AXT_SIO_RSIMPLEIOMLII As Short = &H7ES                     ' Digital IN/Out xx점, Simple I/O sereies, MLII 전용.
    Public Const AXT_SIO_RDI16MLII As Short = &H80S                         ' DISCRETE INPUT MODULE, 16 points (Product by M-SYSTEM), For MLII only
    Public Const AXT_SIO_RDO16AMLII As Short = &H81S                        ' NPN TRANSISTOR OUTPUT MODULE, 16 points (Product by M-SYSTEM), For MLII only
    Public Const AXT_SIO_RDO16BMLII As Short = &H82S                        ' PNP TRANSISTOR OUTPUT MODULE, 16 points (Product by M-SYSTEM), For MLII only  
    Public Const AXT_SIO_RDB96MLII As Short = &H83S                         ' Digital IN/OUT(Selectable), MAX 96 points, For MLII only
    Public Const AXT_SIO_RDO32RTEX As Short = &H84S                         ' Digital OUT  32점
    Public Const AXT_SIO_RDI32RTEX As Short = &H85S                         ' Digital IN  32점
    Public Const AXT_SIO_RDB32RTEX As Short = &H86S                         ' Digital IN/OUT  32점
    Public Const AXT_SIO_DI32_P As Short = &H92S                            ' Digital IN  32점, PNP type(source type)
    Public Const AXT_SIO_DO32T_P As Short = &H93S                           ' Digital OUT 32점, Power TR, PNT type(source type)
    Public Const AXT_SIO_RDB128MLII As Short = &H94S                        ' Digital IN 64점 / OUT 64점, MLII 전용(JEPMC-IO2310)
    Public Const AXT_SIO_RDI32 As Short = &H95S                             ' Digital IN  32점, For RTEX only
    Public Const AXT_SIO_RDO32 As Short = &H96S                             ' Digital OUT 32점, For RTEX only
    Public Const AXT_SIO_DI32 As Short = &H97S                              ' Digital IN  32점
    Public Const AXT_SIO_DO32P As Short = &H98S                             ' Digital OUT 32점
    Public Const AXT_SIO_DB32P As Short = &H99S                             ' Digital IN 16점 / OUT 16점
    Public Const AXT_SIO_RDB32T As Short = &H9AS                            ' Digital IN 16점 / OUT 16점, For RTEX only
    Public Const AXT_SIO_DO32T As Short = &H9ES                             ' Digital OUT 16점, Power TR 출력
    Public Const AXT_SIO_DB32T As Short = &H9FS                             ' Digital IN 16점 / OUT 16점, Power TR 출력
    Public Const AXT_SIO_AI4RB As Short = &HA1S                             ' A1h(161) : AI 4Ch, 12 bit
    Public Const AXT_SIO_AO4RB As Short = &HA2S                             ' A2h(162) : AO 4Ch, 12 bit
    Public Const AXT_SIO_AI16H As Short = &HA3S                             ' A3h(163) : AI 4Ch, 16 bit
    Public Const AXT_SIO_AO8H As Short = &HA4S                              ' A4h(164) : AO 4Ch, 16 bit
    Public Const AXT_SIO_AI16HB As Short = &HA5S                            ' A5h(165) : AI 16Ch, 16 bit (SIO-AI16HR(input module))
    Public Const AXT_SIO_AO2HB As Short = &HA6S                             ' A6h(166) : AO 2Ch, 16 bit  (SIO-AI16HR(output module))
    Public Const AXT_SIO_RAI8RB As Short = &HA7S                            ' A1h(167) : AI 8Ch, 16 bit, For RTEX only
    Public Const AXT_SIO_RAO4RB As Short = &HA8S                            ' A2h(168) : AO 4Ch, 16 bit, For RTEX only
    Public Const AXT_SIO_RAI4MLII As Short = &HA9S                          ' A9h(169) : AI 4Ch, 16 bit, For MLII only
    Public Const AXT_SIO_RAI16RB As Short = &HA0S                           ' A0h(160) : AI 16Ch, 16 bit, For RTEX only
    Public Const AXT_SIO_RAO2MLII As Short = &HAAS                          ' AAh(170) : AO 2Ch, 16 bit, For MLII only
    Public Const AXT_SIO_RAVCI4MLII As Short = &HABS                        ' DC VOLTAGE/CURRENT INPUT MODULE, 4 points (Product by M-SYSTEM), For MLII only
    Public Const AXT_SIO_RAVO2MLII As Short = &HACS                         ' DC VOLTAGE OUTPUT MODULE, 2 points (Product by M-SYSTEM), For MLII only
    Public Const AXT_SIO_RACO2MLII As Short = &HADS                         ' DC CURRENT OUTPUT MODULE, 2 points (Product by M-SYSTEM), For MLII only
    Public Const AXT_SIO_RATI4MLII As Short = &HAES                         ' THERMOCOUPLE INPUT MODULE, 4 points (Product by M-SYSTEM), For MLII only
    Public Const AXT_SIO_RARTDI4MLII As Short = &HAFS                       ' RTD INPUT MODULE, 4 points (Product by M-SYSTEM), For MLII only
    Public Const AXT_SIO_RCNT2MLII As Short = &HB0S                         ' Counter Module Reversible counter, 2 channels (Product by YASKWA)
    Public Const AXT_SIO_CN2CH As Short = &HB1S                             ' Counter Module, 2 channels, Remapped ID, Actual ID is (0xA8)
    Public Const AXT_SIO_RCNT2RTEX As Short = &HB2S                         ' Counter slave module, Reversible counter, 2 channels, For RTEX Only
    Public Const AXT_SIO_RCNT2MLIII As Short = &HB3S                        ' Counter slave moudle, MechatroLink III AXT, 2 ch, Trigger per channel
    Public Const AXT_SIO_RHPC4MLIII As Short = &HB4S                        ' Counter slave moudle, MechatroLink III AXT, 4 ch
    Public Const AXT_SIO_RAI16RTEX As Short = &HC0S                         ' ANALOG VOLTAGE INPUT(+- 10V) 16 Channel RTEX 
    Public Const AXT_SIO_RAO08RTEX As Short = &HC1S                         ' ANALOG VOLTAGE OUTPUT(+- 10V) 08 Channel RTEX
    Public Const AXT_SIO_RAI8MLIII As Short = &HC2S                         ' AI slave module, MechatroLink III AXT, Analog IN 8ch, 16 bit
    Public Const AXT_SIO_RAI16MLIII As Short = &HC3S                        ' AI slave module, MechatroLink III AXT, Analog IN 16ch, 16 bit
    Public Const AXT_SIO_RAO4MLIII As Short = &HC4S                         ' A0 slave module, MechatroLink III AXT, Analog OUT 4ch, 16 bit
    Public Const AXT_SIO_RAO8MLIII As Short = &HC5S                         ' A0 slave module, MechatroLink III AXT, Analog OUT 8ch, 16 bit
    Public Const AXT_SIO_RAVO4MLII As Short = &HC6S                         ' DC VOLTAGE OUTPUT MODULE, 4 points (Product by M-SYSTEM), For MLII only
    Public Const AXT_COM_234R As Short = &HD3S                              ' COM-234R
    Public Const AXT_COM_484R As Short = &HD4S                              ' COM-484R
    Public Const AXT_SIO_RPI2 As Short = &HD5S                              ' D5h : Pulse counter module(JEPMC-2900)
    Public Const AXT_SIO_HPC4 As Short = &HD6S                              ' D6h : External Encoder module for 4Channel with Trigger function.
    Public Const AXT_SIO_AO4HB As Short = &HD7S                             ' D7h : AO 4Ch, 16 bit
    Public Const AXT_SIO_AI8HB As Short = &HD8S                             ' D8h : AI 8Ch, 16 bit
    Public Const AXT_SIO_AI8AO4HB As Short = &HD9S                          ' D8h : AI 8Ch, AO 4Ch, 16 bit

    ' 에러코드 정의        
    Public Const AXT_RT_SUCCESS As Short = 0                                ' API 함수 수행 성공
    Public Const AXT_RT_OPEN_ERROR As Short = 1001                          ' 라이브러리 오픈 되지않음
    Public Const AXT_RT_OPEN_ALREADY As Short = 1002                        ' 라이브러리 오픈 되어있고 사용 중임
    Public Const AXT_RT_NOT_OPEN As Short = 1053                            ' 라이브러리 초기화 실패
    Public Const AXT_RT_NOT_SUPPORT_VERSION As Short = 1054                 ' 지원하지않는 하드웨어
    Public Const AXT_RT_LOCK_FILE_MISMATCH As Short = 1055                  ' Lock파일과 현재 Scan정보가 일치하지 않음 

    Public Const AXT_RT_INVALID_BOARD_NO As Short = 1101                    ' 유효하지 않는 보드 번호
    Public Const AXT_RT_INVALID_MODULE_POS As Short = 1102                  ' 유효하지 않는 모듈 위치
    Public Const AXT_RT_INVALID_LEVEL As Short = 1103                       ' 유효하지 않는 레벨
    Public Const AXT_RT_INVALID_VARIABLE As Short = 1104                    ' 유효하지 않는 변수
    Public Const AXT_RT_ERROR_VERSION_READ As Short = 1151                  ' 라이브러리 버전을 읽을수 없음
    Public Const AXT_RT_NETWORK_ERROR As Short = 1152                       ' 하드웨어 네트워크 에러
    Public Const AXT_RT_NETWORK_LOCK_MISMATCH As Short = 1153               '  보드 Lock정보와 현재 Scan정보가 일치하지 않음

    Public Const AXT_RT_1ST_BELOW_MIN_VALUE As Short = 1160                 ' 첫번째 인자값이 최소값보다 더 작음
    Public Const AXT_RT_1ST_ABOVE_MAX_VALUE As Short = 1161                 ' 첫번째 인자값이 최대값보다 더 큼
    Public Const AXT_RT_2ND_BELOW_MIN_VALUE As Short = 1170                 ' 두번째 인자값이 최소값보다 더 작음
    Public Const AXT_RT_2ND_ABOVE_MAX_VALUE As Short = 1171                 ' 두번째 인자값이 최대값보다 더 큼
    Public Const AXT_RT_3RD_BELOW_MIN_VALUE As Short = 1180                 ' 세번째 인자값이 최소값보다 더 작음
    Public Const AXT_RT_3RD_ABOVE_MAX_VALUE As Short = 1181                 ' 세번째 인자값이 최대값보다 더 큼
    Public Const AXT_RT_4TH_BELOW_MIN_VALUE As Short = 1190                 ' 네번째 인자값이 최소값보다 더 작음
    Public Const AXT_RT_4TH_ABOVE_MAX_VALUE As Short = 1191                 ' 네번째 인자값이 최대값보다 더 큼
    Public Const AXT_RT_5TH_BELOW_MIN_VALUE As Short = 1200                 ' 다섯번째 인자값이 최소값보다 더 작음
    Public Const AXT_RT_5TH_ABOVE_MAX_VALUE As Short = 1201                 ' 다섯번째 인자값이 최대값보다 더 큼
    Public Const AXT_RT_6TH_BELOW_MIN_VALUE As Short = 1210                 ' 여섯번째 인자값이 최소값보다 더 작음
    Public Const AXT_RT_6TH_ABOVE_MAX_VALUE As Short = 1211                 ' 여섯번째 인자값이 최대값보다 더 큼
    Public Const AXT_RT_7TH_BELOW_MIN_VALUE As Short = 1220                 ' 일곱번째 인자값이 최소값보다 더 작음
    Public Const AXT_RT_7TH_ABOVE_MAX_VALUE As Short = 1221                 ' 일곱번째 인자값이 최대값보다 더 큼
    Public Const AXT_RT_8TH_BELOW_MIN_VALUE As Short = 1230                 ' 여덟번째 인자값이 최소값보다 더 작음
    Public Const AXT_RT_8TH_ABOVE_MAX_VALUE As Short = 1231                 ' 여덟번째 인자값이 최대값보다 더 큼
    Public Const AXT_RT_9TH_BELOW_MIN_VALUE As Short = 1240                 ' 아홉번째 인자값이 최소값보다 더 작음
    Public Const AXT_RT_9TH_ABOVE_MAX_VALUE As Short = 1241                 ' 아홉번째 인자값이 최대값보다 더 큼
    Public Const AXT_RT_10TH_BELOW_MIN_VALUE As Short = 1250                ' 열번째 인자값이 최소값보다 더 작음
    Public Const AXT_RT_10TH_ABOVE_MAX_VALUE As Short = 1251                ' 열번째 인자값이 최대값보다 더 큼

    Public Const AXT_RT_AIO_OPEN_ERROR As Short = 2001                      ' AIO 모듈 오픈실패
    Public Const AXT_RT_AIO_NOT_MODULE As Short = 2051                      ' AIO 모듈 없음
    Public Const AXT_RT_AIO_NOT_EVENT As Short = 2052                       ' AIO 이벤트 읽지 못함
    Public Const AXT_RT_AIO_INVALID_MODULE_NO As Short = 2101               ' 유효하지않은 AIO모듈
    Public Const AXT_RT_AIO_INVALID_CHANNEL_NO As Short = 2102              ' 유효하지않은 AIO채널번호
    Public Const AXT_RT_AIO_INVALID_USE As Short = 2106                     ' AIO 함수 사용못함
    Public Const AXT_RT_AIO_INVALID_TRIGGER_MODE As Short = 2107            ' 유효하지않는 트리거 모드
    Public Const AXT_RT_AIO_EXTERNAL_DATA_EMPTY As Short = 2108
    
    Public Const AXT_RT_DIO_OPEN_ERROR As Short = 3001                      ' DIO 모듈 오픈실패
    Public Const AXT_RT_DIO_NOT_MODULE As Short = 3051                      ' DIO 모듈 없음
    Public Const AXT_RT_DIO_NOT_INTERRUPT As Short = 3052                   ' DIO 인터럽트 설정안됨
    Public Const AXT_RT_DIO_INVALID_MODULE_NO As Short = 3101               ' 유효하지않는 DIO 모듈 번호
    Public Const AXT_RT_DIO_INVALID_OFFSET_NO As Short = 3102               ' 유효하지않는 DIO OFFSET 번호
    Public Const AXT_RT_DIO_INVALID_LEVEL As Short = 3103                   ' 유효하지않는 DIO 레벨
    Public Const AXT_RT_DIO_INVALID_MODE As Short = 3104                    ' 유효하지않는 DIO 모드
    Public Const AXT_RT_DIO_INVALID_VALUE As Short = 3105                   ' 유효하지않는 값 설정
    Public Const AXT_RT_DIO_INVALID_USE As Short = 3106                     ' DIO 함수 사용못함

    Public Const AXT_RT_CNT_OPEN_ERROR As Short = 3201                      ' CNT 모듈 오픈실패
    Public Const AXT_RT_CNT_NOT_MODULE As Short = 3251                      ' CNT 모듈 없음
    Public Const AXT_RT_CNT_NOT_INTERRUPT As Short = 3252                   ' CNT 인터럽트 설정안됨
    Public Const AXT_RT_CNT_INVALID_MODULE_NO As Short = 3301               ' 유효하지않는 CNT 모듈 번호
    Public Const AXT_RT_CNT_INVALID_CHANNEL_NO As Short = 3302              ' 유효하지않는 채널 번호
    Public Const AXT_RT_CNT_INVALID_OFFSET_NO As Short = 3303               ' 유효하지않는 CNT OFFSET 번호
    Public Const AXT_RT_CNT_INVALID_LEVEL As Short = 3304                   ' 유효하지않는 CNT 레벨
    Public Const AXT_RT_CNT_INVALID_MODE As Short = 3305                    ' 유효하지않는 CNT 모드
    Public Const AXT_RT_CNT_INVALID_VALUE As Short = 3306                   ' 유효하지않는 값 설정
    Public Const AXT_RT_CNT_INVALID_USE As Short = 3307                     ' CNT 함수 사용못함

    Public Const AXT_RT_MOTION_OPEN_ERROR As Short = 4001                   ' 모션 라이브러리 Open 실패
    Public Const AXT_RT_MOTION_NOT_MODULE As Short = 4051                   ' 시스템에 장착된 모션 모듈이 없음
    Public Const AXT_RT_MOTION_NOT_INTERRUPT As Short = 4052                ' 인터럽트 결과 읽기 실패
    Public Const AXT_RT_MOTION_NOT_INITIAL_AXIS_NO As Short = 4053          ' 해당 축 모션 초기화 실패
    Public Const AXT_RT_MOTION_NOT_IN_CONT_INTERPOL As Short = 4054         ' 연속 보간 구동 중이 아닌 상태에서 연속보간 중지 명령을 수행 하였음
    Public Const AXT_RT_MOTION_NOT_PARA_READ As Short = 4055                ' 원점 구동 설정 파라미터 로드 실패
    Public Const AXT_RT_MOTION_INVALID_AXIS_NO As Short = 4101              ' 해당 축이 존재하지 않음
    Public Const AXT_RT_MOTION_INVALID_METHOD As Short = 4102               ' 해당 축 구동에 필요한 설정이 잘못됨
    Public Const AXT_RT_MOTION_INVALID_USE As Short = 4103                  ' 'uUse' 인자값이 잘못 설정됨
    Public Const AXT_RT_MOTION_INVALID_LEVEL As Short = 4104                ' 'uLevel' 인자값이 잘못 설정됨
    Public Const AXT_RT_MOTION_INVALID_BIT_NO As Short = 4105               ' 범용 입출력 해당 비트가 잘못 설정됨
    Public Const AXT_RT_MOTION_INVALID_STOP_MODE As Short = 4106            ' 모션 정지 모드 설정값이 잘못됨
    Public Const AXT_RT_MOTION_INVALID_TRIGGER_MODE As Short = 4107         ' 트리거 설정 모드가 잘못 설정됨
    Public Const AXT_RT_MOTION_INVALID_TRIGGER_LEVEL As Short = 4108        ' 트리거 출력 레벨 설정이 잘못됨
    Public Const AXT_RT_MOTION_INVALID_SELECTION As Short = 4109            ' 'uSelection' 인자가 COMMAND 또는 ACTUAL 이외의 값으로 설정되어 있음
    Public Const AXT_RT_MOTION_INVALID_TIME As Short = 4110                 ' Trigger 출력 시간값이 잘못 설정되어 있음
    Public Const AXT_RT_MOTION_INVALID_FILE_LOAD As Short = 4111            ' 모션 설정값이 저장된 파일이 로드가 안됨
    Public Const AXT_RT_MOTION_INVALID_FILE_SAVE As Short = 4112            ' 모션 설정값을 저장하는 파일 저장에 실패함
    Public Const AXT_RT_MOTION_INVALID_VELOCITY As Short = 4113             ' 모션 구동 속도값이 0으로 설정되어 모션 에러 발생
    Public Const AXT_RT_MOTION_INVALID_ACCELTIME As Short = 4114            ' 모션 구동 가속 시간값이 0으로 설정되어 모션 에러 발생
    Public Const AXT_RT_MOTION_INVALID_PULSE_VALUE As Short = 4115          ' 모션 단위 설정 시 입력 펄스값이 0보다 작은값으로 설정됨
    Public Const AXT_RT_MOTION_INVALID_NODE_NUMBER As Short = 4116          ' 위치나 속도 오버라이드 함수가 모션 정지 중에 실햄됨
    Public Const AXT_RT_MOTION_INVALID_TARGET As Short = 4117               ' 다축 모션 정지 원인에 관한 플래그를 반환한다.

    Public Const AXT_RT_MOTION_ERROR_IN_NONMOTION As Short = 4151           ' 모션 구동중이어야 되는데 모션 구동중이 아닐 때
    Public Const AXT_RT_MOTION_ERROR_IN_MOTION As Short = 4152              ' 모션 구동 중에 다른 모션 구동 함수를 실행함
    Public Const AXT_RT_MOTION_ERROR As Short = 4153                        ' 다축 구동 정지 함수 실행 중 에러 발생함
    Public Const AXT_RT_MOTION_ERROR_GANTRY_ENABLE As Short = 4154          ' 겐트리 enable이 되어있어 모션중일 때 또 겐트리 enable을 눌렀을 때
    Public Const AXT_RT_MOTION_ERROR_GANTRY_AXIS As Short = 4155            ' 겐트리 축이 마스터채널(축) 번호(0 ~ (최대축수 - 1))가 잘못 들어갔을 때
    Public Const AXT_RT_MOTION_ERROR_MASTER_SERVOON As Short = 4156         ' 마스터 축 서보온이 안되어있을 때
    Public Const AXT_RT_MOTION_ERROR_SLAVE_SERVOON As Short = 4157          ' 슬레이브 축 서보온이 안되어있을 때
    Public Const AXT_RT_MOTION_INVALID_POSITION As Short = 4158             ' 유효한 위치에 없을 때
    Public Const AXT_RT_ERROR_NOT_SAME_MODULE As Short = 4159               ' 똑 같은 모듈내에 있지 않을경우
    Public Const AXT_RT_ERROR_NOT_SAME_BOARD As Short = 4160                ' 똑 같은 보드내에 있지 아닐경우
    Public Const AXT_RT_ERROR_NOT_SAME_PRODUCT As Short = 4161              ' 제품이 서로 다를경우
    Public Const AXT_RT_NOT_CAPTURED As Short = 4162                        ' 위치가 저장되지 않을 때
    Public Const AXT_RT_ERROR_NOT_SAME_IC As Short = 4163                   ' 같은 칩내에 존재하지않을 때
    Public Const AXT_RT_ERROR_NOT_GEARMODE As Short = 4164                  ' 기어모드로 변환이 안될 때
    Public Const AXT_ERROR_CONTI_INVALID_AXIS_NO As Short = 4165            ' 연속보간 축맵핑 시 유효한 축이 아닐 때
    Public Const AXT_ERROR_CONTI_INVALID_MAP_NO As Short = 4166             ' 연속보간 맵핑 시 유효한 맵핑 번호가 아닐 때
    Public Const AXT_ERROR_CONTI_EMPTY_MAP_NO As Short = 4167               ' 연속보간 맵핑 번호가 비워 있을 때
    Public Const AXT_RT_MOTION_ERROR_CACULATION As Short = 4168             ' 계산상의 오차가 발생했을 때
    Public Const AXT_RT_ERROR_MOVE_SENSOR_CHECK As Short = 4169             ' 연속보간 구동전 에러센서가(Alarm, EMG, Limit등) 감지된경우

    Public Const AXT_ERROR_HELICAL_INVALID_AXIS_NO As Short = 4170          ' 헬리컬 축 맵핑 시 유효한 축이 아닐 때
    Public Const AXT_ERROR_HELICAL_INVALID_MAP_NO As Short = 4171           ' 헬리컬 맵핑 시 유효한 맵핑 번호가 아닐  때
    Public Const AXT_ERROR_HELICAL_EMPTY_MAP_NO As Short = 4172             ' 헬리컬 멥핑 번호가 비워 있을 때

    Public Const AXT_ERROR_SPLINE_INVALID_AXIS_NO As Short = 4180           ' 스플라인 축 맵핑 시 유효한 축이 아닐 때
    Public Const AXT_ERROR_SPLINE_INVALID_MAP_NO As Short = 4181            ' 스플라인 맵핑 시 유효한 맵핑 번호가 아닐 때
    Public Const AXT_ERROR_SPLINE_EMPTY_MAP_NO As Short = 4182              ' 스플라인 맵핑 번호가 비워있을 때
    Public Const AXT_ERROR_SPLINE_NUM_ERROR As Short = 4183                 ' 스플라인 점숫자가 부적당할 때
    Public Const AXT_RT_MOTION_INTERPOL_VALUE As Short = 4184               ' 보간할 때 입력 값이 잘못넣어졌을 때
    Public Const AXT_RT_ERROR_NOT_CONTIBEGIN As Short = 4185                ' 연속보간 할 때 CONTIBEGIN함수를 호출하지 않을 때
    Public Const AXT_RT_ERROR_NOT_CONTIEND As Short = 4186                  ' 연속보간 할 때 CONTIEND함수를 호출하지 않을 때

    Public Const AXT_RT_MOTION_HOME_SEARCHING As Short = 4201               ' 홈을 찾고 있는 중일 때 다른 모션 함수들을 사용할 때
    Public Const AXT_RT_MOTION_HOME_ERROR_SEARCHING As Short = 4202         ' 홈을 찾고 있는 중일 때 외부에서 사용자나 혹은 어떤것에 의한 강제로 정지당할 때
    Public Const AXT_RT_MOTION_HOME_ERROR_START As Short = 4203             ' 초기화 문제로 홈시작 불가할 때
    Public Const AXT_RT_MOTION_HOME_ERROR_GANTRY As Short = 4204            ' 홈을 찾고 있는 중일 때 겐트리 enable 불가할 때

    Public Const AXT_RT_MOTION_READ_ALARM_WAITING As Short = 4210           ' 서보팩으로부터 알람코드 결과를 기다리는 중
    Public Const AXT_RT_MOTION_READ_ALARM_NO_REQUEST As Short = 4211        ' 서보팩에 알람코드 반환 명령이 내려지지않았을 때
    Public Const AXT_RT_MOTION_READ_ALARM_TIMEOUT As Short = 4212           ' 서보팩 알람읽기 시간초과 했을때(1sec이상)
    Public Const AXT_RT_MOTION_READ_ALARM_FAILED As Short = 4213            ' 서보팩 알람읽기에 실패 했을 때
    Public Const AXT_RT_MOTION_READ_ALARM_UNKNOWN As Short = 4220           ' 알람코드가 알수없는 코드일 때
    Public Const AXT_RT_MOTION_READ_ALARM_FILES As Short = 4221             ' 알람정보 파일이 정해진위치에 존재하지 않을 때

    Public Const AXT_RT_MOTION_POSITION_OUTOFBOUND As Short = 4251          ' 설정한 위치값이 설정 최대값보다 크거나 최소값보다 작은값임
    Public Const AXT_RT_MOTION_PROFILE_INVALID As Short = 4252              ' 구동 속도 프로파일 설정이 잘못됨
    Public Const AXT_RT_MOTION_VELOCITY_OUTOFBOUND As Short = 4253          ' 구동 속도값이 최대값보다 크게 설정됨
    Public Const AXT_RT_MOTION_MOVE_UNIT_IS_ZERO As Short = 4254            ' 구동 단위값이 0으로 설정됨
    Public Const AXT_RT_MOTION_SETTING_ERROR As Short = 4255                ' 속도, 가속도, 저크, 프로파일 설정이 잘못됨
    Public Const AXT_RT_MOTION_IN_CONT_INTERPOL As Short = 4256             ' 연속 보간 구동 중 구동 시작 또는 재시작 함수를 실행하였음
    Public Const AXT_RT_MOTION_DISABLE_TRIGGER As Short = 4257              ' 트리거 출력이 Disable 상태임
    Public Const AXT_RT_MOTION_INVALID_CONT_INDEX As Short = 4258           ' 연속 보간 Index값 설정이 잘못됨
    Public Const AXT_RT_MOTION_CONT_QUEUE_FULL As Short = 4259              ' 모션 칩의 연속 보간 큐가 Full 상태임
    Public Const AXT_RT_PROTECTED_DURING_SERVOON As Short = 4260            ' 서보 온 되어 있는 상태에서 사용 못 함
    Public Const AXT_RT_HW_ACCESS_ERROR As Short = 4261                     ' 메모리 Read / Write 실패

    Public Const AXT_RT_HW_DPRAM_CMD_WRITE_ERROR_LV1 As Short = 4262        ' DPRAM Comamnd Write 실패 Level1
    Public Const AXT_RT_HW_DPRAM_CMD_WRITE_ERROR_LV2 As Short = 4263        ' DPRAM Comamnd Write 실패 Level2 
    Public Const AXT_RT_HW_DPRAM_CMD_WRITE_ERROR_LV3 As Short = 4264        ' DPRAM Comamnd Write 실패 Level3 
    Public Const AXT_RT_HW_DPRAM_CMD_READ_ERROR_LV1 As Short = 4265         ' DPRAM Comamnd Read 실패 Level1  
    Public Const AXT_RT_HW_DPRAM_CMD_READ_ERROR_LV2 As Short = 4266         ' DPRAM Comamnd Read 실패 Level2  
    Public Const AXT_RT_HW_DPRAM_CMD_READ_ERROR_LV3 As Short = 4267         ' DPRAM Comamnd Read 실패 Level3  

    Public Const AXT_RT_COMPENSATION_SET_PARAM_FIRST As Short = 4300

    Public Const AXT_RT_SEQ_NOT_IN_SERVICE As Short = 4400                  ' 순차 구동 함수 실행 중 자원 할당 실패
    Public Const AXT_ERROR_SEQ_INVALID_MAP_NO As Short = 4401               ' 순차 구동 함수 실행 중 맵핑 번호 이상.
    Public Const AXT_ERROR_INVALID_AXIS_NO As Short = 4402                  ' 함수 설정 인자중 축번호 이상.
    Public Const AXT_RT_ERROR_NOT_SEQ_NODE_BEGIN As Short = 4403            ' 순차 구동 노드 입력 시작 함수를 호출하지 않음.
    Public Const AXT_RT_ERROR_NOT_SEQ_NODE_END As Short = 4404              ' 순차 구동 노드 입력 종료 함수를 호출하지 않음.
    Public Const AXT_RT_ERROR_NO_NODE As Short = 4405                       ' 순차 구동 노드 입력이 없음.
    Public Const AXT_RT_ERROR_SEQ_STOP_TIMEOUT As Short = 4406

    Public Const AXT_RT_M3_COMMUNICATION_FAILED As Short = 4500             ' ML3 통신 기준, 통신 실패
    Public Const AXT_RT_MOTION_ONE_OF_AXES_IS_NOT_M3 As Short = 4501        ' ML3 통신 기준, 구성된 ML3 노드 중에서 모션 노드 없음 
    Public Const AXT_RT_MOTION_BIGGER_VEL_THEN_MAX_VEL As Short = 4502      ' ML3 통신 기준, 지정된 축의 설정된 최대 속도보다 큼
    Public Const AXT_RT_MOTION_SMALLER_VEL_THEN_MAX_VEL As Short = 4503     ' ML3 통신 기준, 지정된 축의 설정된 최대 속도보다 작음
    Public Const AXT_RT_MOTION_ACCEL_MUST_BIGGER_THEN_ZERO As Short = 4504  ' ML3 통신 기준, 지정된 축의 설정된 가속도가 0보다 큼
    Public Const AXT_RT_MOTION_SMALL_ACCEL_WITH_UNIT_PULSE As Short = 4505  ' ML3 통신 기준, UnitPulse가 적용된 가속도가 0보다 큼
    Public Const AXT_RT_MOTION_INVALID_INPUT_ACCEL As Short = 4506          ' ML3 통신 기준, 지정된 축의 가속도 입력이 잘못됨
    Public Const AXT_RT_MOTION_SMALL_DECEL_WITH_UNIT_PULSE As Short = 4507  ' ML3 통신 기준, UnitPulse가 적용된 감속도가 0보다 큼
    Public Const AXT_RT_MOTION_INVALID_INPUT_DECEL As Short = 4508          ' ML3 통신 기준, 지정된 축의 감속도 입력이 잘못됨
    Public Const AXT_RT_MOTION_SAME_START_AND_CENTER_POS As Short = 4509    ' ML3 통신 기준, 원호보간의 시작점과 중심점이 같음
    Public Const AXT_RT_MOTION_INVALID_JERK As Short = 4510                 ' ML3 통신 기준, 지정된 축의 저크 입력이 잘못됨
    Public Const AXT_RT_MOTION_INVALID_INPUT_VALUE As Short = 4511          ' ML3 통신 기준, 지정된 축의 입력값이 잘못됨
    Public Const AXT_RT_MOTION_NOT_SUPPORT_PROFILE As Short = 4512          ' ML3 통신 기준, 제공되지 않는 속도 프로파일임
    Public Const AXT_RT_MOTION_INPOS_UNUSED As Short = 4513                 ' ML3 통신 기준, 인포지션 사용하지 않음
    Public Const AXT_RT_MOTION_AXIS_IN_SLAVE_STATE As Short = 4514          ' ML3 통신 기준, 지정된 축이 슬레이브 상태가 아님
    Public Const AXT_RT_MOTION_AXES_ARE_NOT_SAME_BOARD As Short = 4515      ' ML3 통신 기준, 지정된 축들이 같은 보드 내에 있지 않음
    Public Const AXT_RT_MOTION_ERROR_IN_ALARM As Short = 4516               ' ML3 통신 기준, 지정된 축이 알람 상태임
    Public Const AXT_RT_MOTION_ERROR_IN_EMGN As Short = 4517                ' ML3 통신 기준, 지정된 축이 비상정지 상태임
    Public Const AXT_RT_MOTION_CAN_NOT_CHANGE_COORD_NO As Short = 4518      ' ML3 통신 기준, 코디네이터 넘버 변환 불가임
    Public Const AXT_RT_MOTION_INVALID_INTERNAL_RADIOUS As Short = 4519     ' ML3 통신 기준, 원호보간의 X, Y축 반지름 불일치
    Public Const AXT_RT_MOTION_CONTI_QUEUE_FULL As Short = 4521             ' ML3 통신 기준, 보간의 큐가 가득 참
    Public Const AXT_RT_MOTION_SAME_START_AND_END_POSITION As Short = 4522  ' ML3 통신 기준, 원호보간의 시작점과 종료점이 같음
    Public Const AXT_RT_MOTION_INVALID_ANGLE As Short = 4523                ' ML3 통신 기준, 원호보간의 각도가 360도 초과됨
    Public Const AXT_RT_MOTION_CONTI_QUEUE_EMPTY As Short = 4524            ' ML3 통신 기준, 보간의 큐가 비어있음
    Public Const AXT_RT_MOTION_ERROR_GEAR_ENABLE As Short = 4525            ' ML3 통신 기준, 지정된 축이 이미 링크 설정 상태임
    Public Const AXT_RT_MOTION_ERROR_GEAR_AXIS As Short = 4526              ' ML3 통신 기준, 지정된 축이 링크축이 아님
    Public Const AXT_RT_MOTION_ERROR_NO_GANTRY_ENABLE As Short = 4527       ' ML3 통신 기준, 지정된 축이 겐트리 설정 상태가 아님
    Public Const AXT_RT_MOTION_ERROR_NO_GEAR_ENABLE As Short = 4528         ' ML3 통신 기준, 지정된 축이 링크 설정 상태가 아님
    Public Const AXT_RT_MOTION_ERROR_GANTRY_ENABLE_FULL As Short = 4529     ' ML3 통신 기준, 겐트리 설정 가득참
    Public Const AXT_RT_MOTION_ERROR_GEAR_ENABLE_FULL As Short = 4530       ' ML3 통신 기준, 링크 설정 가득참
    Public Const AXT_RT_MOTION_ERROR_NO_GANTRY_SLAVE As Short = 4531        ' ML3 통신 기준, 지정된 축이 겐트리 슬레이브 설정상태가 아님
    Public Const AXT_RT_MOTION_ERROR_NO_GEAR_SLAVE As Short = 4532          ' ML3 통신 기준, 지정된 축이 링크 슬레이브 설정상태가 아님
    Public Const AXT_RT_MOTION_ERROR_MASTER_SLAVE_SAME As Short = 4533      ' ML3 통신 기준, 마스터축과 슬레이브 축이 동일함
    Public Const AXT_RT_MOTION_NOT_SUPPORT_HOMESIGNAL As Short = 4534       ' ML3 통신 기준, 지정된 축의 홈신호는 지원되지 않음
    Public Const AXT_RT_MOTION_ERROR_NOT_SYNC_CONNECT As Short = 4535       ' ML3 통신 기준, 지정된 축이 싱크 연결 상태가 아님
    Public Const AXT_RT_MOTION_OVERFLOW_POSITION As Short = 4536            ' ML3 통신 기준, 지정된 축에 대한 구동 위치값이 오버플로우임
    Public Const AXT_RT_MOTION_ERROR_INVALID_CONTIMAPAXIS As Short = 4537   ' ML3 통신 기준, 보간작업을 위한 지정된 좌표계 축맵핑이 없음
    Public Const AXT_RT_MOTION_ERROR_INVALID_CONTIMAPSIZE As Short = 4538   ' ML3 통신 기준, 보간작업을 ㅜ이한 지정된 좌표계 축맵핑 축사이즈가 잘못됨
    Public Const AXT_RT_MOTION_ERROR_IN_SERVO_OFF As Short = 4539           ' ML3 통신 기준, 지정된 축이 서보 OFF되어 있음
    Public Const AXT_RT_MOTION_ERROR_POSITIVE_LIMIT As Short = 4540         ' ML3 통신 기준, 지정된 축이 (+)리밋 ON되어 있음
    Public Const AXT_RT_MOTION_ERROR_NEGATIVE_LIMIT As Short = 4541         ' ML3 통신 기준, 지정된 축이 (-)리밋 ON되어 있음
    Public Const AXT_RT_MOTION_ERROR_OVERFLOW_SWPROFILE_NUM As Short = 4542 ' ML3 통신 기준, 지정된 축들에 대한 지원 프로파일 개수가 오버플로우됨
    Public Const AXT_RT_PROTECTED_DURING_INMOTION As Short = 4543           ' in_motion 되어 있는 상태에서 사용 못 함
    
    Public Const AXT_RT_DATA_FLASH_NOT_EXIST As Short = 5000
    Public Const AXT_RT_DATA_FLASH_BUSY As Short = 5001

    Public Const WM_USER As Short = &H400S
    Public Const WM_AXL_INTERRUPT As Integer = (WM_USER + 1001)

    Public Const LEVEL_NONE As Short = 0
    Public Const LEVEL_ERROR As Short = 1
    Public Const LEVEL_RUNSTOP As Short = 2
    Public Const LEVEL_FUNCTION As Short = 3

    Public Const STATUS_NOTEXIST As Short = 0
    Public Const STATUS_EXIST As Short = 1

    Public Const DISABLE As Short = 0
    Public Const ENABLE As Short = 1

    Public Const DISABLE_MODE As Short = 0
    Public Const NORMAL_MODE As Short = 1
    Public Const TIMER_MODE As Short = 2
    Public Const EXTERNAL_MODE As Short = 3

    Public Const NEW_DATA_KEEP As Short = 0
    Public Const CURR_DATA_KEEP As Short = 1

    Public Const DATA_EMPTY As Short = &H1S
    Public Const DATA_MANY As Short = &H2S
    Public Const DATA_SMALL As Short = &H4S
    Public Const DATA_FULL As Short = &H8S

    Public Const ADC_DONE As Short = &H0S
    Public Const SCAN_END As Short = &H1S
    Public Const FIFO_HALF_FULL As Short = &H2S
    Public Const NO_SIGNAL As Short = &H3S

    Public Const AIO_EVENT_DATA_RESET As Short = &H0S
    Public Const AIO_EVENT_DATA_UPPER As Short = &H1S
    Public Const AIO_EVENT_DATA_LOWER As Short = &H2S
    Public Const AIO_EVENT_DATA_FULL As Short = &H3S
    Public Const AIO_EVENT_DATA_EMPTY As Short = &H4S

    ' AI Module H/W FIFO 상태 정의
    Public Const FIFO_DATA_EXIST As Short = 0
    Public Const FIFO_DATA_EMPTY As Short = 1
    Public Const FIFO_DATA_HALF As Short = 2
    Public Const FIFO_DATA_FULL As Short = 6
    ' AI Module Conversion 상태정의
    Public Const EXTERNAL_DATA_DONE As Short = 0
    Public Const EXTERNAL_DATA_FINE As Short = 1
    Public Const EXTERNAL_DATA_HALF As Short = 2
    Public Const EXTERNAL_DATA_FULL As Short = 3
    Public Const EXTERNAL_COMPLETE As Short = 4

    Public Const DOWN_EDGE As Short = 0
    Public Const UP_EDGE As Short = 1

    Public Const OFF_STATE As Short = 0
    Public Const ON_STATE As Short = 1

    Public Const EMERGENCY_STOP As Short = 0
    Public Const SLOWDOWN_STOP As Short = 1

    Public Const SIGNAL_DOWN_EDGE As Short = 0
    Public Const SIGNAL_UP_EDGE As Short = 1
    Public Const SIGNAL_LOW_LEVEL As Short = 2
    Public Const SIGNAL_HIGH_LEVEL As Short = 3

    Public Const COMMAND_Renamed As Short = 0
    Public Const ACTUAL As Short = 1

    Public Const PERIOD_MODE As Short = 0
    Public Const ABS_POS_MODE As Short = 1
    Public Const POS_ABS_LONG_MODE As Short = 2

    Public Const LOW As Short = 0
    Public Const HIGH As Short = 1
    Public Const UNUSED As Short = 2
    Public Const USED As Short = 3

    Public Const POS_ABS_MODE As Short = 0
    Public Const POS_REL_MODE As Short = 1

    Public Const SYM_TRAPEZOIDE_MODE As Short = 0
    Public Const ASYM_TRAPEZOIDE_MODE As Short = 1
    Public Const QUASI_S_CURVE_MODE As Short = 2
    Public Const SYM_S_CURVE_MODE As Short = 3
    Public Const ASYM_S_CURVE_MODE As Short = 4

    Public Const INACTIVE As Short = 0
    Public Const ACTIVE As Short = 1

    Public Const HOME_RESERVED As Short = &H0S                              ' ML3
    Public Const HOME_SUCCESS As Short = &H1S                               ' 원점 검색 완료
    Public Const HOME_SEARCHING As Short = &H2S                             ' 원점 검색 완료
    Public Const HOME_ERR_GNT_RANGE As Short = &H10S                        ' 원점 검색 중
    Public Const HOME_ERR_USER_BREAK As Short = &H11S                       ' 갠트리 원점 검색 기준, 두 축 사이의 설정이상 오차 발생
    Public Const HOME_ERR_VELOCITY As Short = &H12S                         ' 원점 검색 사용자 중지시
    Public Const HOME_ERR_AMP_FAULT As Short = &H13S                        ' 원점 검색 속도 이상 에러 발생 서보팩 알람 발생 에러
    Public Const HOME_ERR_NEG_LIMIT As Short = &H14S                        ' (-)방향 구동중 (+)리미트 센서 감지 에러
    Public Const HOME_ERR_POS_LIMIT As Short = &H15S                        ' (+)방향 구동중 (-)리미트 센서 감지 에러
    Public Const HOME_ERR_NOT_DETECT As Short = &H16S                       ' 지정한 신호 검출하지 못 할 경우 에러
    Public Const HOME_ERR_SETTING As Short = &H17S                          ' 사용자 설정 파라미터가 구동시 제약 조건 발생시
    Public Const HOME_ERR_TIMEOUT As Short = &H20S                          ' 지정된 시간 초과 발생으로 오류 발생 
    Public Const HOME_ERR_FUNCALL As Short = &H30S                          ' 함수 호출 실패
    Public Const HOME_ERR_COUPLING As Short = &H40S                         ' Gantry Master to Slave Over Distance protection
    Public Const HOME_ERR_UNKNOWN As Short = &HFFS                          ' 미지정 에러

    Public Const UIO_INP0 As Short = 0
    Public Const UIO_INP1 As Short = 1
    Public Const UIO_INP2 As Short = 2
    Public Const UIO_INP3 As Short = 3
    Public Const UIO_INP4 As Short = 4
    Public Const UIO_INP5 As Short = 5

    Public Const UIO_OUT0 As Short = 0
    Public Const UIO_OUT1 As Short = 1
    Public Const UIO_OUT2 As Short = 2
    Public Const UIO_OUT3 As Short = 3
    Public Const UIO_OUT4 As Short = 4
    Public Const UIO_OUT5 As Short = 5

    Public Const AutoDetect As Short = 0
    Public Const RestPulse As Short = 1

    ' Pulse Output Method
    Public Const OneHighLowHigh As Short = &H0S                             ' 1펄스 방식, PULSE(Active High), 정방향(DIR=Low)  / 역방향(DIR=High)
    Public Const OneHighHighLow As Short = &H1S                             ' 1펄스 방식, PULSE(Active High), 정방향(DIR=High) / 역방향(DIR=Low)
    Public Const OneLowLowHigh As Short = &H2S                              ' 1펄스 방식, PULSE(Active Low),  정방향(DIR=Low)  / 역방향(DIR=High)
    Public Const OneLowHighLow As Short = &H3S                              ' 1펄스 방식, PULSE(Active Low),  정방향(DIR=High) / 역방향(DIR=Low)
    Public Const TwoCcwCwHigh As Short = &H4S                               ' 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active High
    Public Const TwoCcwCwLow As Short = &H5S                                ' 2펄스 방식, PULSE(CCW:역방향),  DIR(CW:정방향),  Active Low
    Public Const TwoCwCcwHigh As Short = &H6S                               ' 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active High
    Public Const TwoCwCcwLow As Short = &H7S                                ' 2펄스 방식, PULSE(CW:정방향),   DIR(CCW:역방향), Active Low
    Public Const TwoPhase As Short = &H8S                                   ' 2상(90' 위상차),  PULSE lead DIR(CW: 정방향), PULSE lag DIR(CCW:역방향)
    Public Const TwoPhaseReverse As Short = &H9S                            ' 2상(90' 위상차),  PULSE lead DIR(CCW: 정방향), PULSE lag DIR(CW:역방향)

    ' Mode2 Data External Counter Input
    Public Const ObverseUpDownMode As Short = &H0S                          ' 정방향 Up/Down
    Public Const ObverseSqr1Mode As Short = &H1S                            ' 정방향 1체배
    Public Const ObverseSqr2Mode As Short = &H2S                            ' 정방향 2체배
    Public Const ObverseSqr4Mode As Short = &H3S                            ' 정방향 4체배
    Public Const ReverseUpDownMode As Short = &H4S                          ' 역방향 Up/Down
    Public Const ReverseSqr1Mode As Short = &H5S                            ' 역방향 1체배
    Public Const ReverseSqr2Mode As Short = &H6S                            ' 역방향 2체배
    Public Const ReverseSqr4Mode As Short = &H7S                            ' 역방향 4체배

    Public Const UNIT_SEC2 As Short = &H0S                                  ' unit/sec2
    Public Const SEC As Short = &H1S                                        ' sec

    Public Const DIR_CCW As Short = &H0S                                    ' 반시계방향
    Public Const DIR_CW As Short = &H1S                                     ' 시계방향

    Public Const SHORT_DISTANCE As Short = &H0S                             ' 짧은 거리의 원호 이동
    Public Const LONG_DISTANCE As Short = &H1S                              ' 긴 거리의 원호 이동

    Public Const POSITION_LIMIT As Short = &H0S                             ' 전체 영역사용
    Public Const POSITION_BOUND As Short = &H1S                             ' Pos 지정 사용

    Public Const INTERPOLATION_AXIS2 As Short = &H0S                        ' 2축을 보간으로 사용할 때
    Public Const INTERPOLATION_AXIS3 As Short = &H1S                        ' 3축을 보간으로 사용할 때
    Public Const INTERPOLATION_AXIS4 As Short = &H2S                        ' 4축을 보간으로 사용할 때

    Public Const CONTI_NODE_VELOCITY As Short = &H0S                        ' 속도 지정 보간 모드
    Public Const CONTI_NODE_MANUAL As Short = &H1S                          ' 노드 가감속 보간 모드
    Public Const CONTI_NODE_AUTO As Short = &H2S                            ' 자동 가감속 보간 모드

    Public Const PosEndLimit As Short = &H0S                                ' +Elm(End limit) +방향 리미트 센서 신호
    Public Const NegEndLimit As Short = &H1S                                ' -Elm(End limit) -방향 리미트 센서 신호
    Public Const PosSloLimit As Short = &H2S                                ' +Slm(Slow Down limit) 신호 - 사용하지 않음
    Public Const NegSloLimit As Short = &H3S                                ' -Slm(Slow Down limit) 신호 - 사용하지 않음
    Public Const HomeSensor As Short = &H4S                                 ' IN0(ORG)  원점 센서 신호
    Public Const EncodZPhase As Short = &H5S                                ' IN1(Z상)  Encoder Z상 신호
    Public Const UniInput02 As Short = &H6S                                 ' IN2(범용) 범용 입력 2번 신호
    Public Const UniInput03 As Short = &H7S                                 ' IN3(범용) 범용 입력 3번 신호
    Public Const UniInput04 As Short = &H8S                                 ' IN4(범용) 범용 입력 4번 신호
    Public Const UniInput05 As Short = &H9S                                 ' IN5(범용) 범용 입력 5번 신호

    Public Const END_LIMIT As Short = &H10S                                 ' End limit +/-방향 리미트 센서 신호
    Public Const INP_ALARM As Short = &H11S                                 ' Inposition/Alarm 신호
    Public Const UIN_00_01 As Short = &H12S                                 ' Home/Z-Phase 신호
    Public Const UIN_02_04 As Short = &H13S                                 ' UIN 2, 3, 4 신호

    Public Const MPG_DIFF_ONE_PHASE As Short = &H0S                         ' MPG 입력 방식 One Phase
    Public Const MPG_DIFF_TWO_PHASE_1X As Short = &H1S                      ' MPG 입력 방식 TwoPhase1
    Public Const MPG_DIFF_TWO_PHASE_2X As Short = &H2S                      ' MPG 입력 방식 TwoPhase2
    Public Const MPG_DIFF_TWO_PHASE_4X As Short = &H3S                      ' MPG 입력 방식 TwoPhase4
    Public Const MPG_LEVEL_ONE_PHASE As Short = &H4S                        ' MPG 입력 방식 Level One Phase
    Public Const MPG_LEVEL_TWO_PHASE_1X As Short = &H5S                     ' MPG 입력 방식 Level Two Phase1
    Public Const MPG_LEVEL_TWO_PHASE_2X As Short = &H6S                     ' MPG 입력 방식 Level Two Phase2
    Public Const MPG_LEVEL_TWO_PHASE_4X As Short = &H7S                     ' MPG 입력 방식 Level Two Phase4

    Public Const SENSOR_METHOD1 As Short = &H0S                             ' 일반 구동
    Public Const SENSOR_METHOD2 As Short = &H1S                             ' 센서 신호 검출 전은 저속 구동. 신호 검출 후 일반 구동
    Public Const SENSOR_METHOD3 As Short = &H2S                             ' 저속 구동

    Public Const CRC_SELECT1 As Short = &H0S                                ' 위치클리어 사용않함, 잔여펄스 클리어 사용 안함
    Public Const CRC_SELECT2 As Short = &H1S                                ' 위치클리어 사용함, 잔여펄스 클리어 사용 안함
    Public Const CRC_SELECT3 As Short = &H2S                                ' 위치클리어 사용안함, 잔여펄스 클리어 사용함
    Public Const CRC_SELECT4 As Short = &H3S                                ' 위치클리어 사용함, 잔여펄스 클리어 사용함

    ' Detect Destination Signal
    Public Const PElmNegativeEdge As Short = &H0S                           ' +Elm(End limit) 하강 edge
    Public Const NElmNegativeEdge As Short = &H1S                           ' -Elm(End limit) 하강 edge
    Public Const PSlmNegativeEdge As Short = &H2S                           ' +Slm(Slowdown limit) 하강 edge
    Public Const NSlmNegativeEdge As Short = &H3S                           ' -Slm(Slowdown limit) 하강 edge
    Public Const In0DownEdge As Short = &H4S                                ' IN0(ORG) 하강 edge
    Public Const In1DownEdge As Short = &H5S                                ' IN1(Z상) 하강 edge
    Public Const In2DownEdge As Short = &H6S                                ' IN2(범용) 하강 edge
    Public Const In3DownEdge As Short = &H7S                                ' IN3(범용) 하강 edge
    Public Const PElmPositiveEdge As Short = &H8S                           ' +Elm(End limit) 상승 edge
    Public Const NElmPositiveEdge As Short = &H9S                           ' -Elm(End limit) 상승 edge
    Public Const PSlmPositiveEdge As Short = &HAS                           ' +Slm(Slowdown limit) 상승 edge
    Public Const NSlmPositiveEdge As Short = &HBS                           ' -Slm(Slowdown limit) 상승 edge
    Public Const In0UpEdge As Short = &HCS                                  ' IN0(ORG) 상승 edge
    Public Const In1UpEdge As Short = &HDS                                  ' IN1(Z상) 상승 edge
    Public Const In2UpEdge As Short = &HES                                  ' IN2(범용) 상승 edge
    Public Const In3UpEdge As Short = &HFS                                  ' IN3(범용) 상승 edge

    ' IP End status : 0x0000이면 정상종료
    Public Const IPEND_STATUS_SLM As Short = &H1S                           ' Bit 0, limit 감속정지 신호 입력에 의한 종료
    Public Const IPEND_STATUS_ELM As Short = &H2S                           ' Bit 1, limit 급정지 신호 입력에 의한 종료
    Public Const IPEND_STATUS_SSTOP_SIGNAL As Short = &H4S                  ' Bit 2, 감속 정지 신호 입력에 의한 종료
    Public Const IPEND_STATUS_ESTOP_SIGANL As Short = &H8S                  ' Bit 3, 급정지 신호 입력에 의한 종료
    Public Const IPEND_STATUS_SSTOP_COMMAND As Short = &H10S                ' Bit 4, 감속 정지 명령에 의한 종료
    Public Const IPEND_STATUS_ESTOP_COMMAND As Short = &H20S                ' Bit 5, 급정지 정지 명령에 의한 종료
    Public Const IPEND_STATUS_ALARM_SIGNAL As Short = &H40S                 ' Bit 6, Alarm 신호 입력에 희한 종료
    Public Const IPEND_STATUS_DATA_ERROR As Short = &H80S                   ' Bit 7, 데이터 설정 에러에 의한 종료
    Public Const IPEND_STATUS_DEVIATION_ERROR As Short = &H100S             ' Bit 8, 탈조 에러에 의한 종료
    Public Const IPEND_STATUS_ORIGIN_DETECT As Short = &H200S               ' Bit 9, 원점 검출에 의한 종료
    Public Const IPEND_STATUS_SIGNAL_DETECT As Short = &H400S               ' Bit 10, 신호 검출에 의한 종료(Signal search-1/2 drive 종료)
    Public Const IPEND_STATUS_PRESET_PULSE_DRIVE As Short = &H800S          ' Bit 11, Preset pulse drive 종료
    Public Const IPEND_STATUS_SENSOR_PULSE_DRIVE As Short = &H1000S         ' Bit 12, Sensor pulse drive 종료
    Public Const IPEND_STATUS_LIMIT As Short = &H2000S                      ' Bit 13, Limit 완전정지에 의한 종료
    Public Const IPEND_STATUS_SOFTLIMIT As Short = &H4000S                  ' Bit 14, Soft limit에 의한 종료
    Public Const IPEND_STATUS_INTERPOLATION_DRIVE As Short = &H8000S        ' Bit 15, Soft limit에 의한 종료

    ' IP Drive status
    Public Const IPDRIVE_STATUS_BUSY As Short = &H1S                        ' Bit 0, BUSY(드라이브 구동 중)
    Public Const IPDRIVE_STATUS_DOWN As Short = &H2S                        ' Bit 1, DOWN(감속 중)
    Public Const IPDRIVE_STATUS_CONST As Short = &H4S                       ' Bit 2, CONST(등속 중)
    Public Const IPDRIVE_STATUS_UP As Short = &H8S                          ' Bit 3, UP(가속 중)
    Public Const IPDRIVE_STATUS_ICL As Short = &H10S                        ' Bit 4, ICL(내부 위치 카운터 < 내부 위치 카운터 비교값)
    Public Const IPDRIVE_STATUS_ICG As Short = &H20S                        ' Bit 5, ICG(내부 위치 카운터 > 내부 위치 카운터 비교값)
    Public Const IPDRIVE_STATUS_ECL As Short = &H40S                        ' Bit 6, ECL(외부 위치 카운터 < 외부 위치 카운터 비교값)
    Public Const IPDRIVE_STATUS_ECG As Short = &H80S                        ' Bit 7, ECG(외부 위치 카운터 > 외부 위치 카운터 비교값)
    Public Const IPDRIVE_STATUS_DRIVE_DIRECTION As Short = &H100S           ' Bit 8, 드라이브 방향 신호(0=CW/1=CCW)
    Public Const IPDRIVE_STATUS_COMMAND_BUSY As Short = &H200S              ' Bit 9, 명령어 수행중
    Public Const IPDRIVE_STATUS_PRESET_DRIVING As Short = &H400S            ' Bit 10, Preset pulse drive 중
    Public Const IPDRIVE_STATUS_CONTINUOUS_DRIVING As Short = &H800S        ' Bit 11, Continuouse speed drive 중
    Public Const IPDRIVE_STATUS_SIGNAL_SEARCH_DRIVING As Short = &H1000S    ' Bit 12, Signal search-1/2 drive 중
    Public Const IPDRIVE_STATUS_ORG_SEARCH_DRIVING As Short = &H2000S       ' Bit 13, 원점 검출 drive 중
    Public Const IPDRIVE_STATUS_MPG_DRIVING As Short = &H4000S              ' Bit 14, MPG drive 중
    Public Const IPDRIVE_STATUS_SENSOR_DRIVING As Short = &H8000S           ' Bit 15, Sensor positioning drive 중
    Public Const IPDRIVE_STATUS_L_C_INTERPOLATION As Integer = &H10000      ' Bit 16, 직선/원호 보간 중
    Public Const IPDRIVE_STATUS_PATTERN_INTERPOLATION As Integer = &H20000  ' Bit 17, 비트 패턴 보간 중
    Public Const IPDRIVE_STATUS_INTERRUPT_BANK1 As Integer = &H40000        ' Bit 18, 인터럽트 bank1에서 발생
    Public Const IPDRIVE_STATUS_INTERRUPT_BANK2 As Integer = &H80000        ' Bit 19, 인터럽트 bank2에서 발생

    ' Interrupt MASK setting
    Public Const IPINTBANK1_DONTUSE As Short = &H0S                         ' INTERRUT DISABLED.
    Public Const IPINTBANK1_DRIVE_END As Short = &H1S                       ' Bit 0, Drive end(default value : 1).
    Public Const IPINTBANK1_ICG As Short = &H2S                             ' Bit 1, INCNT is greater than INCNTCMP.
    Public Const IPINTBANK1_ICE As Short = &H4S                             ' Bit 2, INCNT is equal with INCNTCMP.
    Public Const IPINTBANK1_ICL As Short = &H8S                             ' Bit 3, INCNT is less than INCNTCMP.
    Public Const IPINTBANK1_ECG As Short = &H10S                            ' Bit 4, EXCNT is greater than EXCNTCMP.
    Public Const IPINTBANK1_ECE As Short = &H20S                            ' Bit 5, EXCNT is equal with EXCNTCMP.
    Public Const IPINTBANK1_ECL As Short = &H40S                            ' Bit 6, EXCNT is less than EXCNTCMP.
    Public Const IPINTBANK1_SCRQEMPTY As Short = &H80S                      ' Bit 7, Script control queue is empty.
    Public Const IPINTBANK1_CAPRQEMPTY As Short = &H100S                    ' Bit 8, Caption result data queue is empty.
    Public Const IPINTBANK1_SCRREG1EXE As Short = &H200S                    ' Bit 9, Script control register-1 command is executed.
    Public Const IPINTBANK1_SCRREG2EXE As Short = &H400S                    ' Bit 10, Script control register-2 command is executed.
    Public Const IPINTBANK1_SCRREG3EXE As Short = &H800S                    ' Bit 11, Script control register-3 command is executed.
    Public Const IPINTBANK1_CAPREG1EXE As Short = &H1000S                   ' Bit 12, Caption control register-1 command is executed.
    Public Const IPINTBANK1_CAPREG2EXE As Short = &H2000S                   ' Bit 13, Caption control register-2 command is executed.
    Public Const IPINTBANK1_CAPREG3EXE As Short = &H4000S                   ' Bit 14, Caption control register-3 command is executed.
    Public Const IPINTBANK1_INTGGENCMD As Short = &H8000S                   ' Bit 15, Interrupt generation command is executed(0xFF)
    Public Const IPINTBANK1_DOWN As Integer = &H10000                       ' Bit 16, At starting point for deceleration drive.
    Public Const IPINTBANK1_CONT As Integer = &H20000                       ' Bit 17, At starting point for constant speed drive.
    Public Const IPINTBANK1_UP As Integer = &H40000                         ' Bit 18, At starting point for acceleration drive.
    Public Const IPINTBANK1_SIGNALDETECTED As Integer = &H80000             ' Bit 19, Signal assigned in MODE1 is detected.
    Public Const IPINTBANK1_SP23E As Integer = &H100000                     ' Bit 20, Current speed is equal with rate change point RCP23.
    Public Const IPINTBANK1_SP12E As Integer = &H200000                     ' Bit 21, Current speed is equal with rate change point RCP12.
    Public Const IPINTBANK1_SPE As Integer = &H400000                       ' Bit 22, Current speed is equal with speed comparison data(SPDCMP).
    Public Const IPINTBANK1_INCEICM As Integer = &H800000                   ' Bit 23, INTCNT(1'st counter) is equal with ICM(1'st count minus limit data)
    Public Const IPINTBANK1_SCRQEXE As Integer = &H1000000                  ' Bit 24, Script queue command is executed When SCRCONQ's 30 bit is '1'.
    Public Const IPINTBANK1_CAPQEXE As Integer = &H2000000                  ' Bit 25, Caption queue command is executed When CAPCONQ's 30 bit is '1'.
    Public Const IPINTBANK1_SLM As Integer = &H4000000                      ' Bit 26, NSLM/PSLM input signal is activated.
    Public Const IPINTBANK1_ELM As Integer = &H8000000                      ' Bit 27, NELM/PELM input signal is activated.
    Public Const IPINTBANK1_USERDEFINE1 As Integer = &H10000000             ' Bit 28, Selectable interrupt source 0(refer "0xFE" command).
    Public Const IPINTBANK1_USERDEFINE2 As Integer = &H20000000             ' Bit 29, Selectable interrupt source 1(refer "0xFE" command).
    Public Const IPINTBANK1_USERDEFINE3 As Integer = &H40000000             ' Bit 30, Selectable interrupt source 2(refer "0xFE" command).
    Public Const IPINTBANK1_USERDEFINE4 As Integer = &H80000000             ' Bit 31, Selectable interrupt source 3(refer "0xFE" command).

    Public Const IPINTBANK2_DONTUSE As Short = &H0S ' INTERRUT DISABLED.
    Public Const IPINTBANK2_L_C_INP_Q_EMPTY As Short = &H1S                 ' Bit 0, Linear/Circular interpolation parameter queue is empty.
    Public Const IPINTBANK2_P_INP_Q_EMPTY As Short = &H2S                   ' Bit 1, Bit pattern interpolation queue is empty.
    Public Const IPINTBANK2_ALARM_ERROR As Short = &H4S                     ' Bit 2, Alarm input signal is activated.
    Public Const IPINTBANK2_INPOSITION As Short = &H8S                      ' Bit 3, Inposition input signal is activated.
    Public Const IPINTBANK2_MARK_SIGNAL_HIGH As Short = &H10S               ' Bit 4, Mark input signal is activated.
    Public Const IPINTBANK2_SSTOP_SIGNAL As Short = &H20S                   ' Bit 5, SSTOP input signal is activated.
    Public Const IPINTBANK2_ESTOP_SIGNAL As Short = &H40S                   ' Bit 6, ESTOP input signal is activated.
    Public Const IPINTBANK2_SYNC_ACTIVATED As Short = &H80S                 ' Bit 7, SYNC input signal is activated.
    Public Const IPINTBANK2_TRIGGER_ENABLE As Short = &H100S                ' Bit 8, Trigger output is activated.
    Public Const IPINTBANK2_EXCNTCLR As Short = &H200S                      ' Bit 9, External(2'nd) counter is cleard by EXCNTCLR setting.
    Public Const IPINTBANK2_FSTCOMPARE_RESULT_BIT0 As Short = &H400S        ' Bit 10, ALU1's compare result bit 0 is activated.
    Public Const IPINTBANK2_FSTCOMPARE_RESULT_BIT1 As Short = &H800S        ' Bit 11, ALU1's compare result bit 1 is activated.
    Public Const IPINTBANK2_FSTCOMPARE_RESULT_BIT2 As Short = &H1000S       ' Bit 12, ALU1's compare result bit 2 is activated.
    Public Const IPINTBANK2_FSTCOMPARE_RESULT_BIT3 As Short = &H2000S       ' Bit 13, ALU1's compare result bit 3 is activated.
    Public Const IPINTBANK2_FSTCOMPARE_RESULT_BIT4 As Short = &H4000S       ' Bit 14, ALU1's compare result bit 4 is activated.
    Public Const IPINTBANK2_SNDCOMPARE_RESULT_BIT0 As Short = &H8000S       ' Bit 15, ALU2's compare result bit 0 is activated.
    Public Const IPINTBANK2_SNDCOMPARE_RESULT_BIT1 As Integer = &H10000     ' Bit 16, ALU2's compare result bit 1 is activated.
    Public Const IPINTBANK2_SNDCOMPARE_RESULT_BIT2 As Integer = &H20000     ' Bit 17, ALU2's compare result bit 2 is activated.
    Public Const IPINTBANK2_SNDCOMPARE_RESULT_BIT3 As Integer = &H40000     ' Bit 18, ALU2's compare result bit 3 is activated.
    Public Const IPINTBANK2_SNDCOMPARE_RESULT_BIT4 As Integer = &H80000     ' Bit 19, ALU2's compare result bit 4 is activated.
    Public Const IPINTBANK2_L_C_INP_Q_LESS_4 As Integer = &H100000          ' Bit 20, Linear/Circular interpolation parameter queue is less than 4.
    Public Const IPINTBANK2_P_INP_Q_LESS_4 As Integer = &H200000            ' Bit 21, Pattern interpolation parameter queue is less than 4.
    Public Const IPINTBANK2_XSYNC_ACTIVATED As Integer = &H400000           ' Bit 22, X axis sync input signal is activated.
    Public Const IPINTBANK2_YSYNC_ACTIVATED As Integer = &H800000           ' Bit 23, Y axis sync input sianal is activated.
    Public Const IPINTBANK2_P_INP_END_BY_END_PATTERN As Integer = &H1000000 ' Bit 24, Bit pattern interpolation is terminated by end pattern.
    ' IPINTBANK2_ = 0x02000000,   // Bit 25, Don't care.
    ' IPINTBANK2_ = 0x04000000,   // Bit 26, Don't care.
    ' IPINTBANK2_ = 0x08000000,   // Bit 27, Don't care.
    ' IPINTBANK2_ = 0x10000000,   // Bit 28, Don't care.
    ' IPINTBANK2_ = 0x20000000,   // Bit 29, Don't care.
    ' IPINTBANK2_ = 0x40000000,   // Bit 30, Don't care.
    ' IPINTBANK2_ = 0x80000000    // Bit 31, Don't care.

    ' IP Drive status
    Public Const IPMECHANICAL_PELM_LEVEL As Short = &H1S                    ' Bit 0, +Limit 급정지 신호가 액티브 됨
    Public Const IPMECHANICAL_NELM_LEVEL As Short = &H2S                    ' Bit 1, -Limit 급정지 신호 액티브 됨
    Public Const IPMECHANICAL_PSLM_LEVEL As Short = &H4S                    ' Bit 2, +limit 감속정지 신호 액티브 됨
    Public Const IPMECHANICAL_NSLM_LEVEL As Short = &H8S                    ' Bit 3, -limit 감속정지 신호 액티브 됨
    Public Const IPMECHANICAL_ALARM_LEVEL As Short = &H10S                  ' Bit 4, Alarm 신호 액티브 됨
    Public Const IPMECHANICAL_INP_LEVEL As Short = &H20S                    ' Bit 5, Inposition 신호 액티브 됨
    Public Const IPMECHANICAL_ENC_DOWN_LEVEL As Short = &H40S               ' Bit 6, 엔코더 DOWN(B상) 신호 입력 Level
    Public Const IPMECHANICAL_ENC_UP_LEVEL As Short = &H80S                 ' Bit 7, 엔코더 UP(A상) 신호 입력 Level
    Public Const IPMECHANICAL_EXMP_LEVEL As Short = &H100S                  ' Bit 8, EXMP 신호 입력 Level
    Public Const IPMECHANICAL_EXPP_LEVEL As Short = &H200S                  ' Bit 9, EXPP 신호 입력 Level
    Public Const IPMECHANICAL_MARK_LEVEL As Short = &H400S                  ' Bit 10, MARK# 신호 액티브 됨
    Public Const IPMECHANICAL_SSTOP_LEVEL As Short = &H800S                 ' Bit 11, SSTOP 신호 액티브 됨
    Public Const IPMECHANICAL_ESTOP_LEVEL As Short = &H1000S                ' Bit 12, ESTOP 신호 액티브 됨
    Public Const IPMECHANICAL_SYNC_LEVEL As Short = &H2000S                 ' Bit 13, SYNC 신호 입력 Level
    Public Const IPMECHANICAL_MODE8_16_LEVEL As Short = &H4000S             ' Bit 14, MODE8_16 신호 입력 Level

    ' Detect Destination Signal
    Public Const Signal_PosEndLimit As Short = &H0S                         ' +Elm(End limit) +방향 리미트 센서 신호
    Public Const Signal_NegEndLimit As Short = &H1S                         ' -Elm(End limit) -방향 리미트 센서 신호
    Public Const Signal_PosSloLimit As Short = &H2S                         ' +Slm(Slow Down limit) 신호 - 사용하지 않음
    Public Const Signal_NegSloLimit As Short = &H3S                         ' -Slm(Slow Down limit) 신호 - 사용하지 않음
    Public Const Signal_HomeSensor As Short = &H4S                          ' IN0(ORG)  원점 센서 신호
    Public Const Signal_EncodZPhase As Short = &H5S                         ' IN1(Z상)  Encoder Z상 신호
    Public Const Signal_UniInput02 As Short = &H6S                          ' IN2(범용) 범용 입력 2번 신호
    Public Const Signal_UniInput03 As Short = &H7S                          ' IN3(범용) 범용 입력 3번 신호

    ' QI Drive status
    Public Const QIMECHANICAL_PELM_LEVEL As Short = &H1S                    ' Bit 0, +Limit 급정지 신호 현재 상태
    Public Const QIMECHANICAL_NELM_LEVEL As Short = &H2S                    ' Bit 1, -Limit 급정지 신호 현재 상태
    Public Const QIMECHANICAL_PSLM_LEVEL As Short = &H4S                    ' Bit 2, +limit 감속정지 현재 상태.
    Public Const QIMECHANICAL_NSLM_LEVEL As Short = &H8S                    ' Bit 3, -limit 감속정지 현재 상태
    Public Const QIMECHANICAL_ALARM_LEVEL As Short = &H10S                  ' Bit 4, Alarm 신호 신호 현재 상태
    Public Const QIMECHANICAL_INP_LEVEL As Short = &H20S                    ' Bit 5, Inposition 신호 현재 상태
    Public Const QIMECHANICAL_ESTOP_LEVEL As Short = &H40S                  ' Bit 6, 비상 정지 신호(ESTOP) 현재 상태.
    Public Const QIMECHANICAL_ORG_LEVEL As Short = &H80S                    ' Bit 7, 원점 신호 헌재 상태
    Public Const QIMECHANICAL_ZPHASE_LEVEL As Short = &H100S                ' Bit 8, Z 상 입력 신호 현재 상태
    Public Const QIMECHANICAL_ECUP_LEVEL As Short = &H200S                  ' Bit 9, ECUP 터미널 신호 상태.
    Public Const QIMECHANICAL_ECDN_LEVEL As Short = &H400S                  ' Bit 10, ECDN 터미널 신호 상태.
    Public Const QIMECHANICAL_EXPP_LEVEL As Short = &H800S                  ' Bit 11, EXPP 터미널 신호 상태
    Public Const QIMECHANICAL_EXMP_LEVEL As Short = &H1000S                 ' Bit 12, EXMP 터미널 신호 상태
    Public Const QIMECHANICAL_SQSTR1_LEVEL As Short = &H2000S               ' Bit 13, SQSTR1 터미널 신호 상태
    Public Const QIMECHANICAL_SQSTR2_LEVEL As Short = &H4000S               ' Bit 14, SQSTR2 터미널 신호 상태
    Public Const QIMECHANICAL_SQSTP1_LEVEL As Short = &H8000S               ' Bit 15, SQSTP1 터미널 신호 상태
    Public Const QIMECHANICAL_SQSTP2_LEVEL As Integer = &H10000             ' Bit 16, SQSTP2 터미널 신호 상태
    Public Const QIMECHANICAL_MODE_LEVEL As Integer = &H20000               ' Bit 17, MODE 터미널 신호 상태.


    'QI End status : 0x0000이면 정상종료
    Public Const QIEND_STATUS_0 As Short = &H1S                             ' Bit 0, 정방향 리미트 신호(PELM)에 의한 종료
    Public Const QIEND_STATUS_1 As Short = &H2S                             ' Bit 1, 역방향 리미트 신호(NELM)에 의한 종료
    Public Const QIEND_STATUS_2 As Short = &H4S                             ' Bit 2, 정방향 부가 리미트 신호(PSLM)에 의한 구동 종료
    Public Const QIEND_STATUS_3 As Short = &H8S                             ' Bit 3, 역방향 부가 리미트 신호(NSLM)에 의한 구동 종료
    Public Const QIEND_STATUS_4 As Short = &H10S                            ' Bit 4, 정방향 소프트 리미트 급정지 기능에 의한 구동 종료
    Public Const QIEND_STATUS_5 As Short = &H20S                            ' Bit 5, 역방향 소프트 리미트 급정지 기능에 의한 구동 종료
    Public Const QIEND_STATUS_6 As Short = &H40S                            ' Bit 6, 정방향 소프트 리미트 감속정지 기능에 의한 구동 종료
    Public Const QIEND_STATUS_7 As Short = &H80S                            ' Bit 7, 역방향 소프트 리미트 감속정지 기능에 의한 구동 종료
    Public Const QIEND_STATUS_8 As Short = &H100S                           ' Bit 8, 서보 알람 기능에 의한 구동 종료.
    Public Const QIEND_STATUS_9 As Short = &H200S                           ' Bit 9, 비상 정지 신호 입력에 의한 구동 종료.
    Public Const QIEND_STATUS_10 As Short = &H400S                          ' Bit 10, 급 정지 명령에 의한 구동 종료.
    Public Const QIEND_STATUS_11 As Short = &H800S                          ' Bit 11, 감속 정지 명령에 의한 구동 종료.
    Public Const QIEND_STATUS_12 As Short = &H1000S                         ' Bit 12, 전축 급정지 명령에 의한 구동 종료
    Public Const QIEND_STATUS_13 As Short = &H2000S                         ' Bit 13, 동기 정지 기능 #1(SQSTP1)에 의한 구동 종료.
    Public Const QIEND_STATUS_14 As Short = &H4000S                         ' Bit 14, 동기 정지 기능 #2(SQSTP2)에 의한 구동 종료.
    Public Const QIEND_STATUS_15 As Short = &H8000S                         ' Bit 15, 인코더 입력(ECUP,ECDN) 오류 발생
    Public Const QIEND_STATUS_16 As Integer = &H10000                       ' Bit 16, MPG 입력(EXPP,EXMP) 오류 발생
    Public Const QIEND_STATUS_17 As Integer = &H20000                       ' Bit 17, 원점 검색 성공 종료.
    Public Const QIEND_STATUS_18 As Integer = &H40000                       ' Bit 18, 신호 검색 성공 종료.
    Public Const QIEND_STATUS_19 As Integer = &H80000                       ' Bit 19, 보간 데이터 이상으로 구동 종료.
    Public Const QIEND_STATUS_20 As Integer = &H100000                      ' Bit 20, 비정상 구동 정지발생.
    Public Const QIEND_STATUS_21 As Integer = &H200000                      ' Bit 21, MPG 기능 블록 펄스 버퍼 오버플로우 발생
    Public Const QIEND_STATUS_22 As Integer = &H400000                      ' Bit 22, DON'CARE
    Public Const QIEND_STATUS_23 As Integer = &H800000                      ' Bit 23, DON'CARE
    Public Const QIEND_STATUS_24 As Integer = &H1000000                     ' Bit 24, DON'CARE
    Public Const QIEND_STATUS_25 As Integer = &H2000000                     ' Bit 25, DON'CARE
    Public Const QIEND_STATUS_26 As Integer = &H4000000                     ' Bit 26, DON'CARE
    Public Const QIEND_STATUS_27 As Integer = &H8000000                     ' Bit 27, DON'CARE
    Public Const QIEND_STATUS_28 As Integer = &H10000000                    ' Bit 28, 현재/마지막 구동 드라이브 방향
    Public Const QIEND_STATUS_29 As Integer = &H20000000                    ' Bit 29, 잔여 펄스 제거 신호 출력 중.
    Public Const QIEND_STATUS_30 As Integer = &H40000000                    ' Bit 30, 비정상 구동 정지 원인 상태
    Public Const QIEND_STATUS_31 As Integer = &H80000000                    ' Bit 31, 보간 드라이브 데이타 오류 상태.

    ' QI Drive status
    Public Const QIDRIVE_STATUS_0 As Short = &H1S                           ' Bit 0, BUSY(드라이브 구동 중)
    Public Const QIDRIVE_STATUS_1 As Short = &H2S                           ' Bit 1, DOWN(감속 중)
    Public Const QIDRIVE_STATUS_2 As Short = &H4S                           ' Bit 2, CONST(등속 중)
    Public Const QIDRIVE_STATUS_3 As Short = &H8S                           ' Bit 3, UP(가속 중)
    Public Const QIDRIVE_STATUS_4 As Short = &H10S                          ' Bit 4, 연속 드라이브 구동 중
    Public Const QIDRIVE_STATUS_5 As Short = &H20S                          ' Bit 5, 지정 거리 드라이브 구동 중
    Public Const QIDRIVE_STATUS_6 As Short = &H40S                          ' Bit 6, MPG 드라이브 구동 중
    Public Const QIDRIVE_STATUS_7 As Short = &H80S                          ' Bit 7, 원점검색 드라이브 구동중
    Public Const QIDRIVE_STATUS_8 As Short = &H100S                         ' Bit 8, 신호 검색 드라이브 구동 중
    Public Const QIDRIVE_STATUS_9 As Short = &H200S                         ' Bit 9, 보간 드라이브 구동 중
    Public Const QIDRIVE_STATUS_10 As Short = &H400S                        ' Bit 10, Slave 드라이브 구동중
    Public Const QIDRIVE_STATUS_11 As Short = &H800S                        ' Bit 11, 현재 구동 드라이브 방향(보간 드라이브에서는 표시 정보 다름)
    Public Const QIDRIVE_STATUS_12 As Short = &H1000S                       ' Bit 12, 펄스 출력후 서보위치 완료 신호 대기중.
    Public Const QIDRIVE_STATUS_13 As Short = &H2000S                       ' Bit 13, 직선 보간 드라이브 구동중.
    Public Const QIDRIVE_STATUS_14 As Short = &H4000S                       ' Bit 14, 원호 보간 드라이브 구동중.
    Public Const QIDRIVE_STATUS_15 As Short = &H8000S                       ' Bit 15, 펄스 출력 중.
    Public Const QIDRIVE_STATUS_16 As Integer = &H10000                     ' Bit 16, 구동 예약 데이터 개수(처음)(0-7)
    Public Const QIDRIVE_STATUS_17 As Integer = &H20000                     ' Bit 17, 구동 예약 데이터 개수(중간)(0-7)
    Public Const QIDRIVE_STATUS_18 As Integer = &H40000                     ' Bit 18, 구동 예약 데이터 갯수(끝)(0-7)
    Public Const QIDRIVE_STATUS_19 As Integer = &H80000                     ' Bit 19, 구동 예약 Queue 비어 있음.
    Public Const QIDRIVE_STATUS_20 As Integer = &H100000                    ' Bit 20, 구동 예약 Queue 가득 찲
    Public Const QIDRIVE_STATUS_21 As Integer = &H200000                    ' Bit 21, 현재 구동 드라이브의 속도 모드(처음)
    Public Const QIDRIVE_STATUS_22 As Integer = &H400000                    ' Bit 22, 현재 구동 드라이브의 속도 모드(끝)
    Public Const QIDRIVE_STATUS_23 As Integer = &H800000                    ' Bit 23, MPG 버퍼 #1 Full
    Public Const QIDRIVE_STATUS_24 As Integer = &H1000000                   ' Bit 24, MPG 버퍼 #2 Full
    Public Const QIDRIVE_STATUS_25 As Integer = &H2000000                   ' Bit 25, MPG 버퍼 #3 Full
    Public Const QIDRIVE_STATUS_26 As Integer = &H4000000                   ' Bit 26, MPG 버퍼 데이터 OverFlow

    'QI Interrupt MASK setting
    Public Const QIINTBANK1_DISABLE As Short = &H0S                         ' INTERRUT DISABLED.
    Public Const QIINTBANK1_0 As Short = &H1S                               ' Bit 0,  인터럽트 발생 사용 설정된 구동 종료시.
    Public Const QIINTBANK1_1 As Short = &H2S                               ' Bit 1,  구동 종료시
    Public Const QIINTBANK1_2 As Short = &H4S                               ' Bit 2,  구동 시작시.
    Public Const QIINTBANK1_3 As Short = &H8S                               ' Bit 3,  카운터 #1 < 비교기 #1 이벤트 발생
    Public Const QIINTBANK1_4 As Short = &H10S                              ' Bit 4,  카운터 #1 = 비교기 #1 이벤트 발생
    Public Const QIINTBANK1_5 As Short = &H20S                              ' Bit 5,  카운터 #1 > 비교기 #1 이벤트 발생
    Public Const QIINTBANK1_6 As Short = &H40S                              ' Bit 6,  카운터 #2 < 비교기 #2 이벤트 발생
    Public Const QIINTBANK1_7 As Short = &H80S                              ' Bit 7,  카운터 #2 = 비교기 #2 이벤트 발생
    Public Const QIINTBANK1_8 As Short = &H100S                             ' Bit 8,  카운터 #2 > 비교기 #2 이벤트 발생
    Public Const QIINTBANK1_9 As Short = &H200S                             ' Bit 9,  카운터 #3 < 비교기 #3 이벤트 발생
    Public Const QIINTBANK1_10 As Short = &H400S                            ' Bit 10, 카운터 #3 = 비교기 #3 이벤트 발생
    Public Const QIINTBANK1_11 As Short = &H800S                            ' Bit 11, 카운터 #3 > 비교기 #3 이벤트 발생
    Public Const QIINTBANK1_12 As Short = &H1000S                           ' Bit 12, 카운터 #4 < 비교기 #4 이벤트 발생
    Public Const QIINTBANK1_13 As Short = &H2000S                           ' Bit 13, 카운터 #4 = 비교기 #4 이벤트 발생
    Public Const QIINTBANK1_14 As Short = &H4000S                           ' Bit 14, 카운터 #4 < 비교기 #4 이벤트 발생
    Public Const QIINTBANK1_15 As Short = &H8000S                           ' Bit 15, 카운터 #5 < 비교기 #5 이벤트 발생
    Public Const QIINTBANK1_16 As Integer = &H10000                         ' Bit 16, 카운터 #5 = 비교기 #5 이벤트 발생
    Public Const QIINTBANK1_17 As Integer = &H20000                         ' Bit 17, 카운터 #5 > 비교기 #5 이벤트 발생
    Public Const QIINTBANK1_18 As Integer = &H40000                         ' Bit 18, 타이머 #1 이벤트 발생.
    Public Const QIINTBANK1_19 As Integer = &H80000                         ' Bit 19, 타이머 #2 이벤트 발생.
    Public Const QIINTBANK1_20 As Integer = &H100000                        ' Bit 20, 구동 예약 설정 Queue 비워짐.
    Public Const QIINTBANK1_21 As Integer = &H200000                        ' Bit 21, 구동 예약 설정 Queue 가득찲
    Public Const QIINTBANK1_22 As Integer = &H400000                        ' Bit 22, 트리거 발생거리 주기/절대위치 Queue 비워짐.
    Public Const QIINTBANK1_23 As Integer = &H800000                        ' Bit 23, 트리거 발생거리 주기/절대위치 Queue 가득찲
    Public Const QIINTBANK1_24 As Integer = &H1000000                       ' Bit 24, 트리거 신호 발생 이벤트
    Public Const QIINTBANK1_25 As Integer = &H2000000                       ' Bit 25, 스크립트 #1 명령어 예약 설정 Queue 비워짐.
    Public Const QIINTBANK1_26 As Integer = &H4000000                       ' Bit 26, 스크립트 #2 명령어 예약 설정 Queue 비워짐.
    Public Const QIINTBANK1_27 As Integer = &H8000000                       ' Bit 27, 스크립트 #3 명령어 예약 설정 레지스터 실행되어 초기화 됨.
    Public Const QIINTBANK1_28 As Integer = &H10000000                      ' Bit 28, 스크립트 #4 명령어 예약 설정 레지스터 실행되어 초기화 됨.
    Public Const QIINTBANK1_29 As Integer = &H20000000                      ' Bit 29, 서보 알람신호 인가됨.
    Public Const QIINTBANK1_30 As Integer = &H40000000                      ' Bit 30, |CNT1| - |CNT2| >= |CNT4| 이벤트 발생.
    Public Const QIINTBANK1_31 As Integer = &H80000000                      ' Bit 31, 인터럽트 발생 명령어|INTGEN| 실행.

    Public Const QIINTBANK2_DISABLE As Short = &H0S                         ' INTERRUT DISABLED.
    Public Const QIINTBANK2_0 As Short = &H1S                               ' Bit 0,  스크립트 #1 읽기 명령 결과 Queue 가 가득찲.
    Public Const QIINTBANK2_1 As Short = &H2S                               ' Bit 1,  스크립트 #2 읽기 명령 결과 Queue 가 가득찲.
    Public Const QIINTBANK2_2 As Short = &H4S                               ' Bit 2,  스크립트 #3 읽기 명령 결과 레지스터가 새로운 데이터로 갱신됨.
    Public Const QIINTBANK2_3 As Short = &H8S                               ' Bit 3,  스크립트 #4 읽기 명령 결과 레지스터가 새로운 데이터로 갱신됨.
    Public Const QIINTBANK2_4 As Short = &H10S                              ' Bit 4,  스크립트 #1 의 예약 명령어 중 실행 시 인터럽트 발생으로 설정된 명령어 실행됨.
    Public Const QIINTBANK2_5 As Short = &H20S                              ' Bit 5,  스크립트 #2 의 예약 명령어 중 실행 시 인터럽트 발생으로 설정된 명령어 실행됨.
    Public Const QIINTBANK2_6 As Short = &H40S                              ' Bit 6,  스크립트 #3 의 예약 명령어 실행 시 인터럽트 발생으로 설정된 명령어 실행됨.
    Public Const QIINTBANK2_7 As Short = &H80S                              ' Bit 7,  스크립트 #4 의 예약 명령어 실행 시 인터럽트 발생으로 설정된 명령어 실행됨.
    Public Const QIINTBANK2_8 As Short = &H100S                             ' Bit 8,  구동 시작
    Public Const QIINTBANK2_9 As Short = &H200S                             ' Bit 9,  서보 위치 결정 완료(Inposition)기능을 사용한 구동,종료 조건 발생.
    Public Const QIINTBANK2_10 As Short = &H400S                            ' Bit 10, 이벤트 카운터로 동작 시 사용할 이벤트 선택 #1 조건 발생.
    Public Const QIINTBANK2_11 As Short = &H800S                            ' Bit 11, 이벤트 카운터로 동작 시 사용할 이벤트 선택 #2 조건 발생.
    Public Const QIINTBANK2_12 As Short = &H1000S                           ' Bit 12, SQSTR1 신호 인가 됨.
    Public Const QIINTBANK2_13 As Short = &H2000S                           ' Bit 13, SQSTR2 신호 인가 됨.
    Public Const QIINTBANK2_14 As Short = &H4000S                           ' Bit 14, UIO0 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_15 As Short = &H8000S                           ' Bit 15, UIO1 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_16 As Integer = &H10000                         ' Bit 16, UIO2 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_17 As Integer = &H20000                         ' Bit 17, UIO3 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_18 As Integer = &H40000                         ' Bit 18, UIO4 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_19 As Integer = &H80000                         ' Bit 19, UIO5 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_20 As Integer = &H100000                        ' Bit 20, UIO6 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_21 As Integer = &H200000                        ' Bit 21, UIO7 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_22 As Integer = &H400000                        ' Bit 22, UIO8 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_23 As Integer = &H800000                        ' Bit 23, UIO9 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_24 As Integer = &H1000000                       ' Bit 24, UIO10 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_25 As Integer = &H2000000                       ' Bit 25, UIO11 터미널 신호가 '1'로 변함.
    Public Const QIINTBANK2_26 As Integer = &H4000000                       ' Bit 26, 오류 정지 조건(LMT, ESTOP, STOP, ESTOP, CMD, ALARM) 발생.
    Public Const QIINTBANK2_27 As Integer = &H8000000                       ' Bit 27, 보간 중 데이터 설정 오류 발생.
    Public Const QIINTBANK2_28 As Integer = &H10000000                      ' Bit 28, Don't Care
    Public Const QIINTBANK2_29 As Integer = &H20000000                      ' Bit 29, 리미트 신호(PELM, NELM)신호가 입력 됨.
    Public Const QIINTBANK2_30 As Integer = &H40000000                      ' Bit 30, 부가 리미트 신호(PSLM, NSLM)신호가 입력 됨.
    Public Const QIINTBANK2_31 As Integer = &H80000000                      ' Bit 31, 비상 정지 신호(ESTOP)신호가 입력됨.

    ' Network Status 상태정의
    Public Const NET_STATUS_DISCONNECTED As Short = 1
    Public Const NET_STATUS_LOCK_MISMATCH As Short = 5
    Public Const NET_STATUS_CONNECTED As Short = 6
    ' 모션제품(QI) Override 위치 조건
    Public Const OVERRIDE_POS_START As Short = 0
    Public Const OVERRIDE_POS_END As Short = 1  
    ' 모션제품(QI) Profile 우선순위
    Public Const PRIORITY_VELOCITY As Short = 0
    Public Const PRIORITY_ACCELTIME As Short = 1
    ' 모션함수 반환형태 정의
    Public Const FUNC_RETURN_IMMEDIATE As Short = 0
    Public Const FUNC_RETURN_BLOCKING As Short = 1
    Public Const FUNC_RETURN_NON_BLOCKING As Short = 2
    ' 서보팩 알람코드 기록 개수정의
    Public Const MAX_SERVO_ALARM_HISTORY As Short = 15

    ' Counter Module Define
    Public Const F_50M_CLK As Integer = 50000000

    Public Const CnCommand As Short = &H10S
    Public Const CnData1 As Short = &H12S
    Public Const CnData2 As Short = &H14S
    Public Const CnData3 As Short = &H16S
    Public Const CnData4 As Short = &H18S
    Public Const CnData12 As Short = &H44S
    Public Const CnData34 As Short = &H46S

    Public Const CnRamAddr1 As Short = &H28S
    Public Const CnRamAddr2 As Short = &H2AS
    Public Const CnRamAddr3 As Short = &H2CS
    Public Const CnRamAddrx1 As Short = &H48S
    Public Const CnRamAddr23 As Short = &H4AS

    Public Const CnAbPhase As Short = 0
    Public Const CnZPhase As Short = 1

    Public Const CnUpDownMode As Short = 0
    Public Const CnSqr1Mode As Short = 1
    Public Const CnSqr2Mode As Short = 2
    Public Const CnSqr4Mode As Short = 3

    ' CH-1 Group Register
    Public Const CnCh1CounterRead As Short = &H10S                       ' CH1 COUNTER READ, 24BIT
    Public Const CnCh1CounterWrite As Short = &H90S                      ' CH1 COUNTER WRITE
    Public Const CnCh1CounterModeRead As Short = &H11S                   ' CH1 COUNTER MODE READ, 8BIT
    Public Const CnCh1CounterModeWrite As Short = &H91S                  ' CH1 COUNTER MODE WRITE
    Public Const CnCh1TriggerRegionLowerDataRead As Short = &H12S        ' CH1 TRIGGER REGION LOWER DATA READ, 24BIT
    Public Const CnCh1TriggerRegionLowerDataWrite As Short = &H92S       ' CH1 TRIGGER REGION LOWER DATA WRITE
    Public Const CnCh1TriggerRegionUpperDataRead As Short = &H13S        ' CH1 TRIGGER REGION UPPER DATA READ, 24BIT
    Public Const CnCh1TriggerRegionUpperDataWrite As Short = &H93S       ' CH1 TRIGGER REGION UPPER DATA WRITE
    Public Const CnCh1TriggerPeriodRead As Short = &H14S                 ' CH1 TRIGGER PERIOD READ, 24BIT, RESERVED
    Public Const CnCh1TriggerPeriodWrite As Short = &H94S                ' CH1 TRIGGER PERIOD WRITE
    Public Const CnCh1TriggerPulseWidthRead As Short = &H15S             ' CH1 TRIGGER PULSE WIDTH READ
    Public Const CnCh1TriggerPulseWidthWrite As Short = &H95S            ' CH1 RIGGER PULSE WIDTH WRITE
    Public Const CnCh1TriggerModeRead As Short = &H16S                   ' CH1 TRIGGER MODE READ
    Public Const CnCh1TriggerModeWrite As Short = &H96S                  ' CH1 RIGGER MODE WRITE
    Public Const CnCh1TriggerStatusRead As Short = &H17S                 ' CH1 TRIGGER STATUS READ
    Public Const CnCh1NoOperation_97 As Short = &H97S
    Public Const CnCh1TriggerEnable As Short = &H98S
    Public Const CnCh1TriggerDisable As Short = &H99S
    Public Const CnCh1TimeTriggerFrequencyRead As Short = &H1AS
    Public Const CnCh1TimeTriggerFrequencyWrite As Short = &H9AS
    Public Const CnCh1ComparatorValueRead As Short = &H1BS
    Public Const CnCh1ComparatorValueWrite As Short = &H9BS
    Public Const CnCh1CompareatorConditionRead As Short = &H1DS
    Public Const CnCh1CompareatorConditionWrite As Short = &H9DS

    ' CH-2 Group Register
    Public Const CnCh2CounterRead As Short = &H20S                       ' CH2 COUNTER READ, 24BIT
    Public Const CnCh2CounterWrite As Short = &HA1S                      ' CH2 COUNTER WRITE
    Public Const CnCh2CounterModeRead As Short = &H21S                   ' CH2 COUNTER MODE READ, 8BIT
    Public Const CnCh2CounterModeWrite As Short = &HA1S                  ' CH2 COUNTER MODE WRITE
    Public Const CnCh2TriggerRegionLowerDataRead As Short = &H22S        ' CH2 TRIGGER REGION LOWER DATA READ, 24BIT
    Public Const CnCh2TriggerRegionLowerDataWrite As Short = &HA2S       ' CH2 TRIGGER REGION LOWER DATA WRITE
    Public Const CnCh2TriggerRegionUpperDataRead As Short = &H23S        ' CH2 TRIGGER REGION UPPER DATA READ, 24BIT
    Public Const CnCh2TriggerRegionUpperDataWrite As Short = &HA3S       ' CH2 TRIGGER REGION UPPER DATA WRITE
    Public Const CnCh2TriggerPeriodRead As Short = &H24S                 ' CH2 TRIGGER PERIOD READ, 24BIT, RESERVED
    Public Const CnCh2TriggerPeriodWrite As Short = &HA4S                ' CH2 TRIGGER PERIOD WRITE
    Public Const CnCh2TriggerPulseWidthRead As Short = &H25S             ' CH2 TRIGGER PULSE WIDTH READ, 24BIT
    Public Const CnCh2TriggerPulseWidthWrite As Short = &HA5S            ' CH2 RIGGER PULSE WIDTH WRITE
    Public Const CnCh2TriggerModeRead As Short = &H26S                   ' CH2 TRIGGER MODE READ
    Public Const CnCh2TriggerModeWrite As Short = &HA6S                  ' CH2 RIGGER MODE WRITE
    Public Const CnCh2TriggerStatusRead As Short = &H27S                 ' CH2 TRIGGER STATUS READ
    Public Const CnCh2NoOperation_A7 As Short = &HA7S
    Public Const CnCh2TriggerEnable As Short = &HA8S
    Public Const CnCh2TriggerDisable As Short = &HA9S
    Public Const CnCh2TimeTriggerFrequencyRead As Short = &H2AS
    Public Const CnCh2TimeTriggerFrequencyWrite As Short = &HAAS
    Public Const CnCh2ComparatorValueRead As Short = &H2BS
    Public Const CnCh2ComparatorValueWrite As Short = &HABS
    Public Const CnCh2CompareatorConditionRead As Short = &H2DS
    Public Const CnCh2CompareatorConditionWrite As Short = &HADS

    ' Ram Access Group Register
    Public Const CnRamDataWithRamAddress As Short = &H30S                ' READ RAM DATA WITH RAM ADDR PORT ADDRESS
    Public Const CnRamDataWrite As Short = &HB0S                         ' RAM DATA WRITE
    Public Const CnRamDataRead As Short = &H31S                          ' RAM DATA READ, 32BIT
End Module
