using Bello.DAL.Interface;
using Bello.Domain.Response.Card;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Bello.DAL.Implement
{
    public class CardRepository : BaseRepository, ICardRepository
    {
        public async Task<SaveCardRes> ChangeStatus(int cardId, int status)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CardId", cardId);
                parameters.Add("@Status", status);
                parameters.Add("@UserId", 1);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveCardRes>(cnn: connection,
                                                            sql: "sp_ChangeStatusCard" +
                                                            "" +
                                                            "",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SaveCardRes> CompleteCard(int cardId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CardId", cardId);
                parameters.Add("@UserId", 1);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveCardRes>(cnn: connection,
                                                            sql: "sp_CompleteCard",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CardView> Get(int cardId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CardId", cardId);
                return await SqlMapper.QueryFirstOrDefaultAsync<CardView>(cnn: connection,
                                                            sql: "sp_GetCard",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<CardView>> Gets(int listId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ListId", listId);
                return await SqlMapper.QueryAsync<CardView>(cnn: connection,
                                                         sql: "sp_GetCards",
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
