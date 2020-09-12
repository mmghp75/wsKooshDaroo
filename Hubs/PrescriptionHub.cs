using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using wsKooshDaroo.Data;
using wsKooshDaroo.Models;

namespace wsKooshDaroo.Hubs
{
    public class PrescriptionHub:Hub
    {
        private KooshDarooContext _context;

        //[Route("Hubs/TestHub")]
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("New Message", message);
        }

        //[Route("Hubs/SendPrescribeToPharmacy")]
        public async Task SendPrescribeToPharmacy(double X, double Y, DateTime dateOf, int Id)
        {
            await Clients.All.SendAsync("SendPrescribeToPharmacy", X, Y, dateOf, Id);
        }
        public async Task SendAcceptToMember(int prescribeResourceId, int prescribeId)
        {
            await Clients.All.SendAsync("SendAcceptToMember", prescribeResourceId, prescribeId);
        }
        public async Task SendAcceptToPharmacy(int prescribeResourceId)
        {
            await Clients.All.SendAsync("SendAcceptToPharmacy", prescribeResourceId);
        }
        public async Task MemberTakesDrugs(int prescribeResourceId)
        {
            await Clients.All.SendAsync("MemberTakesDrugs", prescribeResourceId);
        }

    }
}   