using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Share.Services
{
    public interface ISharedIdentityService
    {
        public string GetUserId { get; }   
    }
}
