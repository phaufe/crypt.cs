// <summary>Implémentation de la classe <c>Crypt.Encoders.LowerCaseEncoder</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Encoders {
  using System;
  using System.Linq;

  using Crypt.Encoders.Properties;
  
  /// <summary>Représente la méthode de codage LowerCase.</summary>
  public class LowerCaseEncoder: IStringEncoder {
  
    /// <summary>Initialise une nouvelle instance de la classe <see cref="LowerCaseEncoder" />.</summary>
    public LowerCaseEncoder() {}

    /// <summary>Obtient la description de ce codeur de chaîne.</summary>
    /// <value>Description du codeur de chaîne.</value>
    public string Description {
      get { return Resources.LowerCaseDescription; }
    }

    /// <summary>Obtient le nom de ce codeur de chaîne.</summary>
    /// <value>Nom du codeur de chaîne.</value>
    public string Name {
      get { return "LowerCase"; }
    }

    /// <summary>Code la chaîne spécifiée.</summary>
    /// <param name="text">Chaîne à coder.</param>
    /// <returns>Chaîne après codage.</returns>
    /// <exception cref="ArgumentNullException">La chaîne spécifiée est une référence null.</exception>
    public string Encode(string text) {
      if(text==null) throw new ArgumentNullException("text");
      return text.ToLowerInvariant();
    }
  }
}