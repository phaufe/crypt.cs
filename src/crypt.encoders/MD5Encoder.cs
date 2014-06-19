// <summary>Implémentation de la classe <c>Crypt.Encoders.MD5Encoder</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Security.Cryptography;
  
  /// <summary>Représente la méthode de codage MD5.</summary>
  public class MD5Encoder: IStringEncoder {
  
    /// <summary>Initialise une nouvelle instance de la classe <see cref="MD5Encoder" />.</summary>
    public MD5Encoder() {}

    /// <summary>Obtient la description de ce codeur de chaîne.</summary>
    /// <value>Description du codeur de chaîne.</value>
    public string Description {
      get { return Resources.MD5Description; }
    }

    /// <summary>Obtient le nom de ce codeur de chaîne.</summary>
    /// <value>Nom du codeur de chaîne.</value>
    public string Name {
      get { return "MD5"; }
    }

    /// <summary>Code la chaîne spécifiée.</summary>
    /// <param name="text">Chaîne à coder.</param>
    /// <returns>Chaîne après codage.</returns>
    public string Encode(string text) {
      return HashUtility.ComputeMD5(text);
    }
  }
}