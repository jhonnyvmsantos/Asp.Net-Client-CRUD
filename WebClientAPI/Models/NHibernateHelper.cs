using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using WebClientAPI.Models.Mappings;
using WebClientAPI.Models.Services;

public class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    public static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory == null)
                InitializeSessionFactory();
            return _sessionFactory;
        }
    }

    private static void InitializeSessionFactory()
    {
        DatabaseServices.CreateDatabase();

        _sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(@"Server=.\SQLEXPRESS;Database=WebClientAPI;Trusted_Connection=True;") // ajuste o connection string
                .ShowSql())
        .Mappings(m =>
        {
            m.FluentMappings.AddFromAssemblyOf<ClientMap>();
        })
            .ExposeConfiguration(cfg =>
            {
                new SchemaExport(cfg).Drop(false, true);
                Task.Delay(2000);
                new SchemaExport(cfg).Create(false, true);
            })
            .BuildSessionFactory();
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}
