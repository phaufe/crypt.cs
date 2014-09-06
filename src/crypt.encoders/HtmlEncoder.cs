/**
 * Implementation of the `Crypt.Encoders.HtmlEncoder` class.
 * @module encoders.HtmlEncoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  
  using Crypt.Encoders.Properties;
  using MiniFramework.Web;
  
  /**
   * Represents the HTML encoding method.
   * @class Crypt.Encoders.HtmlEncoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class HtmlEncoder: IStringEncoder {
  
    public HtmlEncoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.HtmlDescription; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "HTML"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      return Html.EntitiesEncode(text);
    }
  }
}