using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;

namespace DatabaseService
{
    public interface IDataService
    {
        IList<SearchResult> EFShowSearchResult(string searchstring);
        void EFMarkThisPost(int postid, string searchstring);
        IList<Post> GetPosts(int page, int pagesize);
        Post GetPost(int id);
        void AddPost(Post post);
        bool UpdatePost(Post post);
        bool DeletePost(int id);
        int GetNumberOfPosts();
        IList<Comment> GetComments(int page, int pagesize);
        Comment GetComment(int id);
        void AddComment(Comment comment);
        bool UpdateComment(Comment comment);
        bool DeleteComment(int id);
        int GetNumberOfComments();
        
    }
}
