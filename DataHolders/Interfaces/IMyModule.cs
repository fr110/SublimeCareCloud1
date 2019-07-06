using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders.Interfaces
{
    public interface IMyModule
    {
        dhModule ActiveModule(string ModuleName, int? IModuleParentID=0);
    }
}
