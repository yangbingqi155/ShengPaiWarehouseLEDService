using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Utils
{
    /// <summary>
    /// 串口帮助类
    /// </summary>
    public static class SerialPortHelper
    {
        /// <summary>
        /// 获取所有串口
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSerialPorts() {
            List<string> ports = new List<string>(); 
            string[] serialPorts= SerialPort.GetPortNames();
            if (serialPorts!=null&& serialPorts.Count()>0) {
                ports = serialPorts.ToList();
            }
            return ports;
        }
    }
}
