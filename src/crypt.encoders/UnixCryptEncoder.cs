// <summary>Implémentation de la classe <c>Crypt.Encoders.UnixCryptEncoder</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using DigiWar.Security.Cryptography;
  
  /// <summary>Représente la méthode de codage UNIXCrypt.</summary>
  public class UnixCryptEncoder: IStringEncoder {
  
    /// <summary>Initialise une nouvelle instance de la classe <see cref="UnixCryptEncoder" />.</summary>
    public UnixCryptEncoder() {}

    /// <summary>Obtient la description de ce codeur de chaîne.</summary>
    /// <value>Description du codeur de chaîne.</value>
    public string Description {
      get { return Resources.UnixCryptDescription; }
    }

    /// <summary>Obtient le nom de ce codeur de chaîne.</summary>
    /// <value>Nom du codeur de chaîne.</value>
    public string Name {
      get { return "UNIXCrypt"; }
    }

    /// <summary>Code la chaîne spécifiée.</summary>
    /// <param name="text">Chaîne à coder.</param>
    /// <returns>Chaîne après codage.</returns>
    public string Encode(string text) {
      return UnixCrypt.Crypt(text);
    }
  }
}