using System.Collections.Generic;
using System.Linq;
using BL.Services.Provider.Interfaces;
using DAL.ContextData;

namespace SupportWheel.BusinessImplementations.Services
{
    public class EngineerPool : IEngineerPool
    {
        private readonly IRandomAdapter _randomAdapter;

        private readonly List<Engineer> _engineersAvailable;
        private readonly List<Engineer> _engineersPullable;

        public EngineerPool(IRandomAdapter randomAdapter)
        {
            _engineersAvailable = new List<Engineer>();
            _engineersPullable = new List<Engineer>();
            _randomAdapter = randomAdapter;
        }

        public int Available => _engineersAvailable.Count;

        public int Pullable => _engineersPullable.Count;

        public void Add(List<Engineer> engineers)
        {
            _engineersAvailable.AddRange(engineers);
            _engineersPullable.AddRange(engineers);
        }

        public Engineer PullRandom()
        {
            if (_engineersPullable.Any())
            {
                var candidate = _engineersPullable.ElementAt(_randomAdapter.Next(_engineersPullable.Count));
                _engineersPullable.Remove(candidate);
                return candidate;
            }
            else
            {
                return null;
            }
        }

        public void Remove(Engineer engineer)
        {
            _engineersAvailable.Remove(engineer);
        }

        public void ResetPullables()
        {
            _engineersPullable.Clear();
            _engineersPullable.AddRange(_engineersAvailable);
        }
    }
}
