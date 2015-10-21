using IPCheckerWithMEF.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCheckerWithMEF.Lab
{
    public class MainApplication
    {
        private CompositionContainer _container;
        private DirectoryCatalog _catalog;

        [ImportMany(AllowRecomposition = true)]
        public List<Lazy<IIpChecker, IPluginInfo>> Plugins { get; set; }

        public MainApplication(string pluginFolder)
        {
            _catalog = new DirectoryCatalog(pluginFolder);
            _container = new CompositionContainer(_catalog);

            LoadPlugins();
        }

        public void LoadPlugins()
        {
            try
            {
                _catalog.Refresh();
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
