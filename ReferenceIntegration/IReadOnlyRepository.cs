using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceIntegration
{
    public interface IReadOnlyRepository<T>
    {
        T Find(string id);

        IEnumerable<T> ListAll();
    }
}
