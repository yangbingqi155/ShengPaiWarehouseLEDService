using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message
{
    /// <summary>
    /// 消息常量定义
    /// </summary>
    public class MessageConst {
        /// <summary>
        /// 开启LED
        /// </summary>
        public const string TURN_ON = "turn_on";
        
        /// <summary>
        /// 关闭LED
        /// </summary>
        public const string TURN_OFF = "turn_off";

        /// <summary>
        /// 获取设备序列号
        /// </summary>
        public const string SN = "sn";

        /// <summary>
        /// 显示数字
        /// 命令格式为:test_number|数字
        /// </summary>
        public const string SHOW_NUMBER = "show_number";

        /// <summary>
        /// 发送订单信息到设备
        /// 命令格式为:send_order|订单号-产品编号/订购数量
        /// </summary>
        public const string SEND_ORDER_PRODUCT = "send_order";


    }
}
