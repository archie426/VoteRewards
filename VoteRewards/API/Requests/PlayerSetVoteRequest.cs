namespace VoteRewards.API.Requests
{
    public struct PlayerSetVoteRequest
    {
        public bool Successful => EndCode != 0;
        
        public string SteamId { get; }
        public int EndCode { get; }

        public PlayerSetVoteRequest(string steamId, int endCode)
        {
            SteamId = steamId;
            EndCode = endCode;
        }
    }
}