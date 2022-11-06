using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SWE310_SWE2004469_A1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String input;

            while (true)
            {
                Console.WriteLine("///Hello There! I'm the First Aid Bot!");
                Console.WriteLine("///Did you see someone injured or fallen on the ground?");

                for (int i = 0; i < 7; i++)
                {
                    input = Console.ReadLine();
                    if (FetchAnswer(i, booleanAnswer(input)) == false)
                        break;
                }
                break;
            }
            Console.ReadKey();
        }

        private static bool booleanAnswer(String input)
        {
            while(true)
            {
                if (input == "y" || input == "yes" || input == "ya" || input == "ye" || input == "Y" || input == "Ya" || input == "Yes" || input == "YES" ||
                input == "Yup" || input == "yup" || input == "Yaa" || input == "positive" || input == "1" || input == "Yep" || input == "affirmative" || input == "YESS" ||
                input == "yess")
                {
                    return true;
                }
                else if (input == "n" || input == "no" || input == "nope" || input == "negative" || input == "noo" || input == "0")
                {
                    return false;
                }
                else
                {
                    apologyLetter();
                    input = Console.ReadLine();
                }
            }
            
        }

        private static bool FetchAnswer(int step, bool input)
        {
            //Identify Danger
            if (step == 0)
            {
                if (input == true)
                {
                    Console.WriteLine("///First, Check for Danger. Is there any traffic, fire, electricity that may hurt you, the injured person, or the crowd?");
                    return true;
                }
                else
                {
                    Console.WriteLine("///Are you the one injured?");
                    if (booleanAnswer(Console.ReadLine()) == true)
                    {
                        return FetchAnswer('P', true);
                    }
                    else
                    {
                        Console.WriteLine("///Then you don't need me, you need a companion to talk with you.");
                        return false;
                    }

                }
            }
            //Check for Response
            if (step == 1)
            {
                if (input == false)
                {
                    Console.WriteLine("///Is his/her eyes closed?");
                    if (booleanAnswer(Console.ReadLine()) == true)
                    {
                        Console.WriteLine("///Tap on his/her shoulder and shout at him/her. Is he/she responding?");
                        if (booleanAnswer(Console.ReadLine()) == true)
                        {
                            Console.WriteLine("///Ask whether they need any kind of assistance. Wake me if his/her condition deteriorates.");
                            return false;
                        }
                        else
                        {
                            Console.WriteLine("///Pinch his/her earlobe, or do the sternum rub. Is he/she responding?");
                            if (booleanAnswer(Console.ReadLine()) == true)
                            {
                                Console.WriteLine("///Ask whether they need any kind of assistance. Wake me if his/her condition deteriorates.");
                                return false;
                            }
                            else
                            {
                                Console.WriteLine("///Appoint someone to call for ambulance, get an AED, and evacuate the crowd. Are you able to do that?");
                                return true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("///Ask whether they need any kind of assistance. Wake me if his/her condition deteriorates.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("///Try to mitigate the danger. Is the danger cleared?");
                    if (booleanAnswer(Console.ReadLine()) == true)
                    {
                        return FetchAnswer(1, false);
                    }
                    else
                    {
                        Console.WriteLine("///Call the emergency services and stand clear of the danger.");
                        return false;
                    }
                }
            }
            //Shout for Help
            if (step == 2)
            {
                if (input == true)
                {
                    Console.WriteLine("///Open up his airway by lifting up his/her jaw using your finger, and lightly pressing down on their forehead.");
                    Console.WriteLine("///Are you able to do that?");
                    return true;
                }
                else
                {
                    Console.WriteLine("///Can you call the emergency services on loudspeaker?");
                    if(booleanAnswer(Console.ReadLine()) == true)
                    {
                        Console.WriteLine("///Call them and try your best to explain the situation.");
                        return FetchAnswer(2, true);
                    }
                    else
                    {
                        Console.WriteLine("///Are you in a hostage situation?");
                        if(booleanAnswer(Console.ReadLine()) == true)
                        {
                            Console.WriteLine("///You are in a dangerous situation. Contact the police department immediately by acting like you're ordering pizza.");
                            return false;
                        }
                        else
                        {
                            Console.WriteLine("///Call the emergency services immediately and return to attend to the casualty immediately after you've called.");
                            return FetchAnswer(2, true);
                        }
                    }
                }
            }
            //Open Airway
            if (step == 3)
            {
                if(input == true)
                {
                    Console.WriteLine("///Check if he/she is still breathing by placing your ear near the casualty to listen for breathing, and looking at his/her chest for movement.");
                    Console.WriteLine("///Is he/she breathing?");
                    return true;
                }
                else
                {
                    Console.WriteLine("///Is the casualty lying down at an awkward position?");
                    if (booleanAnswer(Console.ReadLine()) == true)
                    {
                        Console.WriteLine("///Do you suspect that there is a spinal injury? (Caused by vehicle collision, high fall, or any trauma)");
                        if(booleanAnswer(Console.ReadLine())==true)
                        {
                            Console.WriteLine("///Move the casualty carefully so that it lies flat on their back.");
                            Console.WriteLine("///Are you able to do that?");
                            if(booleanAnswer(Console.ReadLine())==true)
                            {
                                return FetchAnswer(3, true);
                            }
                            else
                            {
                                Console.WriteLine("///Wait for the emergency services to arrive.");
                                return false;
                            }

                        }
                        else
                        {
                            Console.WriteLine("///Move the casualty so that it lies flat on their back.");
                            return FetchAnswer(3, true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("///Unable to proceed, please wait for emergency services.");
                        return false;
                    }
                }
            }
            //Check for Breathing
            if (step == 4)
            {
                if (input == false)
                {
                    Console.WriteLine("///I'm so sorry, Can you repeat?");
                    return true;
                }
                else
                {
                    Console.WriteLine("///Constantly monitor for his/her breathing. Wake me up if his/her conditions deteriorate.");
                    return false;
                }
            }
            //CPR or Circulation
            if (step == 5)
            {
                Console.WriteLine("///Start CPR. Your dominant hand should be grabbing the other hand which is open, and set it on the casualty's chest.");
                Console.WriteLine("///You should press as hard as possible (3-5 inches deep), according to the tempo below.");
                Console.WriteLine("///Press any key when you're ready. Stop CPR when the casualty starts breathing.");
                Console.ReadKey();

                Console.WriteLine("3...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("2...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("1...");
                System.Threading.Thread.Sleep(1000);

                while (true)
                {
                    for (int i = 0; i < 75; i++)
                    {
                        Console.WriteLine("///PRESS");
                        System.Threading.Thread.Sleep(545);
                        Console.WriteLine("///press");
                        System.Threading.Thread.Sleep(545);
                    }
                    Console.WriteLine("///Is the casualty awake?");
                    if (booleanAnswer(Console.ReadLine()) == true)
                    {
                        break;
                    }
                    Console.WriteLine("///Is the casualty breathing again?");
                    if (booleanAnswer(Console.ReadLine()) == true)
                    {
                        break;
                    }
                    Console.WriteLine("///Has the ambulance arrived?");
                    if (booleanAnswer(Console.ReadLine()) == true)
                    {
                        break;
                    }
                    Console.WriteLine("///Are you tired?");
                    if (booleanAnswer(Console.ReadLine()) == true)
                    {
                        break;
                    }
                    Console.WriteLine("///Continue CPR.");

                    Console.WriteLine("///Press any key when you're ready. Stop CPR when the casualty starts breathing.");
                    Console.ReadKey();

                    Console.WriteLine("3...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("2...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("1...");
                    System.Threading.Thread.Sleep(1000);
                }
                Console.WriteLine("///Continue monitoring the casualty. Wake me if his/her conditions deteriorate.");
                return false;
            }
            else
            {
                Console.WriteLine("///ERROR: STEP_COUNTER UNDEFINED.");
                return false;
            }
        }

        private static void apologyLetter()
        {
            Random rnd = new Random();


            int num = rnd.Next();

            switch(num%5)
            {
                case 0:
                    Console.WriteLine("I don't understand what you say. Can you try again?");
                    break;
                case 1:
                    Console.WriteLine("Sorry, I don’t understand that. Please try again please.");
                    break;
                case 2:
                    Console.WriteLine("I am so sorry, can you simplify your answer please?");
                    break;
                case 3:
                    Console.WriteLine("My sincere apologies, but 'yes' or 'no' works best for me");
                    break;
                case 4:
                    Console.WriteLine("Can you try again, but simpler? Sorry.");
                    break;
            }


        }

    }
}

