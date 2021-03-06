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
    /// InlineResponse20030
    /// </summary>
    [DataContract]
    public partial class InlineResponse20030 :  IEquatable<InlineResponse20030>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20030" /> class.
        /// </summary>
        /// <param name="appleMail">appleMail.</param>
        /// <param name="days">days.</param>
        /// <param name="outlook2010">outlook2010.</param>
        public InlineResponse20030(int? appleMail = default(int?), List<InlineResponse20030Days> days = default(List<InlineResponse20030Days>), int? outlook2010 = default(int?))
        {
            this.AppleMail = appleMail;
            this.Days = days;
            this.Outlook2010 = outlook2010;
        }
        
        /// <summary>
        /// Gets or Sets AppleMail
        /// </summary>
        [DataMember(Name="Apple Mail", EmitDefaultValue=false)]
        public int? AppleMail { get; set; }

        /// <summary>
        /// Gets or Sets Days
        /// </summary>
        [DataMember(Name="Days", EmitDefaultValue=false)]
        public List<InlineResponse20030Days> Days { get; set; }

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
            sb.Append("class InlineResponse20030 {\n");
            sb.Append("  AppleMail: ").Append(AppleMail).Append("\n");
            sb.Append("  Days: ").Append(Days).Append("\n");
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
            return this.Equals(input as InlineResponse20030);
        }

        /// <summary>
        /// Returns true if InlineResponse20030 instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20030 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20030 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AppleMail == input.AppleMail ||
                    (this.AppleMail != null &&
                    this.AppleMail.Equals(input.AppleMail))
                ) && 
                (
                    this.Days == input.Days ||
                    this.Days != null &&
                    this.Days.SequenceEqual(input.Days)
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
                if (this.AppleMail != null)
                    hashCode = hashCode * 59 + this.AppleMail.GetHashCode();
                if (this.Days != null)
                    hashCode = hashCode * 59 + this.Days.GetHashCode();
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
