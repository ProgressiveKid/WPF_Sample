using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class UserInTable
    {
        // public int Rank { get; set; }
        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }
        public int CountDay { get; set; }
        public int SumStepsDay { get; set; }
        public int FinishSum { get; set; }
        public int MaxSum { get; set; }
        public int MinSum { get; set; }
  
    }
}
