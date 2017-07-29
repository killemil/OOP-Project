using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IOperationalSystem 
    {
        string Type { get; }

        string Manufacturer { get; }
    }
}
