using ProductSalesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSalesAPI.AuthServices
{
    public interface IAuthenticateService
    {
        AuthUser Authenticate(string userName, string password);
    }
}
