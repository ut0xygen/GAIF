using System;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace GAIF
{
  public class Instruction
  {
    public string Name {
      get;
    }

    public Instruction()
    {
      return;
    }
  }

  public abstract class InstructionParser
  {
    public abstract string Name { 
      get; 
    }
    
    public abstract int Priority {
      get;
    }

    public abstract bool Skip {
      get;
    }


    public abstract Instruction Parse(string text);
  }


  public class BuiltinParser : InstructionParser
  {
    public override string Name => "BUILTIN";

    public override int Priority => 0;

    public override bool Skip => true;


    public override Instruction Parse(string text)
    {
// JUMP
// VAR

    }
  }

  public class ScriptParser
  {

    public static Instruction[] Parse(string script)
    {
      Instruction[] insts = new Instruction[0];
      InstructionParser[] parsers = new InstructionParser[] {
        new BuiltinParser(),
      };


#pragma warning disable CS8602 
      string dirPlugin = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName.Replace("\\", "/") + "/plugins";
#pragma warning restore CS8602


    } 
  }
}