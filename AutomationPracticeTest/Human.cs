using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice
{
    class Human
    {
        public Human()
        {
            Age = 0;
        }

        public int Height;
        public int Weight;
        public string Name;
        public int Age;

        public void Move(int step)
        {
            for (int i = 0; i < step; i++)
            {
                StepWithLeftLeg();
                StepWithRightLeg();
            }
        }

        private void StepWithLeftLeg()
        {
        }

        private void StepWithRightLeg()
        {
        }

        public void Eat(string food)
        {
        }
    }
}
