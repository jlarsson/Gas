using System.Collections.Generic;

namespace Gas
{
    public class ListElementAdapterViewTypes
    {
        private readonly int _reserveCount;
        private readonly Dictionary<string, int> _viewTypes = new Dictionary<string, int>();

        public ListElementAdapterViewTypes(int reserveCount = 1) : this(new Dictionary<string, int>(), reserveCount)
        {
        }

        private ListElementAdapterViewTypes(Dictionary<string, int> viewTypes, int reserveCount)
        {
            _viewTypes = viewTypes;
            _reserveCount = reserveCount;
        }

        public int GetViewType(string typeTag)
        {
            return _viewTypes[typeTag];
        }

        public void Upgrade(IEnumerable<string> upgradeTypeTags)
        {
            foreach (var upgradeTypeTag in upgradeTypeTags)
            {
                if (!_viewTypes.ContainsKey(upgradeTypeTag))
                {
                    _viewTypes.Add(upgradeTypeTag, _viewTypes.Count);
                }
            }
            if (_viewTypes.Count > _reserveCount)
            {
                throw new GasException("The adapter will contain more viewtypes that allowed.");
            }
        }

        public int GetViewTypeCount()
        {
            var n = _viewTypes.Count;
            n = n > _reserveCount ? n : _reserveCount;
            return n < 1 ? 1 : n;
        }
    }
}