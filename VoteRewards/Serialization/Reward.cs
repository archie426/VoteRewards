using System;
using VoteRewards.API;
using VoteRewards.Rewarding;

namespace VoteRewards.Serialization
{
    [Serializable]
    public class Reward
    {
        public string RewardType { get; set; }
        
        public string ApiType { get; set; }

        public string Name { get; set; }
        

        public Reward()
        {
            
        }

        public Reward(RewardType type, ClientType apiType, string name)
        {
            RewardType = type.ToString();
            ApiType = apiType.ToString();
            Name = name;
        }
        
    }
}