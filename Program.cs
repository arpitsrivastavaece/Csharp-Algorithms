using System;


namespace Assignment1_S19
{
    class Program
    {
        private static int l_num;
        private static int h_num;

        public static void Main()
        {
            int a = 5, b = 15;
            printPrimeNumbers(a, b);


            int n1 = 5;
            string r1 = getSeriesResult(n1).ToString("0.000");
            Console.WriteLine("The sum of the series is: " + r1);
            Console.ReadLine();


            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: "+r2);
            Console.ReadLine();


            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);
            Console.ReadLine();


            int n4 = 5;
            printTriangle(n4);


            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);


            // write your self-reflection here as a comment

        }

        public static void printPrimeNumbers(int x, int y)//Prints prime numbers between and including x & y
        {
            try
            {
                /* 
                 A prime number is a natural numbers with only two factors
                 (1 and itself). Since it is a natural number, negative integers
                 are not considered prime numbers.
                */


                /*
                 Although, x is supposed to be smaller than y, the program 
                 takes into consideration the possibility of a human error. if-else condition is used 
                 to distinguish between the lower(l_num) and higher(h_num) of 
                 parameters x and y. If both paramters have the same value, 
                 then the program will throw an exception.
                */
               
                if (x!=y)
                {
                    if (x > y)
                    {
                        int l_num = y;
                        int h_num = x;
                    }
                    else if (x < y)
                    {
                        l_num = x;
                        h_num = y;
                    }
                }
                
                else // if both parameters have the same value.
                {
                    throw new Exception();
                }

                Console.Write("The Prime numbers including and between {0} and {1} is/are:  ", l_num, h_num);

                /*
                  The program consists of two loops. The idea is to compute the number of factors
                  of each number from l_num to h_num individually. Then finally checking whether the
                  number of factors are 2, which is the condition of a number being prime. The prime
                  numbers are shown as output.
                */
                  
                  
                for (int check_num = l_num; check_num <= h_num; check_num++)
                {   /*
                      This loop will check every number(check_num) between and including 
                      the parameter values
                    */

                    int num_factors = 0; /* 0 is assigned to num_factors so that the number 
                                            of factors can be added to it one at a time */

                    for (int check_factor = 1; check_factor <= check_num; check_factor++)
                    {/*
                        This loop will check every potential factor from 1 to check_num 
                     */
                        if (check_num % check_factor == 0)
                        {
                            num_factors = num_factors + 1;
                            /* Checks every number(check_num) against every
                               potential factor(check_factor)
                            */
                        }

                    }
                    //If the condition for prime number is satisfied, it's printed on the screen
                    if (num_factors == 2)
                    {
                        Console.Write("{0}   ",check_num);

                    }
                }
                Console.WriteLine();
                Console.ReadLine();
            }
            catch// If parameters values are equal to each other
            {
                
            
                Console.WriteLine("Parameter values same");
               
                
            }


        }




        public static int factorial(int f)     //This method calculates the factorial of f.

        {
            try
            {
                if(f>=0)
                {
                    int fact = 1;
                    for (int i1 = 1; i1 <= f; i1++)
                    {
                        fact = fact * i1;/*The value of "fact" changes at every iteration
                                           to finally return the factorial of f.*/
                    }
                    return fact;
                }
                else// exception is thrown if the number is a non-positive integer
                {
                    throw new Exception();
                }
            }

            catch
            {
                Console.WriteLine("Please enter a non-negative integer.");
                Console.ReadLine();
            }
            return 0;
            
        }




        public static int power(int num, int p)  //The method calculates power "p" of number "num".
        {
            int pow = 1;//The variable which will store the calcualted value of num^p.
            for(int i2=1; i2<=p; i2++)
            {
                pow = pow * num;//value of "num" is multiplied by itelf at every iteration until "i2" reaches "p";
            }
            return pow;
        }




        public static double getSeriesResult(int n)
        // Calculates ∑ ((-1)^a)*(a!/(a+1)) where a∈[1,n] increasing by 1 everytime.
        {
            try
            {
                if(n>0)
                {
                    double series_result = 0;
                    for (int i3 = 1; i3 <= n; i3++)
                    {
                        // application of the above mentioned formula.
                        series_result += (((double)power(-1, (i3 + 1)) * (double)factorial(i3)) / (double)(i3 + 1));
                    }
                    return (double)series_result;
                }
                else// Exception is thrown if n<=0.
                {
                    throw new Exception();
                }

            }
            catch
            {
                Console.WriteLine("Enter a positive integer.");
            }

            return 0;
        }




        public static long decimalToBinary(long n)
        {
            //The method converts n(decimal number) to binary
            try
            {
                long q;//quotient
                string r = "";//remainder of string type so that it can be reversed at the end.
                if(n>=0)/*the method does not include 2's complement method for conversion of 
                          negative integers to binary numbers*/
                {
                    while (n >= 1)//breaks when n reaches 1
                    {
                        q = n / 2;
                        r = r + Convert.ToString(n % 2);
                        n = q;
                    }
                    string binary = "";//to store reversed string r
                    for (int i4 = r.Length - 1; i4 >= 0; i4--)
                    {
                        binary = binary + r[i4];
                    }

                    return Convert.ToInt64(binary);//method returns value of long type.
                }
                else// throws exception if n<0
                {
                    throw new Exception();
                }
     
            }
            catch
            {
                Console.WriteLine("The parameter is not a non-negative decimal number");
            }

            return 0;
        }



        public static long binaryToDecimal(long n)
        {//The method converts n(binary number) to decimal.
            try
            {
                string str = Convert.ToString(n);// to access each digit of n
                int len = str.Length;
                long decimalnum = 0;
                bool is_binary=true;//The value stored in is_binary is used to check whether n is binary of not.
                for(int j5=0; j5<len;j5++)//This loop along with conditionals checks whether the value assigned to parameter n is binary.
                {
                    if(str[j5].ToString()=="1" || str[j5].ToString()=="0")
                    {
                        continue;
                    }
                    // if any digit of n is neither 0 nor 1, false value is stored in is_binary.
                    else
                    {
                        is_binary = false;
                    }
                    
                }

                if(is_binary==true)// if n is a binary number, the process for conversion begins
                {
                    for (int i5 = 0; i5 < len; i5++)
                    {
                        decimalnum += power(2, len - i5 - 1) * (Int32.Parse(str[i5].ToString()));
                       //ToString() is used to convert char to string.                                                                           
                       //each number is multiplied by 2^(placevalue) and added to decimalnum which was 0 in the beginning
                    }
                    return decimalnum;
                }
                else//if n is not a binary number
                {
                    throw new Exception();//Exception is thrown when the value of n is not binary in nature.
                }
                
            }

            catch
            {
                Console.WriteLine("The parameter is not binary in nature.");
            }

            return 0;
        }



        public static void printTriangle(int n)
        {
            //The method prints an isosceles triangle of "*" with n number of lines. 
            try
            {
                if(n>0)// Won't print a triangle if number of lines is non-positive.
                {
                    for (int line_count = 1; line_count <= n; line_count++)
                    {   // Enables counting of spaces and "*"s in each line.
                        
                        int star_count = 0;// to count the number of "*"s in each line.
                        for (int space_count = n - line_count; space_count > 0; space_count--)
                        {
                            //Counts number space before the first "*" and prints the spaces on screen.
                            Console.Write(" ");
                        }
                        while (star_count != ((2 * line_count) - 1))
                        {
                            // Every line has 2*(number of lines)-1  "*"s
                            Console.Write("*");                            
                            star_count++;
                            //loop breaks when star_count reaches (2*line_count)-1  (FROM 0)
                        }
                        Console.WriteLine();// To change line after one line is done.
                    }
                    Console.ReadLine();
                }
                else// throws exception if number of lines is non-positive.
                {
                    throw new Exception();
                }
                
            }
            catch
            {
                Console.WriteLine("The parameter is not a Natural Number");
                Console.ReadLine();

            }
        }



        public static void computeFrequency(int[] a)
        {
            // Computes the frequency of each distinct element of array "a"
            try
            {
                if(a.Length>0)// checks whether the array is not empty
                {
                    int[] freq = new int[a.Length];// array where frequencies will be stored.
                    int rep;//repitition
                    for (int l6 = 0; l6 < freq.Length; l6++)
                    {
                        freq[l6] = -1;
                    }
                    Console.WriteLine("Number    Frequency");
                    for (int i6 = 0; i6 < freq.Length; i6++)// for all elements of a
                    {
                        rep = 1;
                        for (int j6 = i6 + 1; j6 < freq.Length; j6++)// for all elements ahead of the element at i6
                        {
                            if (a[i6] == a[j6])
                            {
                                rep++;//counts of frequency of element at a[i6]
                                freq[j6] = 0;// sets frequency at the position of every repeated element to 0
                            }
                            if (freq[i6] != 0)
                            {
                                freq[i6] = rep;  /*sets frequncy at the position of the element which
                                             is checked for repition to rep*/
                            }
                        }

                    }
                    for (int k6 = 0; k6 < freq.Length; k6++)
                    {
                        if (freq[k6] != 0)//skips elements corresponding to the position where frequency
                        {
                            Console.WriteLine("{0}         {1}        ", a[k6], freq[k6]);
                        }
                    }
                    Console.ReadLine();
                }
                else// throws exception if the array if empty
                {
                    throw new Exception();
                }
                
            }
            catch// if the array is empty
            {
                Console.WriteLine("The array does not have any elements");
                Console.ReadLine();
            }
        }
    }
}

