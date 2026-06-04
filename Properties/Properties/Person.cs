using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Person
    {
        int id = 20;
        string name;
        double salary;

        public int _Id
        {
         
            get
            {
                return id;
            }
             set
            {
                id = value;
            }
        }

        public string _Name
        {
            get
            {
                if(name==null)
                {
                    return "No name";
                }
                else
                {
                    return name;
                }
            }
            set
            {
                name = value;
            }
        }

        public double _Salary//auto property
        {
            get; //set;
        } = 50000;
    }

    
    
}
