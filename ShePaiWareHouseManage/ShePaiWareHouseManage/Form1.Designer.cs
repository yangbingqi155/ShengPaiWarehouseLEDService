namespace ShePaiWareHouseManage
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
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnEmpty = new System.Windows.Forms.Button();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnTurnOffLED = new System.Windows.Forms.Button();
            this.btnTurnOnLED = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPorts
            // 
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(97, 13);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 20);
            this.cmbPorts.TabIndex = 0;
            this.cmbPorts.SelectedIndexChanged += new System.EventHandler(this.cmbPorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口列表:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(246, 13);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(128, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "给Arduino发送消息";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(380, 14);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(75, 23);
            this.btnEmpty.TabIndex = 2;
            this.btnEmpty.Text = "清空消息";
            this.btnEmpty.UseVisualStyleBackColor = true;
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(3, 64);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(799, 463);
            this.txtMessages.TabIndex = 3;
            // 
            // btnTurnOffLED
            // 
            this.btnTurnOffLED.Location = new System.Drawing.Point(471, 14);
            this.btnTurnOffLED.Name = "btnTurnOffLED";
            this.btnTurnOffLED.Size = new System.Drawing.Size(75, 23);
            this.btnTurnOffLED.TabIndex = 4;
            this.btnTurnOffLED.Text = "熄灯";
            this.btnTurnOffLED.UseVisualStyleBackColor = true;
            this.btnTurnOffLED.Click += new System.EventHandler(this.btnTurnOffLED_Click);
            // 
            // btnTurnOnLED
            // 
            this.btnTurnOnLED.Location = new System.Drawing.Point(553, 13);
            this.btnTurnOnLED.Name = "btnTurnOnLED";
            this.btnTurnOnLED.Size = new System.Drawing.Size(75, 23);
            this.btnTurnOnLED.TabIndex = 5;
            this.btnTurnOnLED.Text = "开灯";
            this.btnTurnOnLED.UseVisualStyleBackColor = true;
            this.btnTurnOnLED.Click += new System.EventHandler(this.btnTurnOnLED_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 539);
            this.Controls.Add(this.btnTurnOnLED);
            this.Controls.Add(this.btnTurnOffLED);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.btnEmpty);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPorts);
            this.Name = "Form1";
            this.Text = "盛派五金仓库系统";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnEmpty;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button btnTurnOffLED;
        private System.Windows.Forms.Button btnTurnOnLED;
    }
}

