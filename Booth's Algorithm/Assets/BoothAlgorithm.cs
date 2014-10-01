using UnityEngine;
using System.Collections;
//these are what were added
using System;
using System.Collections.Generic;
using System.Text;

public class BoothAlgorithm : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    static void Main(string[] args)
    {
        string A = "0000";
        string M, Q;
        string Q_1 = "0";

        Console.Write("Please enter a 4 bit Multiplicant = ");
        M = Console.ReadLine();

        Console.Write("Please enter a  4 bit Multiplier = ");
        Q = Console.ReadLine();

        for (int i = 0; i < 4; i++)
        {
            string Qo_Q = Q[3] + Q_1;
            if (Qo_Q == "11" || Qo_Q == "00")
            {
                //shift 
                Q_1 = Q[3].ToString();
                string NewQ = A[3].ToString() + Q[0] + Q[1] + Q[2];
                Q = NewQ;

                string NewA = A[0].ToString() + A[0].ToString() + A[1].ToString() + A[2].ToString();
                A = NewA;

            }
            else if (Qo_Q == "01")
            {
                A = Add(A, M);
                Q_1 = Q[3].ToString();
                string NewQ = A[3].ToString() + Q[0] + Q[1] + Q[2];
                Q = NewQ;

                string NewA = A[0].ToString() + A[0].ToString() + A[1].ToString() + A[2].ToString();
                A = NewA;
            }

            else if (Qo_Q == "10")
            {
                A = Subtract(A, M);
                Q_1 = Q[3].ToString();
                string NewQ = A[3].ToString() + Q[0] + Q[1] + Q[2];
                Q = NewQ;

                string NewA = A[0].ToString() + A[0].ToString() + A[1].ToString() + A[2].ToString();
                A = NewA;
            }
        }

        Console.WriteLine("\n\nA = {0}, Q = {1}, Q_1 = {2} ", A, Q, Q_1);

    } 
    
    static string Add(string A, string M)
    {
        string answer;
        string carry = "0";
        string bin0 = "0", bin1 = "0", bin2 = "0", bin3 = "0";
        for (int i = 3; i >= 0; i--)
        {
            if (A[i] == '0' && M[i] == '0' && carry == "0")
            {
                if (i == 3)
                    bin3 = "0";
                else
                    if (i == 2)
                        bin2 = "0";
                    else
                        if (i == 1)
                            bin1 = "0";
                        else
                            if (i == 0)
                                bin0 = "0";

            }
            else
                if (A[i] == '0' && M[i] == '1' && carry == "0")
                {
                    if (i == 3)
                        bin3 = "1";
                    else
                        if (i == 2)
                            bin3 = "1";
                        else
                            if (i == 1)
                                bin2 = "1";
                            else
                                if (i == 0)
                                    bin1 = "1";
                }
                else
                    if (A[i] == '1' && M[i] == '0' && carry == "0")
                    {
                        if (i == 3)
                            bin3 = "1";
                        else
                            if (i == 2)
                                bin2 = "1";
                            else
                                if (i == 1)
                                    bin1 = "1";
                                else
                                    if (i == 0)
                                        bin0 = "1";
                    }
                    else
                        if (A[i] == '0' && M[i] == '0' && carry == "1")
                        {
                            carry = "0";
                            if (i == 3)
                                bin3 = "1";
                            else
                                if (i == 2)
                                    bin2 = "1";
                                else
                                    if (i == 1)
                                        bin1 = "1";
                                    else
                                        if (i == 0)
                                            bin0 = "1";
                        }
                        else
                            if (A[i] == '0' && M[i] == '1' && carry == "1")
                            {
                                carry = "1";
                                if (i == 3)
                                    bin3 = "0";
                                else
                                    if (i == 2)
                                        bin2 = "0";
                                    else
                                        if (i == 1)
                                            bin1 = "0";
                                        else
                                            if (i == 0)
                                                bin0 = "0";
                            }
                            else
                                if (A[i] == '1' && M[i] == '0' && carry == "1")
                                {
                                    carry = "1";
                                    if (i == 3)
                                        bin3 = "0";
                                    else
                                        if (i == 2)
                                            bin2 = "0";
                                        else
                                            if (i == 1)
                                                bin1 = "0";
                                            else
                                                if (i == 0)
                                                    bin0 = "0";
                                }
                                else if (A[i] == '1' && M[i] == '1' && carry == "0")
                                {
                                    carry = "1";
                                    if (i == 3)
                                        bin3 = "0";
                                    else
                                        if (i == 2)
                                            bin2 = "0";
                                        else
                                            if (i == 1)
                                                bin1 = "0";
                                            else
                                                if (i == 0)
                                                    bin0 = "0";
                                }
                                else if (A[i] == '1' && M[i] == '1' && carry == "1")
                                {
                                    carry = "1";
                                    if (i == 3)
                                        bin3 = "1";
                                    else
                                        if (i == 2)
                                            bin2 = "1";
                                        else
                                            if (i == 1)
                                                bin1 = "1";
                                            else
                                                if (i == 0)
                                                    bin0 = "1";
                                }

        }
        answer = bin0 + bin1 + bin2 + bin3;
        return answer;
    }

    static string Subtract(string A, string M)
    {
        bool shift = false;
        char bin3 = '0', bin2 = '0', bin1 = '0', bin0 = '0';

        for (int i = 3; i >= 0; i--)
        {
            if (shift)
            {
                if (M[i] == '0')
                {
                    if (i == 3)
                        bin3 = '1';
                    else if (i == 2)
                        bin2 = '1';
                    else if (i == 1)
                        bin1 = '1';
                    else if (i == 0)
                        bin0 = '1';
                }
                else
                    if (M[i] == '1')
                    {
                        if (i == 3)
                            bin3 = '0';
                        else if (i == 2)
                            bin2 = '0';
                        else if (i == 1)
                            bin1 = '0';
                        else if (i == 0)
                            bin0 = '0';
                    }

            }
            else
            {
                if (M[i] == '1')
                {
                    if (i == 3)
                        bin3 = '1';
                    else if (i == 2)
                        bin2 = '1';
                    else if (i == 1)
                        bin1 = '1';
                    else if (i == 0)
                        bin0 = '1';
                }
                else
                    if (M[i] == '0')
                    {
                        if (i == 3)
                            bin3 = '0';
                        else if (i == 2)
                            bin2 = '0';
                        else if (i == 1)
                            bin1 = '0';
                        else if (i == 0)
                            bin0 = '0';
                    }
            }

            if (M[i] == '1')
                shift = true;
        }

        string ans = bin0.ToString() + bin1.ToString() + bin2.ToString() + bin3.ToString();

        return ans;
    }
}
