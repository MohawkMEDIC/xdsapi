/* 
 * Copyright 2012 Mohawk College of Applied Arts and Technology
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
 * User: Justin Fyfe
 * Date: 11-26-2012
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MARC.IHE.Xds
{
    /// <summary>
    /// XDS Confidentiality codes
    /// </summary>
    public class XdsConfidentialityCodeType
    {

        /// <summary>
        /// Document is submitted
        /// </summary>
        public static readonly XdsConfidentialityCodeType Normal = new XdsConfidentialityCodeType("1.3.6.1.4.1.21367.2006.7.107", "Connect-a-thon confidentialityCodes");
        /// <summary>
        /// Document has been approved for sharing
        /// </summary>
        public static readonly XdsConfidentialityCodeType Restricted = new XdsConfidentialityCodeType("1.3.6.1.4.1.21367.2006.7.109", "Connect-a-thon confidentialityCodes");
        /// <summary>
        /// Document entry that is deprecated
        /// </summary>
        public static readonly XdsConfidentialityCodeType EmergencyOnly = new XdsConfidentialityCodeType("1.3.6.1.4.1.21367.2006.7.110", "Connect-a-thon confidentialityCodes");

        private readonly String m_code;
        private readonly String m_scheme;

        /// <summary>
        /// Create a status type
        /// @param code
        /// </summary>
        private XdsConfidentialityCodeType(String code, String scheme)
        {
            this.m_code = code;
            this.m_scheme = scheme;
        }

        /// <summary>
        /// Get the code for the XDS document entry
        /// @return
        /// </summary>
        public String Scheme
        {
            get
            {
                return this.m_scheme;
            }
        }

        /// <summary>
        /// Get the code for the XDS document entry
        /// @return
        /// </summary>
        public String Code
        {
            get
            {
                return this.m_code;
            }
        }
    }
}
