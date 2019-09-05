using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using Newtonsoft.Json;

namespace CAWorkItem2DB
{
    class WorkItemCRUD
    {
        readonly LiteCollection<WorkItemPOCO> wkitemCollection = instanceCAWorkItem2DB.Instance.DbInstance.GetCollection<WorkItemPOCO>("WorkItemPOCO");
        /// <summary>
        /// Grava ou atualiza um Workitem no BD local
        /// </summary>
        /// <param name="_wiId"></param>
        /// <param name="_wiState"></param>
        /// <param name="_wiTitle"></param>
        /// <param name="_wiChangedDate"></param>
        public void SaveRecord(int _wiId, string _wiState, string _wiTitle, DateTime _wiChangedDate)
        {
            WorkItemPOCO _oWorkItem = new WorkItemPOCO();            
            _oWorkItem.wItemId = _wiId;
            _oWorkItem.State = _wiState;
            _oWorkItem.Title = _wiTitle;
            _oWorkItem.Changed_Date = _wiChangedDate;
            //
            IEnumerable<WorkItemPOCO> resultSearch = wkitemCollection.Find(x => x.wItemId.Equals(_wiId));
            if (resultSearch.Count<WorkItemPOCO>() == 0)
            {
                wkitemCollection.Insert(_oWorkItem);
            }
            else
            {
                wkitemCollection.Update(_oWorkItem);
            }
            
        }

        internal void SynchWEbDataDB()
        {
            IEnumerable<WorkItemPOCO> resultSearch = wkitemCollection.FindAll();
            List<WorkItemPOCO> lst = resultSearch.ToList();
            string json = JsonConvert.SerializeObject(lst.ToArray());            
            System.IO.File.WriteAllText(GlobalConfiguration.Instance._webFileName, json);
        }
    }
}
