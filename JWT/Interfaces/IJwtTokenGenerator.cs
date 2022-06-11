using JWT.Data;

namespace JWT.Interfaces
{
    public interface IJwtTokenGenerator
    {
        Token Generate(string user, string role);
    }
}
