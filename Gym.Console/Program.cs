using ctx = System.Console; 

namespace Gym.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var basketExamples = new BasketExamples();

            ctx.WriteLine("Basket 1:");
            ctx.WriteLine(basketExamples.Basket1().Cart.Display);
            ctx.WriteLine();
            
            ctx.WriteLine("Basket 2:");
            ctx.WriteLine(basketExamples.Basket2().Cart.Display);
            ctx.WriteLine();
            
            ctx.WriteLine("Basket 3:");
            ctx.WriteLine(basketExamples.Basket3().Cart.Display);
            ctx.WriteLine();
            
            ctx.WriteLine("Basket 4:");
            ctx.WriteLine(basketExamples.Basket4().Cart.Display);
            ctx.WriteLine();
            
            ctx.WriteLine("Basket 5:");
            ctx.WriteLine(basketExamples.Basket5().Cart.Display);
            
            ctx.ReadLine();
        }
    }
}