using BussinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)//Constructor Method
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListDraft(string session)//taslak
        {
            return _messageDal.List(x => x.IsDraft == true && x.SenderMail == session);    
        }

        public List<Message> GetListImportant(string session)//önemli
        {
            return _messageDal.List(x => x.IsImportant == true && x.RecevierMail == session);
        }

        public List<Message> GetListInbox(string session)//Alıcı mail
        {
            return _messageDal.List(x=>x.RecevierMail== session);
        }

        public List<Message> GetLisTrash()//çöp
        {
            return _messageDal.List(x => x.Trash == true);
        }

        public List<Message> GetListSendBox(string session)//Gönderen Mail
        {
            return _messageDal.List(x => x.SenderMail == session);
        }

        public List<Message> GetListSpam(string session)//spam
        {
            return _messageDal.List(x => x.IsSpam == true && x.RecevierMail == session);
        }

        public List<Message> GetReadList(string session)//okundu
        {
            return _messageDal.List(x => x.IsRead == true && x.RecevierMail == session);
        }

        public List<Message> GetUnReadList(string session)//okunmadı
        {
            return _messageDal.List(x => x.RecevierMail == session && x.IsRead == false);
        }

        public List<Message> IsDraft(string session)
        {
            return _messageDal.List(x => x.IsDraft == true && x.SenderMail == session);
        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

      
    }
}
