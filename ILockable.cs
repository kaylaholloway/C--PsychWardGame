using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    interface ILockable
    {
        void Lock();
        void Unlock();
        bool isLocked();
        bool isUnlocked();
        bool MayOpen();
        bool MayClose();
    }
}
