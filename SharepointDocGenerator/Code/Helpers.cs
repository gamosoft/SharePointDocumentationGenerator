using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;

namespace SharepointDocGenerator.Code
{
    /// <summary>
    /// Comparer class for SPField
    /// </summary>
    public class SPFieldGroupComparer : IEqualityComparer<SPField>
    {
        #region "Methods"

        /// <summary>
        /// Returns if two SPField objects are equal or not, based on the group
        /// </summary>
        /// <param name="x">First object to compare</param>
        /// <param name="y">Second object to compare</param>
        /// <returns>True or false</returns>
        public bool Equals(SPField x, SPField y)
        {
            return x.Group == y.Group;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <param name="obj">SPField</param>
        /// <returns>Hash code</returns>
        public int GetHashCode(SPField obj)
        {
            return obj.Group.GetHashCode();
        }

        #endregion "Methods"
    }

    /// <summary>
    /// Comparer class for SPContentType
    /// </summary>
    public class SPContentTypeGroupComparer : IEqualityComparer<SPContentType>
    {
        #region "Methods"

        /// <summary>
        /// Returns if two SPContentType objects are equal or not, based on the group
        /// </summary>
        /// <param name="x">First object to compare</param>
        /// <param name="y">Second object to compare</param>
        /// <returns>True or false</returns>
        public bool Equals(SPContentType x, SPContentType y)
        {
            return x.Group == y.Group;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <param name="obj">SPContentType</param>
        /// <returns>Hash code</returns>
        public int GetHashCode(SPContentType obj)
        {
            return obj.Group.GetHashCode();
        }

        #endregion "Methods"
    }
}