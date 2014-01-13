using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusGroups.API.Entities
{
    public class Message
    {
        public int MessageId
        { get; set; }
        public int SenderUserAccountId
        { get; set; }
        public string Text
        { get; set; }
        public string Subject
        { get; set; }
        public DateTime DateSent
        { get; set; }
        public int MessageGroupId
        { get; set; }
        public char vcActuality
        { get; set; }
        public DateTime vcChangeDate
        { get; set; }
    }
}