using UnityEngine;

namespace Pool
{
    public struct PoolData
    {
        public MonoBehaviour obj;
        public string key;

        public PoolData(MonoBehaviour obj, string key)
        {
            this.obj = obj;
            this.key = key;
        }


        public override bool Equals(object objT)
        {
            if (objT is PoolData otherData)
            {
                return obj == otherData.obj && key == otherData.key;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (obj, key).GetHashCode();
        }
    }
}