using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG_Game.Battle {
    public interface IAction {
        Entity User { get; set; }
        Entity Reciever { get; set; }
        void Action();
        //Cost
    }
}
