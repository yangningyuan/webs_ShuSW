using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace Common
{
    public class SocketClient
    {
        public SocketClient()
        {

        }

        public Socket Connection(string ip, int port)
        {
            try
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //连接到指定服务器的指定端口
                //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.connect.aspx

                // socket.Connect("192.168.1.195", 2000);//
                socket.Connect(ip, port);//
                return socket;
            }
            catch
            {
                return null;
            }


        }

        public void Send(Socket socket, byte[] sendBuffer)
        {
            socket.Send(sendBuffer);
        }
        public void Send(Socket socket, List<byte[]> sendBufferList)
        {
            List<byte> sendBuffer = new List<byte>();
            for (int i = 0; i < sendBufferList.Count; i++)
            {
                sendBuffer.AddRange(sendBufferList[0]);
            }
            socket.Send(sendBuffer.ToArray());
        }

        public byte[] Receive(Socket socket)
        {
            byte[] receiveBuffer = new byte[1200];
            int leng = socket.Receive(receiveBuffer);
            byte[] result = new byte[leng];
            Array.Copy(receiveBuffer, 0, result, 0, leng);
            return result;
        }

        #region 异步接收
        //byte[] receiveBuffer = new byte[20];

        public void BegionReceive(Socket socket, byte[] receiveBuffer, AsyncCallback ReceiveProcess)
        {
            socket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveProcess), socket);
        }

        public void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                var socket = ar.AsyncState as Socket;

                //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.endreceive.aspx
                var length = socket.EndReceive(ar);
                byte[] receiveBuffer = new byte[length];
                Array.Copy(receiveBuffer, 0, receiveBuffer, 0, length);

                //接收下一个消息(因为这是一个递归的调用，所以这样就可以一直接收消息了）
                //socket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
            }
            catch
            {
            }
        }
        #endregion

        /// <summary>
        /// 如果是modbus协议的话，应该是第一位是低位，第二位是高位
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte[] CRC16_C(byte[] data)
        {
            byte CRC16Lo;
            byte CRC16Hi;   //CRC寄存器 
            byte CL; byte CH;       //多项式码&HA001 
            byte SaveHi; byte SaveLo;
            byte[] tmpData;
            int I;
            int Flag;
            CRC16Lo = 0xFF;
            CRC16Hi = 0xFF;
            CL = 0x01;
            CH = 0xA0;
            tmpData = data;
            for (int i = 0; i < tmpData.Length; i++)
            {
                CRC16Lo = (byte)(CRC16Lo ^ tmpData[i]); //每一个数据与CRC寄存器进行异或 
                for (Flag = 0; Flag <= 7; Flag++)
                {
                    SaveHi = CRC16Hi;
                    SaveLo = CRC16Lo;
                    CRC16Hi = (byte)(CRC16Hi >> 1);      //高位右移一位 
                    CRC16Lo = (byte)(CRC16Lo >> 1);      //低位右移一位 
                    if ((SaveHi & 0x01) == 0x01) //如果高位字节最后一位为1 
                    {
                        CRC16Lo = (byte)(CRC16Lo | 0x80);   //则低位字节右移后前面补1 
                    }             //否则自动补0 
                    if ((SaveLo & 0x01) == 0x01) //如果LSB为1，则与多项式码进行异或 
                    {
                        CRC16Hi = (byte)(CRC16Hi ^ CH);
                        CRC16Lo = (byte)(CRC16Lo ^ CL);
                    }
                }
            }
            byte[] ReturnData = new byte[2];
            ReturnData[0] = CRC16Hi;       //CRC高位
            ReturnData[1] = CRC16Lo;       //CRC低位  
            return ReturnData;
        }
    }
}
