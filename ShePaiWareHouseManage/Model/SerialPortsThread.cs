using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class SerialPortsThread
    {
        private static List<SerialPortEntity> ports=new List<SerialPortEntity>();

        /// <summary>
        /// 添加新Serial Port
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public static bool AddPort(string portName) {
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
                else
                {
                    throw new Exception(string.Format("串口设备({0})已经存在。",portName));
                }
            }
            catch (Exception ex) {
                throw new Exception("添加新串口设备失败");
            }


            return result;
        }

        /// <summary>
        /// 判断某个串口设备是否存在
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public static bool Exists(string portName) {
            return Get(portName) != null ? true : false;
        }

        /// <summary>
        /// 获取某个串口设备
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public static SerialPortEntity Get(string portName) {
            return ports.Find(en => en.PortName.ToLower() == portName.ToLower());
        }

        /// <summary>
        /// 移除某个串口设备
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public static bool Remove(string portName) {
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
