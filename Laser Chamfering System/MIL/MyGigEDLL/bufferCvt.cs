using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using PvDotNet;

namespace MyGigEDLL
{
    public class bufferCvt
    {
        public bufferCvt(PvBuffer aBuffer)
        {
            mBuffer = aBuffer;
        }
        public bufferCvt()
        {
            
        }
        public void SetPvBuffer(PvBuffer aBuffer)
        {
            mBuffer = aBuffer;
        }

        public int GetBufferData(uint xPos, uint yPos)
        {
            if (mBuffer == null)
            {
                return -1;
            }
            else
            {
                uint iWidth = mBuffer.Image.Width;
                uint iHeight = mBuffer.Image.Height;
                if (xPos >= iWidth || yPos >= iHeight) return -1;
                int iValue = 0;
                unsafe
                {
                    if (mBuffer.Image.BitsPerPixel == 8)
                    {
                        byte* pBuffer = mBuffer.Image.DataPointer;
                        pBuffer += iWidth * yPos + xPos;
                        iValue = *pBuffer;
                    }
                    else
                    if (mBuffer.Image.BitsPerPixel == 16)
                    {
                        short* pBuffer = (short*)mBuffer.Image.DataPointer;
                        pBuffer += iWidth * yPos + xPos;
                        iValue = *pBuffer;
                    }
                    else{
                        iValue = -2;
                    }
                }

                return iValue;
            }
        }

        public void GetBuffer(byte[] userBuffer, int xRange, int yRange)
        {
            uint iWidth = mBuffer.Image.Width;
            uint iHeight = mBuffer.Image.Height;
            if (xRange >= iWidth || yRange >= iHeight) return;
            unsafe
            {
                if (mBuffer.Image.BitsPerPixel == 8)
                {
                    IntPtr pBuffer = (IntPtr)mBuffer.Image.DataPointer;
                    Marshal.Copy(pBuffer, userBuffer, 0, (xRange * yRange));
                }
                else if (mBuffer.Image.BitsPerPixel == 16)
                {
                }
            }
        }

        public ulong GetDataPointer()
        {
            ulong ulDataPointer = 0;
            if (mBuffer != null)
            {
                unsafe
                {
                    ulDataPointer = (ulong)mBuffer.Image.DataPointer;
                }
            }
            return ulDataPointer;
        }

        private PvBuffer mBuffer = null;

    }
}
