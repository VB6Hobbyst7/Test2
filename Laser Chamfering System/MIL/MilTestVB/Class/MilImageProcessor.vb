Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Imports System.Threading
Imports Matrox.MatroxImagingLibrary
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Diagnostics

Public Class MilImageProcessor
    Inherits MIL

    Enum AlignMarkNum
        A1_L1_M1 = 1
        A1_L2_M1 = 2
        A1_L3_M1 = 3
        A1_L1_M2 = 4
        A1_L2_M2 = 5
        A1_L3_M2 = 6
        A2_L1_M1 = 7
        A2_L2_M1 = 8
        A2_L3_M1 = 9
        A2_L1_M2 = 10
        A2_L2_M2 = 11
        A2_L3_M2 = 12

        B1_L1_M1 = 13
        B1_L2_M1 = 14
        B1_L3_M1 = 15
        B1_L1_M2 = 16
        B1_L2_M2 = 17
        B1_L3_M2 = 18
        B2_L1_M1 = 19
        B2_L2_M1 = 20
        B2_L3_M1 = 21
        B2_L1_M2 = 22
        B2_L2_M2 = 23
        B2_L3_M2 = 24
    End Enum

    Structure AlignData
        Dim bMark As Boolean
        Dim MarkNum As AlignMarkNum
        Dim nAlignMark_SearchOffsetX As Integer
        Dim nAlignMark_SearchOffsetY As Integer
        Dim nAlignMark_SearchSizeX As Integer
        Dim nAlignMark_SearchSizeY As Integer
        Dim nAlignMark_ModelOffsetX As Integer
        Dim nAlignMark_ModelOffsetY As Integer
        Dim nAlignMark_ModelSizeX As Integer
        Dim nAlignMark_ModelSizeY As Integer
        Dim nAlignMark_Acceptance As Integer
        Dim nAlignMark_Certainty As Integer
        Dim nAlignMark_OriginPosX As Integer
        Dim nAlignMark_OriginPosY As Integer
        Dim dAlignMark_Result_Acceptance As Double
        Dim strAlignMarkImageBMP_FileName As String
        Dim strAlignMarkImageMMF_FileName As String
        Dim strAlignMarkImageBMP_Mask_FileName As String
        Dim strAlignMarkImageMMF_Mask_FileName As String
    End Structure

    Public Enum ImageBand
        GRAYBAND = 1
        COLORBAND = 3
    End Enum

    Public Function LoadImage(ByVal szFileName As [String], ByRef loadImage__1 As MIL_ID, ByVal MilSystem As MIL_ID) As Boolean
        '=M_DEFAULT_HOST
        If Not File.Exists(szFileName) Then
            Return False
        End If

        MbufRestore(szFileName, MilSystem, loadImage__1)

        Dim AllocError As Long = 0
        MappGetError(M_CURRENT, AllocError)

        If AllocError = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function SaveImage(ByVal srcimage As MIL_ID, ByVal lFormat As Int32, ByVal icompress As Int32, ByVal szFileName As [String]) As Boolean
        Dim sFileDir As [String] = Utility.GetDirectoryFromPath(szFileName)
        Utility.FolderEditCheck(sFileDir)

        If lFormat = M_JPEG_LOSSY Then
            Dim sizex As Integer = 0, sizey As Integer = 0, BufferAttributes As Integer = 0, systype As Integer = 0
            'BufferAttributes = M_IMAGE+M_DISP+M_COMPRESS+M_JPEG_LOSSY+M_YUV9;//M_YUV9
            BufferAttributes = M_IMAGE + M_COMPRESS + M_JPEG_LOSSY
            MbufInquire(srcimage, M_SIZE_X, sizex)
            MbufInquire(srcimage, M_SIZE_Y, sizey)
            MbufInquire(srcimage, M_OWNER_SYSTEM, systype)

            Dim compressImage As MIL_ID = M_NULL
            'M_DEFAULT_HOST
            MbufAllocColor(systype, 3, sizex, sizey, M_DEF_IMAGE_TYPE, BufferAttributes, _
             compressImage)
            MbufControl(compressImage, M_Q_FACTOR, icompress)
            '1,3,1	// 압축할 수 있는 부분... (1 to 99)
            MbufCopy(srcimage, compressImage)


            MbufExport(szFileName, lFormat, compressImage)

            MbufFree(compressImage)
        Else
            MbufExport(szFileName, lFormat, srcimage)
        End If
        Return True
    End Function

    Public Function GetAllocatedBufSize() As Int32
        Dim lBufSize As MIL_ID = M_NULL
        MappInquire(M_NON_PAGED_MEMORY_USED, lBufSize)

        Return lBufSize
    End Function

    Public Sub GetImageSize(ByVal image As MIL_ID, ByRef x As Int32, ByRef y As Int32)
        MbufInquire(image, M_SIZE_X, x)
        MbufInquire(image, M_SIZE_Y, y)
    End Sub

    Public Function GetImageBand(ByVal image As MIL_ID) As Int32
        Dim band As MIL_ID = M_NULL
        MbufInquire(image, M_SIZE_BAND, band)
        Return band
    End Function

    Public Function GetImageType(ByVal image As MIL_ID) As Int32
        Dim type As MIL_ID = M_NULL
        MbufInquire(image, M_TYPE, type)
        Return type
    End Function

    Public Function GetImageAttribute(ByVal image As MIL_ID) As Int64
        Dim attr As MIL_ID = M_NULL
        MbufInquire(image, M_ATTRIBUTE, attr)
        Return attr
    End Function

    Public Function GetImageSystem(ByVal image As MIL_ID) As MIL_ID
        Dim systype As MIL_ID = M_NULL
        MbufInquire(image, M_OWNER_SYSTEM, systype)
        Return systype
    End Function

    Public Sub CopyImage(ByVal srcimage As MIL_ID, ByRef trgimage As MIL_ID)
        MbufCopy(srcimage, trgimage)
    End Sub

    Public Sub CreateGrayBuffer(ByRef image As MIL_ID, ByVal width As Int32, ByVal height As Int32, ByVal Milsystem As MIL_ID)
        '=M_DEFAULT_HOST
        MbufAlloc2d(Milsystem, width, height, M_DEF_IMAGE_TYPE, M_IMAGE + M_PROC + M_DISP, image)
    End Sub

    Public Sub CreateBinaryBuffer(ByRef image As MIL_ID, ByVal width As Int32, ByVal height As Int32, ByVal Milsystem As MIL_ID)
        '=M_DEFAULT_HOST
        MbufAlloc2d(Milsystem, width, height, 1 + M_UNSIGNED, M_IMAGE + M_PROC + M_DISP, image)
    End Sub

    Public Sub CreateColorBuffer(ByRef image As MIL_ID, ByVal width As Int32, ByVal height As Int32, ByVal Milsystem As MIL_ID)
        '=M_DEFAULT_HOST
        MbufAllocColor(Milsystem, 3, width, height, M_DEF_IMAGE_TYPE, M_IMAGE + M_PROC + M_DISP, _
         image)
    End Sub

    Public Sub GetCompatibleColorBuffer(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        Dim tmpsX As Int32 = 0, tmpsY As Int32 = 0
        Dim sys As MIL_ID = M_NULL
        Dim attr As Int64 = M_NULL

        GetImageSize(srcImage, tmpsX, tmpsY)
        sys = GetImageSystem(srcImage)
        attr = GetImageAttribute(srcImage)

        MbufAllocColor(sys, 3, tmpsX, tmpsY, M_DEF_IMAGE_TYPE, attr, _
         destImage)
    End Sub


    Public Sub GetCompatibleGrayBuffer(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        Dim tmpsX As Int32 = 0, tmpsY As Int32 = 0
        Dim sys As MIL_ID = M_NULL
        Dim attr As Int64 = M_NULL

        GetImageSize(srcImage, tmpsX, tmpsY)
        sys = GetImageSystem(srcImage)
        attr = GetImageAttribute(srcImage)
        MbufAlloc2d(sys, tmpsX, tmpsY, M_DEF_IMAGE_TYPE, attr, destImage)
    End Sub

    Public Sub GetCompatibleBinaryBuffer(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        Dim tmpsX As Int32 = 0, tmpsY As Int32 = 0
        Dim sys As MIL_ID = M_NULL
        Dim attr As Int64 = 0

        GetImageSize(srcImage, tmpsX, tmpsY)
        sys = GetImageSystem(srcImage)
        attr = GetImageAttribute(srcImage)

        MbufAlloc2d(sys, tmpsX, tmpsY, 1 + M_UNSIGNED, attr, destImage)
    End Sub

    Public Sub GetCompatibleBuffer(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        Dim tmpsX As Int32 = 0, tmpsY As Int32 = 0, type As Int32 = 0, band As Int32 = 0
        Dim sys As MIL_ID = M_NULL
        Dim attr As Int64 = 0

        GetImageSize(srcImage, tmpsX, tmpsY)
        band = GetImageBand(srcImage)
        type = GetImageType(srcImage)
        attr = GetImageAttribute(srcImage)
        sys = GetImageSystem(srcImage)

        MbufAllocColor(sys, band, tmpsX, tmpsY, type, attr, _
         destImage)
    End Sub

    Public Sub GetCompatibleBuffer(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal XSize As Int32, ByVal YSize As Int32)
        Dim type As Int32 = 0, band As Int32 = 0
        Dim sys As MIL_ID = M_NULL
        Dim attr As Int64 = 0

        band = GetImageBand(srcImage)
        type = GetImageType(srcImage)
        attr = GetImageAttribute(srcImage)
        sys = GetImageSystem(srcImage)

        MbufAllocColor(sys, band, XSize, YSize, type, attr, _
         destImage)
    End Sub

    Public Sub ClearImage(ByVal image As MIL_ID)
        Dim band As Int32 = GetImageBand(image)

        If CType(ImageBand.COLORBAND, Int32) = band Then
            MbufClear(image, M_RGB888(0, 0, 0))
        Else
            MbufClear(image, 0)
        End If
    End Sub

    Public Sub ReleaseBuffer(ByVal image As MIL_ID)
        If M_NULL <> image Then
            MbufFree(image)
            image = M_NULL
        End If
    End Sub

    Public Sub ConvertToLuminant(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        MimConvert(srcImage, destImage, M_RGB_TO_L)
    End Sub

    Public Sub ConvertToGrey(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        Dim width As Int32 = 0, height As Int32 = 0

        GetImageSize(srcImage, width, height)
        Dim colors As Byte() = New Byte(width * height * 3 - 1) {}
        Dim greys As Byte() = New Byte(width * height - 1) {}

        MbufGetColor(srcImage, M_PLANAR, M_ALL_BAND, colors)

        Dim r As Single, g As Single, b As Single
        For h As Integer = 0 To height - 1
            For w As Integer = 0 To width - 1
                r = 0.25F * CSng(colors(w + (h * width)))
                g = 0.5F * CSng(colors(w + (h * width) + (width * height)))
                b = 0.25F * CSng(colors(w + (h * width) + (width * height) * 2))
                greys(h * width + w) = CByte(Math.Truncate(r + g + b))
            Next
        Next

        MbufPut(destImage, greys)
    End Sub

    Public Sub ConvertToHue(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        MimConvert(srcImage, destImage, M_RGB_TO_H)
    End Sub

    Public Sub ConvertToHLS(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        MimConvert(srcImage, destImage, M_RGB_TO_HLS)
    End Sub

    'Public Sub ConvertToHLS(ByVal hsi As Byte, ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
    '    Dim width As Int32 = 0, height As Int32 = 0
    '    Dim hlsImage As MIL_ID = M_NULL
    '    GetImageSize(srcImage, width, height)
    '    GetCompatibleBuffer(srcImage, hlsImage)
    '    ConvertToHLS(srcImage, hlsImage)
    '    Dim tget As Byte() = New Byte(width * height - 1) {}

    '    Dim band As Int32 = GetImageBand(srcImage)
    '    If CType(ImageBand.COLORBAND, Int32) = band Then
    '        If hsi = "h"c OrElse hsi = "H"c Then
    '            MbufGetColor(srcImage, M_PLANAR, M_HUE, tget)
    '        ElseIf hsi = "l"c OrElse hsi = "L"c Then
    '            MbufGetColor(srcImage, M_PLANAR, M_LUMINANCE, tget)
    '        ElseIf hsi = "s"c OrElse hsi = "S"c Then
    '            MbufGetColor(srcImage, M_PLANAR, M_SATURATION, tget)
    '        End If
    '    End If

    '    MbufPut(destImage, tget)
    '    If hlsImage <> M_NULL Then
    '        MbufFree(hlsImage)
    '    End If
    'End Sub

    Public Function ConvertGreyToColor(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID) As Boolean
        If srcImage = M_NULL Then
            Return False
        End If
        If destImage = M_NULL Then
            Return False
        End If
        MbufCopyColor(srcImage, destImage, M_RED)
        MbufCopyColor(srcImage, destImage, M_GREEN)
        MbufCopyColor(srcImage, destImage, M_BLUE)
        Return True
    End Function

    Public Sub ConvertColorToRGB(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal nChannel As Int32)
        Dim tmpsX As Int32 = 0, tmpsY As Int32 = 0
        GetImageSize(srcImage, tmpsX, tmpsY)

        Dim child As MIL_ID = M_NULL
        'R,G,B child buffer
        MbufChildColor2d(srcImage, nChannel, 0, 0, tmpsX, tmpsY, _
         child)
        MbufCopy(child, destImage)

        MbufFree(child)
    End Sub

    Public Function BayerConvert(ByVal grabImage As MIL_ID, ByVal bayerImage As MIL_ID, ByVal WBCoefficients As MIL_ID, ByVal bayer As Int32) As Boolean
        MbufBayer(grabImage, bayerImage, WBCoefficients, bayer)
        Return True
    End Function

    'Public Function BayerConvertForHighQuality(ByVal grabImage As MIL_ID, ByVal bayerImage As MIL_ID, ByVal WBCoefficients As MIL_ID, ByVal bayer As MIL_ID) As Boolean
    '    'MbufBayer(grabImage,bayerImage,WBCoefficients, bayer+M_ADAPTIVE+M_COLOR_CORRECTION );
    '    MbufBayer(grabImage, bayerImage, WBCoefficients, bayer + M_ADAPTIVE)
    '    Return True
    'End Function

    Public Sub Dilate(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal iStep As Int32, ByVal bGrey As Boolean)
        MimDilate(srcImage, destImage, iStep, If((bGrey), M_GRAYSCALE, M_BINARY))
    End Sub

    Public Sub Erosion(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal iStep As Int32, ByVal bGrey As Boolean)
        MimErode(srcImage, destImage, iStep, If((bGrey), M_GRAYSCALE, M_BINARY))
    End Sub

    Public Sub Thinning(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal iStep As Int32, ByVal bGrey As Boolean)
        MimThin(srcImage, destImage, iStep, If((bGrey), M_GRAYSCALE, M_BINARY))
    End Sub

    Public Sub Thicking(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal iStep As Int32, ByVal bGrey As Boolean)
        MimThick(srcImage, destImage, iStep, If((bGrey), M_GRAYSCALE, M_BINARY))
    End Sub

    Public Sub Resize(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        MimResize(srcImage, destImage, M_FILL_DESTINATION, M_FILL_DESTINATION, M_INTERPOLATE + M_OVERSCAN_ENABLE + M_FAST)
    End Sub

    ' Rotating Image   ::화면의 중심기준
    Public Sub RotatingImage(ByVal srcImage As MIL_ID, ByRef trgImage As MIL_ID, ByVal Angle As Single)
        MimRotate(srcImage, trgImage, Angle, M_DEFAULT, M_DEFAULT, M_DEFAULT, _
         M_DEFAULT, M_BILINEAR + M_OVERSCAN_CLEAR)
    End Sub

    ' Rotating Image   ::특정 Position기준
    Public Sub RotatingImage(ByVal srcImage As MIL_ID, ByRef trgImage As MIL_ID, ByVal Angle As Single, ByVal centerX As Int32, ByVal centerY As Int32)
        MimRotate(srcImage, trgImage, Angle, centerX, centerY, centerX, _
         centerY, M_BILINEAR + M_OVERSCAN_CLEAR)
    End Sub

    ' Rotating Image   ::화면의 중심기준
    Public Sub RotatingImage(ByVal srcImage As MIL_ID, ByVal Angle As Single)
        Dim destImage As MIL_ID = M_NULL
        GetCompatibleBuffer(srcImage, destImage)
        MimRotate(srcImage, destImage, Angle, M_DEFAULT, M_DEFAULT, M_DEFAULT, _
         M_DEFAULT, M_BICUBIC + M_OVERSCAN_CLEAR)
        MbufCopy(destImage, srcImage)
        MbufFree(destImage)
    End Sub

    Public Sub RotateImage180Degree(ByVal srcImage As MIL_ID, ByRef dstImage As MIL_ID)
        If M_NULL = srcImage OrElse M_NULL = dstImage Then
            Return
        End If

        MimFlip(srcImage, srcImage, M_FLIP_HORIZONTAL, M_DEFAULT)
        MimFlip(srcImage, dstImage, M_FLIP_VERTICAL, M_DEFAULT)
    End Sub

    Public Sub FilpImage(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal bHorizontal As Boolean)
        If bHorizontal Then
            MimFlip(srcImage, destImage, M_FLIP_HORIZONTAL, M_DEFAULT)
        Else
            MimFlip(srcImage, destImage, M_FLIP_VERTICAL, M_DEFAULT)
        End If
    End Sub

    '*
    '    @author	:LG.PRI.WOOCHUL
    '    @brief	: Model Find로 두개의 이미지를 매칭시켰을때 좌우상하 Shifting되어 Defect로 검출되는 경우,이의 제거를 위해 사용
    '
    '    - 좌우상하 주어진 픽셀거리 만큼 강제로 결함 제거시킴 
    '    @param		srcImage: 검출이미지,destImage: 필터링 된 이미지 
    '    @return		:
    '    @see	:
    '    @date	:2009.3.4
    '    

    Public Sub SideAreaFilter(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal Side As Rectangle)
        'FOV양끝부분 Dft추출되는 현상방지를 위한 끝부분 무시
        Dim width As Int32 = 0, height As Int32 = 0
        GetImageSize(srcImage, width, height)
        Dim srcbuffer As Byte() = New Byte(width * height - 1) {}
        MbufGet2d(srcImage, 0, 0, width, height, srcbuffer)
        'M_PLANAR(RRR...GGG...BBB...)
        Dim Di As Int32 = 0, Ri As Int32 = 0

        Dim i As Int32, yi As Int32, xi As Int32
        For i = 0 To Side.Left - 1
            For yi = 0 To height - 1
                srcbuffer(i + yi * width) = 0
            Next
        Next

        For i = 0 To Side.Right - 1
            Ri = width - i - 1
            For yi = 0 To height - 1
                srcbuffer(Ri + yi * width) = 0
            Next
        Next

        For i = 0 To Side.Top - 1
            For xi = 0 To width - 1
                '위방향
                srcbuffer(xi + i * width) = 0
            Next
        Next

        For i = 0 To Side.Bottom - 1
            Di = height - i - 1
            For xi = 0 To width - 1
                '아래방향
                srcbuffer(xi + Di * width) = 0
            Next
        Next

        MbufPut(destImage, srcbuffer)
    End Sub

    Public Sub Subtract(ByVal insImage As MIL_ID, ByVal refImage As MIL_ID, ByRef resultImage As MIL_ID)
        MimArith(insImage, refImage, resultImage, M_SUB_ABS)
    End Sub

    Public Sub Add(ByVal insImage As MIL_ID, ByVal refImage As MIL_ID, ByRef resultImage As MIL_ID)
        MimArith(insImage, refImage, resultImage, M_ADD + M_SATURATION)
    End Sub

    Public Sub [And](ByVal insImage As MIL_ID, ByVal refImage As MIL_ID, ByRef resultImage As MIL_ID)
        MimArith(insImage, refImage, resultImage, M_AND)
    End Sub

    Public Sub Binarize(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal dThld As Double)
        '=0
        If 0 = dThld Then
            ' 기준 자동계산
            Dim lNewThld As Int32 = MimBinarize(srcImage, M_NULL, M_GREATER_OR_EQUAL, M_DEFAULT, M_DEFAULT)
            MimBinarize(srcImage, destImage, M_GREATER_OR_EQUAL, CDbl(lNewThld), M_DEFAULT)
        Else
            MimBinarize(srcImage, destImage, M_GREATER_OR_EQUAL, dThld, M_DEFAULT)
        End If
    End Sub

    Public Sub HighPassFilter(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        MimConvolve(srcImage, destImage, M_SHARPEN2)
    End Sub

    Public Sub HighPassFilter(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal ival As Int32)
        MimConvolve(srcImage, destImage, M_DERICHE_FILTER(M_SHARPEN, ival))
    End Sub

    Public Sub LowPassFilter(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        MimConvolve(srcImage, destImage, M_SMOOTH)
    End Sub

    Public Sub LowPassFilter(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal ival As Int32)
        MimConvolve(srcImage, destImage, M_DERICHE_FILTER(M_SMOOTH, ival))
    End Sub

    Public Sub MedianFilter(ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID)
        MimRank(srcImage, destImage, M_3X3_RECT, M_MEDIAN, M_BINARY)
    End Sub

    Public Sub MedianFilter(ByVal size As Int32, ByVal srcImage As MIL_ID, ByRef destImage As MIL_ID, ByVal binary As Boolean)
        '=false
        Dim i As Integer, j As Integer
        Dim structArray As Int32(,) = New Int32(size - 1, size - 1) {}
        For i = 0 To size - 1
            'structArray[i] = new Int32[size];
            For j = 0 To size - 1
                structArray(i, j) = 1
            Next
        Next

        Dim structElem As MIL_ID = M_NULL
        'adrMil()->MilSystem
        MbufAlloc2d(M_DEFAULT_HOST, size, size, 32 + M_SIGNED, M_STRUCT_ELEMENT, structElem)
        MbufPut2d(structElem, 0, 0, size, size, structArray)
        MimRank(srcImage, destImage, structElem, M_MEDIAN, If((binary), M_BINARY, M_GRAYSCALE))
        MbufFree(structElem)
    End Sub

    Public Sub GetROIImage(ByVal src As MIL_ID, ByRef dst As MIL_ID, ByVal rect As Rectangle)
        Dim tmp As MIL_ID = M_NULL

        If rect.IsEmpty Then
            'ROI가 지정되어 있지않으면 전체 이미지로
            Dim tmpsX As Int32 = 0, tmpsY As Int32 = 0
            GetImageSize(src, tmpsX, tmpsY)
            MbufChild2d(src, 0, 0, tmpsX, tmpsY, tmp)
        Else
            MbufChild2d(src, rect.Left, rect.Top, rect.Width, rect.Height, tmp)
        End If
        GetCompatibleBuffer(tmp, dst)
        MbufCopy(tmp, dst)
        MbufFree(tmp)
    End Sub

    Public Sub GetHistogram(ByVal srcImage As MIL_ID, ByRef histoVal As Int32())
        Dim histoResult As MIL_ID = M_NULL
        MimAllocResult(M_DEFAULT_HOST, 256, M_HIST_LIST, histoResult)

        Dim band As Int32 = GetImageBand(srcImage)
        If CType(ImageBand.COLORBAND, Int32) = band Then
            Dim destImage As MIL_ID = M_NULL
            GetCompatibleGrayBuffer(srcImage, destImage)
            ConvertToLuminant(srcImage, destImage)
            MimHistogram(destImage, histoResult)
            MbufFree(destImage)
        Else
            MimHistogram(srcImage, histoResult)
        End If
        MimGetResult(histoResult, M_VALUE, histoVal)
        MimFree(histoResult)
    End Sub

    'srcImage의 x,y 위치의 pixel 값(r,g,b) 얻기
    'unsinged char rgb[3]--r,g,b
    Public Function GetPxlValue(ByVal scrImage As MIL_ID, ByVal x As Int32, ByVal y As Int32, ByRef rgb As Byte()) As Boolean
        Dim band As Int32 = GetImageBand(scrImage)
        If CType(ImageBand.COLORBAND, Int32) = band Then
            Dim r As Byte() = New Byte(0) {}
            Dim g As Byte() = New Byte(0) {}
            Dim b As Byte() = New Byte(0) {}

            MbufGetColor2d(scrImage, M_SINGLE_BAND, M_RED, x, y, 1, _
             1, r)
            MbufGetColor2d(scrImage, M_SINGLE_BAND, M_GREEN, x, y, 1, _
             1, g)
            MbufGetColor2d(scrImage, M_SINGLE_BAND, M_BLUE, x, y, 1, _
             1, b)

            rgb(0) = r(0)
            rgb(1) = g(0)
            rgb(2) = b(0)
        Else
            MbufGet2d(scrImage, x, y, 1, 1, rgb)
        End If
        Return True
    End Function

    Public Function GetPxlValue(ByVal scrImage As MIL_ID, ByVal x As Int32, ByVal y As Int32, ByRef rgb As Color) As Boolean
        Dim r As Int32 = 0, g As Int32 = 0, b As Int32 = 0
        Dim band As Int32 = GetImageBand(scrImage)
        If CType(ImageBand.COLORBAND, Int32) = band Then
            MbufGetColor2d(scrImage, M_SINGLE_BAND, M_RED, x, y, 1, _
             1, r)
            MbufGetColor2d(scrImage, M_SINGLE_BAND, M_GREEN, x, y, 1, _
             1, g)
            MbufGetColor2d(scrImage, M_SINGLE_BAND, M_BLUE, x, y, 1, _
             1, b)
        Else
            Dim value As Int32() = New Int32(0) {}
            MbufGet2d(scrImage, x, y, 1, 1, value)
            r = value(0)
        End If

        rgb = Color.FromArgb(r, g, b)

        Return True
    End Function

    ' 2012-03-30 Keunuk.LEE Edge Detection Algorithm 개선
    ' 이미지 특정 영역의 평균밝기를 구해서 반환
    Public Function GetRoiBrightness(ByVal image As MIL_ID, ByVal rect As Rectangle) As Double
        If M_NULL = image Then
            Return 0.0
        End If

        'rect.NormalizeRect();
        If rect.IsEmpty Then
            Return 0.0
        End If

        Dim lSizeX As Int32 = 0, lSizeY As Int32 = 0
        GetImageSize(image, lSizeX, lSizeY)

        ' by Keunuk.Lee 2012-06-28 화면 밖을 벗어난 Edge에 의한 Debug Fix
        If lSizeX - 1 < rect.Left OrElse rect.Right < 0 OrElse lSizeY - 1 < rect.Top OrElse rect.Bottom < 0 Then
            Return 0.0
        End If

        rect.X = Utility.Max(0, rect.Left)
        rect.Width = Utility.Min(rect.Right, lSizeX - 1) - rect.X
        rect.Y = Utility.Max(0, rect.Top)
        rect.Height = Utility.Min(rect.Bottom, lSizeY - 1) - rect.Y

        Dim child As MIL_ID = M_NULL
        MbufChild2d(image, rect.Left, rect.Top, rect.Width, rect.Height, child)

        Dim iSize As Int32 = rect.Width * rect.Height
        Dim pData As Byte() = New Byte(iSize - 1) {}
        MbufGetColor(child, M_SINGLE_BAND, M_ALL_BANDS, pData)
        MbufFree(child)

        Dim iSum As Integer = 0
        For i As Integer = 0 To iSize - 1
            iSum += CInt(pData(i))
        Next

        Return CDbl(iSum) / CDbl(iSize)

        ' by Keunuk.Lee 2012-09-28 Edge Detection 시에 평균값 대신 중간값 사용
        ' 연산에 시간이 너무 오래 걸려서 타임오버 발생. 일단 사용하지 않는다
        '	MbufFree(child);
        '	    std::vector<int> vBrightness;
        '	    for(UINT i = 0; i < iSize; i++)
        '	    {
        '		    vBrightness.push_back((int)pData[i]);
        '	    }
        '	    delete[] pData;
        '
        '	    size_t n = vBrightness.size() / 2;
        '	    static int i = 0;
        '	    //TRACE(_T("START: %d\n"), i++);
        '	    nth_element(vBrightness.begin(),vBrightness.begin() + n,vBrightness.end());
        '	    TRACE(_T("END: %d\n"), vBrightness[n]);
        '	    return vBrightness[n];
        '    

    End Function

    Public Function GetLinePxlValues(ByVal scrImage As MIL_ID, ByVal stPt As Point, ByVal edPt As Point, ByRef data As List(Of Byte)) As Boolean
        Dim width As Int32 = Math.Abs(edPt.X - stPt.X) + 1
        Dim height As Int32 = Math.Abs(edPt.Y - stPt.Y) + 1

        If width <> 1 AndAlso height <> 1 Then
            Return False
        End If
        ' 1 line scan
        Dim lx As Int32 = 0, ly As Int32 = 0
        GetImageSize(scrImage, lx, ly)
        If stPt.X < 0 OrElse stPt.X >= lx OrElse stPt.Y < 0 OrElse stPt.Y >= ly Then
            Return False
        End If
        If edPt.X < 0 OrElse edPt.X >= lx OrElse edPt.Y < 0 OrElse edPt.Y >= ly Then
            Return False
        End If

        Dim bufsize As Int32 = width * height
        Dim srcbuffer As Byte() = New Byte(bufsize - 1) {}

        Dim grayImage As MIL_ID = M_NULL
        Dim bAlloced As Boolean = False
        If CType(ImageBand.COLORBAND, Int32) = GetImageBand(scrImage) Then
            'We need buffer conversion to the grey buffer
            GetCompatibleGrayBuffer(scrImage, grayImage)
            ConvertToLuminant(scrImage, grayImage)
            'greyImage buffer should be released
            bAlloced = True
        Else
            grayImage = scrImage
        End If
        MbufGet2d(scrImage, stPt.X, stPt.Y, width, height, srcbuffer)

        data.Clear()
        For i As Integer = 0 To bufsize - 1
            data.Add(srcbuffer(i))
        Next

        If bAlloced Then
            MbufFree(grayImage)
        End If
        Return True
    End Function

    Public Sub GetPxlValues(ByVal srcImage As MIL_ID, ByRef pts As List(Of Point), ByRef diffs As List(Of Int32))
        Dim bAllocated As Boolean = False
        Dim GrayImage As MIL_ID = M_NULL
        Dim Band As Int32 = GetImageBand(srcImage)
        If Band = CType(ImageBand.COLORBAND, Int32) Then
            GetCompatibleGrayBuffer(srcImage, GrayImage)
            ConvertToLuminant(srcImage, GrayImage)
            bAllocated = True
        Else
            GrayImage = srcImage
        End If

        Dim ptssize As Integer = pts.Count
        Dim rgb As Byte() = {0, 0, 0}
        For i As Integer = 0 To ptssize - 1
            GetPxlValue(GrayImage, pts(i).X, pts(i).Y, rgb)
            diffs.Add(rgb(0))
        Next
        If bAllocated Then
            MbufFree(GrayImage)
        End If
    End Sub

    Public Sub GetDifferentialValues(ByVal srcImage As MIL_ID, ByRef pts As List(Of Point), ByRef diffs As List(Of Int32))
        Dim width As Int32 = 0, height As Int32 = 0
        Dim i As Integer = 0
        GetImageSize(srcImage, width, height)
        Dim bAllocated As Boolean = False
        Dim GrayImage As MIL_ID = M_NULL
        Dim Band As Int32 = GetImageBand(srcImage)
        If Band = CType(ImageBand.COLORBAND, Int32) Then
            GetCompatibleGrayBuffer(srcImage, GrayImage)
            ConvertToLuminant(srcImage, GrayImage)
            bAllocated = True
        Else
            GrayImage = srcImage
        End If

        Dim ptssize As Integer = pts.Count
        Dim rgb As Byte() = {0, 0, 0}
        Dim values As New List(Of Byte)()
        For i = 0 To ptssize - 1
            If pts(i).X < 0 OrElse pts(i).X > width - 1 OrElse pts(i).Y < 0 OrElse pts(i).Y > height - 1 Then
                values.Clear()
                diffs.Clear()
                If bAllocated Then
                    MbufFree(GrayImage)
                End If
                Return
            End If
            GetPxlValue(GrayImage, pts(i).X, pts(i).Y, rgb)
            values.Add(rgb(0))
        Next

        Dim first As Integer = 0, second As Integer = 0
        For i = 0 To ptssize - 1
            first = values(i)
            If i < ptssize - 1 Then
                second = values(i + 1)
                diffs.Add(second - first)
            End If
        Next

        If bAllocated Then
            MbufFree(GrayImage)
        End If
    End Sub

    '''//////////////////////////////////////////////////////////////
    '''@author	:LG.PRI.WOOCHUL
    '''@brief	: 이미지상에 주어진 기준점위치를 십자마크로 Drawing하는 함수
    '''- MilLibrary의 Migra.. 함수를 사용하며 그리며, 선폭 파라미터를 설정하기가 어려우므로 여러번 중첩시켜 Drawing 함.
    '''- 우선은 Passivation의 Dotting위치를 이미지상에 디스플레이하여 작업자가 제대로 보정이 이루어졌는지 확인하기 위하여 표시함.
    '''@param	MIL_ID srcImage: Drawing 할 Image Buffer, CPoint ptRef: Drawing할 기준점의 위치
    '''@return	BOOL 연산 실패여부 반환
    '''@see	:
    '''@date	:2009.3.11
    '''//////////////////////////////////////////////////////////////

    Public Function DrawMarkCenter(ByVal srcImage As MIL_ID, ByVal ptRef As Point, ByVal rgb As Color) As Boolean
        '= RGB(255,0,0)
        If srcImage = M_NULL Then
            Return False
        End If
        Dim ptStHor As Point, ptEdHor As Point, ptStVer As Point, ptEdVer As Point

        '십자선의 수평선,수직선 선길이 60으로 함.
        ptStHor = New Point(ptRef.X - 10, ptRef.Y)
        ptEdHor = New Point(ptRef.X + 10, ptRef.Y)
        ptStVer = New Point(ptRef.X, ptRef.Y + 10)
        ptEdVer = New Point(ptRef.X, ptRef.Y - 10)

        ' Line의 Color Setting
        MgraColor(M_DEFAULT, M_RGB888(rgb.R, rgb.G, rgb.B))

        ' 두께를 고려해서 여러번 중첩해서 그린다.
        'for(int i=-1;i<=1;i++)
        '{
        '	ptStHor.Offset(0,i);
        '	ptEdHor.Offset(0,i);
        '	MgraLine(M_DEFAULT,srcImage,ptStHor.x,ptStHor.y,ptEdHor.x,ptEdHor.y);

        '	ptStHor.Offset(i,0);
        '	ptEdHor.Offset(i,0);
        '	MgraLine(M_DEFAULT,srcImage,ptStVer.x,ptStVer.y,ptEdVer.x,ptEdVer.y);
        '}

        ' 그냥 한줄만 그린다
        MgraLine(M_DEFAULT, srcImage, ptStHor.X, ptStHor.Y, ptEdHor.X, ptEdHor.Y)
        MgraLine(M_DEFAULT, srcImage, ptStVer.X, ptStVer.Y, ptEdVer.X, ptEdVer.Y)

        Return True
    End Function

    '''//////////////////////////////////////////////////////////////
    '''@author	:LG.PRI.WOOCHUL
    '''@brief	: 이미지상에 주어진 TEXT를 쓰는 함수 
    '''- FONT 는 M_FONT_DEFAULT_MEDIUM 로 설정함.
    '''- 
    '''@param	MIL_ID srcImage: Drawing 할 Image Buffer, CPoint ptLeftTop: Drawing할 기준점의 Left-Top 위치, szArray:Drawing할 Text의 Array값
    '''@return	BOOL 연산 실패여부 반환
    '''@see	
    '''@date	:2009.3.11
    '''//////////////////////////////////////////////////////////////

    Public Function DrawText(ByVal srcImage As MIL_ID, ByVal ptLeftTop As Point, ByRef szArray As List(Of String), ByVal rgb As Color) As Boolean
        '= RGB(255,255,255)
        If srcImage = M_NULL Then
            Return False
        End If

        MgraColor(M_DEFAULT, M_RGB888(rgb.R, rgb.G, rgb.B))
        MgraControl(M_DEFAULT, M_BACKGROUND_MODE, M_TRANSPARENT)

        MgraFont(M_DEFAULT, M_FONT_DEFAULT_MEDIUM)
        'M_FONT_DEFAULT_SMALL (8x16 Pxl),M_FONT_DEFAULT_LARGE (16x32 Pxl),M_FONT_DEFAULT_MEDIUM(12x24 Pxl)
        Dim iHeight As Integer = 16
        'PXL HEIGHT + MARGIN
        Dim isize As Integer = szArray.Count
        For i As Integer = 0 To isize - 1
            Dim szText As String = szArray(i)

            MgraText(M_DEFAULT, srcImage, ptLeftTop.X, ptLeftTop.Y + iHeight * i, szText)
        Next

        Return True
    End Function

    ' 2012-05-17 Keunuk.LEE Edge Detection 결과 출력이미지
    Public Function DrawText(ByVal srcImage As MIL_ID, ByVal ptLeftTop As Point, ByVal strText As String, ByVal rgb As Color) As Boolean
        '=RGB(255,255,255)
        If M_NULL = srcImage Then
            Return False
        End If

        MgraColor(M_DEFAULT, M_RGB888(rgb.R, rgb.G, rgb.B))
        MgraControl(M_DEFAULT, M_BACKGROUND_MODE, M_TRANSPARENT)
        MgraFont(M_DEFAULT, M_FONT_DEFAULT_MEDIUM)
        'M_FONT_DEFAULT_SMALL (8x16 Pxl),M_FONT_DEFAULT_LARGE (16x32 Pxl),M_FONT_DEFAULT_MEDIUM(12x24 Pxl)
        MgraText(M_DEFAULT, srcImage, ptLeftTop.X, ptLeftTop.Y, strText)

        Return True
    End Function

    '''//////////////////////////////////////////////////////////////
    '''@author	:LG.PRI.WOOCHUL
    '''@brief	: 이미지상에 주어진 Edge Chain Code들을 그리는 함수
    '''- MilLibrary의 Migra.. 함수를 사용하며 그림.
    '''@return	BOOL 연산 실패여부 반환
    '''@see	:
    '''@date	:2010.11.18
    '''//////////////////////////////////////////////////////////////

    Public Function DrawMarkBoundary(ByVal srcImage As MIL_ID, ByVal lEdgelsNum As Integer, ByVal ptEndgels As Point(), ByVal rgb As Color) As Boolean
        '= RGB(255,0,0)
        If srcImage = M_NULL Then
            Return False
        End If
        If lEdgelsNum < 2 Then
            Return False
        End If

        ' Line의 Color Setting
        MgraColor(M_DEFAULT, M_RGB888(rgb.R, rgb.G, rgb.B))

        ' 두께를 고려해서 여러번 중첩해서 그린다.
        For i As Integer = 0 To lEdgelsNum - 2
            MgraLine(M_DEFAULT, srcImage, ptEndgels(i).X, ptEndgels(i).Y, ptEndgels(i + 1).X, ptEndgels(i + 1).Y)
        Next
        Return True
    End Function

    '''//////////////////////////////////////////////////////////////
    '''@author	:LG.PRI.INSIK
    '''@brief	: 이미지상에 주어진 Edge Chain Code들을 그리는 함수
    '''- MilLibrary의 Migra.. 함수를 사용하며 그림.
    '''@return	BOOL 연산 실패여부 반환
    '''@see	:
    '''@date	:2011.3.12
    '''//////////////////////////////////////////////////////////////

    Public Function DrawCircleBoundary(ByVal srcImage As MIL_ID, ByVal ptCenter As Point, ByVal lRad As Integer, ByVal rgb As Color) As Boolean
        '= RGB(255,0,0)
        If srcImage = M_NULL Then
            Return False
        End If

        ' Line의 Color Setting
        MgraColor(M_DEFAULT, M_RGB888(rgb.R, rgb.G, rgb.B))
        For i As Integer = 0 To 2
            MgraArc(M_DEFAULT, srcImage, ptCenter.X, ptCenter.Y, lRad, lRad, _
             0.0, 360.0)
        Next
        Return True
    End Function

    '''//////////////////////////////////////////////////////////////
    '''@author	:LG.PRI.WOOCHUL
    '''@brief	: 이미지상에 RECT그리는 함수
    '''- MilLibrary의 Migra.. 함수를 사용하며 그림.
    '''@return	BOOL 연산 실패여부 반환
    '''@see	:
    '''@date	:2010.11.18
    '''//////////////////////////////////////////////////////////////

    Public Function DrawRect(ByVal srcImage As MIL_ID, ByVal rtRect As Rectangle, ByVal rgb As Color) As Boolean
        '= RGB(255,0,0)
        If srcImage = M_NULL Then
            Return False
        End If

        ' Line의 Color Setting
        MgraColor(M_DEFAULT, M_RGB888(rgb.R, rgb.G, rgb.B))

        MgraLine(M_DEFAULT, srcImage, rtRect.Left, rtRect.Top, rtRect.Right, rtRect.Top)
        MgraLine(M_DEFAULT, srcImage, rtRect.Right, rtRect.Top, rtRect.Right, rtRect.Bottom)
        MgraLine(M_DEFAULT, srcImage, rtRect.Right, rtRect.Bottom, rtRect.Left, rtRect.Bottom)
        MgraLine(M_DEFAULT, srcImage, rtRect.Left, rtRect.Bottom, rtRect.Left, rtRect.Top)
        Return True
    End Function

    ' 2012-04-01 Keunuk.LEE Cutting Offset Dialog GUI 개선
    '=40
    '=3
    Public Function DrawCross(ByVal image As MIL_ID, ByVal pt As Point, ByVal iSize As Integer, ByVal iWidth As Integer, ByVal rgb As Color) As Boolean
        '= RGB(255,0,0)
        If image = M_NULL Then
            Return False
        End If

        MgraColor(M_DEFAULT, M_RGB888(rgb.R, rgb.G, rgb.B))

        Dim iRange As Integer = Utility.Max(0, iWidth \ 2)
        Dim ptStHor As Point, ptEdHor As Point, ptStVer As Point, ptEdVer As Point

        For i As Integer = -iRange To iRange
            ptStHor = New Point(pt.X - iSize, pt.Y)
            ptEdHor = New Point(pt.X + iSize, pt.Y)

            ptStHor.Offset(0, i)
            ptEdHor.Offset(0, i)

            MgraLine(M_DEFAULT, image, ptStHor.X, ptStHor.Y, ptEdHor.X, ptEdHor.Y)
        Next

        For i As Integer = -iRange To iRange
            ptStVer = New Point(pt.X, pt.Y + iSize)
            ptEdVer = New Point(pt.X, pt.Y - iSize)

            ptStVer.Offset(i, 0)
            ptEdVer.Offset(i, 0)
            MgraLine(M_DEFAULT, image, ptStVer.X, ptStVer.Y, ptEdVer.X, ptEdVer.Y)
        Next

        Return True
    End Function

    Public Function FindAlignMark(ByVal image As MIL_ID, ByVal condition As MIL_ID, ByRef result As MIL_ID, ByRef dOffsetX As Double, ByRef dOffsetY As Double) As Boolean
        Dim dScore As Double = 0.0
        Dim dT As Double = 0.0

        Return FindAlignMark(image, condition, result, dOffsetX, dOffsetY, dT, dScore)
    End Function

    Public Function FindAlignMark(ByVal image As MIL_ID, ByVal condition As MIL_ID, ByRef result As MIL_ID, ByRef dOffsetX As Double, ByRef dOffsetY As Double, ByRef dT As Double, ByRef dScore As Double) As Boolean
        Dim bResult As Boolean = False

        Dim dX As Double = 0.0, dY As Double = 0.0

        bResult = FindModel(image, condition, result, dX, dY, dT, dScore)

        If bResult Then
            'Center 기준 Offset(X는 오른쪽이 (+), Y축은 위쪽이 (+)
            Dim lSizeX As Int32 = 0, lSizeY As Int32 = 0
            GetImageSize(image, lSizeX, lSizeY)

            'GYN - TEST 
            'dOffsetX = (dX - (CDbl(lSizeX) / 2.0))
            'dOffsetY = ((CDbl(lSizeY) / 2.0) - dY)

            dOffsetX = dX
            dOffsetY = dY

            Dim ptFound As New Point(CInt(Math.Truncate(dX)), CInt(Math.Truncate(dY)))
            DrawMarkCenter(image, ptFound, Color.FromArgb(255, 0, 0))
        Else
            dOffsetX = 0.0
            dOffsetY = 0.0
        End If

        Return bResult
    End Function

    Public Function FindModel(ByVal image As MIL_ID, ByVal condition As MIL_ID, ByRef result As MIL_ID, ByRef dX As Double, ByRef dY As Double, ByRef dT As Double, ByRef dScore As Double) As Boolean
        Dim bResult As Boolean = False

        Dim temp As MIL_ID = M_NULL
        GetCompatibleGrayBuffer(image, temp)
        If CInt(ImageBand.COLORBAND) = GetImageBand(image) Then
            ConvertToLuminant(image, temp)
        Else
            CopyImage(image, temp)
        End If
        MmodFind(condition, temp, result)
        MbufFree(temp)

        Dim nModel As Int32 = 0
        MmodGetResult(result, M_DEFAULT, M_NUMBER + M_TYPE_LONG, nModel)
        If nModel = 0 OrElse 1 > nModel Then
            bResult = False
        Else
            MmodGetResult(result, 0, M_POSITION_X, dX)
            MmodGetResult(result, 0, M_POSITION_Y, dY)
            MmodGetResult(result, 0, M_SEARCH_ANGLE, dT)
            MmodGetResult(result, 0, M_SCORE, dScore)
            bResult = True
        End If

        Return bResult
    End Function

    Public Function FindModelScaled(ByVal image As MIL_ID, ByVal conditionScaled As MIL_ID, ByRef result As MIL_ID, ByRef dX As Double, ByRef dY As Double, ByVal dScale As Double) As Boolean
        If M_NULL = image OrElse M_NULL = conditionScaled OrElse M_NULL = result Then
            Return False
        End If
        If 0.0 = dScale Then
            Return False
        End If

        Dim dT As Double

        Dim lSizeX As Int32 = 0, lSizeY As Int32 = 0
        GetImageSize(image, lSizeX, lSizeY)

        Dim iSizeXScaled As Integer = CInt(Math.Truncate(CDbl(lSizeX) * dScale))
        Dim iSizeYScaled As Integer = CInt(Math.Truncate(CDbl(lSizeY) * dScale))
        Dim imageScaled As MIL_ID = M_NULL
        GetCompatibleBuffer(image, imageScaled, iSizeXScaled, iSizeYScaled)
        MimResize(image, imageScaled, M_FILL_DESTINATION, M_FILL_DESTINATION, M_DEFAULT)

        Dim dXScaled As Double = 0.0, dYScaled As Double = 0.0, dScore As Double = 0.0
        Dim bRet As Boolean = FindModel(imageScaled, conditionScaled, result, dXScaled, dYScaled, dT, dScore)

        MbufFree(imageScaled)

        If bRet Then
            dX = dXScaled / dScale
            ' 원래 Scale로 원복해서 값을 반환
            dY = dYScaled / dScale

            Return True
        Else
            dX = 0
            dY = 0

            Return False
        End If
    End Function

    Public Function FindAlignMarkScaled(ByVal image As MIL_ID, ByVal conditionScaled As MIL_ID, ByRef result As MIL_ID, ByRef dOffsetX As Double, ByRef dOffsetY As Double, ByVal dScale As Double) As Boolean
        If M_NULL = image OrElse M_NULL = conditionScaled OrElse M_NULL = result Then
            Return False
        End If
        If 0.0 = dScale Then
            Return False
        End If

        Dim lSizeX As Int32 = 0, lSizeY As Int32 = 0
        GetImageSize(image, lSizeX, lSizeY)

        Dim dT As Double

        Dim iSizeXScaled As Integer = CInt(Math.Truncate(CDbl(lSizeX) * dScale))
        Dim iSizeYScaled As Integer = CInt(Math.Truncate(CDbl(lSizeY) * dScale))
        Dim imageScaled As MIL_ID = M_NULL
        GetCompatibleBuffer(image, imageScaled, iSizeXScaled, iSizeYScaled)
        MimResize(image, imageScaled, M_FILL_DESTINATION, M_FILL_DESTINATION, M_DEFAULT)

        Dim dOffsetXScaled As Double = 0.0, dOffsetYScaled As Double = 0.0, dScore As Double = 0.0
        Dim bRet As Boolean = FindAlignMark(imageScaled, conditionScaled, result, dOffsetXScaled, dOffsetYScaled, dT, dScore)

        MbufFree(imageScaled)

        If bRet Then
            dOffsetX = dOffsetXScaled / dScale
            ' 원래 Scale로 원복해서 값을 반환
            dOffsetY = dOffsetYScaled / dScale

            Dim ptFound As New Point(CInt(Math.Truncate(dOffsetX + CDbl(lSizeX) / 2.0)), CInt(Math.Truncate(CDbl(lSizeY) / 2.0 - dOffsetY)))
            DrawMarkCenter(image, ptFound, Color.FromArgb(255, 0, 0))

            Return True
        Else
            dOffsetX = 0
            dOffsetY = 0

            Return False
        End If
    End Function

    Public Function FindEdgePointsByCannyDetection(ByVal srcImage As MIL_ID, ByVal destImage As MIL_ID, ByVal iThldHigh As Integer, ByVal iThldLow As Integer) As Boolean
        If M_NULL = srcImage OrElse M_NULL = destImage Then
            Return False
        End If

        If CInt(ImageBand.GRAYBAND) <> GetImageBand(srcImage) OrElse CInt(ImageBand.GRAYBAND) <> GetImageBand(destImage) Then
            Return False
        End If

        Dim lSizeX As Int32 = 0, lSizeY As Int32 = 0, lSizeX2 As Int32 = 0, lSizeY2 As Int32 = 0
        GetImageSize(srcImage, lSizeX, lSizeY)
        GetImageSize(destImage, lSizeX2, lSizeY2)

        If lSizeX < 1 OrElse lSizeY < 1 OrElse lSizeX <> lSizeX2 OrElse lSizeY <> lSizeY2 Then
            Return False
        End If

        Dim iWidth As Integer = lSizeX
        Dim iHeight As Integer = lSizeY
        Dim pGray As Byte() = New Byte(iWidth * iHeight - 1) {}
        Dim pEdge As Byte() = New Byte(iWidth * iHeight - 1) {}

        MbufGetColor(srcImage, M_SINGLE_BAND, M_ALL_BANDS, pGray)
        CannyEdge(pGray, iWidth, iHeight, iThldHigh, iThldLow, pEdge)
        MbufPut(destImage, pEdge)

        Return True
    End Function

    Public Sub CannyEdge(ByVal pImage As Byte(), ByVal width As Integer, ByVal height As Integer, ByVal th_high As Integer, ByVal th_low As Integer, ByRef pEdge As Byte())
        Dim i As Integer, j As Integer

        Dim dx As Integer, dy As Integer, mag As Integer, slope As Integer, direction As Integer
        Dim index As Integer, index2 As Integer

        Const fbit As Integer = 10
        Const tan225 As Integer = 424
        ' tan25.5 << fbit, 0.4142
        Const tan675 As Integer = 2472
        ' tan67.5 << fbit, 2.4142 
        Const CERTAIN_EDGE As Integer = 255
        Const PROBABLE_EDGE As Integer = 100

        '#define CANNY_PUSH(p)    *(p) = CERTAIN_EDGE, *(stack_top++) = (p) 
        '#define CANNY_POP()      *(--stack_top)

        Dim bMaxima As Boolean

        Dim mag_tbl As Integer() = New Integer(width * height - 1) {}
        Dim dx_tbl As Integer() = New Integer(width * height - 1) {}
        Dim dy_tbl As Integer() = New Integer(width * height - 1) {}

        Dim stack_top As Byte()(), stack_bottom As Byte()()
        stack_top = New Byte(width * height - 1)() {}
        stack_bottom = stack_top

        For i = 0 To width * height - 1
            mag_tbl(i) = 0
            pEdge(i) = 0
        Next

        ' Sobel Edge Detection     
        For i = 1 To height - 2
            index = i * width
            For j = 1 To width - 2
                index2 = index + j
                ' -1 0 1 
                ' -2 0 2 
                ' -1 0 1             
                dx = pImage(index2 - width + 1) + (pImage(index2 + 1) << 1) + pImage(index2 + width + 1) - pImage(index2 - width - 1) - (pImage(index2 - 1) << 1) - pImage(index2 + width - 1)

                ' -1 -2 -1       
                '  0  0  0
                '  1  2  1 
                dy = -pImage(index2 - width - 1) - (pImage(index2 - width) << 1) - pImage(index2 - width + 1) + pImage(index2 + width - 1) + (pImage(index2 + width) << 1) + pImage(index2 + width + 1)
                mag = Math.Abs(dx) + Math.Abs(dy)
                ' magnitude 
                'mag = sqrtf(dx*dx + dy*dy);
                dx_tbl(index2) = dx
                dy_tbl(index2) = dy
                ' store the magnitude in the table
                mag_tbl(index2) = mag
                ' for(j) 
            Next
        Next
        ' for(i)
        For i = 1 To height - 2
            index = i * width
            For j = 1 To width - 2
                index2 = index + j
                mag = mag_tbl(index2)
                ' retrieve the magnitude from the table 
                ' if the magnitude is greater than the lower threshold
                If mag > th_low Then
                    ' determine the orientation of the edge
                    dx = dx_tbl(index2)
                    dy = dy_tbl(index2)

                    If dx <> 0 Then
                        slope = (dy << fbit) \ dx
                        If slope > 0 Then
                            If slope < tan225 Then
                                direction = 0
                            ElseIf slope < tan675 Then
                                direction = 1
                            Else
                                direction = 2
                            End If
                        Else
                            If -slope > tan675 Then
                                direction = 2
                            ElseIf -slope > tan225 Then
                                direction = 3
                            Else
                                direction = 0
                            End If
                        End If
                    Else
                        direction = 2
                    End If

                    bMaxima = True
                    ' perform non-maxima suppression
                    If direction = 0 Then
                        If mag < mag_tbl(index2 - 1) OrElse mag < mag_tbl(index2 + 1) Then
                            bMaxima = False
                        End If
                    ElseIf direction = 1 Then
                        If mag < mag_tbl(index2 + width + 1) OrElse mag < mag_tbl(index2 - width - 1) Then
                            bMaxima = False
                        End If
                    ElseIf direction = 2 Then
                        If mag < mag_tbl(index2 + width) OrElse mag < mag_tbl(index2 - width) Then
                            bMaxima = False
                        End If
                    Else
                        ' if(direction == 3)
                        If mag < mag_tbl(index2 + width - 1) OrElse mag < mag_tbl(index2 - width + 1) Then
                            bMaxima = False
                        End If
                    End If
                    If bMaxima Then
                        If mag > th_high Then
                            ' the pixel does belong to an edge
                            '*(stack_top++) = (BYTE*)(pEdge+index2);
                            pEdge(index2) = CERTAIN_EDGE
                        Else
                            pEdge(index2) = PROBABLE_EDGE
                            ' the pixel might belong to an edge
                        End If
                    End If
                End If
                ' for(j) 
            Next
        Next
        ' for(i) 
        'while(stack_top != stack_bottom)
        '{
        '    BYTE* p = CANNY_POP();
        '    if(*(p+1) == PROBABLE_EDGE)
        '        CANNY_PUSH(p+1);
        '    if(*(p-1) == PROBABLE_EDGE)
        '        CANNY_PUSH(p-1);
        '    if(*(p+width) == PROBABLE_EDGE) 
        '        CANNY_PUSH(p+width);
        '    if(*(p-width) == PROBABLE_EDGE)
        '        CANNY_PUSH(p-width);
        '    if(*(p-width-1) == PROBABLE_EDGE) 
        '        CANNY_PUSH(p-width-1);
        '    if(*(p-width+1) == PROBABLE_EDGE)
        '        CANNY_PUSH(p-width+1);
        '    if(*(p+width-1) == PROBABLE_EDGE)
        '        CANNY_PUSH(p+width-1);
        '    if(*(p+width+1) == PROBABLE_EDGE)
        '        CANNY_PUSH(p+width+1);
        '} 

        For i = 0 To width * height - 1
            If pEdge(i) <> CERTAIN_EDGE Then
                pEdge(i) = 0
            End If
        Next

    End Sub


    ' 이미지 상의 경계점들을 잇는 직선 성분을 모두 검출해서 그 결과를 반환하는 함수
    ' Equation = ax + b (a는 직선의 기울기, b는 y절편...여기서는 이미지 중앙선에서의 y좌표)
    ' Count는 해당 직선 성분의 Edge Point 카운트 개수
    'Public Function HoughLineTransform(ByVal image As MIL_ID, ByVal iRange As Integer, ByRef vEquation As List(Of Double)(), ByRef vCount As List(Of Integer)) As Boolean
    '    vEquation = New List(Of Double)(1) {}
    '    vEquation(0) = New List(Of Double)()
    '    vEquation(1) = New List(Of Double)()
    '    vCount = New List(Of Integer)()

    '    If M_NULL = image OrElse CInt(ImageBand.GRAYBAND) <> GetImageBand(image) OrElse iRange < 1 Then
    '        Return False
    '    End If

    '    vEquation(0).Clear()
    '    vEquation(1).Clear()
    '    vCount.Clear()

    '    Dim lSizeX As Int32 = 0, lSizeY As Int32 = 0
    '    GetImageSize(image, lSizeX, lSizeY)
    '    Dim iWidth As Integer = lSizeX, iHeight As Integer = lSizeY

    '    Dim pEdge As Byte() = New Byte(iWidth * iHeight - 1) {}
    '    MbufGetColor(image, M_SINGLE_BAND, M_ALL_BANDS, pEdge)

    '    Dim temp As New Deskew()
    '    temp.Init(pEdge, iWidth, iHeight)
    '    temp.Calc()
    '    ' Calculate Hough transform
    '    Dim ttop As HougLine() = temp.GetTop(iRange)
    '    ' Get the best results
    '    'if(top == null)
    '    '{
    '    '    // 일단 이 상황이 발생할 수 없긴 한데...만일 여기에 들어오게 되면 메모리 누수가 발생하게 된다 
    '    '    //TRACE(_T("HoughLineTransform Failed - Memory Leak Occured"));

    '    '    return false;
    '    '}

    '    Dim dDegreeToRad As Double = Math.PI / 180.0
    '    'vEquation.cl;
    '    vCount.Clear()
    '    For i As Integer = 0 To iRange - 1
    '        Dim a As Double = -ttop(i).Alpha
    '        Dim b As Double = ttop(i).d / Math.Cos(ttop(i).Alpha * dDegreeToRad)
    '        ' 이미지 왼쪽 끝에서의 y좌표
    '        b = b - CDbl(iWidth) / 2.0 * Math.Tan(a * dDegreeToRad)
    '        ' 이미지 중앙에서의 y좌표
    '        Dim iCount As Integer = ttop(i).Count
    '        'delete top[i];

    '        'TRACE(_T("Best %d is %f, %f, %d\n"),i,a,b,iCount);
    '        ' by Keunuk.Lee 2012-06-28 화면 밖을 벗어난 Edge에 의한 Debug Fix
    '        Dim iMargin As Integer = 5
    '        If b < iMargin OrElse iHeight - 1 - iMargin < b Then
    '            Continue For
    '        End If

    '        vEquation(0).Add(a)
    '        vEquation(1).Add(b)
    '        'vEquation.push_back(equation);
    '        vCount.Add(iCount)
    '    Next
    '    'delete [] top;
    '    'delete [] pEdge;

    '    If vEquation(0) Is Nothing OrElse vEquation(1) Is Nothing Then
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function

    ' Hought Line Transform으로 얻어진 결과를 종합해서 유력한 후보군 몇개만을 봅아내는 함수
    ' 지정된 각도 범위, 간격 범위안에 들어오는 직선성분은 동일한 것으로 본다
    ' 출력되는 결과에는 ax + b의 b 크기가 작은 순서대로 출력한다.
    Public Function HoughLineTransformResultAnalysis(ByVal dAngleRange As Double, ByVal dGapRange As Double, ByVal iCountThld As Integer, ByRef vEquation As List(Of Double)(), ByRef vCount As List(Of Integer)) As Boolean
        Dim vEquationResult As List(Of Double)() = New List(Of Double)(1) {}
        vEquationResult(0) = New List(Of Double)()
        vEquationResult(1) = New List(Of Double)()
        Dim vCountResult As New List(Of Integer)()

        'vEquation = new List<double>[2];
        'vEquation[0] = new List<double>();
        'vEquation[1] = new List<double>();
        'vCount = new List<int>();

        If dAngleRange <= 0.0 OrElse dGapRange <= 0.0 OrElse iCountThld < 1 OrElse vEquation Is Nothing OrElse vCount Is Nothing OrElse vEquation(0).Count <> vCount.Count OrElse vEquation(1).Count <> vCount.Count Then
            vEquation(0).Clear()
            vEquation(1).Clear()
            vCount.Clear()

            Return False
        End If

        For i As Integer = 0 To vEquation(0).Count - 1
            Dim a As Double = vEquation(0)(i)
            Dim b As Double = vEquation(1)(i)
            Dim iCount As Integer = vCount(i)

            If 0 = i Then
                'std::pair<double,double> equation;
                'equation.first = a;
                'equation.second = b;
                vEquationResult(0).Add(a)
                '.push_back(equation);
                vEquationResult(1).Add(a)
                '.push_back(equation);
                vCountResult.Add(iCount)
            Else
                Dim bFound As Boolean = False
                Dim iIndex As Integer = 0
                For j As Integer = 0 To vEquationResult(0).Count - 1
                    ' 각도 차이, 위치 차이가 기준치 미만이면 같은 Line을 잡은 것으로 본다
                    If Math.Abs(vEquationResult(1)(j) - b) < dGapRange AndAlso Math.Abs(vEquationResult(0)(j) - a) < dAngleRange Then
                        vEquationResult(0)(j) = (vEquationResult(0)(j) * CDbl(vCountResult(j)) + a * CDbl(iCount)) / CDbl(vCountResult(j) + iCount)
                        vEquationResult(1)(j) = (vEquationResult(1)(j) * CDbl(vCountResult(j)) + b * CDbl(iCount)) / CDbl(vCountResult(j) + iCount)
                        vCountResult(j) += iCount
                        bFound = True
                        Exit For
                    Else
                        If vEquationResult(1)(j) < b Then
                            iIndex = j + 1
                        End If
                    End If
                Next
                If Not bFound Then
                    Dim equation As List(Of Double)() = New List(Of Double)(1) {}
                    equation(0) = New List(Of Double)()
                    equation(1) = New List(Of Double)()
                    equation(0).Add(a)
                    equation(1).Add(b)
                    ' = b;
                    'vEquationResult.push_back(equation);
                    'vCountResult.push_back(iCount);
                    'List<double>[] it = vEquationResult = new List<double>[2];
                    'vEquationResult[0] = new List<double>();
                    'vEquationResult[1] = new List<double>();

                    'List<int> it2 = vCountResult = new List<int>();

                    vEquationResult(0).Insert(iIndex, a)
                    vEquationResult(1).Insert(iIndex, b)

                    vCountResult.Insert(iIndex, iCount)
                End If
            End If
        Next

        ' Count Thresholding - 기준 카운트 미만의 직선성분은 배제한다
        vEquation(0).Clear()
        vEquation(1).Clear()
        vCount.Clear()
        For i As Integer = 0 To vCountResult.Count - 1
            If vCountResult(i) < iCountThld Then
                Continue For
            Else
                vEquation(0).Add(vEquationResult(0)(i))
                vEquation(1).Add(vEquationResult(1)(i))
                vCount.Add(vCountResult(i))
            End If
        Next

        If vEquation(0).Count = 0 OrElse vEquation(1).Count = 0 OrElse vCount.Count = 0 Then
            Return False
        End If

        Return True
    End Function

    '    Public Function SaveModel(ByVal ipModelFinder As Object, ByVal ipImageBuf As MIL_ID, ByVal ipImageBufSave As MIL_ID, ByVal ipMGraphic As Object, _
    '                                  ByVal ipFilePath As String, ByRef ipAlignData As AlignData) As String
    '        On Error GoTo syserr
    '        Dim tmpOffX As Integer
    '        Dim tmpOffY As Integer

    '        For i% = 0 To ipModelFinder.Models.Count - 1
    '            ipModelFinder.Models.Remove(i% + 1)
    '        Next i%

    '        tmpOffX = ipAlignData.nAlignMark_ModelOffsetX - ipAlignData.nAlignMark_SearchOffsetX
    '        tmpOffY = ipAlignData.nAlignMark_ModelOffsetY - ipAlignData.nAlignMark_SearchOffsetY

    '        ipModelFinder.Image = ipImageBuf
    '        ipModelFinder.ModelFinderType = MmodGetResult(result, 0, M_POSITION_X, dX) 'Matrox.ActiveMIL.ModelFinder.ModModelFinderTypeConstants.modGeometric
    '        ipModelFinder.Models.TotalNumberOfOccurrences = 1
    '        ipModelFinder.Models.SmoothnessLevel = 50.1
    '        ipModelFinder.Models.DetailLevel = Matrox.ActiveMIL.ModelFinder.ModMediumHighConstants.modMedium                              '결과 표현 분해능
    '        ipModelFinder.Models.Speed = Matrox.ActiveMIL.ModelFinder.ModMediumHighConstants.modMedium                                    '검색 속도
    '        ipModelFinder.Models.Accuracy = Matrox.ActiveMIL.ModelFinder.ModMediumHighConstants.modMedium                                 '검색 분해능
    '        ipModelFinder.Models.SearchAngleEnabled = True
    '        ipModelFinder.Models.SearchScaleEnabled = True
    '        ipModelFinder.Models.SharedEdges = False
    '        ipModelFinder.Models.Timeout = 2000

    '        ipModelFinder.Models.AddImageModel(ipImageBuf, tmpOffX, tmpOffY, ipAlignData.nAlignMark_ModelSizeX, ipAlignData.nAlignMark_ModelSizeY)

    '        ' 모델 이미지 bmp저장
    '        If ipImageBufSave.IsAllocated = True Then
    '            ipImageBufSave.Free()
    '        End If

    '        ipImageBufSave.SizeX = ipAlignData.nAlignMark_ModelSizeX
    '        ipImageBufSave.SizeY = ipAlignData.nAlignMark_ModelSizeY

    '        ipImageBufSave.Allocate()
    '        ipImageBufSave.CopyRegion(ipImageBuf, Matrox.ActiveMIL.ImBandConstants.imAllBands, tmpOffX, tmpOffY, _
    '                                  Matrox.ActiveMIL.ImBandConstants.imAllBands, 0, 0, ipAlignData.nAlignMark_ModelSizeX, ipAlignData.nAlignMark_ModelSizeY)

    '        Select Case ipAlignData.MarkNum
    '            Case AlignMarkNum.A1_L1_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_A1_L1_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_A1_L1_M1" & ".mmf"
    '            Case AlignMarkNum.A1_L1_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_A1_L1_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_A1_L1_M2" & ".mmf"

    '            Case AlignMarkNum.A1_L2_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_A1_L2_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_A1_L2_M1" & ".mmf"
    '            Case AlignMarkNum.A1_L2_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_A1_L2_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_A1_L2_M2" & ".mmf"

    '            Case AlignMarkNum.A1_L3_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_A1_L3_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_A1_L3_M1" & ".mmf"
    '            Case AlignMarkNum.A1_L3_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_A1_L3_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_A1_L3_M2" & ".mmf"

    '            Case AlignMarkNum.A2_L1_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_A2_L1_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_A2_L1_M1" & ".mmf"
    '            Case AlignMarkNum.A2_L1_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_A2_L1_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_A2_L1_M2" & ".mmf"

    '            Case AlignMarkNum.A2_L2_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_A2_L2_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_A2_L2_M1" & ".mmf"
    '            Case AlignMarkNum.A2_L2_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_A2_L2_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_A2_L2_M2" & ".mmf"

    '            Case AlignMarkNum.A2_L3_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_A2_L3_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_A2_L3_M1" & ".mmf"
    '            Case AlignMarkNum.A2_L3_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_A2_L3_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_A2_L3_M2" & ".mmf"

    '            Case AlignMarkNum.B1_L1_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_B1_L1_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_B1_L1_M1" & ".mmf"
    '            Case AlignMarkNum.B1_L1_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_B1_L1_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_B1_L1_M2" & ".mmf"

    '            Case AlignMarkNum.B1_L2_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_B1_L2_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_B1_L2_M1" & ".mmf"
    '            Case AlignMarkNum.B1_L2_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_B1_L2_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_B1_L2_M2" & ".mmf"

    '            Case AlignMarkNum.B1_L3_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_B1_L3_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_B1_L3_M1" & ".mmf"
    '            Case AlignMarkNum.B1_L3_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_B1_L3_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_B1_L3_M2" & ".mmf"

    '            Case AlignMarkNum.B2_L1_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_B2_L1_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_B2_L1_M1" & ".mmf"
    '            Case AlignMarkNum.B2_L1_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_B2_L1_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_B2_L1_M2" & ".mmf"

    '            Case AlignMarkNum.B2_L2_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_B2_L2_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_B2_L2_M1" & ".mmf"
    '            Case AlignMarkNum.B2_L2_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_B2_L2_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_B2_L2_M2" & ".mmf"

    '            Case AlignMarkNum.B2_L3_M1
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_B2_L3_M1" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_B2_L3_M1" & ".mmf"
    '            Case AlignMarkNum.B2_L3_M2
    '                ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_B2_L3_M2" & ".bmp"
    '                ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_B2_L3_M2" & ".mmf"

    '        End Select
    '        ipImageBufSave.Save(ipAlignData.strAlignMarkImageBMP_FileName)

    '        ipModelFinder.Models(1).NumberOfOccurrences = 1 ' Matrox.ActiveMIL.ModelFinder.ModAllConstants.modAll                  '찾을 대상체의 갯수를 여기서 설정 / Default = 1 주의!!!!
    '        ipModelFinder.Models(1).Acceptance = ipAlignData.nAlignMark_Acceptance
    '        ipModelFinder.Models(1).Certainty = ipAlignData.nAlignMark_Certainty

    '        '20160620 이근욱S 수정 - Align Mark 찾기 조건에 AcceptanceTarget = 60, CertaintyTarget = 90 추가
    '        ipModelFinder.Models(1).AcceptanceTarget = 60.0
    '        ipModelFinder.Models(1).CertaintyTarget = 90.0

    '        ipModelFinder.Models(1).Angle.Value = 0 ' set_GeoPara.cDOF_Angle                                    '검색 시작 각도
    '        ipModelFinder.Models(1).Angle.NegativeDelta = 10 'set_GeoPara.cDOF_AngleNegative                    '검색 범위 -
    '        ipModelFinder.Models(1).Angle.PositiveDelta = 10 ' set_GeoPara.cDOF_AnglePositive                    '검색 범위 +
    '        ipModelFinder.Models(1).Scale.Minimum = 1 - (50 / 100) 'set_GeoPara.cDOF_ScaleMinimum                           '검색 대상 인식 최소 Scale
    '        ipModelFinder.Models(1).Scale.Maximum = 1 + (50 / 100) 'set_GeoPara.cDOF_ScaleMaximum                           '검색 대상 인식 최대 Scale

    '        ipModelFinder.Models.Item(1) '
    '        ipModelFinder.Save(ipAlignData.strAlignMarkImageMMF_FileName)
    '        ipModelFinder.Preprocess()
    '        System.Threading.Thread.Sleep(100)
    '        ipModelFinder.Find()
    '        If ipModelFinder.Results.Count = 0 Then
    '            SaveModel = "Model Find Failed!"
    '        Else
    '            Dim ResultIndex As Integer
    '            For ResultIndex = 1 To ipModelFinder.Results.Count

    '                With ipModelFinder.Results.Item(ResultIndex)
    '                    pMF_Result.Score = Math.Round(.Score, 3)
    '                    pMF_Result.Scale = .Scale
    '                    pMF_Result.PositionX = ipAlignData.nAlignMark_SearchOffsetX + Math.Round(.PositionX)
    '                    pMF_Result.PositionY = ipAlignData.nAlignMark_SearchOffsetY + Math.Round(.PositionY)
    '                    pMF_Result.Angle = .Angle
    '                    ipAlignData.nAlignMark_OriginPosX = pMF_Result.PositionX
    '                    ipAlignData.nAlignMark_OriginPosY = pMF_Result.PositionY
    '                    pMF_Result.PositionDiffX = 0
    '                    pMF_Result.positionDiffY = 0
    '                    CrossDraw(ipMGraphic, pMF_Result.PositionX, pMF_Result.PositionY, 15, 15, Color.Yellow)
    '                End With
    '            Next ResultIndex
    '            SaveModel = ""
    '        End If


    '        Exit Function
    'syserr:
    '        SaveModel = Err.Description
    '    End Function


End Class
