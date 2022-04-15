using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Clear();
			Console.Write("Enter String for Hangman: ");
			string? word = Console.ReadLine();
			if (word == null || word.Length == 0) 
			{
				while (true) 
				{
					Console.Clear();
					Console.Write("Enter String for Hangman: ");
					word = Console.ReadLine();
					if (word != null && word.Length > 0)
					{
						break;
					}
				}
			}

			string template = "";
			int n = word.Length;
			int stage = 0;
			int spaces = 0;

			for (int i = 0; i < n; i++) 
			{
				if (word[i] == ' ')
				{
					template += ' ';
					spaces++;
				} else {
					template += '_';
				}
			}
			n -= spaces;

			Console.Clear();
			drawHangman(stage);
			Console.WriteLine(template);
			Console.WriteLine();
			Console.Write("Make your guess: ");
			while (n > 0) 
			{
				string? guess = Console.ReadLine();
				if (guess == null || guess.Length > 1)
				{
					while (true)
					{
						Console.Write("Enter only 1 character: ");
						guess = Console.ReadLine();
						if (guess != null && guess.Length == 1) {
							break;
						}
					}
				}

				string update = updateTemplate(template, word, guess[0]);
				if (update != template) {
					int change = 0;
					for (int i = 0; i < update.Length; i++) {
						if (update[i] != template[i]) {
							change++;
						}
					}
					template = update;
					n -= change;
				} else {
					stage++;
				}

				Console.Clear();
				drawHangman(stage);
				if (stage >= 6) {
					Console.WriteLine("Sorry, you lose. The word was: " + word);
					break;
				}
				Console.WriteLine(template);
				Console.Write("Make your guess:" );
			}
			Console.Clear();
			drawHangman(stage);
			Console.WriteLine(template);
			Console.WriteLine("Congradulations! You won!");
		}

		static void drawHangman(int stage)
		{
			if (stage == 0)
			{
				Console.WriteLine("  ____  ");
				Console.WriteLine("  |   | ");
				Console.WriteLine("  |     ");
				Console.WriteLine("  |     ");
				Console.WriteLine("  |     ");
				Console.WriteLine(" _|___  ");
			} else if (stage == 1) {
				Console.WriteLine("  ____  ");
				Console.WriteLine("  |   | ");
				Console.WriteLine("  |   o ");
				Console.WriteLine("  |     ");
				Console.WriteLine("  |     ");
				Console.WriteLine(" _|___  ");
			} else if (stage == 2) {
				Console.WriteLine("  ____  ");
				Console.WriteLine("  |   | ");
				Console.WriteLine("  |   o ");
				Console.WriteLine("  |   | ");
				Console.WriteLine("  |     ");
				Console.WriteLine(" _|___  ");
			} else if (stage == 3) {
				Console.WriteLine("  ____  ");
				Console.WriteLine("  |   | ");
				Console.WriteLine("  |   o ");
				Console.WriteLine("  |  -| ");
				Console.WriteLine("  |     ");
				Console.WriteLine(" _|___  ");
			} else if (stage == 4) {
				Console.WriteLine("  ____  ");
				Console.WriteLine("  |   | ");
				Console.WriteLine("  |   o ");
				Console.WriteLine("  |  -|-");
				Console.WriteLine("  |     ");
				Console.WriteLine(" _|___  ");
			} else if (stage == 5) {
				Console.WriteLine("  ____  ");
				Console.WriteLine("  |   | ");
				Console.WriteLine("  |   o ");
				Console.WriteLine("  |  -|-");
				Console.WriteLine("  |  /  ");
				Console.WriteLine(" _|___  ");
			} else if (stage == 6) {
				Console.WriteLine("  ____  ");
				Console.WriteLine("  |   | ");
				Console.WriteLine("  |   o ");
				Console.WriteLine("  |  -|-");
				Console.WriteLine("  |  / \\");
				Console.WriteLine(" _|___  ");
			}
		}

		static string updateTemplate(string template, string word, char guess) {
			int n = word.Length;
			char[] update = new char[n];
			for (int i = 0; i < n; i++) {
				if (Char.ToLower(word[i]) == Char.ToLower(guess)) {
					update[i] = word[i];
				} else {
					update[i] = template[i];
				}
			}
			return String.Join("", update);
		}
	}
}