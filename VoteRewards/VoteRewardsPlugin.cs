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
            if (config["voterewards:unturnedSlApiKey"] != "insert key")
                voting.AddUnturnedSl(config["voterewards:unturnedSlApiKey"]);
            if (config["voterewards:unturnedServersApiKey"] != "insert key")
                voting.AddUnturnedServersNet(config["voterewards:unturnedServersApiKey"]);
        }
    }
}