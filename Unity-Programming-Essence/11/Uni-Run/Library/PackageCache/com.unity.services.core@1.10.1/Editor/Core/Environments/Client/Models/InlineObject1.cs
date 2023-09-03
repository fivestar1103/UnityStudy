//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Core.Environments.Client.Http;



namespace Unity.Services.Core.Environments.Client.Models
{
    /// <summary>
    /// InlineObject1 model
    /// </summary>
    [Preserve]
    [DataContract(Name = "inline_object_1")]
    internal class InlineObject1
    {
        /// <summary>
        /// Creates an instance of InlineObject1.
        /// </summary>
        /// <param name="name">Name of the project</param>
        /// <param name="iconUrl">URL for the project icon</param>
        [Preserve]
        public InlineObject1(string name = default, string iconUrl = default)
        {
            Name = name;
            IconUrl = iconUrl;
        }

        /// <summary>
        /// Name of the project
        /// </summary>
        [Preserve]
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name{ get; }
        
        /// <summary>
        /// URL for the project icon
        /// </summary>
        [Preserve]
        [DataMember(Name = "iconUrl", EmitDefaultValue = false)]
        public string IconUrl{ get; }
    
        /// <summary>
        /// Formats a InlineObject1 into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Name != null)
            {
                serializedModel += "name," + Name + ",";
            }
            if (IconUrl != null)
            {
                serializedModel += "iconUrl," + IconUrl;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a InlineObject1 as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Name != null)
            {
                var nameStringValue = Name.ToString();
                dictionary.Add("name", nameStringValue);
            }
            
            if (IconUrl != null)
            {
                var iconUrlStringValue = IconUrl.ToString();
                dictionary.Add("iconUrl", iconUrlStringValue);
            }
            
            return dictionary;
        }
    }
}