using Fiap.Aula03.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.ViewModels
{
    public class DroneViewModel
    {
        public Drone Drone { get; set; }

        public IList<Drone> Lista { get; set; }
    }
}
