using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCheckerWithMEF.Contract
{
    public interface IPluginInfo
    {
        string DisplayName { get; }
        string Description { get; }
        string Version { get; }
    }
}
