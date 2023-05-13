namespace Twileloop.Security.Abstractions.Encoding.Base
{
    public interface IEncodingAlgorithm : ICryptographicAlgorithm
    {
        string Encode(string textData);
        string Decode(string textData);
    }
}
