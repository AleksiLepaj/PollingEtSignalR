using System;
using System.Threading.Tasks;
using labo.signalr.api.Data;
using labo.signalr.api.Models;
using Microsoft.AspNetCore.SignalR;

namespace labo.signalr.api.Hub
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    public class TaskHub : Hub
    {
        ApplicationDbContext _context;

        public TaskHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
        }
    }
}
