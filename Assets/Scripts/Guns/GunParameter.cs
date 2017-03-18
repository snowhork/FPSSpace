using System;
using UnityEngine;

namespace Guns
{
    [Serializable]
    public class GunParameter
    {
        private int _balletsNum;
        [SerializeField] private int _balletsMaxNum = 30;
        [SerializeField] private int _balletsBoxNum = 150;
        [SerializeField] private float _coolTime = 0.5f;

        public int BalletsNum
        {
            get { return _balletsNum; }
            set { _balletsNum = value; }
        }

        public int BalletsMaxNum
        {
            get { return _balletsMaxNum; }
            set { _balletsMaxNum = value; }
        }

        public int BalletsBoxNum
        {
            get { return _balletsBoxNum; }
            set { _balletsBoxNum = value; }
        }

        public float CoolTime
        {
            get { return _coolTime; }
            set { _coolTime = value; }
        }

        public bool IsAbleToReload
        {
            get { return BalletsNum < BalletsMaxNum && BalletsBoxNum > 0; }
        }

        public GunParameter()
        {
            _balletsNum = _balletsMaxNum;
        }

        public int EmptyBalletsNum
        {
            get { return _balletsMaxNum - _balletsNum; }
        }

        public int ReloadBalletsNum
        {
            get
            {
                return BalletsBoxNum >= EmptyBalletsNum ? EmptyBalletsNum : BalletsBoxNum;
            }
        }

    }
}