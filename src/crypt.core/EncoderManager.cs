/**
 * Implementation of the `Crypt.EncoderManager` class.
 * @module core.EncoderManager
 */

namespace Crypt {
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Reflection;
  
  /**
   * Facilitates access to the string encoders at run time.
   * @class Crypt.EncoderManager
   * @static
   */
  public static class EncoderManager {
  
    /**
     * The list of all available string encoders.
     * @property Encoders
     * @type System.Collections.Generic.IList&lt;Crypt.IStringEncoder&gt;
     * @static
     */
    private static IList<IStringEncoder> encoders;
    public static IList<IStringEncoder> Encoders {
      get {
        if(encoders==null) {
          var list=new SortedList<string, IStringEncoder>();

          var startupPath=Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
          var addinsPath=Path.Combine(startupPath, "addins");

          if(Directory.Exists(addinsPath)) {
            foreach(var file in Directory.GetFiles(addinsPath, "*.dll")) {
              try {
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