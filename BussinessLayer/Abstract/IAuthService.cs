using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IAuthService
    {
        void AdminRegister(string adminName,string adminMail, string password,int roleId);
        bool AdminLogin(AdminLoginDto adminDto);
        bool WriterLogin(WriterLoginDto writerDto);
        void WriterRegister(string name,string surname,
           string ımage,string about, string writerMail, string writerPassword,string title,
           bool status);
    }
}
