using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public class Player
    {
        public Grid secretGrid;
        public Grid publicGrid;
        public List<Carrier> carriers = new List<Carrier>();
        public List<Battleship> battleships = new List<Battleship>();
        public List<Cruiser> cruisers = new List<Cruiser>();
        public List<Destroyer> destroyers = new List<Destroyer>();
        public List<Submarine> submarines = new List<Submarine>();

        public Player()
        {
            this.AddCarriers(1);
            this.AddBattleships(2);
            this.AddCruisers(3);
            this.AddSubmarines(4);
            this.AddDestroyers(5);
            
        }

        public void RemoveShip(Type shipType)
        {
            if (shipType == typeof(Carrier))
            {
                this.carriers.RemoveAt(0);
            }

            else if (shipType == typeof(Battleship))
            {
                this.battleships.RemoveAt(0);
            }

            else if (shipType == typeof(Cruiser))
            {
                this.cruisers.RemoveAt(0);
            }

            else if (shipType == typeof(Submarine))
            {
                this.submarines.RemoveAt(0);
            }

            else if (shipType == typeof(Destroyer))
            {
                this.destroyers.RemoveAt(0);
            }

        }

        private void AddCarriers(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.carriers.Add(new Carrier());
            }
        }

        private void AddBattleships(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.battleships.Add(new Battleship());
            }
        }

        private void AddCruisers(int amount)
        {
            // 1 carrier per player
            for (int i = 0; i < amount; i++)
            {
                this.cruisers.Add(new Cruiser());
            }
        }

        private void AddSubmarines(int amount)
        {
            // 1 carrier per player
            for (int i = 0; i < amount; i++)
            {
                this.submarines.Add(new Submarine());
            }
        }

        private void AddDestroyers(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.destroyers.Add(new Destroyer());
            }
        }
    }
}
