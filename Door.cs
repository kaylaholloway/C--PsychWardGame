using System;

namespace StarterGame
{

    public class Door
    {

        private Room roomA;
        private Room roomB;
        private bool closed;
        private ILockable theLock;

        /*public bool Closed
        {
            get
            {
                return closed;
            }
            set
            {
                closed = value; 
            }
        }
        public bool Open
        {
            get
            {
                return !closed;
            }
            set
            {
                closed = !value;
            }
        } */

       
        public Door(Room roomA, Room roomB)
        {
            this.roomA = roomA;
            this.roomB = roomB;
            closed = false;
            theLock = new RegularLock();
        }

        public Room room(Room from)
        {
            if (roomA == from)
            {
                return roomB;
            }
            else
            {
                return roomA;
            }
        }

        public static Door createDoor(Room roomA, Room roomB)
        {
            Door door = new Door(roomA, roomB);
            roomA.setExit(roomB.shortName,door);
            roomB.setExit(roomA.shortName, door);
            return door;
        }

        public void Unlock(Object key)
        {

        }
        public void Lock()
        {
            if (theLock != null)
            {
                theLock.Lock();
                //Console.WriteLine("This door is locked.");
            }
        }
        public void Unlock()
        {
            if (theLock != null)
            {
                theLock.Unlock();
            }
        }
        public bool Closed
        {
            get
            {
                return closed;
            }
            set
            {
                if (theLock != null)
                {
                    if (theLock.MayClose())
                    {
                        closed = value;
                    }

                    else
                    {
                        closed = true;
                    }
                }
            }
        }
        public bool Open
        {
            get
            {
                return !closed;
            }
            set
            {
                if (theLock != null)
                {
                    if (theLock.MayOpen())
                    {
                        closed = !value;
                    }
                    else
                    {
                        closed = !value;
                    }
                }
            }
        }
        public bool isLocked()
        {
            if (theLock != null)
            {
                //Console.WriteLine("This door is LOCKED!");
                return theLock.isLocked();
            }
            else
            {
                return false;
            }
        }
        public bool isUnlocked()
        {
            if (theLock != null)
            {
                return theLock.isUnlocked();
            }
            else
            {
                return true;
            }
        }
        public bool MayOpen()
        {
            if (theLock != null)
            {
                return theLock.MayOpen();
            }
            else
            {
                return true;
            }
        }
        public bool MayClose()
        {
            if (theLock != null)
            {
                return theLock.MayClose();
            }
            else
            {
                return true;
            }
        }

    }
}
