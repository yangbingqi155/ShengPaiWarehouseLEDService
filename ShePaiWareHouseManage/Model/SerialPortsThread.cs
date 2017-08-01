using Message;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Model
{
    public static class SerialPortsThread
    {
        private static List<SerialPortEntity> ports = new List<SerialPortEntity>();

        /// <summary>
        /// 初始化所有串口
        /// </summary>
        public static void InitALLPorts()
        {
            Init(SerialDataReceived);
        }

        /// <summary>
        /// 初始化所有串口
        /// </summary>
        /// <param name="SerialDataReceived"></param>
        public static void InitALLPorts(SerialDataReceivedEventHandler SerialDataReceived)
        {
            Init(SerialDataReceived);
        }

        private static void Init(SerialDataReceivedEventHandler SerialDataReceived) {
            foreach (var portName in SerialPortHelper.GetSerialPorts())
            {
                AddPort(portName);
                SerialPortEntity port = Get(portName);
                port.BindDataReceived(SerialDataReceived);
                port.SendData(MessageConst.SN);
            }
        }


        private static void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPortEntity port = SerialPortsThread.Get(((SerialPort)sender).PortName);
            string message = port.ReadData();
            //根据消息做相应的处理
            if (message.IndexOf(MessageConst.SN) >= 0)
            {
                port.SN = message.Split('|')[1];
            }
        }

        /// <summary>
        /// 添加新Serial Port
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public static bool AddPort(string portName)
        {
            bool result = false;
            try
            {
                if (!Exists(portName))
                {
                    SerialPortEntity entity = new SerialPortEntity();
                    entity.Init(portName);
                    ports.Add(entity);
                    result = true;
                }
                //else
                //{
                //    throw new Exception(string.Format("串口设备({0})已经存在。",portName));
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("添加新串口设备失败");
            }


            return result;
        }

        /// <summary>
        /// 判断某个串口设备是否存在
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public static bool Exists(string portName)
        {
            return Get(portName) != null ? true : false;
        }

        /// <summary>
        /// 获取某个串口设备
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public static SerialPortEntity Get(string portName)
        {
            return ports.Find(en => en.PortName.ToLower() == portName.ToLower());
        }

        /// <summary>
        /// 移除某个串口设备
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public static bool Remove(string portName)
        {
            bool result = false;
            if (Exists(portName))
            {
                ports.Remove(Get(portName));
                result = true;
            }
            else
            {
                throw new Exception(string.Format("串口设备({0})不存在。", portName));
            }
            return result;
        }
    }
}
