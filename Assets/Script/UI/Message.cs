using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.UI
{
    public class Message
    {
        /// <summary>
        /// 回调消息父类
        /// </summary>
        public class CallBackDataBase
        {
            public MessageType messageType { get; set; }
            public string message { get; set; }



            public override string ToString()
            {
                return $"{{{nameof(messageType)}={messageType.ToString()}, {nameof(message)}={message}}}";
            }
        }


        public class EatFoot : CallBackDataBase
        {
            public string footName { get; set; }
            public string footNumber { get; set; }

            public override string ToString()
            {
                return $"{{{nameof(footName)}={footName}, {nameof(footNumber)}={footNumber}, {nameof(messageType)}={messageType.ToString()}, {nameof(message)}={message}}}";
            }
        }

        public class Universal : CallBackDataBase
        {
            public string result;

            public override string ToString()
            {
                return $"{{{nameof(messageType)}={messageType.ToString()}, {nameof(message)}={message}}}";
            }
        }
    }
}
