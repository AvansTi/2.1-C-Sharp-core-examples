using System;

namespace FireAlarmCore
{
    class Program
    {
        static void Main(string[] args)
        {
            FireAlarm myFireAlarm = new FireAlarm();

            // Create an instance of the class that will be handling the event. Note that 
            // it receives the class that will fire the event as a parameter. 

            FireHandlerClass myFireHandler = new FireHandlerClass(myFireAlarm);

            //use our class to raise a few events and watch them get handled
            myFireAlarm.ActivateFireAlarm("Kitchen", 3);
            myFireAlarm.ActivateFireAlarm("Study", 1);
            myFireAlarm.ActivateFireAlarm("Porch", 5);
            Console.ReadLine();
        }
    }
}
