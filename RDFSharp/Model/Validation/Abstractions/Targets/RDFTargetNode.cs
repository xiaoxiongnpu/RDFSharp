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
    /// RDFTargetNode represents a SHACL target of type "Node" within a shape.
    /// </summary>
    public class RDFTargetNode : RDFTarget {

        #region Ctors
        /// <summary>
        /// Default-ctor to build a named target of type "Node" on the given resource
        /// </summary>
        public RDFTargetNode(RDFResource targetName, RDFResource targetNode) : base(targetName) {
            if (targetNode != null) {
                this.TargetValue = targetNode;
            }
            else {
                throw new RDFModelException("Cannot create RDFTargetNode because given \"targetNode\" parameter is null.");
            }
        }

        /// <summary>
        /// Default-ctor to build a blank target of type "Node" on the given resource
        /// </summary>
        public RDFTargetNode(RDFResource targetNode) : this(new RDFResource(), targetNode) { }
        #endregion

        #region Methods
        /// <summary>
        /// Gets a graph representation of this target
        /// </summary>
        public override RDFGraph ToRDFGraph(RDFShape shape) {
            var result = new RDFGraph();

            //sh:targetNode
            if (shape != null)
                result.AddTriple(new RDFTriple(shape, RDFVocabulary.SHACL.TARGET_NODE, this.TargetValue));

            return result;
        }
        #endregion

    }
}