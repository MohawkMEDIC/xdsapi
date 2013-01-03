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
    public static class Util
    {

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
        /// Create provide and register type
        /// </summary>
        public static ExtrinsicObjectType CreateExtrinsicObject(String mimeType, String name, XdsGuidType objectType, params SlotType1[] slots)
        {

            ExtrinsicObjectType retVal = new ExtrinsicObjectType();
            retVal.id = String.Format("urn:uuid:%s", Guid.NewGuid().ToString());
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

            return retVal;

        }

        /// <summary>
        /// Create registry package
        /// </summary>
        public static RegistryPackageType CreateRegistryPackage()
        {
            RegistryPackageType retVal = new RegistryPackageType();
            retVal.id = String.Format("urn:uuid:%s", Guid.NewGuid().ToString());
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
        private static AssociationType1 CreateAssociation(RegistryObjectType source,
            ExtrinsicObjectType target, String status)
        {
            AssociationType1 retAssoc = new AssociationType1();
            retAssoc.id = String.Format("urn:uuid:%s", Guid.NewGuid().ToString());
            retAssoc.sourceObject = source.id;
            retAssoc.targetObject = target.id;
            retAssoc.Slot = new SlotType1[] {
                CreateSlot("SubmissionSetStatus", status)
            };
            return retAssoc;
        }

        /// <summary>
        /// Create classification
        /// </summary>
        private static ClassificationType CreateClassification(RegistryObjectType classifiedObject, XdsGuidType scheme, String nodeRepresentation, String name, params SlotType1[] slots)
        {

            ClassificationType retClass = new ClassificationType();
            retClass.id = String.Format("urn:uuid:%s", Guid.NewGuid().ToString());
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
        private static ClassificationType CreateNodeClassification(RegistryObjectType registryObject, XdsGuidType classificationNode)
        {
            ClassificationType retClass = new ClassificationType();
            retClass.id = String.Format("urn:uuid:%s", Guid.NewGuid());
            retClass.classificationNode = classificationNode.ToString();
            retClass.classifiedObject = registryObject.id;
            return retClass;
        }

        /// <summary>
        /// Create an external identifier
        /// </summary>
        private static ExternalIdentifierType CreateExternalIdentifier(RegistryObjectType registryObject, XdsGuidType scheme, String value)
        {

            ExternalIdentifierType retId = new ExternalIdentifierType();
            retId.id = String.Format("urn:uuid:%s", Guid.NewGuid().ToString());

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
