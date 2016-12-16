using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;

namespace DatabaseService
{
    public interface IDataService
    {
        IList<Cloud> EFShowWordCloud(string word);
        IList<SearchResult> EFShowSearchResult(string searchstring, int page, int pagesize);
        void EFMarkThisPost(int postid, string searchstring);
        SearchResult GetSearchResult(int id);
        IList<PostDetail> EFShowPostDetail(int postid);
        //history
        IList<History> GetHistoryList(int page, int pagesize);
        History GetHistory(int id);
        void AddHistory(History history);
        int GetCountOfHistoryList();

        //Post
        IList<Post> GetPosts(int page, int pagesize);
        Post GetPost(int id);
        void AddPost(Post post);
        bool UpdatePost(Post post);
        bool DeletePost(int id);
        int GetNumberOfPosts();

        //Comment
        IList<Comment> GetComments(int page, int pagesize);
        Comment GetComment(int id);
        void AddComment(Comment comment);
        bool UpdateComment(Comment comment);
        bool DeleteComment(int id);
        int GetNumberOfComments();

        //User
        IList<User> GetUser(int page, int pagesize);
        User GetUser(int id);
        void AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        int GetNumberOfUser();
    
        //Linkpost
        IList<Linkpost> GetLinkpost(int page, int pagesize);
        Linkpost GetLinkpost(int id);
        void AddLinkpost(Linkpost lp);
        bool UpdateLinkpost(Linkpost lp);
        bool DeleteLinkpost(int id);
        int GetNumberOfLinkpost();

        //Post_tag
        IList<Post_tag> GetPost_tag(int page, int pagesize);
        Post_tag GetPost_tag(int id);
        void AddPost_tag(Post_tag pt);
        bool UpdatePost_tag(Post_tag pt);
        bool DeletePost_tag(int id);
        int GetNumberOfPost_tag();

       

        //History


        //Markedposts


    }
}
