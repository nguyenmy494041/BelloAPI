using Bello.Domain.Request.List;
using Bello.Domain.Response.List;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.BAL.Interface
{
    public interface IListService
    {
        Task<IEnumerable<ListView>> Gets(int boardId);
        Task<ListView> Get(int ListId);
        Task<SaveListRes> Save(SaveListReq request);
        Task<SaveListRes> ChangeStatus(int listId, int status);
    }
}
