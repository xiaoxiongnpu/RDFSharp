﻿/*
   Copyright 2012-2020 Marco De Salvo

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using RDFSharp.Model.Vocabularies;

namespace RDFSharp.Model.Validation.Abstractions.Targets
{
    /// <summary>
    /// RDFTargetObjectsOf represents a SHACL target of type "ObjectsOf" within a shape.
    /// </summary>
    public class RDFTargetObjectsOf : RDFTarget {

        #region Ctors
        /// <summary>
        /// Default-ctor to build a named target of type "ObjectsOf" on the given property
        /// </summary>
        public RDFTargetObjectsOf(RDFResource targetName, RDFResource targetProperty) : base(targetName) {
            if (targetProperty != null) {
                this.TargetValue = targetProperty;
            }
            else {
                throw new RDFModelException("Cannot create RDFTargetObjectsOf because given \"targetProperty\" parameter is null.");
            }
        }

        /// <summary>
        /// Default-ctor to build a blank target of type "ObjectsOf" on the given property
        /// </summary>
        public RDFTargetObjectsOf(RDFResource targetProperty) : this(new RDFResource(), targetProperty) { }
        #endregion

        #region Methods
        /// <summary>
        /// Gets a graph representation of this target
        /// </summary>
        public override RDFGraph ToRDFGraph(RDFShape shape) {
            var result = new RDFGraph();

            //sh:targetObjectsOf
            if (shape != null)
                result.AddTriple(new RDFTriple(shape, RDFVocabulary.SHACL.TARGET_OBJECTS_OF, this.TargetValue));

            return result;
        }
        #endregion

    }
}