using Microsoft.Graph.Communications.Calls;
using System.Threading.Tasks;

namespace Garry_Net.Interfaces
{
    public interface ICallHandler
    {
        Task OnIncomingCallAsync(ICall incomingCall);
    }
}
