using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.StatePattern
{
    public interface State
    {

        Dictionary<String, List<String>> GetEmails();
        void SetIsNextTrue();
        void SetIsNextFalse();

    }
        
}
