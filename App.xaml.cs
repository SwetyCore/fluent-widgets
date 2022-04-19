﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfWidgetDesktop.Utils;

namespace MyNewApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            // 当前作用域出现未捕获异常时，使用MyHandler函数响应事件
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            base.OnStartup(e);
            SettingProvider.Init();
        }
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("UnHandled Exception Caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);

            MessageBox.Show(e.Message + "\n" + e.StackTrace, "程序崩溃了！");
            System.IO.File.WriteAllText("err.log", e.Message + e.StackTrace);

        }

        protected override void OnExit(ExitEventArgs e)
        {
            SettingProvider.Save();

            base.OnExit(e);
        }
    }
}
