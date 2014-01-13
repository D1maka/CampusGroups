using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusGroups.API.Entities
{
    public class MessageGroup
    {
        public int MessageGroupId
        { get; set; }
        public string Name
        { get; set; }
        public char IsPrivate
        { get; set; }
        public char vsActuality
        { get; set; }
        public DateTime vcChangeDate
        { get; set; }
    }
}