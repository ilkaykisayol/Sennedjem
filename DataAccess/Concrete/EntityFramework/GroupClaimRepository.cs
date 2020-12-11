﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class GroupClaimRepository : EfEntityRepositoryBase<GroupClaim, ProjectDbContext>, IGroupClaimRepository
    {
        public GroupClaimRepository(ProjectDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SelectionItem>> GetGroupClaimsSelectedList(int groupId)
        {
            var list = await (from gc in context.GroupClaims
                              join oc in context.OperationClaims on gc.ClaimId equals oc.Id
                              where gc.GroupId == groupId
                              select new SelectionItem()
                              {
                                  Id = oc.Id.ToString(),
                                  Label = oc.Name
                              }).ToListAsync();

            return list;
        }
    }
}
