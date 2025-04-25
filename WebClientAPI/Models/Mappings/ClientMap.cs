using FluentNHibernate.Mapping;
using WebClientAPI.Models.Entities;

namespace WebClientAPI.Models.Mappings
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap() { 
            Id(x =>  x.Id);
            Map(x => x.Name);
            Map(x => x.Address);
            Map(x => x.Phone);
            Map(x => x.Gender);
        }
    }
}