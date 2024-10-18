using Common.L4.Query.Filter;

namespace Common.L4.Query
{
	public class QueryFilter<TResponse, TParam> : IQuery<TResponse>
	where TResponse : BaseFilter
	where TParam : BaseFilterParam
	{
		public TParam FilterParams { get; set; }
		public QueryFilter(TParam filterParams)
		{
			FilterParams = filterParams;
		}
	}
}
