using Bello.DAL.Interface;
using Bello.Domain.Request.List;
using Bello.Domain.Response.Card;
using Bello.Domain.Response.List;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Bello.DAL.Implement
{
    public class ListRepository : BaseRepository, IListRepository
    {
        public async Task<SaveListRes> ChangeStatus(int listId, int status)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ListId", listId);
                parameters.Add("@Status", status);
                parameters.Add("@UserId", 1);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveListRes>(cnn: connection,
                                                            sql: "sp_ChangeStatusList",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SaveListRes> DrapDropList(int listId, int positionNew)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ListId", listId);
                parameters.Add("@PositionNew", positionNew);              
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveListRes>(cnn: connection,
                                                            sql: "sp_DrapdropList",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ListView> Get(int ListId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ListId", ListId);
                return await SqlMapper.QueryFirstOrDefaultAsync<ListView>(cnn: connection,
                                                            sql: "sp_GetList",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<ListView>> GetListSave()
        {
            try
            {
               
                return await SqlMapper.QueryAsync<ListView>(cnn: connection,
                                                         sql: "sp_GetListSave",                                                        
                                                         commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ListView>> Gets(int boardId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BoardId", boardId);
                return await SqlMapper.QueryAsync<ListView>(cnn: connection,
                                                         sql: "sp_GetLists",
                                                         param: parameters,
                                                         commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<SaveListRes> MoveAllList(int listIdBefore, int listIdAfter)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ListIdBefore", listIdBefore);
                parameters.Add("@ListidAfter", listIdAfter);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveListRes>(cnn: connection,
                                                            sql: "sp_MoveAllCard",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SaveListRes> Save(SaveListReq request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ListId", request.ListId);
                parameters.Add("@ListName", request.ListName);
                parameters.Add("@BoardId", request.BoardId);
                parameters.Add("@UserId", 1);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveListRes>(cnn: connection,
                                                            sql: "sp_SaveList",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception)
            {
                return new SaveListRes()
                {
                    ListId = 0,
                    Message = "Something went wrong please try again!!"
                };
            }
        }

        public async Task<SaveListRes> StorageAllCard(int listId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();               
                parameters.Add("@ListId", listId);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveListRes>(cnn: connection,
                                                            sql: "sp_StorageAllCard",
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
