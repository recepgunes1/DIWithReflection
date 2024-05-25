using Business.Common.LifeTimeMarkers;
using Business.Services.Abstracts;

namespace Business.Services.Concretes;

public sealed class UserService : IUserService, ITransientService
{
    public string GetUserName()
    {
        return "LoremIpsum10";
    }
}