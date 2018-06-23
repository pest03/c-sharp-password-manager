using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
namespace PasswordConsole
{
    class Program
    {
        static void Main(string[] args)
        {
             string path = AppDomain.CurrentDomain.BaseDirectory;

            if (File.Exists(path + "n5Ur5vfbHWmKMpRS.dat") && File.Exists(path + "F5SnLw9buNKKNYqx.dat"))
            {
                Console.WriteLine("Please enter password you will be using for unlocking the passwords:");
                string password = Console.ReadLine();
                File.WriteAllText(path + "VaFS3DNg5myqK87V.dat", Encryption.Full_Encrypt("sfnsjkdfscvsd1f3srg1sv3x", "se4ts9gsbdfbdfh", password));
                File.WriteAllText(path + "j5aPSX7MMWcGrXkq.dat", Encryption.CreateMD5(password));
                File.Create(path + "exeBNFwsN3An97hA.dat"); //passwords file
                File.Delete("F5SnLw9buNKKNYqx.dat");
                Process.Start(AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);

            }
            else if (File.Exists(path + "n5Ur5vfbHWmKMpRS.dat") && !File.Exists(path + "F5SnLw9buNKKNYqx.dat"))
            {
                Console.WriteLine("Please type in your master password to unlock your passwords:");
                string password = Console.ReadLine();
                if (Encryption.Full_Encrypt("sfnsjkdfscvsd1f3srg1sv3x", "se4ts9gsbdfbdfh", password) == File.ReadAllText(path + "VaFS3DNg5myqK87V.dat"))
                {
                    Console.Clear();
                    Console.WriteLine("Please choose option by typing its number");
                    Console.WriteLine("Please keep in mind that if you have not entered any passwords yet, you need to insert them first.");
                    Console.WriteLine("[1] Insert passwords");
                    Console.WriteLine("[2] Read passwords");
                    
                    string response = Console.ReadLine();
                    switch (response)
                    {
                        case "1":
                            {
                                Console.Clear();
                                Console.WriteLine("Please insert your passwords to securely encrypt them.");
                                Console.WriteLine("This will overwrite whole password file, if you are adding more please count with your old ones too");
                                string passwords = Console.ReadLine();
                                if (passwords != "")
                                {
                                    File.WriteAllText(path + "exeBNFwsN3An97hA.dat", Encryption.EncryptText(passwords, Encryption.EncryptText(Encryption.CreateMD5(File.ReadAllText(path + "j5aPSX7MMWcGrXkq.dat") + password), "E4wDyt92QaEphrV2")));
                                    Console.Clear();
                                    Console.WriteLine("Passwords written, press any key to restart the password manager and view them.");
                                    Console.ReadLine();
                                    Process.Start(AppDomain.CurrentDomain.FriendlyName);
                                    Environment.Exit(0);
                                }
                                break;
                            }
                        case "2":
                            {
                                Console.Clear();
                                Console.Write(Encryption.DecryptText(File.ReadAllText(path + "exeBNFwsN3An97hA.dat"), Encryption.EncryptText(Encryption.CreateMD5(File.ReadAllText(path + "j5aPSX7MMWcGrXkq.dat") + password), "E4wDyt92QaEphrV2")));
                                Console.Read();
                                break;
                            }

                    }
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("Wrong password entered, please restart me and check out.");
                    Console.Read();
                }
            }
            else
            {

                Console.WriteLine("Preparing for first run..");
                File.Create(path + "VaFS3DNg5myqK87V.dat"); //password file       
                File.Create(path + "j5aPSX7MMWcGrXkq.dat"); //password md5 file
                File.Create(path + "F5SnLw9buNKKNYqx.dat"); //has choosen password
                File.Create(path + "n5Ur5vfbHWmKMpRS.dat"); //first start happened.
                Console.WriteLine("Everything setup, let me restart in a second.");
                Process.Start(AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }

        }
    }
}
