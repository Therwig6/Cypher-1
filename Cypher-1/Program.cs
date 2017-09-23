using System;
using System.IO;

namespace CeaserCypher
{
    /// <summary>
    /// This program implements the most basic message encryption technique.  
    /// It is called a Ceaser Cypher (See Wikipedia for more details)
    /// 
    /// Your job is to read and understand this code.
    /// Annotate this example code by commenting on every line that you have not 
    /// seen before in this class.  There are many new things here.  Tell me
    /// what new methods do, and why (you think) they are used here.
    /// 
    /// Run the program, give it some example input, see what happens.
    /// 
    /// There are new methods, opperators, and implicit data conversions here.
    /// 
    /// Make sure to read the rubric on Schoology so you know you have 
    /// covered all the points I'm looking for!
    /// 
    /// </summary>
    class MainClass
    {

        /// <summary>
        /// The alphabet in lower case.
        /// </summary>
        public static String alphabet = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// The alphabet in upper case.
        /// </summary>
        public static String ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Encrypts the character using the given key in the given character set.
        /// </summary>
        /// <returns>The character.</returns>
        /// <param name="charSet">Character set which the given character is a part of.</param>
        /// <param name="ch">The character.</param>
        /// <param name="key">Key for the cypher.</param>
        /// 
      
        //This method Encrypts the message that will be entered later.
        public static char EncryptCharacter(String charSet, char ch, int key)
        {
            //This make sure there is a message that is entered before running code.
            if (charSet.IndexOf(ch) >= 0)
            {
                // Get the position of the character ch in the alphabet.
                int charNumber = charSet.IndexOf(ch);

                // add the key to the char number (this is the Ceaser Cipher step!)
                // the % 26 wraps around the alphabet so 'x' + 5 => 'c'
                int encryptedCharNumber = (charNumber + key) % charSet.Length;

                // get the character associated with the encrypted character number in the lowercase alphabet.
                char encryptedChar = charSet[encryptedCharNumber];

                // stick that encrypted character on the end of the encryptedMessage.
                return encryptedChar;
            }
            else
            {
                // ignore it if they character is not a part of the given character set
                return ch;
            }
        }

        /// <summary>
        /// Reads text from file and returns it as a String.
        /// </summary>
        /// <returns>The contents from file.</returns>
        /// <param name="fileName">Full file path.</param>
        public static String ReadFromFile(String fileName)
        {
            String contents = "";
            StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open));

            while (!reader.EndOfStream)
            {
                contents += String.Format("{0}{1}", reader.ReadLine(), Environment.NewLine);
            }

            reader.Close();

            return contents;
        }

        // This method Decrypts the message with the correct key.

        public static char DecryptCharacter(String charSet, char ch, int key)
        {
            if (charSet.IndexOf(ch) >= 0)
            {

                int charNumber = charSet.IndexOf(ch);


                int decryptedCharNumber = (charNumber - key) % charSet.Length;

                if(decryptedCharNumber < 0)
                {
                    decryptedCharNumber += 26;
                }


                char decryptedChar = charSet[decryptedCharNumber];


                return decryptedChar;
            }
            else
            {

                return ch;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("1 for Encrypt or 2 for Decrypt");
            int which = Convert.ToInt32(Console.ReadLine());
            // Get a secret message from the user.

            if (which == 1)
            {
                Console.WriteLine("Enter a message to encrypt:");
            }
            if (which == 2)
            {
                Console.WriteLine("Enter A message to decrypt");
            }

            String message = Console.ReadLine();

            // Get the KEY with which to encrypt this secret message.  This must be an INTEGER.
            Console.Write("Enter the KEY to encrypt this message with >> ");


            int key = Convert.ToInt32(Console.ReadLine());

            // Make a place to store the encrypted message while I'm working on building it.
            String encryptedMessage = "";

            String decryptedMessage = "";



            // Iterate through the message that the user typed one character at a time.
            if (which == 1)
            {
                foreach (char ch in message.ToCharArray())
                {
                    // if this is a lowercase letter, encrypt the character using the lowercase alphabet string.
                    // IndexOf returns -1 if the character does not appear in the string!
                    if (alphabet.IndexOf(ch) >= 0)
                    {

                        // stick that encrypted character on the end of the encryptedMessage.
                        encryptedMessage += EncryptCharacter(alphabet, ch, key);
                    }

                    // Do the same thing, if the character is a Capital letter.
                    else if (ALPHABET.IndexOf(ch) >= 0)
                    {
                        encryptedMessage += EncryptCharacter(ALPHABET, ch, key);
                    }

                    // If the character is neither a capital nor lowercase, then ignore it and don't try to encrypt.
                    else
                    {
                        encryptedMessage += ch;
                    }
                }
            }


            if (which == 2)
            {
                foreach (char ch in message.ToCharArray())
                {

                    if (alphabet.IndexOf(ch) >= 0)
                    {
                        decryptedMessage += DecryptCharacter(alphabet, ch, key);
                    }

                    // Do the same thing, if the character is a Capital letter.
                    else if (ALPHABET.IndexOf(ch) >= 0)
                    {
                        decryptedMessage += DecryptCharacter(ALPHABET, ch, key);
                    }

                    // If the character is neither a capital nor lowercase, then ignore it and don't try to encrypt.
                    else
                    {
                        decryptedMessage += ch;
                    }





                }
            }
        
        

    



            //I have seen most of this code before



            // Print the encrypted message!
            if (which == 1)
            {
                Console.WriteLine("_________________________________________________");
                Console.WriteLine("Your encrypted message is:\n\n{0}", encryptedMessage);
                Console.ReadKey();

            }
            if(which == 2)
            {
				Console.WriteLine("_________________________________________________");
				Console.WriteLine("Your decrypted message is:\n\n{0}", decryptedMessage);
				Console.ReadKey();
            }
		}
	}
}

