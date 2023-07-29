using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    class Heap
    {
        //Ключ(название) - значение(кол-во)
        private Dictionary<string, int> resources;
        public Dictionary<string, int> Resources
        {
            get { return resources; }
        }
        

        /// <summary>
        /// Конструктор для куч.(передавать в него нужно new Dictionary<string,int>(){{"a",2},{"b",4}} )
        /// </summary>
        /// <param name="resources"></param>
        public Heap(Dictionary<string, int> resources)
        {
            this.resources = resources;
        }

    }
}
