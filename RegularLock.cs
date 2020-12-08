using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class RegularLock: ILockable
    {
        public RegularLock()
        {
            bool locked = false;
        }
        private bool locked;
        public void Lock()
        {
            locked = true;
        }
        public void Unlock()
        {
            locked = false;
        }
        public void Unlock(Door door)
        {

        }
        public bool isLocked()
        {
            return locked;
        }
        public bool isUnlocked()
        {
            return !locked;
        }


        public bool MayOpen()
        {
            return !locked;
        }

        public bool MayClose()
        {
            return true;
        }
    }
}
