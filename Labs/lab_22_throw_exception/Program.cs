using System;
using System.IO;

namespace lab_22_throw_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            //overall system
            try 
            {
                //department
                try
                {
                    //you
                    try 
                    {
                        //custom exception
                        //read database and FAILS
                        throw new Exception("Database read has failed for user Joe");
                    }
                    catch(Exception e) 
                    {
                        //dont handle
                        //pass up
                        throw;
                    }
                }
                catch(Exception e)
                {
                    throw;
                }
            }
            catch(Exception e)
            {
                File.AppendAllText("ErrorLog.txt", Environment.NewLine + e.Message);          //logging system
            }
        }
    }
}
