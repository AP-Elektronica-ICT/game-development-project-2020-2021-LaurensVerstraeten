using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowGame.Input
{
    public interface IInputReader
    {
        Vector2 ReadInput();
    }
}
