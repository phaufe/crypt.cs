// <summary>Implémentation de la classe <c>Crypt.Windows.App</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Console {
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;

  using Crypt.Console.Properties;
  using MiniFramework.Reflection;
  using Mono.Options;

  /// <summary>Application console.</summary>
  internal class Program {
  
    /// <summary>Informations de l'assemblage de l'application.</summary>
    private static AssemblyInfo appInfo=new AssemblyInfo(typeof(Program).Assembly);
    
    /// <summary>Options de la ligne de commandes.</summary>
    private static OptionSet options;

    /// <summary>Point d'entrée du programme.</summary>
    /// <param name="args">Arguments de la ligne de commandes.</param>
    private static void Main(string[] args) {
      // Validation de l'installation
      CheckSetup();

      // Paramétrage des options de ligne de commandes
      bool printHelp=false;
      bool printList=false;
      bool printVersion=false;

      options=new OptionSet {
        { "?|h|help", Resources.HelpOption, x=> printHelp=(x!=null) },
        { "l|list", Resources.ListOption, x=> printList=(x!=null) },
        { "v|version", Resources.VersionOption, x=> printVersion=(x!=null) }
      };

      // Analyse de la ligne de commandes
      List<string> parameters=null;
      try { parameters=options.Parse(args); }

      catch(OptionException e) {
        Console.WriteLine();
        Console.WriteLine(e.Message);
        PrintUsage();
        return;
      }

      // Affiche l'aide détaillée
      if(printHelp) {
        PrintHelp();
        return;
      }

      // Affiche la liste des algorithmes de hachage
      if(printList) {
        PrintEncoderList();
        return;
      }

      // Affiche le numéro de version
      if(printVersion) {
        PrintVersion();
        return;
      }

      // Codage de la chaîne
      if(parameters==null || parameters.Count!=2) {
        Console.WriteLine();
        Console.WriteLine(Resources.SyntaxError);
        PrintUsage();
        return;
      }

      PrintEncodedString(parameters[0], parameters[1]);
    }

    /// <summary>Vérifie que toutes les conditions sont réunies pour le démarrage de l'application.</summary>
    /// <remarks>Si aucun codeur de chaîne ne peut être trouvé, un message est affiché à l'utilisateur et l'application arrêtée.</remarks>
    private static void CheckSetup() {
      if(EncoderManager.Encoders.Count==0) {
        Console.WriteLine();
        Console.WriteLine(Resources.AddInsNotFoundError);
        Console.WriteLine();

        Environment.Exit(1);
      }
    }

    /// <summary>Affiche la chaîne spécifiée codée par l'algorithme de hachage spécifié.</summary>
    /// <param name="encodingMethod">Nom de la méthode de codage à utiliser.</param>
    /// <param name="stringToEncode">Chaîne à coder.</param>
    private static void PrintEncodedString(string encodingMethod, string stringToEncode) {
      Console.WriteLine();

      var encoder=EncoderManager.Encoders.FirstOrDefault(x=>x.Name.ToUpperInvariant()==encodingMethod.ToUpperInvariant());
      if(encoder==null) {
        Console.WriteLine(Resources.UnknownEncoderError);
        PrintEncoderList();
        return;
      }

      var encodedString=encoder.Encode(stringToEncode);
      Console.WriteLine(encodedString.Length>0 ? encodedString : "\"\"");
      Console.WriteLine();
    }

    /// <summary>Affiche la liste des codeurs de chaîne supportés par l'application.</summary>
    private static void PrintEncoderList() {
      Console.WriteLine();
      
      foreach(var item in EncoderManager.Encoders) {
        Console.Write(item.Name.PadRight(25));
        Console.WriteLine(item.Description);
      }

      Console.WriteLine();
    }

    /// <summary>Affiche l'aide détaillée.</summary>
    private static void PrintHelp() {
      Console.WriteLine();
      Console.WriteLine(Resources.Description);
      PrintUsage();
    }

    /// <summary>Affiche la syntaxe d'utilisation du programme.</summary>
    private static void PrintUsage() {
      Console.WriteLine();
      Console.WriteLine(Resources.Usage, appInfo.Title);
      Console.WriteLine();
      Console.WriteLine(Resources.Options);
      options.WriteOptionDescriptions(Console.Out);
      Console.WriteLine();
    }

    /// <summary>Affiche les informations de version de l'application.</summary>
    private static void PrintVersion() {
      Console.WriteLine();
      Console.WriteLine("{0} {1}", appInfo.Product, appInfo.Version);
      Console.WriteLine(string.Format(CultureInfo.CurrentCulture, Resources.Copyright, appInfo.Copyright));
      Console.WriteLine();
    }
  }
}