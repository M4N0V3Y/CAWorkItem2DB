using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;

namespace CAWorkItem2DB
{
    class ExecWorkItemsQuery
    {

        /// <summary>
        /// Constructor. Manually set values to match yourorganization. 
        /// </summary>
        public ExecWorkItemsQuery()
        {

        }

        /// <summary>
        /// Execute a WIQL query to return a list of bugs using the .NET client library
        /// </summary>
        /// <returns>List of Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem</returns>
        public async Task<List<WorkItem>> ExecuteWorkItemsQuery()
        {
            Uri uri = new Uri(GlobalConfiguration.Instance._uri);
            string personalAccessToken = GlobalConfiguration.Instance._tokenPA;
            string project = GlobalConfiguration.Instance._project;

            VssBasicCredential credentials = new VssBasicCredential("", GlobalConfiguration.Instance._tokenPA);

            //create a wiql object and build our query
            Wiql wiql = new Wiql()
            {
                Query = "Select [Id], [State], [Title],[Changed Date]" +
                        "From WorkItems " +
                        "Order By [State] Asc, [Changed Date] Desc"

            };

            //create instance of work item tracking http client
            using (WorkItemTrackingHttpClient workItemTrackingHttpClient = new WorkItemTrackingHttpClient(uri, credentials))
            {
                //execute the query to get the list of work items in the results
                WorkItemQueryResult workItemQueryResult = await workItemTrackingHttpClient.QueryByWiqlAsync(wiql);

                //some error handling                
                if (workItemQueryResult.WorkItems.Count() != 0)
                {
                    //need to get the list of our work item ids and put them into an array
                    List<int> list = new List<int>();
                    foreach (var item in workItemQueryResult.WorkItems)
                    {
                        list.Add(item.Id);
                    }
                    int[] arrWIQueryResult = list.ToArray();

                    //build a list of the fields we want to see
                    string[] wiProperties = new string[4];
                    wiProperties[0] = "System.Id";
                    wiProperties[1] = "System.State";
                    wiProperties[2] = "System.Title";
                    wiProperties[3] = "System.ChangedDate";


                    //get work items for the ids found in query
                    var workItems = await workItemTrackingHttpClient.GetWorkItemsAsync(arrWIQueryResult, wiProperties, workItemQueryResult.AsOf);

                    return workItems;
                }

                return null;
            }
        }
    }
}
