using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriboEstudio.Services
{
    internal class Conectividade
    {
        public static bool VerificaConectividade()
        {
            bool HasConectivity = false;
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                HasConectivity = true;
            }

            return HasConectivity;
        }
    }
}
