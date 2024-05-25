using Business.Common.LifeTimeMarkers;
using Business.Services.Abstracts;

namespace Business.Services.Concretes;

public sealed class CommentService : ICommentService, IScopedService
{
    public string GetLastComment()
    {
        return "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
    }
}