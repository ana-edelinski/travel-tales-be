﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IKeyPointRepository
    {
        List<KeyPoint> GetKeyPointsByUserId(long userId);
        int GetMaxId(long userId);
    }
}
