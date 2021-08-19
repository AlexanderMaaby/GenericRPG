using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    /// <summary>
    /// The exception that is thrown when the Armor attempted to be equipped
    /// is not eligble. Either because of item level or armor type in relation to class.
    /// </summary>
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message) : base(message)
        {
        }
    }
}
