namespace GAIF
{
  public class Cmd : IDisposable
  {
    //////////////////// Property (private) ////////////////////
    public Dictionary<string, CmdParam> _Params {
      get;
    }


    //////////////////// Property (public) ////////////////////
    /// <summary>
    /// Name
    /// </summary>
    public string Name {
      get;
    }

    /// <summary>
    /// Parameters
    /// </summary>
    public CmdParam[] Params {
      get;
    }



    //////////////////// Method (public) ////////////////////
    public CmdParam GetParam(string name)
    {
      if (string.IsNullOrEmpty(name)) {
        throw new KeyNotFoundException("Parameter not found.");
      }

      try {
        return this._Params[name];
      }
      catch {
        throw new KeyNotFoundException("Parameter not found.");
      }
    }


    //////////////////// Constructor/Destructor ////////////////////
    public Cmd(string name, CmdParam[] @params)
    {
      this.Name = DescUtils.VerifyName(name).ToUpper();
      this.Params = @params;
      this._Params = new Dictionary<string, CmdParam>();
      foreach (var param in this.Params) {
        this._Params[param.Name] = param;
      }

      return;
    }

    public void Dispose()
    {
      this._Params.Clear();

      return;
    }
  }

  public class CmdParam : IDisposable
  {
    //////////////////// Property (public) ////////////////////
    /// <summary>
    /// Name
    /// </summary>
    public string Name {
      get;
    }

    /// <summary>
    /// Value
    /// </summary>
    public string Value {
      get;
    }


    //////////////////// Constructor/Destructor ////////////////////
    public CmdParam(string name, string value)
    {
      this.Name = DescUtils.VerifyName(name).ToUpper();
      this.Value = value ?? "";

      return;
    }

    public void Dispose()
    {
      return;
    }
  }
}
