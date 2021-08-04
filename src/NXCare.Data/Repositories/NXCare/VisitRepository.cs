﻿using NXCare.Data.Contexts.NXCare;
using NXCare.Data.Repositories.Base;
using NXCare.Domain.Entities;
using NXCare.Domain.Interfaces.Repositories.NXCare;

namespace NXCare.Data.Repositories.NXCare
{
    public class VisitRepository : BaseRepository<Language, int>, IVisitRepository
    {
        /// <inheritdoc />
        public VisitRepository(NXCareContext context) : base(context)
        {
        }
    }
}