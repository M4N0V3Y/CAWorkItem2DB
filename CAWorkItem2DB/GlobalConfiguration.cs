using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CAWorkItem2DB
{
    class GlobalConfiguration
    {
        public string _uri;
        public string _tokenPA;
        public string _project;
        public string _dbFileName;
        public string _webFileName;

        private static GlobalConfiguration instance;        
        private static readonly object padlock = new object();

        GlobalConfiguration()
        {
            XDocument doc = XDocument.Load("C:\\AzureWorkItemsDb\\AzureDevOpsConfig.xml");

            foreach (XElement el in doc.Root.Elements())
            {
                if (el.Name == "uri") _uri = el.Value;
                if (el.Name == "tokenPA") _tokenPA = el.Value;
                if (el.Name == "project") _project = el.Value;
                if (el.Name == "DBFileName") _dbFileName = el.Value;
                if (el.Name == "WebFileName") _webFileName = el.Value;
            }

        }

        public static GlobalConfiguration Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GlobalConfiguration();

                    }
                    return instance;
                }
            }
        }


    }
}
