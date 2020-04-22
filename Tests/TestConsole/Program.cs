using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Player player1 = new Player();
            //player1.Name = "Georgy";
            //player1.Birthday = new DateTime(1993, 04, 17, 0, 0, 0);

            Console.Write("Введите фамилию >");
            var surname = Console.ReadLine();

            Player player1 = new Player(surname, new DateTime(1993, 04, 17));
            

            Console.WriteLine(player1.Name);

            Console.ReadLine();
        }
    }

    internal class Player
    {
        private string _Name;
        private DateTime _Birthday;

        public string GetName()
        {
            return _Name;
        }

        public string SetName(string Name)
        {
            _Name = Name;
        }

        public Player()
        {

        }

        public Player(string Name)
        {
            this._Name = Name;
            _Birthday = DateTime.Now;
        }

        public Player(string Name, DateTime Birthday)
            :this(Name)        
        {
            //this.Name = Name;
            this._Birthday = Birthday;

        }
    }


}
