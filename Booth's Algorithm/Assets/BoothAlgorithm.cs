using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BoothAlgorithm : MonoBehaviour
{

    public GameObject input1;
    public GameObject input2;
    public GameObject output;

    // Use this for initialization
    void Start()
    {
        output.GetComponent<Text>().text = "";

        string A = "00000000";
        string M, Q;
        string Q_1 = "0";

        M = input1.GetComponent<Text>().text;
        Q = input2.GetComponent<Text>().text;

        //Vars to test if inputs are signed 8 bits
        int Testi1 = System.Convert.ToInt16(M, 10);
        int Testi2 = System.Convert.ToInt16(Q, 10);

        //Console.Write("Please enter a 8 bit Multiplicant = ");
        //Debug.Log("Please enter a 8 bit Multiplicant = ");
        if (input1.GetComponent<Text>().text == "" || input2.GetComponent<Text>().text == "")
        {
            output.GetComponent<Text>().text += "One or more inputs are incomplete : Retry";
            this.enabled = false;
        }
        else if (Testi1 < -128 || Testi1 > 127)
        {
            output.GetComponent<Text>().text += "Input 1 is out of range : Retry";
            this.enabled = false;
        }
        else if (Testi2 < -128 || Testi2 > 127)
        {
            output.GetComponent<Text>().text += "Input 2 is out of range : Retry";
            this.enabled = false;
        }
        else
        {
            int CorrectAnswer = System.Convert.ToSByte(M) * System.Convert.ToSByte(Q);
            output.GetComponent<Text>().text += "\nfirst number = " + M;
            sbyte i1 = System.Convert.ToSByte(M, 10);
            M = System.Convert.ToString((byte)i1, 2).PadLeft(8, '0');
            output.GetComponent<Text>().text += "    :    first number in binary = " + "\" " + M + "\"";

            //Console.Write("Please enter a  8 bit Multiplier = ");
            //Debug.Log("Please enter a  8 bit Multiplier = ");

            output.GetComponent<Text>().text += "\nsecond number = " + Q;
            sbyte i2 = System.Convert.ToSByte(Q, 10);
            Q = System.Convert.ToString((byte)i2, 2).PadLeft(8,'0');
            output.GetComponent<Text>().text += "    :    second number in binary = " + "\" " + Q + "\"";

            output.GetComponent<Text>().text += "\nIteration                    Steps                      Multiplicand                        Product";
            output.GetComponent<Text>().text += "\n_______________________________________________________________________";
            output.GetComponent<Text>().text += "\nIteration: " + (0) + "            Initialization               M = " + M + "               " + A + "  " + Q + "_" + Q_1;
            output.GetComponent<Text>().text += "\n_______________________________________________________________________";

            //M = "00000101";
            //Q = "00000100";

            for (int i = 0; i < 8; i++)
            {
                string Qo_Q = Q[7] + Q_1;
                if (Qo_Q == "11" || Qo_Q == "00")
                {
                    //shift 
                    Q_1 = Q[7].ToString();
                    string NewQ = A[7].ToString() + Q[0] + Q[1] + Q[2] + Q[3] + Q[4] + Q[5] + Q[6];
                    Q = NewQ;

                    string NewA = A[0].ToString() + A[0].ToString() + A[1].ToString() + A[2].ToString() + A[3].ToString() + A[4].ToString() + A[5].ToString() + A[6].ToString();
                    A = NewA;

                }
                else if (Qo_Q == "01")
                {
                    A = Add(A, M);
                    output.GetComponent<Text>().text += "\nIteration: " + (i + 1) + "      Prod' += Multiplicand        M = " + M + "               " + A + "  " + Q + "_" + Q_1;
                    Q_1 = Q[7].ToString();
                    string NewQ = A[7].ToString() + Q[0] + Q[1] + Q[2] + Q[3] + Q[4] + Q[5] + Q[6];
                    Q = NewQ;

                    string NewA = A[0].ToString() + A[0].ToString() + A[1].ToString() + A[2].ToString() + A[3].ToString() + A[4].ToString() + A[5].ToString() + A[6].ToString();
                    A = NewA;
                }

                else if (Qo_Q == "10")
                {
                    //A = Subtract(A, M); #Replaced with finding 2's compliment and adding
                    string M_comp = TwosComp(M);
                    A = Add(A, M_comp);

                    output.GetComponent<Text>().text += "\nIteration: " + (i + 1) + "      Prod' -= Multiplicand        M = " + M + "               " + A + "  " + Q + "_" + Q_1;
                    Q_1 = Q[7].ToString();
                    string NewQ = A[7].ToString() + Q[0] + Q[1] + Q[2] + Q[3] + Q[4] + Q[5] + Q[6];
                    Q = NewQ;

                    string NewA = A[0].ToString() + A[0].ToString() + A[1].ToString() + A[2].ToString() + A[3].ToString() + A[4].ToString() + A[5].ToString() + A[6].ToString();
                    A = NewA;
                }
                output.GetComponent<Text>().text += "\nIteration: " + (i + 1) + "                 ASR                      M = " + M + "               " + A + "  " + Q + "_" + Q_1;
                output.GetComponent<Text>().text += "\n_______________________________________________________________________";
            }

            output.GetComponent<Text>().text += "\n         Final Answer:     " + A + "  " + Q;
            output.GetComponent<Text>().text += "\nAnswer = " + CorrectAnswer;
            this.enabled = false;
        }
    }

    void OnEnable()
    {
        this.Start();
    }

    static string Add(string A, string M)
    {
        string answer;
        string carry = "0";
        string bin0 = "0", bin1 = "0", bin2 = "0", bin3 = "0", bin4 = "0", bin5 = "0", bin6 = "0", bin7 = "0";
        for (int i = 7; i >= 0; i--)
        {
            if (A[i] == '0' && M[i] == '0' && carry == "0")
            {
                if (i == 7)
                    bin7 = "0";
                else
                    if (i == 6)
                        bin6 = "0";
                    else
                        if (i == 5)
                            bin5 = "0";
                        else
                            if (i == 4)
                                bin4 = "0";
                            else
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
            else if (A[i] == '0' && M[i] == '1' && carry == "0")
            {
                if (i == 7)
                    bin7 = "1";
                else
                    if (i == 6)
                        bin6 = "1";
                    else
                        if (i == 5)
                            bin5 = "1";
                        else
                            if (i == 4)
                                bin4 = "1";
                            else
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
            else if (A[i] == '1' && M[i] == '0' && carry == "0")
            {
                if (i == 7)
                    bin7 = "1";
                else
                    if (i == 6)
                        bin6 = "1";
                    else
                        if (i == 5)
                            bin5 = "1";
                        else
                            if (i == 4)
                                bin4 = "1";
                            else
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
            else if (A[i] == '0' && M[i] == '0' && carry == "1")
            {
                carry = "0";
                if (i == 7)
                    bin7 = "1";
                else
                    if (i == 6)
                        bin6 = "1";
                    else
                        if (i == 5)
                            bin5 = "1";
                        else
                            if (i == 4)
                                bin4 = "1";
                            else
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
            else if (A[i] == '0' && M[i] == '1' && carry == "1")
            {
                carry = "1";
                if (i == 7)
                    bin7 = "0";
                else
                    if (i == 6)
                        bin6 = "0";
                    else
                        if (i == 5)
                            bin5 = "0";
                        else
                            if (i == 4)
                                bin4 = "0";
                            else
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
            else if (A[i] == '1' && M[i] == '0' && carry == "1")
            {
                carry = "1";
                if (i == 7)
                    bin7 = "0";
                else
                    if (i == 6)
                        bin6 = "0";
                    else
                        if (i == 5)
                            bin5 = "0";
                        else
                            if (i == 4)
                                bin4 = "0";
                            else
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
                if (i == 7)
                    bin7 = "0";
                else
                    if (i == 6)
                        bin6 = "0";
                    else
                        if (i == 5)
                            bin5 = "0";
                        else
                            if (i == 4)
                                bin4 = "0";
                            else
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
                if (i == 7)
                    bin7 = "1";
                else
                    if (i == 6)
                        bin6 = "1";
                    else
                        if (i == 5)
                            bin5 = "1";
                        else
                            if (i == 4)
                                bin4 = "1";
                            else
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
        answer = bin0 + bin1 + bin2 + bin3 + bin4 + bin5 + bin6 + bin7;
        return answer;
    }

    static string TwosComp(string A)
    {
        string answer;
        string bin0 = "0", bin1 = "0", bin2 = "0", bin3 = "0", bin4 = "0", bin5 = "0", bin6 = "0", bin7 = "0";

        for (int i = 7; i >= 0; i--)
        {
            if (A[i] == '0')
            {
                if (i == 7)
                    bin7 = "1";
                else
                    if (i == 6)
                        bin6 = "1";
                    else
                        if (i == 5)
                            bin5 = "1";
                        else
                            if (i == 4)
                                bin4 = "1";
                            else
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
            else if (A[i] == '1')
            {
                if (i == 7)
                    bin7 = "0";
                else
                    if (i == 6)
                        bin6 = "0";
                    else
                        if (i == 5)
                            bin5 = "0";
                        else
                            if (i == 4)
                                bin4 = "0";
                            else
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
        }

        answer = bin0 + bin1 + bin2 + bin3 + bin4 + bin5 + bin6 + bin7;
        answer = Add(answer,"00000001");

        return answer;
    }

    static string Subtract(string A, string M)
    {
        bool shift = false;
        char bin0 = '0', bin1 = '0', bin2 = '0', bin3 = '0', bin4 = '0', bin5 = '0', bin6 = '0', bin7 = '0';

        for (int i = 7; i >= 0; i--)
        {
            if (shift)
            {
                if (M[i] == '0')
                {
                    if (i == 7)
                        bin7 = '1';
                    else if (i == 6)
                        bin6 = '1';
                    else if (i == 5)
                        bin5 = '1';
                    else if (i == 4)
                        bin4 = '1';
                    else if (i == 3)
                        bin3 = '1';
                    else if (i == 2)
                        bin2 = '1';
                    else if (i == 1)
                        bin1 = '1';
                    else if (i == 0)
                        bin0 = '1';
                }
                else if (M[i] == '1')
                {
                    if (i == 7)
                        bin7 = '0';
                    else if (i == 6)
                        bin6 = '0';
                    else if (i == 5)
                        bin5 = '0';
                    else if (i == 4)
                        bin4 = '0';
                    else if (i == 3)
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
                    if (i == 7)
                        bin7 = '1';
                    else if (i == 6)
                        bin6 = '1';
                    else if (i == 5)
                        bin5 = '1';
                    else if (i == 4)
                        bin4 = '1';
                    else if (i == 3)
                        bin3 = '1';
                    else if (i == 2)
                        bin2 = '1';
                    else if (i == 1)
                        bin1 = '1';
                    else if (i == 0)
                        bin0 = '1';
                }
                else if (M[i] == '0')
                {
                    if (i == 7)
                        bin7 = '0';
                    else if (i == 6)
                        bin6 = '0';
                    else if (i == 5)
                        bin5 = '0';
                    else if (i == 4)
                        bin4 = '0';
                    else if (i == 3)
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

        string ans = bin0.ToString() + bin1.ToString() + bin2.ToString() + bin3.ToString() + bin4.ToString() + bin5.ToString() + bin6.ToString() + bin7.ToString();

        return ans;
    }
}
