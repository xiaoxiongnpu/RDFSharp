﻿/*
   Copyright 2015-2020 Marco De Salvo

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

using RDFSharp.Model;
using System;

namespace RDFSharp.Semantics.OWL
{

    /// <summary>
    /// RDFOntologyObjectProperty represents an object property definition within an ontology model.
    /// </summary>
    public class RDFOntologyObjectProperty: RDFOntologyProperty {

        #region Properties
        /// <summary>
        /// Flag indicating that the ontology property is "owl:SymmetricProperty"
        /// </summary>
        public Boolean Symmetric { get; internal set; }

        /// <summary>
        /// Flag indicating that the ontology property is "owl:TransitiveProperty"
        /// </summary>
        public Boolean Transitive { get; internal set; }

        /// <summary>
        /// Flag indicating that the ontology property is "owl:InverseFunctionalProperty"
        /// </summary>
        public Boolean InverseFunctional { get; internal set; }

        /// <summary>
        /// Flag indicating that the ontology property is "owl:AsymmetricProperty" [OWL2]
        /// </summary>
        public Boolean Asymmetric { get; internal set; }

        /// <summary>
        /// Flag indicating that the ontology property is "owl:ReflexiveProperty" [OWL2]
        /// </summary>
        public Boolean Reflexive { get; internal set; }

        /// <summary>
        /// Flag indicating that the ontology property is "owl:IrreflexiveProperty" [OWL2]
        /// </summary>
        public Boolean Irreflexive { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to build an ontology object property from the given non-blank resource
        /// </summary>
        public RDFOntologyObjectProperty(RDFResource propertyName): base(propertyName) { }
        #endregion

        #region Methods
        /// <summary>
        /// Sets or unsets this ontology object property as "owl:SymmetricProperty"
        /// </summary>
        public RDFOntologyObjectProperty SetSymmetric(Boolean symmetric) {
            this.Symmetric = symmetric;
            if (symmetric)
                this.Asymmetric = false; //Automatically switch-off eventual asymmetry
            return this;
        }

        /// <summary>
        /// Sets or unsets this ontology object property as "owl:ReflexiveProperty" [OWL2]
        /// </summary>
        public RDFOntologyObjectProperty SetReflexive(Boolean reflexive) {
            this.Reflexive = reflexive;
            if (reflexive)
                this.Irreflexive = false; //Automatically switch-off eventual irreflexivity
            return this;
        }

        /// <summary>
        /// Sets or unsets this ontology object property as "owl:IrreflexiveProperty"
        /// </summary>
        public RDFOntologyObjectProperty SetIrreflexive(Boolean irreflexive) {
            this.Irreflexive = irreflexive;
            if (irreflexive)
                this.Reflexive = false; //Automatically switch-off eventual reflexivity
            return this;
        }

        /// <summary>
        /// Sets or unsets this ontology object property as "owl:AsymmetricProperty" [OWL2]
        /// </summary>
        public RDFOntologyObjectProperty SetAsymmetric(Boolean asymmetric)
        {
            this.Asymmetric = asymmetric;
            if (asymmetric)
                this.Symmetric = false; //Automatically switch-off eventual symmetry
            return this;
        }

        /// <summary>
        /// Sets or unsets this ontology object property as "owl:TransitiveProperty"
        /// </summary>
        public RDFOntologyObjectProperty SetTransitive(Boolean transitive) {
            this.Transitive = transitive;
            return this;
        }

        /// <summary>
        /// Sets or unsets this ontology object property as "owl:InverseFunctionalProperty"
        /// </summary>
        public RDFOntologyObjectProperty SetInverseFunctional(Boolean inverseFunctional) {
            this.InverseFunctional = inverseFunctional;
            return this;
        }
        #endregion

    }

}