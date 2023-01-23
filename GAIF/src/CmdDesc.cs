using System;


namespace GAIF
{
  public class CmdDesc
  {
    ////////// Properties (public) //////////
    /// <summary>
    /// Name.
    /// </summary>
    public string Name {
      get;
    }

    /// <summary>
    /// Description.
    /// </summary>
    public string Desc {
      get;
    }

    /// <summary>
    /// Parameters.
    /// </summary>
    public CmdParamDesc[] Params {
      get;
    }


    ////////// Constructor / Destructor //////////
    public CmdDesc(string name, string desc, CmdParamDesc[] @params)
    {
      this.Name = name ?? "";
      this.Desc = desc ?? "";

      @params ??= new CmdParamDesc[0];
      if (@params.Length > 0) {
        if (Array.Find(@params, (x) => (x.Name == "")) == null) {
          foreach (var param in @params) {
            if (Array.FindAll(@params, (x) => (x.Name == param.Name)).Length != 1) {
              throw new ArgumentException();
            }
          }

          Array.Sort(@params, (x, y) => x.Name.CompareTo(y.Name));
          Array.Sort(@params, (x, y) => x.Priority.CompareTo(y.Priority));
        }
        else { 
          if (@params.Length != 0) {
            throw new ArgumentException();
          }
        }
      }
      this.Params = @params;

      return;
    }

    ~CmdDesc()
    {
      return;
    }
  }
}
