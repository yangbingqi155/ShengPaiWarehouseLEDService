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
using Message;

namespace ShePaiWareHouseManage
{
    public partial class Form1 : Form
    {
        private SerialPortEntity port = null;
        public Form1()
        {
            InitializeComponent();
            //绑定串口下拉框
            DataBindPorts();
            //初始化所有串口
            SerialPortsThread.InitALLPorts(SerialDataReceived);
        }

        public void DataBindPorts() {
            cmbPorts.DataSource= SerialPortHelper.GetSerialPorts();
            //cmbPorts.Items.Insert(0, "请选择串口设备");
            //cmbPorts.SelectedIndex = 0;
        }
        

        /// <summary>
        /// 在读取到数据时刷新文本框的信息
        /// </summary>
        private void RefreshInfoTextBox(string portName)
        {
            SerialPortEntity port = SerialPortsThread.Get(portName);
            string display = string.Empty;
            string message = port.ReadData();
            //根据消息做相应的处理
            //如果是抓货完成，关闭LED，接收到订单的相关信息
            if (message.IndexOf(MessageConst.SEND_ORDER_PRODUCT) >= 0) {
                //消息格式为:send_order|订单号-产品编号/订购数量

                //处理订单逻辑

                display = port.PortName + ":订单信息-" + message.Split('|')[1];
            }//如果消息是设备序列号，格式为:sn|设备序列号
            else if (message.IndexOf(MessageConst.SN) >= 0) {
                port.SN = message.Split('|')[1];
                display = port.PortName + ":设备序列号-" + message.Split('|')[1];
            }

            Action<string> setValueAction = text => this.txtMessages.Text += text;

            if (this.txtMessages.InvokeRequired)
            {
                this.txtMessages.Invoke(setValueAction, display);
            }
            else
            {
                setValueAction(display);
            }
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port =(SerialPort) sender;
            RefreshInfoTextBox(port.PortName);
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
            string portName = cmbPorts.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(portName) && portName != "请选择串口设备") {
                port = SerialPortsThread.Get(portName);
            }
        }

        private void btnTurnOffLED_Click(object sender, EventArgs e)
        {
            port.SendData(MessageConst.TURN_OFF);
        }

        private void btnTurnOnLED_Click(object sender, EventArgs e)
        {
            port.SendData(MessageConst.TURN_ON);
        }

        private void btnShowSN_Click(object sender, EventArgs e)
        {
            port.SendData(MessageConst.SN);
        }

        private void btnDisplayNumber_Click(object sender, EventArgs e)
        {
            port.SendData(MessageConst.SHOW_NUMBER+"|6666");
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            port.SendData(MessageConst.SEND_ORDER_PRODUCT+"|0002-0004/100");
        }
    }
}
