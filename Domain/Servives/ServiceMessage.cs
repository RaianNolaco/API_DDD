using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;

namespace Domain.Servives
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _IMessage;

        public ServiceMessage(IMessage iMessage)
        {
            _IMessage = iMessage;
        }


    }
}
