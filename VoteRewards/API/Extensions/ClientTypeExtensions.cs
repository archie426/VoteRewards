namespace VoteRewards.API.Extensions
{
    public static class ClientTypeExtensions
    {
        //TODO: Find a better way to do this
        public static string String(this ClientType type)
        {
            return type == ClientType.UnturnedServers ? "unturnedServersNet" : "unturnedSl";
        }
    }
}