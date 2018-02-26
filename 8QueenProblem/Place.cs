using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QueenProblem
{
    public class Place
    {
        public int Row;
        public int Collumn;

        public Place(int row, int collumn)
        {
            Row = row;
            Collumn = collumn;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
