using MediatR;

namespace Common.L2.Application
{
	public interface IBaseCommandHandler<TCommand> : IRequestHandler<TCommand, OperationResult> where TCommand : IBaseCommand
	{
	}

	public interface IBaseCommandHandler<TCommand, TResponseData> : IRequestHandler<TCommand, OperationResult<TResponseData>> where TCommand : IBaseCommand<TResponseData>
	{
	}
}