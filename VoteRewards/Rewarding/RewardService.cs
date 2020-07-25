using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenMod.API.Ioc;
using OpenMod.API.Permissions;
using OpenMod.API.Users;
using VoteRewards.Serialization;

namespace VoteRewards.Rewarding
{
    [PluginServiceImplementation]
    public class RewardService : IRewardService
    {

        private IConfiguration _config;
        private List<Reward> _rewards;

        public RewardService(IConfiguration config)
        {
            _config = config;
            _rewards = config.Get<List<Reward>>();
        }
        
        public async Task GiveReward(IUser user)
        {
            
        }
    }
}