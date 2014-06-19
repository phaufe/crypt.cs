// <summary>Implémentation de la classe <c>Crypt.Encoders.Base64Encoder</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Text;

  using Crypt.Encoders.Properties;
  
  /// <summary>Représente la méthode de codage Base64.</summary>
  public class Base64Encoder: IStringEncoder {
  
    /// <summary>Initialise une nouvelle instance de la classe <see cref="Base64Encoder" />.</summary>
    public Base64Encoder() {}

    /// <summary>Obtient la description de ce codeur de chaîne.</summary>
    /// <value>Description du codeur de chaîne.</value>
    public string Description {
      get { return Resources.Base64Description; }
    }

    /// <summary>Obtient le nom de ce codeur de chaîne.</summary>
    /// <value>Nom du codeur de chaîne.</value>
    public string Name {
      get { return "Base64"; }
    }

    /// <summary>Code la chaîne spécifiée.</summary>
    /// <param name="text">Chaîne à coder.</param>
    /// <returns>Chaîne après codage.</returns>
    public string Encode(string text) {
      var bytes=Encoding.Default.GetBytes(text);
      return Convert.ToBase64String(bytes);
    }
  }
}