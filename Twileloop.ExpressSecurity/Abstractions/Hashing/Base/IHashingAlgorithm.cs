namespace Twileloop.Security.Abstractions.Hashing.Base
{
    public interface IHashingAlgorithm : ICryptographicAlgorithm
    {
        string Hash(string s);
    }
}
