namespace Homework1
{
    internal class Task3
    {
        private int _size;
        private int[,,] _cube;

        public Task3(int[,,] cube)
        {
            _size = cube.GetLength(0);
            _cube = cube;
        }
        public Task3(int size = 3)
        {
            _size = size;
            _cube = new int[_size, _size, _size];
        }
        public int[,,] GenerateVoids()
        {
            Random random = new Random();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    for (int k = 0; k < _size; k++)
                    {
                        _cube[i, j, k] = random.Next(2);
                    }
                }
            }
            return _cube;
        }
        public void FindThroughLinearHole()
        {
            //vertical/horizontals perralels
            List<(int, int)> XZlines = new List<(int, int)>();//x,z - coords
            for (int x = 0; x < _size; x++)
            {
                for (int z = 0; z < _size; z++)
                {
                    XZlines.Add((x, z));
                    for (int y = 0; y < _size; y++)
                    {
                        if (_cube[x, y, z] == 0)
                        {
                            XZlines.Remove((x, z));
                            break;
                        }

                    }
                }
            }
            List<(int, int)> XYlines = new List<(int, int)>();//x,y - coords
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    XYlines.Add((x, y));
                    for (int z = 0; z < _size; z++)
                    {
                        if (_cube[x, y, z] == 0)
                        {
                            XYlines.Remove((x, y));
                            break;
                        }

                    }
                }
            }
            List<(int, int)> YZlines = new List<(int, int)>();//y,z - coords
            for (int y = 0; y < _size; y++)
            {
                for (int z = 0; z < _size; z++)
                {
                    YZlines.Add((y, z));
                    for (int x = 0; x < _size; x++)
                    {
                        if (_cube[x, y, z] == 0)
                        {
                            YZlines.Remove((y, z));
                            break;
                        }

                    }
                }
            }

            //Plane dizgonals
            //XYDiagonals
            //Top left to bottom right
            List<(int, int, int)> XYDiagonal = new List<(int, int, int)>();
            for (int z = 0; z < _size; z++)
            {
                for (int y = 0; y < _size; y++)
                {
                    (int, int, int) listCoord = (0, 0, 0);
                    for (int x = 0; x < _size; x++)
                    {

                        if (x == 0 || (x + y) % _size == 0)
                        {
                            XYDiagonal.Add((x, (x + y) % _size, z));
                            listCoord = (x, (x + y) % _size, z);
                        }
                        if (_cube[x, (x + y) % _size, z] == 0)
                        {
                            XYDiagonal.Remove(listCoord);
                            break;
                        }
                    }
                }
            }
            //Bottom left to top right
            List<(int, int, int)> XYDiagonal1 = new List<(int, int, int)>();
            for (int z = 0; z < _size; z++)
            {
                for (int x = _size - 1; x >= 0; x--)
                {
                    (int, int, int) listCoord = (0, 0, 0);
                    for (int y = 0; y < _size; y++)
                    {

                        if (((x - y) % _size + _size) % _size == _size - 1 || y == 0)
                        {
                            XYDiagonal1.Add((((x - y) % _size + _size) % _size, y, z));
                            listCoord = (((x - y) % _size + _size) % _size, y, z);
                        }
                        if (_cube[((x - y) % _size + _size) % _size, y, z] == 0)
                        {
                            XYDiagonal1.Remove(listCoord);
                            break;
                        }
                    }
                }
            }
            //XzDiagonals
            //Top left to bottom right
            List<(int, int, int)> XZDiagonal = new List<(int, int, int)>();
            for (int y = 0; y < _size; y++)
            {
                for (int z = 0; z < _size; z++)
                {
                    (int, int, int) listCoord = (0, 0, 0);
                    for (int x = 0; x < _size; x++)
                    {

                        if (x == 0 || (x + y) % _size == 0)
                        {
                            XZDiagonal.Add((x, (x + y) % _size, z));
                            listCoord = (x, (x + y) % _size, z);
                        }
                        if (_cube[x, (x + y) % _size, z] == 0)
                        {
                            XZDiagonal.Remove(listCoord);
                            break;
                        }
                    }
                }
            }
            //Bottom left to top right
            List<(int, int, int)> XZDiagonal1 = new List<(int, int, int)>();
            for (int y = 0; y < _size; y++)
            {
                for (int x = _size - 1; x >= 0; x--)
                {
                    (int, int, int) listCoord = (0, 0, 0);
                    for (int z = 0; z < _size; z++)
                    {

                        if (((x - y) % _size + _size) % _size == _size-1 || y == 0)
                        {
                            XZDiagonal1.Add((((x - y) % _size + _size) % _size, y, z));
                            listCoord = (((x - y) % _size + _size) % _size, y, z);
                        }
                        if (_cube[((x - y) % _size + _size) % _size, y, z] == 0)
                        {
                            XZDiagonal1.Remove(listCoord);
                            break;
                        }
                    }
                }
            }

            //YZDiagonals
            //Top left to bottom right
            List<(int, int, int)> YZDiagonal = new List<(int, int, int)>();
            for (int x = 0; x < _size; x++)
            {
                for (int z = 0; z < _size; z++)
                {
                    (int, int, int) listCoord = (0, 0, 0);
                    for (int y = 0; y < _size; y++)
                    {

                        if (x == 0 || (x + y) % _size == 0)
                        {
                            YZDiagonal.Add((x, (x + y) % _size, z));
                            listCoord = (x, (x + y) % _size, z);
                        }
                        if (_cube[x, (x + y) % _size, z] == 0)
                        {
                            YZDiagonal.Remove(listCoord);
                            break;
                        }
                    }
                }
            }
            //Bottom left to top right
            List<(int, int, int)> YZDiagonal1 = new List<(int, int, int)>();
            for (int x = 0; x < _size; x++)
            {
                for (int y = _size - 1; y >= 0; y--)
                {
                    (int, int, int) listCoord = (0, 0, 0);
                    for (int z = 0; z < _size; z++)
                    {

                        if (((x - y) % _size + _size) % _size == _size - 1 || y == 0)
                        {
                            YZDiagonal1.Add((((x - y) % _size + _size) % _size, y, z));
                            listCoord = (((x - y) % _size + _size) % _size, y, z);
                        }
                        if (_cube[((x - y) % _size + _size) % _size, y, z] == 0)
                        {
                            YZDiagonal1.Remove(listCoord);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("\n``````````````\nTask 3:");
            Console.WriteLine("\nOY parrallel through lines:");
            for (int i = 0; i < XZlines.Count; i++)
                Console.WriteLine($"\tstart point ({XZlines[i].Item1}, 0, {XZlines[i].Item2}); end point ({XZlines[i].Item1}, {_size - 1}, {XZlines[i].Item2})");

            Console.WriteLine("\nOZ through lines:");
            for (int i = 0; i < XYlines.Count; i++)
                Console.WriteLine($"\tstart point ({XYlines[i].Item1}, {XYlines[i].Item2}, 0); end point ({XYlines[i].Item1}, {XYlines[i].Item2}, {_size - 1})");

            Console.WriteLine("\nOX through lines:");
            for (int i = 0; i < YZlines.Count; i++)
                Console.WriteLine($"\tstart point (0, {YZlines[i].Item1}, {YZlines[i].Item2}); end point ({_size - 1}, {YZlines[i].Item1}, {YZlines[i].Item2})");


            Console.WriteLine("\nXY panel diagonals parrallel through lines:");
            for (int i = 0; i < XYDiagonal.Count; i++)
                Console.WriteLine($"\tstart point ({XYDiagonal[i].Item1}, {XYDiagonal[i].Item2}, {XYDiagonal[i].Item3}); " +
                    $"end point ({_size - 1 - XYDiagonal[i].Item2}, {_size - 1 - XYDiagonal[i].Item1}, {XYDiagonal[i].Item3})");
            for (int i = 0; i < XYDiagonal1.Count; i++)
                Console.WriteLine($"\tstart point ({XYDiagonal1[i].Item1}, {XYDiagonal1[i].Item2}, {XYDiagonal1[i].Item3}); " +
                    $"end point ({XYDiagonal1[i].Item2}, {XYDiagonal1[i].Item1}, {XYDiagonal1[i].Item3})");

            Console.WriteLine("\nXZ panel diagonals parrallel through lines:");
            for (int i = 0; i < XZDiagonal.Count; i++)
                Console.WriteLine($"\tstart point ({XZDiagonal[i].Item1}, {XZDiagonal[i].Item2}, {XZDiagonal[i].Item3}); " +
                    $"end point ({_size - 1 - XZDiagonal[i].Item3}, {XZDiagonal[i].Item1}, {_size - 1 - XZDiagonal[i].Item1})");
            for (int i = 0; i < XZDiagonal1.Count; i++)
                Console.WriteLine($"\tstart point ({XZDiagonal1[i].Item1}, {XZDiagonal1[i].Item2}, {XZDiagonal1[i].Item3}); " +
                    $"end point ({XZDiagonal1[i].Item3}, {XZDiagonal1[i].Item2}, {XZDiagonal1[i].Item1})");

            Console.WriteLine("\nYZ panel diagonals parrallel through lines:");
            for (int i = 0; i < YZDiagonal.Count; i++)
                Console.WriteLine($"\tstart point ({YZDiagonal[i].Item1}, {YZDiagonal[i].Item2}, {YZDiagonal[i].Item3}); " +
                    $"end point ({YZDiagonal[i].Item1}, {_size - 1 - YZDiagonal[i].Item3}, {_size - 1 - YZDiagonal[i].Item2})");
            for (int i = 0; i < YZDiagonal1.Count; i++)
                Console.WriteLine($"\tstart point ({YZDiagonal1[i].Item1}, {YZDiagonal1[i].Item2}, {YZDiagonal1[i].Item3}); " +
                    $"end point ({YZDiagonal1[i].Item1}, {YZDiagonal1[i].Item3}, {YZDiagonal1[i].Item2})");
        }
    }
}
