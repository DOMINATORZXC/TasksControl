using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TasksControl.Enum
{
    public enum ProjectStatus
    {
        [Display(Name = "В процессе")]
        Proccess = 0,
        [Display(Name = "Готово")]
        Done= 1
    }
}
