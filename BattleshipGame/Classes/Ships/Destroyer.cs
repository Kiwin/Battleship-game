﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame.Classes
{
    public class Destroyer : Ship
    {   public Destroyer() : base(2)
        {
        }

        public override string Name => "Destroyer";
    }
}
