using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using IPA.Cores.Basic;
using IPA.Cores.Helper.Basic;
using static IPA.Cores.Globals.Basic;

namespace IPA_DN_Cores_Test_DaemonCenterClient
{
    public class Program
    {
        public static int Main(string[] args)
        {
            const string appName = "DCCTest";

            return StandardMainFunctions.DaemonMain.DoMain(
                new CoresLibOptions(CoresMode.Daemon,
                    appName: appName,
                    defaultDebugMode: DebugMode.Debug,
                    defaultPrintStatToConsole: false,
                    defaultRecordLeakFullStack: false),
                args: args,
                getDaemonProc: () => new HttpServerDaemon<Startup>(appName, appName, new HttpServerOptions
                {
                    HttpPortsList = 80._SingleList(),
                    HttpsPortsList = 443._SingleList(),
                    UseKestrelWithIPACoreStack = true,
                    DebugKestrelToConsole = false,
                    UseSimpleBasicAuthentication = false,
                    HoldSimpleBasicAuthenticationDatabase = false,
                    AutomaticRedirectToHttpsIfPossible = true,
                }));
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
    }
}
