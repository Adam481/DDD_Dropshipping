﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DDD_Dropshipping.Ordering.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        void CommitChanges();
    }
}
