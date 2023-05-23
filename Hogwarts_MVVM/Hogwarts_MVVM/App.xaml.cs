/*
 * By Miaad Kimiagari
 * 5/21/2023
 * Available on GitHub: https://github.com/Miaad2004/Hogwarts-Management-System-in-C-Sharp-WPF
 */


using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.Authentication.Exceptions;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts.Core.SharedServices;
using Microsoft.Extensions.DependencyInjection;
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
        public IServiceProvider ServiceProvider { get; private set; }
        private bool isFirstLoadFlag = true;

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            ServiceRegistration.ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var dbContext = ServiceProvider.GetRequiredService<HogwartsDbContext>();
            dbContext.Database.EnsureCreated();

            RegisterFirstAdmin();

            base.OnStartup(e);
        }

        protected override void OnLoadCompleted(NavigationEventArgs e)
        {
            if (isFirstLoadFlag)
            {
                PlayStartupChime();
                isFirstLoadFlag = false;
            }

            base.OnLoadCompleted(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        private async void RegisterFirstAdmin()
        {
            var authService = ServiceProvider.GetRequiredService<IAuthenticationService>();

            const string ADMIN_DTO_PATH = "admin.json";
            if (!File.Exists(ADMIN_DTO_PATH))
            {
                throw new FileNotFoundException($"Could not find {ADMIN_DTO_PATH}");
            }

            try
            {
                string json = File.ReadAllText(ADMIN_DTO_PATH);
                AdminRegistrationDTO DTO = JsonConvert.DeserializeObject<AdminRegistrationDTO>(json) ?? throw new JsonSerializationException();
                await authService.SignUpAdminAsync(DTO);
            }

            catch (UserExistsException)
            {
                // Admin already exists
            }
        }

        private void PlayStartupChime()
        {
            string startupSoundFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StaticResources/Shared/StartupChime.mp3");
            MediaPlayer player = new();
            player.Open(new Uri(startupSoundFilePath));

            Activated += (sender, args) => player.Play();
            Deactivated += (sender, args) => player.Pause();
        }
    }
}
