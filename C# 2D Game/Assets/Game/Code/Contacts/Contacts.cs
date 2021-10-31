using UnityEngine;

namespace Game.Code.Contacts
{
    public class Contacts
    {
        public Collider2D _collider;
        public ContactPoint2D[] _contactsCollaidersArray;
        private int _countIndex;
        public bool _normalRight;
        public bool _normalLeft;
        public bool _normalDown;

        public Contacts(Collider2D collider)
        {
            _collider = collider;
            _contactsCollaidersArray = new ContactPoint2D[10];
        }

        public void Execute()
        {
            _normalRight = false;
            _normalLeft = false;
            _normalDown = false;
            _countIndex = _collider.GetContacts(_contactsCollaidersArray);
            for (int i = 0; i < _countIndex; i++)
            {
                if (_contactsCollaidersArray[i].normal.x == -1)
                {
                    _normalRight = true;
                }

                if (_contactsCollaidersArray[i].normal.x == 1)
                {
                    _normalLeft = true;
                }
                //if (Mathf.Approximately(_contactsCollaidersArray[i].normal.y, -1))
                if (Mathf.Approximately(_contactsCollaidersArray[i].normal.y, 1))
                {
                    _normalDown = true;
                }
            }
        }
    }
}