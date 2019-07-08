using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPattern;
using Game_Defination;

namespace Interaction
{
    public class KingEnvironment : IUpdate
    {
        private List<King> kings;
        private HashSet<KingStep> steps;

        public KingEnvironment()
        {

        }


        public KingEnvironment(List<King> kings)
        {

        }

        public KingEnvironment(HashSet<KingStep> steps)
        {

        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
