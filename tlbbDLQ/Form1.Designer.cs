
namespace tlbbDLQ
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textServerIP = new System.Windows.Forms.TextBox();
            this.numeric_login = new System.Windows.Forms.NumericUpDown();
            this.numeric_game = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_Daqu = new System.Windows.Forms.TextBox();
            this.textQu = new System.Windows.Forms.TextBox();
            this.textGame = new System.Windows.Forms.TextBox();
            this.check_Debug = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_game)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "登陆端口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "游戏端口";
            // 
            // textServerIP
            // 
            this.textServerIP.Location = new System.Drawing.Point(125, 28);
            this.textServerIP.Name = "textServerIP";
            this.textServerIP.Size = new System.Drawing.Size(193, 25);
            this.textServerIP.TabIndex = 3;
            this.textServerIP.Text = "192.168.1.99";
            // 
            // numeric_login
            // 
            this.numeric_login.Location = new System.Drawing.Point(125, 69);
            this.numeric_login.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numeric_login.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_login.Name = "numeric_login";
            this.numeric_login.Size = new System.Drawing.Size(193, 25);
            this.numeric_login.TabIndex = 4;
            this.numeric_login.Value = new decimal(new int[] {
            7775,
            0,
            0,
            0});
            // 
            // numeric_game
            // 
            this.numeric_game.Location = new System.Drawing.Point(125, 106);
            this.numeric_game.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numeric_game.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_game.Name = "numeric_game";
            this.numeric_game.Size = new System.Drawing.Size(193, 25);
            this.numeric_game.TabIndex = 5;
            this.numeric_game.Value = new decimal(new int[] {
            7776,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "大区名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "区  名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "游戏名";
            // 
            // text_Daqu
            // 
            this.text_Daqu.Location = new System.Drawing.Point(460, 28);
            this.text_Daqu.Name = "text_Daqu";
            this.text_Daqu.Size = new System.Drawing.Size(193, 25);
            this.text_Daqu.TabIndex = 9;
            this.text_Daqu.Text = "本地天龙";
            // 
            // textQu
            // 
            this.textQu.Location = new System.Drawing.Point(460, 68);
            this.textQu.Name = "textQu";
            this.textQu.Size = new System.Drawing.Size(193, 25);
            this.textQu.TabIndex = 10;
            this.textQu.Text = "单机一区";
            // 
            // textGame
            // 
            this.textGame.Location = new System.Drawing.Point(460, 105);
            this.textGame.Name = "textGame";
            this.textGame.Size = new System.Drawing.Size(193, 25);
            this.textGame.TabIndex = 11;
            this.textGame.Text = "天龙八部";
            // 
            // check_Debug
            // 
            this.check_Debug.AutoSize = true;
            this.check_Debug.Location = new System.Drawing.Point(49, 157);
            this.check_Debug.Name = "check_Debug";
            this.check_Debug.Size = new System.Drawing.Size(59, 19);
            this.check_Debug.TabIndex = 12;
            this.check_Debug.Text = "调试";
            this.check_Debug.UseVisualStyleBackColor = true;
            this.check_Debug.CheckedChanged += new System.EventHandler(this.check_Debug_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 46);
            this.button1.TabIndex = 13;
            this.button1.Text = "启  动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(441, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "label8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 223);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.check_Debug);
            this.Controls.Add(this.textGame);
            this.Controls.Add(this.textQu);
            this.Controls.Add(this.text_Daqu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numeric_game);
            this.Controls.Add(this.numeric_login);
            this.Controls.Add(this.textServerIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "简易登陆器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_game)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textServerIP;
        private System.Windows.Forms.NumericUpDown numeric_login;
        private System.Windows.Forms.NumericUpDown numeric_game;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_Daqu;
        private System.Windows.Forms.TextBox textQu;
        private System.Windows.Forms.TextBox textGame;
        private System.Windows.Forms.CheckBox check_Debug;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

