using Bello.Domain.Request.List;
using Bello.Domain.Response.List;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.DAL.Interface
{
    public interface IListRepository
    {
        Task<IEnumerable<ListView>> Gets(int boardId);
        Task<ListView> Get(int listId);
        Task<SaveListRes> Save(SaveListReq request,string userid);
        Task<SaveListRes> ChangeStatus(int listId, int status,string userid);
        Task<SaveListRes> DrapDropList(int listId, int positionNew);
        Task<SaveListRes> MoveAllList(int listIdBefore, int listIdAfter);
        Task<SaveListRes> StorageAllCard(int listId);
        Task<IEnumerable<ListView>> GetListSave();
    }
}
