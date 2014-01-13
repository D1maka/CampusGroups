using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusGroups.API.Entities
{
    public class MessageGroupInvitation
    {
        public int MessageGroupInvitationId
        { get; set; }
        public int MessageGrouptId
        { get; set; }
        public int UserAccountId
        { get; set; }
        public DateTime InvitationDate
        { get; set; }
        public int IsProcessed
        { get; set; }
        public char vcActuality
        { get; set; }
        public DateTime vcChangeDate
        { get; set; }
    }
}