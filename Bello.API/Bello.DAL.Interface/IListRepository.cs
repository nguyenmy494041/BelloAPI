﻿using Bello.Domain.Request.List;
using Bello.Domain.Response.List;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.DAL.Interface
{
    public interface IListRepository
    {
        Task<IEnumerable<ListView>> Gets();
        Task<ListView> Get(int listId);
        Task<SaveListRes> Save(SaveListReq request);
        Task<SaveListRes> ChangeStatus(int listId, int status);
    }
}
