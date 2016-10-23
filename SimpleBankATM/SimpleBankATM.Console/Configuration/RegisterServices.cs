using Autofac;
using SimpleBankATM.Business;
using SimpleBankATM.Business.Managers;
using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Data.Repositories;

namespace SimpleBankATM.Console.Configuration
{
    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //DataContext
            builder.RegisterType<DataContext>().As<IDataContext>().InstancePerLifetimeScope();

            //Applicaion
            builder.RegisterType<Application>().As<IApplication>();

            //Validation
            builder.RegisterType<TransactionValidator>().As<ITransactionValidator>();
            builder.RegisterType<TransactionHandler>().As<ITransactionHandler>();

            //Managers
            builder.RegisterType<AccountManager>().As<IAccountManager>();
            builder.RegisterType<TransactionManager>().As<ITransactionManager>();
            builder.RegisterType<CustomerManager>().As<ICustomerManager>();

            //Services

            //Repositories
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<AuthRepository>().As<IAuthRepository>();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>();

            base.Load(builder);
        }
    }
}