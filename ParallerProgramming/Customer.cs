using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ParallerProgramming
{
    public class Customer : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            yield return 100;
            yield return 60;
            yield return 43;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
