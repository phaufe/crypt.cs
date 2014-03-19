// <summary>Implémentation de la classe <c>Crypt.EncoderManager</c>.</summary>
// <author>Cédric Belin &lt;cedric@belin.io&gt;</author>

namespace Crypt {
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Reflection;
  
  /// <summary>Facilite l'accès aux codeurs de chaînes de caractères au moment de l'exécution.</summary>
  public static class EncoderManager {
  
    /// <summary>Liste de tous les codeurs de chaîne disponibles.</summary>
    private static IList<IStringEncoder> encoders;

    /// <summary>Obtient la liste de tous les codeurs de chaîne disponibles.</summary>
    /// <value>Liste de tous les codeurs de chaîne disponibles.</value>
    public static IList<IStringEncoder> Encoders {
      get {
        if(encoders==null) {
          var list=new SortedList<string, IStringEncoder>();

          // Détermination de l'emplacement des greffons
          var startupPath=Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
          var addinsPath=Path.Combine(startupPath, "addins");

          // Recherche des greffons
          if(Directory.Exists(addinsPath)) {
            foreach(var file in Directory.GetFiles(addinsPath, "*.dll")) {
              try {
                // Instanciation des greffons
                var query=
                  from type in Assembly.LoadFrom(file).GetTypes()
                  where type.IsVisible
                    && !type.IsAbstract
                    && type.GetConstructor(Type.EmptyTypes)!=null
                    && typeof(IStringEncoder).IsAssignableFrom(type)
                  select (IStringEncoder) Activator.CreateInstance(type);

                foreach(var item in query) list.Add(item.Name, item);
              }

              catch(SystemException) {}
            }
          }

          encoders=list.Values;
        }

        return encoders;
      }
    }
  }
}