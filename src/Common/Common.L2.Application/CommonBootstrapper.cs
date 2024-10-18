using Common.L2.Application.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Common.L2.Application
{
	public class CommonBootstrapper
	{
		public static void Init(IServiceCollection service)
		{
			service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
		}
	}
}