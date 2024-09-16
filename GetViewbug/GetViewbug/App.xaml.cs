using GetViewbug.Modules.ModuleName;
using GetViewbug.Services;
using GetViewbug.Services.Interfaces;
using GetViewbug.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace GetViewbug
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
