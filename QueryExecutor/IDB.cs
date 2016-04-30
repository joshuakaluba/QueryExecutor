using System.Collections.Generic;

/// <summary>
/// Joshua Kaluba
/// </summary>

namespace QueryExecutor
{
    interface IDB
    {        
        void Open();
        void Close();
        IEnumerable<T> Query<T>(string Query);
        //Using a template class in the IEnumerable class to allow multiple objects
        void NonQuery(string Query);
        object Scalar(string Query);
    }
}
