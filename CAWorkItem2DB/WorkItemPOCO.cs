using System;
using LiteDB;
using System.Collections.Generic;
using System.Text;

namespace CAWorkItem2DB
{
    class WorkItemPOCO
    {
        [BsonId]
        public int wItemId { get; set; }
        public string State { get; set; }
        public string Title { get; set; }
        public DateTime Changed_Date { get; set; }

    }
}

///
/// System.AreaId
/*
System.AreaPath
System.ExternalLinkCount
System.AssignedTo
System.AttachedFileCount
System.AuthorizedAs
System.ChangedBy
System.ChangedDate
System.CreatedBy
System.CreatedDate
System.Description
System.History
System.HyperLinkCount
System.Id
System.IterationId
System.IterationPath
System.NodeName
System.Reason
System.RelatedLinkCount
System.Rev
System.RevisedDate
System.State
System.TeamProject
System.Title
System.WorkItemType*/
///