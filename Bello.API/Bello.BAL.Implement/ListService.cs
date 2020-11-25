﻿using Bello.BAL.Interface;
using Bello.DAL.Interface;
using Bello.Domain.Request.List;
using Bello.Domain.Response.List;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.BAL.Implement
{
    public class ListService : IListService
    {
        private readonly IListRepository listRepository;
        public ListService(IListRepository listRepository)
        {
            this.listRepository = listRepository;
        }

        public async Task<SaveListRes> ChangeStatus(int listId, int status)
        {
            return await listRepository.ChangeStatus(listId,status);
        }

        public async Task<ListView> Get(int ListId)
        {

            return await listRepository.Get(ListId);
        }

        public async Task<IEnumerable<ListView>> Gets()
        {
            return await listRepository.Gets();
        }

        public async Task<SaveListRes> Save(SaveListReq request)
        {
            return await listRepository.Save(request);
        }
    }
}
