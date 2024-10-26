using Common.L4.Query;
using CoreModule.Query._Data;
using CoreModule.Query.Course._DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Query.Course.Episodes;

class GetEpisodeByIdQueryHandler : IQueryHandler<GetEpisodeByIdQuery, EpisodeDto?>
{
    private readonly QueryContext _context;

    public GetEpisodeByIdQueryHandler(QueryContext context)
    {
        _context = context;
    }

    public async Task<EpisodeDto?> Handle(GetEpisodeByIdQuery request, CancellationToken cancellationToken)
    {
        var episode = await _context.Episodes.FirstOrDefaultAsync(f => f.Id == request.EpisodeId, cancellationToken: cancellationToken);
        if (episode == null)
        {
            return null;
        }

        return new EpisodeDto
        {
            Id = episode.Id,
            CreationDate = episode.CreationDate,
            SectionId = episode.SectionId,
            Title = episode.Title,
            EnglishTitle = episode.EnglishTitle,
            Token = episode.Token,
            TimeSpan = episode.TimeSpan,
            VideoName = episode.VideoName,
            AttachmentName = episode.AttachmentName,
            IsActive = episode.IsActive,
            IsFree = episode.IsFree
        };
    }
}