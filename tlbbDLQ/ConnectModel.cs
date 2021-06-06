using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace tlbbDLQ
{
    class ConnectModel
    {
        /// <summary>
        /// 标识
        /// </summary>
        public String Name { set; get; }
        public static int gPort { set; get; }
        public static int lgPort { set; get; }
        private bool enter = false;

        /// <summary>
        /// 存储两个转发线程
        /// </summary>
        private Task taskTo = null;
        private Task taskFrom = null;
        private CancellationTokenSource CancelTokenSource = null;


        public ConnectModel(String name)
        {
            Name = name;           
            CancelTokenSource = new CancellationTokenSource();
        }

        public void closeTasks()
        {
            try
            {
                CancelTokenSource.Cancel();
                if (CancelTokenSource != null)
                    CancelTokenSource = null;
                taskTo = null;
                taskFrom = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void transport(TcpClient src, TcpClient dst, String direct)
        {
            try
            {
                Tools.Log($"{direct} Transport start...");
                NetworkStream s_src = src.GetStream();
                NetworkStream s_dst = dst.GetStream();
                String sname = ((IPEndPoint)src.Client.LocalEndPoint).Address.ToString();
                String dname = ((IPEndPoint)dst.Client.LocalEndPoint).Address.ToString();
                int l_gPort = gPort & 0xFF;
                int h_gPort = (gPort >> 8) & 0xFF;

                Byte[] buffer = new Byte[2048];
                /*Tools.Log("waitting for the first message...");
                s_src.Read(buffer, 0, buffer.Length);
                Tools.Log("The first message Read.");*/
                int rLen = 0;
                while (src.Connected && dst.Connected)
                {
                    if (CancelTokenSource.IsCancellationRequested)
                        break;                   
                    if ((rLen = s_src.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if(!enter)
                        {
                            if (buffer[0] == 0x5A && buffer[10] == l_gPort && buffer[11] == h_gPort)
                            {
                                Tools.Log("Enter Game\nChange data...");
                                buffer[10] = (Byte)(lgPort & 0xFF);
                                buffer[11] = (Byte)((lgPort >> 8) & 0xFF);

                                enter = true;
                            }                           
                        }
                        Tools.Log($"[{direct}] <{rLen}> {BitConverter.ToString(buffer, 0, rLen)}");
                        s_dst.Write(buffer, 0, rLen);
                        s_dst.Flush();
                    }
                }                     
            }
            catch (SocketException)
            {
                throw;
            }
            finally
            {
                Tools.Log("A connection quit.");
                try
                {
                    if (src.Connected)
                        src.Close();
                    if (dst.Connected)
                        dst.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool doRun(TcpClient accept, IPEndPoint remote)
        {
            try
            {
                TcpClient trans = new TcpClient();
                Tools.Log("Connecting " + remote.ToString() + " ...");
                trans.Connect(remote);
                Tools.Log("Connected.");
                if (taskTo == null && taskFrom == null)
                {

                    taskTo = new Task(() => transport(accept, trans, "C to S"), CancelTokenSource.Token);
                    taskFrom = new Task(() => transport(trans, accept, "S to C"), CancelTokenSource.Token);
                    taskTo.Start();
                    taskFrom.Start();
                }
                return true;
            }
            catch (Exception ex)
            {
                Tools.Log("[At ConnectModel.doRun] Connect " + remote.ToString() + " Error!\n" + ex.Message);
                return false;
                throw;
            }
        }

        public bool getStatus()
        {
            try
            {
                return taskTo.IsCanceled;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

    }
}
