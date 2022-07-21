using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Utilities.Results
{
    public interface IDataResult<E>
    {
        E Data { get; }
        bool Success { get; }
    }
}
