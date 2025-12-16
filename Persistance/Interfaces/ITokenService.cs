using System;
using Domain.DBSchemas;

namespace Persistance.Interfaces;

public interface ITokenService
{
	string CreateToken(User user);
}
