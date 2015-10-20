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

        [ImportMany(typeof(IIpChecker))]
        public List<IIpChecker> IpCheckerList;

        public MainApplication(string pluginFolder)
        {
            var catalog = new DirectoryCatalog(pluginFolder);
            _container = new CompositionContainer(catalog);

            LoadPlugins();
        }

        public void LoadPlugins()
        {
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
