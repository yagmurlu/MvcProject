﻿using BussinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace MvcProje.Roles
{
    public class AdminRoleProvider : RoleProvider
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)//Kullanıcılar için rol alma komutu
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                var userNameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(username));
                
                var admin = adminManager.GetList();
                var writer = writerManager.GetList();
                if (admin!=null)
                {
                    foreach (var item in admin)
                    {
                        for (int i = 0; i < userNameHash.Length; i++)
                        {
                            if (userNameHash[i] == item.AdminUserName[i])
                            {
                                return new string[] { item.Role.RoleName };
                            }
                        }
                    }
                }
                //foreach (var item in user)
                //{
                //    for (int i = 0; i < userNameHash.Length; i++)
                //    {
                //        if (userNameHash[i]==item.AdminUserName[i])
                //        {
                //            return new string[] { item.Role.RoleName };
                //        }
                //    }
                //}
                return new string[] { };
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}