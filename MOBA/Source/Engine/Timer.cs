/*
	Created by zsolc
	on 2/25/2019 9:21:04 PM.
	Credits: shlime

*/

#region Including necessary namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace MOBA
{
    public class Timer
    {
        public Timer(float timerTime, float updateTime, bool oneTimeTimer = true, Action toPerform = null)
        {
            currentTime = 0;
            Occured = 0;
            this.TimerTime = timerTime;
            this.oneTimeTimer = oneTimeTimer;
            this.UpdateTime = updateTime;
            this.toPerform = toPerform;
        }

        public float TimerTime;
        public int Occured;
        public float UpdateTime;

        private float currentTime;
        private bool oneTimeTimer;
        private Action toPerform;

        public void Update()
        {
            currentTime += UpdateTime;

            if(currentTime >= TimerTime)
            {
                Occured++;
                if (toPerform != null)
                    toPerform();
                if(!oneTimeTimer)
                {
                    currentTime = 0f;
                }
            }
        }
    }
}
