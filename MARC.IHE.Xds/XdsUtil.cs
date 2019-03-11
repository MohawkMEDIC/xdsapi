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
using MARC.IHE.Xds.Registry;
using MARC.IHE.Xds.Repository;
using System;

namespace MARC.IHE.Xds
{
    /// <summary>
    /// Utility class for generating XDS requests.
    /// </summary>
    public static class XdsUtil
    {
        /// <summary>
        /// Create an adhoc query request.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Returns the created adhoc query request.</returns>
        public static AdhocQueryRequest CreateAdhocQueryRequest(XdsGuidType queryId, params SlotType1[] parameters)
        {
            var retVal = new AdhocQueryRequest
            {
                // Set response option
                ResponseOption = new ResponseOptionType()
                {
                    returnComposedObjects = true,
                    returnType = ResponseOptionTypeReturnType.LeafClass
                },

                // Adhoc query
                AdhocQuery = new AdhocQueryType
                {
                    id = queryId.ToString(),

                    // Create the slots
                    Slot = parameters
                }
            };

            return retVal;
        }

        /// <summary>
        /// Creates an association type.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <param name="status">The status.</param>
        /// <param name="relation">The relation.</param>
        /// <returns>Returns the created association type.</returns>
        public static AssociationType1 CreateAssociation(RegistryObjectType source, ExtrinsicObjectType target, string status, string relation)
        {
            var retAssoc = new AssociationType1
            {
                id = $"urn:uuid:{Guid.NewGuid().ToString()}",
                sourceObject = source.id,
                targetObject = target.id,
                Slot = new SlotType1[]
                {
                    CreateSlot("SubmissionSetStatus", status)
                },
                associationType = relation
            };

            return retAssoc;
        }

        /// <summary>
        /// Creates an classification type.
        /// </summary>
        /// <param name="classificationScheme">The classification scheme.</param>
        /// <param name="nodeRepresentation">The node representation.</param>
        /// <param name="name">The name.</param>
        /// <param name="slots">The slots.</param>
        /// <returns>Returns the created classification type.</returns>
        public static ClassificationType CreateClassification(XdsGuidType classificationScheme, string nodeRepresentation, string name, params SlotType1[] slots)
        {
            var retVal = new ClassificationType()
            {
                id = $"urn:uuid:{Guid.NewGuid().ToString()}",
                classificationScheme = classificationScheme.ToString(),
                nodeRepresentation = nodeRepresentation
            };

            if (name != null)
            {
                retVal.Name = new InternationalStringType()
                {
                    LocalizedString = new LocalizedStringType[] {
                        new LocalizedStringType() {
                            value = name
                        }
                    }
                };
            }

            // Slots
            retVal.Slot = slots;

            return retVal;
        }

        /// <summary>
        /// Creates an classification type.
        /// </summary>
        /// <param name="classifiedObject">The classified object.</param>
        /// <param name="scheme">The scheme.</param>
        /// <param name="nodeRepresentation">The node representation.</param>
        /// <param name="name">The name.</param>
        /// <param name="slots">The slots.</param>
        /// <returns>Returns the created classification type.</returns>
        public static ClassificationType CreateClassification(RegistryObjectType classifiedObject, XdsGuidType scheme, string nodeRepresentation, string name, params SlotType1[] slots)
        {
            var retClass = new ClassificationType
            {
                id = $"urn:uuid:{Guid.NewGuid().ToString()}",
                classificationScheme = scheme.ToString(),
                classifiedObject = classifiedObject.id,
                nodeRepresentation = nodeRepresentation,
                Slot = slots
            };

            if (name != null)
            {
                retClass.Name = new InternationalStringType()
                {
                    LocalizedString = new LocalizedStringType[] {
                        new LocalizedStringType() {
                            value = name
                        }
                    }
                };
            }

            return retClass;
        }

        /// <summary>
        /// Creates an external identifier type.
        /// </summary>
        /// <param name="identifierType">Type of the identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        /// <returns>Returns the created external identifier type.</returns>
        public static ExternalIdentifierType CreateExternalIdentifier(XdsGuidType identifierType, string value, string name)
        {
            var retVal = new ExternalIdentifierType()
            {
                id = $"urn:uuid:{Guid.NewGuid().ToString()}",
                identificationScheme = identifierType.ToString(),
                value = value
            };

            if (name != null)
            {
                retVal.Name = new InternationalStringType()
                {
                    LocalizedString = new LocalizedStringType[] {
                        new LocalizedStringType() {
                            value = name
                        }
                    }
                };
            }

            return retVal;
        }

        /// <summary>
        /// Creates an external identifier type.
        /// </summary>
        /// <param name="registryObject">The registry object.</param>
        /// <param name="scheme">The scheme.</param>
        /// <param name="value">The value.</param>
        /// <returns>Returns the created external identifier type.</returns>
        public static ExternalIdentifierType CreateExternalIdentifier(RegistryObjectType registryObject, XdsGuidType scheme, string value)
        {
            var retId = new ExternalIdentifierType
            {
                id = $"urn:uuid:{Guid.NewGuid().ToString()}",
                registryObject = registryObject.id,
                identificationScheme = scheme.ToString(),
                value = value
            };

            if (scheme.Name != null)
            {
                retId.Name = new InternationalStringType()
                {
                    LocalizedString = new LocalizedStringType[] {
                        new LocalizedStringType() {
                            value = scheme.Name
                        }
                    }
                };
            }

            return retId;
        }

        /// <summary>
        /// Creates an extrinsic object type.
        /// </summary>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="name">The name.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="slots">The slots.</param>
        /// <returns>Returns the created extrinsic object type.</returns>
        public static ExtrinsicObjectType CreateExtrinsicObject(string mimeType, string name, XdsGuidType objectType, params SlotType1[] slots)
        {
            return CreateExtrinsicObject(mimeType, name, objectType, slots, null, null);
        }

        /// <summary>
        /// Creates an extrinsic object type.
        /// </summary>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="name">The name.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="slots">The slots.</param>
        /// <param name="classifications">The classifications.</param>
        /// <param name="externalIds">The external ids.</param>
        /// <returns>Returns the created extrinsic object type.</returns>
        public static ExtrinsicObjectType CreateExtrinsicObject(string mimeType, string name, XdsGuidType objectType, SlotType1[] slots, ClassificationType[] classifications, ExternalIdentifierType[] externalIds)
        {
            var retVal = new ExtrinsicObjectType
            {
                id = $"urn:uuid:{Guid.NewGuid().ToString()}",
                objectType = objectType.ToString(),
                mimeType = mimeType
            };

            if (name != null)
            {
                retVal.Name = new InternationalStringType()
                {
                    LocalizedString = new LocalizedStringType[]
                    {
                        new LocalizedStringType() {
                            value = name
                        }
                    }
                };
            }

            // Slots
            retVal.Slot = slots;
            retVal.Classification = classifications;
            retVal.ExternalIdentifier = externalIds;

            if (retVal.Classification != null)
            {
                foreach (var item in retVal.Classification)
                {
                    item.classifiedObject = retVal.id;
                }
            }

            if (retVal.ExternalIdentifier != null)
            {
                foreach (var item in retVal.ExternalIdentifier)
                {
                    item.registryObject = retVal.id;
                }
            }

            return retVal;
        }

        /// <summary>
        /// Creates an node classification type.
        /// </summary>
        /// <param name="registryObject">The registry object.</param>
        /// <param name="classificationNode">The classification node.</param>
        /// <returns>Returns the created node classification type.</returns>
        public static ClassificationType CreateNodeClassification(RegistryObjectType registryObject, XdsGuidType classificationNode)
        {
            var retClass = new ClassificationType
            {
                id = $"urn:uuid:{Guid.NewGuid()}",
                classificationNode = classificationNode.ToString(),
                classifiedObject = registryObject.id
            };

            return retClass;
        }

        /// <summary>
        /// Creates a provide and register request.
        /// </summary>
        /// <param name="registryRequest">The registry request.</param>
        /// <param name="document">The document.</param>
        /// <returns>Returns the created provide and registry document set request type.</returns>
        public static ProvideAndRegisterDocumentSetRequestType CreateProvideAndRegisterRequest(SubmitObjectsRequest registryRequest, params ProvideAndRegisterDocumentSetRequestTypeDocument[] document)
        {
            var retVal = new ProvideAndRegisterDocumentSetRequestType
            {
                SubmitObjectsRequest = registryRequest,
                Document = document
            };

            return retVal;
        }

        /// <summary>
        /// Creates a registry package type.
        /// </summary>
        /// <returns>Returns the created registry package type.</returns>
        public static RegistryPackageType CreateRegistryPackage()
        {
            var retVal = new RegistryPackageType
            {
                id = $"urn:uuid:{Guid.NewGuid().ToString()}"
            };

            return retVal;
        }

        /// <summary>
        /// Creates a retrieve document set request.
        /// </summary>
        /// <param name="repositoryId">The repository identifier.</param>
        /// <param name="homeCommunityId">The home community identifier.</param>
        /// <param name="docIds">The document ids.</param>
        /// <returns>Returns a list of created retrieve document set request type document requests.</returns>
        /// <exception cref="ArgumentNullException">docIds - Value cannot be null</exception>
        public static RetrieveDocumentSetRequestTypeDocumentRequest[] CreateRetrieveDocumentSetRequest(string repositoryId, string homeCommunityId, params string[] docIds)
        {
            if (docIds == null)
            {
                throw new ArgumentNullException(nameof(docIds), "Value cannot be null");
            }

            var retVal = new RetrieveDocumentSetRequestTypeDocumentRequest[docIds.Length];

            var i = 0;

            foreach (var docid in docIds)
            {
                retVal[i++] = new RetrieveDocumentSetRequestTypeDocumentRequest()
                {
                    DocumentUniqueId = docid,
                    HomeCommunityId = homeCommunityId,
                    RepositoryUniqueId = repositoryId
                };
            }

            return retVal;
        }

        /// <summary>
        /// Creates a slot type.
        /// </summary>
        /// <param name="slotName">Name of the slot.</param>
        /// <param name="value">The value.</param>
        /// <returns>Returns the created slot type.</returns>
        public static SlotType1 CreateSlot(string slotName, params string[] value)
        {
            var retSlot = new SlotType1();

            var patientValueList = new ValueListType { Value = value };

            retSlot.name = slotName;
            retSlot.ValueList = patientValueList;

            return retSlot;
        }

        /// <summary>
        /// Creates a submit objects request.
        /// </summary>
        /// <param name="objects">The objects.</param>
        /// <returns>Returns the created submit objects request.</returns>
        public static SubmitObjectsRequest CreateSubmitObjectsRequest(params IdentifiableType[] objects)
        {
            var retVal = new SubmitObjectsRequest
            {
                RegistryObjectList = objects
            };

            return retVal;
        }
    }
}