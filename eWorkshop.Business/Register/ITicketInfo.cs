using System;
using XCommon.Application.Executes;

namespace eWorkshop.Business.Register
{
	public interface ITicketInfo
    {
		bool IsAuthenticated { get; }

		Guid UserKey { get; }

		ExecuteUser UserInfo { get; }

	}
}
