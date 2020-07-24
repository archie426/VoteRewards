namespace VoteRewards.API.Authentication
{
    public struct ApiKey
    {
        public string Key { get; }
        public ClientType Type { get; }

        public ApiKey(string key, ClientType type)
        {
            Key = key;
            Type = type;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}