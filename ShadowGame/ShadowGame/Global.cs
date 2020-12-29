﻿using ShadowGame.Collision;
using ShadowGame.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame
{
    public static class Global
    {
        public static MoveCommand moveCommand = new MoveCommand();

        public static CollisionManager colMan = new CollisionManager();
    }
}