using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hogwarts_Management_System.Models;

namespace Hogwarts_Management_System
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            FileManager.Load();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //ActivationCode ac = new ActivationCode("sali");
            //Globals.ActivationCodes.Add(ac);
            FileManager.Save();
        }

    }



}
