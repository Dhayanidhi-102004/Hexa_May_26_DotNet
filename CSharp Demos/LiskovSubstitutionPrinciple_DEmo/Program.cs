namespace LiskovSubstitutionPrinciple_DEmo
{
    /// <summary>
    ///  It states that objects of a superclass should be replaceable with objects of its subclasses without affecting the correctness 
    ///  of the program. That means a subclass should completely adhere to the behavior expected by the superclass.
    ///  The Liskov Substitution Principle encourages a design where subclasses are substitutable for their base classes.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            IFruit fruit = new Orange();
            Console.WriteLine($"Colour of the Orange { fruit.GetColor()} ");

            fruit = new Apple();
            Console.WriteLine($" Colour of Apple {fruit.GetColor()}");

            //Apple apple = new Orange();
            //Console.WriteLine(apple.GetColor());
            Console.ReadLine();
        }
    }

    public interface IFruit
    {
        string GetColor();
    }
    public class Apple : IFruit
    {
        public string GetColor()
        {
            return "Red";
        }
    }

    public class Orange : IFruit
    {
        public string GetColor()
        {
            return "Orange";
        }
    }


    //public class Apple
    //{
    //    public virtual string GetColor()
    //    {
    //        return "Red";
    //    }
    //}

    //public class Orange:Apple
    //{
    //    public override string GetColor()
    //    {
    //        return "Orange";
    //    }
    //}
}
