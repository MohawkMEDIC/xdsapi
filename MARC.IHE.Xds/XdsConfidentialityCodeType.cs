/*
 * Copyright 2008-2019 Mohawk College of Applied Arts and Technology
 * 
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: khannan
 * Date: 2019-3-11
 */
using System;

namespace MARC.IHE.Xds
{
    /// <summary>
    /// Represents a collection of XDS Confidentiality codes.
    /// </summary>
    public class XdsConfidentialityCodeType
    {
        /// <summary>
        /// Represents a document entry that is deprecated.
        /// </summary>
        public static readonly XdsConfidentialityCodeType EmergencyOnly = new XdsConfidentialityCodeType("1.3.6.1.4.1.21367.2006.7.110", "Connect-a-thon confidentialityCodes");

        /// <summary>
        /// Represents a document is submitted.
        /// </summary>
        public static readonly XdsConfidentialityCodeType Normal = new XdsConfidentialityCodeType("1.3.6.1.4.1.21367.2006.7.107", "Connect-a-thon confidentialityCodes");

        /// <summary>
        /// Represents a document has been approved for sharing.
        /// </summary>
        public static readonly XdsConfidentialityCodeType Restricted = new XdsConfidentialityCodeType("1.3.6.1.4.1.21367.2006.7.109", "Connect-a-thon confidentialityCodes");

		/// <summary>
		/// Initializes a new instance of the <see cref="XdsConfidentialityCodeType"/> class.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="scheme">The scheme.</param>
		private XdsConfidentialityCodeType(string code, string scheme)
		{
			this.Code = code;
			this.Scheme = scheme;
		}

		/// <summary>
		/// Get the code for the XDS document entry.
		/// </summary>
		/// <value>The code.</value>
		public string Code { get; }

		/// <summary>
		/// Get the scheme for the XDS document entry.
		/// </summary>
		/// <value>The scheme.</value>
		public string Scheme { get; }
	}
}