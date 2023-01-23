using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GAIF
{
  public class Core : IDisposable
  {
    ////////// Properties (private) //////////
    private List<Module> BuiltinModules {
      get;
    }

    private List<Module> Modules {
      get;
    }

    ////////// Methods (public) //////////
    /// <summary>
    /// Load module.
    /// </summary>
    /// <param name="path">Library Path</param>
    public void LoadModule(string path)
    {
      if (string.IsNullOrEmpty(path)) {
        return;
      }

      Assembly asm;

      try { // Load library.
        asm = Assembly.LoadFrom(path);
      }
      catch {
        throw new FileLoadException($"Failed to load library. [PATH: {path}]");
      }

      foreach (var type in asm.ExportedTypes) {
        if (type.IsClass == false || type.IsSubclassOf(typeof(Module)) == false || type.IsAbstract) {
          continue;
        }

        { // Verify duplicates.
          string ns = type.Namespace ?? "";
          string name = type.Name ?? "";

          if (this.Modules.Find((x) => (x.Namespace == ns && x.Name == name)) != null) {
            throw new TypeLoadException();
          }
        }

        { // Add module.
          Module? mod = Activator.CreateInstance(type) as Module;

          if (mod != null) {
            throw new TypeLoadException();
          }

          mod.AsmPath = Path.GetFullPath(path);

          this.Modules.Add(mod);
        }
      }
    }

    public void UnloadModule()
    {
      foreach (var module in this.Modules) {
        module.Dispose();
      }
      this.Modules.Clear();

      return;
    }

    ////////// Constructor / Destructor //////////
    public Core()
    {
      this.BuiltinModules = new List<Module>();
      this.Modules = new List<Module>();

      return;
    }

    ~Core()
    {
      return;
    }

    public void Dispose()
    {
      return;
    }
  }
}
