/***********************************************************************************************************************************
*                                                 GOD First                                                                        *
* Author: Dustin Ledbetter                                                                                                         *
* Release Date: 9-25-2018                                                                                                          *
* Version: 1.0                                                                                                                     *
* Purpose: To create a pure SINI program for the storefront to show how they work                                                  *
************************************************************************************************************************************/

using System;
using static PFWeb.StorefrontAPI;


namespace MyPureSINI
{
    class SINIOne
    {
        static void Main(string[] args)
        {




            #region This section is used to specify the storefront to use and to give access to it with a pre-existing user
            
            // Specify the website to use
            var storefrontUrl = @"https://www.yoursitepath";
            // Pass the url to the storefront API
            var Storefront = new SXI.StorefrontAPIHelper(storefrontUrl);
            // Retrieve a ticket for user from the storefront by passing it login info 
            var ticket = Storefront.ObtainUserTicket("username", "password", "company.extension(Not sure what this should be for others sorry. Pretty sure this is for naming though)");


            // This line is to see the ticket recieved for the user
            Console.WriteLine(ticket);

            #endregion


            #region This section is used to create a new user in the storefront
            
            // Create user id field and set to null til used for user creation
            string uid = null;

            // Check to see if it is a success to create a new user. If it is then we set values for it
            if (eSuccess == Storefront.CreateUser("NewUser", out uid))
            {

                // Display the User id for us to see on console
                Console.WriteLine(uid);

                // Set some fields for the user that is being created
                Storefront.SetValue("UserProperty", "Password", uid, "secret");
                Storefront.SetValue("UserField", "UserProfileFirstName", uid, "FName");
                Storefront.SetValue("UserField", "UserProfileLastName", uid, "LName");
                Storefront.SetValue("UserField", "UserProfileEmailAddress", uid, "new@example.com");
                Storefront.SetValue("UserProperty", "IsActive", uid, "1");

                // Report that the user was created
                Console.WriteLine("Sucessful");
            }
            else
            {

                // Report that the user already exists 
                Console.WriteLine("User Already Exists");
            }

            #endregion


            #region This section is to show the results of our program

            // If a user was successfully created the next two lines will have the id and last name of the user
            // If the user already existed then these lines will be blank
            Console.WriteLine(uid);
            Console.WriteLine(Storefront.GetValue("UserField", "UserProfileLastName", uid));

            // This line should have a break point set on it to prevent the program from closing so that we can view the console results
            Console.WriteLine("success");

            #endregion


        //end of method: Main
        }
    //end of class: SINIOne
    }
//end of file: MyPureSINI
}
