using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interaction;

namespace Primary_Queen
{
    public class PrimaryPlayer : Player
    {
        private Intelligence playerIntelligence;


        public Intelligence PlayerIntelligence
        {
            get; set;
        }



        public PrimaryPlayer()
        {

        }

        public PrimaryPlayer(Intelligence playerIntelligence)
        {

        }

        public PrimaryPlayer(string playerId, string playerName, string playerSurname)
        {

        }

        public PrimaryPlayer(Intelligence intelligence, string playerId, string playerName, string playerSurname)
        {

        }

        public void ChooseCircularR1MovingStrategy()
        {

        }

        public void ChooseNonCircularR1MovingStrategy()
        {

        }
    }
}
