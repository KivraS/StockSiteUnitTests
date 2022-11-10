namespace StockSite.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2,3,5)]
        [InlineData(-4, 4, 0)]
        public void Test1(int x,int y,int expected)
        {
            var result = addNumbers(x, y);
            Assert.Equal(expected, result);
        }
        public int addNumbers(int x, int y)
        {
            return x + y;
        }
    }
}