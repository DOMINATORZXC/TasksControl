using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TasksControl.Enum
{
    public enum StatusCode
    {
        TaskNotFound = 0,
        TaskSuccess = 1,
        OK = 200,
        InternalServerError = 500
    }
}
