using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCheckerWithMEF.Contract
{
    [InheritedExport(typeof(IIpChecker))]
    public interface IIpChecker
    {
        string GetExternalIp();
    }
}
