using System;


namespace GAIF
{
  public class Cmd : IDisposable
  {
    ////////// Properties (private) //////////
    public Dictionary<string, string> _Params {
      get;
    }


    ////////// Properties (public) //////////
    /// <summary>
    /// Name.
    /// </summary>
    public string Name {
      get;
    }

    /// <summary>
    /// Parameters.
    /// </summary>
    public CmdParam[] Params {
      get;
    }


    ////////// Methods (public) //////////
    public string GetParam(string name)
    {
      name ??= "";

      try {
        return this._Params[name];
      }
      catch {
        throw new KeyNotFoundException("Parameter not found.");
      }
    }


    ////////// Constructor / Destructor //////////
    public Cmd(string name, CmdParam[] @params)
    {
      this.Name = name ?? "";
      this.Params = @params ?? new CmdParam[0];
      this._Params = new Dictionary<string, string>();
      foreach (var param in this.Params) {
        this._Params[param.Name] = param.Value;
      }

      return;
    }

    ~Cmd()
    {
      return;
    }

    public void Dispose()
    {
      this._Params.Clear();

      return;
    }
  }
}
