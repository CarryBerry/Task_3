using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Classes
{
    public class CallingInteraction
    {
        public RespondState AnswerChoice(PhoneNumber phoneNumbur, PhoneNumber phoneTarget, RespondState state)
        {
            int actionStopper = 1;

            Console.WriteLine("Incoming call from number: {0} to terminal with number {1}", phoneNumbur.ToString(), phoneTarget.ToString());

            while (actionStopper > 0)
            {
                Console.WriteLine("Answer? Y/N");
                var k = Console.ReadKey().Key;
                if (k == ConsoleKey.Y)
                {
                    actionStopper = 0;
                    state = RespondState.Accept;
                    Console.WriteLine();
                }
                else if (k == ConsoleKey.N)
                {
                    actionStopper = 0;
                    state = RespondState.Decline;
                    Console.WriteLine();
                }
            }
            return state;
        }

        public void CallingToNonExictentNumberMessage(PhoneNumber targetTelephoneNumber)
        {
            Console.WriteLine("This number: {0} does not exist", targetTelephoneNumber.ToString());
        }

        public void CallingToYourselfMessage(PhoneNumber targetTelephoneNumber)
        {
            Console.WriteLine("You are trying to call yourself.", targetTelephoneNumber.ToString());
        }
        public void AnswerMessage(RespondState state, PhoneNumber number, PhoneNumber target)
        {
            switch (state)
            {
                case RespondState.Accept:
                    Console.WriteLine("This number: {0} accepted call from number: {1}", number.ToString(), target.ToString());
                    break;

                case RespondState.Decline:
                    Console.WriteLine("This number: {0} declined call from number: {1}", number.ToString(), target.ToString());
                    break;

                case RespondState.Ending:
                    Console.WriteLine("Terminal with number: {0}, calling ended", number.ToString());
                    break;

                default:
                    break;
            }
        }
        public void CallingToDisconnectedTerminalMessage(PhoneNumber targetTelephoneNumber)
        {
            Console.WriteLine("This terminal: {0} - is disconnected", targetTelephoneNumber.ToString());
        }
    }
}
