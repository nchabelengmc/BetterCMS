﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCms.Module.Api.Operations.Root.Version
{
    public interface IVersionService
    {
        GetVersionResponse Get(GetVersionRequest request = null);
    }
}