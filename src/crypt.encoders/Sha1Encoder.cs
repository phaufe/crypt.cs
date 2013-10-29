// <summary>Implémentation de la classe <c>Crypt.Encoders.Sha1Encoder</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Security.Cryptography;
  
  /// <summary>Représente la méthode de codage SHA-1.</summary>
  public class Sha1Encoder: IStringEncoder {
  
    /// <summary>Initialise une nouvelle instance de la classe <see cref="Sha1Encoder" />.</summary>
    public Sha1Encoder() {}

    /// <summary>Obtient la description de ce codeur de chaîne.</summary>
    /// <value>Description du codeur de chaîne.</value>
    public string Description {
      get { return Resources.Sha1Description; }
    }

    /// <summary>Obtient le nom de ce codeur de chaîne.</summary>
    /// <value>Nom du codeur de chaîne.</value>
    public string Name {
      get { return "SHA-1"; }
    }

    /// <summary>Code la chaîne spécifiée.</summary>
    /// <param name="text">Chaîne à coder.</param>
    /// <returns>Chaîne après codage.</returns>
    public string Encode(string text) {
      return HashUtility.ComputeSha1(text);
    }
  }
}