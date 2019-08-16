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

            string msg = "Hello 11!";

            o.Add("メッセージ", msg);

            o.Add("メッセージ 2", Dbg.HelloMsgTest);

            o.Add("起動時刻", Env.BootTime.ToLocalTime()._ToDtStr());

            o.Add("Git Commit Id", Dbg.GetCurrentGitCommitId());

            o.Add("Process Id", Env.ProcessId.ToString());

            o.Add("BuildConfigurationName", Env.BuildConfigurationName);

            o.Add("ExeOrDllName", Env.AppExecutableExeOrDllFileName);

            o.Add("RealExeName", Env.AppRealProcessExeFileName);

            o.Add("IsDotNetCore", Env.IsDotNetCore.ToString());

            o.Add("DotNetHostProcessExeName", Env.DotNetHostProcessExeName);

            o.Add("AppRootDir", Env.AppRootDir);

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
