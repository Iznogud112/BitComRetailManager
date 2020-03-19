﻿using BitComDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace BitComDesktopUI.Library.API
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
        Task GetLoggedInUserInfo(string token);
    }
}