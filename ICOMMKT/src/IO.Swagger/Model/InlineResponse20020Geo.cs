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
    /// InlineResponse20020Geo
    /// </summary>
    [DataContract]
    public partial class InlineResponse20020Geo :  IEquatable<InlineResponse20020Geo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20020Geo" /> class.
        /// </summary>
        /// <param name="countryISOCode">countryISOCode.</param>
        /// <param name="country">country.</param>
        /// <param name="regionISOCode">regionISOCode.</param>
        /// <param name="city">city.</param>
        /// <param name="zip">zip.</param>
        /// <param name="coords">coords.</param>
        /// <param name="iP">iP.</param>
        public InlineResponse20020Geo(string countryISOCode = default(string), string country = default(string), string regionISOCode = default(string), string city = default(string), string zip = default(string), string coords = default(string), string iP = default(string))
        {
            this.CountryISOCode = countryISOCode;
            this.Country = country;
            this.RegionISOCode = regionISOCode;
            this.City = city;
            this.Zip = zip;
            this.Coords = coords;
            this.IP = iP;
        }
        
        /// <summary>
        /// Gets or Sets CountryISOCode
        /// </summary>
        [DataMember(Name="CountryISOCode", EmitDefaultValue=false)]
        public string CountryISOCode { get; set; }

        /// <summary>
        /// Gets or Sets Country
        /// </summary>
        [DataMember(Name="Country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or Sets RegionISOCode
        /// </summary>
        [DataMember(Name="RegionISOCode", EmitDefaultValue=false)]
        public string RegionISOCode { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        [DataMember(Name="City", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets Zip
        /// </summary>
        [DataMember(Name="Zip", EmitDefaultValue=false)]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or Sets Coords
        /// </summary>
        [DataMember(Name="Coords", EmitDefaultValue=false)]
        public string Coords { get; set; }

        /// <summary>
        /// Gets or Sets IP
        /// </summary>
        [DataMember(Name="IP", EmitDefaultValue=false)]
        public string IP { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20020Geo {\n");
            sb.Append("  CountryISOCode: ").Append(CountryISOCode).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  RegionISOCode: ").Append(RegionISOCode).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  Zip: ").Append(Zip).Append("\n");
            sb.Append("  Coords: ").Append(Coords).Append("\n");
            sb.Append("  IP: ").Append(IP).Append("\n");
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
            return this.Equals(input as InlineResponse20020Geo);
        }

        /// <summary>
        /// Returns true if InlineResponse20020Geo instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20020Geo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20020Geo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CountryISOCode == input.CountryISOCode ||
                    (this.CountryISOCode != null &&
                    this.CountryISOCode.Equals(input.CountryISOCode))
                ) && 
                (
                    this.Country == input.Country ||
                    (this.Country != null &&
                    this.Country.Equals(input.Country))
                ) && 
                (
                    this.RegionISOCode == input.RegionISOCode ||
                    (this.RegionISOCode != null &&
                    this.RegionISOCode.Equals(input.RegionISOCode))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.Zip == input.Zip ||
                    (this.Zip != null &&
                    this.Zip.Equals(input.Zip))
                ) && 
                (
                    this.Coords == input.Coords ||
                    (this.Coords != null &&
                    this.Coords.Equals(input.Coords))
                ) && 
                (
                    this.IP == input.IP ||
                    (this.IP != null &&
                    this.IP.Equals(input.IP))
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
                if (this.CountryISOCode != null)
                    hashCode = hashCode * 59 + this.CountryISOCode.GetHashCode();
                if (this.Country != null)
                    hashCode = hashCode * 59 + this.Country.GetHashCode();
                if (this.RegionISOCode != null)
                    hashCode = hashCode * 59 + this.RegionISOCode.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.Zip != null)
                    hashCode = hashCode * 59 + this.Zip.GetHashCode();
                if (this.Coords != null)
                    hashCode = hashCode * 59 + this.Coords.GetHashCode();
                if (this.IP != null)
                    hashCode = hashCode * 59 + this.IP.GetHashCode();
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