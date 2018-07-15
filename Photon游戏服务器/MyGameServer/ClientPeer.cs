using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace MyGameServer
{
    class ClientPeer : Photon.SocketServer.ClientPeer
    {
        /// <summary>
        /// 构造函数,初始化对象
        /// </summary>
        /// <param name="initRequest"></param>
        public ClientPeer(InitRequest initRequest) : base(initRequest)
        {

        }
        /// <summary>
        /// 处理客户端的断开连接
        /// </summary>
        /// <param name="reasonCode"></param>
        /// <param name="reasonDetail"></param>
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 处理客户端的请求(连接服务器之后)
        /// </summary>
        /// <param name="operationRequest"></param>
        /// <param name="sendParameters"></param>
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            throw new NotImplementedException();
        }
    }
}
