// <summary>Implémentation de la classe <c>Crypt.Encoders.RandomAsciiEncoder</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Encoders {
  using System;
  using System.Globalization;
  using System.Linq;
  using System.Text;

  using Crypt.Encoders.Properties;
  
  /// <summary>Représente la méthode de codage RandomASCII.</summary>
  public class RandomAsciiEncoder: IStringEncoder {
  
    /// <summary>Instance utilisée pour générer une séquence de nombres aléatoires.</summary>
    private Random random=new Random();
    
    /// <summary>Initialise une nouvelle instance de la classe <see cref="RandomAsciiEncoder" />.</summary>
    public RandomAsciiEncoder() {
      this.random=new Random();
    }

    /// <summary>Obtient la description de ce codeur de chaîne.</summary>
    /// <value>Description du codeur de chaîne.</value>
    public string Description {
      get { return Resources.RandomAsciiDescription; }
    }

    /// <summary>Obtient le nom de ce codeur de chaîne.</summary>
    /// <value>Nom du codeur de chaîne.</value>
    public string Name {
      get { return "RandomASCII"; }
    }

    /// <summary>Code la chaîne spécifiée.</summary>
    /// <param name="text">Chaîne à coder.</param>
    /// <returns>Chaîne après codage.</returns>
    public string Encode(string text) {
      if(string.IsNullOrEmpty(text)) return text;

      var builder=new StringBuilder(text.Length);
      foreach(var item in text) {
        if(this.random.Next(3)==0) builder.Append(item);
        else builder.Append(string.Format(CultureInfo.InvariantCulture, "&#{0};", (int) item));
      }

      return builder.ToString();
    }
  }
}