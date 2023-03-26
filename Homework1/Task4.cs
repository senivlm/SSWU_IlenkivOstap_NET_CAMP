
namespace Homework1
{
    internal class Tensor
    {
        //припустимо що прийматимемо лише цілочисельні типи
        private object _data;
        private Type _type;
        public Tensor(object data)
        {
            _data = data;
            _type = data.GetType();
        }
        public bool Compare(Tensor other, bool fullComparing = true)
        {
            if (other == null || other._type != _type)
                return false;
            else
            {
                if (_type.IsArray)
                {
                    if (_type.GetArrayRank() != other._type.GetArrayRank())
                        return false;
                    else
                    {
                        if(fullComparing)
                        {
                            Array arrayA = (Array)_data;
                            Array arrayB = (Array)other._data;

                            for (int i = 0; i < arrayA.Rank; i++)
                            {
                                if (arrayA.GetLength(i) != arrayB.GetLength(i))
                                {
                                    return false;
                                }
                            }
                        }
                        
                        return true;
                    }
                }

                return true;
            }
        }

    }
}
