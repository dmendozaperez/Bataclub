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
    /// InlineResponse20014Details
    /// </summary>
    [DataContract]
    public partial class InlineResponse20014Details :  IEquatable<InlineResponse20014Details>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse20014Details" /> class.
        /// </summary>
        /// <param name="deliveryMessage">deliveryMessage.</param>
        /// <param name="destinationServer">destinationServer.</param>
        /// <param name="destinationIP">destinationIP.</param>
        public InlineResponse20014Details(string deliveryMessage = default(string), string destinationServer = default(string), string destinationIP = default(string))
        {
            this.DeliveryMessage = deliveryMessage;
            this.DestinationServer = destinationServer;
            this.DestinationIP = destinationIP;
        }
        
        /// <summary>
        /// Gets or Sets DeliveryMessage
        /// </summary>
        [DataMember(Name="DeliveryMessage", EmitDefaultValue=false)]
        public string DeliveryMessage { get; set; }

        /// <summary>
        /// Gets or Sets DestinationServer
        /// </summary>
        [DataMember(Name="DestinationServer", EmitDefaultValue=false)]
        public string DestinationServer { get; set; }

        /// <summary>
        /// Gets or Sets DestinationIP
        /// </summary>
        [DataMember(Name="DestinationIP", EmitDefaultValue=false)]
        public string DestinationIP { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20014Details {\n");
            sb.Append("  DeliveryMessage: ").Append(DeliveryMessage).Append("\n");
            sb.Append("  DestinationServer: ").Append(DestinationServer).Append("\n");
            sb.Append("  DestinationIP: ").Append(DestinationIP).Append("\n");
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
            return this.Equals(input as InlineResponse20014Details);
        }

        /// <summary>
        /// Returns true if InlineResponse20014Details instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse20014Details to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20014Details input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DeliveryMessage == input.DeliveryMessage ||
                    (this.DeliveryMessage != null &&
                    this.DeliveryMessage.Equals(input.DeliveryMessage))
                ) && 
                (
                    this.DestinationServer == input.DestinationServer ||
                    (this.DestinationServer != null &&
                    this.DestinationServer.Equals(input.DestinationServer))
                ) && 
                (
                    this.DestinationIP == input.DestinationIP ||
                    (this.DestinationIP != null &&
                    this.DestinationIP.Equals(input.DestinationIP))
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
                if (this.DeliveryMessage != null)
                    hashCode = hashCode * 59 + this.DeliveryMessage.GetHashCode();
                if (this.DestinationServer != null)
                    hashCode = hashCode * 59 + this.DestinationServer.GetHashCode();
                if (this.DestinationIP != null)
                    hashCode = hashCode * 59 + this.DestinationIP.GetHashCode();
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
