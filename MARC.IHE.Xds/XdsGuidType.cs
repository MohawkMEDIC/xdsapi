﻿/*
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
    /// XDS Guid Type
    /// </summary>
    public class XdsGuidType
    {
        /// <summary>
        /// XDS Find documents query.
        /// </summary>
        public static readonly XdsGuidType RegistryStoredQuery_FindDocuments = new XdsGuidType("14d4debf-8f97-4251-9a74-a90016b0af0d");

        /// <summary>
        /// XDS Find submission sets query.
        /// </summary>
        public static readonly XdsGuidType RegistryStoredQuery_FindSubmissionSets = new XdsGuidType("f26abbcb-ac74-4422-8a30-edb644bbc1a9");

        /// <summary>
        /// XDS Get All query.
        /// </summary>
        public static readonly XdsGuidType RegistryStoredQuery_GetAll = new XdsGuidType("10b545ea-725c-446d-9b95-8aeb444eddf3");

        /// <summary>
        /// XDS document entry type.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry = new XdsGuidType("7edca82f-054d-47f2-a032-9b2a5b5186c1");

        /// <summary>
        /// XDS Document author.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_Author = new XdsGuidType("93606bcf-9494-43ec-9b4e-a7748d1a838d");

        /// <summary>
        /// XDS document entry class code.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_ClassCode = new XdsGuidType("41a5887f-8865-4c09-adf7-e362475b143a");

        /// <summary>
        /// XDS document confidentiality code.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_ConfidentialityCode = new XdsGuidType("f4f85eac-e6cb-4883-b524-f2705394840f");

        /// <summary>
        /// XDS document entry event code list.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_EventCodeList = new XdsGuidType("2c6b8cb7-8b2a-4051-b291-b1ae6a575ef4");

        /// <summary>
        /// XDS document entry format code.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_FormatCode = new XdsGuidType("a09d5840-386c-46f2-b5ad-9c3699a4309d");

        /// <summary>
        /// The XDS document entry health care facility type code.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_HealthCareFacilityTypeCode = new XdsGuidType("f33fb8ac-18af-42cc-ae0e-ed0b0bdb91e1");

        /// <summary>
        /// XDS limited meta data classification.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_LimitedMetaData = new XdsGuidType("ab9b591b-83ab-4d03-8f5d-f93b1fb92e85");

        /// <summary>
        /// XDS document entry patient id.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_PatientId = new XdsGuidType("58a6f841-87b3-4a3e-92fd-a8ffeff98427", "XDSDocumentEntry.patientId");

        /// <summary>
        /// XDS document entry practice setting.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_PracticeSettingCode = new XdsGuidType("cccf5598-8b07-4b77-a05e-ae952c785ead");

        /// <summary>
        /// XDS document entry type code.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_TypeCode = new XdsGuidType("f0306f51-975f-434e-a61c-c59651d33983");

        /// <summary>
        /// XDS document entry unique identifier.
        /// </summary>
        public static readonly XdsGuidType XDSDocumentEntry_UniqueId = new XdsGuidType("2e82c1f6-a085-4c72-9da3-8640a32e42ab", "XDSDocumentEntry.uniqueId");

        /// <summary>
        /// Submission set classification id.
        /// </summary>
        public static readonly XdsGuidType XDSSubmissionSet = new XdsGuidType("a54d6aa5-d40d-43f9-88c5-b4633d873bdd");

        /// <summary>
        /// Submission set author classification id.
        /// </summary>
        public static readonly XdsGuidType XDSSubmissionSet_Author = new XdsGuidType("a7058bb9-b4e4-4307-ba5b-e3f0ab85e12d");

        /// <summary>
        /// Submission set content/type.
        /// </summary>
        public static readonly XdsGuidType XDSSubmissionSet_ContentType = new XdsGuidType("aa543740-bdda-424e-8c96-df4873be8500");

        /// <summary>
        /// Limited meta data classification node.
        /// </summary>
        public static readonly XdsGuidType XDSSubmissionSet_LimitedMetaData = new XdsGuidType("5003a9db-8d8d-49e6-bf0c-990e34ac7707");

        /// <summary>
        /// Submission set patient id.
        /// </summary>
        public static readonly XdsGuidType XDSSubmissionSet_PatientId = new XdsGuidType("6b5aea1a-874d-4603-a4bc-96a0a7b38446", "XDSSubmissionSet.patientId");

        /// <summary>
        /// Submission set source id.
        /// </summary>
        public static readonly XdsGuidType XDSSubmissionSet_SourceId = new XdsGuidType("554ac39e-e3fe-47fe-b233-965d2a147832", "XDSSubmissionSet.sourceId");

        /// <summary>
        /// Submission set unique id.
        /// </summary>
        public static readonly XdsGuidType XDSSubmissionSet_UniqueId = new XdsGuidType("96fdda7c-d067-4183-912e-bf5ee74998a8", "XDSSubmissionSet.uniqueId");

        /// <summary>
        /// Initializes a new instance of the <see cref="XdsGuidType"/> class.
        /// </summary>
        /// <param name="queryGuid">The query unique identifier.</param>
        public XdsGuidType(string queryGuid) : this(queryGuid, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XdsGuidType"/> class.
        /// </summary>
        /// <param name="queryGuid">The query unique identifier.</param>
        /// <param name="name">The name.</param>
        public XdsGuidType(string queryGuid, string name)
        {
            this.Guid = queryGuid;
            this.Name = name;
        }

        /// <summary>
        /// Gets the query specification GUID.
        /// </summary>
        /// <value>The unique identifier.</value>
        public string Guid { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {
            if (obj is String)
                return this.ToString().Equals(obj.ToString());
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns the current query GUID.
        /// </summary>
        /// <returns>Returns the current query GUID.</returns>
        public override String ToString()
        {
            return $"urn:uuid:{this.Guid}";
        }
    }
}