using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace GAIF
{
  internal interface IDesc
  {
    /// <summary>
    /// Name
    /// </summary>
    public string Name {
      get;
    }

    /// <summary>
    /// Description
    /// </summary>
    public string Desc {
      get;
    }
  }

  internal static class DescUtils
  {
    public static string VerifyName(string name)
    {
      if (string.IsNullOrEmpty(name)) {
        throw new ArgumentException("Name is not allwed empty.");
      }
      if (Regex.IsMatch(name, @"^[a-zA-Z][a-zA-Z0-9_]*[a-zA-Z0-9]$") == false) {
        throw new ArgumentException("Name contains invalid characters.");
      }

      return name;
    }
  }

  public class CmdDesc : IDesc, IDisposable
  {
    //////////////////// Property (private) ////////////////////
    public Dictionary<string, CmdParamDesc> _Params {
      get;
    }


    //////////////////// Property (public) ////////////////////
    public string Name {
      get;
    }

    public string Desc {
      get;
    }

    /// <summary>
    /// Parameters
    /// </summary>
    public CmdParamDesc[] Params {
      get;
    }
    
    
    //////////////////// Property (public) ////////////////////
    public CmdParamDesc GetParam(string name)
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
    public CmdDesc(string name, string desc, CmdParamDesc[] @params)
    {
      this.Name = DescUtils.VerifyName(name).ToUpper();
      this.Desc = desc ?? "";

      var tParams = @params ?? new CmdParamDesc[0];
      Array.Sort<CmdParamDesc>(tParams, (x, y) => x.Name.CompareTo(y.Name));
      Array.Sort<CmdParamDesc>(tParams, (x, y) => x.DisplayPriority.CompareTo(y.DisplayPriority));
      this._Params = new Dictionary<string, CmdParamDesc>();
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

  public class CmdParamDesc : IDesc
  {
    //////////////////// Property (public) ////////////////////
    public string Name {
      get;
    }

    public string Desc {
      get;
    }

    /// <summary>
    /// Default Value
    /// </summary>
    public string Default {
      get;
    }

    /// <summary>
    /// Display Priority
    /// </summary>
    public int DisplayPriority {
      get;
    }

    /// <summary>
    /// Required Flag
    /// </summary>
    public bool Required {
      get;
    }


    //////////////////// Constructor/Destructor ////////////////////
    public CmdParamDesc(string name, string desc, string @default, int displayPriority = 0)
    {
      this.Name = DescUtils.VerifyName(name).ToUpper();
      this.Desc = desc ?? "";
      if (string.IsNullOrEmpty(@default)) {
        this.Required = true;
        this.Default = "";
      }
      else {
        this.Required = false;
        this.Default = @default;
      }
      this.DisplayPriority = displayPriority;

      return;
    }
  }
}
