using Bello.Domain.Request.Board;
using Bello.Domain.Response.Board;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.DAL.Interface
{
    public interface IBoardRepository
    {
        Task<IEnumerable<BoardView>> Gets();
        Task<BoardView> Get(int boardId);
        Task<SaveBoardRes> Save(SaveBoardReq request);
        Task<SaveBoardRes> ChangeStatus(int boardId, int status);
    }
}
