using Bello.DAL.Interface;
using Bello.Domain.Request.Card;
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

        public async Task<SaveCardRes> Create(SaveCardReq saveCardReq)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CardName", saveCardReq.CardName);
                parameters.Add("@ListId", saveCardReq.ListId);
                parameters.Add("@CreateBy", saveCardReq.CreateBy);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveCardRes>(cnn: connection,
                                                            sql: "sp_SaveCard",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SaveCardRes> DrapDropCard(DrapDropReq drapDropReq)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CardId", drapDropReq.CardId);
                parameters.Add("@ListIdAfter", drapDropReq.ListIdAfter);
                parameters.Add("@PositionNew", drapDropReq.PositionNew);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveCardRes>(cnn: connection,
                                                            sql: "sp_DrapDropCard",
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

        public async Task<IEnumerable<CardView>> Gets(int ListId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ListId", ListId);
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

        public async Task<SaveCardRes> Update(UpdateCardReq updateCardReq)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CardId", updateCardReq.CardId);
                parameters.Add("@CardName", updateCardReq.CardName);
                parameters.Add("@Description", updateCardReq.Description );
                parameters.Add("@DueDate", updateCardReq.DueDate );                
                parameters.Add("@ModifiedBy", updateCardReq.ModifiedBy );
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveCardRes>(cnn: connection,
                                                            sql: "sp_UpdateCard",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SaveCardRes> UpdateName(UpdateName updateName)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CardId", updateName.CardId);
                parameters.Add("@CardName", updateName.CardName);              
                parameters.Add("@UserId", updateName.UserId);
                return await SqlMapper.QueryFirstOrDefaultAsync<SaveCardRes>(cnn: connection,
                                                            sql: "sp_UpdateNameCard",
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
