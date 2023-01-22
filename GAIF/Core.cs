using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GAIF
{
  public class Core
  {
    private List<Assembly> Assemblies {
      get;
    }

    private List<Module> Modules {
      get;
    }

    public void LoadModule(string[] libPathes)
    {
      if (libPathes == null || libPathes.Length == 0) {
        return;
      }

      Assembly asm;
      Type[] types;
      foreach (string path in libPathes) {
        try {
          asm = Assembly.LoadFrom(path);
          types = Array.FindAll(
            asm.GetTypes(),
            type => type.IsClass    == true           &&
                    type.IsPublic   == true           &&
                    type.IsAbstract == false          &&
                    type.BaseType   == typeof(Module)
          );
        }
        catch {
          Console.Error.WriteLine($"Failed to load library. [PATH: {path}]");

          continue;
        }
        if (types.Length == 0) {
          continue;
        }

        this.Assemblies.Add(asm);
        foreach (Type type in types) {
#pragma warning disable CS8600, CS8604
          this.Modules.Add((Module)asm.CreateInstance(type.FullName));
#pragma warning restore CS8600, CS8604
        }
      }
    }

    void UnloadModule()
    {
      if (this.Modules.Count == 0) {
        return;
      }

      foreach (var module in this.Modules) {
        module.
      }

      return;
    }

    public Core()
    {
      Modules = new List<Module>();

      return;
    }
  }
}
