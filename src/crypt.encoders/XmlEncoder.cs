// <summary>Implémentation de la classe <c>Crypt.Encoders.XmlEncoder</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Web;

  using Crypt.Encoders.Properties;
  
  /// <summary>Représente la méthode de codage XML.</summary>
  public class XmlEncoder: IStringEncoder {
  
    /// <summary>Initialise une nouvelle instance de la classe <see cref="XmlEncoder" />.</summary>
    public XmlEncoder() {}

    /// <summary>Obtient la description de ce codeur de chaîne.</summary>
    /// <value>Description du codeur de chaîne.</value>
    public string Description {
      get { return Resources.XmlDescription; }
    }

    /// <summary>Obtient le nom de ce codeur de chaîne.</summary>
    /// <value>Nom du codeur de chaîne.</value>
    public string Name {
      get { return "XML"; }
    }

    /// <summary>Code la chaîne spécifiée.</summary>
    /// <param name="text">Chaîne à coder.</param>
    /// <returns>Chaîne après codage.</returns>
    public string Encode(string text) {
      return HttpUtility.HtmlAttributeEncode(text).Replace(">", "&gt;");
    }
  }
}