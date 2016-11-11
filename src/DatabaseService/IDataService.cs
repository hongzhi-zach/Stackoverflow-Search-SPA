using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;

namespace DatabaseService
{
    public interface IDataService
    {
        IList<Comments> GetComments(int page, int pagesize);
        Comments GetComments(int id);
        void AddComments(Comments comment);
        bool UpdateComments(Comments comment);
        bool DeleteComments(int id);
        int GetNumberOfComments();
    }
}
