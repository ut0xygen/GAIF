using System;


namespace GAIF
{
  public class CmdParamDesc
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
    /// Default value.
    /// </summary>
    public string Default {
      get;
    }

    /// <summary>
    /// Required flag.
    /// </summary>
    public bool Required {
      get;
    }

    /// <summary>
    /// Display priority.
    /// </summary>
    public int Priority {
      get;
    }


    ////////// Constructor / Destructor //////////
    public CmdParamDesc(string name, string desc, string @default, int priority = 0)
    {
      this.Name = name ?? "";
      this.Desc = desc ?? "";
      this.Default = @default ?? "";
      this.Required = string.IsNullOrEmpty(@default);
      this.Priority = priority;

      return;
    }

    ~CmdParamDesc()
    {
      return;
    }
  }
}
