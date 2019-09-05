using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
namespace CAWorkItem2DB
{

    class Program
    {        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Retrieve Work Itens from AZURE DevOps");

            ExecWorkItemsQuery exWIQuery = new ExecWorkItemsQuery();           

            var azrWItemResult = await exWIQuery.ExecuteWorkItemsQuery();

            foreach(var wi in azrWItemResult)
            {

                Console.WriteLine("ID {0} - TYPE {1} - TITLE {2}  DATE CHANGED {3}", wi.Fields["System.Id"], wi.Fields["System.State"], wi.Fields["System.Title"], wi.Fields["System.ChangedDate"]);

                SaveRecord(wi.Fields["System.Id"].ToString(), wi.Fields["System.State"].ToString(), wi.Fields["System.Title"].ToString(), wi.Fields["System.ChangedDate"].ToString());
            }

            SynchWEbDataDB();

            Console.WriteLine("Geting results...");
        }

        private static void SynchWEbDataDB()
        {
            WorkItemCRUD workItemCRUD = new WorkItemCRUD();
            workItemCRUD.SynchWEbDataDB();
        }

        private static void SaveRecord(string _wiId, string wiState, string wiTitle, string wiChangedDt)
        {
            WorkItemCRUD workItemCRUD = new WorkItemCRUD();
            int lcWiId = int.Parse(_wiId);
            DateTime lcChangedDate = DateTime.Parse(wiChangedDt);
            workItemCRUD.SaveRecord(lcWiId, wiState, wiTitle, lcChangedDate);

        }
    }
}
