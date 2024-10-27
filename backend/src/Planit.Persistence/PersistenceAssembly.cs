using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Planit.Persistence;
public class PersistenceAssembly
{
    public static Assembly Assembly => typeof(PersistenceAssembly).Assembly;
    public static string AssemblyName => Assembly.GetName().Name;
}
