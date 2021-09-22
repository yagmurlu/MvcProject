using BussinessLayer.Abstract;
using BussinessLayer.Utilities.Hashing;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BussinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
        IWriterService _writerService;

        public AuthManager(IAdminService adminService, IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;
        }

        public void AdminRegister(string adminMail, string password)
        {
            throw new NotImplementedException();
        }

        public bool AdminLogin(AdminLoginDto adminDto)
        {
            using (var crypto=new System.Security.Cryptography.HMACSHA512())
            {
                var hashMail = crypto.ComputeHash(Encoding.UTF8.GetBytes(adminDto.AdminUsername));
                var admin = _adminService.GetList();
                foreach (var item in admin)
                {
                    if (HashingHelper.AdminVerifyPasswordHash(adminDto.AdminUsername,adminDto.AdminPassword,item.AdminUserName,item.AdminPasswordHash,item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool WriterLogin(WriterLoginDto writerDto)
        {
            throw new NotImplementedException();
        }

        public void WriterRegister(string writerMail, string writerPassword)
        {
            throw new NotImplementedException();
        }
    }
}
