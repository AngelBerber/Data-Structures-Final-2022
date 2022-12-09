using System;
using Hotel_Booking_Final.Models;
using Hotel_Booking_Final.Controllers;
using System.Numerics;
using System.Xml.Linq;


namespace Hotel_Booking_Final.Models
{
    public class HotelSiteTest
    {
        [Fact]
        public void userCreatedTest()
        {
            //arrange
            string expected = "Thank you!";
            string actual;
            int id; 
            Hotel_Booking_Final.Models.clientGuest test = new Hotel_Booking_Final.Models.clientGuest();

            //act
            id = test.makeUserID();
            actual = test.user(1245, "Angel", 5154738860, 112);

            //assert
            Assert.Equal(expected, actual);
        }

        //
        [Fact]
        public void waitListTest()
        {
            //arrange
            string expected = "You've been put on the waiting list for this room";
            string actual;

            Hotel_Booking_Final.Models.waitList test = new Hotel_Booking_Final.Models.waitList();

            //act
            actual = test.waitlistQueue(12, "Angel", 5154738860, 343);

            //assert
            Assert.Equal(actual, expected);
        }

        //Tests to see if it formats correctly 
        [Fact]
        public void displayTestInClientClass()
        {
            //arrange
            string expected = "Name: " + "Angel" + " \nPhone Number: " + "(515)-473-8860" + " \nID: " + 1245 + " \nRoom Number: " + 122;
            string actual;

            Hotel_Booking_Final.Models.clientGuest test = new Hotel_Booking_Final.Models.clientGuest();

            //act
            test.user(1245, "Angel", 5154738860, 122);
            actual = test.display();

            //assert
            Assert.Equal(actual, expected);
        }

        //Tests to see if it formats correctly 
        [Fact]
        public void displayTestInWaitList()
        {
            //arrange
            string expected = "Name: " + "Angel" + " \nPhone Number: " + "5154738860" + " \nID: " + 1245 + " \nRoom Number: " + 122;
            string actual;

            Hotel_Booking_Final.Models.waitList test = new Hotel_Booking_Final.Models.waitList();

            //act
            test.waitlistQueue(1245, "Angel", 5154738860, 122);
            actual = test.display();

            //assert
            Assert.Equal(actual, expected);
        }

        //Checks the method if the inputed number isn't within the array, that it would display "Room number is invalid" meaning that it wasn't inserted in the linked list.
        [Fact]
        public void TestInvalidRoomNumber()
        {
            //arrange
            string expected = "Room number is invalid";
            string actual;

            Hotel_Booking_Final.Models.clientGuest test = new Hotel_Booking_Final.Models.clientGuest();

            //act
            
            actual = test.user(1245, "Angel", 5154738860, 45);

            //assert
            Assert.Equal(actual, expected);
        }

        //short test for the sort method class.
        [Fact]
        public void testSortMethod()
        {
            //arrange
            int[] expected = { 12, 14, 15, 16 };
            int[] actual = { 16, 14, 15, 12 };

           
            Hotel_Booking_Final.Models.insertSort test = new Hotel_Booking_Final.Models.insertSort();

            //act

            test.sort(actual);

            //assert
            Assert.Equal(expected, actual);
        }

        //short for display the room numbers
        [Fact]
        public void testDisplayRooms()
        {
            //arrange
            string expected = "101" + "\n" + "102" + "\n" + "103" + "\n" + "104" + "\n" + "105" + "\n" + "106" + "\n" + "107" + "\n" + "108" + "\n" + "109" + "\n" + "110" + "\n" +
                              "111" + "\n" + "112" + "\n" + "113" + "\n" + "114" + "\n" + "115" + "\n" + "116" + "\n" + "117" + "\n" + "118" + "\n" + "119" + "\n" + "120" + "\n" +
                              "121" + "\n" + "122" + "\n" + "123" + "\n" + "124" + "\n" + "125" + "\n" + "126" + "\n" + "127" + "\n" + "128" + "\n" + "129" + "\n" + "130" + "\n" +
                              "131" + "\n" + "132" + "\n" + "133" + "\n" + "134" + "\n" + "135" + "\n";
            string actual;


            
            Hotel_Booking_Final.Models.hotelRoomInfo test = new Hotel_Booking_Final.Models.hotelRoomInfo();

            

            //act

            actual = test.displayRoomsNumbers();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void testDisplayPrices()
        {
            //arrange
            string expected = "250" + "\n" + "175" + "\n"+ "125" + "\n" + "135" + "\n" + "125" + "\n" + "130" + "\n" + "130" + "\n" +
                "125" + "\n" + "125" + "\n" + "250" + "\n" + "120" + "\n" + "100" + "\n" + "120" + "\n" + "100" + "\n" +
                "140" + "\n" + "160" + "\n" + "120" + "\n" + "120" + "\n" + "175" + "\n" + "165" + "\n" + "150" + "\n" +
                "150" + "\n" + "170" + "\n" + "180" + "\n" + "180" + "\n" + "130" + "\n" + "130" + "\n" + "140" + "\n" +
                "125" + "\n" + "140" + "\n" + "165" + "\n" + "180" + "\n" + "100" + "\n" + "180" + "\n" + "190" + "\n";
            string actual;



            Hotel_Booking_Final.Models.hotelRoomInfo test = new Hotel_Booking_Final.Models.hotelRoomInfo();



            //act

            actual = test.displayRoomPrices();

            //assert
            Assert.Equal(expected, actual);
        }


        //tests how 
        [Fact]
        public void testDisplayOpenForBooking()
        {
            //arrange
            string expected = "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" +
                "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" +
                "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" + "True" + "\n" 
                +"True" + "\n" + "True" + "\n" + "True" + "\n";
            string actual;


            
            Hotel_Booking_Final.Models.hotelRoomInfo test = new Hotel_Booking_Final.Models.hotelRoomInfo();

            

            //act

            actual = test.displayOpenForBooking();

            //assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void testGetInTheUserClassInWaitListQueue()
        {
            //arrange
            int expected = 2;
            int actual;


            
            Hotel_Booking_Final.Models.waitList test = new Hotel_Booking_Final.Models.waitList();

            test.waitlistQueue(453, "Angel", 5154738860, 123);
            test.waitlistQueue(452, "Sam", 5154738860, 124);
            test.waitlistQueue(423, "Tom", 5154738860, 125);

            //should remove a person from the queue meaning there should be two people
            test.getInTheUserClass();

            //act
            
            actual = test.peopleWaiting();

            //assert
            Assert.Equal(expected, actual);
        }




        [Fact]
        public void testRandomNumberMakerForID()
        {
            //arrange
            bool expected = true;
            bool actual  = false;
            int randomnum;

            Hotel_Booking_Final.Models.clientGuest test = new Hotel_Booking_Final.Models.clientGuest();

            //act
            randomnum = test.makeUserID();

            if (randomnum > 0 && randomnum < 1001)
            {
                actual = true;
            }
            else
            {
                actual = false;
            }

            //assert
            Assert.Equal(expected, actual);
        }
        
    }
}