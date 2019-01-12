
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RPSS.Trade.Bittrex.Client.Hubs
{
    public class TradeHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
