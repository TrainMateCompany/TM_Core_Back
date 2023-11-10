using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainmate.Common.Dto
{
    public class ResponseDto<T>
    {
        public bool HasErrors => Errors is { Count: > 0 };
        public List<string> Errors { get; set; } = new();
        public T Result { get; set; }
    }
}
