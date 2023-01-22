using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAIF
{
  public abstract class Module : System.IDisposable
  {
    //////////////////// Property (private) ////////////////////
    private bool _Initialized {
      get;
      set;
    }

    private CmdDesc[] _Commands {
      get;
      set;
    }


    //////////////////// Property (public) ////////////////////
    /// <summary>
    /// Available Commands
    /// </summary>
    public CmdDesc[] Commands {
      get => this._Commands;
      set {
        if (this._Initialized) {
          throw new InvalidOperationException("This property can only be assigned once.");
        }

        this._Commands = value ?? new CmdDesc[0];
        this._Initialized = true;
      }
    }


    //////////////////// Method (public) ////////////////////
    public abstract void Process(Cmd cmd);


    //////////////////// Constructor/Destructor ////////////////////
    public Module()
    {
      this._Commands = new CmdDesc[0];

      return;
    }

    public abstract void Dispose();
  }

}

namespace Core
{
  using GAIF;
  using System.Diagnostics;

  namespace Variable
  {
    public class Integer : Module
    {
      //////////////////// Property (private) ////////////////////
      private Dictionary<string, int> Values {
        get;
      }


      //////////////////// Method (public) ////////////////////
      public override void Process(Cmd cmd)
      {
        switch (cmd.Name) {
          case "DEF":
            this.Values.Add(cmd.)
            break;

          case "ASS":
            break;

          case "ADD":
            break;

          case "SUB":
            break;
        }
      }


      //////////////////// Constructor/Destructor ////////////////////
      public Integer()
      {
        this.Commands = new CmdDesc[]{
        new CmdDesc(
          name        : "DEF",
          desc        : "Declare variable.",
          @params  : new CmdParamDesc[] {
            new CmdParamDesc(
              name      : "N",
              desc      : "Name.",
              @default  : ""
            ),
            new CmdParamDesc(
              name      : "V",
              desc      : "Initial value.",
              @default  : ""
            ),
          }
        ),

        new CmdDesc(
          name        : "ASS",
          desc        : "Assignment to target variable.",
          @params  : new CmdParamDesc[] {
            new CmdParamDesc(
              name      : "N",
              desc      : "Variable name.",
              @default  : ""
            ),
            new CmdParamDesc(
              name      : "V",
              desc      : "Value.",
              @default  : ""
            ),
          }
        ),

        new CmdDesc(
          name        : "ADD",
          desc        : "Additive assignment to target variable.",
          @params  : new CmdParamDesc[] {
            new CmdParamDesc(
              name      : "N",
              desc      : "Variable name.",
              @default  : ""
            ),
            new CmdParamDesc(
              name      : "V",
              desc      : "Value.",
              @default  : ""
            ),
          }
        ),

        new CmdDesc(
          name        : "SUB",
          desc        : "Subtractive assignment to target variable.",
          @params  : new CmdParamDesc[] {
            new CmdParamDesc(
              name      : "N",
              desc      : "Variable name.",
              @default  : ""
            ),
            new CmdParamDesc(
              name      : "V",
              desc      : "Value.",
              @default  : ""
            ),
          }
        ),
      };
        this.Values = new Dictionary<string, int>();
      }

      public override void Dispose()
      {
        return;
      }
    }
  }
}
