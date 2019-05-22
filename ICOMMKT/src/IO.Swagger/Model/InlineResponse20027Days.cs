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
    /// InlineResponse20027Days
    /// </summary>
    [DataContract]
    public partial class InlineResponse20027Days :  IEquatable<InlineResponse20027Days>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20027Days" /> class.
        /// </summary>
        /// <param name="date">date.</param>
        /// <param name="tracked">tracked.</param>
        public InlineResponse20027Days(string date = default(string), int? tracked = default(int?))
        {
            this.Date = date;
            this.Tracked = tracked;
        }
        
        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name="Date", EmitDefaultValue=false)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets Tracked
        /// </summary>
        [DataMember(Name="Tracked", EmitDefaultValue=false)]
        public int? Tracked { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20027Days {\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Tracked: ").Append(Tracked).Append("\n");
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
            return this.Equals(input as InlineResponse20027Days);
        }

        /// <summary>
        /// Returns true if InlineResponse20027Days instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20027Days to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20027Days input)
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
                    this.Tracked == input.Tracked ||
                    (this.Tracked != null &&
                    this.Tracked.Equals(input.Tracked))
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
                if (this.Tracked != null)
                    hashCode = hashCode * 59 + this.Tracked.GetHashCode();
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
