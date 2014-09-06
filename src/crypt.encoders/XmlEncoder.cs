/**
 * Implementation of the `Crypt.Encoders.XmlEncoder` class.
 * @module encoders.XmlEncoder
 */

namespace Crypt.Encoders {
  using System;
  using System.Linq;
  using System.Web;

  using Crypt.Encoders.Properties;
  
  /**
   * Represents the XML encoding method.
   * @class Crypt.Encoders.XmlEncoder
   * @constructor
   * @extends Crypt.IStringEncoder
   */
  public class XmlEncoder: IStringEncoder {
  
    public XmlEncoder() {}

    /**
     * The encoder description.
     * @property Description
     * @type System.String
     * @final
     */
    public string Description {
      get { return Resources.XmlDescription; }
    }

    /**
     * The encoder name.
     * @property Name
     * @type System.String
     * @final
     */
    public string Name {
      get { return "XML"; }
    }

    /**
     * Encodes the specified string.
     * @method Encode
     * @param {System.String} text The string to encode.
     * @return {System.String} The encoded string.
     */
    public string Encode(string text) {
      return HttpUtility.HtmlAttributeEncode(text).Replace(">", "&gt;");
    }
  }
}