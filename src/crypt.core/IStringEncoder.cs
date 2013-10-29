// <summary>Implémentation de l'interface <c>Crypt.IStringEncoder</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt {
  using System;
  using System.Linq;
  
  /// <summary>Représente un codeur de chaînes de caractères.</summary>
  public interface IStringEncoder {
  
    /// <summary>Obtient la description de ce codeur de chaîne.</summary>
    /// <value>Description du codeur de chaîne.</value>
    string Description {
      get;
    }

    /// <summary>Obtient le nom de ce codeur de chaîne.</summary>
    /// <value>Nom du codeur de chaîne.</value>
    string Name {
      get;
    }

    /// <summary>Code la chaîne spécifiée.</summary>
    /// <param name="text">Chaîne à coder.</param>
    /// <returns>Chaîne après codage.</returns>
    string Encode(string text);
  }
}