﻿using BussinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAddBL(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public Contact GetByIdContactAndSetRead(int id, bool read)
        {
            return _contactDal.Get(x => x.ContactID == id && x.IsRead == true);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
    }
}
