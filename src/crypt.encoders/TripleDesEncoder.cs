// <summary>Implémentation de la classe <c>Crypt.Encoders.TripleDesEncoder</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Security.Cryptography;
  using System.Text;

  using Crypt.Encoders.Properties;
  
  /// <summary>Représente la méthode de codage TripleDES.</summary>
  public class TripleDesEncoder: IStringEncoder {
  
    /// <summary>Initialise une nouvelle instance de la classe <see cref="TripleDesEncoder" />.</summary>
    public TripleDesEncoder() {}

    /// <summary>Obtient la description de ce codeur de chaîne.</summary>
    /// <value>Description du codeur de chaîne.</value>
    public string Description {
      get { return Resources.TripleDesDescription; }
    }

    /// <summary>Obtient le nom de ce codeur de chaîne.</summary>
    /// <value>Nom du codeur de chaîne.</value>
    public string Name {
      get { return "TripleDES"; }
    }

    /// <summary>Code la chaîne spécifiée.</summary>
    /// <param name="text">Chaîne à coder.</param>
    /// <returns>Chaîne après codage.</returns>
    public string Encode(string text) {
      var bytes=Encoding.Default.GetBytes(text);
      return Convert.ToBase64String(TripleDES.Create().CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
    }
  }
}