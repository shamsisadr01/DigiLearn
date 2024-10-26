using Common.L4.Query;
using CoreModule.Query.Course._DTOs;

namespace CoreModule.Query.Course.Episodes;

public record GetEpisodeByIdQuery(Guid EpisodeId) : IQuery<EpisodeDto?>;