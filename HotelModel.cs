using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

/**************************************************************
* Name        : Quick Book
* Author      : Angel Berber
* Created     : 12/9/2022
* Course      : CIS 169 - C#
* Version     : 1.0
* OS          : Windows 10
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : This program overall description here
*               Input:  Name, room number, phone number and ID
*               Output: Name, room number, phone number and ID
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access to
* my program.         
***************************************************************/


namespace Hotel_Booking_Final.Models
{

    /***************************************************************************************
*    Title: Insertion Sort
*    Author: ChitraNayal
*    Date: 18 Oct, 2022
*    Code version: Unknown
*    Availability: https://www.geeksforgeeks.org/insertion-sort/
*
***************************************************************************************/
    public class insertSort
    {
        public void sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
    }
    //This class is to house the general information about the hotel.
    public class hotelRoomInfo
    {

        public int roomNum { get; set; }
        public int price { get; set; }


        //Amount of rooms in the hotel
        public const int numberOfRooms = 35;

        //Collection of room numbers 
        public int[] roomNumbersPossible = {101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,
                             120,121,122,123,124,125,126,127,128,129,130,131,132,133,134,135};

        //This parallel array to keep track of which rooms are open for booking, when a room is booked the corresponding index in this array to changed false

        public bool[] roomsOpenForBooking = {true, true, true, true, true, true, true, true, true, true, true, true, true,
                 true,true,true,true,true ,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};

       //Prices 
        public int[] roomPrices = {250,175,125,135,125,130,130,125,125,250,120,100,120,100,140,160,120,120,175,165,150,150,170,180,180,130,130,140,125,140,165,180,100,180,190};
        public void sortByRoomNumbers()
        {
            insertSort test = new insertSort();
            test.sort(roomNumbersPossible);

        }

        //the idea here is that the room number array will display all rooms in a column then the other arrays will go after  
        public string displayRoomsNumbers()
        {
            string columnOfRoomNumbers = "";

            foreach(int roomNumber in roomNumbersPossible)
            {
                columnOfRoomNumbers += roomNumber.ToString() + "\n";

            }
            return columnOfRoomNumbers;
        }

        public string displayOpenForBooking()
        {
            string columnOfAvailability = "";

            foreach(bool open in roomsOpenForBooking)
            {
                columnOfAvailability += open + "\n";    
            }
            return columnOfAvailability;
        }

        public string displayRoomPrices()
        {
            string columnOfPrices = "";

            foreach (int prices in roomPrices)
            {
                columnOfPrices += prices + "\n";
            }
            return columnOfPrices;
        }


    }//end of class hotelRoomInfo



    public class clientGuest
    {
        LinkedList<string> nameList = new LinkedList<string>();

        LinkedList<string> phoneList = new LinkedList<string>();

        LinkedList<int> roomNumberList = new LinkedList<int>();

        LinkedList<int> idList = new LinkedList<int>();

        public int[] roomNumbersPossible = {101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120,
                              121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135 };

        public string user(int _id, string _name, long _phoneNumber, int _roomNumber)
        {
            //making a string in order to format it later to put in the phoneList
            string phoneString = _phoneNumber.ToString();

            //planning to store the user info in four linked lists and will keep track of how each piece of info is stored so that they're not put in out of order

            

                if (phoneString.Length != 10)
                {

                    Console.WriteLine("Please enter a valid phone number");

                }
                else
                {
                    string firstPart = phoneString.Substring(0, 3);
                    string secondPart = phoneString.Substring(3, 3);
                    string thirdPart = phoneString.Substring(6, 4);

                    string finalPhoneNumberString = "(" + firstPart + ")" + "-" + secondPart + "-" + thirdPart;
                    phoneList.AddFirst(finalPhoneNumberString);
                }

                _name.ToUpper();
                nameList.AddFirst(_name);


                //checks if the user put in a valid room number by checking if the array has the room number as well. The array doesn't do anything but is just there to reference from. 
                if (roomNumbersPossible.Contains(_roomNumber))
                {
                    roomNumberList.AddFirst(_roomNumber);
                }
                else
                {
                    return "Room number is invalid";
                }

                idList.AddFirst(_id);

                return "Thank you!";
            
        }
        
        //This method makes a random user id, while the linked list for id already has that number then it'll keep looping until the if statement catches a number that isn't already in. Then it'll make the 
        //user id that random number, add it to the list and finally break from the loop where the userID can be returned. 
        public int makeUserID()
        {
            int userID = 0;

            Random r = new Random();
            userID = r.Next(0, 1000);

            while(idList.Contains(userID) == true)
            {
                userID = r.Next(0, 1000);

                if(idList.Contains(userID) == false)
                {
                    idList.AddFirst(userID);
                    break;
                }
            }

            return userID;
        }

        //Display method
        public string display()
        {
            
            string roomID = roomNumberList.ElementAt(0).ToString();
            string phone = phoneList.ElementAt(0);
            string ID = idList.ElementAt(0).ToString();
            string name = nameList.ElementAt(0);
            return "Name: " +  name + " \nPhone Number: " + phone + " \nID: " + ID + " \nRoom Number: " + roomID;
        }



    }//end of class clientGuest

    public class waitList
    {
        //waiting list queue for if a room is already booked, you can select to be in a waiting list for when the room would be next available 
        //planning to store the user info in four Queues and will keep track of how each piece of info is stored so that they're not put in out of order
        Queue<string> nameList = new Queue<string>();

        Queue<long> phoneList = new Queue<long>();

        Queue<int> roomNumberList = new Queue<int>();

        Queue<int> idList = new Queue<int>();
        public string waitlistQueue(int _id, string _name, long _phoneNumber, int _roomNumber)
        {
            nameList.Enqueue(_name);
            roomNumberList.Enqueue(_roomNumber);
            idList.Enqueue(_id);
            phoneList.Enqueue(_phoneNumber);

            return "You've been put on the waiting list for this room";

        }

        //Display method
        public string display()
        {
            string roomID = roomNumberList.ElementAt(0).ToString();
            long phone = phoneList.ElementAt(0);
            string ID = idList.ElementAt(0).ToString();
            string name = nameList.ElementAt(0);
            return "Name: " + name + " \nPhone Number: " + phone + " \nID: " + ID + " \nRoom Number: " + roomID;
        }

        //for if a room is already booked
        public void getInTheUserClass()
        {
            clientGuest clientGuest = new clientGuest();
            string nextName = nameList.Dequeue();
            long nextPhoneNumber = phoneList.Dequeue();
            int nextRoomNumber = roomNumberList.Dequeue();
            int nextId = idList.Dequeue();

            clientGuest.user(nextId, nextName, nextPhoneNumber, nextRoomNumber);


            

        }

        //This is to check how many people are waiting in a queue and returns the amount. 
        public int peopleWaiting()
        {

            int count = 0;
            int namesWaiting = nameList.Count();
            int phonesWaiting = phoneList.Count();
            int roomsWaiting = roomNumberList.Count();
            int idWaiting = idList.Count();

            if(namesWaiting == phonesWaiting && roomsWaiting == idWaiting)
            {
                count = nameList.Count();
            }

            return count;
        }

    }//end of class waitList


    //main class 
    public class HotelModel
    {

        waitList waitList = new waitList();

        clientGuest client = new clientGuest();

        hotelRoomInfo hotelRoomInfo = new hotelRoomInfo();

        //variables for the main client guest class
        string name = "";
        int roomNumber;
        int ID;
        long phone;

        //Variables for wait list
        string name_waitList = "";
        int roomNumber_waitList;
        int ID_waitList;
        long phone_waitList;


        public string newName
        {
            get { return name; }
            set
            {

                value.ToUpper();
                name = value;

              /*  if (value == " " || value.Length > 25)
                {
                    value.ToUpper();
                    name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid name entered");
                }
              */
                
            }
        }

        //wait list get and sets 
        public string newName_waitList
        {
            get { return name_waitList; }
            set
            {

                value.ToUpper();
                name_waitList = value;

                /*  if (value == " " || value.Length > 25)
                  {
                      value.ToUpper();
                      name = value;
                  }
                  else
                  {
                      throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid name entered");
                  }
                */

            }
        }

        //Gets room number entered from the form and assigns it to the variable in the code.
        public int newRoomNumber
        {
            get { return roomNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid room number");
                    value = 0;

                }
                else if (value > 135)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid room number");
                    value = 0;
                }
                else if (value < 101)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid room number");
                    value = 0;
                }
                else
                {
                    roomNumber = value;
                }
            }
        }


        //wait list get and sets
        public int newRoomNumber_waitList
        {
            get { return roomNumber_waitList; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid room number");
                    value = 0;

                }
                else if (value > 135)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid room number");
                    value = 0;
                }
                else if (value < 101)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid room number");
                    value = 0;
                }
                else
                {
                    roomNumber_waitList = value;
                }
            }
        }



        //wait list get and sets
        public int newRoomNumber_waitlist
        {
            get { return roomNumber_waitList; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid room number");
                    value = 0;

                }
                else if (value > 135)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid room number");
                    value = 0;
                }
                else if (value < 101)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid room number");
                    value = 0;
                }
                else
                {
                    roomNumber_waitList = value;
                }
            }
        }


        public int newUserID
        {
            get { return ID; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid user ID");
                    value = 0;

                }
                else if (value > 1000)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid user ID");
                    value = 0;
                }
                else
                {
                    ID = value;
                }
            }
        }

        //wait list get and sets
        public int newUserID_waitlist
        {
            get { return ID_waitList; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid user ID");
                    value = 0;

                }
                else if (value > 1000)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid user ID");
                    value = 0;
                }
                else
                {
                    ID_waitList = value;
                }
            }
        }


        public long newPhoneNumber 
        {
            get { return phone; }
            set
            {
                if (value > 9999999999)
                {

                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid phone number, too many numbers");

                }
                else if (value < 1000000000)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid phone number, not enough numbers");
                }
                else
                {
                    phone = value;
                }
            }
            
        }

        //wait list get and sets
        public long newPhoneNumber_waitList
        {
            get { return phone_waitList; }
            set
            {
                if (value > 9999999999)
                {

                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid phone number, too many numbers");

                }
                else if (value < 1000000000)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} Invalid phone number, not enough numbers");
                }
                else
                {
                    phone_waitList = value;
                }
            }

        }

        //end result of the client user class 
        public string enterUserIn()
        {
            string formDisplay;

            client.user(ID, name, phone, roomNumber);
            formDisplay = client.display();
            return formDisplay;
        }

        //end result of the wait list queue class
        public string enterIntoWaitList()
        {
            string formDisplay_waitList;

            waitList.waitlistQueue(ID, name, phone, roomNumber);
            formDisplay_waitList = waitList.display();
            return formDisplay_waitList;
        }



        //display a random id number to the user 
        public string displyUserID()
        {

            string displayingUserIDToUser = "";


            clientGuest clientGuest = new clientGuest();
            displayingUserIDToUser = clientGuest.makeUserID().ToString();
            return displayingUserIDToUser;


        }

        /*should display something like this all together 
         * 
         * 101       True         $125$  
         * 
         * 
         * 
         * 
         */
        public string showRoomNumbers()
        {
            
            
            return hotelRoomInfo.displayRoomsNumbers();
        }

        public string showOpenForBooking()
        {


            return hotelRoomInfo.displayOpenForBooking().ToString();
        }

        public string showPrices()
        {


            return hotelRoomInfo.displayRoomPrices().ToString();
        }
    }

}


   


