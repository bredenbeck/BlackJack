using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace BlackJack
{
    public class PlayingCard
    {
        #region Properties
        public CardColor Color { get; set; }
        public CardValue Value { get; set; }
        public bool Visible { get; set; }
#endregion


        #region Constructors
        public PlayingCard(CardColor color, CardValue value, bool visible)
        {
            Color = color;
            Value = value;
            Visible = visible;
        }
        #endregion

        #region Methods

        public override string ToString()
        {
            if (Visible)
            {
                return $"{Value} of {Color}";
            }
            else
            {
                return "Hidden";
            }
        }

        public bool Equals(PlayingCard other)
        {
            return Value == other.Value && Color == other.Color;
        }

        public override bool Equals(object? obj)
        {
            if (obj is PlayingCard other)
            {
                return Equals(other);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(PlayingCard left, PlayingCard right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlayingCard left, PlayingCard right)
        {
            return !left.Equals(right);
        }

        public static bool operator >(PlayingCard left, PlayingCard right)
        {
            if (left.Value == right.Value)
            {
                return (int)left.Color > (int)right.Color;
            }

            return left.Value > right.Value;
        }
        public static bool operator <(PlayingCard left, PlayingCard right)
        {
            if (left.Value == right.Value)
            {
                return (int)left.Color < (int)right.Color;
            }

            return left.Value < right.Value;
        }

        public void Flip()
        {
            Visible = !Visible;
        }
        #endregion
    }
}
