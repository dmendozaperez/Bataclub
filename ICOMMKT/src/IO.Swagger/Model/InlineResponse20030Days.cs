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
    /// InlineResponse20030Days
    /// </summary>
    [DataContract]
    public partial class InlineResponse20030Days :  IEquatable<InlineResponse20030Days>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20030Days" /> class.
        /// </summary>
        /// <param name="date">date.</param>
        /// <param name="appleMail">appleMail.</param>
        /// <param name="outlook2010">outlook2010.</param>
        public InlineResponse20030Days(string date = default(string), int? appleMail = default(int?), int? outlook2010 = default(int?))
        {
            this.Date = date;
            this.AppleMail = appleMail;
            this.Outlook2010 = outlook2010;
        }
        
        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name="Date", EmitDefaultValue=false)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets AppleMail
        /// </summary>
        [DataMember(Name="Apple Mail", EmitDefaultValue=false)]
        public int? AppleMail { get; set; }

        /// <summary>
        /// Gets or Sets Outlook2010
        /// </summary>
        [DataMember(Name="Outlook 2010", EmitDefaultValue=false)]
        public int? Outlook2010 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20030Days {\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  AppleMail: ").Append(AppleMail).Append("\n");
            sb.Append("  Outlook2010: ").Append(Outlook2010).Append("\n");
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
            return this.Equals(input as InlineResponse20030Days);
        }

        /// <summary>
        /// Returns true if InlineResponse20030Days instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20030Days to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20030Days input)
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
                    this.AppleMail == input.AppleMail ||
                    (this.AppleMail != null &&
                    this.AppleMail.Equals(input.AppleMail))
                ) && 
                (
                    this.Outlook2010 == input.Outlook2010 ||
                    (this.Outlook2010 != null &&
                    this.Outlook2010.Equals(input.Outlook2010))
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
                if (this.AppleMail != null)
                    hashCode = hashCode * 59 + this.AppleMail.GetHashCode();
                if (this.Outlook2010 != null)
                    hashCode = hashCode * 59 + this.Outlook2010.GetHashCode();
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
