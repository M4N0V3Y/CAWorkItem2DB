using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace CAWorkItem2DB
{
    class instanceCAWorkItem2DB
    {


        private static instanceCAWorkItem2DB instance = null;
        private static readonly object padlock = new object();
        LiteDatabase dbInstance;

        instanceCAWorkItem2DB()
        {
            DbInstance = new LiteDatabase(GlobalConfiguration.Instance._dbFileName);

        }

        public static instanceCAWorkItem2DB Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new instanceCAWorkItem2DB();
                    }
                    return instance;
                }
            }
        }

        public LiteDatabase DbInstance { get => dbInstance; set => dbInstance = value; }
    }
}
