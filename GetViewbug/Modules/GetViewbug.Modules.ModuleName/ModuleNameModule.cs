using GetViewbug.Core;
using GetViewbug.Modules.ModuleName.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace GetViewbug.Modules.ModuleName
{
    public class ModuleNameModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleNameModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //Registering like this should name the ItemMetadataCollection[0].Name right ?
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, "ViewA");

            //but this still returns null
            var thisShouldNotBeNull = _regionManager.Regions[RegionNames.ContentRegion].GetView("ViewA");

            if (thisShouldNotBeNull is null)
                throw new InvalidOperationException("_regionManager.Regions[RegionNames.ContentRegion].GetView(\"ViewA\")  returned null");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //naming it here does not help either
            containerRegistry.RegisterForNavigation<ViewA>(/*ViewA*/);
        }
    }
}