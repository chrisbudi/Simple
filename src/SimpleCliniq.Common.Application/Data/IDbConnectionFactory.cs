﻿using System.Data.Common;

namespace SimpleCliniq.Common.Application.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
