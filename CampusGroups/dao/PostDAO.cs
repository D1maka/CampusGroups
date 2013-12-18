using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampusGroups.data;

namespace CampusGroups.dao
{
    public class PostDAO
    {
        private static PostDAO instance;
        private dbCAmpusGroupsDataContext db;

        private PostDAO()
        {
            db = new dbCAmpusGroupsDataContext(@"Data Source=.\sqlexpress;Initial Catalog=dbCampusGroups;Integrated Security=True");   
        }

        public static PostDAO getInstance()
        {
            if (instance == null)
            {
                instance = new PostDAO();
            }
            return instance;
        }

        public void insertPost(Post post)
        {
            db.Posts.InsertOnSubmit(post);
            db.SubmitChanges();
        }

        public Post getPostByPostUserGroupTime(int userId, int groupId, DateTime date)
        {
            var query = from post in db.Posts where post.authorId == userId && post.groupId == groupId && post.postDate == date select post;
            if (query.Any())
                return query.First();
            else
                return null;
        }

        public List<Post> getChildPost(Post post)
        {
            var postsList = (from posts in db.Posts where posts.parentPostId == post.postId select posts).ToList();
            return postsList;
        }

        public void insertAttachment(Attachment attachment)
        {
            db.Attachments.InsertOnSubmit(attachment);
            db.SubmitChanges();
        }

        public List<Attachment> getPostAttachments(Post post)
        { 
            var attachmentsList = (from attachment in db.Attachments where attachment.postId == post.postId select attachment).ToList();
            return attachmentsList;
        }
    }
}