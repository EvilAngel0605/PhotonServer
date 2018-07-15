using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using ExitGames.Logging;
using System.IO;
using ExitGames.Logging.Log4Net;
using log4net.Config;

namespace MyGameServer
{
    /// <summary>
    ///所有的Server端主类都要继承自ApplicationBase
    /// </summary>
    class MyGameServer : ApplicationBase
    {
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 当一个客户端请求连接
        /// 使用PeerBase表示和一个客户端连接
        /// </summary>
        /// <param name="initRequest"></param>
        /// <returns></returns>
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new ClientPeer(initRequest);
            log.Info("新的客户端连接！");
        }
        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Setup()
        {
            //日志的初始化
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "bin_Win64","log");
            FileInfo fileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            if(fileInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);//让photo你知道使用的哪个插件
                XmlConfigurator.ConfigureAndWatch(fileInfo);//让log4net插件读取配置文件
            }
            log.Info("Set Up!");
        }
        /// <summary>
        /// Server端关闭的时候
        /// </summary>
        protected override void TearDown()
        {
            log.Info("服务器关闭应用！");
        }
    }
}
