using System;


namespace GAIF
{
  public class CmdParam
  {
    ////////// Properties (public) //////////
    /// <summary>
    /// Name.
    /// </summary>
    public string Name {
      get;
    }

    /// <summary>
    /// Value.
    /// </summary>
    public string Value {
      get;
    }


    ////////// Constructor / Destructor //////////
    public CmdParam(string name, string value)
    {
      this.Name = name ?? "";
      this.Value = value ?? "";

      return;
    }

    ~CmdParam()
    {
      return;
    }
  }
}
