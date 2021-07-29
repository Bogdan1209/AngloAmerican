using System;
using System.Collections.Generic;
using System.Text;

namespace AngloAmerican.Common.Abstract
{
    public interface IMyBeautifulMapper
    {
        IEnumerable<TChild> Map<TParent, TChild>(IEnumerable<TParent> parents)
            where TParent : class
            where TChild : class, new();

        TChild Map<TParent, TChild>(TParent parent) 
            where TParent : class
            where TChild : class, new();
    }
}
