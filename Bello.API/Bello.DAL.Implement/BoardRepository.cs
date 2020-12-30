using Bello.DAL.Interface;
using Bello.Domain.Request.Board;
using Bello.Domain.Response.Board;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Bello.DAL.Implement
{
    public class BoardRepository : BaseRepository, IBoardRepository
    {
        
        public async Task<SaveBoardRes> ChangeStatus(int boardId, int status,string userid)
        {   
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BoardId", boardId);
                parameters.Add("@Status", status);
                parameters.Add("@UserId", userid);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveBoardRes>(cnn: connection,
                                                            sql: "sp_ChangeStatusBoard",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BoardView> Get(int boardId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BoardId", boardId);
                return await SqlMapper.QueryFirstOrDefaultAsync<BoardView>(cnn: connection,
                                                            sql: "sp_GetBoard",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<BoardView>> Gets(string UserId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", UserId);
                return await SqlMapper.QueryAsync<BoardView>(cnn: connection,
                                                         sql: "sp_GetBoards",
                                                          param: parameters,
                                                         commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<SaveBoardRes> Save(SaveBoardReq request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BoardId", request.BoardId);
                parameters.Add("@BoardName", request.BoardName);
                parameters.Add("@UserId", request.UserId);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveBoardRes>(cnn: connection,
                                                            sql: "sp_SaveBoard",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
