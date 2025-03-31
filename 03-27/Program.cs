using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_27
{
    class Program
    {
        static serverConnection connection;
        void Main(string[] args)
        {
            connection = new serverConnection("http://localhost:3000");
            start();
            Console.ReadKey();

        }

        void start()
        {
            Console.WriteLine("mit szeretnél csinálni?[vásárolni,nézelődni,törölni]");
            string readline = Console.ReadLine();
            if (readline == "vásárolni")
            {
                
                Console.WriteLine(readline);

                Console.WriteLine("kolbasz nevet add meg :");
                string name = Console.ReadLine();
                Console.WriteLine("kolbasz arat add meg: ");
                int ara = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("kolbasz ertekeleset add meg: ");
                float ertekeles = float.Parse(Console.ReadLine());
                Console.WriteLine(name);
                Console.WriteLine(ara);
                Console.WriteLine(ertekeles);
                
            
                    
            }
            if (readline == "nézelődni")
            {

            }
            if (readline == "törölni")
            {

            }
            else
            {

            }
        }


        private void getKolbasz()
        {
            throw new NotImplementedException();
        }
    }
}
