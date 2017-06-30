using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Model
{
    public class SerialPortEntity
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string SN { get; set; }

        private SerialPort Port { get; set; }

        
        public void SerialDataReceived(object sender, SerialDataReceivedEventArgs e);

        public void DataReceived(SerialDataReceived serialDataReceived) {
            this.Port.DataReceived += serialDataReceived(,);
        }

        public string PortName {
            get {
                return this.Port.PortName;
            }
        }

        /// <summary>
        /// 初始化串口实例
        /// </summary>
        public void Init(string portName)
        {
            try
            {
                Port = new SerialPort(portName, 9600);
                Port.Encoding = Encoding.ASCII;
                Port.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("初始化串口发生错误：" + ex.Message);
            }
        }

        /// <summary>
        /// 关闭并销毁串口实例
        /// </summary>
        public void Dispose()
        {
            if (Port != null)
            {
                try
                {
                    if (Port.IsOpen)
                    {
                        Port.Close();
                    }
                    Port.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception("关闭串口发生错误：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 从串口读取数据并转换为字符串形式
        /// </summary>
        /// <returns></returns>
        public string ReadData()
        {
            string value = "";
            try
            {
                if (Port != null && Port.BytesToRead > 0)
                {
                    value = Port.ReadExisting();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("读取串口数据发生错误：" + ex.Message);
            }

            return value;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        public void SendData(string message) {
            try
            {
                if (Port != null)
                {
                    Port.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("发送串口数据发生错误：" + ex.Message);
            }
        }
    }
}
