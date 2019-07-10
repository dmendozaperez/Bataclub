/* 
 * ICOMMKT Transactional API
 *
 * ICOMMKT Transactional API
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// InlineResponse20029Days
    /// </summary>
    [DataContract]
    public partial class InlineResponse20029Days :  IEquatable<InlineResponse20029Days>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20029Days" /> class.
        /// </summary>
        /// <param name="date">date.</param>
        /// <param name="desktop">desktop.</param>
        /// <param name="webMail">webMail.</param>
        public InlineResponse20029Days(string date = default(string), int? desktop = default(int?), int? webMail = default(int?))
        {
            this.Date = date;
            this.Desktop = desktop;
            this.WebMail = webMail;
        }
        
        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name="Date", EmitDefaultValue=false)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets Desktop
        /// </summary>
        [DataMember(Name="Desktop", EmitDefaultValue=false)]
        public int? Desktop { get; set; }

        /// <summary>
        /// Gets or Sets WebMail
        /// </summary>
        [DataMember(Name="WebMail", EmitDefaultValue=false)]
        public int? WebMail { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20029Days {\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Desktop: ").Append(Desktop).Append("\n");
            sb.Append("  WebMail: ").Append(WebMail).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as InlineResponse20029Days);
        }

        /// <summary>
        /// Returns true if InlineResponse20029Days instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20029Days to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20029Days input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
                ) && 
                (
                    this.Desktop == input.Desktop ||
                    (this.Desktop != null &&
                    this.Desktop.Equals(input.Desktop))
                ) && 
                (
                    this.WebMail == input.WebMail ||
                    (this.WebMail != null &&
                    this.WebMail.Equals(input.WebMail))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Date != null)
                    hashCode = hashCode * 59 + this.Date.GetHashCode();
                if (this.Desktop != null)
                    hashCode = hashCode * 59 + this.Desktop.GetHashCode();
                if (this.WebMail != null)
                    hashCode = hashCode * 59 + this.WebMail.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}