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
    /// InlineResponse20033
    /// </summary>
    [DataContract]
    public partial class InlineResponse20033 :  IEquatable<InlineResponse20033>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20033" /> class.
        /// </summary>
        /// <param name="days">days.</param>
        /// <param name="googleChrome">googleChrome.</param>
        /// <param name="safariMobile">safariMobile.</param>
        public InlineResponse20033(List<InlineResponse20033Days> days = default(List<InlineResponse20033Days>), int? googleChrome = default(int?), int? safariMobile = default(int?))
        {
            this.Days = days;
            this.GoogleChrome = googleChrome;
            this.SafariMobile = safariMobile;
        }
        
        /// <summary>
        /// Gets or Sets Days
        /// </summary>
        [DataMember(Name="Days", EmitDefaultValue=false)]
        public List<InlineResponse20033Days> Days { get; set; }

        /// <summary>
        /// Gets or Sets GoogleChrome
        /// </summary>
        [DataMember(Name="Google Chrome", EmitDefaultValue=false)]
        public int? GoogleChrome { get; set; }

        /// <summary>
        /// Gets or Sets SafariMobile
        /// </summary>
        [DataMember(Name="Safari mobile", EmitDefaultValue=false)]
        public int? SafariMobile { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20033 {\n");
            sb.Append("  Days: ").Append(Days).Append("\n");
            sb.Append("  GoogleChrome: ").Append(GoogleChrome).Append("\n");
            sb.Append("  SafariMobile: ").Append(SafariMobile).Append("\n");
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
            return this.Equals(input as InlineResponse20033);
        }

        /// <summary>
        /// Returns true if InlineResponse20033 instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20033 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20033 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Days == input.Days ||
                    this.Days != null &&
                    this.Days.SequenceEqual(input.Days)
                ) && 
                (
                    this.GoogleChrome == input.GoogleChrome ||
                    (this.GoogleChrome != null &&
                    this.GoogleChrome.Equals(input.GoogleChrome))
                ) && 
                (
                    this.SafariMobile == input.SafariMobile ||
                    (this.SafariMobile != null &&
                    this.SafariMobile.Equals(input.SafariMobile))
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
                if (this.Days != null)
                    hashCode = hashCode * 59 + this.Days.GetHashCode();
                if (this.GoogleChrome != null)
                    hashCode = hashCode * 59 + this.GoogleChrome.GetHashCode();
                if (this.SafariMobile != null)
                    hashCode = hashCode * 59 + this.SafariMobile.GetHashCode();
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
