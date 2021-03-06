// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-30-2016
//
// Last Modified By : RFTD
// Last Modified On : 04-30-2016
// ***********************************************************************
// <copyright file="CFeDetCollection.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2016 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Collection;
using System.Collections.Generic;

namespace ACBr.Net.Sat
{
    /// <summary>
    /// Class CFeDetCollection. This class cannot be inherited.
    /// </summary>
    /// <seealso>
    ///     <cref>ACBr.Net.DFe.Core.Collection.DFeCollection{ACBr.Net.Sat.CFeDet}</cref>
    /// </seealso>
    public sealed class CFeDetCollection : DFeCollection<CFeDet>
    {
        #region Fields

        private CFe parent;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CFeDetCollection"/> class.
        /// </summary>
        public CFeDetCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CFeDetCollection"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public CFeDetCollection(CFe parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CFeDetCollection"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public CFeDetCollection(IList<CFeDet> source)
        {
            AddRange(source);
        }

        #endregion Constructors

        #region Propriedades

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        [DFeIgnore]
        internal CFe Parent
        {
            get { return parent; }
            set
            {
                parent = value;
                foreach (var cFeDet in this)
                    cFeDet.Parent = value;
            }
        }

        #endregion Propriedades

        #region Methods

        /// <inheritdoc />
        public override CFeDet AddNew()
        {
            var ret = new CFeDet(Parent);
            base.Add(ret);
            return ret;
        }

        /// <inheritdoc />
        public override void Add(CFeDet item)
        {
            item.Parent = Parent;
            base.Add(item);
        }

        /// <inheritdoc />
        public override void Insert(int index, CFeDet item)
        {
            item.Parent = Parent;
            base.Insert(index, item);
        }

        /// <inheritdoc />
        public override void InsertRange(int index, IEnumerable<CFeDet> collection)
        {
            foreach (var item in collection)
            {
                item.Parent = Parent;
            }

            base.InsertRange(index, collection);
        }

        #endregion Methods
    }
}