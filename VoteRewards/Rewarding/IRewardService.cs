using System.Threading.Tasks;
using OpenMod.API.Ioc;
using OpenMod.API.Users;

namespace VoteRewards.Rewarding
{
    [Service]
    public interface IRewardService
    {
        Task GiveReward(IUser user);
    }
}