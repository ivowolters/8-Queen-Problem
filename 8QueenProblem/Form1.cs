using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace _8QueenProblem
{
    public partial class Form1 : Form
    {
        private List<Place> _places = new List<Place>();
        private List<Solution> _solutions = new List<Solution>();
        private Random _random = new Random();

        public Form1()
        {
            addPlaces();

            while (_solutions.Count != 96)
            {
                checkQueenz();
            }
        }

        private void checkQueenz()
        {
            if (_places.Count == 8)
            {
                List<Place> add = new List<Place>();
                foreach (var place in _places)
                {
                    add.Add(place);
                }
                
                _solutions.Add(new Solution(add));
            }

            int i = 1;

            while (_places.Count - i >= 0)
            {
                Place old = _places[_places.Count - i];
                Place newPlace = new Place(old.Row, old.Collumn);
                _places.RemoveAt(_places.Count - i);

                while (newPlace.Row != 8 || newPlace.Collumn != 8)
                {
                    if (newPlace.Collumn < 8) newPlace.Collumn++;
                    else newPlace.Row++;

                    bool straigth = false;
                    bool slantWise = false;

                    foreach (var place in _places)
                    {
                        if (checkStraigth(newPlace, place)) straigth = true;
                        if (checkSlantWise(newPlace, place)) slantWise = true;
                    }

                    if (!straigth && !slantWise)
                    {
                        _places.Add(newPlace);
                        addPlaces();
                    }

                    else if (newPlace.Row == 8 && newPlace.Collumn == 8) _places.Add(old);
                }
            }
        }

        private void addPlaces()
        {
            for (int row = 1; row <= 8; row++)
            {
                for (int collumn = 1; collumn <= 8; collumn++)
                {
                    Place newPlace = new Place(row, collumn);

                    if(_places.Count == 0) _places.Add(newPlace);

                    bool straigth = false;
                    bool slantWise = false;
                    
                    foreach (var VARIABLE in _places)
                    {
                        if (checkStraigth(newPlace, VARIABLE)) straigth = true;
                        if (checkSlantWise(newPlace, VARIABLE)) slantWise = true;
                    }
                    if (!straigth && !slantWise) _places.Add(newPlace);
                }
            }
        }

        private void makeTable()
        {

        }

        public void removePlaces(Place place)
        {
            for (int i = 0; i <= _places.Count - 1; i++)
            {
                bool straigth = checkStraigth(place, _places[i]);
                bool slantwise = checkSlantWise(place, _places[i]);
                if (straigth || slantwise) _places.RemoveAt(i);
            }
        }

        private bool checkStraigth(Place create, Place old)
        {
            bool inRow = false;
            bool inCollumn = false;

            if (create.Row == old.Row) inRow = true;
            if (create.Collumn == old.Collumn) inCollumn = true;

            if (inRow || inCollumn) return true;
            return false;
        }

        private bool checkSlantWise(Place create, Place old)
        {
            bool slantWise = false;
            int rowDifference = create.Row - old.Row;
            int columnDifference = create.Collumn - old.Collumn;

            if (rowDifference == columnDifference || (create.Row + create.Collumn) == (old.Row + old.Collumn)) slantWise = true;

            return slantWise;
        }
    }
}
