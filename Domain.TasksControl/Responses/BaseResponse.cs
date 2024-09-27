using Domain.TasksControl.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TasksControl.Responses
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }

        public StatusCode StatusCode { get; set; }
        public string Desctiption { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T Data { get; set; }
        StatusCode StatusCode { get; set; }
    }
}
