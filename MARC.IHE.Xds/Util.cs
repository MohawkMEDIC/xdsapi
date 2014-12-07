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
using MARC.IHE.Xds.Repository;
using MARC.IHE.Xds.Registry;

namespace MARC.IHE.Xds
{
    /// <summary>
    /// Utility class for generating XDS requests
    /// </summary>
    public static class XdsUtil
    {


        /// <summary>
        /// Creates a retrieve document set request
        /// </summary>
        public static RetrieveDocumentSetRequestTypeDocumentRequest[] CreateRetrieveDocumentSetRequest(String repositoryId, String homeCommunityId, params String[] docIds)
        {
            if (docIds == null)
                throw new ArgumentNullException("docIds");

            var retVal = new RetrieveDocumentSetRequestTypeDocumentRequest[docIds.Length];

            int i = 0;
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
        /// Create an adhoc query request
        /// </summary>
        public static AdhocQueryRequest CreateAdhocQueryRequest(XdsGuidType queryId, params SlotType1[] parameters)
        {
            AdhocQueryRequest retVal = new AdhocQueryRequest();
            // Set response option
            retVal.ResponseOption = new ResponseOptionType()
            {
                returnComposedObjects = true,
                returnType = ResponseOptionTypeReturnType.LeafClass
            };

            // Adhoc query
            retVal.AdhocQuery = new AdhocQueryType()
            {
                id = queryId.ToString()
            };

            // Create the slots
            retVal.AdhocQuery.Slot = parameters;

            return retVal;
        }

        /// <summary>
        /// Create Submit objects request
        /// </summary>
        public static SubmitObjectsRequest CreateSubmitObjectsRequest(
            params IdentifiableType[] objects
        )
        {
            
            SubmitObjectsRequest retVal = new SubmitObjectsRequest();
            retVal.RegistryObjectList = objects;
            
            return retVal;
        }

        /// <summary>
        /// Create provide and register document set
        /// </summary>
        /// <returns></returns>
        public static ProvideAndRegisterDocumentSetRequestType CreateProvideAndRegisterRequest(
            SubmitObjectsRequest registryRequest,
            params ProvideAndRegisterDocumentSetRequestTypeDocument[] document
            )
        {
            ProvideAndRegisterDocumentSetRequestType retVal = new ProvideAndRegisterDocumentSetRequestType();
            retVal.SubmitObjectsRequest = registryRequest;
            retVal.Document = document;
            return retVal;
        }

        /// <summary>
        /// Create an extrinsic object
        /// </summary>
        public static ExtrinsicObjectType CreateExtrinsicObject(String mimeType, String name, XdsGuidType objectType, params SlotType1[] slots)
        {
            return CreateExtrinsicObject(mimeType, name, objectType, slots, null, null);
        }

        /// <summary>
        /// Create provide and register type
        /// </summary>
        public static ExtrinsicObjectType CreateExtrinsicObject(String mimeType, String name, XdsGuidType objectType, SlotType1[] slots, ClassificationType[] classifications, ExternalIdentifierType[] externalIds)
        {

            ExtrinsicObjectType retVal = new ExtrinsicObjectType();
            retVal.id = String.Format("urn:uuid:{0}", Guid.NewGuid().ToString());
            retVal.objectType = objectType.ToString();
            retVal.mimeType = mimeType;
            retVal.Name = new InternationalStringType()
            {
                LocalizedString = new LocalizedStringType[]
                {
                    new LocalizedStringType() {
                        value = name
                    }
                }
            };

            // Slots
            retVal.Slot = slots;
            retVal.Classification = classifications;
            retVal.ExternalIdentifier = externalIds;

            if(retVal.Classification != null)
                foreach(var itm in retVal.Classification)
                    itm.classifiedObject = retVal.id;

            if(retVal.ExternalIdentifier != null)
                foreach(var itm in retVal.ExternalIdentifier)
                    itm.registryObject = retVal.id;

            return retVal;

        }

        /// <summary>
        /// Classiication
        /// </summary>
        /// <param name="classificationScheme"></param>
        /// <returns></returns>
        public static ClassificationType CreateClassification(XdsGuidType classificationScheme, String nodeRepresentation, String name, params SlotType1[] slots)
        {
            ClassificationType retVal = new ClassificationType()
            {
                id = String.Format("urn:uuid:{0}", Guid.NewGuid().ToString()),
                classificationScheme = classificationScheme.ToString(),
                nodeRepresentation = nodeRepresentation
            };

            retVal.Name = new InternationalStringType()
            {
                LocalizedString = new LocalizedStringType[] {
                    new LocalizedStringType() {
                        value = name
                    }
                }
            };
            
            // Slots
            retVal.Slot = slots;

            return retVal;
        }


        /// <summary>
        /// Create an external identifier type
        /// </summary>
        public static ExternalIdentifierType CreateExternalIdentifier(XdsGuidType identifierType, String value, String name)
        {
            ExternalIdentifierType retVal = new ExternalIdentifierType()
            {
                id = String.Format("urn:uuid:{0}", Guid.NewGuid().ToString()),
                identificationScheme = identifierType.ToString(),
                value = value
            };

            retVal.Name = new InternationalStringType()
            {
                LocalizedString = new LocalizedStringType[] {
                    new LocalizedStringType() {
                        value = name
                    }
                }
            };

            return retVal;
        }

        /// <summary>
        /// Create registry package
        /// </summary>
        public static RegistryPackageType CreateRegistryPackage()
        {
            RegistryPackageType retVal = new RegistryPackageType();
            retVal.id = String.Format("urn:uuid:{0}", Guid.NewGuid().ToString());
            return retVal;
        }

        /// <summary>
        /// Create slot
        /// </summary>
        public static SlotType1 CreateSlot(String slotName, params String[] value)
        {
            SlotType1 retSlot = new SlotType1();
            ValueListType patientValueList = new ValueListType();
            patientValueList.Value = value;
            retSlot.name = slotName;
            retSlot.ValueList = patientValueList;
            return retSlot;
        }

        /// <summary>
        /// Create association
        /// </summary>
        public static AssociationType1 CreateAssociation(RegistryObjectType source,
            ExtrinsicObjectType target, String status, String relation)
        {
            AssociationType1 retAssoc = new AssociationType1();
            retAssoc.id = String.Format("urn:uuid:{0}", Guid.NewGuid().ToString());
            retAssoc.sourceObject = source.id;
            retAssoc.targetObject = target.id;
            retAssoc.Slot = new SlotType1[] {
                CreateSlot("SubmissionSetStatus", status)
            };
            retAssoc.associationType = relation;
            return retAssoc;
        }

        /// <summary>
        /// Create classification
        /// </summary>
        public static ClassificationType CreateClassification(RegistryObjectType classifiedObject, XdsGuidType scheme, String nodeRepresentation, String name, params SlotType1[] slots)
        {

            ClassificationType retClass = new ClassificationType();
            retClass.id = String.Format("urn:uuid:{0}", Guid.NewGuid().ToString());
            retClass.classificationScheme = scheme.ToString();
            retClass.classifiedObject = classifiedObject.id;
            retClass.nodeRepresentation = nodeRepresentation;
            retClass.Slot = slots;

            retClass.Name = new InternationalStringType()
            {
                LocalizedString = new LocalizedStringType[] {
                    new LocalizedStringType() {
                        value = name
                    }
                }
            };

            return retClass;
        }

       
        /// <summary>
        /// Create node classification
        /// </summary>
        public static ClassificationType CreateNodeClassification(RegistryObjectType registryObject, XdsGuidType classificationNode)
        {
            ClassificationType retClass = new ClassificationType();
            retClass.id = String.Format("urn:uuid:{0}", Guid.NewGuid());
            retClass.classificationNode = classificationNode.ToString();
            retClass.classifiedObject = registryObject.id;
            return retClass;
        }

        
        /// <summary>
        /// Create an external identifier
        /// </summary>
        public static ExternalIdentifierType CreateExternalIdentifier(RegistryObjectType registryObject, XdsGuidType scheme, String value)
        {

            ExternalIdentifierType retId = new ExternalIdentifierType();
            retId.id = String.Format("urn:uuid:{0}", Guid.NewGuid().ToString());

            retId.registryObject= registryObject.id;
            retId.identificationScheme = scheme.ToString();
            retId.value = value;
            retId.Name = new InternationalStringType()
            {
                LocalizedString = new LocalizedStringType[] {
                    new LocalizedStringType() {
                        value = scheme.Name
                    }
                }
            };

            return retId;
        }
    }
}
