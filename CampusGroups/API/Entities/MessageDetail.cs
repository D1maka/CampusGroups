using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusGroups.API.Entities
{
    public class MessageDetail
    {
        public int MessageDetailsId
        { get; set; }
        public int MessageId
        { get; set; }
        public int UserAccountId
        { get; set; }
        public DateTime DateRead
        { get; set; }
        public DateTime DateView
        { get; set; }
        public DateTime DateDelete
        { get; set; }
        public char vcActuality
        { get; set; }
        public DateTime vcChangeDate
        { get; set; }
    }
}