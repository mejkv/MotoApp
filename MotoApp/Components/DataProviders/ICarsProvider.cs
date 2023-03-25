using MotoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Components.DataProviders
{
    public interface ICarsProvider
    {
        //selct
        List<string> GetUniqueCarColors();

        decimal GetMinimumPriceOfAllCars();

        List<Car> GetSpecificColumns();

        string AnonymousClass();

        //order by
        List<Car> OrderByName();

        List<Car> OrderByNameDescending();

        List<Car> OrderByColorAndName();

        List<Car> OrderByColorAndNameDesc();

        //where
        List<Car> WhereStartsWith(string prefix);

        List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

        List<Car> WhereColorIs(string color);

        //first, last, single

        Car FirstByColor(string color);

        Car FirstByColorOrDefault(string color);

        Car? FirstOrDefaultByColorWithDefault(string color);

        Car LastByColor(string color);

        Car SingleById(int id);

        Car? SingleOrDefaultById(int id);

        //take
        List<Car> TakeCars(int howMany);

        List<Car> TakeCars(Range range);

        List<Car> TakeCarsWithNameStartsWith(string prefix);

        //skip
        List<Car> SkipCars(int howMany);

        List<Car> SkipCarsWhileNameStartsWith(string prefix);

        //distinct
        List<string> DistinctAllColors();

        List<Car> DistinctByColor();

        //chunk
        List<Car[]> ChunkChars(int size);

        //skip and take
        List<Car> SkipAndTake(int howManySkip, int howManyTake);
    }
}
