using System.Collections.Generic;
using System.Linq;
using System;
using NHibernate;
using WebClientAPI.Models.Entities;
using System.Web.Mvc;

namespace WebClientAPI.Models.Services
{
    public class ClientServices
    {
        private readonly ISession _session;

        public ClientServices(ISession session)
        {
            _session = session;
        }

        public IList<Client> GetAllClients()
        {
            return _session.Query<Client>().ToList();
        }

        public void AddClient(Client client)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Save(client);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public Client GetUniqueClient(int id)
        {
            return _session.Get<Client>(id);
        }

        public void EditClient(Client client)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(client);
                transaction.Commit();
            }
        }

        public void DeleteClient(Client client) 
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(client);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}