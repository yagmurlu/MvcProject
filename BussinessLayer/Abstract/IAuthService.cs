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
        void AdminRegister(string adminMail, string password);
        bool AdminLogin(AdminLoginDto adminDto);
        bool WriterLogin(WriterLoginDto writerDto);
        void WriterRegister(string writerMail, string writerPassword);
    }
}
