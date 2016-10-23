using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SimpleBankATM.Data;
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


            //Services



            //Repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>();





            base.Load(builder);
        }
    }
}
