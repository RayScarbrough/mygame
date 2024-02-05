using System;

namespace theIsland
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int food = 0, water = 0, health = 0, scenario = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.WriteLine("You find yourself stranded on a uninhabited island after your boat sank. you must survive long enough for rescue to arrive!");
            string name = Console.ReadLine();
            initValues(ref food, ref water, ref health, r);
            while (food > 0 && water > 0 && health > 0 && !win)
            {
                scenario = chooseScenario(r);
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (scenario == 1)
                    actions(r.Next(4), ref food, ref water, ref health);
                else
                    actions(r.Next(10), ref food, ref water, ref health);
                checkResults(ref round, ref food, ref water, ref health, ref win);
            }
            if (win)
                Console.WriteLine("You're awakewned by the roar of engines and see a boat just off the coast of the island! You light a massive signal" +
                    "fire and the crew see's it, youre saved!");
            else if (food <= 0)
                Console.WriteLine("You have withered away from lack of food. You are now left to the crabs");
            else if (water <= 0)
                Console.WriteLine("Due to lack of water you become hysterical and charge into the ocean and gulp down as much water as your stomach can" +
                    "hold. Over the next few hours you slowly perish");
            else
                Console.WriteLine("You are in poor health and cannot scavange for food or water. You slowly wither away in your makeshift tent");
        }

        private static void checkResults(ref int round, ref int food, ref int water, ref int health, ref bool win)
        {
            round += 1;
            Console.WriteLine($"          ~~~~~~~~~~~~~~~~~~~~Day {round}!~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($" Here is your current stats! Food: {food} Water: {water} Health: {health}");
            Console.WriteLine("");

            if (round >= 10)
                win = true;
        }

        private static void actions(int num, ref int food, ref int water, ref int health)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("You discover a hidden stash of coconuts high up in the palm trees.");
                    Console.WriteLine("Do you want to climb the tree to get them?");
                    Console.WriteLine("Enter '1' to climb the tree or '2' to leave them:");
                    int coconutChoice = int.Parse(Console.ReadLine());
                    if (coconutChoice == 1)
                    {
                        food += 2;
                        water += 1;
                        health -= 3;
                        Console.WriteLine("You climb the tree and yank as hard as you can to pull off a coconut. You lose your grip on the tree as the coconut breaks free and fall hard onto the ground");
                        Console.WriteLine("you gain 2 food and 1 water, but you lose 3 health");
                    }
                    else if (coconutChoice == 2)
                    {
                        food -= 1;
                        Console.WriteLine("You decide not to risk climbing the tree and leave the coconuts behind. You feel evermore hungry and lose 1 food.");
                    }
                    break;

                case 1:
                    Console.WriteLine("You stumble upon a dead bird in the treeline. You examine it and notice it smells ever so slightly off");
                    Console.WriteLine("would you like to risk illness and eat the bird?");
                    Console.WriteLine("Enter '1' to eat the bird or '2' to leave the bird:");
                    int birdChoice = int.Parse(Console.ReadLine());
                    if (birdChoice == 1)
                    {
                        health -= 3;
                        food += 3;
                        Console.WriteLine("You feel slighty ill for the next few days, but atleast you're stomach is full...right?");
                        Console.WriteLine("you lose 3 health but gain 3 hunger");
                    }
                    else if (birdChoice == 2)
                    {
                        Console.WriteLine("You decide to walk away and avoid eating the bird. Its probably for the best");
                    }
                    break;

                case 2:
                    Console.WriteLine("You stumble upon a small cave in the heart of the island");
                    Console.WriteLine("Do you want to adventure in?");
                    Console.WriteLine("Enter '1' to take go in to the cave or '2' to leave:");
                    int caveChoice = int.Parse(Console.ReadLine());
                    if (caveChoice == 1)
                    {
                        water += 4;
                        Console.WriteLine("You stumble upon a small cave. Inside, you find a stash of fresh water bottles. you gain 4 water");
                    }
                    else if (caveChoice == 2)
                    {
                        Console.WriteLine("You decide to avoid the cave.");
                    }
                    break;

                case 3:
                    Console.WriteLine("You encounter a deep hole in the forest of the island. you drop a rock down and hear a splash.");
                    Console.WriteLine("You can try to retrieve water by tying a string to your water container, but you might lose it in the process.");
                    Console.WriteLine("Enter '1' to try to retrieve water or '2' to leave it:");
                    int wellChoice = int.Parse(Console.ReadLine());
                    if (wellChoice == 1)
                    {
                        water += 3;
                        Console.WriteLine("You manage to retrieve water! you gain 3 water");
                    }
                    else if (wellChoice == 2)
                    {
                        Console.WriteLine("You decide to leave the hole. your container remains safe");
                    }
                    break;

                case 4:
                    Console.WriteLine("You find a small stream running through the island's interior.");
                    Console.WriteLine("Do you want to drink from it?");
                    Console.WriteLine("Enter '1' to drink from the stream or '2' to avoid it:");
                    int streamChoice = int.Parse(Console.ReadLine());
                    if (streamChoice == 1)
                    {
                        water += 2;
                        Console.WriteLine("The stream water seems clean. You drink from it and gain 2 water.");
                    }
                    else if (streamChoice == 2)
                    {
                        Console.WriteLine("You decide not to drink from the stream, fearing it might be contaminated.");
                    }
                    break;

                case 5:
                    Console.WriteLine("You spot a group of berries growing on a bush.");
                    Console.WriteLine("Do you want to collect and eat them?");
                    Console.WriteLine("Enter '1' to collect and eat the berries or '2' to leave them:");
                    int berryChoice = int.Parse(Console.ReadLine());
                    if (berryChoice == 1)
                    {
                        food += 3;
                        Console.WriteLine("The berries taste surprisingly good. You gain 3 food.");
                    }
                    else if (berryChoice == 2)
                    {
                        Console.WriteLine("You decide not to risk eating unknown berries. you become hungier and lose 1 food");
                        food -= 1;
                    }
                    break;

                case 6:
                    Console.WriteLine("You discover a makeshift shelter made from leaves and branches.");
                    Console.WriteLine("Do you want to spend the night there?");
                    Console.WriteLine("Enter '1' to stay in the shelter or '2' to continue on:");
                    int shelterChoice = int.Parse(Console.ReadLine());
                    if (shelterChoice == 1)
                    {
                        health += 2;
                        Console.WriteLine("You spend a comfortable night in the shelter. You gain 2 health.");
                    }
                    else if (shelterChoice == 2)
                    {
                        Console.WriteLine("You decide to keep moving, wary of the shelter's safety.");
                    }
                    break;

                case 7:
                    Console.WriteLine("You stumble upon a beehive hanging from a tree branch.");
                    Console.WriteLine("Do you want to risk getting honey?");
                    Console.WriteLine("Enter '1' to collect honey or '2' to leave it:");
                    int honeyChoice = int.Parse(Console.ReadLine());
                    if (honeyChoice == 1)
                    {
                        food += 1;
                        Console.WriteLine("You manage to collect some honey without getting stung. You gain 1 food.");
                    }
                    else if (honeyChoice == 2)
                    {
                        Console.WriteLine("You decide not to risk angering the bees.");
                    }
                    break;

                case 8:
                    Console.WriteLine("You come across a pile of driftwood near the shore.");
                    Console.WriteLine("Do you want to gather some for a relaxing fire?");
                    Console.WriteLine("Enter '1' to gather driftwood or '2' to leave it:");
                    int driftwoodChoice = int.Parse(Console.ReadLine());
                    if (driftwoodChoice == 1)
                    {
                        water -= 1;
                        health += 1;
                        Console.WriteLine("You gather some driftwood for a fire, but you become thirsty and it takes a toll on your water supply. You lose 1 water but gain 1 health.");
                    }
                    else if (driftwoodChoice == 2)
                    {
                        Console.WriteLine("You decide not to waste energy on gathering driftwood.");
                    }
                    break;

                case 9:
                    Console.WriteLine("You notice a small cave with a peculiar odor.");
                    Console.WriteLine("Do you want to investigate the cave?");
                    Console.WriteLine("Enter '1' to explore the cave or '2' to avoid it:");
                    int caveChoice2 = int.Parse(Console.ReadLine());
                    if (caveChoice2 == 1)
                    {
                        food += 2;
                        health -= 1;
                        Console.WriteLine("You find a hidden cache of edible mushrooms. You gain 2 food but lose 1 health.");
                    }
                    else if (caveChoice2 == 2)
                    {
                        Console.WriteLine("You decide not to risk the strange cave.");
                    }
                    break;

                default:
                    Console.WriteLine("You continue your exploration, but nothing noteworthy happens.");
                    water -= 1;
                    food -= 1;
                    break;
            }
        }

        private static int chooseScenario(Random random)
        {
            
            int scenario = random.Next(1, 3); 

            return scenario;
        }

        static void initValues(ref int food, ref int water, ref int health, Random r)
        {
            food = r.Next(10) + 1;
            water = r.Next(15) + 5;
            health = r.Next(14) + 5;
            return;
        }
    }
}
