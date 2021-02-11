/*
 * Author: Jordan Taylor
 * Date: 02 / 11 / 2021
 * Description: Tests bear creations (toy and real) based on an Adaptor Pattern UML.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_5___Adapter_Practice
{
    class TeddyBear : IToyBear
    {
        public void hug()
        {
            Console.WriteLine("Hugs you! :)");
        }
    }

    class Grizzly : IBear
    {
        void IBear.hibernate()
        {
            Console.WriteLine("Goes to sleep.. Zzzzzzz..");
        }

        void IBear.maul()
        {
            Console.WriteLine("Mauls you! >:D");
        }
    }

    class BearAdapter : IToyBear
    {
        private IBear bear;

        public BearAdapter(IBear b)
        {
            this.bear = b;
        }

        public void hug()
        {
            bear.maul();
        }
    }

    interface IToyBear
    {
        void hug();
    }

    interface IBear
    {
        void hibernate();
        void maul();
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBear bear = new Grizzly();
            IToyBear toy = new TeddyBear();
            IToyBear toyAdapt = new BearAdapter(bear);

            Console.WriteLine("Testing with IBear..");
            bear.hibernate();
            bear.maul();

            Console.WriteLine();

            Console.WriteLine("Testing with IToyBear..");
            toy.hug();

            Console.WriteLine();


            Console.WriteLine("Testing with IToyBear with BearAdapter..");
            toyAdapt.hug();

            Console.ReadKey();
        }
    }
}
