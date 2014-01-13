using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusGroups.API.Entities
{
    public class MessageGroupRequest
    {
        public int MessageGroupRequestId
        { get; set; }
        public int MessageGrouptId
        { get; set; }
        public int UserAccountId
        { get; set; }
        public DateTime RequestDate
        { get; set; }
        public int IsProcessed
        { get; set; }
        public char vcActuality
        { get; set; }
        public DateTime vcChangeDate
        { get; set; }
    }
}