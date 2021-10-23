using BussinessLayer.Abstract;
using BussinessLayer.Utilities.Hashing;
using EntityLayer.Concrete;
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

        public void AdminRegister( string adminName,string adminMail, string password ,int roleId)
        {
            byte[] userNameHash, passwordHash, passwordSalt;
            HashingHelper.AdminCreatePasswordHash(adminMail, password, out userNameHash, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                AdminName= adminName,
                AdminUserName = userNameHash,
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                RoleId=roleId
            };
            _adminService.AdminAddBL(admin);
        }

        public bool AdminLogin(AdminLoginDto adminDto)
        {
            using (var crypto=new System.Security.Cryptography.HMACSHA512())
            {
                var userNameHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(adminDto.AdminUsername));
                var user = _adminService.GetList();
                foreach (var item in user)
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
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {

                var writer = _writerService.GetList();
                foreach (var item in writer)
                {
                    if (HashingHelper.WriterVerifyPasswordHash(writerDto.WriterPassword,item.WriterPasswordHash,item.WriterPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void WriterRegister(string name, string surname,
           string ımage, string about, string writerMail, string writerPassword, string title,
           bool status)
        {
            byte[]  passwordHash, passwordSalt;
          
            HashingHelper.WriterCreatePasswordHash(writerPassword, out passwordHash, out passwordSalt);
            var writer = new Writer
            {
                WriterName = name,
                WriterSurName = surname,
                WriterImage = ımage,
                WriterAbout = about,
                WriterMail = writerMail,
                WriterPasswordHash = passwordHash,
                WriterPasswordSalt = passwordSalt,
                WriterTıtle = title,
                WriterStatus=status
            };
            _writerService.WriterAdd(writer);
        }
    }
}
