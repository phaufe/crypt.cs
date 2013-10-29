// <summary>Implémentation de la classe <c>Crypt.Encoders.MD4Encoder</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Text;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Text;
  using Mono.Security.Cryptography;
  
  /// <summary>Représente la méthode de codage MD4.</summary>
  public class MD4Encoder: IStringEncoder {
  
    /// <summary>Initialise une nouvelle instance de la classe <see cref="MD4Encoder" />.</summary>
    public MD4Encoder() {}

    /// <summary>Obtient la description de ce codeur de chaîne.</summary>
    /// <value>Description du codeur de chaîne.</value>
    public string Description {
      get { return Resources.MD4Description; }
    }

    /// <summary>Obtient le nom de ce codeur de chaîne.</summary>
    /// <value>Nom du codeur de chaîne.</value>
    public string Name {
      get { return "MD4"; }
    }

    /// <summary>Code la chaîne spécifiée.</summary>
    /// <param name="text">Chaîne à coder.</param>
    /// <returns>Chaîne après codage.</returns>
    public string Encode(string text) {
      var buffer=Encoding.Default.GetBytes(text);
      var hash=MD4.Create().ComputeHash(buffer);
      return HexCodec.GetString(hash);
    }
  }
}