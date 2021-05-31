using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tlbbDLQ
{
    public partial class Form1 : Form
    {
        private Task taskLogin = null;
        private Task taskGaming = null;
        private TcpListener ls_login = null;
        private TcpListener ls_game = null;
        private CancellationTokenSource CancelTokenSource = null;
        private List<ConnectModel> list_connect;
        private List<Process> list_pro;

        private IPEndPoint localLogin;
        private IPEndPoint ip_game;
        private IPEndPoint ip_login;

        public Form1()
        {
            InitializeComponent();

            list_connect = new List<ConnectModel>();
            list_pro = new List<Process>();
        }

        private void accept(ref IPEndPoint remote, TcpListener server)
        {
            try
            {
                //server.Start();
                while (true)
                {
                    if (CancelTokenSource.IsCancellationRequested)
                        break;
                    if (server.Pending())
                    {
                        TcpClient acc = server.AcceptTcpClient();
                        ConnectModel cm = new ConnectModel(acc.Client.RemoteEndPoint.ToString());
                        Tools.Log($"接入: {acc.Client.RemoteEndPoint}");
                        cm.doRun(acc, remote);
                        list_connect.Add(cm);
                    }
                    Thread.Sleep(800);
                }
                server.Stop();
            }
            catch (Exception ex)
            {
                Tools.Log("[At task accept]: Error! " + ex.Message);
            }
        }

        private bool WriteToText()
        {
            try
            {
                String sname = string.IsNullOrWhiteSpace(text_Daqu.Text) ? "本地天龙" : text_Daqu.Text;
                String ssname = string.IsNullOrWhiteSpace(textQu.Text) ? "单机一区" : textQu.Text;
                String fname = string.IsNullOrWhiteSpace(textGame.Text) ? "天龙八部" : textGame.Text;
                using (StreamWriter sw = new StreamWriter(@"./Patch/LoginServer.txt", false, Encoding.GetEncoding("gb2312")))
                {
                    sw.WriteLine("VERSION 1\n\nSERVER_BEGIN\n");
                    sw.WriteLine($"{sname},{ssname},1,201,3,1,0,{fname}," +
                        $"{localLogin.Address}:{localLogin.Port},{localLogin.Address}:{localLogin.Port}," +
                        $"{localLogin.Address}:{localLogin.Port},{localLogin.Address}:{localLogin.Port}\n\nSERVER_END\n");
                }
                return true;
            }
            catch (Exception ex)
            {
                Tools.Log("[At WriteToText]: Error! " + ex.Message);
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(!File.Exists(@"./Bin/Game.exe") && !File.Exists(@"./Bin/game.exe"))
           {
               MessageBox.Show("请把启动器放在游戏根目录！");
               return;
           }
           int num_login_port = Convert.ToInt32(numeric_login.Value);
           int num_game_port = Convert.ToInt32(numeric_game.Value);
           ip_game = new IPEndPoint(IPAddress.Parse(textServerIP.Text), num_game_port);
           ip_login = new IPEndPoint(IPAddress.Parse(textServerIP.Text), num_login_port);
           
            if (taskGaming == null && taskLogin == null)
           {
               CancelTokenSource = new CancellationTokenSource();
               try
               {

                   ls_login = new TcpListener(IPAddress.Parse("127.0.0.1"), 0);
                   ls_login.Start();
                   localLogin = (IPEndPoint)ls_login.LocalEndpoint;
                   label7.Text = "TLogin: " + localLogin.Port.ToString();

                   Tools.Log($"登录：{ls_login.LocalEndpoint}");

                   ls_game = new TcpListener(IPAddress.Parse("127.0.0.1"), 0);
                   ls_game.Start();
                   ConnectModel.gPort = num_game_port;
                   ConnectModel.lgPort = ((IPEndPoint)ls_game.LocalEndpoint).Port;
                   label8.Text = "TGame: " + ConnectModel.lgPort.ToString();

                   Tools.Log($"游戏: {ls_game.LocalEndpoint}");

                   taskGaming = new Task(() => accept(ref ip_game, ls_game), CancelTokenSource.Token);
                   taskLogin = new Task(() => accept(ref ip_login, ls_login), CancelTokenSource.Token);

                   taskLogin.Start();
                   taskGaming.Start();

                   WriteToText();
               }
               catch (Exception ex)
               {
                   Tools.Log("[At Button start]: Error! " + ex.Message);
                   throw;
               }
           }
           Process pro = new Process();
           pro.StartInfo.FileName = Application.StartupPath + @"/Bin/Game.exe";
           pro.StartInfo.Arguments = "-fl C0A80108 3039 12D82B";
           pro.Start();
           list_pro.Add(pro);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (list_pro.Count > 0)
            {
                foreach (var cm in list_connect)
                {
                    try
                    {
                        cm.closeTasks();
                    }
                    catch (Exception)
                    {

                    }
                }

                foreach (var pro in list_pro)
                {
                    try
                    {
                        pro.Kill();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            try
            {
                if (taskGaming != null)
                {
                    CancelTokenSource.Cancel();
                    taskGaming = null;
                    taskLogin = null;
                    ls_login.Stop();
                    ls_game.Stop();
                }
            }
            catch (Exception)
            {

            }
        }

        private void check_Debug_CheckedChanged(object sender, EventArgs e)
        {
            Tools.T_DEBUG = check_Debug.Checked;
        }
    }
}
