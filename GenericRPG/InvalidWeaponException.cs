using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    /// <summary>
    /// The exception that is thrown when the Weapon attempted to be equipped
    /// is not eligble. Either because of item level or weapon type in relation to class.
    /// </summary>
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message)
        {
        }
    }
}
