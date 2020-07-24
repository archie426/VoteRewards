using System;
using Microsoft.Extensions.Configuration;
using OpenMod.Unturned.Plugins;
using VoteRewards.API;

namespace VoteRewards
{
    public class VoteRewardsPlugin : OpenModUnturnedPlugin
    {
        public VoteRewardsPlugin(IServiceProvider serviceProvider, IUnturnedVotingClient voting, IConfiguration config) : base(serviceProvider)
        {
            if (config.GetValue<string>("voterewards:unturnedSlApiKey") != "insert key")
                voting.AddUnturnedSl(config.GetValue<string>("voterewards:unturnedSlApiKey"));
            if (config.GetValue<string>("voterewards:unturnedServersApiKey") != "insert key")
                voting.AddUnturnedServersNet(config.GetValue<string>("voterewards:unturnedServersApiKey"));
        }
    }
}