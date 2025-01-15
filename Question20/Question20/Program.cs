using System;
using System.Threading.Tasks;

class Program
{
    
    private static Func<int> GenerateRandomNumber = () =>
    {
        Random rand = new Random();
        return rand.Next(1, 10001);  
    };

   
    private static Func<Func<int>, string> GenerateMessage = (generateNumberFunc) =>
    {
        int number = generateNumberFunc();  
        return $"The generated number is: {number}";
    };

    static void Main(string[] args)
    {
        
        TaskFactory taskFactory = new TaskFactory();

        
        taskFactory.StartNew(() =>
        {
            return GenerateRandomNumber(); 
        })
        .ContinueWith(task =>
        {          
            string result = GenerateMessage(GenerateRandomNumber);
            Console.WriteLine(result);  
        })
        .Wait();  
               
        Console.ReadLine();
    }
}
