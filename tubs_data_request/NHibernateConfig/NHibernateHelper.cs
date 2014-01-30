﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tubs_data_request.DAL.Maps;

namespace tubs_data_request.NHibernateConfig
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            //IPersistenceConfigurer cfg =
            //    MsSqlConfiguration.MsSql2008.ConnectionString(c => c
            //            .FromConnectionStringWithKey("ObsvMasterConnection")).ShowSql();

            NHibernate.Cfg.Configuration config = Fluently.Configure().
                Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection"))).
                Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataFormsMap>()).
                CurrentSessionContext<ThreadStaticSessionContext>().
                BuildConfiguration();
            return config.BuildSessionFactory();

        }
    }
}