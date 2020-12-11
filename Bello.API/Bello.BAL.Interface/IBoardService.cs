using Bello.Domain.Request.Board;
using Bello.Domain.Response.Board;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.BAL.Interface
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardView>> Gets(string UserId);
        Task<BoardView> Get(int boardId);
        Task<SaveBoardRes> Save(SaveBoardReq request);
        Task<SaveBoardRes> ChangeStatus(int boardId, int status,string userid);
    }
}
