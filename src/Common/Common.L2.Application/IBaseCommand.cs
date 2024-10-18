using MediatR;

namespace Common.L2.Application
{
	public interface IBaseCommand : IRequest<OperationResult>
	{
	}

	public interface IBaseCommand<TData> : IRequest<OperationResult<TData>>
	{
	}
}