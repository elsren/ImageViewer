﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Navigation.Interfaces
{
    public interface IPageResolver
    {
        Page GetPageInstance(string alias);
    }
}
