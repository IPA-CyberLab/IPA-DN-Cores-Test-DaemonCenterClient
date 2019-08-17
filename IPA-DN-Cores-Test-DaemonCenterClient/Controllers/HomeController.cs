using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IPA_DN_Cores_Test_DaemonCenterClient.Models;
using System.IO;

using IPA.Cores.Basic;
using IPA.Cores.Helper.Basic;
using static IPA.Cores.Globals.Basic;

using IPA.Cores.Codes;
using IPA.Cores.Helper.Codes;
using static IPA.Cores.Globals.Codes;

namespace IPA_DN_Cores_Test_DaemonCenterClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            KeyValueList<string, string> o = new KeyValueList<string, string>();

            string msg = "Hello 15!";

            o.Add("メッセージ", msg);

            o.Add("メッセージ 2", Dbg.HelloMsgTest);

            o.Add("起動時刻", Env.BootTime.ToLocalTime()._ToDtStr());

            o.Add("Git Commit Id", Dbg.GetCurrentGitCommitId());

            o.Add("Startup Arguments", GlobalDaemonStateManager.StartupArguments);

            o.Add("Process Id", Env.ProcessId.ToString());

            o.Add("BuildConfigurationName", Env.BuildConfigurationName);

            o.Add("ExeOrDllName", Env.AppExecutableExeOrDllFileName);

            o.Add("RealExeName", Env.AppRealProcessExeFileName);

            o.Add("IsDotNetCore", Env.IsDotNetCore.ToString());

            o.Add(".NET Version", Env.FrameworkInfoString);

            o.Add("DotNetHostProcessExeName", Env.DotNetHostProcessExeName);

            o.Add("AppRootDir", Env.AppRootDir);

            // 環境変数
            StringWriter w = new StringWriter();
            var dic = Environment.GetEnvironmentVariables();
            KeyValueList<string, string> tmp = new KeyValueList<string, string>();
            foreach (System.Collections.DictionaryEntry kv in dic)
            {
                if (kv.Key is string key2)
                {
                    if (kv.Value is string value2)
                    {
                        tmp.Add(key2._NonNullTrim(), value2._NonNullTrim());
                    }
                }
            }

            tmp.OrderBy(x => x.Key)._DoForEach(x => w.WriteLine($"{x.Key} = {x.Value}"));

            o.Add("Environment Values", w.ToString());

            return View(o);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
