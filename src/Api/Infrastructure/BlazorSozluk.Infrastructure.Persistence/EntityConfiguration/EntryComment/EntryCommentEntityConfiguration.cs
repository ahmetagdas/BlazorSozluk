﻿using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorSozluk.Infrastructure.Persistence.EntityConfiguration.EntryComment;

public class EntryCommentEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.EntryComment>
{
    public override void Configure(EntityTypeBuilder<Api.Domain.Models.EntryComment> builder)
    {
        base.Configure(builder);

        builder.ToTable("entrycomment", BlazorSozlukContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.CreatedBy)
            .WithMany(i => i.EntryComments)
            .HasForeignKey(i => i.CreatedById);

        builder.HasOne(i => i.Entry)
            .WithMany(i => i.EntryComments)
            .HasForeignKey(i=> i.EntryId);
    }
}
