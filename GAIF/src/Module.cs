using System;


namespace GAIF
{
  public abstract class Module : IDisposable
  {
    ////////// Properties (public) //////////
    /// <summary>
    /// Assembly path.
    /// </summary>
    public string AsmPath {
      get; internal set;
    }

    /// <summary>
    /// Namespace.
    /// </summary>
    public string Namespace {
      get;
    }

    /// <summary>
    /// Name.
    /// </summary>
    public string Name {
      get;
    }

    /// <summary>
    /// Commands.
    /// </summary>
    public CmdDesc[] Commands {
      get; internal set;
    }


    ////////// Methods (public) //////////
    public abstract void Process(Cmd cmd);


    ////////// Constructor / Destructor //////////
    public Module(CmdDesc[] cmds)
    {
      this.AsmPath = "";
      this.Name = this.GetType().Name;
      this.Namespace = this.GetType().Namespace ?? "";
      this.Commands = cmds ?? new CmdDesc[0];

      Array.Sort(this.Commands, (x, y) => x.Name.CompareTo(y.Name));

      return;
    }

    ~Module()
    {
      return;
    }

    public abstract void Dispose();
  }
}
