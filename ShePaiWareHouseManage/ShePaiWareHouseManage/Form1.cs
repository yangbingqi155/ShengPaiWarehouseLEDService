using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Model;
using Utils;

namespace ShePaiWareHouseManage
{
    public partial class Form1 : Form
    {
        private SerialPortEntity port = null;
        public Form1()
        {
            InitializeComponent();
            DataBindPorts();
        }

        public void DataBindPorts() {
            cmbPorts.DataSource= SerialPortHelper.GetSerialPorts();
            //cmbPorts.Items("请选择串口设备");
            cmbPorts.SelectedIndex = 0;
        }
        

        /// <summary>
        /// 在读取到数据时刷新文本框的信息
        /// </summary>
        private void RefreshInfoTextBox()
        {
            string value = port.ReadData();
            Action<string> setValueAction = text => this.txtMessages.Text += text;

            if (this.txtMessages.InvokeRequired)
            {
                this.txtMessages.Invoke(setValueAction, value);
            }
            else
            {
                setValueAction(value);
            }
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RefreshInfoTextBox();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            port.SendData("Hello,PC.");
        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            txtMessages.Text = string.Empty;
        }

        private void cmbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbPorts.SelectedValue.ToString())) {
                port = new SerialPortEntity();
                port.Init(cmbPorts.SelectedValue.ToString());
                port.Port.DataReceived += SerialDataReceived;
            }
            
            
        }

        private void btnTurnOffLED_Click(object sender, EventArgs e)
        {
            port.SendData("turn_off");
        }

        private void btnTurnOnLED_Click(object sender, EventArgs e)
        {
            port.SendData("turn_on");
        }

        private void btnShowSN_Click(object sender, EventArgs e)
        {
            port.SendData("SN");
        }

        private void btnDisplayNumber_Click(object sender, EventArgs e)
        {
            port.SendData("test_number|6666");
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            port.SendData("receive_order|0002-0004/100");
        }
    }
}
