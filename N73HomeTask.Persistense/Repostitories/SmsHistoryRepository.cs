﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Persistense.DataAccess;
using N73HomeTask.Persistense.Repostitories.Interfaces;

namespace N73HomeTask.Persistense.Repostitories;

public class SmsHistoryRepository(NotificationDbContext context) : 
    EntityRepositoryBase<SmsHistory,NotificationDbContext>(context),ISmsHistoryRepository
{
    public IQueryable<SmsHistory> Get(
        Expression<Func<SmsHistory, bool>>? predicate = default,
        bool asNoTracking = false
    ) =>
        base.Get(predicate, asNoTracking);

    public async ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        if (smsHistory.SmsTemplate is not null)
            DbContext.Entry(smsHistory.SmsTemplate).State = EntityState.Unchanged;

        var createdHistory = await base.CreateAsync(smsHistory, saveChanges, cancellationToken);

        if (smsHistory.SmsTemplate is not null)
            DbContext.Entry(smsHistory.SmsTemplate).State = EntityState.Detached;

        return createdHistory;
    }
}