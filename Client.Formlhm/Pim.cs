using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Formlhm
{
    public enum PimState
    {
        Deconnecter,
        AttenteBagage,
        SelectionBagage,
        CreationBagage,
        AffichageBagage
    }

    public delegate void PimStateEventHandler(object sender, PimState state);
}
