using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.Authentication.Exceptions;
using Hogwarts.Core.SharedServices;
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace Hogwarts_MVVM
{
    public partial class App : Application
    {
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

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
