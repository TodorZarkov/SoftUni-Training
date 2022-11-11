
namespace _07.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Mission
    {
        string codeName;
        string state;//inProgress || Finished

        public string CodeName { get => codeName; set => codeName = value; }
        public string State { get => state; set => state = value; }


        public void CompleteMission()
        {

        }
    }
}
