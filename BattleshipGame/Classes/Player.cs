using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public class Player
    {
        // Player's secret grid
        public Grid secretGrid;
        // Player's public grid
        public Grid publicGrid;
        // Ships
        public List<Carrier> carriers = new List<Carrier>();
        public List<Battleship> battleships = new List<Battleship>();
        public List<Cruiser> cruisers = new List<Cruiser>();
        public List<Destroyer> destroyers = new List<Destroyer>();
        public List<Submarine> submarines = new List<Submarine>();

        public Player()
        {
            // 1 carrier
            this.AddCarriers(1);
            // 2 battleships
            this.AddBattleships(2);
            // 3 cruisers
            this.AddCruisers(3);
            // 4 submarines
            this.AddSubmarines(4);
            // 5 destroyers
            this.AddDestroyers(5);       
        }
        // Add carriers
        private void AddCarriers(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.carriers.Add(new Carrier());
            }
        }
        // Add battleships
        private void AddBattleships(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.battleships.Add(new Battleship());
            }
        }
        // Add cruisers
        private void AddCruisers(int amount)
        {
            // 1 carrier per player
            for (int i = 0; i < amount; i++)
            {
                this.cruisers.Add(new Cruiser());
            }
        }
        // add submarines
        private void AddSubmarines(int amount)
        {
            // 1 carrier per player
            for (int i = 0; i < amount; i++)
            {
                this.submarines.Add(new Submarine());
            }
        }
        // add destroyers
        private void AddDestroyers(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.destroyers.Add(new Destroyer());
            }
        }
    }
}
