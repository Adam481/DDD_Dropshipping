using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DDD_Dropshipping.Ordering.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD_Dropshipping.Ordering.Infrastructure.Data.EF.Order
{
    internal class OrderEFMapping : IEntityTypeConfiguration<Domain.OrderAggregate.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.OrderAggregate.Order> builder)
        {
            
        }
    }
}
