﻿namespace UserMicroserviceAPI.Services
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
