using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.Authentication.Exceptions;
using Hogwarts.Core.SharedServices;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Hogwarts_MVVM
{
    public partial class App : Application
    {
        private bool isFirstLoad = true;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _ = StaticServiceProvidor.DbContext.Database.EnsureCreated();

            // Register the first admin
            const string ADMIN_DTO_PATH = "admin.json";
            if (!File.Exists(ADMIN_DTO_PATH))
            {
                throw new FileNotFoundException($"Could not find {ADMIN_DTO_PATH}");
            }

            try
            {
                string json = File.ReadAllText(ADMIN_DTO_PATH);
                AdminRegistrationDTO DTO = JsonConvert.DeserializeObject<AdminRegistrationDTO>(json);
                StaticServiceProvidor.authenticationService.SignUpAdmin(DTO);
            }
            catch (UserExistsException)
            {
                // Admin already exists
            }
        }

        protected override void OnLoadCompleted(NavigationEventArgs e)
        {
            base.OnLoadCompleted(e);

            if (isFirstLoad)
            {
                string startupSoundFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StaticResources/Shared/StartupChime.mp3");
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri(startupSoundFilePath));
                player.Play();

                isFirstLoad = false;
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
